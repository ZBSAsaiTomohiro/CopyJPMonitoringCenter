'***********************************************
'プルダウン設定マスタ  メイン画面
'***********************************************
Option Explicit On
Option Strict On

Imports Common
Imports Common.DB
Imports JPG.Common
Imports JPG.Common.log

Imports System.Text

Partial Class MSPULJAG00
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
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                                                                Handles MyBase.Load
        '2012/04/04 NEC ou Add
        '.NETの仕様変更により、ReadOnly属性をASPXでつけると、サーバ側で値の参照ができなくなるため、VB側でAttributeでつける
        If MyBase.IsPostBack = False Then
            txtKBN_NAME.Attributes.Add("ReadOnly", "true")
            txtAYMD.Attributes.Add("ReadOnly", "true")
            txtUYMD.Attributes.Add("ReadOnly", "true")
        End If
        '2012/04/04 NEC ou Add

        '//------------------------------------------
        '//　HTTPヘッダを送信
        HttpHeaderC.mNoCache(Response)

        '//------------------------------------------
        '//　認証クラスのインスタンス生成
        AuthC = New CAuthenticate(Request, Response)

        '//------------------------------------------
        '//　認証処理
        '<TODO>：使用可能権限を指定する
        '[プルダウンマスタ]使用可能権限(運:○/営:×/監:×/出:×)
        AuthC.fncAuthCheck(Server, AuthC.pGROUP_UNKOU)

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
             MyBase.MapPath("../../../MS/MSPULJAG/MSPULJAG00/") & "MSPULJAG00.js"))
        '<フォーカス関連関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncFo.js"))
        '<数値関連関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncNumChk.js"))
        '<入力チェック関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncChk.js"))

        strScript.Append("</Script>")
        '//------------------------------------------
        '//　Css格納
        strScript.Append("<Style>")
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "CssData.css"))
        strScript.Append("</Style>")
        '//------------------------------------------
        '//　Script書込み
        lblScript.Text = strScript.ToString

        '//------------------------------------------
        If MyBase.IsPostBack = False Then
            '//--------------------------------------
            '//初めて開いた時だけ実行される

            '//--------------------------------------
            '初期表示として必要なコントロールの設定を行います
            Call fncIni_format()    '//値の初期化

            '//--------------------------------------
            '初期画面の状態設定(画面を【検索前状態】にする（入力データはそのまま遷移させる)
            Call fncIni_statebf()

            '//--------------------------------------
            '<TODO>フォーカスをセットする（初期表示なのでキーにセットする）
            strMsg.Append("Form1.txtKBN.focus();")
        Else
            '//--------------------------------------
            '//２回目以降実行される
            '//--------------------------------------
        End If

        '//------------------------------------------
        '<TODO>自分の画面IDをHIDDENのhdnMyAspxに書き込む（システム共通）
        hdnMyAspx.Value = "MSPULJAG00"
        '//------------------------------------------

    End Sub

    '******************************************************************************
    '* 検索処理がされる前の画面状態（ReadOnlyやDisabled）
    '******************************************************************************
    Private Sub fncIni_statebf()
        btnUpdate.Disabled = False      '登録ボタン使用可能
        btnDelete.Disabled = True       '削除ボタン使用不可

        '//------------------------------------------
        '<TODO>検索前の状態にコントロールの状態を設定する
        '      すべての項目が使用可能(削除ボタン以外)
        '区分
        txtKBN.ReadOnly = False
        txtKBN.CssClass = "c-k"
        txtKBN.BackColor = Nothing
        '区分検索ボタン
        btnKenKBN.Disabled = False

        'コード
        txtCD.ReadOnly = False
        txtCD.CssClass = "c-k"
        txtCD.BackColor = Nothing
        'コード検索ボタン
        btnKenCD.Disabled = False
    End Sub

    '******************************************************************************
    '* 検索処理がされた後の画面状態（ReadOnlyやDisabled）
    '******************************************************************************
    Private Sub fncIni_stateaf()
        btnUpdate.Disabled = False      '登録ボタン使用可能
        btnDelete.Disabled = False      '削除ボタン使用可能

        '//------------------------------------------
        '<TODO>検索後の状態にコントロールの状態を設定する
        '区分
        txtKBN.ReadOnly = True
        txtKBN.CssClass = "c-RO"
        txtKBN.BackColor = System.Drawing.Color.Gainsboro
        '区分検索ボタン
        btnKenKBN.Disabled = True

        'コード
        txtCD.ReadOnly = True
        txtCD.CssClass = "c-RO"
        txtCD.BackColor = System.Drawing.Color.Gainsboro
        'コード検索ボタン
        btnKenCD.Disabled = True

        '2012/05/25 NEC ou Add Str
        txtKBN_NAME.Attributes.Add("ReadOnly", "true")
        txtAYMD.Attributes.Add("ReadOnly", "true")
        txtUYMD.Attributes.Add("ReadOnly", "true")
        '2012/05/25 NEC ou Add End
    End Sub

    '******************************************************************************
    '* 各コントロールの設定値の初期化
    '******************************************************************************
    Private Sub fncIni_format()
        '//--------------------------------------------------------------------------
        '<TODO>キーコントロールの値を初期化する
        txtKBN.Text = ""
        txtKBN_NAME.Text = ""
        txtCD.Text = ""

        'キー以外の値を初期化する
        Call fncIni_notkey()
    End Sub

    '******************************************************************************
    '* キー以外の値を初期化する
    '******************************************************************************
    Private Sub fncIni_notkey()
        Call fncIni_date()

        '//------------------------------------------
        '<TODO>コントロールの値を初期化する
        txtNAME.Text = ""
        txtDISP_NO.Text = ""
        txtNAIYO1.Text = ""
        txtNAIYO2.Text = ""
    End Sub

    '******************************************************************************
    '* 日付(作成日更新日)を初期化する
    '******************************************************************************
    Private Sub fncIni_date()
        txtAYMD.Text = ""
        txtUYMD.Text = ""
        hdnTIME.Value = ""
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
        '2012/04/04 NEC ou Upd
        'strRecLog = LogC.mAPLog(Request.Cookies.Get("ASP.NET_SessionId").Value, AuthC.pUSERNAME, AuthC.pIPADDRESS, hdnMyAspx.Value, "4", strRec, Request.Form)
        strRecLog = LogC.mAPLog(Me.Session.SessionID, AuthC.pUSERNAME, AuthC.pIPADDRESS, hdnMyAspx.Value, "4", strRec, Request.Form)
        '2012/04/04 NEC ou Upd
        If strRecLog <> "OK" Then
            Dim errmsgc As New CErrMsg
            strMsg.Append("alert('システムエラー：" & errmsgc.mGetArtMsg(strRecLog) & "');")
        End If

    End Sub

    '******************************************************************************
    '* 新規ボタンが押下されたときの処理
    '******************************************************************************
    Private Sub btnInsert_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsert.ServerClick
        Try
            '//--------------------------------------
            '新規登録チェックを行う
            Dim dbData As DataSet
            dbData = fncDataSelect(1)
            'If ds.Tables(0).Rows.Count = 0 Then
            If Convert.ToString(dbData.Tables(0).Rows(0).Item("CNT")) = "0" Then
                'データが存在しない為、新規登録は可能

                'キー項目以外を削除し、検索前状態にする。
                Call fncIni_notkey()
                Call fncIni_statebf()

                '//----------------------------------
                '<TODO>フォーカスをセットする（新規登録でデータが存在しないのでキー以降にセット）
                strMsg.Append("Form1.txtNAME.focus();")

            Else
                'データが存在する為、新規登録は不可

                'メッセージを出力後、検索前状態にする。
                strMsg.Append("alert('既にデータが存在します');")
                Call fncIni_statebf()

                '//----------------------------------
                '<TODO>フォーカスをセットする（新規登録でデータが存在するのでキーにセット）
                strMsg.Append("Form1.txtKBN.focus();")
            End If
            dbData.Dispose()

        Catch ex As Exception
            Dim ErrMsgC As New CErrMsg
            strMsg.Append("alert('システムエラー：" & ErrMsgC.mGetArtMsg(ex.ToString) & "');")
        End Try
    End Sub

    '******************************************************************************
    '* 登録ボタンが押下されたときの処理
    '******************************************************************************
    Private Sub btnUpdate_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.ServerClick
        Dim strRec As String
        strRec = fncbtnJikkou_ClickEvent(hdnKBN.Value)

        If hdnKBN.Value = "1" Then
            Call fncIni_statebf()
        Else
            If strRec = "OK" Then
                Call fncIni_statebf()
            Else
                Call fncIni_stateaf()
            End If
        End If
    End Sub

    '******************************************************************************
    '* 削除ボタンが押下されたときの処理
    '******************************************************************************
    Private Sub btnDelete_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.ServerClick
        Dim strRec As String
        strRec = fncbtnJikkou_ClickEvent("3")

        If strRec = "OK" Then
            Call fncIni_statebf()
        Else
            Call fncIni_stateaf()
        End If
    End Sub

    '******************************************************************************
    '* 取消ボタンが押下されたときの処理
    '******************************************************************************
    Private Sub btnClear_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.ServerClick
        Call fncIni_format()    '//値の初期化
        Call fncIni_statebf()   '//状態の初期化

        '//------------------------------------------
        '<TODO>フォーカスをセットする（初期画面に戻ったので(PageLoad同様)キーにセット）
        strMsg.Append("Form1.txtKBN.focus();")
    End Sub

    '******************************************************************************
    '*　概　要：絞込み条件を渡すプロパティ
    '*　備　考：抽出条件１の値を渡す
    '******************************************************************************
    Public ReadOnly Property pCode1() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then      '//プルダウン区分一覧：区分を条件に渡す
                strRec = ""
            ElseIf hdnPopcrtl.Value = "2" Then  '//プルダウンコード一覧：区分を条件に渡す
                strRec = txtKBN.Text
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
            If hdnPopcrtl.Value = "1" Then
                strRec = "プルダウン区分一覧"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = "プルダウンコード一覧"
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
                strRec = "PULLKBN"
            ElseIf hdnPopcrtl.Value = "2" Then
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
            If hdnPopcrtl.Value = "1" Then      '//区分にコードを返す
                strRec = "txtKBN"
            ElseIf hdnPopcrtl.Value = "2" Then  '//コードにコードを返す
                strRec = "txtCD"
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
            If hdnPopcrtl.Value = "1" Then      '//区分名に名称を返す
                strRec = "txtKBN_NAME"
            ElseIf hdnPopcrtl.Value = "2" Then  '//
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
            If hdnPopcrtl.Value = "1" Then      '//区分にフォーカスをセット
                strRec = "txtKBN"
            ElseIf hdnPopcrtl.Value = "2" Then  '//コードにフォーカスをセット
                strRec = "txtCD"
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：フォーカスを返した後に実行するJS名を渡すプロパティ
    '*　備　考：2005.01.27 J.Katayama 県を変更した場合JA支所コードを削除する
    '******************************************************************************
    Public ReadOnly Property pBackScript() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then      '//
                strRec = "fncPopfunction"
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
    '*　概　要：
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pClear1() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "txtCD"
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

        Try
            '//--------------------------------------
            '検索処理を行う
            Dim DateFncC As New CDateFnc
            Dim dbData As DataSet
            dbData = fncDataSelect(0)
            If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
                'データが存在しない為、検索はエラー
                'メッセージを出力後、検索前状態にする。

                strMsg.Append("alert('データが存在しません');")

                Call fncIni_statebf()

                '//----------------------------------
                '<TODO>フォーカスをセットする（データが存在しないのでキーにセット）
                strMsg.Append("Form1.txtKBN.focus();")
            Else
                'データが存在する為、新規登録は不可
                'データを出力後、検索後状態にする。

                '------------------------------------
                '<TODO>データを出力する
                txtKBN.Text = Convert.ToString(dbData.Tables(0).Rows(0).Item("KBN"))
                txtKBN_NAME.Text = Convert.ToString(dbData.Tables(0).Rows(0).Item("KBNNM"))
                txtCD.Text = Convert.ToString(dbData.Tables(0).Rows(0).Item("CD"))
                txtNAME.Text = Convert.ToString(dbData.Tables(0).Rows(0).Item("NAME"))
                txtNAIYO1.Text = Convert.ToString(dbData.Tables(0).Rows(0).Item("NAIYO1"))
                txtNAIYO2.Text = Convert.ToString(dbData.Tables(0).Rows(0).Item("NAIYO2"))
                txtDISP_NO.Text = Convert.ToString(dbData.Tables(0).Rows(0).Item("DISP_NO"))
                '※下記３項目は必須※
                txtAYMD.Text = DateFncC.mGet(Convert.ToString(dbData.Tables(0).Rows(0).Item("ADD_DATE")))
                txtUYMD.Text = DateFncC.mGet(Convert.ToString(dbData.Tables(0).Rows(0).Item("EDT_DATE")))
                hdnTIME.Value = Convert.ToString(dbData.Tables(0).Rows(0).Item("TIME"))

                If pstrKBN = "1" Then
                    '検索ボタン押下時
                    Call fncIni_stateaf()

                    '//------------------------------
                    '<TODO>フォーカスをセットする（データが存在したのでキー以外にセット）
                    strMsg.Append("Form1.txtNAME.focus();")
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
        Dim MSPULJAW00C As New MSPULJAG00MSPULJAW00.MSPULJAW00

        '--------------------------------------------
        '<TODO>WEBサービスを呼び出す
        strRec = MSPULJAW00C.mSet( _
                            CInt(pstrKBN), _
                            txtKBN.Text, _
                            txtCD.Text, _
                            txtNAME.Text, _
                            txtNAIYO1.Text, _
                            txtNAIYO2.Text, _
                            txtDISP_NO.Text, _
                            DateFncC.mHenkanGet(txtAYMD.Text), _
                            DateFncC.mHenkanGet(txtUYMD.Text), _
                            hdnTIME.Value)

        '--------------------------------------------
        '<TODO>返り値による制御を行う。
        '【共通】
        '  OK : 正常に終了しました
        '   0 : 他のユーザーによってデータが更新されています。再度検索してください
        '   1 : 既にデータが存在します
        '   2 : 対象データが存在しません
        '   3 : 排他制御処理でエラーが発生しました。再度実行してください

        Dim strRecMsg As String
        Select Case strRec
            Case "OK"
                If pstrKBN = "1" Or pstrKBN = "2" Then
                    Call fncbtnKensaku_ClickEvent("2")
                Else
                    Call fncIni_date()
                End If
                strMsg.Append("alert('正常に終了しました');")

                '//------------------------------
                '<TODO>フォーカスをセットする（正常終了後は初期状態になるのでキーにセット）
                strMsg.Append("Form1.txtKBN.focus();")
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
                '<TODO>フォーカスをセットする（登録時でのエラー。キーにセット）
                strMsg.Append("Form1.txtKBN.focus();")

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
                strRecMsg = "区分が存在しません"
                strMsg.Append("alert('" & strRecMsg & "');")

                '<TODO>フォーカスをセットする（登録・修正時でのエラー。区分にセット）
                strMsg.Append("Form1.txtKBN.focus();")

                strRec = strRecMsg
            Case Else
                Dim ErrMsgC As New CErrMsg

                strMsg.Append("alert('システムエラー：" & ErrMsgC.mGetArtMsg(strRec) & "');")

                If pstrKBN = "1" Then
                    '//----------------------------------
                    '<TODO>フォーカスをセットする（登録処理：ログ出力のエラーの為キーにセット）
                    strMsg.Append("Form1.txtKBN.focus();")
                ElseIf pstrKBN = "2" Then
                    '//----------------------------------
                    '<TODO>フォーカスをセットする（修正処理：ログ出力のエラーの為キー以降にセット）
                    strMsg.Append("Form1.txtNAME.focus();")
                Else
                    '//----------------------------------
                    '<TODO>フォーカスをセットする（その他　：ログ出力のエラーの為キー以降にセット）
                    strMsg.Append("Form1.txtNAME.focus();")
                End If
        End Select

        '-------------------------------------------------
        '//ＡＰログ書き込み
        Dim LogC As New CLog
        Dim strRecLog As String
        '2012/04/04 NEC ou Upd
        'strRecLog = LogC.mAPLog(Request.Cookies.Get("ASP.NET_SessionId").Value, AuthC.pUSERNAME, AuthC.pIPADDRESS, hdnMyAspx.Value, pstrKBN, strRec, Request.Form)
        strRecLog = LogC.mAPLog(Me.Session.SessionID, AuthC.pUSERNAME, AuthC.pIPADDRESS, hdnMyAspx.Value, pstrKBN, strRec, Request.Form)
        '2012/04/04 NEC ou Upd
        If strRecLog <> "OK" Then
            Dim errmsgc As New CErrMsg
            strMsg.Append("alert('システムエラー：" & errmsgc.mGetArtMsg(strRecLog) & "');")
        End If

        Return strRec
    End Function

    '******************************************************************************
    '* 入力キーによるデータの検索を行います。
    '* pintKbn　0:検索ボタン押下時データ出力
    '*        　1:新規ボタン押下時データカウント出力
    '******************************************************************************
    Private Function fncDataSelect(ByVal pintKbn As Integer) As DataSet
        'intKbn     0:検索ボタン押下
        'intKbn     1:新規ボタン押下

        '//------------------------------------------
        '//<TODO>Select文の作成
        Dim SQLC As New MSPULJAG00CCSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet
        'Dim cdb As New CDB
        'Dim dbData As New DataSet
        'Dim strSQL As New StringBuilder("")
        'cdb.mOpen()
        strSQL.Append("SELECT ")
        If pintKbn = 0 Then
            '検索なので全ての項目を取得します
            strSQL.Append("PL.KBN, ")
            strSQL.Append("PM.NAME AS KBNNM, ")
            strSQL.Append("PL.CD, ")
            strSQL.Append("PL.NAME, ")
            strSQL.Append("PL.NAIYO1, ")
            strSQL.Append("PL.NAIYO2, ")
            strSQL.Append("PL.DISP_NO, ")
            strSQL.Append("PL.ADD_DATE, ")
            strSQL.Append("PL.EDT_DATE, ")
            strSQL.Append("PL.TIME ")
        Else
            '新規なので対象データのカウントを取得します
            strSQL.Append("COUNT(*) AS CNT ")
        End If
        strSQL.Append("FROM  M06_PULLDOWN PL, ")
        strSQL.Append("      M06_PULLDOWN PM ")
        strSQL.Append("WHERE PL.KBN  = :KBN ")
        strSQL.Append("  AND PL.CD = :CD ")
        strSQL.Append("  AND PM.KBN = '00' ")
        strSQL.Append("  AND PM.CD = PL.KBN ")

        SqlParamC.fncSetParam("KBN", True, txtKBN.Text)
        SqlParamC.fncSetParam("CD", True, txtCD.Text)

        dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

        'cdb.pSQL = strSQL.ToString
        'cdb.pSQLParamStr("KBN") = txtKBN.Text
        'cdb.pSQLParamStr("CD") = txtCD.Text
        'cdb.mExecQuery()
        'dbData = cdb.pResult    '結果をデータセットに格納
        'cdb.mClose()
        'cdb = Nothing
        Return dbData
    End Function

End Class
