Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class cVMClass
	' VMCLASS.cls   CacheDirect�T�[�o�A�N�Z�X�N���X
	' By T.Imai 97/9/1
	'           98/2/3  Wait method �ǉ�
	'           98/2/22 MServer property �ǉ�
	' H.S     1998/7/17 PrintLocalVariable
	'���p�@
	'
	'   General declarations ��
	'       Dim CacheDirect As New cVMClass
	'
	'   Form_Load �C�x���g��
	'       Set CacheDirect.VisM = Vism1
	'
	'   Form_Unload �C�x���g��
	'       Set CacheDirect = Nothing
	'
	'   Method
	'       Cache �֐�($... �܂��� ��...�j���s��
	'           CacheDirect.Eval(Code) �܂��� CacheDirect.Evaluate(Code)
	'               Function Call(�A��l����j
	'
	'       M �R�}���h����s��
	'           CacheDirect.Exe(code) �܂��� CacheDirect.Execute(Code)
	'               Subroutine Call
	'       CacheDirect.Clear   P0,P1,P2,...,PLIST clear
	'       CacheDirect.DebugPrint  P0,P1,P2,...,PLIST Debug window �֕\��
	'       CacheDirect.TimerStart CacheDirect.TimerStop M,TimerContinue
	'       CacheDirect.Wait
	'       CacheDirect.PLISTItem(i)
	'       CacheDirect.Piece(string,substr,pos1,pos2)
	'
	'   Property
	'       CacheDirect.NameSpace
	'       CacheDirect.PDELIM
	'       CacheDirect.Value
	'       CacheDirect.P0,CacheDirect.P1,CacheDirect.P2,...,CacheDirect.P9
	'       CacheDirect.PLIST
	'       CacheDirect.Error
	'       CacheDirect.ErrorName
	'       CacheDirect.MouseIcon
	'       CacheDirect.NoOfPLISTItem
	'
	'
	'   ��
	'
	'   On Error Resume Next
	'   txtValue.Text = CacheDirect.Eval(txtEval.Text)
	'   If Err <> 0 Then
	'        ErrMsgBox
	'   End If
	'
	'
	'
	'
	
	Private m_Value, m_Name, m_Code, m_Error As Object
	Private m_ErrorName As String
	Private m_VisM As System.Windows.Forms.Control
	Private m_MouseIcon As Object
	Private m_MousePointer As Short
	Private m_ElapseTime, m_StartTime As Object
	Private m_EndTime As Double
	
	Public Sub Clear()
		
		' VisM �f�[�^�]���p�v���p�e�B�̏�����
		
		'UPGRADE_WARNING: �I�u�W�F�N�g m_VisM.P0 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		m_VisM.P0 = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g m_VisM.P1 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		m_VisM.P1 = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g m_VisM.P2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		m_VisM.P2 = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g m_VisM.P3 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		m_VisM.P3 = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g m_VisM.P4 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		m_VisM.P4 = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g m_VisM.P5 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		m_VisM.P5 = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g m_VisM.P6 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		m_VisM.P6 = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g m_VisM.P7 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		m_VisM.P7 = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g m_VisM.P8 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		m_VisM.P8 = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g m_VisM.P9 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		m_VisM.P9 = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g m_VisM.PLIST �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		m_VisM.PLIST = ""
		
	End Sub
	
	
	Public Sub DebugPrint()
		
		'UPGRADE_WARNING: �I�u�W�F�N�g m_VisM.Namespace �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Debug.Print("NameSpace=" & m_VisM.Namespace)
		'UPGRADE_WARNING: �I�u�W�F�N�g m_VisM.MServer �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Debug.Print("MServer=" & m_VisM.MServer)
		'UPGRADE_WARNING: �I�u�W�F�N�g m_VisM.Code �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Debug.Print("Code=" & m_VisM.Code)
		'UPGRADE_WARNING: �I�u�W�F�N�g m_VisM.Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Debug.Print("Value=" & m_VisM.Value)
		'UPGRADE_WARNING: �I�u�W�F�N�g m_VisM.Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Debug.Print("Error=" & m_VisM.Error)
		'UPGRADE_WARNING: �I�u�W�F�N�g m_VisM.ErrorName �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Debug.Print("ErrorName=" & m_VisM.ErrorName)
		'UPGRADE_WARNING: �I�u�W�F�N�g m_VisM.P0 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Debug.Print("P0=" & m_VisM.P0)
		'UPGRADE_WARNING: �I�u�W�F�N�g m_VisM.P1 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Debug.Print("P1=" & m_VisM.P1)
		'UPGRADE_WARNING: �I�u�W�F�N�g m_VisM.P2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Debug.Print("P2=" & m_VisM.P2)
		'UPGRADE_WARNING: �I�u�W�F�N�g m_VisM.P3 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Debug.Print("P3=" & m_VisM.P3)
		'UPGRADE_WARNING: �I�u�W�F�N�g m_VisM.P4 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Debug.Print("P4=" & m_VisM.P4)
		'UPGRADE_WARNING: �I�u�W�F�N�g m_VisM.P5 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Debug.Print("P5=" & m_VisM.P5)
		'UPGRADE_WARNING: �I�u�W�F�N�g m_VisM.P6 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Debug.Print("P6=" & m_VisM.P6)
		'UPGRADE_WARNING: �I�u�W�F�N�g m_VisM.P7 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Debug.Print("P7=" & m_VisM.P7)
		'UPGRADE_WARNING: �I�u�W�F�N�g m_VisM.P8 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Debug.Print("P8=" & m_VisM.P8)
		'UPGRADE_WARNING: �I�u�W�F�N�g m_VisM.P9 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Debug.Print("P9=" & m_VisM.P9)
		'UPGRADE_WARNING: �I�u�W�F�N�g m_VisM.PDELIM �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Debug.Print("PDELIM=" & m_VisM.PDELIM)
		'UPGRADE_WARNING: �I�u�W�F�N�g m_VisM.PLIST �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Debug.Print("PLIST=" & m_VisM.PLIST)
		
	End Sub
	
	Public Sub PrintLocalVariable()
		
		'�@�T�[�o�ŕێ����Ă��郍�[�J���ϐ���\������
		
		Dim i As Short
		Dim Pieceno As Short
		
		'UPGRADE_WARNING: �I�u�W�F�N�g m_VisM.PDELIM �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		m_VisM.PDELIM = Chr(1)
		'UPGRADE_WARNING: �I�u�W�F�N�g m_VisM.Execute �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		m_VisM.Execute("$$GetLocal^VISMUTIL(1)")
		'UPGRADE_WARNING: �I�u�W�F�N�g m_VisM.PDELIM �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g m_VisM.PLIST �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Pieceno = length(m_VisM.PLIST, m_VisM.PDELIM)
		For i = 1 To Pieceno
			'UPGRADE_WARNING: �I�u�W�F�N�g m_VisM.PDELIM �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g m_VisM.PLIST �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Debug.Print(Piece(m_VisM.PLIST, m_VisM.PDELIM, i, i))
		Next i
		
	End Sub
	
	Public WriteOnly Property MouseIcon() As Object
		Set(ByVal Value As Object)
			
			'UPGRADE_ISSUE: Screen �v���p�e�B Screen.MouseIcon �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g N �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Screen.MouseIcon = Value
			m_MousePointer = 99 'ccCoustom
			
		End Set
	End Property
	
	
	Public Property MousePointer() As Short
		Get
			
			MousePointer = m_MousePointer
			
		End Get
		Set(ByVal Value As Short)
			
			m_MousePointer = Value
			
		End Set
	End Property
	
	
	'UPGRADE_NOTE: Namespace �� Namespace_Renamed �ɃA�b�v�O���[�h����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"' ���N���b�N���Ă��������B
	Public Property Namespace_Renamed() As String
		Get
			
			'UPGRADE_WARNING: �I�u�W�F�N�g m_VisM.Namespace �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Namespace_Renamed = m_VisM.Namespace
			
		End Get
		Set(ByVal Value As String)
			
			'UPGRADE_WARNING: �I�u�W�F�N�g m_VisM.Namespace �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			m_VisM.Namespace = Value
			
		End Set
	End Property
	
	Public ReadOnly Property ErrorName() As String
		Get
			
			'UPGRADE_WARNING: �I�u�W�F�N�g m_VisM.ErrorName �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			ErrorName = m_VisM.ErrorName
			
		End Get
	End Property
	
	Public ReadOnly Property NoOfPLISTItem() As Short
		Get
			
			'PLIST�̍��ڐ���Ԃ��B
			
			'UPGRADE_WARNING: �I�u�W�F�N�g m_VisM.PDELIM �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g m_VisM.PLIST �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			NoOfPLISTItem = length(m_VisM.PLIST, m_VisM.PDELIM)
			
		End Get
	End Property
	
	'UPGRADE_NOTE: Error �� Error_Renamed �ɃA�b�v�O���[�h����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"' ���N���b�N���Ă��������B
	Public ReadOnly Property Error_Renamed() As String
		Get
			
			'UPGRADE_WARNING: �I�u�W�F�N�g m_VisM.Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Error_Renamed = m_VisM.Error
			
		End Get
	End Property
	
	
	Public Property MServer() As String
		Get
			
			'UPGRADE_WARNING: �I�u�W�F�N�g m_VisM.MServer �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			MServer = m_VisM.MServer
			
		End Get
		Set(ByVal Value As String)
			
			'UPGRADE_WARNING: �I�u�W�F�N�g m_VisM.MServer �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			m_VisM.MServer = Value
			
		End Set
	End Property
	
	Public WriteOnly Property PDELIM() As String
		Set(ByVal Value As String)
			
			'UPGRADE_WARNING: �I�u�W�F�N�g m_VisM.PDELIM �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			m_VisM.PDELIM = Value
			
		End Set
	End Property
	
	Public ReadOnly Property ElapseTime() As Double
		Get
			
			'UPGRADE_WARNING: �I�u�W�F�N�g m_ElapseTime �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			ElapseTime = m_ElapseTime
			
		End Get
	End Property
	
	Public ReadOnly Property StartTime() As Double
		Get
			
			'UPGRADE_WARNING: �I�u�W�F�N�g m_StartTime �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			StartTime = m_StartTime
			
		End Get
	End Property
	
	Public ReadOnly Property EndTime() As Double
		Get
			Dim m_ndTime As Object
			
			'UPGRADE_WARNING: �I�u�W�F�N�g m_ndTime �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			EndTime = m_ndTime
			
		End Get
	End Property
	
	Public ReadOnly Property Value() As String
		Get
			
			'UPGRADE_WARNING: �I�u�W�F�N�g m_VisM.Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Value = m_VisM.Value
			
		End Get
	End Property
	
	Public WriteOnly Property VisM() As Object
		Set(ByVal Value As Object)
			
			m_VisM = Value
			
		End Set
	End Property
	
	
	
	Public Property P1() As String
		Get
			
			'UPGRADE_WARNING: �I�u�W�F�N�g m_VisM.P1 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			P1 = m_VisM.P1
			
		End Get
		Set(ByVal Value As String)
			
			'UPGRADE_WARNING: �I�u�W�F�N�g m_VisM.P1 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			m_VisM.P1 = Value
			
		End Set
	End Property
	
	
	Public Property P2() As String
		Get
			
			'UPGRADE_WARNING: �I�u�W�F�N�g m_VisM.P2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			P2 = m_VisM.P2
			
		End Get
		Set(ByVal Value As String)
			
			'UPGRADE_WARNING: �I�u�W�F�N�g m_VisM.P2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			m_VisM.P2 = Value
			
		End Set
	End Property
	
	
	Public Property P4() As String
		Get
			
			'UPGRADE_WARNING: �I�u�W�F�N�g m_VisM.P4 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			P4 = m_VisM.P4
			
		End Get
		Set(ByVal Value As String)
			
			'UPGRADE_WARNING: �I�u�W�F�N�g m_VisM.P4 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			m_VisM.P4 = Value
			
		End Set
	End Property
	Public Property P3() As String
		Get
			
			'UPGRADE_WARNING: �I�u�W�F�N�g m_VisM.P3 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			P3 = m_VisM.P3
			
		End Get
		Set(ByVal Value As String)
			
			'UPGRADE_WARNING: �I�u�W�F�N�g m_VisM.P3 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			m_VisM.P3 = Value
			
		End Set
	End Property
	
	
	Public Property P5() As String
		Get
			
			'UPGRADE_WARNING: �I�u�W�F�N�g m_VisM.P5 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			P5 = m_VisM.P5
			
		End Get
		Set(ByVal Value As String)
			
			'UPGRADE_WARNING: �I�u�W�F�N�g m_VisM.P5 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			m_VisM.P5 = Value
			
		End Set
	End Property
	
	
	Public Property P6() As String
		Get
			
			'UPGRADE_WARNING: �I�u�W�F�N�g m_VisM.P6 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			P6 = m_VisM.P6
			
		End Get
		Set(ByVal Value As String)
			
			'UPGRADE_WARNING: �I�u�W�F�N�g m_VisM.P6 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			m_VisM.P6 = Value
			
		End Set
	End Property
	
	
	Public Property P7() As String
		Get
			
			'UPGRADE_WARNING: �I�u�W�F�N�g m_VisM.P7 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			P7 = m_VisM.P7
			
		End Get
		Set(ByVal Value As String)
			
			'UPGRADE_WARNING: �I�u�W�F�N�g m_VisM.P7 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			m_VisM.P7 = Value
			
		End Set
	End Property
	Public Property P8() As String
		Get
			
			'UPGRADE_WARNING: �I�u�W�F�N�g m_VisM.P8 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			P8 = m_VisM.P8
			
		End Get
		Set(ByVal Value As String)
			
			'UPGRADE_WARNING: �I�u�W�F�N�g m_VisM.P8 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			m_VisM.P8 = Value
			
		End Set
	End Property
	
	
	Public Property P9() As String
		Get
			
			'UPGRADE_WARNING: �I�u�W�F�N�g m_VisM.P9 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			P9 = m_VisM.P9
			
		End Get
		Set(ByVal Value As String)
			
			'UPGRADE_WARNING: �I�u�W�F�N�g m_VisM.P9 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			m_VisM.P9 = Value
			
		End Set
	End Property
	
	
	
	Public Property P0() As String
		Get
			
			'UPGRADE_WARNING: �I�u�W�F�N�g m_VisM.P0 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			P0 = m_VisM.P0
			
		End Get
		Set(ByVal Value As String)
			
			'UPGRADE_WARNING: �I�u�W�F�N�g m_VisM.P0 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			m_VisM.P0 = Value
			
		End Set
	End Property
	
	
	Public Property PLIST() As String
		Get
			
			'UPGRADE_WARNING: �I�u�W�F�N�g m_VisM.PLIST �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			PLIST = m_VisM.PLIST
			
		End Get
		Set(ByVal Value As String)
			
			'UPGRADE_WARNING: �I�u�W�F�N�g m_VisM.PLIST �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			m_VisM.PLIST = Value
			
		End Set
	End Property
	
	Private Function M_Execute(ByRef Code As String) As String
		
		Dim iMouseSave As Short
		
		'UPGRADE_WARNING: Screen �v���p�e�B Screen.MousePointer �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
		iMouseSave = System.Windows.Forms.Cursor.Current
		
		M_Execute = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g m_VisM.Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		m_VisM.Value = ""
		
		If Code = "" Then Exit Function
		
		'UPGRADE_ISSUE: Screen �v���p�e�B Screen.MousePointer �̓J�X�^�� �}�E�X�|�C���^���T�|�[�g���܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="45116EAB-7060-405E-8ABE-9DBB40DC2E86"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: Screen �v���p�e�B Screen.MousePointer �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
		System.Windows.Forms.Cursor.Current = m_MousePointer
		
		On Error GoTo ConnectError
		
		'UPGRADE_WARNING: �I�u�W�F�N�g m_VisM.Execute �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		m_VisM.Execute(Code)
		
		On Error GoTo 0
		
		'UPGRADE_ISSUE: Screen �v���p�e�B Screen.MousePointer �̓J�X�^�� �}�E�X�|�C���^���T�|�[�g���܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="45116EAB-7060-405E-8ABE-9DBB40DC2E86"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: Screen �v���p�e�B Screen.MousePointer �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
		System.Windows.Forms.Cursor.Current = iMouseSave
		
		'UPGRADE_WARNING: �I�u�W�F�N�g m_VisM.Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If m_VisM.Error <> 0 Then
			
			On Error Resume Next
			'UPGRADE_WARNING: �I�u�W�F�N�g m_VisM.Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g m_VisM.ErrorName �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Err.Raise(Number:=(vbObjectError + m_VisM.Error), Description:=Code & "  " & m_VisM.ErrorName)
			
		End If
		
		'UPGRADE_WARNING: �I�u�W�F�N�g m_VisM.Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		M_Execute = m_VisM.Value
		
		Exit Function
		
