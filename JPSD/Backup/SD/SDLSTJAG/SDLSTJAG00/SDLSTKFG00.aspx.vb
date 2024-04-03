'***********************************************
'緊急出動結果一覧
'***********************************************
' 変更履歴
' 2008/10/15 T.Watabe 抽出条件を処理区分から出動会社処理区分に変更
'<TODO>宣言共通仕様
Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common
Imports JPG.Common.log

Imports System.Text

Partial Class SDLSTKFG00
    Inherits System.Web.UI.Page
    Protected WithEvents dbData As System.Data.DataSet
    Protected WithEvents hdnSysFLG As System.Web.UI.HtmlControls.HtmlInputHidden

    Protected SDLSTJAG00_C As SDLSTJAG00
    Protected ConstC As New CConst

    '******************************************************************************
    ' HttpHeader
    '******************************************************************************
    Protected HttpHeaderC As New CHttpHeader

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
        Me.dbData.DataSetName = "dbData"
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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '//------------------------------------------
        '// HTTPヘッダを送信
        HttpHeaderC.mNoCache(Response)

        '//------------------------------------------
        '// 緊急出動確認へ遷移
        If hdnJUMP.Value = "SDSYUJAG00" Then
            Server.Transfer("../../../SD/SDSYUJAG/SDSYUJAG00/SDSYUJAG00.aspx")
        End If

        '//------------------------------------------
        '// Script書込み用変数宣言
        Dim strScript As New StringBuilder("")
        Dim cscript1 As New CScript
        Dim strScriptPath As String
        strScriptPath = ConfigurationSettings.AppSettings("SCRIPTPATH")
        '//------------------------------------------
        '//　JavaScript格納
        strScript.Append("<Script language=javascript>")
        '//独自のスクリプト
        strScript.Append(cscript1.mWriteScript( _
             MyBase.MapPath("../../../SD/SDLSTJAG/SDLSTJAG00/") & "SDLSTKFG00.js"))
        '//一覧スクリプト
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
        SDLSTJAG00_C = CType(Context.Handler, SDLSTJAG00)
        '//------------------------------------------
        '********************************************

        '//-------------------------------------------------
        '<TODO>自分の画面IDをHIDDENのhdnMyAspxに書き込む（システム共通）
        hdnMyAspx.Value = "SDLSTJAG00"
        '//-------------------------------------------------

        '//--------------------------------------
        '//0:通常出動会社　1:監視センター
        hdnLOGIN_FLG.Value = SDLSTJAG00_C.pLOGIN_FLG

        '//-------------------------------------------------

        '<TODO>選択したKEYの値を転記
        '//-------------------------------------------------
        Dim strKEY_KANSCD As String
        Dim strKEY_SYONO As String

        strKEY_KANSCD = SDLSTJAG00_C.pKEY_KANSCD
        strKEY_SYONO = SDLSTJAG00_C.pKEY_SYONO

        hdnMOVE_SIJIYMD_F.Value = SDLSTJAG00_C.pSIJIYMD_F
        hdnMOVE_SIJIYMD_T.Value = SDLSTJAG00_C.pSIJIYMD_T
        hdnMOVE_KBN.Value = "2"
        '2013/12/10 T.Ono add 監視改善2013 クライアント・JA
        hdnMOVE_CLI_CD.Value = SDLSTJAG00_C.pCLI_CD
        hdnMOVE_CLI_CD_NAME.Value = SDLSTJAG00_C.pCLI_CD_NAME
        hdnMOVE_JA_CD.Value = SDLSTJAG00_C.pJA_CD
        hdnMOVE_JA_CD_NAME.Value = SDLSTJAG00_C.pJA_CD_NAME
        '2014/10/21 H.Hosoda add 監視改善2014 No10 START
        hdnMOVE_GROUP_CD.Value = SDLSTJAG00_C.pGROUP_CD
        hdnMOVE_GROUP_CD_NAME.Value = SDLSTJAG00_C.pGROUP_CD_NAME
        '2014/10/21 H.Hosoda add 監視改善2014 No10 END

        'スクロール位置
        hdnScrollTop.Value = SDLSTJAG00_C.pScrollTop                '2013/12/11 T.Ono add 監視改善2013
        '<TODO>画面オブジェクトを使用可能にする
        strMsg.Append("parent.Form1.btnSelect.disabled=false;")
        strMsg.Append("parent.Form1.btnExit.disabled=false;")
        strMsg.Append("window.scroll( 0, " & hdnScrollTop.Value & ");") 'スクロール位置 2013/12/09 T.Ono add 監視改善2013
        Dim strRec As String = ""
        Try
            '//------------------------------------------
            Dim SQLC As New SDLSTJAG00CCSQL.CSQL
            Dim SqlParamC As New CSQLParam
            Dim strSQL As New StringBuilder

            '//------------------------------------------
            '//MAX件数チェック
            Dim intCount As Integer

            If SDLSTJAG00_C.pSelectClick = "1" Then
                Dim dbCnt As DataSet
                strSQL = New StringBuilder("")
                '検索ボタンが押されている場合のみ件数チェックを行う
                '--------------------------------------------------------------------------------↓↓↓
                '   2005.05.21  日付の範囲が同日の場合件数チェックは行わないよう修正
                Call mMakeSQL(strSQL, SqlParamC, 1, 0)
                dbCnt = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)
                If SDLSTJAG00_C.pSIJIYMD_F = SDLSTJAG00_C.pSIJIYMD_T Then
                Else
                    If Convert.ToInt32(dbCnt.Tables(0).Rows(0).Item("CNT")) > ConstC.pScrollMax Then
                        strMsg.Append("alert('最大出力件数を超えました。条件を指定して再度検索してください');")
                    End If
                End If
                intCount = Convert.ToInt32(dbCnt.Tables(0).Rows(0).Item("CNT"))
                dbCnt.Dispose()
                'Call mMakeSQL(strSQL, SqlParamC, 1, 0)
                'dbCnt = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)
                'If Convert.ToInt32(dbCnt.Tables(0).Rows(0).Item("CNT")) > ConstC.pScrollMax Then
                '    strMsg.Append("alert('最大出力件数を超えました。条件を指定して再度検索してください');")
                'End If
                'intCount = Convert.ToInt32(dbCnt.Tables(0).Rows(0).Item("CNT"))
                'dbCnt.Dispose()
                '--------------------------------------------------------------------------------↑↑↑
            Else
                '検索ボタンが押されていない場合は検索処理を行わない[一覧表示を行わない]
                intCount = 0
            End If

            '//------------------------------------------
            '// データの取得
            strSQL = New StringBuilder("")
            Call mMakeSQL(strSQL, SqlParamC, 0, intCount)
            dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

            '取得データの編集を行う-----------------------------
            Dim intRow As Integer

            If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
                '--- ↓2005/05/13 MOD Falcon↓ ---
                If SDLSTJAG00_C.Request.Form("hdnMsgMode") <> "MSG0" Then    '//2005/05/13 条件追加
                    If SDLSTJAG00_C.pSelectClick = "1" Then
                        '//検索ボタン押下によるデータ０件
                        strMsg.Append("alert('対象データが存在しません');")
                        strRec = "データが存在しません"
                    End If
                End If                                                          '//2005/05/13 条件追加
                '--- ↑2005/05/13 MOD Falcon↑ ---

                dbData.Tables(0).Rows(0).Item("JS_KANSCD") = ""     'JS出力用
                dbData.Tables(0).Rows(0).Item("JS_SYONO") = ""
                dbData.Tables(0).Rows(0).Item("CH_KANSCD") = ""     '遷移チェック用
                dbData.Tables(0).Rows(0).Item("CH_SYONO") = ""
                dbData.Tables(0).Rows(0).Item("ROWNO") = ""
                dbData.Tables(0).Rows(0).Item("COLOR") = ""         'SPANカラー
                dbData.Tables(0).Rows(0).Item("CLS") = ""           'SPANクラス
                dbData.Tables(0).Rows(0).Item("SYONO") = ""
                dbData.Tables(0).Rows(0).Item("TKTANCD_NM") = ""
                dbData.Tables(0).Rows(0).Item("HATYMD") = ""
                dbData.Tables(0).Rows(0).Item("HATTIME") = ""
                dbData.Tables(0).Rows(0).Item("SYOYMD") = ""
                dbData.Tables(0).Rows(0).Item("SYOTIME") = ""
                dbData.Tables(0).Rows(0).Item("HATKBN") = ""
                dbData.Tables(0).Rows(0).Item("JUSYONM") = ""
                dbData.Tables(0).Rows(0).Item("TELRNM") = ""
                dbData.Tables(0).Rows(0).Item("SDNM") = ""
                dbData.Tables(0).Rows(0).Item("SIJI_BIKO") = ""
            Else
                Dim strJsCode As New StringBuilder("")
                Dim EscapeC As New CEscape

                For intRow = 0 To dbData.Tables(0).Rows.Count - 1
                    'HtmlのJsにて使用する
                    dbData.Tables(0).Rows(intRow).Item("ROWNO") = _
                        EscapeC.mDb_Js(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("ROWNO")))
                    dbData.Tables(0).Rows(intRow).Item("JS_KANSCD") = _
                        EscapeC.mDb_Js(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("JS_KANSCD")))
                    dbData.Tables(0).Rows(intRow).Item("JS_SYONO") = _
                        EscapeC.mDb_Js(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("JS_SYONO")))
                    'Htmlの値として使用する
                    dbData.Tables(0).Rows(intRow).Item("SYONO") = _
                        EscapeC.mDb_Html(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("SYONO")))
                    dbData.Tables(0).Rows(intRow).Item("TKTANCD_NM") = _
                        EscapeC.mDb_Html(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("TKTANCD_NM")))
                    dbData.Tables(0).Rows(intRow).Item("HATYMD") = _
                        EscapeC.mDb_Html(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("HATYMD")))
                    dbData.Tables(0).Rows(intRow).Item("HATTIME") = _
                        EscapeC.mDb_Html(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("HATTIME")))
                    dbData.Tables(0).Rows(intRow).Item("SYOYMD") = _
                        EscapeC.mDb_Html(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("SYOYMD")))
                    dbData.Tables(0).Rows(intRow).Item("SYOTIME") = _
                        EscapeC.mDb_Html(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("SYOTIME")))
                    dbData.Tables(0).Rows(intRow).Item("HATKBN") = _
                        EscapeC.mDb_Html(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("HATKBN")))
                    dbData.Tables(0).Rows(intRow).Item("JUSYONM") = _
                        EscapeC.mDb_Html(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("JUSYONM")))
                    dbData.Tables(0).Rows(intRow).Item("TELRNM") = _
                        EscapeC.mDb_Html(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("TELRNM")))
                    dbData.Tables(0).Rows(intRow).Item("SDNM") = _
                        EscapeC.mDb_Html(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("SDNM")))
                    dbData.Tables(0).Rows(intRow).Item("SIJI_BIKO") = _
                        EscapeC.mDb_Html(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("SIJI_BIKO")))

                    '//登録画面より戻ってきた時の画面遷移時に、指定したデータの色を変更する
                    If (strKEY_KANSCD = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("CH_KANSCD")) And _
                        strKEY_SYONO = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("CH_SYONO"))) Then
                        dbData.Tables(0).Rows(intRow).Item("COLOR") = "GreenYellow"
                        dbData.Tables(0).Rows(intRow).Item("CLS") = "CHK"
                    Else
                        dbData.Tables(0).Rows(intRow).Item("COLOR") = "skyblue"
                        dbData.Tables(0).Rows(intRow).Item("CLS") = ""
                    End If

                    '//画面リンク＜処理番号＞
                    If Convert.ToString(dbData.Tables(0).Rows(intRow).Item("SYONO")) <> "" Then

                        '//処理番号にリンクをつけ、対応入力に遷移する
                        strJsCode = New StringBuilder("")
                        strJsCode.Append("<a href=""JavaScript:fncJump(")
                        strJsCode.Append("'" & Convert.ToString(dbData.Tables(0).Rows(intRow).Item("JS_KANSCD")) & "',")
                        strJsCode.Append("'" & Convert.ToString(dbData.Tables(0).Rows(intRow).Item("JS_SYONO")) & "'")
                        strJsCode.Append(")"">")
                        strJsCode.Append(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("SYONO")))
                        strJsCode.Append("</a>")

                        dbData.Tables(0).Rows(intRow).Item("SYONO") = strJsCode.ToString
                    End If

                    Dim strTemp As String

                    '//発生日　発生時刻
                    dbData.Tables(0).Rows(intRow).Item("HATYMD") = _
                            SDLSTJAG00_C.fncDateSet(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("HATYMD"))) _
                            + " " + SDLSTJAG00_C.fncTimeSet(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("HATTIME")))
                    '//緊急対応日　緊急対応時刻
                    dbData.Tables(0).Rows(intRow).Item("SYOYMD") = _
                            SDLSTJAG00_C.fncDateSet(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("SYOYMD"))) _
                            + " " + SDLSTJAG00_C.fncTimeSet(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("SYOTIME")))
                Next
            End If

            'リピータにバインドする-----------------------------
            rptData.DataBind()

            '検索対象件数出力
            strMsg.Append("parent.Form1.txtKEKKA_KENSU.value='" & intCount & "';")
            '--- ↓2005/05/13 ADD Falcon↓ ---
            strMsg.Append("parent.Form1.hdnMsgMode.value='';")
            '--- ↑2005/05/13 ADD Falcon↑ ---
            '********************************************
            If SDLSTJAG00_C.pSelectClick = "1" Then
                If strRec.Length = 0 Then       '[データが存在しません]のメッセージを出力
                    strRec = "OK"
                End If
            End If
        Catch ex As Exception
            strRec = ex.ToString
            Dim ErrMsgC As New CErrMsg
            strMsg.Append("alert('システムエラー：" & ErrMsgC.mGetArtMsg(strRec) & "');")
        End Try

        If SDLSTJAG00_C.pSelectClick = "1" Then
            '//検索ボタン押下による画面出力の場合は検索ボタンにフォーカスセット
            strMsg.Append("parent.Form1.btnSelect.focus();")

            '-------------------------------------------------
            '//ＡＰログ書き込み
            Dim LogC As New CLog
            Dim strRecLog As String
            '2012/04/06 NEC ou Upd Str
            'strRecLog = LogC.mAPLog(Request.Cookies.Get("ASP.NET_SessionId").Value, SDLSTJAG00_C.pLOGIN_USER, SDLSTJAG00_C.pLOGIN_IPADDRESS, hdnMyAspx.Value, "4", strRec, Request.Form)
            strRecLog = LogC.mAPLog(Me.Session.SessionID, SDLSTJAG00_C.pLOGIN_USER, SDLSTJAG00_C.pLOGIN_IPADDRESS, hdnMyAspx.Value, "4", strRec, Request.Form)
            '2012/04/06 NEC ou Upd End
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

        '2013/12/10 T.Ono add 監視改善2013
        If intkbn = 0 Then
            If intCount > 0 Then
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
                strSQL.Append("	'' AS COLOR,")                                              'SPANカラー
                strSQL.Append("	'' AS CLS,")                                                'SPANクラス
                strSQL.Append("	TAI.SYONO,")
                strSQL.Append("	TAI.KANSCD AS JS_KANSCD,")
                strSQL.Append("	TAI.SYONO AS JS_SYONO,")
                strSQL.Append("	TAI.KANSCD AS CH_KANSCD,")
                strSQL.Append("	TAI.SYONO AS CH_SYONO,")
                strSQL.Append("	TAI.TKTANCD_NM,")
                strSQL.Append("	TAI.HATYMD,")
                strSQL.Append("	TAI.HATTIME,")
                strSQL.Append("	TAI.SYOYMD,")
                strSQL.Append("	TAI.SYOTIME,")
                strSQL.Append("	TAI.HATKBN AS HATKBNCD,")
                strSQL.Append("	P08.NAME AS HATKBN,")
                strSQL.Append("	TAI.JUSYONM,")
                strSQL.Append("	TAI.TELRNM,")
                strSQL.Append("	TAI.SDNM, ")
                strSQL.Append("	TAI.SIJI_BIKO1 || SIJI_BIKO2 AS SIJI_BIKO ")

                If SDLSTJAG00_C.pSYU_CD.Length > 0 Then
                    strSQL.Append("FROM D20_TAIOU TAI, ")
                    strSQL.Append("     SHUTUDOMAS SH, ")
                    strSQL.Append("     M06_PULLDOWN P08 ")
                Else
                    strSQL.Append("FROM D20_TAIOU TAI, ")
                    strSQL.Append("     M06_PULLDOWN P08 ")
                End If
            Else
                strSQL.Append("'XYZ' AS ROWNO, ")
                strSQL.Append("'' AS COLOR,")
                strSQL.Append("'' AS CLS,")
                strSQL.Append("'' AS SYONO,")
                strSQL.Append("'' AS JS_KANSCD,")
                strSQL.Append("'' AS JS_SYONO,")
                strSQL.Append("'' AS CH_KANSCD,")
                strSQL.Append("'' AS CH_SYONO,")
                strSQL.Append("'' AS TKTANCD_NM,")
                strSQL.Append("'' AS HATYMD,")
                strSQL.Append("'' AS HATTIME,")
                strSQL.Append("'' AS SYOYMD,")
                strSQL.Append("'' AS SYOTIME,")
                strSQL.Append("'' AS HATKBNCD,")
                strSQL.Append("'' AS HATKBN,")
                strSQL.Append("'' AS JUSYONM,")
                strSQL.Append("'' AS TELRNM,")
                strSQL.Append("'' AS SDNM, ")
                strSQL.Append("'' AS SIJI_BIKO ")
                strSQL.Append("FROM DUAL ")
                strSQL.Append(") A") '2013/12/10 add T.Ono 監視改善2013

                Exit Sub
            End If
        Else
            '//件数カウント用のSQL
            If SDLSTJAG00_C.pSYU_CD.Length > 0 Then
                strSQL.Append("COUNT(*) AS CNT ")       'カウント
                strSQL.Append("FROM D20_TAIOU TAI, ")
                strSQL.Append("     SHUTUDOMAS SH ")
            Else
                strSQL.Append("COUNT(*) AS CNT ")       'カウント
                strSQL.Append("FROM D20_TAIOU TAI ")
            End If
        End If

        '   2005.05.21  -------------------------------------------------↓↓↓
        If SDLSTJAG00_C.pSIJIYMD_F = SDLSTJAG00_C.pSIJIYMD_T And _
            Len(SDLSTJAG00_C.pSIJIYMD_F) > 0 Then
            strSQL.Append("WHERE 1 = 1 ")
        Else
            If intkbn = 0 Then
                strSQL.Append("WHERE ROWNUM <= " & ConstC.pScrollMax)
            Else
                strSQL.Append("WHERE ROWNUM <= " & ConstC.pScrollMax + 1)
            End If

        End If
        'If intkbn = 0 Then
        '    strSQL.Append("WHERE ROWNUM <= " & ConstC.pScrollMax)
        'Else
        '    strSQL.Append("WHERE ROWNUM <= " & ConstC.pScrollMax + 1)
        'End If
        '-------------------------------------------------------------------↑↑↑
        If SDLSTJAG00_C.pLOGIN_FLG = "1" Then
            '監視センターメニューより遷移時
            Dim i As Integer
            Dim arrTemp() As String
            Dim strCenter As String = ""
            arrTemp = SDLSTJAG00_C.pLOGIN_ALLCENTERCD.Split(Convert.ToChar(","))
            For i = 0 To arrTemp.Length - 1
                If strCenter.Length > 0 Then
                    strCenter = strCenter & ","
                End If
                strCenter = strCenter & "'" & arrTemp(i) & "'"
            Next
            strSQL.Append("  AND TAI.KANSCD IN (" & strCenter & ") ")
            '--2005/05/25 ADD (出動会社コードがNULL以外のものを取得する) 
            strSQL.Append("  AND TAI.STD_CD IS NOT NULL ")
            '2013/12/12 T.Ono add 監視改善2013 クライアント・JAの指定追加
            If SDLSTJAG00_C.pCLI_CD.Length > 0 Then
                strSQL.Append("  AND TAI.KURACD = :CLI_CD ")
            End If
            If SDLSTJAG00_C.pJA_CD.Length > 0 Then
                strSQL.Append("  AND TAI.JACD = :JA_CD ")
            End If
            ' 2014/10/21 H.Hosoda add 2014改善開発 No10 START
            If SDLSTJAG00_C.pGROUP_CD.Length > 0 Then
                strSQL.Append("  AND TAI.HANJICD = :GROUP_CD ")
            End If
            ' 2014/10/21 H.Hosoda add 2014改善開発 No10 END
        Else
            '通常出動会社ログイン画面より遷移時
            strSQL.Append("  AND TAI.STD_CD  = :SHUTU_CD ")
            'strSQL.Append("  AND TAI.STD_KYOTEN_CD  = :KYOTEN_CD ")    '--- 2005/07/20 DEL Falcon
        End If
        If SDLSTJAG00_C.pSYU_CD.Length > 0 Then         '-- 2005/05/25 IF文追加
            strSQL.Append("  AND SH.SHUTU_CD  = TAI.STD_CD ")
            strSQL.Append("  AND SH.KYOTEN_CD  = TAI.STD_KYOTEN_CD ")
            strSQL.Append("  AND SH.KANSI_CD  = TAI.KANSCD ")
        End If
        '発生日
        If SDLSTJAG00_C.pSIJIYMD_F.Length > 0 And SDLSTJAG00_C.pSIJIYMD_T.Length > 0 Then
            strSQL.Append(" AND TAI.HATYMD BETWEEN :HATYMD_From AND :HATYMD_To ")
        End If
        '対応区分（2:出動指示　を対象）
        strSQL.Append(" AND TAI.TAIOKBN = '2' ")

        ' 2014/10/21 H.Hosoda コメント→復活 2014改善開発 No10 START
        '処理区分（2:処理済み　を対象）
        strSQL.Append(" AND TAI.TMSKB = '2' ") ' 2008/10/15 T.Watabe edit
        ' 2014/10/21 H.Hosoda コメント→復活 2014改善開発 No10 END

        ''出動会社処理区分（2:処理済み　を対象）
        strSQL.Append(" AND TAI.SDSKBN = '2' ")

        '--- ↓2005/07/12 ADD Falcon↓ ---
        '復帰対応状況（8:緊急出動（委託先） を対象）
        strSQL.Append(" AND TAI.TFKICD = '8' ")
        '--- ↑2005/07/12 ADD Falcon↑ ---

        If intkbn = 0 Then
            '固定SQL
            strSQL.Append("  AND '08'   = P08.KBN(+) ")
            strSQL.Append("  AND TAI.HATKBN = P08.CD(+) ")
            ' 2014/10/21 H.Hosoda mod 2014改善開発 No10 START
            'strSQL.Append("ORDER BY TAI.HATYMD DESC,TAI.HATTIME DESC ")
            strSQL.Append("ORDER BY TAI.HATYMD DESC,TAI.HATTIME DESC,TAI.SYONO DESC ")
            ' 2014/10/21 H.Hosoda mod 2014改善開発 No10 END
            strSQL.Append(") A") '2013/12/10 add T.Ono 監視改善2013
        End If

        '//パラメータのセット ------
        If SDLSTJAG00_C.pLOGIN_FLG = "1" Then
            '監視センターメニューより遷移時
            '上記で文字列の結合を行っている為パラメータ無し

            '2013/12/12 T.Ono add 監視改善2013 クライアント・JAの指定追加
            If SDLSTJAG00_C.pCLI_CD.Length > 0 Then
                SqlParamC.fncSetParam("CLI_CD", True, SDLSTJAG00_C.pCLI_CD)
            End If
            If SDLSTJAG00_C.pJA_CD.Length > 0 Then
                SqlParamC.fncSetParam("JA_CD", True, SDLSTJAG00_C.pJA_CD)
            End If
            ' 2014/10/21 H.Hosoda add 2014改善開発 No10 START
            If SDLSTJAG00_C.pGROUP_CD.Length > 0 Then
                SqlParamC.fncSetParam("GROUP_CD", True, SDLSTJAG00_C.pGROUP_CD)
            End If
            ' 2014/10/21 H.Hosoda add 2014改善開発 No10 END
        Else
            '通常出動会社ログイン画面より遷移時
            SqlParamC.fncSetParam("SHUTU_CD", True, SDLSTJAG00_C.pSYU_CD)
            'SqlParamC.fncSetParam("KYOTEN_CD", True, "00") '--- 2005/07/20 DEL Falcon
        End If
        '発生日
        If SDLSTJAG00_C.pSIJIYMD_F.Length > 0 And SDLSTJAG00_C.pSIJIYMD_T.Length > 0 Then
            SqlParamC.fncSetParam("HATYMD_From", True, SDLSTJAG00_C.pSIJIYMD_F)
            SqlParamC.fncSetParam("HATYMD_To", True, SDLSTJAG00_C.pSIJIYMD_T)
        End If
    End Sub

End Class
