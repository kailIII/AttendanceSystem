﻿Imports System.Drawing.Printing
Imports AxZKFPEngXControl
Imports GridPrintPreviewLib

Public Class In_Out
    'Dim TodayDate As Date
    Dim ServerDate As Date
    'Dim TimeSpanX As TimeSpan = Date.Now.TimeOfDay
    Dim matchType As Integer = 0
    Dim sRegTemplate As String = String.Empty
    Dim sRegTemplate10 As String = String.Empty
    Dim tempUserName As String = String.Empty
    Dim DataGridViewSized As DataGridView
    Private Sub In_Out_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.AttendanceTableTableAdapter1.Fill(Me.MonthlyDataSheet.AttendanceTable)
        Me.UsersTableTableAdapter.Fill(Me.DataSetInOut.UsersTable)
        Me.AttendanceTableTableAdapter.Fill(Me.DataSetInOut.AttendanceTable, DateAndTime.DateString)
        ' to go the last row in the data Grid view
        Try
            AttendanceTableDataGridView.ClearSelection()
            AttendanceTableDataGridView.Rows(AttendanceTableDataGridView.RowCount - 1).Selected = True
            AttendanceTableDataGridView.FirstDisplayedScrollingRowIndex = AttendanceTableDataGridView.RowCount - 1
        Catch ex As Exception

        End Try
        ''''''''''''''''''''''''''''''''''''''
        ServerDate = UsersTableTableAdapter.GetServerTime()
        'TodayDate = DateAndTime.Today
        ServerDate = ServerDate
        La_Date.Text = ServerDate.ToString("d")
        La_Time.Text = ServerDate.ToLongTimeString 'DateAndTime.TimeOfDay.ToString("hh:mm tt")
        FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Location = New Point(0, 0)
        Size = SystemInformation.PrimaryMonitorMaximizedWindowSize
        'TopMost = True
        WindowState = 2
        If (AxZKFPEngX1.InitEngine = 0) Then
            AxZKFPEngX1.FPEngineVersion = "9"
            Dim fpcHandle As Integer = AxZKFPEngX1.CreateFPCacheDBEx()
            StatusLabel2.Text = "Serial Number: " + AxZKFPEngX1.SensorSN() + "   /   "
            StatusLabel1.Text = "Sensor Number: " + AxZKFPEngX1.SensorCount().ToString + "  /   "
            StatusLabel3.Text = "Initial Succeed"
        Else
            AxZKFPEngX1.EndEngine()
            StatusLabel3.Text = "Initial Failed"
        End If

        'TodayDate = DateAndTime.Today
        'La_Date.Text = TodayDate.ToString("d")
        'La_Time.Text = DateAndTime.TimeOfDay.ToString("hh:mm tt")
        Dim myTime As Date = ServerDate ' Now
        'Dim s As Integer = Hour(myTime)
        If (Hour(myTime) > 11 And Hour(myTime) < 16) Then
            Bu_BreakIn.Enabled = True
            Bu_BreakOut.Enabled = True
        ElseIf (Hour(myTime) < 11 And Hour(myTime) > 16) Then
            Bu_BreakIn.Enabled = False
            Bu_BreakOut.Enabled = False
        End If
        If (Hour(myTime) = 7) Then
            Me.AttendanceTableTableAdapter.Fill(Me.DataSetInOut.AttendanceTable, DateAndTime.DateString)
        End If
        CB_Days.SelectedIndex = 0
    End Sub
    Private Sub Timer_DateCheck_Tick(sender As Object, e As EventArgs) Handles Timer_DateCheck.Tick
        'Dim ServerDate As Date = UsersTableTableAdapter.GetServerTime()
        'TodayDate = ServerDate 'DateAndTime.Today
        Try
            ServerDate = UsersTableTableAdapter.GetServerTime()
        Catch ex As Exception
            ServerDate = DateAndTime.Today
        End Try
        Dim WeekName As String = WeekdayName(Weekday(ServerDate))
        La_Date.Text = ServerDate.ToString("d") + Environment.NewLine + WeekName
        La_Time.Text = ServerDate.ToLongTimeString 'TimeOfDay.ToString '("hh:mm tt") 'DateAndTime.TimeOfDay.ToString("hh:mm tt")
        Dim myTime As Date = ServerDate 'Now
        'Dim s As Integer = Hour(myTime)
        If (Hour(myTime) > 11 And Hour(myTime) < 16) Then
            Bu_BreakIn.Enabled = True
            Bu_BreakOut.Enabled = True
        ElseIf (Hour(myTime) < 11 And Hour(myTime) > 16) Then
            Bu_BreakIn.Enabled = False
            Bu_BreakOut.Enabled = False
        End If
        If (Hour(myTime) = 7) Then
            Me.AttendanceTableTableAdapter.Fill(Me.DataSetInOut.AttendanceTable, DateAndTime.DateString)
        End If
    End Sub
    Private Sub AxZKFPEngX1_OnCapture(sender As Object, e As IZKFPEngXEvents_OnCaptureEvent) Handles AxZKFPEngX1.OnCapture
        Dim id As Integer = 0
        Dim Score As Integer = 0
        Dim ProcessNum As Integer = 0
        Dim buffer(63) As SByte
        Dim sTemp As String = String.Empty
        Dim RegChanged As Boolean = False
        StatusLabel3.ForeColor = Color.Black
        ToolStripStatusLabel3.ForeColor = Color.Black
        'Dim ServerDate As Date = UsersTableTableAdapter.GetServerTime()
        Try
            ServerDate = UsersTableTableAdapter.GetServerTime()
        Catch ex As Exception
            ServerDate = DateAndTime.Today
        End Try

        Select Case matchType
            Case 1  ' enter user
                Dim bTemp As String = String.Empty
                sTemp = AxZKFPEngX1.GetTemplateAsString()
                Dim CheckifUserReg = From num In UsersTableTableAdapter.GetData Where AxZKFPEngX1.VerFingerFromStr(num.Stamp, sTemp, False, RegChanged) Or
                                                                                    AxZKFPEngX1.VerFingerFromStr(num.Stamp1, sTemp, False, RegChanged) Or
                                                                                    AxZKFPEngX1.VerFingerFromStr(num.Stamp2, sTemp, False, RegChanged) Or
                                                                                    AxZKFPEngX1.VerFingerFromStr(num.Stamp3, sTemp, False, RegChanged)  ' stamp have't valid user
                If CheckifUserReg.Any Then ' check it user have recored at this day 
                    'Dim isUserHaveRecored = From nun In AttendanceTableTableAdapter.GetData(DateAndTime.DateString) Where nun.UserID = CheckifUserReg.First.UserID 'And nun.LogDate.ToString = La_Date.Text
                    Dim isUserHaveRecored = AttendanceTableTableAdapter.GetDataByLogDate_UserID(DateAndTime.DateString, CheckifUserReg.First.UserID)  'And nun.LogDate.ToString = La_Date.Text
                    If Not isUserHaveRecored.Any Then
                        'If (isUserHaveRecored.First.TimeIn = TimeSpan.Zero And isUserHaveRecored.First.TimeOut = TimeSpan.Zero) Then 'Or isUserHaveRecored.First.LanchIn = TimeSpan.Zero Or isUserHaveRecored.First.LanchOut = TimeSpan.Zero) Then
                        'AttendanceTableTableAdapter.Insert(CheckifUserReg.First.UserID, CheckifUserReg.First.Username, La_Date.Text, Date.Now.TimeOfDay, TimeSpan.Zero, TimeSpan.Zero, TimeSpan.Zero, CheckifUserReg.First.Section)
                        AttendanceTableTableAdapter.Insert(CheckifUserReg.First.UserID, CheckifUserReg.First.Username, ServerDate, ServerDate.TimeOfDay, TimeSpan.Zero, TimeSpan.Zero, TimeSpan.Zero, CheckifUserReg.First.Section)
                        Me.AttendanceTableTableAdapter.Fill(Me.DataSetInOut.AttendanceTable, DateAndTime.DateString)
                        ' to go the last row in the data Grid view
                        AttendanceTableDataGridView.ClearSelection()
                        AttendanceTableDataGridView.Rows(AttendanceTableDataGridView.RowCount - 1).Selected = True
                        AttendanceTableDataGridView.FirstDisplayedScrollingRowIndex = AttendanceTableDataGridView.RowCount - 1
                        ''''''''''''''''''''''''''''''''''''''
                        StatusLabel3.Text = "Verfiy Succeed-you have reg in : " & CheckifUserReg.First.Username
                        StatusLabel3.ForeColor = Color.Green
                        'End If
                    Else
                        'MsgBox("You have been reg In ,you can't enter again in same day ... or something wrong!!", MsgBoxStyle.OkOnly, "Error")
                        StatusLabel3.Text = "you can't enter again in same day,Verfiy Failed In reg in"
                        StatusLabel3.ForeColor = Color.Red
                        'End If
                    End If
                Else
                    'MsgBox("Wrong stamp or No User name for this stamp in Data base pls try again,Thanks or Connect IT Support section !!", MsgBoxStyle.OkOnly, "Error")
                    StatusLabel3.Text = "No User name in Database,Press Login again"
                    StatusLabel3.ForeColor = Color.Red
                End If
                'matchType = 0
            Case 2  ' user go out  
                Dim bTemp As String = String.Empty
                sTemp = AxZKFPEngX1.GetTemplateAsString()
                Dim CheckifUserReg = From num In UsersTableTableAdapter.GetData Where AxZKFPEngX1.VerFingerFromStr(num.Stamp, sTemp, False, RegChanged) Or
                                                                                    AxZKFPEngX1.VerFingerFromStr(num.Stamp1, sTemp, False, RegChanged) Or
                                                                                    AxZKFPEngX1.VerFingerFromStr(num.Stamp2, sTemp, False, RegChanged) Or
                                                                                    AxZKFPEngX1.VerFingerFromStr(num.Stamp3, sTemp, False, RegChanged) 'num.Stamp
                If CheckifUserReg.Any Then 'check if user in data base
                    'Dim isUserHaveRecored = From nun In AttendanceTableTableAdapter.GetData(DateAndTime.DateString) Where nun.UserID = CheckifUserReg.First.UserID 'And nun.LogDate.ToString = La_Date.Text
                    Dim isUserHaveRecored = AttendanceTableTableAdapter.GetDataByLogDate_UserID(DateAndTime.DateString, CheckifUserReg.First.UserID)  'And nun.LogDate.ToString = La_Date.Text
                    If isUserHaveRecored.Any Then ' check if user have recored at this day
                        If (isUserHaveRecored.First.TimeOut = TimeSpan.Zero And isUserHaveRecored.First.TimeIn <> TimeSpan.Zero) Then ' this mean he go out and stamp
                            StatusLabel3.Text = "Verfiy Succeed-you have reg out : " & isUserHaveRecored.First.Username
                            StatusLabel3.ForeColor = Color.Green
                            'AttendanceTableTableAdapter.Update_TimeOut_LogID(Date.Now.TimeOfDay.ToString, isUserHaveRecored.First.LogID)
                            AttendanceTableTableAdapter.Update_TimeOut_LogID(ServerDate.TimeOfDay.ToString, isUserHaveRecored.First.LogID)
                            Me.AttendanceTableTableAdapter.Fill(Me.DataSetInOut.AttendanceTable, DateAndTime.DateString)
                            ' to go the last row in the data Grid view
                            Dim rowindex As Integer = DataGridRowValueFind(AttendanceTableDataGridView, isUserHaveRecored.First.UserID)
                            AttendanceTableDataGridView.ClearSelection()
                            AttendanceTableDataGridView.Rows(rowindex).Selected = True
                            AttendanceTableDataGridView.FirstDisplayedScrollingRowIndex = rowindex
                            ''''''''''''''''''''''''''''''''''''''
                        Else
                            'MsgBox("You have been reg out or not Log in ,you can't out again in same day", MsgBoxStyle.OkOnly, "Error")
                            StatusLabel3.Text = "you can't out again in same day,Failed reg out"
                            StatusLabel3.ForeColor = Color.Red
                        End If
                    Else
                        'MsgBox("You have been reg out or not Log in ,you can't out again in same day", MsgBoxStyle.OkOnly, "Error")
                        StatusLabel3.Text = "Verfiy Faile reg out"
                        StatusLabel3.ForeColor = Color.Red
                    End If
                Else
                    'MsgBox("Wrong stamp or No User name for this stamp in Data base pls try again,Thanks or Connect IT Support section !!", MsgBoxStyle.OkOnly, "Error")
                    StatusLabel3.Text = "No User name in Database,Press LogOut again"
                    StatusLabel3.ForeColor = Color.Red
                End If
                'matchType = 0
            Case 3  ' go to Lansh out
                Dim bTemp As String = String.Empty
                sTemp = AxZKFPEngX1.GetTemplateAsString()
                Dim CheckifUserReg = From num In UsersTableTableAdapter.GetData Where AxZKFPEngX1.VerFingerFromStr(num.Stamp, sTemp, False, RegChanged) Or
                                                                                    AxZKFPEngX1.VerFingerFromStr(num.Stamp1, sTemp, False, RegChanged) Or
                                                                                    AxZKFPEngX1.VerFingerFromStr(num.Stamp2, sTemp, False, RegChanged) Or
                                                                                    AxZKFPEngX1.VerFingerFromStr(num.Stamp3, sTemp, False, RegChanged) 'num.Stamp
                If CheckifUserReg.Any Then 'check if user in data base  'If CheckifUserReg.Count > 0 Then 'check if user in data base
                    'Dim isUserHaveRecored = (From nun In AttendanceTableTableAdapter.GetData(DateAndTime.DateString) Where nun.UserID = CheckifUserReg.First.UserID).ToList 'And nun.LogDate.ToString = La_Date.Text
                    Dim isUserHaveRecored = AttendanceTableTableAdapter.GetDataByLogDate_UserID(DateAndTime.DateString, CheckifUserReg.First.UserID)  'And nun.LogDate.ToString = La_Date.Text
                    If isUserHaveRecored.Any Then ' check if user have recored at this day
                        If (isUserHaveRecored.First.LanchOut = TimeSpan.Zero And isUserHaveRecored.First.LanchIn = TimeSpan.Zero) Then ' this mean he go out and stamp
                            StatusLabel3.Text = "Verfiy Succeed-you have reg Lansh out : " & isUserHaveRecored.First.Username
                            StatusLabel3.ForeColor = Color.Green
                            'AttendanceTableTableAdapter.Update_LanchOut_LogID(Date.Now.TimeOfDay.ToString, isUserHaveRecored.First.LogID)
                            AttendanceTableTableAdapter.Update_LanchOut_LogID(ServerDate.TimeOfDay.ToString, isUserHaveRecored.First.LogID)
                            Me.AttendanceTableTableAdapter.Fill(Me.DataSetInOut.AttendanceTable, DateAndTime.DateString)
                            ' to go the last row in the data Grid view
                            Dim rowindex As Integer = DataGridRowValueFind(AttendanceTableDataGridView, isUserHaveRecored.First.UserID)
                            AttendanceTableDataGridView.ClearSelection()
                            AttendanceTableDataGridView.Rows(rowindex).Selected = True
                            AttendanceTableDataGridView.FirstDisplayedScrollingRowIndex = rowindex
                            ''''''''''''''''''''''''''''''''''''''
                        Else
                            'MsgBox("You have been reg Lansh out or not Log in ,you can't out again in same day", MsgBoxStyle.OkOnly, "Error")
                            StatusLabel3.Text = "you can't out again in same day,Failed reg Break out"
                            StatusLabel3.ForeColor = Color.Red
                        End If
                    Else
                        'MsgBox("You have been reg out or not Log in ,you can't out again in same day", MsgBoxStyle.OkOnly, "Error")
                        StatusLabel3.Text = "Verfiy Failed reg Break out"
                        StatusLabel3.ForeColor = Color.Red
                    End If
                Else
                    'MsgBox("Wrong stamp or No User name for this stamp in Data base pls try again,Thanks or Connect IT Support section !!", MsgBoxStyle.OkOnly, "Error")
                    StatusLabel3.Text = "No User name in Database,Press BreakOut again"
                    StatusLabel3.ForeColor = Color.Red
                End If
                'matchType = 0
            Case 4  ' back form lansh (in)
                Dim bTemp As String = String.Empty
                sTemp = AxZKFPEngX1.GetTemplateAsString()
                Dim CheckifUserReg = From num In UsersTableTableAdapter.GetData Where AxZKFPEngX1.VerFingerFromStr(num.Stamp, sTemp, False, RegChanged) Or
                                                                                    AxZKFPEngX1.VerFingerFromStr(num.Stamp1, sTemp, False, RegChanged) Or
                                                                                    AxZKFPEngX1.VerFingerFromStr(num.Stamp2, sTemp, False, RegChanged) Or
                                                                                    AxZKFPEngX1.VerFingerFromStr(num.Stamp3, sTemp, False, RegChanged) 'num.Stamp
                If CheckifUserReg.Any Then 'check if user in data base
                    'Dim isUserHaveRecored = From nun In AttendanceTableTableAdapter.GetData(DateAndTime.DateString) Where nun.UserID = CheckifUserReg.First.UserID 'And nun.LogDate.ToString = La_Date.Text
                    Dim isUserHaveRecored = AttendanceTableTableAdapter.GetDataByLogDate_UserID(DateAndTime.DateString, CheckifUserReg.First.UserID)  'And nun.LogDate.ToString = La_Date.Text
                    If isUserHaveRecored.Any Then ' check if user have recored at this day
                        If (isUserHaveRecored.First.LanchIn = TimeSpan.Zero And isUserHaveRecored.First.LanchOut <> TimeSpan.Zero) Then ' this mean he go out and stamp
                            StatusLabel3.Text = "Verfiy Succeed-you have reg Lansh In : " & isUserHaveRecored.First.Username
                            StatusLabel3.ForeColor = Color.Green
                            'AttendanceTableTableAdapter.Update_LanchIn_LogID(Date.Now.TimeOfDay.ToString, isUserHaveRecored.First.LogID)
                            AttendanceTableTableAdapter.Update_LanchIn_LogID(ServerDate.TimeOfDay.ToString(), isUserHaveRecored.First.LogID)
                            Me.AttendanceTableTableAdapter.Fill(Me.DataSetInOut.AttendanceTable, DateAndTime.DateString)
                            ' to go the last row in the data Grid view
                            Dim rowindex As Integer = DataGridRowValueFind(AttendanceTableDataGridView, isUserHaveRecored.First.UserID)
                            AttendanceTableDataGridView.ClearSelection()
                            AttendanceTableDataGridView.Rows(rowindex).Selected = True
                            AttendanceTableDataGridView.FirstDisplayedScrollingRowIndex = rowindex
                            ''''''''''''''''''''''''''''''''''''''
                        Else
                            'MsgBox("You have been reg Lansh in or not Log in ,you can't out again in same day", MsgBoxStyle.OkOnly, "Error")
                            StatusLabel3.Text = "you can't BreakIN again in same day, Failed reg Break In"
                            StatusLabel3.ForeColor = Color.Red
                        End If
                    Else
                        'MsgBox("You have been reg out or not Log in ,you can't out again in same day", MsgBoxStyle.OkOnly, "Error")
                        StatusLabel3.Text = "Verfiy Failed reg Break In"
                        StatusLabel3.ForeColor = Color.Red
                    End If
                Else
                    'MsgBox("Wrong stamp or No User name for this stamp in Data base pls try again,Thanks or Connect IT Support section !!", MsgBoxStyle.OkOnly, "Error")
                    StatusLabel3.Text = "No User name in Database,Press Break In again"
                    StatusLabel3.ForeColor = Color.Red
                End If
                'matchType = 0
            Case 5
                Dim bTemp As String = String.Empty
                sTemp = AxZKFPEngX1.GetTemplateAsString()
                Dim CheckifUserReg = From num In UsersTableTableAdapter.GetData Where AxZKFPEngX1.VerFingerFromStr(num.Stamp, sTemp, False, RegChanged) Or
                                                                                    AxZKFPEngX1.VerFingerFromStr(num.Stamp1, sTemp, False, RegChanged) Or
                                                                                    AxZKFPEngX1.VerFingerFromStr(num.Stamp2, sTemp, False, RegChanged) Or
                                                                                    AxZKFPEngX1.VerFingerFromStr(num.Stamp3, sTemp, False, RegChanged) 'num.Stamp
                If CheckifUserReg.Any Then 'check if user in data base
                    If (CheckifUserReg.First.UserLevel = "Admin" And CB_Days.Text <> 0) Then
                        Dim monthIndex As Integer = LB_Month.SelectedIndex + 1
                        Dim yearIndex As Integer = LB_Year.SelectedItem.ToString
                        Dim dayindex As Integer = CB_Days.Text
                        Me.AttendanceTableTableAdapter1.FillByYear_Month_day(Me.MonthlyDataSheet.AttendanceTable, yearIndex, monthIndex, dayindex)
                        CB_Days.SelectedIndex = 0
                    Else
                        Dim monthIndex As Integer = LB_Month.SelectedIndex + 1
                        Dim yearIndex As Integer = LB_Year.SelectedItem.ToString
                        Me.AttendanceTableTableAdapter1.FillByLogDate_UserId(Me.MonthlyDataSheet.AttendanceTable, yearIndex, monthIndex, CheckifUserReg.First.UserID)
                        tempUserName = CheckifUserReg.First.Username
                        ToolStripStatusLabel3.ForeColor = Color.Green
                        ToolStripStatusLabel3.Text = "Verfiy Succeed you can Print"
                        ToolStripStatusLabel3.ForeColor = Color.Green
                    End If

                Else
                    'MsgBox("Wrong stamp or No User name for this stamp in Data base pls try again,Thanks or Connect IT Support section !!", MsgBoxStyle.OkOnly, "Error")
                    ToolStripStatusLabel3.Text = "No User name in Database pls try again"
                    ToolStripStatusLabel3.ForeColor = Color.Red
                End If
                matchType = 0
            Case 6
                Dim bTemp As String = String.Empty
                sTemp = AxZKFPEngX1.GetTemplateAsString()
                Dim CheckifUserReg = From num In UsersTableTableAdapter.GetData Where AxZKFPEngX1.VerFingerFromStr(num.Stamp, sTemp, False, RegChanged) Or
                                                                                    AxZKFPEngX1.VerFingerFromStr(num.Stamp1, sTemp, False, RegChanged) Or
                                                                                    AxZKFPEngX1.VerFingerFromStr(num.Stamp2, sTemp, False, RegChanged) Or
                                                                                    AxZKFPEngX1.VerFingerFromStr(num.Stamp3, sTemp, False, RegChanged) 'num.Stamp
                If CheckifUserReg.Any Then 'check if user in data base
                    If CheckifUserReg.First.UserLevel = "Admin" Then
                        Bu_AdminPrint.Enabled = True
                        Bu_PrintExcel.Enabled = True
                        ToolStripStatusLabel3.ForeColor = Color.Green
                        StatusLabel3.Text = "Verfiy Succeed you can Print"
                        StatusLabel3.ForeColor = Color.Green
                    End If
                Else
                    'MsgBox("Wrong stamp or No User name for this stamp in Data base pls try again,Thanks or Connect IT Support section !!", MsgBoxStyle.OkOnly, "Error")
                    StatusLabel3.Text = "No User name in Database pls try again"
                    StatusLabel3.ForeColor = Color.Red
                End If
                matchType = 0
        End Select

    End Sub
    Private Sub AttendanceTableBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs) Handles AttendanceTableBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.AttendanceTableBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.DataSetInOut)

    End Sub

    Private Sub Bu_In_Click(sender As Object, e As EventArgs) Handles Bu_In.Click
        StatusLabel3.ForeColor = Color.Black
        Bu_In.BackColor = Color.Green
        Bu_Out.BackColor = Color.FromArgb(255)
        Bu_BreakOut.BackColor = Color.FromArgb(255)
        Bu_BreakIn.BackColor = Color.FromArgb(255)
        ToolStripStatusLabel3.ForeColor = Color.Black
        If (AxZKFPEngX1.IsRegister()) Then
            AxZKFPEngX1.CancelEnroll()
        End If
        StatusLabel3.Text = "Verify In"
        matchType = 1
    End Sub

    Private Sub In_Out_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        AxZKFPEngX1.EndEngine()
    End Sub
    Private Sub AxZKFPEngX1_OnImageReceived(sender As Object, e As IZKFPEngXEvents_OnImageReceivedEvent) Handles AxZKFPEngX1.OnImageReceived
        Dim HDC As Long = PB_Stamp.CreateGraphics.GetHdc.ToInt32
        If (e.aImageValid) Then
            AxZKFPEngX1.PrintImageAt(HDC, 0, 0, AxZKFPEngX1.ImageWidth / 2.5, AxZKFPEngX1.ImageHeight / 2.5)
        End If
    End Sub

    Private Sub Bu_Out_Click(sender As Object, e As EventArgs) Handles Bu_Out.Click
        StatusLabel3.ForeColor = Color.Black
        Bu_In.BackColor = Color.FromArgb(255)
        Bu_Out.BackColor = Color.Green
        Bu_BreakOut.BackColor = Color.FromArgb(255)
        Bu_BreakIn.BackColor = Color.FromArgb(255)
        ToolStripStatusLabel3.ForeColor = Color.Black
        If (AxZKFPEngX1.IsRegister()) Then
            AxZKFPEngX1.CancelEnroll()
        End If
        StatusLabel3.Text = "Verify Out"
        matchType = 2
    End Sub

    Private Sub Bu_BreakOut_Click(sender As Object, e As EventArgs) Handles Bu_BreakOut.Click
        StatusLabel3.ForeColor = Color.Black
        Bu_In.BackColor = Color.FromArgb(255)
        Bu_Out.BackColor = Color.FromArgb(255)
        Bu_BreakOut.BackColor = Color.Green
        Bu_BreakIn.BackColor = Color.FromArgb(255)
        ToolStripStatusLabel3.ForeColor = Color.Black
        If (AxZKFPEngX1.IsRegister()) Then
            AxZKFPEngX1.CancelEnroll()
        End If
        StatusLabel3.Text = "Verify Lansh Out"
        matchType = 3
    End Sub

    Private Sub Bu_BreakIn_Click(sender As Object, e As EventArgs) Handles Bu_BreakIn.Click
        StatusLabel3.ForeColor = Color.Black
        Bu_In.BackColor = Color.FromArgb(255)
        Bu_Out.BackColor = Color.FromArgb(255)
        Bu_BreakOut.BackColor = Color.FromArgb(255)
        Bu_BreakIn.BackColor = Color.Green
        ToolStripStatusLabel3.ForeColor = Color.Black
        If (AxZKFPEngX1.IsRegister()) Then
            AxZKFPEngX1.CancelEnroll()
        End If
        StatusLabel3.Text = "Verify Lansh In"
        matchType = 4
    End Sub

    Private Sub Bu_CheckMonth_Click(sender As Object, e As EventArgs) Handles Bu_CheckMonth.Click
        StatusLabel3.ForeColor = Color.Black
        Bu_In.BackColor = Color.FromArgb(255)
        Bu_Out.BackColor = Color.FromArgb(255)
        Bu_BreakOut.BackColor = Color.FromArgb(255)
        Bu_BreakIn.BackColor = Color.FromArgb(255)
        ToolStripStatusLabel3.ForeColor = Color.Black
        If (LB_Month.SelectedIndex >= 0 And LB_Year.SelectedIndex >= 0) Then
            If (AxZKFPEngX1.IsRegister()) Then
                AxZKFPEngX1.CancelEnroll()
            End If
            ToolStripStatusLabel3.Text = "Verify Stamp"
            'ToolStripStatusLabel3.ForeColor = Color.Green
            matchType = 5
            Bu_PrintUser.Enabled = True
            Bu_ExcelUser.Enabled = True
        Else
            'MsgBox("pls chose month and Year to show ", MsgBoxStyle.OkOnly, "Error")
            ToolStripStatusLabel3.Text = "pls chose month and Year to show"
            ToolStripStatusLabel3.ForeColor = Color.Red
        End If
    End Sub

    Private Sub Bu_AdminPrint_Click(sender As Object, e As EventArgs) Handles Bu_AdminPrint.Click
        Dim s As Boolean = DataGridResize(AttendanceTableDataGridView)
        StatusLabel3.ForeColor = Color.Black
        ToolStripStatusLabel3.ForeColor = Color.Black
        ToolStripStatusLabel3.Text = "Please wait we are process ur file"
        If s Then
            'Dim doc As New GridPrintDocument(Me.AttendanceTableDataGridView1, Me.AttendanceTableDataGridView1.Font, True)
            Dim doc As New GridPrintDocument(Me.DataGridViewSized, Me.DataGridViewSized.Font, True)
            doc.DocumentName = "Preview Test"
            Dim printPreviewDialog As New PrintPreviewDialog()
            printPreviewDialog.ClientSize = New Size(600, 800)
            printPreviewDialog.Location = New Point(2, 2)
            printPreviewDialog.Name = "Print Preview Dialog"
            printPreviewDialog.UseAntiAlias = True
            printPreviewDialog.Document = doc
            doc.DrawCellBox = True
            doc.DefaultPageSettings.Landscape = True
            doc.ScaleFactor = 0.5 'scale
            'doc.DefaultPageSettings.PaperSize = New PaperSize("A4", 627, 969)  ' 8.27, 11.69)m_PageSize = {X = 100 Y = 100 Width = 627 Height = 969}
            doc.DefaultPageSettings.Margins = New Margins(5, 5, 5, 5)
            printPreviewDialog.Document = doc
            printPreviewDialog.ShowDialog()

            doc.Dispose()
            doc = Nothing
            Me.AttendanceTableTableAdapter.Fill(Me.DataSetInOut.AttendanceTable, DateAndTime.DateString)
            ' to go the last row in the data Grid view
            AttendanceTableDataGridView.ClearSelection()
            AttendanceTableDataGridView.Rows(AttendanceTableDataGridView.RowCount - 1).Selected = True
            AttendanceTableDataGridView.FirstDisplayedScrollingRowIndex = AttendanceTableDataGridView.RowCount - 1

            ''''''''''''''''''''''''''''''''''''''
            ToolStripStatusLabel3.Text = "file Has Created Will"
        Else
            'MsgBox("Something Error", MsgBoxStyle.OkOnly, "Error")
            ToolStripStatusLabel3.Text = "Something Error"
        End If
        releaseObject(DataGridViewSized)
        Bu_AdminPrint.Enabled = False
        Bu_PrintExcel.Enabled = False
    End Sub

    Private Sub Bu_AccessPrint_Click(sender As Object, e As EventArgs) Handles Bu_AccessPrint.Click
        StatusLabel3.ForeColor = Color.Black
        ToolStripStatusLabel3.ForeColor = Color.Black
        Bu_In.BackColor = Color.FromArgb(255)
        Bu_Out.BackColor = Color.FromArgb(255)
        Bu_BreakOut.BackColor = Color.FromArgb(255)
        Bu_BreakIn.BackColor = Color.FromArgb(255)
        'AttendanceTableDataGridView.ClearSelection()
        AttendanceTableDataGridView.Rows(AttendanceTableDataGridView.RowCount - 1).Selected = True
        AttendanceTableDataGridView.FirstDisplayedScrollingRowIndex = AttendanceTableDataGridView.RowCount - 1
        If (AxZKFPEngX1.IsRegister()) Then
            AxZKFPEngX1.CancelEnroll()
        End If
        StatusLabel3.Text = "Verify Admin Print"
        matchType = 6
    End Sub

    Private Sub Bu_PrintUser_Click(sender As Object, e As EventArgs) Handles Bu_PrintUser.Click
        StatusLabel3.ForeColor = Color.Black
        ToolStripStatusLabel3.ForeColor = Color.Black
        Dim s As Boolean = DataGridResize(AttendanceTableDataGridView1)
        If s Then
            'Dim doc As New GridPrintDocument(Me.AttendanceTableDataGridView1, Me.AttendanceTableDataGridView1.Font, True)
            Dim doc As New GridPrintDocument(Me.DataGridViewSized, Me.DataGridViewSized.Font, True)
            doc.DocumentName = "Preview Test"
            Dim printPreviewDialog As New PrintPreviewDialog()
            printPreviewDialog.ClientSize = New Size(600, 800)
            printPreviewDialog.Location = New Point(2, 2)
            printPreviewDialog.Name = "Print Preview Dialog"
            printPreviewDialog.UseAntiAlias = True
            printPreviewDialog.Document = doc
            doc.DrawCellBox = True
            doc.DefaultPageSettings.Landscape = True
            doc.ScaleFactor = 0.6 'scale
            'doc.DefaultPageSettings.PaperSize = New PaperSize("A4", 627, 969)  ' 8.27, 11.69)m_PageSize = {X = 100 Y = 100 Width = 627 Height = 969}
            doc.DefaultPageSettings.Margins = New Margins(5, 5, 5, 5)
            printPreviewDialog.Document = doc
            'printPreviewDialog.ShowDialog()

            Try
                printPreviewDialog.ShowDialog()

            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
            doc.Dispose()
            doc = Nothing
            Me.AttendanceTableTableAdapter.Fill(Me.DataSetInOut.AttendanceTable, DateAndTime.DateString)
            ' to go the last row in the data Grid view
            AttendanceTableDataGridView.ClearSelection()
            AttendanceTableDataGridView.Rows(AttendanceTableDataGridView.RowCount - 1).Selected = True
            AttendanceTableDataGridView.FirstDisplayedScrollingRowIndex = AttendanceTableDataGridView.RowCount - 1
            ''''''''''''''''''''''''''''''''''''''
        Else
            MsgBox("Something Error", MsgBoxStyle.OkOnly, "Error")
        End If
        Bu_PrintUser.Enabled = False
        Bu_ExcelUser.Enabled = False
    End Sub

    Private Sub Bu_PrintExcel_Click(sender As Object, e As EventArgs) Handles Bu_PrintExcel.Click
        StatusLabel3.ForeColor = Color.Black
        ToolStripStatusLabel3.ForeColor = Color.Black
        ToolStripStatusLabel3.Text = "Please wait we are process ur file"
        Application.DoEvents()
        Dim xlApp As Microsoft.Office.Interop.Excel.Application = New Microsoft.Office.Interop.Excel.Application
        Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook
        Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet
        Dim misValue As Object = System.Reflection.Missing.Value
        xlWorkBook = xlApp.Workbooks.Add(misValue)
        xlWorkSheet = xlWorkBook.Sheets("Sheet1")
        For i = 0 To AttendanceTableDataGridView.RowCount - 1
            For j = 2 To AttendanceTableDataGridView.ColumnCount - 1 'For j = 0 To AttendanceTableDataGridView.ColumnCount - 1
                For k = 3 To AttendanceTableDataGridView.Columns.Count 'For k = 1 To AttendanceTableDataGridView.Columns.Count
                    xlWorkSheet.Cells(1, k) = AttendanceTableDataGridView.Columns(k - 1).HeaderText
                    xlWorkSheet.Cells(i + 2, j + 1) = AttendanceTableDataGridView(j, i).Value.ToString
                Next
            Next
        Next
        Try
            xlWorkSheet.SaveAs("\\192.168.0.23\Archive\DataSheet\ " + DateAndTime.Now.Month.ToString + "-" + DateAndTime.Now.Year.ToString + "xlsx")
            xlWorkBook.Close()
            xlApp.Quit()
            releaseObject(xlApp)
            releaseObject(xlWorkBook)
            releaseObject(xlWorkSheet)
            'MsgBox("File have been Created at DataSheet Folder on the Server", MsgBoxStyle.OkOnly, "Done")
            StatusLabel3.Text = "File Created at DataSheet Folder\Server23\Archive"
            StatusLabel3.ForeColor = Color.Green
        Catch ex As Exception
            xlWorkBook.Close()
            xlApp.Quit()
            releaseObject(xlApp)
            releaseObject(xlWorkBook)
            releaseObject(xlWorkSheet)
            'MsgBox(ex.ToString, MsgBoxStyle.OkOnly, "Error")
            StatusLabel3.Text = ex.ToString
            StatusLabel3.ForeColor = Color.Red
        End Try
        Bu_AdminPrint.Enabled = False
        Bu_PrintExcel.Enabled = False
    End Sub
    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Private Sub Bu_ExcelUser_Click(sender As Object, e As EventArgs) Handles Bu_ExcelUser.Click
        StatusLabel3.ForeColor = Color.Black
        ToolStripStatusLabel3.ForeColor = Color.Black
        'Dim xlApp As Microsoft.Office.Interop.Excel.Application = New Microsoft.Office.Interop.Excel.Application
        'Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook
        'Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet
        'Dim misValue As Object = System.Reflection.Missing.Value
        'xlWorkBook = xlApp.Workbooks.Add(misValue)
        'xlWorkSheet = xlWorkBook.Sheets("Sheet1")
        'For i = 0 To AttendanceTableDataGridView1.RowCount - 1
        '    For j = 2 To AttendanceTableDataGridView1.ColumnCount - 1
        '        For k = 3 To AttendanceTableDataGridView1.Columns.Count
        '            xlWorkSheet.Cells(1, k) = AttendanceTableDataGridView1.Columns(k - 1).HeaderText
        '            xlWorkSheet.Cells(i + 2, j + 1) = AttendanceTableDataGridView1(j, i).Value.ToString
        '        Next
        '    Next
        'Next
        Dim xlApp As Microsoft.Office.Interop.Excel.Application = New Microsoft.Office.Interop.Excel.Application
        Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook
        Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet
        Dim misValue As Object = System.Reflection.Missing.Value
        xlWorkBook = xlApp.Workbooks.Add(misValue)
        xlWorkSheet = xlWorkBook.Sheets("Sheet1")
        'If UserPrint Then xlWorkBook.Sheets("Sheet1").Name = UsernameComboBox.Text + DateAndTime.DateString : UserPrint = False
        Dim formatRangeDate, formatRangeTime As Microsoft.Office.Interop.Excel.Range
        formatRangeDate = xlWorkSheet.Range("b:b")
        formatRangeDate.NumberFormat = "mm/dd/yyyy"
        formatRangeTime = xlWorkSheet.Range("c:f")
        formatRangeTime.NumberFormat = "hh:mm:ss"
        For i = 0 To AttendanceTableDataGridView1.RowCount - 1
            For j = 2 To AttendanceTableDataGridView1.ColumnCount - 1
                For k = 3 To AttendanceTableDataGridView1.Columns.Count
                    xlWorkSheet.Cells(1, k - 2) = AttendanceTableDataGridView1.Columns(k - 1).HeaderText
                    xlWorkSheet.Cells(i + 2, j - 1) = AttendanceTableDataGridView1(j, i).Value.ToString
                Next
            Next
        Next
        Try
            xlWorkSheet.SaveAs("\\192.168.0.23\Archive\DataSheet\" + tempUserName + "-" + DateAndTime.Now.Month.ToString + "-" + DateAndTime.Now.Year.ToString + "xlsx")
            xlWorkBook.Close()
            xlApp.Quit()
            releaseObject(xlApp)
            releaseObject(xlWorkBook)
            releaseObject(xlWorkSheet)
            'MsgBox("File have been Created at DataSheet Folder on the Server", MsgBoxStyle.OkOnly, "Done")
            ToolStripStatusLabel3.Text = "File Created at DataSheet Folder\Server23\Archive\DataSheet"
            ToolStripStatusLabel3.ForeColor = Color.Green
        Catch ex As Exception
            xlWorkBook.Close()
            xlApp.Quit()
            releaseObject(xlApp)
            releaseObject(xlWorkBook)
            releaseObject(xlWorkSheet)
            'MsgBox(ex.ToString, MsgBoxStyle.OkOnly, "Error")
            ToolStripStatusLabel3.Text = ex.ToString
            ToolStripStatusLabel3.ForeColor = Color.Red
        End Try
        tempUserName = ""
        Bu_PrintUser.Enabled = False
        Bu_ExcelUser.Enabled = False
    End Sub

    Function DataGridResize(ByVal datagridviewx As DataGridView) As Boolean
        Dim DataGridViewTemp As DataGridView
        If DataGridViewTemp Is Nothing Then
            DataGridViewTemp = datagridviewx
            DataGridViewTemp.Columns.RemoveAt(0)
            DataGridViewTemp.Columns.RemoveAt(2)
            DataGridViewSized = DataGridViewTemp
        Else
            DataGridViewTemp = datagridviewx
            DataGridViewTemp.Columns.RemoveAt(0)
            DataGridViewTemp.Columns.RemoveAt(2)
            DataGridViewSized = DataGridViewTemp
            Return True
        End If
        Return True
    End Function
    Private Function DataGridRowValueFind(ByVal urDataGridView As DataGridView, ByVal Value As Integer) As Integer
        For i = 0 To urDataGridView.RowCount - 1
            If CInt(urDataGridView.Item(1, i).Value) = Value Then
                Return i
                Exit For
            End If
        Next
        Return 0
    End Function
End Class