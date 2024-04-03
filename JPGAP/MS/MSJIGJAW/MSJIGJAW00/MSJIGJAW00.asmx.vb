'***********************************************
'�����Ή��O���[�v�}�X�^
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


<System.Web.Services.WebService(Namespace:="http://tempuri.org/MSJIGJAW00/Service1")> _
Public Class MSJIGJAW00
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
    '�S���҃}�X�^���X�g�f�[�^�擾
    '************************************************
    '�y���ʁz
    '  OK : ����ɏI�����܂���
    '   0 : ���̃��[�U�[�ɂ���ăf�[�^���X�V����Ă��܂��B�ēx�������Ă�������
    '   1 : ���Ƀf�[�^�����݂��܂�
    '   2 : �Ώۃf�[�^�����݂��܂���
    '   3 : �r�����䏈���ŃG���[���������܂����B�ēx���s���Ă�������
    ' ----------------------------------------------
    <WebMethod()> Public Function mSet( _
                                    ByVal pintMODE As Integer, _
                                    ByVal pstrKURACD() As String, _
                                    ByVal pstrACBCD() As String, _
                                    ByVal pstrGROUPCD() As String, _
                                    ByVal pstrUSE_FLG() As String, _
                                    ByVal pstrINS_DATE() As String, _
                                    ByVal pstrUPD_DATE() As String, _
                                    ByVal pstrBIKO() As String, _
                                    ByVal pstrDEL() As String
                                    ) As String

        ' ------------------------------
        '�z�����ŗp��
        Dim strKURACD() As String
        strKURACD = New String(pstrKURACD.Length) {} '�z��̎��̂��m��
        Dim strACBCD() As String
        strACBCD = New String(pstrACBCD.Length) {} '�z��̎��̂��m��
        Dim strGROUPCD() As String
        strGROUPCD = New String(pstrGROUPCD.Length) {} '�z��̎��̂��m��
        Dim strUSE_FLG() As String
        strUSE_FLG = New String(pstrUSE_FLG.Length) {} '�z��̎��̂��m��
        Dim strINS_DATE() As String
        strINS_DATE = New String(pstrINS_DATE.Length) {} '�z��̎��̂��m��
        Dim strUPD_DATE() As String
        strUPD_DATE = New String(pstrUPD_DATE.Length) {} '�z��̎��̂��m��
        Dim strBIKO() As String
        strBIKO = New String(pstrBIKO.Length) {} '�z��̎��̂��m��
        Dim strDEL() As String
        strDEL = New String(pstrDEL.Length) {} '�z��̎��̂��m��

        Dim i As Integer
        For i = 0 To strKURACD.Length
            strKURACD(i) = ""
            strACBCD(i) = ""
            strGROUPCD(i) = ""
            strUSE_FLG(i) = ""
            strINS_DATE(i) = ""
            strUPD_DATE(i) = ""
            strBIKO(i) = ""
            strDEL(i) = ""
        Next
        ' ------------------------------

        Return mSetEx(pintMODE, _
                    pstrKURACD, _
                    pstrACBCD, _
                    pstrGROUPCD, _
                    pstrUSE_FLG, _
                    pstrINS_DATE, _
                    pstrUPD_DATE, _
                    pstrBIKO, _
                    pstrDEL)
    End Function

    <WebMethod()> Public Function mSetEx( _
                                    ByVal pintMODE As Integer, _
                                    ByVal pstrKURACD() As String, _
                                    ByVal pstrACBCD() As String, _
                                    ByVal pstrGROUPCD() As String, _
                                    ByVal pstrUSE_FLG() As String, _
                                    ByVal pstrINS_DATE() As String, _
                                    ByVal pstrUPD_DATE() As String, _
                                    ByVal pstrBIKO() As String, _
                                    ByVal pstrDEL() As String
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
            For i = 1 To pstrKURACD.Length - 1 '�P�����o�^�^�C���^�폜����B
                mlog("loop:" & pstrDEL(i) & pstrKURACD(i) & "_" & pstrACBCD(i) & "_" & pstrGROUPCD(i))

                strRes = mSetTanto( _
                        cdb, _
                        pintMODE, _
                        pstrKURACD(i), _
                        pstrACBCD(i), _
                        pstrGROUPCD(i), _
                        pstrUSE_FLG(i), _
                        pstrINS_DATE(i), _
                        pstrUPD_DATE(i), _
                        pstrBIKO(i), _
                        pstrDEL(i))

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
    '�S���҃}�X�^�X�V
    '************************************************
    <WebMethod()> Public Function mSetTanto( _
                                ByRef cdb As CDB, _
                                ByVal pintMODE As Integer, _
                                ByVal pstrKURACD As String, _
                                ByVal pstrACBCD As String, _
                                ByVal pstrGROUPCD As String, _
                                ByVal pstrUSE_FLG As String, _
                                ByVal pstrINS_DATE As String, _
                                ByVal pstrUPD_DATE As String, _
                                ByVal pstrBIKO As String, _
                                ByVal pstrDEL As String
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
            strSQL.Append("	    A.KURACD ")
            strSQL.Append("	    ,A.ACBCD ")
            strSQL.Append("	    ,A.GROUPCD ")
            strSQL.Append("	    ,A.USE_FLG ")
            strSQL.Append("	    ,A.INS_DATE ")
            strSQL.Append("	    ,A.UPD_DATE ")
            strSQL.Append("	    ,A.BIKO ")
            strSQL.Append("FROM ")
            strSQL.Append("	    M07_AUTOTAIOUGROUP A ")
            strSQL.Append("WHERE ")
            strSQL.Append("	    A.KURACD = :KURACD ")
            strSQL.Append("AND	A.ACBCD = :ACBCD ")
            strSQL.Append("ORDER BY KURACD, ACBCD ")
            strSQL.Append("FOR UPDATE NOWAIT ")             '�r�������������

            'SQL���Z�b�g
            cdb.pSQL = strSQL.ToString

            '�p�����[�^�ɒl���Z�b�g
            cdb.pSQLParamStr("KURACD") = pstrKURACD         '�N���C�A���g�R�[�h
            cdb.pSQLParamStr("ACBCD") = pstrACBCD           'JA�x���R�[�h

            'SQL���s
            cdb.mExecQuery()
            ds = cdb.pResult

            '*******************************
            ' ���[�h�̍Č���
            '*******************************
            If (ds.Tables(0).Rows.Count <> 0) Then '�c�a�Ƀf�[�^�����݂���H
                If pintMODE = 4 Then 'pintMODE=4(�폜)
                    If pstrDEL = "true" Then '�폜�Ώۃ`�F�b�N����H 
                        pintMODE = 3 '���[�h��3�F�폜
                    Else
                        pintMODE = 4 '���[�h��4�F�X�L�b�v
                    End If
                Else
                    pintMODE = 2 '���[�h��2�F�X�V
                End If
            Else
                If pstrKURACD = "" Then '�o�^���f�[�^�͂Ȃ��H
                    pintMODE = 4 '���[�h��4�F�X�L�b�v
                ElseIf pstrDEL = "true" Then
                    pintMODE = 4 '���[�h��4�F�X�L�b�v
                    strRes = "0" '�폜�Ώۃf�[�^���Ȃ�
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
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("KURACD")) = pstrKURACD) And _
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("ACBCD")) = pstrACBCD) And _
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("GROUPCD")) = pstrGROUPCD) And _
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("USE_FLG")) = pstrUSE_FLG) And _
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
            '�o�^�C�����A
            If (pintMODE = 1 Or pintMODE = 2) Then

                '*******************************************
                '�N���C�A���g�R�[�h�̑��݃`�F�b�N
                strSQL = New StringBuilder("")
                strSQL.Append("SELECT  ")
                strSQL.Append(" CLI_CD ")
                strSQL.Append("FROM ")
                strSQL.Append(" CLIMAS ")
                strSQL.Append("WHERE CLI_CD = :CLI_CD ")
                'SQL���Z�b�g
                cdb.pSQL = strSQL.ToString

                '�p�����[�^�ɒl���Z�b�g
                cdb.pSQLParamStr("CLI_CD") = pstrKURACD

                'SQL���s
                cdb.mExecQuery()
                ds = cdb.pResult

                If (ds.Tables(0).Rows.Count = 0) Then
                    '*******************************************
                    '�N���C�A���g�R�[�h�����݂��Ȃ���
                    '*******************************************
                    strRes = "4"
                    Exit Try
                End If

                '*******************************************
                'JA�x���R�[�h�̑��݃`�F�b�N
                strSQL = New StringBuilder("")
                strSQL.Append("SELECT ")
                strSQL.Append("		A.HAN_CD ")
                strSQL.Append("FROM ")
                strSQL.Append("		HN2MAS A ")
                strSQL.Append("WHERE ")
                strSQL.Append("		A.CLI_CD = :CLI_CD ")
                strSQL.Append("AND	A.HAN_CD = :JA_CD ")
                strSQL.Append("AND	NVL(A.DEL_FLG,'0') <> '1' ")
                strSQL.Append("AND	NOT EXISTS( ")
                strSQL.Append("			SELECT	'X' ")
                strSQL.Append("			FROM	HN2MAS B ")
                strSQL.Append("			WHERE	A.CLI_CD = B.CLI_CD ")
                strSQL.Append("			AND		A.HAN_CD = B.JA_CD ")
                strSQL.Append("			) ")
                strSQL.Append("ORDER BY A.CLI_CD, A.HAN_CD ")
                'SQL���Z�b�g
                cdb.pSQL = strSQL.ToString

                '�p�����[�^�ɒl���Z�b�g
                cdb.pSQLParamStr("CLI_CD") = pstrKURACD
                cdb.pSQLParamStr("JA_CD") = pstrACBCD

                'SQL���s
                cdb.mExecQuery()
                ds = cdb.pResult

                If (ds.Tables(0).Rows.Count = 0) Then
                    '*******************************************
                    'JA�x���R�[�h�����݂��Ȃ���
                    '*******************************************
                    strRes = "5"
                    Exit Try
                End If
            End If

            '�f�[�^�̍X�V����--------------------------------

            If pintMODE = 3 Then
                '�����敪���폜
                strSQL = New StringBuilder("")
                strSQL.Append("DELETE ")
                strSQL.Append("FROM ")
                strSQL.Append("			M07_AUTOTAIOUGROUP ")
                strSQL.Append("WHERE ")
                strSQL.Append("			KURACD =:KURACD ")          '�N���C�A���g�R�[�h
                strSQL.Append("AND		ACBCD =:ACBCD ")            '�x��R�[�h

            ElseIf pintMODE = 2 Then
                '�����敪���C��
                strSQL = New StringBuilder("")
                strSQL.Append("UPDATE ")
                strSQL.Append("         M07_AUTOTAIOUGROUP ")
                strSQL.Append("SET ")
                strSQL.Append("     	KURACD = :KURACD, ")
                strSQL.Append("     	ACBCD = :ACBCD, ")
                strSQL.Append("     	GROUPCD = :GROUPCD, ")
                strSQL.Append("     	USE_FLG = :USE_FLG, ")
                strSQL.Append("     	INS_DATE = TO_DATE(:INS_DATE, 'YYYY/MM/DD HH24:MI:SS'), ")
                strSQL.Append("     	UPD_DATE = TO_DATE(:UPD_DATE, 'YYYY/MM/DD HH24:MI:SS'), ")
                strSQL.Append("     	BIKO = :BIKO ")
                strSQL.Append("WHERE   ")
                strSQL.Append("         KURACD =:KURACD  ")
                strSQL.Append("  AND    ACBCD =:ACBCD ")

            ElseIf pintMODE = 1 Then
                '�����敪���V�K
                strSQL = New StringBuilder("")
                strSQL.Append("INSERT INTO ")
                strSQL.Append(" M07_AUTOTAIOUGROUP (")
                strSQL.Append("     KURACD, ")
                strSQL.Append("     ACBCD, ")
                strSQL.Append("     GROUPCD, ")
                strSQL.Append("     USE_FLG, ")
                strSQL.Append("     INS_DATE, ")
                strSQL.Append("     UPD_DATE, ")
                strSQL.Append("     BIKO ")
                strSQL.Append(") VALUES(")
                strSQL.Append("		:KURACD, ")
                strSQL.Append("		:ACBCD, ")
                strSQL.Append("		:GROUPCD, ")
                strSQL.Append("		:USE_FLG, ")
                strSQL.Append("		TO_DATE(:INS_DATE, 'YYYY/MM/DD HH24:MI:SS'), ")
                strSQL.Append("		TO_DATE(:UPD_DATE, 'YYYY/MM/DD HH24:MI:SS'), ")
                strSQL.Append("		:BIKO ")
                strSQL.Append(")")
            End If

            'SQL���Z�b�g
            cdb.pSQL = strSQL.ToString
            '�o�C���h�ϐ��ɒl���Z�b�g
            If pintMODE = 3 Then
                cdb.pSQLParamStr("KURACD") = pstrKURACD
                cdb.pSQLParamStr("ACBCD") = pstrACBCD
            ElseIf pintMODE = 1 Or pintMODE = 2 Then

                cdb.pSQLParamStr("KURACD") = pstrKURACD
                cdb.pSQLParamStr("ACBCD") = pstrACBCD
                cdb.pSQLParamStr("GROUPCD") = pstrGROUPCD
                If pstrUSE_FLG = "" Then
                    cdb.pSQLParamStr("USE_FLG") = "1"
                Else
                    cdb.pSQLParamStr("USE_FLG") = pstrUSE_FLG
                End If
                cdb.pSQLParamStr("BIKO") = pstrBIKO

                If pintMODE = 1 Then
                    '�V�K�o�^�̏ꍇ
                    cdb.pSQLParamStr("INS_DATE") = Now.ToString()
                    cdb.pSQLParamStr("UPD_DATE") = ""
                Else
                    '�C���o�^�̏ꍇ
                    cdb.pSQLParamStr("INS_DATE") = pstrINS_DATE
                    cdb.pSQLParamStr("UPD_DATE") = Now.ToString()
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
                                        ByVal pstrACBCD_F As String, _
                                        ByVal pstrACBCD_T As String, _
                                        ByVal pstrGROUPCD As String _
                                        ) As String

        Dim strSQL As New StringBuilder("")
        Dim cdb As New CDB
        Dim ds As New DataSet
        Dim dr As DataRow
        Dim CSVC As New CCSV                            'CSV�N���X
        'Dim compressC As New CCompress                  '���k�N���X
        'Dim DateFncC As New CDateFnc                    '���t�ϊ��N���X
        'Dim CTimeFncC As New CTimeFnc                   '���ԕϊ��N���X
        'Dim FileToStrC As New CFileStr                  '�t�@�C����Base64�ɃG���R�[�h����N���X

        '�ڑ�OPEN----------------------------------------
        Try
            cdb.mOpen()
        Catch ex As Exception
            Return ex.ToString
        Finally
        End Try
        Try
            strSQL = New StringBuilder("")
            strSQL.Append("SELECT ")
            strSQL.Append("	    A.KURACD ")
            strSQL.Append("	    ,A.ACBCD ")
            strSQL.Append("	    ,A.GROUPCD ")
            strSQL.Append("	    ,A.USE_FLG ")
            strSQL.Append("	    ,A.BIKO ")
            strSQL.Append("	    ,A.INS_DATE ")
            strSQL.Append("	    ,A.UPD_DATE ")
            strSQL.Append("FROM ")
            strSQL.Append("	    M07_AUTOTAIOUGROUP A ")
            strSQL.Append("WHERE	1=1 ")
            If pstrKURACD.Trim.Length > 0 Then
                strSQL.Append("AND  A.KURACD = :KURACD ")
            End If
            If pstrACBCD_F.Trim.Length > 0 Then
                strSQL.Append("AND  A.ACBCD >=:ACBCD_F ")
            End If
            If pstrACBCD_T.Trim.Length > 0 Then
                strSQL.Append("AND  A.ACBCD <=:ACBCD_T ")
            End If
            If pstrGROUPCD.Trim.Length > 0 Then
                strSQL.Append("AND  A.GROUPCD = :GROUPCD ")
            End If
            strSQL.Append("ORDER BY KURACD, ACBCD ")
            'SQL���Z�b�g
            cdb.pSQL = strSQL.ToString

            '�p�����[�^�ɒl���Z�b�g
            '�N���C�A���g�R�[�h
            If pstrKURACD.Trim.Length > 0 Then
                cdb.pSQLParamStr("KURACD") = pstrKURACD
            End If
            'JA�x���R�[�h
            If pstrACBCD_F.Trim.Length > 0 Then
                cdb.pSQLParamStr("ACBCD_F") = pstrACBCD_F
            End If
            If pstrACBCD_T.Trim.Length > 0 Then
                cdb.pSQLParamStr("ACBCD_T") = pstrACBCD_T
            End If
            '�O���[�v�R�[�h
            If pstrGROUPCD.Trim.Length > 0 Then
                cdb.pSQLParamStr("GROUPCD") = pstrGROUPCD
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
            CSVC.pRepoID = "MSJIGJAW00"       '���[ID
            CSVC.mOpen()
            Dim iCnt As Integer
            Dim irCnt As Integer
            For iCnt = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(iCnt)

                If iCnt = 0 Then
                    CSVC.pColValStrEx = "�N���C�A���g�R�[�h"
                    CSVC.pColValStrEx = "JA�x���R�[�h"
                    CSVC.pColValStrEx = "�O���[�v�R�[�h"
                    CSVC.pColValStrEx = "�g�p�t���O"
                    CSVC.pColValStrEx = "���l"
                    CSVC.pColValStrEx = "�o�^����"
                    CSVC.pColValStrEx = "�X�V����"
                    CSVC.mWriteLine()
                End If

                For irCnt = 0 To dr.Table.Columns.Count - 1
                    CSVC.pColValStrEx = Convert.ToString(dr.Item(irCnt))
                    'CSVC.pColVal = "=""" & Convert.ToString(dr.Item(irCnt)) & """"
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
        Dim strFilnm As String = "testGroup" & System.DateTime.Today.ToString("yyyyMMdd")
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
