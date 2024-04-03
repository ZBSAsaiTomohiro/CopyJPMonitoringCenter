'******************************************************************************
' ポップアップ (呼び出し部)
'******************************************************************************
' 変更履歴
' 2013/12/12 T.Ono add 監視改善2013 クライアント・JA選択ポップアップ追加のためJPGからコピー

Option Explicit On
Option Strict On

Imports Common

Imports System.Text

'******************************************************************************
' ポップアップ (呼び出し部)
'******************************************************************************

Partial Class COPOPUPG00
    Inherits System.Web.UI.Page
    'システム項目
    Protected strListName As String

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
    Protected SDLSTJAG00_C As SDLSTJAG00.SDLSTJAG00         '出動一覧
    ' 2014/10/23 H.Hosoda add 1Line 2014改善開発 No11 START
    Protected SDSYUJAG00_C As SDSYUJAG00.SDSYUJAG00        '緊急出動対応入力
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
        'Iframe出力
        If hdnKensaku.Value = "COPOPUFG00" Then
            Server.Transfer("COPOPUFG00.aspx")
        End If

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
        '//　JavaScript格納
        strScript.Append("<Script language=javascript>")
        '<ポップアップ用関数>
        '--- ↓2012/02/16 UPD NEC↓  ---
        'strScript.Append(cscript1.mWriteScript(MyBase.MapPath("../../../Popup/") & "COPOPUPG00.js"))
        strScript.Append(cscript1.mWriteScript(MyBase.MapPath("../../JPSD/Popup/") & "COPOPUPG00.js"))
        '--- ↓2012/02/16 UPD NEC↓  ---
        '<フォーカス関連関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncFo.js"))
        '<入力チェック関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncChk.js"))
        strScript.Append("</Script>")
        '//------------------------------------------
        '//　Css格納
        strScript.Append("<Style>")
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "CssPopup.css"))
        strScript.Append("</Style>")
        '//------------------------------------------
        '//　Script書込み
        lblScript.Text = strScript.ToString

        '------------------------------------------------------------------------------
        '<TODO>機能追加時に対象のプロジェクトを追加していく

        ''緊急出動一覧
        If Request.Path.LastIndexOf("SDLSTJAG00") >= 0 Then
            SDLSTJAG00_C = CType(Context.Handler, SDLSTJAG00.SDLSTJAG00)
            strListName = SDLSTJAG00_C.pListName
            hdnListCd.Value = SDLSTJAG00_C.pListCd
            hdnCode1.Value = SDLSTJAG00_C.pCode1
            hdnCode2.Value = SDLSTJAG00_C.pCode2          '2013/12/09 T.Ono add 監視改善2013
            hdnBackCode.Value = SDLSTJAG00_C.pBackCode
            hdnBackName.Value = SDLSTJAG00_C.pBackName
            hbdBackFocs.Value = SDLSTJAG00_C.pBackFocs
            hdnClear1.Value = SDLSTJAG00_C.pClearName
            hdnClear2.Value = SDLSTJAG00_C.pClearCode
        End If

        ' 2014/10/23 H.Hosoda add 2014改善開発 No11 START
        '出動会社担当者一覧
        If Request.Path.LastIndexOf("SDSYUJAG00") >= 0 Then
            SDSYUJAG00_C = CType(Context.Handler, SDSYUJAG00.SDSYUJAG00)
            strListName = SDSYUJAG00_C.pListName
            hdnListCd.Value = SDSYUJAG00_C.pListCd
            hdnCode1.Value = SDSYUJAG00_C.pCode1
            hdnCode2.Value = SDSYUJAG00_C.pCode2          '2013/12/09 T.Ono add 監視改善2013
            hdnBackCode.Value = SDSYUJAG00_C.pBackCode
            hdnBackName.Value = SDSYUJAG00_C.pBackName
            hdnBackNameOnly.Value = SDSYUJAG00_C.pBackNameOnly
            hbdBackFocs.Value = SDSYUJAG00_C.pBackFocs
            hdnClear1.Value = SDSYUJAG00_C.pClearName
            hdnClear2.Value = SDSYUJAG00_C.pClearCode
        End If
        ' 2014/10/23 H.Hosoda add 2014改善開発 No11 END

        '------------------------------------------------------------------------------
        '一覧タイトルの表示
        lblListName.Text = strListName
        'ウィンドウのタイトルの設定
        strMsg.Append("document.title='" & strListName & "'")
    End Sub
    '******************************************************************************
    '*　概　要：リストコード(種別)の値を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pListCd() As String
        Get
            Return hdnListCd.Value
        End Get
    End Property
    '******************************************************************************
    '*　概　要：コードを返すオブジェクトの名前値を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pBackCode() As String
        Get
            Return hdnBackCode.Value
        End Get
    End Property
    '******************************************************************************
    '*　概　要：名称を返すオブジェクトの名前値を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pBackName() As String
        Get
            Return hdnBackName.Value
        End Get
    End Property
    '******************************************************************************
    '*　概　要：名称のみを返すオブジェクトの名前値を渡すプロパティ　'2014/10/30 H.Hosoda add 2014改善開発 No11
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pBackNameOnly() As String
        Get
            Return hdnBackNameOnly.Value
        End Get
    End Property
    '******************************************************************************
    '*　概　要：フォーカスを返すオブジェクトの名前値を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pBackFocs() As String
        Get
            Return hbdBackFocs.Value
        End Get
    End Property
    '******************************************************************************
    '*　概　要：実行するＪＳ名を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pBackScript() As String
        Get
            Return hbdBackScript.Value
        End Get
    End Property
    '******************************************************************************
    '*　概　要：
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pPopType() As String
        Get
            '[1]:コードの返り値は表示用の「[CODE]：[NAME]」になります：デフォルト
            '[2]:コードの返り値は入力可能(顧客検索)用の「CODE」になります
            Return hdnPopType.Value
        End Get
    End Property
    '******************************************************************************
    '*　概　要：コードの値を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pCode1() As String
        Get
            Return hdnCode1.Value
        End Get
    End Property
    '******************************************************************************
    '*　概　要：コードの値を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pCode2() As String
        Get
            Return hdnCode2.Value
        End Get
    End Property
    '******************************************************************************
    '*　概　要：供給センターが変更された時にクリアするオブジェクトの名前値を渡すプロパティ１
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pClear1() As String
        Get
            Return hdnClear1.Value
        End Get
    End Property
    '******************************************************************************
    '*　概　要：供給センターが変更された時にクリアするオブジェクトの名前値を渡すプロパティ２
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pClear2() As String
        Get
            Return hdnClear2.Value
        End Get
    End Property
    '******************************************************************************
    '*　概　要：供給センターが変更された時にクリアするオブジェクトの名前値を渡すプロパティ１
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pClear3() As String
        Get
            Return hdnClear3.Value
        End Get
    End Property
    '******************************************************************************
    '*　概　要：供給センターが変更された時にクリアするオブジェクトの名前値を渡すプロパティ２
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pClear4() As String
        Get
            Return hdnClear4.Value
        End Get
    End Property
    '******************************************************************************
    '*　概　要：供給センターが変更された時にクリアするオブジェクトの名前値を渡すプロパティ１
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pClear5() As String
        Get
            Return hdnClear5.Value
        End Get
    End Property
    '******************************************************************************
    '*　概　要：供給センターが変更された時にクリアするオブジェクトの名前値を渡すプロパティ２
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pClear6() As String
        Get
            Return hdnClear6.Value
        End Get
    End Property
End Class
