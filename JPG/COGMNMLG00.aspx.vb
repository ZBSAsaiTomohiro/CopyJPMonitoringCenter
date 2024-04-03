Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common '2014/02/26 T.Ono add 監視改善2013

Imports System.Text

Partial Class COGMNMLG00
    Inherits System.Web.UI.Page

    '******************************************************************************
    ' HttpHeader
    '******************************************************************************
    Protected HttpHeaderC As New CHttpHeader

    '<TODO>宣言共通仕様
    '******************************************************************************
    ' 認証クラス　2014/02/26 T.Ono add 監視改善2013
    '******************************************************************************
    Protected AuthC As CAuthenticate

    '<TODO>宣言共通仕様
    '******************************************************************************
    ' ScriptMessage　2014/02/26 T.Ono add 監視改善2013
    '******************************************************************************
    Private strMsg As New StringBuilder("")

    '<TODO>宣言共通仕様
    '******************************************************************************
    ' Render　2014/02/26 T.Ono add 監視改善2013
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
    ' マスタ一覧メニュー
    '******************************************************************************
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '//------------------------------------------
        '//　HTTPヘッダを送信
        HttpHeaderC.mNoCache(Response)

        '2014/02/06 T.Ono add 監視改善2013 ユーザー情報を確認 ----------START
        '//------------------------------------------
        '//　認証クラスのインスタンス生成
        AuthC = New CAuthenticate(Request, Response)

        Dim strGROUPNAME As String = AuthC.pGROUPNAME
        Dim arrGroupName() As String = strGROUPNAME.Split(Convert.ToChar(","))
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
        '2014/02/26 T.Ono add 監視改善2013 ユーザー情報を確認 ----------END


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

        '2014/02/26 T.Ono add 監視改善2013 ログインユーザーにより、ボタンの表示・非表示を制御 ----------START
        If bolUNKOU_FLG = True Then
            '運行開発部
        ElseIf bolKANSHI_FLG = True Then
            '監視センター
            strMsg.Append("fncDispMNML(0);")
        End If
        '2014/02/26 T.Ono add 監視改善2013 ログインユーザーにより、ボタンの表示・非表示を制御 ----------END

    End Sub

End Class
