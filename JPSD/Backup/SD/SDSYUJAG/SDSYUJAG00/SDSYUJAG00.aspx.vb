'***********************************************
' �ً}�o���m�F�E����
'***********************************************
' �ύX����
' 2009/01/09 T.Watabe �{���x����ǉ�

'<TODO>�錾���ʎd�l
Option Explicit On
Option Strict On

'<TODO>�錾���ʎd�l
Imports Common
Imports JPG.Common
Imports System.Text

Partial Class SDSYUJAG00
    Inherits System.Web.UI.Page
    Protected WithEvents txtAYMD As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtUYMD As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSIJI_BIKO1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtJUTEL As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTIZUN As System.Web.UI.WebControls.TextBox
    'Protected WithEvents txtZENKAI_HAISO As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtZENKAI_HAS_S As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtMETMAKER As System.Web.UI.WebControls.TextBox
    Protected WithEvents cboAITCD As JPG.Common.Controls.CTLCombo
    'Protected WithEvents cboASECD As JPG.Common.Controls.CTLCombo  ' 2008/10/16 T.Watabe edit
    'Protected WithEvents cboSTACD As JPG.Common.Controls.CTLCombo  ' 2008/10/16 T.Watabe edit


    '�� 2009/01/09 T.Watabe add
    '�� 2009/01/09 T.Watabe add

    Protected SDSYUJAG00_C As SDSYUJAG00
    Protected ConstC As New CConst

    Private strSYU_CD As String = ""    '�o����ЃR�[�h(�N�b�L�[���擾�����l���i�[����
    Private strKANSCD As String
    Private strSYONO As String

    '<TODO>�錾���ʎd�l
    '******************************************************************************
    ' HttpHeader
    '******************************************************************************
    Protected HttpHeaderC As New CHttpHeader

    ''<TODO>�錾���ʎd�l
    ''******************************************************************************
    '' �F�؃N���X
    ''******************************************************************************
    'Protected AuthC As CAuthenticate

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

    ' 2014/10/22 H.Hosoda del 1line 2014���P�J�� No11
    'Private strCBO_TSTANCD As String
    Private strCBO_STD_CD As String
    Private strCBO_KYOTEN_CD As String
    Private strCBO_AITCD As String
    Private strCBO_KIGCD As String
    Private strCBO_SADCD As String
    Private strCBO_ASECD As String
    Private strCBO_STACD As String
    Private strCBO_FKICD As String
    Private strCBO_HANASI As String

    '******************************************************************************
    '�o�^�n�t���[�����[�NPublic�ϐ��@�i�o�^�E�폜���Ɋi�[���܂��B�j
    '******************************************************************************
    Public gstrKBN As String
    Public gstrMyAspx As String

    Public gstrKANSCD As String                 '�č��R�[�h
    Public gstrSYONO As String                  '�����ԍ�
    Public gstrMOVE_SIJIYMD_F As String
    Public gstrMOVE_SIJIYMD_T As String
    Public gstrMOVE_KBN As String
    Public gstrMOVE_CLI_CD As String            '�N���C�A���g�R�[�h 2013/12/12 T.Ono add �Ď����P2013
    Public gstrMOVE_CLI_CD_NAME As String       '�N���C�A���g�� 2013/12/12 T.Ono add �Ď����P2013
    Public gstrMOVE_JA_CD As String             'JA�R�[�h 2013/12/12 T.Ono add �Ď����P2013
    Public gstrMOVE_JA_CD_NAME As String        'JA�� 2013/12/12 T.Ono add �Ď����P2013
    Public gstrMOVE_GROUP_CD As String          '�̔����Ǝ҃O���[�v�R�[�h 2014/10/21 H.Hosoda add �Ď����P2014 No10
    Public gstrMOVE_GROUP_CD_NAME As String     '�̔����Ǝ҃O���[�v�� 2014/10/21 H.Hosoda add �Ď����P2014 No10
    Public gstrTSTANCD As String                '��M�҃R�[�h
    Public gstrTSTANNM As String                '��M�Җ� 2014/10/23 H.Hosoda add 2014���P�J�� No11
    Public gstrSTD_CD As String                 '�o����ЃR�[�h
    Public gstrSTD_KYOTEN_CD As String          '����(���_)
    Public gstrSYUTDTNM As String               '�o���Ή���
    Public gstrJUYMD As String                  '�Ή���M�����i���t�j
    Public gstrJUTIME As String                 '�Ή���M�����i���ԁj
    Public gstrSDYMD As String                  '�o�������i���t�j 2008/10/14 T.Watabe add
    Public gstrSDTIME As String                 '�o�������i���ԁj 2008/10/14 T.Watabe add
    Public gstrTYAKYMD As String                '���������i���t�j
    Public gstrTYAKTIME As String               '���������i���ԁj
    Public gstrSYOKANYMD As String              '�����Ή����������i���t�j
    Public gstrSYOKANTIME As String             '�����Ή����������i���ԁj
    Public gstrAITCD As String                  '�Ή�����
    Public gstrMETHEIKAKU As String             '���[�^�\���Ւf�ٕ~�m�F
    Public gstrRUSUHAIRI As String              '�����\���̓\�t
    Public gstrKIGCD As String                  '�K�X����
    Public gstrSADCD As String                  '���[�^�쓮����
    Public gstrASECD As String                  '���[�^�쓮�����i���̓Z���T�[�쓮�����j
    Public gstrSTACD As String                  '���̑�����
    Public gstrFKICD As String                  '���A�Ή�
    Public gstrJAKENREN As String               '�i�`�^���A�̘A������
    Public gstrRENTIME As String                '�A������
    Public gstrKIGUTAIYO As String              '�ȈՃK�X���̑ݗ^
    Public gstrGASMUMU As String                '�K�X�R��_��
    Public gstrORGENIN As String                '�K�X�R�ꌴ��(�K�X���)
    Public gstrHAIKAN As String                 '�K�X�R�ꌴ��(�z��)
    Public gstrGASUGUMU As String               '�K�X�؂ꌴ��
    Public gstrHOSKOKAN As String               '�S���z�[�X����
    Public gstrMETYOINA As String               '���̑��_�����ځi���[�^�[�j
    Public gstrTYOUYOINA As String              '���̑��_�����ځi�����@�j
    Public gstrVALYOINA As String               '���̑��_�����ځi�e��E���ԃo���u�j
    Public gstrKYUHAIUMU As String              '���̑��_�����ځi�z�r�C���j
    Public gstrCOYOINA As String                '���̑��_�����ځi�b�n�Z�x�j
    Public gstrSDTBIK2 As String                '���L����
    Public gstrSNTTOKKI As String               '���̑����L�����i�i�`�^���A�ւ̈˗����j
    '2006/06/15 NEC ADD START
    Public gstrSDTBIK3 As String                '�o�����ʓ��e/��
    '2006/06/15 NEC ADD END
    Public gstrADD_DATE As String
    Public gstrEDT_DATE As String
    Public gstrEDT_TIME As String

    Public gstrMETFUKKI As String
    Public gstrHOAN As String
    Public gstrGASGIRE As String
    Public gstrKIGKOSYO As String
    Public gstrCSNTGEN As String
    Public gstrCSNTNGAS As String
    Public gstrSDTBIK1 As String                '���L����

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

        '2012/04/06 NEC ou Add Str
        '.NET�̎d�l�ύX�ɂ��AReadOnly������ASPX�ł���ƁA�T�[�o���Œl�̎Q�Ƃ��ł��Ȃ��Ȃ邽�߁AVB����Attribute�ł���
        If MyBase.IsPostBack = False Then
            txtKENNM.Attributes.Add("ReadOnly", "true")
            txtHAISO_NAME.Attributes.Add("ReadOnly", "true")
            txtJANM.Attributes.Add("ReadOnly", "true")
            txtSYONO.Attributes.Add("ReadOnly", "true")
            txtHATYMD.Attributes.Add("ReadOnly", "true")
            txtHATTIME.Attributes.Add("ReadOnly", "true")
            txtHATKBN.Attributes.Add("ReadOnly", "true")
            txtSIJIYMD.Attributes.Add("ReadOnly", "true")
            txtSIJITIME.Attributes.Add("ReadOnly", "true")
            txtTKTANCD_NM.Attributes.Add("ReadOnly", "true")
            txtSDNM.Attributes.Add("ReadOnly", "true")
            txtSIJI_BIKO.Attributes.Add("ReadOnly", "true")
            txtJUSYONM.Attributes.Add("ReadOnly", "true")
            txtJUSYOKN.Attributes.Add("ReadOnly", "true")
            txtKTELNO.Attributes.Add("ReadOnly", "true")
            txtADDR.Attributes.Add("ReadOnly", "true")
            txtTIZUNO.Attributes.Add("ReadOnly", "true")
            txtKMNO1.Attributes.Add("ReadOnly", "true")
            txtKMNM1.Attributes.Add("ReadOnly", "true")
            txtKMNO2.Attributes.Add("ReadOnly", "true")
            txtKMNM2.Attributes.Add("ReadOnly", "true")
            txtKMNO3.Attributes.Add("ReadOnly", "true")
            txtKMNM3.Attributes.Add("ReadOnly", "true")
            txtKMNO4.Attributes.Add("ReadOnly", "true")
            txtKMNM4.Attributes.Add("ReadOnly", "true")
            txtKMNO5.Attributes.Add("ReadOnly", "true")
            txtKMNM5.Attributes.Add("ReadOnly", "true")
            txtKMNO6.Attributes.Add("ReadOnly", "true")
            txtKMNM6.Attributes.Add("ReadOnly", "true")
            txtGAS1_HINMEI.Attributes.Add("ReadOnly", "true")
            txtGAS1_DAISU.Attributes.Add("ReadOnly", "true")
            txtGAS2_HINMEI.Attributes.Add("ReadOnly", "true")
            txtGAS2_DAISU.Attributes.Add("ReadOnly", "true")
            txtGAS3_HINMEI.Attributes.Add("ReadOnly", "true")
            txtGAS3_DAISU.Attributes.Add("ReadOnly", "true")
            txtGAS4_HINMEI.Attributes.Add("ReadOnly", "true")
            txtGAS4_DAISU.Attributes.Add("ReadOnly", "true")
            txtBONB1_KKG.Attributes.Add("ReadOnly", "true")
            txtBONB1_HON.Attributes.Add("ReadOnly", "true")
            txtBONB1_RKG.Attributes.Add("ReadOnly", "true")
            txtBONB2_KKG.Attributes.Add("ReadOnly", "true")
            txtBONB2_HON.Attributes.Add("ReadOnly", "true")
            txtBONB2_RKG.Attributes.Add("ReadOnly", "true")
            txtZENKAI_HAISO.Attributes.Add("ReadOnly", "true")
            txtZENKAI_HAI_S.Attributes.Add("ReadOnly", "true")
            txtJIKAI_HAISO.Attributes.Add("ReadOnly", "true")
            txtG_ZAIKO.Attributes.Add("ReadOnly", "true")
            txtTAITNM.Attributes.Add("ReadOnly", "true")
            txtTELRNM.Attributes.Add("ReadOnly", "true")
            txtTKIGNM.Attributes.Add("ReadOnly", "true")
            txtTSADNM.Attributes.Add("ReadOnly", "true")
            ' 2013/10/24 T.Ono �Ď����P2013��1 Start
            'txtTEL_MEMO1.Attributes.Add("ReadOnly", "true")
            'txtTEL_MEMO2.Attributes.Add("ReadOnly", "true")
            'txtFUK_MEMO.Attributes.Add("ReadOnly", "true")
            txtTEL_MEMO.Attributes.Add("ReadOnly", "true")
            ' 2013/10/24 T.Ono �Ď����P2013��1 End
            txtGENIN_KIJI.Attributes.Add("ReadOnly", "true") '2017/10/16 H.Mori add 2017���P�J�� No6-1 �R�����g����
            ' 2014/10/23 H.Hosoda add 2014���P�J�� No11 START
            txtTSTAN_CD.Attributes.Add("ReadOnly", "true")
            ' 2014/10/23 H.Hosoda add 2014���P�J�� No11 END
        End If
        '2012/04/06 NEC ou Add End

        '//------------------------------------------
        '//�@HTTP�w�b�_�𑗐M
        HttpHeaderC.mNoCache(Response)

        '//------------------------------------------
        '// Script�����ݗp�ϐ��錾
        Dim strScript As New StringBuilder("")
        Dim cscript1 As New CScript
        Dim strScriptPath As String
        strScriptPath = ConfigurationSettings.AppSettings("SCRIPTPATH")

        '------------------------------------------------------------------------------
        '�A����I�����o��
        If hdnKensaku.Value = "SDSYUJTG00" Then
            Server.Transfer("SDSYUJTG00.aspx")
        ElseIf hdnKensaku.Value = "COPOPUPG00" Then             ' 2014/10/23 H.Hosoda add 2014���P�J�� No11
            Server.Transfer("../../../Popup/COPOPUPG00.aspx")   '//�|�b�v�A�b�v�o��
        End If

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
             MyBase.MapPath("../../../SD/SDSYUJAG/SDSYUJAG00/") & "SDSYUJAG00.js"))
        '<���̓`�F�b�N�֐�>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncChk.js"))
        '<�t�H�[�J�X�֘A�֐�>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncFo.js"))
        '<���t�֘A�֐�>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncDate.js"))
        '<���Ԋ֘A�֐�>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncTime.js"))
        strScript.Append("</Script>")
        '//------------------------------------------
        '//�@Css�i�[
        strScript.Append("<Style media='print'>")
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "CssPrint.css"))
        strScript.Append("</Style>")
        strScript.Append("<Style>")
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "CssData.css"))
        strScript.Append("</Style>")
        '//------------------------------------------
        '//�@Script������
        lblScript.Text = strScript.ToString

        '//-------------------------------------------------
        '<TODO>�����̉��ID��HIDDEN��hdnMyAspx�ɏ������ށi�V�X�e�����ʁj
        hdnMyAspx.Value = "SDSYUJAG00"

        If MyBase.IsPostBack = False Then
            '//--------------------------------------
            '//���߂ĊJ�������������s�����
            strKANSCD = Request.Form("hdnKEY_KANSCD")
            strSYONO = Request.Form("hdnKEY_SYONO")
            hdnMOVE_SIJIYMD_F.Value = Request.Form("hdnMOVE_SIJIYMD_F")
            hdnMOVE_SIJIYMD_T.Value = Request.Form("hdnMOVE_SIJIYMD_T")
            hdnMOVE_KBN.Value = Request.Form("hdnMOVE_KBN")
            '2013/12/12 T.Ono add �Ď����P2013 �N���C�A���g�EJA
            hdnMOVE_CLI_CD.Value = Request.Form("hdnMOVE_CLI_CD")
            hdnMOVE_CLI_CD_NAME.Value = Request.Form("hdnMOVE_CLI_CD_NAME")
            hdnMOVE_JA_CD.Value = Request.Form("hdnMOVE_JA_CD")
            hdnMOVE_JA_CD_NAME.Value = Request.Form("hdnMOVE_JA_CD_NAME")
            ' 2014/10/21 H.Hosoda mod 2014���P�J�� No10 START
            hdnMOVE_GROUP_CD.Value = Request.Form("hdnMOVE_GROUP_CD")
            hdnMOVE_GROUP_CD_NAME.Value = Request.Form("hdnMOVE_GROUP_CD_NAME")
            ' 2014/10/21 H.Hosoda mod 2014���P�J�� No10 END

            '�X�N���[���o�[�ʒu�̕ێ�
            hdnScrollTop.Value = Request.Form("hdnScrollTop")                   '2013/12/11 T.Ono add �Ď����P2013
            '--- ��2005/05/25 ADD Falcon�� ---
            If Request.Form("hdnLOGIN_FLG") = "1" Then
                '//�Ď��Z���^�[���[�U
                strMsg.Append("Form1.btnUpd1.disabled=true;")
                strMsg.Append("Form1.btnUpd2.disabled=true;")
            Else
                strMsg.Append("Form1.btnUpd1.disabled=false;")
                strMsg.Append("Form1.btnUpd2.disabled=false;")
            End If
            '--- ��2005/05/25 ADD Falcon�� ---

            '//-------------------------------------------------
            '�f�[�^�̓Ǎ�
            Call fncDataSelect()

            '//-------------------------------------------------
            '�R���{�{�b�N�X���o�͂���
            'Call fncCombo_Create_TSTANCD()       '��M�Ҏ��� 2014/10/22 H.Hosoda del 1Line 2014���P�J�� No11
            Call fncCombo_Create_STD()            '����
            Call fncCombo_Create_SYUTDCD()        '�Ή�����
            Call fncCombo_Create_HANASI()
            Call fncCombo_Create_KIGCD()          '�K�X����
            Call fncCombo_Create_FKICD()          '���A�Ή�
            Call fncCombo_Create_SADCD()          '���[�^�쓮�����P
            'Call fncCombo_Create_ASECD()          '���[�^�쓮�����Q ' 2008/10/16 T.Watabe del
            'Call fncCombo_Create_STACD()          '���̑����� ' 2008/10/16 T.Watabe del
            '�R���{�{�b�N�X��I������
            Call fncComboSet()
            '//-------------------------------------------------

            '//--------------------------------------
            '�t�H�[�J�X���Z�b�g����
            ' 2014/10/22 H.Hosoda mod 2014���P�J�� No11 START
            'strMsg.Append("Form1.cboTSTANCD.focus();")
            strMsg.Append("Form1.btnTSTAN_CD.focus();")
            ' 2014/10/22 H.Hosoda mod 2014���P�J�� No11 END

            '//--------------------------------------
            '//0:�ʏ�o����Ё@1:�Ď��Z���^�[
            hdnLOGIN_FLG.Value = Request.Form("hdnLOGIN_FLG")
        End If
    End Sub

    '******************************************************************************
    ' �f�[�^���o
    '******************************************************************************
    Private Function fncDataSelect() As String
        Dim SQLC As New SDSYUJAG00CSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet

        Dim strRec As String
        Try
            '//�Ή����͂���̉�ʑJ�ڂ̏ꍇ
            strSQL = New StringBuilder("")
            strSQL.Append(" SELECT ")
            strSQL.Append("  D20.KENNM")
            strSQL.Append(" ,HA.HAISO_CD AS KYOCD")
            strSQL.Append(" ,HA.NAME AS KYONM")
            '2006/06/07 NEC UPDATE START
            'strSQL.Append(" ,DECODE(JANM,NULL,NULL,ACBNM,NULL,JANM,JANM||'/'||ACBNM) AS JANM")
            strSQL.Append(" ,ACBNM AS JANM")
            '2006/06/07 NEC UPDATE END
            strSQL.Append(" ,D20.SYONO")
            strSQL.Append(" ,D20.HATYMD")
            strSQL.Append(" ,D20.HATTIME")
            strSQL.Append(" ,P2.NAME AS HATKBN")
            strSQL.Append(" ,D20.SIJIYMD")
            strSQL.Append(" ,D20.SIJITIME")
            strSQL.Append(" ,D20.TKTANCD_NM")
            strSQL.Append(" ,D20.SDNM")
            strSQL.Append(" ,RTRIM(D20.SIJI_BIKO1) || RTRIM(D20.SIJI_BIKO2) AS SIJI_BIKO")
            strSQL.Append(" ,D20.JUSYONM")
            strSQL.Append(" ,D20.JUSYOKN")
            '2005/11/29 NEC UPDATE START
            'strSQL.Append(" ,D20.KTELNO")
            strSQL.Append(" ,D20.RENTEL")
            '2005/11/29 NEC UPDATE END
            strSQL.Append(" ,D20.ADDR")
            strSQL.Append(" ,D20.TIZUNO")
            ' 2014/12/26 H.Hosoda mod 2014���P�J�� No11 �ǉ��Ή� START
            'strSQL.Append(" ,D20.KMNM1")
            'strSQL.Append(" ,D20.KMNM2")
            'strSQL.Append(" ,D20.KMNM3")
            'strSQL.Append(" ,D20.KMNM4")
            'strSQL.Append(" ,D20.KMNM5")
            'strSQL.Append(" ,D20.KMNM6")
            strSQL.Append(" ,DECODE(D20.KMCD1,NULL,'',D20.KMNM1) AS KMNM1")
            strSQL.Append(" ,DECODE(D20.KMCD2,NULL,'',D20.KMNM2) AS KMNM2")
            strSQL.Append(" ,DECODE(D20.KMCD3,NULL,'',D20.KMNM3) AS KMNM3")
            strSQL.Append(" ,DECODE(D20.KMCD4,NULL,'',D20.KMNM4) AS KMNM4")
            strSQL.Append(" ,DECODE(D20.KMCD5,NULL,'',D20.KMNM5) AS KMNM5")
            strSQL.Append(" ,DECODE(D20.KMCD6,NULL,'',D20.KMNM6) AS KMNM6")
            ' 2014/12/26 H.Hosoda mod 2014���P�J�� No11 �ǉ��Ή� END
            strSQL.Append(" ,D20.GAS1_HINMEI")
            strSQL.Append(" ,DECODE(D20.GAS1_DAISU,NULL,NULL,D20.GAS1_DAISU|| '��') AS GAS1_DAISU")
            strSQL.Append(" ,D20.GAS2_HINMEI")
            strSQL.Append(" ,DECODE(D20.GAS2_DAISU,NULL,NULL,D20.GAS2_DAISU|| '��') AS GAS2_DAISU")
            strSQL.Append(" ,D20.GAS3_HINMEI")
            strSQL.Append(" ,DECODE(D20.GAS3_DAISU,NULL,NULL,D20.GAS3_DAISU|| '��') AS GAS3_DAISU")
            strSQL.Append(" ,D20.GAS4_HINMEI")
            strSQL.Append(" ,DECODE(D20.GAS4_DAISU,NULL,NULL,D20.GAS4_DAISU|| '��') AS GAS4_DAISU")
            '2006/10/24 ADD_START
            strSQL.Append(" ,D20.ZENKAI_HAISO")
            strSQL.Append(" ,D20.ZENKAI_HAI_S")
            '2006/10/24 ADD_END
            strSQL.Append(" ,D20.KONKAI_HAISO")
            strSQL.Append(" ,D20.KONKAI_HAI_S")
            strSQL.Append(" ,D20.KONKAI_HASEI")
            strSQL.Append(" ,D20.KONKAI_HAS_S")
            strSQL.Append(" ,DECODE(D20.NCU_SET,'0','��','�L') AS NCU_SET")
            strSQL.Append(" ,D20.MET_KATA")
            strSQL.Append(" ,D20.MET_MAKER")
            strSQL.Append(" ,D20.TAITNM")
            strSQL.Append(" ,D20.TELRNM")
            strSQL.Append(" ,D20.TKIGNM")
            strSQL.Append(" ,D20.TSADNM")
            strSQL.Append(" ,D20.FUK_MEMO")
            strSQL.Append(" ,D20.TEL_MEMO1")
            strSQL.Append(" ,D20.TEL_MEMO2")
            strSQL.Append(" ,D20.GENIN_KIJI")
            strSQL.Append(" ,D20.EDT_DATE")
            strSQL.Append(" ,D20.EDT_TIME")
            strSQL.Append(" ,D20.TSTANCD   ")           '��M�҃R�[�h
            strSQL.Append(" ,D20.TSTANNM   ")           '��M�Ҏ����@2014/10/22 H.Hosoda add 2014���P�J�� No11
            strSQL.Append(" ,D20.STD_CD    ")           '�o����ЃR�[�h
            strSQL.Append(" ,D20.STD_KYOTEN_CD    ")    '�o����Ћ��_�R�[�h
            strSQL.Append(" ,D20.SYUTDTNM  ")           '�o���Ή���
            '--- ��2005/05/25 MOD Falcon�� ---
            If hdnMOVE_KBN.Value = "1" Then
                '//�o���ꗗ����J�ڎ�
                strSQL.Append(" ,NVL(D20.JUYMD,TO_CHAR(SYSDATE,'YYYYMMDD')) AS JUYMD")  '�Ή���M���i�x���M���j
                strSQL.Append(" ,D20.JUTIME    ")  '�Ή������i��M�����j
                strSQL.Append(" ,D20.SDYMD ")       '�o����        2008/10/14 T.Watabe add
                strSQL.Append(" ,D20.SDTIME ")      '�o������      2008/10/14 T.Watabe add
                'strSQL.Append(" ,NVL(D20.TYAKYMD,D20.SIJIYMD) AS TYAKYMD  ")    '������   2008/10/14 T.Watabe edit �f�t�H���g�\������߂�
                'strSQL.Append(" ,NVL(D20.TYAKTIME,D20.SIJITIME) AS TYAKTIME ")  '�������� 2008/10/14 T.Watabe edit �f�t�H���g�\������߂�
                strSQL.Append(" ,D20.TYAKYMD ")     '������
                strSQL.Append(" ,D20.TYAKTIME ")    '��������
            ElseIf hdnMOVE_KBN.Value = "2" Then
                '//�o�����ʈꗗ����J�ڎ�
                strSQL.Append(" ,D20.JUYMD ")       '�Ή���M���i�x���M���j
                strSQL.Append(" ,D20.JUTIME ")      '�Ή������i��M�����j
                strSQL.Append(" ,D20.SDYMD ")       '�o����        2008/10/14 T.Watabe add
                strSQL.Append(" ,D20.SDTIME ")      '�o������      2008/10/14 T.Watabe add
                strSQL.Append(" ,D20.TYAKYMD ")     '������
                strSQL.Append(" ,D20.TYAKTIME ")    '��������
            End If
            '--- ��2005/05/25 MOD Falcon�� ---
            strSQL.Append(" ,D20.SYOKANYMD ")  '����������
            strSQL.Append(" ,D20.SYOKANTIME")  '������������
            strSQL.Append(" ,D20.AITCD     ")  '�Ή�����
            strSQL.Append(" ,D20.METHEIKAKU")  '�s�ݎ��̑[�u�@���[�^�Ւf�ٕ~�m�F 1:�L
            strSQL.Append(" ,D20.RUSUHARI  ")  '�s�ݎ��̑[�u�@�����\���̓\�t�@ 1:�L
            strSQL.Append(" ,D20.KIGCD     ")  '�����R�[�h	
            strSQL.Append(" ,D20.SADCD     ")  '�쓮�����R�[�h	
            strSQL.Append(" ,D20.ASECD     ")  '���̓Z���T�[�쓮����
            strSQL.Append(" ,D20.STACD     ")  '���̑������R�[�h
            strSQL.Append(" ,D20.FKICD     ")  '���A����R�[�h
            strSQL.Append(" ,D20.JAKENREN  ")  '�i�`�^���A�ւ̘A������
            strSQL.Append(" ,D20.RENTIME   ")  '�i�`�^���A�ւ̘A������
            strSQL.Append(" ,D20.KIGTAIYO  ")  '�ȈՃK�X���̑ݗ^�@1�F�L
            strSQL.Append(" ,NVL(D20.GASMUMU,'1') AS GASMUMU  ")    '�K�X�R��_���@0�F�L�@1�F��
            strSQL.Append(" ,NVL(D20.ORGENIN,'0') AS ORGENIN  ")    '�K�X�R��_���L�@�����@�K�X���@1:�L
            strSQL.Append(" ,NVL(D20.HAIKAN,'0') AS HAIKAN   ")     '�K�X�R��_���L�@�����@�z�ǁ@1:�L
            strSQL.Append(" ,NVL(D20.GASGUMU,'1') AS GASGUMU  ")    '�K�X�؂�m�F�@0�F�L�@1�F��
            strSQL.Append(" ,NVL(D20.HOSKOKAN,'1') AS HOSKOKAN ")   '�S���z�[�X�����@0�F���{�@1�F�����{
            strSQL.Append(" ,NVL(D20.METYOINA,'0') AS METYOINA ")   '���̑��_���@���[�^�@0�F�ǁ@1�F��
            strSQL.Append(" ,NVL(D20.TYOUYOINA,'0') AS TYOUYOINA ") '���̑��_���@������@0�F�ǁ@1�F��
            strSQL.Append(" ,NVL(D20.VALYOINA,'0') AS VALYOINA  ")  '���̑��_���@�e��E���ԃo���u�@0�F�ǁ@1�F��
            strSQL.Append(" ,NVL(D20.KYUHAIUMU,'0') AS KYUHAIUMU ") '���̑��_���@�z�r�C���@0�F�L�@1�F��
            strSQL.Append(" ,NVL(D20.COYOINA,'0') AS COYOINA  ")    '���̑��_���@�b�n�Z�x�@0�F�ǁ@1�F��
            strSQL.Append(" , DECODE(D20.METFUKKI,'1','1',DECODE(D20.HOAN,'1','2',DECODE(D20.GASGIRE,'1','3',DECODE(D20.KIGKOSYO,'1','4',DECODE(D20.CSNTGEN,'1','5','0'))))) AS HANASI  ")  '���L����
            strSQL.Append(" ,D20.SDTBIK1  ")    '���L����
            strSQL.Append(" ,D20.SDTBIK2   ")   '���L����
            strSQL.Append(" ,D20.SNTTOKKI  ")   '���̑����L����
            '2006/06/15 NEC ADD START
            strSQL.Append(" ,D20.SDTBIK3   ")   '�o�����ʓ��e/��
            '2006/06/15 NEC ADD END
            strSQL.Append(" ,D20.STD_CD  ")     '�o����ЃR�[�h
            strSQL.Append(" ,D20.KURACD ") '2008/11/05 T.Watabe add
            strSQL.Append(" ,D20.ACBCD ") '2008/11/05 T.Watabe add
            '��2009/01/09 T.Watabe add �{���x���擾
            strSQL.Append(", ")
            strSQL.Append("    D20.G_ZAIKO, ")
            strSQL.Append("    D20.ZENKAI_HAISO AS BOMV_HAISO1, ")
            strSQL.Append("    D20.ZENKAI_HAI_S AS BOMV_SISIN1, ")
            strSQL.Append("    D20.JIKAI_HAISO  AS HAISO_YOTEI, ")
            strSQL.Append("    D20.BONB1_KKG    AS BOMB_YOUKI1, ")
            strSQL.Append("    D20.BONB1_HON    AS BOMB_SUU1, ")
            strSQL.Append("    D20.BONB1_YOBI   AS BOMB_RYO1, ")
            strSQL.Append("    D20.BONB2_KKG    AS BOMB_YOUKI2, ")
            strSQL.Append("    D20.BONB2_HON    AS BOMB_SUU2, ")
            strSQL.Append("    D20.BONB2_YOBI   AS BOMB_RYO2 ")
            '��2009/01/09 T.Watabe add
            strSQL.Append(" FROM  ")
            strSQL.Append("     D20_TAIOU D20,HN2MAS JA, HAIMAS HA, M06_PULLDOWN P2")
            '��2005/05/20 MOD ------�� j.k
            'strSQL.Append(" WHERE D20.KANSCD      = :KANSCD")
            'strSQL.Append(" AND D20.SYONO         = :SYONO")
            'strSQL.Append(" AND D20.KURACD        = JA.CLI_CD")
            'strSQL.Append(" AND D20.ACBCD         = JA.HAN_CD")
            'strSQL.Append(" AND SUBSTR(JA.CLI_CD,2,2) = HA.KEN_CD")
            'strSQL.Append(" AND JA.HAISO_CD       = HA.HAISO_CD")
            'strSQL.Append(" AND '08'              = P2.KBN(+)")
            'strSQL.Append(" AND D20.HATKBN        = P2.CD(+)") 
            strSQL.Append(" WHERE")
            strSQL.Append("     D20.KANSCD = :KANSCD")
            strSQL.Append(" AND D20.SYONO = :SYONO")
            strSQL.Append(" AND D20.KURACD = JA.CLI_CD(+)")
            strSQL.Append(" AND D20.ACBCD = JA.HAN_CD(+)")
            strSQL.Append(" AND SUBSTR(JA.CLI_CD,2,2) = HA.KEN_CD(+)")
            strSQL.Append(" AND JA.HAISO_CD = HA.HAISO_CD(+)")
            strSQL.Append(" AND '08' = P2.KBN(+)")
            strSQL.Append(" AND D20.HATKBN = P2.CD(+)")
            '��2005/05/20 MOD ------�� j.k

            '�p�����[�^�̃Z�b�g
            SqlParamC.fncSetParam("KANSCD", True, strKANSCD)
            SqlParamC.fncSetParam("SYONO", True, strSYONO)

            '//SQL�̎��s
            dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

            If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
                '��2005/05/20 MOD ------�� j.k
                'If Convert.ToInt32(dbData.Tables(0).Rows.Count) = 0 Then
                '��2005/05/20 MOD ------�� j.k
                strMsg.Append("alert('�Ώۃf�[�^�����݂��܂���');")
                strRec = "ERROR"
            Else
                '//�f�[�^���o�͂��܂�
                Call fncDataSet(dbData)
                strRec = "OK"
            End If

            '--- ��2005/07/26 ADD Falcon�� ---
            If strRec = "OK" Then
                strSQL = New StringBuilder("")
                strSQL.Append(" SELECT ")
                strSQL.Append("  DECODE(SH.KESSEN,'1','�L','��') AS NCU_SET ") '�����敪�i0:������ 1:�����@2�F�H����z��(12.11�ǉ�)�@D:�폜�i�������̖��J�ʁj�j
                strSQL.Append(" FROM  SHAMAS SH, ")
                strSQL.Append("       D20_TAIOU D20 ")
                strSQL.Append(" WHERE D20.KANSCD = :KANSCD")
                strSQL.Append("   AND D20.SYONO = :SYONO")
                strSQL.Append("   AND SH.CLI_CD = D20.KURACD ")
                strSQL.Append("   AND SH.HAN_CD = D20.ACBCD")
                strSQL.Append("   AND SH.USER_CD = D20.USER_CD")

                '�p�����[�^�̃Z�b�g
                SqlParamC.fncSetParam("KANSCD", True, strKANSCD)
                SqlParamC.fncSetParam("SYONO", True, strSYONO)

                '//SQL�̎��s
                dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

                If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
                    '���p�}�X�^�ɑ��݂��Ȃ��ڋq�̏ꍇ�͖������Ɂu���v��\��
                    txtNCU_SET.Text = "��"
                Else
                    '�m�b�t�ݒu�敪
                    txtNCU_SET.Text = Convert.ToString(dbData.Tables(0).Rows(0).Item("NCU_SET"))
                End If
            End If
            '--- ��2005/07/26 ADD Falcon�� ---

        Catch ex As Exception
            Dim ErrMsgC As New CErrMsg
            strMsg.Append("alert('�V�X�e���G���[�F" & ErrMsgC.mGetArtMsg(ex.ToString) & "');")
            strRec = "ERROR"
        End Try

        'dbData.Dispose()

        Return strRec

    End Function
    '******************************************************************************
    '*�@�T�@�v�F���s�{�^���������̏���
    '*�@���@�l�F
    '******************************************************************************
    Private Sub btnUpd1_ServerClick(ByVal sender As System.Object, _
                                    ByVal e As System.EventArgs) Handles btnUpd1.ServerClick
        Call fncDataGet()
        '//--------------------------------------------------------------------------
        '<TODO>�o�^�������s��
        Server.Transfer("SDSYUJJG00.aspx")
    End Sub
    '******************************************************************************
    '*�@�T�@�v�F���s�{�^���������̏���
    '*�@���@�l�F
    '******************************************************************************
    Private Sub btnUpd2_ServerClick(ByVal sender As System.Object, _
                                    ByVal e As System.EventArgs) Handles btnUpd2.ServerClick
        Call fncDataGet()
        '//--------------------------------------------------------------------------
        '<TODO>�o�^�������s��
        Server.Transfer("SDSYUJJG00.aspx")
    End Sub
    '******************************************************************************
    '*�@�T�@�v�F�I���{�^���������̏���
    '*�@���@�l�F
    '******************************************************************************
    Private Sub btnExit_ServerClick(ByVal sender As System.Object, _
                                    ByVal e As System.EventArgs) Handles btnExit.ServerClick
        '�J�ڂ��Ă�����ʂ�ێ����A[�I���{�^��]�������ɖ߂��ʂ̐��������(VB-Transfer)
        Dim strMyAspx As String
        Dim strRes As String
        strMyAspx = Request.Form("hdnMyAspx")

        '���p�Ҍ�����ʂ���̉�ʑJ�ڂ̏ꍇ
        strMsg.Append("with(parent.Data.Form1){")
        strMsg.Append("hdnMOVE_SIJIYMD_F=" & hdnMOVE_SIJIYMD_F.Value)
        strMsg.Append("hdnMOVE_SIJIYMD_T=" & hdnMOVE_SIJIYMD_T.Value)
        strMsg.Append("}")
        strMsg.Append("location.replace('about:blank');")   '��M�t���[�������u�����N�y�[�W�ɁB

        Server.Transfer("../../../SD/SDLSTJAG/SDLSTJAG00/SDLSTJAG00.aspx")
    End Sub

    '******************************************************************************
    ' �擾�f�[�^����ʂɓ]�L
    '******************************************************************************
    Private Sub fncDataSet(ByVal pdbData As DataSet)

        Dim decKonkai_Hai_S As Decimal              '//����z�����E�w�j�ꎞ�i�[�p
        Dim decKmsin As Decimal                     '//���[�^�l�ꎞ�i�[�p�i�z��������̐���g�p�ʌv�Z���Ɏg�p�j
        Dim strG_Zaiko As String                    '//�z��������̐���g�p���ꎞ�i�[�p
        Dim strNcuSet As String                     '//�m�b�t�ڑ��ꎞ�i�[�p
        Dim decKeihosu As Decimal                   '//�x�񃁃b�Z�[�W��

        Dim DateFncC As New CDateFnc
        Dim TimeFncC As New CTimeFnc
        Dim NaNFncC As New CNaNFnc '2009/01/09 T.Watabe add

        Try
            '//--------------------------------------------------------------------------
            '<TODO>�����������s��
            '
            Dim strTemp As String
            Dim intTemp As Integer
            Dim intLoop As Integer

            '�f�[�^���������
            If Convert.ToString(pdbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then

            Else
                '�f�[�^�]�L����

                '����
                txtKENNM.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("KENNM"))
                '�z���Z���^�[
                txtHAISO_NAME.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("KYOCD")) & ":" & Convert.ToString(pdbData.Tables(0).Rows(0).Item("KYONM"))
                '�i�`�^�i�`�x��
                'txtJANM.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("JANM"))
                txtJANM.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("ACBCD")) & ":" & Convert.ToString(pdbData.Tables(0).Rows(0).Item("JANM"))
                '�����ԍ�
                txtSYONO.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("SYONO"))
                '��������
                txtHATYMD.Text = DateFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("HATYMD")))
                '��������
                txtHATTIME.Text = TimeFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("HATTIME")), 0)
                '�����敪
                txtHATKBN.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("HATKBN"))
                '�w����
                txtSIJIYMD.Text = DateFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("SIJIYMD")))
                '�w������
                txtSIJITIME.Text = TimeFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("SIJITIME")), 1)
                '�Ď��Z���^�[�S����
                txtTKTANCD_NM.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("TKTANCD_NM"))
                '�o���w�����e
                txtSDNM.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("SDNM"))
                '�o���w�����l
                txtSIJI_BIKO.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("SIJI_BIKO"))
                '���q�l����
                txtJUSYONM.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("JUSYONM"))
                '���q�l�J�i
                txtJUSYOKN.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("JUSYOKN"))
                '���d�b�ԍ�
                '2005/11/25 NEC UPDATE START
                '�����d�b���A���d�b
                'txtKTELNO.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("KTELNO"))
                txtKTELNO.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("RENTEL"))
                '2005/11/25 NEC UPDATE START
                '���Z��
                txtADDR.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("ADDR"))
                '�n�}�ԍ�
                txtTIZUNO.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("TIZUNO"))
                '�x��P
                txtKMNM1.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("KMNM1"))
                '�x��Q
                txtKMNM2.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("KMNM2"))
                '�x��R
                txtKMNM3.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("KMNM3"))
                '�x��S
                txtKMNM4.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("KMNM4"))
                '�x��T
                txtKMNM5.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("KMNM5"))
                '�x��U
                txtKMNM6.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("KMNM6"))
                '���q�l���^�K�X���P
                txtGAS1_HINMEI.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("GAS1_HINMEI"))
                '���q�l���^�K�X���P�䐔
                txtGAS1_DAISU.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("GAS1_DAISU"))
                '���q�l���^�K�X���Q
                txtGAS2_HINMEI.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("GAS2_HINMEI"))
                '���q�l���^�K�X���Q�䐔
                txtGAS2_DAISU.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("GAS2_DAISU"))
                '���q�l���^�K�X���R
                txtGAS3_HINMEI.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("GAS3_HINMEI"))
                '���q�l���^�K�X���R�䐔
                txtGAS3_DAISU.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("GAS3_DAISU"))
                '���q�l���^�K�X���S
                txtGAS4_HINMEI.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("GAS4_HINMEI"))
                '���q�l���^�K�X���S�䐔
                txtGAS4_DAISU.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("GAS4_DAISU"))
                '2006/10/24 UPD_START
                '�{���x�����i�������j
                '���{���x�����i�������j�A�{���x�����i�w�j�j�́A�O�񕪂ɍŐV��񂪐ݒ肳��Ă��邽�߁A������łȂ��O�����\������
                'txtKONKAI_HAISO.Text = DateFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("KONKAI_HAISO")))
                txtKONKAI_HAISO.Text = DateFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("ZENKAI_HAISO")))
                '�{���x�����i�w�j�j
                'txtKONKAI_HAI_S.Text = fncEditSisin(Convert.ToString(pdbData.Tables(0).Rows(0).Item("KONKAI_HAI_S")))
                txtKONKAI_HAI_S.Text = fncEditSisin(Convert.ToString(pdbData.Tables(0).Rows(0).Item("ZENKAI_HAI_S")))
                '2006/10/24 UPD_END
                '�{���x�ؑցi�������j
                txtKONKAI_HASEI.Text = DateFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("KONKAI_HASEI")))
                '�{���x�ؑցi�w�j�j
                txtKONKAI_HAS_S.Text = fncEditSisin(Convert.ToString(pdbData.Tables(0).Rows(0).Item("KONKAI_HAS_S")))
                '���[�^�^��
                txtMET_KATA.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("MET_KATA"))
                '�m�b�t
                txtNCU_SET.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("NCU_SET"))
                '���[�^���[�J�[
                txtMET_MAKER.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("MET_MAKER"))
                '�A������
                txtTAITNM.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("TAITNM"))
                '�d�b�A�����e
                txtTELRNM.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("TELRNM"))
                '�K�X����
                txtTKIGNM.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("TKIGNM"))
                '�쓮����
                txtTSADNM.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("TSADNM"))
                ' 2013/10/24 T.Ono �Ď����P2013��1 Start
                ''���l�P
                'txtFUK_MEMO.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("FUK_MEMO"))
                ''���l�Q
                'txtTEL_MEMO1.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("TEL_MEMO1"))
                ''�x��R
                'txtTEL_MEMO2.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("TEL_MEMO2"))
                txtTEL_MEMO.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("TEL_MEMO1")) & vbCrLf & _
                                    Convert.ToString(pdbData.Tables(0).Rows(0).Item("TEL_MEMO2")) & vbCrLf & _
                                    Convert.ToString(pdbData.Tables(0).Rows(0).Item("FUK_MEMO"))
                ' 2013/10/24 T.Ono �Ď����P2013��1 End
                '���q�l�L��
                txtGENIN_KIJI.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("GENIN_KIJI"))
                '��M�҃R�[�h�E��M�Ҏ���
                ' 2014/10/22 H.Hosoda mod 2014���P�J�� No11 START
                'strCBO_TSTANCD = Convert.ToString(pdbData.Tables(0).Rows(0).Item("TSTANCD"))
                If Convert.ToString(pdbData.Tables(0).Rows(0).Item("TSTANCD")) <> "" Then
                    txtTSTAN_CD.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("TSTANCD")) & " : " & _
                                       Convert.ToString(pdbData.Tables(0).Rows(0).Item("TSTANNM"))
                    hdnTSTAN_CD.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("TSTANCD"))
                    hdnTSTAN_NM.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("TSTANNM"))
                End If
                ' 2014/10/22 H.Hosoda mod 2014���P�J�� No11 END
                '�o�����
                strCBO_STD_CD = Convert.ToString(pdbData.Tables(0).Rows(0).Item("STD_CD"))
                '����
                strCBO_KYOTEN_CD = Convert.ToString(pdbData.Tables(0).Rows(0).Item("STD_KYOTEN_CD"))
                '�o���S����
                txtSYUTDNM.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("SYUTDTNM"))
                '�Ή���M����
                txtTAIO_ST_DATE.Text = DateFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("SIJIYMD")))
                '�Ή���M�����i���ԁj
                txtTAIO_ST_TIME.Text = TimeFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("SIJITIME")), 1)

                ' 2008/10/14 T.Watabe add
                '�Ή���M����
                txtSDYMD.Text = DateFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("SDYMD")))
                '�Ή���M�����i���ԁj
                txtSDTIME.Text = TimeFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("SDTIME")), 1)

                '���������i���t�j
                txtTYAKYMD.Text = DateFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("TYAKYMD")))
                '���������i���ԁj
                txtTYAKTIME.Text = TimeFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("TYAKTIME")), 1)
                '���������i���t�j
                txtSYOKANYMD.Text = DateFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("SYOKANYMD")))
                '���������i���ԁj
                txtSYOKANTIME.Text = TimeFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("SYOKANTIME")), 1)
                '�Ή�����
                strCBO_AITCD = Convert.ToString(pdbData.Tables(0).Rows(0).Item("AITCD"))
                '�s�ݎ��̑[�u�@���[�^�Ւf�ٕ~�m�F 1:�L
                If Convert.ToString(pdbData.Tables(0).Rows(0).Item("METHEIKAKU")) = "1" Then
                    chkMETHEIKAKU.Checked = True
                End If
                '�s�ݎ��̑[�u�@�����\���̓\�t�@ 1:�L
                If Convert.ToString(pdbData.Tables(0).Rows(0).Item("RUSUHARI")) = "1" Then
                    chkRUSUHAIRI.Checked = True
                End If

                '���L����()
                txtSDTBIK1.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("SDTBIK1"))
                '�����R�[�h	
                strCBO_KIGCD = Convert.ToString(pdbData.Tables(0).Rows(0).Item("KIGCD"))
                '�쓮�����R�[�h	
                strCBO_SADCD = Convert.ToString(pdbData.Tables(0).Rows(0).Item("SADCD"))
                '���̓Z���T�[�쓮����
                strCBO_ASECD = Convert.ToString(pdbData.Tables(0).Rows(0).Item("ASECD"))
                '���̑������R�[�h
                strCBO_STACD = Convert.ToString(pdbData.Tables(0).Rows(0).Item("STACD"))
                '���A����R�[�h
                strCBO_FKICD = Convert.ToString(pdbData.Tables(0).Rows(0).Item("FKICD"))
                '�i�`�^���A�ւ̘A������
                txtJAKENREN.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("JAKENREN"))
                '�i�`�^���A�ւ̘A������
                txtRENTIME.Text = TimeFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("RENTIME")), 1)
                '�ȈՃK�X���̑ݗ^�@1�F�L
                If Convert.ToString(pdbData.Tables(0).Rows(0).Item("KIGTAIYO")) = "1" Then
                    chkKIGUTAIYO.Checked = True
                End If
                '�K�X�R��_���@0�F�L�@1�F��
                If Convert.ToString(pdbData.Tables(0).Rows(0).Item("GASMUMU")) = "0" Then
                    rdoGASMUMU1.Checked = True
                    rdoGASMUMU2.Checked = False
                    '--- ��2005/04/21 ADD�@Falcon�� -----------------
                    rdoGASMUMU_H.Disabled = False
                    '--- ��2005/04/21 ADD�@Falcon�� -----------------
                Else
                    rdoGASMUMU1.Checked = False
                    rdoGASMUMU2.Checked = True
                    '--- ��2005/04/21 ADD�@Falcon�� -----------------
                    rdoGASMUMU_H.Disabled = True
                    '--- ��2005/04/21 ADD�@Falcon�� -----------------
                End If
                '�K�X�R��_���L�@�����@�K�X���@1:�L
                If Convert.ToString(pdbData.Tables(0).Rows(0).Item("ORGENIN")) = "1" Then
                    rdoGASMUMU_K.Checked = True
                    '--- ��2005/04/21 ADD�@Falcon�� -----------------
                    rdoGASMUMU_H.Checked = False
                    '--- ��2005/04/21 ADD�@Falcon�� -----------------
                Else
                    rdoGASMUMU_K.Checked = False
                    '--- ��2005/04/21 ADD�@Falcon�� -----------------
                    rdoGASMUMU_H.Checked = True
                    '--- ��2005/04/21 ADD�@Falcon�� -----------------
                End If
                '�K�X�R��_���L�@�����@�z�ǁ@�@�@1:�L
                If Convert.ToString(pdbData.Tables(0).Rows(0).Item("HAIKAN")) = "1" Then
                    rdoGASMUMU_H.Checked = True
                    '--- ��2005/04/21 ADD�@Falcon�� -----------------
                    rdoGASMUMU_K.Checked = False
                    '--- ��2005/04/21 ADD�@Falcon�� -----------------
                Else
                    rdoGASMUMU_H.Checked = False
                    '--- ��2005/04/21 ADD�@Falcon�� -----------------
                    rdoGASMUMU_K.Checked = True
                    '--- ��2005/04/21 ADD�@Falcon�� -----------------
                End If
                '�K�X�؂�m�F�@0�F�L�@1�F��
                If Convert.ToString(pdbData.Tables(0).Rows(0).Item("GASGUMU")) = "0" Then
                    rdoGASUGUMU1.Checked = True
                    rdoGASUGUMU2.Checked = False
                Else
                    rdoGASUGUMU1.Checked = False
                    rdoGASUGUMU2.Checked = True
                End If
                '�S���z�[�X�����@0�F���{�@1�F�����{
                If Convert.ToString(pdbData.Tables(0).Rows(0).Item("HOSKOKAN")) = "0" Then
                    rdoHOSKOKAN1.Checked = True
                    rdoHOSKOKAN2.Checked = False
                Else
                    rdoHOSKOKAN1.Checked = False
                    rdoHOSKOKAN2.Checked = True
                End If
                '���̑��_���@���[�^�@0�F�ǁ@1�F��
                If Convert.ToString(pdbData.Tables(0).Rows(0).Item("METYOINA")) = "0" Then
                    rdoMETYOINA1.Checked = True
                    rdoMETYOINA2.Checked = False
                Else
                    rdoMETYOINA1.Checked = False
                    rdoMETYOINA2.Checked = True
                End If
                '���̑��_���@������@0�F�ǁ@1�F��METYOINA
                If Convert.ToString(pdbData.Tables(0).Rows(0).Item("TYOUYOINA")) = "0" Then
                    rdoTYOUYOINA1.Checked = True
                    rdoTYOUYOINA2.Checked = False
                Else
                    rdoTYOUYOINA1.Checked = False
                    rdoTYOUYOINA2.Checked = True
                End If
                '���̑��_���@�e��E���ԃo���u�@0�F�ǁ@1�F��
                If Convert.ToString(pdbData.Tables(0).Rows(0).Item("VALYOINA")) = "0" Then
                    rdoVALYOINA1.Checked = True
                    rdoVALYOINA2.Checked = False
                Else
                    rdoVALYOINA1.Checked = False
                    rdoVALYOINA2.Checked = True
                End If
                '���̑��_���@�z�r�C���@0�F�L�@1�F��
                If Convert.ToString(pdbData.Tables(0).Rows(0).Item("KYUHAIUMU")) = "0" Then
                    rdoKYUHAIUMU1.Checked = True
                    rdoKYUHAIUMU2.Checked = False
                Else
                    rdoKYUHAIUMU1.Checked = False
                    rdoKYUHAIUMU2.Checked = True
                End If
                '���̑��_���@�b�n�Z�x�@0�F�ǁ@1�F��
                If Convert.ToString(pdbData.Tables(0).Rows(0).Item("COYOINA")) = "0" Then
                    rdoCOYOINA1.Checked = True
                    rdoCOYOINA2.Checked = False
                Else
                    rdoCOYOINA1.Checked = False
                    rdoCOYOINA2.Checked = True
                End If
                '���q�l�̂��b
                strCBO_HANASI = Convert.ToString(pdbData.Tables(0).Rows(0).Item("HANASI"))
                If strCBO_HANASI <> "0" Then
                    rdoHanasi1.Checked = True
                    rdoHanasi2.Checked = False
                Else
                    rdoHanasi1.Checked = False
                    rdoHanasi2.Checked = True
                End If
                '2006/06/15 NEC UPDATE START
                ''���L����()
                'txtSDTBIK2.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("SDTBIK2"))
                ''���̑����L����()
                'txtSNTTOKKI.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("SNTTOKKI"))
                ' 2013/10/25 T.Ono �Ď����P��1 Start
                '�o�����ʓ��e/��()
                'txtSDTBIK2.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("SDTBIK2"))
                'txtSNTTOKKI.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("SNTTOKKI"))
                'txtSDTBIK3.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("SDTBIK3"))
                If Convert.ToString(pdbData.Tables(0).Rows(0).Item("SDTBIK2")) & Convert.ToString(pdbData.Tables(0).Rows(0).Item("SNTTOKKI")) & _
                                        Convert.ToString(pdbData.Tables(0).Rows(0).Item("SDTBIK3")) <> "" Then
                    txtSDTBIK.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("SDTBIK2")) & vbCrLf & _
                                        Convert.ToString(pdbData.Tables(0).Rows(0).Item("SNTTOKKI")) & vbCrLf & _
                                        Convert.ToString(pdbData.Tables(0).Rows(0).Item("SDTBIK3"))
                Else
                    txtSDTBIK.Value = ""
                End If

                ' 2013/10/25 T.Ono �Ď����P��1 End
                '2006/06/15 NEC UPDATE END

                '�č��R�[�h
                hdnKEY_KANSCD.Value = strKANSCD
                '�����ԍ�
                hdnKEY_SYONO.Value = strSYONO
                '�X�V���t
                hdnEDT_DATE.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("EDT_DATE"))
                '�X�V����
                hdnEDT_TIME.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("EDT_TIME"))
                '�X�V����
                hdnSTDCD.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("STD_CD"))

                '2008/11/05 T.Watabe add
                '�N���C�A���g�R�[�h
                hdnKURACD.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("KURACD"))
                'JA�x���R�[�h
                hdnJASCD.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("ACBCD"))

                '�� 2009/01/09 T.Watabe add
                '�z��������̐���g�p��(���H
                strG_Zaiko = Convert.ToString(pdbData.Tables(0).Rows(0).Item("G_ZAIKO"))

                '�{���x�����O��z����
                txtZENKAI_HAISO.Text = fncEditDate(Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMV_HAISO1")))
                '�{���x�����O��z���w�j
                txtZENKAI_HAI_S.Text = fncEditSisin2(Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMV_SISIN1")), 1)
                '����z���\���
                txtJIKAI_HAISO.Text = fncEditDate(Convert.ToString(pdbData.Tables(0).Rows(0).Item("HAISO_YOTEI")))
                '�z��������̐���g�p��
                txtG_ZAIKO.Text = NaNFncC.mGet(strG_Zaiko, 0)
                '�{���x�P�e��j�f
                txtBONB1_KKG.Text = NaNFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMB_YOUKI1")), 0)
                '�{���x�P�ݒu�{��
                txtBONB1_HON.Text = NaNFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMB_SUU1")), 0)
                '�{���x�P�e�ʂj�f
                txtBONB1_RKG.Text = fncEditYouryou(Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMB_YOUKI1")), Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMB_SUU1")))
                '�{���x�P�e��\���t���O
                hdnBONB1_YOBI.Value = Convert.ToString(Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMB_RYO1")))
                If hdnBONB1_YOBI.Value = "1" Then
                    chkBONB1_YOBI.Checked = True    '�\���e��Ƃ��ă`�F�b�N
                Else
                    chkBONB1_YOBI.Checked = False
                End If
                '�{���x�Q�e��j�f
                txtBONB2_KKG.Text = NaNFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMB_YOUKI2")), 0)
                '�{���x�Q�ݒu�{��
                txtBONB2_HON.Text = NaNFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMB_SUU2")), 0)
                '�{���x�Q�e�ʂj�f
                txtBONB2_RKG.Text = fncEditYouryou(Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMB_YOUKI2")), Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMB_SUU2")))
                '�{���x�Q�e��\���t���O
                hdnBONB2_YOBI.Value = Convert.ToString(Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMB_RYO2")))
                If hdnBONB2_YOBI.Value = "1" Then
                    chkBONB2_YOBI.Checked = True    '�\���e��Ƃ��ă`�F�b�N
                Else
                    chkBONB2_YOBI.Checked = False
                End If
                '�� 2009/01/09 T.Watabe add
                End If
        Catch ex As Exception
            Dim ErrMsgC As New CErrMsg
            strMsg.Append("alert('�V�X�e���G���[�F" & ErrMsgC.mGetArtMsg(ex.ToString) & "');")
        End Try

    End Sub
    '******************************************************************************
    ' �擾�f�[�^����ʂɓ]�L
    '******************************************************************************
    Private Function fncDataGet() As String
        gstrMyAspx = hdnMyAspx.Value
        gstrKANSCD = hdnKEY_KANSCD.Value
        gstrSYONO = hdnKEY_SYONO.Value
        gstrKBN = hdnKBN.Value
        gstrMOVE_SIJIYMD_F = hdnMOVE_SIJIYMD_F.Value
        gstrMOVE_SIJIYMD_T = hdnMOVE_SIJIYMD_T.Value
        gstrMOVE_KBN = hdnMOVE_KBN.Value
        gstrMOVE_CLI_CD = hdnMOVE_CLI_CD.Value               '2013/12/12 T.Ono add �Ď����P2013
        gstrMOVE_CLI_CD_NAME = hdnMOVE_CLI_CD_NAME.Value     '2013/12/12 T.Ono add �Ď����P2013
        gstrMOVE_JA_CD = hdnMOVE_JA_CD.Value                 '2013/12/12 T.Ono add �Ď����P2013
        gstrMOVE_JA_CD_NAME = hdnMOVE_JA_CD_NAME.Value       '2013/12/12 T.Ono add �Ď����P2013
        gstrMOVE_GROUP_CD = hdnMOVE_GROUP_CD.Value           '2014/10/21 H.Hosoda add �Ď����P2014 No10
        gstrMOVE_GROUP_CD_NAME = hdnMOVE_GROUP_CD_NAME.Value '2014/10/21 H.Hosoda add �Ď����P2014 No10

        '��M�Җ�
        ' 2014/10/23 H.Hosoda mod 2014���P�J�� No11 START
        'gstrTSTANCD = Request.Form("cboTSTANCD")
        gstrTSTANCD = hdnTSTAN_CD.Value
        gstrTSTANNM = hdnTSTAN_NM.Value
        ' 2014/10/23 H.Hosoda mod 2014���P�J�� No11 END

        '�o����ЃR�[�h
        gstrSTD_CD = hdnSTDCD.Value
        '����
        gstrSTD_KYOTEN_CD = Request.Form("cboSTD")
        '�o���Ή���
        gstrSYUTDTNM = txtSYUTDNM.Text
        '�Ή���M�����i���t�j
        gstrJUYMD = txtTAIO_ST_DATE.Text
        '�Ή���M�����i���ԁj
        gstrJUTIME = txtTAIO_ST_TIME.Text

        ' 2008/10/14 T.Watabe add
        '�o�������i���t�j
        gstrSDYMD = txtSDYMD.Text
        '�o�������i���ԁj
        gstrSDTIME = txtSDTIME.Text

        '���������i���t�j
        gstrTYAKYMD = txtTYAKYMD.Text
        '���������i���ԁj
        gstrTYAKTIME = txtTYAKTIME.Text
        '�����Ή����������i���t�j
        gstrSYOKANYMD = txtSYOKANYMD.Text
        '�����Ή����������i���ԁj
        gstrSYOKANTIME = txtSYOKANTIME.Text
        '�Ή�����
        gstrAITCD = Request.Form("cboSYUTDCD")
        '���[�^�\���Ւf�ٕ~�m�F�i1:�L�j
        If chkMETHEIKAKU.Checked = True Then
            gstrMETHEIKAKU = "1"
        Else
            gstrMETHEIKAKU = "0"
        End If
        '�����\���̓\�t�i1:�L�j
        If chkRUSUHAIRI.Checked = True Then
            gstrRUSUHAIRI = "1"
        Else
            gstrRUSUHAIRI = "0"
        End If
        '�K�X����
        gstrKIGCD = Request.Form("cboKIGCD")
        '���[�^�쓮����
        gstrSADCD = Request.Form("cboSADCD")
        '���[�^�쓮�����i���̓Z���T�[�쓮�����j
        'gstrASECD = Request.Form("cboASECD")  ' 2008/10/16 T.Watabe edit
        gstrASECD = Request.Form("hdnASECD")
        '���̑�����
        'gstrSTACD = Request.Form("cboSTACD")  ' 2008/10/16 T.Watabe edit
        gstrSTACD = Request.Form("hdnSTACD")
        '���A�Ή�
        gstrFKICD = Request.Form("cboFKICD")

        '�i�`�^���A�̘A������
        gstrJAKENREN = txtJAKENREN.Text
        '�A������
        gstrRENTIME = txtRENTIME.Text
        '�ȈՃK�X���̑ݗ^�i1:�L�j
        If chkKIGUTAIYO.Checked = True Then
            gstrKIGUTAIYO = "1"
        Else
            gstrKIGUTAIYO = "0"
        End If

        gstrMETFUKKI = "0"
        gstrHOAN = "0"
        gstrGASGIRE = "0"
        gstrKIGKOSYO = "0"
        gstrCSNTGEN = "0"
        gstrCSNTNGAS = "0"
        '2006/06/15 NEC UPDATE START
        'gstrSDTBIK1 = ""
        gstrSDTBIK1 = txtSDTBIK1.Text
        '2006/06/15 NEC UPDATE END

        '2006/06/20 NEC UPDATE START
        'Dim strHANASI As String
        'If rdoHanasi1.Checked = True Then
        '    strHANASI = Request.Form("cboHanasi")
        '    Select Case (strHANASI)
        '        Case ("1")
        '            gstrMETFUKKI = "1"
        '        Case ("2")
        '            gstrHOAN = "1"
        '        Case ("3")
        '            gstrGASGIRE = "1"
        '        Case ("4")
        '            gstrKIGKOSYO = "1"
        '        Case ("5")
        '            gstrCSNTGEN = "1"
        '    End Select
        'Else
        '    gstrCSNTNGAS = "1"
        '    '2006/06/15 NEC UPDATE START
        '    'gstrSDTBIK1 = txtSDTBIK1.Text
        '    '2006/06/15 NEC UPDATE END
        'End If
        Dim strHANASI As String
        strHANASI = Request.Form("cboHanasi")
        Select Case (strHANASI)
            Case ("1")
                gstrMETFUKKI = "1"
            Case ("2")
                gstrHOAN = "1"
            Case ("3")
                gstrGASGIRE = "1"
            Case ("4")
                gstrKIGKOSYO = "1"
            Case ("5")
                gstrCSNTGEN = "1"
        End Select
        If rdoHanasi1.Checked = True Then
        Else
            gstrCSNTNGAS = "1"
        End If
        '2006/06/20 NEC UPDATE END

        '�K�X�R��_���i0:�L�^1:���j
        If rdoGASMUMU1.Checked = True Then
            gstrGASMUMU = "0"
            If rdoGASMUMU_K.Checked = True Then
                gstrORGENIN = "1"               '�K�X�R�ꌴ��(�K�X���)
                gstrHAIKAN = "0"                '�K�X�R�ꌴ��(�z��)
            Else
                gstrORGENIN = "0"               '�K�X�R�ꌴ��(�K�X���)
                gstrHAIKAN = "1"                '�K�X�R�ꌴ��(�z��)
            End If
        Else
            gstrGASMUMU = "1"                   '�K�X�R��_��
            gstrORGENIN = "0"                   '�K�X�R�ꌴ��(�K�X���)
            gstrHAIKAN = "0"                    '�K�X�R�ꌴ��(�z��)
        End If
        '�K�X�؂ꌴ���i0:�L�^1:���j
        If rdoGASUGUMU1.Checked = True Then
            gstrGASUGUMU = "0"
        Else
            gstrGASUGUMU = "1"
        End If
        '�S���z�[�X�����i0:���{�^1:�����{�j�j
        If rdoHOSKOKAN1.Checked = True Then
            gstrHOSKOKAN = "0"
        Else
            gstrHOSKOKAN = "1"
        End If
        '���̑��_�����ځi���[�^�[�j�i0:�ǁ^1:�ہj
        If rdoMETYOINA1.Checked = True Then
            gstrMETYOINA = "0"
        Else
            gstrMETYOINA = "1"
        End If
        '���̑��_�����ځi�����@�j�i0:�ǁ^1:�ہj
        If rdoTYOUYOINA1.Checked = True Then
            gstrTYOUYOINA = "0"
        Else
            gstrTYOUYOINA = "1"
        End If
        '���̑��_�����ځi�e��E���ԃo���u�j�i0:�ǁ^1:�ہj
        If rdoVALYOINA1.Checked = True Then
            gstrVALYOINA = "0"
        Else
            gstrVALYOINA = "1"
        End If
        '���̑��_�����ځi�z�r�C���j�i0:�ǁ^1:�ہj
        If rdoKYUHAIUMU1.Checked = True Then
            gstrKYUHAIUMU = "0"
        Else
            gstrKYUHAIUMU = "1"
        End If
        '���̑��_�����ځi�b�n�Z�x�j�i0:�ǁ^1:�ہj
        If rdoCOYOINA1.Checked = True Then
            gstrCOYOINA = "0"
        Else
            gstrCOYOINA = "1"
        End If
        '2006/06/15 NEC UPDATE START
        ''���L����
        'gstrSDTBIK2 = txtSDTBIK2.Text
        ''���̑����L�����i�i�`�^���A�ւ̈˗����j
        'gstrSNTTOKKI = txtSNTTOKKI.Text
        '�o�����ʓ��e/��
        ' 2013/10/25 T.Ono �Ď����P��1 Start
        'gstrSDTBIK2 = txtSDTBIK2.Text
        'gstrSNTTOKKI = txtSNTTOKKI.Text
        'gstrSDTBIK3 = txtSDTBIK3.Text
        gstrSDTBIK2 = hdnSDTBIK2.Value      '1�s��
        gstrSNTTOKKI = hdnSNTTOKKI.Value    '2�s��
        gstrSDTBIK3 = hdnSDTBIK3.Value      '3�s��
        ' 2013/10/25 T.Ono �Ď����P��1 End

        '2006/06/15 NEC UPDATE END

        gstrEDT_DATE = hdnEDT_DATE.Value
        gstrEDT_TIME = hdnEDT_TIME.Value


    End Function
    '******************************************************************************
    '*�@�T�@�v�F�w�j���o�͎��Ɏg�p�i�Ō�P���������ȉ��Ƃ���j
    '*�@���@�l�F���������l�̏ꍇ�̂݁A���l�łȂ��ꍇ�͂��̂܂܂̒l��Ԃ�
    '******************************************************************************
    Private Function fncEditSisin(ByVal strSisin As String) As String
        Dim strRec As String
        Dim NaNFncC As New CNaNFnc
        If IsNumeric(strSisin) = True Then
            If strSisin.Length = 0 Then
                strRec = ""
            ElseIf strSisin.Length = 1 Then
                strRec = "0." & strSisin
            Else
                strRec = strSisin
                strRec = Left(strRec, strRec.Length - 1) & "." & Right(strRec, 1)
                strRec = NaNFncC.mGet(strRec, 1)
            End If
        Else
            strRec = strSisin
        End If

        Return strRec
    End Function

    '******************************************************************************
    '*�@�T�@�v�F�w�j���o�͎��Ɏg�p�i�E���琔�����ꍇ�̌����������ȉ������Ƃ���j
    '*�@���@�l�F���������l�̏ꍇ�̂݁A���l�łȂ��ꍇ�͂��̂܂܂̒l��Ԃ�
    '******************************************************************************
    '2005/11/22 NEC UPDATE JPG.KETAIJAG00����ڐA
    Private Function fncEditSisin2(ByVal strSisin As String, ByVal intKeta As Integer) As String
        Dim strRec As String
        Dim NaNFncC As New CNaNFnc
        If IsNumeric(strSisin) = True Then
            If strSisin.Length = 0 Then
                strRec = ""
                '�����_���܂܂�Ă����炻�̂܂ܒl��Ԃ�
            ElseIf InStr(strSisin, ".") > 0 Then
                strRec = strSisin
            ElseIf strSisin.Length = 1 Then
                strRec = Convert.ToString(Convert.ToDecimal(strSisin) / 10D ^ Convert.ToDecimal(intKeta))
            Else
                '�[������
                strRec = strSisin.PadLeft(8 - strSisin.Length, "0"c)
                strRec = Left(strRec, strRec.Length - intKeta) & "." & Right(strRec, intKeta)
                If intKeta = 1 Then
                    strRec = Format(Convert.ToDecimal(strRec), "##,###,##0.0")
                ElseIf intKeta = 3 Then
                    strRec = Format(Convert.ToDecimal(strRec), "##,###,##0.000")
                End If
            End If
        Else
            strRec = strSisin
        End If

        Return strRec
    End Function

    '2009/01/09 T.Watabe add
    '******************************************************************************
    '*�@�T�@�v�F�z�������o�͎��Ɏg�p
    '*�@���@�l�F���t�̏ꍇ�͕ϊ��ȊO�͂��̂܂܏o��
    '******************************************************************************
    Private Function fncEditDate(ByVal strDate As String) As String
        Dim strRec As String
        Dim strFlg As String
        '���t�`�F�b�N
        If strDate.Length = 8 Then
            strRec = strDate.Substring(0, 4) & "/" & strDate.Substring(4, 2) & "/" & strDate.Substring(6, 2)
            If IsDate(strRec) = True Then
                strFlg = "1"
            Else
                strFlg = "0"
            End If
        Else
            strFlg = "0"
        End If
        '���t�łȂ��ꍇ�͂��̂܂܂̒l���Z�b�g
        If strFlg = "0" Then
            strRec = strDate
        End If

        Return strRec
    End Function

    '2009/01/09 T.Watabe add
    '******************************************************************************
    '*�@�T�@�v�F�e�ʌv�Z���Ɏg�p
    '*�@���@�l�F�e��Ɩ{�����e�ʂ����߂�
    '******************************************************************************
    Private Function fncEditYouryou(ByVal strYouki As String, ByVal strHonsu As String) As String
        Dim strRec As String
        Dim NaNFncC As New CNaNFnc

        '�����ꂩ�������Ă��Ȃ��ꍇ�A�������͐��l�łȂ��ꍇ�͌v�Z���Ȃ�()
        If (strYouki.Length = 0 Or strHonsu.Length = 0) Or _
           (IsNumeric(strYouki) = False Or IsNumeric(strHonsu) = False) Then
            strRec = ""
        Else
            strRec = Convert.ToString(Convert.ToDecimal(strYouki) * Convert.ToDecimal(strHonsu))
            strRec = NaNFncC.mGet(strRec, 0)
        End If

        Return strRec
    End Function

    '******************************************************************************
    '*�@�T�@�v�F�R���{�{�b�N�X�̑I��
    '*�@���@�l�F
    '******************************************************************************
    Private Sub fncComboSet()
        Dim list As New ListItem

        ' 2014/10/22 H.Hosoda del 2014���P�J�� No11 START
        '��M�Ҏ���
        'If strCBO_TSTANCD <> "" Then
        '    list = cboTSTANCD.Items.FindByValue(strCBO_TSTANCD)
        '    cboTSTANCD.SelectedIndex = cboTSTANCD.Items.IndexOf(list)
        'End If
        ' 2014/10/22 H.Hosoda del 2014���P�J�� No11 END

        '����
        If strCBO_KYOTEN_CD <> "" Then
            list = cboSTD.Items.FindByValue(strCBO_KYOTEN_CD)
            cboSTD.SelectedIndex = cboSTD.Items.IndexOf(list)
        End If
        '�Ή�����R�[�h
        If strCBO_AITCD <> "" Then
            list = cboSYUTDCD.Items.FindByValue(strCBO_AITCD)
            cboSYUTDCD.SelectedIndex = cboSYUTDCD.Items.IndexOf(list)
        End If
        '�Ή�����R�[�h
        If strCBO_HANASI <> "" Then
            list = cboHanasi.Items.FindByValue(strCBO_HANASI)
            cboHanasi.SelectedIndex = cboHanasi.Items.IndexOf(list)
        End If
        '�����R�[�h	
        If strCBO_KIGCD <> "" Then
            list = cboKIGCD.Items.FindByValue(strCBO_KIGCD)
            cboKIGCD.SelectedIndex = cboKIGCD.Items.IndexOf(list)
        End If
        '�쓮�����R�[�h	
        If strCBO_SADCD <> "" Then
            list = cboSADCD.Items.FindByValue(strCBO_SADCD)
            cboSADCD.SelectedIndex = cboSADCD.Items.IndexOf(list)
        End If
        '���̓Z���T�[�쓮���� ' 2008/10/16 T.Watabe del
        'If strCBO_ASECD <> "" Then
        '    list = cboASECD.Items.FindByValue(strCBO_ASECD)
        '    cboASECD.SelectedIndex = cboASECD.Items.IndexOf(list)
        'End If
        '���̑������R�[�h ' 2008/10/16 T.Watabe del
        'If strCBO_STACD <> "" Then
        '    list = cboSTACD.Items.FindByValue(strCBO_STACD)
        '    cboSTACD.SelectedIndex = cboSTACD.Items.IndexOf(list)
        'End If
        '���A����R�[�h
        If strCBO_FKICD <> "" Then
            list = cboFKICD.Items.FindByValue(strCBO_FKICD)
            cboFKICD.SelectedIndex = cboFKICD.Items.IndexOf(list)
        End If

    End Sub
    ' 2014/10/22 H.Hosoda del 2014���P�J�� No11 START
    '//-------------------------------------------------
    '// ��M�Ҏ���
    '//-------------------------------------------------
    'Private Sub fncCombo_Create_TSTANCD()
    '    cboTSTANCD.pComboTitle = True
    '    cboTSTANCD.pNoData = False
    '    cboTSTANCD.pType = "SHUTUTAN"                   '//��M�Ҏ���
    '    cboTSTANCD.pAllShutuCd = strCBO_STD_CD
    '    cboTSTANCD.mMakeCombo()
    'End Sub
    ' 2014/10/22 H.Hosoda del 2014���P�J�� No11 END
    '//-------------------------------------------------
    '// ����
    '//-------------------------------------------------
    Private Sub fncCombo_Create_STD()
        cboSTD.pComboTitle = True
        cboSTD.pNoData = False
        cboSTD.pType = "SYUSYOZOKU"                     '//����
        cboSTD.pAllShutuCd = strCBO_STD_CD
        cboSTD.mMakeCombo()
    End Sub
    '//-------------------------------------------------
    '// �Ή�����
    '//-------------------------------------------------
    Private Sub fncCombo_Create_SYUTDCD()
        cboSYUTDCD.pComboTitle = True
        cboSYUTDCD.pNoData = False
        cboSYUTDCD.pType = "SYUTAIOUAITE"               '//�Ή�����
        cboSYUTDCD.mMakeCombo()
    End Sub
    '//-------------------------------------------------
    '// ���q�l�b
    '//-------------------------------------------------
    Private Sub fncCombo_Create_HANASI()
        cboHanasi.pComboTitle = True
        cboHanasi.pNoData = False
        cboHanasi.pType = "SYUGASUKAN"                  '//���q�l�b
        cboHanasi.mMakeCombo()
    End Sub
    '//-------------------------------------------------
    '// �K�X����
    '//-------------------------------------------------
    Private Sub fncCombo_Create_KIGCD()
        cboKIGCD.pComboTitle = False
        cboKIGCD.pNoData = False
        cboKIGCD.pType = "SYUGASUGEN"                   '//�K�X����
        cboKIGCD.mMakeCombo()
    End Sub
    '//-------------------------------------------------
    '// ���A�Ή�
    '//-------------------------------------------------
    Private Sub fncCombo_Create_FKICD()
        cboFKICD.pComboTitle = False
        cboFKICD.pNoData = False
        cboFKICD.pType = "SYUHUKKITAI"                  '//���A�Ή�
        cboFKICD.mMakeCombo()
    End Sub
    '//-------------------------------------------------
    '// ���[�^�����P
    '//-------------------------------------------------
    Private Sub fncCombo_Create_SADCD()
        cboSADCD.pComboTitle = False
        cboSADCD.pNoData = False
        cboSADCD.pType = "SYUMETAGEN1"                  '//���[�^�����P
        cboSADCD.mMakeCombo()
    End Sub
    ' 2008/10/16 T.Watabe del
    '//-------------------------------------------------
    '// ���[�^�����Q
    '//-------------------------------------------------
    'Private Sub fncCombo_Create_ASECD()
    '    cboASECD.pComboTitle = False
    '    cboASECD.pNoData = False
    '    cboASECD.pType = "SYUMETAGEN2"                  '//���[�^�����Q
    '    cboASECD.mMakeCombo()
    'End Sub
    ' 2008/10/16 T.Watabe del
    '//-------------------------------------------------
    '// ���̑�����
    '//-------------------------------------------------
    'Private Sub fncCombo_Create_STACD()
    '    cboSTACD.pComboTitle = False
    '    cboSTACD.pNoData = False
    '    cboSTACD.pType = "SYUSONOTAGEN"                 '//���̑�����
    '    cboSTACD.mMakeCombo()
    'End Sub

    '******************************************************************************
    '*�@�T�@�v�F���O�C�����[�U�[����Ԃ��v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pLOGIN_USER() As String
        Get
            Return Convert.ToString(Request.Cookies(ConstC.pCookie_SD_Logincd).Value)
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F���O�C�����[�U�[��IPADDRESS��Ԃ��v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pLOGIN_IPADDRESS() As String
        Get
            Return Request.ServerVariables("REMOTE_ADDR")
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�FMyAspx��Ԃ��v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pMY_ASPX() As String
        Get
            Return hdnMyAspx.Value
        End Get
    End Property


    '******************************************************************************
    '*�@�T�@�v�F
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pPRAM_KURACD() As String
        Get
            Return hdnKURACD.Value
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pPRAM_JASCD() As String
        Get
            Return hdnJASCD.Value
        End Get
    End Property


    '******************************************************************************
    '*�@�T�@�v�FhdnKEY_KANSCD�擾�v���p�e�B�i2013/07/01 T.Ono add�j
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pPRAM_KANSCD() As String
        Get
            Return hdnKEY_KANSCD.Value
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�FhdnKEY_SYONO�擾�v���p�e�B�i2013/07/01 T.Ono add�j
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pPRAM_SYONO() As String
        Get
            Return hdnKEY_SYONO.Value
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�i���ݏ�����n���v���p�e�B1�@2014/10/23 H.Hosoda add 2014���P�J�� No11
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pCode1() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = hdnSTDCD.Value
                Case Else
                    strRec = ""
            End Select
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�i���ݏ�����n���v���p�e�B2�@2014/10/23 H.Hosoda add 2014���P�J�� No11
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pCode2() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = ""
                Case Else
                    strRec = ""
            End Select
            Return strRec
        End Get
    End Property


    '******************************************************************************
    '*�@�T�@�v�F�o�͂���ꗗ�̖��O��n���v���p�e�B�@2014/10/23 H.Hosoda add 2014���P�J�� No11
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pListName() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = "�o����ВS���҈ꗗ"
                Case Else
                    strRec = ""
            End Select
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�o�͂���ꗗ�𐧌䂷��l��n���v���p�e�B�@2014/10/23 H.Hosoda add 2014���P�J�� No11
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pListCd() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = "TSTANCD"
                Case Else
                    strRec = ""
            End Select
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�R�[�h��Ԃ��I�u�W�F�N�g�̖��O�l��n���v���p�e�B�@2014/10/23 H.Hosoda add 2014���P�J�� No11
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pBackCode() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = "hdnTSTAN_CD"
                Case Else
                    strRec = ""
            End Select
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F���̂�Ԃ��I�u�W�F�N�g�̖��O�l��n���v���p�e�B�@2014/10/23 H.Hosoda add 2014���P�J�� No11
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pBackName() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = "txtTSTAN_CD"
                Case Else
                    strRec = ""
            End Select
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F���݂̂̂�Ԃ��I�u�W�F�N�g�̖��O�l��n���v���p�e�B�@2014/10/30 H.Hosoda add 2014���P�J�� No11
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pBackNameOnly() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = "hdnTSTAN_NM"
                Case Else
                    strRec = ""
            End Select
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�t�H�[�J�X��Ԃ��I�u�W�F�N�g�̖��O�l��n���v���p�e�B�@2014/10/23 H.Hosoda add 2014���P�J�� No11
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pBackFocs() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = "btnTSTAN_CD"
                Case Else
                    strRec = ""
            End Select

            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�i�`���ύX���ꂽ���ɃN���A����I�u�W�F�N�g�̖��O�l��n���v���p�e�B�P�@2014/10/23 H.Hosoda add 2014���P�J�� No11
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pClearName() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = ""
                Case Else
                    strRec = ""
            End Select
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�i�`���ύX���ꂽ���ɃN���A����I�u�W�F�N�g�̖��O�l��n���v���p�e�B�P�@2014/10/23 H.Hosoda add 2014���P�J�� No11
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pClearCode() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = ""
                Case Else
                    strRec = ""
            End Select
            Return strRec
        End Get
    End Property

End Class
