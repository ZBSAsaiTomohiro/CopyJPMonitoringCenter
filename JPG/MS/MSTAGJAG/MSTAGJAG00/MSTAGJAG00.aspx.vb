'***********************************************
'JA�S���ҁE�A����E���ӎ����}�X�^  ���C�����
'***********************************************
' �ύX����
' 2015/11/04 T.Ono �V�K�쐬

Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common
Imports JPG.Common.log

Imports System.Text
Imports System.IO

Partial Class MSTAGJAG00
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

        '.NET�̎d�l�ύX�ɂ��AReadOnly������ASPX�ł���ƁA�T�[�o���Œl�̎Q�Ƃ��ł��Ȃ��Ȃ邽�߁AVB����Attribute�ł���
        If MyBase.IsPostBack = False Then
            txtKURACD.Attributes.Add("ReadOnly", "true")
            txtACBCD.Attributes.Add("ReadOnly", "true")
            txtGROUPCD.Attributes.Add("ReadOnly", "true")
            txtFileName1.Attributes.Add("ReadOnly", "true")
            txtFileName2.Attributes.Add("ReadOnly", "true")
            'JA�S���ҁE��߯�FAX
            txtTANCD_1.Attributes.Add("ReadOnly", "true")
            txtTANCD_2.Attributes.Add("ReadOnly", "true")
            txtTANCD_3.Attributes.Add("ReadOnly", "true")
            txtTANCD_4.Attributes.Add("ReadOnly", "true")
            txtTANCD_5.Attributes.Add("ReadOnly", "true")
            txtTANCD_6.Attributes.Add("ReadOnly", "true")
            txtTANCD_7.Attributes.Add("ReadOnly", "true")
            txtTANCD_8.Attributes.Add("ReadOnly", "true")
            txtTANCD_9.Attributes.Add("ReadOnly", "true")
            txtTANCD_10.Attributes.Add("ReadOnly", "true")
            txtTANCD_11.Attributes.Add("ReadOnly", "true")
            txtTANCD_12.Attributes.Add("ReadOnly", "true")
            txtTANCD_13.Attributes.Add("ReadOnly", "true")
            txtTANCD_14.Attributes.Add("ReadOnly", "true")
            txtTANCD_15.Attributes.Add("ReadOnly", "true")
            txtTANCD_16.Attributes.Add("ReadOnly", "true")
            txtTANCD_17.Attributes.Add("ReadOnly", "true")
            txtTANCD_18.Attributes.Add("ReadOnly", "true")
            txtTANCD_19.Attributes.Add("ReadOnly", "true")
            txtTANCD_20.Attributes.Add("ReadOnly", "true")
            txtTANCD_21.Attributes.Add("ReadOnly", "true")
            txtTANCD_22.Attributes.Add("ReadOnly", "true")
            txtTANCD_23.Attributes.Add("ReadOnly", "true")
            txtTANCD_24.Attributes.Add("ReadOnly", "true")
            txtTANCD_25.Attributes.Add("ReadOnly", "true")
            txtTANCD_26.Attributes.Add("ReadOnly", "true")
            txtTANCD_27.Attributes.Add("ReadOnly", "true")
            txtTANCD_28.Attributes.Add("ReadOnly", "true")
            txtTANCD_29.Attributes.Add("ReadOnly", "true")
            txtTANCD_30.Attributes.Add("ReadOnly", "true")
            '����FAX&Ұ�
            txtTANCD2_1.Attributes.Add("ReadOnly", "true")
            txtTANCD2_2.Attributes.Add("ReadOnly", "true")
            txtTANCD2_3.Attributes.Add("ReadOnly", "true")
            txtTANCD2_4.Attributes.Add("ReadOnly", "true")
            txtTANCD2_5.Attributes.Add("ReadOnly", "true")
            txtTANCD2_6.Attributes.Add("ReadOnly", "true")
            txtTANCD2_7.Attributes.Add("ReadOnly", "true")
            txtTANCD2_8.Attributes.Add("ReadOnly", "true")
            txtTANCD2_9.Attributes.Add("ReadOnly", "true")
            txtTANCD2_10.Attributes.Add("ReadOnly", "true")
            txtTANCD2_11.Attributes.Add("ReadOnly", "true")
            txtTANCD2_12.Attributes.Add("ReadOnly", "true")
            txtTANCD2_13.Attributes.Add("ReadOnly", "true")
            txtTANCD2_14.Attributes.Add("ReadOnly", "true")
            txtTANCD2_15.Attributes.Add("ReadOnly", "true")
            txtTANCD2_16.Attributes.Add("ReadOnly", "true")
            txtTANCD2_17.Attributes.Add("ReadOnly", "true")
            txtTANCD2_18.Attributes.Add("ReadOnly", "true")
            txtTANCD2_19.Attributes.Add("ReadOnly", "true")
            txtTANCD2_20.Attributes.Add("ReadOnly", "true")
            txtTANCD2_21.Attributes.Add("ReadOnly", "true")
            txtTANCD2_22.Attributes.Add("ReadOnly", "true")
            txtTANCD2_23.Attributes.Add("ReadOnly", "true")
            txtTANCD2_24.Attributes.Add("ReadOnly", "true")
            txtTANCD2_25.Attributes.Add("ReadOnly", "true")
            txtTANCD2_26.Attributes.Add("ReadOnly", "true")
            txtTANCD2_27.Attributes.Add("ReadOnly", "true")
            txtTANCD2_28.Attributes.Add("ReadOnly", "true")
            txtTANCD2_29.Attributes.Add("ReadOnly", "true")
            txtTANCD2_30.Attributes.Add("ReadOnly", "true")
            txtAYMD.Attributes.Add("ReadOnly", "true")
            txtUYMD.Attributes.Add("ReadOnly", "true")
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
        '[�S���҃}�X�^]�g�p�\����(�^:��/�c:��/��:��/�o:�~)
        AuthC.fncAuthCheck(Server, AuthC.pGROUP_UNKOU & "," & AuthC.pGROUP_EIGYOU & "," & AuthC.pGROUP_KANSHI)

        '//------------------------------------------
        '<TODO>�|�b�v�A�b�v/�o�^�n�t���[���̏o��
        '      [hdnKensaku(Hidden)]���쐬���鎖
        If hdnKensaku.Value = "COPOPUPG00" Then
            Server.Transfer("../../../Popup/COPOPUPG00.aspx")
        End If
        'Tips HTML�^�O�̎g�p���@
        If hdnKensaku.Value = "MSTAGJPG00" Then
            Server.Transfer("MSTAGJPG00.aspx")
        End If
        '�x��ꗗ��\������
        If hdnKensaku.Value = "MSTAGJCG00" Then
            Server.Transfer("MSTAGJCG00.aspx")
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
             MyBase.MapPath("../../../MS/MSTAGJAG/MSTAGJAG00/") & "MSTAGJAG00.js"))
        '<�t�H�[�J�X�֘A�֐�>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncFo.js"))
        '<���̓`�F�b�N�֐�>
        'strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncChk.js"))�@����ʐ�p�̂��̂��g��
        '<�d�b�ԍ��`�F�b�N�֐�>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncTel.js"))
        '<���l�֘A�֐�>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncNumChk.js"))
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
            '������ʂ̏�Ԑݒ�
            Call fncIni_statebf()

            '//--------------------------------------------------------------------------
            '�t�H�[�J�X���Z�b�g����
            strMsg.Append("Form1.btnSelect.focus();")

            '//-----------------------------------------------------
            '// �c�Ə��O���[�v�݂̂ɏ������Ă���ꍇ�A[�c�Ə����j���[]���J�ڂ��Ă��Ă����
            '// �I���{�^����������[�c�Ə����j���[]�ɖ߂�
            '//-----------------------------------------------------

            hdnBackUrl.Value = ""

            Dim strGROUPNAME As String = AuthC.pGROUPNAME
            Dim arrGroupName() As String = strGROUPNAME.Split(Convert.ToChar(","))
            Dim arrKanshiGroup() As String = AuthC.pGROUP_KANSHI.Split(Convert.ToChar(","))
            Dim i As Integer
            Dim bolGroupFLG As Boolean = False

            '�^�s�J�����E�c�Ə��̏����`�F�b�N
            If Array.IndexOf(arrGroupName, AuthC.pGROUP_UNKOU) >= 0 Or _
                Array.IndexOf(arrGroupName, AuthC.pGROUP_EIGYOU) >= 0 Then
                bolGroupFLG = True
            End If
            '�Ď��Z���^�[�����`�F�b�N
            If bolGroupFLG = False Then
                For i = 0 To arrKanshiGroup.Length - 1
                    If Array.IndexOf(arrGroupName, arrKanshiGroup(i)) >= 0 Then
                        bolGroupFLG = True
                        '//�c�Ə��O���[�v
                        hdnBackUrl.Value = "KANSHI"
                        Exit For
                    End If
                Next i
            End If
            If bolGroupFLG = False Then
                Dim j As Integer
                Dim intEIGYOU_LEN As Integer
                Dim intGROUP_LEN As Integer
                intEIGYOU_LEN = AuthC.pGROUP_EIGYOU.Length
                For j = 0 To arrGroupName.Length - 1
                    intGROUP_LEN = arrGroupName(j).Length
                    If intGROUP_LEN > 0 Then
                        If Convert.ToString(arrGroupName(j)).Substring(intGROUP_LEN - intEIGYOU_LEN, intEIGYOU_LEN) = AuthC.pGROUP_EIGYOU Then
                            '//�c�Ə��O���[�v
                            hdnBackUrl.Value = "EIGYOU"
                        End If
                    End If
                Next
            End If

            '����ł́A���ӎ����^�u��\�����Ȃ�
            If InStr(AuthC.pGROUPNAME, "0�Ď��Ɩ��P��") > 0 Then
                hdntab.Value = "1"      '�\���Ȃ�
            Else
                hdntab.Value = "0"      '�\������
            End If

        Else
            '//--------------------------------------
            '//�@�Q��ڈȍ~���s�����
            '//--------------------------------------

            '�񍐗v�E�s�v�^�u�A���x���̕\����ݒ�B
            lblpre.Text = "JA���ӎ���"
            guidelineClck1.Text = "JA���ӎ���1"         '2019/11/01 w.ganeko 2019�Ď����P
            guidelineClck2.Text = "JA���ӎ���2"         '2019/11/01 w.ganeko 2019�Ď����P
            guidelineClck3.Text = "JA���ӎ���3"         '2019/11/01 w.ganeko 2019�Ď����P
            strMsg.Append("Form1.document.getElementById('tab4').style.display = 'block';")
        End If

        '//�S���敪�̃��W�I�{�^���Ő��䂷�邽��
        strMsg.Append("window_open();")

        '//-------------------------------------------------
        '<TODO>�����̉��ID��HIDDEN��hdnMyAspx�ɏ������ށi�V�X�e�����ʁj
        hdnMyAspx.Value = "MSTAGJAG00"
        '//-------------------------------------------------


        '//-------------------------------------------------
        fncSearchAndSetFileName12() ' �t�@�C�����������\��

        ' �R���{�{�b�N�X�̃Z�b�g���e���ALoad����Ɠx�ɃN���A�����̂ŁA����Z�b�g���Ȃ���
        Dim sAUTO_KBN(30) As String
        Dim sAUTO_ZERO_FLG(30) As String
        Dim sSD_PRT_FLG(30) As String    '2020/11/01 T.Ono add 2020�Ď����P
        Dim objAUTO_KBN As JPG.Common.Controls.CTLCombo
        Dim objAUTO_ZERO_FLG As JPG.Common.Controls.CTLCombo
        Dim objSD_PRT_FLG As JPG.Common.Controls.CTLCombo    '2020/11/01 T.Ono add 2020�Ď����P
        'fncCombo_Get(sAUTO_KBN, sAUTO_ZERO_FLG)             '2020/11/01 T.Ono mod 2020�Ď����P
        fncCombo_Get(sAUTO_KBN, sAUTO_ZERO_FLG, sSD_PRT_FLG)
        fncCombo_Create_AUTOKBN()
        fncCombo_Create_AUTOZEROFLG()
        fncCombo_Create_SDPRTFLG()    '2020/11/01 T.Ono add 2020�Ď����P
        For i As Integer = 1 To 30
            objAUTO_KBN = CType(FindControl("cboAUTO_KBN_" & CStr(i)), JPG.Common.Controls.CTLCombo)
            objAUTO_ZERO_FLG = CType(FindControl("cboAUTO_ZERO_FLG_" & CStr(i)), JPG.Common.Controls.CTLCombo)
            objSD_PRT_FLG = CType(FindControl("cboSD_PRT_FLG_" & CStr(i)), JPG.Common.Controls.CTLCombo)    '2020/11/01 T.Ono add 2020�Ď����P
            fncCombo_Select(objAUTO_KBN, sAUTO_KBN(i))
            fncCombo_Select(objAUTO_ZERO_FLG, sAUTO_ZERO_FLG(i))
            fncCombo_Select(objSD_PRT_FLG, sSD_PRT_FLG(i)) '2020/11/01 T.Ono add 2020�Ď����P
        Next

        '�t�@�C���֌W�{�^���ɃC�x���g��ǉ�
        btnFileDelete1.Attributes("OnClick") = "return confirm('�폜���Ă�낵���ł����H');"
        btnFileDelete2.Attributes("OnClick") = "return confirm('�폜���Ă�낵���ł����H');"
        btnFileUpload.Attributes("OnClick") = "return btnFileUpload_onclick();"
        '//-------------------------------------------------

    End Sub

    '******************************************************************************
    '* ���������������O�̉�ʏ�ԁiReadOnly��Disabled�j
    '********************************/*********************************************
    Private Sub fncIni_statebf()
        '//--------------------------------------------------------------------------
        '<TODO>�����O�̏�ԂɃR���g���[���̏�Ԃ�ݒ肷��

        btnKURACD.Disabled = False
        btnACBCD.Disabled = False
        btnGROUPCD.Disabled = False

    End Sub

    '******************************************************************************
    '* �������������ꂽ��̉�ʏ�ԁiReadOnly��Disabled�j
    '******************************************************************************
    Private Sub fncIni_stateaf()
        '//--------------------------------------------------------------------------
        '<TODO>������̏�ԂɃR���g���[���̏�Ԃ�ݒ肷��
        '

        '.NET �g�p�ύX�ɂ��AReadOnly��VB����Attribute�ł���
        txtKURACD.Attributes.Add("ReadOnly", "true")
        txtACBCD.Attributes.Add("ReadOnly", "true")
        txtGROUPCD.Attributes.Add("ReadOnly", "true")
        txtFileName1.Attributes.Add("ReadOnly", "true")
        txtFileName2.Attributes.Add("ReadOnly", "true")
        txtTANCD_1.Attributes.Add("ReadOnly", "true")
        txtTANCD_2.Attributes.Add("ReadOnly", "true")
        txtTANCD_3.Attributes.Add("ReadOnly", "true")
        txtTANCD_4.Attributes.Add("ReadOnly", "true")
        txtTANCD_5.Attributes.Add("ReadOnly", "true")
        txtTANCD_6.Attributes.Add("ReadOnly", "true")
        txtTANCD_7.Attributes.Add("ReadOnly", "true")
        txtTANCD_8.Attributes.Add("ReadOnly", "true")
        txtTANCD_9.Attributes.Add("ReadOnly", "true")
        txtTANCD_10.Attributes.Add("ReadOnly", "true")
        txtTANCD_11.Attributes.Add("ReadOnly", "true")
        txtTANCD_12.Attributes.Add("ReadOnly", "true")
        txtTANCD_13.Attributes.Add("ReadOnly", "true")
        txtTANCD_14.Attributes.Add("ReadOnly", "true")
        txtTANCD_15.Attributes.Add("ReadOnly", "true")
        txtTANCD_16.Attributes.Add("ReadOnly", "true")
        txtTANCD_17.Attributes.Add("ReadOnly", "true")
        txtTANCD_18.Attributes.Add("ReadOnly", "true")
        txtTANCD_19.Attributes.Add("ReadOnly", "true")
        txtTANCD_20.Attributes.Add("ReadOnly", "true")
        txtTANCD_21.Attributes.Add("ReadOnly", "true")
        txtTANCD_22.Attributes.Add("ReadOnly", "true")
        txtTANCD_23.Attributes.Add("ReadOnly", "true")
        txtTANCD_24.Attributes.Add("ReadOnly", "true")
        txtTANCD_25.Attributes.Add("ReadOnly", "true")
        txtTANCD_26.Attributes.Add("ReadOnly", "true")
        txtTANCD_27.Attributes.Add("ReadOnly", "true")
        txtTANCD_28.Attributes.Add("ReadOnly", "true")
        txtTANCD_29.Attributes.Add("ReadOnly", "true")
        txtTANCD_30.Attributes.Add("ReadOnly", "true")
        txtTANCD2_1.Attributes.Add("ReadOnly", "true")
        txtTANCD2_2.Attributes.Add("ReadOnly", "true")
        txtTANCD2_3.Attributes.Add("ReadOnly", "true")
        txtTANCD2_4.Attributes.Add("ReadOnly", "true")
        txtTANCD2_5.Attributes.Add("ReadOnly", "true")
        txtTANCD2_6.Attributes.Add("ReadOnly", "true")
        txtTANCD2_7.Attributes.Add("ReadOnly", "true")
        txtTANCD2_8.Attributes.Add("ReadOnly", "true")
        txtTANCD2_9.Attributes.Add("ReadOnly", "true")
        txtTANCD2_10.Attributes.Add("ReadOnly", "true")
        txtTANCD2_11.Attributes.Add("ReadOnly", "true")
        txtTANCD2_12.Attributes.Add("ReadOnly", "true")
        txtTANCD2_13.Attributes.Add("ReadOnly", "true")
        txtTANCD2_14.Attributes.Add("ReadOnly", "true")
        txtTANCD2_15.Attributes.Add("ReadOnly", "true")
        txtTANCD2_16.Attributes.Add("ReadOnly", "true")
        txtTANCD2_17.Attributes.Add("ReadOnly", "true")
        txtTANCD2_18.Attributes.Add("ReadOnly", "true")
        txtTANCD2_19.Attributes.Add("ReadOnly", "true")
        txtTANCD2_20.Attributes.Add("ReadOnly", "true")
        txtTANCD2_21.Attributes.Add("ReadOnly", "true")
        txtTANCD2_22.Attributes.Add("ReadOnly", "true")
        txtTANCD2_23.Attributes.Add("ReadOnly", "true")
        txtTANCD2_24.Attributes.Add("ReadOnly", "true")
        txtTANCD2_25.Attributes.Add("ReadOnly", "true")
        txtTANCD2_26.Attributes.Add("ReadOnly", "true")
        txtTANCD2_27.Attributes.Add("ReadOnly", "true")
        txtTANCD2_28.Attributes.Add("ReadOnly", "true")
        txtTANCD2_29.Attributes.Add("ReadOnly", "true")
        txtTANCD2_30.Attributes.Add("ReadOnly", "true")
        txtAYMD.Attributes.Add("ReadOnly", "true")
        txtUYMD.Attributes.Add("ReadOnly", "true")
    End Sub

    '******************************************************************************
    '* �e�R���g���[���̐ݒ�l�̏�����
    '******************************************************************************
    Private Sub fncIni_format()
        '//--------------------------------------------------------------------------
        '<TODO>�R���g���[���̒l������������

        txtKURACD.Text = ""
        hdnKURACD.Value = ""
        txtACBCD.Text = ""
        hdnACBCD.Value = ""
        txtGROUPCD.Text = ""
        hdnGROUPCD.Value = ""
        hdnKBN.Value = ""
        hdnKEY.Value = ""
        hdnDBKBN.Value = ""
        txtGROUPNEW.Text = ""

        '�L�[�ȊO�̒l������������
        Call fncIni_notkey()

    End Sub

    '******************************************************************************
    '* �L�[�ȊO�̒l������������
    '******************************************************************************
    Private Sub fncIni_notkey()
        Call fncIni_date()
        '//--------------------------------------------------------------------------
        '<TODO>�R���g���[���̒l������������

        hdnKURACD_MOTO.Value = ""
        hdnGROUPCD_MOTO.Value = ""

        Dim objCopy As System.Web.UI.WebControls.CheckBox 
        Dim objDISP_NO As System.Web.UI.HtmlControls.HtmlInputHidden
        Dim objTANCD As System.Web.UI.WebControls.TextBox
        Dim objTANNM As System.Web.UI.WebControls.TextBox
        Dim objRENTEL1 As System.Web.UI.WebControls.TextBox
        Dim objRENTEL2 As System.Web.UI.WebControls.TextBox
        Dim objRENTEL3 As System.Web.UI.WebControls.TextBox
        Dim objFAXNO As System.Web.UI.WebControls.TextBox
        Dim objBIKO As System.Web.UI.WebControls.TextBox
        Dim objAUTO_MAIL As System.Web.UI.WebControls.TextBox
        Dim objSPOT_MAIL As System.Web.UI.WebControls.TextBox
        Dim objMAIL_PASS As System.Web.UI.WebControls.TextBox
        Dim objAUTO_MAIL_PASS As System.Web.UI.WebControls.TextBox
        Dim objAUTO_FAXNO As System.Web.UI.WebControls.TextBox
        Dim objAUTO_FAXNM As System.Web.UI.WebControls.TextBox
        Dim i As Integer

        For i = 1 To 30
            '�R���g���[������T���o���A�^�ϊ�
            objCopy = CType(FindControl("chkCopy_" & CStr(i)), System.Web.UI.WebControls.CheckBox)
            objDISP_NO = CType(FindControl("hdnDISP_NO_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
            objTANCD = CType(FindControl("txtTANCD_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objTANNM = CType(FindControl("txtTANNM_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objRENTEL1 = CType(FindControl("txtRENTEL1_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objRENTEL2 = CType(FindControl("txtRENTEL2_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objRENTEL3 = CType(FindControl("txtRENTEL3_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objFAXNO = CType(FindControl("txtFAXNO_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objBIKO = CType(FindControl("txtBIKO_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objAUTO_MAIL = CType(FindControl("txtAUTO_MAIL_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objSPOT_MAIL = CType(FindControl("txtSPOT_MAIL_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objMAIL_PASS = CType(FindControl("txtMAIL_PASS_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objAUTO_MAIL_PASS = CType(FindControl("txtAUTO_MAIL_PASS_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objAUTO_FAXNO = CType(FindControl("txtAUTO_FAXNO_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objAUTO_FAXNM = CType(FindControl("txtAUTO_FAXNM_" & CStr(i)), System.Web.UI.WebControls.TextBox)

            objCopy.Checked = False 
            objDISP_NO.Value = CStr(i) '�@�B�I�ɔԍ���t����
            objTANCD.Text = Right("00" & CStr(i), 2) '�@�B�I�ɔԍ���t����
            objTANNM.Text = ""
            objRENTEL1.Text = ""
            objRENTEL2.Text = ""
            objRENTEL3.Text = ""
            objFAXNO.Text = ""
            objBIKO.Text = ""
            objAUTO_MAIL.Text = ""
            objSPOT_MAIL.Text = ""
            objMAIL_PASS.Text = ""
            objAUTO_MAIL_PASS.Text = ""
            objAUTO_FAXNO.Text = ""
            objAUTO_FAXNM.Text = ""
        Next

        txtGROUPNM.Text = ""

        txtGUIDELINE.Text = ""
        txtGUIDELINE2.Text = ""  '2019/11/01 w.ganeko 2019�Ď����P
        txtGUIDELINE3.Text = ""  '2019/11/01 w.ganeko 2019�Ď����P
        guidelineClck1.Checked = True  '2019/11/01 w.ganeko 2019�Ď����P
        guidelineClck2.Checked = False '2019/11/01 w.ganeko 2019�Ď����P
        guidelineClck3.Checked = False '2019/11/01 w.ganeko 2019�Ď����P
        txtGUIDELINENM1.Text = "" '2020/10/05 T.Ono add �Ď����P2020
        txtGUIDELINENM2.Text = "" '2020/10/05 T.Ono add �Ď����P2020
        txtGUIDELINENM3.Text = "" '2020/10/05 T.Ono add �Ď����P2020
        checkedRadio(rdoFAXJA1)
        checkedRadio(rdoFAXKURA1)
        hdnFAXJA_MOTO.Value = "9"
        hdnFAXKURA_MOTO.Value = "9"

        '�t�@�C���֘A�����N���A
        hdnFileKey.Text = ""
        txtFileName1.Text = ""
        txtFileName2.Text = ""

        ' �R���{�{�b�N�X�̃Z�b�g
        fncCombo_Create_AUTOKBN()
        fncCombo_Create_AUTOZEROFLG()
        fncCombo_Create_SDPRTFLG()    '2020/11/01 T.Ono add 2020�Ď����P

    End Sub

    '******************************************************************************
    '* ���t(�쐬���X�V��)������������
    '******************************************************************************
    Private Sub fncIni_date()
        txtAYMD.Text = ""
        txtUYMD.Text = ""
    End Sub

    '******************************************************************************
    '* �����{�^�����������ꂽ�Ƃ��̏���
    '******************************************************************************
    Private Sub btnSelect_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.ServerClick
        Dim strRec As String

        '�f�[�^���������A�f�[�^���o�͂��܂�
        strRec = fncbtnKensaku_ClickEvent("1")

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
    '* �o�^�{�^�����������ꂽ�Ƃ��̏���
    '******************************************************************************
    Private Sub btnUpdate_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.ServerClick
        Dim strRec As String
        strRec = fncbtnJikkou_ClickEvent(hdnKBN.Value)

        Call fncIni_stateaf()
    End Sub


    '******************************************************************************
    '* ����{�^�����������ꂽ�Ƃ��̏���
    '******************************************************************************
    Private Sub btnClear_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.ServerClick
        Call fncIni_format()    '//�l�̏�����
        Call fncIni_statebf()   '//��Ԃ̏�����

        '//------------------------------------------
        '<TODO>�t�H�[�J�X���Z�b�g����i������ʂɖ߂����̂�(PageLoad���l)�L�[�ɃZ�b�g�j
        strMsg.Append("Form1.btnSelect.focus();")
    End Sub

    '******************************************************************************
    '*�@�T�@�v�F�i���ݏ�����n���v���p�e�B
    '*�@���@�l�F���o�����P�̒l��n��
    '******************************************************************************
    Public ReadOnly Property pCode1() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                If hdnBackUrl.Value = "EIGYOU" Then
                    '//�c�Ə��O���[�v�̏ꍇ�͊Ď��Z���^�[���R�t�����Ȃ��ׁA�S�N���C�A���g���o��
                    strRec = ""
                Else
                    '//
                    strRec = AuthC.pAUTHCENTERCD    '//�N���C�A���g�R�[�h�ꗗ �`�c�F�؂̎g�p�\�Ď��Z���^�[�R�[�h
                End If
            ElseIf hdnPopcrtl.Value = "2" Then      '//JA�x���R�[�h�ꗗ
                strRec = hdnKURACD.Value
            ElseIf hdnPopcrtl.Value = "3" Then      '//�O���[�v�R�[�h�ꗗ
                If hdnBackUrl.Value = "EIGYOU" Then
                    '//�c�Ə��O���[�v�̏ꍇ�͊Ď��Z���^�[���R�t�����Ȃ��ׁA�S�N���C�A���g���o��
                    strRec = ""
                Else
                    '//
                    strRec = AuthC.pAUTHCENTERCD    '//�N���C�A���g�R�[�h�ꗗ �`�c�F�؂̎g�p�\�Ď��Z���^�[�R�[�h
                End If
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�i���ݏ�����n���v���p�e�B
    '*�@���@�l�F���o�����Q�̒l��n��
    '******************************************************************************
    Public ReadOnly Property pCode2() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "2" Then      '//JA�x���R�[�h�ꗗ
                strRec = ""
            ElseIf hdnPopcrtl.Value = "3" Then      '//�O���[�v�R�[�h�ꗗ
                strRec = hdnKURACD.Value.Trim
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�i���ݏ�����n���v���p�e�B
    '*�@���@�l�F���o�����R�̒l��n��
    '******************************************************************************
    Public ReadOnly Property pCode3() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "2" Then      '//JA�x���R�[�h�ꗗ
                strRec = ""
            ElseIf hdnPopcrtl.Value = "3" Then      '//�O���[�v�R�[�h�ꗗ
                strRec = hdnACBCD.Value.Trim
            Else
                strRec = ""
            End If
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
            If hdnPopcrtl.Value = "1" Then          '//�N���C�A���g�R�[�h�ꗗ
                strRec = "�N���C�A���g�R�[�h�ꗗ"
            ElseIf hdnPopcrtl.Value = "2" Then      '//�R�[�h�ꗗ
                strRec = "�i�`�x���R�[�h�ꗗ"
            ElseIf hdnPopcrtl.Value = "3" Then      '//�O���[�v�R�[�h�ꗗ
                strRec = "�O���[�v�R�[�h�ꗗ"
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
            If hdnPopcrtl.Value = "1" Then          '//�N���C�A���g�R�[�h�ꗗ
                strRec = "CLI"
            ElseIf hdnPopcrtl.Value = "2" Then      '//JA�x���R�[�h�ꗗ
                strRec = "JASS3"
            ElseIf hdnPopcrtl.Value = "3" Then      '//�O���[�v�R�[�h�ꗗ
                strRec = "JAHOKOKU"
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
                strRec = "hdnKURACD"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = "hdnACBCD"
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = "hdnGROUPCD"
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
                strRec = "txtKURACD"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = "txtACBCD"
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = "txtGROUPCD"
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�R�[�h��Ԃ��I�u�W�F�N�g�̖��O�l��n���v���p�e�B
    '*�@���@�l�F�f�[�^�I����A�R�[�h��Ԃ��I�u�W�F�N�g�����w�肷��@2015/02/18 T.Ono add 2014���P�J�� No15
    '******************************************************************************
    Public ReadOnly Property pBackCode2() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
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
    '*�@�T�@�v�F���̂�Ԃ��I�u�W�F�N�g�̖��O�l��n���v���p�e�B
    '*�@���@�l�F�f�[�^�I����A���̂�Ԃ��I�u�W�F�N�g�����w�肷��@2015/02/18 T.Ono add 2014���P�J�� No15
    '******************************************************************************
    Public ReadOnly Property pBackName2() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
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
    '*�@�T�@�v�F�t�H�[�J�X��Ԃ��I�u�W�F�N�g�̖��O�l��n���v���p�e�B
    '*�@���@�l�F�f�[�^�I����A�l��Ԃ�����ɁA�J�[�\�����Z�b�g����ꏊ�̎w��
    '******************************************************************************
    Public ReadOnly Property pBackFocs() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "btnKURACD"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = "btnACBCD"
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = "btnGROUPCD"
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
    Public ReadOnly Property pClear1() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "hdnACBCD"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = "hdnGROUPCD"
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = "txtGROUPNEW"
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
            If hdnPopcrtl.Value = "1" Then
                strRec = "txtACBCD"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = "txtGROUPCD"
            ElseIf hdnPopcrtl.Value = "3" Then      '//�o�^�ς݈ꗗ    2015/02/18 T.Ono add 2014���P�J�� No15
                strRec = ""
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�N���C�A���g�AJA�x���I�����͂��q�l�R�[�h(From)���N���A 2013/07/04 T.Ono add
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pClear3() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "hdnGROUPCD"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = "txtGROUPNEW"
            ElseIf hdnPopcrtl.Value = "3" Then      '//�o�^�ς݈ꗗ    2015/02/18 T.Ono add 2014���P�J�� No15
                strRec = ""
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�N���C�A���g�AJA�x���I�����͂��q�l�R�[�h(To)���N���A 2013/07/04 T.Ono add
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pClear4() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "txtGROUPCD"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = "txtGROUPNEW"
            ElseIf hdnPopcrtl.Value = "3" Then      '//�o�^�ς݈ꗗ    2015/02/18 T.Ono add 2014���P�J�� No15
                strRec = ""
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�N���C�A���g�AJA�x���I�����͂��q�l�����N���A 2013/07/04 T.Ono add
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pClear5() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "txtGROUPNEW"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "3" Then      '//�o�^�ς݈ꗗ    2015/02/18 T.Ono add 2014���P�J�� No15
                strRec = ""
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
                'strRec = "fncFAXKBNDisp" '2015/02/18 T.Ono mod 2014���P�J�� No15
                strRec = ""
            ElseIf hdnPopcrtl.Value = "2" Then  '�i�`�x��
                'strRec = "fncFAXKBNDisp" '2015/02/18 T.Ono mod 2014���P�J�� No15
                strRec = ""
            ElseIf hdnPopcrtl.Value = "3" Then  '�o�^�ς݈ꗗ    2015/02/18 T.Ono add 2014���P�J�� No15
                strRec = ""
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�o�^JA�x���ꗗ�̂��߁A�O���[�v�R�[�h��n���v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pGROUPCD() As String
        Get
            pGROUPCD = hdnGROUPCD.Value
        End Get
    End Property

    '******************************************************************************
    '* �f�[�^�̏o�͏���
    '******************************************************************************
    Private Function fncbtnKensaku_ClickEvent(ByVal pstrKBN As String) As String
        '1:�����{�^��
        '2:���s��o�́@(�t�H�[�J�X�̃Z�b�g���ς��܂�)
        Dim strRec As String

        strRec = "OK"

        fncIni_notkey() '�L�[�ȊO�̍��ڏ�����

        Try
            '//--------------------------------------
            '�����������s��
            Dim DateFncC As New CDateFnc
            Dim dbData As DataSet
            Dim UserCheckFLG As Boolean = True

            '�����{�^���������A�o�^��̌�����
            If pstrKBN = "1" Then
                '�����{�^������
                '�����L�[���Z�b�g(hdnKEY�AhdnDBKBN)�i�o�^�{�^���������́A�Z�b�g�ς݁j
                If (hdnGROUPCD.Value.Trim.Length > 0) Then
                    '�O���[�v�o�^������
                    hdnKEY.Value = hdnGROUPCD.Value.Trim
                    hdnDBKBN.Value = "2" 'DB�FKBN
                Else
                    '�N���C�A���g�o�^������
                    hdnKEY.Value = hdnKURACD.Value.Trim
                    hdnDBKBN.Value = "1"
                End If
            Else
                '�o�^��̌���
                If txtGROUPNEW.Text.Trim.Length > 0 Then
                    '�O���[�v�R�[�h�V�K�̏ꍇ�B�O���[�v�R�[�h�I���Ō��������Ƃ��Ɠ�����Ԃɂ��Ă����B
                    hdnGROUPCD.Value = txtGROUPNEW.Text.Trim
                End If
            End If


            '�������s
            dbData = fncDataSelect(hdnDBKBN.Value)

            If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
                '�f�[�^�����݂��Ȃ��ׁA�����̓G���[
                '���b�Z�[�W���o�͌�A�����O��Ԃɂ���B

                strMsg.Append("alert('�f�[�^�����݂��܂���');")
                strMsg.Append("Form1.btnSelect.focus();")
                Call fncIni_statebf()
                '//--------------------------------------------------------------------------
            Else
                '�f�[�^�����݂���ׁA�V�K�o�^�͕s��
                '�f�[�^���o�͌�A�������Ԃɂ���B

                '------------------------------------
                '<TODO>�f�[�^���o�͂���

                '�N���C�A���g�R�[�h
                hdnKURACD_MOTO.Value = hdnKURACD.Value
                '�O���[�v�R�[�h
                hdnGROUPCD_MOTO.Value = hdnGROUPCD.Value


                Dim sMinInsDate As String
                Dim sMaxUpdDate As String

                sMinInsDate = Convert.ToString(dbData.Tables(0).Rows(0).Item("INS_DATE"))
                sMaxUpdDate = Convert.ToString(dbData.Tables(0).Rows(0).Item("UPD_DATE"))

                Dim objDISP_NO As System.Web.UI.HtmlControls.HtmlInputHidden
                Dim objTANCD As System.Web.UI.WebControls.TextBox
                Dim objTANNM As System.Web.UI.WebControls.TextBox
                Dim objRENTEL1 As System.Web.UI.WebControls.TextBox
                Dim objRENTEL2 As System.Web.UI.WebControls.TextBox
                Dim objRENTEL3 As System.Web.UI.WebControls.TextBox
                Dim objFAXNO As System.Web.UI.WebControls.TextBox
                Dim objBIKO As System.Web.UI.WebControls.TextBox
                Dim objSPOT_MAIL As System.Web.UI.WebControls.TextBox
                Dim objMAIL_PASS As System.Web.UI.WebControls.TextBox
                Dim objAUTO_FAXNM As System.Web.UI.WebControls.TextBox
                Dim objAUTO_MAIL As System.Web.UI.WebControls.TextBox
                Dim objAUTO_MAIL_PASS As System.Web.UI.WebControls.TextBox
                Dim objAUTO_FAXNO As System.Web.UI.WebControls.TextBox
                Dim objAUTO_KBN As JPG.Common.Controls.CTLCombo
                Dim objAUTO_ZERO_FLG As JPG.Common.Controls.CTLCombo    '2020/11/01 T.Ono add 2020�Ď����P
                Dim objSD_PRT_FLG As JPG.Common.Controls.CTLCombo
                Dim objINS_DATE As System.Web.UI.HtmlControls.HtmlInputHidden
                Dim objINS_USER As System.Web.UI.HtmlControls.HtmlInputHidden
                Dim objUPD_DATE As System.Web.UI.HtmlControls.HtmlInputHidden
                Dim objUPD_USER As System.Web.UI.HtmlControls.HtmlInputHidden

                Dim strCboIndex As String '�R���{�{�b�N�X�I���C���f�b�N�X

                Dim i As Integer
                Dim intRow As Integer
                Dim sTANCD As String

                For intRow = 0 To dbData.Tables(0).Rows.Count - 1

                    If intRow >= 30 Then Exit For '30���ȏ�͏�������

                    '----------------------------
                    ' �ŏ��̓o�^���A�Ō�̍X�V��������ʍ��ڂɃZ�b�g
                    '----------------------------
                    '�o�^�����󂩁A�ȑO�̏ꍇ�A�Z�b�g
                    If sMinInsDate = "" _
                        Or Convert.ToString(dbData.Tables(0).Rows(0).Item("INS_DATE")) < sMinInsDate Then
                        sMinInsDate = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("INS_DATE"))
                    End If

                    '�X�V�����󂩁A����Ɍ�̏ꍇ�A�Z�b�g
                    If Convert.ToString(dbData.Tables(0).Rows(intRow).Item("UPD_DATE")) <> "" _
                        And Convert.ToString(dbData.Tables(0).Rows(intRow).Item("UPD_DATE")) >= sMaxUpdDate Then
                        sMaxUpdDate = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("UPD_DATE"))
                    End If

                    '----------------------------
                    ' ���׏�����ʍ��ڂɃZ�b�g
                    '----------------------------
                    sTANCD = Convert.ToString(CInt(dbData.Tables(0).Rows(intRow).Item("TANCD")))

                    If Trim(sTANCD) = "" Then
                        sTANCD = "0"
                    ElseIf IsNumeric(sTANCD) = False Then
                        sTANCD = "0"
                    End If

                    '�\���ԍ�����(�ݒ肳��Ă��Ȃ��ꍇ)�A���[�v���̉񐔂��Ⴂ�ꍇ(���Ԃœo�^����Ă���ꍇ�΍�)
                    If CInt(sTANCD) >= 1 Then
                        objDISP_NO = CType(FindControl("hdnDISP_NO_" & sTANCD), System.Web.UI.HtmlControls.HtmlInputHidden)
                        objTANCD = CType(FindControl("txtTANCD_" & sTANCD), System.Web.UI.WebControls.TextBox)
                        objTANNM = CType(FindControl("txtTANNM_" & sTANCD), System.Web.UI.WebControls.TextBox)
                        objRENTEL1 = CType(FindControl("txtRENTEL1_" & sTANCD), System.Web.UI.WebControls.TextBox)
                        objRENTEL2 = CType(FindControl("txtRENTEL2_" & sTANCD), System.Web.UI.WebControls.TextBox)
                        objRENTEL3 = CType(FindControl("txtRENTEL3_" & sTANCD), System.Web.UI.WebControls.TextBox)
                        objFAXNO = CType(FindControl("txtFAXNO_" & sTANCD), System.Web.UI.WebControls.TextBox)
                        objBIKO = CType(FindControl("txtBIKO_" & sTANCD), System.Web.UI.WebControls.TextBox)
                        objSPOT_MAIL = CType(FindControl("txtSPOT_MAIL_" & sTANCD), System.Web.UI.WebControls.TextBox)
                        objMAIL_PASS = CType(FindControl("txtMAIL_PASS_" & sTANCD), System.Web.UI.WebControls.TextBox)
                        objAUTO_FAXNM = CType(FindControl("txtAUTO_FAXNM_" & sTANCD), System.Web.UI.WebControls.TextBox)
                        objAUTO_MAIL = CType(FindControl("txtAUTO_MAIL_" & sTANCD), System.Web.UI.WebControls.TextBox)
                        objAUTO_MAIL_PASS = CType(FindControl("txtAUTO_MAIL_PASS_" & sTANCD), System.Web.UI.WebControls.TextBox)
                        objAUTO_FAXNO = CType(FindControl("txtAUTO_FAXNO_" & sTANCD), System.Web.UI.WebControls.TextBox)
                        objAUTO_KBN = CType(FindControl("cboAUTO_KBN_" & sTANCD), JPG.Common.Controls.CTLCombo)
                        objAUTO_ZERO_FLG = CType(FindControl("cboAUTO_ZERO_FLG_" & sTANCD), JPG.Common.Controls.CTLCombo)    '2020/11/01 T.Ono add 2020�Ď����P
                        objSD_PRT_FLG = CType(FindControl("cboSD_PRT_FLG_" & sTANCD), JPG.Common.Controls.CTLCombo)
                        objINS_DATE = CType(FindControl("hdnINS_DATE_" & sTANCD), System.Web.UI.HtmlControls.HtmlInputHidden)
                        objINS_USER = CType(FindControl("hdnINS_USER_" & sTANCD), System.Web.UI.HtmlControls.HtmlInputHidden)
                        objUPD_DATE = CType(FindControl("hdnUPD_DATE_" & sTANCD), System.Web.UI.HtmlControls.HtmlInputHidden)
                        objUPD_USER = CType(FindControl("hdnUPD_USER_" & sTANCD), System.Web.UI.HtmlControls.HtmlInputHidden)

                        objDISP_NO.Value = CStr(i)
                        objTANCD.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("TANCD"))
                        objTANNM.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("TANNM"))
                        objRENTEL1.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("RENTEL1"))
                        objRENTEL2.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("RENTEL2"))
                        objRENTEL3.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("RENTEL3"))
                        objFAXNO.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("FAXNO"))
                        objBIKO.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("BIKO"))
                        objSPOT_MAIL.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("SPOT_MAIL"))
                        objMAIL_PASS.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("MAIL_PASS"))
                        objAUTO_FAXNM.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("AUTO_FAXNM"))
                        objAUTO_MAIL.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("AUTO_MAIL"))
                        objAUTO_MAIL_PASS.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("AUTO_MAIL_PASS"))
                        objAUTO_FAXNO.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("AUTO_FAXNO"))
                        objINS_DATE.Value = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("INS_DATE"))
                        objINS_USER.Value = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("INS_USER"))
                        objUPD_DATE.Value = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("UPD_DATE"))
                        objUPD_USER.Value = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("UPD_USER"))


                        ' �������M�敪        ' 2013/07/04/ T.Ono add
                        strCboIndex = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("AUTO_KBN"))
                        fncCombo_Select(objAUTO_KBN, strCboIndex)

                        ' �[�������M�t���O    ' 2013/07/04/ T.Ono add
                        strCboIndex = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("AUTO_ZERO_FLG"))
                        fncCombo_Select(objAUTO_ZERO_FLG, strCboIndex)

                        ' �o���˗����e�E���l�\���t���O    ' 2020/11/01 T.Ono add 2020�Ď����P
                        strCboIndex = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("SD_PRT_FLG"))
                        fncCombo_Select(objSD_PRT_FLG, strCboIndex)

                        If "01" = objTANCD.Text Then

                            '�O���[�v�R�[�h��
                            txtGROUPNM.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("GROUPNM"))

                            'JA���ӎ����Z�b�g
                            txtGUIDELINE.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("GUIDELINE"))
                            txtGUIDELINE2.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("GUIDELINE2"))  '2019/11/01 w.ganeko 2019�Ď����P No 6
                            txtGUIDELINE3.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("GUIDELINE3"))  '2019/11/01 w.ganeko 2019�Ď����P No 6

                            'JA���ӎ����@�{�^����
                            txtGUIDELINENM1.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("GUIDELINENM1"))�@'2020/10/05 T.Ono add �Ď����P2020
                            txtGUIDELINENM2.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("GUIDELINENM2"))  '2020/10/05 T.Ono add �Ď����P2020
                            txtGUIDELINENM3.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("GUIDELINENM3"))  '2020/10/05 T.Ono add �Ď����P2020


                            'FAX�s�v�t���O(�ײ���)
                            hdnFAXKURA_MOTO.Value = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("FAXKURAKBN"))
                            If Convert.ToString(dbData.Tables(0).Rows(intRow).Item("FAXKURAKBN")) = "1" Then
                                checkedRadio(rdoFAXKURA2)
                            ElseIf Convert.ToString(dbData.Tables(0).Rows(intRow).Item("FAXKURAKBN")) = "0" Then
                                checkedRadio(rdoFAXKURA1)
                            Else
                                checkedRadio(rdoFAXKURA1)
                            End If

                            'FAX�s�v�t���O(JA)
                            hdnFAXJA_MOTO.Value = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("FAXKBN"))
                            If Convert.ToString(dbData.Tables(0).Rows(intRow).Item("FAXKBN")) = "1" Then
                                checkedRadio(rdoFAXJA2)
                            ElseIf Convert.ToString(dbData.Tables(0).Rows(intRow).Item("FAXKBN")) = "0" Then
                                checkedRadio(rdoFAXJA1)
                            Else
                                checkedRadio(rdoFAXJA1)
                            End If
                        End If

                    End If
                Next ' intRow

                '�O���[�v�R�[�h�@�@�O���[�v�R�[�h�V�K�o�^��O���[�v�R�[�h���ύX���̂��߂ɁA�ăZ�b�g
                If Convert.ToString(dbData.Tables(0).Rows(0).Item("KBN")) = "2" Then
                    txtGROUPCD.Text = Convert.ToString(dbData.Tables(0).Rows(0).Item("GROUPCD")) & " : " & Convert.ToString(dbData.Tables(0).Rows(0).Item("GROUPNM"))
                End If

                '�O���[�v�R�[�h�i�V�K�o�^�p�j������͋�
                txtGROUPNEW.Text = ""

                '�쐬��
                If sMinInsDate.Trim.Length >= 10 Then
                    txtAYMD.Text = sMinInsDate.Substring(0, 10)
                Else
                    txtAYMD.Text = ""
                End If
                '�X�V��
                If sMaxUpdDate.Trim.Length >= 10 Then
                    txtUYMD.Text = sMaxUpdDate.Substring(0, 10)
                Else
                    txtUYMD.Text = ""
                End If


                '�f�[�^���Ȃ����ڂɒS���҃R�[�h�𖄂߂Ă���
                For i = 1 To 30
                    objTANCD = CType(FindControl("txtTANCD_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                    If objTANCD.Text = "" Then
                        objTANCD.Text = Right("00" & CStr(i), 2)
                    End If
                Next

                If pstrKBN = "1" Then
                    '�����{�^��������
                    Call fncIni_stateaf()

                    '//------------------------------
                    '<TODO>�t�H�[�J�X���Z�b�g����i�f�[�^�����݂����̂ŃL�[�ȊO�ɃZ�b�g�j
                    strMsg.Append("Form1.btnSelect.focus();")
                End If


            End If
            dbData.Dispose()

            '���ӎ����̃��x��
            '�񍐗v�E�s�v�^�u(�N���C�A���g�������͔�\��)
            If hdnDBKBN.Value = "1" Then
                lblpre.Text = "�N���C�A���g���ӎ���"
                guidelineClck1.Text = "�N���C�A���g1"     '2019/11/01 w.ganeko 2019�Ď����P
                guidelineClck2.Text = "�N���C�A���g2"     '2019/11/01 w.ganeko 2019�Ď����P
                guidelineClck3.Text = "�N���C�A���g3"     '2019/11/01 w.ganeko 2019�Ď����P
                strMsg.Append("Form1.document.getElementById('tab4').style.display = 'none';")
            Else
                lblpre.Text = "JA���ӎ���"
                guidelineClck1.Text = "JA���ӎ���1"       '2019/11/01 w.ganeko 2019�Ď����P
                guidelineClck2.Text = "JA���ӎ���2"       '2019/11/01 w.ganeko 2019�Ď����P
                guidelineClck3.Text = "JA���ӎ���3"       '2019/11/01 w.ganeko 2019�Ď����P
            End If


            fncSearchAndSetFileName12() ' �t�@�C�����������\��

        Catch ex As Exception
            strRec = ex.ToString
            Dim ErrMsgC As New CErrMsg
            mlog("�V�X�e���G���[�F" & strRec)
            strMsg.Append("alert('�V�X�e���G���[�F" & ErrMsgC.mGetArtMsg(ex.ToString) & "');")
        End Try

        Return strRec

    End Function

    '******************************************************************************
    '* �o�^�E�폜���������ꂽ�Ƃ��̏���
    '******************************************************************************
    Private Function fncbtnJikkou_ClickEvent(ByVal pstrKBN As String) As String

        Dim strRec As String
        Dim DateFncC As New CDateFnc

        '//------------------------------------------
        '<TODO>�Ǝ���WEB�T�[�r����錾����
        Dim MSTAGJAW00C As New MSTAGJAG00MSTAGJAW00.MSTAGJAW00


        '�l��z��ɃZ�b�g
        Dim sDISP_NO(30) As String
        Dim sGROUPNM(30) As String
        Dim sTANCD(30) As String
        Dim sTANNM(30) As String
        Dim sRENTEL1(30) As String
        Dim sRENTEL2(30) As String
        Dim sRENTEL3(30) As String
        Dim sFAXNO(30) As String
        Dim sBIKO(30) As String
        Dim sSPOT_MAIL(30) As String
        Dim sMAIL_PASS(30) As String
        Dim sAUTO_FAXNM(30) As String
        Dim sAUTO_MAIL(30) As String
        Dim sAUTO_MAIL_PASS(30) As String
        Dim sAUTO_FAXNO(30) As String
        Dim sAUTO_KBN(30) As String
        Dim sAUTO_ZERO_FLG(30) As String
        Dim sSD_PRT_FLG(30) As String�@'2020/11/01 T.Ono add 2020�Ď����P
        Dim sGUIDELINE(30) As String
        Dim sGUIDELINE2(30) As String  '2019/11/01 w.ganeko 2019�Ď����P�@No6
        Dim sGUIDELINE3(30) As String�@'2019/11/01 w.ganeko 2019�Ď����P�@No6
        Dim sGUIDELINENM1(30) As String  '2020/11/01 T.Ono add 2020�Ď����P
        Dim sGUIDELINENM2(30) As String  '2020/11/01 T.Ono add 2020�Ď����P
        Dim sGUIDELINENM3(30) As String�@'2020/11/01 T.Ono add 2020�Ď����P
        Dim sFAXKURAKBN(30) As String
        Dim sFAXJAKBN(30) As String
        Dim sINS_DATE(30) As String
        Dim sINS_USER(30) As String
        Dim sUPD_DATE(30) As String
        Dim sUPD_USER(30) As String
        Dim objDISP_NO As System.Web.UI.HtmlControls.HtmlInputHidden
        Dim objTANCD As System.Web.UI.WebControls.TextBox
        Dim objTANNM As System.Web.UI.WebControls.TextBox
        Dim objRENTEL1 As System.Web.UI.WebControls.TextBox
        Dim objRENTEL2 As System.Web.UI.WebControls.TextBox
        Dim objRENTEL3 As System.Web.UI.WebControls.TextBox
        Dim objFAXNO As System.Web.UI.WebControls.TextBox
        Dim objBIKO As System.Web.UI.WebControls.TextBox
        Dim objSPOT_MAIL As System.Web.UI.WebControls.TextBox
        Dim objMAIL_PASS As System.Web.UI.WebControls.TextBox
        Dim objAUTO_FAXNM As System.Web.UI.WebControls.TextBox
        Dim objAUTO_MAIL As System.Web.UI.WebControls.TextBox
        Dim objAUTO_MAIL_PASS As System.Web.UI.WebControls.TextBox
        Dim objAUTO_FAXNO As System.Web.UI.WebControls.TextBox
        Dim objAUTO_KBN As JPG.Common.Controls.CTLCombo
        Dim objAUTO_ZERO_FLG As JPG.Common.Controls.CTLCombo
        Dim objSD_PRT_FLG As JPG.Common.Controls.CTLCombo    '2020/11/01 T.Ono add 2020�Ď����P
        Dim objINS_DATE As System.Web.UI.HtmlControls.HtmlInputHidden
        Dim objINS_USER As System.Web.UI.HtmlControls.HtmlInputHidden
        Dim objUPD_DATE As System.Web.UI.HtmlControls.HtmlInputHidden
        Dim objUPD_USER As System.Web.UI.HtmlControls.HtmlInputHidden
        Dim i As Integer


        '�L�[���Z�b�g(hdnKEY�AhdnDBKBN)
        If txtGROUPNEW.Text.Trim.Length > 0 Then
            '�O���[�v�R�[�h�V�K�o�^
            If fncDataCheck(txtGROUPNEW.Text.Trim) = False Then
                strRec = "�O���[�v�R�[�h���d�����Ă��܂�"
                strMsg.Append("alert('" & strRec & "');")

                '//------------------------------
                '<TODO>�t�H�[�J�X���Z�b�g����
                strMsg.Append("Form1.txtGROUPNEW.focus();")
                Return strRec
            End If
            hdnKEY.Value = txtGROUPNEW.Text.Trim
            hdnDBKBN.Value = "2"
        ElseIf hdnGROUPCD.Value.Trim.Length > 0 Then
            '�O���[�v�R�[�h�o�^
            hdnKEY.Value = hdnGROUPCD.Value.Trim
            hdnDBKBN.Value = "2"
        ElseIf hdnKURACD.Value.Trim.Length > 0 Then
            '�N���C�A���g�o�^
            hdnKEY.Value = hdnKURACD.Value.Trim
            hdnDBKBN.Value = "1"
        Else
            strRec = "�N���C�A���g�R�[�h�܂��̓O���[�v�R�[�h��I�����Ă�������"
            Return strRec
        End If

        For i = 1 To 30
            '�R���g���[������T���o���A�^�ϊ�
            objDISP_NO = CType(FindControl("hdnDISP_NO_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
            objTANCD = CType(FindControl("txtTANCD_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objTANNM = CType(FindControl("txtTANNM_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objRENTEL1 = CType(FindControl("txtRENTEL1_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objRENTEL2 = CType(FindControl("txtRENTEL2_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objRENTEL3 = CType(FindControl("txtRENTEL3_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objFAXNO = CType(FindControl("txtFAXNO_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objBIKO = CType(FindControl("txtBIKO_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objAUTO_MAIL = CType(FindControl("txtAUTO_MAIL_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objSPOT_MAIL = CType(FindControl("txtSPOT_MAIL_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objMAIL_PASS = CType(FindControl("txtMAIL_PASS_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objAUTO_MAIL_PASS = CType(FindControl("txtAUTO_MAIL_PASS_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objAUTO_FAXNO = CType(FindControl("txtAUTO_FAXNO_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objAUTO_FAXNM = CType(FindControl("txtAUTO_FAXNM_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objAUTO_KBN = CType(FindControl("cboAUTO_KBN_" & CStr(i)), JPG.Common.Controls.CTLCombo)
            objAUTO_ZERO_FLG = CType(FindControl("cboAUTO_ZERO_FLG_" & CStr(i)), JPG.Common.Controls.CTLCombo)
            objSD_PRT_FLG = CType(FindControl("cboSD_PRT_FLG_" & CStr(i)), JPG.Common.Controls.CTLCombo)    '2020/11/01 T.Ono add 2020�Ď����P
            objINS_DATE = CType(FindControl("hdnINS_DATE_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
            objINS_USER = CType(FindControl("hdnINS_USER_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
            objUPD_DATE = CType(FindControl("hdnUPD_DATE_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
            objUPD_USER = CType(FindControl("hdnUPD_USER_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)

            sDISP_NO(i) = objDISP_NO.Value
            sTANCD(i) = objTANCD.Text
            sTANNM(i) = Trim(objTANNM.Text)
            sRENTEL1(i) = Trim(objRENTEL1.Text)
            sRENTEL2(i) = Trim(objRENTEL2.Text)
            sRENTEL3(i) = Trim(objRENTEL3.Text)
            sFAXNO(i) = Trim(objFAXNO.Text)
            sBIKO(i) = Trim(objBIKO.Text)
            sSPOT_MAIL(i) = Trim(objSPOT_MAIL.Text)
            sMAIL_PASS(i) = Trim(objMAIL_PASS.Text)
            sAUTO_FAXNM(i) = Trim(objAUTO_FAXNM.Text)
            sAUTO_MAIL(i) = Trim(objAUTO_MAIL.Text)
            sAUTO_MAIL_PASS(i) = Trim(objAUTO_MAIL_PASS.Text)
            sAUTO_FAXNO(i) = Trim(objAUTO_FAXNO.Text)
            sAUTO_KBN(i) = Request.Form(objAUTO_KBN.ID)
            sAUTO_ZERO_FLG(i) = Request.Form(objAUTO_ZERO_FLG.ID)
            sSD_PRT_FLG(i) = Request.Form(objSD_PRT_FLG.ID)    '2020/11/01 T.Ono add 2020�Ď����P
            sINS_DATE(i) = objINS_DATE.Value
            sINS_USER(i) = objINS_USER.Value
            sUPD_DATE(i) = objUPD_DATE.Value
            sUPD_USER(i) = objUPD_USER.Value

            If i = 1 Then
                '�O���[�v�R�[�h��
                sGROUPNM(i) = Trim(txtGROUPNM.Text)

                '���ӎ���
                sGUIDELINE(i) = Trim(txtGUIDELINE.Text)
                sGUIDELINE2(i) = Trim(txtGUIDELINE2.Text) '2019/11/01 w.ganeko 2019�Ď����P No6
                sGUIDELINE3(i) = Trim(txtGUIDELINE3.Text) '2019/11/01 w.ganeko 2019�Ď����P No6

                '���ӎ����@�{�^����
                sGUIDELINENM1(i) = Trim(txtGUIDELINENM1.Text) '2020/10/05 T.Ono add�@�Ď����P2020
                sGUIDELINENM2(i) = Trim(txtGUIDELINENM2.Text) '2020/10/05 T.Ono add�@�Ď����P2020
                sGUIDELINENM3(i) = Trim(txtGUIDELINENM3.Text) '2020/10/05 T.Ono add�@�Ď����P2020

                'FAX�s�v�t���O
                'JA
                If rdoFAXJA1.Checked Then
                    sFAXJAKBN(i) = "0"
                ElseIf rdoFAXJA2.Checked Then
                    sFAXJAKBN(i) = "1"
                Else
                    sFAXJAKBN(i) = ""
                End If
                '�ײ���
                If rdoFAXKURA1.Checked Then
                    sFAXKURAKBN(i) = "0"
                ElseIf rdoFAXKURA2.Checked Then
                    sFAXKURAKBN(i) = "1"
                Else
                    sFAXKURAKBN(i) = ""
                End If
            Else
                sGROUPNM(i) = ""
                sGUIDELINE(i) = ""
                sGUIDELINE2(i) = ""  '2019/11/01 w.ganeko 2019�Ď����P No6
                sGUIDELINE3(i) = ""  '2019/11/01 w.ganeko 2019�Ď����P No6
                sGUIDELINENM1(i) = ""  '2020/10/05 T.Ono add �Ď����P2020
                sGUIDELINENM2(i) = ""  '2020/10/05 T.Ono add �Ď����P2020
                sGUIDELINENM3(i) = ""  '2020/10/05 T.Ono add �Ď����P2020
                sFAXKURAKBN(i) = ""
                sFAXJAKBN(i) = ""
            End If

        Next

        '--------------------------------------------
        '<TODO>WEB�T�[�r�X���Ăяo��
        strRec = MSTAGJAW00C.mSetEx(
                    CInt(pstrKBN),
                    hdnDBKBN.Value,
                    hdnKEY.Value,
                    sGROUPNM,
                    sTANCD,
                    sTANNM,
                    sRENTEL1,
                    sRENTEL2,
                    sRENTEL3,
                    sFAXNO,
                    sBIKO,
                    sSPOT_MAIL,
                    sMAIL_PASS,
                    sAUTO_FAXNM,
                    sAUTO_MAIL,
                    sAUTO_MAIL_PASS,
                    sAUTO_FAXNO,
                    sAUTO_KBN,
                    sAUTO_ZERO_FLG,
                    sSD_PRT_FLG,    '2020/11/01 T.Ono add 2020�Ď����P
                    sGUIDELINE,
                    sGUIDELINE2,    '2019/11/01 w.ganeko 2019�Ď����P No6
                    sGUIDELINE3,    '2019/11/01 w.ganeko 2019�Ď����P No6
                    sGUIDELINENM1,  '2020/11/01 T.Ono add 2020�Ď����P
                    sGUIDELINENM2,  '2020/11/01 T.Ono add 2020�Ď����P
                    sGUIDELINENM3,  '2020/11/01 T.Ono add 2020�Ď����P
                    sFAXKURAKBN,
                    sFAXJAKBN,
                    sINS_DATE,
                    sINS_USER,
                    sUPD_DATE,
                    sUPD_USER,
                    AuthC.pUSERNAME
                    )
        '--------------------------------------------
        '<TODO>�Ԃ�l�ɂ�鐧����s���B
        '�y���ʁz
        '  OK : ����ɏI�����܂���
        '   0 : ���̃��[�U�[�ɂ���ăf�[�^���X�V����Ă��܂��B�ēx�������Ă�������
        '   1 : ���Ƀf�[�^�����݂��܂�
        '   2 : �Ώۃf�[�^�����݂��܂���
        '   3 : �r�����䏈���ŃG���[���������܂����B�ēx���s���Ă�������
        Dim strRecTemp As String = strRec
        Dim strRecMsg As String
        Select Case strRec
            Case "OK"
                If pstrKBN = "1" Or pstrKBN = "2" Then
                    strRec = fncbtnKensaku_ClickEvent("2")
                ElseIf pstrKBN = "4" Then '4:�폜
                    Call fncIni_date()
                    '�R���{�{�b�N�X�̏�����
                    fncCombo_Create_AUTOKBN()
                    fncCombo_Create_AUTOZEROFLG()

                    '�t�@�C���̍폜
                    If txtFileName1.Text.Trim.Length > 0 Then
                        fncFileDaleteClick("1")
                        txtFileName1.Text = ""
                    End If
                    If txtFileName2.Text.Trim.Length > 0 Then
                        fncFileDaleteClick("2")
                        txtFileName2.Text = ""
                    End If

                Else
                    Call fncIni_date()
                End If
                strMsg.Append("alert('����ɏI�����܂���');")

                '//------------------------------

            Case "0"
                strRecMsg = "���̃��[�U�[�ɂ���ăf�[�^���X�V����Ă��܂��B�ēx�������Ă�������"
                strMsg.Append("alert('" & strRecMsg & "');")

                '//------------------------------
                '<TODO>�t�H�[�J�X���Z�b�g����i�C�����ł̃G���[�B�����{�^���ɃZ�b�g�j
                strMsg.Append("Form1.btnSelect.focus();")
                strRec = strRecMsg
            Case "3"
                strRecMsg = "�r�����䏈���ŃG���[���������܂����B�ēx���s���Ă�������"
                strMsg.Append("alert('" & strRecMsg & "');")

                '<TODO>�t�H�[�J�X���Z�b�g����i�o�^�E�C���E�폜���ł̃G���[�B�I���{�^���ɃZ�b�g�j
                strMsg.Append("Form1.btnExit.focus();")
                strRec = strRecMsg
            Case "4"
                strRecMsg = "JA�O���[�v�쐬�}�X�^�Ŏg�p����Ă���f�[�^������܂��B\n�f�[�^���m�F���Ă�������"
                strMsg.Append("alert('" & strRecMsg & "');")

                '<TODO>�t�H�[�J�X���Z�b�g����i�o�^�E�C���E�폜���ł̃G���[�B�����{�^���ɃZ�b�g�j
                strMsg.Append("Form1.btnSelect.focus();")
                strRec = strRecMsg
            Case "5"
                strRecMsg = "�v���_�E���}�X�^�ɓo�^������܂���"
                strMsg.Append("alert('" & strRecMsg & "');")

                '<TODO>�t�H�[�J�X���Z�b�g����i�o�^�E�C�����ł̃G���[�B�I���{�^���ɃZ�b�g�j
                strMsg.Append("Form1.btnExit.focus();")

                strRec = strRecMsg
            Case "6"
                strRecMsg = "�O���[�v�R�[�h���s���ł��B\n�擪�ɏ���̃A���t�@�x�b�g2��������͂��Ă�������"
                strMsg.Append("alert('" & strRecMsg & "');")
                '<TODO>�t�H�[�J�X���Z�b�g����i�o�^�E�C�����ł̃G���[�B�����{�^���ɃZ�b�g�j
                strMsg.Append("Form1.btnSelect.focus();")

                strRec = strRecMsg

            Case "7" '2016/01/12 T.Ono add 2015���P�J��
                strRecMsg = "�O���[�v�R�[�h�����d�����Ă��܂�"
                strMsg.Append("alert('" & strRecMsg & "');")
                '<TODO>�t�H�[�J�X���Z�b�g����i�o�^�E�C�����ł̃G���[�B�����{�^���ɃZ�b�g�j
                strMsg.Append("Form1.txtGROUPNM.focus();")

                strRec = strRecMsg

            Case Else
                Dim ErrMsgC As New CErrMsg

                strMsg.Append("alert('�V�X�e���G���[�F" & ErrMsgC.mGetArtMsg(strRec) & "');")

                If pstrKBN = "1" Then
                    '//----------------------------------
                    '<TODO>�t�H�[�J�X���Z�b�g����i�o�^�����F���O�o�͂̃G���[�̈׃L�[�ɃZ�b�g�j
                ElseIf pstrKBN = "2" Then
                    '//----------------------------------
                    '<TODO>�t�H�[�J�X���Z�b�g����i�C�������F���O�o�͂̃G���[�̈׃L�[�ȍ~�ɃZ�b�g�j
                    strMsg.Append("Form1.txtTANNM_1.focus();")
                Else
                    '//----------------------------------
                    '<TODO>�t�H�[�J�X���Z�b�g����i���̑��@�F���O�o�͂̃G���[�̈׃L�[�ȍ~�ɃZ�b�g�j
                    strMsg.Append("Form1.txtTANNM_1.focus();")
                End If
        End Select

        '�G���[�̏ꍇ�́A�R���{�{�b�N�X�̏������ƁA���͒l�̃Z�b�g���s��
        If strRecTemp <> "OK" Then
            ' �R���{�{�b�N�X�Z�b�g
            fncCombo_Create_AUTOKBN()
            fncCombo_Create_AUTOZEROFLG()

            ' ���͓��e�̃Z�b�g
            For j As Integer = 1 To 30
                objAUTO_KBN = CType(FindControl("cboAUTO_KBN_" & CStr(j)), JPG.Common.Controls.CTLCombo)
                objAUTO_ZERO_FLG = CType(FindControl("cboAUTO_ZERO_FLG_" & CStr(j)), JPG.Common.Controls.CTLCombo)
                objSD_PRT_FLG = CType(FindControl("cboSD_PRT_FLG_" & CStr(j)), JPG.Common.Controls.CTLCombo)      '2020/11/01 T.Ono add 2020�Ď����P
                fncCombo_Select(objAUTO_KBN, sAUTO_KBN(j))
                fncCombo_Select(objAUTO_ZERO_FLG, sAUTO_ZERO_FLG(j))
                fncCombo_Select(objSD_PRT_FLG, sSD_PRT_FLG(j))      '2020/11/01 T.Ono add 2020�Ď����P
            Next
        End If

        '-------------------------------------------------
        '//�`�o���O��������
        Dim LogC As New CLog
        Dim strRecLog As String

        strRecLog = LogC.mAPLog(Me.Session.SessionID, AuthC.pUSERNAME, AuthC.pIPADDRESS, hdnMyAspx.Value, pstrKBN, strRec, Request.Form)

        If strRecLog <> "OK" Then
            Dim errmsgc As New CErrMsg
            strMsg.Append("alert('�V�X�e���G���[�F" & errmsgc.mGetArtMsg(strRecLog) & "');")
        End If

        Return strRec
    End Function

    '******************************************************************************
    '* ���̓L�[�ɂ��f�[�^�̌������s���܂��B
    '* pstrkbn�@1:�N���C�A���g�o�^������
    '*        �@2:�O���[�v�o�^������
    '******************************************************************************
    Private Function fncDataSelect(ByVal pstrkbn As String) As DataSet

        '//------------------------------------------
        '//<TODO>Select���̍쐬
        Dim SQLC As New MSTAGJAG00CCSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet

        strSQL.Append("SELECT ")
        strSQL.Append("	A.KBN, ")
        strSQL.Append("	A.GROUPCD, ")
        strSQL.Append("	A.GROUPNM, ")
        strSQL.Append("	LPAD(A.TANCD, 2, '0') AS TANCD, ")
        strSQL.Append("	A.TANNM, ")
        strSQL.Append("	A.RENTEL1, ")
        strSQL.Append("	A.RENTEL2, ")
        strSQL.Append("	A.RENTEL3, ")
        strSQL.Append("	A.FAXNO, ")
        strSQL.Append("	A.BIKO, ")
        strSQL.Append("	A.SPOT_MAIL, ")
        strSQL.Append("	A.MAIL_PASS, ")
        strSQL.Append("	A.AUTO_FAXNM, ")
        strSQL.Append("	A.AUTO_MAIL, ")
        strSQL.Append("	A.AUTO_MAIL_PASS, ")
        strSQL.Append("	A.AUTO_FAXNO, ")
        strSQL.Append("	A.AUTO_KBN, ")
        strSQL.Append("	A.AUTO_ZERO_FLG, ")
        strSQL.Append("	A.SD_PRT_FLG, ")            '2020/11/01 T.Ono 2020�Ď����P
        strSQL.Append("	A.GUIDELINE, ")
        strSQL.Append("	A.GUIDELINE2, ")           '2019/11/01 w.ganeko 2019�Ď����P
        strSQL.Append("	A.GUIDELINE3, ")           '2019/11/01 w.ganeko 2019�Ď����P
        strSQL.Append("	A.GUIDELINENM1, ")          '2020/11/01 T.Ono 2020�Ď����P
        strSQL.Append("	A.GUIDELINENM2, ")          '2020/11/01 T.Ono 2020�Ď����P
        strSQL.Append("	A.GUIDELINENM3, ")          '2020/11/01 T.Ono 2020�Ď����P
        strSQL.Append("	A.FAXKURAKBN, ")
        strSQL.Append("	A.FAXKBN, ")
        strSQL.Append("	A.INS_DATE, ")
        strSQL.Append("	A.INS_USER, ")
        strSQL.Append("	A.UPD_DATE, ")
        strSQL.Append("	A.UPD_USER ")
        strSQL.Append("FROM M11_JAHOKOKU A ")
        strSQL.Append("WHERE A.GROUPCD = :CODE ")
        strSQL.Append("AND A.KBN = :KBN ")
        strSQL.Append("ORDER BY TO_NUMBER(A.TANCD) ")

        '�p�����[�^�ݒ�
        SqlParamC.fncSetParam("KBN", True, CStr(pstrkbn)) '1:�N���C�A���g�o�^�������@2:�O���[�v�o�^������

        If hdnKEY.Value.Trim.Length > 0 Then
            SqlParamC.fncSetParam("CODE", True, hdnKEY.Value)
        Else
            SqlParamC.fncSetParam("CODE", True, "")
        End If

        dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

        Return dbData
    End Function

    '******************************************************************************
    '* �O���[�v�R�[�h�V�K�o�^���́ADB�`�F�b�N�B
    '* ���ɓo�^������ꍇ�̓G���[�Ƃ���
    '******************************************************************************
    Private Function fncDataCheck(ByVal pstrgroupnew As String) As Boolean

        '//------------------------------------------
        '//<TODO>Select���̍쐬
        Dim SQLC As New MSTAGJAG00CCSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet
        Dim res As Boolean = False

        strSQL.Append("SELECT ")
        strSQL.Append("	'X' ")
        strSQL.Append("FROM M11_JAHOKOKU A ")
        strSQL.Append("WHERE A.GROUPCD = :GROUPCD ")
        strSQL.Append("AND A.KBN = '2' ")
        strSQL.Append("AND LPAD(A.TANCD,2,'0') = '01' ")

        '�p�����[�^�ݒ�
        If hdnKEY.Value.Trim.Length > 0 Then
            SqlParamC.fncSetParam("GROUPCD", True, pstrgroupnew)
        Else
            SqlParamC.fncSetParam("GROUPCD", True, "")
        End If

        dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

        If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
            res = True
        Else
            res = False
        End If

        Return res
    End Function
    '******************************************************************************
    '* �t�@�C���A�b�v���[�h����
    '******************************************************************************
    Private Sub btnFileUpload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFileUpload.Click
        Dim uploadFile As HttpPostedFile
        Dim sSaveFileName As String
        Dim sSaveFileNameR As String
        Dim sSaveFileNameR2 As String '�ꕔ�����ϊ���
        Dim sSaveFileExt As String
        Dim sSavePath As String
        Dim sSaveFileKey As String '�t�@�C���ۑ����ɓ��ɕt����L�[�i�O���[�v�R�[�h�j
        Dim skipF As Boolean = False
        Dim fs As String()

        Try
            uploadFile = Request.Files("FileUpload1")
            If (uploadFile.FileName <> "") Then

                '�t�@�C����������
                sSaveFileNameR = System.IO.Path.GetFileName(uploadFile.FileName)
                sSaveFileExt = System.IO.Path.GetExtension(uploadFile.FileName) '�g���q�擾���A�������֕ϊ�
                sSaveFileExt = sSaveFileExt.ToLower

                If txtGROUPNEW.Text.Trim <> "" Then
                    sSaveFileKey = txtGROUPNEW.Text.Trim & "_" '�O���[�v�R�[�h�i�V�K�o�^�p�j
                Else
                    sSaveFileKey = hdnGROUPCD.Value.Trim & "_" '�O���[�v�R�[�h
                End If
                sSaveFileNameR2 = sSaveFileNameR
                sSaveFileNameR2 = sSaveFileNameR2.Replace("_", "�Q") '�A���_�[�o�[�͋�؂蕶���Ƃ��Ďg�p����̂Œu������
                sSaveFileNameR2 = sSaveFileNameR2.Replace(" ", "") '���p�X�y�[�X�͏���
                sSaveFileName = sSaveFileKey & sSaveFileNameR2
                sSavePath = ConfigurationSettings.AppSettings("JA_TAN_MST_PATH")

                '�g���q�`�F�b�N
                'If sSaveFileExt = "lzh" Then           '2012/04/20 NEC ou Del
                If sSaveFileExt = ".lzh" Then           '2012/04/20 NEC ou Add
                    strMsg.Append("alert('�g���q��lzh�͓o�^�ł��܂���');")
                    strMsg.Append("Form1.btnSelect.focus();")
                    skipF = True
                    'ElseIf sSaveFileExt = "exe" Then   '2012/04/20 NEC ou Del
                ElseIf sSaveFileExt = ".exe" Then       '2012/04/20 NEC ou Add
                    strMsg.Append("alert('�g���q��exe�͓o�^�ł��܂���');")
                    strMsg.Append("Form1.btnSelect.focus();")
                    skipF = True
                End If

                '�d���t�@�C���`�F�b�N
                fs = System.IO.Directory.GetFiles(sSavePath, sSaveFileName)   'folder�ɂ���t�@�C�����擾����
                If fs.Length >= 1 Then '���Ƀt�@�C�����o�^����Ă���H
                    strMsg.Append("alert('���Ƀt�@�C�����o�^����Ă��܂��B[" & sSaveFileNameR & "]' );")
                    strMsg.Append("Form1.btnSelect.focus();")
                    skipF = True
                End If

                '�t�@�C������MAX�`�F�b�N
                fs = System.IO.Directory.GetFiles(sSavePath, sSaveFileKey & "*")   'folder�ɂ���t�@�C�����擾����
                If fs.Length >= 2 Then '���ɂQ�ȏ�t�@�C�����o�^����Ă���H
                    strMsg.Append("alert('����ȏ�o�^�ł��܂���B');")
                    strMsg.Append("Form1.btnSelect.focus();")
                    skipF = True
                End If

                If skipF = False Then
                    '�o�^
                    uploadFile.SaveAs(sSavePath + sSaveFileName) '�t�@�C���ۑ��I

                    fncSearchAndSetFileName12() '�t�@�C���������ĕ\��
                End If
            End If
        Catch ex As Exception
            mlog("�V�X�e���G���[(btnFileUpload_Click)�F" & ex.ToString)
            strMsg.Append("alert('�t�@�C���̓o�^�Ɏ��s���܂����B\n������x�������Ȃ����Ă��������B');")
            strMsg.Append("Form1.btnSelect.focus();")
        Finally
        End Try
    End Sub

    '******************************************************************************
    '* �t�@�C���폜���� �C�x���g
    '******************************************************************************
    Private Sub btnFileDelete1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFileDelete1.Click

        If fncFileDaleteClick("1") Then '�����H
            fncSearchAndSetFileName12() '�t�@�C���������ĕ\��
        End If

    End Sub
    Private Sub btnFileDelete2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFileDelete2.Click

        If fncFileDaleteClick("2") Then '�����H
            fncSearchAndSetFileName12() '�t�@�C���������ĕ\��
        End If

    End Sub

    '******************************************************************************
    '* �t�@�C���폜����
    '******************************************************************************
    Private Function fncFileDaleteClick(ByVal strBtn As String) As Boolean

        Dim sSaveFileName As String   '���ۂ̌��t�@�C�����i�g���q����j  jm1000001_�e�X�g�t�@�C��.xls
        Dim sSaveFileNameR As String  '�_�E�����[�h��̃t�@�C����        �e�X�g�t�@�C��.xls
        Dim sSavePath As String       '���t�@�C���ۑ��t�H���_
        Dim skipF As Boolean = False
        Dim res As Boolean = False

        Try
            sSavePath = ConfigurationSettings.AppSettings("JA_TAN_MST_PATH")

            If strBtn = "1" Then
                sSaveFileNameR = txtFileName1.Text.Trim '���t�@�C�����P��
            Else
                sSaveFileNameR = txtFileName2.Text.Trim '���t�@�C�����Q��
            End If
            sSaveFileName = hdnFileKey.Text & sSaveFileNameR '�t�@�C�������A�O���[�v�R�[�h�{�t�@�C�����ɕϊ�

            '�t�@�C�����݃`�F�b�N
            If sSaveFileNameR.Length <= 0 Then '�t�@�C�����݂��Ȃ��H     
                strMsg.Append("alert('�t�@�C�����w�肵�ĉ������B');")
                skipF = True
            End If

            If skipF = False Then
                System.IO.File.Delete(sSavePath & sSaveFileName) '�폜���s�I
                res = True
            End If
        Catch ex As Exception
            mlog("�V�X�e���G���[(fncFileDaleteClick)�F" & ex.ToString)
            strMsg.Append("alert('�t�@�C���̍폜�Ɏ��s���܂����B\n������x�������Ȃ����Ă��������B');")
        Finally
            strMsg.Append("Form1.btnSelect.focus();")
        End Try
        Return res

    End Function

    '******************************************************************************
    '* �t�@�C���_�E�����[�h����
    '******************************************************************************
    Private Sub btnFileDownload1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFileDownload1.Click

        Dim sSaveFileName As String   '���ۂ̌��t�@�C�����i�g���q����j  jm1000001_�e�X�g�t�@�C��.xls
        Dim sSaveFileNameR As String  '�_�E�����[�h��̃t�@�C����        �e�X�g�t�@�C��.xls
        Dim sSavePath As String       '���t�@�C���ۑ��t�H���_
        Try
            sSavePath = ConfigurationSettings.AppSettings("JA_TAN_MST_PATH")
            sSaveFileNameR = txtFileName1.Text.Trim '���t�@�C������
            sSaveFileName = hdnFileKey.Text & sSaveFileNameR '�t�@�C�������A�O���[�v�R�[�h�{�t�@�C�����ɕϊ�

            fncFileDownload(sSavePath, sSaveFileName, sSaveFileNameR)
        Catch ex As Exception
            mlog("�V�X�e���G���[(btnFileDownload1_Click)�F" & ex.ToString)
            strMsg.Append("alert('�t�@�C���̃_�E�����[�h�Ɏ��s���܂����B\n������x�������Ȃ����Ă��������B');")
            strMsg.Append("Form1.btnSelect.focus();")
        Finally
        End Try
    End Sub
    Private Sub btnFileDownload2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFileDownload2.Click

        Dim sSaveFileName As String   '���ۂ̌��t�@�C�����i�g���q����j  jm1000001_�e�X�g�t�@�C��.xls
        Dim sSaveFileNameR As String  '�_�E�����[�h��̃t�@�C����        �e�X�g�t�@�C��.xls
        Dim sSavePath As String       '���t�@�C���ۑ��t�H���_           
        Try
            sSavePath = ConfigurationSettings.AppSettings("JA_TAN_MST_PATH")
            sSaveFileNameR = txtFileName2.Text.Trim '���t�@�C������
            sSaveFileName = hdnFileKey.Text & sSaveFileNameR '�t�@�C�������A�O���[�v�R�[�h�{�t�@�C�����ɕϊ�

            fncFileDownload(sSavePath, sSaveFileName, sSaveFileNameR)
        Catch ex As Exception
            mlog("�V�X�e���G���[(btnFileDownload2_Click)�F" & ex.ToString)
            strMsg.Append("alert('�t�@�C���̃_�E�����[�h�Ɏ��s���܂����B\n������x�������Ȃ����Ă��������B');")
            strMsg.Append("Form1.btnSelect.focus();")
        Finally
        End Try
    End Sub

    Private Function fncFileDownload(ByVal sSavePath As String, ByVal sSaveFileName As String, ByVal sSaveFileNameR As String) As String

        Dim dt As Byte()
        Dim sSaveFileNameS As String  '���ۂ̌��t�@�C�����i�g���q�Ȃ��j  jm1000001_�e�X�g�t�@�C��
        Dim fpath As String           '���t�@�C���܂ł̃t���p�X          D:\TEMP\SAVE\jm1000001_�e�X�g�t�@�C��.xls

        Dim tmp As String

        Try

            If sSaveFileName.IndexOf(".") > 0 Then '�g���q����H
                sSaveFileNameS = sSaveFileName.Substring(0, sSaveFileName.LastIndexOf("."))
            Else
                sSaveFileNameS = sSaveFileName
            End If
            Dim fs As String() = System.IO.Directory.GetFiles(sSavePath, sSaveFileName)  'folder�ɂ���t�@�C�����擾����
            If fs.Length > 0 Then
                fpath = fs(0)
            End If

            If System.IO.File.Exists(fpath) Then
                Response.Clear()

                '2018/02/13 T.Ono mod ���k�����t�@�C�����_�E�����[�h����B�@-----START
                'Dim FileToStrC As New CFileStr                  '�t�@�C����Base64�ɃG���R�[�h����N���X
                'Dim compressC As New CCompress                  '���k�N���X
                ''���k��t�@�C���̂���t�H���_
                'compressC.p_Dir = sSavePath
                ''���{��t�@�C�����̎w��
                'compressC.p_NihongoFileName = sSaveFileNameR
                ''���k���t�@�C����
                'compressC.p_FileName = sSavePath & sSaveFileName
                ''���k��t�@�C����
                'compressC.p_madeFilename = sSavePath & sSaveFileNameS & ".lzh"
                ''���k���s
                'compressC.mCompress()
                'putlog("MSTAGJAG00 - " & compressC.p_madeFilename)
                'If System.IO.File.Exists(compressC.p_madeFilename) Then '���k�����t�@�C�������݂���H

                '    '���k�����t�@�C����Base64�G���R�[�h���Ė߂�
                '    Dim strRec As String = FileToStrC.mFileToStr(compressC.p_madeFilename.Replace(".lzh", ".exe"))

                '    dt = Convert.FromBase64String(strRec) 'Web�T�[�r�X�̖߂�l�iBASE64�̃e�L�X�g�j���o�C�g�f�[�^�ɕϊ�����
                '    HttpHeaderC.mDownLoad(Response, sSaveFileNameS & ".exe") '�t�@�C�����́AHttpUtility.UrlEncode���\�b�h���g�p����SJIS�ɃG���R�[�h����K�v������
                '    Response.BinaryWrite(dt) '�t�@�C�����M
                '    Response.Flush() '���X�|���X��S�ēf���o���I

                '    '���k�t�@�C���͕s�v�Ȃ̂ō폜�I
                '    System.IO.File.Delete(sSavePath & sSaveFileNameS & ".lzh")
                '    System.IO.File.Delete(sSavePath & sSaveFileNameS & ".exe")

                'Else
                '    tmp = "alert('"
                '    tmp += "�Ώۃf�[�^�����݂��܂���B\n\n"
                '    tmp += "[" & compressC.p_Dir.Replace("\", "\\") & "]\n"
                '    tmp += "[" & compressC.p_NihongoFileName.Replace("\", "\\") & "]\n"
                '    tmp += "[" & compressC.p_FileName.Replace("\", "\\") & "]\n"
                '    tmp += "[" & compressC.p_madeFilename.Replace("\", "\\") & "]"
                '    tmp += "');"
                '    strMsg.Append(tmp)
                '    strMsg.Append("Form1.btnSelect.focus();")
                'End If
                HttpHeaderC.mDownLoadXLS(Response, sSaveFileNameR)
                Response.WriteFile(sSavePath & sSaveFileName)
                '2018/02/13 T.Ono mod ���k�����t�@�C�����_�E�����[�h����B�@-----END
            Else
                strMsg.Append("alert('" & "�Ώۃf�[�^�����݂��܂���" & "');")
                strMsg.Append("Form1.btnSelect.focus();")
            End If

        Catch ex As Exception
            Throw ex
        Finally
            'If bw Is Nothing = False Then bw.Close()
            'If sw Is Nothing = False Then sw.Close()
        End Try
    End Function
    '-------------------------------------------------
    ' �t�@�C�����ĕ\���i�t�@�C�������擾���ăZ�b�g�j
    '-------------------------------------------------
    Private Sub fncSearchAndSetFileName12()
        Dim folder As String
        Dim buf As String
        Dim searchPattern As String

        '������
        hdnFileKey.Text = ""
        txtFileName1.Text = ""
        txtFileName2.Text = ""

        folder = ConfigurationSettings.AppSettings("JA_TAN_MST_PATH")

        If txtGROUPNEW.Text.Trim <> "" Then
            searchPattern = txtGROUPNEW.Text.Trim & "_"
        Else
            searchPattern = hdnGROUPCD.Value.Trim & "_"
        End If
        Dim fs As String() = System.IO.Directory.GetFiles(folder, searchPattern & "*") 'folder�ɂ���t�@�C�����擾����
        If fs.Length > 0 Then
            buf = fs(0).Substring(fs(0).LastIndexOf("\") + 1)
            txtFileName1.Text = buf.Substring(searchPattern.Length)

            hdnFileKey.Text = searchPattern '�L�[��ێ�
        End If
        If fs.Length > 1 Then
            buf = fs(1).Substring(fs(1).LastIndexOf("\") + 1)
            txtFileName2.Text = buf.Substring(searchPattern.Length)
        End If

        Call fncIni_stateaf()
    End Sub

    Public Sub putlog(ByVal strMsg As String)
        Dim textFile As System.IO.StreamWriter
        Dim folder As String = ConfigurationSettings.AppSettings("JA_TAN_MST_PATH")
        textFile = New System.IO.StreamWriter(folder & "COASYUKE00.log", True, System.Text.Encoding.Default)
        textFile.WriteLine(strMsg)
        textFile.Close()
    End Sub

    Private Sub checkedRadio(ByVal rdo As HtmlInputRadioButton)

        If rdo Is rdoFAXJA1 Then
            rdoFAXJA1.Checked = True
            rdoFAXJA2.Checked = False
        ElseIf rdo Is rdoFAXJA2 Then
            rdoFAXJA1.Checked = False
            rdoFAXJA2.Checked = True
        End If

        If rdo Is rdoFAXKURA1 Then
            rdoFAXKURA1.Checked = True
            rdoFAXKURA2.Checked = False
        ElseIf rdo Is rdoFAXKURA2 Then
            rdoFAXKURA1.Checked = False
            rdoFAXKURA2.Checked = True
        End If
    End Sub

    '**************************************************
    '* �������M�敪�R���{�{�b�N�X�Z�b�g
    '* 2013/07/04 T.Ono add
    '**************************************************
    Private Sub fncCombo_Create_AUTOKBN()
        For i As Integer = 1 To 30
            Dim objAUTO_KBN As JPG.Common.Controls.CTLCombo
            objAUTO_KBN = CType(FindControl("cboAUTO_KBN_" & CStr(i)), JPG.Common.Controls.CTLCombo)
            objAUTO_KBN.Items.Clear()
            objAUTO_KBN.Items.Add(New ListItem("", ""))
            objAUTO_KBN.Items.Add(New ListItem("0:���M�Ȃ�", "0"))
            objAUTO_KBN.Items.Add(New ListItem("1:FAX���M", "1"))
            objAUTO_KBN.Items.Add(New ListItem("2:���[�����M", "2"))
            objAUTO_KBN.Items.Add(New ListItem("3:FAX�����[�����M", "3"))
        Next
    End Sub

    '**************************************************
    '* �[�������M�t���O�R���{�{�b�N�X�Z�b�g
    '* 2013/07/04 T.Ono add
    '**************************************************
    Private Sub fncCombo_Create_AUTOZEROFLG()
        For i As Integer = 1 To 30
            Dim objAUTO_ZERO_FLG As JPG.Common.Controls.CTLCombo
            objAUTO_ZERO_FLG = CType(FindControl("cboAUTO_ZERO_FLG_" & CStr(i)), JPG.Common.Controls.CTLCombo)
            objAUTO_ZERO_FLG.Items.Clear()
            objAUTO_ZERO_FLG.Items.Add(New ListItem("", ""))
            objAUTO_ZERO_FLG.Items.Add(New ListItem("0:���M�Ȃ�", "0"))
            objAUTO_ZERO_FLG.Items.Add(New ListItem("1:���M����", "1"))
        Next
    End Sub

    '**************************************************
    '* �o���˗����e�E���l�t���O�R���{�{�b�N�X�Z�b�g
    '* 2020/11/01 T.Ono add 2020�Ď����P
    '**************************************************
    Private Sub fncCombo_Create_SDPRTFLG()
        For i As Integer = 1 To 30
            Dim objSD_PRT_FLG As JPG.Common.Controls.CTLCombo
            objSD_PRT_FLG = CType(FindControl("cboSD_PRT_FLG_" & CStr(i)), JPG.Common.Controls.CTLCombo)
            objSD_PRT_FLG.Items.Clear()
            objSD_PRT_FLG.Items.Add(New ListItem("", ""))
            objSD_PRT_FLG.Items.Add(New ListItem("0:�\���Ȃ�", "0"))
            objSD_PRT_FLG.Items.Add(New ListItem("1:�\������", "1"))
        Next
    End Sub

    '**************************************************
    '* �R���{�{�b�N�X�̑I��
    '* 2013/07/04 T.Ono add
    '**************************************************
    Private Sub fncCombo_Select(ByVal obj As JPG.Common.Controls.CTLCombo, ByVal str As String)
        Dim list As New ListItem
        If str <> "" Then
            list = obj.Items.FindByValue(str)
            obj.SelectedIndex = obj.Items.IndexOf(list)
        End If
    End Sub

    '**************************************************
    '* �R���{�{�b�N�X�̓��͒l�擾
    '* 2013/07/04 T.Ono add
    '* 2020/11/01 T.Ono mod 2020�Ď����P �����ǉ�sSD_PRT_FLG
    '**************************************************
    Private Sub fncCombo_Get(ByRef sAUTO_KBN() As String, ByRef sAUTO_ZERO_FLG() As String, ByRef sSD_PRT_FLG() As String)
        'Private Sub fncCombo_Get(ByRef sAUTO_KBN() As String, ByRef sAUTO_ZERO_FLG() As String)
        Dim objAUTO_KBN As JPG.Common.Controls.CTLCombo
        Dim objAUTO_ZERO_FLG As JPG.Common.Controls.CTLCombo
        Dim objSD_PRT_FLG As JPG.Common.Controls.CTLCombo   '2020/11/01 T.Ono add 2020�Ď����P

        For i As Integer = 1 To 30
            objAUTO_KBN = CType(FindControl("cboAUTO_KBN_" & CStr(i)), JPG.Common.Controls.CTLCombo)
            objAUTO_ZERO_FLG = CType(FindControl("cboAUTO_ZERO_FLG_" & CStr(i)), JPG.Common.Controls.CTLCombo)
            objSD_PRT_FLG = CType(FindControl("cboSD_PRT_FLG_" & CStr(i)), JPG.Common.Controls.CTLCombo)   '2020/11/01 T.Ono add 2020�Ď����P
            sAUTO_KBN(i) = Request.Form(objAUTO_KBN.ID)
            sAUTO_ZERO_FLG(i) = Request.Form(objAUTO_ZERO_FLG.ID)
            sSD_PRT_FLG(i) = Request.Form(objSD_PRT_FLG.ID)   '2020/11/01 T.Ono add 2020�Ď����P
        Next
    End Sub


    '**********************************************************
    ' 2012/06/28 ADD W.GANEKO
    '���O�f���o��
    '�߂�l�F�������񂾃t�@�C���ւ̃t���p�X
    '**********************************************************
    Public Sub mlog(ByVal pstrString As String)
        Dim strFilnm As String = "log" & System.DateTime.Today.ToString("yyyyMMdd")
        Dim strLogPath As String = ConfigurationSettings.AppSettings("LOG_OUT_PATH")
        Dim strPath As String = strLogPath & strFilnm & ".txt"
        Dim strLogFlg As String = ConfigurationSettings.AppSettings("LOG_OUT")
        Dim LogC As New CLog
        Dim strRecLog As String
        Dim strRec As String

        Try
            If strLogFlg = "1" Then
                '�������݃t�@�C���ւ̃X�g���[��
                Dim outFile As New StreamWriter(strPath, True, System.Text.Encoding.Default)

                '�����̕�������X�g���[���ɏ�������
                outFile.Write(System.DateTime.Now & "|" & AuthC.pUSERNAME & "|" & AuthC.pIPADDRESS & "|" & pstrString + vbCrLf)

                '�������t���b�V���i�t�@�C���������݁j
                outFile.Flush()

                '�t�@�C���N���[�Y
                outFile.Close()
            End If
        Catch ex As Exception
            strRec = "ERROR:" & ex.ToString
            strRecLog = LogC.mAPLog(Me.Session.SessionID, AuthC.pUSERNAME, AuthC.pIPADDRESS, Request.Form("hdnMyAspx"), "1", strRec, Request.Form)
        End Try
    End Sub
End Class
