'***********************************************
'緊急出動一覧　メイン画面
'***********************************************
'<TODO>宣言共通仕様
Option Explicit On
Option Strict On

'<TODO>宣言共通仕様
Imports Common          '：参照設定でCOCOMONC00を設定する
Imports JPG.Common
Imports System.Text     '：StringBuilderを使用するため

Partial Class SDLSTJAG00
    Inherits System.Web.UI.Page
    '--- ↓2005/05/13 ADD Falcon↓ ---
    '--- ↑2005/05/13 ADD Falcon↑ ---

    Protected ConstC As New CConst
    Private strSYU_CD As String = ""    '出動会社コード(クッキーより取得した値を格納する

    '<TODO>宣言共通仕様
    '******************************************************************************
    ' HttpHeader
    '******************************************************************************
    Protected HttpHeaderC As New CHttpHeader

    '<TODO>宣言共通仕様
    '******************************************************************************
    ' ScriptMessage
    '******************************************************************************
    Private strMsg As New StringBuilder("")

    '******************************************************************************
    ' 認証クラス
    '******************************************************************************
    Protected AuthC As CAuthenticate


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

        '2012/04/05 NEC ou Add Str
        '.NETの仕様変更により、ReadOnly属性をASPXでつけると、サーバ側で値の参照ができなくなるため、VB側でAttributeでつける
        If MyBase.IsPostBack = False Then
            txtKEKKA_KENSU.Attributes.Add("ReadOnly", "true")
            txtCLI_CD.Attributes.Add("ReadOnly", "true") '2013/12/12 T.Ono add 監視改善2013
            txtJA_CD.Attributes.Add("ReadOnly", "true")  '2013/12/12 T.Ono add 監視改善2013
            txtGROUP_CD.Attributes.Add("ReadOnly", "true")  '2014/10/21 H.Hosoda add 監視改善2014 No10
        End If
        '2012/04/05 NEC ou Add End

        '//------------------------------------------
        '//　HTTPヘッダを送信
        HttpHeaderC.mNoCache(Response)
        '//　認証クラスのインスタンス生成　2013/12/20 T.Ono add 監視改善2013
        AuthC = New CAuthenticate(Request, Response)
        '//------------------------------------------------
        'ＤＢ認証時(ログイン画面ログオン時)にセットした出動会社コードを格納する
        strSYU_CD = Convert.ToString(Request.Cookies(ConstC.pCookie_SD_Logincd).Value)

        '//------------------------------------------
        '<TODO>ポップアップ/登録系フレームの出力
        '      [hdnKensaku(Hidden)]を作成する事
        '//緊急出動結果一覧
        If hdnKensaku.Value = "SDLSTKFG00" Then
            Server.Transfer("SDLSTKFG00.aspx")
        End If
        '//緊急出動一覧
        If hdnKensaku.Value = "SDLSTSFG00" Then
            Server.Transfer("SDLSTSFG00.aspx")
        End If
        '//ポップアップ出力　2013/12/12 T.Ono add 監視改善
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
        '      [lblScript(Label)]を作成する事
        '//------------------------------------------
        '//　JavaScript格納
        strScript.Append("<Script language=javascript>")
        '<独自スクリプト>
        strScript.Append(cscript1.mWriteScript( _
             MyBase.MapPath("../../../SD/SDLSTJAG/SDLSTJAG00/") & "SDLSTJAG00.js"))
        '<フォーカス関連関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncFo.js"))
        '<日付関連関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncDate.js"))
        strScript.Append("</Script>")
        '//------------------------------------------
        '//　Css格納
        strScript.Append("<Style>")
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "CssData.css"))
        strScript.Append("</Style>")
        '//------------------------------------------

        '2013/12/20 T.Ono add 監視改善2013
        Dim strDivFaxKbnDisp As String = "[" & AuthC.pGROUPNAME & "][" & InStr(AuthC.pGROUPNAME, "0監視業務単独") & "]"
        '営業所の取得
        Dim strEIGYOGROUP As String = ConfigurationSettings.AppSettings("GROUP_EIGYOU")        '営業所名取得(Web.config) 2014/11/14 T.Ono add
        strScript.Append("<!-- ADの監視ｾﾝﾀｰ情報 " & strDivFaxKbnDisp & " -->" & vbCrLf)
        If InStr(AuthC.pGROUPNAME, "0監視業務単独") > 0 Then ' 沖縄や岐阜の画面には表示させない
            hdnOTHER_KANSI_CENTER.Value = "1"
        ElseIf InStr(AuthC.pGROUPNAME, strEIGYOGROUP) > 0 Then '営業所の画面には表示させない 2014/11/14 T.Ono add
            hdnOTHER_KANSI_CENTER.Value = "1"
        Else
            hdnOTHER_KANSI_CENTER.Value = "0"
        End If

        '運行開発部の取得 2014/11/14 T.Ono add
        '運行にも"営業所"が含まれるため、運行かどうかを最後にチェック
        Dim strUNKOUGROUP As String
        Dim arrUnkouGroup() As String
        Dim i As Integer
        strUNKOUGROUP = ConfigurationSettings.AppSettings("GROUP_UNKOU")        '運行開発部名取得(Web.config)
        arrUnkouGroup = strUNKOUGROUP.Split(Convert.ToChar(","))                '運行開発部名取得(カンマ区切り)

        '>>運行開発部チェック
        For i = 0 To arrUnkouGroup.Length - 1
            If InStr(AuthC.pGROUPNAME, arrUnkouGroup(i)) > 0 Then
                hdnOTHER_KANSI_CENTER.Value = "0"
            End If
        Next i


        '//　Script書込み
        lblScript.Text = strScript.ToString

        Dim strMyAspx As String
        Dim strKBN As String

        strMyAspx = Request.Form("hdnMyAspx")

        '//------------------------------------------
        If MyBase.IsPostBack = False Then
            '//--------------------------------------
            '//初めて開いた時だけ実行される

            '//--------------------------------------
            '初期表示として必要なコントロールの設定を行います
            Call fncIni_format()    '//値の初期化

            If strMyAspx = "SDSYUJAG00" Then
                '//緊急出動確認・入力からの遷移時

                '検索対象期間（From）
                txtSIJIYMD_From.Text = fncDateSet(Request.Form("hdnMOVE_SIJIYMD_F"))
                '発生日（To）
                txtSIJIYMD_To.Text = fncDateSet(Request.Form("hdnMOVE_SIJIYMD_T"))
                '2013/12/12 T.Ono add 監視改善2013 START
                'クライアントコード
                hdnCLI_CD.Value = Request.Form("hdnMOVE_CLI_CD")
                'クライアント名
                txtCLI_CD.Text = Request.Form("hdnMOVE_CLI_CD_NAME")
                'ＪＡコード
                hdnJA_CD.Value = Request.Form("hdnMOVE_JA_CD")
                'ＪＡ名
                txtJA_CD.Text = Request.Form("hdnMOVE_JA_CD_NAME")
                ' 2013/12/12 T.Ono add 監視改善2013 START
                ' 2014/10/21 H.Hosoda add 2014改善開発 No10 START
                '販売事業者グループコード
                hdnGROUP_CD.Value = Request.Form("hdnMOVE_GROUP_CD")
                '販売事業者グループ名
                txtGROUP_CD.Text = Request.Form("hdnMOVE_GROUP_CD_NAME")
                ' 2014/10/21 H.Hosoda add 2014改善開発 No10 END

                '区分
                strKBN = Request.Form("hdnMOVE_KBN")
                If strKBN = "1" Then
                    rdoKBN1.Checked = True
                    rdoKBN2.Checked = False
                Else
                    rdoKBN1.Checked = False
                    rdoKBN2.Checked = True
                End If

                '選択キーを保持する
                hdnKEY_KANSCD.Value = Request.Form("hdnKEY_KANSCD")
                hdnKEY_SYONO.Value = Request.Form("hdnKEY_SYONO")
                'スクロールバー
                hdnScrollTop.Value = Request.Form("hdnScrollTop")            '2013/12/11 T.Ono add 監視改善2013

                '--- ↓2005/05/13 ADD Falcon↓ ---
                '「データなし」メッセージを出力しない
                hdnMsgMode.Value = "MSG0"
                '--- ↑2005/05/13 ADD Falcon↑ ---

                '区分に合った画面状態で検索
                strMsg.Append("fncChangeMode(" & strKBN & ",'1');")

                '//------------------------------------------------
                '<TODO>フォーカスをセットする
                If strKBN = "1" Then
                    strMsg.Append("Form1.rdoKBN1.focus();")
                Else
                    strMsg.Append("Form1.rdoKBN2.focus();")
                End If

            Else
                '//出動会社ログイン画面からの遷移時

                '//一覧区分（出動一覧をデフォルト表示）
                rdoKBN1.Checked = True
                rdoKBN2.Checked = False

                '--- ↓2005/05/13 ADD Falcon↓ ---
                '「データなし」メッセージを出力
                hdnMsgMode.Value = ""
                '--- ↑2005/05/13 ADD Falcon↑ ---

                '出動一覧として検索
                strMsg.Append("fncChangeMode(1,'0');")

                strMsg.Append("Form1.rdoKBN1.focus();")
            End If

            '//--------------------------------------
            '//0:通常出動会社　1:監視センター
            hdnLOGIN_FLG.Value = pLOGIN_FLG
        Else
            '//--------------------------------------
            '//２回目以降実行される
            '//--------------------------------------
        End If

        '//-------------------------------------------------
        '<TODO>自分の画面IDをHIDDENのhdnMyAspxに書き込む（システム共通）
        hdnMyAspx.Value = "SDLSTJAG00"
        '//-------------------------------------------------

    End Sub

    '******************************************************************************
    '* 各コントロールの設定値の初期化
    '******************************************************************************
    Private Sub fncIni_format()

        rdoKBN1.Checked = True
        rdoKBN2.Checked = False
        txtSIJIYMD_From.Text = ""
        txtSIJIYMD_To.Text = ""
        hdnKEY_KANSCD.Value = ""
        hdnKEY_SYONO.Value = ""
        '2013/12/12 T.Ono add 監視改善2013 START
        txtCLI_CD.Text = ""
        txtJA_CD.Text = ""
        hdnCLI_CD.Value = ""
        hdnJA_CD.Value = ""
        hdnScrollTop.Value = "0"
        '2013/12/12 T.Ono add 監視改善2013 END
        '2014/10/21 H.Hosoda add 2014改善開発 No10 START
        txtGROUP_CD.Text = ""
        hdnGROUP_CD.Value = ""
        '2014/10/21 H.Hosoda add 2014改善開発 No10 END

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
    '*　概　要：パラメータ値より時刻HH:mm:ss値を返す
    '*　備　考：
    '******************************************************************************
    Public Function fncTimeSet(ByVal pstrTime As String) As String
        Dim TimeFncC As New CTimeFnc
        Dim strRec As String
        strRec = ""
        If IsNumeric(pstrTime) = True Then
            strRec = TimeFncC.mGet(pstrTime, 0)
        End If

        Return strRec
    End Function

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
    '*　概　要：出動会社コードの値を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pSYU_CD() As String
        Get
            Return strSYU_CD
        End Get
    End Property

    '******************************************************************************
    '*　概　要：検索対象期間（Ｆｒｏｍ）の値を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pSIJIYMD_F() As String
        Get
            Return fncDateGet(txtSIJIYMD_From.Text)
        End Get
    End Property

    '******************************************************************************
    '*　概　要：検索対象期間（Ｔｏ）の値を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pSIJIYMD_T() As String
        Get
            Return fncDateGet(txtSIJIYMD_To.Text)
        End Get
    End Property

    '******************************************************************************
    '*　概　要：一覧で選択した監視センターコードの値を渡すプロパティ
    '*　備　考：緊急出動確認・入力画面より戻ってきた時に使用
    '******************************************************************************
    Public ReadOnly Property pKEY_KANSCD() As String
        Get
            Return hdnKEY_KANSCD.Value
        End Get
    End Property

    '******************************************************************************
    '*　概　要：一覧で選択した処理番号の値を渡すプロパティ
    '*　備　考：緊急出動確認・入力画面より戻ってきた時に使用
    '******************************************************************************
    Public ReadOnly Property pKEY_SYONO() As String
        Get
            Return hdnKEY_SYONO.Value
        End Get
    End Property

    '******************************************************************************
    '*　概　要：ログインユーザー名を返すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pLOGIN_USER() As String
        Get
            Return Convert.ToString(Request.Cookies(ConstC.pCookie_SD_Logincd).Value)
        End Get
    End Property

    '******************************************************************************
    '*　概　要：ログインユーザーのIPADDRESSを返すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pLOGIN_IPADDRESS() As String
        Get
            Return Request.ServerVariables("REMOTE_ADDR")
        End Get
    End Property

    '******************************************************************************
    '*　概　要：ログインユーザーの利用可能監視センターを返すプロパティ
    '*　備　考：※監視センターより遷移時のみ
    '******************************************************************************
    Public ReadOnly Property pLOGIN_ALLCENTERCD() As String
        Get
            Return Convert.ToString(Request.Cookies(ConstC.pCookie_SD_ALLCenter).Value)
        End Get
    End Property

    '******************************************************************************
    '*　概　要：ログインした遷移フラグ
    '*　備　考：0:通常出動会社　1:監視センター
    '******************************************************************************
    Public ReadOnly Property pLOGIN_FLG() As String
        Get
            If Convert.ToString(Request.Cookies(ConstC.pCookie_SD_ALLCenter).Value).Length = 0 Then
                Return "0"
            Else
                Return "1"
            End If
        End Get
    End Property

    '<TODO>検索条件としてIFRAME画面に引き渡したい値ReadOnlyプロパティで設定する
    '******************************************************************************
    '*　概　要：クライアントコードの値を渡すプロパティ　'2013/12/12 T.ono add 監視改善2013
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pCLI_CD() As String
        Get
            Return hdnCLI_CD.Value.Trim
        End Get
    End Property

    '******************************************************************************
    '*　概　要：クライアント名の値を渡すプロパティ　'2013/12/12 T.ono add 監視改善2013
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pCLI_CD_NAME() As String
        Get
            Return txtCLI_CD.Text
        End Get
    End Property

    '******************************************************************************
    '*　概　要：ＪＡコードの値を渡すプロパティ　'2013/12/12 T.ono add 監視改善2013
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pJA_CD() As String
        Get
            Return hdnJA_CD.Value.Trim
        End Get
    End Property

    '******************************************************************************
    '*　概　要：ＪＡコードの値を渡すプロパティ　'2013/12/12 T.ono add 監視改善2013
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pJA_CD_NAME() As String
        Get
            Return txtJA_CD.Text
        End Get
    End Property

    '******************************************************************************
    '*　概　要：グループコードの値を渡すプロパティ　'2014/10/21 H.hosoda add 監視改善2014
    '*　備　考：販売事業者グループコードを渡す
    '******************************************************************************
    Public ReadOnly Property pGROUP_CD() As String
        Get
            Return hdnGROUP_CD.Value.Trim
        End Get
    End Property

    '******************************************************************************
    '*　概　要：グループ名の値を渡すプロパティ　'2014/10/21 H.hosoda add 監視改善2014
    '*　備　考：販売事業者グループ名を渡す
    '******************************************************************************
    Public ReadOnly Property pGROUP_CD_NAME() As String
        Get
            Return txtGROUP_CD.Text
        End Get
    End Property

    '******************************************************************************
    '*　概　要：スクロールバーの位置を渡すプロパティ　2013/12/11 T.Ono add 監視改善2013
    '*　備　考：対応入力画面より戻ってきた時に使用
    '******************************************************************************
    Public ReadOnly Property pScrollTop() As String
        Get
            Return hdnScrollTop.Value
        End Get
    End Property

    '******************************************************************************
    '*　概　要：絞込み条件を渡すプロパティ1　2013/12/12 T.Ono add 監視改善2013
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pCode1() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = pLOGIN_ALLCENTERCD
                Case "1"
                    strRec = hdnCLI_CD.Value                 '//ＪＡコード一覧
                Case "2"                                     ' 2014/10/21 H.Hosoda add 2014改善開発 No10
                    strRec = hdnCLI_CD.Value                 '//販売事業者一覧
                Case Else
                    strRec = ""
            End Select
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：絞込み条件を渡すプロパティ2　2013/12/12 T.Ono add 監視改善2013
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pCode2() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = ""
                Case "1"
                    strRec = ""
                Case "2"            ' 2014/10/21 H.Hosoda add 2014改善開発 No10
                    strRec = ""
                Case Else
                    strRec = ""
            End Select
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：出力する一覧の名前を渡すプロパティ　2013/12/12 T.Ono add 監視改善2013
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pListName() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = "クライアント一覧"
                Case "1"
                    strRec = "ＪＡ一覧"
                Case "2"                ' 2014/10/21 H.Hosoda add 2014改善開発 No10
                    strRec = "販売事業者グループ一覧"
                Case Else
                    strRec = ""
            End Select
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：出力する一覧を制御する値を渡すプロパティ　2013/12/12 T.Ono add 監視改善2013
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pListCd() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = "CLI"
                Case "1"
                    strRec = "JA"
                Case "2"                ' 2014/10/21 H.Hosoda add 2014改善開発 No10
                    strRec = "HANG"
                Case Else
                    strRec = ""
            End Select
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：コードを返すオブジェクトの名前値を渡すプロパティ　2013/12/12 T.Ono add 監視改善2013
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pBackCode() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = "hdnCLI_CD"
                Case "1"
                    strRec = "hdnJA_CD"
                Case "2"                ' 2014/10/21 H.Hosoda add 2014改善開発 No10
                    strRec = "hdnGROUP_CD"
                Case Else
                    strRec = ""
            End Select
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：名称を返すオブジェクトの名前値を渡すプロパティ　2013/12/12 T.Ono add 監視改善2013
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pBackName() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = "txtCLI_CD"
                Case "1"
                    strRec = "txtJA_CD"
                Case "2"                ' 2014/10/21 H.Hosoda add 2014改善開発 No10
                    strRec = "txtGROUP_CD"
                Case Else
                    strRec = ""
            End Select
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：フォーカスを返すオブジェクトの名前値を渡すプロパティ　2013/12/12 T.Ono add 監視改善2013
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pBackFocs() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = "btnCLI_CD"
                Case "1"
                    strRec = "btnJA_CD"
                Case "2"                ' 2014/10/21 H.Hosoda add 2014改善開発 No10
                    strRec = "btnGROUP_CD"
                Case Else
                    strRec = ""
            End Select
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：ＪＡが変更された時にクリアするオブジェクトの名前値を渡すプロパティ１　2013/12/12 T.Ono add 監視改善2013
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pClearName() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    '2014/10/21 H.Hosoda mod 2014改善開発 No10 START
                    'strRec = "txtJA_CD"
                    txtJA_CD.Text = txtJA_CD.Text.Trim()
                    txtGROUP_CD.Text = txtGROUP_CD.Text.Trim()
                    If txtJA_CD.Text <> String.Empty Then
                        strRec = "txtJA_CD"
                    Else
                        strRec = "txtGROUP_CD"
                    End If
                    '2014/10/21 H.Hosoda mod 2014改善開発 No10 END
                Case "1"
                    strRec = ""
                Case "2"                ' 2014/10/21 H.Hosoda add 2014改善開発 No10
                    strRec = ""
                Case Else
                    strRec = ""
            End Select
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*　概　要：ＪＡが変更された時にクリアするオブジェクトの名前値を渡すプロパティ１　2013/12/12 T.Ono add 監視改善2013
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pClearCode() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    '2014/10/21 H.Hosoda mod 2014改善開発 No10 START
                    'strRec = "hdnJA_CD"
                    hdnJA_CD.Value = hdnJA_CD.Value.Trim()
                    hdnGROUP_CD.Value = hdnGROUP_CD.Value.Trim()
                    If hdnJA_CD.Value <> String.Empty Then
                        strRec = "hdnJA_CD"
                    Else
                        strRec = "hdnGROUP_CD"
                    End If
                    '2014/10/21 H.Hosoda mod 2014改善開発 No10 END
                Case "1"
                    strRec = ""
                Case "2"                ' 2014/10/21 H.Hosoda add 2014改善開発 No10
                    strRec = ""
                Case Else
                    strRec = ""
            End Select
            Return strRec
        End Get
    End Property

End Class
