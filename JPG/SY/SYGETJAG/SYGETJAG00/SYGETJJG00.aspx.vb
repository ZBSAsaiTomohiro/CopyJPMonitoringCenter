'***********************************************
'�����f�[�^�����@�@���s����
'***********************************************
'<TODO>�錾���ʎd�l
Option Explicit On
Option Strict On

'<TODO>�錾���ʎd�l
Imports Common          '�F�Q�Ɛݒ��COCOMONC00��ݒ肷��
Imports JPG.Common
Imports JPG.Common.log  '�F�Q�Ɛݒ��COCOLOGC00��ݒ肷��
Imports System.Text     '�FStringBuilder���g�p���邽��

Partial Class SYGETJJG00
    Inherits System.Web.UI.Page

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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '//------------------------------------------
        '//�@HTTP�w�b�_�𑗐M
        HttpHeaderC.mNoCache(Response)

        '//------------------------------------------
        '//�@�F�؃N���X�̃C���X�^���X����
        AuthC = New CAuthenticate(Request, Response)

        '//-----------------------------------------

        Dim SYGETJAG00C As SYGETJAG00
        SYGETJAG00C = CType(Context.Handler, SYGETJAG00)

        '//------------------------------------------

        Dim SYGETJAW00C As New SYGETJAG00SYGETJAW00.SYGETJAW00
        Dim strRec As String

        'EXE���s----------------------------------
        strRec = SYGETJAW00C.mExec(Request.Form("hdnTRGDATEM"), _
                                SYGETJAG00C.fncDateGet(Request.Form("txtTRGDATE1")), _
                                SYGETJAG00C.fncDateGet(Request.Form("txtTRGDATE2")), _
                                SYGETJAG00C.fncDateGet(Request.Form("txtTRGDATE3")), _
                                SYGETJAG00C.pDelmonth_ApLog, _
                                SYGETJAG00C.pDelmonth_BatLog, _
                                SYGETJAG00C.pDelmonth_TelLog, _
                                SYGETJAG00C.pDelmonth_File, _
                                SYGETJAG00C.pDelmonth_BackFile, _
                                Convert.ToString(Format(Now, "yyyyMMdd")), _
                                Convert.ToString(Format(Now, "HHmmss")))

        If strRec = "OK" Then
            strMsg.Append("parent.Data.Form1.btnExit.disabled=false;")
            strMsg.Append("parent.Data.Form1.btnExit.focus();")
            strMsg.Append("alert('�������󂯕t���܂���');")
        Else
            '�G���[�ł���΃u���E�U�Ƀ��b�Z�[�W�\��
            Dim ErrMsgC As New CErrMsg
            strMsg.Append("parent.Data.Form1.btnExit.disabled=false;")
            strMsg.Append("parent.Data.Form1.btnExit.focus();")
            strMsg.Append("alert('�V�X�e���G���[�F" & ErrMsgC.mGetArtMsg(strRec) & "');")
        End If


        '-------------------------------------------------
        '//�`�o���O��������
        Dim LogC As New CLog
        Dim strRecLog As String
        '2012/04/04 NEC ou Upd Str
        'strRecLog = LogC.mAPLog(Request.Cookies.Get("ASP.NET_SessionId").Value, _
        '            AuthC.pUSERNAME, AuthC.pIPADDRESS, Request.Form("hdnMyAspx"), "1", strRec, Request.Form)
        strRecLog = LogC.mAPLog(Me.Session.SessionID, _
                    AuthC.pUSERNAME, AuthC.pIPADDRESS, Request.Form("hdnMyAspx"), "1", strRec, Request.Form)
        '2012/04/04 NEC ou Upd End
        If strRecLog <> "OK" Then
            Dim errmsgc As New CErrMsg
            strMsg.Append("alert('�V�X�e���G���[�F" & errmsgc.mGetArtMsg(strRecLog) & "');")
        End If

    End Sub

End Class
