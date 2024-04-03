'***********************************************
'自動対応内容マスタ
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


<System.Web.Services.WebService(Namespace:="http://tempuri.org/MSJINJAW00/Service1")> _
Public Class MSJINJAW00
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
                                    ByVal pstrGROUPCD As String, _
                                    ByVal pstrKMCD() As String, _
                                    ByVal pstrKMNM() As String, _
                                    ByVal pstrPROCKBN() As String, _
                                    ByVal pstrTAIOKBN() As String, _
                                    ByVal pstrTMSKB() As String, _
                                    ByVal pstrTKTANCD() As String, _
                                    ByVal pstrTAITCD() As String, _
                                    ByVal pstrTFKICD() As String, _
                                    ByVal pstrTKIGCD() As String, _
                                    ByVal pstrTSADCD() As String, _
                                    ByVal pstrTELRCD() As String, _
                                    ByVal pstrTEL_MEMO1() As String, _
                                    ByVal pstrUSE_FLG() As String, _
                                    ByVal pstrINS_DATE() As String, _
                                    ByVal pstrUPD_DATE() As String, _
                                    ByVal pstrBIKO() As String, _
                                    ByVal pstrDEL() As String
                                    ) As String

        ' ------------------------------
        '配列を空で用意
        Dim strKMCD() As String
        strKMCD = New String(pstrKMCD.Length) {} '配列の実体を確保
        Dim strKMNM() As String
        strKMNM = New String(pstrKMNM.Length) {} '配列の実体を確保
        Dim strPROCKBN() As String
        strPROCKBN = New String(pstrPROCKBN.Length) {} '配列の実体を確保
        Dim strTAIOKBN() As String
        strTAIOKBN = New String(pstrTAIOKBN.Length) {} '配列の実体を確保
        Dim strTMSKB() As String
        strTMSKB = New String(pstrTMSKB.Length) {} '配列の実体を確保
        Dim strTKTANCD() As String
        strTKTANCD = New String(pstrTKTANCD.Length) {} '配列の実体を確保
        Dim strTAITCD() As String
        strTAITCD = New String(pstrTAITCD.Length) {} '配列の実体を確保
        Dim strTFKICD() As String
        strTFKICD = New String(pstrTFKICD.Length) {} '配列の実体を確保
        Dim strTKIGCD() As String
        strTKIGCD = New String(pstrTKIGCD.Length) {} '配列の実体を確保
        Dim strTSADCD() As String
        strTSADCD = New String(pstrTSADCD.Length) {} '配列の実体を確保
        Dim strTELRCD() As String
        strTELRCD = New String(pstrTELRCD.Length) {} '配列の実体を確保
        Dim strTEL_MEMO1() As String
        strTEL_MEMO1 = New String(pstrTEL_MEMO1.Length) {} '配列の実体を確保
        Dim strUSE_FLG() As String
        strUSE_FLG = New String(pstrUSE_FLG.Length) {} '配列の実体を確保
        Dim strDEL() As String
        strDEL = New String(pstrDEL.Length) {} '配列の実体を確保
        Dim strINS_DATE() As String
        strINS_DATE = New String(pstrINS_DATE.Length) {} '配列の実体を確保
        Dim strUPD_DATE() As String
        strUPD_DATE = New String(pstrUPD_DATE.Length) {} '配列の実体を確保
        Dim strBIKO() As String
        strBIKO = New String(pstrBIKO.Length) {} '配列の実体を確保

        Dim i As Integer
        For i = 0 To strKMCD.Length
            strKMCD(i) = ""
            strKMNM(i) = ""
            strPROCKBN(i) = ""
            strTAIOKBN(i) = ""
            strTMSKB(i) = ""
            strTKTANCD(i) = ""
            strTAITCD(i) = ""
            strTFKICD(i) = ""
            strTKIGCD(i) = ""
            strTSADCD(i) = ""
            strTELRCD(i) = ""
            strTEL_MEMO1(i) = ""
            strUSE_FLG(i) = ""
            strINS_DATE(i) = ""
            strUPD_DATE(i) = ""
            strBIKO(i) = ""
            strDEL(i) = ""
        Next
        ' ------------------------------

        '2017/02/09 W.GANEKO UPD 2016監視改善 №10
        'Return mSetEx(pintMODE, _
        '            pstrGROUPCD, _
        '            pstrKMCD, _
        '            pstrKMNM, _
        '            pstrPROCKBN, _
        '            pstrTAIOKBN, _
        '            pstrTMSKB, _
        '            pstrTKTANCD, _
        '            pstrTAITCD, _
        '            pstrTFKICD, _
        '            pstrTKIGCD, _
        '            pstrTSADCD, _
        '            pstrTELRCD, _
        '            pstrTEL_MEMO1, _
        '            pstrUSE_FLG, _
        '            pstrINS_DATE, _
        '            pstrUPD_DATE, _
        '            pstrBIKO, _
        '            pstrDEL)
        Return mSetEx(pintMODE, _
           pstrGROUPCD, _
           pstrKMCD, _
           pstrKMNM, _
           pstrPROCKBN, _
           pstrTAIOKBN, _
           pstrTMSKB, _
           pstrTKTANCD, _
           pstrTAITCD, _
           pstrTFKICD, _
           pstrTKIGCD, _
           pstrTSADCD, _
           pstrTELRCD, _
           pstrTEL_MEMO1, _
           pstrUSE_FLG, _
           pstrINS_DATE, _
           pstrUPD_DATE, _
           pstrBIKO, _
           pstrDEL, _
           "")
    End Function
    '2017/02/09 W.GANEKO UPD 2016監視改善 №10
    '<WebMethod()> Public Function mSetEx( _
    '                                ByVal pintMODE As Integer, _
    '                                ByVal pstrGROUPCD As String, _
    '                                ByVal pstrKMCD() As String, _
    '                                ByVal pstrKMNM() As String, _
    '                                ByVal pstrPROCKBN() As String, _
    '                                ByVal pstrTAIOKBN() As String, _
    '                                ByVal pstrTMSKB() As String, _
    '                                ByVal pstrTKTANCD() As String, _
    '                                ByVal pstrTAITCD() As String, _
    '                                ByVal pstrTFKICD() As String, _
    '                                ByVal pstrTKIGCD() As String, _
    '                                ByVal pstrTSADCD() As String, _
    '                                ByVal pstrTELRCD() As String, _
    '                                ByVal pstrTEL_MEMO1() As String, _
    '                                ByVal pstrUSE_FLG() As String, _
    '                                ByVal pstrINS_DATE() As String, _
    '                                ByVal pstrUPD_DATE() As String, _
    '                                ByVal pstrBIKO() As String, _
    '                                ByVal pstrDEL() As String
    '                                ) As String
    <WebMethod()> Public Function mSetEx( _
                                    ByVal pintMODE As Integer, _
                                    ByVal pstrGROUPCD As String, _
                                    ByVal pstrKMCD() As String, _
                                    ByVal pstrKMNM() As String, _
                                    ByVal pstrPROCKBN() As String, _
                                    ByVal pstrTAIOKBN() As String, _
                                    ByVal pstrTMSKB() As String, _
                                    ByVal pstrTKTANCD() As String, _
                                    ByVal pstrTAITCD() As String, _
                                    ByVal pstrTFKICD() As String, _
                                    ByVal pstrTKIGCD() As String, _
                                    ByVal pstrTSADCD() As String, _
                                    ByVal pstrTELRCD() As String, _
                                    ByVal pstrTEL_MEMO1() As String, _
                                    ByVal pstrUSE_FLG() As String, _
                                    ByVal pstrINS_DATE() As String, _
                                    ByVal pstrUPD_DATE() As String, _
                                    ByVal pstrBIKO() As String, _
                                    ByVal pstrDEL() As String, _
                                    ByVal pstrGROUPNM As String
                                   ) As String
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
                mlog("loop:" & pstrDEL(i) & pstrGROUPCD & "_" & pstrKMCD(i) & "_" & pstrKMNM(i))

                '2017/02/09 W.GANEKO UPD 2016監視改善 №10
                'strRes = mSetTanto( _
                '        cdb, _
                '        pintMODE, _
                '        pstrGROUPCD, _
                '        pstrKMCD(i), _
                '        pstrKMNM(i), _
                '        pstrPROCKBN(i), _
                '        pstrTAIOKBN(i), _
                '        pstrTMSKB(i), _
                '        pstrTKTANCD(i), _
                '        pstrTAITCD(i), _
                '        pstrTFKICD(i), _
                '        pstrTKIGCD(i), _
                '        pstrTSADCD(i), _
                '        pstrTELRCD(i), _
                '        pstrTEL_MEMO1(i), _
                '        pstrUSE_FLG(i), _
                '        pstrINS_DATE(i), _
                '        pstrUPD_DATE(i), _
                '        pstrBIKO(i), _
                '        pstrDEL(i))
                strRes = mSetTanto( _
                        cdb, _
                        pintMODE, _
                        pstrGROUPCD, _
                        pstrKMCD(i), _
                        pstrKMNM(i), _
                        pstrPROCKBN(i), _
                        pstrTAIOKBN(i), _
                        pstrTMSKB(i), _
                        pstrTKTANCD(i), _
                        pstrTAITCD(i), _
                        pstrTFKICD(i), _
                        pstrTKIGCD(i), _
                        pstrTSADCD(i), _
                        pstrTELRCD(i), _
                        pstrTEL_MEMO1(i), _
                        pstrUSE_FLG(i), _
                        pstrINS_DATE(i), _
                        pstrUPD_DATE(i), _
                        pstrBIKO(i), _
                        pstrDEL(i), _
                        pstrGROUPNM)
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
    '2017/02/09 W.GANEKO UPD 2016監視改善 №10
    '<WebMethod()> Public Function mSetTanto( _
    '                            ByRef cdb As CDB, _
    '                            ByVal pintMODE As Integer, _
    '                            ByVal pstrGROUPCD As String, _
    '                            ByVal pstrKMCD As String, _
    '                            ByVal pstrKMNM As String, _
    '                            ByVal pstrPROCKBN As String, _
    '                            ByVal pstrTAIOKBN As String, _
    '                            ByVal pstrTMSKB As String, _
    '                            ByVal pstrTKTANCD As String, _
    '                            ByVal pstrTAITCD As String, _
    '                            ByVal pstrTFKICD As String, _
    '                            ByVal pstrTKIGCD As String, _
    '                            ByVal pstrTSADCD As String, _
    '                            ByVal pstrTELRCD As String, _
    '                            ByVal pstrTEL_MEMO1 As String, _
    '                            ByVal pstrUSE_FLG As String, _
    '                            ByVal pstrINS_DATE As String, _
    '                            ByVal pstrUPD_DATE As String, _
    '                            ByVal pstrBIKO As String, _
    '                            ByVal pstrDEL As String
    '                            ) As String
    <WebMethod()> Public Function mSetTanto( _
                                ByRef cdb As CDB, _
                                ByVal pintMODE As Integer, _
                                ByVal pstrGROUPCD As String, _
                                ByVal pstrKMCD As String, _
                                ByVal pstrKMNM As String, _
                                ByVal pstrPROCKBN As String, _
                                ByVal pstrTAIOKBN As String, _
                                ByVal pstrTMSKB As String, _
                                ByVal pstrTKTANCD As String, _
                                ByVal pstrTAITCD As String, _
                                ByVal pstrTFKICD As String, _
                                ByVal pstrTKIGCD As String, _
                                ByVal pstrTSADCD As String, _
                                ByVal pstrTELRCD As String, _
                                ByVal pstrTEL_MEMO1 As String, _
                                ByVal pstrUSE_FLG As String, _
                                ByVal pstrINS_DATE As String, _
                                ByVal pstrUPD_DATE As String, _
                                ByVal pstrBIKO As String, _
                                ByVal pstrDEL As String, _
                                ByVal pstrGROUPNM As String
                                ) As String
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
            strSQL.Append("  	    A.GROUPCD ")
            strSQL.Append(" 	    ,A.KMCD ")
            strSQL.Append(" 	    ,A.KMNM ")
            strSQL.Append(" 	    ,A.PROCKBN ")
            strSQL.Append(" 	    ,A.TAIOKBN ")
            strSQL.Append(" 	    ,A.TMSKB ")
            strSQL.Append(" 	    ,A.TKTANCD ")
            strSQL.Append(" 	    ,A.TAITCD ")
            strSQL.Append(" 	    ,A.TFKICD ")
            strSQL.Append(" 	    ,A.TKIGCD ")
            strSQL.Append(" 	    ,A.TSADCD ")
            strSQL.Append(" 	    ,A.TELRCD ")
            strSQL.Append(" 	    ,A.TEL_MEMO1 ")
            strSQL.Append(" 	    ,A.USE_FLG ")
            strSQL.Append(" 	    ,A.INS_DATE ")
            strSQL.Append(" 	    ,A.UPD_DATE ")
            strSQL.Append(" 		,A.BIKO ")
            strSQL.Append(" 		,A.GROUPNM ") '2017/02/09 W.GANEKO 2016監視改善 №10
            strSQL.Append("FROM ")
            strSQL.Append("		M08_AUTOTAIOU A ")
            strSQL.Append("WHERE ")
            strSQL.Append("		A.GROUPCD = :GROUPCD ")
            strSQL.Append("AND		A.KMCD = :KMCD ")
            strSQL.Append("AND		A.KMNM = :KMNM ")
            strSQL.Append("ORDER BY A.KMCD ")
            strSQL.Append("FOR UPDATE NOWAIT ")             '排他制御をかける

            'SQL文セット
            cdb.pSQL = strSQL.ToString

            'パラメータに値をセット
            cdb.pSQLParamStr("GROUPCD") = pstrGROUPCD       'グループコード
            cdb.pSQLParamStr("KMCD") = pstrKMCD             '警報コード
            cdb.pSQLParamStr("KMNM") = pstrKMNM             '警報名称

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
                If pstrKMCD = "" Then '登録元データはない？
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
                tmp = Convert.ToString(ds.Tables(0).Rows(0).Item("INS_DATE")) & "_" & Convert.ToString(ds.Tables(0).Rows(0).Item("UPD_DATE"))
                If (tmp <> pstrINS_DATE & "_" & pstrUPD_DATE) Then
                    strRes = "0"
                    Exit Try
                End If
            End If

            If (pintMODE = 2) Then 'ＤＢにデータが存在して、更新の場合
                '*******************************************
                '修正時で受け渡された日付及び時間と更新対象データが異なる場合エラー
                '*******************************************
                tmp = Convert.ToString(ds.Tables(0).Rows(0).Item("INS_DATE")) & "_" & Convert.ToString(ds.Tables(0).Rows(0).Item("UPD_DATE"))
                If (tmp <> pstrINS_DATE & "_" & pstrUPD_DATE) Then
                    strRes = "0"
                    Exit Try
                End If

                '*******************************************
                ' 修正時でデータが変更されていない場合はスキップ
                '*******************************************
                '2017/02/09 W.GANEKO 2016監視改善 №10
                'If ( _
                '        (Convert.ToString(ds.Tables(0).Rows(0).Item("KMCD")) = pstrKMCD) And _
                '        (Convert.ToString(ds.Tables(0).Rows(0).Item("KMNM")) = pstrKMNM) And _
                '        (Convert.ToString(ds.Tables(0).Rows(0).Item("PROCKBN")) = pstrPROCKBN) And _
                '        (Convert.ToString(ds.Tables(0).Rows(0).Item("TAIOKBN")) = pstrTAIOKBN) And _
                '        (Convert.ToString(ds.Tables(0).Rows(0).Item("TMSKB")) = pstrTMSKB) And _
                '        (Convert.ToString(ds.Tables(0).Rows(0).Item("TKTANCD")) = pstrTKTANCD) And _
                '        (Convert.ToString(ds.Tables(0).Rows(0).Item("TAITCD")) = pstrTAITCD) And _
                '        (Convert.ToString(ds.Tables(0).Rows(0).Item("TFKICD")) = pstrTFKICD) And _
                '        (Convert.ToString(ds.Tables(0).Rows(0).Item("TKIGCD")) = pstrTKIGCD) And _
                '        (Convert.ToString(ds.Tables(0).Rows(0).Item("TSADCD")) = pstrTSADCD) And _
                '        (Convert.ToString(ds.Tables(0).Rows(0).Item("TELRCD")) = pstrTELRCD) And _
                '        (Convert.ToString(ds.Tables(0).Rows(0).Item("TEL_MEMO1")) = pstrTEL_MEMO1) And _
                '        (Convert.ToString(ds.Tables(0).Rows(0).Item("USE_FLG")) = pstrUSE_FLG) And _
                '        (Convert.ToString(ds.Tables(0).Rows(0).Item("BIKO")) = pstrBIKO) _
                '     ) Then
                If ( _
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("KMCD")) = pstrKMCD) And _
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("KMNM")) = pstrKMNM) And _
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("PROCKBN")) = pstrPROCKBN) And _
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("TAIOKBN")) = pstrTAIOKBN) And _
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("TMSKB")) = pstrTMSKB) And _
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("TKTANCD")) = pstrTKTANCD) And _
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("TAITCD")) = pstrTAITCD) And _
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("TFKICD")) = pstrTFKICD) And _
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("TKIGCD")) = pstrTKIGCD) And _
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("TSADCD")) = pstrTSADCD) And _
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("TELRCD")) = pstrTELRCD) And _
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("TEL_MEMO1")) = pstrTEL_MEMO1) And _
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("USE_FLG")) = pstrUSE_FLG) And _
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("BIKO")) = pstrBIKO) And _
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("GROUPNM")) = pstrGROUPNM) _
                     ) Then

                    pintMODE = 4 'スキップ
                End If
            End If

            If pintMODE = 4 Then
                'スキップ→次のレコード
                Exit Try
            End If


            'データの更新処理--------------------------------

            If pintMODE = 3 Then
                '処理区分が削除
                strSQL = New StringBuilder("")
                strSQL.Append("DELETE ")
                strSQL.Append("FROM ")
                strSQL.Append("			M08_AUTOTAIOU ")
                strSQL.Append("WHERE ")
                strSQL.Append("			GROUPCD =:GROUPCD ")    'グループコード
                strSQL.Append("AND		KMCD =:KMCD ")          '警報コード
                strSQL.Append("AND		KMNM =:KMNM ")          '警報名称

            ElseIf pintMODE = 2 Then
                '処理区分が修正
                strSQL = New StringBuilder("")
                strSQL.Append("UPDATE ")
                strSQL.Append("         M08_AUTOTAIOU ")
                strSQL.Append("SET ")
                strSQL.Append("     	GROUPCD = :GROUPCD, ")
                strSQL.Append("     	KMCD = :KMCD, ")
                strSQL.Append("     	KMNM = :KMNM, ")
                strSQL.Append("     	PROCKBN = :PROCKBN, ")
                strSQL.Append("     	TAIOKBN = :TAIOKBN, ")
                strSQL.Append("     	TMSKB = :TMSKB, ")
                strSQL.Append("     	TKTANCD = :TKTANCD, ")
                strSQL.Append("     	TAITCD = :TAITCD, ")
                strSQL.Append("     	TFKICD = :TFKICD, ")
                strSQL.Append("     	TKIGCD = :TKIGCD, ")
                strSQL.Append("     	TSADCD = :TSADCD, ")
                strSQL.Append("     	TELRCD = :TELRCD, ")
                strSQL.Append("     	TEL_MEMO1 = :TEL_MEMO1, ")
                strSQL.Append("     	USE_FLG = :USE_FLG, ")
                strSQL.Append("     	INS_DATE = TO_DATE(:INS_DATE, 'YYYY/MM/DD HH24:MI:SS'), ")
                strSQL.Append("     	UPD_DATE = TO_DATE(:UPD_DATE, 'YYYY/MM/DD HH24:MI:SS'), ")
                strSQL.Append("     	BIKO = :BIKO, ")
                strSQL.Append("     	GROUPNM = :GROUPNM ")   '2017/02/09 W.GANEKO 2016監視改善 №10
                strSQL.Append("WHERE   ")
                strSQL.Append("         GROUPCD =:GROUPCD  ")
                strSQL.Append("  AND    KMCD =:KMCD ")
                strSQL.Append("  AND    KMNM =:KMNM ")

            ElseIf pintMODE = 1 Then
                '処理区分が新規
                strSQL = New StringBuilder("")
                strSQL.Append("INSERT INTO ")
                strSQL.Append(" M08_AUTOTAIOU (")
                strSQL.Append("     GROUPCD, ")
                strSQL.Append("     KMCD, ")
                strSQL.Append("     KMNM, ")
                strSQL.Append("     PROCKBN, ")
                strSQL.Append("     TAIOKBN, ")
                strSQL.Append("     TMSKB, ")
                strSQL.Append("     TKTANCD, ")
                strSQL.Append("     TAITCD, ")
                strSQL.Append("     TFKICD, ")
                strSQL.Append("     TKIGCD, ")
                strSQL.Append("     TSADCD, ")
                strSQL.Append("     TELRCD, ")
                strSQL.Append("     TEL_MEMO1, ")
                strSQL.Append("     USE_FLG, ")
                strSQL.Append("     INS_DATE, ")
                strSQL.Append("     UPD_DATE, ")
                strSQL.Append("     BIKO, ")
                strSQL.Append("     GROUPNM ")        '2017/02/09 W.GANEKO 2016監視改善 №10
                strSQL.Append(") VALUES(")
                strSQL.Append("		:GROUPCD, ")
                strSQL.Append("		:KMCD, ")
                strSQL.Append("		:KMNM, ")
                strSQL.Append("		:PROCKBN, ")
                strSQL.Append("		:TAIOKBN, ")
                strSQL.Append("		:TMSKB, ")
                strSQL.Append("		:TKTANCD, ")
                strSQL.Append("		:TAITCD, ")
                strSQL.Append("		:TFKICD, ")
                strSQL.Append("		:TKIGCD, ")
                strSQL.Append("		:TSADCD, ")
                strSQL.Append("		:TELRCD, ")
                strSQL.Append("		:TEL_MEMO1, ")
                strSQL.Append("		:USE_FLG, ")
                strSQL.Append("		TO_DATE(:INS_DATE, 'YYYY/MM/DD HH24:MI:SS'), ")
                strSQL.Append("		TO_DATE(:UPD_DATE, 'YYYY/MM/DD HH24:MI:SS'), ")
                strSQL.Append("		:BIKO, ")
                strSQL.Append("		:GROUPNM ")     '2017/02/09 W.GANEKO 2016監視改善 №10
                strSQL.Append(")")
            End If

            'SQL文セット
            cdb.pSQL = strSQL.ToString
            'バインド変数に値をセット
            If pintMODE = 3 Then
                cdb.pSQLParamStr("GROUPCD") = pstrGROUPCD
                cdb.pSQLParamStr("KMCD") = pstrKMCD
                cdb.pSQLParamStr("KMNM") = pstrKMNM
            ElseIf pintMODE = 1 Or pintMODE = 2 Then

                cdb.pSQLParamStr("GROUPCD") = pstrGROUPCD
                cdb.pSQLParamStr("KMCD") = pstrKMCD
                cdb.pSQLParamStr("KMNM") = pstrKMNM
                cdb.pSQLParamStr("PROCKBN") = pstrPROCKBN
                cdb.pSQLParamStr("TAIOKBN") = pstrTAIOKBN
                cdb.pSQLParamStr("TMSKB") = pstrTMSKB
                cdb.pSQLParamStr("TKTANCD") = pstrTKTANCD
                cdb.pSQLParamStr("TAITCD") = pstrTAITCD
                cdb.pSQLParamStr("TFKICD") = pstrTFKICD
                cdb.pSQLParamStr("TKIGCD") = pstrTKIGCD
                cdb.pSQLParamStr("TSADCD") = pstrTSADCD
                cdb.pSQLParamStr("TELRCD") = pstrTELRCD
                cdb.pSQLParamStr("TEL_MEMO1") = pstrTEL_MEMO1
                cdb.pSQLParamStr("GROUPNM") = pstrGROUPNM       '2017/02/09 W.GANEKO 2016監視改善 №10

                If pstrUSE_FLG = "" Then
                    cdb.pSQLParamStr("USE_FLG") = "1"
                Else
                    cdb.pSQLParamStr("USE_FLG") = pstrUSE_FLG
                End If
                cdb.pSQLParamStr("BIKO") = pstrBIKO

                If pintMODE = 1 Then
                    '新規登録の場合
                    cdb.pSQLParamStr("INS_DATE") = Now.ToString()
                    cdb.pSQLParamStr("UPD_DATE") = ""
                Else
                    '修正登録の場合
                    cdb.pSQLParamStr("INS_DATE") = pstrINS_DATE
                    cdb.pSQLParamStr("UPD_DATE") = Now.ToString()
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
    '******************************************************************************
    '*　概　要:一覧の出力を行います
    '*　備　考:
    '******************************************************************************
    '　DATA0:対象データがありません
    <WebMethod()> Public Function mCSV( _
                                        ByVal pstrSessionID As String, _
                                        ByVal pstrGROUPCD As String _
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
            strSQL.Append("SELECT ")
            strSQL.Append("      A.GROUPCD ")
            strSQL.Append("     ,A.KMCD ")
            strSQL.Append("     ,A.KMNM ")
            strSQL.Append("     ,A.PROCKBN ")
            strSQL.Append("     ,A.TAIOKBN ")
            strSQL.Append("     ,A.TMSKB ")
            strSQL.Append("     ,A.TKTANCD ")
            strSQL.Append("     ,A.TAITCD ")
            strSQL.Append("     ,A.TFKICD ")
            strSQL.Append("     ,A.TKIGCD ")
            strSQL.Append("     ,A.TSADCD ")
            strSQL.Append("     ,A.TELRCD ")
            strSQL.Append("     ,A.TEL_MEMO1 ")
            strSQL.Append("     ,A.USE_FLG ")
            strSQL.Append("     ,A.BIKO ")
            strSQL.Append("     ,A.INS_DATE ")
            strSQL.Append("     ,A.UPD_DATE ")
            strSQL.Append("     ,A.GROUPNM ")       '2017/02/09 W.GANEKO 2016監視改善 №10
            strSQL.Append("FROM M08_AUTOTAIOU A ")
            strSQL.Append("WHERE	A.GROUPCD = :GROUPCD ")
            strSQL.Append("ORDER BY A.KMCD ")
            'SQL文セット
            cdb.pSQL = strSQL.ToString

            'パラメータに値をセット
            '出動会社コード
            If pstrGROUPCD.Length > 0 Then
                cdb.pSQLParamStr("GROUPCD") = pstrGROUPCD
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
            CSVC.pRepoID = "MSJINJAW00"       '帳票ID
            CSVC.mOpen()
            Dim iCnt As Integer
            Dim irCnt As Integer
            For iCnt = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(iCnt)

                If iCnt = 0 Then
                    CSVC.pColValStrEx = "グループコード"
                    CSVC.pColValStrEx = "警報コード"
                    CSVC.pColValStrEx = "警報名称"
                    CSVC.pColValStrEx = "対応／無視区分"
                    CSVC.pColValStrEx = "対応区分"
                    CSVC.pColValStrEx = "処理区分"
                    CSVC.pColValStrEx = "監視ｾﾝﾀｰ担当者ｺｰﾄﾞ"
                    CSVC.pColValStrEx = "連絡相手"
                    CSVC.pColValStrEx = "復帰対応状況"
                    CSVC.pColValStrEx = "ガス器具"
                    CSVC.pColValStrEx = "作動原因"
                    CSVC.pColValStrEx = "電話連絡内容"
                    CSVC.pColValStrEx = "電話対応メモ"
                    CSVC.pColValStrEx = "使用フラグ"
                    CSVC.pColValStrEx = "備考"
                    CSVC.pColValStrEx = "登録日時"
                    CSVC.pColValStrEx = "更新日時"
                    CSVC.pColValStrEx = "グループコード名"  '2017/02/09 W.GANEKO 2016監視改善 №10
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
