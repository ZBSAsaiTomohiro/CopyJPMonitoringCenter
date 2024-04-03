'******************************************************************************
' 監視対応出力
' PGID: KETAISYW00.asmx.vb
'******************************************************************************
'変更履歴
' 2008/11/27 T.Watabe 監視コードの必須を外す
' 2009/01/23 T.Watabe 警報コードの表示が抜けていた点を修正
' 2009/03/24 T.Watabe 監視ｾﾝﾀｰ担当者、出動会社受付者、出動会社出動者の表示を追加
' 2011/05/17 T.Watabe FAX不要とFAXｸﾗｲﾝﾄ不要を帳票に出力追加
' 2014/12/09 H.Hosoda 監視改善2014 №13
' 2023/01/06 Y.ARAKAKI 2022更改No⑥ _帳票JMコード表示追加対応  excelOut1,excelOut2,excelOut4のExcel出力に、JMコード(D20_TAIOU.KINRENCD)及びJM和名(D20_TAIOU.JMNAME)を追加

Option Explicit On 
Option Strict On

Imports Common
Imports Common.DB

Imports System.Web.Services
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Configuration
Imports System.IO


<System.Web.Services.WebService(Namespace:="http://tempuri.org/KETAISYW00/Service1")> _
Public Class KETAISYW00
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
    '******************************************************************************
    '*　概　要:需要家更新・削除一覧の出力を行います
    '*　備　考:
    '*        
    '******************************************************************************
    '　DATA0:対象データがありません
    '2014/12/10 H.Hosoda mod 監視改善2014 №13 引数を追加
    '2019/11/01 T.Ono mod 監視改善2019 pstrJACDFrom_CLI,pstrJACDTo_CLI 追加
    '2020/01/06 T.Ono mod 災害対応帳票 pstrTSADCD,pstrTSADNM 追加 
    '<WebMethod()> Public Function mExcel( _
    '                                    ByVal pstrSessionID As String, _
    '                                    ByVal pstrKANSCD As String, _
    '                                    ByVal pstrTFKICD As String, _
    '                                    ByVal pstrStkbn1 As String, _
    '                                    ByVal pstrStkbn2 As String, _
    '                                    ByVal pstrPgkbn1 As String, _
    '                                    ByVal pstrPgkbn2 As String, _
    '                                    ByVal pstrPgkbn3 As String, _
    '                                    ByVal pstrTrgFrom As String, _
    '                                    ByVal pstrTrgTo As String, _
    '                                    ByVal pstrKURACDFrom As String, _
    '                                    ByVal pstrKURACDTo As String, _
    '                                    ByVal pstrJACDFrom As String, _
    '                                    ByVal pstrJACDTo As String _
    '                                    ) As String
    '2017/02/16 H.Mori mod 改善2016 No7-1 START
    '<WebMethod()> Public Function mExcel( _
    '                                    ByVal pstrSessionID As String, _
    '                                    ByVal pstrKANSCD As String, _
    '                                    ByVal pstrTFKICD As String, _
    '                                    ByVal pstrStkbn1 As String, _
    '                                    ByVal pstrStkbn2 As String, _
    '                                    ByVal pstrPgkbn1 As String, _
    '                                    ByVal pstrPgkbn2 As String, _
    '                                    ByVal pstrPgkbn3 As String, _
    '                                    ByVal pstrTrgFrom As String, _
    '                                    ByVal pstrTrgTo As String, _
    '                                    ByVal pstrKURACDFrom As String, _
    '                                    ByVal pstrKURACDTo As String, _
    '                                    ByVal pstrJACDFrom As String, _
    '                                    ByVal pstrJACDTo As String, _
    '                                    ByVal pstrHANGRPFrom As String, _
    '                                    ByVal pstrHANGRPTo As String, _
    '                                    ByVal pstrOUTKBN As String, _
    '                                    ByVal pstrKIKANKBN As String _
    '                                    ) As String
    '2017/02/17 W.GANEKO mod 改善2016 No7 START
    <WebMethod()> Public Function mExcel(
                                        ByVal pstrSessionID As String,
                                        ByVal pstrKANSCD As String,
                                        ByVal pstrTFKICD As String,
                                        ByVal pstrStkbn1 As String,
                                        ByVal pstrStkbn2 As String,
                                        ByVal pstrPgkbn1 As String,
                                        ByVal pstrPgkbn2 As String,
                                        ByVal pstrPgkbn3 As String,
                                        ByVal pstrTrgFrom As String,
                                        ByVal pstrTrgTo As String,
                                        ByVal pstrKURACDFrom As String,
                                        ByVal pstrKURACDTo As String,
                                        ByVal pstrJACDFrom As String,
                                        ByVal pstrJACDFrom_CLI As String,
                                        ByVal pstrJACDTo As String,
                                        ByVal pstrJACDTo_CLI As String,
                                        ByVal pstrHANGRPFrom As String,
                                        ByVal pstrHANGRPTo As String,
                                        ByVal pstrOUTKBN As String,
                                        ByVal pstrKIKANKBN As String,
                                        ByVal pstrTrgTimeFrom As String,
                                        ByVal pstrTrgTimeTo As String,
                                        ByVal pstrHOKBN As String,
                                        ByVal pstrOUTLIST As String,
                                        ByVal pstrTFKINM As String,
                                        ByVal pstrTSADCD As String,
                                        ByVal pstrTSADNM As String
                                        ) As String
        '2017/02/17 W.GANEKO mod 改善2016 No7 END
        '2017/02/16 H.Mori mod 改善2016 No7-1 END

        Dim strSQL As New StringBuilder("")
        Dim cdb As New CDB
        Dim ds As New DataSet
        Dim dr As DataRow
        'Dim intGYOSU As Integer = 5                     '改行制御を行う
        'Dim intGyoMax As Integer = CInt(pdecPageMax)    '最大行数
        Dim intGyoMax As Integer = 65535                '最大行数
        Dim ExcelC As New CExcel                        'Excelクラス
        Dim compressC As New CCompress                  '圧縮クラス
        Dim DateFncC As New CDateFnc                    '日付変換クラス
        Dim CTimeFncC As New CTimeFnc                   '時間変換クラス
        Dim FileToStrC As New CFileStr                  'ファイルをBase64にエンコードするクラス
        Dim strHedInfo As String                        'ヘッダー情報（抽出条件）
        Dim strHedInfoHasei As String                        'ヘッダー情報（抽出条件）
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

        '帳票出力項目の取得用SQL文セット-------------------
        Try
            '帳票出力項目の取得用SQL文セット
            '2017/02/16 H.Mori mod 改善2016 No7-1 引数を追加
            '2014/12/10 H.Hosoda mod 監視改善2014 №13 引数を追加
            '2017/02/17 W.GANEKO mod 改善2016 No7 引数を追加
            '2019/11/01 T.Ono mod 監視改善2019 pstrJACDFrom_CLI,pstrJACDTo_CLI 追加
            '2020/01/06 T.Ono mod 災害対応帳票 psrtTSADNM,psrtTSADNM 追加
            'strSQL.Append(fncMakeSelect(pstrKANSCD, _
            '                            pstrTFKICD, _
            '                            pstrStkbn1, _
            '                            pstrStkbn2, _
            '                            pstrPgkbn1, _
            '                            pstrPgkbn2, _
            '                            pstrPgkbn3, _
            '                            pstrTrgFrom, _
            '                            pstrTrgTo, _
            '                            pstrKURACDFrom, _
            '                            pstrKURACDTo, _
            '                            pstrJACDFrom, _
            '                            pstrJACDTo))
            'strSQL.Append(fncMakeSelect(pstrKANSCD, _
            '                            pstrTFKICD, _
            '                            pstrStkbn1, _
            '                            pstrStkbn2, _
            '                            pstrPgkbn1, _
            '                            pstrPgkbn2, _
            '                            pstrPgkbn3, _
            '                            pstrTrgFrom, _
            '                            pstrTrgTo, _
            '                            pstrKURACDFrom, _
            '                            pstrKURACDTo, _
            '                            pstrJACDFrom, _
            '                            pstrJACDTo, _
            '                            pstrHANGRPFrom, _
            '                            pstrHANGRPTo, _
            '                            pstrOUTKBN, _
            '                            pstrKIKANKBN))
            'strSQL.Append(fncMakeSelect(pstrKANSCD, _
            '                            pstrTFKICD, _
            '                            pstrStkbn1, _
            '                            pstrStkbn2, _
            '                            pstrPgkbn1, _
            '                            pstrPgkbn2, _
            '                            pstrPgkbn3, _
            '                            pstrTrgFrom, _
            '                            pstrTrgTo, _
            '                            pstrKURACDFrom, _
            '                            pstrKURACDTo, _
            '                            pstrJACDFrom, _
            '                            pstrJACDTo, _
            '                            pstrHANGRPFrom, _
            '                            pstrHANGRPTo, _
            '                            pstrOUTKBN, _
            '                            pstrKIKANKBN, _
            '                            pstrTrgTimeFrom, _
            '                            pstrTrgTimeTo))
            strSQL.Append(fncMakeSelect(pstrKANSCD,
                                        pstrTFKICD,
                                        pstrStkbn1,
                                        pstrStkbn2,
                                        pstrPgkbn1,
                                        pstrPgkbn2,
                                        pstrPgkbn3,
                                        pstrTrgFrom,
                                        pstrTrgTo,
                                        pstrKURACDFrom,
                                        pstrKURACDTo,
                                        pstrJACDFrom,
                                        pstrJACDFrom_CLI,
                                        pstrJACDTo,
                                        pstrJACDTo_CLI,
                                        pstrHANGRPFrom,
                                        pstrHANGRPTo,
                                        pstrOUTKBN,
                                        pstrKIKANKBN,
                                        pstrTrgTimeFrom,
                                        pstrTrgTimeTo,
                                        pstrHOKBN,
                                        pstrOUTLIST,
                                        pstrTFKINM,
                                        pstrTSADCD,
                                        pstrTSADNM))
            '2017/02/17 W.GANEKO mod 改善2016 No7 END
            cdb.pSQL = strSQL.ToString

            'パラメータセット
            '監視センターコード
            If pstrKANSCD <> "" Then ' 2008/11/27 T.Watabe add
                cdb.pSQLParamStr("KANSCD") = pstrKANSCD
            End If
            '監視センターコード
            If pstrKURACDFrom <> "" Then ' 2008/11/27 T.Watabe add
                cdb.pSQLParamStr("KURACD_FROM") = pstrKURACDFrom
            End If
            If pstrKURACDTo <> "" Then ' 2008/11/27 T.Watabe add
                cdb.pSQLParamStr("KURACD_TO") = pstrKURACDTo
            End If
            'ＪＡコード ' @
            If pstrJACDFrom <> "" Then
                cdb.pSQLParamStr("JACD_FROM") = pstrJACDFrom
                cdb.pSQLParamStr("JACD_FROM_CLI") = pstrJACDFrom_CLI    '2019/11/01 T.Ono add 監視改善2019
            End If
            If pstrJACDTo <> "" Then
                cdb.pSQLParamStr("JACD_TO") = pstrJACDTo
                cdb.pSQLParamStr("JACD_TO_CLI") = pstrJACDTo_CLI        '2019/11/01 T.Ono add 監視改善2019
            End If
            '販売事業者グループコード 2014/12/12 H.Hosoda add 監視改善2014 №13
            If pstrHANGRPFrom <> "" Then
                cdb.pSQLParamStr("HANGRP_FROM") = pstrHANGRPFrom
            End If
            If pstrHANGRPTo <> "" Then
                cdb.pSQLParamStr("HANGRP_TO") = pstrHANGRPTo
            End If

            '対応完了日または受信日
            cdb.pSQLParamStr("TRGDATE_FROM") = pstrTrgFrom
            cdb.pSQLParamStr("TRGDATE_TO") = pstrTrgTo          '対応完了日(To)または受信日(To)

            '対応完了時刻または受信時刻　2017/02/16 H.Mori add 改善2016 No7-1 
            If pstrTrgTimeFrom <> "" Then
                cdb.pSQLParamStr("TRGTIME_FROM") = pstrTrgTimeFrom
            End If
            If pstrTrgTimeTo <> "" Then
                cdb.pSQLParamStr("TRGTIME_TO") = pstrTrgTimeTo & "59"
            End If

            '発生区分
            If pstrStkbn1.Length = 0 And pstrStkbn2.Length = 0 Then
                '条件なし
            Else
                '条件あり
                If pstrStkbn1.Length <> 0 And pstrStkbn2.Length <> 0 Then
                    cdb.pSQLParamStr("HATKBN1") = pstrStkbn1
                    cdb.pSQLParamStr("HATKBN2") = pstrStkbn2
                ElseIf pstrStkbn1.Length <> 0 And pstrStkbn2.Length = 0 Then
                    cdb.pSQLParamStr("HATKBN1") = pstrStkbn1
                ElseIf pstrStkbn1.Length = 0 And pstrStkbn2.Length <> 0 Then
                    cdb.pSQLParamStr("HATKBN2") = pstrStkbn2
                Else
                End If
            End If

            '対応区分
            If pstrPgkbn1.Length = 0 And pstrPgkbn2.Length = 0 And pstrPgkbn3.Length = 0 Then
                '条件なし
            Else
                '条件あり
                '全部入力
                If pstrPgkbn1.Length <> 0 And pstrPgkbn2.Length <> 0 And pstrPgkbn3.Length <> 0 Then
                    cdb.pSQLParamStr("TAIOKBN1") = pstrPgkbn1
                    cdb.pSQLParamStr("TAIOKBN2") = pstrPgkbn2
                    cdb.pSQLParamStr("TAIOKBN3") = pstrPgkbn3

                    '一つ入力
                ElseIf pstrPgkbn1.Length <> 0 And pstrPgkbn2.Length = 0 And pstrPgkbn3.Length = 0 Then
                    cdb.pSQLParamStr("TAIOKBN1") = pstrPgkbn1
                ElseIf pstrPgkbn1.Length = 0 And pstrPgkbn2.Length <> 0 And pstrPgkbn3.Length = 0 Then
                    cdb.pSQLParamStr("TAIOKBN2") = pstrPgkbn2
                ElseIf pstrPgkbn1.Length = 0 And pstrPgkbn2.Length = 0 And pstrPgkbn3.Length <> 0 Then
                    cdb.pSQLParamStr("TAIOKBN3") = pstrPgkbn3

                    '二つ入力
                ElseIf pstrPgkbn1.Length <> 0 And pstrPgkbn2.Length <> 0 And pstrPgkbn3.Length = 0 Then
                    cdb.pSQLParamStr("TAIOKBN1") = pstrPgkbn1
                    cdb.pSQLParamStr("TAIOKBN2") = pstrPgkbn2
                ElseIf pstrPgkbn1.Length <> 0 And pstrPgkbn2.Length = 0 And pstrPgkbn3.Length <> 0 Then
                    cdb.pSQLParamStr("TAIOKBN1") = pstrPgkbn1
                    cdb.pSQLParamStr("TAIOKBN3") = pstrPgkbn3
                ElseIf pstrPgkbn1.Length = 0 And pstrPgkbn2.Length <> 0 And pstrPgkbn3.Length <> 0 Then
                    cdb.pSQLParamStr("TAIOKBN2") = pstrPgkbn2
                    cdb.pSQLParamStr("TAIOKBN3") = pstrPgkbn3
                Else
                End If
            End If

            '復帰対応状況
            If pstrTFKICD.Length > 0 Then cdb.pSQLParamStr("TFKICD") = pstrTFKICD

            '作動原因 '2020/01/06 T.Ono add 災害対応帳票
            If pstrTSADCD.Length > 0 Then cdb.pSQLParamStr("TSADCD") = pstrTSADCD

            cdb.mExecQuery()    'SQL実行
            ds = cdb.pResult    '結果をデータセットに格納

            'データが存在しない場合
            If ds.Tables(0).Rows.Count = 0 Then
                Return "DATA0"      'データが0件であることを示す文字列を返す
                'ElseIf ds.Tables(0).Rows.Count > intGyoMax Then
                '    Return "DATAMAX"    'データが最大行数を超える事を示す文字列を返す
            End If

            dr = ds.Tables(0).Rows(0)           'データローにデータセットを格納
            ExcelC.pKencd = "00"                'クライアントコードをセット
            ExcelC.pSessionID = pstrSessionID   'セッションID
            'ExcelC.pRepoID = "KETAISYX00"       '帳票ID 2007/12/11 T.Watabe edit 00以下にフォルダを作るように変更
            ExcelC.pRepoID = "KETAISYW00"       '帳票ID
            ExcelC.mOpen()                      'ファイルオープン

            'ExcelC.pTitle = "警報出力"                        'タイトル
            ExcelC.pTitle = "対応結果明細"                        'タイトル 2017/02/17 W.GANEKO 2016監視改善 №7
            ExcelC.pDate = DateFncC.mGet(Now.ToString("yyyyMMdd"))  '作成日
            'ExcelC.pScale = 93                                      '縮小拡大率(%)
            ExcelC.pScale = 70                                      '縮小拡大率(%)

            '印刷向き
            'ExcelC.pLandScape = False ' true:横
            ExcelC.pLandScape = True ' true:横
            '余白
            ExcelC.pMarginTop = 2D
            ExcelC.pMarginBottom = 0.6D
            ExcelC.pMarginLeft = 1.5D
            ExcelC.pMarginRight = 1D
            ExcelC.pMarginHeader = 1.3D
            ExcelC.pMarginFooter = 1.3D

            'ヘッダ項目をセット。（1ページあたり行数、出力行数、先頭行から何行目までが行タイトルか）
            'ExcelC.mHeader(intGYOSU, ds.Tables(0).Rows.Count, 5)
            'ExcelC.mHeader(40, ds.Tables(0).Rows.Count, 1)' 2011/05/17 T.Watabe edit 改ページ設定なしに変更
            ExcelC.mHeader(-1, ds.Tables(0).Rows.Count, 1)
            '2017/02/17 W.GANEKO MOD 2016監視改善 START
            '抽出条件1行名
            strHedInfo = ""
            If pstrKANSCD.Length > 0 Then
                strHedInfo = "監視センター:" & pstrKANSCD
            End If
            If pstrKURACDFrom.Length > 0 Then
                If strHedInfo.Length > 0 Then
                    strHedInfo = strHedInfo & "、"
                End If
                strHedInfo += "クライアント:" & pstrKURACDFrom & "～" & pstrKURACDTo
            End If
            If pstrJACDFrom.Length > 0 Or pstrJACDTo.Length > 0 Then
                If strHedInfo.Length > 0 Then
                    strHedInfo = strHedInfo & "、"
                End If
                strHedInfo = strHedInfo & "JA:" & pstrJACDFrom & "～" & pstrJACDTo
            End If
            If pstrHANGRPFrom.Length > 0 Or pstrHANGRPTo.Length > 0 Then
                If strHedInfo.Length > 0 Then
                    strHedInfo = strHedInfo & "、"
                End If
                strHedInfo = strHedInfo & "販売事業者:" & pstrHANGRPFrom & "～" & pstrHANGRPTo
            End If
            If pstrTrgFrom.Length > 0 Then
                If strHedInfo.Length > 0 Then
                    strHedInfo = strHedInfo & "、"
                End If
                If pstrTrgTimeFrom.Length > 0 Then
                    strHedInfo = strHedInfo & "対象期間:" & DateFncC.mGet(pstrTrgFrom) & " " & CTimeFncC.mGet(pstrTrgTimeFrom, 0) & "～" & DateFncC.mGet(pstrTrgTo) & " " & CTimeFncC.mGet(pstrTrgTimeTo, 0)
                Else
                    strHedInfo = strHedInfo & "対象期間:" & DateFncC.mGet(pstrTrgFrom) & "～" & DateFncC.mGet(pstrTrgTo)
                End If
                If pstrKIKANKBN = "1" Then
                    strHedInfo = strHedInfo & "・対応完了日"
                Else
                    strHedInfo = strHedInfo & "・受信日"
                End If
            End If
            If pstrStkbn1.Length > 0 Or pstrStkbn2.Length > 0 Then
                If strHedInfo.Length > 0 Then
                    strHedInfo = strHedInfo & "、"
                End If
                strHedInfo = strHedInfo & "発生区分:"
                strHedInfoHasei = ""
                If pstrStkbn1 = "1" Then
                    strHedInfoHasei = "電話"
                End If
                If pstrStkbn2 = "2" Then
                    If strHedInfoHasei.Length > 0 Then
                        strHedInfoHasei = strHedInfoHasei & "・"
                    End If
                    strHedInfoHasei = strHedInfoHasei & "警報"
                End If
                strHedInfo = strHedInfo & strHedInfoHasei
            End If
            If pstrPgkbn1.Length > 0 Or pstrPgkbn2.Length > 0 Or pstrPgkbn3.Length > 0 Then
                If strHedInfo.Length > 0 Then
                    strHedInfo = strHedInfo & "、"
                End If
                strHedInfo = strHedInfo & "対応区分:"
                strHedInfoHasei = ""
                If pstrPgkbn1 = "1" Then
                    strHedInfoHasei = "電話"
                End If
                If pstrPgkbn2 = "2" Then
                    If strHedInfoHasei.Length > 0 Then
                        strHedInfoHasei = strHedInfoHasei & "・"
                    End If
                    strHedInfoHasei = strHedInfoHasei & "出動"
                End If
                If pstrPgkbn3 = "3" Then
                    If strHedInfoHasei.Length > 0 Then
                        strHedInfoHasei = strHedInfoHasei & "・"
                    End If
                    strHedInfoHasei = strHedInfoHasei & "重複"
                End If
                strHedInfo = strHedInfo & strHedInfoHasei
            End If

            If pstrOUTKBN.Length > 0 Then
                If strHedInfo.Length > 0 Then
                    strHedInfo = strHedInfo & "、"
                End If
                If pstrOUTKBN = "1" Then
                    strHedInfo = strHedInfo & "出力対象:通常"
                ElseIf pstrOUTKBN = "2" Then
                    strHedInfo = strHedInfo & "出力対象:月次帳票と同じ(重複含まず)"
                End If
            End If
            If pstrHOKBN.Length > 0 Then
                If strHedInfo.Length > 0 Then
                    strHedInfo = strHedInfo & "、"
                End If
                If pstrHOKBN = "1" Then
                    strHedInfo = strHedInfo & "法令区分:総合計"
                ElseIf pstrHOKBN = "2" Then
                    strHedInfo = strHedInfo & "法令区分:液石"
                ElseIf pstrHOKBN = "3" Then
                    strHedInfo = strHedInfo & "法令区分:その他"
                End If
            End If
            If pstrOUTLIST.Length > 0 Then
                If strHedInfo.Length > 0 Then
                    strHedInfo = strHedInfo & "、"
                End If
                If pstrOUTLIST = "1" Then
                    strHedInfo = strHedInfo & "出力項目:全て"
                ElseIf pstrOUTLIST = "2" Then
                    strHedInfo = strHedInfo & "出力項目:日次報告と同じ(出動会社あり)"
                ElseIf pstrOUTLIST = "3" Then
                    strHedInfo = strHedInfo & "出力項目:日次報告と同じ(出動会社なし)"
                ElseIf pstrOUTLIST = "4" Then '2020/10/05 T.Ono add 監視改善2020
                    strHedInfo = strHedInfo & "出力項目:日次報告と同じ(出動会社なし)、個人情報なし"
                End If
            End If
            If pstrTFKICD.Length > 0 Then
                If strHedInfo.Length > 0 Then
                    strHedInfo = strHedInfo & "、"
                End If
                strHedInfo = strHedInfo & "復帰対応状況:" & pstrTFKINM
            End If
            '2020/01/06 T.Ono add 災害対応帳票
            If pstrTSADCD.Length > 0 Then
                If strHedInfo.Length > 0 Then
                    strHedInfo = strHedInfo & "、"
                End If
                strHedInfo = strHedInfo & "作動原因:" & pstrTSADNM
            End If

            If strHedInfo.Length > 0 Then
                'cntExcel += 1
                ExcelC.pCellStyle(1) = "height:13px;width:35px;text-align:left;font-size:10px;border-style:none;white-space:nowrap;"
                'ExcelC.pCellVal(i, "colspan=16") = strHedInfo
                ExcelC.pCellVal(1) = strHedInfo
                ExcelC.mWriteLine("")       '行をファイルに書き込む
            End If

            'EXCEL出力
            If pstrOUTLIST = "1" Then
                ExcelC = excelOut1(ds, dr, ExcelC)
            ElseIf pstrOUTLIST = "4" Then '2020/09/15 T.Ono add 監視改善2020
                ExcelC = excelOut4(pstrOUTLIST, ds, dr, ExcelC)
            Else
                ExcelC = excelOut2(pstrOUTLIST, ds, dr, ExcelC)
            End If
            ''印刷向き
            'ExcelC.pLandScape = False
            ''余白
            'ExcelC.pMarginTop = 2D
            'ExcelC.pMarginBottom = 0.6D
            'ExcelC.pMarginLeft = 2D
            'ExcelC.pMarginRight = 1.1D
            'ExcelC.pMarginHeader = 1.3D
            'ExcelC.pMarginFooter = 1.3D

            'ヘッダ行
            '2017/02/17 W.GANEKO MOD 2016監視改善 №7 START
            'ExcelC.pCellStyle(1) = "height:13px;width:50px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(2) = "height:13px;width:50px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(3) = "height:13px;width:50px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2016/02/26 H.Mori add 監視改善2015 №10
            'ExcelC.pCellStyle(4) = "height:13px;width:65px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2013/08/27 T.Ono add 監視改善2013№8
            'ExcelC.pCellStyle(5) = "height:13px;width:50px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2013/08/27 T.Ono add 監視改善2013№8
            'ExcelC.pCellStyle(6) = "height:13px;width:65px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(7) = "height:13px;width:50px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(8) = "height:13px;width:50px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2013/08/27 T.Ono add 監視改善2013№8
            'ExcelC.pCellStyle(9) = "height:13px;width:50px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2013/08/27 T.Ono add 監視改善2013№8
            'ExcelC.pCellStyle(10) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(11) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(12) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(13) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(14) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(15) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(16) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2013/08/27 T.Ono add 監視改善2013№8
            'ExcelC.pCellStyle(17) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(18) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(19) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(20) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(21) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(22) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2013/08/27 T.Ono add 監視改善2013№8
            'ExcelC.pCellStyle(23) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2013/08/27 T.Ono add 監視改善2013№8
            'ExcelC.pCellStyle(24) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2013/08/27 T.Ono add 監視改善2013№8
            'ExcelC.pCellStyle(25) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(26) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(27) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(28) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2013/08/27 T.Ono add 監視改善2013№8
            'ExcelC.pCellStyle(29) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(30) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(31) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(32) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(33) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(34) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(35) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(36) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2013/10/28 T.Ono add 監視改善2013№8
            'ExcelC.pCellStyle(37) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(38) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(39) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ''ExcelC.pCellStyle(29) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"  2013/08/27 T.Ono del 監視改善2013№8
            ''ExcelC.pCellStyle(30) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"  2013/08/27 T.Ono del 監視改善2013№8
            'ExcelC.pCellStyle(40) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(41) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(42) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(43) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(44) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(45) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(46) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(47) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(48) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(49) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(50) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(51) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ''ExcelC.pCellStyle(43) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2010/03/24 T.Watabe add dell
            ''ExcelC.pCellStyle(44) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2010/03/24 T.Watabe add dell
            'ExcelC.pCellStyle(52) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2010/03/24 T.Watabe add
            'ExcelC.pCellStyle(53) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2011/05/17 T.Watabe add
            'ExcelC.pCellStyle(54) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2011/05/17 T.Watabe add
            '' 2014/12/09 H.Hosoda mod 監視改善2014 №13 START
            ''ExcelC.pCellStyle(54) = "height:13px;width:10px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2011/05/17 T.Watabe add
            'ExcelC.pCellStyle(55) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            '' 2014/12/09 H.Hosoda mod 監視改善2014 №13 END
            'ExcelC.pCellStyle(56) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2014/12/09 H.Hosoda add 監視改善2014 №13
            'ExcelC.pCellStyle(57) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2014/12/09 H.Hosoda add 監視改善2014 №13
            'ExcelC.pCellStyle(58) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2014/12/09 H.Hosoda add 監視改善2014 №13
            'ExcelC.pCellStyle(59) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2015/12/10 H.Mori add 監視改善2015 №10
            'ExcelC.pCellStyle(60) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2016/2/1 H.Mori add 監視改善2015 №10
            'ExcelC.pCellStyle(61) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2016/2/1 H.Mori add 監視改善2015 №10
            ''ExcelC.pCellStyle(58) = "height:13px;width:10px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2014/12/09 H.Hosoda add 監視改善2014 №13
            ''ExcelC.pCellStyle(59) = "height:13px;width:10px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2015/12/10 H.Mori mod 監視改善2015 №10 番号を58→59
            'ExcelC.pCellStyle(62) = "height:13px;width:10px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2016/2/1 H.Mori mod 監視改善2015 №10 番号を59→61
            'ExcelC.pCellStyle(43) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" ' 2008/11/11 T.Watabe edit
            'ExcelC.pCellStyle(44) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(45) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(46) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(47) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(48) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(49) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(50) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(51) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(52) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(53) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"

            'ExcelC.pCellVal(1) = Convert.ToString("監視センターコード") ' 2008/11/11 T.Watabe edit
            'ExcelC.pCellVal(2) = Convert.ToString("処理番号")
            'ExcelC.pCellVal(3) = Convert.ToString("発生日")
            'ExcelC.pCellVal(4) = Convert.ToString("発生時刻")
            'ExcelC.pCellVal(5) = Convert.ToString("対応受信日")
            'ExcelC.pCellVal(6) = Convert.ToString("対応時刻")
            'ExcelC.pCellVal(7) = Convert.ToString("警報１コード")
            'ExcelC.pCellVal(8) = Convert.ToString("警報１メッセージ")
            'ExcelC.pCellVal(9) = Convert.ToString("警報２コード")
            'ExcelC.pCellVal(10) = Convert.ToString("警報２メッセージ")
            'ExcelC.pCellVal(11) = Convert.ToString("警報３コード")
            'ExcelC.pCellVal(12) = Convert.ToString("警報３メッセージ")
            'ExcelC.pCellVal(13) = Convert.ToString("警報４コード")
            'ExcelC.pCellVal(14) = Convert.ToString("警報４メッセージ")
            'ExcelC.pCellVal(15) = Convert.ToString("警報５コード")
            'ExcelC.pCellVal(16) = Convert.ToString("警報５メッセージ")
            'ExcelC.pCellVal(17) = Convert.ToString("警報６コード")
            'ExcelC.pCellVal(18) = Convert.ToString("警報６メッセージ")
            'ExcelC.pCellVal(19) = Convert.ToString("全農支所コード")
            'ExcelC.pCellVal(20) = Convert.ToString("クライアントコード")
            'ExcelC.pCellVal(21) = Convert.ToString("県名")
            'ExcelC.pCellVal(22) = Convert.ToString("ＪＡコード")
            'ExcelC.pCellVal(23) = Convert.ToString("ＪＡ名")
            'ExcelC.pCellVal(24) = Convert.ToString("ＪＡ支所コード")
            'ExcelC.pCellVal(25) = Convert.ToString("ＪＡ支所名")
            'ExcelC.pCellVal(26) = Convert.ToString("お客様コード")
            'ExcelC.pCellVal(27) = Convert.ToString("お客様名")
            'ExcelC.pCellVal(28) = Convert.ToString("電話番号市外１")
            'ExcelC.pCellVal(29) = Convert.ToString("電話番号市外２")
            'ExcelC.pCellVal(30) = Convert.ToString("連絡先電話")
            'ExcelC.pCellVal(31) = Convert.ToString("検索電話番号")
            'ExcelC.pCellVal(32) = Convert.ToString("住所")
            'ExcelC.pCellVal(33) = Convert.ToString("ＮＣＵ接続")
            'ExcelC.pCellVal(34) = Convert.ToString("発生区分")
            'ExcelC.pCellVal(35) = Convert.ToString("発生区分・内容")
            'ExcelC.pCellVal(36) = Convert.ToString("対応区分")
            'ExcelC.pCellVal(37) = Convert.ToString("対応区分・内容")
            'ExcelC.pCellVal(38) = Convert.ToString("処理区分")
            'ExcelC.pCellVal(39) = Convert.ToString("処理区分・内容")
            'ExcelC.pCellVal(40) = Convert.ToString("対応完了日")
            'ExcelC.pCellVal(41) = Convert.ToString("対応完了時刻")
            'ExcelC.pCellVal(42) = Convert.ToString("電話連絡")
            'ExcelC.pCellVal(43) = Convert.ToString("電話連絡・内容")
            'ExcelC.pCellVal(44) = Convert.ToString("復帰対応状況")
            'ExcelC.pCellVal(45) = Convert.ToString("復帰対応状況・内容")
            'ExcelC.pCellVal(46) = Convert.ToString("復帰操作メモ")
            'ExcelC.pCellVal(47) = Convert.ToString("電話対応メモ１")
            'ExcelC.pCellVal(48) = Convert.ToString("電話対応メモ２")
            'ExcelC.pCellVal(49) = Convert.ToString("未登録ＦＬＧ")
            'ExcelC.pCellVal(50) = Convert.ToString("ガス器具")
            'ExcelC.pCellVal(51) = Convert.ToString("ガス器具・内容")
            'ExcelC.pCellVal(52) = Convert.ToString("作動原因")
            'ExcelC.pCellVal(53) = Convert.ToString("作動原因・内容")

            '2011/05/17 T.Watabe edit
            'If False Then
            'ExcelC.pCellVal(1) = Convert.ToString("対応受信日")
            'ExcelC.pCellVal(2) = Convert.ToString("対応時刻")
            'ExcelC.pCellVal(3) = Convert.ToString("警報１")
            'ExcelC.pCellVal(4) = Convert.ToString("警報２")
            'ExcelC.pCellVal(5) = Convert.ToString("警報３")
            'ExcelC.pCellVal(6) = Convert.ToString("警報４")
            'ExcelC.pCellVal(7) = Convert.ToString("警報５")
            'ExcelC.pCellVal(8) = Convert.ToString("警報６")
            'ExcelC.pCellVal(9) = Convert.ToString("指針値")
            'ExcelC.pCellVal(10) = Convert.ToString("クライアントコード")
            'ExcelC.pCellVal(11) = Convert.ToString("県名")
            'ExcelC.pCellVal(12) = Convert.ToString("ＪＡ支所コード")
            'ExcelC.pCellVal(13) = Convert.ToString("ＪＡ支所名")
            'ExcelC.pCellVal(14) = Convert.ToString("お客様コード")
            'ExcelC.pCellVal(15) = Convert.ToString("お客様名")
            'ExcelC.pCellVal(16) = Convert.ToString("連絡先電話")
            'ExcelC.pCellVal(17) = Convert.ToString("住所")
            'ExcelC.pCellVal(18) = Convert.ToString("発生区分・内容")
            'ExcelC.pCellVal(19) = Convert.ToString("対応区分・内容")
            'ExcelC.pCellVal(20) = Convert.ToString("処理区分・内容")
            ''ExcelC.pCellVal(21) = Convert.ToString("対応完了日") ' 2010/03/24 T.Watabe edit
            ''ExcelC.pCellVal(22) = Convert.ToString("対応完了時刻")
            ''ExcelC.pCellVal(23) = Convert.ToString("電話連絡・内容")
            ''ExcelC.pCellVal(24) = Convert.ToString("復帰対応状況・内容")
            ''ExcelC.pCellVal(25) = Convert.ToString("電話対応メモ１")
            ''ExcelC.pCellVal(26) = Convert.ToString("電話対応メモ２")
            ''ExcelC.pCellVal(27) = Convert.ToString("電話対応メモ３")
            ''ExcelC.pCellVal(28) = Convert.ToString("ガス器具・内容")
            ''ExcelC.pCellVal(29) = Convert.ToString("作動原因・内容")
            ''ExcelC.pCellVal(30) = Convert.ToString("出動要請日")
            ''ExcelC.pCellVal(31) = Convert.ToString("出動要請時刻")
            ''ExcelC.pCellVal(32) = Convert.ToString("出動会社名")
            ''ExcelC.pCellVal(33) = Convert.ToString("出動日")
            ''ExcelC.pCellVal(34) = Convert.ToString("出動時刻")
            ''ExcelC.pCellVal(35) = Convert.ToString("現着日")
            ''ExcelC.pCellVal(36) = Convert.ToString("現着時刻")
            ''ExcelC.pCellVal(37) = Convert.ToString("対応内容１")
            ''ExcelC.pCellVal(38) = Convert.ToString("対応内容２")
            ''ExcelC.pCellVal(39) = Convert.ToString("対応内容３")
            ''ExcelC.pCellVal(40) = Convert.ToString("復帰操作")
            ''ExcelC.pCellVal(41) = Convert.ToString("措置終了日")
            ''ExcelC.pCellVal(42) = Convert.ToString("措置終了時刻")
            'ExcelC.pCellVal(21) = Convert.ToString("監視ｾﾝﾀｰ担当者") ' 2010/03/24 T.Watabe add
            'ExcelC.pCellVal(22) = Convert.ToString("対応完了日")
            'ExcelC.pCellVal(23) = Convert.ToString("対応完了時刻")
            'ExcelC.pCellVal(24) = Convert.ToString("電話連絡・内容")
            'ExcelC.pCellVal(25) = Convert.ToString("復帰対応状況・内容")
            'ExcelC.pCellVal(26) = Convert.ToString("電話対応メモ１")
            'ExcelC.pCellVal(27) = Convert.ToString("電話対応メモ２")
            'ExcelC.pCellVal(28) = Convert.ToString("電話対応メモ３")
            'ExcelC.pCellVal(29) = Convert.ToString("ガス器具・内容")
            'ExcelC.pCellVal(30) = Convert.ToString("作動原因・内容")
            'ExcelC.pCellVal(31) = Convert.ToString("出動要請日")
            'ExcelC.pCellVal(32) = Convert.ToString("出動要請時刻")
            'ExcelC.pCellVal(33) = Convert.ToString("出動会社名")
            'ExcelC.pCellVal(34) = Convert.ToString("出動受付者") ' 2010/03/24 T.Watabe add
            'ExcelC.pCellVal(35) = Convert.ToString("出動対応者") ' 2010/03/24 T.Watabe add
            'ExcelC.pCellVal(36) = Convert.ToString("出動日")
            'ExcelC.pCellVal(37) = Convert.ToString("出動時刻")
            'ExcelC.pCellVal(38) = Convert.ToString("現着日")
            'ExcelC.pCellVal(39) = Convert.ToString("現着時刻")
            'ExcelC.pCellVal(40) = Convert.ToString("対応内容１")
            'ExcelC.pCellVal(41) = Convert.ToString("対応内容２")
            'ExcelC.pCellVal(42) = Convert.ToString("対応内容３")
            'ExcelC.pCellVal(43) = Convert.ToString("復帰操作")
            'ExcelC.pCellVal(44) = Convert.ToString("措置終了日")
            'ExcelC.pCellVal(45) = Convert.ToString("措置終了時刻")
            'End If
            'i = 1
            '2017/02/17 W.GANEKO MOD 2016監視改善 №7 START
            'ExcelC.pCellVal(i) = Convert.ToString("FAXJA送") : i += 1 ' 2011/05/17 T.Watabe add
            'ExcelC.pCellVal(i) = Convert.ToString("FAXｸﾗ送") : i += 1 ' 2011/05/17 T.Watabe add
            'ExcelC.pCellVal(i) = Convert.ToString("累積送") : i += 1 ' 2016/02/26 H.Mori add 監視改善2015 №10

            'ExcelC.pCellVal(i) = Convert.ToString("発生月日") : i += 1 ' 2013/08/27 T.Ono add 監視改善2013№8     5
            'ExcelC.pCellVal(i) = Convert.ToString("発生時刻") : i += 1 ' 2013/08/27 T.Ono add 監視改善2013№8     6
            ''ExcelC.pCellVal(i) = Convert.ToString("対応受信日") : i += 1 2013/08/27 T.Ono mod 監視改善2013№8
            ''ExcelC.pCellVal(i) = Convert.ToString("対応時刻") : i += 1   2013/08/27 T.Ono mod 監視改善2013№8
            'ExcelC.pCellVal(i) = Convert.ToString("受信日") : i += 1                                             '7
            'ExcelC.pCellVal(i) = Convert.ToString("受信時刻") : i += 1                                           '8
            'ExcelC.pCellVal(i) = Convert.ToString("遅延時間") : i += 1 ' 2013/08/27 T.Ono add 監視改善2013№8     9
            'ExcelC.pCellVal(i) = Convert.ToString("流量区分") : i += 1 ' 2013/08/27 T.Ono add 監視改善2013№8     10
            'ExcelC.pCellVal(i) = Convert.ToString("警報１") : i += 1                                             '11
            'ExcelC.pCellVal(i) = Convert.ToString("警報２") : i += 1                                             '12
            'ExcelC.pCellVal(i) = Convert.ToString("警報３") : i += 1                                             '13
            'ExcelC.pCellVal(i) = Convert.ToString("警報４") : i += 1                                             '14
            'ExcelC.pCellVal(i) = Convert.ToString("警報５") : i += 1                                             '15
            'ExcelC.pCellVal(i) = Convert.ToString("警報６") : i += 1                                             '16
            'ExcelC.pCellVal(i) = Convert.ToString("お客様FLG") : i += 1 ' 2013/08/27 T.Ono add 監視改善2013№8   '17
            'ExcelC.pCellVal(i) = Convert.ToString("指針値") : i += 1                                             '18
            'ExcelC.pCellVal(i) = Convert.ToString("クライアントコード") : i += 1                                 '19
            'ExcelC.pCellVal(i) = Convert.ToString("県名") : i += 1                                               '20
            'ExcelC.pCellVal(i) = Convert.ToString("ＪＡコード") : i += 1           ' 2014/12/11 H.Hosoda add 監視改善2014 №13  21
            'ExcelC.pCellVal(i) = Convert.ToString("ＪＡ名") : i += 1               ' 2014/12/11 H.Hosoda add 監視改善2014 №13  22
            'ExcelC.pCellVal(i) = Convert.ToString("販売事業者コード") : i += 1     ' 2014/12/11 H.Hosoda add 監視改善2014 №13  23
            'ExcelC.pCellVal(i) = Convert.ToString("販売事業者名") : i += 1         ' 2014/12/11 H.Hosoda add 監視改善2014 №13  24
            'ExcelC.pCellVal(i) = Convert.ToString("ＪＡ支所コード") : i += 1                                                   '26
            'ExcelC.pCellVal(i) = Convert.ToString("ＪＡ支所名") : i += 1                                                       '27
            ''ExcelC.pCellVal(i) = Convert.ToString("NCU接続(種別)") : i += 1    ' 2013/08/27 T.Ono add 監視改善2013№8       
            ''ExcelC.pCellVal(i) = Convert.ToString("接続区分") : i += 1 ' 2013/08/27 T.Ono add 監視改善2013№8               
            'ExcelC.pCellVal(i) = Convert.ToString("お客様コード") : i += 1                                                     '28
            'ExcelC.pCellVal(i) = Convert.ToString("お客様名") : i += 1                                                         '29
            'ExcelC.pCellVal(i) = Convert.ToString("代表者氏名") : i += 1    ' 2017/02/17 W.GANEKO add 監視改善2016 №7          30
            ''ExcelC.pCellVal(i) = Convert.ToString("連絡先電話") : i += 1 ' 2014/12/09 H.Hosoda mod 監視改善2014 №13           
            'ExcelC.pCellVal(i) = Convert.ToString("連絡先") : i += 1                                                           '31
            '' 2014/12/11 H.Hosoda mod 監視改善2014 №13 START
            ''ExcelC.pCellVal(i) = Convert.ToString("結線電話番号") : i += 1       ' 2013/08/27 T.Ono add 監視改善2013№8
            'ExcelC.pCellVal(i) = Convert.ToString("結線番号") : i += 1                                                         '32
            '' 2014/12/11 H.Hosoda mod 監視改善2014 №13 END    
            'ExcelC.pCellVal(i) = Convert.ToString("最終架電先") : i += 1 ' 2016/2/1 H.Mori add 監視改善2015 №10                33
            'ExcelC.pCellVal(i) = Convert.ToString("住所") : i += 1                                                             '34
            'ExcelC.pCellVal(i) = Convert.ToString("販売区分") : i += 1 ' 2015/12/10 H.Mori add 監視改善2015 №10                35
            ''ExcelC.pCellVal(i) = Convert.ToString("発生区分・内容") : i += 1  2013/08/27 T.Ono mod 監視改善2013№8
            ''ExcelC.pCellVal(i) = Convert.ToString("対応区分・内容") : i += 1  2013/08/27 T.Ono mod 監視改善2013№8
            ''ExcelC.pCellVal(i) = Convert.ToString("処理区分・内容") : i += 1  2013/08/27 T.Ono mod 監視改善2013№8
            'ExcelC.pCellVal(i) = Convert.ToString("発生区分") : i += 1                                                         '36
            'ExcelC.pCellVal(i) = Convert.ToString("対応区分") : i += 1                                                         '37
            'ExcelC.pCellVal(i) = Convert.ToString("処理区分") : i += 1                                                         '38
            'ExcelC.pCellVal(i) = Convert.ToString("監視ｾﾝﾀｰ担当者") : i += 1 ' 2010/03/24 T.Watabe add                          39
            ''ExcelC.pCellVal(i) = Convert.ToString("対応完了日") : i += 1                                                       
            ''ExcelC.pCellVal(i) = Convert.ToString("対応完了時刻") : i += 1                                                     
            'ExcelC.pCellVal(i) = Convert.ToString("連絡相手") : i += 1 '2013/10/28 T.Ono add 監視改善2013№8                    40
            ''ExcelC.pCellVal(i) = Convert.ToString("電話連絡・内容") : i += 1     2013/08/27 T.Ono mod 監視改善2013№8
            ''ExcelC.pCellVal(i) = Convert.ToString("復帰対応状況・内容") : i += 1 2013/08/27 T.Ono mod 監視改善2013№8
            'ExcelC.pCellVal(i) = Convert.ToString("電話連絡") : i += 1                                                         '41
            'ExcelC.pCellVal(i) = Convert.ToString("復帰対応状況") : i += 1                                                     '42
            ''ExcelC.pCellVal(i) = Convert.ToString("電話対応メモ１") : i += 1  2013/08/27 T.Ono mod 監視改善2013№8
            'ExcelC.pCellVal(i) = Convert.ToString("監視対応内容") : i += 1                                                     '43
            'ExcelC.pCellVal(i) = Convert.ToString("メモ欄") : i += 1         '2014/12/09 H.Hosoda add 監視改善2014 №13         44
            ''ExcelC.pCellVal(i) = Convert.ToString("電話対応メモ２") : i += 1  2013/08/27 T.Ono del 監視改善2013№8
            ''ExcelC.pCellVal(i) = Convert.ToString("電話対応メモ３") : i += 1  2013/08/27 T.Ono del 監視改善2013№8
            ''ExcelC.pCellVal(i) = Convert.ToString("ガス器具・内容") : i += 1 2013/10/28 T.Ono mod 監視改善2013№8
            ''ExcelC.pCellVal(i) = Convert.ToString("作動原因・内容") : i += 1 2013/10/28 T.Ono mod 監視改善2013№8
            ''ExcelC.pCellVal(i) = Convert.ToString("ガス器具") : i += 1  ' 2014/12/09 H.Hosoda mod 監視改善2014 №13
            'ExcelC.pCellVal(i) = Convert.ToString("監視備考") : i += 1 ' 2016/2/1 H.Mori add 監視改善2015 №10                  50
            'ExcelC.pCellVal(i) = Convert.ToString("原因器具") : i += 1                                                         '51
            'ExcelC.pCellVal(i) = Convert.ToString("作動原因") : i += 1                                                         '52
            ''ExcelC.pCellVal(i) = Convert.ToString("出動要請日") : i += 1   ' 2014/12/09 H.Hosoda mod 監視改善2014 №13
            ''ExcelC.pCellVal(i) = Convert.ToString("出動要請時刻") : i += 1 ' 2014/12/09 H.Hosoda mod 監視改善2014 №13
            'ExcelC.pCellVal(i) = Convert.ToString("出動依頼日") : i += 1                                                       '57
            'ExcelC.pCellVal(i) = Convert.ToString("出動依頼時刻") : i += 1                                                     '58
            'ExcelC.pCellVal(i) = Convert.ToString("出動会社名") : i += 1                                                       '59
            'ExcelC.pCellVal(i) = Convert.ToString("出動受付者") : i += 1 ' 2010/03/24 T.Watabe add                              60
            'ExcelC.pCellVal(i) = Convert.ToString("出動対応者") : i += 1 ' 2010/03/24 T.Watabe add                              61
            'ExcelC.pCellVal(i) = Convert.ToString("出動日") : i += 1                                                           '62
            'ExcelC.pCellVal(i) = Convert.ToString("出動時刻") : i += 1                                                         '63
            ''ExcelC.pCellVal(i) = Convert.ToString("現着日") : i += 1   ' 2014/12/09 H.Hosoda mod 監視改善2014 №13
            ''ExcelC.pCellVal(i) = Convert.ToString("現着時刻") : i += 1 ' 2014/12/09 H.Hosoda mod 監視改善2014 №13
            'ExcelC.pCellVal(i) = Convert.ToString("到着日") : i += 1                                                           '64
            'ExcelC.pCellVal(i) = Convert.ToString("到着時刻") : i += 1                                                         '65
            ''ExcelC.pCellVal(i) = Convert.ToString("対応内容１") : i += 1  2013/08/27 T.Ono mod 監視改善2013№8
            'ExcelC.pCellVal(i) = Convert.ToString("出動対応内容") : i += 1                                                     '66
            ''ExcelC.pCellVal(i) = Convert.ToString("対応内容２") : i += 1  2013/08/27 T.Ono del 監視改善2013№8
            ''ExcelC.pCellVal(i) = Convert.ToString("対応内容３") : i += 1  2013/08/27 T.Ono del 監視改善2013№8
            'ExcelC.pCellVal(i) = Convert.ToString("復帰操作") : i += 1                                                         '67
            ''ExcelC.pCellVal(i) = Convert.ToString("措置終了日") : i += 1   ' 2014/12/09 H.Hosoda mod 監視改善2014 №13
            ''ExcelC.pCellVal(i) = Convert.ToString("措置終了時刻") : i += 1 ' 2014/12/09 H.Hosoda mod 監視改善2014 №13
            'ExcelC.pCellVal(i) = Convert.ToString("処理完了日") : i += 1                                                       '68
            'ExcelC.pCellVal(i) = Convert.ToString("処理完了時刻") : i += 1                                                     '69
            'ExcelC.pCellVal(i) = Convert.ToString("適用法令区分") : i += 1                                                     '70
            'ExcelC.pCellVal(i) = Convert.ToString("供給形態区分") : i += 1                                                     '71
            'ExcelC.pCellVal(i) = Convert.ToString("用途区分") : i += 1                                                         '72
            'ExcelC.mWriteLine("")       '行をファイルに書き込む 


            ''明細データ出力
            'Dim iCnt As Integer
            'APサーバからの戻り値をループする
            '明細データ出力
            'For Each dr In ds.Tables(0).Rows
            'For iCnt = 0 To ds.Tables(0).Rows.Count - 1
            'dr = ds.Tables(0).Rows(iCnt)
            '明細項目
            '2017/02/17 W.GANEKO MOD 2016監視改善 №7 START
            'ExcelC.pCellStyle(1) = "height:13px;width:50px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(2) = "height:13px;width:50px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(3) = "height:13px;width:50px;text-align:left;font-size:10px;border-style:none" ' 2016/02/26 H.Mori add 監視改善2015 №10
            'ExcelC.pCellStyle(4) = "height:13px;width:65px;text-align:left;font-size:10px;border-style:none" ' 2013/08/27 T.Ono add 監視改善2013№8
            'ExcelC.pCellStyle(5) = "height:13px;width:50px;text-align:left;font-size:10px;border-style:none" ' 2013/08/27 T.Ono add 監視改善2013№8
            'ExcelC.pCellStyle(6) = "height:13px;width:65px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(7) = "height:13px;width:50px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(8) = "height:13px;width:50px;text-align:left;font-size:10px;border-style:none" ' 2013/08/27 T.Ono add 監視改善2013№8
            'ExcelC.pCellStyle(9) = "height:13px;width:50px;text-align:left;font-size:10px;border-style:none" ' 2013/08/27 T.Ono add 監視改善2013№8
            'ExcelC.pCellStyle(10) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(11) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(12) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(13) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(14) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(15) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(16) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" ' 2013/08/27 T.Ono add 監視改善2013№8
            'ExcelC.pCellStyle(17) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(18) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(19) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(20) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(21) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(22) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" ' 2013/08/27 T.Ono add 監視改善2013№8
            'ExcelC.pCellStyle(23) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" ' 2013/08/27 T.Ono add 監視改善2013№8
            'ExcelC.pCellStyle(24) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(25) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(26) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(27) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" ' 2013/08/27 T.Ono add 監視改善2013№8
            'ExcelC.pCellStyle(28) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(29) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(30) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(31) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(32) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(33) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(34) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(35) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" ' 2013/10/28 T.Ono add 監視改善2013№8
            'ExcelC.pCellStyle(36) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(37) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(38) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            ''ExcelC.pCellStyle(29) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"  2013/08/27 T.Ono del 監視改善2013№8
            ''ExcelC.pCellStyle(30) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"  2013/08/27 T.Ono del 監視改善2013№8
            'ExcelC.pCellStyle(39) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(40) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(41) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(42) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(43) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(44) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(45) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(46) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(47) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(48) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(49) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(50) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            ''ExcelC.pCellStyle(43) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"  2013/08/27 T.Ono del 監視改善2013№8
            ''ExcelC.pCellStyle(44) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" ' 2010/03/24 T.Watabe add  2013/08/27 T.Ono del 監視改善2013№8
            'ExcelC.pCellStyle(51) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" ' 2010/03/24 T.Watabe add
            'ExcelC.pCellStyle(52) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" ' 2010/03/24 T.Watabe add
            'ExcelC.pCellStyle(53) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" ' 2011/05/17 T.Watabe add
            ''2014/12/09 H.Hosoda add 監視改善2014 №13 START
            ''ExcelC.pCellStyle(53) = "height:13px;width:10px;text-align:left;font-size:10px;border-style:none" ' 2011/05/17 T.Watabe add
            'ExcelC.pCellStyle(54) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            ''2014/12/09 H.Hosoda add 監視改善2014 №13 END
            'ExcelC.pCellStyle(55) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" '2014/12/09 H.Hosoda add 監視改善2014 №13
            'ExcelC.pCellStyle(56) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" '2014/12/09 H.Hosoda add 監視改善2014 №13
            'ExcelC.pCellStyle(57) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" '2014/12/09 H.Hosoda add 監視改善2014 №13
            'ExcelC.pCellStyle(58) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" '2014/12/09 H.Hosoda add 監視改善2014 №13
            'ExcelC.pCellStyle(59) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" '2015/12/10 H.Mori add 監視改善2015 №10
            'ExcelC.pCellStyle(60) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" '2016/2/1 H.Mori add 監視改善2015 №10
            'ExcelC.pCellStyle(61) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" '2016/2/1 H.Mori add 監視改善2015 №10
            ''ExcelC.pCellStyle(58) = "height:13px;width:10px;text-align:left;font-size:10px;border-style:none" '2014/12/09 H.Hosoda add 監視改善2014 №13
            ''ExcelC.pCellStyle(59) = "height:13px;width:10px;text-align:left;font-size:10px;border-style:none" '2015/12/10 H.Mori mod 監視改善2015 №10 
            'ExcelC.pCellStyle(62) = "height:13px;width:10px;text-align:left;font-size:10px;border-style:none" '2016/2/1 H.Mori mod 監視改善2015 №10
            'ExcelC.pCellStyle(44) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" ' 2008/11/11 T.Watabe edit
            'ExcelC.pCellStyle(45) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(46) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(47) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(48) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(49) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(50) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(51) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(52) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(53) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(54) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"

            ' 2011/05/17 T.Watabe edit
            'If False Then
            'ExcelC.pCellVal(1) = Convert.ToString(dr.Item("KANSCD")) ' 2008/11/11 T.Watabe edit
            'ExcelC.pCellVal(2) = Convert.ToString(dr.Item("SYONO"))
            'ExcelC.pCellVal(3) = Convert.ToString(dr.Item("HATYMD"))
            'ExcelC.pCellVal(4) = Convert.ToString(dr.Item("HATTIME"))
            'ExcelC.pCellVal(5) = Convert.ToString(dr.Item("JUYMD"))
            'ExcelC.pCellVal(6) = Convert.ToString(dr.Item("JUTIME"))
            'ExcelC.pCellVal(7) = Convert.ToString(dr.Item("KMCD1"))
            'ExcelC.pCellVal(8) = Convert.ToString(dr.Item("KMNM1"))
            'ExcelC.pCellVal(9) = Convert.ToString(dr.Item("KMCD2"))
            'ExcelC.pCellVal(10) = Convert.ToString(dr.Item("KMNM2"))
            'ExcelC.pCellVal(11) = Convert.ToString(dr.Item("KMCD3"))
            'ExcelC.pCellVal(12) = Convert.ToString(dr.Item("KMNM3"))
            'ExcelC.pCellVal(13) = Convert.ToString(dr.Item("KMCD4"))
            'ExcelC.pCellVal(14) = Convert.ToString(dr.Item("KMNM4"))
            'ExcelC.pCellVal(15) = Convert.ToString(dr.Item("KMCD5"))
            'ExcelC.pCellVal(16) = Convert.ToString(dr.Item("KMNM5"))
            'ExcelC.pCellVal(17) = Convert.ToString(dr.Item("KMCD6"))
            'ExcelC.pCellVal(18) = Convert.ToString(dr.Item("KMNM6"))
            'ExcelC.pCellVal(19) = Convert.ToString(dr.Item("ZSISYO"))
            'ExcelC.pCellVal(20) = Convert.ToString(dr.Item("KURACD"))
            'ExcelC.pCellVal(21) = Convert.ToString(dr.Item("KENNM"))
            'ExcelC.pCellVal(22) = Convert.ToString(dr.Item("JACD"))
            'ExcelC.pCellVal(23) = Convert.ToString(dr.Item("JANM"))
            'ExcelC.pCellVal(24) = Convert.ToString(dr.Item("ACBCD"))
            'ExcelC.pCellVal(25) = Convert.ToString(dr.Item("ACBNM"))
            'ExcelC.pCellVal(26) = Convert.ToString(dr.Item("USER_CD"))
            'ExcelC.pCellVal(27) = Convert.ToString(dr.Item("JUSYONM"))
            'ExcelC.pCellVal(28) = Convert.ToString(dr.Item("JUTEL1"))
            'ExcelC.pCellVal(29) = Convert.ToString(dr.Item("JUTEL2"))
            'ExcelC.pCellVal(30) = Convert.ToString(dr.Item("RENTEL"))
            'ExcelC.pCellVal(31) = Convert.ToString(dr.Item("KTELNO"))
            'ExcelC.pCellVal(32) = Convert.ToString(dr.Item("ADDR"))
            'ExcelC.pCellVal(33) = Convert.ToString(dr.Item("NCU_SET"))
            'ExcelC.pCellVal(34) = Convert.ToString(dr.Item("HATKBN"))
            'ExcelC.pCellVal(35) = Convert.ToString(dr.Item("HATKBN_NAI"))
            'ExcelC.pCellVal(36) = Convert.ToString(dr.Item("TAIOKBN"))
            'ExcelC.pCellVal(37) = Convert.ToString(dr.Item("TAIOKBN_NAI"))
            'ExcelC.pCellVal(38) = Convert.ToString(dr.Item("TMSKB"))
            'ExcelC.pCellVal(39) = Convert.ToString(dr.Item("TMSKB_NAI"))
            'ExcelC.pCellVal(40) = Convert.ToString(dr.Item("SYOYMD"))
            'ExcelC.pCellVal(41) = Convert.ToString(dr.Item("SYOTIME"))
            'ExcelC.pCellVal(42) = Convert.ToString(dr.Item("TELRCD"))
            'ExcelC.pCellVal(43) = Convert.ToString(dr.Item("TELRNM"))
            'ExcelC.pCellVal(44) = Convert.ToString(dr.Item("TFKICD"))
            'ExcelC.pCellVal(45) = Convert.ToString(dr.Item("TFKINM"))
            'ExcelC.pCellVal(46) = Convert.ToString(dr.Item("FUK_MEMO"))
            'ExcelC.pCellVal(47) = Convert.ToString(dr.Item("TEL_MEMO1"))
            'ExcelC.pCellVal(48) = Convert.ToString(dr.Item("TEL_MEMO2"))
            'ExcelC.pCellVal(49) = Convert.ToString(dr.Item("MITOKBN"))
            'ExcelC.pCellVal(50) = Convert.ToString(dr.Item("TKIGCD"))
            'ExcelC.pCellVal(51) = Convert.ToString(dr.Item("TKIGNM"))
            'ExcelC.pCellVal(52) = Convert.ToString(dr.Item("TSADCD"))
            'ExcelC.pCellVal(53) = Convert.ToString(dr.Item("TSADNM"))
            'ExcelC.pCellVal(54) = "1"
            'End If
            '    i = 1
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("FAXKBN")) : i += 1 ' FAX不要 1:不要/2:必要
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("FAXKURAKBN")) : i += 1 ' ＦＡＸ不要(ｸﾗｲｱﾝﾄ) 1:不要/2:必要
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("FAXRUISEKIKBN")) : i += 1 ' 報告不要(累積) 1:不要/2:必要 2016/02/26 H.Mori add 監視改善2015 №10
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("FAXSPOTKBN")) : i += 1 ' 依頼書 2017/02/17 W.GANEKO ADD 2016監視改善 №7
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("NCUHATYMD")) : i += 1  ' 発生月日 2013/08/29 T.Ono add 監視改善2013№8
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("NCUHATTIME")) : i += 1 ' 発生時刻 2013/08/29 T.Ono add 監視改善2013№8
            '    '2013/11/01 T.Ono mod 対応画面の受信日時を出力するように変更
            '    'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("JUYMD")) : i += 1
            '    'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("JUTIME")) : i += 1
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("HATYMD")) : i += 1
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("HATTIME")) : i += 1

            '    ExcelC.pCellVal(i) = fncSetChien(Convert.ToString(dr.Item("CHIEN"))) : i += 1  ' 遅延時間 2013/10/28 T.Ono add 監視改善2013№8

            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("RYURYO")) : i += 1 ' 流量区分 2013/08/29 T.Ono add 監視改善2013№8
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KMNM1")) : i += 1
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KMNM2")) : i += 1
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KMNM3")) : i += 1
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KMNM4")) : i += 1
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KMNM5")) : i += 1
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KMNM6")) : i += 1
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("OYAKU_FLG")) : i += 1 ' お客様FLG 2013/08/29 T.Ono add 監視改善2013№8
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KENSIN")) : i += 1
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KURACD")) : i += 1
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KENNM")) : i += 1
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("JACD")) : i += 1      ' 2014/12/11 H.Hosoda add 監視改善2014 №13 [利用者]【JAコード】
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("JANM")) : i += 1      ' 2014/12/11 H.Hosoda add 監視改善2014 №13 [利用者]【JA名】
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("HANJICD")) : i += 1   ' 2014/12/11 H.Hosoda add 監視改善2014 №13 [レコード情報]【販売事業者コード】
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("HANJINM")) : i += 1   ' 2014/12/11 H.Hosoda add 監視改善2014 №13 [レコード情報]【販売事業者名】
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("HANBCD")) : i += 1  ' 販売所コード 2017/02/17 W.GANEKO ADD 2016監視改善 №7
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("ACBCD")) : i += 1
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("ACBNM")) : i += 1
            '    'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TUSIN")) : i += 1   ' NSU接続（種別）  2013/08/29 T.Ono add 監視改善2013№8
            '    'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("NCU_SETNM")) : i += 1 ' 接続（双or端発） 2013/08/29 T.Ono add 監視改善2013№8
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("USER_CD")) : i += 1
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("JUSYONM")) : i += 1
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("DAIHYO_NAME")) : i += 1  ' 代表者氏名 2017/02/17 W.GANEKO ADD 2016監視改善 №7
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("RENTEL")) : i += 1

            '    ExcelC.pCellVal(i) = fncSetJUTEL(Convert.ToString(dr.Item("JUTEL1")), Convert.ToString(dr.Item("JUTEL2"))) : i += 1 ' 結線電話番号     2013/10/28 T.Ono add 監視改善2013№8

            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KOK_TELNO")) : i += 1 ' 2016/2/1 H.Mori add 監視改善2015 №10 【発信電話番号】
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("ADDR")) : i += 1
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("HANBAI_KBN")) : i += 1 ' 2015/12/10 H.Mori add 監視改善2015 №10 [お客様情報]販売区分
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("HATKBN_NAI")) : i += 1
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TAIOKBN_NAI")) : i += 1
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TMSKB_NAI")) : i += 1
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TKTANCD_NM")) : i += 1 ' 2010/03/24 T.Watabe add  [対応情報]【監視センター担当者名】 
            '    'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SYOYMD")) : i += 1
            '    'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SYOTIME")) : i += 1
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TAITCD")) : i += 1 ' 連絡相手     2013/10/28 T.Ono add 監視改善2013№8
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TELRNM")) : i += 1
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TFKINM")) : i += 1
            '    ' 2013/10/28 T.Ono mod 監視改善2013№8
            '    'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TEL_MEMO1")) : i += 1
            '    'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TEL_MEMO2")) : i += 1
            '    'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("FUK_MEMO")) : i += 1
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TEL_MEMO1")) & Convert.ToString(dr.Item("TEL_MEMO2")) & Convert.ToString(dr.Item("FUK_MEMO")) : i += 1
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("FAX_REN")) : i += 1 ' 2014/12/10 H.Hosoda add 監視改善2014 №13 [連絡先]【FAX連絡欄】
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KANSHI_BIKO")) : i += 1 ' 2016/2/1 H.Mori add 監視改善2015 №10 [お客様情報]監視備考
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TKIGNM")) : i += 1
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TSADNM")) : i += 1
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TUSIN")) : i += 1    ' NCU接続(種別) 2017/02/17 W.GANEKO ADD 2016監視改善 №7
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("NCU_SETNM")) : i += 1  ' 接続区分 2017/02/17 W.GANEKO ADD 2016監視改善 №7
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SYOYMD")) : i += 1   ' 対応完了日 2017/02/17 W.GANEKO ADD 2016監視改善 №7
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SYOTIME")) : i += 1  ' 対応完了時刻 2017/02/17 W.GANEKO ADD 2016監視改善 №7
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SIJIYMD")) : i += 1
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SIJITIME")) : i += 1
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("STD")) : i += 1
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TSTANNM")) : i += 1 ' 2010/03/24 T.Watabe add [出動結果]【受信者氏名】
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SYUTDTNM")) : i += 1 ' 2010/03/24 T.Watabe add [出動結果]【出動対応者】
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SDYMD")) : i += 1
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SDTIME")) : i += 1
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TYAKYMD")) : i += 1
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TYAKTIME")) : i += 1
            '    ' 2013/10/28 T.Ono mod 監視改善2013№8
            '    'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SDTBIK2")) : i += 1
            '    'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SNTTOKKI")) : i += 1
            '    'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SDTBIK3")) : i += 1
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SDTBIK2")) & Convert.ToString(dr.Item("SNTTOKKI")) & Convert.ToString(dr.Item("SDTBIK3")) : i += 1
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("FKINM")) : i += 1
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SYOKANYMD")) : i += 1
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SYOKANTIME")) : i += 1
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("HOKBN")) : i += 1      ' 適用法令区分 2017/02/17 W.GANEKO ADD 2016監視改善 №7
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KYOKTKBN")) : i += 1   ' 供給形態区分 2017/02/17 W.GANEKO ADD 2016監視改善 №7
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("YOTOKBN")) : i += 1    ' 用途区分     2017/02/17 W.GANEKO ADD 2016監視改善 №7
            '    ExcelC.pCellVal(i) = "1"
            '    ExcelC.mWriteLine("")           '行をファイルに書き込む
            'Next
            '2017/02/17 W.GANEKO MOD 2016監視改善 №7 END

            ExcelC.mWriteLine("")                           '行をファイルに書き込む
            ExcelC.mClose()                                 'ファイルクローズ

            '圧縮先ファイルのあるフォルダ
            compressC.p_Dir = ExcelC.pDirName
            '日本語ファイル名の指定
            'compressC.p_NihongoFileName = "警報出力.xls"
            compressC.p_NihongoFileName = "対応結果明細.xls"               '2017/02/17 W.GANEKO ADD 2016監視改善 №7
            '圧縮元ファイル名
            compressC.p_FileName = ExcelC.pDirName & ExcelC.pFileName & ".xls"
            '圧縮先ファイル名
            compressC.p_madeFilename = ExcelC.pDirName & ExcelC.pFileName & ".lzh"
            '2014/01/16 T.Ono mod 監視改善2013 Excelを直接開くように変更、ファイルフルパスを返す
            ''圧縮実行
            ''compressC.mCompress()
            ''圧縮したファイルをBase64エンコードして戻す
            ''.xls形式に変更 2013/12/05 T.Ono mod 監視改善2013
            ''Return FileToStrC.mFileToStr(compressC.p_madeFilename.Replace(".lzh", ".exe"))
            'Return FileToStrC.mFileToStr(compressC.p_FileName)
            Return (compressC.p_FileName)

        Catch ex As Exception
            'エラーの内容とＳＱＬ文を返すbaba
            Return "ERROR:" & ex.ToString

        Finally
            cdb.mClose()        '接続クローズ
        End Try

    End Function
    '2017/02/17 W.GANEKO ADD 監視改善2016 №7
    '******************************************************************************
    '*　概　要:EXCEL出力（OUTLIST=1：全て）
    '*　備　考:対応ＤＢ取得
    '******************************************************************************
    Function excelOut1(ByVal ds As DataSet, ByVal dr As DataRow, ByVal ExcelC As Common.CExcel) As Common.CExcel

        Dim i As Integer
        Dim excel_h13px As String = "height:13px;text-align:left;font-size:10px;border-style:none;"
        Dim excel_h56px As String = "height:56px;text-align:left;font-size:10px;border-style:none;"
        Dim excel_backgroundcolor As String = "background-color:lightgrey;"
        Dim excel_w10px As String = "width:10px;"
        Dim excel_w30px As String = "width:30px;"
        Dim excel_w35px As String = "width:35px;"
        Dim excel_w40px As String = "width:40px;"
        Dim excel_w50px As String = "width:50px;"
        Dim excel_w60px As String = "width:60px;"
        Dim excel_w65px As String = "width:65px;"
        Dim excel_w70px As String = "width:70px;"
        Dim excel_w100px As String = "width:100px;"
        Dim excel_w150px As String = "width:150px;"
        Dim excel_w160px As String = "width:160px;"  'JMコード長さ  2023/01/06 ADD Y.ARAKAKI 2022更改No⑥ _帳票JMコード表示追加対応 
        Dim excel_w360px As String = "width:360px;"  'JM和名長さ    2023/01/06 ADD Y.ARAKAKI 2022更改No⑥ _帳票JMコード表示追加対応 

        Dim excel_h56px_w10px As String = "height:56px;width:10px;text-align:left;font-size:10px;border-style:none;"
        ' 2023/01/06 MOD START Y.ARAKAKI 2022更改No⑥ _帳票JMコード表示追加対応 pCellStyleの番号ずらし（途中で2項目追加した為。）
        ExcelC.pCellStyle(1) = excel_h56px & excel_w35px & excel_backgroundcolor    'FAXJA報告
        ExcelC.pCellStyle(2) = excel_h56px & excel_w35px & excel_backgroundcolor    'FAXｸﾗ報告
        ExcelC.pCellStyle(3) = excel_h56px & excel_w35px & excel_backgroundcolor    '累積報告
        ExcelC.pCellStyle(4) = excel_h56px & excel_w35px & excel_backgroundcolor    '依頼書
        ExcelC.pCellStyle(5) = excel_h56px & excel_w65px & excel_backgroundcolor    '発生月日
        ExcelC.pCellStyle(6) = excel_h56px & excel_w40px & excel_backgroundcolor    '発生時刻
        ExcelC.pCellStyle(7) = excel_h56px & excel_w65px & excel_backgroundcolor    '受信日
        ExcelC.pCellStyle(8) = excel_h56px & excel_w40px & excel_backgroundcolor    '受信時刻
        ExcelC.pCellStyle(9) = excel_h56px & excel_w40px & excel_backgroundcolor    '遅延時間
        ExcelC.pCellStyle(10) = excel_h56px & excel_w30px & excel_backgroundcolor   '流量区分

        ExcelC.pCellStyle(11) = excel_h56px & excel_w150px & excel_backgroundcolor  '警報１
        ExcelC.pCellStyle(12) = excel_h56px & excel_w100px & excel_backgroundcolor  '警報２
        ExcelC.pCellStyle(13) = excel_h56px & excel_w100px & excel_backgroundcolor  '警報３
        ExcelC.pCellStyle(14) = excel_h56px & excel_w40px & excel_backgroundcolor   '警報４
        ExcelC.pCellStyle(15) = excel_h56px & excel_w40px & excel_backgroundcolor   '警報５
        ExcelC.pCellStyle(16) = excel_h56px & excel_w40px & excel_backgroundcolor   '警報６
        ExcelC.pCellStyle(17) = excel_h56px & excel_w60px & excel_backgroundcolor   'お客様FLG
        ExcelC.pCellStyle(18) = excel_h56px & excel_w60px & excel_backgroundcolor   '指針値
        ExcelC.pCellStyle(19) = excel_h56px & excel_w50px & excel_backgroundcolor   'クライアントコード
        ExcelC.pCellStyle(20) = excel_h56px & excel_w50px & excel_backgroundcolor   '県名

        ExcelC.pCellStyle(21) = excel_h56px & excel_w50px & excel_backgroundcolor   'ＪＡコード
        ExcelC.pCellStyle(22) = excel_h56px & excel_w100px & excel_backgroundcolor  'ＪＡ名
        ExcelC.pCellStyle(23) = excel_h56px & excel_w160px & excel_backgroundcolor  'ＪＡ担当者報告先コード ' 2023/01/06 ADD Y.ARAKAKI 2022更改No⑥ _帳票JMコード表示追加対応
        ExcelC.pCellStyle(24) = excel_h56px & excel_w360px & excel_backgroundcolor  'ＪＡ担当者報告先名     ' 2023/01/06 ADD Y.ARAKAKI 2022更改No⑥ _帳票JMコード表示追加対応
        ExcelC.pCellStyle(25) = excel_h56px & excel_w100px & excel_backgroundcolor  '販売事業者コード
        ExcelC.pCellStyle(26) = excel_h56px & excel_w100px & excel_backgroundcolor  '販売事業者名
        ExcelC.pCellStyle(27) = excel_h56px & excel_w50px & excel_backgroundcolor   '販売所コード
        ExcelC.pCellStyle(28) = excel_h56px & excel_w60px & excel_backgroundcolor   'ＪＡ支所コード
        ExcelC.pCellStyle(29) = excel_h56px & excel_w100px & excel_backgroundcolor  'ＪＡ支所名
        ExcelC.pCellStyle(30) = excel_h56px & excel_w60px & excel_backgroundcolor   'お客様コード

        ExcelC.pCellStyle(31) = excel_h56px & excel_w100px & excel_backgroundcolor  'お客様名
        ExcelC.pCellStyle(32) = excel_h56px & excel_w60px & excel_backgroundcolor   '代表者氏名
        ExcelC.pCellStyle(33) = excel_h56px & excel_w100px & excel_backgroundcolor  '連絡先
        ExcelC.pCellStyle(34) = excel_h56px & excel_w100px & excel_backgroundcolor  '結線番号
        ExcelC.pCellStyle(35) = excel_h56px & excel_w100px & excel_backgroundcolor  '最終架電先
        ExcelC.pCellStyle(36) = excel_h56px & excel_w100px & excel_backgroundcolor  '住所
        ExcelC.pCellStyle(37) = excel_h56px & excel_w100px & excel_backgroundcolor  '販売区分
        ExcelC.pCellStyle(38) = excel_h56px & excel_w70px & excel_backgroundcolor   '発生区分
        ExcelC.pCellStyle(39) = excel_h56px & excel_w70px & excel_backgroundcolor   '対応区分
        ExcelC.pCellStyle(40) = excel_h56px & excel_w70px & excel_backgroundcolor   '処理区分

        ExcelC.pCellStyle(41) = excel_h56px & excel_w100px & excel_backgroundcolor  '監視ｾﾝﾀｰ担当者
        ExcelC.pCellStyle(42) = excel_h56px & excel_w70px & excel_backgroundcolor   '連絡相手
        ExcelC.pCellStyle(43) = excel_h56px & excel_w70px & excel_backgroundcolor   '電話連絡
        ExcelC.pCellStyle(44) = excel_h56px & excel_w70px & excel_backgroundcolor   '復帰対応状況
        ExcelC.pCellStyle(45) = excel_h56px & excel_w150px & excel_backgroundcolor  '監視対応内容
        ExcelC.pCellStyle(46) = excel_h56px & excel_w100px & excel_backgroundcolor  'メモ欄
        ExcelC.pCellStyle(47) = excel_h56px & excel_w70px & excel_backgroundcolor   '監視備考
        ExcelC.pCellStyle(48) = excel_h56px & excel_w70px & excel_backgroundcolor   '原因器具
        ExcelC.pCellStyle(49) = excel_h56px & excel_w100px & excel_backgroundcolor  '作動原因
        ExcelC.pCellStyle(50) = excel_h56px & excel_w30px & excel_backgroundcolor   'NCU接続(種別)

        ExcelC.pCellStyle(51) = excel_h56px & excel_w50px & excel_backgroundcolor   '接続区分
        ExcelC.pCellStyle(52) = excel_h56px & excel_w60px & excel_backgroundcolor   '対応完了日
        ExcelC.pCellStyle(53) = excel_h56px & excel_w60px & excel_backgroundcolor   '対応完了時刻
        ExcelC.pCellStyle(54) = excel_h56px & excel_w60px & excel_backgroundcolor   '出動依頼日
        ExcelC.pCellStyle(55) = excel_h56px & excel_w60px & excel_backgroundcolor   '出動依頼時刻
        ExcelC.pCellStyle(56) = excel_h56px & excel_w100px & excel_backgroundcolor  '出動会社名
        ExcelC.pCellStyle(57) = excel_h56px & excel_w100px & excel_backgroundcolor  '出動受付者
        ExcelC.pCellStyle(58) = excel_h56px & excel_w100px & excel_backgroundcolor  '出動対応者
        ExcelC.pCellStyle(59) = excel_h56px & excel_w60px & excel_backgroundcolor   '出動日
        ExcelC.pCellStyle(60) = excel_h56px & excel_w60px & excel_backgroundcolor   '出動時刻

        ExcelC.pCellStyle(61) = excel_h56px & excel_w60px & excel_backgroundcolor   '到着日
        ExcelC.pCellStyle(62) = excel_h56px & excel_w60px & excel_backgroundcolor   '到着時刻
        ExcelC.pCellStyle(63) = excel_h56px & excel_w100px & excel_backgroundcolor  '出動対応内容
        ExcelC.pCellStyle(64) = excel_h56px & excel_w100px & excel_backgroundcolor  '復帰操作
        ExcelC.pCellStyle(65) = excel_h56px & excel_w60px & excel_backgroundcolor   '処理完了日
        ExcelC.pCellStyle(66) = excel_h56px & excel_w60px & excel_backgroundcolor   '処理完了時刻
        ExcelC.pCellStyle(67) = excel_h56px & excel_w70px & excel_backgroundcolor   '適用法令区分
        ExcelC.pCellStyle(68) = excel_h56px & excel_w70px & excel_backgroundcolor   '供給形態区分
        ExcelC.pCellStyle(69) = excel_h56px & excel_w70px & excel_backgroundcolor   '用途区分
        ExcelC.pCellStyle(70) = excel_h56px & excel_w10px & excel_backgroundcolor   '（最終列「項目なし」→改行位置）
        ' 2023/01/06 MOD END   Y.ARAKAKI 2022更改No⑥ _帳票JMコード表示追加対応

        i = 1

        ' 2023/01/06 MOD START Y.ARAKAKI 2022更改No⑥ _帳票JMコード表示追加対応 ヘッダに2項目追加 ＋ コメント整理
        ExcelC.pCellVal(i) = Convert.ToString("FAXJA報告") : i += 1               '1   '2017/02/17 W.GANEKO MOD 2016監視改善 №7 
        ExcelC.pCellVal(i) = Convert.ToString("FAXｸﾗ報告") : i += 1               '2   '2017/02/17 W.GANEKO MOD 2016監視改善 №7 
        ExcelC.pCellVal(i) = Convert.ToString("累積報告") : i += 1                '3   '2017/02/17 W.GANEKO MOD 2016監視改善 №7 
        ExcelC.pCellVal(i) = Convert.ToString("依頼書") : i += 1                  '4   '2017/02/17 W.GANEKO MOD 2016監視改善 №7 
        ExcelC.pCellVal(i) = Convert.ToString("発生月日") : i += 1                '5   '2013/08/27 T.Ono add 監視改善2013№8     
        ExcelC.pCellVal(i) = Convert.ToString("発生時刻") : i += 1                '6   '2013/08/27 T.Ono add 監視改善2013№8     
        ExcelC.pCellVal(i) = Convert.ToString("受信日") : i += 1                  '7
        ExcelC.pCellVal(i) = Convert.ToString("受信時刻") : i += 1                '8
        ExcelC.pCellVal(i) = Convert.ToString("遅延時間") : i += 1                '9   '2013/08/27 T.Ono add 監視改善2013№8
        ExcelC.pCellVal(i) = Convert.ToString("流量区分") : i += 1                '10  '2013/08/27 T.Ono add 監視改善2013№8

        ExcelC.pCellVal(i) = Convert.ToString("警報１") : i += 1                  '11
        ExcelC.pCellVal(i) = Convert.ToString("警報２") : i += 1                  '12
        ExcelC.pCellVal(i) = Convert.ToString("警報３") : i += 1                  '13
        ExcelC.pCellVal(i) = Convert.ToString("警報４") : i += 1                  '14
        ExcelC.pCellVal(i) = Convert.ToString("警報５") : i += 1                  '15
        ExcelC.pCellVal(i) = Convert.ToString("警報６") : i += 1                  '16
        ExcelC.pCellVal(i) = Convert.ToString("お客様FLG") : i += 1               '17  '2013/08/27 T.Ono add 監視改善2013№8
        ExcelC.pCellVal(i) = Convert.ToString("指針値") : i += 1                  '18
        ExcelC.pCellVal(i) = Convert.ToString("クライアントコード") : i += 1      '19
        ExcelC.pCellVal(i) = Convert.ToString("県名") : i += 1                    '20

        ExcelC.pCellVal(i) = Convert.ToString("ＪＡコード") : i += 1              '21  '2014/12/11 H.Hosoda add 監視改善2014 №13  
        ExcelC.pCellVal(i) = Convert.ToString("ＪＡ名") : i += 1                  '22  '2014/12/11 H.Hosoda add 監視改善2014 №13  
        ExcelC.pCellVal(i) = Convert.ToString("ＪＡ担当者報告先コード") : i += 1  '23  '2023/01/06 ADD Y.ARAKAKI 2022更改No⑥
        ExcelC.pCellVal(i) = Convert.ToString("ＪＡ担当者報告先名") : i += 1      '24  '2023/01/06 ADD Y.ARAKAKI 2022更改No⑥      
        ExcelC.pCellVal(i) = Convert.ToString("販売事業者コード") : i += 1        '25  '2014/12/11 H.Hosoda add 監視改善2014 №13  
        ExcelC.pCellVal(i) = Convert.ToString("販売事業者名") : i += 1            '26  '2014/12/11 H.Hosoda add 監視改善2014 №13  
        ExcelC.pCellVal(i) = Convert.ToString("販売所コード") : i += 1            '27  '2017/02/17 W.GANEKO add 監視改善2016 №7   
        ExcelC.pCellVal(i) = Convert.ToString("ＪＡ支所コード") : i += 1          '28
        ExcelC.pCellVal(i) = Convert.ToString("ＪＡ支所名") : i += 1              '29
        ExcelC.pCellVal(i) = Convert.ToString("お客様コード") : i += 1            '30

        ExcelC.pCellVal(i) = Convert.ToString("お客様名") : i += 1                '31
        ExcelC.pCellVal(i) = Convert.ToString("代表者氏名") : i += 1              '32  '2017/02/17 W.GANEKO add 監視改善2016 №7
        ExcelC.pCellVal(i) = Convert.ToString("連絡先") : i += 1                  '33
        ExcelC.pCellVal(i) = Convert.ToString("結線番号") : i += 1                '34
        ExcelC.pCellVal(i) = Convert.ToString("最終架電先") : i += 1              '35  '2016/2/1 H.Mori add 監視改善2015 №10
        ExcelC.pCellVal(i) = Convert.ToString("住所") : i += 1                    '36
        ExcelC.pCellVal(i) = Convert.ToString("販売区分") : i += 1                '37  '2015/12/10 H.Mori add 監視改善2015 №10
        ExcelC.pCellVal(i) = Convert.ToString("発生区分") : i += 1                '38
        ExcelC.pCellVal(i) = Convert.ToString("対応区分") : i += 1                '39
        ExcelC.pCellVal(i) = Convert.ToString("処理区分") : i += 1                '40

        ExcelC.pCellVal(i) = Convert.ToString("監視ｾﾝﾀｰ担当者") : i += 1          '41  '2010/03/24 T.Watabe add
        ExcelC.pCellVal(i) = Convert.ToString("連絡相手") : i += 1                '42  '2013/10/28 T.Ono add 監視改善2013№8
        ExcelC.pCellVal(i) = Convert.ToString("電話連絡") : i += 1                '43
        ExcelC.pCellVal(i) = Convert.ToString("復帰対応状況") : i += 1            '44
        ExcelC.pCellVal(i) = Convert.ToString("監視対応内容") : i += 1            '45
        ExcelC.pCellVal(i) = Convert.ToString("メモ欄") : i += 1                  '46  '2014/12/09 H.Hosoda add 監視改善2014 №13
        ExcelC.pCellVal(i) = Convert.ToString("監視備考") : i += 1                '47  '2016/2/1 H.Mori add 監視改善2015 №10
        ExcelC.pCellVal(i) = Convert.ToString("原因器具") : i += 1                '48
        ExcelC.pCellVal(i) = Convert.ToString("作動原因") : i += 1                '49
        ExcelC.pCellVal(i) = Convert.ToString("NCU接続(種別)") : i += 1           '50  '2017/02/17 W.GANEKO add 監視改善2016 №7

        ExcelC.pCellVal(i) = Convert.ToString("接続区分") : i += 1                '51  '2017/02/17 W.GANEKO add 監視改善2016 №7
        ExcelC.pCellVal(i) = Convert.ToString("対応完了日") : i += 1              '52  '2017/02/17 W.GANEKO add 監視改善2016 №7
        ExcelC.pCellVal(i) = Convert.ToString("対応完了時刻") : i += 1            '53  '2017/02/17 W.GANEKO add 監視改善2016 №7
        ExcelC.pCellVal(i) = Convert.ToString("出動依頼日") : i += 1              '54
        ExcelC.pCellVal(i) = Convert.ToString("出動依頼時刻") : i += 1            '55
        ExcelC.pCellVal(i) = Convert.ToString("出動会社名") : i += 1              '56
        ExcelC.pCellVal(i) = Convert.ToString("出動受付者") : i += 1              '57  '2010/03/24 T.Watabe add 
        ExcelC.pCellVal(i) = Convert.ToString("出動対応者") : i += 1              '58  '2010/03/24 T.Watabe add 
        ExcelC.pCellVal(i) = Convert.ToString("出動日") : i += 1                  '59
        ExcelC.pCellVal(i) = Convert.ToString("出動時刻") : i += 1                '60

        ExcelC.pCellVal(i) = Convert.ToString("到着日") : i += 1                  '61
        ExcelC.pCellVal(i) = Convert.ToString("到着時刻") : i += 1                '62
        ExcelC.pCellVal(i) = Convert.ToString("出動対応内容") : i += 1            '63
        ExcelC.pCellVal(i) = Convert.ToString("復帰操作") : i += 1                '64
        ExcelC.pCellVal(i) = Convert.ToString("処理完了日") : i += 1              '65
        ExcelC.pCellVal(i) = Convert.ToString("処理完了時刻") : i += 1            '66
        ExcelC.pCellVal(i) = Convert.ToString("適用法令区分") : i += 1            '67
        ExcelC.pCellVal(i) = Convert.ToString("供給形態区分") : i += 1            '68
        ExcelC.pCellVal(i) = Convert.ToString("用途区分") : i += 1                '69
        ExcelC.mWriteLine("")       '行をファイルに書き込む                       '(70→端の列、記載なしのまま)
        ' 2023/01/06 MOD END   Y.ARAKAKI 2022更改No⑥ _帳票JMコード表示追加対応

        ''明細データ出力
        Dim iCnt As Integer
        'APサーバからの戻り値をループする
        '明細データ出力
        For iCnt = 0 To ds.Tables(0).Rows.Count - 1
            dr = ds.Tables(0).Rows(iCnt)
            ' 2023/01/06 MOD START Y.ARAKAKI 2022更改No⑥ _帳票JMコード表示追加対応 明細に、ヘッダと同様2項目追加
            '明細項目
            ExcelC.pCellStyle(1) = excel_h13px & excel_w35px
            ExcelC.pCellStyle(2) = excel_h13px & excel_w35px
            ExcelC.pCellStyle(3) = excel_h13px & excel_w35px
            ExcelC.pCellStyle(4) = excel_h13px & excel_w35px
            ExcelC.pCellStyle(5) = excel_h13px & excel_w65px
            ExcelC.pCellStyle(6) = excel_h13px & excel_w40px
            ExcelC.pCellStyle(7) = excel_h13px & excel_w65px
            ExcelC.pCellStyle(8) = excel_h13px & excel_w40px
            ExcelC.pCellStyle(9) = excel_h13px & excel_w40px
            ExcelC.pCellStyle(10) = excel_h13px & excel_w30px

            ExcelC.pCellStyle(11) = excel_h13px & excel_w150px
            ExcelC.pCellStyle(12) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(13) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(14) = excel_h13px & excel_w40px
            ExcelC.pCellStyle(15) = excel_h13px & excel_w40px
            ExcelC.pCellStyle(16) = excel_h13px & excel_w40px
            ExcelC.pCellStyle(17) = excel_h13px & excel_w60px
            ExcelC.pCellStyle(18) = excel_h13px & excel_w60px
            ExcelC.pCellStyle(19) = excel_h13px & excel_w50px
            ExcelC.pCellStyle(20) = excel_h13px & excel_w50px

            ExcelC.pCellStyle(21) = excel_h13px & excel_w50px
            ExcelC.pCellStyle(22) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(23) = excel_h13px & excel_w160px  'JMコード  2023/01/06 ADD Y.ARAKAKI 2022更改No⑥ _帳票JMコード表示追加対応 
            ExcelC.pCellStyle(24) = excel_h13px & excel_w360px  'JM和名    2023/01/06 ADD Y.ARAKAKI 2022更改No⑥ _帳票JMコード表示追加対応 
            ExcelC.pCellStyle(25) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(26) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(27) = excel_h13px & excel_w50px
            ExcelC.pCellStyle(28) = excel_h13px & excel_w60px
            ExcelC.pCellStyle(29) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(30) = excel_h13px & excel_w60px

            ExcelC.pCellStyle(31) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(32) = excel_h13px & excel_w60px
            ExcelC.pCellStyle(33) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(34) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(35) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(36) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(37) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(38) = excel_h13px & excel_w70px
            ExcelC.pCellStyle(39) = excel_h13px & excel_w70px
            ExcelC.pCellStyle(40) = excel_h13px & excel_w70px

            ExcelC.pCellStyle(41) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(42) = excel_h13px & excel_w70px
            ExcelC.pCellStyle(43) = excel_h13px & excel_w70px
            ExcelC.pCellStyle(44) = excel_h13px & excel_w70px
            ExcelC.pCellStyle(45) = excel_h13px & excel_w150px
            ExcelC.pCellStyle(46) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(47) = excel_h13px & excel_w70px
            ExcelC.pCellStyle(48) = excel_h13px & excel_w70px
            ExcelC.pCellStyle(49) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(50) = excel_h13px & excel_w30px

            ExcelC.pCellStyle(51) = excel_h13px & excel_w50px
            ExcelC.pCellStyle(52) = excel_h13px & excel_w60px
            ExcelC.pCellStyle(53) = excel_h13px & excel_w60px
            ExcelC.pCellStyle(54) = excel_h13px & excel_w60px
            ExcelC.pCellStyle(55) = excel_h13px & excel_w60px
            ExcelC.pCellStyle(56) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(57) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(58) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(59) = excel_h13px & excel_w60px
            ExcelC.pCellStyle(60) = excel_h13px & excel_w60px

            ExcelC.pCellStyle(61) = excel_h13px & excel_w60px
            ExcelC.pCellStyle(62) = excel_h13px & excel_w60px
            ExcelC.pCellStyle(63) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(64) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(65) = excel_h13px & excel_w60px
            ExcelC.pCellStyle(66) = excel_h13px & excel_w60px
            ExcelC.pCellStyle(67) = excel_h13px & excel_w70px
            ExcelC.pCellStyle(68) = excel_h13px & excel_w70px
            ExcelC.pCellStyle(69) = excel_h13px & excel_w70px
            ExcelC.pCellStyle(70) = excel_h13px & excel_w10px
            ' 2023/01/06 MOD END   Y.ARAKAKI 2022更改No⑥ _帳票JMコード表示追加対応
            i = 1
            ' 2023/01/06 MOD START Y.ARAKAKI 2022更改No⑥ _帳票JMコード表示追加対応 明細に、ヘッダと同様2項目追加
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("FAXKBN")) : i += 1              '[ 1]FAX不要(JA)     1:不要/2:必要
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("FAXKURAKBN")) : i += 1          '[ 2]FAX不要(ｸﾗｲｱﾝﾄ) 1:不要/2:必要
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("FAXRUISEKIKBN")) : i += 1       '[ 3]報告不要(累積)  1:不要/2:必要  2016/02/26 H.Mori add 監視改善2015 №10
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("FAXSPOTKBN")) : i += 1          '[ 4]依頼書                  2017/02/17 W.GANEKO ADD 2016監視改善 №7
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("NCUHATYMD")) : i += 1           '[ 5]発生月日                2013/08/29 T.Ono add 監視改善2013№8
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("NCUHATTIME")) : i += 1          '[ 6]発生時刻                2013/08/29 T.Ono add 監視改善2013№8
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("HATYMD")) : i += 1              '[ 7]受信日
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("HATTIME")) : i += 1             '[ 8]受信時刻
            ExcelC.pCellVal(i) = fncSetChien(Convert.ToString(dr.Item("CHIEN"))) : i += 1  '[ 9]遅延時間                2013/10/28 T.Ono add 監視改善2013№8
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("RYURYO")) : i += 1              '[10]流量区分                2013/08/29 T.Ono add 監視改善2013№8

            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KMNM1")) : i += 1               '[11]警報１
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KMNM2")) : i += 1               '[12]警報２
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KMNM3")) : i += 1               '[13]警報３
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KMNM4")) : i += 1               '[14]警報４
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KMNM5")) : i += 1               '[15]警報５
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KMNM6")) : i += 1               '[16]警報６
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("OYAKU_FLG")) : i += 1           '[17]お客様FLG               2013/08/29 T.Ono add 監視改善2013№8
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KENSIN")) : i += 1              '[18]指針値
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KURACD")) : i += 1              '[19]クライアントコード
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KENNM")) : i += 1               '[20]県名

            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("JACD")) : i += 1                '[21]ＪＡコード              2014/12/11 H.Hosoda add 監視改善2014 №13 [利用者]【JAコード】
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("JANM")) : i += 1                '[22]ＪＡ名                  2014/12/11 H.Hosoda add 監視改善2014 №13 [利用者]【JA名】
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KINRENCD")) : i += 1            '[23]ＪＡ担当者報告先コード  2023/01/06 ADD Y.ARAKAKI 2022更改No⑥
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("JMNAME")) : i += 1              '[24]ＪＡ担当者報告先名      2023/01/06 ADD Y.ARAKAKI 2022更改No⑥
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("HANJICD")) : i += 1             '[25]販売事業者コード        2014/12/11 H.Hosoda add 監視改善2014 №13 [レコード情報]【販売事業者コード】
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("HANJINM")) : i += 1             '[26]販売事業者名            2014/12/11 H.Hosoda add 監視改善2014 №13 [レコード情報]【販売事業者名】
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("HANBCD")) : i += 1              '[27]販売所コード            2017/02/17 W.GANEKO ADD 2016監視改善 №7
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("ACBCD")) : i += 1               '[28]ＪＡ支所コード
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("ACBNM")) : i += 1               '[29]ＪＡ支所名
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("USER_CD")) : i += 1             '[30]お客様コード

            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("JUSYONM")) : i += 1             '[31]お客様名
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("DAIHYO_NAME")) : i += 1         '[32]代表者氏名              2017/02/17 W.GANEKO ADD 2016監視改善 №7
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("RENTEL")) : i += 1              '[33]連絡先
            ExcelC.pCellVal(i) = fncSetJUTEL(Convert.ToString(dr.Item("JUTEL1")), Convert.ToString(dr.Item("JUTEL2"))) : i += 1 '[34]結線電話番号 2013/10/28 T.Ono add 監視改善2013№8
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KOK_TELNO")) : i += 1           '[35]最終架電先              2016/02/01 H.Mori add 監視改善2015 №10 【発信電話番号】
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("ADDR")) : i += 1                '[36]住所
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("HANBAI_KBN")) : i += 1          '[37]販売区分                2015/12/10 H.Mori add 監視改善2015 №10 [お客様情報]販売区分
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("HATKBN_NAI")) : i += 1          '[38]発生区分
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TAIOKBN_NAI")) : i += 1         '[39]対応区分
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TMSKB_NAI")) : i += 1           '[40]処理区分

            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TKTANCD_NM")) : i += 1          '[41]監視ｾﾝﾀｰ担当者          2010/03/24 T.Watabe add  [対応情報]【監視センター担当者名】 
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TAITCD")) : i += 1              '[42]連絡相手                2013/10/28 T.Ono add 監視改善2013№8
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TELRNM")) : i += 1              '[43]電話連絡
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TFKINM")) : i += 1              '[44]復帰対応状況
            'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TEL_MEMO1")) & Convert.ToString(dr.Item("TEL_MEMO2")) & Convert.ToString(dr.Item("FUK_MEMO")) : i += 1  '2020/11/01 T.Ono mod 2020監視改善
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TEL_MEMO1")) & Convert.ToString(dr.Item("TEL_MEMO2")) & Convert.ToString(dr.Item("FUK_MEMO")) &
                                 Convert.ToString(dr.Item("TEL_MEMO4")) & Convert.ToString(dr.Item("TEL_MEMO5")) & Convert.ToString(dr.Item("TEL_MEMO6")) : i += 1  '[45]監視対応内容
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("FAX_REN")) : i += 1             '[46]メモ欄                  2014/12/10 H.Hosoda add 監視改善2014 №13 [連絡先]【FAX連絡欄】
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KANSHI_BIKO")) : i += 1         '[47]監視備考                2016/02/01 H.Mori add 監視改善2015 №10 [お客様情報]監視備考
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TKIGNM")) : i += 1              '[48]原因器具
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TSADNM")) : i += 1              '[49]作動原因
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TUSIN")) : i += 1               '[50]NCU接続(種別)           2017/02/17 W.GANEKO ADD 2016監視改善 №7

            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("NCU_SETNM")) : i += 1           '[51]接続区分                2017/02/17 W.GANEKO ADD 2016監視改善 №7
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SYOYMD")) : i += 1              '[52]対応完了日              2017/02/17 W.GANEKO ADD 2016監視改善 №7
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SYOTIME")) : i += 1             '[53]対応完了時刻            2017/02/17 W.GANEKO ADD 2016監視改善 №7
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SIJIYMD")) : i += 1             '[54]出動依頼日
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SIJITIME")) : i += 1            '[55]出動依頼時刻
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("STD")) : i += 1                 '[56]出動会社名
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TSTANNM")) : i += 1             '[57]出動受付者              2010/03/24 T.Watabe add [出動結果]【受信者氏名】
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SYUTDTNM")) : i += 1            '[58]出動対応者              2010/03/24 T.Watabe add [出動結果]【出動対応者】
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SDYMD")) : i += 1               '[59]出動日
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SDTIME")) : i += 1              '[60]出動時刻

            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TYAKYMD")) : i += 1             '[61]到着日
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TYAKTIME")) : i += 1            '[62]到着時刻
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SDTBIK2")) & Convert.ToString(dr.Item("SNTTOKKI")) & Convert.ToString(dr.Item("SDTBIK3")) : i += 1 '[63]出動対応内容 
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("FKINM")) : i += 1               '[64]復帰操作
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SYOKANYMD")) : i += 1           '[65]処理完了日
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SYOKANTIME")) : i += 1          '[66]処理完了時刻
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("HOKBN")) : i += 1               '[67]適用法令区分            2017/02/17 W.GANEKO ADD 2016監視改善 №7
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KYOKTKBN")) : i += 1            '[68]供給形態区分            2017/02/17 W.GANEKO ADD 2016監視改善 №7
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("YOTOKBN")) : i += 1             '[69]用途区分                2017/02/17 W.GANEKO ADD 2016監視改善 №7
            ExcelC.pCellVal(i) = "1"                                                       '[70]※最終列（ヘッダ記載なし）
            ExcelC.mWriteLine("")           '行をファイルに書き込む
            ' 2023/01/06 MOD END   Y.ARAKAKI 2022更改No⑥ _帳票JMコード表示追加対応
        Next

        Return ExcelC
    End Function
    '2017/02/17 W.GANEKO ADD 監視改善2016 №7
    '******************************************************************************
    '*　概　要:EXCEL出力（OUTLIST=2：日次報告と同じ(出動会社あり)／OUTLIST=3：日次報告と同じ(出動会社なし)）
    '*　備　考:対応ＤＢ取得
    '******************************************************************************
    Function excelOut2(ByVal OUTLIST As String, ByVal ds As DataSet, ByVal dr As DataRow, ByVal ExcelC As Common.CExcel) As Common.CExcel

        Dim i As Integer
        Dim excel_h13px As String = "height:13px;text-align:left;font-size:10px;border-style:none;"
        Dim excel_h56px As String = "height:56px;text-align:left;font-size:10px;border-style:none;"
        Dim excel_backgroundcolor As String = "background-color:lightgrey;"
        Dim excel_w10px As String = "width:10px;"
        Dim excel_w30px As String = "width:30px;"
        Dim excel_w35px As String = "width:35px;"
        Dim excel_w40px As String = "width:40px;"
        Dim excel_w50px As String = "width:50px;"
        Dim excel_w60px As String = "width:60px;"
        Dim excel_w65px As String = "width:65px;"
        Dim excel_w70px As String = "width:70px;"
        Dim excel_w100px As String = "width:100px;"
        Dim excel_w150px As String = "width:150px;"
        Dim excel_h56px_w10px As String = "height:56px;width:10px;text-align:left;font-size:10px;border-style:none;"
        'Dim maxCnt As Integer
        'If OUTLIST = "2" Then
        '    maxCnt = 78
        'ElseIf OUTLIST = "3" Then
        '    maxCnt = 47
        'End If
        Dim x As Integer
        ExcelC.pCellStyle(1) = excel_h56px & excel_w50px & excel_backgroundcolor
        ExcelC.pCellStyle(2) = excel_h56px & excel_w100px & excel_backgroundcolor
        ExcelC.pCellStyle(3) = excel_h56px & excel_w100px & excel_backgroundcolor
        ExcelC.pCellStyle(4) = excel_h56px & excel_w100px & excel_backgroundcolor
        ExcelC.pCellStyle(5) = excel_h56px & excel_w100px & excel_backgroundcolor
        ExcelC.pCellStyle(6) = excel_h56px & excel_w100px & excel_backgroundcolor
        ExcelC.pCellStyle(7) = excel_h56px & excel_w60px & excel_backgroundcolor
        ExcelC.pCellStyle(8) = excel_h56px & excel_w100px & excel_backgroundcolor
        ExcelC.pCellStyle(9) = excel_h56px & excel_w100px & excel_backgroundcolor
        ExcelC.pCellStyle(10) = excel_h56px & excel_w100px & excel_backgroundcolor
        ExcelC.pCellStyle(11) = excel_h56px & excel_w100px & excel_backgroundcolor
        ExcelC.pCellStyle(12) = excel_h56px & excel_w60px & excel_backgroundcolor
        ExcelC.pCellStyle(13) = excel_h56px & excel_w60px & excel_backgroundcolor
        ExcelC.pCellStyle(14) = excel_h56px & excel_w60px & excel_backgroundcolor
        ExcelC.pCellStyle(15) = excel_h56px & excel_w60px & excel_backgroundcolor
        ExcelC.pCellStyle(16) = excel_h56px & excel_w30px & excel_backgroundcolor
        ExcelC.pCellStyle(17) = excel_h56px & excel_w60px & excel_backgroundcolor
        ExcelC.pCellStyle(18) = excel_h56px & excel_w60px & excel_backgroundcolor

        ExcelC.pCellStyle(19) = excel_h56px & excel_w60px & excel_backgroundcolor
        ExcelC.pCellStyle(20) = excel_h56px & excel_w100px & excel_backgroundcolor
        ExcelC.pCellStyle(21) = excel_h56px & excel_w30px & excel_backgroundcolor
        ExcelC.pCellStyle(22) = excel_h56px & excel_w100px & excel_backgroundcolor
        ExcelC.pCellStyle(23) = excel_h56px & excel_w100px & excel_backgroundcolor
        ExcelC.pCellStyle(24) = excel_h56px & excel_w100px & excel_backgroundcolor
        ExcelC.pCellStyle(25) = excel_h56px & excel_w100px & excel_backgroundcolor
        ExcelC.pCellStyle(26) = excel_h56px & excel_w40px & excel_backgroundcolor
        ExcelC.pCellStyle(27) = excel_h56px & excel_w40px & excel_backgroundcolor
        ExcelC.pCellStyle(28) = excel_h56px & excel_w40px & excel_backgroundcolor
        ExcelC.pCellStyle(29) = excel_h56px & excel_w70px & excel_backgroundcolor
        ExcelC.pCellStyle(30) = excel_h56px & excel_w70px & excel_backgroundcolor
        ExcelC.pCellStyle(31) = excel_h56px & excel_w100px & excel_backgroundcolor
        ExcelC.pCellStyle(32) = excel_h56px & excel_w60px & excel_backgroundcolor
        ExcelC.pCellStyle(33) = excel_h56px & excel_w60px & excel_backgroundcolor
        ExcelC.pCellStyle(34) = excel_h56px & excel_w60px & excel_backgroundcolor
        ExcelC.pCellStyle(35) = excel_h56px & excel_w60px & excel_backgroundcolor
        ExcelC.pCellStyle(36) = excel_h56px & excel_w70px & excel_backgroundcolor

        ExcelC.pCellStyle(37) = excel_h56px & excel_w100px & excel_backgroundcolor
        ExcelC.pCellStyle(38) = excel_h56px & excel_w150px & excel_backgroundcolor
        ExcelC.pCellStyle(39) = excel_h56px & excel_w70px & excel_backgroundcolor
        ExcelC.pCellStyle(40) = excel_h56px & excel_w70px & excel_backgroundcolor
        ExcelC.pCellStyle(41) = excel_h56px & excel_w100px & excel_backgroundcolor
        ExcelC.pCellStyle(42) = excel_h56px & excel_w100px & excel_backgroundcolor
        ExcelC.pCellStyle(43) = excel_h56px & excel_w70px & excel_backgroundcolor
        If OUTLIST = "2" Then
            ExcelC.pCellStyle(44) = excel_h56px & excel_w100px & excel_backgroundcolor
            ExcelC.pCellStyle(45) = excel_h56px & excel_w100px & excel_backgroundcolor
            ExcelC.pCellStyle(46) = excel_h56px & excel_w100px & excel_backgroundcolor
            ExcelC.pCellStyle(47) = excel_h56px & excel_w100px & excel_backgroundcolor
            ExcelC.pCellStyle(48) = excel_h56px & excel_w100px & excel_backgroundcolor
            ExcelC.pCellStyle(49) = excel_h56px & excel_w150px & excel_backgroundcolor
            ExcelC.pCellStyle(50) = excel_h56px & excel_w70px & excel_backgroundcolor
            ExcelC.pCellStyle(51) = excel_h56px & excel_w70px & excel_backgroundcolor
            ExcelC.pCellStyle(52) = excel_h56px & excel_w70px & excel_backgroundcolor
            ExcelC.pCellStyle(53) = excel_h56px & excel_w100px & excel_backgroundcolor
            ExcelC.pCellStyle(54) = excel_h56px & excel_w40px & excel_backgroundcolor

            ExcelC.pCellStyle(55) = excel_h56px & excel_w100px & excel_backgroundcolor
            ExcelC.pCellStyle(56) = excel_h56px & excel_w40px & excel_backgroundcolor
            ExcelC.pCellStyle(57) = excel_h56px & excel_w40px & excel_backgroundcolor
            ExcelC.pCellStyle(58) = excel_h56px & excel_w40px & excel_backgroundcolor
            ExcelC.pCellStyle(59) = excel_h56px & excel_w40px & excel_backgroundcolor
            ExcelC.pCellStyle(60) = excel_h56px & excel_w40px & excel_backgroundcolor
            ExcelC.pCellStyle(61) = excel_h56px & excel_w40px & excel_backgroundcolor
            ExcelC.pCellStyle(62) = excel_h56px & excel_w40px & excel_backgroundcolor
            ExcelC.pCellStyle(63) = excel_h56px & excel_w40px & excel_backgroundcolor
            ExcelC.pCellStyle(64) = excel_h56px & excel_w60px & excel_backgroundcolor
            ExcelC.pCellStyle(65) = excel_h56px & excel_w60px & excel_backgroundcolor
            ExcelC.pCellStyle(66) = excel_h56px & excel_w60px & excel_backgroundcolor
            ExcelC.pCellStyle(67) = excel_h56px & excel_w60px & excel_backgroundcolor
            ExcelC.pCellStyle(68) = excel_h56px & excel_w60px & excel_backgroundcolor
            ExcelC.pCellStyle(69) = excel_h56px & excel_w60px & excel_backgroundcolor
            ExcelC.pCellStyle(70) = excel_h56px & excel_w60px & excel_backgroundcolor
            ExcelC.pCellStyle(71) = excel_h56px & excel_w60px & excel_backgroundcolor
            ExcelC.pCellStyle(72) = excel_h56px & excel_w100px & excel_backgroundcolor

            ExcelC.pCellStyle(73) = excel_h56px & excel_w60px & excel_backgroundcolor
            ExcelC.pCellStyle(74) = excel_h56px & excel_w70px & excel_backgroundcolor
            ExcelC.pCellStyle(75) = excel_h56px & excel_w35px & excel_backgroundcolor
            ExcelC.pCellStyle(76) = excel_h56px & excel_w35px & excel_backgroundcolor
            ExcelC.pCellStyle(77) = excel_h56px & excel_w35px & excel_backgroundcolor
            ExcelC.pCellStyle(78) = excel_h56px & excel_w35px & excel_backgroundcolor
            ExcelC.pCellStyle(79) = excel_h56px & excel_w10px & excel_backgroundcolor
        ElseIf OUTLIST = "3" Then
            ExcelC.pCellStyle(44) = excel_h56px & excel_w35px & excel_backgroundcolor
            ExcelC.pCellStyle(45) = excel_h56px & excel_w35px & excel_backgroundcolor
            ExcelC.pCellStyle(46) = excel_h56px & excel_w35px & excel_backgroundcolor
            ExcelC.pCellStyle(47) = excel_h56px & excel_w35px & excel_backgroundcolor
            ExcelC.pCellStyle(48) = excel_h56px & excel_w10px & excel_backgroundcolor
        End If

        i = 1
        ExcelC.pCellVal(i) = Convert.ToString("県名") : i += 1                                               '1
        ExcelC.pCellVal(i) = Convert.ToString("供給センター名") : i += 1                                     '2
        ExcelC.pCellVal(i) = Convert.ToString("ＪＡコード") : i += 1                                         '3
        ExcelC.pCellVal(i) = Convert.ToString("ＪＡ名") : i += 1                                             '4
        ExcelC.pCellVal(i) = Convert.ToString("ＪＡ支所コード") : i += 1                                     '5
        ExcelC.pCellVal(i) = Convert.ToString("ＪＡ支所名") : i += 1                                         '6
        ExcelC.pCellVal(i) = Convert.ToString("お客様コード") : i += 1                                       '7
        ExcelC.pCellVal(i) = Convert.ToString("お客様名") : i += 1                                           '8
        ExcelC.pCellVal(i) = Convert.ToString("連絡先") : i += 1                                             '9
        ExcelC.pCellVal(i) = Convert.ToString("結線番号") : i += 1                                           '10

        ExcelC.pCellVal(i) = Convert.ToString("住所") : i += 1                                               '11
        ExcelC.pCellVal(i) = Convert.ToString("取引中止日") : i += 1                                         '12
        ExcelC.pCellVal(i) = Convert.ToString("取引廃止日") : i += 1                                         '13
        ExcelC.pCellVal(i) = Convert.ToString("地図番号") : i += 1                                           '14
        ExcelC.pCellVal(i) = Convert.ToString("集合区分") : i += 1                                           '15
        ExcelC.pCellVal(i) = Convert.ToString("NCU設置区分") : i += 1                                        '16
        ExcelC.pCellVal(i) = Convert.ToString("お客様状態") : i += 1                                         '17
        ExcelC.pCellVal(i) = Convert.ToString("受信日") : i += 1                                             '18
        ExcelC.pCellVal(i) = Convert.ToString("受信時刻") : i += 1                                           '19
        ExcelC.pCellVal(i) = Convert.ToString("メータ値") : i += 1                                           '20

        ExcelC.pCellVal(i) = Convert.ToString("流量区分") : i += 1                                           '21
        ExcelC.pCellVal(i) = Convert.ToString("メータ種別") : i += 1                                         '22
        ExcelC.pCellVal(i) = Convert.ToString("警報１") : i += 1                                             '23
        ExcelC.pCellVal(i) = Convert.ToString("警報２") : i += 1                                             '24
        ExcelC.pCellVal(i) = Convert.ToString("警報３") : i += 1                                             '25
        ExcelC.pCellVal(i) = Convert.ToString("警報４") : i += 1                                             '26
        ExcelC.pCellVal(i) = Convert.ToString("警報５") : i += 1                                             '27
        ExcelC.pCellVal(i) = Convert.ToString("警報６") : i += 1                                             '28
        ExcelC.pCellVal(i) = Convert.ToString("対応区分") : i += 1                                           '29
        ExcelC.pCellVal(i) = Convert.ToString("処理区分") : i += 1                                           '30

        ExcelC.pCellVal(i) = Convert.ToString("監視ｾﾝﾀｰ担当") : i += 1                                       '31
        ExcelC.pCellVal(i) = Convert.ToString("依頼日") : i += 1                                             '32
        ExcelC.pCellVal(i) = Convert.ToString("依頼時刻") : i += 1                                           '33
        ExcelC.pCellVal(i) = Convert.ToString("対応完了日") : i += 1                                         '34
        ExcelC.pCellVal(i) = Convert.ToString("対応完了時刻") : i += 1                                       '35
        ExcelC.pCellVal(i) = Convert.ToString("連絡相手") : i += 1                                           '36
        ExcelC.pCellVal(i) = Convert.ToString("電話連絡内容") : i += 1                                       '37
        ExcelC.pCellVal(i) = Convert.ToString("監視対応内容") : i += 1                                       '38
        ExcelC.pCellVal(i) = Convert.ToString("原因器具") : i += 1                                           '39
        ExcelC.pCellVal(i) = Convert.ToString("作動原因") : i += 1                                           '40

        ExcelC.pCellVal(i) = Convert.ToString("出動依頼内容") : i += 1                                       '41
        ExcelC.pCellVal(i) = Convert.ToString("出動依頼備考") : i += 1                                       '42
        ExcelC.pCellVal(i) = Convert.ToString("処理番号(照会用)") : i += 1                                   '43
        If OUTLIST = "2" Then
            ExcelC.pCellVal(i) = Convert.ToString("出動委託先") : i += 1                                         '44
            ExcelC.pCellVal(i) = Convert.ToString("支所・拠点名") : i += 1                                       '45
            ExcelC.pCellVal(i) = Convert.ToString("出動対応者") : i += 1                                         '46
            ExcelC.pCellVal(i) = Convert.ToString("対応相手") : i += 1                                           '47
            ExcelC.pCellVal(i) = Convert.ToString("ガス関連") : i += 1                                           '48
            ExcelC.pCellVal(i) = Convert.ToString("お客様のお話内容") : i += 1                                   '49
            ExcelC.pCellVal(i) = Convert.ToString("復帰対応") : i += 1                                           '50

            ExcelC.pCellVal(i) = Convert.ToString("ﾒｰﾀ作動原因１") : i += 1                                      '51
            ExcelC.pCellVal(i) = Convert.ToString("原因器具") : i += 1                                           '52
            ExcelC.pCellVal(i) = Convert.ToString("出動結果内容/報告") : i += 1                                  '53
            ExcelC.pCellVal(i) = Convert.ToString("ガス漏れ点検") : i += 1                                       '54
            ExcelC.pCellVal(i) = Convert.ToString("（ｶﾞｽ漏れ）原因") : i += 1                                    '55
            ExcelC.pCellVal(i) = Convert.ToString("ガス切れ点検") : i += 1                                       '56
            ExcelC.pCellVal(i) = Convert.ToString("ﾒｰﾀ点検") : i += 1                                            '57
            ExcelC.pCellVal(i) = Convert.ToString("ｺﾞﾑﾎｰｽ交換") : i += 1                                         '58
            ExcelC.pCellVal(i) = Convert.ToString("調整器点検") : i += 1                                         '59

            ExcelC.pCellVal(i) = Convert.ToString("容器･中間ﾊﾞﾙﾌﾞ") : i += 1                                     '60
            ExcelC.pCellVal(i) = Convert.ToString("ＣＯ濃度") : i += 1                                           '61
            ExcelC.pCellVal(i) = Convert.ToString("給排気口") : i += 1                                           '62
            ExcelC.pCellVal(i) = Convert.ToString("簡易ガス器具の貸与") : i += 1                                 '63
            ExcelC.pCellVal(i) = Convert.ToString("受信日") : i += 1                                             '64
            ExcelC.pCellVal(i) = Convert.ToString("受信時刻") : i += 1                                           '65
            ExcelC.pCellVal(i) = Convert.ToString("出動日") : i += 1                                             '66
            ExcelC.pCellVal(i) = Convert.ToString("出動時刻") : i += 1                                           '67
            ExcelC.pCellVal(i) = Convert.ToString("到着日") : i += 1                                             '68
            ExcelC.pCellVal(i) = Convert.ToString("到着時刻") : i += 1                                           '69
            ExcelC.pCellVal(i) = Convert.ToString("処理完了日") : i += 1                                         '70

            ExcelC.pCellVal(i) = Convert.ToString("処理完了時刻") : i += 1                                       '71
            ExcelC.pCellVal(i) = Convert.ToString("連絡情況・連絡相手") : i += 1                                 '72
            ExcelC.pCellVal(i) = Convert.ToString("連絡時間") : i += 1                                           '73
            ExcelC.pCellVal(i) = Convert.ToString("処理区分") : i += 1                                           '74
        End If
        ExcelC.pCellVal(i) = Convert.ToString("FAXJA報告") : i += 1                                          '75
        ExcelC.pCellVal(i) = Convert.ToString("FAXｸﾗ報告") : i += 1                                          '76
        ExcelC.pCellVal(i) = Convert.ToString("累積報告") : i += 1                                           '77
        ExcelC.pCellVal(i) = Convert.ToString("依頼書") : i += 1                                             '78
        ExcelC.mWriteLine("")       '行をファイルに書き込む                                                                

        ''明細データ出力
        Dim iCnt As Integer
        'APサーバからの戻り値をループする
        '明細データ出力
        For iCnt = 0 To ds.Tables(0).Rows.Count - 1
            dr = ds.Tables(0).Rows(iCnt)
            '明細項目
            ExcelC.pCellStyle(1) = excel_h13px & excel_w50px
            ExcelC.pCellStyle(2) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(3) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(4) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(5) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(6) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(7) = excel_h13px & excel_w60px
            ExcelC.pCellStyle(8) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(9) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(10) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(11) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(12) = excel_h13px & excel_w60px
            ExcelC.pCellStyle(13) = excel_h13px & excel_w60px
            ExcelC.pCellStyle(14) = excel_h13px & excel_w60px
            ExcelC.pCellStyle(15) = excel_h13px & excel_w60px
            ExcelC.pCellStyle(16) = excel_h13px & excel_w30px
            ExcelC.pCellStyle(17) = excel_h13px & excel_w60px
            ExcelC.pCellStyle(18) = excel_h13px & excel_w60px

            ExcelC.pCellStyle(19) = excel_h13px & excel_w60px
            ExcelC.pCellStyle(20) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(21) = excel_h13px & excel_w30px
            ExcelC.pCellStyle(22) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(23) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(24) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(25) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(26) = excel_h13px & excel_w40px
            ExcelC.pCellStyle(27) = excel_h13px & excel_w40px
            ExcelC.pCellStyle(28) = excel_h13px & excel_w40px
            ExcelC.pCellStyle(29) = excel_h13px & excel_w70px
            ExcelC.pCellStyle(30) = excel_h13px & excel_w70px
            ExcelC.pCellStyle(31) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(32) = excel_h13px & excel_w60px
            ExcelC.pCellStyle(33) = excel_h13px & excel_w60px
            ExcelC.pCellStyle(34) = excel_h13px & excel_w60px
            ExcelC.pCellStyle(35) = excel_h13px & excel_w60px
            ExcelC.pCellStyle(36) = excel_h13px & excel_w70px

            ExcelC.pCellStyle(37) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(38) = excel_h13px & excel_w150px
            ExcelC.pCellStyle(39) = excel_h13px & excel_w70px
            ExcelC.pCellStyle(40) = excel_h13px & excel_w70px
            ExcelC.pCellStyle(41) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(42) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(43) = excel_h13px & excel_w70px
            If OUTLIST = "2" Then
                ExcelC.pCellStyle(44) = excel_h13px & excel_w100px
                ExcelC.pCellStyle(45) = excel_h13px & excel_w100px
                ExcelC.pCellStyle(46) = excel_h13px & excel_w100px
                ExcelC.pCellStyle(47) = excel_h13px & excel_w100px
                ExcelC.pCellStyle(48) = excel_h13px & excel_w100px
                ExcelC.pCellStyle(49) = excel_h13px & excel_w150px
                ExcelC.pCellStyle(50) = excel_h13px & excel_w70px
                ExcelC.pCellStyle(51) = excel_h13px & excel_w70px
                ExcelC.pCellStyle(52) = excel_h13px & excel_w70px
                ExcelC.pCellStyle(53) = excel_h13px & excel_w100px
                ExcelC.pCellStyle(54) = excel_h13px & excel_w40px

                ExcelC.pCellStyle(55) = excel_h13px & excel_w100px
                ExcelC.pCellStyle(56) = excel_h13px & excel_w40px
                ExcelC.pCellStyle(57) = excel_h13px & excel_w40px
                ExcelC.pCellStyle(58) = excel_h13px & excel_w40px
                ExcelC.pCellStyle(59) = excel_h13px & excel_w40px
                ExcelC.pCellStyle(60) = excel_h13px & excel_w40px
                ExcelC.pCellStyle(61) = excel_h13px & excel_w40px
                ExcelC.pCellStyle(62) = excel_h13px & excel_w40px
                ExcelC.pCellStyle(63) = excel_h13px & excel_w40px
                ExcelC.pCellStyle(64) = excel_h13px & excel_w60px
                ExcelC.pCellStyle(65) = excel_h13px & excel_w60px
                ExcelC.pCellStyle(66) = excel_h13px & excel_w60px
                ExcelC.pCellStyle(67) = excel_h13px & excel_w60px
                ExcelC.pCellStyle(68) = excel_h13px & excel_w60px
                ExcelC.pCellStyle(69) = excel_h13px & excel_w60px
                ExcelC.pCellStyle(70) = excel_h13px & excel_w60px
                ExcelC.pCellStyle(71) = excel_h13px & excel_w60px
                ExcelC.pCellStyle(72) = excel_h13px & excel_w100px

                ExcelC.pCellStyle(73) = excel_h13px & excel_w60px
                ExcelC.pCellStyle(74) = excel_h13px & excel_w70px
                ExcelC.pCellStyle(75) = excel_h13px & excel_w35px
                ExcelC.pCellStyle(76) = excel_h13px & excel_w35px
                ExcelC.pCellStyle(77) = excel_h13px & excel_w35px
                ExcelC.pCellStyle(78) = excel_h13px & excel_w35px
                ExcelC.pCellStyle(79) = excel_h13px & excel_w10px
            ElseIf OUTLIST = "3" Then
                ExcelC.pCellStyle(44) = excel_h13px & excel_w35px
                ExcelC.pCellStyle(45) = excel_h13px & excel_w35px
                ExcelC.pCellStyle(46) = excel_h13px & excel_w35px
                ExcelC.pCellStyle(47) = excel_h13px & excel_w35px
                ExcelC.pCellStyle(48) = excel_h13px & excel_w10px
            End If
            i = 1
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KENNM")) : i += 1                  '1 県名
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KYOKYUNM")) : i += 1               '2 供給センター名
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("JACD")) : i += 1                   '3 JAコード
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("JANM")) : i += 1                   '4 JA名
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("ACBCD")) : i += 1                  '5 JA支所コード
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("ACBNM")) : i += 1                  '6 JA支所コード名
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("USER_CD")) : i += 1                '7 お客様コード
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("JUSYONM")) : i += 1                '8 お客様名
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("RENTEL")) : i += 1                 '9 連絡先
            ExcelC.pCellVal(i) = fncSetJUTEL(Convert.ToString(dr.Item("JUTEL1")), Convert.ToString(dr.Item("JUTEL2"))) : i += 1 '10 結線電話番号
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("ADDR")) : i += 1                   '11 住所
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("GAS_STOP")) : i += 1               '12 取引中止日
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("GAS_DELE")) : i += 1               '13 取引廃止日
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TIZUNO")) : i += 1                 '14 地図番号
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SHUGOU")) : i += 1                 '15 集合区分
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("NCU_SETNM2")) : i += 1             '16 NCU設置区分
            'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("USER_FLG")) : i += 1              '17 お客様状態
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("UNYO")) : i += 1                   '17 お客様状態 '2017/11/17 H.Mori mod 2017改善開発 No7-1
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("HATYMD")) : i += 1                 '18 受信日
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("HATTIME")) : i += 1                '19 受信時刻
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KENSIN")) : i += 1                 '20 メータ値
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("RYURYO")) : i += 1                 '21 流量区分
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("METASYU")) : i += 1                '22 メータ種別
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KMNM1")) : i += 1                  '23 警報1
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KMNM2")) : i += 1                  '24 警報2
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KMNM3")) : i += 1                  '25 警報3
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KMNM4")) : i += 1                  '26 警報4
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KMNM5")) : i += 1                  '27 警報5
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KMNM6")) : i += 1                  '28 警報6
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TAIOKBN_NAI")) : i += 1            '29 対応区分
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TMSKB_NAI")) : i += 1              '30 処理区分
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TKTANCD_NM")) : i += 1             '31 監視センター担当者 
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SIJIYMD")) : i += 1                '32 依頼日
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SIJITIME")) : i += 1               '33 依頼時刻
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SYOYMD")) : i += 1                 '34 対応完了日
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SYOTIME")) : i += 1                '35 対応完了時刻
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TAITNM")) : i += 1                 '36 連絡相手
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TELRNM")) : i += 1                 '37 電話連絡内容
            'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TEL_MEMO1")) & Convert.ToString(dr.Item("TEL_MEMO2")) & Convert.ToString(dr.Item("FUK_MEMO")) : i += 1 '38 監視対応内容  '2020/11/01 T.Ono mod 2020監視改善
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TEL_MEMO1")) & Convert.ToString(dr.Item("TEL_MEMO2")) & Convert.ToString(dr.Item("FUK_MEMO")) &
                                 Convert.ToString(dr.Item("TEL_MEMO4")) & Convert.ToString(dr.Item("TEL_MEMO5")) & Convert.ToString(dr.Item("TEL_MEMO6")) : i += 1
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TKIGNM")) : i += 1                 '39 原因器具
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TSADNM")) : i += 1                 '40 作動原因
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SDNM")) : i += 1                   '41 出動依頼内容
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SIJI_BIKO1")) : i += 1             '42 出動依頼備考
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SYONO")) : i += 1                  '43 処理番号(照会用)
            If OUTLIST = "2" Then
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("STD")) : i += 1                '44 出動委託先
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("STD_KYOTEN")) : i += 1         '45 支所・拠点名
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SYUTDTNM")) : i += 1           '46 出動対応者
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("AITNM")) : i += 1              '47 対応相手
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("GAS_FLG")) : i += 1            '48 ガス関連
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SDTBIK1")) : i += 1            '49 お客様のお話内容
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("FKINM")) : i += 1              '50 復帰対応
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TSADNM")) : i += 1             '51 メータ作動原因１
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TKIGNM")) : i += 1             '52 原因器具
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SDTBIK2")) & Convert.ToString(dr.Item("SNTTOKKI")) & Convert.ToString(dr.Item("SDTBIK3")) : i += 1  '53 出動結果内容／報告
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("GASMUMU")) : i += 1            '54 ガス漏れ点検
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("ORGENIN")) : i += 1            '55 (ガス漏れ)原因
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("GASGUMU")) : i += 1            '56 ガス切れ点検
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("METYOINA")) : i += 1           '57 メータ点検
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("HOSKOKAN")) : i += 1           '58 ゴムホース交換
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TYOUYOINA")) : i += 1          '59 調整器点検
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("VALYOINA")) : i += 1           '60 容器・中間バルブ
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("COYOINA")) : i += 1            '61 CO濃度
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KYUHAIUMU")) : i += 1          '62 給排気口
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KIGTAIYO")) : i += 1           '63 簡易ガス器具の貸与
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SIJIYMD")) : i += 1            '64 受信日
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SIJITIME")) : i += 1           '65 受信時刻
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SDYMD")) : i += 1              '66 出動日
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SDTIME")) : i += 1             '67 出動時刻
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TYAKYMD")) : i += 1            '68 到着日
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TYAKTIME")) : i += 1           '69 到着時刻
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SYOKANYMD")) : i += 1          '70 処理完了日
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SYOKANTIME")) : i += 1         '71 処理完了時刻
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("JAKENREN")) : i += 1           '72 連絡状況・連絡相手
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("RENTIME")) : i += 1            '73 連絡時間
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SDSKBN_NAI")) : i += 1         '74 処理区分
            End If
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("FAXKBN")) : i += 1                 '75 FAXJA報告 FAX不要 1:不要/2:必要
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("FAXKURAKBN")) : i += 1             '76 FAXｸﾗ報告 ＦＡＸ不要(ｸﾗｲｱﾝﾄ) 1:不要/2:必要
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("FAXRUISEKIKBN")) : i += 1          '77 累積報告 1:不要/2:必要 2016/02/26 H.Mori add 監視改善2015 №10
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("FAXSPOTKBN")) : i += 1             '78 依頼書
            ExcelC.pCellVal(i) = "1"
            ExcelC.mWriteLine("")           '行をファイルに書き込む
        Next

        Return ExcelC
    End Function
    '2020/09/15 T.Ono add 監視改善2020
    '******************************************************************************
    '*　概　要:EXCEL出力（OUTLIST=4：個人情報なし　かつ　日次報告と同じ(出動会社なし)）
    '*　備　考:対応ＤＢ取得
    '*         災害対応帳票からの出力
    '******************************************************************************
    Function excelOut4(ByVal OUTLIST As String, ByVal ds As DataSet, ByVal dr As DataRow, ByVal ExcelC As Common.CExcel) As Common.CExcel

        Dim i As Integer
        Dim excel_h13px As String = "height:13px;text-align:left;font-size:10px;border-style:none;"
        Dim excel_h56px As String = "height:56px;text-align:left;font-size:10px;border-style:none;"
        Dim excel_backgroundcolor As String = "background-color:lightgrey;"
        Dim excel_w10px As String = "width:10px;"
        Dim excel_w30px As String = "width:30px;"
        Dim excel_w35px As String = "width:35px;"
        Dim excel_w40px As String = "width:40px;"
        Dim excel_w50px As String = "width:50px;"
        Dim excel_w60px As String = "width:60px;"
        Dim excel_w65px As String = "width:65px;"
        Dim excel_w70px As String = "width:70px;"
        Dim excel_w100px As String = "width:100px;"
        Dim excel_w150px As String = "width:150px;"
        Dim excel_h56px_w10px As String = "height:56px;width:10px;text-align:left;font-size:10px;border-style:none;"
        'Dim maxCnt As Integer
        'If OUTLIST = "2" Then
        '    maxCnt = 78
        'ElseIf OUTLIST = "3" Then
        '    maxCnt = 47
        'End If
        Dim x As Integer
        ExcelC.pCellStyle(1) = excel_h56px & excel_w50px & excel_backgroundcolor
        ExcelC.pCellStyle(2) = excel_h56px & excel_w100px & excel_backgroundcolor
        ExcelC.pCellStyle(3) = excel_h56px & excel_w100px & excel_backgroundcolor
        ExcelC.pCellStyle(4) = excel_h56px & excel_w100px & excel_backgroundcolor
        ExcelC.pCellStyle(5) = excel_h56px & excel_w100px & excel_backgroundcolor
        ExcelC.pCellStyle(6) = excel_h56px & excel_w60px & excel_backgroundcolor
        ExcelC.pCellStyle(7) = excel_h56px & excel_w60px & excel_backgroundcolor

        ExcelC.pCellStyle(8) = excel_h56px & excel_w60px & excel_backgroundcolor
        ExcelC.pCellStyle(9) = excel_h56px & excel_w100px & excel_backgroundcolor
        ExcelC.pCellStyle(10) = excel_h56px & excel_w100px & excel_backgroundcolor
        ExcelC.pCellStyle(11) = excel_h56px & excel_w100px & excel_backgroundcolor
        ExcelC.pCellStyle(12) = excel_h56px & excel_w40px & excel_backgroundcolor
        ExcelC.pCellStyle(13) = excel_h56px & excel_w40px & excel_backgroundcolor
        ExcelC.pCellStyle(14) = excel_h56px & excel_w40px & excel_backgroundcolor
        ExcelC.pCellStyle(15) = excel_h56px & excel_w70px & excel_backgroundcolor
        ExcelC.pCellStyle(16) = excel_h56px & excel_w60px & excel_backgroundcolor
        ExcelC.pCellStyle(17) = excel_h56px & excel_w60px & excel_backgroundcolor
        ExcelC.pCellStyle(18) = excel_h56px & excel_w60px & excel_backgroundcolor
        ExcelC.pCellStyle(19) = excel_h56px & excel_w60px & excel_backgroundcolor

        ExcelC.pCellStyle(20) = excel_h56px & excel_w100px & excel_backgroundcolor
        ExcelC.pCellStyle(21) = excel_h56px & excel_w150px & excel_backgroundcolor
        ExcelC.pCellStyle(22) = excel_h56px & excel_w70px & excel_backgroundcolor
        ExcelC.pCellStyle(23) = excel_h56px & excel_w70px & excel_backgroundcolor

        i = 1
        ExcelC.pCellVal(i) = Convert.ToString("県名") : i += 1                                               '1
        ExcelC.pCellVal(i) = Convert.ToString("供給センター名") : i += 1                                     '2
        'ExcelC.pCellVal(i) = Convert.ToString("ＪＡコード") : i += 1                                         '3
        ExcelC.pCellVal(i) = Convert.ToString("ＪＡ名") : i += 1                                             '4
        'ExcelC.pCellVal(i) = Convert.ToString("ＪＡ支所コード") : i += 1                                     '5
        ExcelC.pCellVal(i) = Convert.ToString("ＪＡ支所名") : i += 1                                         '6
        'ExcelC.pCellVal(i) = Convert.ToString("お客様コード") : i += 1                                       '7
        'ExcelC.pCellVal(i) = Convert.ToString("お客様名") : i += 1                                           '8
        'ExcelC.pCellVal(i) = Convert.ToString("連絡先") : i += 1                                             '9
        'ExcelC.pCellVal(i) = Convert.ToString("結線番号") : i += 1                                           '10

        ExcelC.pCellVal(i) = Convert.ToString("住所") : i += 1                                               '11
        'ExcelC.pCellVal(i) = Convert.ToString("取引中止日") : i += 1                                         '12
        'ExcelC.pCellVal(i) = Convert.ToString("取引廃止日") : i += 1                                         '13
        'ExcelC.pCellVal(i) = Convert.ToString("地図番号") : i += 1                                           '14
        ExcelC.pCellVal(i) = Convert.ToString("集合区分") : i += 1                                           '15
        'ExcelC.pCellVal(i) = Convert.ToString("NCU設置区分") : i += 1                                        '16
        'ExcelC.pCellVal(i) = Convert.ToString("お客様状態") : i += 1                                         '17
        ExcelC.pCellVal(i) = Convert.ToString("受信日") : i += 1                                             '18
        ExcelC.pCellVal(i) = Convert.ToString("受信時刻") : i += 1                                           '19
        'ExcelC.pCellVal(i) = Convert.ToString("メータ値") : i += 1                                           '20

        'ExcelC.pCellVal(i) = Convert.ToString("流量区分") : i += 1                                           '21
        'ExcelC.pCellVal(i) = Convert.ToString("メータ種別") : i += 1                                         '22
        ExcelC.pCellVal(i) = Convert.ToString("警報１") : i += 1                                             '23
        ExcelC.pCellVal(i) = Convert.ToString("警報２") : i += 1                                             '24
        ExcelC.pCellVal(i) = Convert.ToString("警報３") : i += 1                                             '25
        ExcelC.pCellVal(i) = Convert.ToString("警報４") : i += 1                                             '26
        ExcelC.pCellVal(i) = Convert.ToString("警報５") : i += 1                                             '27
        ExcelC.pCellVal(i) = Convert.ToString("警報６") : i += 1                                             '28
        ExcelC.pCellVal(i) = Convert.ToString("対応区分") : i += 1                                           '29
        'ExcelC.pCellVal(i) = Convert.ToString("処理区分") : i += 1                                           '30

        'ExcelC.pCellVal(i) = Convert.ToString("監視ｾﾝﾀｰ担当") : i += 1                                       '31
        ExcelC.pCellVal(i) = Convert.ToString("依頼日") : i += 1                                             '32
        ExcelC.pCellVal(i) = Convert.ToString("依頼時刻") : i += 1                                           '33
        ExcelC.pCellVal(i) = Convert.ToString("対応完了日") : i += 1                                         '34
        ExcelC.pCellVal(i) = Convert.ToString("対応完了時刻") : i += 1                                       '35
        'ExcelC.pCellVal(i) = Convert.ToString("連絡相手") : i += 1                                           '36
        ExcelC.pCellVal(i) = Convert.ToString("電話連絡内容") : i += 1                                       '37
        ExcelC.pCellVal(i) = Convert.ToString("監視対応内容") : i += 1                                       '38
        ExcelC.pCellVal(i) = Convert.ToString("原因器具") : i += 1                                           '39
        ExcelC.pCellVal(i) = Convert.ToString("作動原因") : i += 1                                           '40

        'ExcelC.pCellVal(i) = Convert.ToString("出動依頼内容") : i += 1                                       '41
        'ExcelC.pCellVal(i) = Convert.ToString("出動依頼備考") : i += 1                                       '42
        'ExcelC.pCellVal(i) = Convert.ToString("処理番号(照会用)") : i += 1                                   '43
        'ExcelC.pCellVal(i) = Convert.ToString("FAXJA報告") : i += 1                                          '75
        'ExcelC.pCellVal(i) = Convert.ToString("FAXｸﾗ報告") : i += 1                                          '76
        'ExcelC.pCellVal(i) = Convert.ToString("累積報告") : i += 1                                           '77
        'ExcelC.pCellVal(i) = Convert.ToString("依頼書") : i += 1                                             '78
        ExcelC.mWriteLine("")       '行をファイルに書き込む                                                                

        ''明細データ出力
        Dim iCnt As Integer
        'APサーバからの戻り値をループする
        '明細データ出力
        For iCnt = 0 To ds.Tables(0).Rows.Count - 1
            dr = ds.Tables(0).Rows(iCnt)
            '明細項目
            ExcelC.pCellStyle(1) = excel_h13px & excel_w50px
            ExcelC.pCellStyle(2) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(3) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(4) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(5) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(6) = excel_h13px & excel_w60px
            ExcelC.pCellStyle(7) = excel_h13px & excel_w60px

            ExcelC.pCellStyle(8) = excel_h13px & excel_w60px
            ExcelC.pCellStyle(9) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(10) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(11) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(12) = excel_h13px & excel_w40px
            ExcelC.pCellStyle(13) = excel_h13px & excel_w40px
            ExcelC.pCellStyle(14) = excel_h13px & excel_w40px
            ExcelC.pCellStyle(15) = excel_h13px & excel_w70px
            ExcelC.pCellStyle(16) = excel_h13px & excel_w60px
            ExcelC.pCellStyle(17) = excel_h13px & excel_w60px
            ExcelC.pCellStyle(18) = excel_h13px & excel_w60px
            ExcelC.pCellStyle(19) = excel_h13px & excel_w60px

            ExcelC.pCellStyle(20) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(21) = excel_h13px & excel_w150px
            ExcelC.pCellStyle(22) = excel_h13px & excel_w70px
            ExcelC.pCellStyle(23) = excel_h13px & excel_w70px

            i = 1
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KENNM")) : i += 1                  '1 県名
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KYOKYUNM")) : i += 1               '2 供給センター名
            'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("JACD")) : i += 1                   '3 JAコード
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("JANM")) : i += 1                   '4 JA名
            'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("ACBCD")) : i += 1                  '5 JA支所コード
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("ACBNM")) : i += 1                  '6 JA支所コード名
            'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("USER_CD")) : i += 1                '7 お客様コード
            'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("JUSYONM")) : i += 1                '8 お客様名
            'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("RENTEL")) : i += 1                 '9 連絡先
            'ExcelC.pCellVal(i) = fncSetJUTEL(Convert.ToString(dr.Item("JUTEL1")), Convert.ToString(dr.Item("JUTEL2"))) : i += 1 '10 結線電話番号
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("ADDR")) : i += 1                   '11 住所
            'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("GAS_STOP")) : i += 1               '12 取引中止日
            'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("GAS_DELE")) : i += 1               '13 取引廃止日
            'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TIZUNO")) : i += 1                 '14 地図番号
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SHUGOU")) : i += 1                 '15 集合区分
            'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("NCU_SETNM2")) : i += 1             '16 NCU設置区分
            'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("USER_FLG")) : i += 1              '17 お客様状態
            'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("UNYO")) : i += 1                   '17 お客様状態 '2017/11/17 H.Mori mod 2017改善開発 No7-1
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("HATYMD")) : i += 1                 '18 受信日
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("HATTIME")) : i += 1                '19 受信時刻
            'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KENSIN")) : i += 1                 '20 メータ値
            'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("RYURYO")) : i += 1                 '21 流量区分
            'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("METASYU")) : i += 1                '22 メータ種別
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KMNM1")) : i += 1                  '23 警報1
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KMNM2")) : i += 1                  '24 警報2
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KMNM3")) : i += 1                  '25 警報3
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KMNM4")) : i += 1                  '26 警報4
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KMNM5")) : i += 1                  '27 警報5
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KMNM6")) : i += 1                  '28 警報6
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TAIOKBN_NAI")) : i += 1            '29 対応区分
            'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TMSKB_NAI")) : i += 1              '30 処理区分
            'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TKTANCD_NM")) : i += 1             '31 監視センター担当者 
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SIJIYMD")) : i += 1                '32 依頼日
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SIJITIME")) : i += 1               '33 依頼時刻
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SYOYMD")) : i += 1                 '34 対応完了日
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SYOTIME")) : i += 1                '35 対応完了時刻
            'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TAITNM")) : i += 1                 '36 連絡相手
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TELRNM")) : i += 1                 '37 電話連絡内容
            'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TEL_MEMO1")) & Convert.ToString(dr.Item("TEL_MEMO2")) & Convert.ToString(dr.Item("FUK_MEMO")) : i += 1 '38 監視対応内容  '2020/11/01 T.Ono mod 2020監視改善
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TEL_MEMO1")) & Convert.ToString(dr.Item("TEL_MEMO2")) & Convert.ToString(dr.Item("FUK_MEMO")) &
                                 Convert.ToString(dr.Item("TEL_MEMO4")) & Convert.ToString(dr.Item("TEL_MEMO5")) & Convert.ToString(dr.Item("TEL_MEMO6")) : i += 1
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TKIGNM")) : i += 1                 '39 原因器具
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TSADNM")) : i += 1                 '40 作動原因
            'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SDNM")) : i += 1                   '41 出動依頼内容
            'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SIJI_BIKO1")) : i += 1             '42 出動依頼備考
            'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SYONO")) : i += 1                  '43 処理番号(照会用)
            If OUTLIST = "2" Then
            End If
            'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("FAXKBN")) : i += 1                 '75 FAXJA報告 FAX不要 1:不要/2:必要
            'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("FAXKURAKBN")) : i += 1             '76 FAXｸﾗ報告 ＦＡＸ不要(ｸﾗｲｱﾝﾄ) 1:不要/2:必要
            'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("FAXRUISEKIKBN")) : i += 1          '77 累積報告 1:不要/2:必要 2016/02/26 H.Mori add 監視改善2015 №10
            'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("FAXSPOTKBN")) : i += 1             '78 依頼書
            'ExcelC.pCellVal(i) = "1"
            ExcelC.mWriteLine("")           '行をファイルに書き込む
        Next

        Return ExcelC
    End Function
    '******************************************************************************
    '*　概　要:ＳＥＬＥＣＴ文を作成
    '*　備　考:対応ＤＢ取得
    '******************************************************************************
    '2014/12/10 H.Hosoda mod 監視改善2014 №13 引数を追加
    '2019/11/01 T.Ono mod 監視改善2019 pstrJACDFrom_CLI,pstrJACDTo_CLI 追加
    '2020/01/06 T.Ono mod 災害対応帳票 psrtTSADNM 追加
    'Public Function fncMakeSelect(ByVal pstrKANSCD As String, _
    '                              ByVal pstrTFKICD As String, _
    '                              ByVal pstrStkbn1 As String, _
    '                              ByVal pstrStkbn2 As String, _
    '                              ByVal pstrPgkbn1 As String, _
    '                              ByVal pstrPgkbn2 As String, _
    '                              ByVal pstrPgkbn3 As String, _
    '                              ByVal pstrTrgFrom As String, _
    '                              ByVal pstrTrgTo As String, _
    '                              ByVal pstrKURACDFrom As String, _
    '                              ByVal pstrKURACDTo As String, _
    '                              ByVal pstrJACDFrom As String, _
    '                              ByVal pstrJACDTo As String) As String
    '2017/02/16 H.Mori mod 改善2016 No8-2 引数を追加
    'Public Function fncMakeSelect(ByVal pstrKANSCD As String, _
    '                              ByVal pstrTFKICD As String, _
    '                              ByVal pstrStkbn1 As String, _
    '                              ByVal pstrStkbn2 As String, _
    '                              ByVal pstrPgkbn1 As String, _
    '                              ByVal pstrPgkbn2 As String, _
    '                              ByVal pstrPgkbn3 As String, _
    '                              ByVal pstrTrgFrom As String, _
    '                              ByVal pstrTrgTo As String, _
    '                              ByVal pstrKURACDFrom As String, _
    '                              ByVal pstrKURACDTo As String, _
    '                              ByVal pstrJACDFrom As String, _
    '                              ByVal pstrJACDTo As String, _
    '                              ByVal pstrHANGRPFrom As String, _
    '                              ByVal pstrHANGRPTo As String, _
    '                              ByVal pstrOUTKBN As String, _
    '                              ByVal pstrKIKANKBN As String) As String
    '2017/02/17 W.GANEKO mod 監視改善2016 №7 引数を追加 START
    'Public Function fncMakeSelect(ByVal pstrKANSCD As String, _
    '                          ByVal pstrTFKICD As String, _
    '                          ByVal pstrStkbn1 As String, _
    '                          ByVal pstrStkbn2 As String, _
    '                          ByVal pstrPgkbn1 As String, _
    '                          ByVal pstrPgkbn2 As String, _
    '                          ByVal pstrPgkbn3 As String, _
    '                          ByVal pstrTrgFrom As String, _
    '                          ByVal pstrTrgTo As String, _
    '                          ByVal pstrKURACDFrom As String, _
    '                          ByVal pstrKURACDTo As String, _
    '                          ByVal pstrJACDFrom As String, _
    '                          ByVal pstrJACDTo As String, _
    '                          ByVal pstrHANGRPFrom As String, _
    '                          ByVal pstrHANGRPTo As String, _
    '                          ByVal pstrOUTKBN As String, _
    '                          ByVal pstrKIKANKBN As String, _
    '                          ByVal pstrTrgTimeFrom As String, _
    '                          ByVal pstrTrgTimeTo As String) As String
    Public Function fncMakeSelect(ByVal pstrKANSCD As String,
                                  ByVal pstrTFKICD As String,
                                  ByVal pstrStkbn1 As String,
                                  ByVal pstrStkbn2 As String,
                                  ByVal pstrPgkbn1 As String,
                                  ByVal pstrPgkbn2 As String,
                                  ByVal pstrPgkbn3 As String,
                                  ByVal pstrTrgFrom As String,
                                  ByVal pstrTrgTo As String,
                                  ByVal pstrKURACDFrom As String,
                                  ByVal pstrKURACDTo As String,
                                  ByVal pstrJACDFrom As String,
                                  ByVal pstrJACDFromCLI As String,
                                  ByVal pstrJACDTo As String,
                                  ByVal pstrJACDTo_CLI As String,
                                  ByVal pstrHANGRPFrom As String,
                                  ByVal pstrHANGRPTo As String,
                                  ByVal pstrOUTKBN As String,
                                  ByVal pstrKIKANKBN As String,
                                  ByVal pstrTrgTimeFrom As String,
                                  ByVal pstrTrgTimeTo As String,
                                  ByVal pstrHOKBN As String,
                                  ByVal pstrOUTLIST As String,
                                  ByVal pstrTFKINM As String,
                                  ByVal pstrTSADCD As String,
                                  ByVal pstrTSADNM As String) As String
        '2017/02/17 W.GANEKO mod 監視改善2016 №7 END
        Dim strSQL As New StringBuilder("")

        '2016/05/02 T.Ono mod 監視改善2015 №10修正 START
        ''2016/04/20 H.Mori mod 監視改善2015 最終架電先修正 START
        ''2016/02/01 H.Mori add 監視改善2015 最終架電先 START
        'strSQL.Append("WITH ")
        'strSQL.Append("TEL AS ( ")
        ''strSQL.Append("SELECT C.KOK_TELNO,C.EXEC_KBN,C.SEQNO ")
        ''strSQL.Append("FROM   S04_TELLOGDB C ")
        ''strSQL.Append("       ,(SELECT MAX(B.EXEC_YMD || LPAD(B.EXEC_TIME, 6, '0')) AS YMD, B.SEQNO ")
        ''strSQL.Append("       FROM D20_TAIOU A,S04_TELLOGDB B ")
        ''strSQL.Append("       WHERE A.SYONO = B.SEQNO ")
        ''strSQL.Append("       AND 1 = B.EXEC_KBN ")
        ''strSQL.Append("       GROUP BY B.SEQNO) TEL ")
        ''strSQL.Append("WHERE  C.SEQNO = TEL.SEQNO ")
        ''strSQL.Append("AND    (C.EXEC_YMD || LPAD(C.EXEC_TIME, 6, '0')) = TEL.YMD) ")
        ''2016/02/01 H.Mori add 監視改善2015 最終架電先 END
        'strSQL.Append("SELECT ")
        'strSQL.Append(" B.KOK_TELNO, ")
        'strSQL.Append(" B.SEQNO ")
        'strSQL.Append("FROM( ")
        'strSQL.Append("     SELECT ")
        'strSQL.Append("           C.SEQNO, ")
        'strSQL.Append("           MAX(C.EXEC_YMD || LPAD(C.EXEC_TIME, 6, '0')) AS YMD ")
        'strSQL.Append("     FROM  S04_TELLOGDB C ")
        'strSQL.Append("     WHERE C.EXEC_KBN = '1' ")
        'strSQL.Append("     AND   C.EXEC_YMD BETWEEN TO_CHAR(ADD_MONTHS(TO_DATE(:TRGDATE_FROM, 'YYYYMMDD'), -1), 'YYYYMMDD') ")
        'strSQL.Append("                      AND     TO_CHAR(ADD_MONTHS(TO_DATE(:TRGDATE_TO, 'YYYYMMDD'), +1), 'YYYYMMDD') ")
        'strSQL.Append("     GROUP BY ")
        'strSQL.Append("           C.SEQNO ")
        'strSQL.Append("    ) A ")
        'strSQL.Append("INNER JOIN S04_TELLOGDB B ON A.SEQNO = B.SEQNO ")
        'strSQL.Append("                          AND A.YMD = B.EXEC_YMD || LPAD(B.EXEC_TIME, 6, '0') ")
        'strSQL.Append("WHERE B.EXEC_YMD BETWEEN TO_CHAR(ADD_MONTHS(TO_DATE(:TRGDATE_FROM, 'YYYYMMDD'), -1), 'YYYYMMDD') ")
        'strSQL.Append("                 AND     TO_CHAR(ADD_MONTHS(TO_DATE(:TRGDATE_TO, 'YYYYMMDD'), +1), 'YYYYMMDD') ")
        'strSQL.Append(" ) ")
        ''2016/04/20 H.Mori mod 監視改善2015 最終架電先修正 END
        strSQL.Append("WITH ")
        strSQL.Append("TEL AS ( ")
        strSQL.Append("SELECT C.SEQNO, ")
        strSQL.Append("       C.KOK_TELNO ")
        strSQL.Append("FROM ( ")
        strSQL.Append("  SELECT ROWNUM AS NUM, ")
        strSQL.Append("         B.SEQNO, ")
        strSQL.Append("         B.KOK_TELNO ")
        strSQL.Append("  FROM ( ")
        strSQL.Append("    SELECT A.SEQNO, ")
        strSQL.Append("           A.KOK_TELNO ")
        strSQL.Append("    FROM   S04_TELLOGDB A ")
        strSQL.Append("    WHERE  A.EXEC_KBN = '1' ")
        strSQL.Append("    AND    A.EXEC_YMD BETWEEN TO_CHAR(ADD_MONTHS(TO_DATE(:TRGDATE_FROM, 'YYYYMMDD'), -1), 'YYYYMMDD') ")
        strSQL.Append("                      AND     TO_CHAR(ADD_MONTHS(TO_DATE(:TRGDATE_TO, 'YYYYMMDD'), +1), 'YYYYMMDD') ")
        strSQL.Append("    ORDER BY A.SEQNO, A.ADD_DATE, A.TIME, LPAD(A.EDANO,2,'0') ")
        strSQL.Append("    ) B ")
        strSQL.Append("  ) C ")
        strSQL.Append("WHERE NOT EXISTS ( ")
        strSQL.Append("  SELECT 'X' ")
        strSQL.Append("  FROM ( ")
        strSQL.Append("    SELECT ROWNUM AS NUM, ")
        strSQL.Append("           E.SEQNO ")
        strSQL.Append("    FROM ( ")
        strSQL.Append("      SELECT D.SEQNO ")
        strSQL.Append("      FROM   S04_TELLOGDB D ")
        strSQL.Append("      WHERE  D.EXEC_KBN = '1' ")
        strSQL.Append("      AND    D.EXEC_YMD BETWEEN TO_CHAR(ADD_MONTHS(TO_DATE(:TRGDATE_FROM, 'YYYYMMDD'), -1), 'YYYYMMDD') ")
        strSQL.Append("                        AND     TO_CHAR(ADD_MONTHS(TO_DATE(:TRGDATE_TO, 'YYYYMMDD'), +1), 'YYYYMMDD') ")
        strSQL.Append("      ORDER BY D.SEQNO, D.ADD_DATE, D.TIME, LPAD(D.EDANO,2,'0') ")
        strSQL.Append("      ) E ")
        strSQL.Append("    ) F ")
        strSQL.Append("  WHERE C.SEQNO = F.SEQNO ")
        strSQL.Append("  AND   C.NUM < F.NUM ")
        strSQL.Append("  ) ")
        strSQL.Append(") ")
        '2016/05/02 T.Ono mod 監視改善2015 №10修正 END

        strSQL.Append("SELECT ")
        'If ind = 1 Then
        '    strSQL.Append("COUNT(*) ")
        'Else
        'strSQL.Append("KANSCD, ") ' 2008/11/11 T.Watabe edit
        'strSQL.Append("SYONO, ")
        'strSQL.Append("HATYMD, ")
        'strSQL.Append("HATTIME, ")
        'strSQL.Append("JUYMD, ")
        'strSQL.Append("JUTIME, ")
        'strSQL.Append("KMCD1, ")
        'strSQL.Append("KMNM1, ")
        'strSQL.Append("KMCD2, ")
        'strSQL.Append("KMNM2, ")
        'strSQL.Append("KMCD3, ")
        'strSQL.Append("KMNM3, ")
        'strSQL.Append("KMCD4, ")
        'strSQL.Append("KMNM4, ")
        'strSQL.Append("KMCD5, ")
        'strSQL.Append("KMNM5, ")
        'strSQL.Append("KMCD6, ")
        'strSQL.Append("KMNM6, ")
        'strSQL.Append("ZSISYO, ")
        'strSQL.Append("KURACD, ")
        'strSQL.Append("KENNM, ")
        'strSQL.Append("JACD, ")
        'strSQL.Append("JANM, ")
        'strSQL.Append("ACBCD, ")
        'strSQL.Append("ACBNM, ")
        'strSQL.Append("USER_CD, ")
        'strSQL.Append("JUSYONM, ")
        'strSQL.Append("JUTEL1, ")
        'strSQL.Append("JUTEL2, ")
        'strSQL.Append("RENTEL, ")
        'strSQL.Append("KTELNO, ")
        'strSQL.Append("ADDR, ")
        'strSQL.Append("NCU_SET, ")
        'strSQL.Append("HATKBN, ")
        'strSQL.Append("HATKBN_NAI, ")
        'strSQL.Append("TAIOKBN, ")
        'strSQL.Append("TAIOKBN_NAI, ")
        'strSQL.Append("TMSKB, ")
        'strSQL.Append("TMSKB_NAI, ")
        'strSQL.Append("SYOYMD, ")
        'strSQL.Append("SYOTIME, ")
        'strSQL.Append("TELRCD, ")
        'strSQL.Append("TELRNM, ")
        'strSQL.Append("TFKICD, ")
        'strSQL.Append("TFKINM, ")
        'strSQL.Append("FUK_MEMO, ")
        'strSQL.Append("TEL_MEMO1, ")
        'strSQL.Append("TEL_MEMO2, ")
        'strSQL.Append("MITOKBN, ")
        'strSQL.Append("TKIGCD, ")
        'strSQL.Append("TKIGNM, ")
        'strSQL.Append("TSADCD, ")
        'strSQL.Append("TSADNM ")
        strSQL.Append("    DECODE(TAI.FAXKBN,     '2', '送', ' ') AS FAXKBN,     ") ' 2011/05/17 T.Watabe add
        strSQL.Append("    DECODE(TAI.FAXKURAKBN, '2', '送', ' ') AS FAXKURAKBN, ") ' 2011/05/17 T.Watabe add
        strSQL.Append("    DECODE(TAI.FAXRUISEKIKBN, '2', '送', ' ') AS FAXRUISEKIKBN, ") ' 2016/02/26 H.Mori add 2015監視改善 №10
        strSQL.Append("    TAI.NCUHATYMD, ") ' 2013/08/29 T.Ono add 監視改善2013№8
        strSQL.Append("    TAI.NCUHATTIME, ") ' 2013/08/29 T.Ono add 監視改善2013№8
        '2013/11/01 T.Ono mod 対応画面の受信日時を出力するように変更
        'strSQL.Append("    TAI.JUYMD, ")                                            ' 2008/11/11 T.Watabe edit
        'strSQL.Append("    TAI.JUTIME, ")
        strSQL.Append("    TAI.HATYMD, ")
        strSQL.Append("    TAI.HATTIME, ")
        strSQL.Append("    ROUND((TO_DATE(TAI.HATYMD || SUBSTR(TAI.HATTIME,0,4), 'YYYYMMDDHH24MISS') - TO_DATE(TAI.NCUHATYMD || TAI.NCUHATTIME, 'YYYYMMDDHH24MISS'))  * 1440) AS CHIEN, ") ' 2013/08/29 T.Ono add 監視改善2013№8
        strSQL.Append("    TAI.RYURYO, ") ' 2013/08/29 T.Ono add 監視改善2013№8
        '2015/04/09 H.Mori mod 監視改善2015 ｺｰﾄﾞなし、名称ありの場合も表示する START
        'strSQL.Append("    DECODE(RTRIM(TAI.KMCD1), NULL, NULL, TAI.KMCD1 || ':' || TAI.KMNM1) AS KMNM1, ") ' 2009/01/23 T.Watabe edit
        'strSQL.Append("    DECODE(RTRIM(TAI.KMCD2), NULL, NULL, TAI.KMCD2 || ':' || TAI.KMNM2) AS KMNM2, ")
        'strSQL.Append("    DECODE(RTRIM(TAI.KMCD3), NULL, NULL, TAI.KMCD3 || ':' || TAI.KMNM3) AS KMNM3, ")
        'strSQL.Append("    DECODE(RTRIM(TAI.KMCD4), NULL, NULL, TAI.KMCD4 || ':' || TAI.KMNM4) AS KMNM4, ")
        'strSQL.Append("    DECODE(RTRIM(TAI.KMCD5), NULL, NULL, TAI.KMCD5 || ':' || TAI.KMNM5) AS KMNM5, ")
        'strSQL.Append("    DECODE(RTRIM(TAI.KMCD6), NULL, NULL, TAI.KMCD6 || ':' || TAI.KMNM6) AS KMNM6, ")
        strSQL.Append("    CASE WHEN RTRIM(TAI.KMCD1) IS NOT NULL AND RTRIM(TAI.KMNM1) IS NOT NULL  THEN TAI.KMCD1 || ':' || TAI.KMNM1 WHEN RTRIM(TAI.KMCD1) IS NOT NULL THEN TAI.KMCD1 WHEN RTRIM(TAI.KMNM1) IS NOT NULL THEN KMNM1 ELSE NULL END KMNM1, ")
        strSQL.Append("    CASE WHEN RTRIM(TAI.KMCD2) IS NOT NULL AND RTRIM(TAI.KMNM2) IS NOT NULL  THEN TAI.KMCD2 || ':' || TAI.KMNM2 WHEN RTRIM(TAI.KMCD2) IS NOT NULL THEN TAI.KMCD2 WHEN RTRIM(TAI.KMNM2) IS NOT NULL THEN KMNM2 ELSE NULL END KMNM2, ")
        strSQL.Append("    CASE WHEN RTRIM(TAI.KMCD3) IS NOT NULL AND RTRIM(TAI.KMNM3) IS NOT NULL  THEN TAI.KMCD3 || ':' || TAI.KMNM3 WHEN RTRIM(TAI.KMCD3) IS NOT NULL THEN TAI.KMCD3 WHEN RTRIM(TAI.KMNM3) IS NOT NULL THEN KMNM3 ELSE NULL END KMNM3, ")
        strSQL.Append("    CASE WHEN RTRIM(TAI.KMCD4) IS NOT NULL AND RTRIM(TAI.KMNM4) IS NOT NULL  THEN TAI.KMCD4 || ':' || TAI.KMNM4 WHEN RTRIM(TAI.KMCD4) IS NOT NULL THEN TAI.KMCD4 WHEN RTRIM(TAI.KMNM4) IS NOT NULL THEN KMNM4 ELSE NULL END KMNM4, ")
        strSQL.Append("    CASE WHEN RTRIM(TAI.KMCD5) IS NOT NULL AND RTRIM(TAI.KMNM5) IS NOT NULL  THEN TAI.KMCD5 || ':' || TAI.KMNM5 WHEN RTRIM(TAI.KMCD5) IS NOT NULL THEN TAI.KMCD5 WHEN RTRIM(TAI.KMNM5) IS NOT NULL THEN KMNM5 ELSE NULL END KMNM5, ")
        strSQL.Append("    CASE WHEN RTRIM(TAI.KMCD6) IS NOT NULL AND RTRIM(TAI.KMNM6) IS NOT NULL  THEN TAI.KMCD6 || ':' || TAI.KMNM6 WHEN RTRIM(TAI.KMCD6) IS NOT NULL THEN TAI.KMCD6 WHEN RTRIM(TAI.KMNM6) IS NOT NULL THEN KMNM6 ELSE NULL END KMNM6, ")
        '2015/04/09 H.Mori mod 監視改善2015 ｺｰﾄﾞなし、名称ありの場合も表示する END
        strSQL.Append("    DECODE(TAI.UNYO, '0', '0:未開通', '1', '1:運用中', '2', '2:休止中', NULL) AS OYAKU_FLG, ") ' 2013/08/29 T.Ono add 監視改善2013№8
        strSQL.Append("    TAI.KENSIN, ")
        strSQL.Append("    TAI.KURACD, ")
        strSQL.Append("    TAI.KENNM, ")
        strSQL.Append("    TAI.JACD, ")     ' 2014/12/11 H.Hosoda add 監視改善2014 №13
        strSQL.Append("    TAI.JANM, ")     ' 2014/12/11 H.Hosoda add 監視改善2014 №13
        strSQL.Append("    TAI.HANJICD, ")  ' 2014/12/11 H.Hosoda add 監視改善2014 №13
        strSQL.Append("    TAI.HANJINM, ")  ' 2014/12/11 H.Hosoda add 監視改善2014 №13
        strSQL.Append("    TAI.ACBCD, ")
        strSQL.Append("    TAI.ACBNM, ")
        'strSQL.Append("    KOK.TUSIN, ") ' 2013/08/29 T.Ono add 監視改善2013№8
        strSQL.Append("    TAI.TUSIN, ") ' 2017/02/17 W.GANEKO add 監視改善2016 №7
        strSQL.Append("    DECODE(TAI.NCU_SET, '1', '双方向', '2', '端発', '3', '未結線', NULL) AS NCU_SETNM, ") ' 2013/08/29 T.Ono add 監視改善2013№8
        strSQL.Append("    TAI.USER_CD, ")
        strSQL.Append("    TAI.JUSYONM, ")
        strSQL.Append("    TAI.RENTEL, ")
        strSQL.Append("    TAI.JUTEL1, ") ' 2013/10/28 T.Ono add 監視改善2013№8
        strSQL.Append("    TAI.JUTEL2, ") ' 2013/10/28 T.Ono add 監視改善2013№8
        strSQL.Append("    TAI.ADDR, ")
        strSQL.Append("    DECODE(TRIM(TAI.HANBAI_KBN), '1', '1:メータ売', '2', '2:ボンベ売', '3', '3:両方', '4', '4:その他', TAI.HANBAI_KBN) AS HANBAI_KBN, ") ' 2015/12/10 H.Mori add 監視改善2015 №10
        '2013/12/05 T.Ono mod 監視改善2013
        'strSQL.Append("    TAI.HATKBN_NAI, ")
        'strSQL.Append("    TAI.TAIOKBN_NAI, ")
        'strSQL.Append("    TAI.TMSKB_NAI, ")
        strSQL.Append("    DECODE(RTRIM(TAI.HATKBN), NULL, NULL, TAI.HATKBN || ':' || TAI.HATKBN_NAI) AS HATKBN_NAI, ")
        strSQL.Append("    DECODE(RTRIM(TAI.TAIOKBN), NULL, NULL, TAI.TAIOKBN || ':' || TAI.TAIOKBN_NAI) AS TAIOKBN_NAI, ")
        strSQL.Append("    DECODE(RTRIM(TAI.TMSKB), NULL, NULL, TAI.TMSKB || ':' || TAI.TMSKB_NAI) AS TMSKB_NAI, ")
        strSQL.Append("    TAI.SYOYMD, ")
        strSQL.Append("    TAI.SYOTIME, ")
        'strSQL.Append("    TAITCD, ") ' 2013/10/28 T.Ono add 監視改善2013№8
        'strSQL.Append("    TAITNM, ") ' 2013/10/28 T.Ono add 監視改善2013№8
        strSQL.Append("    DECODE(RTRIM(TAI.TAITCD), NULL, NULL, TAI.TAITCD || ':' || TAI.TAITNM) AS TAITCD, ") ' 2013/10/28 T.Ono add 監視改善2013№8
        '2013/12/05 T.Ono mod 監視改善2013
        'strSQL.Append("    TAI.TELRNM, ")
        'strSQL.Append("    TAI.TFKINM, ")
        strSQL.Append("    DECODE(RTRIM(TAI.TELRCD), NULL, NULL, TAI.TELRCD || ':' || TAI.TELRNM) AS TELRNM, ")
        strSQL.Append("    DECODE(RTRIM(TAI.TFKICD), NULL, NULL, TAI.TFKICD || ':' || TAI.TFKINM) AS TFKINM, ")
        strSQL.Append("    TAI.TEL_MEMO1, ")
        strSQL.Append("    TAI.TEL_MEMO2, ")
        strSQL.Append("    TAI.FUK_MEMO, ")
        strSQL.Append("    TAI.TEL_MEMO4, ")    '2020/11/01 T.Ono add 監視改善2020
        strSQL.Append("    TAI.TEL_MEMO5, ")    '2020/11/01 T.Ono add 監視改善2020
        strSQL.Append("    TAI.TEL_MEMO6, ")    '2020/11/01 T.Ono add 監視改善2020
        strSQL.Append("    TAI.FAX_REN, ") ' 2014/12/10 H.Hosoda add 監視改善2014 №13
        strSQL.Append("    TAI.KANSHI_BIKO, ") ' 2016/2/1 H.Mori add 監視改善2015 №10
        '2013/12/05 T.Ono mod 監視改善2013
        'strSQL.Append("    TAI.TKIGNM, ")
        'strSQL.Append("    TAI.TSADNM, ")
        strSQL.Append("    DECODE(RTRIM(TAI.TKIGCD), NULL, NULL, TAI.TKIGCD || ':' || TAI.TKIGNM) AS TKIGNM, ")
        strSQL.Append("    DECODE(RTRIM(TAI.TSADCD), NULL, NULL, TAI.TSADCD || ':' || TAI.TSADNM) AS TSADNM, ")
        strSQL.Append("    TAI.SIJIYMD, ")
        strSQL.Append("    TAI.SIJITIME, ")
        strSQL.Append("    TAI.STD, ")
        strSQL.Append("    TAI.SDYMD, ")
        strSQL.Append("    TAI.SDTIME, ")
        strSQL.Append("    TAI.TYAKYMD, ")
        strSQL.Append("    TAI.TYAKTIME, ")
        strSQL.Append("    TAI.SDTBIK2, ")
        strSQL.Append("    TAI.SNTTOKKI, ")
        strSQL.Append("    TAI.SDTBIK3, ")
        '2013/12/05 T.Ono mod 監視改善2013
        'strSQL.Append("    TAI.FKINM, ")
        strSQL.Append("    DECODE(RTRIM(TAI.FKICD), NULL, NULL, TAI.FKICD || ':' || TAI.FKINM) AS FKINM, ")
        strSQL.Append("    TAI.SYOKANYMD, ")
        strSQL.Append("    TAI.SYOKANTIME, ")

        '2013/12/05 T.Ono mod 監視改善2013
        'strSQL.Append("    TAI.TKTANCD_NM, ") ' 2009/03/24 T.Watabe add [対応情報]【監視センター担当者名】
        'strSQL.Append("    TAI.TSTANNM, ")    ' 2009/03/24 T.Watabe add [出動結果]【受信者氏名】
        strSQL.Append("    DECODE(RTRIM(TAI.TKTANCD), NULL, NULL, TAI.TKTANCD || ':' || TAI.TKTANCD_NM) AS TKTANCD_NM, ")
        strSQL.Append("    DECODE(RTRIM(TAI.TSTANCD), NULL, NULL, TAI.TSTANCD || ':' || TAI.TSTANNM) AS TSTANNM, ")
        strSQL.Append("    TAI.SYUTDTNM ")    ' 2009/03/24 T.Watabe add [出動結果]【出動対応者】
        strSQL.Append("    ,TEL.KOK_TELNO ")   '2016/2/1 H.Mori add 監視改善2015 №10
        '2017/02/17 W.GANEKO 2016監視改善 №7 START
        strSQL.Append("    ,DECODE(TAI.FAXSPOTKBN, '2', '送', ' ') AS FAXSPOTKBN ") '依頼書
        strSQL.Append("    ,TAI.DAIHYO_NAME ")         '代表者氏名
        strSQL.Append("    ,TAI.HANBCD ")              '販売所コード
        strSQL.Append("    ,DECODE(TAI.HOKBN,'1','1:液石法','2','2:高圧法','3','3:液石法・高圧法','4','4:ガス事業法','5','5:適用外',TAI.HOKBN) AS HOKBN ") '適用法令区分
        strSQL.Append("    ,DECODE(TAI.KYOKTKBN,'1','1:一般','2','2:集合','3','3:簡ガス',TAI.KYOKTKBN) AS KYOKTKBN ")                                      '供給形態区分
        strSQL.Append("    ,DECODE(TAI.YOTOKBN,'1','1:家庭用','2','2:業務用','3','3:農業用','4','4:工業用','5','5:その他',TAI.YOTOKBN) AS YOTOKBN ")       '用途区分
        '2017/10/27 H.Mori mod 2017改善開発 No7-1 START
        'strSQL.Append("    ,KOK.GAS_STOP ")
        'strSQL.Append("    ,KOK.GAS_DELE ")
        strSQL.Append("    ,TAI.GAS_STOP ")            '取引中止日
        strSQL.Append("    ,TAI.GAS_DELE ")            '取引廃止日
        '2017/10/27 H.Mori mod 2017改善開発 No7-1 END
        strSQL.Append("    ,HAI.NAME AS KYOKYUNM ")    '供給センター名
        '2017/10/27 H.Mori mod 2017改善開発 No7-1 START
        'strSQL.Append("    ,DECODE(KOK.USER_FLG, '0', '0:未開通', '1', '1:運用中', '2', '2:休止中', KOK.USER_FLG) AS USER_FLG ")   
        strSQL.Append("    ,DECODE(TAI.UNYO, '0', '0:未開通', '1', '1:運用中', '2', '2:休止中', TAI.UNYO) AS UNYO ")   'お客様状態
        '2017/10/27 H.Mori mod 2017改善開発 No7-1 END
        strSQL.Append("    ,TAI.TAITNM ")              '連絡相手
        strSQL.Append("    ,TAI.SDNM ")                '出動依頼内容
        strSQL.Append("    ,DECODE(TAI.NCU_SET, '3', '3:無', TAI.NCU_SET||':有') AS NCU_SETNM2 ") 'NCU設置区分
        strSQL.Append("    ,TAI.TIZUNO ")              '地図番号
        strSQL.Append("    ,TAI.METASYU ")             'メータ種別
        strSQL.Append("    ,TAI.SIJI_BIKO1 ")          '指示依頼備考
        strSQL.Append("    ,TAI.SYONO ")               '処理番号(照会用) 
        strSQL.Append("    ,TAI.STD_KYOTEN ")          '支所・拠点名
        strSQL.Append("    ,TAI.AITNM ")               '対応相手
        strSQL.Append("    ,TAI.SDTBIK1 ")             'お客様のお話内容
        strSQL.Append("    ,TAI.FKINM ")               '復帰対応
        strSQL.Append("    ,TAI.TSADNM ")              'メータ作動原因１
        strSQL.Append("    ,TAI.TKIGNM ")              '原因器具
        strSQL.Append("    ,TAI.JAKENREN ")            '連絡状況・連絡相手
        strSQL.Append("    ,TAI.RENTIME ")             '連絡時間
        strSQL.Append("    ,TAI.SDSKBN_NAI ")          '処理区分
        strSQL.Append("    ,(CASE ")                   'ガス関連
        strSQL.Append("        WHEN TAI.METFUKKI = '1' THEN '1:メータ復帰' ")
        strSQL.Append("        WHEN TAI.HOAN = '1' THEN '1:保安' ")
        strSQL.Append("        WHEN TAI.GASGIRE = '1' THEN '1:ガス切れ' ")
        strSQL.Append("        WHEN TAI.KIGKOSYO = '1' THEN '1:器具故障' ")
        strSQL.Append("        WHEN TAI.CSNTGEN = '1' THEN '1:その他' ")
        strSQL.Append("        ELSE NULL ")
        strSQL.Append("     END) AS GAS_FLG ")
        '2017/10/27 H.Mori mod 2017改善開発 No7-1 START
        'strSQL.Append("    ,KOK.SHUGOU || DECODE(PL6.NAME,NULL,NULL,':'||PL6.NAME) AS SHUGOU ")        
        strSQL.Append("    ,TAI.SHUGOU || DECODE(PL6.NAME,NULL,NULL,':'||PL6.NAME) AS SHUGOU ")         '集合区分
        '2017/10/27 H.Mori mod 2017改善開発 No7-1 END
        strSQL.Append("    ,DECODE(TAI.GASMUMU, '0', '0:有', TAI.GASMUMU||':無') AS GASMUMU ")          'ガス漏れ点検
        strSQL.Append("    ,DECODE(TAI.ORGENIN, '1', '1:ガス器具', TAI.ORGENIN) AS ORGENIN ")           '(ガス漏れ)原因
        strSQL.Append("    ,DECODE(TAI.GASGUMU, '0', '0:有', TAI.GASGUMU||':無') AS GASGUMU ")          'ガス切れ点検
        strSQL.Append("    ,DECODE(TAI.METYOINA, '0', '0:良', TAI.METYOINA||':否') AS METYOINA ")       'メータ点検
        strSQL.Append("    ,DECODE(TAI.HOSKOKAN, '0', '0:実施', TAI.HOSKOKAN||':未実施') AS HOSKOKAN ") 'ゴムホース交換
        strSQL.Append("    ,DECODE(TAI.TYOUYOINA, '0', '0:良', TAI.TYOUYOINA||':否') AS TYOUYOINA ")    '調整器点検
        strSQL.Append("    ,DECODE(TAI.VALYOINA, '0', '0:良', TAI.VALYOINA||':否') AS VALYOINA ")       '容器・中間バルブ
        strSQL.Append("    ,DECODE(TAI.COYOINA, '0', '0:良', TAI.COYOINA||':否') AS COYOINA ")          'CO濃度
        strSQL.Append("    ,DECODE(TAI.KYUHAIUMU, '0', '0:良', TAI.KYUHAIUMU||':否') AS KYUHAIUMU ")    '給排気口
        strSQL.Append("    ,DECODE(TAI.KIGTAIYO, '1', '1:有', TAI.KIGTAIYO||':無') AS KIGTAIYO ")       '簡易ガス器具の貸与
        '2017/02/17 W.GANEKO 2016監視改善 №7 END
        ' 2023/01/11 ADD START Y.ARAKAKI 2022更改No⑥ _帳票JMコード表示追加対応
        strSQL.Append("    ,KINRENCD ")       'JMコード（ＪＡ担当者報告先コード）
        strSQL.Append("    ,JMNAME ")         'JM和名（ＪＡ担当者報告先名）
        ' 2023/01/11 ADD END   Y.ARAKAKI 2022更改No⑥ _帳票JMコード表示追加対応
        strSQL.Append("FROM ")
        strSQL.Append("    D20_TAIOU TAI")
        '2013/10/30 監視改善2013№8
        strSQL.Append("    LEFT JOIN SHAMAS KOK ON TAI.KURACD = KOK.CLI_CD  ")
        strSQL.Append("                         AND TAI.ACBCD = KOK.HAN_CD ")
        strSQL.Append("                         AND TAI.USER_CD = KOK.USER_CD ")
        '2017/02/17 監視改善2016№7 W.GANEKO
        strSQL.Append("    LEFT JOIN HN2MAS HN2 ON TAI.KURACD = HN2.CLI_CD  ")
        strSQL.Append("                         AND TAI.ACBCD = HN2.HAN_CD ")
        strSQL.Append("    LEFT JOIN HAIMAS HAI ON SUBSTR(HN2.CLI_CD,2,2) = HAI.KEN_CD  ")
        strSQL.Append("                         AND HN2.HAISO_CD = HAI.HAISO_CD ")
        '2017/10/27 H.Mori mod 2017改善開発 No7-1 START
        'strSQL.Append("    LEFT JOIN M06_PULLDOWN PL6 ON PL6.KBN = '03' AND PL6.CD = KOK.SHUGOU ")
        strSQL.Append("    LEFT JOIN M06_PULLDOWN PL6 ON PL6.KBN = '03' AND PL6.CD = TAI.SHUGOU ")
        '2017/10/27 H.Mori mod 2017改善開発 No7-1 END
        'End If
        strSQL.Append("    LEFT JOIN TEL ON TAI.SYONO = TEL.SEQNO  ") '2016/2/1 H.Mori add 監視改善2015 №10

        'WHERE
        strSQL.Append("WHERE ")
        strSQL.Append(" 1 = 1 ") ' 2008/11/27 T.Watabe add

        ' 画面からの条件指定
        '監視センター
        If pstrKANSCD <> "" Then ' 2008/11/27 T.Watabe add 監視コードの必須を外す
            strSQL.Append(" AND TAI.KANSCD = :KANSCD ")
        End If
        'クライアントＣＤ
        'strSQL.Append(" AND KURACD BETWEEN :KURACD_FROM AND :KURACD_TO ") ' 2008/11/27 T.Watabe edit
        If pstrKURACDFrom <> "" Then
            strSQL.Append(" AND TAI.KURACD >= :KURACD_FROM ")
        End If
        If pstrKURACDTo <> "" Then
            strSQL.Append(" AND TAI.KURACD <= :KURACD_TO ")
        End If

        'ＪＡＣＤ ' 2008/11/11 T.Watabe edit
        If pstrJACDFrom <> "" Then
            '2019/11/01 T.Ono add 監視改善2019
            'strSQL.Append(" AND TAI.JACD >= :JACD_FROM ")
            strSQL.Append(" AND TAI.KURACD || TAI.JACD >= :JACD_FROM_CLI || :JACD_FROM ")
        End If
        If pstrJACDTo <> "" Then
            '2019/11/01 T.Ono add 監視改善2019
            'strSQL.Append(" AND TAI.JACD <= :JACD_TO ")
            strSQL.Append(" AND TAI.KURACD || TAI.JACD <= :JACD_TO_CLI || :JACD_TO ")
        End If

        '販売事業者グループコード  2014/12/12 H.Hosoda add 監視改善2014 №13
        If pstrHANGRPFrom <> "" Then
            '2019/11/01 T.Ono mod 監視改善2019 START
            'strSQL.Append(" AND TAI.HANJICD >= :HANGRP_FROM ")
            If pstrKURACDFrom <> "" Then
                strSQL.Append(" AND TAI.KURACD || TAI.HANJICD >= :KURACD_FROM || :HANGRP_FROM ")
            Else
                strSQL.Append(" AND TAI.HANJICD >= :HANGRP_FROM ")
            End If
            '2019/11/01 T.Ono mod 監視改善2019 END
        End If
        If pstrHANGRPTo <> "" Then
            '2019/11/01 T.Ono mod 監視改善2019 START
            'strSQL.Append(" AND TAI.HANJICD <= :HANGRP_TO ")
            If pstrKURACDTo <> "" Then
                strSQL.Append(" AND TAI.KURACD || TAI.HANJICD <= :KURACD_TO || :HANGRP_TO ")
            Else
                strSQL.Append(" AND TAI.HANJICD <= :HANGRP_TO ")
            End If
            '2019/11/01 T.Ono mod 監視改善2019 END
        End If

        '2017/02/16 H.Mori mod 改善2016 No7-1 対象時間追加 START
        '2014/12/11 H.Hosoda mod 監視改善2014 №13 START
        '発生日
        'strSQL.Append(" AND TAI.HATYMD BETWEEN :TRGDATE_FROM AND :TRGDATE_TO ")
        '対象期間
        'If pstrKIKANKBN = "1" Then '対応完了日
        '    strSQL.Append(" AND TAI.SYOYMD BETWEEN :TRGDATE_FROM AND :TRGDATE_TO ")
        'Else                       '受信日
        '    strSQL.Append(" AND TAI.HATYMD BETWEEN :TRGDATE_FROM AND :TRGDATE_TO ")
        'End If
        '2014/12/11 H.Hosoda mod 監視改善2014 №13 END
        If pstrKIKANKBN = "1" Then '対応完了日
            If pstrTrgTimeFrom.Length = 0 AndAlso pstrTrgTimeTo.Length = 0 Then
                strSQL.Append(" AND TAI.SYOYMD BETWEEN :TRGDATE_FROM AND :TRGDATE_TO ")
            ElseIf pstrTrgTimeFrom.Length > 0 AndAlso pstrTrgTimeTo.Length > 0 Then
                strSQL.Append(" AND TAI.SYOYMD || TAI.SYOTIME BETWEEN :TRGDATE_FROM || :TRGTIME_FROM AND :TRGDATE_TO || :TRGTIME_TO ")
            End If
        Else                       '受信日
            If pstrTrgTimeFrom.Length = 0 AndAlso pstrTrgTimeTo.Length = 0 Then
                strSQL.Append(" AND TAI.HATYMD BETWEEN :TRGDATE_FROM AND :TRGDATE_TO ")
            ElseIf pstrTrgTimeFrom.Length > 0 AndAlso pstrTrgTimeTo.Length > 0 Then
                strSQL.Append(" AND TAI.HATYMD || TAI.HATTIME BETWEEN :TRGDATE_FROM || :TRGTIME_FROM AND :TRGDATE_TO || :TRGTIME_TO ")
            End If
        End If
        '2017/02/16 H.Mori mod 改善2016 No7-1 対象時間追加 END

        '発生区分
        If pstrStkbn1.Length = 0 And pstrStkbn2.Length = 0 Then
            '条件なし
        Else
            '条件あり
            If pstrStkbn1.Length <> 0 And pstrStkbn2.Length <> 0 Then
                strSQL.Append(" AND (TAI.HATKBN = :HATKBN1 OR TAI.HATKBN = :HATKBN2) ")
            ElseIf pstrStkbn1.Length <> 0 And pstrStkbn2.Length = 0 Then
                strSQL.Append(" AND TAI.HATKBN = :HATKBN1 ")
            ElseIf pstrStkbn1.Length = 0 And pstrStkbn2.Length <> 0 Then
                strSQL.Append(" AND TAI.HATKBN = :HATKBN2 ")
            Else
            End If
        End If

        '対応区分
        If pstrPgkbn1.Length = 0 And pstrPgkbn2.Length = 0 And pstrPgkbn3.Length = 0 Then
            '条件なし
        Else
            '条件あり
            '全部入力
            If pstrPgkbn1.Length <> 0 And pstrPgkbn2.Length <> 0 And pstrPgkbn3.Length <> 0 Then
                strSQL.Append(" AND (TAI.TAIOKBN = :TAIOKBN1 OR TAI.TAIOKBN = :TAIOKBN2 OR TAI.TAIOKBN = :TAIOKBN3) ")

                '一つ入力
            ElseIf pstrPgkbn1.Length <> 0 And pstrPgkbn2.Length = 0 And pstrPgkbn3.Length = 0 Then
                strSQL.Append(" AND TAI.TAIOKBN = :TAIOKBN1 ")
            ElseIf pstrPgkbn1.Length = 0 And pstrPgkbn2.Length <> 0 And pstrPgkbn3.Length = 0 Then
                strSQL.Append(" AND TAI.TAIOKBN = :TAIOKBN2 ")
            ElseIf pstrPgkbn1.Length = 0 And pstrPgkbn2.Length = 0 And pstrPgkbn3.Length <> 0 Then
                strSQL.Append(" AND TAI.TAIOKBN = :TAIOKBN3 ")

                '二つ入力
            ElseIf pstrPgkbn1.Length <> 0 And pstrPgkbn2.Length <> 0 And pstrPgkbn3.Length = 0 Then
                strSQL.Append(" AND (TAI.TAIOKBN = :TAIOKBN1 OR TAI.TAIOKBN = :TAIOKBN2) ")
            ElseIf pstrPgkbn1.Length <> 0 And pstrPgkbn2.Length = 0 And pstrPgkbn3.Length <> 0 Then
                strSQL.Append(" AND (TAI.TAIOKBN = :TAIOKBN1 OR TAI.TAIOKBN = :TAIOKBN3) ")
            ElseIf pstrPgkbn1.Length = 0 And pstrPgkbn2.Length <> 0 And pstrPgkbn3.Length <> 0 Then
                strSQL.Append(" AND (TAI.TAIOKBN = :TAIOKBN2 OR TAI.TAIOKBN = :TAIOKBN3) ")
            Else
            End If
        End If
        '2017/02/17 W.GANEKO ADD 2016監視改善 №7 START
        '法令区分
        If pstrHOKBN = "1" Then '総合計
            '何も指定しない
        ElseIf pstrHOKBN = "2" Then '液石
            strSQL.Append(" AND ( ")
            strSQL.Append("    TAI.HOKBN IN ('1','3') ")
            strSQL.Append("   OR ")
            strSQL.Append("   ((TAI.HOKBN NOT IN ('1','2','3','4','5') OR TAI.HOKBN IS NULL) AND TAI.KYOKTKBN IN ('1','2')) ")
            strSQL.Append(" ) ")
        ElseIf pstrHOKBN = "3" Then 'その他
            strSQL.Append(" AND ( ")
            strSQL.Append("    TAI.HOKBN IN ('2','4','5') ")
            strSQL.Append("   OR ")
            strSQL.Append("   ((TAI.HOKBN NOT IN ('1','2','3','4','5') OR TAI.HOKBN IS NULL) AND (TAI.KYOKTKBN NOT IN ('1','2') OR TAI.KYOKTKBN IS NULL)) ")
            strSQL.Append(" ) ")
        End If
        '2017/02/17 W.GANEKO ADD 2016監視改善 №7 END
        '復帰対応状況
        If pstrTFKICD.Length <> 0 Then
            strSQL.Append(" AND TAI.TFKICD = :TFKICD ")
        End If
        '2020/01/06 T.Ono add 災害対応帳票
        If pstrTSADCD.Length <> 0 Then
            strSQL.Append(" AND TAI.TSADCD = :TSADCD ")
        End If

        '2014/12/10 H.Hosoda add 監視改善2014 №13 START
        If pstrOUTKBN = "2" Then '出力項目で月次帳票と同じを選択時
            strSQL.Append(" AND TAI.TAIOKBN <> '3' ") '対応区分：3.重複を除く
            '月次帳票の出力対象である警報コード（対応区分：2.出動指示は警報コードに関わらず出力）
            strSQL.Append(" AND (EXISTS (SELECT * FROM M06_PULLDOWN MCD WHERE MCD.NAIYO1 = TAI.KMCD1 AND MCD.KBN ='80' AND MCD.NAIYO1 IS NOT NULL AND MCD.NAIYO2 IS NULL AND MCD.NAME <= '08') ")
            strSQL.Append("      OR EXISTS (SELECT * FROM M06_PULLDOWN MCD WHERE MCD.NAIYO1 = TAI.KMCD1 AND MCD.NAIYO2 LIKE TAI.KMNM1 || '%' AND MCD.KBN ='80' AND MCD.NAIYO1 IS NOT NULL AND MCD.NAIYO2 IS NOT NULL AND MCD.NAME <= '08') ")
            strSQL.Append("      OR EXISTS (SELECT * FROM M06_PULLDOWN MCD WHERE MCD.NAIYO2 LIKE TAI.KMNM1 || '%' AND MCD.KBN ='80' AND MCD.NAIYO1 IS NULL AND MCD.NAIYO2 IS NOT NULL AND MCD.NAME <= '08') ")
            '2015/04/10 T.Ono mod 2014改善開発 No13 START
            'strSQL.Append("      OR TAI.TAIOKBN = '2') ")
            strSQL.Append("      OR TAI.TAIOKBN = '2' ")
            strSQL.Append("      OR TAI.HATKBN = '1') ") '発生区分=電話は全て表示
            '2015/04/10 T.Ono mod 2014改善開発 No13 End
            '月次帳票の出力対象である作動原因（対応区分：2.出動指示は作動原因に関わらず出力）
            strSQL.Append(" AND ((TAI.TSADCD<>'63' AND TAI.TSADCD<>'66') OR TAI.TSADCD IS NULL OR TAI.TAIOKBN = '2') ")
        End If
        '2014/12/10 H.Hosoda add 監視改善2014 №13 END

        'ORDER BY
        strSQL.Append(" ORDER BY ")
        'strSQL.Append("    KANSCD, ") ' 2008/11/20 T.Watabe edit
        'strSQL.Append("    KURACD, ")
        'strSQL.Append("    HATKBN, ")
        'strSQL.Append("    TAIOKBN, ")
        'strSQL.Append("    TFKICD ")
        strSQL.Append("    KURACD, ") 'クライアント
        strSQL.Append("    ACBCD, ") 'ＪＡ支所
        '2013/11/01 T.Ono mod 対応画面の受信日時を出力するように変更
        'strSQL.Append("    JUYMD, ") '対応受信日
        'strSQL.Append("    JUTIME ") '対応受信時刻
        strSQL.Append("    HATYMD, ") '受信日
        strSQL.Append("    HATTIME ") '受信時刻
        'mlog(strSQL.ToString & ":" & pstrHOKBN & ":" & pstrOUTLIST)
        Return strSQL.ToString

    End Function

    Function fncSetChien(ByVal str As String) As String
        ' 遅延時間を分から時：分に変換
        Dim M As Long '分
        Dim H As Long '時間
        Dim fugou As String 'マイナス
        Dim res As String


        If str = "0" Then
            res = Convert.ToString("0:00")
        Else
            fugou = CStr(Convert.ToString(str.IndexOf("-")))
            If fugou <> "-1" Then
                M = CLng(str) * -1
            Else
                M = CLng(str)
            End If

            H = CLng(M \ 60)
            M = M Mod 60

            If fugou <> "-1" Then
                res = Convert.ToString("-" & H & ":" & M.ToString.PadLeft(2, "0"c))
            Else
                res = Convert.ToString(H & ":" & M.ToString.PadLeft(2, "0"c))
            End If
        End If

        Return res
    End Function

    Function fncSetJUTEL(ByVal str1 As String, ByVal str2 As String) As String
        Dim res As String

        If str1 = "" Then 'JUTEL1が空白
            If str2 = "" Then 'JUTEL2が空白
                res = ""
            ElseIf Len(str2) < 5 Then 'JUTEL2が4文字以下（ハイフンつける必要なし）
                res = str2
            Else 'JUTEL2が5文字以上
                If str2.IndexOf("-") <> -1 Then 'JUTEL2にハイフンあり
                    res = str2
                Else 'JUTEL2にハイフンなし
                    res = str2.Substring(0, Len(str2) - 4) & "-" & str2.Substring(Len(str2) - 4)
                End If
            End If
        Else
            If str2 = "" Then
                res = str1
            ElseIf Len(str2) < 5 Then
                res = str1 & "-" & str2
            Else
                If str2.IndexOf("-") <> -1 Then
                    res = str1 & "-" & str2
                Else
                    res = str1 & "-" & str2.Substring(0, Len(str2) - 4) & "-" & str2.Substring(Len(str2) - 4)
                End If
            End If


        End If

        Return res
    End Function
    '**********************************************************
    'ログ吐き出し
    '戻り値：書き込んだファイルへのフルパス
    '**********************************************************
    Public Sub mlog(ByVal pstrString As String)
        Dim strFilnm As String = "log" & System.DateTime.Today.ToString("yyyyMMdd")
        Dim strLogPath As String = ConfigurationSettings.AppSettings("LOG_OUT_PATH")
        Dim strPath As String = strLogPath & strFilnm & ".txt"
        Dim strLogFlg As String = ConfigurationSettings.AppSettings("LOG_OUT")
        'Dim LogC As New CLog
        Dim strRecLog As String
        Dim strRec As String
        Dim bytesData As Byte()

        Dim linestring As String = ""
        'If strLogFlg = "1" Then
        '書き込みファイルへのストリーム
        Dim sw As StreamWriter
        Dim fs As New FileStream(strPath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite)

        linestring = System.DateTime.Now & "|" & pstrString + vbCrLf
        sw = New StreamWriter(fs, System.Text.Encoding.Default)

        '引数の文字列をストリームに書き込み
        sw.Write(linestring)

        'メモリフラッシュ（ファイル書き込み）
        'sw.Flush()

        'ファイルクローズ
        sw.Close()
        sw.Dispose()
        fs.Close()
        fs.Dispose()
        'End If

    End Sub
End Class
