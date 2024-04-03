'***********************************************
'�����f�[�^�����i���C���j
'***********************************************
'<TODO>�錾���ʎd�l
Option Explicit On
Option Strict On

'<TODO>�錾���ʎd�l
Imports Common          '�F�Q�Ɛݒ��COCOMONC00��ݒ肷��
Imports JPG.Common
Imports System.Text     '�FStringBuilder���g�p���邽��

Partial Class SYGETJAG00
    Inherits System.Web.UI.Page
    Protected WithEvents txtDATE1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDATE2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDATE3 As System.Web.UI.WebControls.TextBox

    '<TODO>�錾���ʎd�l
    '******************************************************************************
    ' HttpHeader
    '******************************************************************************
    Protected HttpHeaderC As New CHttpHeader

    '<TODO>�錾���ʎd�l
    '******************************************************************************
    '�F�؃N���X
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
        '//------------------------------------------
        '//�@HTTP�w�b�_�𑗐M
        HttpHeaderC.mNoCache(Response)

        '//------------------------------------------
        '//�@�F�؃N���X�̃C���X�^���X����
        AuthC = New CAuthenticate(Request, Response)

        '//------------------------------------------
        '// Script�����ݗp�ϐ��錾
        Dim strScript As New StringBuilder("")
        Dim cscript1 As New CScript
        Dim strScriptPath As String
        'Dim strDelmonth_Setai As String
        'Dim strDelmonth_Koji As String
        Dim strDelmonth_Keiho As String
        Dim strDelmonth_Taio As String

        Dim strDelmonth_Batlog As String '2007/11/29 T.Watabe add
        Dim strDelmonth_Aplog As String
        Dim strDelmonth_Tellog As String
        Dim strDelmonth_File As String
        Dim strDelmonth_Aplog_backfile As String
        Dim strDelmonth_Backfile As String
        Dim strDelmonth_AutoFaxLogDB As String '2016/12/27 T.Ono add 2016���P�J�� ��12 S05_AUTOFAXLOGDB
        Dim strDelmonth_AutoFaxTaiDB As String '2016/12/27 T.Ono add 2016���P�J�� ��12 S06_AUTOFAXTAIDB
        Dim strDelmonth_FaxOutBoxLog As String '2016/12/27 T.Ono add 2016���P�J�� ��12 S07_FAXOUTBOXLOG


        strScriptPath = ConfigurationSettings.AppSettings("SCRIPTPATH")
        'strDelmonth_Setai = ConfigurationSettings.AppSettings("DELMONTH_SETAI")
        'strDelmonth_Koji = ConfigurationSettings.AppSettings("DELMONTH_KOJI")
        strDelmonth_Keiho = ConfigurationSettings.AppSettings("DELMONTH_KEIHO")
        strDelmonth_Taio = ConfigurationSettings.AppSettings("DELMONTH_TAIO")

        strDelmonth_Batlog = ConfigurationSettings.AppSettings("DELMONTH_BATLOG") ' 2007/11/29 T.Watabe add
        strDelmonth_Aplog = ConfigurationSettings.AppSettings("DELMONTH_APLOG")
        strDelmonth_Tellog = ConfigurationSettings.AppSettings("DELMONTH_TELLOG")
        strDelmonth_File = ConfigurationSettings.AppSettings("DELMONTH_FILE")
        strDelmonth_Aplog_backfile = ConfigurationSettings.AppSettings("DELMONTH_APLOG_BACKFILE")
        strDelmonth_Backfile = ConfigurationSettings.AppSettings("DELMONTH_BACKFILE")
        strDelmonth_AutoFaxLogDB = ConfigurationSettings.AppSettings("DELMONTH_AUTOFAXLOGDB") '2016/12/27 T.Ono add 2016���P�J�� ��12
        strDelmonth_AutoFaxTaiDB = ConfigurationSettings.AppSettings("DELMONTH_AUTOFAXTAIDB") '2016/12/27 T.Ono add 2016���P�J�� ��12
        strDelmonth_FaxOutBoxLog = ConfigurationSettings.AppSettings("DELMONTH_FAXOUTBOXLOG") '2016/12/27 T.Ono add 2016���P�J�� ��12

        hdnDELMONTH_APLOG.Value = ConfigurationSettings.AppSettings("DELMONTH_APLOG")
        hdnDELMONTH_BATLOG.Value = ConfigurationSettings.AppSettings("DELMONTH_BATLOG")
        hdnDELMONTH_TELLOG.Value = ConfigurationSettings.AppSettings("DELMONTH_TELLOG")
        hdnDELMONTH_FILE.Value = ConfigurationSettings.AppSettings("DELMONTH_FILE")
        hdnDELMONTH_BACKFILE.Value = ConfigurationSettings.AppSettings("DELMONTH_BACKFILE")
        hdnDELMONTH_AUTOFAXLOGDB.Value = ConfigurationSettings.AppSettings("DELMONTH_AUTOFAXLOGDB") '2016/12/27 T.Ono add 2016���P�J�� ��12
        hdnDELMONTH_AUTOFAXTAIDB.Value = ConfigurationSettings.AppSettings("DELMONTH_AUTOFAXTAIDB") '2016/12/27 T.Ono add 2016���P�J�� ��12
        hdnDELMONTH_FAXOUTBOXLOG.Value = ConfigurationSettings.AppSettings("DELMONTH_FAXOUTBOXLOG") '2016/12/27 T.Ono add 2016���P�J�� ��12

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
             MyBase.MapPath("../../../SY/SYGETJAG/SYGETJAG00/") & "SYGETJAG00.js"))
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

        If MyBase.IsPostBack = False Then
            '//--------------------------------------
            '//�@���߂ĊJ�������������s�����
            Dim datDate As Date
            Dim strDateY As String = Format(Now, "yyyy")
            Dim strDateM As String = Format(Now, "MM")
            Dim strDateD As String = Format(Now, "dd")

            '�����\������Ώۂ̓��t��Hidden�Ɋi�[(��ʏo�͈ȊO�̑Ώۃf�[�^�͂�����f�[�^�������s��)
            hdnTRGDATEM.Value = strDateY & strDateM & strDateD

            ''���ю�/���p��/�Ή�/���C�@�̍폜�Ώۓ��t���o��
            'datDate = DateSerial(CInt(strDateY) - CInt(strDelmonth_Setai), CInt(strDateM), CInt(strDateD))
            ''--- ��2005/04/23 DEL Falcon�� ---
            ''txtDATE1.Text = strDelmonth_Setai
            ''--- ��2005/04/23 DEL Falcon�� ---
            'txtTRGDATE1.Text = Format(datDate, "yyyy/MM/dd")

            ''�H���c�a�̍폜�Ώۓ��t���o��
            'datDate = DateSerial(CInt(strDateY) - CInt(strDelmonth_Koji), CInt(strDateM), CInt(strDateD))
            ''--- ��2005/04/23 DEL Falcon�� ---
            ''txtDATE2.Text = strDelmonth_Koji
            ''--- ��2005/04/23 DEL Falcon�� ---
            'txtTRGDATE2.Text = Format(datDate, "yyyy/MM/dd")

            ''�x��c�a�̍폜�Ώۓ��t���o��
            'datDate = DateSerial(CInt(strDateY), CInt(strDateM) - CInt(strDelmonth_Keiho), CInt(strDateD))
            ''--- ��2005/04/23 DEL Falcon�� ---
            ''txtDATE3.Text = strDelmonth_Keiho
            ''--- ��2005/04/23 DEL Falcon�� ---
            'txtTRGDATE3.Text = Format(datDate, "yyyy/MM/dd")

            txtTRGDATE1.Text = Format(DateSerial(CInt(strDateY), CInt(strDateM) - CInt(strDelmonth_Keiho), CInt(strDateD)), "yyyy/MM/dd")
            txtTRGDATE2.Text = Format(DateSerial(CInt(strDateY) - CInt(strDelmonth_Taio), CInt(strDateM), CInt(strDateD)), "yyyy/MM/dd")
            '2012/06/08 NEC ou Upd Str
            'txtTRGDATE3.Text = Format(DateSerial(CInt(strDateY), CInt(strDateM) - CInt(strDelmonth_Batlog), CInt(strDateD)), "yyyy/MM/dd")
            txtTRGDATE3.Text = Format(DateSerial(CInt(strDateY) - CInt(strDelmonth_Batlog), CInt(strDateM), CInt(strDateD)), "yyyy/MM/dd")
            '2012/06/08 NEC ou Upd End
            txtTRGDATE4.Text = Format(DateSerial(CInt(strDateY), CInt(strDateM) - CInt(strDelmonth_Aplog), CInt(strDateD)), "yyyy/MM/dd")
            '2012/06/08 NEC ou Upd Str
            'txtTRGDATE5.Text = Format(DateSerial(CInt(strDateY), CInt(strDateM) - CInt(strDelmonth_Tellog), CInt(strDateD)), "yyyy/MM/dd")
            txtTRGDATE5.Text = Format(DateSerial(CInt(strDateY) - CInt(strDelmonth_Tellog), CInt(strDateM), CInt(strDateD)), "yyyy/MM/dd")
            '2012/06/08 NEC ou Upd End
            txtTRGDATE6.Text = Format(DateSerial(CInt(strDateY), CInt(strDateM) - CInt(strDelmonth_File), CInt(strDateD)), "yyyy/MM/dd")
            txtTRGDATE7.Text = Format(DateSerial(CInt(strDateY), CInt(strDateM) - CInt(strDelmonth_Aplog_backfile), CInt(strDateD)), "yyyy/MM/dd")
            txtTRGDATE8.Text = Format(DateSerial(CInt(strDateY), CInt(strDateM) - CInt(strDelmonth_Backfile), CInt(strDateD)), "yyyy/MM/dd")
            '2016/12/27 T.Ono add 2016���P�J�� ��12 START
            txtTRGDATE9.Text = Format(DateSerial(CInt(strDateY) - CInt(strDelmonth_AutoFaxLogDB), CInt(strDateM), CInt(strDateD)), "yyyy/MM/dd")
            txtTRGDATE10.Text = Format(DateSerial(CInt(strDateY) - CInt(strDelmonth_AutoFaxTaiDB), CInt(strDateM), CInt(strDateD)), "yyyy/MM/dd")
            txtTRGDATE11.Text = Format(DateSerial(CInt(strDateY) - CInt(strDelmonth_FaxOutBoxLog), CInt(strDateM), CInt(strDateD)), "yyyy/MM/dd")
            '2016/12/27 T.Ono add 2016���P�J�� ��12 END

            '//--------------------------------------------------------------------------
            '�t�H�[�J�X���Z�b�g����
            strMsg.Append("Form1.btnJikkou.focus();")
        Else
            '//--------------------------------------
            '//�@�Q��ڈȍ~���s�����
            '//--------------------------------------
        End If

        '//-------------------------------------------------
        '<TODO>�����̉��ID��HIDDEN��hdnMyAspx�ɏ������ށi�V�X�e�����ʁj
        hdnMyAspx.Value = "SYGETJAG00"
        '//-------------------------------------------------

    End Sub

    '******************************************************************************
    '*�@�T�@�v�F�p�����[�^�l�����tYYYYMMDD�l��Ԃ�
    '*�@���@�l�F
    '******************************************************************************
    Public Function fncDateGet(ByVal pstrDate As String) As String
        Dim DateFncC As New CDateFnc
        Dim strRec As String
        strRec = ""
        If pstrDate.Length = 10 Then    'YYYY/MM/DD
            strRec = DateFncC.mHenkanGet(pstrDate)
        End If

        Return strRec
    End Function

    '******************************************************************************
    '*�@�T�@�v�F�`�o���O�̍폜���Ԃ�n���v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pDelmonth_ApLog() As String
        Get
            Return hdnDELMONTH_APLOG.Value
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�o�b�`���O�̍폜���Ԃ�n���v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pDelmonth_BatLog() As String
        Get
            Return hdnDELMONTH_BATLOG.Value
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�d�b���M���O�̍폜���Ԃ�n���v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pDelmonth_TelLog() As String
        Get
            Return hdnDELMONTH_TELLOG.Value
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�ꎞ�t�@�C���̍폜���Ԃ�n���v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pDelmonth_File() As String
        Get
            Return hdnDELMONTH_FILE.Value
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�o�b�N�A�b�v�t�@�C���̍폜���Ԃ�n���v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pDelmonth_BackFile() As String
        Get
            Return hdnDELMONTH_BACKFILE.Value
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F���s�{�^���������̏���
    '*�@���@�l�F
    '******************************************************************************
    Private Sub btnJikkou_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnJikkou.ServerClick
        Server.Transfer("SYGETJJG00.aspx")
    End Sub
End Class
