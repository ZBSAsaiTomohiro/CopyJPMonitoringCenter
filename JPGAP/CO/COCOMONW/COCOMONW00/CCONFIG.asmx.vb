Option Strict On

Imports System.Web.Services
Imports System.Configuration

<System.Web.Services.WebService(Namespace := "http://tempuri.org/JPGAP.COCOMONW00/CCONFIG")> _
Public Class CCONFIG
    Inherits System.Web.Services.WebService

#Region " Web �T�[�r�X �f�U�C�i�Ő������ꂽ�R�[�h "

    Public Sub New()
        MyBase.New()

        '���̌Ăяo���� Web �T�[�r�X �f�U�C�i�ŕK�v�ł��B
        InitializeComponent()

        ' InitializeComponent() �Ăяo���̌�ɓƎ��̏������R�[�h��ǉ����Ă��������B

    End Sub

    'Web �T�[�r�X �f�U�C�i�ŕK�v�ł��B
    Private components As System.ComponentModel.IContainer

    '���� : �ȉ��̃v���V�[�W���́AWeb �T�[�r�X �f�U�C�i�ŕK�v�ł��B
    'Web �T�[�r�X �f�U�C�i���g���ĕύX���邱�Ƃ��ł��܂��B  
    '�R�[�h �G�f�B�^�ɂ��ύX�͍s��Ȃ��ł��������B
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container()
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        'CODEGEN: ���̃v���V�[�W���� Web �T�[�r�X �f�U�C�i�ŕK�v�ł��B
        '�R�[�h �G�f�B�^�ɂ��ύX�͍s��Ȃ��ł��������B
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

#End Region

    '�c�a�ڑ����[�U�[
    <WebMethod()> Public Function mGetConfigJPUID() As String
        Return ConfigurationSettings.AppSettings("JPUID")
    End Function

    '�c�a�ڑ��p�X���[�h
    <WebMethod()> Public Function mGetConfigJPPWD() As String
        Return ConfigurationSettings.AppSettings("JPPWD")
    End Function

    '�c�a�ڑ��c�a��
    <WebMethod()> Public Function mGetConfigJPDB() As String
        Return ConfigurationSettings.AppSettings("JPDB")
    End Function

    '�Ή��c�a�폜�Ώۊ���
    <WebMethod()> Public Function mGetConfigDELMONTH_TAIO() As String
        Return ConfigurationSettings.AppSettings("DELMONTH_TAIO")
    End Function

    '�x��c�a�폜�Ώۊ���
    <WebMethod()> Public Function mGetConfigDELMONTH_KEIHO() As String
        Return ConfigurationSettings.AppSettings("DELMONTH_KEIHO")
    End Function

    '�`�o���O�c�a�폜�Ώۊ���
    <WebMethod()> Public Function mGetConfigDELMONTH_APLOG() As String
        Return ConfigurationSettings.AppSettings("DELMONTH_APLOG")
    End Function

    '�o�b�`���O�c�a�폜�Ώۊ���
    <WebMethod()> Public Function mGetConfigDELMONTH_BATLOG() As String
        Return ConfigurationSettings.AppSettings("DELMONTH_BATLOG")
    End Function

    '�d�b���O�c�a�폜�Ώۊ���
    <WebMethod()> Public Function mGetConfigDELMONTH_TELLOG() As String
        Return ConfigurationSettings.AppSettings("DELMONTH_TELLOG")
    End Function

    '�ꎞ�쐬�t�@�C���폜�Ώۊ���
    <WebMethod()> Public Function mGetConfigDELMONTH_FILE() As String
        Return ConfigurationSettings.AppSettings("DELMONTH_FILE")
    End Function

    '�`�o���O�o�b�N�A�b�v�t�@�C���폜�Ώۊ���
    <WebMethod()> Public Function mGetConfigDELMONTH_APLOG_BACKFILE() As String
        Return ConfigurationSettings.AppSettings("DELMONTH_APLOG_BACKFILE")
    End Function

    '�o�b�N�A�b�v�t�@�C���폜�Ώۊ���
    <WebMethod()> Public Function mGetConfigDELMONTH_BACKFILE() As String
        Return ConfigurationSettings.AppSettings("DELMONTH_BACKFILE")
    End Function

    '����FAX���O�폜�Ώۊ��� 2016/12/27 T.Ono add 2016���P�J�� ��12
    <WebMethod()> Public Function mGetConfigDELMONTH_AUTOFAXLOGDB() As String
        Return ConfigurationSettings.AppSettings("DELMONTH_AUTOFAXLOGDB")
    End Function

    '����FAX��r�p�Ή��ް��폜�Ώۊ��� 2016/12/27 T.Ono add 2016���P�J�� ��12
    <WebMethod()> Public Function mGetConfigDELMONTH_AUTOFAXTAIDB() As String
        Return ConfigurationSettings.AppSettings("DELMONTH_AUTOFAXTAIDB")
    End Function

    'FAX�T�[�o�[���M���O�폜�Ώۊ��� 2016/12/27 T.Ono add 2016���P�J�� ��12
    <WebMethod()> Public Function mGetConfigDELMONTH_FAXOUTBOXLOG() As String
        Return ConfigurationSettings.AppSettings("DELMONTH_FAXOUTBOXLOG")
    End Function

    '���O�t�@�C���p�X
    <WebMethod()> Public Function mGetConfigLOGPATH() As String
        Return ConfigurationSettings.AppSettings("LOGPATH")
    End Function

    'EXCEL�ꎞ�o�͗p�t�H���_�p�X
    <WebMethod()> Public Function mGetConfigEXCELPATH() As String
        Return ConfigurationSettings.AppSettings("EXCELPATH")
    End Function

    '�e�L�X�g�t�@�C���p�X
    <WebMethod()> Public Function mGetConfigTEXTPATH() As String
        Return ConfigurationSettings.AppSettings("TEXTPATH")
    End Function

    '�`�o���O�o�b�N�A�b�v�t�@�C���o�̓p�X
    <WebMethod()> Public Function mGetConfigAPLOG_BACKPATH() As String
        Return ConfigurationSettings.AppSettings("APLOG_BACKPATH")
    End Function

    '�o�b�N�A�b�v�t�@�C���o�̓p�X
    <WebMethod()> Public Function mGetConfigBACKPATH() As String
        Return ConfigurationSettings.AppSettings("BACKPATH")
    End Function

    '�e�s�o�p�X
    <WebMethod()> Public Function mGetConfigFTPPATH() As String
        Return ConfigurationSettings.AppSettings("FTPPATH")
    End Function

    '�d�w�d�p�X
    <WebMethod()> Public Function mGetConfigEXEPATH() As String
        Return ConfigurationSettings.AppSettings("EXEPATH")
    End Function
End Class
