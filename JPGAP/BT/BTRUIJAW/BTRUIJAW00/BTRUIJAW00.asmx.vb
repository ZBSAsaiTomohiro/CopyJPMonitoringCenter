'***********************************************
' �݌v���FAX��Ұّ��M����
' 2010/10/15 ZBS T.Watabe
'***********************************************
' �ύX����

Option Explicit On 
Option Strict On

Imports Common
Imports Common.DB

Imports System.Web.Services
Imports System.Configuration
Imports System.Text

'Imports java.util.zip 'vjslib.dll�ւ̎Q�Ɛݒ肪�K�v�ł� 

<System.Web.Services.WebService(Namespace:="http://tempuri.org/BTRUIJAW00/BTRUIJAW00")> _
Public Class BTRUIJAW00
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

    '�v���O�����h�c
    Dim strPGID As String

    <WebMethod()> Public Sub ReverseMessageSub(ByRef message As String)
        message = StrReverse(message)
    End Sub
    '==========================================================================================
    ' �c�a���O�o�^
    '==========================================================================================
    ' ���O���c�a�o�^
    <WebMethod()> Public Function insertLog2DB(ByVal id As Integer, _
                             ByVal sendType As String, _
                             ByVal resultStr As String, _
                             ByVal resultMemo As String) As Boolean
        Return insertLog2DB2(id, sendType, resultStr, resultMemo, "", "", False, Nothing)
    End Function
    <WebMethod()> Public Function insertLog2DB2(ByVal id As Integer, _
                             ByVal sendType As String, _
                             ByVal resultStr As String, _
                             ByVal resultMemo As String, _
                             ByVal filePath As String, _
                             ByVal reciveUser As String, _
                             ByVal bNowDispLog As Boolean, _
                             ByVal targetDate As Date) As Boolean

        Dim ds As New DataSet
        Dim cdb As New cdb
        Dim dr As DataRow
        Dim sql As New StringBuilder

        Dim targetDateStr As String = ""

        Dim re As Integer

        '---------------------------------------------
        '�ڑ�������̐ݒ�
        '---------------------------------------------
        cdb.pJPUID = ConfigurationSettings.AppSettings("DB_USER_ID")
        cdb.pJPPWD = ConfigurationSettings.AppSettings("DB_PASSWORD")
        cdb.pJPDB = ConfigurationSettings.AppSettings("DB_SID")

        '---------------------------------------------
        '�v�[���̍ŏ��l�ݒ�
        '---------------------------------------------
        cdb.pConnectPoolSize = 1

        '�ڑ�OPEN----------------------------------------
        Try
            cdb.mOpen()
        Catch ex As Exception
            Return False
        Finally

        End Try
        Try

            If IsNothing(targetDate) = False Then
                targetDateStr = targetDate.ToShortDateString 'yyyy/MM/dd
            End If

            '--------------------
            ' �o�^�pSQL�쐬
            '--------------------
            sql = New StringBuilder
            sql.Append("INSERT INTO B11_BTRUIJAE_LOG ")
            sql.Append("( ")
            sql.Append("    KEYDATE, ")
            sql.Append("    ID, ")
            sql.Append("    RESULT, ")
            sql.Append("    SEND_TYPE, ")
            sql.Append("    MEMO, ")
            sql.Append("    FILE_PATH, ")
            sql.Append("    RECIVE_USER, ")
            sql.Append("    SEND_TARGET_DATE ")
            sql.Append(") VALUES ( ")
            sql.Append("    SYSDATE, ")                ' KEYDATE
            sql.Append("    " & id & ", ")             ' ID
            sql.Append("    '" & resultStr & "', ")    ' ����
            sql.Append("    '" & sendType & "', ")     ' ���M���
            sql.Append("    '" & resultMemo & "', ")   ' ���ʃ���
            sql.Append("    '" & filePath & "', ")     ' �t�@�C���p�X
            sql.Append("    '" & reciveUser & "', ")   ' ��M��
            sql.Append("    TO_DATE('" & targetDateStr & "', 'YYYY/MM/DD') ")    ' ��M��
            sql.Append(")")

            '--------------------
            ' �g�����U�N�V�����J�n
            '--------------------
            cdb.mBeginTrans()

            cdb.pSQL = sql.ToString
            cdb.mExecQuery() 'SQL���s�I

            cdb.mCommit() '�R�~�b�g�I

            '--------------------
            ' ���O�\���ǉ�
            '--------------------
            If bNowDispLog Then '�ǉ�����H
                sql = New StringBuilder
                sql.Append("SELECT ")
                sql.Append("    TO_CHAR(SYSDATE, 'YYYY/MM/DD(DY) HH24:MI') AS DISP_DATE, ")
                sql.Append("    '" & targetDateStr & " " & resultStr & " ' || RPAD('" & reciveUser & "', 30) || RPAD(SUBSTR('" & filePath & "', (INSTR('" & filePath & "', '\', -1) + 1)), 45) AS INFO, ")
                sql.Append("    '" & resultMemo & "' AS MEMO  ")
                sql.Append("FROM ")
                sql.Append("    DUAL ")
                cdb.pSQL = sql.ToString
                cdb.mExecQuery() 'SQL���s�I

                '���ʂ��f�[�^�Z�b�g�Ɋi�[
                ds = cdb.pResult

                '�f�[�^�����݂��Ȃ��ꍇ
                If ds.Tables(0).Rows.Count = 0 Then
                    '�f�[�^��0��
                Else
                    dr = ds.Tables(0).Rows(0)
                    '                    txtLog.Text = Convert.ToString(dr.Item("DISP_DATE")) & " " & Convert.ToString(dr.Item("INFO")) & Convert.ToString(dr.Item("MEMO")) & vbCrLf & txtLog.Text
                End If

            End If

        Catch ex As Exception
            'fncWriteLog("�c�a���O�o�^�G���[ " & ex.ToString, "�Ď��V�X�e���F�ݐϏ�񎩓�FAX")
            ex = Nothing
            Return False
        Finally
            '�ڑ��N���[�Y
            cdb.mClose()
        End Try
        cdb = Nothing

        Return True

    End Function

    '==========================================================================================
    ' �c�a���烍�O����ʕ\��
    '==========================================================================================
    <WebMethod()> Public Function setDB2DispLog(ByRef dbLog As String) As Boolean
        Dim ds As New DataSet
        Dim cdb As New cdb
        Dim dr As DataRow
        Dim sql As New StringBuilder

        Dim msg As New StringBuilder



        '---------------------------------------------
        '�ڑ�������̐ݒ�
        '---------------------------------------------
        cdb.pJPUID = ConfigurationSettings.AppSettings("DB_USER_ID")
        cdb.pJPPWD = ConfigurationSettings.AppSettings("DB_PASSWORD")
        cdb.pJPDB = ConfigurationSettings.AppSettings("DB_SID")

        '---------------------------------------------
        '�v�[���̍ŏ��l�ݒ�
        '---------------------------------------------
        cdb.pConnectPoolSize = 1

        '�ڑ�OPEN----------------------------------------
        Try
            cdb.mOpen()
        Catch ex As Exception
            Return False
        Finally

        End Try
        Try
            'txtLog.Text = ""
            dbLog = ""

            '�g�����U�N�V�����J�n
            cdb.mBeginTrans()

            '�r�p�k�쐬
            sql.Append("SELECT ")
            sql.Append("    TO_CHAR(KEYDATE, 'YYYY/MM/DD(DY) HH24:MI') AS DISP_DATE, ")
            sql.Append("    TO_CHAR(SEND_TARGET_DATE, 'YYYY/MM/DD') || ' ' || RESULT || ' ' || RPAD(RECIVE_USER, 30) || RPAD(SUBSTR(FILE_PATH, (INSTR(FILE_PATH, '\', -1) + 1)), 45) AS INFO, ")
            sql.Append("    MEMO  ")
            sql.Append("FROM ")
            sql.Append("    B11_BTRUIJAE_LOG ")
            sql.Append("WHERE  ")
            sql.Append("    ID = 0 ")
            sql.Append("ORDER BY  ")
            sql.Append("    KEYDATE DESC ")
            cdb.pSQL = sql.ToString
            cdb.mExecQuery() 'SQL���s�I

            '���ʂ��f�[�^�Z�b�g�Ɋi�[
            ds = cdb.pResult

            '�f�[�^�����݂��Ȃ��ꍇ
            If ds.Tables(0).Rows.Count = 0 Then
                '�f�[�^��0���ł��邱�Ƃ������������Ԃ�
            Else
                Dim i As Integer
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    dr = ds.Tables(0).Rows(i)
                    'txtLog.Text += Convert.ToString(dr.Item("DISP_DATE")) & " " & Convert.ToString(dr.Item("INFO")) & Convert.ToString(dr.Item("MEMO")) & vbCrLf '2010/10/19 T.Watabe add
                    dbLog += Convert.ToString(dr.Item("DISP_DATE")) & " " & Convert.ToString(dr.Item("INFO")) & Convert.ToString(dr.Item("MEMO")) & vbCrLf
                Next
            End If

        Catch ex As Exception
            'fncWriteLog("�c�a���烍�O����ʕ\���G���[", "�Ď��V�X�e���F�ݐϏ�񎩓�FAX")
            dbLog = "BTRUIJAW00 ERROR:" & EX.ToString
            ex = Nothing
            Return False
        Finally
            '�ڑ��N���[�Y
            cdb.mClose()
        End Try
        cdb = Nothing

        Return True

    End Function

    '****************************************************************************************************




    '2008/12/15 T.Watabe add
    Function fncFileKill(ByVal sFilePath As String) As Boolean
        Dim bErr As Boolean
        bErr = False
        Try
            Kill(sFilePath)
        Catch ex As Exception
            bErr = True
        End Try
        Return bErr
    End Function

    '*****************************************************************
    '*�@�T�@�v�F�o�b�`���s���O���擾
    '*****************************************************************
    <WebMethod()> Public Function dispBatchLog(ByRef batchLog As String) As Boolean

        Dim ds As New DataSet
        Dim cdb As New cdb
        Dim dr As DataRow

        batchLog = ""

        'batchLog = "test"
        'Return True
        'Exit Function

        '---------------------------------------------
        '�ڑ�������̐ݒ�
        '---------------------------------------------
        'cdb.pJPUID = ConfigurationSettings.AppSettings("DB_USER_ID")
        'cdb.pJPPWD = ConfigurationSettings.AppSettings("DB_PASSWORD")
        'cdb.pJPDB = ConfigurationSettings.AppSettings("DB_SID")

        '---------------------------------------------
        '�v�[���̍ŏ��l�ݒ�
        '---------------------------------------------
        cdb.pConnectPoolSize = 1

        '�ڑ�OPEN----------------------------------------
        Try
            cdb.mOpen()
        Catch ex As Exception
            Return False
        Finally

        End Try

        Try
            '�g�����U�N�V�����J�n
            cdb.mBeginTrans()

            '�Ή��c�a�@D20_TAIOU
            Dim sql As New StringBuilder
            sql.Append("SELECT ")
            sql.Append("    TO_CHAR(TO_DATE(ST_YMD || ST_TIME,'YYYYMMDDHH24MISS'), 'YYYY/MM/DD HH24:MI') AS ST, ")
            sql.Append("    LPAD(TRUNC(EXEC_SEC / 1000,0), 5, ' ') || '�b' AS MIN, ")
            sql.Append("    SUBSTRB(MSG, 1,80) AS MSG ")
            sql.Append("FROM S02_BACHDB  ")
            sql.Append("WHERE PROC_ID = 'BTFAXJAE00' ")
            sql.Append("ORDER BY ST_YMD || ST_TIME DESC ")
            cdb.pSQL = sql.ToString
            cdb.mExecQuery() 'SQL���s�I

            '���ʂ��f�[�^�Z�b�g�Ɋi�[
            ds = cdb.pResult

            '�f�[�^�����݂��Ȃ��ꍇ
            If ds.Tables(0).Rows.Count = 0 Then

                batchLog = "0��"
            Else
                Dim i As Integer = 0
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    If i >= 50 Then Exit For '50���܂�

                    dr = ds.Tables(0).Rows(i)
                    'arrBatchLog.Add(Convert.ToString(dr.Item("ST")) & Convert.ToString(dr.Item("MIN")) & " " & Convert.ToString(dr.Item("MSG")))
                    If batchLog.Length > 0 Then batchLog = batchLog & "$$" '$$�͊֐�����擾�������s�t��������̉��s�����܂�����Ȃ��ׁB
                    batchLog = batchLog & Convert.ToString(dr.Item("ST")) & Convert.ToString(dr.Item("MIN")) & " " & Convert.ToString(dr.Item("MSG"))
                Next
            End If

        Catch ex As Exception
            batchLog = ex.ToString
            Return False
        Finally
            '�ڑ��N���[�Y
            cdb.mClose()
        End Try
        cdb = Nothing

        Return True

    End Function

    '==========================================================================================
    ' �c�a����f�[�^�ǂݍ���
    '==========================================================================================
    '<WebMethod()> Public Function setDB2DataTable(ByRef dt As DataTable) As Boolean
    <WebMethod()> Public Function setDB2DataTable() As Boolean

        Dim dt As DataTable

        ''---------------------
        '' �e�[�u���Ƀf�[�^��ǉ�
        ''---------------------
        'dt.Rows.Add(New [Object]() {1, 1, "3231", "01", "430", "430", "430010", "430010", "1", "1", "1", "0333502160", "0333502161", "watabe_tai@ja-lp.co.jp", "watabe-tai@z-bs.co.jp", "1", "OK", "2010/05/25", "2010/05/26", "", "2010/04/01", "2099/12/31", "���l�e�X�g�����������������������������������ĂƂȂɂʂ˂̂͂Ђӂւق܂݂ނ߂��������������"})
        'dt.Rows.Add(New [Object]() {2, 2, "3231", "03", "", "", "", "", "1", "1", "1", "0333502160", "", "watabe_tai@ja-lp.co.jp", "", "1", "NG", "2010/04/30", "2010/05/26", "1", "2010/09/01", "2011/12/31", ""})
        'dt.Rows.Add(New [Object]() {3, 3, "3232", "01", "", "", "", "", "1", "2", "1", "0333502160", "", "", "", "1", "", "", "2010/05/24", "", "2010/04/01", "2099/12/31", ""})
        'dt.Rows.Add(New [Object]() {4, 4, "3231", "01", "430", "430", "430010", "430010", "1", "1", "2", "", "", "watabe_tai@ja-lp.co.jp", "tai_de_r@hotmail.co.jp", "1", "OK", "2010/05/25", "2010/05/31", "", "2010/04/01", "2099/12/31", ""})
        'dt.Rows.Add(New [Object]() {5, 5, "3231", "01", "430", "430", "430010", "430010", "1", "1", "1", "0333502160", "", "", "", "", "OK", "2010/05/01", "2010/06/01", "", "2010/04/01", "2099/12/31", ""})

        Dim ds As New DataSet
        Dim cdb As New cdb
        Dim dr As DataRow
        Dim sql As New StringBuilder
        Dim i As Integer

        '---------------------------------------------
        '�ڑ�������̐ݒ�
        '---------------------------------------------
        cdb.pJPUID = ConfigurationSettings.AppSettings("DB_USER_ID")
        cdb.pJPPWD = ConfigurationSettings.AppSettings("DB_PASSWORD")
        cdb.pJPDB = ConfigurationSettings.AppSettings("DB_SID")

        '---------------------------------------------
        '�v�[���̍ŏ��l�ݒ�
        '---------------------------------------------
        cdb.pConnectPoolSize = 1

        '�ڑ�OPEN----------------------------------------
        Try
            cdb.mOpen()
        Catch ex As Exception
            Return False
        Finally

        End Try
        Try
            '--------------------
            ' �ǂяo���pSQL�쐬
            '--------------------
            sql = New StringBuilder
            sql.Append("SELECT ")
            sql.Append("    ID, ")
            sql.Append("    SEQ, ")
            sql.Append("    KURACD, ")
            sql.Append("    HAISO_CD, ")
            sql.Append("    ACBCD_FR, ")
            sql.Append("    ACBCD_TO, ")
            sql.Append("    HATKBN, ")
            sql.Append("    PAGEKBN, ")
            sql.Append("    PERIODKBN, ")
            sql.Append("    FAX1, ")
            sql.Append("    FAX2, ")
            sql.Append("    MAIL1, ")
            sql.Append("    MAIL2, ")
            sql.Append("    MAIL_PASSWORD, ")
            sql.Append("    ZEROSENDKBN, ")
            sql.Append("    JOTAI, ")
            sql.Append("    LASTSENDDATE, ")
            sql.Append("    NEXTSENDDATE, ")
            sql.Append("    SENDSTOPKBN, ")
            sql.Append("    SENDSTDATE, ")
            sql.Append("    SENDEDDATE, ")
            sql.Append("    BIKO, ")
            sql.Append("    DEL_FLG, ")
            sql.Append("    INS_DATE, ")
            sql.Append("    UPD_DATE ")
            sql.Append("FROM  ")
            sql.Append("  B10_BTRUIJAE ")
            sql.Append("WHERE ")
            sql.Append("    DEL_FLG = '0' ") ' �폜�t���O=0:�ʏ�
            sql.Append("ORDER BY ")
            sql.Append("    SEQ ")

            '--------------------
            ' �g�����U�N�V�����J�n
            '--------------------
            cdb.mBeginTrans()

            cdb.pSQL = sql.ToString
            cdb.mExecQuery() 'SQL���s�I
            ds = cdb.pResult '���ʂ��f�[�^�Z�b�g�Ɋi�[

            If ds.Tables(0).Rows.Count = 0 Then '�f�[�^�����݂��Ȃ��H
                '�����Ԃ�
                Return True
            Else
                dr = ds.Tables(0).Rows(0) '�f�[�^���[�Ƀf�[�^�Z�b�g���i�[
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    'Application.DoEvents()
                    'Me.Refresh()

                    dr = ds.Tables(0).Rows(i) '�f�[�^���[�Ƀf�[�^�Z�b�g���i�[

                    '---------------------
                    ' �e�[�u���Ƀf�[�^��ǉ�
                    '---------------------
                    dt.Rows.Add(New [Object]() { _
                                Convert.ToString(dr.Item(0)), _
                                Convert.ToString(dr.Item(1)), _
                                Convert.ToString(dr.Item(2)).Trim, _
                                Convert.ToString(dr.Item(3)).Trim, _
                                Convert.ToString(dr.Item(4)).Trim, _
                                Convert.ToString(dr.Item(5)).Trim, _
                                Convert.ToString(dr.Item(6)).Trim, _
                                Convert.ToString(dr.Item(7)).Trim, _
                                Convert.ToString(dr.Item(8)).Trim, _
                                Convert.ToString(dr.Item(9)).Trim, _
                                Convert.ToString(dr.Item(10)).Trim, _
                                Convert.ToString(dr.Item(11)).Trim, _
                                Convert.ToString(dr.Item(12)).Trim, _
                                Convert.ToString(dr.Item(13)).Trim, _
                                Convert.ToString(dr.Item(14)).Replace("0", ""), _
                                Convert.ToString(dr.Item(15)).Trim, _
                                formatStrYMD(Convert.ToString(dr.Item(16)).Trim), _
                                formatStrYMD(Convert.ToString(dr.Item(17)).Trim), _
                                Convert.ToString(dr.Item(18)).Replace("0", ""), _
                                formatStrYMD(Convert.ToString(dr.Item(19)).Trim), _
                                formatStrYMD(Convert.ToString(dr.Item(20)).Trim), _
                                Convert.ToString(dr.Item(21)).Trim})
                    'Try
                    '    �Z���ɐF�t��
                    '    If Convert.ToString(dr.Item(16)).Trim = "OK" Then
                    '        Dim dataTable1 As DataTable = DataGrid1.DataSource
                    '        dataTable1.Rows(0)
                    '        With DataGrid1.TableStyles(dataTable1.TableName)
                    '        End With
                    '    ElseIf Convert.ToString(dr.Item(16)).Trim = "NG" Then
                    '        dr.Item(16).BackColor = Color.Red
                    '    End If
                    'Catch ex As Exception
                    'End Try

                Next
            End If
        Catch ex As Exception
            'fncWriteLog("�c�a�ǂݍ��݃G���[ " & ex.ToString, "�Ď��V�X�e���F�ݐϏ�񎩓�FAX")
            ex = Nothing
            Return False
        Finally
            '�ڑ��N���[�Y
            cdb.mClose()
        End Try
        cdb = Nothing

        Return True
    End Function


    ' 2010/09/15 T.Watabe add
    '*****************************************************************
    '*�@�T�@�v�FDB SID��߂�
    '*****************************************************************
    <WebMethod()> Public Function getDBSID() As String
        Dim res As String = ""
        Try
            res = ConfigurationSettings.AppSettings("JPDB")
        Catch ex As Exception
            res = "JPDB �Q�ƃG���[:" & ex.ToString
        End Try
        Return res
    End Function

    '==========================================================================================
    ' ������؂�o���i��������͈͂������ꍇ�̃G���[����j
    '==========================================================================================
    Private Function subStr(ByVal ss As String, ByVal startPos As Integer, ByVal len As Integer) As String
        Dim ii As Integer = 0
        Dim res As String = ""
        Try
            ii = ss.Length
            If len <= 0 Then
                '�w�肪�Ԉ���Ă���
            ElseIf startPos < 0 Then
                '�w�肪�Ԉ���Ă���
            ElseIf len - startPos < 0 Then
                '�w�肪�Ԉ���Ă���
            ElseIf ss.Length <= 0 Then
                '���Ԃ�
            Else
                If ss.Length <= startPos Then
                    '���Ԃ�
                ElseIf ss.Length >= (startPos + len) Then
                    res = ss.Substring(startPos, len)
                Else
                    res = ss.Substring(startPos)
                End If
            End If
        Catch ex As Exception

        End Try
        Return res

    End Function

    '==========================================================================================
    ' ���t���������t�����ɕϊ�(yyyyMMdd��yyyy/MM/dd)
    '==========================================================================================
    Private Function formatStrYMD(ByVal strYMD As String) As String
        Dim buf As String
        Dim res As String = ""
        Try
            If IsNothing(strYMD) Then
            ElseIf strYMD.Length < 8 Then
            Else
                buf = strYMD.Substring(0, 4) & "/" & strYMD.Substring(4, 2) & "/" & strYMD.Substring(6, 2)
                If IsDate(buf) = True Then
                    res = buf
                End If
            End If
        Catch ex As Exception
        End Try
        Return res
    End Function

End Class
