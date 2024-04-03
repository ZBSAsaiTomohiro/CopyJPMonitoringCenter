'***********************************************
'連絡先画面
'***********************************************
' 変更履歴
' 2010/04/28 T.Watabe 連絡先を３０に増加
' 2010/04/28 T.Watabe クライアント、ＪＡ毎にファイルを２つまで参照できるように変更
' 2012/03/23 W.GANEKO SPOTメール送信機能追加
Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common

Imports System.Text
Imports System.IO
Imports JPG.Common.log

Partial Class KETAIJTG00
    Inherits System.Web.UI.Page
    '--- ↓2005/04/25 ADD Falcon↓ ---
    '--- ↑2005/04/25 ADD Falcon↑ ---

    ' 2008/10/31 T.Watabe add

    ' 2010/04/15 T.Watabe add



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

        '2012/04/04 NEC ou Add Str
        '.NETの仕様変更により、ReadOnly属性をASPXでつけると、サーバ側で値の参照ができなくなるため、VB側でAttributeでつける
        If MyBase.IsPostBack = False Then
            '2016/05/10 w.ganeko mod start Load時以外も使用するため関数化
            Call SetInitKETAIJAG00()
            'txtACBNM.Attributes.Add("ReadOnly", "true")
            'txtACBKN.Attributes.Add("ReadOnly", "true")
            'txtTANNM5.Attributes.Add("ReadOnly", "true")
            'txtBIKO5.Attributes.Add("ReadOnly", "true")
            'txtRENTEL1_5.Attributes.Add("ReadOnly", "true")
            'txtRENTEL2_5.Attributes.Add("ReadOnly", "true")
            'txtRENTEL3_5.Attributes.Add("ReadOnly", "true") '2013/05/27 T.Ono add
            'txtFAX5.Attributes.Add("ReadOnly", "true")
            'txtTANNM6.Attributes.Add("ReadOnly", "true")
            'txtBIKO6.Attributes.Add("ReadOnly", "true")
            'txtRENTEL1_6.Attributes.Add("ReadOnly", "true")
            'txtRENTEL2_6.Attributes.Add("ReadOnly", "true")
            'txtRENTEL3_6.Attributes.Add("ReadOnly", "true") '2013/05/27 T.Ono add
            'txtFAX6.Attributes.Add("ReadOnly", "true")
            'txtTANNM7.Attributes.Add("ReadOnly", "true")
            'txtBIKO7.Attributes.Add("ReadOnly", "true")
            'txtRENTEL1_7.Attributes.Add("ReadOnly", "true")
            'txtRENTEL2_7.Attributes.Add("ReadOnly", "true")
            'txtRENTEL3_7.Attributes.Add("ReadOnly", "true") '2013/05/27 T.Ono add
            'txtFAX7.Attributes.Add("ReadOnly", "true")
            'txtTANNM8.Attributes.Add("ReadOnly", "true")
            'txtBIKO8.Attributes.Add("ReadOnly", "true")
            'txtRENTEL1_8.Attributes.Add("ReadOnly", "true")
            'txtRENTEL2_8.Attributes.Add("ReadOnly", "true")
            'txtRENTEL3_8.Attributes.Add("ReadOnly", "true") '2013/05/27 T.Ono add
            'txtFAX8.Attributes.Add("ReadOnly", "true")
            'txtTANNM9.Attributes.Add("ReadOnly", "true")
            'txtBIKO9.Attributes.Add("ReadOnly", "true")
            'txtRENTEL1_9.Attributes.Add("ReadOnly", "true")
            'txtRENTEL2_9.Attributes.Add("ReadOnly", "true")
            'txtRENTEL3_9.Attributes.Add("ReadOnly", "true") '2013/05/27 T.Ono add
            'txtFAX9.Attributes.Add("ReadOnly", "true")
            'txtTANNM10.Attributes.Add("ReadOnly", "true")
            'txtBIKO10.Attributes.Add("ReadOnly", "true")
            'txtRENTEL1_10.Attributes.Add("ReadOnly", "true")
            'txtRENTEL2_10.Attributes.Add("ReadOnly", "true")
            'txtRENTEL3_10.Attributes.Add("ReadOnly", "true")    '2013/05/27 T.Ono add
            'txtFAX10.Attributes.Add("ReadOnly", "true")
            'txtTANNM11.Attributes.Add("ReadOnly", "true")
            'txtBIKO11.Attributes.Add("ReadOnly", "true")
            'txtRENTEL1_11.Attributes.Add("ReadOnly", "true")
            'txtRENTEL2_11.Attributes.Add("ReadOnly", "true")
            'txtRENTEL3_11.Attributes.Add("ReadOnly", "true")    '2013/05/27 T.Ono add
            'txtFAX11.Attributes.Add("ReadOnly", "true")
            'txtTANNM12.Attributes.Add("ReadOnly", "true")
            'txtBIKO12.Attributes.Add("ReadOnly", "true")
            'txtRENTEL1_12.Attributes.Add("ReadOnly", "true")
            'txtRENTEL2_12.Attributes.Add("ReadOnly", "true")
            'txtRENTEL3_12.Attributes.Add("ReadOnly", "true")    '2013/05/27 T.Ono add
            'txtFAX12.Attributes.Add("ReadOnly", "true")
            'txtTANNM13.Attributes.Add("ReadOnly", "true")
            'txtBIKO13.Attributes.Add("ReadOnly", "true")
            'txtRENTEL1_13.Attributes.Add("ReadOnly", "true")
            'txtRENTEL2_13.Attributes.Add("ReadOnly", "true")
            'txtRENTEL3_13.Attributes.Add("ReadOnly", "true")    '2013/05/27 T.Ono add
            'txtFAX13.Attributes.Add("ReadOnly", "true")
            'txtTANNM14.Attributes.Add("ReadOnly", "true")
            'txtBIKO14.Attributes.Add("ReadOnly", "true")
            'txtRENTEL1_14.Attributes.Add("ReadOnly", "true")
            'txtRENTEL2_14.Attributes.Add("ReadOnly", "true")
            'txtRENTEL3_14.Attributes.Add("ReadOnly", "true")    '2013/05/27 T.Ono add
            'txtFAX14.Attributes.Add("ReadOnly", "true")
            'txtTANNM15.Attributes.Add("ReadOnly", "true")
            'txtBIKO15.Attributes.Add("ReadOnly", "true")
            'txtRENTEL1_15.Attributes.Add("ReadOnly", "true")
            'txtRENTEL2_15.Attributes.Add("ReadOnly", "true")
            'txtRENTEL3_15.Attributes.Add("ReadOnly", "true")    '2013/05/27 T.Ono add
            'txtFAX15.Attributes.Add("ReadOnly", "true")
            'txtTANNM16.Attributes.Add("ReadOnly", "true")
            'txtBIKO16.Attributes.Add("ReadOnly", "true")
            'txtRENTEL1_16.Attributes.Add("ReadOnly", "true")
            'txtRENTEL2_16.Attributes.Add("ReadOnly", "true")
            'txtRENTEL3_16.Attributes.Add("ReadOnly", "true")    '2013/05/27 T.Ono add
            'txtFAX16.Attributes.Add("ReadOnly", "true")
            'txtTANNM17.Attributes.Add("ReadOnly", "true")
            'txtBIKO17.Attributes.Add("ReadOnly", "true")
            'txtRENTEL1_17.Attributes.Add("ReadOnly", "true")
            'txtRENTEL2_17.Attributes.Add("ReadOnly", "true")
            'txtRENTEL3_17.Attributes.Add("ReadOnly", "true")    '2013/05/27 T.Ono add
            'txtFAX17.Attributes.Add("ReadOnly", "true")
            'txtTANNM18.Attributes.Add("ReadOnly", "true")
            'txtBIKO18.Attributes.Add("ReadOnly", "true")
            'txtRENTEL1_18.Attributes.Add("ReadOnly", "true")
            'txtRENTEL2_18.Attributes.Add("ReadOnly", "true")
            'txtRENTEL3_18.Attributes.Add("ReadOnly", "true")    '2013/05/27 T.Ono add
            'txtFAX18.Attributes.Add("ReadOnly", "true")
            'txtTANNM19.Attributes.Add("ReadOnly", "true")
            'txtBIKO19.Attributes.Add("ReadOnly", "true")
            'txtRENTEL1_19.Attributes.Add("ReadOnly", "true")
            'txtRENTEL2_19.Attributes.Add("ReadOnly", "true")
            'txtRENTEL3_19.Attributes.Add("ReadOnly", "true")    '2013/05/27 T.Ono add
            'txtFAX19.Attributes.Add("ReadOnly", "true")
            'txtTANNM20.Attributes.Add("ReadOnly", "true")
            'txtBIKO20.Attributes.Add("ReadOnly", "true")
            'txtRENTEL1_20.Attributes.Add("ReadOnly", "true")
            'txtRENTEL2_20.Attributes.Add("ReadOnly", "true")
            'txtRENTEL3_20.Attributes.Add("ReadOnly", "true")    '2013/05/27 T.Ono add
            'txtFAX20.Attributes.Add("ReadOnly", "true")
            'txtTANNM21.Attributes.Add("ReadOnly", "true")
            'txtBIKO21.Attributes.Add("ReadOnly", "true")
            'txtRENTEL1_21.Attributes.Add("ReadOnly", "true")
            'txtRENTEL2_21.Attributes.Add("ReadOnly", "true")
            'txtRENTEL3_21.Attributes.Add("ReadOnly", "true")    '2013/05/27 T.Ono add
            'txtFAX21.Attributes.Add("ReadOnly", "true")
            'txtTANNM22.Attributes.Add("ReadOnly", "true")
            'txtBIKO22.Attributes.Add("ReadOnly", "true")
            'txtRENTEL1_22.Attributes.Add("ReadOnly", "true")
            'txtRENTEL2_22.Attributes.Add("ReadOnly", "true")
            'txtRENTEL3_22.Attributes.Add("ReadOnly", "true")    '2013/05/27 T.Ono add
            'txtFAX22.Attributes.Add("ReadOnly", "true")
            'txtTANNM23.Attributes.Add("ReadOnly", "true")
            'txtBIKO23.Attributes.Add("ReadOnly", "true")
            'txtRENTEL1_23.Attributes.Add("ReadOnly", "true")
            'txtRENTEL2_23.Attributes.Add("ReadOnly", "true")
            'txtRENTEL3_23.Attributes.Add("ReadOnly", "true")    '2013/05/27 T.Ono add
            'txtFAX23.Attributes.Add("ReadOnly", "true")
            'txtTANNM24.Attributes.Add("ReadOnly", "true")
            'txtBIKO24.Attributes.Add("ReadOnly", "true")
            'txtRENTEL1_24.Attributes.Add("ReadOnly", "true")
            'txtRENTEL2_24.Attributes.Add("ReadOnly", "true")
            'txtRENTEL3_24.Attributes.Add("ReadOnly", "true")    '2013/05/27 T.Ono add
            'txtFAX24.Attributes.Add("ReadOnly", "true")
            'txtTANNM25.Attributes.Add("ReadOnly", "true")
            'txtBIKO25.Attributes.Add("ReadOnly", "true")
            'txtRENTEL1_25.Attributes.Add("ReadOnly", "true")
            'txtRENTEL2_25.Attributes.Add("ReadOnly", "true")
            'txtRENTEL3_25.Attributes.Add("ReadOnly", "true")    '2013/05/27 T.Ono add
            'txtFAX25.Attributes.Add("ReadOnly", "true")
            'txtTANNM26.Attributes.Add("ReadOnly", "true")
            'txtBIKO26.Attributes.Add("ReadOnly", "true")
            'txtRENTEL1_26.Attributes.Add("ReadOnly", "true")
            'txtRENTEL2_26.Attributes.Add("ReadOnly", "true")
            'txtRENTEL3_26.Attributes.Add("ReadOnly", "true")    '2013/05/27 T.Ono add
            'txtFAX26.Attributes.Add("ReadOnly", "true")
            'txtTANNM27.Attributes.Add("ReadOnly", "true")
            'txtBIKO27.Attributes.Add("ReadOnly", "true")
            'txtRENTEL1_27.Attributes.Add("ReadOnly", "true")
            'txtRENTEL2_27.Attributes.Add("ReadOnly", "true")
            'txtRENTEL3_27.Attributes.Add("ReadOnly", "true")    '2013/05/27 T.Ono add
            'txtFAX27.Attributes.Add("ReadOnly", "true")
            'txtTANNM28.Attributes.Add("ReadOnly", "true")
            'txtBIKO28.Attributes.Add("ReadOnly", "true")
            'txtRENTEL1_28.Attributes.Add("ReadOnly", "true")
            'txtRENTEL2_28.Attributes.Add("ReadOnly", "true")
            'txtRENTEL3_28.Attributes.Add("ReadOnly", "true")    '2013/05/27 T.Ono add
            'txtFAX28.Attributes.Add("ReadOnly", "true")
            'txtTANNM29.Attributes.Add("ReadOnly", "true")
            'txtBIKO29.Attributes.Add("ReadOnly", "true")
            'txtRENTEL1_29.Attributes.Add("ReadOnly", "true")
            'txtRENTEL2_29.Attributes.Add("ReadOnly", "true")
            'txtRENTEL3_29.Attributes.Add("ReadOnly", "true")    '2013/05/27 T.Ono add
            'txtFAX29.Attributes.Add("ReadOnly", "true")
            'txtTANNM30.Attributes.Add("ReadOnly", "true")
            'txtBIKO30.Attributes.Add("ReadOnly", "true")
            'txtRENTEL1_30.Attributes.Add("ReadOnly", "true")
            'txtRENTEL2_30.Attributes.Add("ReadOnly", "true")
            'txtRENTEL3_30.Attributes.Add("ReadOnly", "true")    '2013/05/27 T.Ono add
            'txtFAX30.Attributes.Add("ReadOnly", "true")
            'txtFileName1.Attributes.Add("ReadOnly", "true")
            'txtFileName2.Attributes.Add("ReadOnly", "true")
            'txtSPOT_MAIL_1.Attributes.Add("ReadOnly", "true")
            'txtSPOT_MAIL_2.Attributes.Add("ReadOnly", "true")
            'txtSPOT_MAIL_3.Attributes.Add("ReadOnly", "true")
            'txtSPOT_MAIL_4.Attributes.Add("ReadOnly", "true")
            'txtSPOT_MAIL_5.Attributes.Add("ReadOnly", "true")
            'txtSPOT_MAIL_6.Attributes.Add("ReadOnly", "true")
            'txtSPOT_MAIL_7.Attributes.Add("ReadOnly", "true")
            'txtSPOT_MAIL_8.Attributes.Add("ReadOnly", "true")
            'txtSPOT_MAIL_9.Attributes.Add("ReadOnly", "true")
            'txtSPOT_MAIL_10.Attributes.Add("ReadOnly", "true")
            'txtSPOT_MAIL_11.Attributes.Add("ReadOnly", "true")
            'txtSPOT_MAIL_12.Attributes.Add("ReadOnly", "true")
            'txtSPOT_MAIL_13.Attributes.Add("ReadOnly", "true")
            'txtSPOT_MAIL_14.Attributes.Add("ReadOnly", "true")
            'txtSPOT_MAIL_15.Attributes.Add("ReadOnly", "true")
            'txtSPOT_MAIL_16.Attributes.Add("ReadOnly", "true")
            'txtSPOT_MAIL_17.Attributes.Add("ReadOnly", "true")
            'txtSPOT_MAIL_18.Attributes.Add("ReadOnly", "true")
            'txtSPOT_MAIL_19.Attributes.Add("ReadOnly", "true")
            'txtSPOT_MAIL_20.Attributes.Add("ReadOnly", "true")
            'txtSPOT_MAIL_21.Attributes.Add("ReadOnly", "true")
            'txtSPOT_MAIL_22.Attributes.Add("ReadOnly", "true")
            'txtSPOT_MAIL_23.Attributes.Add("ReadOnly", "true")
            'txtSPOT_MAIL_24.Attributes.Add("ReadOnly", "true")
            'txtSPOT_MAIL_25.Attributes.Add("ReadOnly", "true")
            'txtSPOT_MAIL_26.Attributes.Add("ReadOnly", "true")
            'txtSPOT_MAIL_27.Attributes.Add("ReadOnly", "true")
            'txtSPOT_MAIL_28.Attributes.Add("ReadOnly", "true")
            'txtSPOT_MAIL_29.Attributes.Add("ReadOnly", "true")
            'txtSPOT_MAIL_30.Attributes.Add("ReadOnly", "true")
            '2016/05/10 w.ganeko mod end
        End If
        '2012/04/04 NEC ou Add End

        '//------------------------------------------
        '//　HTTPヘッダを送信
        HttpHeaderC.mNoCache(Response)

        '//------------------------------------------
        '//　認証クラスのインスタンス生成
        AuthC = New CAuthenticate(Request, Response)

        '//------------------------------------------
        '//　認証処理
        '<TODO>：使用可能権限を指定する
        '使用可能権限(運:○/営:×/監:○/出:×)
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
             MyBase.MapPath("../../../KE/KETAIJAG/KETAIJAG00/") & "KETAIJTG00.js"))
        '<フォーカス関連関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncFo.js"))
        '<入力チェック関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncChk.js"))
        '<電話番号チェック関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncTel.js"))
        '<バイト数関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncGetByte.js"))
        '<全角チェック関数>
        '--- ↓2005/05/19 DEL Falcon↓ ---
        'strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncZenkakuChk.js"))
        '--- ↑2005/05/19 DEL Falcon↑ ---
        strScript.Append(strScript.Append("</Script>"))
        '//------------------------------------------
        '//　Css格納
        strScript.Append("<Style>")
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "CssSmall.css"))
        strScript.Append("</Style>")
        '//------------------------------------------
        '//　Script書込み
        lblScript.Text = strScript.ToString

        '--- ↓2005/09/09 MOD Falcon↓ ---  //ﾌﾟﾙﾀﾞｳﾝﾏｽﾀから出力
        '//ＦＡＸタイトルコンボ作成 -----------
        Call fncCombo_Create()
        'cboFAX_TITLE.Items.Add(New ListItem("対応依頼書(緊急出動)", "対応依頼書(緊急出動)"))
        'cboFAX_TITLE.Items.Add(New ListItem("対応依頼書(点検)", "対応依頼書(点検)"))
        'cboFAX_TITLE.Items.Add(New ListItem("対応依頼書(報告)", "対応依頼書(報告)"))
        cboFAX_TITLE.SelectedIndex = 0
        '--- ↑2005/09/09 MOD Falcon↑ ---  

        '//------------------------------------
        Dim SQLC As New KETAIJAG00CSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet
        '--- ↓2005/04/27 ADD Falcon↓ ---
        Try
            If MyBase.IsPostBack = False Then
                '//対応入力画面の情報を受け取る ---
                Call GetKETAIJAG00()
                '//--------------------------------
                '--- ↑2005/04/27 ADD Falcon↑ ---
                '--- ↓2005/04/27 DEL Falcon↓ ---
                'Dim KETAIJAG00C As KETAIJAG00
                'KETAIJAG00C = CType(Context.Handler, KETAIJAG00)
                '--- ↑2005/04/27 DEL Falcon↑ ---
                strSQL = New StringBuilder("")
                strSQL.Append("SELECT  ")
                '''''strSQL.Append("JA.JA_NAME || ' / ' || JA.JAS_NAME AS JASNM, ")
                strSQL.Append("JA.JA_NAME, ")
                strSQL.Append("JA.JAS_NAME, ")
                '''''strSQL.Append("JA.JA_KANA || ' / ' || JA.JAS_KANA AS JASKN ")
                strSQL.Append("JA.JA_KANA, ")
                strSQL.Append("JA.JAS_KANA ")
                strSQL.Append("FROM HN2MAS JA ")
                strSQL.Append("WHERE JA.CLI_CD = :CLSI_CD ")
                strSQL.Append("  AND JA.HAN_CD = :HAN_CD ")

                'パラメータのセット
                '--- ↓2005/04/27 DEL Falcon↓ ---
                'SqlParamC.fncSetParam("CLSI_CD", True, KETAIJAG00C.pPRAM_CLI)
                'SqlParamC.fncSetParam("HAN_CD", True, KETAIJAG00C.pPRAM_JASS)
                '--- ↑2005/04/27 DEL Falcon↑ ---
                '--- ↓2005/04/27 MOD Falcon↓ ---
                SqlParamC.fncSetParam("CLSI_CD", True, hdnKURACD.Value)
                SqlParamC.fncSetParam("HAN_CD", True, hdnACBCD.Value)
                '--- ↑2005/04/27 MOD Falcon↑ ---

                '//SQLの実行
                dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

                If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then

                Else
                    '//情報の出力
                    '名称
                    If Convert.ToString(dbData.Tables(0).Rows(0).Item("JA_NAME")).Length = 0 And Convert.ToString(dbData.Tables(0).Rows(0).Item("JAS_NAME")).Length = 0 Then
                        '両方存在しない
                        '2016/02/02 W.GANEKO 2015改善開発 №2
                        'txtACBNM.Text = ""
                        txtACBKN.Text = ""
                    ElseIf Convert.ToString(dbData.Tables(0).Rows(0).Item("JA_NAME")).Length > 0 And Convert.ToString(dbData.Tables(0).Rows(0).Item("JAS_NAME")).Length > 0 Then
                        '両方存在する
                        '2016/02/02 W.GANEKO 2015改善開発 №2
                        'txtACBNM.Text = Convert.ToString(dbData.Tables(0).Rows(0).Item("JA_NAME")) & " / " & Convert.ToString(dbData.Tables(0).Rows(0).Item("JAS_NAME"))
                        txtACBKN.Text = Convert.ToString(dbData.Tables(0).Rows(0).Item("JA_NAME")) & " / " & Convert.ToString(dbData.Tables(0).Rows(0).Item("JAS_NAME"))
                    Else
                        'どちらか存在する
                        '2016/02/02 W.GANEKO 2015改善開発 №2
                        'txtACBNM.Text = Convert.ToString(dbData.Tables(0).Rows(0).Item("JA_NAME")) & Convert.ToString(dbData.Tables(0).Rows(0).Item("JAS_NAME"))
                        txtACBKN.Text = Convert.ToString(dbData.Tables(0).Rows(0).Item("JA_NAME")) & Convert.ToString(dbData.Tables(0).Rows(0).Item("JAS_NAME"))
                    End If
                    '2016/02/02 W.GANEKO 2015改善開発 №2 START
                    ''カナ
                    'If Convert.ToString(dbData.Tables(0).Rows(0).Item("JA_KANA")).Length = 0 And Convert.ToString(dbData.Tables(0).Rows(0).Item("JAS_KANA")).Length = 0 Then
                    '    '両方存在しない
                    '    txtACBKN.Text = ""
                    'ElseIf Convert.ToString(dbData.Tables(0).Rows(0).Item("JA_KANA")).Length > 0 And Convert.ToString(dbData.Tables(0).Rows(0).Item("JAS_KANA")).Length > 0 Then
                    '    '両方存在する
                    '    txtACBKN.Text = Convert.ToString(dbData.Tables(0).Rows(0).Item("JA_KANA")) & " / " & Convert.ToString(dbData.Tables(0).Rows(0).Item("JAS_KANA"))
                    'Else
                    '    'どちらか存在する
                    '    txtACBKN.Text = Convert.ToString(dbData.Tables(0).Rows(0).Item("JA_KANA")) & Convert.ToString(dbData.Tables(0).Rows(0).Item("JAS_KANA"))
                    'End If
                    '2016/02/02 W.GANEKO 2015改善開発 №2 END

                    '--- ↓2005/04/27 DEL Falcon↓ ---
                    'hdnREN_1_TANCD.Value = Request.Form("hdnREN_0_TANCD")
                    'txtTANNM1.Text = Request.Form("hdnREN_0_NA")
                    'txtRENTEL1_1.Text = Request.Form("hdnREN_0_TEL1")
                    'txtRENTEL2_1.Text = Request.Form("hdnREN_0_TEL2")
                    'txtFAX1.Text = Request.Form("hdnREN_0_FAX")             'ＦＡＸ番号１
                    'txtBIKO1.Text = Request.Form("hdnREN_0_BIKO")
                    'hdnREN_2_TANCD.Value = Request.Form("hdnREN_1_TANCD")
                    'txtTANNM2.Text = Request.Form("hdnREN_1_NA")
                    'txtRENTEL1_2.Text = Request.Form("hdnREN_1_TEL1")
                    'txtRENTEL2_2.Text = Request.Form("hdnREN_1_TEL2")
                    'txtFAX2.Text = Request.Form("hdnREN_1_FAX")             'ＦＡＸ番号２
                    'txtBIKO2.Text = Request.Form("hdnREN_1_BIKO")
                    'hdnREN_3_TANCD.Value = Request.Form("hdnREN_2_TANCD")
                    'txtTANNM3.Text = Request.Form("hdnREN_2_NA")
                    'txtRENTEL1_3.Text = Request.Form("hdnREN_2_TEL1")
                    'txtRENTEL2_3.Text = Request.Form("hdnREN_2_TEL2")
                    'txtFAX3.Text = Request.Form("hdnREN_2_FAX")             'ＦＡＸ番号３
                    'txtBIKO3.Text = Request.Form("hdnREN_2_BIKO")
                    'hdnREN_4_TANCD.Value = Request.Form("hdnREN_3_TANCD")
                    'txtTANNM4.Text = Request.Form("hdnREN_3_NA")
                    'txtRENTEL1_4.Text = Request.Form("hdnREN_3_TEL1")
                    'txtRENTEL2_4.Text = Request.Form("hdnREN_3_TEL2")
                    'txtFAX4.Text = Request.Form("hdnREN_3_FAX")             'ＦＡＸ番号４
                    'txtBIKO4.Text = Request.Form("hdnREN_3_BIKO")
                    'txtDENWABIKO.Text = Request.Form("hdnREN_DENWABIKO")
                    ''ＦＡＸタイトル
                    'Dim strTemp As String
                    'Dim list As New ListItem
                    'strTemp = Request.Form("hdnREN_FAXTITLE")
                    'If strTemp <> "" Then
                    '    list = cboFAX_TITLE.Items.FindByValue(strTemp)
                    '    cboFAX_TITLE.SelectedIndex = cboFAX_TITLE.Items.IndexOf(list)
                    'End If
                    'txtFAX_REN.Text = Request.Form("hdnREN_FAXREN")         'ＦＡＸ連絡欄

                    '--- ↑2005/04/27 DEL Falcon↑ ---
                End If
            End If

            'カーソルのセット
            strMsg.Append("Form1.txtTANNM1.focus();")
            '--- ↓2005/04/27 ADD Falcon↓ ---

        Catch ex As Exception
            Dim ErrMsgC As New CErrMsg
            strMsg.Append("alert('システムエラー：" & ErrMsgC.mGetArtMsg(ex.ToString) & "');")

        Finally
            If dbData Is Nothing Then
            Else
                dbData.Dispose()
            End If
        End Try
        '--- ↑2005/04/27 ADD Falcon↑ ---

        fncSearchAndSetFileName12() ' ファイル名再表示（ファイル名を取得してセット） 2010/04/28 T.Watabe add

    End Sub

    '--- ↓2005/04/25 ADD Falcon↓ ---
    '******************************************************************************
    '*　概　要：
    '*　備　考：
    '******************************************************************************
    Private Sub GetKETAIJAG00()
        Dim UtilFucC As New CUtilFuc

        '2010/05/10 T.Watabe add
        Dim hdnREN_TANCD As HtmlInputHidden
        Dim txtTANNM As TextBox
        Dim txtRENTEL1 As TextBox
        Dim txtRENTEL2 As TextBox
        Dim txtRENTEL3 As TextBox '2013/05/27 T.Ono add
        Dim txtFAX As TextBox
        Dim txtBIKO As TextBox
        Dim txtSPOTMAIL As TextBox
        Dim hdnMAILPASS As HtmlInputHidden
        Dim i As Integer
        i = 1
        Do While (i <= 30) '３０行まで対応
            'コントロールを特定 １～３０
            hdnREN_TANCD = DirectCast(FindControl("hdnREN_" & i & "_TANCD"), HtmlInputHidden)
            txtTANNM = DirectCast(FindControl("txtTANNM" & i), TextBox)
            txtRENTEL1 = DirectCast(FindControl("txtRENTEL1_" & i), TextBox)
            txtRENTEL2 = DirectCast(FindControl("txtRENTEL2_" & i), TextBox)
            txtRENTEL3 = DirectCast(FindControl("txtRENTEL3_" & i), TextBox) '2013/05/27 T.Ono add
            txtFAX = DirectCast(FindControl("txtFAX" & i), TextBox)
            txtBIKO = DirectCast(FindControl("txtBIKO" & i), TextBox)
            txtSPOTMAIL = DirectCast(FindControl("txtSPOT_MAIL_" & i), TextBox)
            hdnMAILPASS = DirectCast(FindControl("hdnREN_" & i & "_MAILPASS"), HtmlInputHidden)
            '代入
            hdnREN_TANCD.Value = Request.Form("hdnREN_" & i - 1 & "_TANCD")
            txtTANNM.Text = Request.Form("hdnREN_" & i - 1 & "_NA")
            txtRENTEL1.Text = Request.Form("hdnREN_" & i - 1 & "_TEL1")
            txtRENTEL2.Text = Request.Form("hdnREN_" & i - 1 & "_TEL2")
            txtRENTEL3.Text = Request.Form("hdnREN_" & i - 1 & "_TEL3") '2013/05/27 T.Ono add
            txtFAX.Text = Request.Form("hdnREN_" & i - 1 & "_FAX")
            txtBIKO.Text = Request.Form("hdnREN_" & i - 1 & "_BIKO")
            txtSPOTMAIL.Text = Request.Form("hdnREN_" & i - 1 & "_MAIL")
            hdnMAILPASS.Value = Request.Form("hdnREN_" & i - 1 & "_MAILPASS")
            i = i + 1
        Loop

        'hdnREN_1_TANCD.Value = Request.Form("hdnREN_0_TANCD")
        'txtTANNM1.Text = Request.Form("hdnREN_0_NA")
        'txtRENTEL1_1.Text = Request.Form("hdnREN_0_TEL1")
        'txtRENTEL2_1.Text = Request.Form("hdnREN_0_TEL2")
        'txtFAX1.Text = Request.Form("hdnREN_0_FAX")             'ＦＡＸ番号１
        'txtBIKO1.Text = Request.Form("hdnREN_0_BIKO")
        'hdnREN_2_TANCD.Value = Request.Form("hdnREN_1_TANCD")
        'txtTANNM2.Text = Request.Form("hdnREN_1_NA")
        'txtRENTEL1_2.Text = Request.Form("hdnREN_1_TEL1")
        'txtRENTEL2_2.Text = Request.Form("hdnREN_1_TEL2")
        'txtFAX2.Text = Request.Form("hdnREN_1_FAX")             'ＦＡＸ番号２
        'txtBIKO2.Text = Request.Form("hdnREN_1_BIKO")
        'hdnREN_3_TANCD.Value = Request.Form("hdnREN_2_TANCD")
        'txtTANNM3.Text = Request.Form("hdnREN_2_NA")
        'txtRENTEL1_3.Text = Request.Form("hdnREN_2_TEL1")
        'txtRENTEL2_3.Text = Request.Form("hdnREN_2_TEL2")
        'txtFAX3.Text = Request.Form("hdnREN_2_FAX")             'ＦＡＸ番号３
        'txtBIKO3.Text = Request.Form("hdnREN_2_BIKO")
        'hdnREN_4_TANCD.Value = Request.Form("hdnREN_3_TANCD")
        'txtTANNM4.Text = Request.Form("hdnREN_3_NA")
        'txtRENTEL1_4.Text = Request.Form("hdnREN_3_TEL1")
        'txtRENTEL2_4.Text = Request.Form("hdnREN_3_TEL2")
        'txtFAX4.Text = Request.Form("hdnREN_3_FAX")             'ＦＡＸ番号４
        'txtBIKO4.Text = Request.Form("hdnREN_3_BIKO")

        ''2008/10/31 T.Watabe add
        'hdnREN_5_TANCD.Value = Request.Form("hdnREN_4_TANCD")          '５
        'txtTANNM5.Text = Request.Form("hdnREN_4_NA")
        'txtRENTEL1_5.Text = Request.Form("hdnREN_4_TEL1")
        'txtRENTEL2_5.Text = Request.Form("hdnREN_4_TEL2")
        'txtFAX5.Text = Request.Form("hdnREN_4_FAX")
        'txtBIKO5.Text = Request.Form("hdnREN_4_BIKO")
        'hdnREN_6_TANCD.Value = Request.Form("hdnREN_5_TANCD")          '６
        'txtTANNM6.Text = Request.Form("hdnREN_5_NA")
        'txtRENTEL1_6.Text = Request.Form("hdnREN_5_TEL1")
        'txtRENTEL2_6.Text = Request.Form("hdnREN_5_TEL2")
        'txtFAX6.Text = Request.Form("hdnREN_5_FAX")
        'txtBIKO6.Text = Request.Form("hdnREN_5_BIKO")
        'hdnREN_7_TANCD.Value = Request.Form("hdnREN_6_TANCD")          '７
        'txtTANNM7.Text = Request.Form("hdnREN_6_NA")
        'txtRENTEL1_7.Text = Request.Form("hdnREN_6_TEL1")
        'txtRENTEL2_7.Text = Request.Form("hdnREN_6_TEL2")
        'txtFAX7.Text = Request.Form("hdnREN_6_FAX")
        'txtBIKO7.Text = Request.Form("hdnREN_6_BIKO")
        'hdnREN_8_TANCD.Value = Request.Form("hdnREN_7_TANCD")          '８
        'txtTANNM8.Text = Request.Form("hdnREN_7_NA")
        'txtRENTEL1_8.Text = Request.Form("hdnREN_7_TEL1")
        'txtRENTEL2_8.Text = Request.Form("hdnREN_7_TEL2")
        'txtFAX8.Text = Request.Form("hdnREN_7_FAX")
        'txtBIKO8.Text = Request.Form("hdnREN_7_BIKO")
        'hdnREN_9_TANCD.Value = Request.Form("hdnREN_8_TANCD")          '９
        'txtTANNM9.Text = Request.Form("hdnREN_8_NA")
        'txtRENTEL1_9.Text = Request.Form("hdnREN_8_TEL1")
        'txtRENTEL2_9.Text = Request.Form("hdnREN_8_TEL2")
        'txtFAX9.Text = Request.Form("hdnREN_8_FAX")
        'txtBIKO9.Text = Request.Form("hdnREN_8_BIKO")
        'hdnREN_10_TANCD.Value = Request.Form("hdnREN_9_TANCD")          '１０
        'txtTANNM10.Text = Request.Form("hdnREN_9_NA")
        'txtRENTEL1_10.Text = Request.Form("hdnREN_9_TEL1")
        'txtRENTEL2_10.Text = Request.Form("hdnREN_9_TEL2")
        'txtFAX10.Text = Request.Form("hdnREN_9_FAX")
        'txtBIKO10.Text = Request.Form("hdnREN_9_BIKO")
        'txtDENWABIKO.Text = Request.Form("hdnREN_DENWABIKO") '2014/12/01 H.Hosoda del 1Line 2014改善開発 No4 
        'ＦＡＸタイトル
        Dim strTemp As String
        Dim list As New ListItem
        '--- ↓2005/09/09 MOD Falcon↓ ---
        'strTemp = Request.Form("hdnREN_FAXTITLE")
        strTemp = Request.Form("hdnFAX_TITLE_CD")
        If strTemp <> "" Then
            list = cboFAX_TITLE.Items.FindByValue(strTemp)
            cboFAX_TITLE.SelectedIndex = cboFAX_TITLE.Items.IndexOf(list)
        End If
        '--- ↑2005/09/09 MOD Falcon↑ ---
        '--- ↓2005/09/26 ADD Falcon↓ ---
        hdnFAX_TITLE.Value = cboFAX_TITLE.SelectedValue
        '--- ↑2005/09/26 ADD Falcon↑ ---
        txtFAX_REN.Text = Request.Form("hdnREN_FAXREN")             'メモ欄
        '//ＦＡＸ送信用Hidden-----------------
        hdnFAXEXEPATH.Value = Request.Form("hdnFAXEXEPATH")         'ＦＡＸEXE格納フォルダ[config]
        hdnFAXEXENAME.Value = Request.Form("hdnFAXEXENAME")         'ＦＡＸEXE名[config]
        hdnFAXHEAD.Value = Request.Form("hdnFAXHEAD")               '頭番号(ＦＡＸ)[config]
        hdnFAXSESSION.Value = Request.Form("hdnFAXSESSION")         'セッションＩＤ
        hdnSYONO.Value = Request.Form("hdnSYONO")                   '処理番号
        hdnHATYMD.Value = Request.Form("txtHATYMD")                 '発生日
        hdnHATTIME.Value = Request.Form("txtHATTIME")               '発生時刻
        hdnKURACD.Value = Request.Form("txtClientCD")               'クライアントコード
        hdnACBCD.Value = Request.Form("hdnJASCD")                   'ＪＡ支所コード
        hdnKANSCD.Value = Request.Form("hdnKANSCD")                 '監視センターコード
        hdnJUSYONM.Value = Request.Form("txtJUSYONM")               'お客様氏名
        hdnUSER_CD.Value = Request.Form("txtJUYOKA")                'お客様コード
        hdnJUTEL1.Value = Request.Form("txtJUTEL1")                 '電話番号(市外)
        hdnJUTEL2.Value = Request.Form("txtJUTEL2")                 '電話番号(市内)
        hdnRENTEL.Value = Request.Form("txtRENTEL")                 '連絡先電話
        hdnADDR.Value = UtilFucC.CrlfCut(Request.Form("txtADDR"))   '住所
        hdnKENSIN.Value = Request.Form("txtKMSIN")                  'メータ値
        hdnRYURYO.Value = Request.Form("txtRYURYO")                 '流量区分
        hdnMETASYU.Value = Request.Form("txtMETASYU")               'メータ種別
        '2015/01/06 T.Ono mod 2014改善開発 No5 START
        'hdnKMNM1.Value = Request.Form("hdnKMNM1")                   '警報１メッセージ
        'hdnKMNM2.Value = Request.Form("hdnKMNM2")                   '警報２メッセージ
        'hdnKMNM3.Value = Request.Form("hdnKMNM3")                   '警報３メッセージ
        'hdnKMNM4.Value = Request.Form("hdnKMNM4")                   '警報４メッセージ
        'hdnKMNM5.Value = Request.Form("hdnKMNM5")                   '警報５メッセージ
        'hdnKMNM6.Value = Request.Form("hdnKMNM6")                   '警報６メッセージ
        fncSetKMNM()
        '2015/01/06 T.Ono mod 2014改善開発 No5 END

        hdnTAIOKBN.Value = Request.Form("cboTAIOKBN")               '対応区分
        hdnTKTANCD.Value = Request.Form("hdnTKTANCD")               '監視センター担当者
        hdnSYOYMD.Value = Request.Form("txtSYOYMD")                 '対応完了日
        hdnSYOTIME.Value = Request.Form("txtSYOTIME")               '対応完了時刻
        hdnSIJIYMD.Value = Request.Form("txtSIJIYMD")               '出動指示日
        hdnSIJITIME.Value = Request.Form("txtSIJITIME")             '出動指示時刻
        hdnTAITCD.Value = Request.Form("cboTAITCD")                 '連絡相手
        hdnTELRCD.Value = Request.Form("cboTELRCD")                 '電話連絡内容
        '2013/10/28 T.Ono mod 監視改善2013№1
        'hdnFUK_MEMO.Value = Request.Form("txtFUK_MEMO")             '復帰操作メモ
        'hdnTEL_MEMO1.Value = Request.Form("txtTEL_MEMO1")           '電話メモ１
        'hdnTEL_MEMO2.Value = Request.Form("txtTEL_MEMO2")           '電話メモ２
        hdnTEL_MEMO1.Value = Request.Form("hdnTEL_MEMO1")           '電話メモ1行目
        hdnTEL_MEMO2.Value = Request.Form("hdnTEL_MEMO2")           '電話メモ2行目
        hdnFUK_MEMO.Value = Request.Form("hdnFUK_MEMO")             '電話メモ3行目
        hdnTEL_MEMO4.Value = Request.Form("hdnTEL_MEMO4")           '電話メモ4行目    2020/11/01 T.Ono add 2020監視改善
        hdnTEL_MEMO5.Value = Request.Form("hdnTEL_MEMO5")           '電話メモ5行目    2020/11/01 T.Ono add 2020監視改善
        hdnTEL_MEMO6.Value = Request.Form("hdnTEL_MEMO6")           '電話メモ6行目    2020/11/01 T.Ono add 2020監視改善
        hdnTKIGCD.Value = Request.Form("cboTKIGCD")                 'ガス器具
        hdnTSADCD.Value = Request.Form("cboTSADCD")                 '作動原因
        hdnMITOKBN.Value = Request.Form("hdnMOVE_MITOKBN")          '未登録ＦＬＧ

        hdnM05_TANTO_HAN_CD.Value = Request.Form("hdnM05_TANTO_HAN_CD") 'M05_TANTOマスタを引く際のＪＡｺｰﾄﾞ（JAｺｰﾄﾞかJA支所ｺｰﾄﾞを保持）' 2010/05/12 T.Watabe add
        hdnUSER_CD_FROM.Value = Request.Form("hdnUSER_CD_FROM") ' 2013/07/11 T.Ono
        '2016/02/02 W.GANEKO 2015改善開発 START
        txtACBNM.Text = Request.Form("hdnGROUPCD") & ":" & Request.Form("hdnGROUPNM")
        hdnGROUPCD.Value = Request.Form("hdnGROUPCD")               'グループコード　2016/04/19 T.Ono add 2015改善開発 №7
        ' 2013/07/05 T.Ono del 暫定対応は削除
        ''2013/03/15 w.ganeko 新潟対応
        'Dim SQLC2 As New KETAIJAG00CSQL.CSQL
        'Dim SqlParamC2 As New CSQLParam
        'Dim strSQL2 As New StringBuilder("")
        'Dim strSQL3 As New StringBuilder("")
        'Dim dbData2 As DataSet
        'strSQL2 = New StringBuilder("")
        'strSQL2.Append("SELECT  ")
        'strSQL2.Append("TAN.TANCD AS TANCD, ")
        'strSQL2.Append("TAN.TANNM AS TANNM, ")
        'strSQL2.Append("TAN.RENTEL1 AS RENTEL1, ")
        'strSQL2.Append("TAN.RENTEL2 AS RENTEL2, ")
        'strSQL2.Append("TAN.FAXNO AS FAXNO, ")
        'strSQL2.Append("TAN.BIKO AS BIKO, ")
        'strSQL2.Append("TAN.SPOT_MAIL AS SPOT_MAIL, ")
        'strSQL2.Append("TAN.MAIL_PASS AS MAIL_PASS ")
        'strSQL2.Append("FROM M06_PULLDOWN M06, ")
        'strSQL2.Append(" M05_TANTO TAN ")
        'strSQL2.Append("WHERE M06.KBN = '77' ")
        'strSQL2.Append("  AND M06.NAME = :KURACD||:ACBCD ")
        'strSQL2.Append("  AND TAN.KBN = '3' ")
        'strSQL2.Append("  AND TAN.KURACD = :KURACD1 ")
        'strSQL2.Append("  AND TAN.CODE = M06.NAIYO2 ")

        'Dim x As Integer
        'Dim x2 As Integer
        'Dim sqlflg As Boolean = False
        'Try
        '    strSQL3 = New StringBuilder("")
        '    strSQL3.Append(strSQL2.ToString)
        '    strSQL3.Append("  AND M06.NAIYO1 = :USER_CD ")
        '    strSQL3.Append("ORDER BY TO_NUMBER(TAN.TANCD)  ")
        '    SqlParamC2.fncSetParam("KURACD", True, hdnKURACD.Value)
        '    SqlParamC2.fncSetParam("ACBCD", True, hdnACBCD.Value)
        '    SqlParamC2.fncSetParam("USER_CD", True, hdnUSER_CD.Value)
        '    SqlParamC2.fncSetParam("KURACD1", True, hdnKURACD.Value)
        '    '//SQLの実行
        '    dbData2 = SQLC2.mGetData(strSQL3.ToString, SqlParamC2.pParamDataSet, True)
        '    x = 0
        '    x2 = 1
        '    If Convert.ToString(dbData2.Tables(0).Rows(0).Item(0)) = "XYZ" Then
        '        'データなしの場合、お客様コード頭２桁以上で比較
        '        strSQL3 = New StringBuilder("")
        '        strSQL3.Append(strSQL2.ToString)
        '        strSQL3.Append("  AND :USER_CD LIKE TRIM(M06.NAIYO1)||'%'  ")
        '        'strSQL3.Append("  AND M06.NAIYO1 = SUBSTR(:USER_CD,1,2) ")
        '        strSQL3.Append("ORDER BY TO_NUMBER(TAN.TANCD)  ")
        '        SqlParamC2.fncSetParam("KURACD", True, hdnKURACD.Value)
        '        SqlParamC2.fncSetParam("ACBCD", True, hdnACBCD.Value)
        '        SqlParamC2.fncSetParam("USER_CD", True, hdnUSER_CD.Value)
        '        SqlParamC2.fncSetParam("KURACD1", True, hdnKURACD.Value)
        '        '//SQLの実行
        '        dbData2 = SQLC2.mGetData(strSQL3.ToString, SqlParamC2.pParamDataSet, True)
        '        If Convert.ToString(dbData2.Tables(0).Rows(0).Item(0)) = "XYZ" Then
        '            'データなしの場合
        '        Else
        '            sqlflg = True
        '        End If
        '    Else
        '        sqlflg = True
        '    End If
        '    If sqlflg Then
        '        For x = 0 To dbData2.Tables(0).Rows.Count - 1
        '            hdnREN_TANCD = DirectCast(FindControl("hdnREN_" & x2 & "_TANCD"), HtmlInputHidden)
        '            txtTANNM = DirectCast(FindControl("txtTANNM" & x2), TextBox)
        '            txtRENTEL1 = DirectCast(FindControl("txtRENTEL1_" & x2), TextBox)
        '            txtRENTEL2 = DirectCast(FindControl("txtRENTEL2_" & x2), TextBox)
        '            txtRENTEL3 = DirectCast(FindControl("txtRENTEL3_" & x2), TextBox) '2013/05/27 T.Ono
        '            txtFAX = DirectCast(FindControl("txtFAX" & x2), TextBox)
        '            txtBIKO = DirectCast(FindControl("txtBIKO" & x2), TextBox)
        '            txtSPOTMAIL = DirectCast(FindControl("txtSPOT_MAIL_" & x2), TextBox)
        '            hdnMAILPASS = DirectCast(FindControl("hdnREN_" & x2 & "_MAILPASS"), HtmlInputHidden)
        '            '連絡先を変更
        '            hdnREN_TANCD.Value = Convert.ToString(dbData2.Tables(0).Rows(x).Item("TANCD"))
        '            txtTANNM.Text = Convert.ToString(dbData2.Tables(0).Rows(x).Item("TANNM"))
        '            txtRENTEL1.Text = Convert.ToString(dbData2.Tables(0).Rows(x).Item("RENTEL1"))
        '            txtRENTEL2.Text = Convert.ToString(dbData2.Tables(0).Rows(x).Item("RENTEL2"))
        '            txtRENTEL3.Text = Convert.ToString(dbData2.Tables(0).Rows(x).Item("RENTEL3")) '2013/05/27 T.Ono
        '            txtFAX.Text = Convert.ToString(dbData2.Tables(0).Rows(x).Item("FAXNO"))
        '            txtBIKO.Text = Convert.ToString(dbData2.Tables(0).Rows(x).Item("BIKO"))
        '            txtSPOTMAIL.Text = Convert.ToString(dbData2.Tables(0).Rows(x).Item("SPOT_MAIL"))
        '            hdnMAILPASS.Value = Convert.ToString(dbData2.Tables(0).Rows(x).Item("MAIL_PASS"))
        '            x2 = x2 + 1
        '        Next
        '        Do While (x2 <= 30) '３０行まで対応
        '            'コントロールを特定 １～３０
        '            hdnREN_TANCD = DirectCast(FindControl("hdnREN_" & x2 & "_TANCD"), HtmlInputHidden)
        '            txtTANNM = DirectCast(FindControl("txtTANNM" & x2), TextBox)
        '            txtRENTEL1 = DirectCast(FindControl("txtRENTEL1_" & x2), TextBox)
        '            txtRENTEL2 = DirectCast(FindControl("txtRENTEL2_" & x2), TextBox)
        '            txtRENTEL3 = DirectCast(FindControl("txtRENTEL3_" & x2), TextBox) '2013/05/27 T.Ono
        '            txtFAX = DirectCast(FindControl("txtFAX" & x2), TextBox)
        '            txtBIKO = DirectCast(FindControl("txtBIKO" & x2), TextBox)
        '            txtSPOTMAIL = DirectCast(FindControl("txtSPOT_MAIL_" & x2), TextBox)
        '            hdnMAILPASS = DirectCast(FindControl("hdnREN_" & x2 & "_MAILPASS"), HtmlInputHidden)
        '            '代入
        '            hdnREN_TANCD.Value = ""
        '            txtTANNM.Text = ""
        '            txtRENTEL1.Text = ""
        '            txtRENTEL2.Text = ""
        '            txtRENTEL3.Text = ""
        '            txtFAX.Text = ""
        '            txtBIKO.Text = ""
        '            txtSPOTMAIL.Text = ""
        '            hdnMAILPASS.Value = ""
        '            x2 = x2 + 1
        '        Loop
        '    End If

        'Catch ex As Exception
        '    Dim ErrMsgC As New CErrMsg
        '    strMsg.Append("alert('システムエラー：" & ErrMsgC.mGetArtMsg(ex.ToString) & "');")
        'Finally
        '    If dbData2 Is Nothing Then
        '    Else
        '        dbData2.Dispose()
        '    End If
        'End Try
    End Sub

    '******************************************************************************
    '*　概　要：ＦＡＸ／電話発信ボタン押下
    '*　備　考：
    '******************************************************************************
    Private Sub btnTelHas_ServerClick(ByVal sender As System.Object, _
                                    ByVal e As System.EventArgs) Handles btnTelHas.ServerClick
        '//--------------------------------------------------------------------------
        '<TODO>ＦＡＸデータ作成を行う
        Server.Transfer("KETAIJFG00.aspx")

    End Sub
    '--- ↑2005/04/25 ADD Falcon↑ ---

    '--- ↓2005/09/09 ADD Falcon↓ ---
    '******************************************************************************
    '*　概　要：ＦＡＸタイトルコンボ作成
    '*　備　考：
    '******************************************************************************
    Private Sub fncCombo_Create()
        cboFAX_TITLE.pComboTitle = False
        cboFAX_TITLE.pNoData = False
        cboFAX_TITLE.pType = "FAXTITLE"               '//ＦＡＸタイトル
        cboFAX_TITLE.mMakeCombo()
    End Sub
    '--- ↑2005/09/09 ADD Falcon↑ ---

    ' 2010/04/15 T.Watabe add
    '******************************************************************************
    '* ファイルダウンロード処理
    '******************************************************************************
    Private Sub btnFileDownload1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFileDownload1.Click

        Dim sSaveFileName As String   '実際の元ファイル名（拡張子あり）  jm000000_テストファイル.xls
        Dim sSaveFileNameR As String  'ダウンロード後のファイル名        テストファイル.xls
        Dim sSavePath As String       '元ファイル保存フォルダ            D:\TEMP\SAVE\
        Try
            sSavePath = ConfigurationSettings.AppSettings("JA_TAN_MST_PATH")
            sSaveFileNameR = txtFileName1.Text.Trim '☆ファイル名☆
            'sSaveFileName = hdnKURACD.Value.Trim & "_" & hdnACBCD.Value.Trim & "_" & sSaveFileNameR 'ファイル名を、ｸﾗｲｱﾝﾄｺｰﾄﾞ＋ｺｰﾄﾞ＋ファイル名に変換
            ' 2013/07/11 T.Ono mod
            'sSaveFileName = hdnKURACD.Value.Trim & "_" & hdnM05_TANTO_HAN_CD.Value.Trim & "_" & sSaveFileNameR 'ファイル名を、ｸﾗｲｱﾝﾄｺｰﾄﾞ＋ｺｰﾄﾞ＋ファイル名に変換
            '2016/04/19 T.Ono mod 2015改善開発 №7 START
            'If Trim(hdnUSER_CD_FROM.Value) <> "" Then
            '    sSaveFileName = hdnKURACD.Value.Trim & "_" & hdnM05_TANTO_HAN_CD.Value.Trim & "_" & Trim(hdnUSER_CD_FROM.Value) & "_" & sSaveFileNameR 'ファイル名を、ｸﾗｲｱﾝﾄｺｰﾄﾞ＋ｺｰﾄﾞ＋USER_CD_FROM+ファイル名に変換
            'Else
            '    sSaveFileName = hdnKURACD.Value.Trim & "_" & hdnM05_TANTO_HAN_CD.Value.Trim & "_" & "X" & "_" & sSaveFileNameR 'ファイル名を、ｸﾗｲｱﾝﾄｺｰﾄﾞ＋ｺｰﾄﾞ＋ "X" +ファイル名に変換
            'End If
            sSaveFileName = hdnGROUPCD.Value.Trim & "_" & sSaveFileNameR
            '2016/04/19 T.Ono mod 2015改善開発 №7 END

            fncFileDownload(sSavePath, sSaveFileName, sSaveFileNameR)
        Catch ex As Exception
            Throw ex
        Finally
            Call KeepKETAIJAG00()
        End Try
    End Sub
    Private Sub btnFileDownload2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFileDownload2.Click

        Dim sSaveFileName As String   '実際の元ファイル名（拡張子あり）  jm000000_テストファイル.xls
        Dim sSaveFileNameR As String  'ダウンロード後のファイル名        テストファイル.xls
        Dim sSavePath As String       '元ファイル保存フォルダ            D:\TEMP\SAVE\
        Try
            sSavePath = ConfigurationSettings.AppSettings("JA_TAN_MST_PATH")
            sSaveFileNameR = txtFileName2.Text.Trim '☆ファイル名☆
            'sSaveFileName = hdnKURACD.Value.Trim & "_" & hdnACBCD.Value.Trim & "_" & sSaveFileNameR 'ファイル名を、ｸﾗｲｱﾝﾄｺｰﾄﾞ＋ｺｰﾄﾞ＋ファイル名に変換
            ' 2013/07/11 T.Ono mod
            'sSaveFileName = hdnKURACD.Value.Trim & "_" & hdnM05_TANTO_HAN_CD.Value.Trim & "_" & sSaveFileNameR 'ファイル名を、ｸﾗｲｱﾝﾄｺｰﾄﾞ＋ｺｰﾄﾞ＋ファイル名に変換
            '2016/04/19 T.Ono mod 2015改善開発 №7 START
            'If Trim(hdnUSER_CD_FROM.Value) <> "" Then
            '    sSaveFileName = hdnKURACD.Value.Trim & "_" & hdnM05_TANTO_HAN_CD.Value.Trim & "_" & Trim(hdnUSER_CD_FROM.Value) & "_" & sSaveFileNameR 'ファイル名を、ｸﾗｲｱﾝﾄｺｰﾄﾞ＋ｺｰﾄﾞ＋USER_CD_FROM+ファイル名に変換
            'Else
            '    sSaveFileName = hdnKURACD.Value.Trim & "_" & hdnM05_TANTO_HAN_CD.Value.Trim & "_" & "X" & "_" & sSaveFileNameR 'ファイル名を、ｸﾗｲｱﾝﾄｺｰﾄﾞ＋ｺｰﾄﾞ＋ "X" +ファイル名に変換
            'End If
            sSaveFileName = hdnGROUPCD.Value.Trim & "_" & sSaveFileNameR
            '2016/04/19 T.Ono mod 2015改善開発 №7 END

            fncFileDownload(sSavePath, sSaveFileName, sSaveFileNameR)
        Catch ex As Exception
            Throw ex
        Finally
            Call KeepKETAIJAG00()
        End Try
    End Sub

    Private Function fncFileDownload(ByVal sSavePath As String, ByVal sSaveFileName As String, ByVal sSaveFileNameR As String) As String

        Dim dt As Byte()
        Dim sSaveFileNameS As String  '実際の元ファイル名（拡張子なし）  001_999_テストファイル
        Dim fpath As String           '元ファイルまでのフルパス          D:\TEMP\SAVE\001_999_テストファイル.xls

        Try
            If sSaveFileName.IndexOf(".") > 0 Then '拡張子あり？
                sSaveFileNameS = sSaveFileName.Substring(0, sSaveFileName.LastIndexOf("."))
            Else
                sSaveFileNameS = sSaveFileName
            End If
            Dim fs As String() = System.IO.Directory.GetFiles(sSavePath, sSaveFileName)  'folderにあるファイルを取得する
            If fs.Length > 0 Then
                fpath = fs(0)
            End If

            If System.IO.File.Exists(fpath) Then
                Response.Clear()

                '2018/04/03 T.Ono mod 圧縮せずファイルをダウンロードする。　-----START
                'Dim FileToStrC As New CFileStr                  'ファイルをBase64にエンコードするクラス
                'Dim compressC As New CCompress                  '圧縮クラス
                ''圧縮先ファイルのあるフォルダ
                'compressC.p_Dir = sSavePath
                ''日本語ファイル名の指定
                'compressC.p_NihongoFileName = sSaveFileNameR
                ''圧縮元ファイル名
                'compressC.p_FileName = sSavePath & sSaveFileName
                ''圧縮先ファイル名
                'compressC.p_madeFilename = sSavePath & sSaveFileNameS & ".lzh"
                ''圧縮実行
                'compressC.mCompress()x
                'If System.IO.File.Exists(compressC.p_madeFilename) Then '圧縮したファイルが存在する？

                '    '圧縮したファイルをBase64エンコードして戻す
                '    Dim strRec As String = FileToStrC.mFileToStr(compressC.p_madeFilename.Replace(".lzh", ".exe"))

                '    dt = Convert.FromBase64String(strRec) 'Webサービスの戻り値（BASE64のテキスト）をバイトデータに変換する
                '    HttpHeaderC.mDownLoad(Response, sSaveFileNameS & ".exe") 'ファイル名は、HttpUtility.UrlEncodeメソッドを使用してSJISにエンコードする必要がある
                '    Response.BinaryWrite(dt) 'ファイル送信
                '    Response.Flush() 'レスポンスを全て吐き出し！

                '    '圧縮ファイルは不要なので削除！
                '    System.IO.File.Delete(sSavePath & sSaveFileNameS & ".lzh")
                '    System.IO.File.Delete(sSavePath & sSaveFileNameS & ".exe")

                'Else
                '    strMsg.Append("alert('" & "対象データが存在しません。[" & compressC.p_madeFilename.Replace("\", "\\") & "]');")
                '    'strMsg.Append("Form1.btnSelect.focus();") 2014/06/16 T.Ono mod btnSelectは存在しないためエラーになる
                '    strMsg.Append("Form1.txtTANNM1.focus();")
                'End If
                HttpHeaderC.mDownLoadXLS(Response, sSaveFileNameR)
                Response.WriteFile(sSavePath & sSaveFileName)
                '2018/04/03 T.Ono mod 圧縮せずファイルをダウンロードする。　-----END
            Else
                strMsg.Append("alert('" & "対象データが存在しません" & "');" & vbCrLf)
                'strMsg.Append("Form1.btnSelect.focus();") 2014/06/16 T.Ono mod
                strMsg.Append("Form1.txtTANNM1.focus();")
            End If
        Finally
        End Try
    End Function
    '-------------------------------------------------
    ' ファイル名再表示（ファイル名を取得してセット）
    '-------------------------------------------------
    Private Sub fncSearchAndSetFileName12()
        Dim folder As String
        Dim buf As String
        Dim searchPattern As String

        '初期化
        txtFileName1.Text = ""
        txtFileName2.Text = ""

        folder = ConfigurationSettings.AppSettings("JA_TAN_MST_PATH")
        'searchPattern = hdnKURACD.Value.Trim & "_" & hdnACBCD.Value.Trim & "_"
        ' 2013/07/11 T.Ono add
        'searchPattern = hdnKURACD.Value.Trim & "_" & hdnM05_TANTO_HAN_CD.Value.Trim & "_"
        '2016/04/19 T.Ono mod 2015改善開発 №7 START
        'If Trim(hdnUSER_CD_FROM.Value) <> "" Then
        '    searchPattern = hdnKURACD.Value.Trim & "_" & hdnM05_TANTO_HAN_CD.Value.Trim & "_" & Trim(hdnUSER_CD_FROM.Value) & "_"
        'Else
        '    searchPattern = hdnKURACD.Value.Trim & "_" & hdnM05_TANTO_HAN_CD.Value.Trim & "_" & "X" & "_"
        'End If

        searchPattern = hdnGROUPCD.Value.Trim & "_"

        '2016/04/19 T.Ono mod 2015改善開発 №7 END

        Dim fs As String() = System.IO.Directory.GetFiles(folder, searchPattern & "*") 'folderにあるファイルを取得する
        If fs.Length > 0 Then
            buf = fs(0).Substring(fs(0).LastIndexOf("\") + 1)
            txtFileName1.Text = buf.Substring(searchPattern.Length)
        End If
        If fs.Length > 1 Then
            buf = fs(1).Substring(fs(1).LastIndexOf("\") + 1)
            txtFileName2.Text = buf.Substring(searchPattern.Length)
        End If
    End Sub

    '-------------------------------------------------
    ' 警報CDのある警報名称を格納する 2015/01/06 T.Ono add 2014改善開発 No5
    '-------------------------------------------------
    Private Sub fncSetKMNM()
        '警報CDのある警報名称を格納する
        Dim objKMNM As System.Web.UI.HtmlControls.HtmlInputHidden

        '2016/12/12 H.Mori mod 2016改善開発 No4-5 START
        'Dim hdnKMCD As String = ""
        'For i As Integer = 1 To 6
        '    '警報コード取得
        '    hdnKMCD = Request.Form("hdnKMCD" & i)

        '    If hdnKMCD.Trim <> "" Then
        '        '空でなければ、hdnへセット
        '        objKMNM = CType(FindControl("hdnKMNM" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
        '        objKMNM.Value = Request.Form("hdnKMNM" & i).Trim
        '    End If
        'Next
        '対応入力画面で警報ﾒｯｾｰｼﾞ1を選択している場合
        'If Request.Form("rdoMsg") = "1" Then  2020/03/11 T.Ono mod 監視改善2019
        If Request.Form("hdnrdoMsg") = "1" Then
            hdnKMNM1.Value = Request.Form("hdnKMNM1")
            hdnKMNM2.Value = Request.Form("hdnKMNM2")
            hdnKMNM3.Value = Request.Form("hdnKMNM3")
            hdnKMNM4.Value = Request.Form("hdnKMNM4")
            hdnKMNM5.Value = Request.Form("hdnKMNM5")
            hdnKMNM6.Value = Request.Form("hdnKMNM6")

            objKMNM = CType(FindControl("hdnKMNM1"), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKMNM.Value = hdnKMNM1.Value
            objKMNM = CType(FindControl("hdnKMNM2"), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKMNM.Value = hdnKMNM2.Value
            objKMNM = CType(FindControl("hdnKMNM3"), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKMNM.Value = hdnKMNM3.Value
            objKMNM = CType(FindControl("hdnKMNM4"), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKMNM.Value = hdnKMNM4.Value
            objKMNM = CType(FindControl("hdnKMNM5"), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKMNM.Value = hdnKMNM5.Value
            objKMNM = CType(FindControl("hdnKMNM6"), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKMNM.Value = hdnKMNM6.Value
        End If
        '対応入力画面で警報ﾒｯｾｰｼﾞ2を選択している場合
        'If Request.Form("rdoMsg") = "2" Then 2020/03/11 T.Ono mod 監視改善2019
        If Request.Form("hdnrdoMsg") = "2" Then
            hdnKMNM1.Value = Request.Form("hdnKMNM2")
            hdnKMNM2.Value = Request.Form("hdnKMNM1")
            hdnKMNM3.Value = Request.Form("hdnKMNM3")
            hdnKMNM4.Value = Request.Form("hdnKMNM4")
            hdnKMNM5.Value = Request.Form("hdnKMNM5")
            hdnKMNM6.Value = Request.Form("hdnKMNM6")

            objKMNM = CType(FindControl("hdnKMNM1"), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKMNM.Value = hdnKMNM1.Value
            objKMNM = CType(FindControl("hdnKMNM2"), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKMNM.Value = hdnKMNM2.Value
            objKMNM = CType(FindControl("hdnKMNM3"), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKMNM.Value = hdnKMNM3.Value
            objKMNM = CType(FindControl("hdnKMNM4"), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKMNM.Value = hdnKMNM4.Value
            objKMNM = CType(FindControl("hdnKMNM5"), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKMNM.Value = hdnKMNM5.Value
            objKMNM = CType(FindControl("hdnKMNM6"), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKMNM.Value = hdnKMNM6.Value
        End If
        '対応入力画面で警報ﾒｯｾｰｼﾞ3を選択している場合
        'If Request.Form("rdoMsg") = "3" Then 2020/03/11 T.Ono mod 監視改善2019
        If Request.Form("hdnrdoMsg") = "3" Then
            hdnKMNM1.Value = Request.Form("hdnKMNM3")
            hdnKMNM2.Value = Request.Form("hdnKMNM1")
            hdnKMNM3.Value = Request.Form("hdnKMNM2")
            hdnKMNM4.Value = Request.Form("hdnKMNM4")
            hdnKMNM5.Value = Request.Form("hdnKMNM5")
            hdnKMNM6.Value = Request.Form("hdnKMNM6")

            objKMNM = CType(FindControl("hdnKMNM1"), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKMNM.Value = hdnKMNM1.Value
            objKMNM = CType(FindControl("hdnKMNM2"), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKMNM.Value = hdnKMNM2.Value
            objKMNM = CType(FindControl("hdnKMNM3"), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKMNM.Value = hdnKMNM3.Value
            objKMNM = CType(FindControl("hdnKMNM4"), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKMNM.Value = hdnKMNM4.Value
            objKMNM = CType(FindControl("hdnKMNM5"), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKMNM.Value = hdnKMNM5.Value
            objKMNM = CType(FindControl("hdnKMNM6"), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKMNM.Value = hdnKMNM6.Value
        End If
        '対応入力画面で警報ﾒｯｾｰｼﾞ4を選択している場合
        'If Request.Form("rdoMsg") = "4" Then Then  2020/03/11 T.Ono mod 監視改善2019
        If Request.Form("hdnrdoMsg") = "4" Then
            hdnKMNM1.Value = Request.Form("hdnKMNM4")
            hdnKMNM2.Value = Request.Form("hdnKMNM1")
            hdnKMNM3.Value = Request.Form("hdnKMNM2")
            hdnKMNM4.Value = Request.Form("hdnKMNM3")
            hdnKMNM5.Value = Request.Form("hdnKMNM5")
            hdnKMNM6.Value = Request.Form("hdnKMNM6")

            objKMNM = CType(FindControl("hdnKMNM1"), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKMNM.Value = hdnKMNM1.Value
            objKMNM = CType(FindControl("hdnKMNM2"), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKMNM.Value = hdnKMNM2.Value
            objKMNM = CType(FindControl("hdnKMNM3"), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKMNM.Value = hdnKMNM3.Value
            objKMNM = CType(FindControl("hdnKMNM4"), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKMNM.Value = hdnKMNM4.Value
            objKMNM = CType(FindControl("hdnKMNM5"), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKMNM.Value = hdnKMNM5.Value
            objKMNM = CType(FindControl("hdnKMNM6"), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKMNM.Value = hdnKMNM6.Value
        End If
        '対応入力画面で警報ﾒｯｾｰｼﾞ5を選択している場合
        'If Request.Form("rdoMsg") = "5" Then Then  2020/03/11 T.Ono mod 監視改善2019
        If Request.Form("hdnrdoMsg") = "5" Then
            hdnKMNM1.Value = Request.Form("hdnKMNM5")
            hdnKMNM2.Value = Request.Form("hdnKMNM1")
            hdnKMNM3.Value = Request.Form("hdnKMNM2")
            hdnKMNM4.Value = Request.Form("hdnKMNM3")
            hdnKMNM5.Value = Request.Form("hdnKMNM4")
            hdnKMNM6.Value = Request.Form("hdnKMNM6")

            objKMNM = CType(FindControl("hdnKMNM1"), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKMNM.Value = hdnKMNM1.Value
            objKMNM = CType(FindControl("hdnKMNM2"), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKMNM.Value = hdnKMNM2.Value
            objKMNM = CType(FindControl("hdnKMNM3"), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKMNM.Value = hdnKMNM3.Value
            objKMNM = CType(FindControl("hdnKMNM4"), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKMNM.Value = hdnKMNM4.Value
            objKMNM = CType(FindControl("hdnKMNM5"), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKMNM.Value = hdnKMNM5.Value
            objKMNM = CType(FindControl("hdnKMNM6"), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKMNM.Value = hdnKMNM6.Value
        End If
        '対応入力画面で警報ﾒｯｾｰｼﾞ6を選択している場合
        'If Request.Form("rdoMsg") = "6" Then 2020/03/11 T.Ono mod 監視改善2019
        If Request.Form("hdnrdoMsg") = "6" Then
            hdnKMNM1.Value = Request.Form("hdnKMNM6")
            hdnKMNM2.Value = Request.Form("hdnKMNM1")
            hdnKMNM3.Value = Request.Form("hdnKMNM2")
            hdnKMNM4.Value = Request.Form("hdnKMNM3")
            hdnKMNM5.Value = Request.Form("hdnKMNM4")
            hdnKMNM6.Value = Request.Form("hdnKMNM5")

            objKMNM = CType(FindControl("hdnKMNM1"), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKMNM.Value = hdnKMNM1.Value
            objKMNM = CType(FindControl("hdnKMNM2"), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKMNM.Value = hdnKMNM2.Value
            objKMNM = CType(FindControl("hdnKMNM3"), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKMNM.Value = hdnKMNM3.Value
            objKMNM = CType(FindControl("hdnKMNM4"), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKMNM.Value = hdnKMNM4.Value
            objKMNM = CType(FindControl("hdnKMNM5"), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKMNM.Value = hdnKMNM5.Value
            objKMNM = CType(FindControl("hdnKMNM6"), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKMNM.Value = hdnKMNM6.Value
        End If
        '2016/12/12 H.Mori mod 2016改善開発 No4-5 END

        Return
    End Sub
    '******************************************************************************
    '*　概　要：
    '*　備　考：2016/05/10 w.ganeko add
    '******************************************************************************
    Private Sub KeepKETAIJAG00()

        Dim rdoTel As HtmlInputRadioButton
        Dim chkMail As HtmlInputCheckBox
        Dim chkFax As HtmlInputCheckBox
        Call SetInitKETAIJAG00()

        Dim checkrdo As Integer
        checkrdo = 0
        For i As Integer = 1 To 3
            If checkrdo = 1 Then
                Exit For
            End If
            For j As Integer = 1 To 30
                rdoTel = DirectCast(FindControl("rdoTel" & i & "_" & j), HtmlInputRadioButton)
                chkMail = DirectCast(FindControl("chkMail_" & j), HtmlInputCheckBox)
                chkFax = DirectCast(FindControl("chkFax_" & j), HtmlInputCheckBox)
                If rdoTel.Checked = True Then
                    If hdnPreviewFlg.Value = "1" Then
                        'strMsg.Append("Form1.btnSoExit.disabled=false;" & vbCrLf)　'デバッグ用
                        'strMsg.Append("Form1.btnTelHas.disabled=false;" & vbCrLf)　'デバッグ用
                        btnSoExit.Disabled = False
                        btnTelHas.Disabled = False
                        checkrdo = 1
                        Exit For
                    End If
                    'strMsg.Append("Form1.btnSoExit.disabled=true;" & vbCrLf)
                    'strMsg.Append("Form1.btnTelHas.disabled=false;" & vbCrLf)
                    btnSoExit.Disabled = True
                    btnTelHas.Disabled = False
                    checkrdo = 1
                    Exit For
                End If
                If chkMail.Checked = True Or chkFax.Checked = True Then
                    If hdnPreviewFlg.Value = "1" Then
                        'strMsg.Append("Form1.btnSoExit.disabled=false;" & vbCrLf)
                        'strMsg.Append("Form1.btnTelHas.disabled=false;" & vbCrLf)
                        btnSoExit.Disabled = False
                        btnTelHas.Disabled = False
                        checkrdo = 1
                        Exit For
                    End If
                    'strMsg.Append("Form1.btnSoExit.disabled=true;" & vbCrLf)
                    'strMsg.Append("Form1.btnTelHas.disabled=true;" & vbCrLf)
                    btnSoExit.Disabled = True
                    btnTelHas.Disabled = True
                    checkrdo = 1
                    Exit For
                End If
            Next
        Next
        Dim strTemp As String
        Dim list As New ListItem

        strTemp = hdnFAX_TITLE_SELECT.Value()
        If strTemp <> "" Then
            list = cboFAX_TITLE.Items.FindByValue(strTemp)
            cboFAX_TITLE.SelectedIndex = cboFAX_TITLE.Items.IndexOf(list)
        End If
    End Sub
    '******************************************************************************
    '*　概　要：
    '*　備　考：2016/05/10 w.ganeko add
    '******************************************************************************
    Private Sub SetInitKETAIJAG00()
        txtACBNM.Attributes.Add("ReadOnly", "true")
        txtACBKN.Attributes.Add("ReadOnly", "true")
        txtTANNM5.Attributes.Add("ReadOnly", "true")
        txtBIKO5.Attributes.Add("ReadOnly", "true")
        txtRENTEL1_5.Attributes.Add("ReadOnly", "true")
        txtRENTEL2_5.Attributes.Add("ReadOnly", "true")
        txtRENTEL3_5.Attributes.Add("ReadOnly", "true")
        txtFAX5.Attributes.Add("ReadOnly", "true")
        txtTANNM6.Attributes.Add("ReadOnly", "true")
        txtBIKO6.Attributes.Add("ReadOnly", "true")
        txtRENTEL1_6.Attributes.Add("ReadOnly", "true")
        txtRENTEL2_6.Attributes.Add("ReadOnly", "true")
        txtRENTEL3_6.Attributes.Add("ReadOnly", "true")
        txtFAX6.Attributes.Add("ReadOnly", "true")
        txtTANNM7.Attributes.Add("ReadOnly", "true")
        txtBIKO7.Attributes.Add("ReadOnly", "true")
        txtRENTEL1_7.Attributes.Add("ReadOnly", "true")
        txtRENTEL2_7.Attributes.Add("ReadOnly", "true")
        txtRENTEL3_7.Attributes.Add("ReadOnly", "true")
        txtFAX7.Attributes.Add("ReadOnly", "true")
        txtTANNM8.Attributes.Add("ReadOnly", "true")
        txtBIKO8.Attributes.Add("ReadOnly", "true")
        txtRENTEL1_8.Attributes.Add("ReadOnly", "true")
        txtRENTEL2_8.Attributes.Add("ReadOnly", "true")
        txtRENTEL3_8.Attributes.Add("ReadOnly", "true")
        txtFAX8.Attributes.Add("ReadOnly", "true")
        txtTANNM9.Attributes.Add("ReadOnly", "true")
        txtBIKO9.Attributes.Add("ReadOnly", "true")
        txtRENTEL1_9.Attributes.Add("ReadOnly", "true")
        txtRENTEL2_9.Attributes.Add("ReadOnly", "true")
        txtRENTEL3_9.Attributes.Add("ReadOnly", "true")
        txtFAX9.Attributes.Add("ReadOnly", "true")
        txtTANNM10.Attributes.Add("ReadOnly", "true")
        txtBIKO10.Attributes.Add("ReadOnly", "true")
        txtRENTEL1_10.Attributes.Add("ReadOnly", "true")
        txtRENTEL2_10.Attributes.Add("ReadOnly", "true")
        txtRENTEL3_10.Attributes.Add("ReadOnly", "true")
        txtFAX10.Attributes.Add("ReadOnly", "true")
        txtTANNM11.Attributes.Add("ReadOnly", "true")
        txtBIKO11.Attributes.Add("ReadOnly", "true")
        txtRENTEL1_11.Attributes.Add("ReadOnly", "true")
        txtRENTEL2_11.Attributes.Add("ReadOnly", "true")
        txtRENTEL3_11.Attributes.Add("ReadOnly", "true")
        txtFAX11.Attributes.Add("ReadOnly", "true")
        txtTANNM12.Attributes.Add("ReadOnly", "true")
        txtBIKO12.Attributes.Add("ReadOnly", "true")
        txtRENTEL1_12.Attributes.Add("ReadOnly", "true")
        txtRENTEL2_12.Attributes.Add("ReadOnly", "true")
        txtRENTEL3_12.Attributes.Add("ReadOnly", "true")
        txtFAX12.Attributes.Add("ReadOnly", "true")
        txtTANNM13.Attributes.Add("ReadOnly", "true")
        txtBIKO13.Attributes.Add("ReadOnly", "true")
        txtRENTEL1_13.Attributes.Add("ReadOnly", "true")
        txtRENTEL2_13.Attributes.Add("ReadOnly", "true")
        txtRENTEL3_13.Attributes.Add("ReadOnly", "true")
        txtFAX13.Attributes.Add("ReadOnly", "true")
        txtTANNM14.Attributes.Add("ReadOnly", "true")
        txtBIKO14.Attributes.Add("ReadOnly", "true")
        txtRENTEL1_14.Attributes.Add("ReadOnly", "true")
        txtRENTEL2_14.Attributes.Add("ReadOnly", "true")
        txtRENTEL3_14.Attributes.Add("ReadOnly", "true")
        txtFAX14.Attributes.Add("ReadOnly", "true")
        txtTANNM15.Attributes.Add("ReadOnly", "true")
        txtBIKO15.Attributes.Add("ReadOnly", "true")
        txtRENTEL1_15.Attributes.Add("ReadOnly", "true")
        txtRENTEL2_15.Attributes.Add("ReadOnly", "true")
        txtRENTEL3_15.Attributes.Add("ReadOnly", "true")
        txtFAX15.Attributes.Add("ReadOnly", "true")
        txtTANNM16.Attributes.Add("ReadOnly", "true")
        txtBIKO16.Attributes.Add("ReadOnly", "true")
        txtRENTEL1_16.Attributes.Add("ReadOnly", "true")
        txtRENTEL2_16.Attributes.Add("ReadOnly", "true")
        txtRENTEL3_16.Attributes.Add("ReadOnly", "true")
        txtFAX16.Attributes.Add("ReadOnly", "true")
        txtTANNM17.Attributes.Add("ReadOnly", "true")
        txtBIKO17.Attributes.Add("ReadOnly", "true")
        txtRENTEL1_17.Attributes.Add("ReadOnly", "true")
        txtRENTEL2_17.Attributes.Add("ReadOnly", "true")
        txtRENTEL3_17.Attributes.Add("ReadOnly", "true")
        txtFAX17.Attributes.Add("ReadOnly", "true")
        txtTANNM18.Attributes.Add("ReadOnly", "true")
        txtBIKO18.Attributes.Add("ReadOnly", "true")
        txtRENTEL1_18.Attributes.Add("ReadOnly", "true")
        txtRENTEL2_18.Attributes.Add("ReadOnly", "true")
        txtRENTEL3_18.Attributes.Add("ReadOnly", "true")
        txtFAX18.Attributes.Add("ReadOnly", "true")
        txtTANNM19.Attributes.Add("ReadOnly", "true")
        txtBIKO19.Attributes.Add("ReadOnly", "true")
        txtRENTEL1_19.Attributes.Add("ReadOnly", "true")
        txtRENTEL2_19.Attributes.Add("ReadOnly", "true")
        txtRENTEL3_19.Attributes.Add("ReadOnly", "true")
        txtFAX19.Attributes.Add("ReadOnly", "true")
        txtTANNM20.Attributes.Add("ReadOnly", "true")
        txtBIKO20.Attributes.Add("ReadOnly", "true")
        txtRENTEL1_20.Attributes.Add("ReadOnly", "true")
        txtRENTEL2_20.Attributes.Add("ReadOnly", "true")
        txtRENTEL3_20.Attributes.Add("ReadOnly", "true")
        txtFAX20.Attributes.Add("ReadOnly", "true")
        txtTANNM21.Attributes.Add("ReadOnly", "true")
        txtBIKO21.Attributes.Add("ReadOnly", "true")
        txtRENTEL1_21.Attributes.Add("ReadOnly", "true")
        txtRENTEL2_21.Attributes.Add("ReadOnly", "true")
        txtRENTEL3_21.Attributes.Add("ReadOnly", "true")
        txtFAX21.Attributes.Add("ReadOnly", "true")
        txtTANNM22.Attributes.Add("ReadOnly", "true")
        txtBIKO22.Attributes.Add("ReadOnly", "true")
        txtRENTEL1_22.Attributes.Add("ReadOnly", "true")
        txtRENTEL2_22.Attributes.Add("ReadOnly", "true")
        txtRENTEL3_22.Attributes.Add("ReadOnly", "true")
        txtFAX22.Attributes.Add("ReadOnly", "true")
        txtTANNM23.Attributes.Add("ReadOnly", "true")
        txtBIKO23.Attributes.Add("ReadOnly", "true")
        txtRENTEL1_23.Attributes.Add("ReadOnly", "true")
        txtRENTEL2_23.Attributes.Add("ReadOnly", "true")
        txtRENTEL3_23.Attributes.Add("ReadOnly", "true")
        txtFAX23.Attributes.Add("ReadOnly", "true")
        txtTANNM24.Attributes.Add("ReadOnly", "true")
        txtBIKO24.Attributes.Add("ReadOnly", "true")
        txtRENTEL1_24.Attributes.Add("ReadOnly", "true")
        txtRENTEL2_24.Attributes.Add("ReadOnly", "true")
        txtRENTEL3_24.Attributes.Add("ReadOnly", "true")
        txtFAX24.Attributes.Add("ReadOnly", "true")
        txtTANNM25.Attributes.Add("ReadOnly", "true")
        txtBIKO25.Attributes.Add("ReadOnly", "true")
        txtRENTEL1_25.Attributes.Add("ReadOnly", "true")
        txtRENTEL2_25.Attributes.Add("ReadOnly", "true")
        txtRENTEL3_25.Attributes.Add("ReadOnly", "true")
        txtFAX25.Attributes.Add("ReadOnly", "true")
        txtTANNM26.Attributes.Add("ReadOnly", "true")
        txtBIKO26.Attributes.Add("ReadOnly", "true")
        txtRENTEL1_26.Attributes.Add("ReadOnly", "true")
        txtRENTEL2_26.Attributes.Add("ReadOnly", "true")
        txtRENTEL3_26.Attributes.Add("ReadOnly", "true")
        txtFAX26.Attributes.Add("ReadOnly", "true")
        txtTANNM27.Attributes.Add("ReadOnly", "true")
        txtBIKO27.Attributes.Add("ReadOnly", "true")
        txtRENTEL1_27.Attributes.Add("ReadOnly", "true")
        txtRENTEL2_27.Attributes.Add("ReadOnly", "true")
        txtRENTEL3_27.Attributes.Add("ReadOnly", "true")
        txtFAX27.Attributes.Add("ReadOnly", "true")
        txtTANNM28.Attributes.Add("ReadOnly", "true")
        txtBIKO28.Attributes.Add("ReadOnly", "true")
        txtRENTEL1_28.Attributes.Add("ReadOnly", "true")
        txtRENTEL2_28.Attributes.Add("ReadOnly", "true")
        txtRENTEL3_28.Attributes.Add("ReadOnly", "true")
        txtFAX28.Attributes.Add("ReadOnly", "true")
        txtTANNM29.Attributes.Add("ReadOnly", "true")
        txtBIKO29.Attributes.Add("ReadOnly", "true")
        txtRENTEL1_29.Attributes.Add("ReadOnly", "true")
        txtRENTEL2_29.Attributes.Add("ReadOnly", "true")
        txtRENTEL3_29.Attributes.Add("ReadOnly", "true")
        txtFAX29.Attributes.Add("ReadOnly", "true")
        txtTANNM30.Attributes.Add("ReadOnly", "true")
        txtBIKO30.Attributes.Add("ReadOnly", "true")
        txtRENTEL1_30.Attributes.Add("ReadOnly", "true")
        txtRENTEL2_30.Attributes.Add("ReadOnly", "true")
        txtRENTEL3_30.Attributes.Add("ReadOnly", "true")
        txtFAX30.Attributes.Add("ReadOnly", "true")
        txtFileName1.Attributes.Add("ReadOnly", "true")
        txtFileName2.Attributes.Add("ReadOnly", "true")
        txtSPOT_MAIL_1.Attributes.Add("ReadOnly", "true")
        txtSPOT_MAIL_2.Attributes.Add("ReadOnly", "true")
        txtSPOT_MAIL_3.Attributes.Add("ReadOnly", "true")
        txtSPOT_MAIL_4.Attributes.Add("ReadOnly", "true")
        txtSPOT_MAIL_5.Attributes.Add("ReadOnly", "true")
        txtSPOT_MAIL_6.Attributes.Add("ReadOnly", "true")
        txtSPOT_MAIL_7.Attributes.Add("ReadOnly", "true")
        txtSPOT_MAIL_8.Attributes.Add("ReadOnly", "true")
        txtSPOT_MAIL_9.Attributes.Add("ReadOnly", "true")
        txtSPOT_MAIL_10.Attributes.Add("ReadOnly", "true")
        txtSPOT_MAIL_11.Attributes.Add("ReadOnly", "true")
        txtSPOT_MAIL_12.Attributes.Add("ReadOnly", "true")
        txtSPOT_MAIL_13.Attributes.Add("ReadOnly", "true")
        txtSPOT_MAIL_14.Attributes.Add("ReadOnly", "true")
        txtSPOT_MAIL_15.Attributes.Add("ReadOnly", "true")
        txtSPOT_MAIL_16.Attributes.Add("ReadOnly", "true")
        txtSPOT_MAIL_17.Attributes.Add("ReadOnly", "true")
        txtSPOT_MAIL_18.Attributes.Add("ReadOnly", "true")
        txtSPOT_MAIL_19.Attributes.Add("ReadOnly", "true")
        txtSPOT_MAIL_20.Attributes.Add("ReadOnly", "true")
        txtSPOT_MAIL_21.Attributes.Add("ReadOnly", "true")
        txtSPOT_MAIL_22.Attributes.Add("ReadOnly", "true")
        txtSPOT_MAIL_23.Attributes.Add("ReadOnly", "true")
        txtSPOT_MAIL_24.Attributes.Add("ReadOnly", "true")
        txtSPOT_MAIL_25.Attributes.Add("ReadOnly", "true")
        txtSPOT_MAIL_26.Attributes.Add("ReadOnly", "true")
        txtSPOT_MAIL_27.Attributes.Add("ReadOnly", "true")
        txtSPOT_MAIL_28.Attributes.Add("ReadOnly", "true")
        txtSPOT_MAIL_29.Attributes.Add("ReadOnly", "true")
        txtSPOT_MAIL_30.Attributes.Add("ReadOnly", "true")
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
