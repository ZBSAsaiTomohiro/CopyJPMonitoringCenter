'***********************************************
' 供給センターマスタ  メイン画面
'***********************************************
' 変更履歴

Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common
Imports JPG.Common.log

Imports System.Text

Partial Class MSJIGJAG00
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

    Private strCBO_GROUPCD(50) As String
    Private strCBO_USE_FLG(50) As String

    '******************************************************************************
    ' Page_Load
    '******************************************************************************
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '.NETの仕様変更により、ReadOnly属性をASPXでつけると、サーバ側で値の参照ができなくなるため、VB側でAttributeでつける
        If MyBase.IsPostBack = False Then
            txtKURACD.Attributes.Add("ReadOnly", "true")
            txtACBCD_F.Attributes.Add("ReadOnly", "true")
            txtACBCD_T.Attributes.Add("ReadOnly", "true")
            Dim objDefNO As System.Web.UI.WebControls.TextBox
            Dim objDefDEL As System.Web.UI.WebControls.CheckBox
            Dim i As Integer
            For i = 1 To 50
                objDefNO = CType(FindControl("txtNO_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                objDefDEL = CType(FindControl("chkDEL_" & CStr(i)), System.Web.UI.WebControls.CheckBox)

                objDefNO.Attributes.Add("ReadOnly", "true")
                objDefDEL.Checked = False
            Next
        End If
        '2012/04/03 NEC ou Add

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
             MyBase.MapPath("../../../MS/MSJIGJAG/MSJIGJAG00/") & "MSJIGJAG00.js"))
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

        Else
            '//--------------------------------------
            '//　２回目以降実行される
            '//--------------------------------------

            'コンボボックスの再設定
            'グループコード(KEY)
            Dim list As ListItem
            fncCombo_Create_GROUPCD_KEY()
            list = cboGROUPCD.Items.FindByValue(Request.Form("cboGROUPCD"))
            cboGROUPCD.SelectedIndex = cboGROUPCD.Items.IndexOf(list)

            '一覧のコンボボックスの再設定
            fncCombo_Create_GROUPCD() 'グループコードは、関数内でループするため外で。
            Dim i As Integer
            For i = 1 To 50
                fncCombo_Create_USE_FLG(i)
                fncComboGet(i)
                fncComboSet(i)
            Next


        End If

        '<TODO>自分の画面IDをHIDDENのhdnMyAspxに書き込む（システム共通）
        hdnMyAspx.Value = "MSJIGJAG00"
        '//-------------------------------------------------

    End Sub

    '******************************************************************************
    '* 検索処理がされる前の画面状態（ReadOnlyやDisabled）
    '********************************/*********************************************
    Private Sub fncIni_statebf()
        '//--------------------------------------------------------------------------
        '<TODO>検索前の状態にコントロールの状態を設定する

        btnKURACD.Disabled = False
        btnACBCD_F.Disabled = False
        btnACBCD_T.Disabled = False

    End Sub

    '******************************************************************************
    '* 検索処理がされた後の画面状態（ReadOnlyやDisabled）
    '******************************************************************************
    Private Sub fncIni_stateaf()
        '//--------------------------------------------------------------------------
        '<TODO>検索後の状態にコントロールの状態を設定する
        '

        txtKURACD.Attributes.Add("ReadOnly", "true")
        txtACBCD_F.Attributes.Add("ReadOnly", "true")
        txtACBCD_T.Attributes.Add("ReadOnly", "true")
        Dim objNO As System.Web.UI.WebControls.TextBox
        Dim objDEL As System.Web.UI.WebControls.CheckBox
        Dim i As Integer
        For i = 1 To 50
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
        txtKURACD.Text = ""
        hdnKURACD.Value = ""
        txtACBCD_F.Text = ""
        hdnACBCD_F.Value = ""
        txtACBCD_T.Text = ""
        hdnACBCD_T.Value = ""
        fncCombo_Create_GROUPCD_KEY() 'グループコード
        hdnGROUPCD.Value = ""

        'キー以外の値を初期化する
        Call fncIni_notkey()

    End Sub

    '******************************************************************************
    '* キー以外の値を初期化する
    '******************************************************************************
    Private Sub fncIni_notkey()
        '//--------------------------------------------------------------------------
        '<TODO>コントロールの値を初期化する

        hdnKURACD_MOTO.Value = ""
        hdnACBCD_F_MOTO.Value = ""
        hdnACBCD_T_MOTO.Value = ""
        hdnGROUPCD_MOTO.Value = ""

        Dim objDEL As System.Web.UI.WebControls.CheckBox
        Dim objKURACD As System.Web.UI.WebControls.TextBox
        Dim objACBCD As System.Web.UI.WebControls.TextBox
        Dim objBIKO As System.Web.UI.WebControls.TextBox
        Dim objINS_DATE As System.Web.UI.HtmlControls.HtmlInputHidden
        Dim objUPD_DATE As System.Web.UI.HtmlControls.HtmlInputHidden

        Dim i As Integer
        For i = 1 To 50
            objDEL = CType(FindControl("chkDEL_" & CStr(i)), System.Web.UI.WebControls.CheckBox)
            objKURACD = CType(FindControl("txtKURACD_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objACBCD = CType(FindControl("txtACBCD_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objBIKO = CType(FindControl("txtBIKO_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objINS_DATE = CType(FindControl("hdnINS_DATE_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
            objUPD_DATE = CType(FindControl("hdnUPD_DATE_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)


            objDEL.Checked = False
            objKURACD.Text = ""
            objACBCD.Text = ""
            objBIKO.Text = ""
            objINS_DATE.Value = ""
            objUPD_DATE.Value = ""

            fncCombo_Create_USE_FLG(i)

        Next

        'グループコードのセット　データ取得を1度で済ますため、内部でループさせる
        fncCombo_Create_GROUPCD()

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
    '* 一括登録ボタンが押下されたときの処理
    '******************************************************************************
    Private Sub btnIkkatu_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIkkatu.ServerClick
        Dim strRec As String
        strRec = fncbtnIkkatu_ClickEvent(hdnKBN.Value)

        Call fncIni_stateaf()
    End Sub

    '******************************************************************************
    '*　概　要：絞込み条件を渡すプロパティ
    '*　備　考：抽出条件１の値を渡す
    '******************************************************************************
    Public ReadOnly Property pCode1() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then      '//クライアントコード一覧 
                strRec = AuthC.pAUTHCENTERCD    '//ＡＤ認証の使用可能監視センターコード
            ElseIf hdnPopcrtl.Value = "2" Then  '//JA支所コード（From）一覧
                strRec = hdnKURACD.Value
            ElseIf hdnPopcrtl.Value = "3" Then  '//JA支所コード（To）一覧
                strRec = hdnKURACD.Value
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
            ElseIf hdnPopcrtl.Value = "2" Then      '//JA支所コード（From）一覧
                strRec = "ＪＡ支所コード一覧"
            ElseIf hdnPopcrtl.Value = "3" Then      '//JA支所コード（To）一覧
                strRec = "ＪＡ支所コード一覧"
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
            If hdnPopcrtl.Value = "1" Then
                strRec = "CLI"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = "JASS"
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = "JASS"
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
                strRec = "hdnACBCD_F"
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = "hdnACBCD_T"
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
                strRec = "txtACBCD_F"
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = "txtACBCD_T"
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
                strRec = "btnACBCD_F"
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = "btnACBCD_T"
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*　概　要：表示をクリアするオブジェクトの名前を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pClear1() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "txtACBCD_F"
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
    '*　概　要：表示をクリアするオブジェクトの名前を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pClear2() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "hdnACBCD_F"
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
    '*　概　要：表示をクリアするオブジェクトの名前を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pClear3() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "txtACBCD_T"
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
    '*　概　要：表示をクリアするオブジェクトの名前を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pClear4() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "hdnACBCD_T"
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
    '*　概　要：表示をクリアするオブジェクトの名前を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pClear5() As String
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
    '*　概　要：リターン後に実行されるＪＳ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pBackScript() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = ""
            Else
                strRec = ""
            End If
            Return strRec
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

            dbData = fncDataSelect()

            If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
                'データが存在しない為、検索はエラー
                'メッセージを出力後、検索前状態にする。

                strMsg.Append("alert('データが存在しません');")

                Call fncIni_statebf()

                '//------------------------------
                '<TODO>フォーカスをセットする（検索ボタンにセット）
                strMsg.Append("Form1.btnSelect.focus();")

                '//--------------------------------------------------------------------------
            Else
                'データが存在する為、データ出力

                '------------------------------------
                '<TODO>50件以上の場合はメッセージ
                If dbData.Tables(0).Rows.Count > 50 Then
                    strMsg.Append("alert('最大出力件数を超えました。条件を指定して再度検索してください');")
                End If

                '------------------------------------
                '<TODO>データを出力する

                ''クライアントコード
                'hdnKURACD.Value = Convert.ToString(dbData.Tables(0).Rows(0).Item("KURACD"))
                'hdnKURACD_MOTO.Value = Convert.ToString(dbData.Tables(0).Rows(0).Item("KURACD"))
                ''クライアント名
                'txtKURACD.Text = Convert.ToString(dbData.Tables(0).Rows(0).Item("KURACD")) & " : " & Convert.ToString(dbData.Tables(0).Rows(0).Item("CLI_NAME"))

                'クライアントコード
                If hdnKURACD.Value.Length <> 0 Then
                    hdnKURACD_MOTO.Value = hdnKURACD.Value.Trim
                Else
                    hdnKURACD_MOTO.Value = ""
                End If
                'JA支所コード
                If hdnACBCD_F.Value.Length <> 0 Then
                    hdnACBCD_F_MOTO.Value = hdnACBCD_F.Value.Trim
                Else
                    hdnACBCD_F_MOTO.Value = ""
                End If
                If hdnACBCD_T.Value.Length <> 0 Then
                    hdnACBCD_T_MOTO.Value = hdnACBCD_T.Value.Trim
                Else
                    hdnACBCD_T_MOTO.Value = ""
                End If
                'グループコード
                If cboGROUPCD.SelectedIndex <> 0 Then
                    hdnGROUPCD.Value = Convert.ToString(cboGROUPCD.Items.Item(CInt(Request.Form("cboGROUPCD"))))
                    hdnGROUPCD_MOTO.Value = hdnGROUPCD.Value.Trim
                Else
                    hdnGROUPCD.Value = ""
                    hdnGROUPCD_MOTO.Value = ""
                End If


                Dim objKURACD As System.Web.UI.WebControls.TextBox
                Dim objACBCD As System.Web.UI.WebControls.TextBox
                Dim objBIKO As System.Web.UI.WebControls.TextBox
                Dim objINS_DATE As System.Web.UI.HtmlControls.HtmlInputHidden
                Dim objUPD_DATE As System.Web.UI.HtmlControls.HtmlInputHidden

                Dim intRow As Integer

                For intRow = 0 To dbData.Tables(0).Rows.Count - 1

                    If intRow >= 50 Then Exit For '50件以上は処理抜け

                    '----------------------------
                    ' 明細情報を画面項目にセット
                    '----------------------------
                    'コントロール名を探し出し、型変換
                    objKURACD = CType(FindControl("txtKURACD_" & CStr(intRow + 1)), System.Web.UI.WebControls.TextBox)
                    objACBCD = CType(FindControl("txtACBCD_" & CStr(intRow + 1)), System.Web.UI.WebControls.TextBox)
                    objBIKO = CType(FindControl("txtBIKO_" & CStr(intRow + 1)), System.Web.UI.WebControls.TextBox)
                    objINS_DATE = CType(FindControl("hdnINS_DATE_" & CStr(intRow + 1)), System.Web.UI.HtmlControls.HtmlInputHidden)
                    objUPD_DATE = CType(FindControl("hdnUPD_DATE_" & CStr(intRow + 1)), System.Web.UI.HtmlControls.HtmlInputHidden)

                    'キー項目は変更不可にする
                    objKURACD.ReadOnly = True
                    objKURACD.BackColor = Color.Gainsboro
                    objACBCD.ReadOnly = True
                    objACBCD.BackColor = Color.Gainsboro

                    objKURACD.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("KURACD"))
                    objACBCD.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("ACBCD"))
                    objBIKO.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("BIKO"))
                    objINS_DATE.Value = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("INS_DATE"))
                    objUPD_DATE.Value = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("UPD_DATE"))

                    strCBO_GROUPCD(intRow + 1) = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("GROUPCD"))
                    strCBO_USE_FLG(intRow + 1) = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("USE_FLG"))

                    fncComboSet(intRow + 1)
                Next ' intRow


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

        Dim MSJIGJAW00C As New MSJIGJAG00MSJIGJAW00.MSJIGJAW00


        '値を配列にセット
        Dim objKURACD As System.Web.UI.WebControls.TextBox
        Dim objACBCD As System.Web.UI.WebControls.TextBox
        Dim objGROUPCD As JPG.Common.Controls.CTLCombo
        Dim objINS_DATE As System.Web.UI.HtmlControls.HtmlInputHidden
        Dim objUPD_DATE As System.Web.UI.HtmlControls.HtmlInputHidden
        Dim objBIKO As System.Web.UI.WebControls.TextBox
        Dim objDEL As System.Web.UI.WebControls.CheckBox
        Dim sKURACD(50) As String
        Dim sACBCD(50) As String
        Dim sGROUPCD(50) As String
        Dim sUSE_FLG(50) As String
        Dim sINS_DATE(50) As String
        Dim sUPD_DATE(50) As String
        Dim sBIKO(50) As String
        Dim sDEL(50) As String
        Dim i As Integer
        For i = 1 To 50
            objKURACD = CType(FindControl("txtKURACD_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objACBCD = CType(FindControl("txtACBCD_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objGROUPCD = CType(FindControl("cboGROUPCD_" & CStr(i)), JPG.Common.Controls.CTLCombo)
            objINS_DATE = CType(FindControl("hdnINS_DATE_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
            objUPD_DATE = CType(FindControl("hdnUPD_DATE_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
            objBIKO = CType(FindControl("txtBIKO_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objDEL = CType(FindControl("chkDEL_" & CStr(i)), System.Web.UI.WebControls.CheckBox)

            sKURACD(i) = objKURACD.Text.Trim
            sACBCD(i) = objACBCD.Text.Trim
            sUSE_FLG(i) = Request.Form("cboUSE_FLG_" & i)
            sINS_DATE(i) = objINS_DATE.Value.Trim
            sUPD_DATE(i) = objUPD_DATE.Value.Trim
            sBIKO(i) = objBIKO.Text.Trim

            If Request.Form("cboGROUPCD_" & i) <> "" Then
                sGROUPCD(i) = Convert.ToString(objGROUPCD.Items.Item(CInt(Request.Form("cboGROUPCD_" & i)))) 'インデックスじゃなくて、コードが必要
            Else
                sGROUPCD(i) = ""
            End If


            If (objDEL.Checked) Then
                sDEL(i) = "true"
            Else
                sDEL(i) = "false"
            End If

        Next
        strRec = MSJIGJAW00C.mSetEx( _
                    CInt(pstrKBN), _
                    sKURACD, _
                    sACBCD, _
                    sGROUPCD, _
                    sUSE_FLG, _
                    sINS_DATE, _
                    sUPD_DATE, _
                    sBIKO, _
                    sDEL)

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
                strRecMsg = "既にデータが存在します"
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
                strRecMsg = "クライアントコードが存在しません"
                strMsg.Append("alert('" & strRecMsg & "');")

                '<TODO>フォーカスをセットする（登録・修正時でのエラー。検索ボタンにセット）
                strMsg.Append("Form1.btnSelect.focus();")

                strRec = strRecMsg
            Case "5"
                strRecMsg = "JA支所コードが存在しません"
                strMsg.Append("alert('" & strRecMsg & "');")

                '<TODO>フォーカスをセットする（登録・修正時でのエラー。検索ボタンにセット）
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
                    strMsg.Append("Form1.txtKURACD_1.focus();")
                Else
                    '//----------------------------------
                    '<TODO>フォーカスをセットする（その他　：ログ出力のエラーの為キー以降にセット）
                    strMsg.Append("Form1.txtKURACD_1.focus();")
                End If
        End Select

        For i = 1 To 50
            objKURACD = CType(FindControl("txtKURACD_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objACBCD = CType(FindControl("txtACBCD_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            If objKURACD.Text <> "" Then
                objKURACD.ReadOnly = True
                objKURACD.BackColor = Color.Gainsboro
                objACBCD.ReadOnly = True
                objACBCD.BackColor = Color.Gainsboro
            End If
        Next
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
    '* 一括登録が押下されたときの処理
    '******************************************************************************
    Private Function fncbtnIkkatu_ClickEvent(ByVal pstrKBN As String) As String

        Dim strRec As String = ""
        Dim DateFncC As New CDateFnc

        Dim MSJIGJAW00C As New MSJIGJAG00MSJIGJAW00.MSJIGJAW00


        '配列用意
        Dim sKURACD() As String = {""}
        Dim sACBCD() As String = {""}
        Dim sGROUPCD() As String = {""}
        Dim sUSE_FLG() As String = {""}
        Dim sINS_DATE() As String = {""}
        Dim sUPD_DATE() As String = {""}
        Dim sBIKO() As String = {""}
        Dim sDEL() As String = {""}
        '重複確認
        Dim bolchkCHOUFUKU As Boolean = False 'True：重複なし　False：重複ありNG
        '検索
        Dim dbData As DataSet
        Dim bolDataSelect As Boolean = False 'True：対象データあり　False：対象データなしNG


        Try

            hdnGROUPCD.Value = Convert.ToString(cboGROUPCD.Items.Item(CInt(Request.Form("cboGROUPCD"))))

            '重複確認
            bolchkCHOUFUKU = fncchkCHOUFUKU()
            If bolchkCHOUFUKU = False Then
                strMsg.Append("alert('登録済みデータが存在します。検索してデータを確認してください');")

                Call fncIni_statebf()

                '//------------------------------
                '<TODO>フォーカスをセットする（検索ボタンにセット）
                strMsg.Append("Form1.btnSelect.focus();")
                strRec = "重複チェック"
                Return strRec
            End If

            '検索
            dbData = fncDataSelect_Ikkatu()

            If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
                'データが存在しない為、検索はエラー
                'メッセージを出力後、検索前状態にする。
                strMsg.Append("alert('データが存在しません');")

                Call fncIni_statebf()

                '//------------------------------
                '<TODO>フォーカスをセットする（検索ボタンにセット）
                strMsg.Append("Form1.btnSelect.focus();")
                dbData.Dispose()
                strRec = "対象データなし"
                Return strRec
            Else

                '変数に登録値を格納
                Dim intRow As Integer

                For intRow = 0 To dbData.Tables(0).Rows.Count - 1

                    ReDim Preserve sKURACD(intRow + 1)
                    ReDim Preserve sACBCD(intRow + 1)
                    ReDim Preserve sGROUPCD(intRow + 1)
                    ReDim Preserve sUSE_FLG(intRow + 1)
                    ReDim Preserve sINS_DATE(intRow + 1)
                    ReDim Preserve sUPD_DATE(intRow + 1)
                    ReDim Preserve sBIKO(intRow + 1)
                    ReDim Preserve sDEL(intRow + 1)


                    sKURACD(intRow + 1) = hdnKURACD.Value.Trim
                    sACBCD(intRow + 1) = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("HAN_CD"))
                    sGROUPCD(intRow + 1) = hdnGROUPCD.Value.Trim
                    sUSE_FLG(intRow + 1) = "1"
                    sINS_DATE(intRow + 1) = ""
                    sUPD_DATE(intRow + 1) = ""
                    sBIKO(intRow + 1) = ""
                    sDEL(intRow + 1) = "false"

                Next

                strRec = MSJIGJAW00C.mSetEx( _
                                    CInt(pstrKBN), _
                                    sKURACD, _
                                    sACBCD, _
                                    sGROUPCD, _
                                    sUSE_FLG, _
                                    sINS_DATE, _
                                    sUPD_DATE, _
                                    sBIKO, _
                                    sDEL)



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
                        strRecMsg = "既にデータが存在します"
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
                        strRecMsg = "クライアントコードが存在しません"
                        strMsg.Append("alert('" & strRecMsg & "');")

                        '<TODO>フォーカスをセットする（登録・修正時でのエラー。検索ボタンにセット）
                        strMsg.Append("Form1.btnSelect.focus();")

                        strRec = strRecMsg
                    Case "5"
                        strRecMsg = "JA支所コードが存在しません"
                        strMsg.Append("alert('" & strRecMsg & "');")

                        '<TODO>フォーカスをセットする（登録・修正時でのエラー。検索ボタンにセット）
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
                            strMsg.Append("Form1.txtKURACD_1.focus();")
                        Else
                            '//----------------------------------
                            '<TODO>フォーカスをセットする（その他　：ログ出力のエラーの為キー以降にセット）
                            strMsg.Append("Form1.txtKURACD_1.focus();")
                        End If
                End Select
                dbData.Dispose()
            End If

        Catch ex As Exception
            strRec = ex.ToString
            Dim ErrMsgC As New CErrMsg
            strMsg.Append("alert('システムエラー：" & ErrMsgC.mGetArtMsg(ex.ToString) & "');")

        Finally
            '-------------------------------------------------
            '//ＡＰログ書き込み
            Dim LogC As New CLog
            Dim strRecLog As String
            strRecLog = LogC.mAPLog(Me.Session.SessionID, AuthC.pUSERNAME, AuthC.pIPADDRESS, hdnMyAspx.Value, pstrKBN, strRec, Request.Form)

            If strRecLog <> "OK" Then
                Dim errmsgc As New CErrMsg
                strMsg.Append("alert('システムエラー：" & errmsgc.mGetArtMsg(strRecLog) & "');")
            End If

        End Try
        

        Return strRec
    End Function

    '******************************************************************************
    '* 入力キーによるデータの検索を行います。
    '******************************************************************************
    Private Function fncDataSelect() As DataSet

        '//------------------------------------------
        '//<TODO>Select文の作成
        Dim SQLC As New MSJIGJAG00CCSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet

        strSQL.Append("SELECT  ")
        strSQL.Append("	    A.KURACD ")
        'strSQL.Append("	    ,B.CLI_NAME ")
        strSQL.Append("	    ,A.ACBCD ")
        'strSQL.Append("	    ,C.JAS_NAME ")
        strSQL.Append("	    ,A.GROUPCD ")
        strSQL.Append("	    ,A.USE_FLG ")
        strSQL.Append("	    ,A.INS_DATE ")
        strSQL.Append("	    ,A.UPD_DATE ")
        strSQL.Append("     ,A.BIKO ")
        strSQL.Append("FROM ")
        strSQL.Append("	    M07_AUTOTAIOUGROUP A ")
        'strSQL.Append("	    ,CLIMAS B ")
        'strSQL.Append("	    ,HN2MAS C ")
        strSQL.Append("WHERE 1=1")
        'strSQL.Append("AND   A.KURACD = B.CLI_CD(+) ")
        'strSQL.Append("AND   A.KURACD = C.CLI_CD(+) ")
        'strSQL.Append("AND   A.ACBCD = C.HAN_CD(+) ")
        'クライアントコード
        If hdnKURACD.Value.Trim.Length > 0 Then
            strSQL.Append("AND   A.KURACD =:KURACD ")
        End If
        'JA支所コード
        If hdnACBCD_F.Value.Trim.Length > 0 Then
            strSQL.Append("AND   A.ACBCD >=:ACBCD_F ")
        End If
        If hdnACBCD_T.Value.Trim.Length > 0 Then
            strSQL.Append("AND   A.ACBCD <=:ACBCD_T ")
        End If
        'グループコード
        If hdnGROUPCD.Value.Trim.Length > 0 Then
            strSQL.Append("AND   A.GROUPCD =:GROUPCD ")
        End If
        strSQL.Append("ORDER BY A.KURACD, A.ACBCD")


        'クライアントコード
        If hdnKURACD.Value.Trim.Length > 0 Then
            SqlParamC.fncSetParam("KURACD", True, hdnKURACD.Value.Trim)
        End If
        'JA支所コード（From）
        If hdnACBCD_F.Value.Trim.Length > 0 Then
            SqlParamC.fncSetParam("ACBCD_F", True, hdnACBCD_F.Value.Trim)
        End If
        'JA支所コード（To）
        If hdnACBCD_T.Value.Trim.Length > 0 Then
            SqlParamC.fncSetParam("ACBCD_T", True, hdnACBCD_T.Value.Trim)
        End If
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
        Dim MSJIGJAG00C As New MSJIGJAG00MSJIGJAW00.MSJIGJAW00

        '//　認証クラスのインスタンス生成
        AuthC = New CAuthenticate(Request, Response)

        Dim strRecMsg As String = ""

        strRec = MSJIGJAG00C.mCSV( _
                         Me.Session.SessionID, _
                         hdnKURACD.Value, _
                         hdnACBCD_F.Value, _
                         hdnACBCD_T.Value, _
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
            HttpHeaderC.mDownLoadCSV(Response, "自動対応グループマスタ.csv")
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
    '* 一覧のコンボボックスの入力値取得
    '**************************************************
    Private Sub fncComboGet(ByVal i As Integer)
        Dim obj As JPG.Common.Controls.CTLCombo

        'グループコード
        obj = CType(FindControl("cboGROUPCD_" & CStr(i)), JPG.Common.Controls.CTLCombo)
        strCBO_GROUPCD(i) = Request.Form(obj.ID)
        If Request.Form("cboGROUPCD_" & i) <> "" Then
            strCBO_GROUPCD(i) = Convert.ToString(obj.Items.Item(CInt(Request.Form("cboGROUPCD_" & CStr(i)))))
        Else
            strCBO_GROUPCD(i) = ""
        End If
        '使用フラグ
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

        If strCBO_GROUPCD(i) <> "" Then
            obj = CType(FindControl("cboGROUPCD_" & CStr(i)), JPG.Common.Controls.CTLCombo)
            list = obj.Items.FindByText(strCBO_GROUPCD(i))
            obj.SelectedIndex = obj.Items.IndexOf(list)
        End If

        If strCBO_USE_FLG(i) <> "" Then
            obj = CType(FindControl("cboUSE_FLG_" & CStr(i)), JPG.Common.Controls.CTLCombo)
            list = obj.Items.FindByValue(strCBO_USE_FLG(i))
            obj.SelectedIndex = obj.Items.IndexOf(list)
        End If

    End Sub
    'グループコード(KEY)
    Private Sub fncCombo_Create_GROUPCD_KEY()

        cboGROUPCD.Items.Clear()

        Dim dbData As DataSet
        dbData = fncGET_GROUPCD()

        If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
            cboGROUPCD.Items.Add(New ListItem("", ""))
        Else
            Dim intRow As Integer
            cboGROUPCD.Items.Add(New ListItem("", ""))
            For intRow = 0 To dbData.Tables(0).Rows.Count - 1
                cboGROUPCD.Items.Add(New ListItem(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("GROUPCD")), CStr(intRow + 1)))
            Next
        End If
    End Sub
    'グループコード
    Private Sub fncCombo_Create_GROUPCD()

        Dim objGROUPCD As JPG.Common.Controls.CTLCombo
        Dim dbData As DataSet

        dbData = fncGET_GROUPCD()

        'データ取得を一度にするため、内部でループ
        Dim i As Integer
        For i = 1 To 50
            objGROUPCD = CType(FindControl("cboGROUPCD_" & CStr(i)), JPG.Common.Controls.CTLCombo)
            objGROUPCD.Items.Clear()

            If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
                cboGROUPCD.Items.Add(New ListItem("", ""))
            Else
                Dim intRow As Integer
                objGROUPCD.Items.Add(New ListItem("", ""))
                For intRow = 0 To dbData.Tables(0).Rows.Count - 1
                    objGROUPCD.Items.Add(New ListItem(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("GROUPCD")), CStr(intRow + 1)))
                Next
            End If
        Next

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

    '******************************************************************************
    '*グループコードの一覧取得
    '******************************************************************************
    Private Function fncGET_GROUPCD() As DataSet

        '//------------------------------------------
        '//<TODO>Select文の作成
        Dim SQLC As New MSJIGJAG00CCSQL.CSQL
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
        strSQL.Append("		A.GROUPCD  ")
        strSQL.Append("FROM  ")
        strSQL.Append("		M08_AUTOTAIOU A  ")
        strSQL.Append("GROUP BY A.GROUPCD  ")
        strSQL.Append("UNION ")
        strSQL.Append("SELECT ")
        strSQL.Append("		B.GROUPCD ")
        strSQL.Append("FROM ")
        strSQL.Append("		M07_AUTOTAIOUGROUP B ")
        strSQL.Append("GROUP BY B.GROUPCD ")
        strSQL.Append("ORDER BY GROUPCD ")

        dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

        Return dbData
    End Function

    '******************************************************************************
    '*指定範囲の重複チェック　True：重複なし　False：重複ありNG
    '******************************************************************************
    Private Function fncchkCHOUFUKU() As Boolean

        Dim res As Boolean = False

        '//------------------------------------------
        '//<TODO>Select文の作成
        Dim SQLC As New MSJIGJAG00CCSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet

        strSQL.Append("SELECT ")
        strSQL.Append("		'X' ")
        strSQL.Append("FROM ")
        strSQL.Append("		M07_AUTOTAIOUGROUP A ")
        strSQL.Append("WHERE ")
        strSQL.Append("		A.KURACD = :KURACD ")
        If hdnACBCD_F.Value.Trim.Length > 0 Then
            strSQL.Append("AND	A.ACBCD >= :ACBCD_F ")
        End If
        If hdnACBCD_T.Value.Trim.Length > 0 Then
            strSQL.Append("AND	A.ACBCD <= :ACBCD_T ")
        End If
        strSQL.Append("ORDER BY A.KURACD, A.ACBCD ")


        SqlParamC.fncSetParam("KURACD", True, hdnKURACD.Value.Trim)

        If hdnACBCD_F.Value.Trim.Length > 0 Then
            SqlParamC.fncSetParam("ACBCD_F", True, hdnACBCD_F.Value.Trim)
        End If
        If hdnACBCD_T.Value.Trim.Length > 0 Then
            SqlParamC.fncSetParam("ACBCD_T", True, hdnACBCD_T.Value.Trim)
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
    '*一括登録用検索
    '******************************************************************************
    Private Function fncDataSelect_Ikkatu() As DataSet

        '//------------------------------------------
        '//<TODO>Select文の作成
        Dim SQLC As New MSJIGJAG00CCSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet

        strSQL.Append("SELECT ")
        strSQL.Append("		A.CLI_CD ")
        strSQL.Append("		,A.HAN_CD ")
        strSQL.Append("FROM ")
        strSQL.Append("		HN2MAS A ")
        strSQL.Append("WHERE ")
        strSQL.Append("		A.CLI_CD = :KURACD ")
        strSQL.Append("AND	NVL(A.DEL_FLG,'0') <> '1' ")
        If hdnACBCD_F.Value.Trim.Length > 0 Then
            strSQL.Append("AND	A.HAN_CD >= :ACBCD_F ")
        End If
        If hdnACBCD_T.Value.Trim.Length > 0 Then
            strSQL.Append("AND	A.HAN_CD <= :ACBCD_T ")
        End If
        strSQL.Append("AND	NOT EXISTS( ")
        strSQL.Append("			SELECT	'X' ")
        strSQL.Append("			FROM	HN2MAS B ")
        strSQL.Append("			WHERE	A.CLI_CD = B.CLI_CD ")
        strSQL.Append("			AND		A.HAN_CD = B.JA_CD ")
        strSQL.Append("			) ")
        strSQL.Append("ORDER BY A.CLI_CD, A.HAN_CD ")

        '//------------------------------------------
        '//<TODO>パラメータの設定
        SqlParamC.fncSetParam("KURACD", True, hdnKURACD.Value.Trim)

        If hdnACBCD_F.Value.Trim.Length > 0 Then
            SqlParamC.fncSetParam("ACBCD_F", True, hdnACBCD_F.Value.Trim)
        End If

        If hdnACBCD_T.Value.Trim.Length > 0 Then
            SqlParamC.fncSetParam("ACBCD_T", True, hdnACBCD_T.Value.Trim)
        End If


        dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

        Return dbData
    End Function
End Class
