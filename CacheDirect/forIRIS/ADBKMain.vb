Option Strict Off
Option Explicit On
'以下のインポートが必要
Imports cdapp

Friend Class ADBKMain
	Inherits System.Windows.Forms.Form
	'Dim CacheDirect As New cVMClass
	Public WithEvents CacheDirect As cacheDirectWapper = New cacheDirectWapper("Server = localhost; Port=51773; Namespace=USER; Password = SYS; User ID = _system;")

	Private Sub CmdDelete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdDelete.Click
		Dim status As Short
		status = MsgBox("本当に削除しますか？　", MsgBoxStyle.YesNoCancel, "住所録削除")
		If status = MsgBoxResult.Yes Then ' [はい] がクリックされた場合、
			CacheDirect.Execute("$$Kill^ADBK()")
			'入力フィールドをクリア
			TxtADDRESS.Text = ""
			TxtNAME.Text = ""
			TxtZIP.Text = ""
			TxtAGE.Text = ""
			TxtDOB.Text = ""
			TxtTELH.Text = ""
			TxtTELO.Text = ""
		End If
		'検索結果をクリアする
		CType(FindByName.Controls("ListLookupName"), Object).Items.Clear()
	End Sub
	
	Private Sub CmdEnd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdEnd.Click
		Me.Close()
		End
	End Sub
	
	Private Sub CmdFind_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdFind.Click
		CType(FindByName.Controls("ListLookupName"), Object).Items.Clear()
		'検索フォームを表示する
		FindByName.Show()
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
		CacheDirect.Execute("$$New^ADBK()")
	End Sub
	
	Private Sub CmdUpdate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdUpdate.Click
		Dim status As Object

		'UPGRADE_WARNING: オブジェクト status の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		status = MsgBox("本当に更新しますか？　", MsgBoxStyle.YesNoCancel, "住所録更新")
		If status = MsgBoxResult.Yes Then ' [はい] がクリックされた場合、
			'更新に必要なデータをPLISTにパックする。
			CacheDirect.P0 = TxtNAME.Text & Chr(1) & TxtADDRESS.Text & Chr(1) & TxtZIP.Text
			CacheDirect.P0 = CacheDirect.P0 & Chr(1) & TxtAGE.Text & Chr(1) & TxtDOB.Text
			CacheDirect.P0 = CacheDirect.P0 & Chr(1) & TxtTELH.Text & Chr(1) & TxtTELO.Text
			CacheDirect.Execute("$$Update^ADBK(P0)")
		End If
	End Sub

	Private Sub ADBKMain_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

		'CacheDirect.VisM = VisM1.GetOcx

		'If Not Install("Address Book Demo Application", VisM1, "GLO", "^ADBK", "USER", "+'$D(^$ROUTINE(""ADBK""))", "adbk.gsa", "MAC", "ADBK", "USER", "+'$D(^$ROUTINE(""ADBK""))", "adbk.rsa") Then End
		CacheDirect.Execute("=$DATA(^$ROUTINE(""ADBK""))")
		If CacheDirect.VALUE = 0 Then
			CacheDirect.P0 = "c:\temp"
			CacheDirect.P1 = "ck-d"
			CacheDirect.Execute("set P2=$system.OBJ.ImportDir(P0,,P1,.P2)")
			If CacheDirect.P2.Substring(0, 1) <> 1 Then
				MsgBox("Loadでエラーが発生しました" & CacheDirect.P2)

			End If
		End If
	End Sub

	Private Sub ADBKMain_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		'UPGRADE_NOTE: オブジェクト CacheDirect をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
		'CacheDirect = Nothing
		CacheDirect.end()
	End Sub


	Private Sub CacheDirect_Executed(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CacheDirect.ExecuteEvent
		Dim status As Object

		If CacheDirect.P9 <> "" Then
			'		'UPGRADE_WARNING: オブジェクト status の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			status = MsgBox("データエラー　" & CacheDirect.P9, MsgBoxStyle.OkOnly, "データエラー")
		End If
	End Sub

	'Private Sub VisM1_Executed(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles VisM1.Executed
	'Dim status As Object

	'If VisM1.P9 <> "" Then
	'		'UPGRADE_WARNING: オブジェクト status の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
	'		status = MsgBox("データエラー　" & VisM1.P9, MsgBoxStyle.OKOnly, "データエラー")
	'End If
	'End Sub

	Private Sub CacheDirect_OnError(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CacheDirect.ErrorEvent
		Dim status As Object
		'	'UPGRADE_WARNING: オブジェクト status の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		status = MsgBox("Cache'　Direct　Error　" & CacheDirect.ErrorName, MsgBoxStyle.OkOnly, "Cache'　Direct　Error")
		''エラーが発生した時点でのローカル変数をダンプする
		'CacheDirect.PrintLocalVariable()
		MsgBox("エラーが発生しました" & CacheDirect.ErrorName, MsgBoxStyle.OkOnly)
	End Sub

	'Private Sub VisM1_OnError(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles VisM1.OnError
	'Dim status As Object
	'	'UPGRADE_WARNING: オブジェクト status の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
	'	status = MsgBox("Cache'　Direct　Error　" & VisM1.ErrorName, MsgBoxStyle.OKOnly, "Cache'　Direct　Error")
	''エラーが発生した時点でのローカル変数をダンプする
	'CacheDirect.PrintLocalVariable()
	'End Sub
End Class