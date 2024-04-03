'******************************************************************************
' ポップアップ (呼び出し部)
'******************************************************************************

Option Explicit On
Option Strict On

Imports Common

Imports System.Text

'******************************************************************************
' ポップアップ (呼び出し部)
'******************************************************************************

Partial Class MSTAGJCG00
    Inherits System.Web.UI.Page
    'システム項目
    Protected strListName As String

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

    '------------------------------------------------------------------------------
    '<TODO>機能追加時に対象のプロジェクトを追加していく
    '-----------------------------------------------------------------------
    Protected MSTAGJAG00_C As MSTAGJAG00


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
        'Iframe出力
        If hdnKensaku.Value = "MSTAGJBG00" Then
            Server.Transfer("MSTAGJBG00.aspx")
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
             MyBase.MapPath("../../../MS/MSTAGJAG/MSTAGJAG00/") & "MSTAGJCG00.js"))
        '--- ↓2012/02/16 UPD NEC↓  ---
        '<フォーカス関連関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncFo.js"))
        '<入力チェック関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncChk.js"))
        strScript.Append("</Script>")
        '//------------------------------------------
        '//　Css格納
        strScript.Append("<Style>")
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "CssPopup.css"))
        strScript.Append("</Style>")
        '//------------------------------------------
        '//　Script書込み
        lblScript.Text = strScript.ToString

        '------------------------------------------------------------------------------
        '<TODO>機能追加時に対象のプロジェクトを追加していく
        '------------------------------------------------------------------------------
        MSTAGJAG00_C = CType(Context.Handler, MSTAGJAG00)
        '一覧タイトルの表示
        strListName = "登録JA支所一覧"
        lblListName.Text = strListName
        hdnCode1.Value = MSTAGJAG00_C.pGROUPCD
        'ウィンドウのタイトルの設定
        strMsg.Append("document.title='" & strListName & "'")
    End Sub

    '******************************************************************************
    '*　概　要：コードの値を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pCode1() As String
        Get
            Return hdnCode1.Value
        End Get
    End Property
End Class
