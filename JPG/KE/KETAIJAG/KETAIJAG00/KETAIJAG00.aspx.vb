'***********************************************
'対応入力  メイン画面
'***********************************************
' 変更履歴
' 2008/10/24 T.Watabe  NCU接続にSHAMASの通信モードを表示するように変更
' 2008/10/29 T.Watabe  警報からの場合に、住所末尾が切れないように対応
' 2009/01/05 T.Watabe  「0～9」はそのまま、「: ; < = > ?」はそれぞれ「10 11 12 13 14 15」に置き換え、その他は「0」
' 2009/02/17 T.Watabe  上記対応に加えて「0～15」はそのままとする。
' 2009/03/23 T.Watabe  T10_KEIHOのNCU警報発生日・時間を参照するように変更
' 2011/11/28 H.Uema    JA注意事項表示及びFAX不要区分(ｸﾗｲｱﾝﾄ)設定対応
' 2011/12/01 H.Uema    FAX不要区分(JA)設定対応
' 2013/05    T.Ono     監視改善2013　顧客単位登録機能追加
' 2013/08    T.Ono     監視改善2013　№1　画面項目追加等
' 2013/12    T.Ono     監視改善2013　表示パネル追加項目、顧客検索等追加項目への戻り値を追加
' 2014/02    T.Ono     監視改善2013　重複表示対応
' 2014/12    T.Ono     2014改善開発　№2
' 2019/11    W.GANEKO  2019改善開発　№8-12
' 2020/11    T.Ono     2020監視改善
' 2021/10/01 saka      2021年度監視改善②の警報により原因器具プルダウンのセット内容を制御するのは、手入力する対応区分と併せた制御が今回できないため、すべてコメント化(対応区分の制御含めて復活の可能性あり)
' 2022/07/29 Y.ARAKAKI 2022更改No8 (調査含めた先行着手) _対応入力画面の対応区分＋警報メッセージ組合せのリスト絞込対応
' 2023/01/04 Y.ARAKAKI 2022更改No⑥ _帳票JMコード表示追加対応 

Option Explicit On
Option Strict On

Imports Common
Imports Common.DB   '2019/11/01 w.ganeko 2019/11/01 2019監視改善
Imports JPG.Common

Imports System.Text
Imports System.Diagnostics
Imports System.IO
Imports JPG.Common.log

Partial Class KETAIJAG00
    Inherits System.Web.UI.Page
    '--- ↓2005/04/20 ADD　Falcon↓ -----------------
    '--- ↑2005/04/20 ADD　Falcon↑ -----------------
    '--- ↓2005/05/19 ADD Falcon↓ ---
    '--- ↑2005/05/19 ADD Falcon↑ ---
    '--- ↓2005/09/09 ADD Falcon↓ ---
    '--- ↑2005/09/09 ADD Falcon↑ ---



    ' 2008/10/31 T.Watabe add

    ' 2010/05/10 T.Watabe add
    '2012/03/26 START ADD W.GANEKO
    '2012/03/26 END ADD W.GANEKO


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
    '2010/05/10 T.Watabe add
    'Protected WithEvents Button1 As System.Web.UI.HtmlControls.HtmlInputButton
    'Protected WithEvents Button2 As System.Web.UI.HtmlControls.HtmlInputButton
    'Protected WithEvents Button3 As System.Web.UI.HtmlControls.HtmlInputButton
    'Protected WithEvents Button4 As System.Web.UI.HtmlControls.HtmlInputButton
    'Protected WithEvents Button5 As System.Web.UI.HtmlControls.HtmlInputButton
    'Protected WithEvents Button6 As System.Web.UI.HtmlControls.HtmlInputButton
    'Protected WithEvents btnSearchTEL As System.Web.UI.HtmlControls.HtmlInputButton


    '<TODO>宣言共通仕様
    '******************************************************************************
    ' ScriptMessage
    '******************************************************************************
    Private strMsg As New StringBuilder("")      '//<script>は必要なし

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

    '******************************************************************************
    '登録系フレームワークPublic変数　（登録・削除時に格納します。）
    '******************************************************************************
    Private strCBO_TAIOKBN As String
    Private strCBO_TMSKB As String
    Private strCBO_TAITCD As String
    Private strCBO_TELRCD As String
    Private strCBO_TFKICD As String
    Private strCBO_TKIGCD As String
    Private strCBO_TSADCD As String
    Private strCBO_SDCD As String
    '''''--------------------------
    Public gstrKBN As String
    Public gstrKANSCD As String
    Public gstrSYONO As String
    Public gstrNCUHATYMD As String ' 2008/10/15 T.Watabe add
    Public gstrNCUHATTIME As String ' 2008/10/15 T.Watabe add
    Public gstrHATYMD As String
    Public gstrHATTIME As String
    Public gstrKENSIN As String
    Public gstrKEIHOSU As String
    Public gstrRYURYO As String
    Public gstrMETASYU As String
    Public gstrUNYO As String
    Public gstrJUYMD As String
    Public gstrJUTIME As String
    Public gstrNUM_DIGIT As String
    Public gstrKMCD1 As String
    Public gstrKMNM1 As String
    Public gstrKMCD2 As String
    Public gstrKMNM2 As String
    Public gstrKMCD3 As String
    Public gstrKMNM3 As String
    Public gstrKMCD4 As String
    Public gstrKMNM4 As String
    Public gstrKMCD5 As String
    Public gstrKMNM5 As String
    Public gstrKMCD6 As String
    Public gstrKMNM6 As String
    Public gstrKURACD As String
    Public gstrKENNM As String
    Public gstrJACD As String
    Public gstrJANM As String
    Public gstrHANJICD As String '販売事業者コード 2014/12/17 T.Ono add 2014改善開発 No2 START
    Public gstrHANJINM As String '販売事業者名     2014/12/17 T.Ono add 2014改善開発 No2 START
    Public gstrACBCD As String
    Public gstrACBNM As String
    Public gstrUSER_CD As String
    Public gstrJUSYONM As String
    Public gstrJUSYOKN As String
    Public gstrJUTEL1 As String
    Public gstrJUTEL2 As String
    Public gstrRENTEL As String
    Public gstrKTELNO As String
    Public gstrADDR As String
    '--- ↓2005/09/09 MOD Falcon↓ ---
    'Public gstrUSER_KIJI As String
    Public gstrBIKOU As String
    '--- ↑2005/09/09 MOD Falcon↑ ---
    Public gstrNCU_SET As String
    Public gstrTIZUNO As String
    Public gstrHANBAI_KBN As String '販売区分 2015/11/25 H.Mori add 2015改善開発 No1
    Public gstrKYOKTKBN As String   '供給形態区分 2016/12/02 H.Mori add 2016改善開発 No4-3
    Public gstrMET_KATA As String
    Public gstrMET_MAKER As String
    Public gstrBONB1_KKG As String
    Public gstrBONB1_HON As String
    Public gstrBONB1_YOBI As String
    Public gstrBONB2_KKG As String
    Public gstrBONB2_HON As String
    Public gstrBONB2_YOBI As String
    Public gstrBONB3_KKG As String
    Public gstrBONB3_HON As String
    Public gstrBONB3_YOBI As String
    Public gstrBONB4_KKG As String
    Public gstrBONB4_HON As String
    Public gstrBONB4_YOBI As String
    Public gstrZENKAI_HAISO As String
    Public gstrZENKAI_HAI_S As String
    Public gstrKONKAI_HAISO As String
    Public gstrKONKAI_HAI_S As String
    Public gstrJIKAI_HAISO As String
    Public gstrZENKAI_KENSIN As String
    Public gstrZENKAI_KEN_S As String
    Public gstrZENKAI_KEN_SIYO As String
    Public gstrKONKAI_KENSIN As String
    Public gstrKONKAI_KEN_S As String
    Public gstrKONKAI_KEN_SIYO As String
    Public gstrZENKAI_HASEI As String
    Public gstrZENKAI_HAS_S As String
    Public gstrKONKAI_HASEI As String
    Public gstrKONKAI_HAS_S As String
    Public gstrG_ZAIKO As String
    Public gstrICHI_SIYO As String
    Public gstrYOSOKU_ICHI_SIYO As String
    Public gstrGAS1_HINMEI As String
    Public gstrGAS1_DAISU As String
    Public gstrGAS1_SEIFL As String
    Public gstrGAS2_HINMEI As String
    Public gstrGAS2_DAISU As String
    Public gstrGAS2_SEIFL As String
    Public gstrGAS3_HINMEI As String
    Public gstrGAS3_DAISU As String
    Public gstrGAS3_SEIFL As String
    Public gstrGAS4_HINMEI As String
    Public gstrGAS4_DAISU As String
    Public gstrGAS4_SEIFL As String
    Public gstrGAS5_HINMEI As String
    Public gstrGAS5_DAISU As String
    Public gstrGAS5_SEIFL As String
    Public gstrHATKBN As String
    Public gstrTAIOKBN As String
    Public gstrTMSKB As String
    Public gstrTKTANCD As String
    Public gstrTAITCD As String
    Public gstrTAIO_ST_DATE As String
    Public gstrTAIO_ST_TIME As String
    Public gstrSYOYMD As String
    Public gstrSYOTIME As String
    Public gstrTAIO_SYO_TIME As String
    Public gstrFAXKBN As String
    Public gstrFAXKURAKBN As String ' 2010/07/12 T.Watabe add
    Public gstrFAXRUISEKIKBN As String ' 2015/11/17 H.Mori add 2015改善開発 No1
    Public gstrTELRCD As String
    Public gstrTFKICD As String
    Public gstrFUK_MEMO As String
    Public gstrTEL_MEMO1 As String
    Public gstrTEL_MEMO2 As String
    Public gstrTEL_MEMO4 As String  '2020/11/01 T.Ono add 2020監視改善
    Public gstrTEL_MEMO5 As String  '2020/11/01 T.Ono add 2020監視改善
    Public gstrTEL_MEMO6 As String  '2020/11/01 T.Ono add 2020監視改善
    Public gstrMITOKBN As String
    Public gstrTKIGCD As String
    Public gstrTSADCD As String
    Public gstrGENIN_KIJI As String
    Public gstrSDCD As String
    Public gstrSIJIYMD As String
    Public gstrSIJITIME As String
    Public gstrSIJI_BIKO1 As String
    Public gstrSIJI_BIKO2 As String
    Public gstrSTD_JASCD As String
    Public gstrSTD_JANA As String
    Public gstrSTD_JASNA As String
    Public gstrREN_CODE As String
    Public gstrREN_NA As String
    Public gstrREN_TEL_1 As String
    Public gstrREN_TEL_2 As String
    Public gstrREN_TEL_3 As String          ' 2013/05/27 T.Ono add
    Public gstrREN_FAX As String            'ＦＡＸ番号１
    Public gstrREN_BIKO As String
    Public gstrREN_EDT_DATE As String
    Public gstrREN_TIME As String
    Public gstrREN_1_CODE As String
    Public gstrREN_1_NA As String
    Public gstrREN_1_TEL1 As String
    Public gstrREN_1_TEL2 As String
    Public gstrREN_1_TEL3 As String         ' 2013/05/27 T.Ono add
    Public gstrREN_1_FAX As String          'ＦＡＸ番号２
    Public gstrREN_1_BIKO As String
    Public gstrREN_1_EDT_DATE As String
    Public gstrREN_1_TIME As String
    Public gstrREN_2_CODE As String
    Public gstrREN_2_NA As String
    Public gstrREN_2_TEL1 As String
    Public gstrREN_2_TEL2 As String
    Public gstrREN_2_TEL3 As String         ' 2013/05/27 T.Ono add
    Public gstrREN_2_FAX As String          'ＦＡＸ番号３
    Public gstrREN_2_BIKO As String
    Public gstrREN_2_EDT_DATE As String
    Public gstrREN_2_TIME As String
    Public gstrREN_3_CODE As String
    Public gstrREN_3_NA As String
    Public gstrREN_3_TEL1 As String
    Public gstrREN_3_TEL2 As String
    Public gstrREN_3_TEL3 As String         ' 2013/05/27 T.Ono add
    Public gstrREN_3_FAX As String          'ＦＡＸ番号４
    Public gstrREN_3_BIKO As String
    Public gstrREN_3_EDT_DATE As String
    Public gstrREN_3_TIME As String

    '2008/10/31 T.Watabe add
    Public gstrREN_4_CODE As String          '５
    Public gstrREN_4_NA As String
    Public gstrREN_4_TEL1 As String
    Public gstrREN_4_TEL2 As String
    Public gstrREN_4_TEL3 As String         ' 2013/05/27 T.Ono add
    Public gstrREN_4_FAX As String
    Public gstrREN_4_BIKO As String
    Public gstrREN_5_CODE As String          '６
    Public gstrREN_5_NA As String
    Public gstrREN_5_TEL1 As String
    Public gstrREN_5_TEL2 As String
    Public gstrREN_5_TEL3 As String         ' 2013/05/27 T.Ono add
    Public gstrREN_5_FAX As String
    Public gstrREN_5_BIKO As String
    Public gstrREN_6_CODE As String          '７
    Public gstrREN_6_NA As String
    Public gstrREN_6_TEL1 As String
    Public gstrREN_6_TEL2 As String
    Public gstrREN_6_TEL3 As String         ' 2013/05/27 T.Ono add
    Public gstrREN_6_FAX As String
    Public gstrREN_6_BIKO As String
    Public gstrREN_7_CODE As String          '８
    Public gstrREN_7_NA As String
    Public gstrREN_7_TEL1 As String
    Public gstrREN_7_TEL2 As String
    Public gstrREN_7_TEL3 As String         ' 2013/05/27 T.Ono add
    Public gstrREN_7_FAX As String
    Public gstrREN_7_BIKO As String
    Public gstrREN_8_CODE As String          '９
    Public gstrREN_8_NA As String
    Public gstrREN_8_TEL1 As String
    Public gstrREN_8_TEL2 As String
    Public gstrREN_8_TEL3 As String         ' 2013/05/27 T.Ono add
    Public gstrREN_8_FAX As String
    Public gstrREN_8_BIKO As String
    Public gstrREN_9_CODE As String          '１０
    Public gstrREN_9_NA As String
    Public gstrREN_9_TEL1 As String
    Public gstrREN_9_TEL2 As String
    Public gstrREN_9_TEL3 As String         ' 2013/05/27 T.Ono add
    Public gstrREN_9_FAX As String
    Public gstrREN_9_BIKO As String

    ' 2010/05/10 T.Watabe add
    Public gstrREN_10_CODE As String
    Public gstrREN_10_NA As String
    Public gstrREN_10_TEL1 As String
    Public gstrREN_10_TEL2 As String
    Public gstrREN_10_TEL3 As String         ' 2013/05/27 T.Ono add
    Public gstrREN_10_FAX As String
    Public gstrREN_10_BIKO As String
    Public gstrREN_11_CODE As String
    Public gstrREN_11_NA As String
    Public gstrREN_11_TEL1 As String
    Public gstrREN_11_TEL2 As String
    Public gstrREN_11_TEL3 As String         ' 2013/05/27 T.Ono add
    Public gstrREN_11_FAX As String
    Public gstrREN_11_BIKO As String
    Public gstrREN_12_CODE As String
    Public gstrREN_12_NA As String
    Public gstrREN_12_TEL1 As String
    Public gstrREN_12_TEL2 As String
    Public gstrREN_12_TEL3 As String         ' 2013/05/27 T.Ono add
    Public gstrREN_12_FAX As String
    Public gstrREN_12_BIKO As String
    Public gstrREN_13_CODE As String
    Public gstrREN_13_NA As String
    Public gstrREN_13_TEL1 As String
    Public gstrREN_13_TEL2 As String
    Public gstrREN_13_TEL3 As String         ' 2013/05/27 T.Ono add
    Public gstrREN_13_FAX As String
    Public gstrREN_13_BIKO As String
    Public gstrREN_14_CODE As String
    Public gstrREN_14_NA As String
    Public gstrREN_14_TEL1 As String
    Public gstrREN_14_TEL2 As String
    Public gstrREN_14_TEL3 As String         ' 2013/05/27 T.Ono add
    Public gstrREN_14_FAX As String
    Public gstrREN_14_BIKO As String
    Public gstrREN_15_CODE As String
    Public gstrREN_15_NA As String
    Public gstrREN_15_TEL1 As String
    Public gstrREN_15_TEL2 As String
    Public gstrREN_15_TEL3 As String         ' 2013/05/27 T.Ono add
    Public gstrREN_15_FAX As String
    Public gstrREN_15_BIKO As String
    Public gstrREN_16_CODE As String
    Public gstrREN_16_NA As String
    Public gstrREN_16_TEL1 As String
    Public gstrREN_16_TEL2 As String
    Public gstrREN_16_TEL3 As String         ' 2013/05/27 T.Ono add
    Public gstrREN_16_FAX As String
    Public gstrREN_16_BIKO As String
    Public gstrREN_17_CODE As String
    Public gstrREN_17_NA As String
    Public gstrREN_17_TEL1 As String
    Public gstrREN_17_TEL2 As String
    Public gstrREN_17_TEL3 As String         ' 2013/05/27 T.Ono add
    Public gstrREN_17_FAX As String
    Public gstrREN_17_BIKO As String
    Public gstrREN_18_CODE As String
    Public gstrREN_18_NA As String
    Public gstrREN_18_TEL1 As String
    Public gstrREN_18_TEL2 As String
    Public gstrREN_18_TEL3 As String         ' 2013/05/27 T.Ono add
    Public gstrREN_18_FAX As String
    Public gstrREN_18_BIKO As String
    Public gstrREN_19_CODE As String
    Public gstrREN_19_NA As String
    Public gstrREN_19_TEL1 As String
    Public gstrREN_19_TEL2 As String
    Public gstrREN_19_TEL3 As String         ' 2013/05/27 T.Ono add
    Public gstrREN_19_FAX As String
    Public gstrREN_19_BIKO As String
    Public gstrREN_20_CODE As String
    Public gstrREN_20_NA As String
    Public gstrREN_20_TEL1 As String
    Public gstrREN_20_TEL2 As String
    Public gstrREN_20_TEL3 As String         ' 2013/05/27 T.Ono add
    Public gstrREN_20_FAX As String
    Public gstrREN_20_BIKO As String
    Public gstrREN_21_CODE As String
    Public gstrREN_21_NA As String
    Public gstrREN_21_TEL1 As String
    Public gstrREN_21_TEL2 As String
    Public gstrREN_21_TEL3 As String         ' 2013/05/27 T.Ono add
    Public gstrREN_21_FAX As String
    Public gstrREN_21_BIKO As String
    Public gstrREN_22_CODE As String
    Public gstrREN_22_NA As String
    Public gstrREN_22_TEL1 As String
    Public gstrREN_22_TEL2 As String
    Public gstrREN_22_TEL3 As String         ' 2013/05/27 T.Ono add
    Public gstrREN_22_FAX As String
    Public gstrREN_22_BIKO As String
    Public gstrREN_23_CODE As String
    Public gstrREN_23_NA As String
    Public gstrREN_23_TEL1 As String
    Public gstrREN_23_TEL2 As String
    Public gstrREN_23_TEL3 As String         ' 2013/05/27 T.Ono add
    Public gstrREN_23_FAX As String
    Public gstrREN_23_BIKO As String
    Public gstrREN_24_CODE As String
    Public gstrREN_24_NA As String
    Public gstrREN_24_TEL1 As String
    Public gstrREN_24_TEL2 As String
    Public gstrREN_24_TEL3 As String         ' 2013/05/27 T.Ono add
    Public gstrREN_24_FAX As String
    Public gstrREN_24_BIKO As String
    Public gstrREN_25_CODE As String
    Public gstrREN_25_NA As String
    Public gstrREN_25_TEL1 As String
    Public gstrREN_25_TEL2 As String
    Public gstrREN_25_TEL3 As String         ' 2013/05/27 T.Ono add
    Public gstrREN_25_FAX As String
    Public gstrREN_25_BIKO As String
    Public gstrREN_26_CODE As String
    Public gstrREN_26_NA As String
    Public gstrREN_26_TEL1 As String
    Public gstrREN_26_TEL2 As String
    Public gstrREN_26_TEL3 As String         ' 2013/05/27 T.Ono add
    Public gstrREN_26_FAX As String
    Public gstrREN_26_BIKO As String
    Public gstrREN_27_CODE As String
    Public gstrREN_27_NA As String
    Public gstrREN_27_TEL1 As String
    Public gstrREN_27_TEL2 As String
    Public gstrREN_27_TEL3 As String         ' 2013/05/27 T.Ono add
    Public gstrREN_27_FAX As String
    Public gstrREN_27_BIKO As String
    Public gstrREN_28_CODE As String
    Public gstrREN_28_NA As String
    Public gstrREN_28_TEL1 As String
    Public gstrREN_28_TEL2 As String
    Public gstrREN_28_TEL3 As String         ' 2013/05/27 T.Ono add
    Public gstrREN_28_FAX As String
    Public gstrREN_28_BIKO As String
    Public gstrREN_29_CODE As String
    Public gstrREN_29_NA As String
    Public gstrREN_29_TEL1 As String
    Public gstrREN_29_TEL2 As String
    Public gstrREN_29_TEL3 As String         ' 2013/05/27 T.Ono add
    Public gstrREN_29_FAX As String
    Public gstrREN_29_BIKO As String
    '2012/03/26 START W.GANEKO
    Public gstrREN_MAIL As String
    Public gstrREN_1_MAIL As String
    Public gstrREN_2_MAIL As String
    Public gstrREN_3_MAIL As String
    Public gstrREN_4_MAIL As String
    Public gstrREN_5_MAIL As String
    Public gstrREN_6_MAIL As String
    Public gstrREN_7_MAIL As String
    Public gstrREN_8_MAIL As String
    Public gstrREN_9_MAIL As String
    Public gstrREN_10_MAIL As String
    Public gstrREN_11_MAIL As String
    Public gstrREN_12_MAIL As String
    Public gstrREN_13_MAIL As String
    Public gstrREN_14_MAIL As String
    Public gstrREN_15_MAIL As String
    Public gstrREN_16_MAIL As String
    Public gstrREN_17_MAIL As String
    Public gstrREN_18_MAIL As String
    Public gstrREN_19_MAIL As String
    Public gstrREN_20_MAIL As String
    Public gstrREN_21_MAIL As String
    Public gstrREN_22_MAIL As String
    Public gstrREN_23_MAIL As String
    Public gstrREN_24_MAIL As String
    Public gstrREN_25_MAIL As String
    Public gstrREN_26_MAIL As String
    Public gstrREN_27_MAIL As String
    Public gstrREN_28_MAIL As String
    Public gstrREN_29_MAIL As String
    Public gstrREN_MAILPASS As String
    Public gstrREN_1_MAILPASS As String
    Public gstrREN_2_MAILPASS As String
    Public gstrREN_3_MAILPASS As String
    Public gstrREN_4_MAILPASS As String
    Public gstrREN_5_MAILPASS As String
    Public gstrREN_6_MAILPASS As String
    Public gstrREN_7_MAILPASS As String
    Public gstrREN_8_MAILPASS As String
    Public gstrREN_9_MAILPASS As String
    Public gstrREN_10_MAILPASS As String
    Public gstrREN_11_MAILPASS As String
    Public gstrREN_12_MAILPASS As String
    Public gstrREN_13_MAILPASS As String
    Public gstrREN_14_MAILPASS As String
    Public gstrREN_15_MAILPASS As String
    Public gstrREN_16_MAILPASS As String
    Public gstrREN_17_MAILPASS As String
    Public gstrREN_18_MAILPASS As String
    Public gstrREN_19_MAILPASS As String
    Public gstrREN_20_MAILPASS As String
    Public gstrREN_21_MAILPASS As String
    Public gstrREN_22_MAILPASS As String
    Public gstrREN_23_MAILPASS As String
    Public gstrREN_24_MAILPASS As String
    Public gstrREN_25_MAILPASS As String
    Public gstrREN_26_MAILPASS As String
    Public gstrREN_27_MAILPASS As String
    Public gstrREN_28_MAILPASS As String
    Public gstrREN_29_MAILPASS As String
    '2012/03/26 END W.GANEKO

    Public gstrREN_DENWABIKO As String
    Public gstrREN_FAX_REN As String        'メモ欄
    Public gstrREN_FAXTITLE As String       'ＦＡＸタイトル
    Public gstrFAX_TITLE_CD As String       'ＦＡＸタイトルコード   '2005/09/09 ADD Falcon
    Public gstrSTD_CD As String
    Public gstrSTD As String
    Public gstrSTD_KYOTEN_CD As String
    Public gstrSTD_KYOTEN As String
    Public gstrSTD_TEL As String
    Public gstrADD_DATE As String
    Public gstrEDT_DATE As String
    Public gstrTIME As String
    '//対応DB追加項目---------------
    Public gstrBOMB_TYPE As String
    Public gstrGAS_STOP As String
    Public gstrGAS_DELE As String
    Public gstrGAS_RESTART As String
    '2016/02/02 w.ganeko 2015改善開発 №1-3 start
    Public gstrKANSHI_BIKO As String
    Public gstrRENTEL2 As String
    Public gstrRENTEL2_BIKO As String
    Public gstrRENTEL2_UPD_DATE As String
    Public gstrRENTEL3 As String
    Public gstrRENTEL3_BIKO As String
    Public gstrRENTEL3_UPD_DATE As String
    Public gstrTelJVG As String
    Public gstrKBNMODE As String
    '2016/02/02 w.ganeko 2015改善開発 №1-3 end
    '2016/12/12 H.Mori 2016改善開発 No5-1 START
    Public gstrTELAB As String
    Public gstrDAI3RENDORENTEL As String
    '2016/12/12 H.Mori 2016改善開発 No5-1 END
    '2016/12/14 H.Mori add 2016監視改善 No6-3 START
    Public gstrFAXSPOTKBN As String
    '2016/12/14 H.Mori add 2016監視改善 No6-3 END
    '2016/12/22 H.Mori add 2016監視改善 No4-6 START
    Public gstrDAIHYO_NAME As String
    Public gstrHOKBN As String
    Public gstrYOTOKBN As String
    Public gstrHANBCD As String
    Public gstrKINRENCD As String
    Public gstrJMNAME As String   ' 2023/01/04 ADD Y.ARAKAKI 2022更改No⑥ _帳票JMコード表示追加対応 
    '2016/12/22 H.Mori add 2016監視改善 No4-6 END
    '2017/10/16 H.Mori add 2017改善開発 No4-1 START
    Public gstrSHUGOU As String
    '2017/10/16 H.Mori add 2017改善開発 No4-1 END

    '//-----------------------------
    '電話発信ログ登録用
    Public gstrDialKbns As String
    Public gstrDialNumbers As String
    Public gstrDialAites As String
    Public gstrDialResult As String
    Public gstrDialDates As String
    Public gstrDialTimes As String
    Public gstrDialStates As String
    Public gstrSDSKBN As String ' 2008/10/17 T.Watabe add
    Public gstrTUSIN As String ' 2008/10/24 T.Watabe add
    '本日工事状況------------------
    Public gstrKAITU_DAY As String '2013/08/23 T.Ono add 監視改善2013№1

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

        '2012/04/04 NEC ou Add Str
        '.NETの仕様変更により、ReadOnly属性をASPXでつけると、サーバ側で
        '値の参照ができなくなるため、VB側でAttributeでつける
        If MyBase.IsPostBack = False Then
            '------【受信情報】------
            txtNCUHATYMD.Attributes.Add("ReadOnly", "true")
            txtNCUHATTIME.Attributes.Add("ReadOnly", "true")
            txtHATYMD.Attributes.Add("ReadOnly", "true")
            txtHATTIME.Attributes.Add("ReadOnly", "true")
            txtUSER_FLG.Attributes.Add("ReadOnly", "true")
            txtKEIHOSU.Attributes.Add("ReadOnly", "true")
            txtRYURYO.Attributes.Add("ReadOnly", "true")
            txtMETASYU.Attributes.Add("ReadOnly", "true")
            txtKMSIN.Attributes.Add("ReadOnly", "true")
            txtKMNM1.Attributes.Add("ReadOnly", "true")
            txtKMNM2.Attributes.Add("ReadOnly", "true")
            txtKMNM3.Attributes.Add("ReadOnly", "true")
            txtKMNM4.Attributes.Add("ReadOnly", "true")
            txtKMNM5.Attributes.Add("ReadOnly", "true")
            txtKMNM6.Attributes.Add("ReadOnly", "true")
            txtClientCD.Attributes.Add("ReadOnly", "true")
            txtKENNM.Attributes.Add("ReadOnly", "true")
            txtACBNM.Attributes.Add("ReadOnly", "true")
            txtUSER_KIJI.Attributes.Add("ReadOnly", "true")
            txtHANGRP.Attributes.Add("ReadOnly", "true")
            txtKANSHI_BIKO.Attributes.Add("ReadOnly", "true")     '2016/02/02 w.ganeko add 2015改善開発 №1-3
            '------【お客様情報】------
            txtTUSIN.Attributes.Add("ReadOnly", "true")
            txtMAP_CD.Attributes.Add("ReadOnly", "true")
            txtBOMB_TYPE.Attributes.Add("ReadOnly", "true")
            txtHANBAI_KBN.Attributes.Add("ReadOnly", "true") '2015/11/20 H.Mori add 2015改善開発 No1
            txtKYOKTKBN.Attributes.Add("ReadOnly", "true") '2016/12/02 H.Mori add 2016改善開発 No4-3
            txtMET_KATA.Attributes.Add("ReadOnly", "true")
            txtMET_MAKER.Attributes.Add("ReadOnly", "true")
            txtBONB1_KKG.Attributes.Add("ReadOnly", "true")
            txtBONB1_HON.Attributes.Add("ReadOnly", "true")
            txtBONB1_RKG.Attributes.Add("ReadOnly", "true")
            txtBONB2_KKG.Attributes.Add("ReadOnly", "true")
            txtBONB2_HON.Attributes.Add("ReadOnly", "true")
            txtBONB2_RKG.Attributes.Add("ReadOnly", "true")
            txtBONB3_KKG.Attributes.Add("ReadOnly", "true")
            txtBONB3_HON.Attributes.Add("ReadOnly", "true")
            txtBONB3_RKG.Attributes.Add("ReadOnly", "true")
            txtBONB4_KKG.Attributes.Add("ReadOnly", "true")
            txtBONB4_HON.Attributes.Add("ReadOnly", "true")
            txtBONB4_RKG.Attributes.Add("ReadOnly", "true")
            txtG_ZAIKO.Attributes.Add("ReadOnly", "true")
            txtICHI_SIYO.Attributes.Add("ReadOnly", "true")
            txtYOSOKU_ICHI_SIYO.Attributes.Add("ReadOnly", "true")
            txtZENKAI_KENSIN.Attributes.Add("ReadOnly", "true")
            txtZENKAI_KEN_S.Attributes.Add("ReadOnly", "true")
            txtZENKAI_KEN_SIYO.Attributes.Add("ReadOnly", "true")
            txtKONKAI_KENSIN.Attributes.Add("ReadOnly", "true")
            txtKONKAI_KEN_S.Attributes.Add("ReadOnly", "true")
            txtKONKAI_KEN_SIYO.Attributes.Add("ReadOnly", "true")
            txtZENKAI_HASEI.Attributes.Add("ReadOnly", "true")
            txtZENKAI_HAS_S.Attributes.Add("ReadOnly", "true")
            txtKONKAI_HASEI.Attributes.Add("ReadOnly", "true")
            txtKONKAI_HAS_S.Attributes.Add("ReadOnly", "true")
            txtZENKAI_HAISO.Attributes.Add("ReadOnly", "true")
            txtZENKAI_HAI_S.Attributes.Add("ReadOnly", "true")
            txtKONKAI_HAISO.Attributes.Add("ReadOnly", "true")
            txtKONKAI_HAI_S.Attributes.Add("ReadOnly", "true")
            txtJIKAI_HAISO.Attributes.Add("ReadOnly", "true")
            txtGAS1_HINMEI.Attributes.Add("ReadOnly", "true")
            txtGAS1_DAISU.Attributes.Add("ReadOnly", "true")
            txtGAS1_SEIFL.Attributes.Add("ReadOnly", "true")
            txtGAS2_HINMEI.Attributes.Add("ReadOnly", "true")
            txtGAS2_DAISU.Attributes.Add("ReadOnly", "true")
            txtGAS2_SEIFL.Attributes.Add("ReadOnly", "true")
            txtGAS3_HINMEI.Attributes.Add("ReadOnly", "true")
            txtGAS3_DAISU.Attributes.Add("ReadOnly", "true")
            txtGAS3_SEIFL.Attributes.Add("ReadOnly", "true")
            txtGAS4_HINMEI.Attributes.Add("ReadOnly", "true")
            txtGAS4_DAISU.Attributes.Add("ReadOnly", "true")
            txtGAS4_SEIFL.Attributes.Add("ReadOnly", "true")
            txtGAS5_HINMEI.Attributes.Add("ReadOnly", "true")
            txtGAS5_DAISU.Attributes.Add("ReadOnly", "true")
            txtGAS5_SEIFL.Attributes.Add("ReadOnly", "true")
            txtGAS_START.Attributes.Add("ReadOnly", "true")
            txtGAS_DELE.Attributes.Add("ReadOnly", "true")
            txtGAS_RESTART.Attributes.Add("ReadOnly", "true")
            txtKAITU_DAY.Attributes.Add("ReadOnly", "true")         ' 2013/08/19 T.Ono add 監視改善2013№1
            '------【対応情報】------
            txtHATKBN.Attributes.Add("ReadOnly", "true")
            txtTKTANCD.Attributes.Add("ReadOnly", "true")
            txtSYONO.Attributes.Add("ReadOnly", "true")
            txtSTD.Attributes.Add("ReadOnly", "true")
            txtSTD_KYOTEN.Attributes.Add("ReadOnly", "true")
            txtSTD_TEL.Attributes.Add("ReadOnly", "true")
            '------【データ修正チェックボックス】------             ' 2016/12/05 H.Mori add 監視改善2016 No4-8
            txtJUYOKA.Attributes.Add("ReadOnly", "true")
            txtRENTEL.Attributes.Add("ReadOnly", "true")
            txtJUSYONM.Attributes.Add("ReadOnly", "true")
            txtJUSYOKN.Attributes.Add("ReadOnly", "true")
            txtJUTEL1.Attributes.Add("ReadOnly", "true")
            txtJUTEL2.Attributes.Add("ReadOnly", "true")
            txtADDR.Attributes.Add("ReadOnly", "true")
            '2019/11/01 w.ganeko 2019監視改善 No6-12 start
            rdoMsg1.Attributes.Add("Disabled", "true")
            rdoMsg2.Attributes.Add("Disabled", "true")
            rdoMsg3.Attributes.Add("Disabled", "true")
            rdoMsg4.Attributes.Add("Disabled", "true")
            rdoMsg5.Attributes.Add("Disabled", "true")
            rdoMsg6.Attributes.Add("Disabled", "true")
            '2019/11/01 w.ganeko 2019監視改善 No6-12 end
        End If
        '2012/04/04 NEC ou Add End

        'putlog("Page_Load 01")

        '//------------------------------------------
        '//　HTTPヘッダを送信
        HttpHeaderC.mNoCache(Response)

        '//------------------------------------------
        '//　認証クラスのインスタンス生成
        AuthC = New CAuthenticate(Request, Response)
        mlog("[KETAIJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load start")

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
        '入力補助ポップアップを出力する
        If hdnKensaku.Value = "COPOPUPG00" Then
            mlog("[KETAIJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load COPOPUPG00 Server.Transfer=COPOPUPG00.aspx")
            Server.Transfer("../../../Popup/COPOPUPG00.aspx")
        End If
        '対応履歴照会画面を出力する(ポップアップ)
        If hdnKensaku.Value = "KETAIJRG00" Then
            mlog("[KETAIJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load KETAIJRG00 Server.Transfer=KETAIJRG00.aspx")
            Server.Transfer("KETAIJRG00.aspx")
        End If
        '連絡先選択を出力
        If hdnKensaku.Value = "KETAIJTG00" Then
            mlog("[KETAIJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load KETAIJTG00 Server.Transfer=KETAIJTG00.aspx")
            Server.Transfer("KETAIJTG00.aspx")
        End If
        'クライアントに紐づく県名を取得する
        If hdnKensaku.Value = "KETAIJKG00_KEN" Then
            mlog("[KETAIJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load KETAIJKG00_KEN Server.Transfer=KETAIJKG00.aspx")
            Server.Transfer("KETAIJKG00.aspx")
        End If
        'ＪＡに紐づく出動会社もしくは連絡担当者を取得する
        If hdnKensaku.Value = "KETAIJKG00_REN" Then
            mlog("[KETAIJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load KETAIJKG00_REN Server.Transfer=KETAIJKG00.aspx")
            Server.Transfer("KETAIJKG00.aspx")
        End If
        'ＪＡに紐づく出動会社、連絡担当者、販売事業者を取得する 2014/12/19 T.Ono add 2014改善開発 No2
        If hdnKensaku.Value = "KETAIJKG00_REN_AND_HANGRP" Then
            mlog("[KETAIJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load KETAIJKG00_REN_AND_HANGRP Server.Transfer=KETAIJKG00.aspx")
            Server.Transfer("KETAIJKG00.aspx")
        End If
        '対応完了日・時刻を出力する
        If hdnKensaku.Value = "KETAIJKG00_TKN" Then
            mlog("[KETAIJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load KETAIJKG00_TKN Server.Transfer=KETAIJKG00.aspx")
            Server.Transfer("KETAIJKG00.aspx")
        End If
        '出動指示日・時刻を出力する
        If hdnKensaku.Value = "KETAIJKG00_SSJ" Then
            mlog("[KETAIJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load KETAIJKG00_SSJ Server.Transfer=KETAIJKG00.aspx")
            Server.Transfer("KETAIJKG00.aspx")
        End If
        '2017/10/18 H.Mori add 2017改善開発 No4-3 START
        If hdnKensaku.Value = "KETAIJKG00_ROC_btnTelHas1" Then
            Server.Transfer("KETAIJKG00.aspx")
        End If
        If hdnKensaku.Value = "KETAIJKG00_ROC_btnTelHas2" Then
            Server.Transfer("KETAIJKG00.aspx")
        End If
        If hdnKensaku.Value = "KETAIJKG00_ROC_btnRenraku" Then
            Server.Transfer("KETAIJKG00.aspx")
        End If
        If hdnKensaku.Value = "KETAIJKG00_ROC_btnTKTANCD" Then
            Server.Transfer("KETAIJKG00.aspx")
        End If
        '2017/10/18 H.Mori add 2017改善開発 No4-3 END
        'コピー補助画面を出力する(ポップアップ) 2013/08/19 T.Ono add 監視改善2013№1
        If hdnKensaku.Value = "KETAIJUG00" Then
            mlog("[KETAIJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load KETAIJUG00 Server.Transfer=KETAIJUG00.aspx")
            Server.Transfer("KETAIJUG00.aspx")
        End If
        '2016/02/02 w.ganeko 2015改善開発 №1-3 START
        If hdnKensaku.Value = "KETAIJVG00" Then
            gstrRENTEL2 = hdnRENTEL2.Value
            gstrRENTEL2_BIKO = hdnRENTEL2_BIKO.Value
            gstrRENTEL2_UPD_DATE = hdnRENTEL2_UPD_DATE.Value
            gstrRENTEL3 = hdnRENTEL3.Value
            gstrRENTEL3_BIKO = hdnRENTEL3_BIKO.Value
            gstrRENTEL3_UPD_DATE = hdnRENTEL3_UPD_DATE.Value
            gstrKURACD = txtClientCD.Text
            gstrACBCD = hdnJASCD.Value
            gstrUSER_CD = txtJUYOKA.Text
            gstrTelJVG = hdnTelJVG.Value
            gstrTELAB = hdnTELAB.Value '2016/12/12 H.Mori add 2016改善開発 No5-1
            gstrDAI3RENDORENTEL = hdnDAI3RENDORENTEL.Value '2016/12/12 H.Mori add 2016改善開発 No5-1
            If hdnBackUrl.Value = "MSKOSJAG00" Then
                '利用者検索画面からの画面遷移の場合
                If hdnMOVE_MODE.Value = "1" Then
                    'Dim strRes(6) As String  '2016/12/12 H.Mori add 2016改善開発 No5-1
                    Dim strRes(9) As String
                    strRes = fncGetSHAMAS()
                    gstrRENTEL2 = strRes(0)
                    gstrRENTEL2_BIKO = strRes(1)
                    gstrRENTEL2_UPD_DATE = strRes(2)
                    gstrRENTEL3 = strRes(3)
                    gstrRENTEL3_BIKO = strRes(4)
                    gstrRENTEL3_UPD_DATE = strRes(5)
                    gstrTELAB = strRes(6) & strRes(7) '2016/12/12 H.Mori add 2016改善開発 No5-1
                    gstrDAI3RENDORENTEL = strRes(8)     '2016/12/12 H.Mori add 2016改善開発 No5-1
                End If
            End If
            If hdnBackUrl.Value = "KEKEKJAG00" Then
                gstrKBNMODE = "2"               '修正
            Else
                gstrKBNMODE = "1"               '登録
            End If
            mlog("[KETAIJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load KETAIJVG00 Server.Transfer=KETAIJVG00.aspx")
            Server.Transfer("KETAIJVG00.aspx")
        End If
        '2016/02/02 w.ganeko 2015改善開発 №1-3 end

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
        strScript.Append(cscript1.mWriteScript(
                MyBase.MapPath("../../../KE/KETAIJAG/KETAIJAG00/") & "KETAIJAG00.js"))
        '<フォーカス関連関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncFo.js"))
        '<日付関連関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncDate.js"))
        '<電話番号チェック関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncTel.js"))
        '<入力チェック関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncChk.js"))
        '<時間関連関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncTime.js"))
        '<バイト数関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncGetByte.js"))
        '<全角チェック関数>
        '--- ↓2005/05/19 DEL Falcon↓ ---
        'strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncZenkakuChk.js"))
        '--- ↑2005/05/19 DEL Falcon↑ ---
        '<数字チェック関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncNumChk.js"))
        strScript.Append("</Script>")
        '//------------------------------------------
        '//　Css格納
        strScript.Append("<Style media='print'>")
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "CssPrint.css"))
        strScript.Append("</Style>")
        strScript.Append("<Style>")
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "CssSmall.css"))
        strScript.Append("</Style>")
        '//------------------------------------------

        '2010/10/27 T.Watabe add
        Dim strDivFaxKbnDisp As String = "[" & AuthC.pGROUPNAME & "][" & InStr(AuthC.pGROUPNAME, "0監視業務単独") & "]"
        strScript.Append("<!-- 2010/10/27 ADの監視ｾﾝﾀｰ情報 " & strDivFaxKbnDisp & " -->" & vbCrLf)
        If InStr(AuthC.pGROUPNAME, "0監視業務単独") > 0 Then ' 沖縄や岐阜の画面には表示させない
            'strScript.Append("<script language='javascript'>document.getElementById('divFaxKbnDisp1').style.display='none';document.getElementById('divFaxKbnDisp2').style.display='none';alert('test 2010/10/27 watabe');</script>" & vbCrLf)
            hdnOTHER_KANSI_CENTER.Value = "1"
        Else
            hdnOTHER_KANSI_CENTER.Value = "0"
        End If
        '//　Script書込み
        lblScript.Text = strScript.ToString

        '//------------------------------------------
        '//  監視センターコードフラグ
        hdnKANSFLG.Value = "0"

        '//------------------------------------------------------------------------------

        If MyBase.IsPostBack = False Then
            '//--------------------------------------
            '//初めて開いた時だけ実行される

            'ＣＴＩ未登録フラグ(関係のない遷移の場合はセットしない)
            hdnMOVE_MITOKBN.Value = ""

            '--- ↓2005/05/19 ADD Falcon↓ ---
            'ＣＴＩの時に値をセット（処理的にCTIかどうかを判断）
            hdnCtiFlg.Value = ""
            '--- ↑2005/05/19 ADD Falcon↑ ---

            '遷移してきた画面を保持し遷移元画面別の初期表示を行う------------------
            '[終了ボタン](押下時に戻る画面の制御をする(VB - Transfer))
            Dim strMyAspx As String
            strMyAspx = Request.Form("hdnMyAspx")

            Dim strTitleVal As String       'タイトル名をセット
            Dim strButtonVal As String      'ボタン値をセット
            btnTelHas2.Disabled = False
            If strMyAspx = "MSKOSJAG00" Then
                '利用者検索画面からの画面遷移の場合
                hdnBackUrl.Value = "MSKOSJAG00"
                strTitleVal = "対応入力"
                strButtonVal = "登録"
            ElseIf strMyAspx = "KEKEKJAG00" Then
                '対応入力変更照会画面からの画面遷移の場合
                hdnBackUrl.Value = "KEKEKJAG00"
                strTitleVal = "対応入力変更"
                strButtonVal = "更新"
            ElseIf strMyAspx = "KEJUKJAG00" Then
                '警報受信パネルからの画面遷移の場合
                hdnBackUrl.Value = "KEJUKJAG00"
                strTitleVal = "対応入力"
                strButtonVal = "登録"
            Else
                If Request.Path.LastIndexOf("SYCTIJAG00") >= 0 Then
                    'ＣＴＩからの画面遷移の場合
                    hdnBackUrl.Value = "MSKOSJAG00"
                    strTitleVal = "対応入力"
                    strButtonVal = "登録"
                Else
                    'その他からの画面遷移の場合
                    hdnBackUrl.Value = ""
                    strTitleVal = ""
                    strButtonVal = ""
                End If
            End If
            '上記セットしたタイトル・ボタン値をセットする
            lblTitle.Text = strTitleVal
            btnUpdate.Value = strButtonVal

            '電話発信関連----------------------------------------------------------
            hdnTELEXEPATH.Value = ConfigurationSettings.AppSettings("TELEXEPATH")
            hdnTELEXENAME.Value = ConfigurationSettings.AppSettings("TELEXENAME")
            hdnTELEXERESULT.Value = ConfigurationSettings.AppSettings("TELEXERESULT")
            hdnTELWAITFLG.Value = ConfigurationSettings.AppSettings("TELWAITFLG")
            hdnTELPLSTORN.Value = ConfigurationSettings.AppSettings("TELPLSTORN")
            hdnTELHEAD.Value = ConfigurationSettings.AppSettings("TELHEAD")
            hdnATCOMMAND.Value = ConfigurationSettings.AppSettings("ATCOMMANDINI")

            'ＦＡＸ発信関連--------------------------------------------------------
            hdnFAXEXEPATH.Value = ConfigurationSettings.AppSettings("FAXEXEPATH")
            hdnFAXEXENAME.Value = ConfigurationSettings.AppSettings("FAXEXENAME")
            hdnFAXHEAD.Value = ConfigurationSettings.AppSettings("FAXHEAD")
            '2012/04/04 NEC ou Upd Str
            'hdnFAXSESSION.Value = Request.Cookies.Get("ASP.NET_SessionId").Value
            hdnFAXSESSION.Value = Me.Session.SessionID
            '2012/04/04 NEC ou Upd End

            '遷移元画面の情報を保持する--------------------------------------------
            Dim strRec As String

            If Request.Path.LastIndexOf("SYCTIJAG00") >= 0 Then
                'ＣＴＩからの遷移の場合

                '監視センターコードフラグ
                hdnKANSFLG.Value = "1"

                '--- ↓2005/05/19 ADD Falcon↓ ---
                'ＣＴＩの時に値をセット（処理的にCTIかどうかを判断）
                hdnCtiFlg.Value = "1"
                '--- ↑2005/05/19 ADD Falcon↑ ---

                Dim SYCTIJAG00_C As New SYCTIJAG00.SYCTIJAG00
                SYCTIJAG00_C = CType(Context.Handler, SYCTIJAG00.SYCTIJAG00)

                '一覧のリンクからの遷移時
                hdnKEY_CLI_CD.Value = SYCTIJAG00_C.gstrCLI_CD
                hdnKEY_JA_CD.Value = ""                             '2013/12/09 T.Ono add 監視改善2013
                hdnKEY_HAN_GRP.Value = ""                           '2014/12/03 H.Hosoda add 監視改善2014 No.6
                hdnKEY_KINREN_GRP.Value = ""                        '2016/11/22 H.Mori add 監視改善2016 No2-1
                hdnKEY_HAN_CD.Value = SYCTIJAG00_C.gstrHAN_CD
                hdnKEY_USER_CD.Value = SYCTIJAG00_C.gstrUSER_CD
                '制御値(MOVE)を保持する
                hdnMOVE_NAME.Value = ""
                hdnMOVE_KANAD.Value = ""
                hdnMOVE_ADDR.Value = ""             '2013/12/09 T.Ono add 監視改善2013
                hdnMOVE_CLI_CD.Value = ""
                hdnMOVE_CLI_CD_NAME.Value = ""
                hdnMOVE_JA_CD.Value = ""            '2013/12/09 T.Ono add 監視改善2013
                hdnMOVE_JA_CD_NAME.Value = ""       '2013/12/09 T.Ono add 監視改善2013
                hdnMOVE_JA_CD_CLI.Value = ""        '2019/11/01 T.Ono add 監視改善2019
                hdnMOVE_HAN_GRP.Value = ""          '2014/12/03 H.Hosoda add 監視改善2014 No.6
                hdnMOVE_HAN_GRP_NAME.Value = ""     '2014/12/03 H.Hosoda add 監視改善2014 No.6
                hdnMOVE_KINREN_GRP.Value = ""          '2016/11/22 H.Mori add 監視改善2016 No2-1
                hdnMOVE_KINREN_GRP_NAME.Value = ""     '2016/11/22 H.Mori add 監視改善2016 No2-1
                hdnMOVE_HAN_CD.Value = ""
                hdnMOVE_HAN_CD_NAME.Value = ""
                hdnMOVE_HAN_CD_CLI.Value = ""          '2019/11/01 T.Ono add 監視改善2019
                hdnMOVE_HAN_CD_TO.Value = ""           '2016/11/24 H.Mori add 監視改善2016 No2-2
                hdnMOVE_HAN_CD_NAME_TO.Value = ""      '2016/11/24 H.Mori add 監視改善2016 No2-2
                hdnMOVE_HAN_CD_TO_CLI.Value = ""       '2019/11/01 T.Ono add 監視改善2019
                hdnMOVE_USER_CD.Value = ""
                hdnMOVE_KANSCD.Value = ""
                hdnMOVE_TEL.Value = SYCTIJAG00_C.gstrCTITELNO
                hdnMOVE_NCUTEL.Value = ""           '2014/12/03 H.Hosoda add 監視改善2014 No.6
                '2011.11.15 ADD H.Uema
                hdnMOVE_KMCD.Value = ""
                hdnMOVE_KMNM.Value = ""             '2013/12/10 T.Ono add 監視改善2013
                hdnScrollTop.Value = "0"            '2013/12/10 T.Ono add 監視改善2013
                hdnMOVE_USER_FLG0.Value = "1"       'お客様FLG　2014/01/10 T.Ono add 監視改善2013
                hdnMOVE_USER_FLG1.Value = "1"       'お客様FLG　2014/01/10 T.Ono add 監視改善2013
                hdnMOVE_USER_FLG2.Value = "1"       'お客様FLG　2014/01/10 T.Ono add 監視改善2013
                hdnMOVE_HANBAI_KBN1.Value = "1"     '販売区分   2015/12/15 H.Mori add 監視改善2015
                hdnMOVE_HANBAI_KBN2.Value = "1"     '販売区分   2015/12/15 H.Mori add 監視改善2015
                hdnMOVE_HANBAI_KBN3.Value = "1"     '販売区分   2015/12/15 H.Mori add 監視改善2015
                hdnMOVE_HANBAI_KBN4.Value = "1"     '販売区分   2015/12/15 H.Mori add 監視改善2015
                hdnMOVE_HANBAI_KBN5.Value = "1"     '販売区分   2015/12/15 H.Mori add 監視改善2015
                hdnMOVE_HANBAI_KBN6.Value = "1"     '販売区分   2015/12/15 H.Mori add 監視改善2015

                '画面の出力（コンボの場合は変数に格納）
                strRec = fncSetData_KOKYAKU()
                If strRec <> "OK" Then
                    Call fncError()
                    Exit Sub
                End If
            Else
                If strMyAspx = "MSKOSJAG00" Then
                    '利用者検索画面からの画面遷移の場合
                    If Convert.ToString(Request.Form("hdnTaiouClick")) = "1" Then
                        '対応入力ボタン押下での遷移時
                        'btnTelHas2.Disabled = True

                        'ＣＴＩ未登録フラグ(関係のない遷移の場合はセットしない)
                        hdnMOVE_MITOKBN.Value = Request.Form("hdnMOVE_MITOKBN")

                        '--- ↓2005/05/19 ADD Falcon↓ ---
                        'ＣＴＩの時に値をセット（処理的にCTIかどうかを判断）
                        hdnCtiFlg.Value = Request.Form("hdnMOVE_MITOKBN")
                        '--- ↑2005/05/19 ADD Falcon↑ ---

                        '--- ↓2005/04/20 ADD　Falcon↓ -----------------
                        '対応入力遷移モード
                        hdnMOVE_MODE.Value = Request.Form("hdnTaiouClick")
                        '--- ↑2005/04/20 ADD　Falcon↑ -----------------

                        '監視センターコードフラグ
                        hdnKANSFLG.Value = "0"

                        hdnHATKBN.Value = "1"
                        txtHATKBN.Text = "電話"
                        '電話連絡内容（初期値55:その他） 2016/12/20 H.Mori add 2016改善開発 No4-2
                        'strCBO_TELRCD = "55" '2019/11/01 w.ganeko 2019監視改善 No 6 del

                        Dim DateFncC As New CDateFnc
                        Dim TimeFncC As New CTimeFnc
                        Dim strSYSDATE As String = Now.ToString("yyyyMMdd")
                        Dim strSYSTIME As String = Now.ToString("HHmmss")
                        '発生日時 ' 2008/10/15 T.Watabe add
                        txtNCUHATYMD.Text = DateFncC.mGet(strSYSDATE)
                        txtNCUHATTIME.Text = TimeFncC.mGet(strSYSTIME, 0)
                        '受信日時
                        txtHATYMD.Text = DateFncC.mGet(strSYSDATE)
                        txtHATTIME.Text = TimeFncC.mGet(strSYSTIME, 0)
                        '対応開始日
                        hdnTAIO_ST_DATE.Value = strSYSDATE
                        hdnTAIO_ST_TIME.Value = strSYSTIME
                        '受信日
                        hdnJUYMD.Value = strSYSDATE
                        hdnJUTIME.Value = strSYSTIME
                        'スクロールバー位置の保持
                        hdnScrollTop.Value = "0"            '2013/12/10 T.Ono add 監視改善2013
                        'お客様FLG
                        hdnMOVE_USER_FLG0.Value = "1"       '2014/01/10 T.Ono add 監視改善2013
                        hdnMOVE_USER_FLG1.Value = "1"       '2014/01/10 T.Ono add 監視改善2013
                        hdnMOVE_USER_FLG2.Value = "1"       '2014/01/10 T.Ono add 監視改善2013
                        '販売区分
                        hdnMOVE_HANBAI_KBN1.Value = "1"     '2015/12/15 H.Mori add 監視改善2015
                        hdnMOVE_HANBAI_KBN2.Value = "1"     '2015/12/15 H.Mori add 監視改善2015
                        hdnMOVE_HANBAI_KBN3.Value = "1"     '2015/12/15 H.Mori add 監視改善2015
                        hdnMOVE_HANBAI_KBN4.Value = "1"     '2015/12/15 H.Mori add 監視改善2015
                        hdnMOVE_HANBAI_KBN5.Value = "1"     '2015/12/15 H.Mori add 監視改善2015
                        hdnMOVE_HANBAI_KBN6.Value = "1"     '2015/12/15 H.Mori add 監視改善2015

                        '2020/11/01 T.Ono add 2020監視改善
                        '監視センター担当者
                        Dim strTANInfo() As String
                        strTANInfo = fncGetTANInfo()

                        '監視センター担当者コード
                        If Convert.ToString(strTANInfo(0)) <> "" Then
                            hdnTKTANCD.Value = Convert.ToString(strTANInfo(0))
                            '監視センター担当者名
                            txtTKTANCD.Text = Convert.ToString(strTANInfo(0)) & "：" & Convert.ToString(strTANInfo(1))
                        End If

                    Else
                        '一覧のリンクからの遷移時

                        'ＣＴＩ未登録フラグ(関係のない遷移の場合はセットしない)
                        hdnMOVE_MITOKBN.Value = Request.Form("hdnMOVE_MITOKBN")

                        '--- ↓2005/05/19 ADD Falcon↓ ---
                        'ＣＴＩの時に値をセット（処理的にCTIかどうかを判断）
                        hdnCtiFlg.Value = Request.Form("hdnMOVE_MITOKBN")
                        '--- ↑2005/05/19 ADD Falcon↑ ---

                        '監視センターコードフラグ
                        hdnKANSFLG.Value = "1"

                        hdnKEY_CLI_CD.Value = Request.Form("hdnKEY_CLI_CD")
                        hdnKEY_JA_CD.Value = Request.Form("hdnKEY_JA_CD")                   '2013/12/09 T.Ono add 監視改善2013
                        hdnKEY_HAN_GRP.Value = Request.Form("hdnKEY_HAN_GRP")               '2014/12/03 H.Hosoda add 監視改善2014 No.6
                        hdnKEY_KINREN_GRP.Value = Request.Form("hdnKEY_KINREN_GRP")               '2016/11/22 H.Mori add 監視改善2016 No2-1
                        hdnKEY_HAN_CD.Value = Request.Form("hdnKEY_HAN_CD")
                        hdnKEY_USER_CD.Value = Request.Form("hdnKEY_USER_CD")
                        '制御値(MOVE)を保持する
                        hdnMOVE_KANSCD.Value = Request.Form("hdnMOVE_KANSCD")
                        hdnMOVE_TEL.Value = Request.Form("hdnMOVE_TEL")
                        hdnMOVE_NCUTEL.Value = Request.Form("hdnMOVE_NCUTEL")               '2014/12/03 H.Hosoda add 監視改善2014 No.6
                        hdnMOVE_NAME.Value = Request.Form("hdnMOVE_NAME")
                        hdnMOVE_KANAD.Value = Request.Form("hdnMOVE_KANAD")
                        hdnMOVE_ADDR.Value = Request.Form("hdnMOVE_ADDR")                   '2013/12/09 T.Ono add 監視改善2013
                        hdnMOVE_CLI_CD.Value = Request.Form("hdnMOVE_CLI_CD")
                        hdnMOVE_CLI_CD_NAME.Value = Request.Form("hdnMOVE_CLI_CD_NAME")
                        hdnMOVE_CLI_CD_TO.Value = Request.Form("hdnMOVE_CLI_CD_TO")           '2019/11/01 T.Ono add 監視改善2019 No1
                        hdnMOVE_CLI_CD_TO_NAME.Value = Request.Form("hdnMOVE_CLI_CD_TO_NAME") '2019/11/01 T.Ono add 監視改善2019 No1
                        hdnMOVE_JA_CD.Value = Request.Form("hdnMOVE_JA_CD")                 '2013/12/09 T.Ono add 監視改善2013
                        hdnMOVE_JA_CD_NAME.Value = Request.Form("hdnMOVE_JA_CD_NAME")       '2013/12/09 T.Ono add 監視改善2013
                        hdnMOVE_JA_CD_CLI.Value = Request.Form("hdnMOVE_JA_CD_CLI")         '2019/11/01 T.Ono add 監視改善2019
                        hdnMOVE_HAN_GRP.Value = Request.Form("hdnMOVE_HAN_GRP")             '2014/12/03 H.Hosoda add 監視改善2014 No.6
                        hdnMOVE_HAN_GRP_NAME.Value = Request.Form("hdnMOVE_HAN_GRP_NAME")   '2014/12/03 H.Hosoda add 監視改善2014 No.6
                        hdnMOVE_KINREN_GRP.Value = Request.Form("hdnMOVE_KINREN_GRP")             '2016/11/22 H.Mori add 監視改善2016 No2-1
                        hdnMOVE_KINREN_GRP_NAME.Value = Request.Form("hdnMOVE_KINREN_GRP_NAME")   '2016/11/22 H.Mori add 監視改善2016 No2-1
                        hdnMOVE_HAN_CD.Value = Request.Form("hdnMOVE_HAN_CD")
                        hdnMOVE_HAN_CD_NAME.Value = Request.Form("hdnMOVE_HAN_CD_NAME")
                        hdnMOVE_HAN_CD_CLI.Value = Request.Form("hdnMOVE_HAN_CD_CLI")             '2019/11/01 T.Ono add 監視改善2019
                        hdnMOVE_HAN_CD_TO.Value = Request.Form("hdnMOVE_HAN_CD_TO")               '2016/11/24 H.Mori add 監視改善2016 No2-2
                        hdnMOVE_HAN_CD_NAME_TO.Value = Request.Form("hdnMOVE_HAN_CD_NAME_TO")     '2016/11/24 H.Mori add 監視改善2016 No2-2
                        hdnMOVE_HAN_CD_TO_CLI.Value = Request.Form("hdnMOVE_HAN_CD_TO_CLI")       '2019/11/01 T.Ono add 監視改善2019
                        hdnMOVE_USER_CD.Value = Request.Form("hdnMOVE_USER_CD")
                        hdnMOVE_USER_FLG0.Value = Request.Form("hdnMOVE_USER_FLG0")         '2013/12/20 T.Ono add 監視改善2013
                        hdnMOVE_USER_FLG1.Value = Request.Form("hdnMOVE_USER_FLG1")         '2013/12/20 T.Ono add 監視改善2013
                        hdnMOVE_USER_FLG2.Value = Request.Form("hdnMOVE_USER_FLG2")         '2013/12/20 T.Ono add 監視改善2013
                        hdnMOVE_HANBAI_KBN1.Value = Request.Form("hdnMOVE_HANBAI_KBN1")     '2015/12/15 H.Mori add 監視改善2015
                        hdnMOVE_HANBAI_KBN2.Value = Request.Form("hdnMOVE_HANBAI_KBN2")     '2015/12/15 H.Mori add 監視改善2015
                        hdnMOVE_HANBAI_KBN3.Value = Request.Form("hdnMOVE_HANBAI_KBN3")     '2015/12/15 H.Mori add 監視改善2015
                        hdnMOVE_HANBAI_KBN4.Value = Request.Form("hdnMOVE_HANBAI_KBN4")     '2015/12/15 H.Mori add 監視改善2015
                        hdnMOVE_HANBAI_KBN5.Value = Request.Form("hdnMOVE_HANBAI_KBN5")     '2015/12/15 H.Mori add 監視改善2015
                        hdnMOVE_HANBAI_KBN6.Value = Request.Form("hdnMOVE_HANBAI_KBN6")     '2015/12/15 H.Mori add 監視改善2015
                        'スクロールバー位置の保持
                        hdnScrollTop.Value = Request.Form("hdnScrollTop")                   '2013/12/10 T.Ono add 監視改善2013

                        '画面の出力（コンボの場合は変数に格納）
                        strRec = fncSetData_KOKYAKU()
                        If strRec <> "OK" Then
                            Call fncError()
                            Exit Sub
                        End If
                    End If

                ElseIf strMyAspx = "KEKEKJAG00" Then
                    '対応入力変更一覧画面からの画面遷移の場合

                    '監視センターコードフラグ
                    hdnKANSFLG.Value = "1"

                    '一覧にて選択された検索キーの取得
                    hdnKEY_KANSCD.Value = Request.Form("hdnKEY_KANSCD")
                    hdnKEY_SYONO.Value = Request.Form("hdnKEY_SYONO")
                    '制御値(MOVE)を保持する
                    hdnMOVE_TMSKB.Value = Request.Form("hdnMOVE_TMSKB")
                    hdnMOVE_JUTEL.Value = Request.Form("hdnMOVE_JUTEL")
                    hdnMOVE_NCUTEL.Value = Request.Form("hdnMOVE_NCUTEL")               '2014/12/03 H.Hosoda add 監視改善2014 No.7
                    hdnMOVE_KANSCD.Value = Request.Form("hdnMOVE_KANSCD")
                    hdnMOVE_HATKBN.Value = Request.Form("hdnMOVE_HATKBN")
                    'hdnMOVE_TAIOKBN.Value = Request.Form("hdnMOVE_TAIOKBN")            '2014/12/03 H.Hosoda del 監視改善2014 No.7
                    hdnMOVE_TAIOKBN1.Value = Request.Form("hdnMOVE_TAIOKBN1")           '2014/12/03 H.Hosoda add 監視改善2014 No.7
                    hdnMOVE_TAIOKBN2.Value = Request.Form("hdnMOVE_TAIOKBN2")           '2014/12/03 H.Hosoda add 監視改善2014 No.7
                    hdnMOVE_TAIOKBN3.Value = Request.Form("hdnMOVE_TAIOKBN3")           '2014/12/03 H.Hosoda add 監視改善2014 No.7
                    hdnMOVE_TKTANCD.Value = Request.Form("hdnMOVE_TKTANCD")
                    hdnMOVE_TKTANNM.Value = Request.Form("hdnMOVE_TKTANNM")
                    hdnMOVE_JUSYONM.Value = Request.Form("hdnMOVE_JUSYONM")
                    hdnMOVE_JUSYOKN.Value = Request.Form("hdnMOVE_JUSYOKN")
                    hdnMOVE_KIKANKBN.Value = Request.Form("hdnMOVE_KIKANKBN")    '2017/10/26 H.Mori add 2017改善開発 No3-1
                    hdnMOVE_HATYMD_To.Value = Request.Form("hdnMOVE_HATYMD_To")
                    hdnMOVE_HATTIME_To.Value = Request.Form("hdnMOVE_HATTIME_To")
                    hdnMOVE_HATYMD_From.Value = Request.Form("hdnMOVE_HATYMD_From")
                    hdnMOVE_HATTIME_From.Value = Request.Form("hdnMOVE_HATTIME_From")
                    hdnMOVE_KURACD.Value = Request.Form("hdnMOVE_KURACD")
                    hdnMOVE_KURACD_NAME.Value = Request.Form("hdnMOVE_KURACD_NAME")
                    hdnMOVE_KURACD_TO.Value = Request.Form("hdnMOVE_KURACD_TO")           '2019/11/01 T.Ono add 監視改善2019
                    hdnMOVE_KURACD_TO_NAME.Value = Request.Form("hdnMOVE_KURACD_TO_NAME") '2019/11/01 T.Ono add 監視改善2019
                    hdnMOVE_JA_CD.Value = Request.Form("hdnMOVE_JACD")                 '2013/12/09 T.Ono add 監視改善2013
                    hdnMOVE_JA_CD_NAME.Value = Request.Form("hdnMOVE_JACD_NAME")       '2013/12/09 T.Ono add 監視改善2013
                    hdnMOVE_JA_CD_CLI.Value = Request.Form("hdnMOVE_JACD_CLI")         '2019/11/01 T.Ono add 監視改善2019
                    hdnMOVE_HAN_GRP.Value = Request.Form("hdnMOVE_HAN_GRP")            '2014/12/03 H.Hosoda add 監視改善2014 No.7
                    hdnMOVE_HAN_GRP_NAME.Value = Request.Form("hdnMOVE_HAN_GRP_NAME")  '2014/12/03 H.Hosoda add 監視改善2014 No.7
                    hdnMOVE_KINREN_GRP.Value = Request.Form("hdnMOVE_KINREN_GRP")            '2016/11/25 H.Mori add 監視改善2016 No3-1
                    hdnMOVE_KINREN_GRP_NAME.Value = Request.Form("hdnMOVE_KINREN_GRP_NAME")  '2016/11/25 H.Mori add 監視改善2016 No3-1
                    hdnMOVE_ACBCD.Value = Request.Form("hdnMOVE_ACBCD")
                    hdnMOVE_ACBCD_NAME.Value = Request.Form("hdnMOVE_ACBCD_NAME")
                    hdnMOVE_ACBCD_CLI.Value = Request.Form("hdnMOVE_ACBCD_CLI")           '2019/11/01 T.Ono add 監視改善2019
                    hdnMOVE_ACBCD_TO.Value = Request.Form("hdnMOVE_ACBCD_TO")             '2019/11/01 T.Ono add 監視改善2019
                    hdnMOVE_ACBCD_TO_NAME.Value = Request.Form("hdnMOVE_ACBCD_TO_NAME")   '2019/11/01 T.Ono add 監視改善2019
                    hdnMOVE_ACBCD_TO_CLI.Value = Request.Form("hdnMOVE_ACBCD_TO_CLI")     '2019/11/01 T.Ono add 監視改善2019
                    hdnMOVE_USER_CD.Value = Request.Form("hdnMOVE_USER_CD")
                    '2011.11.15 ADD H.Uema
                    hdnMOVE_KMCD.Value = Request.Form("hdnMOVE_KMCD")
                    hdnMOVE_KMNM.Value = Request.Form("hdnMOVE_KMNM")                   '2013/12/10 T.Ono add 監視改善2013
                    'スクロールバー位置の保持
                    hdnScrollTop.Value = Request.Form("hdnScrollTop")                   '2013/12/10 T.Ono add 監視改善2013
                    '画面の出力（コンボの場合は変数に格納）
                    strRec = fncSetData_TAIOU()
                    If strRec <> "OK" Then
                        Call fncError()
                        Exit Sub
                    End If

                ElseIf strMyAspx = "KEJUKJAG00" Then
                    '警報受信パネルからの画面遷移の場合

                    '監視センターコードフラグ
                    hdnKANSFLG.Value = "1"

                    '一覧にて選択された検索キーの取得
                    hdnKEY_SERIAL.Value = Request.Form("hdnKEY_SERIAL")
                    '制御値(MOVE)を保持する
                    hdnJido.Value = Request.Form("hdnJido")                           '2013/12/13 T.Ono add 監視改善2013
                    hdnMishori.Value = Request.Form("hdnMishori")                     '2013/12/13 T.Ono add 監視改善2013

                    '--- ↓2005/04/20 ADD　Falcon↓ -----------------
                    '利用者情報入力不可
                    Call fncSetState(True)
                    '--- ↑2005/04/20 ADD　Falcon↑ -----------------

                    '画面の出力（コンボの場合は変数に格納）
                    strRec = fncSetData_KEIHOU()
                    If strRec <> "OK" Then
                        Call fncError()
                        Exit Sub
                    End If
                Else
                    'その他からの画面遷移の場合
                    Call fncError()
                    Exit Sub
                End If
            End If

            'コンボボックスを出力する
            Call fncCombo_Create_Taiou()
            Call fncCombo_Create_Syori()
            Call fncCombo_Create_Rebrakua()
            Call fncCombo_Create_Denwaren()
            Call fncCombo_Create_Hukkitai()
            Call fncCombo_Create_Gakukigu()
            Call fncCombo_Create_Sadougen()
            Call fncCombo_Create_Syutusij()

            '2022/12/09 ADD START Y.Arakaki 2022更改No⑦ _特定警報メッセージNo選択時のリスト自動選択対応
            'コンボボックス編集用のリスト取得(画面表示後のJavaScript処理に使用されるデータ)
            Call fncCombo_Get_JidouSentakuList() '特定の警報No選択時、複数の画面リスト項目を自動選択するよう設定
            '2022/12/09 ADD END   Y.Arakaki 2022更改No⑦ _特定警報メッセージNo選択時のリスト自動選択対応

            'コンボの値を選択する
            Call fncComboSet()

            '//-------------------------------------------------
            'フォーカスをセットする
            If strMyAspx = "MSKOSJAG00" Then
                '顧客検索画面からの遷移時
                If Convert.ToString(Request.Form("hdnTaiouClick")) = "1" Then
                    '顧客検索の対応入力ボタン押下時
                    strMsg.Append("Form1.btnKURACD.focus();")
                Else
                    'その他
                    strMsg.Append("Form1.btnTelHas1.focus();")
                End If
            Else
                '受信パネル・結果一覧からの遷移時
                strMsg.Append("Form1.btnTelHas1.focus();")
            End If

            '2022/12/09 ADD START Y.Arakaki 2022更改No⑦ _特定警報メッセージNo選択時のリスト自動選択対応
            If strMyAspx = "KEJUKJAG00" Then
                '警報受信パネルからの画面遷移の場合、警報メッセージをもとに特定リスト内容を自動選択する。
                strMsg.Append("setAutoListValues();")
            End If
            '2022/12/09 ADD END   Y.Arakaki 2022更改No⑦ _特定警報メッセージNo選択時のリスト自動選択対応

            '2014/12/19 T.Ono mod 2014改善開発 No2 START
            ''出力したＪＡ情報より、出動会社・連絡先のデータ取得を行う
            'strMsg.Append("fncSyutudou();")
            '出力したＪＡ情報より、出動会社・連絡先・販売事業者のデータ取得を行う
            strMsg.Append("fncSyutudou(1);")

            '出力した処理区分より対応完了時刻を制御する
            strMsg.Append("fncTMSKB_Chenge();")

            'ガス供給休止日・廃止日・復活日により、画面の色を変える 2013/08/19 T.Ono add 監視改善2013№1
            strMsg.Append("fncChangeColor();")

            '2019/11/01 W.GANEKO 2019監視改善 No8-12 start
            If strMyAspx = "KEKEKJAG00" Then
                strMsg.Append("fncTAIO_Change();")
                If strCBO_TFKICD <> "" Then
                    strMsg.Append("with (Form1) {")
                    strMsg.Append("  cboTFKICD.value = '" + strCBO_TFKICD + "';")
                    strMsg.Append("}")
                End If
            End If
            '2019/11/01 W.GANEKO 2019監視改善 No8-12 end

            '2020/03/11 T.Ono add 監視改善2019
            '対応区分 = 1電話対応、処理区分=１未処理、３処理中の場合、連絡相手当のプルダウンを必須としない
            If strMyAspx = "KEKEKJAG00" Then
                If strCBO_TMSKB <> "2" Then
                    strMsg.Append("fncTMSKB_Chenge();")


                End If
            End If


            hdnInputClientList.Value = fncGetData_ClientList() '2007/05/09 T.Watabe add

            hdnNCUDiffChkMin.Value = ConfigurationSettings.AppSettings("NCU_DIFF_CHK_MIN") '発生～受信時間の経過時間チェック（分）' 2008/10/16 T.Watabe add

        Else
            '//--------------------------------------
            '//　２回目以降実行される
            '//--------------------------------------------------------------------------
            '//※画面表示するコンボボックスは各最終イベント/メソッドでCALLします
            '//--------------------------------------------------------------------------
        End If


        '//-------------------------------------------------
        '<TODO>自分の画面IDをHIDDENのhdnMyAspxに書き込む（システム共通）
        hdnMyAspx.Value = "KETAIJAG00"
        '//-------------------------------------------------
        mlog("[KETAIJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load end")

    End Sub

    '--- ↓2005/04/20 ADD　Falcon↓ -----------------
    '******************************************************************************
    '*　概　要：状態の設定
    '*　備　考：
    '******************************************************************************
    Private Sub fncSetState(ByVal bolState As Boolean)
        'クライアントコード検索ボタンの制御
        btnKURACD.Disabled = bolState

        'ＪＡ支所コード検索ボタンの制御
        btnJASCD.Disabled = bolState
    End Sub
    '--- ↑2005/04/20 ADD　Falcon↑ -----------------

    '******************************************************************************
    '*　概　要：コンボボックスの選択
    '*　備　考：
    '******************************************************************************
    Private Sub fncComboSet()
        Dim list As New ListItem

        If strCBO_TAIOKBN <> "" Then
            list = cboTAIOKBN.Items.FindByValue(strCBO_TAIOKBN)
            cboTAIOKBN.SelectedIndex = cboTAIOKBN.Items.IndexOf(list)
        End If
        If strCBO_TMSKB <> "" Then
            list = cboTMSKB.Items.FindByValue(strCBO_TMSKB)
            cboTMSKB.SelectedIndex = cboTMSKB.Items.IndexOf(list)
        End If
        If strCBO_TAITCD <> "" Then
            list = cboTAITCD.Items.FindByValue(strCBO_TAITCD)
            cboTAITCD.SelectedIndex = cboTAITCD.Items.IndexOf(list)
        End If
        If strCBO_TELRCD <> "" Then
            list = cboTELRCD.Items.FindByValue(strCBO_TELRCD)
            cboTELRCD.SelectedIndex = cboTELRCD.Items.IndexOf(list)
        End If
        If strCBO_TFKICD <> "" Then
            list = cboTFKICD.Items.FindByValue(strCBO_TFKICD)
            cboTFKICD.SelectedIndex = cboTFKICD.Items.IndexOf(list)
        End If
        If strCBO_TKIGCD <> "" Then
            list = cboTKIGCD.Items.FindByValue(strCBO_TKIGCD)
            cboTKIGCD.SelectedIndex = cboTKIGCD.Items.IndexOf(list)
        End If
        If strCBO_TSADCD <> "" Then
            list = cboTSADCD.Items.FindByValue(strCBO_TSADCD)
            cboTSADCD.SelectedIndex = cboTSADCD.Items.IndexOf(list)
        End If
        If strCBO_SDCD <> "" Then
            list = cboSDCD.Items.FindByValue(strCBO_SDCD)
            cboSDCD.SelectedIndex = cboSDCD.Items.IndexOf(list)
        End If

    End Sub

    '******************************************************************************
    '*　概　要：実行ボタン押下時の処理
    '*　備　考：
    '******************************************************************************
    Private Sub btnUpdate_ServerClick(ByVal sender As System.Object,
                                    ByVal e As System.EventArgs) Handles btnUpdate.ServerClick
        mlog("[KETAIJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- btnUpdate_ServerClick start")
        Call fncSetPublic()
        '//--------------------------------------------------------------------------
        '<TODO>登録処理を行う
        mlog("[KETAIJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- btnUpdate_ServerClick Server.Transfer=KETAIJJG00.aspx")
        Server.Transfer("KETAIJJG00.aspx")
        mlog("[KETAIJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- btnUpdate_ServerClick end")
    End Sub

    '******************************************************************************
    '*　概　要：終了ボタン押下時の処理
    '*　備　考：
    '******************************************************************************
    Private Sub btnExit_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                                                                    Handles btnExit.ServerClick
        '遷移してきた画面を保持し、[終了ボタン]押下時に戻る画面の制御をする(VB-Transfer)
        Dim strMyAspx As String
        Dim strRes As String
        strMyAspx = Request.Form("hdnMyAspx")
        mlog("[KETAIJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- btnExit_ServerClick start")

        If hdnBackUrl.Value = "MSKOSJAG00" Then
            mlog("[KETAIJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load MSKOSJAG00 利用者検索画面 Server.Transfer=MSKOSJAG00.aspx")
            '利用者検索画面からの画面遷移の場合
            Server.Transfer("../../../MS/MSKOSJAG/MSKOSJAG00/MSKOSJAG00.aspx")

        ElseIf hdnBackUrl.Value = "KEKEKJAG00" Then
            mlog("[KETAIJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load KEKEKJAG00 対応変更一覧画面 Server.Transfer=KEKEKJAG00.aspx")
            '対応変更一覧画面からの画面遷移の場合
            Server.Transfer("../../../KE/KEKEKJAG/KEKEKJAG00/KEKEKJAG00.aspx")

        ElseIf hdnBackUrl.Value = "KEJUKJAG00" Then
            Dim KETAIJAW00C As New KETAIJAG00KETAIJAW00.KETAIJAW00
            mlog("[KETAIJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load KEJUKJAG00 対応入力_終了押下 hdnKEY_SERIAL=" & hdnKEY_SERIAL.Value)
            '警報DBのロックフラグと対応開始時間を初期化

            'strRes = KETAIJAW00C.mSet_NoRoc(hdnKEY_SERIAL.Value) 
            strRes = KETAIJAW00C.mSet_NoRoc(hdnKEY_SERIAL.Value, AuthC.pUSERNAME) '2017/10/23 H.Mori add 2017改善開発 No4-3
            Select Case strRes
                Case "OK"
                    '警報受信パネルからの画面遷移の場合----------
                    mlog("[KETAIJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load KEJUKJAG00 対応入力_終了押下 Server.Transfer=KEJUKJAG00.aspx OK")
                    Server.Transfer("../../../KE/KEJUKJAG/KEJUKJAG00/KEJUKJAG00.aspx")
                Case Else
                    Dim ErrMsgC As New CErrMsg
                    Call fncError()
                    strMsg.Append("alert('システムエラー：" & ErrMsgC.mGetArtMsg(strRes) & "');")
            End Select
        End If
        mlog("[KETAIJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- btnExit_ServerClick end")

    End Sub
    '******************************************************************************
    '*　概　要：エラー発生時の画面制御
    '*　備　考：戻るボタンのみ使用可能
    '******************************************************************************
    Private Sub fncError()
        ''''''イベントを持つオブジェクトに対するロック処理
        '''''btnTelHas1.Disabled = True
        '''''btnTelHas2.Disabled = True
        '''''btnFAX.Disabled = True
        '''''btnTaiouRireki.Disabled = True
        '''''btnKyoryok.Disabled = True
        '''''txtRNRK_ST_DATE.Enabled = False
        '''''txtRNRK_EN_DATE.Enabled = False
        '''''txtTOKRY_DATE.Enabled = False
        '''''btnUpdate.Disabled = True
        '''''btnExit.Disabled = False
        ''''''エラー時発生時のフォーカスセット
        '''''strMsg.Append("Form1.btnExit.focus();")
    End Sub
    '******************************************************************************
    '*　概　要：画面の更新対象項目をPublic変数に格納する
    '*　備　考：
    '******************************************************************************
    Private Sub fncSetPublic()
        Dim DateFncC As New CDateFnc
        Dim TimeFncC As New CTimeFnc
        Dim NaNFncC As New CNaNFnc
        Dim UtilFucC As New CUtilFuc

        If hdnBackUrl.Value = "KEKEKJAG00" Then
            gstrKBN = "2"               '修正
        Else
            gstrKBN = "1"               '登録
        End If
        gstrADD_DATE = hdnADD_DATE.Value
        gstrEDT_DATE = hdnEDT_DATE.Value
        gstrTIME = hdnTIME.Value

        'データ転記
        '''''gstrKANSCD = strKANSCD  '監視センターコードは監視担当者より取得する→クライアントコードより取得する
        gstrKANSCD = hdnKANSCD.Value
        gstrSYONO = txtSYONO.Text
        gstrNCUHATYMD = DateFncC.mHenkanGet(txtNCUHATYMD.Text) ' 2008/10/15 T.Watabe add
        gstrNCUHATTIME = TimeFncC.mHenkanGet(txtNCUHATTIME.Text) ' 2008/10/15 T.Watabe add
        gstrHATYMD = DateFncC.mHenkanGet(txtHATYMD.Text)
        gstrHATTIME = TimeFncC.mHenkanGet(txtHATTIME.Text)
        gstrKENSIN = txtKMSIN.Text
        gstrKEIHOSU = txtKEIHOSU.Text
        gstrRYURYO = txtRYURYO.Text
        gstrMETASYU = txtMETASYU.Text
        gstrUNYO = hdnUNYOCD.Value
        gstrJUYMD = hdnJUYMD.Value
        gstrJUTIME = hdnJUTIME.Value
        gstrNUM_DIGIT = hdnNUM_DIGIT.Value
        ' 警報メッセージの入れ替え 2013/08/23 T.Ono mod 監視改善2013№1
        'gstrKMCD1 = hdnKMCD1.Value
        'gstrKMNM1 = hdnKMNM1.Value
        'gstrKMCD2 = hdnKMCD2.Value
        'gstrKMNM2 = hdnKMNM2.Value
        'gstrKMCD3 = hdnKMCD3.Value
        'gstrKMNM3 = hdnKMNM3.Value
        'gstrKMCD4 = hdnKMCD4.Value
        'gstrKMNM4 = hdnKMNM4.Value
        'gstrKMCD5 = hdnKMCD5.Value
        'gstrKMNM5 = hdnKMNM5.Value
        'gstrKMCD6 = hdnKMCD6.Value
        'gstrKMNM6 = hdnKMNM6.Value
        fncSetMessage()
        gstrKURACD = txtClientCD.Text
        gstrKENNM = txtKENNM.Text
        gstrJACD = hdnJACD.Value
        gstrJANM = hdnJANAME.Value
        gstrHANJICD = hdnHANJICD.Value '販売事業者コード 2014/12/17 T.Ono add 2014改善開発 No2 START
        gstrHANJINM = hdnHANJINM.Value '販売事業者名     2014/12/17 T.Ono add 2014改善開発 No2 START
        gstrACBCD = hdnJASCD.Value
        gstrACBNM = hdnJASNAME.Value
        gstrUSER_CD = txtJUYOKA.Text
        gstrJUSYONM = txtJUSYONM.Text
        gstrJUSYOKN = txtJUSYOKN.Text
        gstrJUTEL1 = txtJUTEL1.Text
        gstrJUTEL2 = txtJUTEL2.Text
        gstrRENTEL = txtRENTEL.Text
        gstrKTELNO = hdnKTELNO.Value
        gstrADDR = UtilFucC.CrlfCut(txtADDR.Text)       '住所：改行無し
        '--- ↓2005/09/09 MOD Falcon↓ ---
        'gstrUSER_KIJI = txtUSER_KIJI.Text
        gstrBIKOU = txtUSER_KIJI.Text
        '--- ↑2005/09/09 MOD Falcon↑ ---
        gstrNCU_SET = hdnNCU.Value
        gstrTIZUNO = txtMAP_CD.Text
        gstrTUSIN = txtTUSIN.Text ' 2008/10/24 T.Watabe add
        gstrHANBAI_KBN = hdnHANBAI_KBN.Value '2015/11/25 H.Mori add 2015改善開発 No1
        gstrKYOKTKBN = hdnKYOKTKBN.Value '2016/12/02 H.Mori add 2016改善開発 No4-3
        gstrMET_KATA = txtMET_KATA.Text
        gstrMET_MAKER = txtMET_MAKER.Text
        gstrBONB1_KKG = NaNFncC.mHenkanGet(txtBONB1_KKG.Text)
        gstrBONB1_HON = NaNFncC.mHenkanGet(txtBONB1_HON.Text)
        gstrBONB1_YOBI = hdnBONB1_YOBI.Value
        gstrBONB2_KKG = NaNFncC.mHenkanGet(txtBONB2_KKG.Text)
        gstrBONB2_HON = NaNFncC.mHenkanGet(txtBONB2_HON.Text)
        gstrBONB2_YOBI = hdnBONB2_YOBI.Value
        gstrBONB3_KKG = NaNFncC.mHenkanGet(txtBONB3_KKG.Text)
        gstrBONB3_HON = NaNFncC.mHenkanGet(txtBONB3_HON.Text)
        gstrBONB3_YOBI = hdnBONB3_YOBI.Value
        gstrBONB4_KKG = NaNFncC.mHenkanGet(txtBONB4_KKG.Text)
        gstrBONB4_HON = NaNFncC.mHenkanGet(txtBONB4_HON.Text)
        gstrBONB4_YOBI = hdnBONB4_YOBI.Value
        gstrZENKAI_HAISO = DateFncC.mHenkanGet(txtZENKAI_HAISO.Text)
        gstrZENKAI_HAI_S = fncHenkanSisin(txtZENKAI_HAI_S.Text)
        gstrKONKAI_HAISO = DateFncC.mHenkanGet(txtKONKAI_HAISO.Text)
        gstrKONKAI_HAI_S = fncHenkanSisin(txtKONKAI_HAI_S.Text)
        gstrJIKAI_HAISO = DateFncC.mHenkanGet(txtJIKAI_HAISO.Text)
        gstrZENKAI_KENSIN = DateFncC.mHenkanGet(txtZENKAI_KENSIN.Text)
        gstrZENKAI_KEN_S = fncHenkanSisin(txtZENKAI_KEN_S.Text)
        gstrZENKAI_KEN_SIYO = NaNFncC.mHenkanGet(txtZENKAI_KEN_SIYO.Text)
        gstrKONKAI_KENSIN = DateFncC.mHenkanGet(txtKONKAI_KENSIN.Text)
        gstrKONKAI_KEN_S = fncHenkanSisin(txtKONKAI_KEN_S.Text)
        gstrKONKAI_KEN_SIYO = NaNFncC.mHenkanGet(txtKONKAI_KEN_SIYO.Text)
        gstrZENKAI_HASEI = DateFncC.mHenkanGet(txtZENKAI_HASEI.Text)
        gstrZENKAI_HAS_S = fncHenkanSisin(txtZENKAI_HAS_S.Text)
        gstrKONKAI_HASEI = DateFncC.mHenkanGet(txtKONKAI_HASEI.Text)
        gstrKONKAI_HAS_S = fncHenkanSisin(txtKONKAI_HAS_S.Text)
        gstrG_ZAIKO = NaNFncC.mHenkanGet(txtG_ZAIKO.Text)
        '2005/11/22 NEC UPDATE START
        '        gstrICHI_SIYO = fncHenkanSisin(txtICHI_SIYO.Text)
        '        gstrYOSOKU_ICHI_SIYO = fncHenkanSisin(txtYOSOKU_ICHI_SIYO.Text)
        gstrICHI_SIYO = fncHenkanSisin(txtICHI_SIYO.Text, 3)
        gstrYOSOKU_ICHI_SIYO = fncHenkanSisin(txtYOSOKU_ICHI_SIYO.Text, 3)
        '2005/11/22 NEC UPDATE END
        gstrGAS1_HINMEI = txtGAS1_HINMEI.Text
        gstrGAS1_DAISU = txtGAS1_DAISU.Text
        gstrGAS1_SEIFL = txtGAS1_SEIFL.Text
        gstrGAS2_HINMEI = txtGAS2_HINMEI.Text
        gstrGAS2_DAISU = txtGAS2_DAISU.Text
        gstrGAS2_SEIFL = txtGAS2_SEIFL.Text
        gstrGAS3_HINMEI = txtGAS3_HINMEI.Text
        gstrGAS3_DAISU = txtGAS3_DAISU.Text
        gstrGAS3_SEIFL = txtGAS3_SEIFL.Text
        gstrGAS4_HINMEI = txtGAS4_HINMEI.Text
        gstrGAS4_DAISU = txtGAS4_DAISU.Text
        gstrGAS4_SEIFL = txtGAS4_SEIFL.Text
        gstrGAS5_HINMEI = txtGAS5_HINMEI.Text
        gstrGAS5_DAISU = txtGAS5_DAISU.Text
        gstrGAS5_SEIFL = txtGAS5_SEIFL.Text
        gstrHATKBN = hdnHATKBN.Value
        gstrTAIOKBN = Request.Form("cboTAIOKBN")
        gstrTMSKB = Request.Form("cboTMSKB")
        gstrTKTANCD = hdnTKTANCD.Value
        gstrTAITCD = Request.Form("cboTAITCD")
        gstrTAIO_ST_DATE = hdnTAIO_ST_DATE.Value
        gstrTAIO_ST_TIME = hdnTAIO_ST_TIME.Value
        gstrSYOYMD = DateFncC.mHenkanGet(txtSYOYMD.Text)
        gstrSYOTIME = TimeFncC.mHenkanGet(txtSYOTIME.Text)
        If chkFAXKBN.Checked = True Then
            gstrFAXKBN = "1" 'チェックあり　1:不要
        Else
            gstrFAXKBN = "2" 'チェックなし　2:必要
        End If
        If chkFAXKURAKBN.Checked = True Then
            gstrFAXKURAKBN = "1" 'チェックあり　1:不要
        Else
            gstrFAXKURAKBN = "2" 'チェックなし　2:必要
        End If
        '2015/11/17 H.Mori add 2015改善開発 No1 START
        If chkFAXRUISEKIKBN.Checked = True Then
            gstrFAXRUISEKIKBN = "1" 'チェックあり　1:不要
        Else
            gstrFAXRUISEKIKBN = "2" 'チェックなし　2:必要
        End If
        '2015/11/17 H.Mori add 2015改善開発 No1 END
        ' 2010/07/12 T.Watabe add
        gstrTELRCD = Request.Form("cboTELRCD")
        gstrTFKICD = Request.Form("cboTFKICD")
        ' 2013/10/24 T.Ono T.Ono 監視改善2013№1 Start
        'gstrFUK_MEMO = txtFUK_MEMO.Text
        'gstrTEL_MEMO1 = txtTEL_MEMO1.Text
        'gstrTEL_MEMO2 = txtTEL_MEMO2.Text
        gstrTEL_MEMO1 = hdnTEL_MEMO1.Value
        gstrTEL_MEMO2 = hdnTEL_MEMO2.Value
        gstrFUK_MEMO = hdnFUK_MEMO.Value
        ' 2013/10/24 T.Ono T.Ono 監視改善2013№1 End
        '2020/11/01T.Ono add 2020監視改善 Start
        gstrTEL_MEMO4 = hdnTEL_MEMO4.Value
        gstrTEL_MEMO5 = hdnTEL_MEMO5.Value
        gstrTEL_MEMO6 = hdnTEL_MEMO6.Value
        '2020/11/01T.Ono add 2020監視改善 End
        gstrMITOKBN = hdnMOVE_MITOKBN.Value             'ＣＴＩでお客様がいなかったとき１→直接ＣＴＩにて遷移したときは０
        gstrTKIGCD = Request.Form("cboTKIGCD")
        gstrTSADCD = Request.Form("cboTSADCD")
        'gstrGENIN_KIJI = txtGENIN_KIJI.Text    '2021/01/05 T.Ono mod 2020監視改善
        gstrGENIN_KIJI = txtGENIN_KIJI.Value
        gstrSDCD = Request.Form("cboSDCD")
        gstrSIJIYMD = DateFncC.mHenkanGet(txtSIJIYMD.Text)
        gstrSIJITIME = TimeFncC.mHenkanGet(txtSIJITIME.Text)
        gstrSIJI_BIKO1 = txtSIJI_BIKO1.Text
        gstrSIJI_BIKO2 = txtSIJI_BIKO2.Text
        gstrSTD_JASCD = hdnREN_STD_JASCD.Value
        gstrSTD_JANA = hdnREN_STD_JANA.Value
        gstrSTD_JASNA = hdnREN_STD_JASNA.Value
        gstrREN_CODE = hdnREN_0_TANCD.Value
        gstrREN_NA = hdnREN_0_NA.Value
        gstrREN_TEL_1 = hdnREN_0_TEL1.Value
        gstrREN_TEL_2 = hdnREN_0_TEL2.Value
        gstrREN_TEL_3 = hdnREN_0_TEL3.Value         ' 2013/05/27 T.Ono add
        gstrREN_FAX = hdnREN_0_FAX.Value            'ＦＡＸ番号１
        gstrREN_BIKO = hdnREN_0_BIKO.Value
        gstrREN_EDT_DATE = hdnREN_0_EDT_DATE.Value
        gstrREN_TIME = hdnREN_0_TIME.Value
        gstrREN_1_CODE = hdnREN_1_TANCD.Value
        gstrREN_1_NA = hdnREN_1_NA.Value
        gstrREN_1_TEL1 = hdnREN_1_TEL1.Value
        gstrREN_1_TEL2 = hdnREN_1_TEL2.Value
        gstrREN_1_TEL3 = hdnREN_1_TEL3.Value        ' 2013/05/27 T.Ono add
        gstrREN_1_FAX = hdnREN_1_FAX.Value          'ＦＡＸ番号２
        gstrREN_1_BIKO = hdnREN_1_BIKO.Value
        gstrREN_1_EDT_DATE = hdnREN_1_EDT_DATE.Value
        gstrREN_1_TIME = hdnREN_1_TIME.Value
        gstrREN_2_CODE = hdnREN_2_TANCD.Value
        gstrREN_2_NA = hdnREN_2_NA.Value
        gstrREN_2_TEL1 = hdnREN_2_TEL1.Value
        gstrREN_2_TEL2 = hdnREN_2_TEL2.Value
        gstrREN_2_TEL3 = hdnREN_2_TEL3.Value        ' 2013/05/27 T.Ono add
        gstrREN_2_FAX = hdnREN_2_FAX.Value          'ＦＡＸ番号３
        gstrREN_2_BIKO = hdnREN_2_BIKO.Value
        gstrREN_2_EDT_DATE = hdnREN_2_EDT_DATE.Value
        gstrREN_2_TIME = hdnREN_2_TIME.Value
        gstrREN_3_CODE = hdnREN_3_TANCD.Value
        gstrREN_3_NA = hdnREN_3_NA.Value
        gstrREN_3_TEL1 = hdnREN_3_TEL1.Value
        gstrREN_3_TEL2 = hdnREN_3_TEL2.Value
        gstrREN_3_TEL3 = hdnREN_3_TEL3.Value        ' 2013/05/27 T.Ono add
        gstrREN_3_FAX = hdnREN_3_FAX.Value          'ＦＡＸ番号４
        gstrREN_3_BIKO = hdnREN_3_BIKO.Value
        gstrREN_3_EDT_DATE = hdnREN_3_EDT_DATE.Value
        gstrREN_3_TIME = hdnREN_3_TIME.Value

        ' 2008/10/31 T.Watabe add
        gstrREN_4_CODE = hdnREN_4_TANCD.Value              '５
        gstrREN_4_NA = hdnREN_4_NA.Value
        gstrREN_4_TEL1 = hdnREN_4_TEL1.Value
        gstrREN_4_TEL2 = hdnREN_4_TEL2.Value
        gstrREN_4_TEL3 = hdnREN_4_TEL3.Value        ' 2013/05/27 T.Ono add
        gstrREN_4_FAX = hdnREN_4_FAX.Value
        gstrREN_4_BIKO = hdnREN_4_BIKO.Value
        gstrREN_5_CODE = hdnREN_5_TANCD.Value              '６
        gstrREN_5_NA = hdnREN_5_NA.Value
        gstrREN_5_TEL1 = hdnREN_5_TEL1.Value
        gstrREN_5_TEL2 = hdnREN_5_TEL2.Value
        gstrREN_5_TEL3 = hdnREN_5_TEL3.Value        ' 2013/05/27 T.Ono add
        gstrREN_5_FAX = hdnREN_5_FAX.Value
        gstrREN_5_BIKO = hdnREN_5_BIKO.Value
        gstrREN_6_CODE = hdnREN_6_TANCD.Value              '７
        gstrREN_6_NA = hdnREN_6_NA.Value
        gstrREN_6_TEL1 = hdnREN_6_TEL1.Value
        gstrREN_6_TEL2 = hdnREN_6_TEL2.Value
        gstrREN_6_TEL3 = hdnREN_6_TEL3.Value        ' 2013/05/27 T.Ono add
        gstrREN_6_FAX = hdnREN_6_FAX.Value
        gstrREN_6_BIKO = hdnREN_6_BIKO.Value
        gstrREN_7_CODE = hdnREN_7_TANCD.Value              '８
        gstrREN_7_NA = hdnREN_7_NA.Value
        gstrREN_7_TEL1 = hdnREN_7_TEL1.Value
        gstrREN_7_TEL2 = hdnREN_7_TEL2.Value
        gstrREN_7_TEL3 = hdnREN_7_TEL3.Value        ' 2013/05/27 T.Ono add
        gstrREN_7_FAX = hdnREN_7_FAX.Value
        gstrREN_7_BIKO = hdnREN_7_BIKO.Value
        gstrREN_8_CODE = hdnREN_8_TANCD.Value              '９
        gstrREN_8_NA = hdnREN_8_NA.Value
        gstrREN_8_TEL1 = hdnREN_8_TEL1.Value
        gstrREN_8_TEL2 = hdnREN_8_TEL2.Value
        gstrREN_8_TEL3 = hdnREN_8_TEL3.Value        ' 2013/05/27 T.Ono add
        gstrREN_8_FAX = hdnREN_8_FAX.Value
        gstrREN_8_BIKO = hdnREN_8_BIKO.Value
        gstrREN_9_CODE = hdnREN_9_TANCD.Value              '１０
        gstrREN_9_NA = hdnREN_9_NA.Value
        gstrREN_9_TEL1 = hdnREN_9_TEL1.Value
        gstrREN_9_TEL2 = hdnREN_9_TEL2.Value
        gstrREN_9_TEL3 = hdnREN_9_TEL3.Value        ' 2013/05/27 T.Ono add
        gstrREN_9_FAX = hdnREN_9_FAX.Value
        gstrREN_9_BIKO = hdnREN_9_BIKO.Value

        ' 2010/05/10 T.Watabe add
        gstrREN_10_CODE = hdnREN_10_TANCD.Value
        gstrREN_10_NA = hdnREN_10_NA.Value
        gstrREN_10_TEL1 = hdnREN_10_TEL1.Value
        gstrREN_10_TEL2 = hdnREN_10_TEL2.Value
        gstrREN_10_TEL3 = hdnREN_10_TEL3.Value        ' 2013/05/27 T.Ono add
        gstrREN_10_FAX = hdnREN_10_FAX.Value
        gstrREN_10_BIKO = hdnREN_10_BIKO.Value
        gstrREN_11_CODE = hdnREN_11_TANCD.Value
        gstrREN_11_NA = hdnREN_11_NA.Value
        gstrREN_11_TEL1 = hdnREN_11_TEL1.Value
        gstrREN_11_TEL2 = hdnREN_11_TEL2.Value
        gstrREN_11_TEL3 = hdnREN_11_TEL3.Value        ' 2013/05/27 T.Ono add
        gstrREN_11_FAX = hdnREN_11_FAX.Value
        gstrREN_11_BIKO = hdnREN_11_BIKO.Value
        gstrREN_12_CODE = hdnREN_12_TANCD.Value
        gstrREN_12_NA = hdnREN_12_NA.Value
        gstrREN_12_TEL1 = hdnREN_12_TEL1.Value
        gstrREN_12_TEL2 = hdnREN_12_TEL2.Value
        gstrREN_12_TEL3 = hdnREN_12_TEL3.Value        ' 2013/05/27 T.Ono add
        gstrREN_12_FAX = hdnREN_12_FAX.Value
        gstrREN_12_BIKO = hdnREN_12_BIKO.Value
        gstrREN_13_CODE = hdnREN_13_TANCD.Value
        gstrREN_13_NA = hdnREN_13_NA.Value
        gstrREN_13_TEL1 = hdnREN_13_TEL1.Value
        gstrREN_13_TEL2 = hdnREN_13_TEL2.Value
        gstrREN_13_TEL3 = hdnREN_13_TEL3.Value        ' 2013/05/27 T.Ono add
        gstrREN_13_FAX = hdnREN_13_FAX.Value
        gstrREN_13_BIKO = hdnREN_13_BIKO.Value
        gstrREN_14_CODE = hdnREN_14_TANCD.Value
        gstrREN_14_NA = hdnREN_14_NA.Value
        gstrREN_14_TEL1 = hdnREN_14_TEL1.Value
        gstrREN_14_TEL2 = hdnREN_14_TEL2.Value
        gstrREN_14_TEL3 = hdnREN_14_TEL3.Value        ' 2013/05/27 T.Ono add
        gstrREN_14_FAX = hdnREN_14_FAX.Value
        gstrREN_14_BIKO = hdnREN_14_BIKO.Value
        gstrREN_15_CODE = hdnREN_15_TANCD.Value
        gstrREN_15_NA = hdnREN_15_NA.Value
        gstrREN_15_TEL1 = hdnREN_15_TEL1.Value
        gstrREN_15_TEL2 = hdnREN_15_TEL2.Value
        gstrREN_15_TEL3 = hdnREN_15_TEL3.Value        ' 2013/05/27 T.Ono add
        gstrREN_15_FAX = hdnREN_15_FAX.Value
        gstrREN_15_BIKO = hdnREN_15_BIKO.Value
        gstrREN_16_CODE = hdnREN_16_TANCD.Value
        gstrREN_16_NA = hdnREN_16_NA.Value
        gstrREN_16_TEL1 = hdnREN_16_TEL1.Value
        gstrREN_16_TEL2 = hdnREN_16_TEL2.Value
        gstrREN_16_TEL3 = hdnREN_16_TEL3.Value        ' 2013/05/27 T.Ono add
        gstrREN_16_FAX = hdnREN_16_FAX.Value
        gstrREN_16_BIKO = hdnREN_16_BIKO.Value
        gstrREN_17_CODE = hdnREN_17_TANCD.Value
        gstrREN_17_NA = hdnREN_17_NA.Value
        gstrREN_17_TEL1 = hdnREN_17_TEL1.Value
        gstrREN_17_TEL2 = hdnREN_17_TEL2.Value
        gstrREN_17_TEL3 = hdnREN_17_TEL3.Value        ' 2013/05/27 T.Ono add
        gstrREN_17_FAX = hdnREN_17_FAX.Value
        gstrREN_17_BIKO = hdnREN_17_BIKO.Value
        gstrREN_18_CODE = hdnREN_18_TANCD.Value
        gstrREN_18_NA = hdnREN_18_NA.Value
        gstrREN_18_TEL1 = hdnREN_18_TEL1.Value
        gstrREN_18_TEL2 = hdnREN_18_TEL2.Value
        gstrREN_18_TEL3 = hdnREN_18_TEL3.Value        ' 2013/05/27 T.Ono add
        gstrREN_18_FAX = hdnREN_18_FAX.Value
        gstrREN_18_BIKO = hdnREN_18_BIKO.Value
        gstrREN_19_CODE = hdnREN_19_TANCD.Value
        gstrREN_19_NA = hdnREN_19_NA.Value
        gstrREN_19_TEL1 = hdnREN_19_TEL1.Value
        gstrREN_19_TEL2 = hdnREN_19_TEL2.Value
        gstrREN_19_TEL3 = hdnREN_19_TEL3.Value        ' 2013/05/27 T.Ono add
        gstrREN_19_FAX = hdnREN_19_FAX.Value
        gstrREN_19_BIKO = hdnREN_19_BIKO.Value
        gstrREN_20_CODE = hdnREN_20_TANCD.Value
        gstrREN_20_NA = hdnREN_20_NA.Value
        gstrREN_20_TEL1 = hdnREN_20_TEL1.Value
        gstrREN_20_TEL2 = hdnREN_20_TEL2.Value
        gstrREN_20_TEL3 = hdnREN_20_TEL3.Value        ' 2013/05/27 T.Ono add
        gstrREN_20_FAX = hdnREN_20_FAX.Value
        gstrREN_20_BIKO = hdnREN_20_BIKO.Value
        gstrREN_21_CODE = hdnREN_21_TANCD.Value
        gstrREN_21_NA = hdnREN_21_NA.Value
        gstrREN_21_TEL1 = hdnREN_21_TEL1.Value
        gstrREN_21_TEL2 = hdnREN_21_TEL2.Value
        gstrREN_21_TEL3 = hdnREN_21_TEL3.Value        ' 2013/05/27 T.Ono add
        gstrREN_21_FAX = hdnREN_21_FAX.Value
        gstrREN_21_BIKO = hdnREN_21_BIKO.Value
        gstrREN_22_CODE = hdnREN_22_TANCD.Value
        gstrREN_22_NA = hdnREN_22_NA.Value
        gstrREN_22_TEL1 = hdnREN_22_TEL1.Value
        gstrREN_22_TEL2 = hdnREN_22_TEL2.Value
        gstrREN_22_TEL3 = hdnREN_22_TEL3.Value        ' 2013/05/27 T.Ono add
        gstrREN_22_FAX = hdnREN_22_FAX.Value
        gstrREN_22_BIKO = hdnREN_22_BIKO.Value
        gstrREN_23_CODE = hdnREN_23_TANCD.Value
        gstrREN_23_NA = hdnREN_23_NA.Value
        gstrREN_23_TEL1 = hdnREN_23_TEL1.Value
        gstrREN_23_TEL2 = hdnREN_23_TEL2.Value
        gstrREN_23_TEL3 = hdnREN_23_TEL3.Value        ' 2013/05/27 T.Ono add
        gstrREN_23_FAX = hdnREN_23_FAX.Value
        gstrREN_23_BIKO = hdnREN_23_BIKO.Value
        gstrREN_24_CODE = hdnREN_24_TANCD.Value
        gstrREN_24_NA = hdnREN_24_NA.Value
        gstrREN_24_TEL1 = hdnREN_24_TEL1.Value
        gstrREN_24_TEL2 = hdnREN_24_TEL2.Value
        gstrREN_24_TEL3 = hdnREN_24_TEL3.Value        ' 2013/05/27 T.Ono add
        gstrREN_24_FAX = hdnREN_24_FAX.Value
        gstrREN_24_BIKO = hdnREN_24_BIKO.Value
        gstrREN_25_CODE = hdnREN_25_TANCD.Value
        gstrREN_25_NA = hdnREN_25_NA.Value
        gstrREN_25_TEL1 = hdnREN_25_TEL1.Value
        gstrREN_25_TEL2 = hdnREN_25_TEL2.Value
        gstrREN_25_TEL3 = hdnREN_25_TEL3.Value        ' 2013/05/27 T.Ono add
        gstrREN_25_FAX = hdnREN_25_FAX.Value
        gstrREN_25_BIKO = hdnREN_25_BIKO.Value
        gstrREN_26_CODE = hdnREN_26_TANCD.Value
        gstrREN_26_NA = hdnREN_26_NA.Value
        gstrREN_26_TEL1 = hdnREN_26_TEL1.Value
        gstrREN_26_TEL2 = hdnREN_26_TEL2.Value
        gstrREN_26_TEL3 = hdnREN_26_TEL3.Value        ' 2013/05/27 T.Ono add
        gstrREN_26_FAX = hdnREN_26_FAX.Value
        gstrREN_26_BIKO = hdnREN_26_BIKO.Value
        gstrREN_27_CODE = hdnREN_27_TANCD.Value
        gstrREN_27_NA = hdnREN_27_NA.Value
        gstrREN_27_TEL1 = hdnREN_27_TEL1.Value
        gstrREN_27_TEL2 = hdnREN_27_TEL2.Value
        gstrREN_27_TEL3 = hdnREN_27_TEL3.Value        ' 2013/05/27 T.Ono add
        gstrREN_27_FAX = hdnREN_27_FAX.Value
        gstrREN_27_BIKO = hdnREN_27_BIKO.Value
        gstrREN_28_CODE = hdnREN_28_TANCD.Value
        gstrREN_28_NA = hdnREN_28_NA.Value
        gstrREN_28_TEL1 = hdnREN_28_TEL1.Value
        gstrREN_28_TEL2 = hdnREN_28_TEL2.Value
        gstrREN_28_TEL3 = hdnREN_28_TEL3.Value        ' 2013/05/27 T.Ono add
        gstrREN_28_FAX = hdnREN_28_FAX.Value
        gstrREN_28_BIKO = hdnREN_28_BIKO.Value
        gstrREN_29_CODE = hdnREN_29_TANCD.Value
        gstrREN_29_NA = hdnREN_29_NA.Value
        gstrREN_29_TEL1 = hdnREN_29_TEL1.Value
        gstrREN_29_TEL2 = hdnREN_29_TEL2.Value
        gstrREN_29_TEL3 = hdnREN_29_TEL3.Value        ' 2013/05/27 T.Ono add
        gstrREN_29_FAX = hdnREN_29_FAX.Value
        gstrREN_29_BIKO = hdnREN_29_BIKO.Value

        '2012/03/26 START ADD W.GANEKO
        gstrREN_MAIL = hdnREN_0_MAIL.Value
        gstrREN_1_MAIL = hdnREN_1_MAIL.Value
        gstrREN_2_MAIL = hdnREN_2_MAIL.Value
        gstrREN_3_MAIL = hdnREN_3_MAIL.Value
        gstrREN_4_MAIL = hdnREN_4_MAIL.Value
        gstrREN_5_MAIL = hdnREN_5_MAIL.Value
        gstrREN_6_MAIL = hdnREN_6_MAIL.Value
        gstrREN_7_MAIL = hdnREN_7_MAIL.Value
        gstrREN_8_MAIL = hdnREN_8_MAIL.Value
        gstrREN_9_MAIL = hdnREN_9_MAIL.Value
        gstrREN_10_MAIL = hdnREN_10_MAIL.Value
        gstrREN_11_MAIL = hdnREN_11_MAIL.Value
        gstrREN_12_MAIL = hdnREN_12_MAIL.Value
        gstrREN_13_MAIL = hdnREN_13_MAIL.Value
        gstrREN_14_MAIL = hdnREN_14_MAIL.Value
        gstrREN_15_MAIL = hdnREN_15_MAIL.Value
        gstrREN_16_MAIL = hdnREN_16_MAIL.Value
        gstrREN_17_MAIL = hdnREN_17_MAIL.Value
        gstrREN_18_MAIL = hdnREN_18_MAIL.Value
        gstrREN_19_MAIL = hdnREN_19_MAIL.Value
        gstrREN_20_MAIL = hdnREN_20_MAIL.Value
        gstrREN_21_MAIL = hdnREN_21_MAIL.Value
        gstrREN_22_MAIL = hdnREN_22_MAIL.Value
        gstrREN_23_MAIL = hdnREN_23_MAIL.Value
        gstrREN_24_MAIL = hdnREN_24_MAIL.Value
        gstrREN_25_MAIL = hdnREN_25_MAIL.Value
        gstrREN_26_MAIL = hdnREN_26_MAIL.Value
        gstrREN_27_MAIL = hdnREN_27_MAIL.Value
        gstrREN_28_MAIL = hdnREN_28_MAIL.Value
        gstrREN_29_MAIL = hdnREN_29_MAIL.Value
        gstrREN_MAILPASS = hdnREN_0_MAILPASS.Value
        gstrREN_1_MAILPASS = hdnREN_1_MAILPASS.Value
        gstrREN_2_MAILPASS = hdnREN_2_MAILPASS.Value
        gstrREN_3_MAILPASS = hdnREN_3_MAILPASS.Value
        gstrREN_4_MAILPASS = hdnREN_4_MAILPASS.Value
        gstrREN_5_MAILPASS = hdnREN_5_MAILPASS.Value
        gstrREN_6_MAILPASS = hdnREN_6_MAILPASS.Value
        gstrREN_7_MAILPASS = hdnREN_7_MAILPASS.Value
        gstrREN_8_MAILPASS = hdnREN_8_MAILPASS.Value
        gstrREN_9_MAILPASS = hdnREN_9_MAILPASS.Value
        gstrREN_10_MAILPASS = hdnREN_10_MAILPASS.Value
        gstrREN_11_MAILPASS = hdnREN_11_MAILPASS.Value
        gstrREN_12_MAILPASS = hdnREN_12_MAILPASS.Value
        gstrREN_13_MAILPASS = hdnREN_13_MAILPASS.Value
        gstrREN_14_MAILPASS = hdnREN_14_MAILPASS.Value
        gstrREN_15_MAILPASS = hdnREN_15_MAILPASS.Value
        gstrREN_16_MAILPASS = hdnREN_16_MAILPASS.Value
        gstrREN_17_MAILPASS = hdnREN_17_MAILPASS.Value
        gstrREN_18_MAILPASS = hdnREN_18_MAILPASS.Value
        gstrREN_19_MAILPASS = hdnREN_19_MAILPASS.Value
        gstrREN_20_MAILPASS = hdnREN_20_MAILPASS.Value
        gstrREN_21_MAILPASS = hdnREN_21_MAILPASS.Value
        gstrREN_22_MAILPASS = hdnREN_22_MAILPASS.Value
        gstrREN_23_MAILPASS = hdnREN_23_MAILPASS.Value
        gstrREN_24_MAILPASS = hdnREN_24_MAILPASS.Value
        gstrREN_25_MAILPASS = hdnREN_25_MAILPASS.Value
        gstrREN_26_MAILPASS = hdnREN_26_MAILPASS.Value
        gstrREN_27_MAILPASS = hdnREN_27_MAILPASS.Value
        gstrREN_28_MAILPASS = hdnREN_28_MAILPASS.Value
        gstrREN_29_MAILPASS = hdnREN_29_MAILPASS.Value
        '2012/03/26 END ADD W.GANEKO

        gstrREN_DENWABIKO = hdnREN_DENWABIKO.Value
        gstrFAX_TITLE_CD = hdnFAX_TITLE_CD.Value    'ＦＡＸタイトルコード
        gstrREN_FAXTITLE = hdnREN_FAXTITLE.Value    'ＦＡＸタイトル
        gstrREN_FAX_REN = hdnREN_FAXREN.Value       'メモ欄
        gstrSTD_CD = hdnSTD_CD.Value
        gstrSTD = txtSTD.Text
        gstrSTD_KYOTEN_CD = hdnSTD_KYOTEN_CD.Value
        gstrSTD_KYOTEN = txtSTD_KYOTEN.Text
        gstrSTD_TEL = txtSTD_TEL.Text
        '//対応DB追加項目-----------------
        gstrBOMB_TYPE = hdnBOMB_TYPE.Value
        gstrGAS_STOP = DateFncC.mHenkanGet(txtGAS_START.Text)
        gstrGAS_DELE = DateFncC.mHenkanGet(txtGAS_DELE.Text)
        gstrGAS_RESTART = DateFncC.mHenkanGet(txtGAS_RESTART.Text)
        '2016/02/02 w.ganeko 2015監視改善 №1-3 start
        gstrKANSHI_BIKO = txtKANSHI_BIKO.Text
        gstrRENTEL2 = hdnRENTEL2.Value
        gstrRENTEL2_BIKO = hdnRENTEL2_BIKO.Value
        gstrRENTEL2_UPD_DATE = DateFncC.mHenkanGet(hdnRENTEL2_UPD_DATE.Value)
        gstrRENTEL3 = hdnRENTEL3.Value
        gstrRENTEL3_BIKO = hdnRENTEL3_BIKO.Value
        gstrRENTEL3_UPD_DATE = DateFncC.mHenkanGet(hdnRENTEL3_UPD_DATE.Value)
        gstrTelJVG = hdnTelJVG.Value
        '2016/02/02 w.ganeko 2015監視改善 №1-3 end
        '2016/12/12 H.Mori add 2015監視改善 No5-1 START
        gstrTELAB = hdnTELAB.Value
        gstrDAI3RENDORENTEL = hdnDAI3RENDORENTEL.Value
        '2016/12/12 H.Mori add 2015監視改善 No5-1
        '2016/12/14 H.Mori add 2016監視改善 No6-3 START
        If hdnFAXSPOTKBN.Value = "2" Then
            gstrFAXSPOTKBN = "2" 'スポットFAX送信済み
        Else
            gstrFAXSPOTKBN = "1" 'スポットFAX未送信
        End If
        '2016/12/14 H.Mori add 2016監視改善 No6-3 END
        '2016/12/22 H.Mori add 2016監視改善 No4-6 START
        gstrDAIHYO_NAME = hdnDAIHYO_NAME.Value
        gstrHOKBN = hdnHOKBN.Value
        gstrYOTOKBN = hdnYOTOKBN.Value
        gstrHANBCD = hdnHANBCD.Value
        gstrKINRENCD = hdnGROUPCD.Value
        gstrJMNAME = hdnGROUPNM.Value   ' 2023/01/04 ADD Y.ARAKAKI 2022更改No⑥ _帳票JMコード表示追加対応 
        '2016/12/22 H.Mori add 2016監視改善 No4-6 END
        '2017/10/16 H.Mori add 2017改善開発 No4-1 START
        gstrSHUGOU = hdnSHUGOU.Value
        '2017/10/16 H.Mori add 2017改善開発 No4-1 END

        '//-------------------------------
        '電話発信ログ登録用
        gstrDialKbns = hdnDialKbns.Value
        gstrDialNumbers = hdnDialNumbers.Value
        gstrDialAites = hdnDialAitename.Value
        gstrDialResult = hdnDialResult.Value
        gstrDialDates = hdnDialDates.Value
        gstrDialTimes = hdnDialTimes.Value
        gstrDialStates = hdnDialStates.Value
        gstrSDSKBN = hdnSDSKBN.Value ' 2008/10/17 T.Watabe add

        '本日工事状況　2013/08/23 T.Ono add 監視改善2013№1
        gstrKAITU_DAY = txtKAITU_DAY.Text


    End Sub

    '******************************************************************************
    ' 通報受信パネルからの遷移時の画面出力
    '******************************************************************************
    Private Function fncSetData_KEIHOU() As String
        Dim SQLC As New KETAIJAG00CSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet

        Dim strRec As String
        'Dim strPar(2) As String ' FAXKBN,FAXKURAKBN,GUIDELINE格納用　2013/08/07 T.Ono add '2019/11/01 W.GANEKO 2019監視改善 No8-12
        Dim strPar(4) As String ' FAXKBN,FAXKURAKBN,GUIDELINE,GUIDELINE2,GUIDELINE3 格納用　2019/11/01 W.GANEKO 2019監視改善 No8-12 
        Dim strKAITU_DAY As String  ' 本日工事状況　2013/08/23 T.Ono add 監視改善2013№1
        Try
            mlog("[KETAIJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- fncSetData_KEIHOU start")

            ' 2013/08/07 T.Ono add FAXKBN,FAXKURAKBN,GUIDELINEはとり方が他と違うため、先に取得
            strPar = fncGetFAXKBN_GUIDE_KEIHOU()
            strKAITU_DAY = fncGetKAITU_DAY_KEIHO()

            '//警報受信パネルからの画面遷移の場合
            strSQL = New StringBuilder("")
            strSQL.Append("SELECT  ")
            strSQL.Append("KEI.SYORI_SERIAL, ")
            strSQL.Append("KEI.FILE_NAME, ")
            strSQL.Append("KEI.REACTION, ")
            strSQL.Append("KEI.IS_PRINTED, ")
            strSQL.Append("KEI.SYONO, ")
            strSQL.Append("KEI.SAYMD AS JUYMD, ")
            strSQL.Append("KEI.SUYMD, ")
            strSQL.Append("KEI.STIME AS JUTIME, ")
            strSQL.Append("KEI.MES_TYPE, ")
            strSQL.Append("KEI.REPLY_CODE, ")
            strSQL.Append("KEI.MEDIA_TYPE, ")
            strSQL.Append("KEI.KANSCD, ")
            strSQL.Append("KEI.KURACD AS CLI_CD, ")
            strSQL.Append("KEI.ACBCD, ")
            strSQL.Append("KEI.JUYOKA, ")
            strSQL.Append("KEI.JUYOKA AS JUYOKA_CD, ")
            '''''strSQL.Append("KEI.ACBCD || KEI.JUYOKA AS JUYOKA_CD, ")
            strSQL.Append("KEI.INFO_1, ")
            strSQL.Append("KEI.INFO_2, ")
            strSQL.Append("SUBSTR(KEI.INFO_2,3,1) AS RYURYO, ")
            strSQL.Append("KEI.SECURITY_2, ")
            strSQL.Append("KEI.KMYMD, ")
            strSQL.Append("KEI.KMTIME, ")
            strSQL.Append("KEI.JUYONM, ")
            'strSQL.Append("KEI.ADDR, ") ' 2008/10/29 T.Watabe edit 警報からの場合に、住所末尾が切れないように対応
            'strSQL.Append("RTRIM(KEI.ADDR || ' ' || KOK.ADD_3) AS ADDR, ")
            strSQL.Append("KOK.ADD_1 || ' ' || KOK.ADD_2 || ' ' || KOK.ADD_3 AS ADDR, ") '2017/10/17 H.Mori mod 2017改善開発 No4-2
            strSQL.Append("KEI.KMSIN, ")
            strSQL.Append("KEI.NUM_DIGIT, ")
            strSQL.Append("KEI.KMCD1, ")
            strSQL.Append("KEI.KMNM1, ")
            strSQL.Append("KEI.KMCD2, ")
            strSQL.Append("KEI.KMNM2, ")
            strSQL.Append("KEI.KMCD3, ")
            strSQL.Append("KEI.KMNM3, ")
            strSQL.Append("KEI.KMCD4, ")
            strSQL.Append("KEI.KMNM4, ")
            strSQL.Append("KEI.KMCD5, ")
            strSQL.Append("KEI.KMNM5, ")
            strSQL.Append("KEI.KMCD6, ")
            strSQL.Append("KEI.KMNM6, ")
            strSQL.Append("KEI.META_SYUBETU, ")
            strSQL.Append("KEI.KENSIN_MODE, ")
            strSQL.Append("KEI.OKYAKU_FLG AS UNYOCD, ")
            strSQL.Append("KEI.ROC_FRG, ")
            strSQL.Append("KEI.ROC_TIME, ")
            strSQL.Append("KEI.BIKOU, ")          '--- 2005/09/09 ADD Falcon
            strSQL.Append("KOK.NAME, ")
            strSQL.Append("KOK.KANA, ")
            '2005/07/28 NEC UPDATE START
            'strSQL.Append("KOK.NCU_TELA AS JUTEL1, ")           '顧客：ＮＣＵ電話番号市外
            'strSQL.Append("KOK.NCU_TELB AS JUTEL2, ")           '顧客：ＮＣＵ電話番号市内
            '2006/05/23 NEC UPDATE START
            'strSQL.Append("KOK.TELA AS JUTEL1, ")           '顧客：ＮＣＵ電話番号市外
            'strSQL.Append("KOK.TELB AS JUTEL2, ")           '顧客：ＮＣＵ電話番号市内
            strSQL.Append("KOK.NCU_TELA AS JUTEL1, ")           '顧客：ＮＣＵ電話番号市外
            strSQL.Append("KOK.NCU_TELB AS JUTEL2, ")           '顧客：ＮＣＵ電話番号市内
            '2006/05/23 NEC UPDATE END
            '2005/07/28 NEC UPDATE END
            strSQL.Append("KEI.JUTEL AS RENTEL, ")              '警報：電話番号
            strSQL.Append("KOK.KANKENSAKU_TEL AS KTELNO, ")     '顧客：検索用電話番号
            strSQL.Append("KOK.USR_MEMO, ")
            strSQL.Append("KOK.USR_MEMO AS GENIN_KIJI, ")
            strSQL.Append("KOK.NCU_CON, ")
            strSQL.Append("KOK.HANBAI_KBN, ") '2015/11/25 H.Mori add 2015改善開発 No1
            strSQL.Append("KOK.KYOKTKBN, ") '2016/12/02 H.Mori add 2016改善開発 No4-3
            strSQL.Append("KOK.SETSUBI, ")
            strSQL.Append("KOK.KYOKYU_MK, ")
            strSQL.Append("KOK.MAP_CD, ")
            strSQL.Append("KOK.BOMB_TYPE, ")
            strSQL.Append("KOK.BOMB_YOUKI1, ")
            strSQL.Append("KOK.BOMB_SUU1, ")
            strSQL.Append("KOK.YOBI_FLG1 AS BOMB_RYO1, ")
            strSQL.Append("KOK.BOMB_YOUKI2, ")
            strSQL.Append("KOK.BOMB_SUU2, ")
            strSQL.Append("KOK.YOBI_FLG2 AS BOMB_RYO2, ")
            strSQL.Append("KOK.BOMB_YOUKI3, ")
            strSQL.Append("KOK.BOMB_SUU3, ")
            strSQL.Append("KOK.YOBI_FLG3 AS BOMB_RYO3, ")
            strSQL.Append("KOK.BOMB_YOUKI4, ")
            strSQL.Append("KOK.BOMB_SUU4, ")
            strSQL.Append("KOK.YOBI_FLG4 AS BOMB_RYO4, ")
            strSQL.Append("KOK.SIYOU3, ")
            strSQL.Append("KOK.SIYOU4, ")
            strSQL.Append("KOK.BOMV_HAISO1, ")
            strSQL.Append("KOK.BOMV_SISIN1, ")
            strSQL.Append("KOK.BOMV_HAISO2, ")
            strSQL.Append("KOK.BOMV_SISIN2, ")
            strSQL.Append("KOK.HAISO_YOTEI, ")
            strSQL.Append("KOK.BOMB_DATE1, ")
            strSQL.Append("KOK.BOMB_SISIN1, ")
            strSQL.Append("KOK.BOMB_DATE2, ")
            strSQL.Append("KOK.BOMB_SISIN2, ")
            strSQL.Append("KOK.KENSIN_DAY1, ")
            strSQL.Append("KOK.KENSINTI1, ")
            strSQL.Append("KOK.KENSIN_DAY2, ")
            strSQL.Append("KOK.KENSINTI2, ")
            strSQL.Append("KOK.SIYOU1, ")
            strSQL.Append("KOK.SIYOU2, ")
            strSQL.Append("KOK.GAS_NAME1, ")
            strSQL.Append("KOK.GAS_NAME2, ")
            strSQL.Append("KOK.GAS_NAME3, ")
            strSQL.Append("KOK.GAS_NAME4, ")
            strSQL.Append("KOK.GAS_NAME5, ")
            strSQL.Append("KOK.GAS_SUU1, ")
            strSQL.Append("KOK.GAS_SUU2, ")
            strSQL.Append("KOK.GAS_SUU3, ")
            strSQL.Append("KOK.GAS_SUU4, ")
            strSQL.Append("KOK.GAS_SUU5, ")
            strSQL.Append("KOK.GAS_SEIF1, ")
            strSQL.Append("KOK.GAS_SEIF2, ")
            strSQL.Append("KOK.GAS_SEIF3, ")
            strSQL.Append("KOK.GAS_SEIF4, ")
            strSQL.Append("KOK.GAS_SEIF5, ")
            strSQL.Append("KOK.GAS_STOP AS GAS_START, ")
            strSQL.Append("KOK.GAS_DELE, ")
            strSQL.Append("KOK.GAS_RESTART, ")
            strSQL.Append("KOK.KANSHI_BIKO, ")          '2016/02/02 w.ganeko 2015監視改善 №1-3
            strSQL.Append("KOK.RENTEL2, ")                '2016/02/02 w.ganeko 2015改善開発 №1-3
            strSQL.Append("KOK.RENTEL2_BIKO, ")           '2016/02/02 w.ganeko 2015改善開発 №1-3
            strSQL.Append("KOK.RENTEL2_UPD_DATE, ")       '2016/02/02 w.ganeko 2015改善開発 №1-3
            strSQL.Append("KOK.RENTEL3, ")                '2016/02/02 w.ganeko 2015改善開発 №1-3
            strSQL.Append("KOK.RENTEL3_BIKO, ")           '2016/02/02 w.ganeko 2015改善開発 №1-3
            strSQL.Append("KOK.RENTEL3_UPD_DATE, ")       '2016/02/02 w.ganeko 2015改善開発 №1-3
            strSQL.Append("KOK.TELA || TELB TELAB, ")     '2016/12/12 add H.Mori 2016改善開発 No5-1
            strSQL.Append("KOK.DAI3RENDORENTEL, ")        '2016/12/12 add H.Mori 2016改善開発 No5-1
            strSQL.Append("KOK.DAIHYO_NAME, ")            '2016/12/22 add H.Mori 2016改善開発 No4-6
            strSQL.Append("KOK.HOKBN, ")                  '2016/12/22 add H.Mori 2016改善開発 No4-6
            strSQL.Append("KOK.YOTOKBN, ")                '2016/12/12 add H.Mori 2016改善開発 No4-6
            strSQL.Append("KOK.HANBCD, ")                 '2016/12/12 add H.Mori 2016改善開発 No4-6
            strSQL.Append("KOK.SHUGOU, ")                 '2017/10/16 H.Mori add 2017改善開発 No4-1
            strSQL.Append("CLI.KEN_NAME, ")
            strSQL.Append("JAS.JA_CD, ")
            strSQL.Append("JAS.JA_NAME, ")
            strSQL.Append("JAS.JAS_NAME, ")
            strSQL.Append("PU1.NAME AS METASYU_NAI, ")
            strSQL.Append("PU2.NAME AS UNYO_NAI, ")
            strSQL.Append("'2' AS HATKBN, ")            '発生区分[2:緊急警報]
            strSQL.Append("PU3.NAME AS HATKBN_NAI, ")
            strSQL.Append("'1' AS SDSKBN, ")            '出動会社処理区分[1:未処理] '2008/10/17 T.Watabe add
            'strSQL.Append("KEI.KMYMD  AS NCUHATYMD, ")  '発生日   '2008/10/15 T.Watabe add
            'strSQL.Append("KEI.KMTIME AS NCUHATTIME ")  '発生時刻 '2008/10/15 T.Watabe add
            strSQL.Append("NVL(KEI.NCUHATYMD,  KEI.KMYMD)  AS NCUHATYMD, ")  '[警報]NCU警報発生日   '2009/03/23 T.Watabe edit
            strSQL.Append("NVL(KEI.NCUHATTIME, KEI.KMTIME) AS NCUHATTIME ")  '[警報]NCU警報発生時刻 '2009/03/23 T.Watabe edit
            strSQL.Append(",KOK.TUSIN ")                'テレコン.通信モード 2008/10/24 T.Watabe add
            ' ▼▼▼ 2013/08/07 T.Ono mod 顧客単位登録機能追加 ▼▼▼
            ''2011.11.28 ADD H.Uema *------------------------------------------* START
            'strSQL.Append(",NVL(TA1.FAXKURAKBN, ")
            'strSQL.Append("    NVL( ")
            'strSQL.Append("      (SELECT T.FAXKURAKBN ")
            'strSQL.Append("       FROM M05_TANTO T ")
            'strSQL.Append("       WHERE '3' = T.KBN ")
            'strSQL.Append("         AND JAS.CLI_CD = T.KURACD ")
            'strSQL.Append("         AND TRIM(T.FAXKURAKBN) IS NOT NULL ")
            'strSQL.Append("         AND '01' = T.TANCD ")
            'strSQL.Append("         AND T.CODE = JAS.JA_CD), ")
            'strSQL.Append("     '0' ")
            'strSQL.Append("     ) ")
            'strSQL.Append(") AS FAXKURAKBN ")
            'strSQL.Append(",NVL(TA2.GUIDELINE, ")
            'strSQL.Append("    NVL( ")
            'strSQL.Append("      (SELECT T.GUIDELINE ")
            'strSQL.Append("       FROM M05_TANTO T ")
            'strSQL.Append("       WHERE '3' = T.KBN ")
            'strSQL.Append("         AND JAS.CLI_CD = T.KURACD ")
            'strSQL.Append("         AND TRIM(T.GUIDELINE) IS NOT NULL ")
            'strSQL.Append("         AND '01' = T.TANCD ")
            'strSQL.Append("         AND T.CODE = JAS.JA_CD), ")
            'strSQL.Append("     ' ' ")
            'strSQL.Append("     ) ")
            'strSQL.Append(") AS GUIDELINE ")
            ''2011.11.28 ADD H.Uema *------------------------------------------* END
            ''2011.12.01 ADD H.Uema *------------------------------------------* START
            'strSQL.Append(",NVL(TA3.FAXKBN, ")
            'strSQL.Append("    NVL( ")
            'strSQL.Append("      (SELECT T.FAXKBN ")
            'strSQL.Append("       FROM M05_TANTO T ")
            'strSQL.Append("       WHERE '3' = T.KBN ")
            'strSQL.Append("         AND JAS.CLI_CD = T.KURACD ")
            'strSQL.Append("         AND TRIM(T.FAXKBN) IS NOT NULL ")
            'strSQL.Append("         AND '01' = T.TANCD ")
            'strSQL.Append("         AND T.CODE = JAS.JA_CD), ")
            'strSQL.Append("     '0' ")
            'strSQL.Append("     ) ")
            'strSQL.Append(") AS FAXKBN ")
            ''2011.12.01 ADD H.Uema *------------------------------------------* END
            strSQL.Append(", ")
            strSQL.Append("'" & strPar(0) & "' AS FAXKBN, ")
            strSQL.Append("'" & strPar(1) & "' AS FAXKURAKBN, ")
            strSQL.Append("'" & strPar(2) & "' AS GUIDELINE ")
            strSQL.Append(",'" & strPar(3) & "' AS GUIDELINE2 ")  '2019/11/01 W.GANEKO 2019監視改善 No8-12
            strSQL.Append(",'" & strPar(4) & "' AS GUIDELINE3 ")  '2019/11/01 W.GANEKO 2019監視改善 No8-12
            ' ▲▲▲ 2013/08/07 T.Ono del 顧客単位登録機能追加 ▲▲▲
            strSQL.Append(", '" & strKAITU_DAY & "' AS KAITU_DAY ")  '本日工事状況　2013/08/23 T.Ono add 監視改善2013№1 
            strSQL.Append(",NVL(H3.GROUPCD, NVL(H2.GROUPCD, NVL(H1.GROUPCD, ''))) AS HANJICD ") '販売事業者コード　2014/12/16 T.Ono add 2014改善開発 No2
            strSQL.Append(",NVL2(H3.GROUPCD, H3.HANJIGYOSYANM, NVL2(H2.GROUPCD, H2.HANJIGYOSYANM ,NVL2(H1.GROUPCD, H1.HANJIGYOSYANM,''))) AS HANJINM ") '販売事業者名　2014/12/16 T.Ono add 2014改善開発 No2
            strSQL.Append("FROM T10_KEIHO KEI, ")
            strSQL.Append("     SHAMAS KOK, ")
            strSQL.Append("     CLIMAS CLI, ")
            strSQL.Append("     HN2MAS JAS, ")
            strSQL.Append("     M06_PULLDOWN PU1, ")
            strSQL.Append("     M06_PULLDOWN PU2, ")
            strSQL.Append("     M06_PULLDOWN PU3  ")
            '2014/12/16 T.Ono add 2014改善開発 No2 START
            strSQL.Append("     ,M09_JAGROUP G1 ")      'JA単位
            strSQL.Append("     ,M10_HANJIGYOSYA H1 ")
            strSQL.Append("     ,M09_JAGROUP G2 ")      'ユーザー範囲
            strSQL.Append("     ,M10_HANJIGYOSYA H2 ")
            strSQL.Append("     ,M09_JAGROUP G3 ")      'ユーザー個別
            strSQL.Append("     ,M10_HANJIGYOSYA H3 ")
            '2014/12/16 T.Ono add 2014改善開発 No2 END
            ' ▼▼▼ 2013/08/07 T.Ono del 顧客単位登録機能追加 ▼▼▼
            ''2011.11.28 ADD H.Uema *------------------------------------------* START
            'strSQL.Append("     ,M05_TANTO TA1 ") 'FAX不要(ｸﾗｲｱﾝﾄ)フラグ取得
            'strSQL.Append("     ,M05_TANTO TA2 ") 'JA注意事項取得
            ''2011.11.28 ADD H.Uema *------------------------------------------* END
            ''2011.12.01 ADD H.Uema *------------------------------------------* START
            'strSQL.Append("     ,M05_TANTO TA3 ") 'FAX不要(JA)フラグ取得
            ''2011.12.01 ADD H.Uema *------------------------------------------* END
            ' ▲▲▲ 2013/08/07 T.Ono del 顧客単位登録機能追加 ▲▲▲
            strSQL.Append("WHERE KEI.SYORI_SERIAL = :SYORI_SERIAL ")
            strSQL.Append("  AND KEI.KURACD = KOK.CLI_CD(+) ")
            strSQL.Append("  AND KEI.ACBCD  = KOK.HAN_CD(+) ")
            strSQL.Append("  AND KEI.JUYOKA = KOK.USER_CD(+) ")
            strSQL.Append("  AND KEI.KURACD = CLI.CLI_CD(+) ")
            strSQL.Append("  AND KEI.KURACD = JAS.CLI_CD(+) ")
            strSQL.Append("  AND KEI.ACBCD  = JAS.HAN_CD(+) ")
            strSQL.Append("  AND '06' = PU1.KBN(+) ")               'メータ種別
            strSQL.Append("  AND KEI.META_SYUBETU = PU1.CD(+) ")
            strSQL.Append("  AND '04' = PU2.KBN(+) ")               'お客様フラグ
            strSQL.Append("  AND KEI.OKYAKU_FLG = PU2.CD(+) ")
            strSQL.Append("  AND '08' = PU3.KBN(+) ")               '発生区分[2:緊急警報]
            strSQL.Append("  AND '2' = PU3.CD(+) ")
            '販売事業者名の取得　2014/12/16 T.Ono add 2014改善開発 No2 START
            'JA支所単位
            strSQL.Append("  AND G1.KBN(+) = '001' ")
            strSQL.Append("  AND G1.KURACD(+) = KEI.KURACD ")
            strSQL.Append("  AND G1.ACBCD(+) = KEI.ACBCD ")
            strSQL.Append("  AND G1.USERCD_FROM(+) IS NULL ")
            strSQL.Append("  AND G1.USERCD_TO(+) IS NULL ")
            strSQL.Append("  AND G1.GROUPCD = H1.GROUPCD(+) ")
            'ユーザー範囲
            strSQL.Append("  AND G2.KBN(+) = '001' ")
            strSQL.Append("  AND G2.KURACD(+) = KEI.KURACD ")
            strSQL.Append("  AND G2.ACBCD(+) = KEI.ACBCD ")
            strSQL.Append("  AND KEI.JUYOKA BETWEEN G2.USERCD_FROM(+) AND G2.USERCD_TO(+) ")
            strSQL.Append("  AND G2.USERCD_TO(+) IS NOT NULL ")
            strSQL.Append("  AND G2.GROUPCD = H2.GROUPCD(+) ")
            'ユーザー個別
            strSQL.Append("  AND G3.KBN(+) = '001' ")
            strSQL.Append("  AND G3.KURACD(+) = KEI.KURACD ")
            strSQL.Append("  AND G3.ACBCD(+) = KEI.ACBCD ")
            strSQL.Append("  AND G3.USERCD_FROM(+) = KEI.JUYOKA ")
            strSQL.Append("  AND G3.USERCD_TO(+) IS NULL ")
            strSQL.Append("  AND G3.GROUPCD = H3.GROUPCD(+) ")
            '2014/12/16 T.Ono add 2014改善開発 No2 END
            ' ▼▼▼ 2013/08/07 T.Ono del 顧客単位登録機能追加 ▼▼▼
            ''2011.11.28 ADD H.Uema *------------------------------------------* START
            'strSQL.Append("  AND '3' = TA1.KBN(+) ")
            'strSQL.Append("  AND KEI.KURACD = TA1.KURACD(+) ")
            'strSQL.Append("  AND TA1.FAXKURAKBN(+) IS NOT NULL ")
            'strSQL.Append("  AND TA1.CODE(+) = KEI.ACBCD ")
            'strSQL.Append("  AND '01' = TA1.TANCD(+) ")
            'strSQL.Append("  AND '3' = TA2.KBN(+) ")
            'strSQL.Append("  AND KEI.KURACD = TA2.KURACD(+) ")
            'strSQL.Append("  AND TA2.GUIDELINE(+) IS NOT NULL ")
            'strSQL.Append("  AND TA2.CODE(+) = KEI.ACBCD ")
            'strSQL.Append("  AND '01' = TA2.TANCD(+) ")
            ''2011.11.28 ADD H.Uema *------------------------------------------* END
            ''2011.12.01 ADD H.Uema *------------------------------------------* START
            'strSQL.Append("  AND '3' = TA3.KBN(+) ")
            'strSQL.Append("  AND KEI.KURACD = TA3.KURACD(+) ")
            'strSQL.Append("  AND TA3.FAXKBN(+) IS NOT NULL ")
            'strSQL.Append("  AND TA3.CODE(+) = KEI.ACBCD ")
            'strSQL.Append("  AND '01' = TA3.TANCD(+) ")
            ''2011.12.01 ADD H.Uema *------------------------------------------* END
            ' ▲▲▲ 2013/08/07 T.Ono del 顧客単位登録機能追加 ▲▲▲

            'パラメータのセット
            SqlParamC.fncSetParam("SYORI_SERIAL", True, hdnKEY_SERIAL.Value)

            '//SQLの実行
            dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

            If Convert.ToInt32(dbData.Tables(0).Rows.Count) = 0 Then
                strMsg.Append("alert('対象データが存在しません');")
                strRec = "ERROR"
            Else
                '//データを出力します
                Call fncDataSet(dbData, "KEIHOU")
                strRec = "OK"
            End If

        Catch ex As Exception
            Dim ErrMsgC As New CErrMsg
            strMsg.Append("alert('システムエラー：" & ErrMsgC.mGetArtMsg(ex.ToString) & "');")
            strRec = "ERROR"

            '--- ↓2005/04/22 MOD Falcon↓ ---
        Finally
            If dbData Is Nothing Then
            Else
                dbData.Dispose()
            End If
            '--- ↑2005/04/22 MOD Falcon↑ ---
        End Try

        '--- ↓2005/04/22 DEL Falcon↓ ---
        'dbData.Dispose()
        '--- ↑2005/04/22 DEL Falcon↑ ---
        mlog("[KETAIJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- fncSetData_KEIHOU end")

        Return strRec
    End Function

    '******************************************************************************
    ' 顧客検索画面からの遷移時の画面出力
    '******************************************************************************
    Private Function fncSetData_KOKYAKU() As String
        Dim SQLC As New KETAIJAG00CSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet

        Dim strRec As String
        'Dim strPar(2) As String ' FAXKBN,FAXKURAKBN,GUIDELINE格納用　2013/08/07 T.Ono add  '2019/11/01 W.GANEKO 2019監視改善 No8-12
        Dim strPar(4) As String ' FAXKBN,FAXKURAKBN,GUIDELINE,GUIDELINE2,GUIDELINE3 格納用　2019/11/01 W.GANEKO 2019監視改善 No8-12 
        Dim strKAITU_DAY As String  ' 本日工事状況　2013/08/23 T.Ono add 監視改善2013№1

        Try
            ' 2013/08/07 T.Ono add FAXKBN,FAXKURAKBN,GUIDELINEはとり方が他と違うため、先に取得
            mlog("[KETAIJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- fncSetData_KOKYAKU start")
            strPar = fncGetFAXKBN_GUIDE_KOKYAKU()
            strKAITU_DAY = fncGetKAITU_DAY_KOKYAKU()

            '//顧客検索からの画面遷移の場合
            strSQL = New StringBuilder("")
            strSQL.Append("SELECT ")
            strSQL.Append("TO_CHAR(SYSDATE,'YYYYMMDD') AS KMYMD, ") '受信日
            strSQL.Append("TO_CHAR(SYSDATE,'HH24MI') AS KMTIME, ") '受信時刻
            strSQL.Append("KOK.CLI_CD, ")
            strSQL.Append("KOK.HAN_CD AS ACBCD, ")
            strSQL.Append("KOK.USER_CD AS JUYOKA_CD, ")
            strSQL.Append("KOK.NAME AS JUYONM, ")
            strSQL.Append("KOK.KANA, ")
            strSQL.Append("KOK.USER_FLG AS UNYOCD, ")
            'strSQL.Append("KOK.ADD_1 || KOK.ADD_2 || KOK.ADD_3 AS ADDR, ")
            strSQL.Append("KOK.ADD_1 || ' ' || KOK.ADD_2 || ' ' || KOK.ADD_3 AS ADDR, ") ' 2008/10/29 T.Watabe edit
            '2005/07/29 NEC UPDATE START
            'strSQL.Append("KOK.NCU_TELA AS JUTEL1, ")                   '顧客：ＮＣＵ電話番号市外
            'strSQL.Append("KOK.NCU_TELB AS JUTEL2, ")                   '顧客：ＮＣＵ電話番号市内
            '2006/05/23 NEC UPDATE START
            'strSQL.Append("KOK.TELA AS JUTEL1, ")                   '顧客：ＮＣＵ電話番号市外
            'strSQL.Append("KOK.TELB AS JUTEL2, ")                   '顧客：ＮＣＵ電話番号市内
            strSQL.Append("KOK.NCU_TELA AS JUTEL1, ")                   '顧客：ＮＣＵ電話番号市外
            strSQL.Append("KOK.NCU_TELB AS JUTEL2, ")                   '顧客：ＮＣＵ電話番号市内
            '2006/05/23 NEC UPDATE END
            '2005/07/29 NEC UPDATE END
            '2006/06/06 NEC UPDATE START
            'strSQL.Append("KOK.REN_TELA || KOK.REN_TELB AS RENTEL, ")   '顧客：連絡電話番号
            strSQL.Append("KOK.KANKENSAKU_TEL AS RENTEL, ")   '顧客：連絡電話番号
            '2005/06/06 NEC UPDATE END
            strSQL.Append("KOK.KANKENSAKU_TEL AS KTELNO, ")             '顧客：検索用電話番号
            strSQL.Append("KOK.USR_MEMO, ")
            strSQL.Append("KOK.USR_MEMO AS GENIN_KIJI, ")
            strSQL.Append("KOK.NCU_CON, ")
            strSQL.Append("KOK.HANBAI_KBN, ") '2015/11/25 H.Mori add 2015改善開発 No1
            strSQL.Append("KOK.KYOKTKBN, ") '2016/12/02 H.Mori add 2016改善開発 No4-3
            strSQL.Append("KOK.SETSUBI, ")
            strSQL.Append("KOK.KYOKYU_MK, ")
            strSQL.Append("KOK.MAP_CD, ")
            strSQL.Append("KOK.BOMB_TYPE, ")
            strSQL.Append("KOK.BOMB_YOUKI1, ")
            strSQL.Append("KOK.BOMB_SUU1, ")
            strSQL.Append("KOK.YOBI_FLG1 AS BOMB_RYO1, ")
            strSQL.Append("KOK.BOMB_YOUKI2, ")
            strSQL.Append("KOK.BOMB_SUU2, ")
            strSQL.Append("KOK.YOBI_FLG2 AS BOMB_RYO2, ")
            strSQL.Append("KOK.BOMB_YOUKI3, ")
            strSQL.Append("KOK.BOMB_SUU3, ")
            strSQL.Append("KOK.YOBI_FLG3 AS BOMB_RYO3, ")
            strSQL.Append("KOK.BOMB_YOUKI4, ")
            strSQL.Append("KOK.BOMB_SUU4, ")
            strSQL.Append("KOK.YOBI_FLG4 AS BOMB_RYO4, ")
            strSQL.Append("KOK.SIYOU3, ")
            strSQL.Append("KOK.SIYOU4, ")
            strSQL.Append("KOK.BOMV_HAISO1, ")
            strSQL.Append("KOK.BOMV_SISIN1, ")
            strSQL.Append("KOK.BOMV_HAISO2, ")
            strSQL.Append("KOK.BOMV_SISIN2, ")
            strSQL.Append("KOK.HAISO_YOTEI, ")
            strSQL.Append("KOK.BOMB_DATE1, ")
            strSQL.Append("KOK.BOMB_SISIN1, ")
            strSQL.Append("KOK.BOMB_DATE2, ")
            strSQL.Append("KOK.BOMB_SISIN2, ")
            strSQL.Append("KOK.KENSIN_DAY1, ")
            strSQL.Append("KOK.KENSINTI1, ")
            strSQL.Append("KOK.KENSIN_DAY2, ")
            strSQL.Append("KOK.KENSINTI2, ")
            strSQL.Append("KOK.SIYOU1, ")
            strSQL.Append("KOK.SIYOU2, ")
            strSQL.Append("KOK.GAS_NAME1, ")
            strSQL.Append("KOK.GAS_NAME2, ")
            strSQL.Append("KOK.GAS_NAME3, ")
            strSQL.Append("KOK.GAS_NAME4, ")
            strSQL.Append("KOK.GAS_NAME5, ")
            strSQL.Append("KOK.GAS_SUU1, ")
            strSQL.Append("KOK.GAS_SUU2, ")
            strSQL.Append("KOK.GAS_SUU3, ")
            strSQL.Append("KOK.GAS_SUU4, ")
            strSQL.Append("KOK.GAS_SUU5, ")
            strSQL.Append("KOK.GAS_SEIF1, ")
            strSQL.Append("KOK.GAS_SEIF2, ")
            strSQL.Append("KOK.GAS_SEIF3, ")
            strSQL.Append("KOK.GAS_SEIF4, ")
            strSQL.Append("KOK.GAS_SEIF5, ")
            strSQL.Append("KOK.GAS_STOP AS GAS_START, ")
            strSQL.Append("KOK.GAS_DELE, ")
            strSQL.Append("KOK.GAS_RESTART, ")
            strSQL.Append("KOK.KANSHI_BIKO, ")            '2016/02/02 w.ganeko 2015改善開発 №1-3
            strSQL.Append("KOK.RENTEL2, ")                '2016/02/02 w.ganeko 2015改善開発 №1-3
            strSQL.Append("KOK.RENTEL2_BIKO, ")           '2016/02/02 w.ganeko 2015改善開発 №1-3
            strSQL.Append("KOK.RENTEL2_UPD_DATE, ")       '2016/02/02 w.ganeko 2015改善開発 №1-3
            strSQL.Append("KOK.RENTEL3, ")                '2016/02/02 w.ganeko 2015改善開発 №1-3
            strSQL.Append("KOK.RENTEL3_BIKO, ")           '2016/02/02 w.ganeko 2015改善開発 №1-3
            strSQL.Append("KOK.RENTEL3_UPD_DATE, ")       '2016/02/02 w.ganeko 2015改善開発 №1-3
            strSQL.Append("KOK.TELA || TELB TELAB, ")     '2016/12/12 add H.Mori 2016改善開発 No5-1
            strSQL.Append("KOK.DAI3RENDORENTEL, ")        '2016/12/12 add H.Mori 2016改善開発 No5-1
            strSQL.Append("KOK.DAIHYO_NAME, ")            '2016/12/22 add H.Mori 2016改善開発 No4-6
            strSQL.Append("KOK.HOKBN, ")                  '2016/12/22 add H.Mori 2016改善開発 No4-6
            strSQL.Append("KOK.YOTOKBN, ")                '2016/12/12 add H.Mori 2016改善開発 No4-6
            strSQL.Append("KOK.HANBCD, ")                 '2016/12/12 add H.Mori 2016改善開発 No4-6
            strSQL.Append("KOK.SHUGOU, ")                 '2017/10/16 H.Mori add 2017改善開発 No4-1
            strSQL.Append("CLI.KANSI_CODE AS KANSCD, ")
            strSQL.Append("CLI.KEN_NAME, ")
            strSQL.Append("JAS.JA_CD, ")
            strSQL.Append("JAS.JA_NAME, ")
            strSQL.Append("JAS.JAS_NAME, ")
            strSQL.Append("PU2.NAME AS UNYO_NAI, ")
            strSQL.Append("'1' AS HATKBN, ")                            '発生区分[1:電話]
            strSQL.Append("PU3.NAME AS HATKBN_NAI, ")
            strSQL.Append("'1' AS SDSKBN, ")                            '出動会社処理区分[1:未処理] '2008/10/17 T.Watabe add
            strSQL.Append("TO_CHAR(SYSDATE,'YYYYMMDD') AS NCUHATYMD, ") '発生日 '2008/10/15 T.Watabe add
            strSQL.Append("TO_CHAR(SYSDATE,'HH24MI') AS NCUHATTIME ")   '発生時刻 '2008/10/15 T.Watabe add
            strSQL.Append(",KOK.TUSIN ")                                'テレコン.通信モード 2008/10/24 T.Watabe add
            ' ▼▼▼ 2013/08/07 T.Ono mod 顧客単位登録機能追加 ▼▼▼
            ''2011.11.28 ADD H.Uema *------------------------------------------* START
            'strSQL.Append(",NVL(TRIM(TA1.FAXKURAKBN), ")
            'strSQL.Append("    NVL( ")
            'strSQL.Append("      (SELECT TRIM(T.FAXKURAKBN) ")
            'strSQL.Append("       FROM M05_TANTO T ")
            'strSQL.Append("       WHERE '3' = T.KBN ")
            'strSQL.Append("         AND JAS.CLI_CD = T.KURACD ")
            'strSQL.Append("         AND TRIM(T.FAXKURAKBN) IS NOT NULL ")
            'strSQL.Append("         AND '01' = T.TANCD ")
            'strSQL.Append("         AND T.CODE = JAS.JA_CD), ")
            'strSQL.Append("     '0' ")
            'strSQL.Append("     ) ")
            'strSQL.Append(") AS FAXKURAKBN ")
            'strSQL.Append(",NVL(TA2.GUIDELINE, ")
            'strSQL.Append("    NVL( ")
            'strSQL.Append("      (SELECT T.GUIDELINE ")
            'strSQL.Append("       FROM M05_TANTO T ")
            'strSQL.Append("       WHERE '3' = T.KBN ")
            'strSQL.Append("         AND JAS.CLI_CD = T.KURACD ")
            'strSQL.Append("         AND TRIM(T.GUIDELINE) IS NOT NULL ")
            'strSQL.Append("         AND '01' = T.TANCD ")
            'strSQL.Append("         AND T.CODE = JAS.JA_CD), ")
            'strSQL.Append("     ' ' ")
            'strSQL.Append("     ) ")
            'strSQL.Append(") AS GUIDELINE ")
            ''2011.11.28 ADD H.Uema *------------------------------------------* END
            ''2011.12.01 ADD H.Uema *------------------------------------------* START
            'strSQL.Append(",NVL(TRIM(TA3.FAXKBN), ")
            'strSQL.Append("    NVL( ")
            'strSQL.Append("      (SELECT TRIM(T.FAXKBN) ")
            'strSQL.Append("       FROM M05_TANTO T ")
            'strSQL.Append("       WHERE '3' = T.KBN ")
            'strSQL.Append("         AND JAS.CLI_CD = T.KURACD ")
            'strSQL.Append("         AND TRIM(T.FAXKBN) IS NOT NULL ")
            'strSQL.Append("         AND '01' = T.TANCD ")
            'strSQL.Append("         AND T.CODE = JAS.JA_CD), ")
            'strSQL.Append("     '0' ")
            'strSQL.Append("     ) ")
            'strSQL.Append(") AS FAXKBN ")
            ''2011.12.01 ADD H.Uema *------------------------------------------* END
            strSQL.Append(", ")
            strSQL.Append("'" & strPar(0) & "' AS FAXKBN, ")
            strSQL.Append("'" & strPar(1) & "' AS FAXKURAKBN, ")
            strSQL.Append("'" & strPar(2) & "' AS GUIDELINE ")
            strSQL.Append(",'" & strPar(3) & "' AS GUIDELINE2 ")   '2019/11/01 W.GANEKO 2019監視改善 No8-12
            strSQL.Append(",'" & strPar(4) & "' AS GUIDELINE3 ")   '2019/11/01 W.GANEKO 2019監視改善 No8-12
            ' ▲▲▲ 2013/08/07 T.Ono mod 顧客単位登録機能追加 ▲▲▲
            strSQL.Append(", '" & strKAITU_DAY & "' AS KAITU_DAY ") ' 本日工事状況 2013/08/23 T.Ono add 監視改善2013№1
            strSQL.Append(",NVL(H3.GROUPCD, NVL(H2.GROUPCD, NVL(H1.GROUPCD, ''))) AS HANJICD ") '販売事業者コード2014/12/17 T.Ono add 2014改善開発 No2
            strSQL.Append(",NVL2(H3.GROUPCD, H3.HANJIGYOSYANM, NVL2(H2.GROUPCD, H2.HANJIGYOSYANM ,NVL2(H1.GROUPCD, H1.HANJIGYOSYANM,''))) AS HANJINM ") '販売事業者コード2014/12/17 T.Ono add 2014改善開発 No2
            strSQL.Append("FROM SHAMAS KOK, ")
            strSQL.Append("     CLIMAS CLI, ")
            strSQL.Append("     HN2MAS JAS, ")
            'strSQL.Append("     M06_PULLDOWN PU1, ")   ' 2013/06/27 T.ono del 使用していないようなので削除
            strSQL.Append("     M06_PULLDOWN PU2, ")
            strSQL.Append("     M06_PULLDOWN PU3  ")
            '2014/12/17 T.Ono add 2014改善開発 No2 START
            strSQL.Append("     ,M09_JAGROUP G1 ")
            strSQL.Append("     ,M10_HANJIGYOSYA H1 ")
            strSQL.Append("     ,M09_JAGROUP G2 ")
            strSQL.Append("     ,M10_HANJIGYOSYA H2 ")
            strSQL.Append("     ,M09_JAGROUP G3 ")
            strSQL.Append("     ,M10_HANJIGYOSYA H3 ")
            '2014/12/17 T.Ono add 2014改善開発 No2 END
            ' ▼▼▼ 2013/08/07 T.Ono del 顧客単位登録機能追加 ▼▼▼
            '2011.11.28 ADD H.Uema *------------------------------------------* START
            'strSQL.Append("     ,M05_TANTO TA1 ") 'FAX不要(ｸﾗｲｱﾝﾄ)フラグ取得
            'strSQL.Append("     ,M05_TANTO TA2 ") 'JA注意事項取得
            ''2011.11.28 ADD H.Uema *------------------------------------------* END
            ''2011.12.01 ADD H.Uema *------------------------------------------* START
            'strSQL.Append("     ,M05_TANTO TA3 ") 'FAX不要(JA)フラグ取得
            ''2011.12.01 ADD H.Uema *------------------------------------------* END
            ' ▲▲▲ 2013/08/07 T.Ono del 顧客単位登録機能追加 ▲▲▲
            strSQL.Append("WHERE KOK.CLI_CD  = :CLI_CD ")
            strSQL.Append("  AND KOK.HAN_CD  = :HAN_CD ")
            strSQL.Append("  AND KOK.USER_CD = :USER_CD ")
            strSQL.Append("  AND KOK.CLI_CD = CLI.CLI_CD(+) ")
            strSQL.Append("  AND KOK.CLI_CD = JAS.CLI_CD(+) ")
            strSQL.Append("  AND KOK.HAN_CD = JAS.HAN_CD(+) ")
            strSQL.Append("  AND '04' = PU2.KBN(+) ")
            strSQL.Append("  AND KOK.USER_FLG = PU2.CD(+) ")
            strSQL.Append("  AND '08' = PU3.KBN(+) ")           '発生区分[1:電話]
            strSQL.Append("  AND '1' = PU3.CD(+) ")
            ' ▼▼▼ 2013/08/07 T.Ono del 顧客単位登録機能追加 ▼▼▼
            ''2011.11.28 ADD H.Uema *------------------------------------------* START
            'strSQL.Append("  AND '3' = TA1.KBN(+) ")
            'strSQL.Append("  AND KOK.CLI_CD = TA1.KURACD(+) ")
            'strSQL.Append("  AND TA1.FAXKURAKBN(+) IS NOT NULL ")
            'strSQL.Append("  AND TA1.CODE(+) = KOK.HAN_CD ")
            'strSQL.Append("  AND '01' = TA1.TANCD(+) ")
            'strSQL.Append("  AND '3' = TA2.KBN(+) ")
            'strSQL.Append("  AND KOK.CLI_CD = TA2.KURACD(+) ")
            'strSQL.Append("  AND TA2.GUIDELINE(+) IS NOT NULL ")
            'strSQL.Append("  AND TA2.CODE(+) = KOK.HAN_CD ")
            'strSQL.Append("  AND '01' = TA2.TANCD(+) ")
            ''2011.11.28 ADD H.Uema *------------------------------------------* END
            ''2011.12.01 ADD H.Uema *------------------------------------------* START
            'strSQL.Append("  AND '3' = TA3.KBN(+) ")
            'strSQL.Append("  AND KOK.CLI_CD = TA3.KURACD(+) ")
            'strSQL.Append("  AND TA3.FAXKBN(+) IS NOT NULL ")
            'strSQL.Append("  AND TA3.CODE(+) = KOK.HAN_CD ")
            'strSQL.Append("  AND '01' = TA3.TANCD(+) ")
            ''2011.12.01 ADD H.Uema *------------------------------------------* END
            ' ▲▲▲ 2013/08/07 T.Ono del 顧客単位登録機能追加 ▲▲▲
            '販売事業者名の取得　2014/12/16 T.Ono add 2014改善開発 No2 START
            'JA支所
            strSQL.Append("  AND G1.KBN(+) = '001' ")
            strSQL.Append("  AND G1.KURACD(+) = KOK.CLI_CD ")
            strSQL.Append("  AND G1.ACBCD(+) = KOK.HAN_CD ")
            strSQL.Append("  AND G1.USERCD_FROM(+) IS NULL ")
            strSQL.Append("  AND G1.USERCD_TO(+) IS NULL ")
            strSQL.Append("  AND G1.GROUPCD = H1.GROUPCD(+) ")
            'ユーザー範囲
            strSQL.Append("  AND G2.KBN(+) = '001' ")
            strSQL.Append("  AND G2.KURACD(+) = KOK.CLI_CD ")
            strSQL.Append("  AND G2.ACBCD(+) = KOK.HAN_CD ")
            strSQL.Append("  AND KOK.USER_CD BETWEEN G2.USERCD_FROM(+) AND G2.USERCD_TO(+) ")
            strSQL.Append("  AND G2.USERCD_TO(+) IS NOT NULL ")
            strSQL.Append("  AND G2.GROUPCD = H2.GROUPCD(+) ")
            'ユーザー個別
            strSQL.Append("  AND G3.KBN(+) = '001' ")
            strSQL.Append("  AND G3.KURACD(+) = KOK.CLI_CD ")
            strSQL.Append("  AND G3.ACBCD(+) = KOK.HAN_CD ")
            strSQL.Append("  AND G3.USERCD_FROM(+) = KOK.USER_CD ")
            strSQL.Append("  AND G3.USERCD_TO(+) IS NULL ")
            strSQL.Append("  AND G3.GROUPCD = H3.GROUPCD(+) ")
            '2014/12/16 T.Ono add 2014改善開発 No2 END

            'パラメータのセット
            SqlParamC.fncSetParam("CLI_CD", True, hdnKEY_CLI_CD.Value)
            SqlParamC.fncSetParam("USER_CD", True, hdnKEY_USER_CD.Value)

            SqlParamC.fncSetParam("HAN_CD", True, hdnKEY_HAN_CD.Value)
            '//SQLの実行
            dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

            If Convert.ToInt32(dbData.Tables(0).Rows.Count) = 0 Then
                strMsg.Append("alert('対象データが存在しません');")
                strRec = "ERROR"
            Else
                '//データを出力します
                Call fncDataSet(dbData, "KOKYAK")
                strRec = "OK"
            End If

        Catch ex As Exception
            Dim ErrMsgC As New CErrMsg
            strMsg.Append("alert('システムエラー：" & ErrMsgC.mGetArtMsg(ex.ToString) & "');")
            strRec = "ERROR"

            '--- ↓2005/04/22 MOD Falcon↓ ---
        Finally
            If dbData Is Nothing Then
            Else
                dbData.Dispose()
            End If
            '--- ↑2005/04/22 MOD Falcon↑ ---
        End Try

        '--- ↓2005/04/22 DEL Falcon↓ ---
        'dbData.Dispose()
        '--- ↑2005/04/22 DEL Falcon↑ ---
        mlog("[KETAIJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- fncSetData_KOKYAKU end")

        Return strRec
    End Function

    '******************************************************************************
    ' 対応入力変更一覧からの遷移時の画面出力
    '******************************************************************************
    Private Function fncSetData_TAIOU() As String
        Dim SQLC As New KETAIJAG00CSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet

        Dim strRec As String
        'Dim strPar(2) As String ' FAXKBN,FAXKURAKBN,GUIDELINE格納用(ここではGUIDELINのみ使用) 2013/08/07 T.Ono add   '2019/11/01 W.GANEKO 2019監視改善 No8-12
        Dim strPar(4) As String   ' FAXKBN,FAXKURAKBN,GUIDELINE,GUIDELINE2,GUIDELINE3格納用(ここではGUIDELINのみ使用) 2019/11/01 W.GANEKO 2019監視改善 No8-12

        Try
            mlog("[KETAIJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- fncSetData_TAIOU start")
            ' 2013/08/07 T.Ono add FAXKBN,FAXKURAKBN,GUIDELINEはとり方が他と違うため、先に取得
            strPar = fncGetFAXKBN_GUIDE_TAIOU()

            '//対応入力からの画面遷移の場合
            strSQL = New StringBuilder("")
            strSQL.Append("SELECT ")
            strSQL.Append("TAI.KANSCD, ")
            strSQL.Append("TAI.SYONO, ")
            strSQL.Append("TAI.HATYMD AS KMYMD, ")
            strSQL.Append("TAI.HATTIME AS KMTIME, ")
            strSQL.Append("TAI.KENSIN AS KMSIN, ")          '★★★★★メータ値★★★★★
            strSQL.Append("TAI.KEIHOSU, ")
            strSQL.Append("TAI.RYURYO, ")
            strSQL.Append("TAI.METASYU AS METASYU_NAI, ")
            strSQL.Append("TAI.UNYO AS UNYOCD, ")
            strSQL.Append("TAI.JUYMD, ")
            strSQL.Append("TAI.JUTIME, ")
            strSQL.Append("TAI.NUM_DIGIT, ")
            strSQL.Append("TAI.KMCD1, ")
            strSQL.Append("TAI.KMNM1, ")
            strSQL.Append("TAI.KMCD2, ")
            strSQL.Append("TAI.KMNM2, ")
            strSQL.Append("TAI.KMCD3, ")
            strSQL.Append("TAI.KMNM3, ")
            strSQL.Append("TAI.KMCD4, ")
            strSQL.Append("TAI.KMNM4, ")
            strSQL.Append("TAI.KMCD5, ")
            strSQL.Append("TAI.KMNM5, ")
            strSQL.Append("TAI.KMCD6, ")
            strSQL.Append("TAI.KMNM6, ")
            strSQL.Append("TAI.ZSISYO, ")
            strSQL.Append("TAI.KURACD AS CLI_CD, ")
            strSQL.Append("TAI.KENNM AS KEN_NAME, ")
            strSQL.Append("TAI.JACD AS JA_CD, ")
            strSQL.Append("TAI.JANM AS JA_NAME, ")
            strSQL.Append("TAI.ACBCD, ")
            strSQL.Append("TAI.ACBNM AS JAS_NAME, ")
            strSQL.Append("TAI.USER_CD AS JUYOKA_CD, ")
            strSQL.Append("TAI.JUSYONM AS JUYONM, ")
            strSQL.Append("TAI.JUSYOKN AS KANA, ")
            strSQL.Append("TAI.JUTEL1, ")
            strSQL.Append("TAI.JUTEL2, ")
            strSQL.Append("TAI.RENTEL, ")
            strSQL.Append("TAI.KTELNO, ")
            strSQL.Append("TAI.ADDR, ")
            strSQL.Append("TAI.USER_KIJI AS USR_MEMO, ")
            strSQL.Append("TAI.NCU_SET AS NCU_CON, ")
            strSQL.Append("TAI.TIZUNO AS MAP_CD, ")
            strSQL.Append("TAI.BOMB_TYPE AS BOMB_TYPE, ")           '★★★★★交換区分★★★★★
            strSQL.Append("TAI.HANBAI_KBN, ") '2015/11/25 H.Mori add 2015改善開発 No1   ★販売区分★
            strSQL.Append("TAI.KYOKTKBN, ") '2016/12/02 H.Mori add 2016改善開発 No4-3   ★供給形態区分★
            strSQL.Append("TAI.MET_KATA AS SETSUBI, ")
            strSQL.Append("TAI.MET_MAKER AS KYOKYU_MK, ")
            strSQL.Append("TAI.BONB1_KKG AS BOMB_YOUKI1, ")
            strSQL.Append("TAI.BONB1_HON AS BOMB_SUU1, ")
            strSQL.Append("TAI.BONB1_YOBI AS BOMB_RYO1, ")
            strSQL.Append("TAI.BONB2_KKG AS BOMB_YOUKI2, ")
            strSQL.Append("TAI.BONB2_HON AS BOMB_SUU2, ")
            strSQL.Append("TAI.BONB2_YOBI AS BOMB_RYO2, ")
            strSQL.Append("TAI.BONB3_KKG AS BOMB_YOUKI3, ")
            strSQL.Append("TAI.BONB3_HON AS BOMB_SUU3, ")
            strSQL.Append("TAI.BONB3_YOBI AS BOMB_RYO3, ")
            strSQL.Append("TAI.BONB4_KKG AS BOMB_YOUKI4, ")
            strSQL.Append("TAI.BONB4_HON AS BOMB_SUU4, ")
            strSQL.Append("TAI.BONB4_YOBI AS BOMB_RYO4, ")
            strSQL.Append("TAI.ZENKAI_HAISO AS BOMV_HAISO1, ")
            strSQL.Append("TAI.ZENKAI_HAI_S AS BOMV_SISIN1, ")
            strSQL.Append("TAI.KONKAI_HAISO AS BOMV_HAISO2, ")
            strSQL.Append("TAI.KONKAI_HAI_S AS BOMV_SISIN2, ")
            strSQL.Append("TAI.JIKAI_HAISO AS HAISO_YOTEI, ")
            strSQL.Append("TAI.ZENKAI_KENSIN AS KENSIN_DAY1, ")
            strSQL.Append("TAI.ZENKAI_KEN_S AS KENSINTI1, ")
            strSQL.Append("TAI.ZENKAI_KEN_SIYO AS SIYOU1, ")
            strSQL.Append("TAI.KONKAI_KENSIN AS KENSIN_DAY2, ")
            strSQL.Append("TAI.KONKAI_KEN_S AS KENSINTI2, ")
            strSQL.Append("TAI.KONKAI_KEN_SIYO AS SIYOU2, ")
            strSQL.Append("TAI.ZENKAI_HASEI AS BOMB_DATE1, ")
            strSQL.Append("TAI.ZENKAI_HAS_S AS BOMB_SISIN1, ")
            strSQL.Append("TAI.KONKAI_HASEI AS BOMB_DATE2, ")
            strSQL.Append("TAI.KONKAI_HAS_S AS BOMB_SISIN2, ")
            strSQL.Append("TAI.G_ZAIKO, ")
            strSQL.Append("TAI.ICHI_SIYO AS SIYOU3, ")
            strSQL.Append("TAI.YOSOKU_ICHI_SIYO AS SIYOU4, ")
            strSQL.Append("TAI.GAS1_HINMEI AS GAS_NAME1, ")
            strSQL.Append("TAI.GAS1_DAISU AS GAS_SUU1, ")
            strSQL.Append("TAI.GAS1_SEIFL AS GAS_SEIF1, ")
            strSQL.Append("TAI.GAS2_HINMEI AS GAS_NAME2, ")
            strSQL.Append("TAI.GAS2_DAISU AS GAS_SUU2, ")
            strSQL.Append("TAI.GAS2_SEIFL AS GAS_SEIF2, ")
            strSQL.Append("TAI.GAS3_HINMEI AS GAS_NAME3, ")
            strSQL.Append("TAI.GAS3_DAISU AS GAS_SUU3, ")
            strSQL.Append("TAI.GAS3_SEIFL AS GAS_SEIF3, ")
            strSQL.Append("TAI.GAS4_HINMEI AS GAS_NAME4, ")
            strSQL.Append("TAI.GAS4_DAISU AS GAS_SUU4, ")
            strSQL.Append("TAI.GAS4_SEIFL AS GAS_SEIF4, ")
            strSQL.Append("TAI.GAS5_HINMEI AS GAS_NAME5, ")
            strSQL.Append("TAI.GAS5_DAISU AS GAS_SUU5, ")
            strSQL.Append("TAI.GAS5_SEIFL AS GAS_SEIF5, ")
            strSQL.Append("TAI.GAS_STOP AS GAS_START, ")            '★★★★★ガス供給休止日★★★★★
            strSQL.Append("TAI.GAS_DELE AS GAS_DELE, ")             '★★★★★ガス供給廃止日★★★★★
            strSQL.Append("TAI.GAS_RESTART AS GAS_RESTART, ")       '★★★★★ガス供給復活日★★★★★
            strSQL.Append("TAI.KANSHI_BIKO, ")                      '2016/02/02 w.ganeko 2015改善開発 №1-3
            strSQL.Append("TAI.RENTEL2, ")                          '2016/02/02 w.ganeko 2015改善開発 №1-3
            strSQL.Append("TAI.RENTEL2_BIKO, ")                     '2016/02/02 w.ganeko 2015改善開発 №1-3
            strSQL.Append("TAI.RENTEL2_UPD_DATE, ")                 '2016/02/02 w.ganeko 2015改善開発 №1-3
            strSQL.Append("TAI.RENTEL3, ")                          '2016/02/02 w.ganeko 2015改善開発 №1-3
            strSQL.Append("TAI.RENTEL3_BIKO, ")                     '2016/02/02 w.ganeko 2015改善開発 №1-3
            strSQL.Append("TAI.RENTEL3_UPD_DATE, ")                 '2016/02/02 w.ganeko 2015改善開発 №1-3
            strSQL.Append("TAI.TELAB, ")                            '2016/12/12 add H.Mori 2016改善開発 No5-1
            strSQL.Append("TAI.DAI3RENDORENTEL, ")                  '2016/12/12 add H.Mori 2016改善開発 No5-1
            strSQL.Append("TAI.DAIHYO_NAME, ")                      '2016/12/22 add H.Mori 2016改善開発 No4-6
            strSQL.Append("TAI.HOKBN, ")                            '2016/12/22 add H.Mori 2016改善開発 No4-6
            strSQL.Append("TAI.YOTOKBN, ")                          '2016/12/12 add H.Mori 2016改善開発 No4-6
            strSQL.Append("TAI.HANBCD, ")                           '2016/12/12 add H.Mori 2016改善開発 No4-6
            strSQL.Append("TAI.SHUGOU, ")                 '2017/10/16 H.Mori add 2017改善開発 No4-1
            strSQL.Append("TAI.HATKBN, ")
            strSQL.Append("TAI.HATKBN_NAI, ")
            strSQL.Append("TAI.TAIOKBN, ")
            strSQL.Append("TAI.TAIOKBN_NAI, ")
            strSQL.Append("TAI.TMSKB, ")
            strSQL.Append("TAI.TMSKB_NAI, ")
            strSQL.Append("TAI.TKTANCD, ")
            strSQL.Append("TAI.TKTANCD_NM, ")
            strSQL.Append("TAI.TAITCD, ")
            strSQL.Append("TAI.TAITNM, ")
            strSQL.Append("TAI.TAIO_ST_DATE, ")
            strSQL.Append("TAI.TAIO_ST_TIME, ")
            strSQL.Append("TAI.SYOYMD, ")
            strSQL.Append("TAI.SYOTIME, ")
            strSQL.Append("TAI.TAIO_SYO_TIME, ")
            strSQL.Append("TAI.FAXKBN, ")
            strSQL.Append("TAI.TELRCD, ")
            strSQL.Append("TAI.TELRNM, ")
            strSQL.Append("TAI.TFKICD, ")
            strSQL.Append("TAI.TFKINM, ")
            strSQL.Append("TAI.FUK_MEMO, ")
            strSQL.Append("TAI.TEL_MEMO1, ")
            strSQL.Append("TAI.TEL_MEMO2, ")
            strSQL.Append("TAI.TEL_MEMO4, ")            '2020/11/01 T.Ono add 2020 監視改善
            strSQL.Append("TAI.TEL_MEMO5, ")            '2020/11/01 T.Ono add 2020 監視改善
            strSQL.Append("TAI.TEL_MEMO6, ")            '2020/11/01 T.Ono add 2020 監視改善
            strSQL.Append("TAI.MITOKBN, ")
            strSQL.Append("TAI.TKIGCD, ")
            strSQL.Append("TAI.TKIGNM, ")
            strSQL.Append("TAI.TSADCD, ")
            strSQL.Append("TAI.TSADNM, ")
            strSQL.Append("TAI.GENIN_KIJI, ")
            strSQL.Append("TAI.SDCD, ")
            strSQL.Append("TAI.SDNM, ")
            strSQL.Append("TAI.SIJIYMD, ")
            strSQL.Append("TAI.SIJITIME, ")
            strSQL.Append("TAI.SIJI_BIKO1, ")
            strSQL.Append("TAI.SIJI_BIKO2, ")
            strSQL.Append("TAI.STD_JASCD, ")
            strSQL.Append("TAI.STD_JANA, ")
            strSQL.Append("TAI.STD_JASNA, ")
            strSQL.Append("TAI.REN_NA, ")
            strSQL.Append("TAI.REN_TEL_1, ")
            strSQL.Append("TAI.REN_TEL_2, ")
            strSQL.Append("TAI.REN_FAX, ")
            strSQL.Append("TAI.REN_BIKO, ")
            strSQL.Append("TAI.REN_1_NA, ")
            strSQL.Append("TAI.REN_1_TEL1, ")
            strSQL.Append("TAI.REN_1_TEL2, ")
            strSQL.Append("TAI.REN_1_FAX, ")
            strSQL.Append("TAI.REN_1_BIKO, ")
            strSQL.Append("TAI.REN_2_NA, ")
            strSQL.Append("TAI.REN_2_TEL1, ")
            strSQL.Append("TAI.REN_2_TEL2, ")
            strSQL.Append("TAI.REN_2_FAX, ")
            strSQL.Append("TAI.REN_2_BIKO, ")
            strSQL.Append("TAI.REN_3_NA, ")
            strSQL.Append("TAI.REN_3_TEL1, ")
            strSQL.Append("TAI.REN_3_TEL2, ")
            strSQL.Append("TAI.REN_3_FAX, ")
            strSQL.Append("TAI.REN_3_BIKO, ")
            strSQL.Append("'4' AS REN_4_NA, ") ' 2008/10/31 TEST ADD
            strSQL.Append("'4' AS REN_4_TEL1, ")
            strSQL.Append("'4' AS REN_4_TEL2, ")
            strSQL.Append("'4' AS REN_4_FAX, ")
            strSQL.Append("'4' AS REN_4_BIKO, ")
            strSQL.Append("TAI.FAX_TITLE, ")
            strSQL.Append("TAI.FAX_REN, ")
            strSQL.Append("TAI.STD_CD, ")
            strSQL.Append("TAI.STD, ")
            strSQL.Append("TAI.STD_KYOTEN_CD, ")
            strSQL.Append("TAI.STD_KYOTEN, ")
            strSQL.Append("TAI.STD_TEL, ")
            strSQL.Append("TAI.TEL_BIKO, ")
            strSQL.Append("TAI.ADD_DATE, ")
            strSQL.Append("TAI.EDT_DATE, ")
            strSQL.Append("TAI.EDT_TIME, ")
            '--- ↓2005/09/09 ADD Falcon↓ ---
            strSQL.Append("TAI.BIKOU, ")
            strSQL.Append("TAI.FAX_TITLE_CD, ")
            '--- ↑2005/09/09 ADD Falcon↑ ---
            strSQL.Append("PU2.NAME AS UNYO_NAI, ")
            strSQL.Append("TAI.SDSKBN, ")                   ' 2008/10/17 T.Watabe add
            strSQL.Append("DECODE(TAI.NCUHATYMD,  NULL, TAI.HATYMD,  TAI.NCUHATYMD ) AS NCUHATYMD, ") ' 2008/10/15 T.Watabe add
            strSQL.Append("DECODE(TAI.NCUHATTIME, NULL, TAI.HATTIME, TAI.NCUHATTIME) AS NCUHATTIME ") ' 2008/10/15 T.Watabe add
            '2016/12/22 H.Mori mod 2016改善開発 No4-1 NCU接続 START
            'strSQL.Append(",KOK.TUSIN ")                                'テレコン.通信モード 2008/10/24 T.Watabe add
            strSQL.Append(",TAI.TUSIN ")
            '2016/12/22 H.Mori mod 2016改善開発 No4-1 NCU接続 START
            strSQL.Append(",TAI.FAXKURAKBN ") ' 2010/07/12 T.Watabe add
            ' ▼▼▼ 2013/08/07 T.Ono mod 顧客単位登録機能追加 ▼▼▼
            ''2011.11.28 ADD H.Uema *------------------------------------------* START
            'strSQL.Append(",NVL(TA1.GUIDELINE, ")
            'strSQL.Append("    NVL( ")
            'strSQL.Append("      (SELECT T.GUIDELINE ")
            'strSQL.Append("       FROM M05_TANTO T ")
            'strSQL.Append("       WHERE '3' = T.KBN ")
            'strSQL.Append("         AND TAI.KURACD = T.KURACD ")
            'strSQL.Append("         AND TRIM(T.GUIDELINE) IS NOT NULL ")
            'strSQL.Append("         AND '01' = T.TANCD ")
            'strSQL.Append("         AND EXISTS (SELECT 'X' ")
            'strSQL.Append("                     FROM HN2MAS JAS ")
            'strSQL.Append("                     WHERE JAS.CLI_CD = T.KURACD ")
            'strSQL.Append("                       AND JAS.HAN_CD = TAI.ACBCD ")
            'strSQL.Append("                       AND T.CODE = JAS.JA_CD ")
            'strSQL.Append("                     )), ")
            'strSQL.Append("     ' ' ")
            'strSQL.Append("     ) ")
            'strSQL.Append(") AS GUIDELINE ")
            ''2011.11.28 ADD H.Uema *------------------------------------------* END
            strSQL.Append(", ")
            strSQL.Append("'" & strPar(2) & "' AS GUIDELINE ")
            strSQL.Append(",'" & strPar(3) & "' AS GUIDELINE2 ")  '2019/11/01 W.GANEKO 2019監視改善　No8-12
            strSQL.Append(",'" & strPar(4) & "' AS GUIDELINE3 ")  '2019/11/01 W.GANEKO 2019監視改善　No8-12
            ' ▲▲▲ 2013/08/07 T.Ono mod 顧客単位登録機能追加 ▲▲▲
            strSQL.Append(",TAI.KAITU_DAY ") ' 本日工事状況 2013/08/23 T.Ono add 監視改善2013№1
            strSQL.Append(",TAI.HANJICD AS HANJICD ") '販売事業者コード　2014/12/16 T.Ono add 2014改善開発 No2
            strSQL.Append(",TAI.HANJINM AS HANJINM ") '販売事業者名　2014/12/16 T.Ono add 2014改善開発 No2
            strSQL.Append(",TAI.FAXRUISEKIKBN ") ' 2015/11/17 H.Mori add 2015改善開発 No1
            strSQL.Append(",TAI.FAXSPOTKBN ") ' 2016/12/19 H.Mori add 2016改善開発 No6-3
            strSQL.Append("FROM ")
            strSQL.Append("    D20_TAIOU TAI, ")
            strSQL.Append("    M06_PULLDOWN PU2 ")
            '2016/12/22 H.Mori del 2016改善開発 No4-1 START
            'strSQL.Append("    ,SHAMAS KOK ") ' 2008/10/24 T.Watabe add
            '2016/12/22 H.Mori del 2016改善開発 No4-1 END
            ' ▼▼▼ 2013/08/07 T.Ono del 顧客単位登録機能追加 ▼▼▼
            ''2011.11.28 ADD H.Uema *------------------------------------------* START
            'strSQL.Append("     ,M05_TANTO TA1 ") 'JA注意事項取得
            ''2011.11.28 ADD H.Uema *------------------------------------------* END
            ' ▲▲▲ 2013/08/07 T.Ono del 顧客単位登録機能追加 ▲▲▲
            strSQL.Append("WHERE  ")
            strSQL.Append("      KANSCD      = :KANSCD ")
            strSQL.Append("  AND SYONO       = :SYONO ")
            strSQL.Append("  AND '04'        = PU2.KBN(+) ")
            strSQL.Append("  AND TAI.UNYO    = PU2.CD(+) ")
            '2016/12/22 H.Mori del 2016改善開発 No4-1 START
            'strSQL.Append("  AND TAI.KURACD  = KOK.CLI_CD(+) ") ' 2008/10/24 T.Watabe add
            'strSQL.Append("  AND TAI.ACBCD   = KOK.HAN_CD(+) ") ' 2008/10/24 T.Watabe add
            'strSQL.Append("  AND TAI.USER_CD = KOK.USER_CD(+) ") ' 2008/10/24 T.Watabe add
            '2016/12/22 H.Mori del 2016改善開発 No4-1 END
            ' ▼▼▼ 2013/08/07 T.Ono del 顧客単位登録機能追加 ▼▼▼
            ''2011.11.28 ADD H.Uema *------------------------------------------* START
            'strSQL.Append("  AND '3' = TA1.KBN(+) ")
            'strSQL.Append("  AND TAI.KURACD = TA1.KURACD(+) ")
            'strSQL.Append("  AND TA1.GUIDELINE(+) IS NOT NULL ")
            'strSQL.Append("  AND TA1.CODE(+) = TAI.ACBCD ")
            'strSQL.Append("  AND '01' = TA1.TANCD(+) ")
            ''2011.11.28 ADD H.Uema *------------------------------------------* END
            ' ▲▲▲ 2013/08/07 T.Ono del 顧客単位登録機能追加 ▲▲▲

            'パラメータのセット
            SqlParamC.fncSetParam("KANSCD", True, hdnKEY_KANSCD.Value)
            SqlParamC.fncSetParam("SYONO", True, hdnKEY_SYONO.Value)

            '//SQLの実行
            dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

            If Convert.ToInt32(dbData.Tables(0).Rows.Count) = 0 Then
                strMsg.Append("alert('対象データが存在しません');")
                strRec = "ERROR"
            Else
                '//データを出力します
                Call fncDataSet(dbData, "TAIOUK")
                strRec = "OK"
            End If

        Catch ex As Exception
            Dim ErrMsgC As New CErrMsg
            strMsg.Append("alert('システムエラー：" & ErrMsgC.mGetArtMsg(ex.ToString) & "');")
            strRec = "ERROR"

            '--- ↓2005/04/22 MOD Falcon↓ ---
        Finally
            If dbData Is Nothing Then
            Else
                dbData.Dispose()
            End If
            '--- ↑2005/04/22 MOD Falcon↑ ---
        End Try

        '--- ↓2005/04/22 DEL Falcon↓ ---
        'dbData.Dispose()
        '--- ↑2005/04/22 DEL Falcon↑ ---
        mlog("[KETAIJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- fncSetData_TAIOU end")

        Return strRec

    End Function

    '******************************************************************************
    ' 取得データを画面に転記
    '******************************************************************************
    Private Sub fncDataSet(ByVal pdbData As DataSet, ByVal strFLG As String)


        Dim decKonkai_Hai_S As Decimal              '//今回配送日・指針一時格納用
        Dim decKmsin As Decimal                     '//メータ値一時格納用（配送日からの推定使用量計算時に使用）
        Dim strG_Zaiko As String                    '//配送日からの推定使用料一時格納用
        Dim strNcuSet As String                     '//ＮＣＵ接続一時格納用
        Dim decKeihosu As Decimal                   '//警報メッセージ数
        Dim sRyuryo As String '2009/01/05 T.Watabe 流量区分

        Dim DateFncC As New CDateFnc
        Dim TimeFncC As New CTimeFnc
        Dim NaNFncC As New CNaNFnc
        Try
            '//--------------------------------------------------------------------------
            '<TODO>検索処理を行う
            '
            mlog("[KETAIJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- fncDataSet start")
            Dim strTemp As String
            Dim intTemp As Integer
            Dim intLoop As Integer

            'データが無ければ
            If Convert.ToString(pdbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then

            Else
                '既に対応済みの警報だったら表示しない
                If strFLG = "KEIHOU" Then
                    '対象の警報が既に対応済みだった場合のチェック
                    If Convert.ToString(pdbData.Tables(0).Rows(0).Item("REACTION")) <> "0" Then
                        strMsg.Append("alert('対象の警報は既に対応済の為、対応入力は行えません');")
                        strMsg.Append("fncExit();")
                        Return
                    End If
                End If

                '---------------------
                'データ転記処理
                '---------------------
                '発生日 ' 2008/10/15 T.Watabe add
                txtNCUHATYMD.Text = DateFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("NCUHATYMD")))
                '発生日(Hiddenに格納) ' 2008/10/15 T.Watabe add
                hdnNCUHATYMD.Value = DateFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("NCUHATYMD")))
                '発生時刻 ' 2008/10/15 T.Watabe add
                txtNCUHATTIME.Text = TimeFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("NCUHATTIME")), 0)

                '受信日
                txtHATYMD.Text = DateFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("KMYMD")))
                '受信日(Hiddenに格納)
                hdnHATYMD.Value = DateFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("KMYMD")))
                '受信時刻
                txtHATTIME.Text = TimeFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("KMTIME")), 0)

                'メータ値/メータ桁数
                If strFLG = "KEIHOU" Then
                    '整数部桁数
                    If IsNumeric(pdbData.Tables(0).Rows(0).Item("NUM_DIGIT")) = True Then
                        intTemp = Convert.ToInt32(pdbData.Tables(0).Rows(0).Item("NUM_DIGIT"))
                    Else
                        intTemp = 0
                    End If
                    If IsNumeric(pdbData.Tables(0).Rows(0).Item("KMSIN")) = True Then
                        strTemp = Convert.ToString(pdbData.Tables(0).Rows(0).Item("KMSIN"))
                    Else
                        strTemp = ""
                    End If
                    If strTemp.Length = 0 Then
                        'メータ値が指定されていなかったら
                        strTemp = ""
                    Else
                        'メータ値が指定されていたら小数点編集
                        strTemp = strTemp.Substring(0, intTemp) & "." & strTemp.Substring(intTemp)
                    End If
                    If strTemp.Length > 0 Then
                        decKmsin = CDec(strTemp)
                    End If
                    txtKMSIN.Text = strTemp
                    hdnNUM_DIGIT.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("NUM_DIGIT"))
                ElseIf strFLG = "KOKYAK" Then
                    decKmsin = 0
                    txtKMSIN.Text = ""
                    hdnNUM_DIGIT.Value = ""
                Else
                    decKmsin = 0
                    txtKMSIN.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("KMSIN"))
                    hdnNUM_DIGIT.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("NUM_DIGIT"))
                End If
                '警報メッセージ数
                If strFLG = "KEIHOU" Then
                    '警報受信パネルからの遷移だった場合
                    For intLoop = 1 To 6
                        '警報メッセージ数算出処理
                        If Convert.ToString _
                            (pdbData.Tables(0).Rows(0).Item("KMCD" & intLoop)) <> "" Then
                            '値が入っていれば警報メッセージ数カウント
                            decKeihosu = decKeihosu + 1
                        End If
                    Next
                    txtKEIHOSU.Text = Convert.ToString(decKeihosu)
                ElseIf strFLG = "KOKYAK" Then
                    txtKEIHOSU.Text = ""
                Else
                    txtKEIHOSU.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("KEIHOSU"))
                End If
                '流量区分
                If strFLG = "KOKYAK" Then
                    txtRYURYO.Text = ""
                Else
                    '2005/11/22 NEC UPDATE START
                    '2005/09/22 NEC UPDATE START
                    'txtRYURYO.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("RYURYO"))
                    'txtRYURYO.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("RYURYO")).Replace(":", "10").Replace(";", "11").Replace("<", "12").Replace("-", "13").Replace(">", "14").Replace("?", "15")
                    'txtRYURYO.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("RYURYO")).Replace(":", "10").Replace(";", "11").Replace("<", "12").Replace("=", "13").Replace(">", "14").Replace("?", "15")
                    '2005/09/22 NEC UPDATE END
                    '2005/11/22 NEC UPDATE END
                    '2009/01/05 T.Watabe edit 「0～9」はそのまま、「: ; < = > ?」はそれぞれ「10 11 12 13 14 15」に置き換え、その他は「0」
                    '2009/02/17 T.Watabe edit 「0～15」はそのままとする。
                    sRyuryo = Convert.ToString(pdbData.Tables(0).Rows(0).Item("RYURYO")).Trim
                    'If sRyuryo = "0" Or sRyuryo = "1" Or sRyuryo = "2" Or sRyuryo = "3" Or sRyuryo = "4" Or _
                    '    sRyuryo = "5" Or sRyuryo = "6" Or sRyuryo = "7" Or sRyuryo = "8" Or sRyuryo = "9" Then
                    If (sRyuryo >= "0" And sRyuryo <= "9") Or (sRyuryo >= "10" And sRyuryo <= "15") Then
                        txtRYURYO.Text = sRyuryo
                    ElseIf sRyuryo = ":" Or sRyuryo = ";" Or sRyuryo = "<" Or sRyuryo = "=" Or sRyuryo = ">" Or sRyuryo = "?" Then
                        txtRYURYO.Text = sRyuryo.Replace(":", "10").Replace(";", "11").Replace("<", "12").Replace("=", "13").Replace(">", "14").Replace("?", "15")
                    Else
                        txtRYURYO.Text = "0" 'その他
                    End If
                End If
                'メータ種別
                If strFLG = "KOKYAK" Then
                    txtMETASYU.Text = ""
                Else
                    txtMETASYU.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("METASYU_NAI"))
                End If
                'お客様ＦＬＧ
                txtUSER_FLG.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("UNYO_NAI"))
                'お客様ＦＬＧコード（Hiddenに格納）
                hdnUNYOCD.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("UNYOCD"))
                '警報メッセージ
                If strFLG = "KOKYAK" Then
                    '警報メッセージ１
                    txtKMNM1.Text = ""
                    hdnKMCD1.Value = ""
                    hdnKMNM1.Value = ""
                    '警報メッセージ２
                    txtKMNM2.Text = ""
                    hdnKMCD2.Value = ""
                    hdnKMNM2.Value = ""
                    '警報メッセージ３
                    txtKMNM3.Text = ""
                    hdnKMCD3.Value = ""
                    hdnKMNM3.Value = ""
                    '警報メッセージ４
                    txtKMNM4.Text = ""
                    hdnKMCD4.Value = ""
                    hdnKMNM4.Value = ""
                    '警報メッセージ５
                    txtKMNM5.Text = ""
                    hdnKMCD5.Value = ""
                    hdnKMNM5.Value = ""
                    '警報メッセージ６
                    txtKMNM6.Text = ""
                    hdnKMCD6.Value = ""
                    hdnKMNM6.Value = ""
                Else
                    '警報メッセージ１
                    txtKMNM1.Text = fncEditCutMsg(Convert.ToString(pdbData.Tables(0).Rows(0).Item("KMCD1")), Convert.ToString(pdbData.Tables(0).Rows(0).Item("KMNM1")), "：")
                    hdnKMCD1.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("KMCD1"))
                    hdnKMNM1.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("KMNM1"))
                    '警報メッセージ２
                    txtKMNM2.Text = fncEditCutMsg(Convert.ToString(pdbData.Tables(0).Rows(0).Item("KMCD2")), Convert.ToString(pdbData.Tables(0).Rows(0).Item("KMNM2")), "：")
                    hdnKMCD2.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("KMCD2"))
                    hdnKMNM2.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("KMNM2"))
                    '警報メッセージ３
                    txtKMNM3.Text = fncEditCutMsg(Convert.ToString(pdbData.Tables(0).Rows(0).Item("KMCD3")), Convert.ToString(pdbData.Tables(0).Rows(0).Item("KMNM3")), "：")
                    hdnKMCD3.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("KMCD3"))
                    hdnKMNM3.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("KMNM3"))
                    '警報メッセージ４
                    txtKMNM4.Text = fncEditCutMsg(Convert.ToString(pdbData.Tables(0).Rows(0).Item("KMCD4")), Convert.ToString(pdbData.Tables(0).Rows(0).Item("KMNM4")), "：")
                    hdnKMCD4.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("KMCD4"))
                    hdnKMNM4.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("KMNM4"))
                    '警報メッセージ５
                    txtKMNM5.Text = fncEditCutMsg(Convert.ToString(pdbData.Tables(0).Rows(0).Item("KMCD5")), Convert.ToString(pdbData.Tables(0).Rows(0).Item("KMNM5")), "：")
                    hdnKMCD5.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("KMCD5"))
                    hdnKMNM5.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("KMNM5"))
                    '警報メッセージ６
                    txtKMNM6.Text = fncEditCutMsg(Convert.ToString(pdbData.Tables(0).Rows(0).Item("KMCD6")), Convert.ToString(pdbData.Tables(0).Rows(0).Item("KMNM6")), "：")
                    hdnKMCD6.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("KMCD6"))
                    hdnKMNM6.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("KMNM6"))
                End If

                'お客様コード
                txtJUYOKA.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("JUYOKA_CD"))
                'お客様氏名
                txtJUSYONM.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("JUYONM"))
                'お客様カナ
                txtJUSYOKN.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("KANA"))
                '電話番号
                txtJUTEL1.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("JUTEL1"))
                txtJUTEL2.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("JUTEL2"))
                '2006/06/12 NEC UPDATE START
                'If strFLG = "TAIOUK" Then  '2021/10/01sakaDEL 2021年度監視改善⑦結線電話番号14ケタ化に対応して、ハイフンセット処理を削除（※2006年のNEC改善が丸々カットとなる）
                'Else
                'If txtJUTEL2.Text.Length > 4 Then
                'txtJUTEL2.Text = txtJUTEL2.Text.Substring(0, txtJUTEL2.Text.Length - 4) & "-" & txtJUTEL2.Text.Substring(txtJUTEL2.Text.Length - 4, 4)
                'End If
                'End If
                '2006/06/12 NEC UPDATE END
                '連絡先
                txtRENTEL.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("RENTEL"))
                '検索電話番号
                hdnKTELNO.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("KTELNO"))
                '住所
                txtADDR.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("ADDR"))
                'クライアントコード
                txtClientCD.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("CLI_CD"))
                'クライアントコード
                hdnKURACD.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("CLI_CD"))
                '監視センターコード
                hdnKANSCD.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("KANSCD"))
                '県名
                txtKENNM.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("KEN_NAME"))
                'ＪＡ/ＪＡ支所名
                '2006/06/06 NEC UPDATE START
                'txtACBNM.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("ACBCD")) & " : " & fncEditCutMsg(Convert.ToString(pdbData.Tables(0).Rows(0).Item("JA_NAME")), Convert.ToString(pdbData.Tables(0).Rows(0).Item("JAS_NAME")), "/")
                txtACBNM.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("ACBCD")) & " : " & Convert.ToString(pdbData.Tables(0).Rows(0).Item("JAS_NAME"))
                '2006/06/06 NEC UPDATE END
                'ＪＡコード(Hiddenに格納)
                hdnJACD.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("JA_CD"))
                'ＪＡ名(Hiddenに格納)
                hdnJANAME.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("JA_NAME"))
                'ＪＡ支所コード(Hiddenに格納)
                hdnJASCD.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("ACBCD"))
                'ＪＡ支所名(Hiddenに格納)
                hdnJASNAME.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("JAS_NAME"))

                '販売事業者　2014/12/16 T.Ono add 2014改善開発 No2 
                txtHANGRP.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("HANJICD")) & " : " & Convert.ToString(pdbData.Tables(0).Rows(0).Item("HANJINM"))
                hdnHANJICD.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("HANJICD"))
                hdnHANJINM.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("HANJINM"))

                '2016/02/02 w.ganeko add 2015改善開発 №1-3 start
                txtKANSHI_BIKO.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("KANSHI_BIKO"))
                hdnRENTEL2.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("RENTEL2"))
                hdnRENTEL2_BIKO.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("RENTEL2_BIKO"))
                hdnRENTEL2_UPD_DATE.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("RENTEL2_UPD_DATE"))
                hdnRENTEL3.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("RENTEL3"))
                hdnRENTEL3_BIKO.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("RENTEL3_BIKO"))
                hdnRENTEL3_UPD_DATE.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("RENTEL3_UPD_DATE"))
                '2016/12/12 H.Mori add 2016改善開発 No5-1 START
                hdnTELAB.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("TELAB"))
                hdnDAI3RENDORENTEL.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("DAI3RENDORENTEL"))
                '2016/12/12 H.Mori add 2016改善開発 No5-1 END
                hdnTelJVG.Value = "2"
                '2016/02/02 w.ganeko add 2015改善開発 №1-3 end
                '2016/12/22 H.Mori add 2016改善開発 No4-6 START
                hdnDAIHYO_NAME.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("DAIHYO_NAME"))
                hdnHOKBN.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("HOKBN"))
                hdnYOTOKBN.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("YOTOKBN"))
                hdnHANBCD.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("HANBCD"))
                '2016/12/22 H.Mori add 2016改善開発 No4-6 END
                '2017/10/16 H.Mori add 2017改善開発 No4-1 START
                hdnSHUGOU.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("SHUGOU"))
                '2017/10/16 H.Mori add 2017改善開発 No4-1 END

                '--- ↓2005/09/09 MOD Falcon↓ ---
                If strFLG = "KEIHOU" Or strFLG = "TAIOUK" Then
                    'ＪＰ備考
                    txtUSER_KIJI.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("BIKOU"))
                End If
                'お客様記事
                'txtUSER_KIJI.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("USR_MEMO"))
                '--- ↑2005/09/09 MOD Falcon↑ ---

                '------------------------------------------------------------
                '------------------------------------------------------------
                'ＮＣＵ接続の値を変数に格納
                '2006/06/09 NEC UPDATE START
                'If strFLG = "KEIHOU" Then
                '    '警報受信パネルからの遷移だった場合
                '    If Convert.ToString(pdbData.Tables(0).Rows(0).Item("UNYOCD")) <> "0" Then
                '        'お客様ＦＬＧが0以外だったら
                '        If Convert.ToString(pdbData.Tables(0).Rows(0).Item("KENSIN_MODE")) = "T" Then
                '            '検針モードがTだったら
                '            strNcuSet = "2"
                '        Else
                '            strNcuSet = "1"
                '        End If
                '    Else
                '        strNcuSet = "0"
                '    End If
                'Else
                '    strNcuSet = Convert.ToString(pdbData.Tables(0).Rows(0).Item("NCU_CON"))
                'End If
                '対応結果一覧画面から遷移したとき
                If strFLG = "TAIOUK" Then
                    'NCU_CONは、対応DBの「NCU接続」の項目から取得するため、１，２，３のいずれか
                    strNcuSet = Convert.ToString(pdbData.Tables(0).Rows(0).Item("NCU_CON"))
                    '警報受信パネル、顧客検索画面から遷移したとき
                Else
                    'NCU_CONは、共有マスタの「検針種別」の項目から取得するため、A、B、M、T、tのいずれか
                    strNcuSet = Convert.ToString(pdbData.Tables(0).Rows(0).Item("NCU_CON"))
                    Dim SQLC As New KETAIJAG00CSQL.CSQL
                    Dim SqlParamC As New CSQLParam
                    Dim SqlParamt As New CSQLParam      'add 2012/03/01 NEC ou
                    Dim strSQL As New StringBuilder("")
                    Dim dbData As DataSet

                    Dim strRec As String

                    '//対応入力からの画面遷移の場合
                    strSQL = New StringBuilder("")
                    strSQL.Append("SELECT ")
                    strSQL.Append("COUNT(*) AS CNT ")
                    strSQL.Append("FROM ")
                    strSQL.Append("M06_PULLDOWN ")
                    strSQL.Append("WHERE ")
                    strSQL.Append("KBN=:KBN AND ")
                    strSQL.Append("CD=:CD ")

                    'パラメータのセット(NCU接続（双方向）の検索）
                    SqlParamC.fncSetParam("KBN", True, "60")
                    SqlParamC.fncSetParam("CD", True, strNcuSet)

                    '//SQLの実行
                    dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

                    '結果が１件であれば
                    If Convert.ToString(dbData.Tables(0).Rows(0).Item("CNT")) = "1" Then
                        'NCU接続（双方向）
                        strNcuSet = "1"
                    Else
                        'upd 2012/03/01 NEC ou Str
                        'パラメータのセット(NCU接続（端末発呼）の検索）
                        SqlParamt.fncSetParam("KBN", True, "61")
                        SqlParamt.fncSetParam("CD", True, strNcuSet)
                        '//SQLの実行
                        dbData = SQLC.mGetData(strSQL.ToString, SqlParamt.pParamDataSet, True)
                        'upd 2012/03/01 NEC ou End
                        '結果が１件であれば
                        If Convert.ToString(dbData.Tables(0).Rows(0).Item("CNT")) = "1" Then
                            'NCU接続（端末発呼)
                            strNcuSet = "2"
                        ElseIf strNcuSet = "" Then
                            'NCU接続(未接続）
                            strNcuSet = "3"
                        Else
                            strNcuSet = ""
                        End If
                    End If
                End If
                '2006/06/09 NEC UPDATE END
                'ＮＣＵ接続（Hiddenに格納）
                hdnNCU.Value = strNcuSet
                'ＮＣＵ接続（チェックボックスにセット）
                Select Case strNcuSet
                    Case "1"
                        '１:接続（双）
                        chkNCU_SET1.Checked = True
                        chkNCU_SET2.Checked = False
                        chkNCU_SET0.Checked = False
                    Case "2"
                        '２:接続（端）
                        chkNCU_SET1.Checked = False
                        chkNCU_SET2.Checked = True
                        chkNCU_SET0.Checked = False
                    Case "3"
                        '３:未接続
                        chkNCU_SET1.Checked = False
                        chkNCU_SET2.Checked = False
                        chkNCU_SET0.Checked = True
                    Case Else
                        'その他
                        chkNCU_SET1.Checked = False
                        chkNCU_SET2.Checked = False
                        chkNCU_SET0.Checked = False
                End Select
                '地図番号
                txtMAP_CD.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("MAP_CD"))
                '交換区分(１：全交換　２：半数交換 ３：予備交換 ４：予備交互交換)
                hdnBOMB_TYPE.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMB_TYPE"))
                Select Case Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMB_TYPE"))
                    Case "1"
                        txtBOMB_TYPE.Text = "全交換"
                    Case "2"
                        txtBOMB_TYPE.Text = "半数交換"
                    Case "3"
                        txtBOMB_TYPE.Text = "予備交換"
                    Case "4"
                        txtBOMB_TYPE.Text = "予備交互交換"
                    Case Else
                        txtBOMB_TYPE.Text = ""
                End Select
                'NCU接続 2008/10/24 T.Watabe add
                txtTUSIN.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("TUSIN"))
                '販売区分(１：メータ売　２：ボンベ売 ３：両方 ４：その他) 2015/11/25 H.Mori add 2015改善開発 No1　add  
                hdnHANBAI_KBN.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("HANBAI_KBN")).Trim
                Select Case Convert.ToString(pdbData.Tables(0).Rows(0).Item("HANBAI_KBN")).Trim
                    Case "1"
                        txtHANBAI_KBN.Text = "メータ売"
                    Case "2"
                        txtHANBAI_KBN.Text = "ボンベ売"
                    Case "3"
                        txtHANBAI_KBN.Text = "両方"
                    Case "4"
                        txtHANBAI_KBN.Text = "その他"
                    Case Else
                        txtHANBAI_KBN.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("HANBAI_KBN")).Trim
                End Select
                '供給形態区分(１：一般　２：集合 ３：簡ガス) 2016/12/02 H.Mori add 2016改善開発 No4-3　add  
                hdnKYOKTKBN.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("KYOKTKBN")).Trim
                Select Case Convert.ToString(pdbData.Tables(0).Rows(0).Item("KYOKTKBN")).Trim
                    Case "1"
                        txtKYOKTKBN.Text = "一般"
                    Case "2"
                        txtKYOKTKBN.Text = "集合"
                    Case "3"
                        txtKYOKTKBN.Text = "簡ガス"
                    Case Else
                        txtKYOKTKBN.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("KYOKTKBN")).Trim
                End Select
                'メータ型式
                txtMET_KATA.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("SETSUBI"))
                'メータメーカー
                txtMET_MAKER.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("KYOKYU_MK"))
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
                'ボンベ３容器ＫＧ
                txtBONB3_KKG.Text = NaNFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMB_YOUKI3")), 0)
                'ボンベ３設置本数
                txtBONB3_HON.Text = NaNFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMB_SUU3")), 0)
                'ボンベ３容量ＫＧ
                txtBONB3_RKG.Text = fncEditYouryou(Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMB_YOUKI3")), Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMB_SUU3")))
                'ボンベ３容器予備フラグ
                hdnBONB3_YOBI.Value = Convert.ToString(Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMB_RYO3")))
                If hdnBONB3_YOBI.Value = "1" Then
                    chkBONB3_YOBI.Checked = True    '予備容器としてチェック
                Else
                    chkBONB3_YOBI.Checked = False
                End If
                'ボンベ４容器ＫＧ
                txtBONB4_KKG.Text = NaNFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMB_YOUKI4")), 0)
                'ボンベ４設置本数
                txtBONB4_HON.Text = NaNFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMB_SUU4")), 0)
                'ボンベ４容量ＫＧ
                txtBONB4_RKG.Text = fncEditYouryou(Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMB_YOUKI4")), Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMB_SUU4")))
                'ボンベ４容器予備フラグ
                hdnBONB4_YOBI.Value = Convert.ToString(Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMB_RYO4")))
                If hdnBONB4_YOBI.Value = "1" Then
                    chkBONB4_YOBI.Checked = True    '予備容器としてチェック
                Else
                    chkBONB4_YOBI.Checked = False
                End If
                '配送日からの推定使用量(今秋
                If strFLG = "TAIOUK" Then
                    strG_Zaiko = Convert.ToString(pdbData.Tables(0).Rows(0).Item("G_ZAIKO"))
                ElseIf strFLG = "KOKYAK" Then
                    strG_Zaiko = ""
                ElseIf (
                        IsNumeric(Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMV_SISIN1"))) = True And
                        IsNumeric(Convert.ToString(pdbData.Tables(0).Rows(0).Item("KMSIN"))) = True
                       ) And
                       strFLG = "KEIHOU" And
                       Convert.ToString(pdbData.Tables(0).Rows(0).Item("JUYOKA")).Length > 0 Then

                    If IsNumeric(Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMV_SISIN1"))) = True Then
                        decKonkai_Hai_S = fncEditSisinDec(Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMV_SISIN1")))
                    End If

                    '配送日からの推定使用量取得
                    If decKmsin >= decKonkai_Hai_S Then
                        'メータ値が今回配送日・指針以上だったら
                        strG_Zaiko = CStr(Decimal.Truncate((decKmsin - decKonkai_Hai_S) / 0.482D * 10D) / 10D)

                    ElseIf decKmsin < decKonkai_Hai_S Then
                        'メータ値が今回配送日・指針未満だったら
                        Select Case Convert.ToString(pdbData.Tables(0).Rows(0).Item("NUM_DIGIT"))
                            Case "0"
                                strG_Zaiko = CStr(Decimal.Truncate((1D + decKmsin - decKonkai_Hai_S) / 0.482D * 10D) / 10D)
                            Case "1"
                                strG_Zaiko = CStr(Decimal.Truncate((10D + decKmsin - decKonkai_Hai_S) / 0.482D * 10D) / 10D)
                            Case "2"
                                strG_Zaiko = CStr(Decimal.Truncate((100D + decKmsin - decKonkai_Hai_S) / 0.482D * 10D) / 10D)
                            Case "3"
                                strG_Zaiko = CStr(Decimal.Truncate((1000D + decKmsin - decKonkai_Hai_S) / 0.482D * 10D) / 10D)
                            Case "4"
                                strG_Zaiko = CStr(Decimal.Truncate((10000D + decKmsin - decKonkai_Hai_S) / 0.482D * 10D) / 10D)
                            Case "5"
                                strG_Zaiko = CStr(Decimal.Truncate((100000D + decKmsin - decKonkai_Hai_S) / 0.482D * 10D) / 10D)
                            Case "6"
                                strG_Zaiko = CStr(Decimal.Truncate((1000000D + decKmsin - decKonkai_Hai_S) / 0.482D * 10D) / 10D)
                            Case "7"
                                strG_Zaiko = CStr(Decimal.Truncate((10000000D + decKmsin - decKonkai_Hai_S) / 0.482D * 10D) / 10D)
                            Case Else
                                strG_Zaiko = ""
                        End Select
                    End If
                Else
                    '両方とも指定がない場合は空で出力
                    strG_Zaiko = ""
                End If
                '配送日からの推定使用量
                txtG_ZAIKO.Text = NaNFncC.mGet(strG_Zaiko, 0)
                '一日あたり使用量
                '2005/11/22 NEC UPDATE START
                'txtICHI_SIYO.Text = fncEditSisin(Convert.ToString(pdbData.Tables(0).Rows(0).Item("SIYOU3")))
                txtICHI_SIYO.Text = fncEditSisin(Convert.ToString(pdbData.Tables(0).Rows(0).Item("SIYOU3")), 3)
                '2005/11/22 NEC UPDATE END
                '予測１日当り使用量
                '2005/11/22 NEC UPDATE START
                'txtYOSOKU_ICHI_SIYO.Text = fncEditSisin(Convert.ToString(pdbData.Tables(0).Rows(0).Item("SIYOU4")))
                txtYOSOKU_ICHI_SIYO.Text = fncEditSisin(Convert.ToString(pdbData.Tables(0).Rows(0).Item("SIYOU4")), 3)
                '2005/11/22 NEC UPDATE END
                'ボンベ交換前回配送日
                txtZENKAI_HAISO.Text = fncEditDate(Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMV_HAISO1")))
                'ボンベ交換前回配送指針
                '2005/11/22 NEC UPDATE START
                'txtZENKAI_HAI_S.Text = fncEditSisin(Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMV_SISIN1")))
                txtZENKAI_HAI_S.Text = fncEditSisin(Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMV_SISIN1")), 1)
                '2005/11/22 NEC UPDATE END
                'ボンベ交換今回配送日
                txtKONKAI_HAISO.Text = fncEditDate(Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMV_HAISO2")))
                '次回配送予定日
                txtJIKAI_HAISO.Text = fncEditDate(Convert.ToString(pdbData.Tables(0).Rows(0).Item("HAISO_YOTEI")))
                'ボンベ交換今回配送指針
                '2005/11/22 NEC UPDATE START
                'txtKONKAI_HAI_S.Text = fncEditSisin(Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMV_SISIN2")))
                txtKONKAI_HAI_S.Text = fncEditSisin(Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMV_SISIN2")), 1)
                '2005/11/22 NEC UPDATE END
                'ボンベ切替前回発生日
                txtZENKAI_HASEI.Text = fncEditDate(Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMB_DATE1")))
                'ボンベ切替前回発生指針
                '2005/11/22 NEC UPDATE START
                'txtZENKAI_HAS_S.Text = fncEditSisin(Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMB_SISIN1")))
                txtZENKAI_HAS_S.Text = fncEditSisin(Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMB_SISIN1")), 1)
                '2005/11/22 NEC UPDATE END
                'ボンベ切替今回発生日
                txtKONKAI_HASEI.Text = fncEditDate(Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMB_DATE2")))
                'ボンベ切替今回発生指針
                '2005/11/22 NEC UPDATE START
                'txtKONKAI_HAS_S.Text = fncEditSisin(Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMB_SISIN2")))
                txtKONKAI_HAS_S.Text = fncEditSisin(Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMB_SISIN2")), 1)
                '2005/11/22 NEC UPDATE END
                '検針情報前回検針日
                txtZENKAI_KENSIN.Text = fncEditDate(Convert.ToString(pdbData.Tables(0).Rows(0).Item("KENSIN_DAY1")))
                '検針情報前回検針指針
                '2005/11/22 NEC UPDATE START
                'txtZENKAI_KEN_S.Text = fncEditSisin(Convert.ToString(pdbData.Tables(0).Rows(0).Item("KENSINTI1")))
                txtZENKAI_KEN_S.Text = fncEditSisin(Convert.ToString(pdbData.Tables(0).Rows(0).Item("KENSINTI1")), 1)
                '2005/11/22 NEC UPDATE END
                '前回使用量
                ''''txtZENKAI_KEN_SIYO.Text = NaNFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("SIYOU1")), 0)
                '2005/11/22 NEC UPDATE START
                'txtZENKAI_KEN_SIYO.Text = fncEditSisin(Convert.ToString(pdbData.Tables(0).Rows(0).Item("SIYOU1")))
                txtZENKAI_KEN_SIYO.Text = fncEditSisin(Convert.ToString(pdbData.Tables(0).Rows(0).Item("SIYOU1")), 1)
                '2005/11/22 NEC UPDATE END
                '検針情報今回検針日
                txtKONKAI_KENSIN.Text = fncEditDate(Convert.ToString(pdbData.Tables(0).Rows(0).Item("KENSIN_DAY2")))
                '検針情報今回検針指針
                '2005/11/22 NEC UPDATE START
                'txtKONKAI_KEN_S.Text = fncEditSisin(Convert.ToString(pdbData.Tables(0).Rows(0).Item("KENSINTI2")))
                txtKONKAI_KEN_S.Text = fncEditSisin(Convert.ToString(pdbData.Tables(0).Rows(0).Item("KENSINTI2")), 1)
                '2005/11/22 NEC UPDATE END
                '今回使用量
                ''''txtKONKAI_KEN_SIYO.Text = NaNFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("SIYOU2")), 0)
                '2005/11/22 NEC UPDATE START
                'txtKONKAI_KEN_SIYO.Text = fncEditSisin(Convert.ToString(pdbData.Tables(0).Rows(0).Item("SIYOU2")))
                txtKONKAI_KEN_SIYO.Text = fncEditSisin(Convert.ToString(pdbData.Tables(0).Rows(0).Item("SIYOU2")), 1)
                '2005/11/22 NEC UPDATE END
                'ガス器具１品名
                txtGAS1_HINMEI.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("GAS_NAME1"))
                'ガス器具１台数
                txtGAS1_DAISU.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("GAS_SUU1"))
                'ガス器具１セイフル
                txtGAS1_SEIFL.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("GAS_SEIF1"))
                'ガス器具２品名
                txtGAS2_HINMEI.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("GAS_NAME2"))
                'ガス器具２台数
                txtGAS2_DAISU.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("GAS_SUU2"))
                'ガス器具２セイフル
                txtGAS2_SEIFL.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("GAS_SEIF2"))
                'ガス器具３品名
                txtGAS3_HINMEI.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("GAS_NAME3"))
                'ガス器具３台数
                txtGAS3_DAISU.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("GAS_SUU3"))
                'ガス器具３セイフル
                txtGAS3_SEIFL.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("GAS_SEIF3"))
                'ガス器具４品名
                txtGAS4_HINMEI.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("GAS_NAME4"))
                'ガス器具４台数
                txtGAS4_DAISU.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("GAS_SUU4"))
                'ガス器具４セイフル
                txtGAS4_SEIFL.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("GAS_SEIF4"))
                'ガス器具５品名
                txtGAS5_HINMEI.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("GAS_NAME5"))
                'ガス器具５台数
                txtGAS5_DAISU.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("GAS_SUU5"))
                'ガス器具５セイフル
                txtGAS5_SEIFL.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("GAS_SEIF5"))
                'ガス供給休止日
                txtGAS_START.Text = fncEditDate(Convert.ToString(pdbData.Tables(0).Rows(0).Item("GAS_START")))
                'ガス供給廃止日
                txtGAS_DELE.Text = fncEditDate(Convert.ToString(pdbData.Tables(0).Rows(0).Item("GAS_DELE")))
                'ガス供給復活日
                txtGAS_RESTART.Text = fncEditDate(Convert.ToString(pdbData.Tables(0).Rows(0).Item("GAS_RESTART")))
                '本日工事状況　2013/08/23 T.Ono add 監視改善2013№1
                txtKAITU_DAY.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("KAITU_DAY"))

                '------------------------------------------------------------
                '------------------------------------------------------------
                '発生区分
                '//発生区分(1:電話／2:緊急対応)
                hdnHATKBN.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("HATKBN"))
                txtHATKBN.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("HATKBN_NAI"))
                '電話連絡内容（初期値55:その他） 2016/12/20 H.Mori add 2016改善開発 No4-2
                'strCBO_TELRCD = "55"  '2019/11/01 w.ganeko 2019監視改善 No 6 del
                '--- ↓2005/05/23 ADD Falcon↓ ---
                '緊急対応の場合は、
                If Convert.ToString(pdbData.Tables(0).Rows(0).Item("HATKBN")) = "2" Then
                    '電話連絡内容（初期値55:その他） 2020/03/10 T.Ono add 2019監視改善  警報の時は初期値指定
                    strCBO_TELRCD = "55"

                    '利用者情報入力不可
                    Call fncSetState(True)
                End If
                '--- ↑2005/05/23 ADD Falcon↑ ---

                '[入力項目エリア]・[初期選択]-------------------------------
                If strFLG = "TAIOUK" Then
                    '//対応区分
                    strCBO_TAIOKBN = Convert.ToString(pdbData.Tables(0).Rows(0).Item("TAIOKBN"))
                    '//処理区分
                    strCBO_TMSKB = Convert.ToString(pdbData.Tables(0).Rows(0).Item("TMSKB"))
                    '//監視センター担当者コード
                    hdnTKTANCD.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("TKTANCD"))
                    '//監視センター担当者名
                    txtTKTANCD.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("TKTANCD")) & "：" & Convert.ToString(pdbData.Tables(0).Rows(0).Item("TKTANCD_NM"))
                    '//連絡相手
                    strCBO_TAITCD = Convert.ToString(pdbData.Tables(0).Rows(0).Item("TAITCD"))
                    '//対応完了日
                    txtSYOYMD.Text = DateFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("SYOYMD")))
                    '//対応完了時刻
                    txtSYOTIME.Text = TimeFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("SYOTIME")), 1)
                    '//ＦＡＸ不要(JA)　1:不要　2:必要
                    If Convert.ToString(pdbData.Tables(0).Rows(0).Item("FAXKBN")) = "1" Then
                        chkFAXKBN.Checked = True
                    Else
                        chkFAXKBN.Checked = False
                    End If
                    '//ＦＡＸ不要(ｸﾗｲｱﾝﾄ)　1:不要　2:必要 2010/07/12 T.Watabe add
                    If Convert.ToString(pdbData.Tables(0).Rows(0).Item("FAXKURAKBN")) = "1" Then
                        chkFAXKURAKBN.Checked = True
                    Else
                        chkFAXKURAKBN.Checked = False
                    End If
                    '//ＦＡＸ不要(累積)　1:不要　2:必要 2015/11/17 H.Mori add 2015改善開発 No1 START
                    If Convert.ToString(pdbData.Tables(0).Rows(0).Item("FAXRUISEKIKBN")) = "1" Then
                        chkFAXRUISEKIKBN.Checked = True
                    Else
                        chkFAXRUISEKIKBN.Checked = False
                    End If
                    '2015/11/17 H.Mori add 2015改善開発 No1 END
                    '//電話連絡内容
                    strCBO_TELRCD = Convert.ToString(pdbData.Tables(0).Rows(0).Item("TELRCD"))
                    '//復帰対応状況
                    strCBO_TFKICD = Convert.ToString(pdbData.Tables(0).Rows(0).Item("TFKICD"))
                    '電話対応メモ
                    ' 2014/02/13 T.Ono mod 監視改善2013 無駄な改行が入らないように修正 Start
                    '' 2013/10/24 T.Ono 監視改善2013№1 Start
                    ''//復帰操作メモ
                    ''txtFUK_MEMO.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("FUK_MEMO"))
                    ' ''//電話対応メモ１
                    ''txtTEL_MEMO1.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("TEL_MEMO1"))
                    ' ''//電話対応メモ２
                    ''txtTEL_MEMO2.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("TEL_MEMO2"))
                    'txtTEL_MEMO.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("TEL_MEMO1")) & vbCrLf _
                    '                    & Convert.ToString(pdbData.Tables(0).Rows(0).Item("TEL_MEMO2")) & vbCrLf _
                    '                    & Convert.ToString(pdbData.Tables(0).Rows(0).Item("FUK_MEMO"))
                    '' 2013/10/24 T.Ono 監視改善2013№1 End
                    Dim strMemo As String = ""
                    Dim row As String = "0"

                    '2020/11/01 T.Ono mod 2020監改善 Start
                    'If Convert.ToString(pdbData.Tables(0).Rows(0).Item("FUK_MEMO")) <> "" Then
                    '    strMemo = vbCrLf & Convert.ToString(pdbData.Tables(0).Rows(0).Item("FUK_MEMO"))
                    '    row = "3"
                    'End If
                    'If Convert.ToString(pdbData.Tables(0).Rows(0).Item("TEL_MEMO2")) <> "" Then
                    '    strMemo = vbCrLf & Convert.ToString(pdbData.Tables(0).Rows(0).Item("TEL_MEMO2")) & strMemo
                    '    row = "2"
                    'ElseIf row = "3" Then
                    '    '2行目はデータなしだが、3行目はデータあり
                    '    strMemo = vbCrLf & strMemo
                    'End If
                    'If Convert.ToString(pdbData.Tables(0).Rows(0).Item("TEL_MEMO1")) <> "" Then
                    '    strMemo = Convert.ToString(pdbData.Tables(0).Rows(0).Item("TEL_MEMO1")) & strMemo
                    'ElseIf (row = "2" OrElse row = "3") Then
                    '    '1行目はデータなしだが、2,3行目はデータあり
                    '    '（備考：先頭の改行は無視される、2つ続けると1つ目は無視され2つ目は有効となる）
                    '    strMemo = vbCrLf & strMemo
                    'End If

                    '6行目
                    If Convert.ToString(pdbData.Tables(0).Rows(0).Item("TEL_MEMO6")) <> "" Then
                        strMemo = vbCrLf + Convert.ToString(pdbData.Tables(0).Rows(0).Item("TEL_MEMO6"))
                    End If

                    '5行目
                    If Convert.ToString(pdbData.Tables(0).Rows(0).Item("TEL_MEMO5")) <> "" Then
                        strMemo = vbCrLf + Convert.ToString(pdbData.Tables(0).Rows(0).Item("TEL_MEMO5")) + strMemo
                    Else
                        If strMemo <> "" Then
                            strMemo = vbCrLf + strMemo
                        End If
                    End If

                    '4行目
                    If Convert.ToString(pdbData.Tables(0).Rows(0).Item("TEL_MEMO4")) <> "" Then
                        strMemo = vbCrLf + Convert.ToString(pdbData.Tables(0).Rows(0).Item("TEL_MEMO4")) + strMemo
                    Else
                        If strMemo <> "" Then
                            strMemo = vbCrLf + strMemo
                        End If
                    End If

                    '3行目
                    If Convert.ToString(pdbData.Tables(0).Rows(0).Item("FUK_MEMO")) <> "" Then
                        strMemo = vbCrLf + Convert.ToString(pdbData.Tables(0).Rows(0).Item("FUK_MEMO")) + strMemo
                    Else
                        If strMemo <> "" Then
                            strMemo = vbCrLf + strMemo
                        End If
                    End If

                    '2行目
                    If Convert.ToString(pdbData.Tables(0).Rows(0).Item("TEL_MEMO2")) <> "" Then
                        strMemo = vbCrLf + Convert.ToString(pdbData.Tables(0).Rows(0).Item("TEL_MEMO2")) + strMemo
                    Else
                        If strMemo <> "" Then
                            strMemo = vbCrLf + strMemo
                        End If
                    End If

                    '1行目
                    If Convert.ToString(pdbData.Tables(0).Rows(0).Item("TEL_MEMO1")) <> "" Then
                        strMemo = Convert.ToString(pdbData.Tables(0).Rows(0).Item("TEL_MEMO1")) + strMemo
                    Else
                        If strMemo <> "" Then
                            strMemo = vbCrLf + strMemo
                        End If
                    End If
                    '2020/11/01 T.Ono mod 2020監改善 End

                    txtTEL_MEMO.Value = strMemo.ToString
                    'txtTEL_MEMO.Text = strMemo.ToString '★★★
                    ' 2014/02/13 T.Ono mod 監視改善2013 End
                    '//ガス器具
                    strCBO_TKIGCD = Convert.ToString(pdbData.Tables(0).Rows(0).Item("TKIGCD"))
                    '//作動原因
                    strCBO_TSADCD = Convert.ToString(pdbData.Tables(0).Rows(0).Item("TSADCD"))
                    '//お客様記事
                    'txtGENIN_KIJI.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("GENIN_KIJI"))   '2021/01/05 T.Ono mod 2020監視改善
                    txtGENIN_KIJI.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("GENIN_KIJI"))
                    '//出動指示内容
                    strCBO_SDCD = Convert.ToString(pdbData.Tables(0).Rows(0).Item("SDCD"))
                    '//出動指示日
                    txtSIJIYMD.Text = DateFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("SIJIYMD")))
                    '//出動指示時刻
                    txtSIJITIME.Text = TimeFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("SIJITIME")), 1)
                    '//出動指示備考1
                    txtSIJI_BIKO1.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("SIJI_BIKO1"))
                    '//出動指示備考2
                    txtSIJI_BIKO2.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("SIJI_BIKO2"))
                    '//処理番号
                    txtSYONO.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("SYONO"))
                    '//処理番号
                    hdnSYONO.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("SYONO"))
                    '//作成日
                    hdnADD_DATE.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("ADD_DATE"))
                    '//更新日
                    hdnEDT_DATE.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("EDT_DATE"))
                    '//更新時間
                    hdnTIME.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("EDT_TIME"))
                    '連絡先選択画面：電話連絡備考
                    hdnREN_DENWABIKO.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("TEL_BIKO"))
                    '--- ↓2005/09/09 ADD Falcon↓ ---
                    '連絡先選択画面：ＦＡＸタイトルコード
                    hdnFAX_TITLE_CD.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("FAX_TITLE_CD"))
                    '--- ↑2005/09/09 ADD Falcon↑ ---
                    '連絡先選択画面：ＦＡＸタイトル
                    hdnREN_FAXTITLE.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("FAX_TITLE"))
                    '連絡先選択画面：メモ欄
                    hdnREN_FAXREN.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("FAX_REN"))
                    '2016/12/14 H.Mori add 2016改善開発 No6-3 START
                    '連絡先選択画面：スポットFAX送信区分
                    hdnFAXSPOTKBN.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("FAXSPOTKBN"))
                    '2016/12/14 H.Mori add 2016改善開発 No6-3 END

                Else
                    '=============================================================================================
                    '2011.11.07 ADD h.uema
                    'Else追加(遷移元が対応結果一覧画面以外の場合, FAX不要(クライアント)を設定するように改修
                    '=============================================================================================
                    '//ＦＡＸ不要(ｸﾗｲｱﾝﾄ)　1:不要　0:必要 ※担当者マスタより取得
                    If Convert.ToString(pdbData.Tables(0).Rows(0).Item("FAXKURAKBN")) = "1" Then
                        chkFAXKURAKBN.Checked = True
                    Else
                        chkFAXKURAKBN.Checked = False
                    End If
                    '2011.12.01 ADD H.Uema FAX不要(JA)追加
                    If Convert.ToString(pdbData.Tables(0).Rows(0).Item("FAXKBN")) = "1" Then
                        chkFAXKBN.Checked = True
                    Else
                        chkFAXKBN.Checked = False
                    End If
                End If
                '//お客様記事
                'txtGENIN_KIJI.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("GENIN_KIJI"))    '2021/01/05 T.Ono mod 2020監視改善
                txtGENIN_KIJI.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("GENIN_KIJI"))
                '2016/11/17 H.Mori add 2016改善開発 No4-4
                If Convert.ToString(pdbData.Tables(0).Rows(0).Item("GENIN_KIJI")) <> "" Then
                    txtRENTEL.BackColor = Color.GreenYellow
                End If

                Dim strSYSDATE As String = Now.ToString("yyyyMMdd")
                Dim strSYSTIME As String = Now.ToString("HHmmss")

                'すでにＤＢに開始日がセットされて、完了日がセットされている場合は無視する
                'また、すでにＤＢにある日付が変更されている場合はこの値を使用し、再度所要時間を計算する
                hdnTAIO_ST_DATE.Value = strSYSDATE
                hdnTAIO_ST_TIME.Value = strSYSTIME

                '対応受信日・対応時刻
                If strFLG = "TAIOUK" Or strFLG = "KEIHOU" Then
                    hdnJUYMD.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("JUYMD"))
                    hdnJUTIME.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("JUTIME"))
                Else
                    '電話対応の場合は画面を開いた時刻
                    hdnJUYMD.Value = strSYSDATE
                    hdnJUTIME.Value = strSYSTIME
                End If
                hdnSDSKBN.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("SDSKBN")) ' 2008/10/17 T.Watabe add

                '▼▼▼ 2011.11.09 ADD H.Uema JA注意事項の追加 ▼▼▼
                lblGuideline.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("GUIDELINE"))
                lblGuideline2.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("GUIDELINE2"))  '2019/11/01 W.GANEKO 2019監視改善 No8-12
                lblGuideline3.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("GUIDELINE3"))  '2019/11/01 W.GANEKO 2019監視改善 No8-12
                '▲▲▲ 2011.11.09 ADD H.Uema JA注意事項の追加 ▲▲▲


                '2014/02/10 T.Ono add 監視改善2013　重複表示機能追加
                '重複表示対象のものは、対応区分と報告不要をセット
                If strFLG = "KEIHOU" Then
                    Dim taiounaiyou As New KETAIJAG00DTO.AutoTaiouDto
                    '重複表示の対象かチェック
                    taiounaiyou = fncChoufukuHyouji()
                    If Not IsNothing(taiounaiyou.groupcd) Then
                        strCBO_TAIOKBN = "3"                '対応区分を3にセット（fncComboSetでセット）
                        hdnchoufukuhyouji.Value = "1"       '報告不要にチェック（KETAIJKG00.aspx.vbのfncGetData_RENでセット）

                        'その他　マスタの登録内容を画面へ反映
                        '処理区分
                        If Convert.ToString(taiounaiyou.tmskb) <> "" Then
                            strCBO_TMSKB = Convert.ToString(taiounaiyou.tmskb)
                        End If
                        '監視センター担当者コード
                        If Convert.ToString(taiounaiyou.tktancd) <> "" Then
                            hdnTKTANCD.Value = Convert.ToString(taiounaiyou.tktancd)
                            '監視センター担当者名
                            txtTKTANCD.Text = Convert.ToString(taiounaiyou.tktancd) & "：" & Convert.ToString(taiounaiyou.tktannm)
                        End If
                        '連絡相手
                        If Convert.ToString(taiounaiyou.taitcd) <> "" Then
                            strCBO_TAITCD = Convert.ToString(taiounaiyou.taitcd)
                        End If
                        '復帰対応状況
                        If Convert.ToString(taiounaiyou.tfkicd) <> "" Then
                            strCBO_TFKICD = Convert.ToString(taiounaiyou.tfkicd)
                        End If
                        'ガス器具
                        If Convert.ToString(taiounaiyou.tkigcd) <> "" Then
                            strCBO_TKIGCD = Convert.ToString(taiounaiyou.tkigcd)
                        End If
                        '作動原因
                        If Convert.ToString(taiounaiyou.tsadcd) <> "" Then
                            strCBO_TSADCD = Convert.ToString(taiounaiyou.tsadcd)
                        End If
                        '電話連絡内容
                        If Convert.ToString(taiounaiyou.telrcd) <> "" Then
                            strCBO_TELRCD = Convert.ToString(taiounaiyou.telrcd)
                        End If
                        '電話対応メモ（1行分）
                        If Convert.ToString(taiounaiyou.tel_memo1) <> "" Then
                            txtTEL_MEMO.Value = Convert.ToString(taiounaiyou.tel_memo1)
                            'txtTEL_MEMO.Text = Convert.ToString(taiounaiyou.tel_memo1) '★★★
                        End If

                    Else
                        '2020/11/01 T.Ono add 2020監視改善
                        '自動対応じゃない場合
                        Dim strTANInfo() As String
                        strTANInfo = fncGetTANInfo()

                        '監視センター担当者コード
                        If Convert.ToString(strTANInfo(0)) <> "" Then
                            hdnTKTANCD.Value = Convert.ToString(strTANInfo(0))
                            '監視センター担当者名
                            txtTKTANCD.Text = Convert.ToString(strTANInfo(0)) & "：" & Convert.ToString(strTANInfo(1))
                        End If
                    End If
                End If

                '2020/11/01 T.Ono add 2020監視改善
                '顧客検索の場合
                If strFLG = "KOKYAK" Then
                    Dim strTANInfo() As String
                    strTANInfo = fncGetTANInfo()

                    '監視センター担当者コード
                    If Convert.ToString(strTANInfo(0)) <> "" Then
                        hdnTKTANCD.Value = Convert.ToString(strTANInfo(0))
                        '監視センター担当者名
                        txtTKTANCD.Text = Convert.ToString(strTANInfo(0)) & "：" & Convert.ToString(strTANInfo(1))
                    End If
                End If

                '2014/12/16 T.Ono add 2014改善開発 No2
                If hdnJACD.Value = "" OrElse hdnJANAME.Value = "" OrElse hdnJASCD.Value = "" OrElse hdnJASNAME.Value = "" Then
                    strMsg.Append("alert('JA/JA支所が正しくない可能性があります。\n一旦終了し、支所２登録を確認してください。');")
                End If

            End If
        Catch ex As Exception
            Dim ErrMsgC As New CErrMsg
            strMsg.Append("alert('システムエラー：" & ErrMsgC.mGetArtMsg(ex.ToString) & "');")
        End Try

    End Sub

    Private Sub fncCombo_Create_Taiou()
        cboTAIOKBN.pComboTitle = True
        cboTAIOKBN.pNoData = False
        cboTAIOKBN.pType = "TAIOUKBN"               '//対応区分
        cboTAIOKBN.mMakeCombo()
    End Sub
    Private Sub fncCombo_Create_Syori()
        cboTMSKB.pComboTitle = True
        cboTMSKB.pNoData = False
        cboTMSKB.pType = "SYORIKBN"                 '//処理区分
        cboTMSKB.mMakeCombo()
    End Sub
    Private Sub fncCombo_Create_Rebrakua()
        cboTAITCD.pComboTitle = True
        cboTAITCD.pNoData = False
        cboTAITCD.pType = "RENRAKUA"                '//連絡相手
        cboTAITCD.mMakeCombo()
    End Sub
    Private Sub fncCombo_Create_Denwaren()
        cboTELRCD.pComboTitle = True
        cboTELRCD.pNoData = False
        cboTELRCD.pType = "DENWAREN"                '//電話連絡内容
        cboTELRCD.mMakeCombo()
    End Sub
    Private Sub fncCombo_Create_Hukkitai()
        cboTFKICD.pComboTitle = True
        cboTFKICD.pNoData = False
        cboTFKICD.pType = "HUKKITAI"                '//復帰状況対応
        '2019/11/01 w.ganeko mod 2019監視改善 No9-12 start
        'cboTFKICD.mMakeCombo()
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet

        ' 2023/01/11 ADD START Y.ARAKAKI 2022更改No8 _対応入力画面の対応区分＋警報メッセージ組合せのリスト絞込対応
        Dim strSQL2 As New StringBuilder("") '2022/07/29  対応区分と警報メッセージの組合せで「復帰対応状況」「原因器具」「動作原因」リスト内容を編集する。
        Dim dbData2 As DataSet               '2022/07/29  対応区分と警報メッセージの組合せで「復帰対応状況」「原因器具」「動作原因」リスト内容を編集する。
        ' 2023/01/11 ADD END   Y.ARAKAKI 2022更改No8 _対応入力画面の対応区分＋警報メッセージ組合せのリスト絞込対応
        Dim wkKeihoTaiouCds As String
        wkKeihoTaiouCds = "" '初期化

        Dim cdb As New CDB
        Dim i As Integer

        cdb.mOpen()

        strSQL.Append("SELECT ")
        strSQL.Append("CD, ")
        strSQL.Append("CD || '：' || NAME AS NAME, ")
        strSQL.Append("NAIYO1 ")
        strSQL.Append("FROM M06_PULLDOWN ")
        strSQL.Append("WHERE KBN=:KBN ")
        strSQL.Append("ORDER BY TO_NUMBER(DISP_NO),CD ")
        cdb.pSQL = strSQL.ToString
        cdb.pSQLParamStr("KBN") = "14"
        cdb.mExecQuery()
        dbData = cdb.pResult    '結果をデータセットに格納
        cdb.mClose()
        cdb = Nothing
        cboTFKICD.Items.Add(New ListItem("", ""))
        If dbData.Tables(0).Rows.Count > 0 Then
            For i = 0 To dbData.Tables(0).Rows.Count - 1
                strMsg.Append("var item = {val:'" + Convert.ToString(dbData.Tables(0).Rows(i).Item(0)) + "',txt:'" + Convert.ToString(dbData.Tables(0).Rows(i).Item(1)) + "',flg:'" + Convert.ToString(dbData.Tables(0).Rows(i).Item(2)) + "'};")
                strMsg.Append("listcboTFKICD.push(item);")
                'コンボに追加
                cboTFKICD.Items.Add(New ListItem(Convert.ToString(dbData.Tables(0).Rows(i).Item(1)),
                  Convert.ToString(dbData.Tables(0).Rows(i).Item(0))))
            Next
        End If
        '2019/11/01 w.ganeko mod 2019監視改善 No9-12 end

        '2022/07/29 ADD START Y.ARAKAKI 2022更改No8 _対応入力画面の対応区分＋警報メッセージ組合せのリスト絞込対応
        '除外対象項目を検索
        Dim cdb2 As New CDB
        cdb2.mOpen()

        strSQL2.Append("SELECT ")
        strSQL2.Append("CD, ")
        strSQL2.Append("NAIYO1 ")
        strSQL2.Append("FROM M06_PULLDOWN ")
        strSQL2.Append("WHERE KBN=:KBN ")
        strSQL2.Append("ORDER BY TO_NUMBER(DISP_NO),CD ")
        cdb2.pSQL = strSQL2.ToString
        cdb2.pSQLParamStr("KBN") = "82" '82：復帰対応状況（表示除外対象）
        cdb2.mExecQuery()
        dbData2 = cdb2.pResult    '結果をデータセットに格納
        cdb2.mClose()
        cdb2 = Nothing
        If dbData2.Tables(0).Rows.Count > 0 Then
            For i = 0 To dbData2.Tables(0).Rows.Count - 1
                wkKeihoTaiouCds = Convert.ToString(dbData2.Tables(0).Rows(i).Item(0)) '分割前に共通値を取得(20220729時点で、3桁想定)
                strMsg.Append(
                      "var item = {keihoMsgNo:'" + Strings.Left(wkKeihoTaiouCds, 2) _
                    + "',taioKbnNo:'" + Strings.Mid(wkKeihoTaiouCds, 3) _
                    + "',removeNo:'" + Convert.ToString(dbData2.Tables(0).Rows(i).Item(1)) + "'};")
                strMsg.Append("listRemoveCheckTFKICD.push(item);")
            Next
        End If
        '2022/07/29 ADD END Y.ARAKAKI 2022更改No8 _対応入力画面の対応区分＋警報メッセージ組合せのリスト絞込対応

    End Sub
    Private Sub fncCombo_Create_Gakukigu() '原因器具リストの取得はここ。（プルダウンマスタ区分＝'16'）
        '2021/10/01DELsaka2021年度監視改善 START シンプルにプルダウンマスタから項目を引っ張る処理を削除②したが戻す(20211105)
        cboTKIGCD.pComboTitle = True
        cboTKIGCD.pNoData = False
        cboTKIGCD.pType = "GAKUKIGU"                '//ガス器具 2021/10/01なんでGAKUKIGU(GASUKIGUじゃないの？)なのか不明だが変えるのはやめておく

        '2022/07/29 MOD START Y.Arakaki 2022更改No8 _対応入力画面の対応区分＋警報メッセージ組合せのリスト絞込対応
        '既存のリストボックス取得（共通処理）ではなく、ここで原因器具の全項目リストと除外リストを検索し、画面にjs宣言で保持させる。
        'リスト内容の切替は、画面上（JS処理）のみで行い、このVB処理には戻ってこない。
        'cboTKIGCD.mMakeCombo()

        '全項目検索用
        Dim strSQL1 As New StringBuilder("")
        Dim dbData1 As DataSet
        Dim cdb As New CDB

        '除外項目検索用
        Dim strSQL2 As New StringBuilder("")
        Dim dbData2 As DataSet
        Dim cdb2 As New CDB

        'DB処理共通
        Dim i As Integer

        '原因器具(全項目)検索SQL ※共通処理CTLCombo.vbのSQLメソッドはprivate設定で呼び出せない為、独自実装。
        'フラグ管理等はしてない為、コードと名前のみ取得。(やってることは共通処理と同じ)
        cdb.mOpen()
        strSQL1.Append("SELECT ")
        strSQL1.Append("MS.CD AS CD,")
        strSQL1.Append("MS.CD || '：' || MS.NAME AS NAME ")
        strSQL1.Append("FROM ")
        strSQL1.Append("M06_PULLDOWN MS ")
        strSQL1.Append("WHERE MS.KBN=:KBN ")
        strSQL1.Append("ORDER BY TO_NUMBER(MS.DISP_NO), MS.CD")
        cdb.pSQL = strSQL1.ToString
        cdb.pSQLParamStr("KBN") = "16"  '16:ガス器具（画面上では原因器具としてリスト表示。）
        cdb.mExecQuery()
        dbData1 = cdb.pResult     '結果をデータセット格納
        cdb.mClose()
        cdb = Nothing

        'ここが共通処理と違うやりたいこと。：リスト内容を設定しつつ、全項目(編集用バックアップ)を画面jsリストに設定。
        cboTKIGCD.Items.Add(New ListItem("", "")) 'リスト編集1行目は空行を設定。
        If dbData1.Tables(0).Rows.Count > 0 Then
            For i = 0 To dbData1.Tables(0).Rows.Count - 1

                strMsg.Append("var item = {val:'" + Convert.ToString(dbData1.Tables(0).Rows(i).Item(0)) + "',txt:'" + Convert.ToString(dbData1.Tables(0).Rows(i).Item(1)) + "'};")
                strMsg.Append("listcboTKIGCD.push(item);")
                'コンボに追加
                cboTKIGCD.Items.Add(New ListItem(Convert.ToString(dbData1.Tables(0).Rows(i).Item(1)),
                  Convert.ToString(dbData1.Tables(0).Rows(i).Item(0))))
            Next
        End If


        '原因器具(除外対象項目)検索SQL 
        cdb2.mOpen()
        strSQL2.Append("SELECT ")
        strSQL2.Append("CD, ")
        strSQL2.Append("NAIYO1 ")
        strSQL2.Append("FROM M06_PULLDOWN ")
        strSQL2.Append("WHERE KBN=:KBN ")
        strSQL2.Append("ORDER BY TO_NUMBER(DISP_NO),CD ")
        cdb2.pSQL = strSQL2.ToString
        cdb2.pSQLParamStr("KBN") = "83" '83：原因器具（表示除外対象）
        cdb2.mExecQuery()
        dbData2 = cdb2.pResult    '結果をデータセットに格納
        cdb2.mClose()
        cdb2 = Nothing
        Dim wkKeihoTaiouCds As String
        wkKeihoTaiouCds = "" '初期化
        If dbData2.Tables(0).Rows.Count > 0 Then
            For i = 0 To dbData2.Tables(0).Rows.Count - 1
                wkKeihoTaiouCds = Convert.ToString(dbData2.Tables(0).Rows(i).Item(0)) '分割前に共通値を取得(20220729時点で、3桁想定)
                strMsg.Append(
                      "var item = {keihoMsgNo:'" + Strings.Left(wkKeihoTaiouCds, 2) _
                    + "',taioKbnNo:'" + Strings.Mid(wkKeihoTaiouCds, 3) _
                    + "',removeNo:'" + Convert.ToString(dbData2.Tables(0).Rows(i).Item(1)) + "'};")
                strMsg.Append("listRemoveCheckTKIGCD.push(item);")
            Next
        End If
        '2022/07/29 MOD END Y.Arakaki 2022更改No8 _対応入力画面の対応区分＋警報メッセージ組合せのリスト絞込対応

    End Sub
    Private Sub fncCombo_Create_Sadougen()
        '2020/11/01 T.Ono 監視改善2020 Start
        'cboTSADCD.pComboTitle = True
        'cboTSADCD.pNoData = False
        'If hdnKMCD1.Value.Length = 0 Then
        '    cboTSADCD.pType = "SADOUGEN"                '//作動原因
        'Else
        '    cboTSADCD.pKeihocd = hdnKMCD1.Value         '//第一警報コードをセット
        '    cboTSADCD.pType = "KEIHOUSADOU"             '//作動原因(警報メッセージ制御有り)
        'End If

        'cboTSADCD.mMakeCombo()

        Dim strSQL1 As New StringBuilder("")
        'Dim strSQL2 As New StringBuilder("")      '2023/09/15 DEL Y.ARAKAKI プルダウン区分59（作動原因リスト表示絞込）の完全無効化対応
        Dim dbData1 As DataSet
        'Dim dbData2 As DataSet                    '2023/09/15 DEL Y.ARAKAKI プルダウン区分59（作動原因リスト表示絞込）の完全無効化対応
        Dim cdb As New CDB
        Dim i As Integer

        cboTSADCD.Items.Add(New ListItem("", ""))

        cdb.mOpen()

        '2022/08/10 ADD START Y.Arakaki 2022更改No8 _対応入力画面の対応区分＋警報メッセージ組合せのリスト絞込対応
        '2023/01/18 DEL START Y.ARAKAKI No8追加修正 プルダウン区分59による制限表示設定を不使用とし、今後区分84の除外項目のみで制御するよう修正。
        'Dim strSQLViewList As New StringBuilder("")
        'Dim dbDataViewList As DataSet
        'strSQLViewList.Append("SELECT ")
        'strSQLViewList.Append(" SUBSTR(M06A.CD,1,2) AS KEIKOKU_NO ")  '警告メッセージNo
        'strSQLViewList.Append(" ,LISTAGG(SUBSTR(M06A.CD,3,2), ',') WITHIN GROUP (ORDER BY SUBSTR(M06A.CD,1,2)) AS SADOUGENIN_NO_LIST ") '作動原因カンマ区切り（警告Noごと）
        'strSQLViewList.Append("FROM ")
        'strSQLViewList.Append("  M06_PULLDOWN M06A ")
        'strSQLViewList.Append("WHERE ")
        'strSQLViewList.Append("  M06A.KBN='59' ") '区分：絞り込み表示
        'strSQLViewList.Append("  AND EXISTS(")
        'strSQLViewList.Append("    SELECT 1 FROM M06_PULLDOWN M06B_SADOU ")
        'strSQLViewList.Append("    WHERE ")
        'strSQLViewList.Append("      M06B_SADOU.KBN='17' ") '区分17（作動原因）
        'strSQLViewList.Append("      AND M06B_SADOU.CD=SUBSTR(M06A.CD,3,2)")
        'strSQLViewList.Append("    ) ")
        'strSQLViewList.Append("GROUP BY ")
        'strSQLViewList.Append("  SUBSTR(M06A.CD,1,2) ") '警告Noでグループ化
        'cdb.pSQL = strSQLViewList.ToString
        'cdb.mExecQuery()
        'dbDataViewList = cdb.pResult    '結果をデータセットに格納
        'If dbDataViewList.Tables(0).Rows.Count > 0 Then
        '    For i = 0 To dbDataViewList.Tables(0).Rows.Count - 1
        '        strMsg.Append(
        '              "var item = {keihoMsgNo:'" + Convert.ToString(dbDataViewList.Tables(0).Rows(i).Item(0)) _
        '            + "',viewNo:'" + Convert.ToString(dbDataViewList.Tables(0).Rows(i).Item(1)) + "'};")
        '        strMsg.Append("listViewCheckTSADCD.push(item);")
        '    Next
        'End If
        '2023/01/18 DEL END   Y.ARAKAKI No8追加修正 プルダウン区分59による制限表示設定を不使用とし、今後区分84の除外項目のみで制御するよう修正。

        '作動原因(除外対象項目)検索SQL 
        Dim strSQLRemoveList As New StringBuilder("")
        Dim dbDataRemoveList As DataSet
        strSQLRemoveList.Append("SELECT ")
        strSQLRemoveList.Append("CD, ")
        strSQLRemoveList.Append("NAIYO1 ")
        strSQLRemoveList.Append("FROM M06_PULLDOWN ")
        strSQLRemoveList.Append("WHERE KBN=:KBN ")
        strSQLRemoveList.Append("ORDER BY TO_NUMBER(DISP_NO),CD ")
        cdb.pSQL = strSQLRemoveList.ToString
        cdb.pSQLParamStr("KBN") = "84" '84：作動原因（表示除外対象）
        cdb.mExecQuery()
        dbDataRemoveList = cdb.pResult    '結果をデータセットに格納
        Dim wkSadouGenninCds As String
        wkSadouGenninCds = "" '初期化
        If dbDataRemoveList.Tables(0).Rows.Count > 0 Then
            For i = 0 To dbDataRemoveList.Tables(0).Rows.Count - 1
                wkSadouGenninCds = Convert.ToString(dbDataRemoveList.Tables(0).Rows(i).Item(0)) '分割前に共通値を取得(20220729時点で、3桁想定)
                strMsg.Append(
                      "var item = {keihoMsgNo:'" + Strings.Left(wkSadouGenninCds, 2) _
                    + "',taioKbnNo:'" + Strings.Mid(wkSadouGenninCds, 3) _
                    + "',removeNo:'" + Convert.ToString(dbDataRemoveList.Tables(0).Rows(i).Item(1)) + "'};")
                strMsg.Append("listRemoveCheckTSADCD.push(item);")
            Next
        End If
        '2022/08/10 ADD END Y.Arakaki 2022更改No8 _対応入力画面の対応区分＋警報メッセージ組合せのリスト絞込対応


        '全作動原因
        strSQL1.Append("SELECT ")
        strSQL1.Append("MS.CD AS CD,")
        strSQL1.Append("MS.CD || '：' || MS.NAME AS NAME ")
        strSQL1.Append("FROM ")
        strSQL1.Append("M06_PULLDOWN MS ")
        strSQL1.Append("WHERE MS.KBN='17'")
        strSQL1.Append("ORDER BY TO_NUMBER(MS.DISP_NO), MS.CD")

        '全作動原因取得
        cdb.pSQL = strSQL1.ToString
        cdb.mExecQuery()
        dbData1 = cdb.pResult    '結果をデータセットに格納

        '2023/09/15 DEL START Y.ARAKAKI プルダウン区分59（作動原因リスト表示絞込）の完全無効化対応
        ''作動原因(メッセージ制御有り)
        'strSQL2.Append("SELECT ")
        'strSQL2.Append("MS.CD AS CD,")
        'strSQL2.Append("MS.CD || '：' || MS.NAME AS NAME ")
        'strSQL2.Append("FROM ")
        'strSQL2.Append("M06_PULLDOWN KH,")
        'strSQL2.Append("M06_PULLDOWN MS ")
        'strSQL2.Append("WHERE KH.KBN='59'")
        'strSQL2.Append("  AND SUBSTR(KH.CD,1,2) = :KEIHOCD")
        'strSQL2.Append("  AND MS.KBN='17'")
        'strSQL2.Append("  AND MS.CD = SUBSTR(KH.CD,3,2)")
        'strSQL2.Append("ORDER BY TO_NUMBER(MS.DISP_NO), MS.CD")
        '2023/09/15 DEL END   Y.ARAKAKI プルダウン区分59（作動原因リスト表示絞込）の完全無効化対応

        hdnTSADCD1.Value = ""
        '2023/09/15 DEL START Y.ARAKAKI プルダウン区分59（作動原因リスト表示絞込）の完全無効化対応
        ''警報１
        'If hdnKMCD1.Value.Length <> 0 Then
        '    '作動原因(メッセージ制御有り)を検索
        '    cdb.pSQL = strSQL2.ToString
        '    cdb.pSQLParamStr("KEIHOCD") = hdnKMCD1.Value
        '    cdb.mExecQuery()
        '    dbData2 = cdb.pResult    '結果をデータセットに格納

        'End If
        '2023/09/15 DEL END   Y.ARAKAKI プルダウン区分59（作動原因リスト表示絞込）の完全無効化対応



        '警報なし、または、ﾒｯｾｰｼﾞ制御なし
        'If hdnKMCD1.Value.Length = 0 OrElse dbData2.Tables(0).Rows.Count = 0 Then  '2023/09/15 DEL Y.ARAKAKI プルダウン区分59（作動原因リスト表示絞込）の完全無効化対応
        '全作動原因をセットする
        For i = 0 To dbData1.Tables(0).Rows.Count - 1
            strMsg.Append("var item = {val:'" + Convert.ToString(dbData1.Tables(0).Rows(i).Item(0)) + "',txt:'" _
                              + Convert.ToString(dbData1.Tables(0).Rows(i).Item(1)) + "'};")
            strMsg.Append("listcboTSADCD1.push(item);")
            'コンボに追加
            cboTSADCD.Items.Add(New ListItem(Convert.ToString(dbData1.Tables(0).Rows(i).Item(1)),
                      Convert.ToString(dbData1.Tables(0).Rows(i).Item(0))))
        Next
        '2023/09/15 DEL START Y.ARAKAKI プルダウン区分59（作動原因リスト表示絞込）の完全無効化対応
        'Else
        '    '作動原因(メッセージ制御有り)をセットする
        '    For i = 0 To dbData2.Tables(0).Rows.Count - 1
        '        strMsg.Append("var item = {val:'" + Convert.ToString(dbData2.Tables(0).Rows(i).Item(0)) + "',txt:'" _
        '                      + Convert.ToString(dbData2.Tables(0).Rows(i).Item(1)) + "'};")
        '        strMsg.Append("listcboTSADCD1.push(item);")
        '        'コンボに追加
        '        cboTSADCD.Items.Add(New ListItem(Convert.ToString(dbData2.Tables(0).Rows(i).Item(1)),
        '              Convert.ToString(dbData2.Tables(0).Rows(i).Item(0))))
        '    Next
        'End If
        '2023/09/15 DEL END   Y.ARAKAKI プルダウン区分59（作動原因リスト表示絞込）の完全無効化対応

        '2023/09/15 DEL START Y.ARAKAKI プルダウン区分59（作動原因リスト表示絞込）の完全無効化対応
        ''警報２
        ''警報あり
        'If hdnKMCD2.Value.Length <> 0 Then
        '    '作動原因(メッセージ制御有り)を検索
        '    cdb.pSQL = strSQL2.ToString
        '    cdb.pSQLParamStr("KEIHOCD") = hdnKMCD2.Value
        '    cdb.mExecQuery()
        '    dbData2 = cdb.pResult    '結果をデータセットに格納

        'End If
        '2023/09/15 DEL END   Y.ARAKAKI プルダウン区分59（作動原因リスト表示絞込）の完全無効化対応

        '警報なし、または、ﾒｯｾｰｼﾞ制御なし
        'If hdnKMCD2.Value.Length = 0 OrElse dbData2.Tables(0).Rows.Count = 0 Then '2023/09/15 DEL Y.ARAKAKI プルダウン区分59（作動原因リスト表示絞込）の完全無効化対応
        '全作動原因をセットする
        For i = 0 To dbData1.Tables(0).Rows.Count - 1
            strMsg.Append("var item = {val:'" + Convert.ToString(dbData1.Tables(0).Rows(i).Item(0)) + "',txt:'" _
                              + Convert.ToString(dbData1.Tables(0).Rows(i).Item(1)) + "'};")
            strMsg.Append("listcboTSADCD2.push(item);")
        Next
        '2023/09/15 DEL START Y.ARAKAKI プルダウン区分59（作動原因リスト表示絞込）の完全無効化対応
        'Else
        '    '作動原因(メッセージ制御有り)をセットする
        '    For i = 0 To dbData2.Tables(0).Rows.Count - 1
        '        strMsg.Append("var item = {val:'" + Convert.ToString(dbData2.Tables(0).Rows(i).Item(0)) + "',txt:'" _
        '                      + Convert.ToString(dbData2.Tables(0).Rows(i).Item(1)) + "'};")
        '        strMsg.Append("listcboTSADCD2.push(item);")
        '    Next
        'End If
        '2023/09/15 DEL END   Y.ARAKAKI プルダウン区分59（作動原因リスト表示絞込）の完全無効化対応

        '2023/09/15 DEL START Y.ARAKAKI プルダウン区分59（作動原因リスト表示絞込）の完全無効化対応
        ''警報３
        ''警報あり
        'If hdnKMCD3.Value.Length <> 0 Then
        '    '作動原因(メッセージ制御有り)を検索
        '    cdb.pSQL = strSQL2.ToString
        '    cdb.pSQLParamStr("KEIHOCD") = hdnKMCD3.Value
        '    cdb.mExecQuery()
        '    dbData2 = cdb.pResult    '結果をデータセットに格納

        'End If
        '2023/09/15 DEL END   Y.ARAKAKI プルダウン区分59（作動原因リスト表示絞込）の完全無効化対応

        '警報なし、または、ﾒｯｾｰｼﾞ制御なし
        'If hdnKMCD3.Value.Length = 0 OrElse dbData2.Tables(0).Rows.Count = 0 Then '2023/09/15 DEL Y.ARAKAKI プルダウン区分59（作動原因リスト表示絞込）の完全無効化対応
        '全作動原因をセットする
        For i = 0 To dbData1.Tables(0).Rows.Count - 1
            strMsg.Append("var item = {val:'" + Convert.ToString(dbData1.Tables(0).Rows(i).Item(0)) + "',txt:'" _
                              + Convert.ToString(dbData1.Tables(0).Rows(i).Item(1)) + "'};")
            strMsg.Append("listcboTSADCD3.push(item);")
        Next
        '2023/09/15 DEL START Y.ARAKAKI プルダウン区分59（作動原因リスト表示絞込）の完全無効化対応
        'Else
        '    '作動原因(メッセージ制御有り)をセットする
        '    For i = 0 To dbData2.Tables(0).Rows.Count - 1
        '        strMsg.Append("var item = {val:'" + Convert.ToString(dbData2.Tables(0).Rows(i).Item(0)) + "',txt:'" _
        '                      + Convert.ToString(dbData2.Tables(0).Rows(i).Item(1)) + "'};")
        '        strMsg.Append("listcboTSADCD3.push(item);")
        '    Next
        'End If
        '2023/09/15 DEL END   Y.ARAKAKI プルダウン区分59（作動原因リスト表示絞込）の完全無効化対応

        '2023/09/15 DEL START Y.ARAKAKI プルダウン区分59（作動原因リスト表示絞込）の完全無効化対応
        ''警報４
        ''警報あり
        'If hdnKMCD4.Value.Length <> 0 Then
        '    '作動原因(メッセージ制御有り)を検索
        '    cdb.pSQL = strSQL2.ToString
        '    cdb.pSQLParamStr("KEIHOCD") = hdnKMCD4.Value
        '    cdb.mExecQuery()
        '    dbData2 = cdb.pResult    '結果をデータセットに格納

        'End If
        '2023/09/15 DEL END   Y.ARAKAKI プルダウン区分59（作動原因リスト表示絞込）の完全無効化対応

        '警報なし、または、ﾒｯｾｰｼﾞ制御なし
        'If hdnKMCD4.Value.Length = 0 OrElse dbData2.Tables(0).Rows.Count = 0 Then '2023/09/15 DEL Y.ARAKAKI プルダウン区分59（作動原因リスト表示絞込）の完全無効化対応
        '全作動原因をセットする
        For i = 0 To dbData1.Tables(0).Rows.Count - 1
            strMsg.Append("var item = {val:'" + Convert.ToString(dbData1.Tables(0).Rows(i).Item(0)) + "',txt:'" _
                              + Convert.ToString(dbData1.Tables(0).Rows(i).Item(1)) + "'};")
            strMsg.Append("listcboTSADCD4.push(item);")
        Next
        '2023/09/15 DEL START Y.ARAKAKI プルダウン区分59（作動原因リスト表示絞込）の完全無効化対応
        'Else
        '    '作動原因(メッセージ制御有り)をセットする
        '    For i = 0 To dbData2.Tables(0).Rows.Count - 1
        '        strMsg.Append("var item = {val:'" + Convert.ToString(dbData2.Tables(0).Rows(i).Item(0)) + "',txt:'" _
        '                      + Convert.ToString(dbData2.Tables(0).Rows(i).Item(1)) + "'};")
        '        strMsg.Append("listcboTSADCD4.push(item);")
        '    Next
        'End If
        '2023/09/15 DEL END   Y.ARAKAKI プルダウン区分59（作動原因リスト表示絞込）の完全無効化対応

        '2023/09/15 DEL START Y.ARAKAKI プルダウン区分59（作動原因リスト表示絞込）の完全無効化対応
        ''警報５
        ''警報あり
        'If hdnKMCD5.Value.Length <> 0 Then
        '    '作動原因(メッセージ制御有り)を検索
        '    cdb.pSQL = strSQL2.ToString
        '    cdb.pSQLParamStr("KEIHOCD") = hdnKMCD5.Value
        '    cdb.mExecQuery()
        '    dbData2 = cdb.pResult    '結果をデータセットに格納

        'End If
        '2023/09/15 DEL END   Y.ARAKAKI プルダウン区分59（作動原因リスト表示絞込）の完全無効化対応

        '警報なし、または、ﾒｯｾｰｼﾞ制御なし
        'If hdnKMCD5.Value.Length = 0 OrElse dbData2.Tables(0).Rows.Count = 0 Then '2023/09/15 DEL Y.ARAKAKI プルダウン区分59（作動原因リスト表示絞込）の完全無効化対応
        '全作動原因をセットする
        For i = 0 To dbData1.Tables(0).Rows.Count - 1
            strMsg.Append("var item = {val:'" + Convert.ToString(dbData1.Tables(0).Rows(i).Item(0)) + "',txt:'" _
                              + Convert.ToString(dbData1.Tables(0).Rows(i).Item(1)) + "'};")
            strMsg.Append("listcboTSADCD5.push(item);")
        Next
        '2023/09/15 DEL START Y.ARAKAKI プルダウン区分59（作動原因リスト表示絞込）の完全無効化対応
        'Else
        '    '作動原因(メッセージ制御有り)をセットする
        '    For i = 0 To dbData2.Tables(0).Rows.Count - 1
        '        strMsg.Append("var item = {val:'" + Convert.ToString(dbData2.Tables(0).Rows(i).Item(0)) + "',txt:'" _
        '                      + Convert.ToString(dbData2.Tables(0).Rows(i).Item(1)) + "'};")
        '        strMsg.Append("listcboTSADCD5.push(item);")
        '    Next
        'End If
        '2023/09/15 DEL END   Y.ARAKAKI プルダウン区分59（作動原因リスト表示絞込）の完全無効化対応

        '2023/09/15 DEL START Y.ARAKAKI プルダウン区分59（作動原因リスト表示絞込）の完全無効化対応
        ''警報６
        ''警報あり
        'If hdnKMCD6.Value.Length <> 0 Then
        '    '作動原因(メッセージ制御有り)を検索
        '    cdb.pSQL = strSQL2.ToString
        '    cdb.pSQLParamStr("KEIHOCD") = hdnKMCD6.Value
        '    cdb.mExecQuery()
        '    dbData2 = cdb.pResult    '結果をデータセットに格納

        'End If
        '2023/09/15 DEL END   Y.ARAKAKI プルダウン区分59（作動原因リスト表示絞込）の完全無効化対応

        '警報なし、または、ﾒｯｾｰｼﾞ制御なし
        'If hdnKMCD6.Value.Length = 0 OrElse dbData2.Tables(0).Rows.Count = 0 Then '2023/09/15 DEL Y.ARAKAKI プルダウン区分59（作動原因リスト表示絞込）の完全無効化対応
        '全作動原因をセットする
        For i = 0 To dbData1.Tables(0).Rows.Count - 1
            strMsg.Append("var item = {val:'" + Convert.ToString(dbData1.Tables(0).Rows(i).Item(0)) + "',txt:'" _
                              + Convert.ToString(dbData1.Tables(0).Rows(i).Item(1)) + "'};")
            strMsg.Append("listcboTSADCD6.push(item);")
        Next
        '2023/09/15 DEL START Y.ARAKAKI プルダウン区分59（作動原因リスト表示絞込）の完全無効化対応
        'Else
        '    '作動原因(メッセージ制御有り)をセットする
        '    For i = 0 To dbData2.Tables(0).Rows.Count - 1
        '        strMsg.Append("var item = {val:'" + Convert.ToString(dbData2.Tables(0).Rows(i).Item(0)) + "',txt:'" _
        '                      + Convert.ToString(dbData2.Tables(0).Rows(i).Item(1)) + "'};")
        '        strMsg.Append("listcboTSADCD6.push(item);")
        '    Next
        'End If
        '2023/09/15 DEL END   Y.ARAKAKI プルダウン区分59（作動原因リスト表示絞込）の完全無効化対応


        '警報を変更したときのために。
        For i = 0 To dbData1.Tables(0).Rows.Count - 1
            strMsg.Append("var item = {val:'" + Convert.ToString(dbData1.Tables(0).Rows(i).Item(0)) + "',txt:'" _
                          + Convert.ToString(dbData1.Tables(0).Rows(i).Item(1)) + "'};")
            strMsg.Append("listcboTSADCD0.push(item);")
        Next


        '2020/11/01 T.Ono 監視改善2020 End
    End Sub
    Private Sub fncCombo_Create_Syutusij()
        cboSDCD.pComboTitle = True
        cboSDCD.pNoData = False
        cboSDCD.pType = "SYUTUSIJ"                 '//出動指示内容
        cboSDCD.mMakeCombo()
    End Sub

    '2022/12/08 ADD START Y.Arakaki 2022更改No⑦ _特定警報メッセージNo選択時のリスト自動選択対応
    '******************************************************************************
    '*　概　要：自動選択リスト取得処理（特定の警報メッセージNo選択時、画面の複数リスト項目を自動選択できるよう編集値を持たせる。）
    '*　備　考：自動選択対象の警報メッセージNoと自動選択先リストのプルダウンマスタ毎CDは、JavaScript側で固定値使用している為、
    '*　      ：警報Noや自動選択先の追加対応が発生したらvbとJsどちらも修正すること。
    '******************************************************************************
    Private Sub fncCombo_Get_JidouSentakuList()
        Dim cdb As New CDB
        Dim i As Integer

        cdb.mOpen()

        Dim strSQLJidowSentakuList As New StringBuilder("")
        Dim dbDataJidowSentakuList As DataSet
        strSQLJidowSentakuList.Append("SELECT ")
        strSQLJidowSentakuList.Append("  MP.CD  ")    '警告メッセージNo
        strSQLJidowSentakuList.Append(" ,MP.NAIYO1 ") '自動選択リスト（対象のプルダウンリストNo2桁＋リスト内容2桁、をカンマ区切り管理）
        strSQLJidowSentakuList.Append("FROM ")
        strSQLJidowSentakuList.Append("  M06_PULLDOWN MP ")
        strSQLJidowSentakuList.Append("WHERE ")
        strSQLJidowSentakuList.Append("  MP.KBN='86' ") '区分：警報No毎のリスト自動選択
        strSQLJidowSentakuList.Append("  AND MP.CD NOT LIKE 'X%' ") 'X始まりのCDレコードはただのコメント用コードで使用不可のため、検索から除外。
        strSQLJidowSentakuList.Append("ORDER BY MP.CD ")
        cdb.pSQL = strSQLJidowSentakuList.ToString
        cdb.mExecQuery()
        dbDataJidowSentakuList = cdb.pResult    '結果をデータセットに格納
        If dbDataJidowSentakuList.Tables(0).Rows.Count > 0 Then
            For i = 0 To dbDataJidowSentakuList.Tables(0).Rows.Count - 1
                strMsg.Append(
                      "var item = {keihoMsgNo:'" + Convert.ToString(dbDataJidowSentakuList.Tables(0).Rows(i).Item(0)) _
                    + "',jidouSentakuList:'" + Convert.ToString(dbDataJidowSentakuList.Tables(0).Rows(i).Item(1)) + "'};")
                strMsg.Append("listKeihouJidouSentakuCD.push(item);")
            Next
        End If

    End Sub
    '2022/12/08 ADD END   Y.Arakaki 2022更改No⑦ _特定警報メッセージNo選択時のリスト自動選択対応

    '******************************************************************************
    '*　概　要：分割テキスト出力時に使用（引数(例:コロン)で区切る）
    '*　備　考：
    '******************************************************************************
    Private Function fncEditCutMsg(ByVal strCd As String, ByVal strMsg As String, ByVal strCut As String) As String
        Dim strRec As String
        If strCd.Length = 0 Then
            '2014/12/16 T.Ono mod 2014改善開発 No2
            'strRec = ""
            strRec = strMsg
        Else
            strRec = strCd & strCut & strMsg
        End If
        Return strRec
    End Function

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

    '******************************************************************************
    '*　概　要：指針等出力時に使用（右から数えた場合の桁数を小数以下桁数とする）
    '*　備　考：ただし数値の場合のみ、数値でない場合はそのままの値を返す
    '******************************************************************************
    '2005/11/22 NEC UPDATE START
    '    Private Function fncEditSisin(ByVal strSisin As String) As String
    Private Function fncEditSisin(ByVal strSisin As String, ByVal intKeta As Integer) As String
        '2005/11/22 NEC UPDATE END
        Dim strRec As String
        Dim NaNFncC As New CNaNFnc
        If IsNumeric(strSisin) = True Then
            If strSisin.Length = 0 Then
                strRec = ""
                '2005/11/22 NEC ADD START
                '小数点が含まれていたらそのまま値を返す
            ElseIf InStr(strSisin, ".") > 0 Then
                strRec = strSisin
                '2005/11/22 NEC ADD END
            ElseIf strSisin.Length = 1 Then
                '2005/11/22 NEC UPDATE START
                'strRec = "0." & strSisin
                strRec = Convert.ToString(Convert.ToDecimal(strSisin) / 10D ^ Convert.ToDecimal(intKeta))
                '2005/11/22 NEC UPDATE END
            Else
                '2005/11/22 NEC UPDATE START
                'strRec = strSisin
                'strRec = Left(strRec, strRec.Length - 1) & "." & Right(strRec, 1)
                'ゼロ埋め
                strRec = strSisin.PadLeft(8 - strSisin.Length, "0"c)
                strRec = Left(strRec, strRec.Length - intKeta) & "." & Right(strRec, intKeta)
                If intKeta = 1 Then
                    strRec = Format(Convert.ToDecimal(strRec), "##,###,##0.0")
                ElseIf intKeta = 3 Then
                    strRec = Format(Convert.ToDecimal(strRec), "##,###,##0.000")
                End If
                '2005/11/22 NEC UPDATE END
                '2005/11/22 NEC DEL START
                'strRec = NaNFncC.mGet(strRec, 1)
                '2005/11/22 NEC DEL START
            End If
        Else
            strRec = strSisin
        End If

        Return strRec
    End Function

    '******************************************************************************
    '*　概　要：下１桁を小数点とする数値型に変換する
    '*　備　考：
    '******************************************************************************
    Private Function fncEditSisinDec(ByVal strSisin As String) As Decimal
        Dim strRec As String
        If IsNumeric(strSisin) = True Then
            If strSisin.Length = 0 Then
                '20050729 NEC udpate START
                '                strRec = ""
                strRec = "0"
                '20050729 NEC udpate END
            ElseIf strSisin.Length = 1 Then
                strRec = "0." & strSisin
            Else
                strRec = strSisin
                strRec = Left(strRec, strRec.Length - 1) & "." & Right(strRec, 1)
            End If
        Else
            strRec = strSisin
        End If
        '20050729 NEC ADD START
        If IsNumeric(strRec) = False Then
            strRec = "0"
        End If
        '20050729 NEC ADD STOP

        Return CDec(strRec)
    End Function

    '******************************************************************************
    '*　概　要：指針等受取(登録)時に使用（最後１桁を小数以下を元に戻す）
    '*　備　考：ただし数値の場合のみ、数値でない場合はそのままの値を返す
    '******************************************************************************
    '2005/11/22 NEC UPDATE START
    'Private Function fncHenkanSisin(ByVal strSisin As String) As String
    Private Function fncHenkanSisin(ByVal strSisin As String, Optional ByVal intKeta As Integer = 1) As String
        '2005/11/22 NEC UPDATE END
        Dim strRec As String
        Dim NaNFncC As New CNaNFnc
        '2005/11/22 NEC ADD START
        If intKeta = 1 Then
            '2005/11/22 NEC ADD END

            strRec = NaNFncC.mHenkanGet(strSisin)
            If IsNumeric(strRec) = True Then
                strRec = CStr(CInt(CDec(strRec) * 10))
            Else
                strRec = strSisin
            End If
            '2005/11/22 NEC ADD START
        ElseIf intKeta = 3 Then
            strRec = NaNFncC.mHenkanGet(strSisin)
            If IsNumeric(strRec) = True Then
                strRec = CStr(CInt(CDec(strRec) * 1000))
            Else
                strRec = strSisin
            End If
        End If
        '2005/11/22 NEC ADD END

        Return strRec
    End Function

    '******************************************************************************
    '******************************************************************************
    '******************************************************************************
    '*　概　要：hdnBackUrlの値を渡すプロパティ
    '*　備　考：遷移元の画面によってチェックを制御する
    '******************************************************************************
    Public ReadOnly Property pBackUrl() As String
        Get
            Return hdnBackUrl.Value
        End Get
    End Property

    '******************************************************************************
    '*　概　要：hdnKEY_SERIALの値を渡すプロパティ
    '*　備　考：監視パネルより遷移時使用する
    '******************************************************************************
    Public ReadOnly Property pMoveSerial() As String
        Get
            Return hdnKEY_SERIAL.Value
        End Get
    End Property

    '******************************************************************************
    '*　概　要：絞込み条件を渡すプロパティ
    '*　備　考：抽出条件１の値を渡す
    '******************************************************************************
    Public ReadOnly Property pCode1() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                '監視センターコードフラグ("0"未決定 "1"決定)
                If hdnKANSFLG.Value = "1" Then
                    strRec = hdnKANSCD.Value            '//クライアントコード一覧　データが決まっているのでその監視センターコード
                Else
                    strRec = AuthC.pAUTHCENTERCD        '//クライアントコード一覧　ＡＤ認証の使用可能監視センターコード
                End If
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = txtClientCD.Text           '//ＪＡ/ＪＡ支所コード一覧 クライアントコードを渡す
            ElseIf hdnPopcrtl.Value = "3" Then
                'strRec = txtClientCD.Text           '//監視担当者一覧 クライアントコードを渡す 2007/08/09 T.Watabe edit 代行対応
                'strRec = AuthC.pAUTHCENTERCD        '//監視担当者一覧　ＡＤ認証の使用可能監視センターコード 2007/08/09 T.Watabe edit 代行対応
                'strRec = AuthC.pCENTERCD            '//監視担当者一覧　自分の監視センターコード
                ''運行開発部の場合は全ての監視センターの監視担当者を選択可能
                ''以外の場合は代行を使用せずに自分の監視センターの監視担当者のみ使用可能
                Dim strGROUPNAME As String = AuthC.pGROUPNAME
                Dim arrGroupName() As String = strGROUPNAME.Split(Convert.ToChar(","))
                If Array.IndexOf(arrGroupName, AuthC.pGROUP_UNKOU) >= 0 Then
                    strRec = AuthC.pAUTHCENTERCD
                Else
                    strRec = AuthC.pCENTERCD
                End If
            ElseIf hdnPopcrtl.Value = "11" Or _
                    hdnPopcrtl.Value = "12" Or _
                    hdnPopcrtl.Value = "13" Or _
                    hdnPopcrtl.Value = "14" Or _
                    hdnPopcrtl.Value = "15" Or _
                    hdnPopcrtl.Value = "16" Then      '// 警報メッセージ(PULLCODE)コード一覧
                strRec = "70"                         '//警報メッセージ一覧 KBN=70を渡す 2007/04/19
            ElseIf hdnPopcrtl.Value = "21" Then      '// 発生区分(PULLCODE)コード一覧 2007/04/25
                strRec = "08"
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：出力する一覧の名前を渡すプロパティ
    '*　備　考：ポップアップのタイトル名を渡す
    '******************************************************************************
    Public ReadOnly Property pListName() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then          '//クライアントコード一覧
                strRec = "クライアントコード一覧"
            ElseIf hdnPopcrtl.Value = "2" Then      '//ＪＡ/ＪＡ支所コード一覧
                strRec = "ＪＡ/ＪＡ支所コード一覧"
            ElseIf hdnPopcrtl.Value = "3" Then      '//監視センター担当者一覧
                strRec = "監視センター担当者一覧"
            ElseIf hdnPopcrtl.Value = "11" Or _
                   hdnPopcrtl.Value = "12" Or _
                   hdnPopcrtl.Value = "13" Or _
                   hdnPopcrtl.Value = "14" Or _
                   hdnPopcrtl.Value = "15" Or _
                   hdnPopcrtl.Value = "16" Then      '// 警報メッセージ(PULLCODE)コード一覧 2007/04/19
                strRec = "警報メッセージ一覧"
            ElseIf hdnPopcrtl.Value = "21" Then      '// 発生区分(PULLCODE)コード一覧 2007/04/25
                strRec = "発生区分"
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：出力する一覧を制御する値を渡すプロパティ
    '*　備　考：ポップアップの種類を選択する
    '******************************************************************************
    Public ReadOnly Property pListCd() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then          '//クライアントコード一覧
                strRec = "CLI"
            ElseIf hdnPopcrtl.Value = "2" Then      '//ＪＡ/ＪＡ支所コード一覧
                'strRec = "JAJASS"
                'strRec = "JASS2"      '--- 2005/05/24 MOD Falcon ---
                strRec = "JASS"      '--- 2008/02/27 MOD T.Watabe ---
            ElseIf hdnPopcrtl.Value = "3" Then      '//ＪＡ/ＪＡ支所コード一覧
                'strRec = "TKTANCD" '2007/08/09 T.Watabe edit 監視センター担当者をクライアントではなく監視センターコードで絞るように変更
                strRec = "TKTANCDKN"
            ElseIf hdnPopcrtl.Value = "11" Or _
                   hdnPopcrtl.Value = "12" Or _
                   hdnPopcrtl.Value = "13" Or _
                   hdnPopcrtl.Value = "14" Or _
                   hdnPopcrtl.Value = "15" Or _
                   hdnPopcrtl.Value = "16" Then      '// 警報メッセージ(PULLCODE)コード一覧 2007/04/19
                strRec = "PULLCODE"
            ElseIf hdnPopcrtl.Value = "21" Then      '// 発生区分(PULLCODE)コード一覧 2007/04/25
                strRec = "PULLCODE"
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：コードを返すオブジェクトの名前値を渡すプロパティ
    '*　備　考：データ選択後、コードを返すオブジェクト名を指定する
    '******************************************************************************
    Public ReadOnly Property pBackCode() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "txtClientCD"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = "hdnJASCD"
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = "hdnTKTANCD"
            ElseIf hdnPopcrtl.Value = "11" Then      '// 警報メッセージ(PULLCODE)コード一覧 2007/04/19
                strRec = "hdnKMCD1"
            ElseIf hdnPopcrtl.Value = "12" Then      '// 警報メッセージ(PULLCODE)コード一覧 2007/04/19
                strRec = "hdnKMCD2"
            ElseIf hdnPopcrtl.Value = "13" Then      '// 警報メッセージ(PULLCODE)コード一覧 2007/04/19
                strRec = "hdnKMCD3"
            ElseIf hdnPopcrtl.Value = "14" Then      '// 警報メッセージ(PULLCODE)コード一覧 2007/04/19
                strRec = "hdnKMCD4"
            ElseIf hdnPopcrtl.Value = "15" Then      '// 警報メッセージ(PULLCODE)コード一覧 2007/04/19
                strRec = "hdnKMCD5"
            ElseIf hdnPopcrtl.Value = "16" Then      '// 警報メッセージ(PULLCODE)コード一覧 2007/04/19
                strRec = "hdnKMCD6"
            ElseIf hdnPopcrtl.Value = "21" Then      '// 発生区分(PULLCODE)コード一覧 2007/04/25
                strRec = "hdnHATKBN"
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：名称を返すオブジェクトの名前値を渡すプロパティ
    '*　備　考：データ選択後、名称を返すオブジェクト名を指定する
    '******************************************************************************
    Public ReadOnly Property pBackName() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "txtClientNAME"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = "txtACBNM"
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = "txtTKTANCD"
            ElseIf hdnPopcrtl.Value = "11" Then      '// 警報メッセージ(PULLCODE)コード一覧 2007/04/19
                strRec = "hdnKMNM1"
            ElseIf hdnPopcrtl.Value = "12" Then      '// 警報メッセージ(PULLCODE)コード一覧 2007/04/19
                strRec = "hdnKMNM2"
            ElseIf hdnPopcrtl.Value = "13" Then      '// 警報メッセージ(PULLCODE)コード一覧 2007/04/19
                strRec = "hdnKMNM3"
            ElseIf hdnPopcrtl.Value = "14" Then      '// 警報メッセージ(PULLCODE)コード一覧 2007/04/19
                strRec = "hdnKMNM4"
            ElseIf hdnPopcrtl.Value = "15" Then      '// 警報メッセージ(PULLCODE)コード一覧 2007/04/19
                strRec = "hdnKMNM5"
            ElseIf hdnPopcrtl.Value = "16" Then      '// 警報メッセージ(PULLCODE)コード一覧 2007/04/19
                strRec = "hdnKMNM6"
            ElseIf hdnPopcrtl.Value = "21" Then      '// 発生区分(PULLCODE)コード一覧 2007/04/25
                strRec = "txtHATKBN"
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：フォーカスを返すオブジェクトの名前値を渡すプロパティ
    '*　備　考：データ選択後、値を返した後に、カーソルをセットする場所の指定
    '******************************************************************************
    Public ReadOnly Property pBackFocs() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "btnKURACD"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = "btnJASCD"
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = "btnTKTANCD"
            ElseIf hdnPopcrtl.Value = "11" Then      '// 警報メッセージ(PULLCODE)コード一覧 2007/04/19
                strRec = "btnKEICD1"
            ElseIf hdnPopcrtl.Value = "12" Then      '// 警報メッセージ(PULLCODE)コード一覧 2007/04/19
                strRec = "btnKEICD2"
            ElseIf hdnPopcrtl.Value = "13" Then      '// 警報メッセージ(PULLCODE)コード一覧 2007/04/19
                strRec = "btnKEICD3"
            ElseIf hdnPopcrtl.Value = "14" Then      '// 警報メッセージ(PULLCODE)コード一覧 2007/04/19
                strRec = "btnKEICD4"
            ElseIf hdnPopcrtl.Value = "15" Then      '// 警報メッセージ(PULLCODE)コード一覧 2007/04/19
                strRec = "btnKEICD5"
            ElseIf hdnPopcrtl.Value = "16" Then      '// 警報メッセージ(PULLCODE)コード一覧 2007/04/19
                strRec = "btnKEICD6"
            ElseIf hdnPopcrtl.Value = "21" Then      '// 発生区分(PULLCODE)コード一覧 2007/04/25
                strRec = "btnHATKBN"
            Else
                strRec = ""
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
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then      'クライアントコード
                strRec = "fncSyutudouIni"

            ElseIf hdnPopcrtl.Value = "2" Then  'ＪＡ支所
                strRec = "fncSyutudou"
            ElseIf hdnPopcrtl.Value = "3" Then  '監視センター担当者
                strRec = ""
            ElseIf hdnPopcrtl.Value = "11" Or _
                    hdnPopcrtl.Value = "12" Or _
                    hdnPopcrtl.Value = "13" Or _
                    hdnPopcrtl.Value = "14" Or _
                    hdnPopcrtl.Value = "15" Or _
                    hdnPopcrtl.Value = "16" Then      '// 警報メッセージ(PULLCODE)コード一覧 2007/04/19
                strRec = "fncKeihoMsgCopy"
            ElseIf hdnPopcrtl.Value = "21" Then       '発生区分(PULLCODE)コード一覧 2007/04/25
                strRec = ""
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
    Public ReadOnly Property pClear1() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "hdnJASCD"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = ""
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
            If hdnPopcrtl.Value = "1" Then
                strRec = "txtACBNM"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = ""
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
    Public ReadOnly Property pClear3() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "hdnTKTANCD"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = ""
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
    Public ReadOnly Property pClear4() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "txtTKTANCD"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = ""
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
    Public ReadOnly Property pPRAM_CLI() As String
        Get
            Return txtClientCD.Text
        End Get
    End Property

    '******************************************************************************
    '*　概　要：
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pPRAM_JASS() As String
        Get
            Return hdnJASCD.Value
        End Get
    End Property

    '******************************************************************************
    '*　概　要：
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pPRAM_JUYOKA() As String
        Get
            Return txtJUYOKA.Text
        End Get
    End Property

    '******************************************************************************
    '*　概　要：
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pPRAM_JUYOKANAME() As String
        Get
            Return txtJUSYONM.Text
        End Get
    End Property

    '******************************************************************************
    '*　概　要：お客様電話番号1の取得
    '*　備　考：2007/04/19 T.Watabe add
    '******************************************************************************
    Public ReadOnly Property pPRAM_TEL1() As String
        Get
            Dim tel As String
            If txtJUTEL1.Text.Length > 0 Then
                ' 数字以外は削除        
                Dim pattern As String = "[^0-9]" 'パターン：数字以外
                Dim rgx As New System.Text.RegularExpressions.Regex(pattern)
                tel = rgx.Replace(txtJUTEL1.Text, "") '置き換え
            End If
            Return tel
        End Get
    End Property
    '******************************************************************************
    '*　概　要：お客様電話番号2の取得
    '*　備　考：2007/04/19 T.Watabe add
    '******************************************************************************
    Public ReadOnly Property pPRAM_TEL2() As String
        Get
            Dim tel As String
            If txtJUTEL2.Text.Length > 0 Then
                ' 数字以外は削除        
                Dim pattern As String = "[^0-9]" 'パターン：数字以外
                Dim rgx As New System.Text.RegularExpressions.Regex(pattern)
                tel = rgx.Replace(txtJUTEL2.Text, "") '置き換え
            End If
            Return tel
        End Get
    End Property
    '******************************************************************************
    '*　概　要：重複表示の対象か
    '*　備　考：0：対象外　1：対象
    '******************************************************************************
    Public ReadOnly Property pPRAM_choufukuhyouji() As String
        Get
            Return hdnchoufukuhyouji.Value
        End Get
    End Property

    '* 2007/04/18 ZBS T.Watabe デバッグ用一時出力
    Sub putlog(ByVal msg As String)
        ' ログ・ファイルerr.logへの出力ストリームを生成
        'Dim objSw As New System.IO.StreamWriter(Server.MapPath("/err.log"), True, Encoding.GetEncoding("Shift_JIS"))
        Dim objSw As New System.IO.StreamWriter("c:\debug.log", True, System.Text.Encoding.Default)
        objSw.WriteLine(DateTime.Now.ToString() & " " & msg)
        objSw.Close()
    End Sub

    ' 2007/05/09 T.Watabe add
    '******************************************************************************
    ' プルダウンマスタからKBN=71（対応入力可能クライアント）を取得する
    '******************************************************************************
    Private Function fncGetData_ClientList() As String
        Dim SQLC As New KETAIJAG00CSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet

        Dim strRes As String
        Dim strClientList As New StringBuilder("")
        Dim i As Integer

        strRes = ""
        Try
            '//出動会社情報の取得
            strSQL = New StringBuilder("")
            strSQL.Append("SELECT CD ")
            strSQL.Append("FROM M06_PULLDOWN ")
            strSQL.Append("WHERE KBN = '71' ")   ' KBN=71（対応入力可能クライアント）
            strSQL.Append("ORDER BY CD ")

            '//SQLの実行
            dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)


            If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
                'データなしの場合
            Else
                'データありの場合
                For i = 0 To dbData.Tables(0).Rows.Count - 1
                    If i > 0 Then
                        strClientList.Append(",") ' ２つ目からカンマを付ける
                    End If
                    strClientList.Append(Convert.ToString(dbData.Tables(0).Rows(i).Item("CD")))
                Next
            End If
            strRes = strClientList.ToString

        Catch ex As Exception
            Dim ErrMsgC As New CErrMsg
            strMsg.Append("alert('システムエラー：" & ErrMsgC.mGetArtMsg(ex.ToString) & "');")
            strRes = ""

        Finally
            If dbData Is Nothing Then
            Else
                dbData.Dispose()
            End If
        End Try

        Return strRes
    End Function
    '**********************************************************
    ' 2012/06/28 ADD W.GANEKO
    'ログ吐き出し
    '戻り値：書き込んだファイルへのフルパス
    '**********************************************************
    Public Sub mlog(ByVal pstrString As String)
        Dim strFilnm As String = "log" & System.DateTime.Today.ToString("yyyyMMdd")
        Dim strLogPath As String = ConfigurationSettings.AppSettings("LOG_OUT_PATH")
        Dim strPath As String = strLogPath & strFilnm & ".txt"
        Dim strLogFlg As String = ConfigurationSettings.AppSettings("LOG_OUT")
        Dim LogC As New CLog
        Dim strRecLog As String

        Dim linestring As New StringBuilder("")
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

    '**********************************************************
    ' 2013/08/02 T.Ono
    'FAX不要区分(JA・ｸﾗｲｱﾝﾄ)、注意事項取得 fncSetData_KEIHOU
    '**********************************************************
    Private Function fncGetFAXKBN_GUIDE_KEIHOU() As String()
        Dim SQLC As New KETAIJAG00CSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet

        'Dim strRes(2) As String       '2019/11/01 W.GANEKO 2019監視改善 No8-12
        'For i As Integer = 0 To 2     '2019/11/01 W.GANEKO 2019監視改善 No8-12
        Dim strRes(4) As String        '2019/11/01 W.GANEKO 2019監視改善 No8-12
        For i As Integer = 0 To 4      '2019/11/01 W.GANEKO 2019監視改善 No8-12
            strRes(i) = ""
        Next

        Try
            strSQL = New StringBuilder("")
            '2016/02/02 w.ganeko 2015開発改善 №1 start
            'strSQL.Append("WITH ")
            'strSQL.Append("/* お客様個別 */ ")
            'strSQL.Append("A AS ( ")
            'strSQL.Append("SELECT T.KURACD, T.CODE, T.USER_CD_FROM, T.FAXKBN, T.FAXKURAKBN, T.GUIDELINE ")
            'strSQL.Append("FROM   T10_KEIHO KEI, ")
            'strSQL.Append("       M05_TANTO2 T ")
            'strSQL.Append("WHERE  KEI.SYORI_SERIAL = :SYORI_SERIAL ")
            'strSQL.Append("AND    T.KBN = '3' ")
            'strSQL.Append("AND    KEI.KURACD = T.KURACD ")
            'strSQL.Append("AND    KEI.ACBCD = T.CODE ")
            'strSQL.Append("AND    LPAD(T.TANCD, 2, '0') = '01' ")
            'strSQL.Append("AND    T.USER_CD_TO IS NULL ")
            'strSQL.Append("AND    KEI.JUYOKA = T.USER_CD_FROM ")
            'strSQL.Append("), ")
            'strSQL.Append("/* お客様範囲 */ ")
            'strSQL.Append("B AS ( ")
            'strSQL.Append("SELECT T.KURACD, T.CODE, T.USER_CD_FROM, T.FAXKBN, T.FAXKURAKBN, T.GUIDELINE ")
            'strSQL.Append("FROM   T10_KEIHO KEI, ")
            'strSQL.Append("       M05_TANTO2 T ")
            'strSQL.Append("WHERE  KEI.SYORI_SERIAL = :SYORI_SERIAL ")
            'strSQL.Append("AND    T.KBN = '3' ")
            'strSQL.Append("AND    KEI.KURACD = T.KURACD ")
            'strSQL.Append("AND    KEI.ACBCD = T.CODE ")
            'strSQL.Append("AND    LPAD(T.TANCD, 2, '0') = '01' ")
            'strSQL.Append("AND    T.USER_CD_TO IS NOT NULL ")
            'strSQL.Append("AND    KEI.JUYOKA BETWEEN T.USER_CD_FROM AND T.USER_CD_TO ")
            'strSQL.Append("), ")
            'strSQL.Append("/* JA支所 */ ")
            'strSQL.Append("C AS( ")
            'strSQL.Append("SELECT T.KURACD, T.CODE, T.FAXKBN, T.FAXKURAKBN, T.GUIDELINE ")
            'strSQL.Append("FROM   T10_KEIHO KEI, ")
            'strSQL.Append("       M05_TANTO T ")
            'strSQL.Append("WHERE  KEI.SYORI_SERIAL = :SYORI_SERIAL ")
            'strSQL.Append("AND    T.KBN = '3' ")
            'strSQL.Append("AND    KEI.KURACD = T.KURACD ")
            'strSQL.Append("AND    KEI.ACBCD = T.CODE ")
            'strSQL.Append("AND    LPAD(T.TANCD, 2, '0') = '01' ")
            'strSQL.Append("), ")
            'strSQL.Append("/* JA3ケタ */ ")
            'strSQL.Append("D AS( ")
            'strSQL.Append("SELECT T.KURACD, T.CODE, T.FAXKBN, T.FAXKURAKBN, T.GUIDELINE ")
            'strSQL.Append("FROM   T10_KEIHO KEI, ")
            'strSQL.Append("       M05_TANTO T, ")
            'strSQL.Append("       HN2MAS H ")
            'strSQL.Append("WHERE  KEI.SYORI_SERIAL = :SYORI_SERIAL ")
            'strSQL.Append("AND    T.KBN = '3' ")
            'strSQL.Append("AND    KEI.KURACD = T.KURACD ")
            'strSQL.Append("AND    H.CLI_CD = T.KURACD ")
            'strSQL.Append("AND    T.CODE = H.JA_CD ")
            'strSQL.Append("AND    KEI.KURACD = H.CLI_CD ")
            'strSQL.Append("AND    KEI.ACBCD  = H.HAN_CD ")
            'strSQL.Append("AND    LPAD(T.TANCD, 2, '0') = '01'  ")
            'strSQL.Append("), ")
            ''2015/02/19 T.Ono add 2014改善開発 No15 ｸﾗｲｱﾝﾄ追加 START
            'strSQL.Append("/* クライアント */ ")
            'strSQL.Append("K AS( ")
            'strSQL.Append("SELECT T.KURACD, T.CODE, T.FAXKBN, T.FAXKURAKBN, '' AS GUIDELINE ")
            'strSQL.Append("FROM   T10_KEIHO KEI, ")
            'strSQL.Append("       M05_TANTO T ")
            'strSQL.Append("WHERE  KEI.SYORI_SERIAL = :SYORI_SERIAL ")
            'strSQL.Append("AND    T.KBN = '3' ")
            'strSQL.Append("AND    KEI.KURACD = T.KURACD ")
            'strSQL.Append("AND    T.CODE = 'XXXX' ")
            'strSQL.Append("AND    LPAD(T.TANCD, 2, '0') = '01' ")
            'strSQL.Append("), ")
            ''2015/02/19 T.Ono add 2014改善開発 No15 END
            strSQL.Append("WITH ")
            strSQL.Append("/* お客様個別 */ ")
            strSQL.Append("A AS ( ")
            strSQL.Append("SELECT T.KURACD, T.ACBCD, T.USERCD_FROM, D.FAXKBN, D.FAXKURAKBN, D.GUIDELINE ")
            strSQL.Append(",D.GUIDELINE2 ")        '2019/11/01 W.GANEKO 2019監視改善 No8-12
            strSQL.Append(",D.GUIDELINE3 ")        '2019/11/01 W.GANEKO 2019監視改善 No8-12
            strSQL.Append("FROM   T10_KEIHO KEI, ")
            strSQL.Append("       M09_JAGROUP T, ")
            strSQL.Append("       M11_JAHOKOKU D ")
            strSQL.Append("WHERE  KEI.SYORI_SERIAL = :SYORI_SERIAL ")
            strSQL.Append("AND    T.KBN = '002' ")
            strSQL.Append("AND    KEI.KURACD = T.KURACD ")
            strSQL.Append("AND    KEI.ACBCD = T.ACBCD ")
            strSQL.Append("AND    KEI.JUYOKA = T.USERCD_FROM ")
            strSQL.Append("AND    T.USERCD_TO IS NULL ")
            strSQL.Append("AND    D.KBN = '2' ")
            strSQL.Append("AND    T.GROUPCD = D.GROUPCD ")
            strSQL.Append("AND    LPAD(D.TANCD, 2, '0') = '01' ")
            strSQL.Append("), ")
            strSQL.Append("/* お客様範囲 */ ")
            strSQL.Append("B AS ( ")
            strSQL.Append("SELECT T.KURACD, T.ACBCD, T.USERCD_FROM, D.FAXKBN, D.FAXKURAKBN, D.GUIDELINE ")
            strSQL.Append(",D.GUIDELINE2 ")        '2019/11/01 W.GANEKO 2019監視改善 No8-12
            strSQL.Append(",D.GUIDELINE3 ")        '2019/11/01 W.GANEKO 2019監視改善 No8-12
            strSQL.Append("FROM   T10_KEIHO KEI, ")
            strSQL.Append("       M09_JAGROUP T, ")
            strSQL.Append("       M11_JAHOKOKU D ")
            strSQL.Append("WHERE  KEI.SYORI_SERIAL = :SYORI_SERIAL ")
            strSQL.Append("AND    T.KBN = '002' ")
            strSQL.Append("AND    KEI.KURACD = T.KURACD ")
            strSQL.Append("AND    KEI.ACBCD = T.ACBCD ")
            strSQL.Append("AND    D.KBN = '2' ")
            strSQL.Append("AND    T.GROUPCD = D.GROUPCD ")
            strSQL.Append("AND    LPAD(D.TANCD, 2, '0') = '01' ")
            strSQL.Append("AND    T.USERCD_TO IS NOT NULL ")
            strSQL.Append("AND    KEI.JUYOKA BETWEEN T.USERCD_FROM AND T.USERCD_TO ")
            strSQL.Append("), ")
            strSQL.Append("/* JA支所 */ ")
            strSQL.Append("C AS( ")
            strSQL.Append("SELECT T.KURACD, T.ACBCD, D.FAXKBN, D.FAXKURAKBN, D.GUIDELINE ")
            strSQL.Append(",D.GUIDELINE2 ")        '2019/11/01 W.GANEKO 2019監視改善 No8-12
            strSQL.Append(",D.GUIDELINE3 ")        '2019/11/01 W.GANEKO 2019監視改善 No8-12
            strSQL.Append("FROM   T10_KEIHO KEI, ")
            strSQL.Append("       M09_JAGROUP T, ")
            strSQL.Append("       M11_JAHOKOKU D ")
            strSQL.Append("WHERE  KEI.SYORI_SERIAL = :SYORI_SERIAL ")
            strSQL.Append("AND    T.KBN = '002' ")
            strSQL.Append("AND    KEI.KURACD = T.KURACD ")
            strSQL.Append("AND    KEI.ACBCD = T.ACBCD ")
            strSQL.Append("AND    D.KBN = '2' ")
            strSQL.Append("AND    T.GROUPCD = D.GROUPCD ")
            strSQL.Append("AND    LPAD(D.TANCD, 2, '0') = '01' ")
            strSQL.Append("AND    T.USERCD_FROM IS NULL ")
            strSQL.Append("AND    T.USERCD_TO IS NULL ")
            strSQL.Append("), ")
            strSQL.Append("/* クライアント */ ")
            strSQL.Append("K AS( ")
            strSQL.Append("SELECT T.GROUPCD AS KURACD, T.FAXKBN, T.FAXKURAKBN, '' AS GUIDELINE ")
            strSQL.Append(",'' AS GUIDELINE2 ")        '2019/11/01 W.GANEKO 2019監視改善 No8-12
            strSQL.Append(",'' AS GUIDELINE3 ")        '2019/11/01 W.GANEKO 2019監視改善 No8-12
            strSQL.Append("FROM   T10_KEIHO KEI, ")
            strSQL.Append("       M11_JAHOKOKU T ")
            strSQL.Append("WHERE  KEI.SYORI_SERIAL = :SYORI_SERIAL ")
            strSQL.Append("AND    T.KBN = '1' ")
            strSQL.Append("AND    KEI.KURACD = T.GROUPCD ")
            strSQL.Append("AND    LPAD(T.TANCD, 2, '0') = '01' ")
            strSQL.Append("), ")
            '2016/02/02 w.ganeko 2015開発改善 №1 end
            strSQL.Append("/* DUMMY */ ")
            strSQL.Append("E AS( ")
            strSQL.Append("SELECT KEI.KURACD ")
            strSQL.Append("FROM   T10_KEIHO KEI ")
            strSQL.Append("WHERE  KEI.SYORI_SERIAL = :SYORI_SERIAL  ")
            strSQL.Append(") ")
            '2015/02/19 T.Ono mod 2014改善開発 No15 ｸﾗｲｱﾝﾄ追加 START
            'strSQL.Append("SELECT NVL(A.FAXKBN, NVL(B.FAXKBN, NVL(C.FAXKBN, NVL(D.FAXKBN, '0')))) AS FAXKBN , ")
            'strSQL.Append("       NVL(A.FAXKURAKBN, NVL(B.FAXKURAKBN, NVL(C.FAXKURAKBN, NVL(D.FAXKURAKBN, '0')))) AS FAXKURAKBN, ")
            'strSQL.Append("       NVL(A.GUIDELINE, NVL(B.GUIDELINE, NVL(C.GUIDELINE, NVL(D.GUIDELINE, '')))) AS GUIDELINE, ")
            'strSQL.Append("       NVL(A.USER_CD_FROM, NVL(B.USER_CD_FROM, '')) AS USER_CD_FROM ")
            'strSQL.Append("FROM A, B, C, D, E ")
            '2016/02/02 w.ganeko 2015開発改善 №1 START
            'strSQL.Append("SELECT NVL(A.FAXKBN, NVL(B.FAXKBN, NVL(C.FAXKBN, NVL(D.FAXKBN, NVL(K.FAXKBN, '0'))))) AS FAXKBN , ")
            'strSQL.Append("       NVL(A.FAXKURAKBN, NVL(B.FAXKURAKBN, NVL(C.FAXKURAKBN, NVL(D.FAXKURAKBN, NVL(K.FAXKURAKBN, '0'))))) AS FAXKURAKBN, ")
            'strSQL.Append("       NVL(A.GUIDELINE, NVL(B.GUIDELINE, NVL(C.GUIDELINE, NVL(D.GUIDELINE, '')))) AS GUIDELINE, ")
            'strSQL.Append("       NVL(A.USER_CD_FROM, NVL(B.USER_CD_FROM, '')) AS USER_CD_FROM ")
            'strSQL.Append("FROM A, B, C, D, K, E ")
            ''2015/02/19 T.Ono mod 2014改善開発 No15 END
            'strSQL.Append("WHERE 	E.KURACD = D.KURACD(+) ")
            'strSQL.Append("AND	E.KURACD = C.KURACD(+) ")
            'strSQL.Append("AND	E.KURACD = B.KURACD(+) ")
            'strSQL.Append("AND	E.KURACD = A.KURACD(+) ")
            'strSQL.Append("AND	E.KURACD = K.KURACD(+) ") '2015/02/19 T.Ono mod 2014改善開発 No15 ｸﾗｲｱﾝﾄ追加
            strSQL.Append("SELECT NVL(A.FAXKBN, NVL(B.FAXKBN, NVL(C.FAXKBN, NVL(K.FAXKBN, '0')))) AS FAXKBN , ")
            strSQL.Append("       NVL(A.FAXKURAKBN, NVL(B.FAXKURAKBN, NVL(C.FAXKURAKBN, NVL(K.FAXKURAKBN, '0')))) AS FAXKURAKBN, ")
            strSQL.Append("       NVL(A.GUIDELINE, NVL(B.GUIDELINE, NVL(C.GUIDELINE, ''))) AS GUIDELINE, ")
            strSQL.Append("       NVL(A.GUIDELINE2, NVL(B.GUIDELINE2, NVL(C.GUIDELINE2, ''))) AS GUIDELINE2, ") '2019/11/01 W.GANEKO 2019監視改善 No8-12
            strSQL.Append("       NVL(A.GUIDELINE3, NVL(B.GUIDELINE3, NVL(C.GUIDELINE3, ''))) AS GUIDELINE3, ") '2019/11/01 W.GANEKO 2019監視改善 No8-12
            strSQL.Append("       NVL(A.USERCD_FROM, NVL(B.USERCD_FROM, '')) AS USER_CD_FROM ")
            strSQL.Append("FROM A, B, C, K, E ")
            strSQL.Append("WHERE 	")
            strSQL.Append("     E.KURACD = C.KURACD(+) ")
            strSQL.Append("AND	E.KURACD = B.KURACD(+) ")
            strSQL.Append("AND	E.KURACD = A.KURACD(+) ")
            strSQL.Append("AND	E.KURACD = K.KURACD(+) ")
            '2016/02/02 w.ganeko 2015開発改善 №1 END

            'パラメータのセット
            SqlParamC.fncSetParam("SYORI_SERIAL", True, hdnKEY_SERIAL.Value)

            '//SQLの実行
            dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

            If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
                'データなしの場合
                strRes(0) = "0"
                strRes(1) = "0"
                strRes(2) = ""
                strRes(3) = ""    '2019/11/01 W.GANEKO 2019監視改善 No8-12
                strRes(4) = ""    '2019/11/01 W.GANEKO 2019監視改善 No8-12
            Else
                'データありの場合
                strRes(0) = Convert.ToString(dbData.Tables(0).Rows(0).Item("FAXKBN"))
                strRes(1) = Convert.ToString(dbData.Tables(0).Rows(0).Item("FAXKURAKBN"))
                strRes(2) = Convert.ToString(dbData.Tables(0).Rows(0).Item("GUIDELINE"))
                strRes(3) = Convert.ToString(dbData.Tables(0).Rows(0).Item("GUIDELINE2"))  '2019/11/01 W.GANEKO 2019監視改善 No8-12
                strRes(4) = Convert.ToString(dbData.Tables(0).Rows(0).Item("GUIDELINE3"))  '2019/11/01 W.GANEKO 2019監視改善 No8-12
                hdnUSER_CD_FROM.Value = Convert.ToString(dbData.Tables(0).Rows(0).Item("USER_CD_FROM"))
            End If

        Catch ex As Exception
            Dim ErrMsgC As New CErrMsg
            strMsg.Append("alert('システムエラー：" & ErrMsgC.mGetArtMsg(ex.ToString) & "');")
            For i As Integer = 0 To 2
                strRes(i) = ""
            Next

        Finally
            If dbData Is Nothing Then
            Else
                dbData.Dispose()
            End If
        End Try

        Return strRes
    End Function

    '**********************************************************
    ' 2013/08/23 T.Ono add 監視改善2013№1
    ' 本日工事状況取得（KAILOG：KAITU_DAY）　fncSetData_KEIHOU
    '**********************************************************
    Private Function fncGetKAITU_DAY_KEIHO() As String
        Dim SQLC As New KETAIJAG00CSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet

        Dim strRes As String

        Try
            strSQL = New StringBuilder("")
            strSQL.Append("SELECT MAX(TO_CHAR(KAITU_DAY, 'YYYY/MM/DD HH24:MI:SS')) AS KAITU_DAY ")
            strSQL.Append("FROM   T10_KEIHO KEI,  ")
            strSQL.Append("       KAILOG L ")
            strSQL.Append("WHERE  KEI.SYORI_SERIAL = :SYORI_SERIAL  ")
            strSQL.Append("AND    KEI.KURACD = L.CLI_CD  ")
            strSQL.Append("AND    KEI.ACBCD = L.HAN_CD  ")
            strSQL.Append("AND    KEI.JUYOKA = L.USER_CD ")
            strSQL.Append("AND    KAITU_DAY >= TO_DATE(TO_CHAR(SYSDATE, 'YYYY/MM/DD'),'YYYY/MM/DD') ")
            strSQL.Append("AND    KAITU_FLG = '20' ")
            strSQL.Append("ORDER BY KAITU_DAY ")

            'パラメータのセット
            SqlParamC.fncSetParam("SYORI_SERIAL", True, hdnKEY_SERIAL.Value)

            '//SQLの実行
            dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

            If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
                'データなしの場合
                strRes = ""
            Else
                'データありの場合
                strRes = Convert.ToString(dbData.Tables(0).Rows(0).Item("KAITU_DAY"))
            End If

        Catch ex As Exception
            Dim ErrMsgC As New CErrMsg
            strMsg.Append("alert('システムエラー：" & ErrMsgC.mGetArtMsg(ex.ToString) & "');")
            strRes = ""

        Finally
            If dbData Is Nothing Then
            Else
                dbData.Dispose()
            End If
        End Try

        Return strRes
    End Function

    '**********************************************************
    ' 2013/08/05 T.Ono
    'FAX不要区分(JA・ｸﾗｲｱﾝﾄ)、注意事項取得 fncSetData_KOKYAKU
    '**********************************************************
    Private Function fncGetFAXKBN_GUIDE_KOKYAKU() As String()
        Dim SQLC As New KETAIJAG00CSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet

        'Dim strRes(2) As String      '2019/11/01 W.GANEKO 2019監視改善 No8-12
        'For i As Integer = 0 To 2    '2019/11/01 W.GANEKO 2019監視改善 No8-12
        Dim strRes(4) As String       '2019/11/01 W.GANEKO 2019監視改善 No8-12
        For i As Integer = 0 To 4     '2019/11/01 W.GANEKO 2019監視改善 No8-12
            strRes(i) = ""
        Next

        Try
            strSQL = New StringBuilder("")
            '2016/02/02 w.ganeko 2015開発改善 №1 start
            'strSQL.Append("WITH  ")
            'strSQL.Append("/* お客様個別 */ ")
            'strSQL.Append("A AS ( ")
            'strSQL.Append("SELECT T.KURACD, T.CODE, T.USER_CD_FROM, T.FAXKBN, T.FAXKURAKBN, T.GUIDELINE ")
            'strSQL.Append("FROM   M05_TANTO2 T ")
            'strSQL.Append("WHERE  T.KURACD = :CLI_CD ")
            'strSQL.Append("AND    T.CODE = :HAN_CD ")
            'strSQL.Append("AND    T.USER_CD_FROM = :USER_CD ")
            'strSQL.Append("AND    T.KBN = '3' ")
            'strSQL.Append("AND    LPAD(T.TANCD, 2, '0') = '01' ")
            'strSQL.Append("AND    T.USER_CD_TO IS NULL ")
            'strSQL.Append("), ")
            'strSQL.Append("/* お客様範囲 */ ")
            'strSQL.Append("B AS ( ")
            'strSQL.Append("SELECT T.KURACD, T.CODE, T.USER_CD_FROM, T.FAXKBN, T.FAXKURAKBN, T.GUIDELINE ")
            'strSQL.Append("FROM   M05_TANTO2 T ")
            'strSQL.Append("WHERE  T.KURACD = :CLI_CD ")
            'strSQL.Append("AND    T.CODE = :HAN_CD ")
            'strSQL.Append("AND    T.KBN = '3' ")
            'strSQL.Append("AND    LPAD(T.TANCD, 2, '0') = '01' ")
            'strSQL.Append("AND    T.USER_CD_TO IS NOT NULL ")
            'strSQL.Append("AND    :USER_CD BETWEEN T.USER_CD_FROM AND T.USER_CD_TO ")
            'strSQL.Append("), ")
            'strSQL.Append("/* JA支所 */ ")
            'strSQL.Append("C AS ( ")
            'strSQL.Append("SELECT T.KURACD, T.CODE, T.FAXKBN, T.FAXKURAKBN, T.GUIDELINE ")
            'strSQL.Append("FROM   M05_TANTO T ")
            'strSQL.Append("WHERE  T.KURACD = :CLI_CD ")
            'strSQL.Append("AND    T.CODE = :HAN_CD ")
            'strSQL.Append("AND    T.KBN = '3' ")
            'strSQL.Append("AND    LPAD(T.TANCD, 2, '0') = '01' ")
            'strSQL.Append("), ")
            'strSQL.Append("/* JA3ケタ */ ")
            'strSQL.Append("D AS ( ")
            'strSQL.Append("SELECT T.KURACD, T.CODE, T.FAXKBN, T.FAXKURAKBN, T.GUIDELINE ")
            'strSQL.Append("FROM   HN2MAS H, ")
            'strSQL.Append("       M05_TANTO T ")
            'strSQL.Append("WHERE  H.CLI_CD = :CLI_CD ")
            'strSQL.Append("AND    H.HAN_CD = :HAN_CD ")
            'strSQL.Append("AND    H.CLI_CD = T.KURACD ")
            'strSQL.Append("AND    T.CODE = H.JA_CD ")
            'strSQL.Append("AND    T.KBN = '3' ")
            'strSQL.Append("AND    LPAD(T.TANCD, 2, '0') = '01' ")
            'strSQL.Append("), ")
            ''2015/02/19 T.Ono add 2014改善開発 No15 ｸﾗｲｱﾝﾄ追加 START
            'strSQL.Append("/* クライアント */ ")
            'strSQL.Append("K AS ( ")
            'strSQL.Append("SELECT T.KURACD, T.CODE, T.FAXKBN, T.FAXKURAKBN, '' AS GUIDELINE ")
            'strSQL.Append("FROM   M05_TANTO T ")
            'strSQL.Append("WHERE  T.KURACD = :CLI_CD ")
            'strSQL.Append("AND    T.CODE = 'XXXX' ")
            'strSQL.Append("AND    T.KBN = '3' ")
            'strSQL.Append("AND    LPAD(T.TANCD, 2, '0') = '01' ")
            'strSQL.Append("), ")
            '2015/02/19 T.Ono add 2014改善開発 No15 END
            strSQL.Append("WITH ")
            strSQL.Append("/* お客様個別 */ ")
            strSQL.Append("A AS ( ")
            strSQL.Append("SELECT T.KURACD, T.ACBCD, T.USERCD_FROM, D.FAXKBN, D.FAXKURAKBN, D.GUIDELINE ")
            strSQL.Append(",D.GUIDELINE2 ")    '2019/11/01 W.GANEKO 2019監視改善 No8-12
            strSQL.Append(",D.GUIDELINE3 ")    '2019/11/01 W.GANEKO 2019監視改善 No8-12
            strSQL.Append("FROM   M09_JAGROUP T, ")
            strSQL.Append("       M11_JAHOKOKU D ")
            strSQL.Append("WHERE  T.KURACD = :CLI_CD ")
            strSQL.Append("AND    T.ACBCD = :HAN_CD ")
            strSQL.Append("AND    T.KBN = '002' ")
            strSQL.Append("AND    T.USERCD_FROM = :USER_CD ")
            strSQL.Append("AND    T.USERCD_TO IS NULL ")
            strSQL.Append("AND    D.KBN = '2' ")
            strSQL.Append("AND    T.GROUPCD = D.GROUPCD ")
            strSQL.Append("AND    LPAD(D.TANCD, 2, '0') = '01' ")
            strSQL.Append("), ")
            strSQL.Append("/* お客様範囲 */ ")
            strSQL.Append("B AS ( ")
            strSQL.Append("SELECT T.KURACD, T.ACBCD, T.USERCD_FROM, D.FAXKBN, D.FAXKURAKBN, D.GUIDELINE ")
            strSQL.Append(",D.GUIDELINE2 ")    '2019/11/01 W.GANEKO 2019監視改善 No8-12
            strSQL.Append(",D.GUIDELINE3 ")    '2019/11/01 W.GANEKO 2019監視改善 No8-12
            strSQL.Append("FROM   M09_JAGROUP T, ")
            strSQL.Append("       M11_JAHOKOKU D ")
            strSQL.Append("WHERE  T.KURACD = :CLI_CD ")
            strSQL.Append("AND    T.ACBCD = :HAN_CD ")
            strSQL.Append("AND    T.KBN = '002' ")
            strSQL.Append("AND    D.KBN = '2' ")
            strSQL.Append("AND    T.GROUPCD = D.GROUPCD ")
            strSQL.Append("AND    LPAD(D.TANCD, 2, '0') = '01' ")
            strSQL.Append("AND    T.USERCD_TO IS NOT NULL ")
            strSQL.Append("AND    :USER_CD BETWEEN T.USERCD_FROM AND T.USERCD_TO ")
            strSQL.Append("), ")
            strSQL.Append("/* JA支所 */ ")
            strSQL.Append("C AS ( ")
            strSQL.Append("SELECT T.KURACD, T.ACBCD, D.FAXKBN, D.FAXKURAKBN, D.GUIDELINE ")
            strSQL.Append(",D.GUIDELINE2 ")    '2019/11/01 W.GANEKO 2019監視改善 No8-12
            strSQL.Append(",D.GUIDELINE3 ")    '2019/11/01 W.GANEKO 2019監視改善 No8-12
            strSQL.Append("FROM   M09_JAGROUP T, ")
            strSQL.Append("       M11_JAHOKOKU D ")
            strSQL.Append("WHERE  T.KURACD = :CLI_CD ")
            strSQL.Append("AND    T.ACBCD = :HAN_CD ")
            strSQL.Append("AND    T.KBN = '002' ")
            strSQL.Append("AND    D.KBN = '2' ")
            strSQL.Append("AND    T.GROUPCD = D.GROUPCD ")
            strSQL.Append("AND    LPAD(D.TANCD, 2, '0') = '01' ")
            strSQL.Append("AND    T.USERCD_FROM IS NULL ")
            strSQL.Append("AND    T.USERCD_TO IS NULL ")
            strSQL.Append("), ")
            strSQL.Append("/* クライアント */ ")
            strSQL.Append("K AS ( ")
            strSQL.Append("SELECT D.GROUPCD AS KURACD, D.FAXKBN, D.FAXKURAKBN, D.GUIDELINE AS GUIDELINECL ")
            strSQL.Append(",D.GUIDELINE2 AS GUIDELINECL2 ")    '2019/11/01 W.GANEKO 2019監視改善 No8-12
            strSQL.Append(",D.GUIDELINE3 AS GUIDELINECL3 ")    '2019/11/01 W.GANEKO 2019監視改善 No8-12
            strSQL.Append("FROM M11_JAHOKOKU D ")
            strSQL.Append("WHERE  D.KBN = '1' ")
            strSQL.Append("AND    D.GROUPCD = :CLI_CD ")
            strSQL.Append("AND    LPAD(D.TANCD, 2, '0') = '01' ")
            strSQL.Append("), ")
            '2016/02/02 w.ganeko 2015開発改善 №1 END
            strSQL.Append("/* DUMMY */ ")
            strSQL.Append("E AS( ")
            strSQL.Append("SELECT :CLI_CD AS CLI_CD ")
            strSQL.Append("FROM   DUAL  ")
            strSQL.Append(") ")
            '2015/02/19 T.Ono add 2014改善開発 No15 ｸﾗｲｱﾝﾄ追加 START
            'strSQL.Append("SELECT NVL(A.FAXKBN, NVL(B.FAXKBN, NVL(C.FAXKBN, NVL(D.FAXKBN, '0')))) AS FAXKBN, ")
            'strSQL.Append("       NVL(A.FAXKURAKBN, NVL(B.FAXKURAKBN, NVL(C.FAXKURAKBN, NVL(D.FAXKURAKBN, '0')))) AS FAXKURAKBN, ")
            'strSQL.Append("       NVL(A.GUIDELINE, NVL(B.GUIDELINE, NVL(C.GUIDELINE, NVL(D.GUIDELINE, '')))) AS GUIDELINE, ")
            'strSQL.Append("       NVL(A.USER_CD_FROM, NVL(B.USER_CD_FROM, '')) AS USER_CD_FROM ")
            'strSQL.Append("FROM   A, B, C, D, E ")
            '2016/02/02 w.ganeko 2015開発改善 №1 START
            'strSQL.Append("SELECT NVL(A.FAXKBN, NVL(B.FAXKBN, NVL(C.FAXKBN, NVL(D.FAXKBN, NVL(K.FAXKBN, '0'))))) AS FAXKBN, ")
            'strSQL.Append("       NVL(A.FAXKURAKBN, NVL(B.FAXKURAKBN, NVL(C.FAXKURAKBN, NVL(D.FAXKURAKBN, NVL(K.FAXKURAKBN, '0'))))) AS FAXKURAKBN, ")
            'strSQL.Append("       NVL(A.GUIDELINE, NVL(B.GUIDELINE, NVL(C.GUIDELINE, NVL(D.GUIDELINE, '')))) AS GUIDELINE, ")
            'strSQL.Append("       NVL(A.USER_CD_FROM, NVL(B.USER_CD_FROM, '')) AS USER_CD_FROM ")
            'strSQL.Append("FROM   A, B, C, D, K, E ")
            ''2015/02/19 T.Ono add 2014改善開発 No15 END
            'strSQL.Append("WHERE  E.CLI_CD = A.KURACD(+) ")
            'strSQL.Append("AND    E.CLI_CD = B.KURACD(+) ")
            'strSQL.Append("AND    E.CLI_CD = C.KURACD(+) ")
            'strSQL.Append("AND    E.CLI_CD = D.KURACD(+) ")
            'strSQL.Append("AND    E.CLI_CD = K.KURACD(+) ") '2015/02/19 T.Ono add 2014改善開発 No15
            strSQL.Append("SELECT NVL(A.FAXKBN, NVL(B.FAXKBN, NVL(C.FAXKBN, NVL(K.FAXKBN, '0')))) AS FAXKBN, ")
            strSQL.Append("       NVL(A.FAXKURAKBN, NVL(B.FAXKURAKBN, NVL(C.FAXKURAKBN, NVL(K.FAXKURAKBN, '0')))) AS FAXKURAKBN, ")
            strSQL.Append("       NVL(A.GUIDELINE, NVL(B.GUIDELINE, NVL(C.GUIDELINE, ''))) AS GUIDELINE, ")
            strSQL.Append("       NVL(A.GUIDELINE2, NVL(B.GUIDELINE2, NVL(C.GUIDELINE2, ''))) AS GUIDELINE2, ")  '2019/11/01 W.GANEKO 2019監視改善 No8-12
            strSQL.Append("       NVL(A.GUIDELINE3, NVL(B.GUIDELINE3, NVL(C.GUIDELINE3, ''))) AS GUIDELINE3, ")  '2019/11/01 W.GANEKO 2019監視改善 No8-12
            strSQL.Append("       NVL(A.USERCD_FROM, NVL(B.USERCD_FROM, '')) AS USER_CD_FROM ")
            strSQL.Append("FROM   A, B, C, K, E ")
            strSQL.Append("WHERE  E.CLI_CD = A.KURACD(+) ")
            strSQL.Append("AND    E.CLI_CD = B.KURACD(+) ")
            strSQL.Append("AND    E.CLI_CD = C.KURACD(+) ")
            strSQL.Append("AND    E.CLI_CD = K.KURACD(+) ")
            '2016/02/02 w.ganeko 2015開発改善 №1 END

            'パラメータのセット
            SqlParamC.fncSetParam("CLI_CD", True, hdnKEY_CLI_CD.Value)
            SqlParamC.fncSetParam("USER_CD", True, hdnKEY_USER_CD.Value)
            SqlParamC.fncSetParam("HAN_CD", True, hdnKEY_HAN_CD.Value)

            '//SQLの実行
            dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

            If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
                'データなしの場合
                strRes(0) = "0"
                strRes(1) = "0"
                strRes(2) = ""
                strRes(3) = ""     '2019/11/01 W.GANEKO 2019監視改善 No8-12
                strRes(4) = ""     '2019/11/01 W.GANEKO 2019監視改善 No8-12
            Else
                'データありの場合
                strRes(0) = Convert.ToString(dbData.Tables(0).Rows(0).Item("FAXKBN"))
                strRes(1) = Convert.ToString(dbData.Tables(0).Rows(0).Item("FAXKURAKBN"))
                strRes(2) = Convert.ToString(dbData.Tables(0).Rows(0).Item("GUIDELINE"))
                strRes(3) = Convert.ToString(dbData.Tables(0).Rows(0).Item("GUIDELINE2"))    '2019/11/01 W.GANEKO 2019監視改善 No8-12
                strRes(4) = Convert.ToString(dbData.Tables(0).Rows(0).Item("GUIDELINE3"))    '2019/11/01 W.GANEKO 2019監視改善 No8-12
                hdnUSER_CD_FROM.Value = Convert.ToString(dbData.Tables(0).Rows(0).Item("USER_CD_FROM"))
            End If


        Catch ex As Exception
            Dim ErrMsgC As New CErrMsg
            strMsg.Append("alert('システムエラー：" & ErrMsgC.mGetArtMsg(ex.ToString) & "');")
            For i As Integer = 0 To 2
                strRes(i) = ""
            Next

        Finally
            If dbData Is Nothing Then
            Else
                dbData.Dispose()
            End If
        End Try

        Return strRes
    End Function

    '**********************************************************
    ' 2013/08/23 T.Ono add 監視改善2013№1
    ' 本日工事状況取得（KAILOG：KAITU_DAY） fncSetData_KOKYAKU
    '**********************************************************
    Private Function fncGetKAITU_DAY_KOKYAKU() As String
        Dim SQLC As New KETAIJAG00CSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet

        Dim strRes As String

        Try
            strSQL = New StringBuilder("")
            strSQL.Append("SELECT MAX(TO_CHAR(KAITU_DAY, 'YYYY/MM/DD HH24:MI:SS')) AS KAITU_DAY ")
            strSQL.Append("FROM   KAILOG L ")
            strSQL.Append("WHERE  L.CLI_CD = :CLI_CD  ")
            strSQL.Append("AND    L.HAN_CD = :HAN_CD  ")
            strSQL.Append("AND    L.USER_CD = :USER_CD  ")
            strSQL.Append("AND    KAITU_DAY >= TO_DATE(TO_CHAR(SYSDATE, 'YYYY/MM/DD'),'YYYY/MM/DD') ")
            strSQL.Append("AND    KAITU_FLG = '20' ")
            strSQL.Append("ORDER BY KAITU_DAY ")

            'パラメータのセット
            SqlParamC.fncSetParam("CLI_CD", True, hdnKEY_CLI_CD.Value)
            SqlParamC.fncSetParam("USER_CD", True, hdnKEY_USER_CD.Value)
            SqlParamC.fncSetParam("HAN_CD", True, hdnKEY_HAN_CD.Value)

            '//SQLの実行
            dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

            If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
                'データなしの場合
                strRes = ""
            Else
                'データありの場合
                strRes = Convert.ToString(dbData.Tables(0).Rows(0).Item("KAITU_DAY"))
            End If


        Catch ex As Exception
            Dim ErrMsgC As New CErrMsg
            strMsg.Append("alert('システムエラー：" & ErrMsgC.mGetArtMsg(ex.ToString) & "');")
            strRes = ""

        Finally
            If dbData Is Nothing Then
            Else
                dbData.Dispose()
            End If
        End Try

        Return strRes
    End Function

    '**********************************************************
    ' 2013/06/25 T.Ono
    'FAX不要区分(JA・ｸﾗｲｱﾝﾄ)、注意事項取得 fncSetData_TAIOU
    '**********************************************************
    Private Function fncGetFAXKBN_GUIDE_TAIOU() As String()
        Dim SQLC As New KETAIJAG00CSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet

        'Dim strRes(2) As String      '2019/11/01 W.GANEKO 2019監視改善 No8-12
        'For i As Integer = 0 To 2
        Dim strRes(4) As String       '2019/11/01 W.GANEKO 2019監視改善 No8-12
        For i As Integer = 0 To 4     '2019/11/01 W.GANEKO 2019監視改善 No8-12
            strRes(i) = ""
        Next

        Try
            strSQL = New StringBuilder("")
            '2016/02/02 w.ganeko 2015開発改善 №1 start
            'strSQL.Append("WITH ")
            'strSQL.Append("A AS( ")
            'strSQL.Append("SELECT B.KURACD, B.FAXKBN, B.FAXKURAKBN, B.GUIDELINE, B.USER_CD_FROM ")
            'strSQL.Append("FROM   D20_TAIOU A, ")
            'strSQL.Append("       M05_TANTO2 B ")
            'strSQL.Append("WHERE  A.KANSCD = :KANSCD ")
            'strSQL.Append("AND    A.SYONO = :SYONO ")
            'strSQL.Append("AND    B.KURACD = A.KURACD ")
            'strSQL.Append("AND    B.CODE = A.ACBCD ")
            'strSQL.Append("AND    KBN = '3' ")
            'strSQL.Append("AND    LPAD(B.TANCD, 2, '0') = '01' ")
            'strSQL.Append("AND	    B.USER_CD_TO IS NULL ")
            'strSQL.Append("AND	    A.USER_CD =  B.USER_CD_FROM  ")
            'strSQL.Append("), ")
            'strSQL.Append("B AS( ")
            'strSQL.Append("SELECT B.KURACD, B.FAXKBN, B.FAXKURAKBN, B.GUIDELINE, B.USER_CD_FROM ")
            'strSQL.Append("FROM   D20_TAIOU A, ")
            'strSQL.Append("       M05_TANTO2 B ")
            'strSQL.Append("WHERE  A.KANSCD = :KANSCD ")
            'strSQL.Append("AND    A.SYONO = :SYONO ")
            'strSQL.Append("AND    B.KURACD = A.KURACD ")
            'strSQL.Append("AND    B.CODE = A.ACBCD ")
            'strSQL.Append("AND    KBN = '3' ")
            'strSQL.Append("AND    LPAD(B.TANCD, 2, '0') = '01' ")
            'strSQL.Append("AND	    B.USER_CD_TO IS NULL ")
            'strSQL.Append("AND	    A.USER_CD =  B.USER_CD_FROM  ")
            'strSQL.Append("), ")
            'strSQL.Append("C AS( ")
            'strSQL.Append("SELECT B.KURACD, B.FAXKBN, B.FAXKURAKBN, B.GUIDELINE ")
            'strSQL.Append("FROM   D20_TAIOU A, ")
            'strSQL.Append("       M05_TANTO B ")
            'strSQL.Append("WHERE  A.KANSCD = :KANSCD ")
            'strSQL.Append("AND    A.SYONO = :SYONO ")
            'strSQL.Append("AND    B.KURACD = A.KURACD ")
            'strSQL.Append("AND    B.CODE = A.ACBCD ")
            'strSQL.Append("AND    KBN = '3' ")
            'strSQL.Append("AND    LPAD(B.TANCD, 2, '0') = '01' ")
            'strSQL.Append("), ")
            'strSQL.Append("D AS( ")
            'strSQL.Append("SELECT B.KURACD, B.FAXKBN, B.FAXKURAKBN, B.GUIDELINE ")
            'strSQL.Append("FROM   D20_TAIOU A, ")
            'strSQL.Append("       M05_TANTO B ")
            'strSQL.Append("WHERE  A.KANSCD = :KANSCD ")
            'strSQL.Append("AND    A.SYONO = :SYONO ")
            'strSQL.Append("AND    B.KURACD = A.KURACD ")
            'strSQL.Append("AND    B.CODE = A.JACD ")
            'strSQL.Append("AND    KBN = '3' ")
            'strSQL.Append("AND    LPAD(B.TANCD, 2, '0') = '01' ")
            'strSQL.Append("), ")
            ''2015/02/19 T.Ono add 2014改善開発 No15
            ''KEIHOU,KOKYAKUにはクライアントの検索を追加したが、TAIOUは報告要・不要区分は使用しないため、追加しない。
            strSQL.Append("WITH ")
            strSQL.Append("/* お客様個別 */ ")
            strSQL.Append("A AS( ")
            strSQL.Append("SELECT T.KURACD, T.USERCD_FROM, D.FAXKBN, D.FAXKURAKBN, D.GUIDELINE ")
            strSQL.Append(",D.GUIDELINE2 ")   '2019/11/01 W.GANEKO 2019監視改善 No8-12 
            strSQL.Append(",D.GUIDELINE3 ")   '2019/11/01 W.GANEKO 2019監視改善 No8-12 
            strSQL.Append("FROM   D20_TAIOU A, ")
            strSQL.Append("       M09_JAGROUP T, ")
            strSQL.Append("       M11_JAHOKOKU D ")
            strSQL.Append("WHERE  A.KANSCD = :KANSCD ")
            strSQL.Append("AND    A.SYONO = :SYONO ")
            strSQL.Append("AND    T.KBN = '002' ")
            strSQL.Append("AND    A.KURACD = T.KURACD ")
            strSQL.Append("AND    A.ACBCD = T.ACBCD ")
            strSQL.Append("AND    A.USER_CD = T.USERCD_FROM ")
            strSQL.Append("AND    T.USERCD_TO IS NULL ")
            strSQL.Append("AND    D.KBN = '2' ")
            strSQL.Append("AND    T.GROUPCD = D.GROUPCD ")
            strSQL.Append("AND    LPAD(D.TANCD, 2, '0') = '01' ")
            strSQL.Append("), ")
            strSQL.Append("/* お客様範囲 */ ")
            strSQL.Append("B AS ( ")
            strSQL.Append("SELECT T.KURACD, T.USERCD_FROM, D.FAXKBN, D.FAXKURAKBN, D.GUIDELINE ")
            strSQL.Append(",D.GUIDELINE2 ")   '2019/11/01 W.GANEKO 2019監視改善 No8-12 
            strSQL.Append(",D.GUIDELINE3 ")   '2019/11/01 W.GANEKO 2019監視改善 No8-12
            strSQL.Append("FROM   D20_TAIOU A, ")
            strSQL.Append("       M09_JAGROUP T, ")
            strSQL.Append("       M11_JAHOKOKU D ")
            strSQL.Append("WHERE  A.KANSCD = :KANSCD ")
            strSQL.Append("AND    A.SYONO = :SYONO ")
            strSQL.Append("AND    T.KBN = '002' ")
            strSQL.Append("AND    A.KURACD = T.KURACD ")
            strSQL.Append("AND    A.ACBCD = T.ACBCD ")
            strSQL.Append("AND    D.KBN = '2' ")
            strSQL.Append("AND    T.GROUPCD = D.GROUPCD ")
            strSQL.Append("AND    LPAD(D.TANCD, 2, '0') = '01' ")
            strSQL.Append("AND    T.USERCD_TO IS NOT NULL ")
            strSQL.Append("AND    A.USER_CD BETWEEN T.USERCD_FROM AND T.USERCD_TO ")
            strSQL.Append("), ")
            strSQL.Append("/* JA支所 */ ")
            strSQL.Append("C AS( ")
            strSQL.Append("SELECT T.KURACD, D.FAXKBN, D.FAXKURAKBN, D.GUIDELINE ")
            strSQL.Append(",D.GUIDELINE2 ")   '2019/11/01 W.GANEKO 2019監視改善 No8-12 
            strSQL.Append(",D.GUIDELINE3 ")   '2019/11/01 W.GANEKO 2019監視改善 No8-12
            strSQL.Append("FROM   D20_TAIOU A, ")
            strSQL.Append("       M09_JAGROUP T, ")
            strSQL.Append("       M11_JAHOKOKU D ")
            strSQL.Append("WHERE  A.KANSCD = :KANSCD ")
            strSQL.Append("AND    A.SYONO = :SYONO ")
            strSQL.Append("AND    T.KBN = '002' ")
            strSQL.Append("AND    A.KURACD = T.KURACD ")
            strSQL.Append("AND    A.ACBCD = T.ACBCD ")
            strSQL.Append("AND    D.KBN = '2' ")
            strSQL.Append("AND    T.GROUPCD = D.GROUPCD ")
            strSQL.Append("AND    LPAD(D.TANCD, 2, '0') = '01' ")
            strSQL.Append("AND    T.USERCD_FROM IS NULL ")
            strSQL.Append("AND    T.USERCD_TO IS NULL ")
            strSQL.Append("), ")
            '2016/02/02 w.ganeko 2015開発改善 №1 end
            strSQL.Append("E AS ( ")
            strSQL.Append("SELECT KURACD ")
            strSQL.Append("FROM   D20_TAIOU ")
            strSQL.Append("WHERE  KANSCD = :KANSCD ")
            strSQL.Append("AND    SYONO = :SYONO ")
            strSQL.Append(") ")
            '2016/02/02 w.ganeko 2015開発改善 №1 START
            'strSQL.Append("SELECT NVL(A.FAXKBN, NVL(B.FAXKBN, NVL(C.FAXKBN, NVL(D.FAXKBN, '0')))) AS FAXKBN, ")
            'strSQL.Append("       NVL(A.FAXKURAKBN, NVL(B.FAXKURAKBN, NVL(C.FAXKURAKBN, NVL(D.FAXKURAKBN, '0')))) AS FAXKURAKBN, ")
            'strSQL.Append("       NVL(A.GUIDELINE, NVL(B.GUIDELINE, NVL(C.GUIDELINE, NVL(D.GUIDELINE, '')))) AS GUIDELINE, ")
            'strSQL.Append("       NVL(A.USER_CD_FROM, NVL(B.USER_CD_FROM, '')) AS USER_CD_FROM ")
            'strSQL.Append("FROM A, B, C, D, E ")
            'strSQL.Append("WHERE  E.KURACD = A.KURACD(+) ")
            'strSQL.Append("AND    E.KURACD = B.KURACD(+) ")
            'strSQL.Append("AND    E.KURACD = C.KURACD(+) ")
            'strSQL.Append("AND    E.KURACD = D.KURACD(+) ")
            strSQL.Append("SELECT NVL(A.FAXKBN, NVL(B.FAXKBN, NVL(C.FAXKBN, '0'))) AS FAXKBN, ")
            strSQL.Append("       NVL(A.FAXKURAKBN, NVL(B.FAXKURAKBN, NVL(C.FAXKURAKBN, '0'))) AS FAXKURAKBN, ")
            strSQL.Append("       NVL(A.GUIDELINE, NVL(B.GUIDELINE, NVL(C.GUIDELINE, ''))) AS GUIDELINE, ")
            strSQL.Append("       NVL(A.GUIDELINE2, NVL(B.GUIDELINE2, NVL(C.GUIDELINE2, ''))) AS GUIDELINE2, ")   '2019/11/01 W.GANEKO 2019監視改善 No8-12 
            strSQL.Append("       NVL(A.GUIDELINE3, NVL(B.GUIDELINE3, NVL(C.GUIDELINE3, ''))) AS GUIDELINE3, ")   '2019/11/01 W.GANEKO 2019監視改善 No8-12 
            strSQL.Append("       NVL(A.USERCD_FROM, NVL(B.USERCD_FROM, '')) AS USER_CD_FROM ")
            strSQL.Append("FROM A, B, C, E ")
            strSQL.Append("WHERE  E.KURACD = A.KURACD(+) ")
            strSQL.Append("AND    E.KURACD = B.KURACD(+) ")
            strSQL.Append("AND    E.KURACD = C.KURACD(+) ")
            '2016/02/02 w.ganeko 2015開発改善 №1 end

            'パラメータのセット
            SqlParamC.fncSetParam("KANSCD", True, hdnKEY_KANSCD.Value)
            SqlParamC.fncSetParam("SYONO", True, hdnKEY_SYONO.Value)

            '//SQLの実行
            dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

            If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
                'データなしの場合
                strRes(0) = "0"
                strRes(1) = "0"
                strRes(2) = ""
                strRes(3) = ""     '2019/11/01 W.GANEKO 2019監視改善 No8-12
                strRes(4) = ""     '2019/11/01 W.GANEKO 2019監視改善 No8-12
            Else
                'データありの場合
                strRes(0) = Convert.ToString(dbData.Tables(0).Rows(0).Item("FAXKBN"))
                strRes(1) = Convert.ToString(dbData.Tables(0).Rows(0).Item("FAXKURAKBN"))
                strRes(2) = Convert.ToString(dbData.Tables(0).Rows(0).Item("GUIDELINE"))
                strRes(3) = Convert.ToString(dbData.Tables(0).Rows(0).Item("GUIDELINE2")) '2019/11/01 W.GANEKO 2019監視改善 No8-12 
                strRes(4) = Convert.ToString(dbData.Tables(0).Rows(0).Item("GUIDELINE3")) '2019/11/01 W.GANEKO 2019監視改善 No8-12 
                hdnUSER_CD_FROM.Value = Convert.ToString(dbData.Tables(0).Rows(0).Item("USER_CD_FROM"))
            End If

        Catch ex As Exception
            Dim ErrMsgC As New CErrMsg
            strMsg.Append("alert('システムエラー：" & ErrMsgC.mGetArtMsg(ex.ToString) & "');")
            For i As Integer = 0 To 2
                strRes(i) = ""
            Next

        Finally
            If dbData Is Nothing Then
            Else
                dbData.Dispose()
            End If
        End Try

        Return strRes
    End Function

    '**********************************************************
    ' 2013/08/20 T.Ono add 監視改善2013№1
    '警報メッセージの入れ替え
    '**********************************************************
    Private Sub fncSetMessage()

        If rdoMsg1.Checked = True Then
            gstrKMCD1 = hdnKMCD1.Value
            gstrKMNM1 = hdnKMNM1.Value
            gstrKMCD2 = hdnKMCD2.Value
            gstrKMNM2 = hdnKMNM2.Value
            gstrKMCD3 = hdnKMCD3.Value
            gstrKMNM3 = hdnKMNM3.Value
            gstrKMCD4 = hdnKMCD4.Value
            gstrKMNM4 = hdnKMNM4.Value
            gstrKMCD5 = hdnKMCD5.Value
            gstrKMNM5 = hdnKMNM5.Value
            gstrKMCD6 = hdnKMCD6.Value
            gstrKMNM6 = hdnKMNM6.Value
        ElseIf rdoMsg2.Checked Then
            gstrKMCD1 = hdnKMCD2.Value
            gstrKMNM1 = hdnKMNM2.Value
            gstrKMCD2 = hdnKMCD1.Value
            gstrKMNM2 = hdnKMNM1.Value
            gstrKMCD3 = hdnKMCD3.Value
            gstrKMNM3 = hdnKMNM3.Value
            gstrKMCD4 = hdnKMCD4.Value
            gstrKMNM4 = hdnKMNM4.Value
            gstrKMCD5 = hdnKMCD5.Value
            gstrKMNM5 = hdnKMNM5.Value
            gstrKMCD6 = hdnKMCD6.Value
            gstrKMNM6 = hdnKMNM6.Value
        ElseIf rdoMsg3.Checked Then
            gstrKMCD1 = hdnKMCD3.Value
            gstrKMNM1 = hdnKMNM3.Value
            gstrKMCD2 = hdnKMCD1.Value
            gstrKMNM2 = hdnKMNM1.Value
            gstrKMCD3 = hdnKMCD2.Value
            gstrKMNM3 = hdnKMNM2.Value
            gstrKMCD4 = hdnKMCD4.Value
            gstrKMNM4 = hdnKMNM4.Value
            gstrKMCD5 = hdnKMCD5.Value
            gstrKMNM5 = hdnKMNM5.Value
            gstrKMCD6 = hdnKMCD6.Value
            gstrKMNM6 = hdnKMNM6.Value
        ElseIf rdoMsg4.Checked Then
            gstrKMCD1 = hdnKMCD4.Value
            gstrKMNM1 = hdnKMNM4.Value
            gstrKMCD2 = hdnKMCD1.Value
            gstrKMNM2 = hdnKMNM1.Value
            gstrKMCD3 = hdnKMCD2.Value
            gstrKMNM3 = hdnKMNM2.Value
            gstrKMCD4 = hdnKMCD3.Value
            gstrKMNM4 = hdnKMNM3.Value
            gstrKMCD5 = hdnKMCD5.Value
            gstrKMNM5 = hdnKMNM5.Value
            gstrKMCD6 = hdnKMCD6.Value
            gstrKMNM6 = hdnKMNM6.Value
        ElseIf rdoMsg5.Checked Then
            gstrKMCD1 = hdnKMCD5.Value
            gstrKMNM1 = hdnKMNM5.Value
            gstrKMCD2 = hdnKMCD1.Value
            gstrKMNM2 = hdnKMNM1.Value
            gstrKMCD3 = hdnKMCD2.Value
            gstrKMNM3 = hdnKMNM2.Value
            gstrKMCD4 = hdnKMCD3.Value
            gstrKMNM4 = hdnKMNM3.Value
            gstrKMCD5 = hdnKMCD4.Value
            gstrKMNM5 = hdnKMNM4.Value
            gstrKMCD6 = hdnKMCD6.Value
            gstrKMNM6 = hdnKMNM6.Value
        ElseIf rdoMsg6.Checked Then
            gstrKMCD1 = hdnKMCD6.Value
            gstrKMNM1 = hdnKMNM6.Value
            gstrKMCD2 = hdnKMCD1.Value
            gstrKMNM2 = hdnKMNM1.Value
            gstrKMCD3 = hdnKMCD2.Value
            gstrKMNM3 = hdnKMNM2.Value
            gstrKMCD4 = hdnKMCD3.Value
            gstrKMNM4 = hdnKMNM3.Value
            gstrKMCD5 = hdnKMCD4.Value
            gstrKMNM5 = hdnKMNM4.Value
            gstrKMCD6 = hdnKMCD5.Value
            gstrKMNM6 = hdnKMNM5.Value
        End If
    End Sub

    '**********************************************************
    ' 2014/02/10 T.Ono add 監視改善2013 重複表示
    '自動対応内容マスタより、自動的に重複と表示する
    '**********************************************************
    Private Function fncChoufukuHyouji() As KETAIJAG00DTO.AutoTaiouDto
        Dim res As New KETAIJAG00DTO.AutoTaiouDto
        Dim SQLC As New KETAIJAG00CSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet
        Dim dbKeiho As DataSet '2014/06/23 T.Ono add 重複表示エラー対応

        Dim kmdto As KETAIJAG00DTO.KmDto
        Dim kmList As ArrayList
        Dim autoTaiouList As KETAIJAG00DTO.AutoTaiouLists

        Try
            '*-----------------------------------------------------*
            ' 警報に重複表示の対処があるか
            '*-----------------------------------------------------*
            strSQL = New StringBuilder("")
            strSQL.Append(getSqlExistsChoufukuHyouji())
            '//SQLの実行
            '2014/06/23 T.Ono mod START 重複表示エラー　ここの取得結果(警報データ)は後で使うので別の変数に格納
            'dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

            'If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
            '    '無ければ抜ける
            '    Return res
            'End If

            ''*-----------------------------------------------------*
            '' 警報メッセージリスト作成
            ''*-----------------------------------------------------*
            'kmList = New ArrayList
            'For intLoop As Integer = 1 To 6
            '    '警報メッセージ数算出処理
            '    If Convert.ToString(dbData.Tables(0).Rows(0).Item("KMCD" & intLoop)) <> "" Then
            '        '値が入っていれば警報メッセージをリストにセット
            '        kmdto = New KETAIJAG00DTO.KmDto( _
            '                        Convert.ToString(dbData.Tables(0).Rows(0).Item("KMCD" & intLoop)) _
            '                        , Convert.ToString(dbData.Tables(0).Rows(0).Item("KMNM" & intLoop)))
            '        kmList.Add(kmdto)
            '    End If
            'Next
            dbKeiho = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)
            If Convert.ToString(dbKeiho.Tables(0).Rows(0).Item(0)) = "XYZ" Then
                '無ければ抜ける
                Return res
            End If

            '*-----------------------------------------------------*
            ' 警報メッセージリスト作成
            '*-----------------------------------------------------*
            kmList = New ArrayList
            For intLoop As Integer = 1 To 6
                '警報メッセージ数算出処理
                If Convert.ToString(dbKeiho.Tables(0).Rows(0).Item("KMCD" & intLoop)) <> "" Then
                    '値が入っていれば警報メッセージをリストにセット
                    kmdto = New KETAIJAG00DTO.KmDto( _
                                    Convert.ToString(dbKeiho.Tables(0).Rows(0).Item("KMCD" & intLoop)) _
                                    , Convert.ToString(dbKeiho.Tables(0).Rows(0).Item("KMNM" & intLoop)))
                    kmList.Add(kmdto)
                End If
            Next
            '2014/06/23 T.Ono mod END 重複表示エラー

            '*-----------------------------------------------------*
            ' 2.自動対応内容リスト作成
            '*-----------------------------------------------------*
            strSQL = New StringBuilder("")
            strSQL.Append(getSqlAutoTaiouList())
            '//SQLの実行
            dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

            If (dbData.Tables(0).Rows.Count = 0) Then
                '無ければ抜ける
                Return res
            End If

            '*-----------------------------------------------------*
            ' 2-2.自動対応内容リストを、自動対応、無視、重複表示ごとにリスト化
            '*-----------------------------------------------------*
            autoTaiouList = New KETAIJAG00DTO.AutoTaiouLists(dbData.Tables(0))


            '無視リストのチェック
            For Each atDto As KETAIJAG00DTO.AutoTaiouDto In CType(autoTaiouList.procListByIgnore, ArrayList)
                If atDto.prockbn.ToString = "2" AndAlso isExists(kmList, CType(atDto.pkmDto, KETAIJAG00DTO.KmDto)) > -1 Then
                    '*-----------------------------------------------------*
                    ' 3.自動対応内容.対応・無視区分="2"は、警報メッセージリストから削除
                    '*-----------------------------------------------------*
                    kmList.RemoveAt(isExists(kmList, CType(atDto.pkmDto, KETAIJAG00DTO.KmDto)))

                ElseIf atDto.prockbn.ToString = "3" Then
                    '*-----------------------------------------------------*
                    ' 4.対応・無視区分が"3"無視に設定されている場合は、セキュリティ情報テーブルを確認
                    '*-----------------------------------------------------*
                    If isExists(kmList, CType(atDto.pkmDto, KETAIJAG00DTO.KmDto)) > -1 Then
                        '*-----------------------------------------------------*
                        ' 4-1.セキュリティ情報テーブルを参照する
                        '     条件：クライアントコード, JA支所コード, 顧客コード
                        '*-----------------------------------------------------*
                        Dim seqSql As New StringBuilder
                        'Dim bExex As Boolean = getSqlSecurityInfo(seqSql, dbData.Tables(0).Rows(0), Convert.ToString(CType(atDto.pkmDto, KETAIJAG00DTO.KmDto).KmCd)) 2014/06/23 T.Ono mod 重複表示エラー
                        Dim bExex As Boolean = getSqlSecurityInfo(seqSql, dbKeiho.Tables(0).Rows(0), Convert.ToString(CType(atDto.pkmDto, KETAIJAG00DTO.KmDto).KmCd))

                        If bExex Then
                            strSQL = New StringBuilder("")
                            strSQL.Append(seqSql.ToString)
                            '//SQLの実行
                            dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)
                        Else
                            Return res
                        End If
                        '*-----------------------------------------------------*
                        ' 4-2.取得できない場合、重複表示は行わない
                        '*-----------------------------------------------------*
                        'If (dbData.Tables(0).Rows.Count = 0) Then 2014/06/23 T.Ono mod 重複表示エラー
                        If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
                            Return res
                        End If

                        '*-----------------------------------------------------*
                        ' 4-3.出力有無フラグが出力ありの場合、重複表示は行わない
                        '*-----------------------------------------------------*
                        For intSec As Integer = 0 To dbData.Tables(0).Rows.Count - 1
                            If "1".Equals(Convert.ToString(dbData.Tables(0).Rows(0).Item("OUT_FLG"))) Then
                                Return res
                            End If
                        Next
                        kmList.RemoveAt(isExists(kmList, CType(atDto.pkmDto, KETAIJAG00DTO.KmDto)))
                    End If
                End If
            Next

            '*-----------------------------------------------------*
            ' 5.リストアップした警報コードから除外した結果、データが
            '   存在していない、またはひとつに絞れない場合は、重複表示は行わない
            '*-----------------------------------------------------*
            If kmList.Count <> 1 Then
                Return res
            End If

            '*-----------------------------------------------------*
            ' 6.リストアップした警報コードと警報名称を元に、
            '   自動対応内容テーブルから重複表示を行うデータを抽出する。
            '*-----------------------------------------------------*
            For Each atDto As KETAIJAG00DTO.AutoTaiouDto In CType(autoTaiouList.procListByChoufuku, ArrayList)
                If CType(kmList(0), KETAIJAG00DTO.KmDto).isEquals _
                                                            (CType(atDto.pkmDto, KETAIJAG00DTO.KmDto)) Then
                    res = atDto
                    Return res
                End If
            Next

        Catch ex As Exception
            Dim ErrMsgC As New CErrMsg
            strMsg.Append("alert('システムエラー：" & ErrMsgC.mGetArtMsg(ex.ToString) & "');")
        Finally
            If dbData Is Nothing Then
            Else
                dbData.Dispose()
            End If
            '2014/06/23 T.Ono mod 重複表示エラー
            If dbKeiho Is Nothing Then
            Else
                dbKeiho.Dispose()
            End If
        End Try

        Return res
    End Function
    '************************************************
    '2014/02/10 T.Ono add 監視改善2013
    ' 重複表示を行う対象のデータ取得SQL
    '************************************************
    Private Function getSqlExistsChoufukuHyouji() As String

        Dim strSQL As StringBuilder = New StringBuilder
        '+----------------------------------------------------+
        '|重複表示を行う対象のデータの取得するSQL
        '+----------------------------------------------------+
        strSQL.Append("SELECT ")
        strSQL.Append("  KEI.SYORI_SERIAL ")
        strSQL.Append("  ,KEI.REACTION ")
        strSQL.Append("  ,KEI.KANSCD ")
        strSQL.Append("  ,KEI.KURACD ")
        strSQL.Append("  ,KEI.ACBCD ")
        strSQL.Append("  ,KEI.JUYOKA ")
        strSQL.Append("  ,KEI.KMCD1 ")
        strSQL.Append("  ,KEI.KMNM1 ")
        strSQL.Append("  ,KEI.KMCD2 ")
        strSQL.Append("  ,KEI.KMNM2 ")
        strSQL.Append("  ,KEI.KMCD3 ")
        strSQL.Append("  ,KEI.KMNM3 ")
        strSQL.Append("  ,KEI.KMCD4 ")
        strSQL.Append("  ,KEI.KMNM4 ")
        strSQL.Append("  ,KEI.KMCD5 ")
        strSQL.Append("  ,KEI.KMNM5 ")
        strSQL.Append("  ,KEI.KMCD6 ")
        strSQL.Append("  ,KEI.KMNM6 ")
        strSQL.Append("FROM ")
        strSQL.Append("  T10_KEIHO KEI ")
        strSQL.Append("WHERE ")
        strSQL.Append("  KEI.SYORI_SERIAL = '" & hdnKEY_SERIAL.Value & "' ")
        '2017/02/09 W.GANEKO UPD START 2016監視改善 №10
        strSQL.Append("  AND EXISTS (SELECT ")
        strSQL.Append("                'X' ")
        strSQL.Append("              FROM ")
        strSQL.Append("                M09_JAGROUP JAGRP ")
        strSQL.Append("                ,M08_AUTOTAIOU ATTAI ")
        strSQL.Append("              WHERE ")
        strSQL.Append("                JAGRP.KBN = '003' ")
        strSQL.Append("                AND JAGRP.KURACD = KEI.KURACD ")
        strSQL.Append("                AND JAGRP.ACBCD = KEI.ACBCD ")
        strSQL.Append("                AND JAGRP.GROUPCD = ATTAI.GROUPCD ")
        strSQL.Append("                AND ATTAI.USE_FLG = '1' ")
        strSQL.Append("                AND ATTAI.PROCKBN = '4' ")
        strSQL.Append("                AND ATTAI.KMCD IN (KEI.KMCD1, KEI.KMCD2, KEI.KMCD3, KEI.KMCD4, KEI.KMCD5, KEI.KMCD6) ")
        strSQL.Append("              ) ")
        'strSQL.Append("  AND EXISTS (SELECT ")
        'strSQL.Append("                'X' ")
        'strSQL.Append("              FROM ")
        'strSQL.Append("                M07_AUTOTAIOUGROUP ATTAIGRP ")
        'strSQL.Append("                ,M08_AUTOTAIOU ATTAI ")
        'strSQL.Append("              WHERE ")
        'strSQL.Append("                ATTAIGRP.KURACD = KEI.KURACD ")
        'strSQL.Append("                AND ATTAIGRP.ACBCD = KEI.ACBCD ")
        'strSQL.Append("                AND ATTAIGRP.USE_FLG = '1' ")
        'strSQL.Append("                AND ATTAIGRP.GROUPCD = ATTAI.GROUPCD ")
        'strSQL.Append("                AND ATTAI.USE_FLG = '1' ")
        'strSQL.Append("                AND ATTAI.PROCKBN = '4' ")
        'strSQL.Append("                AND ATTAI.KMCD IN (KEI.KMCD1, KEI.KMCD2, KEI.KMCD3, KEI.KMCD4, KEI.KMCD5, KEI.KMCD6) ")
        'strSQL.Append("              ) ")
        '2017/02/09 W.GANEKO UPD END 2016監視改善 №10

        Return strSQL.ToString

    End Function

    '************************************************
    '2014/02/10 T.Ono add 監視改善2013
    ' 自動対応内容のリストを取得SQL
    '************************************************
    Private Function getSqlAutoTaiouList() As String
        Dim strSQL As StringBuilder = New StringBuilder
        '+----------------------------------------------------+
        '|自動対応内容のリストを取得するSQL
        '+----------------------------------------------------+
        strSQL.Append("WITH TN AS ") '監視センター担当者の一覧
        strSQL.Append("	(SELECT ")
        strSQL.Append("	        A.CODE ")
        strSQL.Append("		    ,A.TANCD ")
        strSQL.Append("		    ,A.TANNM ")
        strSQL.Append("	FROM	M05_TANTO A ")
        strSQL.Append("		    ,T10_KEIHO B ")
        strSQL.Append("	WHERE ")
        strSQL.Append("		    B.SYORI_SERIAL = '" & hdnKEY_SERIAL.Value & "' ")
        strSQL.Append("	AND	    B.KANSCD = A.CODE ")
        strSQL.Append("	AND     A.KBN = '1' ") '2016/02/24 T.Ono add 区分指定し、ﾊﾟﾌｫｰﾏﾝｽ向上
        strSQL.Append("	    ) ")
        strSQL.Append("SELECT ")
        strSQL.Append("	    AN.GROUPCD ")
        strSQL.Append("	    ,AN.KMCD ")
        strSQL.Append("	    ,AN.KMNM ")
        strSQL.Append("	    ,AN.PROCKBN ")
        strSQL.Append("	    ,AN.TAIOKBN ")
        strSQL.Append("	    ,AN.TMSKB ")
        strSQL.Append("	    ,AN.TKTANCD ")
        strSQL.Append("	    ,AN.TAITCD ")
        strSQL.Append("	    ,AN.TFKICD ")
        strSQL.Append("	    ,AN.TKIGCD ")
        strSQL.Append("	    ,AN.TSADCD ")
        strSQL.Append("	    ,AN.TELRCD ")
        strSQL.Append("	    ,AN.TEL_MEMO1 ")
        strSQL.Append("	    ,AN.USE_FLG ")
        strSQL.Append("	    ,AN.INS_DATE ")
        strSQL.Append("	    ,AN.UPD_DATE ")
        strSQL.Append("	    ,TN.TANNM ")
        strSQL.Append("FROM ")
        strSQL.Append(" 	T10_KEIHO KEI ")
        '2017/02/09 W.GANEKO UPD START 2016監視改善 №10
        strSQL.Append("	    ,M09_JAGROUP JA ")
        strSQL.Append("	    ,M08_AUTOTAIOU AN ")
        strSQL.Append("	    ,TN ")
        strSQL.Append("WHERE ")
        strSQL.Append(" 	KEI.SYORI_SERIAL = '" & hdnKEY_SERIAL.Value & "' ")
        strSQL.Append("AND	KEI.KURACD = JA.KURACD ")
        strSQL.Append("AND	KEI.ACBCD = JA.ACBCD ")
        strSQL.Append("AND	JA.KBN = '003' ")
        strSQL.Append("AND	JA.GROUPCD = AN.GROUPCD ")
        strSQL.Append("AND	AN.USE_FLG = '1' ")
        strSQL.Append("AND	AN.TKTANCD = TN.TANCD(+) ")
        strSQL.Append("AND  EXISTS ") '重複表示の対象警報があるか
        strSQL.Append("     (SELECT	'X' ")
        strSQL.Append("     FROM ")
        strSQL.Append("     	    M08_AUTOTAIOU AN2 ")
        strSQL.Append("     WHERE ")
        strSQL.Append("     	    KEI.KURACD = JA.KURACD ")
        strSQL.Append("     AND	    KEI.ACBCD = JA.ACBCD ")
        strSQL.Append("     AND     JA.KBN = '003' ")
        strSQL.Append("     AND	    JA.GROUPCD = AN2.GROUPCD ")
        strSQL.Append("     AND	    AN2.PROCKBN = '4' ")
        strSQL.Append("     AND	    AN2.USE_FLG = '1' ")
        strSQL.Append("     AND	    AN2.KMCD IN (KEI.KMCD1, KEI.KMCD2, KEI.KMCD3, KEI.KMCD4, KEI.KMCD5, KEI.KMCD6) ")
        strSQL.Append("	) ")
        strSQL.Append("ORDER BY AN.PROCKBN ")
        'strSQL.Append("	    ,M07_AUTOTAIOUGROUP AG ")
        'strSQL.Append("	    ,M08_AUTOTAIOU AN ")
        'strSQL.Append("	    ,TN ")
        'strSQL.Append("WHERE ")
        'strSQL.Append(" 	KEI.SYORI_SERIAL = '" & hdnKEY_SERIAL.Value & "' ")
        'strSQL.Append("AND	KEI.KURACD = AG.KURACD ")
        'strSQL.Append("AND	KEI.ACBCD = AG.ACBCD ")
        'strSQL.Append("AND	AG.USE_FLG = '1' ")
        'strSQL.Append("AND	AG.GROUPCD = AN.GROUPCD ")
        'strSQL.Append("AND	AN.USE_FLG = '1' ")
        'strSQL.Append("AND	AN.TKTANCD = TN.TANCD(+) ")
        'strSQL.Append("AND  EXISTS ") '重複表示の対象警報があるか
        'strSQL.Append("     (SELECT	'X' ")
        'strSQL.Append("     FROM ")
        'strSQL.Append("     	    M08_AUTOTAIOU AN2 ")
        'strSQL.Append("     WHERE ")
        'strSQL.Append("     	    KEI.KURACD = AG.KURACD ")
        'strSQL.Append("     AND	    KEI.ACBCD = AG.ACBCD ")
        'strSQL.Append("     AND	    AG.USE_FLG = '1' ")
        'strSQL.Append("     AND	    AG.GROUPCD = AN2.GROUPCD ")
        'strSQL.Append("     AND	    AN2.PROCKBN = '4' ")
        'strSQL.Append("     AND	    AN2.USE_FLG = '1' ")
        'strSQL.Append("     AND	    AN2.KMCD IN (KEI.KMCD1, KEI.KMCD2, KEI.KMCD3, KEI.KMCD4, KEI.KMCD5, KEI.KMCD6) ")
        'strSQL.Append("	) ")
        'strSQL.Append("ORDER BY AN.PROCKBN ")
        '2017/02/09 W.GANEKO UPD END 2016監視改善 №10

        Return strSQL.ToString

    End Function

    '********************************************************
    '2014/02/10 T.Ono add 監視改善2013
    'セキュリティ情報抽出SQL生成
    '********************************************************
    Private Function getSqlSecurityInfo(ByRef sql As StringBuilder, ByVal row As DataRow, ByVal kmcd As String) As Boolean
        Dim KM_ZAN1 As String = "29" '警告：残量警告１
        Dim KM_ZAN2 As String = "28" '警告：残量警告２
        Dim KM_ZAN3 As String = "27" '警告：残量警告３
        '上記以外の警報コード以外は、セキュリティ情報を見ていない…

        sql.Append("SELECT ")
        sql.Append("  CLI_CD ")
        sql.Append("  ,HAN_CD ")
        sql.Append("  ,USER_CD ")
        sql.Append("  ,OUT_FLG ")
        sql.Append("  ,SEQMSG ")
        sql.Append("FROM ")
        sql.Append("  SQIMAS ")
        sql.Append("WHERE ")
        sql.Append("  CLI_CD = '" & Convert.ToString(row.Item("KURACD")) & "' ")
        sql.Append("  AND (HAN_CD = '" & Convert.ToString(row.Item("ACBCD")) & "' OR NOT REGEXP_LIKE(HAN_CD, '[0-9]')) ")
        sql.Append("  AND (USER_CD = '" & Convert.ToString(row.Item("JUYOKA")) & "' OR NOT REGEXP_LIKE(USER_CD, '[0-9]')) ")

        Select Case kmcd
            Case KM_ZAN3
                sql.Append("  AND SEQ_GRP1 = '2' ")
                sql.Append("  AND SEQ_GRP2 = '06' ")
                sql.Append("  AND SEQ_GRP3 = '020' ")
                sql.Append("  AND ID_BYTE  = '3' ")
                sql.Append("  AND SEQ_BYTE1_1 = '20' ")
                sql.Append("  AND SEQ_CD1_1   = '2---0' ")
                sql.Append("  AND SEQ_BYTE1_2 = '25' ")
                sql.Append("  AND SEQ_CD1_2 LIKE '___4___' ")
            Case KM_ZAN2
                sql.Append("  AND SEQ_GRP1 = '2' ")
                sql.Append("  AND SEQ_GRP2 = '07' ")
                sql.Append("  AND SEQ_GRP3 = '020' ")
                sql.Append("  AND ID_BYTE  = '3' ")
                sql.Append("  AND SEQ_BYTE1_1 = '20' ")
                sql.Append("  AND SEQ_CD1_1   = '2---0' ")
                sql.Append("  AND SEQ_BYTE1_2 = '25' ")
                sql.Append("  AND SEQ_CD1_2 LIKE '___2___' ")
            Case KM_ZAN1
                sql.Append("  AND SEQ_GRP1 = '2' ")
                sql.Append("  AND SEQ_GRP2 = '08' ")
                sql.Append("  AND SEQ_GRP3 = '020' ")
                sql.Append("  AND ID_BYTE  = '3' ")
                sql.Append("  AND SEQ_BYTE1_1 = '20' ")
                sql.Append("  AND SEQ_CD1_1   = '2---0' ")
                sql.Append("  AND SEQ_BYTE1_2 = '25' ")
                sql.Append("  AND SEQ_CD1_2 LIKE '___1___' ")
            Case Else
                '次のレコードへ
                Return False
        End Select

        sql.Append("ORDER BY ")
        sql.Append("  USER_CD DESC ")
        sql.Append("  ,HAN_CD DESC ")

        Return True
    End Function

    '2014/02/10 T.Ono add 監視改善2013
    Private Function isExists(ByVal list As ArrayList, ByVal kmDto As KETAIJAG00DTO.KmDto) As Integer
        Dim i As Integer = 0
        For Each dto As KETAIJAG00DTO.KmDto In list
            If dto.isEquals(kmDto) Then
                Return i
            End If
            i = i + 1
        Next
        Return -1
    End Function
    '**********************************************************
    ' 2016/02/02 W.GANEKO 2015監視改善 №1
    'SHAMAS取得
    '**********************************************************
    Private Function fncGetSHAMAS() As String()
        Dim SQLC As New KETAIJAG00CSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet

        Dim strRes(9) As String
        'For i As Integer = 0 To 5  2016/12/12 H.Mori Mod 2016改善開発 No5-1
        For i As Integer = 0 To 8
            strRes(i) = ""
        Next

        Try
            strSQL = New StringBuilder("")

            strSQL.Append("SELECT ")
            strSQL.Append(" * ")                                     '//ロックフラグ
            strSQL.Append("FROM ")
            strSQL.Append("SHAMAS ")                                 '//警報ＤＢ
            strSQL.Append("WHERE ")
            strSQL.Append("CLI_CD = :CLI_CD ")
            strSQL.Append("AND HAN_CD = :HAN_CD ")
            strSQL.Append("AND USER_CD = :USER_CD ")
            'パラメータのセット
            SqlParamC.fncSetParam("CLI_CD", True, txtClientCD.Text)
            SqlParamC.fncSetParam("HAN_CD", True, hdnJASCD.Value)
            SqlParamC.fncSetParam("USER_CD", True, txtJUYOKA.Text)

            '//SQLの実行
            dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

            If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
                'データなしの場合
            Else
                'データありの場合
                strRes(0) = Convert.ToString(dbData.Tables(0).Rows(0).Item("RENTEL2"))
                strRes(1) = Convert.ToString(dbData.Tables(0).Rows(0).Item("RENTEL2_BIKO"))
                strRes(2) = Convert.ToString(dbData.Tables(0).Rows(0).Item("RENTEL2_UPD_DATE"))
                strRes(3) = Convert.ToString(dbData.Tables(0).Rows(0).Item("RENTEL3"))
                strRes(4) = Convert.ToString(dbData.Tables(0).Rows(0).Item("RENTEL3_BIKO"))
                strRes(5) = Convert.ToString(dbData.Tables(0).Rows(0).Item("RENTEL3_UPD_DATE"))
                '2016/12/12 H.Mori add 2016改善開発 No5-1 START
                strRes(6) = Convert.ToString(dbData.Tables(0).Rows(0).Item("TELA"))
                strRes(7) = Convert.ToString(dbData.Tables(0).Rows(0).Item("TELB"))
                strRes(8) = Convert.ToString(dbData.Tables(0).Rows(0).Item("DAI3RENDORENTEL"))
                '2016/12/12 H.Mori add 2016改善開発 No5-1 END
            End If

        Catch ex As Exception
            Dim ErrMsgC As New CErrMsg
            strMsg.Append("alert('システムエラー：" & ErrMsgC.mGetArtMsg(ex.ToString) & "');")
            'For i As Integer = 0 To 5  2016/12/12 H.Mori Mod 2016改善開発 No5-1
            For i As Integer = 0 To 8
                strRes(i) = ""
            Next
        Finally
            If dbData Is Nothing Then
            Else
                dbData.Dispose()
            End If
        End Try

        Return strRes
    End Function
    ' 2016/02/02 W.GANEKO 2015監視改善 №1　END

    '**********************************************************
    '  監視センター担当者情報を取得する
    '  2020/11/01 T.Ono add 2020監視改善
    '**********************************************************
    Private Function fncGetTANInfo() As String()
        Dim SQLC As New KETAIJAG00CSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet
        Dim strRes() As String = {"", ""}

        Try
            strSQL = New StringBuilder("")
            strSQL.Append("SELECT ")
            strSQL.Append("       TANCD ")
            strSQL.Append("       ,TANNM ")
            strSQL.Append("FROM   M05_TANTO ")
            strSQL.Append("WHERE  KBN = '1' ")
            strSQL.Append("AND    GUIDELINE = :TANID ")    'GUIDELINE担当者IDが格納されてる
            If hdnKANSCD.Value.Trim <> "" Then
                strSQL.Append("AND    CODE = :KANSCD ")
                SqlParamC.fncSetParam("KANSCD", True, hdnKANSCD.Value)
            End If

            'パラメータのセット
            SqlParamC.fncSetParam("TANID", True, AuthC.pUSERNAME)

            '//SQLの実行
            dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

            If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
                'データなしの場合
            Else
                'データありの場合
                strRes(0) = Convert.ToString(dbData.Tables(0).Rows(0).Item("TANCD"))  '担当者CD
                strRes(1) = Convert.ToString(dbData.Tables(0).Rows(0).Item("TANNM"))  '担当者名
            End If

        Catch ex As Exception
            Dim ErrMsgC As New CErrMsg
            strMsg.Append("alert('システムエラー：" & ErrMsgC.mGetArtMsg(ex.ToString) & "');")
        Finally
            If dbData Is Nothing Then
            Else
                dbData.Dispose()
            End If
        End Try

        Return strRes
    End Function

End Class
