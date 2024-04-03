'***********************************************
' 監視対応出力
'***********************************************
' 変更履歴
' 2008/11/11 T.Watabe 
' 2014/12/10 H.Hosoda 監視改善2014 №13

Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common
Imports JPG.Common.log

Imports System.Text

Partial Class KETAISYG00
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
    ' 時刻クラス                 2017/02/16 H.Mori add 2016改善開発 No7-1
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
    Dim strKANSCD As String         '監視センターコード
    Dim strTFKICD As String         '復帰対応状況コード
    Dim strTFKINM As String         '復帰対応状況名称   '2017/03/02 H.Mori add 2017改善開発 No7-3 


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
        '2012/04/04 NEC ou Add Str
        '.NETの仕様変更により、ReadOnly属性をASPXでつけると、サーバ側で値の参照ができなくなるため、VB側でAttributeでつける
        If MyBase.IsPostBack = False Then
            txtKURACD_From.Attributes.Add("ReadOnly", "true")
            txtKURACD_To.Attributes.Add("ReadOnly", "true")
            txtJACD_From.Attributes.Add("ReadOnly", "true")
            txtJACD_To.Attributes.Add("ReadOnly", "true")
            txtHANGRP_From.Attributes.Add("ReadOnly", "ture")
            txtHANGRP_To.Attributes.Add("ReadOnly", "ture")
        End If
        '2012/04/04 NEC ou Add End

        '//------------------------------------------
        '//　HTTPヘッダを送信
        HttpHeaderC.mNoCache(Response)

        '//------------------------------------------
        '//　認証クラスのインスタンス生成
        AuthC = New CAuthenticate(Request, Response)
        'AuthC.pCENTERCD()
        '//------------------------------------------
        '//　認証処理
        '<TODO>：使用可能権限を指定する
        '[警報出力画面]使用可能権限(運:○/営:○/監:△/出:×)
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

        ''//件数チェックスクリプト
        'If hdnKensaku.Value = "KETAISCG00" Then
        '    Server.Transfer("./KETAISCG00.aspx")
        'End If

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
             MyBase.MapPath("../../../KE/KETAISYG/KETAISYG00/") & "KETAISYG00.js"))
        '<フォーカス関連関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncFo.js"))
        '<日付関連関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncDate.js"))
        '<時間関連関数> 
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncTime.js")) '2017/02/16 H.Mori add 改善2016 No8-2
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

            '受信日に当日日付を表示　2013/12/05 T.Ono add 監視改善2013
            txtTRGDATE_From.Text = DateTime.Today.ToString("yyyy/MM/dd")
            txtTRGDATE_To.Text = DateTime.Today.ToString("yyyy/MM/dd")

            '//フォーカスをセットする
            strMsg.Append("Form1.cboKANSCD.focus();")
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
        hdnMyAspx.Value = "KETAISYG00"
        '//-------------------------------------------------

    End Sub

    '******************************************************************************
    '*　概　要：コンボボックスの選択
    '*　備　考：
    '******************************************************************************
    Private Sub fncSelectCombo()
        Dim list As New ListItem
        '//<TODO>コンボボックスを選択状態にする

        '//監視センターコード
        If strKANSCD <> "" Then
            list = cboKANSCD.Items.FindByValue(strKANSCD)
            cboKANSCD.SelectedIndex = cboKANSCD.Items.IndexOf(list)
        End If

        '//復帰対応状況
        If strTFKICD <> "" Then
            list = cboTFKICD.Items.FindByValue(strTFKICD)
            cboTFKICD.SelectedIndex = cboTFKICD.Items.IndexOf(list) 
            strTFKINM = list.ToString   '2017/03/02 H.Mori add 2017改善開発 No7-3            
        End If

    End Sub

    '******************************************************************************
    '* POSTデータの取得変数の初期化
    '******************************************************************************
    Private Sub fncGetPostIni()
        '//--------------------------------------------------------------------------
        '<TODO>画面コントロール内容を格納した変数を初期化する
        strKANSCD = ""
        strTFKICD = ""
        strTFKINM = ""      '2017/03/02 H.Mori add 2017改善開発 No7-3
        '//-----------------------------------------------
        hdnKURACD_From.Value = ""
        hdnKURACD_To.Value = ""

        txtKURACD_From.Text = ""
        txtKURACD_To.Text = ""

        hdnJACD_From.Value = "" ' 2008/11/11 T.Watabe edit
        hdnJACD_To.Value = ""
        txtJACD_From.Text = ""
        txtJACD_To.Text = ""

        hdnJACD_From_CLI.Value = ""     '2019/11/01 T.Ono add 監視改善2019
        hdnJACD_To_CLI.Value = ""       '2019/11/01 T.Ono add 監視改善2019

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
        strKANSCD = Request.Form("cboKANSCD")
        strTFKICD = Request.Form("cboTFKICD")
    End Sub

    '******************************************************************************
    '* 各コントロールの設定値の初期化
    '******************************************************************************
    Private Sub fncIni_format()

        'コンボ作成
        Call fncCombo_Creatr_KANSI_CD()         '監視センターコンボ
        Call fncCombo_Create_Hukkitai()         '復帰対応状況コンボ

        cboKANSCD.SelectedIndex = 0
        cboTFKICD.SelectedIndex = 0

    End Sub

    '******************************************************************************
    '*　概　要：コンボボックス作成
    '*　備　考：
    '******************************************************************************
    Private Sub fncCreateCombo()
        '//--------------------------------------------------------------------------
        '<TODO>コンボボックスを作成するファンクションをCallする
        Call fncCombo_Creatr_KANSI_CD()         '監視センターコンボ
        Call fncCombo_Create_Hukkitai()         '復帰対応状況
    End Sub

    '******************************************************************************
    'コンボボックスの作成 2013/12/06 T.Ono del ユーザーにより閲覧制限をかける
    '******************************************************************************
    'Private Sub fncCombo_Creatr_KANSI_CD()
    '    '//監視センターコンボ
    '    cboKANSCD.pComboTitle = True
    '    cboKANSCD.pNoData = False
    '    cboKANSCD.pType = "KANSICENTER"

    '    Dim strALLCENTERCD As String = ConfigurationSettings.AppSettings("GROUP_KANSHICD")

    '    cboKANSCD.pAllCenterCd = strALLCENTERCD
    '    cboKANSCD.mMakeCombo()
    'End Sub

    '******************************************************************************
    'コンボボックスの作成 2013/12/06 T.Ono add
    '******************************************************************************
    Private Sub fncCombo_Creatr_KANSI_CD()
        '//監視センターコンボ
        Dim strGROUPNAME As String = AuthC.pGROUPNAME
        Dim arrGroupName() As String = strGROUPNAME.Split(Convert.ToChar(","))
        Dim strALLCENTERCD As String = ConfigurationSettings.AppSettings("GROUP_KANSHICD")

        cboKANSCD.pNoData = False
        cboKANSCD.pType = "KANSICENTER"
        If InStr(AuthC.pGROUPNAME, "0監視業務単独") > 0 Then
            cboKANSCD.pComboTitle = False
            cboKANSCD.pAllCenterCd = AuthC.pAUTHCENTERCD
        Else
            '川口監視センター・運行はすべての監視センター閲覧可能かつ未選択OK
            cboKANSCD.pComboTitle = True
            cboKANSCD.pAllCenterCd = strALLCENTERCD
        End If
        cboKANSCD.mMakeCombo()
    End Sub

    Private Sub fncCombo_Create_Hukkitai()
        '//復帰対応状況
        cboTFKICD.pComboTitle = True
        cboTFKICD.pNoData = False
        cboTFKICD.pType = "HUKKITAI"
        cboTFKICD.mMakeCombo()
    End Sub

    '******************************************************************************
    ' Excel出力(チェックつき)
    '******************************************************************************
    Private Sub btnSelect_ServerClick(ByVal sender As System.Object, _
                                    ByVal e As System.EventArgs) Handles btnSelect.ServerClick
        Dim strRec As String
        'Dim bytExcel() As Byte '2014/01/16 T.Ono del 改善対応2013 Excelを直接出力に変更
        Dim KETAISYG00C As New KETAISYG00KETAISYW00.KETAISYW00

        Dim strSTKBN1 As String
        Dim strSTKBN2 As String

        Dim strPGKBN1 As String
        Dim strPGKBN2 As String
        Dim strPGKBN3 As String

        Dim strOUTKBN As String    '2014/12/10 H.Hosoda add 監視改善2014 №13
        Dim strKIKANKBN As String  '2014/12/11 H.Hosoda add 監視改善2014 №13
        Dim strHOKBN As String     '2017/02/17 W.GANEKO add 監視改善2016 №7
        Dim strOUTLIST As String   '2017/02/17 W.GANEKO add 監視改善2016 №7

        '//　認証クラスのインスタンス生成
        AuthC = New CAuthenticate(Request, Response)

        '発生区分取得
        strSTKBN1 = ""
        strSTKBN2 = ""
        If chkHSI_TEL.Checked = True Then
            strSTKBN1 = "1"      '電話
        End If

        If chkHSI_KEI.Checked = True Then
            strSTKBN2 = "2"      '警報
        End If

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

        '出力対象取得  2014/12/10 H.Hosoda add 監視改善2014 №13
        If rdoOUTPUT1.Checked = True Then
            strOUTKBN = "1"     '通常
        Else
            strOUTKBN = "2"     '月末帳票と同じ
        End If
        
        '対象期間区分取得 2014/12/11 H.Hosoda add 監視改善2014 №13
        If rdoKIKAN1.Checked = True Then
            strKIKANKBN = "1"     '対応完了日
        Else
            strKIKANKBN = "2"     '受信日
        End If
        '法令区分取得  2017/02/17 W.GANEKO add 監視改善2016 №7
        strHOKBN = ""
        If rdoHOKBN1.Checked = True Then
            strHOKBN = "1"     '総合計
        ElseIf rdoHOKBN2.Checked = True Then
            strHOKBN = "2"     '液石
        ElseIf rdoHOKBN3.Checked = True Then
            strHOKBN = "3"     'その他
        End If
        '出力項目取得  2017/02/17 W.GANEKO add 監視改善2016 №7
        strOUTLIST = ""
        If rdoOUTLIST1.Checked = True Then
            strOUTLIST = "1"     '全て
        ElseIf rdoOUTLIST2.Checked = True Then
            strOUTLIST = "2"     '日次報告と同じ(出動会社あり)
        ElseIf rdoOUTLIST3.Checked = True Then
            strOUTLIST = "3"     '日次報告と同じ(出動会社なし)
        End If

        Dim strRecMsg As String = ""

        '2012/04/04 NEC ou Upd Str
        'strRec = KETAISYG00C.mExcel( _
        '                         Request.Cookies.Get("ASP.NET_SessionId").Value, _
        '                         strKANSCD, _
        '                         strTFKICD, _
        '                         strSTKBN1, _
        '                         strSTKBN2, _
        '                         strPGKBN1, _
        '                         strPGKBN2, _
        '                         strPGKBN3, _
        '                         DateFncC.mHenkanGet(txtTRGDATE_From.Text), _
        '                         DateFncC.mHenkanGet(txtTRGDATE_To.Text), _
        '                         hdnKURACD_From.Value, _
        '                         hdnKURACD_To.Value, _
        '                         hdnJACD_From.Value, _
        '                         hdnJACD_To.Value _
        '                         )
        '2014/12/10 H.Hosoda mod 監視改善2014 №13 START
        'strRec = KETAISYG00C.mExcel( _
        '                 Me.Session.SessionID, _
        '                 strKANSCD, _
        '                 strTFKICD, _
        '                 strSTKBN1, _
        '                 strSTKBN2, _
        '                 strPGKBN1, _
        '                 strPGKBN2, _
        '                 strPGKBN3, _
        '                 DateFncC.mHenkanGet(txtTRGDATE_From.Text), _
        '                 DateFncC.mHenkanGet(txtTRGDATE_To.Text), _
        '                 hdnKURACD_From.Value.Trim, _
        '                 hdnKURACD_To.Value.Trim, _
        '                 hdnJACD_From.Value.Trim, _
        '                 hdnJACD_To.Value.Trim _
        '                 )
        '2012/04/04 NEC ou Upd End
        '2017/02/16 H.Mori mod 改善2016 No7-1 START
        'strRec = KETAISYG00C.mExcel( _
        '                 Me.Session.SessionID, _
        '                 strKANSCD, _
        '                 strTFKICD, _
        '                 strSTKBN1, _
        '                 strSTKBN2, _
        '                 strPGKBN1, _
        '                 strPGKBN2, _
        '                 strPGKBN3, _
        '                 DateFncC.mHenkanGet(txtTRGDATE_From.Text), _
        '                 DateFncC.mHenkanGet(txtTRGDATE_To.Text), _
        '                 hdnKURACD_From.Value.Trim, _
        '                 hdnKURACD_To.Value.Trim, _
        '                 hdnJACD_From.Value.Trim, _
        '                 hdnJACD_To.Value.Trim, _
        '                 hdnHANGRP_From.Value.Trim, _
        '                 hdnHANGRP_To.Value.Trim, _
        '                 strOUTKBN, _
        '                 strKIKANKBN _
        '                 )
        '2014/12/10 H.Hosoda mod 監視改善2014 №13 END
        'TODO 2017/02/17 W.GANEKO mod 監視改善2016 №7 START
        '2019/11/01 T.Ono mod 監視改善2019 hdnJACD_From_CLI,hdnJACD_To_CLI 追加
        '2020/01/06 T.Ono mod 災害対応帳票 TSADCD(""),TSADNM("")追加
        strRec = KETAISYG00C.mExcel(
                         Me.Session.SessionID,
                         strKANSCD,
                         strTFKICD,
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
                         hdnHANGRP_From.Value.Trim,
                         hdnHANGRP_To.Value.Trim,
                         strOUTKBN,
                         strKIKANKBN,
                         TimeFncC.mHenkanGet(txtTRGTIME_From.Text),
                         TimeFncC.mHenkanGet(txtTRGTIME_To.Text),
                         strHOKBN,
                         strOUTLIST,
                         strTFKINM,
                         "",
                         ""
                         )
        'TODO 2017/02/17 W.GANEKO mod 監視改善2016 №7 END
        '2017/02/16 H.Mori mod 改善2016 No7-1 END

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
            'ファイル名は、HttpUtility.UrlEncodeメソッドを使用してSJISにエンコードする必要がある
            '            HttpHeaderC.mDownLoad(Response, "累積情報一覧.exe")
            '.xls形式に変更 2013/12/05 T.Ono mod 監視改善2013
            'HttpHeaderC.mDownLoad(Response, "警報出力.exe")
            'ファイル名変更 2017/02/17 W.GANEKO mod 監視改善2016 №7
            'HttpHeaderC.mDownLoadXLS(Response, "警報出力.xls")
            HttpHeaderC.mDownLoadXLS(Response, "対応結果明細.xls")

            '2014/01/16 T.Ono mod 監視改善2013 excelを直接開く Start
            ''Webサービスの戻り値（BASE64のテキスト）をバイトデータに変換する
            'bytExcel = Convert.FromBase64String(strRec)
            ''ファイル送信
            'Response.BinaryWrite(bytExcel)
            Response.ContentType = "application/msexcel" '2017/05/11 T.Ono add 「ファイルを開く」際のエラー対策
            Response.WriteFile(strRec)

            'Response.Flush()
            Response.End()
            'Response.WriteFile("C:\inetpub\wwwroot\JPGAP\TEMP\00\KETAISYW00\test.xls")
            '2014/01/16 T.Ono mod 監視改善2013 excelを直接開く End

            strRecMsg = "OK"
        End If

        strRec = strRecMsg
        '-------------------------------------------------
        '//ＡＰログ書き込み
        Dim LogC As New CLog
        Dim strRecLog As String
        '2012/04/04 NEC ou Upd
        'strRecLog = LogC.mAPLog(Request.Cookies.Get("ASP.NET_SessionId").Value, AuthC.pUSERNAME, AuthC.pIPADDRESS, hdnMyAspx.Value, "4", strRec, Request.Form)
        strRecLog = LogC.mAPLog(Me.Session.SessionID, AuthC.pUSERNAME, AuthC.pIPADDRESS, hdnMyAspx.Value, "4", strRec, Request.Form)
        '2012/04/04 NEC ou Upd
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
                    strRec = Request.Form("cboKANSCD")     '指定された監視センターコード配下のクライアントコード
                Case "1"
                    strRec = Request.Form("cboKANSCD")     '指定された監視センターコード配下のクライアントコード
                Case "2"
                    strRec = hdnKURACD_From.Value ' 2008/11/11 T.Watabe edit
                Case "3"
                    'strRec = hdnKURACD_From.Value ' 2008/11/11 T.Watabe edit
                    strRec = hdnKURACD_To.Value   ' 2019/11/01 T.Ono mod
                Case "4"
                    strRec = hdnKURACD_From.Value ' 2014/12/11 H.Hosoda add 監視改善2014 №13
                Case "5"
                    'strRec = hdnKURACD_From.Value ' 2014/12/11 H.Hosoda add 監視改善2014 №13
                    strRec = hdnKURACD_To.Value   ' 2019/11/01 T.Ono mod
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
                Case "4"
                    strRec = "販売事業者グループ一覧"  ' 2014/12/11 H.Hosoda add 監視改善2014 №13
                Case "5"
                    strRec = "販売事業者グループ一覧"  ' 2014/12/11 H.Hosoda add 監視改善2014 №13
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
                    strRec = "CLI" ' 2008/11/11 T.Watabe edit
                Case "2"
                    strRec = "JA" ' 2008/11/11 T.Watabe edit
                Case "3"
                    strRec = "JA" ' 2008/11/11 T.Watabe edit
                Case "4"
                    strRec = "HANG" ' 2014/12/11 H.Hosoda add 監視改善2014 №13
                Case "5"
                    strRec = "HANG" ' 2014/12/11 H.Hosoda add 監視改善2014 №13
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
                    strRec = "hdnJACD_From"                 ' 2008/11/11 T.Watabe edit
                Case "3"
                    strRec = "hdnJACD_To"                    ' 2008/11/11 T.Watabe edit
                Case "4"
                    strRec = "hdnHANGRP_From"               ' 2014/12/11 H.Hosoda add 監視改善2014 №13
                Case "5"
                    strRec = "hdnHANGRP_To"                  ' 2014/12/11 H.Hosoda add 監視改善2014 №13
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
                    strRec = "txtJACD_From"                 ' 2008/11/11 T.Watabe edit
                Case "3"
                    strRec = "txtJACD_To"                    ' 2008/11/11 T.Watabe edit
                Case "4"
                    strRec = "txtHANGRP_From"               ' 2014/12/11 H.Hosoda add 監視改善2014 №13
                Case "5"
                    strRec = "txtHANGRP_To"                  ' 2014/12/11 H.Hosoda add 監視改善2014 №13
            End Select
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*　概　要：コードを返すオブジェクトの名前値を渡すプロパティ２　2019/11/01 T.Ono add 監視改善2019
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
                Case "4"
                    strRec = ""
                Case "5"
                    strRec = ""
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
                        strRec = "btnJACD_From" ' 2008/11/11 T.Watabe edit
                    Case "3"
                        strRec = "btnJACD_To" ' 2008/11/11 T.Watabe edit
                    Case "4"
                        strRec = "btnHANGRP_From" ' 2014/12/11 H.Hosoda add 監視改善2014 №13
                    Case "5"
                        strRec = "btnHANGRP_To" ' 2014/12/11 H.Hosoda add 監視改善2014 №13
                End Select
                '2019/11/01 T.Ono mod 監視改善2019 START
                'hdnPopcrtlの初期化処理をコメントアウトしたため修正
                'ElseIf hdnCalendar.Value = "1" Then
                '    strRec = "txtTRGDATE_From"
                'ElseIf hdnCalendar.Value = "2" Then
                '    strRec = "txtTRGDATE_To"
            End If

            If hdnCalendar.Value = "1" Then
                strRec = "txtTRGDATE_From"
            ElseIf hdnCalendar.Value = "2" Then
                strRec = "txtTRGDATE_To"
            End If
            '2019/11/01 T.Ono mod 監視改善2019 END

            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*　概　要：リターン後に実行されるＪＳ　2019/11/01 T.Ono add 監視改善2019
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
                Case "4"
                    strRec = "fncSetTo"
                Case "5"
                    strRec = ""
            End Select
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*　概　要：
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pClear1() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "0" Then
                strRec = "txtKURACD_From"
            ElseIf hdnPopcrtl.Value = "1" Then
                strRec = "txtKURACD_To"
            ElseIf hdnPopcrtl.Value = "2" Then ' 2008/11/11 T.Watabe edit
                strRec = "txtJACD_From"
            ElseIf hdnPopcrtl.Value = "3" Then ' 2008/11/11 T.Watabe edit
                strRec = "txtJACD_To"
            ElseIf hdnPopcrtl.Value = "4" Then ' 2014/12/11 H.Hosoda add 監視改善2014 №13
                strRec = "txtHANGRP_From"
            ElseIf hdnPopcrtl.Value = "5" Then ' 2014/12/11 H.Hosoda add 監視改善2014 №13
                strRec = "txtHANGRP_To"
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pClear2() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "0" Then
                strRec = "hdnKURACD_From"
            ElseIf hdnPopcrtl.Value = "1" Then
                strRec = "hdnKURACD_To"
            ElseIf hdnPopcrtl.Value = "2" Then ' 2008/11/11 T.Watabe edit
                strRec = "hdnJACD_From"
            ElseIf hdnPopcrtl.Value = "3" Then ' 2008/11/11 T.Watabe edit
                strRec = "hdnJACD_To"
            ElseIf hdnPopcrtl.Value = "4" Then ' 2014/12/11 H.Hosoda add 監視改善2014 №13
                strRec = "hdnHANGRP_From"
            ElseIf hdnPopcrtl.Value = "5" Then ' 2014/12/11 H.Hosoda add 監視改善2014 №13
                strRec = "hdnHANGRP_To"
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：ＪＡが変更された時にクリアするオブジェクトの名前値を渡すプロパティ１
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pClearName() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"                    
                    'strRec = "txtJACD_From,txtJACD_To" ' 2014/12/11 H.Hosoda mod 監視改善2014 №13
                    strRec = "txtJACD_From,txtJACD_To,txtHANGRP_From,txtHANGRP_To"
                Case "1"
                    strRec = ""
                Case "2"
                    strRec = ""
                Case "3"
                    strRec = ""
                Case "4"
                    strRec = ""  ' 2014/12/11 H.Hosoda add 監視改善2014 №13
                Case "5"
                    strRec = ""  ' 2014/12/11 H.Hosoda add 監視改善2014 №13
            End Select
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：ＪＡが変更された時にクリアするオブジェクトの名前値を渡すプロパティ１
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pClearCode() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    'strRec = "hdnJACD_From,hdnJACD_To"  ' 2014/12/11 H.Hosoda mod 監視改善2014 №13
                    strRec = "hdnJACD_From,hdnJACD_To,hdnHANGRP_From,hdnHANGRP_To"
                Case "1"
                    strRec = ""
                Case "2"
                    strRec = ""
                Case "3"
                    strRec = ""
                Case "4"
                    strRec = ""  ' 2014/12/11 H.Hosoda add 監視改善2014 №13
                Case "5"
                    strRec = ""  ' 2014/12/11 H.Hosoda add 監視改善2014 №13
            End Select
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
