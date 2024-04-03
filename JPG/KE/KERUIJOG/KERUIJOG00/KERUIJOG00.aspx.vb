'***********************************************
'累積情報一覧  一覧画面
'***********************************************
' 変更履歴
' 2011/02/01 T.Watabe 帳票エクセルを圧縮exe形式へ変更して転送する方法をやめる。そのまま転送。

Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common
Imports JPG.Common.log

Imports System.Text

Partial Class KERUIJOG00
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
    ' 時刻クラス                 2017/02/15 H.Mori add 2016改善開発 No9-1
    '******************************************************************************
    Protected TimeFncC As New CTimeFnc

    '******************************************************************************
    ' クッキー
    '******************************************************************************
    Protected ConstC As New CConst
    Protected WithEvents btnSelectTest As System.Web.UI.HtmlControls.HtmlInputButton

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
            txtKURACD.Attributes.Add("ReadOnly", "true")
            txtKYOCD.Attributes.Add("ReadOnly", "true")
            '2015/11/04 W.GANEKO 2015改善開発 №6 start
            'txtJACD.Attributes.Add("ReadOnly", "true")
            'txtJASCD.Attributes.Add("ReadOnly", "true")
            txtHANJICD_F.Attributes.Add("ReadOnly", "true")
            txtHANJICD_T.Attributes.Add("ReadOnly", "true")
            txtJACD_F.Attributes.Add("ReadOnly", "true")
            txtJACD_T.Attributes.Add("ReadOnly", "true")
            txtJASCD_F.Attributes.Add("ReadOnly", "true")
            txtJASCD_T.Attributes.Add("ReadOnly", "true")
            '2015/11/04 W.GANEKO 2015改善開発 №6 end
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
        '[対応結果一覧]使用可能権限(運:○/営:×/監:△/出:×)
        '20051201 NEC UPDATE START
        '[対応結果一覧]使用可能権限(運:○/営:○/監:△/出:×)
        'AuthC.fncAuthCheck(Server, AuthC.pGROUP_UNKOU & "," & AuthC.pGROUP_KANSHI)
        AuthC.fncAuthCheck(Server, AuthC.pGROUP_UNKOU & "," & AuthC.pGROUP_KANSHI & "," & AuthC.pGROUP_EIGYOU)
        '20051201 NEC UPDATE END

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
        If hdnKensaku.Value = "KERUIJCG00" Then
            Server.Transfer("./KERUIJCG00.aspx")
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
             MyBase.MapPath("../../../KE/KERUIJOG/KERUIJOG00/") & "KERUIJOG00.js"))
        '<フォーカス関連関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncFo.js"))
        '<日付関連関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncDate.js"))
        '<時間関連関数> 
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncTime.js")) '2017/02/14 H.Mori add 改善2016 No9-1
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

            '対象期間に当日日付を表示　2013/12/05 T.Ono add 監視改善2013
            txtTRGDATE_From.Text = DateTime.Today.ToString("yyyy/MM/dd")
            txtTRGDATE_To.Text = DateTime.Today.ToString("yyyy/MM/dd")

            '//フォーカスをセットする
            strMsg.Append("Form1.btnKURACD.focus();")
        Else
            '//--------------------------------------
            '//　２回目以降実行される
            '//--------------------------------------------------------------------------
            '//※画面表示するコンボボックスは各最終イベント/メソッドでCALLします
            '//--------------------------------------------------------------------------
        End If

        '//-------------------------------------------------
        '<TODO>自分の画面IDをHIDDENのhdnMyAspxに書き込む（システム共通）
        hdnMyAspx.Value = "KERUIJOG00"
        '//-------------------------------------------------

    End Sub

    '******************************************************************************
    ' Excel出力(チェックつき)
    '******************************************************************************
    Private Sub btnSelect_ServerClick(ByVal sender As System.Object, _
                                    ByVal e As System.EventArgs) Handles btnSelect.ServerClick
        Dim strRec As String
        'Dim bytExcel() As Byte '2014/01/16 T.Ono del 改善対応2013 Excelを直接出力に変更
        Dim KERUIJOG00C As New KERUIJOG00KERUIJOW00.KERUIJOW00

        Dim strSTKBN As String
        Dim strPGKBN As String
        Dim strKIKANKBN As String '2017/02/15 H.Mori add 改善2016 No9-1

        '//　認証クラスのインスタンス生成
        AuthC = New CAuthenticate(Request, Response)

        '発生区分取得
        If rdoSTKBN1.Checked = True Then
            strSTKBN = "1"      '電話
        ElseIf rdoSTKBN2.Checked = True Then
            strSTKBN = "2"      '警報
        ElseIf rdoSTKBN3.Checked = True Then
            '2011.11.21 ADD H.Uema
            strSTKBN = "3"
        Else
            strSTKBN = ""
        End If
        '改ページ条件
        If rdoPGKBN1.Checked = True Then
            strPGKBN = "1"      'JA単位
            '2015/11/04 W.GANEKO 2015改善開発 №6 start
            'ElseIf rdoPGKBN2.Checked = True Then
            '    strPGKBN = "2"      '供給センター単位
            'Else
            '    strPGKBN = "3"      '改ページなし
            'End If
        ElseIf rdoPGKBN2.Checked = True Then
            strPGKBN = "2"      'JA支所単位
        ElseIf rdoPGKBN3.Checked = True Then
            strPGKBN = "3"      '販売事業者単位
        ElseIf rdoPGKBN4.Checked = True Then
            strPGKBN = "4"      '供給センター単位
        Else
            strPGKBN = "5"      '改ページなし
        End If
        '2015/11/04 W.GANEKO 2015改善開発 №6 end
        '2015/11/04 w.ganeko 2015改善開発 №6 start
        Dim strHOKOKU As String = ""
        '報告要・不要
        If rdoHOKOKU1.Checked = True Then
            strHOKOKU = "2"      '必要のみ
        ElseIf rdoHOKOKU2.Checked = True Then
            strHOKOKU = "0"      '全て
        End If
        Dim strTAIO As New StringBuilder("")
        '対応区分
        '電話
        If checkTEL.Checked = True Then
            strTAIO.Append("1")      '電話
        Else
            strTAIO.Append("0")      '電話
        End If
        '出動
        strTAIO.Append(",")
        If checkSYTUDO.Checked = True Then
            strTAIO.Append("2")      '出動
        Else
            strTAIO.Append("0")      '出動
        End If
        '重複
        strTAIO.Append(",")
        If checkTYOFUKU.Checked = True Then
            strTAIO.Append("3")
        Else
            strTAIO.Append("0")
        End If
        '2015/11/04 w.ganeko 2015改善開発 №6 end

        '出動依頼内容・備考    2020/11/01 T.Ono add 2020監視改善
        Dim strSdPrtKBN As String '2020/11/01 T.Ono add 2020監視改善
        If checkSdPrt.Checked = True Then
            strSdPrtKBN = "1"     '表示あり
        Else
            strSdPrtKBN = "0"     '表示なし
        End If

        '2017/02/15 H.Mori add 改善2016 No9-1 START
        '対象期間区分取得 2014/12/11 H.Hosoda add 監視改善2014 №13
        If rdoKIKAN1.Checked = True Then
            strKIKANKBN = "1"     '対応完了日
        Else
            strKIKANKBN = "2"     '受信日
        End If
        '2017/02/15 H.Mori add 改善2016 No9-1 END

        Dim strRecMsg As String = ""

        '2012/04/04 NEC ou Upd
        'strRec = KERUIJOG00C.mExcel( _
        '                         Request.Cookies.Get("ASP.NET_SessionId").Value, _
        '                         hdnKURACD.Value, _
        '                         hdnKYOCD.Value, _
        '                         hdnJACD.Value, _
        '                         hdnJASCD.Value, _
        '                         strSTKBN, _
        '                         strPGKBN, _
        '                         DateFncC.mHenkanGet(txtTRGDATE_From.Text), _
        '                         DateFncC.mHenkanGet(txtTRGDATE_To.Text), _
        '                         txtKURACD.Text, _
        '                         txtKYOCD.Text, _
        '                         txtJACD.Text, _
        '                         txtJASCD.Text, _
        '                         ConstC.pPageMax, _
        '                         AuthC.pCENTERCD _
        '                         )
        '2015/11/04 W.GANEKO 2015改善開発 №6 start
        'strRec = KERUIJOG00C.mExcel( _
        '                         Me.Session.SessionID, _
        '                         hdnKURACD.Value.Trim, _
        '                         hdnKYOCD.Value.Trim, _
        '                         hdnJACD.Value.Trim, _
        '                         hdnJASCD.Value.Trim, _
        '                         strSTKBN, _
        '                         strPGKBN, _
        '                         DateFncC.mHenkanGet(txtTRGDATE_From.Text), _
        '                         DateFncC.mHenkanGet(txtTRGDATE_To.Text), _
        '                         txtKURACD.Text, _
        '                         txtKYOCD.Text, _
        '                         txtJACD.Text, _
        '                         txtJASCD.Text, _
        '                         ConstC.pPageMax, _
        '                         AuthC.pCENTERCD _
        '                         )
        '2017/02/15 H.Mori mod 改善2016 No9-1 START
        'strRec = KERUIJOG00C.mExcel( _
        '                         Me.Session.SessionID, _
        '                         hdnKURACD.Value.Trim, _
        '                         hdnKYOCD.Value.Trim, _
        '                         hdnJACD_F.Value.Trim, _
        '                         hdnJACD_T.Value.Trim, _
        '                         hdnJASCD_F.Value.Trim, _
        '                         hdnJASCD_T.Value.Trim, _
        '                         strSTKBN, _
        '                         strPGKBN, _
        '                         DateFncC.mHenkanGet(txtTRGDATE_From.Text), _
        '                         DateFncC.mHenkanGet(txtTRGDATE_To.Text), _
        '                         txtKURACD.Text, _
        '                         txtKYOCD.Text, _
        '                         txtJACD_F.Text, _
        '                         txtJACD_T.Text, _
        '                         txtJASCD_F.Text, _
        '                         txtJASCD_T.Text, _
        '                         ConstC.pPageMax, _
        '                         AuthC.pCENTERCD, _
        '                         hdnHANJICD_F.Value.Trim, _
        '                         hdnHANJICD_T.Value.Trim, _
        '                         strTAIO.ToString, _
        '                         strHOKOKU, _
        '                         txtHANJICD_F.Text, _
        '                         txtHANJICD_T.Text _
        '                         )
        'TODO
        '2015/11/04 W.GANEKO 2015改善開発 №6 end

        '2012/04/04 NEC ou Upd
        '2020/11/01 T.Ono mod 2020監視改善 strSdPrtKBN 追加
        strRec = KERUIJOG00C.mExcel(
                                 Me.Session.SessionID,
                                 hdnKURACD.Value.Trim,
                                 hdnKYOCD.Value.Trim,
                                 hdnJACD_F.Value.Trim,
                                 hdnJACD_T.Value.Trim,
                                 hdnJASCD_F.Value.Trim,
                                 hdnJASCD_T.Value.Trim,
                                 strSTKBN,
                                 strPGKBN,
                                 DateFncC.mHenkanGet(txtTRGDATE_From.Text),
                                 DateFncC.mHenkanGet(txtTRGDATE_To.Text),
                                 txtKURACD.Text,
                                 txtKYOCD.Text,
                                 txtJACD_F.Text,
                                 txtJACD_T.Text,
                                 txtJASCD_F.Text,
                                 txtJASCD_T.Text,
                                 ConstC.pPageMax,
                                 AuthC.pCENTERCD,
                                 hdnHANJICD_F.Value.Trim,
                                 hdnHANJICD_T.Value.Trim,
                                 strTAIO.ToString,
                                 strHOKOKU,
                                 txtHANJICD_F.Text,
                                 txtHANJICD_T.Text,
                                 strKIKANKBN,
                                 TimeFncC.mHenkanGet(txtTRGTIME_From.Text),
                                 TimeFncC.mHenkanGet(txtTRGTIME_To.Text),
                                 strSdPrtKBN
                                 )

        '2017/02/15 H.Mori mod 改善2016 No9-1 END

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
            '2011/02/10 T.Watabe 元の方式へ戻す。
            If True Then
                '「開く、保存」のダイヤログが出るようにHTTPヘッダに追加
                'ファイル名は、HttpUtility.UrlEncodeメソッドを使用してSJISにエンコードする必要がある
                '.xls形式に変更 2013/12/05 T.Ono mod 監視改善2013
                'HttpHeaderC.mDownLoad(Response, "累積情報一覧.exe") ' 2011/02/01 T.Watabe edit
                HttpHeaderC.mDownLoadXLS(Response, "累積情報一覧.xls")
                '2014/01/16 T.Ono mod 監視改善2013 excelを直接開く Start
                'bytExcel = Convert.FromBase64String(strRec) 'Webサービスの戻り値（BASE64のテキスト）をバイトデータに変換する
                'Response.BinaryWrite(bytExcel) 'ファイル送信
                Response.WriteFile(strRec)
                '2014/01/16 T.Ono mod 監視改善2013 excelを直接開く End
                Response.End()
            Else
                '2011/02/01 T.Watabe エクセルを直接ダウンロードするように変更
                Dim sFile As String
                Dim sPath As String
                Dim pos As Integer
                pos = strRec.LastIndexOf("\\")
                If pos <= 0 Then
                    strRecMsg = "ファイルパスに￥マークが含まれていません。[" & strRec & "]"
                    strMsg.Append("alert('" & strRecMsg & "');")
                    strMsg.Append("Form1.btnSelect.focus();")
                Else
                    'sFile = "20110204143856rbz1mou53ostff55k12fv02a-KERUIJOX00.xls"
                    sFile = strRec.Substring(pos + 1)
                    sFile = HttpUtility.UrlEncode(sFile)
                    'sPath = "/JPGAP/TEMP/00/KERUIJOX00/"
                    'sPath = Server.MapPath(sPath)
                    sPath = strRec.Substring(0, pos)
                    sPath = HttpUtility.UrlEncode(sPath)
                    Response.Redirect("/JPG/test2.aspx?file=" & sFile & "&path=" & sPath)
                    Response.End()
                End If
            End If

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

    Private Sub btnSelectTest_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectTest.ServerClick

        Dim sFile As String
        Dim sPath As String
        sFile = "20110204143856rbz1mou53ostff55k12fv02a-KERUIJOX00.xls"
        sFile = HttpUtility.UrlEncode(sFile)
        sPath = "/JPGAP/TEMP/00/KERUIJOX00/"
        sPath = Server.MapPath(sPath)
        sPath = HttpUtility.UrlEncode(sPath)
        Response.Redirect("/JPG/test2.aspx?file=" & sFile & "&path=" & sPath)
        Response.End()
    End Sub
    '******************************************************************************
    '* 件数チェック用画面に渡すパラメータ設定
    '******************************************************************************
    Public ReadOnly Property pKuracd() As String
        Get
            Return hdnKURACD.Value.Trim     '2012/04/04 NEC ou Add Upd
        End Get
    End Property
    Public ReadOnly Property pKyocd() As String
        Get
            Return hdnKYOCD.Value.Trim      '2012/04/04 NEC ou Add Upd
        End Get
    End Property
    '2015/11/04 w.ganeko 2015改善開発 №6 start
    'Public ReadOnly Property pJacd() As String
    '    Get
    '        Return hdnJACD.Value.Trim       '2012/04/04 NEC ou Add Upd
    '    End Get
    'End Property
    'Public ReadOnly Property pJascd() As String
    '    Get
    '        Return hdnJASCD.Value.Trim      '2012/04/04 NEC ou Add Upd
    '    End Get
    'End Property
    Public ReadOnly Property pJacdFr() As String
        Get
            Return hdnJACD_F.Value.Trim
        End Get
    End Property
    Public ReadOnly Property pJacdTo() As String
        Get
            Return hdnJACD_T.Value.Trim
        End Get
    End Property
    Public ReadOnly Property pJascdFr() As String
        Get
            Return hdnJASCD_F.Value.Trim
        End Get
    End Property
    Public ReadOnly Property pJascdTo() As String
        Get
            Return hdnJASCD_T.Value.Trim
        End Get
    End Property
    Public ReadOnly Property pHanbaiFr() As String
        Get
            Return hdnHANJICD_F.Value.Trim()
        End Get
    End Property
    Public ReadOnly Property pHanbaiTo() As String
        Get
            Return hdnHANJICD_T.Value.Trim
        End Get
    End Property
    Public ReadOnly Property pHkKbn() As String
        Get
            Dim strHOKOKU As String = ""
            '報告要・不要
            If rdoHOKOKU1.Checked = True Then
                strHOKOKU = "2"      '必要のみ
            ElseIf rdoHOKOKU2.Checked = True Then
                strHOKOKU = "0"      '全て
            End If
            Return strHOKOKU
        End Get
    End Property
    Public ReadOnly Property pTaiKbn() As String
        Get
            Dim strTAIO As New StringBuilder("")
            '対応区分
            '電話
            If checkTEL.Checked = True Then
                strTAIO.Append("1")      '電話
            Else
                strTAIO.Append("0")      '電話
            End If
            '出動
            strTAIO.Append(",")
            If checkSYTUDO.Checked = True Then
                strTAIO.Append("2")      '出動
            Else
                strTAIO.Append("0")      '出動
            End If
            '重複
            strTAIO.Append(",")
            If checkTYOFUKU.Checked = True Then
                strTAIO.Append("3")
            Else
                strTAIO.Append("0")
            End If

            Return strTAIO.ToString
        End Get
    End Property
    '2015/11/04 w.ganeko 2015改善開発 №6 end
    Public ReadOnly Property pHatKbn() As String
        Get
            Dim strSTKBN As String
            If rdoSTKBN1.Checked = True Then
                strSTKBN = "1"      '電話
            ElseIf rdoSTKBN2.Checked = True Then
                strSTKBN = "2"      '警報
            ElseIf rdoSTKBN3.Checked = True Then
                '2011.11.21 ADD H.Uema
                strSTKBN = "3"
            Else
                strSTKBN = ""
            End If

            Return strSTKBN
        End Get
    End Property
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
    '2017/02/15 H.Mori add 改善2016 No9-1 START
    Public ReadOnly Property pKikankbn() As String
        Get
            Dim strKIKANKBN As String = ""
            '対象期間区分
            If rdoKIKAN1.Checked = True Then
                strKIKANKBN = "1"      '対応完了日
            ElseIf rdoKIKAN2.Checked = True Then
                strKIKANKBN = "2"      '受信日
            End If
            Return strKIKANKBN
        End Get
    End Property
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
    '2017/02/15 H.Mori add 改善2016 No9-1 END

    '******************************************************************************
    '*　概　要：絞込み条件を渡すプロパティ
    '*　備　考：(県コード)
    '******************************************************************************
    Public ReadOnly Property pCode1() As String
        Get
            Dim strRec As String
            '2015/11/04 W.GANEKO 2015改善開発 №6 START
            'Select Case hdnPopcrtl.Value
            '    Case "0"
            ' 2007/08/09 T.Watabe edit 代行している監視センターのクライアントも表示されるように変更
            ''運行開発部の場合は全ての監視センターを選択可能
            ''以外の場合は代行を使用せずに自分の監視センターのみ使用可能
            'Dim strGROUPNAME As String = AuthC.pGROUPNAME
            'Dim arrGroupName() As String = strGROUPNAME.Split(Convert.ToChar(","))
            'If Array.IndexOf(arrGroupName, AuthC.pGROUP_UNKOU) >= 0 Then
            'strRec = AuthC.pAUTHCENTERCD
            'Else
            '    strRec = AuthC.pCENTERCD
            'End If
            '    Case "1"
            'strRec = ""
            'If hdnKURACD.Value <> "" Then
            'strRec = hdnKURACD.Value.Substring(1, 2)        ''クライアントコード(4)→JA支所コード(1)＋県コード(2)＋任意1文字(1)
            'End If
            '    Case "2"
            'strRec = hdnKURACD.Value       2014/01/21 T.Ono mod 監視改善2013 Trimをつける
            'strRec = hdnKURACD.Value.Trim
            '    Case "3"
            'strRec = hdnKURACD.Value       2014/01/21 T.Ono mod 監視改善2013 Trimをつける
            'strRec = hdnKURACD.Value.Trim
            'End Select
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = AuthC.pAUTHCENTERCD
                Case "1"
                    strRec = ""
                    If hdnKURACD.Value <> "" Then
                        strRec = hdnKURACD.Value.Substring(1, 2)        ''クライアントコード(4)→JA支所コード(1)＋県コード(2)＋任意1文字(1)
                    End If
                Case "2", "3", "4", "5", "6", "7"
                    strRec = hdnKURACD.Value.Trim
            End Select
            '2015/11/04 W.GANEKO 2015改善開発 №6 END
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
            '2015/11/04 W.GANEKO 2015改善開発 №6 START
            'Select Case hdnPopcrtl.Value
            '    Case "0"
            'strRec = ""
            '    Case "1"
            'strRec = ""
            '    Case "2"
            ''strRec = hdnKYOCD.Value    '--- 2005/05/24 MOD Falcon ---
            'strRec = ""
            '    Case "3"
            ''strRec = hdnJACD.Value       2014/01/21 T.Ono mod 監視改善2013 Trimをつける
            'strRec = hdnJACD.Value.Trim
            'End Select
            Select Case hdnPopcrtl.Value
                Case "0", "1", "2", "3", "6", "7"
                    strRec = ""

                '2019/11/01 T.Ono mod 監視改善2019 START
                'Case "4", "5"
                '    strRec = hdnJACD_F.Value.Trim
                Case "4"
                    strRec = hdnJACD_F.Value.Trim
                Case "5"
                    strRec = hdnJACD_T.Value.Trim
                    '2019/11/01 T.Ono mod 監視改善2019 END
            End Select
            '2015/11/04 W.GANEKO 2015改善開発 №6 END
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
            '2015/11/04 W.GANEKO 2015改善開発 №6 START
            'Select Case hdnPopcrtl.Value
            '    Case "0"
            'strRec = "クライアント一覧"
            '    Case "1"
            'strRec = "供給センター一覧"
            '    Case "2"
            'strRec = "ＪＡ一覧"
            '    Case "3"
            'strRec = "ＪＡ支所一覧"
            'End Select
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = "クライアント一覧"
                Case "1"
                    strRec = "供給センター一覧"
                Case "2", "3"
                    strRec = "ＪＡ一覧"
                Case "4", "5"
                    strRec = "ＪＡ支所一覧"
                Case "6", "7"
                    strRec = "販売事業者一覧"
            End Select
            '2015/11/04 W.GANEKO 2015改善開発 №6 END
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
            '2015/11/04 W.GANEKO 2015改善開発 №6 START
            'Select Case hdnPopcrtl.Value
            '    Case "0"
            'strRec = "CLI"
            '    Case "1"
            'strRec = "KYO"
            '    Case "2"
            'strRec = "JA"
            '    Case "3"
            'strRec = "JASS"
            'End Select
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = "CLI"
                Case "1"
                    strRec = "KYO"
                Case "2", "3"
                    strRec = "JA"
                Case "4", "5"
                    strRec = "JASS"
                Case "6", "7"
                    strRec = "HANG"
            End Select
            '2015/11/04 W.GANEKO 2015改善開発 №6 END
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
            '2015/11/04 W.GANEKO 2015改善開発 №6 START
            'Select Case hdnPopcrtl.Value
            '    Case "0"
            'strRec = "hdnKURACD"
            '    Case "1"
            'strRec = "hdnKYOCD"
            '    Case "2"
            'strRec = "hdnJACD"
            '    Case "3"
            'strRec = "hdnJASCD"
            'End Select
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = "hdnKURACD"
                Case "1"
                    strRec = "hdnKYOCD"
                Case "2"
                    strRec = "hdnJACD_F"
                Case "3"
                    strRec = "hdnJACD_T"
                Case "4"
                    strRec = "hdnJASCD_F"
                Case "5"
                    strRec = "hdnJASCD_T"
                Case "6"
                    strRec = "hdnHANJICD_F"
                Case "7"
                    strRec = "hdnHANJICD_T"
            End Select
            '2015/11/04 W.GANEKO 2015改善開発 №6 END
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
            '2015/11/04 W.GANEKO 2015改善開発 №6 START
            'Select Case hdnPopcrtl.Value
            '    Case "0"
            'strRec = "txtKURACD"
            '    Case "1"
            'strRec = "txtKYOCD"
            '    Case "2"
            'strRec = "txtJACD"
            '    Case "3"
            'strRec = "txtJASCD"
            'End Select
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = "txtKURACD"
                Case "1"
                    strRec = "txtKYOCD"
                Case "2"
                    strRec = "txtJACD_F"
                Case "3"
                    strRec = "txtJACD_T"
                Case "4"
                    strRec = "txtJASCD_F"
                Case "5"
                    strRec = "txtJASCD_T"
                Case "6"
                    strRec = "txtHANJICD_F"
                Case "7"
                    strRec = "txtHANJICD_T"
            End Select
            '2015/11/04 W.GANEKO 2015改善開発 №6 END
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
                '2015/11/04 W.GANEKO 2015改善開発 №6 START
                'Select Case hdnPopcrtl.Value
                '    Case "0"
                'strRec = "btnKURACD"
                '    Case "1"
                'strRec = "btnKYOCD"
                '    Case "2"
                'strRec = "btnKen1"
                '    Case "3"
                'strRec = "btnKen2"
                'End Select
                Select Case hdnPopcrtl.Value
                    Case "0"
                        strRec = "btnKURACD"
                    Case "1"
                        strRec = "btnKYOCD"
                    Case "2"
                        strRec = "btnKen1_F"
                    Case "3"
                        strRec = "btnKen1_T"
                    Case "4"
                        strRec = "btnKen2_F"
                    Case "5"
                        strRec = "btnKen2_T"
                    Case "6"
                        strRec = "btnHANJICD_F"
                    Case "7"
                        strRec = "btnHANJICD_T"
                End Select
                '2015/11/04 W.GANEKO 2015改善開発 №6 END
            ElseIf hdnCalendar.Value = "1" Then
                strRec = "txtTRGDATE_From"
            ElseIf hdnCalendar.Value = "2" Then
                strRec = "txtTRGDATE_To"
            End If
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*　概　要：リターン後に実行されるＪＳ　2019/11/01 T.Ono add 監視改善2019
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pBackScript() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = ""
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
                Case "6"
                    strRec = "fncSetTo"
                Case "7"
                    strRec = ""
                Case Else
                    strRec = ""
            End Select
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
            '2015/11/04 W.GANEKO 2015改善開発 №6 START
            'Select Case hdnPopcrtl.Value
            '    Case "0"
            'strRec = "txtKYOCD,txtJACD,txtJASCD"
            '    Case "1"
            'strRec = "txtJACD,txtJASCD"
            '    Case "2"
            'strRec = "txtJASCD"
            '    Case "3"
            'strRec = ""
            'End Select
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = "txtKYOCD,txtHANJICD_F,txtHANJICD_T,txtJACD_F,txtJACD_T,txtJASCD_F,txtJASCD_T"
                Case "1"
                    strRec = "txtHANJICD_F,txtHANJICD_T,txtJACD_F,txtJACD_T,txtJASCD_F,txtJASCD_T"
                Case "2", "3"
                    strRec = "txtJASCD_F,txtJASCD_T"
                Case "4", "5"
                    strRec = ""
                Case "6", "7"
                    strRec = "txtJACD_F,txtJACD_T,txtJASCD_F,txtJASCD_T"
            End Select
            '2015/11/04 W.GANEKO 2015改善開発 №6 END
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
            '2015/11/04 W.GANEKO 2015改善開発 №6 START
            'Select Case hdnPopcrtl.Value
            '    Case "0"
            'strRec = "hdnKYOCD,hdnJACD,hdnJASCD"
            '    Case "1"
            'strRec = "hdnJACD,hdnJASCD"
            '    Case "2"
            'strRec = "hdnJASCD"
            '    Case "3"
            'strRec = ""
            'End Select
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = "hdnKYOCD,hdnHANJICD_F,hdnHANJICD_T,hdnJACD_F,hdnJACD_T,hdnJASCD_F,hdnJASCD_T"
                Case "1"
                    strRec = "hdnHANJICD_F,hdnHANJICD_T,hdnJACD_F,hdnJACD_T,hdnJASCD_F,hdnJASCD_T"
                Case "2", "3"
                    strRec = "hdnJASCD_F,hdnJASCD_T"
                Case "4", "5"
                    strRec = ""
                Case "6", "7"
                    strRec = "hdnJACD_F,hdnJACD_T,hdnJASCD_F,hdnJASCD_T"
            End Select
            '2015/11/04 W.GANEKO 2015改善開発 №6 END
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
