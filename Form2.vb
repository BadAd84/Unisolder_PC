Imports System.Windows.Forms
Imports System.Diagnostics

Public Class Form2
    Dim CPoint As Int32
    'Dim rMsg As New USBCAN.T_CANMsg
    Private WithEvents lUniSolder As New UniSolder
    'Private withevents ud As SSComm.USBHID

    Private PID As UniSolder.PID = Nothing

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Form2_Disposed(sender As Object, e As System.EventArgs) Handles Me.Disposed
        lUniSolder.TransLayer.Dispose()
    End Sub

    Private Sub Form2_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    End Sub

    Private Sub Form2_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    End Sub


    Private Sub Form2_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        SsChart2.DrawingsNum = 13
        With SsChart2.Scales(0)
            .ValFrom = 0
            .ValTo = 10.24
            .ValMinStep = 1 / 25
            .ValMajStep = 1
            .ValFormat = "0"
        End With
        With SsChart2.Scales(1)
            .ValFrom = 0
            .ValTo = 500
            .ValMinStep = 10
            .ValMajStep = 50
            .ValFormat = "0"
        End With
        With SsChart2.Drawings(0)
            .XScale = SsChart2.Scales(0)
            .Yscale = SsChart2.Scales(1)
            .Pen.Color = Color.Yellow
            .Pen.Width = 1
            .PointsNum = 2
            .Points(0).X = .XScale.ValFrom
            .Points(0).Y = .Yscale.ValFrom
            .Points(1).X = .XScale.ValFrom
            .Points(1).Y = .Yscale.ValTo
        End With
        With SsChart2.Drawings(1)
            .XScale = SsChart2.Scales(0)
            .Yscale = SsChart2.Scales(1)
            .Pen.Color = Color.DarkRed
            .Pen.Width = 2
            .PointsNum = 256
            For i = 0 To 255
                With .Points(i)
                    .X = i / 50
                    .Y = 10
                End With
            Next
        End With
        With SsChart2.Drawings(2)
            .XScale = SsChart2.Scales(0)
            .Yscale = SsChart2.Scales(1)
            .Pen.Color = Color.Red
            .Pen.Width = 2
            .PointsNum = 256
            For i = 0 To 255
                With .Points(i)
                    .X = i / 50
                    .Y = 10
                End With
            Next
        End With
        With SsChart2.Drawings(3)
            .XScale = SsChart2.Scales(0)
            .Yscale = SsChart2.Scales(1)
            .Pen.Color = Color.LightGreen
            .Pen.Width = 2
            .PointsNum = 256
            For i = 0 To 255
                With .Points(i)
                    .X = i / 50
                    .Y = 10
                End With
            Next
        End With
        With SsChart2.Drawings(4)
            .XScale = SsChart2.Scales(0)
            .Yscale = SsChart2.Scales(1)
            .Pen.Color = Color.SkyBlue
            .Pen.Width = 2
            .PointsNum = 256
            For i = 0 To 255
                With .Points(i)
                    .X = i / 50
                    .Y = 10
                End With
            Next
        End With
        With SsChart2.Drawings(5)
            .XScale = SsChart2.Scales(0)
            .Yscale = SsChart2.Scales(1)
            .Pen.Color = Color.Magenta
            .Pen.Width = 2
            .PointsNum = 256
            For i = 0 To 255
                With .Points(i)
                    .X = i / 50
                    .Y = 10
                End With
            Next
        End With
        With SsChart2.Drawings(6)
            .XScale = SsChart2.Scales(0)
            .Yscale = SsChart2.Scales(1)
            .Pen.Color = Color.Yellow
            .Pen.Width = 2
            .PointsNum = 256
            For i = 0 To 255
                With .Points(i)
                    .X = i / 50
                    .Y = 10
                End With
            Next
        End With

        With SsChart2.Drawings(7)
            .XScale = SsChart2.Scales(0)
            .Yscale = SsChart2.Scales(1)
            .Pen.Color = Color.Blue
            .Pen.Width = 2
            .PointsNum = 256
            For i = 0 To 255
                With .Points(i)
                    .X = i / 50
                    .Y = 10
                End With
            Next
        End With

        With SsChart2.Drawings(8)
            .XScale = SsChart2.Scales(0)
            .Yscale = SsChart2.Scales(1)
            .Pen.Color = Color.LightGray
            .Pen.Width = 2
            .PointsNum = 256
            For i = 0 To 255
                With .Points(i)
                    .X = i / 50
                    .Y = 10
                End With
            Next
        End With

        With SsChart2.Drawings(9)
            .XScale = SsChart2.Scales(0)
            .Yscale = SsChart2.Scales(1)
            .Pen.Color = Color.Orange
            .Pen.Width = 2
            .PointsNum = 256
            For i = 0 To 255
                With .Points(i)
                    .X = i / 50
                    .Y = 10
                End With
            Next
        End With

        With SsChart2.Drawings(10)
            .XScale = SsChart2.Scales(0)
            .Yscale = SsChart2.Scales(1)
            .Pen.Color = Color.White
            .Pen.Width = 2
            .PointsNum = 8
            For i = 0 To 7
                With .Points(i)
                    .X = i / 50
                    .Y = 10
                End With
            Next
        End With

        With SsChart2.Drawings(11)
            .XScale = SsChart2.Scales(0)
            .Yscale = SsChart2.Scales(1)
            .Pen.Color = Color.Green
            .Pen.Width = 2
            .PointsNum = 256
            For i = 0 To 255
                With .Points(i)
                    .X = i / 50
                    .Y = 10
                End With
            Next
        End With

        With SsChart2.Drawings(12)
            .XScale = SsChart2.Scales(0)
            .Yscale = SsChart2.Scales(1)
            .Pen.Color = Color.DarkSlateBlue
            .Pen.Width = 2
            .PointsNum = 256
            For i = 0 To 255
                With .Points(i)
                    .X = i / 50
                    .Y = 10
                End With
            Next
        End With

        lUniSolder = New UniSolder
        lUniSolder.TransLayer = New SSComm.USBHID
        With TryCast(lUniSolder.TransLayer, SSComm.USBHID)
            .DevVID = &H4D8
            .DevPID = &H3C
        End With
        Debug.Print("Connecting.....")
        Debug.Print(lUniSolder.TransLayer.Connect().ToString())
        'Dim aa(64) As Byte
        'aa(0) = 0
        'lUniSolder.TransLayer.Write(aa, 0, 64)
        'lUniSolder.TransLayer.Write(aa, 0, 64)

        System.Threading.Thread.Sleep(500)
        InstrumentChange()
        'PID = lUniSolder.AppGetPIDParameters()
        'KpTrackBar.Value = PID.KP
        'KiTrackBar.Value = PID.KI
        'DGTrackBar.Value = PID.DGain
        'OVFGTrackBar.Value = PID.OVSGain
        'GTrackBar.Value = PID.Gain
        'Dim b(64) As Byte
        'b(0) = 4
        'ud.Write(b, 0, 64)
        'Timer1.Enabled = True
    End Sub

    Delegate Sub InstrumentChangeDelegate()
    Private Sub InstrumentChange() Handles lUniSolder.InstrumentChange
        If (KpTrackBar.InvokeRequired) Then
            Me.BeginInvoke(New InstrumentChangeDelegate(AddressOf InstrumentChange))
        Else
            'Timer1.Enabled = False
            PID = lUniSolder.AppGetPIDParameters()
            KpTrackBar.Value = PID.KP
            KiTrackBar.Value = PID.KI
            DGTrackBar.Value = PID.DGain
            OVFGTrackBar.Value = PID.OVSGain
            GTrackBar.Value = PID.Gain
            'Timer1.Enabled = True
        End If
    End Sub

    Delegate Sub LiveDataReceivedDelegate(ByVal b() As Byte)
    Private Sub LiveDataReceived(ByVal b() As Byte) Handles lUniSolder.LiveDataReceived
        Dim i As Integer
        'Dim s As String
        'Dim b(64) As Byte
        If SsChart2.InvokeRequired Then
            Me.BeginInvoke(New LiveDataReceivedDelegate(AddressOf LiveDataReceived), b)
        Else
            Select Case b(0)
                Case 3
                    If Button8.Text <> "START" Then
                        SsChart2.Drawings(0).Points(0).X = SsChart2.Drawings(1).Points(CPoint).X
                        SsChart2.Drawings(0).Points(1).X = SsChart2.Drawings(1).Points(CPoint).X
                        SsChart2.Drawings(1).Points(CPoint).Y = (b(32) * 1.0 + b(33) * 256.0) / 128.0   'Duty
                        SsChart2.Drawings(2).Points(CPoint).Y = b(3) * 2.0 'CTTemp
                        SsChart2.Drawings(3).Points(CPoint).Y = b(4) * 0.5 + b(5) * 128.0 + 30 'CTemp
                        SsChart2.Drawings(4).Points(CPoint).Y = b(6) * 0.5 + b(7) * 128.0   'ADCTemp
                        SsChart2.Drawings(5).Points(CPoint).Y = b(8) * 0.5 + b(9) * 128.0   'TAvgF
                        'SsChart2.Drawings(6).Points(CPoint).Y = (b(10) * 1.0 + b(11) * 256.0 - 2048.0) / 4.0 + 200.0
                        SsChart2.Drawings(7).Points(CPoint).Y = IIf(b(14) <> 0, 100.0, 0.0) 'Heater
                        SsChart2.Drawings(8).Points(CPoint).Y = (b(10) * 1.0 + b(11) * 256.0) / 4 'CHRes
                        SsChart2.Drawings(9).Points(CPoint).Y = b(12) * 0.5 + b(13) * 128.0 'TAvgP

                        SsChart2.Drawings(10).Points(0).Y = (b(15) * 1.0 + b(16) * 256.0 - 2048.0) / 4.0 + 200.0 'WSDelta
                        SsChart2.Drawings(10).Points(1).Y = (b(17) * 1.0 + b(18) * 256.0 - 2048.0) / 4.0 + 200.0
                        SsChart2.Drawings(10).Points(2).Y = (b(19) * 1.0 + b(20) * 256.0 - 2048.0) / 4.0 + 200.0
                        SsChart2.Drawings(10).Points(3).Y = (b(21) * 1.0 + b(22) * 256.0 - 2048.0) / 4.0 + 200.0
                        SsChart2.Drawings(10).Points(4).Y = (b(23) * 1.0 + b(24) * 256.0 - 2048.0) / 4.0 + 200.0
                        SsChart2.Drawings(10).Points(5).Y = (b(25) * 1.0 + b(26) * 256.0 - 2048.0) / 4.0 + 200.0
                        SsChart2.Drawings(10).Points(6).Y = (b(27) * 1.0 + b(28) * 256.0 - 2048.0) / 4.0 + 200.0
                        SsChart2.Drawings(10).Points(7).Y = (b(29) * 1.0 + b(30) * 256.0 - 2048.0) / 4.0 + 200.0

                        SsChart2.Drawings(11).Points(CPoint).Y = b(31) * 100.0  'DestinationReached


                        'SsChart2.Drawings(12).Points(CPoint).Y = (b(34) * 1.0 + b(35) * 256.0);

                        CPoint = (CPoint + 1) Mod 256
                        'If(CPoint Mod 20) Then SsChart2._Redraw()
                    End If
            End Select
            If Not SsChart2.redrawactive Then SsChart2._Redraw()
        End If
    End Sub

    'Delegate Sub tlmrcb()
    'Private Sub lUSBCAN_CANMsgReceived() Handles lUSBCAN.CANMsgReceived
    '    If SsChart2.InvokeRequired Then
    '        Dim d As New tlmrcb(AddressOf lUSBCAN_CANMsgReceived)
    '        Try
    '            Me.BeginInvoke(d, New Object() {})
    '        Catch ex As Exception
    '            Exit Try
    '        End Try
    '    Else
    '        While lUSBCAN.CANMsgCount > 0
    '            rMsg = lUSBCAN.CANReadMsg()
    '            If rMsg.ID = 1001 Then
    '                With rMsg
    '                    SsChart2.Drawings(1).Points(CPoint).Y = 5.0 + (CDbl(rMsg.SWord(0)) * 5 / 1024)
    '                    SsChart2.Drawings(2).Points(CPoint).Y = (CDbl(rMsg.Word(2) And &H7FFF) * 5 / 32768)
    '                    SsChart2.Drawings(4).Points(CPoint).Y = (CDbl(rMsg.SWord(4)) * 20 / 32768)
    '                    SsChart2.Drawings(5).Points(CPoint).Y = (CDbl(rMsg.SWord(6)) * 20 / 32768)
    '                    SsChart2.Drawings(3).Points(CPoint).Y = (CDbl((rMsg.Word(2) >> 15)) * 5)

    '                    SsChart2.Drawings(0).Points(0).X = SsChart2.Drawings(1).Points(CPoint).X
    '                    SsChart2.Drawings(0).Points(1).X = SsChart2.Drawings(1).Points(CPoint).X

    '                    CPoint = (CPoint + 1) Mod 2000
    '                    If Not SsChart2.redrawactive Then SsChart2._Redraw()
    '                    'If (CPoint Mod 30) = 0 Then SsChart2._Redraw()
    '                End With
    '            End If
    '        End While
    '    End If
    'End Sub

    'Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
    '    Dim b(64) As Byte
    '    Dim d As Int32

    '    b(0) = 3

    '    d = KpTrackBar.Value * 32768 / 100
    '    b(1) = d And 255
    '    d = d >> 8
    '    b(2) = d And 255

    '    d = KiTrackBar.Value * 32768 / 1000
    '    b(3) = d And 255
    '    d = d >> 8
    '    b(4) = d And 255

    '    b(5) = DGTrackBar.Value
    '    b(6) = OVFGTrackBar.Value

    '    d = GTrackBar.Value
    '    b(7) = d And 255
    '    d = d >> 8
    '    b(8) = d And 255


    '    lUniSolder.AppSetPIDParameters(New UniSolder.PID() With {
    '                                   .KP = KpTrackBar.Value,
    '                                   .KI = KiTrackBar.Value,
    '                                   .DGain = DGTrackBar.Value,
    '                                   .OVSGain = OVFGTrackBar.Value,
    '                                   .Gain = GTrackBar.Value,
    '                                   .Offset = 0})

    'End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim i As UInt32
        Dim b As Byte
        Dim b1 As Byte
        lUniSolder.DevGetInfo(i, b, b1)
        lUniSolder.BlGetInfo(b, b1)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim b As Byte
        lUniSolder.DevGetOpMode(b)
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Dim i As UInt32
        Dim i1 As UInt32
        Dim lStopWatch As New Stopwatch
        Dim cResult As Int32
        Dim sst As New Stopwatch
        Dim ss As New HexFileManager
        Dim HexFilePath As OpenFileDialog = New OpenFileDialog()
        Dim strFileName As String
        'Dim bb(1000) As Byte

        HexFilePath.Title = "Select Firmware Update..."
        HexFilePath.InitialDirectory = "C:\"
        HexFilePath.Filter = "Hex Files (*.hex)|*.hex"
        HexFilePath.FilterIndex = 2
        HexFilePath.Multiselect = False
        HexFilePath.RestoreDirectory = True

        If HexFilePath.ShowDialog() = DialogResult.OK Then
            strFileName = HexFilePath.FileName
            If ss.LoadHexFile(strFileName) Then
                Debug.Print("Hex File loaded successfully")

                Debug.Print("Erasing Flash...")
                sst.Restart()
                lUniSolder.BlEraseFlash()
                sst.Stop()
                Debug.Print("Erasing completed in " & sst.Elapsed.ToString)

                Debug.Print("Programming started...")
                sst.Restart()
                For i = 0 To ss.HexDataRecordsCount - 1
                    With ss.HexDataRecords(i)
                        cResult = lUniSolder.BlProgramFlash(.Address, .Data, 0, .RecDataLen)
                        Select Case cResult
                            Case 0
                                'Debug.Print(i & "(" & Format(.Address, "X8") & "," & .RecDataLen & ")")
                            Case -1
                                Debug.Print("(" & i & "):Time Out")
                            Case Else
                                Debug.Print("(" & i & "):Error(" & cResult & ")")
                        End Select
                    End With
                    If cResult <> 0 Then Exit For
                Next
                lUniSolder.BlProgramComplete()
                sst.Stop()
                Debug.Print("Programming completed in " & sst.Elapsed.ToString)
            End If
        End If

    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        lUniSolder.BlJumpToApplication()
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        lUniSolder.AppJumpToBootloader()
    End Sub

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        'lUSBCAN.DevReset()
        Dim b(64) As Byte
        b(0) = 2
        lUniSolder.TransLayer.Write(b, 0, 64)
        'ud.Write(b, 0, 64)
    End Sub

    Private Sub Button7_Click(sender As System.Object, e As System.EventArgs) Handles Button7.Click
        Dim RLE As New RLE
        RLE.LoadFile("C:\Users\Sparky\Desktop\MyProjects\Electronics\DDLCD\Xilinx\DDLCD_seq\top.svf")
    End Sub

    Private Sub KpTrackBar_ValueChanged(sender As Object, e As System.EventArgs) Handles KpTrackBar.ValueChanged
        KpLabel.Text = "Kp = " & Format((KpTrackBar.Value / 32767), "0.00")
        If (PID.KP <> KpTrackBar.Value) Then
            PID.KP = KpTrackBar.Value
            lUniSolder.AppSetPIDParameters(PID)
        End If
    End Sub

    Private Sub KiTrackBar_ValueChanged(sender As System.Object, e As System.EventArgs) Handles KiTrackBar.ValueChanged
        KiLabel.Text = "Ki = " & Format((KiTrackBar.Value / 32767), "0.000")
        If (PID.KI <> KiTrackBar.Value) Then
            PID.KI = KiTrackBar.Value
            lUniSolder.AppSetPIDParameters(PID)
        End If
    End Sub

    Private Sub DGTrackBar_ValueChanged(sender As System.Object, e As System.EventArgs) Handles DGTrackBar.ValueChanged
        DGLabel.Text = "DGain = " & Format(DGTrackBar.Value)
        If (PID.DGain <> DGTrackBar.Value) Then
            PID.DGain = DGTrackBar.Value
            lUniSolder.AppSetPIDParameters(PID)
        End If
    End Sub

    Private Sub OVFGTrackBar_ValueChanged(sender As System.Object, e As System.EventArgs) Handles OVFGTrackBar.ValueChanged
        OVFGLabel.Text = "OVFGain = " & Format(OVFGTrackBar.Value)
        If (PID.OVSGain <> OVFGTrackBar.Value) Then
            PID.OVSGain = OVFGTrackBar.Value
            lUniSolder.AppSetPIDParameters(PID)
        End If
    End Sub

    Private Sub GTrackBar_ValueChanged(sender As System.Object, e As System.EventArgs) Handles GTrackBar.ValueChanged
        GLabel.Text = "Gain = " & Format(GTrackBar.Value)
        If (PID.Gain <> GTrackBar.Value) Then
            PID.Gain = GTrackBar.Value
            lUniSolder.AppSetPIDParameters(PID)
        End If
    End Sub

    Private Sub Button8_Click(sender As System.Object, e As System.EventArgs) Handles Button8.Click
        If Button8.Text = "STOP" Then
            Button8.Text = "START"
        Else
            Button8.Text = "STOP"
        End If
    End Sub

    Private Sub GTrackBar_Scroll(sender As System.Object, e As System.EventArgs) Handles GTrackBar.Scroll

    End Sub

    Private Sub GLabel_Click(sender As System.Object, e As System.EventArgs) Handles GLabel.Click

    End Sub

    Private Sub KpTrackBar_Scroll(sender As Object, e As EventArgs) Handles KpTrackBar.Scroll

    End Sub

    Private Sub OVFGTrackBar_Scroll(sender As Object, e As EventArgs) Handles OVFGTrackBar.Scroll

    End Sub
End Class