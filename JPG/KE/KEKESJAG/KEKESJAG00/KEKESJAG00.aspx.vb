'***********************************************
'�����f�[�^�ꗗ  ���C�����
'***********************************************
Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common.log
Imports System.Text

Partial Class KEKESJAG00
    Inherits System.Web.UI.Page
    Protected WithEvents txtKansiCtCd As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtKansiCtNm As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSyob_From As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSyob_To As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnKen As System.Web.UI.HtmlControls.HtmlInputButton

    '******************************************************************************
    ' HttpHeader
    '******************************************************************************
    Protected HttpHeaderC As New CHttpHeader

    '******************************************************************************
    ' ScriptMessage
    '******************************************************************************
    Private strMsg As New StringBuilder("")      '//<script>�͕K�v�Ȃ�

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
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                                                                Handles MyBase.Load
        '//------------------------------------------
        '//�@HTTP�w�b�_�𑗐M
        HttpHeaderC.mNoCache(Response)

        '//------------------------------------------
        '//�����ꗗ���o�͂���
        If hdnKenSaku.Value = "KEKESJFG00" Then
            Server.Transfer("KEKESJFG00.aspx")
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
             MyBase.MapPath("../../../KE/KEKESJAG/KEKESJAG00/") & "KEKESJAG00.js"))
        '<�t�H�[�J�X�֘A�֐�>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncFo.js"))
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
            '//�@���߂ĊJ�������������s�����
            '//--------------------------------------------------------------------------
            '<TODO>�����\���Ƃ��ĕK�v�ȃR���g���[���̐ݒ���s���܂�
            '      ��)��ʏ����\�����́��������I������Ă��邱�Ɓc�c���̏���
            '//--------------------------------------------------------------------------
            '�@�������ʂɂ���ʂ̏�Ԃ̐ݒ�------------------------
            '�@��ʂ��y�����O��ԁz�ɂ���i���̓f�[�^�͂��̂܂ܑJ�ڂ�����j
        Else
            '//--------------------------------------
            '//�@�Q��ڈȍ~���s�����
            '//--------------------------------------------------------------------------
            '//����ʕ\������R���{�{�b�N�X�͊e�ŏI�C�x���g/���\�b�h��CALL���܂�
            '//--------------------------------------------------------------------------
        End If

        '//-------------------------------------------------
        '<TODO>�����̉��ID��HIDDEN��hdnMyAspx�ɏ������ށi�V�X�e�����ʁj
        hdnMyAspx.Value = "KEKESJAG00"
        '//-------------------------------------------------

    End Sub
    '******************************************************************************
    ' �폜�{�^��
    '******************************************************************************
    Private Sub btnDelete_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                                                                Handles btnDelete.ServerClick
        'hdnDelCnt�@�F�@�폜�������i�[����Ă���
        'hdnDelKey�@�F�@�폜�Ώۂ̃L�[���J���}�ҏW�Ŋi�[����Ă���
        Dim KEKESJAW00C As New KEKESJAG00KEKESJAW00.KEKESJAW00

        Dim strRec As String

        ''''''-------------------------------------------------
        ''''''�J�n�L�^
        '''''Dim LogC As New CLog
        '''''
        ''''''LogC.mAPLOG_Start(Request.Cookies.Get("ASP.NET_SessionId").Value, hdnMyAspx.Value, "3")        '//�폜����
        '''''strRec = LogC.mAPLOG_Start(Request.Cookies.Get("ASP.NET_SessionId").Value, hdnMyAspx.Value, "3")
        '''''If strRec <> "OK" Then
        '''''    Dim ErrMsgC As New CErrMsg
        '''''    strMsg.Append("alert('�V�X�e���G���[�F" & ErrMsgC.mGetArtMsg(strRec) & "');")
        '''''    Exit Sub
        '''''End If

        'Dim strRec As String  
        strRec = KEKESJAW00C.mDel(CInt(hdnDelCnt.Value), hdnDelKey.Value)

        Select Case strRec
            Case "OK"
                strMsg.Append("alert('����ɏI�����܂���');")
            Case Else
                Dim ErrMsgC As New CErrMsg
                strMsg.Append("alert('�V�X�e���G���[�F" & ErrMsgC.mGetArtMsg(strRec) & "');")
        End Select

        '�폜�{�^���g�p�\
        strMsg.Append("Form1.btnDelete.disabled=false;")
        strMsg.Append("Form1.btnDelete.focus();")

        ''''''//------------------------------------------
        ''''''//�I���L�^
        ''''''LogC.mAPLOG_End(strRec)  				
        '''''Dim strRecLog As String
        '''''strRecLog = LogC.mAPLOG_End(strRec)
        '''''If strRecLog <> "OK" Then
        '''''    Dim ErrMsgC As New CErrMsg
        '''''    strMsg.Append("alert('�V�X�e���G���[�F" & ErrMsgC.mGetArtMsg(strRecLog) & "');")
        '''''End If

    End Sub
End Class




