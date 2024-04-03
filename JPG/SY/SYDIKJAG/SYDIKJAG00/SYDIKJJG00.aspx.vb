'***********************************************
'緊急監視業務代行設定
'***********************************************
Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common
Imports JPG.Common.log  '：参照設定でCOCOLOGC00を設定する

Imports System.Text

Partial Class SYDIKJJG00
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

        '//------------------------------------------
        '//　認証処理
        '<TODO>：使用可能権限を指定する
        '[監視代行]使用可能権限(運:○/営:×/監:○/出:×)
        AuthC.fncAuthCheck(Server, AuthC.pGROUP_UNKOU & "," & AuthC.pGROUP_KANSHI)

        Dim strRec As String
        Dim strMODE As String

        Dim SYDIKJAW00C As New SYDIKJAG00SYDIKJAW00.SYDIKJAW00

        Dim SYDIKJAG00C As SYDIKJAG00
        SYDIKJAG00C = CType(Context.Handler, SYDIKJAG00)

        'strMode 1:代行設定
        'strMode 2:代行解除
        strMODE = Request.Form("hdnMODE")

        '--------------------------------------------
        '<TODO>WEBサービスを呼び出す
        strRec = SYDIKJAW00C.mSet( _
                            SYDIKJAG00C.pKANSCD, _
                            SYDIKJAG00C.pDAIKOKANSCD, _
                            strMODE)

        '--------------------------------------------
        '<TODO>返り値による制御を行う。
        '【共通】
        '  OK : 正常に終了しました
        '   2 : 代行設定されていません
        '   3 : 排他制御処理でエラーが発生しました。再度実行してください


        'ログに書き込むエラーメッセージ格納
        Dim strRecMsg As String

        '画面状態の更新
        'イベントを持つオブジェクトに対するロック処理解除
        Call fncNoRocControl()

        Select Case strRec
            Case "OK"
                strMsg.Append("alert('正常に終了しました');")

                '//------------------------------
                '<TODO>フォーカスをセットする
                strMsg.Append("parent.Data.Form1.cboKANSCD.focus();")
            Case "2"
                strRecMsg = "代行設定されていません"
                strMsg.Append("alert('" & strRecMsg & "');")

                '//------------------------------
                '<TODO>フォーカスをセットする
                strMsg.Append("parent.Data.Form1.cboKANSCD.focus();")

                strRec = strRecMsg
            Case "3"
                strRecMsg = "排他制御処理でエラーが発生しました。再度実行してください"
                strMsg.Append("alert('" & strRecMsg & "');")

                '//------------------------------
                '<TODO>フォーカスをセットする
                strMsg.Append("parent.Data.Form1.btnExit.focus();")

                strRec = strRecMsg
            Case Else
                Dim ErrMsgC As New CErrMsg

                strMsg.Append("alert('システムエラー：" & ErrMsgC.mGetArtMsg(strRec) & "');")

                '//----------------------------------
                '<TODO>フォーカスをセットする
                strMsg.Append("parent.Data.Form1.cboKANSCD.focus();")
        End Select

        '-------------------------------------------------
        '//ＡＰログ書き込み
        Dim LogC As New CLog
        Dim strRecLog As String
        '2012/04/04 NEC ou Upd
        'strRecLog = LogC.mAPLog(Request.Cookies.Get("ASP.NET_SessionId").Value, AuthC.pUSERNAME, AuthC.pIPADDRESS, Request.Form("hdnMyAspx"), "1", strRec, Request.Form)
        strRecLog = LogC.mAPLog(Me.Session.SessionID, AuthC.pUSERNAME, AuthC.pIPADDRESS, Request.Form("hdnMyAspx"), "1", strRec, Request.Form)
        '2012/04/04 NEC ou Upd
        If strRecLog <> "OK" Then
            Dim errmsgc As New CErrMsg
            strMsg.Append("alert('システムエラー：" & errmsgc.mGetArtMsg(strRecLog) & "');")
        End If

        strMsg.Append("location.replace('about:blank');")   '受信フレーム内をブランクページに。

    End Sub

    '******************************************************************
    '実行前に状態にする
    '******************************************************************
    Private Sub fncNoRocControl()
        '//イベント項目としてロックしたものを使用可能
        strMsg.Append("with(parent.Data.Form1){")
        strMsg.Append("btnExit.disabled=false;")
        strMsg.Append("btnSET.disabled=false;")
        strMsg.Append("btnCANCEL.disabled=false;")
        strMsg.Append("}")
    End Sub

End Class
