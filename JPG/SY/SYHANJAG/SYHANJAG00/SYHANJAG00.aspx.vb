'***********************************************
'
'***********************************************
Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common
Imports JPG.Common.log

Imports System.Text

Partial Class SYHANJAG00
    Inherits System.Web.UI.Page

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
    Protected WithEvents CTLCombo2 As JPG.Common.Controls.CTLCombo

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

    Private strCBO_KENCD As String

    '******************************************************************************
    ' Page_Load
    '******************************************************************************
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '2012/04/04 NEC ou Add Str
        '.NETの仕様変更により、ReadOnly属性をASPXでつけると、サーバ側で値の参照ができなくなるため、VB側でAttributeでつける
        If MyBase.IsPostBack = False Then
            txtTAISYO.Attributes.Add("ReadOnly", "true")
            txtSYUKEIF.Attributes.Add("ReadOnly", "true")
        End If
        '2012/04/04 NEC ou Add End

        '//------------------------------------------
        '//　HTTPヘッダを送信
        HttpHeaderC.mNoCache(Response)

        '//------------------------------------------
        '//　認証クラスのインスタンス生成
        AuthC = New CAuthenticate(Request, Response)

        '//------------------------------------------
        '//　認証処理
        '<TODO>：使用可能権限を指定する
        '[プルダウンマスタ]使用可能権限(運:○/営:○/監:×/出:×)
        AuthC.fncAuthCheck(Server, AuthC.pGROUP_UNKOU & "," & AuthC.pGROUP_EIGYOU)

        '連絡先選択を出力
        If hdnKensaku.Value = "SYHANJKG00" Then
            Server.Transfer("SYHANJKG00.aspx")
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
             MyBase.MapPath("../../../SY/SYHANJAG/SYHANJAG00/") & "SYHANJAG00.js"))
        '<フォーカス関連関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncFo.js"))
        '<入力チェック関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncChk.js"))
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
            '//初めて開いた時だけ実行される

            '//--------------------------------------
            '初期表示として必要なコントロールの設定を行います
            Call fncIni_format()    '//値の初期化

            '//--------------------------------------
            strCBO_KENCD = ""

            '//--------------------------------------
            'フォーカスをセットする
            strMsg.Append("Form1.rdoKBN1.focus();")
        Else
            '//--------------------------------------
            '//　２回目以降実行される
            '//--------------------------------------
            strCBO_KENCD = Request.Form("cboKENCD")
        End If

        'コンボボックスを出力する
        Call fncCombo_Create_Ken()

        'コンボの値を選択する
        Call fncComboSet()

        '//-------------------------------------------------
        '<TODO>自分の画面IDをHIDDENのhdnMyAspxに書き込む（システム共通）
        hdnMyAspx.Value = "SYHANJAG00"
        '//-------------------------------------------------
    End Sub

    '******************************************************************************
    '*　概　要：コンボボックスの選択
    '*　備　考：
    '******************************************************************************
    Private Sub fncComboSet()
        Dim list As New ListItem

        If strCBO_KENCD <> "" Then
            list = cboKENCD.Items.FindByValue(strCBO_KENCD)
            cboKENCD.SelectedIndex = cboKENCD.Items.IndexOf(list)
        End If
    End Sub

    '******************************************************************************
    '* 各コントロールの設定値の初期化
    '******************************************************************************
    Private Sub fncIni_format()
        '//--------------------------------------------------------------------------
        '<TODO>コントロールの値を初期化する
        '
        rdoKBN1.Checked = True
        rdoKBN2.Checked = False

        txtTAISYO.Text = ""
        txtSYUKEIF.Text = ""
        txtSYUKEIT.Text = ""

    End Sub

    '******************************************************************************
    '* コンボボックスの作成
    '******************************************************************************
    Private Sub fncCombo_Create_Ken()
        cboKENCD.pComboTitle = True
        cboKENCD.pNoData = False
        cboKENCD.pType = "KEN"               '//県
        cboKENCD.mMakeCombo()
    End Sub

    '******************************************************************************
    '*　概　要：県コンボボックスの値を返す
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pKENCD() As String
        Get
            Return Request.Form("cboKENCD")
        End Get
    End Property

    '******************************************************************************
    '*　概　要：対象年月の値を返す
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pTAISYO() As String
        Get
            Dim DateFncC As New CDateFnc
            Dim strRec As String
            strRec = ""
            If txtTAISYO.Text.Length = 7 Then    'YYYY/MM
                strRec = DateFncC.mHenkanGet(txtTAISYO.Text)
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：集計期間FROMの値を返す
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pSYUKEIF() As String
        Get
            Dim DateFncC As New CDateFnc
            Dim strRec As String
            strRec = ""
            If txtSYUKEIF.Text.Length = 10 Then    'YYYY/MM/DD
                strRec = DateFncC.mHenkanGet(txtSYUKEIF.Text)
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：集計期間TOの値を返す
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pSYUKEIT() As String
        Get
            Dim DateFncC As New CDateFnc
            Dim strRec As String
            strRec = ""
            If txtSYUKEIT.Text.Length = 10 Then    'YYYY/MM/DD
                strRec = DateFncC.mHenkanGet(txtSYUKEIT.Text)
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pMOT_TAISYO() As String
        Get
            Return hdnTAISYO.Value
        End Get
    End Property

    '******************************************************************************
    '*　概　要：
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pMOT_SYUKEIF() As String
        Get
            Return hdnSYUKEIF.Value
        End Get
    End Property

    '******************************************************************************
    '*　概　要：実行ボタン押下時の処理
    '*　備　考：
    '******************************************************************************
    Private Sub btnJikkou_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnJikkou.ServerClick
        Server.Transfer("SYHANJJG00.aspx")
    End Sub

End Class
