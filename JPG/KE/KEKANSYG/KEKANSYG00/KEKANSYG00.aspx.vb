'***********************************************
' 監視対応数集計表  画面
'***********************************************
' 変更履歴
' 2008/11/21 T.Watabe 新規作成
' 2010/03/09 T.Watabe 対応区分＝重複を帳票に含むor含まないの条件を追加

Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common
Imports JPG.Common.log

Imports System.Text

Partial Class KEKANSYG00
    Inherits System.Web.UI.Page
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
    ' 時刻クラス                 2017/02/15 H.Mori add 2016改善開発 No8-2
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
            '2015/02/09 H.Hosoda mod 監視改善2014 №14 Start
            'txtKURACD.Attributes.Add("ReadOnly", "true")
            'txtJACD.Attributes.Add("ReadOnly", "true")
            txtKURACD_From.Attributes.Add("ReadOnly", "true")
            txtKURACD_To.Attributes.Add("ReadOnly", "true")
            txtJACD_From.Attributes.Add("ReadOnly", "true")
            txtJACD_To.Attributes.Add("ReadOnly", "true")
            txtHANGRP_From.Attributes.Add("ReadOnly", "true")
            txtHANGRP_To.Attributes.Add("ReadOnly", "true")
            '2015/02/09 H.Hosoda mod 監視改善2014 №14 End
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
        '[対応結果一覧]使用可能権限(運:○/営:○/監:△/出:×)
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
        '//件数チェックスクリプト
        If hdnKensaku.Value = "KEKANSCG00" Then
            Server.Transfer("./KEKANSCG00.aspx")
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
        '<独自スクリプト>
        strScript.Append(cscript1.mWriteScript( _
             MyBase.MapPath("../../../KE/KEKANSYG/KEKANSYG00/") & "KEKANSYG00.js"))
        '<フォーカス関連関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncFo.js"))
        '<日付関連関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncDate.js"))
        '<時間関連関数> 
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncTime.js")) '2017/02/15 H.Mori add 改善2016 No8-2
        strScript.Append("</Script>")
        '//------------------------------------------
        '//　Css格納
        strScript.Append("<Style>")
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "CssData.css"))
        strScript.Append("</Style>")
        '//------------------------------------------
        '//　Script書込み
        lblScript.Text = strScript.ToString

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
            '//フォーカスをセットする
            '2015/02/09 H.Hosoda mod 監視改善2014 №14 Start
            'strMsg.Append("Form1.btnKURACD.focus();")
            strMsg.Append("Form1.btnKURACD_From.focus();")
            '2015/02/09 H.Hosoda mod 監視改善2014 №14 Start

            '初期値に前月月初と前月月末をセット
            Dim ndt As Date = Now
            strMsg.Append("Form1.txtTRGDATE_From.value='" & Left(DateSerial(ndt.Year, ndt.Month - 1, 1).ToString, 10) & "';")
            strMsg.Append("Form1.txtTRGDATE_To.value='" & Left(DateSerial(ndt.Year, ndt.Month, 1).AddDays(-1).ToString, 10) & "';")

        Else
            '//--------------------------------------
            '//　２回目以降実行される
            '//--------------------------------------------------------------------------
            '//※画面表示するコンボボックスは各最終イベント/メソッドでCALLします
            '//--------------------------------------------------------------------------
        End If

        '//-------------------------------------------------
        '<TODO>自分の画面IDをHIDDENのhdnMyAspxに書き込む（システム共通）
        hdnMyAspx.Value = "KEKANSYG00"
        '//-------------------------------------------------

    End Sub

    '******************************************************************************
    ' Excel出力(チェックつき)
    '******************************************************************************
    Private Sub btnSelect_ServerClick(ByVal sender As System.Object, _
                                    ByVal e As System.EventArgs) Handles btnSelect.ServerClick
        Dim strRec As String
        'Dim bytExcel() As Byte '2014/01/16 T.Ono del 改善対応2013 Excelを直接出力に変更
        Dim KEKANSYG00C As New KEKANSYG00KEKANSYW00.KEKANSYW00

        Dim strSTKBN As String
        Dim strPGKBN As String
        '2015/02/04 H.Hosoda mod 監視改善2014 №14 Start
        'Dim strTAIOU_CHOFUKU As String '2010/03/09 T.Watabe add
        Dim strHASSEI_TEL As String
        Dim strHASSEI_KEI As String
        Dim strTAIOU_TEL As String
        Dim strTAIOU_SHU As String
        Dim strTAIOU_JUF As String
        Dim strTRGDATE_KBN As String
        '2015/02/04 H.Hosoda mod 監視改善2014 №14 End
        Dim strTSADCD As String    '2020/11/01 T.Ono add 2020監視改善

        '//　認証クラスのインスタンス生成
        AuthC = New CAuthenticate(Request, Response)

        '集約条件
        If rdoPGKBN1.Checked = True Then
            strPGKBN = "1"      'クライアント単位
        ElseIf rdoPGKBN2.Checked = True Then
            strPGKBN = "2"      'JA単位
        '2015/02/04 H.Hosoda mod 監視改善2014 №14 Start
        'Else
        ElseIf rdoPGKBN3.Checked = True Then
            strPGKBN = "3"      'JA支所単位
        ElseIf rdoPGKBN4.Checked = True Then
            strPGKBN = "4"      '販売事業者単位
            '2017/02/16 H.Mori add 改善2016 No8-1 START
            'Else
            '    strPGKBN = "5"      '販売事業者支所単位
            'End If
            '2015/02/04 H.Hosoda mod 監視改善2014 №14 End
        ElseIf rdoPGKBN6.Checked = True Then
            strPGKBN = "6"      '県単位
        Else
            strPGKBN = "7"      '販売所単位
        End If
        '2017/02/16 H.Mori add 改善2016 No8-1 END

        '2015/02/04 H.Hosoda add 監視改善2014 №14 Start
        strHASSEI_TEL = ""
        strHASSEI_KEI = ""
        If chkHSI_TEL.Checked = True Then  '発生区分：電話
            strHASSEI_TEL = "1"
        End If
        If chkHSI_KEI.Checked = True Then  '発生区分：警報
            strHASSEI_KEI = "2"
        End If
        '2015/02/04 H.Hosoda add 監視改善2014 №14 End

        '2015/02/04 H.Hosoda mod 監視改善2014 №14 Start
        '2010/03/09 T.Watabe add
        'If chkTAIOU_CHOFUKU.Checked = True Then
        '    strTAIOU_CHOFUKU = "1"      '1:重複あり
        'Else
        '    strTAIOU_CHOFUKU = "0"      '0:重複なし
        'End If
        strTAIOU_TEL = ""
        strTAIOU_SHU = ""
        strTAIOU_JUF = ""
        If chkTAI_TEL.Checked = True Then  '対応区分：電話
            strTAIOU_TEL = "1"
        End If
        If chkTAI_SHU.Checked = True Then  '対応区分：出動
            strTAIOU_SHU = "2"
        End If
        If chkTAI_JUF.Checked = True Then  '対応区分：重複
            strTAIOU_JUF = "3"
        End If
        '2015/02/04 H.Hosoda mod 監視改善2014 №14 End

        '2015/02/04 H.Hosoda add 監視改善2014 №14 Start
        If rdoKIKAN1.Checked = True Then
            strTRGDATE_KBN = "1"      '対応完了日
        Else
            strTRGDATE_KBN = "2"      '受信日
        End If
        '2015/02/04 H.Hosoda add 監視改善2014 №14 End

        '2020/11/01 T.Ono add 監視改善2020 Start
        '作動原因　1＝工事・交換など：63 含む
        strTSADCD = ""
        If chkTSADCD.Checked = True Then
            strTSADCD = "1"
        Else
            strTSADCD = "0"
        End If
        '2020/11/01 T.Ono add 監視改善2020 End

        Dim strRecMsg As String = ""
        'Dim intMaxDataCnt As Integer = ConstC.pPageMax '2008/12/18 T.Watabe edit
        Dim intMaxDataCnt As Integer = 10000

        '2012/04/04 NEC ou Upd Str
        'strRec = KEKANSYG00C.mExcel( _
        '                         Request.Cookies.Get("ASP.NET_SessionId").Value, _
        '                         hdnKURACD.Value, _
        '                         hdnJACD.Value, _
        '                         strPGKBN, _
        '                         strTAIOU_CHOFUKU, _
        '                         DateFncC.mHenkanGet(txtTRGDATE_From.Text), _
        '                         DateFncC.mHenkanGet(txtTRGDATE_To.Text), _
        '                         txtKURACD.Text, _
        '                         txtJACD.Text, _
        '                         intMaxDataCnt, _
        '                         AuthC.pCENTERCD _
        '                         )
        '2015/02/04 H.Hosoda mod 監視改善2014 №14 Start        
        'strRec = KEKANSYG00C.mExcel( _
        '                 Me.Session.SessionID, _
        '                 hdnKURACD.Value.Trim(), _
        '                 hdnJACD.Value.Trim(), _
        '                 strPGKBN, _
        '                 strTAIOU_CHOFUKU, _
        '                 DateFncC.mHenkanGet(txtTRGDATE_From.Text), _
        '                 DateFncC.mHenkanGet(txtTRGDATE_To.Text), _
        '                 txtKURACD.Text, _
        '                 txtJACD.Text, _
        '                 intMaxDataCnt, _
        '                 AuthC.pCENTERCD _
        '                 )
        '2012/04/04 NEC ou Upd End
        '2017/02/15 H.Mori mod 改善2016 No8-2 START
        'strRec = KEKANSYG00C.mExcel( _
        '                 Me.Session.SessionID, _
        '                 hdnKURACD_From.Value.Trim(), _
        '                 hdnKURACD_To.Value.Trim(), _
        '                 hdnJACD_From.Value.Trim(), _
        '                 hdnJACD_To.Value.Trim(), _
        '                 hdnHANGRP_From.Value.Trim(), _
        '                 hdnHANGRP_To.Value.Trim(), _
        '                 strPGKBN, _
        '                 strHASSEI_TEL, _
        '                 strHASSEI_KEI, _
        '                 strTAIOU_TEL, _
        '                 strTAIOU_SHU, _
        '                 strTAIOU_JUF, _
        '                 DateFncC.mHenkanGet(txtTRGDATE_From.Text), _
        '                 DateFncC.mHenkanGet(txtTRGDATE_To.Text), _
        '                 strTRGDATE_KBN, _
        '                 intMaxDataCnt, _
        '                 AuthC.pCENTERCD _
        '                 )
        '2015/02/04 H.Hosoda mod 監視改善2014 №14 End
        '2020/11/01 T.Ono mod 監視改善2020 Start
        'strTSADCD_CHK　追加
        strRec = KEKANSYG00C.mExcel(
                         Me.Session.SessionID,
                         hdnKURACD_From.Value.Trim(),
                         hdnKURACD_To.Value.Trim(),
                         hdnJACD_From.Value.Trim(),
                         hdnJACD_To.Value.Trim(),
                         hdnHANGRP_From.Value.Trim(),
                         hdnHANGRP_To.Value.Trim(),
                         strPGKBN,
                         strHASSEI_TEL,
                         strHASSEI_KEI,
                         strTAIOU_TEL,
                         strTAIOU_SHU,
                         strTAIOU_JUF,
                         DateFncC.mHenkanGet(txtTRGDATE_From.Text),
                         DateFncC.mHenkanGet(txtTRGDATE_To.Text),
                         strTRGDATE_KBN,
                         intMaxDataCnt,
                         AuthC.pCENTERCD,
                         TimeFncC.mHenkanGet(txtTRGTIME_From.Text),
                         TimeFncC.mHenkanGet(txtTRGTIME_To.Text),
                         strTSADCD
                         )
        '2017/02/15 H.Mori mod 改善2016 No8-2 END
        '2020/11/01 T.Ono mod 監視改善2020 End

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

        ElseIf strRec.Substring(0, 7) = "DATAMAX" Then
            'データが最大行数を超えたの場合
            strRecMsg = "データが最大行数を超えました。[最大" & intMaxDataCnt & "行]"
            strMsg.Append("alert('" & strRecMsg & "');")
            strMsg.Append("Form1.btnSelect.focus();")

        Else
            '「開く、保存」のダイヤログが出るようにHTTPヘッダに追加
            'ファイル名は、HttpUtility.UrlEncodeメソッドを使用してSJISにエンコードする必要がある
            '.xls形式に変更 2013/12/06 T.Ono mod 監視改善2013
            'HttpHeaderC.mDownLoad(Response, "監視対応数集計表.exe")
            HttpHeaderC.mDownLoadXLS(Response, "監視対応数集計表.xls")

            '2014/01/16 T.Ono mod 監視改善2013 excelを直接開く Start
            ''Webサービスの戻り値（BASE64のテキスト）をバイトデータに変換する
            'bytExcel = Convert.FromBase64String(strRec)
            ''ファイル送信
            'Response.BinaryWrite(bytExcel)
            Response.WriteFile(strRec)
            '2014/01/16 T.Ono mod 監視改善2013 excelを直接開く End
            strRecMsg = "OK"
        End If

        strRec = strRecMsg
        '-------------------------------------------------
        '//ＡＰログ書き込み
        Dim LogC As New CLog
        Dim strRecLog As String
        '2012/04/04 NEC ou Upd Str
        'strRecLog = LogC.mAPLog(Request.Cookies.Get("ASP.NET_SessionId").Value, AuthC.pUSERNAME, AuthC.pIPADDRESS, hdnMyAspx.Value, "4", strRec, Request.Form)
        strRecLog = LogC.mAPLog(Me.Session.SessionID, AuthC.pUSERNAME, AuthC.pIPADDRESS, hdnMyAspx.Value, "4", strRec, Request.Form)
        '2012/04/04 NEC ou Upd End
        If strRecLog <> "OK" Then
            Dim errmsgc As New CErrMsg
            strMsg.Append("alert('システムエラー：" & errmsgc.mGetArtMsg(strRecLog) & "');")
        End If
    End Sub

    '******************************************************************************
    '* 件数チェック用画面に渡すパラメータ設定
    '******************************************************************************
    '2015/02/09 H.Hosoda mod 監視改善2014 №14 Start
    'Public ReadOnly Property pKuracd() As String
    '    Get
    '        Return hdnKURACD.Value.Trim     '2012/04/04 NEC ou Add Upd
    '    End Get
    'End Property
    'Public ReadOnly Property pJacd() As String
    '    Get
    '        Return hdnJACD.Value.Trim       '2012/04/04 NEC ou Add Upd
    '    End Get
    'End Property
    Public ReadOnly Property pKuracdFrom() As String
        Get
            Return hdnKURACD_From.Value.Trim     '2012/04/04 NEC ou Add Upd
        End Get
    End Property
    Public ReadOnly Property pKuracdTo() As String
        Get
            Return hdnKURACD_To.Value.Trim       '2012/04/04 NEC ou Add Upd
        End Get
    End Property
    Public ReadOnly Property pJacdFrom() As String
        Get
            Return hdnJACD_From.Value.Trim     '2012/04/04 NEC ou Add Upd
        End Get
    End Property
    Public ReadOnly Property pJacdTo() As String
        Get
            Return hdnJACD_To.Value.Trim       '2012/04/04 NEC ou Add Upd
        End Get
    End Property
    Public ReadOnly Property pHangrpFrom() As String
        Get
            Return hdnHANGRP_From.Value.Trim     '2012/04/04 NEC ou Add Upd
        End Get
    End Property
    Public ReadOnly Property pHangrpTo() As String
        Get
            Return hdnHANGRP_To.Value.Trim       '2012/04/04 NEC ou Add Upd
        End Get
    End Property
    Public ReadOnly Property pPgkbn() As String
        Get
            '集約条件
            If rdoPGKBN1.Checked = True Then
                Return "1"      'クライアント単位
            ElseIf rdoPGKBN2.Checked = True Then
                Return "2"      'JA単位
            ElseIf rdoPGKBN3.Checked = True Then
                Return "3"      'JA支所単位
            ElseIf rdoPGKBN4.Checked = True Then
                Return "4"      '販売事業者単位
                '2017/02/16 H.Mori mod 改善2016 No8-1 START
                'Else
                '    Return "5"      '販売事業者支所単位
                '2017/02/16 H.Mori mod 改善2016 No8-1 END
            ElseIf rdoPGKBN6.Checked = True Then
                Return "6"      '県単位
            Else
                Return "7"      '販売所単位
            End If
        End Get
    End Property
    Public ReadOnly Property pHasseiTel() As String
        Get
            If chkHSI_TEL.Checked = True Then  '発生区分：電話
                Return "1"
            Else
                Return ""
            End If
        End Get
    End Property
    Public ReadOnly Property pHasseiKei() As String
        Get
            If chkHSI_KEI.Checked = True Then  '発生区分：警報
                Return "2"
            Else
                Return ""
            End If
        End Get
    End Property
    Public ReadOnly Property pTaiouTel() As String
        Get
            If chkTAI_TEL.Checked = True Then  '対応区分：電話
                Return "1"
            Else
                Return ""
            End If
        End Get
    End Property
    Public ReadOnly Property pTaiouShu() As String
        Get
            If chkTAI_SHU.Checked = True Then  '対応区分：出動
                Return "2"
            Else
                Return ""
            End If
        End Get
    End Property
    Public ReadOnly Property pTaiouJuf() As String
        Get
            If chkTAI_JUF.Checked = True Then  '対応区分：重複
                Return "3"
            Else
                Return ""
            End If
        End Get
    End Property
    Public ReadOnly Property pTrgdatekbn() As String
        Get
            If rdoKIKAN1.Checked = True Then
                Return "1"      '対応完了日
            Else
                Return "2"      '受信日
            End If
        End Get
    End Property
    '2015/02/09 H.Hosoda mod 監視改善2014 №14 End
    Public ReadOnly Property pYmdFrom() As String
        Get
            Return DateFncC.mHenkanGet(txtTRGDATE_From.Text)
        End Get
    End Property
    Public ReadOnly Property pYmdTo() As String
        Get
            Return DateFncC.mHenkanGet(txtTRGDATE_To.Text)
        End Get
    End Property
    '2017/02/16 H.Mori add 改善2016 No8-2 START
    Public ReadOnly Property pTimeFrom() As String
        Get
            Return TimeFncC.mHenkanGet(txtTRGTIME_From.Text)
        End Get
    End Property
    Public ReadOnly Property pTimeTo() As String
        Get
            Return TimeFncC.mHenkanGet(txtTRGTIME_To.Text)
        End Get
    End Property
    '2020/11/01 T.Ono add 2020監視改善
    '作動原因
    Public ReadOnly Property pTsadcd() As String
        Get
            If chkTSADCD.Checked = True Then
                Return "1"
            Else
                Return ""
            End If
        End Get
    End Property
    '2017/02/16 H.Mori add 改善2016 No8-2 END
    '******************************************************************************
    '*　概　要：絞込み条件を渡すプロパティ
    '*　備　考：(県コード)
    '******************************************************************************
    Public ReadOnly Property pCode1() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    ''運行開発部の場合は全ての監視センターを選択可能
                    ''以外の場合は代行を使用せずに自分の監視センターのみ使用可能
                    strRec = AuthC.pAUTHCENTERCD
                Case "1"
                    '2015/02/09 H.Hosoda add 監視改善2014 №14
                    ''運行開発部の場合は全ての監視センターを選択可能
                    ''以外の場合は代行を使用せずに自分の監視センターのみ使用可能
                    strRec = AuthC.pAUTHCENTERCD
                Case "2"
                    '2015/02/09 H.Hosoda mod 監視改善2014 №14 Start
                    'strRec = hdnKURACD.Value
                    strRec = hdnKURACD_From.Value
                    '2015/02/09 H.Hosoda mod 監視改善2014 №14 End
                Case "3"
                    'strRec = hdnKURACD_From.Value '2015/02/09 H.Hosoda add 監視改善2014 №14
                    strRec = hdnKURACD_To.Value    '2019/11/01 w.ganeko 2019監視改善 №4
                Case "4" '2015/02/09 H.Hosoda add 監視改善2014 №14
                    strRec = hdnKURACD_From.Value
                Case "5" '2015/02/09 H.Hosoda add 監視改善2014 №14
                    'strRec = hdnKURACD_From.Value '2019/11/01 w.ganeko 2019監視改善 №4
                    strRec = hdnKURACD_To.Value    '2019/11/01 w.ganeko 2019監視改善 №4
            End Select
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*　概　要：絞込み条件を渡すプロパティ
    '*　備　考：(供給センターコード/ＪＡコード)
    '******************************************************************************
    Public ReadOnly Property pCode2() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = ""
                Case "1"
                    strRec = ""
                Case "2"
                    strRec = ""
                    '2015/02/09 H.Hosoda mod 監視改善2014 №14 Start
                    'Case "3"
                Case Else
                    strRec = ""
                    '2015/02/09 H.Hosoda mod 監視改善2014 №14 End
            End Select
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
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = "クライアント一覧"
                Case "1"
                    strRec = "クライアント一覧" '2015/02/09 H.Hosoda add 監視改善2014 №14
                Case "2"
                    strRec = "ＪＡ一覧"
                Case "3"
                    strRec = "ＪＡ一覧"  '2015/02/09 H.Hosoda add 監視改善2014 №14
                Case "4" '2015/02/09 H.Hosoda add 監視改善2014 №14
                    strRec = "販売事業者グループ一覧"
                Case "5" '2015/02/09 H.Hosoda add 監視改善2014 №14
                    strRec = "販売事業者グループ一覧"
                Case Else '2015/02/09 H.Hosoda add 監視改善2014 №14
                    strRec = ""
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
                    strRec = "CLI"  '2015/02/09 H.Hosoda add 監視改善2014 №14
                Case "2"
                    strRec = "JA"
                Case "3"
                    strRec = "JA"   '2015/02/09 H.Hosoda add 監視改善2014 №14
                Case "4" '2015/02/09 H.Hosoda add 監視改善2014 №14
                    strRec = "HANG"
                Case "5" '2015/02/09 H.Hosoda add 監視改善2014 №14
                    strRec = "HANG"
                Case Else '2015/02/09 H.Hosoda add 監視改善2014 №14
                    strRec = ""
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
                    '2015/02/09 H.Hosoda mod 監視改善2014 №14 Start
                    'strRec = "hdnKURACD"
                    strRec = "hdnKURACD_From"
                    '2015/02/09 H.Hosoda mod 監視改善2014 №14 End
                Case "1"
                    strRec = "hdnKURACD_To"  '2015/02/09 H.Hosoda add 監視改善2014 №14
                Case "2"
                    '2015/02/09 H.Hosoda mod 監視改善2014 №14 Start
                    'strRec = "hdnJACD"
                    strRec = "hdnJACD_From"
                    '2015/02/09 H.Hosoda mod 監視改善2014 №14 End
                Case "3"
                    strRec = "hdnJACD_To"  '2015/02/09 H.Hosoda add 監視改善2014 №14
                Case "4"  '2015/02/09 H.Hosoda add 監視改善2014 №14
                    strRec = "hdnHANGRP_From"
                Case "5"  '2015/02/09 H.Hosoda add 監視改善2014 №14
                    strRec = "hdnHANGRP_To"
                Case Else  '2015/02/09 H.Hosoda add 監視改善2014 №14
                    strRec = ""
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
                    '2015/02/09 H.Hosoda mod 監視改善2014 №14 Start
                    'strRec = "txtKURACD"
                    strRec = "txtKURACD_From"
                    '2015/02/09 H.Hosoda mod 監視改善2014 №14 End
                Case "1"
                    strRec = "txtKURACD_To" '2015/02/09 H.Hosoda add 監視改善2014 №14
                Case "2"
                    '2015/02/09 H.Hosoda mod 監視改善2014 №14 Start
                    'strRec = "txtJACD"
                    strRec = "txtJACD_From"
                Case "3"
                    strRec = "txtJACD_To"  '2015/02/09 H.Hosoda add 監視改善2014 №14
                Case "4"  '2015/02/09 H.Hosoda add 監視改善2014 №14
                    strRec = "txtHANGRP_From"
                Case "5"  '2015/02/09 H.Hosoda add 監視改善2014 №14
                    strRec = "txtHANGRP_To"
                Case Else  '2015/02/09 H.Hosoda add 監視改善2014 №14
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
                        '2015/02/09 H.Hosoda mod 監視改善2014 №14 Start
                        'strRec = "btnKURACD"
                        strRec = "btnKURACD_From"
                        '2015/02/09 H.Hosoda mod 監視改善2014 №14 End
                    Case "1"
                        strRec = "btnKURACD_To"  '2015/02/09 H.Hosoda add 監視改善2014 №14
                    Case "2"
                        '2015/02/09 H.Hosoda mod 監視改善2014 №14 Start
                        'strRec = "btnKen1"
                        strRec = "btnJACD_From"
                        '2015/02/09 H.Hosoda mod 監視改善2014 №14 End
                    Case "3"
                        strRec = "btnJACD_To"  '2015/02/09 H.Hosoda add 監視改善2014 №14
                    Case "4"  '2015/02/09 H.Hosoda add 監視改善2014 №14
                        strRec = "btnHANGRP_From"
                    Case "5"  '2015/02/09 H.Hosoda add 監視改善2014 №14
                        strRec = "btnHANGRP_To"
                    Case Else  '2015/02/09 H.Hosoda add 監視改善2014 №14
                        strRec = ""
                End Select
            ElseIf hdnCalendar.Value = "1" Then
                strRec = "txtTRGDATE_From"
            ElseIf hdnCalendar.Value = "2" Then
                strRec = "txtTRGDATE_To"
            Else '2015/02/09 H.Hosoda add 監視改善2014 №14
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
                    '2015/02/09 H.Hosoda mod 監視改善2014 №14 Start
                    'strRec = "txtJACD"
                    strRec = "txtJACD_From,txtJACD_To,txtHANGRP_From,txtHANGRP_To"
                    '2015/02/09 H.Hosoda mod 監視改善2014 №14 End
                Case "1"
                    strRec = ""
                Case "2"
                    strRec = ""
                Case "3"
                    strRec = ""
                Case Else  '2015/02/09 H.Hosoda add 監視改善2014 №14
                    strRec = ""
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
                    '2015/02/09 H.Hosoda mod 監視改善2014 №14 Start
                    'strRec = "hdnJACD"
                    strRec = "hdnJACD_From,hdnJACD_To,hdnHANGRP_From,hdnHANGRP_To"
                    '2015/02/09 H.Hosoda mod 監視改善2014 №14 End
                Case "1"
                    strRec = ""
                Case "2"
                    strRec = ""
                    'Case "3"
                    '    strRec = ""
                Case Else '2015/02/09 H.Hosoda add 監視改善2014 №14
                    strRec = ""
            End Select
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*　概　要：リターン後に実行されるＪＳ '2015/02/10 H.Hosoda add 監視改善2014 №14
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pBackScript() As String
        Get
            Dim strRec As String
            strRec = "fncPGKBNDisp"
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
