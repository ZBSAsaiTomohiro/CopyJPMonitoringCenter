Option Explicit On 
Option Strict On

Imports Common.DB

Imports System.Web.Services
Imports System.Text

<System.Web.Services.WebService(Namespace:="http://tempuri.org/KEKESJAW00/Service1")> _
Public Class KEKESJAW00
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

    '************************************************
    '�p�����[�^�����ԍ��f�[�^�̃��b�N�t���O������(NULL)���܂�
    '************************************************
    <WebMethod()> Public Function mDel(ByVal pintDelCnt As Integer, ByVal pstrDelKeys As String) As String
        Dim ds As New DataSet
        Dim cdb As New CDB
        Dim strRes As String
        Dim strSQL As StringBuilder

        strRes = "OK"

        '------------------------------------------------
        '�ڑ�OPEN----------------------------------------
        Try
            cdb.mOpen()
        Catch ex As Exception
            strRes = ex.ToString
            Return strRes
        Finally

        End Try

        Try
            '------------------------------------------------
            '�g�����U�N�V�����J�n--------------------------
            cdb.mBeginTrans()

            '*********************************
            '�����X�g�[���[
            '[-]���ɂȂ��B�폜�̂�
            '*********************************

            '------------------------------------------------
            '�J���}�ҏW��z��ɕҏW
            Dim arrDelKey As String()
            arrDelKey = fncArrayOut(pstrDelKeys, pintDelCnt)

            '------------------------------------------------
            '�c�a�X�V�i���b�N�����j----------------------------
            strSQL = New StringBuilder("")
            strSQL.Append("")
            strSQL.Append("DELETE FROM ")
            strSQL.Append("T11_KEIHOFILE ")                         '�x��t�@�C���c�a
            strSQL.Append("WHERE FILE_NAME =:FILE_NAME ")           '�x��t�@�C����

            'SQL���Z�b�g
            cdb.pSQL = strSQL.ToString

            Dim i As Integer
            For i = 0 To pintDelCnt - 1
                '�p�����[�^�Z�b�g
                cdb.pSQLParamStr("FILE_NAME") = arrDelKey(i)     '�x��t�@�C����
                'SQL�����s
                cdb.mExecNonQuery()
            Next

            '�R�~�b�g
            cdb.mCommit()
        Catch ex As Exception
            '�G���[���N������ �G���[���e���i�[
            strRes = ex.ToString
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


    '******************************************************************************
    '*�@�T�@�v�F�z��Ƃ��Ď擾
    '*�@���@�l�FPublic Function
    '******************************************************************************
    Private Function fncArrayOut(ByVal pstrArrBox As String, ByVal pintArr As Integer) As String()
        Dim intLop As Integer
        Dim intIdx As Integer
        Dim strCut As String = ","
        Dim strTmp As String
        Dim arrRec() As String
        ReDim arrRec(pintArr)

        intIdx = 0
        For intLop = 1 To Len(pstrArrBox)
            If Len(pstrArrBox) = intLop Then
                If Mid(pstrArrBox, intLop, 1) <> strCut Then
                    strTmp = strTmp & Mid(pstrArrBox, intLop, 1)
                    arrRec(intIdx) = strTmp
                    strTmp = ""
                ElseIf Mid(pstrArrBox, intLop, 1) = strCut Then
                    arrRec(intIdx) = strTmp
                    strTmp = ""

                    intIdx += 1
                    arrRec(intIdx) = strTmp
                    strTmp = ""
                End If
            ElseIf Mid(pstrArrBox, intLop, 1) = strCut Then
                arrRec(intIdx) = strTmp
                intIdx += 1
                strTmp = ""
            Else
                strTmp = strTmp & Mid(pstrArrBox, intLop, 1)
            End If
        Next

        Return arrRec
    End Function
End Class
