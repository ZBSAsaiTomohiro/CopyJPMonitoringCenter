Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common

Imports System.Text

Partial Class COGMNSSG00
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
    ' システム管理メニュー
    '******************************************************************************
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '//------------------------------------------
        '//　HTTPヘッダを送信
        HttpHeaderC.mNoCache(Response)

        '//------------------------------------------
        '//　認証クラスのインスタンス生成
        AuthC = New CAuthenticate(Request, Response)

        '//------------------------------------------
        '// Script書込み用変数宣言
        Dim strScript As New StringBuilder("")
        Dim cscript1 As New CScript
        Dim strScriptPath As String
        strScriptPath = ConfigurationSettings.AppSettings("SCRIPTPATH")

        '//JavaScript--------------------------------
        strScript.Append(vbCrLf)
        strScript.Append("<Script language=javascript>" & vbCrLf)
        '<メニュー画面共通関数>
        strScript.Append(cscript1.mWriteScript(MyBase.MapPath("./") & "COGBASEG00.js") & vbCrLf)
        strScript.Append("</Script>" & vbCrLf)

        '//Css---------------------------------------
        strScript.Append("<Style>" & vbCrLf)
        '<共通クラス>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "CssData.css") & vbCrLf)
        '<メニュー画面共通クラス>
        strScript.Append(cscript1.mWriteScript(MyBase.MapPath("./") & "COGBASEG00.css") & vbCrLf)
        strScript.Append("</Style>" & vbCrLf)

        '//------------------------------------------
        'ログイングループにより[帳票データ作成]出力の有無を決定する
        Dim strGROUPNAME As String = AuthC.pGROUPNAME
        Dim arrGroupName() As String = strGROUPNAME.Split(Convert.ToChar(","))
        strScript.Append("<Script language=javascript>" & vbCrLf)
        strScript.Append("function window_onload() {")
        If Array.IndexOf(arrGroupName, AuthC.pGROUP_UNKOU) >= 0 Then
            '// 運行開発部のグループに属している場合は「帳票データ作成」を出力
            strScript.Append("document.all.sp01.style.visibility='visible';")
        Else
            '// 監視センターのグループに属している場合は「帳票データ作成」を隠す
            strScript.Append("document.all.sp01.style.visibility='hidden';")
        End If
        strScript.Append("}")
        strScript.Append("</Script>" & vbCrLf)

        '//スクリプトの出力--------------------------
        lblScript.Text = strScript.ToString

    End Sub
End Class
