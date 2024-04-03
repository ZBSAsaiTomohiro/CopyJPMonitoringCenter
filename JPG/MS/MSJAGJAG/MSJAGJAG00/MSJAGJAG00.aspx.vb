'***********************************************
' JAグループ作成マスタ  メイン画面
'***********************************************
' 変更履歴

Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common
Imports JPG.Common.log

Imports System.Text

Partial Class MSJAGJAG00
    Inherits System.Web.UI.Page

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

        '.NETの仕様変更により、ReadOnly属性をASPXでつけると、サーバ側で値の参照ができなくなるため、VB側でAttributeでつける
        If MyBase.IsPostBack = False Then
            txtKURACD.Attributes.Add("ReadOnly", "true")
            txtACBCD_F.Attributes.Add("ReadOnly", "true")
            txtACBCD_T.Attributes.Add("ReadOnly", "true")
            txtGROUPCD.Attributes.Add("ReadOnly", "true")
            Dim objDefNO As System.Web.UI.WebControls.TextBox
            Dim objDefTARGET As System.Web.UI.WebControls.CheckBox
            Dim objDefACBCD As System.Web.UI.WebControls.TextBox
            Dim objDefGROUPCD As System.Web.UI.WebControls.TextBox
            Dim objDefINS_DATE As System.Web.UI.WebControls.TextBox
            Dim objDefINS_USER As System.Web.UI.WebControls.TextBox
            Dim objDefUPD_DATE As System.Web.UI.WebControls.TextBox
            Dim objDefUPD_USER As System.Web.UI.WebControls.TextBox
            Dim i As Integer
            For i = 1 To 100
                objDefNO = CType(FindControl("txtNO_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                objDefTARGET = CType(FindControl("chkTARGET_" & CStr(i)), System.Web.UI.WebControls.CheckBox)
                objDefACBCD = CType(FindControl("txtACBCD_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                objDefGROUPCD = CType(FindControl("txtGROUPCD_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                objDefINS_DATE = CType(FindControl("txtINS_DATE_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                objDefINS_USER = CType(FindControl("txtINS_USER_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                objDefUPD_DATE = CType(FindControl("txtUPD_DATE_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                objDefUPD_USER = CType(FindControl("txtUPD_USER_" & CStr(i)), System.Web.UI.WebControls.TextBox)

                objDefNO.Attributes.Add("ReadOnly", "true")
                objDefTARGET.Checked = True
                objDefACBCD.Attributes.Add("ReadOnly", "true")
                objDefGROUPCD.Attributes.Add("ReadOnly", "true")
                objDefINS_DATE.Attributes.Add("ReadOnly", "true")
                objDefINS_USER.Attributes.Add("ReadOnly", "true")
                objDefUPD_DATE.Attributes.Add("ReadOnly", "true")
                objDefUPD_USER.Attributes.Add("ReadOnly", "true")
            Next
        End If

        '//------------------------------------------
        '//　HTTPヘッダを送信
        HttpHeaderC.mNoCache(Response)

        '//------------------------------------------
        '//　認証クラスのインスタンス生成
        AuthC = New CAuthenticate(Request, Response)

        '//------------------------------------------
        '//　認証処理
        '<TODO>：使用可能権限を指定する
        '[JAグループ作成マスタ]使用可能権限(運:○/営:○/監:○/出:×)
        AuthC.fncAuthCheck(Server, AuthC.pGROUP_UNKOU & "," & AuthC.pGROUP_EIGYOU & "," & AuthC.pGROUP_KANSHI)

        '//------------------------------------------
        '<TODO>ポップアップ/登録系フレームの出力
        '      [hdnKensaku(Hidden)]を作成する事
        If hdnKensaku.Value = "COPOPUPG00" Then
            Server.Transfer("../../../Popup/COPOPUPG00.aspx")
        End If

        '//------------------------------------------
        '// Script書込み用変数宣言
        Dim strScript As New StringBuilder("")
        Dim cscript1 As New CScript
        Dim strScriptPath As String
        strScriptPath = ConfigurationSettings.AppSettings("SCRIPTPATH")

        '------------------------------------------------------------------------------
        '<TODO>HTML内に必要なJavaScript/CSSはここで[strScript]変数に格納後
        '      画面上[lblScript]に書き込みを行います(SPANタグとしてクライアントにスクリプトが
        '      出力されます。)
        '//------------------------------------------
        '//　JavaScript格納
        strScript.Append("<Script language=javascript>")
        '<独自スクリプト>
        strScript.Append(cscript1.mWriteScript( _
             MyBase.MapPath("../../../MS/MSJAGJAG/MSJAGJAG00/") & "MSJAGJAG00.js"))
        '<フォーカス関連関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncFo.js"))
        '<入力チェック関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncChk.js"))
        '<数値関連関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncNumChk.js"))
        '<バイト数カウント関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncGetByte.js"))
        '<全角チェック関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncZenkakuChk.js"))
        strScript.Append("</Script>")
        '//------------------------------------------
        '//　Css格納
        strScript.Append("<Style>")
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "CssData.css"))
        strScript.Append("</Style>")
        '//------------------------------------------
        '//　Script書込み
        lblScript.Text = strScript.ToString

        '//------------------------------------------------------------------------------
        If MyBase.IsPostBack = False Then
            '//--------------------------------------
            '//初めて開いた時だけ実行される

            '//--------------------------------------
            '初期表示として必要なコントロールの設定を行います
            Call fncIni_format()    '//値の初期化

            '//--------------------------------------
            '初期画面の状態設定(画面を【検索前状態】にする（入力データはそのまま遷移させる)
            Call fncIni_statebf()

            '//--------------------------------------------------------------------------
            'フォーカスをセットする
            strMsg.Append("Form1.btnSelect.focus();")

            '//-----------------------------------------------------
            '// 営業所グループは当画面を使わないため、hdnBackUrlも使用しない
            '//-----------------------------------------------------
            hdnBackUrl.Value = ""

            '//--------------------------------------
            'グループコード(新規登録用)を入力不可にするためのフラグ　0:入力可　1:入力不可
            hdnReadOnlyFlg.Value = "0"
        Else
            '//--------------------------------------
            '//　２回目以降実行される
            '//--------------------------------------

            '区分コンボボックスの再設定
            Call fncCombo_Create_JAGKBN()
            cboJAGKBN.SelectedValue = Request.Form("cboJAGKBN")
            hdnJAGKBN.Value = Request.Form("cboJAGKBN")

            ''2017/02/09 W.Ganeko 2016監視改善 №10 start
            If hdnJAGKBN.Value = "003" Then
                Dim objUSERCD_F As System.Web.UI.WebControls.TextBox
                Dim objUSERCD_T As System.Web.UI.WebControls.TextBox
                Dim i As Integer
                For i = 1 To 100
                    objUSERCD_F = CType(FindControl("txtUSERCD_F_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                    objUSERCD_T = CType(FindControl("txtUSERCD_T_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                    objUSERCD_F.Attributes.Add("ReadOnly", "true")
                    objUSERCD_T.Attributes.Add("ReadOnly", "true")
                    objUSERCD_F.BackColor = Color.Gainsboro
                    objUSERCD_T.BackColor = Color.Gainsboro
                Next
            End If
            ''2017/02/09 W.Ganeko 2016監視改善 №10 end

            If hdnReadOnlyFlg.Value = "1" Then
                'グループコード(新規登録用)は入力不可にする
                txtGROUPCD_NEW.Attributes.Add("ReadOnly", "true")
                txtGROUPCD_NEW.BackColor = Color.Gainsboro
            End If
        End If


        '<TODO>自分の画面IDをHIDDENのhdnMyAspxに書き込む（システム共通）
        hdnMyAspx.Value = "MSJAGJAG00"
        '//-------------------------------------------------

    End Sub

    '******************************************************************************
    '* 検索処理がされる前の画面状態（ReadOnlyやDisabled）
    '********************************/*********************************************
    Private Sub fncIni_statebf()
        '//--------------------------------------------------------------------------
        '<TODO>検索前の状態にコントロールの状態を設定する

        btnKURACD.Disabled = False
        btnACBCD_F.Disabled = False
        btnACBCD_T.Disabled = False
        btnGROUPCD.Disabled = False

    End Sub

    '******************************************************************************
    '* 検索処理がされた後の画面状態（ReadOnlyやDisabled）
    '******************************************************************************
    Private Sub fncIni_stateaf()
        '//--------------------------------------------------------------------------
        '<TODO>検索後の状態にコントロールの状態を設定する
        '
        txtKURACD.Attributes.Add("ReadOnly", "true")
        txtACBCD_F.Attributes.Add("ReadOnly", "true")
        txtACBCD_T.Attributes.Add("ReadOnly", "true")
        txtGROUPCD.Attributes.Add("ReadOnly", "true")
        Dim objNO As System.Web.UI.WebControls.TextBox
        Dim objTARGET As System.Web.UI.WebControls.CheckBox
        Dim objACBCD As System.Web.UI.WebControls.TextBox
        Dim objGROUPCD As System.Web.UI.WebControls.TextBox
        Dim objINS_DATE As System.Web.UI.WebControls.TextBox
        Dim objINS_USER As System.Web.UI.WebControls.TextBox
        Dim objUPD_DATE As System.Web.UI.WebControls.TextBox
        Dim objUPD_USER As System.Web.UI.WebControls.TextBox
        Dim i As Integer
        For i = 1 To 100
            objNO = CType(FindControl("txtNO_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objTARGET = CType(FindControl("chkTARGET_" & CStr(i)), System.Web.UI.WebControls.CheckBox)
            objACBCD = CType(FindControl("txtACBCD_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objGROUPCD = CType(FindControl("txtGROUPCD_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objINS_DATE = CType(FindControl("txtINS_DATE_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objINS_USER = CType(FindControl("txtINS_USER_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objUPD_DATE = CType(FindControl("txtUPD_DATE_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objUPD_USER = CType(FindControl("txtUPD_USER_" & CStr(i)), System.Web.UI.WebControls.TextBox)

            objNO.Attributes.Add("ReadOnly", "true")
            objTARGET.Checked = True
            objACBCD.Attributes.Add("ReadOnly", "true")
            objGROUPCD.Attributes.Add("ReadOnly", "true")
            objINS_DATE.Attributes.Add("ReadOnly", "true")
            objINS_USER.Attributes.Add("ReadOnly", "true")
            objUPD_DATE.Attributes.Add("ReadOnly", "true")
            objUPD_USER.Attributes.Add("ReadOnly", "true")
        Next
    End Sub

    '******************************************************************************
    '* 各コントロールの設定値の初期化
    '******************************************************************************
    Private Sub fncIni_format()
        '//--------------------------------------------------------------------------

        ''検索条件
        '区分
        fncCombo_Create_JAGKBN()
        hdnJAGKBN.Value = ""
        'クライアントコード
        txtKURACD.Text = ""
        hdnKURACD.Value = ""
        'JA支所コード
        txtACBCD_F.Text = ""
        hdnACBCD_F.Value = ""
        txtACBCD_T.Text = ""
        hdnACBCD_T.Value = ""
        'グループコード
        txtGROUPCD.Text = ""
        hdnGROUPCD.Value = ""
        '出力
        chkSYU_TOUROKU.Checked = True
        chkSYU_MITOUROKU.Checked = True

        ''グループ新規登録
        txtGROUPCD_NEW.Text = ""
        txtGROUPNM_NEW.Text = ""
        hdnINS_DATE_NEW.Value = ""
        hdnINS_USER_NEW.Value = ""
        hdnUPD_DATE_NEW.Value = ""
        hdnUPD_USER_NEW.Value = ""


        'キー以外の値を初期化する
        Call fncIni_notkey()

    End Sub

    '******************************************************************************
    '* キー以外の値を初期化する
    '******************************************************************************
    Private Sub fncIni_notkey()
        '//--------------------------------------------------------------------------
        '<TODO>コントロールの値を初期化する

        hdnJAGKBN_MOTO.Value = ""
        hdnKURACD_MOTO.Value = ""
        hdnACBCD_F_MOTO.Value = ""
        hdnACBCD_T_MOTO.Value = ""
        hdnGROUPCD_MOTO.Value = ""

        Dim objTARGET As System.Web.UI.WebControls.CheckBox
        Dim objKURACD As System.Web.UI.WebControls.TextBox
        Dim objACBCD As System.Web.UI.WebControls.TextBox
        Dim objhdnACBCD As System.Web.UI.HtmlControls.HtmlInputHidden
        Dim objGROUPCD As System.Web.UI.WebControls.TextBox
        Dim objhdnGROUPCD As System.Web.UI.HtmlControls.HtmlInputHidden
        Dim objUSERCD_F As System.Web.UI.WebControls.TextBox
        Dim objUSERCD_T As System.Web.UI.WebControls.TextBox
        Dim objBIKO As System.Web.UI.WebControls.TextBox
        Dim objINS_DATE As System.Web.UI.WebControls.TextBox
        Dim objINS_USER As System.Web.UI.WebControls.TextBox
        Dim objUPD_DATE As System.Web.UI.WebControls.TextBox
        Dim objUPD_USER As System.Web.UI.WebControls.TextBox

        Dim i As Integer
        For i = 1 To 100
            objTARGET = CType(FindControl("chkTARGET_" & CStr(i)), System.Web.UI.WebControls.CheckBox)
            objKURACD = CType(FindControl("txtKURACD_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objACBCD = CType(FindControl("txtACBCD_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objhdnACBCD = CType(FindControl("hdnACBCD_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
            objGROUPCD = CType(FindControl("txtGROUPCD_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objhdnGROUPCD = CType(FindControl("hdnGROUPCD_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
            objUSERCD_F = CType(FindControl("txtUSERCD_F_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objUSERCD_T = CType(FindControl("txtUSERCD_T_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objBIKO = CType(FindControl("txtBIKO_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objINS_DATE = CType(FindControl("txtINS_DATE_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objINS_USER = CType(FindControl("txtINS_USER_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objUPD_DATE = CType(FindControl("txtUPD_DATE_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objUPD_USER = CType(FindControl("txtUPD_USER_" & CStr(i)), System.Web.UI.WebControls.TextBox)


            objTARGET.Checked = True
            objKURACD.Text = ""
            objACBCD.Text = ""
            objhdnACBCD.Value = ""
            objGROUPCD.Text = ""
            objhdnGROUPCD.Value = ""
            objUSERCD_F.Text = ""
            objUSERCD_T.Text = ""
            objBIKO.Text = ""
            objINS_DATE.Text = ""
            objINS_USER.Text = ""
            objUPD_DATE.Text = ""
            objUPD_USER.Text = ""

        Next

    End Sub

    '******************************************************************************
    '* 検索ボタンが押下されたときの処理
    '******************************************************************************
    Private Sub btnSelect_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.ServerClick
        Dim strRec As String

        'データを検索し、データを出力します
        strRec = fncbtnKensaku_ClickEvent("1")

        '-------------------------------------------------
        '//ＡＰログ書き込み
        Dim LogC As New CLog
        Dim strRecLog As String
        strRecLog = LogC.mAPLog(Me.Session.SessionID, AuthC.pUSERNAME, AuthC.pIPADDRESS, hdnMyAspx.Value, "4", strRec, Request.Form)
        If strRecLog <> "OK" Then
            Dim errmsgc As New CErrMsg
            strMsg.Append("alert('システムエラー：" & errmsgc.mGetArtMsg(strRecLog) & "');")
        End If
    End Sub

    '******************************************************************************
    '* 登録ボタンが押下されたときの処理
    '******************************************************************************
    Private Sub btnUpdate_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.ServerClick
        Dim strRec As String
        strRec = fncbtnJikkou_ClickEvent(hdnKBN.Value)

        Call fncIni_stateaf()
    End Sub

    '******************************************************************************
    '* 取消ボタンが押下されたときの処理
    '******************************************************************************
    Private Sub btnClear_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.ServerClick
        Call fncIni_format()    '//値の初期化
        Call fncIni_statebf()   '//状態の初期化

        hdnReadOnlyFlg.Value = "0" '//グループコード(新規登録用)を入力可にする
        '//------------------------------------------
        '<TODO>フォーカスをセットする（初期画面に戻ったので(PageLoad同様)キーにセット）
        strMsg.Append("Form1.btnSelect.focus();")
        Call fncIni_stateaf()
    End Sub

    '******************************************************************************
    '* 一括登録ボタンが押下されたときの処理
    '******************************************************************************
    Private Sub btnIKKATU_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIKKATU.ServerClick
        Dim strRec As String
        strRec = fncbtnIKKATU_ClickEvent(hdnKBN.Value)

        Call fncIni_stateaf()
    End Sub

    '******************************************************************************
    ' データ出力ボタンが押下されたときの処理　Excel出力(チェックつき)
    '******************************************************************************
    Private Sub btnCSVOUT_ServerClick(ByVal sender As System.Object, _
                                    ByVal e As System.EventArgs) Handles btnCSVOUT.ServerClick
        Dim strRec As String
        Dim MSJAGJAG00C As New MSJAGJAG00MSJAGJAW00.MSJAGJAW00

        '//　認証クラスのインスタンス生成
        'AuthC = New CAuthenticate(Request, Response)

        Dim strRecMsg As String = ""

        strRec = MSJAGJAG00C.mCSV( _
                        Me.Session.SessionID, _
                        AuthC.pAUTHCENTERCD, _
                        hdnJAGKBN.Value.Trim, _
                        hdnKURACD.Value.Trim, _
                        hdnACBCD_F.Value.Trim, _
                        hdnACBCD_T.Value.Trim, _
                        hdnGROUPCD.Value.Trim, _
                        chkSYU_TOUROKU.Checked, _
                        chkSYU_MITOUROKU.Checked _
                        )



        If strRec.Substring(0, 5) = "ERROR" Then
            'エラーであればブラウザにメッセージ表示
            Dim ErrMsgC As New CErrMsg
            strRecMsg = "システムエラー：" & ErrMsgC.mGetArtMsg(strRec)
            strMsg.Append("alert('" & strRecMsg & "');")

        ElseIf strRec.Substring(0, 5) = "DATA0" Then
            'データが0件の場合
            strRecMsg = "対象データが存在しません"
            strMsg.Append("alert('" & strRecMsg & "');")
            strMsg.Append("Form1.btnSelect.focus();")

        Else
            '「開く、保存」のダイヤログが出るようにHTTPヘッダに追加
            'ファイル名は、HttpUtility.UrlEncodeメソッドを使用してSJISにエンコードする必要がある
            HttpHeaderC.mDownLoadCSV(Response, "JAグループ作成マスタ.csv")
            Response.WriteFile(strRec)
            Response.End()

            strRecMsg = "OK"
        End If

        strRec = strRecMsg
        '-------------------------------------------------
        '//ＡＰログ書き込み
        Dim LogC As New CLog
        Dim strRecLog As String
        strRecLog = LogC.mAPLog(Me.Session.SessionID, AuthC.pUSERNAME, AuthC.pIPADDRESS, hdnMyAspx.Value, "5", strRec, Request.Form)
        If strRecLog <> "OK" Then
            Dim errmsgc As New CErrMsg
            strMsg.Append("alert('システムエラー：" & errmsgc.mGetArtMsg(strRecLog) & "');")
        End If
    End Sub

    '******************************************************************************
    '* グループ追加ボタンが押下されたときの処理
    '******************************************************************************
    Private Sub btnGROUP_ADD_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGROUP_ADD.ServerClick

        Dim strRec As String

        hdnINS_DATE_NEW.Value = ""
        hdnINS_USER_NEW.Value = ""
        hdnUPD_DATE_NEW.Value = ""
        hdnUPD_USER_NEW.Value = ""

        strRec = fncbtnGROUP_ADD_ClickEvent(hdnKBN.Value)

        Call fncIni_notkey()
        Call fncIni_stateaf()
    End Sub

    '******************************************************************************
    '* グループコード名検索ボタンが押下されたときの処理
    '******************************************************************************
    Private Sub btnGROUP_SEARCH_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGROUP_SEARCH.ServerClick

        Dim strRecMsg As String = ""

        '//------------------------------------------
        '//<TODO>Select文の作成
        Dim SQLC As New MSJAGJAG00CCSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet

        If hdnJAGKBN.Value.Trim = "001" Then
            strSQL.Append("SELECT ")
            strSQL.Append("     GROUPCD ")
            strSQL.Append("     ,GROUPNM ")
            strSQL.Append("     ,TO_CHAR(INS_DATE, 'YYYY/MM/DD HH24:MI:SS') AS INS_DATE ")
            strSQL.Append("     ,INS_USER ")
            strSQL.Append("     ,TO_CHAR(UPD_DATE, 'YYYY/MM/DD HH24:MI:SS') AS UPD_DATE ")
            strSQL.Append("     ,UPD_USER ")
            strSQL.Append("FROM ")
            strSQL.Append("     M10_HANJIGYOSYA ")
            strSQL.Append("WHERE ")
            strSQL.Append("     GROUPCD = :GROUPCD ")
        ElseIf hdnJAGKBN.Value.Trim = "002" Then
            'JA担当者・報告先・注意事項マスタ　2015/12/10 T.Ono add 2015改善開発 №7
            strSQL.Append("SELECT  ")
            strSQL.Append("     GROUPCD  ")
            strSQL.Append("     ,GROUPNM  ")
            strSQL.Append("     ,TO_CHAR(INS_DATE, 'YYYY/MM/DD HH24:MI:SS') AS INS_DATE  ")
            strSQL.Append("     ,INS_USER  ")
            strSQL.Append("     ,TO_CHAR(UPD_DATE, 'YYYY/MM/DD HH24:MI:SS') AS UPD_DATE  ")
            strSQL.Append("     ,UPD_USER  ")
            strSQL.Append("FROM  ")
            strSQL.Append("     M11_JAHOKOKU  ")
            strSQL.Append("WHERE  ")
            strSQL.Append("     GROUPCD = :GROUPCD ")
            strSQL.Append("AND  LPAD(TANCD, 2, '0') = '01' ")
        ElseIf hdnJAGKBN.Value.Trim = "003" Then
            '自動対応マスタ　2017/02/09 W.GANEKO add 2016改善開発 №10
            strSQL.Append("SELECT  ")
            strSQL.Append("     GROUPCD  ")
            strSQL.Append("     ,GROUPNM  ")
            strSQL.Append("     ,TO_CHAR(INS_DATE, 'YYYY/MM/DD HH24:MI:SS') AS INS_DATE  ")
            strSQL.Append("     ,'' AS INS_USER  ")
            strSQL.Append("     ,TO_CHAR(UPD_DATE, 'YYYY/MM/DD HH24:MI:SS') AS UPD_DATE  ")
            strSQL.Append("     ,'' AS UPD_USER  ")
            strSQL.Append("FROM  ")
            strSQL.Append("     M08_AUTOTAIOU  ")
            strSQL.Append("WHERE  ")
            strSQL.Append("     GROUPCD = :GROUPCD ")
        ElseIf hdnJAGKBN.Value.Trim = "004" Then
            '販売店グループマスタ　2019/01/24 T.Ono add 2018改善開発
            strSQL.Append("SELECT ")
            strSQL.Append("     GROUPCD ")
            strSQL.Append("     ,GROUPNM ")
            strSQL.Append("     ,TO_CHAR(INS_DATE, 'YYYY/MM/DD HH24:MI:SS') AS INS_DATE ")
            strSQL.Append("     ,INS_USER ")
            strSQL.Append("     ,TO_CHAR(UPD_DATE, 'YYYY/MM/DD HH24:MI:SS') AS UPD_DATE ")
            strSQL.Append("     ,UPD_USER ")
            strSQL.Append("FROM ")
            strSQL.Append("     M12_HANBAITEN ")
            strSQL.Append("WHERE ")
            strSQL.Append("     GROUPCD = :GROUPCD ")
        Else
            strSQL.Append("SELECT ")
            strSQL.Append("     'X' ")
            strSQL.Append("FROM ")
            strSQL.Append("     DUAL ")
            strSQL.Append("WHERE ")
            strSQL.Append("     1 <> 1 ")
        End If


        '//------------------------------------------
        '//<TODO>パラメータの設定
        SqlParamC.fncSetParam("GROUPCD", True, hdnGROUPCD.Value.Trim)

        dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

        If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
            'データない場合
            strRecMsg = "対象データが存在しません"
            strMsg.Append("alert('" & strRecMsg & "');")
            strMsg.Append("Form1.btnGROUP_SEARCH.focus();")
        Else
            txtGROUPCD_NEW.Text = Convert.ToString(dbData.Tables(0).Rows(0).Item("GROUPCD")).Trim
            txtGROUPNM_NEW.Text = Convert.ToString(dbData.Tables(0).Rows(0).Item("GROUPNM")).Trim
            hdnINS_DATE_NEW.Value = Convert.ToString(dbData.Tables(0).Rows(0).Item("INS_DATE")).Trim
            hdnINS_USER_NEW.Value = Convert.ToString(dbData.Tables(0).Rows(0).Item("INS_USER")).Trim
            hdnUPD_DATE_NEW.Value = Convert.ToString(dbData.Tables(0).Rows(0).Item("UPD_DATE")).Trim
            hdnUPD_USER_NEW.Value = Convert.ToString(dbData.Tables(0).Rows(0).Item("UPD_USER")).Trim
            'グループコード(新規登録用)は入力不可にする
            txtGROUPCD_NEW.Attributes.Add("ReadOnly", "true")
            txtGROUPCD_NEW.BackColor = Color.Gainsboro
            hdnReadOnlyFlg.Value = "1"
            'フォーカスをセットする（グループコード名検索にセット）
            strMsg.Append("Form1.btnGROUP_SEARCH.focus();")
        End If

        Call fncIni_notkey()
        Call fncIni_stateaf()
    End Sub

    '******************************************************************************
    '* グループコード名変更確定ボタンが押下されたときの処理
    '******************************************************************************
    Private Sub btnGROUP_MOD_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGROUP_MOD.ServerClick
        Dim strRec As String

        strRec = fncbtnGROUP_ADD_ClickEvent(hdnKBN.Value)

        Call fncIni_notkey()
        Call fncIni_stateaf()
    End Sub

    '******************************************************************************
    '*　概　要：絞込み条件を渡すプロパティ
    '*　備　考：抽出条件１の値を渡す
    '******************************************************************************
    Public ReadOnly Property pCode1() As String
        Get
            Dim strRec As String = ""
            Dim col As Integer = 0
            Dim objKURACD As System.Web.UI.WebControls.TextBox
            col = Convert.ToInt32(hdnPopcrtl.Value)

            If hdnPopcrtl.Value = "1" Then      '//クライアントコード一覧 
                strRec = AuthC.pAUTHCENTERCD    '//ＡＤ認証の使用可能監視センターコード
            ElseIf hdnPopcrtl.Value = "2" Then  '//JA支所コード（From）一覧
                strRec = hdnKURACD.Value.Trim
            ElseIf hdnPopcrtl.Value = "3" Then  '//JA支所コード（To）一覧
                strRec = hdnKURACD.Value.Trim
            ElseIf hdnPopcrtl.Value = "4" Then  '//グループコード一覧
                strRec = AuthC.pAUTHCENTERCD    '//ＡＤ認証の使用可能監視センターコード
            ElseIf col >= 101 And col <= 200 Then
                col = col - 100
                objKURACD = CType(FindControl("txtKURACD_" & CStr(col)), System.Web.UI.WebControls.TextBox)
                strRec = objKURACD.Text.Trim
            ElseIf col >= 201 And col <= 300 Then
                strRec = AuthC.pAUTHCENTERCD
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：絞込み条件を渡すプロパティ
    '*　備　考：抽出条件２の値を渡す
    '******************************************************************************
    Public ReadOnly Property pCode2() As String
        Get
            Dim strRec As String = ""
            Dim col As Integer = 0
            Dim objKURACD As System.Web.UI.WebControls.TextBox
            col = Convert.ToInt32(hdnPopcrtl.Value)

            If hdnPopcrtl.Value = "1" Then      '//クライアントコード一覧 
                strRec = ""
            ElseIf hdnPopcrtl.Value = "2" Then  '//JA支所コード（From）一覧
                strRec = ""
            ElseIf hdnPopcrtl.Value = "3" Then  '//JA支所コード（To）一覧
                strRec = ""
            ElseIf hdnPopcrtl.Value = "4" Then  '//グループコード一覧
                strRec = hdnKURACD.Value.Trim
            ElseIf col >= 101 And col <= 200 Then
                strRec = ""
            ElseIf col >= 201 And col <= 300 Then
                col = col - 200
                objKURACD = CType(FindControl("txtKURACD_" & CStr(col)), System.Web.UI.WebControls.TextBox)
                strRec = objKURACD.Text.Trim
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：出力する一覧の名前を渡すプロパティ
    '*　備　考：ポップアップのタイトル名を渡す
    '******************************************************************************
    Public ReadOnly Property pListName() As String
        Get
            Dim strRec As String = ""
            Dim col As Integer = 0
            col = Convert.ToInt32(hdnPopcrtl.Value)

            If hdnPopcrtl.Value = "1" Then          '//クライアントコード一覧
                strRec = "クライアントコード一覧"
            ElseIf hdnPopcrtl.Value = "2" Then      '//JA支所コード（From）一覧
                strRec = "ＪＡ支所コード一覧"
            ElseIf hdnPopcrtl.Value = "3" Then      '//JA支所コード（To）一覧
                strRec = "ＪＡ支所コード一覧"
            ElseIf hdnPopcrtl.Value = "4" Then      '//グループコード一覧
                If Request.Form("cboJAGKBN") = "001" Then
                    strRec = "販売事業者グループ一覧" '販売事業者グループ
                ElseIf Request.Form("cboJAGKBN") = "002" Then '2015/11/25 T.Ono add 2015改善開発 №7
                    strRec = "JA担当者・報告先・注意事項グループ一覧" 'JA担当者・報告先・注意事項マスタ
                ElseIf Request.Form("cboJAGKBN") = "003" Then '2017/02/09 W.Ganeko add 2016改善開発 №10
                    strRec = "自動対応内容グループ一覧" '自動対応グループマスタ
                ElseIf Request.Form("cboJAGKBN") = "004" Then '2019/01/24 T.Ono add 2018改善開発
                    strRec = "販売店グループ一覧" '販売店グループマスタ
                Else
                    strRec = ""
                End If
            ElseIf col >= 101 And col <= 200 Then
                strRec = "ＪＡ支所コード一覧"
            ElseIf col >= 201 And col <= 300 Then
                If Request.Form("cboJAGKBN") = "001" Then
                    strRec = "販売事業者グループ一覧" '販売事業者グループ
                ElseIf Request.Form("cboJAGKBN") = "002" Then '2015/11/25 T.Ono add 2015改善開発 №7
                    strRec = "JA担当者・報告先・注意事項グループ一覧" 'JA担当者・報告先・注意事項マスタ
                ElseIf Request.Form("cboJAGKBN") = "003" Then '2017/02/09 W.Ganeko add 2016改善開発 №10
                    strRec = "自動対応内容グループ一覧" '自動対応グループマスタ
                ElseIf Request.Form("cboJAGKBN") = "004" Then '2019/01/24 T.Ono add 2018改善開発
                    strRec = "販売店グループ一覧" '販売店グループマスタ
                Else
                    strRec = ""
                End If
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：出力する一覧を制御する値を渡すプロパティ
    '*　備　考：ポップアップの種類を選択する
    '******************************************************************************
    Public ReadOnly Property pListCd() As String
        Get
            Dim strRec As String = ""
            Dim col As Integer = 0
            col = Convert.ToInt32(hdnPopcrtl.Value)

            If hdnPopcrtl.Value = "1" Then
                strRec = "CLI"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = "JASS3"
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = "JASS3"
            ElseIf hdnPopcrtl.Value = "4" Then
                If Request.Form("cboJAGKBN") = "001" Then
                    strRec = "HANG2" '販売事業者グループ
                ElseIf Request.Form("cboJAGKBN") = "002" Then '2015/11/25 T.Ono add 2015改善開発 №7
                    strRec = "JAHOKOKU" 'JA担当者・報告先・注意事項マスタ
                ElseIf Request.Form("cboJAGKBN") = "003" Then '2017/02/09 W.Ganeko add 2016改善開発 №10
                    strRec = "AUTOGROUP" '自動対応グループマスタ
                ElseIf Request.Form("cboJAGKBN") = "004" Then '2019/01/24 T.Ono add 2018改善開発
                    strRec = "HANBAITEN" '販売店グループマスタ
                Else
                    strRec = ""
                End If
            ElseIf col >= 101 And col <= 200 Then
                strRec = "JASS3"
            ElseIf col >= 201 And col <= 300 Then
                If Request.Form("cboJAGKBN") = "001" Then
                    strRec = "HANG2" '販売事業者グループ
                ElseIf Request.Form("cboJAGKBN") = "002" Then '2015/11/25 T.Ono add 2015改善開発 №7
                    strRec = "JAHOKOKU" 'JA担当者・報告先・注意事項マスタ
                ElseIf Request.Form("cboJAGKBN") = "003" Then '2017/02/09 W.Ganeko add 2016改善開発 №10
                    strRec = "AUTOGROUP" '自動対応グループマスタ
                ElseIf Request.Form("cboJAGKBN") = "004" Then '2019/01/24 T.Ono add 2018改善開発
                    strRec = "HANBAITEN" '販売店グループマスタ
                Else
                    strRec = ""
                End If
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property


    '******************************************************************************
    '*　概　要：コードを返すオブジェクトの名前値を渡すプロパティ
    '*　備　考：データ選択後、コードを返すオブジェクト名を指定する
    '******************************************************************************
    Public ReadOnly Property pBackCode() As String
        Get
            Dim strRec As String = ""
            Dim col As Integer = 0
            col = Convert.ToInt32(hdnPopcrtl.Value)

            If hdnPopcrtl.Value = "1" Then
                strRec = "hdnKURACD"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = "hdnACBCD_F"
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = "hdnACBCD_T"
            ElseIf hdnPopcrtl.Value = "4" Then
                strRec = "hdnGROUPCD"
            ElseIf col >= 101 And col <= 200 Then
                col = col - 100
                strRec = "hdnACBCD_" & Convert.ToString(col)
            ElseIf col >= 201 And col <= 300 Then
                col = col - 200
                strRec = "hdnGROUPCD_" & Convert.ToString(col)
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：名称を返すオブジェクトの名前値を渡すプロパティ
    '*　備　考：データ選択後、名称を返すオブジェクト名を指定する
    '******************************************************************************
    Public ReadOnly Property pBackName() As String
        Get
            Dim strRec As String = ""
            Dim col As Integer = 0
            col = Convert.ToInt32(hdnPopcrtl.Value)

            If hdnPopcrtl.Value = "1" Then
                strRec = "txtKURACD"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = "txtACBCD_F"
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = "txtACBCD_T"
            ElseIf hdnPopcrtl.Value = "4" Then
                strRec = "txtGROUPCD"
            ElseIf col >= 101 And col <= 200 Then
                col = col - 100
                strRec = "txtACBCD_" & Convert.ToString(col)
            ElseIf col >= 201 And col <= 300 Then
                col = col - 200
                strRec = "txtGROUPCD_" & Convert.ToString(col)
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：フォーカスを返すオブジェクトの名前値を渡すプロパティ
    '*　備　考：データ選択後、値を返した後に、カーソルをセットする場所の指定
    '******************************************************************************
    Public ReadOnly Property pBackFocs() As String
        Get
            Dim strRec As String = ""
            Dim col As Integer = 0
            col = Convert.ToInt32(hdnPopcrtl.Value)

            If hdnPopcrtl.Value = "1" Then
                strRec = "btnKURACD"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = "btnACBCD_F"
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = "btnACBCD_T"
            ElseIf hdnPopcrtl.Value = "4" Then
                strRec = "btnGROUPCD"
            ElseIf col >= 101 And col <= 200 Then
                col = col - 100
                strRec = "btnACBCD_" & Convert.ToString(col)
            ElseIf col >= 201 And col <= 300 Then
                col = col - 200
                strRec = "btnGROUPCD_" & Convert.ToString(col)
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*　概　要：表示をクリアするオブジェクトの名前を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pClear1() As String
        Get
            Dim strRec As String = ""
            Dim col As Integer = 0
            col = Convert.ToInt32(hdnPopcrtl.Value)

            If hdnPopcrtl.Value = "1" Then
                strRec = "txtACBCD_F"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "4" Then
                strRec = ""
            ElseIf col >= 101 And col <= 200 Then
                strRec = ""
            ElseIf col >= 201 And col <= 300 Then
                strRec = ""
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：表示をクリアするオブジェクトの名前を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pClear2() As String
        Get
            Dim strRec As String = ""
            Dim col As Integer = 0
            col = Convert.ToInt32(hdnPopcrtl.Value)

            If hdnPopcrtl.Value = "1" Then
                strRec = "hdnACBCD_F"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "4" Then
                strRec = ""
            ElseIf col >= 101 And col <= 200 Then
                strRec = ""
            ElseIf col >= 201 And col <= 300 Then
                strRec = ""
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：表示をクリアするオブジェクトの名前を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pClear3() As String
        Get
            Dim strRec As String = ""
            Dim col As Integer = 0
            col = Convert.ToInt32(hdnPopcrtl.Value)

            If hdnPopcrtl.Value = "1" Then
                strRec = "txtACBCD_T"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "4" Then
                strRec = ""
            ElseIf col >= 101 And col <= 200 Then
                strRec = ""
            ElseIf col >= 201 And col <= 300 Then
                strRec = ""
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：表示をクリアするオブジェクトの名前を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pClear4() As String
        Get
            Dim strRec As String = ""
            Dim col As Integer = 0
            col = Convert.ToInt32(hdnPopcrtl.Value)

            If hdnPopcrtl.Value = "1" Then
                strRec = "hdnACBCD_T"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "4" Then
                strRec = ""
            ElseIf col >= 101 And col <= 200 Then
                strRec = ""
            ElseIf col >= 201 And col <= 300 Then
                strRec = ""
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*　概　要：表示をクリアするオブジェクトの名前を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pClear5() As String
        Get
            Dim strRec As String = ""
            Dim col As Integer = 0
            col = Convert.ToInt32(hdnPopcrtl.Value)

            If hdnPopcrtl.Value = "1" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "4" Then
                strRec = ""
            ElseIf col >= 101 And col <= 200 Then
                strRec = ""
            ElseIf col >= 201 And col <= 300 Then
                strRec = ""
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*　概　要：リターン後に実行されるＪＳ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pBackScript() As String
        Get
            Dim strRec As String = ""
            Dim col As Integer = 0
            col = Convert.ToInt32(hdnPopcrtl.Value)

            If hdnPopcrtl.Value = "1" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "2" Then
                '2019/11/01 T.Ono mod 監視改善2019
                'strRec = ""
                strRec = "fncSetTo"
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "4" Then
                strRec = ""
            ElseIf col >= 101 And col <= 200 Then
                strRec = ""
            ElseIf col >= 201 And col <= 300 Then
                strRec = ""
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '* データの出力処理
    '******************************************************************************
    Private Function fncbtnKensaku_ClickEvent(ByVal pstrKBN As String) As String
        '1:検索ボタン
        '2:実行後出力　(フォーカスのセットが変わります)
        Dim strRec As String

        strRec = "OK"

        fncIni_notkey() 'キー以外の項目初期化

        Try
            '//--------------------------------------
            '登録・削除、一括登録からきた場合
            '出力にチェックが無い場合は、SQLエラーとなるため自動的につける
            If chkSYU_TOUROKU.Checked = False AndAlso chkSYU_MITOUROKU.Checked = False Then
                chkSYU_TOUROKU.Checked = True
                chkSYU_MITOUROKU.Checked = True
            End If

            '//--------------------------------------
            '検索処理を行う
            Dim DateFncC As New CDateFnc
            Dim dbData As DataSet
            Dim UserCheckFLG As Boolean = True

            dbData = fncDataSelect()

            If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
                'データが存在しない為、検索はエラー
                'メッセージを出力後、検索前状態にする。

                strMsg.Append("alert('データが存在しません');")

                Call fncIni_statebf()

                '//------------------------------
                '<TODO>フォーカスをセットする（検索ボタンにセット）
                strMsg.Append("Form1.btnSelect.focus();")

                '//--------------------------------------------------------------------------
            Else
                'データが存在する為、データ出力

                '------------------------------------
                '<TODO>100件以上の場合はメッセージ
                If dbData.Tables(0).Rows.Count > 100 Then
                    strMsg.Append("alert('最大出力件数を超えました。条件を指定して再度検索してください');")
                End If

                '------------------------------------
                '<TODO>データを出力する
                '区分
                If hdnJAGKBN.Value.Length <> 0 Then
                    hdnJAGKBN_MOTO.Value = hdnJAGKBN.Value.Trim
                End If
                'クライアントコード
                If hdnKURACD.Value.Length <> 0 Then
                    hdnKURACD_MOTO.Value = hdnKURACD.Value.Trim
                Else
                    hdnKURACD_MOTO.Value = ""
                End If
                'JA支所コード
                If hdnACBCD_F.Value.Length <> 0 Then
                    hdnACBCD_F_MOTO.Value = hdnACBCD_F.Value.Trim
                Else
                    hdnACBCD_F_MOTO.Value = ""
                End If
                If hdnACBCD_T.Value.Length <> 0 Then
                    hdnACBCD_T_MOTO.Value = hdnACBCD_T.Value.Trim
                Else
                    hdnACBCD_T_MOTO.Value = ""
                End If
                'グループコード
                If hdnGROUPCD.Value.Length <> 0 Then
                    hdnGROUPCD_MOTO.Value = hdnGROUPCD.Value.Trim
                Else
                    hdnGROUPCD_MOTO.Value = ""
                End If


                Dim objKURACD As System.Web.UI.WebControls.TextBox
                Dim objACBCD As System.Web.UI.WebControls.TextBox
                Dim objhdnACBCD As System.Web.UI.HtmlControls.HtmlInputHidden
                Dim objGROUPCD As System.Web.UI.WebControls.TextBox
                Dim objhdnGROUPCD As System.Web.UI.HtmlControls.HtmlInputHidden
                Dim objUSERCD_F As System.Web.UI.WebControls.TextBox
                Dim objUSERCD_T As System.Web.UI.WebControls.TextBox
                Dim objBIKO As System.Web.UI.WebControls.TextBox
                Dim objINS_DATE As System.Web.UI.WebControls.TextBox
                Dim objINS_USER As System.Web.UI.WebControls.TextBox
                Dim objUPD_DATE As System.Web.UI.WebControls.TextBox
                Dim objUPD_USER As System.Web.UI.WebControls.TextBox
                Dim objbtnACBCD As System.Web.UI.HtmlControls.HtmlInputButton

                Dim intRow As Integer

                For intRow = 0 To dbData.Tables(0).Rows.Count - 1

                    If intRow >= 100 Then Exit For '100件以上は処理抜け

                    '----------------------------
                    ' 明細情報を画面項目にセット
                    '----------------------------
                    'コントロール名を探し出し、型変換
                    objKURACD = CType(FindControl("txtKURACD_" & CStr(intRow + 1)), System.Web.UI.WebControls.TextBox)
                    objACBCD = CType(FindControl("txtACBCD_" & CStr(intRow + 1)), System.Web.UI.WebControls.TextBox)
                    objhdnACBCD = CType(FindControl("hdnACBCD_" & CStr(intRow + 1)), System.Web.UI.HtmlControls.HtmlInputHidden)
                    objGROUPCD = CType(FindControl("txtGROUPCD_" & CStr(intRow + 1)), System.Web.UI.WebControls.TextBox)
                    objhdnGROUPCD = CType(FindControl("hdnGROUPCD_" & CStr(intRow + 1)), System.Web.UI.HtmlControls.HtmlInputHidden)
                    objUSERCD_F = CType(FindControl("txtUSERCD_F_" & CStr(intRow + 1)), System.Web.UI.WebControls.TextBox)
                    objUSERCD_T = CType(FindControl("txtUSERCD_T_" & CStr(intRow + 1)), System.Web.UI.WebControls.TextBox)
                    objBIKO = CType(FindControl("txtBIKO_" & CStr(intRow + 1)), System.Web.UI.WebControls.TextBox)
                    objINS_DATE = CType(FindControl("txtINS_DATE_" & CStr(intRow + 1)), System.Web.UI.WebControls.TextBox)
                    objINS_USER = CType(FindControl("txtINS_USER_" & CStr(intRow + 1)), System.Web.UI.WebControls.TextBox)
                    objUPD_DATE = CType(FindControl("txtUPD_DATE_" & CStr(intRow + 1)), System.Web.UI.WebControls.TextBox)
                    objUPD_USER = CType(FindControl("txtUPD_USER_" & CStr(intRow + 1)), System.Web.UI.WebControls.TextBox)
                    objbtnACBCD = CType(FindControl("btnACBCD_" & CStr(intRow + 1)), System.Web.UI.HtmlControls.HtmlInputButton)


                    'キー項目は変更不可にする
                    objKURACD.ReadOnly = True
                    objKURACD.BackColor = Color.Gainsboro
                    objACBCD.ReadOnly = True
                    objACBCD.BackColor = Color.Gainsboro
                    objbtnACBCD.Disabled = True

                    objKURACD.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("KURACD"))
                    objACBCD.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("ACBNM"))
                    objhdnACBCD.Value = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("ACBCD"))
                    objGROUPCD.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("GROUPNM"))
                    objhdnGROUPCD.Value = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("GROUPCD"))
                    objUSERCD_F.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("USERCD_FROM"))
                    objUSERCD_T.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("USERCD_TO"))
                    objBIKO.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("BIKO"))
                    objINS_DATE.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("INS_DATE"))
                    objINS_USER.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("INS_USER"))
                    objUPD_DATE.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("UPD_DATE"))
                    objUPD_USER.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("UPD_USER"))

                Next ' intRow


                If pstrKBN = "1" Then
                    '検索ボタン押下時
                    Call fncIni_stateaf()

                    '//------------------------------
                    '<TODO>フォーカスをセットする（データが存在したのでキー以外にセット）
                    strMsg.Append("Form1.btnSelect.focus();")
                End If


            End If
            dbData.Dispose()

        Catch ex As Exception
            strRec = ex.ToString
            Dim ErrMsgC As New CErrMsg
            strMsg.Append("alert('システムエラー：" & ErrMsgC.mGetArtMsg(ex.ToString) & "');")
        End Try

        Return strRec

    End Function

    '******************************************************************************
    '* 登録・削除が押下されたときの処理
    '******************************************************************************
    Private Function fncbtnJikkou_ClickEvent(ByVal pstrKBN As String) As String

        Dim strRec As String = ""
        Dim DateFncC As New CDateFnc

        Dim MSJAGJAW00C As New MSJAGJAG00MSJAGJAW00.MSJAGJAW00


        '値を配列にセット
        Dim objTARGET As System.Web.UI.WebControls.CheckBox
        Dim objKURACD As System.Web.UI.WebControls.TextBox
        Dim objhdnACBCD As System.Web.UI.HtmlControls.HtmlInputHidden
        Dim objhdnGROUPCD As System.Web.UI.HtmlControls.HtmlInputHidden
        Dim objUSERCD_F As System.Web.UI.WebControls.TextBox
        Dim objUSERCD_T As System.Web.UI.WebControls.TextBox
        Dim objBIKO As System.Web.UI.WebControls.TextBox
        Dim objINS_DATE As System.Web.UI.WebControls.TextBox
        Dim objINS_USER As System.Web.UI.WebControls.TextBox
        Dim objUPD_DATE As System.Web.UI.WebControls.TextBox
        Dim objUPD_USER As System.Web.UI.WebControls.TextBox

        Dim sTARGET(100) As String
        Dim sKURACD(100) As String
        Dim sACBCD(100) As String
        Dim sGROUPCD(100) As String
        Dim sUSERCD_F(100) As String
        Dim sUSERCD_T(100) As String
        Dim sBIKO(100) As String
        Dim sINS_DATE(100) As String
        Dim sINS_USER(100) As String
        Dim sUPD_DATE(100) As String
        Dim sUPD_USER(100) As String

        Dim i As Integer
        For i = 1 To 100
            'コントロール名を探し出し、型変換
            objTARGET = CType(FindControl("chkTARGET_" & CStr(i)), System.Web.UI.WebControls.CheckBox)
            objKURACD = CType(FindControl("txtKURACD_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objhdnACBCD = CType(FindControl("hdnACBCD_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
            objhdnGROUPCD = CType(FindControl("hdnGROUPCD_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
            objUSERCD_F = CType(FindControl("txtUSERCD_F_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objUSERCD_T = CType(FindControl("txtUSERCD_T_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objBIKO = CType(FindControl("txtBIKO_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objINS_DATE = CType(FindControl("txtINS_DATE_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objINS_USER = CType(FindControl("txtINS_USER_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objUPD_DATE = CType(FindControl("txtUPD_DATE_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objUPD_USER = CType(FindControl("txtUPD_USER_" & CStr(i)), System.Web.UI.WebControls.TextBox)

            If (objTARGET.Checked) Then
                sTARGET(i) = "true"
            Else
                sTARGET(i) = "false"
            End If
            sKURACD(i) = objKURACD.Text.Trim
            sACBCD(i) = objhdnACBCD.Value.Trim
            sGROUPCD(i) = objhdnGROUPCD.Value.Trim
            sUSERCD_F(i) = objUSERCD_F.Text.Trim
            sUSERCD_T(i) = objUSERCD_T.Text.Trim
            sBIKO(i) = objBIKO.Text.Trim
            sINS_DATE(i) = objINS_DATE.Text.Trim
            sINS_USER(i) = objINS_USER.Text.Trim
            sUPD_DATE(i) = objUPD_DATE.Text.Trim
            sUPD_USER(i) = objUPD_USER.Text.Trim

        Next

        strRec = MSJAGJAW00C.mSetEx( _
                    CInt(pstrKBN), _
                    hdnJAGKBN.Value, _
                    sTARGET, _
                    sKURACD, _
                    sACBCD, _
                    sGROUPCD, _
                    sUSERCD_F, _
                    sUSERCD_T, _
                    sBIKO, _
                    sINS_DATE, _
                    sINS_USER, _
                    sUPD_DATE, _
                    sUPD_USER, _
                    AuthC.pUSERNAME _
                    )

        '【共通】
        '  OK : 正常に終了しました
        '   0 : 他のユーザーによってデータが更新されています。再度検索してください
        '   1 : 既にデータが存在します
        '   2 : 対象データが存在しません
        '   3 : 排他制御処理でエラーが発生しました。再度実行してください
        Dim strRecTemp As String = strRec
        Dim strRecMsg As String
        Select Case strRec
            Case "OK"
                strMsg.Append("alert('正常に終了しました');")
                '検索
                strRec = fncbtnKensaku_ClickEvent("2")
                '<TODO>フォーカスをセットする（検索ボタンにセット）
                strMsg.Append("Form1.btnSelect.focus();")
                '//------------------------------

            Case "0"
                strRecMsg = "他のユーザーによってデータが更新されています。再度検索してください"
                strMsg.Append("alert('" & strRecMsg & "');")

                '//------------------------------
                '<TODO>フォーカスをセットする（修正時でのエラー。検索ボタンにセット）
                strMsg.Append("Form1.btnSelect.focus();")
                strRec = strRecMsg
            Case "1"
                strRecMsg = "既にデータが存在します"
                strMsg.Append("alert('" & strRecMsg & "');")

                '//------------------------------
                strRec = strRecMsg
            Case "2"
                strRecMsg = "対象データが存在しません"
                strMsg.Append("alert('" & strRecMsg & "');")

                '//------------------------------
                '<TODO>フォーカスをセットする（修正時でのエラー。検索ボタンにセット）
                strMsg.Append("Form1.btnSelect.focus();")
                strRec = strRecMsg
            Case "3"
                strRecMsg = "排他制御処理でエラーが発生しました。再度実行してください"
                strMsg.Append("alert('" & strRecMsg & "');")

                '<TODO>フォーカスをセットする（登録・修正・削除時でのエラー。終了ボタンにセット）
                strMsg.Append("Form1.btnExit.focus();")
                strRec = strRecMsg
            Case "4"
                strRecMsg = "クライアントコードが存在しません"
                strMsg.Append("alert('" & strRecMsg & "');")

                '<TODO>フォーカスをセットする（登録・修正時でのエラー。検索ボタンにセット）
                strMsg.Append("Form1.btnSelect.focus();")

                strRec = strRecMsg
            Case "5"
                strRecMsg = "JA支所コードが存在しません"
                strMsg.Append("alert('" & strRecMsg & "');")

                '<TODO>フォーカスをセットする（登録・修正時でのエラー。検索ボタンにセット）
                strMsg.Append("Form1.btnSelect.focus();")

                strRec = strRecMsg
            Case "6"
                strRecMsg = "１つのJA支所に100件以上登録することはできません"
                strMsg.Append("alert('" & strRecMsg & "');")

                '<TODO>フォーカスをセットする（登録・修正時でのエラー。検索ボタンにセット）
                strMsg.Append("Form1.btnSelect.focus();")

                strRec = strRecMsg

            Case "7"
                '2016/03/09 T.Ono add 2015改善開発
                strRecMsg = "グループコードが存在しません"
                strMsg.Append("alert('" & strRecMsg & "');")

                '<TODO>フォーカスをセットする（登録・修正時でのエラー。検索ボタンにセット）
                strMsg.Append("Form1.btnSelect.focus();")

                strRec = strRecMsg

            Case Else
                Dim ErrMsgC As New CErrMsg

                strMsg.Append("alert('システムエラー：" & ErrMsgC.mGetArtMsg(strRec) & "');")

                If pstrKBN = "1" Then
                    '//----------------------------------
                    '<TODO>フォーカスをセットする（登録処理：ログ出力のエラーの為キーにセット）
                ElseIf pstrKBN = "2" Then
                    '//----------------------------------
                    '<TODO>フォーカスをセットする（修正処理：ログ出力のエラーの為キー以降にセット）
                    strMsg.Append("Form1.txtKURACD_1.focus();")
                Else
                    '//----------------------------------
                    '<TODO>フォーカスをセットする（その他　：ログ出力のエラーの為キー以降にセット）
                    strMsg.Append("Form1.txtKURACD_1.focus();")
                End If
        End Select

        For i = 1 To 100
            Dim objACBCD As System.Web.UI.WebControls.TextBox
            Dim objbtnACBCD As System.Web.UI.HtmlControls.HtmlInputButton
            objKURACD = CType(FindControl("txtKURACD_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objACBCD = CType(FindControl("txtACBCD_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objbtnACBCD = CType(FindControl("btnACBCD_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputButton)
            If objKURACD.Text <> "" Then
                objKURACD.ReadOnly = True
                objKURACD.BackColor = Color.Gainsboro
                objACBCD.ReadOnly = True
                objACBCD.BackColor = Color.Gainsboro
                objbtnACBCD.Disabled = True
            End If
        Next

        '-------------------------------------------------
        '//ＡＰログ書き込み
        Dim LogC As New CLog
        Dim strRecLog As String
        strRecLog = LogC.mAPLog(Me.Session.SessionID, AuthC.pUSERNAME, AuthC.pIPADDRESS, hdnMyAspx.Value, pstrKBN, strRec, Request.Form)

        If strRecLog <> "OK" Then
            Dim errmsgc As New CErrMsg
            strMsg.Append("alert('システムエラー：" & errmsgc.mGetArtMsg(strRecLog) & "');")
        End If

        Return strRec
    End Function

    '******************************************************************************
    '* 一括登録が押下されたときの処理
    '******************************************************************************
    Private Function fncbtnIKKATU_ClickEvent(ByVal pstrKBN As String) As String

        Dim strRec As String = ""
        Dim DateFncC As New CDateFnc

        Dim MSJAGJAW00C As New MSJAGJAG00MSJAGJAW00.MSJAGJAW00


        '配列用意
        Dim sTARGET() As String = {""}
        Dim sKURACD() As String = {""}
        Dim sACBCD() As String = {""}
        Dim sGROUPCD() As String = {""}
        Dim sUSERCD_F() As String = {""}
        Dim sUSERCD_T() As String = {""}
        Dim sBIKO() As String = {""}
        Dim sINS_DATE() As String = {""}
        Dim sINS_USER() As String = {""}
        Dim sUPD_DATE() As String = {""}
        Dim sUPD_USER() As String = {""}

        '重複確認
        Dim bolchkCHOUFUKU As Boolean = False 'True：重複なし　False：重複ありNG
        '検索
        Dim dbData As DataSet
        Dim bolDataSelect As Boolean = False 'True：対象データあり　False：対象データなしNG


        Try

            '重複確認
            bolchkCHOUFUKU = fncchkCHOUFUKU()
            If bolchkCHOUFUKU = False Then
                strMsg.Append("alert('登録済みデータが存在します。検索してデータを確認してください');")

                Call fncIni_statebf()

                '//------------------------------
                '<TODO>フォーカスをセットする（検索ボタンにセット）
                strMsg.Append("Form1.btnSelect.focus();")
                strRec = "重複チェック"
                Return strRec
            End If

            '検索
            dbData = fncDataSelect_Ikkatu()

            If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
                'データが存在しない為、検索はエラー
                'メッセージを出力後、検索前状態にする。
                strMsg.Append("alert('データが存在しません');")

                Call fncIni_statebf()

                '//------------------------------
                '<TODO>フォーカスをセットする（検索ボタンにセット）
                strMsg.Append("Form1.btnSelect.focus();")
                dbData.Dispose()
                strRec = "対象データなし"
                Return strRec
            Else

                '変数に登録値を格納
                Dim intRow As Integer

                For intRow = 0 To dbData.Tables(0).Rows.Count - 1

                    ReDim Preserve sTARGET(intRow + 1)
                    ReDim Preserve sKURACD(intRow + 1)
                    ReDim Preserve sACBCD(intRow + 1)
                    ReDim Preserve sGROUPCD(intRow + 1)
                    ReDim Preserve sUSERCD_F(intRow + 1)
                    ReDim Preserve sUSERCD_T(intRow + 1)
                    ReDim Preserve sBIKO(intRow + 1)
                    ReDim Preserve sINS_DATE(intRow + 1)
                    ReDim Preserve sINS_USER(intRow + 1)
                    ReDim Preserve sUPD_DATE(intRow + 1)
                    ReDim Preserve sUPD_USER(intRow + 1)

                    sTARGET(intRow + 1) = "true"
                    sKURACD(intRow + 1) = hdnKURACD.Value.Trim
                    sACBCD(intRow + 1) = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("HAN_CD"))
                    sGROUPCD(intRow + 1) = hdnGROUPCD.Value.Trim
                    sUSERCD_F(intRow + 1) = ""
                    sUSERCD_T(intRow + 1) = ""
                    sBIKO(intRow + 1) = ""
                    sINS_DATE(intRow + 1) = ""
                    sINS_USER(intRow + 1) = ""
                    sUPD_DATE(intRow + 1) = ""
                    sUPD_USER(intRow + 1) = ""

                Next

                strRec = MSJAGJAW00C.mSetEx( _
                                    CInt(pstrKBN), _
                                    hdnJAGKBN.Value, _
                                    sTARGET, _
                                    sKURACD, _
                                    sACBCD, _
                                    sGROUPCD, _
                                    sUSERCD_F, _
                                    sUSERCD_T, _
                                    sBIKO, _
                                    sINS_DATE, _
                                    sINS_USER, _
                                    sUPD_DATE, _
                                    sUPD_USER, _
                                    AuthC.pUSERNAME _
                                    )


                '【共通】
                '  OK : 正常に終了しました
                '   0 : 他のユーザーによってデータが更新されています。再度検索してください
                '   1 : 既にデータが存在します
                '   2 : 対象データが存在しません
                '   3 : 排他制御処理でエラーが発生しました。再度実行してください
                Dim strRecTemp As String = strRec
                Dim strRecMsg As String
                Select Case strRec
                    Case "OK"
                        strMsg.Append("alert('正常に終了しました');")
                        '検索
                        strRec = fncbtnKensaku_ClickEvent("2")
                        '<TODO>フォーカスをセットする（検索ボタンにセット）
                        strMsg.Append("Form1.btnSelect.focus();")
                        '//------------------------------

                    Case "0"
                        strRecMsg = "他のユーザーによってデータが更新されています。再度検索してください"
                        strMsg.Append("alert('" & strRecMsg & "');")

                        '//------------------------------
                        '<TODO>フォーカスをセットする（修正時でのエラー。検索ボタンにセット）
                        strMsg.Append("Form1.btnSelect.focus();")
                        strRec = strRecMsg
                    Case "1"
                        strRecMsg = "既にデータが存在します"
                        strMsg.Append("alert('" & strRecMsg & "');")

                        '//------------------------------
                        strRec = strRecMsg
                    Case "2"
                        strRecMsg = "対象データが存在しません"
                        strMsg.Append("alert('" & strRecMsg & "');")

                        '//------------------------------
                        '<TODO>フォーカスをセットする（修正時でのエラー。検索ボタンにセット）
                        strMsg.Append("Form1.btnSelect.focus();")
                        strRec = strRecMsg
                    Case "3"
                        strRecMsg = "排他制御処理でエラーが発生しました。再度実行してください"
                        strMsg.Append("alert('" & strRecMsg & "');")

                        '<TODO>フォーカスをセットする（登録・修正・削除時でのエラー。終了ボタンにセット）
                        strMsg.Append("Form1.btnExit.focus();")
                        strRec = strRecMsg
                    Case "4"
                        strRecMsg = "クライアントコードが存在しません"
                        strMsg.Append("alert('" & strRecMsg & "');")

                        '<TODO>フォーカスをセットする（登録・修正時でのエラー。検索ボタンにセット）
                        strMsg.Append("Form1.btnSelect.focus();")

                        strRec = strRecMsg
                    Case "5"
                        strRecMsg = "JA支所コードが存在しません"
                        strMsg.Append("alert('" & strRecMsg & "');")

                        '<TODO>フォーカスをセットする（登録・修正時でのエラー。検索ボタンにセット）
                        strMsg.Append("Form1.btnSelect.focus();")

                        strRec = strRecMsg
                    Case "6"
                        strRecMsg = "１つのJA支所に100件以上登録することはできません"
                        strMsg.Append("alert('" & strRecMsg & "');")

                        '<TODO>フォーカスをセットする（登録・修正時でのエラー。検索ボタンにセット）
                        strMsg.Append("Form1.btnSelect.focus();")

                        strRec = strRecMsg
                    Case "7"
                        '2016/03/09 T.Ono add 2015改善開発
                        strRecMsg = "グループコードが存在しません"
                        strMsg.Append("alert('" & strRecMsg & "');")

                        '<TODO>フォーカスをセットする（登録・修正時でのエラー。検索ボタンにセット）
                        strMsg.Append("Form1.btnSelect.focus();")

                        strRec = strRecMsg
                    Case Else
                        Dim ErrMsgC As New CErrMsg

                        strMsg.Append("alert('システムエラー：" & ErrMsgC.mGetArtMsg(strRec) & "');")

                        If pstrKBN = "1" Then
                            '//----------------------------------
                            '<TODO>フォーカスをセットする（登録処理：ログ出力のエラーの為キーにセット）
                        ElseIf pstrKBN = "2" Then
                            '//----------------------------------
                            '<TODO>フォーカスをセットする（修正処理：ログ出力のエラーの為キー以降にセット）
                            strMsg.Append("Form1.txtKURACD_1.focus();")
                        Else
                            '//----------------------------------
                            '<TODO>フォーカスをセットする（その他　：ログ出力のエラーの為キー以降にセット）
                            strMsg.Append("Form1.txtKURACD_1.focus();")
                        End If
                End Select
                dbData.Dispose()
            End If

        Catch ex As Exception
            strRec = ex.ToString
            Dim ErrMsgC As New CErrMsg
            strMsg.Append("alert('システムエラー：" & ErrMsgC.mGetArtMsg(ex.ToString) & "');")

        Finally
            '-------------------------------------------------
            '//ＡＰログ書き込み
            Dim LogC As New CLog
            Dim strRecLog As String
            strRecLog = LogC.mAPLog(Me.Session.SessionID, AuthC.pUSERNAME, AuthC.pIPADDRESS, hdnMyAspx.Value, pstrKBN, strRec, Request.Form)

            If strRecLog <> "OK" Then
                Dim errmsgc As New CErrMsg
                strMsg.Append("alert('システムエラー：" & errmsgc.mGetArtMsg(strRecLog) & "');")
            End If

        End Try


        Return strRec
    End Function

    '******************************************************************************
    '* 入力キーによるデータの検索を行います。
    '******************************************************************************
    Private Function fncDataSelect() As DataSet

        '//------------------------------------------
        '//<TODO>Select文の作成
        Dim SQLC As New MSJAGJAG00CCSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet
        Dim strSELECT As New StringBuilder("") 'グループ名取得SELECT句
        Dim strFROM As New StringBuilder("") 'グループ名取得先マスタFROM句
        Dim strWHERE As New StringBuilder("") 'グループ名取得WHERE句

        '区分により、グループコード名の取得先が変わる
        If hdnJAGKBN.Value.Trim = "001" Then
            'SELECT句
            strSELECT.Append("	,A.GROUPCD || ' : ' || B.GROUPNM AS GROUPNM ")
            'FROM句
            strFROM.Append("	,M10_HANJIGYOSYA B ")
            'WHERE句
            strWHERE.Append("AND A.GROUPCD = B.GROUPCD(+) ")
        ElseIf hdnJAGKBN.Value.Trim = "002" Then
            'JA担当者・報告先・注意事項マスタ　2015/12/10 T.Ono add 2015改善開発 №7
            'SELECT句
            strSELECT.Append("	,A.GROUPCD || ' : ' || B.GROUPNM AS GROUPNM ")
            'FROM句
            strFROM.Append("	,M11_JAHOKOKU B ")
            'WHERE句
            strWHERE.Append("AND A.GROUPCD = B.GROUPCD(+) ")
            strWHERE.Append("AND LPAD(B.TANCD(+), 2, '0') = '01' ")
        ElseIf hdnJAGKBN.Value.Trim = "003" Then
            '自動対応マスタ　2017/02/09 W.GANEKO add 2016改善開発 №10
            'SELECT句
            strSELECT.Append("	,A.GROUPCD || ' : ' || B.GROUPNM AS GROUPNM ")
            'FROM句
            strFROM.Append("	,(SELECT GROUPCD,GROUPNM FROM M08_AUTOTAIOU GROUP BY GROUPCD,GROUPNM) B ")
            'WHERE句
            strWHERE.Append("AND A.GROUPCD = B.GROUPCD(+) ")
        ElseIf hdnJAGKBN.Value.Trim = "004" Then
            'SELECT句
            strSELECT.Append("	,A.GROUPCD || ' : ' || B.GROUPNM AS GROUPNM ")
            'FROM句
            strFROM.Append("	,M12_HANBAITEN B ")
            'WHERE句
            strWHERE.Append("AND A.GROUPCD = B.GROUPCD(+) ")
        Else
            strSELECT.Append("	,A.GROUPCD AS GROUPNM ")
            strFROM.Append("")
            strWHERE.Append("")
        End If

        strSQL.Append("WITH Z AS( ")

        If chkSYU_TOUROKU.Checked = True Then
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
            strSQL.Append(strSELECT.ToString)
            strSQL.Append("	,A.USERCD_FROM ")
            strSQL.Append("	,A.USERCD_TO ")
            strSQL.Append("	,A.BIKO ")
            strSQL.Append("	,TO_CHAR(A.INS_DATE, 'YYYY/MM/DD HH24:MI:SS') AS INS_DATE ")
            strSQL.Append("	,A.INS_USER ")
            strSQL.Append("	,TO_CHAR(A.UPD_DATE, 'YYYY/MM/DD HH24:MI:SS') AS UPD_DATE ")
            strSQL.Append("	,A.UPD_USER ")
            strSQL.Append("FROM M09_JAGROUP A ")
            strSQL.Append(strFROM.ToString)
            strSQL.Append("WHERE 1=1 ")
            strSQL.Append("AND A.KBN = :KBN ")
            strSQL.Append(strWHERE.ToString)
            'クライアントコード
            If hdnKURACD.Value.Trim.Length > 0 Then
                strSQL.Append("AND A.KURACD = :KURACD ")
            End If
            'JA支所コード
            If hdnACBCD_F.Value.Trim.Length > 0 Then
                strSQL.Append("AND A.ACBCD >= :ACBCD_F ")
            End If
            If hdnACBCD_T.Value.Trim.Length > 0 Then
                strSQL.Append("AND A.ACBCD <= :ACBCD_T ")
            End If
            'グループコード
            If hdnGROUPCD.Value.Trim.Length > 0 Then
                strSQL.Append("AND A.GROUPCD = :GROUPCD ")
            End If
        End If

        If chkSYU_TOUROKU.Checked = True AndAlso chkSYU_MITOUROKU.Checked = True Then
            '両方のときはつなぐ
            strSQL.Append("UNION ALL ")
        End If

        If chkSYU_MITOUROKU.Checked = True Then
            '未登録分
            strSQL.Append("SELECT '1' AS NO ")
            strSQL.Append("	,:KBN AS KBN ")
            strSQL.Append("	,A.CLI_CD AS KURACD ")
            strSQL.Append("	,A.HAN_CD AS ACBCD ")
            strSQL.Append("	,'' AS GROUPCD ")
            strSQL.Append("	,'' AS GROUPNM ")
            strSQL.Append("	,'' AS USERCD_FROM ")
            strSQL.Append("	,'' AS USERCD_TO ")
            strSQL.Append("	,'' AS BIKO ")
            strSQL.Append("	,'' AS INS_DATE ")
            strSQL.Append("	,'' AS INS_USER ")
            strSQL.Append("	,'' AS UPD_DATE ")
            strSQL.Append("	,'' AS UPD_USER ")
            strSQL.Append("FROM HN2MAS A ")
            strSQL.Append("	,HN2MAS B ")
            strSQL.Append("WHERE NOT EXISTS (SELECT 'X' ")
            strSQL.Append("	FROM M09_JAGROUP C ")
            strSQL.Append("	WHERE 1=1 ")
            strSQL.Append("	AND C.KBN = :KBN ")
            strSQL.Append("	AND C.KURACD = A.CLI_CD ")
            strSQL.Append("	AND C.ACBCD = A.HAN_CD ")
            strSQL.Append("	AND C.USERCD_FROM IS NULL")
            strSQL.Append("	) ")
            strSQL.Append("AND A.CLI_CD = B.CLI_CD ")
            strSQL.Append("AND A.HAN_CD = B.HAN_CD ")
            strSQL.Append("AND A.HAN_CD <> B.JA_CD ")
            strSQL.Append("AND NVL(A.DEL_FLG,'0') <> '1' ")
            strSQL.Append("AND NVL(B.DEL_FLG,'0') <> '1' ")
            'クライアントコード
            If hdnKURACD.Value.Trim.Length > 0 Then
                strSQL.Append("AND A.CLI_CD = :KURACD ")
            End If
            'JA支所コード
            If hdnACBCD_F.Value.Trim.Length > 0 Then
                strSQL.Append("AND A.HAN_CD >= :ACBCD_F ")
            End If
            If hdnACBCD_T.Value.Trim.Length > 0 Then
                strSQL.Append("AND A.HAN_CD <= :ACBCD_T ")
            End If
        End If

        strSQL.Append(") ")
        strSQL.Append("SELECT Z.NO AS NO ")
        strSQL.Append("	,Z.KBN AS KBN ")
        strSQL.Append("	,Z.KURACD AS KURACD ")
        strSQL.Append("	,Z.ACBCD AS ACBCD ")
        strSQL.Append("	,Z.ACBCD || ' : ' || A.JAS_NAME AS ACBNM ")
        strSQL.Append("	,Z.GROUPCD AS GROUPCD ")
        strSQL.Append("	,Z.GROUPNM AS GROUPNM ")
        strSQL.Append("	,Z.USERCD_FROM AS USERCD_FROM ")
        strSQL.Append("	,Z.USERCD_TO AS USERCD_TO ")
        strSQL.Append("	,Z.BIKO AS BIKO ")
        strSQL.Append("	,Z.INS_DATE AS INS_DATE ")
        strSQL.Append("	,Z.INS_USER AS INS_USER ")
        strSQL.Append("	,Z.UPD_DATE AS UPD_DATE ")
        strSQL.Append("	,Z.UPD_USER AS UPD_USER ")
        strSQL.Append("FROM Z, HN2MAS A ")
        strSQL.Append("WHERE Z.KURACD = A.CLI_CD ")
        strSQL.Append("AND Z.ACBCD = A.HAN_CD ")
        strSQL.Append("ORDER BY KBN, KURACD, ACBCD, NO, USERCD_FROM ")


        '区分
        If hdnJAGKBN.Value.Trim.Length > 0 Then
            SqlParamC.fncSetParam("KBN", True, hdnJAGKBN.Value.Trim)
        End If
        'クライアントコード
        If hdnKURACD.Value.Trim.Length > 0 Then
            SqlParamC.fncSetParam("KURACD", True, hdnKURACD.Value.Trim)
        End If
        'JA支所コード（From）
        If hdnACBCD_F.Value.Trim.Length > 0 Then
            SqlParamC.fncSetParam("ACBCD_F", True, hdnACBCD_F.Value.Trim)
        End If
        'JA支所コード（To）
        If hdnACBCD_T.Value.Trim.Length > 0 Then
            SqlParamC.fncSetParam("ACBCD_T", True, hdnACBCD_T.Value.Trim)
        End If
        'グループコード
        If hdnGROUPCD.Value.Trim.Length > 0 AndAlso chkSYU_TOUROKU.Checked = True Then
            SqlParamC.fncSetParam("GROUPCD", True, hdnGROUPCD.Value.Trim)
        End If

        dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

        Return dbData
    End Function
    '******************************************************************************
    '*指定範囲の重複チェック　True：重複なし　False：重複ありNG
    '******************************************************************************
    Private Function fncchkCHOUFUKU() As Boolean

        Dim res As Boolean = False

        '//------------------------------------------
        '//<TODO>Select文の作成
        Dim SQLC As New MSJAGJAG00CCSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet

        strSQL.Append("SELECT ")
        strSQL.Append("		'X' ")
        strSQL.Append("FROM ")
        strSQL.Append("		M09_JAGROUP A ")
        strSQL.Append("WHERE ")
        strSQL.Append("		A.KBN = :JAGKBN ")
        strSQL.Append("AND	A.KURACD = :KURACD ")
        If hdnACBCD_F.Value.Trim.Length > 0 Then
            strSQL.Append("AND	A.ACBCD >= :ACBCD_F ")
        End If
        If hdnACBCD_T.Value.Trim.Length > 0 Then
            strSQL.Append("AND	A.ACBCD <= :ACBCD_T ")
        End If
        strSQL.Append("ORDER BY A.KURACD, A.ACBCD ")

        '//------------------------------------------
        '//<TODO>パラメータの設定
        SqlParamC.fncSetParam("JAGKBN", True, hdnJAGKBN.Value.Trim)
        SqlParamC.fncSetParam("KURACD", True, hdnKURACD.Value.Trim)

        If hdnACBCD_F.Value.Trim.Length > 0 Then
            SqlParamC.fncSetParam("ACBCD_F", True, hdnACBCD_F.Value.Trim)
        End If
        If hdnACBCD_T.Value.Trim.Length > 0 Then
            SqlParamC.fncSetParam("ACBCD_T", True, hdnACBCD_T.Value.Trim)
        End If

        dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

        If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
            res = True
        Else
            res = False
        End If

        Return res
    End Function

    '******************************************************************************
    '*一括登録用検索
    '******************************************************************************
    Private Function fncDataSelect_Ikkatu() As DataSet

        '//------------------------------------------
        '//<TODO>Select文の作成
        Dim SQLC As New MSJAGJAG00CCSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet

        strSQL.Append("SELECT ")
        strSQL.Append("		A.CLI_CD ")
        strSQL.Append("		,A.HAN_CD ")
        strSQL.Append("FROM ")
        strSQL.Append("		HN2MAS A ")
        strSQL.Append("WHERE ")
        strSQL.Append("		A.CLI_CD = :KURACD ")
        strSQL.Append("AND	NVL(A.DEL_FLG,'0') <> '1' ")
        If hdnACBCD_F.Value.Trim.Length > 0 Then
            strSQL.Append("AND	A.HAN_CD >= :ACBCD_F ")
        End If
        If hdnACBCD_T.Value.Trim.Length > 0 Then
            strSQL.Append("AND	A.HAN_CD <= :ACBCD_T ")
        End If
        strSQL.Append("AND	NOT EXISTS( ")
        strSQL.Append("			SELECT	'X' ")
        strSQL.Append("			FROM	HN2MAS B ")
        strSQL.Append("			WHERE	A.CLI_CD = B.CLI_CD ")
        strSQL.Append("			AND		A.HAN_CD = B.JA_CD ")
        strSQL.Append("			) ")
        strSQL.Append("ORDER BY A.CLI_CD, A.HAN_CD ")

        '//------------------------------------------
        '//<TODO>パラメータの設定
        SqlParamC.fncSetParam("KURACD", True, hdnKURACD.Value.Trim)

        If hdnACBCD_F.Value.Trim.Length > 0 Then
            SqlParamC.fncSetParam("ACBCD_F", True, hdnACBCD_F.Value.Trim)
        End If

        If hdnACBCD_T.Value.Trim.Length > 0 Then
            SqlParamC.fncSetParam("ACBCD_T", True, hdnACBCD_T.Value.Trim)
        End If


        dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

        Return dbData
    End Function

    '******************************************************************************
    '* グループ追加ボタン押下時の処理
    '******************************************************************************
    Private Function fncbtnGROUP_ADD_ClickEvent(ByVal pstrKBN As String) As String

        Dim strRec As String = ""
        Dim DateFncC As New CDateFnc

        Dim MSJAGJAW00C As New MSJAGJAG00MSJAGJAW00.MSJAGJAW00

        Dim bolGroupNMchk As Boolean = False 'True:OK　False:NG　命名即、M06.PULLDOWN:KBN=78 NAIYO1と先頭文字を比較
        Dim bolChoufukuGroup As Boolean = False 'True:登録なし　False:登録ありNG


        Try
            '-------------------------------------------------
            'グループ名確認
            bolGroupNMchk = fncGroupNMchk()
            If bolGroupNMchk = False Then
                strMsg.Append("alert('グループコードが不正です\n先頭に区分と同じアルファベット2文字を入力してください');")

                Call fncIni_statebf()

                '//------------------------------
                '<TODO>フォーカスをセットする（グループコード(新規登録用)にセット）
                strMsg.Append("Form1.txtGROUPCD_NEW.focus();")
                strRec = "グループ名先頭文字チェック"
                Return strRec

            End If


            '-------------------------------------------------
            '登録　区分により、登録先変更
            Select Case hdnJAGKBN.Value.Trim
                Case "001" '販売事業者グループマスタ
                    strRec = MSJAGJAW00C.mSetHANJIGYOSYA(
                                            CInt(hdnKBN.Value.Trim), _
                                            txtGROUPCD_NEW.Text.Trim, _
                                            txtGROUPNM_NEW.Text.Trim, _
                                            hdnINS_DATE_NEW.Value.Trim, _
                                            hdnINS_USER_NEW.Value.Trim, _
                                            hdnUPD_DATE_NEW.Value.Trim, _
                                            hdnUPD_USER_NEW.Value.Trim, _
                                            AuthC.pUSERNAME.Trim _
                                            )

                Case "002" 'JA担当者・報告先・注意事項マスタ 2015/12/10 T.Ono add 2015改善開発 №7
                    strRec = MSJAGJAW00C.mSetJAHOKOKU(
                                            CInt(hdnKBN.Value.Trim), _
                                            txtGROUPCD_NEW.Text.Trim, _
                                            txtGROUPNM_NEW.Text.Trim, _
                                            hdnINS_DATE_NEW.Value.Trim, _
                                            hdnINS_USER_NEW.Value.Trim, _
                                            hdnUPD_DATE_NEW.Value.Trim, _
                                            hdnUPD_USER_NEW.Value.Trim, _
                                            AuthC.pUSERNAME.Trim _
                                            )
                Case "003" '自動対応グループマスタ 2017/02/09 W.GANEKO add 2016改善開発 №10
                    strRec = MSJAGJAW00C.mSetAUTOTAIOU(
                                            CInt(hdnKBN.Value.Trim),
                                            txtGROUPCD_NEW.Text.Trim,
                                            txtGROUPNM_NEW.Text.Trim,
                                            hdnINS_DATE_NEW.Value.Trim,
                                            hdnINS_USER_NEW.Value.Trim,
                                            hdnUPD_DATE_NEW.Value.Trim,
                                            hdnUPD_USER_NEW.Value.Trim,
                                            AuthC.pUSERNAME.Trim
                                            )
                Case "004" '販売店グループマスタ 2019/01/24 T.Ono add 2018改善開発
                    strRec = MSJAGJAW00C.mSetHANBAITEN(
                                            CInt(hdnKBN.Value.Trim),
                                            txtGROUPCD_NEW.Text.Trim,
                                            txtGROUPNM_NEW.Text.Trim,
                                            hdnINS_DATE_NEW.Value.Trim,
                                            hdnINS_USER_NEW.Value.Trim,
                                            hdnUPD_DATE_NEW.Value.Trim,
                                            hdnUPD_USER_NEW.Value.Trim,
                                            AuthC.pUSERNAME.Trim
                                            )
                Case Else
                    strRec = "NG"
            End Select

            '【共通】
            '  OK : 正常に終了しました
            '   0 : 他のユーザーによってデータが更新されています。再度検索してください
            '   1 : 既にデータが存在します
            '   2 : 対象データが存在しません
            '   3 : 排他制御処理でエラーが発生しました。再度実行してください
            Dim strRecTemp As String = strRec
            Dim strRecMsg As String
            Select Case strRec
                Case "OK"
                    strMsg.Append("alert('正常に終了しました');")

                    '<TODO>フォーカスをセットする（検索ボタンにセット）
                    strMsg.Append("Form1.btnSelect.focus();")
                    '//------------------------------

                Case "0"
                    strRecMsg = "他のユーザーによってデータが更新されています。再度検索してください"
                    strMsg.Append("alert('" & strRecMsg & "');")

                    '//------------------------------
                    '<TODO>フォーカスをセットする（グループコード名変更確定ボタンにセット）
                    strMsg.Append("Form1.btnGROUP_SEARCH.focus();")
                    strRec = strRecMsg

                Case "1"
                    strRecMsg = "登録済みデータが存在します。確認してください"
                    strMsg.Append("alert('" & strRecMsg & "');")

                    '//------------------------------
                    '<TODO>フォーカスをセットする（修正時でのエラー。グループコード(新規登録用)にセット）
                    strMsg.Append("Form1.txtGROUPCD_NEW.focus();")
                    strRec = strRecMsg

                Case "2"
                    strRecMsg = "データが存在しません。確認してください"
                    strMsg.Append("alert('" & strRecMsg & "');")

                    '//------------------------------
                    '<TODO>フォーカスをセットする（グループコード名変更確定ボタンにセット）
                    strMsg.Append("Form1.btnGROUP_MOD.focus();")
                    strRec = strRecMsg

                Case "3" '2016/01/12 T.Ono add 2015改善開発
                    strRecMsg = "グループコード名が重複しています"
                    strMsg.Append("alert('" & strRecMsg & "');")

                    '//------------------------------
                    '<TODO>フォーカスをセットする（グループコード名変更確定ボタンにセット）
                    strMsg.Append("Form1.txtGROUPNM_NEW.focus();")
                    strRec = strRecMsg
                Case Else
                    Dim ErrMsgC As New CErrMsg

                    strMsg.Append("alert('システムエラー：" & ErrMsgC.mGetArtMsg(strRec) & "');")

                    If pstrKBN = "7" Then
                        '//------------------------------
                        '<TODO>フォーカスをセットする（修正時でのエラー。グループコード(新規登録用)にセット）
                        strMsg.Append("Form1.txtGROUPCD_NEW.focus();")
                    ElseIf pstrKBN = "9" Then
                        '//------------------------------
                        '<TODO>フォーカスをセットする（グループコード名変更確定ボタンにセット）
                        strMsg.Append("Form1.btnGROUP_MOD.focus();")
                    Else
                        '//------------------------------
                        '<TODO>フォーカスをセットする（修正時でのエラー。グループコード(新規登録用)にセット）
                        strMsg.Append("Form1.txtGROUPCD_NEW.focus();")
                    End If
            End Select


        Catch ex As Exception
            strRec = ex.ToString
            Dim ErrMsgC As New CErrMsg
            strMsg.Append("alert('システムエラー：" & ErrMsgC.mGetArtMsg(ex.ToString) & "');")

        Finally
            '-------------------------------------------------
            '//ＡＰログ書き込み
            Dim LogC As New CLog
            Dim strRecLog As String
            strRecLog = LogC.mAPLog(Me.Session.SessionID, AuthC.pUSERNAME, AuthC.pIPADDRESS, hdnMyAspx.Value, pstrKBN, strRec, Request.Form)

            If strRecLog <> "OK" Then
                Dim errmsgc As New CErrMsg
                strMsg.Append("alert('システムエラー：" & errmsgc.mGetArtMsg(strRecLog) & "');")
            End If
        End Try

        Return strRec
    End Function

    '******************************************************************************
    '*グループ追加　命名規則を満たしているか　True：(OK)　False：(NG)
    '******************************************************************************
    Private Function fncGroupNMchk() As Boolean
        'プルダウンマスタKBN=78 NAIYO1と先頭文字を比較

        Dim res As Boolean = False

        '//------------------------------------------
        '//<TODO>Select文の作成
        Dim SQLC As New MSJAGJAG00CCSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet

        strSQL.Append("SELECT ")
        strSQL.Append("		NAIYO1 ")
        strSQL.Append("FROM ")
        strSQL.Append("		M06_PULLDOWN A ")
        strSQL.Append("WHERE ")
        strSQL.Append("		A.KBN = '78' ")
        strSQL.Append("AND  A.CD = :JAGKBN ")


        '//------------------------------------------
        '//<TODO>パラメータの設定
        SqlParamC.fncSetParam("JAGKBN", True, hdnJAGKBN.Value.Trim)

        dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)



        '//------------------------------------------
        '//<TODO>入力値とDBの値を比較
        Dim GroupNM_header As String
        '2015/03/19 T.Ono mod START
        '1文字だとエラーになってしまうため修正
        'GroupNM_header = txtGROUPCD_NEW.Text.Trim.Substring(0, 2)
        If txtGROUPCD_NEW.Text.Trim.Length < 2 Then
            Return False '1文字ならfalseを返す
        Else
            GroupNM_header = txtGROUPCD_NEW.Text.Trim.Substring(0, 2)
        End If
        '2015/03/19 T.Ono mod END

        If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
            res = False
        Else
            If Convert.ToString(dbData.Tables(0).Rows(0).Item("NAIYO1")) = GroupNM_header Then
                res = True
            Else
                res = False
            End If
        End If

        Return res
    End Function
    '******************************************************************************
    '*グループ追加　DBにグループコードが登録されているかチェック　True：登録なし(OK)　False：登録あり(NG)
    '******************************************************************************
    Private Function fncChoufukuGroup() As Boolean

        Dim res As Boolean = False

        '//------------------------------------------
        '//<TODO>Select文の作成
        Dim SQLC As New MSJAGJAG00CCSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet

        If hdnJAGKBN.Value = "001" Then
            '販売事業者グループマスタ
            strSQL.Append("SELECT ")
            strSQL.Append("		'X' ")
            strSQL.Append("FROM ")
            strSQL.Append("		M10_HANJIGYOSYA A ")
            strSQL.Append("WHERE ")
            strSQL.Append("		A.GROUPCD = :GROUPCD ")
        Else
            strSQL.Append("SELECT ")
            strSQL.Append("		'X' ")
            strSQL.Append("FROM ")
            strSQL.Append("		dual ")
        End If


        '//------------------------------------------
        '//<TODO>パラメータの設定
        SqlParamC.fncSetParam("GROUPCD", True, txtGROUPCD_NEW.Text.Trim)

        dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

        If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
            res = True
        Else
            res = False
        End If

        Return res
    End Function

    '区分コンボボックス作成
    Private Sub fncCombo_Create_JAGKBN()
        cboJAGKBN.pComboTitle = False
        cboJAGKBN.pNoData = False
        cboJAGKBN.pType = "JAGKBN"               '//グループ区分
        cboJAGKBN.mMakeCombo()
    End Sub


End Class
