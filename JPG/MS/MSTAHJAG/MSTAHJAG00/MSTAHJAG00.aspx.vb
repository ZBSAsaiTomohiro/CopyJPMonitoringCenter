'***********************************************
' ＪＡ担当者連絡先エクセル出力  画面
'***********************************************
' 変更履歴
' 2015/12/16 T.Ono 新規作成
'（MSTAEJAG00をコピー　JA担当者・報告先・注意事項マスタを参照するためにリニューアル）

Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common
Imports JPG.Common.log

Imports System.Text
Imports System.IO

Partial Class MSTAHJAG00
    Inherits System.Web.UI.Page
    Protected WithEvents dbData As System.Data.DataSet

    '******************************************************************************
    ' HttpHeader
    '******************************************************************************
    Protected HttpHeaderC As New CHttpHeader

    '<TODO>宣言共通仕様
    '******************************************************************************
    ' 認証クラス
    '******************************************************************************
    Protected AuthC As CAuthenticate

    '******************************************************************************
    ' クッキー
    '******************************************************************************
    Protected ConstC As New CConst

    '******************************************************************************
    ' ScriptMessage
    '******************************************************************************
    Private strMsg As New StringBuilder("")      '//<script>は必要なし

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
    Private Sub Page_Load(ByVal sender As System.Object, _
                                            ByVal e As System.EventArgs) Handles MyBase.Load

        '.NETの仕様変更により、ReadOnly属性をASPXでつけると、サーバ側で値の参照ができなくなるため、VB側でAttributeでつける
        If MyBase.IsPostBack = False Then
            txtKURACD.Attributes.Add("ReadOnly", "true")
            txtJACD.Attributes.Add("ReadOnly", "true")
            txtGROUPCD.Attributes.Add("ReadOnly", "true")
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
        '[対応結果一覧]使用可能権限(運:○/営:○/監:△/出:×)
        AuthC.fncAuthCheck(Server, AuthC.pGROUP_UNKOU & "," & AuthC.pGROUP_KANSHI & "," & AuthC.pGROUP_EIGYOU)

        '//------------------------------------------
        '//ポップアップ出力
        If hdnKensaku.Value = "COPOPUPG00" Then
            Server.Transfer("../../../Popup/COPOPUPG00.aspx")
        End If
        '//件数チェックスクリプト
        If hdnKensaku.Value = "MSTAHJCG00" Then
            Server.Transfer("./MSTAHJCG00.aspx")
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
             MyBase.MapPath("../../../MS/MSTAHJAG/MSTAHJAG00/") & "MSTAHJAG00.js"))
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
        '//　Script書込み
        lblScript.Text = strScript.ToString

        '//------------------------------------------------------------------------------
        If MyBase.IsPostBack = False Then
            '//--------------------------------------
            '//　初めて開いた時だけ実行される

            '//--------------------------------------------------------------------------
            '<TODO>初期表示として必要なコントロールの設定を行います
            '      例)画面初期表示時は●●●が選択されていること……等の処理
            '//--------------------------------------------------------------------------
            '　処理結果による画面の状態の設定------------------------
            '　画面を【検索前状態】にする（入力データはそのまま遷移させる）
            '//-------------------------------------------
            '//フォーカスをセットする
            strMsg.Append("Form1.btnKURACD.focus();")

            '2017/07/20 H.Mori add START
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
            '2017/07/20 H.Mori add END

        Else
            '//--------------------------------------
            '//　２回目以降実行される
            '//--------------------------------------------------------------------------
            '//※画面表示するコンボボックスは各最終イベント/メソッドでCALLします
            '//--------------------------------------------------------------------------
        End If

        '//-------------------------------------------------
        '<TODO>自分の画面IDをHIDDENのhdnMyAspxに書き込む（システム共通）
        hdnMyAspx.Value = "MSTAHJAG00"
        '//-------------------------------------------------

    End Sub

    '******************************************************************************
    ' Excel出力(チェックつき)
    '******************************************************************************
    Private Sub btnSelect_ServerClick(ByVal sender As System.Object, _
                                    ByVal e As System.EventArgs) Handles btnSelect.ServerClick
        Dim strRec As String
        Dim MSTAHJAG00C As New MSTAHJAG00MSTAHJAW00.MSTAHJAW00

        Dim strPGKBN As String

        '//　認証クラスのインスタンス生成
        AuthC = New CAuthenticate(Request, Response)

        Dim strRecMsg As String = ""
        Dim intMaxDataCnt As Integer = 65000

        '2019/11/01 T.Ono mod 監視改善2019 hdnKURACD_TO、hdnJACD_CLI追加
        'strRec = MSTAHJAG00C.mExcel(
        '                 Me.Session.SessionID,
        '                 hdnKURACD.Value.Trim,
        '                 hdnJACD.Value.Trim,
        '                 hdnGROUPCD.Value.Trim,
        '                 strPGKBN,
        '                 txtKURACD.Text,
        '                 txtGROUPCD.Text,
        '                 intMaxDataCnt,
        '                  AuthC.pAUTHCENTERCD
        '                 )
        strRec = MSTAHJAG00C.mExcel(
                         Me.Session.SessionID,
                         hdnKURACD.Value.Trim,
                         hdnKURACD_TO.Value.Trim,
                         hdnJACD.Value.Trim,
                         hdnJACD_CLI.Value.Trim,
                         hdnGROUPCD.Value.Trim,
                         strPGKBN,
                         txtKURACD.Text,
                         txtGROUPCD.Text,
                         intMaxDataCnt,
                          AuthC.pAUTHCENTERCD
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

        ElseIf strRec.Substring(0, 7) = "DATAMAX" Then
            'データが最大行数を超えたの場合
            strRecMsg = "データが最大行数を超えました。[最大" & intMaxDataCnt & "行]"
            strMsg.Append("alert('" & strRecMsg & "');")
            strMsg.Append("Form1.btnSelect.focus();")

        Else
            '「開く、保存」のダイヤログが出るようにHTTPヘッダに追加
            'ファイル名は、HttpUtility.UrlEncodeメソッドを使用してSJISにエンコードする必要がある
            '.xls形式
            HttpHeaderC.mDownLoadXLS(Response, "ＪＡ担当者連絡先.xls")

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

    '******************************************************************************
    '* 件数チェック用画面に渡すパラメータ設定
    '******************************************************************************
    Public ReadOnly Property pKuracd() As String
        Get
            Return hdnKURACD.Value.Trim
        End Get
    End Property
    '2019/11/01 T.Ono add 監視改善2019
    Public ReadOnly Property pKuracd_to() As String
        Get
            Return hdnKURACD_TO.Value.Trim
        End Get
    End Property
    Public ReadOnly Property pJAcd() As String
        Get
            Return hdnJACD.Value.Trim
        End Get

    End Property
    'ＪＡコードに紐づくクライアントコードの値を渡すプロパティ　'2013/12/09 T.ono add 監視改善2013
    Public ReadOnly Property pJACD_CLI() As String
        Get
            Return hdnJACD_CLI.Value.Trim
        End Get
    End Property
    Public ReadOnly Property pGroupcd() As String
        Get
            Return hdnGROUPCD.Value.Trim
        End Get

    End Property
    Public ReadOnly Property pCentercd() As String
        Get
            Return AuthC.pAUTHCENTERCD()
        End Get
    End Property
    '******************************************************************************
    '*　概　要：絞込み条件を渡すプロパティ
    '*　備　考：(県コード)
    '******************************************************************************
    Public ReadOnly Property pCode1() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    ''運行開発部の場合は全ての監視センターを選択可能
                    ''以外の場合は代行を使用せずに自分の監視センターのみ使用可能
                    strRec = AuthC.pAUTHCENTERCD

                Case "1"
                    strRec = hdnKURACD.Value
                Case "2"
                    strRec = AuthC.pAUTHCENTERCD
                Case "3"
                    '2019/11/01 T.Ono mod 監視改善219
                    strRec = AuthC.pAUTHCENTERCD
                Case Else
                    strRec = ""
            End Select
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*　概　要：絞込み条件を渡すプロパティ
    '*　備　考：(供給センターコード/ＪＡコード)
    '******************************************************************************
    Public ReadOnly Property pCode2() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = ""
                Case "1"
                    strRec = ""
                Case "2"
                    strRec = hdnKURACD.Value.Trim
                Case "3"
            End Select
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*　概　要：絞込み条件を渡すプロパティ
    '*　備　考：2019/11/01 T.Ono mod 監視改善2019
    '******************************************************************************
    Public ReadOnly Property pCode3() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = ""
                Case "1"
                    strRec = hdnKURACD_TO.Value.Trim
                Case "2"
                    strRec = ""
                Case "3"
                    strRec = ""
                Case Else
                    strRec = ""
            End Select
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*　概　要：絞込み条件を渡すプロパティ
    '*　備　考：2019/11/01 T.Ono mod 監視改善2019
    '******************************************************************************
    Public ReadOnly Property pCode4() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = ""
                Case "1"
                    strRec = ""
                Case "2"
                    strRec = hdnKURACD_TO.Value.Trim
                Case "3"
                    strRec = ""
                Case Else
                    strRec = ""
            End Select
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*　概　要：出力する一覧の名前を渡すプロパティ
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
                Case "2"
                    strRec = "グループコード一覧"
                Case "3"
                    '2019/11/01 T.Ono add 監視改善2019
                    strRec = "クライアント一覧"
                Case Else
                    strRec = ""
            End Select
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*　概　要：出力する一覧を制御する値を渡すプロパティ
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
                Case "2"
                    strRec = "JAHOKOKU"
                Case "3"
                    '2019/11/01 T.Ono add 監視改善2019
                    strRec = "CLI"
                Case Else
                    strRec = ""
            End Select
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*　概　要：コードを返すオブジェクトの名前値を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pBackCode() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = "hdnKURACD"
                Case "1"
                    strRec = "hdnJACD"
                Case "2"
                    strRec = "hdnGROUPCD"
                Case "3"
                    '2019/11/01 T.Ono add 監視改善2019
                    strRec = "hdnKURACD_TO"
                Case Else
                    strRec = ""
            End Select
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*　概　要：名称を返すオブジェクトの名前値を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pBackName() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = "txtKURACD"
                Case "1"
                    strRec = "txtJACD"
                Case "2"
                    strRec = "txtGROUPCD"
                Case "3"
                    '2019/11/01 T.Ono add 監視改善2019
                    strRec = "txtKURACD_TO"
                Case Else
                    strRec = ""
            End Select
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
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = ""
                Case "1"
                    strRec = "hdnJACD_CLI"
                Case "2"
                    strRec = ""
                Case "3"
                    strRec = ""
                Case Else
                    strRec = ""
            End Select
            Return strRec
        End Get

    End Property
    '******************************************************************************
    '*　概　要：フォーカスを返すオブジェクトの名前値を渡すプロパティ
    '*　概　要：カレンダー日付でフォーカスセットされる項目名を返すオブジェクトを指定
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pBackFocs() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value.Length > 0 Then
                Select Case hdnPopcrtl.Value
                    Case "0"
                        strRec = "btnKURACD"
                    Case "1"
                        strRec = "btnJACD"
                    Case "2"
                        strRec = "btnGROUPCD"
                    Case "3"
                        '2019/11/01 T.Ono add 監視改善2019
                        strRec = "btnKURACD_TO"
                    Case Else
                        strRec = ""
                End Select
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
            Dim strRec As String = ""
            If hdnPopcrtl.Value.Length > 0 Then
                Select Case hdnPopcrtl.Value
                    Case "0"
                        strRec = "fncSetTo"
                    Case "1"
                        strRec = ""
                    Case "2"
                        strRec = ""
                    Case "3"
                        strRec = ""
                    Case Else
                        strRec = ""
                End Select
            End If
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*　概　要：クライアントが変更された時にクリアするオブジェクトの名前値を渡すプロパティ１
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pClearCode1() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = "txtJACD"
                Case "1"
                    strRec = ""
                Case "2"
                    strRec = ""
                Case "3"
                    '2019/11/01 T.Ono add 監視改善2019
                    'strRec = ""
                    strRec = "txtJACD"
                Case Else
                    strRec = ""
            End Select
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*　概　要：クライアントが変更された時にクリアするオブジェクトの名前値を渡すプロパティ２
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pClearCode2() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = "hdnJACD"
                Case "1"
                    strRec = ""
                Case "2"
                    strRec = ""
                Case "3"
                    '2019/11/01 T.Ono add 監視改善2019
                    strRec = "hdnJACD"
                Case Else
                    strRec = ""
            End Select
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*　概　要：クライアントが変更された時にクリアするオブジェクトの名前値を渡すプロパティ３
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pClearCode3() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = "txtGROUPCD"
                Case "1"
                    strRec = ""
                Case "2"
                    strRec = ""
                Case "3"
                    '2019/11/01 T.Ono add 監視改善2019
                    'strRec = ""
                    strRec = "txtGROUPCD"
                Case Else
                    strRec = ""
            End Select
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*　概　要：クライアントが変更された時にクリアするオブジェクトの名前値を渡すプロパティ４
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pClearCode4() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = "hdnGROUPCD"
                Case "1"
                    strRec = ""
                Case "2"
                    strRec = ""
                Case "3"
                    '2019/11/01 T.Ono add 監視改善2019
                    strRec = "hdnGROUPCD"
                Case Else
                    strRec = ""
            End Select
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*　概　要：クライアントが変更された時にクリアするオブジェクトの名前値を渡すプロパティ５
    '*　備　考：2019/11/01 T.Ono add 監視改善2019
    '******************************************************************************
    Public ReadOnly Property pClearCode5() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = "hdnJACD_CLI"
                Case "1"
                    strRec = ""
                Case "2"
                    strRec = ""
                Case "3"
                    strRec = "hdnJACD_CLI"
                Case Else
                    strRec = ""
            End Select
            Return strRec
        End Get
    End Property
    '**********************************************************
    ' 2012/06/28 ADD W.GANEKO
    'ログ吐き出し
    '戻り値：書き込んだファイルへのフルパス
    '**********************************************************
    Public Sub mlog(ByVal pstrString As String)
        Dim strFilnm As String = "log" & System.DateTime.Today.ToString("yyyyMMdd")
        Dim strLogPath As String = ConfigurationSettings.AppSettings("LOG_OUT_PATH")
        Dim strPath As String = strLogPath & strFilnm & ".txt"
        Dim strLogFlg As String = ConfigurationSettings.AppSettings("LOG_OUT")
        Dim LogC As New CLog
        Dim strRecLog As String
        Dim strRec As String

        Try
            If strLogFlg = "1" Then
                '書き込みファイルへのストリーム
                Dim outFile As New StreamWriter(strPath, True, System.Text.Encoding.Default)

                '引数の文字列をストリームに書き込み
                outFile.Write(System.DateTime.Now & "|" & AuthC.pUSERNAME & "|" & AuthC.pIPADDRESS & "|" & pstrString + vbCrLf)

                'メモリフラッシュ（ファイル書き込み）
                outFile.Flush()

                'ファイルクローズ
                outFile.Close()
            End If
        Catch ex As Exception
            strRec = "ERROR:" & ex.ToString
            strRecLog = LogC.mAPLog(Me.Session.SessionID, AuthC.pUSERNAME, AuthC.pIPADDRESS, Request.Form("hdnMyAspx"), "1", strRec, Request.Form)
        End Try
    End Sub
End Class
