'***********************************************
' �Ď��Ή��o��
'***********************************************
' �ύX����
' 2008/11/11 T.Watabe 
' 2014/12/10 H.Hosoda �Ď����P2014 ��13

Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common
Imports JPG.Common.log

Imports System.Text

Partial Class KETAISYG00
    Inherits System.Web.UI.Page

    '�{�^��

    '�e�L�X�g�{�b�N�X

    '�R���{�{�b�N�X

    '�`�F�b�N�{�b�N�X

    '��\���R���g���[��

    Protected WithEvents dbData As System.Data.DataSet

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
    ' ���t�N���X
    '******************************************************************************
    Protected DateFncC As New CDateFnc

    '******************************************************************************
    ' �����N���X                 2017/02/16 H.Mori add 2016���P�J�� No7-1
    '******************************************************************************
    Protected TimeFncC As New CTimeFnc

    '******************************************************************************
    ' �N�b�L�[
    '******************************************************************************
    Protected ConstC As New CConst

    '******************************************************************************
    ' ScriptMessage
    '******************************************************************************
    Private strMsg As New StringBuilder("")      '//<script>�͕K�v�Ȃ�
    Dim strKANSCD As String         '�Ď��Z���^�[�R�[�h
    Dim strTFKICD As String         '���A�Ή��󋵃R�[�h
    Dim strTFKINM As String         '���A�Ή��󋵖���   '2017/03/02 H.Mori add 2017���P�J�� No7-3 


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
    Private Sub Page_Load(ByVal sender As System.Object, _
                                            ByVal e As System.EventArgs) Handles MyBase.Load
        '2012/04/04 NEC ou Add Str
        '.NET�̎d�l�ύX�ɂ��AReadOnly������ASPX�ł���ƁA�T�[�o���Œl�̎Q�Ƃ��ł��Ȃ��Ȃ邽�߁AVB����Attribute�ł���
        If MyBase.IsPostBack = False Then
            txtKURACD_From.Attributes.Add("ReadOnly", "true")
            txtKURACD_To.Attributes.Add("ReadOnly", "true")
            txtJACD_From.Attributes.Add("ReadOnly", "true")
            txtJACD_To.Attributes.Add("ReadOnly", "true")
            txtHANGRP_From.Attributes.Add("ReadOnly", "ture")
            txtHANGRP_To.Attributes.Add("ReadOnly", "ture")
        End If
        '2012/04/04 NEC ou Add End

        '//------------------------------------------
        '//�@HTTP�w�b�_�𑗐M
        HttpHeaderC.mNoCache(Response)

        '//------------------------------------------
        '//�@�F�؃N���X�̃C���X�^���X����
        AuthC = New CAuthenticate(Request, Response)
        'AuthC.pCENTERCD()
        '//------------------------------------------
        '//�@�F�؏���
        '<TODO>�F�g�p�\�������w�肷��
        '[�x��o�͉��]�g�p�\����(�^:��/�c:��/��:��/�o:�~)
        AuthC.fncAuthCheck(Server, AuthC.pGROUP_UNKOU & "," & AuthC.pGROUP_KANSHI & "," & AuthC.pGROUP_EIGYOU)

        '//------------------------------------------
        '//�|�b�v�A�b�v�o��
        If hdnKensaku.Value = "COPOPUPG00" Then
            Server.Transfer("../../../Popup/COPOPUPG00.aspx")
        End If
        '//�J�����_�[�̏o��
        If hdnKensaku.Value = "COCALDRG00" Then
            Server.Transfer("../../../Popup/COCALDRG00.aspx")
        End If

        ''//�����`�F�b�N�X�N���v�g
        'If hdnKensaku.Value = "KETAISCG00" Then
        '    Server.Transfer("./KETAISCG00.aspx")
        'End If

        '//-----------------------------------------------
        '//���߂ĊJ�������������s�����
        If MyBase.IsPostBack = False Then
            'POST�f�[�^�̎擾�ϐ��̏�����
            Call fncGetPostIni()
        Else
            'POST�f�[�^�̎擾
            Call fncGetPost()
        End If
        '//-----------------------------------------------

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
             MyBase.MapPath("../../../KE/KETAISYG/KETAISYG00/") & "KETAISYG00.js"))
        '<�t�H�[�J�X�֘A�֐�>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncFo.js"))
        '<���t�֘A�֐�>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncDate.js"))
        '<���Ԋ֘A�֐�> 
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncTime.js")) '2017/02/16 H.Mori add ���P2016 No8-2
        strScript.Append("</Script>")
        '//------------------------------------------
        '//�@Css�i�[
        strScript.Append("<Style>")
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "CssData.css"))
        strScript.Append("</Style>")
        '//------------------------------------------
        '//�@Script������
        lblScript.Text = strScript.ToString

        '�R���{�{�b�N�X�̍쐬
        '<TODO>�R���{�{�b�N�X�̍쐬Function��Call����
        Call fncCreateCombo()

        '//------------------------------------------------------------------------------
        If MyBase.IsPostBack = False Then
            '//--------------------------------------
            '//�@���߂ĊJ�������������s�����

            '//--------------------------------------------------------------------------
            '<TODO>�����\���Ƃ��ĕK�v�ȃR���g���[���̐ݒ���s���܂�
            '      ��)��ʏ����\�����́��������I������Ă��邱�Ɓc�c���̏���
            '//--------------------------------------------------------------------------
            '�@�������ʂɂ���ʂ̏�Ԃ̐ݒ�------------------------
            '�@��ʂ��y�����O��ԁz�ɂ���i���̓f�[�^�͂��̂܂ܑJ�ڂ�����j
            '//-------------------------------------------

            '�����\���Ƃ��ĕK�v�ȃR���g���[���̐ݒ���s���܂�
            '�R���{�{�b�N�X�̍쐬
            Call fncIni_format()    '//�l�̏�����

            '��M���ɓ������t��\���@2013/12/05 T.Ono add �Ď����P2013
            txtTRGDATE_From.Text = DateTime.Today.ToString("yyyy/MM/dd")
            txtTRGDATE_To.Text = DateTime.Today.ToString("yyyy/MM/dd")

            '//�t�H�[�J�X���Z�b�g����
            strMsg.Append("Form1.cboKANSCD.focus();")
        Else
            '//--------------------------------------
            '//�@�Q��ڈȍ~���s�����
            '//--------------------------------------------------------------------------
            '//����ʕ\������R���{�{�b�N�X�͊e�ŏI�C�x���g/���\�b�h��CALL���܂�
            '//--------------------------------------------------------------------------
            '<TODO>�R���{�{�b�N�X�g�p���A�l�I����Function��Call����
            Call fncSelectCombo()

        End If

        '//-------------------------------------------------
        '<TODO>�����̉��ID��HIDDEN��hdnMyAspx�ɏ������ށi�V�X�e�����ʁj
        hdnMyAspx.Value = "KETAISYG00"
        '//-------------------------------------------------

    End Sub

    '******************************************************************************
    '*�@�T�@�v�F�R���{�{�b�N�X�̑I��
    '*�@���@�l�F
    '******************************************************************************
    Private Sub fncSelectCombo()
        Dim list As New ListItem
        '//<TODO>�R���{�{�b�N�X��I����Ԃɂ���

        '//�Ď��Z���^�[�R�[�h
        If strKANSCD <> "" Then
            list = cboKANSCD.Items.FindByValue(strKANSCD)
            cboKANSCD.SelectedIndex = cboKANSCD.Items.IndexOf(list)
        End If

        '//���A�Ή���
        If strTFKICD <> "" Then
            list = cboTFKICD.Items.FindByValue(strTFKICD)
            cboTFKICD.SelectedIndex = cboTFKICD.Items.IndexOf(list) 
            strTFKINM = list.ToString   '2017/03/02 H.Mori add 2017���P�J�� No7-3            
        End If

    End Sub

    '******************************************************************************
    '* POST�f�[�^�̎擾�ϐ��̏�����
    '******************************************************************************
    Private Sub fncGetPostIni()
        '//--------------------------------------------------------------------------
        '<TODO>��ʃR���g���[�����e���i�[�����ϐ�������������
        strKANSCD = ""
        strTFKICD = ""
        strTFKINM = ""      '2017/03/02 H.Mori add 2017���P�J�� No7-3
        '//-----------------------------------------------
        hdnKURACD_From.Value = ""
        hdnKURACD_To.Value = ""

        txtKURACD_From.Text = ""
        txtKURACD_To.Text = ""

        hdnJACD_From.Value = "" ' 2008/11/11 T.Watabe edit
        hdnJACD_To.Value = ""
        txtJACD_From.Text = ""
        txtJACD_To.Text = ""

        hdnJACD_From_CLI.Value = ""     '2019/11/01 T.Ono add �Ď����P2019
        hdnJACD_To_CLI.Value = ""       '2019/11/01 T.Ono add �Ď����P2019

        txtTRGDATE_From.Text = ""
        txtTRGDATE_To.Text = ""

    End Sub

    '******************************************************************************
    '* HTTPPOST�f�[�^�擾
    '******************************************************************************
    Private Sub fncGetPost()
        '//--------------------------------------------------------------------------
        '<TODO>��ʃR���g���[���̓��e��ϐ��Ɋi�[����
        '//     �R���{�{�b�N�X��XYZ����t�̕ϊ����͂��̉ӏ��ōs��
        strKANSCD = Request.Form("cboKANSCD")
        strTFKICD = Request.Form("cboTFKICD")
    End Sub

    '******************************************************************************
    '* �e�R���g���[���̐ݒ�l�̏�����
    '******************************************************************************
    Private Sub fncIni_format()

        '�R���{�쐬
        Call fncCombo_Creatr_KANSI_CD()         '�Ď��Z���^�[�R���{
        Call fncCombo_Create_Hukkitai()         '���A�Ή��󋵃R���{

        cboKANSCD.SelectedIndex = 0
        cboTFKICD.SelectedIndex = 0

    End Sub

    '******************************************************************************
    '*�@�T�@�v�F�R���{�{�b�N�X�쐬
    '*�@���@�l�F
    '******************************************************************************
    Private Sub fncCreateCombo()
        '//--------------------------------------------------------------------------
        '<TODO>�R���{�{�b�N�X���쐬����t�@���N�V������Call����
        Call fncCombo_Creatr_KANSI_CD()         '�Ď��Z���^�[�R���{
        Call fncCombo_Create_Hukkitai()         '���A�Ή���
    End Sub

    '******************************************************************************
    '�R���{�{�b�N�X�̍쐬 2013/12/06 T.Ono del ���[�U�[�ɂ��{��������������
    '******************************************************************************
    'Private Sub fncCombo_Creatr_KANSI_CD()
    '    '//�Ď��Z���^�[�R���{
    '    cboKANSCD.pComboTitle = True
    '    cboKANSCD.pNoData = False
    '    cboKANSCD.pType = "KANSICENTER"

    '    Dim strALLCENTERCD As String = ConfigurationSettings.AppSettings("GROUP_KANSHICD")

    '    cboKANSCD.pAllCenterCd = strALLCENTERCD
    '    cboKANSCD.mMakeCombo()
    'End Sub

    '******************************************************************************
    '�R���{�{�b�N�X�̍쐬 2013/12/06 T.Ono add
    '******************************************************************************
    Private Sub fncCombo_Creatr_KANSI_CD()
        '//�Ď��Z���^�[�R���{
        Dim strGROUPNAME As String = AuthC.pGROUPNAME
        Dim arrGroupName() As String = strGROUPNAME.Split(Convert.ToChar(","))
        Dim strALLCENTERCD As String = ConfigurationSettings.AppSettings("GROUP_KANSHICD")

        cboKANSCD.pNoData = False
        cboKANSCD.pType = "KANSICENTER"
        If InStr(AuthC.pGROUPNAME, "0�Ď��Ɩ��P��") > 0 Then
            cboKANSCD.pComboTitle = False
            cboKANSCD.pAllCenterCd = AuthC.pAUTHCENTERCD
        Else
            '����Ď��Z���^�[�E�^�s�͂��ׂĂ̊Ď��Z���^�[�{���\�����I��OK
            cboKANSCD.pComboTitle = True
            cboKANSCD.pAllCenterCd = strALLCENTERCD
        End If
        cboKANSCD.mMakeCombo()
    End Sub

    Private Sub fncCombo_Create_Hukkitai()
        '//���A�Ή���
        cboTFKICD.pComboTitle = True
        cboTFKICD.pNoData = False
        cboTFKICD.pType = "HUKKITAI"
        cboTFKICD.mMakeCombo()
    End Sub

    '******************************************************************************
    ' Excel�o��(�`�F�b�N��)
    '******************************************************************************
    Private Sub btnSelect_ServerClick(ByVal sender As System.Object, _
                                    ByVal e As System.EventArgs) Handles btnSelect.ServerClick
        Dim strRec As String
        'Dim bytExcel() As Byte '2014/01/16 T.Ono del ���P�Ή�2013 Excel�𒼐ڏo�͂ɕύX
        Dim KETAISYG00C As New KETAISYG00KETAISYW00.KETAISYW00

        Dim strSTKBN1 As String
        Dim strSTKBN2 As String

        Dim strPGKBN1 As String
        Dim strPGKBN2 As String
        Dim strPGKBN3 As String

        Dim strOUTKBN As String    '2014/12/10 H.Hosoda add �Ď����P2014 ��13
        Dim strKIKANKBN As String  '2014/12/11 H.Hosoda add �Ď����P2014 ��13
        Dim strHOKBN As String     '2017/02/17 W.GANEKO add �Ď����P2016 ��7
        Dim strOUTLIST As String   '2017/02/17 W.GANEKO add �Ď����P2016 ��7

        '//�@�F�؃N���X�̃C���X�^���X����
        AuthC = New CAuthenticate(Request, Response)

        '�����敪�擾
        strSTKBN1 = ""
        strSTKBN2 = ""
        If chkHSI_TEL.Checked = True Then
            strSTKBN1 = "1"      '�d�b
        End If

        If chkHSI_KEI.Checked = True Then
            strSTKBN2 = "2"      '�x��
        End If

        '�Ή��敪�擾
        strPGKBN1 = ""
        strPGKBN2 = ""
        strPGKBN3 = ""
        If chkTAI_TEL.Checked = True Then
            strPGKBN1 = "1"      '�d�b
        End If

        If chkTAI_SHU.Checked = True Then
            strPGKBN2 = "2"      '�o��
        End If

        If chkTAI_JUF.Checked = True Then
            strPGKBN3 = "3"      '�d��
        End If

        '�o�͑Ώێ擾  2014/12/10 H.Hosoda add �Ď����P2014 ��13
        If rdoOUTPUT1.Checked = True Then
            strOUTKBN = "1"     '�ʏ�
        Else
            strOUTKBN = "2"     '�������[�Ɠ���
        End If
        
        '�Ώۊ��ԋ敪�擾 2014/12/11 H.Hosoda add �Ď����P2014 ��13
        If rdoKIKAN1.Checked = True Then
            strKIKANKBN = "1"     '�Ή�������
        Else
            strKIKANKBN = "2"     '��M��
        End If
        '�@�ߋ敪�擾  2017/02/17 W.GANEKO add �Ď����P2016 ��7
        strHOKBN = ""
        If rdoHOKBN1.Checked = True Then
            strHOKBN = "1"     '�����v
        ElseIf rdoHOKBN2.Checked = True Then
            strHOKBN = "2"     '�t��
        ElseIf rdoHOKBN3.Checked = True Then
            strHOKBN = "3"     '���̑�
        End If
        '�o�͍��ڎ擾  2017/02/17 W.GANEKO add �Ď����P2016 ��7
        strOUTLIST = ""
        If rdoOUTLIST1.Checked = True Then
            strOUTLIST = "1"     '�S��
        ElseIf rdoOUTLIST2.Checked = True Then
            strOUTLIST = "2"     '�����񍐂Ɠ���(�o����Ђ���)
        ElseIf rdoOUTLIST3.Checked = True Then
            strOUTLIST = "3"     '�����񍐂Ɠ���(�o����ЂȂ�)
        End If

        Dim strRecMsg As String = ""

        '2012/04/04 NEC ou Upd Str
        'strRec = KETAISYG00C.mExcel( _
        '                         Request.Cookies.Get("ASP.NET_SessionId").Value, _
        '                         strKANSCD, _
        '                         strTFKICD, _
        '                         strSTKBN1, _
        '                         strSTKBN2, _
        '                         strPGKBN1, _
        '                         strPGKBN2, _
        '                         strPGKBN3, _
        '                         DateFncC.mHenkanGet(txtTRGDATE_From.Text), _
        '                         DateFncC.mHenkanGet(txtTRGDATE_To.Text), _
        '                         hdnKURACD_From.Value, _
        '                         hdnKURACD_To.Value, _
        '                         hdnJACD_From.Value, _
        '                         hdnJACD_To.Value _
        '                         )
        '2014/12/10 H.Hosoda mod �Ď����P2014 ��13 START
        'strRec = KETAISYG00C.mExcel( _
        '                 Me.Session.SessionID, _
        '                 strKANSCD, _
        '                 strTFKICD, _
        '                 strSTKBN1, _
        '                 strSTKBN2, _
        '                 strPGKBN1, _
        '                 strPGKBN2, _
        '                 strPGKBN3, _
        '                 DateFncC.mHenkanGet(txtTRGDATE_From.Text), _
        '                 DateFncC.mHenkanGet(txtTRGDATE_To.Text), _
        '                 hdnKURACD_From.Value.Trim, _
        '                 hdnKURACD_To.Value.Trim, _
        '                 hdnJACD_From.Value.Trim, _
        '                 hdnJACD_To.Value.Trim _
        '                 )
        '2012/04/04 NEC ou Upd End
        '2017/02/16 H.Mori mod ���P2016 No7-1 START
        'strRec = KETAISYG00C.mExcel( _
        '                 Me.Session.SessionID, _
        '                 strKANSCD, _
        '                 strTFKICD, _
        '                 strSTKBN1, _
        '                 strSTKBN2, _
        '                 strPGKBN1, _
        '                 strPGKBN2, _
        '                 strPGKBN3, _
        '                 DateFncC.mHenkanGet(txtTRGDATE_From.Text), _
        '                 DateFncC.mHenkanGet(txtTRGDATE_To.Text), _
        '                 hdnKURACD_From.Value.Trim, _
        '                 hdnKURACD_To.Value.Trim, _
        '                 hdnJACD_From.Value.Trim, _
        '                 hdnJACD_To.Value.Trim, _
        '                 hdnHANGRP_From.Value.Trim, _
        '                 hdnHANGRP_To.Value.Trim, _
        '                 strOUTKBN, _
        '                 strKIKANKBN _
        '                 )
        '2014/12/10 H.Hosoda mod �Ď����P2014 ��13 END
        'TODO 2017/02/17 W.GANEKO mod �Ď����P2016 ��7 START
        '2019/11/01 T.Ono mod �Ď����P2019 hdnJACD_From_CLI,hdnJACD_To_CLI �ǉ�
        '2020/01/06 T.Ono mod �ЊQ�Ή����[ TSADCD(""),TSADNM("")�ǉ�
        strRec = KETAISYG00C.mExcel(
                         Me.Session.SessionID,
                         strKANSCD,
                         strTFKICD,
                         strSTKBN1,
                         strSTKBN2,
                         strPGKBN1,
                         strPGKBN2,
                         strPGKBN3,
                         DateFncC.mHenkanGet(txtTRGDATE_From.Text),
                         DateFncC.mHenkanGet(txtTRGDATE_To.Text),
                         hdnKURACD_From.Value.Trim,
                         hdnKURACD_To.Value.Trim,
                         hdnJACD_From.Value.Trim,
                         hdnJACD_From_CLI.Value.Trim,
                         hdnJACD_To.Value.Trim,
                         hdnJACD_To_CLI.Value.Trim,
                         hdnHANGRP_From.Value.Trim,
                         hdnHANGRP_To.Value.Trim,
                         strOUTKBN,
                         strKIKANKBN,
                         TimeFncC.mHenkanGet(txtTRGTIME_From.Text),
                         TimeFncC.mHenkanGet(txtTRGTIME_To.Text),
                         strHOKBN,
                         strOUTLIST,
                         strTFKINM,
                         "",
                         ""
                         )
        'TODO 2017/02/17 W.GANEKO mod �Ď����P2016 ��7 END
        '2017/02/16 H.Mori mod ���P2016 No7-1 END

        If strRec.Substring(0, 5) = "ERROR" Then
            '�G���[�ł���΃u���E�U�Ƀ��b�Z�[�W�\��
            Dim ErrMsgC As New CErrMsg
            strRecMsg = "�V�X�e���G���[�F" & ErrMsgC.mGetArtMsg(strRec)
            strMsg.Append("alert('" & strRecMsg & "');")

        ElseIf strRec.Substring(0, 5) = "DATA0" Then
            '�f�[�^��0���̏ꍇ
            strRecMsg = "�Ώۃf�[�^�����݂��܂���"
            strMsg.Append("alert('" & strRecMsg & "');")
            strMsg.Append("Form1.btnSelect.focus();")

        Else
            '�u�J���A�ۑ��v�̃_�C�����O���o��悤��HTTP�w�b�_�ɒǉ�
            '�t�@�C�����́AHttpUtility.UrlEncode���\�b�h���g�p����SJIS�ɃG���R�[�h����K�v������
            '            HttpHeaderC.mDownLoad(Response, "�ݐϏ��ꗗ.exe")
            '.xls�`���ɕύX 2013/12/05 T.Ono mod �Ď����P2013
            'HttpHeaderC.mDownLoad(Response, "�x��o��.exe")
            '�t�@�C�����ύX 2017/02/17 W.GANEKO mod �Ď����P2016 ��7
            'HttpHeaderC.mDownLoadXLS(Response, "�x��o��.xls")
            HttpHeaderC.mDownLoadXLS(Response, "�Ή����ʖ���.xls")

            '2014/01/16 T.Ono mod �Ď����P2013 excel�𒼐ڊJ�� Start
            ''Web�T�[�r�X�̖߂�l�iBASE64�̃e�L�X�g�j���o�C�g�f�[�^�ɕϊ�����
            'bytExcel = Convert.FromBase64String(strRec)
            ''�t�@�C�����M
            'Response.BinaryWrite(bytExcel)
            Response.ContentType = "application/msexcel" '2017/05/11 T.Ono add �u�t�@�C�����J���v�ۂ̃G���[�΍�
            Response.WriteFile(strRec)

            'Response.Flush()
            Response.End()
            'Response.WriteFile("C:\inetpub\wwwroot\JPGAP\TEMP\00\KETAISYW00\test.xls")
            '2014/01/16 T.Ono mod �Ď����P2013 excel�𒼐ڊJ�� End

            strRecMsg = "OK"
        End If

        strRec = strRecMsg
        '-------------------------------------------------
        '//�`�o���O��������
        Dim LogC As New CLog
        Dim strRecLog As String
        '2012/04/04 NEC ou Upd
        'strRecLog = LogC.mAPLog(Request.Cookies.Get("ASP.NET_SessionId").Value, AuthC.pUSERNAME, AuthC.pIPADDRESS, hdnMyAspx.Value, "4", strRec, Request.Form)
        strRecLog = LogC.mAPLog(Me.Session.SessionID, AuthC.pUSERNAME, AuthC.pIPADDRESS, hdnMyAspx.Value, "4", strRec, Request.Form)
        '2012/04/04 NEC ou Upd
        If strRecLog <> "OK" Then
            Dim errmsgc As New CErrMsg
            strMsg.Append("alert('�V�X�e���G���[�F" & errmsgc.mGetArtMsg(strRecLog) & "');")
        End If
    End Sub

    '******************************************************************************
    '*�@�T�@�v�F�i���ݏ�����n���v���p�e�B
    '*�@���@�l�F(�N���C�A���g�R�[�h)
    '******************************************************************************
    Public ReadOnly Property pCode1() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = Request.Form("cboKANSCD")     '�w�肳�ꂽ�Ď��Z���^�[�R�[�h�z���̃N���C�A���g�R�[�h
                Case "1"
                    strRec = Request.Form("cboKANSCD")     '�w�肳�ꂽ�Ď��Z���^�[�R�[�h�z���̃N���C�A���g�R�[�h
                Case "2"
                    strRec = hdnKURACD_From.Value ' 2008/11/11 T.Watabe edit
                Case "3"
                    'strRec = hdnKURACD_From.Value ' 2008/11/11 T.Watabe edit
                    strRec = hdnKURACD_To.Value   ' 2019/11/01 T.Ono mod
                Case "4"
                    strRec = hdnKURACD_From.Value ' 2014/12/11 H.Hosoda add �Ď����P2014 ��13
                Case "5"
                    'strRec = hdnKURACD_From.Value ' 2014/12/11 H.Hosoda add �Ď����P2014 ��13
                    strRec = hdnKURACD_To.Value   ' 2019/11/01 T.Ono mod
            End Select
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�i���ݏ�����n���v���p�e�B
    '*�@���@�l�F(�N���C�A���g�R�[�h)
    '******************************************************************************
    Public ReadOnly Property pCode2() As String
        Get
            Dim strRec As String
            strRec = ""
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�o�͂���ꗗ�̖��O��n���v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pListName() As String
        Get
            Dim strRec As String
            'strRec = "�N���C�A���g�ꗗ"
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = "�N���C�A���g�ꗗ"
                Case "1"
                    strRec = "�N���C�A���g�ꗗ"
                Case "2"
                    strRec = "�i�`�ꗗ"
                Case "3"
                    strRec = "�i�`�ꗗ"
                Case "4"
                    strRec = "�̔����Ǝ҃O���[�v�ꗗ"  ' 2014/12/11 H.Hosoda add �Ď����P2014 ��13
                Case "5"
                    strRec = "�̔����Ǝ҃O���[�v�ꗗ"  ' 2014/12/11 H.Hosoda add �Ď����P2014 ��13
            End Select
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�o�͂���ꗗ�𐧌䂷��l��n���v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pListCd() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = "CLI"
                Case "1"
                    strRec = "CLI" ' 2008/11/11 T.Watabe edit
                Case "2"
                    strRec = "JA" ' 2008/11/11 T.Watabe edit
                Case "3"
                    strRec = "JA" ' 2008/11/11 T.Watabe edit
                Case "4"
                    strRec = "HANG" ' 2014/12/11 H.Hosoda add �Ď����P2014 ��13
                Case "5"
                    strRec = "HANG" ' 2014/12/11 H.Hosoda add �Ď����P2014 ��13
            End Select
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�R�[�h��Ԃ��I�u�W�F�N�g�̖��O�l��n���v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pBackCode() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = "hdnKURACD_From"
                Case "1"
                    strRec = "hdnKURACD_To"
                Case "2"
                    strRec = "hdnJACD_From"                 ' 2008/11/11 T.Watabe edit
                Case "3"
                    strRec = "hdnJACD_To"                    ' 2008/11/11 T.Watabe edit
                Case "4"
                    strRec = "hdnHANGRP_From"               ' 2014/12/11 H.Hosoda add �Ď����P2014 ��13
                Case "5"
                    strRec = "hdnHANGRP_To"                  ' 2014/12/11 H.Hosoda add �Ď����P2014 ��13
            End Select
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F���̂�Ԃ��I�u�W�F�N�g�̖��O�l��n���v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pBackName() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = "txtKURACD_From"
                Case "1"
                    strRec = "txtKURACD_To"
                Case "2"
                    strRec = "txtJACD_From"                 ' 2008/11/11 T.Watabe edit
                Case "3"
                    strRec = "txtJACD_To"                    ' 2008/11/11 T.Watabe edit
                Case "4"
                    strRec = "txtHANGRP_From"               ' 2014/12/11 H.Hosoda add �Ď����P2014 ��13
                Case "5"
                    strRec = "txtHANGRP_To"                  ' 2014/12/11 H.Hosoda add �Ď����P2014 ��13
            End Select
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�R�[�h��Ԃ��I�u�W�F�N�g�̖��O�l��n���v���p�e�B�Q�@2019/11/01 T.Ono add �Ď����P2019
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pBackCode2() As String
        Get
            Dim strRec As String = ""
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = ""
                Case "1"
                    strRec = ""
                Case "2"
                    strRec = "hdnJACD_From_CLI"
                Case "3"
                    strRec = "hdnJACD_To_CLI"
                Case "4"
                    strRec = ""
                Case "5"
                    strRec = ""
            End Select
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�t�H�[�J�X��Ԃ��I�u�W�F�N�g�̖��O�l��n���v���p�e�B
    '*�@�T�@�v�F�J�����_�[���t�Ńt�H�[�J�X�Z�b�g����鍀�ږ���Ԃ��I�u�W�F�N�g���w��
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pBackFocs() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value.Length > 0 Then
                Select Case hdnPopcrtl.Value
                    Case "0"
                        strRec = "btnKURACD_From"
                    Case "1"
                        strRec = "btnKURACD_To"
                    Case "2"
                        strRec = "btnJACD_From" ' 2008/11/11 T.Watabe edit
                    Case "3"
                        strRec = "btnJACD_To" ' 2008/11/11 T.Watabe edit
                    Case "4"
                        strRec = "btnHANGRP_From" ' 2014/12/11 H.Hosoda add �Ď����P2014 ��13
                    Case "5"
                        strRec = "btnHANGRP_To" ' 2014/12/11 H.Hosoda add �Ď����P2014 ��13
                End Select
                '2019/11/01 T.Ono mod �Ď����P2019 START
                'hdnPopcrtl�̏������������R�����g�A�E�g�������ߏC��
                'ElseIf hdnCalendar.Value = "1" Then
                '    strRec = "txtTRGDATE_From"
                'ElseIf hdnCalendar.Value = "2" Then
                '    strRec = "txtTRGDATE_To"
            End If

            If hdnCalendar.Value = "1" Then
                strRec = "txtTRGDATE_From"
            ElseIf hdnCalendar.Value = "2" Then
                strRec = "txtTRGDATE_To"
            End If
            '2019/11/01 T.Ono mod �Ď����P2019 END

            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F���^�[����Ɏ��s�����i�r�@2019/11/01 T.Ono add �Ď����P2019
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pBackScript() As String
        Get
            Dim strRec As String = ""
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = "fncSetTo"
                Case "1"
                    strRec = ""
                Case "2"
                    strRec = "fncSetTo"
                Case "3"
                    strRec = ""
                Case "4"
                    strRec = "fncSetTo"
                Case "5"
                    strRec = ""
            End Select
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pClear1() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "0" Then
                strRec = "txtKURACD_From"
            ElseIf hdnPopcrtl.Value = "1" Then
                strRec = "txtKURACD_To"
            ElseIf hdnPopcrtl.Value = "2" Then ' 2008/11/11 T.Watabe edit
                strRec = "txtJACD_From"
            ElseIf hdnPopcrtl.Value = "3" Then ' 2008/11/11 T.Watabe edit
                strRec = "txtJACD_To"
            ElseIf hdnPopcrtl.Value = "4" Then ' 2014/12/11 H.Hosoda add �Ď����P2014 ��13
                strRec = "txtHANGRP_From"
            ElseIf hdnPopcrtl.Value = "5" Then ' 2014/12/11 H.Hosoda add �Ď����P2014 ��13
                strRec = "txtHANGRP_To"
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pClear2() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "0" Then
                strRec = "hdnKURACD_From"
            ElseIf hdnPopcrtl.Value = "1" Then
                strRec = "hdnKURACD_To"
            ElseIf hdnPopcrtl.Value = "2" Then ' 2008/11/11 T.Watabe edit
                strRec = "hdnJACD_From"
            ElseIf hdnPopcrtl.Value = "3" Then ' 2008/11/11 T.Watabe edit
                strRec = "hdnJACD_To"
            ElseIf hdnPopcrtl.Value = "4" Then ' 2014/12/11 H.Hosoda add �Ď����P2014 ��13
                strRec = "hdnHANGRP_From"
            ElseIf hdnPopcrtl.Value = "5" Then ' 2014/12/11 H.Hosoda add �Ď����P2014 ��13
                strRec = "hdnHANGRP_To"
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�i�`���ύX���ꂽ���ɃN���A����I�u�W�F�N�g�̖��O�l��n���v���p�e�B�P
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pClearName() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"                    
                    'strRec = "txtJACD_From,txtJACD_To" ' 2014/12/11 H.Hosoda mod �Ď����P2014 ��13
                    strRec = "txtJACD_From,txtJACD_To,txtHANGRP_From,txtHANGRP_To"
                Case "1"
                    strRec = ""
                Case "2"
                    strRec = ""
                Case "3"
                    strRec = ""
                Case "4"
                    strRec = ""  ' 2014/12/11 H.Hosoda add �Ď����P2014 ��13
                Case "5"
                    strRec = ""  ' 2014/12/11 H.Hosoda add �Ď����P2014 ��13
            End Select
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�i�`���ύX���ꂽ���ɃN���A����I�u�W�F�N�g�̖��O�l��n���v���p�e�B�P
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pClearCode() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    'strRec = "hdnJACD_From,hdnJACD_To"  ' 2014/12/11 H.Hosoda mod �Ď����P2014 ��13
                    strRec = "hdnJACD_From,hdnJACD_To,hdnHANGRP_From,hdnHANGRP_To"
                Case "1"
                    strRec = ""
                Case "2"
                    strRec = ""
                Case "3"
                    strRec = ""
                Case "4"
                    strRec = ""  ' 2014/12/11 H.Hosoda add �Ď����P2014 ��13
                Case "5"
                    strRec = ""  ' 2014/12/11 H.Hosoda add �Ď����P2014 ��13
            End Select
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�J�����_�[���t��Ԃ��̒l��Ԃ��I�u�W�F�N�g���w��
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pBackDate() As String
        Get
            Dim strRec As String
            If hdnCalendar.Value = "1" Then
                strRec = "txtTRGDATE_From"
            ElseIf hdnCalendar.Value = "2" Then
                strRec = "txtTRGDATE_To"
            End If
            Return strRec
        End Get
    End Property

End Class
