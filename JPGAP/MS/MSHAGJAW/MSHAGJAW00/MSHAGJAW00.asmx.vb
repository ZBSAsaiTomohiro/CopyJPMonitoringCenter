'***********************************************
'販売事業者グループマスタ
'***********************************************
' 変更履歴

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

    'pintMODE
    '   1:新規登録
    '   2:修正登録
    '   3:削除
    '************************************************
    '販売事業者グループリストデータ取得
    '************************************************
    '【共通】
    '  OK : 正常に終了しました
    '   0 : 他のユーザーによってデータが更新されています。再度検索してください
    '   1 : 既にデータが存在します
    '   2 : 対象データが存在しません
    '   3 : 排他制御処理でエラーが発生しました。再度実行してください
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

        '接続OPEN----------------------------------------
        Try
            cdb.mOpen()
        Catch ex As Exception
            strRes = ex.ToString
            Return strRes
        Finally
        End Try

        Try
            'トランザクション開始--------------------------
            cdb.mBeginTrans()

            Dim i As Integer
            For i = 1 To pstrGROUPCD.Length - 1 '１件ずつ登録／更新／削除する。
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
                'コミット
                cdb.mCommit()
            Else
                'ロールバック
                cdb.mRollback()
            End If

        Catch ex As Exception
            'エラーが起きたら エラー内容を格納
            strRes = ex.ToString

            '排他制御処理エラー
            If ErrorToString.Substring(0, 9) = "ORA-00054" Then
                Return "3"
            End If

            'ロールバック
            cdb.mRollback()
            strRes = strRes & cdb.pErr
        Finally
            '接続クローズ
            cdb.mClose()
        End Try

        cdb = Nothing

        Return strRes

    End Function
    '************************************************
    '販売事業者グループマスタ更新
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
            '処理ストーリー
            '・排他のチェックを行う。
            '・登録時にはデータは未だ存在しないこと
            '・修正時にはデータは存在すること
            '・センターコードの存在チェックを行う
            '*********************************

            'ＤＢチェック(基本)-----------------------------
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
            strSQL.Append("FOR UPDATE NOWAIT ")             '排他制御をかける

            'SQL文セット
            cdb.pSQL = strSQL.ToString

            'パラメータに値をセット
            cdb.pSQLParamStr("GROUPCD") = pstrGROUPCD       'グループコード

            'SQL実行
            cdb.mExecQuery()
            ds = cdb.pResult


            '*******************************
            ' モードの再決定
            '*******************************
            If (ds.Tables(0).Rows.Count <> 0) Then 'ＤＢにデータが存在する？
                If pintMODE = 4 Then '削除ボタン押下
                    pintMODE = 3 'モード＝3：削除
                Else
                    pintMODE = 2 'モード＝2：更新
                End If
            Else
                If pintMODE = 4 Then
                    pintMODE = 4 'モード＝4：スキップ
                Else
                    pintMODE = 1 'モード＝1：新規
                End If
            End If


            If (pintMODE = 3) Then 'ＤＢにデータが存在して、削除の場合
                '*******************************************
                '削除時で受け渡された日付及び時間と削除対象データが異なる場合エラー
                '*******************************************
                tmp = Convert.ToString(ds.Tables(0).Rows(0).Item("INS_DATE")) & "_" & Convert.ToString(ds.Tables(0).Rows(0).Item("UPD_DATE"))
                If (tmp <> pstrINS_DATE & "_" & pstrUPD_DATE) Then
                    strRes = "0"
                    Exit Try
                End If
            End If


            If (pintMODE = 2) Then 'ＤＢにデータが存在して、更新の場合
                '*******************************************
                '修正時で受け渡された日付及び時間と更新対象データが異なる場合エラー
                '*******************************************
                tmp = Convert.ToString(ds.Tables(0).Rows(0).Item("INS_DATE")) & "_" & Convert.ToString(ds.Tables(0).Rows(0).Item("UPD_DATE"))
                If (tmp <> pstrINS_DATE & "_" & pstrUPD_DATE) Then
                    strRes = "0"
                    Exit Try
                End If

                '*******************************************
                ' 修正時でデータが変更されていない場合はスキップ
                '*******************************************
                If ( _
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("GROUPCD")) = pstrGROUPCD) And _
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("GROUPNM")) = pstrGROUPNM) And _
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("HANJIGYOSYANM")) = pstrHANJIGYOSYANM) And _
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("BIKO")) = pstrBIKO) _
                     ) Then

                    pintMODE = 4 'スキップ
                End If
            End If

            If pintMODE = 4 Then
                'スキップ→次のレコード
                Exit Try
            End If

            'ＤＢチェック-----------------------------------
            '削除時
            If (pintMODE = 3) Then
                '*******************************************
                'JAグループ作成マスタで使われていないかチェック
                strSQL = New StringBuilder("")
                strSQL.Append("SELECT 'X'")
                strSQL.Append("FROM ")
                strSQL.Append("	M09_JAGROUP A ")
                strSQL.Append("WHERE ")
                strSQL.Append("	A.KBN = '001' ")
                strSQL.Append("AND	A.GROUPCD = :GROUPCD ")
                'SQL文セット
                cdb.pSQL = strSQL.ToString
                'バインド変数に値をセット
                cdb.pSQLParamStr("GROUPCD") = pstrGROUPCD
                'SQL実行
                cdb.mExecQuery()
                ds = cdb.pResult

                If (ds.Tables(0).Rows.Count > 0) Then
                    '*******************************************
                    'JAグループ作成マスタで使用されている
                    '*******************************************
                    strRes = "4"
                    Exit Try
                End If
            End If

            '登録/更新時、
            If (pintMODE = 1 Or pintMODE = 2) Then
                '*******************************************
                '命名則のチェック
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
                'SQL文セット
                cdb.pSQL = strSQL.ToString

                'SQL実行
                cdb.mExecQuery()
                ds = cdb.pResult

                If (ds.Tables(0).Rows.Count = 0) Then
                    '*******************************************
                    'プルダウンマスタに登録が存在しない時
                    '*******************************************
                    strRes = "5"
                    Exit Try
                Else
                    If Convert.ToString(ds.Tables(0).Rows(0).Item("NAIYO1")) <> pstrGROUPCD.Substring(0, 2) Then
                        '*******************************************
                        '命名則違反（グループコードの先頭にNAIYO1かついてない）
                        '*******************************************
                        strRes = "6" & pstrI.PadLeft(3, "0"c) 'エラー№＋行数を返す　6001～6100
                        Exit Try
                    End If
                End If
            End If


            'データの更新処理--------------------------------
            If pintMODE = 3 Then
                '処理区分が削除
                strSQL = New StringBuilder("")
                strSQL.Append("DELETE ")
                strSQL.Append("FROM ")
                strSQL.Append("	    M10_HANJIGYOSYA ")
                strSQL.Append("WHERE ")
                strSQL.Append("     GROUPCD = :GROUPCD ")

            ElseIf pintMODE = 2 Then
                '処理区分が更新
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
                '処理区分が新規
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

            'SQL文セット
            cdb.pSQL = strSQL.ToString
            'バインド変数に値をセット
            If pintMODE = 3 Then
                cdb.pSQLParamStr("GROUPCD") = pstrGROUPCD

            ElseIf pintMODE = 1 Or pintMODE = 2 Then

                cdb.pSQLParamStr("GROUPCD") = pstrGROUPCD
                cdb.pSQLParamStr("GROUPNM") = pstrGROUPNM
                cdb.pSQLParamStr("HANJIGYOSYANM") = pstrHANJIGYOSYANM
                cdb.pSQLParamStr("BIKO") = pstrBIKO


                If pintMODE = 1 Then
                    '新規登録の場合
                    cdb.pSQLParamStr("INS_DATE") = Now.ToString()
                    cdb.pSQLParamStr("INS_USER") = pstrUSERNM.Trim
                    cdb.pSQLParamStr("UPD_DATE") = ""
                    cdb.pSQLParamStr("UPD_USER") = ""
                Else
                    '修正登録の場合
                    cdb.pSQLParamStr("INS_DATE") = pstrINS_DATE
                    cdb.pSQLParamStr("INS_USER") = pstrINS_USER
                    cdb.pSQLParamStr("UPD_DATE") = Now.ToString()
                    cdb.pSQLParamStr("UPD_USER") = pstrUSERNM.Trim
                End If

            End If

            'SQLを実行
            cdb.mExecNonQuery()


        Catch ex As Exception
            'エラーが起きたら エラー内容を格納
            strRes = ex.ToString

            '排他制御処理エラー
            If ErrorToString.Substring(0, 9) = "ORA-00054" Then
                Return "3"
            End If
            strRes = strRes & cdb.pErr
        Finally

        End Try

        Return strRes
    End Function
    '******************************************************************************
    '*　概　要:一覧の出力を行います
    '*　備　考:
    '******************************************************************************
    '　DATA0:対象データがありません
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
        Dim CSVC As New CCSV                            'CSVクラス

        '接続OPEN----------------------------------------
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
            'SQL文セット
            cdb.pSQL = strSQL.ToString

            'パラメータに値をセット
            'クライアントコード
            If pstrKURACD.Trim.Length > 0 Then
                cdb.pSQLParamStr("KURACD") = pstrKURACD.Trim
            End If
            'グループコードFrom
            If pstrGROUPCD_F.Trim.Length > 0 Then
                cdb.pSQLParamStr("GROUPCD_F") = pstrGROUPCD_F.Trim
            End If
            'グループコードTo
            If pstrGROUPCD_T.Trim.Length > 0 Then
                cdb.pSQLParamStr("GROUPCD_T") = pstrGROUPCD_T.Trim
            End If


            'SQL実行
            cdb.mExecQuery()
            ds = cdb.pResult

            'データが無い場合は終了
            If ds.Tables(0).Rows.Count = 0 Then
                Return "DATA0"
            End If

            CSVC.pKencd = "00"
            CSVC.pSessionID = pstrSessionID   'セッションID
            CSVC.pRepoID = "MSHAGJAW00"       '帳票ID
            CSVC.mOpen()
            Dim iCnt As Integer
            Dim irCnt As Integer
            For iCnt = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(iCnt)

                If iCnt = 0 Then
                    CSVC.pColValStrEx = "グループコード"
                    CSVC.pColValStrEx = "グループコード名"
                    CSVC.pColValStrEx = "販売事業者名"
                    CSVC.pColValStrEx = "備考"
                    CSVC.pColValStrEx = "登録日時"
                    CSVC.pColValStrEx = "登録者"
                    CSVC.pColValStrEx = "更新日時"
                    CSVC.pColValStrEx = "更新者"
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
            'エラーの内容とＳＱＬ文を返す
            Return "ERROR:" & ex.ToString

        Finally
            cdb.mClose()        '接続クローズ
        End Try

    End Function
    '**********************************************************
    'ログ吐き出し
    '戻り値：書き込んだファイルへのフルパス
    '**********************************************************
    Public Sub mlog(ByVal pstrString As String)
        Dim strFilnm As String = "testKANSI" & System.DateTime.Today.ToString("yyyyMMdd")
        Dim strLogPath As String = ConfigurationSettings.AppSettings("LOG_OUT_PATH")
        Dim strPath As String = strLogPath & strFilnm & ".txt"
        Dim strLogFlg As String = ConfigurationSettings.AppSettings("LOG_OUT")
        If strLogFlg = "1" Then
            '書き込みファイルへのストリーム
            Dim outFile As New StreamWriter(strPath, True, System.Text.Encoding.Default)

            '引数の文字列をストリームに書き込み
            outFile.Write(System.DateTime.Now & ":[" & pstrString + "]" & vbCrLf)

            'メモリフラッシュ（ファイル書き込み）
            outFile.Flush()

            'ファイルクローズ
            outFile.Close()
        End If
    End Sub
End Class
