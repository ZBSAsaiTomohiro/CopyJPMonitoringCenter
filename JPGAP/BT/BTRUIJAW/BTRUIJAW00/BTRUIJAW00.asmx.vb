'***********************************************
' 累計情報FAX＆ﾒｰﾙ送信処理
' 2010/10/15 ZBS T.Watabe
'***********************************************
' 変更履歴

Option Explicit On 
Option Strict On

Imports Common
Imports Common.DB

Imports System.Web.Services
Imports System.Configuration
Imports System.Text

'Imports java.util.zip 'vjslib.dllへの参照設定が必要です 

<System.Web.Services.WebService(Namespace:="http://tempuri.org/BTRUIJAW00/BTRUIJAW00")> _
Public Class BTRUIJAW00
    Inherits System.Web.Services.WebService

#Region " Web サービス デザイナで生成されたコード "

    Public Sub New()
        MyBase.New()

        'この呼び出しは Web サービス デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後に独自の初期化コードを追加してください。

    End Sub

    'Web サービス デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ : 以下のプロシージャは、Web サービス デザイナで必要です。
    'Web サービス デザイナを使って変更することができます。  
    'コード エディタによる変更は行わないでください。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        'CODEGEN: このプロシージャは Web サービス デザイナで必要です。
        'コード エディタによる変更は行わないでください。
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

