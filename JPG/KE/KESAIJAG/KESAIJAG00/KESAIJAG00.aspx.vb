'***********************************************
' �ЊQ�Ή����[
'***********************************************
' �ύX����
' 2020/01/06 T.Ono �V�K�쐬
' 2021/10/01 saka  2021�N�x�Ď����P�E���k��Ւf�x��o�́i�������o�́j��ǉ�

Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common
Imports JPG.Common.log

Imports System.Text

Partial Class KESAIJAG00
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
    ' �����N���X
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
    Dim strTSADCD As String         '�쓮�����R�[�h
    Dim strTSADNM As String         '�쓮��������


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
        '.NET�̎d�l�ύX�ɂ��AReadOnly������ASPX�ł���ƁA�T�[�o���Œl�̎Q�Ƃ��ł��Ȃ��Ȃ邽�߁AVB����Attribute�ł���
        If MyBase.IsPostBack = False Then
            txtKURACD_From.Attributes.Add("ReadOnly", "true")
            txtKURACD_To.Attributes.Add("ReadOnly", "true")
            txtJACD_From.Attributes.Add("ReadOnly", "true")
            txtJACD_To.Attributes.Add("ReadOnly", "true")
        End If

        '//------------------------------------------
        '//�@HTTP�w�b�_�𑗐M
        HttpHeaderC.mNoCache(Response)

        '//------------------------------------------
        '//�@�F�؃N���X�̃C���X�^���X����
        AuthC = New CAuthenticate(Request, Response)

        '//------------------------------------------
        '//�@�F�؏���
        '<TODO>�F�g�p�\�������w�肷��
        '[�ЊQ�Ή����[]�g�p�\����(�^:��/�c:��/��:��/�o:�~)
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
             MyBase.MapPath("../../../KE/KESAIJAG/KESAIJAG00/") & "KESAIJAG00.js"))
        '<�t�H�[�J�X�֘A�֐�>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncFo.js"))
        '<���t�֘A�֐�>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncDate.js"))
        '<���Ԋ֘A�֐�> 
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncTime.js"))
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

            '�Ώۊ��ԓ��ɓ������t��\��
            txtTRGDATE_From.Text = DateTime.Today.ToString("yyyy/MM/dd")
            txtTRGDATE_To.Text = DateTime.Today.ToString("yyyy/MM/dd")

            '//�t�H�[�J�X���Z�b�g����
            strMsg.Append("Form1.btnKURACD_From.focus();")
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
        hdnMyAspx.Value = "KESAIJAG00"
        '//-------------------------------------------------

    End Sub

    '******************************************************************************
    '*�@�T�@�v�F�R���{�{�b�N�X�̑I��
    '*�@���@�l�F
    '******************************************************************************
    Private Sub fncSelectCombo()
        Dim list As New ListItem
        '//<TODO>�R���{�{�b�N�X��I����Ԃɂ���

        '//�쓮����
        If strTSADCD <> "" Then
            list = cboTSADCD.Items.FindByValue(strTSADCD)
            cboTSADCD.SelectedIndex = cboTSADCD.Items.IndexOf(list)
            strTSADNM = list.ToString
        End If

    End Sub

    '******************************************************************************
    '* POST�f�[�^�̎擾�ϐ��̏�����
    '******************************************************************************
    Private Sub fncGetPostIni()
        '//--------------------------------------------------------------------------
        '<TODO>��ʃR���g���[�����e���i�[�����ϐ�������������
        strTSADCD = ""
        strTSADNM = ""
        '//-----------------------------------------------
        hdnKURACD_From.Value = ""
        hdnKURACD_To.Value = ""

        txtKURACD_From.Text = ""
        txtKURACD_To.Text = ""

        hdnJACD_From.Value = ""
        hdnJACD_To.Value = ""
        txtJACD_From.Text = ""
        txtJACD_To.Text = ""

        hdnJACD_From_CLI.Value = ""
        hdnJACD_To_CLI.Value = ""

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
        strTSADCD = Request.Form("cboTSADCD")
    End Sub

    '******************************************************************************
    '* �e�R���g���[���̐ݒ�l�̏�����
    '******************************************************************************
    Private Sub fncIni_format()

        '�R���{�쐬
        Call fncCombo_Create_Sadougen()         '�쓮�����R���{

        '�����l���w��
        cboTSADCD.SelectedValue = "59"          '59�F���R�ЊQ

    End Sub

    '******************************************************************************
    '*�@�T�@�v�F�R���{�{�b�N�X�쐬
    '*�@���@�l�F
    '******************************************************************************
    Private Sub fncCreateCombo()
        '//--------------------------------------------------------------------------
        '<TODO>�R���{�{�b�N�X���쐬����t�@���N�V������Call����
        Call fncCombo_Create_Sadougen()         '�쓮����
    End Sub
    Private Sub fncCombo_Create_Sadougen()
        '//�쓮����
        cboTSADCD.pComboTitle = True
        cboTSADCD.pNoData = False
        cboTSADCD.pType = "SADOUGEN"
        cboTSADCD.mMakeCombo()
    End Sub

    '******************************************************************************
    ' ���ו\�o��(�`�F�b�N��)
    '******************************************************************************
    Private Sub btnSelect_ServerClick(ByVal sender As System.Object, _
                                    ByVal e As System.EventArgs) Handles btnSelect.ServerClick
        Dim strRec As String
        Dim KETAISYG00C As New KETAISYG00KETAISYW00.KETAISYW00

        Dim strSTKBN1 As String
        Dim strSTKBN2 As String

        Dim strPGKBN1 As String
        Dim strPGKBN2 As String
        Dim strPGKBN3 As String

        Dim strOUTKBN As String
        Dim strKIKANKBN As String
        Dim strHOKBN As String
        Dim strOUTLIST As String

        '//�@�F�؃N���X�̃C���X�^���X����
        AuthC = New CAuthenticate(Request, Response)

        '�����敪�擾
        strSTKBN1 = "1"      '�d�b
        strSTKBN2 = "2"      '�x��

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

        '�o�͑Ώێ擾
        strOUTKBN = "1"         '�ʏ�

        '�Ώۊ��ԋ敪�擾                   '2021�N�x�Ď����P�E���������k��o��(���ג��[����M���o�͂ɑΉ�)2021/10/01
        If rdoKIKAN1.Checked = True Then
            strKIKANKBN = "1"       '�Ή�������
        Else
            strKIKANKBN = "2"     '��M��
        End If

        '�@�ߋ敪�擾
        strHOKBN = "1"          '�����v

        '�o�͍��ڎ擾
        strOUTLIST = "3"        '�����񍐂Ɠ���(�o����ЂȂ�)

        '2020/09/15 T.Ono add �Ď����P2020 
        '�l���
        If rdoKOJIN1.Checked = True Then
            strOUTLIST = "4"    '�l���Ȃ��@���@�����񍐂Ɠ���(�o����ЂȂ�)
        End If


        Dim strRecMsg As String = ""

        strRec = KETAISYG00C.mExcel(
                         Me.Session.SessionID,
                         "",
                         "",
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
                         "",
                         "",
                         strOUTKBN,
                         strKIKANKBN,
                         TimeFncC.mHenkanGet(txtTRGTIME_From.Text),
                         TimeFncC.mHenkanGet(txtTRGTIME_To.Text),
                         strHOKBN,
                         strOUTLIST,
                         "",
                         strTSADCD,
                         strTSADNM
                         )


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
            '�t�@�C�����ύX
            HttpHeaderC.mDownLoadXLS(Response, "�Ή����ʖ���.xls")

            ''�t�@�C�����M
            Response.ContentType = "application/msexcel" '�u�t�@�C�����J���v�ۂ̃G���[�΍�
            Response.WriteFile(strRec)

            Response.End()

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
    '******************************************************************************
    ' �W�v�\�o��
    '******************************************************************************
    Private Sub btnOutput_ServerClick(ByVal sender As System.Object,
                                      ByVal e As System.EventArgs) Handles btnOutput.ServerClick

        Dim strRec As String
        Dim KESAIJAG00C As New KESAIJAG00KESAIJAW00.KESAIJAW00

        Dim strPGKBN1 As String
        Dim strPGKBN2 As String
        Dim strPGKBN3 As String

        Dim strKIKANKBN As String '2021/10/01 2021�N�x�Ď����P�E�n�k�Ȃǂ̍ЊQ���Ɂi�����Ǝ蓮�Łj�o�^����関�����f�[�^���o�͂���ЊQ�Ή����[

        '//�@�F�؃N���X�̃C���X�^���X����
        AuthC = New CAuthenticate(Request, Response)

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

        If rdoKIKAN1.Checked = True Then                             '2021/10/01 2021�N�x�Ď����P�EStart���C���͊��k��Ւf�𖢏����ł��o�͂�����
            strKIKANKBN = "1"     '�Ή�������(�ЊQ���[)
        Else
            strKIKANKBN = "2"     '��M��(�������f�[�^���o�͂�����)
        End If                                                       '2021/10/01 2021�N�x�Ď����P�EEnd

        Dim strRecMsg As String = ""

        strRec = KESAIJAG00C.mExcel(
                         Me.Session.SessionID,
                         hdnKURACD_From.Value.Trim,
                         hdnKURACD_To.Value.Trim,
                         hdnJACD_From.Value.Trim,
                         hdnJACD_From_CLI.Value.Trim,
                         hdnJACD_To.Value.Trim,
                         hdnJACD_To_CLI.Value.Trim,
                         DateFncC.mHenkanGet(txtTRGDATE_From.Text),
                         DateFncC.mHenkanGet(txtTRGDATE_To.Text),
                         TimeFncC.mHenkanGet(txtTRGTIME_From.Text),
                         TimeFncC.mHenkanGet(txtTRGTIME_To.Text),
                         strPGKBN1,
                         strPGKBN2,
                         strPGKBN3,
                         strTSADCD,
                         strTSADNM,       '2021/10/01 2021�N�x�Ď����P�E���k��Ւf�p�ɖ��������o�́AUPDsaka�o�͂���G�N�Z���f�U�C����ς��邽��
                         strKIKANKBN      '2021/10/01 �Ή��������݂̂����M���i�������o�͗p�Ɂj�����W�I�I���ɒǉ�����
                         )


        If strRec.Substring(0, 5) = "ERROR" Then
            '�G���[�ł���΃u���E�U�Ƀ��b�Z�[�W�\��
            Dim ErrMsgC As New CErrMsg
            strRecMsg = "�V�X�e���G���[�F" & ErrMsgC.mGetArtMsg(strRec)
            strMsg.Append("alert('" & strRecMsg & "');")

        ElseIf strRec.Substring(0, 5) = "DATA0" Then
            '�f�[�^��0���̏ꍇ
            strRecMsg = "�Ώۃf�[�^�����݂��܂���"
            strMsg.Append("alert('" & strRecMsg & "');")

            If strKIKANKBN = "1" Then                            '2021/10/01 2021�N�x�Ď����P�E���������o��
                strMsg.Append("Form1.btnSelect.focus();")
            Else                                      '���W�v�\�i���k��Ւf�x��j�̏o�͂�������
                'rdoKIKAN1.Checked = True                   '�Ή��������Ƀ��W�I���Z�b�g(2021/10/01 2021�N�x�Ď����P�E���k�풠�[�Ō����[���G���[���ɂ͔񊈐��������ɂȂ��Ă��܂����߁A�������l���Z�b�g�����ꗗ�A2021/10/08�ł��s�g�p)
                'rdoKIKAN2.Checked = False                  '��M���̃��W�I���͂����A�Ǝv�����₱������S���s�v�ƂȂ������撣�����̂ł����Q�l�o���邩���Ȃ̂Ŏ���Ă���
                'chkTAI_TEL.Checked = True                  '���d�b�Ή��`�F�b�N�{�b�N�X�Ƀ`�F�b�N
                'chkTAI_SHU.Checked = True                  '���o���Ή��`�F�b�N�{�b�N�X�Ƀ`�F�b�N
                'rdoOUTLIST3.Checked = True                 '���o�͍��ڃ��W�I�Ƀ`�F�b�N
                'rdoKOJIN1.Checked = True                   '���l���Ȃ����W�I�Ƀ`�F�b�N
                'cboTSADCD.SelectedValue = "59"             '���쓮�������ЊQ�ɃZ�b�g
                strMsg.Append("Form1.btnOutput.focus();")   '���t�H�[�J�X�������邱�Ƃɂ��Ă݂�
            End If                                         '2021/10/01 2021�N�x�Ď����P�E���������o��

        Else
                '�u�J���A�ۑ��v�̃_�C�����O���o��悤��HTTP�w�b�_�ɒǉ�
                '�t�@�C�����ύX
                HttpHeaderC.mDownLoadXLS(Response, "�ЊQ�Ή����[.xlsx")

            ''�t�@�C�����M
            Response.ContentType = "application/msexcel" '�u�t�@�C�����J���v�ۂ̃G���[�΍�
            Response.WriteFile(strRec)

            Response.End()

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

    '******************************************************************************
    '*�@�T�@�v�F�i���ݏ�����n���v���p�e�B
    '*�@���@�l�F(�N���C�A���g�R�[�h)
    '******************************************************************************
    Public ReadOnly Property pCode1() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = ""
                Case "1"
                    strRec = ""
                Case "2"
                    strRec = hdnKURACD_From.Value
                Case "3"
                    strRec = hdnKURACD_To.Value
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
                    strRec = "CLI"
                Case "2"
                    strRec = "JA"
                Case "3"
                    strRec = "JA"
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
                    strRec = "hdnJACD_From"
                Case "3"
                    strRec = "hdnJACD_To"
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
                    strRec = "txtJACD_From"
                Case "3"
                    strRec = "txtJACD_To"
            End Select
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�R�[�h��Ԃ��I�u�W�F�N�g�̖��O�l��n���v���p�e�B�Q
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
                        strRec = "btnJACD_From"
                    Case "3"
                        strRec = "btnJACD_To"
                End Select
            End If

            If hdnCalendar.Value = "1" Then
                strRec = "txtTRGDATE_From"
            ElseIf hdnCalendar.Value = "2" Then
                strRec = "txtTRGDATE_To"
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
            End Select
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�N���A����I�u�W�F�N�g��n���v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pClear() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "0" Then
                strRec = "txtJACD_From,hdnJACD_From,hdnJACD_From_CLI,txtJACD_To,hdnJACD_To,hdnJACD_To_CLI"
            ElseIf hdnPopcrtl.Value = "1" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = ""
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
                strRec = "txtTRGDATE_From"
            ElseIf hdnCalendar.Value = "2" Then
                strRec = "txtTRGDATE_To"
            End If
            Return strRec
        End Get
    End Property

End Class
