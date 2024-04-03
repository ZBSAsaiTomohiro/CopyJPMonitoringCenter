'***********************************************
'供給センターマスタ
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


<System.Web.Services.WebService(Namespace:="http://tempuri.org/MSKYOJAW00/Service1")> _
Public Class MSKYOJAW00
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
    '供給センターマスタリストデータ取得
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
        ' strAUTO_MAIL配列を空で用意
        Dim strKYOKYUCD() As String
        strKYOKYUCD = New String(pstrKYOKYUCD.Length) {} '配列の実体を確保
        Dim strKYOKYUNM() As String
        strKYOKYUNM = New String(pstrKYOKYUNM.Length) {} '配列の実体を確保
        Dim strDEL() As String
        strDEL = New String(pstrDEL.Length) {} '配列の実体を確保
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
            For i = 1 To 30 '30件を１件ずつ登録／修正／削除する。
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
    '供給センターマスタ更新
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
            '処理ストーリー
            '・排他のチェックを行う。
            '・登録時にはデータは未だ存在しないこと
            '・修正時にはデータは存在すること
            '・センターコードの存在チェックを行う
            '*********************************

            'ＤＢチェック(基本)-----------------------------
            strSQL = New StringBuilder("")
            strSQL.Append("SELECT ")
            strSQL.Append("  KEN_CD, ")
            strSQL.Append("  HAISO_CD, ")
            strSQL.Append("  NAME, ")
            strSQL.Append("  EDT_DATE, ")                    '更新日
            strSQL.Append("  TIME ")                        '更新時間
            strSQL.Append("FROM ")
            strSQL.Append("  HAIMAS ")                      '供給センターマスタ
            strSQL.Append("WHERE KEN_CD  =:KEN_CD  ")       '県コード
            strSQL.Append("  AND HAISO_CD =:HAISO_CD ")     '供給センターコード
            strSQL.Append("FOR UPDATE NOWAIT ")             '排他制御をかける

            'SQL文セット
            cdb.pSQL = strSQL.ToString

            'パラメータに値をセット
            cdb.pSQLParamStr("KEN_CD") = pstrKENCD           '県コード
            cdb.pSQLParamStr("HAISO_CD") = pstrKYOKYUCD       '供給センターコード

            'SQL実行
            cdb.mExecQuery()
            ds = cdb.pResult

            '*******************************
            ' モードの再決定
            '*******************************
            If (ds.Tables(0).Rows.Count <> 0) Then 'ＤＢにデータが存在する？
                If pintMODE = 4 Then 'pintMODE=4(削除)
                    If pstrDEL = "true" Then '登録元データはない？
                        pintMODE = 3 'モード＝3：削除
                    Else
                        pintMODE = 4 'モード＝2：更新
                    End If
                Else
                    pintMODE = 2 'モード＝2：更新
                End If
            Else
                If pstrKYOKYUCD = "" Then '登録元データはない？
                    pintMODE = 4 'モード＝4：スキップ
                ElseIf pstrDEL = "true" Then
                    pintMODE = 4 'モード＝4：スキップ
                    strRes = "0"
                Else
                    pintMODE = 1 'モード＝1：新規
                End If
            End If

            If (pintMODE = 2) Then 'ＤＢにデータが存在して、更新の場合
                '*******************************************
                '修正時で受け渡された日付及び時間と更新対象データが異なる場合エラー
                '*******************************************
                tmp = Convert.ToString(ds.Tables(0).Rows(0).Item("EDT_DATE")) & Convert.ToString(ds.Tables(0).Rows(0).Item("TIME"))
                If (tmp <> pstrEDT_DT) Then
                    strRes = "0"
                    Exit Try
                End If

                '*******************************************
                ' 修正時でデータが変更されていない場合はスキップ
                '*******************************************
                If ( _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("HAISO_CD")) = pstrKYOKYUCD) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("NAME")) = pstrKYOKYUNM) _
                     ) Then

                    pintMODE = 4 'スキップ
                End If
            End If

            If pintMODE = 4 Then
                'スキップ→次のレコード
                Exit Try
            End If
            'ＤＢチェック-----------------------------------
            '登録修正時、ＪＡ担当者の場合は、クライアントコードの存在チェックを行う
            If (pintMODE = 1 Or pintMODE = 2) Then

                strSQL = New StringBuilder("")
                strSQL.Append("SELECT DISTINCT ")
                strSQL.Append(" KEN_CODE ")                     '県コード
                strSQL.Append("FROM ")
                strSQL.Append("CLIMAS ")                        'クライアントマスタ
                strSQL.Append("WHERE KANSI_CODE IS NOT NULL ")  'クライアントコード
                strSQL.Append("AND KEN_CODE = :KEN_CD ")         'クライアントコード

                'SQL文セット
                cdb.pSQL = strSQL.ToString

                'パラメータに値をセット
                cdb.pSQLParamStr("KEN_CD") = pstrKENCD

                'SQL実行
                cdb.mExecQuery()
                ds = cdb.pResult

                If (ds.Tables(0).Rows.Count = 0) Then
                    '*******************************************
                    '県コードが存在しない時
                    '*******************************************
                    strRes = "4"
                    Exit Try
                End If
            End If

            'データの更新処理--------------------------------

            If pintMODE = 3 Then
                '処理区分が削除
                strSQL = New StringBuilder("")
                strSQL.Append("DELETE ")
                strSQL.Append("FROM ")
                strSQL.Append("HAIMAS ")                        '供給センターマスタ
                strSQL.Append("WHERE KEN_CD  =:KEN_CD  ")       '県コード
                strSQL.Append("  AND HAISO_CD =:HAISO_CD ")     '供給センターコード

            ElseIf pintMODE = 2 Then
                '処理区分が修正
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
                strSQL.Append("      KEN_CD  =:KEN_CD  ")        '県コード
                strSQL.Append("  AND HAISO_CD =:HAISO_CD ")      '供給センターコード

            ElseIf pintMODE = 1 Then
                '処理区分が新規
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

            'SQL文セット
            cdb.pSQL = strSQL.ToString
            'バインド変数に値をセット
            If pintMODE = 3 Then
                cdb.pSQLParamStr("KEN_CD") = pstrKENCD           '県コード
                cdb.pSQLParamStr("HAISO_CD") = pstrKYOKYUCD         '供給センターコード
            ElseIf pintMODE = 1 Or pintMODE = 2 Then

                cdb.pSQLParamStr("KEN_CD") = pstrKENCD           '県コード
                cdb.pSQLParamStr("HAISO_CD") = pstrKYOKYUCD       '供給センターコード
                cdb.pSQLParamStr("NAME") = pstrKYOKYUNM       '供給センター名

                If pintMODE = 1 Then
                    '新規登録の場合
                    cdb.pSQLParamStr("ADD_DATE") = Now.ToString("yyyyMMdd")
                    cdb.pSQLParamStr("EDT_DATE") = ""
                Else
                    '修正登録の場合
                    cdb.pSQLParamStr("ADD_DATE") = pstrADD_DATE
                    cdb.pSQLParamStr("EDT_DATE") = Now.ToString("yyyyMMdd")
                End If
                cdb.pSQLParamStr("TIME") = Now.ToString("HHmmss")
            End If

            'SQLを実行
            cdb.mExecNonQuery()

        Catch ex As NullReferenceException
            strRes = "0"
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
    '*　概　要:需要家更新・削除一覧の出力を行います
    '*　備　考:
    '******************************************************************************
    '　DATA0:対象データがありません
    <WebMethod()> Public Function mCSV( _
                                        ByVal pstrSessionID As String, _
                                        ByVal pstrKENCD As String _
                                        ) As String

        Dim strSQL As New StringBuilder("")
        Dim cdb As New CDB
        Dim ds As New DataSet
        Dim dr As DataRow
        Dim CSVC As New CCSV                            'CSVクラス
        Dim compressC As New CCompress                  '圧縮クラス
        Dim DateFncC As New CDateFnc                    '日付変換クラス
        Dim CTimeFncC As New CTimeFnc                   '時間変換クラス
        Dim FileToStrC As New CFileStr                  'ファイルをBase64にエンコードするクラス
        Dim intPrntRow As Integer = 72

        Dim strTmp() As String

        Dim i As Integer ' 2011/05/17 T.Watabe add


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
            strSQL.Append("  KEN_CD, ")
            strSQL.Append("  HAISO_CD, ")
            strSQL.Append("  NAME, ")
            strSQL.Append("  ADD_DATE, ")                   '更新日
            strSQL.Append("  EDT_DATE, ")                   '更新日
            strSQL.Append("  TIME ")                        '更新時間
            strSQL.Append("FROM ")
            strSQL.Append("  HAIMAS ")                      '供給センターマスタ
            strSQL.Append("WHERE KEN_CD  =:KEN_CD  ")         '県コード
            strSQL.Append("ORDER BY TO_NUMBER(HAISO_CD)  ")   '県コード
            'SQL文セット
            cdb.pSQL = strSQL.ToString

            'パラメータに値をセット
            cdb.pSQLParamStr("KEN_CD") = pstrKENCD           '県コード

            'SQL実行
            cdb.mExecQuery()
            ds = cdb.pResult
            CSVC.pKencd = "00"
            CSVC.pSessionID = pstrSessionID   'セッションID
            CSVC.pRepoID = "MSKYOJAW00"       '帳票ID
            CSVC.mOpen()
            Dim iCnt As Integer
            Dim irCnt As Integer
            For iCnt = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(iCnt)
                If iCnt = 0 Then
                    CSVC.pColValStrEx = "県コード"
                    CSVC.pColValStrEx = "供給センターコード"
                    CSVC.pColValStrEx = "供給センター名"
                    CSVC.pColValStrEx = "登録日"
                    CSVC.pColValStrEx = "更新日"
                    CSVC.pColValStrEx = "更新時間"
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
            'エラーの内容とＳＱＬ文を返すbaba
            Return "ERROR:" & ex.ToString

        Finally
            cdb.mClose()        '接続クローズ
        End Try

    End Function
    '**********************************************************
    ' 2012/06/28 ADD W.GANEKO
    'ログ吐き出し
    '戻り値：書き込んだファイルへのフルパス
    '**********************************************************
    Public Sub mlog(ByVal pstrString As String)
        Dim strFilnm As String = "testKyokyu" & System.DateTime.Today.ToString("yyyyMMdd")
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
