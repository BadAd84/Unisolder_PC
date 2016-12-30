Imports System.Windows.Forms
Imports System.IO

Public Class UniSolder

#Region "Enums"
    Public Enum UniSolder_Commands As Byte
        DEV_GET_INFO = &H60
        DEV_GET_OPERATING_MODE = &H61
        DEV_RESET = &H62

        APP_GET_INFO = &H80
        APP_JUMP_TO_BOOTLOADER = &H81
        APP_RESTART = &H82

        APP_SET_PID = 3
        APP_GET_PID = 4

        BL_GET_INFO = &HE0
        BL_ERASE_FLASH = &HE1
        BL_PROGRAM_FLASH = &HE2
        BL_READ_CRC = &HE3
        BL_JUMP_TO_APP = &HE4
        BL_PROGRAM_COMPLETE = &HE5
    End Enum

#End Region

#Region "Public subclasses"

    Public Class T_CommandFeedback
        Public IsEmpty As Boolean
        Public Command As Byte
        Public Status As Byte
        Public Data(1023) As Byte
        Public DataLength As UInt32

        Public Sub Clear()
            IsEmpty = True
            Command = 0
            Status = 0
            DataLength = 0
        End Sub

        Public Function ReadFromBuffer(ByRef bb() As Byte, ByVal Offset As UInt32, ByVal DLen As UInt32) As Boolean
            Dim i As UInt32
            Command = bb(Offset)
            'Status = bb(Offset + 1)
            DataLength = DLen - 1
            For i = 0 To DLen - 2
                Data(i) = bb(Offset + 1 + i)
            Next
            IsEmpty = False
            Return True
        End Function

        Public Sub New()
            Clear()
        End Sub
    End Class

    Public Class PID
        Public Gain As UInt16
        Public Offset As UInt16
        Public KP As UInt16
        Public KI As UInt16
        Public DGain As Byte
        Public OVSGain As Byte
    End Class
