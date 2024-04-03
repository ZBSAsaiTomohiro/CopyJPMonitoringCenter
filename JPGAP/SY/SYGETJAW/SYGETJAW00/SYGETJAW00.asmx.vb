'***********************************************
'月次データ整理
'***********************************************
Option Explicit On 
Option Strict On

Imports System.Web.Services
Imports System.Configuration

<System.Web.Services.WebService(Namespace:="http://tempuri.org/SYGETJAW00/Service1")> _
Public Class SYGETJAW00
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
        components = New System.ComponentModel.Container
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

    'EXE実行
    '******************************************************************************
    '*　概　要：EXEの実行
    '*　備　考：パラメータとして
    '*　　　　：１．対象日付
    '*　　　　：２．整理対象日付①
    '*　　　　：３．整理対象日付②
    '*　　　　：４．整理対象日付③
    '*　　　　：ー．ログキー
    '******************************************************************************
    'OK     : ＯＫ
    'else   : 実行エラー(catch内容)
    <WebMethod()> Public Function mExec( _
                                            ByVal pstrTrgDateM As String, _
                                            ByVal pstrTrgDate1 As String, _
                                            ByVal pstrTrgDate2 As String, _
                                            ByVal pstrTrgDate3 As String, _
                                            ByVal pstrDelmonth_ApLog As String, _
                                            ByVal pstrDelmonth_BatLog As String, _
                                            ByVal pstrDelmonth_TelLog As String, _
                                            ByVal pstrDelmonth_File As String, _
                                            ByVal pstrDelmonth_BackFile As String, _
                                            ByVal pDate As String, _
                                            ByVal pTime As String _
                                            ) As String
        Dim strRec As String
        strRec = "OK"

        Try
            'EXEを起動する-------------------------------
            '<< パラメータ >>
            Dim strAregs(11) As String

            strAregs(0) = pstrTrgDateM
            strAregs(1) = pstrTrgDate1
            strAregs(2) = pstrTrgDate2
            strAregs(3) = pstrTrgDate3
            strAregs(4) = pstrDelmonth_ApLog
            strAregs(5) = pstrDelmonth_BatLog
            strAregs(6) = pstrDelmonth_TelLog
            strAregs(7) = pstrDelmonth_File
            strAregs(8) = pstrDelmonth_BackFile
            strAregs(9) = pDate
            strAregs(10) = pTime

            Dim strAreg As String
            Dim intProc As Integer
            strAreg = Join(strAregs, ",")
            ' 2022/12/21 MOD START Y.ARAKAKI 2022更改No④ _データ整理画面の画面フリーズの解消対応
            ''2012/03/07 NEC Upd ou
            ''intProc = Shell(ConfigurationSettings.AppSettings("EXEPATH") & _
            ''                "BTGETJAE00.exe " & strAreg, _
            ''                AppWinStyle.Hide, False)
            'intProc = Shell(ConfigurationSettings.AppSettings("EXEPATH") &
            '    "BTGETJAE00.exe ",
            '    AppWinStyle.Hide, True)
            intProc = Shell(ConfigurationSettings.AppSettings("EXEPATH") &
                "BTGETJAE00.exe ",
                AppWinStyle.Hide, False)
            ' 2022/12/21 MOD END   Y.ARAKAKI 2022更改No④ _データ整理画面の画面フリーズの解消対応

        Catch ex As Exception
            'エラー内容を格納
            strRec = ex.ToString
        Finally
            '//
        End Try

        Return strRec

    End Function

End Class
