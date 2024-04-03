Option Explicit On 
Option Strict On

Imports Common

Imports System.Text

'******************************************************************************
' �|�b�v�A�b�v (�Ăяo����)
'******************************************************************************

Public Class COPOPUPG00
    Inherits System.Web.UI.Page
    Protected WithEvents lblScript As System.Web.UI.WebControls.Label
    Protected WithEvents hdnKensaku As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hdnListCd As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hdnBackCode As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hdnBackName As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hbdBackFocs As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents lblListName As System.Web.UI.WebControls.Label
    Protected WithEvents hdnPopType As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hdnCode1 As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hdnCode2 As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hdnClear1 As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hdnClear2 As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hdnClear3 As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hdnClear4 As System.Web.UI.HtmlControls.HtmlInputHidden
    '�V�X�e������
    Protected strListName As String

    '******************************************************************************
    ' HttpHeader
    '******************************************************************************
    Protected HttpHeaderC As New CHttpHeader
    Protected WithEvents hbdBackScript As System.Web.UI.HtmlControls.HtmlInputHidden

    '******************************************************************************
    ' ScriptMessage
    '******************************************************************************
    Private strMsg As New StringBuilder("")      '//<script>�͕K�v�Ȃ�

    '******************************************************************************
    ' Render
    '******************************************************************************
    Protected Overrides Sub Render(ByVal writer As HtmlTextWriter)
        MyBase.Render(writer)

        Dim strWrite As New StringBuilder("")

        strWrite.Append("<script language='JavaScript'>")
        strWrite.Append(strMsg.ToString())
        strWrite.Append("</script>")
        writer.Write(strWrite.ToString())
    End Sub

    '------------------------------------------------------------------------------
    '<TODO>�@�\�ǉ����ɑΏۂ̃v���W�F�N�g��ǉ����Ă���
    Protected MSTANJAG00_C As MSTANJAG00.MSTANJAG00         '�S���҃}�X�^
    Protected MSPULJAG00_C As MSPULJAG00.MSPULJAG00         '�v���_�E���}�X�^
    Protected KETAIJAG00_C As KETAIJAG00.KETAIJAG00         '�Ή�����
    Protected KERUIJOG00_C As KERUIJOG00.KERUIJOG00         '�ݐϏ��ꗗ
    Protected KEKEKJAG00_C As KEKEKJAG00.KEKEKJAG00         '�Ή����ʈꗗ
    Protected MSKOSJAG00_C As MSKOSJAG00.MSKOSJAG00         '�ڋq����

    '-----------------------------------------------------------------------

#Region " Web �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h "

    '���̌Ăяo���� Web �t�H�[�� �f�U�C�i�ŕK�v�ł��B
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub


    '���� : ���̃v���[�X�z���_�錾�� Web �t�H�[�� �f�U�C�i�ŕK�v�ł��B
    '�폜����шړ����Ȃ��ł��������B
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        ' CODEGEN: ���̃��\�b�h�Ăяo���� Web �t�H�[�� �f�U�C�i�ŕK�v�ł��B
        ' �R�[�h �G�f�B�^���g���ĕύX���Ȃ��ł��������B
        InitializeComponent()
    End Sub

