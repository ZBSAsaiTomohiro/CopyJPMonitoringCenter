'******************************************************************************
' 災害対応帳票
' PGID: KESAIJAW00.asmx.vb
'******************************************************************************
'変更履歴
' 2020/01/06 T.Ono 新規作成
' 2021/10/01 2021年度監視改善�ESakaUPD 未処理（画面では"継続対応中"）件数を出力するための期間区分を追加

Option Explicit On
Option Strict On

Imports Common
Imports Common.DB
Imports System.Text
Imports System.Configuration
Imports System.IO
Imports NPOI.SS.UserModel
Imports NPOI.HSSF.UserModel
Imports NPOI.XSSF.UserModel


<System.Web.Services.WebService(Namespace:="http://tempuri.org/KESAIJAW00/Service1")> _
Public Class KESAIJAW00
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
    <WebMethod()> Public Function mExcel(
                                        ByVal pstrSessionID As String,
                                        ByVal pstrKURACDFrom As String,
                                        ByVal pstrKURACDTo As String,
                                        ByVal pstrJACDFrom As String,
                                        ByVal pstrJACDFrom_CLI As String,
                                        ByVal pstrJACDTo As String,
                                        ByVal pstrJACDTo_CLI As String,
                                        ByVal pstrTrgFrom As String,
                                        ByVal pstrTrgTo As String,
                                        ByVal pstrTrgTimeFrom As String,
                                        ByVal pstrTrgTimeTo As String,
                                        ByVal pstrPgkbn1 As String,
                                        ByVal pstrPgkbn2 As String,
                                        ByVal pstrPgkbn3 As String,
                                        ByVal pstrTSADCD As String,
                                        ByVal pstrTSADNM As String,     '2021年度監視改善�EsakaUPD 2021/10/01
                                        ByVal pstrKIKANKBN As String    '←2021年度監視改善�EsakaADD期間区分を追加（元の対応完了日と受信日（未処理出力となる））
                                        ) As String

        Dim strSQL As New StringBuilder("")
        Dim cdb As New CDB
        Dim ds As New DataSet
        Dim dr As DataRow
        Dim strRec As String = ""

        Dim book As IWorkbook = New XSSFWorkbook()
        Dim ExcelC As New CExcel                        'Excelクラス20220225
        Dim sheet1 As ISheet
        Dim wfs As FileStream
        Dim rows As IRow
        Dim style1 As ICellStyle 'ヘッダ用
        Dim style2 As ICellStyle '明細用
        Dim style3 As ICellStyle '明細用(クライアント 左右上線有)
        Dim style4 As ICellStyle '明細用(クライアント 左右線有)
        Dim style5 As FontColor '明細用(クライアント 下線有)  '20220225

        Dim strFileName As String = "KESAIJAW00.xlsx"
        Dim strFilePath As String = ConfigurationSettings.AppSettings("EXCELPATH") & "\00\KESAIJAW00\"
        Dim strSheetName As String = "sheet1"

        '明細データ出力
        Dim iCnt As Integer = 0
        Dim iRow As Integer = 0

        Dim DateFncC As New CDateFnc                    '日付変換クラス
        Dim CTimeFncC As New CTimeFnc                   '時間変換クラス
        Dim strHedInfo1 As String                        'ヘッダー情報（抽出条件）
        Dim strHedInfo2 As String                        'ヘッダー情報（抽出条件）
        Dim strHedInfo3 As String                        'ヘッダー情報（注意文言）20220225
        Dim strHedInfoHasei As String                   'ヘッダー情報（抽出条件）

        Dim strKURACD_OLD As String = ""


        '接続OPEN----------------------------------------
        Try
            cdb.mOpen()
        Catch ex As Exception
            Return ex.ToString
        Finally

        End Try

        '帳票出力項目の取得用SQL文セット-------------------
        Try
            '帳票1種類のまま If pstrKIKANKBN = "1" Then                                     '2021年度監視改善�EsakaUPDﾘｱﾙﾀｲﾑの未処理出力(受信日のラジオを増やし、受信日の場合は感震器遮断用未処理も出力)2021/10/01
            '帳票出力項目の取得用SQL文セット
            strSQL.Append(fncMakeSelect(pstrKURACDFrom,
                                        pstrKURACDTo,
                                        pstrJACDFrom,
                                        pstrJACDFrom_CLI,
                                        pstrJACDTo,
                                        pstrJACDTo_CLI,
                                        pstrTrgFrom,
                                        pstrTrgTo,
                                        pstrTrgTimeFrom,
                                        pstrTrgTimeTo,
                                        pstrPgkbn1,
                                        pstrPgkbn2,
                                        pstrPgkbn3,
                                        pstrTSADCD,
                                        pstrTSADNM,
                                        pstrKIKANKBN          '←2021/10/01
                                        ))
            'ElseIf pstrKIKANKBN = "2" Then                                  '←受信日選択時(未処理感震器出力とする)sakaADD '2021年度監視改善�E未処理感震出力'2021/10/01
            'strSQL.Append(fncMakeSelect_Misyori(pstrKURACDFrom,
            'pstrKURACDTo,
            'pstrJACDFrom,
            'pstrJACDFrom_CLI,
            'pstrJACDTo,
            'pstrJACDTo_CLI,
            'pstrTrgFrom,
            'pstrTrgTo,
            'pstrTrgTimeFrom,
            'pstrTrgTimeTo,
            'pstrPgkbn1,
            'pstrPgkbn2,
            'pstrPgkbn3,
            'pstrTSADCD,
            'pstrTSADNM
            '))
            'End If                                                           '←帳票出力の追加はここまで2021年度監視改善�E'2021/10/01

            cdb.pSQL = strSQL.ToString

            'パラメータセット
            'クライアントコード
            If pstrKURACDFrom <> "" Then
                cdb.pSQLParamStr("KURACD_FROM") = pstrKURACDFrom
            End If
            If pstrKURACDTo <> "" Then
                cdb.pSQLParamStr("KURACD_TO") = pstrKURACDTo
            End If
            'ＪＡコード 
            If pstrJACDFrom <> "" Then
                cdb.pSQLParamStr("JACD_FROM") = pstrJACDFrom
                cdb.pSQLParamStr("JACD_FROM_CLI") = pstrJACDFrom_CLI
            End If
            If pstrJACDTo <> "" Then
                cdb.pSQLParamStr("JACD_TO") = pstrJACDTo
                cdb.pSQLParamStr("JACD_TO_CLI") = pstrJACDTo_CLI
            End If

            '対応完了日
            cdb.pSQLParamStr("TRGDATE_FROM") = pstrTrgFrom
            cdb.pSQLParamStr("TRGDATE_TO") = pstrTrgTo

            '対応完了時刻
            If pstrTrgTimeFrom <> "" Then
                cdb.pSQLParamStr("TRGTIME_FROM") = pstrTrgTimeFrom
            End If
            If pstrTrgTimeTo <> "" Then
                cdb.pSQLParamStr("TRGTIME_TO") = pstrTrgTimeTo & "59"
            End If

            '対応区分
            If pstrPgkbn1.Length <> 0 And pstrPgkbn2.Length <> 0 Then
                '二つ入力
                cdb.pSQLParamStr("TAIOKBN1") = pstrPgkbn1
                cdb.pSQLParamStr("TAIOKBN2") = pstrPgkbn2

                '一つ入力
            ElseIf pstrPgkbn1.Length <> 0 And pstrPgkbn2.Length = 0 Then
                cdb.pSQLParamStr("TAIOKBN1") = pstrPgkbn1
            ElseIf pstrPgkbn1.Length = 0 And pstrPgkbn2.Length <> 0 Then
                cdb.pSQLParamStr("TAIOKBN2") = pstrPgkbn2
            Else
            End If

            '作動原因
            If pstrTSADCD.Length <> 0 Then
                cdb.pSQLParamStr("TSADCD") = pstrTSADCD
            End If

            cdb.mExecQuery()            'SQL実行
            ds = cdb.pResult            '結果をデータセットに格納
            dr = ds.Tables(0).Rows(0)   'データローにデータセットを格納

            'データが存在しない場合
            If Convert.ToString(dr.Item("KURACD")) = "XYZ" Then
                Return "DATA0"      'データが0件であることを示す文字列を返す
            End If


            book = New XSSFWorkbook()
            wfs = New FileStream(strFilePath & strFileName, FileMode.Create)

            '新規シート作成
            sheet1 = book.CreateSheet(strSheetName)  'シート作成
            strSheetName = "sheet1"

            '印刷向き
            Dim printset As XSSFPrintSetup
            printset = CType(sheet1.PrintSetup(), XSSFPrintSetup)
            'If pstrKIKANKBN = "1" Then                '←2021年度監視改善�E未処理感震器出力sakaADD2021/10/01
            printset.Landscape = True  '横             '←対応完了日で抽出する場合は横で出力（元々）
            'Else
            'printset.Landscape = False '縦            '←受信日で抽出する場合は横に短いので縦で出力(結局使わないためコメント化したため修正なし)
            'End If                                    '←ここまで、2021年度監視改善未処理感震器出力'2021/10/01

            '余白
            sheet1.SetMargin(MarginType.LeftMargin, 0.5)
            sheet1.SetMargin(MarginType.RightMargin, 0.5)

            'フッター
            Dim footer As XSSFOddFooter
            footer = CType(sheet1.Footer, XSSFOddFooter)
            footer.Center = HSSFFooter.Page() & " / " & HSSFFooter.NumPages()

            '印刷タイトル
            sheet1.RepeatingRows = New NPOI.SS.Util.CellRangeAddress(4, 5, -1, -1)

            'セルの結合
            sheet1.AddMergedRegion(New NPOI.SS.Util.CellRangeAddress(4, 5, 1, 1))
            sheet1.AddMergedRegion(New NPOI.SS.Util.CellRangeAddress(4, 5, 2, 2))
            '帳票一種類のままと決まったためコメント化 If pstrKIKANKBN = "1" Then         '←2021年度監視改善�E未処理感震器出力2021/10/01
            'sheet1.AddMergedRegion(New NPOI.SS.Util.CellRangeAddress(4, 5, 9, 9))
            'Else
            sheet1.AddMergedRegion(New NPOI.SS.Util.CellRangeAddress(4, 5, 11, 11))      '←2021年度監視改善�E未対応枠を増やしたため2列後ろへ
            'End If


            'セルの書式設定
            'ヘッダ用書式
            style1 = book.CreateCellStyle()
            style1.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin
            style1.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin
            style1.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin
            style1.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin
            style1.Alignment = HorizontalAlignment.CenterSelection '選択範囲内で中央
            'style1.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Center
            style1.ShrinkToFit = True         '2021年度監視改善2021/10/01�E未処理感震器出力ヘッダの文字サイズセル枠に合わせてもらう

            '明細用書式
            style2 = book.CreateCellStyle()
            style2.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin
            style2.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin
            style2.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin
            style2.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin
            'Dim format2 As IDataFormat = book.CreateDataFormat()  '文字列
            'style2.DataFormat = format2.GetFormat("@") '文字列 IDataFormatオブジェクトを作って、GetFormatで文字列のshort型を取得する

            '明細用書式(クライアント 左右上線有)
            style3 = book.CreateCellStyle()
            style3.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin
            style3.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin
            style3.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin
            style3.ShrinkToFit = True

            '明細用書式(クライアント 左右線有)
            style4 = book.CreateCellStyle()
            style4.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin
            style4.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin

            '明細用書式(クライアント 左右線有)                   '20220225
            'style5 = book.CreateCellStyle()                     '20220225
            ' style5.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin            '20220225
            style5 = NPOI.SS.UserModel.FontColor.Red '20220225


            'ヘッダ
            If iRow = 0 Then
                'タイトル
                rows = sheet1.CreateRow(0)
                '帳票1種類のまま If pstrKIKANKBN = "1" Then                           '2021年度監視改善�E未処理感震器出力sakaADD2021/10/01
                rows.CreateCell(0).SetCellValue("災害対応帳票")  '←対応完了日で抽出する場合は通常の災害対応帳票
                'ElseIf pstrKIKANKBN = "2" Then
                'rows.CreateCell(0).SetCellValue("災害対応帳票（未処理出力）")  '←受信日で抽出する場合は通常のﾘｱﾙﾀｲﾑ感震器遮断警報出力にする'2021/10/01
                'rows.CreateCell(0).SetCellValue(DateTime.Now.ToString)  '←感震器遮断警報の時に日時を表示させるテストで入れた、参考に残しておく'2021/10/01
                'Else
                'rows.CreateCell(0).SetCellValue("！！！エラーこの出力された帳票はNGなので使用しないでください！！！！") '2021/10/01対応完了日"1"か受信日"2"しかないはずなので
                'End If
                sheet1.SetColumnWidth(0, 256) '1文字の256分の1が単位。一文字分。


                '抽出条件１行目
                strHedInfo1 = ""
                If pstrTrgFrom.Length > 0 Then
                    If strHedInfo1.Length > 0 Then
                        strHedInfo1 = strHedInfo1 & "、"
                    End If
                    If pstrTrgTimeFrom.Length > 0 Then
                        strHedInfo1 = strHedInfo1 & "対象期間：" & DateFncC.mGet(pstrTrgFrom) & " " & CTimeFncC.mGet(pstrTrgTimeFrom, 0) & "〜" & DateFncC.mGet(pstrTrgTo) & " " & CTimeFncC.mGet(pstrTrgTimeTo, 0)
                    Else
                        strHedInfo1 = strHedInfo1 & "対象期間：" & DateFncC.mGet(pstrTrgFrom) & "〜" & DateFncC.mGet(pstrTrgTo)
                    End If
                    If pstrKIKANKBN = "1" Then                                                       '←2021年度監視改善�E未処理感震器出力sakaADD'2021/10/01
                        strHedInfo1 = strHedInfo1 & "・対応完了日"                                   '←2021年度監視改善�E元々の帳票では対応完了日
                    Else
                        strHedInfo1 = strHedInfo1 & "・受信日時（未処理データも出力）"  '←2021年度監視改善�E未処理感震器出力akaADD'2021/10/01
                    End If
                End If

                rows = sheet1.CreateRow(1)
                rows.CreateCell(1).SetCellValue(strHedInfo1)
                sheet1.SetColumnWidth(1, 256 * 30) '1文字の256分の1が単位。一文字分。


                '抽出条件２行目
                strHedInfo2 = ""
                If pstrKURACDFrom.Length > 0 Then
                    If strHedInfo2.Length > 0 Then
                        strHedInfo2 = strHedInfo2 & "、"
                    End If
                    strHedInfo2 += "クライアント：" & pstrKURACDFrom & "〜" & pstrKURACDTo
                End If
                If pstrJACDFrom.Length > 0 Or pstrJACDTo.Length > 0 Then
                    If strHedInfo2.Length > 0 Then
                        strHedInfo2 = strHedInfo2 & "、"
                    End If
                    strHedInfo2 = strHedInfo2 & "ＪＡ：" & pstrJACDFrom & "〜" & pstrJACDTo
                End If
                If pstrPgkbn1.Length > 0 Or pstrPgkbn2.Length > 0 Then
                    If strHedInfo2.Length > 0 Then
                        strHedInfo2 = strHedInfo2 & "、"
                    End If
                    strHedInfo2 = strHedInfo2 & "対応区分："
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
                    strHedInfo2 = strHedInfo2 & strHedInfoHasei
                End If

                If pstrTSADCD.Length > 0 Then
                    If strHedInfo2.Length > 0 Then
                        strHedInfo2 = strHedInfo2 & "、"
                    End If
                    strHedInfo2 = strHedInfo2 & "作動原因：" & pstrTSADNM
                End If
                strHedInfo2 = strHedInfo2 & "、帳票出力日時：" & DateTime.Now.ToString         '←2021年度監視改善�E2021/10/01帳票出力日時を出力

                rows = sheet1.CreateRow(2)
                rows.CreateCell(1).SetCellValue(strHedInfo2)

                '20220225ExcelC.pCellStyle(1) = "height:16px;font-size:11px;text-align:left;border-style:none;color:#FF0000;"
                strHedInfo3 = "※継続対応中は、連絡がつかないお客様を含む" '20220225
                rows = sheet1.CreateRow(3)                               '20220225
                sheet1.GetRow(3).GetCell(3).CellStyle.GetFont(CType(sheet1, IWorkbook))
                'rows.CreateCell(3)
                rows.CreateCell(3).SetCellValue(strHedInfo3)               '20220225


                '明細タイトル
                iRow = 4
                rows = sheet1.CreateRow(iRow)

                rows.CreateCell(1).SetCellValue("クライアント")
                sheet1.SetColumnWidth(1, 256 * 25)
                sheet1.GetRow(iRow).GetCell(1).CellStyle = style1
                '帳票1種類のまま If pstrKIKANKBN = "1" Then                                     '←2021年度監視改善�E未処理感震器出力sakaADD'2021/10/01

                'rows.CreateCell(2).SetCellValue("ＪＡ")
                'sheet1.SetColumnWidth(2, 256 * 25)
                'sheet1.GetRow(iRow).GetCell(2).CellStyle = style1

                'rows.CreateCell(3).SetCellValue("発生区分：電話")
                'sheet1.SetColumnWidth(3, 256 * 9)
                'sheet1.GetRow(iRow).GetCell(3).CellStyle = style1
                'rows.CreateCell(4)
                'sheet1.GetRow(iRow).GetCell(4).CellStyle = style1
                'rows.CreateCell(5)
                'sheet1.GetRow(iRow).GetCell(5).CellStyle = style1

                'rows.CreateCell(6).SetCellValue("発生区分：警報")
                'sheet1.SetColumnWidth(6, 256 * 9)
                'sheet1.GetRow(iRow).GetCell(6).CellStyle = style1
                'rows.CreateCell(7)
                'sheet1.GetRow(iRow).GetCell(7).CellStyle = style1
                'rows.CreateCell(8)
                'sheet1.GetRow(iRow).GetCell(8).CellStyle = style1

                'rows.CreateCell(9).SetCellValue("総計")
                'sheet1.SetColumnWidth(9, 256 * 13)
                'sheet1.GetRow(iRow).GetCell(9).CellStyle = style1

                'Else '2021年度監視改善�E未処理感震器出力時

                rows.CreateCell(2).SetCellValue("ＪＡ")
                    sheet1.SetColumnWidth(2, 256 * 23)
                    sheet1.GetRow(iRow).GetCell(2).CellStyle = style1

                    rows.CreateCell(3).SetCellValue("発生区分：電話")
                    sheet1.SetColumnWidth(3, 256 * 9)
                    sheet1.GetRow(iRow).GetCell(3).CellStyle = style1
                    rows.CreateCell(4)
                    sheet1.GetRow(iRow).GetCell(4).CellStyle = style1
                    rows.CreateCell(5)
                    sheet1.GetRow(iRow).GetCell(5).CellStyle = style1
                    rows.CreateCell(6)
                    sheet1.GetRow(iRow).GetCell(6).CellStyle = style1

                    rows.CreateCell(7).SetCellValue("発生区分：警報")
                    sheet1.SetColumnWidth(7, 256 * 9)
                    sheet1.GetRow(iRow).GetCell(7).CellStyle = style1
                    rows.CreateCell(8)
                    sheet1.GetRow(iRow).GetCell(8).CellStyle = style1
                    rows.CreateCell(9)
                    sheet1.GetRow(iRow).GetCell(9).CellStyle = style1
                    rows.CreateCell(10)
                    sheet1.GetRow(iRow).GetCell(10).CellStyle = style1

                rows.CreateCell(11).SetCellValue("総計")
                sheet1.SetColumnWidth(11, 256 * 13)
                    sheet1.GetRow(iRow).GetCell(11).CellStyle = style1
                'End If                                                    '←この条件はここまで2021年度監視改善�E未処理感震器出力sakaADD'2021/10/01
                iRow = 5
                rows = sheet1.CreateRow(iRow)
                'クライアント
                rows.CreateCell(1)
                sheet1.GetRow(iRow).GetCell(1).CellStyle = style1
                'ＪＡ
                rows.CreateCell(2)
                sheet1.GetRow(iRow).GetCell(2).CellStyle = style1

                '帳票1種類のまま If pstrKIKANKBN = "1" Then                                      '←2021年度監視改善�E未処理感震器出力sakaADD'2021/10/01

                'rows.CreateCell(3).SetCellValue("出動依頼")
                'sheet1.SetColumnWidth(3, 256 * 9)
                'sheet1.GetRow(iRow).GetCell(3).CellStyle = style1

                'rows.CreateCell(4).SetCellValue("電話対応")
                'sheet1.SetColumnWidth(4, 256 * 9)
                'sheet1.GetRow(iRow).GetCell(4).CellStyle = style1

                'rows.CreateCell(5).SetCellValue("電話発生小計")
                'sheet1.SetColumnWidth(5, 256 * 13)
                'sheet1.GetRow(iRow).GetCell(5).CellStyle = style1

                'rows.CreateCell(6).SetCellValue("出動依頼")
                'sheet1.SetColumnWidth(6, 256 * 9)
                'sheet1.GetRow(iRow).GetCell(6).CellStyle = style1

                'rows.CreateCell(7).SetCellValue("電話対応")
                'sheet1.SetColumnWidth(7, 256 * 9)
                'sheet1.GetRow(iRow).GetCell(7).CellStyle = style1

                'rows.CreateCell(8).SetCellValue("警報発生小計")
                'sheet1.SetColumnWidth(8, 256 * 13)
                'sheet1.GetRow(iRow).GetCell(8).CellStyle = style1

                ''総計
                'rows.CreateCell(9)
                'sheet1.GetRow(iRow).GetCell(9).CellStyle = style1

                'Else '未処理感震器出力時

                rows.CreateCell(3).SetCellValue("出動依頼")
                    sheet1.SetColumnWidth(3, 256 * 8)
                    sheet1.GetRow(iRow).GetCell(3).CellStyle = style1

                    rows.CreateCell(4).SetCellValue("電話対応")
                    sheet1.SetColumnWidth(4, 256 * 8)
                    sheet1.GetRow(iRow).GetCell(4).CellStyle = style1

                rows.CreateCell(5).SetCellValue("継続対応中")
                sheet1.SetColumnWidth(5, 256 * 8)
                    sheet1.GetRow(iRow).GetCell(5).CellStyle = style1

                    rows.CreateCell(6).SetCellValue("電話発生小計")
                    sheet1.SetColumnWidth(6, 256 * 10)
                    sheet1.GetRow(iRow).GetCell(6).CellStyle = style1

                    rows.CreateCell(7).SetCellValue("出動依頼")
                    sheet1.SetColumnWidth(7, 256 * 8)
                    sheet1.GetRow(iRow).GetCell(7).CellStyle = style1

                    rows.CreateCell(8).SetCellValue("電話対応")
                    sheet1.SetColumnWidth(8, 256 * 8)
                    sheet1.GetRow(iRow).GetCell(8).CellStyle = style1

                rows.CreateCell(9).SetCellValue("継続対応中")
                sheet1.SetColumnWidth(9, 256 * 8)
                    sheet1.GetRow(iRow).GetCell(9).CellStyle = style1

                    rows.CreateCell(10).SetCellValue("警報発生小計")
                    sheet1.SetColumnWidth(10, 256 * 10)
                    sheet1.GetRow(iRow).GetCell(10).CellStyle = style1

                    '総計
                    rows.CreateCell(11)
                    sheet1.GetRow(iRow).GetCell(11).CellStyle = style1
                'End If                                                        '←この条件はここまで2021年度監視改善�E未処理感震器出力sakaADD'2021/10/01
            End If

            '明細行
            iRow = 6
            For iCnt = 0 To ds.Tables(0).Rows.Count - 1

                dr = ds.Tables(0).Rows(iCnt)
                rows = sheet1.CreateRow(iRow)

                'クライアント、ＪＡ
                If Convert.ToString(dr.Item("KURACD")) = strKURACD_OLD Then
                    rows.CreateCell(1)
                    sheet1.GetRow(iRow).GetCell(1).CellStyle = style4
                    rows.CreateCell(2).SetCellValue(Convert.ToString(dr.Item("JADISP")))
                    sheet1.GetRow(iRow).GetCell(2).CellStyle = style2

                ElseIf Convert.ToString(dr.Item("KURACD")) = "XYZ" Then
                    '総合計
                    rows.CreateCell(1).SetCellValue(Convert.ToString(dr.Item("KURADISP")))
                    sheet1.GetRow(iRow).GetCell(1).CellStyle = style1
                    rows.CreateCell(2)
                    sheet1.GetRow(iRow).GetCell(2).CellStyle = style1
                Else
                    rows.CreateCell(1).SetCellValue(Convert.ToString(dr.Item("KURADISP")))
                    sheet1.GetRow(iRow).GetCell(1).CellStyle = style3
                    strKURACD_OLD = Convert.ToString(dr.Item("KURACD"))
                    rows.CreateCell(2).SetCellValue(Convert.ToString(dr.Item("JADISP")))
                    sheet1.GetRow(iRow).GetCell(2).CellStyle = style2
                End If
                ''ＪＡ
                'If Convert.ToString(dr.Item("KURACD")) = "" Then
                '    '総合計
                'Else
                '    rows.CreateCell(2).SetCellValue(Convert.ToString(dr.Item("JADISP")))
                '    sheet1.GetRow(iRow).GetCell(2).CellStyle = style2
                'End If
                '帳票1種類のまま If pstrKIKANKBN = "1" Then                                                   '←2021年度監視改善�E未処理感震器出力sakaADD'2021/10/01
                ''出動依頼
                'rows.CreateCell(3).SetCellValue(Convert.ToInt32(dr.Item("C01")))
                'sheet1.GetRow(iRow).GetCell(3).CellStyle = style2
                ''電話対応
                'rows.CreateCell(4).SetCellValue(Convert.ToInt32(dr.Item("C02")))
                'sheet1.GetRow(iRow).GetCell(4).CellStyle = style2
                ''電話発生小計
                'rows.CreateCell(5).SetCellValue(Convert.ToInt32(dr.Item("SUM1")))
                'sheet1.GetRow(iRow).GetCell(5).CellStyle = style2
                ''出動依頼
                'rows.CreateCell(6).SetCellValue(Convert.ToInt32(dr.Item("C03")))
                'sheet1.GetRow(iRow).GetCell(6).CellStyle = style2
                ''電話対応
                'rows.CreateCell(7).SetCellValue(Convert.ToInt32(dr.Item("C04")))
                'sheet1.GetRow(iRow).GetCell(7).CellStyle = style2

                ''警報発生小計
                'rows.CreateCell(8).SetCellValue(Convert.ToInt32(dr.Item("SUM2")))
                'sheet1.GetRow(iRow).GetCell(8).CellStyle = style2

                ''総計
                'rows.CreateCell(9).SetCellValue(Convert.ToInt32(dr.Item("SUMA")))
                'sheet1.GetRow(iRow).GetCell(9).CellStyle = style2

                'Else '未処理感震器出力時

                '出動依頼
                rows.CreateCell(3).SetCellValue(Convert.ToInt32(dr.Item("C01")))
                    sheet1.GetRow(iRow).GetCell(3).CellStyle = style2
                    '電話対応
                    rows.CreateCell(4).SetCellValue(Convert.ToInt32(dr.Item("C02")))
                    sheet1.GetRow(iRow).GetCell(4).CellStyle = style2
                    '電話発生未処理
                    rows.CreateCell(5).SetCellValue(Convert.ToInt32(dr.Item("C03")))
                    sheet1.GetRow(iRow).GetCell(5).CellStyle = style2
                    '電話発生小計
                    rows.CreateCell(6).SetCellValue(Convert.ToInt32(dr.Item("SUM1")))
                    sheet1.GetRow(iRow).GetCell(6).CellStyle = style2

                    '出動依頼
                    rows.CreateCell(7).SetCellValue(Convert.ToInt32(dr.Item("C04")))
                    sheet1.GetRow(iRow).GetCell(7).CellStyle = style2
                    '電話対応
                    rows.CreateCell(8).SetCellValue(Convert.ToInt32(dr.Item("C05")))
                    sheet1.GetRow(iRow).GetCell(8).CellStyle = style2
                    '警報発生未処理
                    rows.CreateCell(9).SetCellValue(Convert.ToInt32(dr.Item("C06")))
                    sheet1.GetRow(iRow).GetCell(9).CellStyle = style2

                    '警報発生小計
                    rows.CreateCell(10).SetCellValue(Convert.ToInt32(dr.Item("SUM2")))
                    sheet1.GetRow(iRow).GetCell(10).CellStyle = style2

                    '総計
                    rows.CreateCell(11).SetCellValue(Convert.ToInt32(dr.Item("SUMA")))
                    sheet1.GetRow(iRow).GetCell(11).CellStyle = style2
                'End If                                                                      '←この条件はここまで2021年度監視改善�E未処理感震器出力sakaADD'2021/10/01

                iRow += 1
            Next

            book.Write(wfs)

            wfs.Dispose()
            book.Close()

            Return strFilePath & strFileName


        Catch ex As Exception
            'エラーの内容とＳＱＬ文を返すbaba
            Return "ERROR:" & ex.ToString

        Finally
            cdb.mClose()        '接続クローズ
        End Try

    End Function
    '******************************************************************************
    '*　概　要:ＳＥＬＥＣＴ文を作成　'2021/10/01　2021年度監視改善�Eの未処理件数出力によりコメント化
    '*　備　考:対応ＤＢ取得
    '******************************************************************************
    'Public Function fncMakeSelect(ByVal pstrKURACDFrom As String,
    'ByVal pstrKURACDTo As String,
    'ByVal pstrJACDFrom As String,
    'ByVal pstrJACDFromCLI As String,
    'ByVal pstrJACDTo As String,
    'ByVal pstrJACDTo_CLI As String,
    'ByVal pstrTrgFrom As String,
    'ByVal pstrTrgTo As String,
    'ByVal pstrTrgTimeFrom As String,
    'ByVal pstrTrgTimeTo As String,
    'ByVal pstrPgkbn1 As String,
    'ByVal pstrPgkbn2 As String,
    'ByVal pstrPgkbn3 As String,
    'ByVal pstrTSADCD As String,
    'ByVal pstrTSADNM As String
    ') As String

    'Dim strSQL As New StringBuilder("")
    'Dim strWHE As New StringBuilder("")


    ''WHERE句作成
    'strWHE.Append("WHERE  1 = 1 ")

    ''クライアントＣＤ
    'If pstrKURACDFrom <> "" Then
    'strWHE.Append("AND    KURACD >= :KURACD_FROM ")
    'End If
    'If pstrKURACDTo <> "" Then
    'strWHE.Append("AND    KURACD <= :KURACD_TO ")
    'End If

    ''ＪＡＣＤ
    'If pstrJACDFrom <> "" Then
    'strWHE.Append("AND    KURACD || JACD >= :JACD_FROM_CLI || :JACD_FROM ")
    'End If
    'If pstrJACDTo <> "" Then
    'strWHE.Append("AND    KURACD || JACD <= :JACD_TO_CLI || :JACD_TO ")
    'End If

    ''対応完了日
    'If pstrTrgTimeFrom.Length = 0 AndAlso pstrTrgTimeTo.Length = 0 Then
    'strWHE.Append("AND    SYOYMD BETWEEN :TRGDATE_FROM AND :TRGDATE_TO ")
    'ElseIf pstrTrgTimeFrom.Length > 0 AndAlso pstrTrgTimeTo.Length > 0 Then
    'strWHE.Append("AND    SYOYMD || SYOTIME BETWEEN :TRGDATE_FROM || :TRGTIME_FROM AND :TRGDATE_TO || :TRGTIME_TO ")
    'End If

    ''対応区分
    'If pstrPgkbn1.Length <> 0 And pstrPgkbn2.Length <> 0 Then
    'strWHE.Append("AND    (TAIOKBN = :TAIOKBN1 OR TAIOKBN = :TAIOKBN2 ) ")

    ''一つ入力
    'ElseIf pstrPgkbn1.Length <> 0 And pstrPgkbn2.Length = 0 Then
    'strWHE.Append("AND    TAIOKBN = :TAIOKBN1 ")
    'ElseIf pstrPgkbn1.Length = 0 And pstrPgkbn2.Length <> 0 Then
    'strWHE.Append("AND    TAIOKBN = :TAIOKBN2 ")
    'Else
    'End If

    ''作動原因
    'If pstrTSADCD.Length <> 0 Then
    ' strWHE.Append(" AND TSADCD = :TSADCD ")
    'End If


    'strSQL.Append("WITH Z AS ( ")
    'strSQL.Append("SELECT KURACD ")
    'strSQL.Append("       , JACD ")
    'strSQL.Append("       , TRIM(REPLACE(JANM,'　','')) AS JANM ")
    'strSQL.Append("       , HATKBN ")
    'strSQL.Append("       , TAIOKBN ")
    'strSQL.Append("       , COUNT(*) AS CNT ")
    'strSQL.Append("FROM   D20_TAIOU ")
    'strSQL.Append(strWHE) '検索条件
    'strSQL.Append("GROUP BY KURACD, JACD, TRIM(REPLACE(JANM,'　','')), HATKBN, TAIOKBN ")
    'strSQL.Append("ORDER BY KURACD, JACD, HATKBN, TAIOKBN ")
    'strSQL.Append(") ")
    'strSQL.Append("SELECT Z.KURACD ")
    'strSQL.Append("       , Z.KURACD || ':' || C.CLI_NAME AS KURADISP ")
    'strSQL.Append("       , Z.JACD ")
    'strSQL.Append("       , Z.JACD || ':' || Z.JANM AS JADISP ")
    'strSQL.Append("       , SUM(DECODE(HATKBN || TAIOKBN,'12',CNT,0)) AS C01 ")
    'strSQL.Append("       , SUM(DECODE(HATKBN || TAIOKBN,'11',CNT,0)) AS C02 ")
    'strSQL.Append("       , SUM(DECODE(HATKBN,'1',CNT,0)) AS SUM1 ")
    'strSQL.Append("       , SUM(DECODE(HATKBN || TAIOKBN,'22',CNT,0)) AS C03 ")
    'strSQL.Append("       , SUM(DECODE(HATKBN || TAIOKBN,'21',CNT,0)) AS C04 ")
    'strSQL.Append("       , SUM(DECODE(HATKBN,'2',CNT,0)) AS SUM2 ")
    'strSQL.Append("       , SUM(CNT) AS SUMA ")
    'strSQL.Append("FROM   Z LEFT JOIN CLIMAS C ON Z.KURACD = C.CLI_CD ")
    'strSQL.Append("GROUP BY Z.KURACD ")
    'strSQL.Append("         , Z.JACD ")
    'strSQL.Append("         , Z.JANM ")
    'strSQL.Append("         , C.CLI_NAME ")
    'strSQL.Append("UNION ALL ")
    ''クライアント毎の小計
    'strSQL.Append("SELECT Z.KURACD ")
    'strSQL.Append("       , '' AS KURADISP ")
    'strSQL.Append("       , '' AS JACD ")
    'strSQL.Append("       , '小計' AS JADISP ")
    'strSQL.Append("       , SUM(DECODE(HATKBN || TAIOKBN,'12',CNT,0)) AS C01 ")
    'strSQL.Append("       , SUM(DECODE(HATKBN || TAIOKBN,'11',CNT,0)) AS C02 ")
    'strSQL.Append("       , SUM(DECODE(HATKBN,'1',CNT,0)) AS SUM1 ")
    'strSQL.Append("       , SUM(DECODE(HATKBN || TAIOKBN,'22',CNT,0)) AS C03 ")
    'strSQL.Append("       , SUM(DECODE(HATKBN || TAIOKBN,'21',CNT,0)) AS C04 ")
    'strSQL.Append("       , SUM(DECODE(HATKBN,'2',CNT,0)) AS SUM2 ")
    'strSQL.Append("       , SUM(CNT) AS SUMA ")
    'strSQL.Append("FROM   Z ")
    'strSQL.Append("GROUP BY KURACD ")
    'strSQL.Append("UNION ALL ")
    ''全体の総合計
    'strSQL.Append("SELECT 'XYZ' AS KURACD ")
    'strSQL.Append("       , '総合計' AS KURADISP ")
    'strSQL.Append("       , '' AS JACD ")
    'strSQL.Append("       , '' AS JADISP ")
    'strSQL.Append("       , SUM(DECODE(HATKBN || TAIOKBN,'12',CNT,0)) AS C01 ")
    'strSQL.Append("       , SUM(DECODE(HATKBN || TAIOKBN,'11',CNT,0)) AS C02 ")
    'strSQL.Append("       , SUM(DECODE(HATKBN,'1',CNT,0)) AS SUM1 ")
    'strSQL.Append("       , SUM(DECODE(HATKBN || TAIOKBN,'22',CNT,0)) AS C03 ")
    'strSQL.Append("       , SUM(DECODE(HATKBN || TAIOKBN,'21',CNT,0)) AS C04 ")
    'strSQL.Append("       , SUM(DECODE(HATKBN,'2',CNT,0)) AS SUM2 ")
    'strSQL.Append("       , SUM(CNT) AS SUMA ")
    'strSQL.Append("FROM   Z ")
    'strSQL.Append("ORDER BY KURACD, JACD ")

    'mlog(strSQL.ToString)

    'Return strSQL.ToString

    'End Function

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
    '******************************************************************************
    '*　概　要:未処理感震器出力用のＳＥＬＥＣＴ文を作成　2021/10/01
    '*　備　考:対応DBを参照して、処理済みと未処理を出力させる（対応完了日を選択したら未処理は0件、受信日を選択したら件数が出力される）
    '******************************************************************************
    Public Function fncMakeSelect(ByVal pstrKURACDFrom As String,
                                  ByVal pstrKURACDTo As String,
                                  ByVal pstrJACDFrom As String,
                                  ByVal pstrJACDFromCLI As String,
                                  ByVal pstrJACDTo As String,
                                  ByVal pstrJACDTo_CLI As String,
                                  ByVal pstrTrgFrom As String,
                                  ByVal pstrTrgTo As String,
                                  ByVal pstrTrgTimeFrom As String,
                                  ByVal pstrTrgTimeTo As String,
                                  ByVal pstrPgkbn1 As String,
                                  ByVal pstrPgkbn2 As String,
                                  ByVal pstrPgkbn3 As String,
                                  ByVal pstrTSADCD As String,
                                  ByVal pstrTSADNM As String,
                                  ByVal pstrKIKANKBN As String
                                  ) As String

        Dim strSQL As New StringBuilder("")
        Dim strWHE As New StringBuilder("")


        'WHERE句作成
        strWHE.Append("WHERE  1 = 1 ")

        'クライアントＣＤ
        If pstrKURACDFrom <> "" Then
            strWHE.Append("AND    KURACD >= :KURACD_FROM ")
        End If
        If pstrKURACDTo <> "" Then
            strWHE.Append("AND    KURACD <= :KURACD_TO ")
        End If

        'ＪＡＣＤ
        If pstrJACDFrom <> "" Then
            strWHE.Append("AND    KURACD || ACBCD >= :JACD_FROM_CLI || :JACD_FROM ")
        End If
        If pstrJACDTo <> "" Then
            strWHE.Append("AND    KURACD || ACBCD <= :JACD_TO_CLI || :JACD_TO ")
        End If

        '日時の検索条件
        If pstrKIKANKBN = "1" Then                   '←2021年度監視改善�E未処理感震器出力sakaADD受信日
            '対応完了日
            If pstrTrgTimeFrom.Length = 0 AndAlso pstrTrgTimeTo.Length = 0 Then
                strWHE.Append("AND    SYOYMD BETWEEN :TRGDATE_FROM AND :TRGDATE_TO ")
            ElseIf pstrTrgTimeFrom.Length > 0 AndAlso pstrTrgTimeTo.Length > 0 Then
                strWHE.Append("AND    SYOYMD || SYOTIME BETWEEN :TRGDATE_FROM || :TRGTIME_FROM AND :TRGDATE_TO || :TRGTIME_TO ")
            End If
        Else '受信日
            If pstrTrgTimeFrom.Length = 0 AndAlso pstrTrgTimeTo.Length = 0 Then
                strWHE.Append("AND    HATYMD BETWEEN :TRGDATE_FROM AND :TRGDATE_TO ")
            ElseIf pstrTrgTimeFrom.Length > 0 AndAlso pstrTrgTimeTo.Length > 0 Then
                strWHE.Append("AND    HATYMD || HATTIME BETWEEN :TRGDATE_FROM || :TRGTIME_FROM AND :TRGDATE_TO || :TRGTIME_TO ") '←2021年度監視改善�E未処理感震器出力sakaADD受信日時間(HATYMD||HATTIME)'2021/10/01
            End If
        End If                                       '←2021/10/01 2021年度監視改善�EEnd

        '対応区分
        If pstrPgkbn1.Length <> 0 And pstrPgkbn2.Length <> 0 Then
            strWHE.Append("AND    (TAIOKBN = :TAIOKBN1 OR TAIOKBN = :TAIOKBN2 ) ")

            '一つ入力
        ElseIf pstrPgkbn1.Length <> 0 And pstrPgkbn2.Length = 0 Then
            strWHE.Append("AND    TAIOKBN = :TAIOKBN1 ")
        ElseIf pstrPgkbn1.Length = 0 And pstrPgkbn2.Length <> 0 Then
            strWHE.Append("AND    TAIOKBN = :TAIOKBN2 ")
        End If

        '作動原因
        If pstrTSADCD.Length <> 0 Then
            strWHE.Append(" AND TSADCD = :TSADCD ")
        End If

        strSQL.Append("WITH Z AS ( ")
        strSQL.Append("SELECT KURACD ")
        strSQL.Append("       , JACD ")
        strSQL.Append("       , TRIM(REPLACE(JANM,'　','')) AS JANM ")
        strSQL.Append("       , HATKBN ")
        strSQL.Append("       , TAIOKBN ")
        strSQL.Append("       , TMSKB ")
        strSQL.Append("       , COUNT(*) AS CNT ")
        strSQL.Append("FROM   D20_TAIOU ")
        strSQL.Append(strWHE) '検索条件
        strSQL.Append("GROUP BY KURACD, JACD, TRIM(REPLACE(JANM,'　','')), HATKBN, TAIOKBN, TMSKB ")
        strSQL.Append("ORDER BY KURACD, JACD, HATKBN, TAIOKBN, TMSKB ")
        strSQL.Append(") ")
        strSQL.Append("SELECT Z.KURACD ")
        strSQL.Append("       , Z.KURACD || ':' || C.CLI_NAME AS KURADISP ")
        strSQL.Append("       , Z.JACD ")
        strSQL.Append("       , Z.JACD || ':' || Z.JANM AS JADISP ")
        strSQL.Append("       , SUM(DECODE(HATKBN || TAIOKBN || TMSKB,'122',CNT,0)) AS C01 ")            '←2021/10/01 2021年度監視改善�EStart
        strSQL.Append("       , SUM(DECODE(HATKBN || TAIOKBN || TMSKB,'112',CNT,0)) AS C02 ")
        strSQL.Append("       , SUM(DECODE(HATKBN || TAIOKBN || TMSKB,'111',CNT,'121',CNT,'113',CNT,'123',CNT,0)) AS C03 ")
        strSQL.Append("       , SUM(DECODE(HATKBN || TAIOKBN,'11',CNT,'12',CNT,0)) AS SUM1 ")
        strSQL.Append("       , SUM(DECODE(HATKBN || TAIOKBN || TMSKB,'222',CNT,0)) AS C04 ")
        strSQL.Append("       , SUM(DECODE(HATKBN || TAIOKBN || TMSKB,'212',CNT,0)) AS C05 ")
        strSQL.Append("       , SUM(DECODE(HATKBN || TAIOKBN || TMSKB,'211',CNT,'213',CNT,'221',CNT,'223',CNT,0)) AS C06 ")
        strSQL.Append("       , SUM(DECODE(HATKBN || TAIOKBN,'21',CNT,'22',CNT,0)) AS SUM2 ")
        strSQL.Append("       , SUM(DECODE(TAIOKBN,'1',CNT,'2',CNT,0)) AS SUMA ")                         '←2021/10/01 2021年度監視改善�EEnd
        strSQL.Append("FROM   Z LEFT JOIN CLIMAS C ON Z.KURACD = C.CLI_CD ")
        strSQL.Append("GROUP BY Z.KURACD ")
        strSQL.Append("         , Z.JACD ")
        strSQL.Append("         , Z.JANM ")
        strSQL.Append("         , C.CLI_NAME ")
        strSQL.Append("UNION ALL ")
        'クライアント毎の小計
        strSQL.Append("SELECT Z.KURACD ")
        strSQL.Append("       , '' AS KURADISP ")
        strSQL.Append("       , '' AS JACD ")
        strSQL.Append("       , '小計' AS JADISP ")
        strSQL.Append("       , SUM(DECODE(HATKBN || TAIOKBN || TMSKB,'122',CNT,0)) AS C01 ")            '←2021/10/01 2021年度監視改善�EStart
        strSQL.Append("       , SUM(DECODE(HATKBN || TAIOKBN || TMSKB,'112',CNT,0)) AS C02 ")
        strSQL.Append("       , SUM(DECODE(HATKBN || TAIOKBN || TMSKB,'111',CNT,'121',CNT,'113',CNT,'123',CNT,0)) AS C03 ")
        strSQL.Append("       , SUM(DECODE(HATKBN || TAIOKBN,'11',CNT,'12',CNT,0)) AS SUM1 ")
        strSQL.Append("       , SUM(DECODE(HATKBN || TAIOKBN || TMSKB,'222',CNT,0)) AS C04 ")
        strSQL.Append("       , SUM(DECODE(HATKBN || TAIOKBN || TMSKB,'212',CNT,0)) AS C05 ")
        strSQL.Append("       , SUM(DECODE(HATKBN || TAIOKBN || TMSKB,'211',CNT,'213',CNT,'221',CNT,'223',CNT,0)) AS C06 ")
        strSQL.Append("       , SUM(DECODE(HATKBN || TAIOKBN,'21',CNT,'22',CNT,0)) AS SUM2 ")
        strSQL.Append("       , SUM(DECODE(TAIOKBN,'1',CNT,'2',CNT,0)) AS SUMA ")                         '←2021/10/01 2021年度監視改善�EEnd
        strSQL.Append("FROM   Z ")
        strSQL.Append("GROUP BY KURACD ")
        strSQL.Append("UNION ALL ")
        '全体の総合計
        strSQL.Append("SELECT 'XYZ' AS KURACD ")
        strSQL.Append("       , '総合計' AS KURADISP ")
        strSQL.Append("       , '' AS JACD ")
        strSQL.Append("       , '' AS JADISP ")
        strSQL.Append("       , SUM(DECODE(HATKBN || TAIOKBN || TMSKB,'122',CNT,0)) AS C01 ")            '←2021/10/01 2021年度監視改善�EStart
        strSQL.Append("       , SUM(DECODE(HATKBN || TAIOKBN || TMSKB,'112',CNT,0)) AS C02 ")
        strSQL.Append("       , SUM(DECODE(HATKBN || TAIOKBN || TMSKB,'111',CNT,'121',CNT,'113',CNT,'123',CNT,0)) AS C03 ")
        strSQL.Append("       , SUM(DECODE(HATKBN || TAIOKBN,'11',CNT,'12',CNT,0)) AS SUM1 ")
        strSQL.Append("       , SUM(DECODE(HATKBN || TAIOKBN || TMSKB,'222',CNT,0)) AS C04 ")
        strSQL.Append("       , SUM(DECODE(HATKBN || TAIOKBN || TMSKB,'212',CNT,0)) AS C05 ")
        strSQL.Append("       , SUM(DECODE(HATKBN || TAIOKBN || TMSKB,'211',CNT,'213',CNT,'221',CNT,'223',CNT,0)) AS C06 ")
        strSQL.Append("       , SUM(DECODE(HATKBN || TAIOKBN,'21',CNT,'22',CNT,0)) AS SUM2 ")
        strSQL.Append("       , SUM(DECODE(TAIOKBN,'1',CNT,'2',CNT,0)) AS SUMA ")                         '←2021/10/01 2021年度監視改善�EEnd
        '        strSQL.Append("       , SUM(DECODE(HATKBN || TAIOKBN || TMSKB,'122',CNT,0)) AS C01 ") '←2021/10/01 2021年度監視改善�Eによりコメント化
        '        strSQL.Append("       , SUM(DECODE(HATKBN || TAIOKBN || TMSKB,'112',CNT,0)) AS C02 ") '←上部からここまで3カ所ともこのロジックだが、
        '        strSQL.Append("       , SUM(DECODE(HATKBN || TAIOKBN || TMSKB,'111',CNT,0)) AS C03 ") '←ここだけ残しておく
        '        strSQL.Append("       , SUM(DECODE(HATKBN,'1',CNT,0)) AS SUM1 ")
        '        strSQL.Append("       , SUM(DECODE(HATKBN || TAIOKBN || TMSKB,'222',CNT,0)) AS C04 ")
        '        strSQL.Append("       , SUM(DECODE(HATKBN || TAIOKBN || TMSKB,'212',CNT,0)) AS C05 ")
        '        strSQL.Append("       , SUM(DECODE(HATKBN || TAIOKBN || TMSKB,'211',CNT,0)) AS C06 ")
        '        strSQL.Append("       , SUM(DECODE(HATKBN,'2',CNT,0)) AS SUM2 ")
        '        strSQL.Append("       , SUM(CNT) AS SUMA ")                                           '←2021/10/01 コメント化End
        strSQL.Append("FROM   Z ")
        strSQL.Append("ORDER BY KURACD, JACD ")

        mlog(strSQL.ToString)

        Return strSQL.ToString

    End Function
End Class
