'***********************************************
'担当者マスタ
'***********************************************
Option Explicit On 
Option Strict On

Imports Common.DB

Imports System.Web.Services
Imports System.Text

<System.Web.Services.WebService(Namespace:="http://tempuri.org/MSTANJAW00/Service1")> _
Public Class MSTANJAW00
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
    '担当者マスタリストデータ取得
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
                                    ByVal pstrKURACD As String, _
                                    ByVal pstrCODE As String, _
                                    ByVal pstrTANCD As String, _
                                    ByVal pstrTANNM As String, _
                                    ByVal pstrRENTEL1 As String, _
                                    ByVal pstrRENTEL2 As String, _
                                    ByVal pstrFAXNO As String, _
                                    ByVal pstrDISP_NO As String, _
                                    ByVal pstrBIKO As String, _
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

            strRes = mSetTanto( _
                        cdb, _
                        pintKBN, _
                        pstrKBN, _
                        pstrKURACD, _
                        pstrCODE, _
                        pstrTANCD, _
                        pstrTANNM, _
                        pstrRENTEL1, _
                        pstrRENTEL2, _
                        pstrFAXNO, _
                        pstrDISP_NO, _
                        pstrBIKO, _
                        pstrADD_DATE, _
                        pstrEDT_DATE, _
                        pstrTIME)
            If strRes = "OK" Then
                'コミット
                cdb.mCommit()
            Else
                'ロールバック
                cdb.mRollback()
            End If

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
    '************************************************
    '担当者マスタ更新（対応入力画面からも使用）
    '************************************************
    <WebMethod()> Public Function mSetTanto( _
                                ByRef cdb As CDB, _
                                ByVal pintKBN As Integer, _
                                ByVal pstrKBN As String, _
                                ByVal pstrKURACD As String, _
                                ByVal pstrCODE As String, _
                                ByVal pstrTANCD As String, _
                                ByVal pstrTANNM As String, _
                                ByVal pstrRENTEL1 As String, _
                                ByVal pstrRENTEL2 As String, _
                                ByVal pstrFAXNO As String, _
                                ByVal pstrDISP_NO As String, _
                                ByVal pstrBIKO As String, _
                                ByVal pstrADD_DATE As String, _
                                ByVal pstrEDT_DATE As String, _
                                ByVal pstrTIME As String) As String
        Dim ds As New DataSet
        Dim strRes As String
        Dim strSQL As StringBuilder

        strRes = "OK"

        Try
            '*********************************
            '処理ストーリー
            '・排他のチェックを行う。
            '・登録時にはデータは未だ存在しないこと
            '・修正時にはデータは存在すること
            '・センターコードの存在チェックを行う
            '*********************************

            'ＤＢチェック(基本)-----------------------------
            strSQL = New StringBuilder("")
            strSQL.Append("SELECT ")
            strSQL.Append(" EDT_DATE, ")                    '更新日
            strSQL.Append(" TIME ")                         '更新時間
            strSQL.Append("FROM ")
            strSQL.Append("M05_TANTO ")                     '担当者マスタ
            strSQL.Append("WHERE KBN  =:KBN  ")             '区分
            '--- ↓2005/07/19 ADD Falcon↓ ---
            strSQL.Append("  AND KURACD =:KURACD ")         'クライアントコード（監視・出動はALL「Z」）
            '--- ↑2005/07/19 ADD Falcon↑ ---
            strSQL.Append("  AND CODE =:CODE ")             'コード(監視センターコード／出動会社コード／ＪＡ支所コード)
            strSQL.Append("  AND TANCD=:TANCD ")            '担当者コード
            strSQL.Append("FOR UPDATE NOWAIT ")             '排他制御をかける

            'SQL文セット
            cdb.pSQL = strSQL.ToString

            'パラメータに値をセット
            cdb.pSQLParamStr("KBN") = pstrKBN               '区分
            '--- ↓2005/07/19 ADD Falcon↓ ---
            cdb.pSQLParamStr("KURACD") = pstrKURACD         'クライアントコード
            '--- ↑2005/07/19 ADD Falcon↑ ---
            cdb.pSQLParamStr("CODE") = pstrCODE             'コード
            cdb.pSQLParamStr("TANCD") = pstrTANCD           '担当者コード

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

            'ＤＢチェック-----------------------------------
            '登録修正時、ＪＡ担当者の場合は、クライアントコードの存在チェックを行う
            If (pintKBN = 1 Or pintKBN = 2) And pstrKBN = "3" Then
                strSQL = New StringBuilder("")
                strSQL.Append("SELECT ")
                strSQL.Append(" CLI_CD ")                       'クライアントコード
                strSQL.Append("FROM ")
                strSQL.Append("CLIMAS ")                        'クライアントマスタ
                strSQL.Append("WHERE CLI_CD=:CLI_CD ")          'クライアントコード

                'SQL文セット
                cdb.pSQL = strSQL.ToString

                'パラメータに値をセット
                cdb.pSQLParamStr("CLI_CD") = pstrKURACD

                'SQL実行
                cdb.mExecQuery()
                ds = cdb.pResult

                If (ds.Tables(0).Rows.Count = 0) Then
                    '*******************************************
                    'クライアントコードが存在しない時
                    '*******************************************
                    strRes = "4"
                    Exit Try
                End If
            End If

            '登録修正時、ＪＡ担当者の場合は、コードをＪＡ支所コードとして存在チェックを行う
            If (pintKBN = 1 Or pintKBN = 2) And pstrKBN = "3" Then
                strSQL = New StringBuilder("")
                strSQL.Append("SELECT ")
                strSQL.Append(" HAN_CD ")                       'ＪＡ支所コード
                strSQL.Append("FROM ")
                strSQL.Append("HN2MAS ")                        'ＪＡ支所マスタ
                strSQL.Append("WHERE HAN_CD=:HAN_CD ")          'ＪＡ支所コード
                strSQL.Append("AND CLI_CD=:CLI_CD ")            'クライアントコード      '2012/05/24 NEC Add

                'SQL文セット
                cdb.pSQL = strSQL.ToString

                'パラメータに値をセット
                cdb.pSQLParamStr("HAN_CD") = pstrCODE
                cdb.pSQLParamStr("CLI_CD") = pstrKURACD                                 '2012/05/24 NEC Add

                'SQL実行
                cdb.mExecQuery()
                ds = cdb.pResult

                If (ds.Tables(0).Rows.Count = 0) Then
                    '*******************************************
                    'ＪＡ支所が存在しない時
                    '*******************************************
                    strRes = "5"
                    Exit Try
                End If
            End If

            '登録修正時、監視センター担当者の場合は、コードを監視センターコードとして存在チェックを行う
            If (pintKBN = 1 Or pintKBN = 2) And pstrKBN = "1" Then
                strSQL = New StringBuilder("")
                strSQL.Append("SELECT ")
                strSQL.Append(" KANSI_CD ")                     '監視センタコード
                strSQL.Append("FROM ")
                strSQL.Append("KANSIMAS ")                      '監視センタマスタ
                strSQL.Append("WHERE KANSI_CD=:KANSI_CD ")      '監視センタコード

                'SQL文セット
                cdb.pSQL = strSQL.ToString

                'パラメータに値をセット
                cdb.pSQLParamStr("KANSI_CD") = pstrCODE

                'SQL実行
                cdb.mExecQuery()
                ds = cdb.pResult

                If (ds.Tables(0).Rows.Count = 0) Then
                    '*******************************************
                    '監視センタが存在しない時
                    '*******************************************
                    strRes = "6"
                    Exit Try
                End If
            End If

            '登録修正時、出動会社担当者の場合は、コードを出動会社コードとして存在チェックを行う
            If (pintKBN = 1 Or pintKBN = 2) And pstrKBN = "2" Then
                strSQL = New StringBuilder("")
                strSQL.Append("SELECT ")
                strSQL.Append(" SHUTU_CD ")                     '出動会社コード
                strSQL.Append("FROM ")
                strSQL.Append("SHUTUDOMAS ")                    '出動会社マスタ
                '--- ↓2005/05/23 MOD Falcon↓ ---
                'strSQL.Append("WHERE SHUTU_CD=:SHUTU_CD ")      '出動会社コード
                strSQL.Append("WHERE SHUTU_CD || KYOTEN_CD =:SHUTU_CD ")      '出動会社コード＋拠点コード
                '--- ↑2005/05/23 MOD Falcon↑ ---

                'SQL文セット
                cdb.pSQL = strSQL.ToString

                'パラメータに値をセット
                cdb.pSQLParamStr("SHUTU_CD") = pstrCODE

                'SQL実行
                cdb.mExecQuery()
                ds = cdb.pResult

                If (ds.Tables(0).Rows.Count = 0) Then
                    '*******************************************
                    '出動会社が存在しない時
                    '*******************************************
                    strRes = "7"
                    Exit Try
                End If
            End If

            'データの更新処理--------------------------------
            If pintKBN = 3 Then
                '処理区分が削除
                strSQL = New StringBuilder("")
                strSQL.Append("DELETE ")
                strSQL.Append("FROM ")
                strSQL.Append("M05_TANTO ")                         '担当者マスタ
                strSQL.Append("WHERE KBN  =:KBN  ")                 '区分
                '--- ↓2005/07/19 ADD Falcon↓ ---
                strSQL.Append("  AND KURACD =:KURACD ")             'クライアントコード
                '--- ↑2005/07/19 ADD Falcon↑ ---
                strSQL.Append("  AND CODE =:CODE ")                 'コード
                strSQL.Append("  AND TANCD=:TANCD ")                '担当者コード

            ElseIf pintKBN = 2 Then
                '処理区分が修正
                strSQL = New StringBuilder("")
                strSQL.Append("UPDATE ")
                strSQL.Append("M05_TANTO ")
                strSQL.Append("SET ")
                strSQL.Append("KBN = :KBN, ")
                strSQL.Append("KURACD = :KURACD, ")
                strSQL.Append("CODE = :CODE, ")
                strSQL.Append("TANCD = :TANCD, ")
                strSQL.Append("TANNM = :TANNM, ")
                strSQL.Append("RENTEL1 = :RENTEL1, ")
                strSQL.Append("RENTEL2 = :RENTEL2, ")
                strSQL.Append("FAXNO = :FAXNO, ")
                strSQL.Append("DISP_NO = :DISP_NO, ")
                strSQL.Append("BIKO = :BIKO, ")
                strSQL.Append("ADD_DATE   = :ADD_DATE, ")
                strSQL.Append("EDT_DATE   = :EDT_DATE, ")
                strSQL.Append("TIME       = :TIME ")
                strSQL.Append("WHERE KBN  =:KBN  ")                 '区分
                '--- ↓2005/07/19 ADD Falcon↓ ---
                strSQL.Append("  AND KURACD =:KURACD ")             'クライアントコード
                '--- ↑2005/07/19 ADD Falcon↑ ---
                strSQL.Append("  AND CODE =:CODE ")                 'コード
                strSQL.Append("  AND TANCD=:TANCD ")                '担当者コード

            ElseIf pintKBN = 1 Then
                '処理区分が新規
                strSQL = New StringBuilder("")
                strSQL.Append("INSERT INTO ")
                strSQL.Append("M05_TANTO (")
                strSQL.Append("KBN, ")
                strSQL.Append("KURACD, ")
                strSQL.Append("CODE, ")
                strSQL.Append("TANCD, ")
                strSQL.Append("TANNM, ")
                strSQL.Append("RENTEL1, ")
                strSQL.Append("RENTEL2, ")
                strSQL.Append("FAXNO, ")
                strSQL.Append("DISP_NO, ")
                strSQL.Append("BIKO, ")
                strSQL.Append("ADD_DATE, ")
                strSQL.Append("EDT_DATE, ")
                strSQL.Append("TIME ")
                strSQL.Append(") VALUES(")
                strSQL.Append(":KBN, ")
                strSQL.Append(":KURACD, ")
                strSQL.Append(":CODE, ")
                strSQL.Append(":TANCD, ")
                strSQL.Append(":TANNM, ")
                strSQL.Append(":RENTEL1, ")
                strSQL.Append(":RENTEL2, ")
                strSQL.Append(":FAXNO, ")
                strSQL.Append(":DISP_NO, ")
                strSQL.Append(":BIKO, ")
                strSQL.Append(":ADD_DATE, ")
                strSQL.Append(":EDT_DATE, ")
                strSQL.Append(":TIME ")
                strSQL.Append(")")
            End If

            'SQL文セット
            cdb.pSQL = strSQL.ToString
            'バインド変数に値をセット
            If pintKBN = 3 Then
                cdb.pSQLParamStr("KBN") = pstrKBN               '区分（1:監視センター担当者　2:出動会社担当者 3:JA支所担当者）
                '--- ↓2005/07/19 ADD Falcon↓ ---
                cdb.pSQLParamStr("KURACD") = pstrKURACD         'クライアントコード
                '--- ↑2005/07/19 ADD Falcon↑ ---
                cdb.pSQLParamStr("CODE") = pstrCODE             'コード
                cdb.pSQLParamStr("TANCD") = pstrTANCD           '担当者コード
            ElseIf pintKBN = 1 Or pintKBN = 2 Then

                cdb.pSQLParamStr("KBN") = pstrKBN               '区分（1:監視センター担当者　2:出動会社担当者 3:JA支所担当者）
                cdb.pSQLParamStr("KURACD") = pstrKURACD         'クライアントコード
                cdb.pSQLParamStr("CODE") = pstrCODE             'コード
                cdb.pSQLParamStr("TANCD") = pstrTANCD           '担当者コード
                cdb.pSQLParamStr("TANNM") = pstrTANNM           '担当者名
                cdb.pSQLParamStr("RENTEL1") = pstrRENTEL1       '連絡電話番号１
                cdb.pSQLParamStr("RENTEL2") = pstrRENTEL2       '連絡電話番号２
                cdb.pSQLParamStr("FAXNO") = pstrFAXNO           'FAX番号
                cdb.pSQLParamStr("DISP_NO") = pstrDISP_NO       '表示順序
                cdb.pSQLParamStr("BIKO") = pstrBIKO             '備考

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

        Catch ex As Exception
            'エラーが起きたら エラー内容を格納
            strRes = ex.ToString

            '排他制御処理エラー
            If ErrorToString.Substring(0, 9) = "ORA-00054" Then
                Return "3"
            End If
            strRes = strRes & cdb.pErr
        Finally

        End Try

        Return strRes

    End Function
End Class