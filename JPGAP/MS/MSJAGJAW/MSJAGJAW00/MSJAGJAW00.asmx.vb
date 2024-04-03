'***********************************************
'JAグループ作成マスタ
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


<System.Web.Services.WebService(Namespace:="http://tempuri.org/MSJAGJAW00/Service1")> _
Public Class MSJAGJAW00
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
    'JAグループ作成マスタリストデータ取得
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
                                    ByVal pstrJAGKBN As String, _
                                    ByVal pstrTARGET() As String, _
                                    ByVal pstrKURACD() As String, _
                                    ByVal pstrACBCD() As String, _
                                    ByVal pstrGROUPCD() As String, _
                                    ByVal pstrUSERCD_F() As String, _
                                    ByVal pstrUSERCD_T() As String, _
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
            For i = 1 To pstrKURACD.Length - 1 '１件ずつ登録／更新／削除する。
                mlog("loop:" & pstrTARGET(i) & pstrKURACD(i) & "_" & pstrACBCD(i) & "_" & pstrGROUPCD(i))

                If pstrTARGET(i) = "true" AndAlso pstrKURACD(i) <> "" Then
                    '対象チェックあり、入力ありのみ処理
                    strRes = mSetGroup( _
                            cdb, _
                            pintMODE, _
                            pstrJAGKBN, _
                            pstrTARGET(i), _
                            pstrKURACD(i), _
                            pstrACBCD(i), _
                            pstrGROUPCD(i), _
                            pstrUSERCD_F(i), _
                            pstrUSERCD_T(i), _
                            pstrBIKO(i), _
                            pstrINS_DATE(i), _
                            pstrINS_USER(i), _
                            pstrUPD_DATE(i), _
                            pstrUPD_USER(i), _
                            pstrUSERNM)
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
    'マスタ更新
    '************************************************
    <WebMethod()> Public Function mSetGroup( _
                                ByRef cdb As CDB, _
                                ByVal pintMODE As Integer, _
                                ByVal pstrJAGKBN As String, _
                                ByVal pstrTARGET As String, _
                                ByVal pstrKURACD As String, _
                                ByVal pstrACBCD As String, _
                                ByVal pstrGROUPCD As String, _
                                ByVal pstrUSERCD_F As String, _
                                ByVal pstrUSERCD_T As String, _
                                ByVal pstrBIKO As String, _
                                ByVal pstrINS_DATE As String, _
                                ByVal pstrINS_USER As String, _
                                ByVal pstrUPD_DATE As String, _
                                ByVal pstrUPD_USER As String, _
                                ByVal pstrUSERNM As String _
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
            strSQL.Append("	    A.KBN ")
            strSQL.Append("	    ,A.KURACD ")
            strSQL.Append("	    ,A.ACBCD ")
            strSQL.Append("	    ,A.GROUPCD ")
            strSQL.Append("	    ,A.USERCD_FROM ")
            strSQL.Append("	    ,A.USERCD_TO ")
            strSQL.Append("	    ,A.BIKO ")
            strSQL.Append("	    ,TO_CHAR(A.INS_DATE, 'YYYY/MM/DD HH24:MI:SS') AS INS_DATE ")
            strSQL.Append("	    ,A.INS_USER ")
            strSQL.Append("	    ,TO_CHAR(A.UPD_DATE, 'YYYY/MM/DD HH24:MI:SS') AS UPD_DATE ")
            strSQL.Append("	    ,A.UPD_USER ")
            strSQL.Append("FROM ")
            strSQL.Append("	    M09_JAGROUP A ")
            strSQL.Append("WHERE ")
            strSQL.Append("	    A.KBN = :JAGKBN ")
            strSQL.Append("AND  A.KURACD = :KURACD ")
            strSQL.Append("AND	A.ACBCD = :ACBCD ")
            If pstrJAGKBN.Trim <> "003" Then                     '2017/02/09 w.ganeko 2016監視改善 №10
                If pstrUSERCD_F.Trim.Length > 0 Then
                    strSQL.Append("AND	A.USERCD_FROM = :USERCD_F ")
                Else
                    strSQL.Append("AND	A.USERCD_FROM IS NULL ")
                End If
            End If
            strSQL.Append("ORDER BY KURACD, ACBCD ")
            strSQL.Append("FOR UPDATE NOWAIT ")             '排他制御をかける

            'SQL文セット
            cdb.pSQL = strSQL.ToString

            'パラメータに値をセット
            cdb.pSQLParamStr("JAGKBN") = pstrJAGKBN         'グループ区分
            cdb.pSQLParamStr("KURACD") = pstrKURACD         'クライアントコード
            cdb.pSQLParamStr("ACBCD") = pstrACBCD           'JA支所コード
            If pstrJAGKBN.Trim <> "003" Then                     '2017/02/09 w.ganeko 2016監視改善 №10
                If pstrUSERCD_F.Trim.Length > 0 Then
                    cdb.pSQLParamStr("USERCD_F") = pstrUSERCD_F 'ユーザーコードFrom
                End If
            End If
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
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("KBN")) = pstrJAGKBN) And _
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("KURACD")) = pstrKURACD) And _
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("ACBCD")) = pstrACBCD) And _
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("GROUPCD")) = pstrGROUPCD) And _
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("USERCD_FROM")) = pstrUSERCD_F) And _
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("USERCD_TO")) = pstrUSERCD_T) And _
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
            '登録/更新時、
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

                '*******************************************
                'JA支所コード毎の登録件数チェック
                '100件以上は画面に表示できないので
                '既に100件登録ある場合はNG
                If pintMODE = 1 Then
                    strSQL = New StringBuilder("")
                    strSQL.Append("SELECT ")
                    strSQL.Append("		COUNT(*) AS CNT ")
                    strSQL.Append("FROM ")
                    strSQL.Append("		M09_JAGROUP ")
                    strSQL.Append("WHERE ")
                    strSQL.Append("		KBN = :JAGKBN ")
                    strSQL.Append("AND KURACD = :KURACD ")
                    strSQL.Append("AND ACBCD = :ACBCD ")
                    'SQL文セット
                    cdb.pSQL = strSQL.ToString
                    'パラメータに値をセット
                    cdb.pSQLParamStr("JAGKBN") = pstrJAGKBN
                    cdb.pSQLParamStr("KURACD") = pstrKURACD
                    cdb.pSQLParamStr("ACBCD") = pstrACBCD

                    'SQL実行
                    cdb.mExecQuery()
                    ds = cdb.pResult

                    If CInt(ds.Tables(0).Rows(0).Item("CNT")) >= 100 Then
                        '*******************************************
                        '100件登録あり
                        '*******************************************
                        strRes = "6"
                        Exit Try
                    End If
                End If


                '*******************************************
                'グループコードの存在チェック 2016/03/09 T.Ono add 2015改善開発
                '区分に毎に対応するマスタに、グループの登録があるか確認
                strSQL = New StringBuilder("")
                If pstrJAGKBN.Trim = "001" Then
                    strSQL.Append("SELECT GROUPCD ")
                    strSQL.Append("FROM M10_HANJIGYOSYA ")
                    strSQL.Append("WHERE GROUPCD = :GROUPCD ")
                    'SQL文セット
                    cdb.pSQL = strSQL.ToString
                    'パラメータに値をセット
                    cdb.pSQLParamStr("GROUPCD") = pstrGROUPCD

                ElseIf pstrJAGKBN.Trim = "002" Then
                    strSQL.Append("SELECT GROUPCD ")
                    strSQL.Append("FROM M11_JAHOKOKU ")
                    strSQL.Append("WHERE GROUPCD = :GROUPCD ")
                    'SQL文セット
                    cdb.pSQL = strSQL.ToString
                    'パラメータに値をセット
                    cdb.pSQLParamStr("GROUPCD") = pstrGROUPCD

                ElseIf pstrJAGKBN.Trim = "003" Then           '2017/02/09 w.ganeko 2016監視改善 №10
                    strSQL.Append("SELECT GROUPCD ")
                    strSQL.Append("FROM M08_AUTOTAIOU ")
                    strSQL.Append("WHERE GROUPCD = :GROUPCD ")
                    'SQL文セット
                    cdb.pSQL = strSQL.ToString
                    'パラメータに値をセット
                    cdb.pSQLParamStr("GROUPCD") = pstrGROUPCD

                ElseIf pstrJAGKBN.Trim = "004" Then '2019/01/28 T.Ono add 2018改善開発
                    strSQL.Append("SELECT GROUPCD ")
                    strSQL.Append("FROM M12_HANBAITEN ")
                    strSQL.Append("WHERE GROUPCD = :GROUPCD ")
                    'SQL文セット
                    cdb.pSQL = strSQL.ToString
                    'パラメータに値をセット
                    cdb.pSQLParamStr("GROUPCD") = pstrGROUPCD

                Else
                    strSQL.Append("SELECT 'X' ")
                    strSQL.Append("FROM DUAL ")
                    strSQL.Append("WHERE 1 <> 1 ")
                End If

                'SQL実行
                cdb.mExecQuery()
                ds = cdb.pResult

                If (ds.Tables(0).Rows.Count = 0) Then
                    '*******************************************
                    'グループコードが存在しない時
                    '*******************************************
                    strRes = "7"
                    Exit Try
                End If
            End If

            'データの更新処理--------------------------------

            If pintMODE = 3 Then
                '処理区分が削除
                strSQL = New StringBuilder("")
                strSQL.Append("DELETE ")
                strSQL.Append("FROM ")
                strSQL.Append("	    M09_JAGROUP ")
                strSQL.Append("WHERE ")
                strSQL.Append("	    KBN = :JAGKBN ")
                strSQL.Append("AND  KURACD = :KURACD ")
                strSQL.Append("AND	ACBCD = :ACBCD ")
                If pstrJAGKBN.Trim <> "003" Then           '2017/02/09 w.ganeko 2016監視改善 №10
                    If pstrUSERCD_F.Trim.Length > 0 Then
                        strSQL.Append("AND	USERCD_FROM = :USERCD_F ")
                    Else
                        strSQL.Append("AND	USERCD_FROM IS NULL ")
                    End If
                End If

            ElseIf pintMODE = 2 Then
                '処理区分が更新
                strSQL = New StringBuilder("")
                strSQL.Append("UPDATE ")
                strSQL.Append("         M09_JAGROUP ")
                strSQL.Append("SET ")
                strSQL.Append("     	KBN = :JAGKBN, ")
                strSQL.Append("     	KURACD = :KURACD, ")
                strSQL.Append("     	ACBCD = :ACBCD, ")
                strSQL.Append("     	GROUPCD = :GROUPCD, ")
                strSQL.Append("     	USERCD_FROM = :USERCD_F, ")
                strSQL.Append("     	USERCD_TO = :USERCD_T, ")
                strSQL.Append("     	BIKO = :BIKO, ")
                strSQL.Append("     	INS_DATE = TO_DATE(:INS_DATE, 'YYYY/MM/DD HH24:MI:SS'), ")
                strSQL.Append("     	INS_USER = :INS_USER, ")
                strSQL.Append("     	UPD_DATE = TO_DATE(:UPD_DATE, 'YYYY/MM/DD HH24:MI:SS'), ")
                strSQL.Append("     	UPD_USER = :UPD_USER ")
                strSQL.Append("WHERE ")
                strSQL.Append("	    KBN = :JAGKBN ")
                strSQL.Append("AND  KURACD = :KURACD ")
                strSQL.Append("AND	ACBCD = :ACBCD ")
                If pstrJAGKBN.Trim <> "003" Then           '2017/02/09 w.ganeko 2016監視改善 №10
                    If pstrUSERCD_F.Trim.Length > 0 Then
                        strSQL.Append("AND	USERCD_FROM = :USERCD_F ")
                    Else
                        strSQL.Append("AND	USERCD_FROM IS NULL ")
                    End If
                End If
            ElseIf pintMODE = 1 Then
                '処理区分が新規
                strSQL = New StringBuilder("")
                strSQL.Append("INSERT INTO ")
                strSQL.Append(" M09_JAGROUP (")
                strSQL.Append("     KBN, ")
                strSQL.Append("     KURACD, ")
                strSQL.Append("     ACBCD, ")
                strSQL.Append("     GROUPCD, ")
                strSQL.Append("     USERCD_FROM, ")
                strSQL.Append("     USERCD_TO, ")
                strSQL.Append("     BIKO, ")
                strSQL.Append("     INS_DATE, ")
                strSQL.Append("     INS_USER, ")
                strSQL.Append("     UPD_DATE, ")
                strSQL.Append("     UPD_USER ")
                strSQL.Append(") VALUES(")
                strSQL.Append("		:JAGKBN, ")
                strSQL.Append("		:KURACD, ")
                strSQL.Append("		:ACBCD, ")
                strSQL.Append("		:GROUPCD, ")
                strSQL.Append("		:USERCD_F, ")
                strSQL.Append("		:USERCD_T, ")
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
                    cdb.pSQLParamStr("JAGKBN") = pstrJAGKBN
                    cdb.pSQLParamStr("ACBCD") = pstrACBCD
                    cdb.pSQLParamStr("KURACD") = pstrKURACD
                    If pstrUSERCD_F.Trim.Length > 0 Then
                        cdb.pSQLParamStr("USERCD_F") = pstrUSERCD_F
                    End If

                ElseIf pintMODE = 1 Or pintMODE = 2 Then

                    cdb.pSQLParamStr("JAGKBN") = pstrJAGKBN
                    cdb.pSQLParamStr("ACBCD") = pstrACBCD
                    cdb.pSQLParamStr("KURACD") = pstrKURACD
                    cdb.pSQLParamStr("GROUPCD") = pstrGROUPCD
                    cdb.pSQLParamStr("BIKO") = pstrBIKO
                    cdb.pSQLParamStr("USERCD_F") = pstrUSERCD_F
                    cdb.pSQLParamStr("USERCD_T") = pstrUSERCD_T


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
                                        ByVal pstrAUTHCENTERCD As String, _
                                        ByVal pstrJAGKBN As String, _
                                        ByVal pstrKURACD As String, _
                                        ByVal pstrACBCD_F As String, _
                                        ByVal pstrACBCD_T As String, _
                                        ByVal pstrGROUPCD As String, _
                                        ByVal pstrSYU_TOUROKU As Boolean, _
                                        ByVal pstrSYU_MITOUROKU As Boolean _
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

        '関連する監視センターのクライアントコードのみ出力すること
        'ＡＤ認証された「使用可能監視センター」に所属するクライアントを出力
        Dim i As Integer
        Dim arrTemp() As String
        Dim strCenter As String = ""
        arrTemp = pstrAUTHCENTERCD.Split(Convert.ToChar(","))
        For i = 0 To arrTemp.Length - 1
            If strCenter.Length > 0 Then
                strCenter = strCenter & ","
            End If
            strCenter = strCenter & "'" & arrTemp(i) & "'"
        Next

        '接続OPEN----------------------------------------
        Try
            cdb.mOpen()
        Catch ex As Exception
            Return ex.ToString
        Finally
        End Try
        Try
            strSQL = New StringBuilder("")
            strSQL.Append("WITH Z AS( ")

            If pstrSYU_TOUROKU = True Then
                '登録分
                strSQL.Append("SELECT CASE WHEN USERCD_FROM IS NULL THEN '1' ")
                strSQL.Append("	WHEN USERCD_FROM IS NOT NULL AND USERCD_TO IS NOT NULL THEN '2' ")
                strSQL.Append("	WHEN USERCD_FROM IS NOT NULL AND USERCD_TO IS NULL THEN '3' ")
                strSQL.Append("	ELSE '0' ")
                strSQL.Append("	END AS NO ")
                strSQL.Append("	,A.KBN ")
                strSQL.Append("	,A.KURACD ")
                strSQL.Append("	,A.ACBCD ")
                strSQL.Append("	,A.GROUPCD ")
                strSQL.Append("	,A.USERCD_FROM ")
                strSQL.Append("	,A.USERCD_TO ")
                strSQL.Append("	,A.BIKO ")
                strSQL.Append("	,TO_CHAR(A.INS_DATE, 'YYYY/MM/DD HH24:MI:SS') AS INS_DATE ")
                strSQL.Append("	,A.INS_USER ")
                strSQL.Append("	,TO_CHAR(A.UPD_DATE, 'YYYY/MM/DD HH24:MI:SS') AS UPD_DATE ")
                strSQL.Append("	,A.UPD_USER ")
                strSQL.Append("	,B.GROUPNM ")
                strSQL.Append("	,A.KURACD AS KURACD2 ") 'ｸﾗｲｱﾝﾄの一覧を作るために使用
                strSQL.Append("	,A.ACBCD AS ACBCD2 ") 'JA支所の一覧を作るために使用
                strSQL.Append("FROM M09_JAGROUP A ")
                strSQL.Append(" ,CLIMAS C ") '監視ｾﾝﾀｰｺｰﾄﾞでの絞込　2015/12/10 T.Ono add 
                'グループ名称取得
                If pstrJAGKBN.Trim = "001" Then
                    '販売事業者グループマスタ
                    strSQL.Append(" ,M10_HANJIGYOSYA B ")
                ElseIf pstrJAGKBN.Trim = "002" Then
                    'JA担当者・連絡先・注意事項マスタ　2015/12/10 T.Ono add 2015改善開発 №7
                    strSQL.Append(" ,M11_JAHOKOKU B ")
                ElseIf pstrJAGKBN.Trim = "003" Then
                    '自動対応マスタ　2017/02/09 W.Ganeko add 2016改善開発 №10
                    strSQL.Append(" ,(SELECT GROUPCD,GROUPNM FROM M08_AUTOTAIOU GROUP BY GROUPCD,GROUPNM) B ")
                ElseIf pstrJAGKBN.Trim = "004" Then
                    '販売店グループマスタ　2019/01/28 T.Ono add 2018改善開発
                    strSQL.Append(" ,M12_HANBAITEN B ")
                End If
                strSQL.Append("WHERE 1=1 ")
                strSQL.Append("AND A.KBN = :JAGKBN ")
                '監視センターコード。指定の監視センターのみ。指定が無い場合は全て。2015/12/10 T.Ono add 
                If strCenter.Length > 0 Then
                    strSQL.Append("AND C.KANSI_CODE IN (" & strCenter & ") ")
                End If
                strSQL.Append("AND A.KURACD = C.CLI_CD ") '2015/12/10 T.Ono add 

                If pstrKURACD.Trim.Length > 0 Then
                    strSQL.Append("AND A.KURACD = :KURACD ")
                End If
                If pstrACBCD_F.Trim.Length > 0 AndAlso pstrACBCD_T.Trim.Length > 0 Then
                    strSQL.Append("AND A.ACBCD >= :ACBCD_F ")
                    strSQL.Append("AND A.ACBCD <= :ACBCD_T ")
                End If
                If pstrGROUPCD.Trim.Length > 0 Then
                    strSQL.Append("AND A.GROUPCD = :GROUPCD ")
                End If
                '区分により、処理変更
                If pstrJAGKBN.Trim = "001" Then
                    strSQL.Append("AND A.GROUPCD = B.GROUPCD(+) ")
                ElseIf pstrJAGKBN.Trim = "002" Then '2015/12/10 T.Ono add 2015改善開発 №7
                    strSQL.Append("AND A.GROUPCD = B.GROUPCD(+) ")
                    strSQL.Append("AND LPAD(B.TANCD, 2, '0') = '01' ")
                ElseIf pstrJAGKBN.Trim = "003" Then '2017/02/09 W.GANEKO add 2016改善開発 №10
                    strSQL.Append("AND A.GROUPCD = B.GROUPCD(+) ")
                ElseIf pstrJAGKBN.Trim = "004" Then '2019/01/28 T.Ono add 2018開発改善
                    strSQL.Append("AND A.GROUPCD = B.GROUPCD(+) ")
                End If
            End If

            If pstrSYU_TOUROKU = True AndAlso pstrSYU_MITOUROKU = True Then
                strSQL.Append("UNION ALL ")
            End If

            If pstrSYU_MITOUROKU = True Then
                strSQL.Append("SELECT '1' AS NO ")
                strSQL.Append("	,:JAGKBN AS KBN ")
                strSQL.Append("	,'' AS KURACD ")
                strSQL.Append("	,'' ACBCD ")
                strSQL.Append("	,'' AS GROUPCD ")
                strSQL.Append("	,'' AS USERCD_FROM ")
                strSQL.Append("	,'' AS USERCD_TO ")
                strSQL.Append("	,'' AS BIKO ")
                strSQL.Append("	,'' AS INS_DATE ")
                strSQL.Append("	,'' AS INS_USER ")
                strSQL.Append("	,'' AS UPD_DATE ")
                strSQL.Append("	,'' AS UPD_USER ")
                strSQL.Append("	,'' AS GROUPNM ")
                strSQL.Append("	,A.CLI_CD AS KURACD2 ") 'ｸﾗｲｱﾝﾄの一覧を作るために使用
                strSQL.Append("	,A.HAN_CD AS ACBCD2 ") 'JA支所の一覧を作るために使用
                strSQL.Append("FROM HN2MAS A ")
                strSQL.Append("	,HN2MAS B ")
                strSQL.Append("	,CLIMAS C ")
                strSQL.Append("WHERE NOT EXISTS (SELECT 'X' ")
                strSQL.Append("	FROM M09_JAGROUP D ")
                strSQL.Append("	WHERE 1=1 ")
                strSQL.Append("	AND D.KBN = :JAGKBN ")
                strSQL.Append("	AND D.KURACD = A.CLI_CD ")
                strSQL.Append("	AND D.ACBCD = A.HAN_CD ")
                strSQL.Append("	AND D.USERCD_FROM IS NULL ")
                strSQL.Append("	) ")
                strSQL.Append("AND A.CLI_CD = B.CLI_CD ")
                strSQL.Append("AND A.HAN_CD = B.HAN_CD ")
                strSQL.Append("AND A.HAN_CD <> B.JA_CD ")
                strSQL.Append("AND C.CLI_CD = A.CLI_CD ")
                strSQL.Append("AND NVL(A.DEL_FLG,'0') <> '1' ")
                strSQL.Append("AND NVL(B.DEL_FLG,'0') <> '1' ")
                '監視センターコード。指定の監視センターのみ。指定が無い場合は全て。
                If strCenter.Length > 0 Then
                    strSQL.Append("AND C.KANSI_CODE IN (" & strCenter & ") ")
                End If
                If pstrKURACD.Trim.Length > 0 Then
                    strSQL.Append("AND A.CLI_CD = :KURACD ")
                End If
                If pstrACBCD_F.Trim.Length > 0 AndAlso pstrACBCD_T.Trim.Length > 0 Then
                    strSQL.Append("AND A.HAN_CD >= :ACBCD_F ")
                    strSQL.Append("AND A.HAN_CD <= :ACBCD_T ")
                End If
            End If

            strSQL.Append(") ")
            strSQL.Append("SELECT ")
            strSQL.Append("	Z.KBN AS KBN ")
            strSQL.Append("	,Z.KURACD AS KURACD ")
            strSQL.Append("	,Z.ACBCD AS ACBCD ")
            strSQL.Append("	,Z.GROUPCD AS GROUPCD ")
            strSQL.Append("	,Z.GROUPNM AS GROUPNM ")
            strSQL.Append("	,Z.USERCD_FROM AS USERCD_FROM ")
            strSQL.Append("	,Z.USERCD_TO AS USERCD_TO ")
            strSQL.Append("	,Z.BIKO AS BIKO ")
            strSQL.Append("	,Z.INS_DATE AS INS_DATE ")
            strSQL.Append("	,Z.INS_USER AS INS_USER ")
            strSQL.Append("	,Z.UPD_DATE AS UPD_DATE ")
            strSQL.Append("	,Z.UPD_USER AS UPD_USER ")
            strSQL.Append("	,A.CLI_CD AS HN2_KURACD ")
            strSQL.Append("	,A.HAN_CD AS HN2_ACBCD ")
            strSQL.Append("	,A.JAS_NAME AS HN2_ACBNM ")
            strSQL.Append("FROM Z, HN2MAS A ")
            strSQL.Append("WHERE Z.KURACD2 = A.CLI_CD ")
            strSQL.Append("AND Z.ACBCD2 = A.HAN_CD ")
            strSQL.Append("ORDER BY KBN, HN2_KURACD, HN2_ACBCD, NO, USERCD_FROM ")


            'SQL文セット
            cdb.pSQL = strSQL.ToString

            'パラメータに値をセット
            'グループ区分
            If pstrJAGKBN.Trim.Length > 0 Then
                cdb.pSQLParamStr("JAGKBN") = pstrJAGKBN
            End If
            'クライアントコード
            If pstrKURACD.Trim.Length > 0 Then
                cdb.pSQLParamStr("KURACD") = pstrKURACD
            End If
            'JA支所コード
            If pstrACBCD_F.Trim.Length > 0 AndAlso pstrACBCD_T.Trim.Length > 0 Then
                cdb.pSQLParamStr("ACBCD_F") = pstrACBCD_F
                cdb.pSQLParamStr("ACBCD_T") = pstrACBCD_T
            End If
            'グループコード
            If pstrGROUPCD.Trim.Length > 0 AndAlso pstrSYU_TOUROKU = True Then
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
            CSVC.pRepoID = "MSJAGJAW00"       '帳票ID
            CSVC.mOpen()
            Dim iCnt As Integer
            Dim irCnt As Integer
            For iCnt = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(iCnt)

                If iCnt = 0 Then
                    CSVC.pColValStrEx = "区分"
                    CSVC.pColValStrEx = "クライアント"
                    CSVC.pColValStrEx = "JA支所コード"
                    CSVC.pColValStrEx = "グループコード"
                    CSVC.pColValStrEx = "グループ名"
                    CSVC.pColValStrEx = "お客様コードFrom"
                    CSVC.pColValStrEx = "お客様コードTo"
                    CSVC.pColValStrEx = "備考"
                    CSVC.pColValStrEx = "登録日時"
                    CSVC.pColValStrEx = "登録者"
                    CSVC.pColValStrEx = "更新日時"
                    CSVC.pColValStrEx = "更新者"
                    CSVC.pColValStrEx = "支所２ｸﾗｲｱﾝﾄ"
                    CSVC.pColValStrEx = "支所２JA支所ｺｰﾄﾞ"
                    CSVC.pColValStrEx = "支所２JA支所名"
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

    '************************************************
    '販売事業者グループ追加・変更　pintMODE=7:追加　9:変更
    '************************************************
    <WebMethod()> Public Function mSetHANJIGYOSYA( _
                                ByVal pintMODE As Integer, _
                                ByVal pstrGROUPCD As String, _
                                ByVal pstrGROUPNM As String, _
                                ByVal pstrINS_DATE As String, _
                                ByVal pstrINS_USER As String, _
                                ByVal pstrUPD_DATE As String, _
                                ByVal pstrUPD_USER As String, _
                                ByVal pstrUSERNM As String _
                                ) As String

        Dim ds As New DataSet
        Dim cdb As New CDB
        Dim strRes As String
        Dim strSQL As StringBuilder
        Dim tmp As String

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


            '*********************************
            '処理ストーリー
            '・排他のチェックを行う。
            '*********************************

            'ＤＢチェック(基本)-----------------------------
            strSQL = New StringBuilder("")
            strSQL.Append("SELECT ")
            strSQL.Append("	    A.GROUPCD ")
            strSQL.Append("	    ,A.GROUPNM ")
            strSQL.Append("	    ,A.HANJIGYOSYANM ")
            strSQL.Append("	    ,A.BIKO ")
            strSQL.Append("	    ,TO_CHAR(A.INS_DATE, 'YYYY/MM/DD HH24:MI:SS') AS INS_DATE ")
            strSQL.Append("	    ,A.INS_USER ")
            strSQL.Append("	    ,TO_CHAR(A.UPD_DATE, 'YYYY/MM/DD HH24:MI:SS') AS UPD_DATE ")
            strSQL.Append("	    ,A.UPD_USER ")
            strSQL.Append("FROM ")
            strSQL.Append("	    M10_HANJIGYOSYA A ")
            strSQL.Append("WHERE ")
            strSQL.Append("	    A.GROUPCD = :GROUPCD ")
            strSQL.Append("FOR UPDATE NOWAIT ")             '排他制御をかける

            'SQL文セット
            cdb.pSQL = strSQL.ToString

            'パラメータに値をセット
            cdb.pSQLParamStr("GROUPCD") = pstrGROUPCD         'グループコード

            'SQL実行
            cdb.mExecQuery()
            ds = cdb.pResult


            '*******************************
            ' モードの再決定
            '*******************************
            If (ds.Tables(0).Rows.Count <> 0) Then 'ＤＢにデータが存在する？
                If pintMODE = 7 Then '追加ボタン
                    strRes = "1" '登録済みデータありのエラー
                    pintMODE = 0 '終了
                End If
            Else
                If pintMODE = 9 Then '変更ボタン
                    strRes = "2" '該当データなしのエラー
                    pintMODE = 0 '終了
                End If
            End If

            If (pintMODE = 9) Then 'ＤＢにデータが存在して、更新の場合
                '*******************************************
                '修正時で受け渡された日付及び時間と更新対象データが異なる場合エラー
                '*******************************************
                tmp = Convert.ToString(ds.Tables(0).Rows(0).Item("INS_DATE")) & "_" & Convert.ToString(ds.Tables(0).Rows(0).Item("UPD_DATE"))
                If (tmp <> pstrINS_DATE & "_" & pstrUPD_DATE) Then
                    strRes = "0"
                    pintMODE = 0 '終了
                End If

                '*******************************************
                ' 修正時でデータが変更されていない場合はスキップ
                '*******************************************
                If ( _
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("GROUPCD")) = pstrGROUPCD) And _
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("GROUPNM")) = pstrGROUPNM) _
                     ) Then

                    pintMODE = 0 '終了
                End If
            End If


            If pintMODE <> 0 Then
                'データの更新処理--------------------------------
                '追加処理
                If pintMODE = 9 Then
                    strSQL = New StringBuilder("")
                    strSQL.Append("UPDATE ")
                    strSQL.Append("	M10_HANJIGYOSYA ")
                    strSQL.Append("SET ")
                    strSQL.Append("	GROUPCD = :GROUPCD, ")
                    strSQL.Append("	GROUPNM = :GROUPNM, ")
                    strSQL.Append("	UPD_DATE = TO_DATE(:UPD_DATE, 'YYYY/MM/DD HH24:MI:SS'), ")
                    strSQL.Append("	UPD_USER = :UPD_USER ")
                    strSQL.Append("WHERE ")
                    strSQL.Append("	GROUPCD = :GROUPCD ")

                ElseIf pintMODE = 7 Then
                    strSQL = New StringBuilder("")
                    strSQL.Append("INSERT INTO ")
                    strSQL.Append(" M10_HANJIGYOSYA ( ")
                    strSQL.Append("     GROUPCD, ")
                    strSQL.Append("     GROUPNM, ")
                    strSQL.Append("     HANJIGYOSYANM, ")
                    strSQL.Append("     BIKO, ")
                    strSQL.Append("     INS_DATE, ")
                    strSQL.Append("     INS_USER, ")
                    strSQL.Append("     UPD_DATE, ")
                    strSQL.Append("     UPD_USER ")
                    strSQL.Append(") VALUES( ")
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
                If pintMODE = 9 Then
                    cdb.pSQLParamStr("GROUPCD") = pstrGROUPCD
                    cdb.pSQLParamStr("GROUPNM") = pstrGROUPNM
                    cdb.pSQLParamStr("UPD_DATE") = Now.ToString()
                    cdb.pSQLParamStr("UPD_USER") = pstrUSERNM.Trim

                ElseIf pintMODE = 7 Then
                    cdb.pSQLParamStr("GROUPCD") = pstrGROUPCD
                    cdb.pSQLParamStr("GROUPNM") = pstrGROUPNM
                    cdb.pSQLParamStr("HANJIGYOSYANM") = ""
                    cdb.pSQLParamStr("BIKO") = ""
                    cdb.pSQLParamStr("INS_DATE") = Now.ToString()
                    cdb.pSQLParamStr("INS_USER") = pstrUSERNM.Trim
                    cdb.pSQLParamStr("UPD_DATE") = ""
                    cdb.pSQLParamStr("UPD_USER") = ""
                End If

                'SQLを実行
                cdb.mExecNonQuery()
            End If


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
    'JA担当者・報告先・注意事項グループ追加・変更　pintMODE=7:追加　9:変更
    '************************************************
    <WebMethod()> Public Function mSetJAHOKOKU( _
                                ByVal pintMODE As Integer, _
                                ByVal pstrGROUPCD As String, _
                                ByVal pstrGROUPNM As String, _
                                ByVal pstrINS_DATE As String, _
                                ByVal pstrINS_USER As String, _
                                ByVal pstrUPD_DATE As String, _
                                ByVal pstrUPD_USER As String, _
                                ByVal pstrUSERNM As String _
                                ) As String

        Dim ds As New DataSet
        Dim cdb As New CDB
        Dim strRes As String
        Dim strSQL As StringBuilder
        Dim tmp As String

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

            '*********************************
            '処理ストーリー
            '・排他のチェックを行う。
            '*********************************

            'ＤＢチェック(基本)-----------------------------
            strSQL = New StringBuilder("")
            strSQL.Append("SELECT ")
            strSQL.Append("	    A.GROUPCD ")
            strSQL.Append("	    ,A.GROUPNM ")
            strSQL.Append("	    ,TO_CHAR(A.INS_DATE, 'YYYY/MM/DD HH24:MI:SS') AS INS_DATE ")
            strSQL.Append("	    ,A.INS_USER ")
            strSQL.Append("	    ,TO_CHAR(A.UPD_DATE, 'YYYY/MM/DD HH24:MI:SS') AS UPD_DATE ")
            strSQL.Append("	    ,A.UPD_USER ")
            strSQL.Append("FROM ")
            strSQL.Append("	    M11_JAHOKOKU A ")
            strSQL.Append("WHERE ")
            strSQL.Append("	    A.GROUPCD = :GROUPCD ")
            strSQL.Append("AND  LPAD(A.TANCD, 2, '0') = '01' ")
            strSQL.Append("FOR UPDATE NOWAIT ")             '排他制御をかける

            'SQL文セット
            cdb.pSQL = strSQL.ToString

            'パラメータに値をセット
            cdb.pSQLParamStr("GROUPCD") = pstrGROUPCD         'グループコード

            'SQL実行
            cdb.mExecQuery()
            ds = cdb.pResult


            '*******************************
            ' モードの再決定
            '*******************************
            If (ds.Tables(0).Rows.Count <> 0) Then 'ＤＢにデータが存在する？
                If pintMODE = 7 Then '追加ボタン
                    strRes = "1" '登録済みデータありのエラー
                    pintMODE = 0 '終了
                End If
            Else
                If pintMODE = 9 Then '変更ボタン
                    strRes = "2" '該当データなしのエラー
                    pintMODE = 0 '終了
                End If
            End If

            If (pintMODE = 9) Then 'ＤＢにデータが存在して、更新の場合
                '*******************************************
                '修正時で受け渡された日付及び時間と更新対象データが異なる場合エラー
                '*******************************************
                tmp = Convert.ToString(ds.Tables(0).Rows(0).Item("INS_DATE")) & "_" & Convert.ToString(ds.Tables(0).Rows(0).Item("UPD_DATE"))
                If (tmp <> pstrINS_DATE & "_" & pstrUPD_DATE) Then
                    strRes = "0"
                    pintMODE = 0 '終了
                End If

                '*******************************************
                ' 修正時でデータが変更されていない場合はスキップ
                '*******************************************
                If ( _
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("GROUPCD")) = pstrGROUPCD) And _
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("GROUPNM")) = pstrGROUPNM) _
                     ) Then

                    pintMODE = 0 '終了
                End If
            End If

            'グループコード名の重複はNGとする 2016/01/12 T.Ono add 2015改善開発 
            strSQL = New StringBuilder("")
            strSQL.Append("SELECT ")
            strSQL.Append("     'X' ")
            strSQL.Append("FROM ")
            strSQL.Append("		M11_JAHOKOKU A ")
            strSQL.Append("WHERE ")
            strSQL.Append("		1 = 1 ")
            strSQL.Append("AND	LPAD(A.TANCD,2,'0') = '01' ")
            strSQL.Append("AND	A.GROUPCD <> :GROUPCD ")
            strSQL.Append("AND	A.GROUPNM = :GROUPNM ")

            'SQL文セット
            cdb.pSQL = strSQL.ToString
            'バインド変数に値をセット
            cdb.pSQLParamStr("GROUPCD") = pstrGROUPCD       'グループコード
            cdb.pSQLParamStr("GROUPNM") = pstrGROUPNM       'グループコード名

            'SQL実行
            cdb.mExecQuery()
            ds = cdb.pResult

            If (ds.Tables(0).Rows.Count > 0) Then
                '*******************************************
                'グループコード名重複
                '*******************************************
                strRes = "3"
                Exit Try
            End If


            If pintMODE <> 0 Then
                'データの更新処理--------------------------------
                '追加処理
                If pintMODE = 9 Then
                    strSQL = New StringBuilder("")
                    strSQL.Append("UPDATE ")
                    strSQL.Append("	M11_JAHOKOKU ")
                    strSQL.Append("SET ")
                    strSQL.Append("	GROUPCD = :GROUPCD, ")
                    strSQL.Append("	GROUPNM = :GROUPNM, ")
                    strSQL.Append("	UPD_DATE = TO_DATE(:UPD_DATE, 'YYYY/MM/DD HH24:MI:SS'), ")
                    strSQL.Append("	UPD_USER = :UPD_USER ")
                    strSQL.Append("WHERE ")
                    strSQL.Append("	GROUPCD = :GROUPCD ")
                    strSQL.Append("AND  LPAD(TANCD, 2, '0') = '01' ")

                ElseIf pintMODE = 7 Then
                    strSQL = New StringBuilder("")
                    strSQL.Append("INSERT INTO  ")
                    strSQL.Append(" M11_JAHOKOKU ( ")
                    strSQL.Append("     KBN, ")
                    strSQL.Append("     GROUPCD, ")
                    strSQL.Append("     GROUPNM, ")
                    strSQL.Append("     TANNM, ")
                    strSQL.Append("     TANCD, ")
                    strSQL.Append("     RENTEL1, ")
                    strSQL.Append("     FAXKURAKBN, ")
                    strSQL.Append("     FAXKBN, ")
                    strSQL.Append("     INS_DATE, ")
                    strSQL.Append("     INS_USER, ")
                    strSQL.Append("     UPD_DATE, ")
                    strSQL.Append("     UPD_USER ")
                    strSQL.Append(") VALUES( ")
                    strSQL.Append("     '2', ")         '区分　2：グループコード登録
                    strSQL.Append("     :GROUPCD, ")
                    strSQL.Append("     :GROUPNM, ")
                    strSQL.Append("     '0', ")         '担当者名漢字
                    strSQL.Append("     '01', ")        'コード
                    strSQL.Append("     '0', ")         '電話番号１
                    strSQL.Append("     '0', ")         '報告要・不要初期値ｸﾗｲｱﾝﾄ
                    strSQL.Append("     '0', ")         '報告要・不要初期値JA
                    strSQL.Append("     TO_DATE(:INS_DATE, 'YYYY/MM/DD HH24:MI:SS'), ")
                    strSQL.Append("     :INS_USER, ")
                    strSQL.Append("     TO_DATE(:UPD_DATE, 'YYYY/MM/DD HH24:MI:SS'), ")
                    strSQL.Append("     :UPD_USER ")
                    strSQL.Append(")")
                End If

                'SQL文セット
                cdb.pSQL = strSQL.ToString

                'バインド変数に値をセット
                If pintMODE = 9 Then
                    cdb.pSQLParamStr("GROUPCD") = pstrGROUPCD
                    cdb.pSQLParamStr("GROUPNM") = pstrGROUPNM
                    cdb.pSQLParamStr("UPD_DATE") = Now.ToString()
                    cdb.pSQLParamStr("UPD_USER") = pstrUSERNM.Trim

                ElseIf pintMODE = 7 Then
                    cdb.pSQLParamStr("GROUPCD") = pstrGROUPCD
                    cdb.pSQLParamStr("GROUPNM") = pstrGROUPNM
                    cdb.pSQLParamStr("INS_DATE") = Now.ToString()
                    cdb.pSQLParamStr("INS_USER") = pstrUSERNM.Trim
                    cdb.pSQLParamStr("UPD_DATE") = ""
                    cdb.pSQLParamStr("UPD_USER") = ""
                End If

                'SQLを実行
                cdb.mExecNonQuery()
            End If


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
    '2017/02/09 W.GANEKO ADD START 2016監視改善 №10
    '************************************************
    '自動対応グループ追加・変更　pintMODE=7:追加　9:変更
    '************************************************
    <WebMethod()> Public Function mSetAUTOTAIOU( _
                                ByVal pintMODE As Integer, _
                                ByVal pstrGROUPCD As String, _
                                ByVal pstrGROUPNM As String, _
                                ByVal pstrINS_DATE As String, _
                                ByVal pstrINS_USER As String, _
                                ByVal pstrUPD_DATE As String, _
                                ByVal pstrUPD_USER As String, _
                                ByVal pstrUSERNM As String _
                                ) As String

        Dim ds As New DataSet
        Dim cdb As New CDB
        Dim strRes As String
        Dim strSQL As StringBuilder
        Dim tmp As String

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

            '*********************************
            '処理ストーリー
            '・排他のチェックを行う。
            '*********************************

            'ＤＢチェック(基本)-----------------------------
            strSQL = New StringBuilder("")
            strSQL.Append("SELECT ")
            strSQL.Append("	    A.GROUPCD ")
            strSQL.Append("	    ,A.GROUPNM ")
            strSQL.Append("	    ,TO_CHAR(A.INS_DATE, 'YYYY/MM/DD HH24:MI:SS') AS INS_DATE ")
            strSQL.Append("	    ,TO_CHAR(A.UPD_DATE, 'YYYY/MM/DD HH24:MI:SS') AS UPD_DATE ")
            strSQL.Append("FROM ")
            strSQL.Append("	    M08_AUTOTAIOU A ")
            strSQL.Append("WHERE ")
            strSQL.Append("	    A.GROUPCD = :GROUPCD ")
            strSQL.Append("FOR UPDATE NOWAIT ")             '排他制御をかける

            'SQL文セット
            cdb.pSQL = strSQL.ToString

            'パラメータに値をセット
            cdb.pSQLParamStr("GROUPCD") = pstrGROUPCD         'グループコード

            'SQL実行
            cdb.mExecQuery()
            ds = cdb.pResult


            '*******************************
            ' モードの再決定
            '*******************************
            If (ds.Tables(0).Rows.Count <> 0) Then 'ＤＢにデータが存在する？
                If pintMODE = 7 Then '追加ボタン
                    strRes = "1" '登録済みデータありのエラー
                    pintMODE = 0 '終了
                End If
            Else
                If pintMODE = 9 Then '変更ボタン
                    strRes = "2" '該当データなしのエラー
                    pintMODE = 0 '終了
                End If
            End If

            If (pintMODE = 9) Then 'ＤＢにデータが存在して、更新の場合
                '*******************************************
                '修正時で受け渡された日付及び時間と更新対象データが異なる場合エラー
                '*******************************************
                tmp = Convert.ToString(ds.Tables(0).Rows(0).Item("INS_DATE")) & "_" & Convert.ToString(ds.Tables(0).Rows(0).Item("UPD_DATE"))
                If (tmp <> pstrINS_DATE & "_" & pstrUPD_DATE) Then
                    strRes = "0"
                    pintMODE = 0 '終了
                End If

                '*******************************************
                ' 修正時でデータが変更されていない場合はスキップ
                '*******************************************
                If ( _
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("GROUPCD")) = pstrGROUPCD) And _
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("GROUPNM")) = pstrGROUPNM) _
                     ) Then

                    pintMODE = 0 '終了
                End If
            End If

            'グループコード名の重複はNGとする
            strSQL = New StringBuilder("")
            strSQL.Append("SELECT ")
            strSQL.Append("     'X' ")
            strSQL.Append("FROM ")
            strSQL.Append("		M08_AUTOTAIOU A ")
            strSQL.Append("WHERE ")
            strSQL.Append("		1 = 1 ")
            strSQL.Append("AND	A.GROUPCD <> :GROUPCD ")
            strSQL.Append("AND	A.GROUPNM = :GROUPNM ")

            'SQL文セット
            cdb.pSQL = strSQL.ToString
            'バインド変数に値をセット
            cdb.pSQLParamStr("GROUPCD") = pstrGROUPCD       'グループコード
            cdb.pSQLParamStr("GROUPNM") = pstrGROUPNM       'グループコード名

            'SQL実行
            cdb.mExecQuery()
            ds = cdb.pResult

            If (ds.Tables(0).Rows.Count > 0) Then
                '*******************************************
                'グループコード名重複
                '*******************************************
                strRes = "3"
                Exit Try
            End If


            If pintMODE <> 0 Then
                'データの更新処理--------------------------------
                '追加処理
                If pintMODE = 9 Then
                    strSQL = New StringBuilder("")
                    strSQL.Append("UPDATE ")
                    strSQL.Append("	M08_AUTOTAIOU ")
                    strSQL.Append("SET ")
                    strSQL.Append("	GROUPCD = :GROUPCD, ")
                    strSQL.Append("	GROUPNM = :GROUPNM, ")
                    strSQL.Append("	UPD_DATE = TO_DATE(:UPD_DATE, 'YYYY/MM/DD HH24:MI:SS') ")
                    strSQL.Append("WHERE ")
                    strSQL.Append("	GROUPCD = :GROUPCD ")

                ElseIf pintMODE = 7 Then
                    strSQL = New StringBuilder("")
                    strSQL.Append("INSERT INTO  ")
                    strSQL.Append(" M08_AUTOTAIOU ( ")
                    strSQL.Append("     GROUPCD, ")
                    strSQL.Append("     KMCD, ")
                    strSQL.Append("     KMNM, ")
                    strSQL.Append("     PROCKBN, ")
                    strSQL.Append("     TAIOKBN, ")
                    strSQL.Append("     TMSKB, ")
                    strSQL.Append("     TKTANCD, ")
                    strSQL.Append("     TAITCD, ")
                    strSQL.Append("     TFKICD, ")
                    strSQL.Append("     TKIGCD, ")
                    strSQL.Append("     TSADCD, ")
                    strSQL.Append("     TELRCD, ")
                    strSQL.Append("     TEL_MEMO1, ")
                    strSQL.Append("     USE_FLG, ")
                    strSQL.Append("     INS_DATE, ")
                    strSQL.Append("     UPD_DATE, ")
                    strSQL.Append("     BIKO, ")
                    strSQL.Append("     GROUPNM ")
                    strSQL.Append(") VALUES( ")
                    strSQL.Append("     :GROUPCD, ")    'グループコード
                    strSQL.Append("     '99', ")        '警報コード
                    strSQL.Append("     '0', ")         '警報名称
                    strSQL.Append("     '1', ")         '対応／無視区分
                    strSQL.Append("     NULL, ")        '対応区分
                    strSQL.Append("     NULL, ")        '処理区分
                    strSQL.Append("     NULL, ")        '監視センター担当者CD
                    strSQL.Append("     NULL, ")        '連絡相手CD
                    strSQL.Append("     NULL, ")        '復帰対応状況
                    strSQL.Append("     NULL, ")        'ガス器具
                    strSQL.Append("     NULL, ")        '作動原因
                    strSQL.Append("     NULL, ")        '電話連絡内容
                    strSQL.Append("     NULL, ")        '電話対応メモ１
                    strSQL.Append("     '1', ")         '使用フラグ
                    strSQL.Append("     TO_DATE(:INS_DATE, 'YYYY/MM/DD HH24:MI:SS'), ")
                    strSQL.Append("     TO_DATE(:INS_DATE, 'YYYY/MM/DD HH24:MI:SS'), ")
                    strSQL.Append("     NULL, ")        '備考
                    strSQL.Append("     :GROUPNM ")     'グループ名称
                    strSQL.Append(")")
                End If

                'SQL文セット
                cdb.pSQL = strSQL.ToString

                'バインド変数に値をセット
                If pintMODE = 9 Then
                    cdb.pSQLParamStr("GROUPCD") = pstrGROUPCD
                    cdb.pSQLParamStr("GROUPNM") = pstrGROUPNM
                    cdb.pSQLParamStr("UPD_DATE") = Now.ToString()

                ElseIf pintMODE = 7 Then
                    cdb.pSQLParamStr("GROUPCD") = pstrGROUPCD
                    cdb.pSQLParamStr("GROUPNM") = pstrGROUPNM
                    cdb.pSQLParamStr("INS_DATE") = Now.ToString()
                End If

                'SQLを実行
                cdb.mExecNonQuery()
            End If


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
    '販売店グループ追加・変更　pintMODE=7:追加　9:変更
    '************************************************
    <WebMethod()> Public Function mSetHANBAITEN(
                                ByVal pintMODE As Integer,
                                ByVal pstrGROUPCD As String,
                                ByVal pstrGROUPNM As String,
                                ByVal pstrINS_DATE As String,
                                ByVal pstrINS_USER As String,
                                ByVal pstrUPD_DATE As String,
                                ByVal pstrUPD_USER As String,
                                ByVal pstrUSERNM As String
                                ) As String

        Dim ds As New DataSet
        Dim cdb As New CDB
        Dim strRes As String
        Dim strSQL As StringBuilder
        Dim tmp As String

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


            '*********************************
            '処理ストーリー
            '・排他のチェックを行う。
            '*********************************

            'ＤＢチェック(基本)-----------------------------
            strSQL = New StringBuilder("")
            strSQL.Append("SELECT ")
            strSQL.Append("	    A.GROUPCD ")
            strSQL.Append("	    ,A.GROUPNM ")
            strSQL.Append("	    ,A.HANBAITENNM ")
            strSQL.Append("	    ,A.BIKO ")
            strSQL.Append("	    ,TO_CHAR(A.INS_DATE, 'YYYY/MM/DD HH24:MI:SS') AS INS_DATE ")
            strSQL.Append("	    ,A.INS_USER ")
            strSQL.Append("	    ,TO_CHAR(A.UPD_DATE, 'YYYY/MM/DD HH24:MI:SS') AS UPD_DATE ")
            strSQL.Append("	    ,A.UPD_USER ")
            strSQL.Append("FROM ")
            strSQL.Append("	    M12_HANBAITEN A ")
            strSQL.Append("WHERE ")
            strSQL.Append("	    A.GROUPCD = :GROUPCD ")
            strSQL.Append("FOR UPDATE NOWAIT ")             '排他制御をかける

            'SQL文セット
            cdb.pSQL = strSQL.ToString

            'パラメータに値をセット
            cdb.pSQLParamStr("GROUPCD") = pstrGROUPCD         'グループコード

            'SQL実行
            cdb.mExecQuery()
            ds = cdb.pResult


            '*******************************
            ' モードの再決定
            '*******************************
            If (ds.Tables(0).Rows.Count <> 0) Then 'ＤＢにデータが存在する？
                If pintMODE = 7 Then '追加ボタン
                    strRes = "1" '登録済みデータありのエラー
                    pintMODE = 0 '終了
                End If
            Else
                If pintMODE = 9 Then '変更ボタン
                    strRes = "2" '該当データなしのエラー
                    pintMODE = 0 '終了
                End If
            End If

            If (pintMODE = 9) Then 'ＤＢにデータが存在して、更新の場合
                '*******************************************
                '修正時で受け渡された日付及び時間と更新対象データが異なる場合エラー
                '*******************************************
                tmp = Convert.ToString(ds.Tables(0).Rows(0).Item("INS_DATE")) & "_" & Convert.ToString(ds.Tables(0).Rows(0).Item("UPD_DATE"))
                If (tmp <> pstrINS_DATE & "_" & pstrUPD_DATE) Then
                    strRes = "0"
                    pintMODE = 0 '終了
                End If

                '*******************************************
                ' 修正時でデータが変更されていない場合はスキップ
                '*******************************************
                If (
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("GROUPCD")) = pstrGROUPCD) And
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("GROUPNM")) = pstrGROUPNM)
                     ) Then

                    pintMODE = 0 '終了
                End If
            End If


            If pintMODE <> 0 Then
                'データの更新処理--------------------------------
                '追加処理
                If pintMODE = 9 Then
                    strSQL = New StringBuilder("")
                    strSQL.Append("UPDATE ")
                    strSQL.Append("	M12_HANBAITEN ")
                    strSQL.Append("SET ")
                    strSQL.Append("	GROUPCD = :GROUPCD, ")
                    strSQL.Append("	GROUPNM = :GROUPNM, ")
                    strSQL.Append("	UPD_DATE = TO_DATE(:UPD_DATE, 'YYYY/MM/DD HH24:MI:SS'), ")
                    strSQL.Append("	UPD_USER = :UPD_USER ")
                    strSQL.Append("WHERE ")
                    strSQL.Append("	GROUPCD = :GROUPCD ")

                ElseIf pintMODE = 7 Then
                    strSQL = New StringBuilder("")
                    strSQL.Append("INSERT INTO ")
                    strSQL.Append(" M12_HANBAITEN ( ")
                    strSQL.Append("     GROUPCD, ")
                    strSQL.Append("     GROUPNM, ")
                    strSQL.Append("     HANBAITENNM, ")
                    strSQL.Append("     BIKO, ")
                    strSQL.Append("     INS_DATE, ")
                    strSQL.Append("     INS_USER, ")
                    strSQL.Append("     UPD_DATE, ")
                    strSQL.Append("     UPD_USER ")
                    strSQL.Append(") VALUES( ")
                    strSQL.Append("		:GROUPCD, ")
                    strSQL.Append("		:GROUPNM, ")
                    strSQL.Append("		:HANBAITENNM, ")
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
                If pintMODE = 9 Then
                    cdb.pSQLParamStr("GROUPCD") = pstrGROUPCD
                    cdb.pSQLParamStr("GROUPNM") = pstrGROUPNM
                    cdb.pSQLParamStr("UPD_DATE") = Now.ToString()
                    cdb.pSQLParamStr("UPD_USER") = pstrUSERNM.Trim

                ElseIf pintMODE = 7 Then
                    cdb.pSQLParamStr("GROUPCD") = pstrGROUPCD
                    cdb.pSQLParamStr("GROUPNM") = pstrGROUPNM
                    cdb.pSQLParamStr("HANBAITENNM") = ""
                    cdb.pSQLParamStr("BIKO") = ""
                    cdb.pSQLParamStr("INS_DATE") = Now.ToString()
                    cdb.pSQLParamStr("INS_USER") = pstrUSERNM.Trim
                    cdb.pSQLParamStr("UPD_DATE") = ""
                    cdb.pSQLParamStr("UPD_USER") = ""
                End If

                'SQLを実行
                cdb.mExecNonQuery()
            End If


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
