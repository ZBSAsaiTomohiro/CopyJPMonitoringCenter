'***********************************************
'
'***********************************************
'<TODO>宣言共通仕様
Option Explicit On
Option Strict On

'<TODO>宣言共通仕様
Imports Common
Imports JPG.Common
Imports JPG.Common.log

Imports System.Text

Partial Class SYHANJJG00
    Inherits System.Web.UI.Page

    '<TODO>宣言共通仕様
    '******************************************************************************
    ' HttpHeader
    '******************************************************************************
    Protected HttpHeaderC As New CHttpHeader

    '<TODO>宣言共通仕様
    '******************************************************************************
    '認証クラス
    '******************************************************************************
    Protected AuthC As CAuthenticate

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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '//------------------------------------------
        '//　HTTPヘッダを送信
        HttpHeaderC.mNoCache(Response)

        '//------------------------------------------
        '//　認証クラスのインスタンス生成
        AuthC = New CAuthenticate(Request, Response)

        '//-----------------------------------------
        Dim SYHANJAG00C As SYHANJAG00
        SYHANJAG00C = CType(Context.Handler, SYHANJAG00)

        '//------------------------------------------
        Dim SYHANJAW00C As New SYHANJAG00SYHANJAW00.SYHANJAW00
        Dim strRec As String

        'EXE実行----------------------------------
        strRec = SYHANJAW00C.mExec(SYHANJAG00C.pKENCD, _
                                   SYHANJAG00C.pTAISYO, _
                                   SYHANJAG00C.pSYUKEIF, _
                                   SYHANJAG00C.pSYUKEIT, _
                                   SYHANJAG00C.pMOT_TAISYO, _
                                   SYHANJAG00C.pMOT_SYUKEIF)

        '//ロックした項目の解除-------------------------
        strMsg.Append("parent.Data.Form1.btnJikkou.disabled=false;")
        strMsg.Append("parent.Data.Form1.btnExit.disabled=false;")
        strMsg.Append("parent.Data.Form1.btnJikkou.focus();")

        '//結果取得-------------------------------------
        If strRec = "OK" Then
            strMsg.Append("parent.Data.cboKen_change();")   '更新した日付情報を画面に反映させるため
            strMsg.Append("alert('処理を受け付けました');")

        ElseIf strRec = "0" Then
            strMsg.Append("parent.Data.cboKen_change();")
            strMsg.Append("alert('他のユーザーによって既に処理が行われています。再度実行してください');")

        Else
            'エラーであればブラウザにメッセージ表示
            Dim ErrMsgC As New CErrMsg
            strMsg.Append("alert('システムエラー：" & ErrMsgC.mGetArtMsg(strRec) & "');")

        End If

        '-------------------------------------------------
        '//ＡＰログ書き込み
        Dim LogC As New CLog
        Dim strRecLog As String
        '2012/04/04 NEC ou Upd
        'strRecLog = LogC.mAPLog(Request.Cookies.Get("ASP.NET_SessionId").Value, _
        '            AuthC.pUSERNAME, AuthC.pIPADDRESS, Request.Form("hdnMyAspx"), "1", strRec, Request.Form)
        strRecLog = LogC.mAPLog(Me.Session.SessionID, _
            AuthC.pUSERNAME, AuthC.pIPADDRESS, Request.Form("hdnMyAspx"), "1", strRec, Request.Form)
        '2012/04/04 NEC ou Upd
        If strRecLog <> "OK" Then
            Dim errmsgc As New CErrMsg
            strMsg.Append("alert('システムエラー：" & errmsgc.mGetArtMsg(strRecLog) & "');")
        End If

        '-------------------------------------------------
        '//処理実行後cboKen_changeを行うためコメントとする
        'strMsg.Append("location.replace('about:blank');")   '受信フレーム内をブランクページに。
    End Sub

End Class
