'***********************************************
'受信警報表示パネル  データ制御
'***********************************************
' 2010/03/05 T.Watabe 重複の際に音がなる件の対応
' 2010/03/05 T.Watabe シリアルが最新でないデータが来た場合に音がならない件の対応
' 2012/01/31 T.Watabe edit 一時的に自動対応を停止
' 2012/03/30 W.GANEKO 自動対応解除
' 2014/10/17 H.HOSODA 重複警報の処理済更新〜自動対応までのデータ抽出条件に処理番号を追加
' 2021/10/01 Saka 2021年度監視改善�B監視対応中のデータは自動対応処理で落とさない(感震器遮断の自動対応有効化は、地震などの直後に設定することに対する改善)
' 2021/10/01 Saka 2021年度監視改善�Cの、1時間前あるいは1日前に同一顧客から警報が発生していたら色を変えるという改善について、結局改善しないとなったため、ロジックが残っている(いつか復活する？)

Option Explicit On
Option Strict On

Imports Common
Imports Common.DB   '2017/05/30 w.ganeko mod
Imports JPG.Common
Imports JPG.Common.log
Imports System.Text
Imports System.IO
Imports System.Diagnostics

Partial Class KEJUKJKG00
    Inherits System.Web.UI.Page

    Private intDataCount As Long            'テーブル内データ総数
    Private intNoReactionCoun As Integer    '対応済みでないデータ数
    Private intDoReactionCoun As Integer    '未対応のデータ数(対応済みでなくてロックされていないデータ)
    Private intTargetRownum As Integer      '出力範囲データ位置(Rownum)
    Private intTaiTmskbCount As Integer     '対応入力済みの未処理件数
    'Private strSYORI_SERIAL(2) As String    '処理�� 2013/12/18 T.Ono add 監視改善 表示中の警報の処理��
    Private strSYORI_SERIAL(5) As String    '処理�� 2019/11/01 w.ganeko mod 2019監視改善 No 3,4

    Private gstrCenter As String = ""       '取得可能な監視センターコードSQL用をセットする
    '<TODO>宣言共通仕様
    '******************************************************************************
    ' HttpHeader
    '******************************************************************************
    Protected HttpHeaderC As New CHttpHeader

    '<TODO>宣言共通仕様
    '******************************************************************************
    ' 認証クラス
    '******************************************************************************
    Protected AuthC As CAuthenticate

    '<TODO>宣言共通仕様
    '******************************************************************************
    ' ScriptMessage
    '******************************************************************************
    Private strMsg As New StringBuilder("")      '//<script>は必要なし

    '<TODO>宣言共通仕様
    '******************************************************************************
    ' Render
    '******************************************************************************
    Protected Overrides Sub Render(ByVal writer As HtmlTextWriter)
        MyBase.Render(writer)

        Dim strWrite As New StringBuilder("")

        strWrite.Append("<script language='JavaScript'>")
        strWrite.Append(strMsg.ToString())
        strWrite.Append("</script>")
        writer.Write(strWrite.ToString())
    End Sub

#Region " Web フォーム デザイナで生成されたコード "

    'この呼び出しは Web フォーム デザイナで必要です。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    'メモ : 次のプレースホルダ宣言は Web フォーム デザイナで必要です。
    '削除および移動しないでください。
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        ' CODEGEN: このメソッド呼び出しは Web フォーム デザイナで必要です。
        ' コード エディタを使って変更しないでください。
        InitializeComponent()
    End Sub

