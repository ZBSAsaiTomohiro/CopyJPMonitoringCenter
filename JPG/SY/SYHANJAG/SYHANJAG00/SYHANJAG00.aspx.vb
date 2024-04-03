'***********************************************
'
'***********************************************
Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common
Imports JPG.Common.log

Imports System.Text

Partial Class SYHANJAG00
    Inherits System.Web.UI.Page

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
    Protected WithEvents CTLCombo2 As JPG.Common.Controls.CTLCombo

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

    Private strCBO_KENCD As String

    '******************************************************************************
    ' Page_Load
    '******************************************************************************
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '2012/04/04 NEC ou Add Str
        '.NET�̎d�l�ύX�ɂ��AReadOnly������ASPX�ł���ƁA�T�[�o���Œl�̎Q�Ƃ��ł��Ȃ��Ȃ邽�߁AVB����Attribute�ł���
        If MyBase.IsPostBack = False Then
            txtTAISYO.Attributes.Add("ReadOnly", "true")
            txtSYUKEIF.Attributes.Add("ReadOnly", "true")
        End If
        '2012/04/04 NEC ou Add End

        '//------------------------------------------
        '//�@HTTP�w�b�_�𑗐M
        HttpHeaderC.mNoCache(Response)

        '//------------------------------------------
        '//�@�F�؃N���X�̃C���X�^���X����
        AuthC = New CAuthenticate(Request, Response)

        '//------------------------------------------
        '//�@�F�؏���
        '<TODO>�F�g�p�\�������w�肷��
        '[�v���_�E���}�X�^]�g�p�\����(�^:��/�c:��/��:�~/�o:�~)
        AuthC.fncAuthCheck(Server, AuthC.pGROUP_UNKOU & "," & AuthC.pGROUP_EIGYOU)

        '�A����I�����o��
        If hdnKensaku.Value = "SYHANJKG00" Then
            Server.Transfer("SYHANJKG00.aspx")
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
             MyBase.MapPath("../../../SY/SYHANJAG/SYHANJAG00/") & "SYHANJAG00.js"))
        '<�t�H�[�J�X�֘A�֐�>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncFo.js"))
        '<���̓`�F�b�N�֐�>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncChk.js"))
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
            '//���߂ĊJ�������������s�����

            '//--------------------------------------
            '�����\���Ƃ��ĕK�v�ȃR���g���[���̐ݒ���s���܂�
            Call fncIni_format()    '//�l�̏�����

            '//--------------------------------------
            strCBO_KENCD = ""

            '//--------------------------------------
            '�t�H�[�J�X���Z�b�g����
            strMsg.Append("Form1.rdoKBN1.focus();")
        Else
            '//--------------------------------------
            '//�@�Q��ڈȍ~���s�����
            '//--------------------------------------
            strCBO_KENCD = Request.Form("cboKENCD")
        End If

        '�R���{�{�b�N�X���o�͂���
        Call fncCombo_Create_Ken()

        '�R���{�̒l��I������
        Call fncComboSet()

        '//-------------------------------------------------
        '<TODO>�����̉��ID��HIDDEN��hdnMyAspx�ɏ������ށi�V�X�e�����ʁj
        hdnMyAspx.Value = "SYHANJAG00"
        '//-------------------------------------------------
    End Sub

    '******************************************************************************
    '*�@�T�@�v�F�R���{�{�b�N�X�̑I��
    '*�@���@�l�F
    '******************************************************************************
    Private Sub fncComboSet()
        Dim list As New ListItem

        If strCBO_KENCD <> "" Then
            list = cboKENCD.Items.FindByValue(strCBO_KENCD)
            cboKENCD.SelectedIndex = cboKENCD.Items.IndexOf(list)
        End If
    End Sub

    '******************************************************************************
    '* �e�R���g���[���̐ݒ�l�̏�����
    '******************************************************************************
    Private Sub fncIni_format()
        '//--------------------------------------------------------------------------
        '<TODO>�R���g���[���̒l������������
        '
        rdoKBN1.Checked = True
        rdoKBN2.Checked = False

        txtTAISYO.Text = ""
        txtSYUKEIF.Text = ""
        txtSYUKEIT.Text = ""

    End Sub

    '******************************************************************************
    '* �R���{�{�b�N�X�̍쐬
    '******************************************************************************
    Private Sub fncCombo_Create_Ken()
        cboKENCD.pComboTitle = True
        cboKENCD.pNoData = False
        cboKENCD.pType = "KEN"               '//��
        cboKENCD.mMakeCombo()
    End Sub

    '******************************************************************************
    '*�@�T�@�v�F���R���{�{�b�N�X�̒l��Ԃ�
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pKENCD() As String
        Get
            Return Request.Form("cboKENCD")
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�Ώ۔N���̒l��Ԃ�
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pTAISYO() As String
        Get
            Dim DateFncC As New CDateFnc
            Dim strRec As String
            strRec = ""
            If txtTAISYO.Text.Length = 7 Then    'YYYY/MM
                strRec = DateFncC.mHenkanGet(txtTAISYO.Text)
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�W�v����FROM�̒l��Ԃ�
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pSYUKEIF() As String
        Get
            Dim DateFncC As New CDateFnc
            Dim strRec As String
            strRec = ""
            If txtSYUKEIF.Text.Length = 10 Then    'YYYY/MM/DD
                strRec = DateFncC.mHenkanGet(txtSYUKEIF.Text)
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�W�v����TO�̒l��Ԃ�
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pSYUKEIT() As String
        Get
            Dim DateFncC As New CDateFnc
            Dim strRec As String
            strRec = ""
            If txtSYUKEIT.Text.Length = 10 Then    'YYYY/MM/DD
                strRec = DateFncC.mHenkanGet(txtSYUKEIT.Text)
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pMOT_TAISYO() As String
        Get
            Return hdnTAISYO.Value
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pMOT_SYUKEIF() As String
        Get
            Return hdnSYUKEIF.Value
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F���s�{�^���������̏���
    '*�@���@�l�F
    '******************************************************************************
    Private Sub btnJikkou_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnJikkou.ServerClick
        Server.Transfer("SYHANJJG00.aspx")
    End Sub

End Class
