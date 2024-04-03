'***********************************************
'供給センターマスタ
'***********************************************
' 変更履歴

Option Explicit On 
Option Strict On

Imports Common
Imports Common.DB

Imports System.Web.Services
Imports System.Text
Imports System.Configuration
Imports System.IO


<System.Web.Services.WebService(Namespace:="http://tempuri.org/MSTALJAW00/Service1")> _
Public Class MSTALJAW00
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

    'pintMODE
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
    ' ----------------------------------------------
    <WebMethod()> Public Function mSet( _
                                    ByVal pintMODE As Integer, _
                                    ByVal pstrKBN As String, _
                                    ByVal pstrKURACD As String, _
                                    ByVal pstrCODE As String, _
                                    ByVal pstrTANCD() As String, _
                                    ByVal pstrTANNM() As String, _
                                    ByVal pstrRENTEL1() As String, _
                                    ByVal pstrRENTEL2() As String, _
                                    ByVal pstrRENTEL3() As String, _
                                    ByVal pstrFAXNO() As String, _
                                    ByVal pstrDISP_NO() As String, _
                                    ByVal pstrBIKO() As String, _
                                    ByVal pstrDEL() As String, _
                                    ByVal pstrADD_DATE() As String, _
                                    ByVal pstrEDT_DATE() As String, _
                                    ByVal pstrTIME() As String) As String

        ' ------------------------------
        '配列を空で用意
        Dim strTANCD() As String
        strTANCD = New String(pstrTANCD.Length) {} '配列の実体を確保
        Dim strTANNM() As String
        strTANNM = New String(pstrTANNM.Length) {} '配列の実体を確保
        Dim strRENTEL1() As String
        strRENTEL1 = New String(pstrRENTEL1.Length) {} '配列の実体を確保
        Dim strRENTEL2() As String
        strRENTEL2 = New String(pstrRENTEL2.Length) {} '配列の実体を確保
        Dim strRENTEL3() As String
        strRENTEL3 = New String(pstrRENTEL3.Length) {} '配列の実体を確保
        Dim strFAXNO() As String
        strFAXNO = New String(pstrTANNM.Length) {} '配列の実体を確保
        Dim strDISP_NO() As String
        strDISP_NO = New String(pstrDISP_NO.Length) {} '配列の実体を確保
        Dim strBIKO() As String
        strBIKO = New String(pstrBIKO.Length) {} '配列の実体を確保
        Dim strDEL() As String
        strDEL = New String(pstrDEL.Length) {} '配列の実体を確保
        Dim strADD_DATE() As String
        strADD_DATE = New String(pstrADD_DATE.Length) {} '配列の実体を確保
        Dim strEDT_DATE() As String
        strEDT_DATE = New String(pstrEDT_DATE.Length) {} '配列の実体を確保
        Dim strTIME() As String
        strTIME = New String(pstrTIME.Length) {} '配列の実体を確保

        Dim i As Integer
        For i = 0 To strTANCD.Length
            strTANCD(i) = ""
            strTANNM(i) = ""
            strRENTEL1(i) = ""
            strRENTEL2(i) = ""
            strRENTEL3(i) = ""
            strFAXNO(i) = ""
            strDISP_NO(i) = ""
            strBIKO(i) = ""
            strDEL(i) = ""
            strADD_DATE(i) = ""
            strEDT_DATE(i) = ""
            strTIME(i) = ""
        Next
        ' ------------------------------

        Return mSetEx(pintMODE, _
                    pstrKBN, _
                    pstrKURACD, _
                    pstrCODE, _
                    pstrTANCD, _
                    pstrTANNM, _
                    pstrRENTEL1, _
                    pstrRENTEL2, _
                    pstrRENTEL3, _
                    pstrFAXNO, _
                    pstrDISP_NO, _
                    pstrBIKO, _
                    pstrDEL, _
                    pstrADD_DATE, _
                    pstrEDT_DATE, _
                    pstrTIME)
    End Function

    <WebMethod()> Public Function mSetEx( _
                                    ByVal pintMODE As Integer, _
                                    ByVal pstrKBN As String, _
                                    ByVal pstrKURACD As String, _
                                    ByVal pstrCODE As String, _
                                    ByVal pstrTANCD() As String, _
                                    ByVal pstrTANNM() As String, _
                                    ByVal pstrRENTEL1() As String, _
                                    ByVal pstrRENTEL2() As String, _
                                    ByVal pstrRENTEL3() As String, _
                                    ByVal pstrFAXNO() As String, _
                                    ByVal pstrDISP_NO() As String, _
                                    ByVal pstrBIKO() As String, _
                                    ByVal pstrDEL() As String, _
                                    ByVal pstrADD_DATE() As String, _
                                    ByVal pstrEDT_DATE() As String, _
                                    ByVal pstrTIME() As String) As String
        Dim ds As New DataSet
        Dim cdb As New CDB
        Dim strRes As String

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

            Dim i As Integer
            For i = 1 To 30 '30件を１件ずつ登録／修正／削除する。
                mlog("loop:" & pstrDEL(i) & pstrCODE & "_" & pstrTANCD(i))

                strRes = mSetTanto( _
                        cdb, _
                        pintMODE, _
                        pstrKBN, _
                        pstrKURACD, _
                        pstrCODE, _
                        pstrTANCD(i), _
                        pstrTANNM(i), _
                        pstrRENTEL1(i), _
                        pstrRENTEL2(i), _
                        pstrRENTEL3(i), _
                        pstrFAXNO(i), _
                        pstrDISP_NO(i), _
                        pstrBIKO(i), _
                        pstrDEL(i), _
                        pstrADD_DATE(i), _
                        pstrEDT_DATE(i), _
                        pstrTIME(i))

                If strRes <> "OK" Then
                    Exit For
                End If
            Next

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
    '担当者マスタ更新
    '************************************************
    <WebMethod()> Public Function mSetTanto( _
                                ByRef cdb As CDB, _
                                ByVal pintMODE As Integer, _
                                ByVal pstrKBN As String, _
                                ByVal pstrKURACD As String, _
                                ByVal pstrCODE As String, _
                                ByVal pstrTANCD As String, _
                                ByVal pstrTANNM As String, _
                                ByVal pstrRENTEL1 As String, _
                                ByVal pstrRENTEL2 As String, _
                                ByVal pstrRENTEL3 As String, _
                                ByVal pstrFAXNO As String, _
                                ByVal pstrDISP_NO As String, _
                                ByVal pstrBIKO As String, _
                                ByVal pstrDEL As String, _
                                ByVal pstrADD_DATE As String, _
                                ByVal pstrEDT_DATE As String, _
                                ByVal pstrTIME As String) As String
        Dim ds As New DataSet
        Dim strRes As String
        Dim strSQL As StringBuilder

        Dim tmp As String
        Dim strEDT_DT As String

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
            strSQL.Append("  DISP_NO, ")
            strSQL.Append("  TANCD, ")
            strSQL.Append("  TANNM, ")
            strSQL.Append("  RENTEL1, ")
            strSQL.Append("  RENTEL2, ")
            strSQL.Append("  RENTEL3, ")                     '電話番号３
            strSQL.Append("  FAXNO, ")
            strSQL.Append("  BIKO, ")
            strSQL.Append("  EDT_DATE, ")                    '更新日
            strSQL.Append("  TIME, ")                        '更新時間
            strSQL.Append("  AUTO_MAIL, ")                   '自動FAX送信メールアドレス
            strSQL.Append("  GUIDELINE, ")                   'JA注意事項
            strSQL.Append("  FAXKURAKBN, ")                  'FAX不要(ｸﾗｲｱﾝﾄ)区分
            strSQL.Append("  FAXKBN, ")                      'FAX不要(JA)区分
            strSQL.Append("  SPOT_MAIL, ")                   'SPOTメール追加
            strSQL.Append("  MAIL_PASS, ")                    'ﾒｰﾙﾊﾟｽﾜｰﾄﾞ追加
            strSQL.Append("  AUTO_MAIL_PASS, ")             '自動FAX添付ﾌｧｲﾙﾊﾟｽﾜｰﾄﾞ
            strSQL.Append("  AUTO_FAXNO, ")                 '自動FAX番号
            strSQL.Append("  AUTO_KBN, ")                   '自動送信区分
            strSQL.Append("  AUTO_ZERO_FLG, ")              'ゼロ件送信フラグ
            strSQL.Append("  AUTO_FAXNM ")                  '自動FAX送信名d
            strSQL.Append("FROM ")
            strSQL.Append("  M05_TANTO ")                    '担当者マスタ
            strSQL.Append("WHERE KBN  =:KBN  ")             '区分
            strSQL.Append("  AND KURACD =:KURACD ")         'クライアントコード（監視・出動はALL「Z」）
            strSQL.Append("  AND CODE =:CODE ")             'コード(監視センターコード／出動会社コード／ＪＡ支所コード)
            strSQL.Append("  AND TANCD = :TANCD ")            '担当者コード
            strSQL.Append("FOR UPDATE NOWAIT ")             '排他制御をかける

            'SQL文セット
            cdb.pSQL = strSQL.ToString

            'パラメータに値をセット
            cdb.pSQLParamStr("KBN") = pstrKBN               '区分 "2"固定
            cdb.pSQLParamStr("KURACD") = pstrKURACD         'クライアントコード "ZZZZ"固定
            cdb.pSQLParamStr("CODE") = pstrCODE             'コード（出動会社コード）
            cdb.pSQLParamStr("TANCD") = pstrTANCD           '担当者コード

            'SQL実行
            cdb.mExecQuery()
            ds = cdb.pResult

            '*******************************
            ' モードの再決定
            '*******************************
            If (ds.Tables(0).Rows.Count <> 0) Then 'ＤＢにデータが存在する？
                If pintMODE = 4 Then 'pintMODE=4(削除)
                    If pstrDEL = "true" Then '削除対象チェックあり？ 
                        pintMODE = 3 'モード＝3：削除
                    Else
                        pintMODE = 4 'モード＝4：スキップ
                    End If
                Else
                    pintMODE = 2 'モード＝2：更新
                End If
            Else
                If pstrTANCD = "" Then '登録元データはない？
                    pintMODE = 4 'モード＝4：スキップ
                ElseIf pstrDEL = "true" Then
                    pintMODE = 4 'モード＝4：スキップ
                    strRes = "0"
                Else
                    pintMODE = 1 'モード＝1：新規
                End If
            End If

            If (pintMODE = 3) Then 'ＤＢにデータが存在して、削除の場合
                '*******************************************
                '削除時で受け渡された日付及び時間と削除対象データが異なる場合エラー
                '*******************************************
                '*******************************************
                tmp = Convert.ToString(ds.Tables(0).Rows(0).Item("EDT_DATE")) & Convert.ToString(ds.Tables(0).Rows(0).Item("TIME"))
                strEDT_DT = pstrEDT_DATE & pstrTIME
                If (tmp <> strEDT_DT) Then
                    strRes = "0"
                    Exit Try
                End If
            End If

            If (pintMODE = 2) Then 'ＤＢにデータが存在して、更新の場合
                '*******************************************
                '修正時で受け渡された日付及び時間と更新対象データが異なる場合エラー
                '*******************************************
                tmp = Convert.ToString(ds.Tables(0).Rows(0).Item("EDT_DATE")) & Convert.ToString(ds.Tables(0).Rows(0).Item("TIME"))
                strEDT_DT = pstrEDT_DATE & pstrTIME
                If (tmp <> strEDT_DT) Then
                    strRes = "0"
                    Exit Try
                End If

                '*******************************************
                ' 修正時でデータが変更されていない場合はスキップ
                '*******************************************
                If ( _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("TANCD")) = pstrTANCD) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("TANNM")) = pstrTANNM) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("RENTEL1")) = pstrRENTEL1) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("RENTEL2")) = pstrRENTEL2) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("RENTEL3")) = pstrRENTEL3) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("FAXNO")) = pstrFAXNO) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("DISP_NO")) = pstrDISP_NO) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("BIKO")) = pstrBIKO) _
                     ) Then

                    pintMODE = 4 'スキップ
                End If
            End If

            If pintMODE = 4 Then
                'スキップ→次のレコード
                Exit Try
            End If

            'ＤＢチェック-----------------------------------
            '登録修正時、出動会社コードの存在チェックを行う
            If pintMODE = 1 OrElse pintMODE = 2 Then

                strSQL = New StringBuilder("")
                strSQL.Append("SELECT ")
                strSQL.Append(" SHUTU_CD ")                     '出動会社コード
                strSQL.Append("FROM ")
                strSQL.Append(" SHUTUDOMAS ")                   '出動会社マスタ
                strSQL.Append("WHERE ")
                strSQL.Append(" SHUTU_CD || KYOTEN_CD =:CODE ")  '出動会社コード＋拠点コード

                'SQL文セット
                cdb.pSQL = strSQL.ToString

                'パラメータに値をセット
                cdb.pSQLParamStr("CODE") = pstrCODE

                'SQL実行
                cdb.mExecQuery()
                ds = cdb.pResult

                If (ds.Tables(0).Rows.Count = 0) Then
                    '*******************************************
                    '監視センターコードが存在しない時
                    '*******************************************
                    strRes = "4"
                    Exit Try
                End If
            End If


            'データの更新処理--------------------------------

            If pintMODE = 3 Then
                '処理区分が削除
                strSQL = New StringBuilder("")
                strSQL.Append("DELETE ")
                strSQL.Append("FROM ")
                strSQL.Append("M05_TANTO ")                         '担当者マスタ
                strSQL.Append("WHERE KBN  =:KBN  ")                 '区分
                strSQL.Append("  AND KURACD =:KURACD ")             'クライアントコード
                strSQL.Append("  AND CODE =:CODE ")                 'コード
                strSQL.Append("  AND TANCD=:TANCD ")                '担当者コード

            ElseIf pintMODE = 2 Then
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
                strSQL.Append("RENTEL3 = :RENTEL3, ")               '電話番号３
                strSQL.Append("FAXNO = :FAXNO, ")
                strSQL.Append("DISP_NO = :DISP_NO, ")
                strSQL.Append("BIKO = :BIKO, ")
                strSQL.Append("ADD_DATE   = :ADD_DATE, ")
                strSQL.Append("EDT_DATE   = :EDT_DATE, ")
                strSQL.Append("TIME       = :TIME, ")
                strSQL.Append("AUTO_MAIL  = :AUTO_MAIL, ")          '自動FAX送信メールアドレス
                strSQL.Append("GUIDELINE  = :GUIDELINE, ")          'JA注意事項
                strSQL.Append("FAXKURAKBN  = :FAXKURAKBN, ")        'FAX不要(ｸﾗｲｱﾝﾄ)区分
                strSQL.Append("FAXKBN  = :FAXJAKBN, ")              'FAX不要(JA)区分
                strSQL.Append("SPOT_MAIL = :SPOT_MAIL, ")           'SPOTﾒｰﾙ追加
                strSQL.Append("MAIL_PASS  = :MAIL_PASS, ")          'ﾒｰﾙﾊﾟｽﾜｰﾄﾞ追加
                strSQL.Append("AUTO_MAIL_PASS = :AUTO_MAIL_PASS, ") '自動FAX添付ﾌｧｲﾙﾊﾟｽﾜｰﾄﾞ
                strSQL.Append("AUTO_FAXNO = :AUTO_FAXNO, ")         '自動FAX番号
                strSQL.Append("AUTO_KBN = :AUTO_KBN, ")             '自動送信区分
                strSQL.Append("AUTO_ZERO_FLG = :AUTO_ZERO_FLG, ")   'ゼロ件送信フラグ
                strSQL.Append("AUTO_FAXNM = :AUTO_FAXNM ")          '自動FAX送信名
                strSQL.Append("WHERE   ")
                strSQL.Append("      KBN    =:KBN  ")               '区分
                strSQL.Append("  AND KURACD =:KURACD ")             'クライアントコード
                strSQL.Append("  AND CODE   =:CODE ")               'コード
                strSQL.Append("  AND TANCD  =:TANCD ")              '担当者コード

            ElseIf pintMODE = 1 Then
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
                strSQL.Append("RENTEL3, ")          '電話番号３
                strSQL.Append("FAXNO, ")
                strSQL.Append("DISP_NO, ")
                strSQL.Append("BIKO, ")
                strSQL.Append("ADD_DATE, ")
                strSQL.Append("EDT_DATE, ")
                strSQL.Append("TIME, ")
                strSQL.Append("AUTO_MAIL, ")
                strSQL.Append("GUIDELINE, ")
                strSQL.Append("FAXKURAKBN, ")
                strSQL.Append("FAXKBN, ")
                strSQL.Append("SPOT_MAIL, ")
                strSQL.Append("MAIL_PASS, ")
                strSQL.Append("AUTO_MAIL_PASS, ")   '自動FAX添付ﾌｧｲﾙﾊﾟｽﾜｰﾄﾞ
                strSQL.Append("AUTO_FAXNO, ")       '自動FAX番号
                strSQL.Append("AUTO_KBN, ")         '自動送信区分
                strSQL.Append("AUTO_ZERO_FLG, ")    'ゼロ件送信フラグ
                strSQL.Append("AUTO_FAXNM ")        '自動FAX送信名
                strSQL.Append(") VALUES(")
                strSQL.Append(":KBN, ")
                strSQL.Append(":KURACD, ")
                strSQL.Append(":CODE, ")
                strSQL.Append(":TANCD, ")
                strSQL.Append(":TANNM, ")
                strSQL.Append(":RENTEL1, ")
                strSQL.Append(":RENTEL2, ")
                strSQL.Append(":RENTEL3, ")         '電話番号３
                strSQL.Append(":FAXNO, ")
                strSQL.Append(":DISP_NO, ")
                strSQL.Append(":BIKO, ")
                strSQL.Append(":ADD_DATE, ")
                strSQL.Append(":EDT_DATE, ")
                strSQL.Append(":TIME, ")
                strSQL.Append(":AUTO_MAIL, ")
                strSQL.Append(":GUIDELINE, ")
                strSQL.Append(":FAXKURAKBN, ")
                strSQL.Append(":FAXJAKBN, ")
                strSQL.Append(":SPOT_MAIL, ")
                strSQL.Append(":MAIL_PASS, ")
                strSQL.Append(":AUTO_MAIL_PASS, ")  '自動FAX添付ﾌｧｲﾙﾊﾟｽﾜｰﾄﾞ
                strSQL.Append(":AUTO_FAXNO, ")      '自動FAX番号
                strSQL.Append(":AUTO_KBN, ")        '自動送信区分
                strSQL.Append(":AUTO_ZERO_FLG, ")   'ゼロ件送信フラグ
                strSQL.Append(":AUTO_FAXNM ")       '自動FAX送信名
                strSQL.Append(")")
            End If

            'SQL文セット
            cdb.pSQL = strSQL.ToString
            'バインド変数に値をセット
            If pintMODE = 3 Then
                cdb.pSQLParamStr("KBN") = pstrKBN               '区分（1:監視センター担当者　2:出動会社担当者 3:JA支所担当者）
                cdb.pSQLParamStr("KURACD") = pstrKURACD         'クライアントコード
                cdb.pSQLParamStr("CODE") = pstrCODE             'コード
                cdb.pSQLParamStr("TANCD") = pstrTANCD           '担当者コード
            ElseIf pintMODE = 1 Or pintMODE = 2 Then

                cdb.pSQLParamStr("KBN") = pstrKBN               '区分（1:監視センター担当者　2:出動会社担当者 3:JA支所担当者）
                cdb.pSQLParamStr("KURACD") = pstrKURACD         'クライアントコード
                cdb.pSQLParamStr("CODE") = pstrCODE             'コード
                cdb.pSQLParamStr("TANCD") = pstrTANCD           '担当者コード
                cdb.pSQLParamStr("TANNM") = pstrTANNM           '担当者名
                cdb.pSQLParamStr("RENTEL1") = pstrRENTEL1       '連絡電話番号１
                cdb.pSQLParamStr("RENTEL2") = pstrRENTEL2       '連絡電話番号２
                cdb.pSQLParamStr("RENTEL3") = pstrRENTEL3       '連絡電話番号３
                cdb.pSQLParamStr("FAXNO") = pstrFAXNO           'FAX番号
                cdb.pSQLParamStr("DISP_NO") = pstrDISP_NO       '表示順序
                cdb.pSQLParamStr("BIKO") = pstrBIKO             '備考

                If pintMODE = 1 Then
                    '新規登録の場合
                    cdb.pSQLParamStr("ADD_DATE") = Now.ToString("yyyyMMdd")
                    cdb.pSQLParamStr("EDT_DATE") = ""
                Else
                    '修正登録の場合
                    cdb.pSQLParamStr("ADD_DATE") = pstrADD_DATE
                    cdb.pSQLParamStr("EDT_DATE") = Now.ToString("yyyyMMdd")
                End If
                cdb.pSQLParamStr("TIME") = Now.ToString("HHmmss")
                cdb.pSQLParamStr("AUTO_MAIL") = ""              '自動FAX送信メールアドレス
                cdb.pSQLParamStr("GUIDELINE") = ""              'JA注意事項
                cdb.pSQLParamStr("FAXKURAKBN") = ""             'FAX不要(ｸﾗｲｱﾝﾄ)区分
                cdb.pSQLParamStr("FAXJAKBN") = ""               'FAX不要(JA)区分
                cdb.pSQLParamStr("SPOT_MAIL") = ""              'SPOTﾒｰﾙ追加
                cdb.pSQLParamStr("MAIL_PASS") = ""              'ﾒｰﾙﾊﾟｽﾜｰﾄﾞ追加
                cdb.pSQLParamStr("AUTO_MAIL_PASS") = ""         '自動FAX添付ﾌｧｲﾙﾊﾟｽﾜｰﾄﾞ
                cdb.pSQLParamStr("AUTO_FAXNO") = ""             '自動FAX番号
                cdb.pSQLParamStr("AUTO_KBN") = ""               '自動送信区分
                cdb.pSQLParamStr("AUTO_ZERO_FLG") = ""          'ゼロ件送信フラグ
                cdb.pSQLParamStr("AUTO_FAXNM") = ""             '自動FAX番号

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
    '******************************************************************************
    '*　概　要:一覧の出力を行います
    '*　備　考:
    '******************************************************************************
    '　DATA0:対象データがありません
    <WebMethod()> Public Function mCSV( _
                                        ByVal pstrSessionID As String, _
                                        ByVal pstrCODE As String _
                                        ) As String

        Dim strSQL As New StringBuilder("")
        Dim cdb As New CDB
        Dim ds As New DataSet
        Dim dr As DataRow
        Dim CSVC As New CCSV                            'CSVクラス
        'Dim compressC As New CCompress                  '圧縮クラス
        'Dim DateFncC As New CDateFnc                    '日付変換クラス
        'Dim CTimeFncC As New CTimeFnc                   '時間変換クラス
        'Dim FileToStrC As New CFileStr                  'ファイルをBase64にエンコードするクラス

        '接続OPEN----------------------------------------
        Try
            cdb.mOpen()
        Catch ex As Exception
            Return ex.ToString
        Finally
        End Try
        Try
            strSQL = New StringBuilder("")
            strSQL.Append(" SELECT ")
            strSQL.Append(" 	A.CODE ")
            strSQL.Append(" 	,A.TANCD ")
            strSQL.Append(" 	,A.TANNM ")
            strSQL.Append(" 	,A.RENTEL1 ")
            strSQL.Append(" 	,A.RENTEL2 ")
            strSQL.Append(" 	,A.RENTEL3 ")
            strSQL.Append(" 	,A.FAXNO ")
            strSQL.Append(" 	,A.DISP_NO ")
            strSQL.Append(" 	,A.BIKO ")
            strSQL.Append(" 	,A.ADD_DATE ")
            strSQL.Append(" 	,A.EDT_DATE ")
            strSQL.Append(" 	,A.TIME ")
            strSQL.Append(" FROM  ")
            strSQL.Append(" 	M05_TANTO A ")
            strSQL.Append(" WHERE 1=1 ")
            strSQL.Append(" AND	A.KBN = '2' ")
            strSQL.Append(" AND	A.KURACD = 'ZZZZ' ")
            strSQL.Append(" AND	A.CODE = :CODE ")
            strSQL.Append(" ORDER BY TO_NUMBER(A.TANCD) ")
            'SQL文セット
            cdb.pSQL = strSQL.ToString

            'パラメータに値をセット
            '出動会社コード
            If pstrCODE.Length > 0 Then
                cdb.pSQLParamStr("CODE") = pstrCODE
            End If

            'SQL実行
            cdb.mExecQuery()
            ds = cdb.pResult

            'データが無い場合は終了
            If ds.Tables(0).Rows.Count = 0 Then
                Return "DATA0"
            End If

            CSVC.pKencd = "00"
            CSVC.pSessionID = pstrSessionID   'セッションID
            CSVC.pRepoID = "MSTALJAW00"       '帳票ID
            CSVC.mOpen()
            Dim iCnt As Integer
            Dim irCnt As Integer
            For iCnt = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(iCnt)

                If iCnt = 0 Then
                    CSVC.pColValStrEx = "出動会社コード＋拠点コード"
                    CSVC.pColValStrEx = "担当者コード"
                    CSVC.pColValStrEx = "担当者名"
                    CSVC.pColValStrEx = "電話番号１"
                    CSVC.pColValStrEx = "電話番号２"
                    CSVC.pColValStrEx = "電話番号３"
                    CSVC.pColValStrEx = "FAX番号"
                    CSVC.pColValStrEx = "表示順"
                    CSVC.pColValStrEx = "備考"
                    CSVC.pColValStrEx = "登録日"
                    CSVC.pColValStrEx = "更新日"
                    CSVC.pColValStrEx = "更新時間"
                    CSVC.mWriteLine()
                End If

                For irCnt = 0 To dr.Table.Columns.Count - 1
                    CSVC.pColValStrEx = Convert.ToString(dr.Item(irCnt))
                    'CSVC.pColVal = "=""" & Convert.ToString(dr.Item(irCnt)) & """"
                Next
                CSVC.mWriteLine()
            Next
            CSVC.mClose()
            Return CSVC.pDirName & CSVC.pFileName
        Catch ex As Exception
            'エラーの内容とＳＱＬ文を返す
            Return "ERROR:" & ex.ToString

        Finally
            cdb.mClose()        '接続クローズ
        End Try

    End Function
    '**********************************************************
    'ログ吐き出し
    '戻り値：書き込んだファイルへのフルパス
    '**********************************************************
    Public Sub mlog(ByVal pstrString As String)
        Dim strFilnm As String = "testKANSI" & System.DateTime.Today.ToString("yyyyMMdd")
        Dim strLogPath As String = ConfigurationSettings.AppSettings("LOG_OUT_PATH")
        Dim strPath As String = strLogPath & strFilnm & ".txt"
        Dim strLogFlg As String = ConfigurationSettings.AppSettings("LOG_OUT")
        If strLogFlg = "1" Then
            '書き込みファイルへのストリーム
            Dim outFile As New StreamWriter(strPath, True, System.Text.Encoding.Default)

            '引数の文字列をストリームに書き込み
            outFile.Write(System.DateTime.Now & ":[" & pstrString + "]" & vbCrLf)

            'メモリフラッシュ（ファイル書き込み）
            outFile.Flush()

            'ファイルクローズ
            outFile.Close()
        End If
    End Sub
End Class
