Option Strict Off
Option Explicit On
'�ȉ��̃C���|�[�g���K�v
Imports cdapp

Friend Class ADBKMain
	Inherits System.Windows.Forms.Form
	'Dim CacheDirect As New cVMClass
	Public WithEvents CacheDirect As cacheDirectWapper = New cacheDirectWapper("Server = localhost; Port=51773; Namespace=USER; Password = SYS; User ID = _system;")

	Private Sub CmdDelete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdDelete.Click
		Dim status As Short
		status = MsgBox("�{���ɍ폜���܂����H�@", MsgBoxStyle.YesNoCancel, "�Z���^�폜")
		If status = MsgBoxResult.Yes Then ' [�͂�] ���N���b�N���ꂽ�ꍇ�A
			CacheDirect.Execute("$$Kill^ADBK()")
			'���̓t�B�[���h���N���A
			TxtADDRESS.Text = ""
			TxtNAME.Text = ""
			TxtZIP.Text = ""
			TxtAGE.Text = ""
			TxtDOB.Text = ""
			TxtTELH.Text = ""
			TxtTELO.Text = ""
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
		FindByName.Show()
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
		CacheDirect.Execute("$$New^ADBK()")
	End Sub
	
	Private Sub CmdUpdate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdUpdate.Click
		Dim status As Object

		'UPGRADE_WARNING: �I�u�W�F�N�g status �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		status = MsgBox("�{���ɍX�V���܂����H�@", MsgBoxStyle.YesNoCancel, "�Z���^�X�V")
		If status = MsgBoxResult.Yes Then ' [�͂�] ���N���b�N���ꂽ�ꍇ�A
			'�X�V�ɕK�v�ȃf�[�^��PLIST�Ƀp�b�N����B
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
				MsgBox("Load�ŃG���[���������܂���" & CacheDirect.P2)

			End If
		End If
	End Sub

	Private Sub ADBKMain_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		'UPGRADE_NOTE: �I�u�W�F�N�g CacheDirect ���K�x�[�W �R���N�g����܂ł��̃I�u�W�F�N�g��j�����邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' ���N���b�N���Ă��������B
		'CacheDirect = Nothing
		CacheDirect.end()
	End Sub


	Private Sub CacheDirect_Executed(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CacheDirect.ExecuteEvent
		Dim status As Object

		If CacheDirect.P9 <> "" Then
			'		'UPGRADE_WARNING: �I�u�W�F�N�g status �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			status = MsgBox("�f�[�^�G���[�@" & CacheDirect.P9, MsgBoxStyle.OkOnly, "�f�[�^�G���[")
		End If
	End Sub

	'Private Sub VisM1_Executed(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles VisM1.Executed
	'Dim status As Object

	'If VisM1.P9 <> "" Then
	'		'UPGRADE_WARNING: �I�u�W�F�N�g status �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
	'		status = MsgBox("�f�[�^�G���[�@" & VisM1.P9, MsgBoxStyle.OKOnly, "�f�[�^�G���[")
	'End If
	'End Sub

	Private Sub CacheDirect_OnError(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CacheDirect.ErrorEvent
		Dim status As Object
		'	'UPGRADE_WARNING: �I�u�W�F�N�g status �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		status = MsgBox("Cache'�@Direct�@Error�@" & CacheDirect.ErrorName, MsgBoxStyle.OkOnly, "Cache'�@Direct�@Error")
		''�G���[�������������_�ł̃��[�J���ϐ����_���v����
		'CacheDirect.PrintLocalVariable()
		MsgBox("�G���[���������܂���" & CacheDirect.ErrorName, MsgBoxStyle.OkOnly)
	End Sub

	'Private Sub VisM1_OnError(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles VisM1.OnError
	'Dim status As Object
	'	'UPGRADE_WARNING: �I�u�W�F�N�g status �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
	'	status = MsgBox("Cache'�@Direct�@Error�@" & VisM1.ErrorName, MsgBoxStyle.OKOnly, "Cache'�@Direct�@Error")
	''�G���[�������������_�ł̃��[�J���ϐ����_���v����
	'CacheDirect.PrintLocalVariable()
	'End Sub
End Class