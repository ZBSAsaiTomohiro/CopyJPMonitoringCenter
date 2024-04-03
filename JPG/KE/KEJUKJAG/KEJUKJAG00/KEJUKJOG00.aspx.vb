'***********************************************
'受信警報表示パネル  データ警報出力
'***********************************************
Option Explicit On
Option Strict On

Imports Common
Imports System.Text
Imports JPG.Common
Imports System.IO
Imports System.Diagnostics
Imports JPG.Common.log

Partial Class KEJUKJOG00
    Inherits System.Web.UI.Page

    '******************************************************************************
    ' HttpHeader
    '******************************************************************************
    Protected HttpHeaderC As New CHttpHeader

    '******************************************************************************
    ' ScriptMessage
    '******************************************************************************
    Private strMsg As New StringBuilder("")      '//<script>は必要なし
    Protected AuthC As CAuthenticate
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

    '******************************************************************************
    ' Page_Load
    '******************************************************************************
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '//------------------------------------------
        '//　HTTPヘッダを送信
        HttpHeaderC.mNoCache(Response)
        AuthC = New CAuthenticate(Request, Response)
        Dim lineno As String = New StackFrame(True).GetFileLineNumber.ToString
        mlog("[KEJUKJOG00 " & lineno & "]- Page_Load start")

        'webConfigファイルより下記データを取得します
        '≫WAVファイルURL
        '≫WAVファイルLOOP回数
        '≫警報出力時間(秒)
        Dim strWAVURL As String = ConfigurationSettings.AppSettings("WAVURL")
        Dim strWAVCNT As String = CStr(CInt(ConfigurationSettings.AppSettings("WAVCNT")))
        Dim strWAVSEC As String = CStr(CInt(ConfigurationSettings.AppSettings("WAVSEC")) * 1000)

        '警報の情報をセット
        strMsg.Append("document.write('<BGSOUND SRC=""" & strWAVURL & """ LOOP=""" & strWAVCNT & """>');")
        strMsg.Append("myTimer = setInterval('fncWav_end()'," & strWAVSEC & ");")

        'フォーカスをセットします(最新表示)。
        strMsg.Append("obj1=parent.opener.frames('Data').document.getElementById('btnRenew');")
        strMsg.Append("obj1.focus();")

        '画面を終了します
        strMsg.Append("function fncWav_end(){")
        strMsg.Append(" window.close();")
        strMsg.Append("}")
        lineno = New StackFrame(True).GetFileLineNumber.ToString
        mlog("[KEJUKJOG00 " & lineno & "]- Page_Load end")

    End Sub
    '**********************************************************
    ' 2012/06/28 ADD W.GANEKO
    'ログ吐き出し
    '戻り値：書き込んだファイルへのフルパス
    '**********************************************************
    Public Sub mlog(ByVal pstrString As String)
        Dim strFilnm As String = "log" & System.DateTime.Today.ToString("yyyyMMdd")
        Dim strLogPath As String = ConfigurationSettings.AppSettings("LOG_OUT_PATH")
        Dim strPath As String = strLogPath & strFilnm & ".txt"
        Dim strLogFlg As String = ConfigurationSettings.AppSettings("LOG_OUT")
        Dim LogC As New CLog
        Dim strRecLog As String
        Dim linestring As New StringBuilder("")
        If strLogFlg = "1" Then
            '書き込みファイルへのストリーム
            'Dim sw As StreamWriter
            'Dim fs As New FileStream(strPath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite)
            'linestring = New StringBuilder("")
            'linestring.Append(System.DateTime.Now & "." & System.DateTime.Now.Millisecond & "[" & AuthC.pUSERNAME & "][" & AuthC.pIPADDRESS & "][" & Me.Session.SessionID & "]" & pstrString & Chr(13) & Chr(10))
            Dim tbllog As String = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff") & " " & pstrString
            strRecLog = LogC.mAPLog(Me.Session.SessionID, AuthC.pUSERNAME, AuthC.pIPADDRESS, Request.Form("hdnMyAspx"), "4", tbllog, Request.Form)
            'sw = New StreamWriter(fs, System.Text.Encoding.Default)

            ''引数の文字列をストリームに書き込み
            'sw.Write(linestring.ToString)

            ''メモリフラッシュ（ファイル書き込み）
            ''sw.Flush()

            ''ファイルクローズ
            'sw.Close()
            'sw.Dispose()
            'fs.Close()
            'fs.Dispose()
        End If
    End Sub
End Class
