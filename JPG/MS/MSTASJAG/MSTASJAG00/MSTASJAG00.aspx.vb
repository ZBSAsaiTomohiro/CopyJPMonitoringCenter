'***********************************************
'担当者マスタ  メイン画面
'***********************************************
Option Explicit On
Option Strict On

Imports Common
Imports Common.DB
Imports JPG.Common
Imports JPG.Common.log

Imports System.Text

Partial Class MSTASJAG00
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
            txtKURACD.Attributes.Add("ReadOnly", "true")
            txtCODE.Attributes.Add("ReadOnly", "true")
            txtGROUPCD.Attributes.Add("ReadOnly", "true") '2016/02/12 H.Mori add 2015改善開発 №9
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
        '--- ↓2005/04/28 DEL　Falcon↓ -----------------
        '[プルダウンマスタ]使用可能権限(運:○/営:○/監:×/出:×)
        'AuthC.fncAuthCheck(Server, AuthC.pGROUP_UNKOU & "," & AuthC.pGROUP_EIGYOU)

        '--- ↑2005/04/28 DEL Falcon↑ -----------------
        '--- ↓2005/04/28 MOD　Falcon↓ -----------------
        '[担当者マスタ]使用可能権限(運:○/営:○/監:○/出:×)
        AuthC.fncAuthCheck(Server, AuthC.pGROUP_UNKOU & "," & AuthC.pGROUP_EIGYOU & "," & AuthC.pGROUP_KANSHI)

        '--- ↑2005/04/28 MOD Falcon↑ -----------------
        '//------------------------------------------
        '<TODO>ポップアップ/登録系フレームの出力
        '      [hdnKensaku(Hidden)]を作成する事
        If hdnKensaku.Value = "COPOPUPG00" Then
            Server.Transfer("../../../Popup/COPOPUPG00.aspx")
        End If

        ' 2008/07/31 ADD T.Watabe
        '//------------------------------------------
        '// 担当者一覧
        If hdnKensaku.Value = "MSTAFJAG00" Then
            Server.Transfer("../../../MS/MSTAFJAG/MSTAFJAG00/MSTAFJAG00.aspx")
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
             MyBase.MapPath("../../../MS/MSTASJAG/MSTASJAG00/") & "MSTASJAG00.js"))
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
            strMsg.Append("Form1.rdoKBN1.focus();")

            '//-----------------------------------------------------
            '// 営業所グループのみに所属している場合、[営業所メニュー]より遷移してきている為
            '// 終了ボタン押下時は[営業所メニュー]に戻る
            '//-----------------------------------------------------

            hdnBackUrl.Value = ""

            Dim strGROUPNAME As String = AuthC.pGROUPNAME
            Dim arrGroupName() As String = strGROUPNAME.Split(Convert.ToChar(","))
            '--- ↓2005/04/19 MOD　Falcon↓ -----------------
            Dim arrKanshiGroup() As String = AuthC.pGROUP_KANSHI.Split(Convert.ToChar(","))
            Dim i As Integer
            Dim bolGroupFLG As Boolean = False

            '運行開発部・営業所の所属チェック
            If Array.IndexOf(arrGroupName, AuthC.pGROUP_UNKOU) >= 0 Or _
                Array.IndexOf(arrGroupName, AuthC.pGROUP_EIGYOU) >= 0 Then
                bolGroupFLG = True
            End If
            '--- ↑2005/04/19 MOD Falcon↑ ------------------
            '--- ↓2005/04/28 MOD　Falcon↓ -----------------
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
            '--- ↑2005/04/28 MOD Falcon↑ ------------------
            '--- ↓2005/04/19 MOD　Falcon↓ -----------------
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
            '--- ↑2005/04/19 MOD Falcon↑ ------------------

            '--- ↓2005/04/19 DEL　Falcon↓ -----------------
            'If _
            '    Array.IndexOf(arrGroupName, AuthC.pGROUP_UNKOU) >= 0 Or _
            '    Array.IndexOf(arrGroupName, AuthC.pGROUP_TOUHOKU) >= 0 Or _
            '    Array.IndexOf(arrGroupName, AuthC.pGROUP_NAKANIHON) >= 0 Or _
            '    Array.IndexOf(arrGroupName, AuthC.pGROUP_NISHINIHON) >= 0 Or _
            '    Array.IndexOf(arrGroupName, AuthC.pGROUP_EIGYOU) >= 0 Then
            '    'いずれかのグループに所属している場合はそのメニューにて業務を行うため
            '    '通常[マスタメニュー]に戻る
            'Else
            '    Dim j As Integer
            '    Dim intEIGYOU_LEN As Integer
            '    Dim intGROUP_LEN As Integer
            '    intEIGYOU_LEN = AuthC.pGROUP_EIGYOU.Length
            '    For j = 0 To arrGroupName.Length - 1
            '        intGROUP_LEN = arrGroupName(j).Length
            '        If intGROUP_LEN > 0 Then
            '            If Convert.ToString(arrGroupName(j)).Substring(intGROUP_LEN - intEIGYOU_LEN, intEIGYOU_LEN) = AuthC.pGROUP_EIGYOU Then
            '                '//営業所グループ
            '                hdnBackUrl.Value = "EIGYOU"
            '            End If
            '        End If
            '    Next
            'End If
            '--- ↑2005/04/19 DEL Falcon↑ ------------------
        Else
            '//--------------------------------------
            '//　２回目以降実行される
            '//--------------------------------------

            If hdnTANKBN.Value = "1" Then           '//ＪＡ担当者を選択する
                rdoKBN1.Checked = True
                rdoKBN2.Checked = False
                rdoKBN3.Checked = False
            ElseIf hdnTANKBN.Value = "2" Then       '//監視センターを選択する
                rdoKBN1.Checked = False
                rdoKBN2.Checked = True
                rdoKBN3.Checked = False
                btnKURACD.Disabled = True
                txtCODE.ReadOnly = True
                txtCODE.CssClass = "c-RO"
                txtCODE.BackColor = System.Drawing.Color.Gainsboro
                txtCODE.TabIndex = -1
            ElseIf hdnTANKBN.Value = "3" Then       '//出動会社を選択する
                rdoKBN1.Checked = False
                rdoKBN2.Checked = False
                rdoKBN3.Checked = True
                btnKURACD.Disabled = True
                txtCODE.ReadOnly = True
                txtCODE.CssClass = "c-RO"
                txtCODE.BackColor = System.Drawing.Color.Gainsboro
                txtCODE.TabIndex = -1
            End If
        End If

        '//担当区分のラジオボタンで制御するため
        strMsg.Append("window_open();")

        '//-------------------------------------------------
        '<TODO>自分の画面IDをHIDDENのhdnMyAspxに書き込む（システム共通）
        hdnMyAspx.Value = "MSTASJAG00"
        '//-------------------------------------------------
    End Sub

    '******************************************************************************
    '* 検索処理がされる前の画面状態（ReadOnlyやDisabled）
    '******************************************************************************
    Private Sub fncIni_statebf()
        '//--------------------------------------------------------------------------
        '<TODO>検索前の状態にコントロールの状態を設定する
        '
        rdoKBN1.Disabled = False
        rdoKBN2.Disabled = False

        If hdnTANKBN.Value = "1" Then           '//ＪＡ担当者を選択する
            '--- ↓2005/04/28 ADD Falcon↓ ---
            btnKURACD.Disabled = False
            '--- ↑2005/04/28 ADD Falcon↑ ---
        ElseIf hdnTANKBN.Value = "2" Then       '//監視センターを選択する
            btnKURACD.Disabled = True
        ElseIf hdnTANKBN.Value = "3" Then       '//出動会社を選択する
            btnKURACD.Disabled = True
        End If

    End Sub

    '******************************************************************************
    '* 検索処理がされた後の画面状態（ReadOnlyやDisabled）
    '******************************************************************************
    Private Sub fncIni_stateaf()
        '//--------------------------------------------------------------------------
        '<TODO>検索後の状態にコントロールの状態を設定する
        '
        rdoKBN1.Disabled = True
        rdoKBN2.Disabled = True
        rdoKBN3.Disabled = True

        btnKURACD.Disabled = True
        btnCODECD.Disabled = True

    End Sub

    '******************************************************************************
    '* 各コントロールの設定値の初期化
    '******************************************************************************
    Private Sub fncIni_format()
        '//--------------------------------------------------------------------------
        '<TODO>コントロールの値を初期化する
        '
        rdoKBN1.Checked = True
        rdoKBN2.Checked = False
        rdoKBN3.Checked = False

        txtKURACD.Text = ""
        txtCODE.Text = ""
        txtJACD.Text = ""
        txtTantoTel.Text = "" '2015/11/02 w.ganeko 2015改善開発 №9
        hdnTANKBN.Value = "1"
    End Sub

    '******************************************************************************
    '* キー以外の値を初期化する
    '******************************************************************************
    Private Sub fncIni_notkey()
        'Call fncIni_date()
        '//--------------------------------------------------------------------------
        '<TODO>コントロールの値を初期化する
        '
    End Sub

    ''******************************************************************************
    ''* 日付(作成日更新日)を初期化する
    ''******************************************************************************
    'Private Sub fncIni_date()
    '    hdnTIME.Value = ""
    'End Sub

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
                If hdnTANKBN.Value = "1" Then
                    strRec = hdnKURACD.Value        '//ＪＡ支所コード一覧
                ElseIf hdnTANKBN.Value = "2" Then
                    strRec = AuthC.pAUTHCENTERCD    '//監視センターコード一覧 ＡＤ認証の使用可能監視センターコード
                ElseIf hdnTANKBN.Value = "3" Then
                    '--- ↓2005/04/29 DEL Falcon↓ ---
                    'strRec = ""                     '//出動会社コード一覧
                    '--- ↑2005/04/29 DEL Falcon↑ ---
                    '--- ↓2005/04/29 ADD Falcon↓ ---
                    If hdnBackUrl.Value = "EIGYOU" Then
                        '//営業所グループの場合は監視センターが紐付けられない為、全クライアントを出力
                        strRec = ""
                    Else
                        strRec = AuthC.pAUTHCENTERCD    '//出動会社コード一覧 ＡＤ認証の使用可能監視センターコード
                    End If
                    '--- ↑2005/04/29 ADD Falcon↑ ---
                End If
            ElseIf hdnPopcrtl.Value = "3" Then      '//グループコード一覧
                strRec = AuthC.pAUTHCENTERCD        '2016/02/15 H.Mori add 2015改善開発 №9
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：絞込み条件を渡すプロパティ
    '*　備　考：抽出条件２の値を渡す                   '2016/02/15 H.Mori add 2015改善開発 №9
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
    '*　備　考：抽出条件３の値を渡す                   '2016/02/15 H.Mori add 2015改善開発 №9
    '******************************************************************************
    Public ReadOnly Property pCode3() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "2" Then      '//JA支所コード一覧
                strRec = ""
            ElseIf hdnPopcrtl.Value = "3" Then      '//グループコード一覧
                strRec = hdnCODE.Value.Trim
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
                If hdnTANKBN.Value = "1" Then
                    strRec = "ＪＡ支所コード一覧"
                ElseIf hdnTANKBN.Value = "2" Then
                    strRec = "監視センターコード一覧"
                ElseIf hdnTANKBN.Value = "3" Then
                    strRec = "出動会社コード一覧"
                End If
            ElseIf hdnPopcrtl.Value = "3" Then      '//グループコード一覧
                strRec = "グループコード一覧"       '2016/02/15 H.Mori add 2015改善開発 №9
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
            ElseIf hdnPopcrtl.Value = "2" Then      '//コード一覧
                If hdnTANKBN.Value = "1" Then
                    'strRec = "JASS2"
                    strRec = "JASS"      '--- 2008/02/27 MOD T.Watabe ---
                ElseIf hdnTANKBN.Value = "2" Then
                    strRec = "KANSHI"
                ElseIf hdnTANKBN.Value = "3" Then
                    strRec = "SYUTUDOU"
                End If
            ElseIf hdnPopcrtl.Value = "3" Then      '//グループコード一覧
                strRec = "JAHOKOKU"                 '2016/02/15 H.Mori add 2015改善開発 №9
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
                strRec = "hdnCODE"
            ElseIf hdnPopcrtl.Value = "3" Then      '2016/02/15 H.Mori add 2015改善開発 №9
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
                strRec = "txtCODE"
            ElseIf hdnPopcrtl.Value = "3" Then      '2016/02/15 H.Mori add 2015改善開発 №9
                strRec = "txtGROUPCD"
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
                strRec = "btnCODECD"
            ElseIf hdnPopcrtl.Value = "3" Then      '2016/02/15 H.Mori add 2015改善開発 №9
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
                strRec = "hdnCODE"
            ElseIf hdnPopcrtl.Value = "2" Then
                'strRec = ""
                strRec = "hdnGROUPCD"               '2016/02/15 H.Mori add 2015改善開発 №9
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
                strRec = "txtCODE"
            ElseIf hdnPopcrtl.Value = "2" Then
                'strRec = ""
                strRec = "txtGROUPCD"               '2016/02/16 H.Mori add 2015改善開発 №9
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要： '2016/02/15 H.Mori add 2015改善開発 №9
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pClear3() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "hdnGROUPCD"
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要： '2016/02/15 H.Mori add 2015改善開発 №9
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pClear4() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "txtGROUPCD"
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
            'Dim dbData As DataSet
            'dbData = fncDataSelect(0)
            'If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
            '    'データが存在しない為、検索はエラー
            '    'メッセージを出力後、検索前状態にする。

            '    strMsg.Append("alert('データが存在しません');")

            '    Call fncIni_statebf()
            '    '//--------------------------------------------------------------------------
            '    'フォーカスをセットする
            '    If hdnTANKBN.Value = "1" Then
            '        strMsg.Append("Form1.rdoKBN1.focus();")
            '    ElseIf hdnTANKBN.Value = "2" Then
            '        strMsg.Append("Form1.rdoKBN2.focus();")
            '    ElseIf hdnTANKBN.Value = "3" Then
            '        strMsg.Append("Form1.rdoKBN3.focus();")
            '    End If
            'Else
            '    'データが存在する為、新規登録は不可
            '    'データを出力後、検索後状態にする。

            '    '------------------------------------
            '    '<TODO>データを出力する
            '    Dim strTemp As String

            '    strTemp = Convert.ToString(dbData.Tables(0).Rows(0).Item("KBN"))
            '    If strTemp = "3" Then
            '        rdoKBN1.Checked = True               '//ＪＡ支所担当者を選択する
            '        rdoKBN2.Checked = False
            '        rdoKBN3.Checked = False
            '    ElseIf strTemp = "1" Then
            '        rdoKBN1.Checked = False              '//監視センター担当者を選択する
            '        rdoKBN2.Checked = True
            '        rdoKBN3.Checked = False
            '    ElseIf strTemp = "2" Then
            '        rdoKBN1.Checked = False              '//出動会社担当者を選択する
            '        rdoKBN2.Checked = False
            '        rdoKBN3.Checked = True
            '    End If

            '    'クライアントコード
            '    hdnKURACD.Value = Convert.ToString(dbData.Tables(0).Rows(0).Item("KURACD"))
            '    'クライアント名
            '    If strTemp = "3" Then                   '//ＪＡ支所担当者
            '        txtKURACD.Text = Convert.ToString(dbData.Tables(0).Rows(0).Item("KURACD")) & " : " & Convert.ToString(dbData.Tables(0).Rows(0).Item("CLI_NAME"))
            '    Else
            '        txtKURACD.Text = ""
            '    End If
            '    'コード
            '    hdnCODE.Value = Convert.ToString(dbData.Tables(0).Rows(0).Item("CODE"))
            '    'コード名称
            '    If strTemp = "3" Then                   '//ＪＡ支所担当者
            '        txtCODE.Text = Convert.ToString(dbData.Tables(0).Rows(0).Item("CODE")) & " : " & Convert.ToString(dbData.Tables(0).Rows(0).Item("JAS_NAME"))
            '    ElseIf strTemp = "1" Then               '//監視センター担当者
            '        txtCODE.Text = Convert.ToString(dbData.Tables(0).Rows(0).Item("CODE")) & " : " & Convert.ToString(dbData.Tables(0).Rows(0).Item("KANSI_NAME"))
            '    ElseIf strTemp = "2" Then               '//出動会社担当者
            '        '--- ↓2005/05/21 MOD Falcon↓ ---
            '        'txtCODE.Text = Convert.ToString(dbData.Tables(0).Rows(0).Item("CODE")) & " : " & Convert.ToString(dbData.Tables(0).Rows(0).Item("KAISYA_NAME"))
            '        txtCODE.Text = Convert.ToString(dbData.Tables(0).Rows(0).Item("CODE")) & " : " & Convert.ToString(dbData.Tables(0).Rows(0).Item("KAISYA_NAME"))
            '        '--- ↑2005/05/21 MOD Falcon↑ ---
            '    End If

            '    hdnTIME.Value = Convert.ToString(dbData.Tables(0).Rows(0).Item("TIME"))

            '    If pstrKBN = "1" Then
            '        '検索ボタン押下時
            '        Call fncIni_stateaf()

            '        '//------------------------------
            '        '<TODO>フォーカスをセットする（データが存在したのでキー以外にセット）
            '        strMsg.Append("Form1.txtTANNM.focus();")
            '    End If
            'End If
            'dbData.Dispose()

        Catch ex As Exception
            strRec = ex.ToString
            Dim ErrMsgC As New CErrMsg
            strMsg.Append("alert('システムエラー：" & ErrMsgC.mGetArtMsg(ex.ToString) & "');")
        End Try

        Return strRec

    End Function

    ''******************************************************************************
    ''* 入力キーによるデータの検索を行います。
    ''* pintKbn　0:検索ボタン押下時データ出力
    ''*        　1:新規ボタン押下時データカウント出力
    ''******************************************************************************
    'Private Function fncDataSelect(ByVal pintkbn As Integer) As DataSet

    '    'intKbn     0:検索ボタン押下
    '    'intKbn     1:新規ボタン押下

    '    '//------------------------------------------
    '    '//<TODO>Select文の作成
    '    Dim SQLC As New MSTASJAG00CCSQL.CSQL
    '    Dim SqlParamC As New CSQLParam
    '    Dim strSQL As New StringBuilder("")
    '    Dim dbData As DataSet

    '    strSQL.Append("SELECT ")
    '    If pintkbn = 0 Then
    '        '検索なので全ての項目を取得します
    '        strSQL.Append("TA.KBN, ")
    '        strSQL.Append("TA.KURACD, ")
    '        strSQL.Append("CL.CLI_NAME, ")
    '        strSQL.Append("TA.CODE, ")
    '        '--- ↓2005/05/21 ADD Falcon↓ ---
    '        'strSQL.Append("JA.JAS_NAME, ")
    '        'strSQL.Append("SH.KAISYA_NAME, ")
    '        strSQL.Append("JA_NAME || JAS_NAME AS JAS_NAME, ")
    '        strSQL.Append("SH.KAISYA_NAME || KYOTEN_NAME AS KAISYA_NAME, ")
    '        '--- ↑2005/05/21 ADD Falcon↑ ---
    '        strSQL.Append("KA.KANSI_NAME, ")
    '        strSQL.Append("TA.TANCD, ")
    '        strSQL.Append("TA.TANNM, ")
    '        strSQL.Append("TA.RENTEL1, ")
    '        strSQL.Append("TA.RENTEL2, ")
    '        strSQL.Append("TA.FAXNO, ")
    '        strSQL.Append("TA.DISP_NO, ")
    '        strSQL.Append("TA.BIKO, ")
    '        strSQL.Append("TA.ADD_DATE, ")
    '        strSQL.Append("TA.EDT_DATE, ")
    '        strSQL.Append("TA.TIME ")
    '    Else
    '        '新規なので対象データのカウントを取得します
    '        strSQL.Append("COUNT(*) AS CNT ")
    '    End If
    '    strSQL.Append("FROM  M05_TANTO TA, ")
    '    strSQL.Append("      CLIMAS CL, ")
    '    strSQL.Append("      HN2MAS JA, ")
    '    strSQL.Append("      KANSIMAS KA,")
    '    strSQL.Append("      SHUTUDOMAS SH ")
    '    strSQL.Append("WHERE TA.KBN   = :KBN ")
    '    '--- ↓2005/07/19 ADD Falcon↓ ---
    '    strSQL.Append("  AND TA.KURACD  = :KURACD ")
    '    '--- ↑2005/07/19 ADD Falcon↑ ---
    '    strSQL.Append("  AND TA.CODE  = :CODE ")
    '    strSQL.Append("  AND TA.TANCD = :TANCD ")
    '    strSQL.Append("  AND TA.KURACD = CL.CLI_CD(+) ")
    '    strSQL.Append("  AND TA.KURACD = JA.CLI_CD(+) ")
    '    strSQL.Append("  AND TA.CODE = JA.HAN_CD(+) ")
    '    strSQL.Append("  AND TA.CODE = KA.KANSI_CD(+) ")
    '    'strSQL.Append("  AND TA.CODE = SH.SHUTU_CD(+) ")
    '    strSQL.Append("  AND TA.CODE = (SH.SHUTU_CD(+) || SH.KYOTEN_CD(+)) ")

    '    'strSQL.Append("  AND '00' = SH.KYOTEN_CD(+) ") '--- 2005/07/20 DEL Falcon

    '    'hdnTANKBN.Value 1:ＪＡ担当者　2:監視センター担当者　3:出動会社担当者
    '    If hdnTANKBN.Value = "1" Then
    '        SqlParamC.fncSetParam("KBN", True, "3")
    '    ElseIf hdnTANKBN.Value = "2" Then
    '        SqlParamC.fncSetParam("KBN", True, "1")
    '    ElseIf hdnTANKBN.Value = "3" Then
    '        SqlParamC.fncSetParam("KBN", True, "2")
    '    End If

    '    If hdnCODE.Value.Length > 0 Then
    '        SqlParamC.fncSetParam("CODE", True, hdnCODE.Value)
    '    End If
    '    If txtTANCD.Text.Length > 0 Then
    '        SqlParamC.fncSetParam("TANCD", True, txtTANCD.Text)
    '    End If

    '    '--- ↓2005/07/19 ADD Falcon↓ ---
    '    If hdnTANKBN.Value = "1" Then
    '        If hdnKURACD.Value.Length > 0 Then
    '            SqlParamC.fncSetParam("KURACD", True, hdnKURACD.Value)
    '        End If
    '    Else
    '        SqlParamC.fncSetParam("KURACD", True, "ZZZZ")
    '    End If
    '    '--- ↑2005/07/19 ADD Falcon↑ ---

    '    dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)
    '    Return dbData
    'End Function

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
