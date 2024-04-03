'***********************************************
' 累積情報自動FAX&メールマスタ  メイン画面
'***********************************************
' 変更履歴

Option Explicit On
Option Strict On

Imports Common
Imports Common.DB
Imports JPG.Common
Imports JPG.Common.log

Imports System.Text

Partial Class MSRUIJAG00
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
            txtKURACD.Attributes.Add("ReadOnly", "true")
            txtACBCD_F.Attributes.Add("ReadOnly", "true") '2014/03/10 T.Ono add 絞込み条件追加
            txtACBCD_T.Attributes.Add("ReadOnly", "true") '2014/03/10 T.Ono add 絞込み条件追加
            Dim objDefNO As System.Web.UI.WebControls.TextBox
            Dim objDefDEL As System.Web.UI.WebControls.CheckBox
            Dim objHASSEI As System.Web.UI.WebControls.DropDownList
            Dim objKAIPAGE As System.Web.UI.WebControls.DropDownList
            Dim objKIKAN As System.Web.UI.WebControls.DropDownList
            Dim objZEROSEND As System.Web.UI.WebControls.DropDownList    '2020/11/01 T.Ono add 2020監視改善
            Dim objSD_PRT As System.Web.UI.WebControls.DropDownList
            Dim objSENDSTOP As System.Web.UI.WebControls.DropDownList
            Dim objLSTSEND As System.Web.UI.WebControls.TextBox

            Dim i As Integer
            For i = 1 To 30
                objDefNO = CType(FindControl("txtNO_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                objDefDEL = CType(FindControl("chkDEL_" & CStr(i)), System.Web.UI.WebControls.CheckBox)
                objHASSEI = CType(FindControl("listHASSEI_" & CStr(i)), System.Web.UI.WebControls.DropDownList)
                objKAIPAGE = CType(FindControl("listKAIPAGE_" & CStr(i)), System.Web.UI.WebControls.DropDownList)
                objKIKAN = CType(FindControl("listKIKAN_" & CStr(i)), System.Web.UI.WebControls.DropDownList)
                objZEROSEND = CType(FindControl("listZEROSND_" & CStr(i)), System.Web.UI.WebControls.DropDownList)    '2020/11/01 T.Ono add 2020監視改善
                objSD_PRT = CType(FindControl("listSD_PRT_" & CStr(i)), System.Web.UI.WebControls.DropDownList)
                objSENDSTOP = CType(FindControl("listSNDSTOP_" & CStr(i)), System.Web.UI.WebControls.DropDownList)
                objLSTSEND = CType(FindControl("txtLSSEND_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                objDefNO.Attributes.Add("ReadOnly", "true")
                objLSTSEND.Attributes.Add("ReadOnly", "true")
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
             MyBase.MapPath("../../../MS/MSRUIJAG/MSRUIJAG00/") & "MSRUIJAG00.js"))
        '<フォーカス関連関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncFo.js"))
        '<入力チェック関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncChk.js"))
        '<入力チェック関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncDate.js"))
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
        hdnMyAspx.Value = "MSRUIJAG00"
        '//-------------------------------------------------

    End Sub

    '******************************************************************************
    '* 検索処理がされる前の画面状態（ReadOnlyやDisabled）
    '********************************/*********************************************
    Private Sub fncIni_statebf()
        '//--------------------------------------------------------------------------
        '<TODO>検索前の状態にコントロールの状態を設定する

        btnKURACD.Disabled = False

    End Sub

    '******************************************************************************
    '* 検索処理がされた後の画面状態（ReadOnlyやDisabled）
    '******************************************************************************
    Private Sub fncIni_stateaf()
        '//--------------------------------------------------------------------------
        '<TODO>検索後の状態にコントロールの状態を設定する
        '

        txtKURACD.Attributes.Add("ReadOnly", "true")
        txtACBCD_F.Attributes.Add("ReadOnly", "true") '2014/03/10 T.Ono add 絞込み条件追加
        txtACBCD_T.Attributes.Add("ReadOnly", "true") '2014/03/10 T.Ono add 絞込み条件追加
        Dim objDefNO As System.Web.UI.WebControls.TextBox
        Dim objDefDEL As System.Web.UI.WebControls.CheckBox
        Dim objLSTSEND As System.Web.UI.WebControls.TextBox

        Dim i As Integer
        For i = 1 To 30
            objDefNO = CType(FindControl("txtNO_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objDefDEL = CType(FindControl("chkDEL_" & CStr(i)), System.Web.UI.WebControls.CheckBox)
            objLSTSEND = CType(FindControl("txtLSSEND_" & CStr(i)), System.Web.UI.WebControls.TextBox)

            objDefNO.Attributes.Add("ReadOnly", "true")
            objLSTSEND.Attributes.Add("ReadOnly", "true")
            objDefDEL.Checked = False

        Next
    End Sub

    '******************************************************************************
    '* 各コントロールの設定値の初期化
    '******************************************************************************
    Private Sub fncIni_format()
        '//--------------------------------------------------------------------------
        txtKURACD.Text = ""
        hdnKURACD.Value = ""
        txtACBCD_F.Text = ""   '2014/03/10 T.Ono mod 絞込み条件追加
        hdnACBCD_F.Value = ""  '2014/03/10 T.Ono mod 絞込み条件追加
        txtACBCD_T.Text = ""   '2014/03/10 T.Ono mod 絞込み条件追加
        hdnACBCD_T.Value = ""  '2014/03/10 T.Ono mod 絞込み条件追加


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

        Dim objID As System.Web.UI.HtmlControls.HtmlInputHidden
        Dim objDISP_NO As System.Web.UI.HtmlControls.HtmlInputHidden
        Dim objSEND As System.Web.UI.WebControls.TextBox
        Dim objKYOKYUCD As System.Web.UI.WebControls.TextBox
        Dim objACBCDFR As System.Web.UI.WebControls.TextBox
        Dim objACBCDTO As System.Web.UI.WebControls.TextBox
        Dim objFAX1 As System.Web.UI.WebControls.TextBox
        Dim objFAX2 As System.Web.UI.WebControls.TextBox
        Dim objMAIL1 As System.Web.UI.WebControls.TextBox
        Dim objMAIL2 As System.Web.UI.WebControls.TextBox
        Dim objNXSEND As System.Web.UI.WebControls.TextBox
        Dim objLSSEND As System.Web.UI.WebControls.TextBox
        Dim objSENDSTR As System.Web.UI.WebControls.TextBox
        Dim objSENDEND As System.Web.UI.WebControls.TextBox
        Dim objMAILPASS As System.Web.UI.WebControls.TextBox
        Dim objZIPFILE As System.Web.UI.WebControls.TextBox
        Dim objBIKOU As System.Web.UI.WebControls.TextBox

        Dim objEDT_DT As System.Web.UI.HtmlControls.HtmlInputHidden
        Dim objADD_DT As System.Web.UI.HtmlControls.HtmlInputHidden
        Dim objDEL As System.Web.UI.WebControls.CheckBox
        Dim i As Integer
        For i = 1 To 30
            objID = CType(FindControl("hdnID_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
            objDISP_NO = CType(FindControl("hdnDISP_NO_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKYOKYUCD = CType(FindControl("txtKYOKYU_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objEDT_DT = CType(FindControl("hdnEDT_DT_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
            objADD_DT = CType(FindControl("hdnADD_DT_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
            objSEND = CType(FindControl("txtSEND_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objACBCDFR = CType(FindControl("txtACBCDFR_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objACBCDTO = CType(FindControl("txtACBCDTO_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objFAX1 = CType(FindControl("txtFAX1_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objFAX2 = CType(FindControl("txtFAX2_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objMAIL1 = CType(FindControl("txtMAIL1_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objMAIL2 = CType(FindControl("txtMAIL2_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objNXSEND = CType(FindControl("txtNXSEND_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objLSSEND = CType(FindControl("txtLSSEND_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objSENDSTR = CType(FindControl("txtSENDSTR_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objSENDEND = CType(FindControl("txtSENDEND_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objMAILPASS = CType(FindControl("txtMAILPASS_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objZIPFILE = CType(FindControl("txtZIP_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objBIKOU = CType(FindControl("txtBIKOU_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objDEL = CType(FindControl("chkDEL_" & CStr(i)), System.Web.UI.WebControls.CheckBox)

            objID.Value = ""
            objDISP_NO.Value = CStr(i) '機械的に番号を付ける
            objKYOKYUCD.Text = ""
            objEDT_DT.Value = ""
            objADD_DT.Value = ""
            objKYOKYUCD.Text = ""
            objSEND.Text = ""
            objACBCDFR.Text = ""
            objACBCDTO.Text = ""
            objFAX1.Text = ""
            objFAX2.Text = ""
            objMAIL1.Text = ""
            objMAIL2.Text = ""
            objNXSEND.Text = ""
            objLSSEND.Text = ""
            objSENDSTR.Text = ""
            objSENDEND.Text = ""
            objMAILPASS.Text = ""
            objZIPFILE.Text = ""
            objBIKOU.Text = ""
            objDEL.Checked = False
        Next
        Call fncIni_List()
    End Sub
    '******************************************************************************
    '* 日付(作成日更新日)を初期化する
    '******************************************************************************
    Private Sub fncIni_List()
        Dim objlistHASSEI As System.Web.UI.WebControls.DropDownList
        Dim objlistKAIPAGE As System.Web.UI.WebControls.DropDownList
        Dim objlistKIKAN As System.Web.UI.WebControls.DropDownList
        Dim objlistZEROSND As System.Web.UI.WebControls.DropDownList
        Dim objlistSD_PRT As System.Web.UI.WebControls.DropDownList    '2020/11/01 T.Ono add 2020監視改善
        Dim objlistSNDSTOP As System.Web.UI.WebControls.DropDownList

        Dim i As Integer
        For i = 1 To 30
            objlistHASSEI = CType(FindControl("listHASSEI_" & CStr(i)), System.Web.UI.WebControls.DropDownList)
            objlistKAIPAGE = CType(FindControl("listKAIPAGE_" & CStr(i)), System.Web.UI.WebControls.DropDownList)
            objlistKIKAN = CType(FindControl("listKIKAN_" & CStr(i)), System.Web.UI.WebControls.DropDownList)
            objlistZEROSND = CType(FindControl("listZEROSND_" & CStr(i)), System.Web.UI.WebControls.DropDownList)
            objlistSD_PRT = CType(FindControl("listSD_PRT_" & CStr(i)), System.Web.UI.WebControls.DropDownList)    '2020/11/01 T.Ono add 2020監視改善
            objlistSNDSTOP = CType(FindControl("listSNDSTOP_" & CStr(i)), System.Web.UI.WebControls.DropDownList)
            objlistHASSEI.Items.Insert(0, New ListItem("1:電話", "1"))
            objlistHASSEI.Items.Insert(1, New ListItem("2:警報", "2"))
            objlistHASSEI.Items.Insert(2, New ListItem("3:両方", "3"))
            objlistHASSEI.DataBind()

            objlistKAIPAGE.Items.Insert(0, New ListItem("1:JA単位", "1"))
            '2015/11/20 w.ganeko 2015改善開発 №8 start
            'objlistKAIPAGE.Items.Insert(1, New ListItem("2:供給ｾﾝﾀｰ", "2"))
            'objlistKAIPAGE.Items.Insert(2, New ListItem("3:改頁なし", "3"))
            objlistKAIPAGE.Items.Insert(1, New ListItem("2:JA支所単位", "2"))
            objlistKAIPAGE.Items.Insert(2, New ListItem("3:販売事業者単位", "3"))
            objlistKAIPAGE.Items.Insert(3, New ListItem("4:供給ｾﾝﾀｰ", "4"))
            objlistKAIPAGE.Items.Insert(4, New ListItem("5:改頁なし", "5"))
            '2015/11/20 w.ganeko 2015改善開発 №8 end
            objlistKAIPAGE.DataBind()

            objlistKIKAN.Items.Insert(0, New ListItem("1:日次", "1"))
            objlistKIKAN.Items.Insert(1, New ListItem("2:週次", "2"))
            objlistKIKAN.Items.Insert(2, New ListItem("3:月次", "3"))
            objlistKIKAN.DataBind()

            objlistZEROSND.Items.Insert(0, New ListItem("0:しない", "0"))
            objlistZEROSND.Items.Insert(1, New ListItem("1:0件送信する", "1"))
            objlistZEROSND.DataBind()

            '2020/11/01 T.Ono add 2020監視改善
            objlistSD_PRT.Items.Insert(0, New ListItem("0:表示なし", "0"))
            objlistSD_PRT.Items.Insert(1, New ListItem("1:表示する", "1"))
            objlistSD_PRT.DataBind()

            objlistSNDSTOP.Items.Insert(0, New ListItem("0:送信可能", "0"))
            objlistSNDSTOP.Items.Insert(1, New ListItem("1:一時停止", "1"))
            objlistSNDSTOP.DataBind()
        Next
    End Sub
    '******************************************************************************
    '* 日付(作成日更新日)を初期化する
    '******************************************************************************
    Private Sub fncIni_date()

        txtAYMD.Value = ""
        txtUYMD.Value = ""
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
            Dim col As Integer = 0
            col = Convert.ToInt32(hdnPopcrtl.Value)
            If hdnPopcrtl.Value = "0" Then
                If hdnBackUrl.Value = "EIGYOU" Then
                    '//営業所グループの場合は監視センターが紐付けられない為、全クライアントを出力
                    strRec = ""
                Else
                    '//
                    strRec = AuthC.pAUTHCENTERCD    '//クライアントコード一覧 ＡＤ認証の使用可能監視センターコード
                End If
            ElseIf col >= 1 And col <= 30 Then
                strRec = hdnKENCD.Value        '//県コード一覧
            ElseIf col >= 31 And col <= 90 Then
                strRec = hdnKURACD.Value        '//クライアントコード一覧
            ElseIf hdnPopcrtl.Value = "101" Then '//JA支所コードFrom　2014/03/10 T.Ono add 絞込み条件追加
                strRec = hdnKURACD.Value
            ElseIf hdnPopcrtl.Value = "102" Then '//JA支所コードTo　2014/03/10 T.Ono add 絞込み条件追加
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
            Dim strRec As String = ""
            Dim col As Integer = 0
            col = Convert.ToInt32(hdnPopcrtl.Value)
            If hdnPopcrtl.Value = "0" Then          '//クライアントコード一覧
                strRec = "クライアントコード一覧"
            ElseIf col >= 1 And col <= 30 Then
                strRec = "供給センター一覧"
            ElseIf col >= 31 And col <= 90 Then
                strRec = "JA支所一覧"
            ElseIf hdnPopcrtl.Value = "101" Then     '2014/03/10 T.Ono add 絞込み条件追加
                strRec = "JA支所一覧"
            ElseIf hdnPopcrtl.Value = "102" Then     '2014/03/10 T.Ono add 絞込み条件追加
                strRec = "JA支所一覧"
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
            Dim col As Integer = 0
            col = Convert.ToInt32(hdnPopcrtl.Value)
            If hdnPopcrtl.Value = "0" Then          '//クライアントコード一覧
                strRec = "CLI"
            ElseIf col >= 1 And col <= 30 Then
                strRec = "KYO"
            ElseIf col >= 31 And col <= 90 Then
                strRec = "JAJASS"
            ElseIf hdnPopcrtl.Value = "101" Then     '2014/03/10 T.Ono add 絞込み条件追加
                strRec = "JASS"
            ElseIf hdnPopcrtl.Value = "102" Then     '2014/03/10 T.Ono add 絞込み条件追加
                strRec = "JASS"
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
            Dim col As Integer = 0
            col = Convert.ToInt32(hdnPopcrtl.Value)
            If hdnPopcrtl.Value = "0" Then
                strRec = "hdnKURACD"
            ElseIf col >= 1 And col <= 30 Then
                strRec = "txtKYOKYU_" & Convert.ToString(col)
            ElseIf col >= 31 And col <= 60 Then
                col = col - 30
                strRec = "txtACBCDFR_" & Convert.ToString(col)
            ElseIf col >= 61 And col <= 90 Then
                col = col - 60
                strRec = "txtACBCDTO_" & Convert.ToString(col)
            ElseIf hdnPopcrtl.Value = "101" Then     '2014/03/10 T.Ono add 絞込み条件追加
                strRec = "hdnACBCD_F"
            ElseIf hdnPopcrtl.Value = "102" Then     '2014/03/10 T.Ono add 絞込み条件追加
                strRec = "hdnACBCD_T"
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
            Dim col As Integer = 0                        '2014/03/10 T.Ono add
            col = Convert.ToInt32(hdnPopcrtl.Value)       '2014/03/10 T.Ono add
            If hdnPopcrtl.Value = "0" Then
                strRec = "txtKURACD"
                'ElseIf hdnPopcrtl.Value >= "1" And hdnPopcrtl.Value <= "90" Then   '2014/03/10 T.Ono mod
            ElseIf col >= 1 And col <= 90 Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "101" Then     '2014/03/10 T.Ono add 絞込み条件追加
                strRec = "txtACBCD_F"
            ElseIf hdnPopcrtl.Value = "102" Then     '2014/03/10 T.Ono add 絞込み条件追加
                strRec = "txtACBCD_T"
            End If
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*　概　要：コードを返すオブジェクトの名前値を渡すプロパティ
    '*　備　考：データ選択後、コードを返すオブジェクト名を指定する
    '******************************************************************************
    Public ReadOnly Property pBackCode2() As String
        Get
            Dim strRec As String = ""
            If hdnPopcrtl.Value = "0" Then
                strRec = "hdnKENCD"
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
    Public ReadOnly Property pBackName2() As String
        Get
            Dim strRec As String = ""
            If hdnPopcrtl.Value = "0" Then
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
            Dim strRec As String = ""
            Dim col As Integer = 0
            col = Convert.ToInt32(hdnPopcrtl.Value)
            If hdnPopcrtl.Value = "0" Then
                strRec = "btnKURACD"
            ElseIf col >= 1 And col <= 30 Then
                strRec = "btnKYOKYU_" & Convert.ToString(col)
            ElseIf col >= 31 And col <= 60 Then
                col = col - 30
                strRec = "btnACBCDFR_" & Convert.ToString(col)
            ElseIf col >= 61 And col <= 90 Then
                col = col - 60
                strRec = "btnACBCDTO_" & Convert.ToString(col)
            ElseIf hdnPopcrtl.Value = "101" Then    '2014/03/10 T.Ono add 絞込み条件追加
                strRec = "btnACBCD_F"
            ElseIf hdnPopcrtl.Value = "102" Then    '2014/03/10 T.Ono add 絞込み条件追加
                strRec = "btnACBCD_T"
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：リターン後に実行されるＪＳ　2019/11/01 T.Ono add 監視改善2019
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pBackScript() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "101" Then
                strRec = "fncSetTo"
            ElseIf hdnPopcrtl.Value = "102" Then
                strRec = "fncSetTo"
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
            If hdnPopcrtl.Value = "0" Then
                strRec = "txtACBCD_F"
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
            If hdnPopcrtl.Value = "0" Then
                strRec = "hdnACBCD_F"
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
            If hdnPopcrtl.Value = "0" Then
                strRec = "txtACBCD_T"
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
            If hdnPopcrtl.Value = "0" Then
                strRec = "hdnACBCD_T"
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
                hdnKURACD.Value = Convert.ToString(dbData.Tables(0).Rows(0).Item("KURACD"))
                hdnKURACD_MOTO.Value = Convert.ToString(dbData.Tables(0).Rows(0).Item("KURACD"))
                '県名
                txtKURACD.Text = Convert.ToString(dbData.Tables(0).Rows(0).Item("KURACD")) & " : " & Convert.ToString(dbData.Tables(0).Rows(0).Item("CLI_NAME"))
                Dim sMinAddDate As String
                Dim sMaxEdtDate As String
                sMinAddDate = DateFncC.mGet(Convert.ToString(dbData.Tables(0).Rows(0).Item("INS_DATE")))
                sMaxEdtDate = DateFncC.mGet(Convert.ToString(dbData.Tables(0).Rows(0).Item("UPD_DATE")))

                Dim objID As System.Web.UI.HtmlControls.HtmlInputHidden
                Dim objDISP_NO As System.Web.UI.HtmlControls.HtmlInputHidden
                Dim objSEND As System.Web.UI.WebControls.TextBox
                Dim objKYOKYUCD As System.Web.UI.WebControls.TextBox
                Dim objACBCDFR As System.Web.UI.WebControls.TextBox
                Dim objACBCDTO As System.Web.UI.WebControls.TextBox
                Dim objFAX1 As System.Web.UI.WebControls.TextBox
                Dim objFAX2 As System.Web.UI.WebControls.TextBox
                Dim objMAIL1 As System.Web.UI.WebControls.TextBox
                Dim objMAIL2 As System.Web.UI.WebControls.TextBox
                Dim objNXSEND As System.Web.UI.WebControls.TextBox
                Dim objLSSEND As System.Web.UI.WebControls.TextBox
                Dim objSENDSTR As System.Web.UI.WebControls.TextBox
                Dim objSENDEND As System.Web.UI.WebControls.TextBox
                Dim objMAILPASS As System.Web.UI.WebControls.TextBox
                Dim objZIPFILE As System.Web.UI.WebControls.TextBox
                Dim objBIKOU As System.Web.UI.WebControls.TextBox
                Dim objlistHASSEI As System.Web.UI.WebControls.DropDownList
                Dim objlistKAIPAGE As System.Web.UI.WebControls.DropDownList
                Dim objlistKIKAN As System.Web.UI.WebControls.DropDownList
                Dim objlistZEROSND As System.Web.UI.WebControls.DropDownList
                Dim objlistSD_PRT As System.Web.UI.WebControls.DropDownList    '2020/11/01 T.Ono add 2020監視改善
                Dim objlistSNDSTOP As System.Web.UI.WebControls.DropDownList
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
                        Or DateFncC.mGet(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("INS_DATE"))) < sMinAddDate Then
                        sMinAddDate = DateFncC.mGet(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("INS_DATE")))
                    End If
                    '更新日が空か、さらに後の場合、セット
                    If DateFncC.mGet(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("UPD_DATE"))) <> "" _
                        And DateFncC.mGet(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("UPD_DATE"))) >= sMaxEdtDate Then
                        sMaxEdtDate = DateFncC.mGet(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("UPD_DATE")))

                        '時刻が空か、さらに後の時間の場合、セット
                        'If sMaxTime = "" _
                        '    Or Convert.ToString(dbData.Tables(0).Rows(intRow).Item("TIME")) >= sMaxTime Then
                        'sMaxTime = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("TIME"))
                        'End If
                    End If

                    '----------------------------
                    ' 明細情報を画面項目にセット
                    '----------------------------
                    i = intRow + 1

                    objID = CType(FindControl("hdnID_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
                    objDISP_NO = CType(FindControl("hdnDISP_NO_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
                    objKYOKYUCD = CType(FindControl("txtKYOKYU_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                    objEDT_DT = CType(FindControl("hdnEDT_DT_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
                    objADD_DT = CType(FindControl("hdnADD_DT_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
                    objSEND = CType(FindControl("txtSEND_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                    objACBCDFR = CType(FindControl("txtACBCDFR_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                    objACBCDTO = CType(FindControl("txtACBCDTO_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                    objFAX1 = CType(FindControl("txtFAX1_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                    objFAX2 = CType(FindControl("txtFAX2_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                    objMAIL1 = CType(FindControl("txtMAIL1_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                    objMAIL2 = CType(FindControl("txtMAIL2_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                    objNXSEND = CType(FindControl("txtNXSEND_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                    objLSSEND = CType(FindControl("txtLSSEND_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                    objSENDSTR = CType(FindControl("txtSENDSTR_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                    objSENDEND = CType(FindControl("txtSENDEND_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                    objMAILPASS = CType(FindControl("txtMAILPASS_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                    objZIPFILE = CType(FindControl("txtZIP_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                    objBIKOU = CType(FindControl("txtBIKOU_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                    objlistHASSEI = CType(FindControl("listHASSEI_" & CStr(i)), System.Web.UI.WebControls.DropDownList)
                    objlistKAIPAGE = CType(FindControl("listKAIPAGE_" & CStr(i)), System.Web.UI.WebControls.DropDownList)
                    objlistKIKAN = CType(FindControl("listKIKAN_" & CStr(i)), System.Web.UI.WebControls.DropDownList)
                    objlistZEROSND = CType(FindControl("listZEROSND_" & CStr(i)), System.Web.UI.WebControls.DropDownList)
                    objlistSD_PRT = CType(FindControl("listSD_PRT_" & CStr(i)), System.Web.UI.WebControls.DropDownList)    '2020/11/01 T.Ono add 2020監視改善
                    objlistSNDSTOP = CType(FindControl("listSNDSTOP_" & CStr(i)), System.Web.UI.WebControls.DropDownList)
                    objID.Value = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("ID"))
                    objDISP_NO.Value = CStr(i)
                    objADD_DT.Value = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("INS_DATE"))
                    objEDT_DT.Value = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("UPD_DATE"))
                    objSEND.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("SEQ"))
                    objKYOKYUCD.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("HAISO_CD"))
                    objACBCDFR.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("ACBCD_FR"))
                    objACBCDTO.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("ACBCD_TO"))
                    objFAX1.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("FAX1"))
                    objFAX2.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("FAX2"))
                    objMAIL1.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("MAIL1"))
                    objMAIL2.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("MAIL2"))
                    objNXSEND.Text = fncDateSet(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("NEXTSENDDATE")))
                    objLSSEND.Text = fncDateSet(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("LASTSENDDATE")))
                    objSENDSTR.Text = fncDateSet(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("SENDSTDATE")))
                    objSENDEND.Text = fncDateSet(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("SENDEDDATE")))
                    objMAILPASS.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("MAIL_PASSWORD"))
                    objZIPFILE.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("ZIP_FILE_NAME"))
                    objBIKOU.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("BIKO"))
                    Dim list As New ListItem
                    'objlistHASSEI.SelectedValue = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("HATKBN"))
                    list = objlistHASSEI.Items.FindByValue(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("HATKBN")))
                    objlistHASSEI.SelectedIndex = objlistHASSEI.Items.IndexOf(list)

                    'objlistKAIPAGE.SelectedValue = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("PAGEKBN"))
                    list = objlistKAIPAGE.Items.FindByValue(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("PAGEKBN")))
                    objlistKAIPAGE.SelectedIndex = objlistKAIPAGE.Items.IndexOf(list)

                    'objlistKIKAN.SelectedValue = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("PERIODKBN"))
                    list = objlistKIKAN.Items.FindByValue(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("PERIODKBN")))
                    objlistKIKAN.SelectedIndex = objlistKIKAN.Items.IndexOf(list)

                    'objlistZEROSND.SelectedValue = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("ZEROSENDKBN"))
                    list = objlistZEROSND.Items.FindByValue(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("ZEROSENDKBN")))
                    objlistZEROSND.SelectedIndex = objlistZEROSND.Items.IndexOf(list)

                    '2020/11/01 T.Ono add 2020監視改善
                    list = objlistSD_PRT.Items.FindByValue(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("SD_PRT")))
                    objlistSD_PRT.SelectedIndex = objlistSD_PRT.Items.IndexOf(list)

                    'objlistSNDSTOP.SelectedValue = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("SENDSTOPKBN"))
                    list = objlistSNDSTOP.Items.FindByValue(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("SENDSTOPKBN")))
                    objlistSNDSTOP.SelectedIndex = objlistSNDSTOP.Items.IndexOf(list)
                Next ' intRow


                txtAYMD.Value = sMinAddDate
                txtUYMD.Value = sMaxEdtDate

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

        Dim strKBN As String
        strKBN = "3"        '//ＪＡ支所担当者にチェック

        Dim MSRUIJAW00C As New MSRUIJAG00MSRUIJAW00.MSRUIJAW00

        Dim strKURACD As String
        strKURACD = hdnKURACD.Value

        '値を配列にセット
        Dim objID As System.Web.UI.HtmlControls.HtmlInputHidden
        Dim objDEL As System.Web.UI.WebControls.CheckBox
        Dim objDISP_NO As System.Web.UI.HtmlControls.HtmlInputHidden
        Dim objKYOKYUCD As System.Web.UI.WebControls.TextBox
        Dim objEDT_DT As System.Web.UI.HtmlControls.HtmlInputHidden
        Dim objADD_DT As System.Web.UI.HtmlControls.HtmlInputHidden
        Dim objSEND As System.Web.UI.WebControls.TextBox
        Dim objACBCDFR As System.Web.UI.WebControls.TextBox
        Dim objACBCDTO As System.Web.UI.WebControls.TextBox
        Dim objFAX1 As System.Web.UI.WebControls.TextBox
        Dim objFAX2 As System.Web.UI.WebControls.TextBox
        Dim objMAIL1 As System.Web.UI.WebControls.TextBox
        Dim objMAIL2 As System.Web.UI.WebControls.TextBox
        Dim objNXSEND As System.Web.UI.WebControls.TextBox
        Dim objLSSEND As System.Web.UI.WebControls.TextBox
        Dim objSENDSTR As System.Web.UI.WebControls.TextBox
        Dim objSENDEND As System.Web.UI.WebControls.TextBox
        Dim objMAILPASS As System.Web.UI.WebControls.TextBox
        Dim objZIPFILE As System.Web.UI.WebControls.TextBox
        Dim objBIKOU As System.Web.UI.WebControls.TextBox
        Dim objlistHASSEI As System.Web.UI.WebControls.DropDownList
        Dim objlistKAIPAGE As System.Web.UI.WebControls.DropDownList
        Dim objlistKIKAN As System.Web.UI.WebControls.DropDownList
        Dim objlistZEROSND As System.Web.UI.WebControls.DropDownList
        Dim objlistSD_PRT As System.Web.UI.WebControls.DropDownList    '2020/11/01 T.Ono add 2020監視改善
        Dim objlistSNDSTOP As System.Web.UI.WebControls.DropDownList
        Dim sID(30) As String
        Dim sDEL(30) As String
        Dim sDISP_NO(30) As String
        Dim sKYOKYUCD(30) As String
        Dim sEDT_DT(30) As String
        Dim sADD_DT(30) As String
        Dim sSEND(30) As String
        Dim sACBCDFR(30) As String
        Dim sACBCDTO(30) As String
        Dim sFAX1(30) As String
        Dim sFAX2(30) As String
        Dim sMAIL1(30) As String
        Dim sMAIL2(30) As String
        Dim sNXSEND(30) As String
        Dim sLSSEND(30) As String
        Dim sSENDSTR(30) As String
        Dim sSENDEND(30) As String
        Dim sMAILPASS(30) As String
        Dim sZIPFILE(30) As String
        Dim sBIKOU(30) As String
        Dim slistHASSEI(30) As String
        Dim slistKAIPAGE(30) As String
        Dim slistKIKAN(30) As String
        Dim slistZEROSND(30) As String
        Dim slistSD_PRT(30) As String    '2020/11/01 T.Ono add 2020監視改善
        Dim slistSNDSTOP(30) As String
        Dim i As Integer
        For i = 1 To 30
            objID = CType(FindControl("hdnID_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
            objDEL = CType(FindControl("chkDEL_" & CStr(i)), System.Web.UI.WebControls.CheckBox)
            objDISP_NO = CType(FindControl("hdnDISP_NO_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKYOKYUCD = CType(FindControl("txtKYOKYU_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objEDT_DT = CType(FindControl("hdnEDT_DT_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
            objADD_DT = CType(FindControl("hdnADD_DT_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
            objSEND = CType(FindControl("txtSEND_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objACBCDFR = CType(FindControl("txtACBCDFR_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objACBCDTO = CType(FindControl("txtACBCDTO_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objFAX1 = CType(FindControl("txtFAX1_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objFAX2 = CType(FindControl("txtFAX2_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objMAIL1 = CType(FindControl("txtMAIL1_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objMAIL2 = CType(FindControl("txtMAIL2_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objNXSEND = CType(FindControl("txtNXSEND_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objLSSEND = CType(FindControl("txtLSSEND_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objSENDSTR = CType(FindControl("txtSENDSTR_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objSENDEND = CType(FindControl("txtSENDEND_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objMAILPASS = CType(FindControl("txtMAILPASS_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objZIPFILE = CType(FindControl("txtZIP_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objBIKOU = CType(FindControl("txtBIKOU_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objlistHASSEI = CType(FindControl("listHASSEI_" & CStr(i)), System.Web.UI.WebControls.DropDownList)
            objlistKAIPAGE = CType(FindControl("listKAIPAGE_" & CStr(i)), System.Web.UI.WebControls.DropDownList)
            objlistKIKAN = CType(FindControl("listKIKAN_" & CStr(i)), System.Web.UI.WebControls.DropDownList)
            objlistZEROSND = CType(FindControl("listZEROSND_" & CStr(i)), System.Web.UI.WebControls.DropDownList)
            objlistSD_PRT = CType(FindControl("listSD_PRT_" & CStr(i)), System.Web.UI.WebControls.DropDownList)    '2020/11/01 T.Ono add 2020監視改善
            objlistSNDSTOP = CType(FindControl("listSNDSTOP_" & CStr(i)), System.Web.UI.WebControls.DropDownList)

            sID(i) = objID.Value
            If (objDEL.Checked) Then
                sDEL(i) = "true"
            Else
                sDEL(i) = "false"
            End If
            sDISP_NO(i) = objDISP_NO.Value
            sEDT_DT(i) = objEDT_DT.Value
            sADD_DT(i) = objADD_DT.Value
            sSEND(i) = objSEND.Text
            sKYOKYUCD(i) = objKYOKYUCD.Text
            sACBCDFR(i) = objACBCDFR.Text
            sACBCDTO(i) = objACBCDTO.Text
            sFAX1(i) = objFAX1.Text
            sFAX2(i) = objFAX2.Text
            sMAIL1(i) = objMAIL1.Text
            sMAIL2(i) = objMAIL2.Text
            sNXSEND(i) = fncDateGet(objNXSEND.Text)
            sLSSEND(i) = fncDateGet(objLSSEND.Text)
            sSENDSTR(i) = fncDateGet(objSENDSTR.Text)
            sSENDEND(i) = fncDateGet(objSENDEND.Text)
            sMAILPASS(i) = objMAILPASS.Text
            sZIPFILE(i) = objZIPFILE.Text
            sBIKOU(i) = objBIKOU.Text
            slistHASSEI(i) = Request.Form("listHASSEI_" & CStr(i))
            slistKAIPAGE(i) = Request.Form("listKAIPAGE_" & CStr(i))
            slistKIKAN(i) = Request.Form("listKIKAN_" & CStr(i))
            slistZEROSND(i) = Request.Form("listZEROSND_" & CStr(i))
            slistSD_PRT(i) = Request.Form("listSD_PRT_" & CStr(i))    '2020/11/01 T.Ono add  2020監視改善
            slistSNDSTOP(i) = Request.Form("listSNDSTOP_" & CStr(i))

        Next
        '2020/11/01 T.Ono mod 2020監視改善 slistSD_PRT追加
        strRec = MSRUIJAW00C.mSetEx(
                    CInt(pstrKBN),
                      strKURACD,
                      sID,
                      sSEND,
                      sKYOKYUCD,
                      sACBCDFR,
                      sACBCDTO,
                      sFAX1,
                      sFAX2,
                      sMAIL1,
                      sMAIL2,
                      sNXSEND,
                      sLSSEND,
                      sSENDSTR,
                      sSENDEND,
                      sMAILPASS,
                      sZIPFILE,
                      sBIKOU,
                      slistHASSEI,
                      slistKAIPAGE,
                      slistKIKAN,
                      slistZEROSND,
                      slistSD_PRT,
                      slistSNDSTOP,
                      sDEL,
                      DateFncC.mHenkanGet(txtAYMD.Value),
                      DateFncC.mHenkanGet(txtUYMD.Value),
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
                Call fncIni_List()

                '//------------------------------
                '<TODO>フォーカスをセットする（修正時でのエラー。検索ボタンにセット）
                strMsg.Append("Form1.btnSelect.focus();")
                strRec = strRecMsg
            Case "1"
                strRecMsg = "既にデータが存在します"
                strMsg.Append("alert('" & strRecMsg & "');")
                Call fncIni_List()

                '//------------------------------
                strRec = strRecMsg
            Case "2"
                strRecMsg = "対象データが存在しません"
                strMsg.Append("alert('" & strRecMsg & "');")
                Call fncIni_List()

                '//------------------------------
                '<TODO>フォーカスをセットする（修正時でのエラー。検索ボタンにセット）
                strMsg.Append("Form1.btnSelect.focus();")
                strRec = strRecMsg
            Case "3"
                strRecMsg = "排他制御処理でエラーが発生しました。再度実行してください"
                strMsg.Append("alert('" & strRecMsg & "');")
                Call fncIni_List()

                '<TODO>フォーカスをセットする（登録・修正・削除時でのエラー。終了ボタンにセット）
                strMsg.Append("Form1.btnExit.focus();")
                strRec = strRecMsg
            Case "4"
                strRecMsg = "県コードが存在しません"
                strMsg.Append("alert('" & strRecMsg & "');")
                Call fncIni_List()

                '<TODO>フォーカスをセットする（登録・修正時でのエラー。クライアントコード検索補助ボタンにセット）
                strMsg.Append("Form1.btnSelect.focus();")

                strRec = strRecMsg
            Case "5"
                strRecMsg = "送信順が既に登録されています。"
                strMsg.Append("alert('" & strRecMsg & "');")
                Call fncIni_List()

                '<TODO>フォーカスをセットする（登録・修正時でのエラー。送信順にセット）
                strMsg.Append("Form1.txtSEND_1.focus();")

                strRec = strRecMsg
            Case "8"        
                strRecMsg = "供給センターコードが重複しています"
                strMsg.Append("alert('" & strRecMsg & "');")
                Call fncIni_List()

                '<TODO>フォーカスをセットする（登録・修正時でのエラー。コード検索補助ボタンにセット）
                strMsg.Append("Form1.txtKYOKYU_1.focus();")

                strRec = strRecMsg

            Case Else
                Dim ErrMsgC As New CErrMsg

                strMsg.Append("alert('システムエラー：" & ErrMsgC.mGetArtMsg(strRec) & "');")
                Call fncIni_List()

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
    '*　概　要：パラメータ値より日付YYYYMMDD値を返す
    '*　備　考：
    '******************************************************************************
    Public Function fncDateGet(ByVal pstrDate As String) As String
        Dim DateFncC As New CDateFnc
        Dim strRec As String
        strRec = ""
        If pstrDate.Length <> 0 Then
            strRec = DateFncC.mHenkanGet(pstrDate)
        End If

        Return strRec
    End Function

    '******************************************************************************
    '*　概　要：パラメータ値より日付YYYY/MM/DD値を返す
    '*　備　考：
    '******************************************************************************
    Public Function fncDateSet(ByVal pstrDate As String) As String
        Dim DateFncC As New CDateFnc
        Dim strRec As String
        strRec = ""
        If IsNumeric(pstrDate) = True Then
            strRec = DateFncC.mGet(pstrDate)
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
        Dim SQLC As New MSRUIJAG00CCSQL.CSQL
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
            strSQL.Append("A.KURACD, ")
            strSQL.Append("CL.CLI_NAME, ")
            strSQL.Append("A.ID, ")
            strSQL.Append("A.SEQ, ")
            strSQL.Append("A.HAISO_CD, ")
            strSQL.Append("A.ACBCD_FR, ")
            strSQL.Append("A.ACBCD_TO, ")
            strSQL.Append("A.HATKBN, ")
            strSQL.Append("A.PAGEKBN, ")
            strSQL.Append("A.PERIODKBN, ")
            strSQL.Append("A.FAX1, ")
            strSQL.Append("A.FAX2, ")
            strSQL.Append("A.MAIL1, ")
            strSQL.Append("A.MAIL2, ")
            strSQL.Append("A.ZEROSENDKBN, ")
            strSQL.Append("A.SD_PRT, ")             '2020/11/01 T.Ono add 2020監視改善
            strSQL.Append("A.JOTAI, ")
            strSQL.Append("A.LASTSENDDATE, ")
            strSQL.Append("A.NEXTSENDDATE, ")
            strSQL.Append("A.SENDSTOPKBN, ")
            strSQL.Append("A.SENDSTDATE, ")
            strSQL.Append("A.SENDEDDATE, ")
            strSQL.Append("A.BIKO, ")
            strSQL.Append("A.DEL_FLG, ")
            strSQL.Append("A.MAIL_PASSWORD, ")
            strSQL.Append("A.ZIP_FILE_NAME, ")
            strSQL.Append("A.INS_DATE, ")
            strSQL.Append("A.UPD_DATE ")
        Else
            '新規なので対象データのカウントを取得します
            strSQL.Append("COUNT(*) AS CNT ")
        End If
        strSQL.Append("FROM B10_BTRUIJAE  A, ")
        strSQL.Append("     CLIMAS CL ")
        strSQL.Append("WHERE A.KURACD   = :KURACD ")
        strSQL.Append("AND A.DEL_FLG  = '0' ")
        strSQL.Append("AND A.KURACD   = CL.CLI_CD(+) ")
        '2014/03/10 T.Ono add 絞込み条件追加
        If hdnACBCD_F.Value.Trim.Length > 0 AndAlso hdnACBCD_T.Value.Trim.Length > 0 Then
            'JA支所From～To指定
            strSQL.Append("AND ((A.ACBCD_FR BETWEEN :ACBCD_F AND :ACBCD_T ")
            strSQL.Append("     OR A.ACBCD_TO BETWEEN :ACBCD_F AND :ACBCD_T) ")
            strSQL.Append("     OR (A.ACBCD_FR < :ACBCD_F AND A.ACBCD_TO > :ACBCD_T)) ")
        ElseIf hdnACBCD_F.Value.Trim.Length > 0 Then
            'JA支所From指定
            strSQL.Append("AND A.ACBCD_TO >= :ACBCD_F ")
        ElseIf hdnACBCD_T.Value.Trim.Length > 0 Then
            'JA支所To指定
            strSQL.Append("AND A.ACBCD_FR <= :ACBCD_T ")
        End If

        If pintkbn = 0 Then
            '2014/03/10 T.Ono mod 
            'strSQL.Append(" ORDER BY A.SEQ ")
            strSQL.Append(" ORDER BY A.HAISO_CD, A.ACBCD_FR, A.ACBCD_TO")
        End If
        If hdnKURACD.Value.Trim.Length > 0 Then
            SqlParamC.fncSetParam("KURACD", True, hdnKURACD.Value.Trim)
        End If
        '2014/03/10 T.Ono add 絞込み条件追加
        If hdnACBCD_F.Value.Trim.Length > 0 Then
            SqlParamC.fncSetParam("ACBCD_F", True, hdnACBCD_F.Value.Trim)
        End If
        If hdnACBCD_T.Value.Trim.Length > 0 Then
            SqlParamC.fncSetParam("ACBCD_T", True, hdnACBCD_T.Value.Trim)
        End If

        dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)
        'cdb.pSQL = strSQL.ToString
        'If hdnKURACD.Value.Trim.Length > 0 Then
        '    cdb.pSQLParamStr("KURACD") = hdnKURACD.Value.Trim
        'End If
        ''2014/03/10 T.Ono add 絞込み条件追加
        'If hdnACBCD_F.Value.Trim.Length > 0 Then
        '    cdb.pSQLParamStr("ACBCD_F") = hdnACBCD_F.Value.Trim
        'End If
        'If hdnACBCD_T.Value.Trim.Length > 0 Then
        '    cdb.pSQLParamStr("ACBCD_T") = hdnACBCD_T.Value.Trim
        'End If
        'cdb.mExecQuery()
        'dbData = cdb.pResult    '結果をデータセットに格納
        'cdb.mClose()
        'cdb = Nothing
        Return dbData
    End Function
    '******************************************************************************
    ' Excel出力(チェックつき)
    '******************************************************************************
    Private Sub btnCSVout_ServerClick(ByVal sender As System.Object, _
                                    ByVal e As System.EventArgs) Handles btnCSVout.ServerClick
        Dim strRec As String
        Dim MSRUIJAG00C As New MSRUIJAG00MSRUIJAW00.MSRUIJAW00

        '//　認証クラスのインスタンス生成
        AuthC = New CAuthenticate(Request, Response)

        Dim strRecMsg As String = ""

        strRec = MSRUIJAG00C.mCSV( _
                         Me.Session.SessionID, _
                         hdnKURACD.Value _
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
            HttpHeaderC.mDownLoadCSV(Response, "累積情報自動FAXメールマスタ.csv")
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
