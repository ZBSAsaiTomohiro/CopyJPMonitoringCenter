'***********************************************
' 受託名簿取込
'***********************************************
' 変更履歴
' 2018/08/22 T.Ono
' 2019/11/01 T.Ono 監視改善2019 CSV取込、複数シート取込
' 

Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common
Imports JPG.Common.log

Imports System.Text

Partial Class SBMEIJAG00
    Inherits System.Web.UI.Page

    'ボタン

    'テキストボックス

    'コンボボックス

    'チェックボックス

    '非表示コントロール

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

    Dim strFilepath As String '選択したファイルパス

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
             MyBase.MapPath("../../../SB/SBMEIJAG/SBMEIJAG00/") & "SBMEIJAG00.js"))
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
            '年度を表示
            txtNENDO.Text = DateTime.Now.AddMonths(-3).ToString("yyyy")

            '//フォーカスをセットする
            strMsg.Append("Form1.rdoDATA1.focus();")
        Else
            '//--------------------------------------
            '//　２回目以降実行される
            '//--------------------------------------------------------------------------
            '//※画面表示するコンボボックスは各最終イベント/メソッドでCALLします
            '//--------------------------------------------------------------------------
            '<TODO>コンボボックス使用時、値選択のFunctionをCallする
            'Call fncSelectCombo()


        End If

        '//-------------------------------------------------
        '<TODO>自分の画面IDをHIDDENのhdnMyAspxに書き込む（システム共通）
        hdnMyAspx.Value = "SBMEIJAG00"
        '//-------------------------------------------------

    End Sub

    '******************************************************************************
    '* POSTデータの取得変数の初期化
    '******************************************************************************
    Private Sub fncGetPostIni()
        '//--------------------------------------------------------------------------
        ''<TODO>画面コントロール内容を格納した変数を初期化する
        ''//-----------------------------------------------

    End Sub

    '******************************************************************************
    '* HTTPPOSTデータ取得
    '******************************************************************************
    Private Sub fncGetPost()
        '//--------------------------------------------------------------------------
        '<TODO>画面コントロールの内容を変数に格納する
        '//     コンボボックスのXYZや日付の変換等はこの箇所で行う
    End Sub


    '******************************************************************************
    '* 実行ボタン押下
    '******************************************************************************
    Private Sub btnSelect_ServerClick(ByVal sender As System.Object,
                                    ByVal e As System.EventArgs) Handles btnSelect.ServerClick

        Try
            Dim strRes As String
            Dim SBMEIJAG00C As New SBMEIJAG00SBMEIJAW00.SBMEIJAW00
            Dim strDataType As String = "0" '出力ファイル　1=基礎ﾌｧｲﾙ　2=LTOSファイル
            Dim sfilepath As String = ""

            'タイムアウトの時間を設定（60分）
            SBMEIJAG00C.Timeout = 6000000


            '選択したファイルをサーバーにアップロード
            strRes = fncFileUpLoad()
            If strRes = "Error" Then
                strMsg.Append("alert('ファイルの読み込みに失敗しました。\nもう一度検索しなおしてください。');")
                strMsg.Append("Form1.btnSelect.focus();")
                Return
            Else
                sfilepath = strRes
            End If

            '取込データで処理を分ける
            If rdoDATA1.Checked = True Then
                strDataType = "1"
            ElseIf rdoDATA2.Checked = True Then
                strDataType = "2"
            Else
                'エラー ありえない'
            End If

            mlog(strDataType)

            If strDataType = "1" Then
                '名簿基礎ファイル
                '入力ファイル　必須項目のチェック
                '2019/11/01 T.Ono mod 監視改善2019
                'strRes = SBMEIJAG00C.mChkkisofile(strRes, "1")
                Select Case System.IO.Path.GetExtension(sfilepath).ToLower
                    Case ".xlsx", ".xls"
                        strRes = SBMEIJAG00C.mChkkisofile(strRes, "1")
                    Case ".csv"
                        strRes = SBMEIJAG00C.mChkkisofileCSV(strRes, "1")
                    Case Else
                        strRes = "拡張子はxlsxかxlsかcsvとしてください"
                End Select

                If strRes <> "OK" Then
                    strMsg.Append("alert('必須項目　事前チェック\n\n" & strRes & "');")
                    strMsg.Append("Form1.btnSelect.focus();")
                    Return
                End If


                '取込処理
                '2019/11/13 T.Ono mod 監視改善2019
                'strRes = SBMEIJAG00C.mReadkisofile(sfilepath, txtNENDO.Text, AuthC.pUSERNAME)
                Select Case System.IO.Path.GetExtension(sfilepath).ToLower
                    Case ".xlsx", ".xls"
                        strRes = SBMEIJAG00C.mReadkisofile(sfilepath, txtNENDO.Text, AuthC.pUSERNAME)
                    Case ".csv"
                        strRes = SBMEIJAG00C.mReadkisofileCSV(sfilepath, txtNENDO.Text, AuthC.pUSERNAME)
                    Case Else
                        strRes = "拡張子はxlsxかxlsかcsvとしてください"
                End Select

                If strRes = "OK" Then
                    strMsg.Append("alert('一般消費者名簿を更新しました');")
                    strMsg.Append("Form1.btnSelect.focus();")
                Else
                    strMsg.Append("alert('ファイルの読み込みに失敗しました。\n " & strRes & "');")
                    'strMsg.Append("alert('ファイルの読み込みに失敗しました\n管理者へご連絡ください');")
                    strMsg.Append("Form1.btnSelect.focus();")
                End If

            Else
                mlog("LTOS" & sfilepath)
                'LTOSファイル
                '入力ファイル　必須項目のチェック
                '2019/11/01 T.Ono mod 監視改善2019
                'strRes = SBMEIJAG00C.mChkLTOSfile(strRes, "1")
                Select Case System.IO.Path.GetExtension(sfilepath).ToLower
                    Case ".xlsx", ".xls"
                        mlog(".xlsx")
                        strRes = SBMEIJAG00C.mChkLTOSfile(strRes, "1")
                    Case ".csv"
                        mlog(".csv")
                        strRes = SBMEIJAG00C.mChkLTOSfileCSV(strRes, "1")
                    Case Else
                        strRes = "拡張子はxlsxかxlsかcsvとしてください"
                End Select

                If strRes <> "OK" Then
                    strMsg.Append("alert('必須項目　事前チェック\n\n" & strRes & "');")
                    strMsg.Append("Form1.btnSelect.focus();")
                    Return
                End If


                '取込処理
                '2019/11/01 T.Ono mod 監視改善2019
                'strRes = SBMEIJAG00C.mReadLTOSfile(sfilepath, txtNENDO.Text, AuthC.pUSERNAME)
                Select Case System.IO.Path.GetExtension(sfilepath).ToLower
                    Case ".xlsx", ".xls"
                        strRes = SBMEIJAG00C.mReadLTOSfile(sfilepath, txtNENDO.Text, AuthC.pUSERNAME)
                    Case ".csv"
                        strRes = SBMEIJAG00C.mReadLTOSfileCSV(sfilepath, txtNENDO.Text, AuthC.pUSERNAME)
                    Case Else
                        strRes = "拡張子はxlsxかxlsかcsvとしてください"
                End Select

                mlog(strRes)

                If strRes.Substring(0, 2) = "OK" Then
                    Dim strResArray As String()
                    strResArray = Split(strRes, ":")

                    mlog(strResArray(0) & ":" & strResArray(1) & ":" & strResArray(2))

                    If strResArray(1) = "0" Then
                        strMsg.Append("alert('更新対象はありませんでした');")
                        strMsg.Append("Form1.btnSelect.focus();")
                    Else
                        strMsg.Append("alert('一般消費者名簿を更新しました');")
                        strMsg.Append("Form1.btnSelect.focus();")
                    End If

                    'If strRes.Substring(0, 4) = "OK:0" Then
                    '    mlog("更新なし：" & strRes)
                    '    strMsg.Append("alert('更新対象はありませんでした');")
                    '    strMsg.Append("Form1.btnSelect.focus();")
                    'Else
                    '    mlog("更新あり：" & strRes)
                    '    strMsg.Append("alert('一般消費者名簿を更新しました');")
                    '    strMsg.Append("Form1.btnSelect.focus();")
                    'End If
                Else
                    strMsg.Append("alert('ファイルの読み込みに失敗しました。\n " & strRes & "');")
                    strMsg.Append("Form1.btnSelect.focus();")
                End If
            End If

        Catch ex As Exception
            mlog("システムエラー(btnFileUpload_Click)：" & ex.ToString)
            strMsg.Append("alert('ファイルの取込に失敗しました。\nもう一度検索しなおしてください。');")
            strMsg.Append("Form1.btnSelect.focus();")
        Finally
        End Try
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
                strFilepath = sSaveFileNameR '画面再表示用
                sSaveFileExt = System.IO.Path.GetExtension(uploadFile.FileName) '拡張子取得し、小文字へ変換
                sSaveFileExt = sSaveFileExt.ToLower

                sSaveFileKey = DateTime.Now.ToString("yyyyMMddHHmmss")
                sSaveFileNameR2 = sSaveFileNameR
                sSaveFileNameR2 = sSaveFileNameR2.Replace(" ", "") '半角スペースは除去
                sSaveFileName = sSaveFileKey & "_" & sSaveFileNameR2
                'sSavePath = "C:\inetpub\wwwroot\JPGAP\TEMP\00\SBMEIJAW00\"　　'取込ファイルの置き場所
                sSavePath = ConfigurationSettings.AppSettings("SBMEIJAW_PATH")



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
            strMsg.Append("alert('ファイルの読み込みに失敗しました。\nもう一度検索しなおしてください。');")
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
End Class
