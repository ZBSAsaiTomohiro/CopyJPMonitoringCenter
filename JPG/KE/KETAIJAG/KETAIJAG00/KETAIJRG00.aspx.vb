'***********************************************
'�Ή������ꗗ
'***********************************************
Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common

Imports System.Text

Partial Class KETAIJRG00
    Inherits System.Web.UI.Page

    '�s�����ڂP���⒆
    '�s�����ڂQ���⒆

    Private strExecFlg As String

    '<TODO>�錾���ʎd�l
    '******************************************************************************
    ' HttpHeader
    '******************************************************************************
    Protected HttpHeaderC As New CHttpHeader

    '<TODO>�錾���ʎd�l
    '******************************************************************************
    ' �F�؃N���X
    '******************************************************************************
    Protected AuthC As CAuthenticate

    '<TODO>�錾���ʎd�l
    '******************************************************************************
    ' ScriptMessage
    '******************************************************************************
    Private strMsg As New StringBuilder("")

    '<TODO>�錾���ʎd�l
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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '//------------------------------------------
        '//�@HTTP�w�b�_�𑗐M
        HttpHeaderC.mNoCache(Response)

        '//------------------------------------------
        '//�@�F�؃N���X�̃C���X�^���X����
        AuthC = New CAuthenticate(Request, Response)

        '//------------------------------------------
        '//�@�F�؏���
        '<TODO>�F�g�p�\�������w�肷��
        '[�v���_�E���}�X�^]�g�p�\����(�^:��/�c:�~/��:��/�o:�~)
        '2005/12/03 NEC UPDATE START
        '[�Ή�����]�g�p�\����(�^:��/�c:��/��:��/�o:�~)
        'AuthC.fncAuthCheck(Server, AuthC.pGROUP_UNKOU & "," & AuthC.pGROUP_KANSHI)
        AuthC.fncAuthCheck(Server, AuthC.pGROUP_UNKOU & "," & AuthC.pGROUP_KANSHI & "," & AuthC.pGROUP_EIGYOU)
        '2005/12/03 NEC UPDATE START

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
        '<�Ǝ��X�N���v�g>
        strScript.Append(cscript1.mWriteScript( _
             MyBase.MapPath("../../../KE/KETAIJAG/KETAIJAG00/") & "KETAIJRG00.js"))
        '<�t�H�[�J�X�֘A�֐�>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncFo.js"))
        '<���̓`�F�b�N�֐�>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncChk.js"))
        '<�d�b�ԍ��`�F�b�N�֐�>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncTel.js"))
        '<���l�֘A�֐�>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncNumChk.js"))
        strScript.Append("</Script>")
        '//------------------------------------------
        '//�@Css�i�[
        strScript.Append("<Style>")
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "CssSmall.css"))
        strScript.Append("</Style>")
        '//------------------------------------------
        '//�@Script������
        lblScript.Text = strScript.ToString


        '//------------------------------------------------------------------------------
        If MyBase.IsPostBack = False Then
            '//--------------------------------------
            '//���߂ĊJ�������������s�����

            '//------------------------------------------
            '�o�͂���L�[��HIDDEN�Ɋi�[����
            Dim KETAIJAG00C As KETAIJAG00
            KETAIJAG00C = CType(Context.Handler, KETAIJAG00)

            hdnRIREKI_KURACD.Value = KETAIJAG00C.pPRAM_CLI
            hdnRIREKI_ACBCD.Value = KETAIJAG00C.pPRAM_JASS
            hdnRIREKI_USER_CD.Value = KETAIJAG00C.pPRAM_JUYOKA

            '//------------------------------------------
            '�J�ڌ�����ʂ̐��ю�����o��

            '--- ��2005/05/19 MOD Falcon�� ---  //��Ƀn�C�t���͕t�����Ȃ�
            'If KETAIJAG00C.pPRAM_JASS.Length = 0 Or KETAIJAG00C.pPRAM_JUYOKA.Length = 0 Then
            '�ǂ��炩����̏ꍇ�n�C�t���͕t�����Ȃ�
            txtJUYOKA.Text = KETAIJAG00C.pPRAM_JASS & KETAIJAG00C.pPRAM_JUYOKA
            'Else
            '���������Ă���ꍇ�n�C�t����t������
            'txtJUYOKA.Text = KETAIJAG00C.pPRAM_JASS & "-" & KETAIJAG00C.pPRAM_JUYOKA
            'End If
            '--- ��2005/05/19 MOD Falcon�� ---

            txtJUYOKANAME.Text = KETAIJAG00C.pPRAM_JUYOKANAME

            '//------------------------------------------
            '�f�[�^�̏o�͂��s��
            strMsg.Append("btnFirst_onclick();")

        End If

    End Sub

    '******************************************************************************
    '*�@�T�@�v�F�������s����l��n���v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pExecFlag() As String
        Get
            Return strExecFlg
        End Get
    End Property
    '******************************************************************************
    Public ReadOnly Property pRownum() As String
        Get
            Return hdnRownum.Value
        End Get
    End Property
    '******************************************************************************
    Public ReadOnly Property pRIREKI_CLI() As String
        Get
            Return hdnRIREKI_KURACD.Value
        End Get
    End Property
    '******************************************************************************
    Public ReadOnly Property pRIREKI_JASS() As String
        Get
            Return hdnRIREKI_ACBCD.Value
        End Get
    End Property
    '******************************************************************************
    Public ReadOnly Property pRIREKI_JUYOKA() As String
        Get
            Return hdnRIREKI_USER_CD.Value
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�������s����l��n���v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Private Sub btnFirst_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFirst.ServerClick
        strExecFlg = "DATAFIRST"
        Server.Transfer("KETAIJSG00.aspx")
    End Sub
    '******************************************************************************
    Private Sub btnPre_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPre.ServerClick
        strExecFlg = "DATAPRE"
        Server.Transfer("KETAIJSG00.aspx")
    End Sub
    '******************************************************************************
    Private Sub btnNex_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNex.ServerClick
        strExecFlg = "DATANEX"
        Server.Transfer("KETAIJSG00.aspx")
    End Sub
    '******************************************************************************
    Private Sub btnEnd_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnd.ServerClick
        strExecFlg = "DATAEND"
        Server.Transfer("KETAIJSG00.aspx")
    End Sub
    '******************************************************************************
End Class
