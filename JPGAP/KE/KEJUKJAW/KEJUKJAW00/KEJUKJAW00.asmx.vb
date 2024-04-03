'***********************************************
' 監視警報受信画面
'***********************************************
'変更履歴
'2009/11/04 T.Watabe add 6lines 重複データ処理済更新処理：名称も比較対象とする
'2009/11/30 T.Watabe add 2lines 重複データ処理済更新処理：対象をシリアルで絞り込む
'2011/12/05 H.Uema   add 警報の自動対応処理登録処理追加
'2012/01/30 T.Watabe edit USE_FLGを参照していない点を修正
'2012/03/30 W.GANEKO edit USE_FLGを参照していない点を修正
'2014/10/17 H.HOSODA 2014改善開発 No1 重複警報の抽出条件を変更
'2014/10/17 H.HOSODA 重複警報の処理済更新〜自動対応までのデータ抽出条件に処理番号を追加
'2021/10/01 Saka 2021年度監視改善�B自動対応で対応中の警報は落とさない（感震器遮断警報を自動対応にする作業を地震直後の運用中に更新するため）
'2021/10/01 Saka 2021年度監視改善�Eの感震器遮断の未処理警報を出力するときに既存バグで対応済みでないのに対応完了日(SYOYMD)に日付がセットされるのを防ぐ
'2021/10/01 Saka 2021年度監視改善�F電話番号14ケタ化対応（市外4桁、市内10けた）で、JUTEL2のハイフンセット処理を無効にして、市内10桁をハイフンなしでそのまま10桁セットとする
'2023/01/06 Y.ARAKAKI 2022更改No�E _帳票JMコード表示追加対応  


Option Explicit On
Option Strict On

Imports Common.DB

Imports System.Web.Services
Imports System.Text
Imports System.IO
Imports System.Configuration


