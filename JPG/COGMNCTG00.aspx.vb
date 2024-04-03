Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common

Imports System.Text

Partial Class COGMNCTG00
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
    ' �Ď��Z���^�[���j���[
    '******************************************************************************
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '//------------------------------------------
        '//�@HTTP�w�b�_�𑗐M
        HttpHeaderC.mNoCache(Response)

        '//------------------------------------------
        '// Script�����ݗp�ϐ��錾
        Dim strScript As New StringBuilder("")
        Dim cscript1 As New CScript
        Dim strScriptPath As String
        strScriptPath = ConfigurationSettings.AppSettings("SCRIPTPATH")

        '//JavaScript----------------------------------
        strScript.Append("<Script language=javascript>" & vbCrLf)
        '<���j���[��ʋ��ʊ֐�>
        strScript.Append(cscript1.mWriteScript(MyBase.MapPath("./") & "COGBASEG00.js") & vbCrLf)
        strScript.Append("</Script>" & vbCrLf)

        '//Css-----------------------------------------
        strScript.Append("<Style>" & vbCrLf)
        '<���ʃN���X>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "CssData.css") & vbCrLf)
        '<���j���[��ʋ��ʃN���X>
        strScript.Append(cscript1.mWriteScript(MyBase.MapPath("./") & "COGBASEG00.css") & vbCrLf)
        strScript.Append("</Style>" & vbCrLf)

        lblScript.Text = strScript.ToString

        '//------------------------------------------
        '//�@�F�؃N���X�̃C���X�^���X����
        AuthC = New CAuthenticate(Request, Response)

        '--- ��2005/04/19 MOD�@Falcon�� -----------------
        'Dim strGROUPNAME As String = AuthC.pGROUPNAME
        Dim strKANSHINAME As String = AuthC.pKANSHINAME

        'lblTitle.Text = strGROUPNAME
        lblTitle.Text = strKANSHINAME
        '--- ��2005/04/19 MOD Falcon�� ------------------

        '--- ��2005/04/19 DEL�@Falcon�� -----------------
        'If Array.IndexOf(arrGroupName, AuthC.pGROUP_TOUHOKU) >= 0 Then
        '    '// ���k�Ď��Z���^�[
        '    lblTitle.Text = "���k"
        'ElseIf Array.IndexOf(arrGroupName, AuthC.pGROUP_NAKANIHON) >= 0 Then
        '    '// �����{�Ď��Z���^�[
        '    lblTitle.Text = "�����{"
        'ElseIf Array.IndexOf(arrGroupName, AuthC.pGROUP_NISHINIHON) >= 0 Then
        '    '// �����{�Ď��Z���^�[
        '    lblTitle.Text = "�����{"
        'Else
        '    '//���̑�
        '    lblTitle.Text = ""
        'End If
        '--- ��2005/04/19 DEL Falcon�� ------------------
    End Sub

End Class
