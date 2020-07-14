Option Strict Off
Option Explicit On
Friend Class FindByName
	Inherits System.Windows.Forms.Form
	Dim CacheDirect As New cVMClass
	
	Private Sub CmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdCancel.Click
		
		Me.Hide()
		
	End Sub
	
	Private Sub CmdFind_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdFind.Click
		
		Dim i As Object
		Dim NOL As Short
		Dim Node As String
		
		' ���O�̃��X�g���擾
		ListLookupName.Items.Clear()
		CacheDirect.Clear()
		CacheDirect.PDELIM = Chr(1)
		Node = ""
		CacheDirect.P0 = "^ADBK(""XNAME"")"
		CacheDirect.P1 = TxtSNAME.Text
		CacheDirect.Execute("Do GetList^ADBK(P0,P1,P1,""�@"")")
		If CDbl(CacheDirect.Error_Renamed) <> 0 Then
			'     MsgBox (" Error " & CacheDirect.ErrorName)
			Exit Sub
		End If
		
		'�@�擾�������O���X�g��ListBox�ɓW�J
		For i = 1 To CacheDirect.NoOfPLISTItem
			'UPGRADE_WARNING: �I�u�W�F�N�g i �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			ListLookupName.Items.Add(CacheDirect.PLISTItem(i))
		Next i
		
	End Sub
	
	Private Sub CmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdOK.Click
		
		CacheDirect.Clear()
		CacheDirect.P0 = VB6.GetItemString(ListLookupName, ListLookupName.SelectedIndex)
		'�I������Ă��閼�O�ɑΉ�����f�[�^����������B
		CacheDirect.Execute(("Do GetData^ADBK(P0)"))
		If CDbl(CacheDirect.Error_Renamed) <> 0 Then
			Exit Sub
		End If
		'�����t�H�[�����\��
		Me.Hide()
		'�擾�f�[�^���t�H�[���t�B�[���h�ɓW�J����
		CType(ADBKMain.Controls("TxtNAME"), Object).Text = CacheDirect.MPiece(CacheDirect.P1, Chr(2), 1)
		CType(ADBKMain.Controls("TxtZIP"), Object).Text = CacheDirect.MPiece(CacheDirect.P1, Chr(2), 2)
		CType(ADBKMain.Controls("TxtADDRESS"), Object).Text = CacheDirect.MPiece(CacheDirect.P1, Chr(2), 3)
		CType(ADBKMain.Controls("TxtTELH"), Object).Text = CacheDirect.MPiece(CacheDirect.P1, Chr(2), 4)
		CType(ADBKMain.Controls("TxtTELO"), Object).Text = CacheDirect.MPiece(CacheDirect.P1, Chr(2), 5)
		CType(ADBKMain.Controls("TxtAGE"), Object).Text = CacheDirect.MPiece(CacheDirect.P1, Chr(2), 6)
		CType(ADBKMain.Controls("TxtDOB"), Object).Text = CacheDirect.MPiece(CacheDirect.P1, Chr(2), 7)
		
	End Sub
	
	Private Sub FindByName_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		CacheDirect.VisM = CType(ADBKMain.Controls("VisM1"), Object)
	End Sub
	
	Private Sub FindByName_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		'UPGRADE_NOTE: �I�u�W�F�N�g CacheDirect ���K�x�[�W �R���N�g����܂ł��̃I�u�W�F�N�g��j�����邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' ���N���b�N���Ă��������B
		CacheDirect = Nothing
	End Sub
End Class