#End Region

    Public WithEvents TransLayer As SSComm.IUniComm

    Public CommandFeedBack As New T_CommandFeedback

    Public Event LiveDataReceived(ByVal Data() As Byte)
    Public Event InstrumentChange()

    Private TOTimer As New Stopwatch

    Public Sub Init()
        CommandFeedBack.Clear()
    End Sub

    Public Function DevGetInfo(ByRef dDevID As UInt32, ByRef dVerMaj As Byte, ByRef dVerMin As Byte) As Int32
        Dim bb() As Byte = {UniSolder_Commands.DEV_GET_INFO, 0, 0, 0, 0, 0, 0}
        Dim Result As Int32
        Result = SendBINCommand(bb, 0, 1, bb, 1000)
        If Result = 0 Then
            dDevID = bb(3)
            dDevID <<= 8
            dDevID += bb(2)
            dDevID <<= 8
            dDevID += bb(1)
            dDevID <<= 8
            dDevID += bb(0)
            dVerMin = bb(4)
            dVerMaj = bb(5)
            Debug.Print("Device info: ID=" & Format(dDevID, "X8") & " Version: " & dVerMaj & "." & dVerMin)
        End If
        Return Result
    End Function

    Public Function DevGetOpMode(ByRef dOpM As Byte) As Int32
        Dim bb() As Byte = {UniSolder_Commands.DEV_GET_OPERATING_MODE}
        Dim Result As Int32
        Result = SendBINCommand(bb, 0, 1, bb, 1000)
        If Result = 0 Then
            dOpM = bb(0)
            Debug.Print("Device operating mode: " & bb(0))
        End If
        Return Result
    End Function

    Public Sub DevReset()
        Dim bb() As Byte = {UniSolder_Commands.DEV_RESET}
        SendBINCommand(bb, 0, 1, Nothing, 0)
        Debug.Print("Device reset.")
    End Sub

    Public Function AppGetInfo(ByRef aVerMin As Byte, ByRef aVerMaj As Byte) As Int32
        Dim bb() As Byte = {UniSolder_Commands.APP_GET_INFO, 0}
        Dim Result As Int32
        Result = SendBINCommand(bb, 0, 1, bb, 1000)
        If Result = 0 Then
            aVerMin = bb(0)
            aVerMaj = bb(1)
            Debug.Print("Device application info: Version: " & aVerMaj & "." & aVerMin)
        End If
        Return Result
    End Function

    Public Sub AppJumpToBootloader()
        Dim bb() As Byte = {UniSolder_Commands.APP_JUMP_TO_BOOTLOADER}
        SendBINCommand(bb, 0, 1, Nothing, 0)
        Debug.Print("Jump to bootloader.")
    End Sub

    Public Sub AppRestart()
        Dim bb() As Byte = {UniSolder_Commands.APP_RESTART}
        SendBINCommand(bb, 0, 1, Nothing, 0)
        Debug.Print("Application restart.")
    End Sub

    Public Function AppGetPIDParameters() As PID
        Dim BB() As Byte = {UniSolder_Commands.APP_GET_PID, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        Debug.Print("Get PID paramaters")
        SendBINCommand(BB, 0, 1, BB, 1000)
        Return New PID() With {
            .Gain = Convert.ToUInt16(BB(0)) + Convert.ToUInt16(BB(1)) * 256,
            .Offset = Convert.ToUInt16(BB(2)) + Convert.ToUInt16(BB(3)) * 256,
            .KP = Convert.ToDouble(Convert.ToUInt32(BB(4)) + Convert.ToUInt32(BB(5)) * 256),
            .KI = Convert.ToDouble(Convert.ToUInt32(BB(6)) + Convert.ToUInt32(BB(7)) * 256),
            .DGain = Convert.ToUInt16(BB(8)) + Convert.ToUInt16(BB(9)) * 256,
            .OVSGain = Convert.ToUInt16(BB(10)) + Convert.ToUInt16(BB(11)) * 256
        }
    End Function

    Public Function AppSetPIDParameters(ByRef PID As PID)
        Dim BB() As Byte = {
            UniSolder_Commands.APP_SET_PID,
            PID.Gain And 255, PID.Gain \ 256,
            0, 0,
            PID.KP And 255, PID.KP \ 256,
            PID.KI And 255, PID.KI \ 256,
            PID.DGain, 0,
            PID.OVSGain, 0
        }
        SendBINCommand(BB, 0, BB.Length, Nothing, 0)
    End Function

    Public Function BlGetInfo(ByRef blVerMaj As Byte, ByRef blVerMin As Byte) As Int32
        Dim bb() As Byte = {UniSolder_Commands.BL_GET_INFO, 0}
        Dim Result As Int32
        SendBINCommand(bb, 0, 1, bb, 1000)
        If Result = 0 Then
            blVerMin = bb(0)
            blVerMaj = bb(1)
            Debug.Print("Bootloader information: Version=" & blVerMaj & "." & blVerMin)
        End If
        Return Result
    End Function

    Public Function BlEraseFlash() As Int32
        Dim bb() As Byte = {UniSolder_Commands.BL_ERASE_FLASH, &H34, &H12, &H21, &H43}
        Debug.Print("BlEraseFlash")
        Return SendBINCommand(bb, 0, 5, Nothing, 6000)
    End Function

    Public Function BlProgramFlash(ByVal pfAddr As UInt32, ByRef byteBuff() As Byte, ByVal bbOffset As UInt32, ByVal bbCount As UInt32) As Int32
        Dim bb(64) As Byte
        Dim i As UInt32
        If bbCount > 0 Then
            bb(0) = UniSolder_Commands.BL_PROGRAM_FLASH
            bb(1) = &H34
            bb(2) = &H12
            bb(3) = &H21
            bb(4) = &H43
            bb(5) = (pfAddr And &HFF&)
            bb(6) = ((pfAddr >> 8) And &HFF&)
            bb(7) = ((pfAddr >> 16) And &HFF&)
            bb(8) = ((pfAddr >> 24) And &HFF&)
            bb(9) = (bbCount And &HFF&)
            bb(10) = ((bbCount >> 8) And &HFF&)
            bb(11) = ((bbCount >> 16) And &HFF&)
            bb(12) = ((bbCount >> 24) And &HFF&)
            For i = 0 To bbCount - 1
                bb(13 + i) = byteBuff(bbOffset + i)
            Next
            Return SendBINCommand(bb, 0, 13 + bbCount, Nothing, 1000)
        Else
            Return 0
        End If
    End Function

    Public Function BlProgramComplete() As Int32
        Dim bb() As Byte = {UniSolder_Commands.BL_PROGRAM_COMPLETE, &H34, &H12, &H21, &H43}
        Debug.Print("BlProgramComplete")
        Return SendBINCommand(bb, 0, 5, Nothing, 1000)
    End Function

    Public Function BlReadCRC(ByVal pfAddr As UInt32, ByVal pfCount As UInt32, ByRef pfCRC As UInt16) As Int32
        Dim bb(8) As Byte
        Dim Result As Int32 = 0
        If pfCount > 0 Then
            bb(0) = UniSolder_Commands.BL_READ_CRC
            bb(1) = (pfAddr And &HFF&)
            bb(2) = ((pfAddr >> 8) And &HFF&)
            bb(3) = ((pfAddr >> 16) And &HFF&)
            bb(4) = ((pfAddr >> 24) And &HFF&)
            bb(5) = (pfCount And &HFF&)
            bb(6) = ((pfCount >> 8) And &HFF&)
            bb(7) = ((pfCount >> 16) And &HFF&)
            bb(8) = ((pfCount >> 24) And &HFF&)
            Result = SendBINCommand(bb, 0, 9, bb, 5000)
            If Result = 0 Then
                pfCRC = bb(1)
                pfCRC <<= 8
                pfCRC += bb(0)
            End If
        End If
        Return Result
    End Function

    Public Sub BlJumpToApplication()
        Dim bb() As Byte = {UniSolder_Commands.BL_JUMP_TO_APP}
        SendBINCommand(bb, 0, 1, Nothing, 0)
    End Sub

    Private Function SendBINCommand(ByRef OutBuffer() As Byte, ByVal OutOffset As UInt32, ByVal OutCount As UInt32, Optional ByRef RespBuffer() As Byte = Nothing, Optional ByVal TimeOut As UInt32 = 5000) As Int32
        Dim i As Int32
        Dim rv As Boolean
        Dim OB(63) As Byte
        If OutCount > 0 Then
            SyncLock TOTimer
                For i = 0 To OutCount - 1
                    OB(i) = OutBuffer(i)
                Next
                TransLayer.Write(OB, 0, 64)
                If TimeOut > 0 Then    'wait for feedback
                    CommandFeedBack.IsEmpty = True
                    rv = -1 '-1=timeout
                    TOTimer.Restart()
                    While TOTimer.ElapsedMilliseconds < TimeOut
                        If Not CommandFeedBack.IsEmpty Then
                            If OutBuffer(0) = CommandFeedBack.Command Then
                                rv = CommandFeedBack.Status
                                If RespBuffer IsNot Nothing Then
                                    i = Math.Min(UBound(RespBuffer) + 1, CommandFeedBack.DataLength)
                                    While (i)
                                        i = i - 1
                                        RespBuffer(i) = CommandFeedBack.Data(i)
                                    End While
                                End If
                                Exit While
                            Else
                                CommandFeedBack.IsEmpty = True
                            End If
                        End If
                    End While
                    TOTimer.Stop()
                Else
                    rv = 0
                End If
            End SyncLock
        Else
            rv = 0
        End If
        Return rv
    End Function

    Private RXFBuff(64) As Byte

    Private Sub TransLayer_DataReceived() Handles TransLayer.DataReceived
        Dim rlen As Int32
        Dim RXB(64) As Byte
        While TransLayer.RXDataCount >= 64
            rlen = TransLayer.Read(RXB, 0, 64)
            ProcessRXMessage(RXB)
        End While
    End Sub

    Private Function ProcessRXMessage(ByRef RXB() As Byte) As Boolean
        Select Case RXB(0)
            Case 1
                RaiseEvent InstrumentChange()
            Case 3
                RaiseEvent LiveDataReceived(RXB)
            Case Else

                CommandFeedBack.ReadFromBuffer(RXB, 0, 64)
        End Select
        Return True
    End Function

    Private Function CalculateCRC(ByRef data() As Byte, ByVal boff As UInt32, ByVal blen As UInt32) As UInt16
        Dim crc_table() As UInt16 = {&H0, &H1021, &H2042, &H3063, &H4084, &H50A5, &H60C6, &H70E7, &H8108, &H9129, &HA14A, &HB16B, &HC18C, &HD1AD, &HE1CE, &HF1EF}
        Dim i As UInt32
        Dim i1 As UInt32
        Dim crc As UInt16
        crc = 0
        i1 = boff
        While blen > 0
            i = (crc >> 12) Xor (data(i1) >> 4)
            crc = crc_table(i And 15) Xor (crc << 4)
            i = (crc >> 12) Xor data(i1)
            crc = crc_table(i And 15) Xor (crc << 4)
            i1 += 1
            blen -= 1
        End While
        Return crc
    End Function

End Class

Public Class HexFileManager
    Private VirtualFlash(5 * 1024 * 1024) As Byte
    Private Const BOOT_SECTOR_BEGIN As UInt32 = &H9FC00000&
    Private Const APPLICATION_START As UInt32 = &H9D000000&

    Private Const DATA_RECORD As Byte = 0
    Private Const END_OF_FILE_RECORD As Byte = 1
    Private Const EXT_SEG_ADRS_RECORD As Byte = 2
    Private Const EXT_LIN_ADRS_RECORD As Byte = 4

    Private HexFilePath As String

    Public Class HexDataRecord
        Public Address As UInt32
        Public RecDataLen As UInt32
        Public Data(1023) As Byte
        Public CheckSum As Byte
    End Class

    Private lHexDataRecords() As HexDataRecord
    Private lHexDataRecCount As UInt32

    Public Property HexDataRecordsCount() As UInt32
        Get
            Return lHexDataRecCount
        End Get
        Set(value As UInt32)
            ReDim Preserve lHexDataRecords(value - 1)
            For i = lHexDataRecCount To value - 1
                lHexDataRecords(i) = New HexDataRecord
            Next
            lHexDataRecCount = value
        End Set
    End Property

    Public Property HexDataRecords(index As UInt32) As HexDataRecord
        Get
            Return lHexDataRecords(index)
        End Get
        Set(value As HexDataRecord)
            lHexDataRecords(index) = value
        End Set
    End Property

    Private FileReader As StreamReader

    Private Function PA_TO_VFA(ByVal x As UInt32) As UInt32
        Return (x - APPLICATION_START)
    End Function

    Private Function PA_TO_KVA0(ByVal x As UInt32) As UInt32
        Return (x Or &H80000000&)
    End Function

    Public Function LoadHexFile(ByVal filepath As String) As Boolean
        Dim i As UInt32
        Dim i1 As UInt32
        Dim ldrnum As UInt32
        Dim rectype As Byte
        Dim rv As Boolean
        Dim s As String
        Dim cAddress As UInt32
        Dim ccs As UInt32
        Dim cExtSegAddress As UInt32
        Dim cExtLinAddress As UInt32

        rv = False
        FileReader = Nothing
        Try
            FileReader = New StreamReader(filepath)
        Catch ex As Exception
            Exit Try
        End Try
        If FileReader IsNot Nothing Then
            ldrnum = 0
            'Try
            While Not FileReader.EndOfStream
                s = Trim(FileReader.ReadLine)
                If s.Length >= 11 Then
                    If s.Chars(0) = ":" Then
                        ccs = 0
                        For i = 0 To ((s.Length - 1) / 2) - 2
                            ccs = ccs + CUInt("&H" & Mid(s, 2 + (i * 2), 2))
                            ccs = ccs And &HFF&
                        Next
                        ccs = (&H100& - ccs) And &HFF&
                        If ccs = CUInt("&H" & Right(s, 2)) Then
                            rectype = CByte("&H" & Mid(s, 8, 2))
                            If rectype = 0 Then ldrnum += 1
                        Else
                            FileReader.Close()
                            Return False
                        End If
                    Else
                        FileReader.Close()
                        Return False
                    End If
                End If
            End While

            If ldrnum > 0 Then
                'Try
                HexDataRecordsCount = ldrnum
                ldrnum = 0
                cAddress = 0
                cExtSegAddress = 0
                cExtLinAddress = 0
                FileReader.BaseStream.Seek(0, SeekOrigin.Begin)
                While Not FileReader.EndOfStream
                    s = Trim(FileReader.ReadLine)
                    If s.Length >= 11 Then
                        If s.Chars(0) = ":" Then
                            ccs = 0
                            For i = 0 To ((s.Length - 1) / 2) - 2
                                ccs = ccs + CUInt("&H" & Mid(s, 2 + (i * 2), 2))
                                ccs = ccs And &HFF&
                            Next
                            ccs = (&H100& - ccs) And &HFF&
                            If ccs = CUInt("&H" & Right(s, 2)) Then
                                rectype = CByte("&H" & Mid(s, 8, 2))
                                Select Case rectype
                                    Case DATA_RECORD
                                        With lHexDataRecords(ldrnum)
                                            .Address = CUInt("&H" & Mid(s, 4, 4)) + cExtSegAddress + cExtLinAddress
                                            .RecDataLen = CUInt("&H" & Mid(s, 2, 2))
                                            For i = 1 To .RecDataLen
                                                .Data(i - 1) = CByte("&H" & Mid(s, 10 + (i - 1) * 2, 2))
                                            Next
                                            If ldrnum > 0 Then
                                                If .Address = (lHexDataRecords(ldrnum - 1).Address + lHexDataRecords(ldrnum - 1).RecDataLen) Then
                                                    While ((.RecDataLen > 0)) ' And ((.Address And 1023&) <> 0&))
                                                        If lHexDataRecords(ldrnum - 1).RecDataLen < 48 Then
                                                            lHexDataRecords(ldrnum - 1).Data(lHexDataRecords(ldrnum - 1).RecDataLen) = .Data(0)
                                                            lHexDataRecords(ldrnum - 1).RecDataLen += 1
                                                            .Address += 1
                                                            .RecDataLen -= 1
                                                            For i = 1 To .RecDataLen
                                                                .Data(i - 1) = .Data(i)
                                                            Next
                                                        Else
                                                            Exit While
                                                        End If
                                                    End While
                                                End If
                                            End If
                                            If .RecDataLen > 0 Then ldrnum += 1
                                        End With
                                    Case EXT_SEG_ADRS_RECORD
                                        cExtSegAddress = CUInt("&H" & Mid(s, 10, 4)) << 8
                                        cExtLinAddress = 0
                                    Case EXT_LIN_ADRS_RECORD
                                        cExtLinAddress = CUInt("&H" & Mid(s, 10, 4)) << 16
                                        cExtSegAddress = 0
                                    Case END_OF_FILE_RECORD
                                    Case Else
                                        cExtLinAddress = 0
                                        cExtSegAddress = 0
                                End Select
                            Else
                                FileReader.Close()
                                Return False
                            End If
                        Else
                            FileReader.Close()
                            Return False
                        End If
                    End If
                End While
                lHexDataRecCount = ldrnum
                For i = 1 To lHexDataRecCount
                    With lHexDataRecords(i - 1)
                        s = ""
                        For i1 = 1 To .RecDataLen
                            s = s & Format(.Data(i1 - 1), "X2")
                        Next i1
                        'Debug.Print(Format(PA_TO_KVA0(.Address), "X8") & "(" & Format(.RecDataLen, "X2") & "): " & s)
                    End With
                Next i
            End If
        End If
        FileReader.Close()
        FileReader = Nothing
        Return True
    End Function

End Class
