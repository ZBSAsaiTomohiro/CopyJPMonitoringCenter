
Imports Common

Imports System.Configuration

Partial Class COGBASEG00
    Inherits System.Web.UI.Page

    '<TODO>宣言共通仕様
    '******************************************************************************
    ' HttpHeader
    '******************************************************************************
    Protected HttpHeaderC As New CHttpHeader

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

        If IsNothing(Request.QueryString("CTINO")) = True Then
            '//通常のメニューを出力する
            hdnMNFLG.Value = ""
            hdnSVFLG.Value = ""

        ElseIf Convert.ToString(Request.QueryString("CTINO")).Length > 0 Then
            hdnMNFLG.Value = "SYCTIJAG00"
            hdnSVFLG.Value = Request.QueryString("CTINO")

        Else
            '//通常のメニューを出力する
            hdnMNFLG.Value = ""
            hdnSVFLG.Value = ""

        End If

    End Sub

End Class
