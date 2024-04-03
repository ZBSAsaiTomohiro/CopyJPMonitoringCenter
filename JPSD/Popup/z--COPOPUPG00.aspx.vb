Option Explicit On 
Option Strict On

Imports Common

Imports System.Text

'******************************************************************************
' ポップアップ (呼び出し部)
'******************************************************************************

Public Class COPOPUPG00
    Inherits System.Web.UI.Page
    Protected WithEvents lblScript As System.Web.UI.WebControls.Label
    Protected WithEvents hdnKensaku As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hdnListCd As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hdnBackCode As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hdnBackName As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hbdBackFocs As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents lblListName As System.Web.UI.WebControls.Label
    Protected WithEvents hdnPopType As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hdnCode1 As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hdnCode2 As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hdnClear1 As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hdnClear2 As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hdnClear3 As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hdnClear4 As System.Web.UI.HtmlControls.HtmlInputHidden
    'システム項目
    Protected strListName As String

    '******************************************************************************
    ' HttpHeader
    '******************************************************************************
    Protected HttpHeaderC As New CHttpHeader
    Protected WithEvents hbdBackScript As System.Web.UI.HtmlControls.HtmlInputHidden

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
    Protected MSTANJAG00_C As MSTANJAG00.MSTANJAG00         '担当者マスタ
    Protected MSPULJAG00_C As MSPULJAG00.MSPULJAG00         'プルダウンマスタ
    Protected KETAIJAG00_C As KETAIJAG00.KETAIJAG00         '対応入力
    Protected KERUIJOG00_C As KERUIJOG00.KERUIJOG00         '累積情報一覧
    Protected KEKEKJAG00_C As KEKEKJAG00.KEKEKJAG00         '対応結果一覧
    Protected MSKOSJAG00_C As MSKOSJAG00.MSKOSJAG00         '顧客検索

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
        strScript.Append(cscript1.mWriteScript(MyBase.MapPath("../../../Popup/") & "COPOPUPG00.js"))
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
        ''担当者マスタ
        If Request.Path.LastIndexOf("MSTANJAG00") >= 0 Then
            MSTANJAG00_C = CType(Context.Handler, MSTANJAG00.MSTANJAG00)
            strListName = MSTANJAG00_C.pListName
            hdnListCd.Value = MSTANJAG00_C.pListCd
            hdnCode1.Value = MSTANJAG00_C.pCode1
            hdnBackCode.Value = MSTANJAG00_C.pBackCode
            hdnBackName.Value = MSTANJAG00_C.pBackName
            hbdBackFocs.Value = MSTANJAG00_C.pBackFocs
            hdnClear1.Value = MSTANJAG00_C.pClear1
            hdnClear2.Value = MSTANJAG00_C.pClear2
        End If
        ''プルダウンマスタ
        If Request.Path.LastIndexOf("MSPULJAG00") >= 0 Then
            MSPULJAG00_C = CType(Context.Handler, MSPULJAG00.MSPULJAG00)
            strListName = MSPULJAG00_C.pListName
            hdnListCd.Value = MSPULJAG00_C.pListCd
            hdnCode1.Value = MSPULJAG00_C.pCode1
            hdnBackCode.Value = MSPULJAG00_C.pBackCode
            hdnBackName.Value = MSPULJAG00_C.pBackName
            hbdBackFocs.Value = MSPULJAG00_C.pBackFocs
            hdnClear1.Value = MSPULJAG00_C.pClear1
        End If
        '対応入力
        If Request.Path.LastIndexOf("KETAIJAG00") >= 0 Then
            KETAIJAG00_C = CType(Context.Handler, KETAIJAG00.KETAIJAG00)
            strListName = KETAIJAG00_C.pListName
            hdnListCd.Value = KETAIJAG00_C.pListCd
            hdnCode1.Value = KETAIJAG00_C.pCode1
            hdnBackCode.Value = KETAIJAG00_C.pBackCode
            hdnBackName.Value = KETAIJAG00_C.pBackName
            hbdBackFocs.Value = KETAIJAG00_C.pBackFocs
            hbdBackScript.Value = KETAIJAG00_C.pBackScript
            hdnClear1.Value = KETAIJAG00_C.pClear1
            hdnClear2.Value = KETAIJAG00_C.pClear2
            hdnClear3.Value = KETAIJAG00_C.pClear3
            hdnClear4.Value = KETAIJAG00_C.pClear4
        End If
        ''累積情報一覧
        If Request.Path.LastIndexOf("KERUIJOG00") >= 0 Then
            KERUIJOG00_C = CType(Context.Handler, KERUIJOG00.KERUIJOG00)
            strListName = KERUIJOG00_C.pListName
            hdnListCd.Value = KERUIJOG00_C.pListCd
            hdnCode1.Value = KERUIJOG00_C.pCode1
            hdnCode2.Value = KERUIJOG00_C.pCode2
            hdnBackCode.Value = KERUIJOG00_C.pBackCode
            hdnBackName.Value = KERUIJOG00_C.pBackName
            hbdBackFocs.Value = KERUIJOG00_C.pBackFocs
            hdnClear1.Value = Convert.ToString(KERUIJOG00_C.pClearCode.Split(Convert.ToChar(",")).GetValue(0))
            hdnClear2.Value = Convert.ToString(KERUIJOG00_C.pClearName.Split(Convert.ToChar(",")).GetValue(0))
            If KERUIJOG00_C.pClearCode.Split(Convert.ToChar(",")).Length > 1 Then
                hdnClear3.Value = Convert.ToString(KERUIJOG00_C.pClearCode.Split(Convert.ToChar(",")).GetValue(1))
                hdnClear4.Value = Convert.ToString(KERUIJOG00_C.pClearName.Split(Convert.ToChar(",")).GetValue(1))
            End If
        End If
        ''対応変更一覧
        If Request.Path.LastIndexOf("KEKEKJAG00") >= 0 Then
            KEKEKJAG00_C = CType(Context.Handler, KEKEKJAG00.KEKEKJAG00)
            strListName = KEKEKJAG00_C.pListName
            hdnListCd.Value = KEKEKJAG00_C.pListCd
            hdnCode1.Value = KEKEKJAG00_C.pCode1
            hdnBackCode.Value = KEKEKJAG00_C.pBackCode
            hdnBackName.Value = KEKEKJAG00_C.pBackName
            hbdBackFocs.Value = KEKEKJAG00_C.pBackFocs
            hdnClear1.Value = KEKEKJAG00_C.pClear1
            hdnClear2.Value = KEKEKJAG00_C.pClear2
        End If
        ''顧客検索
        If Request.Path.LastIndexOf("MSKOSJAG00") >= 0 Then
            MSKOSJAG00_C = CType(Context.Handler, MSKOSJAG00.MSKOSJAG00)
            strListName = MSKOSJAG00_C.pListName
            hdnListCd.Value = MSKOSJAG00_C.pListCd
            hdnCode1.Value = MSKOSJAG00_C.pCode1
            hdnBackCode.Value = MSKOSJAG00_C.pBackCode
            hdnBackName.Value = MSKOSJAG00_C.pBackName
            hbdBackFocs.Value = MSKOSJAG00_C.pBackFocs
            hdnClear1.Value = MSKOSJAG00_C.pClear1
            hdnClear2.Value = MSKOSJAG00_C.pClear2
        End If

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
End Class
