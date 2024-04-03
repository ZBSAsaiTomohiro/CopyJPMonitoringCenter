'***********************************************
'緊急時監視業務代行設定
'***********************************************
Option Explicit On 
Option Strict On

Imports System.Web.Services
Imports Common.DB
Imports System.Text

<System.Web.Services.WebService(Namespace:="http://tempuri.org/SYDIKJAW00/SYDIKJAW00")> _
Public Class SYDIKJAW00
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

    <WebMethod()> Public Function mSet( _
                                    ByVal pstrKANSCD As String, _
                                    ByVal pstrDAIKOKANSCD As String, _
                                    ByVal pstrMode As String) As String

        Dim ds As New DataSet
        Dim cdb As New cdb
        Dim strRes As String
        Dim strSQL As StringBuilder

        strRes = "OK"

        '接続OPEN----------------------------------------
        Try
            cdb.mOpen()
        Catch ex As Exception
            strRes = ex.ToString
            Return strRes
        Finally
        End Try

        Try
            Dim strDate As String = Now.ToString("yyyyMMdd")
            Dim strTime As String = Now.ToString("HHmmss")
            Dim pintKBN As Integer

            'トランザクション開始--------------------------
            cdb.mBeginTrans()

            'ＤＢチェック(基本)-----------------------------
            strSQL = New StringBuilder("")
            strSQL.Append("SELECT ")
            strSQL.Append(" EDT_DATE, ")                '更新日
            strSQL.Append(" TIME ")                     '更新時間
            strSQL.Append("FROM ")
            strSQL.Append("S01_DAIKO ")                 '代行設定
            strSQL.Append("WHERE KANSCD  =:KANSCD  ")
            strSQL.Append("FOR UPDATE NOWAIT ")         '排他制御をかける

            'SQL文セット
            cdb.pSQL = strSQL.ToString

            'パラメータに値をセット
            cdb.pSQLParamStr("KANSCD") = pstrKANSCD

            'SQL実行
            cdb.mExecQuery()
            ds = cdb.pResult

            If (ds.Tables(0).Rows.Count <> 0) Then
                '登録時に同一キーのデータが存在する時

                If pstrMode = "1" Then
                    pintKBN = 1     '代行設定　更新モード
                End If
            Else
                '登録時に同一キーのデータが存在しない時
                If pstrMode = "1" Then
                    pintKBN = 0     '代行設定　新規モード
                Else
                    strRes = "2"    '代行解除データなし
                    Exit Try
                End If
            End If

            '//代行設定モード
            If pstrMode = "1" Then
                If pintKBN = 1 Then
                    '世帯主ＤＢ更新
                    strSQL = New StringBuilder("")
                    strSQL.Append("UPDATE ")
                    strSQL.Append("S01_DAIKO DAI ")
                    strSQL.Append("SET ")
                    strSQL.Append("DAIKOKANSCD = :DAIKOKANSCD, ")
                    strSQL.Append("EDT_DATE = :EDT_DATE, ")
                    strSQL.Append("TIME = :TIME ")
                    strSQL.Append("WHERE KANSCD = :KANSCD ")
                Else
                    '新規登録時
                    strSQL = New StringBuilder("")
                    strSQL.Append("INSERT INTO ")
                    strSQL.Append("S01_DAIKO (")
                    strSQL.Append("KANSCD, ")
                    strSQL.Append("DAIKOKANSCD, ")
                    strSQL.Append("ADD_DATE, ")
                    strSQL.Append("TIME ")
                    strSQL.Append(") VALUES(")
                    strSQL.Append(":KANSCD, ")
                    strSQL.Append(":DAIKOKANSCD, ")
                    strSQL.Append(":ADD_DATE, ")
                    strSQL.Append(":TIME ")
                    strSQL.Append(")")
                End If
            Else
                '//代行解除モード
                strSQL = New StringBuilder("")
                strSQL.Append("DELETE ")
                strSQL.Append("FROM ")
                strSQL.Append("S01_DAIKO ")
                strSQL.Append("WHERE KANSCD = :KANSCD ")
            End If

            'SQL文セット
            cdb.pSQL = strSQL.ToString

            'バインド変数に値をセット

            '//代行設定モード
            If pstrMode = "1" Then

                If pintKBN = 1 Then
                    'UPDATE時
                    cdb.pSQLParamStr("EDT_DATE") = strDate
                Else
                    'INSERT時
                    cdb.pSQLParamStr("ADD_DATE") = strDate
                End If

                cdb.pSQLParamStr("DAIKOKANSCD") = pstrDAIKOKANSCD
                cdb.pSQLParamStr("TIME") = strTime
            End If
            cdb.pSQLParamStr("KANSCD") = pstrKANSCD

            'SQLを実行
            cdb.mExecNonQuery()
            'コミット
            cdb.mCommit()

        Catch ex As Exception
            'エラーが起きたら エラー内容を格納
            strRes = ex.ToString

            '排他制御処理エラー
            If ErrorToString.Substring(0, 9) = "ORA-00054" Then
                Return "3"
            End If

            'ロールバック
            cdb.mRollback()
            strRes = strRes & cdb.pErr
        Finally
            '接続クローズ
            cdb.mClose()
        End Try

        cdb = Nothing

        Return strRes
    End Function
End Class
