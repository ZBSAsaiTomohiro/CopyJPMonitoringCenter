'***********************************************
'�̔����Ǝ҃O���[�v�}�X�^
'***********************************************
' �ύX����

Option Explicit On
Option Strict On

Imports Common
Imports Common.DB

Imports System.Web.Services
Imports System.Text
Imports System.Configuration
Imports System.IO


<System.Web.Services.WebService(Namespace:="http://tempuri.org/MSHAGJAW00/Service1")> _
Public Class MSHAGJAW00
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

    'pintMODE
    '   1:�V�K�o�^
    '   2:�C���o�^
    '   3:�폜
    '************************************************
    '�̔����Ǝ҃O���[�v���X�g�f�[�^�擾
    '************************************************
    '�y���ʁz
    '  OK : ����ɏI�����܂���
    '   0 : ���̃��[�U�[�ɂ���ăf�[�^���X�V����Ă��܂��B�ēx�������Ă�������
    '   1 : ���Ƀf�[�^�����݂��܂�
    '   2 : �Ώۃf�[�^�����݂��܂���
    '   3 : �r�����䏈���ŃG���[���������܂����B�ēx���s���Ă�������
    ' ----------------------------------------------
    <WebMethod()> Public Function mSetEx( _
                                    ByVal pintMODE As Integer, _
                                    ByVal pstrTARGET() As String, _
                                    ByVal pstrGROUPCD() As String, _
                                    ByVal pstrGROUPNM() As String, _
                                    ByVal pstrHANJIGYOSYANM() As String, _
                                    ByVal pstrBIKO() As String, _
                                    ByVal pstrINS_DATE() As String, _
                                    ByVal pstrINS_USER() As String, _
                                    ByVal pstrUPD_DATE() As String, _
                                    ByVal pstrUPD_USER() As String, _
                                    ByVal pstrUSERNM As String _
                                    ) As String
        Dim ds As New DataSet
        Dim cdb As New CDB
        Dim strRes As String

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
            '�g�����U�N�V�����J�n--------------------------
            cdb.mBeginTrans()

            Dim i As Integer
            For i = 1 To pstrGROUPCD.Length - 1 '�P�����o�^�^�X�V�^�폜����B
                mlog("loop:" & pstrTARGET(i) & pstrGROUPCD(i) & "_" & pstrGROUPNM(i))

                If pstrTARGET(i) = "true" AndAlso pstrGROUPCD(i) <> "" Then
                    strRes = mSetMASTER( _
                                cdb, _
                                pintMODE, _
                                pstrTARGET(i), _
                                pstrGROUPCD(i), _
                                pstrGROUPNM(i), _
                                pstrHANJIGYOSYANM(i), _
                                pstrBIKO(i), _
                                pstrINS_DATE(i), _
                                pstrINS_USER(i), _
                                pstrUPD_DATE(i), _
                                pstrUPD_USER(i), _
                                pstrUSERNM, _
                                CStr(i))
                End If



                If strRes <> "OK" Then
                    Exit For
                End If
            Next

            If strRes = "OK" Then
                '�R�~�b�g
                cdb.mCommit()
            Else
                '���[���o�b�N
                cdb.mRollback()
            End If

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
    '************************************************
    '�̔����Ǝ҃O���[�v�}�X�^�X�V
    '************************************************
    <WebMethod()> Public Function mSetMASTER( _
                                ByRef cdb As CDB, _
                                ByVal pintMODE As Integer, _
                                ByVal pstrTARGET As String, _
                                ByVal pstrGROUPCD As String, _
                                ByVal pstrGROUPNM As String, _
                                ByVal pstrHANJIGYOSYANM As String, _
                                ByVal pstrBIKO As String, _
                                ByVal pstrINS_DATE As String, _
                                ByVal pstrINS_USER As String, _
                                ByVal pstrUPD_DATE As String, _
                                ByVal pstrUPD_USER As String, _
                                ByVal pstrUSERNM As String, _
                                ByVal pstrI As String _
                                ) As String

        Dim ds As New DataSet
        Dim strRes As String
        Dim strSQL As StringBuilder

        Dim tmp As String

        strRes = "OK"

        Try
            '*********************************
            '�����X�g�[���[
            '�E�r���̃`�F�b�N���s���B
            '�E�o�^���ɂ̓f�[�^�͖������݂��Ȃ�����
            '�E�C�����ɂ̓f�[�^�͑��݂��邱��
            '�E�Z���^�[�R�[�h�̑��݃`�F�b�N���s��
            '*********************************

            '�c�a�`�F�b�N(��{)-----------------------------
            strSQL = New StringBuilder("")
            strSQL.Append("SELECT ")
            strSQL.Append("	A.GROUPCD ")
            strSQL.Append("	,A.GROUPNM ")
            strSQL.Append("	,A.HANJIGYOSYANM ")
            strSQL.Append("	,A.BIKO ")
            strSQL.Append("	,TO_CHAR(A.INS_DATE, 'YYYY/MM/DD HH24:MI:SS') AS INS_DATE ")
            strSQL.Append("	,A.INS_USER ")
            strSQL.Append("	,TO_CHAR(A.UPD_DATE, 'YYYY/MM/DD HH24:MI:SS') AS UPD_DATE ")
            strSQL.Append("	,A.UPD_USER ")
            strSQL.Append("FROM M10_HANJIGYOSYA A ")
            strSQL.Append("WHERE A.GROUPCD = :GROUPCD ")
            strSQL.Append("ORDER BY GROUPCD ")
            strSQL.Append("FOR UPDATE NOWAIT ")             '�r�������������

            'SQL���Z�b�g
            cdb.pSQL = strSQL.ToString

            '�p�����[�^�ɒl���Z�b�g
            cdb.pSQLParamStr("GROUPCD") = pstrGROUPCD       '�O���[�v�R�[�h

            'SQL���s
            cdb.mExecQuery()
            ds = cdb.pResult


            '*******************************
            ' ���[�h�̍Č���
            '*******************************
            If (ds.Tables(0).Rows.Count <> 0) Then '�c�a�Ƀf�[�^�����݂���H
                If pintMODE = 4 Then '�폜�{�^������
                    pintMODE = 3 '���[�h��3�F�폜
                Else
                    pintMODE = 2 '���[�h��2�F�X�V
                End If
            Else
                If pintMODE = 4 Then
                    pintMODE = 4 '���[�h��4�F�X�L�b�v
                Else
                    pintMODE = 1 '���[�h��1�F�V�K
                End If
            End If


            If (pintMODE = 3) Then '�c�a�Ƀf�[�^�����݂��āA�폜�̏ꍇ
                '*******************************************
                '�폜���Ŏ󂯓n���ꂽ���t�y�ю��Ԃƍ폜�Ώۃf�[�^���قȂ�ꍇ�G���[
                '*******************************************
                tmp = Convert.ToString(ds.Tables(0).Rows(0).Item("INS_DATE")) & "_" & Convert.ToString(ds.Tables(0).Rows(0).Item("UPD_DATE"))
                If (tmp <> pstrINS_DATE & "_" & pstrUPD_DATE) Then
                    strRes = "0"
                    Exit Try
                End If
            End If


            If (pintMODE = 2) Then '�c�a�Ƀf�[�^�����݂��āA�X�V�̏ꍇ
                '*******************************************
                '�C�����Ŏ󂯓n���ꂽ���t�y�ю��ԂƍX�V�Ώۃf�[�^���قȂ�ꍇ�G���[
                '*******************************************
                tmp = Convert.ToString(ds.Tables(0).Rows(0).Item("INS_DATE")) & "_" & Convert.ToString(ds.Tables(0).Rows(0).Item("UPD_DATE"))
                If (tmp <> pstrINS_DATE & "_" & pstrUPD_DATE) Then
                    strRes = "0"
                    Exit Try
                End If

                '*******************************************
                ' �C�����Ńf�[�^���ύX����Ă��Ȃ��ꍇ�̓X�L�b�v
                '*******************************************
                If ( _
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("GROUPCD")) = pstrGROUPCD) And _
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("GROUPNM")) = pstrGROUPNM) And _
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("HANJIGYOSYANM")) = pstrHANJIGYOSYANM) And _
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("BIKO")) = pstrBIKO) _
                     ) Then

                    pintMODE = 4 '�X�L�b�v
                End If
            End If

            If pintMODE = 4 Then
                '�X�L�b�v�����̃��R�[�h
                Exit Try
            End If

            '�c�a�`�F�b�N-----------------------------------
            '�폜��
            If (pintMODE = 3) Then
                '*******************************************
                'JA�O���[�v�쐬�}�X�^�Ŏg���Ă��Ȃ����`�F�b�N
                strSQL = New StringBuilder("")
                strSQL.Append("SELECT 'X'")
                strSQL.Append("FROM ")
                strSQL.Append("	M09_JAGROUP A ")
                strSQL.Append("WHERE ")
                strSQL.Append("	A.KBN = '001' ")
                strSQL.Append("AND	A.GROUPCD = :GROUPCD ")
                'SQL���Z�b�g
                cdb.pSQL = strSQL.ToString
                '�o�C���h�ϐ��ɒl���Z�b�g
                cdb.pSQLParamStr("GROUPCD") = pstrGROUPCD
                'SQL���s
                cdb.mExecQuery()
                ds = cdb.pResult

                If (ds.Tables(0).Rows.Count > 0) Then
                    '*******************************************
                    'JA�O���[�v�쐬�}�X�^�Ŏg�p����Ă���
                    '*******************************************
                    strRes = "4"
                    Exit Try
                End If
            End If

            '�o�^/�X�V���A
            If (pintMODE = 1 Or pintMODE = 2) Then
                '*******************************************
                '�������̃`�F�b�N
                strSQL = New StringBuilder("")
                strSQL.Append("SELECT ")
                strSQL.Append("	A.CD ")
                strSQL.Append("	,A.NAME ")
                strSQL.Append("	,A.NAIYO1 ")
                strSQL.Append("	,A.NAIYO2 ")
                strSQL.Append("FROM ")
                strSQL.Append("		M06_PULLDOWN A ")
                strSQL.Append("WHERE ")
                strSQL.Append("		KBN = '78' ")
                strSQL.Append("AND	CD = '001' ")
                'SQL���Z�b�g
                cdb.pSQL = strSQL.ToString

                'SQL���s
                cdb.mExecQuery()
                ds = cdb.pResult

                If (ds.Tables(0).Rows.Count = 0) Then
                    '*******************************************
                    '�v���_�E���}�X�^�ɓo�^�����݂��Ȃ���
                    '*******************************************
                    strRes = "5"
                    Exit Try
                Else
                    If Convert.ToString(ds.Tables(0).Rows(0).Item("NAIYO1")) <> pstrGROUPCD.Substring(0, 2) Then
                        '*******************************************
                        '�������ᔽ�i�O���[�v�R�[�h�̐擪��NAIYO1�����ĂȂ��j
                        '*******************************************
                        strRes = "6" & pstrI.PadLeft(3, "0"c) '�G���[���{�s����Ԃ��@6001�`6100
                        Exit Try
                    End If
                End If
            End If


            '�f�[�^�̍X�V����--------------------------------
            If pintMODE = 3 Then
                '�����敪���폜
                strSQL = New StringBuilder("")
                strSQL.Append("DELETE ")
                strSQL.Append("FROM ")
                strSQL.Append("	    M10_HANJIGYOSYA ")
                strSQL.Append("WHERE ")
                strSQL.Append("     GROUPCD = :GROUPCD ")

            ElseIf pintMODE = 2 Then
                '�����敪���X�V
                strSQL = New StringBuilder("")
                strSQL.Append("UPDATE ")
                strSQL.Append("     M10_HANJIGYOSYA ")
                strSQL.Append("SET ")
                strSQL.Append("    	GROUPCD = :GROUPCD, ")
                strSQL.Append("    	GROUPNM = :GROUPNM, ")
                strSQL.Append("    	HANJIGYOSYANM = :HANJIGYOSYANM, ")
                strSQL.Append("    	BIKO = :BIKO, ")
                strSQL.Append("    	INS_DATE = TO_DATE(:INS_DATE, 'YYYY/MM/DD HH24:MI:SS'), ")
                strSQL.Append("    	INS_USER = :INS_USER, ")
                strSQL.Append("    	UPD_DATE = TO_DATE(:UPD_DATE, 'YYYY/MM/DD HH24:MI:SS'), ")
                strSQL.Append("    	UPD_USER = :UPD_USER ")
                strSQL.Append("WHERE ")
                strSQL.Append("     GROUPCD = :GROUPCD ")

            ElseIf pintMODE = 1 Then
                '�����敪���V�K
                strSQL = New StringBuilder("")
                strSQL.Append("INSERT INTO ")
                strSQL.Append(" M10_HANJIGYOSYA (")
                strSQL.Append("     GROUPCD, ")
                strSQL.Append("     GROUPNM, ")
                strSQL.Append("     HANJIGYOSYANM, ")
                strSQL.Append("     BIKO, ")
                strSQL.Append("     INS_DATE, ")
                strSQL.Append("     INS_USER, ")
                strSQL.Append("     UPD_DATE, ")
                strSQL.Append("     UPD_USER ")
                strSQL.Append(") VALUES(")
                strSQL.Append("		:GROUPCD, ")
                strSQL.Append("		:GROUPNM, ")
                strSQL.Append("		:HANJIGYOSYANM, ")
                strSQL.Append("		:BIKO, ")
                strSQL.Append("		TO_DATE(:INS_DATE, 'YYYY/MM/DD HH24:MI:SS'), ")
                strSQL.Append("		:INS_USER, ")
                strSQL.Append("		TO_DATE(:UPD_DATE, 'YYYY/MM/DD HH24:MI:SS'), ")
                strSQL.Append("		:UPD_USER ")
                strSQL.Append(")")
            End If

            'SQL���Z�b�g
            cdb.pSQL = strSQL.ToString
            '�o�C���h�ϐ��ɒl���Z�b�g
            If pintMODE = 3 Then
                cdb.pSQLParamStr("GROUPCD") = pstrGROUPCD

            ElseIf pintMODE = 1 Or pintMODE = 2 Then

                cdb.pSQLParamStr("GROUPCD") = pstrGROUPCD
                cdb.pSQLParamStr("GROUPNM") = pstrGROUPNM
                cdb.pSQLParamStr("HANJIGYOSYANM") = pstrHANJIGYOSYANM
                cdb.pSQLParamStr("BIKO") = pstrBIKO


                If pintMODE = 1 Then
                    '�V�K�o�^�̏ꍇ
                    cdb.pSQLParamStr("INS_DATE") = Now.ToString()
                    cdb.pSQLParamStr("INS_USER") = pstrUSERNM.Trim
                    cdb.pSQLParamStr("UPD_DATE") = ""
                    cdb.pSQLParamStr("UPD_USER") = ""
                Else
                    '�C���o�^�̏ꍇ
                    cdb.pSQLParamStr("INS_DATE") = pstrINS_DATE
                    cdb.pSQLParamStr("INS_USER") = pstrINS_USER
                    cdb.pSQLParamStr("UPD_DATE") = Now.ToString()
                    cdb.pSQLParamStr("UPD_USER") = pstrUSERNM.Trim
                End If

            End If

            'SQL�����s
            cdb.mExecNonQuery()


        Catch ex As Exception
            '�G���[���N������ �G���[���e���i�[
            strRes = ex.ToString

            '�r�����䏈���G���[
            If ErrorToString.Substring(0, 9) = "ORA-00054" Then
                Return "3"
            End If
            strRes = strRes & cdb.pErr
        Finally

        End Try

        Return strRes
    End Function
    '******************************************************************************
    '*�@�T�@�v:�ꗗ�̏o�͂��s���܂�
    '*�@���@�l:
    '******************************************************************************
    '�@DATA0:�Ώۃf�[�^������܂���
    <WebMethod()> Public Function mCSV( _
                                        ByVal pstrSessionID As String, _
                                        ByVal pstrKURACD As String, _
                                        ByVal pstrGROUPCD_F As String, _
                                        ByVal pstrGROUPCD_T As String _
                                        ) As String

        Dim strSQL As New StringBuilder("")
        Dim cdb As New CDB
        Dim ds As New DataSet
        Dim dr As DataRow
        Dim CSVC As New CCSV                            'CSV�N���X

        '�ڑ�OPEN----------------------------------------
        Try
            cdb.mOpen()
        Catch ex As Exception
            Return ex.ToString
        Finally
        End Try
        Try
            strSQL = New StringBuilder("")
            strSQL.Append("SELECT DISTINCT ")
            strSQL.Append("	A.GROUPCD ")
            strSQL.Append("	,A.GROUPNM ")
            strSQL.Append("	,A.HANJIGYOSYANM ")
            strSQL.Append("	,A.BIKO ")
            strSQL.Append("	,TO_CHAR(A.INS_DATE, 'YYYY/MM/DD HH24:MI:SS') AS INS_DATE ")
            strSQL.Append("	,A.INS_USER ")
            strSQL.Append("	,TO_CHAR(A.UPD_DATE, 'YYYY/MM/DD HH24:MI:SS') AS UPD_DATE ")
            strSQL.Append("	,A.UPD_USER ")
            strSQL.Append("FROM M10_HANJIGYOSYA A ")
            If pstrKURACD.Trim.Length > 0 Then
                strSQL.Append("	,M09_JAGROUP B ")
            End If
            strSQL.Append("WHERE 1=1 ")
            If pstrKURACD.Trim.Length > 0 Then
                strSQL.Append("AND B.KURACD = :KURACD ")
                strSQL.Append("AND A.GROUPCD = B.GROUPCD ")
            End If
            If pstrGROUPCD_F.Trim.Length > 0 Then
                strSQL.Append("AND A.GROUPCD >= :GROUPCD_F ")
            End If
            If pstrGROUPCD_T.Trim.Length > 0 Then
                strSQL.Append("AND A.GROUPCD <= :GROUPCD_T ")
            End If
            strSQL.Append("ORDER BY A.GROUPCD ")
            'SQL���Z�b�g
            cdb.pSQL = strSQL.ToString

            '�p�����[�^�ɒl���Z�b�g
            '�N���C�A���g�R�[�h
            If pstrKURACD.Trim.Length > 0 Then
                cdb.pSQLParamStr("KURACD") = pstrKURACD.Trim
            End If
            '�O���[�v�R�[�hFrom
            If pstrGROUPCD_F.Trim.Length > 0 Then
                cdb.pSQLParamStr("GROUPCD_F") = pstrGROUPCD_F.Trim
            End If
            '�O���[�v�R�[�hTo
            If pstrGROUPCD_T.Trim.Length > 0 Then
                cdb.pSQLParamStr("GROUPCD_T") = pstrGROUPCD_T.Trim
            End If


            'SQL���s
            cdb.mExecQuery()
            ds = cdb.pResult

            '�f�[�^�������ꍇ�͏I��
            If ds.Tables(0).Rows.Count = 0 Then
                Return "DATA0"
            End If

            CSVC.pKencd = "00"
            CSVC.pSessionID = pstrSessionID   '�Z�b�V����ID
            CSVC.pRepoID = "MSHAGJAW00"       '���[ID
            CSVC.mOpen()
            Dim iCnt As Integer
            Dim irCnt As Integer
            For iCnt = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(iCnt)

                If iCnt = 0 Then
                    CSVC.pColValStrEx = "�O���[�v�R�[�h"
                    CSVC.pColValStrEx = "�O���[�v�R�[�h��"
                    CSVC.pColValStrEx = "�̔����ƎҖ�"
                    CSVC.pColValStrEx = "���l"
                    CSVC.pColValStrEx = "�o�^����"
                    CSVC.pColValStrEx = "�o�^��"
                    CSVC.pColValStrEx = "�X�V����"
                    CSVC.pColValStrEx = "�X�V��"
                    CSVC.mWriteLine()
                End If

                For irCnt = 0 To dr.Table.Columns.Count - 1
                    CSVC.pColValStrEx = Convert.ToString(dr.Item(irCnt))
                Next
                CSVC.mWriteLine()
            Next
            CSVC.mClose()
            Return CSVC.pDirName & CSVC.pFileName
        Catch ex As Exception
            '�G���[�̓��e�Ƃr�p�k����Ԃ�
            Return "ERROR:" & ex.ToString

        Finally
            cdb.mClose()        '�ڑ��N���[�Y
        End Try

    End Function
    '**********************************************************
    '���O�f���o��
    '�߂�l�F�������񂾃t�@�C���ւ̃t���p�X
    '**********************************************************
    Public Sub mlog(ByVal pstrString As String)
        Dim strFilnm As String = "testKANSI" & System.DateTime.Today.ToString("yyyyMMdd")
        Dim strLogPath As String = ConfigurationSettings.AppSettings("LOG_OUT_PATH")
        Dim strPath As String = strLogPath & strFilnm & ".txt"
        Dim strLogFlg As String = ConfigurationSettings.AppSettings("LOG_OUT")
        If strLogFlg = "1" Then
            '�������݃t�@�C���ւ̃X�g���[��
            Dim outFile As New StreamWriter(strPath, True, System.Text.Encoding.Default)

            '�����̕�������X�g���[���ɏ�������
            outFile.Write(System.DateTime.Now & ":[" & pstrString + "]" & vbCrLf)

            '�������t���b�V���i�t�@�C���������݁j
            outFile.Flush()

            '�t�@�C���N���[�Y
            outFile.Close()
        End If
    End Sub
End Class
