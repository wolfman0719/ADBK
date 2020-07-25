Option Strict Off
Option Explicit On
Imports InterSystems.Data.IRISClient
Imports InterSystems.Data.IRISClient.ADO

Friend Class ADBKMain
	Inherits System.Windows.Forms.Form
	'Dim m_factory As CacheObject.Factory
	Dim iris As IRIS
	Dim iris_object As IRISObject
	Dim iris_conn As IRISConnection = New IRISConnection
	'Const m_classname As String = "User.ADBK"
	Const iris_classname As String = "User.ADBK"
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
			'm_object.sys_DeleteId(id)
			iris_object.Invoke("%DeleteId", id)

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
		'm_object = FindByName.ShowDialog_Renamed(m_factory)
		iris_object = FindByName.ShowDialog_Renamed(iris, iris_conn)
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
		'm_object = m_factory.New(m_classname)
		iris_object = iris.ClassMethodObject(iris_classname, "%New")
		'If m_object Is Nothing Then
		If iris_object Is Nothing Then

				MsgBox("新しいオブジェクトを作成できません。")
			End If
    End Sub
	
	Private Sub CmdUpdate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdUpdate.Click
		Dim status As Object
		'UPGRADE_WARNING: オブジェクト status の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		status = MsgBox("本当に更新しますか？　", MsgBoxStyle.YesNoCancel, "住所録更新")
		If status = MsgBoxResult.Yes Then ' [はい] がクリックされた場合、
			'UPGRADE_WARNING: オブジェクト m_object.ANAME の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'm_object.ANAME = TxtNAME.Text
			iris_object.Set("ANAME", TxtNAME.Text)
			'UPGRADE_WARNING: オブジェクト m_object.ASTREET の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'm_object.ASTREET = TxtADDRESS.Text
			iris_object.Set("ASTREET", TxtADDRESS.Text)
			'UPGRADE_WARNING: オブジェクト m_object.AZIP の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'm_object.AZIP = TxtZIP.Text
			iris_object.Set("AZIP", TxtZIP.Text)
			'UPGRADE_WARNING: オブジェクト m_object.ABTHDAY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'm_object.ABTHDAY = TxtDOB.Text
			iris_object.Set("ABTHDAY", TxtDOB.Text)
			'UPGRADE_WARNING: オブジェクト m_object.APHHOME の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'm_object.APHHOME = TxtTELH.Text
			iris_object.Set("APHHOME", TxtTELH.Text)
			'UPGRADE_WARNING: オブジェクト m_object.APHOTH1 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'm_object.APHOTH1 = TxtTELO.Text
			iris_object.Set("APHOTH1", TxtTELO.Text)
			On Error GoTo actionSaveError
			'UPGRADE_WARNING: オブジェクト m_object.sys_Save の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'm_object.sys_Save()
			iris_object.Invoke("%Save")
			Exit Sub
actionSaveError: 
			MsgBox(Err.Description)
		End If
	End Sub
	
	Private Sub ADBKMain_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		'Dim sdir As String
		'm_factory = CreateObject("CacheObject.Factory")
		Dim consetup As New setup()
		consetup.LoadSetupFile("..\connectioninfo.json")

		iris_conn.ConnectionString = "Server = " + consetup.co.hostname + "; Port=" + consetup.co.port.ToString() + "; Namespace=" + consetup.co.irisnamespace + "; Password = " + consetup.co.password + "; User ID = " + consetup.co.username + ";"
		iris_conn.Open()
		iris = IRIS.CreateIRIS(iris_conn)
		'sdir = m_factory.ConnectDlg
		'If sdir <> "" Then
		'm_factory.Connect(sdir)
		'Else
		'End
		'End If
	End Sub
End Class