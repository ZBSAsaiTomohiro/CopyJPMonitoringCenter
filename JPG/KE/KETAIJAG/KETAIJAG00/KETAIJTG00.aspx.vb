'***********************************************
'�A������
'***********************************************
' �ύX����
' 2010/04/28 T.Watabe �A������R�O�ɑ���
' 2010/04/28 T.Watabe �N���C�A���g�A�i�`���Ƀt�@�C�����Q�܂ŎQ�Ƃł���悤�ɕύX
' 2012/03/23 W.GANEKO SPOT���[�����M�@�\�ǉ�
Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common

Imports System.Text
Imports System.IO
Imports JPG.Common.log

Partial Class KETAIJTG00
    Inherits System.Web.UI.Page
    '--- ��2005/04/25 ADD Falcon�� ---
    '--- ��2005/04/25 ADD Falcon�� ---

    ' 2008/10/31 T.Watabe add

    ' 2010/04/15 T.Watabe add



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

        '2012/04/04 NEC ou Add Str
        '.NET�̎d�l�ύX�ɂ��AReadOnly������ASPX�ł���ƁA�T�[�o���Œl�̎Q�Ƃ��ł��Ȃ��Ȃ邽�߁AVB����Attribute�ł���
        If MyBase.IsPostBack = False Then
            '2016/05/10 w.ganeko mod start Load���ȊO���g�p���邽�ߊ֐���
            Call SetInitKETAIJAG00()
            'txtACBNM.Attributes.Add("ReadOnly", "true")
            'txtACBKN.Attributes.Add("ReadOnly", "true")
            'txtTANNM5.Attributes.Add("ReadOnly", "true")
            'txtBIKO5.Attributes.Add("ReadOnly", "true")
            'txtRENTEL1_5.Attributes.Add("ReadOnly", "true")
            'txtRENTEL2_5.Attributes.Add("ReadOnly", "true")
            'txtRENTEL3_5.Attributes.Add("ReadOnly", "true") '2013/05/27 T.Ono add
            'txtFAX5.Attributes.Add("ReadOnly", "true")
            'txtTANNM6.Attributes.Add("ReadOnly", "true")
            'txtBIKO6.Attributes.Add("ReadOnly", "true")
            'txtRENTEL1_6.Attributes.Add("ReadOnly", "true")
            'txtRENTEL2_6.Attributes.Add("ReadOnly", "true")
            'txtRENTEL3_6.Attributes.Add("ReadOnly", "true") '2013/05/27 T.Ono add
            'txtFAX6.Attributes.Add("ReadOnly", "true")
            'txtTANNM7.Attributes.Add("ReadOnly", "true")
            'txtBIKO7.Attributes.Add("ReadOnly", "true")
            'txtRENTEL1_7.Attributes.Add("ReadOnly", "true")
            'txtRENTEL2_7.Attributes.Add("ReadOnly", "true")
            'txtRENTEL3_7.Attributes.Add("ReadOnly", "true") '2013/05/27 T.Ono add
            'txtFAX7.Attributes.Add("ReadOnly", "true")
            'txtTANNM8.Attributes.Add("ReadOnly", "true")
            'txtBIKO8.Attributes.Add("ReadOnly", "true")
            'txtRENTEL1_8.Attributes.Add("ReadOnly", "true")
            'txtRENTEL2_8.Attributes.Add("ReadOnly", "true")
            'txtRENTEL3_8.Attributes.Add("ReadOnly", "true") '2013/05/27 T.Ono add
            'txtFAX8.Attributes.Add("ReadOnly", "true")
            'txtTANNM9.Attributes.Add("ReadOnly", "true")
            'txtBIKO9.Attributes.Add("ReadOnly", "true")
            'txtRENTEL1_9.Attributes.Add("ReadOnly", "true")
            'txtRENTEL2_9.Attributes.Add("ReadOnly", "true")
            'txtRENTEL3_9.Attributes.Add("ReadOnly", "true") '2013/05/27 T.Ono add
            'txtFAX9.Attributes.Add("ReadOnly", "true")
            'txtTANNM10.Attributes.Add("ReadOnly", "true")
            'txtBIKO10.Attributes.Add("ReadOnly", "true")
            'txtRENTEL1_10.Attributes.Add("ReadOnly", "true")
            'txtRENTEL2_10.Attributes.Add("ReadOnly", "true")
            'txtRENTEL3_10.Attributes.Add("ReadOnly", "true")    '2013/05/27 T.Ono add
            'txtFAX10.Attributes.Add("ReadOnly", "true")
            'txtTANNM11.Attributes.Add("ReadOnly", "true")
            'txtBIKO11.Attributes.Add("ReadOnly", "true")
            'txtRENTEL1_11.Attributes.Add("ReadOnly", "true")
            'txtRENTEL2_11.Attributes.Add("ReadOnly", "true")
            'txtRENTEL3_11.Attributes.Add("ReadOnly", "true")    '2013/05/27 T.Ono add
            'txtFAX11.Attributes.Add("ReadOnly", "true")
            'txtTANNM12.Attributes.Add("ReadOnly", "true")
            'txtBIKO12.Attributes.Add("ReadOnly", "true")
            'txtRENTEL1_12.Attributes.Add("ReadOnly", "true")
            'txtRENTEL2_12.Attributes.Add("ReadOnly", "true")
            'txtRENTEL3_12.Attributes.Add("ReadOnly", "true")    '2013/05/27 T.Ono add
            'txtFAX12.Attributes.Add("ReadOnly", "true")
            'txtTANNM13.Attributes.Add("ReadOnly", "true")
            'txtBIKO13.Attributes.Add("ReadOnly", "true")
            'txtRENTEL1_13.Attributes.Add("ReadOnly", "true")
            'txtRENTEL2_13.Attributes.Add("ReadOnly", "true")
            'txtRENTEL3_13.Attributes.Add("ReadOnly", "true")    '2013/05/27 T.Ono add
            'txtFAX13.Attributes.Add("ReadOnly", "true")
            'txtTANNM14.Attributes.Add("ReadOnly", "true")
            'txtBIKO14.Attributes.Add("ReadOnly", "true")
            'txtRENTEL1_14.Attributes.Add("ReadOnly", "true")
            'txtRENTEL2_14.Attributes.Add("ReadOnly", "true")
            'txtRENTEL3_14.Attributes.Add("ReadOnly", "true")    '2013/05/27 T.Ono add
            'txtFAX14.Attributes.Add("ReadOnly", "true")
            'txtTANNM15.Attributes.Add("ReadOnly", "true")
            'txtBIKO15.Attributes.Add("ReadOnly", "true")
            'txtRENTEL1_15.Attributes.Add("ReadOnly", "true")
            'txtRENTEL2_15.Attributes.Add("ReadOnly", "true")
            'txtRENTEL3_15.Attributes.Add("ReadOnly", "true")    '2013/05/27 T.Ono add
            'txtFAX15.Attributes.Add("ReadOnly", "true")
            'txtTANNM16.Attributes.Add("ReadOnly", "true")
            'txtBIKO16.Attributes.Add("ReadOnly", "true")
            'txtRENTEL1_16.Attributes.Add("ReadOnly", "true")
            'txtRENTEL2_16.Attributes.Add("ReadOnly", "true")
            'txtRENTEL3_16.Attributes.Add("ReadOnly", "true")    '2013/05/27 T.Ono add
            'txtFAX16.Attributes.Add("ReadOnly", "true")
            'txtTANNM17.Attributes.Add("ReadOnly", "true")
            'txtBIKO17.Attributes.Add("ReadOnly", "true")
            'txtRENTEL1_17.Attributes.Add("ReadOnly", "true")
            'txtRENTEL2_17.Attributes.Add("ReadOnly", "true")
            'txtRENTEL3_17.Attributes.Add("ReadOnly", "true")    '2013/05/27 T.Ono add
            'txtFAX17.Attributes.Add("ReadOnly", "true")
            'txtTANNM18.Attributes.Add("ReadOnly", "true")
            'txtBIKO18.Attributes.Add("ReadOnly", "true")
            'txtRENTEL1_18.Attributes.Add("ReadOnly", "true")
            'txtRENTEL2_18.Attributes.Add("ReadOnly", "true")
            'txtRENTEL3_18.Attributes.Add("ReadOnly", "true")    '2013/05/27 T.Ono add
            'txtFAX18.Attributes.Add("ReadOnly", "true")
            'txtTANNM19.Attributes.Add("ReadOnly", "true")
            'txtBIKO19.Attributes.Add("ReadOnly", "true")
            'txtRENTEL1_19.Attributes.Add("ReadOnly", "true")
            'txtRENTEL2_19.Attributes.Add("ReadOnly", "true")
            'txtRENTEL3_19.Attributes.Add("ReadOnly", "true")    '2013/05/27 T.Ono add
            'txtFAX19.Attributes.Add("ReadOnly", "true")
            'txtTANNM20.Attributes.Add("ReadOnly", "true")
            'txtBIKO20.Attributes.Add("ReadOnly", "true")
            'txtRENTEL1_20.Attributes.Add("ReadOnly", "true")
            'txtRENTEL2_20.Attributes.Add("ReadOnly", "true")
            'txtRENTEL3_20.Attributes.Add("ReadOnly", "true")    '2013/05/27 T.Ono add
            'txtFAX20.Attributes.Add("ReadOnly", "true")
            'txtTANNM21.Attributes.Add("ReadOnly", "true")
            'txtBIKO21.Attributes.Add("ReadOnly", "true")
            'txtRENTEL1_21.Attributes.Add("ReadOnly", "true")
            'txtRENTEL2_21.Attributes.Add("ReadOnly", "true")
            'txtRENTEL3_21.Attributes.Add("ReadOnly", "true")    '2013/05/27 T.Ono add
            'txtFAX21.Attributes.Add("ReadOnly", "true")
            'txtTANNM22.Attributes.Add("ReadOnly", "true")
            'txtBIKO22.Attributes.Add("ReadOnly", "true")
            'txtRENTEL1_22.Attributes.Add("ReadOnly", "true")
            'txtRENTEL2_22.Attributes.Add("ReadOnly", "true")
            'txtRENTEL3_22.Attributes.Add("ReadOnly", "true")    '2013/05/27 T.Ono add
            'txtFAX22.Attributes.Add("ReadOnly", "true")
            'txtTANNM23.Attributes.Add("ReadOnly", "true")
            'txtBIKO23.Attributes.Add("ReadOnly", "true")
            'txtRENTEL1_23.Attributes.Add("ReadOnly", "true")
            'txtRENTEL2_23.Attributes.Add("ReadOnly", "true")
            'txtRENTEL3_23.Attributes.Add("ReadOnly", "true")    '2013/05/27 T.Ono add
            'txtFAX23.Attributes.Add("ReadOnly", "true")
            'txtTANNM24.Attributes.Add("ReadOnly", "true")
            'txtBIKO24.Attributes.Add("ReadOnly", "true")
            'txtRENTEL1_24.Attributes.Add("ReadOnly", "true")
            'txtRENTEL2_24.Attributes.Add("ReadOnly", "true")
            'txtRENTEL3_24.Attributes.Add("ReadOnly", "true")    '2013/05/27 T.Ono add
            'txtFAX24.Attributes.Add("ReadOnly", "true")
            'txtTANNM25.Attributes.Add("ReadOnly", "true")
            'txtBIKO25.Attributes.Add("ReadOnly", "true")
            'txtRENTEL1_25.Attributes.Add("ReadOnly", "true")
            'txtRENTEL2_25.Attributes.Add("ReadOnly", "true")
            'txtRENTEL3_25.Attributes.Add("ReadOnly", "true")    '2013/05/27 T.Ono add
            'txtFAX25.Attributes.Add("ReadOnly", "true")
            'txtTANNM26.Attributes.Add("ReadOnly", "true")
            'txtBIKO26.Attributes.Add("ReadOnly", "true")
            'txtRENTEL1_26.Attributes.Add("ReadOnly", "true")
            'txtRENTEL2_26.Attributes.Add("ReadOnly", "true")
            'txtRENTEL3_26.Attributes.Add("ReadOnly", "true")    '2013/05/27 T.Ono add
            'txtFAX26.Attributes.Add("ReadOnly", "true")
            'txtTANNM27.Attributes.Add("ReadOnly", "true")
            'txtBIKO27.Attributes.Add("ReadOnly", "true")
            'txtRENTEL1_27.Attributes.Add("ReadOnly", "true")
            'txtRENTEL2_27.Attributes.Add("ReadOnly", "true")
            'txtRENTEL3_27.Attributes.Add("ReadOnly", "true")    '2013/05/27 T.Ono add
            'txtFAX27.Attributes.Add("ReadOnly", "true")
            'txtTANNM28.Attributes.Add("ReadOnly", "true")
            'txtBIKO28.Attributes.Add("ReadOnly", "true")
            'txtRENTEL1_28.Attributes.Add("ReadOnly", "true")
            'txtRENTEL2_28.Attributes.Add("ReadOnly", "true")
            'txtRENTEL3_28.Attributes.Add("ReadOnly", "true")    '2013/05/27 T.Ono add
            'txtFAX28.Attributes.Add("ReadOnly", "true")
            'txtTANNM29.Attributes.Add("ReadOnly", "true")
            'txtBIKO29.Attributes.Add("ReadOnly", "true")
            'txtRENTEL1_29.Attributes.Add("ReadOnly", "true")
            'txtRENTEL2_29.Attributes.Add("ReadOnly", "true")
            'txtRENTEL3_29.Attributes.Add("ReadOnly", "true")    '2013/05/27 T.Ono add
            'txtFAX29.Attributes.Add("ReadOnly", "true")
            'txtTANNM30.Attributes.Add("ReadOnly", "true")
            'txtBIKO30.Attributes.Add("ReadOnly", "true")
            'txtRENTEL1_30.Attributes.Add("ReadOnly", "true")
            'txtRENTEL2_30.Attributes.Add("ReadOnly", "true")
            'txtRENTEL3_30.Attributes.Add("ReadOnly", "true")    '2013/05/27 T.Ono add
            'txtFAX30.Attributes.Add("ReadOnly", "true")
            'txtFileName1.Attributes.Add("ReadOnly", "true")
            'txtFileName2.Attributes.Add("ReadOnly", "true")
            'txtSPOT_MAIL_1.Attributes.Add("ReadOnly", "true")
            'txtSPOT_MAIL_2.Attributes.Add("ReadOnly", "true")
            'txtSPOT_MAIL_3.Attributes.Add("ReadOnly", "true")
            'txtSPOT_MAIL_4.Attributes.Add("ReadOnly", "true")
            'txtSPOT_MAIL_5.Attributes.Add("ReadOnly", "true")
            'txtSPOT_MAIL_6.Attributes.Add("ReadOnly", "true")
            'txtSPOT_MAIL_7.Attributes.Add("ReadOnly", "true")
            'txtSPOT_MAIL_8.Attributes.Add("ReadOnly", "true")
            'txtSPOT_MAIL_9.Attributes.Add("ReadOnly", "true")
            'txtSPOT_MAIL_10.Attributes.Add("ReadOnly", "true")
            'txtSPOT_MAIL_11.Attributes.Add("ReadOnly", "true")
            'txtSPOT_MAIL_12.Attributes.Add("ReadOnly", "true")
            'txtSPOT_MAIL_13.Attributes.Add("ReadOnly", "true")
            'txtSPOT_MAIL_14.Attributes.Add("ReadOnly", "true")
            'txtSPOT_MAIL_15.Attributes.Add("ReadOnly", "true")
            'txtSPOT_MAIL_16.Attributes.Add("ReadOnly", "true")
            'txtSPOT_MAIL_17.Attributes.Add("ReadOnly", "true")
            'txtSPOT_MAIL_18.Attributes.Add("ReadOnly", "true")
            'txtSPOT_MAIL_19.Attributes.Add("ReadOnly", "true")
            'txtSPOT_MAIL_20.Attributes.Add("ReadOnly", "true")
            'txtSPOT_MAIL_21.Attributes.Add("ReadOnly", "true")
            'txtSPOT_MAIL_22.Attributes.Add("ReadOnly", "true")
            'txtSPOT_MAIL_23.Attributes.Add("ReadOnly", "true")
            'txtSPOT_MAIL_24.Attributes.Add("ReadOnly", "true")
            'txtSPOT_MAIL_25.Attributes.Add("ReadOnly", "true")
            'txtSPOT_MAIL_26.Attributes.Add("ReadOnly", "true")
            'txtSPOT_MAIL_27.Attributes.Add("ReadOnly", "true")
            'txtSPOT_MAIL_28.Attributes.Add("ReadOnly", "true")
            'txtSPOT_MAIL_29.Attributes.Add("ReadOnly", "true")
            'txtSPOT_MAIL_30.Attributes.Add("ReadOnly", "true")
            '2016/05/10 w.ganeko mod end
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
        '�g�p�\����(�^:��/�c:�~/��:��/�o:�~)
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
             MyBase.MapPath("../../../KE/KETAIJAG/KETAIJAG00/") & "KETAIJTG00.js"))
        '<�t�H�[�J�X�֘A�֐�>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncFo.js"))
        '<���̓`�F�b�N�֐�>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncChk.js"))
        '<�d�b�ԍ��`�F�b�N�֐�>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncTel.js"))
        '<�o�C�g���֐�>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncGetByte.js"))
        '<�S�p�`�F�b�N�֐�>
        '--- ��2005/05/19 DEL Falcon�� ---
        'strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncZenkakuChk.js"))
        '--- ��2005/05/19 DEL Falcon�� ---
        strScript.Append(strScript.Append("</Script>"))
        '//------------------------------------------
        '//�@Css�i�[
        strScript.Append("<Style>")
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "CssSmall.css"))
        strScript.Append("</Style>")
        '//------------------------------------------
        '//�@Script������
        lblScript.Text = strScript.ToString

        '--- ��2005/09/09 MOD Falcon�� ---  //����޳�Ͻ�����o��
        '//�e�`�w�^�C�g���R���{�쐬 -----------
        Call fncCombo_Create()
        'cboFAX_TITLE.Items.Add(New ListItem("�Ή��˗���(�ً}�o��)", "�Ή��˗���(�ً}�o��)"))
        'cboFAX_TITLE.Items.Add(New ListItem("�Ή��˗���(�_��)", "�Ή��˗���(�_��)"))
        'cboFAX_TITLE.Items.Add(New ListItem("�Ή��˗���(��)", "�Ή��˗���(��)"))
        cboFAX_TITLE.SelectedIndex = 0
        '--- ��2005/09/09 MOD Falcon�� ---  

        '//------------------------------------
        Dim SQLC As New KETAIJAG00CSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet
        '--- ��2005/04/27 ADD Falcon�� ---
        Try
            If MyBase.IsPostBack = False Then
                '//�Ή����͉�ʂ̏����󂯎�� ---
                Call GetKETAIJAG00()
                '//--------------------------------
                '--- ��2005/04/27 ADD Falcon�� ---
                '--- ��2005/04/27 DEL Falcon�� ---
                'Dim KETAIJAG00C As KETAIJAG00
                'KETAIJAG00C = CType(Context.Handler, KETAIJAG00)
                '--- ��2005/04/27 DEL Falcon�� ---
                strSQL = New StringBuilder("")
                strSQL.Append("SELECT  ")
                '''''strSQL.Append("JA.JA_NAME || ' / ' || JA.JAS_NAME AS JASNM, ")
                strSQL.Append("JA.JA_NAME, ")
                strSQL.Append("JA.JAS_NAME, ")
                '''''strSQL.Append("JA.JA_KANA || ' / ' || JA.JAS_KANA AS JASKN ")
                strSQL.Append("JA.JA_KANA, ")
                strSQL.Append("JA.JAS_KANA ")
                strSQL.Append("FROM HN2MAS JA ")
                strSQL.Append("WHERE JA.CLI_CD = :CLSI_CD ")
                strSQL.Append("  AND JA.HAN_CD = :HAN_CD ")

                '�p�����[�^�̃Z�b�g
                '--- ��2005/04/27 DEL Falcon�� ---
                'SqlParamC.fncSetParam("CLSI_CD", True, KETAIJAG00C.pPRAM_CLI)
                'SqlParamC.fncSetParam("HAN_CD", True, KETAIJAG00C.pPRAM_JASS)
                '--- ��2005/04/27 DEL Falcon�� ---
                '--- ��2005/04/27 MOD Falcon�� ---
                SqlParamC.fncSetParam("CLSI_CD", True, hdnKURACD.Value)
                SqlParamC.fncSetParam("HAN_CD", True, hdnACBCD.Value)
                '--- ��2005/04/27 MOD Falcon�� ---

                '//SQL�̎��s
                dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

                If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then

                Else
                    '//���̏o��
                    '����
                    If Convert.ToString(dbData.Tables(0).Rows(0).Item("JA_NAME")).Length = 0 And Convert.ToString(dbData.Tables(0).Rows(0).Item("JAS_NAME")).Length = 0 Then
                        '�������݂��Ȃ�
                        '2016/02/02 W.GANEKO 2015���P�J�� ��2
                        'txtACBNM.Text = ""
                        txtACBKN.Text = ""
                    ElseIf Convert.ToString(dbData.Tables(0).Rows(0).Item("JA_NAME")).Length > 0 And Convert.ToString(dbData.Tables(0).Rows(0).Item("JAS_NAME")).Length > 0 Then
                        '�������݂���
                        '2016/02/02 W.GANEKO 2015���P�J�� ��2
                        'txtACBNM.Text = Convert.ToString(dbData.Tables(0).Rows(0).Item("JA_NAME")) & " / " & Convert.ToString(dbData.Tables(0).Rows(0).Item("JAS_NAME"))
                        txtACBKN.Text = Convert.ToString(dbData.Tables(0).Rows(0).Item("JA_NAME")) & " / " & Convert.ToString(dbData.Tables(0).Rows(0).Item("JAS_NAME"))
                    Else
                        '�ǂ��炩���݂���
                        '2016/02/02 W.GANEKO 2015���P�J�� ��2
                        'txtACBNM.Text = Convert.ToString(dbData.Tables(0).Rows(0).Item("JA_NAME")) & Convert.ToString(dbData.Tables(0).Rows(0).Item("JAS_NAME"))
                        txtACBKN.Text = Convert.ToString(dbData.Tables(0).Rows(0).Item("JA_NAME")) & Convert.ToString(dbData.Tables(0).Rows(0).Item("JAS_NAME"))
                    End If
                    '2016/02/02 W.GANEKO 2015���P�J�� ��2 START
                    ''�J�i
                    'If Convert.ToString(dbData.Tables(0).Rows(0).Item("JA_KANA")).Length = 0 And Convert.ToString(dbData.Tables(0).Rows(0).Item("JAS_KANA")).Length = 0 Then
                    '    '�������݂��Ȃ�
                    '    txtACBKN.Text = ""
                    'ElseIf Convert.ToString(dbData.Tables(0).Rows(0).Item("JA_KANA")).Length > 0 And Convert.ToString(dbData.Tables(0).Rows(0).Item("JAS_KANA")).Length > 0 Then
                    '    '�������݂���
                    '    txtACBKN.Text = Convert.ToString(dbData.Tables(0).Rows(0).Item("JA_KANA")) & " / " & Convert.ToString(dbData.Tables(0).Rows(0).Item("JAS_KANA"))
                    'Else
                    '    '�ǂ��炩���݂���
                    '    txtACBKN.Text = Convert.ToString(dbData.Tables(0).Rows(0).Item("JA_KANA")) & Convert.ToString(dbData.Tables(0).Rows(0).Item("JAS_KANA"))
                    'End If
                    '2016/02/02 W.GANEKO 2015���P�J�� ��2 END

                    '--- ��2005/04/27 DEL Falcon�� ---
                    'hdnREN_1_TANCD.Value = Request.Form("hdnREN_0_TANCD")
                    'txtTANNM1.Text = Request.Form("hdnREN_0_NA")
                    'txtRENTEL1_1.Text = Request.Form("hdnREN_0_TEL1")
                    'txtRENTEL2_1.Text = Request.Form("hdnREN_0_TEL2")
                    'txtFAX1.Text = Request.Form("hdnREN_0_FAX")             '�e�`�w�ԍ��P
                    'txtBIKO1.Text = Request.Form("hdnREN_0_BIKO")
                    'hdnREN_2_TANCD.Value = Request.Form("hdnREN_1_TANCD")
                    'txtTANNM2.Text = Request.Form("hdnREN_1_NA")
                    'txtRENTEL1_2.Text = Request.Form("hdnREN_1_TEL1")
                    'txtRENTEL2_2.Text = Request.Form("hdnREN_1_TEL2")
                    'txtFAX2.Text = Request.Form("hdnREN_1_FAX")             '�e�`�w�ԍ��Q
                    'txtBIKO2.Text = Request.Form("hdnREN_1_BIKO")
                    'hdnREN_3_TANCD.Value = Request.Form("hdnREN_2_TANCD")
                    'txtTANNM3.Text = Request.Form("hdnREN_2_NA")
                    'txtRENTEL1_3.Text = Request.Form("hdnREN_2_TEL1")
                    'txtRENTEL2_3.Text = Request.Form("hdnREN_2_TEL2")
                    'txtFAX3.Text = Request.Form("hdnREN_2_FAX")             '�e�`�w�ԍ��R
                    'txtBIKO3.Text = Request.Form("hdnREN_2_BIKO")
                    'hdnREN_4_TANCD.Value = Request.Form("hdnREN_3_TANCD")
                    'txtTANNM4.Text = Request.Form("hdnREN_3_NA")
                    'txtRENTEL1_4.Text = Request.Form("hdnREN_3_TEL1")
                    'txtRENTEL2_4.Text = Request.Form("hdnREN_3_TEL2")
                    'txtFAX4.Text = Request.Form("hdnREN_3_FAX")             '�e�`�w�ԍ��S
                    'txtBIKO4.Text = Request.Form("hdnREN_3_BIKO")
                    'txtDENWABIKO.Text = Request.Form("hdnREN_DENWABIKO")
                    ''�e�`�w�^�C�g��
                    'Dim strTemp As String
                    'Dim list As New ListItem
                    'strTemp = Request.Form("hdnREN_FAXTITLE")
                    'If strTemp <> "" Then
                    '    list = cboFAX_TITLE.Items.FindByValue(strTemp)
                    '    cboFAX_TITLE.SelectedIndex = cboFAX_TITLE.Items.IndexOf(list)
                    'End If
                    'txtFAX_REN.Text = Request.Form("hdnREN_FAXREN")         '�e�`�w�A����

                    '--- ��2005/04/27 DEL Falcon�� ---
                End If
            End If

            '�J�[�\���̃Z�b�g
            strMsg.Append("Form1.txtTANNM1.focus();")
            '--- ��2005/04/27 ADD Falcon�� ---

        Catch ex As Exception
            Dim ErrMsgC As New CErrMsg
            strMsg.Append("alert('�V�X�e���G���[�F" & ErrMsgC.mGetArtMsg(ex.ToString) & "');")

        Finally
            If dbData Is Nothing Then
            Else
                dbData.Dispose()
            End If
        End Try
        '--- ��2005/04/27 ADD Falcon�� ---

        fncSearchAndSetFileName12() ' �t�@�C�����ĕ\���i�t�@�C�������擾���ăZ�b�g�j 2010/04/28 T.Watabe add

    End Sub

    '--- ��2005/04/25 ADD Falcon�� ---
    '******************************************************************************
    '*�@�T�@�v�F
    '*�@���@�l�F
    '******************************************************************************
    Private Sub GetKETAIJAG00()
        Dim UtilFucC As New CUtilFuc

        '2010/05/10 T.Watabe add
        Dim hdnREN_TANCD As HtmlInputHidden
        Dim txtTANNM As TextBox
        Dim txtRENTEL1 As TextBox
        Dim txtRENTEL2 As TextBox
        Dim txtRENTEL3 As TextBox '2013/05/27 T.Ono add
        Dim txtFAX As TextBox
        Dim txtBIKO As TextBox
        Dim txtSPOTMAIL As TextBox
        Dim hdnMAILPASS As HtmlInputHidden
        Dim i As Integer
        i = 1
        Do While (i <= 30) '�R�O�s�܂őΉ�
            '�R���g���[������� �P�`�R�O
            hdnREN_TANCD = DirectCast(FindControl("hdnREN_" & i & "_TANCD"), HtmlInputHidden)
            txtTANNM = DirectCast(FindControl("txtTANNM" & i), TextBox)
            txtRENTEL1 = DirectCast(FindControl("txtRENTEL1_" & i), TextBox)
            txtRENTEL2 = DirectCast(FindControl("txtRENTEL2_" & i), TextBox)
            txtRENTEL3 = DirectCast(FindControl("txtRENTEL3_" & i), TextBox) '2013/05/27 T.Ono add
            txtFAX = DirectCast(FindControl("txtFAX" & i), TextBox)
            txtBIKO = DirectCast(FindControl("txtBIKO" & i), TextBox)
            txtSPOTMAIL = DirectCast(FindControl("txtSPOT_MAIL_" & i), TextBox)
            hdnMAILPASS = DirectCast(FindControl("hdnREN_" & i & "_MAILPASS"), HtmlInputHidden)
            '���
            hdnREN_TANCD.Value = Request.Form("hdnREN_" & i - 1 & "_TANCD")
            txtTANNM.Text = Request.Form("hdnREN_" & i - 1 & "_NA")
            txtRENTEL1.Text = Request.Form("hdnREN_" & i - 1 & "_TEL1")
            txtRENTEL2.Text = Request.Form("hdnREN_" & i - 1 & "_TEL2")
            txtRENTEL3.Text = Request.Form("hdnREN_" & i - 1 & "_TEL3") '2013/05/27 T.Ono add
            txtFAX.Text = Request.Form("hdnREN_" & i - 1 & "_FAX")
            txtBIKO.Text = Request.Form("hdnREN_" & i - 1 & "_BIKO")
            txtSPOTMAIL.Text = Request.Form("hdnREN_" & i - 1 & "_MAIL")
            hdnMAILPASS.Value = Request.Form("hdnREN_" & i - 1 & "_MAILPASS")
            i = i + 1
        Loop

        'hdnREN_1_TANCD.Value = Request.Form("hdnREN_0_TANCD")
        'txtTANNM1.Text = Request.Form("hdnREN_0_NA")
        'txtRENTEL1_1.Text = Request.Form("hdnREN_0_TEL1")
        'txtRENTEL2_1.Text = Request.Form("hdnREN_0_TEL2")
        'txtFAX1.Text = Request.Form("hdnREN_0_FAX")             '�e�`�w�ԍ��P
        'txtBIKO1.Text = Request.Form("hdnREN_0_BIKO")
        'hdnREN_2_TANCD.Value = Request.Form("hdnREN_1_TANCD")
        'txtTANNM2.Text = Request.Form("hdnREN_1_NA")
        'txtRENTEL1_2.Text = Request.Form("hdnREN_1_TEL1")
        'txtRENTEL2_2.Text = Request.Form("hdnREN_1_TEL2")
        'txtFAX2.Text = Request.Form("hdnREN_1_FAX")             '�e�`�w�ԍ��Q
        'txtBIKO2.Text = Request.Form("hdnREN_1_BIKO")
        'hdnREN_3_TANCD.Value = Request.Form("hdnREN_2_TANCD")
        'txtTANNM3.Text = Request.Form("hdnREN_2_NA")
        'txtRENTEL1_3.Text = Request.Form("hdnREN_2_TEL1")
        'txtRENTEL2_3.Text = Request.Form("hdnREN_2_TEL2")
        'txtFAX3.Text = Request.Form("hdnREN_2_FAX")             '�e�`�w�ԍ��R
        'txtBIKO3.Text = Request.Form("hdnREN_2_BIKO")
        'hdnREN_4_TANCD.Value = Request.Form("hdnREN_3_TANCD")
        'txtTANNM4.Text = Request.Form("hdnREN_3_NA")
        'txtRENTEL1_4.Text = Request.Form("hdnREN_3_TEL1")
        'txtRENTEL2_4.Text = Request.Form("hdnREN_3_TEL2")
        'txtFAX4.Text = Request.Form("hdnREN_3_FAX")             '�e�`�w�ԍ��S
        'txtBIKO4.Text = Request.Form("hdnREN_3_BIKO")

        ''2008/10/31 T.Watabe add
        'hdnREN_5_TANCD.Value = Request.Form("hdnREN_4_TANCD")          '�T
        'txtTANNM5.Text = Request.Form("hdnREN_4_NA")
        'txtRENTEL1_5.Text = Request.Form("hdnREN_4_TEL1")
        'txtRENTEL2_5.Text = Request.Form("hdnREN_4_TEL2")
        'txtFAX5.Text = Request.Form("hdnREN_4_FAX")
        'txtBIKO5.Text = Request.Form("hdnREN_4_BIKO")
        'hdnREN_6_TANCD.Value = Request.Form("hdnREN_5_TANCD")          '�U
        'txtTANNM6.Text = Request.Form("hdnREN_5_NA")
        'txtRENTEL1_6.Text = Request.Form("hdnREN_5_TEL1")
        'txtRENTEL2_6.Text = Request.Form("hdnREN_5_TEL2")
        'txtFAX6.Text = Request.Form("hdnREN_5_FAX")
        'txtBIKO6.Text = Request.Form("hdnREN_5_BIKO")
        'hdnREN_7_TANCD.Value = Request.Form("hdnREN_6_TANCD")          '�V
        'txtTANNM7.Text = Request.Form("hdnREN_6_NA")
        'txtRENTEL1_7.Text = Request.Form("hdnREN_6_TEL1")
        'txtRENTEL2_7.Text = Request.Form("hdnREN_6_TEL2")
        'txtFAX7.Text = Request.Form("hdnREN_6_FAX")
        'txtBIKO7.Text = Request.Form("hdnREN_6_BIKO")
        'hdnREN_8_TANCD.Value = Request.Form("hdnREN_7_TANCD")          '�W
        'txtTANNM8.Text = Request.Form("hdnREN_7_NA")
        'txtRENTEL1_8.Text = Request.Form("hdnREN_7_TEL1")
        'txtRENTEL2_8.Text = Request.Form("hdnREN_7_TEL2")
        'txtFAX8.Text = Request.Form("hdnREN_7_FAX")
        'txtBIKO8.Text = Request.Form("hdnREN_7_BIKO")
        'hdnREN_9_TANCD.Value = Request.Form("hdnREN_8_TANCD")          '�X
        'txtTANNM9.Text = Request.Form("hdnREN_8_NA")
        'txtRENTEL1_9.Text = Request.Form("hdnREN_8_TEL1")
        'txtRENTEL2_9.Text = Request.Form("hdnREN_8_TEL2")
        'txtFAX9.Text = Request.Form("hdnREN_8_FAX")
        'txtBIKO9.Text = Request.Form("hdnREN_8_BIKO")
        'hdnREN_10_TANCD.Value = Request.Form("hdnREN_9_TANCD")          '�P�O
        'txtTANNM10.Text = Request.Form("hdnREN_9_NA")
        'txtRENTEL1_10.Text = Request.Form("hdnREN_9_TEL1")
        'txtRENTEL2_10.Text = Request.Form("hdnREN_9_TEL2")
        'txtFAX10.Text = Request.Form("hdnREN_9_FAX")
        'txtBIKO10.Text = Request.Form("hdnREN_9_BIKO")
        'txtDENWABIKO.Text = Request.Form("hdnREN_DENWABIKO") '2014/12/01 H.Hosoda del 1Line 2014���P�J�� No4 
        '�e�`�w�^�C�g��
        Dim strTemp As String
        Dim list As New ListItem
        '--- ��2005/09/09 MOD Falcon�� ---
        'strTemp = Request.Form("hdnREN_FAXTITLE")
        strTemp = Request.Form("hdnFAX_TITLE_CD")
        If strTemp <> "" Then
            list = cboFAX_TITLE.Items.FindByValue(strTemp)
            cboFAX_TITLE.SelectedIndex = cboFAX_TITLE.Items.IndexOf(list)
        End If
        '--- ��2005/09/09 MOD Falcon�� ---
        '--- ��2005/09/26 ADD Falcon�� ---
        hdnFAX_TITLE.Value = cboFAX_TITLE.SelectedValue
        '--- ��2005/09/26 ADD Falcon�� ---
        txtFAX_REN.Text = Request.Form("hdnREN_FAXREN")             '������
        '//�e�`�w���M�pHidden-----------------
        hdnFAXEXEPATH.Value = Request.Form("hdnFAXEXEPATH")         '�e�`�wEXE�i�[�t�H���_[config]
        hdnFAXEXENAME.Value = Request.Form("hdnFAXEXENAME")         '�e�`�wEXE��[config]
        hdnFAXHEAD.Value = Request.Form("hdnFAXHEAD")               '���ԍ�(�e�`�w)[config]
        hdnFAXSESSION.Value = Request.Form("hdnFAXSESSION")         '�Z�b�V�����h�c
        hdnSYONO.Value = Request.Form("hdnSYONO")                   '�����ԍ�
        hdnHATYMD.Value = Request.Form("txtHATYMD")                 '������
        hdnHATTIME.Value = Request.Form("txtHATTIME")               '��������
        hdnKURACD.Value = Request.Form("txtClientCD")               '�N���C�A���g�R�[�h
        hdnACBCD.Value = Request.Form("hdnJASCD")                   '�i�`�x���R�[�h
        hdnKANSCD.Value = Request.Form("hdnKANSCD")                 '�Ď��Z���^�[�R�[�h
        hdnJUSYONM.Value = Request.Form("txtJUSYONM")               '���q�l����
        hdnUSER_CD.Value = Request.Form("txtJUYOKA")                '���q�l�R�[�h
        hdnJUTEL1.Value = Request.Form("txtJUTEL1")                 '�d�b�ԍ�(�s�O)
        hdnJUTEL2.Value = Request.Form("txtJUTEL2")                 '�d�b�ԍ�(�s��)
        hdnRENTEL.Value = Request.Form("txtRENTEL")                 '�A����d�b
        hdnADDR.Value = UtilFucC.CrlfCut(Request.Form("txtADDR"))   '�Z��
        hdnKENSIN.Value = Request.Form("txtKMSIN")                  '���[�^�l
        hdnRYURYO.Value = Request.Form("txtRYURYO")                 '���ʋ敪
        hdnMETASYU.Value = Request.Form("txtMETASYU")               '���[�^���
        '2015/01/06 T.Ono mod 2014���P�J�� No5 START
        'hdnKMNM1.Value = Request.Form("hdnKMNM1")                   '�x��P���b�Z�[�W
        'hdnKMNM2.Value = Request.Form("hdnKMNM2")                   '�x��Q���b�Z�[�W
        'hdnKMNM3.Value = Request.Form("hdnKMNM3")                   '�x��R���b�Z�[�W
        'hdnKMNM4.Value = Request.Form("hdnKMNM4")                   '�x��S���b�Z�[�W
        'hdnKMNM5.Value = Request.Form("hdnKMNM5")                   '�x��T���b�Z�[�W
        'hdnKMNM6.Value = Request.Form("hdnKMNM6")                   '�x��U���b�Z�[�W
        fncSetKMNM()
        '2015/01/06 T.Ono mod 2014���P�J�� No5 END

        hdnTAIOKBN.Value = Request.Form("cboTAIOKBN")               '�Ή��敪
        hdnTKTANCD.Value = Request.Form("hdnTKTANCD")               '�Ď��Z���^�[�S����
        hdnSYOYMD.Value = Request.Form("txtSYOYMD")                 '�Ή�������
        hdnSYOTIME.Value = Request.Form("txtSYOTIME")               '�Ή���������
        hdnSIJIYMD.Value = Request.Form("txtSIJIYMD")               '�o���w����
        hdnSIJITIME.Value = Request.Form("txtSIJITIME")             '�o���w������
        hdnTAITCD.Value = Request.Form("cboTAITCD")                 '�A������
        hdnTELRCD.Value = Request.Form("cboTELRCD")                 '�d�b�A�����e
        '2013/10/28 T.Ono mod �Ď����P2013��1
        'hdnFUK_MEMO.Value = Request.Form("txtFUK_MEMO")             '���A���상��
        'hdnTEL_MEMO1.Value = Request.Form("txtTEL_MEMO1")           '�d�b�����P
        'hdnTEL_MEMO2.Value = Request.Form("txtTEL_MEMO2")           '�d�b�����Q
        hdnTEL_MEMO1.Value = Request.Form("hdnTEL_MEMO1")           '�d�b����1�s��
        hdnTEL_MEMO2.Value = Request.Form("hdnTEL_MEMO2")           '�d�b����2�s��
        hdnFUK_MEMO.Value = Request.Form("hdnFUK_MEMO")             '�d�b����3�s��
        hdnTEL_MEMO4.Value = Request.Form("hdnTEL_MEMO4")           '�d�b����4�s��    2020/11/01 T.Ono add 2020�Ď����P
        hdnTEL_MEMO5.Value = Request.Form("hdnTEL_MEMO5")           '�d�b����5�s��    2020/11/01 T.Ono add 2020�Ď����P
        hdnTEL_MEMO6.Value = Request.Form("hdnTEL_MEMO6")           '�d�b����6�s��    2020/11/01 T.Ono add 2020�Ď����P
        hdnTKIGCD.Value = Request.Form("cboTKIGCD")                 '�K�X���
        hdnTSADCD.Value = Request.Form("cboTSADCD")                 '�쓮����
        hdnMITOKBN.Value = Request.Form("hdnMOVE_MITOKBN")          '���o�^�e�k�f

        hdnM05_TANTO_HAN_CD.Value = Request.Form("hdnM05_TANTO_HAN_CD") 'M05_TANTO�}�X�^�������ۂ̂i�`���ށiJA���ނ�JA�x�����ނ�ێ��j' 2010/05/12 T.Watabe add
        hdnUSER_CD_FROM.Value = Request.Form("hdnUSER_CD_FROM") ' 2013/07/11 T.Ono
        '2016/02/02 W.GANEKO 2015���P�J�� START
        txtACBNM.Text = Request.Form("hdnGROUPCD") & ":" & Request.Form("hdnGROUPNM")
        hdnGROUPCD.Value = Request.Form("hdnGROUPCD")               '�O���[�v�R�[�h�@2016/04/19 T.Ono add 2015���P�J�� ��7
        ' 2013/07/05 T.Ono del �b��Ή��͍폜
        ''2013/03/15 w.ganeko �V���Ή�
        'Dim SQLC2 As New KETAIJAG00CSQL.CSQL
        'Dim SqlParamC2 As New CSQLParam
        'Dim strSQL2 As New StringBuilder("")
        'Dim strSQL3 As New StringBuilder("")
        'Dim dbData2 As DataSet
        'strSQL2 = New StringBuilder("")
        'strSQL2.Append("SELECT  ")
        'strSQL2.Append("TAN.TANCD AS TANCD, ")
        'strSQL2.Append("TAN.TANNM AS TANNM, ")
        'strSQL2.Append("TAN.RENTEL1 AS RENTEL1, ")
        'strSQL2.Append("TAN.RENTEL2 AS RENTEL2, ")
        'strSQL2.Append("TAN.FAXNO AS FAXNO, ")
        'strSQL2.Append("TAN.BIKO AS BIKO, ")
        'strSQL2.Append("TAN.SPOT_MAIL AS SPOT_MAIL, ")
        'strSQL2.Append("TAN.MAIL_PASS AS MAIL_PASS ")
        'strSQL2.Append("FROM M06_PULLDOWN M06, ")
        'strSQL2.Append(" M05_TANTO TAN ")
        'strSQL2.Append("WHERE M06.KBN = '77' ")
        'strSQL2.Append("  AND M06.NAME = :KURACD||:ACBCD ")
        'strSQL2.Append("  AND TAN.KBN = '3' ")
        'strSQL2.Append("  AND TAN.KURACD = :KURACD1 ")
        'strSQL2.Append("  AND TAN.CODE = M06.NAIYO2 ")

        'Dim x As Integer
        'Dim x2 As Integer
        'Dim sqlflg As Boolean = False
        'Try
        '    strSQL3 = New StringBuilder("")
        '    strSQL3.Append(strSQL2.ToString)
        '    strSQL3.Append("  AND M06.NAIYO1 = :USER_CD ")
        '    strSQL3.Append("ORDER BY TO_NUMBER(TAN.TANCD)  ")
        '    SqlParamC2.fncSetParam("KURACD", True, hdnKURACD.Value)
        '    SqlParamC2.fncSetParam("ACBCD", True, hdnACBCD.Value)
        '    SqlParamC2.fncSetParam("USER_CD", True, hdnUSER_CD.Value)
        '    SqlParamC2.fncSetParam("KURACD1", True, hdnKURACD.Value)
        '    '//SQL�̎��s
        '    dbData2 = SQLC2.mGetData(strSQL3.ToString, SqlParamC2.pParamDataSet, True)
        '    x = 0
        '    x2 = 1
        '    If Convert.ToString(dbData2.Tables(0).Rows(0).Item(0)) = "XYZ" Then
        '        '�f�[�^�Ȃ��̏ꍇ�A���q�l�R�[�h���Q���ȏ�Ŕ�r
        '        strSQL3 = New StringBuilder("")
        '        strSQL3.Append(strSQL2.ToString)
        '        strSQL3.Append("  AND :USER_CD LIKE TRIM(M06.NAIYO1)||'%'  ")
        '        'strSQL3.Append("  AND M06.NAIYO1 = SUBSTR(:USER_CD,1,2) ")
        '        strSQL3.Append("ORDER BY TO_NUMBER(TAN.TANCD)  ")
        '        SqlParamC2.fncSetParam("KURACD", True, hdnKURACD.Value)
        '        SqlParamC2.fncSetParam("ACBCD", True, hdnACBCD.Value)
        '        SqlParamC2.fncSetParam("USER_CD", True, hdnUSER_CD.Value)
        '        SqlParamC2.fncSetParam("KURACD1", True, hdnKURACD.Value)
        '        '//SQL�̎��s
        '        dbData2 = SQLC2.mGetData(strSQL3.ToString, SqlParamC2.pParamDataSet, True)
        '        If Convert.ToString(dbData2.Tables(0).Rows(0).Item(0)) = "XYZ" Then
        '            '�f�[�^�Ȃ��̏ꍇ
        '        Else
        '            sqlflg = True
        '        End If
        '    Else
        '        sqlflg = True
        '    End If
        '    If sqlflg Then
        '        For x = 0 To dbData2.Tables(0).Rows.Count - 1
        '            hdnREN_TANCD = DirectCast(FindControl("hdnREN_" & x2 & "_TANCD"), HtmlInputHidden)
        '            txtTANNM = DirectCast(FindControl("txtTANNM" & x2), TextBox)
        '            txtRENTEL1 = DirectCast(FindControl("txtRENTEL1_" & x2), TextBox)
        '            txtRENTEL2 = DirectCast(FindControl("txtRENTEL2_" & x2), TextBox)
        '            txtRENTEL3 = DirectCast(FindControl("txtRENTEL3_" & x2), TextBox) '2013/05/27 T.Ono
        '            txtFAX = DirectCast(FindControl("txtFAX" & x2), TextBox)
        '            txtBIKO = DirectCast(FindControl("txtBIKO" & x2), TextBox)
        '            txtSPOTMAIL = DirectCast(FindControl("txtSPOT_MAIL_" & x2), TextBox)
        '            hdnMAILPASS = DirectCast(FindControl("hdnREN_" & x2 & "_MAILPASS"), HtmlInputHidden)
        '            '�A�����ύX
        '            hdnREN_TANCD.Value = Convert.ToString(dbData2.Tables(0).Rows(x).Item("TANCD"))
        '            txtTANNM.Text = Convert.ToString(dbData2.Tables(0).Rows(x).Item("TANNM"))
        '            txtRENTEL1.Text = Convert.ToString(dbData2.Tables(0).Rows(x).Item("RENTEL1"))
        '            txtRENTEL2.Text = Convert.ToString(dbData2.Tables(0).Rows(x).Item("RENTEL2"))
        '            txtRENTEL3.Text = Convert.ToString(dbData2.Tables(0).Rows(x).Item("RENTEL3")) '2013/05/27 T.Ono
        '            txtFAX.Text = Convert.ToString(dbData2.Tables(0).Rows(x).Item("FAXNO"))
        '            txtBIKO.Text = Convert.ToString(dbData2.Tables(0).Rows(x).Item("BIKO"))
        '            txtSPOTMAIL.Text = Convert.ToString(dbData2.Tables(0).Rows(x).Item("SPOT_MAIL"))
        '            hdnMAILPASS.Value = Convert.ToString(dbData2.Tables(0).Rows(x).Item("MAIL_PASS"))
        '            x2 = x2 + 1
        '        Next
        '        Do While (x2 <= 30) '�R�O�s�܂őΉ�
        '            '�R���g���[������� �P�`�R�O
        '            hdnREN_TANCD = DirectCast(FindControl("hdnREN_" & x2 & "_TANCD"), HtmlInputHidden)
        '            txtTANNM = DirectCast(FindControl("txtTANNM" & x2), TextBox)
        '            txtRENTEL1 = DirectCast(FindControl("txtRENTEL1_" & x2), TextBox)
        '            txtRENTEL2 = DirectCast(FindControl("txtRENTEL2_" & x2), TextBox)
        '            txtRENTEL3 = DirectCast(FindControl("txtRENTEL3_" & x2), TextBox) '2013/05/27 T.Ono
        '            txtFAX = DirectCast(FindControl("txtFAX" & x2), TextBox)
        '            txtBIKO = DirectCast(FindControl("txtBIKO" & x2), TextBox)
        '            txtSPOTMAIL = DirectCast(FindControl("txtSPOT_MAIL_" & x2), TextBox)
        '            hdnMAILPASS = DirectCast(FindControl("hdnREN_" & x2 & "_MAILPASS"), HtmlInputHidden)
        '            '���
        '            hdnREN_TANCD.Value = ""
        '            txtTANNM.Text = ""
        '            txtRENTEL1.Text = ""
        '            txtRENTEL2.Text = ""
        '            txtRENTEL3.Text = ""
        '            txtFAX.Text = ""
        '            txtBIKO.Text = ""
        '            txtSPOTMAIL.Text = ""
        '            hdnMAILPASS.Value = ""
        '            x2 = x2 + 1
        '        Loop
        '    End If

        'Catch ex As Exception
        '    Dim ErrMsgC As New CErrMsg
        '    strMsg.Append("alert('�V�X�e���G���[�F" & ErrMsgC.mGetArtMsg(ex.ToString) & "');")
        'Finally
        '    If dbData2 Is Nothing Then
        '    Else
        '        dbData2.Dispose()
        '    End If
        'End Try
    End Sub

    '******************************************************************************
    '*�@�T�@�v�F�e�`�w�^�d�b���M�{�^������
    '*�@���@�l�F
    '******************************************************************************
    Private Sub btnTelHas_ServerClick(ByVal sender As System.Object, _
                                    ByVal e As System.EventArgs) Handles btnTelHas.ServerClick
        '//--------------------------------------------------------------------------
        '<TODO>�e�`�w�f�[�^�쐬���s��
        Server.Transfer("KETAIJFG00.aspx")

    End Sub
    '--- ��2005/04/25 ADD Falcon�� ---

    '--- ��2005/09/09 ADD Falcon�� ---
    '******************************************************************************
    '*�@�T�@�v�F�e�`�w�^�C�g���R���{�쐬
    '*�@���@�l�F
    '******************************************************************************
    Private Sub fncCombo_Create()
        cboFAX_TITLE.pComboTitle = False
        cboFAX_TITLE.pNoData = False
        cboFAX_TITLE.pType = "FAXTITLE"               '//�e�`�w�^�C�g��
        cboFAX_TITLE.mMakeCombo()
    End Sub
    '--- ��2005/09/09 ADD Falcon�� ---

    ' 2010/04/15 T.Watabe add
    '******************************************************************************
    '* �t�@�C���_�E�����[�h����
    '******************************************************************************
    Private Sub btnFileDownload1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFileDownload1.Click

        Dim sSaveFileName As String   '���ۂ̌��t�@�C�����i�g���q����j  jm000000_�e�X�g�t�@�C��.xls
        Dim sSaveFileNameR As String  '�_�E�����[�h��̃t�@�C����        �e�X�g�t�@�C��.xls
        Dim sSavePath As String       '���t�@�C���ۑ��t�H���_            D:\TEMP\SAVE\
        Try
            sSavePath = ConfigurationSettings.AppSettings("JA_TAN_MST_PATH")
            sSaveFileNameR = txtFileName1.Text.Trim '���t�@�C������
            'sSaveFileName = hdnKURACD.Value.Trim & "_" & hdnACBCD.Value.Trim & "_" & sSaveFileNameR '�t�@�C�������A�ײ��ĺ��ށ{���ށ{�t�@�C�����ɕϊ�
            ' 2013/07/11 T.Ono mod
            'sSaveFileName = hdnKURACD.Value.Trim & "_" & hdnM05_TANTO_HAN_CD.Value.Trim & "_" & sSaveFileNameR '�t�@�C�������A�ײ��ĺ��ށ{���ށ{�t�@�C�����ɕϊ�
            '2016/04/19 T.Ono mod 2015���P�J�� ��7 START
            'If Trim(hdnUSER_CD_FROM.Value) <> "" Then
            '    sSaveFileName = hdnKURACD.Value.Trim & "_" & hdnM05_TANTO_HAN_CD.Value.Trim & "_" & Trim(hdnUSER_CD_FROM.Value) & "_" & sSaveFileNameR '�t�@�C�������A�ײ��ĺ��ށ{���ށ{USER_CD_FROM+�t�@�C�����ɕϊ�
            'Else
            '    sSaveFileName = hdnKURACD.Value.Trim & "_" & hdnM05_TANTO_HAN_CD.Value.Trim & "_" & "X" & "_" & sSaveFileNameR '�t�@�C�������A�ײ��ĺ��ށ{���ށ{ "X" +�t�@�C�����ɕϊ�
            'End If
            sSaveFileName = hdnGROUPCD.Value.Trim & "_" & sSaveFileNameR
            '2016/04/19 T.Ono mod 2015���P�J�� ��7 END

            fncFileDownload(sSavePath, sSaveFileName, sSaveFileNameR)
        Catch ex As Exception
            Throw ex
        Finally
            Call KeepKETAIJAG00()
        End Try
    End Sub
    Private Sub btnFileDownload2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFileDownload2.Click

        Dim sSaveFileName As String   '���ۂ̌��t�@�C�����i�g���q����j  jm000000_�e�X�g�t�@�C��.xls
        Dim sSaveFileNameR As String  '�_�E�����[�h��̃t�@�C����        �e�X�g�t�@�C��.xls
        Dim sSavePath As String       '���t�@�C���ۑ��t�H���_            D:\TEMP\SAVE\
        Try
            sSavePath = ConfigurationSettings.AppSettings("JA_TAN_MST_PATH")
            sSaveFileNameR = txtFileName2.Text.Trim '���t�@�C������
            'sSaveFileName = hdnKURACD.Value.Trim & "_" & hdnACBCD.Value.Trim & "_" & sSaveFileNameR '�t�@�C�������A�ײ��ĺ��ށ{���ށ{�t�@�C�����ɕϊ�
            ' 2013/07/11 T.Ono mod
            'sSaveFileName = hdnKURACD.Value.Trim & "_" & hdnM05_TANTO_HAN_CD.Value.Trim & "_" & sSaveFileNameR '�t�@�C�������A�ײ��ĺ��ށ{���ށ{�t�@�C�����ɕϊ�
            '2016/04/19 T.Ono mod 2015���P�J�� ��7 START
            'If Trim(hdnUSER_CD_FROM.Value) <> "" Then
            '    sSaveFileName = hdnKURACD.Value.Trim & "_" & hdnM05_TANTO_HAN_CD.Value.Trim & "_" & Trim(hdnUSER_CD_FROM.Value) & "_" & sSaveFileNameR '�t�@�C�������A�ײ��ĺ��ށ{���ށ{USER_CD_FROM+�t�@�C�����ɕϊ�
            'Else
            '    sSaveFileName = hdnKURACD.Value.Trim & "_" & hdnM05_TANTO_HAN_CD.Value.Trim & "_" & "X" & "_" & sSaveFileNameR '�t�@�C�������A�ײ��ĺ��ށ{���ށ{ "X" +�t�@�C�����ɕϊ�
            'End If
            sSaveFileName = hdnGROUPCD.Value.Trim & "_" & sSaveFileNameR
            '2016/04/19 T.Ono mod 2015���P�J�� ��7 END

            fncFileDownload(sSavePath, sSaveFileName, sSaveFileNameR)
        Catch ex As Exception
            Throw ex
        Finally
            Call KeepKETAIJAG00()
        End Try
    End Sub

    Private Function fncFileDownload(ByVal sSavePath As String, ByVal sSaveFileName As String, ByVal sSaveFileNameR As String) As String

        Dim dt As Byte()
        Dim sSaveFileNameS As String  '���ۂ̌��t�@�C�����i�g���q�Ȃ��j  001_999_�e�X�g�t�@�C��
        Dim fpath As String           '���t�@�C���܂ł̃t���p�X          D:\TEMP\SAVE\001_999_�e�X�g�t�@�C��.xls

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

                '2018/04/03 T.Ono mod ���k�����t�@�C�����_�E�����[�h����B�@-----START
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
                'compressC.mCompress()x
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
                '    strMsg.Append("alert('" & "�Ώۃf�[�^�����݂��܂���B[" & compressC.p_madeFilename.Replace("\", "\\") & "]');")
                '    'strMsg.Append("Form1.btnSelect.focus();") 2014/06/16 T.Ono mod btnSelect�͑��݂��Ȃ����߃G���[�ɂȂ�
                '    strMsg.Append("Form1.txtTANNM1.focus();")
                'End If
                HttpHeaderC.mDownLoadXLS(Response, sSaveFileNameR)
                Response.WriteFile(sSavePath & sSaveFileName)
                '2018/04/03 T.Ono mod ���k�����t�@�C�����_�E�����[�h����B�@-----END
            Else
                strMsg.Append("alert('" & "�Ώۃf�[�^�����݂��܂���" & "');" & vbCrLf)
                'strMsg.Append("Form1.btnSelect.focus();") 2014/06/16 T.Ono mod
                strMsg.Append("Form1.txtTANNM1.focus();")
            End If
        Finally
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
        txtFileName1.Text = ""
        txtFileName2.Text = ""

        folder = ConfigurationSettings.AppSettings("JA_TAN_MST_PATH")
        'searchPattern = hdnKURACD.Value.Trim & "_" & hdnACBCD.Value.Trim & "_"
        ' 2013/07/11 T.Ono add
        'searchPattern = hdnKURACD.Value.Trim & "_" & hdnM05_TANTO_HAN_CD.Value.Trim & "_"
        '2016/04/19 T.Ono mod 2015���P�J�� ��7 START
        'If Trim(hdnUSER_CD_FROM.Value) <> "" Then
        '    searchPattern = hdnKURACD.Value.Trim & "_" & hdnM05_TANTO_HAN_CD.Value.Trim & "_" & Trim(hdnUSER_CD_FROM.Value) & "_"
        'Else
        '    searchPattern = hdnKURACD.Value.Trim & "_" & hdnM05_TANTO_HAN_CD.Value.Trim & "_" & "X" & "_"
        'End If

        searchPattern = hdnGROUPCD.Value.Trim & "_"

        '2016/04/19 T.Ono mod 2015���P�J�� ��7 END

        Dim fs As String() = System.IO.Directory.GetFiles(folder, searchPattern & "*") 'folder�ɂ���t�@�C�����擾����
        If fs.Length > 0 Then
            buf = fs(0).Substring(fs(0).LastIndexOf("\") + 1)
            txtFileName1.Text = buf.Substring(searchPattern.Length)
        End If
        If fs.Length > 1 Then
            buf = fs(1).Substring(fs(1).LastIndexOf("\") + 1)
            txtFileName2.Text = buf.Substring(searchPattern.Length)
        End If
    End Sub

    '-------------------------------------------------
    ' �x��CD�̂���x�񖼏̂��i�[���� 2015/01/06 T.Ono add 2014���P�J�� No5
    '-------------------------------------------------
    Private Sub fncSetKMNM()
        '�x��CD�̂���x�񖼏̂��i�[����
        Dim objKMNM As System.Web.UI.HtmlControls.HtmlInputHidden

        '2016/12/12 H.Mori mod 2016���P�J�� No4-5 START
        'Dim hdnKMCD As String = ""
        'For i As Integer = 1 To 6
        '    '�x��R�[�h�擾
        '    hdnKMCD = Request.Form("hdnKMCD" & i)

        '    If hdnKMCD.Trim <> "" Then
        '        '��łȂ���΁Ahdn�փZ�b�g
        '        objKMNM = CType(FindControl("hdnKMNM" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
        '        objKMNM.Value = Request.Form("hdnKMNM" & i).Trim
        '    End If
        'Next
        '�Ή����͉�ʂŌx��ү����1��I�����Ă���ꍇ
        'If Request.Form("rdoMsg") = "1" Then  2020/03/11 T.Ono mod �Ď����P2019
        If Request.Form("hdnrdoMsg") = "1" Then
            hdnKMNM1.Value = Request.Form("hdnKMNM1")
            hdnKMNM2.Value = Request.Form("hdnKMNM2")
            hdnKMNM3.Value = Request.Form("hdnKMNM3")
            hdnKMNM4.Value = Request.Form("hdnKMNM4")
            hdnKMNM5.Value = Request.Form("hdnKMNM5")
            hdnKMNM6.Value = Request.Form("hdnKMNM6")

            objKMNM = CType(FindControl("hdnKMNM1"), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKMNM.Value = hdnKMNM1.Value
            objKMNM = CType(FindControl("hdnKMNM2"), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKMNM.Value = hdnKMNM2.Value
            objKMNM = CType(FindControl("hdnKMNM3"), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKMNM.Value = hdnKMNM3.Value
            objKMNM = CType(FindControl("hdnKMNM4"), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKMNM.Value = hdnKMNM4.Value
            objKMNM = CType(FindControl("hdnKMNM5"), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKMNM.Value = hdnKMNM5.Value
            objKMNM = CType(FindControl("hdnKMNM6"), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKMNM.Value = hdnKMNM6.Value
        End If
        '�Ή����͉�ʂŌx��ү����2��I�����Ă���ꍇ
        'If Request.Form("rdoMsg") = "2" Then 2020/03/11 T.Ono mod �Ď����P2019
        If Request.Form("hdnrdoMsg") = "2" Then
            hdnKMNM1.Value = Request.Form("hdnKMNM2")
            hdnKMNM2.Value = Request.Form("hdnKMNM1")
            hdnKMNM3.Value = Request.Form("hdnKMNM3")
            hdnKMNM4.Value = Request.Form("hdnKMNM4")
            hdnKMNM5.Value = Request.Form("hdnKMNM5")
            hdnKMNM6.Value = Request.Form("hdnKMNM6")

            objKMNM = CType(FindControl("hdnKMNM1"), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKMNM.Value = hdnKMNM1.Value
            objKMNM = CType(FindControl("hdnKMNM2"), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKMNM.Value = hdnKMNM2.Value
            objKMNM = CType(FindControl("hdnKMNM3"), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKMNM.Value = hdnKMNM3.Value
            objKMNM = CType(FindControl("hdnKMNM4"), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKMNM.Value = hdnKMNM4.Value
            objKMNM = CType(FindControl("hdnKMNM5"), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKMNM.Value = hdnKMNM5.Value
            objKMNM = CType(FindControl("hdnKMNM6"), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKMNM.Value = hdnKMNM6.Value
        End If
        '�Ή����͉�ʂŌx��ү����3��I�����Ă���ꍇ
        'If Request.Form("rdoMsg") = "3" Then 2020/03/11 T.Ono mod �Ď����P2019
        If Request.Form("hdnrdoMsg") = "3" Then
            hdnKMNM1.Value = Request.Form("hdnKMNM3")
            hdnKMNM2.Value = Request.Form("hdnKMNM1")
            hdnKMNM3.Value = Request.Form("hdnKMNM2")
            hdnKMNM4.Value = Request.Form("hdnKMNM4")
            hdnKMNM5.Value = Request.Form("hdnKMNM5")
            hdnKMNM6.Value = Request.Form("hdnKMNM6")

            objKMNM = CType(FindControl("hdnKMNM1"), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKMNM.Value = hdnKMNM1.Value
            objKMNM = CType(FindControl("hdnKMNM2"), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKMNM.Value = hdnKMNM2.Value
            objKMNM = CType(FindControl("hdnKMNM3"), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKMNM.Value = hdnKMNM3.Value
            objKMNM = CType(FindControl("hdnKMNM4"), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKMNM.Value = hdnKMNM4.Value
            objKMNM = CType(FindControl("hdnKMNM5"), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKMNM.Value = hdnKMNM5.Value
            objKMNM = CType(FindControl("hdnKMNM6"), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKMNM.Value = hdnKMNM6.Value
        End If
        '�Ή����͉�ʂŌx��ү����4��I�����Ă���ꍇ
        'If Request.Form("rdoMsg") = "4" Then Then  2020/03/11 T.Ono mod �Ď����P2019
        If Request.Form("hdnrdoMsg") = "4" Then
            hdnKMNM1.Value = Request.Form("hdnKMNM4")
            hdnKMNM2.Value = Request.Form("hdnKMNM1")
            hdnKMNM3.Value = Request.Form("hdnKMNM2")
            hdnKMNM4.Value = Request.Form("hdnKMNM3")
            hdnKMNM5.Value = Request.Form("hdnKMNM5")
            hdnKMNM6.Value = Request.Form("hdnKMNM6")

            objKMNM = CType(FindControl("hdnKMNM1"), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKMNM.Value = hdnKMNM1.Value
            objKMNM = CType(FindControl("hdnKMNM2"), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKMNM.Value = hdnKMNM2.Value
            objKMNM = CType(FindControl("hdnKMNM3"), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKMNM.Value = hdnKMNM3.Value
            objKMNM = CType(FindControl("hdnKMNM4"), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKMNM.Value = hdnKMNM4.Value
            objKMNM = CType(FindControl("hdnKMNM5"), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKMNM.Value = hdnKMNM5.Value
            objKMNM = CType(FindControl("hdnKMNM6"), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKMNM.Value = hdnKMNM6.Value
        End If
        '�Ή����͉�ʂŌx��ү����5��I�����Ă���ꍇ
        'If Request.Form("rdoMsg") = "5" Then Then  2020/03/11 T.Ono mod �Ď����P2019
        If Request.Form("hdnrdoMsg") = "5" Then
            hdnKMNM1.Value = Request.Form("hdnKMNM5")
            hdnKMNM2.Value = Request.Form("hdnKMNM1")
            hdnKMNM3.Value = Request.Form("hdnKMNM2")
            hdnKMNM4.Value = Request.Form("hdnKMNM3")
            hdnKMNM5.Value = Request.Form("hdnKMNM4")
            hdnKMNM6.Value = Request.Form("hdnKMNM6")

            objKMNM = CType(FindControl("hdnKMNM1"), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKMNM.Value = hdnKMNM1.Value
            objKMNM = CType(FindControl("hdnKMNM2"), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKMNM.Value = hdnKMNM2.Value
            objKMNM = CType(FindControl("hdnKMNM3"), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKMNM.Value = hdnKMNM3.Value
            objKMNM = CType(FindControl("hdnKMNM4"), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKMNM.Value = hdnKMNM4.Value
            objKMNM = CType(FindControl("hdnKMNM5"), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKMNM.Value = hdnKMNM5.Value
            objKMNM = CType(FindControl("hdnKMNM6"), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKMNM.Value = hdnKMNM6.Value
        End If
        '�Ή����͉�ʂŌx��ү����6��I�����Ă���ꍇ
        'If Request.Form("rdoMsg") = "6" Then 2020/03/11 T.Ono mod �Ď����P2019
        If Request.Form("hdnrdoMsg") = "6" Then
            hdnKMNM1.Value = Request.Form("hdnKMNM6")
            hdnKMNM2.Value = Request.Form("hdnKMNM1")
            hdnKMNM3.Value = Request.Form("hdnKMNM2")
            hdnKMNM4.Value = Request.Form("hdnKMNM3")
            hdnKMNM5.Value = Request.Form("hdnKMNM4")
            hdnKMNM6.Value = Request.Form("hdnKMNM5")

            objKMNM = CType(FindControl("hdnKMNM1"), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKMNM.Value = hdnKMNM1.Value
            objKMNM = CType(FindControl("hdnKMNM2"), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKMNM.Value = hdnKMNM2.Value
            objKMNM = CType(FindControl("hdnKMNM3"), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKMNM.Value = hdnKMNM3.Value
            objKMNM = CType(FindControl("hdnKMNM4"), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKMNM.Value = hdnKMNM4.Value
            objKMNM = CType(FindControl("hdnKMNM5"), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKMNM.Value = hdnKMNM5.Value
            objKMNM = CType(FindControl("hdnKMNM6"), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKMNM.Value = hdnKMNM6.Value
        End If
        '2016/12/12 H.Mori mod 2016���P�J�� No4-5 END

        Return
    End Sub
    '******************************************************************************
    '*�@�T�@�v�F
    '*�@���@�l�F2016/05/10 w.ganeko add
    '******************************************************************************
    Private Sub KeepKETAIJAG00()

        Dim rdoTel As HtmlInputRadioButton
        Dim chkMail As HtmlInputCheckBox
        Dim chkFax As HtmlInputCheckBox
        Call SetInitKETAIJAG00()

        Dim checkrdo As Integer
        checkrdo = 0
        For i As Integer = 1 To 3
            If checkrdo = 1 Then
                Exit For
            End If
            For j As Integer = 1 To 30
                rdoTel = DirectCast(FindControl("rdoTel" & i & "_" & j), HtmlInputRadioButton)
                chkMail = DirectCast(FindControl("chkMail_" & j), HtmlInputCheckBox)
                chkFax = DirectCast(FindControl("chkFax_" & j), HtmlInputCheckBox)
                If rdoTel.Checked = True Then
                    If hdnPreviewFlg.Value = "1" Then
                        'strMsg.Append("Form1.btnSoExit.disabled=false;" & vbCrLf)�@'�f�o�b�O�p
                        'strMsg.Append("Form1.btnTelHas.disabled=false;" & vbCrLf)�@'�f�o�b�O�p
                        btnSoExit.Disabled = False
                        btnTelHas.Disabled = False
                        checkrdo = 1
                        Exit For
                    End If
                    'strMsg.Append("Form1.btnSoExit.disabled=true;" & vbCrLf)
                    'strMsg.Append("Form1.btnTelHas.disabled=false;" & vbCrLf)
                    btnSoExit.Disabled = True
                    btnTelHas.Disabled = False
                    checkrdo = 1
                    Exit For
                End If
                If chkMail.Checked = True Or chkFax.Checked = True Then
                    If hdnPreviewFlg.Value = "1" Then
                        'strMsg.Append("Form1.btnSoExit.disabled=false;" & vbCrLf)
                        'strMsg.Append("Form1.btnTelHas.disabled=false;" & vbCrLf)
                        btnSoExit.Disabled = False
                        btnTelHas.Disabled = False
                        checkrdo = 1
                        Exit For
                    End If
                    'strMsg.Append("Form1.btnSoExit.disabled=true;" & vbCrLf)
                    'strMsg.Append("Form1.btnTelHas.disabled=true;" & vbCrLf)
                    btnSoExit.Disabled = True
                    btnTelHas.Disabled = True
                    checkrdo = 1
                    Exit For
                End If
            Next
        Next
        Dim strTemp As String
        Dim list As New ListItem

        strTemp = hdnFAX_TITLE_SELECT.Value()
        If strTemp <> "" Then
            list = cboFAX_TITLE.Items.FindByValue(strTemp)
            cboFAX_TITLE.SelectedIndex = cboFAX_TITLE.Items.IndexOf(list)
        End If
    End Sub
    '******************************************************************************
    '*�@�T�@�v�F
    '*�@���@�l�F2016/05/10 w.ganeko add
    '******************************************************************************
    Private Sub SetInitKETAIJAG00()
        txtACBNM.Attributes.Add("ReadOnly", "true")
        txtACBKN.Attributes.Add("ReadOnly", "true")
        txtTANNM5.Attributes.Add("ReadOnly", "true")
        txtBIKO5.Attributes.Add("ReadOnly", "true")
        txtRENTEL1_5.Attributes.Add("ReadOnly", "true")
        txtRENTEL2_5.Attributes.Add("ReadOnly", "true")
        txtRENTEL3_5.Attributes.Add("ReadOnly", "true")
        txtFAX5.Attributes.Add("ReadOnly", "true")
        txtTANNM6.Attributes.Add("ReadOnly", "true")
        txtBIKO6.Attributes.Add("ReadOnly", "true")
        txtRENTEL1_6.Attributes.Add("ReadOnly", "true")
        txtRENTEL2_6.Attributes.Add("ReadOnly", "true")
        txtRENTEL3_6.Attributes.Add("ReadOnly", "true")
        txtFAX6.Attributes.Add("ReadOnly", "true")
        txtTANNM7.Attributes.Add("ReadOnly", "true")
        txtBIKO7.Attributes.Add("ReadOnly", "true")
        txtRENTEL1_7.Attributes.Add("ReadOnly", "true")
        txtRENTEL2_7.Attributes.Add("ReadOnly", "true")
        txtRENTEL3_7.Attributes.Add("ReadOnly", "true")
        txtFAX7.Attributes.Add("ReadOnly", "true")
        txtTANNM8.Attributes.Add("ReadOnly", "true")
        txtBIKO8.Attributes.Add("ReadOnly", "true")
        txtRENTEL1_8.Attributes.Add("ReadOnly", "true")
        txtRENTEL2_8.Attributes.Add("ReadOnly", "true")
        txtRENTEL3_8.Attributes.Add("ReadOnly", "true")
        txtFAX8.Attributes.Add("ReadOnly", "true")
        txtTANNM9.Attributes.Add("ReadOnly", "true")
        txtBIKO9.Attributes.Add("ReadOnly", "true")
        txtRENTEL1_9.Attributes.Add("ReadOnly", "true")
        txtRENTEL2_9.Attributes.Add("ReadOnly", "true")
        txtRENTEL3_9.Attributes.Add("ReadOnly", "true")
        txtFAX9.Attributes.Add("ReadOnly", "true")
        txtTANNM10.Attributes.Add("ReadOnly", "true")
        txtBIKO10.Attributes.Add("ReadOnly", "true")
        txtRENTEL1_10.Attributes.Add("ReadOnly", "true")
        txtRENTEL2_10.Attributes.Add("ReadOnly", "true")
        txtRENTEL3_10.Attributes.Add("ReadOnly", "true")
        txtFAX10.Attributes.Add("ReadOnly", "true")
        txtTANNM11.Attributes.Add("ReadOnly", "true")
        txtBIKO11.Attributes.Add("ReadOnly", "true")
        txtRENTEL1_11.Attributes.Add("ReadOnly", "true")
        txtRENTEL2_11.Attributes.Add("ReadOnly", "true")
        txtRENTEL3_11.Attributes.Add("ReadOnly", "true")
        txtFAX11.Attributes.Add("ReadOnly", "true")
        txtTANNM12.Attributes.Add("ReadOnly", "true")
        txtBIKO12.Attributes.Add("ReadOnly", "true")
        txtRENTEL1_12.Attributes.Add("ReadOnly", "true")
        txtRENTEL2_12.Attributes.Add("ReadOnly", "true")
        txtRENTEL3_12.Attributes.Add("ReadOnly", "true")
        txtFAX12.Attributes.Add("ReadOnly", "true")
        txtTANNM13.Attributes.Add("ReadOnly", "true")
        txtBIKO13.Attributes.Add("ReadOnly", "true")
        txtRENTEL1_13.Attributes.Add("ReadOnly", "true")
        txtRENTEL2_13.Attributes.Add("ReadOnly", "true")
        txtRENTEL3_13.Attributes.Add("ReadOnly", "true")
        txtFAX13.Attributes.Add("ReadOnly", "true")
        txtTANNM14.Attributes.Add("ReadOnly", "true")
        txtBIKO14.Attributes.Add("ReadOnly", "true")
        txtRENTEL1_14.Attributes.Add("ReadOnly", "true")
        txtRENTEL2_14.Attributes.Add("ReadOnly", "true")
        txtRENTEL3_14.Attributes.Add("ReadOnly", "true")
        txtFAX14.Attributes.Add("ReadOnly", "true")
        txtTANNM15.Attributes.Add("ReadOnly", "true")
        txtBIKO15.Attributes.Add("ReadOnly", "true")
        txtRENTEL1_15.Attributes.Add("ReadOnly", "true")
        txtRENTEL2_15.Attributes.Add("ReadOnly", "true")
        txtRENTEL3_15.Attributes.Add("ReadOnly", "true")
        txtFAX15.Attributes.Add("ReadOnly", "true")
        txtTANNM16.Attributes.Add("ReadOnly", "true")
        txtBIKO16.Attributes.Add("ReadOnly", "true")
        txtRENTEL1_16.Attributes.Add("ReadOnly", "true")
        txtRENTEL2_16.Attributes.Add("ReadOnly", "true")
        txtRENTEL3_16.Attributes.Add("ReadOnly", "true")
        txtFAX16.Attributes.Add("ReadOnly", "true")
        txtTANNM17.Attributes.Add("ReadOnly", "true")
        txtBIKO17.Attributes.Add("ReadOnly", "true")
        txtRENTEL1_17.Attributes.Add("ReadOnly", "true")
        txtRENTEL2_17.Attributes.Add("ReadOnly", "true")
        txtRENTEL3_17.Attributes.Add("ReadOnly", "true")
        txtFAX17.Attributes.Add("ReadOnly", "true")
        txtTANNM18.Attributes.Add("ReadOnly", "true")
        txtBIKO18.Attributes.Add("ReadOnly", "true")
        txtRENTEL1_18.Attributes.Add("ReadOnly", "true")
        txtRENTEL2_18.Attributes.Add("ReadOnly", "true")
        txtRENTEL3_18.Attributes.Add("ReadOnly", "true")
        txtFAX18.Attributes.Add("ReadOnly", "true")
        txtTANNM19.Attributes.Add("ReadOnly", "true")
        txtBIKO19.Attributes.Add("ReadOnly", "true")
        txtRENTEL1_19.Attributes.Add("ReadOnly", "true")
        txtRENTEL2_19.Attributes.Add("ReadOnly", "true")
        txtRENTEL3_19.Attributes.Add("ReadOnly", "true")
        txtFAX19.Attributes.Add("ReadOnly", "true")
        txtTANNM20.Attributes.Add("ReadOnly", "true")
        txtBIKO20.Attributes.Add("ReadOnly", "true")
        txtRENTEL1_20.Attributes.Add("ReadOnly", "true")
        txtRENTEL2_20.Attributes.Add("ReadOnly", "true")
        txtRENTEL3_20.Attributes.Add("ReadOnly", "true")
        txtFAX20.Attributes.Add("ReadOnly", "true")
        txtTANNM21.Attributes.Add("ReadOnly", "true")
        txtBIKO21.Attributes.Add("ReadOnly", "true")
        txtRENTEL1_21.Attributes.Add("ReadOnly", "true")
        txtRENTEL2_21.Attributes.Add("ReadOnly", "true")
        txtRENTEL3_21.Attributes.Add("ReadOnly", "true")
        txtFAX21.Attributes.Add("ReadOnly", "true")
        txtTANNM22.Attributes.Add("ReadOnly", "true")
        txtBIKO22.Attributes.Add("ReadOnly", "true")
        txtRENTEL1_22.Attributes.Add("ReadOnly", "true")
        txtRENTEL2_22.Attributes.Add("ReadOnly", "true")
        txtRENTEL3_22.Attributes.Add("ReadOnly", "true")
        txtFAX22.Attributes.Add("ReadOnly", "true")
        txtTANNM23.Attributes.Add("ReadOnly", "true")
        txtBIKO23.Attributes.Add("ReadOnly", "true")
        txtRENTEL1_23.Attributes.Add("ReadOnly", "true")
        txtRENTEL2_23.Attributes.Add("ReadOnly", "true")
        txtRENTEL3_23.Attributes.Add("ReadOnly", "true")
        txtFAX23.Attributes.Add("ReadOnly", "true")
        txtTANNM24.Attributes.Add("ReadOnly", "true")
        txtBIKO24.Attributes.Add("ReadOnly", "true")
        txtRENTEL1_24.Attributes.Add("ReadOnly", "true")
        txtRENTEL2_24.Attributes.Add("ReadOnly", "true")
        txtRENTEL3_24.Attributes.Add("ReadOnly", "true")
        txtFAX24.Attributes.Add("ReadOnly", "true")
        txtTANNM25.Attributes.Add("ReadOnly", "true")
        txtBIKO25.Attributes.Add("ReadOnly", "true")
        txtRENTEL1_25.Attributes.Add("ReadOnly", "true")
        txtRENTEL2_25.Attributes.Add("ReadOnly", "true")
        txtRENTEL3_25.Attributes.Add("ReadOnly", "true")
        txtFAX25.Attributes.Add("ReadOnly", "true")
        txtTANNM26.Attributes.Add("ReadOnly", "true")
        txtBIKO26.Attributes.Add("ReadOnly", "true")
        txtRENTEL1_26.Attributes.Add("ReadOnly", "true")
        txtRENTEL2_26.Attributes.Add("ReadOnly", "true")
        txtRENTEL3_26.Attributes.Add("ReadOnly", "true")
        txtFAX26.Attributes.Add("ReadOnly", "true")
        txtTANNM27.Attributes.Add("ReadOnly", "true")
        txtBIKO27.Attributes.Add("ReadOnly", "true")
        txtRENTEL1_27.Attributes.Add("ReadOnly", "true")
        txtRENTEL2_27.Attributes.Add("ReadOnly", "true")
        txtRENTEL3_27.Attributes.Add("ReadOnly", "true")
        txtFAX27.Attributes.Add("ReadOnly", "true")
        txtTANNM28.Attributes.Add("ReadOnly", "true")
        txtBIKO28.Attributes.Add("ReadOnly", "true")
        txtRENTEL1_28.Attributes.Add("ReadOnly", "true")
        txtRENTEL2_28.Attributes.Add("ReadOnly", "true")
        txtRENTEL3_28.Attributes.Add("ReadOnly", "true")
        txtFAX28.Attributes.Add("ReadOnly", "true")
        txtTANNM29.Attributes.Add("ReadOnly", "true")
        txtBIKO29.Attributes.Add("ReadOnly", "true")
        txtRENTEL1_29.Attributes.Add("ReadOnly", "true")
        txtRENTEL2_29.Attributes.Add("ReadOnly", "true")
        txtRENTEL3_29.Attributes.Add("ReadOnly", "true")
        txtFAX29.Attributes.Add("ReadOnly", "true")
        txtTANNM30.Attributes.Add("ReadOnly", "true")
        txtBIKO30.Attributes.Add("ReadOnly", "true")
        txtRENTEL1_30.Attributes.Add("ReadOnly", "true")
        txtRENTEL2_30.Attributes.Add("ReadOnly", "true")
        txtRENTEL3_30.Attributes.Add("ReadOnly", "true")
        txtFAX30.Attributes.Add("ReadOnly", "true")
        txtFileName1.Attributes.Add("ReadOnly", "true")
        txtFileName2.Attributes.Add("ReadOnly", "true")
        txtSPOT_MAIL_1.Attributes.Add("ReadOnly", "true")
        txtSPOT_MAIL_2.Attributes.Add("ReadOnly", "true")
        txtSPOT_MAIL_3.Attributes.Add("ReadOnly", "true")
        txtSPOT_MAIL_4.Attributes.Add("ReadOnly", "true")
        txtSPOT_MAIL_5.Attributes.Add("ReadOnly", "true")
        txtSPOT_MAIL_6.Attributes.Add("ReadOnly", "true")
        txtSPOT_MAIL_7.Attributes.Add("ReadOnly", "true")
        txtSPOT_MAIL_8.Attributes.Add("ReadOnly", "true")
        txtSPOT_MAIL_9.Attributes.Add("ReadOnly", "true")
        txtSPOT_MAIL_10.Attributes.Add("ReadOnly", "true")
        txtSPOT_MAIL_11.Attributes.Add("ReadOnly", "true")
        txtSPOT_MAIL_12.Attributes.Add("ReadOnly", "true")
        txtSPOT_MAIL_13.Attributes.Add("ReadOnly", "true")
        txtSPOT_MAIL_14.Attributes.Add("ReadOnly", "true")
        txtSPOT_MAIL_15.Attributes.Add("ReadOnly", "true")
        txtSPOT_MAIL_16.Attributes.Add("ReadOnly", "true")
        txtSPOT_MAIL_17.Attributes.Add("ReadOnly", "true")
        txtSPOT_MAIL_18.Attributes.Add("ReadOnly", "true")
        txtSPOT_MAIL_19.Attributes.Add("ReadOnly", "true")
        txtSPOT_MAIL_20.Attributes.Add("ReadOnly", "true")
        txtSPOT_MAIL_21.Attributes.Add("ReadOnly", "true")
        txtSPOT_MAIL_22.Attributes.Add("ReadOnly", "true")
        txtSPOT_MAIL_23.Attributes.Add("ReadOnly", "true")
        txtSPOT_MAIL_24.Attributes.Add("ReadOnly", "true")
        txtSPOT_MAIL_25.Attributes.Add("ReadOnly", "true")
        txtSPOT_MAIL_26.Attributes.Add("ReadOnly", "true")
        txtSPOT_MAIL_27.Attributes.Add("ReadOnly", "true")
        txtSPOT_MAIL_28.Attributes.Add("ReadOnly", "true")
        txtSPOT_MAIL_29.Attributes.Add("ReadOnly", "true")
        txtSPOT_MAIL_30.Attributes.Add("ReadOnly", "true")
    End Sub
    '**********************************************************
    '2012/06/28 W.GANEKO ADD
    '���O�f���o��
    '�߂�l�F�������񂾃t�@�C���ւ̃t���p�X
    '**********************************************************
    Public Sub mlog(ByVal pstrString As String)
        Dim strFilnm As String = "log" & System.DateTime.Today.ToString("yyyyMMdd")
        Dim strLogPath As String = ConfigurationSettings.AppSettings("LOG_OUT_PATH")
        Dim strPath As String = strLogPath & strFilnm & ".txt"
        Dim strLogFlg As String = ConfigurationSettings.AppSettings("LOG_OUT")
        Dim linestring As New StringBuilder("")
        Dim LogC As New CLog

        Dim strRecLog As String
        If strLogFlg = "1" Then
            '�������݃t�@�C���ւ̃X�g���[��
            'Dim sw As StreamWriter
            'Dim fs As New FileStream(strPath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite)
            'linestring = New StringBuilder("")
            'linestring.Append(System.DateTime.Now & "." & System.DateTime.Now.Millisecond & "[" & AuthC.pUSERNAME & "][" & AuthC.pIPADDRESS & "][" & Me.Session.SessionID & "]" & pstrString & Chr(13) & Chr(10))
            Dim tbllog As String = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff") & " " & pstrString
            strRecLog = LogC.mAPLog(Me.Session.SessionID, AuthC.pUSERNAME, AuthC.pIPADDRESS, Request.Form("hdnMyAspx"), "4", tbllog, Request.Form)
            'sw = New StreamWriter(fs, System.Text.Encoding.Default)

            ''�����̕�������X�g���[���ɏ�������
            'sw.Write(linestring.ToString)

            ''�������t���b�V���i�t�@�C���������݁j
            ''sw.Flush()

            ''�t�@�C���N���[�Y
            'sw.Close()
            'sw.Dispose()
            'fs.Close()
            'fs.Dispose()
        End If
    End Sub
End Class
