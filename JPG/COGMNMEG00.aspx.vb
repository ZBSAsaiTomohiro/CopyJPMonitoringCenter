Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common

Imports System.Text

Partial Class COGMNMEG00
    Inherits System.Web.UI.Page

    '******************************************************************************
    ' HttpHeader
    '******************************************************************************
    Protected HttpHeaderC As New CHttpHeader

    '<TODO>宣言共通仕様
    '******************************************************************************
    ' 認証クラス　2014/01/24 T.Ono add 監視改善2013
    '******************************************************************************
    Protected AuthC As CAuthenticate

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
    ' マスタ管理メニュー
    '******************************************************************************
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '//------------------------------------------
        '//　HTTPヘッダを送信
        HttpHeaderC.mNoCache(Response)

        '//------------------------------------------
        '// Script書込み用変数宣言
        Dim strScript As New StringBuilder("")
        Dim cscript1 As New CScript
        Dim strScriptPath As String
        strScriptPath = ConfigurationSettings.AppSettings("SCRIPTPATH")

        '//JavaScript----------------------------------
        strScript.Append(vbCrLf)
        strScript.Append("<Script language=javascript>" & vbCrLf)
        '<メニュー画面共通関数>
        strScript.Append(cscript1.mWriteScript(MyBase.MapPath("./") & "COGBASEG00.js") & vbCrLf)
        strScript.Append("</Script>" & vbCrLf)

        '//Css-----------------------------------------
        strScript.Append("<Style>" & vbCrLf)
        '<共通クラス>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "CssData.css") & vbCrLf)
        '<メニュー画面共通クラス>
        strScript.Append(cscript1.mWriteScript(MyBase.MapPath("./") & "COGBASEG00.css") & vbCrLf)
        strScript.Append("</Style>" & vbCrLf)

        lblScript.Text = strScript.ToString

    End Sub

End Class
