
Imports Common

Imports System.Configuration

Partial Class COGBASEG00
    Inherits System.Web.UI.Page

    '<TODO>�錾���ʎd�l
    '******************************************************************************
    ' HttpHeader
    '******************************************************************************
    Protected HttpHeaderC As New CHttpHeader

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

        If IsNothing(Request.QueryString("CTINO")) = True Then
            '//�ʏ�̃��j���[���o�͂���
            hdnMNFLG.Value = ""
            hdnSVFLG.Value = ""

        ElseIf Convert.ToString(Request.QueryString("CTINO")).Length > 0 Then
            hdnMNFLG.Value = "SYCTIJAG00"
            hdnSVFLG.Value = Request.QueryString("CTINO")

        Else
            '//�ʏ�̃��j���[���o�͂���
            hdnMNFLG.Value = ""
            hdnSVFLG.Value = ""

        End If

    End Sub

End Class
