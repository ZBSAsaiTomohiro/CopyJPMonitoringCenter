'***********************************************
'対応入力　ＪＡＦＡＸ作成
'***********************************************
' 変更履歴
' 2010/03/24 T.Watabe 監視ｾﾝﾀｰFAX番号をＦＡＸ紙上に印字するように変更
' 2010/08/30 T.Watabe 用紙倍率を98%へ変更。FAX受信側で２ページになってしまう現象を回避するように変更。
' 2010/09/13 T.Watabe 変更を戻す（用紙倍率を98%へ変更。FAX受信側で２ページになってしまう現象を回避するように変更。）
' 2011/05/30 T.Watabe セッションの作成にGUIDからランダムな文字列を使用するように変更
' 2011/08/24 T.Watabe FAXが一枚に収まらない問題の対応(電話連絡内容を纏める)
' 2012/03/26 W.GANEKO FAX＆メール又はメール一斉送信機能追加

Option Explicit On 
Option Strict On

Imports Common
Imports Common.DB

Imports System.Text
Imports System.Web.Services
Imports System.Configuration    '//Configuration
Imports System.IO

<System.Web.Services.WebService(Namespace:="http://tempuri.org/KEFAXJAW00/KEFAXJAW00")> _
Public Class KEFAXJAW00
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

    'Excelクラス
    Dim ExcelC As New CExcel

    Private gstrPATH As String      '//フォルダパス
    '--- ↓2005/05/10 DEL Falcon↓ ---
    'Private gstrPGCD As String      '//プログラムID     
    '--- ↑2005/05/10 DEL Falcon↑ ---
    '--- ↓2005/05/10 MOD Falcon↓ ---
    Private gstrPGCD As String = "KEFAXJAW00"   '//プログラムID     
    '--- ↑2005/05/10 MOD Falcon↑ ---
    Private gstrRecText() As String

    '--- 2005/09/22 UPDATE START ---
    Private gstrPoint As String = "~"
    'Private gstrPoint As String = ">"
    '--- 2005/09/22 UPDATE START ---

    '******************************************************************************
    '*　概　要：
    '*　備　考：
    '******************************************************************************
    '　DATA0：対象データがありません
    '  2014/12/24 T.Ono mod 2014改善開発 No4 引数にpstrBtnKBN追加 1:電話FAXメール発信押下　2:プレビュー押下
    <WebMethod()> Public Function mExcel( _
                                            ByVal pstrSessionID As String, _
                                            ByVal pstrTEXT_NAME As String, _
                                            ByVal pstrSEND_NAME As String, _
                                            ByVal pstrSEND_POST As String, _
                                            ByVal pstrSEND_ADDS As String, _
                                            ByVal pstrSEND_FAX As String, _
                                            ByVal pstrSEND_TEL As String, _
                                            ByVal pstrBtnKBN As String _
                                            ) As String

        Dim strSQL As New StringBuilder("")
        Dim cdb As New CDB
        Dim ds As New DataSet
        Dim dr As DataRow

        Dim UtilFucC As New CUtilFuc

        '改行制御を行う
        'Dim intGYOSU As Integer = 47 ' 2008/02/29 T.Watabe edit
        Dim intGYOSU As Integer = 53
        '日付変換クラス
        Dim DateFncC As New CDateFnc
        'ファイルをBase64にエンコードするクラス
        Dim FileToStrC As New CFileStr

        Dim arrFaxData() As String
        Dim strTaiouTextName As String
        Dim strFaxData As String
        Dim strTaiouText As String

        ReDim gstrRecText(0)

        '接続OPEN----------------------------------------
        Try
            cdb.mOpen()
        Catch ex As Exception
            Return ex.ToString
        Finally

        End Try

        Dim strRec As String = "OK"
        Try
            '--- ↓2005/05/10 DEL Falcon↓ ---
            'gstrPGCD = "KEFAXJAW00"
            '--- ↑2005/05/10 DEL Falcon↑ ---
            gstrPATH = ConfigurationSettings.AppSettings("TEXTPATH") & "\00\"
            'gstrPATH = ConfigurationSettings.AppSettings("TEXTPATH") & "00"
            '対応入力データテキスト
            strTaiouTextName = gstrPGCD & "\" & pstrTEXT_NAME

            '//------------------------------------------------------------
            '対応入力データファイルを読み込む
            strRec = fncTaiouRecv(strTaiouTextName, strTaiouText)
            If strRec <> "OK" Then
                Return strRec
            End If

            '//">"区切りデータを取得　配列に格納
            If strTaiouText.Length <> 0 Then
                arrFaxData = strTaiouText.Split(Convert.ToChar(gstrPoint))
            End If

            '//データセット ----------------------------------
            Dim strSYONO As String = arrFaxData(0)                          '処理番号
            Dim strFAXTITLE As String = arrFaxData(1)                       'ＦＡＸタイトル
            Dim strACBCD As String = arrFaxData(2)                          'ＪＡ支所コード
            Dim strKURACD As String = arrFaxData(3)                         'クライアントコード
            Dim strKANSCD As String = arrFaxData(4)                         '監視センターコード
            Dim strJUSYONM As String = arrFaxData(5)                        'お客様氏名
            Dim strUSER_CD As String = arrFaxData(6)                        'お客様コード
            Dim strJUTEL1 As String = arrFaxData(7)                         '自宅電話市外
            Dim strJUTEL2 As String = arrFaxData(8)                         '自宅電話市内
            Dim strRENTEL As String = arrFaxData(9)                         '連絡電話番号
            Dim strADDR As String = arrFaxData(10)                          '住所
            Dim strHATYMD As String = arrFaxData(11)                        '発生日
            Dim strHATTIME As String = arrFaxData(12)                       '発生時刻
            Dim strKENSIN As String = arrFaxData(13)                        'メータ値
            Dim strRYURYO As String = arrFaxData(14)                        '流量区分
            Dim strMETASYU As String = arrFaxData(15)                       'メータ種別
            Dim strKMNM1 As String = arrFaxData(16)                         '警報メッセージ１
            Dim strKMNM2 As String = arrFaxData(17)                         '警報メッセージ２
            Dim strKMNM3 As String = arrFaxData(18)                         '警報メッセージ３
            Dim strKMNM4 As String = arrFaxData(19)                         '警報メッセージ４
            Dim strKMNM5 As String = arrFaxData(20)                         '警報メッセージ５
            Dim strKMNM6 As String = arrFaxData(21)                         '警報メッセージ６
            Dim strTAIOKBN As String = fncGET_PULLNM("09", arrFaxData(22))  '対応区分
            Dim strTKTANCD As String = arrFaxData(23)                       '監視センター担当者
            Dim strSYOYMD As String = arrFaxData(24)                        '対応完了日
            Dim strSYOTIME As String = arrFaxData(25)                       '対応完了時刻
            Dim strSIJIYMD As String = arrFaxData(26)                       '出動指示日
            Dim strSIJITIME As String = arrFaxData(27)                      '出動指示時刻
            Dim strTAITCD As String = fncGET_PULLNM("12", arrFaxData(28))   '連絡相手
            Dim strTELRCD As String = fncGET_PULLNM("15", arrFaxData(29))   '電話連絡内容
            Dim strFUK_MEMO As String = arrFaxData(30)                      '復帰操作メモ
            Dim strTEL_MEMO1 As String = arrFaxData(31)                     '電話メモ１
            Dim strTEL_MEMO2 As String = arrFaxData(32)                     '電話メモ２
            '2020/11/01 T.Ono mod 2020監視改善 Start
            'Dim strTKIGCD As String = fncGET_PULLNM("16", arrFaxData(33))   '原因器具
            'Dim strTSADCD As String = fncGET_PULLNM("17", arrFaxData(34))   '作動原因
            'Dim strFAX_REN As String = arrFaxData(35)                       '依頼内容
            'Dim strMITOKBN As String = arrFaxData(36)                       '未登録ＦＬＧ
            Dim strTEL_MEMO4 As String = arrFaxData(33)                     '電話メモ４
            Dim strTEL_MEMO5 As String = arrFaxData(34)                     '電話メモ５
            Dim strTEL_MEMO6 As String = arrFaxData(35)                     '電話メモ６
            Dim strTKIGCD As String = fncGET_PULLNM("16", arrFaxData(36))   '原因器具
            Dim strTSADCD As String = fncGET_PULLNM("17", arrFaxData(37))   '作動原因
            Dim strFAX_REN As String = arrFaxData(38)                       '依頼内容
            Dim strMITOKBN As String = arrFaxData(39)                       '未登録ＦＬＧ
            '2020/11/01 T.Ono mod 2020監視改善 End
            '//------------------------------------------------
            '2006/06/09 NEC ADD START
            Dim strMAP_CD As String                                         '地図番号
            Dim strUSER_FLG As String                                       'お客様状態
            '2006/06/09 NEC ADD END
            '県コードをセット
            If strKURACD.Length <> 0 Then
                ExcelC.pKencd = strKURACD.Substring(1, 2)
            Else
                '--- ↓2005/05/12 DEL Falcon↓ ---
                'ExcelC.pKencd = "99"
                '--- ↑2005/05/12 DEL Falcon↑ ---
                '--- ↓2005/05/12 MOD Falcon↓ ---
                ExcelC.pKencd = "00"
                '--- ↑2005/05/12 MOD Falcon↑ ---
            End If
            'セッションID
            ExcelC.pSessionID = pstrSessionID

            '帳票ID
            ExcelC.pRepoID = "KEFAXJAX00"

            '帳票縦
            ExcelC.pLandScape = False

            'ファイルオープン
            ExcelC.mOpen()

            'タイトル
            ExcelC.pTitle = strFAXTITLE

            '作成日
            ExcelC.pDate = DateFncC.mGet(Now.ToString("yyyyMMdd"))

            '縮小拡大率
            'ExcelC.pScale = 100 ' 2010/08/30 T.Watabe edit
            'ExcelC.pScale = 98 ' 2010/09/13 T.Watabe edit
            ExcelC.pScale = 100

            '表示倍率80%へ       '2016/12/13 H.Mori add 2016改善開発 No6-2 
            ExcelC.pZoom = 80

            'ページ縦数を1へ（1ページに収める)       '2022/07/20 Y.Arakaki add 実験修正
            'ExcelC.pPageCnt = 1 'ディスプレイ設定で何とかする為、一度コメントアウト。再使用時はコメント解除。

            '追加実験 20220720_Y.arakaki
            'ExcelC.pFitPaper = True '縦横1ページON 通常はfalseで縮小拡大率を参照。'ディスプレイ設定で何とかする為、一度コメントアウト。再使用時はコメント解除。

            '余白
            ExcelC.pMarginTop = 1.8D
            'ExcelC.pMarginBottom = 1.5D ' 2008/02/29 T.Watabe edit
            ExcelC.pMarginBottom = 0D
            ExcelC.pMarginLeft = 1.2D
            ExcelC.pMarginRight = 1.5D
            ExcelC.pMarginHeader = 1.3D
            'ExcelC.pMarginFooter = 1.3D ' 2008/02/29 T.Watabe edit
            ExcelC.pMarginFooter = 0D

            'ヘッダ項目をセット。（1ページあたり行数、出力行数、先頭行から何行目までが行タイトルか）
            ExcelC.mHeader(intGYOSU, intGYOSU, 1)

            '各列の幅をピクセルでセット。枠線も消す。
            '1行目
            'ExcelC.pCellStyle(1) = "width:40px;border-style:none"  '-- 2005/05/21 MOD Falcon ---
            ExcelC.pCellStyle(1) = "width:32px;border-style:none"
            ExcelC.pCellStyle(2) = "width:103px;border-style:none"
            ExcelC.pCellStyle(3) = "width:72px;border-style:none"
            ExcelC.pCellStyle(4) = "width:72px;border-style:none"
            ExcelC.pCellStyle(5) = "width:72px;border-style:none"
            ExcelC.pCellStyle(6) = "width:72px;border-style:none"
            ExcelC.pCellStyle(7) = "width:72px;border-style:none"
            ExcelC.pCellStyle(8) = "width:72px;border-style:none"
            ExcelC.pCellStyle(9) = "width:72px;border-style:none"
            ExcelC.pCellStyle(10) = "width:80px;border-style:none"
            ExcelC.pCellVal(1) = ""
            ExcelC.pCellVal(2) = ""
            ExcelC.pCellVal(3) = ""
            ExcelC.pCellVal(4) = ""
            ExcelC.pCellVal(5) = ""
            ExcelC.pCellVal(6) = ""
            ExcelC.pCellVal(7) = ""
            ExcelC.pCellVal(8) = ""
            ExcelC.pCellVal(9) = ""
            ExcelC.pCellVal(10) = ""
            ExcelC.mWriteLine("")   '行をファイルに書き込む

            '--------------------------------------------------
            'データの取得
            '--------------------------------------------------
            strSQL.Append("SELECT ")
            strSQL.Append("JA.JA_NAME, ")
            strSQL.Append("JA.JAS_NAME, ")
            strSQL.Append("CL.KEN_NAME, ")
            strSQL.Append("HA.NAME AS HAISO_NAME, ")
            strSQL.Append("KA.KANSI_NAME, ")
            '2006/06/14 NEC UPDATE START
            strSQL.Append("KA.TEL, ")
            '2006/06/14 NEC UPDATE END
            strSQL.Append("KA.KINKYU_TEL, ") ' 2010/03/24 T.Watabe add 監視ｾﾝﾀｰFAX番号
            strSQL.Append("TA.TANNM ")
            strSQL.Append("FROM HN2MAS JA, ")
            strSQL.Append("     CLIMAS CL, ")
            strSQL.Append("     HAIMAS HA, ")
            strSQL.Append("     KANSIMAS KA, ")
            strSQL.Append("     M05_TANTO TA ")
            strSQL.Append("WHERE CL.CLI_CD = :KURACD ")
            strSQL.Append("  AND CL.CLI_CD = JA.CLI_CD(+) ")
            strSQL.Append("  AND :ACBCD = JA.HAN_CD(+) ")
            strSQL.Append("  AND SUBSTR(JA.CLI_CD,2,2) = HA.KEN_CD(+) ")
            strSQL.Append("  AND JA.HAISO_CD = HA.HAISO_CD(+) ")
            strSQL.Append("  AND CL.KANSI_CODE = KA.KANSI_CD(+) ")
            strSQL.Append("  AND '1' = TA.KBN(+) ")
            '--- ↓2005/07/19 ADD Falcon↓ ---
            strSQL.Append("  AND 'ZZZZ' = TA.KURACD(+) ")
            '--- ↑2005/07/19 ADD Falcon↑ ---
            strSQL.Append("  AND CL.KANSI_CODE = TA.CODE(+) ")
            strSQL.Append("  AND :TKTANCD = TA.TANCD(+) ")


            '//SQLセット
            cdb.pSQL = strSQL.ToString
            '//パラメータセット
            cdb.pSQLParamStr("KURACD") = strKURACD
            cdb.pSQLParamStr("ACBCD") = strACBCD
            cdb.pSQLParamStr("TKTANCD") = strTKTANCD

            '//SQL実行
            cdb.mExecQuery()
            '//データセットに格納
            ds = cdb.pResult
            '//データが存在しない場合
            If ds.Tables(0).Rows.Count = 0 Then
                'Return "DATA0"
            Else
                '//データを格納
                dr = ds.Tables(0).Rows(0)
            End If

            '2006/06/09 NEC ADD START
            Dim dsShamas As New DataSet
            Dim drShamas As DataRow
            Dim strSQL_Shamas As New StringBuilder("")

            strSQL_Shamas.Append("SELECT ")
            strSQL_Shamas.Append("MAP_CD, ")        '地図番号
            strSQL_Shamas.Append("USER_FLG ")      'お客様状態
            strSQL_Shamas.Append("FROM SHAMAS ")
            strSQL_Shamas.Append("WHERE CLI_CD=:CLI_CD AND ")
            strSQL_Shamas.Append(" HAN_CD=:HAN_CD AND ")
            strSQL_Shamas.Append(" USER_CD=:USER_CD ")

            '//SQLセット
            cdb.pSQL = strSQL_Shamas.ToString
            '//パラメータセット
            cdb.pSQLParamStr("CLI_CD") = strKURACD
            cdb.pSQLParamStr("HAN_CD") = strACBCD
            cdb.pSQLParamStr("USER_CD") = strUSER_CD

            '//SQL実行
            cdb.mExecQuery()
            '//データセットに格納
            dsShamas = cdb.pResult
            '//データが存在しない場合
            If dsShamas.Tables(0).Rows.Count = 0 Then
                strSQL_Shamas.Remove(0, strSQL_Shamas.Length)
                strSQL_Shamas.Append("SELECT ")
                strSQL_Shamas.Append("'' AS MAP_CD, ")        '地図番号
                strSQL_Shamas.Append("'' AS USER_FLG ")      'お客様状態
                strSQL_Shamas.Append("FROM DUAL ")

                '//SQLセット
                cdb.pSQL = strSQL_Shamas.ToString

                '//SQL実行
                cdb.mExecQuery()
                '//データセットに格納
                dsShamas = cdb.pResult
                '//データを格納
                drShamas = dsShamas.Tables(0).Rows(0)
            Else
                '//データを格納
                drShamas = dsShamas.Tables(0).Rows(0)
            End If

            '2006/06/09 NEC ADD END

            '--------------------------------------------------
            'データの出力
            '--------------------------------------------------
            Dim strTemp As String = ""

            '2行目
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            '2006/06/07 NEC UPDATE START
            'If ds.Tables(0).Rows.Count = 0 Then
            '    strTemp = ""
            'Else
            '    strTemp = Convert.ToString(dr.Item("JA_NAME"))
            'End If
            'ExcelC.pCellVal(1, "colspan=10") = "ＪＡ名：" & strTemp
            ExcelC.pCellVal(1, "colspan=10") = "送信先FAX番号：" & pstrSEND_TEL
            '2006/06/07 NEC UPDATE END
            ExcelC.mWriteLine("")   '行をファイルに書き込む

            '3行目
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            If ds.Tables(0).Rows.Count = 0 Then
                strTemp = ""
            Else
                If Convert.ToString(dr.Item("JAS_NAME")) = "" Then
                    strTemp = ""
                Else
                    strTemp = Convert.ToString(dr.Item("JAS_NAME")) & "　御中"
                End If
            End If
            '2006/06/07 NEC UPDATE START
            'ExcelC.pCellVal(1, "colspan=10") = "支所名：" & strTemp
            ExcelC.pCellVal(1, "colspan=10") = "ＪＡ支所名　 ：" & strTemp
            '2006/06/07 NEC UPDATE END
            ExcelC.mWriteLine("")   '行をファイルに書き込む

            '4行目
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellStyle(2) = "border-style:none;font-size:13pt"
            ExcelC.pCellStyle(3) = "border-style:none;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=4") = ""
            ExcelC.pCellVal(2, "colspan=2") = ""
            '2006/06/14 NEC UPDATE START
            'ExcelC.pCellVal(3, "colspan=4 align=right") = "FAX番号：" & pstrSEND_TEL
            If ds.Tables(0).Rows.Count = 0 Then
                strTemp = ""
            Else
                strTemp = Convert.ToString(dr.Item("TEL"))
            End If
            ExcelC.pCellVal(3, "colspan=4 align=right") = "発信者TEL：" & strTemp
            '2006/06/14 NEC UPDATE END
            ExcelC.mWriteLine("")   '行をファイルに書き込む

            '2010/03/24 T.Watabe add
            '5行目
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellStyle(2) = "border-style:none;font-size:13pt"
            ExcelC.pCellStyle(3) = "border-style:none;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=4") = ""
            ExcelC.pCellVal(2, "colspan=2") = ""
            If ds.Tables(0).Rows.Count = 0 Then
                strTemp = ""
            Else
                strTemp = Convert.ToString(dr.Item("KINKYU_TEL"))
            End If
            ExcelC.pCellVal(3, "colspan=4 align=right") = "発信者FAX：" & strTemp
            ExcelC.mWriteLine("")   '行をファイルに書き込む

            '6行目
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellStyle(2) = "border-style:none;font-size:13pt"
            If ds.Tables(0).Rows.Count = 0 Then
                strTemp = ""
            Else
                strTemp = Convert.ToString(dr.Item("KEN_NAME"))
            End If
            ExcelC.pCellVal(1, "colspan=5") = "県　　　名　 ：" & strTemp
            ExcelC.pCellVal(2, "colspan=5 align=right") = "発信者：" & pstrSEND_NAME
            ExcelC.mWriteLine("")   '行をファイルに書き込む

            '7行目
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellStyle(2) = "border-style:none;font-size:13pt"
            If ds.Tables(0).Rows.Count = 0 Then
                strTemp = ""
            Else
                strTemp = Convert.ToString(dr.Item("HAISO_NAME"))
            End If
            ExcelC.pCellVal(1, "colspan=5") = "供給ｾﾝﾀｰ名　 ：" & strTemp
            If ds.Tables(0).Rows.Count = 0 Then
                strTemp = ""
            Else
                strTemp = Convert.ToString(dr.Item("KANSI_NAME"))
            End If
            ExcelC.pCellVal(2, "colspan=5 align=right") = strTemp
            ExcelC.mWriteLine("")   '行をファイルに書き込む

            '7行目
            '2020/11/01 T.Ono del 2020監視改善
            'ExcelC.mWriteLine("")   '行をファイルに書き込む

            '8行目
            ExcelC.pCellStyle(1) = "border-bottom-style:none;border-left-style:none;border-right-style:none;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=10") = ""
            ExcelC.mWriteLine("")   '行をファイルに書き込む

            '9行目
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=10") = "<<受信情報>>"
            ExcelC.mWriteLine("")   '行をファイルに書き込む

            '10行目
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            '2006/06/13 NEC UPDATE START
            'ExcelC.pCellVal(1, "colspan=10") = "お客様氏名：" & strJUSYONM
            ExcelC.pCellStyle(2) = "border-style:none;font-size:13pt"
            '2015/02/27 H.Hosoda mod 2014改善開発 No.5 START
            'ExcelC.pCellVal(1, "colspan=7") = "お客様氏名：" & strJUSYONM
            ExcelC.pCellVal(1, "colspan=7") = "お客様名　：" & strJUSYONM
            '2015/02/27 H.Hosoda mod 2014改善開発 No.5 END

            If dsShamas.Tables(0).Rows.Count = 0 Then
                strTemp = ""
            Else
                strTemp = Convert.ToString(drShamas.Item("MAP_CD"))
            End If
            '2015/02/27 H.Hosoda mod 2014改善開発 No.5 START
            '2006/06/23 NEC UPDATE START
            'ExcelC.pCellVal(2, "colspan=2") = "地図Ｎｏ：" & strTemp
            'ExcelC.pCellVal(2, "colspan=3") = "地図Ｎｏ　：" & strTemp
            '2006/06/23 NEC UPDATE END
            ExcelC.pCellVal(2, "colspan=3") = "地図番号　：" & strTemp
            '2015/02/27 H.Hosoda mod 2014改善開発 No.5 END
            '2006/06/13 NEC UPDATE END
            ExcelC.mWriteLine("")   '行をファイルに書き込む

            '11行目
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            '2006/06/07 NEC UPDATE START
            'ExcelC.pCellVal(1, "colspan=5") = "電話番号：" & strJUTEL1 & strJUTEL2
            'ExcelC.pCellVal(1, "colspan=10") = "お客様コード：" & strUSER_CD
            '2006/06/13 NEC UPDATE START
            'ExcelC.pCellVal(1, "colspan=10") = "お客様コード：" & strACBCD & strUSER_CD
            ExcelC.pCellStyle(2) = "border-style:none;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=7") = "お客様ｺｰﾄﾞ：" & strACBCD & strUSER_CD
            If dsShamas.Tables(0).Rows.Count = 0 Then
                strTemp = ""
            Else
                strTemp = Convert.ToString(drShamas.Item("USER_FLG"))
            End If

            Select Case strTemp
                Case "0"
                    '0:未開通
                    ExcelC.pCellVal(2, "colspan=3") = "お客様状態：" & "未開通"
                Case "1"
                    '1:運用中
                    ExcelC.pCellVal(2, "colspan=3") = "お客様状態：" & "運用中"
                Case "2"
                    '2:休止中
                    ExcelC.pCellVal(2, "colspan=3") = "お客様状態：" & "休止中"
                Case Else
                    'その他
                    ExcelC.pCellVal(2, "colspan=3") = "お客様状態："
            End Select
            '2006/06/13 NEC UPDATE END
            '2006/06/07 NEC UPDATE END
            ExcelC.mWriteLine("")   '行をファイルに書き込む

            '12行目
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellStyle(2) = "border-style:none;font-size:13pt"
            '2006/06/07 NEC UPDATE START
            'ExcelC.pCellVal(1, "colspan=5") = "電話番号：" & strJUTEL1 & strJUTEL2
            'ExcelC.pCellVal(1, "colspan=5") = "電話番号：" & strJUTEL1 & "-" & strJUTEL2
            '2006/06/07 NEC UPDATE END
            '2006/06/20 NEC UPDATE START
            'ExcelC.pCellVal(1, "colspan=4") = "電話番号：" & Convert.ToString(dr.Item("KTELNO"))
            '2015/02/27 H.Hosoda mod 2014改善開発 No.5 START
            'If strJUTEL1 = "" Or strJUTEL2 = "" Then
            '    ExcelC.pCellVal(1, "colspan=5") = "電話番号　：" & strJUTEL1 & strJUTEL2
            'Else
            '    ExcelC.pCellVal(1, "colspan=5") = "電話番号　：" & strJUTEL1 & "-" & strJUTEL2
            'End If
            ''2006/06/20 NEC UPDATE END
            'ExcelC.pCellVal(2, "colspan=5") = "連絡電話番号：" & strRENTEL
            If strJUTEL1 = "" Or strJUTEL2 = "" Then
                ExcelC.pCellVal(1, "colspan=5") = "結線番号　：" & strJUTEL1 & strJUTEL2
            Else
                ExcelC.pCellVal(1, "colspan=5") = "結線番号　：" & strJUTEL1 & "-" & strJUTEL2
            End If
            ExcelC.pCellVal(2, "colspan=5") = "連絡先：" & strRENTEL
            '2015/02/27 H.Hosoda mod 2014改善開発 No.5 END
            ExcelC.mWriteLine("")   '行をファイルに書き込む

            '13行目
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=10") = "住所　　　：" & strADDR
            ExcelC.mWriteLine("")   '行をファイルに書き込む

            '14行目
            ExcelC.mWriteLine("")   '行をファイルに書き込む

            '15行目
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=10") = "【警報内容】"
            ExcelC.mWriteLine("")   '行をファイルに書き込む

            '16行目
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellStyle(2) = "border-style:none;font-size:13pt"
            '2015/02/27 H.Hosoda mod 2014改善開発 No.5 START
            'ExcelC.pCellVal(1, "colspan=4") = "発生日　　：" & strHATYMD & " " & strHATTIME
            ExcelC.pCellVal(1, "colspan=4") = "受信日時　：" & strHATYMD & " " & strHATTIME
            '2015/02/27 H.Hosoda mod 2014改善開発 No.5 END
            ExcelC.pCellVal(2, "colspan=6") = "メータ値　：" & strKENSIN
            ExcelC.mWriteLine("")   '行をファイルに書き込む

            '17行目
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellStyle(2) = "border-style:none;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=4") = "流量区分　：" & strRYURYO
            ExcelC.pCellVal(2, "colspan=6") = "メータ種別：" & strMETASYU
            ExcelC.mWriteLine("")   '行をファイルに書き込む

            '18行目
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellStyle(2) = "border-style:none;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=5") = "1：" & strKMNM1
            ExcelC.pCellVal(2, "colspan=5") = "4：" & strKMNM4
            ExcelC.mWriteLine("")   '行をファイルに書き込む

            '19行目
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellStyle(2) = "border-style:none;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=5") = "2：" & strKMNM2
            ExcelC.pCellVal(2, "colspan=5") = "5：" & strKMNM5
            ExcelC.mWriteLine("")   '行をファイルに書き込む

            '20行目
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellStyle(2) = "border-style:none;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=5") = "3：" & strKMNM3
            ExcelC.pCellVal(2, "colspan=5") = "6：" & strKMNM6
            ExcelC.mWriteLine("")   '行をファイルに書き込む

            '21行目
            '2020/11/01 T.Ono del 2020監視改善
            'ExcelC.mWriteLine("")   '行をファイルに書き込む

            '21行目
            '2020/11/01 T.Ono del 2020監視改善
            'ExcelC.pCellStyle(1) = "border-bottom-style:none;border-left-style:none;border-right-style:none;font-size:13pt"
            'ExcelC.pCellVal(1, "colspan=10") = ""
            'ExcelC.mWriteLine("")   '行をファイルに書き込む

            '21行目
            'ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"    2020/11/01 T.Ono mod 2020監視改善
            ExcelC.pCellStyle(1) = "border-bottom-style:none;border-left-style:none;border-right-style:none;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=10") = "<<監視センター対応内容>>"
            ExcelC.mWriteLine("")   '行をファイルに書き込む

            '22行目
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellStyle(2) = "border-style:none;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=5") = "対応区分　　：" & strTAIOKBN
            ExcelC.pCellVal(2, "colspan=5") = "処理番号(照会用)：" & strSYONO
            ExcelC.mWriteLine("")   '行をファイルに書き込む

            '23行目
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellStyle(2) = "border-style:none;font-size:13pt"
            If ds.Tables(0).Rows.Count = 0 Then
                strTemp = ""
            Else
                strTemp = Convert.ToString(dr.Item("TANNM"))
            End If
            ExcelC.pCellVal(1, "colspan=5") = "監視ｾﾝﾀｰ担当：" & strTemp
            'ExcelC.pCellVal(2, "colspan=5") = "対応日：" & strSYOYMD & " " & strSYOTIME 2008/10/14 T.Watabe edit
            
            '2015/02/27 H.Hosoda mod 2014改善開発 No.5 START
            'ExcelC.pCellVal(2, "colspan=5") = "完了日時　　　　：" & strSYOYMD & " " & strSYOTIME
            ExcelC.pCellVal(2, "colspan=5") = "対応完了日時　　：" & strSYOYMD & " " & strSYOTIME
            '2015/02/27 H.Hosoda mod 2014改善開発 No.5 END
            ExcelC.mWriteLine("")   '行をファイルに書き込む

            '24行目
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            '2015/02/27 H.Hosoda mod 2014改善開発 No.5 START
            'ExcelC.pCellVal(1, "colspan=10") = "依頼日　　　：" & strSIJIYMD & " " & strSIJITIME
            ExcelC.pCellVal(1, "colspan=10") = "依頼日時　　：" & strSIJIYMD & " " & strSIJITIME
            '2015/02/27 H.Hosoda mod 2014改善開発 No.5 END
            ExcelC.mWriteLine("")   '行をファイルに書き込む

            '25行目
            ExcelC.mWriteLine("")   '行をファイルに書き込む

            '26行目
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=10") = "連絡相手　　：" & strTAITCD
            ExcelC.mWriteLine("")   '行をファイルに書き込む

            '27行目
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=10") = "電話連絡内容：" & strTELRCD
            ExcelC.mWriteLine("")   '行をファイルに書き込む

            ' 2011/08/24 T.Watabe edit
            '''30行目
            ''ExcelC.mWriteLine("")   '行をファイルに書き込む
            '''--- ↓2005/05/17 MOD Falcon↓ ---
            '''出力順を電話メモ１⇒電話メモ２⇒復帰操作メモに修正
            '''31行目
            '''--- ↓2005/05/16 MOD Falcon↓ ---
            ''ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            '''ExcelC.pCellStyle(2) = "border-style:none;font-size:13pt"
            '''10列結合に変更
            ''ExcelC.pCellVal(1, "colspan=10") = strTEL_MEMO1
            '''ExcelC.pCellVal(2, "colspan=1") = ""
            ''ExcelC.mWriteLine("")   '行をファイルに書き込む
            '''--- ↑2005/05/16 MOD Falcon↑ ---
            '''32行目
            '''--- ↓2005/05/16 MOD Falcon↓ ---
            ''ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            '''ExcelC.pCellStyle(2) = "border-style:none;font-size:13pt"
            ''ExcelC.pCellVal(1, "colspan=10") = strTEL_MEMO2
            '''ExcelC.pCellVal(2, "colspan=1") = ""
            ''ExcelC.mWriteLine("")   '行をファイルに書き込む
            '''--- ↑2005/05/16 MOD Falcon↑ ---
            '''33行目
            '''--- ↓2005/05/16 MOD Falcon↓ ---
            ''ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            '''ExcelC.pCellStyle(2) = "border-style:none;font-size:13pt"
            '''10列結合に変更
            ''ExcelC.pCellVal(1, "colspan=10") = strFUK_MEMO
            '''ExcelC.pCellVal(2, "colspan=1") = ""
            ''ExcelC.mWriteLine("")   '行をファイルに書き込む
            '''--- ↑2005/05/16 MOD Falcon↑ ---
            '''--- ↑2005/05/17 MOD Falcon↑ ---
            '28行目
            ExcelC.pCellStyle(1) = "border-style:none"
            'ExcelC.pCellStyle(2) = "border-style:none;height:72px;vertical-align:top" '高さ指定すると、他行が可変高にならず１行になってしまう。
            ExcelC.pCellStyle(2) = "border-style:none;vertical-align:top"
            ExcelC.pCellVal(1) = ""
            'ExcelC.pCellVal(2, "colspan=9") = strTEL_MEMO1 & strTEL_MEMO2 & strFUK_MEMO    2020/11/01 T.Ono mod 2020監視改善
            ExcelC.pCellVal(2, "colspan=9") = strTEL_MEMO1 & strTEL_MEMO2 & strFUK_MEMO & strTEL_MEMO4 & strTEL_MEMO5 & strTEL_MEMO6
            ExcelC.mWriteLine("")   '行をファイルに書き込む

            '29行目
            ExcelC.pCellStyle(1) = "border-style:none;height:6pt"    '2020/11/01 T.Ono add 2020監視改善
            ExcelC.pCellVal(1, "colspan=10") = ""    '2020/11/01 T.Ono add 2020監視改善
            ExcelC.mWriteLine("")   '行をファイルに書き込む

            '30行目
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            '2015/02/27 H.Hosoda mod 2014改善開発 No.5 START
            'ExcelC.pCellVal(1, "colspan=10") = "原因器具名　：" & strTKIGCD
            ExcelC.pCellVal(1, "colspan=10") = "原因器具　　：" & strTKIGCD
            '2015/02/27 H.Hosoda mod 2014改善開発 No.5 END
            ExcelC.mWriteLine("")   '行をファイルに書き込む

            '31行目
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=10") = "作動原因　　：" & strTSADCD
            ExcelC.mWriteLine("")   '行をファイルに書き込む

            '32行目
            '2020/11/01 T.Ono del 2020監視改善
            ''2015/05/13 H.Mori mod メモ欄のひとつ上の行を縮小 START
            ''ExcelC.mWriteLine("")   '行をファイルに書き込む
            'ExcelC.pCellStyle(1) = "border-style:none;height:9pt"
            'ExcelC.pCellVal(1) = ""
            'ExcelC.mWriteLine("")   '行をファイルに書き込む
            ''2015/05/13 H.Mori mod メモ欄のひとつ上の行を縮小 END

            '32行目
            '2015/04/30 H.Mori mod メモ欄を拡大
            'ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellStyle(1) = "border-style:none;height:47pt;vertical-align:top;font-size:13pt"
            '2015/02/27 H.Hosoda mod 2014改善開発 No.5 START
            'ExcelC.pCellVal(1, "colspan=10") = "依頼内容　　：" & strFAX_REN
            ExcelC.pCellVal(1, "colspan=10") = "メモ欄　　　：" & strFAX_REN
            '2015/02/27 H.Hosoda mod 2014改善開発 No.5 END
            ExcelC.mWriteLine("")   '行をファイルに書き込む

            '33行目
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            '2021/02/12 T.Ono mod この文言は表示しない Start
            ''If strMITOKBN = "1" Then    2020/11/01 T.Ono mod vbCRLFが付いていて判断できてない
            'If strMITOKBN.Substring(0, 1) = "1" Then
            '    ExcelC.pCellVal(1, "colspan=10") = "「お客様マスター　氏名、住所、電話番号をご確認の上、ご連絡ください。」"
            'Else
            '    ExcelC.pCellVal(1, "colspan=10") = ""
            'End If
            ExcelC.pCellVal(1, "colspan=10") = ""
            '2021/02/12 T.Ono mod この文言は表示しない Start
            ExcelC.mWriteLine("")   '行をファイルに書き込む

            ' 2008/02/29 T.Watabe del
            '40行目
            'ExcelC.mWriteLine("")   '行をファイルに書き込む

            '41行目
            'ExcelC.pCellStyle(1) = "border-bottom-style:none;border-left-style:none;border-right-style:none;font-size:13pt"
            'ExcelC.pCellVal(1, "colspan=10") = ""
            'ExcelC.mWriteLine("")   '行をファイルに書き込む

            ' 2008/02/29 T.Watabe add
            '34行目～44行目
            ExcelC.pCellStyle(1) = "border:.5pt solid black; height:23.25pt; font-size:12pt"
            ExcelC.pCellVal(1, "colspan=3") = "事業所名："
            ExcelC.pCellStyle(4) = "border:.5pt solid black;font-size:12pt"
            ExcelC.pCellVal(4, "colspan=3") = "対応者名："
            ExcelC.pCellStyle(7) = "border:.5pt solid black;font-size:12pt"
            ExcelC.pCellVal(7, "colspan=4") = "対応日時："
            ExcelC.mWriteLine("")   '行をファイルに書き込む

            ExcelC.pCellStyle(1) = "border:.5pt solid black; height:195.0pt;width:24pt;font-size:13pt;background:silver;layout-flow:vertical"
            'ExcelC.pCellVal(1, "rowspan=12") = "対応結果" ' 2010/03/24 T.Watabe edit １行増やしたので下から１行減らす
            '2015/04/30 H.Mori mod 対応結果を一行分削除 
            'ExcelC.pCellVal(1, "rowspan=11") = "対応結果"
            ExcelC.pCellVal(1, "rowspan=10") = "対応結果"
            ExcelC.pCellStyle(2) = "border-right:.5pt solid black;font-size:12pt"
            'ExcelC.pCellVal(2, "colspan=9 rowspan=10") = "　" ' 2010/03/24 T.Watabe edit １行増やしたので下から１行減らす
            'ExcelC.mWriteLine("")   '行をファイルに書き込む
            '2015/04/30 H.Mori mod 対応結果を一行分削除 
            'ExcelC.pCellVal(2, "colspan=9 rowspan=9") = "　"
            ExcelC.pCellVal(2, "colspan=9 rowspan=8") = "　"
            ExcelC.mWriteLine("")   '行をファイルに書き込む
            ExcelC.mWriteLine("")   '行をファイルに書き込む
            ExcelC.mWriteLine("")   '行をファイルに書き込む
            ExcelC.mWriteLine("")   '行をファイルに書き込む
            ExcelC.mWriteLine("")   '行をファイルに書き込む
            ExcelC.mWriteLine("")   '行をファイルに書き込む
            ExcelC.mWriteLine("")   '行をファイルに書き込む
            ExcelC.mWriteLine("")   '行をファイルに書き込む
            '2015/04/30 H.Mori del 対応結果を一行分削除 
            'ExcelC.mWriteLine("")   '行をファイルに書き込む

            ExcelC.pCellStyle(2) = "border-right:.5pt solid black; height:21.0pt;font-size:12pt"
            ExcelC.pCellVal(2, "colspan=9") = "完了日時："
            ExcelC.mWriteLine("")   '行をファイルに書き込む

            ExcelC.pCellStyle(2) = "border-right:.5pt solid black; height:21.0pt;font-size:12pt"
            ExcelC.pCellVal(2, "colspan=9") = "報告日時："
            ExcelC.mWriteLine("")   '行をファイルに書き込む


            'フッタ項目の書き出しと、ファイルクローズ
            ExcelC.mClose()

            '//テキストデータファイルの削除
            Kill(gstrPATH & strTaiouTextName)

            '2014/12/25 T.Ono mod 2014改善開発 No4 START
            ''作成したファイルをBase64エンコードして戻す
            'Return FileToStrC.mFileToStr(ExcelC.pDirName & ExcelC.pFileName & ".xls")
            If pstrBtnKBN = "2" Then
                'プレビューボタンを押した場合(JPGから呼ばれた場合)
                Return ExcelC.pDirName & ExcelC.pFileName & ".xls"
            Else
                '送信ボタンを押した場合(KEFAXJAE00.exeから呼ばれた場合)
                Return FileToStrC.mFileToStr(ExcelC.pDirName & ExcelC.pFileName & ".xls")
            End If
            '2014/12/25 T.Ono mod 2014改善開発 No4 END

        Catch ex As Exception
            'エラーの内容とＳＱＬ文を返す
            Return "ERROR:" & ex.ToString

        Finally
            '接続クローズ
            cdb.mClose()

        End Try

    End Function
    '2015/12/09 w.ganeko 2015改善開発 №2 start
    '******************************************************************************
    '*　概　要：
    '*　備　考：
    '******************************************************************************
    <WebMethod()> Public Function mExcelSpot( _
                                            ByVal pstrRoop As String, _
                                            ByVal pstrSessionID As String, _
                                            ByVal pstrTEXT_NAME As String, _
                                            ByVal pstrSEND_NAME As String, _
                                            ByVal pstrSEND_POST As String, _
                                            ByVal pstrSEND_ADDS As String, _
                                            ByVal pstrSEND_FAX As String, _
                                            ByVal pstrSEND_TEL As String, _
                                            ByVal pstrBtnKBN As String _
                                            ) As String

        Dim strSQL As New StringBuilder("")
        Dim cdb As New CDB
        Dim ds As New DataSet
        Dim dr As DataRow

        Dim UtilFucC As New CUtilFuc

        '改行制御を行う
        'Dim intGYOSU As Integer = 47 ' 2008/02/29 T.Watabe edit
        Dim intGYOSU As Integer = 53
        '日付変換クラス
        Dim DateFncC As New CDateFnc
        'ファイルをBase64にエンコードするクラス
        Dim FileToStrC As New CFileStr

        Dim arrFaxData() As String
        Dim strTaiouTextName As String
        Dim strFaxData As String
        Dim strTaiouText As String

        ReDim gstrRecText(0)

        '接続OPEN----------------------------------------
        Try
            cdb.mOpen()
        Catch ex As Exception
            Return ex.ToString
        Finally

        End Try

        Dim strRec As String = "OK"
        Try
            gstrPATH = ConfigurationSettings.AppSettings("TEXTPATH") & "\00\"
            '対応入力データテキスト
            strTaiouTextName = gstrPGCD & "\" & pstrTEXT_NAME

            '//------------------------------------------------------------
            '対応入力データファイルを読み込む
            strRec = fncTaiouRecv(strTaiouTextName, strTaiouText)
            If strRec <> "OK" Then
                Return strRec
            End If

            '//">"区切りデータを取得　配列に格納
            If strTaiouText.Length <> 0 Then
                arrFaxData = strTaiouText.Split(Convert.ToChar(gstrPoint))
            End If

            '//データセット ----------------------------------
            Dim strSYONO As String = arrFaxData(0)                          '処理番号
            Dim strFAXTITLE As String = arrFaxData(1)                       'ＦＡＸタイトル
            Dim strACBCD As String = arrFaxData(2)                          'ＪＡ支所コード
            Dim strKURACD As String = arrFaxData(3)                         'クライアントコード
            Dim strKANSCD As String = arrFaxData(4)                         '監視センターコード
            Dim strJUSYONM As String = arrFaxData(5)                        'お客様氏名
            Dim strUSER_CD As String = arrFaxData(6)                        'お客様コード
            Dim strJUTEL1 As String = arrFaxData(7)                         '自宅電話市外
            Dim strJUTEL2 As String = arrFaxData(8)                         '自宅電話市内
            Dim strRENTEL As String = arrFaxData(9)                         '連絡電話番号
            Dim strADDR As String = arrFaxData(10)                          '住所
            Dim strHATYMD As String = arrFaxData(11)                        '発生日
            Dim strHATTIME As String = arrFaxData(12)                       '発生時刻
            Dim strKENSIN As String = arrFaxData(13)                        'メータ値
            Dim strRYURYO As String = arrFaxData(14)                        '流量区分
            Dim strMETASYU As String = arrFaxData(15)                       'メータ種別
            Dim strKMNM1 As String = arrFaxData(16)                         '警報メッセージ１
            Dim strKMNM2 As String = arrFaxData(17)                         '警報メッセージ２
            Dim strKMNM3 As String = arrFaxData(18)                         '警報メッセージ３
            Dim strKMNM4 As String = arrFaxData(19)                         '警報メッセージ４
            Dim strKMNM5 As String = arrFaxData(20)                         '警報メッセージ５
            Dim strKMNM6 As String = arrFaxData(21)                         '警報メッセージ６
            Dim strTAIOKBN As String = fncGET_PULLNM("09", arrFaxData(22))  '対応区分
            Dim strTKTANCD As String = arrFaxData(23)                       '監視センター担当者
            Dim strSYOYMD As String = arrFaxData(24)                        '対応完了日
            Dim strSYOTIME As String = arrFaxData(25)                       '対応完了時刻
            Dim strSIJIYMD As String = arrFaxData(26)                       '出動指示日
            Dim strSIJITIME As String = arrFaxData(27)                      '出動指示時刻
            Dim strTAITCD As String = fncGET_PULLNM("12", arrFaxData(28))   '連絡相手
            Dim strTELRCD As String = fncGET_PULLNM("15", arrFaxData(29))   '電話連絡内容
            Dim strFUK_MEMO As String = arrFaxData(30)                      '復帰操作メモ
            Dim strTEL_MEMO1 As String = arrFaxData(31)                     '電話メモ１
            Dim strTEL_MEMO2 As String = arrFaxData(32)                     '電話メモ２
            '2020/11/01 T.Ono mod 2020監視改善 Start
            'Dim strTKIGCD As String = fncGET_PULLNM("16", arrFaxData(33))   '原因器具
            'Dim strTSADCD As String = fncGET_PULLNM("17", arrFaxData(34))   '作動原因
            'Dim strFAX_REN As String = arrFaxData(35)                       '依頼内容
            'Dim strMITOKBN As String = arrFaxData(36)                       '未登録ＦＬＧ
            Dim strTEL_MEMO4 As String = arrFaxData(33)                     '電話メモ４
            Dim strTEL_MEMO5 As String = arrFaxData(34)                     '電話メモ５
            Dim strTEL_MEMO6 As String = arrFaxData(35)                     '電話メモ６
            Dim strTKIGCD As String = fncGET_PULLNM("16", arrFaxData(36))   '原因器具
            Dim strTSADCD As String = fncGET_PULLNM("17", arrFaxData(37))   '作動原因
            Dim strFAX_REN As String = arrFaxData(38)                       '依頼内容
            Dim strMITOKBN As String = arrFaxData(39)                       '未登録ＦＬＧ
            '2020/11/01 T.Ono mod 2020監視改善 End
            '//------------------------------------------------
            '2006/06/09 NEC ADD START
            Dim strMAP_CD As String                                         '地図番号
            Dim strUSER_FLG As String                                       'お客様状態
            '県コードをセット
            If strKURACD.Length <> 0 Then
                ExcelC.pKencd = strKURACD.Substring(1, 2)
            Else
                ExcelC.pKencd = "00"
            End If
            'セッションID
            ExcelC.pSessionID = pstrRoop & pstrSessionID

            '帳票ID
            ExcelC.pRepoID = "KEFAXJAX00"

            '帳票縦
            ExcelC.pLandScape = False

            'ファイルオープン
            ExcelC.mOpen()

            'タイトル
            ExcelC.pTitle = strFAXTITLE

            '作成日
            ExcelC.pDate = DateFncC.mGet(Now.ToString("yyyyMMdd"))

            '縮小拡大率
            ExcelC.pScale = 100

            '余白
            ExcelC.pMarginTop = 1.8D
            ExcelC.pMarginBottom = 0D
            ExcelC.pMarginLeft = 1.2D
            ExcelC.pMarginRight = 1.5D
            ExcelC.pMarginHeader = 1.3D
            ExcelC.pMarginFooter = 0D

            'ヘッダ項目をセット。（1ページあたり行数、出力行数、先頭行から何行目までが行タイトルか）
            ExcelC.mHeader(intGYOSU, intGYOSU, 1)

            '各列の幅をピクセルでセット。枠線も消す。
            '1行目
            ExcelC.pCellStyle(1) = "width:32px;border-style:none"
            ExcelC.pCellStyle(2) = "width:103px;border-style:none"
            ExcelC.pCellStyle(3) = "width:72px;border-style:none"
            ExcelC.pCellStyle(4) = "width:72px;border-style:none"
            ExcelC.pCellStyle(5) = "width:72px;border-style:none"
            ExcelC.pCellStyle(6) = "width:72px;border-style:none"
            ExcelC.pCellStyle(7) = "width:72px;border-style:none"
            ExcelC.pCellStyle(8) = "width:72px;border-style:none"
            ExcelC.pCellStyle(9) = "width:72px;border-style:none"
            ExcelC.pCellStyle(10) = "width:80px;border-style:none"
            ExcelC.pCellVal(1) = ""
            ExcelC.pCellVal(2) = ""
            ExcelC.pCellVal(3) = ""
            ExcelC.pCellVal(4) = ""
            ExcelC.pCellVal(5) = ""
            ExcelC.pCellVal(6) = ""
            ExcelC.pCellVal(7) = ""
            ExcelC.pCellVal(8) = ""
            ExcelC.pCellVal(9) = ""
            ExcelC.pCellVal(10) = ""
            ExcelC.mWriteLine("")   '行をファイルに書き込む

            '--------------------------------------------------
            'データの取得
            '--------------------------------------------------
            strSQL.Append("SELECT ")
            strSQL.Append("JA.JA_NAME, ")
            strSQL.Append("JA.JAS_NAME, ")
            strSQL.Append("CL.KEN_NAME, ")
            strSQL.Append("HA.NAME AS HAISO_NAME, ")
            strSQL.Append("KA.KANSI_NAME, ")
            strSQL.Append("KA.TEL, ")
            strSQL.Append("KA.KINKYU_TEL, ") ' 2010/03/24 T.Watabe add 監視ｾﾝﾀｰFAX番号
            strSQL.Append("TA.TANNM ")
            strSQL.Append("FROM HN2MAS JA, ")
            strSQL.Append("     CLIMAS CL, ")
            strSQL.Append("     HAIMAS HA, ")
            strSQL.Append("     KANSIMAS KA, ")
            strSQL.Append("     M05_TANTO TA ")
            strSQL.Append("WHERE CL.CLI_CD = :KURACD ")
            strSQL.Append("  AND CL.CLI_CD = JA.CLI_CD(+) ")
            strSQL.Append("  AND :ACBCD = JA.HAN_CD(+) ")
            strSQL.Append("  AND SUBSTR(JA.CLI_CD,2,2) = HA.KEN_CD(+) ")
            strSQL.Append("  AND JA.HAISO_CD = HA.HAISO_CD(+) ")
            strSQL.Append("  AND CL.KANSI_CODE = KA.KANSI_CD(+) ")
            strSQL.Append("  AND '1' = TA.KBN(+) ")
            strSQL.Append("  AND 'ZZZZ' = TA.KURACD(+) ")
            strSQL.Append("  AND CL.KANSI_CODE = TA.CODE(+) ")
            strSQL.Append("  AND :TKTANCD = TA.TANCD(+) ")


            '//SQLセット
            cdb.pSQL = strSQL.ToString
            '//パラメータセット
            cdb.pSQLParamStr("KURACD") = strKURACD
            cdb.pSQLParamStr("ACBCD") = strACBCD
            cdb.pSQLParamStr("TKTANCD") = strTKTANCD

            '//SQL実行
            cdb.mExecQuery()
            '//データセットに格納
            ds = cdb.pResult
            '//データが存在しない場合
            If ds.Tables(0).Rows.Count = 0 Then
                'Return "DATA0"
            Else
                '//データを格納
                dr = ds.Tables(0).Rows(0)
            End If

            '2006/06/09 NEC ADD START
            Dim dsShamas As New DataSet
            Dim drShamas As DataRow
            Dim strSQL_Shamas As New StringBuilder("")

            strSQL_Shamas.Append("SELECT ")
            strSQL_Shamas.Append("MAP_CD, ")        '地図番号
            strSQL_Shamas.Append("USER_FLG ")      'お客様状態
            strSQL_Shamas.Append("FROM SHAMAS ")
            strSQL_Shamas.Append("WHERE CLI_CD=:CLI_CD AND ")
            strSQL_Shamas.Append(" HAN_CD=:HAN_CD AND ")
            strSQL_Shamas.Append(" USER_CD=:USER_CD ")

            '//SQLセット
            cdb.pSQL = strSQL_Shamas.ToString
            '//パラメータセット
            cdb.pSQLParamStr("CLI_CD") = strKURACD
            cdb.pSQLParamStr("HAN_CD") = strACBCD
            cdb.pSQLParamStr("USER_CD") = strUSER_CD

            '//SQL実行
            cdb.mExecQuery()
            '//データセットに格納
            dsShamas = cdb.pResult
            '//データが存在しない場合
            If dsShamas.Tables(0).Rows.Count = 0 Then
                strSQL_Shamas.Remove(0, strSQL_Shamas.Length)
                strSQL_Shamas.Append("SELECT ")
                strSQL_Shamas.Append("'' AS MAP_CD, ")        '地図番号
                strSQL_Shamas.Append("'' AS USER_FLG ")      'お客様状態
                strSQL_Shamas.Append("FROM DUAL ")

                '//SQLセット
                cdb.pSQL = strSQL_Shamas.ToString

                '//SQL実行
                cdb.mExecQuery()
                '//データセットに格納
                dsShamas = cdb.pResult
                '//データを格納
                drShamas = dsShamas.Tables(0).Rows(0)
            Else
                '//データを格納
                drShamas = dsShamas.Tables(0).Rows(0)
            End If

            '2006/06/09 NEC ADD END

            '--------------------------------------------------
            'データの出力
            '--------------------------------------------------
            Dim strTemp As String = ""

            '2行目
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=10") = "送信先FAX番号：" & pstrSEND_TEL
            ExcelC.mWriteLine("")   '行をファイルに書き込む

            '3行目
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            If ds.Tables(0).Rows.Count = 0 Then
                strTemp = ""
            Else
                If Convert.ToString(dr.Item("JAS_NAME")) = "" Then
                    strTemp = ""
                Else
                    strTemp = Convert.ToString(dr.Item("JAS_NAME")) & "　御中"
                End If
            End If
            ExcelC.pCellVal(1, "colspan=10") = "ＪＡ支所名　 ：" & strTemp
            ExcelC.mWriteLine("")   '行をファイルに書き込む

            '4行目
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellStyle(2) = "border-style:none;font-size:13pt"
            ExcelC.pCellStyle(3) = "border-style:none;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=4") = ""
            ExcelC.pCellVal(2, "colspan=2") = ""
            If ds.Tables(0).Rows.Count = 0 Then
                strTemp = ""
            Else
                strTemp = Convert.ToString(dr.Item("TEL"))
            End If
            ExcelC.pCellVal(3, "colspan=4 align=right") = "発信者TEL：" & strTemp
            ExcelC.mWriteLine("")   '行をファイルに書き込む

            '4行目
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellStyle(2) = "border-style:none;font-size:13pt"
            ExcelC.pCellStyle(3) = "border-style:none;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=4") = ""
            ExcelC.pCellVal(2, "colspan=2") = ""
            If ds.Tables(0).Rows.Count = 0 Then
                strTemp = ""
            Else
                strTemp = Convert.ToString(dr.Item("KINKYU_TEL"))
            End If
            ExcelC.pCellVal(3, "colspan=4 align=right") = "発信者FAX：" & strTemp
            ExcelC.mWriteLine("")   '行をファイルに書き込む

            '5行目
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellStyle(2) = "border-style:none;font-size:13pt"
            If ds.Tables(0).Rows.Count = 0 Then
                strTemp = ""
            Else
                strTemp = Convert.ToString(dr.Item("KEN_NAME"))
            End If
            ExcelC.pCellVal(1, "colspan=5") = "県　　　名　 ：" & strTemp
            ExcelC.pCellVal(2, "colspan=5 align=right") = "発信者：" & pstrSEND_NAME
            ExcelC.mWriteLine("")   '行をファイルに書き込む

            '6行目
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellStyle(2) = "border-style:none;font-size:13pt"
            If ds.Tables(0).Rows.Count = 0 Then
                strTemp = ""
            Else
                strTemp = Convert.ToString(dr.Item("HAISO_NAME"))
            End If
            ExcelC.pCellVal(1, "colspan=5") = "供給ｾﾝﾀｰ名　 ：" & strTemp
            If ds.Tables(0).Rows.Count = 0 Then
                strTemp = ""
            Else
                strTemp = Convert.ToString(dr.Item("KANSI_NAME"))
            End If
            ExcelC.pCellVal(2, "colspan=5 align=right") = strTemp
            ExcelC.mWriteLine("")   '行をファイルに書き込む

            '7行目
            '2020/11/01 T.Ono del 2020監視改善
            'ExcelC.mWriteLine("")   '行をファイルに書き込む

            '8行目
            ExcelC.pCellStyle(1) = "border-bottom-style:none;border-left-style:none;border-right-style:none;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=10") = ""
            ExcelC.mWriteLine("")   '行をファイルに書き込む

            '9行目
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=10") = "<<受信情報>>"
            ExcelC.mWriteLine("")   '行をファイルに書き込む

            '10行目
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellStyle(2) = "border-style:none;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=7") = "お客様名　：" & strJUSYONM

            If dsShamas.Tables(0).Rows.Count = 0 Then
                strTemp = ""
            Else
                strTemp = Convert.ToString(drShamas.Item("MAP_CD"))
            End If
            ExcelC.pCellVal(2, "colspan=3") = "地図番号　：" & strTemp
            ExcelC.mWriteLine("")   '行をファイルに書き込む

            '11行目
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellStyle(2) = "border-style:none;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=7") = "お客様ｺｰﾄﾞ：" & strACBCD & strUSER_CD
            If dsShamas.Tables(0).Rows.Count = 0 Then
                strTemp = ""
            Else
                strTemp = Convert.ToString(drShamas.Item("USER_FLG"))
            End If

            Select Case strTemp
                Case "0"
                    '0:未開通
                    ExcelC.pCellVal(2, "colspan=3") = "お客様状態：" & "未開通"
                Case "1"
                    '1:運用中
                    ExcelC.pCellVal(2, "colspan=3") = "お客様状態：" & "運用中"
                Case "2"
                    '2:休止中
                    ExcelC.pCellVal(2, "colspan=3") = "お客様状態：" & "休止中"
                Case Else
                    'その他
                    ExcelC.pCellVal(2, "colspan=3") = "お客様状態："
            End Select
            ExcelC.mWriteLine("")   '行をファイルに書き込む

            '12行目
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellStyle(2) = "border-style:none;font-size:13pt"
            If strJUTEL1 = "" Or strJUTEL2 = "" Then
                ExcelC.pCellVal(1, "colspan=5") = "結線番号　：" & strJUTEL1 & strJUTEL2
            Else
                ExcelC.pCellVal(1, "colspan=5") = "結線番号　：" & strJUTEL1 & "-" & strJUTEL2
            End If
            ExcelC.pCellVal(2, "colspan=5") = "連絡先：" & strRENTEL
            ExcelC.mWriteLine("")   '行をファイルに書き込む

            '13行目
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=10") = "住所　　　：" & strADDR
            ExcelC.mWriteLine("")   '行をファイルに書き込む

            '14行目
            ExcelC.mWriteLine("")   '行をファイルに書き込む

            '15行目
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=10") = "【警報内容】"
            ExcelC.mWriteLine("")   '行をファイルに書き込む

            '16行目
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellStyle(2) = "border-style:none;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=4") = "受信日時　：" & strHATYMD & " " & strHATTIME
            ExcelC.pCellVal(2, "colspan=6") = "メータ値　：" & strKENSIN
            ExcelC.mWriteLine("")   '行をファイルに書き込む

            '17行目
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellStyle(2) = "border-style:none;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=4") = "流量区分　：" & strRYURYO
            ExcelC.pCellVal(2, "colspan=6") = "メータ種別：" & strMETASYU
            ExcelC.mWriteLine("")   '行をファイルに書き込む

            '18行目
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellStyle(2) = "border-style:none;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=5") = "1：" & strKMNM1
            ExcelC.pCellVal(2, "colspan=5") = "4：" & strKMNM4
            ExcelC.mWriteLine("")   '行をファイルに書き込む

            '19行目
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellStyle(2) = "border-style:none;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=5") = "2：" & strKMNM2
            ExcelC.pCellVal(2, "colspan=5") = "5：" & strKMNM5
            ExcelC.mWriteLine("")   '行をファイルに書き込む

            '20行目
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellStyle(2) = "border-style:none;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=5") = "3：" & strKMNM3
            ExcelC.pCellVal(2, "colspan=5") = "6：" & strKMNM6
            ExcelC.mWriteLine("")   '行をファイルに書き込む

            '21行目
            '2020/11/01 T.Ono del 2020監視改善
            'ExcelC.mWriteLine("")   '行をファイルに書き込む

            '22行目
            '2020/11/01 T.Ono del 2020監視改善
            'ExcelC.pCellStyle(1) = "border-bottom-style:none;border-left-style:none;border-right-style:none;font-size:13pt"
            'ExcelC.pCellVal(1, "colspan=10") = ""
            'ExcelC.mWriteLine("")   '行をファイルに書き込む

            '21行目
            'ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"     2020/11/01 T.Ono mod 2020監視改善
            ExcelC.pCellStyle(1) = "border-bottom-style:none;border-left-style:none;border-right-style:none;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=10") = "<<監視センター対応内容>>"
            ExcelC.mWriteLine("")   '行をファイルに書き込む

            '22行目
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellStyle(2) = "border-style:none;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=5") = "対応区分　　：" & strTAIOKBN
            ExcelC.pCellVal(2, "colspan=5") = "処理番号(照会用)：" & strSYONO
            ExcelC.mWriteLine("")   '行をファイルに書き込む

            '23行目
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellStyle(2) = "border-style:none;font-size:13pt"
            If ds.Tables(0).Rows.Count = 0 Then
                strTemp = ""
            Else
                strTemp = Convert.ToString(dr.Item("TANNM"))
            End If
            ExcelC.pCellVal(1, "colspan=5") = "監視ｾﾝﾀｰ担当：" & strTemp

            ExcelC.pCellVal(2, "colspan=5") = "対応完了日時　　：" & strSYOYMD & " " & strSYOTIME
            ExcelC.mWriteLine("")   '行をファイルに書き込む

            '24行目
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=10") = "依頼日時　　：" & strSIJIYMD & " " & strSIJITIME
            ExcelC.mWriteLine("")   '行をファイルに書き込む

            '25行目
            ExcelC.mWriteLine("")   '行をファイルに書き込む

            '26行目
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=10") = "連絡相手　　：" & strTAITCD
            ExcelC.mWriteLine("")   '行をファイルに書き込む

            '27行目
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=10") = "電話連絡内容：" & strTELRCD
            ExcelC.mWriteLine("")   '行をファイルに書き込む

            '28行目
            ExcelC.pCellStyle(1) = "border-style:none"
            ExcelC.pCellStyle(2) = "border-style:none;vertical-align:top"
            ExcelC.pCellVal(1) = ""
            'ExcelC.pCellVal(2, "colspan=9") = strTEL_MEMO1 & strTEL_MEMO2 & strFUK_MEMO    2020/11/01 T.Ono mod 2020監視改善
            ExcelC.pCellVal(2, "colspan=9") = strTEL_MEMO1 & strTEL_MEMO2 & strFUK_MEMO & strTEL_MEMO4 & strTEL_MEMO5 & strTEL_MEMO6
            ExcelC.mWriteLine("")   '行をファイルに書き込む

            '29行目
            ExcelC.pCellStyle(1) = "border-style:none;height:6pt"    '2020/11/01 T.Ono add 2020監視改善
            ExcelC.pCellVal(1, "colspan=10") = ""    '2020/11/01 T.Ono add 2020監視改善
            ExcelC.mWriteLine("")   '行をファイルに書き込む

            '30行目
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=10") = "原因器具　　：" & strTKIGCD
            ExcelC.mWriteLine("")   '行をファイルに書き込む

            '31行目
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=10") = "作動原因　　：" & strTSADCD
            ExcelC.mWriteLine("")   '行をファイルに書き込む

            '32行目
            '2020/11/01 T.Ono del 2020監視改善
            'ExcelC.pCellStyle(1) = "border-style:none;height:9pt"
            'ExcelC.pCellVal(1) = ""
            'ExcelC.mWriteLine("")   '行をファイルに書き込む

            '32行目
            ExcelC.pCellStyle(1) = "border-style:none;height:47pt;vertical-align:top;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=10") = "メモ欄　　　：" & strFAX_REN
            ExcelC.mWriteLine("")   '行をファイルに書き込む

            '33行目
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            '2021/02/12 T.Ono mod この文言は表示しない Start
            ''If strMITOKBN = "1" Then    2020/11/01 T.Ono mod
            'If strMITOKBN.Substring(0, 1) = "1" Then
            '    ExcelC.pCellVal(1, "colspan=10") = "「お客様マスター　氏名、住所、電話番号をご確認の上、ご連絡ください。」"
            'Else
            '    ExcelC.pCellVal(1, "colspan=10") = ""
            'End If
            ExcelC.pCellVal(1, "colspan=10") = ""
            '2021/02/12 T.Ono mod この文言は表示しない END
            ExcelC.mWriteLine("")   '行をファイルに書き込む

            '34行目～44行目
            ExcelC.pCellStyle(1) = "border:.5pt solid black; height:23.25pt; font-size:12pt"
            ExcelC.pCellVal(1, "colspan=3") = "事業所名："
            ExcelC.pCellStyle(4) = "border:.5pt solid black;font-size:12pt"
            ExcelC.pCellVal(4, "colspan=3") = "対応者名："
            ExcelC.pCellStyle(7) = "border:.5pt solid black;font-size:12pt"
            ExcelC.pCellVal(7, "colspan=4") = "対応日時："
            ExcelC.mWriteLine("")   '行をファイルに書き込む

            ExcelC.pCellStyle(1) = "border:.5pt solid black; height:195.0pt;width:24pt;font-size:13pt;background:silver;layout-flow:vertical"
            ExcelC.pCellVal(1, "rowspan=10") = "対応結果"
            ExcelC.pCellStyle(2) = "border-right:.5pt solid black;font-size:12pt"
            ExcelC.pCellVal(2, "colspan=9 rowspan=8") = "　"
            ExcelC.mWriteLine("")   '行をファイルに書き込む
            ExcelC.mWriteLine("")   '行をファイルに書き込む
            ExcelC.mWriteLine("")   '行をファイルに書き込む
            ExcelC.mWriteLine("")   '行をファイルに書き込む
            ExcelC.mWriteLine("")   '行をファイルに書き込む
            ExcelC.mWriteLine("")   '行をファイルに書き込む
            ExcelC.mWriteLine("")   '行をファイルに書き込む
            ExcelC.mWriteLine("")   '行をファイルに書き込む

            ExcelC.pCellStyle(2) = "border-right:.5pt solid black; height:21.0pt;font-size:12pt"
            ExcelC.pCellVal(2, "colspan=9") = "完了日時："
            ExcelC.mWriteLine("")   '行をファイルに書き込む

            ExcelC.pCellStyle(2) = "border-right:.5pt solid black; height:21.0pt;font-size:12pt"
            ExcelC.pCellVal(2, "colspan=9") = "報告日時："
            ExcelC.mWriteLine("")   '行をファイルに書き込む


            'フッタ項目の書き出しと、ファイルクローズ
            ExcelC.mClose()

            '//テキストデータファイルの削除
            'Kill(gstrPATH & strTaiouTextName)

            If pstrBtnKBN = "2" Then
                'プレビューボタンを押した場合(JPGから呼ばれた場合)
                Return ExcelC.pDirName & ExcelC.pFileName & ".xls"
            Else
                '送信ボタンを押した場合(KEFAXJAE00.exeから呼ばれた場合)
                Return FileToStrC.mFileToStr(ExcelC.pDirName & ExcelC.pFileName & ".xls")
            End If
            '2014/12/25 T.Ono mod 2014改善開発 No4 END

        Catch ex As Exception
            'エラーの内容とＳＱＬ文を返す
            Return "ERROR:" & ex.ToString

        Finally
            '接続クローズ
            cdb.mClose()

        End Try

    End Function
    '******************************************************************************
    '*　概　要：
    '*　備　考：
    '******************************************************************************
    <WebMethod()> Public Function mExcelSpotKill( _
                                            ByVal pstrSessionID As String, _
                                            ByVal pstrTEXT_NAME As String) As String
        Dim strRec As String = "OK"
        Dim strTaiouTextName As String

        gstrPATH = ConfigurationSettings.AppSettings("TEXTPATH") & "\00\"
        '対応入力データテキスト
        strTaiouTextName = gstrPGCD & "\" & pstrTEXT_NAME

        '//テキストデータファイルの削除
        Kill(gstrPATH & strTaiouTextName)
        Return strRec
    End Function

    '2015/12/09 w.ganeko 2015改善開発 №2 end

    '*****************************************************************
    '*　概　要：テキストファイル作成
    '*　備　考：区切り文字「>」でパラメータを連結
    '*          2020/11/01 T.Ono mod 2020監視改善 pstrTEL_MEMO4～6を追加
    '*****************************************************************
    <WebMethod()> Public Function fncDataOut(
                            ByVal pstrSYONO As String,
                            ByVal pstrFAX_TITLE As String,
                            ByVal pstrACBCD As String,
                            ByVal pstrKURACD As String,
                            ByVal pstrKANSCD As String,
                            ByVal pstrJUSYONM As String,
                            ByVal pstrUSER_CD As String,
                            ByVal pstrJUTEL1 As String,
                            ByVal pstrJUTEL2 As String,
                            ByVal pstrRENTEL As String,
                            ByVal pstrADDR As String,
                            ByVal pstrHATYMD As String,
                            ByVal pstrHATTIME As String,
                            ByVal pstrKENSIN As String,
                            ByVal pstrRYURYO As String,
                            ByVal pstrMETASYU As String,
                            ByVal pstrKMNM1 As String,
                            ByVal pstrKMNM2 As String,
                            ByVal pstrKMNM3 As String,
                            ByVal pstrKMNM4 As String,
                            ByVal pstrKMNM5 As String,
                            ByVal pstrKMNM6 As String,
                            ByVal pstrTAIOKBN As String,
                            ByVal pstrTKTANCD As String,
                            ByVal pstrSYOYMD As String,
                            ByVal pstrSYOTIME As String,
                            ByVal pstrSIJIYMD As String,
                            ByVal pstrSIJITIME As String,
                            ByVal pstrTAITCD As String,
                            ByVal pstrTELRCD As String,
                            ByVal pstrFUK_MEMO As String,
                            ByVal pstrTEL_MEMO1 As String,
                            ByVal pstrTEL_MEMO2 As String,
                            ByVal pstrTEL_MEMO4 As String,
                            ByVal pstrTEL_MEMO5 As String,
                            ByVal pstrTEL_MEMO6 As String,
                            ByVal pstrTKIGCD As String,
                            ByVal pstrTSADCD As String,
                            ByVal pstrFAX_REN As String,
                            ByVal pstrMITOKBN As String
                        ) As String

        Dim strRec As String
        '--- ↓2005/05/10 DEL Falcon↓ ---
        'Dim strProcId As String = "KEFAXJAW00"
        '--- ↑2005/05/10 DEL Falcon↑ ---
        Dim strFileNM As String

        strRec = "OK"
        Try

            Dim strTaiouText As New StringBuilder("")
            strTaiouText.Append(pstrSYONO & gstrPoint)
            strTaiouText.Append(pstrFAX_TITLE & gstrPoint)
            strTaiouText.Append(pstrACBCD & gstrPoint)
            strTaiouText.Append(pstrKURACD & gstrPoint)
            strTaiouText.Append(pstrKANSCD & gstrPoint)
            strTaiouText.Append(pstrJUSYONM & gstrPoint)
            strTaiouText.Append(pstrUSER_CD & gstrPoint)
            strTaiouText.Append(pstrJUTEL1 & gstrPoint)
            strTaiouText.Append(pstrJUTEL2 & gstrPoint)
            strTaiouText.Append(pstrRENTEL & gstrPoint)
            strTaiouText.Append(pstrADDR & gstrPoint)
            strTaiouText.Append(pstrHATYMD & gstrPoint)
            strTaiouText.Append(pstrHATTIME & gstrPoint)
            strTaiouText.Append(pstrKENSIN & gstrPoint)
            strTaiouText.Append(pstrRYURYO & gstrPoint)
            strTaiouText.Append(pstrMETASYU & gstrPoint)
            strTaiouText.Append(pstrKMNM1 & gstrPoint)
            strTaiouText.Append(pstrKMNM2 & gstrPoint)
            strTaiouText.Append(pstrKMNM3 & gstrPoint)
            strTaiouText.Append(pstrKMNM4 & gstrPoint)
            strTaiouText.Append(pstrKMNM5 & gstrPoint)
            strTaiouText.Append(pstrKMNM6 & gstrPoint)
            strTaiouText.Append(pstrTAIOKBN & gstrPoint)
            strTaiouText.Append(pstrTKTANCD & gstrPoint)
            strTaiouText.Append(pstrSYOYMD & gstrPoint)
            strTaiouText.Append(pstrSYOTIME & gstrPoint)
            strTaiouText.Append(pstrSIJIYMD & gstrPoint)
            strTaiouText.Append(pstrSIJITIME & gstrPoint)
            strTaiouText.Append(pstrTAITCD & gstrPoint)
            strTaiouText.Append(pstrTELRCD & gstrPoint)
            strTaiouText.Append(pstrFUK_MEMO & gstrPoint)
            strTaiouText.Append(pstrTEL_MEMO1 & gstrPoint)
            strTaiouText.Append(pstrTEL_MEMO2 & gstrPoint)
            strTaiouText.Append(pstrTEL_MEMO4 & gstrPoint)    '2020/11/01 T.Ono add 2020監視改善
            strTaiouText.Append(pstrTEL_MEMO5 & gstrPoint)    '2020/11/01 T.Ono add 2020監視改善
            strTaiouText.Append(pstrTEL_MEMO6 & gstrPoint)    '2020/11/01 T.Ono add 2020監視改善
            strTaiouText.Append(pstrTKIGCD & gstrPoint)
            strTaiouText.Append(pstrTSADCD & gstrPoint)
            strTaiouText.Append(pstrFAX_REN & gstrPoint)
            strTaiouText.Append(pstrMITOKBN)
            '出力
            strTaiouText.Append(vbCrLf)

            'ファイルの作成--------------------------------
            'Dim strSessionID As String = Now.ToString("yyyyMMddhhmiss") ' 2011/05/30 T.Watabe edit
            'Dim strSessionID As String = Now.ToString("yyyyMMddHHmmss") & CInt(Rnd() * 1000000000)  'セッションの作成(乱数を使用)
            'Dim strSessionID As String = "" & GetRandomPasswordUsingGUID(14)  'セッションの作成(乱数を使用)
            'Dim strSessionID As String = "" & CInt(Rnd() * 1000000000)   'セッションの作成(乱数を使用)
            Dim strSessionID As String = "" & GetRandomPasswordUsingGUID(8)  'セッションの作成(乱数を使用)

            Dim FileToStrC As New CFileStr
            Dim strFileName As String
            With FileToStrC
                '--- ↓2005/05/12 DEL Falcon↓ ---
                '.pKencd = ""    'クライアントコードより
                '--- ↑2005/05/12 DEL Falcon↑ ---
                '--- ↓2005/05/12 MOD Falcon↓ ---
                .pKencd = "00"
                '--- ↑2005/05/12 MOD Falcon↑ ---
                '--- ↓2005/05/10 DEL Falcon↓ ---
                '.pPgcd = strProcId
                '--- ↑2005/05/10 DEL Falcon↑ ---
                '--- ↓2005/05/10 MOD Falcon↓ ---
                .pPgcd = gstrPGCD
                '--- ↑2005/05/10 MOD Falcon↑ ---
                .pSessionID = strSessionID
                strFileName = .mStrToFile(strTaiouText.ToString)
            End With

            strRec = "OK"
            '--- ↓2005/05/12 DEL Falcon↓ ---
            'fncMakeDir(ConfigurationSettings.AppSettings("TEXTPATH"))
            '--- ↑2005/05/12 DEL Falcon↑ ---
            strFileNM = FileToStrC.pFileName

            '---------------------------------------------
        Catch ex As Exception
            'エラーが起きたら エラー内容を格納
            strRec = ex.ToString
        Finally

        End Try

        Return strRec & strFileNM

    End Function

    '****************************************************************
    'YYYYMMDD → YYYY/MM/DD
    '****************************************************************
    Private Function fncDateSet(ByVal strDate As String) As String
        If strDate.Length = 8 Then
            Return strDate.Substring(0, 4) & "/" & strDate.Substring(4, 2) & "/" & strDate.Substring(6, 2)
        Else
            Return ""
        End If
    End Function

    '****************************************************************
    'HHMISS → HH:MI
    '****************************************************************
    Private Function fncTimeSet(ByVal strTime As String) As String
        If strTime.Length = 4 Or strTime.Length = 6 Then
            Return strTime.Substring(0, 2) & ":" & strTime.Substring(2, 2)
        Else
            Return ""
        End If
    End Function

    '**********************************************************
    'フォルダの作成
    '**********************************************************
    Private Function fncMakeDir(ByVal strPath As String) As String
        'ディレクトリ作成(既にあれば無視)
        Dim dirInfo As New DirectoryInfo(strPath)
        dirInfo.Create()
        '作成パスを返す
        Return strPath
    End Function

    '******************************************************************************
    '*　概　要：プルダウンマスタを検索し、コードから名称を取得する
    '******************************************************************************
    Private Function fncGET_PULLNM(ByVal pstrKBN As String, ByVal pstrCD As String) As String
        Dim ds As New DataSet
        Dim cdb As New CDB
        Dim strRes As String
        Dim strSQL As StringBuilder
        strRes = ""

        '値がない場合は空を返す
        If pstrCD.Length = 0 Then
            Return strRes
        End If

        'ＤＢオープン
        cdb.mOpen()
        'SQL作成
        strSQL = New StringBuilder("")
        strSQL.Append("SELECT ")
        strSQL.Append("NAME ")
        strSQL.Append("FROM ")
        strSQL.Append("M06_PULLDOWN ")
        strSQL.Append("WHERE :KBN = KBN(+)")
        strSQL.Append(" AND :CD = CD(+)")
        'SQL文セット
        cdb.pSQL = strSQL.ToString
        'パラメータセット
        cdb.pSQLParamStr("KBN") = pstrKBN       '//区分
        cdb.pSQLParamStr("CD") = pstrCD         '//コード
        'SQLを実行
        cdb.mExecQuery()
        'データセットに値を格納
        ds = cdb.pResult
        If ds.Tables(0).Rows.Count = 0 Then
            'データが0件だったら
            strRes = ""
        Else
            strRes = Convert.ToString(ds.Tables(0).Rows(0).Item("NAME"))
        End If
        'ＤＢクローズ
        cdb.mClose()

        Return strRes
    End Function

    '******************************************************************************
    '*　概　要：テキストファイルの読み込み
    '*　備　考：
    '******************************************************************************
    Private Function fncTaiouRecv(ByVal pstrFileName As String, ByRef pstrTaiouText As String) As String

        Dim strReturn As New StringBuilder("")                  '結果内容の格納変数
        Dim strRec As String

        strRec = "OK"
        Try

            '結果ファイルが存在しない場合、エラー
            If Dir(gstrPATH & "\" & pstrFileName, FileAttribute.Normal) = "" Then
                Return "ERROR:データファイルが見つかりません。" & vbCrLf & vbCrLf & "[" & gstrPATH & "\" & pstrFileName & "]"
            End If
            '---------------------------------------------
            'ファイルも0バイトで出力され、書き込みを待っている
            'ファイルがあっても0バイトの可能性あり

            '結果ファイルの取得
            Dim c As String
            FileOpen(1, gstrPATH & "\" & pstrFileName, OpenMode.Input, OpenAccess.Read)
            Do
                Try
                    c = InputString(1, 1)
                    strReturn.Append(c)
                Catch
                    Exit Do
                End Try
            Loop
            FileClose()

            '内容のチェック
            If strReturn.ToString.Length = 0 Then
                Return "DATA0"
            End If

            strRec = "OK"
            pstrTaiouText = strReturn.ToString

        Catch ex As Exception
            strRec = "ERROR:" & ex.ToString
            pstrTaiouText = ""

        End Try

        Return strRec
    End Function

    ' 2011/05/30 T.Watabe add
    ' VB.NET
    Public Function GetRandomPasswordUsingGUID(ByVal length As Integer) As String

        'Get the GUID
        Dim guidResult As String = System.Guid.NewGuid().ToString()

        'Remove the hyphens
        guidResult = guidResult.Replace("-", String.Empty)

        'Make sure length is valid
        If length <= 0 OrElse length > guidResult.Length Then
            Throw New ArgumentException("Length must be between 1 and " & guidResult.Length)
        End If

        'Return the first length bytes
        Return guidResult.Substring(0, length)
    End Function
    '2012/03/26 ADD START W.GANEKO
    '*****************************************************************
    '*　概　要：EXCELファイル作成
    '*　備　考：区切り文字「>」でパラメータを連結
    '*          2015/01/19 T.Ono mod 2014改善開発 [発信者:pstrSEND_NAME]を追加
    '*          2020/11/01 T.Ono mod 2020監視改善 pstrTEL_MEMO4～6を追加
    '*****************************************************************
    <WebMethod()> Public Function fncExcelDataOut(
                            ByVal pstrSYONO As String,
                            ByVal pstrFAX_TITLE As String,
                            ByVal pstrACBCD As String,
                            ByVal pstrKURACD As String,
                            ByVal pstrKANSCD As String,
                            ByVal pstrJUSYONM As String,
                            ByVal pstrUSER_CD As String,
                            ByVal pstrJUTEL1 As String,
                            ByVal pstrJUTEL2 As String,
                            ByVal pstrRENTEL As String,
                            ByVal pstrADDR As String,
                            ByVal pstrHATYMD As String,
                            ByVal pstrHATTIME As String,
                            ByVal pstrKENSIN As String,
                            ByVal pstrRYURYO As String,
                            ByVal pstrMETASYU As String,
                            ByVal pstrKMNM1 As String,
                            ByVal pstrKMNM2 As String,
                            ByVal pstrKMNM3 As String,
                            ByVal pstrKMNM4 As String,
                            ByVal pstrKMNM5 As String,
                            ByVal pstrKMNM6 As String,
                            ByVal pstrTAIOKBN As String,
                            ByVal pstrTKTANCD As String,
                            ByVal pstrSYOYMD As String,
                            ByVal pstrSYOTIME As String,
                            ByVal pstrSIJIYMD As String,
                            ByVal pstrSIJITIME As String,
                            ByVal pstrTAITCD As String,
                            ByVal pstrTELRCD As String,
                            ByVal pstrFUK_MEMO As String,
                            ByVal pstrTEL_MEMO1 As String,
                            ByVal pstrTEL_MEMO2 As String,
                            ByVal pstrTEL_MEMO4 As String,
                            ByVal pstrTEL_MEMO5 As String,
                            ByVal pstrTEL_MEMO6 As String,
                            ByVal pstrTKIGCD As String,
                            ByVal pstrTSADCD As String,
                            ByVal pstrFAX_REN As String,
                            ByVal pstrMITOKBN As String,
                            ByVal pstrSENDFLG As String,
                            ByVal pstrMAIL As String,
                            ByVal pstrMAILPASS As String,
                            ByVal pstrSEND_NAME As String
                        ) As String

        Dim strRec As String
        Dim strFileNM As String
        Dim strZipNM As String
        Dim strPotPath As String
        Dim strExcelNM As String

        strRec = "OK"
        Try

            Dim strTaiouText As New StringBuilder("")
            strTaiouText.Append(pstrSYONO & gstrPoint)
            strTaiouText.Append(pstrFAX_TITLE & gstrPoint)
            strTaiouText.Append(pstrACBCD & gstrPoint)
            strTaiouText.Append(pstrKURACD & gstrPoint)
            strTaiouText.Append(pstrKANSCD & gstrPoint)
            strTaiouText.Append(pstrJUSYONM & gstrPoint)
            strTaiouText.Append(pstrUSER_CD & gstrPoint)
            strTaiouText.Append(pstrJUTEL1 & gstrPoint)
            strTaiouText.Append(pstrJUTEL2 & gstrPoint)
            strTaiouText.Append(pstrRENTEL & gstrPoint)
            strTaiouText.Append(pstrADDR & gstrPoint)
            strTaiouText.Append(pstrHATYMD & gstrPoint)
            strTaiouText.Append(pstrHATTIME & gstrPoint)
            strTaiouText.Append(pstrKENSIN & gstrPoint)
            strTaiouText.Append(pstrRYURYO & gstrPoint)
            strTaiouText.Append(pstrMETASYU & gstrPoint)
            strTaiouText.Append(pstrKMNM1 & gstrPoint)
            strTaiouText.Append(pstrKMNM2 & gstrPoint)
            strTaiouText.Append(pstrKMNM3 & gstrPoint)
            strTaiouText.Append(pstrKMNM4 & gstrPoint)
            strTaiouText.Append(pstrKMNM5 & gstrPoint)
            strTaiouText.Append(pstrKMNM6 & gstrPoint)
            strTaiouText.Append(pstrTAIOKBN & gstrPoint)
            strTaiouText.Append(pstrTKTANCD & gstrPoint)
            strTaiouText.Append(pstrSYOYMD & gstrPoint)
            strTaiouText.Append(pstrSYOTIME & gstrPoint)
            strTaiouText.Append(pstrSIJIYMD & gstrPoint)
            strTaiouText.Append(pstrSIJITIME & gstrPoint)
            strTaiouText.Append(pstrTAITCD & gstrPoint)
            strTaiouText.Append(pstrTELRCD & gstrPoint)
            strTaiouText.Append(pstrFUK_MEMO & gstrPoint)
            strTaiouText.Append(pstrTEL_MEMO1 & gstrPoint)
            strTaiouText.Append(pstrTEL_MEMO2 & gstrPoint)
            strTaiouText.Append(pstrTEL_MEMO4 & gstrPoint)    '2020/11/01 T.Ono add 2020監視改善
            strTaiouText.Append(pstrTEL_MEMO5 & gstrPoint)    '2020/11/01 T.Ono add 2020監視改善
            strTaiouText.Append(pstrTEL_MEMO6 & gstrPoint)    '2020/11/01 T.Ono add 2020監視改善
            strTaiouText.Append(pstrTKIGCD & gstrPoint)
            strTaiouText.Append(pstrTSADCD & gstrPoint)
            strTaiouText.Append(pstrFAX_REN & gstrPoint)
            strTaiouText.Append(pstrMITOKBN)
            '出力
            strTaiouText.Append(vbCrLf)
            Dim strToMail As String()
            Dim strToMailPass As String()
            Dim FileToStrC As New CFileStr
            Dim strMess As String
            Dim strKANSI_NAME As String = ""
            Dim strBIKOU As String = ""
            Dim strTEL As String = ""
            Dim strExcelName As String = ""
            Dim strKANSI As String()
            '2015/12/09 w.ganeko 2015改善開発 №2
            'strToMail = pstrMAIL.Split("|"c)
            'strToMailPass = pstrMAILPASS.Split("|"c)
            strToMail = pstrMAIL.Split(","c)
            strToMailPass = pstrMAILPASS.Split(","c)
            strKANSI = fncKansiAdress(pstrKANSCD).Split(";"c)
            If strKANSI(0) = "OK" Then
                strKANSI_NAME = strKANSI(1)
                strBIKOU = strKANSI(2)
                strTEL = strKANSI(3)
            End If

            strMess = fncSendMessage(pstrKANSCD, strKANSI_NAME, strBIKOU, strTEL)
            strPotPath = ConfigurationSettings.AppSettings("TEXTPATH") & "00\" & gstrPGCD & "\"

            Dim i As Integer
            For i = 0 To strToMail.Length - 1
                If strToMail(i) <> "" Then
                    'ファイルの作成--------------------------------
                    Dim strSessionID As String = "" & GetRandomPasswordUsingGUID(8)  'セッションの作成(乱数を使用)

                    Dim strFileName As String
                    With FileToStrC
                        .pKencd = "00"
                        .pPgcd = gstrPGCD
                        .pSessionID = strSessionID
                        strFileName = .mStrToFile(strTaiouText.ToString)
                    End With
                    strRec = "OK"
                    strFileNM = FileToStrC.pFileName

                    'EXCELファイル作成
                    strExcelName = "監視対応依頼書" & Now.ToString("yyyyMMdd") & "_" & strSessionID & ".xls"
                    '2015/01/19 T.Ono mod 2014改善開発 [発信者:pstrSEND_NAME]を追加
                    'strExcelNM = mZipExcel(strSessionID, strFileNM, strExcelName, "", "", "", "", "")
                    strExcelNM = mZipExcel(strSessionID, strFileNM, strExcelName, pstrSEND_NAME, "", "", "", "")
                    strZipNM = "監視対応依頼書" & Now.ToString("yyyyMMdd") & "_" & strSessionID & ".zip"

                    'EXCELファイル⇒zipファイル作成
                    fncMakeZipWithPass(strExcelNM, strPotPath & strZipNM, strToMailPass(i))
                    'メール送信zipファイル添付
                    mMailSend(strPotPath & strZipNM, strToMail(i), True, strBIKOU, strMess)
                End If
            Next
            '---------------------------------------------
        Catch ex As Exception
            'エラーが起きたら エラー内容を格納
            strRec = "ERROR:" & ex.ToString
        Finally

        End Try

        Return strRec & strFileNM

    End Function
    Private Function mZipExcel( _
                                            ByVal pstrSessionID As String, _
                                            ByVal pstrTEXT_NAME As String, _
                                            ByVal pstrFILE_NAME As String, _
                                            ByVal pstrSEND_NAME As String, _
                                            ByVal pstrSEND_POST As String, _
                                            ByVal pstrSEND_ADDS As String, _
                                            ByVal pstrSEND_FAX As String, _
                                            ByVal pstrSEND_TEL As String _
                                            ) As String

        Dim strSQL As New StringBuilder("")
        Dim cdb As New CDB
        Dim ds As New DataSet
        Dim dr As DataRow
        Dim ExcelC2 As New CExcel
        Dim UtilFucC As New CUtilFuc

        '改行制御を行う
        'Dim intGYOSU As Integer = 47 ' 2008/02/29 T.Watabe edit
        Dim intGYOSU As Integer = 53
        '日付変換クラス
        Dim DateFncC As New CDateFnc
        'ファイルをBase64にエンコードするクラス
        Dim FileToStrC As New CFileStr

        Dim arrFaxData() As String
        Dim strTaiouTextName As String
        Dim strFaxData As String
        Dim strTaiouText As String

        ReDim gstrRecText(0)

        '接続OPEN----------------------------------------
        Try
            cdb.mOpen()
        Catch ex As Exception
            Return ex.ToString
        Finally

        End Try

        Dim strRec As String = "OK"
        Try
            gstrPATH = ConfigurationSettings.AppSettings("TEXTPATH") & "\00\"
            '対応入力データテキスト
            strTaiouTextName = gstrPGCD & "\" & pstrTEXT_NAME

            '//------------------------------------------------------------
            '対応入力データファイルを読み込む
            strRec = fncTaiouRecv(strTaiouTextName, strTaiouText)
            If strRec <> "OK" Then
                Return strRec
            End If

            '//">"区切りデータを取得　配列に格納
            If strTaiouText.Length <> 0 Then
                arrFaxData = strTaiouText.Split(Convert.ToChar(gstrPoint))
            End If

            '//データセット ----------------------------------
            Dim strSYONO As String = arrFaxData(0)                          '処理番号
            Dim strFAXTITLE As String = arrFaxData(1)                       'ＦＡＸタイトル
            Dim strACBCD As String = arrFaxData(2)                          'ＪＡ支所コード
            Dim strKURACD As String = arrFaxData(3)                         'クライアントコード
            Dim strKANSCD As String = arrFaxData(4)                         '監視センターコード
            Dim strJUSYONM As String = arrFaxData(5)                        'お客様氏名
            Dim strUSER_CD As String = arrFaxData(6)                        'お客様コード
            Dim strJUTEL1 As String = arrFaxData(7)                         '自宅電話市外
            Dim strJUTEL2 As String = arrFaxData(8)                         '自宅電話市内
            Dim strRENTEL As String = arrFaxData(9)                         '連絡電話番号
            Dim strADDR As String = arrFaxData(10)                          '住所
            Dim strHATYMD As String = arrFaxData(11)                        '発生日
            Dim strHATTIME As String = arrFaxData(12)                       '発生時刻
            Dim strKENSIN As String = arrFaxData(13)                        'メータ値
            Dim strRYURYO As String = arrFaxData(14)                        '流量区分
            Dim strMETASYU As String = arrFaxData(15)                       'メータ種別
            Dim strKMNM1 As String = arrFaxData(16)                         '警報メッセージ１
            Dim strKMNM2 As String = arrFaxData(17)                         '警報メッセージ２
            Dim strKMNM3 As String = arrFaxData(18)                         '警報メッセージ３
            Dim strKMNM4 As String = arrFaxData(19)                         '警報メッセージ４
            Dim strKMNM5 As String = arrFaxData(20)                         '警報メッセージ５
            Dim strKMNM6 As String = arrFaxData(21)                         '警報メッセージ６
            Dim strTAIOKBN As String = fncGET_PULLNM("09", arrFaxData(22))  '対応区分
            Dim strTKTANCD As String = arrFaxData(23)                       '監視センター担当者
            Dim strSYOYMD As String = arrFaxData(24)                        '対応完了日
            Dim strSYOTIME As String = arrFaxData(25)                       '対応完了時刻
            Dim strSIJIYMD As String = arrFaxData(26)                       '出動指示日
            Dim strSIJITIME As String = arrFaxData(27)                      '出動指示時刻
            Dim strTAITCD As String = fncGET_PULLNM("12", arrFaxData(28))   '連絡相手
            Dim strTELRCD As String = fncGET_PULLNM("15", arrFaxData(29))   '電話連絡内容
            Dim strFUK_MEMO As String = arrFaxData(30)                      '復帰操作メモ
            Dim strTEL_MEMO1 As String = arrFaxData(31)                     '電話メモ１
            Dim strTEL_MEMO2 As String = arrFaxData(32)                     '電話メモ２
            '2020/11/01 T.Ono mod 2020監視改善 Start
            'Dim strTKIGCD As String = fncGET_PULLNM("16", arrFaxData(33))   '原因器具
            'Dim strTSADCD As String = fncGET_PULLNM("17", arrFaxData(34))   '作動原因
            'Dim strFAX_REN As String = arrFaxData(35)                       '依頼内容
            'Dim strMITOKBN As String = arrFaxData(36)                       '未登録ＦＬＧ
            Dim strTEL_MEMO4 As String = arrFaxData(33)                     '電話メモ４
            Dim strTEL_MEMO5 As String = arrFaxData(34)                     '電話メモ５
            Dim strTEL_MEMO6 As String = arrFaxData(35)                     '電話メモ６ 
            Dim strTKIGCD As String = fncGET_PULLNM("16", arrFaxData(36))   '原因器具
            Dim strTSADCD As String = fncGET_PULLNM("17", arrFaxData(37))   '作動原因
            Dim strFAX_REN As String = arrFaxData(38)                       '依頼内容
            Dim strMITOKBN As String = arrFaxData(39)                       '未登録ＦＬＧ
            '2020/11/01 T.Ono mod 2020監視改善 End
            '//------------------------------------------------
            Dim strMAP_CD As String                                         '地図番号
            Dim strUSER_FLG As String                                       'お客様状態
            '県コードをセット
            'If strKURACD.Length <> 0 Then
            'ExcelC.pKencd = strKURACD.Substring(1, 2)
            'Else
            ExcelC2.pKencd = "00"
            'End If
            'セッションID
            ExcelC2.pSessionID = pstrSessionID

            '帳票ID
            ExcelC2.pRepoID = gstrPGCD

            '帳票縦
            ExcelC2.pLandScape = False

            'ファイルオープン
            ExcelC2.mOpen()

            'タイトル
            ExcelC2.pTitle = strFAXTITLE

            '作成日
            ExcelC2.pDate = DateFncC.mGet(Now.ToString("yyyyMMdd"))

            '縮小拡大率
            ExcelC2.pScale = 100

            '余白
            ExcelC2.pMarginTop = 1.8D
            ExcelC2.pMarginBottom = 0D
            ExcelC2.pMarginLeft = 1.2D
            ExcelC2.pMarginRight = 1.5D
            ExcelC2.pMarginHeader = 1.3D
            ExcelC2.pMarginFooter = 0D

            'ヘッダ項目をセット。（1ページあたり行数、出力行数、先頭行から何行目までが行タイトルか）
            ExcelC2.mHeader(intGYOSU, intGYOSU, 1)

            '各列の幅をピクセルでセット。枠線も消す。
            '1行目
            ExcelC2.pCellStyle(1) = "width:32px;border-style:none"
            ExcelC2.pCellStyle(2) = "width:103px;border-style:none"
            ExcelC2.pCellStyle(3) = "width:72px;border-style:none"
            ExcelC2.pCellStyle(4) = "width:72px;border-style:none"
            ExcelC2.pCellStyle(5) = "width:72px;border-style:none"
            ExcelC2.pCellStyle(6) = "width:72px;border-style:none"
            ExcelC2.pCellStyle(7) = "width:72px;border-style:none"
            ExcelC2.pCellStyle(8) = "width:72px;border-style:none"
            ExcelC2.pCellStyle(9) = "width:72px;border-style:none"
            ExcelC2.pCellStyle(10) = "width:80px;border-style:none"
            ExcelC2.pCellVal(1) = ""
            ExcelC2.pCellVal(2) = ""
            ExcelC2.pCellVal(3) = ""
            ExcelC2.pCellVal(4) = ""
            ExcelC2.pCellVal(5) = ""
            ExcelC2.pCellVal(6) = ""
            ExcelC2.pCellVal(7) = ""
            ExcelC2.pCellVal(8) = ""
            ExcelC2.pCellVal(9) = ""
            ExcelC2.pCellVal(10) = ""
            ExcelC2.mWriteLine("")   '行をファイルに書き込む

            '--------------------------------------------------
            'データの取得
            '--------------------------------------------------
            strSQL.Append("SELECT ")
            strSQL.Append("JA.JA_NAME, ")
            strSQL.Append("JA.JAS_NAME, ")
            strSQL.Append("CL.KEN_NAME, ")
            strSQL.Append("HA.NAME AS HAISO_NAME, ")
            strSQL.Append("KA.KANSI_NAME, ")
            strSQL.Append("KA.TEL, ")
            strSQL.Append("KA.KINKYU_TEL, ") ' 2010/03/24 T.Watabe add 監視ｾﾝﾀｰFAX番号
            strSQL.Append("TA.TANNM ")
            strSQL.Append("FROM HN2MAS JA, ")
            strSQL.Append("     CLIMAS CL, ")
            strSQL.Append("     HAIMAS HA, ")
            strSQL.Append("     KANSIMAS KA, ")
            strSQL.Append("     M05_TANTO TA ")
            strSQL.Append("WHERE CL.CLI_CD = :KURACD ")
            strSQL.Append("  AND CL.CLI_CD = JA.CLI_CD(+) ")
            strSQL.Append("  AND :ACBCD = JA.HAN_CD(+) ")
            strSQL.Append("  AND SUBSTR(JA.CLI_CD,2,2) = HA.KEN_CD(+) ")
            strSQL.Append("  AND JA.HAISO_CD = HA.HAISO_CD(+) ")
            strSQL.Append("  AND CL.KANSI_CODE = KA.KANSI_CD(+) ")
            strSQL.Append("  AND '1' = TA.KBN(+) ")
            strSQL.Append("  AND 'ZZZZ' = TA.KURACD(+) ")
            strSQL.Append("  AND CL.KANSI_CODE = TA.CODE(+) ")
            strSQL.Append("  AND :TKTANCD = TA.TANCD(+) ")


            '//SQLセット
            cdb.pSQL = strSQL.ToString
            '//パラメータセット
            cdb.pSQLParamStr("KURACD") = strKURACD
            cdb.pSQLParamStr("ACBCD") = strACBCD
            cdb.pSQLParamStr("TKTANCD") = strTKTANCD

            '//SQL実行
            cdb.mExecQuery()
            '//データセットに格納
            ds = cdb.pResult
            '//データが存在しない場合
            If ds.Tables(0).Rows.Count = 0 Then
            Else
                '//データを格納
                dr = ds.Tables(0).Rows(0)
            End If

            '2006/06/09 NEC ADD START
            Dim dsShamas As New DataSet
            Dim drShamas As DataRow
            Dim strSQL_Shamas As New StringBuilder("")

            strSQL_Shamas.Append("SELECT ")
            strSQL_Shamas.Append("MAP_CD, ")        '地図番号
            strSQL_Shamas.Append("USER_FLG ")      'お客様状態
            strSQL_Shamas.Append("FROM SHAMAS ")
            strSQL_Shamas.Append("WHERE CLI_CD=:CLI_CD AND ")
            strSQL_Shamas.Append(" HAN_CD=:HAN_CD AND ")
            strSQL_Shamas.Append(" USER_CD=:USER_CD ")

            '//SQLセット
            cdb.pSQL = strSQL_Shamas.ToString
            '//パラメータセット
            cdb.pSQLParamStr("CLI_CD") = strKURACD
            cdb.pSQLParamStr("HAN_CD") = strACBCD
            cdb.pSQLParamStr("USER_CD") = strUSER_CD

            '//SQL実行
            cdb.mExecQuery()
            '//データセットに格納
            dsShamas = cdb.pResult
            '//データが存在しない場合
            If dsShamas.Tables(0).Rows.Count = 0 Then
                strSQL_Shamas.Remove(0, strSQL_Shamas.Length)
                strSQL_Shamas.Append("SELECT ")
                strSQL_Shamas.Append("'' AS MAP_CD, ")        '地図番号
                strSQL_Shamas.Append("'' AS USER_FLG ")      'お客様状態
                strSQL_Shamas.Append("FROM DUAL ")

                '//SQLセット
                cdb.pSQL = strSQL_Shamas.ToString

                '//SQL実行
                cdb.mExecQuery()
                '//データセットに格納
                dsShamas = cdb.pResult
                '//データを格納
                drShamas = dsShamas.Tables(0).Rows(0)
            Else
                '//データを格納
                drShamas = dsShamas.Tables(0).Rows(0)
            End If

            '--------------------------------------------------
            'データの出力
            '--------------------------------------------------
            Dim strTemp As String = ""

            '2行目
            ExcelC2.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC2.pCellVal(1, "colspan=10") = "送信先FAX番号：" & pstrSEND_TEL
            ExcelC2.mWriteLine("")   '行をファイルに書き込む

            '3行目
            ExcelC2.pCellStyle(1) = "border-style:none;font-size:13pt"
            If ds.Tables(0).Rows.Count = 0 Then
                strTemp = ""
            Else
                If Convert.ToString(dr.Item("JAS_NAME")) = "" Then
                    strTemp = ""
                Else
                    strTemp = Convert.ToString(dr.Item("JAS_NAME")) & "　御中"
                End If
            End If
            ExcelC2.pCellVal(1, "colspan=10") = "ＪＡ支所名　 ：" & strTemp
            ExcelC2.mWriteLine("")   '行をファイルに書き込む

            '4行目
            ExcelC2.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC2.pCellStyle(2) = "border-style:none;font-size:13pt"
            ExcelC2.pCellStyle(3) = "border-style:none;font-size:13pt"
            ExcelC2.pCellVal(1, "colspan=4") = ""
            ExcelC2.pCellVal(2, "colspan=2") = ""
            If ds.Tables(0).Rows.Count = 0 Then
                strTemp = ""
            Else
                strTemp = Convert.ToString(dr.Item("TEL"))
            End If
            ExcelC2.pCellVal(3, "colspan=4 align=right") = "発信者TEL：" & strTemp
            ExcelC2.mWriteLine("")   '行をファイルに書き込む

            '4行目
            ExcelC2.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC2.pCellStyle(2) = "border-style:none;font-size:13pt"
            ExcelC2.pCellStyle(3) = "border-style:none;font-size:13pt"
            ExcelC2.pCellVal(1, "colspan=4") = ""
            ExcelC2.pCellVal(2, "colspan=2") = ""
            If ds.Tables(0).Rows.Count = 0 Then
                strTemp = ""
            Else
                strTemp = Convert.ToString(dr.Item("KINKYU_TEL"))
            End If
            ExcelC2.pCellVal(3, "colspan=4 align=right") = "発信者FAX：" & strTemp
            ExcelC2.mWriteLine("")   '行をファイルに書き込む

            '5行目
            ExcelC2.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC2.pCellStyle(2) = "border-style:none;font-size:13pt"
            If ds.Tables(0).Rows.Count = 0 Then
                strTemp = ""
            Else
                strTemp = Convert.ToString(dr.Item("KEN_NAME"))
            End If
            ExcelC2.pCellVal(1, "colspan=5") = "県　　　名　 ：" & strTemp
            ExcelC2.pCellVal(2, "colspan=5 align=right") = "発信者：" & pstrSEND_NAME
            ExcelC2.mWriteLine("")   '行をファイルに書き込む

            '6行目
            ExcelC2.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC2.pCellStyle(2) = "border-style:none;font-size:13pt"
            If ds.Tables(0).Rows.Count = 0 Then
                strTemp = ""
            Else
                strTemp = Convert.ToString(dr.Item("HAISO_NAME"))
            End If
            ExcelC2.pCellVal(1, "colspan=5") = "供給ｾﾝﾀｰ名　 ：" & strTemp
            If ds.Tables(0).Rows.Count = 0 Then
                strTemp = ""
            Else
                strTemp = Convert.ToString(dr.Item("KANSI_NAME"))
            End If
            ExcelC2.pCellVal(2, "colspan=5 align=right") = strTemp
            ExcelC2.mWriteLine("")   '行をファイルに書き込む

            '7行目
            '2020/11/01 T.Ono del 2020監視改善
            'ExcelC2.mWriteLine("")   '行をファイルに書き込む

            '7行目
            ExcelC2.pCellStyle(1) = "border-bottom-style:none;border-left-style:none;border-right-style:none;font-size:13pt"
            ExcelC2.pCellVal(1, "colspan=10") = ""
            ExcelC2.mWriteLine("")   '行をファイルに書き込む

            '9行目
            ExcelC2.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC2.pCellVal(1, "colspan=10") = "<<受信情報>>"
            ExcelC2.mWriteLine("")   '行をファイルに書き込む

            '10行目
            ExcelC2.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC2.pCellStyle(2) = "border-style:none;font-size:13pt"
            '2015/02/27 H.Hosoda mod 2014改善開発 No.5 START
            'ExcelC2.pCellVal(1, "colspan=7") = "お客様氏名：" & strJUSYONM
            ExcelC2.pCellVal(1, "colspan=7") = "お客様名　：" & strJUSYONM
            '2015/02/27 H.Hosoda mod 2014改善開発 No.5 END

            If dsShamas.Tables(0).Rows.Count = 0 Then
                strTemp = ""
            Else
                strTemp = Convert.ToString(drShamas.Item("MAP_CD"))
            End If
            '2015/02/27 H.Hosoda mod 2014改善開発 No.5 START
            'ExcelC2.pCellVal(2, "colspan=3") = "地図Ｎｏ　：" & strTemp
            ExcelC2.pCellVal(2, "colspan=3") = "地図番号　：" & strTemp
            '2015/02/27 H.Hosoda mod 2014改善開発 No.5 END
            ExcelC2.mWriteLine("")   '行をファイルに書き込む

            '11行目
            ExcelC2.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC2.pCellStyle(2) = "border-style:none;font-size:13pt"
            ExcelC2.pCellVal(1, "colspan=7") = "お客様ｺｰﾄﾞ：" & strACBCD & strUSER_CD
            If dsShamas.Tables(0).Rows.Count = 0 Then
                strTemp = ""
            Else
                strTemp = Convert.ToString(drShamas.Item("USER_FLG"))
            End If

            Select Case strTemp
                Case "0"
                    '0:未開通
                    ExcelC2.pCellVal(2, "colspan=3") = "お客様状態：" & "未開通"
                Case "1"
                    '1:運用中
                    ExcelC2.pCellVal(2, "colspan=3") = "お客様状態：" & "運用中"
                Case "2"
                    '2:休止中
                    ExcelC2.pCellVal(2, "colspan=3") = "お客様状態：" & "休止中"
                Case Else
                    'その他
                    ExcelC2.pCellVal(2, "colspan=3") = "お客様状態："
            End Select
            ExcelC2.mWriteLine("")   '行をファイルに書き込む

            '12行目
            ExcelC2.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC2.pCellStyle(2) = "border-style:none;font-size:13pt"
            '2015/02/27 H.Hosoda mod 2014改善開発 No.5 START
            'If strJUTEL1 = "" Or strJUTEL2 = "" Then
            '    ExcelC2.pCellVal(1, "colspan=5") = "電話番号　：" & strJUTEL1 & strJUTEL2
            'Else
            '    ExcelC2.pCellVal(1, "colspan=5") = "電話番号　：" & strJUTEL1 & "-" & strJUTEL2
            'End If
            'ExcelC2.pCellVal(2, "colspan=5") = "連絡電話番号：" & strRENTEL
            If strJUTEL1 = "" Or strJUTEL2 = "" Then
                ExcelC2.pCellVal(1, "colspan=5") = "結線番号　：" & strJUTEL1 & strJUTEL2
            Else
                ExcelC2.pCellVal(1, "colspan=5") = "結線番号　：" & strJUTEL1 & "-" & strJUTEL2
            End If
            ExcelC2.pCellVal(2, "colspan=5") = "連絡先：" & strRENTEL
            '2015/02/27 H.Hosoda mod 2014改善開発 No.5 END
            ExcelC2.mWriteLine("")   '行をファイルに書き込む

            '13行目
            ExcelC2.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC2.pCellVal(1, "colspan=10") = "住所　　　：" & strADDR
            ExcelC2.mWriteLine("")   '行をファイルに書き込む

            '14行目
            ExcelC2.mWriteLine("")   '行をファイルに書き込む

            '15行目
            ExcelC2.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC2.pCellVal(1, "colspan=10") = "【警報内容】"
            ExcelC2.mWriteLine("")   '行をファイルに書き込む

            '16行目
            ExcelC2.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC2.pCellStyle(2) = "border-style:none;font-size:13pt"
            '2015/02/27 H.Hosoda mod 2014改善開発 No.5 START
            'ExcelC2.pCellVal(1, "colspan=4") = "発生日　　：" & strHATYMD & " " & strHATTIME
            ExcelC2.pCellVal(1, "colspan=4") = "受信日時　：" & strHATYMD & " " & strHATTIME
            '2015/02/27 H.Hosoda mod 2014改善開発 No.5 END
            ExcelC2.pCellVal(2, "colspan=6") = "メータ値　：" & strKENSIN
            ExcelC2.mWriteLine("")   '行をファイルに書き込む

            '17行目
            ExcelC2.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC2.pCellStyle(2) = "border-style:none;font-size:13pt"
            ExcelC2.pCellVal(1, "colspan=4") = "流量区分　：" & strRYURYO
            ExcelC2.pCellVal(2, "colspan=6") = "メータ種別：" & strMETASYU
            ExcelC2.mWriteLine("")   '行をファイルに書き込む

            '18行目
            ExcelC2.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC2.pCellStyle(2) = "border-style:none;font-size:13pt"
            ExcelC2.pCellVal(1, "colspan=5") = "1：" & strKMNM1
            ExcelC2.pCellVal(2, "colspan=5") = "4：" & strKMNM4
            ExcelC2.mWriteLine("")   '行をファイルに書き込む

            '19行目
            ExcelC2.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC2.pCellStyle(2) = "border-style:none;font-size:13pt"
            ExcelC2.pCellVal(1, "colspan=5") = "2：" & strKMNM2
            ExcelC2.pCellVal(2, "colspan=5") = "5：" & strKMNM5
            ExcelC2.mWriteLine("")   '行をファイルに書き込む

            '20行目
            ExcelC2.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC2.pCellStyle(2) = "border-style:none;font-size:13pt"
            ExcelC2.pCellVal(1, "colspan=5") = "3：" & strKMNM3
            ExcelC2.pCellVal(2, "colspan=5") = "6：" & strKMNM6
            ExcelC2.mWriteLine("")   '行をファイルに書き込む

            '21行目
            '2020/11/01 T.Ono mod 2020監視改善
            'ExcelC2.mWriteLine("")   '行をファイルに書き込む

            '22行目
            '2020/11/01 T.Ono mod 2020監視改善
            'ExcelC2.pCellStyle(1) = "border-bottom-style:none;border-left-style:none;border-right-style:none;font-size:13pt"
            'ExcelC2.pCellVal(1, "colspan=10") = ""
            'ExcelC2.mWriteLine("")   '行をファイルに書き込む

            '21行目
            'ExcelC2.pCellStyle(1) = "border-style:none;font-size:13pt"    2020/11/01 T.Ono mod 2020監視改善
            ExcelC2.pCellStyle(1) = "border-bottom-style:none;border-left-style:none;border-right-style:none;font-size:13pt"
            ExcelC2.pCellVal(1, "colspan=10") = "<<監視センター対応内容>>"
            ExcelC2.mWriteLine("")   '行をファイルに書き込む

            '22行目
            ExcelC2.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC2.pCellStyle(2) = "border-style:none;font-size:13pt"
            ExcelC2.pCellVal(1, "colspan=5") = "対応区分　　：" & strTAIOKBN
            ExcelC2.pCellVal(2, "colspan=5") = "処理番号(照会用)：" & strSYONO
            ExcelC2.mWriteLine("")   '行をファイルに書き込む

            '23行目
            ExcelC2.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC2.pCellStyle(2) = "border-style:none;font-size:13pt"
            If ds.Tables(0).Rows.Count = 0 Then
                strTemp = ""
            Else
                strTemp = Convert.ToString(dr.Item("TANNM"))
            End If
            ExcelC2.pCellVal(1, "colspan=5") = "監視ｾﾝﾀｰ担当：" & strTemp
            'ExcelC2.pCellVal(2, "colspan=5") = "対応日：" & strSYOYMD & " " & strSYOTIME 2008/10/14 T.Watabe edit
            '2015/02/27 H.Hosoda mod 2014改善開発 No.5 START
            'ExcelC2.pCellVal(2, "colspan=5") = "完了日時　　　　：" & strSYOYMD & " " & strSYOTIME
            ExcelC2.pCellVal(2, "colspan=5") = "対応完了日時　　：" & strSYOYMD & " " & strSYOTIME
            '2015/02/27 H.Hosoda mod 2014改善開発 No.5 END
            ExcelC2.mWriteLine("")   '行をファイルに書き込む

            '24行目
            ExcelC2.pCellStyle(1) = "border-style:none;font-size:13pt"
            '2015/02/27 H.Hosoda mod 2014改善開発 No.5 START
            'ExcelC2.pCellVal(1, "colspan=10") = "依頼日　　　：" & strSIJIYMD & " " & strSIJITIME
            ExcelC2.pCellVal(1, "colspan=10") = "依頼日時　　：" & strSIJIYMD & " " & strSIJITIME
            '2015/02/27 H.Hosoda mod 2014改善開発 No.5 END
            ExcelC2.mWriteLine("")   '行をファイルに書き込む

            '25行目
            ExcelC2.mWriteLine("")   '行をファイルに書き込む

            '26行目
            ExcelC2.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC2.pCellVal(1, "colspan=10") = "連絡相手　　：" & strTAITCD
            ExcelC2.mWriteLine("")   '行をファイルに書き込む

            '27行目
            ExcelC2.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC2.pCellVal(1, "colspan=10") = "電話連絡内容：" & strTELRCD
            ExcelC2.mWriteLine("")   '行をファイルに書き込む

            '28行目
            ExcelC2.pCellStyle(1) = "border-style:none"
            'ExcelC2.pCellStyle(2) = "border-style:none;height:72px;vertical-align:top" '高さ指定すると、他行が可変高にならず１行になってしまう。
            ExcelC2.pCellStyle(2) = "border-style:none;vertical-align:top"
            ExcelC2.pCellVal(1) = ""
            'ExcelC2.pCellVal(2, "colspan=9") = strTEL_MEMO1 & strTEL_MEMO2 & strFUK_MEMO  2020/11/01 T.Ono mod 2020監視改善
            ExcelC2.pCellVal(2, "colspan=9") = strTEL_MEMO1 & strTEL_MEMO2 & strFUK_MEMO & strTEL_MEMO4 & strTEL_MEMO5 & strTEL_MEMO6
            ExcelC2.mWriteLine("")   '行をファイルに書き込む

            '29行目
            ExcelC2.pCellStyle(1) = "border-style:none;height:6pt"    '2020/11/01 T.Ono add 2020監視改善
            ExcelC2.pCellVal(1, "colspan=10") = ""    '2020/11/01 T.Ono add 2020監視改善
            ExcelC2.mWriteLine("")   '行をファイルに書き込む

            '30行目
            ExcelC2.pCellStyle(1) = "border-style:none;font-size:13pt"
            '2015/02/27 H.Hosoda mod 2014改善開発 No.5 START
            'ExcelC2.pCellVal(1, "colspan=10") = "原因器具名　：" & strTKIGCD
            ExcelC2.pCellVal(1, "colspan=10") = "原因器具　　：" & strTKIGCD
            '2015/02/27 H.Hosoda mod 2014改善開発 No.5 END
            ExcelC2.mWriteLine("")   '行をファイルに書き込む

            '31行目
            ExcelC2.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC2.pCellVal(1, "colspan=10") = "作動原因　　：" & strTSADCD
            ExcelC2.mWriteLine("")   '行をファイルに書き込む

            '37行目
            '2020/11/01 T.Ono del 2020監視改善
            ''2015/05/14 H.Mori mod メモ欄のひとつ上の行を縮小 START
            ''ExcelC2.mWriteLine("")   '行をファイルに書き込む
            'ExcelC2.pCellStyle(1) = "border-style:none;height:9pt"
            'ExcelC2.pCellVal(1) = ""
            'ExcelC2.mWriteLine("")   '行をファイルに書き込む
            ''2015/05/14 H.Mori mod メモ欄のひとつ上の行を縮小 END

            '32行目
            '2015/04/30 H.Mori mod メモ欄を拡大 
            'ExcelC2.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC2.pCellStyle(1) = "border-style:none;height:47pt;vertical-align:top;font-size:13pt"
            '2015/02/27 H.Hosoda mod 2014改善開発 No.5 START
            'ExcelC2.pCellVal(1, "colspan=10") = "依頼内容　　：" & strFAX_REN
            ExcelC2.pCellVal(1, "colspan=10") = "メモ欄　　　：" & strFAX_REN
            '2015/02/27 H.Hosoda mod 2014改善開発 No.5 END
            ExcelC2.mWriteLine("")   '行をファイルに書き込む

            '33行目
            ExcelC2.pCellStyle(1) = "border-style:none;font-size:13pt"
            '2021/02/12 T.Ono mod この文言は表示しない Start
            ''If strMITOKBN = "1" Then '2020/11/01 T.Ono mod
            'If strMITOKBN.Substring(0, 1) = "1" Then
            '    ExcelC2.pCellVal(1, "colspan=10") = "「お客様マスター　氏名、住所、電話番号をご確認の上、ご連絡ください。」"
            'Else
            '    ExcelC2.pCellVal(1, "colspan=10") = ""
            'End If
            ExcelC.pCellVal(1, "colspan=10") = ""
            '2021/02/12 T.Ono mod この文言は表示しない Start
            ExcelC2.mWriteLine("")   '行をファイルに書き込む

            '34行目～44行目
            ExcelC2.pCellStyle(1) = "border:.5pt solid black; height:23.25pt; font-size:12pt"
            ExcelC2.pCellVal(1, "colspan=3") = "事業所名："
            ExcelC2.pCellStyle(4) = "border:.5pt solid black;font-size:12pt"
            ExcelC2.pCellVal(4, "colspan=3") = "対応者名："
            ExcelC2.pCellStyle(7) = "border:.5pt solid black;font-size:12pt"
            ExcelC2.pCellVal(7, "colspan=4") = "対応日時："
            ExcelC2.mWriteLine("")   '行をファイルに書き込む

            ExcelC2.pCellStyle(1) = "border:.5pt solid black; height:195.0pt;width:24pt;font-size:13pt;background:silver;layout-flow:vertical"
            '2015/04/30 H.Mori mod 対応結果を一行分削除 
            'ExcelC.pCellVal(1, "rowspan=11") = "対応結果"
            ExcelC2.pCellVal(1, "rowspan=10") = "対応結果"
            ExcelC2.pCellStyle(2) = "border-right:.5pt solid black;font-size:12pt"
            '2015/04/30 H.Mori mod 対応結果を一行分削除 
            'ExcelC2.pCellVal(2, "colspan=9 rowspan=9") = "　"
            ExcelC2.pCellVal(2, "colspan=9 rowspan=8") = "　"
            ExcelC2.mWriteLine("")   '行をファイルに書き込む
            ExcelC2.mWriteLine("")   '行をファイルに書き込む
            ExcelC2.mWriteLine("")   '行をファイルに書き込む
            ExcelC2.mWriteLine("")   '行をファイルに書き込む
            ExcelC2.mWriteLine("")   '行をファイルに書き込む
            ExcelC2.mWriteLine("")   '行をファイルに書き込む
            ExcelC2.mWriteLine("")   '行をファイルに書き込む
            ExcelC2.mWriteLine("")   '行をファイルに書き込む
            '2015/04/30 H.Mori del 対応結果を一行分削除 
            'ExcelC2.mWriteLine("")   '行をファイルに書き込む

            ExcelC2.pCellStyle(2) = "border-right:.5pt solid black; height:21.0pt;font-size:12pt"
            ExcelC2.pCellVal(2, "colspan=9") = "完了日時："
            ExcelC2.mWriteLine("")   '行をファイルに書き込む

            ExcelC2.pCellStyle(2) = "border-right:.5pt solid black; height:21.0pt;font-size:12pt"
            ExcelC2.pCellVal(2, "colspan=9") = "報告日時："
            ExcelC2.mWriteLine("")   '行をファイルに書き込む


            'フッタ項目の書き出しと、ファイルクローズ
            ExcelC2.mClose()

            '//テキストデータファイルの削除
            Kill(gstrPATH & strTaiouTextName)

            '作成したファイルをBase64エンコードして戻す
            'Return FileToStrC.mFileToStr(ExcelC2.pDirName & ExcelC2.pFileName & ".xls")
            System.IO.File.Move(ExcelC2.pDirName & ExcelC2.pFileName & ".xls", ExcelC2.pDirName & pstrFILE_NAME)
            Return ExcelC2.pDirName & pstrFILE_NAME

        Catch ex As Exception
            'エラーの内容とＳＱＬ文を返す
            Return "ERROR:" & ex.ToString

        Finally
            '接続クローズ
            cdb.mClose()
            ExcelC2 = Nothing
        End Try

    End Function
    '******************************************************************************
    '*　概　要：ファイルの圧縮(zip) ICSharpCode.SharpZipLib.dll使用(要参照設定)
    '*　備　考：
    '******************************************************************************
    Private Sub fncMakeZipWithPass(ByVal sXlsFilePath As String, ByVal sZipFilePath As String, ByVal sPass As String)

        '圧縮するファイルの設定 
        'Dim filePaths(100) As String
        Dim crc As ICSharpCode.SharpZipLib.Checksums.Crc32

        Dim writer As System.IO.FileStream
        Dim zos As ICSharpCode.SharpZipLib.Zip.ZipOutputStream
        Dim f As String
        Dim fs As System.IO.FileStream
        Dim buffer() As Byte
        Dim ze As ICSharpCode.SharpZipLib.Zip.ZipEntry

        Dim file As String
        'filePaths(0) = sXlsFilePath

        If Len(sPass) <= 0 Then
            sPass = "jalp" 'パスワードのデフォルトはjalp
        End If
        crc = New ICSharpCode.SharpZipLib.Checksums.Crc32
        writer = New System.IO.FileStream( _
                        sZipFilePath, System.IO.FileMode.Create, _
                        System.IO.FileAccess.Write, _
                        System.IO.FileShare.Write)
        zos = New ICSharpCode.SharpZipLib.Zip.ZipOutputStream(writer)

        ' 圧縮レベルを設定する 
        zos.SetLevel(6)
        ' パスワードを設定する 
        zos.Password = sPass

        ' Zipにファイルを追加する 
        If True Then
            'For Each file As String In filePaths '(複数ファイルを１つのzipに圧縮することもできる。)
            file = sXlsFilePath

            ' ZIPに追加するときのファイル名を決定する 
            f = System.IO.Path.GetFileName(file)
            ze = New ICSharpCode.SharpZipLib.Zip.ZipEntry(f)
            ze.CompressionMethod = ICSharpCode.SharpZipLib.Zip.CompressionMethod.Stored 'この1行でWindows標準でのPASS解凍問題が解決！？

            ' ヘッダを設定する 
            ' ファイルを読み込む 
            fs = New System.IO.FileStream( _
                        file, _
                        System.IO.FileMode.Open, _
                        System.IO.FileAccess.Read, _
                        System.IO.FileShare.Read)
            ReDim buffer(CInt(fs.Length))

            fs.Read(buffer, 0, buffer.Length)
            fs.Close()
            ' CRCを設定する 
            crc.Reset()
            crc.Update(buffer)
            ze.Crc = crc.Value
            ' サイズを設定する 
            ze.Size = buffer.Length

            ' 時間を設定する 
            ze.DateTime = DateTime.Now

            ' 新しいエントリの追加を開始 
            zos.PutNextEntry(ze)
            ' 書き込む 
            zos.Write(buffer, 0, buffer.Length)

            'Next
        End If

        zos.Close()
        writer.Close()
        Kill(sXlsFilePath)

    End Sub
    '**************************************************************************************************
    ' メール送信処理
    '  パラメータ：pstrDataFile　　送信するファイルパス
    '　　　　　　：pstrMailAddress 送信先メールアドレス
    '　　　　　　：pbolFileCheck   ファイルチェックフラグ
    '**************************************************************************************************
    Private Sub mMailSend( _
                        ByVal pstrDataFile As String, _
                        ByVal pstrMailAddress As String, _
                        ByVal pbolFileCheck As Boolean, _
                        ByVal pstrSEND_MAILADDRESS As String, _
                        ByVal pstrSEND_BODY As String _
                        )
        Dim strResult As String = ""

        Try
            Dim mm As New System.Web.Mail.MailMessage
            Dim attachment As System.Web.Mail.MailAttachment
            '2018/10/16 del BCCをつけると2重送信されてしまうため外す
            'Dim strSEND_BCC As String = pstrSEND_MAILADDRESS '監視センターメールアドレスにBCCで送信
            Dim strSEND_BCC As String = "" '監視センターメールアドレスにBCCで送信
            Dim strSEND_SUBJECT As String = "対応依頼書（送付）"
            Dim strSEND_SMTP As String = ConfigurationSettings.AppSettings("MAIL_SMTP")

            '=== SMTP認証 ===
            mm.Fields.Item("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate") = 1 'smtpauthenticate = 1:SMTP認証
            mm.Fields.Item("http://schemas.microsoft.com/cdo/configuration/sendusername") = "jalp" ' 集中監視センターのユーザID
            mm.Fields.Item("http://schemas.microsoft.com/cdo/configuration/sendpassword") = "jalp"

            '=== チェック ===
            If strResult.Length > 0 Then Exit Sub
            If pbolFileCheck Then '2010/07/02 T.Watabe add
                If System.IO.File.Exists(pstrDataFile) = False Then
                    strResult = "ERROR:対象ファイルが存在しません。[" & pstrDataFile & "]"
                    Debug.WriteLine("mMailSend チェック [" & pstrDataFile & " は存在しません]")
                End If
                If strResult.Length > 0 Then Exit Sub
            End If

            '=== メール送信部分 === 
            '//送信者
            mm.From = pstrSEND_MAILADDRESS
            '//送信先
            mm.To = pstrMailAddress
            '//確認用としてBCCで送信する
            If strSEND_BCC <> Nothing Then
                If strSEND_BCC.Length > 0 Then
                    mm.Bcc = strSEND_BCC
                End If
            End If
            '//題名
            mm.Subject = strSEND_SUBJECT
            '//本文
            mm.Body = pstrSEND_BODY
            '//JISコードに変換する
            mm.BodyEncoding = System.Text.Encoding.GetEncoding(50220)
            If pstrDataFile.Length > 0 Then ' 2010/01/19 T.Watabe add ファイルチェックを追加
                '//添付ファイルの指定
                attachment = New System.Web.Mail.MailAttachment(pstrDataFile)
                mm.Attachments.Add(attachment)
            End If
            '//SMTPサーバーを指定する
            System.Web.Mail.SmtpMail.SmtpServer = strSEND_SMTP
            '//送信する
            System.Web.Mail.SmtpMail.Send(mm)
            strResult = "OK"
        Catch ex As Exception

            strResult = "ERROR:" & ex.ToString
        End Try
    End Sub
    '**************************************************************************************************
    'メール本文作成
    '**************************************************************************************************
    Private Function fncSendMessage( _
                        ByVal pstrKANSI_CD As String, _
                        ByVal pstrKANSI_NAME As String, _
                        ByVal pstrBIKOU As String, _
                        ByVal pstrTEL As String _
                        ) As String
        Dim strResult As String()

        Dim strSEND As New StringBuilder("")
        strSEND.Append("(株)JA-LPガス情報センター　です。" & vbCrLf)
        strSEND.Append("いつも大変お世話になっております。" & vbCrLf)
        strSEND.Append("" & vbCrLf)
        strSEND.Append("対応依頼書を添付ファイルにてご報告させていただきますので" & vbCrLf)
        strSEND.Append("ご査収のほど、よろしくお願い申し上げます。" & vbCrLf)
        strSEND.Append("" & vbCrLf)
        strSEND.Append("---------------------------------------------------------------" & vbCrLf)
        strSEND.Append("(株)JA-LPガス情報センター" & vbCrLf)
        strSEND.Append("" & pstrKANSI_NAME & vbCrLf)             '←監視センター名
        strSEND.Append("" & vbCrLf)
        strSEND.Append("Mail:" & pstrBIKOU & vbCrLf)             '←監視センターメールアドレス
        strSEND.Append("TEL:" & pstrTEL & vbCrLf)                '←監視センター電話番号

        Return strSEND.ToString
    End Function
    '**************************************************************************************************
    '電話番号取得
    '**************************************************************************************************
    Private Function fncKansiAdress(ByVal pstrKANSI_CD As String) As String
        Dim strSQL As New StringBuilder("")
        Dim cdb As New CDB
        Dim ds As New DataSet
        Dim dr As DataRow
        Dim strResult As String
        Dim strKANSI_NAME As String
        Dim strBIKOU As String
        Dim strTEL As String


        '接続OPEN----------------------------------------
        Try
            cdb.mOpen()
        Catch ex As Exception
            strResult = "ERROR;" & ex.ToString
        Finally

        End Try

        Try
            strSQL.Append("SELECT ")
            strSQL.Append("KA.KANSI_NAME, ")
            strSQL.Append("KA.TEL, ")
            strSQL.Append("KA.BIKOU ")
            strSQL.Append("FROM KANSIMAS KA ")
            strSQL.Append("WHERE KA.KANSI_CD = :KANSI_CD ")


            '//SQLセット
            cdb.pSQL = strSQL.ToString
            '//パラメータセット
            cdb.pSQLParamStr("KANSI_CD") = pstrKANSI_CD

            '//SQL実行
            cdb.mExecQuery()
            '//データセットに格納
            ds = cdb.pResult
            '//データが存在しない場合
            If ds.Tables(0).Rows.Count = 0 Then
                strKANSI_NAME = ""
                strBIKOU = ""
                strTEL = ""
            Else
                '//データを格納
                dr = ds.Tables(0).Rows(0)
                strKANSI_NAME = Convert.ToString(dr.Item("KANSI_NAME"))
                strBIKOU = Convert.ToString(dr.Item("BIKOU"))
                strTEL = Convert.ToString(dr.Item("TEL"))
            End If
            strResult = "OK;" & strKANSI_NAME & ";" & strBIKOU & ";" & strTEL
        Catch ex As Exception
            'エラーの内容とＳＱＬ文を返す
            strResult = "ERROR;" & ex.ToString
        Finally
            '接続クローズ
            cdb.mClose()
        End Try
        Return strResult
    End Function
    '**********************************************************
    'ログ吐き出し
    '戻り値：書き込んだファイルへのフルパス
    '**********************************************************
    Public Sub mlog(ByVal pstrFileNm As String, ByVal pstrString As String)
        Dim strPath As String = "D:\inetpub\wwwroot\JPGAP\TEMP\" & pstrFileNm & ".txt"

        '書き込みファイルへのストリーム
        Dim outFile As New StreamWriter(strPath, True, System.Text.Encoding.Default)

        '引数の文字列をストリームに書き込み
        outFile.Write(pstrString + vbCrLf)

        'メモリフラッシュ（ファイル書き込み）
        outFile.Flush()

        'ファイルクローズ
        outFile.Close()

    End Sub
End Class
