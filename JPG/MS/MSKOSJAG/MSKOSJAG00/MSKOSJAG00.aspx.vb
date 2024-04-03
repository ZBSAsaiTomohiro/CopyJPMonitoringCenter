'***********************************************
'�ڋq����  ���C�����
'***********************************************
Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common
Imports JPG.Common.log
Imports System.Text

Partial Class MSKOSJAG00
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

    '******************************************************************************
    ' Page_Load
    '******************************************************************************
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '2012/04/04 NEC ou Add Str
        '.NET�̎d�l�ύX�ɂ��AReadOnly������ASPX�ł���ƁA�T�[�o���Œl�̎Q�Ƃ��ł��Ȃ��Ȃ邽�߁AVB����Attribute�ł���
        If MyBase.IsPostBack = False Then
            txtCLI_CD.Attributes.Add("ReadOnly", "true")
            txtCLI_CD_TO.Attributes.Add("ReadOnly", "true") '2019/11/01 T.Ono add �Ď����P2019 ��1
            txtJA_CD.Attributes.Add("ReadOnly", "true") '2013/11/26 T.Ono add �Ď����P2013��2
            txtHANGRP.Attributes.Add("ReadOnly", "true") '2014/12/03 H.Hosoda add �Ď����P2014 No.6
            txtHAN_CD.Attributes.Add("ReadOnly", "true")
            'txtKINRENGRP.Attributes.Add("ReadOnly", "true") '2016/11/17 H.Mori add 2016���P�J�� No2-1 '2019/11/01 T.Ono del
            txtHAN_CD_TO.Attributes.Add("ReadOnly", "true") '2016/11/24 H.Mori add 2016���P�J�� No2-2
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
        '[�ڋq����]�g�p�\����(�^:��/�c:�~����/��:��/�o:�~)
        'AuthC.fncAuthCheck(Server, AuthC.pGROUP_UNKOU & "," & AuthC.pGROUP_KANSHI) '2017/07/20 H.Mori mod
        AuthC.fncAuthCheck(Server, AuthC.pGROUP_UNKOU & "," & AuthC.pGROUP_KANSHI & "," & AuthC.pGROUP_EIGYOU)

        '//------------------------------------------
        '<TODO>�|�b�v�A�b�v/�o�^�n�t���[���̏o��
        '      [hdnKensaku(Hidden)]���쐬���鎖
        If hdnKensaku.Value = "COPOPUPG00" Then
            Server.Transfer("../../../Popup/COPOPUPG00.aspx")
        End If
        '//�ꗗ��IFRAME���o�͂���
        If hdnKensaku.Value = "MSKOSJFG00" Then
            Server.Transfer("MSKOSJFG00.aspx")
        End If
        '�Ή����͉�ʂ֑J��
        If hdnKensaku.Value = "KETAIJAG00" Then
            Server.Transfer("../../../KE/KETAIJAG/KETAIJAG00/KETAIJAG00.aspx")
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
        strScript.Append(cscript1.mWriteScript(
             MyBase.MapPath("../../../MS/MSKOSJAG/MSKOSJAG00/") & "MSKOSJAG00.js"))
        '<�t�H�[�J�X�֘A�֐�>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncFo.js"))
        '<�S�p�`�F�b�N�֐�>
        '--- ��2005/05/19 DEL Falcon�� ---
        'strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncZenkakuChk.js"))
        '--- ��2005/05/19 DEL Falcon�� ---
        '<�d�b�ԍ��`�F�b�N�֐�>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncTel.js"))

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

            Dim list As New ListItem            '���X�g�A�C�e��
            If Request.Path.LastIndexOf("SYCTIJAG00") >= 0 Then
                '�b�s�h����̑J�ڂ̏ꍇ

                Dim SYCTIJAG00_C As New SYCTIJAG00.SYCTIJAG00
                SYCTIJAG00_C = CType(Context.Handler, SYCTIJAG00.SYCTIJAG00)

                '���v�Ɠd�b�ԍ�
                txtTEL.Text = SYCTIJAG00_C.gstrCTITELNO
                '�I���L�[��ێ�����
                hdnKEY_CLI_CD.Value = SYCTIJAG00_C.gstrCLI_CD
                'hdnKEY_JA_CD.Value = SYCTIJAG00_C.gstrHAN_CD        '2013/12/09 T.Ono add �Ď����P2013
                hdnKEY_HAN_CD.Value = SYCTIJAG00_C.gstrHAN_CD
                hdnKEY_USER_CD.Value = SYCTIJAG00_C.gstrUSER_CD

                '�b�s�h���o�^�t���O
                hdnMOVE_MITOKBN.Value = "1"

                '�����{�^���������Ɠ��l�̏������s�����ۂ�
                hdnSelectClick.Value = SYCTIJAG00_C.gstrKENFLG
            Else
                '�b�s�h���o�^�t���O(�b�s�h�ɂĈ�ӂŖ��������ꍇ�̂݃Z�b�g����)
                hdnMOVE_MITOKBN.Value = ""

                If Request.Form("hdnMyAspx") = "KETAIJAG00" Then
                    '�Ď��Z���^�[�R�[�h
                    list = cboKANSCD.Items.FindByValue(Request.Form("hdnMOVE_KANSCD"))
                    cboKANSCD.SelectedIndex = cboKANSCD.Items.IndexOf(list)
                    '���v�Ɠd�b�ԍ�
                    txtTEL.Text = Request.Form("hdnMOVE_TEL")
                    '�����ԍ��폜 2016/11/16 H.Mori del 2016���P�J�� No2-3 
                    ''�����ԍ� 2014/12/02 H.Hosoda add �Ď����P2014 No.6
                    'txtNCUTEL.Text = Request.Form("hdnMOVE_NCUTEL")
                    '���v�Ɩ�
                    txtNAME.Text = Request.Form("hdnMOVE_NAME")
                    '�J�i�폜 2016/11/16 H.Mori del 2016���P�J�� No2-4
                    ''���v�Ɩ��J�i
                    'txtKANA.Text = Request.Form("hdnMOVE_KANAD")
                    '���v�ƏZ�� 2013/12/09 T.Ono add �Ď����P2013
                    txtADDR.Text = Request.Form("hdnMOVE_ADDR")
                    '�N���C�A���g�R�[�h
                    hdnCLI_CD.Value = Request.Form("hdnMOVE_CLI_CD")
                    '�N���C�A���g��
                    txtCLI_CD.Text = Request.Form("hdnMOVE_CLI_CD_NAME")
                    '�N���C�A���gTo�R�[�h 2019/11/01 T.Ono add �Ď����P2019 No1
                    hdnCLI_CD_TO.Value = Request.Form("hdnMOVE_CLI_CD_TO")
                    '�N���C�A���gTo�� 2019/11/01 T.Ono add �Ď����P2019 No1
                    txtCLI_CD_TO.Text = Request.Form("hdnMOVE_CLI_CD_TO_NAME")
                    '�i�`�R�[�h 2013/12/09 T.Ono add �Ď����P2013
                    hdnJA_CD.Value = Request.Form("hdnMOVE_JA_CD")
                    '�i�`�� 2013/12/09 T.Ono add �Ď����P2013
                    txtJA_CD.Text = Request.Form("hdnMOVE_JA_CD_NAME")
                    '�i�`�R�[�h�ɕR�Â��N���C�A���g�R�[�h 2019/11/01 T.Ono add �Ď����P2019
                    hdnJA_CD_CLI.Value = Request.Form("hdnMOVE_JA_CD_CLI")
                    '�̔����Ǝ҃O���[�v�R�[�h 2014/12/03 H.Hosoda add �Ď����P2014 No.6
                    hdnHANGRP.Value = Request.Form("hdnMOVE_HAN_GRP")
                    '�̔����Ǝ҃O���[�v�� 2014/12/03 H.Hosoda add �Ď����P2014 7No.6
                    txtHANGRP.Text = Request.Form("hdnMOVE_HAN_GRP_NAME")
                    '2019/11/01 T.Ono del �Ď����P2019 ��1
                    ''�ً}�A����Gr 2016/11/22 H.Mori add 2016���P�J�� No2-1
                    'hdnKINRENGRP.Value = Request.Form("hdnMOVE_KINREN_GRP")
                    ''�ً}�A����Gr�� 2016/11/22 H.Mori add 2016���P�J�� No2-1
                    'txtKINRENGRP.Text = Request.Form("hdnMOVE_KINREN_GRP_NAME")
                    '�i�`�x���R�[�h
                    hdnHAN_CD.Value = Request.Form("hdnMOVE_HAN_CD")
                    '�i�`�x����
                    txtHAN_CD.Text = Request.Form("hdnMOVE_HAN_CD_NAME")
                    '�i�`�x�����ɕR�Â��N���C�A���g�R�[�h 2019/11/01 T.Ono add �Ď����P2019
                    hdnHAN_CD_CLI.Value = Request.Form("hdnMOVE_HAN_CD_CLI")
                    '�i�`�x���R�[�hTO 2016/11/24 H.Mori add 2016���P�J�� No2-2
                    hdnHAN_CD_TO.Value = Request.Form("hdnMOVE_HAN_CD_TO")
                    '�i�`�x����TO     2016/11/24 H.Mori add 2016���P�J�� No2-2
                    txtHAN_CD_TO.Text = Request.Form("hdnMOVE_HAN_CD_NAME_TO")
                    '�i�`�x����TO�ɕR�Â��N���C�A���g�R�[�h 2019/11/01 T.Ono add �Ď����P2019
                    hdnHAN_CD_TO_CLI.Value = Request.Form("hdnMOVE_HAN_CD_TO_CLI")
                    '���q�l���R�[�h
                    txtUSER_CD.Text = Request.Form("hdnMOVE_USER_CD")
                    '���q�l�t���O 2013/12/20 T.Ono add �Ď����P2013
                    ''���J��
                    If Request.Form("hdnMOVE_USER_FLG0") = "1" Then
                        chkUSER_FLG0.Checked = True
                    Else
                        chkUSER_FLG0.Checked = False
                    End If
                    ''�^�p��
                    If Request.Form("hdnMOVE_USER_FLG1") = "1" Then
                        chkUSER_FLG1.Checked = True
                    Else
                        chkUSER_FLG1.Checked = False
                    End If
                    ''�x�~��
                    If Request.Form("hdnMOVE_USER_FLG2") = "1" Then
                        chkUSER_FLG2.Checked = True
                    Else
                        chkUSER_FLG2.Checked = False
                    End If
                    '�̔��敪 2015/12/11 H.Mori add �Ď����P2015
                    ''���[�^��
                    If Request.Form("hdnMOVE_HANBAI_KBN1") = "1" Then
                        chkHANBAI_KBN1.Checked = True
                    Else
                        chkHANBAI_KBN1.Checked = False
                    End If
                    ''�{���x��
                    If Request.Form("hdnMOVE_HANBAI_KBN2") = "1" Then
                        chkHANBAI_KBN2.Checked = True
                    Else
                        chkHANBAI_KBN2.Checked = False
                    End If
                    ''����
                    If Request.Form("hdnMOVE_HANBAI_KBN3") = "1" Then
                        chkHANBAI_KBN3.Checked = True
                    Else
                        chkHANBAI_KBN3.Checked = False
                    End If
                    ''���̑�
                    If Request.Form("hdnMOVE_HANBAI_KBN4") = "1" Then
                        chkHANBAI_KBN4.Checked = True
                    Else
                        chkHANBAI_KBN4.Checked = False
                    End If
                    ''�f�[�^�Ȃ�
                    If Request.Form("hdnMOVE_HANBAI_KBN5") = "1" Then
                        chkHANBAI_KBN5.Checked = True
                    Else
                        chkHANBAI_KBN5.Checked = False
                    End If
                    ''��O
                    If Request.Form("hdnMOVE_HANBAI_KBN6") = "1" Then
                        chkHANBAI_KBN6.Checked = True
                    Else
                        chkHANBAI_KBN6.Checked = False
                    End If

                    '�I���L�[��ێ�����
                    hdnKEY_CLI_CD.Value = Request.Form("hdnKEY_CLI_CD")
                    hdnKEY_CLI_CD_TO.Value = Request.Form("hdnKEY_CLI_CD_TO")   '2019/11/01 T.Ono add �Ď����P2019 No1
                    hdnKEY_JA_CD.Value = Request.Form("hdnKEY_JA_CD")           '2013/12/09 T.Ono add �Ď����P2013
                    hdnKEY_HAN_GRP.Value = Request.Form("hdnKEY_HAN_GRP")       '2014/12/03 H.Hosoda add �Ď����P2014 No.6
                    'hdnKEY_KINREN_GRP.Value = Request.Form("hdnKEY_KINREN_GRP") '2016/11/22 H.Mori add �Ď����P2016 No2-1  2019/11/01 T.Ono dell �Ď����P2019 No1
                    hdnKEY_HAN_CD.Value = Request.Form("hdnKEY_HAN_CD")
                    hdnKEY_USER_CD.Value = Request.Form("hdnKEY_USER_CD")
                    hdnScrollTop.Value = Request.Form("hdnScrollTop")           '2013/12/10 T.Ono add �Ď����P2013

                    '--- ��2005/04/20 DEL�@Falcon�� -----------------
                    ''�����{�^���������Ɠ��l�̏������s��
                    'hdnSelectClick.Value = "1"
                    '--- ��2005/04/20 DEL�@Falcon�� -----------------

                    '--- ��2005/04/20 MOD�@Falcon�� -----------------
                    '�Ή����̓{�^�����������J�ڂ��߂��ė����ꍇ�͌��������͍s��Ȃ�
                    If Convert.ToString(Request.Form("hdnMOVE_MODE")) = "1" Then
                        '�����{�^���Ƀt�H�[�J�X���Z�b�g
                        strMsg.Append("Form1.btnSelect.focus();")
                    Else
                        '�����{�^���������Ɠ��l�̏������s��
                        hdnSelectClick.Value = "1"
                    End If
                    '--- ��2005/04/20 MOD�@Falcon�� -----------------
                Else
                    '�ʏ�̑J�ڎ�(���j���[���)
                    hdnSelectClick.Value = ""

                    '//------------------------------------------------
                    '<TODO>�t�H�[�J�X���Z�b�g����i�����\���Ȃ̂ŃL�[�ɃZ�b�g����j
                    strMsg.Append("Form1.cboKANSCD.focus();")
                End If
            End If
        Else
            '//--------------------------------------
            '//�Q��ڈȍ~���s�����
            '//--------------------------------------
        End If

        '//-------------------------------------------------
        '<TODO>�����̉��ID��HIDDEN��hdnMyAspx�ɏ������ށi�V�X�e�����ʁj
        hdnMyAspx.Value = "MSKOSJAG00"
        '//-------------------------------------------------
    End Sub

    '******************************************************************************
    '* �e�R���g���[���̐ݒ�l�̏�����
    '******************************************************************************
    Private Sub fncIni_format()

        '�R���{�쐬
        Call fncCombo_Creatr_KANSICD()     '�Ď��Z���^�[�R���{

        '//�Ď��Z���^�[�R�[�h-----------------------------
        'AD�ɂĎ����̊Ď��Z���^�[�R�[�h�������I������
        '�^�s�J������TOP��I��
        Dim list As New ListItem
        Dim strGROUPNAME As String = AuthC.pGROUPNAME
        Dim arrGroupName() As String = strGROUPNAME.Split(Convert.ToChar(","))
        '2017/10/25 H.Mori mod 2017���P�J�� No2-1 START
        'If Array.IndexOf(arrGroupName, AuthC.pGROUP_UNKOU) >= 0 Then '2017/07/20 H.Mori mod
        'If Array.IndexOf(arrGroupName, AuthC.pGROUP_UNKOU) >= 0 Or Array.IndexOf(arrGroupName, AuthC.pGROUP_EIGYOU) >= 0 Then
        '    '�^�s�J�����A�c�Ə�
        '    cboKANSCD.SelectedIndex = 0
        'Else
        '    list = cboKANSCD.Items.FindByValue(AuthC.pCENTERCD)
        '    cboKANSCD.SelectedIndex = cboKANSCD.Items.IndexOf(list)
        'End If
        '�Ď��Z���^�[�͋󔒂������I������
        cboKANSCD.SelectedIndex = 0
        '2017/10/25 H.Mori mod 2017���P�J�� No2-1 END
        '//-----------------------------------------------
        txtTEL.Text = ""
        'txtNCUTEL.Text = ""         '2014/12/02 H.Hosoda add �Ď����P2014 No.6 '2016/11/16 H.Mori del 2016���P�J�� No2-3
        txtNAME.Text = ""
        'txtKANA.Text = ""          '2016/11/16 H.Mori del 2016���P�J�� No2-4
        txtADDR.Text = ""           '2013/12/09 T.Ono add �Ď����P2013
        txtCLI_CD.Text = ""
        hdnCLI_CD.Value = ""
        txtCLI_CD_TO.Text = ""      '2019/11/01 T.Ono add �Ď����P2019 No1
        hdnCLI_CD_TO.Value = ""     '2019/11/01 T.Ono add �Ď����P2019 No1
        txtJA_CD.Text = ""          '2013/12/09 T.Ono add �Ď����P2013
        hdnJA_CD.Value = ""         '2013/12/09 T.Ono add �Ď����P2013
        hdnJA_CD_CLI.Value = ""     '2019/11/01 T.Ono add �Ď����P2019
        txtHANGRP.Text = ""         '2014/12/03 H.Hosoda add �Ď����P2014 No.6
        hdnHANGRP.Value = ""        '2014/12/03 H.Hosoda add �Ď����P2014 No.6
        txtHAN_CD.Text = ""         '2013/12/09 T.Ono add �Ď����P2013
        hdnHAN_CD.Value = ""
        hdnHAN_CD_CLI.Value = ""    '2019/11/01 T.Ono add �Ď����P2019
        '2019/11/01 T.Ono del �Ď����P2019 ��1
        'txtKINRENGRP.Text = ""        '2016/11/17 H.Mori add 2016���P�J�� No2-1
        'hdnKINRENGRP.Value = ""       '2016/11/17 H.Mori add 2016���P�J�� No2-1
        txtHAN_CD_TO.Text = ""        '2016/11/24 H.Mori add 2016���P�J�� No2-2
        hdnHAN_CD_TO.Value = ""       '2016/11/24 H.Mori add 2016���P�J�� No2-2
        hdnHAN_CD_TO_CLI.Value = ""   '2019/11/01 T.Ono add �Ď����P2019

        hdnKEY_CLI_CD.Value = ""
        hdnKEY_JA_CD.Value = ""     '2013/12/09 T.Ono add �Ď����P2013
        hdnKEY_HAN_CD.Value = ""
        hdnKEY_USER_CD.Value = ""
        hdnTaiouClick.Value = ""

        hdnScrollTop.Value = "0"    '2014/01/08 T.Ono add �Ď����P2013

    End Sub

    '******************************************************************************
    '*�@�T�@�v�F�i���ݏ�����n���v���p�e�B
    '*�@���@�l�F���o�����P�̒l��n��
    '******************************************************************************
    Public ReadOnly Property pCode1() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" OrElse hdnPopcrtl.Value = "7" Then
                'If hdnPopcrtl.Value = "1" Then  2019/11/01 T.Ono mod �Ď����P2019 No1
                If Request.Form("cboKANSCD").Length > 0 Then
                    '�Ď��Z���^�[���w�肳��Ă���ꍇ
                    strRec = Request.Form("cboKANSCD")  '//�N���C�A���g�R�[�h�ꗗ �w�肳�ꂽ�Ď��Z���^�[�R�[�h�z���̃N���C�A���g�R�[�h
                Else
                    strRec = AuthC.pAUTHCENTERCD        '//�N���C�A���g�R�[�h�ꗗ �`�c�F�؂̎g�p�\�Ď��Z���^�[�R�[�h
                End If
            ElseIf hdnPopcrtl.Value = "2" Then
                '2013/12/09 T.Ono mod �Ď����P2013
                'JA�R�[�h�ǉ��AJA�x���R�[�h��hdnPopcrtl.Value�J�艺��
                'strRec = hdnCLI_CD.Value                 '//�i�`�R�[�h�ꗗ '2014/01/21 T.Ono mod �Ď����P2013 Trim������
                strRec = hdnCLI_CD.Value.Trim           '//�i�`�R�[�h�ꗗ
            ElseIf hdnPopcrtl.Value = "3" Then
                '2014/12/04 H.Hosoda mod �Ď����P2014 No.6
                '�̔����Ǝ҃O���[�v�R�[�h�ǉ��AJA�x���R�[�h��hdnPopcrtl.Value�J�艺��
                strRec = hdnCLI_CD.Value.Trim           '//�̔����Ǝ҃O���[�v�R�[�h�ꗗ
                'ElseIf hdnPopcrtl.Value = "4" Then 
                'ElseIf hdnPopcrtl.Value = "4" Or hdnPopcrtl.Value = "6" Then '2016/11/24 H.Mori mod �Ď����P2016 No2-2
            ElseIf hdnPopcrtl.Value = "4" Then          '2019/11/01 T.Ono mod �Ď����P2019 No1
                'strRec = hdnCLI_CD.Value               '//�i�`�x���R�[�h�ꗗ '2014/01/21 T.Ono mod �Ď����P2013 Trim������
                strRec = hdnCLI_CD.Value.Trim           '//�i�`�x���R�[�h�ꗗ
                '2016/11/21 H.Mori mod �Ď����P2016 No2-1
                '�ً}�A����Gr�O���[�v�R�[�h�ǉ�
            ElseIf hdnPopcrtl.Value = "5" Then          '2016/11/21 H.Mori add �Ď����P2016 No2-1
                strRec = hdnCLI_CD.Value.Trim           '�ً}�A����Gr�O���[�v�R�[�h�ǉ�
            ElseIf hdnPopcrtl.Value = "6" Then '2019/11/01 T.Ono mod �Ď����P2019 No1
                strRec = hdnCLI_CD_TO.Value.Trim           '//�i�`�x��To�R�[�h�ꗗ
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�i���ݏ�����n���v���p�e�B�@'2013/12/09 T.Ono add �Ď����P2013
    '*�@���@�l�F(�i�`�R�[�h)                '201611/17 H.Mori �ً}�A����Gr�Ŏg�p����ꍇ������
    '******************************************************************************
    Public ReadOnly Property pCode2() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = ""
                Case "1", "7" '2019/11/01 T.Ono mod �Ď����P2019 No1
                    'Case "1"
                    strRec = ""
                Case "2"
                    strRec = ""
                Case "3"                                '2014/12/04 H.Hosoda mod �Ď����P2014 No.6
                    '2019/11/01 T.Ono mod �Ď����P2019 No1
                    'strRec = ""                         '�̔����Ǝ҃O���[�v�R�[�h�ǉ��AJA�x���R�[�h��hdnPopcrtl.Value�J�艺��
                    strRec = hdnCLI_CD_TO.Value.Trim
                    'Case "4"
                Case "4", "6"                           '2016/11/24 H.Mori mod �Ď����P2016 No2-2
                    'strRec = hdnJA_CD.Value            '2014/01/21 T.Ono mod �Ď����P2013 Trim������
                    strRec = hdnJA_CD.Value.Trim        '//�i�`�x���R�[�h�ꗗ
                Case "5"                                '2016/11/17 H.Mori add �Ď����P2016 No2-1
                    strRec = ""
                Case Else
                    strRec = ""
            End Select
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�i���ݏ�����n���v���p�e�B�@'2014/12/04 H.Hosoda add �Ď����P2014 No.6
    '*�@���@�l�F(�̔����Ǝ҃O���[�v�R�[�h)  
    '******************************************************************************
    Public ReadOnly Property pCode3() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = ""
                Case "1", "7" '2019/11/01 T.Ono mod �Ď����P2019 No1
                    'Case "1" 
                    strRec = ""
                Case "2"
                    '2019/11/01 T.Ono mod �Ď����P2019 No1
                    'strRec = ""
                    strRec = hdnCLI_CD_TO.Value.Trim
                Case "3"
                    strRec = ""
                    'Case "4"
                Case "4", "6"                            '2016/11/24 H.Mori mod �Ď����P2016 No2-2
                    strRec = hdnHANGRP.Value.Trim        '//�̔����Ǝ҃O���[�v�R�[�h�ꗗ
                Case "5"                                 '2016/11/17 H.Mori add �Ď����P2016 No2-1
                    strRec = ""
                Case Else
                    strRec = ""
            End Select
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�i���ݏ�����n���v���p�e�B(�ǉ�)�@'201611/21 H.Mori add �Ď����P2016 No2-1
    '*�@���@�l�FJA�x���̍i���ݏ����Ƃ��Ĉ���������Ȃ��������ߒǉ�  
    '******************************************************************************
    Public ReadOnly Property pCode4() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = ""
                Case "1", "7" '2019/11/01 T.Ono mod �Ď����P2019 No1
                    'Case "1"
                    strRec = ""
                Case "2"
                    strRec = ""
                Case "3"
                    strRec = ""
                Case "4", "6"
                    '2019/11/01 T.Ono mod �Ď����P2019 No1
                    'strRec = hdnKINRENGRP.Value.Trim
                    strRec = ""
                Case "5"
                    strRec = ""
                Case Else
                    strRec = ""
            End Select
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�o�͂���ꗗ�̖��O��n���v���p�e�B
    '*�@���@�l�F�|�b�v�A�b�v�̃^�C�g������n��
    '******************************************************************************
    Public ReadOnly Property pListName() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" OrElse hdnPopcrtl.Value = "7" Then
                'If hdnPopcrtl.Value = "1" Then '2019/11/01 T.Ono mod �Ď����P2019 No1
                strRec = "�N���C�A���g�R�[�h�ꗗ"
            ElseIf hdnPopcrtl.Value = "2" Then
                '2013/12/09 T.Ono mod �Ď����P2013
                'JA�R�[�h�ǉ��AJA�x���R�[�h��hdnPopcrtl.Value�J�艺��
                strRec = "�i�`�R�[�h�ꗗ"
            ElseIf hdnPopcrtl.Value = "3" Then
                '2014/12/04 H.Hosoda mod �Ď����P2014 No.6
                '�̔����Ǝ҃O���[�v�R�[�h�ǉ��AJA�x���R�[�h��hdnPopcrtl.Value�J�艺��
                strRec = "�̔����Ǝ҃O���[�v�ꗗ"
                '2016/11/24 H.Mori mod �Ď����P2016 No2-2
                'ElseIf hdnPopcrtl.Value = "4"
            ElseIf hdnPopcrtl.Value = "4" Or hdnPopcrtl.Value = "6" Then
                strRec = "�i�`�x���R�[�h�ꗗ"
                '2016/11/17 H.Mori add �Ď����P2016 No2-1
                '�ً}�A����Gr�O���[�v�R�[�h�ǉ�
            ElseIf hdnPopcrtl.Value = "5" Then
                strRec = "�ً}�A����Gr�ꗗ"
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�o�͂���ꗗ�𐧌䂷��l��n���v���p�e�B
    '*�@���@�l�F�|�b�v�A�b�v�̎�ނ�I������
    '******************************************************************************
    Public ReadOnly Property pListCd() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" OrElse hdnPopcrtl.Value = "7" Then
                'If hdnPopcrtl.Value = "1" Then '2019/11/01 T.Ono mod �Ď����P2019 No1
                strRec = "CLI"
            ElseIf hdnPopcrtl.Value = "2" Then
                '2013/12/09 T.Ono mod �Ď����P2013
                'JA�R�[�h�ǉ��AJA�x���R�[�h��hdnPopcrtl.Value�J�艺��(2��3)
                strRec = "JA"
            ElseIf hdnPopcrtl.Value = "3" Then
                '2013/12/09 T.Ono mod �Ď����P2013
                '�̔����Ǝ҃O���[�v�R�[�h�ǉ��AJA�x���R�[�h��hdnPopcrtl.Value�J�艺��(3��4)
                strRec = "HANG"
                '2016/11/24 H.Mori mod �Ď����P2016 No2-2
                'ElseIf hdnPopcrtl.Value = "4"
            ElseIf hdnPopcrtl.Value = "4" Or hdnPopcrtl.Value = "6" Then
                'strRec = "JASS"
                'strRec = "JASS2"      '--- 2005/05/24 MOD Falcon ---
                strRec = "JASS"      '--- 2008/02/27 MOD T.Watabe ---
                '2016/11/17 H.Mori add �Ď����P2016 No2-1
                '�ً}�A����Gr�O���[�v�R�[�h�ǉ�
            ElseIf hdnPopcrtl.Value = "5" Then
                strRec = "JAHOKOKU2"
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�R�[�h��Ԃ��I�u�W�F�N�g�̖��O�l��n���v���p�e�B
    '*�@���@�l�F�f�[�^�I����A�R�[�h��Ԃ��I�u�W�F�N�g�����w�肷��
    '******************************************************************************
    Public ReadOnly Property pBackCode() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "hdnCLI_CD"
            ElseIf hdnPopcrtl.Value = "2" Then
                '2013/12/09 T.Ono mod �Ď����P2013
                'JA�R�[�h�ǉ��AJA�x���R�[�h��hdnPopcrtl.Value�J�艺��(2��3)
                strRec = "hdnJA_CD"
            ElseIf hdnPopcrtl.Value = "3" Then
                '2014/12/04 H.Hosoda mod �Ď����P2014 No.6
                '�̔����Ǝ҃O���[�v�R�[�h�ǉ��AJA�x���R�[�h��hdnPopcrtl.Value�J�艺��(3��4)
                strRec = "hdnHANGRP"
            ElseIf hdnPopcrtl.Value = "4" Then
                strRec = "hdnHAN_CD"

                '2019/11/01 T.Ono �Ď����P2019 No1
                'ElseIf hdnPopcrtl.Value = "5" Then
                ''2016/11/17 H.Mori add �Ď����P2016 No2-1
                ''�ً}�A����Gr�O���[�v�R�[�h�ǉ�
                'strRec = "hdnKINRENGRP"
            ElseIf hdnPopcrtl.Value = "6" Then
                '2016/11/24 H.Mori add �Ď����P2016 No2-2
                'JA�x����TO�ǉ�
                strRec = "hdnHAN_CD_TO"
            ElseIf hdnPopcrtl.Value = "7" Then
                '2019/11/01 T.Ono add �Ď����P2019
                strRec = "hdnCLI_CD_TO"
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F���̂�Ԃ��I�u�W�F�N�g�̖��O�l��n���v���p�e�B
    '*�@���@�l�F�f�[�^�I����A���̂�Ԃ��I�u�W�F�N�g�����w�肷��
    '******************************************************************************
    Public ReadOnly Property pBackName() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "txtCLI_CD"
            ElseIf hdnPopcrtl.Value = "2" Then
                '2013/12/09 T.Ono mod �Ď����P2013
                'JA�R�[�h�ǉ��AJA�x���R�[�h��hdnPopcrtl.Value�J�艺��(2��3)
                strRec = "txtJA_CD"
            ElseIf hdnPopcrtl.Value = "3" Then
                '2014/12/04 H.Hosoda mod �Ď����P2014 No.6
                '�̔����Ǝ҃O���[�v�R�[�h�ǉ��AJA�x���R�[�h��hdnPopcrtl.Value�J�艺��(3��4)
                strRec = "txtHANGRP"
            ElseIf hdnPopcrtl.Value = "4" Then
                strRec = "txtHAN_CD"

                '2019/11/01 T.Ono del �Ď����P2019 No1
                'ElseIf hdnPopcrtl.Value = "5" Then
                ''2016/11/17 H.Mori add �Ď����P2016 No2-1
                ''�ً}�A����Gr�O���[�v�R�[�h�ǉ�
                'strRec = "txtKINRENGRP"
            ElseIf hdnPopcrtl.Value = "6" Then
                '2016/11/24 H.Mori add �Ď����P2016 No2-2
                'JA�x����TO�ǉ�
                strRec = "txtHAN_CD_TO"
            ElseIf hdnPopcrtl.Value = "7" Then
                '2019/11/01 T.Ono add �Ď����P2019
                strRec = "txtCLI_CD_TO"
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�R�[�h��Ԃ��I�u�W�F�N�g�̖��O�l��n���v���p�e�B 2019/11/01 T.Ono add �Ď����P2019
    '*�@���@�l�F�f�[�^�I����A�R�[�h��Ԃ��I�u�W�F�N�g�����w�肷��
    '******************************************************************************
    Public ReadOnly Property pBackCode2() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = "hdnJA_CD_CLI"
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "4" Then
                strRec = "hdnHAN_CD_CLI"
            ElseIf hdnPopcrtl.Value = "6" Then
                strRec = "hdnHAN_CD_TO_CLI"
            ElseIf hdnPopcrtl.Value = "7" Then
                strRec = ""
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�t�H�[�J�X�Z�b�g����鍀�ږ���Ԃ��I�u�W�F�N�g���w��
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pBackFocs() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "btnCLI_CD"
            ElseIf hdnPopcrtl.Value = "2" Then
                '2013/12/09 T.Ono mod �Ď����P2013
                'JA�R�[�h�ǉ��AJA�x���R�[�h��hdnPopcrtl.Value�J�艺��(2��3)
                strRec = "btnJA_CD"
            ElseIf hdnPopcrtl.Value = "3" Then
                '2014/12/04 H.Hosoda mod �Ď����P2014 No.6
                '�̔����Ǝ҃O���[�v�R�[�h�ǉ��AJA�x���R�[�h��hdnPopcrtl.Value�J�艺��(3��4)
                strRec = "btnHANGRP"
            ElseIf hdnPopcrtl.Value = "4" Then
                strRec = "btnHAN_CD"

                '2019/11/01 T.Ono del �Ď����P2019 No1
                'ElseIf hdnPopcrtl.Value = "5" Then
                '2016/11/17 H.Mori add �Ď����P2016 No2-1
                '�ً}�A����Gr�O���[�v�R�[�h�ǉ�
                '    strRec = "btnKINRENGRP"
            ElseIf hdnPopcrtl.Value = "6" Then
                '2016/11/24 H.Mori add �Ď����P2016 No2-2
                'JA�x����TO�ǉ�
                strRec = "btnHAN_CD_TO"
            ElseIf hdnPopcrtl.Value = "7" Then
                '2019/11/01 T.Ono add �Ď����P2019 No1
                '�N���C�A���g�R�[�hTo�ǉ�
                strRec = "btnCLI_CD_TO"
            Else
                strRec = ""
            End If

            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F���^�[����Ɏ��s�����i�r�@2019/11/01 T.Ono add �Ď����P2019
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pBackScript() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "fncSetTo"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "4" Then
                strRec = "fncSetTo"
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�FJA�x���R�[�h�̃N���A�itxt�j
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pClear1() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "txtHAN_CD"
            ElseIf hdnPopcrtl.Value = "2" Then
                'strRec = "" 2013/12/09 T.Ono mod �Ď����P2013
                strRec = "txtHAN_CD"
            ElseIf hdnPopcrtl.Value = "3" Then  '2014/12/04 H.Hosoda add �Ď����P2014 No.6
                strRec = "txtHAN_CD"

                '2019/11/01 T.Ono del �Ď����P2019 No1
                'ElseIf hdnPopcrtl.Value = "5" Then  '2016/11/17 H.Mori add �Ď����P2016 No2-1
                'strRec = "txtHAN_CD"
            ElseIf hdnPopcrtl.Value = "7" Then  '2019/11/01 T.Ono add �Ď����P2019 No1
                strRec = "txtHAN_CD"
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�FJA�x���R�[�h�̃N���A�ihdn�j
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pClear2() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "hdnHAN_CD"
            ElseIf hdnPopcrtl.Value = "2" Then
                'strRec = ""  T.Ono mod �Ď����P2013
                strRec = "hdnHAN_CD"
            ElseIf hdnPopcrtl.Value = "3" Then  '2014/12/04 H.Hosoda add �Ď����P2014 No.6
                strRec = "hdnHAN_CD"

                '2019/11/01 T.Ono �Ď����PNo1
                'ElseIf hdnPopcrtl.Value = "5" Then  '2016/11/17 H.Mori add �Ď����P2016 No2-1
                'strRec = "hdnHAN_CD"
            ElseIf hdnPopcrtl.Value = "7" Then  '2019/11/01 T.Ono add �Ď����P2019 No1
                strRec = "hdnHAN_CD"
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�FJA�R�[�h�̃N���A�itxt�j 2013/12/09 T.Ono add �Ď����P2013
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pClear3() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "txtJA_CD"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "7" Then  '2019/11/01 T.Ono add �Ď����P2019 No1
                strRec = "txtJA_CD"
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�FJA�R�[�h�̃N���A�ihdn�j 2013/12/09 T.Ono add �Ď����P2013
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pClear4() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "hdnJA_CD"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "7" Then  '2019/11/01 T.Ono add �Ď����P2019 No1
                strRec = "hdnJA_CD"
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�̔����Ǝ҃O���[�v�R�[�h�̃N���A�itxt�j 2014/12/04 H.Hosoda add �Ď����P2014 No.6
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pClear5() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "txtHANGRP"
            ElseIf hdnPopcrtl.Value = "7" Then  '2019/11/01 T.Ono add �Ď����P2019 No1
                strRec = "txtHANGRP"
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�̔����Ǝ҃O���[�v�R�[�h�̃N���A�ihdn�j 2014/12/04 H.Hosoda add �Ď����P2014 No.6
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pClear6() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "hdnHANGRP"
            ElseIf hdnPopcrtl.Value = "7" Then  '2019/11/01 T.Ono add �Ď����P2019 No1
                strRec = "hdnHANGRP"
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�N���C�A���g�R�[�hTo�̃N���A�itxt�j 
    '*�@���@�l�F2019/11/01 T.Ono �Ď����P2019 No1
    '*�@�@�@�@�@�ً}�A��Gr�̃N���A����N���C�A���g�R�[�h�̃N���A�ɕύX
    '******************************************************************************
    Public ReadOnly Property pClear7() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                'strRec = "txtKINRENGRP"
                strRec = "txtCLI_CD_TO"
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�N���C�A���g�R�[�hTo�̃N���A�ihdn�j
    '*�@���@�l�F2019/11/01 T.Ono �Ď����P2019 No1
    '*�@�@�@�@�@�ً}�A��Gr�̃N���A����N���C�A���g�R�[�h�̃N���A�ɕύX
    '******************************************************************************
    Public ReadOnly Property pClear8() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                'strRec = "hdnKINRENGRP"
                strRec = "hdnCLI_CD_TO"
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�FJA�x��TO�̃N���A�itxt�j 2016/11/24 H.Mori add �Ď����P2016 No2-2
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pClear9() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "txtHAN_CD_TO"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = "txtHAN_CD_TO"
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = "txtHAN_CD_TO"
            ElseIf hdnPopcrtl.Value = "5" Then
                strRec = "txtHAN_CD_TO"
            ElseIf hdnPopcrtl.Value = "7" Then  '2019/11/01 T.Ono add �Ď����P2019 No1
                strRec = "txtHAN_CD_TO"
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�FJA�x��TO�̃N���A�ihdn�j 2016/11/24 H.Mori add �Ď����P2016 No2-2
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pClear10() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "hdnHAN_CD_TO"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = "hdnHAN_CD_TO"
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = "hdnHAN_CD_TO"
            ElseIf hdnPopcrtl.Value = "5" Then
                strRec = "hdnHAN_CD_TO"
            ElseIf hdnPopcrtl.Value = "7" Then  '2019/11/01 T.Ono add �Ď����P2019 No1
                strRec = "hdnHAN_CD_TO"
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�N���A 2019/11/01 T.Ono add �Ď����P2019
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pClear11() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "hdnJA_CD_CLI"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = "hdnJA_CD_CLI"
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "4" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "5" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "6" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "7" Then
                strRec = "hdnJA_CD_CLI"
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�N���A 2019/11/01 T.Ono add �Ď����P2019
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pClear12() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "hdnHAN_CD_CLI"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = "hdnHAN_CD_CLI"
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = "hdnHAN_CD_CLI"
            ElseIf hdnPopcrtl.Value = "4" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "5" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "6" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "7" Then
                strRec = "hdnHAN_CD_CLI"
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�N���A 2019/11/01 T.Ono add �Ď����P2019
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pClear13() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "hdnHAN_CD_TO_CLI"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = "hdnHAN_CD_TO_CLI"
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = "hdnHAN_CD_TO_CLI"
            ElseIf hdnPopcrtl.Value = "4" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "5" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "6" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "7" Then
                strRec = "hdnHAN_CD_TO_CLI"
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property
    '<TODO>���������Ƃ���IFRAME��ʂɈ����n�������lReadOnly�v���p�e�B�Őݒ肷��
    '******************************************************************************
    '*�@�T�@�v�F�Ď��Z���^�[�R�[�h�̒l��n���v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pKANSCD() As String
        Get
            Return Request.Form("cboKANSCD")
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F���v�Ɠd�b�ԍ��̒l��n���v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pTEL() As String
        Get
            Return txtTEL.Text
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�����ԍ��̒l��n���v���p�e�B '2014/12/02 H.Hosoda add �Ď����P2014 No.6
    '*�@���@�l�F2016/11/16 H.Mori del 2016���P�J�� No2-3 
    '******************************************************************************
    'Public ReadOnly Property pNCUTEL() As String
    '    Get
    '        Return txtNCUTEL.Text
    '    End Get
    'End Property

    '******************************************************************************
    '*�@�T�@�v�F���v�Ɩ��̒l��n���v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pNAME() As String
        Get
            '2014/04/09 T.Ono mod
            'Return txtNAME.Text
            Return txtNAME.Text.Trim
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F���v�Ɩ��J�i�̒l��n���v���p�e�B
    '*�@���@�l�F'2016/11/16 H.Mori del 2016���P�J�� No2-4
    '******************************************************************************
    'Public ReadOnly Property pKANA() As String
    '    Get
    '        '2014/04/09 T.Ono mod
    '        'Return txtKANA.Text
    '        Return txtKANA.Text.Trim

    '    End Get
    'End Property

    '******************************************************************************
    '*�@�T�@�v�F���v�ƏZ���̒l��n���v���p�e�B�@2013/12/05 T.Ono add �Ď����P2013
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pADDR() As String
        Get
            '2014/04/09 T.Ono mod
            'Return txtADDR.Text
            Return txtADDR.Text.Trim
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�N���C�A���g�R�[�h�̒l��n���v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pCLI_CD() As String
        Get
            Return hdnCLI_CD.Value.Trim     '2012/04/04 NEC ou Add Upd
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�N���C�A���g���̒l��n���v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pCLI_CD_NAME() As String
        Get
            Return txtCLI_CD.Text
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�N���C�A���gTo�R�[�h�̒l��n���v���p�e�B 2019/11/01 T.Ono add �Ď����P2019 No1
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pCLI_CD_TO() As String
        Get
            Return hdnCLI_CD_TO.Value.Trim
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�N���C�A���gTo���̒l��n���v���p�e�B  2019/11/01 T.Ono add �Ď����P2019 No1
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pCLI_CD_TO_NAME() As String
        Get
            Return txtCLI_CD_TO.Text
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�i�`�R�[�h�̒l��n���v���p�e�B�@'2013/12/09 T.ono add �Ď����P2013
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pJA_CD() As String
        Get
            Return hdnJA_CD.Value.Trim
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�i�`�R�[�h�̒l��n���v���p�e�B�@'2013/12/09 T.ono add �Ď����P2013
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pJA_CD_NAME() As String
        Get
            Return txtJA_CD.Text
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�i�`�R�[�h�ɕR�Â��N���C�A���g�R�[�h�̒l��n���v���p�e�B '2019/11/01 T.Ono add �Ď����P2019
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pJA_CD_CLI() As String
        Get
            Return hdnJA_CD_CLI.Value.Trim
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�̔����Ǝ҃O���[�v�R�[�h�̒l��n���v���p�e�B�@'2014/12/03 H.hosoda add �Ď����P2014 No.6
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pHAN_GRP() As String
        Get
            Return hdnHANGRP.Value.Trim
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�̔����Ǝ҃O���[�v�R�[�h�̒l��n���v���p�e�B�@'2014/12/03 T.hosoda add �Ď����P2014 No.6
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pHAN_GRP_NAME() As String
        Get
            Return txtHANGRP.Text
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�ً}�A����Gr�̒l��n���v���p�e�B�@'2016/11/22 H.Mori add �Ď����P2016 No2-1
    '*�@���@�l�F2019/11/01 T.Ono del �Ď����P2019 ��1
    '******************************************************************************
    'Public ReadOnly Property pKINREN_GRP() As String
    '    Get
    '        Return hdnKINRENGRP.Value.Trim
    '    End Get
    'End Property

    '******************************************************************************
    '*�@�T�@�v�F�ً}�A����Gr�̒l��n���v���p�e�B�@'2016/11/22 H.Mori add �Ď����P2016 No2-1
    '*�@���@�l�F2019/11/01 T.Ono del �Ď����P2019 ��1
    '******************************************************************************
    'Public ReadOnly Property pKINREN_GRP_NAME() As String
    '    Get
    '        Return txtKINRENGRP.Text
    '    End Get
    'End Property

    '******************************************************************************
    '*�@�T�@�v�F�i�`�x���R�[�h�̒l��n���v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pHAN_CD() As String
        Get
            Return hdnHAN_CD.Value.Trim     '2012/04/04 NEC ou Add Upd
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�i�`�x���R�[�h�̒l��n���v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pHAN_CD_NAME() As String
        Get
            Return txtHAN_CD.Text
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�i�`�x���R�[�h�ɕR�Â��N���C�A���g�R�[�h�̒l��n���v���p�e�B�@'2019/11/01 T.Ono add �Ď����P2019
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pHAN_CD_CLI() As String
        Get
            Return hdnHAN_CD_CLI.Value.Trim
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�i�`�x���R�[�hTO�̒l��n���v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pHAN_CD_TO() As String
        Get
            Return hdnHAN_CD_TO.Value.Trim
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�i�`�x���R�[�hTO�̒l��n���v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pHAN_CD_NAME_TO() As String
        Get
            Return txtHAN_CD_TO.Text
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�i�`�x���R�[�hTO�ɕR�Â��N���C�A���g�R�[�h�̒l��n���v���p�e�B�@'2019/11/01 T.Ono add �Ď����P2019
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pHAN_CD_TO_CLI() As String
        Get
            Return hdnHAN_CD_TO_CLI.Value.Trim
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F���q�l�R�[�h�̒l��n���v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pUSER_CD() As String
        Get
            Return txtUSER_CD.Text
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F���q�lFLG�i���J�ʁj�̒l��n���v���p�e�B�@2013/12/05 T.Ono add �Ď����P2013
    '*�@���@�l�F0�F�`�F�b�N�Ȃ��@1�F�`�F�b�N����
    '******************************************************************************
    Public ReadOnly Property pUSER_FLG0() As String
        Get
            If chkUSER_FLG0.Checked = False Then
                Return "0"
            Else
                Return "1"
            End If
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F���q�lFLG�i�^�p���j�̒l��n���v���p�e�B�@2013/12/05 T.Ono add �Ď����P2013
    '*�@���@�l�F0�F�`�F�b�N�Ȃ��@1�F�`�F�b�N����
    '******************************************************************************
    Public ReadOnly Property pUSER_FLG1() As String
        Get
            If chkUSER_FLG1.Checked = False Then
                Return "0"
            Else
                Return "1"
            End If
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F���q�lFLG�i�x�~���j�̒l��n���v���p�e�B�@2013/12/05 T.Ono add �Ď����P2013
    '*�@���@�l�F0�F�`�F�b�N�Ȃ��@1�F�`�F�b�N����
    '******************************************************************************
    Public ReadOnly Property pUSER_FLG2() As String
        Get
            If chkUSER_FLG2.Checked = False Then
                Return "0"
            Else
                Return "1"
            End If
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�̔��敪�i���[�^���j�̒l��n���v���p�e�B�@2015/12/11 H.Mori add �Ď����P2015
    '*�@���@�l�F0�F�`�F�b�N�Ȃ��@1�F�`�F�b�N����
    '******************************************************************************
    Public ReadOnly Property pHANBAI_KBN1() As String
        Get
            If chkHANBAI_KBN1.Checked = False Then
                Return "0"
            Else
                Return "1"
            End If
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�̔��敪�i�{���x���j�̒l��n���v���p�e�B�@2015/12/11 H.Mori add �Ď����P2015
    '*�@���@�l�F0�F�`�F�b�N�Ȃ��@1�F�`�F�b�N����
    '******************************************************************************
    Public ReadOnly Property pHANBAI_KBN2() As String
        Get
            If chkHANBAI_KBN2.Checked = False Then
                Return "0"
            Else
                Return "1"
            End If
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�̔��敪�i�����j�̒l��n���v���p�e�B�@2015/12/11 H.Mori add �Ď����P2015
    '*�@���@�l�F0�F�`�F�b�N�Ȃ��@1�F�`�F�b�N����
    '******************************************************************************
    Public ReadOnly Property pHANBAI_KBN3() As String
        Get
            If chkHANBAI_KBN3.Checked = False Then
                Return "0"
            Else
                Return "1"
            End If
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�̔��敪�i���̑��j�̒l��n���v���p�e�B�@2015/12/11 H.Mori add �Ď����P2015
    '*�@���@�l�F0�F�`�F�b�N�Ȃ��@1�F�`�F�b�N����
    '******************************************************************************
    Public ReadOnly Property pHANBAI_KBN4() As String
        Get
            If chkHANBAI_KBN4.Checked = False Then
                Return "0"
            Else
                Return "1"
            End If
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�̔��敪�i�f�[�^�Ȃ��j�̒l��n���v���p�e�B�@2015/12/11 H.Mori add �Ď����P2015
    '*�@���@�l�F0�F�`�F�b�N�Ȃ��@1�F�`�F�b�N����
    '******************************************************************************
    Public ReadOnly Property pHANBAI_KBN5() As String
        Get
            If chkHANBAI_KBN5.Checked = False Then
                Return "0"
            Else
                Return "1"
            End If
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�̔��敪�i��O�j�̒l��n���v���p�e�B�@2015/12/11 H.Mori add �Ď����P2015
    '*�@���@�l�F0�F�`�F�b�N�Ȃ��@1�F�`�F�b�N����
    '******************************************************************************
    Public ReadOnly Property pHANBAI_KBN6() As String
        Get
            If chkHANBAI_KBN6.Checked = False Then
                Return "0"
            Else
                Return "1"
            End If
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

    '******************************************************************************
    '*�@�T�@�v�F�ꗗ�őI�������N���C�A���g�R�[�h�̒l��n���v���p�e�B
    '*�@���@�l�F�Ή����͉�ʂ��߂��Ă������Ɏg�p
    '******************************************************************************
    Public ReadOnly Property pKEY_CLI_CD() As String
        Get
            Return hdnKEY_CLI_CD.Value
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�ꗗ�őI������JA�R�[�h�̒l��n���v���p�e�B�@2013/12/09 T.Ono add �Ď����P2013
    '*�@���@�l�F�Ή����͉�ʂ��߂��Ă������Ɏg�p
    '******************************************************************************
    Public ReadOnly Property pKEY_JA_CD() As String
        Get
            Return hdnKEY_JA_CD.Value
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�ꗗ�őI�������̔����Ǝ҃O���[�v�R�[�h�̒l��n���v���p�e�B�@2014/12/03 H.Hosoda add �Ď����P2014 No.6
    '*�@���@�l�F�Ή����͉�ʂ��߂��Ă������Ɏg�p
    '******************************************************************************
    Public ReadOnly Property pKEY_HAN_GRP() As String
        Get
            Return hdnKEY_HAN_GRP.Value
        End Get
    End Property

    '******************************************************************************
    '*�@2019/11/01 T.Ono del �Ď����P2019 No1
    '*�@�T�@�v�F�ꗗ�őI�������ً}�A����Gr�O���[�v�R�[�h�̒l��n���v���p�e�B�@2016/11/22 H.Mori add �Ď����P2016 No2-1
    '*�@���@�l�F�Ή����͉�ʂ��߂��Ă������Ɏg�p 
    '******************************************************************************
    'Public ReadOnly Property pKEY_KINREN_GRP() As String
    '    Get
    '        Return hdnKEY_KINREN_GRP.Value
    '    End Get
    'End Property

    '******************************************************************************
    '*�@�T�@�v�F�ꗗ�őI�������̔��X�R�[�h�̒l��n���v���p�e�B
    '*�@���@�l�F�Ή����͉�ʂ��߂��Ă������Ɏg�p
    '******************************************************************************
    Public ReadOnly Property pKEY_HAN_CD() As String
        Get
            Return hdnKEY_HAN_CD.Value
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�ꗗ�őI���������q�l�R�[�h�̒l��n���v���p�e�B
    '*�@���@�l�F�Ή����͉�ʂ��߂��Ă������Ɏg�p
    '******************************************************************************
    Public ReadOnly Property pKEY_USER_CD() As String
        Get
            Return hdnKEY_USER_CD.Value
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F���o�^�t���O
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pMITOKBN() As String
        Get
            Return hdnMOVE_MITOKBN.Value
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�X�N���[���o�[�̈ʒu��n���v���p�e�B�@2013/12/10 T.Ono add �Ď����P2013
    '*�@���@�l�F�Ή����͉�ʂ��߂��Ă������Ɏg�p
    '******************************************************************************
    Public ReadOnly Property pScrollTop() As String
        Get
            Return hdnScrollTop.Value
        End Get
    End Property

    '******************************************************************************
    '�R���{�{�b�N�X�̍쐬
    '******************************************************************************
    Private Sub fncCombo_Creatr_KANSICD()
        '//�Ď��Z���^�[�R���{
        Dim strGROUPNAME As String = AuthC.pGROUPNAME
        Dim arrGroupName() As String = strGROUPNAME.Split(Convert.ToChar(","))
        '2017/10/25 H.Mori mod 2017���P�J�� No2-1 START
        'If Array.IndexOf(arrGroupName, AuthC.pGROUP_UNKOU) >= 0 Then '2017/07/20 H.Mori mod
        'If Array.IndexOf(arrGroupName, AuthC.pGROUP_UNKOU) >= 0 Or strGROUPNAME.IndexOf(AuthC.pGROUP_EIGYOU) >= 0 Then
        '    '�J�����A�c�Ə��̏ꍇ�͖��I���n�j�@�e�Ď��Z���^�[�̏ꍇ�͊Ď��Z���^�[��I������
        '    cboKANSCD.pComboTitle = True
        'Else
        '    cboKANSCD.pComboTitle = False
        'End If
        cboKANSCD.pComboTitle = True
        '2017/10/25 H.Mori mod 2017���P�J�� No2-1 END
        cboKANSCD.pNoData = False
        cboKANSCD.pType = "KANSICENTER"
        cboKANSCD.pAllCenterCd = AuthC.pAUTHCENTERCD
        cboKANSCD.mMakeCombo()
    End Sub
    ' 2017/02/06 W.Ganeko 2016�Ď����P start
    '******************************************************************************
    ' Excel�o��(�`�F�b�N��)
    '******************************************************************************
    Private Sub btnExcel_ServerClick(ByVal sender As System.Object, _
                                    ByVal e As System.EventArgs) Handles btnExcel.ServerClick
        Dim strRec As String
        Dim MSKOSJAG00C As New MSKOSJAG00MSKOSJAW00.MSKOSJAW00
        Dim list As New ListItem

        Dim strRecMsg As String = ""
        Call fncCombo_Creatr_KANSICD()     '�Ď��Z���^�[�R���{
        list = cboKANSCD.Items.FindByValue(pKANSCD)
        cboKANSCD.SelectedIndex = cboKANSCD.Items.IndexOf(list)

        Dim strKANSCD As String = ""

        If pKANSCD.Trim.Length > 0 Then
            strKANSCD = "'" & pKANSCD & "'"
        Else
            '�Ď��Z���^�[�̎w�肪�Ȃ��ꍇ�́A�F�؃N���X����Z���^�[�R�[�h���擾
            Dim arrTemp() As String
            arrTemp = AuthC.pAUTHCENTERCD.Split(Convert.ToChar(","))
            For i As Integer = 0 To arrTemp.Length - 1
                If strKANSCD.Length > 0 Then
                    strKANSCD = strKANSCD & ","
                End If
                strKANSCD = strKANSCD & "'" & arrTemp(i) & "'"
            Next
        End If


        '2019/11/01 T.Ono mod �Ď����P2019 No1
        'strRec = MSKOSJAG00C.mExcel(
        '                 Me.Session.SessionID,
        '                 pKANSCD,
        '                 pTEL,
        '                 pNAME,
        '                 pADDR,
        '                 pCLI_CD,
        '                 pJA_CD,
        '                 pHAN_GRP,
        '                 pKINREN_GRP,
        '                 pHAN_CD,
        '                 pHAN_CD_TO,
        '                 pUSER_CD,
        '                 pUSER_FLG0,
        '                 pUSER_FLG1,
        '                 pUSER_FLG2,
        '                 pHANBAI_KBN1,
        '                 pHANBAI_KBN2,
        '                 pHANBAI_KBN3,
        '                 pHANBAI_KBN4,
        '                 pHANBAI_KBN5,
        '                 pHANBAI_KBN6
        '                 )
        strRec = MSKOSJAG00C.mExcel(
                         Me.Session.SessionID,
                         strKANSCD,
                         pTEL,
                         pNAME,
                         pADDR,
                         pCLI_CD,
                         pCLI_CD_TO,
                         pJA_CD,
                         pJA_CD_CLI,
                         pHAN_GRP,
                         pHAN_CD,
                         pHAN_CD_CLI,
                         pHAN_CD_TO,
                         pHAN_CD_TO_CLI,
                         pUSER_CD,
                         pUSER_FLG0,
                         pUSER_FLG1,
                         pUSER_FLG2,
                         pHANBAI_KBN1,
                         pHANBAI_KBN2,
                         pHANBAI_KBN3,
                         pHANBAI_KBN4,
                         pHANBAI_KBN5,
                         pHANBAI_KBN6
                         )

        If strRec.Substring(0, 5) = "ERROR" Then
            '�G���[�ł���΃u���E�U�Ƀ��b�Z�[�W�\��
            Dim ErrMsgC As New CErrMsg
            strRecMsg = "�V�X�e���G���[�F" & ErrMsgC.mGetArtMsg(strRec)
            strMsg.Append("alert('" & strRecMsg & "');")
            strMsg.Append("Form1.btnExcel.focus();")

        ElseIf strRec.Substring(0, 5) = "DATA0" Then
            '�f�[�^��0���̏ꍇ
            strRecMsg = "�Ώۃf�[�^�����݂��܂���"
            strMsg.Append("alert('" & strRecMsg & "');")
            strMsg.Append("Form1.btnExcel.focus();")

        ElseIf strRec.Substring(0, 5) = "OVER0" Then
            '�f�[�^��65536���̏ꍇ
            'HttpHeaderC.mDownLoadXLS(Response, "���q�l�������ʃ��X�g.xls")
            'Dim sb As New System.Text.StringBuilder(strRec)
            'sb.Replace("OVER0", "")
            ' ''�t�@�C�����M
            'Response.WriteFile(sb.ToString())
            strRecMsg = "�f�[�^���ő�s���𒴂��܂����B[�ő�65536�s]"
            strMsg.Append("alert('" & strRecMsg & "');")
            strMsg.Append("Form1.btnExcel.focus();")
        Else
            strMsg.Append("Form1.btnExcel.focus();")
            HttpHeaderC.mDownLoadXLS(Response, "���q�l�������X�g.xls")

            ''�t�@�C�����M
            Response.WriteFile(strRec)

            strRecMsg = "OK"
        End If

        strRec = strRecMsg
        '-------------------------------------------------
        '//�`�o���O��������
        Dim LogC As New CLog
        Dim strRecLog As String
        strRecLog = LogC.mAPLog(Me.Session.SessionID, AuthC.pUSERNAME, AuthC.pIPADDRESS, hdnMyAspx.Value, "4", strRec, Request.Form)
        If strRecLog <> "OK" Then
            Dim errmsgc As New CErrMsg
            strMsg.Append("alert('�V�X�e���G���[�F" & errmsgc.mGetArtMsg(strRecLog) & "');")
        End If
    End Sub
    ' 2017/02/06 W.Ganeko 2016�Ď����P end
End Class