ConnectError: 
		
		'UPGRADE_ISSUE: Screen �v���p�e�B Screen.MousePointer �̓J�X�^�� �}�E�X�|�C���^���T�|�[�g���܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="45116EAB-7060-405E-8ABE-9DBB40DC2E86"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: Screen �v���p�e�B Screen.MousePointer �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
		System.Windows.Forms.Cursor.Current = iMouseSave
		
		On Error Resume Next
		Err.Raise(Number:=(vbObjectError + 2000), Description:="VisM1.Execute ���s���ł��܂���B" & Chr(13) & Chr(10) & "Cache'�@Direct�T�[�o���N������Ă��Ȃ��H")
		
	End Function
	Public Function TimerStart() As Double
		
		'UPGRADE_WARNING: �I�u�W�F�N�g m_StartTime �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		m_StartTime = VB.Timer()
		'UPGRADE_WARNING: �I�u�W�F�N�g m_ElapseTime �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		m_ElapseTime = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g m_StartTime �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		TimerStart = m_StartTime
		
	End Function
	Public Function TimerContinue() As Double
		
		'UPGRADE_WARNING: �I�u�W�F�N�g m_StartTime �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		m_StartTime = VB.Timer()
		'UPGRADE_WARNING: �I�u�W�F�N�g m_StartTime �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		TimerContinue = m_StartTime
		
	End Function
	
	Public Function TimerStop() As Double
		Dim t As Object
		
		m_EndTime = VB.Timer()
		'UPGRADE_WARNING: �I�u�W�F�N�g m_StartTime �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g t �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		t = m_EndTime - m_StartTime
		
		While (t < -0.01)
			
			'UPGRADE_WARNING: �I�u�W�F�N�g t �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			t = t + 86400
			
		End While
		
		'UPGRADE_WARNING: �I�u�W�F�N�g t �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g m_ElapseTime �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		m_ElapseTime = m_ElapseTime + t
		TimerStop = m_EndTime
		
	End Function
	
	Public Sub Wait(ByRef Waitseconds As Single)
		' �w��b���҂��i�n���O�j
		
		Dim StartTime As Single
		StartTime = VB.Timer()
		Do While VB.Timer() < StartTime + Waitseconds
			System.Windows.Forms.Application.DoEvents()
		Loop 
		
	End Sub
	
	Public Function Eval(ByRef Code As String) As String
		
		Eval = M_Execute(Code)
		
	End Function
	
	Public Function Evaluate(ByRef Code As String) As String
		
		Evaluate = M_Execute(Code)
		
	End Function
	
	Public Sub Execute(ByRef Code As String)
		
		M_Execute(Code)
		
	End Sub
	
	Public Sub Exe(ByRef Code As String)
		
		M_Execute(Code)
		
	End Sub
	
	Public Function PLISTItem(ByVal ItemNo As Short) As String
		
		'�@n�Ԗڂ�PLIST���ڂ�Ԃ��B
		
		'UPGRADE_WARNING: �I�u�W�F�N�g m_VisM.PDELIM �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g m_VisM.PLIST �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		PLISTItem = Piece(m_VisM.PLIST, m_VisM.PDELIM, ItemNo, ItemNo)
		
	End Function
	
	'UPGRADE_NOTE: str �� str_Renamed �ɃA�b�v�O���[�h����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"' ���N���b�N���Ă��������B
	Public Function MPiece(ByVal str_Renamed As String, ByVal substr As String, ByVal pos As Short) As String
		
		'�@$Piece�֐��݊�
		
		MPiece = Piece(str_Renamed, substr, pos, pos)
		
	End Function
	
	'UPGRADE_NOTE: Class_Initialize �� Class_Initialize_Renamed �ɃA�b�v�O���[�h����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"' ���N���b�N���Ă��������B
	Private Sub Class_Initialize_Renamed()
		
		m_MousePointer = 11 'ccHourglass
		
	End Sub
	Public Sub New()
		MyBase.New()
		Class_Initialize_Renamed()
	End Sub
	
	Private Function length(ByVal fullstr As String, ByVal substr As String) As Short
		Dim j, i, c As Object
		Dim L As Short
		
		L = Len(substr)
		'UPGRADE_WARNING: �I�u�W�F�N�g c �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		c = 1
		'UPGRADE_WARNING: �I�u�W�F�N�g j �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		j = 1
		Do 
			'UPGRADE_WARNING: �I�u�W�F�N�g j �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g i �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			i = InStr(j, fullstr, substr)
			'UPGRADE_WARNING: �I�u�W�F�N�g i �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If i = 0 Then Exit Do
			'UPGRADE_WARNING: �I�u�W�F�N�g i �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g j �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			j = i + L
			'UPGRADE_WARNING: �I�u�W�F�N�g c �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			c = c + 1
		Loop 
		'UPGRADE_WARNING: �I�u�W�F�N�g c �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		length = c
		
	End Function
	
	Private Function Piece(ByVal fullstr As String, ByVal substr As String, ByVal P1 As Short, ByVal P2 As Short) As String
		Dim i As Short 'pointer for next found substr
		Dim j As Short 'pointer for start of next search
		Dim L As Short 'length of substr
		Dim c As Short 'piece counter
		Dim m1 As Short 'beginning offset for return value
		Dim m2 As Short 'ending offset for return value
		
		If P1 < 1 Then P1 = 1
		If P1 > P2 Then Piece = "" : Exit Function
		
		L = Len(substr)
		m1 = Len(fullstr) + 1 'default values to use for MID$() in the end
		m2 = Len(fullstr) 'if they are never modified in the do-loop
		
		i = -L + 1 : j = 1 : c = 1
		Do 
			If c = P1 Then m1 = i + L
			If c = P2 + 1 Then m2 = i - 1 : Exit Do
			i = InStr(j, fullstr, substr)
			If i = 0 Then Exit Do
			j = i + L
			c = c + 1
		Loop 
		
		Piece = Mid(fullstr, m1, m2 - m1 + 1)
		
	End Function
End Class