#End Region

    '******************************************************************************
    ' Page_Load
    '******************************************************************************
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '//------------------------------------------
        '//　HTTPヘッダを送信
        HttpHeaderC.mNoCache(Response)

        '//------------------------------------------
        '//　認証クラスのインスタンス生成
        AuthC = New CAuthenticate(Request, Response)
        mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load start")

        '//------------------------------------------
        Dim i As Integer
        Dim arrTemp() As String
        arrTemp = AuthC.pAUTHCENTERCD.Split(Convert.ToChar(","))
        For i = 0 To arrTemp.Length - 1
            If gstrCenter.Length > 0 Then
                gstrCenter = gstrCenter & ","
            End If
            gstrCenter = gstrCenter & "'" & arrTemp(i) & "'"
        Next

        Dim KEJUKJAG00C As KEJUKJAG00
        KEJUKJAG00C = CType(Context.Handler, KEJUKJAG00)

        'Dim SQLC As New KEJUKJAG00CCSQL.CSQL
        'Dim SqlParamC As New CSQLParam
        Dim strSQL As String
        Dim dbData As DataSet

        Dim strRec As String
        Dim strRecLog As String

        Dim LogC As New CLog
        Dim cdb As New CDB               '2017/05/30 w.ganeko add

        Dim intRow As Integer            '2013/12/18 T.Ono add 監視改善2013
        Dim intTmpRownom As Integer      '2013/12/18 T.Ono add 監視改善2013
        Dim strTmpSyori_Serial As String '2013/12/18 T.Ono add 監視改善2013

        Dim strMaxSyori_Serial As String '2014/10/17 H.Hosda add 監視改善2014

        Try
            strMsg.Append("with(parent.Data) {")
            '//(垂れ流し時のみ)処理が実行されているので警報エラーメッセージを消す(出力されていた場合のみ)
            'If KEJUKJAG00C.pCtlFlg = "KEJUKEI" Then
            strMsg.Append("fncMessage_delete();")
            'End If
            '//最新表示ボタン/欠損一覧ボタンを使用可能
            strMsg.Append("Form1.btnRenew.disabled = false;")
            strMsg.Append("Form1.btnKeson.disabled = false;")
            strMsg.Append("Form1.btnTanto.disabled = false;") '2015/11/02 w.ganeko 2015改善開発��9
            strMsg.Append("}")

            '-------------------------------
            ' 処理番号の最大値を取得 2014/10/17 H.Hosoda add
            '-------------------------------
            '2017/05/30 w.ganeko mod start
            cdb.mOpen()                                                   '2017/05/30 w.ganeko add
            strSQL = fncGetMaxSyoriSerial()                               '2017/05/30 w.ganeko add
            cdb.pSQL = strSQL.ToString                                    '2017/05/30 w.ganeko add
            cdb.mExecQuery()                                              '2017/05/30 w.ganeko add
            dbData = cdb.pResult    '結果をデータセットに格納             '2017/05/30 w.ganeko add
            cdb.mClose()                                                  '2017/05/30 w.ganeko add
            cdb = Nothing                                                 '2017/05/30 w.ganeko add 

            'strSQL = fncGetMaxSyoriSerial()
            'dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)
            '2017/05/30 w.ganeko mod end
            strMaxSyori_Serial = Convert.ToString(dbData.Tables(0).Rows(0).Item(0))

            '-------------------------------
            ' 重複警報の処理済更新 2009/09/09 T.Watabe add
            '-------------------------------
            '2014/10/17 H.Hosoda mod 処理Noを引数として設定
            'Call fncUpdateDuplicateKeiho()
            mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load fncUpdateDuplicateKeiho start strMaxSyori_Serial=" & strMaxSyori_Serial)

            Call fncUpdateDuplicateKeiho(strMaxSyori_Serial)

            mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load fncUpdateDuplicateKeiho end strMaxSyori_Serial=" & strMaxSyori_Serial)

            '-------------------------------
            ' 警報の自動対応処理登録 2011/12/05 H.Uema add
            '-------------------------------
            '2014/10/17 H.Hosoda mod 処理Noを引数として設定
            'Call fncAutoInsKeiho() '2012/01/31 T.Watabe edit 一時的に自動対応を停止
            mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load fncAutoInsKeiho start strMaxSyori_Serial=" & strMaxSyori_Serial)

            Call fncAutoInsKeiho(strMaxSyori_Serial)

            mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load fncAutoInsKeiho end strMaxSyori_Serial=" & strMaxSyori_Serial)

            '//ＤＢ内データ数の取得
            '2014/10/17 H.Hosoda mod 処理Noを引数として設定
            'intDataCount = fncDataCount()
            mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load fncDataCount start strMaxSyori_Serial=" & strMaxSyori_Serial)

            intDataCount = fncDataCount(strMaxSyori_Serial)

            mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load fncDataCount end strMaxSyori_Serial=" & strMaxSyori_Serial)
            '//未処理件数の取得：REACTION＝0のデータが対象
            '2014/10/17 H.Hosoda mod 処理Noを引数として設定
            'intNoReactionCoun = fncNoReactionCount()
            mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load fncNoReactionCount start strMaxSyori_Serial=" & strMaxSyori_Serial)

            intNoReactionCoun = fncNoReactionCount(strMaxSyori_Serial)

            mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load fncNoReactionCount end strMaxSyori_Serial=" & strMaxSyori_Serial)
            '//未処理件数の取得：REACTION＝0でROC_FRG IS NULLのデータが対象 (未処理のみ)
            '2014/10/17 H.Hosoda mod 処理Noを引数として設定
            'intDoReactionCoun = fncDoReactionCount()
            mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load fncDoReactionCount start strMaxSyori_Serial=" & strMaxSyori_Serial)

            intDoReactionCoun = fncDoReactionCount(strMaxSyori_Serial)

            mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load fncDoReactionCount end strMaxSyori_Serial=" & strMaxSyori_Serial)
            '//対応未処理件数の初期化
            intTaiTmskbCount = CInt(KEJUKJAG00C.pTaiTmskbCount)
            '//前回表示の一番古い警報の処理�� 2013/12/18 T.Ono add 監視改善2013
            '2019/11/01 w.ganeko 2019監視改善 No3,4
            If KEJUKJAG00C.pSYORI_SERIAL6 <> "" Then              '2019/11/01 w.ganeko 2019監視改善 No3,4
                strTmpSyori_Serial = KEJUKJAG00C.pSYORI_SERIAL6   '2019/11/01 w.ganeko 2019監視改善 No3,4
            ElseIf KEJUKJAG00C.pSYORI_SERIAL5 <> "" Then          '2019/11/01 w.ganeko 2019監視改善 No3,4
                strTmpSyori_Serial = KEJUKJAG00C.pSYORI_SERIAL5   '2019/11/01 w.ganeko 2019監視改善 No3,4
            ElseIf KEJUKJAG00C.pSYORI_SERIAL4 <> "" Then          '2019/11/01 w.ganeko 2019監視改善 No3,4
                strTmpSyori_Serial = KEJUKJAG00C.pSYORI_SERIAL4   '2019/11/01 w.ganeko 2019監視改善 No3,4
            ElseIf KEJUKJAG00C.pSYORI_SERIAL3 <> "" Then
                strTmpSyori_Serial = KEJUKJAG00C.pSYORI_SERIAL3
            ElseIf KEJUKJAG00C.pSYORI_SERIAL2 <> "" Then
                strTmpSyori_Serial = KEJUKJAG00C.pSYORI_SERIAL2
            ElseIf KEJUKJAG00C.pSYORI_SERIAL1 <> "" Then
                strTmpSyori_Serial = KEJUKJAG00C.pSYORI_SERIAL1
            Else
                strTmpSyori_Serial = ""
            End If

            Dim bolKei As Boolean = False
            mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load KEJUKJAG00C.pExecFlag=" & KEJUKJAG00C.pExecFlag)

            Select Case KEJUKJAG00C.pExecFlag
                Case "DATACHECK"
                    ''-------------------------------
                    '//監視用：N秒後毎の警報監視チェックです
                    '//
                    '//
                    If CLng(KEJUKJAG00C.pDataCount) <> intDataCount Then
                        '//全データの件数が前回取得した全データの時の件数よりも多い場合は警報発生と認識します
                        If KEJUKJAG00C.pCtlFlg = "KEJUKEI" Then
                            '2012/06/28 W.GANEKO ADD
                            mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load DATACHECK|KEJUKEI|" & intDataCount & "|" & KEJUKJAG00C.pDataCount & "|" & gstrCenter & "|自動更新：" & KEJUKJAG00C.pChkJido)
                            '//----------------------------------
                            '//警報を出力します
                            strMsg.Append("parent.Data.fncAlert_output();")
                            bolKei = True
                            '//----------------------------------
                        Else
                            '//strMsg.Append("alert('新しい警報が発生しました');")
                        End If
                        '//制御ROWNUMを1にします
                        intTargetRownum = 1
                        '//データを検索します
                        '2014/10/17 H.Hosoda mod 処理Noを引数として設定
                        'strSQL = fncSelectSql(intTargetRownum)
                        mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load fncSelectSql 1 start strMaxSyori_Serial=" & strMaxSyori_Serial & "|自動更新：" & KEJUKJAG00C.pChkJido)
                        '2017/05/30 w.ganeko mod start
                        cdb = New CDB
                        cdb.mOpen()
                        strSQL = fncSelectSql(intTargetRownum, strMaxSyori_Serial)
                        cdb.pSQL = strSQL.ToString
                        cdb.mExecQuery()
                        dbData = cdb.pResult    '結果をデータセットに格納
                        cdb.mClose()
                        cdb = Nothing
                        'strSQL = fncSelectSql(intTargetRownum, strMaxSyori_Serial)
                        'dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)
                        '2017/05/30 w.ganeko mod end
                        '//データを出力します
                        mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load fncSelectSql 1 end strMaxSyori_Serial=" & strMaxSyori_Serial & "|自動更新：" & KEJUKJAG00C.pChkJido)
                        mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load fncDataSet start strMaxSyori_Serial=" & strMaxSyori_Serial & "|自動更新：" & KEJUKJAG00C.pChkJido)
                        Call fncDataSet(dbData, KEJUKJAG00C.pCtlFlg)
                        mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load fncDataSet end strMaxSyori_Serial=" & strMaxSyori_Serial & "|自動更新：" & KEJUKJAG00C.pChkJido)
                        '表示している警報の処理�ｂ�保存 2013/12/18 T.Ono add 監視改善2013
                        '2019/11/01 w.ganeko 2019監視改善 No3,4
                        'For intRow = 0 To 2
                        For intRow = 0 To 5
                            If intRow > dbData.Tables(0).Rows.Count - 1 Then
                                strSYORI_SERIAL(intRow) = ""
                            Else
                                strSYORI_SERIAL(intRow) = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("SYORI_SERIAL"))
                            End If
                        Next
                    ElseIf KEJUKJAG00C.pNoReactionCount <> intNoReactionCoun Or KEJUKJAG00C.pDoReactionCount <> intDoReactionCoun Then
                        ''''''ElseIf KEJUKJAG00C.pCount <> intNoReactionCoun Then
                        '//制御ROWNUMを1にします
                        intTargetRownum = 1
                        '//データを検索します
                        '2014/10/17 H.Hosoda mod 処理Noを引数として設定
                        'strSQL = fncSelectSql(intTargetRownum)
                        mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load fncSelectSql start 2 strMaxSyori_Serial=" & strMaxSyori_Serial & "|自動更新：" & KEJUKJAG00C.pChkJido)
                        '2017/05/30 w.ganeko mod start
                        cdb = New CDB
                        cdb.mOpen()
                        strSQL = fncSelectSql(intTargetRownum, strMaxSyori_Serial)
                        cdb.pSQL = strSQL.ToString
                        cdb.mExecQuery()
                        dbData = cdb.pResult    '結果をデータセットに格納
                        cdb.mClose()
                        cdb = Nothing
                        'strSQL = fncSelectSql(intTargetRownum, strMaxSyori_Serial)
                        'dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)
                        '2017/05/30 w.ganeko mod end
                        mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load fncSelectSql end 2 strMaxSyori_Serial=" & strMaxSyori_Serial & "|自動更新：" & KEJUKJAG00C.pChkJido)
                        '//データを出力します
                        mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load fncDataSet start 2 strMaxSyori_Serial=" & strMaxSyori_Serial & "|自動更新：" & KEJUKJAG00C.pChkJido)
                        Call fncDataSet(dbData, KEJUKJAG00C.pCtlFlg)
                        mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load fncDataSet end 2 strMaxSyori_Serial=" & strMaxSyori_Serial & "|自動更新：" & KEJUKJAG00C.pChkJido)
                        '表示している警報の処理�ｂ�保存 2013/12/18 T.Ono add 監視改善2013
                        '2019/11/01 w.ganeko 2019監視改善 No3,4
                        'For intRow = 0 To 2
                        For intRow = 0 To 5
                            If intRow > dbData.Tables(0).Rows.Count - 1 Then
                                strSYORI_SERIAL(intRow) = ""
                            Else
                                strSYORI_SERIAL(intRow) = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("SYORI_SERIAL"))
                            End If
                        Next
                    Else
                        '警報が発生していない場合は何もしません
                        intTargetRownum = CInt(KEJUKJAG00C.pRownum)
                        '表示している警報の処理�ｂ�保存 2013/12/18 T.Ono add 監視改善2013
                        strSYORI_SERIAL(0) = KEJUKJAG00C.pSYORI_SERIAL1
                        strSYORI_SERIAL(1) = KEJUKJAG00C.pSYORI_SERIAL2
                        strSYORI_SERIAL(2) = KEJUKJAG00C.pSYORI_SERIAL3
                        '2019/11/01 w.ganeko 2019監視改善 No3,4 start
                        strSYORI_SERIAL(3) = KEJUKJAG00C.pSYORI_SERIAL4
                        strSYORI_SERIAL(4) = KEJUKJAG00C.pSYORI_SERIAL5
                        strSYORI_SERIAL(5) = KEJUKJAG00C.pSYORI_SERIAL6
                        '2019/11/01 w.ganeko 2019監視改善 No3,4 end
                    End If

                Case "DATAROC"
                    '//-------------------------------
                    '//対応入力ボタンが押下されました
                    '//
                    '//(対応入力への遷移　メッセージの制御しか行いません)
                    '//指定の処理番号のデータのロックフラグとロック開始時間をNULLにする
                    '2014/01/20 T.Ono add 緊急対応ボタン押下をログ取得
                    mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load DATAROC|警報パネル_緊急対応ボタン押下|fncUpdateRoc start pSERIAL=" & KEJUKJAG00C.pSERIAL & "|自動更新：" & KEJUKJAG00C.pChkJido)
                    strRec = fncUpdateRoc(KEJUKJAG00C.pSERIAL)
                    mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load DATAROC|警報パネル_緊急対応ボタン押下|fncUpdateRoc end  pSERIAL=" & KEJUKJAG00C.pSERIAL & "|自動更新：" & KEJUKJAG00C.pChkJido)

                    Select Case strRec
                        Case "OK"
                            '//対応入力へ遷移します
                            strMsg.Append("parent.Data.fncMove_taijag();")
                            Return
                        Case "1"
                            '//既に対応済みになっております
                            strMsg.Append("alert('既に対応済みになっている為、対応入力は行えません');")
                            strMsg.Append("parent.Data.Form1.hdnBtmOukaFlg.value = '0';")                 '2014/01/20 T.Ono add
                            '2013/12/18 T.Ono mod 監視改善2013  START
                            'intTargetRownum = CInt(KEJUKJAG00C.pRownum)
                            If KEJUKJAG00C.pSERIAL = "" Then
                                intTargetRownum = 1
                            Else
                                mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load fncGetRownumSql start  pSERIAL=" & KEJUKJAG00C.pSERIAL & "|自動更新：" & KEJUKJAG00C.pChkJido)
                                '2017/05/30 w.ganeko mod start
                                cdb = New CDB
                                cdb.mOpen()
                                strSQL = fncGetRownumSql(KEJUKJAG00C.pSERIAL, 2)
                                cdb.pSQL = strSQL.ToString
                                cdb.mExecQuery()
                                dbData = cdb.pResult    '結果をデータセットに格納
                                cdb.mClose()
                                cdb = Nothing
                                'strSQL = fncGetRownumSql(KEJUKJAG00C.pSERIAL, 2)
                                'dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)
                                '2017/05/30 w.ganeko mod end

                                mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load fncGetRownumSql end  pSERIAL=" & KEJUKJAG00C.pSERIAL & "|自動更新：" & KEJUKJAG00C.pChkJido)
                                'ターゲットのRownumを取得
                                If dbData.Tables(0).Rows.Count = 0 Then                                 '2017/05/30 w.ganeko mod
                                    'If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then '2017/05/30 w.ganeko mod
                                    '表示中の処理�ａi画面上）または、より古い警報がなかった場合、最終ページに遷移
                                    If KEJUKJAG00C.pChkMishori = "1" Then
                                        '未処理のみにチェックあり
                                        '2019/11/01 w.ganeko 2019監視改善 No3,4 start
                                        'If intDoReactionCoun < 4 Then  
                                        '  intTargetRownum = 1
                                        'Else
                                        '   intTargetRownum = ((intDoReactionCoun - 1) \ 3) * 3 + 1
                                        'End If
                                        If intDoReactionCoun < 7 Then
                                            intTargetRownum = 1
                                        Else
                                            intTargetRownum = ((intDoReactionCoun - 1) \ 6) * 6 + 1
                                        End If
                                        '2019/11/01 w.ganeko 2019監視改善 No3,4 end
                                    Else
                                        '未処理のみにチェックなし
                                        '2019/11/01 w.ganeko 2019監視改善 No3,4 start
                                        'If intNoReactionCoun < 4 Then
                                        '    intTargetRownum = 1
                                        'Else
                                        '    intTargetRownum = ((intNoReactionCoun - 1) \ 3) * 3 + 1
                                        'End If
                                        If intNoReactionCoun < 7 Then
                                            intTargetRownum = 1
                                        Else
                                            intTargetRownum = ((intNoReactionCoun - 1) \ 6) * 6 + 1
                                        End If
                                        '2019/11/01 w.ganeko 2019監視改善 No3,4 end
                                    End If
                                Else
                                    intTmpRownom = CInt(dbData.Tables(0).Rows(0).Item("ROWNUMID"))
                                    'intTargetRownum = ((intTmpRownom - 1) \ 3) * 3 + 1 '2019/11/01 w.ganeko 2019監視改善 No3,4 
                                    intTargetRownum = ((intTmpRownom - 1) \ 6) * 6 + 1  '2019/11/01 w.ganeko 2019監視改善 No3,4 
                                End If
                            End If
                            '2013/12/18 T.Ono mod 監視改善2013  END
                            '//データを検索します
                            '2014/10/17 H.Hosoda mod 処理Noを引数として設定
                            'strSQL = fncSelectSql(intTargetRownum)
                            mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load fncSelectSql 3 start  strMaxSyori_Serial=" & strMaxSyori_Serial & "|自動更新：" & KEJUKJAG00C.pChkJido)
                            '2017/05/30 w.ganeko mod start
                            cdb = New CDB
                            cdb.mOpen()
                            strSQL = fncSelectSql(intTargetRownum, strMaxSyori_Serial)
                            cdb.pSQL = strSQL.ToString
                            cdb.mExecQuery()
                            dbData = cdb.pResult    '結果をデータセットに格納
                            cdb.mClose()
                            cdb = Nothing
                            'strSQL = fncSelectSql(intTargetRownum, strMaxSyori_Serial)
                            'dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)
                            '2017/05/30 w.ganeko mod end

                            mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load fncSelectSql 3 end  strMaxSyori_Serial=" & strMaxSyori_Serial & "|自動更新：" & KEJUKJAG00C.pChkJido)

                            '//データを出力します
                            mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load fncDataSet 3 start  strMaxSyori_Serial=" & strMaxSyori_Serial & "|自動更新：" & KEJUKJAG00C.pChkJido)
                            Call fncDataSet(dbData, KEJUKJAG00C.pCtlFlg)

                            mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load fncDataSet 3 end  strMaxSyori_Serial=" & strMaxSyori_Serial & "|自動更新：" & KEJUKJAG00C.pChkJido)
                            '表示している警報の処理�ｂ�保存 2013/12/18 T.Ono add 監視改善2013
                            '2019/11/01 w.ganeko 2019監視改善 No3,4
                            'For intRow = 0 To 2
                            For intRow = 0 To 5
                                If intRow > dbData.Tables(0).Rows.Count - 1 Then
                                    strSYORI_SERIAL(intRow) = ""
                                Else
                                    strSYORI_SERIAL(intRow) = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("SYORI_SERIAL"))
                                End If
                            Next
                        Case "2"
                                '//既に対応中になっております
                            strMsg.Append("alert('既に対応中になっている為、対応入力は行えません');")
                            strMsg.Append("parent.Data.Form1.hdnBtmOukaFlg.value = '0';")                 '2014/01/20 T.Ono add
                            '2013/12/18 T.Ono mod 監視改善2013  START
                            'intTargetRownum = CInt(KEJUKJAG00C.pRownum)
                            If KEJUKJAG00C.pSERIAL = "" Then
                                intTargetRownum = 1
                            Else
                                mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load fncGetRownumSql start KEJUKJAG00C.pSERIAL=" & KEJUKJAG00C.pSERIAL & "|自動更新：" & KEJUKJAG00C.pChkJido)
                                '2017/05/30 w.ganeko mod start
                                cdb = New CDB
                                cdb.mOpen()
                                strSQL = fncGetRownumSql(KEJUKJAG00C.pSERIAL, 1)
                                cdb.pSQL = strSQL.ToString
                                cdb.mExecQuery()
                                dbData = cdb.pResult    '結果をデータセットに格納
                                cdb.mClose()
                                cdb = Nothing
                                'strSQL = fncGetRownumSql(KEJUKJAG00C.pSERIAL, 1)
                                'dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)
                                '2017/05/30 w.ganeko mod end

                                mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load fncGetRownumSql end KEJUKJAG00C.pSERIAL=" & KEJUKJAG00C.pSERIAL & "|自動更新：" & KEJUKJAG00C.pChkJido)
                                'ターゲットのRownumを取得
                                If dbData.Tables(0).Rows.Count = 0 Then                                   '2017/05/30 w.ganeko mod
                                    'If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then   '2017/05/30 w.ganeko mod
                                    '表示中の処理�ａi画面上）または、より古い警報がなかった場合、最終ページに遷移
                                    If KEJUKJAG00C.pChkMishori = "1" Then
                                        '未処理のみにチェックあり
                                        '2019/11/01 w.ganeko 2019監視改善 No3,4 start
                                        'If intDoReactionCoun < 4 Then
                                        'intTargetRownum = 1
                                        'Else
                                        'intTargetRownum = ((intDoReactionCoun - 1) \ 3) * 3 + 1
                                        'End If
                                        If intDoReactionCoun < 7 Then
                                            intTargetRownum = 1
                                        Else
                                            intTargetRownum = ((intDoReactionCoun - 1) \ 6) * 6 + 1
                                        End If
                                    Else
                                        '未処理のみにチェックなし
                                        '2019/11/01 w.ganeko 2019監視改善 No3,4 start
                                        'If intNoReactionCoun < 4 Then
                                        'intTargetRownum = 1
                                        'Else
                                        'intTargetRownum = ((intNoReactionCoun - 1) \ 3) * 3 + 1
                                        'End If
                                        If intNoReactionCoun < 7 Then
                                            intTargetRownum = 1
                                        Else
                                            intTargetRownum = ((intNoReactionCoun - 1) \ 6) * 6 + 1
                                        End If
                                    End If
                                Else
                                    intTmpRownom = CInt(dbData.Tables(0).Rows(0).Item("ROWNUMID"))
                                    intTargetRownum = ((intTmpRownom - 1) \ 3) * 3 + 1
                                End If
                            End If
                            '2013/12/18 T.Ono mod 監視改善2013  END
                            '//データを検索します
                            '2014/10/17 H.Hosoda mod 処理Noを引数として設定
                            'strSQL = fncSelectSql(intTargetRownum)
                            mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load fncSelectSql start strMaxSyori_Serial=" & strMaxSyori_Serial & "|自動更新：" & KEJUKJAG00C.pChkJido)

                            '2017/05/30 w.ganeko mod start
                            cdb = New CDB
                            cdb.mOpen()
                            strSQL = fncSelectSql(intTargetRownum, strMaxSyori_Serial)
                            cdb.pSQL = strSQL.ToString
                            cdb.mExecQuery()
                            dbData = cdb.pResult    '結果をデータセットに格納
                            cdb.mClose()
                            cdb = Nothing
                            'strSQL = fncSelectSql(intTargetRownum, strMaxSyori_Serial)
                            'dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)
                            '2017/05/30 w.ganeko mod end

                            mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load fncSelectSql end strMaxSyori_Serial=" & strMaxSyori_Serial & "|自動更新：" & KEJUKJAG00C.pChkJido)
                            mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load fncDataSet start strMaxSyori_Serial=" & strMaxSyori_Serial & "|自動更新：" & KEJUKJAG00C.pChkJido)
                            '//データを出力します
                            Call fncDataSet(dbData, KEJUKJAG00C.pCtlFlg)

                            mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load fncDataSet end strMaxSyori_Serial=" & strMaxSyori_Serial & "|自動更新：" & KEJUKJAG00C.pChkJido)
                            '表示している警報の処理�ｂ�保存 2013/12/18 T.Ono add 監視改善2013
                            '2019/11/01 w.ganeko 2019監視改善 No3,4
                            'For intRow = 0 To 2
                            For intRow = 0 To 5
                                If intRow > dbData.Tables(0).Rows.Count - 1 Then
                                    strSYORI_SERIAL(intRow) = ""
                                Else
                                    strSYORI_SERIAL(intRow) = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("SYORI_SERIAL"))
                                End If
                            Next
                        Case Else
                            Dim ErrMsgC As New CErrMsg
                            strMsg.Append("alert('システムエラー：" & ErrMsgC.mGetArtMsg(strRec) & "');")
                            strMsg.Append("parent.Data.Form1.hdnBtmOukaFlg.value = '0';")                 '2014/01/20 T.Ono add
                            '2013/12/18 T.Ono mod 監視改善2013  START
                            'intTargetRownum = CInt(KEJUKJAG00C.pRownum)
                            If KEJUKJAG00C.pSERIAL = "" Then
                                intTargetRownum = 1
                            Else
                                '2017/05/30 w.ganeko mod start
                                cdb = New CDB
                                cdb.mOpen()
                                strSQL = fncGetRownumSql(KEJUKJAG00C.pSERIAL, 1)
                                cdb.pSQL = strSQL.ToString
                                cdb.mExecQuery()
                                dbData = cdb.pResult    '結果をデータセットに格納
                                cdb.mClose()
                                cdb = Nothing
                                'strSQL = fncGetRownumSql(KEJUKJAG00C.pSERIAL, 1)
                                'dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)
                                '2017/05/30 w.ganeko mod end

                                'ターゲットのRownumを取得
                                If dbData.Tables(0).Rows.Count = 0 Then                                   '2017/05/30 w.ganeko mod start
                                    'If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then   '2017/05/30 w.ganeko mod start 
                                    '表示中の処理�ａi画面上）または、より古い警報がなかった場合、最終ページに遷移
                                    If KEJUKJAG00C.pChkMishori = "1" Then
                                        '未処理のみにチェックあり
                                        '2019/11/01 w.ganeko 2019監視改善 No3,4 start
                                        'If intDoReactionCoun < 4 Then
                                        'intTargetRownum = 1
                                        'Else
                                        'intTargetRownum = ((intDoReactionCoun - 1) \ 3) * 3 + 1
                                        'End If
                                        If intDoReactionCoun < 7 Then
                                            intTargetRownum = 1
                                        Else
                                            intTargetRownum = ((intDoReactionCoun - 1) \ 6) * 6 + 1
                                        End If
                                        '2019/11/01 w.ganeko 2019監視改善 No3,4 end
                                    Else
                                        '未処理のみにチェックなし
                                        '2019/11/01 w.ganeko 2019監視改善 No3,4 start
                                        'If intNoReactionCoun < 4 Then
                                        'intTargetRownum = 1
                                        'Else
                                        'intTargetRownum = ((intNoReactionCoun - 1) \ 3) * 3 + 1
                                        'End If
                                        If intNoReactionCoun < 7 Then
                                            intTargetRownum = 1
                                        Else
                                            intTargetRownum = ((intNoReactionCoun - 1) \ 6) * 6 + 1
                                        End If
                                        '2019/11/01 w.ganeko 2019監視改善 No3,4 end
                                    End If
                                Else
                                    intTmpRownom = CInt(dbData.Tables(0).Rows(0).Item("ROWNUMID"))
                                    'intTargetRownum = ((intTmpRownom - 1) \ 3) * 3 + 1  '2019/11/01 w.ganeko 2019監視改善 No3,4
                                    intTargetRownum = ((intTmpRownom - 1) \ 3) * 3 + 1   '2019/11/01 w.ganeko 2019監視改善 No3,4
                                End If
                            End If
                            '2013/12/18 T.Ono mod 監視改善2013  END
                            '//データを検索します
                            '2014/10/17 H.Hosoda mod 処理Noを引数として設定
                            mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load fncSelectSql start strMaxSyori_Serial=" & strMaxSyori_Serial & "|自動更新：" & KEJUKJAG00C.pChkJido)
                            'strSQL = fncSelectSql(intTargetRownum)
                            '2017/05/30 w.ganeko mod start
                            cdb = New CDB
                            cdb.mOpen()
                            strSQL = fncSelectSql(intTargetRownum, strMaxSyori_Serial)
                            cdb.pSQL = strSQL.ToString
                            cdb.mExecQuery()
                            dbData = cdb.pResult    '結果をデータセットに格納
                            cdb.mClose()
                            cdb = Nothing
                            'strSQL = fncSelectSql(intTargetRownum, strMaxSyori_Serial)
                            'dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)
                            '2017/05/30 w.ganeko mod end

                            mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load fncSelectSql end strMaxSyori_Serial=" & strMaxSyori_Serial & "|自動更新：" & KEJUKJAG00C.pChkJido)
                            mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load fncDataSet start strMaxSyori_Serial=" & strMaxSyori_Serial & "|自動更新：" & KEJUKJAG00C.pChkJido)
                            '//データを出力します
                            Call fncDataSet(dbData, KEJUKJAG00C.pCtlFlg)
                            mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load fncDataSet end strMaxSyori_Serial=" & strMaxSyori_Serial & "|自動更新：" & KEJUKJAG00C.pChkJido)
                            '表示している警報の処理�ｂ�保存 2013/12/18 T.Ono add 監視改善2013
                            '2019/11/01 w.ganeko 2019監視改善 No3,4
                            'For intRow = 0 To 2
                            For intRow = 0 To 5
                                If intRow > dbData.Tables(0).Rows.Count - 1 Then
                                    strSYORI_SERIAL(intRow) = ""
                                Else
                                    strSYORI_SERIAL(intRow) = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("SYORI_SERIAL"))
                                End If
                            Next
                    End Select

                Case "DATANOROC"
                    '//-------------------------------
                    '//ロック解除ボタンが押下されました
                    '//
                    '//(ロック関連項目　メッセージの制御しか行いません)
                    '//指定の処理番号のデータのロックフラグとロック開始時間をNULLにする
                    mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load DATANOROC|fncUpdateNoRoc start pSERIAL=" & KEJUKJAG00C.pSERIAL)

                    strRec = fncUpdateNoRoc(KEJUKJAG00C.pSERIAL)
                    mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load DATANOROC|fncUpdateNoRoc end pSERIAL=" & KEJUKJAG00C.pSERIAL)
                    Select Case strRec
                        Case "OK"
                            '//対応入力ボタンにカーソルをセットする
                            strMsg.Append("with(parent.Data) {")
                            strMsg.Append("fncFo(Form1.btn" & CInt(KEJUKJAG00C.pINDEX) & "ROC, 5);")
                            strMsg.Append("Form1.btn" & CInt(KEJUKJAG00C.pINDEX) & "TAIOU.disabled = false;")
                            strMsg.Append("Form1.btn" & CInt(KEJUKJAG00C.pINDEX) & "TAIOU.focus();")
                            '//ロックの箇所のみNULLにします
                            strMsg.Append("Form1.txt" & CInt(KEJUKJAG00C.pINDEX) & "ROC.value = '未処理';")
                            strMsg.Append("Form1.txt" & CInt(KEJUKJAG00C.pINDEX) & "ROC.className = 'c-rNMB';")
                            ''''''strMsg.Append("Form1.txt" & CInt(KEJUKJAG00C.pINDEX) & "ROCTIME.value = '';")
                            '//ロック解除ボタンをDisabledにする
                            strMsg.Append("Form1.btn" & CInt(KEJUKJAG00C.pINDEX) & "ROC.disabled = true;")
                            strMsg.Append("}")
                        Case "1"
                            '//既に対応済みになっております
                            strMsg.Append("alert('既に対応済みになっている為、ロックは解除できません');")
                        Case Else
                            Dim ErrMsgC As New CErrMsg
                            strMsg.Append("alert('システムエラー：" & ErrMsgC.mGetArtMsg(strRec) & "');")
                    End Select
                    '2013/12/18 T.Ono mod 監視改善2013  START
                    'intTargetRownum = CInt(KEJUKJAG00C.pRownum)
                    If KEJUKJAG00C.pSERIAL = "" Then
                        intTargetRownum = 1
                    Else
                        mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load DATANOROC|fncGetRownumSql start pSERIAL=" & KEJUKJAG00C.pSERIAL)
                        '2017/05/30 w.ganeko mod start
                        cdb = New CDB
                        cdb.mOpen()
                        strSQL = fncGetRownumSql(KEJUKJAG00C.pSERIAL, 1)
                        cdb.pSQL = strSQL.ToString
                        cdb.mExecQuery()
                        dbData = cdb.pResult    '結果をデータセットに格納
                        cdb.mClose()
                        cdb = Nothing
                        'strSQL = fncGetRownumSql(KEJUKJAG00C.pSERIAL, 1)
                        'dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)
                        '2017/05/30 w.ganeko mod end

                        mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load DATANOROC|fncGetRownumSql end pSERIAL=" & KEJUKJAG00C.pSERIAL)
                        'ターゲットのRownumを取得
                        If dbData.Tables(0).Rows.Count = 0 Then                                    '2017/05/30 w.ganeko mod
                            'If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then    '2017/05/30 w.ganeko mod
                            '表示中の処理�ａi画面上）または、より古い警報がなかった場合、最終ページに遷移
                            '2019/11/01 w.ganeko 2019監視改善 No3,4 start
                            'If intNoReactionCoun < 4 Then
                            'intTargetRownum = 1
                            'Else
                            'intTargetRownum = ((intNoReactionCoun - 1) \ 3) * 3 + 1
                            'End If
                            If intNoReactionCoun < 7 Then
                                intTargetRownum = 1
                            Else
                                intTargetRownum = ((intNoReactionCoun - 1) \ 6) * 6 + 1
                            End If
                            '2019/11/01 w.ganeko 2019監視改善 No3,4 end
                        Else
                            intTmpRownom = CInt(dbData.Tables(0).Rows(0).Item("ROWNUMID"))
                            'intTargetRownum = ((intTmpRownom - 1) \ 3) * 3 + 1   '2019/11/01 w.ganeko 2019監視改善 No3,4
                            intTargetRownum = ((intTmpRownom - 1) \ 6) * 6 + 1    '2019/11/01 w.ganeko 2019監視改善 No3,4
                        End If
                    End If
                    '2013/12/18 T.Ono mod 監視改善2013  END
                    '//データを検索します
                    '2014/10/17 H.Hosoda mod 処理Noを引数として設定
                    'strSQL = fncSelectSql(intTargetRownum)
                    mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load fncSelectSql 4 start pSERIAL=" & KEJUKJAG00C.pSERIAL)

                    '2017/05/30 w.ganeko mod start
                    cdb = New CDB
                    cdb.mOpen()
                    strSQL = fncSelectSql(intTargetRownum, strMaxSyori_Serial)
                    cdb.pSQL = strSQL.ToString
                    cdb.mExecQuery()
                    dbData = cdb.pResult    '結果をデータセットに格納
                    cdb.mClose()
                    cdb = Nothing
                    'strSQL = fncSelectSql(intTargetRownum, strMaxSyori_Serial)
                    'dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)
                    '2017/05/30 w.ganeko mod end

                    '//データを出力します
                    mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load fncSelectSql 4 end pSERIAL=" & KEJUKJAG00C.pSERIAL)
                    mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load fncDataSet 4 start pSERIAL=" & KEJUKJAG00C.pSERIAL)
                    Call fncDataSet(dbData, KEJUKJAG00C.pCtlFlg)
                    mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load fncDataSet 4 end pSERIAL=" & KEJUKJAG00C.pSERIAL)
                    '表示している警報の処理�ｂ�保存 2013/12/18 T.Ono add 監視改善2013
                    '2019/11/01 w.ganeko 2019監視改善 No3,4
                    'For intRow = 0 To 2
                    For intRow = 0 To 5
                        If intRow > dbData.Tables(0).Rows.Count - 1 Then
                            strSYORI_SERIAL(intRow) = ""
                        Else
                            strSYORI_SERIAL(intRow) = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("SYORI_SERIAL"))
                        End If
                    Next

                Case "DATARENEW"
                    '//-------------------------------
                    '//最新の状態を出力します
                    '//
                    '//
                    '//制御ROWNUMを1にします
                    intTargetRownum = 1
                    If CLng(KEJUKJAG00C.pDataCount) <> intDataCount Then
                        '//全データの件数が前回取得した全データの時の件数よりも多い場合は警報発生と認識
                        '//警報が１件もなかった場合は音を出さない
                        If KEJUKJAG00C.pCtlFlg = "KEJUKEI" And CLng(KEJUKJAG00C.pDataCount) > 0 Then
                            mlog("DATARENEW|KEJUKEI|" & intDataCount & "|" & KEJUKJAG00C.pDataCount & "|" & gstrCenter)

                            '//----------------------------------
                            '警報を出力します
                            strMsg.Append("parent.Data.fncAlert_output();")
                            bolKei = True
                            '//----------------------------------
                        Else
                            '//strMsg.Append("alert('新しい警報が発生しました');")

                        End If
                    End If

                    '2013/12/19 T.Ono add 監視改善2013  START
                    '対応入力から戻ってきた場合は、選択した警報を再表示
                    If KEJUKJAG00C.pCtlFlg = "KEJUTAI" AndAlso KEJUKJAG00C.pSERIAL <> "" AndAlso CLng(KEJUKJAG00C.pDataCount) = 0 Then
                        '(対応入力用ボタンから遷移or対応入力画面から遷移) AND 処理�ｂ�保持している AND 前回データ総数=0
                        'の場合は、対応入力画面から遷移してきたと判断
                        mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load fncGetRownumSql 5 start KEJUKJAG00C.pSERIAL=" & KEJUKJAG00C.pSERIAL)
                        '2017/05/30 w.ganeko mod start
                        cdb = New CDB
                        cdb.mOpen()
                        strSQL = fncGetRownumSql(KEJUKJAG00C.pSERIAL, 1)
                        cdb.pSQL = strSQL.ToString
                        cdb.mExecQuery()
                        dbData = cdb.pResult    '結果をデータセットに格納
                        cdb.mClose()
                        cdb = Nothing
                        'strSQL = fncGetRownumSql(KEJUKJAG00C.pSERIAL, 1)
                        'dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)
                        '2017/05/30 w.ganeko mod end

                        mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load fncGetRownumSql 5 end KEJUKJAG00C.pSERIAL=" & KEJUKJAG00C.pSERIAL)

                        'ターゲットのRownumを取得
                        If dbData.Tables(0).Rows.Count = 0 Then                                     '2017/05/30 w.ganeko mod
                            'If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then     '2017/05/30 w.ganeko mod
                            '選択警報の処理�ｂﾜたは、より古い警報がなかった場合、最終ページに遷移
                            If KEJUKJAG00C.pChkMishori = "1" Then
                                '未処理のみにチェックあり
                                '2019/11/01 w.ganeko 2019監視改善 No3,4 start
                                'If intDoReactionCoun < 4 Then
                                'intTargetRownum = 1
                                'Else
                                'intTargetRownum = ((intDoReactionCoun - 1) \ 3) * 3 + 1
                                'End If
                                If intDoReactionCoun < 7 Then
                                    intTargetRownum = 1
                                Else
                                    intTargetRownum = ((intDoReactionCoun - 1) \ 6) * 6 + 1
                                End If
                                '2019/11/01 w.ganeko 2019監視改善 No3,4 end
                            Else
                                '未処理のみにチェックなし
                                '2019/11/01 w.ganeko 2019監視改善 No3,4 start
                                'If intNoReactionCoun < 4 Then
                                'intTargetRownum = 1
                                'Else
                                'intTargetRownum = ((intNoReactionCoun - 1) \ 3) * 3 + 1
                                'End If
                                If intNoReactionCoun < 7 Then
                                    intTargetRownum = 1
                                Else
                                    intTargetRownum = ((intNoReactionCoun - 1) \ 6) * 6 + 1
                                End If
                                '2019/11/01 w.ganeko 2019監視改善 No3,4 end
                            End If
                        Else
                            intTmpRownom = CInt(dbData.Tables(0).Rows(0).Item("ROWNUMID"))
                            'intTargetRownum = ((intTmpRownom - 1) \ 3) * 3 + 1  '2019/11/01 w.ganeko 2019監視改善 No3,4
                            intTargetRownum = ((intTmpRownom - 1) \ 6) * 6 + 1   '2019/11/01 w.ganeko 2019監視改善 No3,4
                        End If
                    End If
                    '2013/12/19 T.Ono add 監視改善2013  END

                    '//データを検索します
                    '2014/10/17 H.Hosoda mod 処理Noを引数として設定
                    'strSQL = fncSelectSql(intTargetRownum)
                    mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load fncSelectSql 6 start strMaxSyori_Serial=" & strMaxSyori_Serial)
                    '2017/05/30 w.ganeko mod start
                    cdb = New CDB
                    cdb.mOpen()
                    strSQL = fncSelectSql(intTargetRownum, strMaxSyori_Serial)
                    cdb.pSQL = strSQL.ToString
                    cdb.mExecQuery()
                    dbData = cdb.pResult    '結果をデータセットに格納
                    cdb.mClose()
                    cdb = Nothing
                    'strSQL = fncSelectSql(intTargetRownum, strMaxSyori_Serial)
                    'dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)
                    '2017/05/30 w.ganeko mod end

                    mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load fncSelectSql 6 end strMaxSyori_Serial=" & strMaxSyori_Serial)
                    mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load fncDataSet 6 start strMaxSyori_Serial=" & strMaxSyori_Serial)
                    '//データを出力します
                    Call fncDataSet(dbData, KEJUKJAG00C.pCtlFlg)
                    mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load fncDataSet 6 end strMaxSyori_Serial=" & strMaxSyori_Serial)
                    '表示している警報の処理�ｂ�保存 2013/12/18 T.Ono add 監視改善2013
                    '2019/11/01 w.ganeko 2019監視改善 No3,4
                    'For intRow = 0 To 2
                    For intRow = 0 To 5
                        If intRow > dbData.Tables(0).Rows.Count - 1 Then
                            strSYORI_SERIAL(intRow) = ""
                        Else
                            strSYORI_SERIAL(intRow) = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("SYORI_SERIAL"))
                        End If
                    Next

                Case "DATAFIRST"
                    '//-------------------------------
                    '//先頭ボタンのデータ遷移を行います
                    '//
                    '//
                    If CLng(KEJUKJAG00C.pDataCount) <> intDataCount Then
                        '//全データの件数が前回取得した全データの時の件数よりも多い場合は警報発生と認識します
                        If KEJUKJAG00C.pCtlFlg = "KEJUKEI" Then
                            mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load KEJUKEI DATAFIRST")

                            '----------------------------------
                            '//警報を出力します
                            strMsg.Append("parent.Data.fncAlert_output();")
                            bolKei = True
                            '----------------------------------
                        Else
                            '//strMsg.Append("alert('新しい警報が発生しました');")
                        End If
                        '//制御ROWNUMを1にします
                        intTargetRownum = 1
                    Else
                        '//警報が発生していない場合は
                        '//制御ROWNUMを1にします
                        intTargetRownum = 1
                    End If
                    'データを検索します
                    '2014/10/17 H.Hosoda mod 処理Noを引数として設定
                    'strSQL = fncSelectSql(intTargetRownum)
                    mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load fncSelectSql 7 start strMaxSyori_Serial=" & strMaxSyori_Serial)
                    '2017/05/30 w.ganeko mod start
                    cdb = New CDB
                    cdb.mOpen()
                    strSQL = fncSelectSql(intTargetRownum, strMaxSyori_Serial)
                    cdb.pSQL = strSQL.ToString
                    cdb.mExecQuery()
                    dbData = cdb.pResult    '結果をデータセットに格納
                    cdb.mClose()
                    cdb = Nothing
                    'strSQL = fncSelectSql(intTargetRownum, strMaxSyori_Serial)
                    'dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)
                    '2017/05/30 w.ganeko mod end

                    mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load fncSelectSql 7 end strMaxSyori_Serial=" & strMaxSyori_Serial)
                    mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load fncDataSet 7 start strMaxSyori_Serial=" & strMaxSyori_Serial)
                    'データを出力します
                    Call fncDataSet(dbData, KEJUKJAG00C.pCtlFlg)
                    mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load fncDataSet 7 end strMaxSyori_Serial=" & strMaxSyori_Serial)
                    '表示している警報の処理�ｂ�保存 2013/12/18 T.Ono add 監視改善2013
                    '2019/11/01 w.ganeko 2019監視改善 No3,4
                    'For intRow = 0 To 2
                    For intRow = 0 To 5
                        If intRow > dbData.Tables(0).Rows.Count - 1 Then
                            strSYORI_SERIAL(intRow) = ""
                        Else
                            strSYORI_SERIAL(intRow) = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("SYORI_SERIAL"))
                        End If
                    Next

                Case "DATAPRE"
                    '//-------------------------------
                    '//前ボタンのデータ遷移を行います
                    '//
                    '//
                    If CLng(KEJUKJAG00C.pDataCount) <> intDataCount Then
                        '//全データの件数が前回取得した全データの時の件数よりも多い場合は警報発生と認識します
                        If KEJUKJAG00C.pCtlFlg = "KEJUKEI" Then
                            mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load DATAPREKEJUKEI")

                            '----------------------------------
                            '//警報を出力します
                            strMsg.Append("parent.Data.fncAlert_output();")
                            bolKei = True
                            '----------------------------------
                            '//制御ROWNUMを1にします 2013/12/18 T.Ono add 監視改善2013
                            intTargetRownum = 1
                        Else
                            '//strMsg.Append("alert('新しい警報が発生しました');")
                            '2013/12/18 T.Ono add 監視改善2013  START
                            If KEJUKJAG00C.pSYORI_SERIAL1 = "" Then
                                '1番目（画面上）に表示がない場合（前ボタン押せないため通常ないケース）
                                intTargetRownum = 1
                            Else
                                '2017/05/30 w.ganeko mod start
                                cdb = New CDB
                                cdb.mOpen()
                                strSQL = fncGetRownumSql(KEJUKJAG00C.pSYORI_SERIAL1, 3)
                                cdb.pSQL = strSQL.ToString
                                cdb.mExecQuery()
                                dbData = cdb.pResult    '結果をデータセットに格納
                                cdb.mClose()
                                cdb = Nothing
                                'strSQL = fncGetRownumSql(KEJUKJAG00C.pSYORI_SERIAL1, 3)
                                'dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)
                                '2017/05/30 w.ganeko mod end

                                'ターゲットのRownumを取得
                                If dbData.Tables(0).Rows.Count = 0 Then                                  '2017/05/30 w.ganeko mod start
                                    'If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then  '2017/05/30 w.ganeko mod start
                                    '表示中の処理�ｂ謔闌ﾃい警報がなかった場合、先頭ページに遷移
                                    intTargetRownum = 1
                                Else
                                    intTmpRownom = CInt(dbData.Tables(0).Rows(0).Item("ROWNUMID"))
                                    'intTargetRownum = ((intTmpRownom - 1) \ 3) * 3 + 1    '2019/11/01 w.ganeko 2019監視改善 No3,4
                                    intTargetRownum = ((intTmpRownom - 1) \ 6) * 6 + 1     '2019/11/01 w.ganeko 2019監視改善 No3,4
                                End If
                            End If
                            '2013/12/18 T.Ono add 監視改善2013  END
                        End If
                        ''制御ROWNUMを1にします 2013/12/18 T.Ono del 監視改善2013
                        'intTargetRownum = 1
                    Else
                        '2013/12/18 T.Ono mod 監視改善2013  START
                        ''//警報が発生していない場合は
                        ''//制御ROWNUMを-3にします(マイナスになる場合は1にします)
                        'If CInt(KEJUKJAG00C.pRownum) - 3 <= 0 Then
                        '    intTargetRownum = 1
                        'Else
                        '    intTargetRownum = CInt(KEJUKJAG00C.pRownum) - 3
                        'End If

                        If KEJUKJAG00C.pSYORI_SERIAL1 = "" Then
                            '1番目（画面上）に表示がない場合（前ボタン押せないため通常ないケース）
                            intTargetRownum = 1
                        Else
                            '2017/05/30 w.ganeko mod start
                            cdb = New CDB
                            cdb.mOpen()
                            strSQL = fncGetRownumSql(KEJUKJAG00C.pSYORI_SERIAL1, 3)
                            cdb.pSQL = strSQL.ToString
                            cdb.mExecQuery()
                            dbData = cdb.pResult    '結果をデータセットに格納
                            cdb.mClose()
                            cdb = Nothing
                            'strSQL = fncGetRownumSql(KEJUKJAG00C.pSYORI_SERIAL1, 3)
                            'dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)
                            '2017/05/30 w.ganeko mod end
                            'ターゲットのRownumを取得
                            If dbData.Tables(0).Rows.Count = 0 Then                                     '2017/05/30 w.ganeko mod
                                'If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then     '2017/05/30 w.ganeko mod
                                '表示中の処理�ｂ謔闌ﾃい警報がなかった場合、先頭ページに遷移
                                intTargetRownum = 1
                            Else
                                intTmpRownom = CInt(dbData.Tables(0).Rows(0).Item("ROWNUMID"))
                                'intTargetRownum = ((intTmpRownom - 1) \ 3) * 3 + 1          '2019/11/01 w.ganeko 2019監視改善 No3,4
                                intTargetRownum = ((intTmpRownom - 1) \ 6) * 6 + 1           '2019/11/01 w.ganeko 2019監視改善 No3,4
                            End If
                        End If
                        '2013/12/18 T.Ono mod 監視改善2013  END
                    End If
                    'データを検索します
                    '2014/10/17 H.Hosoda mod 処理Noを引数として設定
                    'strSQL = fncSelectSql(intTargetRownum)
                    mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load fncSelectSql 8 start strMaxSyori_Serial=" & strMaxSyori_Serial)
                    '2017/05/30 w.ganeko mod start
                    cdb = New CDB
                    cdb.mOpen()
                    strSQL = fncSelectSql(intTargetRownum, strMaxSyori_Serial)
                    cdb.pSQL = strSQL.ToString
                    cdb.mExecQuery()
                    dbData = cdb.pResult    '結果をデータセットに格納
                    cdb.mClose()
                    cdb = Nothing
                    'strSQL = fncSelectSql(intTargetRownum, strMaxSyori_Serial)
                    'dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)
                    '2017/05/30 w.ganeko mod end

                    mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load fncSelectSql 8 end strMaxSyori_Serial=" & strMaxSyori_Serial)

                    'データを出力します
                    Call fncDataSet(dbData, KEJUKJAG00C.pCtlFlg)
                    '表示している警報の処理�ｂ�保存 2013/12/18 T.Ono add 監視改善2013
                    '2019/11/01 w.ganeko 2019監視改善 No3,4
                    'For intRow = 0 To 2
                    For intRow = 0 To 5
                        If intRow > dbData.Tables(0).Rows.Count - 1 Then
                            strSYORI_SERIAL(intRow) = ""
                        Else
                            strSYORI_SERIAL(intRow) = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("SYORI_SERIAL"))
                        End If
                    Next

                Case "DATANEX"
                    '//-------------------------------
                    '//次ボタンのデータ遷移を行います
                    '//
                    '//
                    If CLng(KEJUKJAG00C.pDataCount) <> intDataCount Then
                        '//全データの件数が前回取得した全データの時の件数よりも多い場合は警報発生と認識します
                        If KEJUKJAG00C.pCtlFlg = "KEJUKEI" Then
                            mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load DATANEX KEJUKEI")

                            '----------------------------------
                            '//警報を出力します
                            strMsg.Append("parent.Data.fncAlert_output();")
                            bolKei = True
                            '----------------------------------
                            '//制御ROWNUMを1にします 2013/12/18 T.Ono add 監視改善2013
                            intTargetRownum = 1
                        Else
                            '//strMsg.Append("alert('新しい警報が発生しました');")
                            '2013/12/18 T.Ono mod 監視改善2013  START
                            'If KEJUKJAG00C.pSYORI_SERIAL3 = "" Then  '2019/11/01 w.ganeko 2019監視改善 No3,4
                            If KEJUKJAG00C.pSYORI_SERIAL6 = "" Then   '2019/11/01 w.ganeko 2019監視改善 No3,4
                                '3番目（画面下）に表示がない場合（次ボタン押せないため通常ないケース）
                                intTargetRownum = 1
                            Else
                                mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load fncSelectSql 8 start KEJUKJAG00C.pSYORI_SERIAL6=" & KEJUKJAG00C.pSYORI_SERIAL6)
                                '2017/05/30 w.ganeko mod start
                                cdb = New CDB
                                cdb.mOpen()
                                'strSQL = fncGetRownumSql(KEJUKJAG00C.pSYORI_SERIAL3, 2)  '2019/11/01 w.ganeko 2019監視改善 No3,4
                                strSQL = fncGetRownumSql(KEJUKJAG00C.pSYORI_SERIAL6, 2)   '2019/11/01 w.ganeko 2019監視改善 No3,4
                                cdb.pSQL = strSQL.ToString
                                cdb.mExecQuery()
                                dbData = cdb.pResult    '結果をデータセットに格納
                                cdb.mClose()
                                cdb = Nothing
                                'strSQL = fncGetRownumSql(KEJUKJAG00C.pSYORI_SERIAL3, 2)
                                'dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)
                                '2017/05/30 w.ganeko mod end

                                mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load fncSelectSql 8 end KEJUKJAG00C.pSYORI_SERIAL6=" & KEJUKJAG00C.pSYORI_SERIAL6)
                                'ターゲットのRownumを取得
                                If dbData.Tables(0).Rows.Count = 0 Then                                    '2017/05/30 w.ganeko mod
                                    'If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then    '2017/05/30 w.ganeko mod
                                    '表示中の処理�ｂ謔闌ﾃい警報がなかった場合、最終ページに遷移
                                    If KEJUKJAG00C.pChkMishori = "1" Then
                                        '未処理のみにチェックあり
                                        '2019/11/01 w.ganeko 2019監視改善 No3,4 start
                                        'If intDoReactionCoun < 4 Then
                                        'intTargetRownum = 1
                                        'Else
                                        'intTargetRownum = ((intDoReactionCoun - 1) \ 3) * 3 + 1
                                        'End If
                                        If intDoReactionCoun < 7 Then
                                            intTargetRownum = 1
                                        Else
                                            intTargetRownum = ((intDoReactionCoun - 1) \ 6) * 6 + 1
                                        End If
                                        '2019/11/01 w.ganeko 2019監視改善 No3,4 end
                                    Else
                                        '未処理のみにチェックなし
                                        '2019/11/01 w.ganeko 2019監視改善 No3,4 start
                                        'If intNoReactionCoun < 4 Then
                                        'intTargetRownum = 1
                                        'Else
                                        'intTargetRownum = ((intNoReactionCoun - 1) \ 3) * 3 + 1
                                        'End If
                                        If intNoReactionCoun < 7 Then
                                            intTargetRownum = 1
                                        Else
                                            intTargetRownum = ((intNoReactionCoun - 1) \ 6) * 6 + 1
                                        End If
                                        '2019/11/01 w.ganeko 2019監視改善 No3,4 end
                                    End If
                                Else
                                    intTmpRownom = CInt(dbData.Tables(0).Rows(0).Item("ROWNUMID"))
                                    'intTargetRownum = ((intTmpRownom - 1) \ 3) * 3 + 1   '2019/11/01 w.ganeko 2019監視改善 No3,4
                                    intTargetRownum = ((intTmpRownom - 1) \ 6) * 6 + 1    '2019/11/01 w.ganeko 2019監視改善 No3,4
                                End If
                            End If
                            '2013/12/18 T.Ono mod 監視改善2013  END
                        End If
                        ''//制御ROWNUMを1にします 2013/12/18 T.Ono del 監視改善2013
                        'intTargetRownum = 1
                    Else
                        '2013/12/18 T.Ono mod 監視改善2013  START
                        '前回表示していた処理�ｂﾌ次に古い警報を表示する
                        ''//警報が発生していない場合は
                        ''//制御ROWNUMを+3にします(未処理件数(対応中を含む)を超える場合は)未処理件数(対応中を含む)-2にします)
                        'If CInt(KEJUKJAG00C.pRownum) + 3 > intNoReactionCoun Then
                        '    If intNoReactionCoun < 4 Then
                        '        intTargetRownum = 1
                        '    Else
                        '        If ((intNoReactionCoun \ 3) * 3) + 1 > CInt(KEJUKJAG00C.pRownum) Then
                        '            intTargetRownum = CInt(KEJUKJAG00C.pRownum)
                        '        Else
                        '            intTargetRownum = ((intNoReactionCoun \ 3) * 3) + 1
                        '        End If
                        '    End If
                        'Else
                        '    intTargetRownum = CInt(KEJUKJAG00C.pRownum) + 3
                        'End If

                        'If KEJUKJAG00C.pSYORI_SERIAL3 = "" Then '2019/11/01 w.ganeko 2019監視改善 No3,4 
                        If KEJUKJAG00C.pSYORI_SERIAL6 = "" Then  '2019/11/01 w.ganeko 2019監視改善 No3,4 
                            '3番目（画面下）に表示がない場合（次ボタン押せないため通常ないケース）
                            intTargetRownum = 1
                        Else
                            '2017/05/30 w.ganeko mod start
                            cdb = New CDB
                            cdb.mOpen()
                            'strSQL = fncGetRownumSql(KEJUKJAG00C.pSYORI_SERIAL3, 2) '2019/11/01 w.ganeko 2019監視改善 No3,4
                            strSQL = fncGetRownumSql(KEJUKJAG00C.pSYORI_SERIAL6, 2)  '2019/11/01 w.ganeko 2019監視改善 No3,4
                            cdb.pSQL = strSQL.ToString
                            cdb.mExecQuery()
                            dbData = cdb.pResult    '結果をデータセットに格納
                            cdb.mClose()
                            cdb = Nothing
                            'strSQL = fncGetRownumSql(KEJUKJAG00C.pSYORI_SERIAL3, 2)
                            'dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)
                            '2017/05/30 w.ganeko mod end

                            'ターゲットのRownumを取得
                            If dbData.Tables(0).Rows.Count = 0 Then                                 '2017/05/30 w.ganeko mod
                                'If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then '2017/05/30 w.ganeko mod
                                '表示中の処理�ｂ謔闌ﾃい警報がなかった場合、最終ページに遷移
                                If KEJUKJAG00C.pChkMishori = "1" Then
                                    '未処理のみにチェックあり
                                    '2019/11/01 w.ganeko 2019監視改善 No3,4 start
                                    'If intDoReactionCoun < 4 Then
                                    'intTargetRownum = 1
                                    'Else
                                    'intTargetRownum = ((intDoReactionCoun - 1) \ 3) * 3 + 1
                                    'End If
                                    If intDoReactionCoun < 7 Then
                                        intTargetRownum = 1
                                    Else
                                        intTargetRownum = ((intDoReactionCoun - 1) \ 6) * 6 + 1
                                    End If
                                    '2019/11/01 w.ganeko 2019監視改善 No3,4 end
                                Else
                                    '未処理のみにチェックなし
                                    '2019/11/01 w.ganeko 2019監視改善 No3,4 start
                                    'If intNoReactionCoun < 4 Then
                                    'intTargetRownum = 1
                                    'Else
                                    'intTargetRownum = ((intNoReactionCoun - 1) \ 3) * 3 + 1
                                    'End If
                                    If intNoReactionCoun < 7 Then
                                        intTargetRownum = 1
                                    Else
                                        intTargetRownum = ((intNoReactionCoun - 1) \ 6) * 6 + 1
                                    End If
                                    '2019/11/01 w.ganeko 2019監視改善 No3,4 end
                                End If
                            Else
                                intTmpRownom = CInt(dbData.Tables(0).Rows(0).Item("ROWNUMID"))
                                'intTargetRownum = ((intTmpRownom - 1) \ 3) * 3 + 1   '2019/11/01 w.ganeko 2019監視改善 No3,4
                                intTargetRownum = ((intTmpRownom - 1) \ 6) * 6 + 1    '2019/11/01 w.ganeko 2019監視改善 No3,4
                            End If
                        End If
                        '2013/12/18 T.Ono mod 監視改善2013  END
                    End If
                    '//データを検索します
                    '2014/10/17 H.Hosoda mod 処理Noを引数として設定
                    'strSQL = fncSelectSql(intTargetRownum)
                    '2017/05/30 w.ganeko mod start
                    cdb = New CDB
                    cdb.mOpen()
                    strSQL = fncSelectSql(intTargetRownum, strMaxSyori_Serial)
                    cdb.pSQL = strSQL.ToString
                    cdb.mExecQuery()
                    dbData = cdb.pResult    '結果をデータセットに格納
                    cdb.mClose()
                    cdb = Nothing
                    'strSQL = fncSelectSql(intTargetRownum, strMaxSyori_Serial)
                    'dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)
                    '2017/05/30 w.ganeko mod end

                    '//データを出力します
                    Call fncDataSet(dbData, KEJUKJAG00C.pCtlFlg)

                    '表示している警報の処理�ｂ�保存 2013/12/18 T.Ono add 監視改善2013
                    '2019/11/01 w.ganeko 2019監視改善 No3,4
                    'For intRow = 0 To 2
                    For intRow = 0 To 5
                        If intRow > dbData.Tables(0).Rows.Count - 1 Then
                            strSYORI_SERIAL(intRow) = ""
                        Else
                            strSYORI_SERIAL(intRow) = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("SYORI_SERIAL"))
                        End If
                    Next

                Case "DATAEND"
                    '//-------------------------------
                    '//最後ボタンのデータ遷移を行います
                    '//
                    '//
                    If CLng(KEJUKJAG00C.pDataCount) <> intDataCount Then
                        '//全データの件数が前回取得した全データの時の件数よりも多い場合は警報発生と認識します
                        If KEJUKJAG00C.pCtlFlg = "KEJUKEI" Then
                            mlog("DATAEND|" & intDataCount & "|" & KEJUKJAG00C.pDataCount & "|" & gstrCenter)

                            '----------------------------------
                            '//警報を出力します
                            strMsg.Append("parent.Data.fncAlert_output();")
                            bolKei = True
                            '----------------------------------
                            '//制御ROWNUMを1にします 2013/12/18 T.Ono add 監視改善2013
                            intTargetRownum = 1
                        Else
                            '//strMsg.Append("alert('新しい警報が発生しました');")
                            '2013/12/18 T.Ono add 監視改善2013 START
                            If KEJUKJAG00C.pChkMishori = "1" Then
                                '未処理のみチェックあり
                                '2019/11/01 w.ganeko 2019監視改善 No3,4 start
                                'If intDoReactionCoun < 4 Then
                                'intTargetRownum = 1
                                'Else
                                'intTargetRownum = ((intDoReactionCoun - 1) \ 3) * 3 + 1
                                'End If
                                If intDoReactionCoun < 7 Then
                                    intTargetRownum = 1
                                Else
                                    intTargetRownum = ((intDoReactionCoun - 1) \ 6) * 6 + 1
                                End If
                                '2019/11/01 w.ganeko 2019監視改善 No3,4 end
                            Else
                                '未処理のみチェックなし
                                '2019/11/01 w.ganeko 2019監視改善 No3,4 start
                                'If intNoReactionCoun < 4 Then
                                'intTargetRownum = 1
                                'Else
                                'intTargetRownum = ((intNoReactionCoun - 1) \ 3) * 3 + 1
                                'End If
                                If intNoReactionCoun < 7 Then
                                    intTargetRownum = 1
                                Else
                                    intTargetRownum = ((intNoReactionCoun - 1) \ 6) * 6 + 1
                                End If
                                '2019/11/01 w.ganeko 2019監視改善 No3,4 end
                            End If
                            '2013/12/18 T.Ono add 監視改善2013 END
                        End If
                        ''//制御ROWNUMを1にします 2013/12/18 T.Ono del 監視改善2013
                        'intTargetRownum = 1
                    Else
                        '2013/12/18 T.Ono mod 監視改善2013 START
                        ''//警報が発生していない場合は
                        ''//制御ROWNUMを[未処理件数(対応中を含む)-2]にします
                        'If intNoReactionCoun < 4 Then
                        '    intTargetRownum = 1
                        'Else
                        '    If ((intNoReactionCoun \ 3) * 3) + 1 > intNoReactionCoun Then
                        '        intTargetRownum = ((intNoReactionCoun \ 3) * 3) + 1 - 3
                        '    Else
                        '        intTargetRownum = ((intNoReactionCoun \ 3) * 3) + 1
                        '    End If
                        'End If
                        If KEJUKJAG00C.pChkMishori = "1" Then
                            '未処理のみチェックあり
                            '2019/11/01 w.ganeko 2019監視改善 No3,4 start
                            'If intDoReactionCoun < 4 Then
                            '    intTargetRownum = 1
                            'Else
                            '    intTargetRownum = ((intDoReactionCoun - 1) \ 3) * 3 + 1
                            'End If
                            If intDoReactionCoun < 7 Then
                                intTargetRownum = 1
                            Else
                                intTargetRownum = ((intDoReactionCoun - 1) \ 6) * 6 + 1
                            End If
                            '2019/11/01 w.ganeko 2019監視改善 No3,4 end
                        Else
                            '未処理のみチェックなし
                            '2019/11/01 w.ganeko 2019監視改善 No3,4 start
                            'If intNoReactionCoun < 4 Then
                            '    intTargetRownum = 1
                            'Else
                            '    intTargetRownum = ((intNoReactionCoun - 1) \ 3) * 3 + 1
                            'End If
                            If intNoReactionCoun < 7 Then
                                intTargetRownum = 1
                            Else
                                intTargetRownum = ((intNoReactionCoun - 1) \ 6) * 6 + 1
                            End If
                            '2019/11/01 w.ganeko 2019監視改善 No3,4 end
                        End If
                        '2013/12/18 T.Ono mod 監視改善2013 END
                    End If
                    '//データを検索します
                    '2014/10/17 H.Hosoda mod 処理Noを引数として設定
                    'strSQL = fncSelectSql(intTargetRownum)
                    '2017/05/30 w.ganeko mod start
                    cdb = New CDB
                    cdb.mOpen()
                    strSQL = fncSelectSql(intTargetRownum, strMaxSyori_Serial)
                    cdb.pSQL = strSQL.ToString
                    cdb.mExecQuery()
                    dbData = cdb.pResult    '結果をデータセットに格納
                    cdb.mClose()
                    cdb = Nothing
                    'strSQL = fncSelectSql(intTargetRownum, strMaxSyori_Serial)
                    'dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)
                    '2017/05/30 w.ganeko mod end

                    '//データを出力します
                    Call fncDataSet(dbData, KEJUKJAG00C.pCtlFlg)
                    '表示している警報の処理�ｂ�保存 2013/12/18 T.Ono add 監視改善2013
                    '2019/11/01 w.ganeko 2019監視改善 No3,4
                    'For intRow = 0 To 2
                    For intRow = 0 To 5
                        If intRow > dbData.Tables(0).Rows.Count - 1 Then
                            strSYORI_SERIAL(intRow) = ""
                        Else
                            strSYORI_SERIAL(intRow) = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("SYORI_SERIAL"))
                        End If
                    Next

            End Select

            '//警報が出力された時のみログにその旨を書き込みます
            '//警報が出力された時のみ初回利用の利用者情報を更新します
            '//警報が出力された時のみ欠損データの作成・ファイルＤＢ更新を行います
            If bolKei = True Then
                '-------------------------------------------------
                '//ＡＰログ書き込み
                strRec = "警報が発生しました(監視)"
                '2012/04/04 NEC ou Upd
                'strRecLog = LogC.mAPLog(Request.Cookies.Get("ASP.NET_SessionId").Value, AuthC.pUSERNAME, AuthC.pIPADDRESS, Request.Form("hdnMyAspx"), "4", strRec, Request.Form)
                strRecLog = LogC.mAPLog(Me.Session.SessionID, AuthC.pUSERNAME, AuthC.pIPADDRESS, Request.Form("hdnMyAspx"), "4", strRec, Request.Form)
                '2012/04/04 NEC ou Upd

                '//intDataCount
                '//  02バイト目から8バイトは発生日付
                '//  14バイト目から2バイトはテレコンセンター番号
                '//　16バイト目から6バイトはＳＥＱ番号
                Dim strFILE_NAME As String
                Dim strHASSEI As String = CStr(intDataCount).Substring(1, 8)
                Dim strSYORI_SERIAL As String = CStr(intDataCount).Substring(13, 6)

                strRec = funGetFileName(strSYORI_SERIAL, strFILE_NAME)

                Dim strZEN_FILE_NAME As String
                Dim strUPPER_SERIAL As String
                Dim strKessonFlg As Integer
                '//  strKessonFlg　 　0:欠損を作成しない　1:欠損を作成する
                '//  strUPPER_SERIAL　更新するシリアルが格納（空の時は更新しない→削除する）
                '2005/08/15 NEC UPDATE START
                '欠損処理はしない
                'strKessonFlg = fncKessonChk(strFILE_NAME, strUPPER_SERIAL)
                strKessonFlg = 0
                strUPPER_SERIAL = ""    '2012/04/24 NEC ou Add
                '2005/08/15 NEC UPDATE END
                '//そのＳＥＱ番号より欠損データ作成を行う(チェック)

                '//ファイルＤＢ・欠損データ更新
                strRec = fncKesson_Update(strKessonFlg, strFILE_NAME, strUPPER_SERIAL)

                '-------------------------------------------------
                '//終了記録
                Select Case strRec
                    Case "OK"
                        If strKessonFlg = 0 Then
                            strRec = "ファイルＤＢ更新：正常終了"
                        Else
                            strRec = "ファイルＤＢ更新・欠損データ作成：正常終了"
                        End If
                    Case Else
                        If strKessonFlg = 0 Then
                            strRec = "ファイルＤＢ更新：異常終了 " & strRec
                        Else
                            strRec = "ファイルＤＢ更新・欠損データ作成：異常終了 " & strRec
                        End If
                End Select
                '-------------------------------------------------

                '//ＡＰログ書き込み
                '2012/04/04 NEC ou Upd
                'strRecLog = LogC.mAPLog(Request.Cookies.Get("ASP.NET_SessionId").Value, AuthC.pUSERNAME, AuthC.pIPADDRESS, Request.Form("hdnMyAspx"), "1", strRec, Request.Form)
                strRecLog = LogC.mAPLog(Me.Session.SessionID, AuthC.pUSERNAME, AuthC.pIPADDRESS, Request.Form("hdnMyAspx"), "1", strRec, Request.Form)
                '2012/04/04 NEC ou Upd

            End If

            '//警報が出力された時または最新表示ボタンが押下された時のみ対応未処理件数を再取得します
            If KEJUKJAG00C.pExecFlag = "DATARENEW" Or bolKei = True Then
                '//対応未処理件数の取得：TMSKB＝1
                intTaiTmskbCount = fncTaiTmskbCount()
            End If

            strMsg.Append("with(parent.Data) {")
            strMsg.Append("Form1.hdnDataCount.value = '" & intDataCount & "';")                 '出力しているデータのカウント
            strMsg.Append("Form1.hdnNoReactionCOUNT.value = '" & intNoReactionCoun & "';")      '未対応データのカウント(hdn)
            strMsg.Append("Form1.hdnDoReactionCOUNT.value = '" & intDoReactionCoun & "';")      '未対応データのカウント(hdn)
            strMsg.Append("Form1.hdnTaiTmskbCOUNT.value = '" & intTaiTmskbCount & "';")         '対応未処理データのカウント(hdn)
            strMsg.Append("Form1.txtCOUNT.value = '" & intDoReactionCoun & "';")                '未対応データのカウント(txt)
            strMsg.Append("Form1.txtTAICNT.value = '" & intTaiTmskbCount & "';")                '対応未処理データのカウント(txt)
            strMsg.Append("Form1.txtTOTALCNT.value = '" & intNoReactionCoun & "';")             '警報表示パネル総件数のカウント(txt)    2016/11/16 H.Mori add 2016改善開発 No1-2 
            strMsg.Append("Form1.hdnRownum.value = '" & intTargetRownum & "';")
            strMsg.Append("Form1.hdnSYORI_SERIAL1.value = '" & strSYORI_SERIAL(0) & "';")       '処理��(表示パネル左上)　2013/12/18 T.Ono add 監視改善2013
            strMsg.Append("Form1.hdnSYORI_SERIAL2.value = '" & strSYORI_SERIAL(1) & "';")       '処理��(表示パネル左中)　2013/12/18 T.Ono add 監視改善2013
            strMsg.Append("Form1.hdnSYORI_SERIAL3.value = '" & strSYORI_SERIAL(2) & "';")       '処理��(表示パネル左下)　2013/12/18 T.Ono add 監視改善2013
            strMsg.Append("Form1.hdnSYORI_SERIAL4.value = '" & strSYORI_SERIAL(3) & "';")       '処理��(表示パネル右上)　2019/11/01 w.ganeko add 監視改善2019
            strMsg.Append("Form1.hdnSYORI_SERIAL5.value = '" & strSYORI_SERIAL(4) & "';")       '処理��(表示パネル右中)　2019/11/01 w.ganeko add 監視改善2019
            strMsg.Append("Form1.hdnSYORI_SERIAL6.value = '" & strSYORI_SERIAL(5) & "';")       '処理��(表示パネル右下)　2019/11/01 w.ganeko add 監視改善2019
            strMsg.Append("}")

            '//ページボタンの制御(Disabled)
            strMsg.Append("with(parent.Data) {")
            '未処理のみの場合は、処理を分ける
            If KEJUKJAG00C.pChkMishori = "1" Then
                '未処理のみチェックあり
                If intTargetRownum = 1 Then
                    '//最初のページの時
                    'If intDoReactionCoun <= 3 Then         '2019/11/01 w.ganeko add 監視改善2019 No 3,4
                    If intDoReactionCoun <= 6 Then          '2019/11/01 w.ganeko add 監視改善2019 No 3,4
                        '//総数が次ページまで行かない時
                        strMsg.Append("Form1.btnFirst.disabled = true;")
                        strMsg.Append("Form1.btnPre.disabled = true;")
                        strMsg.Append("Form1.btnEnd.disabled = true;")
                        strMsg.Append("Form1.btnNex.disabled = true;")
                    Else
                        '//上記以外、又は次ページからの戻り
                        strMsg.Append("fncFo(Form1.btnFirst, 5);")
                        strMsg.Append("fncFo(Form1.btnPre, 5);")
                        strMsg.Append("Form1.btnFirst.disabled = true;")
                        strMsg.Append("Form1.btnPre.disabled = true;")
                        strMsg.Append("Form1.btnEnd.disabled = false;")
                        strMsg.Append("Form1.btnNex.disabled = false;")
                    End If
                    'ElseIf intTargetRownum = (((intDoReactionCoun - 1) \ 3) * 3) + 1 Then '2019/11/01 w.ganeko add 監視改善2019 No 3,4
                ElseIf intTargetRownum = (((intDoReactionCoun - 1) \ 6) * 6) + 1 Then      '2019/11/01 w.ganeko add 監視改善2019 No 3,4
                    '//最後のページの時
                    strMsg.Append("Form1.btnFirst.disabled = false;")
                    strMsg.Append("Form1.btnPre.disabled = false;")
                    strMsg.Append("fncFo(Form1.btnEnd, 5);")
                    strMsg.Append("fncFo(Form1.btnNex, 5);")
                    strMsg.Append("Form1.btnEnd.disabled = true;")
                    strMsg.Append("Form1.btnNex.disabled = true;")
                Else
                    strMsg.Append("Form1.btnFirst.disabled = false;")
                    strMsg.Append("Form1.btnPre.disabled = false;")
                    strMsg.Append("Form1.btnEnd.disabled = false;")
                    strMsg.Append("Form1.btnNex.disabled = false;")
                End If
            Else
                '未処理のみチェックなし
                If intTargetRownum = 1 Then
                    '//最初のページの時
                    'If intNoReactionCoun <= 3 Then        '2019/11/01 w.ganeko add 監視改善2019 No 3,4
                    If intNoReactionCoun <= 6 Then         '2019/11/01 w.ganeko add 監視改善2019 No 3,4
                        '//総数が次ページまで行かない時
                        strMsg.Append("Form1.btnFirst.disabled = true;")
                        strMsg.Append("Form1.btnPre.disabled = true;")
                        strMsg.Append("Form1.btnEnd.disabled = true;")
                        strMsg.Append("Form1.btnNex.disabled = true;")
                    Else
                        '//上記以外、又は次ページからの戻り
                        strMsg.Append("fncFo(Form1.btnFirst, 5);")
                        strMsg.Append("fncFo(Form1.btnPre, 5);")
                        strMsg.Append("Form1.btnFirst.disabled = true;")
                        strMsg.Append("Form1.btnPre.disabled = true;")
                        strMsg.Append("Form1.btnEnd.disabled = false;")
                        strMsg.Append("Form1.btnNex.disabled = false;")
                    End If
                    'ElseIf intTargetRownum = (((intNoReactionCoun - 1) \ 3) * 3) + 1 Then   '2019/11/01 w.ganeko add 監視改善2019 No 3,4
                ElseIf intTargetRownum = (((intNoReactionCoun - 1) \ 6) * 6) + 1 Then        '2019/11/01 w.ganeko add 監視改善2019 No 3,4
                    '//最後のページの時
                    strMsg.Append("Form1.btnFirst.disabled = false;")
                    strMsg.Append("Form1.btnPre.disabled = false;")
                    strMsg.Append("fncFo(Form1.btnEnd, 5);")
                    strMsg.Append("fncFo(Form1.btnNex, 5);")
                    strMsg.Append("Form1.btnEnd.disabled = true;")
                    strMsg.Append("Form1.btnNex.disabled = true;")
                Else
                    strMsg.Append("Form1.btnFirst.disabled = false;")
                    strMsg.Append("Form1.btnPre.disabled = false;")
                    strMsg.Append("Form1.btnEnd.disabled = false;")
                    strMsg.Append("Form1.btnNex.disabled = false;")
                End If
            End If
            '//画面初期表示の際に最新表示ボタンへフォーカス
            If KEJUKJAG00C.pExecFlag = "DATARENEW" And KEJUKJAG00C.pCtlFlg <> "KEJUKEI" Then
                strMsg.Append("Form1.btnRenew.focus();")
            End If

            strMsg.Append("}")

            If KEJUKJAG00C.pCtlFlg = "KEJUKEI" Then
                Dim strJUSININTER As String = CStr(CInt(ConfigurationSettings.AppSettings("JINTER")) * 1000)
                '//[監視]N行後に再度実行JSを出力する
                strMsg.Append("var strFlg='0';")
                strMsg.Append("myTimer = setInterval('fncCheck_retry()'," & strJUSININTER & ");")
                strMsg.Append("function fncCheck_retry(){")
                strMsg.Append("	if (strFlg=='0') {")
                strMsg.Append("	  parent.Data.fncDataCheck();")
                strMsg.Append("	  strFlg='1';")
                strMsg.Append("	}")
                strMsg.Append("}")
            ElseIf KEJUKJAG00C.pChkJido = "1" Then
                '2013/12/13 T.Ono add 監視改善2013 自動更新
                Dim strJUSININTER As String = CStr(CInt(ConfigurationSettings.AppSettings("JINTER2")) * 1000)
                '//[自動更新チェック]N行後に再度実行JSを出力する
                strMsg.Append("var strFlg='0';")
                strMsg.Append("myTimer = setInterval('fncCheck_retry()'," & strJUSININTER & ");")
                strMsg.Append("function fncCheck_retry(){")

                strMsg.Append("	if (parent.Data.Form1.hdnBtmOukaFlg.value=='1') {")
                strMsg.Append("	    return;")
                strMsg.Append("	}")

                strMsg.Append("	if (strFlg=='0') {")
                strMsg.Append("	  parent.Data.fncDataCheck();")
                strMsg.Append("	  strFlg='1';")
                strMsg.Append("	}")
                strMsg.Append("}")
            Else
                '//[対応入力]最後に受信フレームワークを空にする
                'SHINYA
                strMsg.Append("location.replace('about:blank');")
            End If
            mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load end")

        Catch ex As Exception
            strRec = "ERROR:" & ex.ToString
            mlog("KEIHO_exception|" & AuthC.pUSERNAME & "|" & AuthC.pIPADDRESS & "|" & ex.ToString)
            If KEJUKJAG00C.pCtlFlg = "KEJUKEI" Then
                '自動更新のためALERTは出力しない
                '//ＡＰログ書き込み
                '2012/04/04 NEC ou Upd
                'strRecLog = LogC.mAPLog(Request.Cookies.Get("ASP.NET_SessionId").Value, AuthC.pUSERNAME, AuthC.pIPADDRESS, Request.Form("hdnMyAspx"), "1", strRec, Request.Form)
                strRecLog = LogC.mAPLog(Me.Session.SessionID, AuthC.pUSERNAME, AuthC.pIPADDRESS, Request.Form("hdnMyAspx"), "1", strRec, Request.Form)
                '2012/04/04 NEC ou Upd
            Else
                Dim ErrMsgC As New CErrMsg
                strMsg = New StringBuilder("")
                strMsg.Append("alert('システムエラー：" & ErrMsgC.mGetArtMsg(strRec) & "');")
            End If

        End Try
    End Sub

    Private Function funGetFileName(ByVal pstrSYORI_SERIAL As String, ByRef pstrFILE_NAME As String) As String
        'Dim SQLC As New KEJUKJAG00CCSQL.CSQL
        'Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet
        '2017/05/30 w.ganeko mod start
        Dim cdb As New CDB
        cdb.mOpen()
        '2017/05/30 w.ganeko mod end
        mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- EJUKJAG00:funGetFileName start pstrSYORI_SERIAL=" & pstrSYORI_SERIAL & ",pstrFILE_NAME=" & pstrFILE_NAME)

        strSQL.Append("SELECT  ")
        strSQL.Append(" RPAD(KE.FILE_NAME,8,' ') AS FILE_NAME ")   'ファイル名の文字列を合わせる為
        strSQL.Append("FROM T10_KEIHO KE ")
        strSQL.Append("WHERE KE.SYORI_SERIAL = :SYORI_SERIAL ")

        '2017/05/30 w.ganeko mod start
        'パラメータ設定
        'SqlParamC.fncSetParam("SYORI_SERIAL", True, pstrSYORI_SERIAL)

        '実行
        'dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)
        cdb.pSQL = strSQL.ToString
        cdb.pSQLParamStr("SYORI_SERIAL") = pstrSYORI_SERIAL
        cdb.mExecQuery()
        dbData = cdb.pResult    '結果をデータセットに格納
        cdb.mClose()
        cdb = Nothing
        '2017/05/30 w.ganeko mod end

        pstrFILE_NAME = Convert.ToString(dbData.Tables(0).Rows(0).Item("FILE_NAME"))
        mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- EJUKJAG00:funGetFileName end pstrSYORI_SERIAL=" & pstrSYORI_SERIAL & ",pstrFILE_NAME=" & pstrFILE_NAME)

    End Function

    '***************************************************
    '*ロック解除
    '***************************************************
    Private Function fncUpdateNoRoc(ByVal pstrSERIAL As String) As String

        'Dim KEJUKJAW00C As New KEJUKJAG00KEJUKJAW00.KEJUKJAW00 '2017/05/30 w.ganeko mod 
        Dim strRec As String
        mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- EJUKJAG00:fncUpdateNoRoc start KEJUKJAW00C.mSet_NoRoc pstrSERIAL=" & pstrSERIAL)

        'strRec = KEJUKJAW00C.mSet_NoRoc(pstrSERIAL)    '2017/05/30 w.ganeko mod 
        '2017/05/30 w.ganeko mod start
        Dim ds As New DataSet
        Dim cdb As New CDB
        Dim strSQL As StringBuilder
        mlog("[KEJUKJAW00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- mSet_NoRoc start pstrSERIAL=" & pstrSERIAL)

        strRec = "OK"

        '------------------------------------------------
        '接続OPEN----------------------------------------
        Try
            cdb.mOpen()
        Catch ex As Exception
            strRec = ex.ToString
            Return strRec
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
                strRec = "1"
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
            strSQL.Append("ROC_TIME= NULL, ")                   'ロック時間
            strSQL.Append("ROC_USER= NULL ")                   'ロックユーザー 2017/10/11 H.Mori add 2017改善開発 No1
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
            strRec = ex.ToString
            'ロールバック
            cdb.mRollback()
            strRec = strRec & cdb.pErr
        Finally
            '接続クローズ
            cdb.mClose()
        End Try

        cdb = Nothing
        '2017/05/30 w.ganeko mod end
        mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- EJUKJAG00:fncUpdateNoRoc end KEJUKJAW00C.mSet_NoRoc pstrSERIAL=" & pstrSERIAL)
 
        Return strRec

    End Function

    '***************************************************
    '*ロック
    '***************************************************
    Private Function fncUpdateRoc(ByVal pstrSERIAL As String) As String

        'Dim KEJUKJAW00C As New KEJUKJAG00KEJUKJAW00.KEJUKJAW00 '2017/05/30 w.ganeko mod 
        Dim strRec As String
        mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- EJUKJAG00:fncUpdateRoc start KEJUKJAW00C.mSet_Roc pstrSERIAL=" & pstrSERIAL)
        '2017/05/30 w.ganeko mod start
        Dim ds As New DataSet
        Dim cdb As New CDB
        Dim strSQL As StringBuilder

        strRec = "OK"

        '接続OPEN----------------------------------------
        Try
            cdb.mOpen()
        Catch ex As Exception
            strRec = ex.ToString
            Return strRec
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
                strRec = "1"
                Exit Try
            End If

            'ロックフラグが立っている時はエラーとする為
            If (Convert.ToString(ds.Tables(0).Rows(0).Item("ROC_FRG")) <> "") Then
                strRec = "2"
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
            strSQL.Append("ROC_TIME= :ROC_TIME, ")                      'ロック時間
            strSQL.Append("ROC_USER= :ROC_USER ")                       'ロックユーザー '2017/10/11 H.Mori add 2017改善開発 No1
            strSQL.Append("WHERE SYORI_SERIAL =:SYORI_SERIAL ")         '処理番号

            'SQL文セット
            cdb.pSQL = strSQL.ToString
            'パラメータセット
            cdb.pSQLParamStr("ROC_FRG") = "1"                           'ロックフラグ
            cdb.pSQLParamStr("ROC_TIME") = Now.ToString("HHmmss")       'ロック時間
            cdb.pSQLParamStr("ROC_USER") = AuthC.pUSERNAME              'ロックユーザー '2017/10/11 H.Mori add 2017改善開発 No1
            cdb.pSQLParamStr("SYORI_SERIAL") = pstrSERIAL               '処理番号
            'SQLを実行
            cdb.mExecNonQuery()

            'コミット
            cdb.mCommit()
        Catch ex As Exception
            'エラーが起きたら エラー内容を格納
            strRec = ex.ToString
            'ロールバック
            cdb.mRollback()
            strRec = strRec & cdb.pErr
        Finally
            '接続クローズ
            cdb.mClose()
        End Try

        cdb = Nothing

        'strRec = KEJUKJAW00C.mSet_Roc(pstrSERIAL)    '2017/05/30 w.ganeko mod 
        '2017/05/30 w.ganeko mod end
        mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- EJUKJAG00:fncUpdateRoc end KEJUKJAW00C.mSet_Roc pstrSERIAL=" & pstrSERIAL)

        Return strRec

    End Function

    '***************************************************
    '*全データから、発生日のMAXを取得
    '*※総数ではなくMAXの登録日と登録時間にて新しい警報が発生したかをチェックする
    '*　SEQ番号はSEQUENCEの為、１回転の可能性があるため使用しない
    '***************************************************
    '2014/10/17 H.Hosoda mod 処理Noを引数として設定 
    'Private Function fncDataCount() As Long
    Private Function fncDataCount(ByVal pstrSYORI_SERIAL As String) As Long

        'Dim SQLC As New KEJUKJAG00CCSQL.CSQL
        'Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet
        Dim strKanscd As String
        '2017/05/30 w.ganeko mod start
        Dim cdb As New CDB
        cdb.mOpen()
        '2017/05/30 w.ganeko mod end
        Dim kmList As ArrayList

        strKanscd = gstrCenter
        If gstrCenter.Length = 0 Then
            strKanscd = "''"
        End If
        mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- EJUKJAG00:fncDataCount start pstrSYORI_SERIAL=" & pstrSYORI_SERIAL)

        strSQL.Append("SELECT * FROM ( ")
        strSQL.Append("    SELECT  ")
        strSQL.Append("    '1' || RPAD(NVL(KEI.KMYMD || KEI.KMTIME,0),12,'0') || KEI.SYORI_SERIAL AS MAXRECODE  ")
        strSQL.Append("   ,KEI.REACTION ")
        strSQL.Append("   ,KEI.KANSCD ")
        strSQL.Append("   ,KEI.KURACD ")
        strSQL.Append("   ,KEI.ACBCD ")
        strSQL.Append("   ,KEI.JUYOKA ")
        strSQL.Append("   ,KEI.KMCD1 ")
        strSQL.Append("   ,KEI.KMNM1 ")
        strSQL.Append("   ,KEI.KMCD2 ")
        strSQL.Append("   ,KEI.KMNM2 ")
        strSQL.Append("   ,KEI.KMCD3 ")
        strSQL.Append("   ,KEI.KMNM3 ")
        strSQL.Append("   ,KEI.KMCD4 ")
        strSQL.Append("   ,KEI.KMNM4 ")
        strSQL.Append("   ,KEI.KMCD5 ")
        strSQL.Append("   ,KEI.KMNM5 ")
        strSQL.Append("   ,KEI.KMCD6 ")
        strSQL.Append("   ,KEI.KMNM6 ")
        strSQL.Append("    FROM T10_KEIHO KEI ")
        strSQL.Append("    WHERE  ")
        strSQL.Append("        KEI.KANSCD IN (" & strKanscd & ") ")
        strSQL.Append("    AND KEI.REACTION IN ('0', '1') ") '2:重複は除く 2010/03/05 T.Watabe add
        strSQL.Append("    AND TO_NUMBER(KEI.SYORI_SERIAL) <= " & pstrSYORI_SERIAL) '2014/10/17 H.Hosoda add 1Line 処理Noを条件として設定
        'If False Then '自動対応しない　T.Watabe edit 2012/01/30
        '2011/12/09 add H.Uema *----------------* START
        '処理済み且つ自動対応の警報が、警報データに含まれている場合は、除外する
        '2012/06/21 DEL W.GANEKO *----------------* START
        'strSQL.Append("    AND NOT EXISTS (SELECT ")
        'strSQL.Append("                      'X' ")
        'strSQL.Append("                    FROM ")
        'strSQL.Append("                      M07_AUTOTAIOUGROUP M07 ")
        'strSQL.Append("                      ,M08_AUTOTAIOU M08 ")
        'strSQL.Append("                    WHERE ")
        'strSQL.Append("                      KEI.REACTION = '1' ")
        'strSQL.Append("                      AND M07.USE_FLG = '1' ")
        'strSQL.Append("                      AND M07.KURACD = KEI.KURACD ")
        'strSQL.Append("                      AND M07.ACBCD = KEI.ACBCD ")
        'strSQL.Append("                      AND M08.GROUPCD = M07.GROUPCD ")
        'strSQL.Append("                      AND M08.PROCKBN = '1' ")
        'strSQL.Append("                      AND M08.KMCD IN (KEI.KMCD1, KEI.KMCD2, KEI.KMCD3, KEI.KMCD4, KEI.KMCD5, KEI.KMCD6) ")
        'strSQL.Append("                      AND M08.USE_FLG = '1' ")
        'strSQL.Append("                    ) ")
        '2012/06/21 DEL W.GANEKO *----------------* END
        '2011/12/09 add H.Uema *-----------------* END
        'End If
        'strSQL.Append("    ORDER BY 1 DESC ")
        strSQL.Append("    ORDER BY RPAD(NVL(KEI.SAYMD || KEI.STIME,0),12,'0') DESC, KEI.SYORI_SERIAL DESC  ") ' 2010/03/05 T.Watabe add
        strSQL.Append(") WHERE ROWNUM = 1 ")
        '2017/05/30 w.ganeko mod start
        'dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)
        'If Convert.ToString(dbData.Tables(0).Rows(0).Item("MAXRECODE")) = "XYZ" Then
        'dbData.Tables(0).Rows(0).Item("MAXRECODE") = "1000000000000000000"
        'End If
        cdb.pSQL = strSQL.ToString
        cdb.mExecQuery()
        dbData = cdb.pResult    '結果をデータセットに格納
        cdb.mClose()
        cdb = Nothing
        If dbData.Tables(0).Rows.Count = 0 Then
            mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- EJUKJAG00:fncDataCount end  pstrSYORI_SERIAL=" & pstrSYORI_SERIAL)
            Return Convert.ToInt64("1000000000000000000")
        End If
        '2017/05/30 w.ganeko mod end
        mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- EJUKJAG00:fncDataCount end  pstrSYORI_SERIAL=" & pstrSYORI_SERIAL)
        Return Convert.ToInt64(dbData.Tables(0).Rows(0).Item("MAXRECODE"))

    End Function

    '***************************************************
    '*未対応と対応中の件数の取得
    '***************************************************
    '2014/10/17 H.Hosoda mod 処理Noを引数として設定 
    'Private Function fncNoReactionCount() As Integer
    Private Function fncNoReactionCount(ByVal pstrSYORI_SERIAL As String) As Integer
        'Dim SQLC As New KEJUKJAG00CCSQL.CSQL
        'Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet
        '2017/05/30 w.ganeko mod start
        Dim cdb As New CDB
        cdb.mOpen()
        '2017/05/30 w.ganeko mod end
        mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- EJUKJAG00:fncNoReactionCount start pstrSYORI_SERIAL=" & pstrSYORI_SERIAL)

        strSQL.Append("SELECT ")
        strSQL.Append(" COUNT(*) AS CNT ")
        strSQL.Append("FROM T10_KEIHO ")
        strSQL.Append("WHERE REACTION = '0' ")
        strSQL.Append("AND TO_NUMBER(SYORI_SERIAL) <= " & pstrSYORI_SERIAL) '2014/10/17 H.Hosoda add 1Line 処理Noを条件として設定
        If gstrCenter.Length = 0 Then
            'エラーで落ちない為に
            strSQL.Append("  AND KANSCD = '' ")
        Else
            strSQL.Append("  AND KANSCD IN (" & gstrCenter & ") ")
        End If
        '2017/05/30 w.ganeko mod start
        'dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)
        cdb.pSQL = strSQL.ToString
        cdb.mExecQuery()
        dbData = cdb.pResult    '結果をデータセットに格納
        cdb.mClose()
        cdb = Nothing
        '2017/05/30 w.ganeko mod end
        mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- EJUKJAG00:fncNoReactionCount end pstrSYORI_SERIAL=" & pstrSYORI_SERIAL)

        Return Convert.ToInt32(dbData.Tables(0).Rows(0).Item("CNT"))

    End Function

    '***************************************************
    '*未対応の件数の取得
    '***************************************************
    '2014/10/17 H.Hosoda mod 処理Noを引数として設定 
    'Private Function fncDoReactionCount() As Integer
    Private Function fncDoReactionCount(ByVal pstrSYORI_SERIAL As String) As Integer
        'Dim SQLC As New KEJUKJAG00CCSQL.CSQL
        'Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet
        '2017/05/30 w.ganeko mod start
        Dim cdb As New CDB
        cdb.mOpen()
        '2017/05/30 w.ganeko mod end
        mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- EJUKJAG00:fncDoReactionCount start pstrSYORI_SERIAL=" & pstrSYORI_SERIAL)

        strSQL.Append("SELECT ")
        strSQL.Append("COUNT(*) AS CNT ")
        strSQL.Append("FROM T10_KEIHO ")
        strSQL.Append("WHERE REACTION = '0' ")
        strSQL.Append("AND TO_NUMBER(SYORI_SERIAL) <= " & pstrSYORI_SERIAL) '2014/10/17 H.Hosoda add 1Line 処理Noを条件として設定
        If gstrCenter.Length = 0 Then
            'エラーで落ちない為に
            strSQL.Append("  AND KANSCD = '' ")
        Else
            strSQL.Append("  AND KANSCD IN (" & gstrCenter & ") ")
        End If
        strSQL.Append("  AND ROC_FRG IS NULL ")
        '2017/05/30 w.ganeko mod start
        'dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)
        cdb.pSQL = strSQL.ToString
        cdb.mExecQuery()
        dbData = cdb.pResult    '結果をデータセットに格納
        cdb.mClose()
        cdb = Nothing
        '2017/05/30 w.ganeko mod end
        mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- EJUKJAG00:fncDoReactionCount end  pstrSYORI_SERIAL=" & pstrSYORI_SERIAL)
        Return Convert.ToInt32(dbData.Tables(0).Rows(0).Item("CNT"))

    End Function

    '***************************************************
    '*対応入力済で未対応の件数の取得
    '***************************************************
    Private Function fncTaiTmskbCount() As Integer
        'Dim SQLC As New KEJUKJAG00CCSQL.CSQL
        'Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet
        '2017/05/30 w.ganeko mod start
        Dim cdb As New CDB
        cdb.mOpen()
        '2017/05/30 w.ganeko mod end
        mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- KEJUKJAG00:fncTaiTmskbCount start ")

        strSQL.Append("SELECT ")
        strSQL.Append("COUNT(*) AS CNT ")
        strSQL.Append("FROM D20_TAIOU ")
        If gstrCenter.Length = 0 Then
            'エラーで落ちない為に
            strSQL.Append("WHERE KANSCD = '' ")
        Else
            strSQL.Append("WHERE KANSCD IN (" & gstrCenter & ") ")
        End If
        strSQL.Append("  AND TMSKB = '1' ")

        '2017/05/30 w.ganeko mod start
        'dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)
        cdb.pSQL = strSQL.ToString
        cdb.mExecQuery()
        dbData = cdb.pResult    '結果をデータセットに格納
        cdb.mClose()
        cdb = Nothing
        '2017/05/30 w.ganeko mod end

        mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- KEJUKJAG00:fncTaiTmskbCount end")
        Return Convert.ToInt32(dbData.Tables(0).Rows(0).Item("CNT"))

    End Function

    '***************************************************
    '*
    '***************************************************
    '2014/10/17 H.Hosoda mod 処理Noを引数として設定 
    'Private Function fncSelectSql(ByVal pintRownum As Integer) As String
    Private Function fncSelectSql(ByVal pintRownum As Integer, ByVal pstrSYORI_SERIAL As String) As String

        Dim KEJUKJAG00C As KEJUKJAG00                    '2013/12/13 T.Ono add 監視改善2013
        KEJUKJAG00C = CType(Context.Handler, KEJUKJAG00) '2013/12/13 T.Ono add 監視改善2013


        Dim strSQL As New StringBuilder("")
        '20050816 NEC DEL START
        'strSQL.Append("SELECT ")
        'strSQL.Append("* ")
        'strSQL.Append("FROM ")
        'strSQL.Append("( ")
        'strSQL.Append("SELECT ")
        'strSQL.Append("TO_CHAR(ROWNUM) AS ROWNUMIND, ")
        'strSQL.Append("A.* ")
        'strSQL.Append("FROM ")
        'strSQL.Append("( ")
        '20050816 NEC DEL END
        strSQL.Append("SELECT ")
        strSQL.Append("KE.SYORI_SERIAL, ")
        strSQL.Append("KE.FILE_NAME, ")
        strSQL.Append("KE.REACTION, ")
        strSQL.Append("KE.IS_PRINTED, ")
        strSQL.Append("KE.SYONO, ")
        strSQL.Append("KE.SAYMD, ")
        strSQL.Append("KE.SUYMD, ")
        strSQL.Append("KE.STIME, ")
        strSQL.Append("KE.MES_TYPE, ")
        strSQL.Append("KE.REPLY_CODE, ")
        strSQL.Append("KE.MEDIA_TYPE, ")
        strSQL.Append("KE.KURACD, ")
        strSQL.Append("KE.ACBCD, ")  '2019/11/01 W.GANEKO 2019監視改善 No 3,4
        strSQL.Append("KE.JUYOKA, ")
        strSQL.Append("KE.INFO_1, ")
        strSQL.Append("NVL(KE.INFO_2,'') AS INFO_2, ")
        strSQL.Append("KE.SECURITY_2, ")
        strSQL.Append("KE.KMYMD, ")
        strSQL.Append("KE.KMTIME, ")
        strSQL.Append("KE.JUYONM, ")
        strSQL.Append("KE.ADDR, ")
        strSQL.Append("KE.JUTEL, ")
        strSQL.Append("NVL(KE.KMSIN,'') AS KMSIN, ")
        strSQL.Append("NVL(KE.NUM_DIGIT,0) AS NUM_DIGIT, ")
        strSQL.Append("KE.KMCD1, ")
        strSQL.Append("KE.KMNM1, ")
        strSQL.Append("KE.KMCD2, ")
        strSQL.Append("KE.KMNM2, ")
        strSQL.Append("KE.KMCD3, ")
        strSQL.Append("KE.KMNM3, ")
        strSQL.Append("KE.KMCD4, ")
        strSQL.Append("KE.KMNM4, ")
        strSQL.Append("KE.KMCD5, ")
        strSQL.Append("KE.KMNM5, ")
        strSQL.Append("KE.KMCD6, ")
        strSQL.Append("KE.KMNM6, ")
        strSQL.Append("KE.META_SYUBETU, ")
        strSQL.Append("KE.KENSIN_MODE, ")
        strSQL.Append("KE.OKYAKU_FLG, ")
        strSQL.Append("KE.ROC_FRG, ")
        strSQL.Append("KE.ROC_TIME, ")
        strSQL.Append("KE.ROC_USER, ") '2017/10/11 H.Mori add 2017改善開発 No1
        strSQL.Append("CL.KEN_NAME AS KENNM, ")             '県名（クライアントマスタより）
        strSQL.Append("SH.USER_CD AS JUYOKA_UMU, ")         'お客様コード（有無）
        strSQL.Append("HN.JA_NAME AS ACBNM, ")              'ＪＡ名
        strSQL.Append("HA.NAME AS CENTNM ")                 '供給センター名
        strSQL.Append("FROM  ")
        '20051122 NEC UPDATE START
        '20050816 NEC UPDATE START
        'strSQL.Append("T10_KEIHO KE, ")                     '警報ＤＢ
        'strSQL.Append("(SELECT * FROM (")
        'strSQL.Append("SELECT ROWNUM AS ROWNUMID,T10_KEIHO.* FROM T10_KEIHO ")
        'strSQL.Append("WHERE KANSCD IN (" & gstrCenter & ") ")
        'strSQL.Append(" AND REACTION = '0' ORDER BY SYORI_SERIAL DESC) WHERE ROWNUMID BETWEEN " & pintRownum & " AND " & pintRownum + 2 & ") KE, ")
        strSQL.Append("(SELECT * FROM (")
        strSQL.Append("(SELECT ROWNUM AS ROWNUMID,KEIHO.* FROM (")
        strSQL.Append("SELECT * FROM T10_KEIHO ")
        strSQL.Append("WHERE KANSCD IN (" & gstrCenter & ") ")
        '2013/12/13 T.Ono mod 監視改善2013 未処理のみ検索 START
        'strSQL.Append(" AND REACTION = '0' ORDER BY SYORI_SERIAL DESC) KEIHO ")
        strSQL.Append(" AND REACTION = '0'  ")
        strSQL.Append(" AND TO_NUMBER(SYORI_SERIAL) <= " & pstrSYORI_SERIAL) '2014/10/17 H.Hosoda add 1Line 処理Noを条件として設定
        If KEJUKJAG00C.pChkMishori = "1" Then
            strSQL.Append(" AND ROC_FRG IS NULL ")
        End If
        strSQL.Append(" ORDER BY SYORI_SERIAL DESC ")
        strSQL.Append(" ) KEIHO ")
        '2013/12/13 T.Ono mod 監視改善2013 END
        strSQL.Append(" )  ")
        'strSQL.Append(") WHERE ROWNUMID BETWEEN " & pintRownum & " AND " & pintRownum + 2 & ") KE, ") '2019/11/01 w.ganeko 2019監視改善 No 3,4
        strSQL.Append(") WHERE ROWNUMID BETWEEN " & pintRownum & " AND " & pintRownum + 5 & ") KE, ")  '2019/11/01 w.ganeko 2019監視改善 No 3,4
        '20050816 NEC UPDATE END
        '20051122 NEC UPDATE END
        strSQL.Append("CLIMAS CL, ")                        'クライアントマスタ（テレコン）
        strSQL.Append("SHAMAS SH, ")                        '共用マスタ（テレコン）
        strSQL.Append("HN2MAS HN, ")                        'ＪＡ支所マスタ（テレコン）
        strSQL.Append("( ")
        'ＪＡ支所の供給センター・名称を取得
        strSQL.Append("SELECT  ")
        strSQL.Append("HN.CLI_CD, ")
        strSQL.Append("HN.HAN_CD, ")
        strSQL.Append("HA.NAME ")
        strSQL.Append("FROM ")
        strSQL.Append("HN2MAS HN, ")                       'ＪＡ支所マスタ（テレコン）
        strSQL.Append("HAIMAS HA ")                        '配送センターマスタ（テレコン）
        strSQL.Append("WHERE SUBSTR(HN.CLI_CD,2,2) = HA.KEN_CD(+) ")
        strSQL.Append("  AND HN.HAISO_CD = HA.HAISO_CD(+) ")
        strSQL.Append(") HA ")
        If gstrCenter.Length = 0 Then
            'エラーで落ちない為に
            strSQL.Append("WHERE KE.KANSCD = '' ")
        Else
            strSQL.Append("WHERE KE.KANSCD IN (" & gstrCenter & ") ")
        End If
        strSQL.Append("  AND KE.KURACD = CL.CLI_CD(+) ")
        strSQL.Append("  AND KE.KURACD = SH.CLI_CD(+) ")
        strSQL.Append("  AND KE.ACBCD = SH.HAN_CD(+) ")
        strSQL.Append("  AND KE.JUYOKA = SH.USER_CD(+) ")
        strSQL.Append("  AND KE.KURACD = HN.CLI_CD(+) ")
        strSQL.Append("  AND KE.ACBCD = HN.HAN_CD(+) ")
        strSQL.Append("  AND KE.KURACD = HA.CLI_CD(+) ")
        strSQL.Append("  AND KE.ACBCD = HA.HAN_CD(+) ")
        '20050816 NEC DEL START
        'strSQL.Append("  AND KE.REACTION = '0' ")
        '20050816 NEC DEL END
        strSQL.Append("ORDER BY SYORI_SERIAL DESC")
        '20050816 NEC DEL START
        'strSQL.Append(") A ")
        'strSQL.Append(") T ")
        'strSQL.Append("WHERE ROWNUMIND BETWEEN " & pintRownum & " AND " & pintRownum + 2 & " ")
        '20050816 NEC DEL END

        Return strSQL.ToString

    End Function

    '***************************************************
    '*
    '***************************************************
    Private Sub fncDataSet(ByRef pdbData As DataSet, ByVal psreCtl As String)
        Dim i As Integer
        Dim strTemp As String
        Dim strKuracd As String
        Dim strAcbcd As String
        Dim strJuyoka As String
        Dim strKuracd2 As String
        Dim strAcbcd2 As String
        Dim strJuyoka2 As String
        Dim intTemp As Integer
        Dim dbData2 As DataSet
        'Dim dbData3 As DataSet     '2021/10/01 saka 2021年度監視改善�Cの1時間前に同一顧客警報で対応してたら色変えは対応しないため、残しておくが削除 

        Dim DateFncC As New CDateFnc
        Dim TimeFncC As New CTimeFnc

        Dim intRow As Integer
        Dim intRowCk As Integer

        If pdbData.Tables(0).Rows.Count = 0 Then                                  '2017/05/30 w.ganeko mod start
            'If Convert.ToString(pdbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then  '2017/05/30 w.ganeko mod start

            strMsg.Append("with(parent.Data) {")
            '2019/11/01 W.GANEKO 2019改善開発 No3,4
            'For intRow = 0 To 2
            For intRow = 0 To 5
                strMsg.Append("Form1.hdn" & intRow + 1 & "SERIAL.value = '';")
                strMsg.Append("Form1.txt" & intRow + 1 & "KMYMD.value = '';")
                strMsg.Append("Form1.txt" & intRow + 1 & "KMTIME.value = '';")
                strMsg.Append("Form1.txt" & intRow + 1 & "RYURYO.value = '';")
                'For i = 1 To 6  '2019/11/01 w.ganeko 2019監視改善 No 3,4
                For i = 1 To 3   '2019/11/01 w.ganeko 2019監視改善 No 3,4
                    strMsg.Append("Form1.txt" & intRow + 1 & "KMMESSAGE" & CStr(i) & ".value = '';")
                Next
                strMsg.Append("Form1.txt" & intRow + 1 & "KMCNT.value = '';")
                strMsg.Append("Form1.txt" & intRow + 1 & "KURACD.value = '';")
                'strMsg.Append("Form1.txt" & intRow + 1 & "JUYOKA.value = '';")
                strMsg.Append("Form1.txt" & intRow + 1 & "JUYONM.value = '';")
                strMsg.Append("Form1.txt" & intRow + 1 & "JUTEL.value = '';")
                strMsg.Append("Form1.txt" & intRow + 1 & "ADDR.value = '';")
                strMsg.Append("Form1.txt" & intRow + 1 & "META.value = '';")
                strMsg.Append("Form1.txt" & intRow + 1 & "KENNM.value = '';")
                'strMsg.Append("Form1.txt" & intRow + 1 & "KYONM.value = '';")
                strMsg.Append("Form1.txt" & intRow + 1 & "JANM.value = '';")
                'strMsg.Append("Form1.txt" & intRow + 1 & "KOKYAKU.value = '';")
                strMsg.Append("Form1.txt" & intRow + 1 & "ROC.value = '';")
                strMsg.Append("Form1.txt" & intRow + 1 & "ROC.className = 'c-rNM';")
                'strMsg.Append("Form1.txt" & intRow + 1 & "ROCTIME.value = '';")
                strMsg.Append("Form1.txt" & intRow + 1 & "ROCUSER.value = '';") '2017/10/11 H.Mori add 2017改善開発 No1
                strMsg.Append("Form1.txt" & intRow + 1 & "ROCUSER.className = 'c-rNM';") '2017/11/17 H.Mori add 2017改善開発 No1
                strMsg.Append("Form1.txt" & intRow + 1 & "JUYONM.className = 'c-rNM';")  '2019/11/01 w.ganeko 2019監視改善 No 3,4
                strMsg.Append("Form1.txt" & intRow + 1 & "JUTEL.className = 'c-rNM';")   '2019/11/01 w.ganeko 2019監視改善 No 3,4
                strMsg.Append("Form1.txt" & intRow + 1 & "ADDR.className = 'c-rNM';")    '2019/11/01 w.ganeko 2019監視改善 No 3,4
                'strMsg.Append("Form1.txt" & intRow + 1 & "KURACD.className = 'c-rNM';")  '2021/10/01 saka 2021年度監視改善�Cの1時間前に同一顧客警報で対応してたら色変えは対応しないため、残しておくが削除
                'strMsg.Append("Form1.txt" & intRow + 1 & "KENNM.className = 'c-rNM';")   '2021/10/01
                'strMsg.Append("Form1.txt" & intRow + 1 & "JANM.className = 'c-rNM';")    '2021/10/01
                If psreCtl = "KEJUTAI" Then  '対応入力時
                    '緊急対応ボタンをDisabledにする
                    'ロック解除ボタンをDisabledにする
                    strMsg.Append("Form1.btn" & intRow + 1 & "TAIOU.disabled = true;")
                    strMsg.Append("Form1.btn" & intRow + 1 & "ROC.disabled = true;")
                End If
            Next
            strMsg.Append("}")
        Else

            Dim EscapeC As New CEscape
            '2019/11/01 w.ganeko 2019監視改善 No 3,4 start
            dbData2 = fncDupUser()
            'dbData3 = fncHourUser()                     '2021/10/01 saka 2021年度監視改善�Cの1時間前に同一顧客警報で対応してたら色変えは対応しないため、残しておくが削除

            '2019/11/01 w.ganeko 2019監視改善 No 3,4 end
            strMsg.Append("with(parent.Data) {")
            '2019/11/01 W.GANEKO 2019改善開発 No3,4
            'For intRow = 0 To 2   '2019/11/01 W.GANEKO 2019改善開発 No3,4
            For intRow = 0 To 5
                strMsg.Append("Form1.txt" & intRow + 1 & "JUYONM.className = 'c-rNM';")  '2019/11/01 w.ganeko 2019監視改善 No 3,4
                strMsg.Append("Form1.txt" & intRow + 1 & "JUTEL.className = 'c-rNM';")   '2019/11/01 w.ganeko 2019監視改善 No 3,4
                strMsg.Append("Form1.txt" & intRow + 1 & "ADDR.className = 'c-rNM';")    '2019/11/01 w.ganeko 2019監視改善 No 3,4

                'strMsg.Append("Form1.txt" & intRow + 1 & "KURACD.className = 'c-rNM';")  '2021/10/01 saka 2021年度監視改善�Cの1時間前に同一顧客警報で対応してたら色変えは対応しないため、残しておくが削除
                'strMsg.Append("Form1.txt" & intRow + 1 & "KENNM.className = 'c-rNM';")   '2021/10/01
                'strMsg.Append("Form1.txt" & intRow + 1 & "JANM.className = 'c-rNM';")    '2021/10/01

                If intRow > pdbData.Tables(0).Rows.Count - 1 Then
                    strMsg.Append("Form1.hdn" & intRow + 1 & "SERIAL.value = '';")
                    strMsg.Append("Form1.txt" & intRow + 1 & "KMYMD.value = '';")
                    strMsg.Append("Form1.txt" & intRow + 1 & "KMTIME.value = '';")
                    strMsg.Append("Form1.txt" & intRow + 1 & "RYURYO.value = '';")
                    '2019/11/01 W.GANEKO 2019改善開発 No3,4
                    'For i = 1 To 6  '2019/11/01 W.GANEKO 2019改善開発 No3,4
                    For i = 1 To 3
                        strMsg.Append("Form1.txt" & intRow + 1 & "KMMESSAGE" & CStr(i) & ".value = '';")
                    Next
                    strMsg.Append("Form1.txt" & intRow + 1 & "KMCNT.value = '';")
                    strMsg.Append("Form1.txt" & intRow + 1 & "KURACD.value = '';")
                    'strMsg.Append("Form1.txt" & intRow + 1 & "JUYOKA.value = '';")      '2019/11/01 W.GANEKO 2019改善開発 No3,4
                    strMsg.Append("Form1.txt" & intRow + 1 & "JUYONM.value = '';")
                    strMsg.Append("Form1.txt" & intRow + 1 & "JUTEL.value = '';")
                    strMsg.Append("Form1.txt" & intRow + 1 & "ADDR.value = '';")
                    strMsg.Append("Form1.txt" & intRow + 1 & "META.value = '';")
                    strMsg.Append("Form1.txt" & intRow + 1 & "KENNM.value = '';")
                    'strMsg.Append("Form1.txt" & intRow + 1 & "KYONM.value = '';")       '2019/11/01 W.GANEKO 2019改善開発 No3,4
                    strMsg.Append("Form1.txt" & intRow + 1 & "JANM.value = '';")
                    'strMsg.Append("Form1.txt" & intRow + 1 & "KOKYAKU.value = '';")     '2019/11/01 W.GANEKO 2019改善開発 No3,4
                    strMsg.Append("Form1.txt" & intRow + 1 & "ROC.value = '';")
                    strMsg.Append("Form1.txt" & intRow + 1 & "ROC.className = 'c-rNM';")
                    'strMsg.Append("Form1.txt" & intRow + 1 & "ROCTIME.value = '';")     '2019/11/01 W.GANEKO 2019改善開発 No3,4
                    strMsg.Append("Form1.txt" & intRow + 1 & "ROCUSER.value = '';") '2017/10/11 H.Mori add 2017改善開発 No1
                    strMsg.Append("Form1.txt" & intRow + 1 & "ROCUSER.className = 'c-rNM';") '2017/11/17 H.Mori add 2017改善開発 No1

                    If psreCtl = "KEJUTAI" Then  '対応入力時
                        '緊急対応ボタンをDisabledにする
                        'ロック解除ボタンをDisabledにする
                        strMsg.Append("Form1.btn" & intRow + 1 & "TAIOU.disabled = true;")
                        strMsg.Append("Form1.btn" & intRow + 1 & "ROC.disabled = true;")
                    End If
                Else
                    pdbData.Tables(0).Rows(intRow).Item("SYORI_SERIAL") =
                    EscapeC.mDb_Text(Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("SYORI_SERIAL")))
                    pdbData.Tables(0).Rows(intRow).Item("FILE_NAME") =
                    EscapeC.mDb_Text(Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("FILE_NAME")))
                    pdbData.Tables(0).Rows(intRow).Item("REACTION") =
                    EscapeC.mDb_Text(Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("REACTION")))
                    pdbData.Tables(0).Rows(intRow).Item("IS_PRINTED") =
                    EscapeC.mDb_Text(Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("IS_PRINTED")))
                    pdbData.Tables(0).Rows(intRow).Item("SYONO") =
                    EscapeC.mDb_Text(Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("SYONO")))
                    pdbData.Tables(0).Rows(intRow).Item("SAYMD") =
                    EscapeC.mDb_Text(Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("SAYMD")))
                    pdbData.Tables(0).Rows(intRow).Item("SUYMD") =
                    EscapeC.mDb_Text(Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("SUYMD")))
                    pdbData.Tables(0).Rows(intRow).Item("STIME") =
                    EscapeC.mDb_Text(Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("STIME")))
                    pdbData.Tables(0).Rows(intRow).Item("MES_TYPE") =
                    EscapeC.mDb_Text(Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("MES_TYPE")))
                    pdbData.Tables(0).Rows(intRow).Item("REPLY_CODE") =
                    EscapeC.mDb_Text(Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("REPLY_CODE")))
                    pdbData.Tables(0).Rows(intRow).Item("MEDIA_TYPE") =
                    EscapeC.mDb_Text(Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("MEDIA_TYPE")))
                    pdbData.Tables(0).Rows(intRow).Item("KURACD") =
                    EscapeC.mDb_Text(Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("KURACD")))
                    pdbData.Tables(0).Rows(intRow).Item("ACBCD") =
                    EscapeC.mDb_Text(Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("ACBCD")))    '2019/11/01 W.GANEKO 2019監視改善 No 3,4
                    pdbData.Tables(0).Rows(intRow).Item("JUYOKA") =
                    EscapeC.mDb_Text(Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("JUYOKA")))
                    pdbData.Tables(0).Rows(intRow).Item("INFO_1") =
                    EscapeC.mDb_Text(Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("INFO_1")))
                    pdbData.Tables(0).Rows(intRow).Item("INFO_2") =
                    EscapeC.mDb_Text(Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("INFO_2")))
                    pdbData.Tables(0).Rows(intRow).Item("SECURITY_2") =
                    EscapeC.mDb_Text(Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("SECURITY_2")))
                    pdbData.Tables(0).Rows(intRow).Item("KMYMD") =
                    EscapeC.mDb_Text(Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("KMYMD")))
                    pdbData.Tables(0).Rows(intRow).Item("KMTIME") =
                    EscapeC.mDb_Text(Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("KMTIME")))
                    pdbData.Tables(0).Rows(intRow).Item("JUYONM") =
                    EscapeC.mDb_Text(Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("JUYONM")))
                    pdbData.Tables(0).Rows(intRow).Item("ADDR") =
                    EscapeC.mDb_Text(Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("ADDR")))
                    pdbData.Tables(0).Rows(intRow).Item("JUTEL") =
                    EscapeC.mDb_Text(Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("JUTEL")))
                    pdbData.Tables(0).Rows(intRow).Item("KMSIN") =
                    EscapeC.mDb_Text(Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("KMSIN")))
                    pdbData.Tables(0).Rows(intRow).Item("NUM_DIGIT") =
                    EscapeC.mDb_Text(Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("NUM_DIGIT")))
                    pdbData.Tables(0).Rows(intRow).Item("KMCD1") =
                    EscapeC.mDb_Text(Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("KMCD1")))
                    pdbData.Tables(0).Rows(intRow).Item("KMNM1") =
                    EscapeC.mDb_Text(Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("KMNM1")))
                    pdbData.Tables(0).Rows(intRow).Item("KMCD2") =
                    EscapeC.mDb_Text(Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("KMCD2")))
                    pdbData.Tables(0).Rows(intRow).Item("KMNM2") =
                    EscapeC.mDb_Text(Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("KMNM2")))
                    pdbData.Tables(0).Rows(intRow).Item("KMCD3") =
                    EscapeC.mDb_Text(Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("KMCD3")))
                    pdbData.Tables(0).Rows(intRow).Item("KMNM3") =
                    EscapeC.mDb_Text(Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("KMNM3")))
                    pdbData.Tables(0).Rows(intRow).Item("KMCD4") =
                    EscapeC.mDb_Text(Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("KMCD4")))
                    pdbData.Tables(0).Rows(intRow).Item("KMNM4") =
                    EscapeC.mDb_Text(Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("KMNM4")))
                    pdbData.Tables(0).Rows(intRow).Item("KMCD5") =
                    EscapeC.mDb_Text(Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("KMCD5")))
                    pdbData.Tables(0).Rows(intRow).Item("KMNM5") =
                    EscapeC.mDb_Text(Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("KMNM5")))
                    pdbData.Tables(0).Rows(intRow).Item("KMCD6") =
                    EscapeC.mDb_Text(Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("KMCD6")))
                    pdbData.Tables(0).Rows(intRow).Item("KMNM6") =
                    EscapeC.mDb_Text(Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("KMNM6")))
                    pdbData.Tables(0).Rows(intRow).Item("META_SYUBETU") =
                    EscapeC.mDb_Text(Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("META_SYUBETU")))
                    pdbData.Tables(0).Rows(intRow).Item("KENSIN_MODE") =
                    EscapeC.mDb_Text(Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("KENSIN_MODE")))
                    pdbData.Tables(0).Rows(intRow).Item("OKYAKU_FLG") =
                    EscapeC.mDb_Text(Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("OKYAKU_FLG")))
                    pdbData.Tables(0).Rows(intRow).Item("ROC_FRG") =
                    EscapeC.mDb_Text(Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("ROC_FRG")))
                    pdbData.Tables(0).Rows(intRow).Item("ROC_TIME") =
                    EscapeC.mDb_Text(Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("ROC_TIME")))
                    pdbData.Tables(0).Rows(intRow).Item("ROC_USER") =
                    EscapeC.mDb_Text(Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("ROC_USER"))) '2017/10/11 H.Mori add 2017改善開発 No1
                    pdbData.Tables(0).Rows(intRow).Item("KENNM") =
                    EscapeC.mDb_Text(Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("KENNM")))
                    pdbData.Tables(0).Rows(intRow).Item("JUYOKA_UMU") =
                    EscapeC.mDb_Text(Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("JUYOKA_UMU")))
                    pdbData.Tables(0).Rows(intRow).Item("ACBNM") =
                    EscapeC.mDb_Text(Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("ACBNM")))
                    pdbData.Tables(0).Rows(intRow).Item("CENTNM") =
                    EscapeC.mDb_Text(Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("CENTNM")))

                    '処理番号------------------
                    strMsg.Append("Form1.hdn" & intRow + 1 & "SERIAL.value = '" _
                                    & Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("SYORI_SERIAL")) & "';")
                    '発生日--------------------
                    strMsg.Append("Form1.txt" & intRow + 1 & "KMYMD.value = '" _
                                    & DateFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("KMYMD"))) & "';")
                    '発生時間
                    strMsg.Append("Form1.txt" & intRow + 1 & "KMTIME.value = '" _
                                    & TimeFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("KMTIME")), 0) & "';")

                    '流動区分
                    strTemp = Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("INFO_2"))
                    If strTemp.Length < 3 Then
                        strTemp = ""
                    Else
                        '2005/12/03 NEC UPDATE START
                        '2005/09/22 NEC UPDATE START
                        'strTemp = strTemp.Substring(2, 1)
                        'strTemp = strTemp.Substring(2, 1).Replace(":", "10").Replace(";", "11").Replace("<", "12").Replace("-", "13").Replace(">", "14").Replace("?", "15")
                        strTemp = strTemp.Substring(2, 1).Replace(":", "10").Replace(";", "11").Replace("<", "12").Replace("=", "13").Replace(">", "14").Replace("?", "15")
                        '2005/09/22 NEC UPDATE END
                        '2005/12/03 NEC UPDATE END
                    End If
                    strMsg.Append("Form1.txt" & intRow + 1 & "RYURYO.value = '" & strTemp & "';")
                    '警報メッセージ１〜６
                    intTemp = 0
                    '2019/11/01 W.GANEKO 2019改善開発 No3,4
                    For i = 1 To 6
                        '2005/7/29 NEC UPDATE START
                        '警報コードがなくても表示できるようにする
                        'strTemp = Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("KMCD" & CStr(i)))
                        strTemp = Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("KMCD" & CStr(i))) &
                                Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("KMNM" & CStr(i)))
                        '2005/7/29 NEC UPDATE END
                        If strTemp.Length > 0 Then
                            strTemp = Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("KMCD" & CStr(i)))
                            If i >= 1 And i <= 3 Then
                                strMsg.Append("Form1.txt" & intRow + 1 & "KMMESSAGE" & CStr(i) & ".value = '" _
                                    & strTemp & "：" & Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("KMNM" & CStr(i))) & "';")
                            End If
                            intTemp += 1
                        Else
                            If i >= 1 And i <= 3 Then
                                strMsg.Append("Form1.txt" & intRow + 1 & "KMMESSAGE" & CStr(i) & ".value = '';")
                            End If
                        End If
                    Next
                    '警報メッセージ数
                    strMsg.Append("Form1.txt" & intRow + 1 & "KMCNT.value = '" & CStr(intTemp) & "';")
                    'クライアントコード
                    strMsg.Append("Form1.txt" & intRow + 1 & "KURACD.value = '" _
                                    & Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("KURACD")) & "';")
                    '2019/11/01 W.GANEKO 2019改善開発 No3,4 start
                    '需要家コード
                    'strMsg.Append("Form1.txt" & intRow + 1 & "JUYOKA.value = '" _
                    '                & Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("JUYOKA")) & "';")
                    '2019/11/01 W.GANEKO 2019改善開発 No3,4 end
                    '需要家名
                    strMsg.Append("Form1.txt" & intRow + 1 & "JUYONM.value = '" _
                                    & Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("JUYONM")) & "';")
                    '電話番号
                    strMsg.Append("Form1.txt" & intRow + 1 & "JUTEL.value = '" _
                                    & Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("JUTEL")) & "';")
                    '住所
                    strMsg.Append("Form1.txt" & intRow + 1 & "ADDR.value = '" _
                                    & Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("ADDR")) & "';")
                    '整数部桁数
                    strTemp = Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("NUM_DIGIT"))
                    If IsNumeric(strTemp) Then
                        intTemp = CInt(strTemp)
                    Else
                        intTemp = 0
                    End If
                    'メータ値
                    strTemp = Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("KMSIN"))
                    If strTemp.Length = 0 Then
                        strTemp = ""
                    Else
                        strTemp = strTemp.Substring(0, intTemp) & "." & strTemp.Substring(intTemp)
                    End If
                    If IsNumeric(pdbData.Tables(0).Rows(intRow).Item("KMSIN")) = True Then
                        strMsg.Append("Form1.txt" & intRow + 1 & "META.value = '" & strTemp & "';")
                    Else
                        strMsg.Append("Form1.txt" & intRow + 1 & "META.value = '" & Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("KMSIN")) & "';")
                    End If
                    '県名
                    strMsg.Append("Form1.txt" & intRow + 1 & "KENNM.value = '" _
                                    & Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("KENNM")) & "';")
                    '2019/11/01 W.GANEKO 2019改善開発 No3,4 start
                    '供給センター名
                    'strMsg.Append("Form1.txt" & intRow + 1 & "KYONM.value = '" _
                    '                & Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("CENTNM")) & "';")
                    '2019/11/01 W.GANEKO 2019改善開発 No3,4 end
                    'ＪＡ名
                    strMsg.Append("Form1.txt" & intRow + 1 & "JANM.value = '" _
                                    & Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("ACBNM")) & "';")
                    '2019/11/01 W.GANEKO 2019改善開発 No3,4 start
                    '顧客情報有無
                    'strTemp = Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("JUYOKA_UMU"))
                    'If strTemp.Length = 0 Then
                    'strMsg.Append("Form1.txt" & intRow + 1 & "KOKYAKU.value = 'なし';")
                    'Else
                    'strMsg.Append("Form1.txt" & intRow + 1 & "KOKYAKU.value = 'あり';")
                    'End If
                    '2019/11/01 W.GANEKO 2019改善開発 No3,4 end
                    '警報状態
                    strTemp = Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("ROC_FRG"))
                    If strTemp = "1" Then
                        strMsg.Append("Form1.txt" & intRow + 1 & "ROC.value = '対応中';")
                        strMsg.Append("Form1.txt" & intRow + 1 & "ROC.className = 'c-rNMR';")
                        '2017/11/17 H.Mori add 2017改善開発 No1 ロックユーザーの色（水色）
                        strMsg.Append("Form1.txt" & intRow + 1 & "ROCUSER.className = 'T';")
                        strMsg.Append("Form1.txt" & intRow + 1 & "JUYONM.className = 'c-rNM';")  '2019/11/01 w.ganeko 2019監視改善 No 3,4
                        strMsg.Append("Form1.txt" & intRow + 1 & "JUTEL.className = 'c-rNM';")   '2019/11/01 w.ganeko 2019監視改善 No 3,4
                        strMsg.Append("Form1.txt" & intRow + 1 & "ADDR.className = 'c-rNM';")    '2019/11/01 w.ganeko 2019監視改善 No 3,4
                        'strMsg.Append("Form1.txt" & intRow + 1 & "KURACD.className = 'c-rNM';")  '2021/10/01 saka 2021年度監視改善�Cの1時間前に同一顧客警報で対応してたら色変えは対応しないため、残しておくが削除
                        'strMsg.Append("Form1.txt" & intRow + 1 & "KENNM.className = 'c-rNM';")   '2021/10/01
                        'strMsg.Append("Form1.txt" & intRow + 1 & "JANM.className = 'c-rNM';")    '2021/10/01
                        If psreCtl = "KEJUTAI" Then  '対応入力時
                            '緊急対応ボタンをDisabledにする
                            strMsg.Append("Form1.btn" & intRow + 1 & "TAIOU.disabled = true;")
                            strMsg.Append("Form1.btn" & intRow + 1 & "ROC.disabled = false;")
                        End If
                    Else
                        strMsg.Append("Form1.txt" & intRow + 1 & "ROC.value = '未処理';")
                        strMsg.Append("Form1.txt" & intRow + 1 & "ROC.className = 'c-rNMB';")
                        '2017/11/17 H.Mori add 2017改善開発 No1 ロックユーザーの色
                        strMsg.Append("Form1.txt" & intRow + 1 & "ROCUSER.className = 'c-rNM';")
                        If psreCtl = "KEJUTAI" Then  '対応入力時
                            'ロック解除ボタンをDisabledにする
                            strMsg.Append("Form1.btn" & intRow + 1 & "TAIOU.disabled = false;")
                            strMsg.Append("Form1.btn" & intRow + 1 & "ROC.disabled = true;")
                        End If
                        '2019/11/01 W.GANEKO 2019改善開発 No3,4 start
                        strKuracd = Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("KURACD"))
                        strAcbcd = Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("ACBCD"))
                        strJuyoka = Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("JUYOKA"))

                        If dbData2.Tables(0).Rows.Count > 0 Then
                            For intRowCk = 0 To dbData2.Tables(0).Rows.Count - 1
                                strKuracd2 = Convert.ToString(dbData2.Tables(0).Rows(intRowCk).Item("KURACD"))
                                strAcbcd2 = Convert.ToString(dbData2.Tables(0).Rows(intRowCk).Item("ACBCD"))
                                strJuyoka2 = Convert.ToString(dbData2.Tables(0).Rows(intRowCk).Item("JUYOKA"))
                                If strKuracd = strKuracd2 And
                                   strAcbcd = strAcbcd2 And
                                   strJuyoka = strJuyoka2 Then
                                    strMsg.Append("Form1.txt" & intRow + 1 & "JUYONM.className = 'c-rNM2';")
                                    strMsg.Append("Form1.txt" & intRow + 1 & "JUTEL.className = 'c-rNM2';")
                                    strMsg.Append("Form1.txt" & intRow + 1 & "ADDR.className = 'c-rNM2';")
                                    Exit For
                                End If
                            Next
                        End If
                        '2019/11/01 W.GANEKO 2019改善開発 No3,4 end
                        'If dbData3.Tables(0).Rows.Count > 0 Then                '2021/10/01 saka 2021年度監視改善�Cの1時間前に同一顧客警報で対応してたら色変えは対応しないため、残しておくが削除
                        'For intRowCk = 0 To dbData3.Tables(0).Rows.Count - 1
                        'strKuracd2 = Convert.ToString(dbData3.Tables(0).Rows(intRowCk).Item("KURACD"))
                        'strAcbcd2 = Convert.ToString(dbData3.Tables(0).Rows(intRowCk).Item("ACBCD"))
                        'strJuyoka2 = Convert.ToString(dbData3.Tables(0).Rows(intRowCk).Item("JUYOKA"))
                        'If strKuracd = strKuracd2 And
                        'strAcbcd = strAcbcd2 And
                        'strJuyoka = strJuyoka2 Then
                        'strMsg.Append("Form1.txt" & intRow + 1 & "KURACD.className = 'c-rNM3';")
                        'strMsg.Append("Form1.txt" & intRow + 1 & "KENNM.className = 'c-rNM3';")
                        'strMsg.Append("Form1.txt" & intRow + 1 & "JANM.className = 'c-rNM3';")
                        'Exit For
                        'End If
                        'Next
                        'End If                         '2021/10/01
                    End If
                    '2019/11/01 W.GANEKO 2019改善開発 No3,4 start
                    '対応開始時刻
                    'strMsg.Append("Form1.txt" & intRow + 1 & "ROCTIME.value = '" _
                    '                & TimeFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("ROC_TIME")), 1) & "';")
                    '2019/11/01 W.GANEKO 2019改善開発 No3,4 end
                    'ロックユーザー 2017/10/11 H.Mori add 2017改善開発 No1
                    strMsg.Append("Form1.txt" & intRow + 1 & "ROCUSER.value = '" _
                                    & Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("ROC_USER")) & "';")
                End If
            Next

            strMsg.Append("}")

        End If
    End Sub

    '***************************************************
    '*警報としてきたＦＴＰファイル名と警報ファイルＤＢを比較して
    '*欠損データ作成の必要があるかどうかのチェックを行う
    '*また、今回の警報ファイルＤＢとして更新するデータのアッパーシリアルを取得する
    '*返り値：0:(欠損データの作成なし)／1:(欠損データの作成あり)
    '*
    '*また、ByRefのpstrUPPER_SERIALシリアルが空の場合は、送れてきた警報として
    '*今回警報のファイルＤＢ更新は無しとして処理する
    '*その時、警報ファイルＤＢにある警報の番号は削除する必要がある
    '***************************************************
    Private Function fncKessonChk( _
                                    ByVal pstrFILE_NAME As String, _
                                    ByRef pstrUPPER_SERIAL As String _
                                    ) As Integer
        'Dim SQLC As New KEJUKJAG00CCSQL.CSQL
        'Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet

        Dim strRec_UPPER_SERIAL As String
        Dim intRec_KESSON As Integer

        Dim strZEN_FILE_NAME As String
        Dim strZEN_UPPER_SERIAL As String
        '2017/05/30 w.ganeko mod start
        Dim cdb As New CDB
        cdb.mOpen()
        '2017/05/30 w.ganeko mod end

        '--------------------------------------------
        'ファイルステータス0のデータは１件のみ存在する
        '(正常分としては、前回処理をしたファイル名のみを保持)
        '前回処理のファイル名とアッパーシリアルを取得する
        strSQL = New StringBuilder("")
        strSQL.Append("SELECT  ")
        strSQL.Append(" RPAD(FILE_NAME,8,' ') AS FILE_NAME, ") 'ファイル名の文字列を合わせる為
        strSQL.Append(" UPPER_SERIAL ")
        strSQL.Append("FROM T11_KEIHOFILE ")
        strSQL.Append("WHERE FILE_STATUS = :FILE_STATUS ")
        '2017/05/30 w.ganeko mod start
        'パラメータ設定
        'SqlParamC.fncSetParam("FILE_STATUS", True, "0")         '正常処理済
        '実行
        'dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)
        'If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
        '    strZEN_FILE_NAME = "SE000000"
        '    strZEN_UPPER_SERIAL = "0"
        'Else
        '    strZEN_FILE_NAME = Convert.ToString(dbData.Tables(0).Rows(0).Item("FILE_NAME"))
        '    strZEN_UPPER_SERIAL = Convert.ToString(dbData.Tables(0).Rows(0).Item("UPPER_SERIAL"))
        'End If
        cdb.pSQL = strSQL.ToString
        cdb.pSQLParamStr("FILE_STATUS") = "0"
        cdb.mExecQuery()
        dbData = cdb.pResult    '結果をデータセットに格納
        cdb.mClose()
        cdb = Nothing
        '前回ファイルデータの取得
        If dbData.Tables(0).Rows.Count = 0 Then
            strZEN_FILE_NAME = "SE000000"
            strZEN_UPPER_SERIAL = "0"
        Else
            strZEN_FILE_NAME = Convert.ToString(dbData.Tables(0).Rows(0).Item("FILE_NAME"))
            strZEN_UPPER_SERIAL = Convert.ToString(dbData.Tables(0).Rows(0).Item("UPPER_SERIAL"))
        End If
        '2017/05/30 w.ganeko mod end

        '[警報ファイル番号]より[前回ファイル番号]の比較
        If CInt(pstrFILE_NAME.Substring(2, 6)) > CInt(strZEN_FILE_NAME.Substring(2, 6)) Then
            '[警報ファイル番号]より[前回ファイル番号]の方が小さい場場合

            'そのままの[アッパーシリアル]で、警報ファイルＤＢに
            '[警報ファイル番号]を前回処理データとしてデータ更新
            strRec_UPPER_SERIAL = strZEN_UPPER_SERIAL
            intRec_KESSON = fncKessonCreateChk(pstrFILE_NAME, strZEN_FILE_NAME)
        Else
            '[警報ファイル番号]より[前回ファイル番号]の方が大きい場合(または同じ）

            '[警報ファイル番号]-[ファイル番号]と250000(999999/4)で比較
            If CInt(strZEN_FILE_NAME.Substring(2, 6)) - CInt(pstrFILE_NAME.Substring(2, 6)) > 250000 Then
                '250000以上の差がある場合

                'ファイル番号が一周したと判断し、
                '[アッパーシリアル]＋１の番号で、警報ファイルＤＢに
                '[警報ファイル番号]を前回処理データとしてデータ更新
                strRec_UPPER_SERIAL = CStr(CInt(strZEN_UPPER_SERIAL) + 1)
                '[10]の時は[0]になる
                strRec_UPPER_SERIAL = Right(strRec_UPPER_SERIAL, 1)
                intRec_KESSON = fncKessonCreateChk(pstrFILE_NAME, strZEN_FILE_NAME)
            Else
                '250000以内の差の場合

                '遅れて警報が来たと判断し、
                '[警報ファイル番号]のデータが警報ファイルＤＢに存在する場合は
                'データを削除する
                '今回処理としてのファイル番号の更新は行わない
                strRec_UPPER_SERIAL = ""        'データの削除処理をおこなう
                intRec_KESSON = 0               '送れて来た警報のため欠損は無し
            End If
        End If

        pstrUPPER_SERIAL = strRec_UPPER_SERIAL
        Return intRec_KESSON
    End Function

    '***************************************************
    '*警報としてきたＦＴＰファイル名と前回処理ファイル名との間隔が5000以上の場合
    '*0:(欠損データの作成無し)
    '*5000以内の場合1:(欠損データの作成)をRetrunする
    '***************************************************
    Private Function fncKessonCreateChk(ByVal pstrFILE_NAME As String, ByVal pstrZEN_FILE_NAME As String) As Integer
        Dim intRec As Integer
        '頭2桁は"SE"とする
        Dim intFILE_NAME As Integer = CInt(pstrFILE_NAME.Substring(2, 6))
        Dim intZEN_FILE_NAME As Integer = CInt(pstrZEN_FILE_NAME.Substring(2, 6))

        'Importsが必要の為ABSは使用しない
        If intFILE_NAME > intZEN_FILE_NAME Then
            If intFILE_NAME - intZEN_FILE_NAME > 5000 Then
                intRec = 0      '作成しない
            Else
                intRec = 1      '作成する
            End If
        Else
            '１回転した計算を行う
            If 1000000 + intFILE_NAME - intZEN_FILE_NAME > 5000 Then
                intRec = 0      '作成しない
            Else
                intRec = 1      '作成する
            End If
        End If

        Return intRec
    End Function

    '***************************************************
    '*ファイルＤＢの更新：欠損作成：過去情報削除
    '***************************************************
    Private Function fncKesson_Update( _
                                    ByVal pintKESSON As Integer, _
                                    ByVal pstrFILE_NAME As String, _
                                    ByVal pstrUPPER_SERIAL As String _
                            ) As String
        Dim KEJUKJAW00C As New KEJUKJAG00KEJUKJAW00.KEJUKJAW00
        Dim strRec As String
        mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- fncKesson_Update end KEJUKJAW00C.mSet_Kesson pintKESSON=" & pintKESSON & " pstrFILE_NAME=" & pstrFILE_NAME & " pstrUPPER_SERIAL=" & pstrUPPER_SERIAL)
        
        strRec = KEJUKJAW00C.mSet_Kesson(pintKESSON, pstrFILE_NAME, pstrUPPER_SERIAL)

        mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- fncKesson_Update end KEJUKJAW00C.mSet_Kesson pintKESSON=" & pintKESSON & " pstrFILE_NAME=" & pstrFILE_NAME & " pstrUPPER_SERIAL=" & pstrUPPER_SERIAL & " return " & strRec)
        Return strRec

    End Function

    '***************************************************
    '* 重複警報の処理済更新 2009/09/09 T.Watabe edit
    '***************************************************
    '2014/10/17 H.Hosoda mod 処理Noを引数として設定
    'Private Function fncUpdateDuplicateKeiho() As String
    Private Function fncUpdateDuplicateKeiho(ByVal pstrSYORI_SERIAL As String) As String

        'Dim KEJUKJAW00C As New KEJUKJAG00KEJUKJAW00.KEJUKJAW00 '2017/05/30 w.ganeko mod start
        Dim strRec As String

        '2014/10/17 H.Hosoda mod 処理Noを引数として設定
        'strRec = KEJUKJAW00C.mSet_DuplicateKeiho()   
        mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- fncUpdateDuplicateKeiho start KEJUKJAW00C.mSet_DuplicateKeiho pstrSYORI_SERIAL=" & pstrSYORI_SERIAL)
        '2017/05/30 w.ganeko mod start
        'strRec = KEJUKJAW00C.mSet_DuplicateKeiho(pstrSYORI_SERIAL)
        Dim ds As New DataSet
        Dim cdb As New CDB
        Dim sql As StringBuilder

        strRec = "OK"

        '------------------------------------------------
        '接続OPEN----------------------------------------
        Try
            cdb.mOpen()
        Catch ex As Exception
            strRec = ex.ToString
            Return strRec
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
            strRec = ex.ToString
            'ロールバック
            cdb.mRollback()
            strRec = strRec & cdb.pErr
        Finally
            '接続クローズ
            cdb.mClose()
        End Try

        cdb = Nothing
        '2017/05/30 w.ganeko mod end
        mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- fncUpdateDuplicateKeiho end KEJUKJAW00C.mSet_DuplicateKeiho pstrSYORI_SERIAL=" & pstrSYORI_SERIAL)

        Return strRec

    End Function

    '***************************************************
    '* 警報の自動対応処理登録 2011/12/05 H.Uema add
    '***************************************************
    '2014/10/17 H.Hosoda mod 処理Noを引数として設定
    'Private Function fncAutoInsKeiho() As String
    Private Function fncAutoInsKeiho(ByVal pstrSYORI_SERIAL As String) As String
        Dim KEJUKJAW00C As New KEJUKJAG00KEJUKJAW00.KEJUKJAW00
        Dim strRec As String

        '2014/10/17 H.Hosoda mod 処理Noを引数として設定
        'strRec = KEJUKJAW00C.mSet_AutoTaiou()
        mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- fncAutoInsKeiho start KEJUKJAW00C.mSet_AutoTaiou pstrSYORI_SERIAL=" & pstrSYORI_SERIAL)
        '2017/05/30 w.ganeko mod start
        Dim cdb As New CDB
        Dim ds As New DataSet
        strRec = "OK"
        cdb.mOpen()
        cdb.pSQL = getSqlExistsAutoTaiou(pstrSYORI_SERIAL)
        cdb.mExecQuery()
        ds = cdb.pResult
        'データが存在しない場合、終了
        If (ds.Tables(0).Rows.Count <> 0) Then
            strRec = KEJUKJAW00C.mSet_AutoTaiou(pstrSYORI_SERIAL)
        End If
        cdb.mClose()
        cdb = Nothing
        'strRec = KEJUKJAW00C.mSet_AutoTaiou(pstrSYORI_SERIAL)
        '2017/05/30 w.ganeko mod end

        mlog("[KEJUKJKG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- fncAutoInsKeiho end KEJUKJAW00C.mSet_AutoTaiou pstrSYORI_SERIAL=" & pstrSYORI_SERIAL)

        Return strRec
    End Function
    '************************************************
    ' 自動対応を行う対象のデータ取得SQL
    '************************************************
    '2017/05/31 w.ganeko mod 処理軽量化
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
        strSQL.Append("  AND TO_NUMBER(KEI.SYORI_SERIAL) <= " & pstrSYORI_SERIAL)
        strSQL.Append("  AND KEI.ROC_FRG IS NULL ") '2021/10/01 2021年度監視改善�B sakaUPD 対応中の警報は自動対応で落とさない
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
        mlog("[KEJUKJAW00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- getSqlExistsAutoTaiou end  pstrSYORI_SERIAL=" & pstrSYORI_SERIAL)

        Return strSQL.ToString

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
        Dim LogC As New CLog
        Dim strRecLog As String
        Dim linestring As New StringBuilder("")
        If strLogFlg = "1" Then
            '書き込みファイルへのストリーム
            'Dim sw As StreamWriter
            'Dim fs As New FileStream(strPath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite)
            'linestring = New StringBuilder("")
            'linestring.Append( System.DateTime.Now & "." & System.DateTime.Now.Millisecond & "[" & AuthC.pUSERNAME & "][" & AuthC.pIPADDRESS & "][" & Me.Session.SessionID & "]" & pstrString & Chr(13) & Chr(10))
            Dim tbllog As String = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff") & " " & pstrString
            strRecLog = LogC.mAPLog(Me.Session.SessionID, AuthC.pUSERNAME, AuthC.pIPADDRESS, Request.Form("hdnMyAspx"), "4", tbllog, Request.Form)
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
        End If
    End Sub

    '**********************************************************
    ' 2013/12/18 ADD T.Ono
    '処理�ｂｩら、ROWNUMIDを取得 kbn 1:その警報または、より古い警報 2:古い警報 3:新しい警報
    '戻り値：
    '**********************************************************
    Private Function fncGetRownumSql(ByVal pintSYORI_SERIAL As String, ByRef kbn As Integer) As String

        Dim KEJUKJAG00C As KEJUKJAG00
        KEJUKJAG00C = CType(Context.Handler, KEJUKJAG00)
        Dim strSQL As New StringBuilder("")

        strSQL.Append(" SELECT ")
        strSQL.Append("  '' AS A, ")
        strSQL.Append("  '' AS B, ")
        strSQL.Append("  KE.SYORI_SERIAL, ")
        strSQL.Append("  KE.ROWNUMID, ")
        strSQL.Append("  KE.REACTION, ")
        strSQL.Append("  KE.KURACD, ")
        strSQL.Append("  KE.JUYOKA, ")
        strSQL.Append("  KE.JUYONM, ")
        strSQL.Append("  KE.ROC_FRG, ")
        strSQL.Append("  KE.ROC_TIME, ")
        strSQL.Append("  KE.ROC_USER ") '2017/10/11 H.Mori add 2017改善開発 No1
        strSQL.Append(" FROM ")
        strSQL.Append("  (SELECT * ")
        strSQL.Append("   FROM ")
        strSQL.Append("    ((SELECT ROWNUM AS ROWNUMID,KEIHO.* ")
        strSQL.Append("      FROM (SELECT * ")
        strSQL.Append("            FROM T10_KEIHO ")
        strSQL.Append("            WHERE KANSCD IN (" & gstrCenter & ") ")
        strSQL.Append("            AND REACTION = '0' ")
        If KEJUKJAG00C.pChkMishori = "1" Then
            strSQL.Append("            AND ROC_FRG IS NULL ")
        End If
        strSQL.Append("            ORDER BY SYORI_SERIAL DESC ")
        strSQL.Append("           ) KEIHO ")
        strSQL.Append("    ))) KE ")
        If gstrCenter.Length = 0 Then
            'エラーで落ちない為に
            strSQL.Append(" WHERE KE.KANSCD = '' ")
        Else
            strSQL.Append(" WHERE KE.KANSCD IN (" & gstrCenter & ") ")
        End If
        Select Case kbn
            Case 1
                strSQL.Append(" AND KE.SYORI_SERIAL <= '" & pintSYORI_SERIAL & "' ")
                strSQL.Append(" ORDER BY SYORI_SERIAL DESC ")
            Case 2
                strSQL.Append(" AND KE.SYORI_SERIAL < '" & pintSYORI_SERIAL & "' ")
                strSQL.Append(" ORDER BY SYORI_SERIAL DESC ")
            Case 3
                strSQL.Append(" AND KE.SYORI_SERIAL > '" & pintSYORI_SERIAL & "' ")
                strSQL.Append(" ORDER BY SYORI_SERIAL ")
            Case Else
                strSQL.Append(" AND KE.SYORI_SERIAL = '" & pintSYORI_SERIAL & "' ")
                strSQL.Append(" ORDER BY SYORI_SERIAL DESC ")
        End Select

        Return strSQL.ToString
    End Function

    '**********************************************************
    ' 2014/10/17 ADD H.Hosoda
    ' 警報ＤＢの処理Noの最大値を取得
    '戻り値：処理No(最大値）
    '**********************************************************
    Private Function fncGetMaxSyoriSerial() As String

        Dim strSQL As New StringBuilder("")

        strSQL.Append(" SELECT ")
        strSQL.Append("  MAX(SYORI_SERIAL) ")
        strSQL.Append(" FROM T10_KEIHO ")

        Return strSQL.ToString
    End Function
    '***************************************************
    ' 2019/11/01 w.ganeko 2019監視改善 No 3,4
    '* 同一顧客のチェック
    '***************************************************
    Private Function fncDupUser() As DataSet
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet
        Dim cdb As New CDB
        cdb.mOpen()

        strSQL.Append("SELECT ")
        strSQL.Append(" *  ")
        strSQL.Append("FROM( ")
        strSQL.Append(" SELECT ")
        strSQL.Append("  KURACD")
        strSQL.Append(" ,ACBCD ")
        strSQL.Append(" ,JUYOKA ")
        strSQL.Append(" ,COUNT(*) AS CNT ")
        strSQL.Append(" ,SUM(CASE WHEN ROC_FRG = '1' THEN 1 ELSE NULL END) AS ROC ")
        strSQL.Append("FROM T10_KEIHO ")
        strSQL.Append("WHERE REACTION = '0' ")
        strSQL.Append("GROUP BY KURACD,ACBCD,JUYOKA ")
        strSQL.Append(") A ")
        strSQL.Append(" WHERE A.CNT >= 2 AND A.ROC >= 1 ")

        cdb.pSQL = strSQL.ToString
        cdb.mExecQuery()
        dbData = cdb.pResult    '結果をデータセットに格納
        cdb.mClose()
        cdb = Nothing
        Return dbData

    End Function
    '***************************************************
    ' 2021/10/01 sakaADD 2021年度監視改善�C1日以内に警報発生していたら色を変える、は改善しないとなったため、ロジックは残しておくが削除
    '* 監視対応DB（D20_TAIOU）をみて同一顧客のデータが存在するかチェック
    '***************************************************
    'Private Function fncHourUser() As DataSet
    'Dim strSQL As New StringBuilder("")
    'Dim dbData As DataSet
    'Dim cdb As New CDB
    '   cdb.mOpen()

    '    strSQL.Append("SELECT ")
    '    strSQL.Append(" *  ")
    '    strSQL.Append("FROM( ")
    '    strSQL.Append(" SELECT ")
    '    strSQL.Append("  K.KURACD AS KURACD")
    '    strSQL.Append(" ,K.ACBCD AS ACBCD")
    '    strSQL.Append(" ,K.JUYOKA AS JUYOKA")
    '    strSQL.Append(" ,COUNT(T.KANSCD) AS CNT ")
    '    'strSQL.Append(" ,SUM(CASE WHEN ROC_FRG = '1' THEN 1 ELSE NULL END) AS ROC ")
    '    strSQL.Append(" FROM T10_KEIHO K,D20_TAIOU T ")
    '    'strSQL.Append("WHERE REACTION = '0' ")
    '    strSQL.Append(" WHERE K.KURACD=T.KURACD AND K.ACBCD=T.ACBCD AND K.JUYOKA=T.USER_CD AND K.REACTION='0' ")
    '    'strSQL.Append(" and t.hatkbn='2'and t.taiokbn in('1','2')and t.hatymd||t.hattime>=to_char(sysdate - 1/24,'yyyymmddhh24mi') ") '←1時間前
    '    strSQL.Append(" AND T.HATKBN='2'AND T.TAIOKBN IN('1','2')AND T.HATYMD||T.HATTIME>=TO_CHAR(SYSDATE - 1,'YYYYMMDDHH24MI') ")  '←1日前
    '    strSQL.Append("GROUP BY K.KURACD,K.ACBCD,K.JUYOKA ")
    '    strSQL.Append(") A ")
    '    strSQL.Append(" WHERE A.CNT >= 1 ")

    '    cdb.pSQL = strSQL.ToString
    '    cdb.mExecQuery()
    '    dbData = cdb.pResult    '結果をデータセットに格納
    '    cdb.mClose()
    '    cdb = Nothing
    '    Return dbData

    'End Function        '←2021年度監視改善�C1日以内に同一顧客から警報対応していたら色を変える2021/10/01
End Class
