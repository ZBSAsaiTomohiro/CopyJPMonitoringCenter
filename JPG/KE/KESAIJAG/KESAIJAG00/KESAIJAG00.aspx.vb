'***********************************************
' 災害対応帳票
'***********************************************
' 変更履歴
' 2020/01/06 T.Ono 新規作成
' 2021/10/01 saka  2021年度監視改善⑥感震器遮断警報出力（未処理出力）列追加

Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common
Imports JPG.Common.log

Imports System.Text

Partial Class KESAIJAG00
    Inherits System.Web.UI.Page

    'ボタン

    'テキストボックス

    'コンボボックス

    'チェックボックス

    '非表示コントロール

    Protected WithEvents dbData As System.Data.DataSet

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
    ' 日付クラス
    '******************************************************************************
    Protected DateFncC As New CDateFnc

    '******************************************************************************
    ' 時刻クラス
    '******************************************************************************
    Protected TimeFncC As New CTimeFnc

    '******************************************************************************
    ' クッキー
    '******************************************************************************
    Protected ConstC As New CConst

    '******************************************************************************
    ' ScriptMessage
    '******************************************************************************
    Private strMsg As New StringBuilder("")      '//<script>は必要なし
    Dim strTSADCD As String         '作動原因コード
    Dim strTSADNM As String         '作動原因名称


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
    Private Sub Page_Load(ByVal sender As System.Object, _
                                            ByVal e As System.EventArgs) Handles MyBase.Load
        '.NETの仕様変更により、ReadOnly属性をASPXでつけると、サーバ側で値の参照ができなくなるため、VB側でAttributeでつける
        If MyBase.IsPostBack = False Then
            txtKURACD_From.Attributes.Add("ReadOnly", "true")
            txtKURACD_To.Attributes.Add("ReadOnly", "true")
            txtJACD_From.Attributes.Add("ReadOnly", "true")
            txtJACD_To.Attributes.Add("ReadOnly", "true")
        End If

        '//------------------------------------------
        '//　HTTPヘッダを送信
        HttpHeaderC.mNoCache(Response)

        '//------------------------------------------
        '//　認証クラスのインスタンス生成
        AuthC = New CAuthenticate(Request, Response)

        '//------------------------------------------
        '//　認証処理
        '<TODO>：使用可能権限を指定する
        '[災害対応帳票]使用可能権限(運:○/営:○/監:△/出:×)
        AuthC.fncAuthCheck(Server, AuthC.pGROUP_UNKOU & "," & AuthC.pGROUP_KANSHI & "," & AuthC.pGROUP_EIGYOU)

        '//------------------------------------------
        '//ポップアップ出力
        If hdnKensaku.Value = "COPOPUPG00" Then
            Server.Transfer("../../../Popup/COPOPUPG00.aspx")
        End If
        '//カレンダーの出力
        If hdnKensaku.Value = "COCALDRG00" Then
            Server.Transfer("../../../Popup/COCALDRG00.aspx")
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
             MyBase.MapPath("../../../KE/KESAIJAG/KESAIJAG00/") & "KESAIJAG00.js"))
        '<フォーカス関連関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncFo.js"))
        '<日付関連関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncDate.js"))
        '<時間関連関数> 
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncTime.js"))
        strScript.Append("</Script>")
        '//------------------------------------------
        '//　Css格納
        strScript.Append("<Style>")
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "CssData.css"))
        strScript.Append("</Style>")
        '//------------------------------------------
        '//　Script書込み
        lblScript.Text = strScript.ToString

        'コンボボックスの作成
        '<TODO>コンボボックスの作成FunctionをCallする
        Call fncCreateCombo()

        '//------------------------------------------------------------------------------
        If MyBase.IsPostBack = False Then
            '//--------------------------------------
            '//　初めて開いた時だけ実行される

            '//--------------------------------------------------------------------------
            '<TODO>初期表示として必要なコントロールの設定を行います
            '      例)画面初期表示時は●●●が選択されていること……等の処理
            '//--------------------------------------------------------------------------
            '　処理結果による画面の状態の設定------------------------
            '　画面を【検索前状態】にする（入力データはそのまま遷移させる）
            '//-------------------------------------------

            '初期表示として必要なコントロールの設定を行います
            'コンボボックスの作成
            Call fncIni_format()    '//値の初期化

            '対象期間日に当日日付を表示
            txtTRGDATE_From.Text = DateTime.Today.ToString("yyyy/MM/dd")
            txtTRGDATE_To.Text = DateTime.Today.ToString("yyyy/MM/dd")

            '//フォーカスをセットする
            strMsg.Append("Form1.btnKURACD_From.focus();")
        Else
            '//--------------------------------------
            '//　２回目以降実行される
            '//--------------------------------------------------------------------------
            '//※画面表示するコンボボックスは各最終イベント/メソッドでCALLします
            '//--------------------------------------------------------------------------
            '<TODO>コンボボックス使用時、値選択のFunctionをCallする
            Call fncSelectCombo()

        End If

        '//-------------------------------------------------
        '<TODO>自分の画面IDをHIDDENのhdnMyAspxに書き込む（システム共通）
        hdnMyAspx.Value = "KESAIJAG00"
        '//-------------------------------------------------

    End Sub

    '******************************************************************************
    '*　概　要：コンボボックスの選択
    '*　備　考：
    '******************************************************************************
    Private Sub fncSelectCombo()
        Dim list As New ListItem
        '//<TODO>コンボボックスを選択状態にする

        '//作動原因
        If strTSADCD <> "" Then
            list = cboTSADCD.Items.FindByValue(strTSADCD)
            cboTSADCD.SelectedIndex = cboTSADCD.Items.IndexOf(list)
            strTSADNM = list.ToString
        End If

    End Sub

    '******************************************************************************
    '* POSTデータの取得変数の初期化
    '******************************************************************************
    Private Sub fncGetPostIni()
        '//--------------------------------------------------------------------------
        '<TODO>画面コントロール内容を格納した変数を初期化する
        strTSADCD = ""
        strTSADNM = ""
        '//-----------------------------------------------
        hdnKURACD_From.Value = ""
        hdnKURACD_To.Value = ""

        txtKURACD_From.Text = ""
        txtKURACD_To.Text = ""

        hdnJACD_From.Value = ""
        hdnJACD_To.Value = ""
        txtJACD_From.Text = ""
        txtJACD_To.Text = ""

        hdnJACD_From_CLI.Value = ""
        hdnJACD_To_CLI.Value = ""

        txtTRGDATE_From.Text = ""
        txtTRGDATE_To.Text = ""

    End Sub

    '******************************************************************************
    '* HTTPPOSTデータ取得
    '******************************************************************************
    Private Sub fncGetPost()
        '//--------------------------------------------------------------------------
        '<TODO>画面コントロールの内容を変数に格納する
        '//     コンボボックスのXYZや日付の変換等はこの箇所で行う
        strTSADCD = Request.Form("cboTSADCD")
    End Sub

    '******************************************************************************
    '* 各コントロールの設定値の初期化
    '******************************************************************************
    Private Sub fncIni_format()

        'コンボ作成
        Call fncCombo_Create_Sadougen()         '作動原因コンボ

        '初期値を指定
        cboTSADCD.SelectedValue = "59"          '59：自然災害

    End Sub

    '******************************************************************************
    '*　概　要：コンボボックス作成
    '*　備　考：
    '******************************************************************************
    Private Sub fncCreateCombo()
        '//--------------------------------------------------------------------------
        '<TODO>コンボボックスを作成するファンクションをCallする
        Call fncCombo_Create_Sadougen()         '作動原因
    End Sub
    Private Sub fncCombo_Create_Sadougen()
        '//作動原因
        cboTSADCD.pComboTitle = True
        cboTSADCD.pNoData = False
        cboTSADCD.pType = "SADOUGEN"
        cboTSADCD.mMakeCombo()
    End Sub

    '******************************************************************************
    ' 明細表出力(チェックつき)
    '******************************************************************************
    Private Sub btnSelect_ServerClick(ByVal sender As System.Object, _
                                    ByVal e As System.EventArgs) Handles btnSelect.ServerClick
        Dim strRec As String
        Dim KETAISYG00C As New KETAISYG00KETAISYW00.KETAISYW00

        Dim strSTKBN1 As String
        Dim strSTKBN2 As String

        Dim strPGKBN1 As String
        Dim strPGKBN2 As String
        Dim strPGKBN3 As String

        Dim strOUTKBN As String
        Dim strKIKANKBN As String
        Dim strHOKBN As String
        Dim strOUTLIST As String

        '//　認証クラスのインスタンス生成
        AuthC = New CAuthenticate(Request, Response)

        '発生区分取得
        strSTKBN1 = "1"      '電話
        strSTKBN2 = "2"      '警報

        '対応区分取得
        strPGKBN1 = ""
        strPGKBN2 = ""
        strPGKBN3 = ""
        If chkTAI_TEL.Checked = True Then
            strPGKBN1 = "1"      '電話
        End If

        If chkTAI_SHU.Checked = True Then
            strPGKBN2 = "2"      '出動
        End If

        If chkTAI_JUF.Checked = True Then
            strPGKBN3 = "3"      '重複
        End If

        '出力対象取得
        strOUTKBN = "1"         '通常

        '対象期間区分取得                   '2021年度監視改善⑥未処理感震器出力(明細帳票も受信日出力に対応)2021/10/01
        If rdoKIKAN1.Checked = True Then
            strKIKANKBN = "1"       '対応完了日
        Else
            strKIKANKBN = "2"     '受信日
        End If

        '法令区分取得
        strHOKBN = "1"          '総合計

        '出力項目取得
        strOUTLIST = "3"        '日次報告と同じ(出動会社なし)

        '2020/09/15 T.Ono add 監視改善2020 
        '個人情報
        If rdoKOJIN1.Checked = True Then
            strOUTLIST = "4"    '個人情報なし　かつ　日次報告と同じ(出動会社なし)
        End If


        Dim strRecMsg As String = ""

        strRec = KETAISYG00C.mExcel(
                         Me.Session.SessionID,
                         "",
                         "",
                         strSTKBN1,
                         strSTKBN2,
                         strPGKBN1,
                         strPGKBN2,
                         strPGKBN3,
                         DateFncC.mHenkanGet(txtTRGDATE_From.Text),
                         DateFncC.mHenkanGet(txtTRGDATE_To.Text),
                         hdnKURACD_From.Value.Trim,
                         hdnKURACD_To.Value.Trim,
                         hdnJACD_From.Value.Trim,
                         hdnJACD_From_CLI.Value.Trim,
                         hdnJACD_To.Value.Trim,
                         hdnJACD_To_CLI.Value.Trim,
                         "",
                         "",
                         strOUTKBN,
                         strKIKANKBN,
                         TimeFncC.mHenkanGet(txtTRGTIME_From.Text),
                         TimeFncC.mHenkanGet(txtTRGTIME_To.Text),
                         strHOKBN,
                         strOUTLIST,
                         "",
                         strTSADCD,
                         strTSADNM
                         )


        If strRec.Substring(0, 5) = "ERROR" Then
            'エラーであればブラウザにメッセージ表示
            Dim ErrMsgC As New CErrMsg
            strRecMsg = "システムエラー：" & ErrMsgC.mGetArtMsg(strRec)
            strMsg.Append("alert('" & strRecMsg & "');")

        ElseIf strRec.Substring(0, 5) = "DATA0" Then
            'データが0件の場合
            strRecMsg = "対象データが存在しません"
            strMsg.Append("alert('" & strRecMsg & "');")
            strMsg.Append("Form1.btnSelect.focus();")

        Else
            '「開く、保存」のダイヤログが出るようにHTTPヘッダに追加
            'ファイル名変更
            HttpHeaderC.mDownLoadXLS(Response, "対応結果明細.xls")

            ''ファイル送信
            Response.ContentType = "application/msexcel" '「ファイルを開く」際のエラー対策
            Response.WriteFile(strRec)

            Response.End()

            strRecMsg = "OK"
        End If

        strRec = strRecMsg
        '-------------------------------------------------
        '//ＡＰログ書き込み
        Dim LogC As New CLog
        Dim strRecLog As String
        strRecLog = LogC.mAPLog(Me.Session.SessionID, AuthC.pUSERNAME, AuthC.pIPADDRESS, hdnMyAspx.Value, "4", strRec, Request.Form)
        If strRecLog <> "OK" Then
            Dim errmsgc As New CErrMsg
            strMsg.Append("alert('システムエラー：" & errmsgc.mGetArtMsg(strRecLog) & "');")
        End If
    End Sub
    '******************************************************************************
    ' 集計表出力
    '******************************************************************************
    Private Sub btnOutput_ServerClick(ByVal sender As System.Object,
                                      ByVal e As System.EventArgs) Handles btnOutput.ServerClick

        Dim strRec As String
        Dim KESAIJAG00C As New KESAIJAG00KESAIJAW00.KESAIJAW00

        Dim strPGKBN1 As String
        Dim strPGKBN2 As String
        Dim strPGKBN3 As String

        Dim strKIKANKBN As String '2021/10/01 2021年度監視改善⑥地震などの災害時に（自動と手動で）登録される未処理データを出力する災害対応帳票

        '//　認証クラスのインスタンス生成
        AuthC = New CAuthenticate(Request, Response)

        '対応区分取得
        strPGKBN1 = ""
        strPGKBN2 = ""
        strPGKBN3 = ""
        If chkTAI_TEL.Checked = True Then
            strPGKBN1 = "1"      '電話
        End If

        If chkTAI_SHU.Checked = True Then
            strPGKBN2 = "2"      '出動
        End If

        If chkTAI_JUF.Checked = True Then
            strPGKBN3 = "3"      '重複
        End If

        If rdoKIKAN1.Checked = True Then                             '2021/10/01 2021年度監視改善⑥Startメインは感震器遮断を未処理でも出力させる
            strKIKANKBN = "1"     '対応完了日(災害帳票)
        Else
            strKIKANKBN = "2"     '受信日(未処理データも出力させる)
        End If                                                       '2021/10/01 2021年度監視改善⑥End

        Dim strRecMsg As String = ""

        strRec = KESAIJAG00C.mExcel(
                         Me.Session.SessionID,
                         hdnKURACD_From.Value.Trim,
                         hdnKURACD_To.Value.Trim,
                         hdnJACD_From.Value.Trim,
                         hdnJACD_From_CLI.Value.Trim,
                         hdnJACD_To.Value.Trim,
                         hdnJACD_To_CLI.Value.Trim,
                         DateFncC.mHenkanGet(txtTRGDATE_From.Text),
                         DateFncC.mHenkanGet(txtTRGDATE_To.Text),
                         TimeFncC.mHenkanGet(txtTRGTIME_From.Text),
                         TimeFncC.mHenkanGet(txtTRGTIME_To.Text),
                         strPGKBN1,
                         strPGKBN2,
                         strPGKBN3,
                         strTSADCD,
                         strTSADNM,       '2021/10/01 2021年度監視改善⑥感震器遮断用に未処理も出力、UPDsaka出力するエクセルデザインを変えるため
                         strKIKANKBN      '2021/10/01 対応完了日のみから受信日（未処理出力用に）もラジオ選択に追加した
                         )


        If strRec.Substring(0, 5) = "ERROR" Then
            'エラーであればブラウザにメッセージ表示
            Dim ErrMsgC As New CErrMsg
            strRecMsg = "システムエラー：" & ErrMsgC.mGetArtMsg(strRec)
            strMsg.Append("alert('" & strRecMsg & "');")

        ElseIf strRec.Substring(0, 5) = "DATA0" Then
            'データが0件の場合
            strRecMsg = "対象データが存在しません"
            strMsg.Append("alert('" & strRecMsg & "');")

            If strKIKANKBN = "1" Then                            '2021/10/01 2021年度監視改善⑥未処理も出力
                strMsg.Append("Form1.btnSelect.focus();")
            Else                                      '←集計表（感震器遮断警報）の出力だったら
                'rdoKIKAN1.Checked = True                   '対応完了日にラジオをセット(2021/10/01 2021年度監視改善⑥感震器帳票で件数ゼロエラー時には非活性が活性になってしまうため、無理やり値をセット処理一覧、2021/10/08でも不使用)
                'rdoKIKAN2.Checked = False                  '受信日のラジオをはずす、と思いきやここいら全部不要となったが頑張ったのでいつか参考出来るかもなので取っておく
                'chkTAI_TEL.Checked = True                  '←電話対応チェックボックスにチェック
                'chkTAI_SHU.Checked = True                  '←出動対応チェックボックスにチェック
                'rdoOUTLIST3.Checked = True                 '←出力項目ラジオにチェック
                'rdoKOJIN1.Checked = True                   '←個人情報なしラジオにチェック
                'cboTSADCD.SelectedValue = "59"             '←作動原因を災害にセット
                strMsg.Append("Form1.btnOutput.focus();")   '←フォーカスだけすることにしてみた
            End If                                         '2021/10/01 2021年度監視改善⑥未処理も出力

        Else
                '「開く、保存」のダイヤログが出るようにHTTPヘッダに追加
                'ファイル名変更
                HttpHeaderC.mDownLoadXLS(Response, "災害対応帳票.xlsx")

            ''ファイル送信
            Response.ContentType = "application/msexcel" '「ファイルを開く」際のエラー対策
            Response.WriteFile(strRec)

            Response.End()

            strRecMsg = "OK"
        End If

        strRec = strRecMsg
        '-------------------------------------------------
        '//ＡＰログ書き込み
        Dim LogC As New CLog
        Dim strRecLog As String
        strRecLog = LogC.mAPLog(Me.Session.SessionID, AuthC.pUSERNAME, AuthC.pIPADDRESS, hdnMyAspx.Value, "4", strRec, Request.Form)
        If strRecLog <> "OK" Then
            Dim errmsgc As New CErrMsg
            strMsg.Append("alert('システムエラー：" & errmsgc.mGetArtMsg(strRecLog) & "');")
        End If
    End Sub

    '******************************************************************************
    '*　概　要：絞込み条件を渡すプロパティ
    '*　備　考：(クライアントコード)
    '******************************************************************************
    Public ReadOnly Property pCode1() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = ""
                Case "1"
                    strRec = ""
                Case "2"
                    strRec = hdnKURACD_From.Value
                Case "3"
                    strRec = hdnKURACD_To.Value
            End Select
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*　概　要：絞込み条件を渡すプロパティ
    '*　備　考：(クライアントコード)
    '******************************************************************************
    Public ReadOnly Property pCode2() As String
        Get
            Dim strRec As String
            strRec = ""
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*　概　要：出力する一覧の名前を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pListName() As String
        Get
            Dim strRec As String
            'strRec = "クライアント一覧"
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = "クライアント一覧"
                Case "1"
                    strRec = "クライアント一覧"
                Case "2"
                    strRec = "ＪＡ一覧"
                Case "3"
                    strRec = "ＪＡ一覧"
            End Select
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*　概　要：出力する一覧を制御する値を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pListCd() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = "CLI"
                Case "1"
                    strRec = "CLI"
                Case "2"
                    strRec = "JA"
                Case "3"
                    strRec = "JA"
            End Select
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*　概　要：コードを返すオブジェクトの名前値を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pBackCode() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = "hdnKURACD_From"
                Case "1"
                    strRec = "hdnKURACD_To"
                Case "2"
                    strRec = "hdnJACD_From"
                Case "3"
                    strRec = "hdnJACD_To"
            End Select
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*　概　要：名称を返すオブジェクトの名前値を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pBackName() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = "txtKURACD_From"
                Case "1"
                    strRec = "txtKURACD_To"
                Case "2"
                    strRec = "txtJACD_From"
                Case "3"
                    strRec = "txtJACD_To"
            End Select
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*　概　要：コードを返すオブジェクトの名前値を渡すプロパティ２
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pBackCode2() As String
        Get
            Dim strRec As String = ""
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = ""
                Case "1"
                    strRec = ""
                Case "2"
                    strRec = "hdnJACD_From_CLI"
                Case "3"
                    strRec = "hdnJACD_To_CLI"
            End Select
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*　概　要：フォーカスを返すオブジェクトの名前値を渡すプロパティ
    '*　概　要：カレンダー日付でフォーカスセットされる項目名を返すオブジェクトを指定
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pBackFocs() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value.Length > 0 Then
                Select Case hdnPopcrtl.Value
                    Case "0"
                        strRec = "btnKURACD_From"
                    Case "1"
                        strRec = "btnKURACD_To"
                    Case "2"
                        strRec = "btnJACD_From"
                    Case "3"
                        strRec = "btnJACD_To"
                End Select
            End If

            If hdnCalendar.Value = "1" Then
                strRec = "txtTRGDATE_From"
            ElseIf hdnCalendar.Value = "2" Then
                strRec = "txtTRGDATE_To"
            End If

            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*　概　要：リターン後に実行されるＪＳ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pBackScript() As String
        Get
            Dim strRec As String = ""
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = "fncSetTo"
                Case "1"
                    strRec = ""
                Case "2"
                    strRec = "fncSetTo"
                Case "3"
                    strRec = ""
            End Select
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*　概　要：クリアするオブジェクトを渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pClear() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "0" Then
                strRec = "txtJACD_From,hdnJACD_From,hdnJACD_From_CLI,txtJACD_To,hdnJACD_To,hdnJACD_To_CLI"
            ElseIf hdnPopcrtl.Value = "1" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = ""
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*　概　要：カレンダー日付を返すの値を返すオブジェクトを指定
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pBackDate() As String
        Get
            Dim strRec As String
            If hdnCalendar.Value = "1" Then
                strRec = "txtTRGDATE_From"
            ElseIf hdnCalendar.Value = "2" Then
                strRec = "txtTRGDATE_To"
            End If
            Return strRec
        End Get
    End Property

End Class
