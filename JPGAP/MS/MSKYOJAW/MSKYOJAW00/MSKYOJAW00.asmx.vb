'***********************************************
'�����Z���^�[�}�X�^
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


<System.Web.Services.WebService(Namespace:="http://tempuri.org/MSKYOJAW00/Service1")> _
Public Class MSKYOJAW00
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
    '�����Z���^�[�}�X�^���X�g�f�[�^�擾
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
                                    ByVal pstrKENCD As String, _
                                    ByVal pstrKYOKYUCD() As String, _
                                    ByVal pstrKYOKYUNM() As String, _
                                    ByVal pstrDEL() As String, _
                                    ByVal pstrADD_DATE As String, _
                                    ByVal pstrEDT_DATE As String, _
                                    ByVal pstrTIME As String, _
                                    ByVal pstrADD_DT() As String, _
                                    ByVal pstrEDT_DT() As String) As String

        ' ------------------------------
        ' strAUTO_MAIL�z�����ŗp��
        Dim strKYOKYUCD() As String
        strKYOKYUCD = New String(pstrKYOKYUCD.Length) {} '�z��̎��̂��m��
        Dim strKYOKYUNM() As String
        strKYOKYUNM = New String(pstrKYOKYUNM.Length) {} '�z��̎��̂��m��
        Dim strDEL() As String
        strDEL = New String(pstrDEL.Length) {} '�z��̎��̂��m��
        Dim i As Integer
        For i = 0 To strKYOKYUCD.Length
            strKYOKYUCD(i) = ""
            strKYOKYUNM(i) = ""
            strDEL(i) = ""
        Next
        ' ------------------------------

        Return mSetEx(pintMODE, _
                    pstrKENCD, _
                    pstrKYOKYUCD, _
                    pstrKYOKYUNM, _
                    pstrDEL, _
                    pstrADD_DATE, _
                    pstrEDT_DATE, _
                    pstrTIME, _
                    pstrADD_DT, _
                    pstrEDT_DT)
    End Function

    <WebMethod()> Public Function mSetEx( _
                                    ByVal pintMODE As Integer, _
                                    ByVal pstrKENCD As String, _
                                    ByVal pstrKYOKYUCD() As String, _
                                    ByVal pstrKYOKYUNM() As String, _
                                    ByVal pstrDEL() As String, _
                                    ByVal pstrADD_DATE As String, _
                                    ByVal pstrEDT_DATE As String, _
                                    ByVal pstrTIME As String, _
                                    ByVal pstrADD_DT() As String, _
                                    ByVal pstrEDT_DT() As String) As String
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
            For i = 1 To 30 '30�����P�����o�^�^�C���^�폜����B
                strRes = mSetKyokyu( _
                        cdb, _
                        pintMODE, _
                        pstrKENCD, _
                        pstrKYOKYUCD(i), _
                        pstrKYOKYUNM(i), _
                        pstrDEL(i), _
                        pstrADD_DT(i), _
                        pstrEDT_DATE, _
                        pstrTIME, _
                        pstrEDT_DT(i))

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
    '�����Z���^�[�}�X�^�X�V
    '************************************************
    <WebMethod()> Public Function mSetKyokyu( _
                                ByRef cdb As CDB, _
                                ByVal pintMODE As Integer, _
                                ByVal pstrKENCD As String, _
                                ByVal pstrKYOKYUCD As String, _
                                ByVal pstrKYOKYUNM As String, _
                                ByVal pstrDEL As String, _
                                ByVal pstrADD_DATE As String, _
                                ByVal pstrEDT_DATE As String, _
                                ByVal pstrTIME As String, _
                                ByVal pstrEDT_DT As String) As String
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
            strSQL.Append("  KEN_CD, ")
            strSQL.Append("  HAISO_CD, ")
            strSQL.Append("  NAME, ")
            strSQL.Append("  EDT_DATE, ")                    '�X�V��
            strSQL.Append("  TIME ")                        '�X�V����
            strSQL.Append("FROM ")
            strSQL.Append("  HAIMAS ")                      '�����Z���^�[�}�X�^
            strSQL.Append("WHERE KEN_CD  =:KEN_CD  ")       '���R�[�h
            strSQL.Append("  AND HAISO_CD =:HAISO_CD ")     '�����Z���^�[�R�[�h
            strSQL.Append("FOR UPDATE NOWAIT ")             '�r�������������

            'SQL���Z�b�g
            cdb.pSQL = strSQL.ToString

            '�p�����[�^�ɒl���Z�b�g
            cdb.pSQLParamStr("KEN_CD") = pstrKENCD           '���R�[�h
            cdb.pSQLParamStr("HAISO_CD") = pstrKYOKYUCD       '�����Z���^�[�R�[�h

            'SQL���s
            cdb.mExecQuery()
            ds = cdb.pResult

            '*******************************
            ' ���[�h�̍Č���
            '*******************************
            If (ds.Tables(0).Rows.Count <> 0) Then '�c�a�Ƀf�[�^�����݂���H
                If pintMODE = 4 Then 'pintMODE=4(�폜)
                    If pstrDEL = "true" Then '�o�^���f�[�^�͂Ȃ��H
                        pintMODE = 3 '���[�h��3�F�폜
                    Else
                        pintMODE = 4 '���[�h��2�F�X�V
                    End If
                Else
                    pintMODE = 2 '���[�h��2�F�X�V
                End If
            Else
                If pstrKYOKYUCD = "" Then '�o�^���f�[�^�͂Ȃ��H
                    pintMODE = 4 '���[�h��4�F�X�L�b�v
                ElseIf pstrDEL = "true" Then
                    pintMODE = 4 '���[�h��4�F�X�L�b�v
                    strRes = "0"
                Else
                    pintMODE = 1 '���[�h��1�F�V�K
                End If
            End If

            If (pintMODE = 2) Then '�c�a�Ƀf�[�^�����݂��āA�X�V�̏ꍇ
                '*******************************************
                '�C�����Ŏ󂯓n���ꂽ���t�y�ю��ԂƍX�V�Ώۃf�[�^���قȂ�ꍇ�G���[
                '*******************************************
                tmp = Convert.ToString(ds.Tables(0).Rows(0).Item("EDT_DATE")) & Convert.ToString(ds.Tables(0).Rows(0).Item("TIME"))
                If (tmp <> pstrEDT_DT) Then
                    strRes = "0"
                    Exit Try
                End If

                '*******************************************
                ' �C�����Ńf�[�^���ύX����Ă��Ȃ��ꍇ�̓X�L�b�v
                '*******************************************
                If ( _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("HAISO_CD")) = pstrKYOKYUCD) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("NAME")) = pstrKYOKYUNM) _
                     ) Then

                    pintMODE = 4 '�X�L�b�v
                End If
            End If

            If pintMODE = 4 Then
                '�X�L�b�v�����̃��R�[�h
                Exit Try
            End If
            '�c�a�`�F�b�N-----------------------------------
            '�o�^�C�����A�i�`�S���҂̏ꍇ�́A�N���C�A���g�R�[�h�̑��݃`�F�b�N���s��
            If (pintMODE = 1 Or pintMODE = 2) Then

                strSQL = New StringBuilder("")
                strSQL.Append("SELECT DISTINCT ")
                strSQL.Append(" KEN_CODE ")                     '���R�[�h
                strSQL.Append("FROM ")
                strSQL.Append("CLIMAS ")                        '�N���C�A���g�}�X�^
                strSQL.Append("WHERE KANSI_CODE IS NOT NULL ")  '�N���C�A���g�R�[�h
                strSQL.Append("AND KEN_CODE = :KEN_CD ")         '�N���C�A���g�R�[�h

                'SQL���Z�b�g
                cdb.pSQL = strSQL.ToString

                '�p�����[�^�ɒl���Z�b�g
                cdb.pSQLParamStr("KEN_CD") = pstrKENCD

                'SQL���s
                cdb.mExecQuery()
                ds = cdb.pResult

                If (ds.Tables(0).Rows.Count = 0) Then
                    '*******************************************
                    '���R�[�h�����݂��Ȃ���
                    '*******************************************
                    strRes = "4"
                    Exit Try
                End If
            End If

            '�f�[�^�̍X�V����--------------------------------

            If pintMODE = 3 Then
                '�����敪���폜
                strSQL = New StringBuilder("")
                strSQL.Append("DELETE ")
                strSQL.Append("FROM ")
                strSQL.Append("HAIMAS ")                        '�����Z���^�[�}�X�^
                strSQL.Append("WHERE KEN_CD  =:KEN_CD  ")       '���R�[�h
                strSQL.Append("  AND HAISO_CD =:HAISO_CD ")     '�����Z���^�[�R�[�h

            ElseIf pintMODE = 2 Then
                '�����敪���C��
                strSQL = New StringBuilder("")
                strSQL.Append("UPDATE ")
                strSQL.Append("HAIMAS ")
                strSQL.Append("SET ")
                strSQL.Append("KEN_CD      = :KEN_CD, ")
                strSQL.Append("HAISO_CD    = :HAISO_CD, ")
                strSQL.Append("NAME        = :NAME, ")
                strSQL.Append("ADD_DATE   = :ADD_DATE, ")
                strSQL.Append("EDT_DATE   = :EDT_DATE, ")
                strSQL.Append("TIME       = :TIME ")
                strSQL.Append("WHERE   ")
                strSQL.Append("      KEN_CD  =:KEN_CD  ")        '���R�[�h
                strSQL.Append("  AND HAISO_CD =:HAISO_CD ")      '�����Z���^�[�R�[�h

            ElseIf pintMODE = 1 Then
                '�����敪���V�K
                strSQL = New StringBuilder("")
                strSQL.Append("INSERT INTO ")
                strSQL.Append("HAIMAS (")
                strSQL.Append("KEN_CD, ")
                strSQL.Append("HAISO_CD, ")
                strSQL.Append("NAME, ")
                strSQL.Append("ADD_DATE, ")
                strSQL.Append("EDT_DATE, ")
                strSQL.Append("TIME ")
                strSQL.Append(") VALUES(")
                strSQL.Append(":KEN_CD, ")
                strSQL.Append(":HAISO_CD, ")
                strSQL.Append(":NAME, ")
                strSQL.Append(":ADD_DATE, ")
                strSQL.Append(":EDT_DATE, ")
                strSQL.Append(":TIME ")
                strSQL.Append(")")
            End If

            'SQL���Z�b�g
            cdb.pSQL = strSQL.ToString
            '�o�C���h�ϐ��ɒl���Z�b�g
            If pintMODE = 3 Then
                cdb.pSQLParamStr("KEN_CD") = pstrKENCD           '���R�[�h
                cdb.pSQLParamStr("HAISO_CD") = pstrKYOKYUCD         '�����Z���^�[�R�[�h
            ElseIf pintMODE = 1 Or pintMODE = 2 Then

                cdb.pSQLParamStr("KEN_CD") = pstrKENCD           '���R�[�h
                cdb.pSQLParamStr("HAISO_CD") = pstrKYOKYUCD       '�����Z���^�[�R�[�h
                cdb.pSQLParamStr("NAME") = pstrKYOKYUNM       '�����Z���^�[��

                If pintMODE = 1 Then
                    '�V�K�o�^�̏ꍇ
                    cdb.pSQLParamStr("ADD_DATE") = Now.ToString("yyyyMMdd")
                    cdb.pSQLParamStr("EDT_DATE") = ""
                Else
                    '�C���o�^�̏ꍇ
                    cdb.pSQLParamStr("ADD_DATE") = pstrADD_DATE
                    cdb.pSQLParamStr("EDT_DATE") = Now.ToString("yyyyMMdd")
                End If
                cdb.pSQLParamStr("TIME") = Now.ToString("HHmmss")
            End If

            'SQL�����s
            cdb.mExecNonQuery()

        Catch ex As NullReferenceException
            strRes = "0"
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
    '*�@�T�@�v:���v�ƍX�V�E�폜�ꗗ�̏o�͂��s���܂�
    '*�@���@�l:
    '******************************************************************************
    '�@DATA0:�Ώۃf�[�^������܂���
    <WebMethod()> Public Function mCSV( _
                                        ByVal pstrSessionID As String, _
                                        ByVal pstrKENCD As String _
                                        ) As String

        Dim strSQL As New StringBuilder("")
        Dim cdb As New CDB
        Dim ds As New DataSet
        Dim dr As DataRow
        Dim CSVC As New CCSV                            'CSV�N���X
        Dim compressC As New CCompress                  '���k�N���X
        Dim DateFncC As New CDateFnc                    '���t�ϊ��N���X
        Dim CTimeFncC As New CTimeFnc                   '���ԕϊ��N���X
        Dim FileToStrC As New CFileStr                  '�t�@�C����Base64�ɃG���R�[�h����N���X
        Dim intPrntRow As Integer = 72

        Dim strTmp() As String

        Dim i As Integer ' 2011/05/17 T.Watabe add


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
            strSQL.Append("  KEN_CD, ")
            strSQL.Append("  HAISO_CD, ")
            strSQL.Append("  NAME, ")
            strSQL.Append("  ADD_DATE, ")                   '�X�V��
            strSQL.Append("  EDT_DATE, ")                   '�X�V��
            strSQL.Append("  TIME ")                        '�X�V����
            strSQL.Append("FROM ")
            strSQL.Append("  HAIMAS ")                      '�����Z���^�[�}�X�^
            strSQL.Append("WHERE KEN_CD  =:KEN_CD  ")         '���R�[�h
            strSQL.Append("ORDER BY TO_NUMBER(HAISO_CD)  ")   '���R�[�h
            'SQL���Z�b�g
            cdb.pSQL = strSQL.ToString

            '�p�����[�^�ɒl���Z�b�g
            cdb.pSQLParamStr("KEN_CD") = pstrKENCD           '���R�[�h

            'SQL���s
            cdb.mExecQuery()
            ds = cdb.pResult
            CSVC.pKencd = "00"
            CSVC.pSessionID = pstrSessionID   '�Z�b�V����ID
            CSVC.pRepoID = "MSKYOJAW00"       '���[ID
            CSVC.mOpen()
            Dim iCnt As Integer
            Dim irCnt As Integer
            For iCnt = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(iCnt)
                If iCnt = 0 Then
                    CSVC.pColValStrEx = "���R�[�h"
                    CSVC.pColValStrEx = "�����Z���^�[�R�[�h"
                    CSVC.pColValStrEx = "�����Z���^�[��"
                    CSVC.pColValStrEx = "�o�^��"
                    CSVC.pColValStrEx = "�X�V��"
                    CSVC.pColValStrEx = "�X�V����"
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
            '�G���[�̓��e�Ƃr�p�k����Ԃ�baba
            Return "ERROR:" & ex.ToString

        Finally
            cdb.mClose()        '�ڑ��N���[�Y
        End Try

    End Function
    '**********************************************************
    ' 2012/06/28 ADD W.GANEKO
    '���O�f���o��
    '�߂�l�F�������񂾃t�@�C���ւ̃t���p�X
    '**********************************************************
    Public Sub mlog(ByVal pstrString As String)
        Dim strFilnm As String = "testKyokyu" & System.DateTime.Today.ToString("yyyyMMdd")
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
