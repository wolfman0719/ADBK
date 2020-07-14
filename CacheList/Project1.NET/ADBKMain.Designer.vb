<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class ADBKMain
#Region "Windows フォーム デザイナによって生成されたコード "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
		'この呼び出しは、Windows フォーム デザイナで必要です。
		InitializeComponent()
	End Sub
	'Form は、コンポーネント一覧に後処理を実行するために dispose をオーバーライドします。
	<System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
		If Disposing Then
			If Not components Is Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(Disposing)
	End Sub
	'Windows フォーム デザイナで必要です。
	Private components As System.ComponentModel.IContainer
	Public ToolTip1 As System.Windows.Forms.ToolTip
	Public WithEvents CmdEnd As System.Windows.Forms.Button
	Public WithEvents TxtDOB As System.Windows.Forms.TextBox
	Public WithEvents CmdUpdate As System.Windows.Forms.Button
	Public WithEvents CmdNew As System.Windows.Forms.Button
	Public WithEvents CmdDelete As System.Windows.Forms.Button
	Public WithEvents CmdFind As System.Windows.Forms.Button
	Public WithEvents TxtAGE As System.Windows.Forms.TextBox
	Public WithEvents TxtTELO As System.Windows.Forms.TextBox
	Public WithEvents TxtTELH As System.Windows.Forms.TextBox
	Public WithEvents TxtADDRESS As System.Windows.Forms.TextBox
	Public WithEvents TxtZIP As System.Windows.Forms.TextBox
	Public WithEvents TxtNAME As System.Windows.Forms.TextBox
	Public WithEvents lblAID As System.Windows.Forms.Label
	Public WithEvents LblDateFormat As System.Windows.Forms.Label
	Public WithEvents LblDob As System.Windows.Forms.Label
	Public WithEvents LblAge As System.Windows.Forms.Label
	Public WithEvents LblTelo As System.Windows.Forms.Label
	Public WithEvents LblTelh As System.Windows.Forms.Label
	Public WithEvents LblAddress As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
	'Windows フォーム デザイナを使って変更できます。
	'コード エディタを使用して、変更しないでください。
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ADBKMain))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.CmdEnd = New System.Windows.Forms.Button
		Me.TxtDOB = New System.Windows.Forms.TextBox
		Me.CmdUpdate = New System.Windows.Forms.Button
		Me.CmdNew = New System.Windows.Forms.Button
		Me.CmdDelete = New System.Windows.Forms.Button
		Me.CmdFind = New System.Windows.Forms.Button
		Me.TxtAGE = New System.Windows.Forms.TextBox
		Me.TxtTELO = New System.Windows.Forms.TextBox
		Me.TxtTELH = New System.Windows.Forms.TextBox
		Me.TxtADDRESS = New System.Windows.Forms.TextBox
		Me.TxtZIP = New System.Windows.Forms.TextBox
		Me.TxtNAME = New System.Windows.Forms.TextBox
		Me.lblAID = New System.Windows.Forms.Label
		Me.LblDateFormat = New System.Windows.Forms.Label
		Me.LblDob = New System.Windows.Forms.Label
		Me.LblAge = New System.Windows.Forms.Label
		Me.LblTelo = New System.Windows.Forms.Label
		Me.LblTelh = New System.Windows.Forms.Label
		Me.LblAddress = New System.Windows.Forms.Label
		Me.Label3 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.Text = "Form1"
		Me.ClientSize = New System.Drawing.Size(425, 424)
		Me.Location = New System.Drawing.Point(4, 23)
		Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
		Me.ControlBox = True
		Me.Enabled = True
		Me.KeyPreview = False
		Me.MaximizeBox = True
		Me.MinimizeBox = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "ADBKMain"
		Me.CmdEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CmdEnd.Text = "終了"
		Me.CmdEnd.Size = New System.Drawing.Size(73, 33)
		Me.CmdEnd.Location = New System.Drawing.Point(344, 368)
		Me.CmdEnd.TabIndex = 19
		Me.CmdEnd.BackColor = System.Drawing.SystemColors.Control
		Me.CmdEnd.CausesValidation = True
		Me.CmdEnd.Enabled = True
		Me.CmdEnd.ForeColor = System.Drawing.SystemColors.ControlText
		Me.CmdEnd.Cursor = System.Windows.Forms.Cursors.Default
		Me.CmdEnd.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CmdEnd.TabStop = True
		Me.CmdEnd.Name = "CmdEnd"
		Me.TxtDOB.AutoSize = False
		Me.TxtDOB.Size = New System.Drawing.Size(129, 25)
		Me.TxtDOB.Location = New System.Drawing.Point(128, 320)
		Me.TxtDOB.TabIndex = 18
		Me.TxtDOB.AcceptsReturn = True
		Me.TxtDOB.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.TxtDOB.BackColor = System.Drawing.SystemColors.Window
		Me.TxtDOB.CausesValidation = True
		Me.TxtDOB.Enabled = True
		Me.TxtDOB.ForeColor = System.Drawing.SystemColors.WindowText
		Me.TxtDOB.HideSelection = True
		Me.TxtDOB.ReadOnly = False
		Me.TxtDOB.Maxlength = 0
		Me.TxtDOB.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.TxtDOB.MultiLine = False
		Me.TxtDOB.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.TxtDOB.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.TxtDOB.TabStop = True
		Me.TxtDOB.Visible = True
		Me.TxtDOB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.TxtDOB.Name = "TxtDOB"
		Me.CmdUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CmdUpdate.Text = "登録／更新"
		Me.CmdUpdate.Size = New System.Drawing.Size(73, 33)
		Me.CmdUpdate.Location = New System.Drawing.Point(264, 368)
		Me.CmdUpdate.TabIndex = 16
		Me.CmdUpdate.BackColor = System.Drawing.SystemColors.Control
		Me.CmdUpdate.CausesValidation = True
		Me.CmdUpdate.Enabled = True
		Me.CmdUpdate.ForeColor = System.Drawing.SystemColors.ControlText
		Me.CmdUpdate.Cursor = System.Windows.Forms.Cursors.Default
		Me.CmdUpdate.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CmdUpdate.TabStop = True
		Me.CmdUpdate.Name = "CmdUpdate"
		Me.CmdNew.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CmdNew.Text = "新規"
		Me.CmdNew.Size = New System.Drawing.Size(73, 33)
		Me.CmdNew.Location = New System.Drawing.Point(104, 368)
		Me.CmdNew.TabIndex = 15
		Me.CmdNew.BackColor = System.Drawing.SystemColors.Control
		Me.CmdNew.CausesValidation = True
		Me.CmdNew.Enabled = True
		Me.CmdNew.ForeColor = System.Drawing.SystemColors.ControlText
		Me.CmdNew.Cursor = System.Windows.Forms.Cursors.Default
		Me.CmdNew.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CmdNew.TabStop = True
		Me.CmdNew.Name = "CmdNew"
		Me.CmdDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CmdDelete.Text = "削除"
		Me.CmdDelete.Size = New System.Drawing.Size(73, 33)
		Me.CmdDelete.Location = New System.Drawing.Point(184, 368)
		Me.CmdDelete.TabIndex = 14
		Me.CmdDelete.BackColor = System.Drawing.SystemColors.Control
		Me.CmdDelete.CausesValidation = True
		Me.CmdDelete.Enabled = True
		Me.CmdDelete.ForeColor = System.Drawing.SystemColors.ControlText
		Me.CmdDelete.Cursor = System.Windows.Forms.Cursors.Default
		Me.CmdDelete.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CmdDelete.TabStop = True
		Me.CmdDelete.Name = "CmdDelete"
		Me.CmdFind.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CmdFind.Text = "検索"
		Me.CmdFind.Size = New System.Drawing.Size(73, 33)
		Me.CmdFind.Location = New System.Drawing.Point(24, 368)
		Me.CmdFind.TabIndex = 13
		Me.CmdFind.BackColor = System.Drawing.SystemColors.Control
		Me.CmdFind.CausesValidation = True
		Me.CmdFind.Enabled = True
		Me.CmdFind.ForeColor = System.Drawing.SystemColors.ControlText
		Me.CmdFind.Cursor = System.Windows.Forms.Cursors.Default
		Me.CmdFind.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CmdFind.TabStop = True
		Me.CmdFind.Name = "CmdFind"
		Me.TxtAGE.AutoSize = False
		Me.TxtAGE.Size = New System.Drawing.Size(97, 25)
		Me.TxtAGE.Location = New System.Drawing.Point(128, 280)
		Me.TxtAGE.TabIndex = 11
		Me.TxtAGE.AcceptsReturn = True
		Me.TxtAGE.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.TxtAGE.BackColor = System.Drawing.SystemColors.Window
		Me.TxtAGE.CausesValidation = True
		Me.TxtAGE.Enabled = True
		Me.TxtAGE.ForeColor = System.Drawing.SystemColors.WindowText
		Me.TxtAGE.HideSelection = True
		Me.TxtAGE.ReadOnly = False
		Me.TxtAGE.Maxlength = 0
		Me.TxtAGE.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.TxtAGE.MultiLine = False
		Me.TxtAGE.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.TxtAGE.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.TxtAGE.TabStop = True
		Me.TxtAGE.Visible = True
		Me.TxtAGE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.TxtAGE.Name = "TxtAGE"
		Me.TxtTELO.AutoSize = False
		Me.TxtTELO.Size = New System.Drawing.Size(153, 25)
		Me.TxtTELO.Location = New System.Drawing.Point(128, 240)
		Me.TxtTELO.TabIndex = 10
		Me.TxtTELO.AcceptsReturn = True
		Me.TxtTELO.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.TxtTELO.BackColor = System.Drawing.SystemColors.Window
		Me.TxtTELO.CausesValidation = True
		Me.TxtTELO.Enabled = True
		Me.TxtTELO.ForeColor = System.Drawing.SystemColors.WindowText
		Me.TxtTELO.HideSelection = True
		Me.TxtTELO.ReadOnly = False
		Me.TxtTELO.Maxlength = 0
		Me.TxtTELO.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.TxtTELO.MultiLine = False
		Me.TxtTELO.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.TxtTELO.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.TxtTELO.TabStop = True
		Me.TxtTELO.Visible = True
		Me.TxtTELO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.TxtTELO.Name = "TxtTELO"
		Me.TxtTELH.AutoSize = False
		Me.TxtTELH.Size = New System.Drawing.Size(153, 25)
		Me.TxtTELH.Location = New System.Drawing.Point(128, 200)
		Me.TxtTELH.TabIndex = 8
		Me.TxtTELH.AcceptsReturn = True
		Me.TxtTELH.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.TxtTELH.BackColor = System.Drawing.SystemColors.Window
		Me.TxtTELH.CausesValidation = True
		Me.TxtTELH.Enabled = True
		Me.TxtTELH.ForeColor = System.Drawing.SystemColors.WindowText
		Me.TxtTELH.HideSelection = True
		Me.TxtTELH.ReadOnly = False
		Me.TxtTELH.Maxlength = 0
		Me.TxtTELH.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.TxtTELH.MultiLine = False
		Me.TxtTELH.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.TxtTELH.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.TxtTELH.TabStop = True
		Me.TxtTELH.Visible = True
		Me.TxtTELH.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.TxtTELH.Name = "TxtTELH"
		Me.TxtADDRESS.AutoSize = False
		Me.TxtADDRESS.Size = New System.Drawing.Size(289, 25)
		Me.TxtADDRESS.Location = New System.Drawing.Point(128, 160)
		Me.TxtADDRESS.TabIndex = 6
		Me.TxtADDRESS.AcceptsReturn = True
		Me.TxtADDRESS.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.TxtADDRESS.BackColor = System.Drawing.SystemColors.Window
		Me.TxtADDRESS.CausesValidation = True
		Me.TxtADDRESS.Enabled = True
		Me.TxtADDRESS.ForeColor = System.Drawing.SystemColors.WindowText
		Me.TxtADDRESS.HideSelection = True
		Me.TxtADDRESS.ReadOnly = False
		Me.TxtADDRESS.Maxlength = 0
		Me.TxtADDRESS.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.TxtADDRESS.MultiLine = False
		Me.TxtADDRESS.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.TxtADDRESS.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.TxtADDRESS.TabStop = True
		Me.TxtADDRESS.Visible = True
		Me.TxtADDRESS.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.TxtADDRESS.Name = "TxtADDRESS"
		Me.TxtZIP.AutoSize = False
		Me.TxtZIP.Size = New System.Drawing.Size(57, 25)
		Me.TxtZIP.Location = New System.Drawing.Point(128, 120)
		Me.TxtZIP.TabIndex = 4
		Me.TxtZIP.AcceptsReturn = True
		Me.TxtZIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.TxtZIP.BackColor = System.Drawing.SystemColors.Window
		Me.TxtZIP.CausesValidation = True
		Me.TxtZIP.Enabled = True
		Me.TxtZIP.ForeColor = System.Drawing.SystemColors.WindowText
		Me.TxtZIP.HideSelection = True
		Me.TxtZIP.ReadOnly = False
		Me.TxtZIP.Maxlength = 0
		Me.TxtZIP.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.TxtZIP.MultiLine = False
		Me.TxtZIP.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.TxtZIP.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.TxtZIP.TabStop = True
		Me.TxtZIP.Visible = True
		Me.TxtZIP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.TxtZIP.Name = "TxtZIP"
		Me.TxtNAME.AutoSize = False
		Me.TxtNAME.Size = New System.Drawing.Size(185, 25)
		Me.TxtNAME.Location = New System.Drawing.Point(128, 80)
		Me.TxtNAME.TabIndex = 2
		Me.TxtNAME.AcceptsReturn = True
		Me.TxtNAME.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.TxtNAME.BackColor = System.Drawing.SystemColors.Window
		Me.TxtNAME.CausesValidation = True
		Me.TxtNAME.Enabled = True
		Me.TxtNAME.ForeColor = System.Drawing.SystemColors.WindowText
		Me.TxtNAME.HideSelection = True
		Me.TxtNAME.ReadOnly = False
		Me.TxtNAME.Maxlength = 0
		Me.TxtNAME.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.TxtNAME.MultiLine = False
		Me.TxtNAME.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.TxtNAME.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.TxtNAME.TabStop = True
		Me.TxtNAME.Visible = True
		Me.TxtNAME.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.TxtNAME.Name = "TxtNAME"
		Me.lblAID.Size = New System.Drawing.Size(57, 17)
		Me.lblAID.Location = New System.Drawing.Point(16, 16)
		Me.lblAID.TabIndex = 21
		Me.lblAID.Visible = False
		Me.lblAID.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblAID.BackColor = System.Drawing.SystemColors.Control
		Me.lblAID.Enabled = True
		Me.lblAID.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblAID.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblAID.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblAID.UseMnemonic = True
		Me.lblAID.AutoSize = False
		Me.lblAID.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblAID.Name = "lblAID"
		Me.LblDateFormat.Text = "YYYY/MM/DD"
		Me.LblDateFormat.Size = New System.Drawing.Size(89, 17)
		Me.LblDateFormat.Location = New System.Drawing.Point(280, 328)
		Me.LblDateFormat.TabIndex = 20
		Me.LblDateFormat.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.LblDateFormat.BackColor = System.Drawing.SystemColors.Control
		Me.LblDateFormat.Enabled = True
		Me.LblDateFormat.ForeColor = System.Drawing.SystemColors.ControlText
		Me.LblDateFormat.Cursor = System.Windows.Forms.Cursors.Default
		Me.LblDateFormat.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.LblDateFormat.UseMnemonic = True
		Me.LblDateFormat.Visible = True
		Me.LblDateFormat.AutoSize = False
		Me.LblDateFormat.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.LblDateFormat.Name = "LblDateFormat"
		Me.LblDob.Text = "生年月日："
		Me.LblDob.Font = New System.Drawing.Font("ＭＳ Ｐ明朝", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.LblDob.Size = New System.Drawing.Size(81, 25)
		Me.LblDob.Location = New System.Drawing.Point(24, 328)
		Me.LblDob.TabIndex = 17
		Me.LblDob.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.LblDob.BackColor = System.Drawing.SystemColors.Control
		Me.LblDob.Enabled = True
		Me.LblDob.ForeColor = System.Drawing.SystemColors.ControlText
		Me.LblDob.Cursor = System.Windows.Forms.Cursors.Default
		Me.LblDob.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.LblDob.UseMnemonic = True
		Me.LblDob.Visible = True
		Me.LblDob.AutoSize = False
		Me.LblDob.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.LblDob.Name = "LblDob"
		Me.LblAge.Text = "年齢："
		Me.LblAge.Font = New System.Drawing.Font("ＭＳ Ｐ明朝", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.LblAge.Size = New System.Drawing.Size(81, 25)
		Me.LblAge.Location = New System.Drawing.Point(24, 288)
		Me.LblAge.TabIndex = 12
		Me.LblAge.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.LblAge.BackColor = System.Drawing.SystemColors.Control
		Me.LblAge.Enabled = True
		Me.LblAge.ForeColor = System.Drawing.SystemColors.ControlText
		Me.LblAge.Cursor = System.Windows.Forms.Cursors.Default
		Me.LblAge.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.LblAge.UseMnemonic = True
		Me.LblAge.Visible = True
		Me.LblAge.AutoSize = False
		Me.LblAge.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.LblAge.Name = "LblAge"
		Me.LblTelo.Text = "会社Tel："
		Me.LblTelo.Font = New System.Drawing.Font("ＭＳ Ｐ明朝", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.LblTelo.Size = New System.Drawing.Size(81, 25)
		Me.LblTelo.Location = New System.Drawing.Point(24, 248)
		Me.LblTelo.TabIndex = 9
		Me.LblTelo.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.LblTelo.BackColor = System.Drawing.SystemColors.Control
		Me.LblTelo.Enabled = True
		Me.LblTelo.ForeColor = System.Drawing.SystemColors.ControlText
		Me.LblTelo.Cursor = System.Windows.Forms.Cursors.Default
		Me.LblTelo.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.LblTelo.UseMnemonic = True
		Me.LblTelo.Visible = True
		Me.LblTelo.AutoSize = False
		Me.LblTelo.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.LblTelo.Name = "LblTelo"
		Me.LblTelh.Text = "自宅Tel："
		Me.LblTelh.Font = New System.Drawing.Font("ＭＳ Ｐ明朝", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.LblTelh.Size = New System.Drawing.Size(81, 25)
		Me.LblTelh.Location = New System.Drawing.Point(24, 208)
		Me.LblTelh.TabIndex = 7
		Me.LblTelh.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.LblTelh.BackColor = System.Drawing.SystemColors.Control
		Me.LblTelh.Enabled = True
		Me.LblTelh.ForeColor = System.Drawing.SystemColors.ControlText
		Me.LblTelh.Cursor = System.Windows.Forms.Cursors.Default
		Me.LblTelh.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.LblTelh.UseMnemonic = True
		Me.LblTelh.Visible = True
		Me.LblTelh.AutoSize = False
		Me.LblTelh.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.LblTelh.Name = "LblTelh"
		Me.LblAddress.Text = "住所："
		Me.LblAddress.Font = New System.Drawing.Font("ＭＳ Ｐ明朝", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.LblAddress.Size = New System.Drawing.Size(81, 25)
		Me.LblAddress.Location = New System.Drawing.Point(24, 168)
		Me.LblAddress.TabIndex = 5
		Me.LblAddress.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.LblAddress.BackColor = System.Drawing.SystemColors.Control
		Me.LblAddress.Enabled = True
		Me.LblAddress.ForeColor = System.Drawing.SystemColors.ControlText
		Me.LblAddress.Cursor = System.Windows.Forms.Cursors.Default
		Me.LblAddress.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.LblAddress.UseMnemonic = True
		Me.LblAddress.Visible = True
		Me.LblAddress.AutoSize = False
		Me.LblAddress.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.LblAddress.Name = "LblAddress"
		Me.Label3.Text = "郵便番号："
		Me.Label3.Font = New System.Drawing.Font("ＭＳ Ｐ明朝", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.Label3.Size = New System.Drawing.Size(81, 25)
		Me.Label3.Location = New System.Drawing.Point(24, 120)
		Me.Label3.TabIndex = 3
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label3.BackColor = System.Drawing.SystemColors.Control
		Me.Label3.Enabled = True
		Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label3.UseMnemonic = True
		Me.Label3.Visible = True
		Me.Label3.AutoSize = False
		Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label3.Name = "Label3"
		Me.Label2.Text = "名前："
		Me.Label2.Font = New System.Drawing.Font("ＭＳ Ｐ明朝", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.Label2.Size = New System.Drawing.Size(49, 25)
		Me.Label2.Location = New System.Drawing.Point(24, 80)
		Me.Label2.TabIndex = 1
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label2.BackColor = System.Drawing.SystemColors.Control
		Me.Label2.Enabled = True
		Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label2.UseMnemonic = True
		Me.Label2.Visible = True
		Me.Label2.AutoSize = False
		Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label2.Name = "Label2"
		Me.Label1.Text = "住所録"
		Me.Label1.Font = New System.Drawing.Font("ＭＳ Ｐ明朝", 15.75!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.Label1.Size = New System.Drawing.Size(161, 33)
		Me.Label1.Location = New System.Drawing.Point(160, 24)
		Me.Label1.TabIndex = 0
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label1.BackColor = System.Drawing.SystemColors.Control
		Me.Label1.Enabled = True
		Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1.UseMnemonic = True
		Me.Label1.Visible = True
		Me.Label1.AutoSize = False
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label1.Name = "Label1"
		Me.Controls.Add(CmdEnd)
		Me.Controls.Add(TxtDOB)
		Me.Controls.Add(CmdUpdate)
		Me.Controls.Add(CmdNew)
		Me.Controls.Add(CmdDelete)
		Me.Controls.Add(CmdFind)
		Me.Controls.Add(TxtAGE)
		Me.Controls.Add(TxtTELO)
		Me.Controls.Add(TxtTELH)
		Me.Controls.Add(TxtADDRESS)
		Me.Controls.Add(TxtZIP)
		Me.Controls.Add(TxtNAME)
		Me.Controls.Add(lblAID)
		Me.Controls.Add(LblDateFormat)
		Me.Controls.Add(LblDob)
		Me.Controls.Add(LblAge)
		Me.Controls.Add(LblTelo)
		Me.Controls.Add(LblTelh)
		Me.Controls.Add(LblAddress)
		Me.Controls.Add(Label3)
		Me.Controls.Add(Label2)
		Me.Controls.Add(Label1)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class