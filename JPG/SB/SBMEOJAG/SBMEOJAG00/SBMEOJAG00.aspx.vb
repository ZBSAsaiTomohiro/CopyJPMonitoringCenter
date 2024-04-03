'***********************************************
' 一般消費者名簿出力
'***********************************************
' 変更履歴
' 2018/08/22 T.Ono 
' 

Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common
Imports JPG.Common.log

Imports System.Text

Partial Class SBMEOJAG00
    Inherits System.Web.UI.Page

    'ボタン

    'テキストボックス

    'コンボボックス

    'チェックボックス

    '非表示コントロール

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
    ' ScriptMessage
    '******************************************************************************
    Private strMsg As New StringBuilder("")      '//<script>は必要なし
    Dim strFileType As String         '出力リスト 


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
            '入力禁止のtxtがあれば設定
            txtKURACD_From.Attributes.Add("ReadOnly", "true")
            txtKURACD_To.Attributes.Add("ReadOnly", "true")
            txtHANTENCD_From.Attributes.Add("ReadOnly", "true")
            txtHANTENCD_To.Attributes.Add("ReadOnly", "true")
        End If

        '//------------------------------------------
        '//　HTTPヘッダを送信
        HttpHeaderC.mNoCache(Response)

        '//------------------------------------------
        '//　認証クラスのインスタンス生成
        AuthC = New CAuthenticate(Request, Response)
        'AuthC.pCENTERCD()
        '//------------------------------------------
        '//　認証処理
        '<TODO>：使用可能権限を指定する
        '[警報出力画面]使用可能権限(運:○/営:○/監:△/出:×)
        AuthC.fncAuthCheck(Server, AuthC.pGROUP_UNKOU & "," & AuthC.pGROUP_KANSHI & "," & AuthC.pGROUP_EIGYOU)

        '//------------------------------------------
        '//ポップアップ出力
        If hdnKensaku.Value = "COPOPUPG00" Then
            Server.Transfer("../../../Popup/COPOPUPG00.aspx")
        End If


        '//-----------------------------------------------
        '//初めて開いた時だけ実行される
        If MyBase.IsPostBack = False Then
            'POSTデータの取得変数の初期化
            Call fncGetPostIni()
        Else
            'POSTデータの取得
            Call fncGetPost()
        End If
        '//-----------------------------------------------

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
             MyBase.MapPath("../../../SB/SBMEOJAG/SBMEOJAG00/") & "SBMEOJAG00.js"))
        '<フォーカス関連関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncFo.js"))
        '<数字チェック関数>
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

        'コンボボックスの作成
        '<TODO>コンボボックスの作成FunctionをCallする
        Call fncCreateCombo()

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

            '初期表示として必要なコントロールの設定を行います
            'コンボボックスの作成
            'Call fncIni_format()    '//値の初期化

            '年度を表示
            txtNENDO.Text = DateTime.Now.AddMonths(-3).ToString("yyyy")

            '//フォーカスをセットする
            strMsg.Append("Form1.txtKENCD.focus();")
        Else
            '//--------------------------------------
            '//　２回目以降実行される
            '//--------------------------------------------------------------------------
            '//※画面表示するコンボボックスは各最終イベント/メソッドでCALLします
            '//--------------------------------------------------------------------------
            '<TODO>コンボボックス使用時、値選択のFunctionをCallする
            Call fncSelectCombo()

        End If


        '//-------------------------------------------------
        '<TODO>自分の画面IDをHIDDENのhdnMyAspxに書き込む（システム共通）
        hdnMyAspx.Value = "SBMEOJAG00"
        '//-------------------------------------------------

    End Sub

    '******************************************************************************
    '*　概　要：コンボボックスの選択
    '*　備　考：
    '******************************************************************************
    Private Sub fncSelectCombo()
        Dim list As New ListItem
        '//<TODO>コンボボックスを選択状態にする

        '//出力リスト
        If strFileType <> "" Then
            list = listfiletype.Items.FindByValue(strFileType)
            listfiletype.SelectedIndex = listfiletype.Items.IndexOf(list)
        End If
    End Sub

    '******************************************************************************
    '* POSTデータの取得変数の初期化
    '******************************************************************************
    Private Sub fncGetPostIni()
        '//--------------------------------------------------------------------------
        ''<TODO>画面コントロール内容を格納した変数を初期化する
        ''//-----------------------------------------------
        hdnKURACD_From.Value = ""
        hdnKURACD_To.Value = ""
        txtKURACD_From.Text = ""
        txtKURACD_To.Text = ""

        hdnHANTENCD_From.Value = ""
        hdnHANTENCD_To.Value = ""
        txtHANTENCD_From.Text = ""
        txtHANTENCD_To.Text = ""

        txtKENCD.Text = ""

    End Sub

    '******************************************************************************
    '* HTTPPOSTデータ取得
    '******************************************************************************
    Private Sub fncGetPost()
        '//--------------------------------------------------------------------------
        '<TODO>画面コントロールの内容を変数に格納する
        '//     コンボボックスのXYZや日付の変換等はこの箇所で行う
        strFileType = Request.Form("listfiletype")

    End Sub

    '******************************************************************************
    '* 各コントロールの設定値の初期化
    '******************************************************************************
    Private Sub fncIni_format()

        'コンボ作成
        Call fncCombo_Create_FileType()         '出力リストコンボ

        listfiletype.SelectedIndex = 0

    End Sub

    '******************************************************************************
    '*　概　要：コンボボックス作成
    '*　備　考：
    '******************************************************************************
    Private Sub fncCreateCombo()
        '//--------------------------------------------------------------------------
        '<TODO>コンボボックスを作成するファンクションをCallする
        Call fncCombo_Create_FileType()         '出力リストコンボ
    End Sub
    Private Sub fncCombo_Create_FileType()
        '//出力リスト
        Dim objlistKIKAN As System.Web.UI.WebControls.DropDownList
        objlistKIKAN = CType(FindControl("listfiletype"), System.Web.UI.WebControls.DropDownList)
        objlistKIKAN.Items.Insert(0, New ListItem("1:一般消費者名簿", "1"))
        objlistKIKAN.Items.Insert(1, New ListItem("2:確認用リスト", "2"))
        objlistKIKAN.Items.Insert(2, New ListItem("3:すべて", "3"))
        objlistKIKAN.DataBind()

    End Sub

    '******************************************************************************
    ' Excel出力(チェックつき)
    '******************************************************************************
    Private Sub btnSelect_ServerClick(ByVal sender As System.Object,
                                    ByVal e As System.EventArgs) Handles btnSelect.ServerClick
        Dim strRec As String
        Dim SBMEOJAG00C As New SBMEOJAG00SBMEOJAW00.SBMEOJAW00

        '//　認証クラスのインスタンス生成
        AuthC = New CAuthenticate(Request, Response)


        Dim strRecMsg As String = ""
        Dim strNENDO As String
        Dim strKEN As String
        Dim strKURACDFrom As String
        Dim strKURACDTo As String
        Dim strHANTENCDFrom As String
        Dim strHANTENCDTo As String
        Dim strFileType As String

        strNENDO = txtNENDO.Text
        strKEN = txtKENCD.Text
        strKURACDFrom = hdnKURACD_From.Value
        strKURACDTo = hdnKURACD_To.Value
        strHANTENCDFrom = hdnHANTENCD_From.Value
        strHANTENCDTo = hdnHANTENCD_To.Value
        strFileType = Request.Form("listfiletype")


        strRec = SBMEOJAG00C.mExcel(
                         Me.Session.SessionID,
                         strNENDO,
                         strKEN,
                         strKURACDFrom,
                         strKURACDTo,
                         strHANTENCDFrom,
                         strHANTENCDTo,
                         strFileType
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

        ElseIf strRec.Substring(0, 9) = "NULLEXIST" Then
            '分類コードNULLのデータある場合
            strRecMsg = "分類コード不明のデータが存在します"
            strMsg.Append("alert('" & strRecMsg & "');")
            strMsg.Append("Form1.btnSelect.focus();")

        Else

            '「開く、保存」のダイヤログが出るようにHTTPヘッダに追加
            Select Case strFileType
                Case "1"
                    '一般消費者名簿
                    HttpHeaderC.mDownLoadXLS(Response, "一般消費者名簿.zip")

                Case "2"
                    '確認用リスト
                    HttpHeaderC.mDownLoadXLS(Response, "名簿基礎ファイル_確認用リスト.zip")

                Case "3"
                    'すべて
                    HttpHeaderC.mDownLoadXLS(Response, "名簿基礎ファイル_すべて.zip")

                Case Else
                    'それ以外なら、一般消費者名簿にしておく
                    HttpHeaderC.mDownLoadXLS(Response, "一般消費者名簿.zip")

            End Select


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

    '**********************************************************
    'ファイルアップロード
    '戻り値：書き込んだファイルへのフルパス
    '**********************************************************
    Private Function fncFileUpLoad() As String

        Dim uploadFile As HttpPostedFile
        Dim sSaveFileName As String
        Dim sSaveFileNameR As String
        Dim sSaveFileNameR2 As String '一部文字変換後
        Dim sSaveFileExt As String
        Dim sSavePath As String
        Dim sSaveFileKey As String 'ファイル保存時に頭に付けるキー（日時）
        Dim skipF As Boolean = False
        Dim fs As String()
        Dim strRes As String = "ERROR"

        Try
            uploadFile = Request.Files("FileUpload1")
            If (uploadFile.FileName <> "") Then

                'ファイル名を準備
                sSaveFileNameR = System.IO.Path.GetFileName(uploadFile.FileName)
                sSaveFileExt = System.IO.Path.GetExtension(uploadFile.FileName) '拡張子取得し、小文字へ変換
                sSaveFileExt = sSaveFileExt.ToLower

                sSaveFileKey = DateTime.Now.ToString("yyyyMMddHHmmss")
                sSaveFileNameR2 = sSaveFileNameR
                sSaveFileNameR2 = sSaveFileNameR2.Replace(" ", "") '半角スペースは除去
                sSaveFileName = sSaveFileKey & "_" & sSaveFileNameR2
                'sSavePath = "C:\inetpub\wwwroot\JPGAP\TEMP\00\SBMEOJAW00\"　　'取込ファイルの置き場所
                sSavePath = ConfigurationSettings.AppSettings("SBMEOJAW_PATH")

                mlog(sSavePath)

                '重複ファイルチェック
                fs = System.IO.Directory.GetFiles(sSavePath, sSaveFileName)   'folderにあるファイルを取得する
                If fs.Length >= 1 Then '既にファイルが登録されている？
                    strMsg.Append("alert('既にファイルが登録されています。[" & sSaveFileNameR & "]' );")
                    strMsg.Append("Form1.btnSelect.focus();")
                    skipF = True
                End If


                If skipF = False Then
                    '登録
                    uploadFile.SaveAs(sSavePath + sSaveFileName) 'ファイル保存！

                    strRes = sSavePath + sSaveFileName

                End If
            End If
        Catch ex As Exception
            strMsg.Append("alert('ファイルのアップロードに失敗しました。\nもう一度検索しなおしてください。');")
            strMsg.Append("Form1.btnSelect.focus();")
            strRes = "ERROR"
        Finally
        End Try

        Return strRes
    End Function

    '**********************************************************
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
                Dim outFile As New System.IO.StreamWriter(strPath, True, System.Text.Encoding.Default)

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

    '******************************************************************************
    '*　概　要：絞込み条件を渡すプロパティ
    '*　備　考：(クライアントコード)
    '******************************************************************************
    Public ReadOnly Property pCode1() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = AuthC.pAUTHCENTERCD
                Case "1"
                    strRec = AuthC.pAUTHCENTERCD
                Case "2"
                    strRec = AuthC.pAUTHCENTERCD
                Case "3"
                    strRec = AuthC.pAUTHCENTERCD
            End Select
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*　概　要：絞込み条件を渡すプロパティ
    '*　備　考：(クライアントコード)
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
                    strRec = hdnKURACD_From.Value.Trim
                Case "3"
                    'strRec = hdnKURACD_From.Value.Trim    '2019/11/01 T.Ono mod 監視改善2019
                    strRec = hdnKURACD_To.Value.Trim
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
            'strRec = "クライアント一覧"
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = "クライアント一覧"
                Case "1"
                    strRec = "クライアント一覧"
                Case "2"
                    strRec = "販売店グループ一覧"
                Case "3"
                    strRec = "販売店グループ一覧"
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
                    strRec = "CLI"
                Case "2"
                    strRec = "HANBAITEN"
                Case "3"
                    strRec = "HANBAITEN"
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
                    strRec = "hdnKURACD_From"
                Case "1"
                    strRec = "hdnKURACD_To"
                Case "2"
                    strRec = "hdnHANTENCD_From"
                Case "3"
                    strRec = "hdnHANTENCD_To"
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
                    strRec = "txtKURACD_From"
                Case "1"
                    strRec = "txtKURACD_To"
                Case "2"
                    strRec = "txtHANTENCD_From"
                Case "3"
                    strRec = "txtHANTENCD_To"
            End Select
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*　概　要：フォーカスを返すオブジェクトの名前値を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pBackFocs() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = "btnKURACD_From"
                Case "1"
                    strRec = "btnKURACD_To"
                Case "2"
                    strRec = "btnHANTENCD_From"
                Case "3"
                    strRec = "btnHANTENCD_To"
            End Select

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
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = "fncSetTo"
                Case "1"
                    strRec = ""
                Case "2"
                    strRec = "fncSetTo"
                Case "3"
                    strRec = ""
            End Select

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
                strRec = "txtHANTENCD_From"
            ElseIf hdnPopcrtl.Value = "1" Then
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
            If hdnPopcrtl.Value = "0" Then
                strRec = "hdnHANTENCD_From"
            ElseIf hdnPopcrtl.Value = "1" Then
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
            If hdnPopcrtl.Value = "0" Then
                strRec = "txtHANTENCD_To"
            ElseIf hdnPopcrtl.Value = "1" Then
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
            If hdnPopcrtl.Value = "0" Then
                strRec = "hdnHANTENCD_To"
            ElseIf hdnPopcrtl.Value = "1" Then
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


End Class
