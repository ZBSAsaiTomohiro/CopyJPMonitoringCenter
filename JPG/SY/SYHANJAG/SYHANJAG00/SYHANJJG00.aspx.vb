'***********************************************
'
'***********************************************
'<TODO>�錾���ʎd�l
Option Explicit On
Option Strict On

'<TODO>�錾���ʎd�l
Imports Common
Imports JPG.Common
Imports JPG.Common.log

Imports System.Text

Partial Class SYHANJJG00
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
        Dim SYHANJAG00C As SYHANJAG00
        SYHANJAG00C = CType(Context.Handler, SYHANJAG00)

        '//------------------------------------------
        Dim SYHANJAW00C As New SYHANJAG00SYHANJAW00.SYHANJAW00
        Dim strRec As String

        'EXE���s----------------------------------
        strRec = SYHANJAW00C.mExec(SYHANJAG00C.pKENCD, _
                                   SYHANJAG00C.pTAISYO, _
                                   SYHANJAG00C.pSYUKEIF, _
                                   SYHANJAG00C.pSYUKEIT, _
                                   SYHANJAG00C.pMOT_TAISYO, _
                                   SYHANJAG00C.pMOT_SYUKEIF)

        '//���b�N�������ڂ̉���-------------------------
        strMsg.Append("parent.Data.Form1.btnJikkou.disabled=false;")
        strMsg.Append("parent.Data.Form1.btnExit.disabled=false;")
        strMsg.Append("parent.Data.Form1.btnJikkou.focus();")

        '//���ʎ擾-------------------------------------
        If strRec = "OK" Then
            strMsg.Append("parent.Data.cboKen_change();")   '�X�V�������t������ʂɔ��f�����邽��
            strMsg.Append("alert('�������󂯕t���܂���');")

        ElseIf strRec = "0" Then
            strMsg.Append("parent.Data.cboKen_change();")
            strMsg.Append("alert('���̃��[�U�[�ɂ���Ċ��ɏ������s���Ă��܂��B�ēx���s���Ă�������');")

        Else
            '�G���[�ł���΃u���E�U�Ƀ��b�Z�[�W�\��
            Dim ErrMsgC As New CErrMsg
            strMsg.Append("alert('�V�X�e���G���[�F" & ErrMsgC.mGetArtMsg(strRec) & "');")

        End If

        '-------------------------------------------------
        '//�`�o���O��������
        Dim LogC As New CLog
        Dim strRecLog As String
        '2012/04/04 NEC ou Upd
        'strRecLog = LogC.mAPLog(Request.Cookies.Get("ASP.NET_SessionId").Value, _
        '            AuthC.pUSERNAME, AuthC.pIPADDRESS, Request.Form("hdnMyAspx"), "1", strRec, Request.Form)
        strRecLog = LogC.mAPLog(Me.Session.SessionID, _
            AuthC.pUSERNAME, AuthC.pIPADDRESS, Request.Form("hdnMyAspx"), "1", strRec, Request.Form)
        '2012/04/04 NEC ou Upd
        If strRecLog <> "OK" Then
            Dim errmsgc As New CErrMsg
            strMsg.Append("alert('�V�X�e���G���[�F" & errmsgc.mGetArtMsg(strRecLog) & "');")
        End If

        '-------------------------------------------------
        '//�������s��cboKen_change���s�����߃R�����g�Ƃ���
        'strMsg.Append("location.replace('about:blank');")   '��M�t���[�������u�����N�y�[�W�ɁB
    End Sub

End Class
