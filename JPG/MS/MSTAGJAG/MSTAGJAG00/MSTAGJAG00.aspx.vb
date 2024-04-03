'***********************************************
'JA担当者・連絡先・注意事項マスタ  メイン画面
'***********************************************
' 変更履歴
' 2015/11/04 T.Ono 新規作成

Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common
Imports JPG.Common.log

Imports System.Text
Imports System.IO

Partial Class MSTAGJAG00
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

        '.NETの仕様変更により、ReadOnly属性をASPXでつけると、サーバ側で値の参照ができなくなるため、VB側でAttributeでつける
        If MyBase.IsPostBack = False Then
            txtKURACD.Attributes.Add("ReadOnly", "true")
            txtACBCD.Attributes.Add("ReadOnly", "true")
            txtGROUPCD.Attributes.Add("ReadOnly", "true")
            txtFileName1.Attributes.Add("ReadOnly", "true")
            txtFileName2.Attributes.Add("ReadOnly", "true")
            'JA担当者・ｽﾎﾟｯﾄFAX
            txtTANCD_1.Attributes.Add("ReadOnly", "true")
            txtTANCD_2.Attributes.Add("ReadOnly", "true")
            txtTANCD_3.Attributes.Add("ReadOnly", "true")
            txtTANCD_4.Attributes.Add("ReadOnly", "true")
            txtTANCD_5.Attributes.Add("ReadOnly", "true")
            txtTANCD_6.Attributes.Add("ReadOnly", "true")
            txtTANCD_7.Attributes.Add("ReadOnly", "true")
            txtTANCD_8.Attributes.Add("ReadOnly", "true")
            txtTANCD_9.Attributes.Add("ReadOnly", "true")
            txtTANCD_10.Attributes.Add("ReadOnly", "true")
            txtTANCD_11.Attributes.Add("ReadOnly", "true")
            txtTANCD_12.Attributes.Add("ReadOnly", "true")
            txtTANCD_13.Attributes.Add("ReadOnly", "true")
            txtTANCD_14.Attributes.Add("ReadOnly", "true")
            txtTANCD_15.Attributes.Add("ReadOnly", "true")
            txtTANCD_16.Attributes.Add("ReadOnly", "true")
            txtTANCD_17.Attributes.Add("ReadOnly", "true")
            txtTANCD_18.Attributes.Add("ReadOnly", "true")
            txtTANCD_19.Attributes.Add("ReadOnly", "true")
            txtTANCD_20.Attributes.Add("ReadOnly", "true")
            txtTANCD_21.Attributes.Add("ReadOnly", "true")
            txtTANCD_22.Attributes.Add("ReadOnly", "true")
            txtTANCD_23.Attributes.Add("ReadOnly", "true")
            txtTANCD_24.Attributes.Add("ReadOnly", "true")
            txtTANCD_25.Attributes.Add("ReadOnly", "true")
            txtTANCD_26.Attributes.Add("ReadOnly", "true")
            txtTANCD_27.Attributes.Add("ReadOnly", "true")
            txtTANCD_28.Attributes.Add("ReadOnly", "true")
            txtTANCD_29.Attributes.Add("ReadOnly", "true")
            txtTANCD_30.Attributes.Add("ReadOnly", "true")
            '自動FAX&ﾒｰﾙ
            txtTANCD2_1.Attributes.Add("ReadOnly", "true")
            txtTANCD2_2.Attributes.Add("ReadOnly", "true")
            txtTANCD2_3.Attributes.Add("ReadOnly", "true")
            txtTANCD2_4.Attributes.Add("ReadOnly", "true")
            txtTANCD2_5.Attributes.Add("ReadOnly", "true")
            txtTANCD2_6.Attributes.Add("ReadOnly", "true")
            txtTANCD2_7.Attributes.Add("ReadOnly", "true")
            txtTANCD2_8.Attributes.Add("ReadOnly", "true")
            txtTANCD2_9.Attributes.Add("ReadOnly", "true")
            txtTANCD2_10.Attributes.Add("ReadOnly", "true")
            txtTANCD2_11.Attributes.Add("ReadOnly", "true")
            txtTANCD2_12.Attributes.Add("ReadOnly", "true")
            txtTANCD2_13.Attributes.Add("ReadOnly", "true")
            txtTANCD2_14.Attributes.Add("ReadOnly", "true")
            txtTANCD2_15.Attributes.Add("ReadOnly", "true")
            txtTANCD2_16.Attributes.Add("ReadOnly", "true")
            txtTANCD2_17.Attributes.Add("ReadOnly", "true")
            txtTANCD2_18.Attributes.Add("ReadOnly", "true")
            txtTANCD2_19.Attributes.Add("ReadOnly", "true")
            txtTANCD2_20.Attributes.Add("ReadOnly", "true")
            txtTANCD2_21.Attributes.Add("ReadOnly", "true")
            txtTANCD2_22.Attributes.Add("ReadOnly", "true")
            txtTANCD2_23.Attributes.Add("ReadOnly", "true")
            txtTANCD2_24.Attributes.Add("ReadOnly", "true")
            txtTANCD2_25.Attributes.Add("ReadOnly", "true")
            txtTANCD2_26.Attributes.Add("ReadOnly", "true")
            txtTANCD2_27.Attributes.Add("ReadOnly", "true")
            txtTANCD2_28.Attributes.Add("ReadOnly", "true")
            txtTANCD2_29.Attributes.Add("ReadOnly", "true")
            txtTANCD2_30.Attributes.Add("ReadOnly", "true")
            txtAYMD.Attributes.Add("ReadOnly", "true")
            txtUYMD.Attributes.Add("ReadOnly", "true")
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
        '[担当者マスタ]使用可能権限(運:○/営:○/監:○/出:×)
        AuthC.fncAuthCheck(Server, AuthC.pGROUP_UNKOU & "," & AuthC.pGROUP_EIGYOU & "," & AuthC.pGROUP_KANSHI)

        '//------------------------------------------
        '<TODO>ポップアップ/登録系フレームの出力
        '      [hdnKensaku(Hidden)]を作成する事
        If hdnKensaku.Value = "COPOPUPG00" Then
            Server.Transfer("../../../Popup/COPOPUPG00.aspx")
        End If
        'Tips HTMLタグの使用方法
        If hdnKensaku.Value = "MSTAGJPG00" Then
            Server.Transfer("MSTAGJPG00.aspx")
        End If
        '警報一覧を表示する
        If hdnKensaku.Value = "MSTAGJCG00" Then
            Server.Transfer("MSTAGJCG00.aspx")
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
             MyBase.MapPath("../../../MS/MSTAGJAG/MSTAGJAG00/") & "MSTAGJAG00.js"))
        '<フォーカス関連関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncFo.js"))
        '<入力チェック関数>
        'strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncChk.js"))　当画面専用のものを使う
        '<電話番号チェック関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncTel.js"))
        '<数値関連関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncNumChk.js"))
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
            '//初めて開いた時だけ実行される

            '//--------------------------------------
            '初期表示として必要なコントロールの設定を行います
            Call fncIni_format()    '//値の初期化

            '//--------------------------------------
            '初期画面の状態設定
            Call fncIni_statebf()

            '//--------------------------------------------------------------------------
            'フォーカスをセットする
            strMsg.Append("Form1.btnSelect.focus();")

            '//-----------------------------------------------------
            '// 営業所グループのみに所属している場合、[営業所メニュー]より遷移してきている為
            '// 終了ボタン押下時は[営業所メニュー]に戻る
            '//-----------------------------------------------------

            hdnBackUrl.Value = ""

            Dim strGROUPNAME As String = AuthC.pGROUPNAME
            Dim arrGroupName() As String = strGROUPNAME.Split(Convert.ToChar(","))
            Dim arrKanshiGroup() As String = AuthC.pGROUP_KANSHI.Split(Convert.ToChar(","))
            Dim i As Integer
            Dim bolGroupFLG As Boolean = False

            '運行開発部・営業所の所属チェック
            If Array.IndexOf(arrGroupName, AuthC.pGROUP_UNKOU) >= 0 Or _
                Array.IndexOf(arrGroupName, AuthC.pGROUP_EIGYOU) >= 0 Then
                bolGroupFLG = True
            End If
            '監視センター所属チェック
            If bolGroupFLG = False Then
                For i = 0 To arrKanshiGroup.Length - 1
                    If Array.IndexOf(arrGroupName, arrKanshiGroup(i)) >= 0 Then
                        bolGroupFLG = True
                        '//営業所グループ
                        hdnBackUrl.Value = "KANSHI"
                        Exit For
                    End If
                Next i
            End If
            If bolGroupFLG = False Then
                Dim j As Integer
                Dim intEIGYOU_LEN As Integer
                Dim intGROUP_LEN As Integer
                intEIGYOU_LEN = AuthC.pGROUP_EIGYOU.Length
                For j = 0 To arrGroupName.Length - 1
                    intGROUP_LEN = arrGroupName(j).Length
                    If intGROUP_LEN > 0 Then
                        If Convert.ToString(arrGroupName(j)).Substring(intGROUP_LEN - intEIGYOU_LEN, intEIGYOU_LEN) = AuthC.pGROUP_EIGYOU Then
                            '//営業所グループ
                            hdnBackUrl.Value = "EIGYOU"
                        End If
                    End If
                Next
            End If

            '沖縄では、注意事項タブを表示しない
            If InStr(AuthC.pGROUPNAME, "0監視業務単独") > 0 Then
                hdntab.Value = "1"      '表示なし
            Else
                hdntab.Value = "0"      '表示あり
            End If

        Else
            '//--------------------------------------
            '//　２回目以降実行される
            '//--------------------------------------

            '報告要・不要タブ、ラベルの表示を設定。
            lblpre.Text = "JA注意事項"
            guidelineClck1.Text = "JA注意事項1"         '2019/11/01 w.ganeko 2019監視改善
            guidelineClck2.Text = "JA注意事項2"         '2019/11/01 w.ganeko 2019監視改善
            guidelineClck3.Text = "JA注意事項3"         '2019/11/01 w.ganeko 2019監視改善
            strMsg.Append("Form1.document.getElementById('tab4').style.display = 'block';")
        End If

        '//担当区分のラジオボタンで制御するため
        strMsg.Append("window_open();")

        '//-------------------------------------------------
        '<TODO>自分の画面IDをHIDDENのhdnMyAspxに書き込む（システム共通）
        hdnMyAspx.Value = "MSTAGJAG00"
        '//-------------------------------------------------


        '//-------------------------------------------------
        fncSearchAndSetFileName12() ' ファイルを検索＆表示

        ' コンボボックスのセット内容が、Loadすると度にクリアされるので、毎回セットしなおす
        Dim sAUTO_KBN(30) As String
        Dim sAUTO_ZERO_FLG(30) As String
        Dim sSD_PRT_FLG(30) As String    '2020/11/01 T.Ono add 2020監視改善
        Dim objAUTO_KBN As JPG.Common.Controls.CTLCombo
        Dim objAUTO_ZERO_FLG As JPG.Common.Controls.CTLCombo
        Dim objSD_PRT_FLG As JPG.Common.Controls.CTLCombo    '2020/11/01 T.Ono add 2020監視改善
        'fncCombo_Get(sAUTO_KBN, sAUTO_ZERO_FLG)             '2020/11/01 T.Ono mod 2020監視改善
        fncCombo_Get(sAUTO_KBN, sAUTO_ZERO_FLG, sSD_PRT_FLG)
        fncCombo_Create_AUTOKBN()
        fncCombo_Create_AUTOZEROFLG()
        fncCombo_Create_SDPRTFLG()    '2020/11/01 T.Ono add 2020監視改善
        For i As Integer = 1 To 30
            objAUTO_KBN = CType(FindControl("cboAUTO_KBN_" & CStr(i)), JPG.Common.Controls.CTLCombo)
            objAUTO_ZERO_FLG = CType(FindControl("cboAUTO_ZERO_FLG_" & CStr(i)), JPG.Common.Controls.CTLCombo)
            objSD_PRT_FLG = CType(FindControl("cboSD_PRT_FLG_" & CStr(i)), JPG.Common.Controls.CTLCombo)    '2020/11/01 T.Ono add 2020監視改善
            fncCombo_Select(objAUTO_KBN, sAUTO_KBN(i))
            fncCombo_Select(objAUTO_ZERO_FLG, sAUTO_ZERO_FLG(i))
            fncCombo_Select(objSD_PRT_FLG, sSD_PRT_FLG(i)) '2020/11/01 T.Ono add 2020監視改善
        Next

        'ファイル関係ボタンにイベントを追加
        btnFileDelete1.Attributes("OnClick") = "return confirm('削除してよろしいですか？');"
        btnFileDelete2.Attributes("OnClick") = "return confirm('削除してよろしいですか？');"
        btnFileUpload.Attributes("OnClick") = "return btnFileUpload_onclick();"
        '//-------------------------------------------------

    End Sub

    '******************************************************************************
    '* 検索処理がされる前の画面状態（ReadOnlyやDisabled）
    '********************************/*********************************************
    Private Sub fncIni_statebf()
        '//--------------------------------------------------------------------------
        '<TODO>検索前の状態にコントロールの状態を設定する

        btnKURACD.Disabled = False
        btnACBCD.Disabled = False
        btnGROUPCD.Disabled = False

    End Sub

    '******************************************************************************
    '* 検索処理がされた後の画面状態（ReadOnlyやDisabled）
    '******************************************************************************
    Private Sub fncIni_stateaf()
        '//--------------------------------------------------------------------------
        '<TODO>検索後の状態にコントロールの状態を設定する
        '

        '.NET 使用変更により、ReadOnlyはVB側でAttributeでつける
        txtKURACD.Attributes.Add("ReadOnly", "true")
        txtACBCD.Attributes.Add("ReadOnly", "true")
        txtGROUPCD.Attributes.Add("ReadOnly", "true")
        txtFileName1.Attributes.Add("ReadOnly", "true")
        txtFileName2.Attributes.Add("ReadOnly", "true")
        txtTANCD_1.Attributes.Add("ReadOnly", "true")
        txtTANCD_2.Attributes.Add("ReadOnly", "true")
        txtTANCD_3.Attributes.Add("ReadOnly", "true")
        txtTANCD_4.Attributes.Add("ReadOnly", "true")
        txtTANCD_5.Attributes.Add("ReadOnly", "true")
        txtTANCD_6.Attributes.Add("ReadOnly", "true")
        txtTANCD_7.Attributes.Add("ReadOnly", "true")
        txtTANCD_8.Attributes.Add("ReadOnly", "true")
        txtTANCD_9.Attributes.Add("ReadOnly", "true")
        txtTANCD_10.Attributes.Add("ReadOnly", "true")
        txtTANCD_11.Attributes.Add("ReadOnly", "true")
        txtTANCD_12.Attributes.Add("ReadOnly", "true")
        txtTANCD_13.Attributes.Add("ReadOnly", "true")
        txtTANCD_14.Attributes.Add("ReadOnly", "true")
        txtTANCD_15.Attributes.Add("ReadOnly", "true")
        txtTANCD_16.Attributes.Add("ReadOnly", "true")
        txtTANCD_17.Attributes.Add("ReadOnly", "true")
        txtTANCD_18.Attributes.Add("ReadOnly", "true")
        txtTANCD_19.Attributes.Add("ReadOnly", "true")
        txtTANCD_20.Attributes.Add("ReadOnly", "true")
        txtTANCD_21.Attributes.Add("ReadOnly", "true")
        txtTANCD_22.Attributes.Add("ReadOnly", "true")
        txtTANCD_23.Attributes.Add("ReadOnly", "true")
        txtTANCD_24.Attributes.Add("ReadOnly", "true")
        txtTANCD_25.Attributes.Add("ReadOnly", "true")
        txtTANCD_26.Attributes.Add("ReadOnly", "true")
        txtTANCD_27.Attributes.Add("ReadOnly", "true")
        txtTANCD_28.Attributes.Add("ReadOnly", "true")
        txtTANCD_29.Attributes.Add("ReadOnly", "true")
        txtTANCD_30.Attributes.Add("ReadOnly", "true")
        txtTANCD2_1.Attributes.Add("ReadOnly", "true")
        txtTANCD2_2.Attributes.Add("ReadOnly", "true")
        txtTANCD2_3.Attributes.Add("ReadOnly", "true")
        txtTANCD2_4.Attributes.Add("ReadOnly", "true")
        txtTANCD2_5.Attributes.Add("ReadOnly", "true")
        txtTANCD2_6.Attributes.Add("ReadOnly", "true")
        txtTANCD2_7.Attributes.Add("ReadOnly", "true")
        txtTANCD2_8.Attributes.Add("ReadOnly", "true")
        txtTANCD2_9.Attributes.Add("ReadOnly", "true")
        txtTANCD2_10.Attributes.Add("ReadOnly", "true")
        txtTANCD2_11.Attributes.Add("ReadOnly", "true")
        txtTANCD2_12.Attributes.Add("ReadOnly", "true")
        txtTANCD2_13.Attributes.Add("ReadOnly", "true")
        txtTANCD2_14.Attributes.Add("ReadOnly", "true")
        txtTANCD2_15.Attributes.Add("ReadOnly", "true")
        txtTANCD2_16.Attributes.Add("ReadOnly", "true")
        txtTANCD2_17.Attributes.Add("ReadOnly", "true")
        txtTANCD2_18.Attributes.Add("ReadOnly", "true")
        txtTANCD2_19.Attributes.Add("ReadOnly", "true")
        txtTANCD2_20.Attributes.Add("ReadOnly", "true")
        txtTANCD2_21.Attributes.Add("ReadOnly", "true")
        txtTANCD2_22.Attributes.Add("ReadOnly", "true")
        txtTANCD2_23.Attributes.Add("ReadOnly", "true")
        txtTANCD2_24.Attributes.Add("ReadOnly", "true")
        txtTANCD2_25.Attributes.Add("ReadOnly", "true")
        txtTANCD2_26.Attributes.Add("ReadOnly", "true")
        txtTANCD2_27.Attributes.Add("ReadOnly", "true")
        txtTANCD2_28.Attributes.Add("ReadOnly", "true")
        txtTANCD2_29.Attributes.Add("ReadOnly", "true")
        txtTANCD2_30.Attributes.Add("ReadOnly", "true")
        txtAYMD.Attributes.Add("ReadOnly", "true")
        txtUYMD.Attributes.Add("ReadOnly", "true")
    End Sub

    '******************************************************************************
    '* 各コントロールの設定値の初期化
    '******************************************************************************
    Private Sub fncIni_format()
        '//--------------------------------------------------------------------------
        '<TODO>コントロールの値を初期化する

        txtKURACD.Text = ""
        hdnKURACD.Value = ""
        txtACBCD.Text = ""
        hdnACBCD.Value = ""
        txtGROUPCD.Text = ""
        hdnGROUPCD.Value = ""
        hdnKBN.Value = ""
        hdnKEY.Value = ""
        hdnDBKBN.Value = ""
        txtGROUPNEW.Text = ""

        'キー以外の値を初期化する
        Call fncIni_notkey()

    End Sub

    '******************************************************************************
    '* キー以外の値を初期化する
    '******************************************************************************
    Private Sub fncIni_notkey()
        Call fncIni_date()
        '//--------------------------------------------------------------------------
        '<TODO>コントロールの値を初期化する

        hdnKURACD_MOTO.Value = ""
        hdnGROUPCD_MOTO.Value = ""

        Dim objCopy As System.Web.UI.WebControls.CheckBox 
        Dim objDISP_NO As System.Web.UI.HtmlControls.HtmlInputHidden
        Dim objTANCD As System.Web.UI.WebControls.TextBox
        Dim objTANNM As System.Web.UI.WebControls.TextBox
        Dim objRENTEL1 As System.Web.UI.WebControls.TextBox
        Dim objRENTEL2 As System.Web.UI.WebControls.TextBox
        Dim objRENTEL3 As System.Web.UI.WebControls.TextBox
        Dim objFAXNO As System.Web.UI.WebControls.TextBox
        Dim objBIKO As System.Web.UI.WebControls.TextBox
        Dim objAUTO_MAIL As System.Web.UI.WebControls.TextBox
        Dim objSPOT_MAIL As System.Web.UI.WebControls.TextBox
        Dim objMAIL_PASS As System.Web.UI.WebControls.TextBox
        Dim objAUTO_MAIL_PASS As System.Web.UI.WebControls.TextBox
        Dim objAUTO_FAXNO As System.Web.UI.WebControls.TextBox
        Dim objAUTO_FAXNM As System.Web.UI.WebControls.TextBox
        Dim i As Integer

        For i = 1 To 30
            'コントロール名を探し出し、型変換
            objCopy = CType(FindControl("chkCopy_" & CStr(i)), System.Web.UI.WebControls.CheckBox)
            objDISP_NO = CType(FindControl("hdnDISP_NO_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
            objTANCD = CType(FindControl("txtTANCD_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objTANNM = CType(FindControl("txtTANNM_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objRENTEL1 = CType(FindControl("txtRENTEL1_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objRENTEL2 = CType(FindControl("txtRENTEL2_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objRENTEL3 = CType(FindControl("txtRENTEL3_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objFAXNO = CType(FindControl("txtFAXNO_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objBIKO = CType(FindControl("txtBIKO_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objAUTO_MAIL = CType(FindControl("txtAUTO_MAIL_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objSPOT_MAIL = CType(FindControl("txtSPOT_MAIL_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objMAIL_PASS = CType(FindControl("txtMAIL_PASS_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objAUTO_MAIL_PASS = CType(FindControl("txtAUTO_MAIL_PASS_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objAUTO_FAXNO = CType(FindControl("txtAUTO_FAXNO_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objAUTO_FAXNM = CType(FindControl("txtAUTO_FAXNM_" & CStr(i)), System.Web.UI.WebControls.TextBox)

            objCopy.Checked = False 
            objDISP_NO.Value = CStr(i) '機械的に番号を付ける
            objTANCD.Text = Right("00" & CStr(i), 2) '機械的に番号を付ける
            objTANNM.Text = ""
            objRENTEL1.Text = ""
            objRENTEL2.Text = ""
            objRENTEL3.Text = ""
            objFAXNO.Text = ""
            objBIKO.Text = ""
            objAUTO_MAIL.Text = ""
            objSPOT_MAIL.Text = ""
            objMAIL_PASS.Text = ""
            objAUTO_MAIL_PASS.Text = ""
            objAUTO_FAXNO.Text = ""
            objAUTO_FAXNM.Text = ""
        Next

        txtGROUPNM.Text = ""

        txtGUIDELINE.Text = ""
        txtGUIDELINE2.Text = ""  '2019/11/01 w.ganeko 2019監視改善
        txtGUIDELINE3.Text = ""  '2019/11/01 w.ganeko 2019監視改善
        guidelineClck1.Checked = True  '2019/11/01 w.ganeko 2019監視改善
        guidelineClck2.Checked = False '2019/11/01 w.ganeko 2019監視改善
        guidelineClck3.Checked = False '2019/11/01 w.ganeko 2019監視改善
        txtGUIDELINENM1.Text = "" '2020/10/05 T.Ono add 監視改善2020
        txtGUIDELINENM2.Text = "" '2020/10/05 T.Ono add 監視改善2020
        txtGUIDELINENM3.Text = "" '2020/10/05 T.Ono add 監視改善2020
        checkedRadio(rdoFAXJA1)
        checkedRadio(rdoFAXKURA1)
        hdnFAXJA_MOTO.Value = "9"
        hdnFAXKURA_MOTO.Value = "9"

        'ファイル関連情報をクリア
        hdnFileKey.Text = ""
        txtFileName1.Text = ""
        txtFileName2.Text = ""

        ' コンボボックスのセット
        fncCombo_Create_AUTOKBN()
        fncCombo_Create_AUTOZEROFLG()
        fncCombo_Create_SDPRTFLG()    '2020/11/01 T.Ono add 2020監視改善

    End Sub

    '******************************************************************************
    '* 日付(作成日更新日)を初期化する
    '******************************************************************************
    Private Sub fncIni_date()
        txtAYMD.Text = ""
        txtUYMD.Text = ""
    End Sub

    '******************************************************************************
    '* 検索ボタンが押下されたときの処理
    '******************************************************************************
    Private Sub btnSelect_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.ServerClick
        Dim strRec As String

        'データを検索し、データを出力します
        strRec = fncbtnKensaku_ClickEvent("1")

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
    '* 登録ボタンが押下されたときの処理
    '******************************************************************************
    Private Sub btnUpdate_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.ServerClick
        Dim strRec As String
        strRec = fncbtnJikkou_ClickEvent(hdnKBN.Value)

        Call fncIni_stateaf()
    End Sub


    '******************************************************************************
    '* 取消ボタンが押下されたときの処理
    '******************************************************************************
    Private Sub btnClear_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.ServerClick
        Call fncIni_format()    '//値の初期化
        Call fncIni_statebf()   '//状態の初期化

        '//------------------------------------------
        '<TODO>フォーカスをセットする（初期画面に戻ったので(PageLoad同様)キーにセット）
        strMsg.Append("Form1.btnSelect.focus();")
    End Sub

    '******************************************************************************
    '*　概　要：絞込み条件を渡すプロパティ
    '*　備　考：抽出条件１の値を渡す
    '******************************************************************************
    Public ReadOnly Property pCode1() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                If hdnBackUrl.Value = "EIGYOU" Then
                    '//営業所グループの場合は監視センターが紐付けられない為、全クライアントを出力
                    strRec = ""
                Else
                    '//
                    strRec = AuthC.pAUTHCENTERCD    '//クライアントコード一覧 ＡＤ認証の使用可能監視センターコード
                End If
            ElseIf hdnPopcrtl.Value = "2" Then      '//JA支所コード一覧
                strRec = hdnKURACD.Value
            ElseIf hdnPopcrtl.Value = "3" Then      '//グループコード一覧
                If hdnBackUrl.Value = "EIGYOU" Then
                    '//営業所グループの場合は監視センターが紐付けられない為、全クライアントを出力
                    strRec = ""
                Else
                    '//
                    strRec = AuthC.pAUTHCENTERCD    '//クライアントコード一覧 ＡＤ認証の使用可能監視センターコード
                End If
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：絞込み条件を渡すプロパティ
    '*　備　考：抽出条件２の値を渡す
    '******************************************************************************
    Public ReadOnly Property pCode2() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "2" Then      '//JA支所コード一覧
                strRec = ""
            ElseIf hdnPopcrtl.Value = "3" Then      '//グループコード一覧
                strRec = hdnKURACD.Value.Trim
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：絞込み条件を渡すプロパティ
    '*　備　考：抽出条件３の値を渡す
    '******************************************************************************
    Public ReadOnly Property pCode3() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "2" Then      '//JA支所コード一覧
                strRec = ""
            ElseIf hdnPopcrtl.Value = "3" Then      '//グループコード一覧
                strRec = hdnACBCD.Value.Trim
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
            ElseIf hdnPopcrtl.Value = "2" Then      '//コード一覧
                strRec = "ＪＡ支所コード一覧"
            ElseIf hdnPopcrtl.Value = "3" Then      '//グループコード一覧
                strRec = "グループコード一覧"
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
            ElseIf hdnPopcrtl.Value = "2" Then      '//JA支所コード一覧
                strRec = "JASS3"
            ElseIf hdnPopcrtl.Value = "3" Then      '//グループコード一覧
                strRec = "JAHOKOKU"
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
                strRec = "hdnKURACD"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = "hdnACBCD"
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = "hdnGROUPCD"
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
                strRec = "txtKURACD"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = "txtACBCD"
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = "txtGROUPCD"
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：コードを返すオブジェクトの名前値を渡すプロパティ
    '*　備　考：データ選択後、コードを返すオブジェクト名を指定する　2015/02/18 T.Ono add 2014改善開発 No15
    '******************************************************************************
    Public ReadOnly Property pBackCode2() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
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
    '*　概　要：名称を返すオブジェクトの名前値を渡すプロパティ
    '*　備　考：データ選択後、名称を返すオブジェクト名を指定する　2015/02/18 T.Ono add 2014改善開発 No15
    '******************************************************************************
    Public ReadOnly Property pBackName2() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
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
    '*　概　要：フォーカスを返すオブジェクトの名前値を渡すプロパティ
    '*　備　考：データ選択後、値を返した後に、カーソルをセットする場所の指定
    '******************************************************************************
    Public ReadOnly Property pBackFocs() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "btnKURACD"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = "btnACBCD"
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = "btnGROUPCD"
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
                strRec = "hdnACBCD"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = "hdnGROUPCD"
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = "txtGROUPNEW"
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
                strRec = "txtACBCD"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = "txtGROUPCD"
            ElseIf hdnPopcrtl.Value = "3" Then      '//登録済み一覧    2015/02/18 T.Ono add 2014改善開発 No15
                strRec = ""
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：クライアント、JA支所選択時はお客様コード(From)をクリア 2013/07/04 T.Ono add
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pClear3() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "hdnGROUPCD"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = "txtGROUPNEW"
            ElseIf hdnPopcrtl.Value = "3" Then      '//登録済み一覧    2015/02/18 T.Ono add 2014改善開発 No15
                strRec = ""
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：クライアント、JA支所選択時はお客様コード(To)をクリア 2013/07/04 T.Ono add
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pClear4() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "txtGROUPCD"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = "txtGROUPNEW"
            ElseIf hdnPopcrtl.Value = "3" Then      '//登録済み一覧    2015/02/18 T.Ono add 2014改善開発 No15
                strRec = ""
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：クライアント、JA支所選択時はお客様名をクリア 2013/07/04 T.Ono add
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pClear5() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "txtGROUPNEW"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "3" Then      '//登録済み一覧    2015/02/18 T.Ono add 2014改善開発 No15
                strRec = ""
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
                'strRec = "fncFAXKBNDisp" '2015/02/18 T.Ono mod 2014改善開発 No15
                strRec = ""
            ElseIf hdnPopcrtl.Value = "2" Then  'ＪＡ支所
                'strRec = "fncFAXKBNDisp" '2015/02/18 T.Ono mod 2014改善開発 No15
                strRec = ""
            ElseIf hdnPopcrtl.Value = "3" Then  '登録済み一覧    2015/02/18 T.Ono add 2014改善開発 No15
                strRec = ""
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*　概　要：登録JA支所一覧のため、グループコードを渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pGROUPCD() As String
        Get
            pGROUPCD = hdnGROUPCD.Value
        End Get
    End Property

    '******************************************************************************
    '* データの出力処理
    '******************************************************************************
    Private Function fncbtnKensaku_ClickEvent(ByVal pstrKBN As String) As String
        '1:検索ボタン
        '2:実行後出力　(フォーカスのセットが変わります)
        Dim strRec As String

        strRec = "OK"

        fncIni_notkey() 'キー以外の項目初期化

        Try
            '//--------------------------------------
            '検索処理を行う
            Dim DateFncC As New CDateFnc
            Dim dbData As DataSet
            Dim UserCheckFLG As Boolean = True

            '検索ボタン押下か、登録後の検索か
            If pstrKBN = "1" Then
                '検索ボタン押下
                '検索キーをセット(hdnKEY、hdnDBKBN)（登録ボタン押下時は、セット済み）
                If (hdnGROUPCD.Value.Trim.Length > 0) Then
                    'グループ登録を検索
                    hdnKEY.Value = hdnGROUPCD.Value.Trim
                    hdnDBKBN.Value = "2" 'DB：KBN
                Else
                    'クライアント登録を検索
                    hdnKEY.Value = hdnKURACD.Value.Trim
                    hdnDBKBN.Value = "1"
                End If
            Else
                '登録後の検索
                If txtGROUPNEW.Text.Trim.Length > 0 Then
                    'グループコード新規の場合。グループコード選択で検索したときと同じ状態にしておく。
                    hdnGROUPCD.Value = txtGROUPNEW.Text.Trim
                End If
            End If


            '検索実行
            dbData = fncDataSelect(hdnDBKBN.Value)

            If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
                'データが存在しない為、検索はエラー
                'メッセージを出力後、検索前状態にする。

                strMsg.Append("alert('データが存在しません');")
                strMsg.Append("Form1.btnSelect.focus();")
                Call fncIni_statebf()
                '//--------------------------------------------------------------------------
            Else
                'データが存在する為、新規登録は不可
                'データを出力後、検索後状態にする。

                '------------------------------------
                '<TODO>データを出力する

                'クライアントコード
                hdnKURACD_MOTO.Value = hdnKURACD.Value
                'グループコード
                hdnGROUPCD_MOTO.Value = hdnGROUPCD.Value


                Dim sMinInsDate As String
                Dim sMaxUpdDate As String

                sMinInsDate = Convert.ToString(dbData.Tables(0).Rows(0).Item("INS_DATE"))
                sMaxUpdDate = Convert.ToString(dbData.Tables(0).Rows(0).Item("UPD_DATE"))

                Dim objDISP_NO As System.Web.UI.HtmlControls.HtmlInputHidden
                Dim objTANCD As System.Web.UI.WebControls.TextBox
                Dim objTANNM As System.Web.UI.WebControls.TextBox
                Dim objRENTEL1 As System.Web.UI.WebControls.TextBox
                Dim objRENTEL2 As System.Web.UI.WebControls.TextBox
                Dim objRENTEL3 As System.Web.UI.WebControls.TextBox
                Dim objFAXNO As System.Web.UI.WebControls.TextBox
                Dim objBIKO As System.Web.UI.WebControls.TextBox
                Dim objSPOT_MAIL As System.Web.UI.WebControls.TextBox
                Dim objMAIL_PASS As System.Web.UI.WebControls.TextBox
                Dim objAUTO_FAXNM As System.Web.UI.WebControls.TextBox
                Dim objAUTO_MAIL As System.Web.UI.WebControls.TextBox
                Dim objAUTO_MAIL_PASS As System.Web.UI.WebControls.TextBox
                Dim objAUTO_FAXNO As System.Web.UI.WebControls.TextBox
                Dim objAUTO_KBN As JPG.Common.Controls.CTLCombo
                Dim objAUTO_ZERO_FLG As JPG.Common.Controls.CTLCombo    '2020/11/01 T.Ono add 2020監視改善
                Dim objSD_PRT_FLG As JPG.Common.Controls.CTLCombo
                Dim objINS_DATE As System.Web.UI.HtmlControls.HtmlInputHidden
                Dim objINS_USER As System.Web.UI.HtmlControls.HtmlInputHidden
                Dim objUPD_DATE As System.Web.UI.HtmlControls.HtmlInputHidden
                Dim objUPD_USER As System.Web.UI.HtmlControls.HtmlInputHidden

                Dim strCboIndex As String 'コンボボックス選択インデックス

                Dim i As Integer
                Dim intRow As Integer
                Dim sTANCD As String

                For intRow = 0 To dbData.Tables(0).Rows.Count - 1

                    If intRow >= 30 Then Exit For '30件以上は処理抜け

                    '----------------------------
                    ' 最初の登録日、最後の更新日時を画面項目にセット
                    '----------------------------
                    '登録日が空か、以前の場合、セット
                    If sMinInsDate = "" _
                        Or Convert.ToString(dbData.Tables(0).Rows(0).Item("INS_DATE")) < sMinInsDate Then
                        sMinInsDate = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("INS_DATE"))
                    End If

                    '更新日が空か、さらに後の場合、セット
                    If Convert.ToString(dbData.Tables(0).Rows(intRow).Item("UPD_DATE")) <> "" _
                        And Convert.ToString(dbData.Tables(0).Rows(intRow).Item("UPD_DATE")) >= sMaxUpdDate Then
                        sMaxUpdDate = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("UPD_DATE"))
                    End If

                    '----------------------------
                    ' 明細情報を画面項目にセット
                    '----------------------------
                    sTANCD = Convert.ToString(CInt(dbData.Tables(0).Rows(intRow).Item("TANCD")))

                    If Trim(sTANCD) = "" Then
                        sTANCD = "0"
                    ElseIf IsNumeric(sTANCD) = False Then
                        sTANCD = "0"
                    End If

                    '表示番号が空か(設定されていない場合)、ループ中の回数より低い場合(同番で登録されている場合対策)
                    If CInt(sTANCD) >= 1 Then
                        objDISP_NO = CType(FindControl("hdnDISP_NO_" & sTANCD), System.Web.UI.HtmlControls.HtmlInputHidden)
                        objTANCD = CType(FindControl("txtTANCD_" & sTANCD), System.Web.UI.WebControls.TextBox)
                        objTANNM = CType(FindControl("txtTANNM_" & sTANCD), System.Web.UI.WebControls.TextBox)
                        objRENTEL1 = CType(FindControl("txtRENTEL1_" & sTANCD), System.Web.UI.WebControls.TextBox)
                        objRENTEL2 = CType(FindControl("txtRENTEL2_" & sTANCD), System.Web.UI.WebControls.TextBox)
                        objRENTEL3 = CType(FindControl("txtRENTEL3_" & sTANCD), System.Web.UI.WebControls.TextBox)
                        objFAXNO = CType(FindControl("txtFAXNO_" & sTANCD), System.Web.UI.WebControls.TextBox)
                        objBIKO = CType(FindControl("txtBIKO_" & sTANCD), System.Web.UI.WebControls.TextBox)
                        objSPOT_MAIL = CType(FindControl("txtSPOT_MAIL_" & sTANCD), System.Web.UI.WebControls.TextBox)
                        objMAIL_PASS = CType(FindControl("txtMAIL_PASS_" & sTANCD), System.Web.UI.WebControls.TextBox)
                        objAUTO_FAXNM = CType(FindControl("txtAUTO_FAXNM_" & sTANCD), System.Web.UI.WebControls.TextBox)
                        objAUTO_MAIL = CType(FindControl("txtAUTO_MAIL_" & sTANCD), System.Web.UI.WebControls.TextBox)
                        objAUTO_MAIL_PASS = CType(FindControl("txtAUTO_MAIL_PASS_" & sTANCD), System.Web.UI.WebControls.TextBox)
                        objAUTO_FAXNO = CType(FindControl("txtAUTO_FAXNO_" & sTANCD), System.Web.UI.WebControls.TextBox)
                        objAUTO_KBN = CType(FindControl("cboAUTO_KBN_" & sTANCD), JPG.Common.Controls.CTLCombo)
                        objAUTO_ZERO_FLG = CType(FindControl("cboAUTO_ZERO_FLG_" & sTANCD), JPG.Common.Controls.CTLCombo)    '2020/11/01 T.Ono add 2020監視改善
                        objSD_PRT_FLG = CType(FindControl("cboSD_PRT_FLG_" & sTANCD), JPG.Common.Controls.CTLCombo)
                        objINS_DATE = CType(FindControl("hdnINS_DATE_" & sTANCD), System.Web.UI.HtmlControls.HtmlInputHidden)
                        objINS_USER = CType(FindControl("hdnINS_USER_" & sTANCD), System.Web.UI.HtmlControls.HtmlInputHidden)
                        objUPD_DATE = CType(FindControl("hdnUPD_DATE_" & sTANCD), System.Web.UI.HtmlControls.HtmlInputHidden)
                        objUPD_USER = CType(FindControl("hdnUPD_USER_" & sTANCD), System.Web.UI.HtmlControls.HtmlInputHidden)

                        objDISP_NO.Value = CStr(i)
                        objTANCD.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("TANCD"))
                        objTANNM.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("TANNM"))
                        objRENTEL1.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("RENTEL1"))
                        objRENTEL2.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("RENTEL2"))
                        objRENTEL3.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("RENTEL3"))
                        objFAXNO.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("FAXNO"))
                        objBIKO.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("BIKO"))
                        objSPOT_MAIL.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("SPOT_MAIL"))
                        objMAIL_PASS.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("MAIL_PASS"))
                        objAUTO_FAXNM.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("AUTO_FAXNM"))
                        objAUTO_MAIL.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("AUTO_MAIL"))
                        objAUTO_MAIL_PASS.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("AUTO_MAIL_PASS"))
                        objAUTO_FAXNO.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("AUTO_FAXNO"))
                        objINS_DATE.Value = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("INS_DATE"))
                        objINS_USER.Value = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("INS_USER"))
                        objUPD_DATE.Value = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("UPD_DATE"))
                        objUPD_USER.Value = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("UPD_USER"))


                        ' 自動送信区分        ' 2013/07/04/ T.Ono add
                        strCboIndex = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("AUTO_KBN"))
                        fncCombo_Select(objAUTO_KBN, strCboIndex)

                        ' ゼロ件送信フラグ    ' 2013/07/04/ T.Ono add
                        strCboIndex = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("AUTO_ZERO_FLG"))
                        fncCombo_Select(objAUTO_ZERO_FLG, strCboIndex)

                        ' 出動依頼内容・備考表示フラグ    ' 2020/11/01 T.Ono add 2020監視改善
                        strCboIndex = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("SD_PRT_FLG"))
                        fncCombo_Select(objSD_PRT_FLG, strCboIndex)

                        If "01" = objTANCD.Text Then

                            'グループコード名
                            txtGROUPNM.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("GROUPNM"))

                            'JA注意事項セット
                            txtGUIDELINE.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("GUIDELINE"))
                            txtGUIDELINE2.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("GUIDELINE2"))  '2019/11/01 w.ganeko 2019監視改善 No 6
                            txtGUIDELINE3.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("GUIDELINE3"))  '2019/11/01 w.ganeko 2019監視改善 No 6

                            'JA注意事項　ボタン名
                            txtGUIDELINENM1.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("GUIDELINENM1"))　'2020/10/05 T.Ono add 監視改善2020
                            txtGUIDELINENM2.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("GUIDELINENM2"))  '2020/10/05 T.Ono add 監視改善2020
                            txtGUIDELINENM3.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("GUIDELINENM3"))  '2020/10/05 T.Ono add 監視改善2020


                            'FAX不要フラグ(ｸﾗｲｱﾝﾄ)
                            hdnFAXKURA_MOTO.Value = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("FAXKURAKBN"))
                            If Convert.ToString(dbData.Tables(0).Rows(intRow).Item("FAXKURAKBN")) = "1" Then
                                checkedRadio(rdoFAXKURA2)
                            ElseIf Convert.ToString(dbData.Tables(0).Rows(intRow).Item("FAXKURAKBN")) = "0" Then
                                checkedRadio(rdoFAXKURA1)
                            Else
                                checkedRadio(rdoFAXKURA1)
                            End If

                            'FAX不要フラグ(JA)
                            hdnFAXJA_MOTO.Value = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("FAXKBN"))
                            If Convert.ToString(dbData.Tables(0).Rows(intRow).Item("FAXKBN")) = "1" Then
                                checkedRadio(rdoFAXJA2)
                            ElseIf Convert.ToString(dbData.Tables(0).Rows(intRow).Item("FAXKBN")) = "0" Then
                                checkedRadio(rdoFAXJA1)
                            Else
                                checkedRadio(rdoFAXJA1)
                            End If
                        End If

                    End If
                Next ' intRow

                'グループコード　　グループコード新規登録やグループコード名変更時のために、再セット
                If Convert.ToString(dbData.Tables(0).Rows(0).Item("KBN")) = "2" Then
                    txtGROUPCD.Text = Convert.ToString(dbData.Tables(0).Rows(0).Item("GROUPCD")) & " : " & Convert.ToString(dbData.Tables(0).Rows(0).Item("GROUPNM"))
                End If

                'グループコード（新規登録用）検索後は空欄
                txtGROUPNEW.Text = ""

                '作成日
                If sMinInsDate.Trim.Length >= 10 Then
                    txtAYMD.Text = sMinInsDate.Substring(0, 10)
                Else
                    txtAYMD.Text = ""
                End If
                '更新日
                If sMaxUpdDate.Trim.Length >= 10 Then
                    txtUYMD.Text = sMaxUpdDate.Substring(0, 10)
                Else
                    txtUYMD.Text = ""
                End If


                'データがない項目に担当者コードを埋めておく
                For i = 1 To 30
                    objTANCD = CType(FindControl("txtTANCD_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                    If objTANCD.Text = "" Then
                        objTANCD.Text = Right("00" & CStr(i), 2)
                    End If
                Next

                If pstrKBN = "1" Then
                    '検索ボタン押下時
                    Call fncIni_stateaf()

                    '//------------------------------
                    '<TODO>フォーカスをセットする（データが存在したのでキー以外にセット）
                    strMsg.Append("Form1.btnSelect.focus();")
                End If


            End If
            dbData.Dispose()

            '注意事項のラベル
            '報告要・不要タブ(クライアント検索時は非表示)
            If hdnDBKBN.Value = "1" Then
                lblpre.Text = "クライアント注意事項"
                guidelineClck1.Text = "クライアント1"     '2019/11/01 w.ganeko 2019監視改善
                guidelineClck2.Text = "クライアント2"     '2019/11/01 w.ganeko 2019監視改善
                guidelineClck3.Text = "クライアント3"     '2019/11/01 w.ganeko 2019監視改善
                strMsg.Append("Form1.document.getElementById('tab4').style.display = 'none';")
            Else
                lblpre.Text = "JA注意事項"
                guidelineClck1.Text = "JA注意事項1"       '2019/11/01 w.ganeko 2019監視改善
                guidelineClck2.Text = "JA注意事項2"       '2019/11/01 w.ganeko 2019監視改善
                guidelineClck3.Text = "JA注意事項3"       '2019/11/01 w.ganeko 2019監視改善
            End If


            fncSearchAndSetFileName12() ' ファイルを検索＆表示

        Catch ex As Exception
            strRec = ex.ToString
            Dim ErrMsgC As New CErrMsg
            mlog("システムエラー：" & strRec)
            strMsg.Append("alert('システムエラー：" & ErrMsgC.mGetArtMsg(ex.ToString) & "');")
        End Try

        Return strRec

    End Function

    '******************************************************************************
    '* 登録・削除が押下されたときの処理
    '******************************************************************************
    Private Function fncbtnJikkou_ClickEvent(ByVal pstrKBN As String) As String

        Dim strRec As String
        Dim DateFncC As New CDateFnc

        '//------------------------------------------
        '<TODO>独自のWEBサービルを宣言する
        Dim MSTAGJAW00C As New MSTAGJAG00MSTAGJAW00.MSTAGJAW00


        '値を配列にセット
        Dim sDISP_NO(30) As String
        Dim sGROUPNM(30) As String
        Dim sTANCD(30) As String
        Dim sTANNM(30) As String
        Dim sRENTEL1(30) As String
        Dim sRENTEL2(30) As String
        Dim sRENTEL3(30) As String
        Dim sFAXNO(30) As String
        Dim sBIKO(30) As String
        Dim sSPOT_MAIL(30) As String
        Dim sMAIL_PASS(30) As String
        Dim sAUTO_FAXNM(30) As String
        Dim sAUTO_MAIL(30) As String
        Dim sAUTO_MAIL_PASS(30) As String
        Dim sAUTO_FAXNO(30) As String
        Dim sAUTO_KBN(30) As String
        Dim sAUTO_ZERO_FLG(30) As String
        Dim sSD_PRT_FLG(30) As String　'2020/11/01 T.Ono add 2020監視改善
        Dim sGUIDELINE(30) As String
        Dim sGUIDELINE2(30) As String  '2019/11/01 w.ganeko 2019監視改善　No6
        Dim sGUIDELINE3(30) As String　'2019/11/01 w.ganeko 2019監視改善　No6
        Dim sGUIDELINENM1(30) As String  '2020/11/01 T.Ono add 2020監視改善
        Dim sGUIDELINENM2(30) As String  '2020/11/01 T.Ono add 2020監視改善
        Dim sGUIDELINENM3(30) As String　'2020/11/01 T.Ono add 2020監視改善
        Dim sFAXKURAKBN(30) As String
        Dim sFAXJAKBN(30) As String
        Dim sINS_DATE(30) As String
        Dim sINS_USER(30) As String
        Dim sUPD_DATE(30) As String
        Dim sUPD_USER(30) As String
        Dim objDISP_NO As System.Web.UI.HtmlControls.HtmlInputHidden
        Dim objTANCD As System.Web.UI.WebControls.TextBox
        Dim objTANNM As System.Web.UI.WebControls.TextBox
        Dim objRENTEL1 As System.Web.UI.WebControls.TextBox
        Dim objRENTEL2 As System.Web.UI.WebControls.TextBox
        Dim objRENTEL3 As System.Web.UI.WebControls.TextBox
        Dim objFAXNO As System.Web.UI.WebControls.TextBox
        Dim objBIKO As System.Web.UI.WebControls.TextBox
        Dim objSPOT_MAIL As System.Web.UI.WebControls.TextBox
        Dim objMAIL_PASS As System.Web.UI.WebControls.TextBox
        Dim objAUTO_FAXNM As System.Web.UI.WebControls.TextBox
        Dim objAUTO_MAIL As System.Web.UI.WebControls.TextBox
        Dim objAUTO_MAIL_PASS As System.Web.UI.WebControls.TextBox
        Dim objAUTO_FAXNO As System.Web.UI.WebControls.TextBox
        Dim objAUTO_KBN As JPG.Common.Controls.CTLCombo
        Dim objAUTO_ZERO_FLG As JPG.Common.Controls.CTLCombo
        Dim objSD_PRT_FLG As JPG.Common.Controls.CTLCombo    '2020/11/01 T.Ono add 2020監視改善
        Dim objINS_DATE As System.Web.UI.HtmlControls.HtmlInputHidden
        Dim objINS_USER As System.Web.UI.HtmlControls.HtmlInputHidden
        Dim objUPD_DATE As System.Web.UI.HtmlControls.HtmlInputHidden
        Dim objUPD_USER As System.Web.UI.HtmlControls.HtmlInputHidden
        Dim i As Integer


        'キーをセット(hdnKEY、hdnDBKBN)
        If txtGROUPNEW.Text.Trim.Length > 0 Then
            'グループコード新規登録
            If fncDataCheck(txtGROUPNEW.Text.Trim) = False Then
                strRec = "グループコードが重複しています"
                strMsg.Append("alert('" & strRec & "');")

                '//------------------------------
                '<TODO>フォーカスをセットする
                strMsg.Append("Form1.txtGROUPNEW.focus();")
                Return strRec
            End If
            hdnKEY.Value = txtGROUPNEW.Text.Trim
            hdnDBKBN.Value = "2"
        ElseIf hdnGROUPCD.Value.Trim.Length > 0 Then
            'グループコード登録
            hdnKEY.Value = hdnGROUPCD.Value.Trim
            hdnDBKBN.Value = "2"
        ElseIf hdnKURACD.Value.Trim.Length > 0 Then
            'クライアント登録
            hdnKEY.Value = hdnKURACD.Value.Trim
            hdnDBKBN.Value = "1"
        Else
            strRec = "クライアントコードまたはグループコードを選択してください"
            Return strRec
        End If

        For i = 1 To 30
            'コントロール名を探し出し、型変換
            objDISP_NO = CType(FindControl("hdnDISP_NO_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
            objTANCD = CType(FindControl("txtTANCD_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objTANNM = CType(FindControl("txtTANNM_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objRENTEL1 = CType(FindControl("txtRENTEL1_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objRENTEL2 = CType(FindControl("txtRENTEL2_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objRENTEL3 = CType(FindControl("txtRENTEL3_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objFAXNO = CType(FindControl("txtFAXNO_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objBIKO = CType(FindControl("txtBIKO_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objAUTO_MAIL = CType(FindControl("txtAUTO_MAIL_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objSPOT_MAIL = CType(FindControl("txtSPOT_MAIL_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objMAIL_PASS = CType(FindControl("txtMAIL_PASS_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objAUTO_MAIL_PASS = CType(FindControl("txtAUTO_MAIL_PASS_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objAUTO_FAXNO = CType(FindControl("txtAUTO_FAXNO_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objAUTO_FAXNM = CType(FindControl("txtAUTO_FAXNM_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objAUTO_KBN = CType(FindControl("cboAUTO_KBN_" & CStr(i)), JPG.Common.Controls.CTLCombo)
            objAUTO_ZERO_FLG = CType(FindControl("cboAUTO_ZERO_FLG_" & CStr(i)), JPG.Common.Controls.CTLCombo)
            objSD_PRT_FLG = CType(FindControl("cboSD_PRT_FLG_" & CStr(i)), JPG.Common.Controls.CTLCombo)    '2020/11/01 T.Ono add 2020監視改善
            objINS_DATE = CType(FindControl("hdnINS_DATE_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
            objINS_USER = CType(FindControl("hdnINS_USER_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
            objUPD_DATE = CType(FindControl("hdnUPD_DATE_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
            objUPD_USER = CType(FindControl("hdnUPD_USER_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)

            sDISP_NO(i) = objDISP_NO.Value
            sTANCD(i) = objTANCD.Text
            sTANNM(i) = Trim(objTANNM.Text)
            sRENTEL1(i) = Trim(objRENTEL1.Text)
            sRENTEL2(i) = Trim(objRENTEL2.Text)
            sRENTEL3(i) = Trim(objRENTEL3.Text)
            sFAXNO(i) = Trim(objFAXNO.Text)
            sBIKO(i) = Trim(objBIKO.Text)
            sSPOT_MAIL(i) = Trim(objSPOT_MAIL.Text)
            sMAIL_PASS(i) = Trim(objMAIL_PASS.Text)
            sAUTO_FAXNM(i) = Trim(objAUTO_FAXNM.Text)
            sAUTO_MAIL(i) = Trim(objAUTO_MAIL.Text)
            sAUTO_MAIL_PASS(i) = Trim(objAUTO_MAIL_PASS.Text)
            sAUTO_FAXNO(i) = Trim(objAUTO_FAXNO.Text)
            sAUTO_KBN(i) = Request.Form(objAUTO_KBN.ID)
            sAUTO_ZERO_FLG(i) = Request.Form(objAUTO_ZERO_FLG.ID)
            sSD_PRT_FLG(i) = Request.Form(objSD_PRT_FLG.ID)    '2020/11/01 T.Ono add 2020監視改善
            sINS_DATE(i) = objINS_DATE.Value
            sINS_USER(i) = objINS_USER.Value
            sUPD_DATE(i) = objUPD_DATE.Value
            sUPD_USER(i) = objUPD_USER.Value

            If i = 1 Then
                'グループコード名
                sGROUPNM(i) = Trim(txtGROUPNM.Text)

                '注意事項
                sGUIDELINE(i) = Trim(txtGUIDELINE.Text)
                sGUIDELINE2(i) = Trim(txtGUIDELINE2.Text) '2019/11/01 w.ganeko 2019監視改善 No6
                sGUIDELINE3(i) = Trim(txtGUIDELINE3.Text) '2019/11/01 w.ganeko 2019監視改善 No6

                '注意事項　ボタン名
                sGUIDELINENM1(i) = Trim(txtGUIDELINENM1.Text) '2020/10/05 T.Ono add　監視改善2020
                sGUIDELINENM2(i) = Trim(txtGUIDELINENM2.Text) '2020/10/05 T.Ono add　監視改善2020
                sGUIDELINENM3(i) = Trim(txtGUIDELINENM3.Text) '2020/10/05 T.Ono add　監視改善2020

                'FAX不要フラグ
                'JA
                If rdoFAXJA1.Checked Then
                    sFAXJAKBN(i) = "0"
                ElseIf rdoFAXJA2.Checked Then
                    sFAXJAKBN(i) = "1"
                Else
                    sFAXJAKBN(i) = ""
                End If
                'ｸﾗｲｱﾝﾄ
                If rdoFAXKURA1.Checked Then
                    sFAXKURAKBN(i) = "0"
                ElseIf rdoFAXKURA2.Checked Then
                    sFAXKURAKBN(i) = "1"
                Else
                    sFAXKURAKBN(i) = ""
                End If
            Else
                sGROUPNM(i) = ""
                sGUIDELINE(i) = ""
                sGUIDELINE2(i) = ""  '2019/11/01 w.ganeko 2019監視改善 No6
                sGUIDELINE3(i) = ""  '2019/11/01 w.ganeko 2019監視改善 No6
                sGUIDELINENM1(i) = ""  '2020/10/05 T.Ono add 監視改善2020
                sGUIDELINENM2(i) = ""  '2020/10/05 T.Ono add 監視改善2020
                sGUIDELINENM3(i) = ""  '2020/10/05 T.Ono add 監視改善2020
                sFAXKURAKBN(i) = ""
                sFAXJAKBN(i) = ""
            End If

        Next

        '--------------------------------------------
        '<TODO>WEBサービスを呼び出す
        strRec = MSTAGJAW00C.mSetEx(
                    CInt(pstrKBN),
                    hdnDBKBN.Value,
                    hdnKEY.Value,
                    sGROUPNM,
                    sTANCD,
                    sTANNM,
                    sRENTEL1,
                    sRENTEL2,
                    sRENTEL3,
                    sFAXNO,
                    sBIKO,
                    sSPOT_MAIL,
                    sMAIL_PASS,
                    sAUTO_FAXNM,
                    sAUTO_MAIL,
                    sAUTO_MAIL_PASS,
                    sAUTO_FAXNO,
                    sAUTO_KBN,
                    sAUTO_ZERO_FLG,
                    sSD_PRT_FLG,    '2020/11/01 T.Ono add 2020監視改善
                    sGUIDELINE,
                    sGUIDELINE2,    '2019/11/01 w.ganeko 2019監視改善 No6
                    sGUIDELINE3,    '2019/11/01 w.ganeko 2019監視改善 No6
                    sGUIDELINENM1,  '2020/11/01 T.Ono add 2020監視改善
                    sGUIDELINENM2,  '2020/11/01 T.Ono add 2020監視改善
                    sGUIDELINENM3,  '2020/11/01 T.Ono add 2020監視改善
                    sFAXKURAKBN,
                    sFAXJAKBN,
                    sINS_DATE,
                    sINS_USER,
                    sUPD_DATE,
                    sUPD_USER,
                    AuthC.pUSERNAME
                    )
        '--------------------------------------------
        '<TODO>返り値による制御を行う。
        '【共通】
        '  OK : 正常に終了しました
        '   0 : 他のユーザーによってデータが更新されています。再度検索してください
        '   1 : 既にデータが存在します
        '   2 : 対象データが存在しません
        '   3 : 排他制御処理でエラーが発生しました。再度実行してください
        Dim strRecTemp As String = strRec
        Dim strRecMsg As String
        Select Case strRec
            Case "OK"
                If pstrKBN = "1" Or pstrKBN = "2" Then
                    strRec = fncbtnKensaku_ClickEvent("2")
                ElseIf pstrKBN = "4" Then '4:削除
                    Call fncIni_date()
                    'コンボボックスの初期化
                    fncCombo_Create_AUTOKBN()
                    fncCombo_Create_AUTOZEROFLG()

                    'ファイルの削除
                    If txtFileName1.Text.Trim.Length > 0 Then
                        fncFileDaleteClick("1")
                        txtFileName1.Text = ""
                    End If
                    If txtFileName2.Text.Trim.Length > 0 Then
                        fncFileDaleteClick("2")
                        txtFileName2.Text = ""
                    End If

                Else
                    Call fncIni_date()
                End If
                strMsg.Append("alert('正常に終了しました');")

                '//------------------------------

            Case "0"
                strRecMsg = "他のユーザーによってデータが更新されています。再度検索してください"
                strMsg.Append("alert('" & strRecMsg & "');")

                '//------------------------------
                '<TODO>フォーカスをセットする（修正時でのエラー。検索ボタンにセット）
                strMsg.Append("Form1.btnSelect.focus();")
                strRec = strRecMsg
            Case "3"
                strRecMsg = "排他制御処理でエラーが発生しました。再度実行してください"
                strMsg.Append("alert('" & strRecMsg & "');")

                '<TODO>フォーカスをセットする（登録・修正・削除時でのエラー。終了ボタンにセット）
                strMsg.Append("Form1.btnExit.focus();")
                strRec = strRecMsg
            Case "4"
                strRecMsg = "JAグループ作成マスタで使用されているデータがあります。\nデータを確認してください"
                strMsg.Append("alert('" & strRecMsg & "');")

                '<TODO>フォーカスをセットする（登録・修正・削除時でのエラー。検索ボタンにセット）
                strMsg.Append("Form1.btnSelect.focus();")
                strRec = strRecMsg
            Case "5"
                strRecMsg = "プルダウンマスタに登録がありません"
                strMsg.Append("alert('" & strRecMsg & "');")

                '<TODO>フォーカスをセットする（登録・修正時でのエラー。終了ボタンにセット）
                strMsg.Append("Form1.btnExit.focus();")

                strRec = strRecMsg
            Case "6"
                strRecMsg = "グループコードが不正です。\n先頭に所定のアルファベット2文字を入力してください"
                strMsg.Append("alert('" & strRecMsg & "');")
                '<TODO>フォーカスをセットする（登録・修正時でのエラー。検索ボタンにセット）
                strMsg.Append("Form1.btnSelect.focus();")

                strRec = strRecMsg

            Case "7" '2016/01/12 T.Ono add 2015改善開発
                strRecMsg = "グループコード名が重複しています"
                strMsg.Append("alert('" & strRecMsg & "');")
                '<TODO>フォーカスをセットする（登録・修正時でのエラー。検索ボタンにセット）
                strMsg.Append("Form1.txtGROUPNM.focus();")

                strRec = strRecMsg

            Case Else
                Dim ErrMsgC As New CErrMsg

                strMsg.Append("alert('システムエラー：" & ErrMsgC.mGetArtMsg(strRec) & "');")

                If pstrKBN = "1" Then
                    '//----------------------------------
                    '<TODO>フォーカスをセットする（登録処理：ログ出力のエラーの為キーにセット）
                ElseIf pstrKBN = "2" Then
                    '//----------------------------------
                    '<TODO>フォーカスをセットする（修正処理：ログ出力のエラーの為キー以降にセット）
                    strMsg.Append("Form1.txtTANNM_1.focus();")
                Else
                    '//----------------------------------
                    '<TODO>フォーカスをセットする（その他　：ログ出力のエラーの為キー以降にセット）
                    strMsg.Append("Form1.txtTANNM_1.focus();")
                End If
        End Select

        'エラーの場合は、コンボボックスの初期化と、入力値のセットを行う
        If strRecTemp <> "OK" Then
            ' コンボボックスセット
            fncCombo_Create_AUTOKBN()
            fncCombo_Create_AUTOZEROFLG()

            ' 入力内容のセット
            For j As Integer = 1 To 30
                objAUTO_KBN = CType(FindControl("cboAUTO_KBN_" & CStr(j)), JPG.Common.Controls.CTLCombo)
                objAUTO_ZERO_FLG = CType(FindControl("cboAUTO_ZERO_FLG_" & CStr(j)), JPG.Common.Controls.CTLCombo)
                objSD_PRT_FLG = CType(FindControl("cboSD_PRT_FLG_" & CStr(j)), JPG.Common.Controls.CTLCombo)      '2020/11/01 T.Ono add 2020監視改善
                fncCombo_Select(objAUTO_KBN, sAUTO_KBN(j))
                fncCombo_Select(objAUTO_ZERO_FLG, sAUTO_ZERO_FLG(j))
                fncCombo_Select(objSD_PRT_FLG, sSD_PRT_FLG(j))      '2020/11/01 T.Ono add 2020監視改善
            Next
        End If

        '-------------------------------------------------
        '//ＡＰログ書き込み
        Dim LogC As New CLog
        Dim strRecLog As String

        strRecLog = LogC.mAPLog(Me.Session.SessionID, AuthC.pUSERNAME, AuthC.pIPADDRESS, hdnMyAspx.Value, pstrKBN, strRec, Request.Form)

        If strRecLog <> "OK" Then
            Dim errmsgc As New CErrMsg
            strMsg.Append("alert('システムエラー：" & errmsgc.mGetArtMsg(strRecLog) & "');")
        End If

        Return strRec
    End Function

    '******************************************************************************
    '* 入力キーによるデータの検索を行います。
    '* pstrkbn　1:クライアント登録を検索
    '*        　2:グループ登録を検索
    '******************************************************************************
    Private Function fncDataSelect(ByVal pstrkbn As String) As DataSet

        '//------------------------------------------
        '//<TODO>Select文の作成
        Dim SQLC As New MSTAGJAG00CCSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet

        strSQL.Append("SELECT ")
        strSQL.Append("	A.KBN, ")
        strSQL.Append("	A.GROUPCD, ")
        strSQL.Append("	A.GROUPNM, ")
        strSQL.Append("	LPAD(A.TANCD, 2, '0') AS TANCD, ")
        strSQL.Append("	A.TANNM, ")
        strSQL.Append("	A.RENTEL1, ")
        strSQL.Append("	A.RENTEL2, ")
        strSQL.Append("	A.RENTEL3, ")
        strSQL.Append("	A.FAXNO, ")
        strSQL.Append("	A.BIKO, ")
        strSQL.Append("	A.SPOT_MAIL, ")
        strSQL.Append("	A.MAIL_PASS, ")
        strSQL.Append("	A.AUTO_FAXNM, ")
        strSQL.Append("	A.AUTO_MAIL, ")
        strSQL.Append("	A.AUTO_MAIL_PASS, ")
        strSQL.Append("	A.AUTO_FAXNO, ")
        strSQL.Append("	A.AUTO_KBN, ")
        strSQL.Append("	A.AUTO_ZERO_FLG, ")
        strSQL.Append("	A.SD_PRT_FLG, ")            '2020/11/01 T.Ono 2020監視改善
        strSQL.Append("	A.GUIDELINE, ")
        strSQL.Append("	A.GUIDELINE2, ")           '2019/11/01 w.ganeko 2019監視改善
        strSQL.Append("	A.GUIDELINE3, ")           '2019/11/01 w.ganeko 2019監視改善
        strSQL.Append("	A.GUIDELINENM1, ")          '2020/11/01 T.Ono 2020監視改善
        strSQL.Append("	A.GUIDELINENM2, ")          '2020/11/01 T.Ono 2020監視改善
        strSQL.Append("	A.GUIDELINENM3, ")          '2020/11/01 T.Ono 2020監視改善
        strSQL.Append("	A.FAXKURAKBN, ")
        strSQL.Append("	A.FAXKBN, ")
        strSQL.Append("	A.INS_DATE, ")
        strSQL.Append("	A.INS_USER, ")
        strSQL.Append("	A.UPD_DATE, ")
        strSQL.Append("	A.UPD_USER ")
        strSQL.Append("FROM M11_JAHOKOKU A ")
        strSQL.Append("WHERE A.GROUPCD = :CODE ")
        strSQL.Append("AND A.KBN = :KBN ")
        strSQL.Append("ORDER BY TO_NUMBER(A.TANCD) ")

        'パラメータ設定
        SqlParamC.fncSetParam("KBN", True, CStr(pstrkbn)) '1:クライアント登録を検索　2:グループ登録を検索

        If hdnKEY.Value.Trim.Length > 0 Then
            SqlParamC.fncSetParam("CODE", True, hdnKEY.Value)
        Else
            SqlParamC.fncSetParam("CODE", True, "")
        End If

        dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

        Return dbData
    End Function

    '******************************************************************************
    '* グループコード新規登録時の、DBチェック。
    '* 既に登録がある場合はエラーとする
    '******************************************************************************
    Private Function fncDataCheck(ByVal pstrgroupnew As String) As Boolean

        '//------------------------------------------
        '//<TODO>Select文の作成
        Dim SQLC As New MSTAGJAG00CCSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet
        Dim res As Boolean = False

        strSQL.Append("SELECT ")
        strSQL.Append("	'X' ")
        strSQL.Append("FROM M11_JAHOKOKU A ")
        strSQL.Append("WHERE A.GROUPCD = :GROUPCD ")
        strSQL.Append("AND A.KBN = '2' ")
        strSQL.Append("AND LPAD(A.TANCD,2,'0') = '01' ")

        'パラメータ設定
        If hdnKEY.Value.Trim.Length > 0 Then
            SqlParamC.fncSetParam("GROUPCD", True, pstrgroupnew)
        Else
            SqlParamC.fncSetParam("GROUPCD", True, "")
        End If

        dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

        If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
            res = True
        Else
            res = False
        End If

        Return res
    End Function
    '******************************************************************************
    '* ファイルアップロード処理
    '******************************************************************************
    Private Sub btnFileUpload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFileUpload.Click
        Dim uploadFile As HttpPostedFile
        Dim sSaveFileName As String
        Dim sSaveFileNameR As String
        Dim sSaveFileNameR2 As String '一部文字変換後
        Dim sSaveFileExt As String
        Dim sSavePath As String
        Dim sSaveFileKey As String 'ファイル保存時に頭に付けるキー（グループコード）
        Dim skipF As Boolean = False
        Dim fs As String()

        Try
            uploadFile = Request.Files("FileUpload1")
            If (uploadFile.FileName <> "") Then

                'ファイル名を準備
                sSaveFileNameR = System.IO.Path.GetFileName(uploadFile.FileName)
                sSaveFileExt = System.IO.Path.GetExtension(uploadFile.FileName) '拡張子取得し、小文字へ変換
                sSaveFileExt = sSaveFileExt.ToLower

                If txtGROUPNEW.Text.Trim <> "" Then
                    sSaveFileKey = txtGROUPNEW.Text.Trim & "_" 'グループコード（新規登録用）
                Else
                    sSaveFileKey = hdnGROUPCD.Value.Trim & "_" 'グループコード
                End If
                sSaveFileNameR2 = sSaveFileNameR
                sSaveFileNameR2 = sSaveFileNameR2.Replace("_", "＿") 'アンダーバーは区切り文字として使用するので置き換え
                sSaveFileNameR2 = sSaveFileNameR2.Replace(" ", "") '半角スペースは除去
                sSaveFileName = sSaveFileKey & sSaveFileNameR2
                sSavePath = ConfigurationSettings.AppSettings("JA_TAN_MST_PATH")

                '拡張子チェック
                'If sSaveFileExt = "lzh" Then           '2012/04/20 NEC ou Del
                If sSaveFileExt = ".lzh" Then           '2012/04/20 NEC ou Add
                    strMsg.Append("alert('拡張子がlzhは登録できません');")
                    strMsg.Append("Form1.btnSelect.focus();")
                    skipF = True
                    'ElseIf sSaveFileExt = "exe" Then   '2012/04/20 NEC ou Del
                ElseIf sSaveFileExt = ".exe" Then       '2012/04/20 NEC ou Add
                    strMsg.Append("alert('拡張子がexeは登録できません');")
                    strMsg.Append("Form1.btnSelect.focus();")
                    skipF = True
                End If

                '重複ファイルチェック
                fs = System.IO.Directory.GetFiles(sSavePath, sSaveFileName)   'folderにあるファイルを取得する
                If fs.Length >= 1 Then '既にファイルが登録されている？
                    strMsg.Append("alert('既にファイルが登録されています。[" & sSaveFileNameR & "]' );")
                    strMsg.Append("Form1.btnSelect.focus();")
                    skipF = True
                End If

                'ファイル件数MAXチェック
                fs = System.IO.Directory.GetFiles(sSavePath, sSaveFileKey & "*")   'folderにあるファイルを取得する
                If fs.Length >= 2 Then '既に２つ以上ファイルが登録されている？
                    strMsg.Append("alert('これ以上登録できません。');")
                    strMsg.Append("Form1.btnSelect.focus();")
                    skipF = True
                End If

                If skipF = False Then
                    '登録
                    uploadFile.SaveAs(sSavePath + sSaveFileName) 'ファイル保存！

                    fncSearchAndSetFileName12() 'ファイル名だけ再表示
                End If
            End If
        Catch ex As Exception
            mlog("システムエラー(btnFileUpload_Click)：" & ex.ToString)
            strMsg.Append("alert('ファイルの登録に失敗しました。\nもう一度検索しなおしてください。');")
            strMsg.Append("Form1.btnSelect.focus();")
        Finally
        End Try
    End Sub

    '******************************************************************************
    '* ファイル削除処理 イベント
    '******************************************************************************
    Private Sub btnFileDelete1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFileDelete1.Click

        If fncFileDaleteClick("1") Then '成功？
            fncSearchAndSetFileName12() 'ファイル名だけ再表示
        End If

    End Sub
    Private Sub btnFileDelete2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFileDelete2.Click

        If fncFileDaleteClick("2") Then '成功？
            fncSearchAndSetFileName12() 'ファイル名だけ再表示
        End If

    End Sub

    '******************************************************************************
    '* ファイル削除処理
    '******************************************************************************
    Private Function fncFileDaleteClick(ByVal strBtn As String) As Boolean

        Dim sSaveFileName As String   '実際の元ファイル名（拡張子あり）  jm1000001_テストファイル.xls
        Dim sSaveFileNameR As String  'ダウンロード後のファイル名        テストファイル.xls
        Dim sSavePath As String       '元ファイル保存フォルダ
        Dim skipF As Boolean = False
        Dim res As Boolean = False

        Try
            sSavePath = ConfigurationSettings.AppSettings("JA_TAN_MST_PATH")

            If strBtn = "1" Then
                sSaveFileNameR = txtFileName1.Text.Trim '☆ファイル名１☆
            Else
                sSaveFileNameR = txtFileName2.Text.Trim '☆ファイル名２☆
            End If
            sSaveFileName = hdnFileKey.Text & sSaveFileNameR 'ファイル名を、グループコード＋ファイル名に変換

            'ファイル存在チェック
            If sSaveFileNameR.Length <= 0 Then 'ファイル存在しない？     
                strMsg.Append("alert('ファイルを指定して下さい。');")
                skipF = True
            End If

            If skipF = False Then
                System.IO.File.Delete(sSavePath & sSaveFileName) '削除実行！
                res = True
            End If
        Catch ex As Exception
            mlog("システムエラー(fncFileDaleteClick)：" & ex.ToString)
            strMsg.Append("alert('ファイルの削除に失敗しました。\nもう一度検索しなおしてください。');")
        Finally
            strMsg.Append("Form1.btnSelect.focus();")
        End Try
        Return res

    End Function

    '******************************************************************************
    '* ファイルダウンロード処理
    '******************************************************************************
    Private Sub btnFileDownload1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFileDownload1.Click

        Dim sSaveFileName As String   '実際の元ファイル名（拡張子あり）  jm1000001_テストファイル.xls
        Dim sSaveFileNameR As String  'ダウンロード後のファイル名        テストファイル.xls
        Dim sSavePath As String       '元ファイル保存フォルダ
        Try
            sSavePath = ConfigurationSettings.AppSettings("JA_TAN_MST_PATH")
            sSaveFileNameR = txtFileName1.Text.Trim '☆ファイル名☆
            sSaveFileName = hdnFileKey.Text & sSaveFileNameR 'ファイル名を、グループコード＋ファイル名に変換

            fncFileDownload(sSavePath, sSaveFileName, sSaveFileNameR)
        Catch ex As Exception
            mlog("システムエラー(btnFileDownload1_Click)：" & ex.ToString)
            strMsg.Append("alert('ファイルのダウンロードに失敗しました。\nもう一度検索しなおしてください。');")
            strMsg.Append("Form1.btnSelect.focus();")
        Finally
        End Try
    End Sub
    Private Sub btnFileDownload2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFileDownload2.Click

        Dim sSaveFileName As String   '実際の元ファイル名（拡張子あり）  jm1000001_テストファイル.xls
        Dim sSaveFileNameR As String  'ダウンロード後のファイル名        テストファイル.xls
        Dim sSavePath As String       '元ファイル保存フォルダ           
        Try
            sSavePath = ConfigurationSettings.AppSettings("JA_TAN_MST_PATH")
            sSaveFileNameR = txtFileName2.Text.Trim '☆ファイル名☆
            sSaveFileName = hdnFileKey.Text & sSaveFileNameR 'ファイル名を、グループコード＋ファイル名に変換

            fncFileDownload(sSavePath, sSaveFileName, sSaveFileNameR)
        Catch ex As Exception
            mlog("システムエラー(btnFileDownload2_Click)：" & ex.ToString)
            strMsg.Append("alert('ファイルのダウンロードに失敗しました。\nもう一度検索しなおしてください。');")
            strMsg.Append("Form1.btnSelect.focus();")
        Finally
        End Try
    End Sub

    Private Function fncFileDownload(ByVal sSavePath As String, ByVal sSaveFileName As String, ByVal sSaveFileNameR As String) As String

        Dim dt As Byte()
        Dim sSaveFileNameS As String  '実際の元ファイル名（拡張子なし）  jm1000001_テストファイル
        Dim fpath As String           '元ファイルまでのフルパス          D:\TEMP\SAVE\jm1000001_テストファイル.xls

        Dim tmp As String

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

                '2018/02/13 T.Ono mod 圧縮せずファイルをダウンロードする。　-----START
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
                'compressC.mCompress()
                'putlog("MSTAGJAG00 - " & compressC.p_madeFilename)
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
                '    tmp = "alert('"
                '    tmp += "対象データが存在しません。\n\n"
                '    tmp += "[" & compressC.p_Dir.Replace("\", "\\") & "]\n"
                '    tmp += "[" & compressC.p_NihongoFileName.Replace("\", "\\") & "]\n"
                '    tmp += "[" & compressC.p_FileName.Replace("\", "\\") & "]\n"
                '    tmp += "[" & compressC.p_madeFilename.Replace("\", "\\") & "]"
                '    tmp += "');"
                '    strMsg.Append(tmp)
                '    strMsg.Append("Form1.btnSelect.focus();")
                'End If
                HttpHeaderC.mDownLoadXLS(Response, sSaveFileNameR)
                Response.WriteFile(sSavePath & sSaveFileName)
                '2018/02/13 T.Ono mod 圧縮せずファイルをダウンロードする。　-----END
            Else
                strMsg.Append("alert('" & "対象データが存在しません" & "');")
                strMsg.Append("Form1.btnSelect.focus();")
            End If

        Catch ex As Exception
            Throw ex
        Finally
            'If bw Is Nothing = False Then bw.Close()
            'If sw Is Nothing = False Then sw.Close()
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
        hdnFileKey.Text = ""
        txtFileName1.Text = ""
        txtFileName2.Text = ""

        folder = ConfigurationSettings.AppSettings("JA_TAN_MST_PATH")

        If txtGROUPNEW.Text.Trim <> "" Then
            searchPattern = txtGROUPNEW.Text.Trim & "_"
        Else
            searchPattern = hdnGROUPCD.Value.Trim & "_"
        End If
        Dim fs As String() = System.IO.Directory.GetFiles(folder, searchPattern & "*") 'folderにあるファイルを取得する
        If fs.Length > 0 Then
            buf = fs(0).Substring(fs(0).LastIndexOf("\") + 1)
            txtFileName1.Text = buf.Substring(searchPattern.Length)

            hdnFileKey.Text = searchPattern 'キーを保持
        End If
        If fs.Length > 1 Then
            buf = fs(1).Substring(fs(1).LastIndexOf("\") + 1)
            txtFileName2.Text = buf.Substring(searchPattern.Length)
        End If

        Call fncIni_stateaf()
    End Sub

    Public Sub putlog(ByVal strMsg As String)
        Dim textFile As System.IO.StreamWriter
        Dim folder As String = ConfigurationSettings.AppSettings("JA_TAN_MST_PATH")
        textFile = New System.IO.StreamWriter(folder & "COASYUKE00.log", True, System.Text.Encoding.Default)
        textFile.WriteLine(strMsg)
        textFile.Close()
    End Sub

    Private Sub checkedRadio(ByVal rdo As HtmlInputRadioButton)

        If rdo Is rdoFAXJA1 Then
            rdoFAXJA1.Checked = True
            rdoFAXJA2.Checked = False
        ElseIf rdo Is rdoFAXJA2 Then
            rdoFAXJA1.Checked = False
            rdoFAXJA2.Checked = True
        End If

        If rdo Is rdoFAXKURA1 Then
            rdoFAXKURA1.Checked = True
            rdoFAXKURA2.Checked = False
        ElseIf rdo Is rdoFAXKURA2 Then
            rdoFAXKURA1.Checked = False
            rdoFAXKURA2.Checked = True
        End If
    End Sub

    '**************************************************
    '* 自動送信区分コンボボックスセット
    '* 2013/07/04 T.Ono add
    '**************************************************
    Private Sub fncCombo_Create_AUTOKBN()
        For i As Integer = 1 To 30
            Dim objAUTO_KBN As JPG.Common.Controls.CTLCombo
            objAUTO_KBN = CType(FindControl("cboAUTO_KBN_" & CStr(i)), JPG.Common.Controls.CTLCombo)
            objAUTO_KBN.Items.Clear()
            objAUTO_KBN.Items.Add(New ListItem("", ""))
            objAUTO_KBN.Items.Add(New ListItem("0:送信なし", "0"))
            objAUTO_KBN.Items.Add(New ListItem("1:FAX送信", "1"))
            objAUTO_KBN.Items.Add(New ListItem("2:メール送信", "2"))
            objAUTO_KBN.Items.Add(New ListItem("3:FAX＆メール送信", "3"))
        Next
    End Sub

    '**************************************************
    '* ゼロ件送信フラグコンボボックスセット
    '* 2013/07/04 T.Ono add
    '**************************************************
    Private Sub fncCombo_Create_AUTOZEROFLG()
        For i As Integer = 1 To 30
            Dim objAUTO_ZERO_FLG As JPG.Common.Controls.CTLCombo
            objAUTO_ZERO_FLG = CType(FindControl("cboAUTO_ZERO_FLG_" & CStr(i)), JPG.Common.Controls.CTLCombo)
            objAUTO_ZERO_FLG.Items.Clear()
            objAUTO_ZERO_FLG.Items.Add(New ListItem("", ""))
            objAUTO_ZERO_FLG.Items.Add(New ListItem("0:送信なし", "0"))
            objAUTO_ZERO_FLG.Items.Add(New ListItem("1:送信あり", "1"))
        Next
    End Sub

    '**************************************************
    '* 出動依頼内容・備考フラグコンボボックスセット
    '* 2020/11/01 T.Ono add 2020監視改善
    '**************************************************
    Private Sub fncCombo_Create_SDPRTFLG()
        For i As Integer = 1 To 30
            Dim objSD_PRT_FLG As JPG.Common.Controls.CTLCombo
            objSD_PRT_FLG = CType(FindControl("cboSD_PRT_FLG_" & CStr(i)), JPG.Common.Controls.CTLCombo)
            objSD_PRT_FLG.Items.Clear()
            objSD_PRT_FLG.Items.Add(New ListItem("", ""))
            objSD_PRT_FLG.Items.Add(New ListItem("0:表示なし", "0"))
            objSD_PRT_FLG.Items.Add(New ListItem("1:表示あり", "1"))
        Next
    End Sub

    '**************************************************
    '* コンボボックスの選択
    '* 2013/07/04 T.Ono add
    '**************************************************
    Private Sub fncCombo_Select(ByVal obj As JPG.Common.Controls.CTLCombo, ByVal str As String)
        Dim list As New ListItem
        If str <> "" Then
            list = obj.Items.FindByValue(str)
            obj.SelectedIndex = obj.Items.IndexOf(list)
        End If
    End Sub

    '**************************************************
    '* コンボボックスの入力値取得
    '* 2013/07/04 T.Ono add
    '* 2020/11/01 T.Ono mod 2020監視改善 引数追加sSD_PRT_FLG
    '**************************************************
    Private Sub fncCombo_Get(ByRef sAUTO_KBN() As String, ByRef sAUTO_ZERO_FLG() As String, ByRef sSD_PRT_FLG() As String)
        'Private Sub fncCombo_Get(ByRef sAUTO_KBN() As String, ByRef sAUTO_ZERO_FLG() As String)
        Dim objAUTO_KBN As JPG.Common.Controls.CTLCombo
        Dim objAUTO_ZERO_FLG As JPG.Common.Controls.CTLCombo
        Dim objSD_PRT_FLG As JPG.Common.Controls.CTLCombo   '2020/11/01 T.Ono add 2020監視改善

        For i As Integer = 1 To 30
            objAUTO_KBN = CType(FindControl("cboAUTO_KBN_" & CStr(i)), JPG.Common.Controls.CTLCombo)
            objAUTO_ZERO_FLG = CType(FindControl("cboAUTO_ZERO_FLG_" & CStr(i)), JPG.Common.Controls.CTLCombo)
            objSD_PRT_FLG = CType(FindControl("cboSD_PRT_FLG_" & CStr(i)), JPG.Common.Controls.CTLCombo)   '2020/11/01 T.Ono add 2020監視改善
            sAUTO_KBN(i) = Request.Form(objAUTO_KBN.ID)
            sAUTO_ZERO_FLG(i) = Request.Form(objAUTO_ZERO_FLG.ID)
            sSD_PRT_FLG(i) = Request.Form(objSD_PRT_FLG.ID)   '2020/11/01 T.Ono add 2020監視改善
        Next
    End Sub


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
        Dim strRec As String

        Try
            If strLogFlg = "1" Then
                '書き込みファイルへのストリーム
                Dim outFile As New StreamWriter(strPath, True, System.Text.Encoding.Default)

                '引数の文字列をストリームに書き込み
                outFile.Write(System.DateTime.Now & "|" & AuthC.pUSERNAME & "|" & AuthC.pIPADDRESS & "|" & pstrString + vbCrLf)

                'メモリフラッシュ（ファイル書き込み）
                outFile.Flush()

                'ファイルクローズ
                outFile.Close()
            End If
        Catch ex As Exception
            strRec = "ERROR:" & ex.ToString
            strRecLog = LogC.mAPLog(Me.Session.SessionID, AuthC.pUSERNAME, AuthC.pIPADDRESS, Request.Form("hdnMyAspx"), "1", strRec, Request.Form)
        End Try
    End Sub
End Class
