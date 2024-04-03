'***********************************************
'自動対応グループマスタ
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


<System.Web.Services.WebService(Namespace:="http://tempuri.org/MSJIGJAW00/Service1")> _
Public Class MSJIGJAW00
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
    '担当者マスタリストデータ取得
    '************************************************
    '【共通】
    '  OK : 正常に終了しました
    '   0 : 他のユーザーによってデータが更新されています。再度検索してください
    '   1 : 既にデータが存在します
    '   2 : 対象データが存在しません
    '   3 : 排他制御処理でエラーが発生しました。再度実行してください
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
        '配列を空で用意
        Dim strKURACD() As String
        strKURACD = New String(pstrKURACD.Length) {} '配列の実体を確保
        Dim strACBCD() As String
        strACBCD = New String(pstrACBCD.Length) {} '配列の実体を確保
        Dim strGROUPCD() As String
        strGROUPCD = New String(pstrGROUPCD.Length) {} '配列の実体を確保
        Dim strUSE_FLG() As String
        strUSE_FLG = New String(pstrUSE_FLG.Length) {} '配列の実体を確保
        Dim strINS_DATE() As String
        strINS_DATE = New String(pstrINS_DATE.Length) {} '配列の実体を確保
        Dim strUPD_DATE() As String
        strUPD_DATE = New String(pstrUPD_DATE.Length) {} '配列の実体を確保
        Dim strBIKO() As String
        strBIKO = New String(pstrBIKO.Length) {} '配列の実体を確保
        Dim strDEL() As String
        strDEL = New String(pstrDEL.Length) {} '配列の実体を確保

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
            For i = 1 To pstrKURACD.Length - 1 '１件ずつ登録／修正／削除する。
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
    '担当者マスタ更新
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
            '処理ストーリー
            '・排他のチェックを行う。
            '・登録時にはデータは未だ存在しないこと
            '・修正時にはデータは存在すること
            '・センターコードの存在チェックを行う
            '*********************************

            'ＤＢチェック(基本)-----------------------------
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
            strSQL.Append("FOR UPDATE NOWAIT ")             '排他制御をかける

            'SQL文セット
            cdb.pSQL = strSQL.ToString

            'パラメータに値をセット
            cdb.pSQLParamStr("KURACD") = pstrKURACD         'クライアントコード
            cdb.pSQLParamStr("ACBCD") = pstrACBCD           'JA支所コード

            'SQL実行
            cdb.mExecQuery()
            ds = cdb.pResult

            '*******************************
            ' モードの再決定
            '*******************************
            If (ds.Tables(0).Rows.Count <> 0) Then 'ＤＢにデータが存在する？
                If pintMODE = 4 Then 'pintMODE=4(削除)
                    If pstrDEL = "true" Then '削除対象チェックあり？ 
                        pintMODE = 3 'モード＝3：削除
                    Else
                        pintMODE = 4 'モード＝4：スキップ
                    End If
                Else
                    pintMODE = 2 'モード＝2：更新
                End If
            Else
                If pstrKURACD = "" Then '登録元データはない？
                    pintMODE = 4 'モード＝4：スキップ
                ElseIf pstrDEL = "true" Then
                    pintMODE = 4 'モード＝4：スキップ
                    strRes = "0" '削除対象データがない
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
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("KURACD")) = pstrKURACD) And _
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("ACBCD")) = pstrACBCD) And _
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("GROUPCD")) = pstrGROUPCD) And _
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("USE_FLG")) = pstrUSE_FLG) And _
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
            '登録修正時、
            If (pintMODE = 1 Or pintMODE = 2) Then

                '*******************************************
                'クライアントコードの存在チェック
                strSQL = New StringBuilder("")
                strSQL.Append("SELECT  ")
                strSQL.Append(" CLI_CD ")
                strSQL.Append("FROM ")
                strSQL.Append(" CLIMAS ")
                strSQL.Append("WHERE CLI_CD = :CLI_CD ")
                'SQL文セット
                cdb.pSQL = strSQL.ToString

                'パラメータに値をセット
                cdb.pSQLParamStr("CLI_CD") = pstrKURACD

                'SQL実行
                cdb.mExecQuery()
                ds = cdb.pResult

                If (ds.Tables(0).Rows.Count = 0) Then
                    '*******************************************
                    'クライアントコードが存在しない時
                    '*******************************************
                    strRes = "4"
                    Exit Try
                End If

                '*******************************************
                'JA支所コードの存在チェック
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
                'SQL文セット
                cdb.pSQL = strSQL.ToString

                'パラメータに値をセット
                cdb.pSQLParamStr("CLI_CD") = pstrKURACD
                cdb.pSQLParamStr("JA_CD") = pstrACBCD

                'SQL実行
                cdb.mExecQuery()
                ds = cdb.pResult

                If (ds.Tables(0).Rows.Count = 0) Then
                    '*******************************************
                    'JA支所コードが存在しない時
                    '*******************************************
                    strRes = "5"
                    Exit Try
                End If
            End If

            'データの更新処理--------------------------------

            If pintMODE = 3 Then
                '処理区分が削除
                strSQL = New StringBuilder("")
                strSQL.Append("DELETE ")
                strSQL.Append("FROM ")
                strSQL.Append("			M07_AUTOTAIOUGROUP ")
                strSQL.Append("WHERE ")
                strSQL.Append("			KURACD =:KURACD ")          'クライアントコード
                strSQL.Append("AND		ACBCD =:ACBCD ")            '警報コード

            ElseIf pintMODE = 2 Then
                '処理区分が修正
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
                '処理区分が新規
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

            'SQL文セット
            cdb.pSQL = strSQL.ToString
            'バインド変数に値をセット
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
                    '新規登録の場合
                    cdb.pSQLParamStr("INS_DATE") = Now.ToString()
                    cdb.pSQLParamStr("UPD_DATE") = ""
                Else
                    '修正登録の場合
                    cdb.pSQLParamStr("INS_DATE") = pstrINS_DATE
                    cdb.pSQLParamStr("UPD_DATE") = Now.ToString()
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
                                        ByVal pstrACBCD_F As String, _
                                        ByVal pstrACBCD_T As String, _
                                        ByVal pstrGROUPCD As String _
                                        ) As String

        Dim strSQL As New StringBuilder("")
        Dim cdb As New CDB
        Dim ds As New DataSet
        Dim dr As DataRow
        Dim CSVC As New CCSV                            'CSVクラス
        'Dim compressC As New CCompress                  '圧縮クラス
        'Dim DateFncC As New CDateFnc                    '日付変換クラス
        'Dim CTimeFncC As New CTimeFnc                   '時間変換クラス
        'Dim FileToStrC As New CFileStr                  'ファイルをBase64にエンコードするクラス

        '接続OPEN----------------------------------------
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
            'SQL文セット
            cdb.pSQL = strSQL.ToString

            'パラメータに値をセット
            'クライアントコード
            If pstrKURACD.Trim.Length > 0 Then
                cdb.pSQLParamStr("KURACD") = pstrKURACD
            End If
            'JA支所コード
            If pstrACBCD_F.Trim.Length > 0 Then
                cdb.pSQLParamStr("ACBCD_F") = pstrACBCD_F
            End If
            If pstrACBCD_T.Trim.Length > 0 Then
                cdb.pSQLParamStr("ACBCD_T") = pstrACBCD_T
            End If
            'グループコード
            If pstrGROUPCD.Trim.Length > 0 Then
                cdb.pSQLParamStr("GROUPCD") = pstrGROUPCD
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
            CSVC.pRepoID = "MSJIGJAW00"       '帳票ID
            CSVC.mOpen()
            Dim iCnt As Integer
            Dim irCnt As Integer
            For iCnt = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(iCnt)

                If iCnt = 0 Then
                    CSVC.pColValStrEx = "クライアントコード"
                    CSVC.pColValStrEx = "JA支所コード"
                    CSVC.pColValStrEx = "グループコード"
                    CSVC.pColValStrEx = "使用フラグ"
                    CSVC.pColValStrEx = "備考"
                    CSVC.pColValStrEx = "登録日時"
                    CSVC.pColValStrEx = "更新日時"
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
        Dim strFilnm As String = "testGroup" & System.DateTime.Today.ToString("yyyyMMdd")
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