#End Region

    '******************************************************************************
    ' Page_Load
    '******************************************************************************
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                                                                Handles MyBase.Load
        '//------------------------------------------
        '//�@HTTP�w�b�_�𑗐M
        HttpHeaderC.mNoCache(Response)

        '//------------------------------------------
        'Iframe�o��
        If hdnKensaku.Value = "COPOPUFG00" Then
            Server.Transfer("COPOPUFG00.aspx")
        End If

        '//------------------------------------------
        '// Script�����ݗp�ϐ��錾
        Dim strScript As New StringBuilder("")
        Dim cscript1 As New CScript
        Dim strScriptPath As String
        strScriptPath = ConfigurationSettings.AppSettings("SCRIPTPATH")
        '------------------------------------------------------------------------------
        '<TODO>HTML���ɕK�v��JavaScript/CSS�͂�����[strScript]�ϐ��Ɋi�[��
        '      ��ʏ�[lblScript]�ɏ������݂��s���܂�(SPAN�^�O�Ƃ��ăN���C�A���g�ɃX�N���v�g��
        '      �o�͂���܂��B)
        '//------------------------------------------
        '//�@JavaScript�i�[
        strScript.Append("<Script language=javascript>")
        '<�|�b�v�A�b�v�p�֐�>
        strScript.Append(cscript1.mWriteScript(MyBase.MapPath("../../../Popup/") & "COPOPUPG00.js"))
        '<�t�H�[�J�X�֘A�֐�>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncFo.js"))
        '<���̓`�F�b�N�֐�>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncChk.js"))
        strScript.Append("</Script>")
        '//------------------------------------------
        '//�@Css�i�[
        strScript.Append("<Style>")
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "CssPopup.css"))
        strScript.Append("</Style>")
        '//------------------------------------------
        '//�@Script������
        lblScript.Text = strScript.ToString

        '------------------------------------------------------------------------------
        '<TODO>�@�\�ǉ����ɑΏۂ̃v���W�F�N�g��ǉ����Ă���
        ''�S���҃}�X�^
        If Request.Path.LastIndexOf("MSTANJAG00") >= 0 Then
            MSTANJAG00_C = CType(Context.Handler, MSTANJAG00.MSTANJAG00)
            strListName = MSTANJAG00_C.pListName
            hdnListCd.Value = MSTANJAG00_C.pListCd
            hdnCode1.Value = MSTANJAG00_C.pCode1
            hdnBackCode.Value = MSTANJAG00_C.pBackCode
            hdnBackName.Value = MSTANJAG00_C.pBackName
            hbdBackFocs.Value = MSTANJAG00_C.pBackFocs
            hdnClear1.Value = MSTANJAG00_C.pClear1
            hdnClear2.Value = MSTANJAG00_C.pClear2
        End If
        ''�v���_�E���}�X�^
        If Request.Path.LastIndexOf("MSPULJAG00") >= 0 Then
            MSPULJAG00_C = CType(Context.Handler, MSPULJAG00.MSPULJAG00)
            strListName = MSPULJAG00_C.pListName
            hdnListCd.Value = MSPULJAG00_C.pListCd
            hdnCode1.Value = MSPULJAG00_C.pCode1
            hdnBackCode.Value = MSPULJAG00_C.pBackCode
            hdnBackName.Value = MSPULJAG00_C.pBackName
            hbdBackFocs.Value = MSPULJAG00_C.pBackFocs
            hdnClear1.Value = MSPULJAG00_C.pClear1
        End If
        '�Ή�����
        If Request.Path.LastIndexOf("KETAIJAG00") >= 0 Then
            KETAIJAG00_C = CType(Context.Handler, KETAIJAG00.KETAIJAG00)
            strListName = KETAIJAG00_C.pListName
            hdnListCd.Value = KETAIJAG00_C.pListCd
            hdnCode1.Value = KETAIJAG00_C.pCode1
            hdnBackCode.Value = KETAIJAG00_C.pBackCode
            hdnBackName.Value = KETAIJAG00_C.pBackName
            hbdBackFocs.Value = KETAIJAG00_C.pBackFocs
            hbdBackScript.Value = KETAIJAG00_C.pBackScript
            hdnClear1.Value = KETAIJAG00_C.pClear1
            hdnClear2.Value = KETAIJAG00_C.pClear2
            hdnClear3.Value = KETAIJAG00_C.pClear3
            hdnClear4.Value = KETAIJAG00_C.pClear4
        End If
        ''�ݐϏ��ꗗ
        If Request.Path.LastIndexOf("KERUIJOG00") >= 0 Then
            KERUIJOG00_C = CType(Context.Handler, KERUIJOG00.KERUIJOG00)
            strListName = KERUIJOG00_C.pListName
            hdnListCd.Value = KERUIJOG00_C.pListCd
            hdnCode1.Value = KERUIJOG00_C.pCode1
            hdnCode2.Value = KERUIJOG00_C.pCode2
            hdnBackCode.Value = KERUIJOG00_C.pBackCode
            hdnBackName.Value = KERUIJOG00_C.pBackName
            hbdBackFocs.Value = KERUIJOG00_C.pBackFocs
            hdnClear1.Value = Convert.ToString(KERUIJOG00_C.pClearCode.Split(Convert.ToChar(",")).GetValue(0))
            hdnClear2.Value = Convert.ToString(KERUIJOG00_C.pClearName.Split(Convert.ToChar(",")).GetValue(0))
            If KERUIJOG00_C.pClearCode.Split(Convert.ToChar(",")).Length > 1 Then
                hdnClear3.Value = Convert.ToString(KERUIJOG00_C.pClearCode.Split(Convert.ToChar(",")).GetValue(1))
                hdnClear4.Value = Convert.ToString(KERUIJOG00_C.pClearName.Split(Convert.ToChar(",")).GetValue(1))
            End If
        End If
        ''�Ή��ύX�ꗗ
        If Request.Path.LastIndexOf("KEKEKJAG00") >= 0 Then
            KEKEKJAG00_C = CType(Context.Handler, KEKEKJAG00.KEKEKJAG00)
            strListName = KEKEKJAG00_C.pListName
            hdnListCd.Value = KEKEKJAG00_C.pListCd
            hdnCode1.Value = KEKEKJAG00_C.pCode1
            hdnBackCode.Value = KEKEKJAG00_C.pBackCode
            hdnBackName.Value = KEKEKJAG00_C.pBackName
            hbdBackFocs.Value = KEKEKJAG00_C.pBackFocs
            hdnClear1.Value = KEKEKJAG00_C.pClear1
            hdnClear2.Value = KEKEKJAG00_C.pClear2
        End If
        ''�ڋq����
        If Request.Path.LastIndexOf("MSKOSJAG00") >= 0 Then
            MSKOSJAG00_C = CType(Context.Handler, MSKOSJAG00.MSKOSJAG00)
            strListName = MSKOSJAG00_C.pListName
            hdnListCd.Value = MSKOSJAG00_C.pListCd
            hdnCode1.Value = MSKOSJAG00_C.pCode1
            hdnBackCode.Value = MSKOSJAG00_C.pBackCode
            hdnBackName.Value = MSKOSJAG00_C.pBackName
            hbdBackFocs.Value = MSKOSJAG00_C.pBackFocs
            hdnClear1.Value = MSKOSJAG00_C.pClear1
            hdnClear2.Value = MSKOSJAG00_C.pClear2
        End If

        '------------------------------------------------------------------------------
        '�ꗗ�^�C�g���̕\��
        lblListName.Text = strListName
        '�E�B���h�E�̃^�C�g���̐ݒ�
        strMsg.Append("document.title='" & strListName & "'")
    End Sub
    '******************************************************************************
    '*�@�T�@�v�F���X�g�R�[�h(���)�̒l��n���v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pListCd() As String
        Get
            Return hdnListCd.Value
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�R�[�h��Ԃ��I�u�W�F�N�g�̖��O�l��n���v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pBackCode() As String
        Get
            Return hdnBackCode.Value
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F���̂�Ԃ��I�u�W�F�N�g�̖��O�l��n���v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pBackName() As String
        Get
            Return hdnBackName.Value
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�t�H�[�J�X��Ԃ��I�u�W�F�N�g�̖��O�l��n���v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pBackFocs() As String
        Get
            Return hbdBackFocs.Value
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F���s����i�r����n���v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pBackScript() As String
        Get
            Return hbdBackScript.Value
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pPopType() As String
        Get
            '[1]:�R�[�h�̕Ԃ�l�͕\���p�́u[CODE]�F[NAME]�v�ɂȂ�܂��F�f�t�H���g
            '[2]:�R�[�h�̕Ԃ�l�͓��͉\(�ڋq����)�p�́uCODE�v�ɂȂ�܂�
            Return hdnPopType.Value
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�R�[�h�̒l��n���v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pCode1() As String
        Get
            Return hdnCode1.Value
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�R�[�h�̒l��n���v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pCode2() As String
        Get
            Return hdnCode2.Value
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�����Z���^�[���ύX���ꂽ���ɃN���A����I�u�W�F�N�g�̖��O�l��n���v���p�e�B�P
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pClear1() As String
        Get
            Return hdnClear1.Value
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�����Z���^�[���ύX���ꂽ���ɃN���A����I�u�W�F�N�g�̖��O�l��n���v���p�e�B�Q
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pClear2() As String
        Get
            Return hdnClear2.Value
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�����Z���^�[���ύX���ꂽ���ɃN���A����I�u�W�F�N�g�̖��O�l��n���v���p�e�B�P
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pClear3() As String
        Get
            Return hdnClear3.Value
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�����Z���^�[���ύX���ꂽ���ɃN���A����I�u�W�F�N�g�̖��O�l��n���v���p�e�B�Q
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pClear4() As String
        Get
            Return hdnClear4.Value
        End Get
    End Property
End Class
