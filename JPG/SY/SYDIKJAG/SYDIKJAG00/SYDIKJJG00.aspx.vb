'***********************************************
'�ً}�Ď��Ɩ���s�ݒ�
'***********************************************
Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common
Imports JPG.Common.log  '�F�Q�Ɛݒ��COCOLOGC00��ݒ肷��

Imports System.Text

Partial Class SYDIKJJG00
    Inherits System.Web.UI.Page

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

        Dim strRec As String
        Dim strMODE As String

        Dim SYDIKJAW00C As New SYDIKJAG00SYDIKJAW00.SYDIKJAW00

        Dim SYDIKJAG00C As SYDIKJAG00
        SYDIKJAG00C = CType(Context.Handler, SYDIKJAG00)

        'strMode 1:��s�ݒ�
        'strMode 2:��s����
        strMODE = Request.Form("hdnMODE")

        '--------------------------------------------
        '<TODO>WEB�T�[�r�X���Ăяo��
        strRec = SYDIKJAW00C.mSet( _
                            SYDIKJAG00C.pKANSCD, _
                            SYDIKJAG00C.pDAIKOKANSCD, _
                            strMODE)

        '--------------------------------------------
        '<TODO>�Ԃ�l�ɂ�鐧����s���B
        '�y���ʁz
        '  OK : ����ɏI�����܂���
        '   2 : ��s�ݒ肳��Ă��܂���
        '   3 : �r�����䏈���ŃG���[���������܂����B�ēx���s���Ă�������


        '���O�ɏ������ރG���[���b�Z�[�W�i�[
        Dim strRecMsg As String

        '��ʏ�Ԃ̍X�V
        '�C�x���g�����I�u�W�F�N�g�ɑ΂��郍�b�N��������
        Call fncNoRocControl()

        Select Case strRec
            Case "OK"
                strMsg.Append("alert('����ɏI�����܂���');")

                '//------------------------------
                '<TODO>�t�H�[�J�X���Z�b�g����
                strMsg.Append("parent.Data.Form1.cboKANSCD.focus();")
            Case "2"
                strRecMsg = "��s�ݒ肳��Ă��܂���"
                strMsg.Append("alert('" & strRecMsg & "');")

                '//------------------------------
                '<TODO>�t�H�[�J�X���Z�b�g����
                strMsg.Append("parent.Data.Form1.cboKANSCD.focus();")

                strRec = strRecMsg
            Case "3"
                strRecMsg = "�r�����䏈���ŃG���[���������܂����B�ēx���s���Ă�������"
                strMsg.Append("alert('" & strRecMsg & "');")

                '//------------------------------
                '<TODO>�t�H�[�J�X���Z�b�g����
                strMsg.Append("parent.Data.Form1.btnExit.focus();")

                strRec = strRecMsg
            Case Else
                Dim ErrMsgC As New CErrMsg

                strMsg.Append("alert('�V�X�e���G���[�F" & ErrMsgC.mGetArtMsg(strRec) & "');")

                '//----------------------------------
                '<TODO>�t�H�[�J�X���Z�b�g����
                strMsg.Append("parent.Data.Form1.cboKANSCD.focus();")
        End Select

        '-------------------------------------------------
        '//�`�o���O��������
        Dim LogC As New CLog
        Dim strRecLog As String
        '2012/04/04 NEC ou Upd
        'strRecLog = LogC.mAPLog(Request.Cookies.Get("ASP.NET_SessionId").Value, AuthC.pUSERNAME, AuthC.pIPADDRESS, Request.Form("hdnMyAspx"), "1", strRec, Request.Form)
        strRecLog = LogC.mAPLog(Me.Session.SessionID, AuthC.pUSERNAME, AuthC.pIPADDRESS, Request.Form("hdnMyAspx"), "1", strRec, Request.Form)
        '2012/04/04 NEC ou Upd
        If strRecLog <> "OK" Then
            Dim errmsgc As New CErrMsg
            strMsg.Append("alert('�V�X�e���G���[�F" & errmsgc.mGetArtMsg(strRecLog) & "');")
        End If

        strMsg.Append("location.replace('about:blank');")   '��M�t���[�������u�����N�y�[�W�ɁB

    End Sub

    '******************************************************************
    '���s�O�ɏ�Ԃɂ���
    '******************************************************************
    Private Sub fncNoRocControl()
        '//�C�x���g���ڂƂ��ă��b�N�������̂��g�p�\
        strMsg.Append("with(parent.Data.Form1){")
        strMsg.Append("btnExit.disabled=false;")
        strMsg.Append("btnSET.disabled=false;")
        strMsg.Append("btnCANCEL.disabled=false;")
        strMsg.Append("}")
    End Sub

End Class
