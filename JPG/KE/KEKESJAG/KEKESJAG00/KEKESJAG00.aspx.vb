'***********************************************
'欠損データ一覧  メイン画面
'***********************************************
Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common.log
Imports System.Text

Partial Class KEKESJAG00
    Inherits System.Web.UI.Page
    Protected WithEvents txtKansiCtCd As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtKansiCtNm As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSyob_From As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSyob_To As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnKen As System.Web.UI.HtmlControls.HtmlInputButton

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
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                                                                Handles MyBase.Load
        '//------------------------------------------
        '//　HTTPヘッダを送信
        HttpHeaderC.mNoCache(Response)

        '//------------------------------------------
        '//欠損一覧を出力する
        If hdnKenSaku.Value = "KEKESJFG00" Then
            Server.Transfer("KEKESJFG00.aspx")
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
             MyBase.MapPath("../../../KE/KEKESJAG/KEKESJAG00/") & "KEKESJAG00.js"))
        '<フォーカス関連関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncFo.js"))
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncDate.js"))
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
            '//　初めて開いた時だけ実行される
            '//--------------------------------------------------------------------------
            '<TODO>初期表示として必要なコントロールの設定を行います
            '      例)画面初期表示時は●●●が選択されていること……等の処理
            '//--------------------------------------------------------------------------
            '　処理結果による画面の状態の設定------------------------
            '　画面を【検索前状態】にする（入力データはそのまま遷移させる）
        Else
            '//--------------------------------------
            '//　２回目以降実行される
            '//--------------------------------------------------------------------------
            '//※画面表示するコンボボックスは各最終イベント/メソッドでCALLします
            '//--------------------------------------------------------------------------
        End If

        '//-------------------------------------------------
        '<TODO>自分の画面IDをHIDDENのhdnMyAspxに書き込む（システム共通）
        hdnMyAspx.Value = "KEKESJAG00"
        '//-------------------------------------------------

    End Sub
    '******************************************************************************
    ' 削除ボタン
    '******************************************************************************
    Private Sub btnDelete_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                                                                Handles btnDelete.ServerClick
        'hdnDelCnt　：　削除件数が格納されている
        'hdnDelKey　：　削除対象のキーがカンマ編集で格納されている
        Dim KEKESJAW00C As New KEKESJAG00KEKESJAW00.KEKESJAW00

        Dim strRec As String

        ''''''-------------------------------------------------
        ''''''開始記録
        '''''Dim LogC As New CLog
        '''''
        ''''''LogC.mAPLOG_Start(Request.Cookies.Get("ASP.NET_SessionId").Value, hdnMyAspx.Value, "3")        '//削除処理
        '''''strRec = LogC.mAPLOG_Start(Request.Cookies.Get("ASP.NET_SessionId").Value, hdnMyAspx.Value, "3")
        '''''If strRec <> "OK" Then
        '''''    Dim ErrMsgC As New CErrMsg
        '''''    strMsg.Append("alert('システムエラー：" & ErrMsgC.mGetArtMsg(strRec) & "');")
        '''''    Exit Sub
        '''''End If

        'Dim strRec As String  
        strRec = KEKESJAW00C.mDel(CInt(hdnDelCnt.Value), hdnDelKey.Value)

        Select Case strRec
            Case "OK"
                strMsg.Append("alert('正常に終了しました');")
            Case Else
                Dim ErrMsgC As New CErrMsg
                strMsg.Append("alert('システムエラー：" & ErrMsgC.mGetArtMsg(strRec) & "');")
        End Select

        '削除ボタン使用可能
        strMsg.Append("Form1.btnDelete.disabled=false;")
        strMsg.Append("Form1.btnDelete.focus();")

        ''''''//------------------------------------------
        ''''''//終了記録
        ''''''LogC.mAPLOG_End(strRec)  				
        '''''Dim strRecLog As String
        '''''strRecLog = LogC.mAPLOG_End(strRec)
        '''''If strRecLog <> "OK" Then
        '''''    Dim ErrMsgC As New CErrMsg
        '''''    strMsg.Append("alert('システムエラー：" & ErrMsgC.mGetArtMsg(strRecLog) & "');")
        '''''End If

    End Sub
End Class




