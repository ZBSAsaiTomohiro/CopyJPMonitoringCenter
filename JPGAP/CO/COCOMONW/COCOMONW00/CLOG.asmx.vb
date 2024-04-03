Option Strict On

Imports Common.DB

Imports System.Web.Services
Imports System.Text


<System.Web.Services.WebService(Namespace := "http://tempuri.org/JPGAP.COCOMONW00/CLOG")> _
Public Class CLOG
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
        components = New System.ComponentModel.Container()
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

    <WebMethod()> Public Function mAPLog(ByVal pSession_Id As String, ByVal pUser_Id As String, _
                                         ByVal pIp_Address As String, ByVal pProc_Id As String, _
                                         ByVal pExec_Status As String, ByVal pResult As String, _
                                         ByVal pDs As DataSet) As String
        ''--------------------------------------------------------------------------------
        ''SESSION_ID    セッションＩＤ  
        ''LOGINCD       統合WINDOWSユーザーコード
        ''IPADR         ＩＰアドレス
        ''PROC_ID       プログラムＩＤ
        ''EXEC_STATUS   実行区分
        ''TEXT          画面からのForm情報
        ''MSG           メッセージ
        ''ADD_DATE      レコード作成日
        ''TIME          レコード更新時刻
        ''--------------------------------------------------------------------------------
        Dim cdb As New CDB
        Dim dr As DataRow
        Dim strSQL As New StringBuilder("")

        Dim i As Integer
        Dim strText As String

        '結果データ初期化
        mAPLog = "OK"

        '引数で渡されたカラム名
        Dim strColName As String

        '引数で渡されたカラムの値
        Dim strColVal As String
        Dim intColCnt As Integer

        'データロー型に引数のデータセットを格納
        dr = pDs.Tables(0).Rows(0)

        'データローのカラムの数を取得
        intColCnt = dr.ItemArray.GetUpperBound(0)

        'カラムの数だけループ
        strText = ""
        For i = 0 To intColCnt
            'カラム名
            strColName = dr.Table.Columns(i).ColumnName
            'カラムの値
            strColVal = Convert.ToString(dr.Item(i))
            '代入テキストに格納
            strText = strText & strColName & "=" & strColVal & ";"
        Next

        Try
            'DBオープン
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

            'パラメータに値をセット
            cdb.pSQLParamStr("SESSION_ID") = pSession_Id
            cdb.pSQLParamStr("LOGINCD") = pUser_Id
            cdb.pSQLParamStr("IPADR") = pIp_Address
            cdb.pSQLParamStr("PROC_ID") = pProc_Id
            cdb.pSQLParamStr("EXEC_STATUS") = pExec_Status
            cdb.pSQLParamStr("TEXT") = strText
            cdb.pSQLParamStr("MSG") = pResult
            cdb.pSQLParamStr("ADD_DATE") = Format(Now, "yyyyMMdd")      '作成日
            cdb.pSQLParamStr("TIME") = Format(Now, "HHmmss")      '作成時間

            cdb.mExecNonQuery()
            cdb.mCommit()
        Catch
            'エラーが発生したら、エラー情報を返す
            mAPLog = cdb.pErr & ErrorToString()
            cdb.mRollback()
        Finally
            'DBクローズ
            cdb.mClose()
        End Try
    End Function


    <WebMethod()> Public Function mBTLog_Start(ByVal pDate As String, ByVal pTime As String, ByVal pProc_Id As String) As String
        ''--------------------------------------------------------------------------------
        ''             　　　　　　　　　　　　　　　　|開始時|終了時|
        ''PROC_ID      プログラムＩＤ　　　　　　　　　|　ｉ　|　ｋ　|　Keyとして使用　(パラメータ)
        ''ST_YMD       開始年月日　　　　　　　　　　　|　ｉ　|　ｋ　|　Keyとして使用　(パラメータ)
        ''ST_TIME      開始時刻　　　　　　　　　　　　|　ｉ　|　ｋ　|　Keyとして使用　(パラメータ)
        ''ED_YMD       終了年月日　　　　　　　　　　　|　　　|　ｕ　|　(パラメータ)
        ''ED_TIME      終了時刻　　　　　　　　　　　　|　　　|　ｕ　|　(パラメータ)
        ''EXEC_SEC     実行時間　　　　　　　　　　　　|　　　|　ｕ　|　(パラメータ)
        ''PROJ_STATUS  プロジェクト実行状態　　　　　　|　　　|　ｕ　|　(パラメータ)　　登録時はNULL
        ''EXEC_STATUS  処理ステータス　　　　　　　　　|　▲　|　ｕ　|　(パラメータ)　　登録時は０:処理中
        ''MSG          実行メッセージ：エラー内容　　　|　　　|　ｕ　|　(パラメータ)
        ''FILE_NM      ファイル名（連動時のみ）　　　　|　　　|　ｕ　|　(パラメータ)
        ''ADD_DATE     レコード作成日　　　　　　　　　|　ｉ　|　　　|
        ''TIME         レコード更新時刻　　　　　　　　|　ｉ　|　　　|
        ''--------------------------------------------------------------------------------
        Dim cdb As New CDB
        Dim strSQL As New StringBuilder("")
        mBTLog_Start = "OK"

        Try
            'DBオープン
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
            'パラメータに値をセット
            cdb.pSQLParamStr("PROC_ID") = pProc_Id
            cdb.pSQLParamStr("ST_YMD") = pDate
            cdb.pSQLParamStr("ST_TIME") = pTime
            cdb.pSQLParamStr("EXEC_STATUS") = "0"           '0：処理中にて登録
            cdb.pSQLParamStr("ADD_DATE") = pDate
            cdb.pSQLParamStr("TIME") = pTime
            'Execute
            cdb.mExecNonQuery()
            cdb.mCommit()
        Catch ex As Exception
            'エラーが発生したら、エラー情報を返す
            mBTLog_Start = cdb.pErr & ex.ToString & ";行番号:" & Err.Erl & ";オブジェクト:" & Err.Source
            cdb.mRollback()
        Finally
            'DBクローズ
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
            'DBオープン
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
            'パラメータに値をセット
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
            'エラーが発生したら、エラー情報を返す
            mBTLog_END = strSQL.ToString & cdb.pErr & ex.ToString
            cdb.mRollback()
        Finally
            'DBクローズ
            cdb.mClose()

        End Try
    End Function
End Class
