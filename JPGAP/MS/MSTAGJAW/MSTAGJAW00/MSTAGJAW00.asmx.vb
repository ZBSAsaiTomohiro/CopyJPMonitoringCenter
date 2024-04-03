'***********************************************
'JA担当者・連絡先・注意事項マスタ
'***********************************************
' 変更履歴
' 2015/11/04 T.Ono    2015改善開発 新規作成

Option Explicit On 
Option Strict On

Imports Common.DB

Imports System.Web.Services
Imports System.Text


Imports System.Configuration
Imports System.IO

<System.Web.Services.WebService(Namespace:="http://tempuri.org/MSTAGJAW00/Service1")> _
Public Class MSTAGJAW00
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

        'Return mSetEx(pintMODE, _
        '            pstrKBN, _
        '            pstrKURACD, _
        '            pstrCODE, _
        '            pstrUSER_CD_FROM, _
        '            pstrUSER_CD_TO, _
        '            pstrTANCD, _
        '            pstrTANNM, _
        '            pstrRENTEL1, _
        '            pstrRENTEL2, _
        '            pstrRENTEL3, _
        '            pstrFAXNO, _
        '            pstrDISP_NO, _
        '            pstrBIKO, _
        '            pstrADD_DATE, _
        '            pstrEDT_DATE, _
        '            pstrTIME, _
        '            pstrEDT_DT, _
        '            strAUTO_MAIL, _
        '            strGUIDELINE, _
        '            strFAXKURAKBN, _
        '            strFAXJAKBN, _
        '            strSPOT_MAIL, _
        '            strMAIL_PASS, _
        '            pstrAUTO_MAIL_PASS, _
        '            pstrAUTO_FAXNO, _
        '            pstrAUTO_FAXNM, _
        '            pstrAUTO_KBN, _
        '            pstrAUTO_ZERO_FLG)
    End Function

    '2020/11/01 T.Ono mod 2020監視改善 pstrSD_PRT_FLG追加
    <WebMethod()> Public Function mSetEx(
                                    ByVal pintMODE As Integer,
                                    ByVal pstrDBKBN As String,
                                    ByVal pstrGROUPCD As String,
                                    ByVal pstrGROUPNM() As String,
                                    ByVal pstrTANCD() As String,
                                    ByVal pstrTANNM() As String,
                                    ByVal pstrRENTEL1() As String,
                                    ByVal pstrRENTEL2() As String,
                                    ByVal pstrRENTEL3() As String,
                                    ByVal pstrFAXNO() As String,
                                    ByVal pstrBIKO() As String,
                                    ByVal pstrSPOT_MAIL() As String,
                                    ByVal pstrMAIL_PASS() As String,
                                    ByVal pstrAUTO_FAXNM() As String,
                                    ByVal pstrAUTO_MAIL() As String,
                                    ByVal pstrAUTO_MAIL_PASS() As String,
                                    ByVal pstrAUTO_FAXNO() As String,
                                    ByVal pstrAUTO_KBN() As String,
                                    ByVal pstrAUTO_ZERO_FLG() As String,
                                    ByVal pstrSD_PRT_FLG() As String,               '2020/11/01 T.Ono 2020監視改善
                                    ByVal pstrGUIDELINE() As String,
                                    ByVal pstrGUIDELINE2() As String,                '2019/11/01 w.ganeko 2019監視改善
                                    ByVal pstrGUIDELINE3() As String,                '2019/11/01 w.ganeko 2019監視改善
                                    ByVal pstrGUIDELINENM1() As String,             '2020/11/01 T.Ono 2020監視改善
                                    ByVal pstrGUIDELINENM2() As String,             '2020/11/01 T.Ono 2020監視改善
                                    ByVal pstrGUIDELINENM3() As String,             '2020/11/01 T.Ono 2020監視改善
                                    ByVal pstrFAXKURAKBN() As String,
                                    ByVal pstrFAXJAKBN() As String,
                                    ByVal pstrINS_DATE() As String,
                                    ByVal pstrINS_USER() As String,
                                    ByVal pstrUPD_DATE() As String,
                                    ByVal pstrUPD_USER() As String,
                                    ByVal pstrUSERNM As String) As String

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

                strRes = mSetTanto(
                                cdb,
                                pintMODE,
                                pstrDBKBN,
                                pstrGROUPCD,
                                pstrGROUPNM(i),
                                pstrTANCD(i),
                                pstrTANNM(i),
                                pstrRENTEL1(i),
                                pstrRENTEL2(i),
                                pstrRENTEL3(i),
                                pstrFAXNO(i),
                                pstrBIKO(i),
                                pstrSPOT_MAIL(i),
                                pstrMAIL_PASS(i),
                                pstrAUTO_FAXNM(i),
                                pstrAUTO_MAIL(i),
                                pstrAUTO_MAIL_PASS(i),
                                pstrAUTO_FAXNO(i),
                                pstrAUTO_KBN(i),
                                pstrAUTO_ZERO_FLG(i),
                                pstrSD_PRT_FLG(i),                      '2020/11/01 T.Ono 2020監視改善
                                pstrGUIDELINE(i),
                                pstrGUIDELINE2(i),                     '2019/11/01 w.ganeko 2019監視改善      
                                pstrGUIDELINE3(i),                     '2019/11/01 w.ganeko 2019監視改善
                                pstrGUIDELINENM1(i),                    '2020/11/01 T.Ono 2020監視改善
                                pstrGUIDELINENM2(i),                    '2020/11/01 T.Ono 2020監視改善
                                pstrGUIDELINENM3(i),                    '2020/11/01 T.Ono 2020監視改善
                                pstrFAXKURAKBN(i),
                                pstrFAXJAKBN(i),
                                pstrINS_DATE(i),
                                pstrINS_USER(i),
                                pstrUPD_DATE(i),
                                pstrUPD_USER(i),
                                pstrUSERNM)



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
    <WebMethod()> Public Function mSetTanto(
                                ByRef cdb As CDB,
                                ByVal pintMODE As Integer,
                                ByVal pstrDBKBN As String,
                                ByVal pstrGROUPCD As String,
                                ByVal pstrGROUPNM As String,
                                ByVal pstrTANCD As String,
                                ByVal pstrTANNM As String,
                                ByVal pstrRENTEL1 As String,
                                ByVal pstrRENTEL2 As String,
                                ByVal pstrRENTEL3 As String,
                                ByVal pstrFAXNO As String,
                                ByVal pstrBIKO As String,
                                ByVal pstrSPOT_MAIL As String,
                                ByVal pstrMAIL_PASS As String,
                                ByVal pstrAUTO_FAXNM As String,
                                ByVal pstrAUTO_MAIL As String,
                                ByVal pstrAUTO_MAIL_PASS As String,
                                ByVal pstrAUTO_FAXNO As String,
                                ByVal pstrAUTO_KBN As String,
                                ByVal pstrAUTO_ZERO_FLG As String,
                                ByVal pstrSD_PRT_FLG As String,             '2020/11/01 T.Ono add 2020監視改善
                                ByVal pstrGUIDELINE As String,
                                ByVal pstrGUIDELINE2 As String,            '2019/11/01 w.ganeko 2019監視改善
                                ByVal pstrGUIDELINE3 As String,            '2019/11/01 w.ganeko 2019監視改善
                                ByVal pstrGUIDELINENM1 As String,           '2020/11/01 T.Ono add 2020監視改善
                                ByVal pstrGUIDELINENM2 As String,           '2020/11/01 T.Ono add 2020監視改善
                                ByVal pstrGUIDELINENM3 As String,           '2020/11/01 T.Ono add 2020監視改善
                                ByVal pstrFAXKURAKBN As String,
                                ByVal pstrFAXJAKBN As String,
                                ByVal pstrINS_DATE As String,
                                ByVal pstrINS_USER As String,
                                ByVal pstrUPD_DATE As String,
                                ByVal pstrUPD_USER As String,
                                ByVal pstrUSERNM As String) As String
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
            strSQL.Append("	    KBN, ")
            strSQL.Append("	    GROUPCD, ")
            strSQL.Append("	    GROUPNM, ")
            strSQL.Append("	    TANCD, ")
            strSQL.Append("	    TANNM, ")
            strSQL.Append("	    RENTEL1, ")
            strSQL.Append("	    RENTEL2, ")
            strSQL.Append("	    RENTEL3, ")
            strSQL.Append("	    FAXNO, ")
            strSQL.Append("	    BIKO, ")
            strSQL.Append("	    SPOT_MAIL, ")
            strSQL.Append("	    MAIL_PASS, ")
            strSQL.Append("	    AUTO_FAXNM, ")
            strSQL.Append("	    AUTO_MAIL, ")
            strSQL.Append("	    AUTO_MAIL_PASS, ")
            strSQL.Append("	    AUTO_FAXNO, ")
            strSQL.Append("	    AUTO_KBN, ")
            strSQL.Append("	    AUTO_ZERO_FLG, ")
            strSQL.Append("	    SD_PRT_FLG, ")          '2020/11/01 T.Ono add 2020監視改善
            strSQL.Append("	    GUIDELINE, ")
            strSQL.Append("	    GUIDELINE2, ")          '2019/11/01 w.ganeko 2019監視改善
            strSQL.Append("	    GUIDELINE3, ")          '2019/11/01 w.ganeko 2019監視改善
            strSQL.Append("	    GUIDELINENM1, ")        '2020/11/01 T.Ono add 2020監視改善
            strSQL.Append("	    GUIDELINENM2, ")        '2020/11/01 T.Ono add 2020監視改善
            strSQL.Append("	    GUIDELINENM3, ")        '2020/11/01 T.Ono add 2020監視改善
            strSQL.Append("	    FAXKURAKBN, ")
            strSQL.Append("	    FAXKBN, ")
            strSQL.Append("	    INS_DATE, ")
            strSQL.Append("	    INS_USER, ")
            strSQL.Append("	    UPD_DATE, ")
            strSQL.Append("	    UPD_USER ")
            strSQL.Append("FROM ")
            strSQL.Append("	    M11_JAHOKOKU ")
            strSQL.Append("WHERE	KBN = :KBN ")
            strSQL.Append("AND	    GROUPCD = :GROUPCD ")
            strSQL.Append("AND	    LPAD(TANCD,2,'0') = :TANCD ")
            strSQL.Append("FOR UPDATE NOWAIT ")             '排他制御をかける

            'SQL文セット
            cdb.pSQL = strSQL.ToString

            'パラメータに値をセット
            cdb.pSQLParamStr("KBN") = pstrDBKBN             '区分
            cdb.pSQLParamStr("GROUPCD") = pstrGROUPCD       'グループコード
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
                '*******************************************
                tmp = Convert.ToString(ds.Tables(0).Rows(0).Item("INS_DATE")) & "_" & Convert.ToString(ds.Tables(0).Rows(0).Item("UPD_DATE"))
                If (tmp <> pstrINS_DATE & "_" & pstrUPD_DATE) Then
                    strRes = "0"
                    Exit Try
                End If

                '*******************************************
                ' 修正時でデータが変更されていない場合はスキップ
                '*******************************************
                If (
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("GROUPNM")) = pstrGROUPNM) And
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("TANCD")) = pstrTANCD) And
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("TANNM")) = pstrTANNM) And
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("RENTEL1")) = pstrRENTEL1) And
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("RENTEL2")) = pstrRENTEL2) And
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("RENTEL3")) = pstrRENTEL3) And
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("FAXNO")) = pstrFAXNO) And
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("BIKO")) = pstrBIKO) And
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("SPOT_MAIL")) = pstrSPOT_MAIL) And
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("MAIL_PASS")) = pstrMAIL_PASS) And
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("AUTO_FAXNM")) = pstrAUTO_FAXNM) And
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("AUTO_MAIL")) = pstrAUTO_MAIL) And
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("AUTO_MAIL_PASS")) = pstrAUTO_MAIL_PASS) And
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("AUTO_FAXNO")) = pstrAUTO_FAXNO) And
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("AUTO_KBN")) = pstrAUTO_KBN) And
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("AUTO_ZERO_FLG")) = pstrAUTO_ZERO_FLG) And
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("SD_PRT_FLG")) = pstrSD_PRT_FLG) And       '2020/11/01 T.Ono add 2020監視改善
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("GUIDELINE")) = pstrGUIDELINE) And
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("GUIDELINE2")) = pstrGUIDELINE2) And      '2019/11/01 w.ganeko 2019監視改善
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("GUIDELINE3")) = pstrGUIDELINE3) And      '2019/11/01 w.ganeko 2019監視改善
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("GUIDELINENM1")) = pstrGUIDELINENM1) And   '2020/11/01 T.Ono add 2020監視改善
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("GUIDELINENM2")) = pstrGUIDELINENM2) And   '2020/11/01 T.Ono add 2020監視改善
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("GUIDELINENM3")) = pstrGUIDELINENM3) And   '2020/11/01 T.Ono add 2020監視改善
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("FAXKURAKBN")) = pstrFAXKURAKBN) And
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("FAXKBN")) = pstrFAXJAKBN)
                     ) Then

                    pintMODE = 4 'スキップ
                End If
            End If


            If pintMODE = 4 Then
                'スキップ→次のレコード
                Exit Try
            End If

            'ＤＢチェック-----------------------------------
            'DBKBN=2,グループコード登録のときのチェック
            'グループコードのチェックなので、TANCD=01のときだけチェックする
            If pstrDBKBN = "2" AndAlso pstrTANCD = "01" Then
                '削除時
                If (pintMODE = 3) Then
                    '*******************************************
                    'JAグループ作成マスタで使われていないかチェック
                    strSQL = New StringBuilder("")
                    strSQL.Append("SELECT 'X'")
                    strSQL.Append("FROM ")
                    strSQL.Append("     M09_JAGROUP A ")
                    strSQL.Append("WHERE ")
                    strSQL.Append("     A.KBN = '002' ")
                    strSQL.Append("AND	A.GROUPCD = :GROUPCD ")
                    'SQL文セット
                    cdb.pSQL = strSQL.ToString
                    'バインド変数に値をセット
                    cdb.pSQLParamStr("GROUPCD") = pstrGROUPCD
                    'SQL実行
                    cdb.mExecQuery()
                    ds = cdb.pResult

                    If (ds.Tables(0).Rows.Count > 0) Then
                        '*******************************************
                        'JAグループ作成マスタで使用されている
                        '*******************************************
                        strRes = "4"
                        Exit Try
                    End If
                End If

                '登録/更新時
                If (pintMODE = 1 Or pintMODE = 2) Then
                    '*******************************************
                    '命名則のチェック
                    strSQL = New StringBuilder("")
                    strSQL.Append("SELECT ")
                    strSQL.Append("	A.CD ")
                    strSQL.Append("	,A.NAME ")
                    strSQL.Append("	,A.NAIYO1 ")
                    strSQL.Append("	,A.NAIYO2 ")
                    strSQL.Append("FROM ")
                    strSQL.Append("		M06_PULLDOWN A ")
                    strSQL.Append("WHERE ")
                    strSQL.Append("		KBN = '78' ")
                    strSQL.Append("AND	CD = '002' ")
                    'SQL文セット
                    cdb.pSQL = strSQL.ToString

                    'SQL実行
                    cdb.mExecQuery()
                    ds = cdb.pResult

                    If (ds.Tables(0).Rows.Count = 0) Then
                        '*******************************************
                        'プルダウンマスタに登録が存在しない時
                        '*******************************************
                        strRes = "5"
                        Exit Try
                    Else
                        If Convert.ToString(ds.Tables(0).Rows(0).Item("NAIYO1")) <> pstrGROUPCD.Substring(0, 2) Then
                            '*******************************************
                            '命名則違反（グループコードの先頭にNAIYO1がついてない）
                            '*******************************************
                            strRes = "6"
                            Exit Try
                        End If
                    End If
                End If
            End If

            'グループコード名の重複はNGとする 2016/01/12 T.Ono add 2015改善開発 
            '登録/更新時
            If (pintMODE = 1 Or pintMODE = 2) Then
                '担当者コード01、グループコード名入力ありの場合にチェック
                If pstrTANCD = "01" AndAlso pstrGROUPNM.Trim.Length > 0 Then
                    strSQL = New StringBuilder("")
                    strSQL.Append("SELECT ")
                    strSQL.Append("     'X' ")
                    strSQL.Append("FROM ")
                    strSQL.Append("		M11_JAHOKOKU A ")
                    strSQL.Append("WHERE ")
                    strSQL.Append("		1 = 1 ")
                    strSQL.Append("AND	LPAD(A.TANCD,2,'0') = :TANCD ")
                    strSQL.Append("AND	A.GROUPCD <> :GROUPCD ")
                    strSQL.Append("AND	A.GROUPNM = :GROUPNM ")

                    'SQL文セット
                    cdb.pSQL = strSQL.ToString
                    'バインド変数に値をセット
                    cdb.pSQLParamStr("TANCD") = pstrTANCD           '担当者コード
                    cdb.pSQLParamStr("GROUPCD") = pstrGROUPCD       'グループコード
                    cdb.pSQLParamStr("GROUPNM") = pstrGROUPNM       'グループコード名

                    'SQL実行
                    cdb.mExecQuery()
                    ds = cdb.pResult

                    If (ds.Tables(0).Rows.Count > 0) Then
                        '*******************************************
                        'グループコード名重複
                        '*******************************************
                        strRes = "7"
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
                strSQL.Append("     M11_JAHOKOKU ")                 'JA担当者・報告先・注意事項マスタ
                strSQL.Append("WHERE KBN  =:KBN  ")                 '区分
                strSQL.Append("AND  GROUPCD =:GROUPCD ")            'クライアントコード
                strSQL.Append("AND  LPAD(TANCD,2,'0')=:TANCD ")     '担当者コード

            ElseIf pintMODE = 2 Then
                '処理区分が修正
                strSQL = New StringBuilder("")
                strSQL.Append("UPDATE ")
                strSQL.Append("     M11_JAHOKOKU ")
                strSQL.Append("SET ")
                strSQL.Append("     KBN = :KBN, ")
                strSQL.Append("     GROUPCD = :GROUPCD, ")
                strSQL.Append("     GROUPNM = :GROUPNM, ")
                strSQL.Append("     TANCD = :TANCD, ")
                strSQL.Append("     TANNM = :TANNM, ")
                strSQL.Append("     RENTEL1 = :RENTEL1, ")
                strSQL.Append("     RENTEL2 = :RENTEL2, ")
                strSQL.Append("     RENTEL3 = :RENTEL3, ")
                strSQL.Append("     FAXNO = :FAXNO, ")
                strSQL.Append("     BIKO = :BIKO, ")
                strSQL.Append("     SPOT_MAIL = :SPOT_MAIL, ")
                strSQL.Append("     MAIL_PASS  = :MAIL_PASS, ")
                strSQL.Append("     AUTO_FAXNM = :AUTO_FAXNM, ")
                strSQL.Append("     AUTO_MAIL  = :AUTO_MAIL, ")
                strSQL.Append("     AUTO_MAIL_PASS = :AUTO_MAIL_PASS, ")
                strSQL.Append("     AUTO_FAXNO = :AUTO_FAXNO, ")
                strSQL.Append("     AUTO_KBN = :AUTO_KBN, ")
                strSQL.Append("     AUTO_ZERO_FLG = :AUTO_ZERO_FLG, ")
                strSQL.Append("     SD_PRT_FLG = :SD_PRT_FLG, ")        '2020/11/01 T.Ono 2020監視改善
                strSQL.Append("     GUIDELINE  = :GUIDELINE, ")
                strSQL.Append("     GUIDELINE2  = :GUIDELINE2, ")     '2019/11/01 w.ganeko 2019監視改善
                strSQL.Append("     GUIDELINE3  = :GUIDELINE3, ")     '2019/11/01 w.ganeko 2019監視改善
                strSQL.Append("     GUIDELINENM1  = :GUIDELINENM1, ")   '2020/11/01 T.Ono 2020監視改善
                strSQL.Append("     GUIDELINENM2  = :GUIDELINENM2, ")   '2020/11/01 T.Ono 2020監視改善
                strSQL.Append("     GUIDELINENM3  = :GUIDELINENM3, ")   '2020/11/01 T.Ono 2020監視改善
                strSQL.Append("     FAXKURAKBN  = :FAXKURAKBN, ")
                strSQL.Append("     FAXKBN  = :FAXJAKBN, ")
                strSQL.Append("     INS_DATE   = TO_DATE(:INS_DATE, 'YYYY/MM/DD HH24:MI:SS'), ")
                strSQL.Append("     INS_USER   = :INS_USER, ")
                strSQL.Append("     UPD_DATE   = TO_DATE(:UPD_DATE, 'YYYY/MM/DD HH24:MI:SS'), ")
                strSQL.Append("     UPD_USER   = :UPD_USER ")
                strSQL.Append("WHERE ")
                strSQL.Append("     KBN    = :KBN ")                    '区分
                strSQL.Append("AND  GROUPCD = :GROUPCD ")               'グループコード
                strSQL.Append("AND  LPAD(TANCD,2,'0')= :TANCD ")        '担当者コード

            ElseIf pintMODE = 1 Then
                '処理区分が新規
                strSQL = New StringBuilder("")
                strSQL.Append("INSERT INTO ")
                strSQL.Append(" M11_JAHOKOKU (")
                strSQL.Append("     KBN, ")
                strSQL.Append("     GROUPCD, ")
                strSQL.Append("     GROUPNM, ")
                strSQL.Append("     TANCD, ")
                strSQL.Append("     TANNM, ")
                strSQL.Append("     RENTEL1, ")
                strSQL.Append("     RENTEL2, ")
                strSQL.Append("     RENTEL3, ")
                strSQL.Append("     FAXNO, ")
                strSQL.Append("     BIKO, ")
                strSQL.Append("     SPOT_MAIL, ")
                strSQL.Append("     MAIL_PASS, ")
                strSQL.Append("     AUTO_FAXNM, ")
                strSQL.Append("     AUTO_MAIL, ")
                strSQL.Append("     AUTO_MAIL_PASS, ")
                strSQL.Append("     AUTO_FAXNO, ")
                strSQL.Append("     AUTO_KBN, ")
                strSQL.Append("     AUTO_ZERO_FLG, ")
                strSQL.Append("     SD_PRT_FLG, ")          '2020/11/01 T.Ono add 2020監視改善
                strSQL.Append("     GUIDELINE, ")
                strSQL.Append("     GUIDELINE2, ")          '2019/11/01 w.ganeko 2019監視改善
                strSQL.Append("     GUIDELINE3, ")          '2019/11/01 w.ganeko 2019監視改善
                strSQL.Append("     GUIDELINENM1, ")        '2020/11/01 T.Ono add 2020監視改善
                strSQL.Append("     GUIDELINENM2, ")        '2020/11/01 T.Ono add 2020監視改善
                strSQL.Append("     GUIDELINENM3, ")        '2020/11/01 T.Ono add 2020監視改善
                strSQL.Append("     FAXKURAKBN, ")
                strSQL.Append("     FAXKBN, ")
                strSQL.Append("     INS_DATE, ")
                strSQL.Append("     INS_USER, ")
                strSQL.Append("     UPD_DATE, ")
                strSQL.Append("     UPD_USER ")
                strSQL.Append(") VALUES( ")
                strSQL.Append("     :KBN, ")
                strSQL.Append("     :GROUPCD, ")
                strSQL.Append("     :GROUPNM, ")
                strSQL.Append("     LPAD(:TANCD,2,'0'), ")
                strSQL.Append("     :TANNM, ")
                strSQL.Append("     :RENTEL1, ")
                strSQL.Append("     :RENTEL2, ")
                strSQL.Append("     :RENTEL3, ")
                strSQL.Append("     :FAXNO, ")
                strSQL.Append("     :BIKO, ")
                strSQL.Append("     :SPOT_MAIL, ")
                strSQL.Append("     :MAIL_PASS, ")
                strSQL.Append("     :AUTO_FAXNM, ")
                strSQL.Append("     :AUTO_MAIL, ")
                strSQL.Append("     :AUTO_MAIL_PASS, ")
                strSQL.Append("     :AUTO_FAXNO, ")
                strSQL.Append("     :AUTO_KBN, ")
                strSQL.Append("     :AUTO_ZERO_FLG, ")
                strSQL.Append("     :SD_PRT_FLG, ")         '2020/11/01 T.Ono add 2020監視改善
                strSQL.Append("     :GUIDELINE, ")
                strSQL.Append("     :GUIDELINE2, ")         '2019/11/01 w.ganeko 2019監視改善
                strSQL.Append("     :GUIDELINE3, ")         '2019/11/01 w.ganeko 2019監視改善
                strSQL.Append("     :GUIDELINENM1, ")       '2020/11/01 T.Ono add 2020監視改善
                strSQL.Append("     :GUIDELINENM2, ")       '2020/11/01 T.Ono add 2020監視改善
                strSQL.Append("     :GUIDELINENM3, ")       '2020/11/01 T.Ono add 2020監視改善
                strSQL.Append("     :FAXKURAKBN, ")
                strSQL.Append("     :FAXJAKBN, ")
                strSQL.Append("     TO_DATE(:INS_DATE, 'YYYY/MM/DD HH24:MI:SS'), ")
                strSQL.Append("     :INS_USER, ")
                strSQL.Append("     TO_DATE(:UPD_DATE, 'YYYY/MM/DD HH24:MI:SS'), ")
                strSQL.Append("     :UPD_USER ")
                strSQL.Append(")")
            End If

            'SQL文セット
            cdb.pSQL = strSQL.ToString
            'バインド変数に値をセット
            If pintMODE = 3 Then
                cdb.pSQLParamStr("KBN") = pstrDBKBN                     '区分（1:クライアント登録　2:グループコード登録）
                cdb.pSQLParamStr("GROUPCD") = pstrGROUPCD               'クライアントコード／グループコード
                cdb.pSQLParamStr("TANCD") = pstrTANCD                   '担当者コード
            ElseIf pintMODE = 1 Or pintMODE = 2 Then

                cdb.pSQLParamStr("KBN") = pstrDBKBN                       '区分（1:監視センター担当者　2:出動会社担当者 3:JA支所担当者）
                cdb.pSQLParamStr("GROUPCD") = pstrGROUPCD               'グループコード
                cdb.pSQLParamStr("GROUPNM") = pstrGROUPNM               'グループコード名
                cdb.pSQLParamStr("TANCD") = pstrTANCD                   '担当者コード
                cdb.pSQLParamStr("TANNM") = pstrTANNM                   '担当者名
                cdb.pSQLParamStr("RENTEL1") = pstrRENTEL1               '連絡電話番号１
                cdb.pSQLParamStr("RENTEL2") = pstrRENTEL2               '連絡電話番号２
                cdb.pSQLParamStr("RENTEL3") = pstrRENTEL3               '連絡電話番号３
                cdb.pSQLParamStr("FAXNO") = pstrFAXNO                   'FAX番号
                cdb.pSQLParamStr("BIKO") = pstrBIKO                     '備考
                cdb.pSQLParamStr("SPOT_MAIL") = pstrSPOT_MAIL           'SPOTﾒｰﾙ
                cdb.pSQLParamStr("MAIL_PASS") = pstrMAIL_PASS           'ﾒｰﾙﾊﾟｽﾜｰﾄﾞ
                cdb.pSQLParamStr("AUTO_FAXNM") = pstrAUTO_FAXNM         '自動FAX番号
                cdb.pSQLParamStr("AUTO_MAIL") = pstrAUTO_MAIL           '自動FAX送信メールアドレス
                cdb.pSQLParamStr("AUTO_MAIL_PASS") = pstrAUTO_MAIL_PASS '自動FAX添付ﾌｧｲﾙﾊﾟｽﾜｰﾄ
                cdb.pSQLParamStr("AUTO_FAXNO") = pstrAUTO_FAXNO         '自動FAX番号
                cdb.pSQLParamStr("AUTO_KBN") = pstrAUTO_KBN             '自動送信区分
                cdb.pSQLParamStr("AUTO_ZERO_FLG") = pstrAUTO_ZERO_FLG   'ゼロ件送信フラグ
                cdb.pSQLParamStr("SD_PRT_FLG") = pstrSD_PRT_FLG         '出動依頼内容・備考表示フラグ  '2020/11/01 T.Ono add 2020監視改善
                cdb.pSQLParamStr("GUIDELINE") = pstrGUIDELINE           'JA注意事項1
                cdb.pSQLParamStr("GUIDELINE2") = pstrGUIDELINE2         'JA注意事項2   '2019/11/01 w.ganeko 2019監視改善
                cdb.pSQLParamStr("GUIDELINE3") = pstrGUIDELINE3         'JA注意事項3   '2019/11/01 w.ganeko 2019監視改善
                cdb.pSQLParamStr("GUIDELINENM1") = pstrGUIDELINENM1     'JA注意事項1ボタン名    '2020/10/05 T.Ono 2020監視改善
                cdb.pSQLParamStr("GUIDELINENM2") = pstrGUIDELINENM2     'JA注意事項2ボタン名    '2020/10/05 T.Ono 2020監視改善　
                cdb.pSQLParamStr("GUIDELINENM3") = pstrGUIDELINENM3     'JA注意事項3ボタン名    '2020/10/05 T.Ono 2020監視改善
                cdb.pSQLParamStr("FAXKURAKBN") = pstrFAXKURAKBN         'FAX不要(ｸﾗｲｱﾝﾄ)区分
                cdb.pSQLParamStr("FAXJAKBN") = pstrFAXJAKBN             'FAX不要(JA)区分

                If pintMODE = 1 Then
                    '新規登録の場合
                    cdb.pSQLParamStr("INS_DATE") = Now.ToString()
                    cdb.pSQLParamStr("INS_USER") = pstrUSERNM.Trim
                    cdb.pSQLParamStr("UPD_DATE") = ""
                    cdb.pSQLParamStr("UPD_USER") = ""
                Else
                    '修正登録の場合
                    cdb.pSQLParamStr("INS_DATE") = pstrINS_DATE
                    cdb.pSQLParamStr("INS_USER") = pstrINS_USER
                    cdb.pSQLParamStr("UPD_DATE") = Now.ToString()
                    cdb.pSQLParamStr("UPD_USER") = pstrUSERNM.Trim
                End If

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
    '**********************************************************
    'ログ吐き出し
    '戻り値：書き込んだファイルへのフルパス
    '**********************************************************
    Public Sub mlog(ByVal pstrString As String)
        Dim strFilnm As String = "testGroup" & System.DateTime.Today.ToString("yyyyMMdd")
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
