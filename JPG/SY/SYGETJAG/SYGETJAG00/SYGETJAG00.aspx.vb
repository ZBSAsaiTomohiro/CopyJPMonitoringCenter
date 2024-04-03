'***********************************************
'月次データ整理（メイン）
'***********************************************
'<TODO>宣言共通仕様
Option Explicit On
Option Strict On

'<TODO>宣言共通仕様
Imports Common          '：参照設定でCOCOMONC00を設定する
Imports JPG.Common
Imports System.Text     '：StringBuilderを使用するため

Partial Class SYGETJAG00
    Inherits System.Web.UI.Page
    Protected WithEvents txtDATE1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDATE2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDATE3 As System.Web.UI.WebControls.TextBox

    '<TODO>宣言共通仕様
    '******************************************************************************
    ' HttpHeader
    '******************************************************************************
    Protected HttpHeaderC As New CHttpHeader

    '<TODO>宣言共通仕様
    '******************************************************************************
    '認証クラス
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
        '//------------------------------------------
        '//　HTTPヘッダを送信
        HttpHeaderC.mNoCache(Response)

        '//------------------------------------------
        '//　認証クラスのインスタンス生成
        AuthC = New CAuthenticate(Request, Response)

        '//------------------------------------------
        '// Script書込み用変数宣言
        Dim strScript As New StringBuilder("")
        Dim cscript1 As New CScript
        Dim strScriptPath As String
        'Dim strDelmonth_Setai As String
        'Dim strDelmonth_Koji As String
        Dim strDelmonth_Keiho As String
        Dim strDelmonth_Taio As String

        Dim strDelmonth_Batlog As String '2007/11/29 T.Watabe add
        Dim strDelmonth_Aplog As String
        Dim strDelmonth_Tellog As String
        Dim strDelmonth_File As String
        Dim strDelmonth_Aplog_backfile As String
        Dim strDelmonth_Backfile As String
        Dim strDelmonth_AutoFaxLogDB As String '2016/12/27 T.Ono add 2016改善開発 №12 S05_AUTOFAXLOGDB
        Dim strDelmonth_AutoFaxTaiDB As String '2016/12/27 T.Ono add 2016改善開発 №12 S06_AUTOFAXTAIDB
        Dim strDelmonth_FaxOutBoxLog As String '2016/12/27 T.Ono add 2016改善開発 №12 S07_FAXOUTBOXLOG


        strScriptPath = ConfigurationSettings.AppSettings("SCRIPTPATH")
        'strDelmonth_Setai = ConfigurationSettings.AppSettings("DELMONTH_SETAI")
        'strDelmonth_Koji = ConfigurationSettings.AppSettings("DELMONTH_KOJI")
        strDelmonth_Keiho = ConfigurationSettings.AppSettings("DELMONTH_KEIHO")
        strDelmonth_Taio = ConfigurationSettings.AppSettings("DELMONTH_TAIO")

        strDelmonth_Batlog = ConfigurationSettings.AppSettings("DELMONTH_BATLOG") ' 2007/11/29 T.Watabe add
        strDelmonth_Aplog = ConfigurationSettings.AppSettings("DELMONTH_APLOG")
        strDelmonth_Tellog = ConfigurationSettings.AppSettings("DELMONTH_TELLOG")
        strDelmonth_File = ConfigurationSettings.AppSettings("DELMONTH_FILE")
        strDelmonth_Aplog_backfile = ConfigurationSettings.AppSettings("DELMONTH_APLOG_BACKFILE")
        strDelmonth_Backfile = ConfigurationSettings.AppSettings("DELMONTH_BACKFILE")
        strDelmonth_AutoFaxLogDB = ConfigurationSettings.AppSettings("DELMONTH_AUTOFAXLOGDB") '2016/12/27 T.Ono add 2016改善開発 №12
        strDelmonth_AutoFaxTaiDB = ConfigurationSettings.AppSettings("DELMONTH_AUTOFAXTAIDB") '2016/12/27 T.Ono add 2016改善開発 №12
        strDelmonth_FaxOutBoxLog = ConfigurationSettings.AppSettings("DELMONTH_FAXOUTBOXLOG") '2016/12/27 T.Ono add 2016改善開発 №12

        hdnDELMONTH_APLOG.Value = ConfigurationSettings.AppSettings("DELMONTH_APLOG")
        hdnDELMONTH_BATLOG.Value = ConfigurationSettings.AppSettings("DELMONTH_BATLOG")
        hdnDELMONTH_TELLOG.Value = ConfigurationSettings.AppSettings("DELMONTH_TELLOG")
        hdnDELMONTH_FILE.Value = ConfigurationSettings.AppSettings("DELMONTH_FILE")
        hdnDELMONTH_BACKFILE.Value = ConfigurationSettings.AppSettings("DELMONTH_BACKFILE")
        hdnDELMONTH_AUTOFAXLOGDB.Value = ConfigurationSettings.AppSettings("DELMONTH_AUTOFAXLOGDB") '2016/12/27 T.Ono add 2016改善開発 №12
        hdnDELMONTH_AUTOFAXTAIDB.Value = ConfigurationSettings.AppSettings("DELMONTH_AUTOFAXTAIDB") '2016/12/27 T.Ono add 2016改善開発 №12
        hdnDELMONTH_FAXOUTBOXLOG.Value = ConfigurationSettings.AppSettings("DELMONTH_FAXOUTBOXLOG") '2016/12/27 T.Ono add 2016改善開発 №12

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
             MyBase.MapPath("../../../SY/SYGETJAG/SYGETJAG00/") & "SYGETJAG00.js"))
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

        If MyBase.IsPostBack = False Then
            '//--------------------------------------
            '//　初めて開いた時だけ実行される
            Dim datDate As Date
            Dim strDateY As String = Format(Now, "yyyy")
            Dim strDateM As String = Format(Now, "MM")
            Dim strDateD As String = Format(Now, "dd")

            '初期表示する対象の日付をHiddenに格納(画面出力以外の対象データはこれよりデータ整理を行う)
            hdnTRGDATEM.Value = strDateY & strDateM & strDateD

            ''世帯主/利用者/対応/元気　の削除対象日付を出力
            'datDate = DateSerial(CInt(strDateY) - CInt(strDelmonth_Setai), CInt(strDateM), CInt(strDateD))
            ''--- ↓2005/04/23 DEL Falcon↓ ---
            ''txtDATE1.Text = strDelmonth_Setai
            ''--- ↑2005/04/23 DEL Falcon↑ ---
            'txtTRGDATE1.Text = Format(datDate, "yyyy/MM/dd")

            ''工事ＤＢの削除対象日付を出力
            'datDate = DateSerial(CInt(strDateY) - CInt(strDelmonth_Koji), CInt(strDateM), CInt(strDateD))
            ''--- ↓2005/04/23 DEL Falcon↓ ---
            ''txtDATE2.Text = strDelmonth_Koji
            ''--- ↑2005/04/23 DEL Falcon↑ ---
            'txtTRGDATE2.Text = Format(datDate, "yyyy/MM/dd")

            ''警報ＤＢの削除対象日付を出力
            'datDate = DateSerial(CInt(strDateY), CInt(strDateM) - CInt(strDelmonth_Keiho), CInt(strDateD))
            ''--- ↓2005/04/23 DEL Falcon↓ ---
            ''txtDATE3.Text = strDelmonth_Keiho
            ''--- ↑2005/04/23 DEL Falcon↑ ---
            'txtTRGDATE3.Text = Format(datDate, "yyyy/MM/dd")

            txtTRGDATE1.Text = Format(DateSerial(CInt(strDateY), CInt(strDateM) - CInt(strDelmonth_Keiho), CInt(strDateD)), "yyyy/MM/dd")
            txtTRGDATE2.Text = Format(DateSerial(CInt(strDateY) - CInt(strDelmonth_Taio), CInt(strDateM), CInt(strDateD)), "yyyy/MM/dd")
            '2012/06/08 NEC ou Upd Str
            'txtTRGDATE3.Text = Format(DateSerial(CInt(strDateY), CInt(strDateM) - CInt(strDelmonth_Batlog), CInt(strDateD)), "yyyy/MM/dd")
            txtTRGDATE3.Text = Format(DateSerial(CInt(strDateY) - CInt(strDelmonth_Batlog), CInt(strDateM), CInt(strDateD)), "yyyy/MM/dd")
            '2012/06/08 NEC ou Upd End
            txtTRGDATE4.Text = Format(DateSerial(CInt(strDateY), CInt(strDateM) - CInt(strDelmonth_Aplog), CInt(strDateD)), "yyyy/MM/dd")
            '2012/06/08 NEC ou Upd Str
            'txtTRGDATE5.Text = Format(DateSerial(CInt(strDateY), CInt(strDateM) - CInt(strDelmonth_Tellog), CInt(strDateD)), "yyyy/MM/dd")
            txtTRGDATE5.Text = Format(DateSerial(CInt(strDateY) - CInt(strDelmonth_Tellog), CInt(strDateM), CInt(strDateD)), "yyyy/MM/dd")
            '2012/06/08 NEC ou Upd End
            txtTRGDATE6.Text = Format(DateSerial(CInt(strDateY), CInt(strDateM) - CInt(strDelmonth_File), CInt(strDateD)), "yyyy/MM/dd")
            txtTRGDATE7.Text = Format(DateSerial(CInt(strDateY), CInt(strDateM) - CInt(strDelmonth_Aplog_backfile), CInt(strDateD)), "yyyy/MM/dd")
            txtTRGDATE8.Text = Format(DateSerial(CInt(strDateY), CInt(strDateM) - CInt(strDelmonth_Backfile), CInt(strDateD)), "yyyy/MM/dd")
            '2016/12/27 T.Ono add 2016改善開発 №12 START
            txtTRGDATE9.Text = Format(DateSerial(CInt(strDateY) - CInt(strDelmonth_AutoFaxLogDB), CInt(strDateM), CInt(strDateD)), "yyyy/MM/dd")
            txtTRGDATE10.Text = Format(DateSerial(CInt(strDateY) - CInt(strDelmonth_AutoFaxTaiDB), CInt(strDateM), CInt(strDateD)), "yyyy/MM/dd")
            txtTRGDATE11.Text = Format(DateSerial(CInt(strDateY) - CInt(strDelmonth_FaxOutBoxLog), CInt(strDateM), CInt(strDateD)), "yyyy/MM/dd")
            '2016/12/27 T.Ono add 2016改善開発 №12 END

            '//--------------------------------------------------------------------------
            'フォーカスをセットする
            strMsg.Append("Form1.btnJikkou.focus();")
        Else
            '//--------------------------------------
            '//　２回目以降実行される
            '//--------------------------------------
        End If

        '//-------------------------------------------------
        '<TODO>自分の画面IDをHIDDENのhdnMyAspxに書き込む（システム共通）
        hdnMyAspx.Value = "SYGETJAG00"
        '//-------------------------------------------------

    End Sub

    '******************************************************************************
    '*　概　要：パラメータ値より日付YYYYMMDD値を返す
    '*　備　考：
    '******************************************************************************
    Public Function fncDateGet(ByVal pstrDate As String) As String
        Dim DateFncC As New CDateFnc
        Dim strRec As String
        strRec = ""
        If pstrDate.Length = 10 Then    'YYYY/MM/DD
            strRec = DateFncC.mHenkanGet(pstrDate)
        End If

        Return strRec
    End Function

    '******************************************************************************
    '*　概　要：ＡＰログの削除期間を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pDelmonth_ApLog() As String
        Get
            Return hdnDELMONTH_APLOG.Value
        End Get
    End Property

    '******************************************************************************
    '*　概　要：バッチログの削除期間を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pDelmonth_BatLog() As String
        Get
            Return hdnDELMONTH_BATLOG.Value
        End Get
    End Property

    '******************************************************************************
    '*　概　要：電話発信ログの削除期間を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pDelmonth_TelLog() As String
        Get
            Return hdnDELMONTH_TELLOG.Value
        End Get
    End Property

    '******************************************************************************
    '*　概　要：一時ファイルの削除期間を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pDelmonth_File() As String
        Get
            Return hdnDELMONTH_FILE.Value
        End Get
    End Property

    '******************************************************************************
    '*　概　要：バックアップファイルの削除期間を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pDelmonth_BackFile() As String
        Get
            Return hdnDELMONTH_BACKFILE.Value
        End Get
    End Property

    '******************************************************************************
    '*　概　要：実行ボタン押下時の処理
    '*　備　考：
    '******************************************************************************
    Private Sub btnJikkou_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnJikkou.ServerClick
        Server.Transfer("SYGETJJG00.aspx")
    End Sub
End Class
