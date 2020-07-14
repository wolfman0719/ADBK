Option Strict Off
Option Explicit On
Imports InterSystems.Data.IRISClient
Imports InterSystems.Data.IRISClient.ADO
Imports Microsoft.VisualBasic.Compatibility.VB6

Friend Class ADBKMain
	Inherits System.Windows.Forms.Form
	Dim iris As IRIS
	Dim iris_object As IRISObject
	Dim iris_conn As IRISConnection = New IRISConnection
	'Dim m_factory As CacheObject.Factory
	'Dim m_object As CacheObject.ObjInstance
	'Const m_classname As String = "User.ADBK"
	Const iris_classname As String = "User.ADBK"
	Dim id As Object

	Private Sub CmdDelete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdDelete.Click
		Dim status As Short
		'UPGRADE_WARNING: �I�u�W�F�N�g id �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		id = lblAID.Text
		'UPGRADE_WARNING: �I�u�W�F�N�g id �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If id = "" Then
			MsgBox("���R�[�h���폜�ł��܂���(ID�Ȃ�)", MsgBoxStyle.Information)
			Exit Sub
		End If
		status = MsgBox("�{���ɍ폜���܂����H�@", MsgBoxStyle.YesNoCancel, "�Z���^�폜")
		If status = MsgBoxResult.Yes Then ' [�͂�] ���N���b�N���ꂽ�ꍇ�A
			'UPGRADE_WARNING: �I�u�W�F�N�g m_object.sys_DeleteId �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'm_object.sys_DeleteId(id)
			iris_object.Invoke("%DeleteId", id)
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
		'm_object = FindByName.ShowDialog_Renamed(m_factory)
		iris_object = FindByName.ShowDialog_Renamed(iris, iris_conn)
		'�V�K���͎��ȊO�́A���O�t�B�[���h�͕ύX�s�Ƃ���B
		TxtNAME.ReadOnly = True
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
		'�V�K�f�[�^�̏��������s��
		iris_object = iris.ClassMethodObject(iris_classname, "%New")
		If iris_object Is Nothing Then
			MsgBox("�V�����I�u�W�F�N�g���쐬�ł��܂���B")
		End If
		'm_object = m_factory.New(m_classname)
		'If m_object Is Nothing Then
		'MsgBox("�V�����I�u�W�F�N�g���쐬�ł��܂���B")
		'End If
	End Sub

	Private Sub CmdUpdate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdUpdate.Click
		Dim status As Object
		'UPGRADE_WARNING: �I�u�W�F�N�g status �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		status = MsgBox("�{���ɍX�V���܂����H�@", MsgBoxStyle.YesNoCancel, "�Z���^�X�V")
		If status = MsgBoxResult.Yes Then ' [�͂�] ���N���b�N���ꂽ�ꍇ�A
			'UPGRADE_WARNING: �I�u�W�F�N�g m_object.ANAME �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'm_object.ANAME = TxtNAME.Text
			iris_object.Set("ANAME", TxtNAME.Text)
			'UPGRADE_WARNING: �I�u�W�F�N�g m_object.ASTREET �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'm_object.ASTREET = TxtADDRESS.Text
			iris_object.Set("ASTREET", TxtADDRESS.Text)
			'UPGRADE_WARNING: �I�u�W�F�N�g m_object.AZIP �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'm_object.AZIP = TxtZIP.Text
			iris_object.Set("AZIP", TxtZIP.Text)
			'UPGRADE_WARNING: �I�u�W�F�N�g m_object.ABTHDAY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'm_object.ABTHDAY = TxtDOB.Text
			iris_object.Set("ABTHDAY", TxtDOB.Text)
			'UPGRADE_WARNING: �I�u�W�F�N�g m_object.APHHOME �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'm_object.APHHOME = TxtTELH.Text
			iris_object.Set("APHHOME", TxtTELH.Text)
			'UPGRADE_WARNING: �I�u�W�F�N�g m_object.APHOTH1 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'm_object.APHOTH1 = TxtTELO.Text
			iris_object.Set("APHWORK", TxtTELO.Text)
			On Error GoTo actionSaveError
			'UPGRADE_WARNING: �I�u�W�F�N�g m_object.sys_Save �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
		iris_conn.ConnectionString = "Server = localhost; Log File=cprovider.log;Port=51773; Namespace=USER; Password = SYS; User ID = _system;"
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