<System.Web.Services.WebService(Namespace:="http://tempuri.org/KEJUKJAW00/Service1")> _
Public Class KEJUKJAW00
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


    '************************************************
    'パラメータ処理番号データのロックフラグを解除(NULL)します
    '-----JPGのfncUpdateNoRocへ処理を移管したため、現在未使用-----
    '************************************************
    <WebMethod()> Public Function mSet_NoRoc(ByVal pstrSERIAL As String) As String
        Dim ds As New DataSet
        Dim cdb As New CDB
        Dim strRes As String
        Dim strSQL As StringBuilder
        mlog("[KEJUKJAW00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- mSet_NoRoc start pstrSERIAL=" & pstrSERIAL)

        strRes = "OK"

        '------------------------------------------------
        '接続OPEN----------------------------------------
        Try
            cdb.mOpen()
        Catch ex As Exception
            strRes = ex.ToString
            Return strRes
        Finally

        End Try

        Try
            '------------------------------------------------
            'トランザクション開始--------------------------
            cdb.mBeginTrans()

            '*********************************
            '処理ストーリー
            '[1]既に対応済みかのチェックを行う(Reaction)
            '*********************************

            '------------------------------------------------
            'ＤＢチェック-----------------------------------
            strSQL = New StringBuilder("")
            strSQL.Append("SELECT ")
            strSQL.Append(" NVL(ROC_FRG,'') AS ROC_FRG, ")      'ロックフラグ
            strSQL.Append(" SYORI_SERIAL ")                     '処理番号
            strSQL.Append("FROM ")
            strSQL.Append("T10_KEIHO ")                         '警報ＤＢ
            strSQL.Append("WHERE SYORI_SERIAL =:SYORI_SERIAL ") '処理番号
            strSQL.Append("  AND REACTION = '0' ")              '処理状態(Oでない場合は既に対応入力登録ずみとなる)
            strSQL.Append("FOR UPDATE ")                        '排他制御をかける

            'SQL文セット
            cdb.pSQL = strSQL.ToString
            'パラメータに値をセット
            cdb.pSQLParamStr("SYORI_SERIAL") = pstrSERIAL       '処理番号
            'SQL実行
            cdb.mExecQuery()
            ds = cdb.pResult

            'データが存在しない場合は対応入力済みデータとして｢1｣をRETURNする
            If (ds.Tables(0).Rows.Count = 0) Then
                strRes = "1"
                Exit Try
            End If

            If (Convert.ToString(ds.Tables(0).Rows(0).Item("ROC_FRG")) = "") Then
                'ロールバック
                cdb.mRollback()
                Exit Try
            End If

            '------------------------------------------------
            'ＤＢ更新（ロック解除）----------------------------
            strSQL = New StringBuilder("")
            strSQL.Append("")
            strSQL.Append("UPDATE ")
            strSQL.Append("T10_KEIHO ")
            strSQL.Append("SET ")
            strSQL.Append("ROC_FRG = NULL, ")                   'ロックフラグ
            strSQL.Append("ROC_TIME= NULL ")                   'ロック時間
            strSQL.Append("WHERE SYORI_SERIAL =:SYORI_SERIAL ") '処理番号

            'SQL文セット
            cdb.pSQL = strSQL.ToString
            'パラメータセット
            cdb.pSQLParamStr("SYORI_SERIAL") = pstrSERIAL              '処理番号
            'SQLを実行
            cdb.mExecNonQuery()

            'コミット
            cdb.mCommit()
        Catch ex As Exception
            'エラーが起きたら エラー内容を格納
            strRes = ex.ToString
            'ロールバック
            cdb.mRollback()
            strRes = strRes & cdb.pErr
        Finally
            '接続クローズ
            cdb.mClose()
        End Try

        cdb = Nothing
        mlog("[KEJUKJAW00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- mSet_NoRoc end pstrSERIAL=" & pstrSERIAL)

        Return strRes
    End Function


    '************************************************
    'パラメータ処理番号データのロックフラグを設定します
    '-----JPGのfncUpdateNoRocへ処理を移管したため、現在未使用-----
    '************************************************
    <WebMethod()> Public Function mSet_Roc(ByVal pstrSERIAL As String) As String
        Dim ds As New DataSet
        Dim cdb As New CDB
        Dim strRes As String
        Dim strSQL As StringBuilder
        mlog("[KEJUKJAW00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- mSet_Roc start pstrSERIAL=" & pstrSERIAL)

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
            '------------------------------------------------
            'トランザクション開始--------------------------
            cdb.mBeginTrans()

            '*********************************
            '処理ストーリー
            '[1]既に対応済みかのチェックを行う(Reaction)
            '[2]既に対応中かどうかのチェックを行う
            '*********************************

            'ＤＢチェック-----------------------------------
            strSQL = New StringBuilder("")
            strSQL.Append("SELECT ")
            strSQL.Append(" NVL(ROC_FRG,'') AS ROC_FRG, ")                         'ロックフラグ
            strSQL.Append(" SYORI_SERIAL ")                     '処理番号
            strSQL.Append("FROM ")
            strSQL.Append("T10_KEIHO ")                         '警報ＤＢ
            strSQL.Append("WHERE SYORI_SERIAL =:SYORI_SERIAL ") '処理番号
            strSQL.Append("  AND REACTION = '0' ")              '処理状態(Oでない場合は既に対応入力登録ずみとなる)
            strSQL.Append(" FOR UPDATE ")                       '排他制御をかける

            'SQL文セット
            cdb.pSQL = strSQL.ToString
            'パラメータに値をセット
            cdb.pSQLParamStr("SYORI_SERIAL") = pstrSERIAL       '処理番号
            'SQL実行
            cdb.mExecQuery()
            ds = cdb.pResult

            'データが存在しない場合は対応入力済みデータとして｢1｣をRETURNする
            If (ds.Tables(0).Rows.Count = 0) Then
                strRes = "1"
                Exit Try
            End If

            'ロックフラグが立っている時はエラーとする為
            If (Convert.ToString(ds.Tables(0).Rows(0).Item("ROC_FRG")) <> "") Then
                strRes = "2"
                Exit Try
            End If

            '------------------------------------------------
            'ＤＢ更新（ロック設定）----------------------------
            strSQL = New StringBuilder("")
            strSQL.Append("")
            strSQL.Append("UPDATE ")
            strSQL.Append("T10_KEIHO ")
            strSQL.Append("SET ")
            strSQL.Append("ROC_FRG = :ROC_FRG, ")                       'ロックフラグ
            strSQL.Append("ROC_TIME= :ROC_TIME ")                      'ロック時間
            strSQL.Append("WHERE SYORI_SERIAL =:SYORI_SERIAL ")         '処理番号

            'SQL文セット
            cdb.pSQL = strSQL.ToString
            'パラメータセット
            cdb.pSQLParamStr("ROC_FRG") = "1"                           'ロックフラグ
            cdb.pSQLParamStr("ROC_TIME") = Now.ToString("HHmmss")       'ロック時間
            cdb.pSQLParamStr("SYORI_SERIAL") = pstrSERIAL               '処理番号
            'SQLを実行
            cdb.mExecNonQuery()

            'コミット
            cdb.mCommit()
        Catch ex As Exception
            'エラーが起きたら エラー内容を格納
            strRes = ex.ToString
            'ロールバック
            cdb.mRollback()
            strRes = strRes & cdb.pErr
        Finally
            '接続クローズ
            cdb.mClose()
        End Try

        cdb = Nothing
        mlog("[KEJUKJAW00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- mSet_Roc end pstrSERIAL=" & pstrSERIAL)

        Return strRes
    End Function

    '************************************************
    'ファイルＤＢの更新：欠損作成：過去情報削除
    'pintFLG → 0:(欠損データの作成なし)／1:(欠損データの作成あり)
    '************************************************
    <WebMethod()> Public Function mSet_Kesson( _
                                    ByVal pintFLG As Integer, _
                                    ByVal pstrFILE_NAME As String, _
                                    ByVal pstrUPPER_SERIAL As String _
                            ) As String
        Dim ds As New DataSet
        Dim cdb As New CDB
        Dim strRes As String
        Dim strSQL As StringBuilder

        Dim strZEN_FILE_NAME As String
        Dim strZEN_UPPER_SERIAL As String
        mlog("[KEJUKJAW00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- mSet_Kesson start  pintFLG=" & pintFLG.ToString & ",pstrFILE_NAME=" & pstrFILE_NAME & ",pstrUPPER_SERIAL=" & pstrUPPER_SERIAL)

        strRes = "OK"

        '------------------------------------------------
        '接続OPEN
        Try
            cdb.mOpen()
        Catch ex As Exception
            strRes = ex.ToString
            Return strRes
        Finally

        End Try

        Try
            '------------------------------------------------
            'トランザクション開始
            cdb.mBeginTrans()

            '------------------------------------------------
            'ＤＢ取得（正常分はテーブル内に１件のみ）
            strSQL = New StringBuilder("")
            strSQL.Append("SELECT  ")
            strSQL.Append(" RPAD(FILE_NAME,8,' ') AS FILE_NAME, ") 'ファイル名の文字列を合わせる為
            strSQL.Append(" UPPER_SERIAL ")
            strSQL.Append("FROM T11_KEIHOFILE ")
            strSQL.Append("WHERE FILE_STATUS = :FILE_STATUS ")
            'SQL文セット
            cdb.pSQL = strSQL.ToString
            'パラメータに値をセット
            cdb.pSQLParamStr("FILE_STATUS") = "0"
            'SQL実行
            cdb.mExecQuery()
            ds = cdb.pResult
            'データが存在しない場合は０年として計算
            If (ds.Tables(0).Rows.Count = 0) Then
                strZEN_FILE_NAME = "SE000000"
                strZEN_UPPER_SERIAL = "0"
            Else
                strZEN_FILE_NAME = Convert.ToString(ds.Tables(0).Rows(0).Item("FILE_NAME"))
                strZEN_UPPER_SERIAL = Convert.ToString(ds.Tables(0).Rows(0).Item("UPPER_SERIAL"))
            End If

            '------------------------------------------------
            '今回処理情報の登録
            If pstrUPPER_SERIAL.Length = 0 Then
                '遅れてきた警報の処理の為、現在登録されているファイル番号のデータを削除します
                'FILE_NAME = pstrFILE_NAME AND FILE_STATUS = 1(欠損)

                '過去に欠損として登録したデータを削除する
                strSQL = New StringBuilder("")
                strSQL.Append("")
                strSQL.Append("DELETE FROM ")
                strSQL.Append("T11_KEIHOFILE ")
                strSQL.Append("WHERE FILE_NAME = :FILE_NAME")
                strSQL.Append("  AND FILE_STATUS = :FILE_STATUS")
                'SQL文セット
                cdb.pSQL = strSQL.ToString
                'パラメータセット
                cdb.pSQLParamStr("FILE_NAME") = Trim(pstrFILE_NAME)
                cdb.pSQLParamStr("FILE_STATUS") = "1"       '欠損
                'SQLを実行
                cdb.mExecNonQuery()
            Else
                '現在ファイルステータスが0(正常)を削除し、
                '今回のファイル番号をファイルステータス0(正常)で登録する

                '前回の正常データを削除する (正常分全て削除)//////////////
                '今回警報がＤＢに存在する場合はそのデータも削除する
                strSQL = New StringBuilder("")
                strSQL.Append("")
                strSQL.Append("DELETE FROM ")
                strSQL.Append("T11_KEIHOFILE ")
                strSQL.Append("WHERE FILE_NAME = :FILE_NAME")
                strSQL.Append("   OR FILE_STATUS = :FILE_STATUS")
                'SQL文セット
                cdb.pSQL = strSQL.ToString
                'パラメータセット
                cdb.pSQLParamStr("FILE_NAME") = Trim(pstrFILE_NAME)
                cdb.pSQLParamStr("FILE_STATUS") = "0"       '正常
                'SQLを実行
                cdb.mExecNonQuery()

                '今回警報を正常として登録/////////////////////////////////
                strSQL = New StringBuilder("")
                strSQL.Append("")
                strSQL.Append("INSERT INTO T11_KEIHOFILE")
                strSQL.Append("( ")
                strSQL.Append("FILE_NAME, ")
                strSQL.Append("UPPER_SERIAL, ")
                strSQL.Append("FILE_STATUS, ")
                strSQL.Append("FILE_WAIT_MODE, ")
                strSQL.Append("LAST_MODIFIED ")
                strSQL.Append(") VALUES ( ")
                strSQL.Append(":FILE_NAME, ")
                strSQL.Append(":UPPER_SERIAL, ")
                strSQL.Append(":FILE_STATUS, ")
                strSQL.Append(":FILE_WAIT_MODE, ")
                strSQL.Append(":LAST_MODIFIED ")
                strSQL.Append(") ")
                'SQL文セット
                cdb.pSQL = strSQL.ToString
                'パラメータセット
                cdb.pSQLParamStr("FILE_NAME") = Trim(pstrFILE_NAME)
                cdb.pSQLParamStr("UPPER_SERIAL") = pstrUPPER_SERIAL
                cdb.pSQLParamStr("FILE_STATUS") = "0"
                cdb.pSQLParamStr("FILE_WAIT_MODE") = "0"
                cdb.pSQLParamStr("LAST_MODIFIED") = Now.ToString("yyyyMMdd") & Now.ToString("HHmmss")
                'SQLを実行
                cdb.mExecNonQuery()
            End If

            '------------------------------------------------
            '欠損データの作成
            'pintFLG → 0:(欠損データの作成なし)／1:(欠損データの作成あり)
            Dim i As Integer
            Dim intFILE_From As Integer
            Dim intFILE_To As Integer
            Dim intFILE_NAME As Integer
            Dim intZEN_FILE_NAME As Integer

            Dim strTEMP_FILE_NAME As String
            Dim strTEMP_UPPER_SERIAL As String

            If pintFLG = 1 Then
                intFILE_NAME = CInt(pstrFILE_NAME.Substring(2, 6))
                intZEN_FILE_NAME = CInt(strZEN_FILE_NAME.Substring(2, 6))
                If intFILE_NAME > intZEN_FILE_NAME Then
                    intFILE_From = intZEN_FILE_NAME + 1
                    intFILE_To = intFILE_NAME - 1
                Else
                    intFILE_From = intZEN_FILE_NAME + 1
                    intFILE_To = 1000000 + intFILE_NAME - 1
                End If
                For i = intFILE_From To intFILE_To
                    '処理を行うファイル名を取得
                    strTEMP_FILE_NAME = "SE" & Right("000000" & i, 6)
                    If i >= 1000000 Then
                        strTEMP_UPPER_SERIAL = CStr(CInt(strZEN_UPPER_SERIAL) + 1)
                    Else
                        strTEMP_UPPER_SERIAL = strZEN_UPPER_SERIAL
                    End If
                    '------------------------------------------------
                    'LOOPのファイル名データが存在した場合、そのデータを削除する
                    strSQL = New StringBuilder("")
                    strSQL.Append("SELECT  ")
                    strSQL.Append(" FILE_NAME ")
                    strSQL.Append("FROM T11_KEIHOFILE ")
                    strSQL.Append("WHERE FILE_NAME = :FILE_NAME ")
                    'SQL文セット
                    cdb.pSQL = strSQL.ToString
                    'パラメータに値をセット
                    cdb.pSQLParamStr("FILE_NAME") = strTEMP_FILE_NAME
                    'SQL実行
                    cdb.mExecQuery()
                    ds = cdb.pResult
                    'データ存在チェック
                    If (ds.Tables(0).Rows.Count = 0) Then
                        'データが存在しない場合は、何もしない

                    Else
                        'データが存在する時は削除する（欠損分の削除を行う）
                        strSQL = New StringBuilder("")
                        strSQL.Append("")
                        strSQL.Append("DELETE FROM ")
                        strSQL.Append("T11_KEIHOFILE ")
                        strSQL.Append("WHERE FILE_NAME = :FILE_NAME")
                        strSQL.Append("  AND FILE_STATUS = :FILE_STATUS")
                        'SQL文セット
                        cdb.pSQL = strSQL.ToString
                        'パラメータセット
                        cdb.pSQLParamStr("FILE_NAME") = strTEMP_FILE_NAME
                        cdb.pSQLParamStr("FILE_STATUS") = "1"       '欠損
                        'SQLを実行
                        cdb.mExecNonQuery()
                    End If

                    '欠損データの作成
                    strSQL = New StringBuilder("")
                    strSQL.Append("")
                    strSQL.Append("INSERT INTO T11_KEIHOFILE")
                    strSQL.Append("( ")
                    strSQL.Append("FILE_NAME, ")
                    strSQL.Append("UPPER_SERIAL, ")
                    strSQL.Append("FILE_STATUS, ")
                    strSQL.Append("FILE_WAIT_MODE, ")
                    strSQL.Append("LAST_MODIFIED ")
                    strSQL.Append(") VALUES ( ")
                    strSQL.Append(":FILE_NAME, ")
                    strSQL.Append(":UPPER_SERIAL, ")
                    strSQL.Append(":FILE_STATUS, ")
                    strSQL.Append(":FILE_WAIT_MODE, ")
                    strSQL.Append(":LAST_MODIFIED ")
                    strSQL.Append(") ")
                    'SQL文セット
                    cdb.pSQL = strSQL.ToString
                    'パラメータセット
                    cdb.pSQLParamStr("FILE_NAME") = strTEMP_FILE_NAME
                    cdb.pSQLParamStr("UPPER_SERIAL") = strTEMP_UPPER_SERIAL
                    cdb.pSQLParamStr("FILE_STATUS") = "1"       '欠損
                    cdb.pSQLParamStr("FILE_WAIT_MODE") = "0"
                    cdb.pSQLParamStr("LAST_MODIFIED") = Now.ToString("yyyyMMdd") & Now.ToString("HHmmss")
                    'SQLを実行
                    cdb.mExecNonQuery()
                Next
            End If

            'コミット
            cdb.mCommit()
        Catch ex As Exception
            'エラーが起きたら エラー内容を格納
            strRes = ex.ToString
            'ロールバック
            cdb.mRollback()
            strRes = strRes & cdb.pErr
        Finally
            '接続クローズ
            cdb.mClose()
        End Try

        cdb = Nothing
        mlog("[KEJUKJAW00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- mSet_Kesson end  pintFLG=" & pintFLG.ToString & ",pstrFILE_NAME=" & pstrFILE_NAME & ",pstrUPPER_SERIAL=" & pstrUPPER_SERIAL)
        Return strRes

    End Function

    '************************************************
    '指定された欠損データの削除を行う
    '************************************************
    <WebMethod()> Public Function mKesson_Del( _
                                        ByVal pintDelCnt As Integer, _
                                        ByVal pstrDelKeys As String) As String
        Dim ds As New DataSet
        Dim cdb As New CDB
        Dim strRes As String
        Dim strSQL As StringBuilder

        mlog("[KEJUKJAW00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- mKesson_Del start  pintDelCnt=" & pintDelCnt.ToString & ",pstrDelKeys=" & pstrDelKeys)
        strRes = "OK"

        '------------------------------------------------
        '接続OPEN
        Try
            cdb.mOpen()
        Catch ex As Exception
            strRes = ex.ToString
            Return strRes
        Finally

        End Try

        Try
            '------------------------------------------------
            'トランザクション開始
            cdb.mBeginTrans()

            '------------------------------------------------
            'カンマ編集を配列に編集
            Dim arrDelKey As String()
            arrDelKey = fncArrayOut(pstrDelKeys, pintDelCnt)

            '------------------------------------------------
            'ＤＢ更新
            strSQL = New StringBuilder("")
            strSQL.Append("")
            strSQL.Append("DELETE FROM ")
            strSQL.Append("T11_KEIHOFILE ")                         '警報ファイルＤＢ
            strSQL.Append("WHERE FILE_NAME =:FILE_NAME ")           '警報ファイル名

            'SQL文セット
            cdb.pSQL = strSQL.ToString

            Dim i As Integer
            For i = 0 To pintDelCnt - 1
                'パラメータセット
                cdb.pSQLParamStr("FILE_NAME") = arrDelKey(i)     '警報ファイル名
                'SQLを実行
                cdb.mExecNonQuery()
            Next

            'コミット
            cdb.mCommit()
        Catch ex As Exception
            'エラーが起きたら エラー内容を格納
            strRes = ex.ToString
            'ロールバック
            cdb.mRollback()
            strRes = strRes & cdb.pErr
        Finally
            '接続クローズ
            cdb.mClose()
        End Try

        cdb = Nothing
        mlog("[KEJUKJAW00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- mKesson_Del end  pintDelCnt=" & pintDelCnt.ToString & ",pstrDelKeys=" & pstrDelKeys)

        Return strRes
    End Function

    '******************************************************************************
    '*　概　要：配列として取得
    '*　備　考：Public Function
    '******************************************************************************
    Private Function fncArrayOut(ByVal pstrArrBox As String, ByVal pintArr As Integer) As String()
        Dim intLop As Integer
        Dim intIdx As Integer
        Dim strCut As String = ","
        Dim strTmp As String = ""
        Dim arrRec() As String
        ReDim arrRec(pintArr)
        mlog("[KEJUKJAW00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- fncArrayOut start  ")

        intIdx = 0
        For intLop = 1 To Len(pstrArrBox)
            If Len(pstrArrBox) = intLop Then
                If Mid(pstrArrBox, intLop, 1) <> strCut Then
                    strTmp = strTmp & Mid(pstrArrBox, intLop, 1)
                    arrRec(intIdx) = strTmp
                    strTmp = ""
                ElseIf Mid(pstrArrBox, intLop, 1) = strCut Then
                    arrRec(intIdx) = strTmp
                    strTmp = ""

                    intIdx += 1
                    arrRec(intIdx) = strTmp
                    strTmp = ""
                End If
            ElseIf Mid(pstrArrBox, intLop, 1) = strCut Then
                arrRec(intIdx) = strTmp
                intIdx += 1
                strTmp = ""
            Else
                strTmp = strTmp & Mid(pstrArrBox, intLop, 1)
            End If
        Next
        mlog("[KEJUKJAW00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- fncArrayOut end  ")

        Return arrRec
    End Function

    '************************************************
    ' 重複警報の処理済更新 2009/09/09 T.Watabe add
    '************************************************
    '2014/10/17 H.Hosoda mod 処理Noを引数として設定
    '<WebMethod()> Public Function mSet_DuplicateKeiho() As String
    <WebMethod()> Public Function mSet_DuplicateKeiho(ByVal pstrSYORI_SERIAL As String) As String

        Dim ds As New DataSet
        Dim cdb As New CDB
        Dim strRes As String
        Dim sql As StringBuilder

        mlog("[KEJUKJAW00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- mSet_DuplicateKeiho start  pstrSYORI_SERIAL=" & pstrSYORI_SERIAL)
        strRes = "OK"

        '------------------------------------------------
        '接続OPEN----------------------------------------
        Try
            cdb.mOpen()
        Catch ex As Exception
            strRes = ex.ToString
            Return strRes
        Finally

        End Try

        Try
            '------------------------------------------------
            'トランザクション開始--------------------------
            cdb.mBeginTrans()

            'ＤＢ更新----------------------------
            sql = New StringBuilder("")
            '/* 重複警報を探すSQL→ REACTIONを2:処理済(重複)とする */
            sql.Append("UPDATE T10_KEIHO ")
            sql.Append("SET REACTION = '2' ")
            sql.Append("WHERE SYORI_SERIAL IN ")
            sql.Append("    ( ")
            sql.Append("        SELECT  ")
            sql.Append("            A.SYORI_SERIAL ")
            'sql.append("            /* ,               */ ")
            'sql.append("            /* A.KANSCD,       */ ")
            'sql.append("            /* A.KURACD,       */ ")
            'sql.append("            /* A.ACBCD,        */ ")
            'sql.append("            /* A.JUYOKA,       */ ")
            'sql.append("            /* A.KMCD1,        */ ")
            'sql.append("            /* A.KMCD2,        */ ")
            'sql.append("            /* A.KMCD3,        */ ")
            'sql.append("            /* A.KMCD4,        */ ")
            'sql.append("            /* A.KMCD5,        */ ")
            'sql.append("            /* A.KMCD6,        */ ")
            'sql.append("            /* A.KMYMD,        */ ")
            'sql.append("            /* A.KMTIME,       */ ")
            'sql.append("            /* B.SYORI_SERIAL, */ ")
            'sql.append("            /* B.KMYMD,        */ ")
            'sql.append("            /* B.KMTIME        */ ")
            sql.Append("        FROM  ")
            sql.Append("            T10_KEIHO A, ") '/* 新しい未処理のデータ */
            sql.Append("            T10_KEIHO B ")  '/* Aより前のデータ */
            sql.Append("        WHERE  ")
            sql.Append("                A.REACTION = '0' ")
            sql.Append("            AND B.SYORI_SERIAL < A.SYORI_SERIAL ") '/* 同一レコードは除く、且つ、前の警報は残す */
            sql.Append("            AND B.KANSCD  = A.KANSCD ")
            sql.Append("            AND B.KURACD  = A.KURACD ")
            sql.Append("            AND B.ACBCD   = A.ACBCD ")
            sql.Append("            AND B.JUYOKA  = A.JUYOKA ")
            sql.Append("            AND NVL(B.KMCD1, 'NULL')   = NVL(A.KMCD1, 'NULL') ")
            sql.Append("            AND NVL(B.KMCD2, 'NULL')   = NVL(A.KMCD2, 'NULL') ")
            sql.Append("            AND NVL(B.KMCD3, 'NULL')   = NVL(A.KMCD3, 'NULL') ")
            sql.Append("            AND NVL(B.KMCD4, 'NULL')   = NVL(A.KMCD4, 'NULL') ")
            sql.Append("            AND NVL(B.KMCD5, 'NULL')   = NVL(A.KMCD5, 'NULL') ")
            sql.Append("            AND NVL(B.KMCD6, 'NULL')   = NVL(A.KMCD6, 'NULL') ")
            sql.Append("            AND NVL(B.KMNM1, 'NULL')   = NVL(A.KMNM1, 'NULL') ") '2009/11/04 T.Watabe add 6lines 名称も比較対象とする
            sql.Append("            AND NVL(B.KMNM2, 'NULL')   = NVL(A.KMNM2, 'NULL') ")
            sql.Append("            AND NVL(B.KMNM3, 'NULL')   = NVL(A.KMNM3, 'NULL') ")
            sql.Append("            AND NVL(B.KMNM4, 'NULL')   = NVL(A.KMNM4, 'NULL') ")
            sql.Append("            AND NVL(B.KMNM5, 'NULL')   = NVL(A.KMNM5, 'NULL') ")
            sql.Append("            AND NVL(B.KMNM6, 'NULL')   = NVL(A.KMNM6, 'NULL') ")
            'sql.Append("            AND TO_DATE(B.KMYMD || B.KMTIME, 'YYYYMMDDHH24MI') >= TO_DATE(A.KMYMD || A.KMTIME, 'YYYYMMDDHH24MI') - 2/(24*60) /* 2分差以内 */ ") '2009/09/30 T.Watabe edit 熊本の重複データはNCU発生日時刻が同一なので、そちらに変更 
            '2014/10/27 H.Hosoda mod 2014改善開発 No1 START
            '以下の警報を除外対象とする
            ' <NCU発生日>がシステム日付と比較し10日以内であること
            ' A:人為的に警報情報を連続して発生させてしまった場合の2回目以降の警報（NCU発生日時は近いが同じではない）→直近警報と比較して2分以内
            ' B:リトライなどによって上がってくる同一警報の2回目以降の警報（NCU発生日時が同一）
            'sql.Append("            AND B.NCUHATYMD || B.NCUHATTIME = A.NCUHATYMD || A.NCUHATTIME /* NCU発生日時刻が同じもの */ ")
            'sql.Append("            AND A.SYORI_SERIAL > (SELECT (MAX(SYORI_SERIAL)-50) FROM T10_KEIHO WHERE SYORI_SERIAL < '900000') AND A.SYORI_SERIAL < '900000' ") '2009/11/30 T.Watabe add 2lines 対象をシリアルで絞り込む（直近５０件）
            'sql.Append("            AND B.SYORI_SERIAL > (SELECT (MAX(SYORI_SERIAL)-50) FROM T10_KEIHO WHERE SYORI_SERIAL < '900000') AND B.SYORI_SERIAL < '900000' ")
            sql.Append("            AND TO_DATE(B.NCUHATYMD || B.NCUHATTIME, 'YYYYMMDDHH24MI') >= TO_DATE(A.NCUHATYMD || A.NCUHATTIME, 'YYYYMMDDHH24MI') - 2/(24*60) /* 2分差以内 */ ")
            '2014/11/26 H.Hosoda mod 2014改善開発 No1 START
            sql.Append("            AND TO_DATE(B.NCUHATYMD || B.NCUHATTIME, 'YYYYMMDDHH24MI') <= TO_DATE(A.NCUHATYMD || A.NCUHATTIME, 'YYYYMMDDHH24MI')")
            '2014/11/26 H.Hosoda mod 2014改善開発 No1 END
            sql.Append("            AND TRUNC(SYSDATE) - TO_DATE(A.NCUHATYMD) <= 10 ") '発生日が10日以内
            '2014/10/27 H.Hosoda mod 2014改善開発 No1 END
            '2014/10/17 H.Hosoda add 1Line 引数で渡された処理No以下のデータを対象とする
            sql.Append("            AND TO_NUMBER(A.SYORI_SERIAL) <= " & pstrSYORI_SERIAL)
            '2014/10/27 H.Hosoda add 2014改善開発 No1 START
            sql.Append("        GROUP BY A.SYORI_SERIAL ")
            '2014/10/27 H.Hosoda add 2014改善開発 No1 END
            sql.Append("    ) ")

            'SQL文セット
            cdb.pSQL = sql.ToString
            'SQLを実行
            cdb.mExecNonQuery()

            'コミット
            cdb.mCommit()
        Catch ex As Exception
            'エラーが起きたら エラー内容を格納
            strRes = ex.ToString
            'ロールバック
            cdb.mRollback()
            strRes = strRes & cdb.pErr
        Finally
            '接続クローズ
            cdb.mClose()
        End Try

        cdb = Nothing

        mlog("[KEJUKJAW00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- mSet_DuplicateKeiho end  pstrSYORI_SERIAL=" & pstrSYORI_SERIAL)
        Return strRes
    End Function

    '************************************************
    ' 指定警報の自動対応処理 2011/12/01 H.Uema ADD
    '************************************************
    Public Const PROCKBN_AUTO As String = "1" '対応・無視区分（自動対応）
    Public Const PROCKBN_OUT1 As String = "2" '対応・無視区分（無視）
    Public Const PROCKBN_OUT2 As String = "3" '対応・無視区分（無視：集中監視確認）
    Public Const KM_ZAN1 As String = "29" '警告：残量警告１
    Public Const KM_ZAN2 As String = "28" '警告：残量警告２
    Public Const KM_ZAN3 As String = "27" '警告：残量警告３

    '2014/10/17 H.Hosoda mod 処理Noを引数として設定
    '<WebMethod()> Public Function mSet_AutoTaiou() As String
    <WebMethod()> Public Function mSet_AutoTaiou(ByVal pstrSYORI_SERIAL As String) As String

        mlog("[KEJUKJAW00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- mSet_AutoTaiou start  pstrSYORI_SERIAL=" & pstrSYORI_SERIAL)
        Dim ds As New DataSet
        Dim dsAuto As DataSet
        Dim dsTaiou As DataSet
        Dim dsSec As DataSet
        Dim cdb As New CDB
        Dim strRes As String
        Dim sql As StringBuilder
        Dim taiouWS As New KETAIJAW00.KETAIJAW00

        Dim dto As KEJUKJAW00DTO.D20TaiouDto

        Dim kmdto As KEJUKJAW00DTO.KmDto
        Dim kmList As ArrayList
        Dim autoTaiouList As KEJUKJAW00DTO.AutoTaiouLists
        Dim autoTaiou As KEJUKJAW00DTO.AutoTaiouDto

        Dim TanMSKBN As String = "0"  ' 0:M05_TANTO2登録なし 1:お客様CD1つでの登録 2:お客様CD範囲での登録  2013/07/03 T.Ono add

        strRes = "OK"

        '------------------------------------------------
        '接続OPEN----------------------------------------
        Try
            cdb.mOpen()
        Catch ex As Exception
            strRes = ex.ToString
            Return strRes
        Finally
        End Try

        Try
            '------------------------------------------------
            'トランザクション開始--------------------------
            cdb.mBeginTrans()

            '*-----------------------------------------------------*
            ' 1.受信警報データの取得
            '*-----------------------------------------------------*
            '2014/10/17 H.Hosoda mod 処理Noを引数として設定
            'cdb.pSQL = getSqlExistsAutoTaiou()
            cdb.pSQL = getSqlExistsAutoTaiou(pstrSYORI_SERIAL)

            cdb.mExecQuery()
            ds = cdb.pResult
            'データが存在しない場合、終了
            If (ds.Tables(0).Rows.Count = 0) Then
                Exit Try
            End If
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1

                '*-----------------------------------------------------*
                ' 警報メッセージリスト作成
                '*-----------------------------------------------------*
                kmList = New ArrayList
                For intLoop As Integer = 1 To 6
                    '警報メッセージ数算出処理
                    If Convert.ToString(ds.Tables(0).Rows(i).Item("KMCD" & intLoop)) <> "" Then
                        '値が入っていれば警報メッセージをリストにセット
                        kmdto = New KEJUKJAW00DTO.KmDto( _
                                        Convert.ToString(ds.Tables(0).Rows(i).Item("KMCD" & intLoop)) _
                                        , Convert.ToString(ds.Tables(0).Rows(i).Item("KMNM" & intLoop)))
                        kmList.Add(kmdto)
                    End If
                Next

                '*-----------------------------------------------------*
                ' 2.自動対応内容リスト作成
                '*-----------------------------------------------------*
                cdb.pSQL = getSqlAutoTaiouList(Convert.ToString(ds.Tables(0).Rows(i).Item("SYORI_SERIAL")))
                cdb.mExecQuery()
                dsAuto = New DataSet
                dsAuto = cdb.pResult

                'データが存在しない場合、次のレコードへ
                If (dsAuto.Tables(0).Rows.Count = 0) Then
                    GoTo [Continue]
                End If

                autoTaiouList = New KEJUKJAW00DTO.AutoTaiouLists(dsAuto.Tables(0))

                For Each atDto As KEJUKJAW00DTO.AutoTaiouDto In CType(autoTaiouList.procListByIgnore, ArrayList)
                    If PROCKBN_OUT1.Equals(atDto.prockbn) And isExists(kmList, CType(atDto.pkmDto, KEJUKJAW00DTO.KmDto)) > -1 Then
                        '*-----------------------------------------------------*
                        ' 3.自動対応内容.対応・無視区分="2"は、警報メッセージリストから削除
                        '*-----------------------------------------------------*
                        kmList.RemoveAt(isExists(kmList, CType(atDto.pkmDto, KEJUKJAW00DTO.KmDto)))
                    ElseIf PROCKBN_OUT2.Equals(atDto.prockbn) Then
                        ''*-----------------------------------------------------*
                        '' 4.対応・無視区分が"3"無視に設定されている場合は、セキュリティ情報テーブルを確認
                        ''*-----------------------------------------------------*
                        If isExists(kmList, CType(atDto.pkmDto, KEJUKJAW00DTO.KmDto)) > -1 Then
                            '*-----------------------------------------------------*
                            ' 4-1.セキュリティ情報テーブルを参照する
                            '     条件：クライアントコード, JA支所コード, 顧客コード
                            '*-----------------------------------------------------*
                            Dim seqSql As New StringBuilder
                            Dim bExex As Boolean = getSqlSecurityInfo(seqSql, ds.Tables(0).Rows(i), Convert.ToString(CType(atDto.pkmDto, KEJUKJAW00DTO.KmDto).KmCd))

                            If bExex Then
                                cdb.pSQL = seqSql.ToString
                                cdb.mExecQuery()
                                dsSec = New DataSet
                                dsSec = cdb.pResult
                            Else
                                GoTo [Continue]
                            End If
                            '*-----------------------------------------------------*
                            ' 4-2.取得できない場合、自動対応は行わない
                            '*-----------------------------------------------------*
                            If (dsSec.Tables(0).Rows.Count = 0) Then
                                GoTo [Continue]
                            End If

                            '*-----------------------------------------------------*
                            ' 4-3.出力有無フラグが出力ありの場合、自動対応は行わない
                            '*-----------------------------------------------------*
                            For intSec As Integer = 0 To dsSec.Tables(0).Rows.Count - 1
                                If "1".Equals(Convert.ToString(dsSec.Tables(0).Rows(0).Item("OUT_FLG"))) Then
                                    GoTo [Continue]
                                End If
                            Next
                            kmList.RemoveAt(isExists(kmList, CType(atDto.pkmDto, KEJUKJAW00DTO.KmDto)))
                        End If
                    End If
                Next

                '*-----------------------------------------------------*
                ' 5.リストアップした警報コードから除外した結果、データが
                '   存在していない場合は、警報パネルへ出力する
                '*-----------------------------------------------------*
                If kmList.Count <> 1 Then
                    GoTo [Continue]
                End If

                '*-----------------------------------------------------*
                ' 6.リストアップした警報コードと警報名称を元に、
                '   自動対応内容テーブルから自動対応を行うデータを抽出する。
                '*-----------------------------------------------------*
                For Each atDto As KEJUKJAW00DTO.AutoTaiouDto In CType(autoTaiouList.procListByAuto, ArrayList)

                    If CType(kmList(0), KEJUKJAW00DTO.KmDto).isEquals _
                                                                (CType(atDto.pkmDto, KEJUKJAW00DTO.KmDto)) Then
                        autoTaiou = New KEJUKJAW00DTO.AutoTaiouDto
                        autoTaiou = atDto
                        Exit For
                    End If
                Next

                If autoTaiou Is Nothing Then
                    GoTo [Continue]
                End If

                '*-----------------------------------------------------*
                ' 7.自動対応処理を行う。
                '*-----------------------------------------------------*
                '登録情報取得

                ' 2013/08/07 T.Ono add FAXKBN,FAXKURAKBN取得
                Dim strPar(1) As String 'FAXKBN,FAXKURAKBN格納用
                strPar = fncGetFAXKBN(cdb, Convert.ToString(ds.Tables(0).Rows(i).Item("SYORI_SERIAL")))

                'SQL文セット
                ' 2013/08/07 T.Ono mod
                'cdb.pSQL = getAutoKeiho(Convert.ToString(ds.Tables(0).Rows(i).Item("SYORI_SERIAL")))
                cdb.pSQL = getAutoKeiho(Convert.ToString(ds.Tables(0).Rows(i).Item("SYORI_SERIAL")), strPar)
                cdb.mExecQuery()
                dsTaiou = New DataSet
                dsTaiou = cdb.pResult
                'データが存在しない場合、終了
                If (dsTaiou.Tables(0).Rows.Count = 0) Then
                    GoTo [Continue]
                End If

                '取得データの編集
                dto = New KEJUKJAW00DTO.D20TaiouDto
                editTaiouData(dsTaiou.Tables(0).Rows(0), cdb, dto, autoTaiou)
                If dto Is Nothing Then
                    GoTo [Continue]
                End If

                '2012/06/28 ADD W.GANEKO
                '8時間内に同一警報があった場合、重複にする。
                If (dto.BackUrl = "KEJUKJAG00") Then
                    If (getSqlDupTaiou(cdb, dto.KANSCD, _
                                       dto.KMCD1, _
                                       dto.KMNM1, _
                                       dto.KMCD2, _
                                       dto.KMNM2, _
                                       dto.KMCD3, _
                                       dto.KMNM3, _
                                       dto.KMCD4, _
                                       dto.KMNM4, _
                                       dto.KMCD5, _
                                       dto.KMNM5, _
                                       dto.KMCD6, _
                                       dto.KMNM6, _
                                       dto.KURACD, _
                                       dto.JACD, _
                                       dto.ACBCD, _
                                       dto.USER_CD, _
                                       dto.HATYMD, _
                                       dto.HATTIME _
                                       )) Then
                        dto.TAIOKBN = "3"
                        dto.FAXKBN = "1"
                        dto.FAXKURAKBN = "1"
                        dto.FAXRUISEKIKBN = "1" '2015/11/25 H.Mori add 2015改善開発 No1
                    End If
                    '自動対応中の警報があるかチェック
                    If (getKeihoDupTaiou(cdb, _
                                       dto.MoveSerial _
                                           )) Then
                        '自動対応中があった場合は次のレコードを読む
                        GoTo [Continue]
                    Else
                        '自動対応中にする
                        If (mSet_AutoFlg(dto.MoveSerial) <> "OK") Then
                            '自動対応中にできない場合は次のレコードを読む
                            GoTo [Continue]
                        End If
                    End If
                End If

                '対応入力TBL登録及び警報TBL更新処理呼び出し
                '2012/06/25 W.GANEKO パラメータの最後を追加 "1":自動対応
                '2013/05/27 T.Ono 顧客単位登録機能追加　項目追加
                '2013/08/23 T.Ono add 監視改善��1　本日工事状況
                '2014/12/19 T.Ono edit 販売事業者コード・名称追加 2014改善開発 No2
                '2015/11/19 H.Mori add 報告不要（累積）2015改善開発 No1
                '2015/11/25 H.Mori add 販売区分 2015改善開発 No1
                '2016/02/02 W.GANEKO add 2015改善開発 No1-3 監視備考、連絡先2、連絡先3追加
                '2016/12/14 H.Mori mod NCU接続、供給形態区分、ｽﾎﾟｯﾄFAX区分、電話番号(TELAB)、第3連動連絡先、法人代表者氏名、適用法令区分、用途区分、販売書コード、緊急連絡先CD 2016改善開発 No4-6
                '2017/10/16 H.Mori mod 集合区分 2017改善開発 No4-1
                '2020/01/19 T.Ono mod 2020監視改善 TEL_MEMO4〜6追加
                ' 2023/01/04 ADD Y.ARAKAKI 2022更改No�E _帳票JMコード表示追加対応 自動対応データ登録でもJM和名を登録できるよう修正（共通処理だった為併せて修正）
                strRes = taiouWS.mSet_Taiou2(dto.BackUrl,
                                    dto.MoveSerial,
                                    dto.KBN,
                                    dto.KANSCD,
                                    dto.SYONO,
                                    dto.NCUHATYMD,
                                    dto.NCUHATTIME,
                                    dto.HATYMD,
                                    dto.HATTIME,
                                    dto.KENSIN,
                                    dto.KEIHOSU,
                                    dto.RYURYO,
                                    dto.METASYU,
                                    dto.UNYO,
                                    dto.JUYMD,
                                    dto.JUTIME,
                                    dto.NUM_DIGIT,
                                    dto.KMCD1,
                                    dto.KMNM1,
                                    dto.KMCD2,
                                    dto.KMNM2,
                                    dto.KMCD3,
                                    dto.KMNM3,
                                    dto.KMCD4,
                                    dto.KMNM4,
                                    dto.KMCD5,
                                    dto.KMNM5,
                                    dto.KMCD6,
                                    dto.KMNM6,
                                    dto.KURACD,
                                    dto.KENNM,
                                    dto.JACD,
                                    dto.JANM,
                                    dto.HANJICD,
                                    dto.HANJINM,
                                    dto.ACBCD,
                                    dto.ACBNM,
                                    dto.USER_CD,
                                    dto.JUSYONM,
                                    dto.JUSYOKN,
                                    dto.JUTEL1,
                                    dto.JUTEL2,
                                    dto.RENTEL,
                                    dto.KTELNO,
                                    dto.ADDR,
                                    dto.NCU_SET,
                                    dto.TIZUNO,
                                    dto.HANBAI_KBN,
                                    dto.KYOKTKBN,
                                    dto.MET_KATA,
                                    dto.MET_MAKER,
                                    dto.BONB1_KKG,
                                    dto.BONB1_HON,
                                    dto.BONB1_YOBI,
                                    dto.BONB2_KKG,
                                    dto.BONB2_HON,
                                    dto.BONB2_YOBI,
                                    dto.BONB3_KKG,
                                    dto.BONB3_HON,
                                    dto.BONB3_YOBI,
                                    dto.BONB4_KKG,
                                    dto.BONB4_HON,
                                    dto.BONB4_YOBI,
                                    dto.ZENKAI_HAISO,
                                    dto.ZENKAI_HAI_S,
                                    dto.KONKAI_HAISO,
                                    dto.KONKAI_HAI_S,
                                    dto.JIKAI_HAISO,
                                    dto.ZENKAI_KENSIN,
                                    dto.ZENKAI_KEN_S,
                                    dto.ZENKAI_KEN_SIYO,
                                    dto.KONKAI_KENSIN,
                                    dto.KONKAI_KEN_S,
                                    dto.KONKAI_KEN_SIYO,
                                    dto.ZENKAI_HASEI,
                                    dto.ZENKAI_HAS_S,
                                    dto.KONKAI_HASEI,
                                    dto.KONKAI_HAS_S,
                                    dto.G_ZAIKO,
                                    dto.ICHI_SIYO,
                                    dto.YOSOKU_ICHI_SIYO,
                                    dto.GAS1_HINMEI,
                                    dto.GAS1_DAISU,
                                    dto.GAS1_SEIFL,
                                    dto.GAS2_HINMEI,
                                    dto.GAS2_DAISU,
                                    dto.GAS2_SEIFL,
                                    dto.GAS3_HINMEI,
                                    dto.GAS3_DAISU,
                                    dto.GAS3_SEIFL,
                                    dto.GAS4_HINMEI,
                                    dto.GAS4_DAISU,
                                    dto.GAS4_SEIFL,
                                    dto.GAS5_HINMEI,
                                    dto.GAS5_DAISU,
                                    dto.GAS5_SEIFL,
                                    dto.HATKBN,
                                    dto.TAIOKBN,
                                    dto.TMSKB,
                                    dto.TKTANCD,
                                    dto.TAITCD,
                                    dto.TAIO_ST_DATE,
                                    dto.TAIO_ST_TIME,
                                    dto.SYOYMD,
                                    dto.SYOTIME,
                                    dto.TAIO_SYO_TIME,
                                    dto.FAXKBN,
                                    dto.FAXKURAKBN,
                                    dto.FAXRUISEKIKBN,
                                    dto.TELRCD,
                                    dto.TFKICD,
                                    dto.FUK_MEMO,
                                    dto.TEL_MEMO1,
                                    dto.TEL_MEMO2,
                                    dto.TEL_MEMO4,
                                    dto.TEL_MEMO5,
                                    dto.TEL_MEMO6,
                                    dto.MITOKBN,
                                    dto.TKIGCD,
                                    dto.TSADCD,
                                    dto.GENIN_KIJI,
                                    dto.SDCD,
                                    dto.SIJIYMD,
                                    dto.SIJITIME,
                                    dto.SIJI_BIKO1,
                                    dto.SIJI_BIKO2,
                                    dto.STD_JASCD,
                                    dto.STD_JANA,
                                    dto.STD_JASNA,
                                    dto.REN_CODE,
                                    dto.REN_NA,
                                    dto.REN_TEL_1,
                                    dto.REN_TEL_2,
                                    dto.REN_TEL_3,
                                    dto.REN_FAX,
                                    dto.REN_BIKO,
                                    dto.REN_EDT_DATE,
                                    dto.REN_TIME,
                                    dto.REN_1_CODE,
                                    dto.REN_1_NA,
                                    dto.REN_1_TEL1,
                                    dto.REN_1_TEL2,
                                    dto.REN_1_TEL3,
                                    dto.REN_1_FAX,
                                    dto.REN_1_BIKO,
                                    dto.REN_1_EDT_DATE,
                                    dto.REN_1_TIME,
                                    dto.REN_2_CODE,
                                    dto.REN_2_NA,
                                    dto.REN_2_TEL1,
                                    dto.REN_2_TEL2,
                                    dto.REN_2_TEL3,
                                    dto.REN_2_FAX,
                                    dto.REN_2_BIKO,
                                    dto.REN_2_EDT_DATE,
                                    dto.REN_2_TIME,
                                    dto.REN_3_CODE,
                                    dto.REN_3_NA,
                                    dto.REN_3_TEL1,
                                    dto.REN_3_TEL2,
                                    dto.REN_3_TEL3,
                                    dto.REN_3_FAX,
                                    dto.REN_3_BIKO,
                                    dto.REN_3_EDT_DATE,
                                    dto.REN_3_TIME,
                                    dto.REN_DENWABIKO,
                                    dto.REN_FAXTITLE,
                                    dto.REN_FAX_REN,
                                    dto.STD_CD,
                                    dto.STD,
                                    dto.STD_KYOTEN_CD,
                                    dto.STD_KYOTEN,
                                    dto.STD_TEL,
                                    dto.ADD_DATE,
                                    dto.EDT_DATE,
                                    dto.TIME,
                                    dto.BOMB_TYPE,
                                    dto.GAS_STOP,
                                    dto.GAS_DELE,
                                    dto.GAS_RESTART,
                                    dto.KAITU_DAY,
                                    dto.BIKOU,
                                    dto.FAX_TITLE_CD,
                                    dto.DialKbns,
                                    dto.DialNumbers,
                                    dto.DialAites,
                                    dto.DialResult,
                                    dto.DialDates,
                                    dto.DialTimes,
                                    dto.DialStates,
                                    dto.SDSKBN,
                                    "1",
                                    dto.KANSHI_BIKO,
                                    dto.RENTEL2,
                                    dto.RENTEL2_BIKO,
                                    dto.RENTEL2_UPD_DATE,
                                    dto.RENTEL3,
                                    dto.RENTEL3_BIKO,
                                    dto.RENTEL3_UPD_DATE,
                                    dto.TUSIN,
                                    dto.FAXSPOTKBN,
                                    dto.TELAB,
                                    dto.DAI3RENDORENTEL,
                                    dto.DAIHYO_NAME,
                                    dto.HOKBN,
                                    dto.YOTOKBN,
                                    dto.HANBCD,
                                    dto.KINRENCD,
                                    dto.SHUGOU,
                                    dto.JMNAME
                                    )

