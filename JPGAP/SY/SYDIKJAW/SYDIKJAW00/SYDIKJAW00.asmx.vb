'***********************************************
'�ً}���Ď��Ɩ���s�ݒ�
'***********************************************
Option Explicit On 
Option Strict On

Imports System.Web.Services
Imports Common.DB
Imports System.Text

<System.Web.Services.WebService(Namespace:="http://tempuri.org/SYDIKJAW00/SYDIKJAW00")> _
Public Class SYDIKJAW00
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

    <WebMethod()> Public Function mSet( _
                                    ByVal pstrKANSCD As String, _
                                    ByVal pstrDAIKOKANSCD As String, _
                                    ByVal pstrMode As String) As String

        Dim ds As New DataSet
        Dim cdb As New cdb
        Dim strRes As String
        Dim strSQL As StringBuilder

        strRes = "OK"

        '�ڑ�OPEN----------------------------------------
        Try
            cdb.mOpen()
        Catch ex As Exception
            strRes = ex.ToString
            Return strRes
        Finally
        End Try

        Try
            Dim strDate As String = Now.ToString("yyyyMMdd")
            Dim strTime As String = Now.ToString("HHmmss")
            Dim pintKBN As Integer

            '�g�����U�N�V�����J�n--------------------------
            cdb.mBeginTrans()

            '�c�a�`�F�b�N(��{)-----------------------------
            strSQL = New StringBuilder("")
            strSQL.Append("SELECT ")
            strSQL.Append(" EDT_DATE, ")                '�X�V��
            strSQL.Append(" TIME ")                     '�X�V����
            strSQL.Append("FROM ")
            strSQL.Append("S01_DAIKO ")                 '��s�ݒ�
            strSQL.Append("WHERE KANSCD  =:KANSCD  ")
            strSQL.Append("FOR UPDATE NOWAIT ")         '�r�������������

            'SQL���Z�b�g
            cdb.pSQL = strSQL.ToString

            '�p�����[�^�ɒl���Z�b�g
            cdb.pSQLParamStr("KANSCD") = pstrKANSCD

            'SQL���s
            cdb.mExecQuery()
            ds = cdb.pResult

            If (ds.Tables(0).Rows.Count <> 0) Then
                '�o�^���ɓ���L�[�̃f�[�^�����݂��鎞

                If pstrMode = "1" Then
                    pintKBN = 1     '��s�ݒ�@�X�V���[�h
                End If
            Else
                '�o�^���ɓ���L�[�̃f�[�^�����݂��Ȃ���
                If pstrMode = "1" Then
                    pintKBN = 0     '��s�ݒ�@�V�K���[�h
                Else
                    strRes = "2"    '��s�����f�[�^�Ȃ�
                    Exit Try
                End If
            End If

            '//��s�ݒ胂�[�h
            If pstrMode = "1" Then
                If pintKBN = 1 Then
                    '���ю�c�a�X�V
                    strSQL = New StringBuilder("")
                    strSQL.Append("UPDATE ")
                    strSQL.Append("S01_DAIKO DAI ")
                    strSQL.Append("SET ")
                    strSQL.Append("DAIKOKANSCD = :DAIKOKANSCD, ")
                    strSQL.Append("EDT_DATE = :EDT_DATE, ")
                    strSQL.Append("TIME = :TIME ")
                    strSQL.Append("WHERE KANSCD = :KANSCD ")
                Else
                    '�V�K�o�^��
                    strSQL = New StringBuilder("")
                    strSQL.Append("INSERT INTO ")
                    strSQL.Append("S01_DAIKO (")
                    strSQL.Append("KANSCD, ")
                    strSQL.Append("DAIKOKANSCD, ")
                    strSQL.Append("ADD_DATE, ")
                    strSQL.Append("TIME ")
                    strSQL.Append(") VALUES(")
                    strSQL.Append(":KANSCD, ")
                    strSQL.Append(":DAIKOKANSCD, ")
                    strSQL.Append(":ADD_DATE, ")
                    strSQL.Append(":TIME ")
                    strSQL.Append(")")
                End If
            Else
                '//��s�������[�h
                strSQL = New StringBuilder("")
                strSQL.Append("DELETE ")
                strSQL.Append("FROM ")
                strSQL.Append("S01_DAIKO ")
                strSQL.Append("WHERE KANSCD = :KANSCD ")
            End If

            'SQL���Z�b�g
            cdb.pSQL = strSQL.ToString

            '�o�C���h�ϐ��ɒl���Z�b�g

            '//��s�ݒ胂�[�h
            If pstrMode = "1" Then

                If pintKBN = 1 Then
                    'UPDATE��
                    cdb.pSQLParamStr("EDT_DATE") = strDate
                Else
                    'INSERT��
                    cdb.pSQLParamStr("ADD_DATE") = strDate
                End If

                cdb.pSQLParamStr("DAIKOKANSCD") = pstrDAIKOKANSCD
                cdb.pSQLParamStr("TIME") = strTime
            End If
            cdb.pSQLParamStr("KANSCD") = pstrKANSCD

            'SQL�����s
            cdb.mExecNonQuery()
            '�R�~�b�g
            cdb.mCommit()

        Catch ex As Exception
            '�G���[���N������ �G���[���e���i�[
            strRes = ex.ToString

            '�r�����䏈���G���[
            If ErrorToString.Substring(0, 9) = "ORA-00054" Then
                Return "3"
            End If

            '���[���o�b�N
            cdb.mRollback()
            strRes = strRes & cdb.pErr
        Finally
            '�ڑ��N���[�Y
            cdb.mClose()
        End Try

        cdb = Nothing

        Return strRes
    End Function
End Class
