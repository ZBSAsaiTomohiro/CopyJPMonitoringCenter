'***********************************************
'累積情報自動FAX&メールマスタ
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


<System.Web.Services.WebService(Namespace:="http://tempuri.org/MSRUIJAW00/Service1")> _
Public Class MSRUIJAW00
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
    '累積情報自動FAX&メールマスタリストデータ取得
    '************************************************
    '【共通】
    '  OK : 正常に終了しました
    '   0 : 他のユーザーによってデータが更新されています。再度検索してください
    '   1 : 既にデータが存在します
    '   2 : 対象データが存在しません
    '   3 : 排他制御処理でエラーが発生しました。再度実行してください
    ' ----------------------------------------------
    '2020/11/01 T.Ono mod 2020監視改善 pstrSD_PRT追加
    <WebMethod()> Public Function mSet(
                                    ByVal pintMODE As Integer,
                                    ByVal pstrKURACD As String,
                                    ByVal pstrID() As String,
                                    ByVal pstrSEND() As String,
                                    ByVal pstrKYOKYUCD() As String,
                                    ByVal pstrACBCDFR() As String,
                                    ByVal pstrACBCDTO() As String,
                                    ByVal pstrFAX1() As String,
                                    ByVal pstrFAX2() As String,
                                    ByVal pstrMAIL1() As String,
                                    ByVal pstrMAIL2() As String,
                                    ByVal pstrNXSEND() As String,
                                    ByVal pstrLSSEND() As String,
                                    ByVal pstrSENDSTR() As String,
                                    ByVal pstrSENDEND() As String,
                                    ByVal pstrMAILPASS() As String,
                                    ByVal pstrZIPFILE() As String,
                                    ByVal pstrBIKOU() As String,
                                    ByVal pstrHASSEI() As String,
                                    ByVal pstrKAIPAGE() As String,
                                    ByVal pstrKIKAN() As String,
                                    ByVal pstrZEROSEND() As String,
                                    ByVal pstrSD_PRT() As String,
                                    ByVal pstrSNDSTOP() As String,
                                    ByVal pstrDEL() As String,
                                    ByVal pstrADD_DATE As String,
                                    ByVal pstrEDT_DATE As String,
                                    ByVal pstrADD_DT() As String,
                                    ByVal pstrEDT_DT() As String) As String

        ' ------------------------------
        ' strAUTO_MAIL配列を空で用意
        Dim strKYOKYUCD() As String
        strKYOKYUCD = New String(pstrKYOKYUCD.Length) {} '配列の実体を確保
        Dim strDEL() As String
        strDEL = New String(pstrDEL.Length) {} '配列の実体を確保
        Dim i As Integer
        For i = 0 To strKYOKYUCD.Length
            strKYOKYUCD(i) = ""
            strDEL(i) = ""
        Next
        ' ------------------------------
        '2020/11/01 T.Ono mod 2020監視改善 pstrSD_PRT追加
        Return mSetEx(pintMODE,
                      pstrKURACD,
                      pstrID,
                      pstrSEND,
                      pstrKYOKYUCD,
                      pstrACBCDFR,
                      pstrACBCDTO,
                      pstrFAX1,
                      pstrFAX2,
                      pstrMAIL1,
                      pstrMAIL2,
                      pstrNXSEND,
                      pstrLSSEND,
                      pstrSENDSTR,
                      pstrSENDEND,
                      pstrMAILPASS,
                      pstrZIPFILE,
                      pstrBIKOU,
                      pstrHASSEI,
                      pstrKAIPAGE,
                      pstrKIKAN,
                      pstrZEROSEND,
                      pstrSD_PRT,
                      pstrSNDSTOP,
                      pstrDEL,
                      pstrADD_DATE,
                      pstrEDT_DATE,
                      pstrADD_DT,
                      pstrEDT_DT)
    End Function

    '2020/11/01 T.Ono mod 2020監視改善 pstrSD_PRT追加
    <WebMethod()> Public Function mSetEx(
                                    ByVal pintMODE As Integer,
                                    ByVal pstrKURACD As String,
                                    ByVal pstrID() As String,
                                    ByVal pstrSEND() As String,
                                    ByVal pstrKYOKYUCD() As String,
                                    ByVal pstrACBCDFR() As String,
                                    ByVal pstrACBCDTO() As String,
                                    ByVal pstrFAX1() As String,
                                    ByVal pstrFAX2() As String,
                                    ByVal pstrMAIL1() As String,
                                    ByVal pstrMAIL2() As String,
                                    ByVal pstrNXSEND() As String,
                                    ByVal pstrLSSEND() As String,
                                    ByVal pstrSENDSTR() As String,
                                    ByVal pstrSENDEND() As String,
                                    ByVal pstrMAILPASS() As String,
                                    ByVal pstrZIPFILE() As String,
                                    ByVal pstrBIKOU() As String,
                                    ByVal pstrHASSEI() As String,
                                    ByVal pstrKAIPAGE() As String,
                                    ByVal pstrKIKAN() As String,
                                    ByVal pstrZEROSEND() As String,
                                    ByVal pstrSD_PRT() As String,
                                    ByVal pstrSNDSTOP() As String,
                                    ByVal pstrDEL() As String,
                                    ByVal pstrADD_DATE As String,
                                    ByVal pstrEDT_DATE As String,
                                    ByVal pstrADD_DT() As String,
                                    ByVal pstrEDT_DT() As String) As String
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

                '2020/11/01 T.Ono mod 2020監視改善 pstrSD_PRT追加
                strRes = mSetRuiauto(
                        cdb,
                        pintMODE,
                        pstrKURACD,
                        pstrID(i),
                        pstrSEND(i),
                        pstrKYOKYUCD(i),
                        pstrACBCDFR(i),
                        pstrACBCDTO(i),
                        pstrFAX1(i),
                        pstrFAX2(i),
                        pstrMAIL1(i),
                        pstrMAIL2(i),
                        pstrNXSEND(i),
                        pstrLSSEND(i),
                        pstrSENDSTR(i),
                        pstrSENDEND(i),
                        pstrMAILPASS(i),
                        pstrZIPFILE(i),
                        pstrBIKOU(i),
                        pstrHASSEI(i),
                        pstrKAIPAGE(i),
                        pstrKIKAN(i),
                        pstrZEROSEND(i),
                        pstrSD_PRT(i),
                        pstrSNDSTOP(i),
                        pstrDEL(i),
                        pstrADD_DATE,
                        pstrEDT_DATE,
                        pstrADD_DT(i),
                        pstrEDT_DT(i))

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
    '累積情報FAXマスタ更新
    '************************************************
    '2020/11/01 T.Ono 2020監視改善 pstrSD_PRT追加
    <WebMethod()> Public Function mSetRuiauto(
                                ByRef cdb As CDB,
                                ByVal pintMODE As Integer,
                                ByVal pstrKURACD As String,
                                ByVal pstrID As String,
                                ByVal pstrSEND As String,
                                ByVal pstrKYOKYUCD As String,
                                ByVal pstrACBCDFR As String,
                                ByVal pstrACBCDTO As String,
                                ByVal pstrFAX1 As String,
                                ByVal pstrFAX2 As String,
                                ByVal pstrMAIL1 As String,
                                ByVal pstrMAIL2 As String,
                                ByVal pstrNXSEND As String,
                                ByVal pstrLSSEND As String,
                                ByVal pstrSENDSTR As String,
                                ByVal pstrSENDEND As String,
                                ByVal pstrMAILPASS As String,
                                ByVal pstrZIPFILE As String,
                                ByVal pstrBIKOU As String,
                                ByVal pstrHASSEI As String,
                                ByVal pstrKAIPAGE As String,
                                ByVal pstrKIKAN As String,
                                ByVal pstrZEROSEND As String,
                                ByVal pstrSD_PRT As String,
                                ByVal pstrSNDSTOP As String,
                                ByVal pstrDEL As String,
                                ByVal pstrADD_DATE As String,
                                ByVal pstrEDT_DATE As String,
                                ByVal pstrADD_DT As String,
                                ByVal pstrEDT_DT As String) As String
        Dim ds As New DataSet
        Dim strRes As String
        Dim strSQL As StringBuilder
        Dim re As Integer
        Dim newId As Integer
        Dim newSEQ As Integer

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
            strSQL.Append("A.ID, ")
            strSQL.Append("A.SEQ, ")
            strSQL.Append("A.KURACD, ")
            strSQL.Append("A.HAISO_CD, ")
            strSQL.Append("A.ACBCD_FR, ")
            strSQL.Append("A.ACBCD_TO, ")
            strSQL.Append("A.HATKBN, ")
            strSQL.Append("A.PAGEKBN, ")
            strSQL.Append("A.PERIODKBN, ")
            strSQL.Append("A.FAX1, ")
            strSQL.Append("A.FAX2, ")
            strSQL.Append("A.MAIL1, ")
            strSQL.Append("A.MAIL2, ")
            strSQL.Append("A.ZEROSENDKBN, ")
            strSQL.Append("A.SD_PRT, ")                     '出動依頼内容・備考表示フラグ 2020/11/01 T.Ono add 2020監視改善
            strSQL.Append("A.JOTAI, ")
            strSQL.Append("A.LASTSENDDATE, ")
            strSQL.Append("A.NEXTSENDDATE, ")
            strSQL.Append("A.SENDSTOPKBN, ")
            strSQL.Append("A.SENDSTDATE, ")
            strSQL.Append("A.SENDEDDATE, ")
            strSQL.Append("A.BIKO, ")
            strSQL.Append("A.DEL_FLG, ")
            strSQL.Append("A.MAIL_PASSWORD, ")
            strSQL.Append("A.ZIP_FILE_NAME, ")
            strSQL.Append("A.INS_DATE, ")
            strSQL.Append("A.UPD_DATE ")                  '更新時間
            strSQL.Append("FROM ")
            strSQL.Append("  B10_BTRUIJAE A ")              '累積情報自動FAX&メールマスタ
            strSQL.Append("WHERE A.ID   = :ID ")
            strSQL.Append("AND A.KURACD   = :KURACD ")
            strSQL.Append("AND A.DEL_FLG  = '0' ")
            strSQL.Append("FOR UPDATE NOWAIT ")             '排他制御をかける

            'SQL文セット
            cdb.pSQL = strSQL.ToString

            'パラメータに値をセット
            cdb.pSQLParamStr("ID") = pstrID               'ID
            cdb.pSQLParamStr("KURACD") = pstrKURACD               'クライアントコード

            'SQL実行
            cdb.mExecQuery()
            ds = cdb.pResult

            '*******************************
            ' モードの再決定
            '*******************************
            If (ds.Tables(0).Rows.Count <> 0) Then 'ＤＢにデータが存在する？
                If pintMODE = 4 Then 'pintMODE=4(削除)
                    If pstrDEL = "true" Then
                        pintMODE = 3 'モード＝3：削除
                    Else
                        pintMODE = 2 'モード＝2：更新
                    End If
                Else
                    pintMODE = 2 'モード＝2：更新
                End If
            Else
                '登録元データはない？
                '2014/03/10 T.Ono mod 入力の有無はFAXとメールでチェック
                'If pstrSEND = "" Then 
                If pstrFAX1 = "" AndAlso pstrFAX2 = "" AndAlso pstrMAIL1 = "" AndAlso pstrMAIL2 = "" Then
                    pintMODE = 4 'モード＝4：スキップ
                ElseIf pstrDEL = "true" Then
                    strRes = "0"
                    pintMODE = 4 'モード＝4：スキップ
                Else
                    pintMODE = 1 'モード＝1：新規
                End If
            End If

            If (pintMODE = 2) Then 'ＤＢにデータが存在して、更新の場合
                '*******************************************
                '修正時で受け渡された日付及び時間と更新対象データが異なる場合エラー
                '*******************************************
                tmp = Convert.ToString(ds.Tables(0).Rows(0).Item("UPD_DATE"))
                If (tmp <> pstrEDT_DT) Then
                    strRes = "0"
                    Exit Try
                End If

                '*******************************************
                ' 修正時でデータが変更されていない場合はスキップ
                '*******************************************
                If (
                (Convert.ToString(ds.Tables(0).Rows(0).Item("SEQ")) = pstrSEND) And
                (Convert.ToString(ds.Tables(0).Rows(0).Item("KURACD")) = pstrKURACD) And
                (Convert.ToString(ds.Tables(0).Rows(0).Item("HAISO_CD")) = pstrKYOKYUCD) And
                (Convert.ToString(ds.Tables(0).Rows(0).Item("ACBCD_FR")) = pstrACBCDFR) And
                (Convert.ToString(ds.Tables(0).Rows(0).Item("ACBCD_TO")) = pstrACBCDTO) And
                (Convert.ToString(ds.Tables(0).Rows(0).Item("HATKBN")) = pstrHASSEI) And
                (Convert.ToString(ds.Tables(0).Rows(0).Item("PAGEKBN")) = pstrKAIPAGE) And
                (Convert.ToString(ds.Tables(0).Rows(0).Item("PERIODKBN")) = pstrKIKAN) And
                (Convert.ToString(ds.Tables(0).Rows(0).Item("FAX1")) = pstrFAX1) And
                (Convert.ToString(ds.Tables(0).Rows(0).Item("FAX2")) = pstrFAX2) And
                (Convert.ToString(ds.Tables(0).Rows(0).Item("MAIL1")) = pstrMAIL1) And
                (Convert.ToString(ds.Tables(0).Rows(0).Item("MAIL2")) = pstrMAIL2) And
                (Convert.ToString(ds.Tables(0).Rows(0).Item("NEXTSENDDATE")) = pstrNXSEND) And
                (Convert.ToString(ds.Tables(0).Rows(0).Item("ZEROSENDKBN")) = pstrZEROSEND) And
                (Convert.ToString(ds.Tables(0).Rows(0).Item("SD_PRT")) = pstrSD_PRT) And                '2020/11/01 T.Ono add 2020監視改善
                (Convert.ToString(ds.Tables(0).Rows(0).Item("SENDSTOPKBN")) = pstrSNDSTOP) And
                (Convert.ToString(ds.Tables(0).Rows(0).Item("SENDSTDATE")) = pstrSENDSTR) And
                (Convert.ToString(ds.Tables(0).Rows(0).Item("SENDEDDATE")) = pstrSENDEND) And
                (Convert.ToString(ds.Tables(0).Rows(0).Item("BIKO")) = pstrBIKOU) And
                (Convert.ToString(ds.Tables(0).Rows(0).Item("MAIL_PASSWORD")) = pstrMAILPASS) And
                (Convert.ToString(ds.Tables(0).Rows(0).Item("ZIP_FILE_NAME")) = pstrZIPFILE)
                     ) Then

                    pintMODE = 4 'スキップ
                End If
            End If

            If pintMODE = 4 Then
                'スキップ→次のレコード
                Exit Try
            End If

            'ＤＢチェック-----------------------------------
            '登録修正時、クライアントコードの存在チェックを行う
            If (pintMODE = 1 Or pintMODE = 2) Then

                strSQL = New StringBuilder("")
                strSQL.Append("SELECT  ")
                strSQL.Append(" CLI_CD ")                     'クライアントコード
                strSQL.Append("FROM ")
                strSQL.Append("CLIMAS ")                        'クライアントマスタ
                strSQL.Append("WHERE CLI_CD = :CLI_CD ")  'クライアントコード
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

            '登録修正時、送信順の重複チェックを行う
            '2014/03/10 T.Ono mod 送信順の入力がある場合。無い場合は自動採番
            'If (pintMODE = 1 Or pintMODE = 2) Then
            If (pintMODE = 1 Or pintMODE = 2) AndAlso pstrSEND.Trim.Length > 0 Then

                strSQL = New StringBuilder("")
                strSQL.Append("SELECT ")
                strSQL.Append("     ID ")
                strSQL.Append("FROM ")
                strSQL.Append("     B10_BTRUIJAE ")
                strSQL.Append("WHERE ")
                strSQL.Append("     DEL_FLG ='0' ")
                strSQL.Append("AND  SEQ = :SEQ ")
                If pintMODE = 2 Then
                    strSQL.Append("AND  ID != :ID ")
                End If
                strSQL.Append("ORDER BY ID ")
                'SQL文セット
                cdb.pSQL = strSQL.ToString

                'パラメータに値をセット
                cdb.pSQLParamStr("SEQ") = pstrSEND
                If pintMODE = 2 Then
                    cdb.pSQLParamStr("ID") = pstrID
                End If

                'SQL実行
                cdb.mExecQuery()
                ds = cdb.pResult

                If (ds.Tables(0).Rows.Count <> 0) Then
                    '*******************************************
                    '送信順が存在する時
                    '*******************************************
                    strRes = "5"
                    Exit Try
                End If
            End If

            'データの更新処理--------------------------------

            If pintMODE = 3 Then
                '処理区分が削除
                strSQL = New StringBuilder("")
                strSQL.Append("UPDATE ")
                strSQL.Append("B10_BTRUIJAE ")                      '累積情報自動FAX&メール
                strSQL.Append("SET ")
                strSQL.Append("    DEL_FLG     = '1' ")          ' 削除フラグ
                strSQL.Append("    ,UPD_DATE     = SYSDATE ")          ' 更新日
                strSQL.Append("WHERE ID  =:ID  ")                   'ID

            ElseIf pintMODE = 2 Then
                '処理区分が修正
                strSQL = New StringBuilder("")
                strSQL.Append("UPDATE ")
                strSQL.Append("B10_BTRUIJAE ")
                strSQL.Append("SET ")
                strSQL.Append("    SEQ          = :SEQ, ")               ' 送順
                strSQL.Append("    KURACD       = :KURACD, ")            ' ｸﾗｲﾝﾄ
                strSQL.Append("    HAISO_CD     = :HAISO_CD, ")          ' 供給
                strSQL.Append("    ACBCD_FR     = :ACBCD_FR, ")          ' 支所 From
                strSQL.Append("    ACBCD_TO     = :ACBCD_TO, ")          ' 支所 To
                strSQL.Append("    HATKBN       = :HATKBN, ")            ' 発
                strSQL.Append("    PAGEKBN      = :PAGEKBN, ")           ' 改
                strSQL.Append("    PERIODKBN    = :PERIODKBN, ")         ' 期
                strSQL.Append("    FAX1         = :FAX1, ")              ' FAX1
                strSQL.Append("    FAX2         = :FAX2, ")              ' FAX2
                strSQL.Append("    MAIL1        = :MAIL1, ")             ' ﾒｰﾙ1
                strSQL.Append("    MAIL2        = :MAIL2, ")             ' ﾒｰﾙ2
                strSQL.Append("    MAIL_PASSWORD= :MAIL_PASSWORD, ")     ' ﾒｰﾙﾊﾟｽﾜｰﾄﾞ
                strSQL.Append("    ZEROSENDKBN  = :ZEROSENDKBN, ")       ' ０
                strSQL.Append("    SD_PRT       = :SD_PRT, ")            ' 出動依頼内容・備考表示フラグ
                'strSQL.Append("    JOTAI        = NULL, ")               ' 状態
                'strSQL.Append("    LASTSENDDATE = NULL, ")              ' 完了
                strSQL.Append("    NEXTSENDDATE = :NEXTSENDDATE, ")      ' 次回
                strSQL.Append("    SENDSTOPKBN  = :SENDSTOPKBN, ")       ' 停止
                strSQL.Append("    SENDSTDATE   = :SENDSTDATE, ")        ' 送信開始日
                strSQL.Append("    SENDEDDATE   = :SENDEDDATE, ")        ' 送信終了日
                strSQL.Append("    BIKO         = :BIKO, ")              ' 備考
                'strSQL.Append("    INS_DATE     = :INS_DATE, ")          ' 更新日
                strSQL.Append("    UPD_DATE     = SYSDATE, ")          ' 更新日
                strSQL.Append("    ZIP_FILE_NAME = :ZIP_FILE_NAME ")     ' zipファイル名

                strSQL.Append("WHERE   ")
                strSQL.Append("      ID  =:ID  ")                  '県コード

            ElseIf pintMODE = 1 Then
                '--------------------
                ' ID採番
                '--------------------
                strSQL = New StringBuilder
                strSQL.Append("SELECT MAX(ID) FROM B10_BTRUIJAE ")
                Try
                    cdb.pSQL = strSQL.ToString()
                    cdb.mExecQuery() 'SQL実行！

                    '結果をデータセットに格納
                    ds = cdb.pResult

                    'データが存在しない場合
                    If ds.Tables(0).Rows.Count = 0 Then
                        'データが0件であることを示す文字列を返す
                        re = 0
                    Else
                        'データローにデータセットを格納
                        re = Convert.ToInt16(ds.Tables(0).Rows(0).Item(0))
                    End If
                Catch ex As Exception
                    ' ex.ToString
                    re = 0
                Finally
                End Try
                newId = re + 1
                '--------------------
                ' 送信順採番（入力なしの場合）
                '--------------------
                If pstrSEND.Trim.Length = 0 Then
                    strSQL = New StringBuilder
                    strSQL.Append("SELECT MAX(SEQ) FROM B10_BTRUIJAE ")
                    Try
                        cdb.pSQL = strSQL.ToString()
                        cdb.mExecQuery() 'SQL実行！

                        '結果をデータセットに格納
                        ds = cdb.pResult

                        'データが存在しない場合
                        If ds.Tables(0).Rows.Count = 0 Then
                            'データが0件であることを示す文字列を返す
                            re = 0
                        Else
                            'データローにデータセットを格納
                            re = Convert.ToInt16(ds.Tables(0).Rows(0).Item(0))
                        End If
                    Catch ex As Exception
                        ' ex.ToString
                        re = 0
                    Finally
                    End Try
                    newSEQ = re + 1
                End If
                '処理区分が新規
                strSQL = New StringBuilder("")
                strSQL.Append("INSERT INTO ")
                strSQL.Append("B10_BTRUIJAE (")
                strSQL.Append("    ID, ")
                strSQL.Append("    SEQ, ")
                strSQL.Append("    KURACD, ")
                strSQL.Append("    HAISO_CD, ")
                strSQL.Append("    ACBCD_FR, ")
                strSQL.Append("    ACBCD_TO, ")
                strSQL.Append("    HATKBN, ")
                strSQL.Append("    PAGEKBN, ")
                strSQL.Append("    PERIODKBN, ")
                strSQL.Append("    FAX1, ")
                strSQL.Append("    FAX2, ")
                strSQL.Append("    MAIL1, ")
                strSQL.Append("    MAIL2, ")
                strSQL.Append("    ZEROSENDKBN, ")
                strSQL.Append("    SD_PRT, ")               '2020/11/01 T.Ono add 2020監視改善
                strSQL.Append("    JOTAI, ")
                strSQL.Append("    LASTSENDDATE, ")
                strSQL.Append("    NEXTSENDDATE, ")
                strSQL.Append("    SENDSTOPKBN, ")
                strSQL.Append("    SENDSTDATE, ")
                strSQL.Append("    SENDEDDATE, ")
                strSQL.Append("    BIKO, ")
                strSQL.Append("    DEL_FLG, ")
                strSQL.Append("    INS_DATE, ")
                strSQL.Append("    UPD_DATE, ")
                strSQL.Append("    MAIL_PASSWORD, ")
                strSQL.Append("    ZIP_FILE_NAME ")
                strSQL.Append(") VALUES ( ")
                strSQL.Append("    :ID, ")
                strSQL.Append("    :SEQ, ")
                strSQL.Append("    :KURACD, ")
                strSQL.Append("    :HAISO_CD, ")
                strSQL.Append("    :ACBCD_FR, ")
                strSQL.Append("    :ACBCD_TO, ")
                strSQL.Append("    :HATKBN, ")
                strSQL.Append("    :PAGEKBN, ")
                strSQL.Append("    :PERIODKBN, ")
                strSQL.Append("    :FAX1, ")
                strSQL.Append("    :FAX2, ")
                strSQL.Append("    :MAIL1, ")
                strSQL.Append("    :MAIL2, ")
                strSQL.Append("    :ZEROSENDKBN, ")
                strSQL.Append("    :SD_PRT, ")              '2020/11/01 T.Ono add 2020監視改善
                strSQL.Append("    'OK', ")
                strSQL.Append("    NULL, ")
                strSQL.Append("    :NEXTSENDDATE, ")
                strSQL.Append("    :SENDSTOPKBN, ")
                strSQL.Append("    :SENDSTDATE, ")
                strSQL.Append("    :SENDEDDATE, ")
                strSQL.Append("    :BIKO, ")
                strSQL.Append("    '0', ")
                strSQL.Append("    SYSDATE, ")
                strSQL.Append("    NULL, ")
                strSQL.Append("    :MAIL_PASSWORD, ")
                strSQL.Append("    :ZIP_FILE_NAME ")
                strSQL.Append(")")
            End If

            'SQL文セット
            cdb.pSQL = strSQL.ToString
            'バインド変数に値をセット
            If pintMODE = 3 Then
                cdb.pSQLParamStr("ID") = pstrID                 'ID
            ElseIf pintMODE = 1 Or pintMODE = 2 Then

                If pintMODE = 1 Then
                    cdb.pSQLParamStr("ID") = Convert.ToString(newId)     'ID
                Else
                    cdb.pSQLParamStr("ID") = pstrID                      'ID
                End If
                '2014/03/10 T.Ono mod 送信順の入力が無い場合は、自動採番
                'cdb.pSQLParamStr("SEQ") = pstrSEND                   '送信順
                If pstrSEND.Trim.Length > 0 Then
                    cdb.pSQLParamStr("SEQ") = pstrSEND                   '送信順
                Else
                    cdb.pSQLParamStr("SEQ") = Convert.ToString(newSEQ)   '送信順（自動採番）
                End If
                cdb.pSQLParamStr("KURACD") = pstrKURACD              'クライアントコード
                cdb.pSQLParamStr("HAISO_CD") = pstrKYOKYUCD          '供給センター
                cdb.pSQLParamStr("ACBCD_FR") = pstrACBCDFR           'JA支所FROM
                cdb.pSQLParamStr("ACBCD_TO") = pstrACBCDTO           'JA支所TO
                cdb.pSQLParamStr("HATKBN") = pstrHASSEI              '発生区分
                cdb.pSQLParamStr("PAGEKBN") = pstrKAIPAGE            '改ページ条件
                cdb.pSQLParamStr("PERIODKBN") = pstrKIKAN            '期間条件
                cdb.pSQLParamStr("FAX1") = pstrFAX1                  'FAX1
                cdb.pSQLParamStr("FAX2") = pstrFAX2                  'FAX2
                cdb.pSQLParamStr("MAIL1") = pstrMAIL1                'メール1
                cdb.pSQLParamStr("MAIL2") = pstrMAIL2                'メール2
                cdb.pSQLParamStr("ZEROSENDKBN") = pstrZEROSEND       '0件送信区分
                cdb.pSQLParamStr("SD_PRT") = pstrSD_PRT              '出動依頼内容・備考表示フラグ
                'cdb.pSQLParamStr("JOTAI") = "OK"                     '状態
                'cdb.pSQLParamStr("LASTSENDDATE") = ""                '最終正常送信日
                cdb.pSQLParamStr("NEXTSENDDATE") = pstrNXSEND        '次回送信日
                cdb.pSQLParamStr("SENDSTOPKBN") = pstrSNDSTOP        '送信停止区分
                cdb.pSQLParamStr("SENDSTDATE") = pstrSENDSTR         '送信開始日
                cdb.pSQLParamStr("SENDEDDATE") = pstrSENDEND         '送信終了日
                cdb.pSQLParamStr("BIKO") = pstrBIKOU                 '備考
                cdb.pSQLParamStr("MAIL_PASSWORD") = pstrMAILPASS     'メールパスワード
                cdb.pSQLParamStr("ZIP_FILE_NAME") = pstrZIPFILE      'ZIPファイル名
                'If pintMODE = 1 Then
                '新規登録の場合
                'cdb.pSQLParamStr("INS_DATE") = Now.ToString("yyyyMMdd")
                'cdb.pSQLParamStr("UPD_DATE") = ""
                '            Else
                '修正登録の場合
                '               cdb.pSQLParamStr("INS_DATE") = pstrADD_DT
                '              cdb.pSQLParamStr("UPD_DATE") = Now.ToString("yyyyMMdd")
                '         End If
            End If

            'SQLを実行
            cdb.mExecNonQuery()

        Catch ex As NullReferenceException
            strRes = "0"
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
    '*　概　要:需要家更新・削除一覧の出力を行います
    '*　備　考:
    '******************************************************************************
    '　DATA0:対象データがありません
    <WebMethod()> Public Function mCSV( _
                                        ByVal pstrSessionID As String, _
                                        ByVal pstrKURACD As String _
                                        ) As String

        Dim strSQL As New StringBuilder("")
        Dim cdb As New CDB
        Dim ds As New DataSet
        Dim dr As DataRow
        Dim CSVC As New CCSV                            'CSVクラス
        Dim compressC As New CCompress                  '圧縮クラス
        Dim DateFncC As New CDateFnc                    '日付変換クラス
        Dim CTimeFncC As New CTimeFnc                   '時間変換クラス
        Dim FileToStrC As New CFileStr                  'ファイルをBase64にエンコードするクラス
        Dim intPrntRow As Integer = 72

        Dim strTmp() As String

        Dim i As Integer ' 2011/05/17 T.Watabe add


        '接続OPEN----------------------------------------
        Try
            cdb.mOpen()
        Catch ex As Exception
            Return ex.ToString
        Finally
        End Try
        Try
            strSQL = New StringBuilder("")
            strSQL.Append("SELECT ")
            strSQL.Append("A.ID, ")
            strSQL.Append("A.SEQ, ")
            strSQL.Append("A.KURACD, ")
            strSQL.Append("A.HAISO_CD, ")
            strSQL.Append("A.ACBCD_FR, ")
            strSQL.Append("A.ACBCD_TO, ")
            strSQL.Append("A.HATKBN, ")
            strSQL.Append("A.PAGEKBN, ")
            strSQL.Append("A.PERIODKBN, ")
            strSQL.Append("A.FAX1, ")
            strSQL.Append("A.FAX2, ")
            strSQL.Append("A.MAIL1, ")
            strSQL.Append("A.MAIL2, ")
            strSQL.Append("A.ZEROSENDKBN, ")
            strSQL.Append("A.SD_PRT, ")                 '2020/11/01 T.Ono add 2020監視改善
            strSQL.Append("A.JOTAI, ")
            strSQL.Append("A.LASTSENDDATE, ")
            strSQL.Append("A.NEXTSENDDATE, ")
            strSQL.Append("A.SENDSTOPKBN, ")
            strSQL.Append("A.SENDSTDATE, ")
            strSQL.Append("A.SENDEDDATE, ")
            strSQL.Append("A.MAIL_PASSWORD, ")
            strSQL.Append("A.ZIP_FILE_NAME, ")
            strSQL.Append("A.INS_DATE, ")
            strSQL.Append("A.UPD_DATE, ")
            strSQL.Append("A.BIKO ")
            strSQL.Append("FROM ")
            strSQL.Append("  B10_BTRUIJAE A ")
            '2014/03/07 T.Ono mod クライアントコードの指定は任意
            'strSQL.Append("WHERE KURACD  =:KURACD  ")
            strSQL.Append("WHERE 1=1 ")
            If pstrKURACD.Trim.Length > 0 Then
                strSQL.Append("AND KURACD  =:KURACD ")
            End If
            strSQL.Append("AND A.DEL_FLG  = '0' ")
            strSQL.Append("ORDER BY TO_NUMBER(SEQ)  ")
            'SQL文セット
            cdb.pSQL = strSQL.ToString

            'パラメータに値をセット
            '2014/03/07 T.Ono mod クライアントコードの指定は任意
            'cdb.pSQLParamStr("KURACD") = pstrKURACD
            If pstrKURACD.Trim.Length > 0 Then
                cdb.pSQLParamStr("KURACD") = pstrKURACD.Trim
            End If

            'SQL実行
            cdb.mExecQuery()
            ds = cdb.pResult
            CSVC.pKencd = "00"
            CSVC.pSessionID = pstrSessionID   'セッションID
            CSVC.pRepoID = "MSRUIJAW00"       '帳票ID
            CSVC.mOpen()
            Dim iCnt As Integer
            Dim irCnt As Integer
            For iCnt = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(iCnt)
                If iCnt = 0 Then
                    CSVC.pColValStrEx = "ID"
                    CSVC.pColValStrEx = "送信順"
                    CSVC.pColValStrEx = "クライアントコード"
                    CSVC.pColValStrEx = "供給センターコード"
                    CSVC.pColValStrEx = "JA支所FROM"
                    CSVC.pColValStrEx = "JA支所TO"
                    CSVC.pColValStrEx = "発生区分"
                    CSVC.pColValStrEx = "改ページ条件"
                    CSVC.pColValStrEx = "期間条件"
                    CSVC.pColValStrEx = "FAX番号1"
                    CSVC.pColValStrEx = "FAX番号2"
                    CSVC.pColValStrEx = "メール番号1"
                    CSVC.pColValStrEx = "メール番号2"
                    CSVC.pColValStrEx = "0件送信区分"
                    CSVC.pColValStrEx = "出動内容・備考表示フラグ"      '2020/11/01 T.Ono add 2020監視改善
                    CSVC.pColValStrEx = "状態"
                    CSVC.pColValStrEx = "最終正常送信日"
                    CSVC.pColValStrEx = "次回送信日"
                    CSVC.pColValStrEx = "送信停止区分"
                    CSVC.pColValStrEx = "送信開始日"
                    CSVC.pColValStrEx = "送信終了日"
                    CSVC.pColValStrEx = "メールパスワード"
                    CSVC.pColValStrEx = "ZIPファイル名"
                    CSVC.pColValStrEx = "登録日時"
                    CSVC.pColValStrEx = "更新日時"
                    CSVC.pColValStrEx = "備考"
                    CSVC.mWriteLine()
                End If
                For irCnt = 0 To dr.Table.Columns.Count - 1
                    CSVC.pColValStrEx = Convert.ToString(dr.Item(irCnt))
                Next
                CSVC.mWriteLine()
            Next
            CSVC.mClose()
            Return CSVC.pDirName & CSVC.pFileName
        Catch ex As Exception
            'エラーの内容とＳＱＬ文を返すbaba
            Return "ERROR:" & ex.ToString

        Finally
            cdb.mClose()        '接続クローズ
        End Try

    End Function
    '**********************************************************
    ' 2012/06/28 ADD W.GANEKO
    'ログ吐き出し
    '戻り値：書き込んだファイルへのフルパス
    '**********************************************************
    Public Sub mlog(ByVal pstrString As String)
        Dim strFilnm As String = "testRUISEKI" & System.DateTime.Today.ToString("yyyyMMdd")
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
