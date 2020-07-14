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
	Public WithEvents VisM1 As AxVISMLib.AxVisM
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ADBKMain))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.CmdEnd = New System.Windows.Forms.Button()
        Me.VisM1 = New AxVISMLib.AxVisM()
        Me.TxtDOB = New System.Windows.Forms.TextBox()
        Me.CmdUpdate = New System.Windows.Forms.Button()
        Me.CmdNew = New System.Windows.Forms.Button()
        Me.CmdDelete = New System.Windows.Forms.Button()
        Me.CmdFind = New System.Windows.Forms.Button()
        Me.TxtAGE = New System.Windows.Forms.TextBox()
        Me.TxtTELO = New System.Windows.Forms.TextBox()
        Me.TxtTELH = New System.Windows.Forms.TextBox()
        Me.TxtADDRESS = New System.Windows.Forms.TextBox()
        Me.TxtZIP = New System.Windows.Forms.TextBox()
        Me.TxtNAME = New System.Windows.Forms.TextBox()
        Me.LblDateFormat = New System.Windows.Forms.Label()
        Me.LblDob = New System.Windows.Forms.Label()
        Me.LblAge = New System.Windows.Forms.Label()
        Me.LblTelo = New System.Windows.Forms.Label()
        Me.LblTelh = New System.Windows.Forms.Label()
        Me.LblAddress = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.VisM1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CmdEnd
        '
        Me.CmdEnd.BackColor = System.Drawing.SystemColors.Control
        Me.CmdEnd.Cursor = System.Windows.Forms.Cursors.Default
        Me.CmdEnd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdEnd.Location = New System.Drawing.Point(344, 368)
        Me.CmdEnd.Name = "CmdEnd"
        Me.CmdEnd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CmdEnd.Size = New System.Drawing.Size(73, 33)
        Me.CmdEnd.TabIndex = 19
        Me.CmdEnd.Text = "終了"
        Me.CmdEnd.UseVisualStyleBackColor = False
        '
        'VisM1
        '
        Me.VisM1.Enabled = True
        Me.VisM1.Location = New System.Drawing.Point(400, 320)
        Me.VisM1.Name = "VisM1"
        Me.VisM1.OcxState = CType(resources.GetObject("VisM1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.VisM1.Size = New System.Drawing.Size(28, 28)
        Me.VisM1.TabIndex = 20
        '
        'TxtDOB
        '
        Me.TxtDOB.AcceptsReturn = True
        Me.TxtDOB.BackColor = System.Drawing.SystemColors.Window
        Me.TxtDOB.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TxtDOB.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TxtDOB.Location = New System.Drawing.Point(128, 320)
        Me.TxtDOB.MaxLength = 0
        Me.TxtDOB.Name = "TxtDOB"
        Me.TxtDOB.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtDOB.Size = New System.Drawing.Size(129, 25)
        Me.TxtDOB.TabIndex = 18
        '
        'CmdUpdate
        '
        Me.CmdUpdate.BackColor = System.Drawing.SystemColors.Control
        Me.CmdUpdate.Cursor = System.Windows.Forms.Cursors.Default
        Me.CmdUpdate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdUpdate.Location = New System.Drawing.Point(264, 368)
        Me.CmdUpdate.Name = "CmdUpdate"
        Me.CmdUpdate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CmdUpdate.Size = New System.Drawing.Size(73, 33)
        Me.CmdUpdate.TabIndex = 16
        Me.CmdUpdate.Text = "登録／更新"
        Me.CmdUpdate.UseVisualStyleBackColor = False
        '
        'CmdNew
        '
        Me.CmdNew.BackColor = System.Drawing.SystemColors.Control
        Me.CmdNew.Cursor = System.Windows.Forms.Cursors.Default
        Me.CmdNew.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdNew.Location = New System.Drawing.Point(104, 368)
        Me.CmdNew.Name = "CmdNew"
        Me.CmdNew.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CmdNew.Size = New System.Drawing.Size(73, 33)
        Me.CmdNew.TabIndex = 15
        Me.CmdNew.Text = "新規"
        Me.CmdNew.UseVisualStyleBackColor = False
        '
        'CmdDelete
        '
        Me.CmdDelete.BackColor = System.Drawing.SystemColors.Control
        Me.CmdDelete.Cursor = System.Windows.Forms.Cursors.Default
        Me.CmdDelete.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdDelete.Location = New System.Drawing.Point(184, 368)
        Me.CmdDelete.Name = "CmdDelete"
        Me.CmdDelete.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CmdDelete.Size = New System.Drawing.Size(73, 33)
        Me.CmdDelete.TabIndex = 14
        Me.CmdDelete.Text = "削除"
        Me.CmdDelete.UseVisualStyleBackColor = False
        '
        'CmdFind
        '
        Me.CmdFind.BackColor = System.Drawing.SystemColors.Control
        Me.CmdFind.Cursor = System.Windows.Forms.Cursors.Default
        Me.CmdFind.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdFind.Location = New System.Drawing.Point(24, 368)
        Me.CmdFind.Name = "CmdFind"
        Me.CmdFind.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CmdFind.Size = New System.Drawing.Size(73, 33)
        Me.CmdFind.TabIndex = 13
        Me.CmdFind.Text = "検索"
        Me.CmdFind.UseVisualStyleBackColor = False
        '
        'TxtAGE
        '
        Me.TxtAGE.AcceptsReturn = True
        Me.TxtAGE.BackColor = System.Drawing.SystemColors.Window
        Me.TxtAGE.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TxtAGE.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TxtAGE.Location = New System.Drawing.Point(128, 280)
        Me.TxtAGE.MaxLength = 0
        Me.TxtAGE.Name = "TxtAGE"
        Me.TxtAGE.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtAGE.Size = New System.Drawing.Size(97, 25)
        Me.TxtAGE.TabIndex = 11
        '
        'TxtTELO
        '
        Me.TxtTELO.AcceptsReturn = True
        Me.TxtTELO.BackColor = System.Drawing.SystemColors.Window
        Me.TxtTELO.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TxtTELO.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TxtTELO.Location = New System.Drawing.Point(128, 240)
        Me.TxtTELO.MaxLength = 0
        Me.TxtTELO.Name = "TxtTELO"
        Me.TxtTELO.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtTELO.Size = New System.Drawing.Size(153, 25)
        Me.TxtTELO.TabIndex = 10
        '
        'TxtTELH
        '
        Me.TxtTELH.AcceptsReturn = True
        Me.TxtTELH.BackColor = System.Drawing.SystemColors.Window
        Me.TxtTELH.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TxtTELH.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TxtTELH.Location = New System.Drawing.Point(128, 200)
        Me.TxtTELH.MaxLength = 0
        Me.TxtTELH.Name = "TxtTELH"
        Me.TxtTELH.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtTELH.Size = New System.Drawing.Size(153, 25)
        Me.TxtTELH.TabIndex = 8
        '
        'TxtADDRESS
        '
        Me.TxtADDRESS.AcceptsReturn = True
        Me.TxtADDRESS.BackColor = System.Drawing.SystemColors.Window
        Me.TxtADDRESS.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TxtADDRESS.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TxtADDRESS.Location = New System.Drawing.Point(128, 160)
        Me.TxtADDRESS.MaxLength = 0
        Me.TxtADDRESS.Name = "TxtADDRESS"
        Me.TxtADDRESS.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtADDRESS.Size = New System.Drawing.Size(289, 25)
        Me.TxtADDRESS.TabIndex = 6
        '
        'TxtZIP
        '
        Me.TxtZIP.AcceptsReturn = True
        Me.TxtZIP.BackColor = System.Drawing.SystemColors.Window
        Me.TxtZIP.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TxtZIP.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TxtZIP.Location = New System.Drawing.Point(128, 120)
        Me.TxtZIP.MaxLength = 0
        Me.TxtZIP.Name = "TxtZIP"
        Me.TxtZIP.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtZIP.Size = New System.Drawing.Size(57, 25)
        Me.TxtZIP.TabIndex = 4
        '
        'TxtNAME
        '
        Me.TxtNAME.AcceptsReturn = True
        Me.TxtNAME.BackColor = System.Drawing.SystemColors.Window
        Me.TxtNAME.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TxtNAME.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TxtNAME.Location = New System.Drawing.Point(128, 80)
        Me.TxtNAME.MaxLength = 0
        Me.TxtNAME.Name = "TxtNAME"
        Me.TxtNAME.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtNAME.Size = New System.Drawing.Size(185, 25)
        Me.TxtNAME.TabIndex = 2
        '
        'LblDateFormat
        '
        Me.LblDateFormat.BackColor = System.Drawing.SystemColors.Control
        Me.LblDateFormat.Cursor = System.Windows.Forms.Cursors.Default
        Me.LblDateFormat.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LblDateFormat.Location = New System.Drawing.Point(280, 328)
        Me.LblDateFormat.Name = "LblDateFormat"
        Me.LblDateFormat.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LblDateFormat.Size = New System.Drawing.Size(89, 17)
        Me.LblDateFormat.TabIndex = 20
        Me.LblDateFormat.Text = "YYYY-MM-DD"
        '
        'LblDob
        '
        Me.LblDob.BackColor = System.Drawing.SystemColors.Control
        Me.LblDob.Cursor = System.Windows.Forms.Cursors.Default
        Me.LblDob.Font = New System.Drawing.Font("ＭＳ Ｐ明朝", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblDob.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LblDob.Location = New System.Drawing.Point(24, 328)
        Me.LblDob.Name = "LblDob"
        Me.LblDob.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LblDob.Size = New System.Drawing.Size(81, 25)
        Me.LblDob.TabIndex = 17
        Me.LblDob.Text = "生年月日："
        '
        'LblAge
        '
        Me.LblAge.BackColor = System.Drawing.SystemColors.Control
        Me.LblAge.Cursor = System.Windows.Forms.Cursors.Default
        Me.LblAge.Font = New System.Drawing.Font("ＭＳ Ｐ明朝", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblAge.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LblAge.Location = New System.Drawing.Point(24, 288)
        Me.LblAge.Name = "LblAge"
        Me.LblAge.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LblAge.Size = New System.Drawing.Size(81, 25)
        Me.LblAge.TabIndex = 12
        Me.LblAge.Text = "年齢："
        '
        'LblTelo
        '
        Me.LblTelo.BackColor = System.Drawing.SystemColors.Control
        Me.LblTelo.Cursor = System.Windows.Forms.Cursors.Default
        Me.LblTelo.Font = New System.Drawing.Font("ＭＳ Ｐ明朝", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblTelo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LblTelo.Location = New System.Drawing.Point(24, 248)
        Me.LblTelo.Name = "LblTelo"
        Me.LblTelo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LblTelo.Size = New System.Drawing.Size(81, 25)
        Me.LblTelo.TabIndex = 9
        Me.LblTelo.Text = "会社Tel："
        '
        'LblTelh
        '
        Me.LblTelh.BackColor = System.Drawing.SystemColors.Control
        Me.LblTelh.Cursor = System.Windows.Forms.Cursors.Default
        Me.LblTelh.Font = New System.Drawing.Font("ＭＳ Ｐ明朝", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblTelh.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LblTelh.Location = New System.Drawing.Point(24, 208)
        Me.LblTelh.Name = "LblTelh"
        Me.LblTelh.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LblTelh.Size = New System.Drawing.Size(81, 25)
        Me.LblTelh.TabIndex = 7
        Me.LblTelh.Text = "自宅Tel："
        '
        'LblAddress
        '
        Me.LblAddress.BackColor = System.Drawing.SystemColors.Control
        Me.LblAddress.Cursor = System.Windows.Forms.Cursors.Default
        Me.LblAddress.Font = New System.Drawing.Font("ＭＳ Ｐ明朝", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblAddress.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LblAddress.Location = New System.Drawing.Point(24, 168)
        Me.LblAddress.Name = "LblAddress"
        Me.LblAddress.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LblAddress.Size = New System.Drawing.Size(81, 25)
        Me.LblAddress.TabIndex = 5
        Me.LblAddress.Text = "住所："
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("ＭＳ Ｐ明朝", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(24, 120)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(81, 25)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "郵便番号："
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("ＭＳ Ｐ明朝", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(24, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(49, 25)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "名前："
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("ＭＳ Ｐ明朝", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(160, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(161, 33)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "住所録"
        '
        'ADBKMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(425, 424)
        Me.Controls.Add(Me.CmdEnd)
        Me.Controls.Add(Me.VisM1)
        Me.Controls.Add(Me.TxtDOB)
        Me.Controls.Add(Me.CmdUpdate)
        Me.Controls.Add(Me.CmdNew)
        Me.Controls.Add(Me.CmdDelete)
        Me.Controls.Add(Me.CmdFind)
        Me.Controls.Add(Me.TxtAGE)
        Me.Controls.Add(Me.TxtTELO)
        Me.Controls.Add(Me.TxtTELH)
        Me.Controls.Add(Me.TxtADDRESS)
        Me.Controls.Add(Me.TxtZIP)
        Me.Controls.Add(Me.TxtNAME)
        Me.Controls.Add(Me.LblDateFormat)
        Me.Controls.Add(Me.LblDob)
        Me.Controls.Add(Me.LblAge)
        Me.Controls.Add(Me.LblTelo)
        Me.Controls.Add(Me.LblTelh)
        Me.Controls.Add(Me.LblAddress)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Location = New System.Drawing.Point(4, 23)
        Me.Name = "ADBKMain"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Form1"
        CType(Me.VisM1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
#End Region
End Class