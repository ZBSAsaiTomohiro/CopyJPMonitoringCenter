'***********************************************
'担当者マスタ
'***********************************************
Option Explicit On 
Option Strict On

Imports Common.DB

Imports System.Web.Services
Imports System.Configuration
Imports System.text


<System.Web.Services.WebService(Namespace:="http://tempuri.org/SYHANJAW00/SYHANJAW00")> _
Public Class SYHANJAW00
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
    '*　　　　：１．対象年月
    '*　　　　：２．集計期間FROM
    '*　　　　：３．集計期間TO
    '******************************************************************************
    'OK     : ＯＫ
    'else   : 実行エラー(catch内容)
    <WebMethod()> Public Function mExec( _
                                        ByVal pstrKENCD As String, _
                                        ByVal pstrTRGDATE As String, _
                                        ByVal pstrSYUFROM As String, _
                                        ByVal pstrSYUTO As String, _
                                        ByVal pstrMOT_TRGDATE As String, _
                                        ByVal pstrMOT_SYUFROM As String _
                                        ) As String
        Dim strRec As String
        strRec = "OK"

        Dim ds As New DataSet
        Dim cdb As New cdb
        Dim strSQL As StringBuilder

        Dim strFLG As String

        '接続OPEN----------------------------------------
        Try
            cdb.mOpen()
        Catch ex As Exception
            strRec = ex.ToString
            Return strRec
        Finally
        End Try

        Try
            '//--------------------------------------------
            'トランザクション開始
            cdb.mBeginTrans()


            strSQL = New StringBuilder("")
            strSQL.Append("SELECT ")
            strSQL.Append(" NAME, ")                        '対象年月
            strSQL.Append(" NAIYO1, ")                      '集計期間FROM
            strSQL.Append(" NAIYO2 ")                       '集計期間TO
            strSQL.Append("FROM ")
            strSQL.Append("M06_PULLDOWN ")                  'プルダウンマスタ
            strSQL.Append("WHERE KBN  =:KBN  ")             '区分
            strSQL.Append("  AND CD =:KENCD ")              'コード(県コードで検索)
            strSQL.Append("FOR UPDATE NOWAIT ")             '排他制御をかける
            'SQL文セット
            cdb.pSQL = strSQL.ToString
            'パラメータに値をセット
            cdb.pSQLParamStr("KBN") = "56"                  '販売管理締情報
            cdb.pSQLParamStr("KENCD") = pstrKENCD
            'SQL実行
            cdb.mExecQuery()
            ds = cdb.pResult
            '登録時に同一キーのデータが存在する時
            If (ds.Tables(0).Rows.Count = 0) Then
                '存在しない場合は初回処理する
                strFLG = "1"
            Else
                If ( _
                    (Convert.ToString(ds.Tables(0).Rows(0).Item("NAME")) <> pstrMOT_TRGDATE) Or _
                    (Convert.ToString(ds.Tables(0).Rows(0).Item("NAIYO1")) <> pstrMOT_SYUFROM) _
                   ) Then
                    Return "0"
                    ''strRec = "他のユーザーによって既に処理が行われています。再度実行してください"
                End If
                strFLG = "2"
            End If


            '//--------------------------------------------
            'EXEを起動する
            '<< パラメータ >>
            Dim strAregs(6) As String

            strAregs(0) = pstrKENCD
            strAregs(1) = pstrTRGDATE
            strAregs(2) = pstrSYUFROM
            strAregs(3) = pstrSYUTO
            strAregs(4) = pstrMOT_TRGDATE
            strAregs(5) = pstrMOT_SYUFROM

            Dim strAreg As String
            Dim intProc As Integer
            strAreg = Join(strAregs, ",")
            intProc = Shell(ConfigurationSettings.AppSettings("EXEPATH") & _
                            "SYHANJAE00.exe " & strAreg, _
                            AppWinStyle.Hide, False)


            '//--------------------------------------------
            'プルダウンマスタの同じ県の、
            '対象年月・集計期間FROM・集計期間TOを更新する
            strSQL = New StringBuilder("")
            If strFLG = "1" Then
                strSQL.Append("INSERT INTO M06_PULLDOWN ")
                strSQL.Append("( ")
                strSQL.Append("KBN, ")
                strSQL.Append("CD, ")
                strSQL.Append("NAME, ")
                strSQL.Append("NAIYO1, ")
                strSQL.Append("NAIYO2, ")
                strSQL.Append("ADD_DATE, ")
                strSQL.Append("TIME ")
                strSQL.Append(") VALUES ( ")
                strSQL.Append(":KBN, ")
                strSQL.Append(":KENCD, ")
                strSQL.Append(":TRGDATE, ")
                strSQL.Append(":SYUFROM, ")
                strSQL.Append(":SYUTO, ")
                strSQL.Append(":SDATE, ")
                strSQL.Append(":TIME ")
                strSQL.Append(") ")
            Else
                strSQL.Append("UPDATE M06_PULLDOWN SET ")
                strSQL.Append("NAME   = :TRGDATE, ")
                strSQL.Append("NAIYO1 = :SYUFROM, ")
                strSQL.Append("NAIYO2 = :SYUTO, ")
                strSQL.Append("EDT_DATE = :SDATE, ")
                strSQL.Append("TIME = :TIME ")
                strSQL.Append("WHERE KBN =:KBN ")
                strSQL.Append("  AND CD =:KENCD ")
            End If
            'SQL文セット
            cdb.pSQL = strSQL.ToString
            'バインド変数に値をセット
            cdb.pSQLParamStr("KBN") = "56"
            cdb.pSQLParamStr("KENCD") = pstrKENCD
            cdb.pSQLParamStr("TRGDATE") = pstrTRGDATE
            cdb.pSQLParamStr("SYUFROM") = pstrSYUFROM
            cdb.pSQLParamStr("SYUTO") = pstrSYUTO
            cdb.pSQLParamStr("SDATE") = Now.ToString("yyyyMMdd")
            cdb.pSQLParamStr("TIME") = Now.ToString("HHmmss")
            'SQLを実行
            cdb.mExecNonQuery()

            'コミット
            cdb.mCommit()
        Catch ex As Exception
            'エラー内容を格納
            strRec = ex.ToString

            'ロールバック
            cdb.mRollback()
            strRec = strRec & cdb.pErr
        Finally
            '//
        End Try

        cdb = Nothing

        Return strRec

    End Function
End Class
