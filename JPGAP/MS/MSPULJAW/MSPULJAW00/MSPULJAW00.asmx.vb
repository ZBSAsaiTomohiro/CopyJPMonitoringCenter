Option Explicit On 
Option Strict On

Imports Common.DB

Imports System.Web.Services
Imports System.Text


<System.Web.Services.WebService(Namespace:="http://tempuri.org/MSPULJAW00/Service1")> _
Public Class MSPULJAW00
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

    'pintKBN
    '   1:新規登録
    '   2:修正登録
    '   3:削除
    '************************************************
    'プルダウン設定マスタリストデータ取得
    '************************************************
    '【共通】
    '  OK : 正常に終了しました
    '   0 : 他のユーザーによってデータが更新されています。再度検索してください
    '   1 : 既にデータが存在します
    '   2 : 対象データが存在しません
    '   3 : 排他制御処理でエラーが発生しました。再度実行してください

    <WebMethod()> Public Function mSet( _
                                    ByVal pintKBN As Integer, _
                                    ByVal pstrKBN As String, _
                                    ByVal pstrCD As String, _
                                    ByVal pstrNAME As String, _
                                    ByVal pstrNAIYO1 As String, _
                                    ByVal pstrNAIYO2 As String, _
                                    ByVal pstrDISP_NO As String, _
                                    ByVal pstrADD_DATE As String, _
                                    ByVal pstrEDT_DATE As String, _
                                    ByVal pstrTIME As String) As String
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
            'トランザクション開始--------------------------
            cdb.mBeginTrans()

            '*********************************
            '処理ストーリー
            '・排他のチェックを行う。
            '・登録時にはデータは未だ存在しないこと
            '・修正時にはデータは存在すること
            '*********************************

            'ＤＢチェック(基本)-----------------------------
            strSQL = New StringBuilder("")
            strSQL.Append("SELECT ")
            strSQL.Append(" EDT_DATE, ")            '更新日
            strSQL.Append(" TIME ")             '更新時間
            strSQL.Append("FROM ")
            strSQL.Append("M06_PULLDOWN ")          'プルダウンマスタ
            strSQL.Append("WHERE KBN  =:KBN  ")     '区分
            strSQL.Append("  AND CD =:CD ")         'コード
            strSQL.Append("FOR UPDATE NOWAIT ")     '排他制御をかける

            'SQL文セット
            cdb.pSQL = strSQL.ToString

            'パラメータに値をセット
            cdb.pSQLParamStr("KBN") = pstrKBN       '区分
            cdb.pSQLParamStr("CD") = pstrCD         'コード

            'SQL実行
            cdb.mExecQuery()
            ds = cdb.pResult

            '登録時に同一キーのデータが存在する時
            If (pintKBN = 1) And (ds.Tables(0).Rows.Count <> 0) Then
                '*******************************************
                '登録時に同じキーのデータが既に存在する場合はエラーとする
                '*******************************************
                strRes = "1"
                Exit Try
            Else
                If (pintKBN = 2) Then
                    '*******************************************
                    '修正時同じキーのデータが存在しない場合はエラーとする
                    '*******************************************
                    If (ds.Tables(0).Rows.Count = 0) Then
                        strRes = "2"
                        Exit Try
                    End If
                    '*******************************************
                    '修正時で受け渡された日付及び時間と更新対象データが異なる場合エラー
                    '*******************************************
                    If ((Convert.ToString(ds.Tables(0).Rows(0).Item("EDT_DATE")) <> pstrEDT_DATE) Or _
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("TIME")) <> pstrTIME)) Then
                        strRes = "0"
                        Exit Try
                    End If
                End If
            End If

            '登録修正時、プルダウン区分より区分の有無チェックを行なう
            If (pintKBN = 1 Or pintKBN = 2) Then
                strSQL = New StringBuilder("")
                strSQL.Append("SELECT ")
                strSQL.Append(" CD ")                  '区分
                strSQL.Append("FROM ")
                strSQL.Append("M06_PULLDOWN ")         'プルダウンマスタ
                strSQL.Append("WHERE KBN = '00' ")      '区分
                strSQL.Append("  AND CD = :CD ")        'コード

                'SQL文セット
                cdb.pSQL = strSQL.ToString

                'パラメータに値をセット
                cdb.pSQLParamStr("CD") = pstrKBN       '区分

                'SQL実行
                cdb.mExecQuery()
                ds = cdb.pResult

                If (ds.Tables(0).Rows.Count = 0) Then
                    '*******************************************
                    '区分が存在しない時
                    '*******************************************
                    strRes = "4"
                    Exit Try
                End If
            End If

            'データの更新処理--------------------------------
            If pintKBN = 3 Then
                '処理区分が削除
                strSQL = New StringBuilder("")
                strSQL.Append("DELETE ")
                strSQL.Append("FROM ")
                strSQL.Append("M06_PULLDOWN ")          'プルダウンマスタ
                strSQL.Append("WHERE KBN =:KBN  ")      '区分
                strSQL.Append("  AND CD =:CD ")         'コード

            ElseIf pintKBN = 2 Then
                '処理区分が修正
                strSQL = New StringBuilder("")
                strSQL.Append("UPDATE ")
                strSQL.Append("M06_PULLDOWN ")
                strSQL.Append("SET ")
                strSQL.Append("KBN =:KBN, ")
                strSQL.Append("CD =:CD, ")
                strSQL.Append("NAME =:NAME, ")
                strSQL.Append("NAIYO1 =:NAIYO1, ")
                strSQL.Append("NAIYO2 =:NAIYO2, ")
                strSQL.Append("DISP_NO =:DISP_NO, ")
                strSQL.Append("ADD_DATE    = :ADD_DATE, ")
                strSQL.Append("EDT_DATE    = :EDT_DATE, ")
                strSQL.Append("TIME     = :TIME ")
                strSQL.Append("WHERE KBN =:KBN  ")      '区分
                strSQL.Append("  AND CD =:CD ")         'コード

            ElseIf pintKBN = 1 Then
                '処理区分が新規
                strSQL = New StringBuilder("")
                strSQL.Append("INSERT INTO ")
                strSQL.Append("M06_PULLDOWN (")
                strSQL.Append("KBN, ")
                strSQL.Append("CD, ")
                strSQL.Append("NAME, ")
                strSQL.Append("NAIYO1, ")
                strSQL.Append("NAIYO2, ")
                strSQL.Append("DISP_NO, ")
                strSQL.Append("ADD_DATE, ")
                strSQL.Append("EDT_DATE, ")
                strSQL.Append("TIME ")
                strSQL.Append(") VALUES(")
                strSQL.Append(":KBN, ")
                strSQL.Append(":CD, ")
                strSQL.Append(":NAME, ")
                strSQL.Append(":NAIYO1, ")
                strSQL.Append(":NAIYO2, ")
                strSQL.Append(":DISP_NO, ")
                strSQL.Append(":ADD_DATE, ")
                strSQL.Append(":EDT_DATE, ")
                strSQL.Append(":TIME ")
                strSQL.Append(")")
            End If

            'SQL文セット
            cdb.pSQL = strSQL.ToString
            'バインド変数に値をセット
            If pintKBN = 3 Then
                cdb.pSQLParamStr("KBN") = pstrKBN                   '区分
                cdb.pSQLParamStr("CD") = pstrCD                     'コード
            ElseIf pintKBN = 1 Or pintKBN = 2 Then
                cdb.pSQLParamStr("KBN") = pstrKBN                   '区分
                cdb.pSQLParamStr("CD") = pstrCD                     'コード
                cdb.pSQLParamStr("NAME") = pstrNAME                 '名称
                cdb.pSQLParamStr("NAIYO1") = pstrNAIYO1             '内容１
                cdb.pSQLParamStr("NAIYO2") = pstrNAIYO2             '内容２
                cdb.pSQLParamStr("DISP_NO") = pstrDISP_NO           '表示順序
                If pintKBN = 1 Then
                    '新規登録の場合
                    cdb.pSQLParamStr("ADD_DATE") = Now.ToString("yyyyMMdd")
                    cdb.pSQLParamStr("EDT_DATE") = ""
                Else
                    '修正登録の場合
                    cdb.pSQLParamStr("ADD_DATE") = pstrADD_DATE
                    cdb.pSQLParamStr("EDT_DATE") = Now.ToString("yyyyMMdd")
                End If
                cdb.pSQLParamStr("TIME") = Now.ToString("HHmmss")

            End If
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