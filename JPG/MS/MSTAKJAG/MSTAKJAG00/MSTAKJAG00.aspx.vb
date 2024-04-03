'***********************************************
'監視センター担当者マスタ
'***********************************************
' 変更履歴

Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common
Imports JPG.Common.log

Imports System.Text

Partial Class MSTAKJAG00
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
            txtCODE.Attributes.Add("ReadOnly", "true")
            txtTANCD_F.Attributes.Add("ReadOnly", "true")
            txtTANCD_T.Attributes.Add("ReadOnly", "true")
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
             MyBase.MapPath("../../../MS/MSTAKJAG/MSTAKJAG00/") & "MSTAKJAG00.js"))
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


        End If

        '<TODO>自分の画面IDをHIDDENのhdnMyAspxに書き込む（システム共通）
        hdnMyAspx.Value = "MSTAKJAG00"
        '//-------------------------------------------------

    End Sub

    '******************************************************************************
    '* 検索処理がされる前の画面状態（ReadOnlyやDisabled）
    '********************************/*********************************************
    Private Sub fncIni_statebf()
        '//--------------------------------------------------------------------------
        '<TODO>検索前の状態にコントロールの状態を設定する

        btnCODE.Disabled = False
        btnTANCD_F.Disabled = False
        btnTANCD_T.Disabled = False

    End Sub

    '******************************************************************************
    '* 検索処理がされた後の画面状態（ReadOnlyやDisabled）
    '******************************************************************************
    Private Sub fncIni_stateaf()
        '//--------------------------------------------------------------------------
        '<TODO>検索後の状態にコントロールの状態を設定する
        '
        txtCODE.Attributes.Add("ReadOnly", "true")
        txtTANCD_F.Attributes.Add("ReadOnly", "true")
        txtTANCD_T.Attributes.Add("ReadOnly", "true")
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
        txtCODE.Text = ""
        hdnCODE.Value = ""
        txtTANCD_F.Text = ""
        hdnTANCD_F.Value = ""
        txtTANCD_T.Text = ""
        hdnTANCD_T.Value = ""

        'キー以外の値を初期化する
        Call fncIni_notkey()

    End Sub

    '******************************************************************************
    '* キー以外の値を初期化する
    '******************************************************************************
    Private Sub fncIni_notkey()

        '//--------------------------------------------------------------------------
        '<TODO>コントロールの値を初期化する

        hdnCODE_MOTO.Value = ""
        hdnTANCD_F_MOTO.Value = ""
        hdnTANCD_T_MOTO.Value = ""

        Dim objDEL As System.Web.UI.WebControls.CheckBox
        Dim objTANCD As System.Web.UI.WebControls.TextBox
        Dim objTANNM As System.Web.UI.WebControls.TextBox
        Dim objTANID As System.Web.UI.WebControls.TextBox    '2020/11/01 T.Ono add 2020 監視改善2020
        Dim objDISP_NO As System.Web.UI.WebControls.TextBox
        Dim objBIKO As System.Web.UI.WebControls.TextBox
        Dim objADD_DATE As System.Web.UI.HtmlControls.HtmlInputHidden
        Dim objEDT_DATE As System.Web.UI.HtmlControls.HtmlInputHidden
        Dim objTIME As System.Web.UI.HtmlControls.HtmlInputHidden

        Dim i As Integer

        For i = 1 To 30
            'コントロール名を探し出し、型変換
            objDEL = CType(FindControl("chkDEL_" & CStr(i)), System.Web.UI.WebControls.CheckBox)
            objTANCD = CType(FindControl("txtTANCD_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objTANNM = CType(FindControl("txtTANNM_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objTANID = CType(FindControl("txtTANID_" & CStr(i)), System.Web.UI.WebControls.TextBox)    '2020/11/01 T.Ono add 2020監視改善
            objDISP_NO = CType(FindControl("txtDISP_NO_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objBIKO = CType(FindControl("txtBIKO_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objADD_DATE = CType(FindControl("hdnADD_DATE_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
            objEDT_DATE = CType(FindControl("hdnEDT_DATE_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
            objTIME = CType(FindControl("hdnTIME_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)


            objDEL.Checked = False
            objTANCD.Text = ""
            objTANNM.Text = ""
            objTANID.Text = ""    '2020/11/01 T.Ono add 2020監視改善
            objDISP_NO.Text = ""
            objBIKO.Text = ""
            objADD_DATE.Value = ""
            objEDT_DATE.Value = ""
            objTIME.Value = ""
        Next

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
            If hdnPopcrtl.Value = "1" Then      '//監視センターコード一覧
                strRec = AuthC.pAUTHCENTERCD    '//ＡＤ認証の使用可能監視センターコード
            ElseIf hdnPopcrtl.Value = "2" Then  '//担当者コード（From）一覧
                strRec = hdnCODE.Value.Trim     '//監視センターコード
            ElseIf hdnPopcrtl.Value = "3" Then  '//担当者コード（To）一覧
                strRec = hdnCODE.Value.Trim     '//監視センターコード
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
            If hdnPopcrtl.Value = "1" Then          '//監視センターコード一覧
                strRec = "監視センターコード一覧"
            ElseIf hdnPopcrtl.Value = "2" Then      '//担当者コード（From）一覧
                strRec = "監視センター担当者一覧"
            ElseIf hdnPopcrtl.Value = "3" Then      '//担当者コード（To）一覧
                strRec = "監視センター担当者一覧"
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
                strRec = "KANSHI"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = "TKTANCDKN_ORDCD"
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = "TKTANCDKN_ORDCD"
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
                strRec = "hdnCODE"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = "hdnTANCD_F"
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = "hdnTANCD_T"
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
                strRec = "txtCODE"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = "txtTANCD_F"
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = "txtTANCD_T"
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
                strRec = "btnCODE"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = "btnTANCD_F"
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = "btnTANCD_T"
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
                strRec = "txtTANCD_F"
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
                strRec = "hdnTANCD_F"
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
                strRec = "txtTANCD_T"
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
                strRec = "hdnTANCD_T"
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
                '<TODO>フォーカスをセットする
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

                '監視センターコード
                hdnCODE.Value = Convert.ToString(dbData.Tables(0).Rows(0).Item("CODE"))
                hdnCODE_MOTO.Value = Convert.ToString(dbData.Tables(0).Rows(0).Item("CODE"))
                '監視センター名
                txtCODE.Text = Convert.ToString(dbData.Tables(0).Rows(0).Item("CODE")) & " : " & Convert.ToString(dbData.Tables(0).Rows(0).Item("KANSI_NAME"))

                Dim objTANCD As System.Web.UI.WebControls.TextBox
                Dim objTANNM As System.Web.UI.WebControls.TextBox
                Dim objTANID As System.Web.UI.WebControls.TextBox    '2020/11/01 T.Ono add 2020監視改善
                Dim objDISP_NO As System.Web.UI.WebControls.TextBox
                Dim objBIKO As System.Web.UI.WebControls.TextBox
                Dim objADD_DATE As System.Web.UI.HtmlControls.HtmlInputHidden
                Dim objEDT_DATE As System.Web.UI.HtmlControls.HtmlInputHidden
                Dim objTIME As System.Web.UI.HtmlControls.HtmlInputHidden

                Dim intRow As Integer

                For intRow = 0 To dbData.Tables(0).Rows.Count - 1

                    If intRow >= 30 Then Exit For '30件以上は処理抜け

                    '----------------------------
                    ' 明細情報を画面項目にセット
                    '----------------------------
                    'コントロール名を探し出し、型変換
                    objTANCD = CType(FindControl("txtTANCD_" & CStr(intRow + 1)), System.Web.UI.WebControls.TextBox)
                    objTANNM = CType(FindControl("txtTANNM_" & CStr(intRow + 1)), System.Web.UI.WebControls.TextBox)
                    objTANID = CType(FindControl("txtTANID_" & CStr(intRow + 1)), System.Web.UI.WebControls.TextBox)    '2020/11/01 T.Ono add 2020監視改善
                    objDISP_NO = CType(FindControl("txtDISP_NO_" & CStr(intRow + 1)), System.Web.UI.WebControls.TextBox)
                    objBIKO = CType(FindControl("txtBIKO_" & CStr(intRow + 1)), System.Web.UI.WebControls.TextBox)
                    objADD_DATE = CType(FindControl("hdnADD_DATE_" & CStr(intRow + 1)), System.Web.UI.HtmlControls.HtmlInputHidden)
                    objEDT_DATE = CType(FindControl("hdnEDT_DATE_" & CStr(intRow + 1)), System.Web.UI.HtmlControls.HtmlInputHidden)
                    objTIME = CType(FindControl("hdnTIME_" & CStr(intRow + 1)), System.Web.UI.HtmlControls.HtmlInputHidden)

                    'キー項目は変更不可にする
                    objTANCD.ReadOnly = True
                    objTANCD.BackColor = Color.Gainsboro

                    objTANCD.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("TANCD"))
                    objTANNM.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("TANNM"))
                    objTANID.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("GUIDELINE"))    '2020/11/01 T.Ono add 2020監視改善
                    objDISP_NO.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("DISP_NO"))
                    objBIKO.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("BIKO"))
                    objADD_DATE.Value = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("ADD_DATE"))
                    objEDT_DATE.Value = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("EDT_DATE"))
                    objTIME.Value = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("TIME"))

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

        '//------------------------------------------
        '<TODO>独自のWEBサービルを宣言する
        Dim MSTAKJAW00C As New MSTAKJAG00MSTAKJAW00.MSTAKJAW00

        '//-----------------------------------------------
        '<TODO>監視センター担当者は区分=1
        Dim strKBN As String
        strKBN = "1"

        '//-----------------------------------------------
        '<TODO>クライアントコード="ZZZZ"
        Dim strKURACD As String
        strKURACD = "ZZZZ"

        '//-----------------------------------------------
        '<TODO>担当者コードFrom・To
        Dim strTANCD_F As String
        Dim strTANCD_T As String
        strTANCD_F = hdnTANCD_F.Value
        strTANCD_T = hdnTANCD_T.Value


        '値を配列にセット
        Dim sTANCD(30) As String
        Dim sTANNM(30) As String
        Dim sTANID(30) As String    '2020/11/01 T.Ono add 2020監視改善
        Dim sDISP_NO(30) As String
        Dim sBIKO(30) As String
        Dim sDEL(30) As String
        Dim sADD_DATE(30) As String
        Dim sEDT_DATE(30) As String
        Dim sTIME(30) As String
        Dim objTANCD As System.Web.UI.WebControls.TextBox
        Dim objTANNM As System.Web.UI.WebControls.TextBox
        Dim objTANID As System.Web.UI.WebControls.TextBox    '2020/11/01 T.Ono add 2020監視改善
        Dim objDISP_NO As System.Web.UI.WebControls.TextBox
        Dim objBIKO As System.Web.UI.WebControls.TextBox
        Dim objDEL As System.Web.UI.WebControls.CheckBox
        Dim objADD_DATE As System.Web.UI.HtmlControls.HtmlInputHidden
        Dim objEDT_DATE As System.Web.UI.HtmlControls.HtmlInputHidden
        Dim objTIME As System.Web.UI.HtmlControls.HtmlInputHidden
        Dim i As Integer

        For i = 1 To 30
            'コントロール名を探し出し、型変換
            objTANCD = CType(FindControl("txtTANCD_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objTANNM = CType(FindControl("txtTANNM_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objTANID = CType(FindControl("txtTANID_" & CStr(i)), System.Web.UI.WebControls.TextBox)    '2020/11/01 T.Ono add 2020監視改善
            objDISP_NO = CType(FindControl("txtDISP_NO_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objBIKO = CType(FindControl("txtBIKO_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objDEL = CType(FindControl("chkDEL_" & CStr(i)), System.Web.UI.WebControls.CheckBox)
            objADD_DATE = CType(FindControl("hdnADD_DATE_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
            objEDT_DATE = CType(FindControl("hdnEDT_DATE_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
            objTIME = CType(FindControl("hdnTIME_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)


            sTANCD(i) = Trim(objTANCD.Text)
            sTANNM(i) = Trim(objTANNM.Text)
            sTANID(i) = Trim(objTANID.Text)
            sDISP_NO(i) = Trim(objDISP_NO.Text)
            sBIKO(i) = Trim(objBIKO.Text)
            If (objDEL.Checked) Then
                sDEL(i) = "true"
            Else
                sDEL(i) = "false"
            End If
            sADD_DATE(i) = objADD_DATE.Value
            sEDT_DATE(i) = objEDT_DATE.Value
            sTIME(i) = objTIME.Value
        Next

        '2020/11/01 T.Ono mod 2020監視改善 sTANID追加
        strRec = MSTAKJAW00C.mSetEx(
                    CInt(pstrKBN),
                    strKBN,
                    strKURACD,
                    hdnCODE.Value,
                    strTANCD_F,
                    strTANCD_T,
                    sTANCD,
                    sTANNM,
                    sTANID,
                    sDISP_NO,
                    sBIKO,
                    sDEL,
                    sADD_DATE,
                    sEDT_DATE,
                    sTIME)

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
            Case "3"
                strRecMsg = "排他制御処理でエラーが発生しました。再度実行してください"
                strMsg.Append("alert('" & strRecMsg & "');")

                '<TODO>フォーカスをセットする（登録・修正・削除時でのエラー。終了ボタンにセット）
                strMsg.Append("Form1.btnExit.focus();")
                strRec = strRecMsg
            Case "4"
                strRecMsg = "監視センターコードが存在しません"
                strMsg.Append("alert('" & strRecMsg & "');")

                '<TODO>フォーカスをセットする（登録・修正時でのエラー。監視センターコード検索補助ボタンにセット）
                strMsg.Append("Form1.btnCODE.focus();")

            Case Else
                Dim ErrMsgC As New CErrMsg

                strMsg.Append("alert('システムエラー：" & ErrMsgC.mGetArtMsg(strRec) & "');")

                If pstrKBN = "1" Then
                    '//----------------------------------
                    '<TODO>フォーカスをセットする（登録処理：ログ出力のエラーの為キーにセット）
                ElseIf pstrKBN = "2" Then
                    '//----------------------------------
                    '<TODO>フォーカスをセットする（修正処理：ログ出力のエラーの為キー以降にセット）
                    strMsg.Append("Form1.txtTANCD_1.focus();")
                Else
                    '//----------------------------------
                    '<TODO>フォーカスをセットする（その他　：ログ出力のエラーの為キー以降にセット）
                    strMsg.Append("Form1.txtTANCD_1.focus();")
                End If
        End Select
        For i = 1 To 30
            objTANCD = CType(FindControl("txtTANCD_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            If objTANCD.Text <> "" Then
                objTANCD.ReadOnly = True
                objTANCD.BackColor = Color.Gainsboro
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
    '* 入力キーによるデータの検索を行います。
    '******************************************************************************
    Private Function fncDataSelect() As DataSet

        '//------------------------------------------
        '//<TODO>Select文の作成
        Dim SQLC As New MSTAKJAG00CCSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet

        strSQL.Append(" SELECT ")
        strSQL.Append(" 	A.KBN ")
        strSQL.Append(" 	,A.KURACD ")
        strSQL.Append(" 	,A.CODE ")
        strSQL.Append(" 	,B.KANSI_NAME ")
        strSQL.Append(" 	,A.TANCD ")
        strSQL.Append(" 	,A.TANNM ")
        strSQL.Append(" 	,A.GUIDELINE ")    '担当者ID　2020/11/01 T.Ono add 2020監視改善
        strSQL.Append(" 	,A.DISP_NO ")
        strSQL.Append(" 	,A.BIKO ")
        strSQL.Append(" 	,A.ADD_DATE ")
        strSQL.Append(" 	,A.EDT_DATE ")
        strSQL.Append(" 	,A.TIME ")
        strSQL.Append(" FROM  ")
        strSQL.Append(" 	M05_TANTO A ")
        strSQL.Append(" 	,KANSIMAS B ")
        strSQL.Append(" WHERE 1=1 ")
        strSQL.Append(" AND	A.KBN = '1' ")
        strSQL.Append(" AND	A.KURACD = 'ZZZZ' ")
        strSQL.Append(" AND	A.CODE = :CODE ")
        strSQL.Append(" AND A.CODE = B.KANSI_CD ")
        If hdnTANCD_F.Value.Trim.Length > 0 Then
            strSQL.Append(" AND	TO_NUMBER(A.TANCD) >= TO_NUMBER(:TANCD_F) ")
        End If
        If hdnTANCD_T.Value.Trim.Length > 0 Then
            strSQL.Append(" AND	TO_NUMBER(A.TANCD) <= TO_NUMBER(:TANCD_T) ")
        End If
        strSQL.Append(" ORDER BY TO_NUMBER(A.TANCD) ")


        '監視センターコード
        If hdnCODE.Value.Trim.Length > 0 Then
            SqlParamC.fncSetParam("CODE", True, hdnCODE.Value.Trim)
        End If
        '担当者コードFrom
        If hdnTANCD_F.Value.Trim.Length > 0 Then
            SqlParamC.fncSetParam("TANCD_F", True, hdnTANCD_F.Value.Trim)
        End If
        '担当者コードTo
        If hdnTANCD_T.Value.Trim.Length > 0 Then
            SqlParamC.fncSetParam("TANCD_T", True, hdnTANCD_T.Value.Trim)
        End If

        dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

        Return dbData
    End Function


    Public Sub putlog(ByVal strMsg As String)
        Dim textFile As System.IO.StreamWriter
        Dim folder As String = ConfigurationSettings.AppSettings("JA_TAN_MST_PATH")
        textFile = New System.IO.StreamWriter(folder & "COASYUKE00.log", True, System.Text.Encoding.Default)
        textFile.WriteLine(strMsg)
        textFile.Close()
    End Sub
    '******************************************************************************
    ' Excel出力(チェックつき)
    '******************************************************************************
    Private Sub btnCSVout_ServerClick(ByVal sender As System.Object, _
                                    ByVal e As System.EventArgs) Handles btnCSVout.ServerClick
        Dim strRec As String
        Dim MSTAKJAG00C As New MSTAKJAG00MSTAKJAW00.MSTAKJAW00

        '//　認証クラスのインスタンス生成
        AuthC = New CAuthenticate(Request, Response)

        Dim strRecMsg As String = "ERROR"

        strRec = MSTAKJAG00C.mCSV( _
                         Me.Session.SessionID, _
                         hdnCODE.Value, _
                         hdnTANCD_F.Value.Trim, _
                         hdnTANCD_T.Value.Trim _
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
            HttpHeaderC.mDownLoadCSV(Response, "監視センター担当者.csv")
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
End Class
