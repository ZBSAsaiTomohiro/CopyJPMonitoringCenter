'***********************************************
' 供給センターマスタ  メイン画面
'***********************************************
' 変更履歴

Option Explicit On
Option Strict On

Imports Common
Imports Common.DB
Imports JPG.Common
Imports JPG.Common.log

Imports System.Text

Partial Class MSKYOJAG00
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

    '******************************************************************************
    ' Page_Load
    '******************************************************************************
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '2012/04/03 NEC ou Add
        '.NETの仕様変更により、ReadOnly属性をASPXでつけると、サーバ側で値の参照ができなくなるため、VB側でAttributeでつける
        If MyBase.IsPostBack = False Then
            txtKENCD.Attributes.Add("ReadOnly", "true")
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
             MyBase.MapPath("../../../MS/MSKYOJAG/MSKYOJAG00/") & "MSKYOJAG00.js"))
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


        End If

        '<TODO>自分の画面IDをHIDDENのhdnMyAspxに書き込む（システム共通）
        hdnMyAspx.Value = "MSKYOJAG00"
        '//-------------------------------------------------

    End Sub

    '******************************************************************************
    '* 検索処理がされる前の画面状態（ReadOnlyやDisabled）
    '********************************/*********************************************
    Private Sub fncIni_statebf()
        '//--------------------------------------------------------------------------
        '<TODO>検索前の状態にコントロールの状態を設定する

        btnKENCD.Disabled = False

    End Sub

    '******************************************************************************
    '* 検索処理がされた後の画面状態（ReadOnlyやDisabled）
    '******************************************************************************
    Private Sub fncIni_stateaf()
        '//--------------------------------------------------------------------------
        '<TODO>検索後の状態にコントロールの状態を設定する
        '

        txtKENCD.Attributes.Add("ReadOnly", "true")
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
        txtKENCD.Text = ""
        hdnKENCD.Value = ""


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

        hdnKENCD_MOTO.Value = ""

        Dim objEDT_DT As System.Web.UI.HtmlControls.HtmlInputHidden
        Dim objDISP_NO As System.Web.UI.HtmlControls.HtmlInputHidden
        Dim objKYOKYUCD As System.Web.UI.WebControls.TextBox
        Dim objKYOKYUNM As System.Web.UI.WebControls.TextBox
        Dim objDEL As System.Web.UI.WebControls.CheckBox
        Dim i As Integer
        For i = 1 To 30
            objEDT_DT = CType(FindControl("hdnEDT_DT_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden) 'コントロール名を探し出し、型変換
            objDISP_NO = CType(FindControl("hdnDISP_NO_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKYOKYUCD = CType(FindControl("txtKYOKYU_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objKYOKYUNM = CType(FindControl("txtKYOKYUNM_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objDEL = CType(FindControl("chkDEL_" & CStr(i)), System.Web.UI.WebControls.CheckBox)

            objEDT_DT.Value = ""
            objDISP_NO.Value = CStr(i) '機械的に番号を付ける
            objKYOKYUCD.Text = ""
            objKYOKYUNM.Text = ""
            objDEL.Checked = False
        Next

    End Sub

    '******************************************************************************
    '* 日付(作成日更新日)を初期化する
    '******************************************************************************
    Private Sub fncIni_date()

        txtAYMD.Value = ""
        txtUYMD.Value = ""
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
            ElseIf hdnPopcrtl.Value = "2" Then      '//コード一覧
                strRec = hdnKENCD.Value        '//ＪＡ支所コード一覧
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
            Dim strRec As String = ""
            If hdnPopcrtl.Value = "1" Then          '//県コード一覧
                strRec = "県コード一覧"
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
            Dim strRec As String = ""
            If hdnPopcrtl.Value = "1" Then          '//県コード一覧
                strRec = "KENCD"
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
            Dim strRec As String = ""
            If hdnPopcrtl.Value = "1" Then
                strRec = "hdnKENCD"
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
            Dim strRec As String = ""
            If hdnPopcrtl.Value = "1" Then
                strRec = "txtKENCD"
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
            Dim strRec As String = ""
            If hdnPopcrtl.Value = "1" Then
                strRec = "btnKENCD"
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

            dbData = fncDataSelect(0)
            'If ds.Tables(0).Rows.Count = 0 Then
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
                If dbData.Tables(0).Rows.Count > 30 Then
                    strMsg.Append("alert('最大出力件数を超えました。条件を指定して再度検索してください');")
                End If

                '県コード
                hdnKENCD.Value = Convert.ToString(dbData.Tables(0).Rows(0).Item("KEN_CD"))
                hdnKENCD_MOTO.Value = Convert.ToString(dbData.Tables(0).Rows(0).Item("KEN_CD"))
                '県名
                txtKENCD.Text = Convert.ToString(dbData.Tables(0).Rows(0).Item("KEN_CD")) & " : " & Convert.ToString(dbData.Tables(0).Rows(0).Item("KEN_NAME"))
                Dim sMinAddDate As String
                Dim sMaxEdtDate As String
                Dim sMaxTime As String
                sMinAddDate = DateFncC.mGet(Convert.ToString(dbData.Tables(0).Rows(0).Item("ADD_DATE")))
                sMaxEdtDate = DateFncC.mGet(Convert.ToString(dbData.Tables(0).Rows(0).Item("EDT_DATE")))
                sMaxTime = Convert.ToString(dbData.Tables(0).Rows(0).Item("TIME"))

                Dim objDISP_NO As System.Web.UI.HtmlControls.HtmlInputHidden
                Dim objKYOKYUCD As System.Web.UI.WebControls.TextBox
                Dim objKYOKYUNM As System.Web.UI.WebControls.TextBox
                Dim objEDT_DT As System.Web.UI.HtmlControls.HtmlInputHidden
                Dim objADD_DT As System.Web.UI.HtmlControls.HtmlInputHidden

                Dim i As Integer
                Dim intRow As Integer
                Dim sDispNo As String

                For intRow = 0 To dbData.Tables(0).Rows.Count - 1

                    If intRow >= 30 Then Exit For '30件以上は処理抜け

                    '----------------------------
                    ' 最初の登録日、最後の更新日時を画面項目にセット
                    '----------------------------
                    '登録日が空か、以前の場合、セット
                    If sMinAddDate = "" _
                        Or DateFncC.mGet(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("ADD_DATE"))) < sMinAddDate Then
                        sMinAddDate = DateFncC.mGet(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("ADD_DATE")))
                    End If
                    '更新日が空か、さらに後の場合、セット
                    If DateFncC.mGet(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("EDT_DATE"))) <> "" _
                        And DateFncC.mGet(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("EDT_DATE"))) >= sMaxEdtDate Then
                        sMaxEdtDate = DateFncC.mGet(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("EDT_DATE")))

                        '時刻が空か、さらに後の時間の場合、セット
                        If sMaxTime = "" _
                            Or Convert.ToString(dbData.Tables(0).Rows(intRow).Item("TIME")) >= sMaxTime Then
                            sMaxTime = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("TIME"))
                        End If
                    End If

                    '----------------------------
                    ' 明細情報を画面項目にセット
                    '----------------------------
                    i = intRow + 1

                    objDISP_NO = CType(FindControl("hdnDISP_NO_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
                    objKYOKYUCD = CType(FindControl("txtKYOKYU_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                    objKYOKYUNM = CType(FindControl("txtKYOKYUNM_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                    objEDT_DT = CType(FindControl("hdnEDT_DT_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
                    objADD_DT = CType(FindControl("hdnADD_DT_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
                    objKYOKYUCD.ReadOnly = True
                    objKYOKYUCD.BackColor = Color.Gainsboro

                    objDISP_NO.Value = CStr(i)
                    objADD_DT.Value = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("ADD_DATE"))
                    objEDT_DT.Value = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("EDT_DATE")) & Convert.ToString(dbData.Tables(0).Rows(intRow).Item("TIME"))
                    objKYOKYUCD.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("HAISO_CD"))
                    objKYOKYUNM.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("NAME"))
                Next ' intRow


                txtAYMD.Value = sMinAddDate
                txtUYMD.Value = sMaxEdtDate
                hdnTIME.Value = sMaxTime

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

        Dim MSKYOJAW00C As New MSKYOJAG00MSKYOJAW00.MSKYOJAW00

        Dim strKENCD As String
        strKENCD = hdnKENCD.Value

        '値を配列にセット
        Dim objADD_DT As System.Web.UI.HtmlControls.HtmlInputHidden
        Dim objEDT_DT As System.Web.UI.HtmlControls.HtmlInputHidden
        Dim objDISP_NO As System.Web.UI.HtmlControls.HtmlInputHidden
        Dim objKYOKYUCD As System.Web.UI.WebControls.TextBox
        Dim objKYOKYUNM As System.Web.UI.WebControls.TextBox
        Dim objDEL As System.Web.UI.WebControls.CheckBox
        Dim sADD_DT(30) As String
        Dim sEDT_DT(30) As String
        Dim sDISP_NO(30) As String
        Dim sKYOKYUCD(30) As String
        Dim sKYOKYUNM(30) As String
        Dim sDEL(30) As String
        Dim i As Integer
        For i = 1 To 30
            objADD_DT = CType(FindControl("hdnADD_DT_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden) 'コントロール名を探し出し、型変換
            objEDT_DT = CType(FindControl("hdnEDT_DT_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden) 'コントロール名を探し出し、型変換
            objDISP_NO = CType(FindControl("hdnDISP_NO_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKYOKYUCD = CType(FindControl("txtKYOKYU_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objKYOKYUNM = CType(FindControl("txtKYOKYUNM_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objDEL = CType(FindControl("chkDEL_" & CStr(i)), System.Web.UI.WebControls.CheckBox)

            sADD_DT(i) = objADD_DT.Value
            sEDT_DT(i) = objEDT_DT.Value
            sDISP_NO(i) = objDISP_NO.Value
            sKYOKYUCD(i) = objKYOKYUCD.Text
            sKYOKYUNM(i) = Trim(objKYOKYUNM.Text)
            If (objDEL.Checked) Then
                sDEL(i) = "true"
            Else
                sDEL(i) = "false"
            End If

        Next
        strRec = MSKYOJAW00C.mSetEx( _
                    CInt(pstrKBN), _
                    strKENCD, _
                    sKYOKYUCD, _
                    sKYOKYUNM, _
                    sDEL, _
                    DateFncC.mHenkanGet(txtAYMD.Value), _
                    DateFncC.mHenkanGet(txtUYMD.Value), _
                    hdnTIME.Value, _
                    sADD_DT,
                    sEDT_DT)

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
                Else
                    strRec = fncbtnKensaku_ClickEvent("2")
                End If
                strMsg.Append("alert('正常に終了しました');")

                '//------------------------------
                strMsg.Append("Form1.btnSelect.focus();")

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
                strMsg.Append("Form1.btnSelect.focus();")
                strRec = strRecMsg
            Case "4"
                strRecMsg = "県コードが存在しません"
                strMsg.Append("alert('" & strRecMsg & "');")

                '<TODO>フォーカスをセットする（登録・修正時でのエラー。クライアントコード検索補助ボタンにセット）
                strMsg.Append("Form1.btnSelect.focus();")

                strRec = strRecMsg

            Case "8"        
                strRecMsg = "供給センターコードが重複しています"
                strMsg.Append("alert('" & strRecMsg & "');")

                '<TODO>フォーカスをセットする（登録・修正時でのエラー。コード検索補助ボタンにセット）
                strMsg.Append("Form1.txtKYOKYU_1.focus();")

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
                    strMsg.Append("Form1.txtKYOKYU_1.focus();")
                Else
                    '//----------------------------------
                    '<TODO>フォーカスをセットする（その他　：ログ出力のエラーの為キー以降にセット）
                    strMsg.Append("Form1.txtKYOKYU_1.focus();")
                End If
        End Select
        For i = 1 To 30
            objKYOKYUCD = CType(FindControl("txtKYOKYU_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            If objKYOKYUCD.Text <> "" Then
                objKYOKYUCD.ReadOnly = True
                objKYOKYUCD.BackColor = Color.Gainsboro
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
    '* pintKbn　0:検索ボタン押下時データ出力
    '*        　1:新規ボタン押下時データカウント出力
    '******************************************************************************
    Private Function fncDataSelect(ByVal pintkbn As Integer) As DataSet

        'intKbn     0:検索ボタン押下
        'intKbn     1:新規ボタン押下

        '//------------------------------------------
        '//<TODO>Select文の作成
        Dim SQLC As New MSKYOJAG00CCSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet
        'Dim cdb As New CDB
        'Dim dbData As New DataSet
        'Dim strSQL As New StringBuilder("")
        'cdb.mOpen()
        strSQL.Append("SELECT ")
        If pintkbn = 0 Then
            '検索なので全ての項目を取得します
            strSQL.Append("A.KEN_CD, ")
            strSQL.Append("B.KEN_NAME, ")
            strSQL.Append("A.HAISO_CD, ")
            strSQL.Append("A.NAME, ")
            strSQL.Append("A.ADD_DATE, ")
            strSQL.Append("A.EDT_DATE, ")
            strSQL.Append("A.TIME ")
        Else
            '新規なので対象データのカウントを取得します
            strSQL.Append("COUNT(*) AS CNT ")
        End If
        strSQL.Append("FROM  HAIMAS A, ")
        strSQL.Append("(SELECT DISTINCT ")
        strSQL.Append(" KEN_CODE, ")
        strSQL.Append(" KEN_NAME ")
        strSQL.Append("FROM CLIMAS ")
        strSQL.Append("WHERE KANSI_CODE IS NOT NULL ")
        strSQL.Append(") B ")
        strSQL.Append("WHERE A.KEN_CD   = :KEN_CD ")
        strSQL.Append("AND A.KEN_CD   = B.KEN_CODE(+) ")

        If pintkbn = 0 Then
            strSQL.Append(" ORDER BY TO_NUMBER(HAISO_CD) ")
        End If
        If hdnKENCD.Value.Length > 0 Then
            SqlParamC.fncSetParam("KEN_CD", True, hdnKENCD.Value)
        End If

        dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)
        'cdb.pSQL = strSQL.ToString
        'If hdnKENCD.Value.Length > 0 Then
        '    cdb.pSQLParamStr("KEN_CD") = hdnKENCD.Value
        'End If
        'cdb.mExecQuery()
        'dbData = cdb.pResult    '結果をデータセットに格納
        'cdb.mClose()
        'cdb = Nothing
        Return (dbData)
    End Function
    '******************************************************************************
    ' Excel出力(チェックつき)
    '******************************************************************************
    Private Sub btnCSVout_ServerClick(ByVal sender As System.Object, _
                                    ByVal e As System.EventArgs) Handles btnCSVout.ServerClick
        Dim strRec As String
        Dim MSKYOJAG00C As New MSKYOJAG00MSKYOJAW00.MSKYOJAW00

        '//　認証クラスのインスタンス生成
        AuthC = New CAuthenticate(Request, Response)

        Dim strRecMsg As String = ""

        strRec = MSKYOJAG00C.mCSV( _
                         Me.Session.SessionID, _
                         hdnKENCD.Value _
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
            HttpHeaderC.mDownLoadCSV(Response, "供給センターマスタ.csv")
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
