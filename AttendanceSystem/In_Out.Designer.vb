﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class In_Out
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(In_Out))
        Me.Timer_DateCheck = New System.Windows.Forms.Timer(Me.components)
        Me.AxZKFPEngX1 = New AxZKFPEngXControl.AxZKFPEngX()
        Me.DataSetInOut = New AttendanceSystem.DataSetInOut()
        Me.AttendanceTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.AttendanceTableTableAdapter = New AttendanceSystem.DataSetInOutTableAdapters.AttendanceTableTableAdapter()
        Me.TableAdapterManager = New AttendanceSystem.DataSetInOutTableAdapters.TableAdapterManager()
        Me.AttendanceTableBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.AttendanceTableBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton()
        Me.UsersTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.UsersTableTableAdapter = New AttendanceSystem.DataSetInOutTableAdapters.UsersTableTableAdapter()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.PB_Stamp = New System.Windows.Forms.PictureBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.StatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Bu_BreakOut = New System.Windows.Forms.Button()
        Me.Bu_BreakIn = New System.Windows.Forms.Button()
        Me.Bu_Out = New System.Windows.Forms.Button()
        Me.Bu_In = New System.Windows.Forms.Button()
        Me.AttendanceTableDataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.La_Time = New System.Windows.Forms.Label()
        Me.La_Date = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        CType(Me.AxZKFPEngX1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSetInOut, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AttendanceTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AttendanceTableBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.AttendanceTableBindingNavigator.SuspendLayout()
        CType(Me.UsersTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.PB_Stamp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.AttendanceTableDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer_DateCheck
        '
        Me.Timer_DateCheck.Enabled = True
        Me.Timer_DateCheck.Interval = 60000
        '
        'AxZKFPEngX1
        '
        Me.AxZKFPEngX1.Enabled = True
        Me.AxZKFPEngX1.Location = New System.Drawing.Point(1209, 445)
        Me.AxZKFPEngX1.Name = "AxZKFPEngX1"
        Me.AxZKFPEngX1.OcxState = CType(resources.GetObject("AxZKFPEngX1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxZKFPEngX1.Size = New System.Drawing.Size(24, 24)
        Me.AxZKFPEngX1.TabIndex = 3
        '
        'DataSetInOut
        '
        Me.DataSetInOut.DataSetName = "DataSetInOut"
        Me.DataSetInOut.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'AttendanceTableBindingSource
        '
        Me.AttendanceTableBindingSource.DataMember = "AttendanceTable"
        Me.AttendanceTableBindingSource.DataSource = Me.DataSetInOut
        '
        'AttendanceTableTableAdapter
        '
        Me.AttendanceTableTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.AttendanceTableTableAdapter = Me.AttendanceTableTableAdapter
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.UpdateOrder = AttendanceSystem.DataSetInOutTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        Me.TableAdapterManager.UsersTableTableAdapter = Nothing
        '
        'AttendanceTableBindingNavigator
        '
        Me.AttendanceTableBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.AttendanceTableBindingNavigator.BindingSource = Me.AttendanceTableBindingSource
        Me.AttendanceTableBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.AttendanceTableBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.AttendanceTableBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.AttendanceTableBindingNavigatorSaveItem})
        Me.AttendanceTableBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.AttendanceTableBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.AttendanceTableBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.AttendanceTableBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.AttendanceTableBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.AttendanceTableBindingNavigator.Name = "AttendanceTableBindingNavigator"
        Me.AttendanceTableBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.AttendanceTableBindingNavigator.Size = New System.Drawing.Size(1240, 25)
        Me.AttendanceTableBindingNavigator.TabIndex = 4
        Me.AttendanceTableBindingNavigator.Text = "BindingNavigator1"
        Me.AttendanceTableBindingNavigator.Visible = False
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorAddNewItem.Text = "Add new"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(35, 22)
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorDeleteItem.Text = "Delete"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 23)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem.Text = "Move last"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'AttendanceTableBindingNavigatorSaveItem
        '
        Me.AttendanceTableBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.AttendanceTableBindingNavigatorSaveItem.Image = CType(resources.GetObject("AttendanceTableBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.AttendanceTableBindingNavigatorSaveItem.Name = "AttendanceTableBindingNavigatorSaveItem"
        Me.AttendanceTableBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 22)
        Me.AttendanceTableBindingNavigatorSaveItem.Text = "Save Data"
        '
        'UsersTableBindingSource
        '
        Me.UsersTableBindingSource.DataMember = "UsersTable"
        Me.UsersTableBindingSource.DataSource = Me.DataSetInOut
        '
        'UsersTableTableAdapter
        '
        Me.UsersTableTableAdapter.ClearBeforeFill = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1289, 820)
        Me.TabControl1.TabIndex = 9
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.SteelBlue
        Me.TabPage1.Controls.Add(Me.PB_Stamp)
        Me.TabPage1.Controls.Add(Me.StatusStrip1)
        Me.TabPage1.Controls.Add(Me.Bu_BreakOut)
        Me.TabPage1.Controls.Add(Me.Bu_BreakIn)
        Me.TabPage1.Controls.Add(Me.Bu_Out)
        Me.TabPage1.Controls.Add(Me.Bu_In)
        Me.TabPage1.Controls.Add(Me.AttendanceTableDataGridView)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 28)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1281, 788)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TabPage1"
        '
        'PB_Stamp
        '
        Me.PB_Stamp.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PB_Stamp.Location = New System.Drawing.Point(387, 648)
        Me.PB_Stamp.Name = "PB_Stamp"
        Me.PB_Stamp.Size = New System.Drawing.Size(156, 108)
        Me.PB_Stamp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PB_Stamp.TabIndex = 16
        Me.PB_Stamp.TabStop = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.White
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StatusLabel1, Me.StatusLabel2, Me.StatusLabel3})
        Me.StatusStrip1.Location = New System.Drawing.Point(3, 763)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1275, 22)
        Me.StatusStrip1.TabIndex = 15
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'StatusLabel1
        '
        Me.StatusLabel1.Name = "StatusLabel1"
        Me.StatusLabel1.Size = New System.Drawing.Size(49, 17)
        Me.StatusLabel1.Text = "!!!!!!!!!!!!!!"
        '
        'StatusLabel2
        '
        Me.StatusLabel2.Name = "StatusLabel2"
        Me.StatusLabel2.Size = New System.Drawing.Size(49, 17)
        Me.StatusLabel2.Text = "!!!!!!!!!!!!!!"
        '
        'StatusLabel3
        '
        Me.StatusLabel3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusLabel3.Name = "StatusLabel3"
        Me.StatusLabel3.Size = New System.Drawing.Size(64, 17)
        Me.StatusLabel3.Text = "!!!!!!!!!!!!!!"
        '
        'Bu_BreakOut
        '
        Me.Bu_BreakOut.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Bu_BreakOut.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Bu_BreakOut.Location = New System.Drawing.Point(741, 644)
        Me.Bu_BreakOut.Name = "Bu_BreakOut"
        Me.Bu_BreakOut.Size = New System.Drawing.Size(183, 113)
        Me.Bu_BreakOut.TabIndex = 14
        Me.Bu_BreakOut.Text = "BreakOut"
        Me.Bu_BreakOut.UseVisualStyleBackColor = True
        '
        'Bu_BreakIn
        '
        Me.Bu_BreakIn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Bu_BreakIn.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Bu_BreakIn.Location = New System.Drawing.Point(552, 644)
        Me.Bu_BreakIn.Name = "Bu_BreakIn"
        Me.Bu_BreakIn.Size = New System.Drawing.Size(183, 113)
        Me.Bu_BreakIn.TabIndex = 13
        Me.Bu_BreakIn.Text = "BreakIn"
        Me.Bu_BreakIn.UseVisualStyleBackColor = True
        '
        'Bu_Out
        '
        Me.Bu_Out.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Bu_Out.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Bu_Out.Location = New System.Drawing.Point(197, 644)
        Me.Bu_Out.Name = "Bu_Out"
        Me.Bu_Out.Size = New System.Drawing.Size(183, 113)
        Me.Bu_Out.TabIndex = 12
        Me.Bu_Out.Text = "Log_Out"
        Me.Bu_Out.UseVisualStyleBackColor = True
        '
        'Bu_In
        '
        Me.Bu_In.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Bu_In.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Bu_In.Location = New System.Drawing.Point(8, 644)
        Me.Bu_In.Name = "Bu_In"
        Me.Bu_In.Size = New System.Drawing.Size(183, 113)
        Me.Bu_In.TabIndex = 11
        Me.Bu_In.Text = "Log_In"
        Me.Bu_In.UseVisualStyleBackColor = True
        '
        'AttendanceTableDataGridView
        '
        Me.AttendanceTableDataGridView.AllowUserToAddRows = False
        Me.AttendanceTableDataGridView.AllowUserToDeleteRows = False
        Me.AttendanceTableDataGridView.AllowUserToResizeColumns = False
        Me.AttendanceTableDataGridView.AllowUserToResizeRows = False
        Me.AttendanceTableDataGridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AttendanceTableDataGridView.AutoGenerateColumns = False
        Me.AttendanceTableDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.AttendanceTableDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.AttendanceTableDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.AttendanceTableDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9})
        Me.AttendanceTableDataGridView.DataSource = Me.AttendanceTableBindingSource
        Me.AttendanceTableDataGridView.Location = New System.Drawing.Point(8, 117)
        Me.AttendanceTableDataGridView.Name = "AttendanceTableDataGridView"
        Me.AttendanceTableDataGridView.Size = New System.Drawing.Size(1264, 521)
        Me.AttendanceTableDataGridView.TabIndex = 10
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "LogID"
        Me.DataGridViewTextBoxColumn1.HeaderText = "LogID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "UserID"
        Me.DataGridViewTextBoxColumn2.HeaderText = "UserID"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Username"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Username"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "LogDate"
        Me.DataGridViewTextBoxColumn4.HeaderText = "LogDate"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "TimeIn"
        Me.DataGridViewTextBoxColumn5.HeaderText = "TimeIn"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "TimeOut"
        Me.DataGridViewTextBoxColumn6.HeaderText = "TimeOut"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "LanchOut"
        Me.DataGridViewTextBoxColumn7.HeaderText = "LanchOut"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "LanchIn"
        Me.DataGridViewTextBoxColumn8.HeaderText = "LanchIn"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "Section"
        Me.DataGridViewTextBoxColumn9.HeaderText = "Section"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.SteelBlue
        Me.GroupBox1.Controls.Add(Me.La_Time)
        Me.GroupBox1.Controls.Add(Me.La_Date)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(8, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1264, 106)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Time and Clock"
        '
        'La_Time
        '
        Me.La_Time.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.La_Time.AutoSize = True
        Me.La_Time.Font = New System.Drawing.Font("Tahoma", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.La_Time.ForeColor = System.Drawing.Color.Maroon
        Me.La_Time.Location = New System.Drawing.Point(665, 23)
        Me.La_Time.Name = "La_Time"
        Me.La_Time.Size = New System.Drawing.Size(246, 77)
        Me.La_Time.TabIndex = 1
        Me.La_Time.Text = "Label1"
        '
        'La_Date
        '
        Me.La_Date.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.La_Date.AutoSize = True
        Me.La_Date.Font = New System.Drawing.Font("Tahoma", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.La_Date.ForeColor = System.Drawing.Color.Maroon
        Me.La_Date.Location = New System.Drawing.Point(184, 23)
        Me.La_Date.Name = "La_Date"
        Me.La_Date.Size = New System.Drawing.Size(246, 77)
        Me.La_Date.TabIndex = 0
        Me.La_Date.Text = "Label1"
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 28)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1281, 788)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'In_Out
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(1289, 820)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.AxZKFPEngX1)
        Me.Controls.Add(Me.AttendanceTableBindingNavigator)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "In_Out"
        Me.Text = "In_Out"
        CType(Me.AxZKFPEngX1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSetInOut, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AttendanceTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AttendanceTableBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.AttendanceTableBindingNavigator.ResumeLayout(False)
        Me.AttendanceTableBindingNavigator.PerformLayout()
        CType(Me.UsersTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.PB_Stamp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.AttendanceTableDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Timer_DateCheck As Timer
    Friend WithEvents AxZKFPEngX1 As AxZKFPEngXControl.AxZKFPEngX
    Friend WithEvents DataSetInOut As DataSetInOut
    Friend WithEvents AttendanceTableBindingSource As BindingSource
    Friend WithEvents AttendanceTableTableAdapter As DataSetInOutTableAdapters.AttendanceTableTableAdapter
    Friend WithEvents TableAdapterManager As DataSetInOutTableAdapters.TableAdapterManager
    Friend WithEvents AttendanceTableBindingNavigator As BindingNavigator
    Friend WithEvents BindingNavigatorAddNewItem As ToolStripButton
    Friend WithEvents BindingNavigatorCountItem As ToolStripLabel
    Friend WithEvents BindingNavigatorDeleteItem As ToolStripButton
    Friend WithEvents BindingNavigatorMoveFirstItem As ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As ToolStripSeparator
    Friend WithEvents AttendanceTableBindingNavigatorSaveItem As ToolStripButton
    Friend WithEvents UsersTableBindingSource As BindingSource
    Friend WithEvents UsersTableTableAdapter As DataSetInOutTableAdapters.UsersTableTableAdapter
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents Bu_BreakOut As Button
    Friend WithEvents Bu_BreakIn As Button
    Friend WithEvents Bu_Out As Button
    Friend WithEvents Bu_In As Button
    Friend WithEvents AttendanceTableDataGridView As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As DataGridViewTextBoxColumn
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents La_Time As Label
    Friend WithEvents La_Date As Label
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents StatusLabel1 As ToolStripStatusLabel
    Friend WithEvents StatusLabel2 As ToolStripStatusLabel
    Friend WithEvents StatusLabel3 As ToolStripStatusLabel
    Friend WithEvents PB_Stamp As PictureBox
End Class