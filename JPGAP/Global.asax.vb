Imports System.Web
Imports System.Web.SessionState

Public Class [Global]
    Inherits System.Web.HttpApplication

#Region " �R���|�[�l���g �f�U�C�i�Ő������ꂽ�R�[�h "

    Public Sub New()
        MyBase.New()

        ' ���̌Ăяo���́A�R���|�[�l���g �f�U�C�i�ŕK�v�ł��B
        InitializeComponent()

        ' InitializeComponent() �Ăяo���̌�ɏ�������ǉ����܂��B

    End Sub

    ' �R���|�[�l���g �f�U�C�i�ŕK�v�ł��B
    Private components As System.ComponentModel.IContainer

    ' ���� : �ȉ��̃v���V�[�W���̓R���|�[�l���g �f�U�C�i�ŕK�v�ł��B
    ' �R���|�[�l���g �f�U�C�i���g���ĕύX���Ă��������B
    ' �R�[�h �G�f�B�^���g���ĕύX���Ȃ��ł��������B
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container()
    End Sub

#End Region

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' �A�v���P�[�V�������J�n���ꂽ�Ƃ��ɔ������܂��B
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' �Z�b�V�������J�n���ꂽ�Ƃ��ɔ������܂��B
    End Sub

    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' �e�v���̍ŏ��ɔ������܂��B
    End Sub

    Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' �g�p��F�؂��悤�Ƃ���Ƃ��ɔ������܂��B
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' �G���[�����������Ƃ��ɑ��o����܂��B
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' �Z�b�V�������I�������Ƃ��ɔ������܂��B
    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' �A�v���P�[�V�������I�������Ƃ��ɔ������܂��B
    End Sub

End Class
