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

Option Explicit On 
Option Strict On

Imports Common
Imports Common.DB

Imports System.Web.Services
Imports System.Text
Imports System.Text.RegularExpressions

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
    '******************************************************************************
    '　DATA0:対象データがありません
    '2014/12/10 H.Hosoda mod 監視改善2014 №13 引数を追加
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
    <WebMethod()> Public Function mExcel( _
                                        ByVal pstrSessionID As String, _
                                        ByVal pstrKANSCD As String, _
                                        ByVal pstrTFKICD As String, _
                                        ByVal pstrStkbn1 As String, _
                                        ByVal pstrStkbn2 As String, _
                                        ByVal pstrPgkbn1 As String, _
                                        ByVal pstrPgkbn2 As String, _
                                        ByVal pstrPgkbn3 As String, _
                                        ByVal pstrTrgFrom As String, _
                                        ByVal pstrTrgTo As String, _
                                        ByVal pstrKURACDFrom As String, _
                                        ByVal pstrKURACDTo As String, _
                                        ByVal pstrJACDFrom As String, _
                                        ByVal pstrJACDTo As String, _
                                        ByVal pstrHANGRPFrom As String, _
                                        ByVal pstrHANGRPTo As String, _
                                        ByVal pstrOUTKBN As String, _
                                        ByVal pstrKIKANKBN As String _
                                        ) As String

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
            '2014/12/10 H.Hosoda mod 監視改善2014 №13 引数を追加
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
            strSQL.Append(fncMakeSelect(pstrKANSCD, _
                                        pstrTFKICD, _
                                        pstrStkbn1, _
                                        pstrStkbn2, _
                                        pstrPgkbn1, _
                                        pstrPgkbn2, _
                                        pstrPgkbn3, _
                                        pstrTrgFrom, _
                                        pstrTrgTo, _
                                        pstrKURACDFrom, _
                                        pstrKURACDTo, _
                                        pstrJACDFrom, _
                                        pstrJACDTo, _
                                        pstrHANGRPFrom, _
                                        pstrHANGRPTo, _
                                        pstrOUTKBN, _
                                        pstrKIKANKBN))

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
            End If
            If pstrJACDTo <> "" Then
                cdb.pSQLParamStr("JACD_TO") = pstrJACDTo
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

            ExcelC.pTitle = "警報出力"                        'タイトル
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
            ExcelC.pCellStyle(1) = "height:13px;width:50px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(2) = "height:13px;width:50px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(3) = "height:13px;width:65px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2013/08/27 T.Ono add 監視改善2013№8
            ExcelC.pCellStyle(4) = "height:13px;width:50px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2013/08/27 T.Ono add 監視改善2013№8
            ExcelC.pCellStyle(5) = "height:13px;width:65px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(6) = "height:13px;width:50px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(7) = "height:13px;width:50px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2013/08/27 T.Ono add 監視改善2013№8
            ExcelC.pCellStyle(8) = "height:13px;width:50px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2013/08/27 T.Ono add 監視改善2013№8
            ExcelC.pCellStyle(9) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(10) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(11) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(12) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(13) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(14) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(15) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2013/08/27 T.Ono add 監視改善2013№8
            ExcelC.pCellStyle(16) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(17) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(18) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(19) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(20) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(21) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2013/08/27 T.Ono add 監視改善2013№8
            ExcelC.pCellStyle(22) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2013/08/27 T.Ono add 監視改善2013№8
            ExcelC.pCellStyle(23) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2013/08/27 T.Ono add 監視改善2013№8
            ExcelC.pCellStyle(24) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(25) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(26) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(27) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2013/08/27 T.Ono add 監視改善2013№8
            ExcelC.pCellStyle(28) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(29) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(30) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(31) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(32) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(33) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(34) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(35) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2013/10/28 T.Ono add 監視改善2013№8
            ExcelC.pCellStyle(36) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(37) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(38) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(29) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"  2013/08/27 T.Ono del 監視改善2013№8
            'ExcelC.pCellStyle(30) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"  2013/08/27 T.Ono del 監視改善2013№8
            ExcelC.pCellStyle(39) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(40) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(41) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(42) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(43) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(44) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(45) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(46) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(47) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(48) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(49) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(50) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(43) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2010/03/24 T.Watabe add dell
            'ExcelC.pCellStyle(44) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2010/03/24 T.Watabe add dell
            ExcelC.pCellStyle(51) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2010/03/24 T.Watabe add
            ExcelC.pCellStyle(52) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2011/05/17 T.Watabe add
            ExcelC.pCellStyle(53) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2011/05/17 T.Watabe add
            ' 2014/12/09 H.Hosoda mod 監視改善2014 №13 START
            'ExcelC.pCellStyle(54) = "height:13px;width:10px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2011/05/17 T.Watabe add
            ExcelC.pCellStyle(54) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ' 2014/12/09 H.Hosoda mod 監視改善2014 №13 END
            ExcelC.pCellStyle(55) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2014/12/09 H.Hosoda add 監視改善2014 №13
            ExcelC.pCellStyle(56) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2014/12/09 H.Hosoda add 監視改善2014 №13
            ExcelC.pCellStyle(57) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2014/12/09 H.Hosoda add 監視改善2014 №13
            ExcelC.pCellStyle(58) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2015/12/10 H.Mori add 監視改善2015 №10
            'ExcelC.pCellStyle(58) = "height:13px;width:10px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2014/12/09 H.Hosoda add 監視改善2014 №13
            ExcelC.pCellStyle(59) = "height:13px;width:10px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2015/12/10 H.Mori mod 監視改善2015 №10 番号を58→59
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
            If False Then
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
            End If
            i = 1
            ExcelC.pCellVal(i) = Convert.ToString("FAXJA送") : i += 1 ' 2011/05/17 T.Watabe add
            ExcelC.pCellVal(i) = Convert.ToString("FAXｸﾗ送") : i += 1 ' 2011/05/17 T.Watabe add
            ExcelC.pCellVal(i) = Convert.ToString("発生月日") : i += 1 ' 2013/08/27 T.Ono add 監視改善2013№8
            ExcelC.pCellVal(i) = Convert.ToString("発生時刻") : i += 1 ' 2013/08/27 T.Ono add 監視改善2013№8
            'ExcelC.pCellVal(i) = Convert.ToString("対応受信日") : i += 1 2013/08/27 T.Ono mod 監視改善2013№8
            'ExcelC.pCellVal(i) = Convert.ToString("対応時刻") : i += 1   2013/08/27 T.Ono mod 監視改善2013№8
            ExcelC.pCellVal(i) = Convert.ToString("受信日") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("受信時刻") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("遅延時間") : i += 1 ' 2013/08/27 T.Ono add 監視改善2013№8
            ExcelC.pCellVal(i) = Convert.ToString("流量区分") : i += 1 ' 2013/08/27 T.Ono add 監視改善2013№8
            ExcelC.pCellVal(i) = Convert.ToString("警報１") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("警報２") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("警報３") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("警報４") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("警報５") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("警報６") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("お客様FLG") : i += 1 ' 2013/08/27 T.Ono add 監視改善2013№8
            ExcelC.pCellVal(i) = Convert.ToString("指針値") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("クライアントコード") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("県名") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("ＪＡコード") : i += 1           ' 2014/12/11 H.Hosoda add 監視改善2014 №13
            ExcelC.pCellVal(i) = Convert.ToString("ＪＡ名") : i += 1               ' 2014/12/11 H.Hosoda add 監視改善2014 №13
            ExcelC.pCellVal(i) = Convert.ToString("販売事業者コード") : i += 1     ' 2014/12/11 H.Hosoda add 監視改善2014 №13
            ExcelC.pCellVal(i) = Convert.ToString("販売事業者名") : i += 1         ' 2014/12/11 H.Hosoda add 監視改善2014 №13
            ExcelC.pCellVal(i) = Convert.ToString("ＪＡ支所コード") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("ＪＡ支所名") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("NCU接続(種別)") : i += 1    ' 2013/08/27 T.Ono add 監視改善2013№8
            ExcelC.pCellVal(i) = Convert.ToString("接続区分") : i += 1 ' 2013/08/27 T.Ono add 監視改善2013№8
            ExcelC.pCellVal(i) = Convert.ToString("お客様コード") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("お客様名") : i += 1
            'ExcelC.pCellVal(i) = Convert.ToString("連絡先電話") : i += 1 ' 2014/12/09 H.Hosoda mod 監視改善2014 №13
            ExcelC.pCellVal(i) = Convert.ToString("連絡先") : i += 1
            ' 2014/12/11 H.Hosoda mod 監視改善2014 №13 START
            'ExcelC.pCellVal(i) = Convert.ToString("結線電話番号") : i += 1       ' 2013/08/27 T.Ono add 監視改善2013№8
            ExcelC.pCellVal(i) = Convert.ToString("結線番号") : i += 1
            ' 2014/12/11 H.Hosoda mod 監視改善2014 №13 END    
            ExcelC.pCellVal(i) = Convert.ToString("住所") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("販売区分") : i += 1 ' 2015/12/10 H.Mori add 監視改善2015 №10
            'ExcelC.pCellVal(i) = Convert.ToString("発生区分・内容") : i += 1  2013/08/27 T.Ono mod 監視改善2013№8
            'ExcelC.pCellVal(i) = Convert.ToString("対応区分・内容") : i += 1  2013/08/27 T.Ono mod 監視改善2013№8
            'ExcelC.pCellVal(i) = Convert.ToString("処理区分・内容") : i += 1  2013/08/27 T.Ono mod 監視改善2013№8
            ExcelC.pCellVal(i) = Convert.ToString("発生区分") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("対応区分") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("処理区分") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("監視ｾﾝﾀｰ担当者") : i += 1 ' 2010/03/24 T.Watabe add
            ExcelC.pCellVal(i) = Convert.ToString("対応完了日") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("対応完了時刻") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("連絡相手") : i += 1 '2013/10/28 T.Ono add 監視改善2013№8
            'ExcelC.pCellVal(i) = Convert.ToString("電話連絡・内容") : i += 1     2013/08/27 T.Ono mod 監視改善2013№8
            'ExcelC.pCellVal(i) = Convert.ToString("復帰対応状況・内容") : i += 1 2013/08/27 T.Ono mod 監視改善2013№8
            ExcelC.pCellVal(i) = Convert.ToString("電話連絡") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("復帰対応状況") : i += 1
            'ExcelC.pCellVal(i) = Convert.ToString("電話対応メモ１") : i += 1  2013/08/27 T.Ono mod 監視改善2013№8
            ExcelC.pCellVal(i) = Convert.ToString("監視対応内容") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("メモ欄") : i += 1         '2014/12/09 H.Hosoda add 監視改善2014 №13
            'ExcelC.pCellVal(i) = Convert.ToString("電話対応メモ２") : i += 1  2013/08/27 T.Ono del 監視改善2013№8
            'ExcelC.pCellVal(i) = Convert.ToString("電話対応メモ３") : i += 1  2013/08/27 T.Ono del 監視改善2013№8
            'ExcelC.pCellVal(i) = Convert.ToString("ガス器具・内容") : i += 1 2013/10/28 T.Ono mod 監視改善2013№8
            'ExcelC.pCellVal(i) = Convert.ToString("作動原因・内容") : i += 1 2013/10/28 T.Ono mod 監視改善2013№8
            'ExcelC.pCellVal(i) = Convert.ToString("ガス器具") : i += 1  ' 2014/12/09 H.Hosoda mod 監視改善2014 №13
            ExcelC.pCellVal(i) = Convert.ToString("原因器具") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("作動原因") : i += 1
            'ExcelC.pCellVal(i) = Convert.ToString("出動要請日") : i += 1   ' 2014/12/09 H.Hosoda mod 監視改善2014 №13
            'ExcelC.pCellVal(i) = Convert.ToString("出動要請時刻") : i += 1 ' 2014/12/09 H.Hosoda mod 監視改善2014 №13
            ExcelC.pCellVal(i) = Convert.ToString("出動依頼日") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("出動依頼時刻") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("出動会社名") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("出動受付者") : i += 1 ' 2010/03/24 T.Watabe add
            ExcelC.pCellVal(i) = Convert.ToString("出動対応者") : i += 1 ' 2010/03/24 T.Watabe add
            ExcelC.pCellVal(i) = Convert.ToString("出動日") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("出動時刻") : i += 1
            'ExcelC.pCellVal(i) = Convert.ToString("現着日") : i += 1   ' 2014/12/09 H.Hosoda mod 監視改善2014 №13
            'ExcelC.pCellVal(i) = Convert.ToString("現着時刻") : i += 1 ' 2014/12/09 H.Hosoda mod 監視改善2014 №13
            ExcelC.pCellVal(i) = Convert.ToString("到着日") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("到着時刻") : i += 1
            'ExcelC.pCellVal(i) = Convert.ToString("対応内容１") : i += 1  2013/08/27 T.Ono mod 監視改善2013№8
            ExcelC.pCellVal(i) = Convert.ToString("出動対応内容") : i += 1
            'ExcelC.pCellVal(i) = Convert.ToString("対応内容２") : i += 1  2013/08/27 T.Ono del 監視改善2013№8
            'ExcelC.pCellVal(i) = Convert.ToString("対応内容３") : i += 1  2013/08/27 T.Ono del 監視改善2013№8
            ExcelC.pCellVal(i) = Convert.ToString("復帰操作") : i += 1
            'ExcelC.pCellVal(i) = Convert.ToString("措置終了日") : i += 1   ' 2014/12/09 H.Hosoda mod 監視改善2014 №13
            'ExcelC.pCellVal(i) = Convert.ToString("措置終了時刻") : i += 1 ' 2014/12/09 H.Hosoda mod 監視改善2014 №13
            ExcelC.pCellVal(i) = Convert.ToString("処理完了日") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("処理完了時刻") : i += 1
            ExcelC.mWriteLine("")       '行をファイルに書き込む

            ''明細データ出力
            Dim iCnt As Integer
            'APサーバからの戻り値をループする
            '明細データ出力
            'For Each dr In ds.Tables(0).Rows
            For iCnt = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(iCnt)
                '明細項目
                ExcelC.pCellStyle(1) = "height:13px;width:50px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(2) = "height:13px;width:50px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(3) = "height:13px;width:65px;text-align:left;font-size:10px;border-style:none" ' 2013/08/27 T.Ono add 監視改善2013№8
                ExcelC.pCellStyle(4) = "height:13px;width:50px;text-align:left;font-size:10px;border-style:none" ' 2013/08/27 T.Ono add 監視改善2013№8
                ExcelC.pCellStyle(5) = "height:13px;width:65px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(6) = "height:13px;width:50px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(7) = "height:13px;width:50px;text-align:left;font-size:10px;border-style:none" ' 2013/08/27 T.Ono add 監視改善2013№8
                ExcelC.pCellStyle(8) = "height:13px;width:50px;text-align:left;font-size:10px;border-style:none" ' 2013/08/27 T.Ono add 監視改善2013№8
                ExcelC.pCellStyle(9) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(10) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(11) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(12) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(13) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(14) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(15) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" ' 2013/08/27 T.Ono add 監視改善2013№8
                ExcelC.pCellStyle(16) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(17) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(18) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(19) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(20) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(21) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" ' 2013/08/27 T.Ono add 監視改善2013№8
                ExcelC.pCellStyle(22) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" ' 2013/08/27 T.Ono add 監視改善2013№8
                ExcelC.pCellStyle(23) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(24) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(25) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(26) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" ' 2013/08/27 T.Ono add 監視改善2013№8
                ExcelC.pCellStyle(27) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(28) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(29) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(30) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(31) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(32) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(33) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(34) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" ' 2013/10/28 T.Ono add 監視改善2013№8
                ExcelC.pCellStyle(35) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(36) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(37) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                'ExcelC.pCellStyle(29) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"  2013/08/27 T.Ono del 監視改善2013№8
                'ExcelC.pCellStyle(30) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"  2013/08/27 T.Ono del 監視改善2013№8
                ExcelC.pCellStyle(38) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(39) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(40) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(41) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(42) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(43) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(44) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(45) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(46) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(47) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(48) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(49) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                'ExcelC.pCellStyle(43) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"  2013/08/27 T.Ono del 監視改善2013№8
                'ExcelC.pCellStyle(44) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" ' 2010/03/24 T.Watabe add  2013/08/27 T.Ono del 監視改善2013№8
                ExcelC.pCellStyle(50) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" ' 2010/03/24 T.Watabe add
                ExcelC.pCellStyle(51) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" ' 2010/03/24 T.Watabe add
                ExcelC.pCellStyle(52) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" ' 2011/05/17 T.Watabe add
                '2014/12/09 H.Hosoda add 監視改善2014 №13 START
                'ExcelC.pCellStyle(53) = "height:13px;width:10px;text-align:left;font-size:10px;border-style:none" ' 2011/05/17 T.Watabe add
                ExcelC.pCellStyle(53) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                '2014/12/09 H.Hosoda add 監視改善2014 №13 END
                ExcelC.pCellStyle(54) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" '2014/12/09 H.Hosoda add 監視改善2014 №13
                ExcelC.pCellStyle(55) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" '2014/12/09 H.Hosoda add 監視改善2014 №13
                ExcelC.pCellStyle(56) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" '2014/12/09 H.Hosoda add 監視改善2014 №13
                ExcelC.pCellStyle(57) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" '2014/12/09 H.Hosoda add 監視改善2014 №13
                ExcelC.pCellStyle(58) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" '2015/12/10 H.Mori add 監視改善2015 №10
                'ExcelC.pCellStyle(58) = "height:13px;width:10px;text-align:left;font-size:10px;border-style:none" '2014/12/09 H.Hosoda add 監視改善2014 №13
                ExcelC.pCellStyle(59) = "height:13px;width:10px;text-align:left;font-size:10px;border-style:none" '2015/12/10 H.Mori mod 監視改善2015 №10 
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
                If False Then
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
                    'ExcelC.pCellVal(1) = Convert.ToString(dr.Item("JUYMD"))
                    'ExcelC.pCellVal(2) = Convert.ToString(dr.Item("JUTIME"))
                    'ExcelC.pCellVal(3) = Convert.ToString(dr.Item("KMNM1"))
                    'ExcelC.pCellVal(4) = Convert.ToString(dr.Item("KMNM2"))
                    'ExcelC.pCellVal(5) = Convert.ToString(dr.Item("KMNM3"))
                    'ExcelC.pCellVal(6) = Convert.ToString(dr.Item("KMNM4"))
                    'ExcelC.pCellVal(7) = Convert.ToString(dr.Item("KMNM5"))
                    'ExcelC.pCellVal(8) = Convert.ToString(dr.Item("KMNM6"))
                    'ExcelC.pCellVal(9) = Convert.ToString(dr.Item("KENSIN"))
                    'ExcelC.pCellVal(10) = Convert.ToString(dr.Item("KURACD"))
                    'ExcelC.pCellVal(11) = Convert.ToString(dr.Item("KENNM"))
                    'ExcelC.pCellVal(12) = Convert.ToString(dr.Item("ACBCD"))
                    'ExcelC.pCellVal(13) = Convert.ToString(dr.Item("ACBNM"))
                    'ExcelC.pCellVal(14) = Convert.ToString(dr.Item("USER_CD"))
                    'ExcelC.pCellVal(15) = Convert.ToString(dr.Item("JUSYONM"))
                    'ExcelC.pCellVal(16) = Convert.ToString(dr.Item("RENTEL"))
                    'ExcelC.pCellVal(17) = Convert.ToString(dr.Item("ADDR"))
                    'ExcelC.pCellVal(18) = Convert.ToString(dr.Item("HATKBN_NAI"))
                    'ExcelC.pCellVal(19) = Convert.ToString(dr.Item("TAIOKBN_NAI"))
                    'ExcelC.pCellVal(20) = Convert.ToString(dr.Item("TMSKB_NAI"))
                    ''ExcelC.pCellVal(21) = Convert.ToString(dr.Item("SYOYMD")) ' 2008/11/11 T.Watabe edit
                    ''ExcelC.pCellVal(22) = Convert.ToString(dr.Item("SYOTIME"))
                    ''ExcelC.pCellVal(23) = Convert.ToString(dr.Item("TELRNM"))
                    ''ExcelC.pCellVal(24) = Convert.ToString(dr.Item("TFKINM"))
                    ''ExcelC.pCellVal(25) = Convert.ToString(dr.Item("TEL_MEMO1"))
                    ''ExcelC.pCellVal(26) = Convert.ToString(dr.Item("TEL_MEMO2"))
                    ''ExcelC.pCellVal(27) = Convert.ToString(dr.Item("FUK_MEMO"))
                    ''ExcelC.pCellVal(28) = Convert.ToString(dr.Item("TKIGNM"))
                    ''ExcelC.pCellVal(29) = Convert.ToString(dr.Item("TSADNM"))
                    ''ExcelC.pCellVal(30) = Convert.ToString(dr.Item("SIJIYMD"))
                    ''ExcelC.pCellVal(31) = Convert.ToString(dr.Item("SIJITIME"))
                    ''ExcelC.pCellVal(32) = Convert.ToString(dr.Item("STD"))
                    ''ExcelC.pCellVal(33) = Convert.ToString(dr.Item("SDYMD"))
                    ''ExcelC.pCellVal(34) = Convert.ToString(dr.Item("SDTIME"))
                    ''ExcelC.pCellVal(35) = Convert.ToString(dr.Item("TYAKYMD"))
                    ''ExcelC.pCellVal(36) = Convert.ToString(dr.Item("TYAKTIME"))
                    ''ExcelC.pCellVal(37) = Convert.ToString(dr.Item("SDTBIK2"))
                    ''ExcelC.pCellVal(38) = Convert.ToString(dr.Item("SNTTOKKI"))
                    ''ExcelC.pCellVal(39) = Convert.ToString(dr.Item("SDTBIK3"))
                    ''ExcelC.pCellVal(40) = Convert.ToString(dr.Item("FKINM"))
                    ''ExcelC.pCellVal(41) = Convert.ToString(dr.Item("SYOKANYMD"))
                    ''ExcelC.pCellVal(42) = Convert.ToString(dr.Item("SYOKANTIME"))
                    ''ExcelC.pCellVal(43) = "1"
                    'ExcelC.pCellVal(21) = Convert.ToString(dr.Item("TKTANCD_NM")) ' 2010/03/24 T.Watabe add  [対応情報]【監視センター担当者名】 
                    'ExcelC.pCellVal(22) = Convert.ToString(dr.Item("SYOYMD"))
                    'ExcelC.pCellVal(23) = Convert.ToString(dr.Item("SYOTIME"))
                    'ExcelC.pCellVal(24) = Convert.ToString(dr.Item("TELRNM"))
                    'ExcelC.pCellVal(25) = Convert.ToString(dr.Item("TFKINM"))
                    'ExcelC.pCellVal(26) = Convert.ToString(dr.Item("TEL_MEMO1"))
                    'ExcelC.pCellVal(27) = Convert.ToString(dr.Item("TEL_MEMO2"))
                    'ExcelC.pCellVal(28) = Convert.ToString(dr.Item("FUK_MEMO"))
                    'ExcelC.pCellVal(29) = Convert.ToString(dr.Item("TKIGNM"))
                    'ExcelC.pCellVal(30) = Convert.ToString(dr.Item("TSADNM"))
                    'ExcelC.pCellVal(31) = Convert.ToString(dr.Item("SIJIYMD"))
                    'ExcelC.pCellVal(32) = Convert.ToString(dr.Item("SIJITIME"))
                    'ExcelC.pCellVal(33) = Convert.ToString(dr.Item("STD"))
                    'ExcelC.pCellVal(34) = Convert.ToString(dr.Item("TSTANNM")) ' 2010/03/24 T.Watabe add [出動結果]【受信者氏名】
                    'ExcelC.pCellVal(35) = Convert.ToString(dr.Item("SYUTDTNM")) ' 2010/03/24 T.Watabe add [出動結果]【出動対応者】
                    'ExcelC.pCellVal(36) = Convert.ToString(dr.Item("SDYMD"))
                    'ExcelC.pCellVal(37) = Convert.ToString(dr.Item("SDTIME"))
                    'ExcelC.pCellVal(38) = Convert.ToString(dr.Item("TYAKYMD"))
                    'ExcelC.pCellVal(39) = Convert.ToString(dr.Item("TYAKTIME"))
                    'ExcelC.pCellVal(40) = Convert.ToString(dr.Item("SDTBIK2"))
                    'ExcelC.pCellVal(41) = Convert.ToString(dr.Item("SNTTOKKI"))
                    'ExcelC.pCellVal(42) = Convert.ToString(dr.Item("SDTBIK3"))
                    'ExcelC.pCellVal(43) = Convert.ToString(dr.Item("FKINM"))
                    'ExcelC.pCellVal(44) = Convert.ToString(dr.Item("SYOKANYMD"))
                    'ExcelC.pCellVal(45) = Convert.ToString(dr.Item("SYOKANTIME"))
                    'ExcelC.pCellVal(46) = "1"
                End If
                i = 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("FAXKBN")) : i += 1 ' FAX不要 1:不要/2:必要
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("FAXKURAKBN")) : i += 1 ' ＦＡＸ不要(ｸﾗｲｱﾝﾄ) 1:不要/2:必要
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("NCUHATYMD")) : i += 1  ' 発生月日 2013/08/29 T.Ono add 監視改善2013№8
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("NCUHATTIME")) : i += 1 ' 発生時刻 2013/08/29 T.Ono add 監視改善2013№8
                '2013/11/01 T.Ono mod 対応画面の受信日時を出力するように変更
                'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("JUYMD")) : i += 1
                'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("JUTIME")) : i += 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("HATYMD")) : i += 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("HATTIME")) : i += 1

                ExcelC.pCellVal(i) = fncSetChien(Convert.ToString(dr.Item("CHIEN"))) : i += 1  ' 遅延時間 2013/10/28 T.Ono add 監視改善2013№8

                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("RYURYO")) : i += 1 ' 流量区分 2013/08/29 T.Ono add 監視改善2013№8
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KMNM1")) : i += 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KMNM2")) : i += 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KMNM3")) : i += 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KMNM4")) : i += 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KMNM5")) : i += 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KMNM6")) : i += 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("OYAKU_FLG")) : i += 1 ' お客様FLG 2013/08/29 T.Ono add 監視改善2013№8
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KENSIN")) : i += 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KURACD")) : i += 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KENNM")) : i += 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("JACD")) : i += 1      ' 2014/12/11 H.Hosoda add 監視改善2014 №13 [利用者]【JAコード】
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("JANM")) : i += 1      ' 2014/12/11 H.Hosoda add 監視改善2014 №13 [利用者]【JA名】
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("HANJICD")) : i += 1   ' 2014/12/11 H.Hosoda add 監視改善2014 №13 [レコード情報]【販売事業者コード】
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("HANJINM")) : i += 1   ' 2014/12/11 H.Hosoda add 監視改善2014 №13 [レコード情報]【販売事業者名】
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("ACBCD")) : i += 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("ACBNM")) : i += 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TUSIN")) : i += 1   ' NSU接続（種別）  2013/08/29 T.Ono add 監視改善2013№8
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("NCU_SETNM")) : i += 1 ' 接続（双or端発） 2013/08/29 T.Ono add 監視改善2013№8
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("USER_CD")) : i += 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("JUSYONM")) : i += 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("RENTEL")) : i += 1

                ExcelC.pCellVal(i) = fncSetJUTEL(Convert.ToString(dr.Item("JUTEL1")), Convert.ToString(dr.Item("JUTEL2"))) : i += 1 ' 結線電話番号     2013/10/28 T.Ono add 監視改善2013№8

                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("ADDR")) : i += 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("HANBAI_KBN")) : i += 1 ' 2015/12/10 H.Mori add 監視改善2015 №10 [お客様情報]販売区分
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("HATKBN_NAI")) : i += 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TAIOKBN_NAI")) : i += 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TMSKB_NAI")) : i += 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TKTANCD_NM")) : i += 1 ' 2010/03/24 T.Watabe add  [対応情報]【監視センター担当者名】 
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SYOYMD")) : i += 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SYOTIME")) : i += 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TAITCD")) : i += 1 ' 連絡相手     2013/10/28 T.Ono add 監視改善2013№8
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TELRNM")) : i += 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TFKINM")) : i += 1
                ' 2013/10/28 T.Ono mod 監視改善2013№8
                'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TEL_MEMO1")) : i += 1
                'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TEL_MEMO2")) : i += 1
                'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("FUK_MEMO")) : i += 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TEL_MEMO1")) & Convert.ToString(dr.Item("TEL_MEMO2")) & Convert.ToString(dr.Item("FUK_MEMO")) : i += 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("FAX_REN")) : i += 1 ' 2014/12/10 H.Hosoda add 監視改善2014 №13 [連絡先]【FAX連絡欄】
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TKIGNM")) : i += 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TSADNM")) : i += 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SIJIYMD")) : i += 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SIJITIME")) : i += 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("STD")) : i += 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TSTANNM")) : i += 1 ' 2010/03/24 T.Watabe add [出動結果]【受信者氏名】
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SYUTDTNM")) : i += 1 ' 2010/03/24 T.Watabe add [出動結果]【出動対応者】
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SDYMD")) : i += 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SDTIME")) : i += 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TYAKYMD")) : i += 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TYAKTIME")) : i += 1
                ' 2013/10/28 T.Ono mod 監視改善2013№8
                'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SDTBIK2")) : i += 1
                'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SNTTOKKI")) : i += 1
                'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SDTBIK3")) : i += 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SDTBIK2")) & Convert.ToString(dr.Item("SNTTOKKI")) & Convert.ToString(dr.Item("SDTBIK3")) : i += 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("FKINM")) : i += 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SYOKANYMD")) : i += 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SYOKANTIME")) : i += 1
                ExcelC.pCellVal(i) = "1"
                ExcelC.mWriteLine("")           '行をファイルに書き込む
            Next

            ExcelC.mWriteLine("")                           '行をファイルに書き込む
            ExcelC.mClose()                                 'ファイルクローズ

            '圧縮先ファイルのあるフォルダ
            compressC.p_Dir = ExcelC.pDirName
            '日本語ファイル名の指定
            compressC.p_NihongoFileName = "警報出力.xls"
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

    '******************************************************************************
    '*　概　要:ＳＥＬＥＣＴ文を作成
    '*　備　考:対応ＤＢ取得
    '******************************************************************************
    '2014/12/10 H.Hosoda mod 監視改善2014 №13 引数を追加
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
    Public Function fncMakeSelect(ByVal pstrKANSCD As String, _
                                  ByVal pstrTFKICD As String, _
                                  ByVal pstrStkbn1 As String, _
                                  ByVal pstrStkbn2 As String, _
                                  ByVal pstrPgkbn1 As String, _
                                  ByVal pstrPgkbn2 As String, _
                                  ByVal pstrPgkbn3 As String, _
                                  ByVal pstrTrgFrom As String, _
                                  ByVal pstrTrgTo As String, _
                                  ByVal pstrKURACDFrom As String, _
                                  ByVal pstrKURACDTo As String, _
                                  ByVal pstrJACDFrom As String, _
                                  ByVal pstrJACDTo As String, _
                                  ByVal pstrHANGRPFrom As String, _
                                  ByVal pstrHANGRPTo As String, _
                                  ByVal pstrOUTKBN As String, _
                                  ByVal pstrKIKANKBN As String) As String

        Dim strSQL As New StringBuilder("")

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
        strSQL.Append("    TAI.NCUHATYMD, ") ' 2013/08/29 T.Ono add 監視改善2013№8
        strSQL.Append("    TAI.NCUHATTIME, ") ' 2013/08/29 T.Ono add 監視改善2013№8
        '2013/11/01 T.Ono mod 対応画面の受信日時を出力するように変更
        'strSQL.Append("    TAI.JUYMD, ")                                            ' 2008/11/11 T.Watabe edit
        'strSQL.Append("    TAI.JUTIME, ")
        strSQL.Append("    TAI.HATYMD, ")
        strSQL.Append("    TAI.HATTIME, ")
        strSQL.Append("    ROUND((TO_DATE(TAI.HATYMD || SUBSTR(TAI.HATTIME,0,4), 'YYYYMMDDHH24MISS') - TO_DATE(TAI.NCUHATYMD || TAI.NCUHATTIME, 'YYYYMMDDHH24MISS'))  * 1440) AS CHIEN, ") ' 2013/08/29 T.Ono add 監視改善2013№8
        strSQL.Append("    TAI.RYURYO, ") ' 2013/08/29 T.Ono add 監視改善2013№8
        '2015/04/09 H.Mori mod 監視改善2014 ｺｰﾄﾞなし、名称ありの場合も表示する START
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
        '2015/04/09 H.Mori mod 監視改善2014 ｺｰﾄﾞなし、名称ありの場合も表示する END
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
        strSQL.Append("    KOK.TUSIN, ") ' 2013/08/29 T.Ono add 監視改善2013№8
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
        strSQL.Append("    TAI.FAX_REN, ") ' 2014/12/10 H.Hosoda add 監視改善2014 №13
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
        strSQL.Append("FROM ")
        strSQL.Append("    D20_TAIOU TAI")
        '2013/10/30 監視改善2013№8
        strSQL.Append("    LEFT JOIN SHAMAS KOK ON TAI.KURACD = KOK.CLI_CD  ")
        strSQL.Append("                         AND TAI.ACBCD = KOK.HAN_CD ")
        strSQL.Append("                         AND TAI.USER_CD = KOK.USER_CD ")
        'End If

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
            strSQL.Append(" AND TAI.JACD >= :JACD_FROM ")
        End If
        If pstrJACDTo <> "" Then
            strSQL.Append(" AND TAI.JACD <= :JACD_TO ")
        End If

        '販売事業者グループコード  2014/12/12 H.Hosoda add 監視改善2014 №13
        If pstrHANGRPFrom <> "" Then
            strSQL.Append(" AND TAI.HANJICD >= :HANGRP_FROM ")
        End If
        If pstrHANGRPTo <> "" Then
            strSQL.Append(" AND TAI.HANJICD <= :HANGRP_TO ")
        End If

        '2014/12/11 H.Hosoda mod 監視改善2014 №13 START
        '発生日
        'strSQL.Append(" AND TAI.HATYMD BETWEEN :TRGDATE_FROM AND :TRGDATE_TO ")
        '対象期間
        If pstrKIKANKBN = "1" Then '対応完了日
            strSQL.Append(" AND TAI.SYOYMD BETWEEN :TRGDATE_FROM AND :TRGDATE_TO ")
        Else                       '受信日
            strSQL.Append(" AND TAI.HATYMD BETWEEN :TRGDATE_FROM AND :TRGDATE_TO ")
        End If
        '2014/12/11 H.Hosoda mod 監視改善2014 №13 END

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

        '復帰対応状況
        If pstrTFKICD.Length <> 0 Then
            strSQL.Append(" AND TAI.TFKICD = :TFKICD ")
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
        strSQL.Append("	ORDER BY ")
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
End Class
