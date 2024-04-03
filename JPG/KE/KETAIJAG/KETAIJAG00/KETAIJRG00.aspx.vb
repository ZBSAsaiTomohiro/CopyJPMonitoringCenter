'***********************************************
'対応履歴一覧
'***********************************************
Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common

Imports System.Text

Partial Class KETAIJRG00
    Inherits System.Web.UI.Page

    '不明項目１質問中
    '不明項目２質問中

    Private strExecFlg As String

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

        '//------------------------------------------
        '//　認証処理
        '<TODO>：使用可能権限を指定する
        '[プルダウンマスタ]使用可能権限(運:○/営:×/監:○/出:×)
        '2005/12/03 NEC UPDATE START
        '[対応入力]使用可能権限(運:○/営:○/監:○/出:×)
        'AuthC.fncAuthCheck(Server, AuthC.pGROUP_UNKOU & "," & AuthC.pGROUP_KANSHI)
        AuthC.fncAuthCheck(Server, AuthC.pGROUP_UNKOU & "," & AuthC.pGROUP_KANSHI & "," & AuthC.pGROUP_EIGYOU)
        '2005/12/03 NEC UPDATE START

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
        '<独自スクリプト>
        strScript.Append(cscript1.mWriteScript( _
             MyBase.MapPath("../../../KE/KETAIJAG/KETAIJAG00/") & "KETAIJRG00.js"))
        '<フォーカス関連関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncFo.js"))
        '<入力チェック関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncChk.js"))
        '<電話番号チェック関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncTel.js"))
        '<数値関連関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncNumChk.js"))
        strScript.Append("</Script>")
        '//------------------------------------------
        '//　Css格納
        strScript.Append("<Style>")
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "CssSmall.css"))
        strScript.Append("</Style>")
        '//------------------------------------------
        '//　Script書込み
        lblScript.Text = strScript.ToString


        '//------------------------------------------------------------------------------
        If MyBase.IsPostBack = False Then
            '//--------------------------------------
            '//初めて開いた時だけ実行される

            '//------------------------------------------
            '出力するキーをHIDDENに格納する
            Dim KETAIJAG00C As KETAIJAG00
            KETAIJAG00C = CType(Context.Handler, KETAIJAG00)

            hdnRIREKI_KURACD.Value = KETAIJAG00C.pPRAM_CLI
            hdnRIREKI_ACBCD.Value = KETAIJAG00C.pPRAM_JASS
            hdnRIREKI_USER_CD.Value = KETAIJAG00C.pPRAM_JUYOKA

            '//------------------------------------------
            '遷移元情報画面の世帯主情報を出力

            '--- ↓2005/05/19 MOD Falcon↓ ---  //常にハイフンは付加しない
            'If KETAIJAG00C.pPRAM_JASS.Length = 0 Or KETAIJAG00C.pPRAM_JUYOKA.Length = 0 Then
            'どちらかが空の場合ハイフンは付加しない
            txtJUYOKA.Text = KETAIJAG00C.pPRAM_JASS & KETAIJAG00C.pPRAM_JUYOKA
            'Else
            '両方入っている場合ハイフンを付加する
            'txtJUYOKA.Text = KETAIJAG00C.pPRAM_JASS & "-" & KETAIJAG00C.pPRAM_JUYOKA
            'End If
            '--- ↑2005/05/19 MOD Falcon↑ ---

            txtJUYOKANAME.Text = KETAIJAG00C.pPRAM_JUYOKANAME

            '//------------------------------------------
            'データの出力を行う
            strMsg.Append("btnFirst_onclick();")

        End If

    End Sub

    '******************************************************************************
    '*　概　要：処理実行制御値を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pExecFlag() As String
        Get
            Return strExecFlg
        End Get
    End Property
    '******************************************************************************
    Public ReadOnly Property pRownum() As String
        Get
            Return hdnRownum.Value
        End Get
    End Property
    '******************************************************************************
    Public ReadOnly Property pRIREKI_CLI() As String
        Get
            Return hdnRIREKI_KURACD.Value
        End Get
    End Property
    '******************************************************************************
    Public ReadOnly Property pRIREKI_JASS() As String
        Get
            Return hdnRIREKI_ACBCD.Value
        End Get
    End Property
    '******************************************************************************
    Public ReadOnly Property pRIREKI_JUYOKA() As String
        Get
            Return hdnRIREKI_USER_CD.Value
        End Get
    End Property

    '******************************************************************************
    '*　概　要：処理実行制御値を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Private Sub btnFirst_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFirst.ServerClick
        strExecFlg = "DATAFIRST"
        Server.Transfer("KETAIJSG00.aspx")
    End Sub
    '******************************************************************************
    Private Sub btnPre_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPre.ServerClick
        strExecFlg = "DATAPRE"
        Server.Transfer("KETAIJSG00.aspx")
    End Sub
    '******************************************************************************
    Private Sub btnNex_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNex.ServerClick
        strExecFlg = "DATANEX"
        Server.Transfer("KETAIJSG00.aspx")
    End Sub
    '******************************************************************************
    Private Sub btnEnd_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnd.ServerClick
        strExecFlg = "DATAEND"
        Server.Transfer("KETAIJSG00.aspx")
    End Sub
    '******************************************************************************
End Class
