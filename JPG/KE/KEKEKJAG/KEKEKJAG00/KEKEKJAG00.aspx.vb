
'***********************************************
'�Ή����ʈꗗ  ���C�����
'***********************************************
'<TODO>�錾���ʎd�l
Option Explicit On
Option Strict On

'<TODO>�錾���ʎd�l
Imports Common
Imports JPG.Common
Imports JPG.Common.log
Imports System.Text

Partial Class KEKEKJAG00
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
            txtTKTANCD.Attributes.Add("ReadOnly", "true")
            txtKURACD.Attributes.Add("ReadOnly", "true")
            txtKURACD_TO.Attributes.Add("ReadOnly", "true") '2019/11/01 T.Ono add �Ď����P2019
            'txtHANGRP.Attributes.Add("ReadOnly", "true") '2014/12/08 H.Hosoda add �Ď����P2014 No.7 '2019/11/01 T.Ono del �Ď����P2019
            'txtKINRENGRP.Attributes.Add("ReadOnly", "true") '2016/11/25 H.Mori add �Ď����P2016 No3-1  '2019/11/01 T.Ono del �Ď����P2019
            txtACBNM.Attributes.Add("ReadOnly", "true")
            txtACBNM_TO.Attributes.Add("ReadOnly", "true") '2019/11/01 T.Ono add �Ď����P2019
            txtJANM.Attributes.Add("ReadOnly", "true") '2013/12/13 T.Ono add �Ď����P2013
            txtKMCD.Attributes.Add("ReadOnly", "true") '2013/12/13 T.Ono add �Ď����P2013
        End If
        '2012/04/03 NEC ou Add End

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
        '2005/12/03 NEC UPDATE START
        '[�Ή����ʈꗗ]�g�p�\����(�^:��/�c:��/��:��/�o:�~)
        'AuthC.fncAuthCheck(Server, AuthC.pGROUP_UNKOU & "," & AuthC.pGROUP_KANSHI)
        AuthC.fncAuthCheck(Server, AuthC.pGROUP_UNKOU & "," & AuthC.pGROUP_KANSHI & "," & AuthC.pGROUP_EIGYOU)
        '2005/12/03 NEC UPDATE START

        '//------------------------------------------
        '<TODO>�|�b�v�A�b�v/�o�^�n�t���[���̏o��
        '      [hdnKensaku(Hidden)]���쐬���鎖
        If hdnKensaku.Value = "COPOPUPG00" Then
            Server.Transfer("../../../Popup/COPOPUPG00.aspx")
        End If
        '//�Ή����ʈꗗ�o��
        If hdnKensaku.Value = "KEKEKJFG00" Then
            Server.Transfer("KEKEKJFG00.aspx")
        End If
        '//�J�����_�[�̏o��
        If hdnKensaku.Value = "COCALDRG00" Then
            Server.Transfer("../../../Popup/COCALDRG00.aspx")
        End If

        '//------------------------------------------
        '// Script�����ݗp�ϐ��錾
        Dim strScript As New StringBuilder("")
        Dim cscript1 As New CScript
        Dim strScriptPath As String

        Dim dbData As DataSet

        strScriptPath = ConfigurationSettings.AppSettings("SCRIPTPATH")

        '------------------------------------------------------------------------------
        '<TODO>HTML���ɕK�v��JavaScript/CSS�͂�����[strScript]�ϐ��Ɋi�[��
        '      ��ʏ�[lblScript]�ɏ������݂��s���܂�(SPAN�^�O�Ƃ��ăN���C�A���g�ɃX�N���v�g��
        '      �o�͂���܂��B)
        '      [lblScript(Label)]���쐬���鎖
        '//------------------------------------------
        '//�@JavaScript�i�[
        strScript.Append("<Script language=javascript>")
        '<�Ǝ��X�N���v�g>
        strScript.Append(cscript1.mWriteScript( _
             MyBase.MapPath("../../../KE/KEKEKJAG/KEKEKJAG00/") & "KEKEKJAG00.js"))
        '<�t�H�[�J�X�֘A�֐�>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncFo.js"))
        '<���t�֘A�֐�>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncDate.js"))
        '<���Ԋ֘A�֐�>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncTime.js"))
        '<�d�b�ԍ��`�F�b�N�֐�>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncTel.js"))
        '<�S�p�`�F�b�N�֐�>
        '--- ��2005/05/19 DEL Falcon�� ---
        'strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncZenkakuChk.js"))
        '--- ��2005/05/19 DEL Falcon�� ---

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

            '�Ή����͂���A���Ă�����ʑJ�ڂ̏ꍇ------------
            Dim list As New ListItem            '���X�g�A�C�e��
            If Request.Form("hdnMyAspx") = "KETAIJAG00" Then

                '�Ď��Z���^�[�R�[�h
                list = cboKANSCD.Items.FindByValue(Request.Form("hdnMOVE_KANSCD"))
                cboKANSCD.SelectedIndex = cboKANSCD.Items.IndexOf(list)
                '�Ώۊ��ԋ敪���W�I�{�^��  2017/10/26 H.Mori add 2017���P�J�� No3-1
                If Request.Form("hdnMOVE_KIKANKBN") = "1" Then
                    rdoKIKAN1.Checked = True '�Ή�������
                    rdoKIKAN2.Checked = False
                ElseIf Request.Form("hdnMOVE_KIKANKBN") = "2" Then
                    rdoKIKAN1.Checked = False
                    rdoKIKAN2.Checked = True '��M��
                End If
                '�������ԁiFrom�j   ���t�ҏW
                txtHATYMD_From.Text = fncDateSet(Request.Form("hdnMOVE_HATYMD_From"))
                '�������ԁiTo�j     ���t�ҏW
                txtHATYMD_To.Text = fncDateSet(Request.Form("hdnMOVE_HATYMD_To"))
                '���������iFrom�j   �����ҏW
                txtHATTIME_From.Text = fncTimeSet(Request.Form("hdnMOVE_HATTIME_From"), 0)
                '���������iTo�j     �����ҏW
                txtHATTIME_To.Text = fncTimeSet(Request.Form("hdnMOVE_HATTIME_To"), 0)
                '�Ď��Z���^�[�S���҃R�[�h
                hdnTKTANCD.Value = Request.Form("hdnMOVE_TKTANCD")
                '�Ď��Z���^�[�S���Җ�
                txtTKTANCD.Text = Request.Form("hdnMOVE_TKTANNM")
                '�����敪
                list = cboHATKBN.Items.FindByValue(Request.Form("hdnMOVE_HATKBN"))
                cboHATKBN.SelectedIndex = cboHATKBN.Items.IndexOf(list)
                '�Ή��敪
                '2014/12/04 H.Hosoda mod �Ď����P2014 No.7 START
                'list = cboTAIOKBN.Items.FindByValue(Request.Form("hdnMOVE_TAIOKBN"))
                'cboTAIOKBN.SelectedIndex = cboTAIOKBN.Items.IndexOf(list)
                ''�d�b
                If Request.Form("hdnMOVE_TAIOKBN1") = "1" Then
                    chkTAIOU_KBN1.Checked = True
                Else
                    chkTAIOU_KBN1.Checked = False
                End If
                ''�o��
                If Request.Form("hdnMOVE_TAIOKBN2") = "1" Then
                    chkTAIOU_KBN2.Checked = True
                Else
                    chkTAIOU_KBN2.Checked = False
                End If
                ''�d��
                If Request.Form("hdnMOVE_TAIOKBN3") = "1" Then
                    chkTAIOU_KBN3.Checked = True
                Else
                    chkTAIOU_KBN3.Checked = False
                End If
                '2014/12/04 H.Hosoda mod �Ď����P2014 No.7 END
                '�����敪
                list = cboTMSKB.Items.FindByValue(Request.Form("hdnMOVE_TMSKB"))
                cboTMSKB.SelectedIndex = cboTMSKB.Items.IndexOf(list)
                '���q�l�d�b�ԍ�
                txtJUTEL.Text = Request.Form("hdnMOVE_JUTEL")
                '�����ԍ�  2014/12/05 H.Hosoda add �Ď����P2014 No.7 2016/11/25 H.Mori del �Ď����P2016 No3-2
                'txtNCUTEL.Text = Request.Form("hdnMOVE_NCUTEL")
                '���q�l��
                txtJUSYONM.Text = Request.Form("hdnMOVE_JUSYONM")
                '���q�l���J�i�@2016/11/24 H.Mori del �Ď����P2016 No3-3
                'txtJUSYOKN.Text = Request.Form("hdnMOVE_JUSYOKN")
                '�N���C�A���g�R�[�h
                hdnKURACD.Value = Request.Form("hdnMOVE_KURACD")
                '�N���C�A���g��
                txtKURACD.Text = Request.Form("hdnMOVE_KURACD_NAME")
                '2019/11/01 T.Ono del �Ď����P2019 START
                '�N���C�A���gTO�R�[�h
                hdnKURACD_TO.Value = Request.Form("hdnMOVE_KURACD_TO")
                '�N���C�A���gTO��
                txtKURACD_TO.Text = Request.Form("hdnMOVE_KURACD_TO_NAME")
                '2019/11/01 T.Ono del �Ď����P2019 END
                '�i�`�R�[�h 2013/12/10 T.Ono add �Ď����P2013
                hdnJACD.Value = Request.Form("hdnMOVE_JA_CD")
                '�i�`�� 2013/12/10 T.Ono add �Ď����P2013
                txtJANM.Text = Request.Form("hdnMOVE_JA_CD_NAME")
                '�i�`�R�[�h�ɕR�Â��N���C�A���g�R�[�h 2019/11/01 T.Ono add �Ď����P2019
                hdnJACD_CLI.Value = Request.Form("hdnMOVE_JA_CD_CLI")
                '2019/11/01 T.Ono del �Ď����P2019 START
                ''�̔����Ǝ҃O���[�v�R�[�h 2014/12/08 H.Hosoda add �Ď����P2014 No.7
                'hdnHANGRP.Value = Request.Form("hdnMOVE_HAN_GRP")
                ''�̔����Ǝ҃O���[�v�� 2014/12/08 H.Hosoda add �Ď����P2014 No.7
                'txtHANGRP.Text = Request.Form("hdnMOVE_HAN_GRP_NAME")
                ''�ً}�A����Gr 2016/11/25 H.Mori add �Ď����P2016 No3-1
                'hdnKINRENGRP.Value = Request.Form("hdnMOVE_KINREN_GRP")
                ''�ً}�A����Gr�� 2016/11/25 H.Mori add �Ď����P2016 No3-1
                'txtKINRENGRP.Text = Request.Form("hdnMOVE_KINREN_GRP_NAME")
                '2019/11/01 T.Ono del �Ď����P2019 END
                '�i�`�x���R�[�h
                hdnACBCD.Value = Request.Form("hdnMOVE_ACBCD")
                '�i�`�x����
                txtACBNM.Text = Request.Form("hdnMOVE_ACBCD_NAME")
                '2019/11/01 T.Ono add �Ď����P2019 START
                '�i�`�x�����ɕR�Â��N���C�A���g�R�[�h
                hdnACBCD_CLI.Value = Request.Form("hdnMOVE_ACBCD_CLI")
                '�i�`�x���R�[�hTO
                hdnACBCD_TO.Value = Request.Form("hdnMOVE_ACBCD_TO")
                '�i�`�x����TO
                txtACBNM_TO.Text = Request.Form("hdnMOVE_ACBCD_TO_NAME")
                '�i�`�x����TO�ɕR�Â��N���C�A���g�R�[�h
                hdnACBCD_TO_CLI.Value = Request.Form("hdnMOVE_ACBCD_TO_CLI")
                '2019/11/01 T.Ono add �Ď����P2019 END
                '���q�l���R�[�h
                txtUSER_CD.Text = Request.Form("hdnMOVE_USER_CD")
                '2011.11.15 ADD H.Uema
                '�x��R�[�h
                'txtKMCD.Text = Request.Form("hdnMOVE_KMCD") 2013/12/10 T.Ono mod �Ď����P2013
                txtKMCD.Text = Request.Form("hdnMOVE_KMNM")
                hdnKMCD.Value = Request.Form("hdnMOVE_KMCD")
                '�I���L�[��ێ�����
                hdnKEY_KANSCD.Value = Request.Form("hdnKEY_KANSCD")
                hdnKEY_SYONO.Value = Request.Form("hdnKEY_SYONO")
                '�X�N���[���o�[
                hdnScrollTop.Value = Request.Form("hdnScrollTop")            '2013/12/10 T.Ono add �Ď����P2013
                '�����{�^���������Ɠ��l�̏������s��
                hdnSelectClick.Value = "1"
            Else
                '�ʏ�̑J�ڎ�(���j���[���)
                hdnSelectClick.Value = ""

                '��M���Ԃɓ������t��\���@2013/12/10 T.Ono add �Ď����P2013
                txtHATYMD_From.Text = DateTime.Today.ToString("yyyy/MM/dd")
                txtHATYMD_To.Text = DateTime.Today.ToString("yyyy/MM/dd")

                '//------------------------------------------------
                '<TODO>�t�H�[�J�X���Z�b�g����i�����\���Ȃ̂ŃL�[�ɃZ�b�g����j
                strMsg.Append("Form1.cboKANSCD.focus();")
            End If

        Else
            '//--------------------------------------
            '//�Q��ڈȍ~���s�����
            '//--------------------------------------

        End If

        '//-------------------------------------------------
        '<TODO>�����̉��ID��HIDDEN��hdnMyAspx�ɏ������ށi�V�X�e�����ʁj
        hdnMyAspx.Value = "KEKEKJAG00"
        '//-------------------------------------------------

    End Sub

    '******************************************************************************
    '* �e�R���g���[���̐ݒ�l�̏�����
    '******************************************************************************
    Private Sub fncIni_format()

        '�R���{�쐬
        Call fncCombo_Creatr_KANSI_CD()     '�Ď��Z���^�[�R���{
        Call fncCombo_Create_HASEIKBN()     '�����敪�R���{
        'Call fncCombo_Create_TAIOUKBN()    '�Ή��敪�R���{ '2014/12/04 H.Hosoda del �Ď����P2014 No.7
        Call fncCombo_Create_SYORIKBN()     '�����敪�R���{

        '//�Ď��Z���^�[�R�[�h-----------------------------
        'AD�ɂĎ����̊Ď��Z���^�[�R�[�h�������I������
        '�^�s�J������TOP��I��
        Dim list As New ListItem
        Dim strGROUPNAME As String = AuthC.pGROUPNAME
        Dim arrGroupName() As String = strGROUPNAME.Split(Convert.ToChar(","))
        '2005/12/03 NEC UPDATE START
        'If Array.IndexOf(arrGroupName, AuthC.pGROUP_UNKOU) >= 0 Then
        If Array.IndexOf(arrGroupName, AuthC.pGROUP_UNKOU) >= 0 Or Array.IndexOf(arrGroupName, AuthC.pGROUP_EIGYOU) >= 0 Then
            '2005/12/03 NEC UPDATE END
            '�^�s�J����
            cboKANSCD.SelectedIndex = 0
        Else
            list = cboKANSCD.Items.FindByValue(AuthC.pCENTERCD)
            cboKANSCD.SelectedIndex = cboKANSCD.Items.IndexOf(list)
        End If
        '//-----------------------------------------------
        txtHATYMD_From.Text = ""
        txtHATYMD_To.Text = ""
        txtHATTIME_From.Text = ""
        txtHATTIME_To.Text = ""
        cboHATKBN.SelectedIndex = 0

        '2014/12/04 H.Hosoda mod �Ď����P2014 No.7 START
        'cboTAIOKBN.SelectedIndex = 0 
        chkTAIOU_KBN1.Checked = True
        chkTAIOU_KBN2.Checked = True
        chkTAIOU_KBN3.Checked = False
        '2014/12/04 H.Hosoda mod �Ď����P2014 No.7 END

        cboTMSKB.SelectedIndex = 0

        hdnKEY_KANSCD.Value = ""
        hdnKEY_SYONO.Value = ""

        hdnScrollTop.Value = "0" '2014/01/09 T.Ono add �Ď����P2013

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
    '*�@�T�@�v�F�p�����[�^�l��莞��HHmmss�l��Ԃ�
    '*�@���@�l�F
    '******************************************************************************
    Public Function fncTimeGet(ByVal pstrTime As String) As String
        Dim TimeFncC As New CTimeFnc
        Dim strRec As String
        strRec = ""
        If pstrTime.Length <> 0 Then
            strRec = TimeFncC.mHenkanGet(pstrTime)
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

    '******************************************************************************
    '*�@�T�@�v�F�i���ݏ�����n���v���p�e�B
    '*�@���@�l�F���o�����P�̒l��n��
    '******************************************************************************
    Public ReadOnly Property pCode1() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                If Request.Form("cboKANSCD").Length > 0 Then
                    '�Ď��Z���^�[���w�肳��Ă���ꍇ
                    strRec = Request.Form("cboKANSCD")  '//�N���C�A���g�R�[�h�ꗗ �w�肳�ꂽ�Ď��Z���^�[�R�[�h�z���̃N���C�A���g�R�[�h
                Else
                    strRec = AuthC.pAUTHCENTERCD        '//�N���C�A���g�R�[�h�ꗗ �`�c�F�؂̎g�p�\�Ď��Z���^�[�R�[�h
                End If
                '2013/12/10 T.Ono mod �Ď����P2013 START
                'ElseIf hdnPopcrtl.Value = "2" Then
                '    strRec = hdnKURACD.Value                '//�i�`�x���R�[�h�ꗗ
                'ElseIf hdnPopcrtl.Value = "3" Then
                '    If Request.Form("cboKANSCD").Length > 0 Then
                '        '�Ď��Z���^�[���w�肳��Ă���ꍇ
                '        strRec = Request.Form("cboKANSCD")  '//�Ď��Z���^�[�S���҈ꗗ �w�肳�ꂽ�Ď��Z���^�[�R�[�h�z���̃N���C�A���g�R�[�h
                '    Else
                '        strRec = AuthC.pAUTHCENTERCD        '//�Ď��Z���^�[�S���҈ꗗ �`�c�F�؂̎g�p�\�Ď��Z���^�[�R�[�h
                '    End If
                'Else
                '    strRec = ""
                'End If
            ElseIf hdnPopcrtl.Value = "2" Then
                'strRec = hdnKURACD.Value                '//�i�`�R�[�h�ꗗ 2014/01/21 T.Ono mod �Ď����P2013 Trim������
                strRec = hdnKURACD.Value.Trim           '//�i�`�R�[�h�ꗗ
            ElseIf hdnPopcrtl.Value = "3" Then
                'strRec = hdnKURACD.Value                '//�i�`�x���R�[�h�ꗗ 2014/01/21 T.Ono mod �Ď����P2013 Trim������
                strRec = hdnKURACD.Value.Trim           '//�i�`�x���R�[�h�ꗗ
            ElseIf hdnPopcrtl.Value = "4" Then
                If Request.Form("cboKANSCD").Length > 0 Then
                    '�Ď��Z���^�[���w�肳��Ă���ꍇ
                    strRec = Request.Form("cboKANSCD")  '//�Ď��Z���^�[�S���҈ꗗ �w�肳�ꂽ�Ď��Z���^�[�R�[�h�z���̃N���C�A���g�R�[�h
                Else
                    strRec = AuthC.pAUTHCENTERCD        '//�Ď��Z���^�[�S���҈ꗗ �`�c�F�؂̎g�p�\�Ď��Z���^�[�R�[�h
                End If
            ElseIf hdnPopcrtl.Value = "5" Then
                strRec = "70"             '//�x��R�[�h�ꗗ�i�v���_�E���}�X�^�j
            ElseIf hdnPopcrtl.Value = "6" Then  '�̔����Ǝ҃O���[�v�R�[�h�ꗗ 2014/12/08 H.Hosoda add �Ď����P2014 No.7
                '2019/11/01 T.Ono mod �Ď����P2019 START
                '�N���C�A���gTo�ꗗ
                'strRec = hdnKURACD.Value.Trim
                If Request.Form("cboKANSCD").Length > 0 Then
                    '�Ď��Z���^�[���w�肳��Ă���ꍇ
                    strRec = Request.Form("cboKANSCD")  '//�N���C�A���g�R�[�h�ꗗ �w�肳�ꂽ�Ď��Z���^�[�R�[�h�z���̃N���C�A���g�R�[�h
                Else
                    strRec = AuthC.pAUTHCENTERCD        '//�N���C�A���g�R�[�h�ꗗ �`�c�F�؂̎g�p�\�Ď��Z���^�[�R�[�h
                End If
            ElseIf hdnPopcrtl.Value = "7" Then  '�ً}�A����Gr�ꗗ 2016/11/25 H.Mori add �Ď����P2016 No3-1
                'JA�x��To�ꗗ
                'strRec = hdnKURACD.Value.Trim
                strRec = hdnKURACD_TO.Value.Trim
                '2019/11/01 T.Ono mod �Ď����P2019 END
            Else
                strRec = ""
            End If
            '2013/12/10 T.Ono mod �Ď����P2013 END
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�i���ݏ�����n���v���p�e�B 2013/12/10 T.Ono mod �Ď����P2013
    '*�@���@�l�F���o�����Q�̒l��n��
    '******************************************************************************
    Public ReadOnly Property pCode2() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "1"
                    strRec = ""
                Case "2"
                    strRec = ""
                Case "3", "7"  '2019/11/01 T.Ono mod �Ď����P2019
                    'Case "3"
                    'strRec = hdnJACD.Value          2014/01/21 T.Ono mod �Ď����P2013 Trim������
                    strRec = hdnJACD.Value.Trim
                Case "4"
                    strRec = ""
                Case "5"
                    strRec = ""
                Case "6"              '2014/12/08 H.Hosoda add �Ď����P2014 No.7
                    strRec = ""
                Case Else
                    strRec = ""
            End Select
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�i���ݏ�����n���v���p�e�B 2014/12/08 H.Hosoda add �Ď����P2014 No.7
    '*�@���@�l�F���o�����R�̒l��n��
    '******************************************************************************
    Public ReadOnly Property pCode3() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "1"
                    strRec = ""
                Case "2"
                    '2019/11/01 T.Ono mod �Ď����P2019
                    'strRec = ""
                    strRec = hdnKURACD_TO.Value.Trim
                Case "3"
                    'strRec = hdnHANGRP.Value.Trim '2019/11/01 T.Ono mod �Ď����P2019
                    strRec = ""
                Case Else
                    strRec = ""
            End Select
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�i���ݏ�����n���v���p�e�B�i�ǉ��j 2016/11/25 H.Mori add �Ď����P2016 No3-1
    '*�@���@�l�F���o�����S�̒l��n��
    '******************************************************************************
    Public ReadOnly Property pCode4() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "1"
                    strRec = ""
                Case "2"
                    strRec = ""
                Case "3"
                    'strRec = hdnKINRENGRP.Value.Trim '2019/11/01 T.Ono mod �Ď����P2019
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
            If hdnPopcrtl.Value = "1" Then
                strRec = "�N���C�A���g�R�[�h�ꗗ"
                '2013/12/10 T.Ono mod �Ď����P2013 START
                'ElseIf hdnPopcrtl.Value = "2" Then
                '    strRec = "�i�`�x���R�[�h�ꗗ"
                'ElseIf hdnPopcrtl.Value = "3" Then
                '    strRec = "�Ď��Z���^�[�S���҈ꗗ"
                'Else
                '    strRec = ""
                'End If
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = "�i�`�R�[�h�ꗗ"
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = "�i�`�x���R�[�h�ꗗ"
            ElseIf hdnPopcrtl.Value = "4" Then
                strRec = "�Ď��Z���^�[�S���҈ꗗ"
            ElseIf hdnPopcrtl.Value = "5" Then
                strRec = "�x��R�[�h�ꗗ"
            ElseIf hdnPopcrtl.Value = "6" Then      '2014/12/08 H.Hosoda add �Ď����P2014 No.7
                '2019/11/01 T.Ono mod �Ď����P2019
                'strRec = "�̔����Ǝ҃O���[�v�ꗗ"
                strRec = "�N���C�A���g�R�[�h�ꗗ"
            ElseIf hdnPopcrtl.Value = "7" Then      '2016/11/25 H.Mori add �Ď����P2016 No3-1
                '2019/11/01 T.Ono mod �Ď����P2019
                'strRec = "�ً}�A����Gr�ꗗ"
                strRec = "�i�`�x���R�[�h�ꗗ"
            Else
                strRec = ""
            End If
            '2013/12/10 T.Ono mod �Ď����P2013 END
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
            If hdnPopcrtl.Value = "1" Then
                strRec = "CLI"
                '2013/12/10 T.Ono mod �Ď����P2013 START
                'ElseIf hdnPopcrtl.Value = "2" Then
                '    'strRec = "JASS"
                '    'strRec = "JASS2"      '--- 2005/05/24 MOD Falcon ---
                '    strRec = "JASS"      '--- 2008/02/27 MOD T.Watabe ---
                'ElseIf hdnPopcrtl.Value = "3" Then
                '    strRec = "TKTANCDKN"
                'Else
                '    strRec = ""
                'End If
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = "JA"
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = "JASS"
            ElseIf hdnPopcrtl.Value = "4" Then
                strRec = "TKTANCDKN"
            ElseIf hdnPopcrtl.Value = "5" Then
                strRec = "PULLCODE"
            ElseIf hdnPopcrtl.Value = "6" Then   '2014/12/08 H.Hosoda add �Ď����P2014 No.7
                '2019/11/01 T.Ono mod �Ď����P2019
                'strRec = "HANG"
                strRec = "CLI"
            ElseIf hdnPopcrtl.Value = "7" Then   '2016/11/25 H.Mori add �Ď����P2016 No3-1
                '2019/11/01 T.Ono mod �Ď����P2019
                'strRec = "JAHOKOKU2"
                strRec = "JASS"
            Else
                strRec = ""
            End If
            '2013/12/10 T.Ono mod �Ď����P2013 END
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
                strRec = "hdnKURACD"
                '2013/12/10 T.Ono mod �Ď����P2013 START
                'ElseIf hdnPopcrtl.Value = "2" Then
                '    strRec = "hdnACBCD"
                'ElseIf hdnPopcrtl.Value = "3" Then
                '    strRec = "hdnTKTANCD"
                'Else
                '    strRec = ""
                'End If
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = "hdnJACD"
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = "hdnACBCD"
            ElseIf hdnPopcrtl.Value = "4" Then
                strRec = "hdnTKTANCD"
            ElseIf hdnPopcrtl.Value = "5" Then
                strRec = "hdnKMCD"
            ElseIf hdnPopcrtl.Value = "6" Then  '2014/12/08 H.Hosoda add �Ď����P2014 No.7
                '2019/11/01 T.Ono mod �Ď����P2019
                'strRec = "hdnHANGRP"
                strRec = "hdnKURACD_TO"
            ElseIf hdnPopcrtl.Value = "7" Then  '2016/11/25 H.Mori add �Ď����P2016 No3-1
                '2019/11/01 T.Ono mod �Ď����P2019
                'strRec = "hdnKINRENGRP"
                strRec = "hdnACBCD_TO"
            Else
                strRec = ""
            End If
            '2013/12/10 T.Ono mod �Ď����P2013 END
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
                strRec = "txtKURACD"
                '2013/12/10 T.Ono mod �Ď����P2013 START
                'ElseIf hdnPopcrtl.Value = "2" Then
                '    strRec = "txtACBNM"
                'ElseIf hdnPopcrtl.Value = "3" Then
                '    strRec = "txtTKTANCD"
                'Else
                '    strRec = ""
                'End If
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = "txtJANM"
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = "txtACBNM"
            ElseIf hdnPopcrtl.Value = "4" Then
                strRec = "txtTKTANCD"
            ElseIf hdnPopcrtl.Value = "5" Then
                strRec = "hdnKMNM"
            ElseIf hdnPopcrtl.Value = "6" Then  '2014/12/08 H.Hosoda add �Ď����P2014 No.7
                '2019/11/01 T.Ono mod �Ď����P2019
                'strRec = "txtHANGRP"
                strRec = "txtKURACD_TO"
            ElseIf hdnPopcrtl.Value = "7" Then  '2016/11/25 H.Mori add �Ď����P2016 No3-1
                '2019/11/01 T.Ono mod �Ď����P2019
                'strRec = "txtKINRENGRP"
                strRec = "txtACBNM_TO"
            Else
                strRec = ""
            End If
            '2013/12/10 T.Ono mod �Ď����P2013 END
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�R�[�h�Q��Ԃ��I�u�W�F�N�g�̖��O�l��n���v���p�e�B
    '*�@���@�l�F�f�[�^�I����A�R�[�h��Ԃ��I�u�W�F�N�g�����w�肷��@2019/11/01 T.Ono add �Ď����P2019
    '******************************************************************************
    Public ReadOnly Property pBackCode2() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = "hdnJACD_CLI"
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = "hdnACBCD_CLI"
            ElseIf hdnPopcrtl.Value = "4" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "5" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "6" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "7" Then
                strRec = "hdnACBCD_TO_CLI"
            Else
                strRec = ""
            End If

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
                strRec = "txtHATYMD_From"
            Else
                strRec = "txtHATYMD_To"
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
            If hdnCalendar.Value = "1" Then
                strRec = "txtHATYMD_From"
            Else
                strRec = "txtHATYMD_To"
            End If

            If hdnPopcrtl.Value = "1" Then
                strRec = "btnKURACD"
                '2013/12/10 T.Ono mod �Ď����P2013 START
                'ElseIf hdnPopcrtl.Value = "2" Then
                '    strRec = "btnACBCD"
                'Else
                '    strRec = ""
                'End If
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = "btnJACD"
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = "btnACBCD"
            ElseIf hdnPopcrtl.Value = "4" Then
                strRec = "btnTKTANCD"
            ElseIf hdnPopcrtl.Value = "5" Then
                strRec = "btnKMCD"
            ElseIf hdnPopcrtl.Value = "6" Then   '2014/12/08 H.Hosoda add �Ď����P2014 No.7
                '2019/11/01 T.Ono mod �Ď����P2019
                'strRec = "btnHANGRP"
                strRec = "btnKURACD_TO"
            ElseIf hdnPopcrtl.Value = "7" Then   '2016/11/25 H.Mori add �Ď����P2016 No3-1
                '2019/11/01 T.Ono mod �Ď����P2019
                'strRec = "btnKINRENGRP"
                strRec = "btnACBCD_TO"
            Else
                strRec = ""
            End If
            '2013/12/10 T.Ono mod �Ď����P2013 END
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�FJA�x���R�[�h�̃N���A�ihdn�j
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pClear1() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "hdnACBCD"
            ElseIf hdnPopcrtl.Value = "2" Then
                'strRec = "" 2013/12/10 T.Ono mod �Ď����P2013
                strRec = "hdnACBCD"
            ElseIf hdnPopcrtl.Value = "6" Then  '2014/12/08 H.Hosoda add �Ď����P2014 No.7
                strRec = "hdnACBCD"
            ElseIf hdnPopcrtl.Value = "7" Then  '2016/11/25 H.Mori add �Ď����P2016 No3-1
                '2019/11/01 T.Ono mod �Ď����P2019
                'strRec = "hdnACBCD"
                strRec = ""
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
    Public ReadOnly Property pClear2() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "txtACBNM"
            ElseIf hdnPopcrtl.Value = "2" Then
                'strRec = "" 2013/12/10 T.Ono mod �Ď����P2013
                strRec = "txtACBNM"
            ElseIf hdnPopcrtl.Value = "6" Then  '2014/12/08 H.Hosoda add �Ď����P2014 No.7
                strRec = "txtACBNM"
            ElseIf hdnPopcrtl.Value = "7" Then  '2016/11/25 H.Mori add �Ď����P2016 No3-1
                '2019/11/01 T.Ono mod �Ď����P2019
                'strRec = "txtACBNM"
                strRec = ""
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�FJA�R�[�h�̃N���A�ihdn�j 2013/12/10 T.Ono add �Ď����P2013
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pClear3() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "hdnJACD"
            ElseIf hdnPopcrtl.Value = "2" Then
                '2019/11/01 T.Ono mod �Ď����P2019
                'strRec = ""
                strRec = "hdnACBCD_TO"
            ElseIf hdnPopcrtl.Value = "6" Then '2019/11/01 T.Ono add �Ď����P2019
                strRec = "hdnJACD"
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�FJA�R�[�h�̃N���A�itxt�j 2013/12/10 T.Ono add �Ď����P2013
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pClear4() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "txtJANM"
            ElseIf hdnPopcrtl.Value = "2" Then
                '2019/11/01 T.Ono mod �Ď����P2019
                'strRec = ""
                strRec = "txtACBNM_TO"
            ElseIf hdnPopcrtl.Value = "6" Then '2019/11/01 T.Ono add �Ď����P2019
                strRec = "txtJANM"
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�̔����Ǝ҃O���[�v�R�[�h�̃N���A�ihdn�j 2014/12/08 H.Hosoda add �Ď����P2014 No.7
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pClear5() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                '2019/11/01 T.Ono mod �Ď����P2019
                'strRec = "hdnHANGRP"
                strRec = "hdnACBCD_TO"
            ElseIf hdnPopcrtl.Value = "6" Then '2019/11/01 T.Ono add �Ď����P2019
                strRec = "hdnACBCD_TO"
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�̔����Ǝ҃O���[�v�R�[�h�̃N���A�itxt�j 2014/12/08 H.Hosoda add �Ď����P2014 No.7
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pClear6() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                '2019/11/01 T.Ono mod �Ď����P2019
                'strRec = "txtHANGRP"
                strRec = "txtACBNM_TO"
            ElseIf hdnPopcrtl.Value = "6" Then '2019/11/01 T.Ono add �Ď����P2019
                strRec = "txtACBNM_TO"
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�ً}�A����Gr�̃N���A�ihdn�j 2016/11/25 H.Mori add �Ď����P2016 No3-1
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pClear7() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                '2019/11/01 T.Ono mod �Ď����P2019
                'strRec = "hdnKINRENGRP"
                strRec = "hdnJACD_CLI"
            ElseIf hdnPopcrtl.Value = "6" Then '2019/11/01 T.Ono add �Ď����P2019
                strRec = "hdnJACD_CLI"
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�ً}�A����Gr�̃N���A�itxt�j 2016/11/25 H.Mori add �Ď����P2016 No3-1
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pClear8() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                '2019/11/01 T.Ono mod �Ď����P2019
                'strRec = "txtKINRENGRP"
                strRec = "hdnACBCD_CLI"
            ElseIf hdnPopcrtl.Value = "6" Then '2019/11/01 T.Ono add �Ď����P2019
                strRec = "hdnACBCD_CLI"
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
    Public ReadOnly Property pClear9() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "hdnACBCD_TO_CLI"
            ElseIf hdnPopcrtl.Value = "6" Then '2019/11/01 T.Ono add �Ď����P2019
                strRec = "hdnACBCD_TO_CLI"
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F���^�[����Ɏ��s�����i�r
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pBackScript() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then      '�N���C�A���g�R�[�h
                '2019/11/01 T.Ono mod �Ď����P2019
                'strRec = ""
                strRec = "fncSetTo"
            ElseIf hdnPopcrtl.Value = "2" Then  '�i�`
                strRec = ""
            ElseIf hdnPopcrtl.Value = "3" Then  '�i�`�x��
                '2019/11/01 T.Ono mod �Ď����P2019
                'strRec = ""
                strRec = "fncSetTo"
            ElseIf hdnPopcrtl.Value = "4" Then  '�Ď��Z���^�[�S����
                strRec = ""
            ElseIf hdnPopcrtl.Value = "5" Then '�x�񃁃b�Z�[�W(PULLCODE)
                strRec = "fncKeihoMsgCopy"
            Else
                strRec = ""
            End If
            Return strRec
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
    '*�@�T�@�v�F�Ď��Z���^�[�̒l��n���v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pKANSCD() As String
        Get
            Return Request.Form("cboKANSCD")
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�Ή��������E��M���̒l��n���v���p�e�B
    '*�@���@�l�F2017/10/25 H.Mori add 2017���P�J�� No3-1
    '******************************************************************************
    Public ReadOnly Property pKikankbn() As String
        Get
            Dim strKIKANKBN As String = ""
            If rdoKIKAN1.Checked = True Then
                strKIKANKBN = "1"      '�Ή�������
            ElseIf rdoKIKAN2.Checked = True Then
                strKIKANKBN = "2"      '��M��
            End If
            Return strKIKANKBN
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�������ԁiFrom�j�̒l��n���v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pHATYMD_From() As String
        Get
            Return fncDateGet(txtHATYMD_From.Text)
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�������ԁiTo�j�̒l��n���v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pHATYMD_To() As String
        Get
            Return fncDateGet(txtHATYMD_To.Text)
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F���������iFrom�j�̒l��n���v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pHATTIME_From() As String
        Get
            Return fncTimeGet(txtHATTIME_From.Text)
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F���������iTo�j�̒l��n���v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pHATTIME_To() As String
        Get
            Return fncTimeGet(txtHATTIME_To.Text)
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�Ď��Z���^�[�S���҂̒l��n���v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pTKTANCD() As String
        Get
            Return hdnTKTANCD.Value.Trim()          '2012/04/25 NEC ou Upd
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�Ď��Z���^�[�S���҂̒l��n���v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pTKTANNAME() As String
        Get
            Return txtTKTANCD.Text.Trim()           '2012/04/25 NEC ou Upd
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�����敪�̒l��n���v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pHATKBN() As String
        Get
            Return Request.Form("cboHATKBN")
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�Ή��敪�̒l��n���v���p�e�B 2014/12/04 H.Hosoda del �Ď����P2014 No.7
    '*�@���@�l�F
    '******************************************************************************
    'Public ReadOnly Property pTAIOKBN() As String
    '    Get
    '        Return Request.Form("cboTAIOKBN")
    '    End Get
    'End Property

    '******************************************************************************
    '*�@�T�@�v�F�Ή��敪�i�d�b�j�̒l��n���v���p�e�B�@2014/12/04 H.Hosoda add �Ď����P2014 No.7
    '*�@���@�l�F0�F�`�F�b�N�Ȃ��@1�F�`�F�b�N����
    '******************************************************************************
    Public ReadOnly Property pTAIOKBN1() As String
        Get
            If chkTAIOU_KBN1.Checked = False Then
                Return "0"
            Else
                Return "1"
            End If
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�Ή��敪�i�o���j�̒l��n���v���p�e�B�@2014/12/04 H.Hosoda add �Ď����P2014 No.7
    '*�@���@�l�F0�F�`�F�b�N�Ȃ��@1�F�`�F�b�N����
    '******************************************************************************
    Public ReadOnly Property pTAIOKBN2() As String
        Get
            If chkTAIOU_KBN2.Checked = False Then
                Return "0"
            Else
                Return "1"
            End If
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�Ή��敪�i�d���j�̒l��n���v���p�e�B�@2014/12/04 H.Hosoda add �Ď����P2014 No.7
    '*�@���@�l�F0�F�`�F�b�N�Ȃ��@1�F�`�F�b�N����
    '******************************************************************************
    Public ReadOnly Property pTAIOKBN3() As String
        Get
            If chkTAIOU_KBN3.Checked = False Then
                Return "0"
            Else
                Return "1"
            End If
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�����敪�̒l��n���v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pTMSKB() As String
        Get
            Return Request.Form("cboTMSKB")
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F���q�l�d�b�ԍ��̒l��n���v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pJUTEL() As String
        Get
            Return txtJUTEL.Text
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�����ԍ��̒l��n���v���p�e�B�@2014/12/05 H.Hosoda add �Ď����P2014 No.7 2016/11/25 H.Mori del �Ď����P2016 No3-2
    '*�@���@�l�F
    '******************************************************************************
    'Public ReadOnly Property pNCUTEL() As String
    '    Get
    '        Return txtNCUTEL.Text
    '    End Get
    'End Property

    '******************************************************************************
    '*�@�T�@�v�F���q�l���̒l��n���v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pJUSYONM() As String
        Get
            Return txtJUSYONM.Text
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F���q�l���J�i�̒l��n���v���p�e�B 2016/11/24 H.Mori del �Ď����P2016 No3-3
    '*�@���@�l�F
    '******************************************************************************
    'Public ReadOnly Property pJUSYOKN() As String
    '    Get
    '        Return txtJUSYOKN.Text
    '    End Get
    'End Property

    '******************************************************************************
    '*�@�T�@�v�F�N���C�A���g�R�[�h�̒l��n���v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pKURACD() As String
        Get
            Return hdnKURACD.Value.Trim()       '2012/04/25 NEC ou Upd
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�N���C�A���g���̒l��n���v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pKURACD_NAME() As String
        Get
            Return txtKURACD.Text.Trim()        '2012/04/25 NEC ou Upd
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�N���C�A���g�R�[�hTO�̒l��n���v���p�e�B
    '*�@���@�l�F2019/11/01 T.Ono add �Ď����P2019
    '******************************************************************************
    Public ReadOnly Property pKURACD_TO() As String
        Get
            Return hdnKURACD_TO.Value.Trim()
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�N���C�A���g��TO�̒l��n���v���p�e�B
    '*�@���@�l�F2019/11/01 T.Ono add �Ď����P2019
    '******************************************************************************
    Public ReadOnly Property pKURACD_TO_NAME() As String
        Get
            Return txtKURACD_TO.Text.Trim()
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�i�`�R�[�h�̒l��n���v���p�e�B 2013/12/10 T.Ono add �Ď����P2013
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pJACD() As String
        Get
            Return hdnJACD.Value.Trim()
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�i�`���̒l��n���v���p�e�B 2013/12/10 T.Ono add �Ď����P2013
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pJACD_NAME() As String
        Get
            Return txtJANM.Text.Trim()
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�i�`�R�[�h�ɕR�Â��N���C�A���g�R�[�h�̒l��n���v���p�e�B '2019/11/01 T.Ono add �Ď����P2019
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pJACD_CLI() As String
        Get
            Return hdnJACD_CLI.Value.Trim
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�̔����Ǝ҃O���[�v�R�[�h�̒l��n���v���p�e�B 2014/12/08 H.Hosoda add �Ď����P2014 No.7
    '*�@���@�l�F2019/11/01 T.Ono del �Ď����P2019
    '******************************************************************************
    'Public ReadOnly Property pHANGRP() As String
    '    Get
    '        Return hdnHANGRP.Value.Trim()
    '    End Get
    'End Property

    '******************************************************************************
    '*�@�T�@�v�F�̔����Ǝ҃O���[�v���̒l��n���v���p�e�B 2014/12/08 H.Hosoda add �Ď����P2014 No.7
    '*�@���@�l�F2019/11/01 T.Ono del �Ď����P2019
    '******************************************************************************
    'Public ReadOnly Property pHANGRP_NAME() As String
    '    Get
    '        Return txtHANGRP.Text.Trim()
    '    End Get
    'End Property

    '******************************************************************************
    '*�@�T�@�v�F�ً}�A����Gr�̒l��n���v���p�e�B 2016/11/25 H.Mori add �Ď����P2016 No3-1
    '*�@���@�l�F2019/11/01 T.Ono del �Ď����P2019
    '******************************************************************************
    'Public ReadOnly Property pKINRENGRP() As String
    '    Get
    '        Return hdnKINRENGRP.Value.Trim()
    '    End Get
    'End Property

    '******************************************************************************
    '*�@�T�@�v�F�ً}�A����Gr���̒l��n���v���p�e�B 2014/12/08 H.Hosoda add �Ď����P2014 No.7
    '*�@���@�l�F2019/11/01 T.Ono del �Ď����P2019
    '******************************************************************************
    'Public ReadOnly Property pKINRENGRP_NAME() As String
    '    Get
    '        Return txtKINRENGRP.Text.Trim()
    '    End Get
    'End Property

    '******************************************************************************
    '*�@�T�@�v�F�i�`�x���R�[�h�̒l��n���v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pACBCD() As String
        Get
            Return hdnACBCD.Value.Trim()        '2012/04/25 NEC ou Upd
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�i�`�x�����̒l��n���v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pACBCD_NAME() As String
        Get
            Return txtACBNM.Text.Trim()         '2012/04/25 NEC ou Upd
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�i�`�x���R�[�h�ɕR�Â��N���C�A���g�R�[�h�̒l��n���v���p�e�B '2019/11/01 T.Ono add �Ď����P2019
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pACBCD_CLI() As String
        Get
            Return hdnACBCD_CLI.Value.Trim
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�i�`�x���R�[�hTo�̒l��n���v���p�e�B
    '*�@���@�l�F2019/11/01 T.Ono add �Ď����P2019
    '******************************************************************************
    Public ReadOnly Property pACBCD_TO() As String
        Get
            Return hdnACBCD_TO.Value.Trim()
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�i�`�x����TO�̒l��n���v���p�e�B
    '*�@���@�l�F2019/11/01 T.Ono add �Ď����P2019
    '******************************************************************************
    Public ReadOnly Property pACBCD_TO_NAME() As String
        Get
            Return txtACBNM_TO.Text.Trim()
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�i�`�x��TO�R�[�h�ɕR�Â��N���C�A���g�R�[�h�̒l��n���v���p�e�B '2019/11/01 T.Ono add �Ď����P2019
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pACBCD_TO_CLI() As String
        Get
            Return hdnACBCD_TO_CLI.Value.Trim
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F���q�l���R�[�h�̒l��n���v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pUSER_CD() As String
        Get
            Return txtUSER_CD.Text
        End Get
    End Property

    '2011.11.15 ADD H.Uema
    '******************************************************************************
    '*�@�T�@�v�F�x��R�[�h�̒l��n���v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pKMCD() As String
        Get
            'Return txtKMCD.Text    '2013/12/10 T.Ono mod �Ď����P2013
            Return hdnKMCD.Value.Trim()
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�x�񖼂̒l��n���v���p�e�B '2013/12/10 T.Ono add �Ď����P2013
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pKMNM() As String
        Get
            Return txtKMCD.Text.Trim()
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�ꗗ�őI�����������ԍ��̒l��n���v���p�e�B
    '*�@���@�l�F�Ή����͉�ʂ��߂��Ă������Ɏg�p
    '******************************************************************************
    Public ReadOnly Property pKEY_SYONO() As String
        Get
            Return hdnKEY_SYONO.Value
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�Ď��Z���^�[�R�[�h�̒l��n���v���p�e�B
    '*�@���@�l�F�Ή����͉�ʂ��߂��Ă������Ɏg�p
    '******************************************************************************
    Public ReadOnly Property pKEY_KANSCD() As String
        Get
            Return hdnKEY_KANSCD.Value
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
    Private Sub fncCombo_Creatr_KANSI_CD()
        '//�Ď��Z���^�[�R���{
        Dim strGROUPNAME As String = AuthC.pGROUPNAME
        Dim arrGroupName() As String = strGROUPNAME.Split(Convert.ToChar(","))
        '2005/12/03 NEC UPDATE START
        'If Array.IndexOf(arrGroupName, AuthC.pGROUP_UNKOU) >= 0 Then
        If Array.IndexOf(arrGroupName, AuthC.pGROUP_UNKOU) >= 0 Or strGROUPNAME.IndexOf(AuthC.pGROUP_EIGYOU) >= 0 Then
            '2005/12/03 NEC UPDATE END
            '�^�s�J�����A�c�Ə��̏ꍇ�͖��I���n�j�@�e�Ď��Z���^�[�̏ꍇ�͊Ď��Z���^�[��I������
            cboKANSCD.pComboTitle = True
        Else
            cboKANSCD.pComboTitle = False
        End If
        cboKANSCD.pNoData = False
        cboKANSCD.pType = "KANSICENTER"
        cboKANSCD.pAllCenterCd = AuthC.pAUTHCENTERCD
        cboKANSCD.mMakeCombo()
    End Sub

    Private Sub fncCombo_Create_HASEIKBN()
        '//�����敪�R���{
        cboHATKBN.pComboTitle = True
        cboHATKBN.pNoData = False
        cboHATKBN.pType = "HASSEIKBN"                '//�����敪
        cboHATKBN.mMakeCombo()
    End Sub

    '2014/12/04 H.Hosoda del �Ď����P2014 No.7
    'Private Sub fncCombo_Create_TAIOUKBN()
    '    '//�Ή��敪�R���{
    '    cboTAIOKBN.pComboTitle = True
    '    cboTAIOKBN.pNoData = False
    '    cboTAIOKBN.pType = "TAIOUKBN"               '//�Ή��敪
    '    cboTAIOKBN.mMakeCombo()
    'End Sub

    Private Sub fncCombo_Create_SYORIKBN()
        '//�����敪�R���{
        cboTMSKB.pComboTitle = True
        cboTMSKB.pNoData = False
        cboTMSKB.pType = "SYORIKBN"                 '//�����敪
        cboTMSKB.mMakeCombo()
    End Sub

End Class
