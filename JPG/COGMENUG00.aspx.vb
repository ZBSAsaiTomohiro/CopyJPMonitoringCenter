Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common

Partial Class COGMENUG00
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

        Dim strGROUPNAME As String = AuthC.pGROUPNAME
        Dim arrGroupName() As String = strGROUPNAME.Split(Convert.ToChar(","))

        '--- ↓2005/04/19 MOD　Falcon↓ -----------------
        Dim bolKANSHI_FLG As Boolean = False
        Dim arrKanshiGroup() As String = AuthC.pGROUP_KANSHI.Split(Convert.ToChar(","))
        Dim i As Integer
        Dim bolUNKOU_FLG As Boolean = False
        Dim arrUnkouGroup() As String = AuthC.pGROUP_UNKOU.Split(Convert.ToChar(","))

        '>>運行開発部所属チェック
        For i = 0 To arrUnkouGroup.Length - 1
            If Array.IndexOf(arrGroupName, arrUnkouGroup(i)) >= 0 Then
                bolUNKOU_FLG = True
                Exit For
            End If
        Next i

        '>>監視センター所属チェック
        If bolUNKOU_FLG = False Then
            For i = 0 To arrKanshiGroup.Length - 1
                If Array.IndexOf(arrGroupName, arrKanshiGroup(i)) >= 0 Then
                    bolKANSHI_FLG = True
                    Exit For
                End If
            Next i
        End If
        '--- ↑2005/04/19 MOD Falcon↑ ------------------

        '--- ↓2005/04/19 MOD　Falcon↓ -----------------
        If bolUNKOU_FLG = True Then
            '//-----------------------------------------------------
            '// 運行開発部のグループに属している場合は「運行開発部メニュー」を出力
            '//-----------------------------------------------------

            Server.Transfer("COGMNKHG00.aspx")
            '--- ↑2005/04/19 MOD Falcon↑ ------------------

            '--- ↓2005/04/19 DEL　Falcon↓ -----------------
            'If Array.IndexOf(arrGroupName, AuthC.pGROUP_UNKOU) >= 0 Then
            '    '//-----------------------------------------------------
            '    '// 運行開発部のグループに属している場合は「運行開発部メニュー」を出力
            '    '//-----------------------------------------------------
            '    Server.Transfer("COGMNKHG00.aspx")
            '--- ↑2005/04/19 DEL Falcon↑ ------------------

            '--- ↓2005/04/19 MOD　Falcon↓ -----------------
        ElseIf bolKANSHI_FLG = True Then
            '//-----------------------------------------------------
            '// 監視センターのグループに属している場合は「監視センターメニュー」を出力
            '//-----------------------------------------------------
            Server.Transfer("COGMNCTG00.aspx")
            '--- ↑2005/04/19 MOD Falcon↑ ------------------

            '--- ↓2005/04/19 DEL　Falcon↓ -----------------
            '''''ElseIf Array.IndexOf(arrGroupName, AuthC.pGROUP_TOUHOKU) >= 0 Then
            '''''    '//-----------------------------------------------------
            '''''    '// 仙台監視センターのグループに属している場合は「監視センターメニュー」を出力
            '''''    '//-----------------------------------------------------
            '''''    Server.Transfer("COGMNCTG00.aspx")

            '''''ElseIf Array.IndexOf(arrGroupName, AuthC.pGROUP_NAKANIHON) >= 0 Then
            '''''    '//-----------------------------------------------------
            '''''    '// 中日本監視センターのグループに属している場合は「監視センターメニュー」を出力
            '''''    '//-----------------------------------------------------
            '''''    Server.Transfer("COGMNCTG00.aspx")

            '''''ElseIf Array.IndexOf(arrGroupName, AuthC.pGROUP_NISHINIHON) >= 0 Then
            '''''    '//-----------------------------------------------------
            '''''    '// 広島監視センターのグループに属している場合は「監視センターメニュー」を出力
            '''''    '//-----------------------------------------------------
            '''''    Server.Transfer("COGMNCTG00.aspx")
            '--- ↑2005/04/19 DEL Falcon↑ ------------------

        ElseIf Array.IndexOf(arrGroupName, AuthC.pGROUP_EIGYOU) >= 0 Then
            '//-----------------------------------------------------
            '// 営業部のグループに属している場合は「営業部メニュー」を出力
            '//-----------------------------------------------------
            Server.Transfer("COGMNEGG00.aspx")

        Else
            '//-----------------------------------------------------
            '// 営業部のグループに属している場合は「営業部メニュー」を出力
            '// 取得文字列が最後についているグループ名を営業所として判断
            '//-----------------------------------------------------
            Dim j As Integer
            Dim intEIGYOU_LEN As Integer
            Dim intGROUP_LEN As Integer
            intEIGYOU_LEN = AuthC.pGROUP_EIGYOU.Length
            For j = 0 To arrGroupName.Length - 1
                intGROUP_LEN = arrGroupName(j).Length
                If intGROUP_LEN > 0 Then
                    If Convert.ToString(arrGroupName(j)).Substring(intGROUP_LEN - intEIGYOU_LEN, intEIGYOU_LEN) = AuthC.pGROUP_EIGYOU Then
                        '//営業所グループ名が存在する場合はそのままリターン
                        Server.Transfer("COGMNEGG00.aspx")
                    End If
                End If
            Next

            Response.Write("所属グループを特定できませんでした")
        End If
    End Sub

End Class