#End Region

    'プログラムＩＤ
    Dim strPGID As String

    <WebMethod()> Public Sub ReverseMessageSub(ByRef message As String)
        message = StrReverse(message)
    End Sub
    '==========================================================================================
    ' ＤＢログ登録
    '==========================================================================================
    ' ログをＤＢ登録
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
        '接続文字列の設定
        '---------------------------------------------
        cdb.pJPUID = ConfigurationSettings.AppSettings("DB_USER_ID")
        cdb.pJPPWD = ConfigurationSettings.AppSettings("DB_PASSWORD")
        cdb.pJPDB = ConfigurationSettings.AppSettings("DB_SID")

        '---------------------------------------------
        'プールの最小値設定
        '---------------------------------------------
        cdb.pConnectPoolSize = 1

        '接続OPEN----------------------------------------
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
            ' 登録用SQL作成
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
            sql.Append("    '" & resultStr & "', ")    ' 結果
            sql.Append("    '" & sendType & "', ")     ' 送信種類
            sql.Append("    '" & resultMemo & "', ")   ' 結果メモ
            sql.Append("    '" & filePath & "', ")     ' ファイルパス
            sql.Append("    '" & reciveUser & "', ")   ' 受信者
            sql.Append("    TO_DATE('" & targetDateStr & "', 'YYYY/MM/DD') ")    ' 受信者
            sql.Append(")")

            '--------------------
            ' トランザクション開始
            '--------------------
            cdb.mBeginTrans()

            cdb.pSQL = sql.ToString
            cdb.mExecQuery() 'SQL実行！

            cdb.mCommit() 'コミット！

            '--------------------
            ' ログ表示追加
            '--------------------
            If bNowDispLog Then '追加する？
                sql = New StringBuilder
                sql.Append("SELECT ")
                sql.Append("    TO_CHAR(SYSDATE, 'YYYY/MM/DD(DY) HH24:MI') AS DISP_DATE, ")
                sql.Append("    '" & targetDateStr & " " & resultStr & " ' || RPAD('" & reciveUser & "', 30) || RPAD(SUBSTR('" & filePath & "', (INSTR('" & filePath & "', '\', -1) + 1)), 45) AS INFO, ")
                sql.Append("    '" & resultMemo & "' AS MEMO  ")
                sql.Append("FROM ")
                sql.Append("    DUAL ")
                cdb.pSQL = sql.ToString
                cdb.mExecQuery() 'SQL実行！

                '結果をデータセットに格納
                ds = cdb.pResult

                'データが存在しない場合
                If ds.Tables(0).Rows.Count = 0 Then
                    'データが0件
                Else
                    dr = ds.Tables(0).Rows(0)
                    '                    txtLog.Text = Convert.ToString(dr.Item("DISP_DATE")) & " " & Convert.ToString(dr.Item("INFO")) & Convert.ToString(dr.Item("MEMO")) & vbCrLf & txtLog.Text
                End If

            End If

        Catch ex As Exception
            'fncWriteLog("ＤＢログ登録エラー " & ex.ToString, "監視システム：累積情報自動FAX")
            ex = Nothing
            Return False
        Finally
            '接続クローズ
            cdb.mClose()
        End Try
        cdb = Nothing

        Return True

    End Function

    '==========================================================================================
    ' ＤＢからログを画面表示
    '==========================================================================================
    <WebMethod()> Public Function setDB2DispLog(ByRef dbLog As String) As Boolean
        Dim ds As New DataSet
        Dim cdb As New cdb
        Dim dr As DataRow
        Dim sql As New StringBuilder

        Dim msg As New StringBuilder



        '---------------------------------------------
        '接続文字列の設定
        '---------------------------------------------
        cdb.pJPUID = ConfigurationSettings.AppSettings("DB_USER_ID")
        cdb.pJPPWD = ConfigurationSettings.AppSettings("DB_PASSWORD")
        cdb.pJPDB = ConfigurationSettings.AppSettings("DB_SID")

        '---------------------------------------------
        'プールの最小値設定
        '---------------------------------------------
        cdb.pConnectPoolSize = 1

        '接続OPEN----------------------------------------
        Try
            cdb.mOpen()
        Catch ex As Exception
            Return False
        Finally

        End Try
        Try
            'txtLog.Text = ""
            dbLog = ""

            'トランザクション開始
            cdb.mBeginTrans()

            'ＳＱＬ作成
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
            cdb.mExecQuery() 'SQL実行！

            '結果をデータセットに格納
            ds = cdb.pResult

            'データが存在しない場合
            If ds.Tables(0).Rows.Count = 0 Then
                'データが0件であることを示す文字列を返す
            Else
                Dim i As Integer
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    dr = ds.Tables(0).Rows(i)
                    'txtLog.Text += Convert.ToString(dr.Item("DISP_DATE")) & " " & Convert.ToString(dr.Item("INFO")) & Convert.ToString(dr.Item("MEMO")) & vbCrLf '2010/10/19 T.Watabe add
                    dbLog += Convert.ToString(dr.Item("DISP_DATE")) & " " & Convert.ToString(dr.Item("INFO")) & Convert.ToString(dr.Item("MEMO")) & vbCrLf
                Next
            End If

        Catch ex As Exception
            'fncWriteLog("ＤＢからログを画面表示エラー", "監視システム：累積情報自動FAX")
            dbLog = "BTRUIJAW00 ERROR:" & EX.ToString
            ex = Nothing
            Return False
        Finally
            '接続クローズ
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
    '*　概　要：バッチ実行ログを取得
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
        '接続文字列の設定
        '---------------------------------------------
        'cdb.pJPUID = ConfigurationSettings.AppSettings("DB_USER_ID")
        'cdb.pJPPWD = ConfigurationSettings.AppSettings("DB_PASSWORD")
        'cdb.pJPDB = ConfigurationSettings.AppSettings("DB_SID")

        '---------------------------------------------
        'プールの最小値設定
        '---------------------------------------------
        cdb.pConnectPoolSize = 1

        '接続OPEN----------------------------------------
        Try
            cdb.mOpen()
        Catch ex As Exception
            Return False
        Finally

        End Try

        Try
            'トランザクション開始
            cdb.mBeginTrans()

            '対応ＤＢ　D20_TAIOU
            Dim sql As New StringBuilder
            sql.Append("SELECT ")
            sql.Append("    TO_CHAR(TO_DATE(ST_YMD || ST_TIME,'YYYYMMDDHH24MISS'), 'YYYY/MM/DD HH24:MI') AS ST, ")
            sql.Append("    LPAD(TRUNC(EXEC_SEC / 1000,0), 5, ' ') || '秒' AS MIN, ")
            sql.Append("    SUBSTRB(MSG, 1,80) AS MSG ")
            sql.Append("FROM S02_BACHDB  ")
            sql.Append("WHERE PROC_ID = 'BTFAXJAE00' ")
            sql.Append("ORDER BY ST_YMD || ST_TIME DESC ")
            cdb.pSQL = sql.ToString
            cdb.mExecQuery() 'SQL実行！

            '結果をデータセットに格納
            ds = cdb.pResult

            'データが存在しない場合
            If ds.Tables(0).Rows.Count = 0 Then

                batchLog = "0件"
            Else
                Dim i As Integer = 0
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    If i >= 50 Then Exit For '50件まで

                    dr = ds.Tables(0).Rows(i)
                    'arrBatchLog.Add(Convert.ToString(dr.Item("ST")) & Convert.ToString(dr.Item("MIN")) & " " & Convert.ToString(dr.Item("MSG")))
                    If batchLog.Length > 0 Then batchLog = batchLog & "$$" '$$は関数から取得した改行付き文字列の改行がうまくされない為。
                    batchLog = batchLog & Convert.ToString(dr.Item("ST")) & Convert.ToString(dr.Item("MIN")) & " " & Convert.ToString(dr.Item("MSG"))
                Next
            End If

        Catch ex As Exception
            batchLog = ex.ToString
            Return False
        Finally
            '接続クローズ
            cdb.mClose()
        End Try
        cdb = Nothing

        Return True

    End Function

    '==========================================================================================
    ' ＤＢからデータ読み込み
    '==========================================================================================
    '<WebMethod()> Public Function setDB2DataTable(ByRef dt As DataTable) As Boolean
    <WebMethod()> Public Function setDB2DataTable() As Boolean

        Dim dt As DataTable

        ''---------------------
        '' テーブルにデータを追加
        ''---------------------
        'dt.Rows.Add(New [Object]() {1, 1, "3231", "01", "430", "430", "430010", "430010", "1", "1", "1", "0333502160", "0333502161", "watabe_tai@ja-lp.co.jp", "watabe-tai@z-bs.co.jp", "1", "OK", "2010/05/25", "2010/05/26", "", "2010/04/01", "2099/12/31", "備考テストあいうえおかきくけこさしすせそたちつてとなにぬねのはひふへほまみむめもやゆよらりるれろわをん"})
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
        '接続文字列の設定
        '---------------------------------------------
        cdb.pJPUID = ConfigurationSettings.AppSettings("DB_USER_ID")
        cdb.pJPPWD = ConfigurationSettings.AppSettings("DB_PASSWORD")
        cdb.pJPDB = ConfigurationSettings.AppSettings("DB_SID")

        '---------------------------------------------
        'プールの最小値設定
        '---------------------------------------------
        cdb.pConnectPoolSize = 1

        '接続OPEN----------------------------------------
        Try
            cdb.mOpen()
        Catch ex As Exception
            Return False
        Finally

        End Try
        Try
            '--------------------
            ' 読び出し用SQL作成
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
            sql.Append("    DEL_FLG = '0' ") ' 削除フラグ=0:通常
            sql.Append("ORDER BY ")
            sql.Append("    SEQ ")

            '--------------------
            ' トランザクション開始
            '--------------------
            cdb.mBeginTrans()

            cdb.pSQL = sql.ToString
            cdb.mExecQuery() 'SQL実行！
            ds = cdb.pResult '結果をデータセットに格納

            If ds.Tables(0).Rows.Count = 0 Then 'データが存在しない？
                '正常を返す
                Return True
            Else
                dr = ds.Tables(0).Rows(0) 'データローにデータセットを格納
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    'Application.DoEvents()
                    'Me.Refresh()

                    dr = ds.Tables(0).Rows(i) 'データローにデータセットを格納

                    '---------------------
                    ' テーブルにデータを追加
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
                    '    セルに色付け
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
            'fncWriteLog("ＤＢ読み込みエラー " & ex.ToString, "監視システム：累積情報自動FAX")
            ex = Nothing
            Return False
        Finally
            '接続クローズ
            cdb.mClose()
        End Try
        cdb = Nothing

        Return True
    End Function


    ' 2010/09/15 T.Watabe add
    '*****************************************************************
    '*　概　要：DB SIDを戻す
    '*****************************************************************
    <WebMethod()> Public Function getDBSID() As String
        Dim res As String = ""
        Try
            res = ConfigurationSettings.AppSettings("JPDB")
        Catch ex As Exception
            res = "JPDB 参照エラー:" & ex.ToString
        End Try
        Return res
    End Function

    '==========================================================================================
    ' 文字列切り出し（文字列より範囲が狭い場合のエラー回避）
    '==========================================================================================
    Private Function subStr(ByVal ss As String, ByVal startPos As Integer, ByVal len As Integer) As String
        Dim ii As Integer = 0
        Dim res As String = ""
        Try
            ii = ss.Length
            If len <= 0 Then
                '指定が間違っている
            ElseIf startPos < 0 Then
                '指定が間違っている
            ElseIf len - startPos < 0 Then
                '指定が間違っている
            ElseIf ss.Length <= 0 Then
                '空を返す
            Else
                If ss.Length <= startPos Then
                    '空を返す
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
    ' 日付文字列を日付書式に変換(yyyyMMdd→yyyy/MM/dd)
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
