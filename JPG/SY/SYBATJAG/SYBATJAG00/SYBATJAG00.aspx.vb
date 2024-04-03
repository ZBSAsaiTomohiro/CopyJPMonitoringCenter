'***********************************************
'バッチ実行履歴一覧  メイン画面
'***********************************************
' 変更履歴
' 2011/04/20 T.Watabe BTFAXJBE00（自動ＦＡＸ２）一覧に追加 
Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common
Imports System.Text

Partial Class SYBATJAG00
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
        '[対応結果一覧]使用可能権限(運:○/営:×/監:△/出:×)
        AuthC.fncAuthCheck(Server, AuthC.pGROUP_UNKOU & "," & AuthC.pGROUP_KANSHI)

        '//------------------------------------------
        '//一覧のIFRAMEを出力する
        If hdnKenSaku.Value = "SYBATJFG00" Then
            Server.Transfer("SYBATJFG00.aspx")
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
             MyBase.MapPath("../../../SY/SYBATJAG/SYBATJAG00/") & "SYBATJAG00.js"))
        '<フォーカス関連関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncFo.js"))
        '<日付関連関数>
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

            '//--------------------------------------
            '初期表示として必要なコントロールの設定を行います
            Call fncIni_format()    '//値の初期化

            '//--------------------------------------------------------------------------
            '<TODO>初期表示として必要なコントロールの設定を行います
            '      例)画面初期表示時は●●●が選択されていること……等の処理
            '//--------------------------------------------------------------------------
            '　処理結果による画面の状態の設定------------------------
            '　画面を【検索前状態】にする（入力データはそのまま遷移させる）
            '//--------------------------------------------------------------------------
            'フォーカスをセットする
            strMsg.Append("Form1.btnSelect.focus();")
        Else
            '//--------------------------------------
            '//　２回目以降実行される
            '//--------------------------------------------------------------------------
            '//※画面表示するコンボボックスは各最終イベント/メソッドでCALLします
            '//--------------------------------------------------------------------------
        End If

        '//-------------------------------------------------
        '<TODO>自分の画面IDをHIDDENのhdnMyAspxに書き込む（システム共通）
        hdnMyAspx.Value = "SYBATJAG00"
        '//-------------------------------------------------

    End Sub

    '******************************************************************************
    '* 各コントロールの設定値の初期化
    '******************************************************************************
    Private Sub fncIni_format()

        'コンボ作成
        cboPROC_ID.Items.Add(New ListItem("", ""))
        cboPROC_ID.Items.Add(New ListItem("BTGETJAE00:月次データ整理", "BTGETJAE00"))
        'cboPROC_ID.Items.Add(New ListItem("BTFAXJAE00:自動ＦＡＸ", "BTFAXJAE00")) 2013/12/06 T.Ono del 監視改善2013
        'cboPROC_ID.Items.Add(New ListItem("BTFAXJBE00:自動ＦＡＸ２", "BTFAXJBE00")) ' 2011/04/20 T.Watabe add　2013/12/06 T.Ono del 監視改善2013
        cboPROC_ID.Items.Add(New ListItem("BTFAXJCE00:自動ＦＡＸ2013", "BTFAXJCE00")) '2013/12/06 T.Ono del 監視改善2013
        cboPROC_ID.Items.Add(New ListItem("BTFAXJDE00:自動ＦＡＸ2014", "BTFAXJDE00")) '2015/03/10 T.Ono add 2014改善開発
        cboPROC_ID.Items.Add(New ListItem("BTFAXJEE00:自動ＦＡＸ2015", "BTFAXJEE00")) '2016/04/04 T.Ono add 2015改善開発
        'cboPROC_ID.Items.Add(New ListItem("SYHANJAE00:販売管理締処理", "SYHANJAE00"))　2013/12/06 T.Ono del 監視改善2013
        'cboPROC_ID.Items.Add(New ListItem("BTLTSJAE00:次期ＬＴＯＳ連動", "BTLTSJAE00"))　2013/12/06 T.Ono mod 監視改善2013
        cboPROC_ID.Items.Add(New ListItem("BTLTSJAE00:ＪＡ－ＬＴＯＳ連動", "BTLTSJAE00"))

        cboPROC_ID.SelectedIndex = 0

        '//「異常」を選択する
        rdoKBN1.Checked = False
        rdoKBN2.Checked = False
        rdoKBN3.Checked = True

        '//対象日付はシステム日付を出力する(yyyy/MM/dd)。
        txtTRGDATE_From.Text = Now.ToString("yyyy/MM/dd")
        txtTRGDATE_To.Text = Now.ToString("yyyy/MM/dd")

    End Sub

    '******************************************************************************
    '*　概　要：パラメータ値より日付YYYYMMDD値を返す
    '*　備　考：
    '******************************************************************************
    Public Function fncDateGet(ByVal pstrDate As String) As String
        Dim DateFncC As New CDateFnc
        Dim strRec As String
        strRec = ""
        If pstrDate.Length <> 0 Then
            strRec = DateFncC.mHenkanGet(pstrDate)
        End If

        Return strRec
    End Function

    '******************************************************************************
    '*　概　要：パラメータ値より日付YYYY/MM/DD値を返す
    '*　備　考：
    '******************************************************************************
    Public Function fncDateSet(ByVal pstrDate As String) As String
        Dim DateFncC As New CDateFnc
        Dim strRec As String
        strRec = ""
        If IsNumeric(pstrDate) = True Then
            strRec = DateFncC.mGet(pstrDate)
        End If

        Return strRec
    End Function

    '******************************************************************************
    '*　概　要：パラメータ値より時刻HH:mm:ss値を返す
    '*　備　考：
    '******************************************************************************
    Public Function fncTimeSet(ByVal pstrTime As String, ByVal intInd As Integer) As String
        Dim TimeFncC As New CTimeFnc
        Dim strRec As String
        strRec = ""
        If IsNumeric(pstrTime) = True Then
            strRec = TimeFncC.mGet(pstrTime, intInd)
        End If

        Return strRec
    End Function

    '<TODO>検索条件としてIFRAME画面に引き渡したい値ReadOnlyプロパティで設定する
    '******************************************************************************
    '*　概　要：区分の値を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pKbn() As String
        Get
            Dim strRec As String = Request.Form("rdoKBN")
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：対象処理の値を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pPROC_ID() As String
        Get
            Dim strRec As String = Request.Form("cboPROC_ID")
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：対象日付（Ｆｒｏｍ）の値を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pTRGDATE_F() As String
        Get
            Return fncDateGet(txtTRGDATE_From.Text)
        End Get
    End Property

    '******************************************************************************
    '*　概　要：対象日付（Ｔｏ）の値を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pTRGDATE_T() As String
        Get
            Return fncDateGet(txtTRGDATE_To.Text)
        End Get
    End Property

    '******************************************************************************
    '*　概　要：hdnSelectClickの値を渡すプロパティ
    '*　備　考：検索ボタン押下時のみ"1"が代入。IFRAME内にて遷移的出力なのか検索出力なのかを判定(MESSAGE)
    '******************************************************************************
    Public ReadOnly Property pSelectClick() As String
        Get
            Return hdnSelectClick.Value
        End Get
    End Property

End Class
