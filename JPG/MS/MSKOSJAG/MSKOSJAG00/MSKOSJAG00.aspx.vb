'***********************************************
'顧客検索  メイン画面
'***********************************************
Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common
Imports JPG.Common.log
Imports System.Text

Partial Class MSKOSJAG00
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
            txtCLI_CD.Attributes.Add("ReadOnly", "true")
            txtCLI_CD_TO.Attributes.Add("ReadOnly", "true") '2019/11/01 T.Ono add 監視改善2019 №1
            txtJA_CD.Attributes.Add("ReadOnly", "true") '2013/11/26 T.Ono add 監視改善2013№2
            txtHANGRP.Attributes.Add("ReadOnly", "true") '2014/12/03 H.Hosoda add 監視改善2014 No.6
            txtHAN_CD.Attributes.Add("ReadOnly", "true")
            'txtKINRENGRP.Attributes.Add("ReadOnly", "true") '2016/11/17 H.Mori add 2016改善開発 No2-1 '2019/11/01 T.Ono del
            txtHAN_CD_TO.Attributes.Add("ReadOnly", "true") '2016/11/24 H.Mori add 2016改善開発 No2-2
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
        '[顧客検索]使用可能権限(運:○/営:×→○/監:△/出:×)
        'AuthC.fncAuthCheck(Server, AuthC.pGROUP_UNKOU & "," & AuthC.pGROUP_KANSHI) '2017/07/20 H.Mori mod
        AuthC.fncAuthCheck(Server, AuthC.pGROUP_UNKOU & "," & AuthC.pGROUP_KANSHI & "," & AuthC.pGROUP_EIGYOU)

        '//------------------------------------------
        '<TODO>ポップアップ/登録系フレームの出力
        '      [hdnKensaku(Hidden)]を作成する事
        If hdnKensaku.Value = "COPOPUPG00" Then
            Server.Transfer("../../../Popup/COPOPUPG00.aspx")
        End If
        '//一覧のIFRAMEを出力する
        If hdnKensaku.Value = "MSKOSJFG00" Then
            Server.Transfer("MSKOSJFG00.aspx")
        End If
        '対応入力画面へ遷移
        If hdnKensaku.Value = "KETAIJAG00" Then
            Server.Transfer("../../../KE/KETAIJAG/KETAIJAG00/KETAIJAG00.aspx")
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
        strScript.Append(cscript1.mWriteScript(
             MyBase.MapPath("../../../MS/MSKOSJAG/MSKOSJAG00/") & "MSKOSJAG00.js"))
        '<フォーカス関連関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncFo.js"))
        '<全角チェック関数>
        '--- ↓2005/05/19 DEL Falcon↓ ---
        'strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncZenkakuChk.js"))
        '--- ↑2005/05/19 DEL Falcon↑ ---
        '<電話番号チェック関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncTel.js"))

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

            Dim list As New ListItem            'リストアイテム
            If Request.Path.LastIndexOf("SYCTIJAG00") >= 0 Then
                'ＣＴＩからの遷移の場合

                Dim SYCTIJAG00_C As New SYCTIJAG00.SYCTIJAG00
                SYCTIJAG00_C = CType(Context.Handler, SYCTIJAG00.SYCTIJAG00)

                '需要家電話番号
                txtTEL.Text = SYCTIJAG00_C.gstrCTITELNO
                '選択キーを保持する
                hdnKEY_CLI_CD.Value = SYCTIJAG00_C.gstrCLI_CD
                'hdnKEY_JA_CD.Value = SYCTIJAG00_C.gstrHAN_CD        '2013/12/09 T.Ono add 監視改善2013
                hdnKEY_HAN_CD.Value = SYCTIJAG00_C.gstrHAN_CD
                hdnKEY_USER_CD.Value = SYCTIJAG00_C.gstrUSER_CD

                'ＣＴＩ未登録フラグ
                hdnMOVE_MITOKBN.Value = "1"

                '検索ボタン押下時と同様の処理を行うか否か
                hdnSelectClick.Value = SYCTIJAG00_C.gstrKENFLG
            Else
                'ＣＴＩ未登録フラグ(ＣＴＩにて一意で無かった場合のみセットする)
                hdnMOVE_MITOKBN.Value = ""

                If Request.Form("hdnMyAspx") = "KETAIJAG00" Then
                    '監視センターコード
                    list = cboKANSCD.Items.FindByValue(Request.Form("hdnMOVE_KANSCD"))
                    cboKANSCD.SelectedIndex = cboKANSCD.Items.IndexOf(list)
                    '需要家電話番号
                    txtTEL.Text = Request.Form("hdnMOVE_TEL")
                    '結線番号削除 2016/11/16 H.Mori del 2016改善開発 No2-3 
                    ''結線番号 2014/12/02 H.Hosoda add 監視改善2014 No.6
                    'txtNCUTEL.Text = Request.Form("hdnMOVE_NCUTEL")
                    '需要家名
                    txtNAME.Text = Request.Form("hdnMOVE_NAME")
                    'カナ削除 2016/11/16 H.Mori del 2016改善開発 No2-4
                    ''需要家名カナ
                    'txtKANA.Text = Request.Form("hdnMOVE_KANAD")
                    '需要家住所 2013/12/09 T.Ono add 監視改善2013
                    txtADDR.Text = Request.Form("hdnMOVE_ADDR")
                    'クライアントコード
                    hdnCLI_CD.Value = Request.Form("hdnMOVE_CLI_CD")
                    'クライアント名
                    txtCLI_CD.Text = Request.Form("hdnMOVE_CLI_CD_NAME")
                    'クライアントToコード 2019/11/01 T.Ono add 監視改善2019 No1
                    hdnCLI_CD_TO.Value = Request.Form("hdnMOVE_CLI_CD_TO")
                    'クライアントTo名 2019/11/01 T.Ono add 監視改善2019 No1
                    txtCLI_CD_TO.Text = Request.Form("hdnMOVE_CLI_CD_TO_NAME")
                    'ＪＡコード 2013/12/09 T.Ono add 監視改善2013
                    hdnJA_CD.Value = Request.Form("hdnMOVE_JA_CD")
                    'ＪＡ名 2013/12/09 T.Ono add 監視改善2013
                    txtJA_CD.Text = Request.Form("hdnMOVE_JA_CD_NAME")
                    'ＪＡコードに紐づくクライアントコード 2019/11/01 T.Ono add 監視改善2019
                    hdnJA_CD_CLI.Value = Request.Form("hdnMOVE_JA_CD_CLI")
                    '販売事業者グループコード 2014/12/03 H.Hosoda add 監視改善2014 No.6
                    hdnHANGRP.Value = Request.Form("hdnMOVE_HAN_GRP")
                    '販売事業者グループ名 2014/12/03 H.Hosoda add 監視改善2014 7No.6
                    txtHANGRP.Text = Request.Form("hdnMOVE_HAN_GRP_NAME")
                    '2019/11/01 T.Ono del 監視改善2019 №1
                    ''緊急連絡先Gr 2016/11/22 H.Mori add 2016改善開発 No2-1
                    'hdnKINRENGRP.Value = Request.Form("hdnMOVE_KINREN_GRP")
                    ''緊急連絡先Gr名 2016/11/22 H.Mori add 2016改善開発 No2-1
                    'txtKINRENGRP.Text = Request.Form("hdnMOVE_KINREN_GRP_NAME")
                    'ＪＡ支所コード
                    hdnHAN_CD.Value = Request.Form("hdnMOVE_HAN_CD")
                    'ＪＡ支所名
                    txtHAN_CD.Text = Request.Form("hdnMOVE_HAN_CD_NAME")
                    'ＪＡ支所名に紐づくクライアントコード 2019/11/01 T.Ono add 監視改善2019
                    hdnHAN_CD_CLI.Value = Request.Form("hdnMOVE_HAN_CD_CLI")
                    'ＪＡ支所コードTO 2016/11/24 H.Mori add 2016改善開発 No2-2
                    hdnHAN_CD_TO.Value = Request.Form("hdnMOVE_HAN_CD_TO")
                    'ＪＡ支所名TO     2016/11/24 H.Mori add 2016改善開発 No2-2
                    txtHAN_CD_TO.Text = Request.Form("hdnMOVE_HAN_CD_NAME_TO")
                    'ＪＡ支所名TOに紐づくクライアントコード 2019/11/01 T.Ono add 監視改善2019
                    hdnHAN_CD_TO_CLI.Value = Request.Form("hdnMOVE_HAN_CD_TO_CLI")
                    'お客様名コード
                    txtUSER_CD.Text = Request.Form("hdnMOVE_USER_CD")
                    'お客様フラグ 2013/12/20 T.Ono add 監視改善2013
                    ''未開通
                    If Request.Form("hdnMOVE_USER_FLG0") = "1" Then
                        chkUSER_FLG0.Checked = True
                    Else
                        chkUSER_FLG0.Checked = False
                    End If
                    ''運用中
                    If Request.Form("hdnMOVE_USER_FLG1") = "1" Then
                        chkUSER_FLG1.Checked = True
                    Else
                        chkUSER_FLG1.Checked = False
                    End If
                    ''休止中
                    If Request.Form("hdnMOVE_USER_FLG2") = "1" Then
                        chkUSER_FLG2.Checked = True
                    Else
                        chkUSER_FLG2.Checked = False
                    End If
                    '販売区分 2015/12/11 H.Mori add 監視改善2015
                    ''メータ売
                    If Request.Form("hdnMOVE_HANBAI_KBN1") = "1" Then
                        chkHANBAI_KBN1.Checked = True
                    Else
                        chkHANBAI_KBN1.Checked = False
                    End If
                    ''ボンベ売
                    If Request.Form("hdnMOVE_HANBAI_KBN2") = "1" Then
                        chkHANBAI_KBN2.Checked = True
                    Else
                        chkHANBAI_KBN2.Checked = False
                    End If
                    ''両方
                    If Request.Form("hdnMOVE_HANBAI_KBN3") = "1" Then
                        chkHANBAI_KBN3.Checked = True
                    Else
                        chkHANBAI_KBN3.Checked = False
                    End If
                    ''その他
                    If Request.Form("hdnMOVE_HANBAI_KBN4") = "1" Then
                        chkHANBAI_KBN4.Checked = True
                    Else
                        chkHANBAI_KBN4.Checked = False
                    End If
                    ''データなし
                    If Request.Form("hdnMOVE_HANBAI_KBN5") = "1" Then
                        chkHANBAI_KBN5.Checked = True
                    Else
                        chkHANBAI_KBN5.Checked = False
                    End If
                    ''例外
                    If Request.Form("hdnMOVE_HANBAI_KBN6") = "1" Then
                        chkHANBAI_KBN6.Checked = True
                    Else
                        chkHANBAI_KBN6.Checked = False
                    End If

                    '選択キーを保持する
                    hdnKEY_CLI_CD.Value = Request.Form("hdnKEY_CLI_CD")
                    hdnKEY_CLI_CD_TO.Value = Request.Form("hdnKEY_CLI_CD_TO")   '2019/11/01 T.Ono add 監視改善2019 No1
                    hdnKEY_JA_CD.Value = Request.Form("hdnKEY_JA_CD")           '2013/12/09 T.Ono add 監視改善2013
                    hdnKEY_HAN_GRP.Value = Request.Form("hdnKEY_HAN_GRP")       '2014/12/03 H.Hosoda add 監視改善2014 No.6
                    'hdnKEY_KINREN_GRP.Value = Request.Form("hdnKEY_KINREN_GRP") '2016/11/22 H.Mori add 監視改善2016 No2-1  2019/11/01 T.Ono dell 監視改善2019 No1
                    hdnKEY_HAN_CD.Value = Request.Form("hdnKEY_HAN_CD")
                    hdnKEY_USER_CD.Value = Request.Form("hdnKEY_USER_CD")
                    hdnScrollTop.Value = Request.Form("hdnScrollTop")           '2013/12/10 T.Ono add 監視改善2013

                    '--- ↓2005/04/20 DEL　Falcon↓ -----------------
                    ''検索ボタン押下時と同様の処理を行う
                    'hdnSelectClick.Value = "1"
                    '--- ↑2005/04/20 DEL　Falcon↑ -----------------

                    '--- ↓2005/04/20 MOD　Falcon↓ -----------------
                    '対応入力ボタンを押下し遷移し戻って来た場合は検索処理は行わない
                    If Convert.ToString(Request.Form("hdnMOVE_MODE")) = "1" Then
                        '検索ボタンにフォーカスをセット
                        strMsg.Append("Form1.btnSelect.focus();")
                    Else
                        '検索ボタン押下時と同様の処理を行う
                        hdnSelectClick.Value = "1"
                    End If
                    '--- ↑2005/04/20 MOD　Falcon↑ -----------------
                Else
                    '通常の遷移時(メニューより)
                    hdnSelectClick.Value = ""

                    '//------------------------------------------------
                    '<TODO>フォーカスをセットする（初期表示なのでキーにセットする）
                    strMsg.Append("Form1.cboKANSCD.focus();")
                End If
            End If
        Else
            '//--------------------------------------
            '//２回目以降実行される
            '//--------------------------------------
        End If

        '//-------------------------------------------------
        '<TODO>自分の画面IDをHIDDENのhdnMyAspxに書き込む（システム共通）
        hdnMyAspx.Value = "MSKOSJAG00"
        '//-------------------------------------------------
    End Sub

    '******************************************************************************
    '* 各コントロールの設定値の初期化
    '******************************************************************************
    Private Sub fncIni_format()

        'コンボ作成
        Call fncCombo_Creatr_KANSICD()     '監視センターコンボ

        '//監視センターコード-----------------------------
        'ADにて自分の監視センターコードを初期選択する
        '運行開発部はTOPを選択
        Dim list As New ListItem
        Dim strGROUPNAME As String = AuthC.pGROUPNAME
        Dim arrGroupName() As String = strGROUPNAME.Split(Convert.ToChar(","))
        '2017/10/25 H.Mori mod 2017改善開発 No2-1 START
        'If Array.IndexOf(arrGroupName, AuthC.pGROUP_UNKOU) >= 0 Then '2017/07/20 H.Mori mod
        'If Array.IndexOf(arrGroupName, AuthC.pGROUP_UNKOU) >= 0 Or Array.IndexOf(arrGroupName, AuthC.pGROUP_EIGYOU) >= 0 Then
        '    '運行開発部、営業所
        '    cboKANSCD.SelectedIndex = 0
        'Else
        '    list = cboKANSCD.Items.FindByValue(AuthC.pCENTERCD)
        '    cboKANSCD.SelectedIndex = cboKANSCD.Items.IndexOf(list)
        'End If
        '監視センターは空白を初期選択する
        cboKANSCD.SelectedIndex = 0
        '2017/10/25 H.Mori mod 2017改善開発 No2-1 END
        '//-----------------------------------------------
        txtTEL.Text = ""
        'txtNCUTEL.Text = ""         '2014/12/02 H.Hosoda add 監視改善2014 No.6 '2016/11/16 H.Mori del 2016改善開発 No2-3
        txtNAME.Text = ""
        'txtKANA.Text = ""          '2016/11/16 H.Mori del 2016改善開発 No2-4
        txtADDR.Text = ""           '2013/12/09 T.Ono add 監視改善2013
        txtCLI_CD.Text = ""
        hdnCLI_CD.Value = ""
        txtCLI_CD_TO.Text = ""      '2019/11/01 T.Ono add 監視改善2019 No1
        hdnCLI_CD_TO.Value = ""     '2019/11/01 T.Ono add 監視改善2019 No1
        txtJA_CD.Text = ""          '2013/12/09 T.Ono add 監視改善2013
        hdnJA_CD.Value = ""         '2013/12/09 T.Ono add 監視改善2013
        hdnJA_CD_CLI.Value = ""     '2019/11/01 T.Ono add 監視改善2019
        txtHANGRP.Text = ""         '2014/12/03 H.Hosoda add 監視改善2014 No.6
        hdnHANGRP.Value = ""        '2014/12/03 H.Hosoda add 監視改善2014 No.6
        txtHAN_CD.Text = ""         '2013/12/09 T.Ono add 監視改善2013
        hdnHAN_CD.Value = ""
        hdnHAN_CD_CLI.Value = ""    '2019/11/01 T.Ono add 監視改善2019
        '2019/11/01 T.Ono del 監視改善2019 №1
        'txtKINRENGRP.Text = ""        '2016/11/17 H.Mori add 2016改善開発 No2-1
        'hdnKINRENGRP.Value = ""       '2016/11/17 H.Mori add 2016改善開発 No2-1
        txtHAN_CD_TO.Text = ""        '2016/11/24 H.Mori add 2016改善開発 No2-2
        hdnHAN_CD_TO.Value = ""       '2016/11/24 H.Mori add 2016改善開発 No2-2
        hdnHAN_CD_TO_CLI.Value = ""   '2019/11/01 T.Ono add 監視改善2019

        hdnKEY_CLI_CD.Value = ""
        hdnKEY_JA_CD.Value = ""     '2013/12/09 T.Ono add 監視改善2013
        hdnKEY_HAN_CD.Value = ""
        hdnKEY_USER_CD.Value = ""
        hdnTaiouClick.Value = ""

        hdnScrollTop.Value = "0"    '2014/01/08 T.Ono add 監視改善2013

    End Sub

    '******************************************************************************
    '*　概　要：絞込み条件を渡すプロパティ
    '*　備　考：抽出条件１の値を渡す
    '******************************************************************************
    Public ReadOnly Property pCode1() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" OrElse hdnPopcrtl.Value = "7" Then
                'If hdnPopcrtl.Value = "1" Then  2019/11/01 T.Ono mod 監視改善2019 No1
                If Request.Form("cboKANSCD").Length > 0 Then
                    '監視センターが指定されている場合
                    strRec = Request.Form("cboKANSCD")  '//クライアントコード一覧 指定された監視センターコード配下のクライアントコード
                Else
                    strRec = AuthC.pAUTHCENTERCD        '//クライアントコード一覧 ＡＤ認証の使用可能監視センターコード
                End If
            ElseIf hdnPopcrtl.Value = "2" Then
                '2013/12/09 T.Ono mod 監視改善2013
                'JAコード追加、JA支所コードのhdnPopcrtl.Value繰り下げ
                'strRec = hdnCLI_CD.Value                 '//ＪＡコード一覧 '2014/01/21 T.Ono mod 監視改善2013 Trimをつける
                strRec = hdnCLI_CD.Value.Trim           '//ＪＡコード一覧
            ElseIf hdnPopcrtl.Value = "3" Then
                '2014/12/04 H.Hosoda mod 監視改善2014 No.6
                '販売事業者グループコード追加、JA支所コードのhdnPopcrtl.Value繰り下げ
                strRec = hdnCLI_CD.Value.Trim           '//販売事業者グループコード一覧
                'ElseIf hdnPopcrtl.Value = "4" Then 
                'ElseIf hdnPopcrtl.Value = "4" Or hdnPopcrtl.Value = "6" Then '2016/11/24 H.Mori mod 監視改善2016 No2-2
            ElseIf hdnPopcrtl.Value = "4" Then          '2019/11/01 T.Ono mod 監視改善2019 No1
                'strRec = hdnCLI_CD.Value               '//ＪＡ支所コード一覧 '2014/01/21 T.Ono mod 監視改善2013 Trimをつける
                strRec = hdnCLI_CD.Value.Trim           '//ＪＡ支所コード一覧
                '2016/11/21 H.Mori mod 監視改善2016 No2-1
                '緊急連絡先Grグループコード追加
            ElseIf hdnPopcrtl.Value = "5" Then          '2016/11/21 H.Mori add 監視改善2016 No2-1
                strRec = hdnCLI_CD.Value.Trim           '緊急連絡先Grグループコード追加
            ElseIf hdnPopcrtl.Value = "6" Then '2019/11/01 T.Ono mod 監視改善2019 No1
                strRec = hdnCLI_CD_TO.Value.Trim           '//ＪＡ支所Toコード一覧
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：絞込み条件を渡すプロパティ　'2013/12/09 T.Ono add 監視改善2013
    '*　備　考：(ＪＡコード)                '201611/17 H.Mori 緊急連絡先Grで使用する場合もあり
    '******************************************************************************
    Public ReadOnly Property pCode2() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = ""
                Case "1", "7" '2019/11/01 T.Ono mod 監視改善2019 No1
                    'Case "1"
                    strRec = ""
                Case "2"
                    strRec = ""
                Case "3"                                '2014/12/04 H.Hosoda mod 監視改善2014 No.6
                    '2019/11/01 T.Ono mod 監視改善2019 No1
                    'strRec = ""                         '販売事業者グループコード追加、JA支所コードのhdnPopcrtl.Value繰り下げ
                    strRec = hdnCLI_CD_TO.Value.Trim
                    'Case "4"
                Case "4", "6"                           '2016/11/24 H.Mori mod 監視改善2016 No2-2
                    'strRec = hdnJA_CD.Value            '2014/01/21 T.Ono mod 監視改善2013 Trimをつける
                    strRec = hdnJA_CD.Value.Trim        '//ＪＡ支所コード一覧
                Case "5"                                '2016/11/17 H.Mori add 監視改善2016 No2-1
                    strRec = ""
                Case Else
                    strRec = ""
            End Select
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：絞込み条件を渡すプロパティ　'2014/12/04 H.Hosoda add 監視改善2014 No.6
    '*　備　考：(販売事業者グループコード)  
    '******************************************************************************
    Public ReadOnly Property pCode3() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = ""
                Case "1", "7" '2019/11/01 T.Ono mod 監視改善2019 No1
                    'Case "1" 
                    strRec = ""
                Case "2"
                    '2019/11/01 T.Ono mod 監視改善2019 No1
                    'strRec = ""
                    strRec = hdnCLI_CD_TO.Value.Trim
                Case "3"
                    strRec = ""
                    'Case "4"
                Case "4", "6"                            '2016/11/24 H.Mori mod 監視改善2016 No2-2
                    strRec = hdnHANGRP.Value.Trim        '//販売事業者グループコード一覧
                Case "5"                                 '2016/11/17 H.Mori add 監視改善2016 No2-1
                    strRec = ""
                Case Else
                    strRec = ""
            End Select
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：絞込み条件を渡すプロパティ(追加)　'201611/21 H.Mori add 監視改善2016 No2-1
    '*　備　考：JA支所の絞込み条件として引数が足りなかったため追加  
    '******************************************************************************
    Public ReadOnly Property pCode4() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = ""
                Case "1", "7" '2019/11/01 T.Ono mod 監視改善2019 No1
                    'Case "1"
                    strRec = ""
                Case "2"
                    strRec = ""
                Case "3"
                    strRec = ""
                Case "4", "6"
                    '2019/11/01 T.Ono mod 監視改善2019 No1
                    'strRec = hdnKINRENGRP.Value.Trim
                    strRec = ""
                Case "5"
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
            If hdnPopcrtl.Value = "1" OrElse hdnPopcrtl.Value = "7" Then
                'If hdnPopcrtl.Value = "1" Then '2019/11/01 T.Ono mod 監視改善2019 No1
                strRec = "クライアントコード一覧"
            ElseIf hdnPopcrtl.Value = "2" Then
                '2013/12/09 T.Ono mod 監視改善2013
                'JAコード追加、JA支所コードのhdnPopcrtl.Value繰り下げ
                strRec = "ＪＡコード一覧"
            ElseIf hdnPopcrtl.Value = "3" Then
                '2014/12/04 H.Hosoda mod 監視改善2014 No.6
                '販売事業者グループコード追加、JA支所コードのhdnPopcrtl.Value繰り下げ
                strRec = "販売事業者グループ一覧"
                '2016/11/24 H.Mori mod 監視改善2016 No2-2
                'ElseIf hdnPopcrtl.Value = "4"
            ElseIf hdnPopcrtl.Value = "4" Or hdnPopcrtl.Value = "6" Then
                strRec = "ＪＡ支所コード一覧"
                '2016/11/17 H.Mori add 監視改善2016 No2-1
                '緊急連絡先Grグループコード追加
            ElseIf hdnPopcrtl.Value = "5" Then
                strRec = "緊急連絡先Gr一覧"
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
            If hdnPopcrtl.Value = "1" OrElse hdnPopcrtl.Value = "7" Then
                'If hdnPopcrtl.Value = "1" Then '2019/11/01 T.Ono mod 監視改善2019 No1
                strRec = "CLI"
            ElseIf hdnPopcrtl.Value = "2" Then
                '2013/12/09 T.Ono mod 監視改善2013
                'JAコード追加、JA支所コードのhdnPopcrtl.Value繰り下げ(2→3)
                strRec = "JA"
            ElseIf hdnPopcrtl.Value = "3" Then
                '2013/12/09 T.Ono mod 監視改善2013
                '販売事業者グループコード追加、JA支所コードのhdnPopcrtl.Value繰り下げ(3→4)
                strRec = "HANG"
                '2016/11/24 H.Mori mod 監視改善2016 No2-2
                'ElseIf hdnPopcrtl.Value = "4"
            ElseIf hdnPopcrtl.Value = "4" Or hdnPopcrtl.Value = "6" Then
                'strRec = "JASS"
                'strRec = "JASS2"      '--- 2005/05/24 MOD Falcon ---
                strRec = "JASS"      '--- 2008/02/27 MOD T.Watabe ---
                '2016/11/17 H.Mori add 監視改善2016 No2-1
                '緊急連絡先Grグループコード追加
            ElseIf hdnPopcrtl.Value = "5" Then
                strRec = "JAHOKOKU2"
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
                strRec = "hdnCLI_CD"
            ElseIf hdnPopcrtl.Value = "2" Then
                '2013/12/09 T.Ono mod 監視改善2013
                'JAコード追加、JA支所コードのhdnPopcrtl.Value繰り下げ(2→3)
                strRec = "hdnJA_CD"
            ElseIf hdnPopcrtl.Value = "3" Then
                '2014/12/04 H.Hosoda mod 監視改善2014 No.6
                '販売事業者グループコード追加、JA支所コードのhdnPopcrtl.Value繰り下げ(3→4)
                strRec = "hdnHANGRP"
            ElseIf hdnPopcrtl.Value = "4" Then
                strRec = "hdnHAN_CD"

                '2019/11/01 T.Ono 監視改善2019 No1
                'ElseIf hdnPopcrtl.Value = "5" Then
                ''2016/11/17 H.Mori add 監視改善2016 No2-1
                ''緊急連絡先Grグループコード追加
                'strRec = "hdnKINRENGRP"
            ElseIf hdnPopcrtl.Value = "6" Then
                '2016/11/24 H.Mori add 監視改善2016 No2-2
                'JA支所名TO追加
                strRec = "hdnHAN_CD_TO"
            ElseIf hdnPopcrtl.Value = "7" Then
                '2019/11/01 T.Ono add 監視改善2019
                strRec = "hdnCLI_CD_TO"
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
                strRec = "txtCLI_CD"
            ElseIf hdnPopcrtl.Value = "2" Then
                '2013/12/09 T.Ono mod 監視改善2013
                'JAコード追加、JA支所コードのhdnPopcrtl.Value繰り下げ(2→3)
                strRec = "txtJA_CD"
            ElseIf hdnPopcrtl.Value = "3" Then
                '2014/12/04 H.Hosoda mod 監視改善2014 No.6
                '販売事業者グループコード追加、JA支所コードのhdnPopcrtl.Value繰り下げ(3→4)
                strRec = "txtHANGRP"
            ElseIf hdnPopcrtl.Value = "4" Then
                strRec = "txtHAN_CD"

                '2019/11/01 T.Ono del 監視改善2019 No1
                'ElseIf hdnPopcrtl.Value = "5" Then
                ''2016/11/17 H.Mori add 監視改善2016 No2-1
                ''緊急連絡先Grグループコード追加
                'strRec = "txtKINRENGRP"
            ElseIf hdnPopcrtl.Value = "6" Then
                '2016/11/24 H.Mori add 監視改善2016 No2-2
                'JA支所名TO追加
                strRec = "txtHAN_CD_TO"
            ElseIf hdnPopcrtl.Value = "7" Then
                '2019/11/01 T.Ono add 監視改善2019
                strRec = "txtCLI_CD_TO"
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*　概　要：コードを返すオブジェクトの名前値を渡すプロパティ 2019/11/01 T.Ono add 監視改善2019
    '*　備　考：データ選択後、コードを返すオブジェクト名を指定する
    '******************************************************************************
    Public ReadOnly Property pBackCode2() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = "hdnJA_CD_CLI"
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "4" Then
                strRec = "hdnHAN_CD_CLI"
            ElseIf hdnPopcrtl.Value = "6" Then
                strRec = "hdnHAN_CD_TO_CLI"
            ElseIf hdnPopcrtl.Value = "7" Then
                strRec = ""
            Else
                strRec = ""
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
            If hdnPopcrtl.Value = "1" Then
                strRec = "btnCLI_CD"
            ElseIf hdnPopcrtl.Value = "2" Then
                '2013/12/09 T.Ono mod 監視改善2013
                'JAコード追加、JA支所コードのhdnPopcrtl.Value繰り下げ(2→3)
                strRec = "btnJA_CD"
            ElseIf hdnPopcrtl.Value = "3" Then
                '2014/12/04 H.Hosoda mod 監視改善2014 No.6
                '販売事業者グループコード追加、JA支所コードのhdnPopcrtl.Value繰り下げ(3→4)
                strRec = "btnHANGRP"
            ElseIf hdnPopcrtl.Value = "4" Then
                strRec = "btnHAN_CD"

                '2019/11/01 T.Ono del 監視改善2019 No1
                'ElseIf hdnPopcrtl.Value = "5" Then
                '2016/11/17 H.Mori add 監視改善2016 No2-1
                '緊急連絡先Grグループコード追加
                '    strRec = "btnKINRENGRP"
            ElseIf hdnPopcrtl.Value = "6" Then
                '2016/11/24 H.Mori add 監視改善2016 No2-2
                'JA支所名TO追加
                strRec = "btnHAN_CD_TO"
            ElseIf hdnPopcrtl.Value = "7" Then
                '2019/11/01 T.Ono add 監視改善2019 No1
                'クライアントコードTo追加
                strRec = "btnCLI_CD_TO"
            Else
                strRec = ""
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
            If hdnPopcrtl.Value = "1" Then
                strRec = "fncSetTo"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "4" Then
                strRec = "fncSetTo"
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
    Public ReadOnly Property pClear1() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "txtHAN_CD"
            ElseIf hdnPopcrtl.Value = "2" Then
                'strRec = "" 2013/12/09 T.Ono mod 監視改善2013
                strRec = "txtHAN_CD"
            ElseIf hdnPopcrtl.Value = "3" Then  '2014/12/04 H.Hosoda add 監視改善2014 No.6
                strRec = "txtHAN_CD"

                '2019/11/01 T.Ono del 監視改善2019 No1
                'ElseIf hdnPopcrtl.Value = "5" Then  '2016/11/17 H.Mori add 監視改善2016 No2-1
                'strRec = "txtHAN_CD"
            ElseIf hdnPopcrtl.Value = "7" Then  '2019/11/01 T.Ono add 監視改善2019 No1
                strRec = "txtHAN_CD"
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：JA支所コードのクリア（hdn）
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pClear2() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "hdnHAN_CD"
            ElseIf hdnPopcrtl.Value = "2" Then
                'strRec = ""  T.Ono mod 監視改善2013
                strRec = "hdnHAN_CD"
            ElseIf hdnPopcrtl.Value = "3" Then  '2014/12/04 H.Hosoda add 監視改善2014 No.6
                strRec = "hdnHAN_CD"

                '2019/11/01 T.Ono 監視改善No1
                'ElseIf hdnPopcrtl.Value = "5" Then  '2016/11/17 H.Mori add 監視改善2016 No2-1
                'strRec = "hdnHAN_CD"
            ElseIf hdnPopcrtl.Value = "7" Then  '2019/11/01 T.Ono add 監視改善2019 No1
                strRec = "hdnHAN_CD"
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：JAコードのクリア（txt） 2013/12/09 T.Ono add 監視改善2013
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pClear3() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "txtJA_CD"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "7" Then  '2019/11/01 T.Ono add 監視改善2019 No1
                strRec = "txtJA_CD"
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：JAコードのクリア（hdn） 2013/12/09 T.Ono add 監視改善2013
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pClear4() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "hdnJA_CD"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "7" Then  '2019/11/01 T.Ono add 監視改善2019 No1
                strRec = "hdnJA_CD"
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：販売事業者グループコードのクリア（txt） 2014/12/04 H.Hosoda add 監視改善2014 No.6
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pClear5() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "txtHANGRP"
            ElseIf hdnPopcrtl.Value = "7" Then  '2019/11/01 T.Ono add 監視改善2019 No1
                strRec = "txtHANGRP"
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：販売事業者グループコードのクリア（hdn） 2014/12/04 H.Hosoda add 監視改善2014 No.6
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pClear6() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "hdnHANGRP"
            ElseIf hdnPopcrtl.Value = "7" Then  '2019/11/01 T.Ono add 監視改善2019 No1
                strRec = "hdnHANGRP"
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：クライアントコードToのクリア（txt） 
    '*　備　考：2019/11/01 T.Ono 監視改善2019 No1
    '*　　　　　緊急連絡Grのクリアからクライアントコードのクリアに変更
    '******************************************************************************
    Public ReadOnly Property pClear7() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                'strRec = "txtKINRENGRP"
                strRec = "txtCLI_CD_TO"
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：クライアントコードToのクリア（hdn）
    '*　備　考：2019/11/01 T.Ono 監視改善2019 No1
    '*　　　　　緊急連絡Grのクリアからクライアントコードのクリアに変更
    '******************************************************************************
    Public ReadOnly Property pClear8() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                'strRec = "hdnKINRENGRP"
                strRec = "hdnCLI_CD_TO"
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：JA支所TOのクリア（txt） 2016/11/24 H.Mori add 監視改善2016 No2-2
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pClear9() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "txtHAN_CD_TO"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = "txtHAN_CD_TO"
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = "txtHAN_CD_TO"
            ElseIf hdnPopcrtl.Value = "5" Then
                strRec = "txtHAN_CD_TO"
            ElseIf hdnPopcrtl.Value = "7" Then  '2019/11/01 T.Ono add 監視改善2019 No1
                strRec = "txtHAN_CD_TO"
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：JA支所TOのクリア（hdn） 2016/11/24 H.Mori add 監視改善2016 No2-2
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pClear10() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "hdnHAN_CD_TO"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = "hdnHAN_CD_TO"
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = "hdnHAN_CD_TO"
            ElseIf hdnPopcrtl.Value = "5" Then
                strRec = "hdnHAN_CD_TO"
            ElseIf hdnPopcrtl.Value = "7" Then  '2019/11/01 T.Ono add 監視改善2019 No1
                strRec = "hdnHAN_CD_TO"
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
    Public ReadOnly Property pClear11() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "hdnJA_CD_CLI"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = "hdnJA_CD_CLI"
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "4" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "5" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "6" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "7" Then
                strRec = "hdnJA_CD_CLI"
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
    Public ReadOnly Property pClear12() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "hdnHAN_CD_CLI"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = "hdnHAN_CD_CLI"
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = "hdnHAN_CD_CLI"
            ElseIf hdnPopcrtl.Value = "4" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "5" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "6" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "7" Then
                strRec = "hdnHAN_CD_CLI"
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
    Public ReadOnly Property pClear13() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "hdnHAN_CD_TO_CLI"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = "hdnHAN_CD_TO_CLI"
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = "hdnHAN_CD_TO_CLI"
            ElseIf hdnPopcrtl.Value = "4" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "5" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "6" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "7" Then
                strRec = "hdnHAN_CD_TO_CLI"
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property
    '<TODO>検索条件としてIFRAME画面に引き渡したい値ReadOnlyプロパティで設定する
    '******************************************************************************
    '*　概　要：監視センターコードの値を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pKANSCD() As String
        Get
            Return Request.Form("cboKANSCD")
        End Get
    End Property

    '******************************************************************************
    '*　概　要：需要家電話番号の値を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pTEL() As String
        Get
            Return txtTEL.Text
        End Get
    End Property

    '******************************************************************************
    '*　概　要：結線番号の値を渡すプロパティ '2014/12/02 H.Hosoda add 監視改善2014 No.6
    '*　備　考：2016/11/16 H.Mori del 2016改善開発 No2-3 
    '******************************************************************************
    'Public ReadOnly Property pNCUTEL() As String
    '    Get
    '        Return txtNCUTEL.Text
    '    End Get
    'End Property

    '******************************************************************************
    '*　概　要：需要家名の値を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pNAME() As String
        Get
            '2014/04/09 T.Ono mod
            'Return txtNAME.Text
            Return txtNAME.Text.Trim
        End Get
    End Property

    '******************************************************************************
    '*　概　要：需要家名カナの値を渡すプロパティ
    '*　備　考：'2016/11/16 H.Mori del 2016改善開発 No2-4
    '******************************************************************************
    'Public ReadOnly Property pKANA() As String
    '    Get
    '        '2014/04/09 T.Ono mod
    '        'Return txtKANA.Text
    '        Return txtKANA.Text.Trim

    '    End Get
    'End Property

    '******************************************************************************
    '*　概　要：需要家住所の値を渡すプロパティ　2013/12/05 T.Ono add 監視改善2013
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pADDR() As String
        Get
            '2014/04/09 T.Ono mod
            'Return txtADDR.Text
            Return txtADDR.Text.Trim
        End Get
    End Property

    '******************************************************************************
    '*　概　要：クライアントコードの値を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pCLI_CD() As String
        Get
            Return hdnCLI_CD.Value.Trim     '2012/04/04 NEC ou Add Upd
        End Get
    End Property

    '******************************************************************************
    '*　概　要：クライアント名の値を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pCLI_CD_NAME() As String
        Get
            Return txtCLI_CD.Text
        End Get
    End Property

    '******************************************************************************
    '*　概　要：クライアントToコードの値を渡すプロパティ 2019/11/01 T.Ono add 監視改善2019 No1
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pCLI_CD_TO() As String
        Get
            Return hdnCLI_CD_TO.Value.Trim
        End Get
    End Property

    '******************************************************************************
    '*　概　要：クライアントTo名の値を渡すプロパティ  2019/11/01 T.Ono add 監視改善2019 No1
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pCLI_CD_TO_NAME() As String
        Get
            Return txtCLI_CD_TO.Text
        End Get
    End Property
    '******************************************************************************
    '*　概　要：ＪＡコードの値を渡すプロパティ　'2013/12/09 T.ono add 監視改善2013
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pJA_CD() As String
        Get
            Return hdnJA_CD.Value.Trim
        End Get
    End Property

    '******************************************************************************
    '*　概　要：ＪＡコードの値を渡すプロパティ　'2013/12/09 T.ono add 監視改善2013
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pJA_CD_NAME() As String
        Get
            Return txtJA_CD.Text
        End Get
    End Property
    '******************************************************************************
    '*　概　要：ＪＡコードに紐づくクライアントコードの値を渡すプロパティ '2019/11/01 T.Ono add 監視改善2019
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pJA_CD_CLI() As String
        Get
            Return hdnJA_CD_CLI.Value.Trim
        End Get
    End Property
    '******************************************************************************
    '*　概　要：販売事業者グループコードの値を渡すプロパティ　'2014/12/03 H.hosoda add 監視改善2014 No.6
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pHAN_GRP() As String
        Get
            Return hdnHANGRP.Value.Trim
        End Get
    End Property

    '******************************************************************************
    '*　概　要：販売事業者グループコードの値を渡すプロパティ　'2014/12/03 T.hosoda add 監視改善2014 No.6
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pHAN_GRP_NAME() As String
        Get
            Return txtHANGRP.Text
        End Get
    End Property

    '******************************************************************************
    '*　概　要：緊急連絡先Grの値を渡すプロパティ　'2016/11/22 H.Mori add 監視改善2016 No2-1
    '*　備　考：2019/11/01 T.Ono del 監視改善2019 №1
    '******************************************************************************
    'Public ReadOnly Property pKINREN_GRP() As String
    '    Get
    '        Return hdnKINRENGRP.Value.Trim
    '    End Get
    'End Property

    '******************************************************************************
    '*　概　要：緊急連絡先Grの値を渡すプロパティ　'2016/11/22 H.Mori add 監視改善2016 No2-1
    '*　備　考：2019/11/01 T.Ono del 監視改善2019 №1
    '******************************************************************************
    'Public ReadOnly Property pKINREN_GRP_NAME() As String
    '    Get
    '        Return txtKINRENGRP.Text
    '    End Get
    'End Property

    '******************************************************************************
    '*　概　要：ＪＡ支所コードの値を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pHAN_CD() As String
        Get
            Return hdnHAN_CD.Value.Trim     '2012/04/04 NEC ou Add Upd
        End Get
    End Property

    '******************************************************************************
    '*　概　要：ＪＡ支所コードの値を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pHAN_CD_NAME() As String
        Get
            Return txtHAN_CD.Text
        End Get
    End Property
    '******************************************************************************
    '*　概　要：ＪＡ支所コードに紐づくクライアントコードの値を渡すプロパティ　'2019/11/01 T.Ono add 監視改善2019
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pHAN_CD_CLI() As String
        Get
            Return hdnHAN_CD_CLI.Value.Trim
        End Get
    End Property
    '******************************************************************************
    '*　概　要：ＪＡ支所コードTOの値を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pHAN_CD_TO() As String
        Get
            Return hdnHAN_CD_TO.Value.Trim
        End Get
    End Property

    '******************************************************************************
    '*　概　要：ＪＡ支所コードTOの値を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pHAN_CD_NAME_TO() As String
        Get
            Return txtHAN_CD_TO.Text
        End Get
    End Property
    '******************************************************************************
    '*　概　要：ＪＡ支所コードTOに紐づくクライアントコードの値を渡すプロパティ　'2019/11/01 T.Ono add 監視改善2019
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pHAN_CD_TO_CLI() As String
        Get
            Return hdnHAN_CD_TO_CLI.Value.Trim
        End Get
    End Property
    '******************************************************************************
    '*　概　要：お客様コードの値を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pUSER_CD() As String
        Get
            Return txtUSER_CD.Text
        End Get
    End Property

    '******************************************************************************
    '*　概　要：お客様FLG（未開通）の値を渡すプロパティ　2013/12/05 T.Ono add 監視改善2013
    '*　備　考：0：チェックなし　1：チェックあり
    '******************************************************************************
    Public ReadOnly Property pUSER_FLG0() As String
        Get
            If chkUSER_FLG0.Checked = False Then
                Return "0"
            Else
                Return "1"
            End If
        End Get
    End Property

    '******************************************************************************
    '*　概　要：お客様FLG（運用中）の値を渡すプロパティ　2013/12/05 T.Ono add 監視改善2013
    '*　備　考：0：チェックなし　1：チェックあり
    '******************************************************************************
    Public ReadOnly Property pUSER_FLG1() As String
        Get
            If chkUSER_FLG1.Checked = False Then
                Return "0"
            Else
                Return "1"
            End If
        End Get
    End Property

    '******************************************************************************
    '*　概　要：お客様FLG（休止中）の値を渡すプロパティ　2013/12/05 T.Ono add 監視改善2013
    '*　備　考：0：チェックなし　1：チェックあり
    '******************************************************************************
    Public ReadOnly Property pUSER_FLG2() As String
        Get
            If chkUSER_FLG2.Checked = False Then
                Return "0"
            Else
                Return "1"
            End If
        End Get
    End Property

    '******************************************************************************
    '*　概　要：販売区分（メータ売）の値を渡すプロパティ　2015/12/11 H.Mori add 監視改善2015
    '*　備　考：0：チェックなし　1：チェックあり
    '******************************************************************************
    Public ReadOnly Property pHANBAI_KBN1() As String
        Get
            If chkHANBAI_KBN1.Checked = False Then
                Return "0"
            Else
                Return "1"
            End If
        End Get
    End Property

    '******************************************************************************
    '*　概　要：販売区分（ボンベ売）の値を渡すプロパティ　2015/12/11 H.Mori add 監視改善2015
    '*　備　考：0：チェックなし　1：チェックあり
    '******************************************************************************
    Public ReadOnly Property pHANBAI_KBN2() As String
        Get
            If chkHANBAI_KBN2.Checked = False Then
                Return "0"
            Else
                Return "1"
            End If
        End Get
    End Property

    '******************************************************************************
    '*　概　要：販売区分（両方）の値を渡すプロパティ　2015/12/11 H.Mori add 監視改善2015
    '*　備　考：0：チェックなし　1：チェックあり
    '******************************************************************************
    Public ReadOnly Property pHANBAI_KBN3() As String
        Get
            If chkHANBAI_KBN3.Checked = False Then
                Return "0"
            Else
                Return "1"
            End If
        End Get
    End Property

    '******************************************************************************
    '*　概　要：販売区分（その他）の値を渡すプロパティ　2015/12/11 H.Mori add 監視改善2015
    '*　備　考：0：チェックなし　1：チェックあり
    '******************************************************************************
    Public ReadOnly Property pHANBAI_KBN4() As String
        Get
            If chkHANBAI_KBN4.Checked = False Then
                Return "0"
            Else
                Return "1"
            End If
        End Get
    End Property

    '******************************************************************************
    '*　概　要：販売区分（データなし）の値を渡すプロパティ　2015/12/11 H.Mori add 監視改善2015
    '*　備　考：0：チェックなし　1：チェックあり
    '******************************************************************************
    Public ReadOnly Property pHANBAI_KBN5() As String
        Get
            If chkHANBAI_KBN5.Checked = False Then
                Return "0"
            Else
                Return "1"
            End If
        End Get
    End Property

    '******************************************************************************
    '*　概　要：販売区分（例外）の値を渡すプロパティ　2015/12/11 H.Mori add 監視改善2015
    '*　備　考：0：チェックなし　1：チェックあり
    '******************************************************************************
    Public ReadOnly Property pHANBAI_KBN6() As String
        Get
            If chkHANBAI_KBN6.Checked = False Then
                Return "0"
            Else
                Return "1"
            End If
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
    '*　概　要：一覧で選択したクライアントコードの値を渡すプロパティ
    '*　備　考：対応入力画面より戻ってきた時に使用
    '******************************************************************************
    Public ReadOnly Property pKEY_CLI_CD() As String
        Get
            Return hdnKEY_CLI_CD.Value
        End Get
    End Property

    '******************************************************************************
    '*　概　要：一覧で選択したJAコードの値を渡すプロパティ　2013/12/09 T.Ono add 監視改善2013
    '*　備　考：対応入力画面より戻ってきた時に使用
    '******************************************************************************
    Public ReadOnly Property pKEY_JA_CD() As String
        Get
            Return hdnKEY_JA_CD.Value
        End Get
    End Property

    '******************************************************************************
    '*　概　要：一覧で選択した販売事業者グループコードの値を渡すプロパティ　2014/12/03 H.Hosoda add 監視改善2014 No.6
    '*　備　考：対応入力画面より戻ってきた時に使用
    '******************************************************************************
    Public ReadOnly Property pKEY_HAN_GRP() As String
        Get
            Return hdnKEY_HAN_GRP.Value
        End Get
    End Property

    '******************************************************************************
    '*　2019/11/01 T.Ono del 監視改善2019 No1
    '*　概　要：一覧で選択した緊急連絡先Grグループコードの値を渡すプロパティ　2016/11/22 H.Mori add 監視改善2016 No2-1
    '*　備　考：対応入力画面より戻ってきた時に使用 
    '******************************************************************************
    'Public ReadOnly Property pKEY_KINREN_GRP() As String
    '    Get
    '        Return hdnKEY_KINREN_GRP.Value
    '    End Get
    'End Property

    '******************************************************************************
    '*　概　要：一覧で選択した販売店コードの値を渡すプロパティ
    '*　備　考：対応入力画面より戻ってきた時に使用
    '******************************************************************************
    Public ReadOnly Property pKEY_HAN_CD() As String
        Get
            Return hdnKEY_HAN_CD.Value
        End Get
    End Property

    '******************************************************************************
    '*　概　要：一覧で選択したお客様コードの値を渡すプロパティ
    '*　備　考：対応入力画面より戻ってきた時に使用
    '******************************************************************************
    Public ReadOnly Property pKEY_USER_CD() As String
        Get
            Return hdnKEY_USER_CD.Value
        End Get
    End Property

    '******************************************************************************
    '*　概　要：未登録フラグ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pMITOKBN() As String
        Get
            Return hdnMOVE_MITOKBN.Value
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
    Private Sub fncCombo_Creatr_KANSICD()
        '//監視センターコンボ
        Dim strGROUPNAME As String = AuthC.pGROUPNAME
        Dim arrGroupName() As String = strGROUPNAME.Split(Convert.ToChar(","))
        '2017/10/25 H.Mori mod 2017改善開発 No2-1 START
        'If Array.IndexOf(arrGroupName, AuthC.pGROUP_UNKOU) >= 0 Then '2017/07/20 H.Mori mod
        'If Array.IndexOf(arrGroupName, AuthC.pGROUP_UNKOU) >= 0 Or strGROUPNAME.IndexOf(AuthC.pGROUP_EIGYOU) >= 0 Then
        '    '開発部、営業所の場合は未選択ＯＫ　各監視センターの場合は監視センターを選択する
        '    cboKANSCD.pComboTitle = True
        'Else
        '    cboKANSCD.pComboTitle = False
        'End If
        cboKANSCD.pComboTitle = True
        '2017/10/25 H.Mori mod 2017改善開発 No2-1 END
        cboKANSCD.pNoData = False
        cboKANSCD.pType = "KANSICENTER"
        cboKANSCD.pAllCenterCd = AuthC.pAUTHCENTERCD
        cboKANSCD.mMakeCombo()
    End Sub
    ' 2017/02/06 W.Ganeko 2016監視改善 start
    '******************************************************************************
    ' Excel出力(チェックつき)
    '******************************************************************************
    Private Sub btnExcel_ServerClick(ByVal sender As System.Object, _
                                    ByVal e As System.EventArgs) Handles btnExcel.ServerClick
        Dim strRec As String
        Dim MSKOSJAG00C As New MSKOSJAG00MSKOSJAW00.MSKOSJAW00
        Dim list As New ListItem

        Dim strRecMsg As String = ""
        Call fncCombo_Creatr_KANSICD()     '監視センターコンボ
        list = cboKANSCD.Items.FindByValue(pKANSCD)
        cboKANSCD.SelectedIndex = cboKANSCD.Items.IndexOf(list)

        Dim strKANSCD As String = ""

        If pKANSCD.Trim.Length > 0 Then
            strKANSCD = "'" & pKANSCD & "'"
        Else
            '監視センターの指定がない場合は、認証クラスからセンターコードを取得
            Dim arrTemp() As String
            arrTemp = AuthC.pAUTHCENTERCD.Split(Convert.ToChar(","))
            For i As Integer = 0 To arrTemp.Length - 1
                If strKANSCD.Length > 0 Then
                    strKANSCD = strKANSCD & ","
                End If
                strKANSCD = strKANSCD & "'" & arrTemp(i) & "'"
            Next
        End If


        '2019/11/01 T.Ono mod 監視改善2019 No1
        'strRec = MSKOSJAG00C.mExcel(
        '                 Me.Session.SessionID,
        '                 pKANSCD,
        '                 pTEL,
        '                 pNAME,
        '                 pADDR,
        '                 pCLI_CD,
        '                 pJA_CD,
        '                 pHAN_GRP,
        '                 pKINREN_GRP,
        '                 pHAN_CD,
        '                 pHAN_CD_TO,
        '                 pUSER_CD,
        '                 pUSER_FLG0,
        '                 pUSER_FLG1,
        '                 pUSER_FLG2,
        '                 pHANBAI_KBN1,
        '                 pHANBAI_KBN2,
        '                 pHANBAI_KBN3,
        '                 pHANBAI_KBN4,
        '                 pHANBAI_KBN5,
        '                 pHANBAI_KBN6
        '                 )
        strRec = MSKOSJAG00C.mExcel(
                         Me.Session.SessionID,
                         strKANSCD,
                         pTEL,
                         pNAME,
                         pADDR,
                         pCLI_CD,
                         pCLI_CD_TO,
                         pJA_CD,
                         pJA_CD_CLI,
                         pHAN_GRP,
                         pHAN_CD,
                         pHAN_CD_CLI,
                         pHAN_CD_TO,
                         pHAN_CD_TO_CLI,
                         pUSER_CD,
                         pUSER_FLG0,
                         pUSER_FLG1,
                         pUSER_FLG2,
                         pHANBAI_KBN1,
                         pHANBAI_KBN2,
                         pHANBAI_KBN3,
                         pHANBAI_KBN4,
                         pHANBAI_KBN5,
                         pHANBAI_KBN6
                         )

        If strRec.Substring(0, 5) = "ERROR" Then
            'エラーであればブラウザにメッセージ表示
            Dim ErrMsgC As New CErrMsg
            strRecMsg = "システムエラー：" & ErrMsgC.mGetArtMsg(strRec)
            strMsg.Append("alert('" & strRecMsg & "');")
            strMsg.Append("Form1.btnExcel.focus();")

        ElseIf strRec.Substring(0, 5) = "DATA0" Then
            'データが0件の場合
            strRecMsg = "対象データが存在しません"
            strMsg.Append("alert('" & strRecMsg & "');")
            strMsg.Append("Form1.btnExcel.focus();")

        ElseIf strRec.Substring(0, 5) = "OVER0" Then
            'データが65536件の場合
            'HttpHeaderC.mDownLoadXLS(Response, "お客様検索結果リスト.xls")
            'Dim sb As New System.Text.StringBuilder(strRec)
            'sb.Replace("OVER0", "")
            ' ''ファイル送信
            'Response.WriteFile(sb.ToString())
            strRecMsg = "データが最大行数を超えました。[最大65536行]"
            strMsg.Append("alert('" & strRecMsg & "');")
            strMsg.Append("Form1.btnExcel.focus();")
        Else
            strMsg.Append("Form1.btnExcel.focus();")
            HttpHeaderC.mDownLoadXLS(Response, "お客様検索リスト.xls")

            ''ファイル送信
            Response.WriteFile(strRec)

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
    ' 2017/02/06 W.Ganeko 2016監視改善 end
End Class
