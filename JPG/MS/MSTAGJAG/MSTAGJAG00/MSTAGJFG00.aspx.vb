'***********************************************
' JA担当者・連絡先・注意事項マスタ  ファイルダウンロード
'***********************************************
Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common
Imports JPG.Common.log

Imports System.Text

Partial Class MSTAGJFG00
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

        '//------------------------------------------------------------------------------
        If MyBase.IsPostBack = False Then
            '//--------------------------------------
            '//初めて開いた時だけ実行される
            fncFileDownload()

        Else
            '//--------------------------------------
            '//　２回目以降実行される
            '//--------------------------------------

        End If


    End Sub

    ' 2010/04/15 T.Watabe add
    '******************************************************************************
    '* ファイルダウンロード処理
    '******************************************************************************
    Private Sub fncFileDownload()

        Dim sw As System.IO.Stream = Nothing
        Dim bw As System.IO.BinaryWriter = Nothing
        Dim dt As Byte()
        Dim fpath As String
        Dim sSaveFileName As String

        Try
            'sSaveFileName = "test.txt"
            'sSaveFileName = "test.gif"
            sSaveFileName = "test.xls"

            fpath = ConfigurationSettings.AppSettings("JA_TAN_MST_PATH") & sSaveFileName

            'sw = System.IO.File.Open(fpath, System.IO.FileMode.Create, System.IO.FileAccess.Write) 'Streamでファイルを開く
            'bw = New System.IO.BinaryWriter(sw) 'StreamをBinaryWriterクラスで開く
            'bw.Write(dt) 'BinaryWriterクラスをバイト配列へ書き出す

            'HttpHeaderC.mDownLoad(Response, "test.txt")
            'Response.BinaryWrite(dt) 'バイト配列をレスポンスへ出力
            'Response.Flush()


            'Dim fs As New System.IO.FileStream(fpath, System.IO.FileMode.Open, System.IO.FileAccess.Read)
            ''If fs.Length > 0 Then
            'Dim br As New System.IO.BinaryReader(fs)
            '' Read data from Test.data.
            'dt = br.ReadBytes(CInt(fs.Length) - 1)
            'HttpHeaderC.mDownLoad(Response, "test.txt")
            'Response.BinaryWrite(dt) 'バイト配列をレスポンスへ出力
            'Response.Flush()
            'br.Close()
            ''End If
            'fs.Close()
            'Response.End()

            'Response.ContentType = "application/octet-stream-dummy"
            'Response.WriteFile(fpath)
            'Response.End()
            'Response.ContentType = "image/gif"


            If System.IO.File.Exists(fpath) Then
                Response.Clear()
                If False Then
                    HttpHeaderC.mDownLoad(Response, sSaveFileName)
                    'Response.AddHeader("Content-Disposition", "inline;filename=" & sSaveFileName)
                    Response.ContentType = "application/octet-stream-dummy"
                    Response.WriteFile(fpath)
                    Response.End()
                End If

                Dim FileToStrC As New CFileStr                  'ファイルをBase64にエンコードするクラス
                Dim compressC As New CCompress                  '圧縮クラス
                '圧縮先ファイルのあるフォルダ
                compressC.p_Dir = ConfigurationSettings.AppSettings("JA_TAN_MST_PATH")
                '日本語ファイル名の指定
                compressC.p_NihongoFileName = sSaveFileName
                '圧縮元ファイル名
                compressC.p_FileName = ConfigurationSettings.AppSettings("JA_TAN_MST_PATH") & sSaveFileName
                '圧縮先ファイル名
                compressC.p_madeFilename = ConfigurationSettings.AppSettings("JA_TAN_MST_PATH") & sSaveFileName & ".lzh"
                '圧縮実行
                compressC.mCompress()
                '圧縮したファイルをBase64エンコードして戻す
                Dim strRec As String = FileToStrC.mFileToStr(compressC.p_madeFilename.Replace(".lzh", ".exe"))
                'ファイル名は、HttpUtility.UrlEncodeメソッドを使用してSJISにエンコードする必要がある
                HttpHeaderC.mDownLoad(Response, "監視対応数集計表.exe")

                'Webサービスの戻り値（BASE64のテキスト）をバイトデータに変換する
                dt = Convert.FromBase64String(strRec)
                'ファイル送信
                Response.BinaryWrite(dt)



            Else
                strMsg.Append("alert('" & "対象データが存在しません" & "');")
                strMsg.Append("Form1.btnSelect.focus();")
            End If

            'Catch ex As Exception
            '    Throw ex
        Finally
            If bw Is Nothing = False Then bw.Close()
            If sw Is Nothing = False Then sw.Close()
        End Try
    End Sub
End Class
