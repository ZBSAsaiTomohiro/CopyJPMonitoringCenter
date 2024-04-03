'******************************************************************************
' 一般消費者名簿出力
' PGID: SBMEOJAW00.asmx.vb
'******************************************************************************
'変更履歴
' 2019/01/11 T.Ono 新規作成

Option Explicit On 
Option Strict On

Imports Common
Imports Common.DB

Imports System.Web.Services
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Configuration
Imports System.IO
Imports NPOI.SS.UserModel
Imports NPOI.HSSF.UserModel
Imports NPOI.XSSF.UserModel
Imports NPOI.SS.Util.CellUtil

<System.Web.Services.WebService(Namespace:="http://tempuri.org/SBMEOJAW00/Service1")> _
Public Class SBMEOJAW00
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
                                        ByVal pstrNENDO As String,
                                        ByVal pstrKENCD As String,
                                        ByVal pstrKURACDFrom As String,
                                        ByVal pstrKURACDTo As String,
                                        ByVal pstrHANTENCDFrom As String,
                                        ByVal pstrHANTENCDTo As String,
                                        ByVal pstrFileType As String
                                        ) As String


        Dim strSQL As New StringBuilder("")
        Dim cdb As New CDB
        Dim ds As New DataSet
        Dim dr As DataRow
        Dim strRec As String = ""

        '作成ファイル格納フォルダ
        'Dim strTempDir As String = "C:\inetpub\wwwroot\JPGAP\TEMP\00\SBMEOJAW00\"
        Dim strTempDir As String = ConfigurationSettings.AppSettings("SBMEOJAW_PATH")
        Dim strZipDirName As String = Now.ToString("yyyyMMddHHmmss")　　'作成したexcelを入れるフォルダ
        Dim strZipDirPath As String = strTempDir & strZipDirName & "\"  'フォルダのパス

        'フォルダ作成
        If File.Exists(strZipDirPath) = False Then
            System.IO.Directory.CreateDirectory(strZipDirPath)
        End If


        '接続OPEN----------------------------------------
        Try
            cdb.mOpen()
        Catch ex As Exception
            Return ex.ToString
        Finally

        End Try

        '帳票出力項目の取得用SQL文セット-------------------
        Try

            '分類コードNULLのデータあるかチェックSQL文セット
            If pstrFileType = "1" Then
                strSQL.Append(fncMakeChkSelect(pstrNENDO,
                                            pstrKENCD,
                                            pstrKURACDFrom,
                                            pstrKURACDTo,
                                            pstrHANTENCDFrom,
                                            pstrHANTENCDTo,
                                            pstrFileType))

                cdb.pSQL = strSQL.ToString

                'パラメータセット
                '年度
                cdb.pSQLParamStr("NENDO") = pstrNENDO.Trim
                '県コード
                cdb.pSQLParamStr("KENCD") = pstrKENCD.Trim
                'クライアントコード
                If pstrKURACDFrom.Trim.Length > 0 Then
                    cdb.pSQLParamStr("KURACD_FROM") = pstrKURACDFrom.Trim
                End If
                If pstrKURACDTo.Trim.Length > 0 Then
                    cdb.pSQLParamStr("KURACD_TO") = pstrKURACDTo.Trim
                End If
                '販売店コード
                If pstrHANTENCDFrom.Trim.Length > 0 Then
                    cdb.pSQLParamStr("HANTENCD_FROM") = pstrHANTENCDFrom.Trim
                End If
                If pstrHANTENCDTo.Trim.Length > 0 Then
                    cdb.pSQLParamStr("HANTENCD_TO") = pstrHANTENCDTo.Trim
                End If

                cdb.mExecQuery()    'SQL実行
                ds = cdb.pResult    '結果をデータセットに格納

                'データが存在する場合
                If ds.Tables(0).Rows.Count > 0 Then
                    Return "NULLEXIST"      '分類コードNULLのデータある
                End If
            End If


            '帳票出力項目の取得用SQL文セット
            strSQL.Clear()
            strSQL.Append(fncMakeSelect(pstrNENDO,
                                        pstrKENCD,
                                        pstrKURACDFrom,
                                        pstrKURACDTo,
                                        pstrHANTENCDFrom,
                                        pstrHANTENCDTo,
                                        pstrFileType))

            cdb.pSQL = strSQL.ToString

            'パラメータセット
            '年度
            cdb.pSQLParamStr("NENDO") = pstrNENDO.Trim
            '県コード
            cdb.pSQLParamStr("KENCD") = pstrKENCD.Trim
            'クライアントコード
            If pstrKURACDFrom.Trim.Length > 0 Then
                cdb.pSQLParamStr("KURACD_FROM") = pstrKURACDFrom.Trim
            End If
            If pstrKURACDTo.Trim.Length > 0 Then
                cdb.pSQLParamStr("KURACD_TO") = pstrKURACDTo.Trim
            End If
            '販売店コード
            If pstrHANTENCDFrom.Trim.Length > 0 Then
                cdb.pSQLParamStr("HANTENCD_FROM") = pstrHANTENCDFrom.Trim
            End If
            If pstrHANTENCDTo.Trim.Length > 0 Then
                cdb.pSQLParamStr("HANTENCD_TO") = pstrHANTENCDTo.Trim
            End If

            cdb.mExecQuery()    'SQL実行
            ds = cdb.pResult    '結果をデータセットに格納

            'データが存在しない場合
            If ds.Tables(0).Rows.Count = 0 Then
                Return "DATA0"      'データが0件であることを示す文字列を返す
            End If


            '帳票作成
            Select Case pstrFileType
                Case "1"
                    '一般消費者名簿
                    strRec = IppansyohisyaOut(ds, dr, strZipDirPath)
                Case "2"
                    '確認用リスト
                    strRec = KakuninlistOut(ds, dr, strZipDirPath, pstrFileType)
                Case "3"
                    'すべて
                    strRec = KakuninlistOut(ds, dr, strZipDirPath, pstrFileType)
            End Select

            If strRec.Substring(0, 5) = "ERROR" Then
                mlog(strRec)
                Return strRec
            End If


            '変数宣言
            Dim strToDir As String = ""           '圧縮先ファイルのあるフォルダ
            Dim strToZipDir As String = ""        '圧縮するディレクトリ
            Dim strNihongoFileName As String = "" '日本語ファイル名の指定(パラメータ[セッション] + 電話番号)
            Dim strFileName As String = ""        '圧縮元ファイル名(FAX用EXCEL、メール用ZIPファイル名)
            Dim strmadeFilename As String = ""    '圧縮先ファイル名(パラメータ[セッション])


            'Dim strZipFileName As String = "C:\inetpub\wwwroot\JPGAP\TEMP\00\SBMEOJAW00\DLFile.zip"
            Dim strZipFileName As String = strTempDir & strZipDirName & ".zip"


            Dim fastZip As New ICSharpCode.SharpZipLib.Zip.FastZip()

            fastZip.CreateEmptyDirectories = True

            fastZip.UseZip64 = ICSharpCode.SharpZipLib.Zip.UseZip64.Dynamic

            fastZip.CreateZip(strZipFileName, strZipDirPath, True, Nothing, Nothing)

            '圧縮したZIPファイル名を戻す
            Return strZipFileName
            'mlog(pstrSESSION & "\" & pstrKANSI_CODE & "\" & pstrKURACD_F & "\" & pstrKURACD_T, "BTFAXJAX00:mExcelOut：8")

        Catch ex As Exception
            'エラーの内容とＳＱＬ文を返すbaba
            Return "ERROR:" & ex.ToString

        Finally
            cdb.mClose()        '接続クローズ
        End Try

    End Function

    '******************************************************************************
    '*　概　要:ＳＥＬＥＣＴ文を作成
    '*　備　考:一般消費者名簿の場合の分類コードNULLレコードをチェック
    '******************************************************************************
    Public Function fncMakeChkSelect(ByVal pstrNENDO As String,
                      ByVal pstrKENCD As String,
                      ByVal pstrKURACDFrom As String,
                      ByVal pstrKURACDTo As String,
                      ByVal pstrHANTENCDFrom As String,
                      ByVal pstrHANTENCDTo As String,
                      ByVal pstrFileType As String) As String

        Dim strSQL As New StringBuilder("")

        strSQL.Append("SELECT NENDO, ")
        strSQL.Append("       KURACD, ")
        strSQL.Append("       KENCD, ")
        strSQL.Append("       ACBCD, ")
        strSQL.Append("       USER_CD, ")
        strSQL.Append("       JUSYONM, ")
        strSQL.Append("       ADDR1, ")
        strSQL.Append("       ADDR2, ")
        strSQL.Append("       ADDR3, ")
        strSQL.Append("       ADDR, ")
        strSQL.Append("       RENTEL, ")
        strSQL.Append("       SYUTUTEL, ")
        strSQL.Append("       KESSEN, ")
        strSQL.Append("       DAIHYO_NAME, ")
        strSQL.Append("       KYOKTKBN, ")
        strSQL.Append("       HOKBN, ")
        strSQL.Append("       YOTOKBN, ")
        strSQL.Append("       BUNRUICD, ")
        strSQL.Append("       HANJICD, ")
        strSQL.Append("       HANJINM, ")
        strSQL.Append("       HANTENCD, ")
        strSQL.Append("       HANTENNM ")
        strSQL.Append("FROM   D30_MEIBO ")
        strSQL.Append("WHERE  1=1 ")
        strSQL.Append("AND    NENDO = :NENDO ")
        strSQL.Append("AND    KENCD = :KENCD ")
        strSQL.Append("AND    BUNRUICD IS NULL ")


        '2019/11/01 T.Ono mod 監視改善2019 START
        '選択パターンによって、SQLを変える
        ''クライアントコード
        'If pstrKURACDFrom.Trim.Length > 0 Then
        '    strSQL.Append("AND    KURACD >= :KURACD_FROM ")
        'End If
        'If pstrKURACDTo.Trim.Length > 0 Then
        '    strSQL.Append("AND    KURACD <= :KURACD_TO ")
        'End If

        ''販売店コード
        'If pstrHANTENCDFrom.Trim.Length > 0 Then
        '    strSQL.Append("AND    HANTENCD >= :HANTENCD_FROM ")
        'End If
        'If pstrHANTENCDTo.Trim.Length > 0 Then
        '    strSQL.Append("AND    HANTENCD <= :HANTENCD_TO ")
        'End If

        If pstrKURACDFrom.Trim.Length > 0 Then
            If pstrHANTENCDFrom.Trim.Length > 0 Then
                'クライアント＆販売店
                strSQL.Append("AND    KURACD || HANTENCD >= :KURACD_FROM || :HANTENCD_FROM ")
            Else
                'クライアント
                strSQL.Append("AND    KURACD >= :KURACD_FROM ")
            End If
        Else
            If pstrHANTENCDFrom.Trim.Length > 0 Then
                '販売店
                strSQL.Append("AND    HANTENCD >= :HANTENCD_FROM ")
            End If
        End If

        If pstrKURACDTo.Trim.Length > 0 Then
            If pstrHANTENCDTo.Trim.Length > 0 Then
                'クライアント＆販売店
                strSQL.Append("AND    KURACD || HANTENCD <= :KURACD_TO || :HANTENCD_TO ")
            Else
                'クライアント
                strSQL.Append("AND    KURACD <= :KURACD_TO ")
            End If
        Else
            If pstrHANTENCDTo.Trim.Length > 0 Then
                '販売店
                strSQL.Append("AND    HANTENCD <= :HANTENCD_TO ")
            End If
        End If
        '2019/11/01 T.Ono mod 監視改善2019 END

        Return strSQL.ToString

    End Function


    '******************************************************************************
    '*　概　要:ＳＥＬＥＣＴ文を作成
    '*　備　考:
    '******************************************************************************
    Public Function fncMakeSelect(ByVal pstrNENDO As String,
                      ByVal pstrKENCD As String,
                      ByVal pstrKURACDFrom As String,
                      ByVal pstrKURACDTo As String,
                      ByVal pstrHANTENCDFrom As String,
                      ByVal pstrHANTENCDTo As String,
                      ByVal pstrFileType As String) As String

        Dim strSQL As New StringBuilder("")

        strSQL.Append("SELECT NENDO, ")
        strSQL.Append("       KURACD, ")
        strSQL.Append("       KENCD, ")
        strSQL.Append("       ACBCD, ")
        strSQL.Append("       USER_CD, ")
        strSQL.Append("       JUSYONM, ")
        strSQL.Append("       ADDR1, ")
        strSQL.Append("       ADDR2, ")
        strSQL.Append("       ADDR3, ")
        strSQL.Append("       ADDR, ")
        strSQL.Append("       RENTEL, ")
        strSQL.Append("       SYUTUTEL, ")
        strSQL.Append("       KESSEN, ")
        strSQL.Append("       DAIHYO_NAME, ")
        strSQL.Append("       KYOKTKBN, ")
        strSQL.Append("       HOKBN, ")
        strSQL.Append("       YOTOKBN, ")
        strSQL.Append("       BUNRUICD, ")
        strSQL.Append("       HANJICD, ")
        strSQL.Append("       HANJINM, ")
        strSQL.Append("       HANTENCD, ")
        strSQL.Append("       HANTENNM ")
        strSQL.Append("FROM   D30_MEIBO ")
        strSQL.Append("WHERE  1=1 ")
        strSQL.Append("AND    NENDO = :NENDO ")
        strSQL.Append("AND    KENCD = :KENCD ")

        '2019/11/01 T.Ono mod 監視改善2019 START
        '選択パターンによって、SQLを変える
        ''クライアントコード
        'If pstrKURACDFrom.Trim.Length > 0 Then
        '    strSQL.Append("AND    KURACD >= :KURACD_FROM ")
        'End If
        'If pstrKURACDTo.Trim.Length > 0 Then
        '    strSQL.Append("AND    KURACD <= :KURACD_TO ")
        'End If

        ''販売店コード
        'If pstrHANTENCDFrom.Trim.Length > 0 Then
        '    strSQL.Append("AND    HANTENCD >= :HANTENCD_FROM ")
        'End If
        'If pstrHANTENCDTo.Trim.Length > 0 Then
        '    strSQL.Append("AND    HANTENCD <= :HANTENCD_TO ")
        'End If

        If pstrKURACDFrom.Trim.Length > 0 Then
            If pstrHANTENCDFrom.Trim.Length > 0 Then
                'クライアント＆販売店
                strSQL.Append("AND    KURACD || HANTENCD >= :KURACD_FROM || :HANTENCD_FROM ")
            Else
                'クライアント
                strSQL.Append("AND    KURACD >= :KURACD_FROM ")
            End If
        Else
            If pstrHANTENCDFrom.Trim.Length > 0 Then
                '販売店
                strSQL.Append("AND    HANTENCD >= :HANTENCD_FROM ")
            End If
        End If

        If pstrKURACDTo.Trim.Length > 0 Then
            If pstrHANTENCDTo.Trim.Length > 0 Then
                'クライアント＆販売店
                strSQL.Append("AND    KURACD || HANTENCD <= :KURACD_TO || :HANTENCD_TO ")
            Else
                'クライアント
                strSQL.Append("AND    KURACD <= :KURACD_TO ")
            End If
        Else
            If pstrHANTENCDTo.Trim.Length > 0 Then
                '販売店
                strSQL.Append("AND    HANTENCD <= :HANTENCD_TO ")
            End If
        End If
        '2019/11/01 T.Ono mod 監視改善2019 END

        '出力リスト毎の条件とorder
        Select Case pstrFileType
            Case "1" '一般消費者名簿
                strSQL.Append("AND    BUNRUICD <> '9' ")
                strSQL.Append("ORDER BY HANJICD, BUNRUICD, HANTENCD, KENCD, KURACD, ACBCD, USER_CD ")
            Case "2" '確認リスト
                strSQL.Append("AND    BUNRUICD IS NULL ")
                strSQL.Append("ORDER BY HANJICD, BUNRUICD, HANTENCD, KENCD, KURACD, ACBCD, USER_CD ")
            Case "3" 'すべて
                strSQL.Append("ORDER BY HANJICD, HANTENCD, BUNRUICD, KENCD, KURACD, ACBCD, USER_CD ")
        End Select

        Return strSQL.ToString

    End Function

    '******************************************************************************
    '*　概　要:EXCEL出力（一般消費者名簿）
    '*　備　考:
    '******************************************************************************
    Function IppansyohisyaOut(ByVal ds As DataSet, ByVal dr As DataRow, ByVal pZipFileDir As String) As String

        Dim book As IWorkbook = New XSSFWorkbook()
        Dim sheet1 As ISheet
        Dim wfs As FileStream
        Dim rows As IRow
        Dim style1 As ICellStyle 'ヘッダ用
        Dim style2 As ICellStyle '明細用

        Dim strFileName As String
        Dim strFilePath As String
        Dim strSheetName As String

        Dim strFileName_old As String = "0"
        Dim strHANTEN_old As String = "0"

        '明細データ出力
        Dim iCnt As Integer = 0
        Dim isheet As Integer = 1
        Dim iRow As Integer = 0


        Try
            'APサーバからの戻り値をループする
            'データ出力
            For iCnt = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(iCnt)

                'excelファイル名
                If Convert.ToString(dr.Item("HANJICD")).Trim.Length > 0 Then
                    strFileName = Convert.ToString(dr.Item("HANJICD")) & "_" & Convert.ToString(dr.Item("BUNRUICD")) & ".xlsx"
                Else
                    strFileName = "HANJICDnull_" & Convert.ToString(dr.Item("KENCD")) & Convert.ToString(dr.Item("ACBCD")) & ".xlsx"

                End If
                strFileName = Convert.ToString(dr.Item("HANJICD")) & "_" & Convert.ToString(dr.Item("BUNRUICD")) & ".xlsx"

                '新規ファイル作成
                If strFileName <> strFileName_old Then

                    '閉じる
                    If iCnt > 0 Then
                        book.Write(wfs)
                        wfs.Dispose()
                        book.Close()
                    End If

                    book = New XSSFWorkbook()
                    strFilePath = pZipFileDir & strFileName
                    wfs = New FileStream(strFilePath, FileMode.Create)
                    strFileName_old = strFileName '次レコードとの比較用

                    '新規シート作成
                    isheet = 1       'シート番号
                    If Convert.ToString(dr.Item("HANTENNM")).Trim.Length > 0 Then
                        strSheetName = Convert.ToString(dr.Item("HANTENNM"))
                        If strSheetName.Length > 25 Then
                            strSheetName = "(" & isheet & ")" & strSheetName.Substring(0, 25)
                        Else
                            strSheetName = "(" & isheet & ")" & strSheetName
                        End If

                        sheet1 = book.CreateSheet(strSheetName)  'シート作成
                    Else
                        sheet1 = book.CreateSheet("(" & isheet & ")" & "HANTENNMnull_" & Convert.ToString(dr.Item("HANTENCD")))  'シート作成
                    End If

                    strHANTEN_old = Convert.ToString(dr.Item("HANTENCD")) '次レコードとの比較用
                    iRow = 0          'シート作成したら、行をリセット

                    'ヘッダ用書式
                    style1 = book.CreateCellStyle()
                    style1.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin
                    style1.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin
                    style1.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin
                    style1.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin
                    style1.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center
                    style1.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Center
                    style1.WrapText = True

                    '明細用書式
                    style2 = book.CreateCellStyle()
                    Dim format2 As IDataFormat = book.CreateDataFormat()
                    style2.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin
                    style2.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin
                    style2.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin
                    style2.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin
                    style2.ShrinkToFit = True
                    style2.DataFormat = format2.GetFormat("@") '文字列 IDataFormatオブジェクトを作って、GetFormatで文字列のshort型を取得する

                Else
                    '新規シート作成
                    If Convert.ToString(dr.Item("HANTENCD")) <> strHANTEN_old Then
                        isheet += 1          'シート番号
                        If Convert.ToString(dr.Item("HANTENNM")).Trim.Length > 0 Then
                            strSheetName = Convert.ToString(dr.Item("HANTENNM"))
                            If strSheetName.Length > 25 Then
                                strSheetName = "(" & isheet & ")" & strSheetName.Substring(0, 25)
                            Else
                                strSheetName = "(" & isheet & ")" & strSheetName
                            End If
                            sheet1 = book.CreateSheet(strSheetName)  'シート作成
                        Else
                            sheet1 = book.CreateSheet("(" & isheet & ")" & "HANTENNMnull_" & Convert.ToString(dr.Item("HANTENNM")))  'シート作成
                        End If

                        strHANTEN_old = Convert.ToString(dr.Item("HANTENCD")) '次レコードとの比較用
                        iRow = 0             'シート作成したら、行をリセット
                    End If
                End If


                'ヘッダ
                If iRow = 0 Then
                    rows = sheet1.CreateRow(0)
                    rows.CreateCell(0).SetCellValue("１．委託販売所名：" & Convert.ToString(dr.Item("HANTENNM")))
                    sheet1.SetColumnWidth(0, 256 * 5) '1文字の256分の1が単位。およそ5文字。

                    rows = sheet1.CreateRow(1)
                    rows.CreateCell(0).SetCellValue("２．受託事業者名：株式会社ＪＡ-LPガス情報センター")

                    If Convert.ToString(dr.Item("BUNRUICD")) = "1" OrElse Convert.ToString(dr.Item("BUNRUICD")) = "2" Then
                        rows = sheet1.CreateRow(2)
                        'rows.CreateCell(0).SetCellValue("３．保安業務区分：緊急連絡先") 2019/05/09 T.Ono mod 
                        rows.CreateCell(0).SetCellValue("３．保安業務区分：緊急時連絡")
                    Else
                        rows = sheet1.CreateRow(2)
                        rows.CreateCell(0).SetCellValue("３．保安業務区分：")
                    End If

                    rows = sheet1.CreateRow(3)
                    rows.CreateCell(0).SetCellValue("４．一般消費者等の氏名（法人にあっては名称及び代表者の氏名）、住所、電話番号")


                    rows = sheet1.CreateRow(5)
                    rows.CreateCell(0).SetCellValue("No.")
                    sheet1.GetRow(5).GetCell(0).CellStyle = style1
                    rows.CreateCell(1).SetCellValue("県コード")
                    sheet1.SetColumnWidth(1, 256 * 8)
                    sheet1.GetRow(5).GetCell(1).CellStyle = style1
                    rows.CreateCell(2).SetCellValue("JA支所コード")
                    sheet1.SetColumnWidth(2, 256 * 12)
                    sheet1.GetRow(5).GetCell(2).CellStyle = style1
                    rows.CreateCell(3).SetCellValue("お客様コード")
                    sheet1.SetColumnWidth(3, 256 * 12)
                    sheet1.GetRow(5).GetCell(3).CellStyle = style1
                    rows.CreateCell(4).SetCellValue("一般消費者等の" & vbLf & "氏名・名称")
                    sheet1.SetColumnWidth(4, 256 * 21)
                    sheet1.GetRow(5).GetCell(4).CellStyle = style1
                    rows.CreateCell(5).SetCellValue("代表者名")
                    sheet1.SetColumnWidth(5, 256 * 21)
                    sheet1.GetRow(5).GetCell(5).CellStyle = style1
                    rows.CreateCell(6).SetCellValue("住所")
                    sheet1.SetColumnWidth(6, 256 * 35)
                    sheet1.GetRow(5).GetCell(6).CellStyle = style1
                    rows.CreateCell(7).SetCellValue("電話番号")
                    sheet1.SetColumnWidth(7, 256 * 15)
                    sheet1.GetRow(5).GetCell(7).CellStyle = style1
                    rows.CreateCell(8).SetCellValue("備考")
                    sheet1.SetColumnWidth(8, 256 * 10)
                    sheet1.GetRow(5).GetCell(8).CellStyle = style1

                    '一部非表示
                    sheet1.SetColumnHidden(1, True)
                    sheet1.SetColumnHidden(2, True)
                    sheet1.SetColumnHidden(3, True)

                    iRow = 6
                End If

                '明細行
                rows = sheet1.CreateRow(iRow)
                rows.CreateCell(0).SetCellValue(iRow - 5)
                sheet1.GetRow(iRow).GetCell(0).CellStyle = style2
                rows.CreateCell(1).SetCellValue(Convert.ToString(dr.Item("KENCD")))
                sheet1.GetRow(iRow).GetCell(1).CellStyle = style2
                rows.CreateCell(2).SetCellValue(Convert.ToString(dr.Item("ACBCD")))
                sheet1.GetRow(iRow).GetCell(2).CellStyle = style2
                rows.CreateCell(3).SetCellValue(Convert.ToString(dr.Item("USER_CD")))
                sheet1.GetRow(iRow).GetCell(3).CellStyle = style2
                rows.CreateCell(4).SetCellValue(Convert.ToString(dr.Item("JUSYONM")))
                sheet1.GetRow(iRow).GetCell(4).CellStyle = style2
                rows.CreateCell(5).SetCellValue(Convert.ToString(dr.Item("DAIHYO_NAME")))
                sheet1.GetRow(iRow).GetCell(5).CellStyle = style2
                rows.CreateCell(6).SetCellValue(Convert.ToString(dr.Item("ADDR")))
                sheet1.GetRow(iRow).GetCell(6).CellStyle = style2
                rows.CreateCell(7).SetCellValue(Convert.ToString(dr.Item("SYUTUTEL")))
                sheet1.GetRow(iRow).GetCell(7).CellStyle = style2
                rows.CreateCell(8).SetCellValue(Convert.ToString(dr.Item("KESSEN")))
                sheet1.GetRow(iRow).GetCell(8).CellStyle = style2

                iRow += 1
            Next

            book.Write(wfs)

            wfs.Dispose()
            book.Close()

            Return "OK!!!"

        Catch ex As Exception
            Return "ERROR:" & "IppansyohisyaOut:" & ex.Message

        Finally
            wfs.Dispose()
            book.Close()
        End Try
    End Function

    '******************************************************************************
    '*　概　要:EXCEL出力（確認用リスト）
    '*　備　考:
    '******************************************************************************
    Function KakuninlistOut(ByVal ds As DataSet, ByVal dr As DataRow, ByVal pZipFileDir As String, ByVal pFileType As String) As String

        Dim book As IWorkbook = New XSSFWorkbook()
        Dim sheet1 As ISheet
        Dim wfs As FileStream
        Dim rows As IRow
        Dim cells As ICell

        Dim strFileName As String
        Dim strFilePath As String
        Dim strSheetName As String

        Dim strFileName_old As String = "0"
        Dim strHANTEN_old As String = "0"

        '明細データ出力
        Dim iCnt As Integer = 0
        Dim isheet As Integer = 1
        Dim iRow As Integer = 0


        'セルの書式設定　ICellStyleを定義して各セルに適用する
        '罫線あり（細い枠）
        Dim style1 As ICellStyle
        '背景色黄色
        Dim style2 As ICellStyle
        '明細用
        Dim style3 As ICellStyle
        Dim format3 As IDataFormat


        Try
            'APサーバからの戻り値をループする
            'データ出力
            For iCnt = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(iCnt)

                'excelファイル名
                strFileName = Convert.ToString(dr.Item("HANJICD")) & ".xlsx"

                '新規ファイル作成
                If strFileName <> strFileName_old Then

                    '閉じる
                    If iCnt > 0 Then
                        book.Write(wfs)
                        wfs.Dispose()
                        book.Close()
                    End If

                    book = New XSSFWorkbook()
                    strFilePath = pZipFileDir & strFileName
                    wfs = New FileStream(strFilePath, FileMode.Create)
                    strFileName_old = strFileName '次レコードとの比較用

                    '新規シート作成
                    isheet = 1       'シート番号
                    If Convert.ToString(dr.Item("HANTENNM")).Trim.Length > 0 Then
                        strSheetName = Convert.ToString(dr.Item("HANTENNM"))
                        If strSheetName.Length > 25 Then
                            strSheetName = "(" & isheet & ")" & strSheetName.Substring(0, 25)
                        Else
                            strSheetName = "(" & isheet & ")" & strSheetName
                        End If
                        sheet1 = book.CreateSheet(strSheetName)  'シート作成
                    Else
                        sheet1 = book.CreateSheet("HANTENNMnull_" & Convert.ToString(dr.Item("HANTENNM")))  'シート作成
                    End If

                    strHANTEN_old = Convert.ToString(dr.Item("HANTENCD")) '次レコードとの比較用
                    iRow = 0          'シート作成したら、行をリセット

                    'セルの書式設定　ICellStyleを定義して各セルに適用する
                    '罫線あり（細い枠）
                    style1 = book.CreateCellStyle()
                    style1.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin
                    style1.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin
                    style1.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin
                    style1.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin

                    '背景色黄色
                    style2 = book.CreateCellStyle()
                    style2.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin
                    style2.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin
                    style2.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin
                    style2.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin
                    style2.FillPattern = NPOI.SS.UserModel.FillPattern.SolidForeground
                    style2.FillForegroundColor = NPOI.SS.UserModel.IndexedColors.Yellow.Index

                    '明細用
                    style3 = book.CreateCellStyle()
                    format3 = book.CreateDataFormat()
                    style3.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin
                    style3.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin
                    style3.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin
                    style3.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin
                    style3.ShrinkToFit = True
                    style3.DataFormat = format3.GetFormat("@") '文字列 IDataFormatオブジェクトを作って、GetFormatで文字列のshort型を取得する


                Else
                    '新規シート作成
                    If Convert.ToString(dr.Item("HANTENCD")) <> strHANTEN_old Then
                        isheet += 1          'シート番号
                        If Convert.ToString(dr.Item("HANTENNM")).Trim.Length > 0 Then
                            strSheetName = Convert.ToString(dr.Item("HANTENNM"))
                            If strSheetName.Length > 25 Then
                                strSheetName = "(" & isheet & ")" & strSheetName.Substring(0, 25)
                            Else
                                strSheetName = "(" & isheet & ")" & strSheetName
                            End If
                            sheet1 = book.CreateSheet(strSheetName)  'シート作成
                        Else
                            sheet1 = book.CreateSheet("(" & isheet & ")" & "HANTENNMnull_" & Convert.ToString(dr.Item("HANTENCD")))  'シート作成
                        End If

                        strHANTEN_old = Convert.ToString(dr.Item("HANTENCD")) '次レコードとの比較用
                        iRow = 0             'シート作成したら、行をリセット
                    End If
                End If


                'ヘッダ行
                If iRow = 0 Then
                    rows = sheet1.CreateRow(iRow)
                    rows.CreateCell(0).SetCellValue("ｸﾗｲｱﾝﾄｺｰﾄﾞ")
                    sheet1.SetColumnWidth(0, 256 * 12) '1文字の256分の1が単位。およそ12文字。
                    sheet1.GetRow(iRow).GetCell(0).CellStyle = style1
                    rows.CreateCell(1).SetCellValue("JA支所ｺｰﾄﾞ")
                    sheet1.SetColumnWidth(1, 256 * 12)
                    sheet1.GetRow(iRow).GetCell(1).CellStyle = style1
                    rows.CreateCell(2).SetCellValue("お客様ｺｰﾄﾞ")
                    sheet1.SetColumnWidth(2, 256 * 12)
                    sheet1.GetRow(iRow).GetCell(2).CellStyle = style1
                    rows.CreateCell(3).SetCellValue("お客様氏名")
                    sheet1.SetColumnWidth(3, 256 * 21)
                    sheet1.GetRow(iRow).GetCell(3).CellStyle = style1
                    rows.CreateCell(4).SetCellValue("法人代表者氏名")
                    sheet1.SetColumnWidth(4, 256 * 21)
                    sheet1.GetRow(iRow).GetCell(4).CellStyle = style1
                    rows.CreateCell(5).SetCellValue("住所１")
                    sheet1.SetColumnWidth(5, 256 * 21)
                    sheet1.GetRow(iRow).GetCell(5).CellStyle = style1
                    rows.CreateCell(6).SetCellValue("住所２")
                    sheet1.SetColumnWidth(6, 256 * 21)
                    sheet1.GetRow(iRow).GetCell(6).CellStyle = style1
                    rows.CreateCell(7).SetCellValue("住所３")
                    sheet1.SetColumnWidth(7, 256 * 21)
                    sheet1.GetRow(iRow).GetCell(7).CellStyle = style1
                    rows.CreateCell(8).SetCellValue("連絡電話番号")
                    sheet1.SetColumnWidth(8, 256 * 12)
                    sheet1.GetRow(iRow).GetCell(8).CellStyle = style1
                    rows.CreateCell(9).SetCellValue("結線/未結線")
                    sheet1.SetColumnWidth(9, 256 * 10)
                    sheet1.GetRow(iRow).GetCell(9).CellStyle = style1
                    rows.CreateCell(10).SetCellValue("供給形態区分")
                    sheet1.SetColumnWidth(10, 256 * 10)
                    sheet1.GetRow(iRow).GetCell(10).CellStyle = style1
                    rows.CreateCell(11).SetCellValue("適用法令区分")
                    sheet1.SetColumnWidth(11, 256 * 10)
                    sheet1.GetRow(iRow).GetCell(11).CellStyle = style1
                    rows.CreateCell(12).SetCellValue("用途区分")
                    sheet1.SetColumnWidth(12, 256 * 10)
                    sheet1.GetRow(iRow).GetCell(12).CellStyle = style1
                    rows.CreateCell(13).SetCellValue("分類コード")
                    sheet1.SetColumnWidth(13, 256 * 10)
                    sheet1.GetRow(iRow).GetCell(13).CellStyle = style1

                    '確認用リストは一部非表示、背景色つける
                    If pFileType = "2" Then
                        sheet1.SetColumnHidden(9, True)
                        sheet1.SetColumnHidden(10, True)
                        sheet1.SetColumnHidden(11, True)
                        sheet1.SetColumnHidden(12, True)
                        sheet1.GetRow(0).GetCell(4).CellStyle = style2
                        sheet1.GetRow(0).GetCell(13).CellStyle = style2
                    End If

                    iRow += 1
                End If

                '明細行
                rows = sheet1.CreateRow(iRow)
                rows.CreateCell(0).SetCellValue(Convert.ToString(dr.Item("KURACD")))
                sheet1.GetRow(iRow).GetCell(0).CellStyle = style3
                rows.CreateCell(1).SetCellValue(Convert.ToString(dr.Item("ACBCD")))
                sheet1.GetRow(iRow).GetCell(1).CellStyle = style3
                rows.CreateCell(2).SetCellValue(Convert.ToString(dr.Item("USER_CD")))
                sheet1.GetRow(iRow).GetCell(2).CellStyle = style3
                rows.CreateCell(3).SetCellValue(Convert.ToString(dr.Item("JUSYONM")))
                sheet1.GetRow(iRow).GetCell(3).CellStyle = style3
                rows.CreateCell(4).SetCellValue(Convert.ToString(dr.Item("DAIHYO_NAME")))
                sheet1.GetRow(iRow).GetCell(4).CellStyle = style3
                rows.CreateCell(5).SetCellValue(Convert.ToString(dr.Item("ADDR1")))
                sheet1.GetRow(iRow).GetCell(5).CellStyle = style3
                rows.CreateCell(6).SetCellValue(Convert.ToString(dr.Item("ADDR2")))
                sheet1.GetRow(iRow).GetCell(6).CellStyle = style3
                rows.CreateCell(7).SetCellValue(Convert.ToString(dr.Item("ADDR3")))
                sheet1.GetRow(iRow).GetCell(7).CellStyle = style3
                rows.CreateCell(8).SetCellValue(Convert.ToString(dr.Item("RENTEL")))
                sheet1.GetRow(iRow).GetCell(8).CellStyle = style3
                rows.CreateCell(9).SetCellValue(Convert.ToString(dr.Item("KESSEN")))
                sheet1.GetRow(iRow).GetCell(9).CellStyle = style3
                rows.CreateCell(10).SetCellValue(Convert.ToString(dr.Item("KYOKTKBN")))
                sheet1.GetRow(iRow).GetCell(10).CellStyle = style3
                rows.CreateCell(11).SetCellValue(Convert.ToString(dr.Item("HOKBN")))
                sheet1.GetRow(iRow).GetCell(11).CellStyle = style3
                rows.CreateCell(12).SetCellValue(Convert.ToString(dr.Item("YOTOKBN")))
                sheet1.GetRow(iRow).GetCell(12).CellStyle = style3
                rows.CreateCell(13).SetCellValue(Convert.ToString(dr.Item("BUNRUICD")))
                sheet1.GetRow(iRow).GetCell(13).CellStyle = style3

                iRow += 1
            Next

            book.Write(wfs)

            wfs.Dispose()
            book.Close()

            Return "OK!!!" '5文字返さないとsubstringでエラーになる

        Catch ex As Exception
            Return "ERROR:" & "KakuninlistOut:" & pFileType & ":" & ex.Message

        Finally
            wfs.Dispose()
            book.Close()
        End Try
    End Function

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
