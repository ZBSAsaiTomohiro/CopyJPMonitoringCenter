'******************************************************************************
' お客様検索出力
' PGID: MSKOSJAW00.asmx.vb
'******************************************************************************
'変更履歴
' 2017/02/06 W.GANEKO 2016監視改善

Option Explicit On 
Option Strict On

Imports Common
Imports Common.DB

Imports System.Web.Services
Imports System.Text
Imports System.Text.RegularExpressions

<System.Web.Services.WebService(Namespace:="http://tempuri.org/MSKOSJAW00/Service1")> _
Public Class MSKOSJAW00
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
    '*　備　考:2019/11/01 T.Ono mod 監視改善2019 No1 CLI_CD_TO,JA_CD_CLI,HAN_CD_CLI,HAN_CD_TO_CLI追加、KINREN_GRP削除
    '******************************************************************************
    '　DATA0:対象データがありません
    <WebMethod()> Public Function mExcel(
                                        ByVal pstrSessionID As String,
                                        ByVal pstrKANSCD As String,
                                        ByVal pstrTEL As String,
                                        ByVal pstrNAME As String,
                                        ByVal pstrADDR As String,
                                        ByVal pstrCLI_CD As String,
                                        ByVal pstrCLI_CD_TO As String,
                                        ByVal pstrJA_CD As String,
                                        ByVal pstrJA_CD_CLI As String,
                                        ByVal pstrHAN_GRP As String,
                                        ByVal pstrHAN_CD As String,
                                        ByVal pstrHAN_CD_CLI As String,
                                        ByVal pstrHAN_CD_TO As String,
                                        ByVal pstrHAN_CD_TO_CLI As String,
                                        ByVal pstrUSER_CD As String,
                                        ByVal pstrUSER_FLG0 As String,
                                        ByVal pstrUSER_FLG1 As String,
                                        ByVal pstrUSER_FLG2 As String,
                                        ByVal pstrHANBAI_KBN1 As String,
                                        ByVal pstrHANBAI_KBN2 As String,
                                        ByVal pstrHANBAI_KBN3 As String,
                                        ByVal pstrHANBAI_KBN4 As String,
                                        ByVal pstrHANBAI_KBN5 As String,
                                        ByVal pstrHANBAI_KBN6 As String
                                        ) As String

        Dim strSQL As New StringBuilder("")
        Dim cdb As New CDB
        Dim ds As New DataSet
        Dim dr As DataRow
        Dim intGyoMax As Integer = 65535                '最大行数
        Dim ExcelC As New CExcel                        'Excelクラス
        Dim compressC As New CCompress                  '圧縮クラス
        Dim DateFncC As New CDateFnc                    '日付変換クラス
        Dim CTimeFncC As New CTimeFnc                   '時間変換クラス
        Dim FileToStrC As New CFileStr                  'ファイルをBase64にエンコードするクラス
        Dim strHedInfo As String                        'ヘッダー情報（抽出条件）
        Dim strHedInfoHanbai As String                  'ヘッダー情報（抽出条件）
        Dim strHedInfoUserFlg As String                 'ヘッダー情報（抽出条件）
        Dim intPrntRow As Integer = 72
        Dim overFlg As String = "0"

        Dim i As Integer
        Dim cntExcel As Integer


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
            '2019/11/01 T.Ono mod 監視改善2019 No1
            'strSQL.Append(fncMakeSelect(pstrKANSCD,
            '                      pstrTEL,
            '                      pstrNAME,
            '                      pstrADDR,
            '                      pstrCLI_CD,
            '                      pstrCLI_CD_TO,
            '                      pstrJA_CD,
            '                      pstrHAN_GRP,
            '                      pstrKINREN_GRP,
            '                      pstrHAN_CD,
            '                      pstrHAN_CD_TO,
            '                      pstrUSER_CD,
            '                      pstrUSER_FLG0,
            '                      pstrUSER_FLG1,
            '                      pstrUSER_FLG2,
            '                      pstrHANBAI_KBN1,
            '                      pstrHANBAI_KBN2,
            '                      pstrHANBAI_KBN3,
            '                      pstrHANBAI_KBN4,
            '                      pstrHANBAI_KBN5,
            '                      pstrHANBAI_KBN6
            '                      ))

            strSQL.Append(fncMakeSelect(pstrKANSCD,
                                  pstrTEL,
                                  pstrNAME,
                                  pstrADDR,
                                  pstrCLI_CD,
                                  pstrCLI_CD_TO,
                                  pstrJA_CD,
                                  pstrJA_CD_CLI,
                                  pstrHAN_GRP,
                                  pstrHAN_CD,
                                  pstrHAN_CD_CLI,
                                  pstrHAN_CD_TO,
                                  pstrHAN_CD_TO_CLI,
                                  pstrUSER_CD,
                                  pstrUSER_FLG0,
                                  pstrUSER_FLG1,
                                  pstrUSER_FLG2,
                                  pstrHANBAI_KBN1,
                                  pstrHANBAI_KBN2,
                                  pstrHANBAI_KBN3,
                                  pstrHANBAI_KBN4,
                                  pstrHANBAI_KBN5,
                                  pstrHANBAI_KBN6
                                  ))

            cdb.pSQL = strSQL.ToString
            'パラメータのセット
            If pstrKANSCD.Length > 0 Then
                cdb.pSQLParamStr("KANSCD") = pstrKANSCD
            End If
            If pstrTEL.Length > 0 Then
                cdb.pSQLParamStr("TEL") = pstrTEL & "%"
            End If
            If pstrNAME.Length > 0 Then
                cdb.pSQLParamStr("NAME") = pstrNAME & "%"
            End If
            If pstrADDR.Length > 0 Then
                cdb.pSQLParamStr("ADDR") = pstrADDR & "%"
            End If

            '2019/11/01 T.Ono mod 監視改善2019 START
            'If pstrCLI_CD.Length > 0 Then
            '    cdb.pSQLParamStr("CLI_CD") = pstrCLI_CD
            'End If
            'If pstrJA_CD.Length > 0 Then
            '    cdb.pSQLParamStr("JA_CD") = pstrJA_CD & "%"
            'End If
            If pstrJA_CD.Length > 0 Then
                cdb.pSQLParamStr("JA_CD") = pstrJA_CD & "%"
                cdb.pSQLParamStr("CLI_CD") = pstrJA_CD_CLI
                cdb.pSQLParamStr("CLI_CD_TO") = pstrJA_CD_CLI
            Else
                If pstrCLI_CD.Length > 0 Then
                    cdb.pSQLParamStr("CLI_CD") = pstrCLI_CD
                End If
                If pstrCLI_CD_TO.Length > 0 Then
                    cdb.pSQLParamStr("CLI_CD_TO") = pstrCLI_CD_TO
                End If
            End If
            '2019/11/01 T.Ono mod 監視改善2019 END

            If pstrHAN_GRP.Length > 0 Then
                cdb.pSQLParamStr("HAN_GRP") = pstrHAN_GRP
                cdb.pSQLParamStr("HAN_GRP_KBN") = "001"
            End If
            '2019/11/01 T.Ono del 監視改善2019
            'If pstrKINREN_GRP.Length > 0 Then
            '    cdb.pSQLParamStr("HAN_GRP") = pstrKINREN_GRP
            '    cdb.pSQLParamStr("HAN_GRP_KBN") = "002"
            'End If
            If pstrHAN_CD.Length > 0 Then
                cdb.pSQLParamStr("HAN_CD") = pstrHAN_CD
                cdb.pSQLParamStr("HAN_CD_TO") = pstrHAN_CD_TO
                '2019/11/01 T.Ono add 監視改善2019
                cdb.pSQLParamStr("HAN_CD_CLI") = pstrHAN_CD_CLI
                cdb.pSQLParamStr("HAN_CD_TO_CLI") = pstrHAN_CD_TO_CLI
            End If
            If pstrUSER_CD.Length > 0 Then
                cdb.pSQLParamStr("USER_CD") = pstrUSER_CD & "%"
            End If
            If pstrUSER_FLG0 = "0" Then
                cdb.pSQLParamStr("USER_FLG0") = ""
            Else
                cdb.pSQLParamStr("USER_FLG0") = "0"
            End If
            If pstrUSER_FLG1 = "0" Then
                cdb.pSQLParamStr("USER_FLG1") = ""
            Else
                cdb.pSQLParamStr("USER_FLG1") = "1"
            End If
            If pstrUSER_FLG2 = "0" Then
                cdb.pSQLParamStr("USER_FLG2") = ""
            Else
                cdb.pSQLParamStr("USER_FLG2") = "2"
            End If

            'チェックボックス　0：チェックなし　1：チェックあり
            '販売区分　1：メータ売　2：ボンベ売　3：両方　4：その他　5：データなし　6：例外
            If pstrHANBAI_KBN1 = "1" AndAlso pstrHANBAI_KBN2 = "1" AndAlso pstrHANBAI_KBN3 = "1" AndAlso
                pstrHANBAI_KBN4 = "1" AndAlso pstrHANBAI_KBN5 = "1" AndAlso pstrHANBAI_KBN6 = "1" Then
            Else
                If pstrHANBAI_KBN1 = "1" OrElse pstrHANBAI_KBN2 = "1" OrElse pstrHANBAI_KBN3 = "1" OrElse
                   pstrHANBAI_KBN4 = "1" Then
                    If pstrHANBAI_KBN1 = "1" Then
                        cdb.pSQLParamStr("HANBAI_KBN1") = "1"
                    Else
                        cdb.pSQLParamStr("HANBAI_KBN1") = ""
                    End If
                    If pstrHANBAI_KBN2 = "1" Then
                        cdb.pSQLParamStr("HANBAI_KBN2") = "2"
                    Else
                        cdb.pSQLParamStr("HANBAI_KBN2") = ""
                    End If
                    If pstrHANBAI_KBN3 = "1" Then
                        cdb.pSQLParamStr("HANBAI_KBN3") = "3"
                    Else
                        cdb.pSQLParamStr("HANBAI_KBN3") = ""
                    End If
                    If pstrHANBAI_KBN4 = "1" Then
                        cdb.pSQLParamStr("HANBAI_KBN4") = "4"
                    Else
                        cdb.pSQLParamStr("HANBAI_KBN4") = ""
                    End If
                End If
            End If


            cdb.mExecQuery()    'SQL実行
            ds = cdb.pResult    '結果をデータセットに格納

            'データが存在しない場合
            If ds.Tables(0).Rows.Count = 0 Then
                Return "DATA0"      'データが0件であることを示す文字列を返す
            End If

            dr = ds.Tables(0).Rows(0)           'データローにデータセットを格納
            ExcelC.pKencd = "00"                'クライアントコードをセット
            ExcelC.pSessionID = pstrSessionID   'セッションID
            ExcelC.pRepoID = "MSKOSJAW00"       '帳票ID
            ExcelC.mOpen()                      'ファイルオープン

            ExcelC.pTitle = "お客様検索結果リスト"                      'タイトル
            ExcelC.pDate = DateFncC.mGet(Now.ToString("yyyyMMdd"))  '作成日
            'ExcelC.pScale = 93                                      '縮小拡大率(%)
            ExcelC.pScale = 70                                      '縮小拡大率(%)

            '印刷向き
            ExcelC.pLandScape = True ' true:横
            '余白
            ExcelC.pMarginTop = 2D
            ExcelC.pMarginBottom = 0.6D
            ExcelC.pMarginLeft = 1.5D
            ExcelC.pMarginRight = 1D
            ExcelC.pMarginHeader = 1.3D
            ExcelC.pMarginFooter = 1.3D

            'ヘッダ項目をセット。（1ページあたり行数、出力行数、先頭行から何行目までが行タイトルか）
            ExcelC.mHeader(-1, ds.Tables(0).Rows.Count, 1)
            i = 1
            '抽出条件1行名
            strHedInfo = ""
            If pstrKANSCD.Length > 0 Then
                strHedInfo = "監視センター:" & pstrKANSCD
            End If
            If pstrCLI_CD.Length > 0 Then
                If strHedInfo.Length > 0 Then
                    strHedInfo = strHedInfo & "、"
                End If
                '2019/11/01 T.Ono mod 監視改善2019 No1
                'strHedInfo += "クライアント:" & pstrCLI_CD
                strHedInfo += "クライアント:" & pstrCLI_CD & "～" & pstrCLI_CD_TO
            End If
            If pstrJA_CD.Length > 0 Then
                If strHedInfo.Length > 0 Then
                    strHedInfo = strHedInfo & "、"
                End If
                strHedInfo = strHedInfo & "JA:" & pstrJA_CD
            End If
            If pstrHAN_GRP.Length > 0 Then
                If strHedInfo.Length > 0 Then
                    strHedInfo = strHedInfo & "、"
                End If
                strHedInfo = strHedInfo & "販売事業者:" & pstrHAN_GRP
            End If
            '2019/11/01 T.Ono del 監視改善2019
            'If pstrKINREN_GRP.Length > 0 Then
            '    If strHedInfo.Length > 0 Then
            '        strHedInfo = strHedInfo & "、"
            '    End If
            '    strHedInfo = strHedInfo & "緊急連絡先Gr:" & pstrKINREN_GRP
            'End If
            If pstrHAN_CD.Length > 0 Then
                If strHedInfo.Length > 0 Then
                    strHedInfo = strHedInfo & "、"
                End If
                strHedInfo = strHedInfo & "JA支所:" & pstrHAN_CD & "～" & pstrHAN_CD_TO
            End If
            If pstrHANBAI_KBN1 = "1" Or pstrHANBAI_KBN2 = "1" Or pstrHANBAI_KBN3 = "1" Or pstrHANBAI_KBN4 = "1" Or pstrHANBAI_KBN5 = "1" Or pstrHANBAI_KBN6 = "1" Then
                If strHedInfo.Length > 0 Then
                    strHedInfo = strHedInfo & "、"
                End If
                strHedInfo = strHedInfo & "販売区分:"
                strHedInfoHanbai = ""
                '販売区分　1：メータ売　2：ボンベ売　3：両方　4：その他　5：データなし　6：例外
                If pstrHANBAI_KBN1 = "1" Then
                    strHedInfoHanbai = "メータ売"
                End If
                If pstrHANBAI_KBN2 = "1" Then
                    If strHedInfoHanbai.Length > 0 Then
                        strHedInfoHanbai = strHedInfoHanbai & "・"
                    End If
                    strHedInfoHanbai = strHedInfoHanbai & "ボンベ売"
                End If
                If pstrHANBAI_KBN3 = "1" Then
                    If strHedInfoHanbai.Length > 0 Then
                        strHedInfoHanbai = strHedInfoHanbai & "・"
                    End If
                    strHedInfoHanbai = strHedInfoHanbai & "両方"
                End If
                If pstrHANBAI_KBN4 = "1" Then
                    If strHedInfoHanbai.Length > 0 Then
                        strHedInfoHanbai = strHedInfoHanbai & "・"
                    End If
                    strHedInfoHanbai = strHedInfoHanbai & "その他"
                End If
                If pstrHANBAI_KBN5 = "1" Then
                    If strHedInfoHanbai.Length > 0 Then
                        strHedInfoHanbai = strHedInfoHanbai & "・"
                    End If
                    strHedInfoHanbai = strHedInfoHanbai & "データなし"
                End If
                If pstrHANBAI_KBN6 = "1" Then
                    If strHedInfoHanbai.Length > 0 Then
                        strHedInfoHanbai = strHedInfoHanbai & "・"
                    End If
                    strHedInfoHanbai = strHedInfoHanbai & "例外"
                End If
                strHedInfo = strHedInfo & strHedInfoHanbai
            End If
            If pstrUSER_FLG0 <> "0" Or pstrUSER_FLG1 <> "0" Or pstrUSER_FLG2 <> "0" Then
                If strHedInfo.Length > 0 Then
                    strHedInfo = strHedInfo & "、"
                End If
                strHedInfo = strHedInfo & "お客様FLG:"
                strHedInfoUserFlg = ""
                '販売区分　1：メータ売　2：ボンベ売　3：両方　4：その他　5：データなし　6：例外
                If pstrUSER_FLG0 <> "0" Then
                    strHedInfoUserFlg = "未開通"
                End If
                If pstrUSER_FLG1 <> "0" Then
                    If strHedInfoUserFlg.Length > 0 Then
                        strHedInfoUserFlg = strHedInfoUserFlg & "・"
                    End If
                    strHedInfoUserFlg = strHedInfoUserFlg & "運用中"
                End If
                If pstrUSER_FLG2 <> "0" Then
                    If strHedInfoUserFlg.Length > 0 Then
                        strHedInfoUserFlg = strHedInfoUserFlg & "・"
                    End If
                    strHedInfoUserFlg = strHedInfoUserFlg & "休止中"
                End If
                strHedInfo = strHedInfo & strHedInfoUserFlg
            End If
            If strHedInfo.Length > 0 Then
                cntExcel += 1
                ExcelC.pCellStyle(1) = "height:13px;width:50px;text-align:left;font-size:10px;border-style:none;white-space:nowrap;"
                'ExcelC.pCellVal(i, "colspan=16") = strHedInfo
                ExcelC.pCellVal(i) = strHedInfo
                ExcelC.mWriteLine("")       '行をファイルに書き込む
            End If
            '抽出条件2行名
            strHedInfo = ""
            If pstrTEL.Length > 0 Then
                strHedInfo = strHedInfo & "連絡先／結線番号:" & pstrTEL
            End If
            If pstrNAME.Length > 0 Then
                If strHedInfo.Length > 0 Then
                    strHedInfo = strHedInfo & "、"
                End If
                strHedInfo = strHedInfo & "お客様名／カナ:" & pstrNAME
            End If
            If pstrUSER_CD.Length > 0 Then
                If strHedInfo.Length > 0 Then
                    strHedInfo = strHedInfo & "、"
                End If
                strHedInfo = strHedInfo & "お客様コード:" & pstrUSER_CD
            End If
            If pstrADDR.Length > 0 Then
                If strHedInfo.Length > 0 Then
                    strHedInfo = strHedInfo & "、"
                End If
                strHedInfo = strHedInfo & "お客様住所:" & pstrADDR
            End If
            If strHedInfo.Length > 0 Then
                cntExcel += 1
                'ExcelC.pCellStyle(1) = "height:13px;width:50px;text-align:left;font-size:10px;border-style:none;"
                'ExcelC.pCellVal(i, "colspan=16") = strHedInfo
                ExcelC.pCellStyle(1) = "height:13px;width:50px;text-align:left;font-size:10px;border-style:none;white-space:nowrap;"
                ExcelC.pCellVal(i) = strHedInfo
                ExcelC.mWriteLine("")       '行をファイルに書き込む
            End If
            'ヘッダ行
            ExcelC.pCellStyle(1) = "height:13px;width:30px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(2) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(3) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(4) = "height:13px;width:100Px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(5) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(6) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(7) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(8) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(9) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(10) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(11) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" '2017/10/24 H.Mori add 2017改善開発 No2-2
            ExcelC.pCellStyle(12) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(13) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(14) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(15) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(16) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(17) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"


            i = 1
            cntExcel += 1
            ExcelC.pCellVal(i) = Convert.ToString("№") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("ＪＡコード") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("ＪＡ名") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("販売事業者コード") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("販売事業者名") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("販売所コード") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("ＪＡ支所コード") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("ＪＡ支所名") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("お客様コード") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("お客様名") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("代表者氏名") : i += 1          '2017/10/24 H.Mori add 2017改善開発 No2-2
            ExcelC.pCellVal(i) = Convert.ToString("連絡先") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("結線番号") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("住所") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("適用法令区分") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("供給形態区分") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("用途区分") : i += 1
            ExcelC.mWriteLine("")       '行をファイルに書き込む

            ''明細データ出力
            Dim iCnt As Integer
            'APサーバからの戻り値をループする
            '明細データ出力
            'For Each dr In ds.Tables(0).Rows
            For iCnt = 0 To ds.Tables(0).Rows.Count - 1
                If cntExcel = 65536 Then
                    overFlg = "1"
                    Exit For
                End If
                dr = ds.Tables(0).Rows(iCnt)
                '明細項目
                ExcelC.pCellStyle(1) = "height:13px;width:30px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(2) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(3) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" ' 2016/02/26 H.Mori add 監視改善2015 №10
                ExcelC.pCellStyle(4) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" ' 2013/08/27 T.Ono add 監視改善2013№8
                ExcelC.pCellStyle(5) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" ' 2013/08/27 T.Ono add 監視改善2013№8
                ExcelC.pCellStyle(6) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(7) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(8) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" ' 2013/08/27 T.Ono add 監視改善2013№8
                ExcelC.pCellStyle(9) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" ' 2013/08/27 T.Ono add 監視改善2013№8
                ExcelC.pCellStyle(10) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(11) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" '2017/10/24 H.Mori add 2017改善開発 No2-2
                ExcelC.pCellStyle(12) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(13) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(14) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(15) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(16) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(17) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" ' 2013/08/27 T.Ono add 監視改善2013№8

                i = 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("NO")) : i += 1 ' №
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("JA_CD")) : i += 1      ' [利用者]【JAコード】
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("JA_NAME")) : i += 1   ' [利用者]【JA名】
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("GROUPCD")) : i += 1   ' [レコード情報]【販売事業者コード】
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("HANJIGYOSYANM")) : i += 1   ' [レコード情報]【販売事業者名】
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("HANBCD")) : i += 1    ' []【販売所コード】
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("HAN_CD")) : i += 1    ' []【JA支所コード】
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("JAS_NAME")) : i += 1  ' []【JA支所名】
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("USER_CD")) : i += 1   ' []【お客様コード】
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("NAME")) : i += 1   ' []【お客様名】
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("DAIHYO_NAME")) : i += 1   ' []【代表者氏名】 2017/10/24 H.Mori add 2017改善開発 No2-2
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KANKENSAKU_TEL")) : i += 1   ' []【連絡先】

                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("NCU_TEL")) : i += 1   '[]【結線番号】
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("ADDR")) : i += 1      '[]【住所】
                ExcelC.pCellVal(i) = fncGetHOKBNNM(Convert.ToString(dr.Item("HOKBN"))) : i += 1 ' []【適用法令区分】
                ExcelC.pCellVal(i) = fncGetKYOKTKBNNM(Convert.ToString(dr.Item("KYOKTKBN"))) : i += 1 ' []【供給形態区分】
                ExcelC.pCellVal(i) = fncGetYOTOKBNNM(Convert.ToString(dr.Item("YOTOKBN"))) : i += 1 ' []【用途区分】
                ExcelC.mWriteLine("")           '行をファイルに書き込む
                cntExcel += 1
            Next

            ExcelC.mWriteLine("")                           '行をファイルに書き込む
            ExcelC.mClose()                                 'ファイルクローズ

            '圧縮先ファイルのあるフォルダ
            compressC.p_Dir = ExcelC.pDirName
            '日本語ファイル名の指定
            compressC.p_NihongoFileName = "お客様検索リスト.xls"
            '圧縮元ファイル名
            compressC.p_FileName = ExcelC.pDirName & ExcelC.pFileName & ".xls"
            '圧縮先ファイル名
            compressC.p_madeFilename = ExcelC.pDirName & ExcelC.pFileName & ".lzh"
            If overFlg = "1" Then
                Return "OVER0" & (compressC.p_FileName)
            End If
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
    '*         2019/11/01 T.Ono mod 監視改善2019 No1 CLI_CD_TO,JA_CD_CLI,HAN_CD_CLI,HAN_CD_TO_CLI追加、KINREN_GRP削除
    '******************************************************************************
    Public Function fncMakeSelect(ByVal pstrKANSCD As String,
                                  ByVal pstrTEL As String,
                                  ByVal pstrNAME As String,
                                  ByVal pstrADDR As String,
                                  ByVal pstrCLI_CD As String,
                                  ByVal pstrCLI_CD_TO As String,
                                  ByVal pstrJA_CD As String,
                                  ByVal pstrJA_CD_CLI As String,
                                  ByVal pstrHAN_GRP As String,
                                  ByVal pstrHAN_CD As String,
                                  ByVal pstrHAN_CD_CLI As String,
                                  ByVal pstrHAN_CD_TO As String,
                                  ByVal pstrHAN_CD_TO_CLI As String,
                                  ByVal pstrUSER_CD As String,
                                  ByVal pstrUSER_FLG0 As String,
                                  ByVal pstrUSER_FLG1 As String,
                                  ByVal pstrUSER_FLG2 As String,
                                  ByVal pstrHANBAI_KBN1 As String,
                                  ByVal pstrHANBAI_KBN2 As String,
                                  ByVal pstrHANBAI_KBN3 As String,
                                  ByVal pstrHANBAI_KBN4 As String,
                                  ByVal pstrHANBAI_KBN5 As String,
                                  ByVal pstrHANBAI_KBN6 As String) As String

        Dim strSQL As New StringBuilder("")
        'ORDER BYをした後に№を取得しないと、順序よく並ばないため
        strSQL.Append("SELECT ")
        strSQL.Append("A.* ")
        strSQL.Append(",ROWNUM AS NO ")
        strSQL.Append("FROM (")
        strSQL.Append("  SELECT ")
        strSQL.Append("LPAD(ROWNUM,4,0) AS ROWNO, ")
        strSQL.Append("	'' AS COLOR, ")                                              'SPANカラー
        strSQL.Append("	'' AS CLS, ")                                                'SPANクラス
        strSQL.Append("	HN.JA_CD, ")
        strSQL.Append("	HN.JA_NAME, ")
        strSQL.Append("	H1.GROUPCD, ")
        strSQL.Append("	H1.HANJIGYOSYANM, ")
        strSQL.Append("	SH.HANBCD, ")
        strSQL.Append("	SH.HAN_CD, ")
        strSQL.Append("	HN.JAS_NAME, ")
        strSQL.Append("	SH.USER_CD, ")
        strSQL.Append("	SH.NAME, ")
        strSQL.Append("	SH.KANKENSAKU_TEL, ")
        'strSQL.Append("	SH.NCU_TELA || SH.NCU_TELB AS NCU_TEL, ")
        strSQL.Append("	(CASE WHEN SH.NCU_TELA IS NULL THEN NULL ELSE SH.NCU_TELA||'-'||SUBSTR(SH.NCU_TELB,1,INSTR(SH.NCU_TELB, SUBSTR(SH.NCU_TELB, - 4))-1)||'-'||SUBSTR(SH.NCU_TELB, - 4)  END) AS NCU_TEL, ")
        strSQL.Append("	SH.ADD_1 || SH.ADD_2 || SH.ADD_3 AS ADDR, ")
        strSQL.Append("	SH.HOKBN, ")
        strSQL.Append("	SH.KYOKTKBN, ")
        strSQL.Append("	SH.YOTOKBN, ")
        strSQL.Append("	SH.DAIHYO_NAME ") '2017/10/24 H.Mori add 2017改善開発 No2-2
        strSQL.Append("FROM SHAMAS SH, ")
        strSQL.Append("     CLIMAS CL, ")
        strSQL.Append("     HN2MAS HN, ")
        strSQL.Append("     M09_JAGROUP G1, ")     'JA支所
        strSQL.Append("     M10_HANJIGYOSYA H1 ")


        strSQL.Append("WHERE SH.CLI_CD = CL.CLI_CD(+) ")
        strSQL.Append("AND SH.CLI_CD = HN.CLI_CD(+) ")
        strSQL.Append("AND SH.HAN_CD = HN.HAN_CD(+) ")
        strSQL.Append("  AND G1.KBN(+) = '001' ")
        strSQL.Append("  AND G1.KURACD(+) = SH.CLI_CD ")
        strSQL.Append("  AND G1.ACBCD(+) = SH.HAN_CD ")
        strSQL.Append("  AND G1.USERCD_FROM(+) IS NULL ")
        strSQL.Append("  AND G1.USERCD_TO(+) IS NULL ")
        strSQL.Append("  AND G1.GROUPCD = H1.GROUPCD(+) ")
        '監視センター
        If pstrKANSCD.Length > 0 Then
            strSQL.Append(" AND SH.CLI_CD = CL.CLI_CD ")
            '2019/11/01 T.Ono mod 監視改善2019 
            'strSQL.Append(" AND CL.KANSI_CODE = :KANSCD ")
            strSQL.Append(" AND CL.KANSI_CODE IN (" & pstrKANSCD & ") ")
        End If
        '需要家電話番号
        If pstrTEL.Length > 0 Then
            strSQL.Append(" AND (REPLACE(REPLACE(SH.KANKENSAKU_TEL,'-',''), ' ','') ")
            strSQL.Append("  LIKE REPLACE(:TEL,'-','') ")
            strSQL.Append(" OR REPLACE(REPLACE(SH.RENTEL2,'-',''), ' ','') ")
            strSQL.Append("  LIKE REPLACE(:TEL,'-','') ")
            strSQL.Append(" OR REPLACE(REPLACE(SH.RENTEL3,'-',''), ' ','') ")
            strSQL.Append("  LIKE REPLACE(:TEL,'-','') ")
            strSQL.Append(" OR REPLACE(REPLACE(SH.NCU_TELA || SH.NCU_TELB,'-',''), ' ', '') ")
            strSQL.Append("  LIKE REPLACE(:TEL,'-','') ")
            strSQL.Append(" OR REPLACE(REPLACE(SH.TELA || SH.TELB,'-',''), ' ', '') ")
            strSQL.Append("  LIKE REPLACE(:TEL,'-','') ")
            strSQL.Append(" OR REPLACE(REPLACE(SH.DAI3RENDORENTEL,'-',''), ' ', '') ")
            strSQL.Append("  LIKE REPLACE(:TEL,'-','')) ")
        End If
        '需要家名
        If pstrNAME.Length > 0 Then
            strSQL.Append(" AND (REPLACE(UTL_I18N.TRANSLITERATE(TO_SINGLE_BYTE (SH.NAME), 'FWKATAKANA_HWKATAKANA'),' ','') ")
            strSQL.Append("  LIKE REPLACE(UTL_I18N.TRANSLITERATE(TO_SINGLE_BYTE (:NAME), 'FWKATAKANA_HWKATAKANA'),' ','') ")
            strSQL.Append(" OR REPLACE(UTL_I18N.TRANSLITERATE(TO_SINGLE_BYTE (SH.KANA), 'FWKATAKANA_HWKATAKANA'),' ','') ")
            strSQL.Append("  LIKE REPLACE(UTL_I18N.TRANSLITERATE(TO_SINGLE_BYTE (:NAME), 'FWKATAKANA_HWKATAKANA'),' ','')) ")
        End If
        '需要家住所
        If pstrADDR.Length > 0 Then
            strSQL.Append(" AND REPLACE(UTL_I18N.TRANSLITERATE(TO_SINGLE_BYTE (SH.ADD_1 || SH.ADD_2 || SH.ADD_3), 'FWKATAKANA_HWKATAKANA'),' ','') ")
            strSQL.Append("  LIKE REPLACE(UTL_I18N.TRANSLITERATE(TO_SINGLE_BYTE (:ADDR), 'FWKATAKANA_HWKATAKANA'),' ','') ")
        End If
        'クライアントコード
        If pstrCLI_CD.Length > 0 Then
            '2019/11/01 T.Ono mod 監視改善2019 No1
            'strSQL.Append(" AND SH.CLI_CD = :CLI_CD ")
            strSQL.Append(" AND SH.CLI_CD >= :CLI_CD ")
            strSQL.Append(" AND SH.CLI_CD <= :CLI_CD_TO ")
        End If
        'ＪＡコード
        If pstrJA_CD.Length > 0 Then
            strSQL.Append(" AND SH.HAN_CD LIKE :JA_CD ")
        End If
        '販売事業者グループ
        If pstrHAN_GRP.Length > 0 Then
            strSQL.Append(mMakeSQL_HANGRP())
        End If
        '2019/11/01 T.Ono del 監視改善2019 No1
        ''緊急連絡先Gr
        'If pstrKINREN_GRP.Length > 0 Then
        '    strSQL.Append(mMakeSQL_HANGRP())
        'End If
        'ＪＡ支所コード
        If pstrHAN_CD.Length > 0 Then
            '2019/11/01 T.Ono mod 監視改善2019 No1
            'strSQL.Append(" AND SH.HAN_CD >= :HAN_CD ")
            'strSQL.Append(" AND SH.HAN_CD <= :HAN_CD_TO ")
            strSQL.Append(" AND SH.CLI_CD || SH.HAN_CD >= :HAN_CD_CLI || :HAN_CD ")
            strSQL.Append(" AND SH.CLI_CD || SH.HAN_CD <= :HAN_CD_TO_CLI || :HAN_CD_TO ")
        End If
        'お客様コード
        If pstrUSER_CD.Length > 0 Then
            strSQL.Append(" AND SH.USER_CD LIKE :USER_CD ")
        End If

        'お客様FLG
        strSQL.Append(" AND SH.USER_FLG IN (:USER_FLG0,:USER_FLG1,:USER_FLG2) ")

        '販売区分
        If pstrHANBAI_KBN1 = "1" AndAlso pstrHANBAI_KBN2 = "1" AndAlso pstrHANBAI_KBN3 = "1" AndAlso
            pstrHANBAI_KBN4 = "1" AndAlso pstrHANBAI_KBN5 = "1" AndAlso pstrHANBAI_KBN6 = "1" Then
        Else
            If pstrHANBAI_KBN1 = "1" OrElse pstrHANBAI_KBN2 = "1" OrElse pstrHANBAI_KBN3 = "1" OrElse
                pstrHANBAI_KBN4 = "1" Then
                If pstrHANBAI_KBN5 = "1" OrElse pstrHANBAI_KBN6 = "1" Then
                    If pstrHANBAI_KBN5 = "1" AndAlso pstrHANBAI_KBN6 = "1" Then
                        strSQL.Append(" AND (SH.HANBAI_KBN IN (:HANBAI_KBN1,:HANBAI_KBN2,:HANBAI_KBN3,:HANBAI_KBN4) ")
                        strSQL.Append(" OR  (SH.HANBAI_KBN IS NULL) ")
                        strSQL.Append(" OR  (SH.HANBAI_KBN NOT IN ('1','2','3','4') AND SH.HANBAI_KBN IS NOT NULL)) ")
                    Else
                        If pstrHANBAI_KBN5 = "1" Then
                            strSQL.Append(" AND (SH.HANBAI_KBN IN (:HANBAI_KBN1,:HANBAI_KBN2,:HANBAI_KBN3,:HANBAI_KBN4) ")
                            strSQL.Append(" OR  (SH.HANBAI_KBN IS NULL)) ")
                        Else
                            strSQL.Append(" AND (SH.HANBAI_KBN IN (:HANBAI_KBN1,:HANBAI_KBN2,:HANBAI_KBN3,:HANBAI_KBN4) ")
                            strSQL.Append(" OR  (SH.HANBAI_KBN NOT IN ('1','2','3','4') AND SH.HANBAI_KBN IS NOT NULL)) ")
                        End If
                    End If
                Else
                    strSQL.Append(" AND SH.HANBAI_KBN IN (:HANBAI_KBN1,:HANBAI_KBN2,:HANBAI_KBN3,:HANBAI_KBN4) ")
                End If
            Else
                If pstrHANBAI_KBN5 = "1" OrElse pstrHANBAI_KBN6 = "1" Then
                    If pstrHANBAI_KBN5 = "1" AndAlso pstrHANBAI_KBN6 = "1" Then
                        strSQL.Append(" AND ((SH.HANBAI_KBN IS NULL) ")
                        strSQL.Append(" OR  (SH.HANBAI_KBN NOT IN ('1','2','3','4') AND SH.HANBAI_KBN IS NOT NULL)) ")
                    Else
                        If pstrHANBAI_KBN5 = "1" Then
                            strSQL.Append(" AND (SH.HANBAI_KBN IS NULL) ")
                        Else
                            strSQL.Append(" AND (SH.HANBAI_KBN NOT IN ('1','2','3','4') AND SH.HANBAI_KBN IS NOT NULL) ")
                        End If
                    End If
                Else
                    strSQL.Append(" AND  1 <> 1 ")
                End If
            End If
        End If
        '販売区分
        'データのソートを行なう
        strSQL.Append("ORDER BY SH.CLI_CD, SH.HAN_CD, SH.USER_CD ")
        strSQL.Append(") A") '2013/12/09 add T.Ono 監視改善2013





        Return strSQL.ToString

    End Function
    Function fncGetHOKBNNM(ByVal str As String) As String
        Dim res As String
        If str = "1" Then
            res = "1:液石法"
        ElseIf str = "2" Then
            res = "2:高圧法"
        ElseIf str = "3" Then
            res = "3:液石法・高圧法"
        ElseIf str = "4" Then
            res = "4:ガス事業法"
        ElseIf str = "5" Then
            res = "5:適用外"
        Else
            res = str
        End If

        Return res
    End Function
    Function fncGetKYOKTKBNNM(ByVal str As String) As String
        Dim res As String
        If str = "1" Then
            res = "1:一般"
        ElseIf str = "2" Then
            res = "2:集合"
        ElseIf str = "3" Then
            res = "3:簡ガス"
        Else
            res = str
        End If

        Return res
    End Function
    Function fncGetYOTOKBNNM(ByVal str As String) As String
        Dim res As String
        If str = "1" Then
            res = "1:家庭用"
        ElseIf str = "2" Then
            res = "2:業務用"
        ElseIf str = "3" Then
            res = "3:農業用"
        ElseIf str = "4" Then
            res = "4:工業用"
        ElseIf str = "5" Then
            res = "5:その他"
        Else
            res = str
        End If

        Return res
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
    '******************************************************************************
    '*　概　要：ＳＱＬ作成（販売事業者グループ条件）
    '*　備　考：
    '******************************************************************************
    Private Function mMakeSQL_HANGRP() As String

        Dim strSQL As New StringBuilder("")

        strSQL.Append(" AND EXISTS ( ")
        strSQL.Append("SELECT * FROM ( ")
        '2019/11/01 T.Ono mod 監視改善2019 No1
        'strSQL.Append("WITH T_SH AS (SELECT SH.CLI_CD,SH.HAN_CD,SH.USER_CD FROM SHAMAS SH WHERE SH.CLI_CD= :CLI_CD), ")
        'strSQL.Append("     T_JG AS (SELECT JG.KBN,JG.KURACD,JG.ACBCD,JG.GROUPCD,JG.USERCD_FROM,JG.USERCD_TO FROM M09_JAGROUP JG WHERE JG.KBN = :HAN_GRP_KBN AND JG.KURACD = :CLI_CD) ")
        strSQL.Append("WITH T_SH AS (SELECT SH.CLI_CD,SH.HAN_CD,SH.USER_CD FROM SHAMAS SH WHERE SH.CLI_CD >= :CLI_CD AND SH.CLI_CD <= :CLI_CD_TO), ")
        strSQL.Append("     T_JG AS (SELECT JG.KBN,JG.KURACD,JG.ACBCD,JG.GROUPCD,JG.USERCD_FROM,JG.USERCD_TO FROM M09_JAGROUP JG WHERE JG.KBN = :HAN_GRP_KBN AND JG.KURACD >= :CLI_CD AND JG.KURACD <= :CLI_CD_TO) ")
        '画面で選択した販売事業所に所属する個別の顧客を取得
        strSQL.Append("SELECT * FROM T_SH SH1 ")
        strSQL.Append("WHERE EXISTS ( ")
        strSQL.Append("               SELECT * FROM T_JG JG1 ")
        strSQL.Append("               WHERE JG1.ACBCD = SH1.HAN_CD ")
        strSQL.Append("               AND JG1.KURACD = SH1.CLI_CD ")         '2019/11/01 T.Ono add 監視改善2019
        strSQL.Append("               AND JG1.GROUPCD = :HAN_GRP ")
        strSQL.Append("               AND JG1.USERCD_FROM = SH1.USER_CD ")
        strSQL.Append("               AND JG1.USERCD_TO IS NULL ")
        strSQL.Append("            ) ")
        strSQL.Append("UNION ")
        '画面で選択した販売事業所に所属する範囲の顧客を取得
        strSQL.Append("SELECT * FROM T_SH SH2 ")
        strSQL.Append("WHERE EXISTS ( ")
        strSQL.Append("               SELECT * FROM T_JG JG2 ")
        strSQL.Append("               WHERE JG2.ACBCD = SH2.HAN_CD ")
        strSQL.Append("               AND JG2.KURACD = SH2.CLI_CD ")         '2019/11/01 T.Ono add 監視改善2019
        strSQL.Append("               AND JG2.GROUPCD = :HAN_GRP ")
        strSQL.Append("               AND JG2.USERCD_FROM IS NOT NULL ")
        strSQL.Append("               AND JG2.USERCD_TO IS NOT NULL ")
        strSQL.Append("               AND SH2.USER_CD BETWEEN JG2.USERCD_FROM AND JG2.USERCD_TO ")
        strSQL.Append("             ) ")
        '''''別の販売事業者グループに属する個別の顧客を除く
        strSQL.Append("AND NOT EXISTS( ")
        strSQL.Append("               SELECT * FROM T_JG JG3 ")
        strSQL.Append("               WHERE SH2.HAN_CD = JG3.ACBCD ")
        strSQL.Append("               AND JG3.KURACD = SH2.CLI_CD ")         '2019/11/01 T.Ono add 監視改善2019
        strSQL.Append("               AND JG3.GROUPCD <> :HAN_GRP ")
        strSQL.Append("               AND JG3.USERCD_TO IS NULL ")
        strSQL.Append("               AND SH2.USER_CD = JG3.USERCD_FROM ")
        strSQL.Append("              ) ")
        strSQL.Append("UNION ")
        '画面で選択した販売事業所に所属する支所の顧客を取得
        strSQL.Append("SELECT * FROM T_SH SH3 ")
        strSQL.Append("WHERE EXISTS ( ")
        strSQL.Append("               SELECT * FROM T_JG JG4 ")
        strSQL.Append("               WHERE SH3.HAN_CD =  JG4.ACBCD ")
        strSQL.Append("               AND JG4.KURACD = SH3.CLI_CD ")         '2019/11/01 T.Ono add 監視改善2019
        strSQL.Append("               AND JG4.GROUPCD = :HAN_GRP ")
        strSQL.Append("               AND JG4.USERCD_FROM IS NULL ")
        strSQL.Append("               AND JG4.USERCD_TO IS NULL ")
        strSQL.Append("             ) ")
        '''''別の販売事業者グループに属する個別の顧客を除く
        strSQL.Append("AND NOT EXISTS( ")
        strSQL.Append("               SELECT * FROM T_JG JG5 ")
        strSQL.Append("               WHERE SH3.HAN_CD = JG5.ACBCD ")
        strSQL.Append("               AND JG5.KURACD = SH3.CLI_CD ")         '2019/11/01 T.Ono add 監視改善2019
        strSQL.Append("               AND JG5.GROUPCD <> :HAN_GRP ")
        strSQL.Append("               AND JG5.USERCD_TO IS NULL ")
        strSQL.Append("               AND SH3.USER_CD = JG5.USERCD_FROM ")
        strSQL.Append("              ) ")
        '''''別の販売事業者グループに属する範囲の顧客を除く
        strSQL.Append("AND NOT EXISTS( ")
        strSQL.Append("               SELECT * FROM T_JG JG6 ")
        strSQL.Append("               WHERE SH3.HAN_CD = JG6.ACBCD ")
        strSQL.Append("               AND JG6.KURACD = SH3.CLI_CD ")         '2019/11/01 T.Ono add 監視改善2019
        strSQL.Append("               AND JG6.GROUPCD <> :HAN_GRP ")
        strSQL.Append("               AND JG6.USERCD_FROM IS NOT NULL ")
        strSQL.Append("               AND JG6.USERCD_TO IS NOT NULL ")
        strSQL.Append("               AND SH3.USER_CD BETWEEN JG6.USERCD_FROM AND JG6.USERCD_TO ")
        strSQL.Append("              ) ")
        strSQL.Append(") T_GRP ")
        strSQL.Append("WHERE SH.CLI_CD = T_GRP.CLI_CD ")
        strSQL.Append("AND SH.HAN_CD = T_GRP.HAN_CD ")
        strSQL.Append("AND SH.USER_CD = T_GRP.USER_CD ")
        strSQL.Append(" ) ")

        Return strSQL.ToString
    End Function
End Class
