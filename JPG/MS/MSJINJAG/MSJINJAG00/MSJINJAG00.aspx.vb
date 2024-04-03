'***********************************************
' 供給センターマスタ  メイン画面
'***********************************************
' 変更履歴

Option Explicit On
Option Strict On

Imports Common
Imports Common.DB   ' 2023/01/26 ADD Y.ARAKAKI 2022更改No⑤ _自動対応内容マスタ_特定警報Noの使用フラグ一括設定追加対応
Imports JPG.Common
Imports JPG.Common.log

Imports System.Text


Partial Class MSJINJAG00
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

    'コンボボックスの値格納
    Private strCBO_PROCKBN(30) As String
    Private strCBO_TAIOKBN(30) As String
    Private strCBO_TMSKB(30) As String
    Private strCBO_TAITCD(30) As String
    Private strCBO_TFKICD(30) As String
    Private strCBO_TKIGCD(30) As String
    Private strCBO_TSADCD(30) As String
    Private strCBO_TELRCD(30) As String
    Private strCBO_USE_FLG(30) As String
    ' 2023/01/26 ADD START Y.ARAKAKI 2022更改No⑤ _自動対応内容マスタ_特定警報Noの使用フラグ一括設定追加対応
    Private strCBO_JTLISTFROM As String
    Private strCBO_JTLISTTO As String
    ' 2023/01/26 ADD END   Y.ARAKAKI 2022更改No⑤ _自動対応内容マスタ_特定警報Noの使用フラグ一括設定追加対応

    '******************************************************************************
    ' Page_Load
    '******************************************************************************
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '2012/04/03 NEC ou Add
        '.NETの仕様変更により、ReadOnly属性をASPXでつけると、サーバ側で値の参照ができなくなるため、VB側でAttributeでつける
        If MyBase.IsPostBack = False Then
            Dim objDefNO As System.Web.UI.WebControls.TextBox
            Dim objDefDEL As System.Web.UI.WebControls.CheckBox

            Dim i As Integer
            For i = 1 To 30
                objDefNO = CType(FindControl("txtNO_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                objDefDEL = CType(FindControl("chkDEL_" & CStr(i)), System.Web.UI.WebControls.CheckBox)

                objDefNO.Attributes.Add("ReadOnly", "true")
                objDefDEL.Checked = False
            Next
        End If
        '2012/04/03 NEC ou Add
        txtGROUPCD.Attributes.Add("ReadOnly", "true")

        '//------------------------------------------
        '//　HTTPヘッダを送信
        HttpHeaderC.mNoCache(Response)

        '//------------------------------------------
        '//　認証クラスのインスタンス生成
        AuthC = New CAuthenticate(Request, Response)

        '//------------------------------------------
        '//　認証処理
        '<TODO>：使用可能権限を指定する
        '[自動対応内容マスタ]使用可能権限(運:○/営:×/監:○/出:×)
        AuthC.fncAuthCheck(Server, AuthC.pGROUP_UNKOU & "," & AuthC.pGROUP_KANSHI)

        '//------------------------------------------
        '<TODO>ポップアップ/登録系フレームの出力
        '      [hdnKensaku(Hidden)]を作成する事
        'If hdnKensaku.Value = "COPOPUPG00" Then
        '    Server.Transfer("../../../Popup/COPOPUPG00.aspx")
        'End If
        '警報一覧を表示する（ポップアップ）
        If hdnKensaku.Value = "MSJINJCG00" Then
            Server.Transfer("MSJINJCG00.aspx")
        End If
        '2017/02/09 W.GANEKO ADD 2016監視改善
        If hdnKensaku.Value = "COPOPUPG00" Then
            Server.Transfer("../../../Popup/COPOPUPG00.aspx")
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
             MyBase.MapPath("../../../MS/MSJINJAG/MSJINJAG00/") & "MSJINJAG00.js"))
        '<フォーカス関連関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncFo.js"))
        '<入力チェック関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncChk.js"))
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
            '初期画面の状態設定(画面を【検索前状態】にする（入力データはそのまま遷移させる)
            Call fncIni_statebf()

            '//--------------------------------------------------------------------------
            'フォーカスをセットする
            strMsg.Append("Form1.btnSelect.focus();")


        Else
            '//--------------------------------------
            '//　２回目以降実行される
            '//--------------------------------------

            '2017/02/09 W.GANEKO DEL START 
            'グループコードコンボボックスの再設定
            'Dim list As ListItem
            'fncCombo_Create_GROUPCD()
            'list = cboGROUPCD.Items.FindByValue(Request.Form("cboGROUPCD"))
            ''list = cboGROUPCD.Items.FindByText(hdnGROUPCD.Value.Trim)
            'cboGROUPCD.SelectedIndex = cboGROUPCD.Items.IndexOf(list)

            '一覧のコンボボックスの再設定
            Dim i As Integer
            For i = 1 To 30
                fncCombo_Create_PROCKBN(i)
                fncCombo_Create_TAIOKBN(i)
                fncCombo_Create_TMSKB(i)
                fncCombo_Create_TAITCD(i)
                fncCombo_Create_TFKICD(i)
                fncCombo_Create_TKIGCD(i)
                fncCombo_Create_TSADCD(i)
                fncCombo_Create_TELRCD(i)
                fncCombo_Create_USE_FLG(i)

                fncComboGet(i) 'コンボボックスの取得
                fncComboSet(i) 'コンボボックスの設定
            Next

            fncCombo_Create_JidouTaiouGroupList()  ' 2023/01/26 ADD Y.ARAKAKI 2022更改No⑤ _自動対応内容マスタ_特定警報Noの使用フラグ一括設定追加対応
            fncComboGetAndSet_FromTo() '画面に値設定あれば、復元
        End If



        '<TODO>自分の画面IDをHIDDENのhdnMyAspxに書き込む（システム共通）
        hdnMyAspx.Value = "MSJINJAG00"
        '//-------------------------------------------------

    End Sub

    '******************************************************************************
    '* 検索処理がされる前の画面状態（ReadOnlyやDisabled）
    '********************************/*********************************************
    Private Sub fncIni_statebf()
        '//--------------------------------------------------------------------------
        '<TODO>検索前の状態にコントロールの状態を設定する

        'btnGROUPCD.Disabled = False

    End Sub

    '******************************************************************************
    '* 検索処理がされた後の画面状態（ReadOnlyやDisabled）
    '******************************************************************************
    Private Sub fncIni_stateaf()
        '//--------------------------------------------------------------------------
        '<TODO>検索後の状態にコントロールの状態を設定する
        '
        Dim objNO As System.Web.UI.WebControls.TextBox
        Dim objDEL As System.Web.UI.WebControls.CheckBox
        Dim i As Integer
        For i = 1 To 30
            objNO = CType(FindControl("txtNO_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objDEL = CType(FindControl("chkDEL_" & CStr(i)), System.Web.UI.WebControls.CheckBox)

            objNO.Attributes.Add("ReadOnly", "true")
            objDEL.Checked = False
        Next
    End Sub

    '******************************************************************************
    '* 各コントロールの設定値の初期化
    '******************************************************************************
    Private Sub fncIni_format()
        '//--------------------------------------------------------------------------
        txtGROUPCD.Text = ""       '2017/02/09 W.GANEKO ADD 2016監視改善 №10
        hdnGROUPCD.Value = ""
        txtGROUPCD_NEW.Text = ""
        'fncCombo_Create_GROUPCD() 'グループコード

        'キー以外の値を初期化する
        Call fncIni_notkey()

    End Sub

    '******************************************************************************
    '* キー以外の値を初期化する
    '******************************************************************************
    Private Sub fncIni_notkey()
        '//--------------------------------------------------------------------------
        '<TODO>コントロールの値を初期化する

        hdnGROUPCD_MOTO.Value = ""

        Dim objDEL As System.Web.UI.WebControls.CheckBox
        Dim objKMCD As System.Web.UI.WebControls.TextBox
        Dim objKMNM As System.Web.UI.WebControls.TextBox
        Dim objTKTANCD As System.Web.UI.WebControls.TextBox
        Dim objTEL_MEMO1 As System.Web.UI.WebControls.TextBox
        Dim objBIKO As System.Web.UI.WebControls.TextBox
        Dim objINS_DATE As System.Web.UI.HtmlControls.HtmlInputHidden
        Dim objUPD_DATE As System.Web.UI.HtmlControls.HtmlInputHidden

        txtGROUPNM.Text = "" 'ｸﾞﾙｰﾌﾟｺｰﾄﾞ名

        Dim i As Integer

        For i = 1 To 30
            'コントロール名を探し出し、型変換
            objDEL = CType(FindControl("chkDEL_" & CStr(i)), System.Web.UI.WebControls.CheckBox)
            objKMCD = CType(FindControl("txtKMCD_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objKMNM = CType(FindControl("txtKMNM_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objTKTANCD = CType(FindControl("txtTKTANCD_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objTEL_MEMO1 = CType(FindControl("txtTEL_MEMO1_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objBIKO = CType(FindControl("txtBIKO_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objINS_DATE = CType(FindControl("hdnINS_DATE_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
            objUPD_DATE = CType(FindControl("hdnUPD_DATE_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)

            objDEL.Checked = False
            objKMCD.Text = ""
            objKMNM.Text = ""
            objTKTANCD.Text = ""
            objTEL_MEMO1.Text = ""
            objBIKO.Text = ""
            objINS_DATE.Value = ""
            objUPD_DATE.Value = ""


            'コンボボックスの初期化
            fncCombo_Create_PROCKBN(i)
            fncCombo_Create_TAIOKBN(i)
            fncCombo_Create_TMSKB(i)
            fncCombo_Create_TAITCD(i)
            fncCombo_Create_TFKICD(i)
            fncCombo_Create_TKIGCD(i)
            fncCombo_Create_TSADCD(i)
            fncCombo_Create_TELRCD(i)
            fncCombo_Create_USE_FLG(i)

        Next

        fncCombo_Create_JidouTaiouGroupList()  ' 2023/01/26 ADD Y.ARAKAKI 2022更改No⑤ _自動対応内容マスタ_特定警報Noの使用フラグ一括設定追加対応

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
        cboJTLISTFROM.Items.Clear() '//初期化：グループコードListFrom
        cboJTLISTTO.Items.Clear() '//初期化：グループコードListTo

        Call fncIni_format()    '//値の初期化
        Call fncIni_statebf()   '//状態の初期化

        '//------------------------------------------
        '<TODO>フォーカスをセットする（初期画面に戻ったので(PageLoad同様)キーにセット）
        strMsg.Append("Form1.btnSelect.focus();")
    End Sub

    ' 2023/02/07 ADD START Y.ARAKAKI 2022更改No⑤ _自動対応内容マスタ_特定警報Noの使用フラグ一括設定追加対応
    '******************************************************************************
    '* 更新：使用可へ ボタンが押下されたときの処理 
    '******************************************************************************
    Private Sub btnUpdateJtFlgAllOn_ServerClick(ByVal sender As System.Object,
                                                ByVal e As System.EventArgs) Handles btnUpdateJtFlgAllOn.ServerClick
        Dim strRec As String
        strRec = fncbtnUpdFromTo_ClickEvent("1") '更新処理呼出（1:使用可）

        Call fncIni_stateaf()
    End Sub
    '******************************************************************************
    '* 更新：使用不可へ ボタンが押下されたときの処理 
    '******************************************************************************
    Private Sub btnUpdateJtFlgAllOff_ServerClick(ByVal sender As System.Object,
                                                 ByVal e As System.EventArgs) Handles btnUpdateJtFlgAllOff.ServerClick
        Dim strRec As String
        strRec = fncbtnUpdFromTo_ClickEvent("2") '更新処理呼出（2:使用不可）

        Call fncIni_stateaf()
    End Sub
    ' 2023/02/07 ADD END   Y.ARAKAKI 2022更改No⑤ _自動対応内容マスタ_特定警報Noの使用フラグ一括設定追加対応

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


            'キーを格納
            If pstrKBN = "2" Then
                '2017/02/09 W.GANEKO UPD START 2016監視改善
                '登録処理後。グループコードの削除、新規登録に対応するため、コンボボックスを再セット
                'Dim list As New ListItem
                ''コンボボックスを再セット
                'fncCombo_Create_GROUPCD()
                ''グループコードを表示
                'list = cboGROUPCD.Items.FindByText(hdnGROUPCD.Value)
                'cboGROUPCD.SelectedIndex = cboGROUPCD.Items.IndexOf(list)
                '削除によりグループコードが存在しなくなった
                'If cboGROUPCD.SelectedIndex.ToString = "0" Then
                '    hdnGROUPCD.Value = ""
                '    '//------------------------------
                '    '<TODO>フォーカスをセットする（データが存在したのでキー以外にセット）
                '    strMsg.Append("Form1.btnSelect.focus();")
                '    Return strRec
                'End If
            Else
                'hdnGROUPCD.Value = Convert.ToString(cboGROUPCD.Items.Item(CInt(Request.Form("cboGROUPCD"))))
            End If


            dbData = fncDataSelect()

            If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
                'データが存在しない為、検索はエラー
                'メッセージを出力後、検索前状態にする。

                strMsg.Append("alert('データが存在しません');")

                Call fncIni_statebf()

                '//------------------------------
                '<TODO>フォーカスをセットする（検索ボタンへセット）
                strMsg.Append("Form1.btnSelect.focus();")

                '//--------------------------------------------------------------------------
            Else
                'データが存在する為、データ出力

                '------------------------------------
                '<TODO>30件以上の場合はメッセージ
                If dbData.Tables(0).Rows.Count > 30 Then
                    strMsg.Append("alert('最大出力件数を超えました。条件を指定して再度検索してください');")
                End If

                '------------------------------------
                '<TODO>データを出力する

                'グループコード
                hdnGROUPCD.Value = Convert.ToString(dbData.Tables(0).Rows(0).Item("GROUPCD"))
                hdnGROUPCD_MOTO.Value = Convert.ToString(dbData.Tables(0).Rows(0).Item("GROUPCD"))
                txtGROUPNM.Text = Convert.ToString(dbData.Tables(0).Rows(0).Item("GROUPNM"))          '2017/02/09 W.GANEKO ADD 2016監視改善

                ''監視センター名
                'txtCODE.Text = Convert.ToString(dbData.Tables(0).Rows(0).Item("CODE")) & " : " & Convert.ToString(dbData.Tables(0).Rows(0).Item("KANSI_NAME"))


                Dim objKMCD As System.Web.UI.WebControls.TextBox
                Dim objKMNM As System.Web.UI.WebControls.TextBox
                Dim objTKTANCD As System.Web.UI.WebControls.TextBox
                Dim objTEL_MEMO1 As System.Web.UI.WebControls.TextBox
                Dim objBIKO As System.Web.UI.WebControls.TextBox
                Dim objINS_DATE As System.Web.UI.HtmlControls.HtmlInputHidden
                Dim objUPD_DATE As System.Web.UI.HtmlControls.HtmlInputHidden

                'Dim objPROCKBN As JPG.Common.Controls.CTLCombo
                'Dim objTAIOKBN As JPG.Common.Controls.CTLCombo
                'Dim objTMSKB As JPG.Common.Controls.CTLCombo
                'Dim objTAITCD As JPG.Common.Controls.CTLCombo
                'Dim objTFKICD As JPG.Common.Controls.CTLCombo
                'Dim objTKIGCD As JPG.Common.Controls.CTLCombo
                'Dim objTSADCD As JPG.Common.Controls.CTLCombo
                'Dim objTELRCD As JPG.Common.Controls.CTLCombo
                'Dim objUSE_FLG As JPG.Common.Controls.CTLCombo


                Dim intRow As Integer

                For intRow = 0 To dbData.Tables(0).Rows.Count - 1

                    If intRow >= 30 Then Exit For '30件以上は処理抜け

                    '----------------------------
                    ' 明細情報を画面項目にセット
                    '----------------------------
                    'コントロール名を探し出し、型変換
                    objKMCD = CType(FindControl("txtKMCD_" & CStr(intRow + 1)), System.Web.UI.WebControls.TextBox)
                    objKMNM = CType(FindControl("txtKMNM_" & CStr(intRow + 1)), System.Web.UI.WebControls.TextBox)
                    objTKTANCD = CType(FindControl("txtTKTANCD_" & CStr(intRow + 1)), System.Web.UI.WebControls.TextBox)
                    objTEL_MEMO1 = CType(FindControl("txtTEL_MEMO1_" & CStr(intRow + 1)), System.Web.UI.WebControls.TextBox)
                    objBIKO = CType(FindControl("txtBIKO_" & CStr(intRow + 1)), System.Web.UI.WebControls.TextBox)
                    objINS_DATE = CType(FindControl("hdnINS_DATE_" & CStr(intRow + 1)), System.Web.UI.HtmlControls.HtmlInputHidden)
                    objUPD_DATE = CType(FindControl("hdnUPD_DATE_" & CStr(intRow + 1)), System.Web.UI.HtmlControls.HtmlInputHidden)

                    'キー項目は変更不可にする
                    objKMCD.ReadOnly = True
                    objKMCD.BackColor = Color.Gainsboro
                    objKMNM.ReadOnly = True
                    objKMNM.BackColor = Color.Gainsboro

                    'objPROCKBN = CType(FindControl("cboPROCKBN_" & CStr(intRow + 1)), JPG.Common.Controls.CTLCombo)
                    'objTAIOKBN = CType(FindControl("cboTAIOKBN_" & CStr(intRow + 1)), JPG.Common.Controls.CTLCombo)
                    'objTMSKB = CType(FindControl("cboTMSKB_" & CStr(intRow + 1)), JPG.Common.Controls.CTLCombo)
                    'objTAITCD = CType(FindControl("cboTAITCD_" & CStr(intRow + 1)), JPG.Common.Controls.CTLCombo)
                    'objTFKICD = CType(FindControl("cboTFKICD_" & CStr(intRow + 1)), JPG.Common.Controls.CTLCombo)
                    'objTKIGCD = CType(FindControl("cboTKIGCD_" & CStr(intRow + 1)), JPG.Common.Controls.CTLCombo)
                    'objTSADCD = CType(FindControl("cboTSADCD_" & CStr(intRow + 1)), JPG.Common.Controls.CTLCombo)
                    'objTELRCD = CType(FindControl("cboTELRCD_" & CStr(intRow + 1)), JPG.Common.Controls.CTLCombo)
                    'objUSE_FLG = CType(FindControl("cboUSE_FLG_" & CStr(intRow + 1)), JPG.Common.Controls.CTLCombo)

                    objKMCD.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("KMCD"))
                    objKMNM.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("KMNM"))
                    objTKTANCD.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("TKTANCD"))
                    objTEL_MEMO1.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("TEL_MEMO1"))
                    objBIKO.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("BIKO"))
                    objINS_DATE.Value = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("INS_DATE"))
                    objUPD_DATE.Value = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("UPD_DATE"))

                    'objPROCKBN.SelectedIndex = Convert.ToInt32(dbData.Tables(0).Rows(intRow).Item("PROCKBN"))
                    'objTAIOKBN.SelectedIndex = Convert.ToInt32(dbData.Tables(0).Rows(intRow).Item("TAIOKBN"))
                    'objTMSKB.SelectedIndex = Convert.ToInt32(dbData.Tables(0).Rows(intRow).Item("TMSKB"))
                    'objTAITCD.SelectedIndex = Convert.ToInt32(dbData.Tables(0).Rows(intRow).Item("TAITCD"))
                    'objTFKICD.SelectedIndex = Convert.ToInt32(dbData.Tables(0).Rows(intRow).Item("TFKICD"))
                    'objTKIGCD.SelectedIndex = Convert.ToInt32(dbData.Tables(0).Rows(intRow).Item("TKIGCD"))
                    'objTSADCD.SelectedIndex = Convert.ToInt32(dbData.Tables(0).Rows(intRow).Item("TSADCD"))
                    'objTELRCD.SelectedIndex = Convert.ToInt32(dbData.Tables(0).Rows(intRow).Item("TELRCD"))
                    'objUSE_FLG.SelectedIndex = Convert.ToInt32(dbData.Tables(0).Rows(intRow).Item("USE_FLG"))


                    strCBO_PROCKBN(intRow + 1) = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("PROCKBN"))
                    strCBO_TAIOKBN(intRow + 1) = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("TAIOKBN"))
                    strCBO_TMSKB(intRow + 1) = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("TMSKB"))
                    strCBO_TAITCD(intRow + 1) = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("TAITCD"))
                    strCBO_TFKICD(intRow + 1) = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("TFKICD"))
                    strCBO_TKIGCD(intRow + 1) = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("TKIGCD"))
                    strCBO_TSADCD(intRow + 1) = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("TSADCD"))
                    strCBO_TELRCD(intRow + 1) = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("TELRCD"))
                    strCBO_USE_FLG(intRow + 1) = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("USE_FLG"))

                    fncComboSet(intRow + 1)
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

        Catch ex As Exception
            strRec = ex.ToString
            Dim ErrMsgC As New CErrMsg
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
        '値を配列にセット
        Dim objKMCD As System.Web.UI.WebControls.TextBox
        Dim objKMNM As System.Web.UI.WebControls.TextBox
        Dim objTKTANCD As System.Web.UI.WebControls.TextBox
        Dim objTEL_MEMO1 As System.Web.UI.WebControls.TextBox
        Dim objBIKO As System.Web.UI.WebControls.TextBox
        Dim objINS_DATE As System.Web.UI.HtmlControls.HtmlInputHidden
        Dim objUPD_DATE As System.Web.UI.HtmlControls.HtmlInputHidden
        Dim objDEL As System.Web.UI.WebControls.CheckBox

        Dim sKMCD(30) As String
        Dim sKMNM(30) As String
        Dim sPROCKBN(30) As String
        Dim sTAIOKBN(30) As String
        Dim sTMSKB(30) As String
        Dim sTKTANCD(30) As String
        Dim sTAITCD(30) As String
        Dim sTFKICD(30) As String
        Dim sTKIGCD(30) As String
        Dim sTSADCD(30) As String
        Dim sTELRCD(30) As String
        Dim sTEL_MEMO1(30) As String
        Dim sUSE_FLG(30) As String
        Dim sINS_DATE(30) As String
        Dim sUPD_DATE(30) As String
        Dim sBIKO(30) As String
        Dim sDEL(30) As String

        Dim i As Integer
        '//------------------------------------------
        '<TODO>独自のWEBサービルを宣言する
        Dim MSJINJAW00C As New MSJINJAG00MSJINJAW00.MSJINJAW00

        '//-----------------------------------------------
        '<TODO>グループコード
        Dim strGROUPCD As String
        Dim bolCHKGROUPCD As Boolean = True 'True:OK False:NG
        Dim bolCHKJAGROUPCD As Boolean = True 'True:OK False:NG   '2017/02/09 W.GANEKO ADD 2016監視改善
        Dim bolCHKSTRGROUPCD As Boolean = True 'True:OK False:NG   '2017/02/09 W.GANEKO ADD 2016監視改善
        Dim strGROUPCDNM As String
        If pstrKBN = "1" AndAlso txtGROUPCD_NEW.Text.Trim <> "" Then
            'グループコードの新規登録
            bolCHKGROUPCD = fncchkGROUPCD(txtGROUPCD_NEW.Text.Trim) '入力したグループコードが既にある場合はNG
            bolCHKSTRGROUPCD = fncCHKSTRGROUPCD(txtGROUPCD_NEW.Text.Trim) '2017/02/09 W.GANEKO ADD 2016監視改善
            strGROUPCD = txtGROUPCD_NEW.Text.Trim
            hdnGROUPCD.Value = txtGROUPCD_NEW.Text.Trim
            strGROUPCDNM = txtGROUPNM.Text.Trim     '2017/02/09 W.GANEKO ADD 2016監視改善
        Else
            'グループ登録選択
            'hdnGROUPCD.Value = Convert.ToString(cboGROUPCD.Items.Item(CInt(Request.Form("cboGROUPCD"))))
            '2017/02/09 W.GANEKO ADD 2016監視改善
            If pstrKBN = "4" Then
                bolCHKJAGROUPCD = fncchkJAGROUPCD(hdnGROUPCD.Value.Trim) '入力したJAグループコードが既にある場合はNG
            End If
            strGROUPCD = hdnGROUPCD.Value
            strGROUPCDNM = txtGROUPNM.Text.Trim  '2017/02/09 W.GANEKO ADD 2016監視改善
        End If

        If bolCHKGROUPCD = False Then
            '新規の場合。グループコードが既に存在する
            strRec = "4"
        ElseIf bolCHKSTRGROUPCD = False Then '2017/02/09 W.GANEKO ADD 2016監視改善
            '新規の場合。グループコードの頭2文字が違う
            strRec = "6"
        ElseIf pstrKBN = "4" AndAlso bolCHKJAGROUPCD = False AndAlso fncchkJAGROUPDEL(hdnGROUPCD.Value.Trim) = False Then '2017/03/09 T.Ono mod 2016監視改善
            'ElseIf pstrKBN = "4" AndAlso bolCHKJAGROUPCD = False Then '2017/02/09 W.GANEKO ADD 2016監視改善
            '削除の場合。JAグループコードが既に存在する
            strRec = "5"
        Else


            For i = 1 To 30
                'コントロール名を探し出し、型変換
                objKMCD = CType(FindControl("txtKMCD_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                objKMNM = CType(FindControl("txtKMNM_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                objTKTANCD = CType(FindControl("txtTKTANCD_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                objTEL_MEMO1 = CType(FindControl("txtTEL_MEMO1_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                objBIKO = CType(FindControl("txtBIKO_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                objINS_DATE = CType(FindControl("hdnINS_DATE_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
                objUPD_DATE = CType(FindControl("hdnUPD_DATE_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
                objDEL = CType(FindControl("chkDEL_" & CStr(i)), System.Web.UI.WebControls.CheckBox)

                sKMCD(i) = objKMCD.Text.Trim
                sKMNM(i) = objKMNM.Text.Trim
                sPROCKBN(i) = Request.Form("cboPROCKBN_" & i)
                sTAIOKBN(i) = Request.Form("cboTAIOKBN_" & i)
                sTMSKB(i) = Request.Form("cboTMSKB_" & i)
                sTAITCD(i) = Request.Form("cboTAITCD_" & i)
                sTFKICD(i) = Request.Form("cboTFKICD_" & i)
                sTKIGCD(i) = Request.Form("cboTKIGCD_" & i)
                sTSADCD(i) = Request.Form("cboTSADCD_" & i)
                sTELRCD(i) = Request.Form("cboTELRCD_" & i)
                sTEL_MEMO1(i) = objTEL_MEMO1.Text.Trim
                sUSE_FLG(i) = Request.Form("cboUSE_FLG_" & i)
                sINS_DATE(i) = objINS_DATE.Value.Trim
                sUPD_DATE(i) = objUPD_DATE.Value.Trim
                sBIKO(i) = objBIKO.Text.Trim

                '担当者コード　自動対応で担当者コード空白の場合は"999"をセット
                If sPROCKBN(i) = "1" AndAlso objTKTANCD.Text.Trim = "" Then
                    sTKTANCD(i) = "999"
                Else
                    sTKTANCD(i) = objTKTANCD.Text.Trim
                End If

                If (objDEL.Checked) Then
                    sDEL(i) = "true"
                Else
                    sDEL(i) = "false"
                End If

            Next
            '2017/02/09 W.GANEKO UPD 2016監視改善
            'strRec = MSJINJAW00C.mSetEx( _
            '            CInt(pstrKBN), _
            '            strGROUPCD, _
            '            sKMCD, _
            '            sKMNM, _
            '            sPROCKBN, _
            '            sTAIOKBN, _
            '            sTMSKB, _
            '            sTKTANCD, _
            '            sTAITCD, _
            '            sTFKICD, _
            '            sTKIGCD, _
            '            sTSADCD, _
            '            sTELRCD, _
            '            sTEL_MEMO1, _
            '            sUSE_FLG, _
            '            sINS_DATE, _
            '            sUPD_DATE, _
            '            sBIKO, _
            '            sDEL)
            strRec = MSJINJAW00C.mSetEx( _
                         CInt(pstrKBN), _
                         strGROUPCD, _
                         sKMCD, _
                         sKMNM, _
                         sPROCKBN, _
                         sTAIOKBN, _
                         sTMSKB, _
                         sTKTANCD, _
                         sTAITCD, _
                         sTFKICD, _
                         sTKIGCD, _
                         sTSADCD, _
                         sTELRCD, _
                         sTEL_MEMO1, _
                         sUSE_FLG, _
                         sINS_DATE, _
                         sUPD_DATE, _
                         sBIKO, _
                         sDEL, _
                         strGROUPCDNM _
                         )
        End If


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
                strMsg.Append("alert('正常に終了しました');")

                If pstrKBN = "1" Or pstrKBN = "2" Then
                    strRec = fncbtnKensaku_ClickEvent("2")
                Else
                    strRec = fncbtnKensaku_ClickEvent("2")
                End If
                '<TODO>フォーカスをセットする（検索ボタンにセット）
                strMsg.Append("Form1.btnSelect.focus();")
                '//------------------------------

            Case "0"
                strRecMsg = "他のユーザーによってデータが更新されています。再度検索してください"
                strMsg.Append("alert('" & strRecMsg & "');")

                '//------------------------------
                '<TODO>フォーカスをセットする（修正時でのエラー。検索ボタンにセット）
                strMsg.Append("Form1.btnSelect.focus();")
                strRec = strRecMsg
            Case "1"
                'strRecMsg = "既にデータが存在します"
                strRecMsg = "既にグループコードが存在します"
                strMsg.Append("alert('" & strRecMsg & "');")

                '//------------------------------
                strRec = strRecMsg
            Case "2"
                strRecMsg = "対象データが存在しません"
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
                strRecMsg = "既にグループコードが存在します"
                strMsg.Append("alert('" & strRecMsg & "');")

                '<TODO>フォーカスをセットする（登録・修正時でのエラー。新規登録用入力欄にセット）
                strMsg.Append("Form1.txtGROUPCD_NEW.focus();")

                strRec = strRecMsg
            Case "5"
                '2017/02/09 W.GANEKO ADD 2016監視改善
                strRecMsg = "JAグループ作成マスタで使用されているデータがあります。\nデータを確認して下さい。"
                strMsg.Append("alert('" & strRecMsg & "');")

                '<TODO>フォーカスをセットする（登録・修正時でのエラー。新規登録用入力欄にセット）
                strMsg.Append("Form1.btnSelect.focus();")

                strRec = strRecMsg
            Case "6"
                '2017/02/09 W.GANEKO ADD 2016監視改善
                strRecMsg = "グループコードが不正です。\n先頭に所定のアルファベット2文字を入力してください。"
                strMsg.Append("alert('" & strRecMsg & "');")

                '<TODO>フォーカスをセットする（登録・修正時でのエラー。新規登録用入力欄にセット）
                strMsg.Append("Form1.btnSelect.focus();")

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
                    strMsg.Append("Form1.txtKMCD_1.focus();")
                Else
                    '//----------------------------------
                    '<TODO>フォーカスをセットする（その他　：ログ出力のエラーの為キー以降にセット）
                    strMsg.Append("Form1.txtKMCD_1.focus();")
                End If
        End Select
        If pstrKBN <> "1" Then
            For i = 1 To 30
                objKMCD = CType(FindControl("txtKMCD_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                objKMNM = CType(FindControl("txtKMNM_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                If objKMCD.Text <> "" Then
                    objKMCD.ReadOnly = True
                    objKMCD.BackColor = Color.Gainsboro
                    objKMNM.ReadOnly = True
                    objKMNM.BackColor = Color.Gainsboro
                End If
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

    ' 2023/02/07 ADD START Y.ARAKAKI 2022更改No⑤ _自動対応内容マスタ_特定警報Noの使用フラグ一括設定追加対応
    '******************************************************************************
    '* 登録・削除が押下されたときの処理
    '******************************************************************************
    Private Function fncbtnUpdFromTo_ClickEvent(ByVal updKbn As String) As String
        Dim strRec As String
        strRec = "OK" '初期値：更新OK　後続でエラー等あれば上書きされる。

        '//ＡＰログ書き込み (S03_APLOGDBに、今回実行結果のログを書き込む。実行区分は２：修正で扱うことにする。)
        Dim LogC As New CLog
        Dim strRecLog As String
        Dim pstrKBN As String
        pstrKBN = "2" ' これの正体→実行区分。 S03_APLOGDB.EXEC_STATUS → 【実行区分】１：登録　２：修正　３：削除　４：照会（一覧出力）

        Dim groupCdFromValue As String  '画面：グループコード（FROM)
        Dim groupCdToValue As String    '画面：グループコード（TO)
        '画面より値を取得(JSチェックしてるので、必ず値ある、なおかつFROM-TO間の指定範囲は正しい前提。)
        groupCdFromValue = Request.Form("cboJTLISTFROM")
        groupCdToValue = Request.Form("cboJTLISTTO")

        Dim ds As New DataSet
        Dim cdb As New CDB
        Dim strSQL As StringBuilder

        Try
            '接続OPEN----------------------------------------
            cdb.mOpen()
            'トランザクション開始--------------------------
            cdb.mBeginTrans()

            '1.更新前検索（排他ロック）
            strSQL = New StringBuilder("")
            strSQL.Append("SELECT ")
            strSQL.Append(" 	    A.USE_FLG ")
            strSQL.Append(" 	    ,A.UPD_DATE ")
            strSQL.Append("FROM ")
            strSQL.Append("		M08_AUTOTAIOU A ")
            strSQL.Append("WHERE ")
            strSQL.Append("		A.GROUPCD BETWEEN :GRPCDFROM AND :GRPCDTO ")
            strSQL.Append("AND		A.KMCD IN  ('08','15') ")
            strSQL.Append("ORDER BY A.GROUPCD, A.KMCD ")
            strSQL.Append("FOR UPDATE NOWAIT ")             '排他制御をかける

            'SQL文セット
            cdb.pSQL = strSQL.ToString
            'パラメータに値をセット
            cdb.pSQLParamStr("GRPCDFROM") = groupCdFromValue  'グループコード(FROM)
            cdb.pSQLParamStr("GRPCDTO") = groupCdToValue      'グループコード(TO)

            'SQL実行
            cdb.mExecQuery()
            ds = cdb.pResult

            If (ds.Tables(0).Rows.Count <> 0) Then 'ＤＢにデータが存在する？
                '2.更新処理、実施。
                strSQL = New StringBuilder("")
                strSQL.Append("UPDATE ")
                strSQL.Append("         M08_AUTOTAIOU ")
                strSQL.Append("SET ")
                strSQL.Append("     	USE_FLG = :USE_FLG, ")
                strSQL.Append("     	UPD_DATE = TO_DATE(:UPD_DATE, 'YYYY/MM/DD HH24:MI:SS') ")
                strSQL.Append("WHERE   ")
                strSQL.Append("		GROUPCD BETWEEN :GRPCDFROM AND :GRPCDTO ")
                strSQL.Append("     AND KMCD IN  ('08','15') ") '警報メッセージNo…固定値 08：感震器遮断、15：安全確認中遮断

                'SQL文セット
                cdb.pSQL = strSQL.ToString

                'パラメータに値をセット
                '画面のボタン押下によって、使用フラグの値を変更する。
                If updKbn = "1" Then '使用可ボタン押下時→使用フラグを 1:使用可能 とする。
                    cdb.pSQLParamStr("USE_FLG") = "1"  '使用フラグ    1:使用可能  0:使用不可
                ElseIf updKbn = "2" Then '使用不可ボタン押下時→使用フラグを 0:使用不可 とする。
                    cdb.pSQLParamStr("USE_FLG") = "0"  '使用フラグ    1:使用可能  0:使用不可
                End If
                cdb.pSQLParamStr("UPD_DATE") = Now.ToString()  'システム日付
                cdb.pSQLParamStr("GRPCDFROM") = groupCdFromValue  'グループコード(FROM)
                cdb.pSQLParamStr("GRPCDTO") = groupCdToValue      'グループコード(TO)

                'SQLを実行(更新)
                cdb.mExecNonQuery()

            End If

            'コミット
            cdb.mCommit()

            strMsg.Append("alert('正常に終了しました');")
            strMsg.Append("Form1.btnSelect.focus();") '<TODO>フォーカスをセットする（検索ボタンにセット）

        Catch ex As Exception

            '排他制御処理エラー
            If ErrorToString.Substring(0, 9) = "ORA-00054" Then
                strRec = "排他制御処理でエラーが発生しました。再度実行してください"
                strMsg.Append("alert('" & strRec & "');")

                'エラーログをログDBに登録
                strRecLog = LogC.mAPLog(Me.Session.SessionID, AuthC.pUSERNAME, AuthC.pIPADDRESS, hdnMyAspx.Value, pstrKBN, strRec, Request.Form)

                If strRecLog <> "OK" Then
                    Dim errmsgc As New CErrMsg
                    strMsg.Append("alert('システムエラー：" & errmsgc.mGetArtMsg(strRecLog) & "');")
                End If

                Return "3"
            End If
            'エラーが起きたら エラー内容を格納
            strRec = "システムエラー：" & ex.ToString

            strMsg.Append("alert('" & strRec & "');")
            '<TODO>フォーカスをセットする（登録・修正・削除時でのエラー。終了ボタンにセット）
            strMsg.Append("Form1.btnExit.focus();")

            'ロールバック
            cdb.mRollback()
            strRec = strRec & cdb.pErr
        Finally
            '接続クローズ
            cdb.mClose()
        End Try

        cdb = Nothing

        'ログ書込
        strRecLog = LogC.mAPLog(Me.Session.SessionID, AuthC.pUSERNAME, AuthC.pIPADDRESS, hdnMyAspx.Value, pstrKBN, strRec, Request.Form)

        If strRecLog <> "OK" Then
            Dim errmsgc As New CErrMsg
            strMsg.Append("alert('システムエラー：" & errmsgc.mGetArtMsg(strRecLog) & "');")
        End If

        '(グループCDが選択されている場合のみ)検索処理実施。２：登録or更新処理後の検索 
        If hdnGROUPCD.Value.Trim.Length > 0 Then
            fncbtnKensaku_ClickEvent("2")
        End If

        Return strRec
    End Function
    ' 2023/02/07 ADD END   Y.ARAKAKI 2022更改No⑤ _自動対応内容マスタ_特定警報Noの使用フラグ一括設定追加対応

    '******************************************************************************
    '* 入力キーによるデータの検索を行います。
    '******************************************************************************
    Private Function fncDataSelect() As DataSet

        '//------------------------------------------
        '//<TODO>Select文の作成
        Dim SQLC As New MSJINJAG00CCSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet

        strSQL.Append("SELECT  ")
        strSQL.Append("	    A.GROUPCD ")
        strSQL.Append("	    ,A.KMCD ")
        strSQL.Append("	    ,A.KMNM ")
        strSQL.Append("	    ,A.PROCKBN ")
        strSQL.Append("	    ,A.TAIOKBN ")
        strSQL.Append("	    ,A.TMSKB ")
        strSQL.Append("	    ,A.TKTANCD ")
        strSQL.Append("	    ,A.TAITCD ")
        strSQL.Append("	    ,A.TFKICD ")
        strSQL.Append("	    ,A.TKIGCD ")
        strSQL.Append("	    ,A.TSADCD ")
        strSQL.Append("	    ,A.TELRCD ")
        strSQL.Append("	    ,A.TEL_MEMO1 ")
        strSQL.Append("	    ,A.USE_FLG ")
        strSQL.Append("	    ,A.INS_DATE ")
        strSQL.Append("	    ,A.UPD_DATE ")
        strSQL.Append("	,   A.BIKO ")
        strSQL.Append("	,   A.GROUPNM ")     '2017/02/09 W.GANEKO ADD 2016監視改善 №10
        strSQL.Append("FROM ")
        strSQL.Append("	    M08_AUTOTAIOU A ")
        strSQL.Append("WHERE ")
        strSQL.Append("     GROUPCD = :GROUPCD ")
        strSQL.Append("ORDER BY KMCD ")


        'グループコード
        If hdnGROUPCD.Value.Trim.Length > 0 Then
            SqlParamC.fncSetParam("GROUPCD", True, hdnGROUPCD.Value.Trim)
        End If

        dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

        Return dbData
    End Function
    '******************************************************************************
    ' Excel出力(チェックつき)
    '******************************************************************************
    Private Sub btnCSVout_ServerClick(ByVal sender As System.Object, _
                                    ByVal e As System.EventArgs) Handles btnCSVout.ServerClick
        Dim strRec As String
        Dim MSJINJAW00C As New MSJINJAG00MSJINJAW00.MSJINJAW00

        '//　認証クラスのインスタンス生成
        AuthC = New CAuthenticate(Request, Response)

        Dim strRecMsg As String = ""

        'キーを格納
        'hdnGROUPCD.Value = Convert.ToString(cboGROUPCD.Items.Item(CInt(Request.Form("cboGROUPCD"))))

        strRec = MSJINJAW00C.mCSV( _
                         Me.Session.SessionID, _
                         hdnGROUPCD.Value _
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
            'ファイル名は、HttpUtility.UrlEncodeメソッドを使用してSJISにエンコードする必要がある
            HttpHeaderC.mDownLoadCSV(Response, "自動対応内容マスタ.csv")
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

    '**************************************************
    '* コンボボックスの選択
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
    '**************************************************
    Private Sub fncComboGet(ByVal i As Integer)
        Dim obj As JPG.Common.Controls.CTLCombo

        obj = CType(FindControl("cboPROCKBN_" & CStr(i)), JPG.Common.Controls.CTLCombo)
        strCBO_PROCKBN(i) = Request.Form(obj.ID)

        obj = CType(FindControl("cboTAIOKBN_" & CStr(i)), JPG.Common.Controls.CTLCombo)
        strCBO_TAIOKBN(i) = Request.Form(obj.ID)

        obj = CType(FindControl("cboTMSKB_" & CStr(i)), JPG.Common.Controls.CTLCombo)
        strCBO_TMSKB(i) = Request.Form(obj.ID)

        obj = CType(FindControl("cboTAITCD_" & CStr(i)), JPG.Common.Controls.CTLCombo)
        strCBO_TAITCD(i) = Request.Form(obj.ID)

        obj = CType(FindControl("cboTFKICD_" & CStr(i)), JPG.Common.Controls.CTLCombo)
        strCBO_TFKICD(i) = Request.Form(obj.ID)

        obj = CType(FindControl("cboTKIGCD_" & CStr(i)), JPG.Common.Controls.CTLCombo)
        strCBO_TKIGCD(i) = Request.Form(obj.ID)

        obj = CType(FindControl("cboTSADCD_" & CStr(i)), JPG.Common.Controls.CTLCombo)
        strCBO_TSADCD(i) = Request.Form(obj.ID)

        obj = CType(FindControl("cboTELRCD_" & CStr(i)), JPG.Common.Controls.CTLCombo)
        strCBO_TELRCD(i) = Request.Form(obj.ID)

        obj = CType(FindControl("cboUSE_FLG_" & CStr(i)), JPG.Common.Controls.CTLCombo)
        strCBO_USE_FLG(i) = Request.Form(obj.ID)

    End Sub

    '******************************************************************************
    '*　概　要：コンボボックスの選択
    '*　備　考：
    '******************************************************************************
    Private Sub fncComboSet(ByVal i As Integer)
        Dim obj As JPG.Common.Controls.CTLCombo
        Dim list As New ListItem

        If strCBO_PROCKBN(i) <> "" Then
            obj = CType(FindControl("cboPROCKBN_" & CStr(i)), JPG.Common.Controls.CTLCombo)
            list = obj.Items.FindByValue(strCBO_PROCKBN(i))
            obj.SelectedIndex = obj.Items.IndexOf(list)
        End If

        If strCBO_TAIOKBN(i) <> "" Then
            obj = CType(FindControl("cboTAIOKBN_" & CStr(i)), JPG.Common.Controls.CTLCombo)
            list = obj.Items.FindByValue(strCBO_TAIOKBN(i))
            obj.SelectedIndex = obj.Items.IndexOf(list)
        End If

        If strCBO_TMSKB(i) <> "" Then
            obj = CType(FindControl("cboTMSKB_" & CStr(i)), JPG.Common.Controls.CTLCombo)
            list = obj.Items.FindByValue(strCBO_TMSKB(i))
            obj.SelectedIndex = obj.Items.IndexOf(list)
        End If

        If strCBO_TAITCD(i) <> "" Then
            obj = CType(FindControl("cboTAITCD_" & CStr(i)), JPG.Common.Controls.CTLCombo)
            list = obj.Items.FindByValue(strCBO_TAITCD(i))
            obj.SelectedIndex = obj.Items.IndexOf(list)
        End If

        If strCBO_TFKICD(i) <> "" Then
            obj = CType(FindControl("cboTFKICD_" & CStr(i)), JPG.Common.Controls.CTLCombo)
            list = obj.Items.FindByValue(strCBO_TFKICD(i))
            obj.SelectedIndex = obj.Items.IndexOf(list)
        End If

        If strCBO_TKIGCD(i) <> "" Then
            obj = CType(FindControl("cboTKIGCD_" & CStr(i)), JPG.Common.Controls.CTLCombo)
            list = obj.Items.FindByValue(strCBO_TKIGCD(i))
            obj.SelectedIndex = obj.Items.IndexOf(list)
        End If

        If strCBO_TSADCD(i) <> "" Then
            obj = CType(FindControl("cboTSADCD_" & CStr(i)), JPG.Common.Controls.CTLCombo)
            list = obj.Items.FindByValue(strCBO_TSADCD(i))
            obj.SelectedIndex = obj.Items.IndexOf(list)
        End If

        If strCBO_TELRCD(i) <> "" Then
            obj = CType(FindControl("cboTELRCD_" & CStr(i)), JPG.Common.Controls.CTLCombo)
            list = obj.Items.FindByValue(strCBO_TELRCD(i))
            obj.SelectedIndex = obj.Items.IndexOf(list)
        End If

        If strCBO_USE_FLG(i) <> "" Then
            obj = CType(FindControl("cboUSE_FLG_" & CStr(i)), JPG.Common.Controls.CTLCombo)
            list = obj.Items.FindByValue(strCBO_USE_FLG(i))
            obj.SelectedIndex = obj.Items.IndexOf(list)
        End If

    End Sub

    ' 2023/02/07 ADD START Y.ARAKAKI 2022更改No⑤ _自動対応内容マスタ_特定警報Noの使用フラグ一括設定追加対応
    '**************************************************
    '* コンボボックスの入力値取得＋設定(グループコードFromTo) '画面の値保持用に使用。
    '**************************************************
    Private Sub fncComboGetAndSet_FromTo()
        Dim objFrom As JPG.Common.Controls.CTLCombo
        Dim objTo As JPG.Common.Controls.CTLCombo

        '画面の値保持
        objFrom = CType(FindControl("cboJTLISTFROM"), JPG.Common.Controls.CTLCombo)
        objTo = CType(FindControl("cboJTLISTTO"), JPG.Common.Controls.CTLCombo)
        strCBO_JTLISTFROM = Request.Form(objFrom.ID)
        strCBO_JTLISTTO = Request.Form(objTo.ID)

        'もし画面の値保持があれば、復元する。
        Dim listFrom As New ListItem
        Dim listTo As New ListItem
        If strCBO_JTLISTFROM <> "" Then
            listFrom = objFrom.Items.FindByValue(strCBO_JTLISTFROM)
            objFrom.SelectedIndex = objFrom.Items.IndexOf(listFrom)
        End If
        If strCBO_JTLISTTO <> "" Then
            listTo = objTo.Items.FindByValue(strCBO_JTLISTTO)
            objTo.SelectedIndex = objTo.Items.IndexOf(listTo)
        End If
    End Sub
    ' 2023/02/07 ADD END   Y.ARAKAKI 2022更改No⑤ _自動対応内容マスタ_特定警報Noの使用フラグ一括設定追加対応

    '2017/02/09 W.GANEKO DEL 2016監視改善 №10
    'グループコード（KEY）
    'Private Sub fncCombo_Create_GROUPCD()

    '    cboGROUPCD.Items.Clear()

    '    Dim dbData As DataSet
    '    dbData = fncGET_GROUPCD()

    '    If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
    '        cboGROUPCD.Items.Add(New ListItem("", ""))
    '    Else
    '        Dim intRow As Integer
    '        cboGROUPCD.Items.Add(New ListItem("", ""))
    '        For intRow = 0 To dbData.Tables(0).Rows.Count - 1
    '            cboGROUPCD.Items.Add(New ListItem(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("GROUPCD")), CStr(intRow + 1)))
    '        Next
    '    End If

    'End Sub
    '対応／対応無視区分
    Private Sub fncCombo_Create_PROCKBN(ByVal i As Integer)
        Dim objPROCKBN As JPG.Common.Controls.CTLCombo
        objPROCKBN = CType(FindControl("cboPROCKBN_" & CStr(i)), JPG.Common.Controls.CTLCombo)
        objPROCKBN.Items.Clear()
        objPROCKBN.Items.Add(New ListItem("", ""))
        objPROCKBN.Items.Add(New ListItem("1：自動対応", "1"))
        objPROCKBN.Items.Add(New ListItem("2：無視", "2"))
        objPROCKBN.Items.Add(New ListItem("3：無視（セキュリティ情報参照）", "3"))
        objPROCKBN.Items.Add(New ListItem("4：重複表示", "4"))
    End Sub
    '対応区分
    Private Sub fncCombo_Create_TAIOKBN(ByVal i As Integer)
        Dim objTAIOKBN As JPG.Common.Controls.CTLCombo
        objTAIOKBN = CType(FindControl("cboTAIOKBN_" & CStr(i)), JPG.Common.Controls.CTLCombo)
        objTAIOKBN.pComboTitle = True
        objTAIOKBN.pNoData = False
        objTAIOKBN.pType = "TAIOUKBN"               '//対応区分
        objTAIOKBN.mMakeCombo()
    End Sub
    '処理区分
    Private Sub fncCombo_Create_TMSKB(ByVal i As Integer)
        Dim objTMSKB As JPG.Common.Controls.CTLCombo
        objTMSKB = CType(FindControl("cboTMSKB_" & CStr(i)), JPG.Common.Controls.CTLCombo)
        objTMSKB.pComboTitle = True
        objTMSKB.pNoData = False
        objTMSKB.pType = "SYORIKBN"               '//処理区分
        objTMSKB.mMakeCombo()
    End Sub
    '連絡相手
    Private Sub fncCombo_Create_TAITCD(ByVal i As Integer)
        Dim objTAITCD As JPG.Common.Controls.CTLCombo
        objTAITCD = CType(FindControl("cboTAITCD_" & CStr(i)), JPG.Common.Controls.CTLCombo)
        objTAITCD.pComboTitle = True
        objTAITCD.pNoData = False
        objTAITCD.pType = "RENRAKUA"               '//連絡相手
        objTAITCD.mMakeCombo()
    End Sub
    '復帰対応状況
    Private Sub fncCombo_Create_TFKICD(ByVal i As Integer)
        Dim objTFKICD As JPG.Common.Controls.CTLCombo
        objTFKICD = CType(FindControl("cboTFKICD_" & CStr(i)), JPG.Common.Controls.CTLCombo)
        objTFKICD.pComboTitle = True
        objTFKICD.pNoData = False
        objTFKICD.pType = "HUKKITAI"               '//復帰対応状況
        objTFKICD.mMakeCombo()
    End Sub
    'ガス器具
    Private Sub fncCombo_Create_TKIGCD(ByVal i As Integer)
        Dim objTKIGCD As JPG.Common.Controls.CTLCombo
        objTKIGCD = CType(FindControl("cboTKIGCD_" & CStr(i)), JPG.Common.Controls.CTLCombo)
        objTKIGCD.pComboTitle = True
        objTKIGCD.pNoData = False
        objTKIGCD.pType = "GAKUKIGU"               '//ガス器具
        objTKIGCD.mMakeCombo()
    End Sub
    '作動原因
    Private Sub fncCombo_Create_TSADCD(ByVal i As Integer)
        Dim objTSADCD As JPG.Common.Controls.CTLCombo
        objTSADCD = CType(FindControl("cboTSADCD_" & CStr(i)), JPG.Common.Controls.CTLCombo)
        objTSADCD.pComboTitle = True
        objTSADCD.pNoData = False
        objTSADCD.pType = "SADOUGEN"               '//作動原因
        objTSADCD.mMakeCombo()
    End Sub
    '電話連絡内容
    Private Sub fncCombo_Create_TELRCD(ByVal i As Integer)
        Dim objTELRCD As JPG.Common.Controls.CTLCombo
        objTELRCD = CType(FindControl("cboTELRCD_" & CStr(i)), JPG.Common.Controls.CTLCombo)
        objTELRCD.pComboTitle = True
        objTELRCD.pNoData = False
        objTELRCD.pType = "DENWAREN"               '//電話連絡内容
        objTELRCD.mMakeCombo()
    End Sub
    '使用フラグ
    Private Sub fncCombo_Create_USE_FLG(ByVal i As Integer)
        Dim objUSE_FLG As JPG.Common.Controls.CTLCombo
        objUSE_FLG = CType(FindControl("cboUSE_FLG_" & CStr(i)), JPG.Common.Controls.CTLCombo)
        objUSE_FLG.Items.Clear()
        objUSE_FLG.Items.Add(New ListItem("0：使用不可", "0"))
        objUSE_FLG.Items.Add(New ListItem("1：使用可", "1"))
        objUSE_FLG.SelectedIndex = 1
    End Sub

    ' 2023/01/26 ADD START Y.ARAKAKI 2022更改No⑤ _自動対応内容マスタ_特定警報Noの使用フラグ一括設定追加対応
    '******************************************************************************
    '*グループコード（自動対応From-To）_画面リストボックス用_一覧取得
    '*  ※From-To、まとめて２リスト分のレコードを取得、設定する。
    '******************************************************************************
    Private Sub fncCombo_Create_JidouTaiouGroupList()
        '全項目検索用
        Dim strSQL1 As New StringBuilder("")
        Dim dbData1 As DataSet
        Dim cdb As New CDB
        'DB処理共通
        Dim i As Integer

        '検索処理開始
        cdb.mOpen()
        strSQL1.Append("SELECT ")
        strSQL1.Append(" M8.GROUPCD AS CD ")
        strSQL1.Append(" ,M8.GROUPCD || '：' || M8.GROUPNM AS NAME ")
        strSQL1.Append("FROM ")
        strSQL1.Append(" M08_AUTOTAIOU M8 ")
        strSQL1.Append("WHERE ")
        strSQL1.Append(" M8.KMCD IN ('08','15') ")
        strSQL1.Append("GROUP BY M8.GROUPCD,M8.GROUPNM ")
        strSQL1.Append("ORDER BY M8.GROUPCD,M8.GROUPNM ")

        cdb.pSQL = strSQL1.ToString
        'cdb.pSQLParamStr(":条件名 の条件名のみ指定") = "条件内容"  '※今回は条件指定なしの為、ここは不要でコメントアウト。
        cdb.mExecQuery()
        dbData1 = cdb.pResult     '結果をデータセット格納
        cdb.mClose()
        cdb = Nothing



        'ここが共通処理と違うやりたいこと。：リスト内容を設定しつつ、全項目(編集用バックアップ)を画面jsリストに設定。
        cboJTLISTFROM.Items.Add(New ListItem("", "")) 'リスト編集1行目は空行を設定。
        cboJTLISTTO.Items.Add(New ListItem("", "")) 'リスト編集1行目は空行を設定。
        If dbData1.Tables(0).Rows.Count > 0 Then
            For i = 0 To dbData1.Tables(0).Rows.Count - 1

                '動作確認して問題なければこの不要行削除↓
                'strMsg.Append("var item = {val:'" + Convert.ToString(dbData1.Tables(0).Rows(i).Item(0)) + "',txt:'" + Convert.ToString(dbData1.Tables(0).Rows(i).Item(1)) + "'};")
                'strMsg.Append("listcboTKIGCD.push(item);")

                'コンボに追加
                cboJTLISTFROM.Items.Add(New ListItem(Convert.ToString(dbData1.Tables(0).Rows(i).Item(1)),
                  Convert.ToString(dbData1.Tables(0).Rows(i).Item(0))))
                cboJTLISTTO.Items.Add(New ListItem(Convert.ToString(dbData1.Tables(0).Rows(i).Item(1)),
                  Convert.ToString(dbData1.Tables(0).Rows(i).Item(0))))
            Next
        End If

    End Sub
    ' 2023/01/26 ADD END   Y.ARAKAKI 2022更改No⑤ _自動対応内容マスタ_特定警報Noの使用フラグ一括設定追加対応

    '******************************************************************************
    '*グループコードの一覧取得
    '******************************************************************************
    Private Function fncGET_GROUPCD() As DataSet

        '//------------------------------------------
        '//<TODO>Select文の作成
        Dim SQLC As New MSJINJAG00CCSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet

        'strSQL.Append("SELECT ")
        'strSQL.Append("		A.GROUPCD ")
        'strSQL.Append("FROM ")
        'strSQL.Append("		M08_AUTOTAIOU A ")
        'strSQL.Append("GROUP BY A.GROUPCD ")
        'strSQL.Append("ORDER BY A.GROUPCD ")
        strSQL.Append("SELECT ")
        strSQL.Append("		A.GROUPCD ")
        strSQL.Append("FROM ")
        strSQL.Append("		M08_AUTOTAIOU A ")
        strSQL.Append("GROUP BY A.GROUPCD ")
        'strSQL.Append("UNION ")
        'strSQL.Append("SELECT ")
        'strSQL.Append("		B.GROUPCD ")
        'strSQL.Append("FROM ")
        'strSQL.Append("		M07_AUTOTAIOUGROUP B ")
        'strSQL.Append("GROUP BY B.GROUPCD ")
        'strSQL.Append("ORDER BY GROUPCD ")

        dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

        Return dbData
    End Function

    '******************************************************************************
    '*グループコードの重複チェック　True：重複なし　False：重複ありNG
    '******************************************************************************
    Private Function fncchkGROUPCD(ByVal groupcd As String) As Boolean

        Dim res As Boolean = False

        '//------------------------------------------
        '//<TODO>Select文の作成
        Dim SQLC As New MSJINJAG00CCSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet

        strSQL.Append("SELECT ")
        strSQL.Append("		A.GROUPCD ")
        strSQL.Append("FROM ")
        strSQL.Append("		M08_AUTOTAIOU A ")
        strSQL.Append("WHERE ")
        strSQL.Append("		A.GROUPCD = :GROUPCD ")
        strSQL.Append("GROUP BY A.GROUPCD ")
        '2017/02/09 W.GANEKO DEL START 2016監視改善 №10
        'strSQL.Append("UNION ")
        'strSQL.Append("SELECT ")
        'strSQL.Append("		B.GROUPCD ")
        'strSQL.Append("FROM ")
        'strSQL.Append("		M07_AUTOTAIOUGROUP B ")
        'strSQL.Append("WHERE ")
        'strSQL.Append("		B.GROUPCD = :GROUPCD ")
        'strSQL.Append("GROUP BY B.GROUPCD ")
        'strSQL.Append("ORDER BY GROUPCD ")
        '2017/02/09 W.GANEKO DEL END 2016監視改善 №10

        SqlParamC.fncSetParam("GROUPCD", True, groupcd.Trim)

        dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)


        If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
            res = True
        Else
            res = False
        End If

        Return res
    End Function
    '2017/02/09 W.GANEKO ADD START 2016監視改善 №10
    '******************************************************************************
    '*グループコードの先頭文字チェック　True：重複なし　False：重複ありNG
    '******************************************************************************
    Private Function fncCHKSTRGROUPCD(ByVal groupcd As String) As Boolean

        Dim res As Boolean = False

        '//------------------------------------------
        '//<TODO>Select文の作成
        Dim SQLC As New MSJINJAG00CCSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet
        Dim KEY As String = ""
        strSQL.Append("SELECT ")
        strSQL.Append("		A.NAIYO1 ")
        strSQL.Append("FROM ")
        strSQL.Append("		M06_PULLDOWN A ")
        strSQL.Append("WHERE ")
        strSQL.Append("		A.KBN = '78' ")
        strSQL.Append("AND  A.CD = '003'  ")

        dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)


        If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
            res = False
        Else
            KEY = Convert.ToString(dbData.Tables(0).Rows(0).Item(0)).Trim
            If groupcd.Substring(0, 2) = KEY.Substring(0, 2) Then
                res = True
            Else
                res = False
            End If
        End If

        Return res
    End Function
    '******************************************************************************
    '*JAグループコードの重複チェック　True：重複なし　False：重複ありNG
    '******************************************************************************
    Private Function fncchkJAGROUPCD(ByVal groupcd As String) As Boolean

        Dim res As Boolean = False

        '//------------------------------------------
        '//<TODO>Select文の作成
        Dim SQLC As New MSJINJAG00CCSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet

        strSQL.Append("SELECT ")
        strSQL.Append("		A.GROUPCD ")
        strSQL.Append("FROM ")
        strSQL.Append("		M09_JAGROUP A ")
        strSQL.Append("WHERE ")
        strSQL.Append("		A.KBN = '003' ")
        strSQL.Append("AND  A.GROUPCD = :GROUPCD ")
        strSQL.Append("ORDER BY GROUPCD ")

        SqlParamC.fncSetParam("GROUPCD", True, groupcd.Trim)

        dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)


        If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
            res = True
        Else
            res = False
        End If

        Return res
    End Function
    '******************************************************************************
    '*　概　要：全件削除時のチェック　True：削除可　False：削除不可
    '*　備　考：JAグループ作成マスタに紐付がある場合、一行ごとの削除は可能とするが
    '*　　　　　グループ全件を削除することはできない
    '******************************************************************************
    Private Function fncchkJAGROUPDEL(ByVal groupcd As String) As Boolean

        Dim res As Boolean = False
        Dim objKMCD As System.Web.UI.WebControls.TextBox
        Dim objDEL As System.Web.UI.WebControls.CheckBox
        Dim DELCOUNT As Integer = 0
        Dim i As Integer

        '削除対象行をカウント
        For i = 1 To 30
            'コントロール名を探し出し、型変換
            objKMCD = CType(FindControl("txtKMCD_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objDEL = CType(FindControl("chkDEL_" & CStr(i)), System.Web.UI.WebControls.CheckBox)

            If objKMCD.Text.Trim.Length <> 0 AndAlso (objDEL.Checked) Then
                DELCOUNT += 1
            End If
        Next

        '対象グループの登録レコード数
        '//------------------------------------------
        '//<TODO>Select文の作成
        Dim SQLC As New MSJINJAG00CCSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet

        strSQL.Append("SELECT ")
        strSQL.Append("		COUNT(A.GROUPCD) ")
        strSQL.Append("FROM ")
        strSQL.Append("		M08_AUTOTAIOU A ")
        strSQL.Append("WHERE ")
        strSQL.Append("		A.GROUPCD = :GROUPCD ")
        strSQL.Append("ORDER BY GROUPCD ")

        SqlParamC.fncSetParam("GROUPCD", True, groupcd.Trim)

        dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)


        If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
            res = True
        Else
            If CStr(DELCOUNT) = Convert.ToString(dbData.Tables(0).Rows(0).Item(0)).Trim Then
                res = False
            Else
                res = True
            End If
        End If

        'strMsg.Append("alert('" & Convert.ToString(dbData.Tables(0).Rows(0).Item(0)).Trim & "');")
        Return res
    End Function

    Private Sub MSJINJAG00_AbortTransaction(sender As Object, e As EventArgs) Handles Me.AbortTransaction

    End Sub
    '******************************************************************************
    '*　概　要：絞込み条件を渡すプロパティ
    '*　備　考：抽出条件１の値を渡す
    '******************************************************************************
    Public ReadOnly Property pCode1() As String
        Get
            Dim strRec As String = ""
            strRec = AuthC.pAUTHCENTERCD    '//ＡＤ認証の使用可能監視センターコード
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：絞込み条件を渡すプロパティ
    '*　備　考：抽出条件２の値を渡す
    '******************************************************************************
    Public ReadOnly Property pCode2() As String
        Get
            Dim strRec As String = ""
 
            strRec = ""
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：出力する一覧の名前を渡すプロパティ
    '*　備　考：ポップアップのタイトル名を渡す
    '******************************************************************************
    Public ReadOnly Property pListName() As String
        Get
            Dim strRec As String = ""

            strRec = "自動対応内容グループ一覧" '自動対応グループマスタ
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：出力する一覧を制御する値を渡すプロパティ
    '*　備　考：ポップアップの種類を選択する
    '******************************************************************************
    Public ReadOnly Property pListCd() As String
        Get
            Dim strRec As String = ""
            strRec = "AUTOGROUP" '自動対応グループマスタ
            Return strRec
        End Get
    End Property


    '******************************************************************************
    '*　概　要：コードを返すオブジェクトの名前値を渡すプロパティ
    '*　備　考：データ選択後、コードを返すオブジェクト名を指定する
    '******************************************************************************
    Public ReadOnly Property pBackCode() As String
        Get
            Dim strRec As String = ""
            strRec = "hdnGROUPCD"
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：名称を返すオブジェクトの名前値を渡すプロパティ
    '*　備　考：データ選択後、名称を返すオブジェクト名を指定する
    '******************************************************************************
    Public ReadOnly Property pBackName() As String
        Get
            Dim strRec As String = ""
            strRec = "txtGROUPCD"
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：フォーカスを返すオブジェクトの名前値を渡すプロパティ
    '*　備　考：データ選択後、値を返した後に、カーソルをセットする場所の指定
    '******************************************************************************
    Public ReadOnly Property pBackFocs() As String
        Get
            Dim strRec As String = ""
            strRec = "btnGROUPCD"
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*　概　要：表示をクリアするオブジェクトの名前を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pClear1() As String
        Get
            Dim strRec As String = ""
            strRec = ""
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：表示をクリアするオブジェクトの名前を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pClear2() As String
        Get
            Dim strRec As String = ""
            strRec = ""
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：表示をクリアするオブジェクトの名前を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pClear3() As String
        Get
            Dim strRec As String = ""
            strRec = ""
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：表示をクリアするオブジェクトの名前を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pClear4() As String
        Get
            Dim strRec As String = ""
            strRec = ""
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*　概　要：表示をクリアするオブジェクトの名前を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pClear5() As String
        Get
            Dim strRec As String = ""
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
            strRec = ""
            Return strRec
        End Get
    End Property
End Class
