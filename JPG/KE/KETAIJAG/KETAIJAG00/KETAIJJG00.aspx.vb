'***********************************************
' 対応入力  実行処理
'***********************************************
' 変更履歴
' 2010/10/27 T.Watabe FAX不要(ｸﾗｲｱﾝﾄ)を関数引数に追加。KETAIJAW00C.mSet_TaiouをKETAIJAW00C.mSet_Taiou2へ変更

Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common
Imports JPG.Common.log

Imports System.Text
Imports System.IO

Partial Class KETAIJJG00
    Inherits System.Web.UI.Page

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
    '*　概　要：実行ボタン押下時
    '*　備　考：
    '******************************************************************************
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                                                                    Handles MyBase.Load
        '//------------------------------------------
        HttpHeaderC.mNoCache(Response)

        '//------------------------------------------
        '// 認証クラスのインスタンス生成
        AuthC = New CAuthenticate(Request, Response)

        '//------------------------------------------
        '// ＷＥＢサービスのインスタンスを作成
        Dim strRec As String
        Dim KETAIJAW00C As New KETAIJAG00KETAIJAW00.KETAIJAW00

        '//------------------------------------------
        '// 呼び出し元の画面クラスインスタンスを作成
        Dim KETAIJAG00C As KETAIJAG00
        KETAIJAG00C = CType(Context.Handler, KETAIJAG00)

        '//------------------------------------------
        '// ＷＥＢサービスの実行
        '2005/09/09 ADD Falcon 備考、ＦＡＸタイトルコード追加
        '           DEL Falcon お客様記事
        'strRec = KETAIJAW00C.mSet_Taiou(KETAIJAG00C.pBackUrl, _ ' 2010/10/27 T.Watabe edit
        ' 2013/05/27 T.Ono edit TEL3追加
        ' 2013/08/23 T.Ono edit 本日工事状況追加 監視改善2013№1
        ' 2014/12/17 T.Ono edit 販売事業者コード・名称追加 2014改善開発 No2
        ' 2016/02/02 W.GANEKO edit 監視備考、連絡先2、連絡先3追加 2015改善開発 No1-3
        ' 2016/12/22 H.Mori mod 2016改善開発 No4-1 NCU接続 START
        ' 2016/12/14 H.Mori mod 供給形態区分、スポットFAX区分、電話番号、第3連動連絡先、法人代表者氏名、適用法令区分、用途区分、販売書コード、緊急連絡先CD 2016改善開発 No4-6
        ' 2017/10/16 H.Mori mod 集合区分 2017改善開発 No4-1
        ' 2020/11/01 T.Ono mod 2020監視改善 電話対応メモ拡張TEL_MEMO4～6追加
        ' 2023/01/04 ADD Y.ARAKAKI 2022更改No⑥ _帳票JMコード表示追加対応 引数にJM和名（gstrJMNAME）を追加. D20_TAIOUにもカラム追加。
        strRec = KETAIJAW00C.mSet_Taiou2(KETAIJAG00C.pBackUrl,
                                        KETAIJAG00C.pMoveSerial,
                                        KETAIJAG00C.gstrKBN,
                                        KETAIJAG00C.gstrKANSCD,
                                        KETAIJAG00C.gstrSYONO,
                                        KETAIJAG00C.gstrNCUHATYMD,
                                        KETAIJAG00C.gstrNCUHATTIME,
                                        KETAIJAG00C.gstrHATYMD,
                                        KETAIJAG00C.gstrHATTIME,
                                        KETAIJAG00C.gstrKENSIN,
                                        KETAIJAG00C.gstrKEIHOSU,
                                        KETAIJAG00C.gstrRYURYO,
                                        KETAIJAG00C.gstrMETASYU,
                                        KETAIJAG00C.gstrUNYO,
                                        KETAIJAG00C.gstrJUYMD,
                                        KETAIJAG00C.gstrJUTIME,
                                        KETAIJAG00C.gstrNUM_DIGIT,
                                        KETAIJAG00C.gstrKMCD1,
                                        KETAIJAG00C.gstrKMNM1,
                                        KETAIJAG00C.gstrKMCD2,
                                        KETAIJAG00C.gstrKMNM2,
                                        KETAIJAG00C.gstrKMCD3,
                                        KETAIJAG00C.gstrKMNM3,
                                        KETAIJAG00C.gstrKMCD4,
                                        KETAIJAG00C.gstrKMNM4,
                                        KETAIJAG00C.gstrKMCD5,
                                        KETAIJAG00C.gstrKMNM5,
                                        KETAIJAG00C.gstrKMCD6,
                                        KETAIJAG00C.gstrKMNM6,
                                        KETAIJAG00C.gstrKURACD,
                                        KETAIJAG00C.gstrKENNM,
                                        KETAIJAG00C.gstrJACD,
                                        KETAIJAG00C.gstrJANM,
                                        KETAIJAG00C.gstrHANJICD,
                                        KETAIJAG00C.gstrHANJINM,
                                        KETAIJAG00C.gstrACBCD,
                                        KETAIJAG00C.gstrACBNM,
                                        KETAIJAG00C.gstrUSER_CD,
                                        KETAIJAG00C.gstrJUSYONM,
                                        KETAIJAG00C.gstrJUSYOKN,
                                        KETAIJAG00C.gstrJUTEL1,
                                        KETAIJAG00C.gstrJUTEL2,
                                        KETAIJAG00C.gstrRENTEL,
                                        KETAIJAG00C.gstrKTELNO,
                                        KETAIJAG00C.gstrADDR,
                                        KETAIJAG00C.gstrNCU_SET,
                                        KETAIJAG00C.gstrTIZUNO,
                                        KETAIJAG00C.gstrHANBAI_KBN,
                                        KETAIJAG00C.gstrKYOKTKBN,
                                        KETAIJAG00C.gstrMET_KATA,
                                        KETAIJAG00C.gstrMET_MAKER,
                                        KETAIJAG00C.gstrBONB1_KKG,
                                        KETAIJAG00C.gstrBONB1_HON,
                                        KETAIJAG00C.gstrBONB1_YOBI,
                                        KETAIJAG00C.gstrBONB2_KKG,
                                        KETAIJAG00C.gstrBONB2_HON,
                                        KETAIJAG00C.gstrBONB2_YOBI,
                                        KETAIJAG00C.gstrBONB3_KKG,
                                        KETAIJAG00C.gstrBONB3_HON,
                                        KETAIJAG00C.gstrBONB3_YOBI,
                                        KETAIJAG00C.gstrBONB4_KKG,
                                        KETAIJAG00C.gstrBONB4_HON,
                                        KETAIJAG00C.gstrBONB4_YOBI,
                                        KETAIJAG00C.gstrZENKAI_HAISO,
                                        KETAIJAG00C.gstrZENKAI_HAI_S,
                                        KETAIJAG00C.gstrKONKAI_HAISO,
                                        KETAIJAG00C.gstrKONKAI_HAI_S,
                                        KETAIJAG00C.gstrJIKAI_HAISO,
                                        KETAIJAG00C.gstrZENKAI_KENSIN,
                                        KETAIJAG00C.gstrZENKAI_KEN_S,
                                        KETAIJAG00C.gstrZENKAI_KEN_SIYO,
                                        KETAIJAG00C.gstrKONKAI_KENSIN,
                                        KETAIJAG00C.gstrKONKAI_KEN_S,
                                        KETAIJAG00C.gstrKONKAI_KEN_SIYO,
                                        KETAIJAG00C.gstrZENKAI_HASEI,
                                        KETAIJAG00C.gstrZENKAI_HAS_S,
                                        KETAIJAG00C.gstrKONKAI_HASEI,
                                        KETAIJAG00C.gstrKONKAI_HAS_S,
                                        KETAIJAG00C.gstrG_ZAIKO,
                                        KETAIJAG00C.gstrICHI_SIYO,
                                        KETAIJAG00C.gstrYOSOKU_ICHI_SIYO,
                                        KETAIJAG00C.gstrGAS1_HINMEI,
                                        KETAIJAG00C.gstrGAS1_DAISU,
                                        KETAIJAG00C.gstrGAS1_SEIFL,
                                        KETAIJAG00C.gstrGAS2_HINMEI,
                                        KETAIJAG00C.gstrGAS2_DAISU,
                                        KETAIJAG00C.gstrGAS2_SEIFL,
                                        KETAIJAG00C.gstrGAS3_HINMEI,
                                        KETAIJAG00C.gstrGAS3_DAISU,
                                        KETAIJAG00C.gstrGAS3_SEIFL,
                                        KETAIJAG00C.gstrGAS4_HINMEI,
                                        KETAIJAG00C.gstrGAS4_DAISU,
                                        KETAIJAG00C.gstrGAS4_SEIFL,
                                        KETAIJAG00C.gstrGAS5_HINMEI,
                                        KETAIJAG00C.gstrGAS5_DAISU,
                                        KETAIJAG00C.gstrGAS5_SEIFL,
                                        KETAIJAG00C.gstrHATKBN,
                                        KETAIJAG00C.gstrTAIOKBN,
                                        KETAIJAG00C.gstrTMSKB,
                                        KETAIJAG00C.gstrTKTANCD,
                                        KETAIJAG00C.gstrTAITCD,
                                        KETAIJAG00C.gstrTAIO_ST_DATE,
                                        KETAIJAG00C.gstrTAIO_ST_TIME,
                                        KETAIJAG00C.gstrSYOYMD,
                                        KETAIJAG00C.gstrSYOTIME,
                                        KETAIJAG00C.gstrTAIO_SYO_TIME,
                                        KETAIJAG00C.gstrFAXKBN,
                                        KETAIJAG00C.gstrFAXKURAKBN,
                                        KETAIJAG00C.gstrFAXRUISEKIKBN,
                                        KETAIJAG00C.gstrTELRCD,
                                        KETAIJAG00C.gstrTFKICD,
                                        KETAIJAG00C.gstrFUK_MEMO,
                                        KETAIJAG00C.gstrTEL_MEMO1,
                                        KETAIJAG00C.gstrTEL_MEMO2,
                                        KETAIJAG00C.gstrTEL_MEMO4,
                                        KETAIJAG00C.gstrTEL_MEMO5,
                                        KETAIJAG00C.gstrTEL_MEMO6,
                                        KETAIJAG00C.gstrMITOKBN,
                                        KETAIJAG00C.gstrTKIGCD,
                                        KETAIJAG00C.gstrTSADCD,
                                        KETAIJAG00C.gstrGENIN_KIJI,
                                        KETAIJAG00C.gstrSDCD,
                                        KETAIJAG00C.gstrSIJIYMD,
                                        KETAIJAG00C.gstrSIJITIME,
                                        KETAIJAG00C.gstrSIJI_BIKO1,
                                        KETAIJAG00C.gstrSIJI_BIKO2,
                                        KETAIJAG00C.gstrSTD_JASCD,
                                        KETAIJAG00C.gstrSTD_JANA,
                                        KETAIJAG00C.gstrSTD_JASNA,
                                        KETAIJAG00C.gstrREN_CODE,
                                        KETAIJAG00C.gstrREN_NA,
                                        KETAIJAG00C.gstrREN_TEL_1,
                                        KETAIJAG00C.gstrREN_TEL_2,
                                        KETAIJAG00C.gstrREN_TEL_3,
                                        KETAIJAG00C.gstrREN_FAX,
                                        KETAIJAG00C.gstrREN_BIKO,
                                        KETAIJAG00C.gstrREN_EDT_DATE,
                                        KETAIJAG00C.gstrREN_TIME,
                                        KETAIJAG00C.gstrREN_1_CODE,
                                        KETAIJAG00C.gstrREN_1_NA,
                                        KETAIJAG00C.gstrREN_1_TEL1,
                                        KETAIJAG00C.gstrREN_1_TEL2,
                                        KETAIJAG00C.gstrREN_1_TEL3,
                                        KETAIJAG00C.gstrREN_1_FAX,
                                        KETAIJAG00C.gstrREN_1_BIKO,
                                        KETAIJAG00C.gstrREN_1_EDT_DATE,
                                        KETAIJAG00C.gstrREN_1_TIME,
                                        KETAIJAG00C.gstrREN_2_CODE,
                                        KETAIJAG00C.gstrREN_2_NA,
                                        KETAIJAG00C.gstrREN_2_TEL1,
                                        KETAIJAG00C.gstrREN_2_TEL2,
                                        KETAIJAG00C.gstrREN_2_TEL3,
                                        KETAIJAG00C.gstrREN_2_FAX,
                                        KETAIJAG00C.gstrREN_2_BIKO,
                                        KETAIJAG00C.gstrREN_2_EDT_DATE,
                                        KETAIJAG00C.gstrREN_2_TIME,
                                        KETAIJAG00C.gstrREN_3_CODE,
                                        KETAIJAG00C.gstrREN_3_NA,
                                        KETAIJAG00C.gstrREN_3_TEL1,
                                        KETAIJAG00C.gstrREN_3_TEL2,
                                        KETAIJAG00C.gstrREN_3_TEL3,
                                        KETAIJAG00C.gstrREN_3_FAX,
                                        KETAIJAG00C.gstrREN_3_BIKO,
                                        KETAIJAG00C.gstrREN_3_EDT_DATE,
                                        KETAIJAG00C.gstrREN_3_TIME,
                                        KETAIJAG00C.gstrREN_DENWABIKO,
                                        KETAIJAG00C.gstrREN_FAXTITLE,
                                        KETAIJAG00C.gstrREN_FAX_REN,
                                        KETAIJAG00C.gstrSTD_CD,
                                        KETAIJAG00C.gstrSTD,
                                        KETAIJAG00C.gstrSTD_KYOTEN_CD,
                                        KETAIJAG00C.gstrSTD_KYOTEN,
                                        KETAIJAG00C.gstrSTD_TEL,
                                        KETAIJAG00C.gstrADD_DATE,
                                        KETAIJAG00C.gstrEDT_DATE,
                                        KETAIJAG00C.gstrTIME,
                                        KETAIJAG00C.gstrBOMB_TYPE,
                                        KETAIJAG00C.gstrGAS_STOP,
                                        KETAIJAG00C.gstrGAS_DELE,
                                        KETAIJAG00C.gstrGAS_RESTART,
                                        KETAIJAG00C.gstrKAITU_DAY,
                                        KETAIJAG00C.gstrBIKOU,
                                        KETAIJAG00C.gstrFAX_TITLE_CD,
                                        KETAIJAG00C.gstrDialKbns,
                                        KETAIJAG00C.gstrDialNumbers,
                                        KETAIJAG00C.gstrDialAites,
                                        KETAIJAG00C.gstrDialResult,
                                        KETAIJAG00C.gstrDialDates,
                                        KETAIJAG00C.gstrDialTimes,
                                        KETAIJAG00C.gstrDialStates,
                                        KETAIJAG00C.gstrSDSKBN,
                                        "0",
                                        KETAIJAG00C.gstrKANSHI_BIKO,
                                        KETAIJAG00C.gstrRENTEL2,
                                        KETAIJAG00C.gstrRENTEL2_BIKO,
                                        KETAIJAG00C.gstrRENTEL2_UPD_DATE,
                                        KETAIJAG00C.gstrRENTEL3,
                                        KETAIJAG00C.gstrRENTEL3_BIKO,
                                        KETAIJAG00C.gstrRENTEL3_UPD_DATE,
                                        KETAIJAG00C.gstrTUSIN,
                                        KETAIJAG00C.gstrFAXSPOTKBN,
                                        KETAIJAG00C.gstrTELAB,
                                        KETAIJAG00C.gstrDAI3RENDORENTEL,
                                        KETAIJAG00C.gstrDAIHYO_NAME,
                                        KETAIJAG00C.gstrHOKBN,
                                        KETAIJAG00C.gstrYOTOKBN,
                                        KETAIJAG00C.gstrHANBCD,
                                        KETAIJAG00C.gstrKINRENCD,
                                        KETAIJAG00C.gstrSHUGOU,
                                        KETAIJAG00C.gstrJMNAME
                                        )

        Dim strRecMsg As String
        If strRec <> "OK" Then
            strMsg.Append("parent.Data.Form1.btnExit.disabled=false;")
            strMsg.Append("parent.Data.Form1.btnTelHas1.disabled=false;")
            strMsg.Append("parent.Data.Form1.btnRireki.disabled=false;")
            strMsg.Append("parent.Data.Form1.btnUpdate.disabled=false;")
            strMsg.Append("parent.Data.Form1.btnRenraku.disabled=false;")
            strMsg.Append("parent.Data.Form1.txtSYOYMD.readOnly=false;")
            strMsg.Append("parent.Data.Form1.txtSIJIYMD.readOnly=false;")
        End If

        Select Case strRec
            Case "OK"   '//正常終了
                If KETAIJAG00C.pBackUrl() = "KEJUKJAG00" Then
                    '2012/06/28 W.GANEKO ADD
                    mlog("対応入力登録|" & KETAIJAG00C.pMoveSerial & "|1" & KETAIJAG00C.gstrHATYMD & KETAIJAG00C.gstrHATTIME & KETAIJAG00C.pMoveSerial)
                End If
                '--- ↓2005/05/19 MOD Falcon↓ ---
                strMsg.Append("alert('正常に終了しました');")
                If Request.Form("hdnCtiFlg") = "1" Then
                    'ＣＴＩによるデータ更新⇒画面を閉じる
                    strMsg.Append("parent.Data.fncWindow_close();")
                Else
                    '通常処理⇒画面遷移
                    'その他処理の場合は終了ボタンイベント
                    strMsg.Append("parent.Data.doPostBack('btnExit','');")
                End If
                '--- ↑2005/05/19 MOD Falcon↑ ---
            Case "1"
                strRecMsg = "対象データが存在しません"
                strMsg.Append("alert('" & strRecMsg & "');")
                strRec = strRecMsg
                strMsg.Append("parent.Data.Form1.btnUpdate.focus();")
            Case "2"
                strRecMsg = "他のユーザーによってデータが更新されています。再度検索してください"
                strMsg.Append("alert('" & strRecMsg & "');")
                strRec = strRecMsg
                strMsg.Append("parent.Data.Form1.btnUpdate.focus();")
            Case "3"
                strRecMsg = "既に対応済みになっています"
                strMsg.Append("alert('" & strRecMsg & "');")
                strRec = strRecMsg
                strMsg.Append("parent.Data.Form1.btnUpdate.focus();")
            Case "T0"
                strRecMsg = "担当者データが、他のユーザーによってデータが更新されています。再度処理してください"
                strMsg.Append("alert('" & strRecMsg & "');")
                strRec = strRecMsg
                strMsg.Append("parent.Data.Form1.btnUpdate.focus();")
            Case "T1"
                strRecMsg = "担当者データが、既にデータが存在します"
                strMsg.Append("alert('" & strRecMsg & "');")
                strRec = strRecMsg
                strMsg.Append("parent.Data.Form1.btnUpdate.focus();")
            Case "T2"
                strRecMsg = "対象の担当者データが存在しません"
                strMsg.Append("alert('" & strRecMsg & "');")
                strRec = strRecMsg
                strMsg.Append("parent.Data.Form1.btnUpdate.focus();")
            Case "T3"
                strRecMsg = "担当者データ更新時、排他制御処理でエラーが発生しました。再度実行してください"
                strMsg.Append("alert('" & strRecMsg & "');")
                strRec = strRecMsg
                strMsg.Append("parent.Data.Form1.btnUpdate.focus();")
            Case "T4"
                strRecMsg = "担当者データのクライアントコードが存在しません"
                strMsg.Append("alert('" & strRecMsg & "');")
                strRec = strRecMsg
                strMsg.Append("parent.Data.Form1.btnUpdate.focus();")
            Case "T5"
                strRecMsg = "ＪＡ支所が存在しません"
                strMsg.Append("alert('" & strRecMsg & "');")
                strRec = strRecMsg
                strMsg.Append("parent.Data.Form1.btnUpdate.focus();")
            Case Else
                Dim ErrMsgC As New CErrMsg
                strMsg.Append("alert('システムエラー：" & ErrMsgC.mGetArtMsg(strRec) & "');")
                strMsg.Append("parent.Data.Form1.btnUpdate.focus();")
        End Select

        '-------------------------------------------------
        '//ＡＰログ書き込み
        Dim LogC As New CLog
        Dim strRecLog As String
        '2012/04/04 NEC ou Upd Str
        'strRecLog = LogC.mAPLog(Request.Cookies.Get("ASP.NET_SessionId").Value, AuthC.pUSERNAME, AuthC.pIPADDRESS, Request.Form("hdnMyAspx"), KETAIJAG00C.gstrKBN, strRec, Request.Form)
        strRecLog = LogC.mAPLog(Me.Session.SessionID, AuthC.pUSERNAME, AuthC.pIPADDRESS, Request.Form("hdnMyAspx"), KETAIJAG00C.gstrKBN, strRec, Request.Form)
        '2012/04/04 NEC ou Upd End
        If strRecLog <> "OK" Then
            Dim errmsgc As New CErrMsg
            strMsg.Append("alert('システムエラー：" & errmsgc.mGetArtMsg(strRecLog) & "');")
        End If

        '-------------------------------------------------
        '//
        strMsg.Append("location.replace('about:blank');")   '受信フレーム内をブランクページに。

    End Sub
    '**********************************************************
    '2012/06/28 W.GANEKO ADD
    'ログ吐き出し
    '戻り値：書き込んだファイルへのフルパス
    '**********************************************************
    Public Sub mlog(ByVal pstrString As String)
        Dim strFilnm As String = "log" & System.DateTime.Today.ToString("yyyyMMdd")
        Dim strLogPath As String = ConfigurationSettings.AppSettings("LOG_OUT_PATH")
        Dim strPath As String = strLogPath & strFilnm & ".txt"
        Dim strLogFlg As String = ConfigurationSettings.AppSettings("LOG_OUT")
        Dim linestring As New StringBuilder("")
        Dim LogC As New CLog

        Dim strRecLog As String
        If strLogFlg = "1" Then
            '書き込みファイルへのストリーム
            'Dim sw As StreamWriter
            'Dim fs As New FileStream(strPath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite)
            'linestring = New StringBuilder("")
            'linestring.Append(System.DateTime.Now & "." & System.DateTime.Now.Millisecond & "[" & AuthC.pUSERNAME & "][" & AuthC.pIPADDRESS & "][" & Me.Session.SessionID & "]" & pstrString & Chr(13) & Chr(10))
            Dim tbllog As String = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff") & " " & pstrString
            strRecLog = LogC.mAPLog(Me.Session.SessionID, AuthC.pUSERNAME, AuthC.pIPADDRESS, Request.Form("hdnMyAspx"), "4", tbllog, Request.Form)
            'sw = New StreamWriter(fs, System.Text.Encoding.Default)

            ''引数の文字列をストリームに書き込み
            'sw.Write(linestring.ToString)

            ''メモリフラッシュ（ファイル書き込み）
            ''sw.Flush()

            ''ファイルクローズ
            'sw.Close()
            'sw.Dispose()
            'fs.Close()
            'fs.Dispose()
        End If
    End Sub
End Class