[Continue]:
                '初期化
                dsAuto = Nothing
                dsSec = Nothing
                dsTaiou = Nothing
                dto = Nothing
                kmList = Nothing
                autoTaiouList = Nothing
                autoTaiou = Nothing
            Next
        Catch ex As Exception
            'エラーが起きたら エラー内容を格納
            strRes = ex.ToString
            'ロールバック
            cdb.mRollback()
            strRes = strRes & cdb.pErr
        Finally
            '接続クローズ
            cdb.mClose()
            cdb = Nothing
        End Try
        mlog("[KEJUKJAW00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- mSet_AutoTaiou end  pstrSYORI_SERIAL=" & pstrSYORI_SERIAL)

        Return strRes
    End Function

    Private Function isExists(ByVal list As ArrayList, ByVal kmDto As KEJUKJAW00DTO.KmDto) As Integer
        Dim i As Integer = 0
        For Each dto As KEJUKJAW00DTO.KmDto In list
            If dto.isEquals(kmDto) Then
                Return i
            End If
            i = i + 1
        Next
        Return -1
    End Function

    '************************************************
    ' 自動対応を行う対象のデータを抽出SQL
    '************************************************
    ' 2013/08/07 T.Ono mod
    'Private Function getAutoKeiho(ByVal pstrSyoriNo As String) As String
    Private Function getAutoKeiho(ByVal pstrSyoriNo As String, ByVal strPar() As String) As String
        Dim strSQL As StringBuilder = New StringBuilder
        mlog("[KEJUKJAW00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- getAutoKeiho start  pstrSyoriNo=" & pstrSyoriNo)
        '+----------------------------------------------------+
        '|自動対応を行う対象のデータを抽出するSQLを構築
        '+----------------------------------------------------+
        ' ※抽出項目は、警報パネルから対応入力へ遷移時に発行される
        ' 　検索SQLの項目と対応入力TBLに登録する必要な項目
        strSQL.Append("SELECT  ")
        '<<受信情報>>
        strSQL.Append("KEI.SYORI_SERIAL, ")
        strSQL.Append("KEI.FILE_NAME, ")
        strSQL.Append("KEI.REACTION, ")
        strSQL.Append("KEI.IS_PRINTED, ")
        strSQL.Append("KEI.SYONO, ")
        strSQL.Append("KEI.SAYMD AS JUYMD, ")
        strSQL.Append("KEI.SUYMD, ")
        strSQL.Append("KEI.STIME AS JUTIME, ")
        strSQL.Append("KEI.MES_TYPE, ")
        strSQL.Append("KEI.REPLY_CODE, ")
        strSQL.Append("KEI.MEDIA_TYPE, ")
        strSQL.Append("KEI.KANSCD, ")
        strSQL.Append("KEI.KURACD AS CLI_CD, ")
        strSQL.Append("KEI.ACBCD, ")
        strSQL.Append("KEI.JUYOKA, ")
        strSQL.Append("KEI.JUYOKA AS JUYOKA_CD, ")
        strSQL.Append("KEI.INFO_1, ")
        strSQL.Append("KEI.INFO_2, ")
        strSQL.Append("SUBSTR(KEI.INFO_2,3,1) AS RYURYO, ")
        strSQL.Append("KEI.SECURITY_2, ")
        strSQL.Append("KEI.KMYMD, ")
        strSQL.Append("KEI.KMTIME, ")
        strSQL.Append("KEI.JUYONM, ")
        'strSQL.Append("RTRIM(KEI.ADDR || ' ' || KOK.ADD_3) AS ADDR, ")
        strSQL.Append("KOK.ADD_1 || ' ' || KOK.ADD_2 || ' ' || KOK.ADD_3 AS ADDR, ") '2017/10/17 H.Mori mod 2017改善開発 No4-2
        strSQL.Append("KEI.KMSIN, ")
        strSQL.Append("KEI.NUM_DIGIT, ")
        strSQL.Append("KEI.KMCD1, ")
        strSQL.Append("KEI.KMNM1, ")
        strSQL.Append("KEI.KMCD2, ")
        strSQL.Append("KEI.KMNM2, ")
        strSQL.Append("KEI.KMCD3, ")
        strSQL.Append("KEI.KMNM3, ")
        strSQL.Append("KEI.KMCD4, ")
        strSQL.Append("KEI.KMNM4, ")
        strSQL.Append("KEI.KMCD5, ")
        strSQL.Append("KEI.KMNM5, ")
        strSQL.Append("KEI.KMCD6, ")
        strSQL.Append("KEI.KMNM6, ")
        strSQL.Append("KEI.META_SYUBETU, ")
        strSQL.Append("KEI.KENSIN_MODE, ")
        strSQL.Append("KEI.OKYAKU_FLG AS UNYOCD, ")
        strSQL.Append("KEI.ROC_FRG, ")
        strSQL.Append("KEI.ROC_TIME, ")
        strSQL.Append("KEI.ROC_USER, ") '2017/10/11 H.Mori add 2017改善開発 No1
        strSQL.Append("KEI.BIKOU, ")
        strSQL.Append("KOK.NAME, ")
        strSQL.Append("KOK.KANA, ")
        strSQL.Append("KOK.NCU_TELA AS JUTEL1, ")           '顧客：ＮＣＵ電話番号市外
        strSQL.Append("KOK.NCU_TELB AS JUTEL2, ")           '顧客：ＮＣＵ電話番号市内
        strSQL.Append("KEI.JUTEL AS RENTEL, ")              '警報：電話番号
        strSQL.Append("KOK.KANKENSAKU_TEL AS KTELNO, ")     '顧客：検索用電話番号
        strSQL.Append("KOK.USR_MEMO, ")
        strSQL.Append("KOK.USR_MEMO AS GENIN_KIJI, ")
        '<<お客様情報>>
        strSQL.Append("KOK.NCU_CON, ")
        strSQL.Append("KOK.SETSUBI, ")
        strSQL.Append("KOK.KYOKYU_MK, ")
        strSQL.Append("KOK.MAP_CD, ")
        strSQL.Append("KOK.BOMB_TYPE, ")
        strSQL.Append("KOK.BOMB_YOUKI1, ")
        strSQL.Append("KOK.BOMB_SUU1, ")
        strSQL.Append("KOK.YOBI_FLG1 AS BOMB_RYO1, ")
        strSQL.Append("KOK.BOMB_YOUKI2, ")
        strSQL.Append("KOK.BOMB_SUU2, ")
        strSQL.Append("KOK.YOBI_FLG2 AS BOMB_RYO2, ")
        strSQL.Append("KOK.BOMB_YOUKI3, ")
        strSQL.Append("KOK.BOMB_SUU3, ")
        strSQL.Append("KOK.YOBI_FLG3 AS BOMB_RYO3, ")
        strSQL.Append("KOK.BOMB_YOUKI4, ")
        strSQL.Append("KOK.BOMB_SUU4, ")
        strSQL.Append("KOK.YOBI_FLG4 AS BOMB_RYO4, ")
        strSQL.Append("KOK.SIYOU3, ")
        strSQL.Append("KOK.SIYOU4, ")
        strSQL.Append("KOK.BOMV_HAISO1, ")
        strSQL.Append("KOK.BOMV_SISIN1, ")
        strSQL.Append("KOK.BOMV_HAISO2, ")
        strSQL.Append("KOK.BOMV_SISIN2, ")
        strSQL.Append("KOK.HAISO_YOTEI, ")
        strSQL.Append("KOK.BOMB_DATE1, ")
        strSQL.Append("KOK.BOMB_SISIN1, ")
        strSQL.Append("KOK.BOMB_DATE2, ")
        strSQL.Append("KOK.BOMB_SISIN2, ")
        strSQL.Append("KOK.KENSIN_DAY1, ")
        strSQL.Append("KOK.KENSINTI1, ")
        strSQL.Append("KOK.KENSIN_DAY2, ")
        strSQL.Append("KOK.KENSINTI2, ")
        strSQL.Append("KOK.SIYOU1, ")
        strSQL.Append("KOK.SIYOU2, ")
        strSQL.Append("KOK.GAS_NAME1, ")
        strSQL.Append("KOK.GAS_NAME2, ")
        strSQL.Append("KOK.GAS_NAME3, ")
        strSQL.Append("KOK.GAS_NAME4, ")
        strSQL.Append("KOK.GAS_NAME5, ")
        strSQL.Append("KOK.GAS_SUU1, ")
        strSQL.Append("KOK.GAS_SUU2, ")
        strSQL.Append("KOK.GAS_SUU3, ")
        strSQL.Append("KOK.GAS_SUU4, ")
        strSQL.Append("KOK.GAS_SUU5, ")
        strSQL.Append("KOK.GAS_SEIF1, ")
        strSQL.Append("KOK.GAS_SEIF2, ")
        strSQL.Append("KOK.GAS_SEIF3, ")
        strSQL.Append("KOK.GAS_SEIF4, ")
        strSQL.Append("KOK.GAS_SEIF5, ")
        strSQL.Append("KOK.GAS_STOP AS GAS_START, ")
        strSQL.Append("KOK.GAS_DELE, ")
        strSQL.Append("KOK.GAS_RESTART, ")
        strSQL.Append("KOK.HANBAI_KBN, ") ' 2015/12/18 H.Mori add
        strSQL.Append("KOK.KYOKTKBN, ")   ' 2016/12/26 H.Mori add 2016監視改善 No4-6
        strSQL.Append("KOK.KANSHI_BIKO, ")       ' 2016/02/02 W.GANEKO 2015監視改善 ��1-3
        strSQL.Append("KOK.RENTEL2, ")           ' 2016/02/02 W.GANEKO 2015監視改善 ��1-3
        strSQL.Append("KOK.RENTEL2_BIKO, ")      ' 2016/02/02 W.GANEKO 2015監視改善 ��1-3
        strSQL.Append("KOK.RENTEL2_UPD_DATE, ")  ' 2016/02/02 W.GANEKO 2015監視改善 ��1-3
        strSQL.Append("KOK.RENTEL3, ")           ' 2016/02/02 W.GANEKO 2015監視改善 ��1-3
        strSQL.Append("KOK.RENTEL3_BIKO, ")      ' 2016/02/02 W.GANEKO 2015監視改善 ��1-3
        strSQL.Append("KOK.RENTEL3_UPD_DATE, ")  ' 2016/02/02 W.GANEKO 2015監視改善 ��1-3
        strSQL.Append("KOK.TELA || TELB TELAB, ")     '2016/12/26 add H.Mori 2016改善開発 No5-1
        strSQL.Append("KOK.DAI3RENDORENTEL, ")        '2016/12/26 add H.Mori 2016改善開発 No5-1
        strSQL.Append("KOK.DAIHYO_NAME, ")            '2016/12/26 add H.Mori 2016改善開発 No4-6
        strSQL.Append("KOK.HOKBN, ")                  '2016/12/26 add H.Mori 2016改善開発 No4-6
        strSQL.Append("KOK.YOTOKBN, ")                '2016/12/26 add H.Mori 2016改善開発 No4-6
        strSQL.Append("KOK.HANBCD, ")                 '2016/12/26 add H.Mori 2016改善開発 No4-6
        strSQL.Append("KOK.SHUGOU, ")                   '2017/10/16 H.Mori add 2017改善開発 No4-1
        strSQL.Append("CLI.KEN_NAME, ")
        strSQL.Append("JAS.JA_CD, ")
        strSQL.Append("JAS.JA_NAME, ")
        strSQL.Append("JAS.JAS_NAME, ")
        strSQL.Append("PU1.NAME AS METASYU_NAI, ")
        '<<対応情報>>
        strSQL.Append("'2' AS HATKBN, ")            '発生区分[2:緊急警報]
        strSQL.Append("'1' AS SDSKBN, ")            '出動会社処理区分[1:未処理]
        strSQL.Append("NVL(KEI.NCUHATYMD,  KEI.KMYMD)  AS NCUHATYMD, ")  '[警報]NCU警報発生日
        strSQL.Append("NVL(KEI.NCUHATTIME, KEI.KMTIME) AS NCUHATTIME ")  '[警報]NCU警報発生時刻
        strSQL.Append(",KOK.TUSIN ")                'テレコン.通信モード
        '<<対応情報自動設定項目>>
        'strSQL.Append(",NVL(TA1.FAXKURAKBN, ")
        'strSQL.Append("    NVL( ")
        'strSQL.Append("      (SELECT T.FAXKURAKBN ")
        'strSQL.Append("       FROM M05_TANTO T ")
        'strSQL.Append("       WHERE '3' = T.KBN ")
        'strSQL.Append("         AND JAS.CLI_CD = T.KURACD ")
        'strSQL.Append("         AND TRIM(T.FAXKURAKBN) IS NOT NULL ")
        'strSQL.Append("         AND '01' = T.TANCD ")
        'strSQL.Append("         AND T.CODE = JAS.JA_CD), ")
        'strSQL.Append("     '2' ")
        'strSQL.Append("     ) ")
        'strSQL.Append(") AS FAXKURAKBN ")
        'strSQL.Append(",NVL(TA2.FAXKBN, ")
        'strSQL.Append("    NVL( ")
        'strSQL.Append("      (SELECT T.FAXKBN ")
        'strSQL.Append("       FROM M05_TANTO T ")
        'strSQL.Append("       WHERE '3' = T.KBN ")
        'strSQL.Append("         AND JAS.CLI_CD = T.KURACD ")
        'strSQL.Append("         AND TRIM(T.FAXKBN) IS NOT NULL ")
        'strSQL.Append("         AND '01' = T.TANCD ")
        'strSQL.Append("         AND T.CODE = JAS.JA_CD), ")
        'strSQL.Append("     '2' ")
        'strSQL.Append("     ) ")
        'strSQL.Append(") AS FAXKBN ")
        ' 2013/08/07 T.Ono mod ---------- START
        'strSQL.Append(",DECODE(NVL(TA1.FAXKURAKBN, ")
        'strSQL.Append("       (SELECT T.FAXKURAKBN ")
        'strSQL.Append("        FROM M05_TANTO T ")
        'strSQL.Append("       WHERE '3' = T.KBN ")
        'strSQL.Append("         AND JAS.CLI_CD = T.KURACD ")
        'strSQL.Append("         AND TRIM(T.FAXKURAKBN) IS NOT NULL ")
        'strSQL.Append("         AND '01' = T.TANCD ")
        'strSQL.Append("         AND T.CODE = JAS.JA_CD)), ")
        'strSQL.Append(" '1','1','2')  AS FAXKURAKBN ")
        'strSQL.Append(",DECODE(NVL(TA1.FAXKBN, ")
        'strSQL.Append("      (SELECT T.FAXKBN ")
        'strSQL.Append("       FROM M05_TANTO T ")
        'strSQL.Append("       WHERE '3' = T.KBN ")
        'strSQL.Append("         AND JAS.CLI_CD = T.KURACD ")
        'strSQL.Append("         AND TRIM(T.FAXKBN) IS NOT NULL ")
        'strSQL.Append("         AND '01' = T.TANCD ")
        'strSQL.Append("         AND T.CODE = JAS.JA_CD)), ")
        'strSQL.Append(" '1','1','2') AS FAXKBN ")
        strSQL.Append(",DECODE('" & strPar(0) & "','1','1','2')  AS FAXKBN ")
        strSQL.Append(",DECODE('" & strPar(1) & "','1','1','2')  AS FAXKURAKBN ")
        ' 2013/08/07 T.Ono mod ---------- END
        strSQL.Append(",'2'  AS FAXRUISEKIKBN ") ' 2015/12/21 H.Mori add
        strSQL.Append(",'1'  AS FAXSPOTKBN ") ' 2016/12/26 H.Mori add 2016監視改善 No4-6
        strSQL.Append(",KL.KAITU_DAY ") '2013/08/23 T.Ono add 監視改善2013��1
        strSQL.Append(",NVL(H3.GROUPCD, NVL(H2.GROUPCD, NVL(H1.GROUPCD, ''))) AS HANJICD ") '販売事業者コード 2014/12/19 T.Ono add 2014改善開発 No2
        strSQL.Append(",NVL2(H3.GROUPCD, H3.HANJIGYOSYANM, NVL2(H2.GROUPCD, H2.HANJIGYOSYANM ,NVL2(H1.GROUPCD, H1.HANJIGYOSYANM,''))) AS HANJINM ") '販売事業者名 2014/12/19 T.Ono add 2014改善開発 No2
        strSQL.Append(",NVL(K3.GROUPCD, NVL(K2.GROUPCD, NVL(K1.GROUPCD, ''))) AS KINRENCD ") '2016/12/26 H.Mori add 2016改善開発 No4-6 緊急連絡先CD
        strSQL.Append(",NVL(K3.GROUPNM, NVL(K2.GROUPNM, NVL(K1.GROUPNM, ''))) AS JMNAME ") ' 2023/01/04 ADD Y.ARAKAKI 2022更改No�E _帳票JMコード表示追加対応 JM和名（グループCD取得できれば必ず取得できるはず）
        '==========================================
        'FROM句
        '==========================================
        strSQL.Append("FROM T10_KEIHO KEI ")
        strSQL.Append("     ,SHAMAS KOK ")
        strSQL.Append("     ,CLIMAS CLI ")
        strSQL.Append("     ,HN2MAS JAS ")
        strSQL.Append("     ,M06_PULLDOWN PU1 ")
        'strSQL.Append("     ,M05_TANTO TA1 ") ' 2013/08/07 T.Ono del
        'strSQL.Append("     ,M05_TANTO TA2 ")
        ' 2013/08/23 T.Ono add 監視改善2013��1 ----------Start
        strSQL.Append("     , ")
        strSQL.Append("     (SELECT MAX(TO_CHAR(L.KAITU_DAY, 'YYYY/MM/DD HH24:MI:SS')) AS KAITU_DAY ")
        strSQL.Append("      FROM KAILOG L, ")
        strSQL.Append("           T10_KEIHO K ")
        strSQL.Append("      WHERE K.SYORI_SERIAL = '" & pstrSyoriNo & "' ")
        strSQL.Append("      AND K.KURACD = L.CLI_CD(+) ")
        strSQL.Append("      AND K.ACBCD  = L.HAN_CD(+) ")
        strSQL.Append("      AND K.JUYOKA = L.USER_CD(+) ")
        strSQL.Append("      AND L.KAITU_FLG(+) = '20' ")
        strSQL.Append("      AND L.KAITU_DAY(+) >= TO_DATE(TO_CHAR(SYSDATE, 'YYYY/MM/DD'),'YYYY/MM/DD') ")
        strSQL.Append("     ) KL ")
        ' 2013/08/23 T.Ono add 監視改善2013��1 ----------END
        '2014/12/19 T.Ono add 2014改善開発 No2 START
        strSQL.Append("     ,M09_JAGROUP G1 ")     'JA支所
        strSQL.Append("     ,M10_HANJIGYOSYA H1 ")
        strSQL.Append("     ,M09_JAGROUP G2 ")     'ユーザー範囲
        strSQL.Append("     ,M10_HANJIGYOSYA H2 ")
        strSQL.Append("     ,M09_JAGROUP G3 ")     'ユーザー個別
        strSQL.Append("     ,M10_HANJIGYOSYA H3 ")
        '2014/12/19 T.Ono add 2014改善開発 No2 END
        '2016/12/26 H.Mori add 2016改善開発 No4-6 START
        strSQL.Append("     ,M09_JAGROUP G4 ")     'JA支所
        strSQL.Append("     ,M11_JAHOKOKU K1 ")
        strSQL.Append("     ,M09_JAGROUP G5 ")     'ユーザー範囲
        strSQL.Append("     ,M11_JAHOKOKU K2 ")
        strSQL.Append("     ,M09_JAGROUP G6 ")     'ユーザー個別
        strSQL.Append("     ,M11_JAHOKOKU K3 ")
        '2016/12/26 H.Mori add 2016改善開発 No4-6 END
        '==========================================
        'WHERE句
        '    条件：警報TBL.担当者対応状態 = "0"
        '==========================================
        strSQL.Append("WHERE KEI.REACTION = '0' ")
        strSQL.Append("  AND KEI.SYORI_SERIAL = '" & pstrSyoriNo & "' ")
        strSQL.Append("  AND KEI.ROC_FRG IS NULL ") '2021/10/01 sakaUPD 対応中の警報は自動対応で落とさない
        strSQL.Append("  AND KEI.KURACD = KOK.CLI_CD(+) ")
        strSQL.Append("  AND KEI.ACBCD  = KOK.HAN_CD(+) ")
        strSQL.Append("  AND KEI.JUYOKA = KOK.USER_CD(+) ")
        strSQL.Append("  AND KEI.KURACD = CLI.CLI_CD(+) ")
        strSQL.Append("  AND KEI.KURACD = JAS.CLI_CD(+) ")
        strSQL.Append("  AND KEI.ACBCD  = JAS.HAN_CD(+) ")
        strSQL.Append("  AND '06' = PU1.KBN(+) ")               'メータ種別
        strSQL.Append("  AND KEI.META_SYUBETU = PU1.CD(+) ")
        ' 2013/08/07 T.Ono del ---------- START
        'strSQL.Append("  AND '3' = TA1.KBN(+) ")
        'strSQL.Append("  AND KEI.KURACD = TA1.KURACD(+) ")
        ''strSQL.Append("  AND TA1.FAXKURAKBN(+) IS NOT NULL ")
        'strSQL.Append("  AND TA1.CODE(+) = KEI.ACBCD ")
        'strSQL.Append("  AND '01' = TA1.TANCD(+) ")
        ''strSQL.Append("  AND '3' = TA2.KBN(+) ")
        ''strSQL.Append("  AND KEI.KURACD = TA2.KURACD(+) ")
        ''strSQL.Append("  AND TA2.FAXKBN(+) IS NOT NULL ")
        ''strSQL.Append("  AND TA2.CODE(+) = KEI.ACBCD ")
        ''strSQL.Append("  AND '01' = TA2.TANCD(+) ")
        ' 2013/08/07 T.Ono del ---------- END
        '2014/12/19 T.Ono add 2014改善開発 No2 START
        'JA支所単位
        strSQL.Append("  AND G1.KBN(+) = '001' ")
        strSQL.Append("  AND G1.KURACD(+) = KEI.KURACD ")
        strSQL.Append("  AND G1.ACBCD(+) = KEI.ACBCD ")
        strSQL.Append("  AND G1.USERCD_FROM(+) IS NULL ")
        strSQL.Append("  AND G1.USERCD_TO(+) IS NULL ")
        strSQL.Append("  AND G1.GROUPCD = H1.GROUPCD(+) ")
        'ユーザー範囲
        strSQL.Append("  AND G2.KBN(+) = '001' ")
        strSQL.Append("  AND G2.KURACD(+) = KEI.KURACD ")
        strSQL.Append("  AND G2.ACBCD(+) = KEI.ACBCD ")
        strSQL.Append("  AND KEI.JUYOKA BETWEEN G2.USERCD_FROM(+) AND G2.USERCD_TO(+) ")
        strSQL.Append("  AND G2.USERCD_TO(+) IS NOT NULL ")
        strSQL.Append("  AND G2.GROUPCD = H2.GROUPCD(+) ")
        'ユーザー個別
        strSQL.Append("  AND G3.KBN(+) = '001' ")
        strSQL.Append("  AND G3.KURACD(+) = KEI.KURACD ")
        strSQL.Append("  AND G3.ACBCD(+) = KEI.ACBCD ")
        strSQL.Append("  AND G3.USERCD_FROM(+) = KEI.JUYOKA ")
        strSQL.Append("  AND G3.USERCD_TO(+) IS NULL ")
        strSQL.Append("  AND G3.GROUPCD = H3.GROUPCD(+) ")
        '2014/12/19 T.Ono add 2014改善開発 No2 END
        '2016/12/26 H.Mori add 2016改善開発 No4-6 START 緊急連絡先cd
        'JA支所単位
        strSQL.Append("  AND G4.KBN(+) = '002' ")
        strSQL.Append("  AND G4.KURACD(+) = KEI.KURACD ")
        strSQL.Append("  AND G4.ACBCD(+) = KEI.ACBCD ")
        strSQL.Append("  AND G4.USERCD_FROM(+) IS NULL ")
        strSQL.Append("  AND G4.USERCD_TO(+) IS NULL ")
        strSQL.Append("  AND G4.GROUPCD = K1.GROUPCD(+) ")
        strSQL.Append("  AND K1.GROUPNM(+) IS NOT NULL  ") ' 2023/01/04 ADD Y.ARAKAKI 2022更改No�E _帳票JMコード表示追加対応 
        'ユーザー範囲
        strSQL.Append("  AND G5.KBN(+) = '002' ")
        strSQL.Append("  AND G5.KURACD(+) = KEI.KURACD ")
        strSQL.Append("  AND G5.ACBCD(+) = KEI.ACBCD ")
        strSQL.Append("  AND KEI.JUYOKA BETWEEN G5.USERCD_FROM(+) AND G5.USERCD_TO(+) ")
        strSQL.Append("  AND G5.USERCD_TO(+) IS NOT NULL ")
        strSQL.Append("  AND G5.GROUPCD = K2.GROUPCD(+) ")
        strSQL.Append("  AND K2.GROUPNM(+) IS NOT NULL  ") ' 2023/01/04 ADD Y.ARAKAKI 2022更改No�E _帳票JMコード表示追加対応 
        'ユーザー個別
        strSQL.Append("  AND G6.KBN(+) = '002' ")
        strSQL.Append("  AND G6.KURACD(+) = KEI.KURACD ")
        strSQL.Append("  AND G6.ACBCD(+) = KEI.ACBCD ")
        strSQL.Append("  AND G6.USERCD_FROM(+) = KEI.JUYOKA ")
        strSQL.Append("  AND G6.USERCD_TO(+) IS NULL ")
        strSQL.Append("  AND G6.GROUPCD = K3.GROUPCD(+) ")
        strSQL.Append("  AND K3.GROUPNM(+) IS NOT NULL  ") ' 2023/01/04 ADD Y.ARAKAKI 2022更改No�E _帳票JMコード表示追加対応 
        '2016/12/26 H.Mori add 2016改善開発 No4-6 END

        strSQL.Append("ORDER BY ")
        strSQL.Append("  KEI.SYORI_SERIAL ")
        mlog("[KEJUKJAW00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- getAutoKeiho end  pstrSyoriNo=" & pstrSyoriNo)

        Return strSQL.ToString
    End Function

    '************************************************
    ' 自動対応を行う対象のデータ取得SQL
    '************************************************
    '2014/10/17 H.Hosoda mod 処理Noを引数として設定
    'Private Function getSqlExistsAutoTaiou() As String
    Private Function getSqlExistsAutoTaiou(ByVal pstrSYORI_SERIAL As String) As String

        Dim strSQL As StringBuilder = New StringBuilder
        mlog("[KEJUKJAW00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- getSqlExistsAutoTaiou start  pstrSYORI_SERIAL=" & pstrSYORI_SERIAL)
        '+----------------------------------------------------+
        '|自動対応を行う対象のデータの取得するSQL
        '+----------------------------------------------------+
        strSQL.Append("SELECT ")
        strSQL.Append("  KEI.SYORI_SERIAL ")
        strSQL.Append("  ,KEI.REACTION ")
        strSQL.Append("  ,KEI.KANSCD ")
        strSQL.Append("  ,KEI.KURACD ")
        strSQL.Append("  ,KEI.ACBCD ")
        strSQL.Append("  ,KEI.JUYOKA ")
        strSQL.Append("  ,KEI.KMCD1 ")
        strSQL.Append("  ,KEI.KMNM1 ")
        strSQL.Append("  ,KEI.KMCD2 ")
        strSQL.Append("  ,KEI.KMNM2 ")
        strSQL.Append("  ,KEI.KMCD3 ")
        strSQL.Append("  ,KEI.KMNM3 ")
        strSQL.Append("  ,KEI.KMCD4 ")
        strSQL.Append("  ,KEI.KMNM4 ")
        strSQL.Append("  ,KEI.KMCD5 ")
        strSQL.Append("  ,KEI.KMNM5 ")
        strSQL.Append("  ,KEI.KMCD6 ")
        strSQL.Append("  ,KEI.KMNM6 ")
        strSQL.Append("FROM ")
        strSQL.Append("  T10_KEIHO KEI ")
        strSQL.Append("WHERE ")
        strSQL.Append("  KEI.REACTION = '0' ")
        strSQL.Append("  AND TO_NUMBER(KEI.SYORI_SERIAL) <= " & pstrSYORI_SERIAL) '2014/10/17 H.Hosoda add 1Line 処理Noを条件として設定
        strSQL.Append("  AND KEI.ROC_FRG IS NULL ") '2021/10/01 sakaUPD 対応中の警報は自動対応で落とさない
        '2017/02/09 W.GANEKO UPD START 2016監視改善 ��10
        strSQL.Append("  AND EXISTS (SELECT ")
        strSQL.Append("                'X' ")
        strSQL.Append("              FROM ")
        strSQL.Append("                M09_JAGROUP JAGRP ")
        strSQL.Append("                ,M08_AUTOTAIOU ATTAI ")
        strSQL.Append("              WHERE ")
        strSQL.Append("                JAGRP.KBN = '003' ")
        strSQL.Append("                AND JAGRP.KURACD = KEI.KURACD ")
        strSQL.Append("                AND JAGRP.ACBCD = KEI.ACBCD ")
        strSQL.Append("                AND JAGRP.GROUPCD = ATTAI.GROUPCD ")
        strSQL.Append("                AND ATTAI.USE_FLG = '1' ")
        strSQL.Append("                AND ATTAI.PROCKBN = '1' ")
        strSQL.Append("                AND ATTAI.KMCD IN (KEI.KMCD1, KEI.KMCD2, KEI.KMCD3, KEI.KMCD4, KEI.KMCD5, KEI.KMCD6) ")
        strSQL.Append("              ) ")
        'strSQL.Append("  AND EXISTS (SELECT ")
        'strSQL.Append("                'X' ")
        'strSQL.Append("              FROM ")
        'strSQL.Append("                M07_AUTOTAIOUGROUP ATTAIGRP ")
        'strSQL.Append("                ,M08_AUTOTAIOU ATTAI ")
        'strSQL.Append("              WHERE ")
        'strSQL.Append("                ATTAIGRP.KURACD = KEI.KURACD ")
        'strSQL.Append("                AND ATTAIGRP.ACBCD = KEI.ACBCD ")
        'strSQL.Append("                AND ATTAIGRP.USE_FLG = '1' ")
        'strSQL.Append("                AND ATTAIGRP.GROUPCD = ATTAI.GROUPCD ")
        'strSQL.Append("                AND ATTAI.USE_FLG = '1' ")
        'strSQL.Append("                AND ATTAI.PROCKBN = '1' ")
        'strSQL.Append("                AND ATTAI.KMCD IN (KEI.KMCD1, KEI.KMCD2, KEI.KMCD3, KEI.KMCD4, KEI.KMCD5, KEI.KMCD6) ")
        'strSQL.Append("              ) ")
        '2017/02/09 W.GANEKO UPD END 2016監視改善 ��10
        mlog("[KEJUKJAW00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- getSqlExistsAutoTaiou end  pstrSYORI_SERIAL=" & pstrSYORI_SERIAL)

        Return strSQL.ToString

    End Function

    '************************************************
    ' 自動対応内容のリストを取得SQL
    '************************************************
    Private Function getSqlAutoTaiouList(ByVal pstrSyoriNo As String) As String
        Dim strSQL As StringBuilder = New StringBuilder
        mlog("[KEJUKJAW00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- getSqlAutoTaiouList start  pstrSyoriNo=" & pstrSyoriNo)
        '+----------------------------------------------------+
        '|自動対応内容のリストを取得するSQL
        '+----------------------------------------------------+
        strSQL.Append("SELECT ")
        strSQL.Append("  MAIN.GROUPCD ")
        strSQL.Append("  ,MAIN.KMCD ")
        strSQL.Append("  ,MAIN.KMNM ")
        strSQL.Append("  ,MAIN.PROCKBN ")
        strSQL.Append("  ,MAIN.TAIOKBN ")
        strSQL.Append("  ,MAIN.TMSKB ")
        strSQL.Append("  ,MAIN.TKTANCD ")
        strSQL.Append("  ,MAIN.TAITCD ")
        strSQL.Append("  ,MAIN.TFKICD ")
        strSQL.Append("  ,MAIN.TKIGCD ")
        strSQL.Append("  ,MAIN.TSADCD ")
        strSQL.Append("  ,MAIN.TELRCD ")
        strSQL.Append("  ,MAIN.TEL_MEMO1 ")
        strSQL.Append("  ,MAIN.USE_FLG ")
        strSQL.Append("  ,MAIN.INS_DATE ")
        strSQL.Append("  ,MAIN.UPD_DATE ")
        strSQL.Append("FROM ")
        strSQL.Append("  M08_AUTOTAIOU MAIN, ")
        strSQL.Append("  (SELECT ")
        strSQL.Append("     ATTAI.* ")
        strSQL.Append("   FROM ")
        strSQL.Append("     M08_AUTOTAIOU ATTAI ")
        strSQL.Append("   WHERE ")
        strSQL.Append("     ATTAI.USE_FLG = '1' ")
        '2017/02/09 W.GANEKO UPD START 2016監視改善 ��10
        strSQL.Append("     AND EXISTS (SELECT ")
        strSQL.Append("                   'X' ")
        strSQL.Append("                 FROM ")
        strSQL.Append("                   T10_KEIHO KEI ")
        strSQL.Append("                   ,M09_JAGROUP JAGRP ")
        strSQL.Append("                 WHERE ")
        strSQL.Append("                   KEI.SYORI_SERIAL = '" & pstrSyoriNo & "' ")
        strSQL.Append("                   AND KEI.ROC_FRG IS NULL ") '2021/10/01 sakaUPD 対応中の警報は自動対応で落とさない
        strSQL.Append("                   AND KEI.KURACD = JAGRP.KURACD ")
        strSQL.Append("                   AND KEI.ACBCD = JAGRP.ACBCD ")
        strSQL.Append("                   AND JAGRP.KBN = '003' ")
        strSQL.Append("                   AND JAGRP.GROUPCD = ATTAI.GROUPCD ")
        strSQL.Append("                   AND ATTAI.PROCKBN = '1' ")
        strSQL.Append("                   AND ATTAI.KMCD IN (KEI.KMCD1, KEI.KMCD2, KEI.KMCD3, KEI.KMCD4, KEI.KMCD5, KEI.KMCD6) ")
        strSQL.Append("                 ) ")
        'strSQL.Append("     AND EXISTS (SELECT ")
        'strSQL.Append("                   'X' ")
        'strSQL.Append("                 FROM ")
        'strSQL.Append("                   T10_KEIHO KEI ")
        'strSQL.Append("                   ,M07_AUTOTAIOUGROUP ATTAIGRP ")
        'strSQL.Append("                 WHERE ")
        'strSQL.Append("                   KEI.SYORI_SERIAL = '" & pstrSyoriNo & "' ")
        'strSQL.Append("                   AND KEI.KURACD = ATTAIGRP.KURACD ")
        'strSQL.Append("                   AND KEI.ACBCD = ATTAIGRP.ACBCD ")
        'strSQL.Append("                   AND ATTAIGRP.USE_FLG = '1' ")
        'strSQL.Append("                   AND ATTAIGRP.GROUPCD = ATTAI.GROUPCD ")
        'strSQL.Append("                   AND ATTAI.PROCKBN = '1' ")
        'strSQL.Append("                   AND ATTAI.KMCD IN (KEI.KMCD1, KEI.KMCD2, KEI.KMCD3, KEI.KMCD4, KEI.KMCD5, KEI.KMCD6) ")
        'strSQL.Append("                 ) ")
        '2017/02/09 W.GANEKO UPD END 2016監視改善 ��10
        strSQL.Append("     AND ROWNUM = 1 ")
        strSQL.Append("   ORDER BY ")
        strSQL.Append("     ATTAI.GROUPCD ")
        strSQL.Append("  ) SUB ")
        strSQL.Append("WHERE ")
        strSQL.Append("      MAIN.GROUPCD = SUB.GROUPCD ")
        strSQL.Append("  AND MAIN.USE_FLG = '1' ") ' 2012/01/30 T.Watabe edit
        strSQL.Append("ORDER BY ")
        strSQL.Append("  MAIN.PROCKBN ")
        mlog("[KEJUKJAW00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- getSqlAutoTaiouList end  pstrSyoriNo=" & pstrSyoriNo)
        Return strSQL.ToString

    End Function

    '********************************************************
    'セキュリティ情報抽出SQL生成
    '********************************************************
    Private Function getSqlSecurityInfo(ByRef sql As StringBuilder, ByVal row As DataRow, ByVal kmcd As String) As Boolean

        mlog("[KEJUKJAW00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- getSqlSecurityInfo start  kmcd=" & kmcd)
        sql.Append("SELECT ")
        sql.Append("  CLI_CD ")
        sql.Append("  ,HAN_CD ")
        sql.Append("  ,USER_CD ")
        sql.Append("  ,OUT_FLG ")
        sql.Append("  ,SEQMSG ")
        sql.Append("FROM ")
        sql.Append("  SQIMAS ")
        sql.Append("WHERE ")
        sql.Append("  CLI_CD = '" & Convert.ToString(row.Item("KURACD")) & "' ")
        sql.Append("  AND (HAN_CD = '" & Convert.ToString(row.Item("ACBCD")) & "' OR NOT REGEXP_LIKE(HAN_CD, '[0-9]')) ")
        sql.Append("  AND (USER_CD = '" & Convert.ToString(row.Item("JUYOKA")) & "' OR NOT REGEXP_LIKE(USER_CD, '[0-9]')) ")

        Select Case kmcd
            Case KM_ZAN3
                sql.Append("  AND SEQ_GRP1 = '2' ")
                sql.Append("  AND SEQ_GRP2 = '06' ")
                sql.Append("  AND SEQ_GRP3 = '020' ")
                sql.Append("  AND ID_BYTE  = '3' ")
                sql.Append("  AND SEQ_BYTE1_1 = '20' ")
                sql.Append("  AND SEQ_CD1_1   = '2---0' ")
                sql.Append("  AND SEQ_BYTE1_2 = '25' ")
                sql.Append("  AND SEQ_CD1_2 LIKE '___4___' ")
            Case KM_ZAN2
                sql.Append("  AND SEQ_GRP1 = '2' ")
                sql.Append("  AND SEQ_GRP2 = '07' ")
                sql.Append("  AND SEQ_GRP3 = '020' ")
                sql.Append("  AND ID_BYTE  = '3' ")
                sql.Append("  AND SEQ_BYTE1_1 = '20' ")
                sql.Append("  AND SEQ_CD1_1   = '2---0' ")
                sql.Append("  AND SEQ_BYTE1_2 = '25' ")
                sql.Append("  AND SEQ_CD1_2 LIKE '___2___' ")
            Case KM_ZAN1
                sql.Append("  AND SEQ_GRP1 = '2' ")
                sql.Append("  AND SEQ_GRP2 = '08' ")
                sql.Append("  AND SEQ_GRP3 = '020' ")
                sql.Append("  AND ID_BYTE  = '3' ")
                sql.Append("  AND SEQ_BYTE1_1 = '20' ")
                sql.Append("  AND SEQ_CD1_1   = '2---0' ")
                sql.Append("  AND SEQ_BYTE1_2 = '25' ")
                sql.Append("  AND SEQ_CD1_2 LIKE '___1___' ")
            Case Else
                '次のレコードへ
                Return False
        End Select

        sql.Append("ORDER BY ")
        sql.Append("  USER_CD DESC ")
        sql.Append("  ,HAN_CD DESC ")
        mlog("[KEJUKJAW00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- getSqlSecurityInfo start  kmcd=" & kmcd)

        Return True
    End Function

    '************************************************
    ' 対応入力TBLへ登録するデータの編集
    '************************************************
    Private Sub editTaiouData(ByVal pRow As DataRow, ByVal cdb As CDB, ByRef dto As KEJUKJAW00DTO.D20TaiouDto, ByVal atDto As KEJUKJAW00DTO.AutoTaiouDto)

        Dim decKonkai_Hai_S As Decimal              '//今回配送日・指針一時格納用
        Dim decKmsin As Decimal                     '//メータ値一時格納用（配送日からの推定使用量計算時に使用）
        Dim strG_Zaiko As String                    '//配送日からの推定使用料一時格納用
        Dim strNcuSet As String                     '//ＮＣＵ接続一時格納用
        Dim decKeihosu As Decimal                   '//警報メッセージ数
        Dim sRyuryo As String '流量区分
         mlog("[KEJUKJAW00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- editTaiouData start")

        Dim DateFncC As New Common.CDateFnc
        Dim TimeFncC As New Common.CTimeFnc
        Dim NaNFncC As New Common.CNaNFnc
        Try
            '//--------------------------------------------------------------------------
            Dim strTemp As String
            Dim intTemp As Integer
            Dim intLoop As Integer

            'データが無ければ
            If Convert.ToString(pRow.Item(0)) = "XYZ" Then

            Else
                '既に対応済みの警報だったら表示しない
                '対象の警報が既に対応済みだった場合のチェック
                If Convert.ToString(pRow.Item("REACTION")) <> "0" Then
                    dto = Nothing
                End If

                '---------------------
                'データ転記処理
                '---------------------
                '判別ページ
                dto.BackUrl = "KEJUKJAG00"
                '処理No(警報)
                dto.MoveSerial = Convert.ToString(pRow.Item("SYORI_SERIAL"))
                '区分
                dto.KBN = "1" '登録

                '発生日
                dto.NCUHATYMD = Convert.ToString(pRow.Item("NCUHATYMD"))
                '発生時刻
                dto.NCUHATTIME = Convert.ToString(pRow.Item("NCUHATTIME"))
                '受信日
                dto.HATYMD = Convert.ToString(pRow.Item("KMYMD"))
                '受信時刻
                dto.HATTIME = Convert.ToString(pRow.Item("KMTIME"))

                'メータ値/メータ桁数
                '整数部桁数
                If IsNumeric(pRow.Item("NUM_DIGIT")) = True Then
                    intTemp = Convert.ToInt32(pRow.Item("NUM_DIGIT"))
                Else
                    intTemp = 0
                End If
                If IsNumeric(pRow.Item("KMSIN")) = True Then
                    strTemp = Convert.ToString(pRow.Item("KMSIN"))
                Else
                    strTemp = ""
                End If
                If strTemp.Length = 0 Then
                    'メータ値が指定されていなかったら
                    strTemp = ""
                Else
                    'メータ値が指定されていたら小数点編集
                    strTemp = strTemp.Substring(0, intTemp) & "." & strTemp.Substring(intTemp)
                End If
                If strTemp.Length > 0 Then
                    decKmsin = CDec(strTemp)
                End If
                dto.KENSIN = strTemp
                dto.NUM_DIGIT = Convert.ToString(pRow.Item("NUM_DIGIT"))

                '警報メッセージ数
                '警報受信パネルからの遷移だった場合
                For intLoop = 1 To 6
                    '警報メッセージ数算出処理
                    If Convert.ToString _
                        (pRow.Item("KMCD" & intLoop)) <> "" Then
                        '値が入っていれば警報メッセージ数カウント
                        decKeihosu = decKeihosu + 1
                    End If
                Next
                dto.KEIHOSU = Convert.ToString(decKeihosu)

                '流量区分
                '「0〜9」はそのまま、「: ; < = > ?」はそれぞれ「10 11 12 13 14 15」に置き換え、その他は「0」
                '「0〜15」はそのままとする。
                sRyuryo = Convert.ToString(pRow.Item("RYURYO")).Trim
                If (sRyuryo >= "0" And sRyuryo <= "9") Or (sRyuryo >= "10" And sRyuryo <= "15") Then
                    dto.RYURYO = sRyuryo
                ElseIf sRyuryo = ":" Or sRyuryo = ";" Or sRyuryo = "<" Or sRyuryo = "=" Or sRyuryo = ">" Or sRyuryo = "?" Then
                    dto.RYURYO = sRyuryo.Replace(":", "10").Replace(";", "11").Replace("<", "12").Replace("=", "13").Replace(">", "14").Replace("?", "15")
                Else
                    dto.RYURYO = "0" 'その他
                End If
                'メータ種別
                dto.METASYU = Convert.ToString(pRow.Item("METASYU_NAI"))
                'お客様ＦＬＧコード
                dto.UNYO = Convert.ToString(pRow.Item("UNYOCD"))
                '警報メッセージ１
                dto.KMCD1 = Convert.ToString(pRow.Item("KMCD1"))
                dto.KMNM1 = Convert.ToString(pRow.Item("KMNM1"))
                '警報メッセージ２
                dto.KMCD2 = Convert.ToString(pRow.Item("KMCD2"))
                dto.KMNM2 = Convert.ToString(pRow.Item("KMNM2"))
                '警報メッセージ３
                dto.KMCD3 = Convert.ToString(pRow.Item("KMCD3"))
                dto.KMNM3 = Convert.ToString(pRow.Item("KMNM3"))
                '警報メッセージ４
                dto.KMCD4 = Convert.ToString(pRow.Item("KMCD4"))
                dto.KMNM4 = Convert.ToString(pRow.Item("KMNM4"))
                '警報メッセージ５
                dto.KMCD5 = Convert.ToString(pRow.Item("KMCD5"))
                dto.KMNM5 = Convert.ToString(pRow.Item("KMNM5"))
                '警報メッセージ６
                dto.KMCD6 = Convert.ToString(pRow.Item("KMCD6"))
                dto.KMNM6 = Convert.ToString(pRow.Item("KMNM6"))

                'お客様コード
                dto.USER_CD = Convert.ToString(pRow.Item("JUYOKA_CD"))
                'お客様氏名
                dto.JUSYONM = Convert.ToString(pRow.Item("JUYONM"))
                'お客様カナ
                dto.JUSYOKN = Convert.ToString(pRow.Item("KANA"))
                '電話番号
                dto.JUTEL1 = Convert.ToString(pRow.Item("JUTEL1"))
                'strTemp = Convert.ToString(pRow.Item("JUTEL2"))   '←2021/10/01 2021年度監視改善�FsakaDEL結線電話番号14ケタ化対応（ハイフン削除で市内10桁→JUTEL2（10桁））
                'If strTemp.Length > 4 Then
                'strTemp = strTemp.Substring(0, strTemp.Length - 4) & "-" & strTemp.Substring(strTemp.Length - 4, 4)
                'End If
                'dto.JUTEL2 = strTemp
                dto.JUTEL2 = Convert.ToString(pRow.Item("JUTEL2")) '←2021/10/01 2021年度監視改善�FsakaADD結線電話番号14ケタ化対応（ハイフン削除で市内10桁→JUTEL2（10桁））
                '連絡先
                dto.RENTEL = Convert.ToString(pRow.Item("RENTEL"))
                '検索電話番号
                dto.KTELNO = Convert.ToString(pRow.Item("KTELNO"))
                '住所
                dto.ADDR = Convert.ToString(pRow.Item("ADDR"))
                'クライアントコード
                dto.KURACD = Convert.ToString(pRow.Item("CLI_CD"))
                '監視センターコード
                dto.KANSCD = Convert.ToString(pRow.Item("KANSCD"))
                '県名
                dto.KENNM = Convert.ToString(pRow.Item("KEN_NAME"))
                'ＪＡコード
                dto.JACD = Convert.ToString(pRow.Item("JA_CD"))
                'ＪＡ名
                dto.JANM = Convert.ToString(pRow.Item("JA_NAME"))
                '販売事業者コード 2014/12/19 T.Ono add 2014改善開発 No2
                dto.HANJICD = Convert.ToString(pRow.Item("HANJICD"))
                '販売事業者名 2014/12/19 T.Ono add 2014改善開発 No2
                dto.HANJINM = Convert.ToString(pRow.Item("HANJINM"))
                'ＪＡ支所コード
                dto.ACBCD = Convert.ToString(pRow.Item("ACBCD"))
                'ＪＡ支所名
                dto.ACBNM = Convert.ToString(pRow.Item("JAS_NAME"))

                'ＪＰ備考
                dto.BIKOU = Convert.ToString(pRow.Item("BIKOU"))

                'NCU_CONは、共有マスタの「検針種別」の項目から取得するため、A、B、M、T、tのいずれか
                strNcuSet = Convert.ToString(pRow.Item("NCU_CON"))
                Dim strSQL As New StringBuilder("")
                Dim dbData As DataSet

                Dim strRec As String

                '//対応入力からの画面遷移の場合
                strSQL.Append("SELECT ")
                strSQL.Append("COUNT(*) AS CNT ")
                strSQL.Append("FROM ")
                strSQL.Append("M06_PULLDOWN ")
                strSQL.Append("WHERE ")
                strSQL.Append("KBN = :KBN AND ")
                strSQL.Append("CD = :CD ")

                'パラメータのセット(NCU接続（双方向）の検索）
                cdb.pSQL = strSQL.ToString
                cdb.pSQLParamStr("KBN") = "60"
                cdb.pSQLParamStr("CD") = strNcuSet

                'SQL実行
                cdb.mExecQuery()
                dbData = cdb.pResult

                '結果が１件であれば
                If Convert.ToString(dbData.Tables(0).Rows(0).Item("CNT")) = "1" Then
                    'NCU接続（双方向）
                    strNcuSet = "1"
                Else
                    'パラメータのセット(NCU接続（端末発呼）の検索）
                    cdb.pSQLParamStr("KBN") = "61"
                    cdb.pSQLParamStr("CD") = strNcuSet
                    '//SQLの実行
                    cdb.mExecQuery()
                    dbData = cdb.pResult
                    '結果が１件であれば
                    If Convert.ToString(dbData.Tables(0).Rows(0).Item("CNT")) = "1" Then
                        'NCU接続（端末発呼)
                        strNcuSet = "2"
                    ElseIf strNcuSet = "" Then
                        'NCU接続(未接続）
                        strNcuSet = "3"
                    Else
                        strNcuSet = ""
                    End If
                End If
                'ＮＣＵ接続（Hiddenに格納）
                dto.NCU_SET = strNcuSet
                '地図番号
                dto.TIZUNO = Convert.ToString(pRow.Item("MAP_CD"))
                '交換区分(１：全交換　２：半数交換 ３：予備交換 ４：予備交互交換)
                dto.BOMB_TYPE = Convert.ToString(pRow.Item("BOMB_TYPE"))
                '販売区分
                dto.HANBAI_KBN = Convert.ToString(pRow.Item("HANBAI_KBN"))
                '供給形態区分
                dto.KYOKTKBN = Convert.ToString(pRow.Item("KYOKTKBN"))
                'メータ型式
                dto.MET_KATA = Convert.ToString(pRow.Item("SETSUBI"))
                'メータメーカー
                dto.MET_MAKER = Convert.ToString(pRow.Item("KYOKYU_MK"))
                'ボンベ１容器ＫＧ
                dto.BONB1_KKG = Convert.ToString(pRow.Item("BOMB_YOUKI1"))
                'ボンベ１設置本数
                dto.BONB1_HON = Convert.ToString(pRow.Item("BOMB_SUU1"))
                'ボンベ１容器予備フラグ
                dto.BONB1_YOBI = Convert.ToString(Convert.ToString(pRow.Item("BOMB_RYO1")))
                'ボンベ２容器ＫＧ
                dto.BONB2_KKG = Convert.ToString(pRow.Item("BOMB_YOUKI2"))
                'ボンベ２設置本数
                dto.BONB2_HON = Convert.ToString(pRow.Item("BOMB_SUU2"))
                'ボンベ２容器予備フラグ
                dto.BONB2_YOBI = Convert.ToString(Convert.ToString(pRow.Item("BOMB_RYO2")))
                'ボンベ３容器ＫＧ
                dto.BONB3_KKG = Convert.ToString(pRow.Item("BOMB_YOUKI3"))
                'ボンベ３設置本数
                dto.BONB3_HON = Convert.ToString(pRow.Item("BOMB_SUU3"))
                'ボンベ３容器予備フラグ
                dto.BONB3_YOBI = Convert.ToString(Convert.ToString(pRow.Item("BOMB_RYO3")))
                'ボンベ４容器ＫＧ
                dto.BONB4_KKG = Convert.ToString(pRow.Item("BOMB_YOUKI4"))
                'ボンベ４設置本数
                dto.BONB4_HON = Convert.ToString(pRow.Item("BOMB_SUU4"))
                'ボンベ４容器予備フラグ
                dto.BONB4_YOBI = Convert.ToString(Convert.ToString(pRow.Item("BOMB_RYO4")))
                '配送日からの推定使用量(今秋
                If (IsNumeric(Convert.ToString(pRow.Item("BOMV_SISIN1"))) = True And _
                    IsNumeric(Convert.ToString(pRow.Item("KMSIN"))) = True _
                       ) And _
                       Convert.ToString(pRow.Item("JUYOKA")).Length > 0 Then

                    If IsNumeric(Convert.ToString(pRow.Item("BOMV_SISIN1"))) = True Then
                        decKonkai_Hai_S = fncEditSisinDec(Convert.ToString(pRow.Item("BOMV_SISIN1")))
                    End If

                    '配送日からの推定使用量取得
                    If decKmsin >= decKonkai_Hai_S Then
                        'メータ値が今回配送日・指針以上だったら
                        strG_Zaiko = CStr(Decimal.Truncate((decKmsin - decKonkai_Hai_S) / 0.482D * 10D) / 10D)

                    ElseIf decKmsin < decKonkai_Hai_S Then
                        'メータ値が今回配送日・指針未満だったら
                        Select Case Convert.ToString(pRow.Item("NUM_DIGIT"))
                            Case "0"
                                strG_Zaiko = CStr(Decimal.Truncate((1D + decKmsin - decKonkai_Hai_S) / 0.482D * 10D) / 10D)
                            Case "1"
                                strG_Zaiko = CStr(Decimal.Truncate((10D + decKmsin - decKonkai_Hai_S) / 0.482D * 10D) / 10D)
                            Case "2"
                                strG_Zaiko = CStr(Decimal.Truncate((100D + decKmsin - decKonkai_Hai_S) / 0.482D * 10D) / 10D)
                            Case "3"
                                strG_Zaiko = CStr(Decimal.Truncate((1000D + decKmsin - decKonkai_Hai_S) / 0.482D * 10D) / 10D)
                            Case "4"
                                strG_Zaiko = CStr(Decimal.Truncate((10000D + decKmsin - decKonkai_Hai_S) / 0.482D * 10D) / 10D)
                            Case "5"
                                strG_Zaiko = CStr(Decimal.Truncate((100000D + decKmsin - decKonkai_Hai_S) / 0.482D * 10D) / 10D)
                            Case "6"
                                strG_Zaiko = CStr(Decimal.Truncate((1000000D + decKmsin - decKonkai_Hai_S) / 0.482D * 10D) / 10D)
                            Case "7"
                                strG_Zaiko = CStr(Decimal.Truncate((10000000D + decKmsin - decKonkai_Hai_S) / 0.482D * 10D) / 10D)
                            Case Else
                                strG_Zaiko = ""
                        End Select
                    End If
                Else
                    '両方とも指定がない場合は空で出力
                    strG_Zaiko = ""
                End If
                '配送日からの推定使用量
                dto.G_ZAIKO = strG_Zaiko
                '一日あたり使用量
                dto.ICHI_SIYO = Convert.ToString(pRow.Item("SIYOU3"))
                '予測１日当り使用量
                dto.YOSOKU_ICHI_SIYO = Convert.ToString(pRow.Item("SIYOU4"))
                'ボンベ交換前回配送日
                dto.ZENKAI_HAISO = Convert.ToString(pRow.Item("BOMV_HAISO1"))
                'ボンベ交換前回配送指針
                dto.ZENKAI_HAI_S = Convert.ToString(pRow.Item("BOMV_SISIN1"))
                'ボンベ交換今回配送日
                dto.KONKAI_HAISO = Convert.ToString(pRow.Item("BOMV_HAISO2"))
                '次回配送予定日
                dto.JIKAI_HAISO = Convert.ToString(pRow.Item("HAISO_YOTEI"))
                'ボンベ交換今回配送指針
                dto.KONKAI_HAI_S = Convert.ToString(pRow.Item("BOMV_SISIN2"))
                'ボンベ切替前回発生日
                dto.ZENKAI_HASEI = Convert.ToString(pRow.Item("BOMB_DATE1"))
                'ボンベ切替前回発生指針
                dto.ZENKAI_HAS_S = Convert.ToString(pRow.Item("BOMB_SISIN1"))
                'ボンベ切替今回発生日
                dto.KONKAI_HASEI = Convert.ToString(pRow.Item("BOMB_DATE2"))
                'ボンベ切替今回発生指針
                dto.KONKAI_HAS_S = Convert.ToString(pRow.Item("BOMB_SISIN2"))
                '検針情報前回検針日
                dto.ZENKAI_KENSIN = Convert.ToString(pRow.Item("KENSIN_DAY1"))
                '検針情報前回検針指針
                dto.ZENKAI_KEN_S = Convert.ToString(pRow.Item("KENSINTI1"))
                '前回使用量
                dto.ZENKAI_KEN_SIYO = Convert.ToString(pRow.Item("SIYOU1"))
                '検針情報今回検針日
                dto.KONKAI_KENSIN = Convert.ToString(pRow.Item("KENSIN_DAY2"))
                '検針情報今回検針指針
                dto.KONKAI_KEN_S = Convert.ToString(pRow.Item("KENSINTI2"))
                '今回使用量
                dto.KONKAI_KEN_SIYO = Convert.ToString(pRow.Item("SIYOU2"))
                'ガス器具１品名
                dto.GAS1_HINMEI = Convert.ToString(pRow.Item("GAS_NAME1"))
                'ガス器具１台数
                dto.GAS1_DAISU = Convert.ToString(pRow.Item("GAS_SUU1"))
                'ガス器具１セイフル
                dto.GAS1_SEIFL = Convert.ToString(pRow.Item("GAS_SEIF1"))
                'ガス器具２品名
                dto.GAS2_HINMEI = Convert.ToString(pRow.Item("GAS_NAME2"))
                'ガス器具２台数
                dto.GAS2_DAISU = Convert.ToString(pRow.Item("GAS_SUU2"))
                'ガス器具２セイフル
                dto.GAS2_SEIFL = Convert.ToString(pRow.Item("GAS_SEIF2"))
                'ガス器具３品名
                dto.GAS3_HINMEI = Convert.ToString(pRow.Item("GAS_NAME3"))
                'ガス器具３台数
                dto.GAS3_DAISU = Convert.ToString(pRow.Item("GAS_SUU3"))
                'ガス器具３セイフル
                dto.GAS3_SEIFL = Convert.ToString(pRow.Item("GAS_SEIF3"))
                'ガス器具４品名
                dto.GAS4_HINMEI = Convert.ToString(pRow.Item("GAS_NAME4"))
                'ガス器具４台数
                dto.GAS4_DAISU = Convert.ToString(pRow.Item("GAS_SUU4"))
                'ガス器具４セイフル
                dto.GAS4_SEIFL = Convert.ToString(pRow.Item("GAS_SEIF4"))
                'ガス器具５品名
                dto.GAS5_HINMEI = Convert.ToString(pRow.Item("GAS_NAME5"))
                'ガス器具５台数
                dto.GAS5_DAISU = Convert.ToString(pRow.Item("GAS_SUU5"))
                'ガス器具５セイフル
                dto.GAS5_SEIFL = Convert.ToString(pRow.Item("GAS_SEIF5"))
                'ガス供給休止日
                dto.GAS_STOP = Convert.ToString(pRow.Item("GAS_START"))
                'ガス供給廃止日
                dto.GAS_DELE = Convert.ToString(pRow.Item("GAS_DELE"))
                'ガス供給復活日
                dto.GAS_RESTART = Convert.ToString(pRow.Item("GAS_RESTART"))
                '本日工事状況　2013/08/26 T.Ono add 監視改善2013��1
                dto.KAITU_DAY = Convert.ToString(pRow.Item("KAITU_DAY"))
                '------------------------------------------------------------
                '------------------------------------------------------------
                '発生区分
                '//発生区分(1:電話／2:緊急対応)
                dto.HATKBN = Convert.ToString(pRow.Item("HATKBN"))

                '//お客様記事
                dto.GENIN_KIJI = Convert.ToString(pRow.Item("GENIN_KIJI"))

                Dim strSYSDATE As String = Now.ToString("yyyyMMdd")
                Dim strSYSTIME As String = Now.ToString("HHmmss")

                'すでにＤＢに開始日がセットされて、完了日がセットされている場合は無視する
                'また、すでにＤＢにある日付が変更されている場合はこの値を使用し、再度所要時間を計算する
                'dto.TAIO_ST_DATE = strSYSDATE
                'dto.SYOYMD = strSYSDATE
                'dto.TAIO_ST_TIME = strSYSTIME
                'dto.SYOTIME = strSYSTIME
                'MOD START 2012/03/30 W.GANEKO
                Dim strTAIO_ST_YMDTIME As String = Convert.ToString(pRow.Item("KMYMD")).Substring(0, 4) & "/" & Convert.ToString(pRow.Item("KMYMD")).Substring(4, 2) & "/" & Convert.ToString(pRow.Item("KMYMD")).Substring(6, 2) & " " & Convert.ToString(pRow.Item("KMTIME")).Substring(0, 2) & ":" & Convert.ToString(pRow.Item("KMTIME")).Substring(2, 2) & ":00"
                Dim dateTAIO_ST_YMDTIME As DateTime = DateTime.Parse(strTAIO_ST_YMDTIME)
                dateTAIO_ST_YMDTIME = dateTAIO_ST_YMDTIME.AddMinutes(1) '1分加算

                Dim strTAIO_ST_YMDCNV As String = dateTAIO_ST_YMDTIME.ToString("yyyyMMdd")
                Dim strTAIO_ST_TIMECNV As String = dateTAIO_ST_YMDTIME.ToString("HHmmss")

                dto.TAIO_ST_DATE = strTAIO_ST_YMDCNV
                dto.TAIO_ST_TIME = strTAIO_ST_TIMECNV

                Dim strSYOYMDTIME As String = Convert.ToString(pRow.Item("KMYMD")).Substring(0, 4) & "/" & Convert.ToString(pRow.Item("KMYMD")).Substring(4, 2) & "/" & Convert.ToString(pRow.Item("KMYMD")).Substring(6, 2) & " " & Convert.ToString(pRow.Item("KMTIME")).Substring(0, 2) & ":" & Convert.ToString(pRow.Item("KMTIME")).Substring(2, 2) & ":00"
                Dim dateSYOYMDTIME As DateTime = DateTime.Parse(strSYOYMDTIME)
                dateSYOYMDTIME = dateSYOYMDTIME.AddMinutes(3) '3分加算

                Dim strSYOYMDCNV As String = dateSYOYMDTIME.ToString("yyyyMMdd")
                Dim strSYOTIMECNV As String = dateSYOYMDTIME.ToString("HHmmss")

                Dim strTMSKB As String = Convert.ToString(atDto.tmskb)               '←2021/10/01 Start 2021年度監視改善�Eに関係し、自動対応で処理区分が2:処理済みでない場合は対応完了日(SYOYMD)は空欄とする

                If strTMSKB = "2" Then                                               '←2021/10/01 既存バグの修正となる、�Eで自動対応で未処理で登録されたデータを対応完了日などで検索させるが、日付が入っていてヒットしてしまう事が判明したため
                    dto.SYOYMD = strSYOYMDCNV
                    dto.SYOTIME = strSYOTIMECNV
                Else
                    dto.SYOYMD = ""
                    dto.SYOTIME = ""
                End If                                                               '←2021/10/01 End
                'MOD END 2012/03/30 W.GANEKO

                '対応区分
                dto.TAIOKBN = Convert.ToString(atDto.taiokbn)

                    '処理区分
                    dto.TMSKB = Convert.ToString(atDto.tmskb)

                    '担当者コード
                    dto.TKTANCD = Convert.ToString(atDto.tktancd)

                    '対応受信日・対応時刻
                    dto.JUYMD = Convert.ToString(pRow.Item("JUYMD"))
                    dto.JUTIME = Convert.ToString(pRow.Item("JUTIME"))

                    '連絡相手
                    dto.TAITCD = Convert.ToString(atDto.taitcd)

                    'FAX区分
                    '2015/12/24 T.Ono mod START 対応区分=3:重複 の場合は、報告不要にチェックを付ける 
                    'dto.FAXKBN = Convert.ToString(pRow.Item("FAXKBN"))
                    'dto.FAXKURAKBN = Convert.ToString(pRow.Item("FAXKURAKBN"))
                    'dto.FAXRUISEKIKBN = Convert.ToString(pRow.Item("FAXRUISEKIKBN")) '2015/11/25 H.Mori add 2015改善開発 No1
                    If dto.TAIOKBN = "3" Then
                        dto.FAXKBN = "1"
                        dto.FAXKURAKBN = "1"
                        dto.FAXRUISEKIKBN = "1"
                    Else
                        dto.FAXKBN = Convert.ToString(pRow.Item("FAXKBN"))
                        dto.FAXKURAKBN = Convert.ToString(pRow.Item("FAXKURAKBN"))
                        dto.FAXRUISEKIKBN = Convert.ToString(pRow.Item("FAXRUISEKIKBN")) '2015/11/25 H.Mori add 2015改善開発 No1
                    End If
                    '2015/12/24 T.Ono mod END

                    '電話連絡内容
                    dto.TELRCD = Convert.ToString(atDto.telrcd)

                    '復帰対応状況
                    dto.TFKICD = Convert.ToString(atDto.tfkicd)

                    '電話メモ１
                    dto.TEL_MEMO1 = Convert.ToString(atDto.tel_memo1)

                    'ガス器具
                    dto.TKIGCD = Convert.ToString(atDto.tkigcd)

                    '作業原因
                    dto.TSADCD = Convert.ToString(atDto.tsadcd)

                    '出動処理区分
                    dto.SDSKBN = Convert.ToString(pRow.Item("SDSKBN"))
                    '2016/02/02 W.GANEKO 2015改善開発 ��1-3 START
                    '監視備考
                    dto.KANSHI_BIKO = Convert.ToString(pRow.Item("KANSHI_BIKO"))
                    '連絡先2
                    dto.RENTEL2 = Convert.ToString(pRow.Item("RENTEL2"))
                    '連絡先2備考
                    dto.RENTEL2_BIKO = Convert.ToString(pRow.Item("RENTEL2_BIKO"))
                    '連絡先2更新日
                    dto.RENTEL2_UPD_DATE = Convert.ToString(pRow.Item("RENTEL2_UPD_DATE"))
                    '連絡先3
                    dto.RENTEL3 = Convert.ToString(pRow.Item("RENTEL3"))
                    '連絡先3備考
                    dto.RENTEL3_BIKO = Convert.ToString(pRow.Item("RENTEL3_BIKO"))
                    '連絡先3更新日
                    dto.RENTEL3_UPD_DATE = Convert.ToString(pRow.Item("RENTEL3_UPD_DATE"))
                    '2016/02/02 W.GANEKO 2015改善開発 ��1-3 END
                    '2016/12/26 H.Mori 2016改善開発 ��4-6 START
                    'NCU接続
                    dto.TUSIN = Convert.ToString(pRow.Item("TUSIN"))
                    '電話番号
                    dto.TELAB = Convert.ToString(pRow.Item("TELAB"))
                    '第3連動連絡先
                    dto.DAI3RENDORENTEL = Convert.ToString(pRow.Item("DAI3RENDORENTEL"))
                    '法人代表者氏名
                    dto.DAIHYO_NAME = Convert.ToString(pRow.Item("DAIHYO_NAME"))
                    '適用法令区分
                    dto.HOKBN = Convert.ToString(pRow.Item("HOKBN"))
                    '用途区分
                    dto.YOTOKBN = Convert.ToString(pRow.Item("YOTOKBN"))
                    '販売所コード
                    dto.HANBCD = Convert.ToString(pRow.Item("HANBCD"))
                    'ｽﾎﾟｯﾄFAX送信区分
                    dto.FAXSPOTKBN = Convert.ToString(pRow.Item("FAXSPOTKBN"))
                    '緊急連絡先CD 
                    dto.KINRENCD = Convert.ToString(pRow.Item("KINRENCD"))
                    '2016/12/26 H.Mori 2016改善開発 ��4-6 END
                    '2017/10/17 H.Mori add 2017改善開発 No4-1 START
                    '集合区分
                    dto.SHUGOU = Convert.ToString(pRow.Item("SHUGOU"))
                '2017/10/17 H.Mori add 2017改善開発 No4-1 END
                ' 2023/01/04 ADD START Y.ARAKAKI 2022更改No�E _帳票JMコード表示追加対応
                'JM和名
                dto.JMNAME = Convert.ToString(pRow.Item("JMNAME"))
                ' 2023/01/04 ADD END   Y.ARAKAKI 2022更改No�E _帳票JMコード表示追加対応
            End If
        Catch ex As Exception
            Throw ex
        End Try

        mlog("[KEJUKJAW00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- editTaiouData end")

    End Sub

    '******************************************************************************
    '*　概　要：下１桁を小数点とする数値型に変換する
    '*　備　考：
    '******************************************************************************
    Private Function fncEditSisinDec(ByVal strSisin As String) As Decimal
        Dim strRec As String
        mlog("[KEJUKJAW00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- fncEditSisinDec start strSisin=" & strSisin)
        If IsNumeric(strSisin) = True Then
            If strSisin.Length = 0 Then
                '20050729 NEC udpate START
                '                strRec = ""
                strRec = "0"
                '20050729 NEC udpate END
            ElseIf strSisin.Length = 1 Then
                strRec = "0." & strSisin
            Else
                strRec = strSisin
                strRec = Left(strRec, strRec.Length - 1) & "." & Right(strRec, 1)
            End If
        Else
            strRec = strSisin
        End If
        '20050729 NEC ADD START
        If IsNumeric(strRec) = False Then
            strRec = "0"
        End If
        '20050729 NEC ADD STOP
        mlog("[KEJUKJAW00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- fncEditSisinDec end strSisin=" & strSisin)

        Return CDec(strRec)
    End Function
    '2012/05/24 ADD START W.GANEKO
    '************************************************
    ' 対応テーブルの8時間内の重複チェック
    '************************************************
    Private Function getSqlDupTaiou(ByVal cdb As CDB, _
                                    ByVal pstrKANSCD As String, _
                                    ByVal pstrKMCD1 As String, _
                                    ByVal pstrKMNM1 As String, _
                                    ByVal pstrKMCD2 As String, _
                                    ByVal pstrKMNM2 As String, _
                                    ByVal pstrKMCD3 As String, _
                                    ByVal pstrKMNM3 As String, _
                                    ByVal pstrKMCD4 As String, _
                                    ByVal pstrKMNM4 As String, _
                                    ByVal pstrKMCD5 As String, _
                                    ByVal pstrKMNM5 As String, _
                                    ByVal pstrKMCD6 As String, _
                                    ByVal pstrKMNM6 As String, _
                                    ByVal pstrKURACD As String, _
                                    ByVal pstrJACD As String, _
                                    ByVal pstrACBCD As String, _
                                    ByVal pstrUSER_CD As String, _
                                    ByVal pstrHATYMD As String, _
                                    ByVal pstrHATTIME As String _
  ) As Boolean

        Dim strSQL As New StringBuilder("")
        Dim ds As DataSet
        mlog("[KEJUKJAW00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- getSqlDupTaiou start pstrKURACD=" & pstrKURACD & ",pstrJACD=" & pstrJACD & ",pstrACBCD=" & pstrACBCD & ",pstrUSER_CD=" & pstrUSER_CD & ",pstrHATYMD=" & pstrHATYMD & ",pstrHATTIME=" & pstrHATTIME)

        Dim strRslt As Boolean = False
        '8時間内に同一の対応データが存在するか確認
        strSQL.Append("SELECT ")
        strSQL.Append("    COUNT(KANSCD) AS CNT ")
        strSQL.Append("FROM ")
        strSQL.Append("    D20_TAIOU ")
        strSQL.Append("WHERE ")
        strSQL.Append("    KANSCD = :KANSCD ")
        '2015/12/24 T.Ono mod レスポンス改善 START
        strSQL.Append("AND TO_DATE(HATYMD||HATTIME,'YYYY/MM/DD HH24:MI:SS') BETWEEN ")
        strSQL.Append(" TO_DATE(:HATYMD||:HATTIME,'YYYY/MM/DD HH24:MI:SS')-8/24 AND ")
        strSQL.Append(" TO_DATE(:HATYMD||:HATTIME,'YYYY/MM/DD HH24:MI:SS') ")
        strSQL.Append("AND TAIOKBN <> '3' AND TKTANCD = '999' ")
        '2015/12/24 T.Ono mod レスポンス改善 END
        strSQL.Append("AND NVL(KMCD1,'NULL')  = NVL(:KMCD1,'NULL') ")
        strSQL.Append("AND NVL(KMNM1,'NULL')  = NVL(:KMNM1,'NULL') ")
        strSQL.Append("AND NVL(KMCD2,'NULL')  = NVL(:KMCD2,'NULL') ")
        strSQL.Append("AND NVL(KMNM2,'NULL')  = NVL(:KMNM2,'NULL') ")
        strSQL.Append("AND NVL(KMCD3,'NULL')  = NVL(:KMCD3,'NULL') ")
        strSQL.Append("AND NVL(KMNM3,'NULL')  = NVL(:KMNM3,'NULL') ")
        strSQL.Append("AND NVL(KMCD4,'NULL')  = NVL(:KMCD4,'NULL') ")
        strSQL.Append("AND NVL(KMNM4,'NULL')  = NVL(:KMNM4,'NULL') ")
        strSQL.Append("AND NVL(KMCD5,'NULL')  = NVL(:KMCD5,'NULL') ")
        strSQL.Append("AND NVL(KMNM5,'NULL')  = NVL(:KMNM5,'NULL') ")
        strSQL.Append("AND NVL(KMCD6,'NULL')  = NVL(:KMCD6,'NULL') ")
        strSQL.Append("AND NVL(KMNM6,'NULL')  = NVL(:KMNM6,'NULL') ")
        strSQL.Append("AND NVL(KURACD,'NULL') = NVL(:KURACD,'NULL') ")
        strSQL.Append("AND NVL(JACD,'NULL')   = NVL(:JACD,'NULL') ")
        strSQL.Append("AND NVL(ACBCD,'NULL')  = NVL(:ACBCD,'NULL') ")
        strSQL.Append("AND NVL(USER_CD,'NULL') = NVL(:USER_CD,'NULL') ")
        '2015/12/24 T.Ono mod レスポンス改善 START
        'strSQL.Append("AND TO_DATE(HATYMD||HATTIME,'YYYY/MM/DD HH24:MI:SS') BETWEEN ")
        'strSQL.Append(" TO_DATE(:HATYMD||:HATTIME,'YYYY/MM/DD HH24:MI:SS')-8/24 AND ")
        'strSQL.Append(" TO_DATE(:HATYMD||:HATTIME,'YYYY/MM/DD HH24:MI:SS') ")
        'strSQL.Append("AND TAIOKBN <> '3' AND TKTANCD = '999' ")
        '2015/12/24 T.Ono mod レスポンス改善 END
        'SQL文セット
        cdb.pSQL = strSQL.ToString
        'パラメータに値をセット
        cdb.pSQLParamStr("KANSCD") = pstrKANSCD
        cdb.pSQLParamStr("KMCD1") = pstrKMCD1
        cdb.pSQLParamStr("KMNM1") = pstrKMNM1
        cdb.pSQLParamStr("KMCD2") = pstrKMCD2
        cdb.pSQLParamStr("KMNM2") = pstrKMNM2
        cdb.pSQLParamStr("KMCD3") = pstrKMCD3
        cdb.pSQLParamStr("KMNM3") = pstrKMNM3
        cdb.pSQLParamStr("KMCD4") = pstrKMCD4
        cdb.pSQLParamStr("KMNM4") = pstrKMNM4
        cdb.pSQLParamStr("KMCD5") = pstrKMCD5
        cdb.pSQLParamStr("KMNM5") = pstrKMNM5
        cdb.pSQLParamStr("KMCD6") = pstrKMCD6
        cdb.pSQLParamStr("KMNM6") = pstrKMNM6
        cdb.pSQLParamStr("KURACD") = pstrKURACD
        cdb.pSQLParamStr("JACD") = pstrJACD
        cdb.pSQLParamStr("ACBCD") = pstrACBCD
        cdb.pSQLParamStr("USER_CD") = pstrUSER_CD
        cdb.pSQLParamStr("HATYMD") = pstrHATYMD
        cdb.pSQLParamStr("HATTIME") = pstrHATTIME

        'SQL実行
        cdb.mExecQuery()
        'データセットに値を格納
        ds = cdb.pResult
        If Convert.ToInt16(ds.Tables(0).Rows(0).Item("CNT")) <> 0 Then
            strRslt = True
        End If
        mlog("[KEJUKJAW00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- getSqlDupTaiou end pstrKURACD=" & pstrKURACD & ",pstrJACD=" & pstrJACD & ",pstrACBCD=" & pstrACBCD & ",pstrUSER_CD=" & pstrUSER_CD & ",pstrHATYMD=" & pstrHATYMD & ",pstrHATTIME=" & pstrHATTIME)

        Return strRslt
    End Function
    '2012/06/28 ADD START W.GANEKO
    '************************************************
    ' 警報データが自動対応中のデータがあるか確認
    '************************************************
    Private Function getKeihoDupTaiou(ByVal cdb As CDB, _
                                    ByVal pstrSERIAL As String _
  ) As Boolean

        Dim strSQL As New StringBuilder("")
        Dim ds As DataSet
        mlog("[KEJUKJAW00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- getKeihoDupTaiou start pstrSERIAL=" & pstrSERIAL)

        Dim strRslt As Boolean = False
        '自動対応中の警報が存在するか確認
        strSQL.Append("SELECT ")
        strSQL.Append("    COUNT(SYORI_SERIAL) AS CNT ")
        strSQL.Append("FROM ")
        strSQL.Append("    T10_KEIHO ")
        strSQL.Append("WHERE ")
        strSQL.Append(" SYORI_SERIAL = :SYORI_SERIAL ")
        strSQL.Append("AND REACTION = '9' ")
        'SQL文セット
        cdb.pSQL = strSQL.ToString
        'パラメータに値をセット
        cdb.pSQLParamStr("SYORI_SERIAL") = pstrSERIAL
        'SQL実行
        cdb.mExecQuery()
        'データセットに値を格納
        ds = cdb.pResult
        If Convert.ToInt16(ds.Tables(0).Rows(0).Item("CNT")) <> 0 Then
            strRslt = True
        End If
        mlog("[KEJUKJAW00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- getKeihoDupTaiou end pstrSERIAL=" & pstrSERIAL)

        Return strRslt
    End Function
    '2012/06/28 ADD START W.GANEKO
    '************************************************
    'パラメータ処理番号データの自動対応中にします
    '************************************************
    Private Function mSet_AutoFlg(ByVal pstrSERIAL As String) As String
        Dim ds As New DataSet
        Dim cdb As New CDB
        Dim strRes As String
        Dim strSQL As StringBuilder

        strRes = "OK"
        mlog("[KEJUKJAW00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- mSet_AutoFlg start pstrSERIAL=" & pstrSERIAL)
        '------------------------------------------------
        '接続OPEN----------------------------------------
        Try
            cdb.mOpen()
        Catch ex As Exception
            strRes = ex.ToString
            Return strRes
        Finally

        End Try

        Try
            '------------------------------------------------
            'トランザクション開始--------------------------
            cdb.mBeginTrans()

            '*********************************
            '処理ストーリー
            '[1]既に対応済みかのチェックを行う(Reaction)
            '*********************************

            '------------------------------------------------
            'ＤＢ更新（ロック解除）
            '------------------------------------------------
            strSQL = New StringBuilder("")
            strSQL.Append("")
            strSQL.Append("UPDATE ")
            strSQL.Append("T10_KEIHO ")
            strSQL.Append("SET REACTION = '9' ")
            strSQL.Append("WHERE ")
            strSQL.Append(" SYORI_SERIAL = :SYORI_SERIAL ") '処理番号
            strSQL.Append("AND REACTION = '0' ")

            'SQL文セット
            cdb.pSQL = strSQL.ToString
            'パラメータセット
            cdb.pSQLParamStr("SYORI_SERIAL") = pstrSERIAL              '処理番号
            'SQLを実行
            cdb.mExecNonQuery()
            Dim updcnt As Integer
            updcnt = cdb.pAffectedRows()
            'コミット
            cdb.mCommit()
            If updcnt = 0 Then
                strRes = "NG"
            End If
        Catch ex As Exception
            'エラーが起きたら エラー内容を格納
            strRes = ex.ToString
            'ロールバック
            cdb.mRollback()
            strRes = "NG"
        Finally
            '接続クローズ
            cdb.mClose()
        End Try

        cdb = Nothing
        mlog("[KEJUKJAW00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- mSet_AutoFlg end pstrSERIAL=" & pstrSERIAL)

        Return strRes
    End Function

    '**********************************************************
    ' 2013/08/07 T.Ono
    'FAX不要区分(JA・ｸﾗｲｱﾝﾄ)取得
    '**********************************************************
    Private Function fncGetFAXKBN(ByVal cdb As CDB, ByVal pstrSERIAL As String) As String()

        Dim strSQL As New StringBuilder("")
        Dim ds As DataSet
        Dim strRes(1) As String ' FAXKBN,FAXKURAKBN格納用
        mlog("[KEJUKJAW00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- fncGetFAXKBN start pstrSERIAL=" & pstrSERIAL)

        For i As Integer = 0 To 1
            strRes(i) = ""
        Next

        strSQL = New StringBuilder("")
        '2016/02/23 T.Ono mod 2015改善開発 ��7 START
        '取得先マスタ変更のため、SQL変更
        'strSQL.Append("WITH ")
        'strSQL.Append("/* お客様個別 */ ")
        'strSQL.Append("A AS ( ")
        'strSQL.Append("SELECT T.KURACD, T.CODE, T.USER_CD_FROM, T.FAXKBN, T.FAXKURAKBN, T.GUIDELINE ")
        'strSQL.Append("FROM   T10_KEIHO KEI, ")
        'strSQL.Append("       M05_TANTO2 T ")
        'strSQL.Append("WHERE  KEI.SYORI_SERIAL = :SYORI_SERIAL ")
        'strSQL.Append("AND    T.KBN = '3' ")
        'strSQL.Append("AND    KEI.KURACD = T.KURACD ")
        'strSQL.Append("AND    KEI.ACBCD = T.CODE ")
        'strSQL.Append("AND    LPAD(T.TANCD, 2, '0') = '01' ")
        'strSQL.Append("AND    T.USER_CD_TO IS NULL ")
        'strSQL.Append("AND    KEI.JUYOKA = T.USER_CD_FROM ")
        'strSQL.Append("), ")
        'strSQL.Append("/* お客様範囲 */ ")
        'strSQL.Append("B AS ( ")
        'strSQL.Append("SELECT T.KURACD, T.CODE, T.USER_CD_FROM, T.FAXKBN, T.FAXKURAKBN, T.GUIDELINE ")
        'strSQL.Append("FROM   T10_KEIHO KEI, ")
        'strSQL.Append("       M05_TANTO2 T ")
        'strSQL.Append("WHERE  KEI.SYORI_SERIAL = :SYORI_SERIAL ")
        'strSQL.Append("AND    T.KBN = '3' ")
        'strSQL.Append("AND    KEI.KURACD = T.KURACD ")
        'strSQL.Append("AND    KEI.ACBCD = T.CODE ")
        'strSQL.Append("AND    LPAD(T.TANCD, 2, '0') = '01' ")
        'strSQL.Append("AND    T.USER_CD_TO IS NOT NULL ")
        'strSQL.Append("AND    KEI.JUYOKA BETWEEN T.USER_CD_FROM AND T.USER_CD_TO ")
        'strSQL.Append("), ")
        'strSQL.Append("/* JA支所 */ ")
        'strSQL.Append("C AS( ")
        'strSQL.Append("SELECT T.KURACD, T.CODE, T.FAXKBN, T.FAXKURAKBN, T.GUIDELINE ")
        'strSQL.Append("FROM   T10_KEIHO KEI, ")
        'strSQL.Append("       M05_TANTO T ")
        'strSQL.Append("WHERE  KEI.SYORI_SERIAL = :SYORI_SERIAL ")
        'strSQL.Append("AND    T.KBN = '3' ")
        'strSQL.Append("AND    KEI.KURACD = T.KURACD ")
        'strSQL.Append("AND    KEI.ACBCD = T.CODE ")
        'strSQL.Append("AND    LPAD(T.TANCD, 2, '0') = '01' ")
        'strSQL.Append("), ")
        'strSQL.Append("/* JA3ケタ */ ")
        'strSQL.Append("D AS( ")
        'strSQL.Append("SELECT T.KURACD, T.CODE, T.FAXKBN, T.FAXKURAKBN, T.GUIDELINE ")
        'strSQL.Append("FROM   T10_KEIHO KEI, ")
        'strSQL.Append("       M05_TANTO T, ")
        'strSQL.Append("       HN2MAS H ")
        'strSQL.Append("WHERE  KEI.SYORI_SERIAL = :SYORI_SERIAL ")
        'strSQL.Append("AND    T.KBN = '3' ")
        'strSQL.Append("AND    KEI.KURACD = T.KURACD ")
        'strSQL.Append("AND    H.CLI_CD = T.KURACD ")
        'strSQL.Append("AND    T.CODE = H.JA_CD ")
        'strSQL.Append("AND    KEI.KURACD = H.CLI_CD ")
        'strSQL.Append("AND    KEI.ACBCD  = H.HAN_CD ")
        'strSQL.Append("AND    LPAD(T.TANCD, 2, '0') = '01'  ")
        'strSQL.Append("), ")
        'strSQL.Append("/* DUMMY */ ")
        'strSQL.Append("E AS( ")
        'strSQL.Append("SELECT KEI.KURACD ")
        'strSQL.Append("FROM   T10_KEIHO KEI ")
        'strSQL.Append("WHERE  KEI.SYORI_SERIAL = :SYORI_SERIAL  ")
        'strSQL.Append(") ")
        'strSQL.Append("SELECT NVL(A.FAXKBN, NVL(B.FAXKBN, NVL(C.FAXKBN, NVL(D.FAXKBN, '0')))) AS FAXKBN , ")
        'strSQL.Append("       NVL(A.FAXKURAKBN, NVL(B.FAXKURAKBN, NVL(C.FAXKURAKBN, NVL(D.FAXKURAKBN, '0')))) AS FAXKURAKBN ")
        'strSQL.Append("FROM A, B, C, D, E ")
        'strSQL.Append("WHERE 	E.KURACD = D.KURACD(+) ")
        'strSQL.Append("AND	E.KURACD = C.KURACD(+) ")
        'strSQL.Append("AND	E.KURACD = B.KURACD(+) ")
        'strSQL.Append("AND	E.KURACD = A.KURACD(+) ")

        strSQL.Append("WITH ")
        strSQL.Append("/* お客様個別 */ ")
        strSQL.Append("A AS ( ")
        strSQL.Append("SELECT KEI.KURACD, HOK.GROUPCD, HOK.FAXKBN, HOK.FAXKURAKBN ")
        strSQL.Append("FROM   T10_KEIHO KEI, ")
        strSQL.Append("       M09_JAGROUP GRP, ")
        strSQL.Append("       M11_JAHOKOKU HOK ")
        strSQL.Append("WHERE  KEI.SYORI_SERIAL = :SYORI_SERIAL ")
        strSQL.Append("AND    GRP.KBN = '002' ")
        strSQL.Append("AND    KEI.KURACD = GRP.KURACD ")
        strSQL.Append("AND    KEI.ACBCD = GRP.ACBCD ")
        strSQL.Append("AND    GRP.USERCD_TO IS NULL ")
        strSQL.Append("AND    KEI.JUYOKA = GRP.USERCD_FROM ")
        strSQL.Append("AND    HOK.KBN = '2' ")
        strSQL.Append("AND    GRP.GROUPCD = HOK.GROUPCD ")
        strSQL.Append("AND    LPAD(HOK.TANCD, 2, '0') = '01' ")
        strSQL.Append("), ")
        strSQL.Append("/* お客様範囲 */ ")
        strSQL.Append("B AS ( ")
        strSQL.Append("SELECT KEI.KURACD, HOK.GROUPCD, HOK.FAXKBN, HOK.FAXKURAKBN ")
        strSQL.Append("FROM   T10_KEIHO KEI, ")
        strSQL.Append("       M09_JAGROUP GRP, ")
        strSQL.Append("       M11_JAHOKOKU HOK ")
        strSQL.Append("WHERE  KEI.SYORI_SERIAL = :SYORI_SERIAL ")
        strSQL.Append("AND    GRP.KBN = '002' ")
        strSQL.Append("AND    KEI.KURACD = GRP.KURACD ")
        strSQL.Append("AND    KEI.ACBCD = GRP.ACBCD ")
        strSQL.Append("AND    GRP.USERCD_TO IS NOT NULL ")
        strSQL.Append("AND    KEI.JUYOKA BETWEEN GRP.USERCD_FROM AND GRP.USERCD_TO ")
        strSQL.Append("AND    HOK.KBN = '2' ")
        strSQL.Append("AND    GRP.GROUPCD = HOK.GROUPCD ")
        strSQL.Append("AND    LPAD(HOK.TANCD, 2, '0') = '01' ")
        strSQL.Append("), ")
        strSQL.Append("/* JA支所 */ ")
        strSQL.Append("C AS( ")
        strSQL.Append("SELECT KEI.KURACD, HOK.GROUPCD, HOK.FAXKBN, HOK.FAXKURAKBN ")
        strSQL.Append("FROM   T10_KEIHO KEI, ")
        strSQL.Append("       M09_JAGROUP GRP, ")
        strSQL.Append("       M11_JAHOKOKU HOK ")
        strSQL.Append("WHERE  KEI.SYORI_SERIAL = :SYORI_SERIAL ")
        strSQL.Append("AND    GRP.KBN = '002' ")
        strSQL.Append("AND    KEI.KURACD = GRP.KURACD ")
        strSQL.Append("AND    KEI.ACBCD = GRP.ACBCD ")
        strSQL.Append("AND    GRP.USERCD_TO IS NULL ")
        strSQL.Append("AND    GRP.USERCD_FROM IS NULL ")
        strSQL.Append("AND    HOK.KBN = '2' ")
        strSQL.Append("AND    GRP.GROUPCD = HOK.GROUPCD ")
        strSQL.Append("AND    LPAD(HOK.TANCD, 2, '0') = '01' ")
        strSQL.Append("), ")
        strSQL.Append("/* DUMMY */ ")
        strSQL.Append("X AS( ")
        strSQL.Append("SELECT KEI.KURACD ")
        strSQL.Append("FROM   T10_KEIHO KEI ")
        strSQL.Append("WHERE  KEI.SYORI_SERIAL = :SYORI_SERIAL ")
        strSQL.Append(") ")
        strSQL.Append("SELECT NVL(A.FAXKBN, NVL(B.FAXKBN, NVL(C.FAXKBN, '0'))) AS FAXKBN , ")
        strSQL.Append("       NVL(A.FAXKURAKBN, NVL(B.FAXKURAKBN, NVL(C.FAXKURAKBN, '0'))) AS FAXKURAKBN ")
        strSQL.Append("FROM A, B, C, X ")
        strSQL.Append("WHERE 	X.KURACD = C.KURACD(+) ")
        strSQL.Append("AND	    X.KURACD = B.KURACD(+) ")
        strSQL.Append("AND	    X.KURACD = A.KURACD(+) ")
        '2016/02/23 T.Ono mod 2015改善開発 ��7 END

        'SQL文セット
        cdb.pSQL = strSQL.ToString
        'パラメータのセット
        cdb.pSQLParamStr("SYORI_SERIAL") = pstrSERIAL
        'SQL実行
        cdb.mExecQuery()
        'データセットに値を格納
        ds = cdb.pResult
        strRes(0) = Convert.ToString(ds.Tables(0).Rows(0).Item("FAXKBN"))
        strRes(1) = Convert.ToString(ds.Tables(0).Rows(0).Item("FAXKURAKBN"))
        mlog("[KEJUKJAW00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- fncGetFAXKBN end pstrSERIAL=" & pstrSERIAL)

        Return strRes
    End Function
    '**********************************************************
    ' 2012/06/28 ADD W.GANEKO
    'ログ吐き出し
    '戻り値：書き込んだファイルへのフルパス
    '**********************************************************
    Public Sub mlog(ByVal pstrString As String)
        Dim strFilnm As String = "log" & System.DateTime.Today.ToString("yyyyMMdd")
        Dim strLogPath As String = ConfigurationSettings.AppSettings("LOG_OUT_PATH")
        Dim strPath As String = strLogPath & strFilnm & ".txt"
        Dim strLogFlg As String = ConfigurationSettings.AppSettings("LOG_OUT")
        Dim linestring As New StringBuilder("")

        Dim strRecLog As String
        If strLogFlg = "1" Then
            '書き込みファイルへのストリーム
            'Dim sw As StreamWriter
            'Dim fs As New FileStream(strPath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite)
            'linestring = New StringBuilder("")
            'linestring.Append(System.DateTime.Now & "." & System.DateTime.Now.Millisecond & "[]" & pstrString & Chr(13) & Chr(10))
            ''strRecLog = LogC.mAPLog(Me.Session.SessionID, "system", "127.0.0.1", "KEJUKJAW00", "4", tbllog, "")
            'sw = New StreamWriter(fs, System.Text.Encoding.Default)

            ''引数の文字列をストリームに書き込み
            'sw.Write(linestring.ToString)

            ''メモリフラッシュ（ファイル書き込み）
            ''sw.Flush()

            ''ファイルクローズ
            'sw.Close()
            'sw.Dispose()
            'fs.Close()
            'fs.Dispose()
            Dim tbllog As String = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff") & " " & pstrString

            Dim cdb As New CDB
            Dim dr As DataRow
            Dim strSQL As New StringBuilder("")


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
                cdb.pSQLParamStr("SESSION_ID") = "KEJUKJAW00"
                cdb.pSQLParamStr("LOGINCD") = "SYSTEM"
                cdb.pSQLParamStr("IPADR") = "SYSTEM"
                cdb.pSQLParamStr("PROC_ID") = "KEJUKJAW00"
                cdb.pSQLParamStr("EXEC_STATUS") = "4"
                cdb.pSQLParamStr("TEXT") = tbllog
                cdb.pSQLParamStr("MSG") = tbllog
                cdb.pSQLParamStr("ADD_DATE") = Format(Now, "yyyyMMdd")      '作成日
                cdb.pSQLParamStr("TIME") = Format(Now, "HHmmss")      '作成時間

                cdb.mExecNonQuery()
                cdb.mCommit()
            Catch

                cdb.mRollback()
            Finally
                'DBクローズ
                cdb.mClose()
            End Try
        End If
    End Sub
End Class
