'***********************************************
'月次データ整理　　実行処理
'***********************************************
'<TODO>宣言共通仕様
Option Explicit On
Option Strict On

'<TODO>宣言共通仕様
Imports Common          '：参照設定でCOCOMONC00を設定する
Imports JPG.Common
Imports JPG.Common.log  '：参照設定でCOCOLOGC00を設定する
Imports System.Text     '：StringBuilderを使用するため

Partial Class SYGETJJG00
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

        Dim SYGETJAG00C As SYGETJAG00
        SYGETJAG00C = CType(Context.Handler, SYGETJAG00)

        '//------------------------------------------

        Dim SYGETJAW00C As New SYGETJAG00SYGETJAW00.SYGETJAW00
        Dim strRec As String

        'EXE実行----------------------------------
        strRec = SYGETJAW00C.mExec(Request.Form("hdnTRGDATEM"), _
                                SYGETJAG00C.fncDateGet(Request.Form("txtTRGDATE1")), _
                                SYGETJAG00C.fncDateGet(Request.Form("txtTRGDATE2")), _
                                SYGETJAG00C.fncDateGet(Request.Form("txtTRGDATE3")), _
                                SYGETJAG00C.pDelmonth_ApLog, _
                                SYGETJAG00C.pDelmonth_BatLog, _
                                SYGETJAG00C.pDelmonth_TelLog, _
                                SYGETJAG00C.pDelmonth_File, _
                                SYGETJAG00C.pDelmonth_BackFile, _
                                Convert.ToString(Format(Now, "yyyyMMdd")), _
                                Convert.ToString(Format(Now, "HHmmss")))

        If strRec = "OK" Then
            strMsg.Append("parent.Data.Form1.btnExit.disabled=false;")
            strMsg.Append("parent.Data.Form1.btnExit.focus();")
            strMsg.Append("alert('処理を受け付けました');")
        Else
            'エラーであればブラウザにメッセージ表示
            Dim ErrMsgC As New CErrMsg
            strMsg.Append("parent.Data.Form1.btnExit.disabled=false;")
            strMsg.Append("parent.Data.Form1.btnExit.focus();")
            strMsg.Append("alert('システムエラー：" & ErrMsgC.mGetArtMsg(strRec) & "');")
        End If


        '-------------------------------------------------
        '//ＡＰログ書き込み
        Dim LogC As New CLog
        Dim strRecLog As String
        '2012/04/04 NEC ou Upd Str
        'strRecLog = LogC.mAPLog(Request.Cookies.Get("ASP.NET_SessionId").Value, _
        '            AuthC.pUSERNAME, AuthC.pIPADDRESS, Request.Form("hdnMyAspx"), "1", strRec, Request.Form)
        strRecLog = LogC.mAPLog(Me.Session.SessionID, _
                    AuthC.pUSERNAME, AuthC.pIPADDRESS, Request.Form("hdnMyAspx"), "1", strRec, Request.Form)
        '2012/04/04 NEC ou Upd End
        If strRecLog <> "OK" Then
            Dim errmsgc As New CErrMsg
            strMsg.Append("alert('システムエラー：" & errmsgc.mGetArtMsg(strRecLog) & "');")
        End If

    End Sub

End Class
