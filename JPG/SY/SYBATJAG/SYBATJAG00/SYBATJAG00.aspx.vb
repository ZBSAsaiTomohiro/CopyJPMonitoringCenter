'***********************************************
'�o�b�`���s�����ꗗ  ���C�����
'***********************************************
' �ύX����
' 2011/04/20 T.Watabe BTFAXJBE00�i�����e�`�w�Q�j�ꗗ�ɒǉ� 
Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common
Imports System.Text

Partial Class SYBATJAG00
    Inherits System.Web.UI.Page

    '******************************************************************************
    ' HttpHeader
    '******************************************************************************
    Protected HttpHeaderC As New CHttpHeader

    '<TODO>�錾���ʎd�l
    '******************************************************************************
    ' �F�؃N���X
    '******************************************************************************
    Protected AuthC As CAuthenticate

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
        '[�Ή����ʈꗗ]�g�p�\����(�^:��/�c:�~/��:��/�o:�~)
        AuthC.fncAuthCheck(Server, AuthC.pGROUP_UNKOU & "," & AuthC.pGROUP_KANSHI)

        '//------------------------------------------
        '//�ꗗ��IFRAME���o�͂���
        If hdnKenSaku.Value = "SYBATJFG00" Then
            Server.Transfer("SYBATJFG00.aspx")
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
        '<�Ǝ��X�N���v�g>
        strScript.Append(cscript1.mWriteScript( _
             MyBase.MapPath("../../../SY/SYBATJAG/SYBATJAG00/") & "SYBATJAG00.js"))
        '<�t�H�[�J�X�֘A�֐�>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncFo.js"))
        '<���t�֘A�֐�>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncDate.js"))
        strScript.Append("</Script>")
        '//------------------------------------------
        '//�@Css�i�[
        strScript.Append("<Style>")
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "CssData.css"))

        strScript.Append("</Style>")
        '//------------------------------------------
        '//�@Script������
        lblScript.Text = strScript.ToString

        '//------------------------------------------------------------------------------
        If MyBase.IsPostBack = False Then
            '//--------------------------------------
            '//�@���߂ĊJ�������������s�����

            '//--------------------------------------
            '�����\���Ƃ��ĕK�v�ȃR���g���[���̐ݒ���s���܂�
            Call fncIni_format()    '//�l�̏�����

            '//--------------------------------------------------------------------------
            '<TODO>�����\���Ƃ��ĕK�v�ȃR���g���[���̐ݒ���s���܂�
            '      ��)��ʏ����\�����́��������I������Ă��邱�Ɓc�c���̏���
            '//--------------------------------------------------------------------------
            '�@�������ʂɂ���ʂ̏�Ԃ̐ݒ�------------------------
            '�@��ʂ��y�����O��ԁz�ɂ���i���̓f�[�^�͂��̂܂ܑJ�ڂ�����j
            '//--------------------------------------------------------------------------
            '�t�H�[�J�X���Z�b�g����
            strMsg.Append("Form1.btnSelect.focus();")
        Else
            '//--------------------------------------
            '//�@�Q��ڈȍ~���s�����
            '//--------------------------------------------------------------------------
            '//����ʕ\������R���{�{�b�N�X�͊e�ŏI�C�x���g/���\�b�h��CALL���܂�
            '//--------------------------------------------------------------------------
        End If

        '//-------------------------------------------------
        '<TODO>�����̉��ID��HIDDEN��hdnMyAspx�ɏ������ށi�V�X�e�����ʁj
        hdnMyAspx.Value = "SYBATJAG00"
        '//-------------------------------------------------

    End Sub

    '******************************************************************************
    '* �e�R���g���[���̐ݒ�l�̏�����
    '******************************************************************************
    Private Sub fncIni_format()

        '�R���{�쐬
        cboPROC_ID.Items.Add(New ListItem("", ""))
        cboPROC_ID.Items.Add(New ListItem("BTGETJAE00:�����f�[�^����", "BTGETJAE00"))
        'cboPROC_ID.Items.Add(New ListItem("BTFAXJAE00:�����e�`�w", "BTFAXJAE00")) 2013/12/06 T.Ono del �Ď����P2013
        'cboPROC_ID.Items.Add(New ListItem("BTFAXJBE00:�����e�`�w�Q", "BTFAXJBE00")) ' 2011/04/20 T.Watabe add�@2013/12/06 T.Ono del �Ď����P2013
        cboPROC_ID.Items.Add(New ListItem("BTFAXJCE00:�����e�`�w2013", "BTFAXJCE00")) '2013/12/06 T.Ono del �Ď����P2013
        cboPROC_ID.Items.Add(New ListItem("BTFAXJDE00:�����e�`�w2014", "BTFAXJDE00")) '2015/03/10 T.Ono add 2014���P�J��
        cboPROC_ID.Items.Add(New ListItem("BTFAXJEE00:�����e�`�w2015", "BTFAXJEE00")) '2016/04/04 T.Ono add 2015���P�J��
        'cboPROC_ID.Items.Add(New ListItem("SYHANJAE00:�̔��Ǘ�������", "SYHANJAE00"))�@2013/12/06 T.Ono del �Ď����P2013
        'cboPROC_ID.Items.Add(New ListItem("BTLTSJAE00:�����k�s�n�r�A��", "BTLTSJAE00"))�@2013/12/06 T.Ono mod �Ď����P2013
        cboPROC_ID.Items.Add(New ListItem("BTLTSJAE00:�i�`�|�k�s�n�r�A��", "BTLTSJAE00"))

        cboPROC_ID.SelectedIndex = 0

        '//�u�ُ�v��I������
        rdoKBN1.Checked = False
        rdoKBN2.Checked = False
        rdoKBN3.Checked = True

        '//�Ώۓ��t�̓V�X�e�����t���o�͂���(yyyy/MM/dd)�B
        txtTRGDATE_From.Text = Now.ToString("yyyy/MM/dd")
        txtTRGDATE_To.Text = Now.ToString("yyyy/MM/dd")

    End Sub

    '******************************************************************************
    '*�@�T�@�v�F�p�����[�^�l�����tYYYYMMDD�l��Ԃ�
    '*�@���@�l�F
    '******************************************************************************
    Public Function fncDateGet(ByVal pstrDate As String) As String
        Dim DateFncC As New CDateFnc
        Dim strRec As String
        strRec = ""
        If pstrDate.Length <> 0 Then
            strRec = DateFncC.mHenkanGet(pstrDate)
        End If

        Return strRec
    End Function

    '******************************************************************************
    '*�@�T�@�v�F�p�����[�^�l�����tYYYY/MM/DD�l��Ԃ�
    '*�@���@�l�F
    '******************************************************************************
    Public Function fncDateSet(ByVal pstrDate As String) As String
        Dim DateFncC As New CDateFnc
        Dim strRec As String
        strRec = ""
        If IsNumeric(pstrDate) = True Then
            strRec = DateFncC.mGet(pstrDate)
        End If

        Return strRec
    End Function

    '******************************************************************************
    '*�@�T�@�v�F�p�����[�^�l��莞��HH:mm:ss�l��Ԃ�
    '*�@���@�l�F
    '******************************************************************************
    Public Function fncTimeSet(ByVal pstrTime As String, ByVal intInd As Integer) As String
        Dim TimeFncC As New CTimeFnc
        Dim strRec As String
        strRec = ""
        If IsNumeric(pstrTime) = True Then
            strRec = TimeFncC.mGet(pstrTime, intInd)
        End If

        Return strRec
    End Function

    '<TODO>���������Ƃ���IFRAME��ʂɈ����n�������lReadOnly�v���p�e�B�Őݒ肷��
    '******************************************************************************
    '*�@�T�@�v�F�敪�̒l��n���v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pKbn() As String
        Get
            Dim strRec As String = Request.Form("rdoKBN")
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�Ώۏ����̒l��n���v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pPROC_ID() As String
        Get
            Dim strRec As String = Request.Form("cboPROC_ID")
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�Ώۓ��t�i�e�������j�̒l��n���v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pTRGDATE_F() As String
        Get
            Return fncDateGet(txtTRGDATE_From.Text)
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�Ώۓ��t�i�s���j�̒l��n���v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pTRGDATE_T() As String
        Get
            Return fncDateGet(txtTRGDATE_To.Text)
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�FhdnSelectClick�̒l��n���v���p�e�B
    '*�@���@�l�F�����{�^���������̂�"1"������BIFRAME���ɂđJ�ړI�o�͂Ȃ̂������o�͂Ȃ̂��𔻒�(MESSAGE)
    '******************************************************************************
    Public ReadOnly Property pSelectClick() As String
        Get
            Return hdnSelectClick.Value
        End Get
    End Property

End Class
