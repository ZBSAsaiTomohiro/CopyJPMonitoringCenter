Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common

Imports System.Text

Partial Class COGMNCTG00
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
    ' 監視センターメニュー
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

        '//------------------------------------------
        '//　認証クラスのインスタンス生成
        AuthC = New CAuthenticate(Request, Response)

        '--- ↓2005/04/19 MOD　Falcon↓ -----------------
        'Dim strGROUPNAME As String = AuthC.pGROUPNAME
        Dim strKANSHINAME As String = AuthC.pKANSHINAME

        'lblTitle.Text = strGROUPNAME
        lblTitle.Text = strKANSHINAME
        '--- ↑2005/04/19 MOD Falcon↑ ------------------

        '--- ↓2005/04/19 DEL　Falcon↓ -----------------
        'If Array.IndexOf(arrGroupName, AuthC.pGROUP_TOUHOKU) >= 0 Then
        '    '// 東北監視センター
        '    lblTitle.Text = "東北"
        'ElseIf Array.IndexOf(arrGroupName, AuthC.pGROUP_NAKANIHON) >= 0 Then
        '    '// 中日本監視センター
        '    lblTitle.Text = "中日本"
        'ElseIf Array.IndexOf(arrGroupName, AuthC.pGROUP_NISHINIHON) >= 0 Then
        '    '// 西日本監視センター
        '    lblTitle.Text = "西日本"
        'Else
        '    '//その他
        '    lblTitle.Text = ""
        'End If
        '--- ↑2005/04/19 DEL Falcon↑ ------------------
    End Sub

End Class
