'***********************************************
' 緊急出動確認・入力
'***********************************************
' 変更履歴
' 2009/01/09 T.Watabe ボンベ情報を追加

'<TODO>宣言共通仕様
Option Explicit On
Option Strict On

'<TODO>宣言共通仕様
Imports Common
Imports JPG.Common
Imports System.Text

Partial Class SDSYUJAG00
    Inherits System.Web.UI.Page
    Protected WithEvents txtAYMD As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtUYMD As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSIJI_BIKO1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtJUTEL As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTIZUN As System.Web.UI.WebControls.TextBox
    'Protected WithEvents txtZENKAI_HAISO As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtZENKAI_HAS_S As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtMETMAKER As System.Web.UI.WebControls.TextBox
    Protected WithEvents cboAITCD As JPG.Common.Controls.CTLCombo
    'Protected WithEvents cboASECD As JPG.Common.Controls.CTLCombo  ' 2008/10/16 T.Watabe edit
    'Protected WithEvents cboSTACD As JPG.Common.Controls.CTLCombo  ' 2008/10/16 T.Watabe edit


    '▼ 2009/01/09 T.Watabe add
    '▲ 2009/01/09 T.Watabe add

    Protected SDSYUJAG00_C As SDSYUJAG00
    Protected ConstC As New CConst

    Private strSYU_CD As String = ""    '出動会社コード(クッキーより取得した値を格納する
    Private strKANSCD As String
    Private strSYONO As String

    '<TODO>宣言共通仕様
    '******************************************************************************
    ' HttpHeader
    '******************************************************************************
    Protected HttpHeaderC As New CHttpHeader

    ''<TODO>宣言共通仕様
    ''******************************************************************************
    '' 認証クラス
    ''******************************************************************************
    'Protected AuthC As CAuthenticate

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

    ' 2014/10/22 H.Hosoda del 1line 2014改善開発 No11
    'Private strCBO_TSTANCD As String
    Private strCBO_STD_CD As String
    Private strCBO_KYOTEN_CD As String
    Private strCBO_AITCD As String
    Private strCBO_KIGCD As String
    Private strCBO_SADCD As String
    Private strCBO_ASECD As String
    Private strCBO_STACD As String
    Private strCBO_FKICD As String
    Private strCBO_HANASI As String

    '******************************************************************************
    '登録系フレームワークPublic変数　（登録・削除時に格納します。）
    '******************************************************************************
    Public gstrKBN As String
    Public gstrMyAspx As String

    Public gstrKANSCD As String                 '監査コード
    Public gstrSYONO As String                  '処理番号
    Public gstrMOVE_SIJIYMD_F As String
    Public gstrMOVE_SIJIYMD_T As String
    Public gstrMOVE_KBN As String
    Public gstrMOVE_CLI_CD As String            'クライアントコード 2013/12/12 T.Ono add 監視改善2013
    Public gstrMOVE_CLI_CD_NAME As String       'クライアント名 2013/12/12 T.Ono add 監視改善2013
    Public gstrMOVE_JA_CD As String             'JAコード 2013/12/12 T.Ono add 監視改善2013
    Public gstrMOVE_JA_CD_NAME As String        'JA名 2013/12/12 T.Ono add 監視改善2013
    Public gstrMOVE_GROUP_CD As String          '販売事業者グループコード 2014/10/21 H.Hosoda add 監視改善2014 No10
    Public gstrMOVE_GROUP_CD_NAME As String     '販売事業者グループ名 2014/10/21 H.Hosoda add 監視改善2014 No10
    Public gstrTSTANCD As String                '受信者コード
    Public gstrTSTANNM As String                '受信者名 2014/10/23 H.Hosoda add 2014改善開発 No11
    Public gstrSTD_CD As String                 '出動会社コード
    Public gstrSTD_KYOTEN_CD As String          '所属(拠点)
    Public gstrSYUTDTNM As String               '出動対応者
    Public gstrJUYMD As String                  '対応受信日時（日付）
    Public gstrJUTIME As String                 '対応受信日時（時間）
    Public gstrSDYMD As String                  '出動日時（日付） 2008/10/14 T.Watabe add
    Public gstrSDTIME As String                 '出動日時（時間） 2008/10/14 T.Watabe add
    Public gstrTYAKYMD As String                '到着日時（日付）
    Public gstrTYAKTIME As String               '到着日時（時間）
    Public gstrSYOKANYMD As String              '処理対応完了日時（日付）
    Public gstrSYOKANTIME As String             '処理対応完了日時（時間）
    Public gstrAITCD As String                  '対応相手
    Public gstrMETHEIKAKU As String             'メータ表示遮断弁閉止確認
    Public gstrRUSUHAIRI As String              '留守宅表示の貼付
    Public gstrKIGCD As String                  'ガス器具原因
    Public gstrSADCD As String                  'メータ作動原因
    Public gstrASECD As String                  'メータ作動原因（圧力センサー作動原因）
    Public gstrSTACD As String                  'その他原因
    Public gstrFKICD As String                  '復帰対応
    Public gstrJAKENREN As String               'ＪＡ／県連の連絡相手
    Public gstrRENTIME As String                '連絡時間
    Public gstrKIGUTAIYO As String              '簡易ガス器具の貸与
    Public gstrGASMUMU As String                'ガス漏れ点検
    Public gstrORGENIN As String                'ガス漏れ原因(ガス器具)
    Public gstrHAIKAN As String                 'ガス漏れ原因(配管)
    Public gstrGASUGUMU As String               'ガス切れ原因
    Public gstrHOSKOKAN As String               'ゴムホース交換
    Public gstrMETYOINA As String               'その他点検項目（メーター）
    Public gstrTYOUYOINA As String              'その他点検項目（調整機）
    Public gstrVALYOINA As String               'その他点検項目（容器・中間バルブ）
    Public gstrKYUHAIUMU As String              'その他点検項目（吸排気口）
    Public gstrCOYOINA As String                'その他点検項目（ＣＯ濃度）
    Public gstrSDTBIK2 As String                '特記事項
    Public gstrSNTTOKKI As String               'その他特記事項（ＪＡ／県連への依頼等）
    '2006/06/15 NEC ADD START
    Public gstrSDTBIK3 As String                '出動結果内容/報告
    '2006/06/15 NEC ADD END
    Public gstrADD_DATE As String
    Public gstrEDT_DATE As String
    Public gstrEDT_TIME As String

    Public gstrMETFUKKI As String
    Public gstrHOAN As String
    Public gstrGASGIRE As String
    Public gstrKIGKOSYO As String
    Public gstrCSNTGEN As String
    Public gstrCSNTNGAS As String
    Public gstrSDTBIK1 As String                '特記事項

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

        '2012/04/06 NEC ou Add Str
        '.NETの仕様変更により、ReadOnly属性をASPXでつけると、サーバ側で値の参照ができなくなるため、VB側でAttributeでつける
        If MyBase.IsPostBack = False Then
            txtKENNM.Attributes.Add("ReadOnly", "true")
            txtHAISO_NAME.Attributes.Add("ReadOnly", "true")
            txtJANM.Attributes.Add("ReadOnly", "true")
            txtSYONO.Attributes.Add("ReadOnly", "true")
            txtHATYMD.Attributes.Add("ReadOnly", "true")
            txtHATTIME.Attributes.Add("ReadOnly", "true")
            txtHATKBN.Attributes.Add("ReadOnly", "true")
            txtSIJIYMD.Attributes.Add("ReadOnly", "true")
            txtSIJITIME.Attributes.Add("ReadOnly", "true")
            txtTKTANCD_NM.Attributes.Add("ReadOnly", "true")
            txtSDNM.Attributes.Add("ReadOnly", "true")
            txtSIJI_BIKO.Attributes.Add("ReadOnly", "true")
            txtJUSYONM.Attributes.Add("ReadOnly", "true")
            txtJUSYOKN.Attributes.Add("ReadOnly", "true")
            txtKTELNO.Attributes.Add("ReadOnly", "true")
            txtADDR.Attributes.Add("ReadOnly", "true")
            txtTIZUNO.Attributes.Add("ReadOnly", "true")
            txtKMNO1.Attributes.Add("ReadOnly", "true")
            txtKMNM1.Attributes.Add("ReadOnly", "true")
            txtKMNO2.Attributes.Add("ReadOnly", "true")
            txtKMNM2.Attributes.Add("ReadOnly", "true")
            txtKMNO3.Attributes.Add("ReadOnly", "true")
            txtKMNM3.Attributes.Add("ReadOnly", "true")
            txtKMNO4.Attributes.Add("ReadOnly", "true")
            txtKMNM4.Attributes.Add("ReadOnly", "true")
            txtKMNO5.Attributes.Add("ReadOnly", "true")
            txtKMNM5.Attributes.Add("ReadOnly", "true")
            txtKMNO6.Attributes.Add("ReadOnly", "true")
            txtKMNM6.Attributes.Add("ReadOnly", "true")
            txtGAS1_HINMEI.Attributes.Add("ReadOnly", "true")
            txtGAS1_DAISU.Attributes.Add("ReadOnly", "true")
            txtGAS2_HINMEI.Attributes.Add("ReadOnly", "true")
            txtGAS2_DAISU.Attributes.Add("ReadOnly", "true")
            txtGAS3_HINMEI.Attributes.Add("ReadOnly", "true")
            txtGAS3_DAISU.Attributes.Add("ReadOnly", "true")
            txtGAS4_HINMEI.Attributes.Add("ReadOnly", "true")
            txtGAS4_DAISU.Attributes.Add("ReadOnly", "true")
            txtBONB1_KKG.Attributes.Add("ReadOnly", "true")
            txtBONB1_HON.Attributes.Add("ReadOnly", "true")
            txtBONB1_RKG.Attributes.Add("ReadOnly", "true")
            txtBONB2_KKG.Attributes.Add("ReadOnly", "true")
            txtBONB2_HON.Attributes.Add("ReadOnly", "true")
            txtBONB2_RKG.Attributes.Add("ReadOnly", "true")
            txtZENKAI_HAISO.Attributes.Add("ReadOnly", "true")
            txtZENKAI_HAI_S.Attributes.Add("ReadOnly", "true")
            txtJIKAI_HAISO.Attributes.Add("ReadOnly", "true")
            txtG_ZAIKO.Attributes.Add("ReadOnly", "true")
            txtTAITNM.Attributes.Add("ReadOnly", "true")
            txtTELRNM.Attributes.Add("ReadOnly", "true")
            txtTKIGNM.Attributes.Add("ReadOnly", "true")
            txtTSADNM.Attributes.Add("ReadOnly", "true")
            ' 2013/10/24 T.Ono 監視改善2013№1 Start
            'txtTEL_MEMO1.Attributes.Add("ReadOnly", "true")
            'txtTEL_MEMO2.Attributes.Add("ReadOnly", "true")
            'txtFUK_MEMO.Attributes.Add("ReadOnly", "true")
            txtTEL_MEMO.Attributes.Add("ReadOnly", "true")
            ' 2013/10/24 T.Ono 監視改善2013№1 End
            txtGENIN_KIJI.Attributes.Add("ReadOnly", "true") '2017/10/16 H.Mori add 2017改善開発 No6-1 コメント解除
            ' 2014/10/23 H.Hosoda add 2014改善開発 No11 START
            txtTSTAN_CD.Attributes.Add("ReadOnly", "true")
            ' 2014/10/23 H.Hosoda add 2014改善開発 No11 END
        End If
        '2012/04/06 NEC ou Add End

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
        '連絡先選択を出力
        If hdnKensaku.Value = "SDSYUJTG00" Then
            Server.Transfer("SDSYUJTG00.aspx")
        ElseIf hdnKensaku.Value = "COPOPUPG00" Then             ' 2014/10/23 H.Hosoda add 2014改善開発 No11
            Server.Transfer("../../../Popup/COPOPUPG00.aspx")   '//ポップアップ出力
        End If

        '------------------------------------------------------------------------------
        '<TODO>HTML内に必要なJavaScript/CSSはここで[strScript]変数に格納後
        '      画面上[lblScript]に書き込みを行います(SPANタグとしてクライアントにスクリプトが
        '      出力されます。)
        '      [lblScript(Label)]を作成する事
        '//------------------------------------------
        '//　JavaScript格納
        strScript.Append("<Script language=javascript>")
        '<独自スクリプト>
        strScript.Append(cscript1.mWriteScript( _
             MyBase.MapPath("../../../SD/SDSYUJAG/SDSYUJAG00/") & "SDSYUJAG00.js"))
        '<入力チェック関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncChk.js"))
        '<フォーカス関連関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncFo.js"))
        '<日付関連関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncDate.js"))
        '<時間関連関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncTime.js"))
        strScript.Append("</Script>")
        '//------------------------------------------
        '//　Css格納
        strScript.Append("<Style media='print'>")
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "CssPrint.css"))
        strScript.Append("</Style>")
        strScript.Append("<Style>")
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "CssData.css"))
        strScript.Append("</Style>")
        '//------------------------------------------
        '//　Script書込み
        lblScript.Text = strScript.ToString

        '//-------------------------------------------------
        '<TODO>自分の画面IDをHIDDENのhdnMyAspxに書き込む（システム共通）
        hdnMyAspx.Value = "SDSYUJAG00"

        If MyBase.IsPostBack = False Then
            '//--------------------------------------
            '//初めて開いた時だけ実行される
            strKANSCD = Request.Form("hdnKEY_KANSCD")
            strSYONO = Request.Form("hdnKEY_SYONO")
            hdnMOVE_SIJIYMD_F.Value = Request.Form("hdnMOVE_SIJIYMD_F")
            hdnMOVE_SIJIYMD_T.Value = Request.Form("hdnMOVE_SIJIYMD_T")
            hdnMOVE_KBN.Value = Request.Form("hdnMOVE_KBN")
            '2013/12/12 T.Ono add 監視改善2013 クライアント・JA
            hdnMOVE_CLI_CD.Value = Request.Form("hdnMOVE_CLI_CD")
            hdnMOVE_CLI_CD_NAME.Value = Request.Form("hdnMOVE_CLI_CD_NAME")
            hdnMOVE_JA_CD.Value = Request.Form("hdnMOVE_JA_CD")
            hdnMOVE_JA_CD_NAME.Value = Request.Form("hdnMOVE_JA_CD_NAME")
            ' 2014/10/21 H.Hosoda mod 2014改善開発 No10 START
            hdnMOVE_GROUP_CD.Value = Request.Form("hdnMOVE_GROUP_CD")
            hdnMOVE_GROUP_CD_NAME.Value = Request.Form("hdnMOVE_GROUP_CD_NAME")
            ' 2014/10/21 H.Hosoda mod 2014改善開発 No10 END

            'スクロールバー位置の保持
            hdnScrollTop.Value = Request.Form("hdnScrollTop")                   '2013/12/11 T.Ono add 監視改善2013
            '--- ↓2005/05/25 ADD Falcon↓ ---
            If Request.Form("hdnLOGIN_FLG") = "1" Then
                '//監視センターユーザ
                strMsg.Append("Form1.btnUpd1.disabled=true;")
                strMsg.Append("Form1.btnUpd2.disabled=true;")
            Else
                strMsg.Append("Form1.btnUpd1.disabled=false;")
                strMsg.Append("Form1.btnUpd2.disabled=false;")
            End If
            '--- ↑2005/05/25 ADD Falcon↑ ---

            '//-------------------------------------------------
            'データの読込
            Call fncDataSelect()

            '//-------------------------------------------------
            'コンボボックスを出力する
            'Call fncCombo_Create_TSTANCD()       '受信者氏名 2014/10/22 H.Hosoda del 1Line 2014改善開発 No11
            Call fncCombo_Create_STD()            '所属
            Call fncCombo_Create_SYUTDCD()        '対応相手
            Call fncCombo_Create_HANASI()
            Call fncCombo_Create_KIGCD()          'ガス器具原因
            Call fncCombo_Create_FKICD()          '復帰対応
            Call fncCombo_Create_SADCD()          'メータ作動原因１
            'Call fncCombo_Create_ASECD()          'メータ作動原因２ ' 2008/10/16 T.Watabe del
            'Call fncCombo_Create_STACD()          'その他原因 ' 2008/10/16 T.Watabe del
            'コンボボックスを選択する
            Call fncComboSet()
            '//-------------------------------------------------

            '//--------------------------------------
            'フォーカスをセットする
            ' 2014/10/22 H.Hosoda mod 2014改善開発 No11 START
            'strMsg.Append("Form1.cboTSTANCD.focus();")
            strMsg.Append("Form1.btnTSTAN_CD.focus();")
            ' 2014/10/22 H.Hosoda mod 2014改善開発 No11 END

            '//--------------------------------------
            '//0:通常出動会社　1:監視センター
            hdnLOGIN_FLG.Value = Request.Form("hdnLOGIN_FLG")
        End If
    End Sub

    '******************************************************************************
    ' データ抽出
    '******************************************************************************
    Private Function fncDataSelect() As String
        Dim SQLC As New SDSYUJAG00CSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet

        Dim strRec As String
        Try
            '//対応入力からの画面遷移の場合
            strSQL = New StringBuilder("")
            strSQL.Append(" SELECT ")
            strSQL.Append("  D20.KENNM")
            strSQL.Append(" ,HA.HAISO_CD AS KYOCD")
            strSQL.Append(" ,HA.NAME AS KYONM")
            '2006/06/07 NEC UPDATE START
            'strSQL.Append(" ,DECODE(JANM,NULL,NULL,ACBNM,NULL,JANM,JANM||'/'||ACBNM) AS JANM")
            strSQL.Append(" ,ACBNM AS JANM")
            '2006/06/07 NEC UPDATE END
            strSQL.Append(" ,D20.SYONO")
            strSQL.Append(" ,D20.HATYMD")
            strSQL.Append(" ,D20.HATTIME")
            strSQL.Append(" ,P2.NAME AS HATKBN")
            strSQL.Append(" ,D20.SIJIYMD")
            strSQL.Append(" ,D20.SIJITIME")
            strSQL.Append(" ,D20.TKTANCD_NM")
            strSQL.Append(" ,D20.SDNM")
            strSQL.Append(" ,RTRIM(D20.SIJI_BIKO1) || RTRIM(D20.SIJI_BIKO2) AS SIJI_BIKO")
            strSQL.Append(" ,D20.JUSYONM")
            strSQL.Append(" ,D20.JUSYOKN")
            '2005/11/29 NEC UPDATE START
            'strSQL.Append(" ,D20.KTELNO")
            strSQL.Append(" ,D20.RENTEL")
            '2005/11/29 NEC UPDATE END
            strSQL.Append(" ,D20.ADDR")
            strSQL.Append(" ,D20.TIZUNO")
            ' 2014/12/26 H.Hosoda mod 2014改善開発 No11 追加対応 START
            'strSQL.Append(" ,D20.KMNM1")
            'strSQL.Append(" ,D20.KMNM2")
            'strSQL.Append(" ,D20.KMNM3")
            'strSQL.Append(" ,D20.KMNM4")
            'strSQL.Append(" ,D20.KMNM5")
            'strSQL.Append(" ,D20.KMNM6")
            strSQL.Append(" ,DECODE(D20.KMCD1,NULL,'',D20.KMNM1) AS KMNM1")
            strSQL.Append(" ,DECODE(D20.KMCD2,NULL,'',D20.KMNM2) AS KMNM2")
            strSQL.Append(" ,DECODE(D20.KMCD3,NULL,'',D20.KMNM3) AS KMNM3")
            strSQL.Append(" ,DECODE(D20.KMCD4,NULL,'',D20.KMNM4) AS KMNM4")
            strSQL.Append(" ,DECODE(D20.KMCD5,NULL,'',D20.KMNM5) AS KMNM5")
            strSQL.Append(" ,DECODE(D20.KMCD6,NULL,'',D20.KMNM6) AS KMNM6")
            ' 2014/12/26 H.Hosoda mod 2014改善開発 No11 追加対応 END
            strSQL.Append(" ,D20.GAS1_HINMEI")
            strSQL.Append(" ,DECODE(D20.GAS1_DAISU,NULL,NULL,D20.GAS1_DAISU|| '台') AS GAS1_DAISU")
            strSQL.Append(" ,D20.GAS2_HINMEI")
            strSQL.Append(" ,DECODE(D20.GAS2_DAISU,NULL,NULL,D20.GAS2_DAISU|| '台') AS GAS2_DAISU")
            strSQL.Append(" ,D20.GAS3_HINMEI")
            strSQL.Append(" ,DECODE(D20.GAS3_DAISU,NULL,NULL,D20.GAS3_DAISU|| '台') AS GAS3_DAISU")
            strSQL.Append(" ,D20.GAS4_HINMEI")
            strSQL.Append(" ,DECODE(D20.GAS4_DAISU,NULL,NULL,D20.GAS4_DAISU|| '台') AS GAS4_DAISU")
            '2006/10/24 ADD_START
            strSQL.Append(" ,D20.ZENKAI_HAISO")
            strSQL.Append(" ,D20.ZENKAI_HAI_S")
            '2006/10/24 ADD_END
            strSQL.Append(" ,D20.KONKAI_HAISO")
            strSQL.Append(" ,D20.KONKAI_HAI_S")
            strSQL.Append(" ,D20.KONKAI_HASEI")
            strSQL.Append(" ,D20.KONKAI_HAS_S")
            strSQL.Append(" ,DECODE(D20.NCU_SET,'0','無','有') AS NCU_SET")
            strSQL.Append(" ,D20.MET_KATA")
            strSQL.Append(" ,D20.MET_MAKER")
            strSQL.Append(" ,D20.TAITNM")
            strSQL.Append(" ,D20.TELRNM")
            strSQL.Append(" ,D20.TKIGNM")
            strSQL.Append(" ,D20.TSADNM")
            strSQL.Append(" ,D20.FUK_MEMO")
            strSQL.Append(" ,D20.TEL_MEMO1")
            strSQL.Append(" ,D20.TEL_MEMO2")
            strSQL.Append(" ,D20.GENIN_KIJI")
            strSQL.Append(" ,D20.EDT_DATE")
            strSQL.Append(" ,D20.EDT_TIME")
            strSQL.Append(" ,D20.TSTANCD   ")           '受信者コード
            strSQL.Append(" ,D20.TSTANNM   ")           '受信者氏名　2014/10/22 H.Hosoda add 2014改善開発 No11
            strSQL.Append(" ,D20.STD_CD    ")           '出動会社コード
            strSQL.Append(" ,D20.STD_KYOTEN_CD    ")    '出動会社拠点コード
            strSQL.Append(" ,D20.SYUTDTNM  ")           '出動対応者
            '--- ↓2005/05/25 MOD Falcon↓ ---
            If hdnMOVE_KBN.Value = "1" Then
                '//出動一覧から遷移時
                strSQL.Append(" ,NVL(D20.JUYMD,TO_CHAR(SYSDATE,'YYYYMMDD')) AS JUYMD")  '対応受信日（警報受信日）
                strSQL.Append(" ,D20.JUTIME    ")  '対応時刻（受信時刻）
                strSQL.Append(" ,D20.SDYMD ")       '出動日        2008/10/14 T.Watabe add
                strSQL.Append(" ,D20.SDTIME ")      '出動時刻      2008/10/14 T.Watabe add
                'strSQL.Append(" ,NVL(D20.TYAKYMD,D20.SIJIYMD) AS TYAKYMD  ")    '到着日   2008/10/14 T.Watabe edit デフォルト表示をやめる
                'strSQL.Append(" ,NVL(D20.TYAKTIME,D20.SIJITIME) AS TYAKTIME ")  '到着時間 2008/10/14 T.Watabe edit デフォルト表示をやめる
                strSQL.Append(" ,D20.TYAKYMD ")     '到着日
                strSQL.Append(" ,D20.TYAKTIME ")    '到着時間
            ElseIf hdnMOVE_KBN.Value = "2" Then
                '//出動結果一覧から遷移時
                strSQL.Append(" ,D20.JUYMD ")       '対応受信日（警報受信日）
                strSQL.Append(" ,D20.JUTIME ")      '対応時刻（受信時刻）
                strSQL.Append(" ,D20.SDYMD ")       '出動日        2008/10/14 T.Watabe add
                strSQL.Append(" ,D20.SDTIME ")      '出動時刻      2008/10/14 T.Watabe add
                strSQL.Append(" ,D20.TYAKYMD ")     '到着日
                strSQL.Append(" ,D20.TYAKTIME ")    '到着時間
            End If
            '--- ↑2005/05/25 MOD Falcon↑ ---
            strSQL.Append(" ,D20.SYOKANYMD ")  '処理完了日
            strSQL.Append(" ,D20.SYOKANTIME")  '処理完了時間
            strSQL.Append(" ,D20.AITCD     ")  '対応相手
            strSQL.Append(" ,D20.METHEIKAKU")  '不在時の措置　メータ遮断弁閉止確認 1:有
            strSQL.Append(" ,D20.RUSUHARI  ")  '不在時の措置　留守宅表示の貼付　 1:有
            strSQL.Append(" ,D20.KIGCD     ")  '器具原因コード	
            strSQL.Append(" ,D20.SADCD     ")  '作動原因コード	
            strSQL.Append(" ,D20.ASECD     ")  '圧力センサー作動原因
            strSQL.Append(" ,D20.STACD     ")  'その他原因コード
            strSQL.Append(" ,D20.FKICD     ")  '復帰操作コード
            strSQL.Append(" ,D20.JAKENREN  ")  'ＪＡ／県連への連絡相手
            strSQL.Append(" ,D20.RENTIME   ")  'ＪＡ／県連への連絡時間
            strSQL.Append(" ,D20.KIGTAIYO  ")  '簡易ガス器具の貸与　1：有
            strSQL.Append(" ,NVL(D20.GASMUMU,'1') AS GASMUMU  ")    'ガス漏れ点検　0：有　1：無
            strSQL.Append(" ,NVL(D20.ORGENIN,'0') AS ORGENIN  ")    'ガス漏れ点検有　原因　ガス器具　1:有
            strSQL.Append(" ,NVL(D20.HAIKAN,'0') AS HAIKAN   ")     'ガス漏れ点検有　原因　配管　1:有
            strSQL.Append(" ,NVL(D20.GASGUMU,'1') AS GASGUMU  ")    'ガス切れ確認　0：有　1：無
            strSQL.Append(" ,NVL(D20.HOSKOKAN,'1') AS HOSKOKAN ")   'ゴムホース交換　0：実施　1：未実施
            strSQL.Append(" ,NVL(D20.METYOINA,'0') AS METYOINA ")   'その他点検　メータ　0：良　1：否
            strSQL.Append(" ,NVL(D20.TYOUYOINA,'0') AS TYOUYOINA ") 'その他点検　調整器　0：良　1：否
            strSQL.Append(" ,NVL(D20.VALYOINA,'0') AS VALYOINA  ")  'その他点検　容器・中間バルブ　0：良　1：否
            strSQL.Append(" ,NVL(D20.KYUHAIUMU,'0') AS KYUHAIUMU ") 'その他点検　吸排気口　0：有　1：無
            strSQL.Append(" ,NVL(D20.COYOINA,'0') AS COYOINA  ")    'その他点検　ＣＯ濃度　0：良　1：否
            strSQL.Append(" , DECODE(D20.METFUKKI,'1','1',DECODE(D20.HOAN,'1','2',DECODE(D20.GASGIRE,'1','3',DECODE(D20.KIGKOSYO,'1','4',DECODE(D20.CSNTGEN,'1','5','0'))))) AS HANASI  ")  '特記事項
            strSQL.Append(" ,D20.SDTBIK1  ")    '特記事項
            strSQL.Append(" ,D20.SDTBIK2   ")   '特記事項
            strSQL.Append(" ,D20.SNTTOKKI  ")   'その他特記事項
            '2006/06/15 NEC ADD START
            strSQL.Append(" ,D20.SDTBIK3   ")   '出動結果内容/報告
            '2006/06/15 NEC ADD END
            strSQL.Append(" ,D20.STD_CD  ")     '出動会社コード
            strSQL.Append(" ,D20.KURACD ") '2008/11/05 T.Watabe add
            strSQL.Append(" ,D20.ACBCD ") '2008/11/05 T.Watabe add
            '▼2009/01/09 T.Watabe add ボンベ情報取得
            strSQL.Append(", ")
            strSQL.Append("    D20.G_ZAIKO, ")
            strSQL.Append("    D20.ZENKAI_HAISO AS BOMV_HAISO1, ")
            strSQL.Append("    D20.ZENKAI_HAI_S AS BOMV_SISIN1, ")
            strSQL.Append("    D20.JIKAI_HAISO  AS HAISO_YOTEI, ")
            strSQL.Append("    D20.BONB1_KKG    AS BOMB_YOUKI1, ")
            strSQL.Append("    D20.BONB1_HON    AS BOMB_SUU1, ")
            strSQL.Append("    D20.BONB1_YOBI   AS BOMB_RYO1, ")
            strSQL.Append("    D20.BONB2_KKG    AS BOMB_YOUKI2, ")
            strSQL.Append("    D20.BONB2_HON    AS BOMB_SUU2, ")
            strSQL.Append("    D20.BONB2_YOBI   AS BOMB_RYO2 ")
            '▲2009/01/09 T.Watabe add
            strSQL.Append(" FROM  ")
            strSQL.Append("     D20_TAIOU D20,HN2MAS JA, HAIMAS HA, M06_PULLDOWN P2")
            '↓2005/05/20 MOD ------↓ j.k
            'strSQL.Append(" WHERE D20.KANSCD      = :KANSCD")
            'strSQL.Append(" AND D20.SYONO         = :SYONO")
            'strSQL.Append(" AND D20.KURACD        = JA.CLI_CD")
            'strSQL.Append(" AND D20.ACBCD         = JA.HAN_CD")
            'strSQL.Append(" AND SUBSTR(JA.CLI_CD,2,2) = HA.KEN_CD")
            'strSQL.Append(" AND JA.HAISO_CD       = HA.HAISO_CD")
            'strSQL.Append(" AND '08'              = P2.KBN(+)")
            'strSQL.Append(" AND D20.HATKBN        = P2.CD(+)") 
            strSQL.Append(" WHERE")
            strSQL.Append("     D20.KANSCD = :KANSCD")
            strSQL.Append(" AND D20.SYONO = :SYONO")
            strSQL.Append(" AND D20.KURACD = JA.CLI_CD(+)")
            strSQL.Append(" AND D20.ACBCD = JA.HAN_CD(+)")
            strSQL.Append(" AND SUBSTR(JA.CLI_CD,2,2) = HA.KEN_CD(+)")
            strSQL.Append(" AND JA.HAISO_CD = HA.HAISO_CD(+)")
            strSQL.Append(" AND '08' = P2.KBN(+)")
            strSQL.Append(" AND D20.HATKBN = P2.CD(+)")
            '↑2005/05/20 MOD ------↑ j.k

            'パラメータのセット
            SqlParamC.fncSetParam("KANSCD", True, strKANSCD)
            SqlParamC.fncSetParam("SYONO", True, strSYONO)

            '//SQLの実行
            dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

            If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
                '↓2005/05/20 MOD ------↓ j.k
                'If Convert.ToInt32(dbData.Tables(0).Rows.Count) = 0 Then
                '↑2005/05/20 MOD ------↑ j.k
                strMsg.Append("alert('対象データが存在しません');")
                strRec = "ERROR"
            Else
                '//データを出力します
                Call fncDataSet(dbData)
                strRec = "OK"
            End If

            '--- ↓2005/07/26 ADD Falcon↓ ---
            If strRec = "OK" Then
                strSQL = New StringBuilder("")
                strSQL.Append(" SELECT ")
                strSQL.Append("  DECODE(SH.KESSEN,'1','有','無') AS NCU_SET ") '結線区分（0:未結線 1:結線　2：工事手配中(12.11追加)　D:削除（未結線の未開通））
                strSQL.Append(" FROM  SHAMAS SH, ")
                strSQL.Append("       D20_TAIOU D20 ")
                strSQL.Append(" WHERE D20.KANSCD = :KANSCD")
                strSQL.Append("   AND D20.SYONO = :SYONO")
                strSQL.Append("   AND SH.CLI_CD = D20.KURACD ")
                strSQL.Append("   AND SH.HAN_CD = D20.ACBCD")
                strSQL.Append("   AND SH.USER_CD = D20.USER_CD")

                'パラメータのセット
                SqlParamC.fncSetParam("KANSCD", True, strKANSCD)
                SqlParamC.fncSetParam("SYONO", True, strSYONO)

                '//SQLの実行
                dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

                If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
                    '共用マスタに存在しない顧客の場合は無条件に「無」を表示
                    txtNCU_SET.Text = "無"
                Else
                    'ＮＣＵ設置区分
                    txtNCU_SET.Text = Convert.ToString(dbData.Tables(0).Rows(0).Item("NCU_SET"))
                End If
            End If
            '--- ↑2005/07/26 ADD Falcon↑ ---

        Catch ex As Exception
            Dim ErrMsgC As New CErrMsg
            strMsg.Append("alert('システムエラー：" & ErrMsgC.mGetArtMsg(ex.ToString) & "');")
            strRec = "ERROR"
        End Try

        'dbData.Dispose()

        Return strRec

    End Function
    '******************************************************************************
    '*　概　要：実行ボタン押下時の処理
    '*　備　考：
    '******************************************************************************
    Private Sub btnUpd1_ServerClick(ByVal sender As System.Object, _
                                    ByVal e As System.EventArgs) Handles btnUpd1.ServerClick
        Call fncDataGet()
        '//--------------------------------------------------------------------------
        '<TODO>登録処理を行う
        Server.Transfer("SDSYUJJG00.aspx")
    End Sub
    '******************************************************************************
    '*　概　要：実行ボタン押下時の処理
    '*　備　考：
    '******************************************************************************
    Private Sub btnUpd2_ServerClick(ByVal sender As System.Object, _
                                    ByVal e As System.EventArgs) Handles btnUpd2.ServerClick
        Call fncDataGet()
        '//--------------------------------------------------------------------------
        '<TODO>登録処理を行う
        Server.Transfer("SDSYUJJG00.aspx")
    End Sub
    '******************************************************************************
    '*　概　要：終了ボタン押下時の処理
    '*　備　考：
    '******************************************************************************
    Private Sub btnExit_ServerClick(ByVal sender As System.Object, _
                                    ByVal e As System.EventArgs) Handles btnExit.ServerClick
        '遷移してきた画面を保持し、[終了ボタン]押下時に戻る画面の制御をする(VB-Transfer)
        Dim strMyAspx As String
        Dim strRes As String
        strMyAspx = Request.Form("hdnMyAspx")

        '利用者検索画面からの画面遷移の場合
        strMsg.Append("with(parent.Data.Form1){")
        strMsg.Append("hdnMOVE_SIJIYMD_F=" & hdnMOVE_SIJIYMD_F.Value)
        strMsg.Append("hdnMOVE_SIJIYMD_T=" & hdnMOVE_SIJIYMD_T.Value)
        strMsg.Append("}")
        strMsg.Append("location.replace('about:blank');")   '受信フレーム内をブランクページに。

        Server.Transfer("../../../SD/SDLSTJAG/SDLSTJAG00/SDLSTJAG00.aspx")
    End Sub

    '******************************************************************************
    ' 取得データを画面に転記
    '******************************************************************************
    Private Sub fncDataSet(ByVal pdbData As DataSet)

        Dim decKonkai_Hai_S As Decimal              '//今回配送日・指針一時格納用
        Dim decKmsin As Decimal                     '//メータ値一時格納用（配送日からの推定使用量計算時に使用）
        Dim strG_Zaiko As String                    '//配送日からの推定使用料一時格納用
        Dim strNcuSet As String                     '//ＮＣＵ接続一時格納用
        Dim decKeihosu As Decimal                   '//警報メッセージ数

        Dim DateFncC As New CDateFnc
        Dim TimeFncC As New CTimeFnc
        Dim NaNFncC As New CNaNFnc '2009/01/09 T.Watabe add

        Try
            '//--------------------------------------------------------------------------
            '<TODO>検索処理を行う
            '
            Dim strTemp As String
            Dim intTemp As Integer
            Dim intLoop As Integer

            'データが無ければ
            If Convert.ToString(pdbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then

            Else
                'データ転記処理

                '県名
                txtKENNM.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("KENNM"))
                '配送センター
                txtHAISO_NAME.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("KYOCD")) & ":" & Convert.ToString(pdbData.Tables(0).Rows(0).Item("KYONM"))
                'ＪＡ／ＪＡ支所
                'txtJANM.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("JANM"))
                txtJANM.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("ACBCD")) & ":" & Convert.ToString(pdbData.Tables(0).Rows(0).Item("JANM"))
                '処理番号
                txtSYONO.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("SYONO"))
                '発生日時
                txtHATYMD.Text = DateFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("HATYMD")))
                '発生時間
                txtHATTIME.Text = TimeFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("HATTIME")), 0)
                '発生区分
                txtHATKBN.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("HATKBN"))
                '指示日
                txtSIJIYMD.Text = DateFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("SIJIYMD")))
                '指示時間
                txtSIJITIME.Text = TimeFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("SIJITIME")), 1)
                '監視センター担当者
                txtTKTANCD_NM.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("TKTANCD_NM"))
                '出動指示内容
                txtSDNM.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("SDNM"))
                '出動指示備考
                txtSIJI_BIKO.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("SIJI_BIKO"))
                'お客様氏名
                txtJUSYONM.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("JUSYONM"))
                'お客様カナ
                txtJUSYOKN.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("JUSYOKN"))
                'お電話番号
                '2005/11/25 NEC UPDATE START
                '検索電話→連絡電話
                'txtKTELNO.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("KTELNO"))
                txtKTELNO.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("RENTEL"))
                '2005/11/25 NEC UPDATE START
                'ご住所
                txtADDR.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("ADDR"))
                '地図番号
                txtTIZUNO.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("TIZUNO"))
                '警報１
                txtKMNM1.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("KMNM1"))
                '警報２
                txtKMNM2.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("KMNM2"))
                '警報３
                txtKMNM3.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("KMNM3"))
                '警報４
                txtKMNM4.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("KMNM4"))
                '警報５
                txtKMNM5.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("KMNM5"))
                '警報６
                txtKMNM6.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("KMNM6"))
                'お客様情報／ガス器具１
                txtGAS1_HINMEI.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("GAS1_HINMEI"))
                'お客様情報／ガス器具１台数
                txtGAS1_DAISU.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("GAS1_DAISU"))
                'お客様情報／ガス器具２
                txtGAS2_HINMEI.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("GAS2_HINMEI"))
                'お客様情報／ガス器具２台数
                txtGAS2_DAISU.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("GAS2_DAISU"))
                'お客様情報／ガス器具３
                txtGAS3_HINMEI.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("GAS3_HINMEI"))
                'お客様情報／ガス器具３台数
                txtGAS3_DAISU.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("GAS3_DAISU"))
                'お客様情報／ガス器具４
                txtGAS4_HINMEI.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("GAS4_HINMEI"))
                'お客様情報／ガス器具４台数
                txtGAS4_DAISU.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("GAS4_DAISU"))
                '2006/10/24 UPD_START
                'ボンベ交換（発生日）
                '※ボンベ交換（発生日）、ボンベ交換（指針）は、前回分に最新情報が設定されているため、今回情報でなく前回情報を表示する
                'txtKONKAI_HAISO.Text = DateFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("KONKAI_HAISO")))
                txtKONKAI_HAISO.Text = DateFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("ZENKAI_HAISO")))
                'ボンベ交換（指針）
                'txtKONKAI_HAI_S.Text = fncEditSisin(Convert.ToString(pdbData.Tables(0).Rows(0).Item("KONKAI_HAI_S")))
                txtKONKAI_HAI_S.Text = fncEditSisin(Convert.ToString(pdbData.Tables(0).Rows(0).Item("ZENKAI_HAI_S")))
                '2006/10/24 UPD_END
                'ボンベ切替（発生日）
                txtKONKAI_HASEI.Text = DateFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("KONKAI_HASEI")))
                'ボンベ切替（指針）
                txtKONKAI_HAS_S.Text = fncEditSisin(Convert.ToString(pdbData.Tables(0).Rows(0).Item("KONKAI_HAS_S")))
                'メータ型式
                txtMET_KATA.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("MET_KATA"))
                'ＮＣＵ
                txtNCU_SET.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("NCU_SET"))
                'メータメーカー
                txtMET_MAKER.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("MET_MAKER"))
                '連絡相手
                txtTAITNM.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("TAITNM"))
                '電話連絡内容
                txtTELRNM.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("TELRNM"))
                'ガス器具原因
                txtTKIGNM.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("TKIGNM"))
                '作動原因
                txtTSADNM.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("TSADNM"))
                ' 2013/10/24 T.Ono 監視改善2013№1 Start
                ''備考１
                'txtFUK_MEMO.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("FUK_MEMO"))
                ''備考２
                'txtTEL_MEMO1.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("TEL_MEMO1"))
                ''警報３
                'txtTEL_MEMO2.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("TEL_MEMO2"))
                txtTEL_MEMO.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("TEL_MEMO1")) & vbCrLf & _
                                    Convert.ToString(pdbData.Tables(0).Rows(0).Item("TEL_MEMO2")) & vbCrLf & _
                                    Convert.ToString(pdbData.Tables(0).Rows(0).Item("FUK_MEMO"))
                ' 2013/10/24 T.Ono 監視改善2013№1 End
                'お客様記事
                txtGENIN_KIJI.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("GENIN_KIJI"))
                '受信者コード・受信者氏名
                ' 2014/10/22 H.Hosoda mod 2014改善開発 No11 START
                'strCBO_TSTANCD = Convert.ToString(pdbData.Tables(0).Rows(0).Item("TSTANCD"))
                If Convert.ToString(pdbData.Tables(0).Rows(0).Item("TSTANCD")) <> "" Then
                    txtTSTAN_CD.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("TSTANCD")) & " : " & _
                                       Convert.ToString(pdbData.Tables(0).Rows(0).Item("TSTANNM"))
                    hdnTSTAN_CD.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("TSTANCD"))
                    hdnTSTAN_NM.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("TSTANNM"))
                End If
                ' 2014/10/22 H.Hosoda mod 2014改善開発 No11 END
                '出動会社
                strCBO_STD_CD = Convert.ToString(pdbData.Tables(0).Rows(0).Item("STD_CD"))
                '所属
                strCBO_KYOTEN_CD = Convert.ToString(pdbData.Tables(0).Rows(0).Item("STD_KYOTEN_CD"))
                '出動担当者
                txtSYUTDNM.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("SYUTDTNM"))
                '対応受信日時
                txtTAIO_ST_DATE.Text = DateFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("SIJIYMD")))
                '対応受信日時（時間）
                txtTAIO_ST_TIME.Text = TimeFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("SIJITIME")), 1)

                ' 2008/10/14 T.Watabe add
                '対応受信日時
                txtSDYMD.Text = DateFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("SDYMD")))
                '対応受信日時（時間）
                txtSDTIME.Text = TimeFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("SDTIME")), 1)

                '到着日時（日付）
                txtTYAKYMD.Text = DateFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("TYAKYMD")))
                '到着日時（時間）
                txtTYAKTIME.Text = TimeFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("TYAKTIME")), 1)
                '処理完了（日付）
                txtSYOKANYMD.Text = DateFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("SYOKANYMD")))
                '処理完了（時間）
                txtSYOKANTIME.Text = TimeFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("SYOKANTIME")), 1)
                '対応相手
                strCBO_AITCD = Convert.ToString(pdbData.Tables(0).Rows(0).Item("AITCD"))
                '不在時の措置　メータ遮断弁閉止確認 1:有
                If Convert.ToString(pdbData.Tables(0).Rows(0).Item("METHEIKAKU")) = "1" Then
                    chkMETHEIKAKU.Checked = True
                End If
                '不在時の措置　留守宅表示の貼付　 1:有
                If Convert.ToString(pdbData.Tables(0).Rows(0).Item("RUSUHARI")) = "1" Then
                    chkRUSUHAIRI.Checked = True
                End If

                '特記事項()
                txtSDTBIK1.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("SDTBIK1"))
                '器具原因コード	
                strCBO_KIGCD = Convert.ToString(pdbData.Tables(0).Rows(0).Item("KIGCD"))
                '作動原因コード	
                strCBO_SADCD = Convert.ToString(pdbData.Tables(0).Rows(0).Item("SADCD"))
                '圧力センサー作動原因
                strCBO_ASECD = Convert.ToString(pdbData.Tables(0).Rows(0).Item("ASECD"))
                'その他原因コード
                strCBO_STACD = Convert.ToString(pdbData.Tables(0).Rows(0).Item("STACD"))
                '復帰操作コード
                strCBO_FKICD = Convert.ToString(pdbData.Tables(0).Rows(0).Item("FKICD"))
                'ＪＡ／県連への連絡相手
                txtJAKENREN.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("JAKENREN"))
                'ＪＡ／県連への連絡時間
                txtRENTIME.Text = TimeFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("RENTIME")), 1)
                '簡易ガス器具の貸与　1：有
                If Convert.ToString(pdbData.Tables(0).Rows(0).Item("KIGTAIYO")) = "1" Then
                    chkKIGUTAIYO.Checked = True
                End If
                'ガス漏れ点検　0：有　1：無
                If Convert.ToString(pdbData.Tables(0).Rows(0).Item("GASMUMU")) = "0" Then
                    rdoGASMUMU1.Checked = True
                    rdoGASMUMU2.Checked = False
                    '--- ↓2005/04/21 ADD　Falcon↓ -----------------
                    rdoGASMUMU_H.Disabled = False
                    '--- ↑2005/04/21 ADD　Falcon↑ -----------------
                Else
                    rdoGASMUMU1.Checked = False
                    rdoGASMUMU2.Checked = True
                    '--- ↓2005/04/21 ADD　Falcon↓ -----------------
                    rdoGASMUMU_H.Disabled = True
                    '--- ↑2005/04/21 ADD　Falcon↑ -----------------
                End If
                'ガス漏れ点検有　原因　ガス器具　1:有
                If Convert.ToString(pdbData.Tables(0).Rows(0).Item("ORGENIN")) = "1" Then
                    rdoGASMUMU_K.Checked = True
                    '--- ↓2005/04/21 ADD　Falcon↓ -----------------
                    rdoGASMUMU_H.Checked = False
                    '--- ↑2005/04/21 ADD　Falcon↑ -----------------
                Else
                    rdoGASMUMU_K.Checked = False
                    '--- ↓2005/04/21 ADD　Falcon↓ -----------------
                    rdoGASMUMU_H.Checked = True
                    '--- ↑2005/04/21 ADD　Falcon↑ -----------------
                End If
                'ガス漏れ点検有　原因　配管　　　1:有
                If Convert.ToString(pdbData.Tables(0).Rows(0).Item("HAIKAN")) = "1" Then
                    rdoGASMUMU_H.Checked = True
                    '--- ↓2005/04/21 ADD　Falcon↓ -----------------
                    rdoGASMUMU_K.Checked = False
                    '--- ↑2005/04/21 ADD　Falcon↑ -----------------
                Else
                    rdoGASMUMU_H.Checked = False
                    '--- ↓2005/04/21 ADD　Falcon↓ -----------------
                    rdoGASMUMU_K.Checked = True
                    '--- ↑2005/04/21 ADD　Falcon↑ -----------------
                End If
                'ガス切れ確認　0：有　1：無
                If Convert.ToString(pdbData.Tables(0).Rows(0).Item("GASGUMU")) = "0" Then
                    rdoGASUGUMU1.Checked = True
                    rdoGASUGUMU2.Checked = False
                Else
                    rdoGASUGUMU1.Checked = False
                    rdoGASUGUMU2.Checked = True
                End If
                'ゴムホース交換　0：実施　1：未実施
                If Convert.ToString(pdbData.Tables(0).Rows(0).Item("HOSKOKAN")) = "0" Then
                    rdoHOSKOKAN1.Checked = True
                    rdoHOSKOKAN2.Checked = False
                Else
                    rdoHOSKOKAN1.Checked = False
                    rdoHOSKOKAN2.Checked = True
                End If
                'その他点検　メータ　0：良　1：否
                If Convert.ToString(pdbData.Tables(0).Rows(0).Item("METYOINA")) = "0" Then
                    rdoMETYOINA1.Checked = True
                    rdoMETYOINA2.Checked = False
                Else
                    rdoMETYOINA1.Checked = False
                    rdoMETYOINA2.Checked = True
                End If
                'その他点検　調整器　0：良　1：否METYOINA
                If Convert.ToString(pdbData.Tables(0).Rows(0).Item("TYOUYOINA")) = "0" Then
                    rdoTYOUYOINA1.Checked = True
                    rdoTYOUYOINA2.Checked = False
                Else
                    rdoTYOUYOINA1.Checked = False
                    rdoTYOUYOINA2.Checked = True
                End If
                'その他点検　容器・中間バルブ　0：良　1：否
                If Convert.ToString(pdbData.Tables(0).Rows(0).Item("VALYOINA")) = "0" Then
                    rdoVALYOINA1.Checked = True
                    rdoVALYOINA2.Checked = False
                Else
                    rdoVALYOINA1.Checked = False
                    rdoVALYOINA2.Checked = True
                End If
                'その他点検　吸排気口　0：有　1：無
                If Convert.ToString(pdbData.Tables(0).Rows(0).Item("KYUHAIUMU")) = "0" Then
                    rdoKYUHAIUMU1.Checked = True
                    rdoKYUHAIUMU2.Checked = False
                Else
                    rdoKYUHAIUMU1.Checked = False
                    rdoKYUHAIUMU2.Checked = True
                End If
                'その他点検　ＣＯ濃度　0：良　1：否
                If Convert.ToString(pdbData.Tables(0).Rows(0).Item("COYOINA")) = "0" Then
                    rdoCOYOINA1.Checked = True
                    rdoCOYOINA2.Checked = False
                Else
                    rdoCOYOINA1.Checked = False
                    rdoCOYOINA2.Checked = True
                End If
                'お客様のお話
                strCBO_HANASI = Convert.ToString(pdbData.Tables(0).Rows(0).Item("HANASI"))
                If strCBO_HANASI <> "0" Then
                    rdoHanasi1.Checked = True
                    rdoHanasi2.Checked = False
                Else
                    rdoHanasi1.Checked = False
                    rdoHanasi2.Checked = True
                End If
                '2006/06/15 NEC UPDATE START
                ''特記事項()
                'txtSDTBIK2.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("SDTBIK2"))
                ''その他特記事項()
                'txtSNTTOKKI.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("SNTTOKKI"))
                ' 2013/10/25 T.Ono 監視改善№1 Start
                '出動結果内容/報告()
                'txtSDTBIK2.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("SDTBIK2"))
                'txtSNTTOKKI.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("SNTTOKKI"))
                'txtSDTBIK3.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("SDTBIK3"))
                If Convert.ToString(pdbData.Tables(0).Rows(0).Item("SDTBIK2")) & Convert.ToString(pdbData.Tables(0).Rows(0).Item("SNTTOKKI")) & _
                                        Convert.ToString(pdbData.Tables(0).Rows(0).Item("SDTBIK3")) <> "" Then
                    txtSDTBIK.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("SDTBIK2")) & vbCrLf & _
                                        Convert.ToString(pdbData.Tables(0).Rows(0).Item("SNTTOKKI")) & vbCrLf & _
                                        Convert.ToString(pdbData.Tables(0).Rows(0).Item("SDTBIK3"))
                Else
                    txtSDTBIK.Value = ""
                End If

                ' 2013/10/25 T.Ono 監視改善№1 End
                '2006/06/15 NEC UPDATE END

                '監査コード
                hdnKEY_KANSCD.Value = strKANSCD
                '処理番号
                hdnKEY_SYONO.Value = strSYONO
                '更新日付
                hdnEDT_DATE.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("EDT_DATE"))
                '更新時間
                hdnEDT_TIME.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("EDT_TIME"))
                '更新時間
                hdnSTDCD.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("STD_CD"))

                '2008/11/05 T.Watabe add
                'クライアントコード
                hdnKURACD.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("KURACD"))
                'JA支所コード
                hdnJASCD.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("ACBCD"))

                '▼ 2009/01/09 T.Watabe add
                '配送日からの推定使用量(今秋
                strG_Zaiko = Convert.ToString(pdbData.Tables(0).Rows(0).Item("G_ZAIKO"))

                'ボンベ交換前回配送日
                txtZENKAI_HAISO.Text = fncEditDate(Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMV_HAISO1")))
                'ボンベ交換前回配送指針
                txtZENKAI_HAI_S.Text = fncEditSisin2(Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMV_SISIN1")), 1)
                '次回配送予定日
                txtJIKAI_HAISO.Text = fncEditDate(Convert.ToString(pdbData.Tables(0).Rows(0).Item("HAISO_YOTEI")))
                '配送日からの推定使用量
                txtG_ZAIKO.Text = NaNFncC.mGet(strG_Zaiko, 0)
                'ボンベ１容器ＫＧ
                txtBONB1_KKG.Text = NaNFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMB_YOUKI1")), 0)
                'ボンベ１設置本数
                txtBONB1_HON.Text = NaNFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMB_SUU1")), 0)
                'ボンベ１容量ＫＧ
                txtBONB1_RKG.Text = fncEditYouryou(Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMB_YOUKI1")), Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMB_SUU1")))
                'ボンベ１容器予備フラグ
                hdnBONB1_YOBI.Value = Convert.ToString(Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMB_RYO1")))
                If hdnBONB1_YOBI.Value = "1" Then
                    chkBONB1_YOBI.Checked = True    '予備容器としてチェック
                Else
                    chkBONB1_YOBI.Checked = False
                End If
                'ボンベ２容器ＫＧ
                txtBONB2_KKG.Text = NaNFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMB_YOUKI2")), 0)
                'ボンベ２設置本数
                txtBONB2_HON.Text = NaNFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMB_SUU2")), 0)
                'ボンベ２容量ＫＧ
                txtBONB2_RKG.Text = fncEditYouryou(Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMB_YOUKI2")), Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMB_SUU2")))
                'ボンベ２容器予備フラグ
                hdnBONB2_YOBI.Value = Convert.ToString(Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMB_RYO2")))
                If hdnBONB2_YOBI.Value = "1" Then
                    chkBONB2_YOBI.Checked = True    '予備容器としてチェック
                Else
                    chkBONB2_YOBI.Checked = False
                End If
                '▲ 2009/01/09 T.Watabe add
                End If
        Catch ex As Exception
            Dim ErrMsgC As New CErrMsg
            strMsg.Append("alert('システムエラー：" & ErrMsgC.mGetArtMsg(ex.ToString) & "');")
        End Try

    End Sub
    '******************************************************************************
    ' 取得データを画面に転記
    '******************************************************************************
    Private Function fncDataGet() As String
        gstrMyAspx = hdnMyAspx.Value
        gstrKANSCD = hdnKEY_KANSCD.Value
        gstrSYONO = hdnKEY_SYONO.Value
        gstrKBN = hdnKBN.Value
        gstrMOVE_SIJIYMD_F = hdnMOVE_SIJIYMD_F.Value
        gstrMOVE_SIJIYMD_T = hdnMOVE_SIJIYMD_T.Value
        gstrMOVE_KBN = hdnMOVE_KBN.Value
        gstrMOVE_CLI_CD = hdnMOVE_CLI_CD.Value               '2013/12/12 T.Ono add 監視改善2013
        gstrMOVE_CLI_CD_NAME = hdnMOVE_CLI_CD_NAME.Value     '2013/12/12 T.Ono add 監視改善2013
        gstrMOVE_JA_CD = hdnMOVE_JA_CD.Value                 '2013/12/12 T.Ono add 監視改善2013
        gstrMOVE_JA_CD_NAME = hdnMOVE_JA_CD_NAME.Value       '2013/12/12 T.Ono add 監視改善2013
        gstrMOVE_GROUP_CD = hdnMOVE_GROUP_CD.Value           '2014/10/21 H.Hosoda add 監視改善2014 No10
        gstrMOVE_GROUP_CD_NAME = hdnMOVE_GROUP_CD_NAME.Value '2014/10/21 H.Hosoda add 監視改善2014 No10

        '受信者名
        ' 2014/10/23 H.Hosoda mod 2014改善開発 No11 START
        'gstrTSTANCD = Request.Form("cboTSTANCD")
        gstrTSTANCD = hdnTSTAN_CD.Value
        gstrTSTANNM = hdnTSTAN_NM.Value
        ' 2014/10/23 H.Hosoda mod 2014改善開発 No11 END

        '出動会社コード
        gstrSTD_CD = hdnSTDCD.Value
        '所属
        gstrSTD_KYOTEN_CD = Request.Form("cboSTD")
        '出動対応者
        gstrSYUTDTNM = txtSYUTDNM.Text
        '対応受信日時（日付）
        gstrJUYMD = txtTAIO_ST_DATE.Text
        '対応受信日時（時間）
        gstrJUTIME = txtTAIO_ST_TIME.Text

        ' 2008/10/14 T.Watabe add
        '出動日時（日付）
        gstrSDYMD = txtSDYMD.Text
        '出動日時（時間）
        gstrSDTIME = txtSDTIME.Text

        '到着日時（日付）
        gstrTYAKYMD = txtTYAKYMD.Text
        '到着日時（時間）
        gstrTYAKTIME = txtTYAKTIME.Text
        '処理対応完了日時（日付）
        gstrSYOKANYMD = txtSYOKANYMD.Text
        '処理対応完了日時（時間）
        gstrSYOKANTIME = txtSYOKANTIME.Text
        '対応相手
        gstrAITCD = Request.Form("cboSYUTDCD")
        'メータ表示遮断弁閉止確認（1:有）
        If chkMETHEIKAKU.Checked = True Then
            gstrMETHEIKAKU = "1"
        Else
            gstrMETHEIKAKU = "0"
        End If
        '留守宅表示の貼付（1:有）
        If chkRUSUHAIRI.Checked = True Then
            gstrRUSUHAIRI = "1"
        Else
            gstrRUSUHAIRI = "0"
        End If
        'ガス器具原因
        gstrKIGCD = Request.Form("cboKIGCD")
        'メータ作動原因
        gstrSADCD = Request.Form("cboSADCD")
        'メータ作動原因（圧力センサー作動原因）
        'gstrASECD = Request.Form("cboASECD")  ' 2008/10/16 T.Watabe edit
        gstrASECD = Request.Form("hdnASECD")
        'その他原因
        'gstrSTACD = Request.Form("cboSTACD")  ' 2008/10/16 T.Watabe edit
        gstrSTACD = Request.Form("hdnSTACD")
        '復帰対応
        gstrFKICD = Request.Form("cboFKICD")

        'ＪＡ／県連の連絡相手
        gstrJAKENREN = txtJAKENREN.Text
        '連絡時間
        gstrRENTIME = txtRENTIME.Text
        '簡易ガス器具の貸与（1:有）
        If chkKIGUTAIYO.Checked = True Then
            gstrKIGUTAIYO = "1"
        Else
            gstrKIGUTAIYO = "0"
        End If

        gstrMETFUKKI = "0"
        gstrHOAN = "0"
        gstrGASGIRE = "0"
        gstrKIGKOSYO = "0"
        gstrCSNTGEN = "0"
        gstrCSNTNGAS = "0"
        '2006/06/15 NEC UPDATE START
        'gstrSDTBIK1 = ""
        gstrSDTBIK1 = txtSDTBIK1.Text
        '2006/06/15 NEC UPDATE END

        '2006/06/20 NEC UPDATE START
        'Dim strHANASI As String
        'If rdoHanasi1.Checked = True Then
        '    strHANASI = Request.Form("cboHanasi")
        '    Select Case (strHANASI)
        '        Case ("1")
        '            gstrMETFUKKI = "1"
        '        Case ("2")
        '            gstrHOAN = "1"
        '        Case ("3")
        '            gstrGASGIRE = "1"
        '        Case ("4")
        '            gstrKIGKOSYO = "1"
        '        Case ("5")
        '            gstrCSNTGEN = "1"
        '    End Select
        'Else
        '    gstrCSNTNGAS = "1"
        '    '2006/06/15 NEC UPDATE START
        '    'gstrSDTBIK1 = txtSDTBIK1.Text
        '    '2006/06/15 NEC UPDATE END
        'End If
        Dim strHANASI As String
        strHANASI = Request.Form("cboHanasi")
        Select Case (strHANASI)
            Case ("1")
                gstrMETFUKKI = "1"
            Case ("2")
                gstrHOAN = "1"
            Case ("3")
                gstrGASGIRE = "1"
            Case ("4")
                gstrKIGKOSYO = "1"
            Case ("5")
                gstrCSNTGEN = "1"
        End Select
        If rdoHanasi1.Checked = True Then
        Else
            gstrCSNTNGAS = "1"
        End If
        '2006/06/20 NEC UPDATE END

        'ガス漏れ点検（0:有／1:無）
        If rdoGASMUMU1.Checked = True Then
            gstrGASMUMU = "0"
            If rdoGASMUMU_K.Checked = True Then
                gstrORGENIN = "1"               'ガス漏れ原因(ガス器具)
                gstrHAIKAN = "0"                'ガス漏れ原因(配管)
            Else
                gstrORGENIN = "0"               'ガス漏れ原因(ガス器具)
                gstrHAIKAN = "1"                'ガス漏れ原因(配管)
            End If
        Else
            gstrGASMUMU = "1"                   'ガス漏れ点検
            gstrORGENIN = "0"                   'ガス漏れ原因(ガス器具)
            gstrHAIKAN = "0"                    'ガス漏れ原因(配管)
        End If
        'ガス切れ原因（0:有／1:無）
        If rdoGASUGUMU1.Checked = True Then
            gstrGASUGUMU = "0"
        Else
            gstrGASUGUMU = "1"
        End If
        'ゴムホース交換（0:実施／1:未実施））
        If rdoHOSKOKAN1.Checked = True Then
            gstrHOSKOKAN = "0"
        Else
            gstrHOSKOKAN = "1"
        End If
        'その他点検項目（メーター）（0:良／1:否）
        If rdoMETYOINA1.Checked = True Then
            gstrMETYOINA = "0"
        Else
            gstrMETYOINA = "1"
        End If
        'その他点検項目（調整機）（0:良／1:否）
        If rdoTYOUYOINA1.Checked = True Then
            gstrTYOUYOINA = "0"
        Else
            gstrTYOUYOINA = "1"
        End If
        'その他点検項目（容器・中間バルブ）（0:良／1:否）
        If rdoVALYOINA1.Checked = True Then
            gstrVALYOINA = "0"
        Else
            gstrVALYOINA = "1"
        End If
        'その他点検項目（吸排気口）（0:良／1:否）
        If rdoKYUHAIUMU1.Checked = True Then
            gstrKYUHAIUMU = "0"
        Else
            gstrKYUHAIUMU = "1"
        End If
        'その他点検項目（ＣＯ濃度）（0:良／1:否）
        If rdoCOYOINA1.Checked = True Then
            gstrCOYOINA = "0"
        Else
            gstrCOYOINA = "1"
        End If
        '2006/06/15 NEC UPDATE START
        ''特記事項
        'gstrSDTBIK2 = txtSDTBIK2.Text
        ''その他特記事項（ＪＡ／県連への依頼等）
        'gstrSNTTOKKI = txtSNTTOKKI.Text
        '出動結果内容/報告
        ' 2013/10/25 T.Ono 監視改善№1 Start
        'gstrSDTBIK2 = txtSDTBIK2.Text
        'gstrSNTTOKKI = txtSNTTOKKI.Text
        'gstrSDTBIK3 = txtSDTBIK3.Text
        gstrSDTBIK2 = hdnSDTBIK2.Value      '1行目
        gstrSNTTOKKI = hdnSNTTOKKI.Value    '2行目
        gstrSDTBIK3 = hdnSDTBIK3.Value      '3行目
        ' 2013/10/25 T.Ono 監視改善№1 End

        '2006/06/15 NEC UPDATE END

        gstrEDT_DATE = hdnEDT_DATE.Value
        gstrEDT_TIME = hdnEDT_TIME.Value


    End Function
    '******************************************************************************
    '*　概　要：指針等出力時に使用（最後１桁を小数以下とする）
    '*　備　考：ただし数値の場合のみ、数値でない場合はそのままの値を返す
    '******************************************************************************
    Private Function fncEditSisin(ByVal strSisin As String) As String
        Dim strRec As String
        Dim NaNFncC As New CNaNFnc
        If IsNumeric(strSisin) = True Then
            If strSisin.Length = 0 Then
                strRec = ""
            ElseIf strSisin.Length = 1 Then
                strRec = "0." & strSisin
            Else
                strRec = strSisin
                strRec = Left(strRec, strRec.Length - 1) & "." & Right(strRec, 1)
                strRec = NaNFncC.mGet(strRec, 1)
            End If
        Else
            strRec = strSisin
        End If

        Return strRec
    End Function

    '******************************************************************************
    '*　概　要：指針等出力時に使用（右から数えた場合の桁数を小数以下桁数とする）
    '*　備　考：ただし数値の場合のみ、数値でない場合はそのままの値を返す
    '******************************************************************************
    '2005/11/22 NEC UPDATE JPG.KETAIJAG00から移植
    Private Function fncEditSisin2(ByVal strSisin As String, ByVal intKeta As Integer) As String
        Dim strRec As String
        Dim NaNFncC As New CNaNFnc
        If IsNumeric(strSisin) = True Then
            If strSisin.Length = 0 Then
                strRec = ""
                '小数点が含まれていたらそのまま値を返す
            ElseIf InStr(strSisin, ".") > 0 Then
                strRec = strSisin
            ElseIf strSisin.Length = 1 Then
                strRec = Convert.ToString(Convert.ToDecimal(strSisin) / 10D ^ Convert.ToDecimal(intKeta))
            Else
                'ゼロ埋め
                strRec = strSisin.PadLeft(8 - strSisin.Length, "0"c)
                strRec = Left(strRec, strRec.Length - intKeta) & "." & Right(strRec, intKeta)
                If intKeta = 1 Then
                    strRec = Format(Convert.ToDecimal(strRec), "##,###,##0.0")
                ElseIf intKeta = 3 Then
                    strRec = Format(Convert.ToDecimal(strRec), "##,###,##0.000")
                End If
            End If
        Else
            strRec = strSisin
        End If

        Return strRec
    End Function

    '2009/01/09 T.Watabe add
    '******************************************************************************
    '*　概　要：配送日等出力時に使用
    '*　備　考：日付の場合は変換以外はそのまま出力
    '******************************************************************************
    Private Function fncEditDate(ByVal strDate As String) As String
        Dim strRec As String
        Dim strFlg As String
        '日付チェック
        If strDate.Length = 8 Then
            strRec = strDate.Substring(0, 4) & "/" & strDate.Substring(4, 2) & "/" & strDate.Substring(6, 2)
            If IsDate(strRec) = True Then
                strFlg = "1"
            Else
                strFlg = "0"
            End If
        Else
            strFlg = "0"
        End If
        '日付でない場合はそのままの値をセット
        If strFlg = "0" Then
            strRec = strDate
        End If

        Return strRec
    End Function

    '2009/01/09 T.Watabe add
    '******************************************************************************
    '*　概　要：容量計算時に使用
    '*　備　考：容器と本数より容量を求める
    '******************************************************************************
    Private Function fncEditYouryou(ByVal strYouki As String, ByVal strHonsu As String) As String
        Dim strRec As String
        Dim NaNFncC As New CNaNFnc

        'いずれかが入っていない場合、もしくは数値でない場合は計算しない()
        If (strYouki.Length = 0 Or strHonsu.Length = 0) Or _
           (IsNumeric(strYouki) = False Or IsNumeric(strHonsu) = False) Then
            strRec = ""
        Else
            strRec = Convert.ToString(Convert.ToDecimal(strYouki) * Convert.ToDecimal(strHonsu))
            strRec = NaNFncC.mGet(strRec, 0)
        End If

        Return strRec
    End Function

    '******************************************************************************
    '*　概　要：コンボボックスの選択
    '*　備　考：
    '******************************************************************************
    Private Sub fncComboSet()
        Dim list As New ListItem

        ' 2014/10/22 H.Hosoda del 2014改善開発 No11 START
        '受信者氏名
        'If strCBO_TSTANCD <> "" Then
        '    list = cboTSTANCD.Items.FindByValue(strCBO_TSTANCD)
        '    cboTSTANCD.SelectedIndex = cboTSTANCD.Items.IndexOf(list)
        'End If
        ' 2014/10/22 H.Hosoda del 2014改善開発 No11 END

        '所属
        If strCBO_KYOTEN_CD <> "" Then
            list = cboSTD.Items.FindByValue(strCBO_KYOTEN_CD)
            cboSTD.SelectedIndex = cboSTD.Items.IndexOf(list)
        End If
        '対応相手コード
        If strCBO_AITCD <> "" Then
            list = cboSYUTDCD.Items.FindByValue(strCBO_AITCD)
            cboSYUTDCD.SelectedIndex = cboSYUTDCD.Items.IndexOf(list)
        End If
        '対応相手コード
        If strCBO_HANASI <> "" Then
            list = cboHanasi.Items.FindByValue(strCBO_HANASI)
            cboHanasi.SelectedIndex = cboHanasi.Items.IndexOf(list)
        End If
        '器具原因コード	
        If strCBO_KIGCD <> "" Then
            list = cboKIGCD.Items.FindByValue(strCBO_KIGCD)
            cboKIGCD.SelectedIndex = cboKIGCD.Items.IndexOf(list)
        End If
        '作動原因コード	
        If strCBO_SADCD <> "" Then
            list = cboSADCD.Items.FindByValue(strCBO_SADCD)
            cboSADCD.SelectedIndex = cboSADCD.Items.IndexOf(list)
        End If
        '圧力センサー作動原因 ' 2008/10/16 T.Watabe del
        'If strCBO_ASECD <> "" Then
        '    list = cboASECD.Items.FindByValue(strCBO_ASECD)
        '    cboASECD.SelectedIndex = cboASECD.Items.IndexOf(list)
        'End If
        'その他原因コード ' 2008/10/16 T.Watabe del
        'If strCBO_STACD <> "" Then
        '    list = cboSTACD.Items.FindByValue(strCBO_STACD)
        '    cboSTACD.SelectedIndex = cboSTACD.Items.IndexOf(list)
        'End If
        '復帰操作コード
        If strCBO_FKICD <> "" Then
            list = cboFKICD.Items.FindByValue(strCBO_FKICD)
            cboFKICD.SelectedIndex = cboFKICD.Items.IndexOf(list)
        End If

    End Sub
    ' 2014/10/22 H.Hosoda del 2014改善開発 No11 START
    '//-------------------------------------------------
    '// 受信者氏名
    '//-------------------------------------------------
    'Private Sub fncCombo_Create_TSTANCD()
    '    cboTSTANCD.pComboTitle = True
    '    cboTSTANCD.pNoData = False
    '    cboTSTANCD.pType = "SHUTUTAN"                   '//受信者氏名
    '    cboTSTANCD.pAllShutuCd = strCBO_STD_CD
    '    cboTSTANCD.mMakeCombo()
    'End Sub
    ' 2014/10/22 H.Hosoda del 2014改善開発 No11 END
    '//-------------------------------------------------
    '// 所属
    '//-------------------------------------------------
    Private Sub fncCombo_Create_STD()
        cboSTD.pComboTitle = True
        cboSTD.pNoData = False
        cboSTD.pType = "SYUSYOZOKU"                     '//所属
        cboSTD.pAllShutuCd = strCBO_STD_CD
        cboSTD.mMakeCombo()
    End Sub
    '//-------------------------------------------------
    '// 対応相手
    '//-------------------------------------------------
    Private Sub fncCombo_Create_SYUTDCD()
        cboSYUTDCD.pComboTitle = True
        cboSYUTDCD.pNoData = False
        cboSYUTDCD.pType = "SYUTAIOUAITE"               '//対応相手
        cboSYUTDCD.mMakeCombo()
    End Sub
    '//-------------------------------------------------
    '// お客様話
    '//-------------------------------------------------
    Private Sub fncCombo_Create_HANASI()
        cboHanasi.pComboTitle = True
        cboHanasi.pNoData = False
        cboHanasi.pType = "SYUGASUKAN"                  '//お客様話
        cboHanasi.mMakeCombo()
    End Sub
    '//-------------------------------------------------
    '// ガス器具原因
    '//-------------------------------------------------
    Private Sub fncCombo_Create_KIGCD()
        cboKIGCD.pComboTitle = False
        cboKIGCD.pNoData = False
        cboKIGCD.pType = "SYUGASUGEN"                   '//ガス器具原因
        cboKIGCD.mMakeCombo()
    End Sub
    '//-------------------------------------------------
    '// 復帰対応
    '//-------------------------------------------------
    Private Sub fncCombo_Create_FKICD()
        cboFKICD.pComboTitle = False
        cboFKICD.pNoData = False
        cboFKICD.pType = "SYUHUKKITAI"                  '//復帰対応
        cboFKICD.mMakeCombo()
    End Sub
    '//-------------------------------------------------
    '// メータ原因１
    '//-------------------------------------------------
    Private Sub fncCombo_Create_SADCD()
        cboSADCD.pComboTitle = False
        cboSADCD.pNoData = False
        cboSADCD.pType = "SYUMETAGEN1"                  '//メータ原因１
        cboSADCD.mMakeCombo()
    End Sub
    ' 2008/10/16 T.Watabe del
    '//-------------------------------------------------
    '// メータ原因２
    '//-------------------------------------------------
    'Private Sub fncCombo_Create_ASECD()
    '    cboASECD.pComboTitle = False
    '    cboASECD.pNoData = False
    '    cboASECD.pType = "SYUMETAGEN2"                  '//メータ原因２
    '    cboASECD.mMakeCombo()
    'End Sub
    ' 2008/10/16 T.Watabe del
    '//-------------------------------------------------
    '// その他原因
    '//-------------------------------------------------
    'Private Sub fncCombo_Create_STACD()
    '    cboSTACD.pComboTitle = False
    '    cboSTACD.pNoData = False
    '    cboSTACD.pType = "SYUSONOTAGEN"                 '//その他原因
    '    cboSTACD.mMakeCombo()
    'End Sub

    '******************************************************************************
    '*　概　要：ログインユーザー名を返すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pLOGIN_USER() As String
        Get
            Return Convert.ToString(Request.Cookies(ConstC.pCookie_SD_Logincd).Value)
        End Get
    End Property

    '******************************************************************************
    '*　概　要：ログインユーザーのIPADDRESSを返すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pLOGIN_IPADDRESS() As String
        Get
            Return Request.ServerVariables("REMOTE_ADDR")
        End Get
    End Property

    '******************************************************************************
    '*　概　要：MyAspxを返すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pMY_ASPX() As String
        Get
            Return hdnMyAspx.Value
        End Get
    End Property


    '******************************************************************************
    '*　概　要：
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pPRAM_KURACD() As String
        Get
            Return hdnKURACD.Value
        End Get
    End Property

    '******************************************************************************
    '*　概　要：
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pPRAM_JASCD() As String
        Get
            Return hdnJASCD.Value
        End Get
    End Property


    '******************************************************************************
    '*　概　要：hdnKEY_KANSCD取得プロパティ（2013/07/01 T.Ono add）
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pPRAM_KANSCD() As String
        Get
            Return hdnKEY_KANSCD.Value
        End Get
    End Property

    '******************************************************************************
    '*　概　要：hdnKEY_SYONO取得プロパティ（2013/07/01 T.Ono add）
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pPRAM_SYONO() As String
        Get
            Return hdnKEY_SYONO.Value
        End Get
    End Property

    '******************************************************************************
    '*　概　要：絞込み条件を渡すプロパティ1　2014/10/23 H.Hosoda add 2014改善開発 No11
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pCode1() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = hdnSTDCD.Value
                Case Else
                    strRec = ""
            End Select
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：絞込み条件を渡すプロパティ2　2014/10/23 H.Hosoda add 2014改善開発 No11
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pCode2() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = ""
                Case Else
                    strRec = ""
            End Select
            Return strRec
        End Get
    End Property


    '******************************************************************************
    '*　概　要：出力する一覧の名前を渡すプロパティ　2014/10/23 H.Hosoda add 2014改善開発 No11
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pListName() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = "出動会社担当者一覧"
                Case Else
                    strRec = ""
            End Select
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：出力する一覧を制御する値を渡すプロパティ　2014/10/23 H.Hosoda add 2014改善開発 No11
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pListCd() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = "TSTANCD"
                Case Else
                    strRec = ""
            End Select
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：コードを返すオブジェクトの名前値を渡すプロパティ　2014/10/23 H.Hosoda add 2014改善開発 No11
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pBackCode() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = "hdnTSTAN_CD"
                Case Else
                    strRec = ""
            End Select
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：名称を返すオブジェクトの名前値を渡すプロパティ　2014/10/23 H.Hosoda add 2014改善開発 No11
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pBackName() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = "txtTSTAN_CD"
                Case Else
                    strRec = ""
            End Select
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：名称のみを返すオブジェクトの名前値を渡すプロパティ　2014/10/30 H.Hosoda add 2014改善開発 No11
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pBackNameOnly() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = "hdnTSTAN_NM"
                Case Else
                    strRec = ""
            End Select
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：フォーカスを返すオブジェクトの名前値を渡すプロパティ　2014/10/23 H.Hosoda add 2014改善開発 No11
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pBackFocs() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = "btnTSTAN_CD"
                Case Else
                    strRec = ""
            End Select

            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*　概　要：ＪＡが変更された時にクリアするオブジェクトの名前値を渡すプロパティ１　2014/10/23 H.Hosoda add 2014改善開発 No11
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pClearName() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = ""
                Case Else
                    strRec = ""
            End Select
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：ＪＡが変更された時にクリアするオブジェクトの名前値を渡すプロパティ１　2014/10/23 H.Hosoda add 2014改善開発 No11
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pClearCode() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = ""
                Case Else
                    strRec = ""
            End Select
            Return strRec
        End Get
    End Property

End Class
