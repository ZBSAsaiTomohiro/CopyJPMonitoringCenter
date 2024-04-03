
'***********************************************
'対応結果一覧  メイン画面
'***********************************************
'<TODO>宣言共通仕様
Option Explicit On
Option Strict On

'<TODO>宣言共通仕様
Imports Common
Imports JPG.Common
Imports JPG.Common.log
Imports System.Text

Partial Class KEKEKJAG00
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

        '2012/04/04 NEC ou Add Str
        '.NETの仕様変更により、ReadOnly属性をASPXでつけると、サーバ側で値の参照ができなくなるため、VB側でAttributeでつける
        If MyBase.IsPostBack = False Then
            txtTKTANCD.Attributes.Add("ReadOnly", "true")
            txtKURACD.Attributes.Add("ReadOnly", "true")
            txtKURACD_TO.Attributes.Add("ReadOnly", "true") '2019/11/01 T.Ono add 監視改善2019
            'txtHANGRP.Attributes.Add("ReadOnly", "true") '2014/12/08 H.Hosoda add 監視改善2014 No.7 '2019/11/01 T.Ono del 監視改善2019
            'txtKINRENGRP.Attributes.Add("ReadOnly", "true") '2016/11/25 H.Mori add 監視改善2016 No3-1  '2019/11/01 T.Ono del 監視改善2019
            txtACBNM.Attributes.Add("ReadOnly", "true")
            txtACBNM_TO.Attributes.Add("ReadOnly", "true") '2019/11/01 T.Ono add 監視改善2019
            txtJANM.Attributes.Add("ReadOnly", "true") '2013/12/13 T.Ono add 監視改善2013
            txtKMCD.Attributes.Add("ReadOnly", "true") '2013/12/13 T.Ono add 監視改善2013
        End If
        '2012/04/03 NEC ou Add End

        '//------------------------------------------
        '//　HTTPヘッダを送信
        HttpHeaderC.mNoCache(Response)

        '//------------------------------------------
        '//　認証クラスのインスタンス生成
        AuthC = New CAuthenticate(Request, Response)

        '//------------------------------------------
        '//　認証処理
        '<TODO>：使用可能権限を指定する
        '[対応結果一覧]使用可能権限(運:○/営:×/監:△/出:×)
        '2005/12/03 NEC UPDATE START
        '[対応結果一覧]使用可能権限(運:○/営:○/監:△/出:×)
        'AuthC.fncAuthCheck(Server, AuthC.pGROUP_UNKOU & "," & AuthC.pGROUP_KANSHI)
        AuthC.fncAuthCheck(Server, AuthC.pGROUP_UNKOU & "," & AuthC.pGROUP_KANSHI & "," & AuthC.pGROUP_EIGYOU)
        '2005/12/03 NEC UPDATE START

        '//------------------------------------------
        '<TODO>ポップアップ/登録系フレームの出力
        '      [hdnKensaku(Hidden)]を作成する事
        If hdnKensaku.Value = "COPOPUPG00" Then
            Server.Transfer("../../../Popup/COPOPUPG00.aspx")
        End If
        '//対応結果一覧出力
        If hdnKensaku.Value = "KEKEKJFG00" Then
            Server.Transfer("KEKEKJFG00.aspx")
        End If
        '//カレンダーの出力
        If hdnKensaku.Value = "COCALDRG00" Then
            Server.Transfer("../../../Popup/COCALDRG00.aspx")
        End If

        '//------------------------------------------
        '// Script書込み用変数宣言
        Dim strScript As New StringBuilder("")
        Dim cscript1 As New CScript
        Dim strScriptPath As String

        Dim dbData As DataSet

        strScriptPath = ConfigurationSettings.AppSettings("SCRIPTPATH")

        '------------------------------------------------------------------------------
        '<TODO>HTML内に必要なJavaScript/CSSはここで[strScript]変数に格納後
        '      画面上[lblScript]に書き込みを行います(SPANタグとしてクライアントにスクリプトが
        '      出力されます。)
        '      [lblScript(Label)]を作成する事
        '//------------------------------------------
        '//　JavaScript格納
        strScript.Append("<Script language=javascript>")
        '<独自スクリプト>
        strScript.Append(cscript1.mWriteScript( _
             MyBase.MapPath("../../../KE/KEKEKJAG/KEKEKJAG00/") & "KEKEKJAG00.js"))
        '<フォーカス関連関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncFo.js"))
        '<日付関連関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncDate.js"))
        '<時間関連関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncTime.js"))
        '<電話番号チェック関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncTel.js"))
        '<全角チェック関数>
        '--- ↓2005/05/19 DEL Falcon↓ ---
        'strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncZenkakuChk.js"))
        '--- ↑2005/05/19 DEL Falcon↑ ---

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
            '//　初めて開いた時だけ実行される

            '//--------------------------------------
            '初期表示として必要なコントロールの設定を行います
            Call fncIni_format()    '//値の初期化

            '対応入力から帰ってきた画面遷移の場合------------
            Dim list As New ListItem            'リストアイテム
            If Request.Form("hdnMyAspx") = "KETAIJAG00" Then

                '監視センターコード
                list = cboKANSCD.Items.FindByValue(Request.Form("hdnMOVE_KANSCD"))
                cboKANSCD.SelectedIndex = cboKANSCD.Items.IndexOf(list)
                '対象期間区分ラジオボタン  2017/10/26 H.Mori add 2017改善開発 No3-1
                If Request.Form("hdnMOVE_KIKANKBN") = "1" Then
                    rdoKIKAN1.Checked = True '対応完了日
                    rdoKIKAN2.Checked = False
                ElseIf Request.Form("hdnMOVE_KIKANKBN") = "2" Then
                    rdoKIKAN1.Checked = False
                    rdoKIKAN2.Checked = True '受信日
                End If
                '発生期間（From）   日付編集
                txtHATYMD_From.Text = fncDateSet(Request.Form("hdnMOVE_HATYMD_From"))
                '発生期間（To）     日付編集
                txtHATYMD_To.Text = fncDateSet(Request.Form("hdnMOVE_HATYMD_To"))
                '発生時刻（From）   時刻編集
                txtHATTIME_From.Text = fncTimeSet(Request.Form("hdnMOVE_HATTIME_From"), 0)
                '発生時刻（To）     時刻編集
                txtHATTIME_To.Text = fncTimeSet(Request.Form("hdnMOVE_HATTIME_To"), 0)
                '監視センター担当者コード
                hdnTKTANCD.Value = Request.Form("hdnMOVE_TKTANCD")
                '監視センター担当者名
                txtTKTANCD.Text = Request.Form("hdnMOVE_TKTANNM")
                '発生区分
                list = cboHATKBN.Items.FindByValue(Request.Form("hdnMOVE_HATKBN"))
                cboHATKBN.SelectedIndex = cboHATKBN.Items.IndexOf(list)
                '対応区分
                '2014/12/04 H.Hosoda mod 監視改善2014 No.7 START
                'list = cboTAIOKBN.Items.FindByValue(Request.Form("hdnMOVE_TAIOKBN"))
                'cboTAIOKBN.SelectedIndex = cboTAIOKBN.Items.IndexOf(list)
                ''電話
                If Request.Form("hdnMOVE_TAIOKBN1") = "1" Then
                    chkTAIOU_KBN1.Checked = True
                Else
                    chkTAIOU_KBN1.Checked = False
                End If
                ''出動
                If Request.Form("hdnMOVE_TAIOKBN2") = "1" Then
                    chkTAIOU_KBN2.Checked = True
                Else
                    chkTAIOU_KBN2.Checked = False
                End If
                ''重複
                If Request.Form("hdnMOVE_TAIOKBN3") = "1" Then
                    chkTAIOU_KBN3.Checked = True
                Else
                    chkTAIOU_KBN3.Checked = False
                End If
                '2014/12/04 H.Hosoda mod 監視改善2014 No.7 END
                '処理区分
                list = cboTMSKB.Items.FindByValue(Request.Form("hdnMOVE_TMSKB"))
                cboTMSKB.SelectedIndex = cboTMSKB.Items.IndexOf(list)
                'お客様電話番号
                txtJUTEL.Text = Request.Form("hdnMOVE_JUTEL")
                '結線番号  2014/12/05 H.Hosoda add 監視改善2014 No.7 2016/11/25 H.Mori del 監視改善2016 No3-2
                'txtNCUTEL.Text = Request.Form("hdnMOVE_NCUTEL")
                'お客様名
                txtJUSYONM.Text = Request.Form("hdnMOVE_JUSYONM")
                'お客様名カナ　2016/11/24 H.Mori del 監視改善2016 No3-3
                'txtJUSYOKN.Text = Request.Form("hdnMOVE_JUSYOKN")
                'クライアントコード
                hdnKURACD.Value = Request.Form("hdnMOVE_KURACD")
                'クライアント名
                txtKURACD.Text = Request.Form("hdnMOVE_KURACD_NAME")
                '2019/11/01 T.Ono del 監視改善2019 START
                'クライアントTOコード
                hdnKURACD_TO.Value = Request.Form("hdnMOVE_KURACD_TO")
                'クライアントTO名
                txtKURACD_TO.Text = Request.Form("hdnMOVE_KURACD_TO_NAME")
                '2019/11/01 T.Ono del 監視改善2019 END
                'ＪＡコード 2013/12/10 T.Ono add 監視改善2013
                hdnJACD.Value = Request.Form("hdnMOVE_JA_CD")
                'ＪＡ名 2013/12/10 T.Ono add 監視改善2013
                txtJANM.Text = Request.Form("hdnMOVE_JA_CD_NAME")
                'ＪＡコードに紐づくクライアントコード 2019/11/01 T.Ono add 監視改善2019
                hdnJACD_CLI.Value = Request.Form("hdnMOVE_JA_CD_CLI")
                '2019/11/01 T.Ono del 監視改善2019 START
                ''販売事業者グループコード 2014/12/08 H.Hosoda add 監視改善2014 No.7
                'hdnHANGRP.Value = Request.Form("hdnMOVE_HAN_GRP")
                ''販売事業者グループ名 2014/12/08 H.Hosoda add 監視改善2014 No.7
                'txtHANGRP.Text = Request.Form("hdnMOVE_HAN_GRP_NAME")
                ''緊急連絡先Gr 2016/11/25 H.Mori add 監視改善2016 No3-1
                'hdnKINRENGRP.Value = Request.Form("hdnMOVE_KINREN_GRP")
                ''緊急連絡先Gr名 2016/11/25 H.Mori add 監視改善2016 No3-1
                'txtKINRENGRP.Text = Request.Form("hdnMOVE_KINREN_GRP_NAME")
                '2019/11/01 T.Ono del 監視改善2019 END
                'ＪＡ支所コード
                hdnACBCD.Value = Request.Form("hdnMOVE_ACBCD")
                'ＪＡ支所名
                txtACBNM.Text = Request.Form("hdnMOVE_ACBCD_NAME")
                '2019/11/01 T.Ono add 監視改善2019 START
                'ＪＡ支所名に紐づくクライアントコード
                hdnACBCD_CLI.Value = Request.Form("hdnMOVE_ACBCD_CLI")
                'ＪＡ支所コードTO
                hdnACBCD_TO.Value = Request.Form("hdnMOVE_ACBCD_TO")
                'ＪＡ支所名TO
                txtACBNM_TO.Text = Request.Form("hdnMOVE_ACBCD_TO_NAME")
                'ＪＡ支所名TOに紐づくクライアントコード
                hdnACBCD_TO_CLI.Value = Request.Form("hdnMOVE_ACBCD_TO_CLI")
                '2019/11/01 T.Ono add 監視改善2019 END
                'お客様名コード
                txtUSER_CD.Text = Request.Form("hdnMOVE_USER_CD")
                '2011.11.15 ADD H.Uema
                '警報コード
                'txtKMCD.Text = Request.Form("hdnMOVE_KMCD") 2013/12/10 T.Ono mod 監視改善2013
                txtKMCD.Text = Request.Form("hdnMOVE_KMNM")
                hdnKMCD.Value = Request.Form("hdnMOVE_KMCD")
                '選択キーを保持する
                hdnKEY_KANSCD.Value = Request.Form("hdnKEY_KANSCD")
                hdnKEY_SYONO.Value = Request.Form("hdnKEY_SYONO")
                'スクロールバー
                hdnScrollTop.Value = Request.Form("hdnScrollTop")            '2013/12/10 T.Ono add 監視改善2013
                '検索ボタン押下時と同様の処理を行う
                hdnSelectClick.Value = "1"
            Else
                '通常の遷移時(メニューより)
                hdnSelectClick.Value = ""

                '受信期間に当日日付を表示　2013/12/10 T.Ono add 監視改善2013
                txtHATYMD_From.Text = DateTime.Today.ToString("yyyy/MM/dd")
                txtHATYMD_To.Text = DateTime.Today.ToString("yyyy/MM/dd")

                '//------------------------------------------------
                '<TODO>フォーカスをセットする（初期表示なのでキーにセットする）
                strMsg.Append("Form1.cboKANSCD.focus();")
            End If

        Else
            '//--------------------------------------
            '//２回目以降実行される
            '//--------------------------------------

        End If

        '//-------------------------------------------------
        '<TODO>自分の画面IDをHIDDENのhdnMyAspxに書き込む（システム共通）
        hdnMyAspx.Value = "KEKEKJAG00"
        '//-------------------------------------------------

    End Sub

    '******************************************************************************
    '* 各コントロールの設定値の初期化
    '******************************************************************************
    Private Sub fncIni_format()

        'コンボ作成
        Call fncCombo_Creatr_KANSI_CD()     '監視センターコンボ
        Call fncCombo_Create_HASEIKBN()     '発生区分コンボ
        'Call fncCombo_Create_TAIOUKBN()    '対応区分コンボ '2014/12/04 H.Hosoda del 監視改善2014 No.7
        Call fncCombo_Create_SYORIKBN()     '処理区分コンボ

        '//監視センターコード-----------------------------
        'ADにて自分の監視センターコードを初期選択する
        '運行開発部はTOPを選択
        Dim list As New ListItem
        Dim strGROUPNAME As String = AuthC.pGROUPNAME
        Dim arrGroupName() As String = strGROUPNAME.Split(Convert.ToChar(","))
        '2005/12/03 NEC UPDATE START
        'If Array.IndexOf(arrGroupName, AuthC.pGROUP_UNKOU) >= 0 Then
        If Array.IndexOf(arrGroupName, AuthC.pGROUP_UNKOU) >= 0 Or Array.IndexOf(arrGroupName, AuthC.pGROUP_EIGYOU) >= 0 Then
            '2005/12/03 NEC UPDATE END
            '運行開発部
            cboKANSCD.SelectedIndex = 0
        Else
            list = cboKANSCD.Items.FindByValue(AuthC.pCENTERCD)
            cboKANSCD.SelectedIndex = cboKANSCD.Items.IndexOf(list)
        End If
        '//-----------------------------------------------
        txtHATYMD_From.Text = ""
        txtHATYMD_To.Text = ""
        txtHATTIME_From.Text = ""
        txtHATTIME_To.Text = ""
        cboHATKBN.SelectedIndex = 0

        '2014/12/04 H.Hosoda mod 監視改善2014 No.7 START
        'cboTAIOKBN.SelectedIndex = 0 
        chkTAIOU_KBN1.Checked = True
        chkTAIOU_KBN2.Checked = True
        chkTAIOU_KBN3.Checked = False
        '2014/12/04 H.Hosoda mod 監視改善2014 No.7 END

        cboTMSKB.SelectedIndex = 0

        hdnKEY_KANSCD.Value = ""
        hdnKEY_SYONO.Value = ""

        hdnScrollTop.Value = "0" '2014/01/09 T.Ono add 監視改善2013

    End Sub

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
    '*　概　要：パラメータ値より時刻HHmmss値を返す
    '*　備　考：
    '******************************************************************************
    Public Function fncTimeGet(ByVal pstrTime As String) As String
        Dim TimeFncC As New CTimeFnc
        Dim strRec As String
        strRec = ""
        If pstrTime.Length <> 0 Then
            strRec = TimeFncC.mHenkanGet(pstrTime)
        End If

        Return strRec
    End Function

    '******************************************************************************
    '*　概　要：パラメータ値より時刻HH:mm:ss値を返す
    '*　備　考：
    '******************************************************************************
    Public Function fncTimeSet(ByVal pstrTime As String, ByVal intInd As Integer) As String
        Dim TimeFncC As New CTimeFnc
        Dim strRec As String
        strRec = ""
        If IsNumeric(pstrTime) = True Then
            strRec = TimeFncC.mGet(pstrTime, intInd)
        End If

        Return strRec
    End Function

    '******************************************************************************
    '*　概　要：絞込み条件を渡すプロパティ
    '*　備　考：抽出条件１の値を渡す
    '******************************************************************************
    Public ReadOnly Property pCode1() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                If Request.Form("cboKANSCD").Length > 0 Then
                    '監視センターが指定されている場合
                    strRec = Request.Form("cboKANSCD")  '//クライアントコード一覧 指定された監視センターコード配下のクライアントコード
                Else
                    strRec = AuthC.pAUTHCENTERCD        '//クライアントコード一覧 ＡＤ認証の使用可能監視センターコード
                End If
                '2013/12/10 T.Ono mod 監視改善2013 START
                'ElseIf hdnPopcrtl.Value = "2" Then
                '    strRec = hdnKURACD.Value                '//ＪＡ支所コード一覧
                'ElseIf hdnPopcrtl.Value = "3" Then
                '    If Request.Form("cboKANSCD").Length > 0 Then
                '        '監視センターが指定されている場合
                '        strRec = Request.Form("cboKANSCD")  '//監視センター担当者一覧 指定された監視センターコード配下のクライアントコード
                '    Else
                '        strRec = AuthC.pAUTHCENTERCD        '//監視センター担当者一覧 ＡＤ認証の使用可能監視センターコード
                '    End If
                'Else
                '    strRec = ""
                'End If
            ElseIf hdnPopcrtl.Value = "2" Then
                'strRec = hdnKURACD.Value                '//ＪＡコード一覧 2014/01/21 T.Ono mod 監視改善2013 Trimをつける
                strRec = hdnKURACD.Value.Trim           '//ＪＡコード一覧
            ElseIf hdnPopcrtl.Value = "3" Then
                'strRec = hdnKURACD.Value                '//ＪＡ支所コード一覧 2014/01/21 T.Ono mod 監視改善2013 Trimをつける
                strRec = hdnKURACD.Value.Trim           '//ＪＡ支所コード一覧
            ElseIf hdnPopcrtl.Value = "4" Then
                If Request.Form("cboKANSCD").Length > 0 Then
                    '監視センターが指定されている場合
                    strRec = Request.Form("cboKANSCD")  '//監視センター担当者一覧 指定された監視センターコード配下のクライアントコード
                Else
                    strRec = AuthC.pAUTHCENTERCD        '//監視センター担当者一覧 ＡＤ認証の使用可能監視センターコード
                End If
            ElseIf hdnPopcrtl.Value = "5" Then
                strRec = "70"             '//警報コード一覧（プルダウンマスタ）
            ElseIf hdnPopcrtl.Value = "6" Then  '販売事業者グループコード一覧 2014/12/08 H.Hosoda add 監視改善2014 No.7
                '2019/11/01 T.Ono mod 監視改善2019 START
                'クライアントTo一覧
                'strRec = hdnKURACD.Value.Trim
                If Request.Form("cboKANSCD").Length > 0 Then
                    '監視センターが指定されている場合
                    strRec = Request.Form("cboKANSCD")  '//クライアントコード一覧 指定された監視センターコード配下のクライアントコード
                Else
                    strRec = AuthC.pAUTHCENTERCD        '//クライアントコード一覧 ＡＤ認証の使用可能監視センターコード
                End If
            ElseIf hdnPopcrtl.Value = "7" Then  '緊急連絡先Gr一覧 2016/11/25 H.Mori add 監視改善2016 No3-1
                'JA支所To一覧
                'strRec = hdnKURACD.Value.Trim
                strRec = hdnKURACD_TO.Value.Trim
                '2019/11/01 T.Ono mod 監視改善2019 END
            Else
                strRec = ""
            End If
            '2013/12/10 T.Ono mod 監視改善2013 END
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：絞込み条件を渡すプロパティ 2013/12/10 T.Ono mod 監視改善2013
    '*　備　考：抽出条件２の値を渡す
    '******************************************************************************
    Public ReadOnly Property pCode2() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "1"
                    strRec = ""
                Case "2"
                    strRec = ""
                Case "3", "7"  '2019/11/01 T.Ono mod 監視改善2019
                    'Case "3"
                    'strRec = hdnJACD.Value          2014/01/21 T.Ono mod 監視改善2013 Trimをつける
                    strRec = hdnJACD.Value.Trim
                Case "4"
                    strRec = ""
                Case "5"
                    strRec = ""
                Case "6"              '2014/12/08 H.Hosoda add 監視改善2014 No.7
                    strRec = ""
                Case Else
                    strRec = ""
            End Select
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：絞込み条件を渡すプロパティ 2014/12/08 H.Hosoda add 監視改善2014 No.7
    '*　備　考：抽出条件３の値を渡す
    '******************************************************************************
    Public ReadOnly Property pCode3() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "1"
                    strRec = ""
                Case "2"
                    '2019/11/01 T.Ono mod 監視改善2019
                    'strRec = ""
                    strRec = hdnKURACD_TO.Value.Trim
                Case "3"
                    'strRec = hdnHANGRP.Value.Trim '2019/11/01 T.Ono mod 監視改善2019
                    strRec = ""
                Case Else
                    strRec = ""
            End Select
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：絞込み条件を渡すプロパティ（追加） 2016/11/25 H.Mori add 監視改善2016 No3-1
    '*　備　考：抽出条件４の値を渡す
    '******************************************************************************
    Public ReadOnly Property pCode4() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "1"
                    strRec = ""
                Case "2"
                    strRec = ""
                Case "3"
                    'strRec = hdnKINRENGRP.Value.Trim '2019/11/01 T.Ono mod 監視改善2019
                    strRec = ""
                Case Else
                    strRec = ""
            End Select
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
                strRec = "クライアントコード一覧"
                '2013/12/10 T.Ono mod 監視改善2013 START
                'ElseIf hdnPopcrtl.Value = "2" Then
                '    strRec = "ＪＡ支所コード一覧"
                'ElseIf hdnPopcrtl.Value = "3" Then
                '    strRec = "監視センター担当者一覧"
                'Else
                '    strRec = ""
                'End If
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = "ＪＡコード一覧"
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = "ＪＡ支所コード一覧"
            ElseIf hdnPopcrtl.Value = "4" Then
                strRec = "監視センター担当者一覧"
            ElseIf hdnPopcrtl.Value = "5" Then
                strRec = "警報コード一覧"
            ElseIf hdnPopcrtl.Value = "6" Then      '2014/12/08 H.Hosoda add 監視改善2014 No.7
                '2019/11/01 T.Ono mod 監視改善2019
                'strRec = "販売事業者グループ一覧"
                strRec = "クライアントコード一覧"
            ElseIf hdnPopcrtl.Value = "7" Then      '2016/11/25 H.Mori add 監視改善2016 No3-1
                '2019/11/01 T.Ono mod 監視改善2019
                'strRec = "緊急連絡先Gr一覧"
                strRec = "ＪＡ支所コード一覧"
            Else
                strRec = ""
            End If
            '2013/12/10 T.Ono mod 監視改善2013 END
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
                '2013/12/10 T.Ono mod 監視改善2013 START
                'ElseIf hdnPopcrtl.Value = "2" Then
                '    'strRec = "JASS"
                '    'strRec = "JASS2"      '--- 2005/05/24 MOD Falcon ---
                '    strRec = "JASS"      '--- 2008/02/27 MOD T.Watabe ---
                'ElseIf hdnPopcrtl.Value = "3" Then
                '    strRec = "TKTANCDKN"
                'Else
                '    strRec = ""
                'End If
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = "JA"
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = "JASS"
            ElseIf hdnPopcrtl.Value = "4" Then
                strRec = "TKTANCDKN"
            ElseIf hdnPopcrtl.Value = "5" Then
                strRec = "PULLCODE"
            ElseIf hdnPopcrtl.Value = "6" Then   '2014/12/08 H.Hosoda add 監視改善2014 No.7
                '2019/11/01 T.Ono mod 監視改善2019
                'strRec = "HANG"
                strRec = "CLI"
            ElseIf hdnPopcrtl.Value = "7" Then   '2016/11/25 H.Mori add 監視改善2016 No3-1
                '2019/11/01 T.Ono mod 監視改善2019
                'strRec = "JAHOKOKU2"
                strRec = "JASS"
            Else
                strRec = ""
            End If
            '2013/12/10 T.Ono mod 監視改善2013 END
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
                '2013/12/10 T.Ono mod 監視改善2013 START
                'ElseIf hdnPopcrtl.Value = "2" Then
                '    strRec = "hdnACBCD"
                'ElseIf hdnPopcrtl.Value = "3" Then
                '    strRec = "hdnTKTANCD"
                'Else
                '    strRec = ""
                'End If
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = "hdnJACD"
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = "hdnACBCD"
            ElseIf hdnPopcrtl.Value = "4" Then
                strRec = "hdnTKTANCD"
            ElseIf hdnPopcrtl.Value = "5" Then
                strRec = "hdnKMCD"
            ElseIf hdnPopcrtl.Value = "6" Then  '2014/12/08 H.Hosoda add 監視改善2014 No.7
                '2019/11/01 T.Ono mod 監視改善2019
                'strRec = "hdnHANGRP"
                strRec = "hdnKURACD_TO"
            ElseIf hdnPopcrtl.Value = "7" Then  '2016/11/25 H.Mori add 監視改善2016 No3-1
                '2019/11/01 T.Ono mod 監視改善2019
                'strRec = "hdnKINRENGRP"
                strRec = "hdnACBCD_TO"
            Else
                strRec = ""
            End If
            '2013/12/10 T.Ono mod 監視改善2013 END
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
                '2013/12/10 T.Ono mod 監視改善2013 START
                'ElseIf hdnPopcrtl.Value = "2" Then
                '    strRec = "txtACBNM"
                'ElseIf hdnPopcrtl.Value = "3" Then
                '    strRec = "txtTKTANCD"
                'Else
                '    strRec = ""
                'End If
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = "txtJANM"
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = "txtACBNM"
            ElseIf hdnPopcrtl.Value = "4" Then
                strRec = "txtTKTANCD"
            ElseIf hdnPopcrtl.Value = "5" Then
                strRec = "hdnKMNM"
            ElseIf hdnPopcrtl.Value = "6" Then  '2014/12/08 H.Hosoda add 監視改善2014 No.7
                '2019/11/01 T.Ono mod 監視改善2019
                'strRec = "txtHANGRP"
                strRec = "txtKURACD_TO"
            ElseIf hdnPopcrtl.Value = "7" Then  '2016/11/25 H.Mori add 監視改善2016 No3-1
                '2019/11/01 T.Ono mod 監視改善2019
                'strRec = "txtKINRENGRP"
                strRec = "txtACBNM_TO"
            Else
                strRec = ""
            End If
            '2013/12/10 T.Ono mod 監視改善2013 END
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*　概　要：コード２を返すオブジェクトの名前値を渡すプロパティ
    '*　備　考：データ選択後、コードを返すオブジェクト名を指定する　2019/11/01 T.Ono add 監視改善2019
    '******************************************************************************
    Public ReadOnly Property pBackCode2() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = "hdnJACD_CLI"
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = "hdnACBCD_CLI"
            ElseIf hdnPopcrtl.Value = "4" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "5" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "6" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "7" Then
                strRec = "hdnACBCD_TO_CLI"
            Else
                strRec = ""
            End If

            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*　概　要：カレンダー日付を返すの値を返すオブジェクトを指定
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pBackDate() As String
        Get
            Dim strRec As String
            If hdnCalendar.Value = "1" Then
                strRec = "txtHATYMD_From"
            Else
                strRec = "txtHATYMD_To"
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：フォーカスセットされる項目名を返すオブジェクトを指定
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pBackFocs() As String
        Get
            Dim strRec As String
            If hdnCalendar.Value = "1" Then
                strRec = "txtHATYMD_From"
            Else
                strRec = "txtHATYMD_To"
            End If

            If hdnPopcrtl.Value = "1" Then
                strRec = "btnKURACD"
                '2013/12/10 T.Ono mod 監視改善2013 START
                'ElseIf hdnPopcrtl.Value = "2" Then
                '    strRec = "btnACBCD"
                'Else
                '    strRec = ""
                'End If
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = "btnJACD"
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = "btnACBCD"
            ElseIf hdnPopcrtl.Value = "4" Then
                strRec = "btnTKTANCD"
            ElseIf hdnPopcrtl.Value = "5" Then
                strRec = "btnKMCD"
            ElseIf hdnPopcrtl.Value = "6" Then   '2014/12/08 H.Hosoda add 監視改善2014 No.7
                '2019/11/01 T.Ono mod 監視改善2019
                'strRec = "btnHANGRP"
                strRec = "btnKURACD_TO"
            ElseIf hdnPopcrtl.Value = "7" Then   '2016/11/25 H.Mori add 監視改善2016 No3-1
                '2019/11/01 T.Ono mod 監視改善2019
                'strRec = "btnKINRENGRP"
                strRec = "btnACBCD_TO"
            Else
                strRec = ""
            End If
            '2013/12/10 T.Ono mod 監視改善2013 END
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：JA支所コードのクリア（hdn）
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pClear1() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "hdnACBCD"
            ElseIf hdnPopcrtl.Value = "2" Then
                'strRec = "" 2013/12/10 T.Ono mod 監視改善2013
                strRec = "hdnACBCD"
            ElseIf hdnPopcrtl.Value = "6" Then  '2014/12/08 H.Hosoda add 監視改善2014 No.7
                strRec = "hdnACBCD"
            ElseIf hdnPopcrtl.Value = "7" Then  '2016/11/25 H.Mori add 監視改善2016 No3-1
                '2019/11/01 T.Ono mod 監視改善2019
                'strRec = "hdnACBCD"
                strRec = ""
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：JA支所コードのクリア（txt）
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pClear2() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "txtACBNM"
            ElseIf hdnPopcrtl.Value = "2" Then
                'strRec = "" 2013/12/10 T.Ono mod 監視改善2013
                strRec = "txtACBNM"
            ElseIf hdnPopcrtl.Value = "6" Then  '2014/12/08 H.Hosoda add 監視改善2014 No.7
                strRec = "txtACBNM"
            ElseIf hdnPopcrtl.Value = "7" Then  '2016/11/25 H.Mori add 監視改善2016 No3-1
                '2019/11/01 T.Ono mod 監視改善2019
                'strRec = "txtACBNM"
                strRec = ""
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：JAコードのクリア（hdn） 2013/12/10 T.Ono add 監視改善2013
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pClear3() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "hdnJACD"
            ElseIf hdnPopcrtl.Value = "2" Then
                '2019/11/01 T.Ono mod 監視改善2019
                'strRec = ""
                strRec = "hdnACBCD_TO"
            ElseIf hdnPopcrtl.Value = "6" Then '2019/11/01 T.Ono add 監視改善2019
                strRec = "hdnJACD"
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：JAコードのクリア（txt） 2013/12/10 T.Ono add 監視改善2013
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pClear4() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "txtJANM"
            ElseIf hdnPopcrtl.Value = "2" Then
                '2019/11/01 T.Ono mod 監視改善2019
                'strRec = ""
                strRec = "txtACBNM_TO"
            ElseIf hdnPopcrtl.Value = "6" Then '2019/11/01 T.Ono add 監視改善2019
                strRec = "txtJANM"
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：販売事業者グループコードのクリア（hdn） 2014/12/08 H.Hosoda add 監視改善2014 No.7
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pClear5() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                '2019/11/01 T.Ono mod 監視改善2019
                'strRec = "hdnHANGRP"
                strRec = "hdnACBCD_TO"
            ElseIf hdnPopcrtl.Value = "6" Then '2019/11/01 T.Ono add 監視改善2019
                strRec = "hdnACBCD_TO"
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：販売事業者グループコードのクリア（txt） 2014/12/08 H.Hosoda add 監視改善2014 No.7
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pClear6() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                '2019/11/01 T.Ono mod 監視改善2019
                'strRec = "txtHANGRP"
                strRec = "txtACBNM_TO"
            ElseIf hdnPopcrtl.Value = "6" Then '2019/11/01 T.Ono add 監視改善2019
                strRec = "txtACBNM_TO"
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：緊急連絡先Grのクリア（hdn） 2016/11/25 H.Mori add 監視改善2016 No3-1
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pClear7() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                '2019/11/01 T.Ono mod 監視改善2019
                'strRec = "hdnKINRENGRP"
                strRec = "hdnJACD_CLI"
            ElseIf hdnPopcrtl.Value = "6" Then '2019/11/01 T.Ono add 監視改善2019
                strRec = "hdnJACD_CLI"
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：緊急連絡先Grのクリア（txt） 2016/11/25 H.Mori add 監視改善2016 No3-1
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pClear8() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                '2019/11/01 T.Ono mod 監視改善2019
                'strRec = "txtKINRENGRP"
                strRec = "hdnACBCD_CLI"
            ElseIf hdnPopcrtl.Value = "6" Then '2019/11/01 T.Ono add 監視改善2019
                strRec = "hdnACBCD_CLI"
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：クリア 2019/11/01 T.Ono add 監視改善2019
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pClear9() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "hdnACBCD_TO_CLI"
            ElseIf hdnPopcrtl.Value = "6" Then '2019/11/01 T.Ono add 監視改善2019
                strRec = "hdnACBCD_TO_CLI"
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
                '2019/11/01 T.Ono mod 監視改善2019
                'strRec = ""
                strRec = "fncSetTo"
            ElseIf hdnPopcrtl.Value = "2" Then  'ＪＡ
                strRec = ""
            ElseIf hdnPopcrtl.Value = "3" Then  'ＪＡ支所
                '2019/11/01 T.Ono mod 監視改善2019
                'strRec = ""
                strRec = "fncSetTo"
            ElseIf hdnPopcrtl.Value = "4" Then  '監視センター担当者
                strRec = ""
            ElseIf hdnPopcrtl.Value = "5" Then '警報メッセージ(PULLCODE)
                strRec = "fncKeihoMsgCopy"
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：hdnSelectClickの値を渡すプロパティ
    '*　備　考：検索ボタン押下時のみ"1"が代入。IFRAME内にて遷移的出力なのか検索出力なのかを判定(MESSAGE)
    '******************************************************************************
    Public ReadOnly Property pSelectClick() As String
        Get
            Return hdnSelectClick.Value
        End Get
    End Property

    '******************************************************************************
    '*　概　要：監視センターの値を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pKANSCD() As String
        Get
            Return Request.Form("cboKANSCD")
        End Get
    End Property

    '******************************************************************************
    '*　概　要：対応完了日・受信日の値を渡すプロパティ
    '*　備　考：2017/10/25 H.Mori add 2017改善開発 No3-1
    '******************************************************************************
    Public ReadOnly Property pKikankbn() As String
        Get
            Dim strKIKANKBN As String = ""
            If rdoKIKAN1.Checked = True Then
                strKIKANKBN = "1"      '対応完了日
            ElseIf rdoKIKAN2.Checked = True Then
                strKIKANKBN = "2"      '受信日
            End If
            Return strKIKANKBN
        End Get
    End Property

    '******************************************************************************
    '*　概　要：発生期間（From）の値を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pHATYMD_From() As String
        Get
            Return fncDateGet(txtHATYMD_From.Text)
        End Get
    End Property

    '******************************************************************************
    '*　概　要：発生期間（To）の値を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pHATYMD_To() As String
        Get
            Return fncDateGet(txtHATYMD_To.Text)
        End Get
    End Property

    '******************************************************************************
    '*　概　要：発生時刻（From）の値を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pHATTIME_From() As String
        Get
            Return fncTimeGet(txtHATTIME_From.Text)
        End Get
    End Property

    '******************************************************************************
    '*　概　要：発生時刻（To）の値を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pHATTIME_To() As String
        Get
            Return fncTimeGet(txtHATTIME_To.Text)
        End Get
    End Property

    '******************************************************************************
    '*　概　要：監視センター担当者の値を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pTKTANCD() As String
        Get
            Return hdnTKTANCD.Value.Trim()          '2012/04/25 NEC ou Upd
        End Get
    End Property

    '******************************************************************************
    '*　概　要：監視センター担当者の値を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pTKTANNAME() As String
        Get
            Return txtTKTANCD.Text.Trim()           '2012/04/25 NEC ou Upd
        End Get
    End Property

    '******************************************************************************
    '*　概　要：発生区分の値を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pHATKBN() As String
        Get
            Return Request.Form("cboHATKBN")
        End Get
    End Property

    '******************************************************************************
    '*　概　要：対応区分の値を渡すプロパティ 2014/12/04 H.Hosoda del 監視改善2014 No.7
    '*　備　考：
    '******************************************************************************
    'Public ReadOnly Property pTAIOKBN() As String
    '    Get
    '        Return Request.Form("cboTAIOKBN")
    '    End Get
    'End Property

    '******************************************************************************
    '*　概　要：対応区分（電話）の値を渡すプロパティ　2014/12/04 H.Hosoda add 監視改善2014 No.7
    '*　備　考：0：チェックなし　1：チェックあり
    '******************************************************************************
    Public ReadOnly Property pTAIOKBN1() As String
        Get
            If chkTAIOU_KBN1.Checked = False Then
                Return "0"
            Else
                Return "1"
            End If
        End Get
    End Property

    '******************************************************************************
    '*　概　要：対応区分（出動）の値を渡すプロパティ　2014/12/04 H.Hosoda add 監視改善2014 No.7
    '*　備　考：0：チェックなし　1：チェックあり
    '******************************************************************************
    Public ReadOnly Property pTAIOKBN2() As String
        Get
            If chkTAIOU_KBN2.Checked = False Then
                Return "0"
            Else
                Return "1"
            End If
        End Get
    End Property

    '******************************************************************************
    '*　概　要：対応区分（重複）の値を渡すプロパティ　2014/12/04 H.Hosoda add 監視改善2014 No.7
    '*　備　考：0：チェックなし　1：チェックあり
    '******************************************************************************
    Public ReadOnly Property pTAIOKBN3() As String
        Get
            If chkTAIOU_KBN3.Checked = False Then
                Return "0"
            Else
                Return "1"
            End If
        End Get
    End Property

    '******************************************************************************
    '*　概　要：処理区分の値を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pTMSKB() As String
        Get
            Return Request.Form("cboTMSKB")
        End Get
    End Property

    '******************************************************************************
    '*　概　要：お客様電話番号の値を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pJUTEL() As String
        Get
            Return txtJUTEL.Text
        End Get
    End Property

    '******************************************************************************
    '*　概　要：結線番号の値を渡すプロパティ　2014/12/05 H.Hosoda add 監視改善2014 No.7 2016/11/25 H.Mori del 監視改善2016 No3-2
    '*　備　考：
    '******************************************************************************
    'Public ReadOnly Property pNCUTEL() As String
    '    Get
    '        Return txtNCUTEL.Text
    '    End Get
    'End Property

    '******************************************************************************
    '*　概　要：お客様名の値を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pJUSYONM() As String
        Get
            Return txtJUSYONM.Text
        End Get
    End Property

    '******************************************************************************
    '*　概　要：お客様名カナの値を渡すプロパティ 2016/11/24 H.Mori del 監視改善2016 No3-3
    '*　備　考：
    '******************************************************************************
    'Public ReadOnly Property pJUSYOKN() As String
    '    Get
    '        Return txtJUSYOKN.Text
    '    End Get
    'End Property

    '******************************************************************************
    '*　概　要：クライアントコードの値を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pKURACD() As String
        Get
            Return hdnKURACD.Value.Trim()       '2012/04/25 NEC ou Upd
        End Get
    End Property

    '******************************************************************************
    '*　概　要：クライアント名の値を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pKURACD_NAME() As String
        Get
            Return txtKURACD.Text.Trim()        '2012/04/25 NEC ou Upd
        End Get
    End Property
    '******************************************************************************
    '*　概　要：クライアントコードTOの値を渡すプロパティ
    '*　備　考：2019/11/01 T.Ono add 監視改善2019
    '******************************************************************************
    Public ReadOnly Property pKURACD_TO() As String
        Get
            Return hdnKURACD_TO.Value.Trim()
        End Get
    End Property

    '******************************************************************************
    '*　概　要：クライアント名TOの値を渡すプロパティ
    '*　備　考：2019/11/01 T.Ono add 監視改善2019
    '******************************************************************************
    Public ReadOnly Property pKURACD_TO_NAME() As String
        Get
            Return txtKURACD_TO.Text.Trim()
        End Get
    End Property
    '******************************************************************************
    '*　概　要：ＪＡコードの値を渡すプロパティ 2013/12/10 T.Ono add 監視改善2013
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pJACD() As String
        Get
            Return hdnJACD.Value.Trim()
        End Get
    End Property

    '******************************************************************************
    '*　概　要：ＪＡ名の値を渡すプロパティ 2013/12/10 T.Ono add 監視改善2013
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pJACD_NAME() As String
        Get
            Return txtJANM.Text.Trim()
        End Get
    End Property
    '******************************************************************************
    '*　概　要：ＪＡコードに紐づくクライアントコードの値を渡すプロパティ '2019/11/01 T.Ono add 監視改善2019
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pJACD_CLI() As String
        Get
            Return hdnJACD_CLI.Value.Trim
        End Get
    End Property
    '******************************************************************************
    '*　概　要：販売事業者グループコードの値を渡すプロパティ 2014/12/08 H.Hosoda add 監視改善2014 No.7
    '*　備　考：2019/11/01 T.Ono del 監視改善2019
    '******************************************************************************
    'Public ReadOnly Property pHANGRP() As String
    '    Get
    '        Return hdnHANGRP.Value.Trim()
    '    End Get
    'End Property

    '******************************************************************************
    '*　概　要：販売事業者グループ名の値を渡すプロパティ 2014/12/08 H.Hosoda add 監視改善2014 No.7
    '*　備　考：2019/11/01 T.Ono del 監視改善2019
    '******************************************************************************
    'Public ReadOnly Property pHANGRP_NAME() As String
    '    Get
    '        Return txtHANGRP.Text.Trim()
    '    End Get
    'End Property

    '******************************************************************************
    '*　概　要：緊急連絡先Grの値を渡すプロパティ 2016/11/25 H.Mori add 監視改善2016 No3-1
    '*　備　考：2019/11/01 T.Ono del 監視改善2019
    '******************************************************************************
    'Public ReadOnly Property pKINRENGRP() As String
    '    Get
    '        Return hdnKINRENGRP.Value.Trim()
    '    End Get
    'End Property

    '******************************************************************************
    '*　概　要：緊急連絡先Gr名の値を渡すプロパティ 2014/12/08 H.Hosoda add 監視改善2014 No.7
    '*　備　考：2019/11/01 T.Ono del 監視改善2019
    '******************************************************************************
    'Public ReadOnly Property pKINRENGRP_NAME() As String
    '    Get
    '        Return txtKINRENGRP.Text.Trim()
    '    End Get
    'End Property

    '******************************************************************************
    '*　概　要：ＪＡ支所コードの値を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pACBCD() As String
        Get
            Return hdnACBCD.Value.Trim()        '2012/04/25 NEC ou Upd
        End Get
    End Property

    '******************************************************************************
    '*　概　要：ＪＡ支所名の値を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pACBCD_NAME() As String
        Get
            Return txtACBNM.Text.Trim()         '2012/04/25 NEC ou Upd
        End Get
    End Property
    '******************************************************************************
    '*　概　要：ＪＡ支所コードに紐づくクライアントコードの値を渡すプロパティ '2019/11/01 T.Ono add 監視改善2019
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pACBCD_CLI() As String
        Get
            Return hdnACBCD_CLI.Value.Trim
        End Get
    End Property
    '******************************************************************************
    '*　概　要：ＪＡ支所コードToの値を渡すプロパティ
    '*　備　考：2019/11/01 T.Ono add 監視改善2019
    '******************************************************************************
    Public ReadOnly Property pACBCD_TO() As String
        Get
            Return hdnACBCD_TO.Value.Trim()
        End Get
    End Property

    '******************************************************************************
    '*　概　要：ＪＡ支所名TOの値を渡すプロパティ
    '*　備　考：2019/11/01 T.Ono add 監視改善2019
    '******************************************************************************
    Public ReadOnly Property pACBCD_TO_NAME() As String
        Get
            Return txtACBNM_TO.Text.Trim()
        End Get
    End Property
    '******************************************************************************
    '*　概　要：ＪＡ支所TOコードに紐づくクライアントコードの値を渡すプロパティ '2019/11/01 T.Ono add 監視改善2019
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pACBCD_TO_CLI() As String
        Get
            Return hdnACBCD_TO_CLI.Value.Trim
        End Get
    End Property
    '******************************************************************************
    '*　概　要：お客様名コードの値を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pUSER_CD() As String
        Get
            Return txtUSER_CD.Text
        End Get
    End Property

    '2011.11.15 ADD H.Uema
    '******************************************************************************
    '*　概　要：警報コードの値を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pKMCD() As String
        Get
            'Return txtKMCD.Text    '2013/12/10 T.Ono mod 監視改善2013
            Return hdnKMCD.Value.Trim()
        End Get
    End Property

    '******************************************************************************
    '*　概　要：警報名の値を渡すプロパティ '2013/12/10 T.Ono add 監視改善2013
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pKMNM() As String
        Get
            Return txtKMCD.Text.Trim()
        End Get
    End Property

    '******************************************************************************
    '*　概　要：一覧で選択した処理番号の値を渡すプロパティ
    '*　備　考：対応入力画面より戻ってきた時に使用
    '******************************************************************************
    Public ReadOnly Property pKEY_SYONO() As String
        Get
            Return hdnKEY_SYONO.Value
        End Get
    End Property

    '******************************************************************************
    '*　概　要：監視センターコードの値を渡すプロパティ
    '*　備　考：対応入力画面より戻ってきた時に使用
    '******************************************************************************
    Public ReadOnly Property pKEY_KANSCD() As String
        Get
            Return hdnKEY_KANSCD.Value
        End Get
    End Property

    '******************************************************************************
    '*　概　要：スクロールバーの位置を渡すプロパティ　2013/12/10 T.Ono add 監視改善2013
    '*　備　考：対応入力画面より戻ってきた時に使用
    '******************************************************************************
    Public ReadOnly Property pScrollTop() As String
        Get
            Return hdnScrollTop.Value
        End Get
    End Property

    '******************************************************************************
    'コンボボックスの作成
    '******************************************************************************
    Private Sub fncCombo_Creatr_KANSI_CD()
        '//監視センターコンボ
        Dim strGROUPNAME As String = AuthC.pGROUPNAME
        Dim arrGroupName() As String = strGROUPNAME.Split(Convert.ToChar(","))
        '2005/12/03 NEC UPDATE START
        'If Array.IndexOf(arrGroupName, AuthC.pGROUP_UNKOU) >= 0 Then
        If Array.IndexOf(arrGroupName, AuthC.pGROUP_UNKOU) >= 0 Or strGROUPNAME.IndexOf(AuthC.pGROUP_EIGYOU) >= 0 Then
            '2005/12/03 NEC UPDATE END
            '運行開発部、営業所の場合は未選択ＯＫ　各監視センターの場合は監視センターを選択する
            cboKANSCD.pComboTitle = True
        Else
            cboKANSCD.pComboTitle = False
        End If
        cboKANSCD.pNoData = False
        cboKANSCD.pType = "KANSICENTER"
        cboKANSCD.pAllCenterCd = AuthC.pAUTHCENTERCD
        cboKANSCD.mMakeCombo()
    End Sub

    Private Sub fncCombo_Create_HASEIKBN()
        '//発生区分コンボ
        cboHATKBN.pComboTitle = True
        cboHATKBN.pNoData = False
        cboHATKBN.pType = "HASSEIKBN"                '//発生区分
        cboHATKBN.mMakeCombo()
    End Sub

    '2014/12/04 H.Hosoda del 監視改善2014 No.7
    'Private Sub fncCombo_Create_TAIOUKBN()
    '    '//対応区分コンボ
    '    cboTAIOKBN.pComboTitle = True
    '    cboTAIOKBN.pNoData = False
    '    cboTAIOKBN.pType = "TAIOUKBN"               '//対応区分
    '    cboTAIOKBN.mMakeCombo()
    'End Sub

    Private Sub fncCombo_Create_SYORIKBN()
        '//処理区分コンボ
        cboTMSKB.pComboTitle = True
        cboTMSKB.pNoData = False
        cboTMSKB.pType = "SYORIKBN"                 '//処理区分
        cboTMSKB.mMakeCombo()
    End Sub

End Class
