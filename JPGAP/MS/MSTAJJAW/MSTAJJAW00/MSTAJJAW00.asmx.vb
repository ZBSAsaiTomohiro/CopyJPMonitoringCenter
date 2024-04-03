'***********************************************
'担当者マスタ
'***********************************************
' 変更履歴
' 2010/04/14 T.Watabe 10件から30件に増加
' 2010/04/14 T.Watabe 印刷フラグを追加
' 2011/04/14 T.Watabe 自動FAX送信メールアドレス項目を追加
' 2011/11/08 H.Uema   JA注意事項項目を追加
' 2011/11/29 H.Uema   FAX不要(ｸﾗｲｱﾝﾄ)項目を追加
' 2011/12/01 H.Uema   FAX不要(JA)項目を追加
' 2012/03/23 W.GANEKO スポットメールアドレス項目追加
' 2013/05/23 T.Ono    顧客単位登録機能追加

Option Explicit On 
Option Strict On

Imports Common.DB

Imports System.Web.Services
Imports System.Text

<System.Web.Services.WebService(Namespace:="http://tempuri.org/MSTAJJAW00/Service1")> _
Public Class MSTAJJAW00
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
    ' 2011/04/14 T.Watabe add 既存のmSetと別にmSetExを作成
    ' 2011/11/08 H.Uema modify mSetExパラメータ変更に伴う修正(注意事項追加)
    ' 2011/11/29 H.Uema modify mSetExパラメータ変更に伴う修正(FAX不要(ｸﾗｲｱﾝﾄ)区分追加)
    ' 2011/12/01 H.Uema modify mSetExパラメータ変更に伴う修正(FAX不要(JA)区分追加)
    ' 2013/05/23 T.Ono modify 顧客単位登録機能追加 
    <WebMethod()> Public Function mSet( _
                                    ByVal pintMODE As Integer, _
                                    ByVal pstrKBN As String, _
                                    ByVal pstrKURACD As String, _
                                    ByVal pstrCODE As String, _
                                    ByVal pstrUSER_CD_FROM As String, _
                                    ByVal pstrUSER_CD_TO As String, _
                                    ByVal pstrTANCD() As String, _
                                    ByVal pstrTANNM() As String, _
                                    ByVal pstrRENTEL1() As String, _
                                    ByVal pstrRENTEL2() As String, _
                                    ByVal pstrRENTEL3() As String, _
                                    ByVal pstrFAXNO() As String, _
                                    ByVal pstrDISP_NO() As String, _
                                    ByVal pstrBIKO() As String, _
                                    ByVal pstrADD_DATE As String, _
                                    ByVal pstrEDT_DATE As String, _
                                    ByVal pstrTIME As String, _
                                    ByVal pstrEDT_DT() As String) As String

        ' ------------------------------
        ' strAUTO_MAIL配列を空で用意
        Dim strAUTO_MAIL() As String
        strAUTO_MAIL = New String(pstrTANCD.Length) {} '配列の実体を確保
        ' 2011/11/08 add H.Uema strGUIDELINE配列を空で用意
        Dim strGUIDELINE() As String
        strGUIDELINE = New String(pstrTANCD.Length) {} '配列の実態を確保
        ' 2011/11/29 add H.Uema strFAXKURAKBN配列を空で用意
        Dim strFAXKURAKBN() As String
        strFAXKURAKBN = New String(pstrTANCD.Length) {} '配列の実態を確保
        ' 2011/12/01 add H.Uema strFAXJAKBN配列を空で用意
        Dim strFAXJAKBN() As String
        strFAXJAKBN = New String(pstrTANCD.Length) {} '配列の実態を確保
        ' 2012/03/23 ADD W.GANEKO strSPOT_MAIL配列を空で用意
        Dim strSPOT_MAIL() As String
        strSPOT_MAIL = New String(pstrTANCD.Length) {} '配列の実体を確保
        ' 2012/03/23 ADD W.GANEKO strMAIL_PASS配列を空で用意
        Dim strMAIL_PASS() As String
        strMAIL_PASS = New String(pstrTANCD.Length) {} '配列の実体を確保
        ' 2012/05/23 ADD T.ONO pstrAUTO_MAIL_PASS配列を空で用意
        Dim pstrAUTO_MAIL_PASS() As String
        pstrAUTO_MAIL_PASS = New String(pstrTANCD.Length) {} '配列の実体を確保
        ' 2012/05/23 ADD T.ONO pstrAUTO_FAXNO配列を空で用意
        Dim pstrAUTO_FAXNO() As String
        pstrAUTO_FAXNO = New String(pstrTANCD.Length) {} '配列の実体を確保
        ' 2012/07/18 ADD T.ONO pstrAUTO_FAXNM配列を空で用意
        Dim pstrAUTO_FAXNM() As String
        pstrAUTO_FAXNM = New String(pstrTANCD.Length) {} '配列の実体を確保
        ' 2012/05/23 ADD T.ONO pstrAUTO_KBN配列を空で用意
        Dim pstrAUTO_KBN() As String
        pstrAUTO_KBN = New String(pstrTANCD.Length) {} '配列の実体を確保
        ' 2012/05/23 ADD T.ONO pstrAUTO_ZERO_FLG配列を空で用意
        Dim pstrAUTO_ZERO_FLG() As String
        pstrAUTO_ZERO_FLG = New String(pstrTANCD.Length) {} '配列の実体を確保
        Dim i As Integer
        For i = 0 To strAUTO_MAIL.Length
            strAUTO_MAIL(i) = ""
            strGUIDELINE(i) = ""
            strFAXKURAKBN(i) = ""
            strSPOT_MAIL(i) = ""
            strMAIL_PASS(i) = ""
            pstrAUTO_MAIL_PASS(i) = ""
            pstrAUTO_FAXNO(i) = ""
            pstrAUTO_FAXNM(i) = ""
            pstrAUTO_KBN(i) = ""
            pstrAUTO_ZERO_FLG(i) = ""
        Next
        ' ------------------------------

        Return mSetEx(pintMODE, _
                    pstrKBN, _
                    pstrKURACD, _
                    pstrCODE, _
                    pstrUSER_CD_FROM, _
                    pstrUSER_CD_TO, _
                    pstrTANCD, _
                    pstrTANNM, _
                    pstrRENTEL1, _
                    pstrRENTEL2, _
                    pstrRENTEL3, _
                    pstrFAXNO, _
                    pstrDISP_NO, _
                    pstrBIKO, _
                    pstrADD_DATE, _
                    pstrEDT_DATE, _
                    pstrTIME, _
                    pstrEDT_DT, _
                    strAUTO_MAIL, _
                    strGUIDELINE, _
                    strFAXKURAKBN, _
                    strFAXJAKBN, _
                    strSPOT_MAIL, _
                    strMAIL_PASS, _
                    pstrAUTO_MAIL_PASS, _
                    pstrAUTO_FAXNO, _
                    pstrAUTO_FAXNM, _
                    pstrAUTO_KBN, _
                    pstrAUTO_ZERO_FLG)
    End Function

    <WebMethod()> Public Function mSetEx( _
                                    ByVal pintMODE As Integer, _
                                    ByVal pstrKBN As String, _
                                    ByVal pstrKURACD As String, _
                                    ByVal pstrCODE As String, _
                                    ByVal pstrUSER_CD_FROM As String, _
                                    ByVal pstrUSER_CD_TO As String, _
                                    ByVal pstrTANCD() As String, _
                                    ByVal pstrTANNM() As String, _
                                    ByVal pstrRENTEL1() As String, _
                                    ByVal pstrRENTEL2() As String, _
                                    ByVal pstrRENTEL3() As String, _
                                    ByVal pstrFAXNO() As String, _
                                    ByVal pstrDISP_NO() As String, _
                                    ByVal pstrBIKO() As String, _
                                    ByVal pstrADD_DATE As String, _
                                    ByVal pstrEDT_DATE As String, _
                                    ByVal pstrTIME As String, _
                                    ByVal pstrEDT_DT() As String, _
                                    ByVal pstrAUTO_MAIL() As String, _
                                    ByVal pstrGUIDELINE() As String, _
                                    ByVal pstrFAXKURAKBN() As String, _
                                    ByVal pstrFAXJAKBN() As String, _
                                    ByVal pstrSPOT_MAIL() As String, _
                                    ByVal pstrMAIL_PASS() As String, _
                                    ByVal pstrAUTO_MAIL_PASS() As String, _
                                    ByVal pstrAUTO_FAXNO() As String, _
                                    ByVal pstrAUTO_FAXNM() As String, _
                                    ByVal pstrAUTO_KBN() As String, _
                                    ByVal pstrAUTO_ZERO_FLG() As String) As String
        Dim ds As New DataSet
        Dim cdb As New CDB
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

            Dim i As Integer
            'For i = 1 To 10 '10件を１件ずつ登録／修正／削除する。 ' 2010/04/14 T.Watabe edit
            For i = 1 To 30 '30件を１件ずつ登録／修正／削除する。
                '2011/04/14 T.Watabe add pstrAUTO_MAIL追加
                '2011/11/08 H.Uema add JA注意事項追加
                '2011/11/29 H.Uema add FAX不要(ｸﾗｲｱﾝﾄ)区分追加
                '2011/12/01 H.Uema add FAX不要(JA)区分追加
                '2012/03/23 W.GANEKO add SPOTメール追加
                '2013/05/23 T.Ono mod  顧客単位登録機能追加 処理分岐
                If pstrUSER_CD_FROM = "" Then
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
                            pstrADD_DATE, _
                            pstrEDT_DATE, _
                            pstrTIME, _
                            pstrEDT_DT(i), _
                            pstrAUTO_MAIL(i), _
                            pstrGUIDELINE(i), _
                            pstrFAXKURAKBN(i), _
                            pstrFAXJAKBN(i), _
                            pstrSPOT_MAIL(i), _
                            pstrMAIL_PASS(i), _
                            pstrAUTO_MAIL_PASS(i), _
                            pstrAUTO_FAXNO(i), _
                            pstrAUTO_FAXNM(i), _
                            pstrAUTO_KBN(i), _
                            pstrAUTO_ZERO_FLG(i))

                Else
                    strRes = mSetTanto2( _
                            cdb, _
                            pintMODE, _
                            pstrKBN, _
                            pstrKURACD, _
                            pstrCODE, _
                            pstrUSER_CD_FROM, _
                            pstrUSER_CD_TO, _
                            pstrTANCD(i), _
                            pstrTANNM(i), _
                            pstrRENTEL1(i), _
                            pstrRENTEL2(i), _
                            pstrRENTEL3(i), _
                            pstrFAXNO(i), _
                            pstrDISP_NO(i), _
                            pstrBIKO(i), _
                            pstrADD_DATE, _
                            pstrEDT_DATE, _
                            pstrTIME, _
                            pstrEDT_DT(i), _
                            pstrAUTO_MAIL(i), _
                            pstrGUIDELINE(i), _
                            pstrFAXKURAKBN(i), _
                            pstrFAXJAKBN(i), _
                            pstrSPOT_MAIL(i), _
                            pstrMAIL_PASS(i), _
                            pstrAUTO_MAIL_PASS(i), _
                            pstrAUTO_FAXNO(i), _
                            pstrAUTO_FAXNM(i), _
                            pstrAUTO_KBN(i), _
                            pstrAUTO_ZERO_FLG(i))
                End If


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
                                ByVal pstrADD_DATE As String, _
                                ByVal pstrEDT_DATE As String, _
                                ByVal pstrTIME As String, _
                                ByVal pstrEDT_DT As String, _
                                ByVal pstrAUTO_MAIL As String, _
                                ByVal pstrGUIDELINE As String, _
                                ByVal pstrFAXKURAKBN As String, _
                                ByVal pstrFAXJAKBN As String, _
                                ByVal pstrSPOT_MAIL As String, _
                                ByVal pstrMAIL_PASS As String, _
                                ByVal pstrAUTO_MAIL_PASS As String, _
                                ByVal pstrAUTO_FAXNO As String, _
                                ByVal pstrAUTO_FAXNM As String, _
                                ByVal pstrAUTO_KBN As String, _
                                ByVal pstrAUTO_ZERO_FLG As String) As String
        Dim ds As New DataSet
        Dim strRes As String
        Dim strSQL As StringBuilder

        Dim tmp As String

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
            strSQL.Append("  RENTEL3, ")                     '電話番号３ 2013/05/23 T.Ono add
            strSQL.Append("  FAXNO, ")
            strSQL.Append("  BIKO, ")
            strSQL.Append("  EDT_DATE, ")                    '更新日
            strSQL.Append("  TIME, ")                        '更新時間
            strSQL.Append("  AUTO_MAIL, ")                   '自動FAX送信メールアドレス 2011/04/14 T.Watabe add
            strSQL.Append("  GUIDELINE, ")                   'JA注意事項 2011/11/08 H.Uema add
            strSQL.Append("  FAXKURAKBN, ")                  'FAX不要(ｸﾗｲｱﾝﾄ)区分 2011/11/29 H.Uema add
            strSQL.Append("  FAXKBN, ")                      'FAX不要(JA)区分 2011/12/01 H.Uema add
            strSQL.Append("  SPOT_MAIL, ")                   'SPOTメール追加 2012/03/23 W.GANEKO add
            strSQL.Append("  MAIL_PASS, ")                    'ﾒｰﾙﾊﾟｽﾜｰﾄﾞ追加 2012/03/23 W.GANEKO add
            strSQL.Append("  AUTO_MAIL_PASS, ")             '自動FAX添付ﾌｧｲﾙﾊﾟｽﾜｰﾄﾞ 2013/05/23 T.Ono add
            strSQL.Append("  AUTO_FAXNO, ")                 '自動FAX番号 2013/05/23 T.Ono add
            strSQL.Append("  AUTO_KBN, ")                   '自動送信区分 2013/05/23 T.Ono add
            strSQL.Append("  AUTO_ZERO_FLG, ")              'ゼロ件送信フラグ 2013/05/23 T.Ono add
            strSQL.Append("  AUTO_FAXNM ")                  '自動FAX送信名 2013/07/22 T.Ono add
            strSQL.Append("FROM ")
            strSQL.Append("  M05_TANTO ")                    '担当者マスタ
            strSQL.Append("WHERE KBN  =:KBN  ")             '区分
            strSQL.Append("  AND KURACD =:KURACD ")         'クライアントコード（監視・出動はALL「Z」）
            strSQL.Append("  AND CODE =:CODE ")             'コード(監視センターコード／出動会社コード／ＪＡ支所コード)
            strSQL.Append("  AND LPAD(TANCD,2,'0') = :TANCD ")            '担当者コード
            strSQL.Append("FOR UPDATE NOWAIT ")             '排他制御をかける

            'SQL文セット
            cdb.pSQL = strSQL.ToString

            'パラメータに値をセット
            cdb.pSQLParamStr("KBN") = pstrKBN               '区分
            cdb.pSQLParamStr("KURACD") = pstrKURACD         'クライアントコード
            cdb.pSQLParamStr("CODE") = pstrCODE             'コード
            cdb.pSQLParamStr("TANCD") = pstrTANCD           '担当者コード

            'SQL実行
            cdb.mExecQuery()
            ds = cdb.pResult

            '*******************************
            ' モードの再決定
            '*******************************
            If (ds.Tables(0).Rows.Count <> 0) Then 'ＤＢにデータが存在する？
                If pstrTANNM = "" Then '登録元データはない？
                    pintMODE = 3 'モード＝3：削除
                Else
                    pintMODE = 2 'モード＝2：更新
                End If
            Else
                If pstrTANNM = "" Then '登録元データはない？
                    pintMODE = 4 'モード＝4：スキップ
                Else
                    pintMODE = 1 'モード＝1：新規
                End If
            End If

            If (pintMODE = 2) Then 'ＤＢにデータが存在して、更新の場合
                '*******************************************
                '修正時で受け渡された日付及び時間と更新対象データが異なる場合エラー
                '*******************************************
                tmp = Convert.ToString(ds.Tables(0).Rows(0).Item("EDT_DATE")) & Convert.ToString(ds.Tables(0).Rows(0).Item("TIME"))
                If (tmp <> pstrEDT_DT) Then
                    strRes = "0"
                    Exit Try
                End If

                '*******************************************
                ' 修正時でデータが変更されていない場合はスキップ
                '*******************************************
                '2011/04/14 T.Watabe edit pstrAUTO_MAIL記述追加
                '2011/11/08 H.Uema edit pstrGUIDELINE記述追加
                '2011/11/29 H.Uema edit pstrFAXKURAKBN記述追加
                '2011/12/01 H.Uema edit pstrFAXJAKBN記述追加
                '2012/03/23 W.GANEKO edit pstrSPOT_MAIL記述追加
                '2012/03/23 W.GANEKO edit pstrMAIL_PASS記述追加
                '2013/05/23 T.Ono edit 顧客単位登録機能追加
                If ( _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("DISP_NO")) = pstrDISP_NO) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("TANCD")) = pstrTANCD) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("TANNM")) = pstrTANNM) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("RENTEL1")) = pstrRENTEL1) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("RENTEL2")) = pstrRENTEL2) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("RENTEL3")) = pstrRENTEL3) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("FAXNO")) = pstrFAXNO) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("BIKO")) = pstrBIKO) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("AUTO_MAIL")) = pstrAUTO_MAIL) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("GUIDELINE")) = pstrGUIDELINE) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("FAXKURAKBN")) = pstrFAXKURAKBN) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("FAXKBN")) = pstrFAXJAKBN) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("SPOT_MAIL")) = pstrSPOT_MAIL) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("MAIL_PASS")) = pstrMAIL_PASS) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("AUTO_MAIL_PASS")) = pstrAUTO_MAIL_PASS) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("AUTO_FAXNO")) = pstrAUTO_FAXNO) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("AUTO_FAXNM")) = pstrAUTO_FAXNM) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("AUTO_KBN")) = pstrAUTO_KBN) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("AUTO_ZERO_FLG")) = pstrAUTO_ZERO_FLG) _
                     ) Then

                    pintMODE = 4 'スキップ
                End If
            End If

            If pintMODE = 4 Then
                'スキップ→次のレコード
                Exit Try
            End If

            'ＤＢチェック-----------------------------------
            '登録修正時、ＪＡ担当者の場合は、クライアントコードの存在チェックを行う
            If (pintMODE = 1 Or pintMODE = 2) And pstrKBN = "3" Then

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

            ' 2013/06/25 T.Ono del クライアントコードのみでの登録を許可するため、JA支所コードのチェック削除
            ''登録修正時、ＪＡ担当者の場合は、コードをＪＡ支所コードとして存在チェックを行う
            'If (pintMODE = 1 Or pintMODE = 2) And pstrKBN = "3" Then
            '    strSQL = New StringBuilder("")
            '    strSQL.Append("SELECT ")
            '    strSQL.Append(" HAN_CD ")                       'ＪＡ支所コード
            '    strSQL.Append("FROM ")
            '    strSQL.Append("HN2MAS ")                        'ＪＡ支所マスタ
            '    strSQL.Append("WHERE HAN_CD=:HAN_CD ")          'ＪＡ支所コード
            '    strSQL.Append("AND CLI_CD=:CLI_CD ")            'クライアントコード      '2012/05/24 NEC Add

            '    'SQL文セット
            '    cdb.pSQL = strSQL.ToString

            '    'パラメータに値をセット
            '    cdb.pSQLParamStr("HAN_CD") = pstrCODE
            '    cdb.pSQLParamStr("CLI_CD") = pstrKURACD                                 '2012/05/24 NEC Add

            '    'SQL実行
            '    cdb.mExecQuery()
            '    ds = cdb.pResult

            '    If (ds.Tables(0).Rows.Count = 0) Then
            '        '*******************************************
            '        'ＪＡ支所が存在しない時
            '        '*******************************************
            '        strRes = "5"
            '        Exit Try
            '    End If
            'End If



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
                strSQL.Append("  AND LPAD(TANCD,2,'0')=:TANCD ")                '担当者コード

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
                strSQL.Append("RENTEL3 = :RENTEL3, ")       '電話番号３ 2013/05/23 T.Ono add
                strSQL.Append("FAXNO = :FAXNO, ")
                strSQL.Append("DISP_NO = :DISP_NO, ")
                strSQL.Append("BIKO = :BIKO, ")
                strSQL.Append("ADD_DATE   = :ADD_DATE, ")
                strSQL.Append("EDT_DATE   = :EDT_DATE, ")
                strSQL.Append("TIME       = :TIME, ")
                strSQL.Append("AUTO_MAIL  = :AUTO_MAIL, ") '自動FAX送信メールアドレス 2011/04/14 T.Watabe add
                strSQL.Append("GUIDELINE  = :GUIDELINE, ") 'JA注意事項 2011/11/08 H.Uema add
                strSQL.Append("FAXKURAKBN  = :FAXKURAKBN, ") 'FAX不要(ｸﾗｲｱﾝﾄ)区分 2011/11/29 H.Uema add
                strSQL.Append("FAXKBN  = :FAXJAKBN, ")       'FAX不要(JA)区分 2011/12/01 H.Uema add
                strSQL.Append("SPOT_MAIL = :SPOT_MAIL, ")    'SPOTﾒｰﾙ追加 2012/03/23 W.GANEKO add
                strSQL.Append("MAIL_PASS  = :MAIL_PASS, ")       'ﾒｰﾙﾊﾟｽﾜｰﾄﾞ追加 2012/03/23 W.GANEKO add
                strSQL.Append("AUTO_MAIL_PASS = :AUTO_MAIL_PASS, ") '自動FAX添付ﾌｧｲﾙﾊﾟｽﾜｰﾄﾞ 2013/05/23 T.Ono add
                strSQL.Append("AUTO_FAXNO = :AUTO_FAXNO, ")         '自動FAX番号 2013/05/23 T.Ono add
                strSQL.Append("AUTO_KBN = :AUTO_KBN, ")             '自動送信区分 2013/05/23 T.Ono add
                strSQL.Append("AUTO_ZERO_FLG = :AUTO_ZERO_FLG, ")    'ゼロ件送信フラグ 2013/05/23 T.Ono add
                strSQL.Append("AUTO_FAXNM = :AUTO_FAXNM ")         '自動FAX送信名 2013/057/22 T.Ono add
                strSQL.Append("WHERE   ")
                strSQL.Append("      KBN    =:KBN  ")                 '区分
                strSQL.Append("  AND KURACD =:KURACD ")             'クライアントコード
                strSQL.Append("  AND CODE   =:CODE ")                 'コード
                strSQL.Append("  AND LPAD(TANCD,2,'0')=:TANCD ")                '担当者コード

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
                strSQL.Append("RENTEL3, ")  '電話番号３ 2013/05/23 T.Ono add
                strSQL.Append("FAXNO, ")
                strSQL.Append("DISP_NO, ")
                strSQL.Append("BIKO, ")
                strSQL.Append("ADD_DATE, ")
                strSQL.Append("EDT_DATE, ")
                strSQL.Append("TIME, ")
                strSQL.Append("AUTO_MAIL, ") '2011/04/14 T.Watabe add
                strSQL.Append("GUIDELINE, ") '2011/11/08 H.Uema add
                strSQL.Append("FAXKURAKBN, ") '2011/11/29 H.Uema add
                strSQL.Append("FAXKBN, ")   '2011/12/01 H.Uema add
                strSQL.Append("SPOT_MAIL, ")   '2012/03/23 W.GANEKO add
                strSQL.Append("MAIL_PASS, ")   '2012/03/23 W.GANEKO add
                strSQL.Append("AUTO_MAIL_PASS, ")   '自動FAX添付ﾌｧｲﾙﾊﾟｽﾜｰﾄﾞ 2013/05/23 T.Ono add
                strSQL.Append("AUTO_FAXNO, ")       '自動FAX番号 2013/05/23 T.Ono add
                strSQL.Append("AUTO_KBN, ")         '自動送信区分 2013/05/23 T.Ono add
                strSQL.Append("AUTO_ZERO_FLG, ")    'ゼロ件送信フラグ 2013/05/23 T.Ono add
                strSQL.Append("AUTO_FAXNM ")        '自動FAX送信名 2013/07/22 T.Ono add
                strSQL.Append(") VALUES(")
                strSQL.Append(":KBN, ")
                strSQL.Append(":KURACD, ")
                strSQL.Append(":CODE, ")
                'strSQL.Append(":TANCD, ")
                strSQL.Append("LPAD(:TANCD,2,'0'), ")
                strSQL.Append(":TANNM, ")
                strSQL.Append(":RENTEL1, ")
                strSQL.Append(":RENTEL2, ")
                strSQL.Append(":RENTEL3, ")  '電話番号３ 2013/05/23 T.Ono add
                strSQL.Append(":FAXNO, ")
                strSQL.Append(":DISP_NO, ")
                strSQL.Append(":BIKO, ")
                strSQL.Append(":ADD_DATE, ")
                strSQL.Append(":EDT_DATE, ")
                strSQL.Append(":TIME, ")
                strSQL.Append(":AUTO_MAIL, ") '2011/04/14 T.Watabe add
                strSQL.Append(":GUIDELINE, ") '2011/11/08 H.Uema add
                strSQL.Append(":FAXKURAKBN, ") '2011/11/29 H.Uema add
                strSQL.Append(":FAXJAKBN, ") '2011/12/01 H.Uema add
                strSQL.Append(":SPOT_MAIL, ") '2012/03/23 W.GANEKO add
                strSQL.Append(":MAIL_PASS, ") '2012/03/23 W.GANEKO add
                strSQL.Append(":AUTO_MAIL_PASS, ")  '自動FAX添付ﾌｧｲﾙﾊﾟｽﾜｰﾄﾞ 2013/05/23 T.Ono add
                strSQL.Append(":AUTO_FAXNO, ")      '自動FAX番号 2013/05/23 T.Ono add
                strSQL.Append(":AUTO_KBN, ")        '自動送信区分 2013/05/23 T.Ono add
                strSQL.Append(":AUTO_ZERO_FLG, ")   'ゼロ件送信フラグ 2013/05/23 T.Ono add
                strSQL.Append(":AUTO_FAXNM ")       '自動FAX送信名 2013/07/22 T.Ono add
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
                cdb.pSQLParamStr("RENTEL3") = pstrRENTEL3       '連絡電話番号３ 2013/05/23 T.Ono add
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
                cdb.pSQLParamStr("AUTO_MAIL") = pstrAUTO_MAIL             '自動FAX送信メールアドレス 2011/04/14 T.Watabe add
                cdb.pSQLParamStr("GUIDELINE") = pstrGUIDELINE             'JA注意事項 2011/11/08 H.Uema add
                cdb.pSQLParamStr("FAXKURAKBN") = pstrFAXKURAKBN           'FAX不要(ｸﾗｲｱﾝﾄ)区分 2011/11/29 H.Uema add
                cdb.pSQLParamStr("FAXJAKBN") = pstrFAXJAKBN               'FAX不要(JA)区分 2011/12/01 H.Uema add
                cdb.pSQLParamStr("SPOT_MAIL") = pstrSPOT_MAIL             'SPOTﾒｰﾙ追加 2012/03/23 W.GANEKO add
                cdb.pSQLParamStr("MAIL_PASS") = pstrMAIL_PASS             'ﾒｰﾙﾊﾟｽﾜｰﾄﾞ追加 2012/03/23 W.GANEKO add
                cdb.pSQLParamStr("AUTO_MAIL_PASS") = pstrAUTO_MAIL_PASS '自動FAX添付ﾌｧｲﾙﾊﾟｽﾜｰﾄﾞ 2013/05/23 T.Ono add
                cdb.pSQLParamStr("AUTO_FAXNO") = pstrAUTO_FAXNO         '自動FAX番号 2013/05/23 T.Ono add
                cdb.pSQLParamStr("AUTO_KBN") = pstrAUTO_KBN             '自動送信区分 2013/05/23 T.Ono add
                cdb.pSQLParamStr("AUTO_ZERO_FLG") = pstrAUTO_ZERO_FLG   'ゼロ件送信フラグ 2013/05/23 T.Ono add
                cdb.pSQLParamStr("AUTO_FAXNM") = pstrAUTO_FAXNM         '自動FAX番号 2013/07/22 T.Ono add

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

    '2013/05/24 T.Ono add  顧客単位登録機能追加
    '************************************************
    '担当者マスタ2更新
    '************************************************
    <WebMethod()> Public Function mSetTanto2( _
                                ByRef cdb As CDB, _
                                ByVal pintMODE As Integer, _
                                ByVal pstrKBN As String, _
                                ByVal pstrKURACD As String, _
                                ByVal pstrCODE As String, _
                                ByVal pstrUSER_CD_FROM As String, _
                                ByVal pstrUSER_CD_TO As String, _
                                ByVal pstrTANCD As String, _
                                ByVal pstrTANNM As String, _
                                ByVal pstrRENTEL1 As String, _
                                ByVal pstrRENTEL2 As String, _
                                ByVal pstrRENTEL3 As String, _
                                ByVal pstrFAXNO As String, _
                                ByVal pstrDISP_NO As String, _
                                ByVal pstrBIKO As String, _
                                ByVal pstrADD_DATE As String, _
                                ByVal pstrEDT_DATE As String, _
                                ByVal pstrTIME As String, _
                                ByVal pstrEDT_DT As String, _
                                ByVal pstrAUTO_MAIL As String, _
                                ByVal pstrGUIDELINE As String, _
                                ByVal pstrFAXKURAKBN As String, _
                                ByVal pstrFAXJAKBN As String, _
                                ByVal pstrSPOT_MAIL As String, _
                                ByVal pstrMAIL_PASS As String, _
                                ByVal pstrAUTO_MAIL_PASS As String, _
                                ByVal pstrAUTO_FAXNO As String, _
                                ByVal pstrAUTO_FAXNM As String, _
                                ByVal pstrAUTO_KBN As String, _
                                ByVal pstrAUTO_ZERO_FLG As String) As String
        Dim ds As New DataSet
        Dim strRes As String
        Dim strSQL As StringBuilder

        Dim tmp As String
        Dim modeKBN As Integer '0=お客様単体　1=お客様範囲

        strRes = "OK"

        If pstrUSER_CD_TO <> "" Then
            modeKBN = 1     'お客様範囲
        Else
            modeKBN = 0     'お客様単体
        End If

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
            strSQL.Append("  RENTEL3, ")                            '電話番号３
            strSQL.Append("  FAXNO, ")
            strSQL.Append("  BIKO, ")
            strSQL.Append("  EDT_DATE, ")                           '更新日
            strSQL.Append("  TIME, ")                               '更新時間
            strSQL.Append("  AUTO_MAIL, ")                          '自動FAX送信メールアドレス 
            strSQL.Append("  GUIDELINE, ")                          'JA注意事項
            strSQL.Append("  FAXKURAKBN, ")                         'FAX不要(ｸﾗｲｱﾝﾄ)区分
            strSQL.Append("  FAXKBN, ")                             'FAX不要(JA)区分
            strSQL.Append("  SPOT_MAIL, ")                          'SPOTメール追加
            strSQL.Append("  MAIL_PASS, ")                          'ﾒｰﾙﾊﾟｽﾜｰﾄﾞ追加
            strSQL.Append("  AUTO_MAIL_PASS, ")                     '自動FAX添付ﾌｧｲﾙﾊﾟｽﾜｰﾄﾞ
            strSQL.Append("  AUTO_FAXNO, ")                         '自動FAX番号
            strSQL.Append("  AUTO_KBN, ")                           '自動送信区分
            strSQL.Append("  AUTO_ZERO_FLG, ")                      'ゼロ件送信フラグ
            strSQL.Append("  AUTO_FAXNM ")                          '自動FAX送信名
            strSQL.Append("FROM ")
            strSQL.Append("  M05_TANTO2 ")                          '担当者マスタ2
            strSQL.Append("WHERE KBN  =:KBN  ")                     '区分
            strSQL.Append("  AND KURACD =:KURACD ")                 'クライアントコード（監視・出動はALL「Z」）
            strSQL.Append("  AND CODE =:CODE ")                     'コード(監視センターコード／出動会社コード／ＪＡ支所コード)
            strSQL.Append("  AND USER_CD_FROM =:USER_CD_FROM ")     'お客様コード_FROM
            If modeKBN = 1 Then
                strSQL.Append("  AND USER_CD_TO =:USER_CD_TO ")     'お客様コード_TO
            ElseIf modeKBN = 0 Then
                strSQL.Append("  AND USER_CD_TO Is Null ")          'お客様コード_TO
            End If
            strSQL.Append("  AND LPAD(TANCD,2,'0') = :TANCD ")      '担当者コード
            strSQL.Append("FOR UPDATE NOWAIT ")                     '排他制御をかける

            'SQL文セット
            cdb.pSQL = strSQL.ToString

            'パラメータに値をセット
            cdb.pSQLParamStr("KBN") = pstrKBN                       '区分
            cdb.pSQLParamStr("KURACD") = pstrKURACD                 'クライアントコード
            cdb.pSQLParamStr("CODE") = pstrCODE                     'コード
            cdb.pSQLParamStr("USER_CD_FROM") = pstrUSER_CD_FROM     'お客様コード_FROM
            If modeKBN = 1 Then
                cdb.pSQLParamStr("USER_CD_TO") = pstrUSER_CD_TO         'お客様コード_TO
            End If
            cdb.pSQLParamStr("TANCD") = pstrTANCD                   '担当者コード

            'SQL実行
            cdb.mExecQuery()
            ds = cdb.pResult

            '*******************************
            ' モードの再決定
            '*******************************
            If (ds.Tables(0).Rows.Count <> 0) Then 'ＤＢにデータが存在する？
                If pstrTANNM = "" Then '登録元データはない？
                    pintMODE = 3 'モード＝3：削除
                Else
                    pintMODE = 2 'モード＝2：更新
                End If
            Else
                If pstrTANNM = "" Then '登録元データはない？
                    pintMODE = 4 'モード＝4：スキップ
                Else
                    pintMODE = 1 'モード＝1：新規
                End If
            End If

            If (pintMODE = 2) Then 'ＤＢにデータが存在して、更新の場合
                '*******************************************
                '修正時で受け渡された日付及び時間と更新対象データが異なる場合エラー
                '*******************************************
                tmp = Convert.ToString(ds.Tables(0).Rows(0).Item("EDT_DATE")) & Convert.ToString(ds.Tables(0).Rows(0).Item("TIME"))
                If (tmp <> pstrEDT_DT) Then
                    strRes = "0"
                    Exit Try
                End If

                '*******************************************
                ' 修正時でデータが変更されていない場合はスキップ
                '*******************************************
                If ( _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("DISP_NO")) = pstrDISP_NO) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("TANCD")) = pstrTANCD) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("TANNM")) = pstrTANNM) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("RENTEL1")) = pstrRENTEL1) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("RENTEL2")) = pstrRENTEL2) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("RENTEL3")) = pstrRENTEL3) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("FAXNO")) = pstrFAXNO) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("BIKO")) = pstrBIKO) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("AUTO_MAIL")) = pstrAUTO_MAIL) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("GUIDELINE")) = pstrGUIDELINE) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("FAXKURAKBN")) = pstrFAXKURAKBN) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("FAXKBN")) = pstrFAXJAKBN) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("SPOT_MAIL")) = pstrSPOT_MAIL) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("MAIL_PASS")) = pstrMAIL_PASS) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("AUTO_MAIL_PASS")) = pstrAUTO_MAIL_PASS) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("AUTO_FAXNO")) = pstrAUTO_FAXNO) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("AUTO_FAXNM")) = pstrAUTO_FAXNM) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("AUTO_KBN")) = pstrAUTO_KBN) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("AUTO_ZERO_FLG")) = pstrAUTO_ZERO_FLG) _
                     ) Then

                    pintMODE = 4 'スキップ
                End If
            End If

            If pintMODE = 4 Then
                'スキップ→次のレコード
                Exit Try
            End If

            'ＤＢチェック-----------------------------------
            '登録修正時、ＪＡ担当者の場合は、クライアントコードの存在チェックを行う
            If (pintMODE = 1 Or pintMODE = 2) And pstrKBN = "3" Then

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
            If (pintMODE = 1 Or pintMODE = 2) And pstrKBN = "3" Then
                strSQL = New StringBuilder("")
                strSQL.Append("SELECT ")
                strSQL.Append(" HAN_CD ")                       'ＪＡ支所コード
                strSQL.Append("FROM ")
                strSQL.Append("HN2MAS ")                        'ＪＡ支所マスタ
                strSQL.Append("WHERE HAN_CD=:HAN_CD ")          'ＪＡ支所コード
                strSQL.Append("AND CLI_CD=:CLI_CD ")            'クライアントコード 

                'SQL文セット
                cdb.pSQL = strSQL.ToString

                'パラメータに値をセット
                cdb.pSQLParamStr("HAN_CD") = pstrCODE
                cdb.pSQLParamStr("CLI_CD") = pstrKURACD

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

            ' 主キーの重複をチェック
            If pintMODE = 1 Then
                If pstrTANCD = "01" OrElse pstrTANCD = "1" Then '1行目でのみ評価
                    strSQL = New StringBuilder("")
                    strSQL.Append("SELECT  ")
                    strSQL.Append("USER_CD_FROM ")
                    strSQL.Append("FROM ")
                    strSQL.Append("   M05_TANTO2 ")
                    strSQL.Append("WHERE  KURACD=:KURACD   ")
                    strSQL.Append("AND    CODE=:CODE   ")
                    strSQL.Append("AND    USER_CD_FROM = :USER_CD_FROM ")
                    'SQL文セット
                    cdb.pSQL = strSQL.ToString

                    'パラメータに値をセット
                    cdb.pSQLParamStr("KURACD") = pstrKURACD                 'クライアントコード
                    cdb.pSQLParamStr("CODE") = pstrCODE                     'コード
                    cdb.pSQLParamStr("USER_CD_FROM") = pstrUSER_CD_FROM     'お客様コード_FROM

                    'SQL実行
                    cdb.mExecQuery()
                    ds = cdb.pResult

                    If (ds.Tables(0).Rows.Count <> 0) Then
                        '*******************************************
                        '主キーの重複も範囲の重複とする
                        '*******************************************
                        strRes = "8"
                        Exit Try
                    End If
                End If
            End If

            ' お客様コードFrom～Toの重複をチェック
            If pintMODE = 1 AndAlso modeKBN = 1 Then
                If pstrTANCD = "01" OrElse pstrTANCD = "1" Then '1行目でのみ評価
                    strSQL = New StringBuilder("")
                    strSQL.Append("SELECT ")
                    strSQL.Append("   USER_CD_FROM ")
                    strSQL.Append("FROM ")
                    strSQL.Append("   M05_TANTO2 ")
                    strSQL.Append("WHERE  KURACD=:KURACD  ")
                    strSQL.Append("AND    CODE=:CODE  ")
                    strSQL.Append("AND    USER_CD_TO IS NOT NULL ")
                    strSQL.Append("AND    ( ")
                    strSQL.Append("        :USER_CD_FROM      between USER_CD_FROM and USER_CD_TO  ")
                    strSQL.Append("        OR  :USER_CD_TO    between USER_CD_FROM and USER_CD_TO  ")
                    strSQL.Append("        OR  USER_CD_FROM   between :USER_CD_FROM and :USER_CD_TO ")
                    strSQL.Append("       ) ")
                    'SQL文セット
                    cdb.pSQL = strSQL.ToString

                    'パラメータに値をセット
                    cdb.pSQLParamStr("KURACD") = pstrKURACD                 'クライアントコード
                    cdb.pSQLParamStr("CODE") = pstrCODE                     'コード
                    cdb.pSQLParamStr("USER_CD_FROM") = pstrUSER_CD_FROM     'お客様コード_FROM
                    cdb.pSQLParamStr("USER_CD_TO") = pstrUSER_CD_TO         'お客様コード_TO

                    'SQL実行
                    cdb.mExecQuery()
                    ds = cdb.pResult

                    If (ds.Tables(0).Rows.Count <> 0) Then
                        '*******************************************
                        '範囲の重複
                        '*******************************************
                        strRes = "8"
                        Exit Try
                    End If
                End If
            End If



            'データの更新処理--------------------------------

            If pintMODE = 3 Then
                '処理区分が削除
                strSQL = New StringBuilder("")
                strSQL.Append("DELETE ")
                strSQL.Append("FROM ")
                strSQL.Append("M05_TANTO2 ")                        '担当者マスタ２
                strSQL.Append("WHERE KBN  =:KBN  ")                 '区分
                strSQL.Append("  AND KURACD =:KURACD ")             'クライアントコード
                strSQL.Append("  AND CODE =:CODE ")                 'コード
                strSQL.Append("  AND USER_CD_FROM =:USER_CD_FROM ") 'お客様コード_FROM
                If modeKBN = 1 Then
                    strSQL.Append("  AND USER_CD_TO =:USER_CD_TO ") 'お客様コード_TO
                ElseIf modeKBN = 0 Then
                    strSQL.Append("  AND USER_CD_TO Is Null ")      'お客様コード_TO
                End If
                strSQL.Append("  AND LPAD(TANCD,2,'0')=:TANCD ")    '担当者コード

            ElseIf pintMODE = 2 Then
                '処理区分が修正
                strSQL = New StringBuilder("")
                strSQL.Append("UPDATE ")
                strSQL.Append("M05_TANTO2 ")
                strSQL.Append("SET ")
                strSQL.Append("KBN = :KBN, ")
                strSQL.Append("KURACD = :KURACD, ")
                strSQL.Append("CODE = :CODE, ")
                strSQL.Append("USER_CD_FROM = :USER_CD_FROM, ")         'お客様コード_FROM
                If modeKBN = 1 Then
                    strSQL.Append("USER_CD_TO = :USER_CD_TO, ")         'お客様コード_TO
                End If
                strSQL.Append("TANCD = :TANCD, ")
                strSQL.Append("TANNM = :TANNM, ")
                strSQL.Append("RENTEL1 = :RENTEL1, ")
                strSQL.Append("RENTEL2 = :RENTEL2, ")
                strSQL.Append("RENTEL3 = :RENTEL3, ")                   '電話番号３
                strSQL.Append("FAXNO = :FAXNO, ")
                strSQL.Append("DISP_NO = :DISP_NO, ")
                strSQL.Append("BIKO = :BIKO, ")
                strSQL.Append("ADD_DATE   = :ADD_DATE, ")
                strSQL.Append("EDT_DATE   = :EDT_DATE, ")
                strSQL.Append("TIME       = :TIME, ")
                strSQL.Append("AUTO_MAIL  = :AUTO_MAIL, ")              '自動FAX送信メールアドレス
                strSQL.Append("GUIDELINE  = :GUIDELINE, ")              'JA注意事項
                strSQL.Append("FAXKURAKBN  = :FAXKURAKBN, ")            'FAX不要(ｸﾗｲｱﾝﾄ)
                strSQL.Append("FAXKBN  = :FAXJAKBN, ")                  'FAX不要(JA)
                strSQL.Append("SPOT_MAIL = :SPOT_MAIL, ")               'SPOTﾒｰﾙ
                strSQL.Append("MAIL_PASS  = :MAIL_PASS, ")              'ﾒｰﾙﾊﾟｽﾜｰﾄﾞ 
                strSQL.Append("AUTO_MAIL_PASS = :AUTO_MAIL_PASS, ")     '自動FAX添付ﾌｧｲﾙﾊﾟｽﾜｰﾄﾞ 
                strSQL.Append("AUTO_FAXNO = :AUTO_FAXNO, ")             '自動FAX番号
                strSQL.Append("AUTO_KBN = :AUTO_KBN, ")                 '自動送信区分
                strSQL.Append("AUTO_ZERO_FLG = :AUTO_ZERO_FLG, ")       'ゼロ件送信フラグ  
                strSQL.Append("AUTO_FAXNM = :AUTO_FAXNM ")              '自動FAX送信名
                strSQL.Append("WHERE   ")
                strSQL.Append("      KBN    =:KBN  ")                   '区分
                strSQL.Append("  AND KURACD =:KURACD ")                 'クライアントコード
                strSQL.Append("  AND CODE   =:CODE ")                   'コード
                strSQL.Append("  AND USER_CD_FROM =:USER_CD_FROM ")     'お客様コード_FROM
                If modeKBN = 1 Then
                    strSQL.Append("  AND USER_CD_TO =:USER_CD_TO ")     'お客様コード_TO
                ElseIf modeKBN = 0 Then
                    strSQL.Append("  AND USER_CD_TO Is Null ")          'お客様コード_TO
                End If
                strSQL.Append("  AND LPAD(TANCD,2,'0')=:TANCD ")        '担当者コード

            ElseIf pintMODE = 1 Then
                '処理区分が新規
                strSQL = New StringBuilder("")
                strSQL.Append("INSERT INTO ")
                strSQL.Append("M05_TANTO2 (")
                strSQL.Append("KBN, ")
                strSQL.Append("KURACD, ")
                strSQL.Append("CODE, ")
                strSQL.Append("USER_CD_FROM, ")  'お客様コード_FROM
                strSQL.Append("USER_CD_TO, ")  'お客様コード_TO
                strSQL.Append("TANCD, ")
                strSQL.Append("TANNM, ")
                strSQL.Append("RENTEL1, ")
                strSQL.Append("RENTEL2, ")
                strSQL.Append("RENTEL3, ")  '電話番号３
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
                strSQL.Append(":USER_CD_FROM, ")    'お客様コード_FROM
                If modeKBN = 1 Then
                    strSQL.Append(":USER_CD_TO, ")  'お客様コード_TO
                ElseIf modeKBN = 0 Then
                    strSQL.Append(" Null, ")  'お客様コード_TO
                End If
                'strSQL.Append(":TANCD, ")
                strSQL.Append("LPAD(:TANCD,2,'0'), ")
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
                cdb.pSQLParamStr("KBN") = pstrKBN                       '区分（1:監視センター担当者　2:出動会社担当者 3:JA支所担当者）
                cdb.pSQLParamStr("KURACD") = pstrKURACD                 'クライアントコード
                cdb.pSQLParamStr("CODE") = pstrCODE                     'コード
                cdb.pSQLParamStr("USER_CD_FROM") = pstrUSER_CD_FROM     'お客様コード_FROM
                If modeKBN = 1 Then
                    cdb.pSQLParamStr("USER_CD_TO") = pstrUSER_CD_TO         'お客様コード_TO
                End If
                cdb.pSQLParamStr("TANCD") = pstrTANCD                   '担当者コード
            ElseIf pintMODE = 1 Or pintMODE = 2 Then

                cdb.pSQLParamStr("KBN") = pstrKBN                       '区分（1:監視センター担当者　2:出動会社担当者 3:JA支所担当者）
                cdb.pSQLParamStr("KURACD") = pstrKURACD                 'クライアントコード
                cdb.pSQLParamStr("CODE") = pstrCODE                     'コード
                cdb.pSQLParamStr("USER_CD_FROM") = pstrUSER_CD_FROM     'お客様コード_FROM
                If modeKBN = 1 Then
                    cdb.pSQLParamStr("USER_CD_TO") = pstrUSER_CD_TO     'お客様コード_TO
                End If
                cdb.pSQLParamStr("TANCD") = pstrTANCD                   '担当者コード
                cdb.pSQLParamStr("TANNM") = pstrTANNM                   '担当者名
                cdb.pSQLParamStr("RENTEL1") = pstrRENTEL1               '連絡電話番号１
                cdb.pSQLParamStr("RENTEL2") = pstrRENTEL2               '連絡電話番号２
                cdb.pSQLParamStr("RENTEL3") = pstrRENTEL3               '連絡電話番号３
                cdb.pSQLParamStr("FAXNO") = pstrFAXNO                   'FAX番号
                cdb.pSQLParamStr("DISP_NO") = pstrDISP_NO               '表示順序
                cdb.pSQLParamStr("BIKO") = pstrBIKO                     '備考

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
                cdb.pSQLParamStr("AUTO_MAIL") = pstrAUTO_MAIL             '自動FAX送信メールアドレス
                cdb.pSQLParamStr("GUIDELINE") = pstrGUIDELINE             'JA注意事項
                cdb.pSQLParamStr("FAXKURAKBN") = pstrFAXKURAKBN           'FAX不要(ｸﾗｲｱﾝﾄ)区分 
                cdb.pSQLParamStr("FAXJAKBN") = pstrFAXJAKBN               'FAX不要(JA)区分
                cdb.pSQLParamStr("SPOT_MAIL") = pstrSPOT_MAIL             'SPOTﾒｰﾙ追加
                cdb.pSQLParamStr("MAIL_PASS") = pstrMAIL_PASS             'ﾒｰﾙﾊﾟｽﾜｰﾄﾞ追加
                cdb.pSQLParamStr("AUTO_MAIL_PASS") = pstrAUTO_MAIL_PASS '自動FAX添付ﾌｧｲﾙﾊﾟｽﾜｰﾄﾞ
                cdb.pSQLParamStr("AUTO_FAXNO") = pstrAUTO_FAXNO         '自動FAX番号
                cdb.pSQLParamStr("AUTO_KBN") = pstrAUTO_KBN             '自動送信区分
                cdb.pSQLParamStr("AUTO_ZERO_FLG") = pstrAUTO_ZERO_FLG   'ゼロ件送信フラグ 
                cdb.pSQLParamStr("AUTO_FAXNM") = pstrAUTO_FAXNM         '自動FAX番号

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
