Option Strict On

Imports Common.DB

Imports System.Web.Services
Imports System.Text


<System.Web.Services.WebService(Namespace := "http://tempuri.org/JPGAP.COCOMONW00/CLOG")> _
Public Class CLOG
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

    <WebMethod()> Public Function mAPLog(ByVal pSession_Id As String, ByVal pUser_Id As String, _
                                         ByVal pIp_Address As String, ByVal pProc_Id As String, _
                                         ByVal pExec_Status As String, ByVal pResult As String, _
                                         ByVal pDs As DataSet) As String
        ''--------------------------------------------------------------------------------
        ''SESSION_ID    �Z�b�V�����h�c  
        ''LOGINCD       ����WINDOWS���[�U�[�R�[�h
        ''IPADR         �h�o�A�h���X
        ''PROC_ID       �v���O�����h�c
        ''EXEC_STATUS   ���s�敪
        ''TEXT          ��ʂ����Form���
        ''MSG           ���b�Z�[�W
        ''ADD_DATE      ���R�[�h�쐬��
        ''TIME          ���R�[�h�X�V����
        ''--------------------------------------------------------------------------------
        Dim cdb As New CDB
        Dim dr As DataRow
        Dim strSQL As New StringBuilder("")

        Dim i As Integer
        Dim strText As String

        '���ʃf�[�^������
        mAPLog = "OK"

        '�����œn���ꂽ�J������
        Dim strColName As String

        '�����œn���ꂽ�J�����̒l
        Dim strColVal As String
        Dim intColCnt As Integer

        '�f�[�^���[�^�Ɉ����̃f�[�^�Z�b�g���i�[
        dr = pDs.Tables(0).Rows(0)

        '�f�[�^���[�̃J�����̐����擾
        intColCnt = dr.ItemArray.GetUpperBound(0)

        '�J�����̐��������[�v
        strText = ""
        For i = 0 To intColCnt
            '�J������
            strColName = dr.Table.Columns(i).ColumnName
            '�J�����̒l
            strColVal = Convert.ToString(dr.Item(i))
            '����e�L�X�g�Ɋi�[
            strText = strText & strColName & "=" & strColVal & ";"
        Next

        Try
            'DB�I�[�v��
            cdb.mOpen()
            cdb.mBeginTrans()
            strSQL.Append("INSERT INTO S03_APLOGDB (")
            strSQL.Append("SESSION_ID, ")
            strSQL.Append("LOGINCD, ")
            strSQL.Append("IPADR, ")
            strSQL.Append("PROC_ID, ")
            strSQL.Append("EXEC_STATUS, ")
            strSQL.Append("TEXT, ")
            strSQL.Append("MSG, ")
            strSQL.Append("ADD_DATE, ")
            strSQL.Append("TIME ")
            strSQL.Append(") VALUES (")
            strSQL.Append(":SESSION_ID, ")
            strSQL.Append(":LOGINCD, ")
            strSQL.Append(":IPADR, ")
            strSQL.Append(":PROC_ID, ")
            strSQL.Append(":EXEC_STATUS, ")
            strSQL.Append(":TEXT, ")
            strSQL.Append(":MSG, ")
            strSQL.Append(":ADD_DATE, ")
            strSQL.Append(":TIME ")
            strSQL.Append(")")

            'SQL
            cdb.pSQL = strSQL.ToString

            '�p�����[�^�ɒl���Z�b�g
            cdb.pSQLParamStr("SESSION_ID") = pSession_Id
            cdb.pSQLParamStr("LOGINCD") = pUser_Id
            cdb.pSQLParamStr("IPADR") = pIp_Address
            cdb.pSQLParamStr("PROC_ID") = pProc_Id
            cdb.pSQLParamStr("EXEC_STATUS") = pExec_Status
            cdb.pSQLParamStr("TEXT") = strText
            cdb.pSQLParamStr("MSG") = pResult
            cdb.pSQLParamStr("ADD_DATE") = Format(Now, "yyyyMMdd")      '�쐬��
            cdb.pSQLParamStr("TIME") = Format(Now, "HHmmss")      '�쐬����

            cdb.mExecNonQuery()
            cdb.mCommit()
        Catch
            '�G���[������������A�G���[����Ԃ�
            mAPLog = cdb.pErr & ErrorToString()
            cdb.mRollback()
        Finally
            'DB�N���[�Y
            cdb.mClose()
        End Try
    End Function


    <WebMethod()> Public Function mBTLog_Start(ByVal pDate As String, ByVal pTime As String, ByVal pProc_Id As String) As String
        ''--------------------------------------------------------------------------------
        ''             �@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@|�J�n��|�I����|
        ''PROC_ID      �v���O�����h�c�@�@�@�@�@�@�@�@�@|�@���@|�@���@|�@Key�Ƃ��Ďg�p�@(�p�����[�^)
        ''ST_YMD       �J�n�N�����@�@�@�@�@�@�@�@�@�@�@|�@���@|�@���@|�@Key�Ƃ��Ďg�p�@(�p�����[�^)
        ''ST_TIME      �J�n�����@�@�@�@�@�@�@�@�@�@�@�@|�@���@|�@���@|�@Key�Ƃ��Ďg�p�@(�p�����[�^)
        ''ED_YMD       �I���N�����@�@�@�@�@�@�@�@�@�@�@|�@�@�@|�@���@|�@(�p�����[�^)
        ''ED_TIME      �I�������@�@�@�@�@�@�@�@�@�@�@�@|�@�@�@|�@���@|�@(�p�����[�^)
        ''EXEC_SEC     ���s���ԁ@�@�@�@�@�@�@�@�@�@�@�@|�@�@�@|�@���@|�@(�p�����[�^)
        ''PROJ_STATUS  �v���W�F�N�g���s��ԁ@�@�@�@�@�@|�@�@�@|�@���@|�@(�p�����[�^)�@�@�o�^����NULL
        ''EXEC_STATUS  �����X�e�[�^�X�@�@�@�@�@�@�@�@�@|�@���@|�@���@|�@(�p�����[�^)�@�@�o�^���͂O:������
        ''MSG          ���s���b�Z�[�W�F�G���[���e�@�@�@|�@�@�@|�@���@|�@(�p�����[�^)
        ''FILE_NM      �t�@�C�����i�A�����̂݁j�@�@�@�@|�@�@�@|�@���@|�@(�p�����[�^)
        ''ADD_DATE     ���R�[�h�쐬���@�@�@�@�@�@�@�@�@|�@���@|�@�@�@|
        ''TIME         ���R�[�h�X�V�����@�@�@�@�@�@�@�@|�@���@|�@�@�@|
        ''--------------------------------------------------------------------------------
        Dim cdb As New CDB
        Dim strSQL As New StringBuilder("")
        mBTLog_Start = "OK"

        Try
            'DB�I�[�v��
            cdb.mOpen()
            cdb.mBeginTrans()
            'SQL
            strSQL.Append("INSERT INTO S02_BACHDB( ")
            strSQL.Append(" PROC_ID, ")
            strSQL.Append(" ST_YMD, ")
            strSQL.Append(" ST_TIME, ")
            strSQL.Append(" EXEC_STATUS, ")
            strSQL.Append(" ADD_DATE, ")
            strSQL.Append(" TIME ")
            strSQL.Append(") VALUES (")
            strSQL.Append(" :PROC_ID, ")
            strSQL.Append(" :ST_YMD, ")
            strSQL.Append(" :ST_TIME, ")
            strSQL.Append(" :EXEC_STATUS, ")
            strSQL.Append(" :ADD_DATE, ")
            strSQL.Append(" :TIME ")
            strSQL.Append(")")
            'SQL Set
            cdb.pSQL = strSQL.ToString
            '�p�����[�^�ɒl���Z�b�g
            cdb.pSQLParamStr("PROC_ID") = pProc_Id
            cdb.pSQLParamStr("ST_YMD") = pDate
            cdb.pSQLParamStr("ST_TIME") = pTime
            cdb.pSQLParamStr("EXEC_STATUS") = "0"           '0�F�������ɂēo�^
            cdb.pSQLParamStr("ADD_DATE") = pDate
            cdb.pSQLParamStr("TIME") = pTime
            'Execute
            cdb.mExecNonQuery()
            cdb.mCommit()
        Catch ex As Exception
            '�G���[������������A�G���[����Ԃ�
            mBTLog_Start = cdb.pErr & ex.ToString & ";�s�ԍ�:" & Err.Erl & ";�I�u�W�F�N�g:" & Err.Source
            cdb.mRollback()
        Finally
            'DB�N���[�Y
            cdb.mClose()

        End Try
    End Function
    <WebMethod()> Public Function mBTLog_END(ByVal pDate As String, ByVal pTime As String, _
                                             ByVal pProc_Id As String, ByVal pEDate As String, _
                                             ByVal pETime As String, ByVal pESec As Decimal, _
                                             ByVal pPStatus As String, ByVal pEStatus As String, _
                                             ByVal pEResult As String) As String
        Dim cdb As New CDB
        Dim strSQL As New StringBuilder("")
        mBTLog_END = "OK"
        Try
            'DB�I�[�v��
            cdb.mOpen()
            cdb.mBeginTrans()
            'SQL
            strSQL.Append("UPDATE S02_BACHDB SET ")
            strSQL.Append("ED_YMD      = :ED_YMD, ")
            strSQL.Append("ED_TIME     = :ED_TIME, ")
            strSQL.Append("EXEC_SEC = CASE WHEN :EXEC_SEC>999999 THEN 999999 ELSE :EXEC_SEC END , ")
            strSQL.Append("PROJ_STATUS = :PROJ_STATUS, ")
            strSQL.Append("EXEC_STATUS = :EXEC_STATUS, ")
            strSQL.Append("MSG         = SUBSTRB(:MSG,1,100) ")
            strSQL.Append("WHERE PROC_ID = :PROC_ID")
            strSQL.Append("  AND ST_YMD  = :ST_YMD")
            strSQL.Append("  AND ST_TIME = :ST_TIME")
            'SQL Set
            cdb.pSQL = strSQL.ToString
            '�p�����[�^�ɒl���Z�b�g
            cdb.pSQLParamStr("PROC_ID") = pProc_Id
            cdb.pSQLParamStr("ST_YMD") = pDate
            cdb.pSQLParamStr("ST_TIME") = pTime
            cdb.pSQLParamStr("ED_YMD") = pEDate
            cdb.pSQLParamStr("ED_TIME") = pETime
            cdb.pSQLParamDec("EXEC_SEC") = pESec
            cdb.pSQLParamStr("PROJ_STATUS") = pPStatus
            cdb.pSQLParamStr("EXEC_STATUS") = pEStatus
            cdb.pSQLParamStr("MSG") = pEResult
            'Execute
            cdb.mExecNonQuery()
            cdb.mCommit()
        Catch ex As Exception
            '�G���[������������A�G���[����Ԃ�
            mBTLog_END = strSQL.ToString & cdb.pErr & ex.ToString
            cdb.mRollback()
        Finally
            'DB�N���[�Y
            cdb.mClose()

        End Try
    End Function
End Class
