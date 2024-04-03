'***********************************************
'販売店グループマスタ
'***********************************************
' 変更履歴

Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common
Imports JPG.Common.log

Imports System.Text

Partial Class MSHATJAG00
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
            txtGROUPCD_F.Attributes.Add("ReadOnly", "true")
            txtGROUPCD_T.Attributes.Add("ReadOnly", "true")
            Dim objDefNO As System.Web.UI.WebControls.TextBox
            Dim objDefTARGET As System.Web.UI.WebControls.CheckBox
            Dim objDefINS_DATE As System.Web.UI.WebControls.TextBox
            Dim objDefINS_USER As System.Web.UI.WebControls.TextBox
            Dim objDefUPD_DATE As System.Web.UI.WebControls.TextBox
            Dim objDefUPD_USER As System.Web.UI.WebControls.TextBox
            Dim i As Integer
            For i = 1 To 100
                objDefNO = CType(FindControl("txtNO_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                objDefTARGET = CType(FindControl("chkTARGET_" & CStr(i)), System.Web.UI.WebControls.CheckBox)
                objDefINS_DATE = CType(FindControl("txtINS_DATE_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                objDefINS_USER = CType(FindControl("txtINS_USER_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                objDefUPD_DATE = CType(FindControl("txtUPD_DATE_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                objDefUPD_USER = CType(FindControl("txtUPD_USER_" & CStr(i)), System.Web.UI.WebControls.TextBox)

                objDefNO.Attributes.Add("ReadOnly", "true")
                objDefTARGET.Checked = True
                objDefINS_DATE.Attributes.Add("ReadOnly", "true")
                objDefINS_USER.Attributes.Add("ReadOnly", "true")
                objDefUPD_DATE.Attributes.Add("ReadOnly", "true")
                objDefUPD_USER.Attributes.Add("ReadOnly", "true")
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
             MyBase.MapPath("../../../MS/MSHATJAG/MSHATJAG00/") & "MSHATJAG00.js"))
        '<フォーカス関連関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncFo.js"))
        '<入力チェック関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncChk.js"))
        '<数値関連関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncNumChk.js"))
        '<バイト数カウント関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncGetByte.js"))
        '<全角チェック関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncZenkakuChk.js"))
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
            '// 営業所グループは当画面を使わないため、hdnBackUrlも使用しない
            '//-----------------------------------------------------
            hdnBackUrl.Value = ""

        Else
            '//--------------------------------------
            '//　２回目以降実行される
            '//--------------------------------------


        End If

        '<TODO>自分の画面IDをHIDDENのhdnMyAspxに書き込む（システム共通）
        hdnMyAspx.Value = "MSHATJAG00"
        '//-------------------------------------------------

    End Sub

    '******************************************************************************
    '* 検索処理がされる前の画面状態（ReadOnlyやDisabled）
    '********************************/*********************************************
    Private Sub fncIni_statebf()
        '//--------------------------------------------------------------------------
        '<TODO>検索前の状態にコントロールの状態を設定する

        btnKURACD.Disabled = False
        btnGROUPCD_F.Disabled = False
        btnGROUPCD_T.Disabled = False

    End Sub

    '******************************************************************************
    '* 検索処理がされた後の画面状態（ReadOnlyやDisabled）
    '******************************************************************************
    Private Sub fncIni_stateaf()
        '//--------------------------------------------------------------------------
        '<TODO>検索後の状態にコントロールの状態を設定する
        '
        txtKURACD.Attributes.Add("ReadOnly", "true")
        txtGROUPCD_F.Attributes.Add("ReadOnly", "true")
        txtGROUPCD_T.Attributes.Add("ReadOnly", "true")
        Dim objNO As System.Web.UI.WebControls.TextBox
        Dim objTARGET As System.Web.UI.WebControls.CheckBox
        Dim objINS_DATE As System.Web.UI.WebControls.TextBox
        Dim objINS_USER As System.Web.UI.WebControls.TextBox
        Dim objUPD_DATE As System.Web.UI.WebControls.TextBox
        Dim objUPD_USER As System.Web.UI.WebControls.TextBox
        Dim i As Integer
        For i = 1 To 100
            objNO = CType(FindControl("txtNO_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objTARGET = CType(FindControl("chkTARGET_" & CStr(i)), System.Web.UI.WebControls.CheckBox)
            objINS_DATE = CType(FindControl("txtINS_DATE_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objINS_USER = CType(FindControl("txtINS_USER_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objUPD_DATE = CType(FindControl("txtUPD_DATE_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objUPD_USER = CType(FindControl("txtUPD_USER_" & CStr(i)), System.Web.UI.WebControls.TextBox)

            objNO.Attributes.Add("ReadOnly", "true")
            objTARGET.Checked = True
            objINS_DATE.Attributes.Add("ReadOnly", "true")
            objINS_USER.Attributes.Add("ReadOnly", "true")
            objUPD_DATE.Attributes.Add("ReadOnly", "true")
            objUPD_USER.Attributes.Add("ReadOnly", "true")
        Next
    End Sub

    '******************************************************************************
    '* 各コントロールの設定値の初期化
    '******************************************************************************
    Private Sub fncIni_format()
        '//--------------------------------------------------------------------------
        txtKURACD.Text = ""
        hdnKURACD.Value = ""
        txtGROUPCD_F.Text = ""
        hdnGROUPCD_F.Value = ""
        txtGROUPCD_T.Text = ""
        hdnGROUPCD_T.Value = ""

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
        hdnGROUPCD_F_MOTO.Value = ""
        hdnGROUPCD_T_MOTO.Value = ""

        Dim objTARGET As System.Web.UI.WebControls.CheckBox
        Dim objGROUPCD As System.Web.UI.WebControls.TextBox
        Dim objGROUPNM As System.Web.UI.WebControls.TextBox
        Dim objHANBAITENNM As System.Web.UI.WebControls.TextBox
        Dim objBIKO As System.Web.UI.WebControls.TextBox
        Dim objINS_DATE As System.Web.UI.WebControls.TextBox
        Dim objINS_USER As System.Web.UI.WebControls.TextBox
        Dim objUPD_DATE As System.Web.UI.WebControls.TextBox
        Dim objUPD_USER As System.Web.UI.WebControls.TextBox

        Dim i As Integer

        For i = 1 To 100
            'コントロール名を探し出し、型変換
            objTARGET = CType(FindControl("chkTARGET_" & CStr(i)), System.Web.UI.WebControls.CheckBox)
            objGROUPCD = CType(FindControl("txtGROUPCD_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objGROUPNM = CType(FindControl("txtGROUPNM_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objHANBAITENNM = CType(FindControl("txtHANBAITENNM_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objBIKO = CType(FindControl("txtBIKO_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objINS_DATE = CType(FindControl("txtINS_DATE_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objINS_USER = CType(FindControl("txtINS_USER_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objUPD_DATE = CType(FindControl("txtUPD_DATE_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objUPD_USER = CType(FindControl("txtUPD_USER_" & CStr(i)), System.Web.UI.WebControls.TextBox)


            objTARGET.Checked = True
            objGROUPCD.Text = ""
            objGROUPNM.Text = ""
            objHANBAITENNM.Text = ""
            objBIKO.Text = ""
            objINS_DATE.Text = ""
            objINS_USER.Text = ""
            objUPD_DATE.Text = ""
            objUPD_USER.Text = ""
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
            If hdnPopcrtl.Value = "1" Then      '//クライアントコード一覧
                strRec = AuthC.pAUTHCENTERCD    '//ＡＤ認証の使用可能監視センターコード
            ElseIf hdnPopcrtl.Value = "2" Then  '//グループコード（From）一覧
                strRec = AuthC.pAUTHCENTERCD    '//ＡＤ認証の使用可能監視センターコード
            ElseIf hdnPopcrtl.Value = "3" Then  '//グループコード（To）一覧
                strRec = AuthC.pAUTHCENTERCD    '//ＡＤ認証の使用可能監視センターコード
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
            If hdnPopcrtl.Value = "1" Then      '//クライアントコード一覧
                strRec = ""
            ElseIf hdnPopcrtl.Value = "2" Then  '//グループコード（From）一覧
                strRec = hdnKURACD.Value.Trim   '//クライアントコード
            ElseIf hdnPopcrtl.Value = "3" Then  '//グループコード（To）一覧
                strRec = hdnKURACD.Value.Trim   '//クライアントコード
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
                strRec = "クライアントコードコード一覧"
            ElseIf hdnPopcrtl.Value = "2" Then      '//ループコード（From）一覧
                strRec = "グループコード一覧"
            ElseIf hdnPopcrtl.Value = "3" Then      '//グループコード（To）一覧
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
            If hdnPopcrtl.Value = "1" Then
                strRec = "CLI"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = "HANBAITEN"
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = "HANBAITEN"
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
                strRec = "hdnGROUPCD_F"
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = "hdnGROUPCD_T"
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
                strRec = "txtGROUPCD_F"
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = "txtGROUPCD_T"
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
                strRec = "btnGROUPCD_F"
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = "btnGROUPCD_T"
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
    '*　概　要：表示をクリアするオブジェクトの名前を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pClear2() As String
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
    '*　概　要：表示をクリアするオブジェクトの名前を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pClear3() As String
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
    '*　概　要：表示をクリアするオブジェクトの名前を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pClear4() As String
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
                '2019/11/01 T.Ono mod 監視改善2019
                'strRec = ""
                strRec = "fncSetTo"
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
                '<TODO>100件以上の場合はメッセージ
                If dbData.Tables(0).Rows.Count > 100 Then
                    strMsg.Append("alert('最大出力件数を超えました。条件を指定して再度検索してください');")
                End If

                '------------------------------------
                '<TODO>データを出力する
                'クライアントコード
                If hdnKURACD.Value.Length <> 0 Then
                    hdnKURACD_MOTO.Value = hdnKURACD.Value.Trim
                Else
                    hdnKURACD_MOTO.Value = ""
                End If
                'JA支所コード
                If hdnGROUPCD_F.Value.Length <> 0 Then
                    hdnGROUPCD_F_MOTO.Value = hdnGROUPCD_F.Value.Trim
                Else
                    hdnGROUPCD_F_MOTO.Value = ""
                End If
                If hdnGROUPCD_T.Value.Length <> 0 Then
                    hdnGROUPCD_T_MOTO.Value = hdnGROUPCD_T.Value.Trim
                Else
                    hdnGROUPCD_T_MOTO.Value = ""
                End If


                Dim objGROUPCD As System.Web.UI.WebControls.TextBox
                Dim objGROUPNM As System.Web.UI.WebControls.TextBox
                Dim objHANBAITENNM As System.Web.UI.WebControls.TextBox
                Dim objBIKO As System.Web.UI.WebControls.TextBox
                Dim objINS_DATE As System.Web.UI.WebControls.TextBox
                Dim objINS_USER As System.Web.UI.WebControls.TextBox
                Dim objUPD_DATE As System.Web.UI.WebControls.TextBox
                Dim objUPD_USER As System.Web.UI.WebControls.TextBox

                Dim intRow As Integer

                For intRow = 0 To dbData.Tables(0).Rows.Count - 1

                    If intRow >= 100 Then Exit For '100件以上は処理抜け

                    '----------------------------
                    ' 明細情報を画面項目にセット
                    '----------------------------
                    'コントロール名を探し出し、型変換
                    objGROUPCD = CType(FindControl("txtGROUPCD_" & CStr(intRow + 1)), System.Web.UI.WebControls.TextBox)
                    objGROUPNM = CType(FindControl("txtGROUPNM_" & CStr(intRow + 1)), System.Web.UI.WebControls.TextBox)
                    objHANBAITENNM = CType(FindControl("txtHANBAITENNM_" & CStr(intRow + 1)), System.Web.UI.WebControls.TextBox)
                    objBIKO = CType(FindControl("txtBIKO_" & CStr(intRow + 1)), System.Web.UI.WebControls.TextBox)
                    objINS_DATE = CType(FindControl("txtINS_DATE_" & CStr(intRow + 1)), System.Web.UI.WebControls.TextBox)
                    objINS_USER = CType(FindControl("txtINS_USER_" & CStr(intRow + 1)), System.Web.UI.WebControls.TextBox)
                    objUPD_DATE = CType(FindControl("txtUPD_DATE_" & CStr(intRow + 1)), System.Web.UI.WebControls.TextBox)
                    objUPD_USER = CType(FindControl("txtUPD_USER_" & CStr(intRow + 1)), System.Web.UI.WebControls.TextBox)

                    'キー項目は変更不可にする
                    objGROUPCD.ReadOnly = True
                    objGROUPCD.BackColor = Color.Gainsboro

                    objGROUPCD.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("GROUPCD"))
                    objGROUPNM.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("GROUPNM"))
                    objHANBAITENNM.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("HANBAITENNM"))
                    objBIKO.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("BIKO"))
                    objINS_DATE.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("INS_DATE"))
                    objINS_USER.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("INS_USER"))
                    objUPD_DATE.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("UPD_DATE"))
                    objUPD_USER.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("UPD_USER"))

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
        Dim MSHATJAW00C As New MSHATJAG00MSHATJAW00.MSHATJAW00

        '値を配列にセット
        Dim objTARGET As System.Web.UI.WebControls.CheckBox
        Dim objGROUPCD As System.Web.UI.WebControls.TextBox
        Dim objGROUPNM As System.Web.UI.WebControls.TextBox
        Dim objHANBAITENNM As System.Web.UI.WebControls.TextBox
        Dim objBIKO As System.Web.UI.WebControls.TextBox
        Dim objINS_DATE As System.Web.UI.WebControls.TextBox
        Dim objINS_USER As System.Web.UI.WebControls.TextBox
        Dim objUPD_DATE As System.Web.UI.WebControls.TextBox
        Dim objUPD_USER As System.Web.UI.WebControls.TextBox


        Dim sTARGET(100) As String
        Dim sGROUPCD(100) As String
        Dim sGROUPNM(100) As String
        Dim sHANBAITENNM(100) As String
        Dim sBIKO(100) As String
        Dim sINS_DATE(100) As String
        Dim sINS_USER(100) As String
        Dim sUPD_DATE(100) As String
        Dim sUPD_USER(100) As String

        Dim i As Integer

        For i = 1 To 100
            'コントロール名を探し出し、型変換
            objTARGET = CType(FindControl("chkTARGET_" & CStr(i)), System.Web.UI.WebControls.CheckBox)
            objGROUPCD = CType(FindControl("txtGROUPCD_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objGROUPNM = CType(FindControl("txtGROUPNM_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objHANBAITENNM = CType(FindControl("txtHANBAITENNM_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objBIKO = CType(FindControl("txtBIKO_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objINS_DATE = CType(FindControl("txtINS_DATE_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objINS_USER = CType(FindControl("txtINS_USER_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objUPD_DATE = CType(FindControl("txtUPD_DATE_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objUPD_USER = CType(FindControl("txtUPD_USER_" & CStr(i)), System.Web.UI.WebControls.TextBox)

            If (objTARGET.Checked) Then
                sTARGET(i) = "true"
            Else
                sTARGET(i) = "false"
            End If
            sGROUPCD(i) = objGROUPCD.Text.Trim
            sGROUPNM(i) = objGROUPNM.Text.Trim
            sHANBAITENNM(i) = objHANBAITENNM.Text.Trim
            sBIKO(i) = objBIKO.Text.Trim
            sINS_DATE(i) = objINS_DATE.Text.Trim
            sINS_USER(i) = objINS_USER.Text.Trim
            sUPD_DATE(i) = objUPD_DATE.Text.Trim
            sUPD_USER(i) = objUPD_USER.Text.Trim
        Next

        strRec = MSHATJAW00C.mSetEx(
                    CInt(pstrKBN),
                    sTARGET,
                    sGROUPCD,
                    sGROUPNM,
                    sHANBAITENNM,
                    sBIKO,
                    sINS_DATE,
                    sINS_USER,
                    sUPD_DATE,
                    sUPD_USER,
                    AuthC.pUSERNAME
                    )

        '【共通】
        '  OK : 正常に終了しました
        '   0 : 他のユーザーによってデータが更新されています。再度検索してください
        '   1 : 既にデータが存在します
        '   2 : 対象データが存在しません
        '   3 : 排他制御処理でエラーが発生しました。再度実行してください
        Dim strRecTemp As String = strRec
        Dim strRecMsg As String
        Dim intRowNo As Integer = 0
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
            Case "6001" To "6100"
                'エラー行を返す。対象行は入力不可としない必要があるため。
                intRowNo = CInt(strRec.Substring(1))
                strRecMsg = "グループコードが不正です。\n先頭に所定のアルファベット2文字を入力してください"
                strMsg.Append("alert('" & strRecMsg & "');")
                '<TODO>フォーカスをセットする（登録・修正時でのエラー。監視センターコード検索補助ボタンにセット）
                strMsg.Append("Form1.btnSelect.focus();")
                ''<TODO>フォーカスをセットする（登録・修正時でのエラー。監視センターコード検索補助ボタンにセット）
                'strMsg.Append("Form1.txtGROUPCD_" & intRowNo & ".focus();")
            Case Else
                Dim ErrMsgC As New CErrMsg

                strMsg.Append("alert('システムエラー：" & ErrMsgC.mGetArtMsg(strRec) & "');")

                If pstrKBN = "1" Then
                    '//----------------------------------
                    '<TODO>フォーカスをセットする（登録処理：検索にセット）
                    strMsg.Append("Form1.btnSelect.focus();")
                ElseIf pstrKBN = "2" Then
                    '//----------------------------------
                    '<TODO>フォーカスをセットする（修正処理：検索にセット）
                    strMsg.Append("Form1.btnSelect.focus();")
                Else
                    '//----------------------------------
                    '<TODO>フォーカスをセットする（その他　：検索にセット）
                    strMsg.Append("Form1.btnSelect.focus();")
                End If
        End Select
        For i = 1 To 100
            objGROUPCD = CType(FindControl("txtGROUPCD_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            If objGROUPCD.Text <> "" AndAlso i <> intRowNo Then
                objGROUPCD.ReadOnly = True
                objGROUPCD.BackColor = Color.Gainsboro
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
        Dim SQLC As New MSHATJAG00CCSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet

        strSQL.Append("SELECT DISTINCT ")
        strSQL.Append("	A.GROUPCD ")
        strSQL.Append("	,A.GROUPNM ")
        strSQL.Append("	,A.HANBAITENNM ")
        strSQL.Append("	,A.BIKO ")
        strSQL.Append("	,TO_CHAR(A.INS_DATE, 'YYYY/MM/DD HH24:MI:SS') AS INS_DATE ")
        strSQL.Append("	,A.INS_USER ")
        strSQL.Append("	,TO_CHAR(A.UPD_DATE, 'YYYY/MM/DD HH24:MI:SS') AS UPD_DATE ")
        strSQL.Append("	,A.UPD_USER ")
        strSQL.Append("FROM M12_HANBAITEN A ")
        If hdnKURACD.Value.Trim.Length > 0 Then
            strSQL.Append("	,M09_JAGROUP B ")
        End If
        strSQL.Append("WHERE 1=1 ")
        If hdnKURACD.Value.Trim.Length > 0 Then
            strSQL.Append("AND B.KURACD = :KURACD ")
            strSQL.Append("AND A.GROUPCD = B.GROUPCD ")
            strSQL.Append("AND B.KBN = '004' ")
        End If
        If hdnGROUPCD_F.Value.Trim.Length > 0 Then
            strSQL.Append("AND A.GROUPCD >= :GROUPCD_F ")
        End If
        If hdnGROUPCD_T.Value.Trim.Length > 0 Then
            strSQL.Append("AND A.GROUPCD <= :GROUPCD_T ")
        End If
        strSQL.Append("ORDER BY A.GROUPCD ")


        'クライアントコード
        If hdnKURACD.Value.Trim.Length > 0 Then
            SqlParamC.fncSetParam("KURACD", True, hdnKURACD.Value.Trim)
        End If
        'グループコードFrom
        If hdnGROUPCD_F.Value.Trim.Length > 0 Then
            SqlParamC.fncSetParam("GROUPCD_F", True, hdnGROUPCD_F.Value.Trim)
        End If
        'グループコードTo
        If hdnGROUPCD_T.Value.Trim.Length > 0 Then
            SqlParamC.fncSetParam("GROUPCD_T", True, hdnGROUPCD_T.Value.Trim)
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
    Private Sub btnCSVOUT_ServerClick(ByVal sender As System.Object, _
                                    ByVal e As System.EventArgs) Handles btnCSVOUT.ServerClick
        Dim strRec As String
        Dim MSHATJAG00C As New MSHATJAG00MSHATJAW00.MSHATJAW00

        '//　認証クラスのインスタンス生成
        AuthC = New CAuthenticate(Request, Response)

        Dim strRecMsg As String = "ERROR"

        strRec = MSHATJAG00C.mCSV( _
                         Me.Session.SessionID, _
                         hdnKURACD.Value.Trim, _
                         hdnGROUPCD_F.Value.Trim, _
                         hdnGROUPCD_T.Value.Trim _
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
            HttpHeaderC.mDownLoadCSV(Response, "販売店グループマスタ.csv")
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
