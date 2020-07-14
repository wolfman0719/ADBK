Option Strict Off
Option Explicit On
Friend Class ADBKMain
	Inherits System.Windows.Forms.Form
	Dim m_factory As CacheObject.Factory
	Dim m_object As CacheObject.ObjInstance
	Const m_classname As String = "User.ADBK"
	Dim id As Object
	
	Private Sub CmdDelete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdDelete.Click
		Dim status As Short
		'UPGRADE_WARNING: オブジェクト id の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		id = lblAID.Text
		'UPGRADE_WARNING: オブジェクト id の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If id = "" Then
			MsgBox("レコードを削除できません(IDなし)", MsgBoxStyle.Information)
			Exit Sub
		End If
		status = MsgBox("本当に削除しますか？　", MsgBoxStyle.YesNoCancel, "住所録削除")
		If status = MsgBoxResult.Yes Then ' [はい] がクリックされた場合、
			'UPGRADE_WARNING: オブジェクト m_object.sys_DeleteId の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			m_object.sys_DeleteId(id)
		End If
		'検索結果をクリアする
		'UPGRADE_WARNING: オブジェクト FindByName!ListLookupName.Clear の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CType(FindByName.Controls("ListLookupName"), Object).Clear()
	End Sub
	
	Private Sub CmdEnd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdEnd.Click
		Me.Close()
		End
	End Sub
	
	Private Sub CmdFind_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdFind.Click
		'FindByName!ListLookupName.Clear
		'検索フォームを表示する
		m_object = FindByName.ShowDialog_Renamed(m_factory)
		'新規入力時以外は、名前フィールドは変更不可とする。
		TxtNAME.ReadOnly = True
	End Sub
	
	Private Sub CmdNew_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdNew.Click
		'名前フィールドを変更可能に戻す
		TxtNAME.ReadOnly = False
		'入力フィールドをクリア
		TxtADDRESS.Text = ""
		TxtNAME.Text = ""
		TxtZIP.Text = ""
		TxtAGE.Text = ""
		TxtDOB.Text = ""
		TxtTELH.Text = ""
		TxtTELO.Text = ""
		'新規データの初期化を行う
		m_object = m_factory.New(m_classname)
		If m_object Is Nothing Then
			MsgBox("新しいオブジェクトを作成できません。")
		End If
	End Sub
	
	Private Sub CmdUpdate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdUpdate.Click
		Dim status As Object
		'UPGRADE_WARNING: オブジェクト status の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		status = MsgBox("本当に更新しますか？　", MsgBoxStyle.YesNoCancel, "住所録更新")
		If status = MsgBoxResult.Yes Then ' [はい] がクリックされた場合、
			'UPGRADE_WARNING: オブジェクト m_object.ANAME の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			m_object.ANAME = TxtNAME.Text
			'UPGRADE_WARNING: オブジェクト m_object.ASTREET の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			m_object.ASTREET = TxtADDRESS.Text
			'UPGRADE_WARNING: オブジェクト m_object.AZIP の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			m_object.AZIP = TxtZIP.Text
			'UPGRADE_WARNING: オブジェクト m_object.ABTHDAY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			m_object.ABTHDAY = TxtDOB.Text
			'UPGRADE_WARNING: オブジェクト m_object.APHHOME の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			m_object.APHHOME = TxtTELH.Text
			'UPGRADE_WARNING: オブジェクト m_object.APHOTH1 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			m_object.APHOTH1 = TxtTELO.Text
			On Error GoTo actionSaveError
			'UPGRADE_WARNING: オブジェクト m_object.sys_Save の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			m_object.sys_Save()
			Exit Sub
actionSaveError: 
			MsgBox(Err.Description)
		End If
	End Sub
	
	Private Sub ADBKMain_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Dim sdir As String
		m_factory = CreateObject("CacheObject.Factory")
		sdir = m_factory.ConnectDlg
		If sdir <> "" Then
			m_factory.Connect(sdir)
		Else
			End
		End If
	End Sub
End Class