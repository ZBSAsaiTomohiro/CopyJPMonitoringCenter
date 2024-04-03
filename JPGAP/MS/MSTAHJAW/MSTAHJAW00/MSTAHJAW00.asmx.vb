'***************************************************************************
'  ＪＡ担当者連絡先エクセル出力
'***************************************************************************
' 変更履歴
' 2015/12/16 T.Ono 新規作成
'（MSTAEJAG00をコピー　JA担当者・報告先・注意事項マスタを参照するためにリニューアル）

Option Explicit On 
Option Strict On

Imports Common
Imports Common.DB

Imports System.Web.Services
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.IO

<System.Web.Services.WebService(Namespace:="http://tempuri.org/MSTAHJAW00/Service1")> _
Public Class MSTAHJAW00
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
    '*　概　要:件数チェックを行う
    '*　備　考:
    '******************************************************************************
    '　DATA0:対象データがありません
    '  2019/11/01 T.Ono mod 監視改善2019　pstrKuracd_toを追加
    <WebMethod()> Public Function mCheck(
                                        ByVal pstrKuracd As String,
                                        ByVal pstrKuracd_to As String,
                                        ByVal pstrJAcd As String,
                                        ByVal pstrGroupcd As String,
                                        ByVal pstrCentercd As String,
                                        ByVal pdecPageMax As Decimal
                                        ) As String

        Dim strSQL As New StringBuilder("")
        Dim cdb As New CDB
        Dim ds As New DataSet
        Dim dr As DataRow
        Dim decGyoMax As Decimal = pdecPageMax '最大行数

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
            '2019/11/01 T.Ono mod 監視改善2019 pstrkuracd_to追加
            'cdb.pSQL = fncMakeSelect(2,
            '                         pstrKuracd,
            '                         pstrJAcd,
            '                         pstrGroupcd,
            '                         pstrCentercd)
            cdb.pSQL = fncMakeSelect(2,
                                     pstrKuracd,
                                     pstrKuracd_to,
                                     pstrJAcd,
                                     pstrGroupcd,
                                     pstrCentercd)

            'パラメータセット
            'クライアントコード
            If pstrKuracd.Length > 0 Then cdb.pSQLParamStr("KURACD") = pstrKuracd
            'クライアントコードTo  2019/11/01 T.Ono add 監視改善2019
            If pstrKuracd_to.Length > 0 Then cdb.pSQLParamStr("KURACD_TO") = pstrKuracd_to
            'ＪＡコード
            If pstrJAcd.Length > 0 Then cdb.pSQLParamStr("JACD") = pstrJAcd & "%"
            'グループコード
            If pstrGroupcd.Length > 0 Then cdb.pSQLParamStr("GROUPCD") = pstrGroupcd

            cdb.mExecQuery()    'SQL実行
            ds = cdb.pResult    '結果をデータセットに格納

            'データが存在しない場合
            If ds.Tables(0).Rows.Count = 0 Then
                Return "DATA0"      'データが0件であることを示す文字列を返す
            ElseIf ds.Tables(0).Rows.Count > decGyoMax Then
                Return "DATAMAX"    'データが最大行数を超える事を示す文字列を返す
            End If

            Return "OK"
        Catch ex As Exception
            'エラーの内容とＳＱＬ文を返す
            Return "ERROR:" & ex.ToString

        Finally
            cdb.mClose()        '接続クローズ
        End Try

    End Function

    '******************************************************************************
    '*　概　要:出力を行います
    '*　備　考:
    '******************************************************************************
    '　DATA0:対象データがありません
    '  2019/11/01 T.Ono mod 監視改善2019　pstrkuracd_to,pstrJAcd_CLIを追加
    <WebMethod()> Public Function mExcel(
                                        ByVal pstrSessionID As String,
                                        ByVal pstrKuracd As String,
                                        ByVal pstrKuracd_to As String,
                                        ByVal pstrJAcd As String,
                                        ByVal pstrJAcd_CLI As String,
                                        ByVal pstrGroupcd As String,
                                        ByVal pstrPgkbn As String,
                                        ByVal pstrKuraNm As String,
                                        ByVal pstrGroupNm As String,
                                        ByVal pdecPageMax As Decimal,
                                        ByVal pstrCentcd As String
                                        ) As String

        Dim strSQL As New StringBuilder("")
        Dim cdb As New CDB
        Dim ds As New DataSet
        Dim dr As DataRow
        Dim intGyoMax As Integer = CInt(pdecPageMax)    '最大行数
        Dim ExcelC As New CExcel                        'Excelクラス
        Dim compressC As New CCompress                  '圧縮クラス
        Dim DateFncC As New CDateFnc                    '日付変換クラス
        Dim CTimeFncC As New CTimeFnc                   '時間変換クラス
        Dim FileToStrC As New CFileStr                  'ファイルをBase64にエンコードするクラス
        Dim strHedInfo As String                        'ヘッダー情報（抽出条件）
        Dim intPrntRow As Integer = 72
        Dim StrFileNM1() As String                      '登録ﾌｧｲﾙ名1　2013/07/25 T.Ono add
        Dim StrFileNM2() As String                      '登録ﾌｧｲﾙ名2　2013/07/25 T.Ono add
        Dim StrFileNMtmp(1) As String                   '登録ﾌｧｲﾙ名tmp　2013/07/25 T.Ono add

        '接続OPEN----------------------------------------
        Try
            cdb.mOpen()
        Catch ex As Exception
            Return ex.ToString
        Finally

        End Try

        '帳票出力項目の取得用SQL文セット-------------------
        Try
            mlog("mExcel pstrKuracd:" & pstrKuracd & " pstrGroupcd:" & pstrGroupcd & " pstrCentcd:" & pstrCentcd)
            '帳票出力項目の取得用SQL文セット
            '2019/11/01 T.Ono mod 監視改善2019 pstrkuracd_to追加
            'strSQL.Append(fncMakeSelect(2,
            '                         pstrKuracd,
            '                         pstrJAcd,
            '                         pstrGroupcd,
            '                         pstrCentcd))
            strSQL.Append(fncMakeSelect(2,
                                     pstrKuracd,
                                     pstrKuracd_to,
                                     pstrJAcd,
                                     pstrGroupcd,
                                     pstrCentcd))

            'パラメータセット
            '2019/11/01 T.Ono mod 監視改善2019 START
            ''クライアントコード
            'If pstrKuracd.Length > 0 Then cdb.pSQLParamStr("KURACD") = pstrKuracd
            ''ＪＡコード
            'If pstrJAcd.Length > 0 Then cdb.pSQLParamStr("JACD") = pstrJAcd & "%"
            If pstrJAcd.Length > 0 Then
                'ＪＡコード
                cdb.pSQLParamStr("JACD") = pstrJAcd & "%"
                'クライアントコード　JA指定の場合は、JAのクライアントコードを入れる
                cdb.pSQLParamStr("KURACD") = pstrJAcd_CLI
                cdb.pSQLParamStr("KURACD_TO") = pstrJAcd_CLI
            Else
                'クライアントコード
                If pstrKuracd.Length > 0 Then cdb.pSQLParamStr("KURACD") = pstrKuracd
                If pstrKuracd_to.Length > 0 Then cdb.pSQLParamStr("KURACD_TO") = pstrKuracd_to
            End If
            '2019/11/01 T.Ono mod 監視改善2019　END
            'グループコード
            If pstrGroupcd.Length > 0 Then cdb.pSQLParamStr("GROUPCD") = pstrGroupcd

            cdb.pSQL = strSQL.ToString 'SQLをセット
            cdb.mExecQuery()    'SQL実行
            ds = cdb.pResult    '結果をデータセットに格納

            'データが存在しない場合
            If ds.Tables(0).Rows.Count = 0 Then
                Return "DATA0"      'データが0件であることを示す文字列を返す
            ElseIf ds.Tables(0).Rows.Count > intGyoMax Then
                Return "DATAMAX"    'データが最大行数を超える事を示す文字列を返す
            End If


            For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                ReDim Preserve StrFileNM1(j)
                ReDim Preserve StrFileNM2(j)

                If Convert.ToString(ds.Tables(0).Rows(j).Item("TANCD")) = "01" Then

                    StrFileNMtmp = fncSearchFile(Convert.ToString(ds.Tables(0).Rows(j).Item("GROUPCD")))
                    StrFileNM1(j) = StrFileNMtmp(0)
                    StrFileNM2(j) = StrFileNMtmp(1)
                Else
                    StrFileNM1(j) = ""
                    StrFileNM2(j) = ""
                End If
            Next

            dr = ds.Tables(0).Rows(0)           'データローにデータセットを格納
            ExcelC.pKencd = "00"                '県コードをセット
            ExcelC.pSessionID = pstrSessionID   'セッションID
            ExcelC.pRepoID = "MSTAHJAW00"       '帳票ID
            ExcelC.mOpen()                      'ファイルオープン

            ExcelC.pTitle = "ＪＡ担当者連絡先"                        'タイトル
            ExcelC.pDate = DateFncC.mGet(Now.ToString("yyyyMMdd"))  '作成日

            ExcelC.pFitPaper = True '用紙に横幅でフィットさせる
            'If pstrPgkbn = "1" Then '1:クライアント集約？
            '    ExcelC.pScale = 80                '縮小拡大率(%)
            'Else
            '    ExcelC.pScale = 65                '縮小拡大率(%)
            'End If

            '印刷向き
            ExcelC.pLandScape = True 'true:横/false:縦
            '余白
            ExcelC.pMarginTop = 2D
            ExcelC.pMarginBottom = 0.6D
            ExcelC.pMarginLeft = 1D
            ExcelC.pMarginRight = 0.5D
            ExcelC.pMarginHeader = 1.3D
            ExcelC.pMarginFooter = 1.3D
            ExcelC.pSheetName = "DATA"

            'ヘッダ項目をセット。（1ページあたり行数、出力行数、先頭行から何行目までが行タイトルか）
            ExcelC.mHeader(65000, ds.Tables(0).Rows.Count, 1)

            '-----------------------
            ' エクセル項目情報
            '-----------------------
            Dim arrColNM1(31) As String
            Dim arrColNM2(31) As String
            Dim arrColID(31) As String
            Dim arrHeadBGColor(31) As String
            Dim zoku As String
            Dim buf As String

            Dim i As Integer
            If True Then
                arrColNM1(1) = "区分"
                arrColNM1(2) = "ｸﾗｲｱﾝﾄｺｰﾄﾞ"
                arrColNM1(3) = "ｸﾞﾙｰﾌﾟｺｰﾄﾞ"
                arrColNM1(4) = "ｸﾞﾙｰﾌﾟｺｰﾄﾞ名"
                arrColNM1(5) = "ｺｰﾄﾞ"
                arrColNM1(6) = "担当者名漢字"
                arrColNM1(7) = "電話番号１"
                arrColNM1(8) = "電話番号２"
                arrColNM1(9) = "電話番号３"
                arrColNM1(10) = "ｽﾎﾟｯﾄFAX番号"
                arrColNM1(11) = "記事"
                arrColNM1(12) = "ｽﾎﾟｯﾄFAX送信先ﾒｰﾙｱﾄﾞﾚｽ"
                arrColNM1(13) = "ｽﾎﾟｯﾄFAX添付ﾌｧｲﾙﾊﾟｽﾜｰﾄﾞ"
                arrColNM1(14) = "自動FAX送信名"
                arrColNM1(15) = "自動FAX送信先ﾒｰﾙｱﾄﾞﾚｽ"
                arrColNM1(16) = "自動FAX添付ﾌｧｲﾙﾊﾟｽﾜｰﾄﾞ"
                arrColNM1(17) = "自動FAX番号"
                arrColNM1(18) = "自動送信区分"
                arrColNM1(19) = "ゼロ件送信フラグ"
                arrColNM1(20) = "報告要・不要初期値(JA)"
                arrColNM1(21) = "報告要・不要初期値(ｸﾗｲｱﾝﾄ)"
                arrColNM1(22) = "注意事項"
                arrColNM1(23) = "ﾌｧｲﾙ登録１"
                arrColNM1(24) = "ﾌｧｲﾙ登録２"
                arrColNM1(25) = "作成日時"
                arrColNM1(26) = "作成者"
                arrColNM1(27) = "更新日時"
                arrColNM1(28) = "更新者"
                arrColNM1(29) = "ｸﾗｲｱﾝﾄｺｰﾄﾞ"
                arrColNM1(30) = "ｸﾗｲｱﾝﾄ名"
            End If
            If True Then
                arrColID(1) = "KBN"
                arrColID(2) = "KURACD"
                arrColID(3) = "GROUPCD"
                arrColID(4) = "GROUPNM"
                arrColID(5) = "TANCD"
                arrColID(6) = "TANNM"
                arrColID(7) = "RENTEL1"
                arrColID(8) = "RENTEL2"
                arrColID(9) = "RENTEL3"
                arrColID(10) = "FAXNO"
                arrColID(11) = "BIKO"
                arrColID(12) = "SPOT_MAIL"
                arrColID(13) = "MAIL_PASS"
                arrColID(14) = "AUTO_FAXNM"
                arrColID(15) = "AUTO_MAIL"
                arrColID(16) = "AUTO_MAIL_PASS"
                arrColID(17) = "AUTO_FAXNO"
                arrColID(18) = "AUTO_KBN"
                arrColID(19) = "AUTO_ZERO_FLG"
                arrColID(20) = "FAXKBN"
                arrColID(21) = "FAXKURAKBN"
                arrColID(22) = "GUIDELINE"
                arrColID(23) = "file1"
                arrColID(24) = "file2"
                arrColID(25) = "INS_DATE"
                arrColID(26) = "INS_USER"
                arrColID(27) = "UPD_DATE"
                arrColID(28) = "UPD_USER"
                arrColID(29) = "CLI_CD"
                arrColID(30) = "CLI_NAME"
            End If

            If True Then
                arrHeadBGColor(1) = "background:#99CCFF;" '青
                arrHeadBGColor(2) = "background:#99CCFF;" '青
                arrHeadBGColor(3) = "background:#99CCFF;" '青
                arrHeadBGColor(4) = "background:#99CCFF;" '青
                arrHeadBGColor(5) = "background:#99CCFF;" '青
                arrHeadBGColor(6) = "background:#99CCFF;" '青
                arrHeadBGColor(7) = "background:#99CCFF;" '青
                arrHeadBGColor(8) = "background:#99CCFF;" '青
                arrHeadBGColor(9) = "background:#99CCFF;" '青
                arrHeadBGColor(10) = "background:#99CCFF;" '青
                arrHeadBGColor(11) = "background:#99CCFF;" '青
                arrHeadBGColor(12) = "background:#99CCFF;" '青
                arrHeadBGColor(13) = "background:#99CCFF;" '青
                arrHeadBGColor(14) = "background:#99CCFF;" '青
                arrHeadBGColor(15) = "background:#99CCFF;" '青
                arrHeadBGColor(16) = "background:#99CCFF;" '青
                arrHeadBGColor(17) = "background:#99CCFF;" '青
                arrHeadBGColor(18) = "background:#99CCFF;" '青
                arrHeadBGColor(19) = "background:#99CCFF;" '青
                arrHeadBGColor(20) = "background:#99CCFF;" '青
                arrHeadBGColor(21) = "background:#99CCFF;" '青
                arrHeadBGColor(22) = "background:#99CCFF;" '青
                arrHeadBGColor(23) = "background:#99CCFF;" '青
                arrHeadBGColor(24) = "background:#99CCFF;" '青
                arrHeadBGColor(25) = "background:#99CCFF;" '青
                arrHeadBGColor(26) = "background:#99CCFF;" '青
                arrHeadBGColor(27) = "background:#99CCFF;" '青
                arrHeadBGColor(28) = "background:#99CCFF;" '青
                arrHeadBGColor(29) = "background:#CCFFCC;" '黄緑
                arrHeadBGColor(30) = "background:#CCFFCC;" '黄緑
            End If


            '■ヘッダ行1
            For i = 1 To 30
                ExcelC.pCellStyle(i) = "height:26px;text-align:center;font-size:9px;border-style:solid;" & arrHeadBGColor(i)
                ExcelC.pCellVal(i) = arrColNM1(i)
            Next
            ExcelC.mWriteLine("")       '行をファイルに書き込む

            '■明細データ行
            Dim iCnt As Integer
            Dim tmp As String
            For iCnt = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(iCnt)

                '明細項目
                For i = 1 To 30
                    buf = ""
                    tmp = ""
                    zoku = ""
                    ' 登録ﾌｧｲﾙ名を入れる
                    If i = 23 Then
                        buf = Convert.ToString(StrFileNM1(iCnt))  '登録ﾌｧｲﾙ1
                    ElseIf i = 24 Then
                        buf = Convert.ToString(StrFileNM2(iCnt)) '登録ﾌｧｲﾙ2
                    Else
                        buf = Convert.ToString(dr.Item(arrColID(i)))
                    End If
                    tmp = "text-align:left;white-space:nowrap;"

                    ExcelC.pCellStyle(i) = "height:16px;font-size:11px;border-style:solid;" & tmp
                    ExcelC.pCellVal(i, zoku) = buf
                Next
                ExcelC.mWriteLine("")           '行をファイルに書き込む
            Next

            ExcelC.mClose()                                 'ファイルクローズ

            '圧縮先ファイルのあるフォルダ
            compressC.p_Dir = ExcelC.pDirName
            '日本語ファイル名の指定
            compressC.p_NihongoFileName = "ＪＡ担当者連絡先.xls"
            '圧縮元ファイル名
            compressC.p_FileName = ExcelC.pDirName & ExcelC.pFileName & ".xls"
            '圧縮先ファイル名
            compressC.p_madeFilename = ExcelC.pDirName & ExcelC.pFileName & ".lzh"
            'Excelを直接開くように変更、ファイルフルパスを返す
            ''圧縮実行
            'compressC.mCompress()
            ''圧縮したファイルをBase64エンコードして戻す
            ''.xls形式に変更
            ''Return FileToStrC.mFileToStr(compressC.p_madeFilename.Replace(".lzh", ".exe"))
            'Return FileToStrC.mFileToStr(compressC.p_FileName)
            Return compressC.p_FileName

        Catch ex As Exception
            'エラーの内容とＳＱＬ文を返す
            Return "ERROR:" & ex.ToString

        Finally
            cdb.mClose()        '接続クローズ
        End Try

    End Function

    '******************************************************************************
    '*　概　要:ＳＥＬＥＣＴ文を作成
    '*　備　考:[ind]1:件数取得  2:データ取得
    '******************************************************************************
    '  2019/11/01 T.Ono mod 監視改善2019　pstrkuracd_toを追加
    Public Function fncMakeSelect(ByVal ind As Integer,
                                  ByVal pstrKuracd As String,
                                  ByVal pstrKuracd_to As String,
                                  ByVal pstrJAcd As String,
                                  ByVal pstrGroupcd As String,
                                  ByVal pstrCentercd As String) As String

        Dim strSQL As New StringBuilder("")
        Dim strWHE As New StringBuilder("")

        '監視センターコード
        Dim i As Integer
        Dim arrTemp() As String
        Dim strCenter As String = ""
        arrTemp = pstrCentercd.Split(Convert.ToChar(","))
        For i = 0 To arrTemp.Length - 1
            If strCenter.Length > 0 Then
                strCenter = strCenter & ","
            End If
            strCenter = strCenter & "'" & arrTemp(i) & "'"
        Next

        If ind = 1 Then

        Else
            '----------------
            ' 2:データ取得
            '----------------
            '紐付けあり
            strSQL.Append("WITH Z AS  ")
            strSQL.Append("(SELECT X.KURACD, X.GROUPCD, Y.CLI_CD, Y.CLI_NAME ")
            strSQL.Append(" FROM M09_JAGROUP X ")
            strSQL.Append("	,CLIMAS Y ")
            strSQL.Append(" WHERE X.KBN = '002' ")
            If pstrCentercd.Trim.Length > 0 Then
                strSQL.Append(" AND Y.KANSI_CODE IN (" & strCenter & ") ")
            End If
            If pstrKuracd.Trim.Length > 0 Then
                '2049/11/01 T.Ono mod 監視改善2019
                'strSQL.Append(" AND Y.CLI_CD = :KURACD ")
                strSQL.Append(" AND Y.CLI_CD >= :KURACD ")
                strSQL.Append(" AND Y.CLI_CD <= :KURACD_TO ")
            End If
            If pstrJAcd.Trim.Length > 0 Then
                strSQL.Append(" AND X.ACBCD LIKE :JACD ")
            End If
            If pstrGroupcd.Trim.Length > 0 Then
                strSQL.Append(" AND X.GROUPCD = :GROUPCD ")
            End If
            strSQL.Append(" AND X.KURACD = Y.CLI_CD ")
            If pstrKuracd.Trim.Length = 0 Then 'ｸﾗｲｱﾝﾄを跨ぐグループがあるため、2重出力されないようにする
                strSQL.Append(" AND X.KURACD = (SELECT MIN(W.KURACD) ")
                strSQL.Append("                 FROM M09_JAGROUP W ")
                strSQL.Append("                 WHERE X.GROUPCD = W.GROUPCD) ")
            End If
            strSQL.Append(" GROUP BY KURACD, GROUPCD, CLI_CD, CLI_NAME ")
            strSQL.Append(" ORDER BY KURACD, GROUPCD ")
            strSQL.Append(") ")
            strSQL.Append("SELECT ")
            strSQL.Append("  A.KBN ")
            strSQL.Append("	,A.GROUPCD AS SORT ")
            strSQL.Append("	,'' AS KURACD ")
            'strSQL.Append("	,A.GROUPCD ")
            strSQL.Append("	,DECODE(A.TANCD, '01', A.GROUPCD, '') AS GROUPCD ")
            strSQL.Append("	,A.GROUPNM ")
            strSQL.Append("	,A.TANCD ")
            strSQL.Append("	,A.TANNM ")
            strSQL.Append("	,A.RENTEL1 ")
            strSQL.Append("	,A.RENTEL2 ")
            strSQL.Append("	,A.RENTEL3 ")
            strSQL.Append("	,A.FAXNO ")
            strSQL.Append("	,A.BIKO ")
            strSQL.Append("	,A.SPOT_MAIL ")
            strSQL.Append("	,A.MAIL_PASS ")
            strSQL.Append("	,A.AUTO_FAXNM ")
            strSQL.Append("	,A.AUTO_MAIL ")
            strSQL.Append("	,A.AUTO_MAIL_PASS ")
            strSQL.Append("	,A.AUTO_FAXNO ")
            strSQL.Append("	,A.AUTO_KBN ")
            strSQL.Append("	,A.AUTO_ZERO_FLG ")
            strSQL.Append("	,A.GUIDELINE ")
            strSQL.Append("	,A.FAXKBN ")
            strSQL.Append("	,A.FAXKURAKBN ")
            strSQL.Append("	,A.INS_DATE ")
            strSQL.Append("	,A.INS_USER ")
            strSQL.Append("	,A.UPD_DATE ")
            strSQL.Append("	,A.UPD_USER ")
            strSQL.Append("	,Z.CLI_CD ")
            strSQL.Append("	,Z.CLI_NAME ")
            strSQL.Append("FROM M11_JAHOKOKU A ")
            strSQL.Append("	,Z ")
            strSQL.Append("WHERE A.KBN = '2' ")
            strSQL.Append("AND A.GROUPCD = Z.GROUPCD ")

            If pstrKuracd.Trim.Length = 0 Then
                '紐付けなし
                strSQL.Append("UNION ALL ")
                strSQL.Append("SELECT ")
                strSQL.Append("  A.KBN ")
                strSQL.Append("	,A.GROUPCD AS SORT ")
                strSQL.Append("	,'' AS KURACD ")
                'strSQL.Append("	,A.GROUPCD ")
                strSQL.Append("	,DECODE(A.TANCD, '01', A.GROUPCD, '') AS GROUPCD ")
                strSQL.Append("	,A.GROUPNM ")
                strSQL.Append("	,A.TANCD ")
                strSQL.Append("	,A.TANNM ")
                strSQL.Append("	,A.RENTEL1 ")
                strSQL.Append("	,A.RENTEL2 ")
                strSQL.Append("	,A.RENTEL3 ")
                strSQL.Append("	,A.FAXNO ")
                strSQL.Append("	,A.BIKO ")
                strSQL.Append("	,A.SPOT_MAIL ")
                strSQL.Append("	,A.MAIL_PASS ")
                strSQL.Append("	,A.AUTO_FAXNM ")
                strSQL.Append("	,A.AUTO_MAIL ")
                strSQL.Append("	,A.AUTO_MAIL_PASS ")
                strSQL.Append("	,A.AUTO_FAXNO ")
                strSQL.Append("	,A.AUTO_KBN ")
                strSQL.Append("	,A.AUTO_ZERO_FLG ")
                strSQL.Append("	,A.GUIDELINE ")
                strSQL.Append("	,A.FAXKBN ")
                strSQL.Append("	,A.FAXKURAKBN ")
                strSQL.Append("	,A.INS_DATE ")
                strSQL.Append("	,A.INS_USER ")
                strSQL.Append("	,A.UPD_DATE ")
                strSQL.Append("	,A.UPD_USER ")
                strSQL.Append("	,'' AS CLI_CD ")
                strSQL.Append("	,'' AS CLI_NAME ")
                strSQL.Append("FROM M11_JAHOKOKU A ")
                strSQL.Append("WHERE A.KBN = '2' ")
                If pstrGroupcd.Trim.Length > 0 Then
                    strSQL.Append("AND A.GROUPCD = :GROUPCD ")
                End If
                strSQL.Append("AND NOT EXISTS(SElECT 'X' FROM M09_JAGROUP B WHERE A.GROUPCD = B.GROUPCD) ")
            End If

            If pstrJAcd.Trim.Length = 0 AndAlso pstrGroupcd.Trim.Length = 0 Then
                'クライアント登録 ｸﾗｲｱﾝﾄのみ指定したときに表示する。
                strSQL.Append("UNION ALL ")
                strSQL.Append("SELECT A.KBN ")
                strSQL.Append("	,A.GROUPCD AS SORT ")
                'strSQL.Append("	,A.GROUPCD AS KURACD ")
                strSQL.Append("	,DECODE(A.TANCD, '01', A.GROUPCD, '') AS KURACD ")
                strSQL.Append("	,'' AS GROUPCD ")
                strSQL.Append("	,A.GROUPNM ")
                strSQL.Append("	,A.TANCD ")
                strSQL.Append("	,A.TANNM ")
                strSQL.Append("	,A.RENTEL1 ")
                strSQL.Append("	,A.RENTEL2 ")
                strSQL.Append("	,A.RENTEL3 ")
                strSQL.Append("	,A.FAXNO ")
                strSQL.Append("	,A.BIKO ")
                strSQL.Append("	,A.SPOT_MAIL ")
                strSQL.Append("	,A.MAIL_PASS ")
                strSQL.Append("	,A.AUTO_FAXNM ")
                strSQL.Append("	,A.AUTO_MAIL ")
                strSQL.Append("	,A.AUTO_MAIL_PASS ")
                strSQL.Append("	,A.AUTO_FAXNO ")
                strSQL.Append("	,A.AUTO_KBN ")
                strSQL.Append("	,A.AUTO_ZERO_FLG ")
                strSQL.Append("	,A.GUIDELINE ")
                strSQL.Append("	,A.FAXKBN ")
                strSQL.Append("	,A.FAXKURAKBN ")
                strSQL.Append("	,A.INS_DATE ")
                strSQL.Append("	,A.INS_USER ")
                strSQL.Append("	,A.UPD_DATE ")
                strSQL.Append("	,A.UPD_USER ")
                strSQL.Append(" ,B.CLI_CD ")
                strSQL.Append("	,B.CLI_NAME ")
                strSQL.Append("FROM M11_JAHOKOKU A ")
                strSQL.Append("	,CLIMAS B ")
                strSQL.Append("WHERE A.KBN = '1' ")
                If pstrCentercd.Trim.Length > 0 Then
                    strSQL.Append("AND B.KANSI_CODE IN (" & strCenter & ") ")
                End If
                If pstrKuracd.Trim.Length > 0 Then
                    '2019/11/01 T.Ono mod 監視改善2019
                    'strSQL.Append("AND A.GROUPCD = :KURACD ")
                    strSQL.Append("AND A.GROUPCD >= :KURACD ")
                    strSQL.Append("AND A.GROUPCD <= :KURACD_TO ")
                End If
                strSQL.Append("AND A.GROUPCD = B.CLI_CD ")
            End If

            strSQL.Append("ORDER BY KBN, SORT, TANCD ")

        End If

        Return strSQL.ToString

    End Function


    Private Function fncSearchFile(ByVal GROUPCD As String) As String()

        Dim Res() As String = {"", ""}
        Dim searchPattern As String
        Dim folder As String
        Dim buf As String

        folder = ConfigurationSettings.AppSettings("JA_TAN_MST_PATH")

        searchPattern = GROUPCD.Trim & "_"

        Dim fs As String() = System.IO.Directory.GetFiles(folder, searchPattern & "*") 'folderにあるファイルを取得する
        If fs.Length > 0 Then
            buf = fs(0).Substring(fs(0).LastIndexOf("\") + 1)
            Res(0) = buf.Substring(searchPattern.Length)

        End If
        If fs.Length > 1 Then
            buf = fs(1).Substring(fs(1).LastIndexOf("\") + 1)
            Res(1) = buf.Substring(searchPattern.Length)
        End If


        Return Res
    End Function
    '**********************************************************
    ' 2012/06/28 ADD W.GANEKO
    'ログ吐き出し
    '戻り値：書き込んだファイルへのフルパス
    '**********************************************************
    Public Sub mlog(ByVal pstrString As String)
        Dim strFilnm As String = "testMSTAH" & System.DateTime.Today.ToString("yyyyMMdd")
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
