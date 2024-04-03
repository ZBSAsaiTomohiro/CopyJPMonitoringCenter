'***********************************************
'�ً}���Ď��Ɩ���s�ݒ�  ���C�����
'***********************************************
Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common
Imports JPG.Common.log  '�F�Q�Ɛݒ��COCOLOGC00��ݒ肷��

Imports System.Text
Imports System.Configuration

Partial Class SYDIKJAG00
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
    Dim strKANSCD As String         '�Ď��Z���^�[�R�[�h
    Dim strDAIKOKANSCD As String    '��s�Ď��Z���^�[�R�[�h

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

        '//------------------------------------------
        '//�@HTTP�w�b�_�𑗐M
        HttpHeaderC.mNoCache(Response)

        '//------------------------------------------
        '//�@�F�؃N���X�̃C���X�^���X����
        AuthC = New CAuthenticate(Request, Response)

        '//------------------------------------------
        '//�@�F�؏���
        '<TODO>�F�g�p�\�������w�肷��
        '[�Ď���s]�g�p�\����(�^:��/�c:�~/��:��/�o:�~)
        AuthC.fncAuthCheck(Server, AuthC.pGROUP_UNKOU & "," & AuthC.pGROUP_KANSHI)

        '�X�V����
        If hdnKensaku.Value = "SYDIKJJG00" Then
            Server.Transfer("SYDIKJJG00.aspx")
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
             MyBase.MapPath("../../../SY/SYDIKJAG/SYDIKJAG00/") & "SYDIKJAG00.js"))
        '<�t�H�[�J�X�֘A�֐�>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncFo.js"))

        strScript.Append("</Script>")
        '//------------------------------------------
        '//�@Css�i�[
        strScript.Append("<Style>")
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "CssData.css"))
        strScript.Append("</Style>")
        '//------------------------------------------
        '//�@Script������
        lblScript.Text = strScript.ToString

        '//------------------------------------------
        '�R���{�{�b�N�X�̍쐬
        '<TODO>�R���{�{�b�N�X�̍쐬Function��Call����
        Call fncCreateCombo()
        '//------------------------------------------

        '//------------------------------------------------------------------------------
        If MyBase.IsPostBack = False Then
            '//--------------------------------------
            '//�@���߂ĊJ�������������s�����

            '//--------------------------------------
            '�����\���Ƃ��ĕK�v�ȃR���g���[���̐ݒ���s���܂�
            Call fncIni_format()    '//�l�̏�����

            '<TODO>�t�H�[�J�X���Z�b�g����
            strMsg.Append("Form1.cboKANSCD.focus();")

        Else
            '//--------------------------------------
            '//�Q��ڈȍ~���s�����
            '//--------------------------------------

            '<TODO>�R���{�{�b�N�X�g�p���A�l�I����Function��Call����
            Call fncSelectCombo()
        End If

        '//-------------------------------------------------
        '<TODO>�����̉��ID��HIDDEN��hdnMyAspx�ɏ������ށi�V�X�e�����ʁj
        hdnMyAspx.Value = "SYDIKJAG00"
        '//-------------------------------------------------

    End Sub

    '******************************************************************************
    '*�@�T�@�v�F�R���{�{�b�N�X�̑I��
    '*�@���@�l�F
    '******************************************************************************
    Private Sub fncSelectCombo()
        Dim list As New ListItem
        '//<TODO>�R���{�{�b�N�X��I����Ԃɂ���

        If strKANSCD <> "" Then
            list = cboKANSCD.Items.FindByValue(strKANSCD)
            cboKANSCD.SelectedIndex = cboKANSCD.Items.IndexOf(list)
        End If
        If strDAIKOKANSCD <> "" Then
            list = cboDAIKOKANSCD.Items.FindByValue(strDAIKOKANSCD)
            cboDAIKOKANSCD.SelectedIndex = cboDAIKOKANSCD.Items.IndexOf(list)
        End If

    End Sub

    '******************************************************************************
    '* POST�f�[�^�̎擾�ϐ��̏�����
    '******************************************************************************
    Private Sub fncGetPostIni()
        '//--------------------------------------------------------------------------
        '<TODO>��ʃR���g���[�����e���i�[�����ϐ�������������
        strKANSCD = ""
        strDAIKOKANSCD = ""
    End Sub

    '******************************************************************************
    '* HTTPPOST�f�[�^�擾
    '******************************************************************************
    Private Sub fncGetPost()
        '//--------------------------------------------------------------------------
        '<TODO>��ʃR���g���[���̓��e��ϐ��Ɋi�[����
        '//     �R���{�{�b�N�X��XYZ����t�̕ϊ����͂��̉ӏ��ōs��

        strKANSCD = Request.Form("cboKANSCD")
        strDAIKOKANSCD = Request.Form("cboDAIKOKANSCD")
    End Sub

    '******************************************************************************
    '* �e�R���g���[���̐ݒ�l�̏�����
    '******************************************************************************
    Private Sub fncIni_format()

        '�R���{�쐬
        Call fncCombo_Creatr_KANSI_CD()         '�Ď��Z���^�[�R���{
        Call fncCombo_Create_DAI_KANSI_CD()     '��s�Ď��Z���^�[�R���{

        cboKANSCD.SelectedIndex = 0
        cboDAIKOKANSCD.SelectedIndex = 0

    End Sub

    '******************************************************************************
    '*�@�T�@�v�F�R���{�{�b�N�X�쐬
    '*�@���@�l�F
    '******************************************************************************
    Private Sub fncCreateCombo()
        '//--------------------------------------------------------------------------
        '<TODO>�R���{�{�b�N�X���쐬����t�@���N�V������Call����
        Call fncCombo_Creatr_KANSI_CD()         '�Ď��Z���^�[�R���{
        Call fncCombo_Create_DAI_KANSI_CD()     '��s�Ď��Z���^�[�R���{
    End Sub

    '******************************************************************************
    '�R���{�{�b�N�X�̍쐬
    '******************************************************************************
    Private Sub fncCombo_Creatr_KANSI_CD()
        '//�Ď��Z���^�[�R���{
        cboKANSCD.pComboTitle = True
        cboKANSCD.pNoData = False
        cboKANSCD.pType = "KANSICENTER"

        '--- ��2005/04/19 DEL�@Falcon�� -----------------
        '���k�E�����{�E�����{�̊Ď��Z���^�[���o��
        'Dim strALLCENTERCD As String = "" & _
        '    ConfigurationSettings.AppSettings("KANSHICD_TOUHOKU") & "," & _
        '    ConfigurationSettings.AppSettings("KANSHICD_NAKANIHON") & "," & _
        '    ConfigurationSettings.AppSettings("KANSHICD_NISHINIHON")
        '--- ��2005/04/19 DEL Falcon�� ------------------

        '--- ��2005/04/19 MOD�@Falcon�� -----------------
        Dim strALLCENTERCD As String = ConfigurationSettings.AppSettings("GROUP_KANSHICD")
        '--- ��2005/04/19 MOD Falcon�� ------------------

        cboKANSCD.pAllCenterCd = strALLCENTERCD
        cboKANSCD.mMakeCombo()
    End Sub

    Private Sub fncCombo_Create_DAI_KANSI_CD()
        '//��s�Ď��Z���^�[�R���{
        cboDAIKOKANSCD.pComboTitle = True
        cboDAIKOKANSCD.pNoData = False
        cboDAIKOKANSCD.pType = "KANSICENTER"

        '--- ��2005/04/19 DEL�@Falcon�� -----------------
        '���k�E�����{�E�����{�̊Ď��Z���^�[���o��
        'Dim strALLCENTERCD As String = "" & _
        '    ConfigurationSettings.AppSettings("KANSHICD_TOUHOKU") & "," & _
        '    ConfigurationSettings.AppSettings("KANSHICD_NAKANIHON") & "," & _
        '    ConfigurationSettings.AppSettings("KANSHICD_NISHINIHON")
        '--- ��2005/04/19 DEL Falcon�� ------------------

        '--- ��2005/04/19 MOD�@Falcon�� -----------------
        Dim strALLCENTERCD As String = ConfigurationSettings.AppSettings("GROUP_KANSHICD")
        '--- ��2005/04/19 MOD Falcon�� ------------------

        cboDAIKOKANSCD.pAllCenterCd = strALLCENTERCD
        cboDAIKOKANSCD.mMakeCombo()
    End Sub

    '*****************************************************************************
    '*��s�ݒ�{�^���������̏���
    '*****************************************************************************
    Private Sub btnSET_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSET.ServerClick

        Dim strCNT As String
        Dim dbData As DataSet

        Try
            dbData = fncDataSelect()
            strCNT = Convert.ToString(dbData.Tables(0).Rows(0).Item("CNT"))
            dbData.Dispose()

            If strCNT = "0" Then
                strMsg.Append("strRes=confirm('��s�ݒ���s���ƃV�X�e���S�̂̋Ɩ��ɉe�����y�т܂��B��s�ݒ���s���܂����H');")
                strMsg.Append("if (strRes==false){")
                strMsg.Append("Form1.btnSET.focus();")
                strMsg.Append("} else {")
                strMsg.Append("fncDispRoc();")
                strMsg.Append("doSubmit('SYDIKJJG00');")
                strMsg.Append("}")
            Else
                strMsg.Append("strRes=confirm('���ɑ�s�ݒ肪�s���Ă��܂��B��s�ݒ���s���܂����H');")
                strMsg.Append("if (strRes==false){")
                strMsg.Append("Form1.btnSET.focus();")
                strMsg.Append("} else {")
                strMsg.Append("fncDispRoc();")
                strMsg.Append("doSubmit('SYDIKJJG00');")
                strMsg.Append("}")
            End If

        Catch ex As Exception
            Dim ErrMsgC As New CErrMsg
            strMsg.Append("alert('�V�X�e���G���[�F" & ErrMsgC.mGetArtMsg(ex.ToString) & "');")
        End Try
    End Sub

    '*****************************************************************************
    '*��s�����{�^���������̏���
    '*****************************************************************************
    Private Sub btnCANCEL_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCANCEL.ServerClick

        Dim strCNT As String
        Dim strRecMsg As String
        Dim dbData As DataSet

        Try
            dbData = fncDataSelect()
            strCNT = Convert.ToString(dbData.Tables(0).Rows(0).Item("CNT"))
            dbData.Dispose()

            If strCNT = "0" Then
                '��s�������s���f�[�^�Ȃ�
                strRecMsg = "��s�ݒ肳��Ă��܂���"
                strMsg.Append("alert('" & strRecMsg & "');")

                '//----------------------------------
                '<TODO>�t�H�[�J�X���Z�b�g����
                strMsg.Append("Form1.cboKANSCD.focus();")
            Else
                '�X�V����
                strMsg.Append("fncDispRoc();")
                strMsg.Append("doSubmit('SYDIKJJG00');")
            End If

        Catch ex As Exception
            Dim ErrMsgC As New CErrMsg
            strMsg.Append("alert('�V�X�e���G���[�F" & ErrMsgC.mGetArtMsg(ex.ToString) & "');")
        End Try

    End Sub

    '******************************************************************************
    '*�@�T�@�v�F�Ď��Z���^�[�R�[�h
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pKANSCD() As String
        Get
            Return Request.Form("cboKANSCD")
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F��s�Ď��Z���^�[�R�[�h
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pDAIKOKANSCD() As String
        Get
            Return Request.Form("cboDAIKOKANSCD")
        End Get
    End Property

    '******************************************************************************
    '* �f�[�^�̌������s���܂��B
    '******************************************************************************
    Private Function fncDataSelect() As DataSet

        '//------------------------------------------
        '//<TODO>Select���̍쐬
        Dim SQLC As New SYDIKJAG00CCSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet

        strSQL.Append("SELECT ")
        strSQL.Append("COUNT(*) AS CNT ")
        strSQL.Append("FROM  S01_DAIKO ")
        strSQL.Append("WHERE KANSCD  = :KANSCD ")

        '�������o�C���h����
        SqlParamC.fncSetParam("KANSCD", True, strKANSCD)

        dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)
        Return dbData

    End Function

End Class
