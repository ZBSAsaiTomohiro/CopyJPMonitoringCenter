'***********************************************
'�����f�[�^����
'***********************************************
Option Explicit On 
Option Strict On

Imports System.Web.Services
Imports System.Configuration

<System.Web.Services.WebService(Namespace:="http://tempuri.org/SYGETJAW00/Service1")> _
Public Class SYGETJAW00
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
        components = New System.ComponentModel.Container
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

    'EXE���s
    '******************************************************************************
    '*�@�T�@�v�FEXE�̎��s
    '*�@���@�l�F�p�����[�^�Ƃ���
    '*�@�@�@�@�F�P�D�Ώۓ��t
    '*�@�@�@�@�F�Q�D�����Ώۓ��t�@
    '*�@�@�@�@�F�R�D�����Ώۓ��t�A
    '*�@�@�@�@�F�S�D�����Ώۓ��t�B
    '*�@�@�@�@�F�[�D���O�L�[
    '******************************************************************************
    'OK     : �n�j
    'else   : ���s�G���[(catch���e)
    <WebMethod()> Public Function mExec( _
                                            ByVal pstrTrgDateM As String, _
                                            ByVal pstrTrgDate1 As String, _
                                            ByVal pstrTrgDate2 As String, _
                                            ByVal pstrTrgDate3 As String, _
                                            ByVal pstrDelmonth_ApLog As String, _
                                            ByVal pstrDelmonth_BatLog As String, _
                                            ByVal pstrDelmonth_TelLog As String, _
                                            ByVal pstrDelmonth_File As String, _
                                            ByVal pstrDelmonth_BackFile As String, _
                                            ByVal pDate As String, _
                                            ByVal pTime As String _
                                            ) As String
        Dim strRec As String
        strRec = "OK"

        Try
            'EXE���N������-------------------------------
            '<< �p�����[�^ >>
            Dim strAregs(11) As String

            strAregs(0) = pstrTrgDateM
            strAregs(1) = pstrTrgDate1
            strAregs(2) = pstrTrgDate2
            strAregs(3) = pstrTrgDate3
            strAregs(4) = pstrDelmonth_ApLog
            strAregs(5) = pstrDelmonth_BatLog
            strAregs(6) = pstrDelmonth_TelLog
            strAregs(7) = pstrDelmonth_File
            strAregs(8) = pstrDelmonth_BackFile
            strAregs(9) = pDate
            strAregs(10) = pTime

            Dim strAreg As String
            Dim intProc As Integer
            strAreg = Join(strAregs, ",")
            ' 2022/12/21 MOD START Y.ARAKAKI 2022�X��No�C _�f�[�^������ʂ̉�ʃt���[�Y�̉����Ή�
            ''2012/03/07 NEC Upd ou
            ''intProc = Shell(ConfigurationSettings.AppSettings("EXEPATH") & _
            ''                "BTGETJAE00.exe " & strAreg, _
            ''                AppWinStyle.Hide, False)
            'intProc = Shell(ConfigurationSettings.AppSettings("EXEPATH") &
            '    "BTGETJAE00.exe ",
            '    AppWinStyle.Hide, True)
            intProc = Shell(ConfigurationSettings.AppSettings("EXEPATH") &
                "BTGETJAE00.exe ",
                AppWinStyle.Hide, False)
            ' 2022/12/21 MOD END   Y.ARAKAKI 2022�X��No�C _�f�[�^������ʂ̉�ʃt���[�Y�̉����Ή�

        Catch ex As Exception
            '�G���[���e���i�[
            strRec = ex.ToString
        Finally
            '//
        End Try

        Return strRec

    End Function

End Class
