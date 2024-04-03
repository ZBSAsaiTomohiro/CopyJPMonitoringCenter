'***********************************************
'顧客検索  一覧画面
'***********************************************
'2012/03/08 T.Watabe パラメータクエリの不具合を解消するために変更
Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common
Imports JPG.Common.log
Imports System.Text

Partial Class MSKOSJFG00
    Inherits System.Web.UI.Page
    Protected WithEvents dbData As System.Data.DataSet

    Protected MSKOSJAG00_C As MSKOSJAG00
    Protected ConstC As New CConst

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
    Private strMsg As New StringBuilder("")

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
    ' Page_Load
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
        '[顧客検索]使用可能権限(運:○/営:×→○/監:△/出:×)
        'AuthC.fncAuthCheck(Server, AuthC.pGROUP_UNKOU & "," & AuthC.pGROUP_KANSHI) '2017/07/20 H.Mori mod
        AuthC.fncAuthCheck(Server, AuthC.pGROUP_UNKOU & "," & AuthC.pGROUP_KANSHI & "," & AuthC.pGROUP_EIGYOU)

        '対応入力
        If hdnJUMP.Value = "KETAIJAG00" Then
            Server.Transfer("../../../KE/KETAIJAG/KETAIJAG00/KETAIJAG00.aspx")
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
        '独自のスクリプト
        strScript.Append(cscript1.mWriteScript( _
             MyBase.MapPath("../../../MS/MSKOSJAG/MSKOSJAG00/") & "MSKOSJFG00.js"))
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
        MSKOSJAG00_C = CType(Context.Handler, MSKOSJAG00)
        '//------------------------------------------
        '********************************************

        '//-------------------------------------------------
        '<TODO>自分の画面IDをHIDDENのhdnMyAspxに書き込む（システム共通）
        hdnMyAspx.Value = "MSKOSJAG00"
        '//-------------------------------------------------

        Dim strKEY_CLI_CD As String
        Dim strKEY_JA_CD As String      '2013/12/09 T.Ono add 監視改善2013
        Dim strKEY_HAN_GRP As String    '2014/12/03 H.Hosoda add 監視改善2014 No.6
        'Dim strKEY_KINREN_GRP As String '2016/11/22 H.Mori add 監視改善2016 No2-1  2019/11/01 T.Ono del 監視改善2019 No1
        Dim strKEY_HAN_CD As String
        Dim strKEY_USER_CD As String

        strKEY_CLI_CD = MSKOSJAG00_C.pKEY_CLI_CD
        strKEY_JA_CD = MSKOSJAG00_C.pKEY_JA_CD                      '2013/12/09 T.Ono add 監視改善2013
        strKEY_HAN_GRP = MSKOSJAG00_C.pKEY_HAN_GRP                  '2014/12/03 H.Hosoda add 監視改善2014 No.6
        'strKEY_KINREN_GRP = MSKOSJAG00_C.pKEY_KINREN_GRP           '2016/11/22 H.Mori add 監視改善2016 No2-1  2019/11/01 T.Ono del 監視改善2019 No1
        strKEY_HAN_CD = MSKOSJAG00_C.pKEY_HAN_CD
        strKEY_USER_CD = MSKOSJAG00_C.pKEY_USER_CD

        hdnMOVE_KANSCD.Value = MSKOSJAG00_C.pKANSCD
        hdnMOVE_TEL.Value = MSKOSJAG00_C.pTEL
        'hdnMOVE_NCUTEL.Value = MSKOSJAG00_C.pNCUTEL                 '2014/12/02 H.Hosoda add 監視改善2014 No.6 '2016/11/16 H.Mori del 2016改善開発 No2-3
        hdnMOVE_NAME.Value = MSKOSJAG00_C.pNAME
        'hdnMOVE_KANAD.Value = MSKOSJAG00_C.pKANA                   '2016/11/16 H.Mori del 2016改善開発 No2-4
        hdnMOVE_ADDR.Value = MSKOSJAG00_C.pADDR                     '2013/12/09 T.Ono add 監視改善2013
        hdnMOVE_CLI_CD.Value = MSKOSJAG00_C.pCLI_CD
        hdnMOVE_CLI_CD_NAME.Value = MSKOSJAG00_C.pCLI_CD_NAME
        hdnMOVE_CLI_CD_TO.Value = MSKOSJAG00_C.pCLI_CD_TO           '2019/11/01 T.Ono add 監視改善2019 No1
        hdnMOVE_CLI_CD_TO_NAME.Value = MSKOSJAG00_C.pCLI_CD_TO_NAME '2019/11/01 T.Ono add 監視改善2019 No1
        hdnMOVE_JA_CD.Value = MSKOSJAG00_C.pJA_CD                   '2013/12/09 T.Ono add 監視改善2013
        hdnMOVE_JA_CD_NAME.Value = MSKOSJAG00_C.pJA_CD_NAME         '2013/12/09 T.Ono add 監視改善2013
        hdnMOVE_JA_CD_CLI.Value = MSKOSJAG00_C.pJA_CD_CLI           '2019/11/01 T.Ono add 監視改善2019
        hdnMOVE_HAN_GRP.Value = MSKOSJAG00_C.pHAN_GRP               '2014/12/03 H.Hosoda add 監視改善2014 No.6
        hdnMOVE_HAN_GRP_NAME.Value = MSKOSJAG00_C.pHAN_GRP_NAME     '2014/12/03 H.Hosoda add 監視改善2014 No.6
        '2019/11/01 T.Ono del 監視改善2019 No1
        'hdnMOVE_KINREN_GRP.Value = MSKOSJAG00_C.pKINREN_GRP               '2016/11/22 H.Mori add 監視改善2016 No2-1
        'hdnMOVE_KINREN_GRP_NAME.Value = MSKOSJAG00_C.pKINREN_GRP_NAME     '2016/11/22 H.Mori add 監視改善2016 No2-1
        hdnMOVE_HAN_CD.Value = MSKOSJAG00_C.pHAN_CD
        hdnMOVE_HAN_CD_NAME.Value = MSKOSJAG00_C.pHAN_CD_NAME
        hdnMOVE_HAN_CD_CLI.Value = MSKOSJAG00_C.pHAN_CD_CLI               '2019/11/01 T.Ono add 監視改善2019
        hdnMOVE_HAN_CD_TO.Value = MSKOSJAG00_C.pHAN_CD_TO                 '2016/11/24 H.Mori add 監視改善2016 No2-2
        hdnMOVE_HAN_CD_NAME_TO.Value = MSKOSJAG00_C.pHAN_CD_NAME_TO       '2016/11/24 H.Mori add 監視改善2016 No2-2
        hdnMOVE_HAN_CD_TO_CLI.Value = MSKOSJAG00_C.pHAN_CD_TO_CLI         '2019/11/01 T.Ono add 監視改善2019
        hdnMOVE_USER_CD.Value = MSKOSJAG00_C.pUSER_CD
        hdnMOVE_USER_FLG0.Value = MSKOSJAG00_C.pUSER_FLG0           '2013/12/20 T.Ono add 監視改善2013
        hdnMOVE_USER_FLG1.Value = MSKOSJAG00_C.pUSER_FLG1           '2013/12/20 T.Ono add 監視改善2013
        hdnMOVE_USER_FLG2.Value = MSKOSJAG00_C.pUSER_FLG2           '2013/12/20 T.Ono add 監視改善2013
        hdnMOVE_HANBAI_KBN1.Value = MSKOSJAG00_C.pHANBAI_KBN1       '2015/12/11 H.Mori add 監視改善2015
        hdnMOVE_HANBAI_KBN2.Value = MSKOSJAG00_C.pHANBAI_KBN2       '2015/12/11 H.Mori add 監視改善2015
        hdnMOVE_HANBAI_KBN3.Value = MSKOSJAG00_C.pHANBAI_KBN3       '2015/12/11 H.Mori add 監視改善2015
        hdnMOVE_HANBAI_KBN4.Value = MSKOSJAG00_C.pHANBAI_KBN4       '2015/12/11 H.Mori add 監視改善2015
        hdnMOVE_HANBAI_KBN5.Value = MSKOSJAG00_C.pHANBAI_KBN5       '2015/12/11 H.Mori add 監視改善2015
        hdnMOVE_HANBAI_KBN6.Value = MSKOSJAG00_C.pHANBAI_KBN6       '2015/12/11 H.Mori add 監視改善2015

        'ＣＴＩ未登録フラグ
        hdnMOVE_MITOKBN.Value = MSKOSJAG00_C.pMITOKBN

        'スクロール位置
        hdnScrollTop.Value = MSKOSJAG00_C.pScrollTop                '2013/12/10 T.Ono add 監視改善2013

        '<TODO>画面オブジェクトを使用可能にする
        strMsg.Append("parent.Form1.btnSelect.disabled=false;")
        strMsg.Append("parent.Form1.btnExcel.disabled=false;")      '2017/02/06 W.Ganeko add 監視改善2016
        strMsg.Append("parent.Form1.btnExit.disabled=false;")
        strMsg.Append("parent.Form1.btnTAIO.disabled=false;")
        strMsg.Append("parent.Form1.btnCLI_CD.disabled=false;")
        strMsg.Append("parent.Form1.btnCLI_CD_TO.disabled=false;")  '2019/11/01 T.Ono add 監視改善2019 No1
        strMsg.Append("parent.Form1.btnJA_CD.disabled=false;")      '2013/12/09 T.Ono add 監視改善2013
        strMsg.Append("parent.Form1.btnHANGRP.disabled=false;")    '2014/12/03 H.Hosoda add 監視改善2014 No.6
        'strMsg.Append("parent.Form1.btnKINRENGRP.disabled=false;") '2016/11/22 H.Mori add 監視改善2016 No2-1  2019/11/01 監視改善2019 No1
        strMsg.Append("parent.Form1.btnHAN_CD.disabled=false;")
        strMsg.Append("parent.Form1.btnHAN_CD_TO.disabled=false;")    '2016/11/24 H.Mori add 監視改善2016 No2-2
        strMsg.Append("window.scroll( 0, " & hdnScrollTop.Value & ");") 'スクロール位置 2013/12/09 T.Ono add 監視改善2013

        Dim strRec As String = ""

        Try
            '//------------------------------------------
            Dim SQLC As New MSKOSJAG00CCSQL.CSQL
            Dim SqlParamC As New CSQLParam
            Dim strSQL As New StringBuilder

            '//------------------------------------------
            '//MAX件数チェック
            Dim intCount As Integer

            If MSKOSJAG00_C.pSelectClick = "1" Then
                Dim dbCnt As DataSet
                strSQL = New StringBuilder("")
                '検索ボタンが押されている場合のみ件数チェックを行う
                Call mMakeSQL(strSQL, SqlParamC, 1, 0)
                dbCnt = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)
                If Convert.ToInt32(dbCnt.Tables(0).Rows(0).Item("CNT")) > ConstC.pScrollMax Then
                    strMsg.Append("alert('最大出力件数を超えました。条件を指定して再度検索してください');")
                End If
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

            '取得データの編集を行う-----------------------------
            Dim intRow As Integer

            If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
                If MSKOSJAG00_C.pSelectClick = "1" Then
                    '//検索ボタン押下によるデータ０件
                    strMsg.Append("alert('対象データが存在しません');")
                    strRec = "データが存在しません"
                End If

                dbData.Tables(0).Rows(0).Item("JS_CLI_CD") = ""         'JSリンク出力用
                dbData.Tables(0).Rows(0).Item("JS_HAN_CD") = ""
                dbData.Tables(0).Rows(0).Item("JS_USER_CD") = ""
                dbData.Tables(0).Rows(0).Item("CH_CLI_CD") = ""         '遷移チェック用
                dbData.Tables(0).Rows(0).Item("CH_HAN_CD") = ""
                dbData.Tables(0).Rows(0).Item("CH_USER_CD") = ""
                dbData.Tables(0).Rows(0).Item("ROWNO") = ""
                dbData.Tables(0).Rows(0).Item("COLOR") = ""             'SPANカラー
                dbData.Tables(0).Rows(0).Item("CLS") = ""               'SPANクラス
                dbData.Tables(0).Rows(0).Item("JCODE") = ""             '需要家コード
                dbData.Tables(0).Rows(0).Item("NAME") = ""              '需要家名
                dbData.Tables(0).Rows(0).Item("KANA") = ""              '需要家カナ
                dbData.Tables(0).Rows(0).Item("TEL") = ""               '需要家電話番号
                dbData.Tables(0).Rows(0).Item("NCUTEL") = ""            '結線番号 2014/12/02 H.Hosoda add 監視改善2014 No.6 
                dbData.Tables(0).Rows(0).Item("ADDR") = ""              '需要家住所
            Else

                Dim strJsCode As New StringBuilder("")
                Dim EscapeC As New CEscape

                Dim strTemp As String

                strMsg.Append("parent.Form1.btnSelect.focus();")

                For intRow = 0 To dbData.Tables(0).Rows.Count - 1
                    'HtmlのJsにて使用する
                    dbData.Tables(0).Rows(intRow).Item("ROWNO") = _
                        EscapeC.mDb_Js(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("ROWNO")))
                    dbData.Tables(0).Rows(intRow).Item("JS_CLI_CD") = _
                        EscapeC.mDb_Js(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("JS_CLI_CD")))
                    dbData.Tables(0).Rows(intRow).Item("JS_HAN_CD") = _
                        EscapeC.mDb_Js(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("JS_HAN_CD")))
                    dbData.Tables(0).Rows(intRow).Item("JS_USER_CD") = _
                        EscapeC.mDb_Js(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("JS_USER_CD")))
                    'Htmlの値として使用する
                    dbData.Tables(0).Rows(intRow).Item("JCODE") = _
                        EscapeC.mDb_Html(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("JCODE")))
                    dbData.Tables(0).Rows(intRow).Item("NAME") = _
                        EscapeC.mDb_Html(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("NAME")))
                    dbData.Tables(0).Rows(intRow).Item("KANA") = _
                        EscapeC.mDb_Html(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("KANA")))
                    dbData.Tables(0).Rows(intRow).Item("TEL") = _
                        EscapeC.mDb_Html(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("TEL")))
                    dbData.Tables(0).Rows(intRow).Item("NCUTEL") = _
                        EscapeC.mDb_Html(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("NCUTEL")))    '2014/12/02 H.Hosoda add 監視改善2014 No.6
                    dbData.Tables(0).Rows(intRow).Item("ADDR") = _
                        EscapeC.mDb_Html(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("ADDR")))

                    '//登録画面より戻ってきた時の画面遷移時に、指定したデータの色を変更する
                    If (strKEY_CLI_CD = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("CH_CLI_CD")) And _
                        strKEY_HAN_CD = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("CH_HAN_CD")) And _
                        strKEY_USER_CD = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("CH_USER_CD"))) Then
                        dbData.Tables(0).Rows(intRow).Item("COLOR") = "GreenYellow"
                        dbData.Tables(0).Rows(intRow).Item("CLS") = "CHK"
                    Else
                        dbData.Tables(0).Rows(intRow).Item("COLOR") = "skyblue"
                        dbData.Tables(0).Rows(intRow).Item("CLS") = ""
                    End If

                    '//需要家コードにリンクをつけ、顧客登録もしくは対応入力(電話対応)に遷移する
                    strJsCode = New StringBuilder("")
                    strJsCode.Append("<a href=""JavaScript:fncJump(")
                    strJsCode.Append("'" & Convert.ToString(dbData.Tables(0).Rows(intRow).Item("JS_CLI_CD")) & "',")
                    strJsCode.Append("'" & Convert.ToString(dbData.Tables(0).Rows(intRow).Item("JS_HAN_CD")) & "',")
                    strJsCode.Append("'" & Convert.ToString(dbData.Tables(0).Rows(intRow).Item("JS_USER_CD")) & "'")
                    strJsCode.Append(")"">")
                    strJsCode.Append(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("JCODE")))
                    strJsCode.Append("</a>")

                    dbData.Tables(0).Rows(intRow).Item("JCODE") = strJsCode.ToString
                Next

                'スクロール位置指定 2013/12/10 T.Ono add 監視改善2013
                'strMsg.Append("window.scroll( 0, " & hdnScrollTop.Value & ");")

            End If

            '// リピータにバインドする--------------------
            rptData.DataBind()
            '********************************************
            If MSKOSJAG00_C.pSelectClick = "1" Then
                If strRec.Length = 0 Then       '[データが存在しません]のメッセージを出力
                    strRec = "OK"
                End If
            End If
        Catch ex As Exception
            strRec = ex.ToString
            Dim ErrMsgC As New CErrMsg
            strMsg.Append("alert('システムエラー：" & ErrMsgC.mGetArtMsg(strRec) & "');")
        End Try

        If MSKOSJAG00_C.pSelectClick = "1" Then
            '//検索ボタン押下による画面出力の場合は検索ボタンにフォーカスセット
            '//初期出力時は親画面での制御に任せる
            '<TODO>検索後のフォーカスをセットする
            strMsg.Append("parent.Form1.btnSelect.focus();")

            '-------------------------------------------------
            '//ＡＰログ書き込み
            Dim LogC As New CLog
            Dim strRecLog As String
            '2012/04/04 NEC ou Upd
            'strRecLog = LogC.mAPLog(Request.Cookies.Get("ASP.NET_SessionId").Value, AuthC.pUSERNAME, AuthC.pIPADDRESS, hdnMyAspx.Value, "4", strRec, Request.Form)
            strRecLog = LogC.mAPLog(Me.Session.SessionID, AuthC.pUSERNAME, AuthC.pIPADDRESS, hdnMyAspx.Value, "4", strRec, Request.Form)
            '2012/04/04 NEC ou Upd
            If strRecLog <> "OK" Then
                Dim errmsgc As New CErrMsg
                strMsg.Append("alert('システムエラー：" & errmsgc.mgetartmsg(strRecLog) & "');")
            End If
        End If
    End Sub

    '******************************************************************************
    '*　概　要：ＳＱＬ作成
    '*　備　考：
    '******************************************************************************
    Private Sub mMakeSQL(ByVal strSQL As StringBuilder, ByVal SqlParamC As CSQLParam, ByVal intkbn As Integer, ByVal intCount As Integer)

        '2013/12/06 T.Ono add 監視改善2013
        'ORDER BYをした後に№を取得しないと、順序よく並ばないため
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
                'strSQL.Append("LPAD(ROWNUM,3,0) AS ROWNO, ")   '2013/12/10 T.Ono mod 監視改善2013　9999件対応
                strSQL.Append("LPAD(ROWNUM,4,0) AS ROWNO, ")
                strSQL.Append("	'' AS COLOR, ")                                              'SPANカラー
                strSQL.Append("	'' AS CLS, ")                                                'SPANクラス
                strSQL.Append("	SH.CLI_CD AS JS_CLI_CD, ")
                strSQL.Append("	SH.HAN_CD AS JS_HAN_CD, ")
                strSQL.Append("	SH.USER_CD AS JS_USER_CD, ")
                strSQL.Append("	SH.CLI_CD AS CH_CLI_CD, ")
                strSQL.Append("	SH.HAN_CD AS CH_HAN_CD, ")
                strSQL.Append("	SH.USER_CD AS CH_USER_CD, ")
                strSQL.Append("	SH.HAN_CD || SH.USER_CD AS JCODE, ")
                strSQL.Append("	SH.NAME, ")
                '2014/12/02 H.Hosoda mod 監視改善2014 No.6 START
                'strSQL.Append("	SH.KANA, ")
                strSQL.Append("	SUBSTR(SH.KANA,1,10) AS KANA, ")
                '2014/12/02 H.Hosoda mod 監視改善2014 No.6 END
                strSQL.Append("	SH.KANKENSAKU_TEL AS TEL, ")
                strSQL.Append("	SH.NCU_TELA || SH.NCU_TELB AS NCUTEL, ")        '2014/12/02 H.Hosoda add 監視改善2014 No.6
                strSQL.Append("	SH.ADD_1 || SH.ADD_2 || SH.ADD_3 AS ADDR ")
                strSQL.Append("FROM SHAMAS SH, ")
                '''''strSQL.Append("     LEFT JOIN CLIMAS CL ")
                '''''strSQL.Append("     ON SH.CLI_CD = CL.CLI_CD ")
                strSQL.Append("     CLIMAS CL ")
            Else
                strSQL.Append("'XYZ' AS ROWNO, ")
                strSQL.Append("	'' AS COLOR, ")
                strSQL.Append("	'' AS CLS, ")
                strSQL.Append("	'' AS JS_CLI_CD, ")
                strSQL.Append("	'' AS JS_HAN_CD, ")
                strSQL.Append("	'' AS JS_USER_CD, ")
                strSQL.Append("	'' AS CH_CLI_CD, ")
                strSQL.Append("	'' AS CH_HAN_CD, ")
                strSQL.Append("	'' AS CH_USER_CD, ")
                strSQL.Append("	'' AS JCODE, ")
                strSQL.Append("	'' AS NAME, ")
                strSQL.Append("	'' AS KANA, ")
                strSQL.Append("	'' AS TEL, ")
                strSQL.Append("	'' AS NCUTEL, ")  '2014/12/02 H.Hosoda add 監視改善2014 No.6
                strSQL.Append("	'' AS ADDR ")
                strSQL.Append("FROM DUAL ")
                strSQL.Append(") A") '2013/12/09 add T.Ono 監視改善2013
                Exit Sub
            End If
        Else
            '//件数カウント用のSQL
            strSQL.Append("COUNT(*) AS CNT ")       'カウント
            strSQL.Append("FROM SHAMAS SH, ")
            '''''strSQL.Append("     LEFT JOIN CLIMAS CL ")
            '''''strSQL.Append("     ON SH.CLI_CD = CL.CLI_CD ")
            strSQL.Append("     CLIMAS CL ")
        End If

        If intkbn = 0 Then
            strSQL.Append("  WHERE ROWNUM <= " & ConstC.pScrollMax)
            strSQL.Append("    AND SH.CLI_CD = CL.CLI_CD(+) ")
        Else
            strSQL.Append("  WHERE ROWNUM <= " & ConstC.pScrollMax + 1)
            strSQL.Append("    AND SH.CLI_CD = CL.CLI_CD(+) ")
        End If
        '監視センター
        If MSKOSJAG00_C.pKANSCD.Length > 0 Then
            strSQL.Append(" AND SH.CLI_CD = CL.CLI_CD ")
            strSQL.Append(" AND CL.KANSI_CODE = :KANSCD ")
        Else
            '監視センターの指定がない場合は、認証クラスからセンターコードを取得
            Dim strCenter As String = ""
            Dim arrTemp() As String
            arrTemp = AuthC.pAUTHCENTERCD.Split(Convert.ToChar(","))
            For i As Integer = 0 To arrTemp.Length - 1
                If strCenter.Length > 0 Then
                    strCenter = strCenter & ","
                End If
                strCenter = strCenter & "'" & arrTemp(i) & "'"
            Next
            strSQL.Append(" AND SH.CLI_CD = CL.CLI_CD ")
            strSQL.Append(" AND CL.KANSI_CODE IN (" & strCenter & ") ")
        End If
        '需要家電話番号
        If MSKOSJAG00_C.pTEL.Length > 0 Then
            'strSQL.Append(" AND SH.KANKENSAKU_TEL LIKE :TEL || '%' ") '2012/03/08 T.Watabe edit
            '2014/12/02 H.Hosoda mod 監視改善2014 No.6 START
            'strSQL.Append(" AND SH.KANKENSAKU_TEL LIKE :TEL ")
            'strSQL.Append(" AND REPLACE(SH.KANKENSAKU_TEL,'-','') ") '2015/01/23 T.Ono mod 監視改善2014 No.6
            '連絡先2,3　2016/1/29 H.Mori mod 監視改善2015 START
            'strSQL.Append(" AND REPLACE(REPLACE(SH.KANKENSAKU_TEL,'-',''), ' ','') ")
            'strSQL.Append("  LIKE REPLACE(:TEL,'-','') ")
            strSQL.Append(" AND (REPLACE(REPLACE(SH.KANKENSAKU_TEL,'-',''), ' ','') ")
            strSQL.Append("  LIKE REPLACE(:TEL,'-','') ")
            strSQL.Append(" OR REPLACE(REPLACE(SH.RENTEL2,'-',''), ' ','') ")
            strSQL.Append("  LIKE REPLACE(:TEL,'-','') ")
            strSQL.Append(" OR REPLACE(REPLACE(SH.RENTEL3,'-',''), ' ','') ")
            strSQL.Append("  LIKE REPLACE(:TEL,'-','') ")
            '2016/11/16,12/22 H.Mori add 2016改善開発 No2-3 START
            strSQL.Append(" OR REPLACE(REPLACE(SH.NCU_TELA || SH.NCU_TELB,'-',''), ' ', '') ")
            strSQL.Append("  LIKE REPLACE(:TEL,'-','') ")
            strSQL.Append(" OR REPLACE(REPLACE(SH.TELA || SH.TELB,'-',''), ' ', '') ")
            strSQL.Append("  LIKE REPLACE(:TEL,'-','') ")
            strSQL.Append(" OR REPLACE(REPLACE(SH.DAI3RENDORENTEL,'-',''), ' ', '') ")
            strSQL.Append("  LIKE REPLACE(:TEL,'-','')) ")
            '2016/11/16,12/22 H.Mori add 2016改善開発 No2-3 END
            '連絡先2,3　2016/1/29 H.Mori mod 監視改善2015 END
            '2014/12/02 H.Hosoda mod 監視改善2014 No.6 END
        End If
        '2016/11/16 H.Mori del 2016改善開発 No2-3 START
        ''2014/12/02 H.Hosoda add 監視改善2014 No.6 START
        ''結線番号
        'If MSKOSJAG00_C.pNCUTEL.Length > 0 Then
        '    'strSQL.Append(" AND REPLACE(SH.NCU_TELA || SH.NCU_TELB,'-','') ") 2015/01/23 T.Ono mod 監視改善2014 No.6
        '    strSQL.Append(" AND REPLACE(REPLACE(SH.NCU_TELA || SH.NCU_TELB,'-',''), ' ', '') ")
        '    strSQL.Append("  LIKE REPLACE(:NCUTEL,'-','') ")
        'End If
        ''2014/12/02 H.Hosoda add 監視改善2014 No.6 END
        '2016/11/16 H.Mori del 2016改善開発 No2-3 END
        '需要家名
        If MSKOSJAG00_C.pNAME.Length > 0 Then
            'strSQL.Append(" AND SH.NAME LIKE :NAME || '%' ") '2012/03/08 T.Watabe edit
            'strSQL.Append(" AND SH.NAME LIKE :NAME ") 2013/12/09 T.Ono add 監視改善2013
            'strSQL.Append(" AND UTL_I18N.TRANSLITERATE(TO_SINGLE_BYTE (SH.NAME), 'FWKATAKANA_HWKATAKANA') LIKE UTL_I18N.TRANSLITERATE(TO_SINGLE_BYTE (:NAME), 'FWKATAKANA_HWKATAKANA') ") '2014/04/02 T.Ono mod
            strSQL.Append(" AND (REPLACE(UTL_I18N.TRANSLITERATE(TO_SINGLE_BYTE (SH.NAME), 'FWKATAKANA_HWKATAKANA'),' ','') ")
            strSQL.Append("  LIKE REPLACE(UTL_I18N.TRANSLITERATE(TO_SINGLE_BYTE (:NAME), 'FWKATAKANA_HWKATAKANA'),' ','') ")
            strSQL.Append(" OR REPLACE(UTL_I18N.TRANSLITERATE(TO_SINGLE_BYTE (SH.KANA), 'FWKATAKANA_HWKATAKANA'),' ','') ")
            strSQL.Append("  LIKE REPLACE(UTL_I18N.TRANSLITERATE(TO_SINGLE_BYTE (:NAME), 'FWKATAKANA_HWKATAKANA'),' ','')) ")
        End If
        '2016/11/16 H.Mori del 2016改善開発 No2-4 START
        '需要家名カナ
        'If MSKOSJAG00_C.pKANA.Length > 0 Then
        '    'strSQL.Append(" AND SH.KANA LIKE :KANA || '%' ") '2012/03/08 T.Watabe edit
        '    'strSQL.Append(" AND SH.KANA LIKE :KANA ") 2013/12/09 T.Ono add 監視改善2013
        '    'strSQL.Append(" AND UTL_I18N.TRANSLITERATE(TO_SINGLE_BYTE (SH.KANA), 'FWKATAKANA_HWKATAKANA') LIKE UTL_I18N.TRANSLITERATE(TO_SINGLE_BYTE (:KANA), 'FWKATAKANA_HWKATAKANA') ") '2014/04/02 T.Ono mod
        '    strSQL.Append(" AND REPLACE(UTL_I18N.TRANSLITERATE(TO_SINGLE_BYTE (SH.KANA), 'FWKATAKANA_HWKATAKANA'),' ','') ")
        '    strSQL.Append("  LIKE REPLACE(UTL_I18N.TRANSLITERATE(TO_SINGLE_BYTE (:KANA), 'FWKATAKANA_HWKATAKANA'),' ','') ")
        'End If
        '2016/11/16 H.Mori del 2016改善開発 No2-4 END
        '需要家住所　2013/12/05 T.Ono add 監視改善2013
        If MSKOSJAG00_C.pADDR.Length > 0 Then
            'strSQL.Append(" AND SH.ADD_1 LIKE :ADD ")
            'strSQL.Append(" AND UTL_I18N.TRANSLITERATE(TO_SINGLE_BYTE (SH.ADD_1 || SH.ADD_2 || SH.ADD_3), 'FWKATAKANA_HWKATAKANA') LIKE UTL_I18N.TRANSLITERATE(TO_SINGLE_BYTE (:ADDR), 'FWKATAKANA_HWKATAKANA') ") '2014/04/02 T.Ono mod
            strSQL.Append(" AND REPLACE(UTL_I18N.TRANSLITERATE(TO_SINGLE_BYTE (SH.ADD_1 || SH.ADD_2 || SH.ADD_3), 'FWKATAKANA_HWKATAKANA'),' ','') ")
            strSQL.Append("  LIKE REPLACE(UTL_I18N.TRANSLITERATE(TO_SINGLE_BYTE (:ADDR), 'FWKATAKANA_HWKATAKANA'),' ','') ")
        End If
        'クライアントコード
        If MSKOSJAG00_C.pCLI_CD.Length > 0 Then
            '2019/11/01 T.Ono mod 監視改善2019 No1
            'strSQL.Append(" AND SH.CLI_CD = :CLI_CD ")
            strSQL.Append(" AND SH.CLI_CD >= :CLI_CD ")
            strSQL.Append(" AND SH.CLI_CD <= :CLI_CD_TO ")
        End If
        'ＪＡコード 2013/12/09 T.Ono add 監視改善2013
        If MSKOSJAG00_C.pJA_CD.Length > 0 Then
            '2019/11/01 T.Ono add 監視改善2019
            strSQL.Append(" AND SH.HAN_CD LIKE :JA_CD ")
        End If
        '販売事業者グループ 2014/12/04 H.Hosoda add 監視改善2014 No.6
        If MSKOSJAG00_C.pHAN_GRP.Length > 0 Then
            strSQL.Append(mMakeSQL_HANGRP())
        End If
        '2019/11/01 T.Ono del 監視改善2019 No1
        ''緊急連絡先Gr 2016/11/22 H.Mori add 監視改善2016 No2-1
        'If MSKOSJAG00_C.pKINREN_GRP.Length > 0 Then
        '    strSQL.Append(mMakeSQL_HANGRP())
        'End If
        'ＪＡ支所コード
        If MSKOSJAG00_C.pHAN_CD.Length > 0 Then
            ' 2011/11/15 MOD H.Uema JA支所コードをLike検索(前方一致)へ変更
            'strSQL.Append(" AND SH.HAN_CD = :HAN_CD ") 'DEL
            'strSQL.Append(" AND SH.HAN_CD LIKE :HAN_CD || '%' ") 'ADD '2012/03/08 T.Watabe edit
            'strSQL.Append(" AND SH.HAN_CD LIKE :HAN_CD ") 2013/12/09 T.Ono mod 監視改善2013
            'strSQL.Append(" AND SH.HAN_CD = :HAN_CD ") 2016/11/24 H.Mori mod 監視改善2016
            '2019/11/01 T.Ono mod 監視改善2019 No1
            'strSQL.Append(" AND SH.HAN_CD >= :HAN_CD ")
            'strSQL.Append(" AND SH.HAN_CD <= :HAN_CD_TO ")
            strSQL.Append(" AND SH.CLI_CD || SH.HAN_CD >= :HAN_CD_CLI || :HAN_CD ")
            strSQL.Append(" AND SH.CLI_CD || SH.HAN_CD <= :HAN_CD_TO_CLI || :HAN_CD_TO ")
        End If
        'お客様コード
        If MSKOSJAG00_C.pUSER_CD.Length > 0 Then
            'strSQL.Append(" AND SH.USER_CD LIKE :USER_CD || '%' ") '2012/03/08 T.Watabe edit
            strSQL.Append(" AND SH.USER_CD LIKE :USER_CD ")
        End If

        'お客様FLG　2013/12/05 T.Ono add 監視改善2013 START
        'If Not (MSKOSJAG00_C.pUSER_FLG0 = "0" And MSKOSJAG00_C.pUSER_FLG1 = "0" And MSKOSJAG00_C.pUSER_FLG2 = "0") Then
        strSQL.Append(" AND SH.USER_FLG IN (:USER_FLG0,:USER_FLG1,:USER_FLG2) ")
        'End If

        '販売区分　2015/12/11 H.Mori add 監視改善2015 START
        If MSKOSJAG00_C.pHANBAI_KBN1 = "1" AndAlso MSKOSJAG00_C.pHANBAI_KBN2 = "1" AndAlso MSKOSJAG00_C.pHANBAI_KBN3 = "1" AndAlso
            MSKOSJAG00_C.pHANBAI_KBN4 = "1" AndAlso MSKOSJAG00_C.pHANBAI_KBN5 = "1" AndAlso MSKOSJAG00_C.pHANBAI_KBN6 = "1" Then
        Else
            If MSKOSJAG00_C.pHANBAI_KBN1 = "1" OrElse MSKOSJAG00_C.pHANBAI_KBN2 = "1" OrElse MSKOSJAG00_C.pHANBAI_KBN3 = "1" OrElse
                MSKOSJAG00_C.pHANBAI_KBN4 = "1" Then
                If MSKOSJAG00_C.pHANBAI_KBN5 = "1" OrElse MSKOSJAG00_C.pHANBAI_KBN6 = "1" Then
                    If MSKOSJAG00_C.pHANBAI_KBN5 = "1" AndAlso MSKOSJAG00_C.pHANBAI_KBN6 = "1" Then
                        strSQL.Append(" AND (SH.HANBAI_KBN IN (:HANBAI_KBN1,:HANBAI_KBN2,:HANBAI_KBN3,:HANBAI_KBN4) ")
                        strSQL.Append(" OR  (SH.HANBAI_KBN IS NULL) ")
                        strSQL.Append(" OR  (SH.HANBAI_KBN NOT IN ('1','2','3','4') AND SH.HANBAI_KBN IS NOT NULL)) ")
                    Else
                        If MSKOSJAG00_C.pHANBAI_KBN5 = "1" Then
                            strSQL.Append(" AND (SH.HANBAI_KBN IN (:HANBAI_KBN1,:HANBAI_KBN2,:HANBAI_KBN3,:HANBAI_KBN4) ")
                            strSQL.Append(" OR  (SH.HANBAI_KBN IS NULL)) ")
                        Else
                            strSQL.Append(" AND (SH.HANBAI_KBN IN (:HANBAI_KBN1,:HANBAI_KBN2,:HANBAI_KBN3,:HANBAI_KBN4) ")
                            strSQL.Append(" OR  (SH.HANBAI_KBN NOT IN ('1','2','3','4') AND SH.HANBAI_KBN IS NOT NULL)) ")
                        End If
                    End If
                Else
                    strSQL.Append(" AND SH.HANBAI_KBN IN (:HANBAI_KBN1,:HANBAI_KBN2,:HANBAI_KBN3,:HANBAI_KBN4) ")
                End If
            Else
                If MSKOSJAG00_C.pHANBAI_KBN5 = "1" OrElse MSKOSJAG00_C.pHANBAI_KBN6 = "1" Then
                    If MSKOSJAG00_C.pHANBAI_KBN5 = "1" AndAlso MSKOSJAG00_C.pHANBAI_KBN6 = "1" Then
                        strSQL.Append(" AND ((SH.HANBAI_KBN IS NULL) ")
                        strSQL.Append(" OR  (SH.HANBAI_KBN NOT IN ('1','2','3','4') AND SH.HANBAI_KBN IS NOT NULL)) ")
                    Else
                        If MSKOSJAG00_C.pHANBAI_KBN5 = "1" Then
                            strSQL.Append(" AND (SH.HANBAI_KBN IS NULL) ")
                        Else
                            strSQL.Append(" AND (SH.HANBAI_KBN NOT IN ('1','2','3','4') AND SH.HANBAI_KBN IS NOT NULL) ")
                        End If
                    End If
                Else
                    strSQL.Append(" AND  1 <> 1 ")
                End If
            End If
        End If
        '販売区分　2015/12/14 H.Mori add 監視改善2015 END
        'データのソートを行なう
        If intkbn = 0 Then
            strSQL.Append("ORDER BY JS_CLI_CD, JS_HAN_CD, JS_USER_CD ")
            strSQL.Append(") A") '2013/12/09 add T.Ono 監視改善2013
        End If

        'パラメータのセット
        If MSKOSJAG00_C.pKANSCD.Length > 0 Then
            SqlParamC.fncSetParam("KANSCD", True, MSKOSJAG00_C.pKANSCD)
        End If
        If MSKOSJAG00_C.pTEL.Length > 0 Then
            'SqlParamC.fncSetParam("TEL", True, MSKOSJAG00_C.pTEL) '2012/03/08 T.Watabe edit
            SqlParamC.fncSetParam("TEL", True, MSKOSJAG00_C.pTEL & "%")
        End If
        '2016/11/16 H.Mori del 2016改善開発 No2-3 START
        '2014/12/02 H.Hosoda add 監視改善2014 No.6
        'If MSKOSJAG00_C.pNCUTEL.Length > 0 Then
        '    SqlParamC.fncSetParam("NCUTEL", True, MSKOSJAG00_C.pNCUTEL & "%")
        'End If
        '2016/11/16 H.Mori del 2016改善開発 No2-3 END
        If MSKOSJAG00_C.pNAME.Length > 0 Then
            'SqlParamC.fncSetParam("NAME", True, MSKOSJAG00_C.pNAME) '2012/03/08 T.Watabe edit
            SqlParamC.fncSetParam("NAME", True, MSKOSJAG00_C.pNAME & "%")
        End If
        '2016/11/16 H.Mori del 2016改善開発 No2-4 START
        'If MSKOSJAG00_C.pKANA.Length > 0 Then
        '    'SqlParamC.fncSetParam("KANA", True, MSKOSJAG00_C.pKANA) '2012/03/08 T.Watabe edit
        '    SqlParamC.fncSetParam("KANA", True, MSKOSJAG00_C.pKANA & "%")
        'End If
        '2016/11/16 H.Mori del 2016改善開発 No2-4 END
        '2013/12/05 T.Ono add 監視改善2013
        If MSKOSJAG00_C.pADDR.Length > 0 Then
            SqlParamC.fncSetParam("ADDR", True, MSKOSJAG00_C.pADDR & "%")
        End If
        '2019/11/01 T.Ono mod 監視改善2019 START
        'If MSKOSJAG00_C.pCLI_CD.Length > 0 Then
        '    SqlParamC.fncSetParam("CLI_CD", True, MSKOSJAG00_C.pCLI_CD)
        'End If
        ''2013/12/09 T.Ono add 監視改善2013
        'If MSKOSJAG00_C.pJA_CD.Length > 0 Then
        '    SqlParamC.fncSetParam("JA_CD", True, MSKOSJAG00_C.pJA_CD & "%")
        'End If
        If MSKOSJAG00_C.pJA_CD.Length > 0 Then
            SqlParamC.fncSetParam("JA_CD", True, MSKOSJAG00_C.pJA_CD & "%")
            SqlParamC.fncSetParam("CLI_CD", True, MSKOSJAG00_C.pJA_CD_CLI)
            SqlParamC.fncSetParam("CLI_CD_TO", True, MSKOSJAG00_C.pJA_CD_CLI)
        Else
            'JAが指定されない場合は、クライアント範囲指定
            If MSKOSJAG00_C.pCLI_CD.Length > 0 Then
                SqlParamC.fncSetParam("CLI_CD", True, MSKOSJAG00_C.pCLI_CD)
            End If
            If MSKOSJAG00_C.pCLI_CD_TO.Length > 0 Then
                SqlParamC.fncSetParam("CLI_CD_TO", True, MSKOSJAG00_C.pCLI_CD_TO)
            End If
        End If
        '2019/11/01 T.Ono mod 監視改善2019 END

        '2014/12/04 H.Hosoda add 監視改善2014 No.6 START
        If MSKOSJAG00_C.pHAN_GRP.Length > 0 Then
            SqlParamC.fncSetParam("HAN_GRP", True, MSKOSJAG00_C.pHAN_GRP)
            SqlParamC.fncSetParam("HAN_GRP_KBN", True, "001")
        End If
        '2014/12/04 H.Hosoda add 監視改善2014 No.6 END
        '2019/11/01 T.Ono del 監視改善2019 No1
        ''2016/11/22 H.Mori add 監視改善2016 No2-1 START
        'If MSKOSJAG00_C.pKINREN_GRP.Length > 0 Then
        '    SqlParamC.fncSetParam("HAN_GRP", True, MSKOSJAG00_C.pKINREN_GRP)
        '    SqlParamC.fncSetParam("HAN_GRP_KBN", True, "002")
        'End If
        ''2016/11/22 H.Mori add 監視改善2016 No2-1 END
        If MSKOSJAG00_C.pHAN_CD.Length > 0 Then
            'SqlParamC.fncSetParam("HAN_CD", True, MSKOSJAG00_C.pHAN_CD) '2012/03/08 T.Watabe edit
            'SqlParamC.fncSetParam("HAN_CD", True, MSKOSJAG00_C.pHAN_CD & "%") 2013/12/09 T.Ono mod 監視改善2013
            SqlParamC.fncSetParam("HAN_CD", True, MSKOSJAG00_C.pHAN_CD)
            SqlParamC.fncSetParam("HAN_CD_TO", True, MSKOSJAG00_C.pHAN_CD_TO)  '2016/11/24 H.Mori add 監視改善2016 No2-2
            '2019/11/01 T.Ono add 監視改善2019
            SqlParamC.fncSetParam("HAN_CD_CLI", True, MSKOSJAG00_C.pHAN_CD_CLI)
            SqlParamC.fncSetParam("HAN_CD_TO_CLI", True, MSKOSJAG00_C.pHAN_CD_TO_CLI)
        End If
        If MSKOSJAG00_C.pUSER_CD.Length > 0 Then
            'SqlParamC.fncSetParam("USER_CD", True, MSKOSJAG00_C.pUSER_CD) '2012/03/08 T.Watabe edit
            SqlParamC.fncSetParam("USER_CD", True, MSKOSJAG00_C.pUSER_CD & "%")
        End If
        ' 2013/12/05 T.Ono add 監視改善2013 START
        'チェックボックス　0：チェックなし　1：チェックあり
        'お客様FLG　0：未開通　1：運用中　2：休止中
        If MSKOSJAG00_C.pUSER_FLG0 = "0" Then
            SqlParamC.fncSetParam("USER_FLG0", True, "")
        Else
            SqlParamC.fncSetParam("USER_FLG0", True, "0")
        End If

        If MSKOSJAG00_C.pUSER_FLG1 = "0" Then
            SqlParamC.fncSetParam("USER_FLG1", True, "")
        Else
            SqlParamC.fncSetParam("USER_FLG1", True, "1")
        End If

        If MSKOSJAG00_C.pUSER_FLG2 = "0" Then
            SqlParamC.fncSetParam("USER_FLG2", True, "")
        Else
            SqlParamC.fncSetParam("USER_FLG2", True, "2")
        End If
        ' 2013/12/05 T.Ono add 監視改善2013 END
        ' 2015/12/11 H.Mori add 監視改善2015 START
        'チェックボックス　0：チェックなし　1：チェックあり
        '販売区分　1：メータ売　2：ボンベ売　3：両方　4：その他　5：データなし　6：例外
        If MSKOSJAG00_C.pHANBAI_KBN1 = "1" AndAlso MSKOSJAG00_C.pHANBAI_KBN2 = "1" AndAlso MSKOSJAG00_C.pHANBAI_KBN3 = "1" AndAlso
            MSKOSJAG00_C.pHANBAI_KBN4 = "1" AndAlso MSKOSJAG00_C.pHANBAI_KBN5 = "1" AndAlso MSKOSJAG00_C.pHANBAI_KBN6 = "1" Then
        Else
            If MSKOSJAG00_C.pHANBAI_KBN1 = "1" OrElse MSKOSJAG00_C.pHANBAI_KBN2 = "1" OrElse MSKOSJAG00_C.pHANBAI_KBN3 = "1" OrElse
                MSKOSJAG00_C.pHANBAI_KBN4 = "1" Then
                If MSKOSJAG00_C.pHANBAI_KBN1 = "1" Then
                    SqlParamC.fncSetParam("HANBAI_KBN1", True, "1")
                Else
                    SqlParamC.fncSetParam("HANBAI_KBN1", True, "")
                End If
                If MSKOSJAG00_C.pHANBAI_KBN2 = "1" Then
                    SqlParamC.fncSetParam("HANBAI_KBN2", True, "2")
                Else
                    SqlParamC.fncSetParam("HANBAI_KBN2", True, "")
                End If
                If MSKOSJAG00_C.pHANBAI_KBN3 = "1" Then
                    SqlParamC.fncSetParam("HANBAI_KBN3", True, "3")
                Else
                    SqlParamC.fncSetParam("HANBAI_KBN3", True, "")
                End If
                If MSKOSJAG00_C.pHANBAI_KBN4 = "1" Then
                    SqlParamC.fncSetParam("HANBAI_KBN4", True, "4")
                Else
                    SqlParamC.fncSetParam("HANBAI_KBN4", True, "")
                End If
            End If
        End If
        ' 2015/12/11 H.Mori add 監視改善2015 END
    End Sub

    '******************************************************************************
    '*　概　要：ＳＱＬ作成（販売事業者グループ条件）
    '*　備　考：
    '******************************************************************************
    Private Function mMakeSQL_HANGRP() As String

        Dim strSQL As New StringBuilder("")

        strSQL.Append(" AND EXISTS ( ")
        strSQL.Append("SELECT * FROM ( ")
        '2019/11/01 T.Ono mod 監視改善2019 No1
        'strSQL.Append("WITH T_SH AS (SELECT SH.CLI_CD,SH.HAN_CD,SH.USER_CD FROM SHAMAS SH WHERE SH.CLI_CD= :CLI_CD), ")
        'strSQL.Append("     T_JG AS (SELECT JG.KBN,JG.KURACD,JG.ACBCD,JG.GROUPCD,JG.USERCD_FROM,JG.USERCD_TO FROM M09_JAGROUP JG WHERE JG.KBN = :HAN_GRP_KBN AND JG.KURACD = :CLI_CD) ")
        strSQL.Append("WITH T_SH AS (SELECT SH.CLI_CD,SH.HAN_CD,SH.USER_CD FROM SHAMAS SH WHERE SH.CLI_CD >= :CLI_CD AND SH.CLI_CD <= :CLI_CD_TO), ")
        strSQL.Append("     T_JG AS (SELECT JG.KBN,JG.KURACD,JG.ACBCD,JG.GROUPCD,JG.USERCD_FROM,JG.USERCD_TO FROM M09_JAGROUP JG WHERE JG.KBN = :HAN_GRP_KBN AND JG.KURACD >= :CLI_CD AND JG.KURACD <= :CLI_CD_TO) ")
        '画面で選択した販売事業所に所属する個別の顧客を取得
        strSQL.Append("SELECT * FROM T_SH SH1 ")
        strSQL.Append("WHERE EXISTS ( ")
        strSQL.Append("               SELECT * FROM T_JG JG1 ")
        strSQL.Append("               WHERE JG1.ACBCD = SH1.HAN_CD ")
        strSQL.Append("               AND JG1.GROUPCD = :HAN_GRP ")
        strSQL.Append("               AND JG1.USERCD_FROM = SH1.USER_CD ")
        strSQL.Append("               AND JG1.USERCD_TO IS NULL ")
        strSQL.Append("            ) ")
        strSQL.Append("UNION ")
        '画面で選択した販売事業所に所属する範囲の顧客を取得
        strSQL.Append("SELECT * FROM T_SH SH2 ")
        strSQL.Append("WHERE EXISTS ( ")
        strSQL.Append("               SELECT * FROM T_JG JG2 ")
        strSQL.Append("               WHERE JG2.ACBCD = SH2.HAN_CD ")
        strSQL.Append("               AND JG2.GROUPCD = :HAN_GRP ")
        strSQL.Append("               AND JG2.USERCD_FROM IS NOT NULL ")
        strSQL.Append("               AND JG2.USERCD_TO IS NOT NULL ")
        strSQL.Append("               AND SH2.USER_CD BETWEEN JG2.USERCD_FROM AND JG2.USERCD_TO ")
        strSQL.Append("             ) ")
        '''''別の販売事業者グループに属する個別の顧客を除く
        strSQL.Append("AND NOT EXISTS( ")
        strSQL.Append("               SELECT * FROM T_JG JG3 ")
        strSQL.Append("               WHERE SH2.HAN_CD = JG3.ACBCD ")
        strSQL.Append("               AND JG3.GROUPCD <> :HAN_GRP ")
        strSQL.Append("               AND JG3.USERCD_TO IS NULL ")
        strSQL.Append("               AND SH2.USER_CD = JG3.USERCD_FROM ")
        strSQL.Append("              ) ")
        strSQL.Append("UNION ")
        '画面で選択した販売事業所に所属する支所の顧客を取得
        strSQL.Append("SELECT * FROM T_SH SH3 ")
        strSQL.Append("WHERE EXISTS ( ")
        strSQL.Append("               SELECT * FROM T_JG JG4 ")
        strSQL.Append("               WHERE SH3.HAN_CD =  JG4.ACBCD ")
        strSQL.Append("               AND JG4.GROUPCD = :HAN_GRP ")
        strSQL.Append("               AND JG4.USERCD_FROM IS NULL ")
        strSQL.Append("               AND JG4.USERCD_TO IS NULL ")
        strSQL.Append("             ) ")
        '''''別の販売事業者グループに属する個別の顧客を除く
        strSQL.Append("AND NOT EXISTS( ")
        strSQL.Append("               SELECT * FROM T_JG JG5 ")
        strSQL.Append("               WHERE SH3.HAN_CD = JG5.ACBCD ")
        strSQL.Append("               AND JG5.GROUPCD <> :HAN_GRP ")
        strSQL.Append("               AND JG5.USERCD_TO IS NULL ")
        strSQL.Append("               AND SH3.USER_CD = JG5.USERCD_FROM ")
        strSQL.Append("              ) ")
        '''''別の販売事業者グループに属する範囲の顧客を除く
        strSQL.Append("AND NOT EXISTS( ")
        strSQL.Append("               SELECT * FROM T_JG JG6 ")
        strSQL.Append("               WHERE SH3.HAN_CD = JG6.ACBCD ")
        strSQL.Append("               AND JG6.GROUPCD <> :HAN_GRP ")
        strSQL.Append("               AND JG6.USERCD_FROM IS NOT NULL ")
        strSQL.Append("               AND JG6.USERCD_TO IS NOT NULL ")
        strSQL.Append("               AND SH3.USER_CD BETWEEN JG6.USERCD_FROM AND JG6.USERCD_TO ")
        strSQL.Append("              ) ")
        strSQL.Append(") T_GRP ")
        strSQL.Append("WHERE SH.CLI_CD = T_GRP.CLI_CD ")
        strSQL.Append("AND SH.HAN_CD = T_GRP.HAN_CD ")
        strSQL.Append("AND SH.USER_CD = T_GRP.USER_CD ")
        strSQL.Append(" ) ")

        Return strSQL.ToString
    End Function

End Class
