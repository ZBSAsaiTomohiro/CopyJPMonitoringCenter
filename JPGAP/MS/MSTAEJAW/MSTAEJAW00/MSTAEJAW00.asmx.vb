'***************************************************************************
'  ＪＡ担当者連絡先エクセル出力
'***************************************************************************
' 変更履歴
' 2010/03/29 T.Watabe 新規作成

Option Explicit On 
Option Strict On

Imports Common
Imports Common.DB

Imports System.Web.Services
Imports System.Text
Imports System.Text.RegularExpressions

<System.Web.Services.WebService(Namespace:="http://tempuri.org/MSTAEJAW00/Service1")> _
Public Class MSTAEJAW00
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
    <WebMethod()> Public Function mCheck( _
                                        ByVal pstrKuracd As String, _
                                        ByVal pstrJacd As String, _
                                        ByVal pdecPageMax As Decimal _
                                        ) As String
        Dim strSQL As New StringBuilder("")
        Dim cdb As New cdb
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
            cdb.pSQL = fncMakeSelect(2, _
                                     pstrKuracd, _
                                     pstrJacd)

            'パラメータセット
            If pstrKuracd.Length <> 0 Then
                cdb.pSQLParamStr("KURACD") = pstrKuracd
            End If
            If pstrJacd.Length > 0 Then cdb.pSQLParamStr("JACD") = pstrJacd

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
    <WebMethod()> Public Function mExcel( _
                                        ByVal pstrSessionID As String, _
                                        ByVal pstrKuracd As String, _
                                        ByVal pstrJacd As String, _
                                        ByVal pstrPgkbn As String, _
                                        ByVal pstrKuraNm As String, _
                                        ByVal pstrJaNm As String, _
                                        ByVal pdecPageMax As Decimal, _
                                        ByVal pstrCentcd As String _
                                        ) As String

        Dim strSQL As New StringBuilder("")
        Dim cdb As New cdb
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
            '帳票出力項目の取得用SQL文セット
            strSQL.Append(fncMakeSelect(2, _
                                     pstrKuracd, _
                                     pstrJacd))

            cdb.pSQL = strSQL.ToString 'SQLをセット
            cdb.mExecQuery()    'SQL実行
            ds = cdb.pResult    '結果をデータセットに格納

            'データが存在しない場合
            If ds.Tables(0).Rows.Count = 0 Then
                Return "DATA0"      'データが0件であることを示す文字列を返す
            ElseIf ds.Tables(0).Rows.Count > intGyoMax Then
                Return "DATAMAX"    'データが最大行数を超える事を示す文字列を返す
            End If

            ' 2013/07/25 T.Ono add
            For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                ReDim Preserve StrFileNM1(j)
                ReDim Preserve StrFileNM2(j)

                If Convert.ToString(ds.Tables(0).Rows(j).Item("TANCD")) = "01" Then

                    StrFileNMtmp = fncSearchFile(Convert.ToString(ds.Tables(0).Rows(j).Item("KURACD")), Convert.ToString(ds.Tables(0).Rows(j).Item("CODE")), _
                                  Convert.ToString(ds.Tables(0).Rows(j).Item("USER_CD_FROM")))

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
            ExcelC.pRepoID = "MSTAEJAW00"       '帳票ID
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
            ' 2013/07/05 T.Ono mod 列追加 ---------- START
            'Dim arrColNM1(24) As String
            'Dim arrColNM2(24) As String
            'Dim arrColID(24) As String
            'Dim arrWidth(24) As String '幅 項目1～24
            'Dim arrHeadBGColor(24) As String
            Dim arrColNM1(40) As String
            Dim arrColNM2(40) As String
            Dim arrColID(40) As String
            Dim arrWidth(40) As String '幅 項目1～28
            Dim arrHeadBGColor(40) As String
            ' 2013/07/05 T.Ono mod 列追加 ---------- END
            Dim zoku As String
            Dim buf As String

            Dim i As Integer
            If True Then
                ' 2013/07/05 T.Ono mod 列追加&タイトルを漢字に変更 ---------- START
                'arrColNM1(1) = "KBN"
                'arrColNM1(2) = "KURACD"
                'arrColNM1(3) = "CODE"
                'arrColNM1(4) = "TANCD"
                'arrColNM1(5) = "TANNM"
                'arrColNM1(6) = "RENTEL1"
                'arrColNM1(7) = "RENTEL2"
                'arrColNM1(8) = "FAXNO"
                'arrColNM1(9) = "DISP_NO"
                'arrColNM1(10) = "BIKO"
                'arrColNM1(11) = "ADD_DATE"
                'arrColNM1(12) = "EDT_DATE"
                'arrColNM1(13) = "TIME"
                'arrColNM1(14) = "HAN_CD"
                'arrColNM1(15) = "JAS_NAME"
                'arrColNM1(16) = "JAS_KANA"
                'arrColNM1(17) = "JA_CD"
                'arrColNM1(18) = "JA_NAME"
                'arrColNM1(19) = "JA_KANA"
                'arrColNM1(20) = "TEL_REN1"
                'arrColNM1(21) = "TEL_FAX1"
                'arrColNM1(22) = "HAN_KETA"
                'arrColNM1(23) = "JA_KETA"
                'arrColNM1(24) = "CLI_NAME"
                arrColNM1(1) = "区分"
                arrColNM1(2) = "ｸﾗｲｱﾝﾄﾞｺｰﾄﾞ"
                arrColNM1(3) = "JA支所ｺｰﾄﾞ"
                arrColNM1(4) = "お客様ｺｰﾄﾞ(FROM)"
                arrColNM1(5) = "お客様ｺｰﾄﾞ(TO)"
                arrColNM1(6) = "ｺｰﾄﾞ"
                arrColNM1(7) = "担当者名漢字"
                arrColNM1(8) = "電話番号１"
                arrColNM1(9) = "電話番号２"
                arrColNM1(10) = "電話番号３"
                arrColNM1(11) = "ｽﾎﾟｯﾄFAX番号"
                '2013/12/06 T.Ono mod 監視改善2013
                'arrColNM1(12) = "備考"
                arrColNM1(12) = "記事"
                arrColNM1(13) = "ｽﾎﾟｯﾄFAX送信先ﾒｰﾙｱﾄﾞﾚｽ"
                arrColNM1(14) = "ｽﾎﾟｯﾄFAX添付ﾌｧｲﾙﾊﾟｽﾜｰﾄﾞ"
                arrColNM1(15) = "自動FAX送信名"
                arrColNM1(16) = "自動FAX送信先ﾒｰﾙｱﾄﾞﾚｽ"
                arrColNM1(17) = "自動FAX添付ﾌｧｲﾙﾊﾟｽﾜｰﾄﾞ"
                arrColNM1(18) = "自動FAX番号"
                arrColNM1(19) = "自動送信区分"
                arrColNM1(20) = "ゼロ件送信フラグ"
                '2013/12/06 T.Ono mod 監視改善2013
                'arrColNM1(21) = "FAX不要初期値(JA)"
                'arrColNM1(22) = "FAX不要初期値(ｸﾗｲｱﾝﾄ)"
                arrColNM1(21) = "報告要・不要初期値(JA)"
                arrColNM1(22) = "報告要・不要初期値(ｸﾗｲｱﾝﾄ)"
                arrColNM1(23) = "注意事項"
                arrColNM1(24) = "ﾌｧｲﾙ登録１"
                arrColNM1(25) = "ﾌｧｲﾙ登録２"
                arrColNM1(26) = "表示順"
                arrColNM1(27) = "作成日"
                arrColNM1(28) = "更新日"
                arrColNM1(29) = "更新時間"
                arrColNM1(30) = "JA支所ｺｰﾄﾞ"
                arrColNM1(31) = "JA支所名"
                arrColNM1(32) = "JA支所名ｶﾅ"
                arrColNM1(33) = "JAｺｰﾄﾞ"
                arrColNM1(34) = "JA名"
                arrColNM1(35) = "JA名ｶﾅ"
                arrColNM1(36) = "電話番号"
                arrColNM1(37) = "FAX番号"
                arrColNM1(38) = "JA桁数(HAN_KETA)"
                arrColNM1(39) = "JA支所桁数(JA_KETA)"
                arrColNM1(40) = "ｸﾗｲｱﾝﾄ名"
                ' 2013/07/05 T.Ono mod 列追加 ---------- END
            End If
            If True Then
                ' 2013/07/05 T.Ono mod 列追加 ---------- START
                'arrColID(1) = "KBN"
                'arrColID(2) = "KURACD"
                'arrColID(3) = "CODE"
                'arrColID(4) = "TANCD"
                'arrColID(5) = "TANNM"
                'arrColID(6) = "RENTEL1"
                'arrColID(7) = "RENTEL2"
                'arrColID(8) = "FAXNO"
                'arrColID(9) = "DISP_NO"
                'arrColID(10) = "BIKO"
                'arrColID(11) = "ADD_DATE"
                'arrColID(12) = "EDT_DATE"
                'arrColID(13) = "TIME"
                'arrColID(14) = "HAN_CD"
                'arrColID(15) = "JAS_NAME"
                'arrColID(16) = "JAS_KANA"
                'arrColID(17) = "JA_CD"
                'arrColID(18) = "JA_NAME"
                'arrColID(19) = "JA_KANA"
                'arrColID(20) = "TEL_REN1"
                'arrColID(21) = "TEL_FAX1"
                'arrColID(22) = "HAN_KETA"
                'arrColID(23) = "JA_KETA"
                'arrColID(24) = "CLI_NAME"
                arrColID(1) = "KBN"
                arrColID(2) = "KURACD"
                arrColID(3) = "CODE"
                arrColID(4) = "USER_CD_FROM"
                arrColID(5) = "USER_CD_TO"
                arrColID(6) = "TANCD"
                arrColID(7) = "TANNM"
                arrColID(8) = "RENTEL1"
                arrColID(9) = "RENTEL2"
                arrColID(10) = "RENTEL3"
                arrColID(11) = "FAXNO"
                arrColID(12) = "BIKO"
                arrColID(13) = "SPOT_MAIL"
                arrColID(14) = "MAIL_PASS"
                arrColID(15) = "AUTO_FAXNM"
                arrColID(16) = "AUTO_MAIL"
                arrColID(17) = "AUTO_MAIL_PASS"
                arrColID(18) = "AUTO_FAXNO"
                arrColID(19) = "AUTO_KBN"
                arrColID(20) = "AUTO_ZERO_FLG"
                arrColID(21) = "FAXKBN"
                arrColID(22) = "FAXKURAKBN"
                arrColID(23) = "GUIDELINE"
                arrColID(24) = "file1"
                arrColID(25) = "file2"
                arrColID(26) = "DISP_NO"
                arrColID(27) = "ADD_DATE"
                arrColID(28) = "EDT_DATE"
                arrColID(29) = "TIME"
                arrColID(30) = "HAN_CD"
                arrColID(31) = "JAS_NAME"
                arrColID(32) = "JAS_KANA"
                arrColID(33) = "JA_CD"
                arrColID(34) = "JA_NAME"
                arrColID(35) = "JA_KANA"
                arrColID(36) = "TEL_REN1"
                arrColID(37) = "TEL_FAX1"
                arrColID(38) = "HAN_KETA"
                arrColID(39) = "JA_KETA"
                arrColID(40) = "CLI_NAME"
                ' 2013/07/05 T.Ono mod 列追加 ---------- END
            End If
            'If True Then '幅
            '    arrWidth(1) = "31"
            '    arrWidth(2) = "66"
            '    arrWidth(3) = "66"
            '    arrWidth(4) = "66"
            '    arrWidth(5) = "66"
            '    arrWidth(6) = "66"
            '    arrWidth(7) = "66"
            '    arrWidth(8) = "66"
            '    arrWidth(9) = "66"
            '    arrWidth(10) = "66"
            '    arrWidth(11) = "66"
            '    arrWidth(12) = "66"
            '    arrWidth(13) = "66"
            '    arrWidth(14) = "66"
            '    arrWidth(15) = "66"
            '    arrWidth(16) = "66"
            '    arrWidth(17) = "66"
            '    arrWidth(18) = "66"
            '    arrWidth(19) = "66"
            '    arrWidth(20) = "66"
            '    arrWidth(21) = "66"
            '    arrWidth(22) = "66"
            '    arrWidth(23) = "66"
            'End If
            If True Then
                'arrHeadBGColor(1) = "background:#99CCFF;" '青
                'arrHeadBGColor(2) = "background:#99CCFF;" '青
                'arrHeadBGColor(3) = "background:#99CCFF;" '青
                'arrHeadBGColor(4) = "background:#99CCFF;" '青
                'arrHeadBGColor(5) = "background:#99CCFF;" '青
                'arrHeadBGColor(6) = "background:#99CCFF;" '青
                'arrHeadBGColor(7) = "background:#99CCFF;" '青
                'arrHeadBGColor(8) = "background:#99CCFF;" '青
                'arrHeadBGColor(9) = "background:#99CCFF;" '青
                'arrHeadBGColor(10) = "background:#99CCFF;" '青
                'arrHeadBGColor(11) = "background:#99CCFF;" '青
                'arrHeadBGColor(12) = "background:#99CCFF;" '青
                'arrHeadBGColor(13) = "background:#99CCFF;" '青
                'arrHeadBGColor(14) = "background:#CCFFCC;" '黄緑
                'arrHeadBGColor(15) = "background:#CCFFCC;" '黄緑
                'arrHeadBGColor(16) = "background:#CCFFCC;" '黄緑
                'arrHeadBGColor(17) = "background:#CCFFCC;" '黄緑
                'arrHeadBGColor(18) = "background:#CCFFCC;" '黄緑
                'arrHeadBGColor(19) = "background:#CCFFCC;" '黄緑
                'arrHeadBGColor(20) = "background:#CCFFCC;" '黄緑
                'arrHeadBGColor(21) = "background:#CCFFCC;" '黄緑
                'arrHeadBGColor(22) = "background:#CCFFCC;" '黄緑
                'arrHeadBGColor(23) = "background:#CCFFCC;" '黄緑
                'arrHeadBGColor(24) = "background:#CCFFFF;" '水色
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
                arrHeadBGColor(29) = "background:#99CCFF;" '青
                arrHeadBGColor(30) = "background:#CCFFCC;" '黄緑
                arrHeadBGColor(31) = "background:#CCFFCC;" '黄緑
                arrHeadBGColor(32) = "background:#CCFFCC;" '黄緑
                arrHeadBGColor(33) = "background:#CCFFCC;" '黄緑
                arrHeadBGColor(34) = "background:#CCFFCC;" '黄緑
                arrHeadBGColor(35) = "background:#CCFFCC;" '黄緑
                arrHeadBGColor(36) = "background:#CCFFCC;" '黄緑
                arrHeadBGColor(37) = "background:#CCFFCC;" '黄緑
                arrHeadBGColor(38) = "background:#CCFFCC;" '黄緑
                arrHeadBGColor(39) = "background:#CCFFCC;" '黄緑
                arrHeadBGColor(40) = "background:#CCFFFF;" '水色
            End If


            '■ヘッダ行1
            ' 2013/07/05 T.Ono mod
            'For i = 1 To 24
            For i = 1 To 40
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
                ' 2013/07/05 T.Ono mod
                'For i = 1 To 24
                For i = 1 To 40
                    buf = ""
                    tmp = ""
                    zoku = ""
                    ' 登録ﾌｧｲﾙ名を入れる 2013/07/25 T.Ono add
                    'buf = Convert.ToString(dr.Item(arrColID(i)))
                    If i = 24 Then
                        buf = Convert.ToString(StrFileNM1(iCnt))  '登録ﾌｧｲﾙ1
                    ElseIf i = 25 Then
                        buf = Convert.ToString(StrFileNM2(iCnt)) '登録ﾌｧｲﾙ2
                    Else
                        buf = Convert.ToString(dr.Item(arrColID(i)))
                    End If
                    'tmp = "width:" & arrWidth(i) & "px;"
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
            '2014/01/16 T.Ono mod 監視改善2013 Excelを直接開くように変更、ファイルフルパスを返す
            ''圧縮実行
            'compressC.mCompress()
            ''圧縮したファイルをBase64エンコードして戻す
            ''.xls形式に変更 2013/12/06 T.Ono mod 監視改善2013
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
    Public Function fncMakeSelect(ByVal ind As Integer, _
                                  ByVal pstrKuracd As String, _
                                  ByVal pstrJacd As String) As String

        Dim strSQL As New StringBuilder("")
        Dim strWHE As New StringBuilder("")

        '----------------
        ' SQL条件作成(共通)
        '----------------
        If Len(pstrKuracd) > 0 Then 'クライアントコード
            strWHE.Append("    AND A.KURACD = '" & pstrKuracd & "' ")
        End If
        If Len(pstrJacd) > 0 Then 'ＪＡコード
            '2010/05/16 NEC ou Upd Str
            'strWHE.Append("    AND A.CODE = '" & pstrJacd & "' ")
            strWHE.Append("    AND B.JA_CD = '" & pstrJacd & "' ")
            '2010/05/16 NEC ou Upd End
        End If

        If ind = 1 Then
            '----------------
            ' 1:件数取得
            '----------------
            strSQL.Append("SELECT COUNT(*) FROM M05_TANTO A ")
            strSQL.Append("    WHERE  ")
            strSQL.Append("        1=1 ")
            strSQL.Append("    AND A.KBN = '3'  ")
            strSQL.Append(strWHE) '条件追加
        Else
            '----------------
            ' 2:データ取得
            '----------------
            '/* SQL3監視HONからＪＡ担当者データ一覧を抜き出し.SQL */
            strSQL.Append("SELECT ")
            strSQL.Append("    A.KBN      , ")
            strSQL.Append("    A.KURACD   , ")
            'strSQL.Append("    A.CODE     , ") '2013/07/31 T.Ono add
            strSQL.Append("    DECODE(A.CODE, 'XXXX' ,'', A.CODE) AS CODE     , ")
            strSQL.Append("    LPAD(A.TANCD,2,'0') AS TANCD, ")
            strSQL.Append("    A.TANNM    , ")
            strSQL.Append("    A.RENTEL1  , ")
            strSQL.Append("    A.RENTEL2  , ")
            strSQL.Append("    A.FAXNO    , ")
            strSQL.Append("    A.DISP_NO  , ")
            strSQL.Append("    A.BIKO     , ")
            strSQL.Append("    A.ADD_DATE , ")
            strSQL.Append("    A.EDT_DATE , ")
            strSQL.Append("    A.TIME     , ")
            strSQL.Append("    B.HAN_CD,  ")
            strSQL.Append("    B.JAS_NAME,  ")
            strSQL.Append("    B.JAS_KANA,  ")
            strSQL.Append("    B.JA_CD,  ")
            strSQL.Append("    B.JA_NAME,  ")
            strSQL.Append("    B.JA_KANA,  ")
            strSQL.Append("    B.TEL_REN1,  ")
            strSQL.Append("    B.TEL_FAX1,  ")
            strSQL.Append("    B.HAN_KETA,  ")
            strSQL.Append("    B.JA_KETA, ")
            strSQL.Append("    C.CLI_NAME ")
            ' 2013/07/05 T.Ono add ---------- START
            strSQL.Append(" 　 , ")
            strSQL.Append(" 　 NULL AS USER_CD_FROM, ")
            strSQL.Append("    NULL AS USER_CD_TO, ")
            strSQL.Append("    A.RENTEL3, ")
            strSQL.Append("    A.AUTO_FAXNO, ")
            strSQL.Append("    A.SPOT_MAIL,      ")
            strSQL.Append("    A.MAIL_PASS,    ")
            strSQL.Append("    A.AUTO_FAXNM,     ")
            strSQL.Append("    A.AUTO_MAIL,     ")
            strSQL.Append("    A.AUTO_MAIL_PASS, ")
            strSQL.Append("    A.AUTO_FAXNO,     ")
            strSQL.Append("    A.AUTO_KBN,       ")
            strSQL.Append("    A.AUTO_ZERO_FLG, ")
            strSQL.Append("    A.FAXKURAKBN,     ")
            strSQL.Append("    A.FAXKBN,         ")
            strSQL.Append("    A.GUIDELINE,      ")
            strSQL.Append("    '01' AS NO, ")   'M05_TANTOと区別
            strSQL.Append("    DECODE(A.CODE,'XXXX','01','02') AS NO2 ")   'クライアントのみの登録を区別
            ' 2013/07/05 T.Ono add ---------- END
            strSQL.Append("FROM  ")
            strSQL.Append("    M05_TANTO A,  ")
            strSQL.Append("    HN2MAS B,  ")
            strSQL.Append("    CLIMAS C ")
            strSQL.Append("WHERE  ")
            strSQL.Append("        B.CLI_CD (+) = A.KURACD ")
            strSQL.Append("    AND B.HAN_CD (+) = A.CODE ")
            strSQL.Append("    AND C.CLI_CD (+) = A.KURACD ")
            strSQL.Append("    AND A.KBN = '3'  ")
            strSQL.Append(strWHE) '条件追加
            ' ▼▼▼ 2013/07/05 T.Ono mod 顧客単位登録機能追加 ▼▼▼
            ' M05_TANTO2からもデータを取得
            'strSQL.Append("ORDER BY  ")
            'strSQL.Append("    A.KURACD   , ")
            'strSQL.Append("    A.CODE     , ")
            'strSQL.Append("    LPAD(A.TANCD,2,'0') ")
            strSQL.Append("UNION ALL ")
            strSQL.Append("SELECT ")
            strSQL.Append("    A.KBN      , ")
            strSQL.Append("    A.KURACD   , ")
            strSQL.Append("    A.CODE     , ")
            strSQL.Append("    LPAD(A.TANCD,2,'0') AS TANCD, ")
            strSQL.Append("    A.TANNM    , ")
            strSQL.Append("    A.RENTEL1  , ")
            strSQL.Append("    A.RENTEL2  , ")
            strSQL.Append("    A.FAXNO    , ")
            strSQL.Append("    A.DISP_NO  , ")
            strSQL.Append("    A.BIKO     , ")
            strSQL.Append("    A.ADD_DATE , ")
            strSQL.Append("    A.EDT_DATE , ")
            strSQL.Append("    A.TIME     , ")
            strSQL.Append("    B.HAN_CD, ")
            strSQL.Append("    B.JAS_NAME, ")
            strSQL.Append("    B.JAS_KANA, ")
            strSQL.Append("    B.JA_CD, ")
            strSQL.Append("    B.JA_NAME, ")
            strSQL.Append("    B.JA_KANA, ")
            strSQL.Append("    B.TEL_REN1, ")
            strSQL.Append("    B.TEL_FAX1, ")
            strSQL.Append("    B.HAN_KETA, ")
            strSQL.Append("    B.JA_KETA, ")
            strSQL.Append("    C.CLI_NAME, ")
            strSQL.Append(" 　 A.USER_CD_FROM, ")
            strSQL.Append("    A.USER_CD_TO, ")
            strSQL.Append("    A.RENTEL3, ")
            strSQL.Append("    A.AUTO_FAXNO, ")
            strSQL.Append("    A.SPOT_MAIL,      ")
            strSQL.Append("    A.MAIL_PASS,    ")
            strSQL.Append("    A.AUTO_FAXNM,     ")
            strSQL.Append("    A.AUTO_MAIL,     ")
            strSQL.Append("    A.AUTO_MAIL_PASS, ")
            strSQL.Append("    A.AUTO_FAXNO,     ")
            strSQL.Append("    A.AUTO_KBN,       ")
            strSQL.Append("    A.AUTO_ZERO_FLG, ")
            strSQL.Append("    A.FAXKURAKBN,     ")
            strSQL.Append("    A.FAXKBN,         ")
            strSQL.Append("    A.GUIDELINE,      ")
            strSQL.Append("    '02' AS NO, ")   'M05_TANTOと区別
            strSQL.Append("    '02' AS NO2 ")   'クライアントのみの登録を区別
            strSQL.Append("FROM ")
            strSQL.Append("    M05_TANTO2 A, ")
            strSQL.Append("    HN2MAS B, ")
            strSQL.Append("    CLIMAS C ")
            strSQL.Append("WHERE ")
            strSQL.Append("        B.CLI_CD (+) = A.KURACD ")
            strSQL.Append("    AND B.HAN_CD (+) = A.CODE ")
            strSQL.Append("    AND C.CLI_CD (+) = A.KURACD ")
            strSQL.Append("    AND A.KBN = '3'  ")
            strSQL.Append(strWHE) '条件追加
            strSQL.Append("ORDER BY ")
            strSQL.Append("    KBN, ")
            strSQL.Append("    NO2, ")
            strSQL.Append("    KURACD, ")
            strSQL.Append("    CODE, ")
            strSQL.Append("    NO, ")
            strSQL.Append("    USER_CD_TO, ")
            strSQL.Append("    USER_CD_FROM, ")
            strSQL.Append("    TANCD ")
            ' ▲▲▲ 2013/07/05 T.Ono mod 顧客単位登録機能追加 ▲▲▲
        End If

        Return strSQL.ToString

    End Function


    Private Function fncSearchFile(ByVal KURACD As String, ByVal CODE As String, ByVal USER_CD_FROM As String) As String()

        Dim Res() As String = {"", ""}
        Dim searchPattern As String
        Dim folder As String
        Dim buf As String

        folder = ConfigurationSettings.AppSettings("JA_TAN_MST_PATH")

        If Trim(USER_CD_FROM) <> "" Then
            searchPattern = KURACD.Trim & "_" & CODE.Trim & "_" & USER_CD_FROM.Trim & "_"
        Else
            searchPattern = KURACD.Trim & "_" & CODE.Trim & "_" & "X" & "_"
        End If

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

End Class
