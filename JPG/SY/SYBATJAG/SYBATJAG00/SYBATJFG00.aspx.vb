'***********************************************
'バッチ実行履歴一覧  一覧画面
'***********************************************
Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common
Imports JPG.Common.log
Imports System.Text

Partial Class SYBATJFG00
    Inherits System.Web.UI.Page
    Protected WithEvents dbData As System.Data.DataSet

    Protected SYBATJAG00_C As SYBATJAG00
    Protected ConstC As New CConst

    '******************************************************************************
    ' HttpHeader
    '******************************************************************************
    Protected HttpHeaderC As New CHttpHeader

    '<TODO>宣言共通仕様
    '******************************************************************************
    ' 認証クラス
    '******************************************************************************
    Protected AuthC As CAuthenticate

    '******************************************************************************
    ' ScriptMessage
    '******************************************************************************
    Private strMsg As New StringBuilder("")      '//<script>は必要なし

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
        Me.dbData = New System.Data.DataSet
        CType(Me.dbData, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'dbData
        '
        Me.dbData.DataSetName = "NewDataSet"
        Me.dbData.Locale = New System.Globalization.CultureInfo("ja-JP")
        CType(Me.dbData, System.ComponentModel.ISupportInitialize).EndInit()

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
    '*　概　要：
    '*　備　考：
    '******************************************************************************
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '//------------------------------------------
        '//　HTTPヘッダを送信
        HttpHeaderC.mNoCache(Response)

        '//------------------------------------------
        '//　認証クラスのインスタンス生成
        AuthC = New CAuthenticate(Request, Response)

        '//------------------------------------------
        '//　認証処理
        '<TODO>：使用可能権限を指定する
        '[バッチ実行履歴一覧]使用可能権限(運:○/営:×/監:△/出:×)
        AuthC.fncAuthCheck(Server, AuthC.pGROUP_UNKOU & "," & AuthC.pGROUP_KANSHI)

        '//------------------------------------------
        '// Script書込み用変数宣言
        Dim strScript As New StringBuilder("")
        Dim cscript1 As New CScript
        Dim strScriptPath As String
        strScriptPath = ConfigurationSettings.AppSettings("SCRIPTPATH")
        '//------------------------------------------
        '//　JavaScript格納
        strScript.Append("<Script language=javascript>")
        '＜一覧スクリプト＞
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncBG.js"))
        strScript.Append("</Script>")
        '//------------------------------------------
        '//　Css格納
        strScript.Append("<Style>")
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "CssIframe.css"))

        strScript.Append("</Style>")
        '//------------------------------------------
        '//　Script書込み
        lblScript.Text = strScript.ToString

        '********************************************
        '//------------------------------------------
        '<TODO>呼び出し元クラスのインスタンス作成
        SYBATJAG00_C = CType(Context.Handler, SYBATJAG00)
        '//------------------------------------------
        '********************************************

        '********************************************

        '//-------------------------------------------------
        '<TODO>自分の画面IDをHIDDENのhdnMyAspxに書き込む（システム共通）
        hdnMyAspx.Value = "SYBATJAG00"
        '//-------------------------------------------------

        '<TODO>画面オブジェクトを使用可能にする
        strMsg.Append("parent.Form1.btnSelect.disabled=false;")
        strMsg.Append("parent.Form1.btnExit.disabled=false;")

        Dim strRec As String = ""

        Try
            '//------------------------------------------
            Dim SQLC As New SYBATJAG00CCSQL.CSQL
            Dim SqlParamC As New CSQLParam
            Dim strSQL As New StringBuilder

            '//------------------------------------------
            '//MAX件数チェック
            Dim intCount As Integer

            If SYBATJAG00_C.pSelectClick = "1" Then
                Dim dbCnt As DataSet
                strSQL = New StringBuilder("")
                '検索ボタンが押されている場合のみ件数チェックを行う
                Call mMakeSQL(strSQL, SqlParamC, 1, 0)
                dbCnt = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)
                intCount = Convert.ToInt32(dbCnt.Tables(0).Rows(0).Item("CNT"))
                dbCnt.Dispose()
            Else
                '検索ボタンが押されていない場合は検索処理を行わない[一覧表示を行わない]
                intCount = 0
            End If

            '//------------------------------------------
            '// データの取得
            strSQL = New StringBuilder("")
            Call mMakeSQL(strSQL, SqlParamC, 0, intCount)
            dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

            '//取得データの編集を行う-----------------------------
            Dim intRow As Integer

            If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
                If SYBATJAG00_C.pSelectClick = "1" Then
                    '//検索ボタン押下によるデータ０件
                    strMsg.Append("alert('対象データが存在しません');")
                    strRec = "データが存在しません"
                End If

                dbData.Tables(0).Rows(0).Item("ROWNO") = ""
                dbData.Tables(0).Rows(0).Item("PROC_ID") = ""           'プロジェクトＩＤ
                dbData.Tables(0).Rows(0).Item("ST_YMD") = ""            '開始日付
                dbData.Tables(0).Rows(0).Item("ST_TIME") = ""           '開始時間
                dbData.Tables(0).Rows(0).Item("ED_YMD") = ""            '終了日付
                dbData.Tables(0).Rows(0).Item("ED_TIME") = ""           '終了時間
                dbData.Tables(0).Rows(0).Item("PROJ_STATUS_CD") = ""       '
                dbData.Tables(0).Rows(0).Item("PROJ_STATUS") = ""       'プロジェクト実行結果
                dbData.Tables(0).Rows(0).Item("EXEC_STATUS_CD") = ""
                dbData.Tables(0).Rows(0).Item("EXEC_STATUS") = ""       '処理状況
                dbData.Tables(0).Rows(0).Item("MSG") = ""               'メッセージ

            Else

                Dim strTemp As String
                Dim EscapeC As New CEscape

                For intRow = 0 To dbData.Tables(0).Rows.Count - 1
                    dbData.Tables(0).Rows(intRow).Item("ROWNO") = _
                       EscapeC.mDb_Js(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("ROWNO")))
                    '//処理名
                    strTemp = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("PROC_ID"))
                    Select Case strTemp
                        Case "BTGETJAE00"
                            dbData.Tables(0).Rows(intRow).Item("PROC_ID") = "月次データ整理"
                            'Case "BTFAXJAE00"　2013/12/06 T.Ono del 監視改善2013
                            '    dbData.Tables(0).Rows(intRow).Item("PROC_ID") = "自動ＦＡＸ"
                            'Case "SYHANJAE00"　2013/12/06 T.Ono del 監視改善2013
                            'dbData.Tables(0).Rows(intRow).Item("PROC_ID") = "販売連動締処理"
                        Case "BTLTSJAE00"
                            'dbData.Tables(0).Rows(intRow).Item("PROC_ID") = "次期ＬＴＯＳ連動"　2013/12/06 T.Ono mod 監視改善2013
                            dbData.Tables(0).Rows(intRow).Item("PROC_ID") = "ＪＡ－ＬＴＯＳ連動"
                        Case "BTFAXJCE00"
                            dbData.Tables(0).Rows(intRow).Item("PROC_ID") = "自動ＦＡＸ2013"
                        Case "BTFAXJDE00"
                            dbData.Tables(0).Rows(intRow).Item("PROC_ID") = "自動ＦＡＸ2014" '2015/03/10 T.Ono add 2014改善開発
                    End Select

                    '//開始日付
                    strTemp = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("ST_YMD"))
                    If IsNumeric(strTemp) = True Then
                        dbData.Tables(0).Rows(intRow).Item("ST_YMD") = SYBATJAG00_C.fncDateSet(strTemp)
                    End If
                    '//開始時間
                    strTemp = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("ST_TIME"))
                    If IsNumeric(strTemp) = True Then
                        dbData.Tables(0).Rows(intRow).Item("ST_TIME") = SYBATJAG00_C.fncTimeSet(strTemp, 1)
                    End If
                    dbData.Tables(0).Rows(intRow).Item("ST_YMD") = _
                                Convert.ToString(dbData.Tables(0).Rows(intRow).Item("ST_YMD")) & " " & _
                                Convert.ToString(dbData.Tables(0).Rows(intRow).Item("ST_TIME"))

                    '//終了日付
                    strTemp = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("ED_YMD"))
                    If IsNumeric(strTemp) = True Then
                        dbData.Tables(0).Rows(intRow).Item("ED_YMD") = SYBATJAG00_C.fncDateSet(strTemp)
                    End If
                    '//終了時間
                    strTemp = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("ED_TIME"))
                    If IsNumeric(strTemp) = True Then
                        dbData.Tables(0).Rows(intRow).Item("ED_TIME") = SYBATJAG00_C.fncTimeSet(strTemp, 1)
                    End If
                    dbData.Tables(0).Rows(intRow).Item("ED_YMD") = _
                                Convert.ToString(dbData.Tables(0).Rows(intRow).Item("ED_YMD")) & " " & _
                                Convert.ToString(dbData.Tables(0).Rows(intRow).Item("ED_TIME"))
                    '実行結果
                    strTemp = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("PROJ_STATUS"))
                    If strTemp = "1" Then
                        dbData.Tables(0).Rows(intRow).Item("EXEC_STATUS") = ""
                    End If

                Next
            End If

            'リピータにバインドする-----------------------------
            rptData.DataBind()
            '********************************************
            If SYBATJAG00_C.pSelectClick = "1" Then
                If strRec.Length = 0 Then       '[データが存在しません]のメッセージを出力
                    strRec = "OK"
                End If
            End If
        Catch ex As Exception
            ''strRec = "出力処理にてエラーが発生しました"   '//ORACLE-MESSAGEだと大きすぎる為メッセージ指定
            strRec = ex.ToString
            Dim ErrMsgC As New CErrMsg
            strMsg.Append("alert('システムエラー：" & errmsgc.mGetArtMsg(strRec) & "');")

        End Try

        If SYBATJAG00_C.pSelectClick = "1" Then
            '//検索ボタン押下による画面出力の場合は検索ボタンにフォーカスセット
            '//初期出力時は親画面での制御に任せる
            '<TODO>検索後のフォーカスをセットする
            strMsg.Append("parent.Form1.btnSelect.focus();")

            '-------------------------------------------------
            '//ＡＰログ書き込み
            Dim LogC As New CLog
            Dim strRecLog As String
            '2012/04/04 NEC ou Upd Str
            'strRecLog = LogC.mAPLog(Request.Cookies.Get("ASP.NET_SessionId").Value, AuthC.pUSERNAME, AuthC.pIPADDRESS, hdnMyAspx.Value, "4", strRec, Request.Form)
            strRecLog = LogC.mAPLog(Me.Session.SessionID, AuthC.pUSERNAME, AuthC.pIPADDRESS, hdnMyAspx.Value, "4", strRec, Request.Form)
            '2012/04/04 NEC ou Upd End
            If strRecLog <> "OK" Then
                Dim errmsgc As New CErrMsg
                strMsg.Append("alert('システムエラー：" & errmsgc.mGetArtMsg(strRecLog) & "');")
            End If
        End If

    End Sub

    '******************************************************************************
    '*　概　要：
    '*　備　考：
    '******************************************************************************
    Private Sub mMakeSQL(ByVal strSQL As StringBuilder, ByVal SqlParamC As CSQLParam, ByVal intkbn As Integer, ByVal intCount As Integer)

        '2013/12/09 T.Ono add 監視改善2013
        If intkbn = 0 Then
            If intCount > 0 Then
                'strSQL.Append("SELECT LPAD(ROWNUM,4,0) AS NO, A.* ")
                strSQL.Append("SELECT ")
                strSQL.Append("A.* ")
                strSQL.Append(",ROWNUM AS NO ")
                strSQL.Append("FROM (")
            Else
                strSQL.Append("SELECT ")
                strSQL.Append("A.* ")
                strSQL.Append(",'' AS NO ")
                strSQL.Append("FROM (")
            End If
        End If


        strSQL.Append("SELECT ")
        If intkbn = 0 Then
            If intCount > 0 Then
                strSQL.Append("LPAD(ROWNUM,3,0) AS ROWNO, ")
                strSQL.Append("BA.PROC_ID, ")
                strSQL.Append("BA.ST_YMD, ")
                strSQL.Append("BA.ST_TIME, ")
                strSQL.Append("BA.ED_YMD, ")
                strSQL.Append("BA.ED_TIME, ")
                strSQL.Append("BA.PROJ_STATUS AS PROJ_STATUS_CD, ")
                strSQL.Append("P33.NAME AS PROJ_STATUS, ")
                strSQL.Append("BA.EXEC_STATUS AS EXEC_STATUS_CD, ")
                strSQL.Append("P34.NAME AS EXEC_STATUS, ")
                strSQL.Append("BA.MSG ")
                strSQL.Append("FROM S02_BACHDB BA,  ")
                strSQL.Append("     M06_PULLDOWN P33, ")
                strSQL.Append("     M06_PULLDOWN P34 ")
            Else
                strSQL.Append("'XYZ' AS ROWNO, ")
                strSQL.Append("'' AS PROC_ID, ")
                strSQL.Append("'' AS ST_YMD, ")
                strSQL.Append("'' AS ST_TIME, ")
                strSQL.Append("'' AS ED_YMD, ")
                strSQL.Append("'' AS ED_TIME, ")
                strSQL.Append("'' AS PROJ_STATUS_CD, ")
                strSQL.Append("'' AS PROJ_STATUS, ")
                strSQL.Append("'' AS EXEC_STATUS_CD, ")
                strSQL.Append("'' AS EXEC_STATUS, ")
                strSQL.Append("'' AS MSG ")
                strSQL.Append("FROM DUAL ")
                strSQL.Append(") A") '2013/12/09 add T.Ono 監視改善2013
                Exit Sub
            End If
        Else
            '//件数カウント用のSQL
            strSQL.Append("COUNT(*) AS CNT ")       'カウント
            strSQL.Append("FROM S02_BACHDB BA ")
        End If

        If intkbn = 0 Then
            strSQL.Append("  WHERE ROWNUM <= " & ConstC.pScrollMax)
        Else
            strSQL.Append("  WHERE ROWNUM <= " & ConstC.pScrollMax + 1)
        End If

        '対象日付From～To
        strSQL.Append("  AND (BA.ADD_DATE BETWEEN :TRGDATE_F AND :TRGDATE_T) ")

        'プロジェクトＩＤ
        If SYBATJAG00_C.pPROC_ID.Length > 0 Then
            strSQL.Append("  AND BA.PROC_ID = :PROC_ID ")
        End If

        '状態
        If SYBATJAG00_C.pKbn = "2" Then         '正常
            strSQL.Append("  AND (BA.PROJ_STATUS = '0' AND BA.EXEC_STATUS = '1') ")
        ElseIf SYBATJAG00_C.pKbn = "3" Then     '異常
            strSQL.Append("  AND (BA.PROJ_STATUS = '1' AND BA.EXEC_STATUS = '0') ")
        Else                                    '全て

        End If

        If intkbn = 0 Then
            strSQL.Append("  AND P33.KBN = '33' ")
            strSQL.Append("  AND P33.CD  = BA.PROJ_STATUS ")
            strSQL.Append("  AND P34.KBN = '34' ")
            strSQL.Append("  AND P34.CD  = BA.EXEC_STATUS ")
            strSQL.Append("ORDER BY ST_YMD DESC,ST_TIME DESC ")
            strSQL.Append(") A") '2013/12/09 add T.Ono 監視改善2013
        End If

        'パラメータのセット
        '「全て」に対応 IF文追加　2013/12/06 T.Ono mod 監視改善2013
        If SYBATJAG00_C.pPROC_ID.Length > 0 Then
            SqlParamC.fncSetParam("PROC_ID", True, SYBATJAG00_C.pPROC_ID)
        End If
        SqlParamC.fncSetParam("TRGDATE_T", True, SYBATJAG00_C.pTRGDATE_T)
        SqlParamC.fncSetParam("TRGDATE_F", True, SYBATJAG00_C.pTRGDATE_F)

    End Sub
End Class