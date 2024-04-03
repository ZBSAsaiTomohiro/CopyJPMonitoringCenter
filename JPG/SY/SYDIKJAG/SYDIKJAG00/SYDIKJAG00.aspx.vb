'***********************************************
'緊急時監視業務代行設定  メイン画面
'***********************************************
Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common
Imports JPG.Common.log  '：参照設定でCOCOLOGC00を設定する

Imports System.Text
Imports System.Configuration

Partial Class SYDIKJAG00
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

    '<TODO>宣言共通仕様
    '******************************************************************************
    ' ScriptMessage
    '******************************************************************************
    Private strMsg As New StringBuilder("")
    Dim strKANSCD As String         '監視センターコード
    Dim strDAIKOKANSCD As String    '代行監視センターコード

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

        '//------------------------------------------
        '//　認証処理
        '<TODO>：使用可能権限を指定する
        '[監視代行]使用可能権限(運:○/営:×/監:○/出:×)
        AuthC.fncAuthCheck(Server, AuthC.pGROUP_UNKOU & "," & AuthC.pGROUP_KANSHI)

        '更新処理
        If hdnKensaku.Value = "SYDIKJJG00" Then
            Server.Transfer("SYDIKJJG00.aspx")
        End If

        '//-----------------------------------------------
        '//初めて開いた時だけ実行される
        If MyBase.IsPostBack = False Then
            'POSTデータの取得変数の初期化
            Call fncGetPostIni()
        Else
            'POSTデータの取得
            Call fncGetPost()
        End If
        '//-----------------------------------------------

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
             MyBase.MapPath("../../../SY/SYDIKJAG/SYDIKJAG00/") & "SYDIKJAG00.js"))
        '<フォーカス関連関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncFo.js"))

        strScript.Append("</Script>")
        '//------------------------------------------
        '//　Css格納
        strScript.Append("<Style>")
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "CssData.css"))
        strScript.Append("</Style>")
        '//------------------------------------------
        '//　Script書込み
        lblScript.Text = strScript.ToString

        '//------------------------------------------
        'コンボボックスの作成
        '<TODO>コンボボックスの作成FunctionをCallする
        Call fncCreateCombo()
        '//------------------------------------------

        '//------------------------------------------------------------------------------
        If MyBase.IsPostBack = False Then
            '//--------------------------------------
            '//　初めて開いた時だけ実行される

            '//--------------------------------------
            '初期表示として必要なコントロールの設定を行います
            Call fncIni_format()    '//値の初期化

            '<TODO>フォーカスをセットする
            strMsg.Append("Form1.cboKANSCD.focus();")

        Else
            '//--------------------------------------
            '//２回目以降実行される
            '//--------------------------------------

            '<TODO>コンボボックス使用時、値選択のFunctionをCallする
            Call fncSelectCombo()
        End If

        '//-------------------------------------------------
        '<TODO>自分の画面IDをHIDDENのhdnMyAspxに書き込む（システム共通）
        hdnMyAspx.Value = "SYDIKJAG00"
        '//-------------------------------------------------

    End Sub

    '******************************************************************************
    '*　概　要：コンボボックスの選択
    '*　備　考：
    '******************************************************************************
    Private Sub fncSelectCombo()
        Dim list As New ListItem
        '//<TODO>コンボボックスを選択状態にする

        If strKANSCD <> "" Then
            list = cboKANSCD.Items.FindByValue(strKANSCD)
            cboKANSCD.SelectedIndex = cboKANSCD.Items.IndexOf(list)
        End If
        If strDAIKOKANSCD <> "" Then
            list = cboDAIKOKANSCD.Items.FindByValue(strDAIKOKANSCD)
            cboDAIKOKANSCD.SelectedIndex = cboDAIKOKANSCD.Items.IndexOf(list)
        End If

    End Sub

    '******************************************************************************
    '* POSTデータの取得変数の初期化
    '******************************************************************************
    Private Sub fncGetPostIni()
        '//--------------------------------------------------------------------------
        '<TODO>画面コントロール内容を格納した変数を初期化する
        strKANSCD = ""
        strDAIKOKANSCD = ""
    End Sub

    '******************************************************************************
    '* HTTPPOSTデータ取得
    '******************************************************************************
    Private Sub fncGetPost()
        '//--------------------------------------------------------------------------
        '<TODO>画面コントロールの内容を変数に格納する
        '//     コンボボックスのXYZや日付の変換等はこの箇所で行う

        strKANSCD = Request.Form("cboKANSCD")
        strDAIKOKANSCD = Request.Form("cboDAIKOKANSCD")
    End Sub

    '******************************************************************************
    '* 各コントロールの設定値の初期化
    '******************************************************************************
    Private Sub fncIni_format()

        'コンボ作成
        Call fncCombo_Creatr_KANSI_CD()         '監視センターコンボ
        Call fncCombo_Create_DAI_KANSI_CD()     '代行監視センターコンボ

        cboKANSCD.SelectedIndex = 0
        cboDAIKOKANSCD.SelectedIndex = 0

    End Sub

    '******************************************************************************
    '*　概　要：コンボボックス作成
    '*　備　考：
    '******************************************************************************
    Private Sub fncCreateCombo()
        '//--------------------------------------------------------------------------
        '<TODO>コンボボックスを作成するファンクションをCallする
        Call fncCombo_Creatr_KANSI_CD()         '監視センターコンボ
        Call fncCombo_Create_DAI_KANSI_CD()     '代行監視センターコンボ
    End Sub

    '******************************************************************************
    'コンボボックスの作成
    '******************************************************************************
    Private Sub fncCombo_Creatr_KANSI_CD()
        '//監視センターコンボ
        cboKANSCD.pComboTitle = True
        cboKANSCD.pNoData = False
        cboKANSCD.pType = "KANSICENTER"

        '--- ↓2005/04/19 DEL　Falcon↓ -----------------
        '東北・中日本・西日本の監視センターが出力
        'Dim strALLCENTERCD As String = "" & _
        '    ConfigurationSettings.AppSettings("KANSHICD_TOUHOKU") & "," & _
        '    ConfigurationSettings.AppSettings("KANSHICD_NAKANIHON") & "," & _
        '    ConfigurationSettings.AppSettings("KANSHICD_NISHINIHON")
        '--- ↑2005/04/19 DEL Falcon↑ ------------------

        '--- ↓2005/04/19 MOD　Falcon↓ -----------------
        Dim strALLCENTERCD As String = ConfigurationSettings.AppSettings("GROUP_KANSHICD")
        '--- ↑2005/04/19 MOD Falcon↑ ------------------

        cboKANSCD.pAllCenterCd = strALLCENTERCD
        cboKANSCD.mMakeCombo()
    End Sub

    Private Sub fncCombo_Create_DAI_KANSI_CD()
        '//代行監視センターコンボ
        cboDAIKOKANSCD.pComboTitle = True
        cboDAIKOKANSCD.pNoData = False
        cboDAIKOKANSCD.pType = "KANSICENTER"

        '--- ↓2005/04/19 DEL　Falcon↓ -----------------
        '東北・中日本・西日本の監視センターが出力
        'Dim strALLCENTERCD As String = "" & _
        '    ConfigurationSettings.AppSettings("KANSHICD_TOUHOKU") & "," & _
        '    ConfigurationSettings.AppSettings("KANSHICD_NAKANIHON") & "," & _
        '    ConfigurationSettings.AppSettings("KANSHICD_NISHINIHON")
        '--- ↑2005/04/19 DEL Falcon↑ ------------------

        '--- ↓2005/04/19 MOD　Falcon↓ -----------------
        Dim strALLCENTERCD As String = ConfigurationSettings.AppSettings("GROUP_KANSHICD")
        '--- ↑2005/04/19 MOD Falcon↑ ------------------

        cboDAIKOKANSCD.pAllCenterCd = strALLCENTERCD
        cboDAIKOKANSCD.mMakeCombo()
    End Sub

    '*****************************************************************************
    '*代行設定ボタン押下時の処理
    '*****************************************************************************
    Private Sub btnSET_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSET.ServerClick

        Dim strCNT As String
        Dim dbData As DataSet

        Try
            dbData = fncDataSelect()
            strCNT = Convert.ToString(dbData.Tables(0).Rows(0).Item("CNT"))
            dbData.Dispose()

            If strCNT = "0" Then
                strMsg.Append("strRes=confirm('代行設定を行うとシステム全体の業務に影響が及びます。代行設定を行いますか？');")
                strMsg.Append("if (strRes==false){")
                strMsg.Append("Form1.btnSET.focus();")
                strMsg.Append("} else {")
                strMsg.Append("fncDispRoc();")
                strMsg.Append("doSubmit('SYDIKJJG00');")
                strMsg.Append("}")
            Else
                strMsg.Append("strRes=confirm('既に代行設定が行われています。代行設定を行いますか？');")
                strMsg.Append("if (strRes==false){")
                strMsg.Append("Form1.btnSET.focus();")
                strMsg.Append("} else {")
                strMsg.Append("fncDispRoc();")
                strMsg.Append("doSubmit('SYDIKJJG00');")
                strMsg.Append("}")
            End If

        Catch ex As Exception
            Dim ErrMsgC As New CErrMsg
            strMsg.Append("alert('システムエラー：" & ErrMsgC.mGetArtMsg(ex.ToString) & "');")
        End Try
    End Sub

    '*****************************************************************************
    '*代行解除ボタン押下時の処理
    '*****************************************************************************
    Private Sub btnCANCEL_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCANCEL.ServerClick

        Dim strCNT As String
        Dim strRecMsg As String
        Dim dbData As DataSet

        Try
            dbData = fncDataSelect()
            strCNT = Convert.ToString(dbData.Tables(0).Rows(0).Item("CNT"))
            dbData.Dispose()

            If strCNT = "0" Then
                '代行解除を行うデータなし
                strRecMsg = "代行設定されていません"
                strMsg.Append("alert('" & strRecMsg & "');")

                '//----------------------------------
                '<TODO>フォーカスをセットする
                strMsg.Append("Form1.cboKANSCD.focus();")
            Else
                '更新処理
                strMsg.Append("fncDispRoc();")
                strMsg.Append("doSubmit('SYDIKJJG00');")
            End If

        Catch ex As Exception
            Dim ErrMsgC As New CErrMsg
            strMsg.Append("alert('システムエラー：" & ErrMsgC.mGetArtMsg(ex.ToString) & "');")
        End Try

    End Sub

    '******************************************************************************
    '*　概　要：監視センターコード
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pKANSCD() As String
        Get
            Return Request.Form("cboKANSCD")
        End Get
    End Property

    '******************************************************************************
    '*　概　要：代行監視センターコード
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pDAIKOKANSCD() As String
        Get
            Return Request.Form("cboDAIKOKANSCD")
        End Get
    End Property

    '******************************************************************************
    '* データの検索を行います。
    '******************************************************************************
    Private Function fncDataSelect() As DataSet

        '//------------------------------------------
        '//<TODO>Select文の作成
        Dim SQLC As New SYDIKJAG00CCSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet

        strSQL.Append("SELECT ")
        strSQL.Append("COUNT(*) AS CNT ")
        strSQL.Append("FROM  S01_DAIKO ")
        strSQL.Append("WHERE KANSCD  = :KANSCD ")

        '条件をバインドする
        SqlParamC.fncSetParam("KANSCD", True, strKANSCD)

        dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)
        Return dbData

    End Function

End Class
