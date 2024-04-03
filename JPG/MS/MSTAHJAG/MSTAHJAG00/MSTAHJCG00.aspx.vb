'***********************************************
' �i�`�S���ҘA����G�N�Z���o��
'***********************************************
' �ύX����
' 2010/03/30 T.Watabe �V�K�쐬

Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common
Imports JPG.Common.log

Imports System.Text

Partial Class MSTAHJCG00
    Inherits System.Web.UI.Page

    '******************************************************************************
    ' HttpHeader
    '******************************************************************************
    Protected HttpHeaderC As New CHttpHeader

    '******************************************************************************
    ' �e��ʃN���X
    '******************************************************************************
    Protected MSTAHJAG00C As MSTAHJAG00

    '<TODO>�錾���ʎd�l
    '******************************************************************************
    ' �F�؃N���X
    '******************************************************************************
    Protected AuthC As CAuthenticate

    '******************************************************************************
    ' �N�b�L�[
    '******************************************************************************
    Protected ConstC As New CConst

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

        '//<TODO>Transfer���Ă����e�̃n���h���������p��
        MSTAHJAG00C = CType(Context.Handler, MSTAHJAG00)

        Dim strRec As String
        Dim strRecMsg As String
        Dim MSTAHJCG00C As New MSTAHJAG00MSTAHJAW00.MSTAHJAW00

        '2019/11/01 T.Ono mod �Ď����P2019 MSTAHJAG00C.pKuracd_to �ǉ�
        'strRec = MSTAHJCG00C.mCheck(
        '                       MSTAHJAG00C.pKuracd,
        '                       MSTAHJAG00C.pJAcd,
        '                       MSTAHJAG00C.pGroupcd,
        '                       MSTAHJAG00C.pCentercd,
        '                       65000
        '                       )
        strRec = MSTAHJCG00C.mCheck(
                               MSTAHJAG00C.pKuracd,
                               MSTAHJAG00C.pKuracd_to,
                               MSTAHJAG00C.pJAcd,
                               MSTAHJAG00C.pGroupcd,
                               MSTAHJAG00C.pCentercd,
                               65000
                               )

        If strRec = "DATA0" Then
            '�f�[�^��0���̏ꍇ
            strRecMsg = "�Ώۃf�[�^�����݂��܂���"
            strMsg.Append("alert('" & strRecMsg & "');" & vbCrLf)
            strMsg.Append("parent.Data.Form1.btnSelect.focus();" & vbCrLf)

        ElseIf strRec = "DATAMAX" Then
            strRec = "CHK"
            '���݂���ׁA�㏑���̊m�F���s��
            strMsg.Append(vbCrLf)
            strMsg.Append("function fncChkMessage(){" & vbCrLf)
            strMsg.Append("var strRes;" & vbCrLf)
            strMsg.Append("strRes = confirm('�ő�o�͌����𒴂��܂����B\n�o�͂��܂����H');" & vbCrLf)
            strMsg.Append("if (strRes==false){" & vbCrLf)
            strMsg.Append("  parent.Data.Form1.btnSelect.disabled = false;")     '//�����߂�
            strMsg.Append("  return;" & vbCrLf)
            strMsg.Append("}" & vbCrLf)
            strMsg.Append("" & vbCrLf)
            strMsg.Append("parent.Data.doPostBack('btnSelect','');" & vbCrLf)
            strMsg.Append("}" & vbCrLf)
            strMsg.Append("window.onload = fncChkMessage;" & vbCrLf)
            strMsg.Append(vbCrLf)
        Else
            strMsg.Append("parent.Data.doPostBack('btnSelect','');" & vbCrLf)
        End If
    End Sub

End Class
