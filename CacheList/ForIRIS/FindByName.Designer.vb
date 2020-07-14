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
	'Public WithEvents CacheList1 As AxCACHELISTLib.AxCacheList
	Public WithEvents CmdFind As System.Windows.Forms.Button
	Public WithEvents CmdCancel As System.Windows.Forms.Button
	Public WithEvents CmdOK As System.Windows.Forms.Button
	Public WithEvents TxtSNAME As System.Windows.Forms.TextBox
	Public WithEvents LblSname As System.Windows.Forms.Label
	'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
	'Windows フォーム デザイナを使って変更できます。
	'コード エディタを使用して、変更しないでください。
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.CmdFind = New System.Windows.Forms.Button()
        Me.CmdCancel = New System.Windows.Forms.Button()
        Me.CmdOK = New System.Windows.Forms.Button()
        Me.TxtSNAME = New System.Windows.Forms.TextBox()
        Me.LblSname = New System.Windows.Forms.Label()
        Me.ListLookupName = New System.Windows.Forms.ListBox()
        Me.DataSet1 = New Project1.DataSet1()
        Me.ADBKBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ADBKTableAdapter = New Project1.DataSet1TableAdapters.ADBKTableAdapter()
        Me.DataSet1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ADBKBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CmdFind
        '
        Me.CmdFind.BackColor = System.Drawing.SystemColors.Control
        Me.CmdFind.Cursor = System.Windows.Forms.Cursors.Default
        Me.CmdFind.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdFind.Location = New System.Drawing.Point(16, 224)
        Me.CmdFind.Name = "CmdFind"
        Me.CmdFind.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CmdFind.Size = New System.Drawing.Size(89, 33)
        Me.CmdFind.TabIndex = 4
        Me.CmdFind.Text = "検索"
        Me.CmdFind.UseVisualStyleBackColor = False
        '
        'CmdCancel
        '
        Me.CmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.CmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.CmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdCancel.Location = New System.Drawing.Point(208, 224)
        Me.CmdCancel.Name = "CmdCancel"
        Me.CmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CmdCancel.Size = New System.Drawing.Size(89, 33)
        Me.CmdCancel.TabIndex = 3
        Me.CmdCancel.Text = "キャンセル"
        Me.CmdCancel.UseVisualStyleBackColor = False
        '
        'CmdOK
        '
        Me.CmdOK.BackColor = System.Drawing.SystemColors.Control
        Me.CmdOK.Cursor = System.Windows.Forms.Cursors.Default
        Me.CmdOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdOK.Location = New System.Drawing.Point(112, 224)
        Me.CmdOK.Name = "CmdOK"
        Me.CmdOK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CmdOK.Size = New System.Drawing.Size(89, 33)
        Me.CmdOK.TabIndex = 2
        Me.CmdOK.Text = "OK"
        Me.CmdOK.UseVisualStyleBackColor = False
        '
        'TxtSNAME
        '
        Me.TxtSNAME.AcceptsReturn = True
        Me.TxtSNAME.BackColor = System.Drawing.SystemColors.Window
        Me.TxtSNAME.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TxtSNAME.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TxtSNAME.Location = New System.Drawing.Point(128, 24)
        Me.TxtSNAME.MaxLength = 0
        Me.TxtSNAME.Name = "TxtSNAME"
        Me.TxtSNAME.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtSNAME.Size = New System.Drawing.Size(169, 25)
        Me.TxtSNAME.TabIndex = 1
        '
        'LblSname
        '
        Me.LblSname.BackColor = System.Drawing.SystemColors.Control
        Me.LblSname.Cursor = System.Windows.Forms.Cursors.Default
        Me.LblSname.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LblSname.Location = New System.Drawing.Point(16, 19)
        Me.LblSname.Name = "LblSname"
        Me.LblSname.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LblSname.Size = New System.Drawing.Size(113, 82)
        Me.LblSname.TabIndex = 0
        Me.LblSname.Text = "検索氏名：　　（前方一致）"
        '
        'ListLookupName
        '
        Me.ListLookupName.FormattingEnabled = True
        Me.ListLookupName.ItemHeight = 18
        Me.ListLookupName.Location = New System.Drawing.Point(19, 83)
        Me.ListLookupName.Name = "ListLookupName"
        Me.ListLookupName.Size = New System.Drawing.Size(265, 94)
        Me.ListLookupName.TabIndex = 5
        '
        'DataSet1
        '
        Me.DataSet1.DataSetName = "DataSet1"
        Me.DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ADBKBindingSource
        '
        Me.ADBKBindingSource.DataMember = "ADBK"
        Me.ADBKBindingSource.DataSource = Me.DataSet1
        '
        'ADBKTableAdapter
        '
        Me.ADBKTableAdapter.ClearBeforeFill = True
        '
        'DataSet1BindingSource
        '
        Me.DataSet1BindingSource.DataSource = Me.DataSet1
        Me.DataSet1BindingSource.Position = 0
        '
        'FindByName
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(459, 349)
        Me.Controls.Add(Me.ListLookupName)
        Me.Controls.Add(Me.CmdFind)
        Me.Controls.Add(Me.CmdCancel)
        Me.Controls.Add(Me.CmdOK)
        Me.Controls.Add(Me.TxtSNAME)
        Me.Controls.Add(Me.LblSname)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Location = New System.Drawing.Point(4, 23)
        Me.Name = "FindByName"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Form2"
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ADBKBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ListLookupName As ListBox
    Friend WithEvents DataSet1 As DataSet1
    Friend WithEvents ADBKBindingSource As BindingSource
    Friend WithEvents ADBKTableAdapter As DataSet1TableAdapters.ADBKTableAdapter
    Friend WithEvents DataSet1BindingSource As BindingSource
#End Region
End Class