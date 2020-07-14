Option Strict Off
Option Explicit On
Imports InterSystems.Data.IRISClient
Imports InterSystems.Data.IRISClient.ADO

Friend Class ADBKMain
	Inherits System.Windows.Forms.Form
	'Dim cnn1 As New ADODB.Connection
	'Dim rs As New ADODB.Recordset
	Dim iris_conn As IRISConnection = New IRISConnection
	Dim Reader As IRISDataReader
	Dim id As Object
	Dim newflag As Boolean
	Dim DataSet As System.Data.DataSet


	Private Sub CmdDelete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdDelete.Click
		Dim status As Short
		'UPGRADE_NOTE: command �� command_Renamed �ɃA�b�v�O���[�h����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"' ���N���b�N���Ă��������B
		'Dim command_Renamed As String
		'UPGRADE_WARNING: �I�u�W�F�N�g id �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		id = lblAID.Text
		'UPGRADE_WARNING: �I�u�W�F�N�g id �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If id = "" Then
			MsgBox("���R�[�h���폜�ł��܂���(ID�Ȃ�)", MsgBoxStyle.Information)
			Exit Sub
		End If
		status = MsgBox("�{���ɍ폜���܂����H�@", MsgBoxStyle.YesNoCancel, "�Z���^�폜")
		If status = MsgBoxResult.Yes Then ' [�͂�] ���N���b�N���ꂽ�ꍇ�A
			'command = "delete from adbk where aid = " + lblAID.Caption
			'cnn1.Execute command
			'rs.Delete()
			Dim SQLtext As String = "delete from adbk where aid = ?"
			Dim Command As IRISCommand = New IRISCommand(SQLtext, iris_conn)
			Dim Id_param As IRISParameter = New IRISParameter("Id_col", IRISDbType.NVarChar)
			Id_param.Value = lblAID.Text
			Command.Parameters.Add(Id_param)
			Dim affected_record As Integer = Command.ExecuteNonQuery()


			'���̓t�B�[���h���N���A
			TxtADDRESS.Text = ""
			TxtNAME.Text = ""
			TxtZIP.Text = ""
			TxtAGE.Text = ""
			TxtDOB.Text = ""
			TxtTELH.Text = ""
			TxtTELO.Text = ""
			lblAID.Text = ""
		End If
		'�������ʂ��N���A����
		CType(FindByName.Controls("ListLookupName"), Object).Items.Clear()
	End Sub
	
	Private Sub CmdEnd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdEnd.Click
		Me.Close()
		End
	End Sub
	
	Private Sub CmdFind_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdFind.Click
		CType(FindByName.Controls("ListLookupName"), Object).Items.Clear()
		'�����t�H�[����\������
		'rs = FindByName.ShowDialog_Renamed(cnn1)
		DataSet = FindByName.ShowDialog_Renamed(iris_conn)
		'�V�K���͎��ȊO�́A���O�t�B�[���h�͕ύX�s�Ƃ���B
		TxtNAME.ReadOnly = True
		newflag = False
	End Sub
	
	Private Sub CmdNew_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdNew.Click
		'���O�t�B�[���h��ύX�\�ɖ߂�
		TxtNAME.ReadOnly = False
		'���̓t�B�[���h���N���A
		TxtADDRESS.Text = ""
		TxtNAME.Text = ""
		TxtZIP.Text = ""
		TxtAGE.Text = ""
		TxtDOB.Text = ""
		TxtTELH.Text = ""
		TxtTELO.Text = ""
		newflag = True
		'UPGRADE_NOTE: �I�u�W�F�N�g rs ���K�x�[�W �R���N�g����܂ł��̃I�u�W�F�N�g��j�����邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' ���N���b�N���Ă��������B
		'rs = Nothing
		'rs.Open("SELECT * FROM ADBK WHERE ANAME = 'zzz'", cnn1,  , ADODB.LockTypeEnum.adLockPessimistic)
		Dim SQLtext As String = "SELECT * FROM ADBK WHERE ANAME = ?"
		Dim Command As IRISCommand = New IRISCommand(SQLtext, iris_conn)
		Dim Name_param As IRISParameter = New IRISParameter("Name_col", IRISDbType.NVarChar)
		Name_param.Value = "zzz"
		Command.Parameters.Add(Name_param)
		Dim Reader As IRISDataReader = Command.ExecuteReader()
		Reader.Read()

	End Sub

	Private Sub CmdUpdate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdUpdate.Click

		Dim status As Object
		Dim SQLtext As String
		Dim Command As IRISCommand
		Dim Street_param As IRISParameter
		Dim Name_param As IRISParameter
		Dim Zip_param As IRISParameter
		Dim DOB_param As IRISParameter
		Dim Telh_param As IRISParameter
		Dim Telo_param As IRISParameter
		Dim Id_Param As IRISParameter
		Dim affected_records As Integer

		'UPGRADE_NOTE: command �� command_Renamed �ɃA�b�v�O���[�h����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"' ���N���b�N���Ă��������B
		'Dim command_Renamed As String
		'UPGRADE_WARNING: �I�u�W�F�N�g status �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		status = MsgBox("�{���ɍX�V���܂����H�@", MsgBoxStyle.YesNoCancel, "�Z���^�X�V")
		If status = MsgBoxResult.Yes Then ' [�͂�] ���N���b�N���ꂽ�ꍇ�A
			If newflag = True Then '�V�K�쐬
				'Set rs = Nothing
				'command = "INSERT INTO ADBK (ANAME,ASTREET,AZIP,ABTHDAY,APHHOME,APHOTH1)"
				'command = command + " VALUES('" + TxtNAME.Text + "','" + TxtADDRESS.Text + "','"
				'command = command + TxtZIP.Text + "','" + Format(TxtDOB.Text, "YYYY-MM-DD") + "','"
				'command = command + TxtTELH.Text + "','" + TxtTELO.Text
				On Error GoTo actionSaveError
				SQLtext = "INSERT INTO ADBK (ANAME,ASTREET,AZIP,ABTHDAY,APHHOME,APHWORK) VALUES(?,?,?,TO_DATE(?,'YYYY-MM-DD'),?,?)"
				Name_param = New IRISParameter("Name_col", IRISDbType.NVarChar)
				Name_param.Value = TxtNAME.Text
				Command = New IRISCommand(SQLtext, iris_conn)
				Command.Parameters.Add(Name_param)
				Street_param = New IRISParameter("Street_col", IRISDbType.NVarChar)
				Street_param.Value = TxtADDRESS.Text
				Command.Parameters.Add(Street_param)
				Zip_param = New IRISParameter("Zip_col", IRISDbType.NVarChar)
				Zip_param.Value = TxtZIP.Text
				Command.Parameters.Add(Zip_param)
				DOB_param = New IRISParameter("Dob_col", IRISDbType.NVarChar)
				DOB_param.Value = TxtDOB.Text
				Command.Parameters.Add(DOB_param)
				Telh_param = New IRISParameter("Telh_col", IRISDbType.NVarChar)
				Telh_param.Value = TxtTELH.Text
				Command.Parameters.Add(Telh_param)
				Telo_param = New IRISParameter("Telo_col", IRISDbType.NVarChar)
				Telo_param.Value = TxtTELO.Text
				Command.Parameters.Add(Telo_param)
				affected_records = Command.ExecuteNonQuery()
				'cnn1.Execute command
				'rs.AddNew()
				'rs.Fields("ASTREET").Value = TxtADDRESS.Text
				'rs.Fields("AZIP").Value = TxtZIP.Text
				'rs.Fields("ABTHDAY").Value = TxtDOB.Text
				'rs.Fields("APHHOME").Value = TxtTELH.Text
				'rs.Fields("APHOTH1").Value = TxtTELO.Text
				'rs.Fields("ANAME").Value = TxtNAME.Text
			Else
				'command = "UPDATE ADBK SET ASTREET = '" + TxtADDRESS.Text + "', AZIP = '" + TxtZIP.Text
				'command = command + "', ABTHDAY = '" + Format(TxtDOB.Text, "YYYY-MM-DD") + "' , APHHOME = '" + TxtTELH.Text
				'command = command + "', APHHOME = '" + TxtTELH.Text + "' WHERE AID = " + lblAID.Caption
				'cnn1.Execute command
				SQLtext = "UPDATE ADBK SET ASTREET = ?, AZIP = ?, ABTHDAY = TO_DATE(?,'YYYY-MM-DD'), APHHOME = ?, APHWORK = ? WHERE AID = ?"
				Command = New IRISCommand(SQLtext, iris_conn)
				Street_param = New IRISParameter("Street_col", IRISDbType.NVarChar)
				Street_param.Value = TxtADDRESS.Text
				Command.Parameters.Add(Street_param)
				Zip_param = New IRISParameter("Zip_col", IRISDbType.NVarChar)
				Zip_param.Value = TxtZIP.Text
				Command.Parameters.Add(Zip_param)
				DOB_param = New IRISParameter("Dob_col", IRISDbType.NVarChar)
				DOB_param.Value = TxtDOB.Text
				Command.Parameters.Add(DOB_param)
				Telh_param = New IRISParameter("Telh_col", IRISDbType.NVarChar)
				Telh_param.Value = TxtTELH.Text
				Command.Parameters.Add(Telh_param)
				Telo_param = New IRISParameter("Telo_col", IRISDbType.NVarChar)
				Telo_param.Value = TxtTELO.Text
				Command.Parameters.Add(Telo_param)
				Id_param = New IRISParameter("Id_col", IRISDbType.NVarChar)
				Id_param.Value = lblAID.Text
				Command.Parameters.Add(Id_Param)
				affected_records = Command.ExecuteNonQuery()
				'rs.Fields("ASTREET").Value = TxtADDRESS.Text
				'rs.Fields("AZIP").Value = TxtZIP.Text
				'rs.Fields("ABTHDAY").Value = TxtDOB.Text
				'rs.Fields("APHHOME").Value = TxtTELH.Text
				'rs.Fields("APHOTH1").Value = TxtTELO.Text
			End If
			On Error GoTo actionSaveError
			'rs.Update()
			Exit Sub
actionSaveError:
			MsgBox("�f�[�^�`���G���[ " & Err.Description)
		End If
	End Sub

	Private Sub ADBKMain_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		'cnn1.ConnectionString = "DSN=CacheISJSAMPLES;UID=_system;PWD=sys"
		'cnn1.Open()
		iris_conn.ConnectionString = "Server = localhost; Log File=cprovider.log;Port=51773; Namespace=USER; Password = SYS; User ID = _system;"
		iris_conn.Open()
	End Sub
	
	Private Sub ADBKMain_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		'UPGRADE_NOTE: �I�u�W�F�N�g rs ���K�x�[�W �R���N�g����܂ł��̃I�u�W�F�N�g��j�����邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' ���N���b�N���Ă��������B
		'rs = Nothing
		'cnn1.Close()
		iris_conn.Close()
	End Sub

End Class