'***********************************************
'対応結果一覧  一覧画面
'***********************************************
' 変更履歴
' 2011/11/02 H.Uema 表示項目の変更（削除：処理番号, 追加：JA支所名, 警報１）
' 2011/11/02 H.Uema 表示件数変更(99->999)※Web.configで件数を定義している箇所を修正
' 2011/11/28 H.Uema 表示項目の変更（追加：JA支所コード）
Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common
Imports JPG.Common.log
Imports System.Text

Partial Class KEKEKJFG00
    Inherits System.Web.UI.Page

    Protected WithEvents dbData As System.Data.DataSet

    '2011.11.15 ADD H.Uema

    Protected KEKEKJAG00_C As KEKEKJAG00
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
        '// HTTPヘッダを送信
        HttpHeaderC.mNoCache(Response)

        '//------------------------------------------
        '//　認証クラスのインスタンス生成
        AuthC = New CAuthenticate(Request, Response)

        '//------------------------------------------
        '//　認証処理
        '<TODO>：使用可能権限を指定する
        '2005/12/03 NEC UPDATE START
        '[対応結果一覧]使用可能権限(運:○/営:×/監:△/出:×)
        '[対応結果一覧]使用可能権限(運:○/営:○/監:△/出:×)
        'AuthC.fncAuthCheck(Server, AuthC.pGROUP_UNKOU & "," & AuthC.pGROUP_KANSHI)
        AuthC.fncAuthCheck(Server, AuthC.pGROUP_UNKOU & "," & AuthC.pGROUP_KANSHI & "," & AuthC.pGROUP_EIGYOU)
        '2005/12/03 NEC UPDATE START

        '//------------------------------------------
        '// 対応入力
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
        '//独自のスクリプト
        strScript.Append(cscript1.mWriteScript( _
             MyBase.MapPath("../../../KE/KEKEKJAG/KEKEKJAG00/") & "KEKEKJFG00.js"))
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
        If Not IsPostBack Then
            KEKEKJAG00_C = CType(Context.Handler, KEKEKJAG00)
        End If
        '//------------------------------------------
        '********************************************

        '//-------------------------------------------------
        '<TODO>自分の画面IDをHIDDENのhdnMyAspxに書き込む（システム共通）
        hdnMyAspx.Value = "KEKEKJAG00"
        '//-------------------------------------------------

        Dim strKEY_KANSCD As String
        Dim strKEY_SYONO As String

        strKEY_KANSCD = KEKEKJAG00_C.pKEY_KANSCD
        strKEY_SYONO = KEKEKJAG00_C.pKEY_SYONO

        hdnMOVE_TMSKB.Value = KEKEKJAG00_C.pTMSKB
        hdnMOVE_JUTEL.Value = KEKEKJAG00_C.pJUTEL
        'hdnMOVE_NCUTEL.Value = KEKEKJAG00_C.pNCUTEL            '2014/12/05 H.Hosoda add 監視改善2014 No.7 '2016/11/25 H.Mori del 監視改善2016 No3-2
        hdnMOVE_KANSCD.Value = KEKEKJAG00_C.pKANSCD
        hdnMOVE_HATKBN.Value = KEKEKJAG00_C.pHATKBN
        'hdnMOVE_TAIOKBN.Value = KEKEKJAG00_C.pTAIOKBN          '2014/12/04 H.Hosoda del 監視改善2014 No.7
        hdnMOVE_TAIOKBN1.Value = KEKEKJAG00_C.pTAIOKBN1         '2014/12/04 H.Hosoda add 監視改善2014 No.7
        hdnMOVE_TAIOKBN2.Value = KEKEKJAG00_C.pTAIOKBN2         '2014/12/04 H.Hosoda add 監視改善2014 No.7
        hdnMOVE_TAIOKBN3.Value = KEKEKJAG00_C.pTAIOKBN3         '2014/12/04 H.Hosoda add 監視改善2014 No.7
        hdnMOVE_TKTANCD.Value = KEKEKJAG00_C.pTKTANCD
        hdnMOVE_TKTANNM.Value = KEKEKJAG00_C.pTKTANNAME
        hdnMOVE_JUSYONM.Value = KEKEKJAG00_C.pJUSYONM
        'hdnMOVE_JUSYOKN.Value = KEKEKJAG00_C.pJUSYOKN          '2016/11/24 H.Mori del 監視改善2016 No3-3
        hdnMOVE_KIKANKBN.Value = KEKEKJAG00_C.pKikankbn         '2017/10/25 H.Mori add 2017改善開発 No3-1
        hdnMOVE_HATYMD_To.Value = KEKEKJAG00_C.pHATYMD_To
        hdnMOVE_HATTIME_To.Value = KEKEKJAG00_C.pHATTIME_To
        hdnMOVE_HATYMD_From.Value = KEKEKJAG00_C.pHATYMD_From
        hdnMOVE_HATTIME_From.Value = KEKEKJAG00_C.pHATTIME_From
        hdnMOVE_KURACD.Value = KEKEKJAG00_C.pKURACD
        hdnMOVE_KURACD_NAME.Value = KEKEKJAG00_C.pKURACD_NAME
        hdnMOVE_KURACD_TO.Value = KEKEKJAG00_C.pKURACD_TO            '2019/11/01 T.Ono add 監視改善2019
        hdnMOVE_KURACD_TO_NAME.Value = KEKEKJAG00_C.pKURACD_TO_NAME  '2019/11/01 T.Ono add 監視改善2019
        hdnMOVE_JACD.Value = KEKEKJAG00_C.pJACD                   '2013/12/09 T.Ono add 監視改善2013
        hdnMOVE_JACD_NAME.Value = KEKEKJAG00_C.pJACD_NAME         '2013/12/09 T.Ono add 監視改善2013        
        hdnMOVE_JACD_CLI.Value = KEKEKJAG00_C.pJACD_CLI            '2019/11/01 T.Ono add 監視改善2019
        '2019/11/01 T.Ono del 監視改善2019 START
        'hdnMOVE_HAN_GRP.Value = KEKEKJAG00_C.pHANGRP              '2014/12/08 H.Hosoda add 監視改善2014 No.7
        'hdnMOVE_HAN_GRP_NAME.Value = KEKEKJAG00_C.pHANGRP_NAME    '2014/12/08 H.Hosoda add 監視改善2014 No.7
        'hdnMOVE_KINREN_GRP.Value = KEKEKJAG00_C.pKINRENGRP              '2016/11/25 H.Mori add 監視改善2016 No3-1
        'hdnMOVE_KINREN_GRP_NAME.Value = KEKEKJAG00_C.pKINRENGRP_NAME    '2016/11/25 H.Mori add 監視改善2016 No3-1
        '2019/11/01 T.Ono del 監視改善2019 END
        hdnMOVE_ACBCD.Value = KEKEKJAG00_C.pACBCD
        hdnMOVE_ACBCD_NAME.Value = KEKEKJAG00_C.pACBCD_NAME
        hdnMOVE_ACBCD_CLI.Value = KEKEKJAG00_C.pACBCD_CLI          '2019/11/01 T.Ono add 監視改善2019
        hdnMOVE_ACBCD_TO.Value = KEKEKJAG00_C.pACBCD_TO            '2019/11/01 T.Ono add 監視改善2019
        hdnMOVE_ACBCD_TO_NAME.Value = KEKEKJAG00_C.pACBCD_TO_NAME  '2019/11/01 T.Ono add 監視改善2019
        hdnMOVE_ACBCD_TO_CLI.Value = KEKEKJAG00_C.pACBCD_TO_CLI    '2019/11/01 T.Ono add 監視改善2019
        hdnMOVE_USER_CD.Value = KEKEKJAG00_C.pUSER_CD
        '2011.11.15 ADD H.Uema
        hdnMOVE_KMCD.Value = KEKEKJAG00_C.pKMCD
        hdnMOVE_KMNM.Value = KEKEKJAG00_C.pKMNM
        'スクロール位置
        hdnScrollTop.Value = KEKEKJAG00_C.pScrollTop                '2013/12/10 T.Ono add 監視改善2013

        '<TODO>画面オブジェクトを使用可能にする
        strMsg.Append("parent.Form1.btnSelect.disabled=false;")
        strMsg.Append("parent.Form1.btnExit.disabled=false;")
        strMsg.Append("parent.Form1.btnCalendar1.disabled=false;")
        strMsg.Append("parent.Form1.btnCalendar2.disabled=false;")
        strMsg.Append("parent.Form1.btnTKTANCD.disabled=false;")
        strMsg.Append("parent.Form1.btnKURACD.disabled=false;")
        strMsg.Append("parent.Form1.btnKURACD_TO.disabled=false;")  '2019/11/01 T.Ono add 監視改善2019
        strMsg.Append("parent.Form1.btnJACD.disabled=false;")       '2013/12/09 T.Ono add 監視改善2013
        'strMsg.Append("parent.Form1.btnHANGRP.disabled=false;")     '2014/12/08 H.Hosoda add 監視改善2014 No.7
        'strMsg.Append("parent.Form1.btnKINRENGRP.disabled=false;")     '2016/11/25 H.Mori add 監視改善2016 No3-1
        strMsg.Append("parent.Form1.btnACBCD.disabled=false;")
        strMsg.Append("parent.Form1.btnACBCD_TO.disabled=false;")   '2019/11/01 T.Ono add 監視改善2019
        strMsg.Append("parent.Form1.btnKMCD.disabled=false;")       '2013/12/09 T.Ono add 監視改善2013
        strMsg.Append("window.scroll( 0, " & hdnScrollTop.Value & ");") 'スクロール位置 2013/12/09 T.Ono add 監視改善2013
        Dim strRec As String = ""

        Try
            '//------------------------------------------
            Dim SQLC As New KEKEKJAG00CCSQL.CSQL
            Dim SqlParamC As New CSQLParam
            Dim strSQL As New StringBuilder

            '//------------------------------------------
            '//MAX件数チェック
            Dim intCount As Integer

            If KEKEKJAG00_C.pSelectClick = "1" Then

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
                If KEKEKJAG00_C.pSelectClick = "1" Then
                    '//検索ボタン押下によるデータ０件
                    strMsg.Append("alert('対象データが存在しません');")
                    strRec = "データが存在しません"
                End If

                dbData.Tables(0).Rows(0).Item("JS_KANSCD") = ""     'JS出力用
                dbData.Tables(0).Rows(0).Item("JS_SYONO") = ""
                dbData.Tables(0).Rows(0).Item("CH_KANSCD") = ""     '遷移チェック用
                dbData.Tables(0).Rows(0).Item("CH_SYONO") = ""
                dbData.Tables(0).Rows(0).Item("ROWNO") = ""
                dbData.Tables(0).Rows(0).Item("COLOR") = ""     'SPANカラー
                dbData.Tables(0).Rows(0).Item("CLS") = ""       'SPANクラス
                dbData.Tables(0).Rows(0).Item("KANSCD") = ""
                dbData.Tables(0).Rows(0).Item("SYONO") = ""
                dbData.Tables(0).Rows(0).Item("SYOYMD") = ""
                dbData.Tables(0).Rows(0).Item("SYOTIME") = ""
                dbData.Tables(0).Rows(0).Item("HATYMD") = ""
                dbData.Tables(0).Rows(0).Item("HATTIME") = ""
                dbData.Tables(0).Rows(0).Item("HATKBN") = ""
                dbData.Tables(0).Rows(0).Item("TAIOKBN") = ""
                dbData.Tables(0).Rows(0).Item("TMSKB") = ""
                dbData.Tables(0).Rows(0).Item("JUSYONM") = ""

                '*** 2011.11.02 ADD h.uema 表示項目改修に伴う修正 ***** START
                dbData.Tables(0).Rows(0).Item("ACBCD") = ""
                dbData.Tables(0).Rows(0).Item("ACBNM") = ""
                dbData.Tables(0).Rows(0).Item("KMCD1") = ""
                dbData.Tables(0).Rows(0).Item("KMNM1") = ""
                '*** 2011.11.02 ADD h.uema 表示項目改修に伴う修正 ***** END

            Else
                Dim strJsCode As New StringBuilder("")
                Dim EscapeC As New CEscape

                Dim strTemp As String

                For intRow = 0 To dbData.Tables(0).Rows.Count - 1
                    'HtmlのJsにて使用する
                    dbData.Tables(0).Rows(intRow).Item("ROWNO") =
                        EscapeC.mDb_Js(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("ROWNO")))
                    dbData.Tables(0).Rows(intRow).Item("JS_KANSCD") =
                        EscapeC.mDb_Js(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("JS_KANSCD")))
                    dbData.Tables(0).Rows(intRow).Item("JS_SYONO") =
                        EscapeC.mDb_Js(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("JS_SYONO")))
                    'Htmlの値として使用する
                    dbData.Tables(0).Rows(intRow).Item("KANSCD") =
                        EscapeC.mDb_Html(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("KANSCD")))
                    dbData.Tables(0).Rows(intRow).Item("SYONO") =
                        EscapeC.mDb_Html(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("SYONO")))
                    dbData.Tables(0).Rows(intRow).Item("SYOYMD") =
                        EscapeC.mDb_Html(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("SYOYMD")))
                    dbData.Tables(0).Rows(intRow).Item("SYOTIME") =
                        EscapeC.mDb_Html(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("SYOTIME")))
                    dbData.Tables(0).Rows(intRow).Item("HATYMD") =
                        EscapeC.mDb_Html(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("HATYMD")))
                    dbData.Tables(0).Rows(intRow).Item("HATTIME") =
                        EscapeC.mDb_Html(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("HATTIME")))
                    dbData.Tables(0).Rows(intRow).Item("HATKBN") =
                        EscapeC.mDb_Html(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("HATKBN")))
                    dbData.Tables(0).Rows(intRow).Item("TAIOKBN") =
                        EscapeC.mDb_Html(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("TAIOKBN")))
                    dbData.Tables(0).Rows(intRow).Item("TMSKB") =
                        EscapeC.mDb_Html(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("TMSKB")))
                    dbData.Tables(0).Rows(intRow).Item("JUSYONM") =
                        EscapeC.mDb_Html(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("JUSYONM")))

                    '*** 2011.11.02 ADD h.uema 表示項目改修に伴う修正 ***** START
                    dbData.Tables(0).Rows(intRow).Item("ACBCD") =
                        EscapeC.mDb_Html(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("ACBCD")))
                    dbData.Tables(0).Rows(intRow).Item("ACBNM") =
                        EscapeC.mDb_Html(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("ACBNM")))
                    dbData.Tables(0).Rows(intRow).Item("KMCD1") =
                        EscapeC.mDb_Html(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("KMCD1")))
                    dbData.Tables(0).Rows(intRow).Item("KMNM1") =
                        EscapeC.mDb_Html(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("KMNM1")))
                    '*** 2011.11.02 ADD h.uema 表示項目改修に伴う修正 ***** END

                    '//登録画面より戻ってきた時の画面遷移時に、指定したデータの色を変更する
                    If (strKEY_KANSCD = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("CH_KANSCD")) And
                        strKEY_SYONO = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("CH_SYONO"))) Then
                        dbData.Tables(0).Rows(intRow).Item("COLOR") = "GreenYellow"
                        dbData.Tables(0).Rows(intRow).Item("CLS") = "CHK"
                    Else
                        dbData.Tables(0).Rows(intRow).Item("COLOR") = "skyblue"
                        dbData.Tables(0).Rows(intRow).Item("CLS") = ""
                    End If

                    '*** 2011.11.02 cmmentOut h.uema
                    '*** 処理番号項目が非表示となるため、下記処理は不要
                    ''//画面リンク＜処理番号＞
                    'If Convert.ToString(dbData.Tables(0).Rows(intRow).Item("SYONO")) <> "" Then

                    '    '//処理番号にリンクをつけ、対応入力に遷移する
                    '    strJsCode = New StringBuilder("")
                    '    strJsCode.Append("<a href=""JavaScript:fncJump(")
                    '    strJsCode.Append("'" & Convert.ToString(dbData.Tables(0).Rows(intRow).Item("JS_KANSCD")) & "',")
                    '    strJsCode.Append("'" & Convert.ToString(dbData.Tables(0).Rows(intRow).Item("JS_SYONO")) & "'")
                    '    strJsCode.Append(")"">")
                    '    strJsCode.Append(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("SYONO")))
                    '    strJsCode.Append("</a>")

                    '    dbData.Tables(0).Rows(intRow).Item("SYONO") = strJsCode.ToString
                    'End If
                    '//発生日
                    strTemp = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("HATYMD"))
                    If IsNumeric(strTemp) = True Then
                        dbData.Tables(0).Rows(intRow).Item("HATYMD") = KEKEKJAG00_C.fncDateSet(strTemp)
                    End If
                    '//発生時刻
                    strTemp = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("HATTIME"))
                    If IsNumeric(strTemp) = True Then
                        dbData.Tables(0).Rows(intRow).Item("HATTIME") = KEKEKJAG00_C.fncTimeSet(strTemp, 0)
                    End If
                    '//対応完了日
                    strTemp = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("SYOYMD"))
                    If IsNumeric(strTemp) = True Then
                        dbData.Tables(0).Rows(intRow).Item("SYOYMD") = KEKEKJAG00_C.fncDateSet(strTemp)
                    End If
                    '//対応完了時刻
                    strTemp = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("SYOTIME"))
                    If IsNumeric(strTemp) = True Then
                        dbData.Tables(0).Rows(intRow).Item("SYOTIME") = KEKEKJAG00_C.fncTimeSet(strTemp, 1)
                    End If
                    '*** 2011.11.02 ADD h.uema 表示項目改修に伴う修正 ***** START
                    '// JA支店支所
                    strTemp = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("ACBNM"))
                    If strTemp = "" Then
                        strTemp = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("ACBCD"))
                        If strTemp = "" Then
                            strTemp = "***"
                        End If
                    End If
                    '//リンクをつけ、対応入力に遷移する
                    strJsCode = New StringBuilder("")
                    strJsCode.Append("<a href=""JavaScript:fncJump(")
                    strJsCode.Append("'" & Convert.ToString(dbData.Tables(0).Rows(intRow).Item("JS_KANSCD")) & "',")
                    strJsCode.Append("'" & Convert.ToString(dbData.Tables(0).Rows(intRow).Item("JS_SYONO")) & "'")
                    strJsCode.Append(")"">")
                    strJsCode.Append(strTemp)
                    strJsCode.Append("</a>")
                    dbData.Tables(0).Rows(intRow).Item("ACBNM") = strJsCode.ToString
                    '// 警報１
                    If Convert.ToString(dbData.Tables(0).Rows(intRow).Item("KMCD1")) = "" Then
                        strTemp = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("KMNM1"))
                    Else
                        strTemp = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("KMCD1")) +
                                ":" + Convert.ToString(dbData.Tables(0).Rows(intRow).Item("KMNM1"))
                    End If
                    dbData.Tables(0).Rows(intRow).Item("KMNM1") = strTemp
                    '*** 2011.11.02 ADD h.uema 表示項目改修に伴う修正 ***** END
                Next

            End If


            'リピータにバインドする-----------------------------
            rptData.DataBind()


            '********************************************
            If KEKEKJAG00_C.pSelectClick = "1" Then
                If strRec.Length = 0 Then       '[データが存在しません]のメッセージを出力
                    strRec = "OK"
                End If
            End If
        Catch ex As Exception
            strRec = ex.ToString
            Dim ErrMsgC As New CErrMsg
            strMsg.Append("alert('システムエラー：" & ErrMsgC.mGetArtMsg(strRec) & "');")
        End Try

        If KEKEKJAG00_C.pSelectClick = "1" Then
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
                'strSQL.Append("LPAD(ROWNUM,3,0) AS ROWNO, ")   '2013/12/10 T.Ono mod 監視改善2013
                strSQL.Append("LPAD(ROWNUM,4,0) AS ROWNO, ")
                strSQL.Append("	'' AS COLOR,")                                              'SPANカラー
                strSQL.Append("	'' AS CLS,")                                                'SPANクラス
                strSQL.Append("	TAI.KANSCD,")
                strSQL.Append("	TAI.SYONO,")
                strSQL.Append("	TAI.KANSCD AS JS_KANSCD,")
                strSQL.Append("	TAI.SYONO AS JS_SYONO,")
                strSQL.Append("	TAI.KANSCD AS CH_KANSCD,")
                strSQL.Append("	TAI.SYONO AS CH_SYONO,")
                strSQL.Append("	TAI.SYOYMD,")
                strSQL.Append("	TAI.SYOTIME,")
                strSQL.Append("	TAI.HATYMD,")
                strSQL.Append("	TAI.HATTIME,")
                strSQL.Append("	TAI.HATKBN AS HATKBNCD,")
                strSQL.Append("	P08.NAME AS HATKBN,")
                strSQL.Append("	TAI.TAIOKBN AS TAIOKBNCD,")
                strSQL.Append("	P09.NAME AS TAIOKBN,")
                '*** 2011.11.02 ADD h.uema 表示項目改修に伴う修正 ***** START
                strSQL.Append(" TAI.ACBCD,")
                strSQL.Append(" TAI.ACBNM,")
                strSQL.Append(" TAI.KMCD1,")
                strSQL.Append(" TAI.KMNM1,")
                '*** 2011.11.02 ADD h.uema 表示項目改修に伴う修正 ***** END
                strSQL.Append("	TAI.TMSKB AS TMSKBCD,")
                strSQL.Append("	P10.NAME AS TMSKB,")
                strSQL.Append("	TAI.JUSYONM,")
                strSQL.Append("	TAI.TAIO_ST_DATE,")
                strSQL.Append("	TAI.TAIO_ST_TIME ")
                strSQL.Append("FROM D20_TAIOU TAI, ")
                strSQL.Append("     M06_PULLDOWN P08, ")
                strSQL.Append("     M06_PULLDOWN P09, ")
                strSQL.Append("     M06_PULLDOWN P10 ")
            Else
                strSQL.Append("'XYZ' AS ROWNO, ")
                strSQL.Append("	'' AS COLOR,")
                strSQL.Append("	'' AS CLS,")
                strSQL.Append("	'' AS KANSCD,")
                strSQL.Append("	'' AS SYONO,")
                strSQL.Append("	'' AS JS_KANSCD,")
                strSQL.Append("	'' AS JS_SYONO,")
                strSQL.Append("	'' AS CH_KANSCD,")
                strSQL.Append("	'' AS CH_SYONO,")
                strSQL.Append("	'' AS SYOYMD,")
                strSQL.Append("	'' AS SYOTIME,")
                strSQL.Append("	'' AS HATYMD,")
                strSQL.Append("	'' AS HATTIME,")
                strSQL.Append("	'' AS HATKBNCD,")
                strSQL.Append("	'' AS HATKBN,")
                strSQL.Append("	'' AS TAIOKBNCD,")
                strSQL.Append("	'' AS TAIOKBN,")
                '*** 2011.11.02 ADD h.uema 表示項目改修に伴う修正 ***** START
                strSQL.Append(" '' AS ACBCD,")
                strSQL.Append(" '' AS ACBNM,")
                strSQL.Append(" '' AS KMCD1,")
                strSQL.Append(" '' AS KMNM1,")
                '*** 2011.11.02 ADD h.uema 表示項目改修に伴う修正 ***** END
                strSQL.Append("	'' AS TMSKBCD,")
                strSQL.Append("	'' AS TMSKB,")
                strSQL.Append("	'' AS JUSYONM,")
                strSQL.Append("	'' AS TAIO_ST_DATE,")
                strSQL.Append("	'' AS TAIO_ST_TIME ")
                strSQL.Append("FROM DUAL ")
                strSQL.Append(") A") '2013/12/10 add T.Ono 監視改善2013

                Exit Sub
            End If
        Else
            '//件数カウント用のSQL
            strSQL.Append("COUNT(*) AS CNT ")       'カウント
            strSQL.Append("FROM D20_TAIOU TAI ")
        End If

        If intkbn = 0 Then
            strSQL.Append("  WHERE ROWNUM <= " & ConstC.pScrollMax)
        Else
            strSQL.Append("  WHERE ROWNUM <= " & ConstC.pScrollMax + 1)
        End If

        '監視センター
        If KEKEKJAG00_C.pKANSCD.Length > 0 Then
            strSQL.Append(" AND TAI.KANSCD = :KANSCD ")
        End If

        ''発生期間
        'If KEKEKJAG00_C.pHATYMD_From.Length > 0 And KEKEKJAG00_C.pHATYMD_To.Length > 0 Then
        '    strSQL.Append(" AND TAI.HATYMD BETWEEN :HATYMD_FROM AND :HATYMD_TO ")
        'End If
        'If KEKEKJAG00_C.pHATYMD_From.Length > 0 And KEKEKJAG00_C.pHATYMD_To.Length = 0 Then
        '    strSQL.Append(" AND TAI.HATYMD >= :HATYMD_FROM ")
        'End If
        'If KEKEKJAG00_C.pHATYMD_From.Length = 0 And KEKEKJAG00_C.pHATYMD_To.Length > 0 Then
        '    strSQL.Append(" AND TAI.HATYMD <= :HATYMD_TO ")
        'End If
        ''発生時間
        'If KEKEKJAG00_C.pHATTIME_From.Length > 0 And KEKEKJAG00_C.pHATTIME_To.Length > 0 Then
        '    strSQL.Append(" AND TAI.HATTIME BETWEEN :HATTIME_FROM AND :HATTIME_TO ")
        'End If
        'If KEKEKJAG00_C.pHATTIME_From.Length > 0 And KEKEKJAG00_C.pHATTIME_To.Length = 0 Then
        '    strSQL.Append(" AND TAI.HATTIME >= :HATTIME_FROM ")
        'End If
        'If KEKEKJAG00_C.pHATTIME_From.Length = 0 And KEKEKJAG00_C.pHATTIME_To.Length > 0 Then
        '    strSQL.Append(" AND TAI.HATTIME <= :HATTIME_TO ")
        'End If

        '2017/10/25 H.Mori add 2017改善開発 No3-1 対応完了日・受信日 START
        If KEKEKJAG00_C.pKikankbn = "2" Then '受信日
            '対象期間･対象時間From
            If KEKEKJAG00_C.pHATYMD_From.Length > 0 AndAlso KEKEKJAG00_C.pHATTIME_From.Length > 0 Then
                strSQL.Append(" AND TAI.HATYMD || TAI.HATTIME >= :HATYMD_FROM || :HATTIME_FROM ")
            End If
            If KEKEKJAG00_C.pHATYMD_From.Length > 0 AndAlso KEKEKJAG00_C.pHATTIME_From.Length = 0 Then
                strSQL.Append(" AND TAI.HATYMD >= :HATYMD_FROM ")
            End If
            '対象期間･対象時間To
            If KEKEKJAG00_C.pHATYMD_To.Length > 0 AndAlso KEKEKJAG00_C.pHATTIME_To.Length > 0 Then
                strSQL.Append(" AND TAI.HATYMD || TAI.HATTIME <= :HATYMD_TO || :HATTIME_To ")
            End If
            If KEKEKJAG00_C.pHATYMD_To.Length > 0 AndAlso KEKEKJAG00_C.pHATTIME_To.Length = 0 Then
                strSQL.Append(" AND TAI.HATYMD <= :HATYMD_TO ")
            End If
        End If
        If KEKEKJAG00_C.pKikankbn = "1" Then '対応完了日
            '対象期間･対象時間From
            If KEKEKJAG00_C.pHATYMD_From.Length > 0 AndAlso KEKEKJAG00_C.pHATTIME_From.Length > 0 Then
                strSQL.Append(" AND TAI.SYOYMD || TAI.SYOTIME >= :HATYMD_FROM || :HATTIME_FROM ")
            End If
            If KEKEKJAG00_C.pHATYMD_From.Length > 0 AndAlso KEKEKJAG00_C.pHATTIME_From.Length = 0 Then
                strSQL.Append(" AND TAI.SYOYMD >= :HATYMD_FROM ")
            End If
            '対象期間･対象時間To
            If KEKEKJAG00_C.pHATYMD_To.Length > 0 AndAlso KEKEKJAG00_C.pHATTIME_To.Length > 0 Then
                strSQL.Append(" AND TAI.SYOYMD || TAI.SYOTIME <= :HATYMD_TO || :HATTIME_To ")
            End If
            If KEKEKJAG00_C.pHATYMD_To.Length > 0 AndAlso KEKEKJAG00_C.pHATTIME_To.Length = 0 Then
                strSQL.Append(" AND TAI.SYOYMD <= :HATYMD_TO ")
            End If
        End If
        '2017/10/25 H.Mori add 2017改善開発 No3-1 対応完了日・受信日 END

        '監視センター担当者
        If KEKEKJAG00_C.pTKTANCD.Length > 0 Then
            strSQL.Append(" AND TAI.TKTANCD = :TKTANCD ")
        End If
        '発生区分
        If KEKEKJAG00_C.pHATKBN.Length > 0 Then
            strSQL.Append(" AND TAI.HATKBN = :HATKBN ")
        End If

        '対応区分
        '2014/12/05 H.Hosoda mod 監視改善2014 No.7 START
        'If KEKEKJAG00_C.pTAIOKBN.Length > 0 Then
        '    strSQL.Append(" AND TAI.TAIOKBN = :TAIOKBN ")
        'End If
        strSQL.Append(" AND TAI.TAIOKBN IN (:TAIOKBN1,:TAIOKBN2,:TAIOKBN3)")
        '2014/12/05 H.Hosoda mod 監視改善2014 No.7 END

        '処理区分
        If KEKEKJAG00_C.pTMSKB.Length > 0 Then
            strSQL.Append(" AND TAI.TMSKB = :TMSKB ")
        End If
        'お客様電話番号
        If KEKEKJAG00_C.pJUTEL.Length > 0 Then
            '2014/12/05 H.Hosoda mod 監視改善2014 No.7 START
            'strSQL.Append(" AND TAI.KTELNO LIKE :KTELNO || '%' ")
            'strSQL.Append(" AND REPLACE(TAI.KTELNO,'-','') ") 2015/01/23 T.Ono mod 監視改善2014 No.7
            '連絡先2,3　2016/1/29 H.Mori mod 監視改善2015 START
            'strSQL.Append(" AND REPLACE(REPLACE(TAI.KTELNO,'-',''),' ','') ")
            'strSQL.Append("  LIKE REPLACE(:KTELNO,'-','') || '%' ")
            '2016/11/25 H.Mori mod 改善2016 No3-2 START
            'strSQL.Append(" AND (REPLACE(REPLACE(TAI.KTELNO,'-',''), ' ','') ")
            'strSQL.Append("  LIKE REPLACE(:KTELNO,'-','') || '%' ")
            strSQL.Append(" AND (REPLACE(REPLACE(TAI.RENTEL,'-',''), ' ','') ")
            strSQL.Append("  LIKE REPLACE(:KTELNO,'-','') || '%' ")
            '2016/11/25 H.Mori mod 改善2016 No3-2 END
            strSQL.Append(" OR REPLACE(REPLACE(TAI.RENTEL2,'-',''), ' ','') ")
            strSQL.Append("  LIKE REPLACE(:KTELNO,'-','') || '%' ")
            strSQL.Append(" OR REPLACE(REPLACE(TAI.RENTEL3,'-',''), ' ','') ")
            strSQL.Append("  LIKE REPLACE(:KTELNO,'-','') || '%' ")
            '連絡先2,3　2016/1/29 H.Mori mod 監視改善2015 END
            '2014/12/05 H.Hosoda mod 監視改善2014 No.7 END
            '2016/11/25 H.Mori add 改善2016 No3-2 START
            strSQL.Append(" OR REPLACE(REPLACE(TAI.JUTEL1 || TAI.JUTEL2,'-',''),' ','') ")
            strSQL.Append("  LIKE REPLACE(:KTELNO,'-','') || '%' ")
            strSQL.Append(" OR REPLACE(REPLACE(TAI.TELAB,'-',''),' ','') ")
            strSQL.Append("  LIKE REPLACE(:KTELNO,'-','') || '%' ")
            strSQL.Append(" OR REPLACE(REPLACE(TAI.DAI3RENDORENTEL,'-',''),' ','') ")
            strSQL.Append("  LIKE REPLACE(:KTELNO,'-','') || '%') ")
            '2016/12/22 H.Mori add 監視改善2016 No3-2 END
        End If
        '2016/11/25 H.Mori del 監視改善2016 No3-2 START
        '結線番号  '2014/12/05 H.Hosoda add 監視改善2014 No.7
        'If KEKEKJAG00_C.pNCUTEL.Length > 0 Then
        '    'strSQL.Append(" AND REPLACE(TAI.JUTEL1 || TAI.JUTEL2,'-','') ") 2015/01/23 T.Ono mod 監視改善2014 №7
        '    strSQL.Append(" AND REPLACE(REPLACE(TAI.JUTEL1 || TAI.JUTEL2,'-',''),' ','') ")
        '    strSQL.Append("  LIKE REPLACE(:NCUTELNO,'-','') || '%' ")
        'End If
        '2016/11/25 H.Mori del 監視改善2016 No3-2 END
        'お客様名
        If KEKEKJAG00_C.pJUSYONM.Length > 0 Then
            '2014/12/05 H.Hosoda mod 監視改善2014 No.7 START
            'strSQL.Append(" AND TAI.JUSYONM LIKE :JUSYONM || '%' ")
            strSQL.Append(" AND (REPLACE(UTL_I18N.TRANSLITERATE(TO_SINGLE_BYTE (TAI.JUSYONM), 'FWKATAKANA_HWKATAKANA'),' ','') ")
            strSQL.Append("  LIKE REPLACE(UTL_I18N.TRANSLITERATE(TO_SINGLE_BYTE (:JUSYONM), 'FWKATAKANA_HWKATAKANA'),' ','')  || '%' ")
            '2014/12/05 H.Hosoda mod 監視改善2014 No.7 END
            '2016/11/24 H.Mori add 監視改善2016 No3-3 START
            strSQL.Append(" OR  REPLACE(UTL_I18N.TRANSLITERATE(TO_SINGLE_BYTE (TAI.JUSYOKN), 'FWKATAKANA_HWKATAKANA'),' ','') ")
            strSQL.Append("  LIKE REPLACE(UTL_I18N.TRANSLITERATE(TO_SINGLE_BYTE (:JUSYONM), 'FWKATAKANA_HWKATAKANA'),' ','')  || '%') ")
            '2016/11/24 H.Mori add 監視改善2016 No3-3 END
        End If
        '2016/11/24 H.Mori del 監視改善2016 No3-3 START
        ''お客様名カナ
        'If KEKEKJAG00_C.pJUSYOKN.Length > 0 Then
        '    '2014/12/05 H.Hosoda mod 監視改善2014 No.7 START
        '    'strSQL.Append(" AND TAI.JUSYOKN LIKE :JUSYOKN || '%' ")
        '    strSQL.Append(" AND REPLACE(UTL_I18N.TRANSLITERATE(TO_SINGLE_BYTE (TAI.JUSYOKN), 'FWKATAKANA_HWKATAKANA'),' ','') ")
        '    strSQL.Append("  LIKE REPLACE(UTL_I18N.TRANSLITERATE(TO_SINGLE_BYTE (:JUSYOKN), 'FWKATAKANA_HWKATAKANA'),' ','')  || '%' ")
        '    '2014/12/05 H.Hosoda mod 監視改善2014 No.7 END
        'End If
        '2016/11/24 H.Mori del 監視改善2016 No3-3 END
        'クライアントコード
        If KEKEKJAG00_C.pKURACD.Length > 0 Then
            '2019/11/01 T.Ono mod 監視改善2019
            'strSQL.Append(" AND TAI.KURACD = :KURACD ")
            strSQL.Append(" AND TAI.KURACD >= :KURACD ")
            strSQL.Append(" AND TAI.KURACD <= :KURACD_TO ")
        End If
        'ＪＡコード 2013/12/10 T.Ono add 監視改善2013
        If KEKEKJAG00_C.pJACD.Length > 0 Then
            strSQL.Append(" AND TAI.JACD = :JACD ")
        End If

        '2019/11/01 T.Ono del 監視改善2019 START
        ''販売事業者グループコード 2014/12/08 H.Hosoda add 監視改善2014 No.7
        'If KEKEKJAG00_C.pHANGRP.Length > 0 Then
        '    strSQL.Append(" AND TAI.HANJICD = :HANGRP ")
        'End If
        ''緊急連絡先Gr 2016/11/25 H.Mori add 監視改善2016 No3-1
        'If KEKEKJAG00_C.pKINRENGRP.Length > 0 Then
        '    strSQL.Append(" AND TAI.KINRENCD = :KINRENGRP ")
        'End If
        '2019/11/01 T.Ono del 監視改善2019 END

        'ＪＡ支所コード
        If KEKEKJAG00_C.pACBCD.Length > 0 Then
            ' 2011/11/15 MOD H.Uema JA支所コードをLike検索(前方一致)へ変更
            'strSQL.Append(" AND TAI.ACBCD = :ACBCD ") 'DEL
            'strSQL.Append(" AND TAI.ACBCD LIKE :ACBCD || '%' ") 'ADD '2013/12/10 T.Ono mod 監視改善2013
            '2019/11/01 T.Ono mod 監視改善2019
            'strSQL.Append(" AND TAI.ACBCD = :ACBCD ")
            strSQL.Append(" AND TAI.KURACD || TAI.ACBCD >= :KURACD || :ACBCD ")
            strSQL.Append(" AND TAI.KURACD || TAI.ACBCD <= :KURACD_TO || :ACBCD_TO ")
        End If
        'お客様コード
        If KEKEKJAG00_C.pUSER_CD.Length > 0 Then
            strSQL.Append(" AND TAI.USER_CD LIKE :USER_CD || '%' ")
        End If
        '2011.11.15 ADD H.Uema
        '警報コード
        If KEKEKJAG00_C.pKMCD.Length > 0 Then
            strSQL.Append(" AND TAI.KMCD1 = :KMCD ")
        End If

        If intkbn = 0 Then
            strSQL.Append("  AND '08'   = P08.KBN(+) ")
            strSQL.Append("  AND TAI.HATKBN = P08.CD(+) ")
            strSQL.Append("  AND '09'   = P09.KBN(+) ")
            strSQL.Append("  AND TAI.TAIOKBN = P09.CD(+) ")
            strSQL.Append("  AND '10'   = P10.KBN(+) ")
            strSQL.Append("  AND TAI.TMSKB = P10.CD(+) ")
            '2020/11/01 T.Ono mod 監視改善2020 START
            ''2014/12/05 H.Hosoda mod 監視改善2014 No.7 START
            ''strSQL.Append("ORDER BY TAI.HATYMD DESC,TAI.HATTIME DESC ")
            'strSQL.Append("ORDER BY TAI.HATYMD DESC,TAI.HATTIME DESC,TAI.SYONO DESC ")
            ''2014/12/05 H.Hosoda mod 監視改善2014 No.7 END
            If KEKEKJAG00_C.pKikankbn = "2" Then '受信日
                strSQL.Append("ORDER BY TAI.HATYMD DESC,TAI.HATTIME DESC,TAI.SYONO DESC ")
            ElseIf KEKEKJAG00_C.pKikankbn = "1" Then '対応完了日
                strSQL.Append("ORDER BY TAI.SYOYMD DESC,TAI.SYOTIME DESC,TAI.SYONO DESC ")
            Else '基本は受信日
                strSQL.Append("ORDER BY TAI.HATYMD DESC,TAI.HATTIME DESC,TAI.SYONO DESC ")
            End If
            '2020/11/01 T.Ono mod 監視改善2020 END
            strSQL.Append(") A") '2013/12/10 add T.Ono 監視改善2013
        End If

        'パラメータのセット
        If KEKEKJAG00_C.pKANSCD.Length > 0 Then
            SqlParamC.fncSetParam("KANSCD", True, KEKEKJAG00_C.pKANSCD)
        End If
        If KEKEKJAG00_C.pHATYMD_From.Length > 0 Then
            SqlParamC.fncSetParam("HATYMD_FROM", True, KEKEKJAG00_C.pHATYMD_From)
        End If
        If KEKEKJAG00_C.pHATYMD_To.Length > 0 Then
            SqlParamC.fncSetParam("HATYMD_TO", True, KEKEKJAG00_C.pHATYMD_To)
        End If
        If KEKEKJAG00_C.pHATTIME_From.Length > 0 Then
            SqlParamC.fncSetParam("HATTIME_FROM", True, KEKEKJAG00_C.pHATTIME_From)
            ''''''SqlParamC.fncSetParam("HATTIME_FROM", True, KEKEKJAG00_C.pHATTIME_From & "00")
        End If

        If KEKEKJAG00_C.pHATTIME_To.Length > 0 Then
            '2017/10/26 H.Mori add 2017改善開発 No3-1 START
            SqlParamC.fncSetParam("HATTIME_TO", True, KEKEKJAG00_C.pHATTIME_To & "59")
            ''''''SqlParamC.fncSetParam("HATTIME_TO", True, KEKEKJAG00_C.pHATTIME_To)
            ''''''SqlParamC.fncSetParam("HATTIME_TO", True, KEKEKJAG00_C.pHATTIME_To & "99")
            '2017/10/26 H.Mori add 2017改善開発 No3-1 END
        End If
        If KEKEKJAG00_C.pTKTANCD.Length > 0 Then
            SqlParamC.fncSetParam("TKTANCD", True, KEKEKJAG00_C.pTKTANCD)
        End If
        If KEKEKJAG00_C.pHATKBN.Length > 0 Then
            SqlParamC.fncSetParam("HATKBN", True, KEKEKJAG00_C.pHATKBN)
        End If

        '2014/12/05 H.Hosoda mod 監視改善2014 No.7 START
        'If KEKEKJAG00_C.pTAIOKBN.Length > 0 Then
        '    SqlParamC.fncSetParam("TAIOKBN", True, KEKEKJAG00_C.pTAIOKBN)
        'End If
        'チェックボックス　0：チェックなし　1：チェックあり
        '対応区分　1：電話　2：出動　3：重複
        If KEKEKJAG00_C.pTAIOKBN1 = "0" Then
            SqlParamC.fncSetParam("TAIOKBN1", True, "")
        Else
            SqlParamC.fncSetParam("TAIOKBN1", True, "1")
        End If

        If KEKEKJAG00_C.pTAIOKBN2 = "0" Then
            SqlParamC.fncSetParam("TAIOKBN2", True, "")
        Else
            SqlParamC.fncSetParam("TAIOKBN2", True, "2")
        End If

        If KEKEKJAG00_C.pTAIOKBN3 = "0" Then
            SqlParamC.fncSetParam("TAIOKBN3", True, "")
        Else
            SqlParamC.fncSetParam("TAIOKBN3", True, "3")
        End If
        '2014/12/05 H.Hosoda mod 監視改善2014 No.7 END

        If KEKEKJAG00_C.pTMSKB.Length > 0 Then
            SqlParamC.fncSetParam("TMSKB", True, KEKEKJAG00_C.pTMSKB)
        End If
        If KEKEKJAG00_C.pJUTEL.Length > 0 Then
            SqlParamC.fncSetParam("KTELNO", True, KEKEKJAG00_C.pJUTEL)
        End If
        '2016/11/25 H.Mori del 監視改善2016 No3-2 START
        '2014/12/05 H.Hosoda add 監視改善2014 No.7 START
        'If KEKEKJAG00_C.pNCUTEL.Length > 0 Then
        '    SqlParamC.fncSetParam("NCUTELNO", True, KEKEKJAG00_C.pNCUTEL)
        'End If
        '2014/12/05 H.Hosoda add 監視改善2014 No.7 END
        '2016/11/25 H.Mori del 監視改善2016 No3-2 END
        If KEKEKJAG00_C.pJUSYONM.Length > 0 Then
            SqlParamC.fncSetParam("JUSYONM", True, KEKEKJAG00_C.pJUSYONM)
        End If
        '2016/11/24 H.Mori del 監視改善2016 No3-3 START
        'If KEKEKJAG00_C.pJUSYOKN.Length > 0 Then
        '    SqlParamC.fncSetParam("JUSYOKN", True, KEKEKJAG00_C.pJUSYOKN)
        'End If
        '2016/11/24 H.Mori del 監視改善2016 No3-3 END

        '2019/11/01 T.Ono mod 監視改善2019 START
        'If KEKEKJAG00_C.pKURACD.Length > 0 Then
        '    SqlParamC.fncSetParam("KURACD", True, KEKEKJAG00_C.pKURACD)
        'End If
        ''2013/12/10 T.Ono add 監視改善2013
        'If KEKEKJAG00_C.pJACD.Length > 0 Then
        '    SqlParamC.fncSetParam("JACD", True, KEKEKJAG00_C.pJACD)
        'End If
        'If KEKEKJAG00_C.pHANGRP.Length > 0 Then    '2014/12/08 H.Hosoda add 監視改善2014 No.7 
        '    SqlParamC.fncSetParam("HANGRP", True, KEKEKJAG00_C.pHANGRP)
        'End If
        'If KEKEKJAG00_C.pKINRENGRP.Length > 0 Then    '2016/11/25 H.Mori add 監視改善2016 No3-1 
        '    SqlParamC.fncSetParam("KINRENGRP", True, KEKEKJAG00_C.pKINRENGRP)
        'End If
        If KEKEKJAG00_C.pJACD.Length > 0 Then
            SqlParamC.fncSetParam("JACD", True, KEKEKJAG00_C.pJACD)
            SqlParamC.fncSetParam("KURACD", True, KEKEKJAG00_C.pJACD_CLI)
            SqlParamC.fncSetParam("KURACD_TO", True, KEKEKJAG00_C.pJACD_CLI)
        Else
            If KEKEKJAG00_C.pKURACD.Length > 0 Then
                SqlParamC.fncSetParam("KURACD", True, KEKEKJAG00_C.pKURACD)
            End If
            If KEKEKJAG00_C.pKURACD_TO.Length > 0 Then
                SqlParamC.fncSetParam("KURACD_TO", True, KEKEKJAG00_C.pKURACD_TO)
            End If
        End If
        '2019/11/01 T.Ono mod 監視改善2019 END
        If KEKEKJAG00_C.pACBCD.Length > 0 Then
            SqlParamC.fncSetParam("ACBCD", True, KEKEKJAG00_C.pACBCD)
            '2019/11/01 T.Ono add 監視改善2019
            SqlParamC.fncSetParam("ACBCD_TO", True, KEKEKJAG00_C.pACBCD_TO)
        End If
        If KEKEKJAG00_C.pUSER_CD.Length > 0 Then
            SqlParamC.fncSetParam("USER_CD", True, KEKEKJAG00_C.pUSER_CD)
        End If
        '2011.11.15 ADD H.Uema
        If KEKEKJAG00_C.pKMCD.Length > 0 Then
            SqlParamC.fncSetParam("KMCD", True, KEKEKJAG00_C.pKMCD)
        End If

    End Sub
End Class
