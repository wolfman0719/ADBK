<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class FindByName
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
	Public WithEvents CacheList1 As AxCACHELISTLib.AxCacheList
	Public WithEvents CmdFind As System.Windows.Forms.Button
	Public WithEvents CmdCancel As System.Windows.Forms.Button
	Public WithEvents CmdOK As System.Windows.Forms.Button
	Public WithEvents TxtSNAME As System.Windows.Forms.TextBox
	Public WithEvents LblSname As System.Windows.Forms.Label
	'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
	'Windows フォーム デザイナを使って変更できます。
	'コード エディタを使用して、変更しないでください。
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FindByName))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.CacheList1 = New AxCACHELISTLib.AxCacheList
		Me.CmdFind = New System.Windows.Forms.Button
		Me.CmdCancel = New System.Windows.Forms.Button
		Me.CmdOK = New System.Windows.Forms.Button
		Me.TxtSNAME = New System.Windows.Forms.TextBox
		Me.LblSname = New System.Windows.Forms.Label
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.CacheList1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Text = "Form2"
		Me.ClientSize = New System.Drawing.Size(459, 349)
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
		Me.Name = "FindByName"
		CacheList1.OcxState = CType(resources.GetObject("CacheList1.OcxState"), System.Windows.Forms.AxHost.State)
		Me.CacheList1.Size = New System.Drawing.Size(153, 105)
		Me.CacheList1.Location = New System.Drawing.Point(80, 88)
		Me.CacheList1.TabIndex = 5
		Me.CacheList1.Name = "CacheList1"
		Me.CmdFind.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CmdFind.Text = "検索"
		Me.CmdFind.Size = New System.Drawing.Size(89, 33)
		Me.CmdFind.Location = New System.Drawing.Point(16, 224)
		Me.CmdFind.TabIndex = 4
		Me.CmdFind.BackColor = System.Drawing.SystemColors.Control
		Me.CmdFind.CausesValidation = True
		Me.CmdFind.Enabled = True
		Me.CmdFind.ForeColor = System.Drawing.SystemColors.ControlText
		Me.CmdFind.Cursor = System.Windows.Forms.Cursors.Default
		Me.CmdFind.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CmdFind.TabStop = True
		Me.CmdFind.Name = "CmdFind"
		Me.CmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CmdCancel.Text = "キャンセル"
		Me.CmdCancel.Size = New System.Drawing.Size(89, 33)
		Me.CmdCancel.Location = New System.Drawing.Point(208, 224)
		Me.CmdCancel.TabIndex = 3
		Me.CmdCancel.BackColor = System.Drawing.SystemColors.Control
		Me.CmdCancel.CausesValidation = True
		Me.CmdCancel.Enabled = True
		Me.CmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
		Me.CmdCancel.Cursor = System.Windows.Forms.Cursors.Default
		Me.CmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CmdCancel.TabStop = True
		Me.CmdCancel.Name = "CmdCancel"
		Me.CmdOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CmdOK.Text = "OK"
		Me.CmdOK.Size = New System.Drawing.Size(89, 33)
		Me.CmdOK.Location = New System.Drawing.Point(112, 224)
		Me.CmdOK.TabIndex = 2
		Me.CmdOK.BackColor = System.Drawing.SystemColors.Control
		Me.CmdOK.CausesValidation = True
		Me.CmdOK.Enabled = True
		Me.CmdOK.ForeColor = System.Drawing.SystemColors.ControlText
		Me.CmdOK.Cursor = System.Windows.Forms.Cursors.Default
		Me.CmdOK.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CmdOK.TabStop = True
		Me.CmdOK.Name = "CmdOK"
		Me.TxtSNAME.AutoSize = False
		Me.TxtSNAME.Size = New System.Drawing.Size(169, 33)
		Me.TxtSNAME.Location = New System.Drawing.Point(80, 24)
		Me.TxtSNAME.TabIndex = 1
		Me.TxtSNAME.AcceptsReturn = True
		Me.TxtSNAME.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.TxtSNAME.BackColor = System.Drawing.SystemColors.Window
		Me.TxtSNAME.CausesValidation = True
		Me.TxtSNAME.Enabled = True
		Me.TxtSNAME.ForeColor = System.Drawing.SystemColors.WindowText
		Me.TxtSNAME.HideSelection = True
		Me.TxtSNAME.ReadOnly = False
		Me.TxtSNAME.Maxlength = 0
		Me.TxtSNAME.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.TxtSNAME.MultiLine = False
		Me.TxtSNAME.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.TxtSNAME.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.TxtSNAME.TabStop = True
		Me.TxtSNAME.Visible = True
		Me.TxtSNAME.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.TxtSNAME.Name = "TxtSNAME"
		Me.LblSname.Text = "検索氏名：　　（前方一致）"
		Me.LblSname.Size = New System.Drawing.Size(73, 25)
		Me.LblSname.Location = New System.Drawing.Point(16, 32)
		Me.LblSname.TabIndex = 0
		Me.LblSname.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.LblSname.BackColor = System.Drawing.SystemColors.Control
		Me.LblSname.Enabled = True
		Me.LblSname.ForeColor = System.Drawing.SystemColors.ControlText
		Me.LblSname.Cursor = System.Windows.Forms.Cursors.Default
		Me.LblSname.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.LblSname.UseMnemonic = True
		Me.LblSname.Visible = True
		Me.LblSname.AutoSize = False
		Me.LblSname.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.LblSname.Name = "LblSname"
		Me.Controls.Add(CacheList1)
		Me.Controls.Add(CmdFind)
		Me.Controls.Add(CmdCancel)
		Me.Controls.Add(CmdOK)
		Me.Controls.Add(TxtSNAME)
		Me.Controls.Add(LblSname)
		CType(Me.CacheList1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class