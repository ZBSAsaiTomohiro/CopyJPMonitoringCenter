Option Strict On

Imports System.Web.Services
Imports System.Configuration

<System.Web.Services.WebService(Namespace := "http://tempuri.org/JPGAP.COCOMONW00/CCONFIG")> _
Public Class CCONFIG
    Inherits System.Web.Services.WebService

#Region " Web サービス デザイナで生成されたコード "

    Public Sub New()
        MyBase.New()

        'この呼び出しは Web サービス デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後に独自の初期化コードを追加してください。

    End Sub

    'Web サービス デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ : 以下のプロシージャは、Web サービス デザイナで必要です。
    'Web サービス デザイナを使って変更することができます。  
    'コード エディタによる変更は行わないでください。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container()
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        'CODEGEN: このプロシージャは Web サービス デザイナで必要です。
        'コード エディタによる変更は行わないでください。
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

#End Region

    'ＤＢ接続ユーザー
    <WebMethod()> Public Function mGetConfigJPUID() As String
        Return ConfigurationSettings.AppSettings("JPUID")
    End Function

    'ＤＢ接続パスワード
    <WebMethod()> Public Function mGetConfigJPPWD() As String
        Return ConfigurationSettings.AppSettings("JPPWD")
    End Function

    'ＤＢ接続ＤＢ名
    <WebMethod()> Public Function mGetConfigJPDB() As String
        Return ConfigurationSettings.AppSettings("JPDB")
    End Function

    '対応ＤＢ削除対象期間
    <WebMethod()> Public Function mGetConfigDELMONTH_TAIO() As String
        Return ConfigurationSettings.AppSettings("DELMONTH_TAIO")
    End Function

    '警報ＤＢ削除対象期間
    <WebMethod()> Public Function mGetConfigDELMONTH_KEIHO() As String
        Return ConfigurationSettings.AppSettings("DELMONTH_KEIHO")
    End Function

    'ＡＰログＤＢ削除対象期間
    <WebMethod()> Public Function mGetConfigDELMONTH_APLOG() As String
        Return ConfigurationSettings.AppSettings("DELMONTH_APLOG")
    End Function

    'バッチログＤＢ削除対象期間
    <WebMethod()> Public Function mGetConfigDELMONTH_BATLOG() As String
        Return ConfigurationSettings.AppSettings("DELMONTH_BATLOG")
    End Function

    '電話ログＤＢ削除対象期間
    <WebMethod()> Public Function mGetConfigDELMONTH_TELLOG() As String
        Return ConfigurationSettings.AppSettings("DELMONTH_TELLOG")
    End Function

    '一時作成ファイル削除対象期間
    <WebMethod()> Public Function mGetConfigDELMONTH_FILE() As String
        Return ConfigurationSettings.AppSettings("DELMONTH_FILE")
    End Function

    'ＡＰログバックアップファイル削除対象期間
    <WebMethod()> Public Function mGetConfigDELMONTH_APLOG_BACKFILE() As String
        Return ConfigurationSettings.AppSettings("DELMONTH_APLOG_BACKFILE")
    End Function

    'バックアップファイル削除対象期間
    <WebMethod()> Public Function mGetConfigDELMONTH_BACKFILE() As String
        Return ConfigurationSettings.AppSettings("DELMONTH_BACKFILE")
    End Function

    '自動FAXログ削除対象期間 2016/12/27 T.Ono add 2016改善開発 №12
    <WebMethod()> Public Function mGetConfigDELMONTH_AUTOFAXLOGDB() As String
        Return ConfigurationSettings.AppSettings("DELMONTH_AUTOFAXLOGDB")
    End Function

    '自動FAX比較用対応ﾃﾞｰﾀ削除対象期間 2016/12/27 T.Ono add 2016改善開発 №12
    <WebMethod()> Public Function mGetConfigDELMONTH_AUTOFAXTAIDB() As String
        Return ConfigurationSettings.AppSettings("DELMONTH_AUTOFAXTAIDB")
    End Function

    'FAXサーバー送信ログ削除対象期間 2016/12/27 T.Ono add 2016改善開発 №12
    <WebMethod()> Public Function mGetConfigDELMONTH_FAXOUTBOXLOG() As String
        Return ConfigurationSettings.AppSettings("DELMONTH_FAXOUTBOXLOG")
    End Function

    'ログファイルパス
    <WebMethod()> Public Function mGetConfigLOGPATH() As String
        Return ConfigurationSettings.AppSettings("LOGPATH")
    End Function

    'EXCEL一時出力用フォルダパス
    <WebMethod()> Public Function mGetConfigEXCELPATH() As String
        Return ConfigurationSettings.AppSettings("EXCELPATH")
    End Function

    'テキストファイルパス
    <WebMethod()> Public Function mGetConfigTEXTPATH() As String
        Return ConfigurationSettings.AppSettings("TEXTPATH")
    End Function

    'ＡＰログバックアップファイル出力パス
    <WebMethod()> Public Function mGetConfigAPLOG_BACKPATH() As String
        Return ConfigurationSettings.AppSettings("APLOG_BACKPATH")
    End Function

    'バックアップファイル出力パス
    <WebMethod()> Public Function mGetConfigBACKPATH() As String
        Return ConfigurationSettings.AppSettings("BACKPATH")
    End Function

    'ＦＴＰパス
    <WebMethod()> Public Function mGetConfigFTPPATH() As String
        Return ConfigurationSettings.AppSettings("FTPPATH")
    End Function

    'ＥＸＥパス
    <WebMethod()> Public Function mGetConfigEXEPATH() As String
        Return ConfigurationSettings.AppSettings("EXEPATH")
    End Function
End Class
