Option Explicit On
Option Strict On

Imports Common

Imports System.Text

'******************************************************************************
' ポップアップ (カレンダー)
'******************************************************************************
' 2008/11/20 T.Watabe 「監視対応数集計表」用に記述追加

Partial Class COCALDRG00
    Inherits System.Web.UI.Page

    '******************************************************************************
    ' HttpHeader
    '******************************************************************************
    Protected HttpHeaderC As New CHttpHeader

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

    '------------------------------------------------------------------------------
    '<TODO>機能追加時に対象のプロジェクトを追加していく
    Protected KEKEKJAG00_C As KEKEKJAG00.KEKEKJAG00
    Protected KERUIJOG00_C As KERUIJOG00.KERUIJOG00
    '/* 2006/05/24 ADD_BEGIN */
    Protected KETAISYG00_C As KETAISYG00.KETAISYG00  '/* 警報出力指示画面 */
    '/* 2006/05/24 ADD_END */
    Protected KEKANSYG00_C As KEKANSYG00.KEKANSYG00  '/* 監視対応数集計表 ' 2008/11/20 T.Watabe add */
    Protected KESAIJAG00_C As KESAIJAG00.KESAIJAG00  '/* 災害対応帳票　   ' 2020/01/06 T.Ono add */
    '-----------------------------------------------------------------------

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
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                                                                Handles MyBase.Load
        '//------------------------------------------
        '//　HTTPヘッダを送信
        HttpHeaderC.mNoCache(Response)

        '//------------------------------------------
        '// Script書込み用変数宣言
        Dim strScript As New StringBuilder("")
        Dim cscript1 As New CScript
        Dim strScriptPath As String
        strScriptPath = ConfigurationSettings.AppSettings("SCRIPTPATH")

        '------------------------------------------------------------------------------
        '<TODO>HTML内に必要なJavaScript/CSSはここで[strScript]変数に格納後
        '      画面上[lblScript]に書き込みを行います(SPANタグとしてクライアントにスクリプトが
        '      出力されます。)
        '//------------------------------------------
        '//　Css格納
        strScript.Append("<Style>")
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "CssPopup.css"))
        strScript.Append("</Style>")
        '//------------------------------------------
        '//　Script書込み
        lblScript.Text = strScript.ToString

        '//--------------------------------------------------------------------------------
        If MyBase.IsPostBack = False Then
            '//--------------------------------------
            '//　初めて開いた時だけ実行される
            '------------------------------------------------------------------------------
            '<TODO>機能追加時に対象のプロジェクトを追加していく
            If Request.Path.LastIndexOf("KEKEKJAG00") >= 0 Then
                KEKEKJAG00_C = CType(Context.Handler, KEKEKJAG00.KEKEKJAG00)
                hdnBackDate.Value = KEKEKJAG00_C.pBackDate
                hbdBackFocs.Value = KEKEKJAG00_C.pBackFocs
            End If

            If Request.Path.LastIndexOf("KERUIJOG00") >= 0 Then
                KERUIJOG00_C = CType(context.Handler, KERUIJOG00.KERUIJOG00)
                hdnBackDate.Value = KERUIJOG00_C.pBackDate
                hbdBackFocs.Value = KERUIJOG00_C.pBackFocs
            End If
            '/* 2006/05/24 ADD_BEGIN */
            If Request.Path.LastIndexOf("KETAISYG00") >= 0 Then
                KETAISYG00_C = CType(context.Handler, KETAISYG00.KETAISYG00)
                hdnBackDate.Value = KETAISYG00_C.pBackDate
                hbdBackFocs.Value = KETAISYG00_C.pBackFocs
            End If
            '/* 2006/05/24 ADD_END   */
            ' 2008/11/20 T.Watabe add
            If Request.Path.LastIndexOf("KEKANSYG00") >= 0 Then
                KEKANSYG00_C = CType(context.Handler, KEKANSYG00.KEKANSYG00)
                hdnBackDate.Value = KEKANSYG00_C.pBackDate
                hbdBackFocs.Value = KEKANSYG00_C.pBackFocs
            End If
            '災害対応帳票　2020/01/06 T.Ono add
            If Request.Path.LastIndexOf("KESAIJAG00") >= 0 Then
                KESAIJAG00_C = CType(Context.Handler, KESAIJAG00.KESAIJAG00)
                hdnBackDate.Value = KESAIJAG00_C.pBackDate
                hbdBackFocs.Value = KESAIJAG00_C.pBackFocs
            End If

            '本日の日付を選択状態で出力します------------------
            calender.SelectedDate = DateTime.Now

            '--------------------------------------------------
        Else
            '------------------------------------------------------------------------------
            '//Null
        End If

    End Sub

    '******************************************************************************
    ' カレンダーのクリック
    '******************************************************************************
    Private Sub calender_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                                                                Handles calender.SelectionChanged
        Dim strDate As String = Format(calender.SelectedDate, "yyyy/MM/dd")
        '//日付のセット
        If hdnBackDate.Value <> "" Then
            strMsg.Append("obj1=parent.opener.frames(""data"").document.getElementById(""" & hdnBackDate.Value & """);")
            strMsg.Append("obj1.value='" & strDate & "';")
        End If
        '// フォーカスのセット
        If hbdBackFocs.Value <> "" Then
            strMsg.Append("obj2=parent.opener.frames(""data"").document.getElementById(""" & hbdBackFocs.Value & """);")
            strMsg.Append("obj2.focus();")
        End If
        strMsg.Append("window.close();")
    End Sub
End Class
