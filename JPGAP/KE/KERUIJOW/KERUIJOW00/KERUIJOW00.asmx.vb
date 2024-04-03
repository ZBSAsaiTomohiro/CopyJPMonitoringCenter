'***********************************************
' PGID：KERUIJOW00
' PG名：累積情報一覧
'***********************************************
' 変更履歴
' 2010/03/05 T.Watabe メータ検針値(D20_TAIOU.KENSIN)を帳票に追加
' 2010/06/02 T.Watabe ゼロ件出力に対応
' 2010/09/10 T.Watabe ﾍﾟｰｼﾞﾌｨｯﾄ
' 2011/02/01 T.Watabe 帳票エクセルを圧縮exe形式へ変更して転送する方法をやめる。そのまま転送。
' 2011/02/10 T.Watabe ↑元の方式へ戻す
' 2011/05/11 T.Watabe FAX送信時不具合解消のため、出力エクセルファイルの倍率、マージンを変更。倍率93→100、マージン左右縮小
' 2011/06/02 T.Watabe ファイル名を「累積情報_<JA名>_セッションID.xls」に変更
' 2011/11/21 H.Uema   発生区分に「電話／警報」項目追加に伴う修正。

Option Explicit On
Option Strict On

Imports Common
Imports Common.DB
Imports Common.CCompress

Imports System.Web.Services
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Configuration
Imports System.IO
Imports System.IO.Compression

<System.Web.Services.WebService(Namespace:="http://tempuri.org/KERUIJOW00/Service1")> _
Public Class KERUIJOW00
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

    '2015/11/04 w.ganeko 2015改善開発 №6 start
    '******************************************************************************
    '*　概　要:件数チェックを行う
    '*　備　考:
    '******************************************************************************
    '　DATA0:対象データがありません
    '<WebMethod()> Public Function mCheck( _
    '                                    ByVal pstrKuracd As String, _
    '                                    ByVal pstrKyocd As String, _
    '                                    ByVal pstrJacd As String, _
    '                                    ByVal pstrJascd As String, _
    '                                    ByVal pstrStkbn As String, _
    '                                    ByVal pstrTrgFrom As String, _
    '                                    ByVal pstrTrgTo As String, _
    '                                    ByVal pdecPageMax As Decimal _
    '                                    ) As String
    '    Return mCheck2( _
    '        pstrKuracd, _
    '        pstrKyocd, _
    '        pstrJacd, _
    '        pstrJacd, _
    '        pstrJascd, _
    '        pstrJascd, _
    '        pstrStkbn, _
    '        pstrTrgFrom, _
    '        pstrTrgTo, _
    '        pdecPageMax _
    '        )
    '    End Function
    '******************************************************************************
    '*　概　要:件数チェックを行う
    '*　備　考:
    '******************************************************************************
    '2017/02/15 H.Mori mod 改善2016 No9-1 START
    '<WebMethod()> Public Function mCheck( _
    '                                    ByVal pstrKuracd As String, _
    '                                    ByVal pstrKyocd As String, _
    '                                    ByVal pstrJacdFr As String, _
    '                                    ByVal pstrJacdTo As String, _
    '                                    ByVal pstrJascdFr As String, _
    '                                    ByVal pstrJascdTo As String, _
    '                                    ByVal pstrStkbn As String, _
    '                                    ByVal pstrTrgFrom As String, _
    '                                    ByVal pstrTrgTo As String, _
    '                                    ByVal pdecPageMax As Decimal, _
    '                                    ByVal pstrHanbaiCdFr As String, _
    '                                    ByVal pstrHanbaiCdTo As String, _
    '                                    ByVal pstrTaikbn As String, _
    '                                    ByVal pstrHkkbn As String _
    '                                    ) As String
    '    Return mCheck2( _
    'pstrKuracd, _
    'pstrKyocd, _
    'pstrJacdFr, _
    'pstrJacdTo, _
    'pstrJascdFr, _
    'pstrJascdTo, _
    'pstrStkbn, _
    'pstrTrgFrom, _
    'pstrTrgTo, _
    'pdecPageMax, _
    'pstrHanbaiCdFr, _
    'pstrHanbaiCdTo, _
    'pstrTaikbn, _
    'pstrHkkbn _
    ')

    'End Function
    <WebMethod()> Public Function mCheck( _
                                        ByVal pstrKuracd As String, _
                                        ByVal pstrKyocd As String, _
                                        ByVal pstrJacdFr As String, _
                                        ByVal pstrJacdTo As String, _
                                        ByVal pstrJascdFr As String, _
                                        ByVal pstrJascdTo As String, _
                                        ByVal pstrStkbn As String, _
                                        ByVal pstrTrgFrom As String, _
                                        ByVal pstrTrgTo As String, _
                                        ByVal pdecPageMax As Decimal, _
                                        ByVal pstrHanbaiCdFr As String, _
                                        ByVal pstrHanbaiCdTo As String, _
                                        ByVal pstrTaikbn As String, _
                                        ByVal pstrHkkbn As String, _
                                        ByVal pstrKikankbn As String, _
                                        ByVal pstrTrgTimeFrom As String, _
                                        ByVal pstrTrgTimeTo As String _
                                        ) As String
        Return mCheck2( _
    pstrKuracd, _
    pstrKyocd, _
    pstrJacdFr, _
    pstrJacdTo, _
    pstrJascdFr, _
    pstrJascdTo, _
    pstrStkbn, _
    pstrTrgFrom, _
    pstrTrgTo, _
    pdecPageMax, _
    pstrHanbaiCdFr, _
    pstrHanbaiCdTo, _
    pstrTaikbn, _
    pstrHkkbn, _
    pstrKikankbn, _
    pstrTrgTimeFrom, _
    pstrTrgTimeTo _
    )

    End Function
    '2017/02/15 H.Mori mod 改善2016 No9-1 END

    '2015/11/04 w.ganeko 2015改善開発 №6 end
    '2017/02/15 H.Mori mod 改善2016 No9-1 START
    '2015/11/04 w.ganeko 2015改善開発 №6 start
    '<WebMethod()> Public Function mCheck2( _
    '                                    ByVal pstrKuracd As String, _
    '                                    ByVal pstrKyocd As String, _
    '                                    ByVal pstrJaCdFr As String, _
    '                                    ByVal pstrJaCdTo As String, _
    '                                    ByVal pstrJasCdFr As String, _
    '                                    ByVal pstrJasCdTo As String, _
    '                                    ByVal pstrStkbn As String, _
    '                                    ByVal pstrTrgFrom As String, _
    '                                    ByVal pstrTrgTo As String, _
    '                                    ByVal pdecPageMax As Decimal _
    '                                    ) As String
    '<WebMethod()> Public Function mCheck2( _
    '                                    ByVal pstrKuracd As String, _
    '                                    ByVal pstrKyocd As String, _
    '                                    ByVal pstrJaCdFr As String, _
    '                                    ByVal pstrJaCdTo As String, _
    '                                    ByVal pstrJasCdFr As String, _
    '                                    ByVal pstrJasCdTo As String, _
    '                                    ByVal pstrStkbn As String, _
    '                                    ByVal pstrTrgFrom As String, _
    '                                    ByVal pstrTrgTo As String, _
    '                                    ByVal pdecPageMax As Decimal, _
    '                                    ByVal pstrHanbaiCdFr As String, _
    '                                    ByVal pstrHanbaiCdTo As String, _
    '                                    ByVal pstrTaikbn As String, _
    '                                    ByVal pstrHkkbn As String _
    '                                    ) As String
    <WebMethod()> Public Function mCheck2( _
                                        ByVal pstrKuracd As String, _
                                        ByVal pstrKyocd As String, _
                                        ByVal pstrJaCdFr As String, _
                                        ByVal pstrJaCdTo As String, _
                                        ByVal pstrJasCdFr As String, _
                                        ByVal pstrJasCdTo As String, _
                                        ByVal pstrStkbn As String, _
                                        ByVal pstrTrgFrom As String, _
                                        ByVal pstrTrgTo As String, _
                                        ByVal pdecPageMax As Decimal, _
                                        ByVal pstrHanbaiCdFr As String, _
                                        ByVal pstrHanbaiCdTo As String, _
                                        ByVal pstrTaikbn As String, _
                                        ByVal pstrHkkbn As String, _
                                        ByVal pstrKikankbn As String, _
                                        ByVal pstrTrgTimeFrom As String, _
                                        ByVal pstrTrgTimeTo As String _
                                        ) As String
        '2015/11/04 w.ganeko 2015改善開発 №6 end
        '2017/02/15 H.Mori mod 改善2016 No9-1 END
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
            Dim SQL As String
            '2011.11.21 MOD H.Uema *---------------------* start
            'SQL = fncMakeSelect(2, _
            '                         pstrKuracd, _
            '                         pstrKyocd, _
            '                         pstrJaCdFr, _
            '                         pstrJaCdTo, _
            '                         pstrJasCdFr, _
            '                         pstrJasCdTo, _
            '                         pstrTrgFrom, _
            '                         pstrTrgTo, _
            '                         "", _
            '                         pdecPageMax)
            '2015/11/04 w.ganeko 2015改善開発 №6 start
            'SQL = fncMakeSelect(2, _
            '                    pstrKuracd, _
            '                    pstrKyocd, _
            '                    pstrJaCdFr, _
            '                    pstrJaCdTo, _
            '                    pstrJasCdFr, _
            '                    pstrJasCdTo, _
            '                    pstrTrgFrom, _
            '                    pstrTrgTo, _
            '                    "", _
            '                    pdecPageMax, _
            '                    pstrStkbn)
            '2017/02/15 H.Mori mod 改善2016 No9-1 START
            'SQL = fncMakeSelect(2, _
            '                    pstrKuracd, _
            '                    pstrKyocd, _
            '                    pstrJaCdFr, _
            '                    pstrJaCdTo, _
            '                    pstrJasCdFr, _
            '                    pstrJasCdTo, _
            '                    pstrTrgFrom, _
            '                    pstrTrgTo, _
            '                    "", _
            '                    pdecPageMax, _
            '                    pstrStkbn, _
            '                    pstrHanbaiCdFr, _
            '                    pstrHanbaiCdTo, _
            '                    pstrTaikbn, _
            '                    pstrHkkbn)
            '2015/11/04 w.ganeko 2015改善開発 №6 end
            '2011.11.21 MOD H.Uema *---------------------* end
            SQL = fncMakeSelect(2, _
                                pstrKuracd, _
                                pstrKyocd, _
                                pstrJaCdFr, _
                                pstrJaCdTo, _
                                pstrJasCdFr, _
                                pstrJasCdTo, _
                                pstrTrgFrom, _
                                pstrTrgTo, _
                                "", _
                                pdecPageMax, _
                                pstrStkbn, _
                                pstrHanbaiCdFr, _
                                pstrHanbaiCdTo, _
                                pstrTaikbn, _
                                pstrHkkbn, _
                                pstrKikankbn, _
                                pstrTrgTimeFrom, _
                                pstrTrgTimeTo)
            '2017/02/15 H.Mori mod 改善2016 No9-1 END

            'Return "DEBUG:" & SQL
            cdb.pSQL = SQL
            'パラメータセット
            If pstrKuracd.Length <> 0 Then
                cdb.pSQLParamStr("KURACD") = pstrKuracd
            End If
            If pstrKyocd.Length > 0 Then cdb.pSQLParamStr("KYOCD") = pstrKyocd
            '2015/11/04 w.ganeko 2015改善開発 №6 start
            If pstrHanbaiCdFr.Length > 0 Then cdb.pSQLParamStr("GROUPCDFR") = pstrHanbaiCdFr
            If pstrHanbaiCdTo.Length > 0 Then cdb.pSQLParamStr("GROUPCDTO") = pstrHanbaiCdTo
            '2015/11/04 w.ganeko 2015改善開発 №6 end
            If pstrJaCdFr.Length > 0 Then cdb.pSQLParamStr("JACDFR") = pstrJaCdFr
            If pstrJaCdTo.Length > 0 Then cdb.pSQLParamStr("JACDTO") = pstrJaCdTo
            If pstrJasCdFr.Length > 0 Then cdb.pSQLParamStr("JASCDFR") = pstrJasCdFr
            If pstrJasCdTo.Length > 0 Then cdb.pSQLParamStr("JASCDTO") = pstrJasCdTo
            cdb.pSQLParamStr("HATKBN") = pstrStkbn
            If pstrTrgFrom.Length > 0 Then cdb.pSQLParamStr("TRGDATE_FROM") = pstrTrgFrom
            If pstrTrgTo.Length > 0 Then cdb.pSQLParamStr("TRGDATE_TO") = pstrTrgTo
            '2017/02/15 H.Mori add 改善2016 No9-1 START
            If pstrTrgTimeFrom.Length > 0 Then cdb.pSQLParamStr("TRGTIME_FROM") = pstrTrgTimeFrom
            If pstrTrgTimeTo.Length > 0 Then cdb.pSQLParamStr("TRGTIME_TO") = pstrTrgTimeTo & "59"
            '2017/02/15 H.Mori add 改善2016 No9-1 END

            cdb.mExecQuery()    'SQL実行
            ds = cdb.pResult    '結果をデータセットに格納

            '検索数の上限をなくす　2013/12/05 T.Ono mod 監視改善2013
            'データが存在しない場合
            'If ds.Tables(0).Rows.Count = 0 Then
            '    Return "DATA0"      'データが0件であることを示す文字列を返す
            'ElseIf ds.Tables(0).Rows.Count > decGyoMax Then
            '    Return "DATAMAX"    'データが最大行数を超える事を示す文字列を返す
            'End If
            If ds.Tables(0).Rows.Count = 0 Then
                Return "DATA0"      'データが0件であることを示す文字列を返す
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
    '*　概　要:一覧の出力を行います
    '*　備　考:
    '******************************************************************************
    '　DATA0:対象データがありません
    '2015/11/04 w.ganeko 2015改善開発 №6 start
    '<WebMethod()> Public Function mExcel( _
    '                                    ByVal pstrSessionID As String, _
    '                                    ByVal pstrKuracd As String, _
    '                                    ByVal pstrKyocd As String, _
    '                                    ByVal pstrJacd As String, _
    '                                    ByVal pstrJascd As String, _
    '                                    ByVal pstrStkbn As String, _
    '                                    ByVal pstrPgkbn As String, _
    '                                    ByVal pstrTrgFrom As String, _
    '                                    ByVal pstrTrgTo As String, _
    '                                    ByVal pstrKuraNm As String, _
    '                                    ByVal pstrKyoNm As String, _
    '                                    ByVal pstrJaNm As String, _
    '                                    ByVal pstrJasNm As String, _
    '                                    ByVal pdecPageMax As Decimal, _
    '                                    ByVal pstrCentcd As String _
    '                                    ) As String
    '2017/02/15 H.Mori mod 改善2016 No9-1 START
    '<WebMethod()> Public Function mExcel( _
    '                                    ByVal pstrSessionID As String, _
    '                                    ByVal pstrKuracd As String, _
    '                                    ByVal pstrKyocd As String, _
    '                                    ByVal pstrJacdFr As String, _
    '                                    ByVal pstrJacdTo As String, _
    '                                    ByVal pstrJascdFr As String, _
    '                                    ByVal pstrJascdTo As String, _
    '                                    ByVal pstrStkbn As String, _
    '                                    ByVal pstrPgkbn As String, _
    '                                    ByVal pstrTrgFrom As String, _
    '                                    ByVal pstrTrgTo As String, _
    '                                    ByVal pstrKuraNm As String, _
    '                                    ByVal pstrKyoNm As String, _
    '                                    ByVal pstrJaNmFr As String, _
    '                                    ByVal pstrJaNmTo As String, _
    '                                    ByVal pstrJasNmFr As String, _
    '                                    ByVal pstrJasNmTo As String, _
    '                                    ByVal pdecPageMax As Decimal, _
    '                                    ByVal pstrCentcd As String, _
    '                                    ByVal pstrHanbaiCdFr As String, _
    '                                    ByVal pstrHanbaiCdTo As String, _
    '                                    ByVal pstrTaikbn As String, _
    '                                    ByVal pstrHkkbn As String, _
    '                                    ByVal pstrHanbaiNmFr As String, _
    '                                    ByVal pstrHanbaiNmTo As String _
    '                                    ) As String

    '2015/11/04 w.ganeko 2015改善開発 №6 end
    '2020/11/01 T.Ono mod 2020監視改善 pstrSdPrt追加
    <WebMethod()> Public Function mExcel(
                                        ByVal pstrSessionID As String,
                                        ByVal pstrKuracd As String,
                                        ByVal pstrKyocd As String,
                                        ByVal pstrJacdFr As String,
                                        ByVal pstrJacdTo As String,
                                        ByVal pstrJascdFr As String,
                                        ByVal pstrJascdTo As String,
                                        ByVal pstrStkbn As String,
                                        ByVal pstrPgkbn As String,
                                        ByVal pstrTrgFrom As String,
                                        ByVal pstrTrgTo As String,
                                        ByVal pstrKuraNm As String,
                                        ByVal pstrKyoNm As String,
                                        ByVal pstrJaNmFr As String,
                                        ByVal pstrJaNmTo As String,
                                        ByVal pstrJasNmFr As String,
                                        ByVal pstrJasNmTo As String,
                                        ByVal pdecPageMax As Decimal,
                                        ByVal pstrCentcd As String,
                                        ByVal pstrHanbaiCdFr As String,
                                        ByVal pstrHanbaiCdTo As String,
                                        ByVal pstrTaikbn As String,
                                        ByVal pstrHkkbn As String,
                                        ByVal pstrHanbaiNmFr As String,
                                        ByVal pstrHanbaiNmTo As String,
                                        ByVal pstrKikankbn As String,
                                        ByVal pstrTrgTimeFrom As String,
                                        ByVal pstrTrgTimeTo As String,
                                        ByVal pstrSdPrt As String
                                        ) As String
        '2017/02/15 H.Mori mod 改善2016 No9-1 END

        '2016/12/05 T.Ono add 2016改善開発 №12
        Dim faxNo() As String = {"", ""}
        Dim mailADD() As String = {"", ""}

        '2014/01/06 T.Ono mod 監視改善2013
        '累積情報一覧メニューからの出力形式をexe→xlsへ変更する
        '累積自動FAXはexeのままにしておく必要があるため、
        'メニューからは「mExcel3」　累積自動FAXからは「mExcel2」を使用する
        'Return mExcel2( _
        '                pstrSessionID, _
        '                pstrKuracd, _
        '                pstrKyocd, _
        '                pstrJacd, _
        '                pstrJacd, _
        '                pstrJascd, _
        '                pstrJascd, _
        '                pstrStkbn, _
        '                pstrPgkbn, _
        '                pstrTrgFrom, _
        '                pstrTrgTo, _
        '                pstrKuraNm, _
        '                pstrKyoNm, _
        '                pstrJaNm, _
        '                pstrJasNm, _
        '                pdecPageMax, _
        '                pstrCentcd, _
        '                "0", _
        '                True _
        '                )
        '2015/11/04 w.ganeko 2015改善開発 №6 start
        'Return mExcel3( _
        '                pstrSessionID, _
        '                pstrKuracd, _
        '                pstrKyocd, _
        '                pstrJacd, _
        '                pstrJacd, _
        '                pstrJascd, _
        '                pstrJascd, _
        '                pstrStkbn, _
        '                pstrPgkbn, _
        '                pstrTrgFrom, _
        '                pstrTrgTo, _
        '                pstrKuraNm, _
        '                pstrKyoNm, _
        '                pstrJaNm, _
        '                pstrJasNm, _
        '                pdecPageMax, _
        '                pstrCentcd, _
        '                "0", _
        '                True _
        '                )
        '2017/02/15 H.Mori mod 改善2016 No9-1 START
        'Return mExcel3( _
        '        pstrSessionID, _
        '        pstrKuracd, _
        '        pstrKyocd, _
        '        pstrJacdFr, _
        '        pstrJacdTo, _
        '        pstrJascdFr, _
        '        pstrJascdTo, _
        '        pstrStkbn, _
        '        pstrPgkbn, _
        '        pstrTrgFrom, _
        '        pstrTrgTo, _
        '        pstrKuraNm, _
        '        pstrKyoNm, _
        '        pstrJaNmFr, _
        '        pstrJaNmTo, _
        '        pstrJasNmFr, _
        '        pstrJasNmTo, _
        '        pdecPageMax, _
        '        pstrCentcd, _
        '        "0", _
        '        True, _
        '        pstrHanbaiCdFr, _
        '        pstrHanbaiCdTo, _
        '        pstrTaikbn, _
        '        pstrHkkbn, _
        '        pstrHanbaiNmFr, _
        '        pstrHanbaiNmTo, _
        '        "0", _
        '        faxNo, _
        '        mailADD _
        '        )
        '2015/11/04 w.ganeko 2015改善開発 №6 end
        '2020/11/01 T.Ono mod 2020監視改善 pstrSdPrt追加
        Return mExcel3(
                pstrSessionID,
                pstrKuracd,
                pstrKyocd,
                pstrJacdFr,
                pstrJacdTo,
                pstrJascdFr,
                pstrJascdTo,
                pstrStkbn,
                pstrPgkbn,
                pstrTrgFrom,
                pstrTrgTo,
                pstrKuraNm,
                pstrKyoNm,
                pstrJaNmFr,
                pstrJaNmTo,
                pstrJasNmFr,
                pstrJasNmTo,
                pdecPageMax,
                pstrCentcd,
                "0",
                pstrSdPrt,
                True,
                pstrHanbaiCdFr,
                pstrHanbaiCdTo,
                pstrTaikbn,
                pstrHkkbn,
                pstrHanbaiNmFr,
                pstrHanbaiNmTo,
                "0",
                faxNo,
                mailADD,
                pstrKikankbn,
                pstrTrgTimeFrom,
                pstrTrgTimeTo
                )
        '2017/02/15 H.Mori mod 改善2016 No9-1 END
    End Function
    '2015/11/04 w.ganeko 2015改善開発 №6 start
    '<WebMethod()> Public Function mExcel2( _
    '                                ByVal pstrSessionID As String, _
    '                                ByVal pstrKuracd As String, _
    '                                ByVal pstrKyocd As String, _
    '                                ByVal pstrJaCdFr As String, _
    '                                ByVal pstrJaCdTo As String, _
    '                                ByVal pstrJasCdFr As String, _
    '                                ByVal pstrJasCdTo As String, _
    '                                ByVal pstrStkbn As String, _
    '                                ByVal pstrPgkbn As String, _
    '                                ByVal pstrTrgFrom As String, _
    '                                ByVal pstrTrgTo As String, _
    '                                ByVal pstrKuraNm As String, _
    '                                ByVal pstrKyoNm As String, _
    '                                ByVal pstrJaNm As String, _
    '                                ByVal pstrJasNm As String, _
    '                                ByVal pdecPageMax As Decimal, _
    '                                ByVal pstrCentcd As String, _
    '                                ByVal pstrZeroSend As String, _
    '                                ByVal pbolLzhAutoExec As Boolean _
    '                                ) As String

    '    Dim strSQL As New StringBuilder("")
    '    Dim cdb As New CDB
    '    Dim ds As New DataSet
    '    Dim dr As DataRow
    '    Dim intGYOSU As Integer = 5                     '改行制御を行う
    '    Dim intGyoMax As Integer = CInt(pdecPageMax)    '最大行数
    '    'Dim intGyoMax As Integer = 4500 '最大行数
    '    Dim ExcelC As New CExcel                        'Excelクラス
    '    Dim compressC As New CCompress                  '圧縮クラス
    '    Dim DateFncC As New CDateFnc                    '日付変換クラス
    '    Dim CTimeFncC As New CTimeFnc                   '時間変換クラス
    '    Dim FileToStrC As New CFileStr                  'ファイルをBase64にエンコードするクラス
    '    Dim strHedInfo As String                        'ヘッダー情報（抽出条件）
    '    Dim intPrntRow As Integer = 72
    '    '2015/11/04 w.ganeko 2015改善開発 №6 start
    '    Dim pstrHanbaiCdFr As String = ""
    '    Dim pstrHanbaiCdTo As String = ""
    '    Dim pstrTaikbn As String = "0"
    '    Dim pstrHkkbn As String = "2"
    '    Dim pstrHanbaiNmFr As String = ""
    '    Dim pstrHanbaiNmTo As String = ""
    '    Dim pstrZipFlg As String = "1"
    '    '2015/11/04 w.ganeko 2015改善開発 №6 end
    '    Dim strTmp() As String

    '    '接続OPEN----------------------------------------
    '    Try
    '        cdb.mOpen()
    '    Catch ex As Exception
    '        Return ex.ToString
    '    Finally

    '    End Try

    '    ' ---------------------------------
    '    ' ＪＡ名、県名、クライアント名、供給ｾﾝﾀｰ名を取得
    '    ' ---------------------------------
    '    Dim jaNmFr As String = ""
    '    Dim jaNmTo As String = ""
    '    Dim jasNmFr As String = ""
    '    Dim jasNmTo As String = ""
    '    Dim kenNm As String = ""
    '    Dim HanNmFr As String = ""
    '    Dim HanNmTo As String = ""
    '    'Dim clientNm As String = ""
    '    Dim centerNm As String = ""
    '    Try
    '        jaNmFr = getDB2JasNm(cdb, pstrKuracd, pstrJaCdFr)
    '        jaNmFr = jaNmFr.Trim
    '        If pstrJaCdFr.Length <> 0 And pstrJaCdFr = pstrJaCdTo Then
    '            jaNmTo = jaNmFr
    '        Else
    '            jaNmTo = getDB2JasNm(cdb, pstrKuracd, pstrJaCdTo)
    '        End If
    '        jasNmFr = getDB2JasNm(cdb, pstrKuracd, pstrJasCdFr)
    '        '2015/11/04 w.ganeko 2015改善開発 №6 start
    '        strTmp = pstrHanbaiNmFr.Split(Convert.ToChar(":"))
    '        HanNmFr = strTmp(strTmp.Length - 1).Trim
    '        If pstrHanbaiCdFr.Length <> 0 And pstrHanbaiCdFr = pstrHanbaiCdTo Then
    '            HanNmTo = HanNmFr
    '        ElseIf pstrHanbaiCdTo.Length <> 0 Then
    '            strTmp = pstrHanbaiNmTo.Split(Convert.ToChar(":"))
    '            HanNmTo = strTmp(strTmp.Length - 1).Trim
    '        End If
    '        '2015/11/04 w.ganeko 2015改善開発 №6 end
    '        If pstrJasCdFr.Length <> 0 And pstrJasCdFr = pstrJasCdTo Then
    '            jasNmTo = jasNmFr
    '        Else
    '            jasNmTo = getDB2JasNm(cdb, pstrKuracd, pstrJasCdTo)
    '        End If
    '        kenNm = getDB2KenNm(cdb, pstrKuracd)

    '        '2011.11.22 MOD H.Uema クライアント未指定の場合、落ちるので修正
    '        'centerNm = getDB2CenterNm(cdb, pstrKuracd.Substring(1, 2), pstrKyocd)
    '        If (pstrKuracd.Length > 2) Then
    '            centerNm = getDB2CenterNm(cdb, pstrKuracd.Substring(1, 2), pstrKyocd)
    '        End If

    '    Catch ex As Exception
    '        '2011.11.22 MOD H.Uema *----------* start
    '        'Return ex.ToString
    '        cdb.mClose()        '接続クローズ
    '        Return "ERROR:" & ex.ToString
    '        '2011.11.22 MOD H.Uema *----------* end
    '    Finally
    '    End Try

    '    '帳票出力項目の取得用SQL文セット-------------------
    '    Try
    '        '2011.11.21 MOD H.Uema *---------------------* start
    '        '帳票出力項目の取得用SQL文セット
    '        'strSQL.Append(fncMakeSelect(2, _
    '        '                         pstrKuracd, _
    '        '                         pstrKyocd, _
    '        '                         pstrJaCdFr, _
    '        '                         pstrJaCdTo, _
    '        '                         pstrJasCdFr, _
    '        '                         pstrJasCdTo, _
    '        '                         pstrTrgFrom, _
    '        '                         pstrTrgTo, _
    '        '                         pstrPgkbn, _
    '        '                         pdecPageMax))
    '        '2015/11/04 w.ganeko 2015改善開発 №6 start
    '        'strSQL.Append(fncMakeSelect(2, _
    '        '                        pstrKuracd, _
    '        '                        pstrKyocd, _
    '        '                        pstrJaCdFr, _
    '        '                        pstrJaCdTo, _
    '        '                        pstrJasCdFr, _
    '        '                        pstrJasCdTo, _
    '        '                        pstrTrgFrom, _
    '        '                        pstrTrgTo, _
    '        '                        pstrPgkbn, _
    '        '                        pdecPageMax, _
    '        '                        pstrStkbn))
    '        strSQL.Append(fncMakeSelect(2, _
    '                                pstrKuracd, _
    '                                pstrKyocd, _
    '                                pstrJaCdFr, _
    '                                pstrJaCdTo, _
    '                                pstrJasCdFr, _
    '                                pstrJasCdTo, _
    '                                pstrTrgFrom, _
    '                                pstrTrgTo, _
    '                                pstrPgkbn, _
    '                                pdecPageMax, _
    '                                pstrStkbn, _
    '                                pstrHanbaiCdFr, _
    '                                pstrHanbaiCdTo, _
    '                                pstrTaikbn, _
    '                                pstrHkkbn
    '                               ))
    '        '2015/11/04 w.ganeko 2015改善開発 №6 end
    '        '2011.11.21 MOD H.Uema *---------------------* end

    '        cdb.pSQL = strSQL.ToString

    '        'パラメータセット
    '        If pstrKuracd.Length <> 0 Then
    '            cdb.pSQLParamStr("KURACD") = pstrKuracd
    '        End If
    '        If pstrKyocd.Length > 0 Then cdb.pSQLParamStr("KYOCD") = pstrKyocd
    '        '2015/11/04 w.ganeko 2015改善開発 №6 start
    '        If pstrHanbaiCdFr.Length > 0 Then cdb.pSQLParamStr("GROUPCDFR") = pstrHanbaiCdFr
    '        If pstrHanbaiCdTo.Length > 0 Then cdb.pSQLParamStr("GROUPCDTO") = pstrHanbaiCdTo
    '        '2015/11/04 w.ganeko 2015改善開発 №6 end
    '        If pstrJaCdFr.Length > 0 Then cdb.pSQLParamStr("JACDFR") = pstrJaCdFr
    '        If pstrJaCdTo.Length > 0 Then cdb.pSQLParamStr("JACDTO") = pstrJaCdTo
    '        If pstrJasCdFr.Length > 0 Then cdb.pSQLParamStr("JASCDFR") = pstrJasCdFr
    '        If pstrJasCdTo.Length > 0 Then cdb.pSQLParamStr("JASCDTO") = pstrJasCdTo
    '        cdb.pSQLParamStr("HATKBN") = pstrStkbn '発生区分
    '        If pstrTrgFrom.Length > 0 Then cdb.pSQLParamStr("TRGDATE_FROM") = pstrTrgFrom
    '        If pstrTrgTo.Length > 0 Then cdb.pSQLParamStr("TRGDATE_TO") = pstrTrgTo

    '        cdb.mExecQuery()    'SQL実行
    '        ds = cdb.pResult    '結果をデータセットに格納

    '        '検索数の上限をなくす　2013/12/05 T.Ono mod 監視改善2013
    '        ''データが存在しない場合
    '        'If ds.Tables(0).Rows.Count = 0 And pstrZeroSend <> "1" Then
    '        '    Return "DATA0"      'データが0件であることを示す文字列を返す
    '        'ElseIf ds.Tables(0).Rows.Count > intGyoMax Then
    '        '    Return "DATAMAX"    'データが最大行数を超える事を示す文字列を返す
    '        'End If
    '        If ds.Tables(0).Rows.Count = 0 And pstrZeroSend <> "1" Then
    '            Return "DATA0"      'データが0件であることを示す文字列を返す
    '        End If

    '        'dr = ds.Tables(0).Rows(0)           'データローにデータセットを格納
    '        ExcelC.pKencd = "00"                'クライアントコードをセット
    '        ExcelC.pSessionID = pstrSessionID   'セッションID
    '        ExcelC.pRepoID = "KERUIJOX00"       '帳票ID
    '        ExcelC.mOpen()                      'ファイルオープン

    '        '2014/03/20 T.Ono mod FAXタイトル変更要望
    '        'ExcelC.pTitle = "累積情報一覧表"                        'タイトル
    '        'ExcelC.pTitle = "監視センター対応結果累積明細（ご報告）" 'タイトル  2014/03/31 T.Ono mod "()"を半角に。Excel2003だと作成日の右寄せが甘く、タイトルと重なる
    '        ExcelC.pTitle = "監視センター対応結果累積明細(ご報告)" 'タイトル
    '        ExcelC.pDate = DateFncC.mGet(Now.ToString("yyyyMMdd"))  '作成日
    '        'ExcelC.pScale = 93                                      '縮小拡大率(%)
    '        ExcelC.pScale = 100                                      '縮小拡大率(%) ' 2011/05/11 T.Watabe edit
    '        'ExcelC.pFitPaper = True                                 'ﾍﾟｰｼﾞﾌｨｯﾄ 2010/09/10 T.Watabe add

    '        '印刷向き
    '        ExcelC.pLandScape = False
    '        '余白
    '        ExcelC.pMarginTop = 2D
    '        'ExcelC.pMarginBottom = 1.6D
    '        ExcelC.pMarginBottom = 0.6D
    '        'ExcelC.pMarginLeft = 2D    ' 2011/05/11 T.Watabe edit
    '        'ExcelC.pMarginRight = 1.1D ' 2011/05/11 T.Watabe edit
    '        ExcelC.pMarginLeft = 1.7D
    '        ExcelC.pMarginRight = 0D
    '        ExcelC.pMarginHeader = 1.3D
    '        ExcelC.pMarginFooter = 1.3D

    '        'ヘッダ項目をセット。（1ページあたり行数、出力行数、先頭行から何行目までが行タイトルか）
    '        'ExcelC.mHeader(intGYOSU, ds.Tables(0).Rows.Count, 5)
    '        ExcelC.mHeader(intPrntRow, ds.Tables(0).Rows.Count, 4)

    '        '各列の幅をピクセルでセット。枠線も消す。
    '        ' 2015/02/16 H.Hosoda mod 2014改善開発 No9 START
    '        'ExcelC.pCellStyle(1) = "height:0px;width:66px;border-style:none"
    '        ExcelC.pCellStyle(1) = "height:0px;width:71px;border-style:none"
    '        ' 2015/02/16 H.Hosoda mod 2014改善開発 No9 END
    '        ExcelC.pCellStyle(2) = "height:0px;width:65px;border-style:none"
    '        ExcelC.pCellStyle(3) = "height:0px;width:21px;border-style:none"
    '        ExcelC.pCellStyle(4) = "height:0px;width:72px;border-style:none"
    '        ExcelC.pCellStyle(5) = "height:0px;width:23px;border-style:none"
    '        ExcelC.pCellStyle(6) = "height:0px;width:86px;border-style:none"
    '        'ExcelC.pCellStyle(7) = "height:0px;width:144px;border-style:none" '2010/03/05 T.Watabe edit
    '        ExcelC.pCellStyle(7) = "height:0px;width:204px;border-style:none"
    '        ExcelC.pCellStyle(8) = "height:0px;width:72px;border-style:none"
    '        '2006/06/14 NEC UPDATE START
    '        'ExcelC.pCellStyle(9) = "height:0px;width:175px;border-style:none"
    '        'ExcelC.pCellStyle(9) = "height:0px;width:195px;border-style:none" '2010/03/05 T.Watabe edit
    '        ExcelC.pCellStyle(9) = "height:0px;width:135px;border-style:none"
    '        ExcelC.pCellStyle(10) = "height:0px;width:5px;border-style:none"
    '        ExcelC.pCellStyle(11) = "height:0px;width:5px;border-style:none"
    '        '2006/06/14 NEC UPDATE END
    '        ExcelC.pCellVal(1) = ""
    '        ExcelC.pCellVal(2) = ""
    '        ExcelC.pCellVal(3) = ""
    '        ExcelC.pCellVal(4) = ""
    '        ExcelC.pCellVal(5) = ""
    '        ExcelC.pCellVal(6) = ""
    '        ExcelC.pCellVal(7) = ""
    '        ExcelC.pCellVal(8) = ""
    '        ExcelC.pCellVal(9) = ""
    '        ExcelC.pCellVal(10) = ""
    '        ExcelC.pCellVal(11) = ""
    '        ExcelC.mWriteLine("")   '行をファイルに書き込む

    '        If True Then
    '            '抽出条件（上段）
    '            ExcelC.pCellStyle(1) = "height:16px;font-size:13px;border-bottom-style:none"
    '            ExcelC.pCellVal(1, "colspan = 9") = "抽出条件"
    '            ExcelC.mWriteLine("")   '行をファイルに書き込む

    '            '抽出条件（中段）
    '            strHedInfo = "県名:"
    '            'If pstrKuracd.Length <> 0 Then strHedInfo &= Convert.ToString(dr.Item("KENNM"))
    '            If pstrKuracd.Length <> 0 Then strHedInfo &= kenNm
    '            strHedInfo &= "　供給センター:"
    '            If pstrKyocd.Length <> 0 Then
    '                'strHedInfo &= Convert.ToString(dr.Item("NAME"))
    '                'strTmp = pstrKyoNm.Split(Convert.ToChar(":"))
    '                'strHedInfo &= strTmp(strTmp.Length - 1)
    '                strHedInfo &= centerNm
    '            End If
    '            '2015/11/04 w.ganeko 2015改善開発 №6 start
    '            If pstrHanbaiCdFr.Length <> 0 Or pstrHanbaiCdTo.Length <> 0 Then '販売事業者 両方or片方が設定されている場合
    '                strHedInfo &= "　販売事業者:"
    '                If pstrHanbaiCdFr.Length <> 0 And pstrHanbaiCdFr = pstrHanbaiCdTo Then '販売事業者 from、toが同じ場合→名称１つを表示
    '                    strHedInfo &= HanNmFr
    '                Else
    '                    strHedInfo &= HanNmFr & " ～ " & HanNmTo
    '                End If
    '            End If
    '            '2015/11/04 w.ganeko 2015改善開発 №6 end
    '            strHedInfo &= "　ＪＡ:"
    '            If pstrJaCdFr.Length <> 0 And pstrJaCdFr = pstrJaCdTo Then 'ＪＡ名称 from、toが同じ場合→名称１つを表示
    '                'strTmp = pstrJaNm.Split(Convert.ToChar(":"))
    '                'strHedInfo &= strTmp(strTmp.Length - 1)
    '                strHedInfo &= jaNmFr
    '            ElseIf pstrJaCdFr.Length <> 0 Or pstrJaCdTo.Length <> 0 Then 'ＪＡ名称 両方or片方が設定されている場合 
    '                'strTmp = pstrJaNm.Split(Convert.ToChar(":"))
    '                'strHedInfo &= strTmp(strTmp.Length - 1)
    '                'strHedInfo &= Convert.ToString(dr.Item("JANM"))
    '                strHedInfo &= jaNmFr & " ～ " & jaNmTo
    '            End If
    '            strHedInfo &= "　ＪＡ支所:"
    '            'If pstrJasCd.Length <> 0 Then
    '            '    strTmp = pstrJasNm.Split(Convert.ToChar(":"))
    '            '    strHedInfo &= strTmp(strTmp.Length - 1)
    '            '    'strHedInfo &= Convert.ToString(dr.Item("ACBNM"))
    '            'End If
    '            If pstrJasCdFr.Length <> 0 And pstrJasCdFr = pstrJasCdTo Then 'ＪＡ名称 from、toが同じ場合→名称１つを表示
    '                strHedInfo &= jasNmFr
    '            ElseIf pstrJasCdFr.Length <> 0 Or pstrJasCdTo.Length <> 0 Then 'ＪＡ名称 両方or片方が設定されている場合 
    '                strHedInfo &= jasNmFr & " ～ " & jasNmTo
    '            End If

    '            ExcelC.pCellStyle(1) = "height:16px;font-size:13px;border-top-style:none;border-bottom-style:none"
    '            ExcelC.pCellVal(1, "colspan = 9") = strHedInfo
    '            ExcelC.mWriteLine("")           '行をファイルに書き込む

    '            '抽出条件（下段）
    '            '2011.11.21 MOD H.Uema *---------------* start
    '            'If pstrStkbn = "1" Then
    '            '    strHedInfo = "発生区分:電話"
    '            'Else
    '            '    strHedInfo = "発生区分:警報"
    '            'End If
    '            If pstrStkbn = "1" Then
    '                strHedInfo = "発生区分:電話"
    '            ElseIf pstrStkbn = "2" Then
    '                strHedInfo = "発生区分:警報"
    '            Else
    '                strHedInfo = "発生区分:電話／警報"
    '            End If
    '            '2011.11.21 MOD H.Uema *---------------* end

    '            If pstrTrgTo <> "" Then
    '                strHedInfo &= "　対象期間:" & DateFncC.mGet(pstrTrgFrom) & "～" & DateFncC.mGet(pstrTrgTo)
    '            Else
    '                strHedInfo &= "　対象期間:" & DateFncC.mGet(pstrTrgFrom)
    '            End If
    '            ExcelC.pCellStyle(1) = "height:16px;font-size:13px;border-top-style:none"
    '            ExcelC.pCellVal(1, "colspan = 9") = strHedInfo
    '            ExcelC.mWriteLine("")           '行をファイルに書き込む
    '        End If

    '        '明細データ出力
    '        Dim intd As Integer = 0                   '処理件数
    '        Dim intRow As Integer = 0                   '処理件数
    '        Dim iRCnt As Integer = 0                   '処理件数
    '        Dim iCnt As Integer
    '        Dim strKyoCd As String = ""    '前回供給センターコード
    '        Dim strJaCd As String = ""         '前回ＪＡコード
    '        Dim strAcdCd As String = ""       '前回ＪＡ支所コード
    '        Dim strHanjiCd As String = ""       '前回販売事業者コード 2015/11/04 w.ganeko 2015改善開発 №6
    '        Dim blnFlg As Boolean = False                '初回フラグ

    '        '--- ↓2005/05/23 ADD Falcon↓ ---
    '        Dim strSTD_CD As String
    '        Dim intHedFlg As Integer = 0
    '        '--- ↑2005/05/23 ADD Falcon↑ ---
    '        Dim strTAIOKBN As String        '--- 2005/05/26 ADD Falcon ---

    '        '--- ↓2005/07/12 ADD Falcon↓ ---
    '        Dim strTFKICD As String
    '        Dim bolStdFlg As Boolean        '出動情報表示フラグ(True：表示　False：非表示)
    '        '--- ↑2005/07/12 ADD Falcon↑ ---

    '        '2006/02/01 NEC ADD START
    '        '出動があったかどうか判別するためのDataRow
    '        Dim drPageBreak As DataRow
    '        'カウンタ
    '        Dim intCntPageBreak As Integer

    '        '2006/02/01 NEC ADD END

    '        If ds.Tables(0).Rows.Count = 0 And pstrZeroSend = "1" Then '2010/06/02 T.Watabe add
    '            '対象０件でゼロ件出力あり→データセットをスルー

    '            ExcelC.mWriteLine("")           '行をファイルに書き込む
    '            ExcelC.pCellStyle(1) = "height:16px;text-align:left;font-size:13px;border-style:none;"
    '            ExcelC.pCellVal(1, "colspan=7") = "期間内の情報はありませんでした。"
    '            ExcelC.mWriteLine("")           '行をファイルに書き込む

    '        ElseIf ds.Tables(0).Rows.Count = 0 Then '2010/06/02 T.Watabe add
    '            '対象０件→データセットをスルー

    '        Else

    '            dr = ds.Tables(0).Rows(0)           'データローにデータセットを格納
    '            strKyoCd = Convert.ToString(ds.Tables(0).Rows(0).Item("HAISO_CD"))    '前回供給センターコード
    '            strJaCd = Convert.ToString(ds.Tables(0).Rows(0).Item("JACD"))         '前回ＪＡコード
    '            strAcdCd = Convert.ToString(ds.Tables(0).Rows(0).Item("ACBCD"))       '前回ＪＡ支所コード
    '            strHanjiCd = Convert.ToString(ds.Tables(0).Rows(0).Item("HANJICD"))   '前回販売事業者コード 2015/11/04 W.GANEKO 2015改善開発 №6

    '            'APサーバからの戻り値をループする
    '            'For Each dr In ds.Tables(0).Rows
    '            For iCnt = 0 To ds.Tables(0).Rows.Count - 1
    '                dr = ds.Tables(0).Rows(iCnt)

    '                If pstrPgkbn = "1" Then
    '                    'JA単位
    '                    If strJaCd <> Convert.ToString(dr.Item("JACD")) Then
    '                        '改ページを行う
    '                        ExcelC.mWriteLine("", True)
    '                        strJaCd = Convert.ToString(dr.Item("JACD"))
    '                        intRow = 0
    '                    End If
    '                    '2015/11/04 w.ganeko 2015改善開発 №6 start
    '                    'ElseIf pstrPgkbn = "2" Then
    '                    '    '供給センター単位
    '                    '    If strKyoCd <> Convert.ToString(dr.Item("HAISO_CD")) Then
    '                    '        '改ページを行う
    '                    '        ExcelC.mWriteLine("", True)
    '                    '        strKyoCd = Convert.ToString(dr.Item("HAISO_CD"))
    '                    '        intRow = 0
    '                    '    End If
    '                ElseIf pstrPgkbn = "2" Then
    '                    'JA支所単位
    '                    If strKyoCd <> Convert.ToString(dr.Item("ACBCD")) Then
    '                        '改ページを行う
    '                        ExcelC.mWriteLine("", True)
    '                        strKyoCd = Convert.ToString(dr.Item("ACBCD"))
    '                        intRow = 0
    '                    End If
    '                ElseIf pstrPgkbn = "3" Then
    '                    '販売事業者単位
    '                    If strHanjiCd <> Convert.ToString(dr.Item("HANJICD")) Then
    '                        '改ページを行う
    '                        ExcelC.mWriteLine("", True)
    '                        strHanjiCd = Convert.ToString(dr.Item("HANJICD"))
    '                        intRow = 0
    '                    End If
    '                ElseIf pstrPgkbn = "4" Then
    '                    '供給センター単位
    '                    If strKyoCd <> Convert.ToString(dr.Item("HAISO_CD")) Then
    '                        '改ページを行う
    '                        ExcelC.mWriteLine("", True)
    '                        strKyoCd = Convert.ToString(dr.Item("HAISO_CD"))
    '                        intRow = 0
    '                    End If
    '                    '2015/11/04 w.ganeko 2015改善開発 №6 end
    '                End If

    '                '--- ↓2005/05/23 MOD Falcon↓ ---
    '                'If intRow = 0 Or (intRow Mod 5) = 0 Then
    '                'If intRow > 0 And (intRow Mod 5) = 0 Then
    '                '   ExcelC.mWriteLine("", True)
    '                'End If

    '                intHedFlg = 0
    '                '2006/02/01 NEC UPDATE START
    '                'strSTD_CD = Convert.ToString(dr.Item("STD_CD"))         '出動会社コード
    '                ''--- ↓2005/05/26 ADD Falcon↓ ---
    '                'strTAIOKBN = Convert.ToString(dr.Item("TAIOKBN"))       '対応区分（１：電話対応　２：出動指示）
    '                ''--- ↑2005/05/26 ADD Falcon↑ ---

    '                ''--- ↓2005/07/12 ADD Falcon↓ ---
    '                'strTFKICD = Convert.ToString(dr.Item("TFKICD"))         '復帰対応状況(8:緊急出動（委託先）)
    '                'If (strSTD_CD.Length <> 0) And (strTAIOKBN = "2") And (strTFKICD = "8") Then
    '                '    bolStdFlg = True    '出動情報表示
    '                'Else
    '                '    bolStdFlg = False   '出動情報非表示
    '                'End If
    '                intCntPageBreak = iCnt
    '                If intRow = 0 Or (intGYOSU = 4 And (intRow Mod 4) = 0) _
    '                        Or (intGYOSU = 3 And (intRow Mod 3) = 0) Then
    '                    bolStdFlg = False   '出動情報非表示
    '                    '現在の行から４行先までに出動情報が存在するかチェック
    '                    Do Until intCntPageBreak - iCnt = 4
    '                        If intCntPageBreak <= ds.Tables(0).Rows.Count - 1 Then
    '                            drPageBreak = ds.Tables(0).Rows(intCntPageBreak)
    '                            strSTD_CD = Convert.ToString(drPageBreak.Item("STD_CD"))         '出動会社コード
    '                            strTAIOKBN = Convert.ToString(drPageBreak.Item("TAIOKBN"))       '対応区分（１：電話対応　２：出動指示）
    '                            strTFKICD = Convert.ToString(drPageBreak.Item("TFKICD"))         '復帰対応状況(8:緊急出動（委託先）)
    '                            If (strSTD_CD.Length <> 0) And (strTAIOKBN = "2") And (strTFKICD = "8") Then
    '                                bolStdFlg = True    '出動情報表示
    '                            End If
    '                        End If
    '                        'カウントアップ
    '                        intCntPageBreak += 1
    '                    Loop
    '                End If
    '                '2006/02/01 NEC UPDATE END

    '                '--- ↑2005/07/12 ADD Falcon↑ ---

    '                If intRow = 0 Then
    '                    intHedFlg = 1       '１番最初は必ずヘッダをヘッダを書き込む
    '                    '//出力行数の設定---------------
    '                    '--- ↓2005/07/12 MOD Falcon↓ ---
    '                    ''出動会社コードが存在しない場合４行出力、存在する場合は３行出力
    '                    'If strSTD_CD.Length = 0 Then
    '                    '１ページの行数は出動情報非表示の場合は４行、表示の場合は３行を設定
    '                    If bolStdFlg = True Then
    '                        intGYOSU = 3
    '                    Else
    '                        intGYOSU = 4
    '                    End If
    '                    '--- ↑2005/07/12 MOD Falcon↑ ---
    '                    '//-----------------------------
    '                Else
    '                    If (intGYOSU = 4 And (intRow Mod 4) = 0) _
    '                        Or (intGYOSU = 3 And (intRow Mod 3) = 0) Then
    '                        intHedFlg = 1   'ヘッダ書き込み：有
    '                        intRow = 0      '行数カウント：0
    '                        intGYOSU = 0    '１ページ出力数：0
    '                        '//出力行数の設定---------------
    '                        '--- ↓2005/07/12 MOD Falcon↓ ---
    '                        '出動会社コードが存在しない場合４行出力、存在する場合は３行出力
    '                        'If strSTD_CD.Length = 0 Then
    '                        '１ページの行数は出動情報非表示の場合は４行、表示の場合は３行を設定
    '                        If bolStdFlg = True Then
    '                            intGYOSU = 3
    '                        Else
    '                            intGYOSU = 4
    '                        End If
    '                        '--- ↑2005/07/12 MOD Falcon↑ ---
    '                        '//-----------------------------
    '                        ExcelC.mWriteLine("", True)
    '                    Else
    '                        '//出力行数の設定---------------
    '                        If intGYOSU = 4 Then
    '                            '--- ↓2005/07/12 MOD Falcon↓ ---
    '                            '出動会社コードが存在する場合は３行出力
    '                            'If strSTD_CD.Length <> 0 Then
    '                            If bolStdFlg = True Then
    '                                intGYOSU = 3
    '                            Else
    '                                intGYOSU = intGYOSU
    '                            End If
    '                            '--- ↑2005/07/12 MOD Falcon↑ ---
    '                        Else
    '                            intGYOSU = intGYOSU
    '                        End If
    '                        '//-----------------------------
    '                    End If
    '                End If

    '                If intHedFlg = 1 Then
    '                    ExcelC.mWriteLine("")
    '                    ExcelC.pCellStyle(1) = "height:16px;text-align:left;font-size:13px;border:none"
    '                    ExcelC.pCellStyle(2) = "height:16px;text-align:left;font-size:13px;border:none"     '<-- 2005/05/21 ADD
    '                    'ExcelC.pCellVal(1, "colspan=2") = "県名：" & Convert.ToString(dr.Item("KENNM"))
    '                    ExcelC.pCellVal(1, "colspan=2") = "県名：" & kenNm
    '                    If pstrPgkbn = "1" Then
    '                        ExcelC.pCellVal(2, "colspan=7") = "ＪＡ名：" & Convert.ToString(dr.Item("JANM"))
    '                        'ExcelC.pCellVal(1, "colspan=9") = "ＪＡ名：" & Convert.ToString(dr.Item("JANM"))
    '                        ''& "　" & "ＪＡ支所名：" & Convert.ToString(dr.Item("ACBNM"))
    '                        '2015/11/04 w.ganeko 2015改善開発 №6 start
    '                        'ElseIf pstrPgkbn = "2" Then
    '                        '    ExcelC.pCellVal(2, "colspan=7") = "供給センター名：" & Convert.ToString(dr.Item("NAME"))
    '                        '    'ExcelC.pCellVal(1, "colspan=9") = "供給センター名：" & Convert.ToString(dr.Item("NAME"))
    '                        '2015/11/04 w.ganeko 2015改善開発 №6 start
    '                    ElseIf pstrPgkbn = "2" Then
    '                        ExcelC.pCellVal(2, "colspan=7") = "JA支所名：" & Convert.ToString(dr.Item("ACBNM"))
    '                    ElseIf pstrPgkbn = "3" Then
    '                        ExcelC.pCellVal(2, "colspan=7") = "販売事業者名：" & Convert.ToString(dr.Item("HANJINM"))
    '                    ElseIf pstrPgkbn = "4" Then
    '                        ExcelC.pCellVal(2, "colspan=7") = "供給センター名：" & Convert.ToString(dr.Item("NAME"))
    '                        '2015/11/04 w.ganeko 2015改善開発 №6 end
    '                    End If
    '                    ExcelC.mWriteLine("")


    '                    iRCnt = iRCnt + 1
    '                End If

    '                '--- ↑2005/05/23 MOD Falcon↑ ---

    '                '明細項目
    '                '--- ↓2005/05/21 MOD Falcon↓ ---  '移動
    '                '1段目----------------------------------------------------------------
    '                '2006/06/13 NEC UPDATE START
    '                'ExcelC.pCellStyle(1) = "text-align:right;height:16px;font-size:13px;border-bottom-style:none;border-right-style:none"
    '                'ExcelC.pCellVal(1) = "ＪＡ名:"
    '                'ExcelC.pCellStyle(2) = "height:16px;font-size:13px;border-bottom-style:none;border-left-style:none;border-right-style:none"
    '                'ExcelC.pCellVal(2, "colspan = 5") = Convert.ToString(dr.Item("JACD")) & "　" & Convert.ToString(dr.Item("JANM"))
    '                ''JA/JA支所
    '                'ExcelC.pCellStyle(3) = "text-align:right;height:16px;font-size:13px;border-bottom-style:none;border-left-style:none;border-right-style:none"
    '                'ExcelC.pCellVal(3) = "ＪＡ支所名:"
    '                'ExcelC.pCellStyle(4) = "height:16px;font-size:13px;border-bottom-style:none;border-left-style:none"
    '                'ExcelC.pCellVal(4, "colspan = 2") = Convert.ToString(dr.Item("ACBCD")) & "　" & Convert.ToString(dr.Item("ACBNM"))
    '                'ExcelC.mWriteLine("")           '行をファイルに書き込む
    '                'JA支所
    '                ExcelC.pCellStyle(1) = "text-align:right;height:16px;font-size:13px;border-bottom-style:none;border-right-style:none"
    '                ExcelC.pCellVal(1, "colspan = 2") = "ＪＡ支所名:"
    '                ExcelC.pCellStyle(2) = "height:16px;font-size:13px;border-bottom-style:none;border-left-style:none"
    '                ExcelC.pCellVal(2, "colspan = 7") = Convert.ToString(dr.Item("ACBCD")) & "　" & Convert.ToString(dr.Item("ACBNM"))
    '                ExcelC.mWriteLine("")           '行をファイルに書き込む
    '                '2006/06/13 NEC UPDATE END

    '                '----------------------------------------------------------------------
    '                '--- ↑2005/05/21 MOD Falcon↑ ---
    '                '2段目-----------------------------------------------------------------
    '                'お客様名
    '                ExcelC.pCellStyle(1) = "height:16px;text-align:right;font-size:13px;border-top-style:none;border-bottom-style:none;border-right-style:none"
    '                ' 2015/02/12 H.Hosoda mod 2014改善開発 No9 START
    '                'ExcelC.pCellVal(1) = "氏名:"
    '                ExcelC.pCellVal(1) = "お客様名:"
    '                ' 2015/02/12 H.Hosoda mod 2014改善開発 No9 END
    '                ExcelC.pCellStyle(2) = "font-size:13px;border-top-style:none;border-bottom-style:none;border-left-style:none;border-right-style:none"
    '                ExcelC.pCellVal(2, "colspan = 5") = Convert.ToString(dr.Item("JUSYONM"))
    '                'お客様コード
    '                ExcelC.pCellStyle(3) = "text-align:right;font-size:13px;border-top-style:none;border-bottom-style:none;border-left-style:none;border-right-style:none"
    '                ' 2015/02/12 H.Hosoda mod 2014改善開発 No9 START
    '                'ExcelC.pCellVal(3) = "需要家コード:"
    '                ExcelC.pCellVal(3) = "お客様コード:"
    '                ' 2015/02/12 H.Hosoda mod 2014改善開発 No9 END
    '                ExcelC.pCellStyle(4) = "font-size:13px;border-top-style:none;border-bottom-style:none;border-left-style:none"
    '                ExcelC.pCellVal(4, "colspan = 2") = Convert.ToString(dr.Item("JUYOKA"))
    '                ExcelC.mWriteLine("")           '行をファイルに書き込む
    '                '3段目-----------------------------------------------------------------
    '                '結線番号
    '                ExcelC.pCellStyle(1) = "height:16px;text-align:right;font-size:13px;border-top-style:none;border-right-style:none;border-bottom-style:none"
    '                ' 2015/02/12 H.Hosoda mod 2014改善開発 No9 START
    '                'ExcelC.pCellVal(1) = "TEL:"
    '                ExcelC.pCellVal(1) = "結線番号:"
    '                ' 2015/02/12 H.Hosoda mod 2014改善開発 No9 END
    '                ExcelC.pCellStyle(2) = "font-size:13px;border-style:none"
    '                '2006/06/14 NEC UPDATE START
    '                'ExcelC.pCellVal(2, "colspan = 5") = Convert.ToString(dr.Item("JUTEL"))
    '                If Convert.ToString(dr.Item("JUTEL1")) = "" Then
    '                    ExcelC.pCellVal(2, "colspan = 5") = Convert.ToString(dr.Item("JUTEL2"))
    '                Else
    '                    ExcelC.pCellVal(2, "colspan = 5") = Convert.ToString(dr.Item("JUTEL1")) & "-" & Convert.ToString(dr.Item("JUTEL2"))
    '                End If
    '                '2006/06/14 NEC UPDATE END
    '                '連絡先
    '                ExcelC.pCellStyle(3) = "text-align:right;font-size:13px;border-style:none"
    '                ExcelC.pCellVal(3) = "連絡先:"
    '                ExcelC.pCellStyle(4) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
    '                ExcelC.pCellVal(4, "colspan = 2") = Convert.ToString(dr.Item("RENTEL"))
    '                ExcelC.mWriteLine("")           '行をファイルに書き込む
    '                '4段目-----------------------------------------------------------------
    '                '住所
    '                ExcelC.pCellStyle(1) = "height:16px;text-align:right;font-size:13px;border-top-style:none;border-right-style:none;border-bottom-style:none"
    '                ExcelC.pCellVal(1) = "住所:"
    '                ExcelC.pCellStyle(2) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:dashed"
    '                ExcelC.pCellVal(2, "colspan = 8") = Convert.ToString(dr.Item("ADDR"))
    '                ExcelC.mWriteLine("")           '行をファイルに書き込む
    '                ''5段目-----------------------------------------------------------------
    '                ''受付時間
    '                'ExcelC.pCellStyle(1) = "height:16px;font-size:13px;border-top-style:dashed;border-bottom-style:none"
    '                'ExcelC.pCellVal(1, "colspan = 9") = "受付時間:" & _
    '                '                                    DateFncC.mGet(Convert.ToString(dr.Item("HATYMD"))) & _
    '                '                                    " " & CTimeFncC.mGet(Convert.ToString(dr.Item("HATTIME")), 0)
    '                'ExcelC.mWriteLine("")           '行をファイルに書き込む
    '                '5段目-----------------------------------------------------------------
    '                ExcelC.pCellStyle(1) = "height:16px;font-size:13px;border-right-style:none;border-bottom-style:none"
    '                ExcelC.pCellVal(1) = "<緊急>"
    '                '事象数
    '                ExcelC.pCellStyle(2) = "text-align:right;font-size:13px;border-left-style:none;border-right-style:none;border-bottom-style:none"
    '                ExcelC.pCellVal(2) = "事象数:"
    '                ExcelC.pCellStyle(3) = "font-size:13px;border-left-style:none;border-right-style:none;border-bottom-style:none"
    '                ExcelC.pCellVal(3) = Convert.ToString(dr.Item("KEIHOSU"))
    '                '流量区分
    '                ExcelC.pCellStyle(4) = "text-align:right;font-size:13px;border-left-style:none;border-right-style:none;border-bottom-style:none"
    '                ExcelC.pCellVal(4) = "流量区分:"
    '                ExcelC.pCellStyle(5) = "font-size:13px;border-left-style:none;border-bottom-style:none"
    '                ExcelC.pCellVal(5) = Convert.ToString(dr.Item("RYURYO"))
    '                '処理区分
    '                ExcelC.pCellStyle(6) = "text-align:right;font-size:13px;border-top-style:none;border-right-style:none;border-bottom-style:none"
    '                ' 2015/02/17 H.Hosoda mod 2014改善開発 No9 START
    '                'ExcelC.pCellVal(6) = "処理種別:"
    '                ExcelC.pCellVal(6) = "処理区分:"
    '                ' 2015/02/17 H.Hosoda mod 2014改善開発 No9 END
    '                ExcelC.pCellStyle(7) = "font-size:13px;border-style:none"
    '                ExcelC.pCellVal(7) = Convert.ToString(dr.Item("TMSKB_NAI"))
    '                '2006/06/13 NEC UPDATE START
    '                ''処理日時
    '                'ExcelC.pCellStyle(8) = "text-align:right;font-size:13px;border-style:none"
    '                'ExcelC.pCellVal(8) = "処理日時:"
    '                'ExcelC.pCellStyle(9) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
    '                'ExcelC.pCellVal(9) = DateFncC.mGet(Convert.ToString(dr.Item("SYOYMD"))) & _
    '                '                     " " & CTimeFncC.mGet(Convert.ToString(dr.Item("SYOTIME")), 0)
    '                '受信日時
    '                ExcelC.pCellStyle(8) = "text-align:right;font-size:13px;border-style:none"
    '                ' 2015/02/12 H.Hosoda mod 2014改善開発 No9 START
    '                'ExcelC.pCellVal(8) = "受付時間:"
    '                ExcelC.pCellVal(8) = "受信日時:"
    '                ' 2015/02/12 H.Hosoda mod 2014改善開発 No9 END
    '                ExcelC.pCellStyle(9) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
    '                ExcelC.pCellVal(9) = DateFncC.mGet(Convert.ToString(dr.Item("HATYMD"))) & _
    '                                                    " " & CTimeFncC.mGet(Convert.ToString(dr.Item("HATTIME")), 0)
    '                '2006/06/13 NEC UPDATE END
    '                ExcelC.mWriteLine("")           '行をファイルに書き込む
    '                '6段目-----------------------------------------------------------------
    '                '警報１メッセージ
    '                ExcelC.pCellStyle(1) = "height:16px;font-size:13px;border-top-style:none;border-bottom-style:none"
    '                ExcelC.pCellVal(1, "colspan = 5") = Convert.ToString(dr.Item("KMNM1"))
    '                '連絡相手
    '                ExcelC.pCellStyle(2) = "text-align:right;font-size:13px;border-top-style:none;border-right-style:none;border-bottom-style:none"
    '                ' 2015/02/12 H.Hosoda mod 2014改善開発 No9 START
    '                'ExcelC.pCellVal(2) = "連絡相手先:"
    '                ExcelC.pCellVal(2) = "連絡相手:"
    '                ' 2015/02/12 H.Hosoda mod 2014改善開発 No9 END
    '                ExcelC.pCellStyle(3) = "font-size:13px;border-style:none"
    '                ExcelC.pCellVal(3) = Convert.ToString(dr.Item("TAITNM"))
    '                '2006/06/13 NEC UPDATE START
    '                ''対応区分
    '                'ExcelC.pCellStyle(4) = "text-align:right;font-size:13px;border-style:none"
    '                'ExcelC.pCellVal(4) = "対応区分:"
    '                'ExcelC.pCellStyle(5) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
    '                'ExcelC.pCellVal(5) = Convert.ToString(dr.Item("TAIOKBN_NAI"))
    '                '完了日時
    '                ExcelC.pCellStyle(4) = "text-align:right;font-size:13px;border-style:none"
    '                ' 2015/02/12 H.Hosoda mod 2014改善開発 No9 START
    '                'ExcelC.pCellVal(4) = "処理日時:"
    '                ExcelC.pCellVal(4) = "完了日時:"
    '                ' 2015/02/12 H.Hosoda mod 2014改善開発 No9 END
    '                ExcelC.pCellStyle(5) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
    '                ExcelC.pCellVal(5) = DateFncC.mGet(Convert.ToString(dr.Item("SYOYMD"))) & _
    '                                     " " & CTimeFncC.mGet(Convert.ToString(dr.Item("SYOTIME")), 0)
    '                '2006/06/13 NEC UPDATE END
    '                ExcelC.mWriteLine("")           '行をファイルに書き込む
    '                '7段目-----------------------------------------------------------------
    '                '警報２メッセージ
    '                ExcelC.pCellStyle(1) = "height:16px;font-size:13px;border-top-style:none;border-bottom-style:none"
    '                ExcelC.pCellVal(1, "colspan = 5") = Convert.ToString(dr.Item("KMNM2"))
    '                '担当者名
    '                ExcelC.pCellStyle(2) = "text-align:right;font-size:13px;border-top-style:none;border-right-style:none;border-bottom-style:none"
    '                ExcelC.pCellVal(2) = "担当者名:"
    '                '2006/06/13 NEC UPDATE START
    '                'ExcelC.pCellStyle(3) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
    '                ExcelC.pCellStyle(3) = "font-size:13px;border-style:none"
    '                'ExcelC.pCellVal(3, "colspan = 3") = Convert.ToString(dr.Item("TKTANCD_NM"))
    '                ExcelC.pCellVal(3) = Convert.ToString(dr.Item("TKTANCD_NM"))
    '                '2011.11.21 MOD H.Uema *-------------------* start
    '                ''対応区分
    '                'ExcelC.pCellStyle(4) = "text-align:right;font-size:13px;border-style:none"
    '                'ExcelC.pCellVal(4) = "対応区分:"
    '                'ExcelC.pCellStyle(5) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
    '                'ExcelC.pCellVal(5) = Convert.ToString(dr.Item("TAIOKBN_NAI"))
    '                ' 2015/02/12 H.Hosoda mod 2014改善開発 No9 START
    '                ''発生区分
    '                'ExcelC.pCellStyle(4) = "text-align:right;font-size:13px;border-style:none"
    '                'ExcelC.pCellVal(4) = "発生区分:"
    '                'ExcelC.pCellStyle(5) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
    '                'ExcelC.pCellVal(5) = Convert.ToString(dr.Item("HATKBN_NAI"))
    '                '2011.11.21 MOD H.Uema *-------------------* end
    '                '依頼日時
    '                ExcelC.pCellStyle(4) = "text-align:right;font-size:13px;border-style:none"
    '                ExcelC.pCellVal(4) = "依頼日時:"
    '                ExcelC.pCellStyle(5) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
    '                ExcelC.pCellVal(5) = DateFncC.mGet(Convert.ToString(dr.Item("SIJIYMD"))) & _
    '                                     " " & CTimeFncC.mGet(Convert.ToString(dr.Item("SIJITIME")), 0)
    '                ' 2015/02/12 H.Hosoda mod 2014改善開発 No9 END
    '                '2006/06/13 NEC UPDATE END
    '                ExcelC.mWriteLine("")           '行をファイルに書き込む
    '                '8段目-----------------------------------------------------------------
    '                '警報３メッセージ
    '                ExcelC.pCellStyle(1) = "height:16px;font-size:13px;border-top-style:none;border-bottom-style:none"
    '                ExcelC.pCellVal(1, "colspan = 5") = Convert.ToString(dr.Item("KMNM3"))
    '                '復帰作業
    '                ExcelC.pCellStyle(2) = "text-align:right;font-size:13px;border-top-style:none;border-right-style:none;border-bottom-style:none"
    '                ExcelC.pCellVal(2) = "復帰操作:"
    '                'ExcelC.pCellStyle(3) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
    '                'ExcelC.pCellVal(3, "colspan = 3") = Convert.ToString(dr.Item("TFKINM")) '2010/03/05 T.Watabe edit
    '                ExcelC.pCellStyle(3) = "font-size:13px;border-style:none"
    '                ExcelC.pCellVal(3) = Convert.ToString(dr.Item("TFKINM"))
    '                '2011.11.21 MOD H.Uema *-------------------* start
    '                ''メータ指針値 '2010/03/05 T.Watabe add
    '                'ExcelC.pCellStyle(4) = "text-align:right;font-size:13px;border-style:none"
    '                'ExcelC.pCellVal(4) = "メータ値:"
    '                'ExcelC.pCellStyle(5) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
    '                'ExcelC.pCellVal(5) = Convert.ToString(dr.Item("KENSIN"))
    '                ' 2015/02/12 H.Hosoda mod 2014改善開発 No9 START
    '                ''対応区分
    '                'ExcelC.pCellStyle(4) = "text-align:right;font-size:13px;border-style:none"
    '                'ExcelC.pCellVal(4) = "対応区分:"
    '                'ExcelC.pCellStyle(5) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
    '                'ExcelC.pCellVal(5) = Convert.ToString(dr.Item("TAIOKBN_NAI"))
    '                '2011.11.21 MOD H.Uema *-------------------* end
    '                '発生区分
    '                ExcelC.pCellStyle(4) = "text-align:right;font-size:13px;border-style:none"
    '                ExcelC.pCellVal(4) = "発生区分:"
    '                ExcelC.pCellStyle(5) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
    '                ExcelC.pCellVal(5) = Convert.ToString(dr.Item("HATKBN_NAI"))
    '                ' 2015/02/12 H.Hosoda mod 2014改善開発 No9 END
    '                ExcelC.mWriteLine("")           '行をファイルに書き込む
    '                '9段目-----------------------------------------------------------------
    '                '警報４メッセージ
    '                ExcelC.pCellStyle(1) = "height:16px;font-size:13px;border-top-style:none;border-bottom-style:none"
    '                ExcelC.pCellVal(1, "colspan = 5") = Convert.ToString(dr.Item("KMNM4"))
    '                '原因器具
    '                ExcelC.pCellStyle(2) = "text-align:right;font-size:13px;border-top-style:none;border-right-style:none;border-bottom-style:none"
    '                ' 2015/02/12 H.Hosoda mod 2014改善開発 No9 START
    '                'ExcelC.pCellVal(2) = "器具原因:"
    '                ExcelC.pCellVal(2) = "原因器具:"
    '                ' 2015/02/12 H.Hosoda mod 2014改善開発 No9 END
    '                '2011.11.21 MOD H.Uema *-------------------* start
    '                'ExcelC.pCellStyle(3) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
    '                'ExcelC.pCellVal(3, "colspan = 3") = Convert.ToString(dr.Item("TKIGNM"))
    '                ExcelC.pCellStyle(3) = "font-size:13px;border-style:none"
    '                ExcelC.pCellVal(3) = Convert.ToString(dr.Item("TKIGNM"))
    '                ' 2015/02/12 H.Hosoda mod 2014改善開発 No9 START
    '                ''メータ指針値
    '                'ExcelC.pCellStyle(4) = "text-align:right;font-size:13px;border-style:none"
    '                'ExcelC.pCellVal(4) = "メータ値:"
    '                'ExcelC.pCellStyle(5) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
    '                'ExcelC.pCellVal(5) = Convert.ToString(dr.Item("KENSIN"))
    '                '対応区分
    '                ExcelC.pCellStyle(4) = "text-align:right;font-size:13px;border-style:none"
    '                ExcelC.pCellVal(4) = "対応区分:"
    '                ExcelC.pCellStyle(5) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
    '                ExcelC.pCellVal(5) = Convert.ToString(dr.Item("TAIOKBN_NAI"))
    '                '2011.11.21 MOD H.Uema *-------------------* end
    '                ' 2015/02/12 H.Hosoda mod 2014改善開発 No9 END
    '                ExcelC.mWriteLine("")           '行をファイルに書き込む
    '                '10段目----------------------------------------------------------------
    '                '警報５メッセージ
    '                ExcelC.pCellStyle(1) = "height:16px;font-size:13px;border-top-style:none;border-bottom-style:none"
    '                ExcelC.pCellVal(1, "colspan = 5") = Convert.ToString(dr.Item("KMNM5"))
    '                '作動原因
    '                ExcelC.pCellStyle(2) = "text-align:right;font-size:13px;border-top-style:none;border-right-style:none;border-bottom-style:none"
    '                ExcelC.pCellVal(2) = "作動原因:"
    '                ' 2015/02/12 H.Hosoda mod 2014改善開発 No9 START
    '                'ExcelC.pCellVal(3, "colspan = 3") = Convert.ToString(dr.Item("TSADNM"))
    '                'ExcelC.pCellStyle(3) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
    '                ExcelC.pCellVal(3) = Convert.ToString(dr.Item("TSADNM"))
    '                ExcelC.pCellStyle(3) = "font-size:13px;border-style:none"
    '                ' 2015/02/12 H.Hosoda mod 2014改善開発 No9 END
    '                ' 2015/02/12 H.Hosoda add 2014改善開発 No9 START
    '                'メータ指針値
    '                ExcelC.pCellStyle(4) = "text-align:right;font-size:13px;border-style:none"
    '                ExcelC.pCellVal(4) = "メータ値:"
    '                ExcelC.pCellStyle(5) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
    '                ExcelC.pCellVal(5) = Convert.ToString(dr.Item("KENSIN"))
    '                ' 2015/02/12 H.Hosoda add 2014改善開発 No9 END
    '                ExcelC.mWriteLine("")           '行をファイルに書き込む
    '                '11段目----------------------------------------------------------------
    '                '警報６メッセージ
    '                ExcelC.pCellStyle(1) = "height:16px;font-size:13px;border-top-style:none"
    '                ExcelC.pCellVal(1, "colspan = 5") = Convert.ToString(dr.Item("KMNM6"))
    '                '--- ↓2005/05/21 MOD Falcon↓ ---
    '                '--- 出動情報の出力追加 ----------
    '                ExcelC.pCellStyle(2) = "text-align:right;font-size:13px;border-top-style:none;border-right-style:none;border-bottom-style:none"
    '                '2006/06/14 NEC UPDATE START
    '                'ExcelC.pCellVal(2) = ""
    '                'ExcelC.pCellStyle(3) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
    '                'ExcelC.pCellVal(3, "colspan = 3") = ""
    '                ' 2015/02/12 H.Hosoda mod 2014改善開発 No9 START
    '                'ExcelC.pCellVal(2) = "出動指示:"
    '                ExcelC.pCellVal(2) = "出動依頼:"
    '                ' 2015/02/12 H.Hosoda mod 2014改善開発 No9 END
    '                ExcelC.pCellStyle(3) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
    '                ExcelC.pCellVal(3, "colspan = 3") = Convert.ToString(dr.Item("SDNM"))
    '                '2006/06/14 NEC UPDATE END
    '                ExcelC.mWriteLine("")           '行をファイルに書き込む
    '                '12段目----------------------------------------------------------------
    '                '電話メモ１
    '                ExcelC.pCellStyle(1) = "height:16px;font-size:12px;border-top-style:none;border-bottom-style:none"
    '                ExcelC.pCellVal(1, "colspan = 9") = Convert.ToString(dr.Item("TEL_MEMO1"))
    '                ExcelC.mWriteLine("")           '行をファイルに書き込む
    '                '13段目----------------------------------------------------------------
    '                '電話メモ１
    '                ExcelC.pCellStyle(1) = "height:16px;font-size:12px;border-top-style:none;border-bottom-style:none"
    '                ExcelC.pCellVal(1, "colspan = 9") = Convert.ToString(dr.Item("TEL_MEMO2"))
    '                ExcelC.mWriteLine("")           '行をファイルに書き込む
    '                '14段目----------------------------------------------------------------
    '                '復帰操作メモ
    '                ExcelC.pCellStyle(1) = "height:16px;font-size:12px;border-top-style:none"
    '                ExcelC.pCellVal(1, "colspan = 9") = Convert.ToString(dr.Item("FUK_MEMO"))
    '                ExcelC.mWriteLine("")           '行をファイルに書き込む

    '                '2006/2/1 NEC UPDATE START
    '                ''If intGYOSU = 3 And strSTD_CD.Length <> 0 Then                     '--- 2005/05/26 DEL Falcon ---
    '                'If intGYOSU = 3 Then
    '                '    '--- ↓2005/07/12 MOD Falcon↓ ---
    '                '    'If strSTD_CD.Length <> 0 And strTAIOKBN = "2" Then  '--- 2005/05/26 MOD Falcon ---
    '                '    If bolStdFlg = True Then
    '                '        '--- ↑2005/07/12 MOD Falcon↑ ---
    '                '出動情報であれば、出動内容を表示
    '                If Convert.ToString(dr.Item("STD_CD")).Length <> 0 And _
    '                Convert.ToString(dr.Item("TAIOKBN")) = "2" And _
    '                Convert.ToString(dr.Item("TFKICD")) = "8" Then
    '                    '2006/2/1 NEC UPDATE END
    '                    '15段目-----------------------------------------------------------------
    '                    ExcelC.pCellStyle(1) = "height:16px;font-size:13px;border-bottom-style:none;border-right-style:none"
    '                    ExcelC.pCellVal(1, "colspan = 5") = "＜出動情報＞"
    '                    '対応相手
    '                    ExcelC.pCellStyle(2) = "text-align:right;height:16px;font-size:13px;border-bottom-style:none;border-left-style:none;border-right-style:none"
    '                    ' 2015/02/12 H.Hosoda mod 2014改善開発 No9 START
    '                    'ExcelC.pCellVal(2) = "連絡相手先:"
    '                    'ExcelC.pCellStyle(3) = "height:16px;font-size:13px;border-bottom-style:none;border-left-style:none"
    '                    'ExcelC.pCellVal(3, "colspan = 3") = Convert.ToString(dr.Item("AITNM"))
    '                    ExcelC.pCellVal(2) = "対応相手:"
    '                    ExcelC.pCellStyle(3) = "height:16px;font-size:13px;border-bottom-style:none;border-left-style:none;border-right-style:none"
    '                    ExcelC.pCellVal(3) = Convert.ToString(dr.Item("AITNM"))
    '                    '受信日時
    '                    ExcelC.pCellStyle(4) = "text-align:right;font-size:13px;border-style:none"
    '                    ExcelC.pCellVal(4) = "受信日時:"
    '                    ExcelC.pCellStyle(5) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
    '                    ExcelC.pCellVal(5) = DateFncC.mGet(Convert.ToString(dr.Item("SIJIYMD"))) & _
    '                                         " " & CTimeFncC.mGet(Convert.ToString(dr.Item("SIJITIME")), 0)
    '                    ' 2015/02/12 H.Hosoda mod 2014改善開発 No9 END
    '                    ExcelC.mWriteLine("")           '行をファイルに書き込む
    '                    '16段目-----------------------------------------------------------------
    '                    '出動対応者
    '                    ExcelC.pCellStyle(1) = "font-size:13px;border-top-style:none;border-bottom-style:none;border-right-style:none"
    '                    ' 2015/02/12 H.Hosoda mod 2014改善開発 No9 START
    '                    'ExcelC.pCellVal(1, "colspan = 5") = "受信者氏名:" & Convert.ToString(dr.Item("TSTANNM"))
    '                    ExcelC.pCellVal(1, "colspan = 5") = "出動対応者:" & Convert.ToString(dr.Item("SYUTDTNM"))
    '                    '原因器具
    '                    ExcelC.pCellStyle(2) = "text-align:right;height:16px;font-size:13px;border-top-style:none;border-bottom-style:none;border-left-style:none;border-right-style:none"
    '                    ExcelC.pCellVal(2) = "原因器具:"
    '                    ExcelC.pCellStyle(3) = "height:16px;font-size:13px;border-top-style:none;border-bottom-style:none;border-left-style:none;border-right-style:none"
    '                    ExcelC.pCellVal(3) = Convert.ToString(dr.Item("KIGNM"))
    '                    '出動日時
    '                    ExcelC.pCellStyle(4) = "text-align:right;font-size:13px;border-style:none"
    '                    ExcelC.pCellVal(4) = "出動日時:"
    '                    ExcelC.pCellStyle(5) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
    '                    ExcelC.pCellVal(5) = DateFncC.mGet(Convert.ToString(dr.Item("SDYMD"))) & _
    '                                         " " & CTimeFncC.mGet(Convert.ToString(dr.Item("SDTIME")), 0)
    '                    ' 2015/02/12 H.Hosoda mod 2014改善開発 No9 END
    '                    ' 2015/02/12 H.Hosoda del 2014改善開発 No9 START
    '                    ''作動原因
    '                    'ExcelC.pCellStyle(3) = "text-align:right;height:16px;font-size:13px;border-top-style:none;border-bottom-style:none;border-left-style:none;border-right-style:none"
    '                    'ExcelC.pCellVal(3) = "作動原因:"
    '                    'ExcelC.pCellStyle(4) = "height:16px;font-size:13px;border-top-style:none;border-bottom-style:none;border-left-style:none"
    '                    'ExcelC.pCellVal(4, "colspan = 3") = Convert.ToString(dr.Item("SADNM"))
    '                    ' 2015/02/12 H.Hosoda del 2014改善開発 No9 END
    '                    ExcelC.mWriteLine("")           '行をファイルに書き込む
    '                    '17段目-----------------------------------------------------------------
    '                    '復帰操作
    '                    ExcelC.pCellStyle(1) = "font-size:13px;border-top-style:none;border-bottom-style:none;border-right-style:none"
    '                    ExcelC.pCellVal(1, "colspan = 5") = "復帰操作:" & Convert.ToString(dr.Item("FKINM"))
    '                    ' 2015/02/12 H.Hosoda add 2014改善開発 No9 START
    '                    '作動原因
    '                    ExcelC.pCellStyle(2) = "text-align:right;height:16px;font-size:13px;border-top-style:none;border-bottom-style:none;border-left-style:none;border-right-style:none"
    '                    ExcelC.pCellVal(2) = "作動原因:"
    '                    ExcelC.pCellStyle(3) = "height:16px;font-size:13px;border-top-style:none;border-bottom-style:none;border-left-style:none;border-right-style:none"
    '                    ExcelC.pCellVal(3) = Convert.ToString(dr.Item("SADNM"))
    '                    '到着日時
    '                    ExcelC.pCellStyle(4) = "text-align:right;font-size:13px;border-style:none"
    '                    ExcelC.pCellVal(4) = "到着日時:"
    '                    ExcelC.pCellStyle(5) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
    '                    ExcelC.pCellVal(5) = DateFncC.mGet(Convert.ToString(dr.Item("TYAKYMD"))) & _
    '                                         " " & CTimeFncC.mGet(Convert.ToString(dr.Item("TYAKTIME")), 0)
    '                    ' 2015/02/12 H.Hosoda add 2014改善開発 No9 END
    '                    ' 2015/02/12 H.Hosoda del 2014改善開発 No9 START
    '                    ''センサ原因
    '                    'ExcelC.pCellStyle(3) = "text-align:right;height:16px;font-size:13px;border-top-style:none;border-bottom-style:none;border-left-style:none;border-right-style:none"
    '                    'ExcelC.pCellVal(3) = "センサ原因:"
    '                    'ExcelC.pCellStyle(4) = "height:16px;font-size:13px;border-top-style:none;border-bottom-style:none;border-left-style:none"
    '                    'ExcelC.pCellVal(4, "colspan = 3") = Convert.ToString(dr.Item("ASENM"))
    '                    ' 2015/02/12 H.Hosoda del 2014改善開発 No9 END
    '                    ExcelC.mWriteLine("")           '行をファイルに書き込む
    '                    '18段目-----------------------------------------------------------------
    '                    ' 2015/02/12 H.Hosoda del 2014改善開発 No9 START
    '                    ''器具原因
    '                    'ExcelC.pCellStyle(1) = "font-size:13px;border-top-style:none;border-bottom-style:none;border-right-style:none"
    '                    'ExcelC.pCellVal(1, "colspan = 5") = "器具原因:" & Convert.ToString(dr.Item("KIGNM"))
    '                    ''その他原因
    '                    'ExcelC.pCellStyle(3) = "text-align:right;height:16px;font-size:13px;border-top-style:none;border-bottom-style:none;border-left-style:none;border-right-style:none"
    '                    ''--- ↓2005/05/31 MOD Falcon↓ ---
    '                    ''ExcelC.pCellVal(3) = "その他原因:"
    '                    'ExcelC.pCellVal(3) = "ｿﾉﾀ原因:"
    '                    ''--- ↑2005/05/31 MOD Falcon↑ ---
    '                    'ExcelC.pCellStyle(4) = "height:16px;font-size:13px;border-top-style:none;border-bottom-style:none;border-left-style:none"
    '                    'ExcelC.pCellVal(4, "colspan = 3") = Convert.ToString(dr.Item("STANM"))
    '                    ' 2015/02/12 H.Hosoda del 2014改善開発 No9 END
    '                    ' 2015/02/12 H.Hosoda add 2014改善開発 No9 START
    '                    ExcelC.pCellStyle(1) = "font-size:13px;border-top-style:none;border-bottom-style:none;border-right-style:none"
    '                    ExcelC.pCellVal(1, "colspan = 7") = ""
    '                    '完了日時
    '                    ExcelC.pCellStyle(2) = "text-align:right;font-size:13px;border-style:none"
    '                    ExcelC.pCellVal(2) = "完了日時:"
    '                    ExcelC.pCellStyle(3) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
    '                    ExcelC.pCellVal(3) = DateFncC.mGet(Convert.ToString(dr.Item("SYOKANYMD"))) & _
    '                                         " " & CTimeFncC.mGet(Convert.ToString(dr.Item("SYOKANTIME")), 0)
    '                    ' 2015/02/12 H.Hosoda add 2014改善開発 No9 END
    '                    ExcelC.mWriteLine("")           '行をファイルに書き込む
    '                    '19段目-----------------------------------------------------------------
    '                    '2006/06/14 NEC UPDATE START
    '                    '出動備考
    '                    ExcelC.pCellStyle(1) = "font-size:13px;border-top-style:none;border-bottom-style:none;border-right-style:none"
    '                    ExcelC.pCellVal(1, "nowrap") = "出動備考:"
    '                    ExcelC.pCellStyle(2) = "height:16px;font-size:13px;border-top-style:none;border-bottom-style:none;border-left-style:none"
    '                    ExcelC.pCellVal(2, "colspan = 8") = Convert.ToString(dr.Item("SIJI_BIKO1"))
    '                    ExcelC.mWriteLine("")           '行をファイルに書き込む
    '                    ''20段目-----------------------------------------------------------------
    '                    ''備考１
    '                    'ExcelC.pCellStyle(1) = "text-align:right;font-size:13px;border-top-style:none;border-bottom-style:none;border-right-style:none"
    '                    'ExcelC.pCellVal(1) = "備考１:"
    '                    'ExcelC.pCellStyle(2) = "height:16px;font-size:13px;border-top-style:none;border-bottom-style:none;border-left-style:none"
    '                    'ExcelC.pCellVal(2, "colspan = 8") = Convert.ToString(dr.Item("SDTBIK1"))
    '                    'ExcelC.mWriteLine("")           '行をファイルに書き込む
    '                    ''21段目-----------------------------------------------------------------
    '                    ''備考２
    '                    'ExcelC.pCellStyle(1) = "text-align:right;font-size:13px;border-top-style:none;border-bottom-style:none;border-right-style:none"
    '                    'ExcelC.pCellVal(1) = "備考２:"
    '                    'ExcelC.pCellStyle(2) = "height:16px;font-size:13px;border-top-style:none;border-bottom-style:none;border-left-style:none"
    '                    'ExcelC.pCellVal(2, "colspan = 8") = Convert.ToString(dr.Item("SDTBIK2"))
    '                    'ExcelC.mWriteLine("")           '行をファイルに書き込む
    '                    ''22段目-----------------------------------------------------------------
    '                    ''その他特記
    '                    'ExcelC.pCellStyle(1) = "text-align:right;font-size:13px;border-top-style:none;border-right-style:none"
    '                    ''--- ↓2005/05/31 MOD Falcon↓ ---
    '                    ''ExcelC.pCellVal(1) = "その他特記:"
    '                    'ExcelC.pCellVal(1) = "ｿﾉﾀ特記:"
    '                    ''--- ↑2005/05/31 MOD Falcon↑ ---
    '                    'ExcelC.pCellStyle(2) = "height:16px;font-size:13px;border-top-style:none;border-left-style:none"
    '                    'ExcelC.pCellVal(2, "colspan = 8") = Convert.ToString(dr.Item("SNTTOKKI"))
    '                    'ExcelC.mWriteLine("")           '行をファイルに書き込む
    '                    '20段目-----------------------------------------------------------------
    '                    '出動結果(1)
    '                    ExcelC.pCellStyle(1) = "font-size:13px;border-top-style:none;border-bottom-style:none;border-right-style:none"
    '                    ExcelC.pCellVal(1, "nowrap") = "出動結果:"
    '                    ExcelC.pCellStyle(2) = "height:16px;font-size:12px;border-top-style:none;border-bottom-style:none;border-left-style:none"
    '                    ExcelC.pCellVal(2, "colspan = 8") = Convert.ToString(dr.Item("SDTBIK2"))
    '                    ExcelC.mWriteLine("")           '行をファイルに書き込む
    '                    '21段目-----------------------------------------------------------------
    '                    '出動結果(2)
    '                    ExcelC.pCellStyle(1) = "font-size:13px;border-top-style:none;border-bottom-style:none;border-right-style:none"
    '                    ExcelC.pCellVal(1) = ""
    '                    ExcelC.pCellStyle(2) = "height:16px;font-size:12px;border-top-style:none;border-bottom-style:none;border-left-style:none"
    '                    ExcelC.pCellVal(2, "colspan = 8") = Convert.ToString(dr.Item("SNTTOKKI"))
    '                    ExcelC.mWriteLine("")           '行をファイルに書き込む
    '                    '22段目-----------------------------------------------------------------
    '                    '出動結果(3)
    '                    ExcelC.pCellStyle(1) = "font-size:13px;border-top-style:none;border-right-style:none"
    '                    ExcelC.pCellVal(1) = ""
    '                    ExcelC.pCellStyle(2) = "height:16px;font-size:12px;border-top-style:none;border-left-style:none"
    '                    ExcelC.pCellVal(2, "colspan = 8") = Convert.ToString(dr.Item("SDTBIK3"))
    '                    ExcelC.mWriteLine("")           '行をファイルに書き込む
    '                    '2006/06/14 NEC UPDATE END
    '                End If
    '                '2006/2/1 NEC UPDATE START
    '                'End If
    '                '2006/2/1 NEC UPDATE END

    '                '--- ↑2005/05/21 MOD Falcon↑ ---

    '                '--- ↓2005/05/21 DEL Falcon↓ ---
    '                ''連絡内容１0
    '                'ExcelC.pCellStyle(2) = "text-align:right;font-size:13px;border-top-style:none;border-right-style:none;border-bottom-style:none"
    '                'ExcelC.pCellVal(2) = "連絡内容:"
    '                'ExcelC.pCellStyle(3) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
    '                'ExcelC.pCellVal(3, "colspan = 3") = Convert.ToString(dr.Item("TEL_MEMO1"))
    '                'ExcelC.mWriteLine("")           '行をファイルに書き込む
    '                ''12段目----------------------------------------------------------------
    '                'ExcelC.pCellStyle(1) = "height:16px;font-size:13px;none;border-right-style:none;border-bottom-style:dashed"
    '                'ExcelC.pCellVal(1, "colspan = 5") = ""
    '                ''連絡内容２
    '                'ExcelC.pCellStyle(2) = "text-align:right;font-size:13px;border-top-style:none;border-left-style:none;border-right-style:none"
    '                'ExcelC.pCellVal(2) = ""
    '                'ExcelC.pCellStyle(3) = "font-size:13px;border-top-style:none;border-left-style:none"
    '                'ExcelC.pCellVal(3, "colspan = 3") = Convert.ToString(dr.Item("TEL_MEMO2"))
    '                'ExcelC.mWriteLine("")           '行をファイルに書き込む
    '                ''13段目----------------------------------------------------------------
    '                'ExcelC.pCellStyle(1) = "height:16px;font-size:13px;border-top-style:none;border-right-style:none;"
    '                'ExcelC.pCellVal(1, "colspan = 5") = "JA名：" & Convert.ToString(dr.Item("JACD")) & "　" & _
    '                '                                               Convert.ToString(dr.Item("JANM"))
    '                ''JA/JA支所
    '                'ExcelC.pCellStyle(2) = "text-align:right;font-size:13px;border-top-style:none;border-left-style:none;border-right-style:none;"
    '                'ExcelC.pCellVal(2) = ""
    '                'ExcelC.pCellStyle(3) = "font-size:13px;border-top-style:none;border-left-style:none;"
    '                'ExcelC.pCellVal(3, "colspan = 3") = "JA支所名：" & Convert.ToString(dr.Item("ACBCD")) & "　" & _
    '                '                                               Convert.ToString(dr.Item("ACBNM"))
    '                'ExcelC.mWriteLine("")           '行をファイルに書き込む
    '                ''----------------------------------------------------------------------
    '                '--- ↑2005/05/21 DEL Falcon↑ ---
    '                '行数のカウント
    '                intRow = intRow + 1
    '                '2004/11/24 NEC ADD START
    '                If (intRow Mod intGYOSU) = 0 Then
    '                    'ExcelC.pCellStyle(1) = "height:6px;border:none"
    '                    'ExcelC.pCellVal(1, "colspan = 9") = ""
    '                    'ExcelC.mWriteLine("", True)
    '                Else
    '                    ExcelC.pCellStyle(1) = "height:6px;border:none"
    '                    ExcelC.pCellVal(1, "colspan = 9") = ""
    '                    ExcelC.mWriteLine("")   '行をファイルに書き込む
    '                End If

    '                '--- ↓2005/05/23 ADD Falcon↓ ---
    '                'iRCnt = iRCnt + 13
    '                If intGYOSU = 4 Then
    '                    iRCnt = iRCnt + 15
    '                Else
    '                    iRCnt = iRCnt + 22
    '                End If
    '                '--- ↑2005/05/23 ADD Falcon↑ ---
    '            Next
    '        End If

    '        ExcelC.mWriteLine("")                           '行をファイルに書き込む
    '        ExcelC.mClose()                                 'ファイルクローズ

    '        ' 2011/02/10 T.Watabe edit 元の方式へ戻す
    '        If True Then

    '            Dim strXlsSubName As String ' 2011/06/02 T.Watabe add
    '            If jaNmFr.Length > 0 Then
    '                strXlsSubName = jaNmFr
    '            ElseIf centerNm.Length > 0 Then
    '                strXlsSubName = centerNm
    '            ElseIf kenNm.Length > 0 Then
    '                strXlsSubName = kenNm
    '            End If

    '            'ファイルデータをエンコードして呼び出し元へ戻す方式
    '            '圧縮先ファイルのあるフォルダ
    '            compressC.p_Dir = ExcelC.pDirName
    '            '日本語ファイル名の指定
    '            'compressC.p_NihongoFileName = pstrSessionID & "累積情報一覧表.xls" ' 2011/06/02 T.Watabe edit
    '            compressC.p_NihongoFileName = "累積情報_" & strXlsSubName & "_" & pstrSessionID & ".xls"
    '            '圧縮元ファイル名
    '            compressC.p_FileName = ExcelC.pDirName & ExcelC.pFileName & ".xls"
    '            '圧縮先ファイル名
    '            compressC.p_madeFilename = ExcelC.pDirName & ExcelC.pFileName & ".lzh"
    '            compressC.p_Exec = pbolLzhAutoExec '解凍時の自動実行あり？／なし？
    '            '圧縮実行
    '            compressC.mCompress()
    '            mlog("@1_" & compressC.p_madeFilename)
    '            '圧縮したファイルをBase64エンコードして戻す
    '            Return FileToStrC.mFileToStr(compressC.p_madeFilename.Replace(".lzh", ".exe"))
    '        Else
    '            ' 2011/02/01 T.Watabe edit
    '            'ファイルパスを戻す方式（試し）
    '            Dim sCopyFrom As String = ExcelC.pDirName & ExcelC.pFileName & ".xls"
    '            'Dim sCopyTo As String = ExcelC.pDirName & pstrSessionID & "累積情報一覧表.xls"
    '            'Microsoft.VisualBasic.FileSystem.Rename(sCopyFrom, sCopyTo)
    '            'Return FileToStrC.mFileToStr(sCopyTo)
    '            'Return FileToStrC.mFileToStr(sCopyFrom)
    '            mlog("@2_" & sCopyFrom)
    '            Return sCopyFrom
    '        End If

    '    Catch ex As Exception
    '        'エラーの内容とＳＱＬ文を返す
    '        Return "ERROR:" & ex.ToString

    '    Finally
    '        cdb.mClose()        '接続クローズ
    '    End Try

    'End Function
    '2015/11/04 w.ganeko 2015改善開発 №6 end

    '******************************************************************************
    '*　概　要:監視センターメニュー「累積情報一覧」用　帳票のDL形式を変更exe→xls
    '*　備　考:mExcel2をコピーして作成 2014/01/06 T.Ono add 監視改善2013
    '*        :2016/12/05 T.Ono mod 2016改善開発 №12 [pstrfaxNo()][pstrmailADD()] 追加
    '*        :2020/11/01 T.Ono mod 2020監視改善 pstrSdPrt　追加
    '******************************************************************************
    '2015/11/04 w.ganeko 2015改善開発 №6 start
    '<WebMethod()> Public Function mExcel3( _
    '                                ByVal pstrSessionID As String, _
    '                                ByVal pstrKuracd As String, _
    '                                ByVal pstrKyocd As String, _
    '                                ByVal pstrJaCdFr As String, _
    '                                ByVal pstrJaCdTo As String, _
    '                                ByVal pstrJasCdFr As String, _
    '                                ByVal pstrJasCdTo As String, _
    '                                ByVal pstrStkbn As String, _
    '                                ByVal pstrPgkbn As String, _
    '                                ByVal pstrTrgFrom As String, _
    '                                ByVal pstrTrgTo As String, _
    '                                ByVal pstrKuraNm As String, _
    '                                ByVal pstrKyoNm As String, _
    '                                ByVal pstrJaNm As String, _
    '                                ByVal pstrJasNm As String, _
    '                                ByVal pdecPageMax As Decimal, _
    '                                ByVal pstrCentcd As String, _
    '                                ByVal pstrZeroSend As String, _
    '                                ByVal pbolLzhAutoExec As Boolean _
    '                                ) As String
    '<WebMethod()> Public Function mExcel3( _
    '                                ByVal pstrSessionID As String, _
    '                                ByVal pstrKuracd As String, _
    '                                ByVal pstrKyocd As String, _
    '                                ByVal pstrJaCdFr As String, _
    '                                ByVal pstrJaCdTo As String, _
    '                                ByVal pstrJasCdFr As String, _
    '                                ByVal pstrJasCdTo As String, _
    '                                ByVal pstrStkbn As String, _
    '                                ByVal pstrPgkbn As String, _
    '                                ByVal pstrTrgFrom As String, _
    '                                ByVal pstrTrgTo As String, _
    '                                ByVal pstrKuraNm As String, _
    '                                ByVal pstrKyoNm As String, _
    '                                ByVal pstrJaNmFr As String, _
    '                                ByVal pstrJaNmTo As String, _
    '                                ByVal pstrJasNmFr As String, _
    '                                ByVal pstrJasNmTo As String, _
    '                                ByVal pdecPageMax As Decimal, _
    '                                ByVal pstrCentcd As String, _
    '                                ByVal pstrZeroSend As String, _
    '                                ByVal pbolLzhAutoExec As Boolean, _
    '                                ByVal pstrHanbaiCdFr As String, _
    '                                ByVal pstrHanbaiCdTo As String, _
    '                                ByVal pstrTaikbn As String, _
    '                                ByVal pstrHkkbn As String, _
    '                                ByVal pstrHanbaiNmFr As String, _
    '                                ByVal pstrHanbaiNmTo As String, _
    '                                ByVal pstrZipFlg As String, _
    '                                ByVal pstrfaxNo() As String, _
    '                                ByVal pstrmailADD() As String _
    '                                ) As String
    '2015/11/04 w.ganeko 2015改善開発 №6 end
    <WebMethod()> Public Function mExcel3(
                                    ByVal pstrSessionID As String,
                                    ByVal pstrKuracd As String,
                                    ByVal pstrKyocd As String,
                                    ByVal pstrJaCdFr As String,
                                    ByVal pstrJaCdTo As String,
                                    ByVal pstrJasCdFr As String,
                                    ByVal pstrJasCdTo As String,
                                    ByVal pstrStkbn As String,
                                    ByVal pstrPgkbn As String,
                                    ByVal pstrTrgFrom As String,
                                    ByVal pstrTrgTo As String,
                                    ByVal pstrKuraNm As String,
                                    ByVal pstrKyoNm As String,
                                    ByVal pstrJaNmFr As String,
                                    ByVal pstrJaNmTo As String,
                                    ByVal pstrJasNmFr As String,
                                    ByVal pstrJasNmTo As String,
                                    ByVal pdecPageMax As Decimal,
                                    ByVal pstrCentcd As String,
                                    ByVal pstrZeroSend As String,
                                    ByVal pstrSdPrt As String,
                                    ByVal pbolLzhAutoExec As Boolean,
                                    ByVal pstrHanbaiCdFr As String,
                                    ByVal pstrHanbaiCdTo As String,
                                    ByVal pstrTaikbn As String,
                                    ByVal pstrHkkbn As String,
                                    ByVal pstrHanbaiNmFr As String,
                                    ByVal pstrHanbaiNmTo As String,
                                    ByVal pstrZipFlg As String,
                                    ByVal pstrfaxNo() As String,
                                    ByVal pstrmailADD() As String,
                                    ByVal pstrKikankbn As String,
                                    ByVal pstrTrgTimeFrom As String,
                                    ByVal pstrTrgTimeTo As String
                                    ) As String
        '2017/02/15 H.Mori mod 改善2016 No9-1 END

        Dim strSQL As New StringBuilder("")
        Dim cdb As New CDB
        Dim ds As New DataSet
        Dim dr As DataRow
        Dim intGYOSU As Integer = 5                     '改行制御を行う
        Dim intGyoMax As Integer = CInt(pdecPageMax)    '最大行数
        'Dim intGyoMax As Integer = 4500 '最大行数
        Dim ExcelC As New CExcel                        'Excelクラス
        Dim compressC As New CCompress                  '圧縮クラス
        Dim DateFncC As New CDateFnc                    '日付変換クラス
        Dim CTimeFncC As New CTimeFnc                   '時間変換クラス
        Dim FileToStrC As New CFileStr                  'ファイルをBase64にエンコードするクラス
        Dim strHedInfo As String                        'ヘッダー情報（抽出条件）
        Dim intPrntRow As Integer = 72

        Dim strTmp() As String
        Dim strTmpTo() As String

        '2016/11/30 T.Ono add 2016改善開発 №12 --------------------Start
        'ログ出力に使用
        Dim strEXEC_YMD As String
        Dim strEXEC_TIME As String
        Dim strGUID As String
        Dim intSEQNO As Integer
        Dim wkstrTAIOU_SYONO As String = ""
        Dim wkstrTAIOU_KANSCD As String = ""
        Dim wkstrTAIOU_KURACD As String = ""
        Dim wkstrTAIOU_JACD As String = ""
        Dim wkstrTAIOU_ACBCD As String = ""
        Dim wkstrTAIOU_USER_CD As String = ""
        Dim wkstrAUTO_ZERO_FLG As String = "" ' 【ゼロ件送信フラグ】 0:データあり/1:ゼロ件！(データなし)　


        strEXEC_YMD = Format(DateTime.Now, "yyyyMMdd")
        strEXEC_TIME = Format(DateTime.Now, "HHmmss")
        strGUID = pstrSessionID
        intSEQNO = 0
        '2016/11/30 T.Ono add 2016改善開発 №12 --------------------End


        '接続OPEN----------------------------------------
        Try
            cdb.mOpen()
        Catch ex As Exception
            Return ex.ToString
        Finally

        End Try

        ' ---------------------------------
        ' ＪＡ名、県名、クライアント名、供給ｾﾝﾀｰ名を取得
        ' ---------------------------------
        Dim jaNmFr As String = ""
        Dim jaNmTo As String = ""
        Dim jasNmFr As String = ""
        Dim jasNmTo As String = ""
        Dim kenNm As String = ""
        Dim HanNmFr As String = ""
        Dim HanNmTo As String = ""
        'Dim clientNm As String = ""
        Dim centerNm As String = ""
        Try
            '2015/01/23 T.Ono add JAにJA支所名が表示されていたため修正 START
            'jaNmFr = getDB2JasNm(cdb, pstrKuracd, pstrJaCdFr)
            'jaNmFr = jaNmFr.Trim
            'If pstrJaCdFr.Length <> 0 And pstrJaCdFr = pstrJaCdTo Then
            '    jaNmTo = jaNmFr
            'Else
            '    jaNmTo = getDB2JasNm(cdb, pstrKuracd, pstrJaCdTo)
            'End If
            '2015/11/04 w.ganeko 2015改善開発 №6
            'strTmp = pstrJaNm.Split(Convert.ToChar(":"))
            strTmp = pstrJaNmFr.Split(Convert.ToChar(":"))
            jaNmFr = strTmp(strTmp.Length - 1).Trim
            strTmp = pstrHanbaiNmFr.Split(Convert.ToChar(":"))
            HanNmFr = strTmp(strTmp.Length - 1).Trim
            If pstrHanbaiCdFr.Length <> 0 And pstrHanbaiCdFr = pstrHanbaiCdTo Then
                HanNmTo = HanNmFr
            ElseIf pstrHanbaiCdTo.Length <> 0 Then
                strTmp = pstrHanbaiNmTo.Split(Convert.ToChar(":"))
                HanNmTo = strTmp(strTmp.Length - 1).Trim
            End If
            '2015/11/04 w.ganeko 2015改善開発 №6
            'jaNmTo = jaNmFr 'JAコードのFromとToは同じものを渡しているのでIF文にする必要ない
            strTmpTo = pstrJaNmTo.Split(Convert.ToChar(":"))
            jaNmTo = strTmpTo(strTmpTo.Length - 1).Trim
            '2015/01/23 T.Ono add JAにJA支所名が表示されていたため修正 END
            jasNmFr = getDB2JasNm(cdb, pstrKuracd, pstrJasCdFr)
            If pstrJasCdFr.Length <> 0 And pstrJasCdFr = pstrJasCdTo Then
                jasNmTo = jasNmFr
            Else
                jasNmTo = getDB2JasNm(cdb, pstrKuracd, pstrJasCdTo)
            End If
            kenNm = getDB2KenNm(cdb, pstrKuracd)

            '2011.11.22 MOD H.Uema クライアント未指定の場合、落ちるので修正
            'centerNm = getDB2CenterNm(cdb, pstrKuracd.Substring(1, 2), pstrKyocd)
            If (pstrKuracd.Length > 2) Then
                centerNm = getDB2CenterNm(cdb, pstrKuracd.Substring(1, 2), pstrKyocd)
            End If

        Catch ex As Exception
            '2011.11.22 MOD H.Uema *----------* start
            'Return ex.ToString
            cdb.mClose()        '接続クローズ
            Return "ERROR:" & ex.ToString
            '2011.11.22 MOD H.Uema *----------* end
        Finally
        End Try

        '帳票出力項目の取得用SQL文セット-------------------
        Try
            '2015/11/04 w.ganeko 2015改善開発 №6 start
            'strSQL.Append(fncMakeSelect(2, _
            '                        pstrKuracd, _
            '                        pstrKyocd, _
            '                        pstrJaCdFr, _
            '                        pstrJaCdTo, _
            '                        pstrJasCdFr, _
            '                        pstrJasCdTo, _
            '                        pstrTrgFrom, _
            '                        pstrTrgTo, _
            '                        pstrPgkbn, _
            '                        pdecPageMax, _
            '                        pstrStkbn))
            '2017/02/15 H.Mori mod 改善2016 No9-1 START
            'strSQL.Append(fncMakeSelect(2, _
            '                        pstrKuracd, _
            '                        pstrKyocd, _
            '                        pstrJaCdFr, _
            '                        pstrJaCdTo, _
            '                        pstrJasCdFr, _
            '                        pstrJasCdTo, _
            '                        pstrTrgFrom, _
            '                        pstrTrgTo, _
            '                        pstrPgkbn, _
            '                        pdecPageMax, _
            '                        pstrStkbn, _
            '                        pstrHanbaiCdFr, _
            '                        pstrHanbaiCdTo, _
            '                        pstrTaikbn, _
            '                        pstrHkkbn
            '                       ))
            '2015/11/04 w.ganeko 2015改善開発 №6 end
            strSQL.Append(fncMakeSelect(2,
                                    pstrKuracd,
                                    pstrKyocd,
                                    pstrJaCdFr,
                                    pstrJaCdTo,
                                    pstrJasCdFr,
                                    pstrJasCdTo,
                                    pstrTrgFrom,
                                    pstrTrgTo,
                                    pstrPgkbn,
                                    pdecPageMax,
                                    pstrStkbn,
                                    pstrHanbaiCdFr,
                                    pstrHanbaiCdTo,
                                    pstrTaikbn,
                                    pstrHkkbn,
                                    pstrKikankbn,
                                    pstrTrgTimeFrom,
                                    pstrTrgTimeTo
                                   ))
            '2017/02/15 H.Mori mod 改善2016 No9-1 END
            cdb.pSQL = strSQL.ToString

            'パラメータセット
            If pstrKuracd.Length <> 0 Then
                cdb.pSQLParamStr("KURACD") = pstrKuracd
            End If
            If pstrKyocd.Length > 0 Then cdb.pSQLParamStr("KYOCD") = pstrKyocd
            '2015/11/04 w.ganeko 2015改善開発 №6 start
            If pstrHanbaiCdFr.Length > 0 Then cdb.pSQLParamStr("GROUPCDFR") = pstrHanbaiCdFr
            If pstrHanbaiCdTo.Length > 0 Then cdb.pSQLParamStr("GROUPCDTO") = pstrHanbaiCdTo
            '2015/11/04 w.ganeko 2015改善開発 №6 end
            If pstrJaCdFr.Length > 0 Then cdb.pSQLParamStr("JACDFR") = pstrJaCdFr
            If pstrJaCdTo.Length > 0 Then cdb.pSQLParamStr("JACDTO") = pstrJaCdTo
            If pstrJasCdFr.Length > 0 Then cdb.pSQLParamStr("JASCDFR") = pstrJasCdFr
            If pstrJasCdTo.Length > 0 Then cdb.pSQLParamStr("JASCDTO") = pstrJasCdTo
            cdb.pSQLParamStr("HATKBN") = pstrStkbn '発生区分
            If pstrTrgFrom.Length > 0 Then cdb.pSQLParamStr("TRGDATE_FROM") = pstrTrgFrom
            If pstrTrgTo.Length > 0 Then cdb.pSQLParamStr("TRGDATE_TO") = pstrTrgTo
            '2017/02/15 H.Mori add 改善2016 No9-1 START
            If pstrTrgTimeFrom.Length > 0 Then cdb.pSQLParamStr("TRGTIME_FROM") = pstrTrgTimeFrom
            If pstrTrgTimeTo.Length > 0 Then cdb.pSQLParamStr("TRGTIME_TO") = pstrTrgTimeTo & "59"
            '2017/02/15 H.Mori add 改善2016 No9-1 END

            cdb.mExecQuery()    'SQL実行
            ds = cdb.pResult    '結果をデータセットに格納

            '検索数の上限をなくす　2013/12/05 T.Ono mod 監視改善2013
            ''データが存在しない場合
            'If ds.Tables(0).Rows.Count = 0 And pstrZeroSend <> "1" Then
            '    Return "DATA0"      'データが0件であることを示す文字列を返す
            'ElseIf ds.Tables(0).Rows.Count > intGyoMax Then
            '    Return "DATAMAX"    'データが最大行数を超える事を示す文字列を返す
            'End If
            If ds.Tables(0).Rows.Count = 0 And pstrZeroSend <> "1" Then
                Return "DATA0"      'データが0件であることを示す文字列を返す
            End If

            'dr = ds.Tables(0).Rows(0)           'データローにデータセットを格納
            ExcelC.pKencd = "00"                'クライアントコードをセット
            ExcelC.pSessionID = pstrSessionID   'セッションID
            ExcelC.pRepoID = "KERUIJOX00"       '帳票ID
            ExcelC.mOpen()                      'ファイルオープン

            '2014/03/20 T.Ono mod FAXタイトル変更要望
            'ExcelC.pTitle = "累積情報一覧表"                        'タイトル
            'ExcelC.pTitle = "監視センター対応結果累積明細（ご報告）" 'タイトル  2014/03/31 T.Ono mod
            ExcelC.pTitle = "監視センター対応結果累積明細(ご報告)" 'タイトル
            ExcelC.pDate = DateFncC.mGet(Now.ToString("yyyyMMdd"))  '作成日
            ExcelC.pScale = 100                                      '縮小拡大率(%)
            'ExcelC.pFitPaper = True                                 'ﾍﾟｰｼﾞﾌｨｯﾄ

            '印刷向き
            ExcelC.pLandScape = False
            '余白
            ExcelC.pMarginTop = 2D
            ExcelC.pMarginBottom = 0.6D
            ExcelC.pMarginLeft = 1.7D
            ExcelC.pMarginRight = 0D
            ExcelC.pMarginHeader = 1.3D
            ExcelC.pMarginFooter = 1.3D

            'ヘッダ項目をセット。（1ページあたり行数、出力行数、先頭行から何行目までが行タイトルか）
            ExcelC.mHeader(intPrntRow, ds.Tables(0).Rows.Count, 4)

            '各列の幅をピクセルでセット。枠線も消す。
            ' 2015/02/16 H.Hosoda mod 2014改善開発 No9 START
            'ExcelC.pCellStyle(1) = "height:0px;width:66px;border-style:none"
            ExcelC.pCellStyle(1) = "height:0px;width:71px;border-style:none"
            ' 2015/02/16 H.Hosoda mod 2014改善開発 No9 END
            ExcelC.pCellStyle(2) = "height:0px;width:65px;border-style:none"
            ExcelC.pCellStyle(3) = "height:0px;width:21px;border-style:none"
            ExcelC.pCellStyle(4) = "height:0px;width:72px;border-style:none"
            ExcelC.pCellStyle(5) = "height:0px;width:23px;border-style:none"
            ExcelC.pCellStyle(6) = "height:0px;width:86px;border-style:none"
            ExcelC.pCellStyle(7) = "height:0px;width:204px;border-style:none"
            ExcelC.pCellStyle(8) = "height:0px;width:72px;border-style:none"
            ExcelC.pCellStyle(9) = "height:0px;width:135px;border-style:none"
            ExcelC.pCellStyle(10) = "height:0px;width:5px;border-style:none"
            ExcelC.pCellStyle(11) = "height:0px;width:5px;border-style:none"
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
            ExcelC.pCellVal(11) = ""
            ExcelC.mWriteLine("")   '行をファイルに書き込む

            If True Then
                '抽出条件（上段）
                ExcelC.pCellStyle(1) = "height:16px;font-size:13px;border-bottom-style:none"
                ExcelC.pCellVal(1, "colspan = 9") = "抽出条件"
                ExcelC.mWriteLine("")   '行をファイルに書き込む

                '抽出条件（中段）
                strHedInfo = "県名:"
                If pstrKuracd.Length <> 0 Then strHedInfo &= kenNm
                strHedInfo &= "　供給センター:"
                If pstrKyocd.Length <> 0 Then
                    strHedInfo &= centerNm
                End If
                '2015/11/04 w.ganeko 2015改善開発 №6 start
                If pstrHanbaiCdFr.Length <> 0 Or pstrHanbaiCdTo.Length <> 0 Then '販売事業者 両方or片方が設定されている場合
                    strHedInfo &= "　販売事業者:"
                    If pstrHanbaiCdFr.Length <> 0 And pstrHanbaiCdFr = pstrHanbaiCdTo Then '販売事業者 from、toが同じ場合→名称１つを表示
                        strHedInfo &= HanNmFr
                    Else
                        strHedInfo &= HanNmFr & " ～ " & HanNmTo
                    End If
                End If
                '2015/11/04 w.ganeko 2015改善開発 №6 end
                strHedInfo &= "　ＪＡ:"
                If pstrJaCdFr.Length <> 0 And pstrJaCdFr = pstrJaCdTo Then 'ＪＡ名称 from、toが同じ場合→名称１つを表示
                    strHedInfo &= jaNmFr
                ElseIf pstrJaCdFr.Length <> 0 Or pstrJaCdTo.Length <> 0 Then 'ＪＡ名称 両方or片方が設定されている場合 
                    strHedInfo &= jaNmFr & " ～ " & jaNmTo
                End If
                strHedInfo &= "　ＪＡ支所:"
                If pstrJasCdFr.Length <> 0 And pstrJasCdFr = pstrJasCdTo Then 'ＪＡ名称 from、toが同じ場合→名称１つを表示
                    strHedInfo &= jasNmFr
                ElseIf pstrJasCdFr.Length <> 0 Or pstrJasCdTo.Length <> 0 Then 'ＪＡ名称 両方or片方が設定されている場合 
                    strHedInfo &= jasNmFr & " ～ " & jasNmTo
                End If

                ExcelC.pCellStyle(1) = "height:16px;font-size:13px;border-top-style:none;border-bottom-style:none"
                ExcelC.pCellVal(1, "colspan = 9") = strHedInfo
                ExcelC.mWriteLine("")           '行をファイルに書き込む

                '抽出条件（下段）
                If pstrStkbn = "1" Then
                    strHedInfo = "発生区分:電話"
                ElseIf pstrStkbn = "2" Then
                    strHedInfo = "発生区分:警報"
                Else
                    strHedInfo = "発生区分:電話／警報"
                End If

                If pstrTrgTo <> "" Then
                    strHedInfo &= "　対象期間:" & DateFncC.mGet(pstrTrgFrom) & "～" & DateFncC.mGet(pstrTrgTo)
                Else
                    strHedInfo &= "　対象期間:" & DateFncC.mGet(pstrTrgFrom)
                End If
                ExcelC.pCellStyle(1) = "height:16px;font-size:13px;border-top-style:none"
                ExcelC.pCellVal(1, "colspan = 9") = strHedInfo
                ExcelC.mWriteLine("")           '行をファイルに書き込む
            End If

            '明細データ出力
            Dim intd As Integer = 0                   '処理件数
            Dim intRow As Integer = 0                   '処理件数
            Dim iRCnt As Integer = 0                   '処理件数
            Dim iCnt As Integer
            Dim strKyoCd As String = ""    '前回供給センターコード
            Dim strJaCd As String = ""         '前回ＪＡコード
            Dim strAcdCd As String = ""       '前回ＪＡ支所コード
            Dim strHanjiCd As String = ""       '前回販売事業者コード 2015/11/04 w.ganeko 2015改善開発 №6
            Dim blnFlg As Boolean = False                '初回フラグ

            '--- ↓2005/05/23 ADD Falcon↓ ---
            Dim strSTD_CD As String
            Dim intHedFlg As Integer = 0
            '--- ↑2005/05/23 ADD Falcon↑ ---
            Dim strTAIOKBN As String        '--- 2005/05/26 ADD Falcon ---

            '--- ↓2005/07/12 ADD Falcon↓ ---
            Dim strTFKICD As String
            Dim bolStdFlg As Boolean        '出動情報表示フラグ(True：表示　False：非表示)
            '--- ↑2005/07/12 ADD Falcon↑ ---

            '2006/02/01 NEC ADD START
            '出動があったかどうか判別するためのDataRow
            Dim drPageBreak As DataRow
            'カウンタ
            Dim intCntPageBreak As Integer

            '出動情報ありの件数  2020/11/01 T.Ono add 2020監視改善
            Dim intSdCnt As Integer = 0

            '2006/02/01 NEC ADD END

            If ds.Tables(0).Rows.Count = 0 And pstrZeroSend = "1" Then '2010/06/02 T.Watabe add
                '対象０件でゼロ件出力あり→データセットをスルー

                ExcelC.mWriteLine("")           '行をファイルに書き込む
                ExcelC.pCellStyle(1) = "height:16px;text-align:left;font-size:13px;border-style:none;"
                ExcelC.pCellVal(1, "colspan=7") = "期間内の情報はありませんでした。"
                ExcelC.mWriteLine("")           '行をファイルに書き込む


                '2016/11/30 T.Ono add 2016改善開発 №12 --------------------Start
                'S05_AUTOFAXLOGDBに書き込む

                'ログ出力用にデータセット
                wkstrTAIOU_SYONO = ""
                wkstrTAIOU_KANSCD = ""
                wkstrTAIOU_KURACD = pstrKuracd
                wkstrTAIOU_JACD = ""
                wkstrTAIOU_ACBCD = ""
                wkstrTAIOU_USER_CD = ""
                wkstrAUTO_ZERO_FLG = "1" ' 【ゼロ件送信フラグ】 0:データあり/1:ゼロ件！(データなし)

                'EXEC_KBN=0
                '累積情報FAXから呼出はDEBUGNO=0は、累積情報一覧から呼出はDEBUGNO=1
                'LATEST_OF_DAY_FLGは"0"にしておく。自動FAX送信前確認で"1"を見ているため。
                'FAXのあて先分ループ
                For i As Integer = 0 To 1
                    If pstrfaxNo(i).Length > 0 Then
                        intSEQNO = intSEQNO + 1
                        Call mInsertS05AutofaxLog(cdb,
                            strEXEC_YMD,
                            strEXEC_TIME,
                            "0",
                            strGUID,
                            intSEQNO,
                            pstrTrgFrom,
                            "0",
                            wkstrTAIOU_KANSCD,
                            wkstrTAIOU_SYONO,
                            wkstrTAIOU_KURACD,
                            wkstrTAIOU_JACD,
                            wkstrTAIOU_ACBCD,
                            wkstrTAIOU_USER_CD,
                            "1",
                            pstrfaxNo(i),
                            "",
                            wkstrAUTO_ZERO_FLG,
                            "",
                            "0",
                            ""
                            )
                    End If
                Next

                'MAILのあて先分ループ
                For i As Integer = 0 To 1
                    If pstrmailADD(i).Length > 0 Then
                        intSEQNO = intSEQNO + 1
                        Call mInsertS05AutofaxLog(cdb,
                            strEXEC_YMD,
                            strEXEC_TIME,
                            "0",
                            strGUID,
                            intSEQNO,
                            pstrTrgFrom,
                            "0",
                            wkstrTAIOU_KANSCD,
                            wkstrTAIOU_SYONO,
                            wkstrTAIOU_KURACD,
                            wkstrTAIOU_JACD,
                            wkstrTAIOU_ACBCD,
                            wkstrTAIOU_USER_CD,
                            "2",
                            "",
                            pstrmailADD(i),
                            wkstrAUTO_ZERO_FLG,
                            "",
                            "0",
                            ""
                            )
                    End If
                Next
                '2016/11/30 T.Ono add 2016改善開発 №12 --------------------End



            ElseIf ds.Tables(0).Rows.Count = 0 Then '2010/06/02 T.Watabe add
                '対象０件→データセットをスルー

            Else

                dr = ds.Tables(0).Rows(0)           'データローにデータセットを格納
                strKyoCd = Convert.ToString(ds.Tables(0).Rows(0).Item("HAISO_CD"))    '前回供給センターコード
                strJaCd = Convert.ToString(ds.Tables(0).Rows(0).Item("JACD"))         '前回ＪＡコード
                strAcdCd = Convert.ToString(ds.Tables(0).Rows(0).Item("ACBCD"))       '前回ＪＡ支所コード
                strHanjiCd = Convert.ToString(ds.Tables(0).Rows(0).Item("HANJICD"))   '前回販売事業者コード 2015/11/04 W.GANEKO 2015改善開発 №6

                'APサーバからの戻り値をループする
                'For Each dr In ds.Tables(0).Rows
                For iCnt = 0 To ds.Tables(0).Rows.Count - 1
                    dr = ds.Tables(0).Rows(iCnt)

                    If pstrPgkbn = "1" Then
                        'JA単位
                        If strJaCd <> Convert.ToString(dr.Item("JACD")) Then
                            '改ページを行う
                            ExcelC.mWriteLine("", True)
                            strJaCd = Convert.ToString(dr.Item("JACD"))
                            intRow = 0
                        End If
                        '2015/11/04 w.ganeko 2015改善開発 №6 start
                        'ElseIf pstrPgkbn = "2" Then
                        '    '供給センター単位
                        '    If strKyoCd <> Convert.ToString(dr.Item("HAISO_CD")) Then
                        '        '改ページを行う
                        '        ExcelC.mWriteLine("", True)
                        '        strKyoCd = Convert.ToString(dr.Item("HAISO_CD"))
                        '        intRow = 0
                        '    End If
                    ElseIf pstrPgkbn = "2" Then
                        'JA支所単位
                        If strAcdCd <> Convert.ToString(dr.Item("ACBCD")) Then
                            '改ページを行う
                            ExcelC.mWriteLine("", True)
                            strAcdCd = Convert.ToString(dr.Item("ACBCD"))
                            intRow = 0
                        End If
                    ElseIf pstrPgkbn = "3" Then
                        '販売事業者単位
                        If strHanjiCd <> Convert.ToString(dr.Item("HANJICD")) Then
                            '改ページを行う
                            ExcelC.mWriteLine("", True)
                            strHanjiCd = Convert.ToString(dr.Item("HANJICD"))
                            intRow = 0
                        End If
                    ElseIf pstrPgkbn = "4" Then
                        '供給センター単位
                        If strKyoCd <> Convert.ToString(dr.Item("HAISO_CD")) Then
                            '改ページを行う
                            ExcelC.mWriteLine("", True)
                            strKyoCd = Convert.ToString(dr.Item("HAISO_CD"))
                            intRow = 0
                        End If
                        '2015/11/04 w.ganeko 2015改善開発 №6 end
                    End If

                    '2020/11/01 T.Ono mod 2020監視改善 Start
                    'intHedFlg = 0
                    'intCntPageBreak = iCnt
                    'If intRow = 0 Or (intGYOSU = 4 And (intRow Mod 4) = 0) _
                    '        Or (intGYOSU = 3 And (intRow Mod 3) = 0) Then
                    '    bolStdFlg = False   '出動情報非表示
                    '    '現在の行から４行先までに出動情報が存在するかチェック
                    '    Do Until intCntPageBreak - iCnt = 4
                    '        If intCntPageBreak <= ds.Tables(0).Rows.Count - 1 Then
                    '            drPageBreak = ds.Tables(0).Rows(intCntPageBreak)
                    '            strSTD_CD = Convert.ToString(drPageBreak.Item("STD_CD"))         '出動会社コード
                    '            strTAIOKBN = Convert.ToString(drPageBreak.Item("TAIOKBN"))       '対応区分（１：電話対応　２：出動指示）
                    '            strTFKICD = Convert.ToString(drPageBreak.Item("TFKICD"))         '復帰対応状況(8:緊急出動（委託先）)
                    '            If (strSTD_CD.Length <> 0) And (strTAIOKBN = "2") And (strTFKICD = "8") Then
                    '                bolStdFlg = True    '出動情報表示
                    '            End If
                    '        End If
                    '        'カウントアップ
                    '        intCntPageBreak += 1
                    '    Loop
                    'End If

                    'If intRow = 0 Then
                    '    intHedFlg = 1       '１番最初は必ずヘッダをヘッダを書き込む
                    '    '//出力行数の設定---------------
                    '    '１ページの行数は出動情報非表示の場合は４行、表示の場合は３行を設定
                    '    If bolStdFlg = True Then
                    '        intGYOSU = 3
                    '    Else
                    '        intGYOSU = 4
                    '    End If
                    '    '//-----------------------------
                    'Else
                    '    If (intGYOSU = 4 And (intRow Mod 4) = 0) _
                    '        Or (intGYOSU = 3 And (intRow Mod 3) = 0) Then
                    '        intHedFlg = 1   'ヘッダ書き込み：有
                    '        intRow = 0      '行数カウント：0
                    '        intGYOSU = 0    '１ページ出力数：0
                    '        '//出力行数の設定---------------
                    '        '１ページの行数は出動情報非表示の場合は４行、表示の場合は３行を設定
                    '        If bolStdFlg = True Then
                    '            intGYOSU = 3
                    '        Else
                    '            intGYOSU = 4
                    '        End If
                    '        '//-----------------------------
                    '        ExcelC.mWriteLine("", True)
                    '    Else
                    '        '//出力行数の設定---------------
                    '        If intGYOSU = 4 Then
                    '            '出動会社コードが存在する場合は３行出力
                    '            'If strSTD_CD.Length <> 0 Then
                    '            If bolStdFlg = True Then
                    '                intGYOSU = 3
                    '            Else
                    '                intGYOSU = intGYOSU
                    '            End If
                    '        Else
                    '            intGYOSU = intGYOSU
                    '        End If
                    '        '//-----------------------------
                    '    End If
                    'End If

                    intHedFlg = 0
                    intCntPageBreak = iCnt
                    If intRow = 0 Or (intGYOSU = 3 And (intRow Mod 3) = 0) _
                            Or (intGYOSU = 2 And (intRow Mod 2) = 0) Then
                        bolStdFlg = False   '出動情報非表示
                        intSdCnt = 0
                        '現在の行から３行先までに出動情報が存在するかチェック
                        Do Until intCntPageBreak - iCnt = 3
                            If intCntPageBreak <= ds.Tables(0).Rows.Count - 1 Then
                                drPageBreak = ds.Tables(0).Rows(intCntPageBreak)
                                strSTD_CD = Convert.ToString(drPageBreak.Item("STD_CD"))         '出動会社コード
                                strTAIOKBN = Convert.ToString(drPageBreak.Item("TAIOKBN"))       '対応区分（１：電話対応　２：出動指示）
                                strTFKICD = Convert.ToString(drPageBreak.Item("TFKICD"))         '復帰対応状況(8:緊急出動（委託先）)
                                If (strSTD_CD.Length <> 0) And (strTAIOKBN = "2") And (strTFKICD = "8") Then
                                    bolStdFlg = True    '出動情報表示
                                    intSdCnt += 1       '出動情報あり件数
                                End If
                            End If
                            'カウントアップ
                            intCntPageBreak += 1
                        Loop
                    End If

                    If intRow = 0 Then
                        intHedFlg = 1       '１番最初は必ずヘッダをヘッダを書き込む
                        '//出力行数の設定---------------
                        '出動情報表示が２件以上なら２件表示。０件または１件なら３件表示。
                        If intSdCnt >= 2 Then
                            intGYOSU = 2
                        Else
                            intGYOSU = 3
                        End If
                        '//-----------------------------
                    Else
                        If (intGYOSU = 3 And (intRow Mod 3) = 0) _
                            Or (intGYOSU = 2 And (intRow Mod 2) = 0) Then
                            intHedFlg = 1   'ヘッダ書き込み：有
                            intRow = 0      '行数カウント：0
                            intGYOSU = 0    '１ページ出力数：0
                            '//出力行数の設定---------------
                            '出動情報表示が２件以上なら２件表示。０件または１件なら３件表示。
                            If intSdCnt >= 2 Then
                                intGYOSU = 2
                            Else
                                intGYOSU = 3
                            End If
                            '//-----------------------------
                            ExcelC.mWriteLine("", True)
                        Else
                            '//出力行数の設定---------------
                            If intGYOSU = 4 Then
                                '出動会社コードが存在する場合は３件出力
                                If bolStdFlg = True Then
                                    intGYOSU = 3
                                Else
                                    intGYOSU = intGYOSU
                                End If
                            Else
                                intGYOSU = intGYOSU
                            End If
                            '//-----------------------------
                        End If
                    End If
                    '2020/11/01 T.Ono mod 2020監視改善 End

                    If intHedFlg = 1 Then
                        ExcelC.mWriteLine("")
                        ExcelC.pCellStyle(1) = "height:16px;text-align:left;font-size:13px;border:none"
                        ExcelC.pCellStyle(2) = "height:16px;text-align:left;font-size:13px;border:none"     '<-- 2005/05/21 ADD
                        ExcelC.pCellVal(1, "colspan=2") = "県名：" & kenNm
                        If pstrPgkbn = "1" Then
                            ExcelC.pCellVal(2, "colspan=7") = "ＪＡ名：" & Convert.ToString(dr.Item("JANM"))
                            'ElseIf pstrPgkbn = "2" Then
                            '    ExcelC.pCellVal(2, "colspan=7") = "供給センター名：" & Convert.ToString(dr.Item("NAME"))
                            '2015/11/04 w.ganeko 2015改善開発 №6 start
                        ElseIf pstrPgkbn = "2" Then
                            ExcelC.pCellVal(2, "colspan=7") = "JA支所名：" & Convert.ToString(dr.Item("ACBNM"))
                        ElseIf pstrPgkbn = "3" Then
                            ExcelC.pCellVal(2, "colspan=7") = "販売事業者名：" & Convert.ToString(dr.Item("HANJINM"))
                        ElseIf pstrPgkbn = "4" Then
                            ExcelC.pCellVal(2, "colspan=7") = "供給センター名：" & Convert.ToString(dr.Item("NAME"))
                            '2015/11/04 w.ganeko 2015改善開発 №6 end
                        End If
                        ExcelC.mWriteLine("")


                        iRCnt = iRCnt + 1
                    End If


                    '明細項目
                    '1段目----------------------------------------------------------------
                    'JA支所
                    ExcelC.pCellStyle(1) = "text-align:right;height:16px;font-size:13px;border-bottom-style:none;border-right-style:none"
                    ExcelC.pCellVal(1, "colspan = 2") = "ＪＡ支所名:"
                    ExcelC.pCellStyle(2) = "height:16px;font-size:13px;border-bottom-style:none;border-left-style:none"
                    ExcelC.pCellVal(2, "colspan = 7") = Convert.ToString(dr.Item("ACBCD")) & "　" & Convert.ToString(dr.Item("ACBNM"))
                    ExcelC.mWriteLine("")           '行をファイルに書き込む
                    '2段目-----------------------------------------------------------------
                    'お客様名
                    ExcelC.pCellStyle(1) = "height:16px;text-align:right;font-size:13px;border-top-style:none;border-bottom-style:none;border-right-style:none"
                    ' 2015/02/13 H.Hosoda mod 2014改善開発 No9 START
                    'ExcelC.pCellVal(1) = "氏名:"
                    ExcelC.pCellVal(1) = "お客様名:"
                    ' 2015/02/13 H.Hosoda mod 2014改善開発 No9 END
                    ExcelC.pCellStyle(2) = "font-size:13px;border-top-style:none;border-bottom-style:none;border-left-style:none;border-right-style:none"
                    ExcelC.pCellVal(2, "colspan = 5") = Convert.ToString(dr.Item("JUSYONM"))
                    'お客様コード
                    ExcelC.pCellStyle(3) = "text-align:right;font-size:13px;border-top-style:none;border-bottom-style:none;border-left-style:none;border-right-style:none"
                    ' 2015/02/16 H.Hosoda mod 2014改善開発 No9 START
                    'ExcelC.pCellVal(3) = "需要家コード:"
                    ExcelC.pCellVal(3) = "お客様コード:"
                    ' 2015/02/16 H.Hosoda mod 2014改善開発 No9 END
                    ExcelC.pCellStyle(4) = "font-size:13px;border-top-style:none;border-bottom-style:none;border-left-style:none"
                    ExcelC.pCellVal(4, "colspan = 2") = Convert.ToString(dr.Item("JUYOKA"))
                    ExcelC.mWriteLine("")           '行をファイルに書き込む
                    '3段目-----------------------------------------------------------------
                    '結線番号
                    ExcelC.pCellStyle(1) = "height:16px;text-align:right;font-size:13px;border-top-style:none;border-right-style:none;border-bottom-style:none"
                    ' 2015/02/16 H.Hosoda mod 2014改善開発 No9 START
                    'ExcelC.pCellVal(1) = "TEL:"
                    ExcelC.pCellVal(1) = "結線番号:"
                    ' 2015/02/16 H.Hosoda mod 2014改善開発 No9 END
                    ExcelC.pCellStyle(2) = "font-size:13px;border-style:none"
                    If Convert.ToString(dr.Item("JUTEL1")) = "" Then
                        ExcelC.pCellVal(2, "colspan = 5") = Convert.ToString(dr.Item("JUTEL2"))
                    Else
                        ExcelC.pCellVal(2, "colspan = 5") = Convert.ToString(dr.Item("JUTEL1")) & "-" & Convert.ToString(dr.Item("JUTEL2"))
                    End If
                    '連絡先
                    ExcelC.pCellStyle(3) = "text-align:right;font-size:13px;border-style:none"
                    ExcelC.pCellVal(3) = "連絡先:"
                    ExcelC.pCellStyle(4) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
                    ExcelC.pCellVal(4, "colspan = 2") = Convert.ToString(dr.Item("RENTEL"))
                    ExcelC.mWriteLine("")           '行をファイルに書き込む
                    '4段目-----------------------------------------------------------------
                    '住所
                    ExcelC.pCellStyle(1) = "height:16px;text-align:right;font-size:13px;border-top-style:none;border-right-style:none;border-bottom-style:none"
                    ExcelC.pCellVal(1) = "住所:"
                    ExcelC.pCellStyle(2) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:dashed"
                    ExcelC.pCellVal(2, "colspan = 8") = Convert.ToString(dr.Item("ADDR"))
                    ExcelC.mWriteLine("")           '行をファイルに書き込む
                    '5段目-----------------------------------------------------------------
                    ExcelC.pCellStyle(1) = "height:16px;font-size:13px;border-right-style:none;border-bottom-style:none"
                    ExcelC.pCellVal(1) = "<緊急>"
                    '事象数
                    ExcelC.pCellStyle(2) = "text-align:right;font-size:13px;border-left-style:none;border-right-style:none;border-bottom-style:none"
                    ExcelC.pCellVal(2) = "事象数:"
                    ExcelC.pCellStyle(3) = "font-size:13px;border-left-style:none;border-right-style:none;border-bottom-style:none"
                    ExcelC.pCellVal(3) = Convert.ToString(dr.Item("KEIHOSU"))
                    '流量区分
                    ExcelC.pCellStyle(4) = "text-align:right;font-size:13px;border-left-style:none;border-right-style:none;border-bottom-style:none"
                    ExcelC.pCellVal(4) = "流量区分:"
                    ExcelC.pCellStyle(5) = "font-size:13px;border-left-style:none;border-bottom-style:none"
                    ExcelC.pCellVal(5) = Convert.ToString(dr.Item("RYURYO"))
                    '処理種別
                    ExcelC.pCellStyle(6) = "text-align:right;font-size:13px;border-top-style:none;border-right-style:none;border-bottom-style:none"
                    ' 2015/02/17 H.Hosoda mod 2014改善開発 No9 START
                    'ExcelC.pCellVal(6) = "処理種別:"
                    ExcelC.pCellVal(6) = "処理区分:"
                    ' 2015/02/17 H.Hosoda mod 2014改善開発 No9 END
                    ExcelC.pCellStyle(7) = "font-size:13px;border-style:none"
                    ExcelC.pCellVal(7) = Convert.ToString(dr.Item("TMSKB_NAI"))
                    '受信日時
                    ExcelC.pCellStyle(8) = "text-align:right;font-size:13px;border-style:none"
                    ' 2015/02/16 H.Hosoda mod 2014改善開発 No9 START
                    'ExcelC.pCellVal(8) = "受付時間:"
                    ExcelC.pCellVal(8) = "受信日時:"
                    ' 2015/02/16 H.Hosoda mod 2014改善開発 No9 END
                    ExcelC.pCellStyle(9) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
                    ExcelC.pCellVal(9) = DateFncC.mGet(Convert.ToString(dr.Item("HATYMD"))) &
                                                        " " & CTimeFncC.mGet(Convert.ToString(dr.Item("HATTIME")), 0)
                    ExcelC.mWriteLine("")           '行をファイルに書き込む
                    '6段目-----------------------------------------------------------------
                    '警報１メッセージ
                    ExcelC.pCellStyle(1) = "height:16px;font-size:13px;border-top-style:none;border-bottom-style:none"
                    ExcelC.pCellVal(1, "colspan = 5") = Convert.ToString(dr.Item("KMNM1"))
                    '連絡相手
                    ExcelC.pCellStyle(2) = "text-align:right;font-size:13px;border-top-style:none;border-right-style:none;border-bottom-style:none"
                    ' 2015/02/16 H.Hosoda mod 2014改善開発 No9 START
                    'ExcelC.pCellVal(2) = "連絡相手先:"
                    ExcelC.pCellVal(2) = "連絡相手:"
                    ' 2015/02/16 H.Hosoda mod 2014改善開発 No9 END
                    ExcelC.pCellStyle(3) = "font-size:13px;border-style:none"
                    ExcelC.pCellVal(3) = Convert.ToString(dr.Item("TAITNM"))
                    '完了日時
                    ExcelC.pCellStyle(4) = "text-align:right;font-size:13px;border-style:none"
                    ' 2015/02/16 H.Hosoda mod 2014改善開発 No9 START
                    'ExcelC.pCellVal(4) = "処理日時:"
                    ExcelC.pCellVal(4) = "完了日時:"
                    ' 2015/02/16 H.Hosoda mod 2014改善開発 No9 END
                    ExcelC.pCellStyle(5) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
                    ExcelC.pCellVal(5) = DateFncC.mGet(Convert.ToString(dr.Item("SYOYMD"))) &
                                         " " & CTimeFncC.mGet(Convert.ToString(dr.Item("SYOTIME")), 0)
                    ExcelC.mWriteLine("")           '行をファイルに書き込む
                    '7段目-----------------------------------------------------------------
                    '警報２メッセージ
                    ExcelC.pCellStyle(1) = "height:16px;font-size:13px;border-top-style:none;border-bottom-style:none"
                    ExcelC.pCellVal(1, "colspan = 5") = Convert.ToString(dr.Item("KMNM2"))
                    '担当者名
                    ExcelC.pCellStyle(2) = "text-align:right;font-size:13px;border-top-style:none;border-right-style:none;border-bottom-style:none"
                    ExcelC.pCellVal(2) = "担当者名:"

                    ExcelC.pCellStyle(3) = "font-size:13px;border-style:none"
                    ExcelC.pCellVal(3) = Convert.ToString(dr.Item("TKTANCD_NM"))
                    ' 2015/02/16 H.Hosoda mod 2014改善開発 No9 START
                    ''発生区分
                    'ExcelC.pCellStyle(4) = "text-align:right;font-size:13px;border-style:none"
                    'ExcelC.pCellVal(4) = "発生区分:"
                    'ExcelC.pCellStyle(5) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
                    'ExcelC.pCellVal(5) = Convert.ToString(dr.Item("HATKBN_NAI"))
                    '依頼日時
                    ExcelC.pCellStyle(4) = "text-align:right;font-size:13px;border-style:none"
                    ExcelC.pCellVal(4) = "依頼日時:"
                    ExcelC.pCellStyle(5) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
                    ExcelC.pCellVal(5) = DateFncC.mGet(Convert.ToString(dr.Item("SIJIYMD"))) &
                                         " " & CTimeFncC.mGet(Convert.ToString(dr.Item("SIJITIME")), 0)
                    ' 2015/02/16 H.Hosoda mod 2014改善開発 No9 START
                    ExcelC.mWriteLine("")           '行をファイルに書き込む
                    '8段目-----------------------------------------------------------------
                    '警報３メッセージ
                    ExcelC.pCellStyle(1) = "height:16px;font-size:13px;border-top-style:none;border-bottom-style:none"
                    ExcelC.pCellVal(1, "colspan = 5") = Convert.ToString(dr.Item("KMNM3"))
                    '復帰作業
                    ExcelC.pCellStyle(2) = "text-align:right;font-size:13px;border-top-style:none;border-right-style:none;border-bottom-style:none"
                    ExcelC.pCellVal(2) = "復帰操作:"
                    ExcelC.pCellStyle(3) = "font-size:13px;border-style:none"
                    ExcelC.pCellVal(3) = Convert.ToString(dr.Item("TFKINM"))
                    ' 2015/02/16 H.Hosoda mod 2014改善開発 No9 START
                    ''対応区分
                    'ExcelC.pCellStyle(4) = "text-align:right;font-size:13px;border-style:none"
                    'ExcelC.pCellVal(4) = "対応区分:"
                    'ExcelC.pCellStyle(5) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
                    'ExcelC.pCellVal(5) = Convert.ToString(dr.Item("TAIOKBN_NAI"))
                    '発生区分
                    ExcelC.pCellStyle(4) = "text-align:right;font-size:13px;border-style:none"
                    ExcelC.pCellVal(4) = "発生区分:"
                    ExcelC.pCellStyle(5) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
                    ExcelC.pCellVal(5) = Convert.ToString(dr.Item("HATKBN_NAI"))
                    ' 2015/02/16 H.Hosoda mod 2014改善開発 No9 END
                    ExcelC.mWriteLine("")           '行をファイルに書き込む
                    '9段目-----------------------------------------------------------------
                    '警報４メッセージ
                    ExcelC.pCellStyle(1) = "height:16px;font-size:13px;border-top-style:none;border-bottom-style:none"
                    ExcelC.pCellVal(1, "colspan = 5") = Convert.ToString(dr.Item("KMNM4"))
                    '原因器具
                    ExcelC.pCellStyle(2) = "text-align:right;font-size:13px;border-top-style:none;border-right-style:none;border-bottom-style:none"
                    ' 2015/02/16 H.Hosoda mod 2014改善開発 No9 START
                    'ExcelC.pCellVal(2) = "器具原因:"
                    ExcelC.pCellVal(2) = "原因器具:"
                    ' 2015/02/16 H.Hosoda mod 2014改善開発 No9 END
                    ExcelC.pCellStyle(3) = "font-size:13px;border-style:none"
                    ExcelC.pCellVal(3) = Convert.ToString(dr.Item("TKIGNM"))
                    ' 2015/02/16 H.Hosoda mod 2014改善開発 No9 START
                    ''メータ指針値
                    'ExcelC.pCellStyle(4) = "text-align:right;font-size:13px;border-style:none"
                    'ExcelC.pCellVal(4) = "メータ値:"
                    'ExcelC.pCellStyle(5) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
                    'ExcelC.pCellVal(5) = Convert.ToString(dr.Item("KENSIN"))
                    '対応区分
                    ExcelC.pCellStyle(4) = "text-align:right;font-size:13px;border-style:none"
                    ExcelC.pCellVal(4) = "対応区分:"
                    ExcelC.pCellStyle(5) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
                    ExcelC.pCellVal(5) = Convert.ToString(dr.Item("TAIOKBN_NAI"))
                    ' 2015/02/16 H.Hosoda mod 2014改善開発 No9 END
                    ExcelC.mWriteLine("")           '行をファイルに書き込む
                    '10段目----------------------------------------------------------------
                    '警報５メッセージ
                    ExcelC.pCellStyle(1) = "height:16px;font-size:13px;border-top-style:none;border-bottom-style:none"
                    ExcelC.pCellVal(1, "colspan = 5") = Convert.ToString(dr.Item("KMNM5"))
                    '作動原因
                    ExcelC.pCellStyle(2) = "text-align:right;font-size:13px;border-top-style:none;border-right-style:none;border-bottom-style:none"
                    ExcelC.pCellVal(2) = "作動原因:"
                    ' 2015/02/16 H.Hosoda mod 2014改善開発 No9 START
                    'ExcelC.pCellStyle(3) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
                    'ExcelC.pCellVal(3, "colspan = 3") = Convert.ToString(dr.Item("TSADNM"))
                    ExcelC.pCellVal(3) = Convert.ToString(dr.Item("TSADNM"))
                    ExcelC.pCellStyle(3) = "font-size:13px;border-style:none"
                    ' 2015/02/16 H.Hosoda mod 2014改善開発 No9 END
                    ' 2015/02/16 H.Hosoda add 2014改善開発 No9 START
                    'メータ指針値
                    ExcelC.pCellStyle(4) = "text-align:right;font-size:13px;border-style:none"
                    ExcelC.pCellVal(4) = "メータ値:"
                    ExcelC.pCellStyle(5) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
                    ExcelC.pCellVal(5) = Convert.ToString(dr.Item("KENSIN"))
                    ' 2015/02/16 H.Hosoda add 2014改善開発 No9 END
                    ExcelC.mWriteLine("")           '行をファイルに書き込む
                    '11段目----------------------------------------------------------------
                    '警報６メッセージ
                    ExcelC.pCellStyle(1) = "height:16px;font-size:13px;border-top-style:none"
                    ExcelC.pCellVal(1, "colspan = 5") = Convert.ToString(dr.Item("KMNM6"))
                    '--- 出動情報の出力追加 ----------
                    ExcelC.pCellStyle(2) = "text-align:right;font-size:13px;border-top-style:none;border-right-style:none;border-bottom-style:none"
                    ' 2015/02/16 H.Hosoda mod 2014改善開発 No9 START
                    'ExcelC.pCellVal(2) = "出動指示:"
                    ExcelC.pCellVal(2) = "出動依頼:"
                    ' 2015/02/16 H.Hosoda mod 2014改善開発 No9 END
                    ExcelC.pCellStyle(3) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
                    '2020/11/01 T.Ono mod 2020監視改善 Start
                    'ExcelC.pCellVal(3, "colspan = 3") = Convert.ToString(dr.Item("SDNM"))
                    If pstrSdPrt = "0" Then
                        ExcelC.pCellVal(3, "colspan = 3") = ""
                    Else
                        ExcelC.pCellVal(3, "colspan = 3") = Convert.ToString(dr.Item("SDNM"))
                    End If
                    '2020/11/01 T.Ono mod 2020監視改善 End
                    ExcelC.mWriteLine("")           '行をファイルに書き込む
                    '12段目----------------------------------------------------------------
                    '電話メモ１
                    ExcelC.pCellStyle(1) = "height:16px;font-size:12px;border-top-style:none;border-bottom-style:none"
                    ExcelC.pCellVal(1, "colspan = 9") = Convert.ToString(dr.Item("TEL_MEMO1"))
                    ExcelC.mWriteLine("")           '行をファイルに書き込む
                    '13段目----------------------------------------------------------------
                    '電話メモ１
                    ExcelC.pCellStyle(1) = "height:16px;font-size:12px;border-top-style:none;border-bottom-style:none"
                    ExcelC.pCellVal(1, "colspan = 9") = Convert.ToString(dr.Item("TEL_MEMO2"))
                    ExcelC.mWriteLine("")           '行をファイルに書き込む
                    '14段目----------------------------------------------------------------
                    '復帰操作メモ
                    'ExcelC.pCellStyle(1) = "height:16px;font-size:12px;border-top-style:none"          '2020/11/01 T.Ono mod 2020監視改善
                    ExcelC.pCellStyle(1) = "height:16px;font-size:12px;border-top-style:none;border-bottom-style:none"
                    ExcelC.pCellVal(1, "colspan = 9") = Convert.ToString(dr.Item("FUK_MEMO"))
                    ExcelC.mWriteLine("")           '行をファイルに書き込む

                    '2020/11/01 T.Ono mod 2020監視改善 Start
                    '12段目----------------------------------------------------------------
                    '電話メモ４
                    ExcelC.pCellStyle(1) = "height:16px;font-size:12px;border-top-style:none;border-bottom-style:none"
                    ExcelC.pCellVal(1, "colspan = 9") = Convert.ToString(dr.Item("TEL_MEMO4"))
                    ExcelC.mWriteLine("")           '行をファイルに書き込む
                    '13段目----------------------------------------------------------------
                    '電話メモ５
                    ExcelC.pCellStyle(1) = "height:16px;font-size:12px;border-top-style:none;border-bottom-style:none"
                    ExcelC.pCellVal(1, "colspan = 9") = Convert.ToString(dr.Item("TEL_MEMO5"))
                    ExcelC.mWriteLine("")           '行をファイルに書き込む
                    '14段目----------------------------------------------------------------
                    '電話メモ６
                    ExcelC.pCellStyle(1) = "height:16px;font-size:12px;border-top-style:none"
                    ExcelC.pCellVal(1, "colspan = 9") = Convert.ToString(dr.Item("TEL_MEMO6"))
                    ExcelC.mWriteLine("")           '行をファイルに書き込む

                    '2020/11/01 T.Ono mod 2020監視改善 End

                    '出動情報であれば、出動内容を表示
                    If Convert.ToString(dr.Item("STD_CD")).Length <> 0 And
                    Convert.ToString(dr.Item("TAIOKBN")) = "2" And
                    Convert.ToString(dr.Item("TFKICD")) = "8" Then
                        '2006/2/1 NEC UPDATE END
                        '15段目-----------------------------------------------------------------
                        ExcelC.pCellStyle(1) = "height:16px;font-size:13px;border-bottom-style:none;border-right-style:none"
                        ExcelC.pCellVal(1, "colspan = 5") = "＜出動情報＞"
                        '連絡相手先
                        ExcelC.pCellStyle(2) = "text-align:right;height:16px;font-size:13px;border-bottom-style:none;border-left-style:none;border-right-style:none"
                        ' 2015/02/16 H.Hosoda mod 2014改善開発 No9 START
                        'ExcelC.pCellVal(2) = "連絡相手先:"
                        'ExcelC.pCellStyle(3) = "height:16px;font-size:13px;border-bottom-style:none;border-left-style:none"
                        'ExcelC.pCellVal(3, "colspan = 3") = Convert.ToString(dr.Item("AITNM"))
                        ExcelC.pCellVal(2) = "対応相手:"
                        ExcelC.pCellStyle(3) = "height:16px;font-size:13px;border-style:none"
                        ExcelC.pCellVal(3) = Convert.ToString(dr.Item("AITNM"))
                        ' 2015/02/16 H.Hosoda mod 2014改善開発 No9 END
                        ' 2015/02/16 H.Hosoda add 2014改善開発 No9 START
                        '受信日時
                        ExcelC.pCellStyle(4) = "text-align:right;font-size:13px;border-style:none"
                        ExcelC.pCellVal(4) = "受信日時:"
                        ExcelC.pCellStyle(5) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
                        ExcelC.pCellVal(5) = DateFncC.mGet(Convert.ToString(dr.Item("SIJIYMD"))) &
                                             " " & CTimeFncC.mGet(Convert.ToString(dr.Item("SIJITIME")), 0)
                        ' 2015/02/16 H.Hosoda add 2014改善開発 No9 END
                        ExcelC.mWriteLine("")           '行をファイルに書き込む
                        '16段目-----------------------------------------------------------------
                        '受信者氏名
                        ExcelC.pCellStyle(1) = "font-size:13px;border-top-style:none;border-bottom-style:none;border-right-style:none"
                        ' 2015/02/16 H.Hosoda mod 2014改善開発 No9 START
                        'ExcelC.pCellVal(1, "colspan = 5") = "受信者氏名:" & Convert.ToString(dr.Item("TSTANNM"))
                        ''作動原因
                        'ExcelC.pCellStyle(3) = "text-align:right;height:16px;font-size:13px;border-top-style:none;border-bottom-style:none;border-left-style:none;border-right-style:none"
                        'ExcelC.pCellVal(3) = "作動原因:"
                        'ExcelC.pCellStyle(4) = "height:16px;font-size:13px;border-top-style:none;border-bottom-style:none;border-left-style:none"
                        'ExcelC.pCellVal(4, "colspan = 3") = Convert.ToString(dr.Item("SADNM"))
                        ExcelC.pCellVal(1, "colspan = 5") = "出動対応者:" & Convert.ToString(dr.Item("SYUTDTNM"))
                        '原因器具
                        ExcelC.pCellStyle(2) = "text-align:right;height:16px;font-size:13px;border-top-style:none;border-bottom-style:none;border-left-style:none;border-right-style:none"
                        ExcelC.pCellVal(2) = "原因器具:"
                        ExcelC.pCellStyle(3) = "height:16px;font-size:13px;border-style:none"
                        ExcelC.pCellVal(3) = Convert.ToString(dr.Item("KIGNM"))
                        '出動日時
                        ExcelC.pCellStyle(4) = "text-align:right;font-size:13px;border-style:none"
                        ExcelC.pCellVal(4) = "出動日時:"
                        ExcelC.pCellStyle(5) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
                        ExcelC.pCellVal(5) = DateFncC.mGet(Convert.ToString(dr.Item("SDYMD"))) &
                                             " " & CTimeFncC.mGet(Convert.ToString(dr.Item("SDTIME")), 0)
                        ' 2015/02/16 H.Hosoda mod 2014改善開発 No9 END
                        ExcelC.mWriteLine("")           '行をファイルに書き込む
                        '17段目-----------------------------------------------------------------
                        '復帰操作
                        ExcelC.pCellStyle(1) = "font-size:13px;border-top-style:none;border-bottom-style:none;border-right-style:none"
                        ExcelC.pCellVal(1, "colspan = 5") = "復帰操作:" & Convert.ToString(dr.Item("FKINM"))
                        ' 2015/02/16 H.Hosoda mod 2014改善開発 No9 START
                        ''センサ原因
                        'ExcelC.pCellStyle(3) = "text-align:right;height:16px;font-size:13px;border-top-style:none;border-bottom-style:none;border-left-style:none;border-right-style:none"
                        'ExcelC.pCellVal(3) = "センサ原因:"
                        'ExcelC.pCellStyle(4) = "height:16px;font-size:13px;border-top-style:none;border-bottom-style:none;border-left-style:none"
                        'ExcelC.pCellVal(4, "colspan = 3") = Convert.ToString(dr.Item("ASENM"))
                        '作動原因
                        ExcelC.pCellStyle(2) = "text-align:right;height:16px;font-size:13px;border-top-style:none;border-bottom-style:none;border-left-style:none;border-right-style:none"
                        ExcelC.pCellVal(2) = "作動原因:"
                        ExcelC.pCellStyle(3) = "height:16px;font-size:13px;border-style:none"
                        ExcelC.pCellVal(3) = Convert.ToString(dr.Item("SADNM"))
                        '到着日時
                        ExcelC.pCellStyle(4) = "text-align:right;font-size:13px;border-style:none"
                        ExcelC.pCellVal(4) = "到着日時:"
                        ExcelC.pCellStyle(5) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
                        ExcelC.pCellVal(5) = DateFncC.mGet(Convert.ToString(dr.Item("TYAKYMD"))) &
                                             " " & CTimeFncC.mGet(Convert.ToString(dr.Item("TYAKTIME")), 0)
                        ' 2015/02/16 H.Hosoda mod 2014改善開発 No9 END
                        ExcelC.mWriteLine("")           '行をファイルに書き込む
                        '18段目-----------------------------------------------------------------
                        ' 2015/02/16 H.Hosoda mod 2014改善開発 No9 START
                        ''器具原因
                        'ExcelC.pCellStyle(1) = "font-size:13px;border-top-style:none;border-bottom-style:none;border-right-style:none"
                        'ExcelC.pCellVal(1, "colspan = 5") = "器具原因:" & Convert.ToString(dr.Item("KIGNM"))
                        ''その他原因
                        'ExcelC.pCellStyle(3) = "text-align:right;height:16px;font-size:13px;border-top-style:none;border-bottom-style:none;border-left-style:none;border-right-style:none"
                        'ExcelC.pCellVal(3) = "ｿﾉﾀ原因:"
                        'ExcelC.pCellStyle(4) = "height:16px;font-size:13px;border-top-style:none;border-bottom-style:none;border-left-style:none"
                        'ExcelC.pCellVal(4, "colspan = 3") = Convert.ToString(dr.Item("STANM"))
                        ExcelC.pCellStyle(1) = "font-size:13px;border-top-style:none;border-bottom-style:none;border-right-style:none"
                        ExcelC.pCellVal(1, "colspan = 7") = ""
                        '完了日時
                        ExcelC.pCellStyle(2) = "text-align:right;font-size:13px;border-style:none"
                        ExcelC.pCellVal(2) = "完了日時:"
                        ExcelC.pCellStyle(3) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
                        ExcelC.pCellVal(3) = DateFncC.mGet(Convert.ToString(dr.Item("SYOKANYMD"))) &
                                             " " & CTimeFncC.mGet(Convert.ToString(dr.Item("SYOKANTIME")), 0)
                        ' 2015/02/16 H.Hosoda mod 2014改善開発 No9 END
                        ExcelC.mWriteLine("")           '行をファイルに書き込む
                        '19段目-----------------------------------------------------------------
                        '出動備考
                        ExcelC.pCellStyle(1) = "font-size:13px;border-top-style:none;border-bottom-style:none;border-right-style:none"
                        ExcelC.pCellVal(1, "nowrap") = "出動備考:"
                        ExcelC.pCellStyle(2) = "height:16px;font-size:13px;border-top-style:none;border-bottom-style:none;border-left-style:none"
                        '2020/11/01 T.Ono mod 2020監視改善 Start
                        'ExcelC.pCellVal(2, "colspan = 8") = Convert.ToString(dr.Item("SIJI_BIKO1"))
                        If pstrSdPrt = "0" Then
                            ExcelC.pCellVal(2, "colspan = 8") = ""
                        Else
                            ExcelC.pCellVal(2, "colspan = 8") = Convert.ToString(dr.Item("SIJI_BIKO1"))
                        End If
                        '2020/11/01 T.Ono mod 2020監視改善 End
                        ExcelC.mWriteLine("")           '行をファイルに書き込む
                        '20段目-----------------------------------------------------------------
                        '出動結果(1)
                        ExcelC.pCellStyle(1) = "font-size:13px;border-top-style:none;border-bottom-style:none;border-right-style:none"
                        ExcelC.pCellVal(1, "nowrap") = "出動結果:"
                        ExcelC.pCellStyle(2) = "height:16px;font-size:12px;border-top-style:none;border-bottom-style:none;border-left-style:none"
                        ExcelC.pCellVal(2, "colspan = 8") = Convert.ToString(dr.Item("SDTBIK2"))
                        ExcelC.mWriteLine("")           '行をファイルに書き込む
                        '21段目-----------------------------------------------------------------
                        '出動結果(2)
                        ExcelC.pCellStyle(1) = "font-size:13px;border-top-style:none;border-bottom-style:none;border-right-style:none"
                        ExcelC.pCellVal(1) = ""
                        ExcelC.pCellStyle(2) = "height:16px;font-size:12px;border-top-style:none;border-bottom-style:none;border-left-style:none"
                        ExcelC.pCellVal(2, "colspan = 8") = Convert.ToString(dr.Item("SNTTOKKI"))
                        ExcelC.mWriteLine("")           '行をファイルに書き込む
                        '22段目-----------------------------------------------------------------
                        '出動結果(3)
                        ExcelC.pCellStyle(1) = "font-size:13px;border-top-style:none;border-right-style:none"
                        ExcelC.pCellVal(1) = ""
                        ExcelC.pCellStyle(2) = "height:16px;font-size:12px;border-top-style:none;border-left-style:none"
                        ExcelC.pCellVal(2, "colspan = 8") = Convert.ToString(dr.Item("SDTBIK3"))
                        ExcelC.mWriteLine("")           '行をファイルに書き込む
                    End If

                    '行数のカウント
                    intRow = intRow + 1
                    If (intRow Mod intGYOSU) = 0 Then
                    Else
                        ExcelC.pCellStyle(1) = "height:6px;border:none"
                        ExcelC.pCellVal(1, "colspan = 9") = ""
                        ExcelC.mWriteLine("")   '行をファイルに書き込む
                    End If

                    If intGYOSU = 4 Then
                        iRCnt = iRCnt + 15
                    Else
                        iRCnt = iRCnt + 22
                    End If

                    '2016/11/30 T.Ono add 2016改善開発 №12 --------------------Start
                    'S05_AUTOFAXLOGDBに書き込む
                    'ログ出力用にデータセット
                    wkstrTAIOU_SYONO = Convert.ToString(dr.Item("SYONO"))
                    wkstrTAIOU_KANSCD = Convert.ToString(dr.Item("KANSCD"))
                    wkstrTAIOU_KURACD = Convert.ToString(dr.Item("KURACD"))
                    wkstrTAIOU_JACD = Convert.ToString(dr.Item("JACD"))
                    wkstrTAIOU_ACBCD = Convert.ToString(dr.Item("ACBCD"))
                    wkstrTAIOU_USER_CD = Convert.ToString(dr.Item("JUYOKA"))
                    wkstrAUTO_ZERO_FLG = "0" ' 【ゼロ件送信フラグ】 0:データあり/1:ゼロ件！(データなし)

                    'EXEC_KBN=0
                    '累積情報FAXから呼出はDEBUGNO=0は、累積情報一覧から呼出はDEBUGNO=1
                    ''LATEST_OF_DAY_FLGは"0"にしておく。自動FAX送信前確認で"1"を見ているため。
                    'FAXのあて先分ループ
                    For i As Integer = 0 To 1
                        If pstrfaxNo(i).Length > 0 Then
                            intSEQNO = intSEQNO + 1
                            Call mInsertS05AutofaxLog(cdb,
                                strEXEC_YMD,
                                strEXEC_TIME,
                                "0",
                                strGUID,
                                intSEQNO,
                                pstrTrgFrom,
                                "0",
                                wkstrTAIOU_KANSCD,
                                wkstrTAIOU_SYONO,
                                wkstrTAIOU_KURACD,
                                wkstrTAIOU_JACD,
                                wkstrTAIOU_ACBCD,
                                wkstrTAIOU_USER_CD,
                                "1",
                                pstrfaxNo(i),
                                "",
                                wkstrAUTO_ZERO_FLG,
                                "",
                                "0",
                                ""
                                )
                        End If
                    Next

                    'MAILのあて先分ループ
                    For i As Integer = 0 To 1
                        If pstrmailADD(i).Length > 0 Then
                            intSEQNO = intSEQNO + 1
                            Call mInsertS05AutofaxLog(cdb,
                                strEXEC_YMD,
                                strEXEC_TIME,
                                "0",
                                strGUID,
                                intSEQNO,
                                pstrTrgFrom,
                                "0",
                                wkstrTAIOU_KANSCD,
                                wkstrTAIOU_SYONO,
                                wkstrTAIOU_KURACD,
                                wkstrTAIOU_JACD,
                                wkstrTAIOU_ACBCD,
                                wkstrTAIOU_USER_CD,
                                "2",
                                "",
                                pstrmailADD(i),
                                wkstrAUTO_ZERO_FLG,
                                "",
                                "0",
                                ""
                                )
                        End If
                    Next
                    '2016/11/30 T.Ono add 2016改善開発 №12 --------------------End

                Next
            End If

            ExcelC.mWriteLine("")                           '行をファイルに書き込む
            ExcelC.mClose()                                 'ファイルクローズ

            ' 2011/02/10 T.Watabe edit 元の方式へ戻す
            If True Then

                Dim strXlsSubName As String ' 2011/06/02 T.Watabe add
                If jaNmFr.Length > 0 Then
                    strXlsSubName = jaNmFr
                ElseIf centerNm.Length > 0 Then
                    strXlsSubName = centerNm
                ElseIf kenNm.Length > 0 Then
                    strXlsSubName = kenNm
                End If

                '2018/02/19 T.Ono mod START --------------------
                '圧縮方法を変更。UNLHA32.DLLは使わない。

                ''ファイルデータをエンコードして呼び出し元へ戻す方式
                ''圧縮先ファイルのあるフォルダ
                'compressC.p_Dir = ExcelC.pDirName
                ''日本語ファイル名の指定f
                ''compressC.p_NihongoFileName = pstrSessionID & "累積情報一覧表.xls" ' 2011/06/02 T.Watabe edit
                'compressC.p_NihongoFileName = "累積情報_" & strXlsSubName & "_" & pstrSessionID & ".xls"
                ''圧縮元ファイル名
                'compressC.p_FileName = ExcelC.pDirName & ExcelC.pFileName & ".xls"
                ''圧縮先ファイル名
                'compressC.p_madeFilename = ExcelC.pDirName & ExcelC.pFileName & ".lzh"
                'compressC.p_Exec = pbolLzhAutoExec '解凍時の自動実行あり？／なし？

                ''2014/01/16 T.Ono mod 監視改善2013 Excelを直接開くように変更、ファイルフルパスを返す
                '''圧縮実行
                ''compressC.mCompress()
                '''圧縮したファイルをBase64エンコードして戻す
                '''.xls形式に変更 2013/12/05 T.Ono mod 監視改善2013
                '''Return FileToStrC.mFileToStr(compressC.p_madeFilename.Replace(".lzh", ".exe"))
                ''Return FileToStrC.mFileToStr(compressC.p_FileName)
                ''2015/11/04 w.ganeko 2015改善開発 №6 start
                ''Return compressC.p_FileName
                'If pstrZipFlg = "0" Then
                '    'Return compressC.p_FileName
                '    Dim sCopyFrom As String = ExcelC.pDirName & ExcelC.pFileName & ".xls"
                '    Return sCopyFrom
                'ElseIf pstrZipFlg = "1" Then
                '    '圧縮実行
                '    compressC.mCompress()
                '    '圧縮したファイルをBase64エンコードして戻す
                '    Return FileToStrC.mFileToStr(compressC.p_madeFilename.Replace(".lzh", ".exe"))
                'End If
                ''2015/11/04 w.ganeko 2015改善開発 №6 end

                '変数宣言
                Dim strToDir As String = ""           '圧縮先ファイルのあるフォルダ
                Dim strToZipDir As String = ""        '圧縮するディレクトリ
                Dim strNihongoFileName As String = "" '日本語ファイル名の指定(パラメータ[セッション] + 電話番号)
                Dim strFileName As String = ""        '圧縮元ファイル名(FAX用EXCEL、メール用ZIPファイル名)
                Dim strmadeFilename As String = ""    '圧縮先ファイル名(パラメータ[セッション])

                'ファイルデータをエンコードして呼び出し元へ戻す方式
                '圧縮先ファイルのあるフォルダ
                strToDir = ExcelC.pDirName
                '日本語ファイル名の指定f
                strNihongoFileName = "累積情報_" & strXlsSubName & "_" & pstrSessionID & ".xls"
                '圧縮元ファイル名
                strFileName = ExcelC.pDirName & ExcelC.pFileName & ".xls"
                '圧縮先ファイル名
                strmadeFilename = ExcelC.pDirName & ExcelC.pFileName & ".zip"

                If pstrZipFlg = "0" Then
                    '累積情報一覧（Excelファイル名を返す）
                    Dim sCopyFrom As String = ExcelC.pDirName & ExcelC.pFileName & ".xls"
                    Return sCopyFrom
                ElseIf pstrZipFlg = "1" Then
                    '累積情報自動FAX（ZIP書庫を返す）
                    '圧縮するディレクトリの作成
                    strToZipDir = ExcelC.pDirName & pstrSessionID
                    If File.Exists(strToZipDir) = False Then
                        System.IO.Directory.CreateDirectory(strToZipDir)
                    End If

                    '圧縮先ファイル名      (パラメータ[セッション])※２回目以降の時は追加される
                    strmadeFilename = strToZipDir & ".zip"

                    'ディレクトリを圧縮（ZIP書庫作成）
                    If File.Exists(strmadeFilename) = False Then
                        ZipFile.CreateFromDirectory(strToZipDir, strmadeFilename, CompressionLevel.Optimal,
                                    False, System.Text.Encoding.GetEncoding("shift_jis"))
                    End If

                    'ZIP書庫をオープンし、ファイルを追加
                    Using fo As ZipArchive = ZipFile.Open(strmadeFilename, ZipArchiveMode.Update)
                        Dim e As ZipArchiveEntry = fo.CreateEntryFromFile(strFileName, strNihongoFileName)
                    End Using

                    '圧縮したファイルをBase64エンコードして戻す
                    Return FileToStrC.mFileToStr(strmadeFilename)

                End If
                '2018/02/19 T.Ono mod END ----------------------

            Else
                ' 2011/02/01 T.Watabe edit
                'ファイルパスを戻す方式（試し）
                Dim sCopyFrom As String = ExcelC.pDirName & ExcelC.pFileName & ".xls"
                'Dim sCopyTo As String = ExcelC.pDirName & pstrSessionID & "累積情報一覧表.xls"
                'Microsoft.VisualBasic.FileSystem.Rename(sCopyFrom, sCopyTo)
                'Return FileToStrC.mFileToStr(sCopyTo)
                'Return FileToStrC.mFileToStr(sCopyFrom)
                Return sCopyFrom
            End If

        Catch ex As Exception
            'エラーの内容とＳＱＬ文を返す
            Return "ERROR:" & ex.ToString

        Finally
            cdb.mClose()        '接続クローズ
        End Try

    End Function

    '******************************************************************************
    '*　概　要:ファイル圧縮（文字データをファイルに復元し、圧縮し(lzh,zip)、再度文字データに変換して戻す）
    '*　備　考:
    '******************************************************************************
    <WebMethod()> Public Function compressStr2Arc2Str(ByVal pFileName As String, ByVal pBase64Data As String, ByVal pPass As String) As String

        Dim compressC As New CCompress                  '圧縮クラス
        Dim FileToStrC As New CFileStr                  'ファイルをBase64にエンコードするクラス
        Dim excelPath As String
        Try

            excelPath = ConfigurationSettings.AppSettings.Get("EXCELPATH")

            If saveString2BinFile(pBase64Data, excelPath & pFileName) Then

                If False Then
                    '圧縮先ファイルのあるフォルダ
                    compressC.p_Dir = excelPath
                    '日本語ファイル名の指定
                    compressC.p_NihongoFileName = pFileName ' pstrSessionID & "累積情報一覧表.xls"
                    '圧縮元ファイル名
                    compressC.p_FileName = excelPath & pFileName   ' ExcelC.pDirName & ExcelC.pFileName & ".xls"
                    '圧縮先ファイル名
                    compressC.p_madeFilename = excelPath & pFileName.Replace(".xls", ".lzh") ' ExcelC.pDirName & ExcelC.pFileName & ".lzh"
                    compressC.p_Exec = False '解凍時の自動実行あり？／なし？
                    '圧縮実行
                    compressC.mCompress()
                    '圧縮したファイルをBase64エンコードして戻す
                    Return FileToStrC.mFileToStr(compressC.p_madeFilename)
                End If
                If True Then
                    Dim sXlsFilePath As String = excelPath & pFileName
                    Dim sZipFilePath As String = excelPath & pFileName.Replace(".xls", ".zip")

                    Call fncMakeZipWithPass(sXlsFilePath, sZipFilePath, pPass)

                    '圧縮したファイルをBase64エンコードして戻す
                    Return FileToStrC.mFileToStr(sZipFilePath)
                End If

            Else
                Dim buf As String = ""
                If IsNothing(pBase64Data) = False And pBase64Data.Length >= 10 Then buf = pBase64Data.Substring(0, 10)

                Return "ERROR:引数データからファイル復元エラー[" & pFileName & "][" & buf & "](compressStr2Arc2Str)"
            End If

        Catch ex As Exception
            'エラーの内容とＳＱＬ文を返す
            Return "ERROR:" & ex.ToString

        Finally

        End Try

    End Function

    '==========================================================================================
    ' バイト文字列からファイルに復元
    '==========================================================================================
    Public Function saveString2BinFile(ByVal base64Data As String, ByVal saveFilePath As String) As Boolean
        If base64Data.Length <= 0 Then Return False
        If saveFilePath.Length <= 0 Then Return False
        Try
            Dim bs() As Byte = System.Convert.FromBase64String(base64Data) 'バイト型配列に戻す
            Dim outFile As New System.IO.FileStream(saveFilePath, System.IO.FileMode.Create, System.IO.FileAccess.Write)             'ファイルに書き込む
            outFile.Write(bs, 0, bs.Length)
            outFile.Close()
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    '******************************************************************************
    '*　概　要:ヘッダー行を作成
    '*　備　考:
    '******************************************************************************
    Public Sub SubMakeHetter(ByVal pExcelC As CExcel, ByVal pdr As DataRow)

        'ヘッダー情報
        pExcelC.pCellStyle(1) = "height:16px;font-size:13px;border-style:none"
        pExcelC.pCellVal(1, "colspan = 9") = "ＪＡ:" & Convert.ToString(pdr.Item("JANM")) & _
                                            "　ＪＡ支所:" & Convert.ToString(pdr.Item("SISYONM"))
        pExcelC.mWriteLine("")   '行をファイルに書き込む

    End Sub

    '******************************************************************************
    '*　概　要:ＳＥＬＥＣＴ文を作成
    '*　備　考:[ind]1:件数取得  2:データ取得
    '******************************************************************************
    'Public Function fncMakeSelect(ByVal ind As Integer, _
    '                              ByVal pstrKuracd As String, _
    '                              ByVal pstrKyocd As String, _
    '                              ByVal pstrJacd As String, _
    '                              ByVal pstrJascd As String, _
    '                              ByVal pstrTrgFrom As String, _
    '                              ByVal pstrTrgTo As String, _
    '                              ByVal pstrPgKbn As String, _
    '                              ByVal pdecPageMax As Decimal) As String

    '    Dim strSQL As New StringBuilder("")

    '    strSQL.Append("SELECT ")
    '    If ind = 1 Then
    '        strSQL.Append("COUNT(*) ")
    '    Else
    '        strSQL.Append("DT.KENNM, ")
    '        strSQL.Append("DT.KURACD, ")
    '        strSQL.Append("DT.KANSCD, ")
    '        '20050730 NEC UPDATE START
    '        'strSQL.Append("HN.HAISO_CD, ")          '--JA支所マスタ．供給センターコード
    '        strSQL.Append("HA.HAISO_CD, ")          '--配送センタマスタ．供給センターコード
    '        '20050730 NEC UPDATE END
    '        strSQL.Append("HA.NAME, ")              '--配送センタマスタ．供給センター名
    '        strSQL.Append("DT.JACD, ")
    '        strSQL.Append("DT.JANM, ")
    '        strSQL.Append("DT.ACBCD, ")
    '        strSQL.Append("DT.ACBNM, ")
    '        strSQL.Append("DT.ACBCD || DT.USER_CD AS JUYOKA, ")
    '        strSQL.Append("DT.JUSYONM, ")
    '        '2006/06/14 NEC UPDATE START
    '        'strSQL.Append("DT.JUTEL1 || DT.JUTEL2 AS JUTEL, ")
    '        strSQL.Append("DT.JUTEL1, ")
    '        strSQL.Append("DT.JUTEL2, ")
    '        '2006/06/14 NEC END
    '        strSQL.Append("DT.RENTEL, ")
    '        strSQL.Append("DT.ADDR, ")
    '        strSQL.Append("DT.HATKBN_NAI, ")
    '        strSQL.Append("DT.HATYMD, ")
    '        strSQL.Append("DT.HATTIME, ")
    '        strSQL.Append("DT.KEIHOSU, ")
    '        strSQL.Append("DT.RYURYO, ")
    '        strSQL.Append("DT.KMNM1, ")
    '        strSQL.Append("DT.KMNM2, ")
    '        strSQL.Append("DT.KMNM3, ")
    '        strSQL.Append("DT.KMNM4, ")
    '        strSQL.Append("DT.KMNM5, ")
    '        strSQL.Append("DT.KMNM6, ")
    '        strSQL.Append("DT.TMSKB_NAI, ")
    '        strSQL.Append("DT.SYOYMD, ")
    '        strSQL.Append("DT.SYOTIME, ")
    '        strSQL.Append("DT.TAITNM, ")
    '        strSQL.Append("DT.TAIOKBN_NAI, ")
    '        strSQL.Append("DT.TKTANCD_NM, ")
    '        strSQL.Append("DT.TFKINM, ")
    '        strSQL.Append("DT.TKIGNM, ")
    '        strSQL.Append("DT.TSADNM, ")
    '        '2006/06/14 NEC UPDATE START
    '        strSQL.Append("DT.SDNM, ")
    '        '2006/06/14 NEC UPDATE END
    '        strSQL.Append("DT.TFKICD, ")    '--- 2005/07/12 ADD Falcon
    '        '--- ↓2005/05/21 ADD Falcon↓ ---
    '        strSQL.Append("DT.FUK_MEMO, ")
    '        strSQL.Append("DT.AITNM, ")
    '        strSQL.Append("DT.TSTANNM, ")
    '        strSQL.Append("DT.SADNM, ")
    '        strSQL.Append("DT.FKINM, ")
    '        strSQL.Append("DT.ASENM, ")
    '        strSQL.Append("DT.KIGNM, ")
    '        strSQL.Append("DT.STANM, ")
    '        strSQL.Append("DT.SDTBIK1, ")
    '        strSQL.Append("DT.SDTBIK2, ")
    '        '2006/06/14 NEC UPDATE START
    '        strSQL.Append("DT.SDTBIK3, ")
    '        strSQL.Append("DT.SIJI_BIKO1, ")
    '        '2006/06/14 NEC UPDATE END
    '        strSQL.Append("DT.SNTTOKKI, ")
    '        strSQL.Append("DT.STD_CD, ")
    '        '--- ↑2005/05/21 ADD Falcon↑ ---
    '        strSQL.Append("DT.TAIOKBN, ")       '--- 2005/05/26 ADD Falcon ---
    '        strSQL.Append("DT.TEL_MEMO1, ")
    '        strSQL.Append("DT.TEL_MEMO2, ")
    '        strSQL.Append("DT.KENSIN ") '2010/03/05 T.Watabe add
    '        strSQL.Append("FROM ")
    '        strSQL.Append("D20_TAIOU DT, ")
    '        strSQL.Append("HN2MAS HN, ")
    '        '20050730 NEC UPDATE START
    '        'strSQL.Append("HAIMAS HA ")
    '        strSQL.Append("(SELECT J.CLI_CD,J.HAN_CD,H.HAISO_CD,H.NAME FROM HN2MAS J,HAIMAS H ")
    '        strSQL.Append("WHERE SUBSTR(J.CLI_CD,2,2)=H.KEN_CD AND ")
    '        strSQL.Append("J.HAISO_CD=H.HAISO_CD ) HA ")
    '        '20050730 NEC UPDATE END
    '    End If
    '    'WHERE
    '    strSQL.Append("WHERE DT.TAIOKBN<'3' ")        '重複は含まない
    '    strSQL.Append("  AND DT.KURACD=HN.CLI_CD(+) ")
    '    strSQL.Append("  AND DT.ACBCD=HN.HAN_CD(+) ")
    '    '20050730 NEC UPDATE START
    '    'strSQL.Append("  AND SUBSTR(HN.CLI_CD,2,2)=HA.KEN_CD(+) ")
    '    'strSQL.Append("  AND HN.HAISO_CD=HA.HAISO_CD(+) ")
    '    strSQL.Append("  AND DT.KURACD=HA.CLI_CD(+) ")
    '    strSQL.Append("  AND DT.ACBCD=HA.HAN_CD(+) ")
    '    '20050730 NEC UPDATE END
    '    ' 画面からの条件指定
    '    If pstrKuracd.Length <> 0 Then
    '        strSQL.Append(" AND DT.KURACD = :KURACD ")
    '    End If
    '    If pstrKyocd.Length <> 0 Then
    '        '20050730 NEC UPDATE START
    '        '供給センターが指定されたときは等価結合
    '        'strSQL.Append("  AND :KYOCD=HN.HAISO_CD(+) ")
    '        strSQL.Append("  AND DT.KURACD=HA.CLI_CD ")
    '        strSQL.Append("  AND DT.ACBCD=HA.HAN_CD ")
    '        '20050730 NEC UPDATE END
    '        strSQL.Append("  AND :KYOCD=HA.HAISO_CD ")
    '    End If
    '    If pstrJacd.Length <> 0 Then
    '        'strSQL.Append("	  AND DT.JACD LIKE :JACD || '%' ")
    '        strSQL.Append("	  AND DT.JACD = :JACD ")
    '    End If
    '    If pstrJascd.Length <> 0 Then
    '        strSQL.Append("	  AND DT.ACBCD = :JASCD ")
    '    End If
    '    strSQL.Append("	  AND DT.HATKBN = :HATKBN ")
    '    ''指定されている対象期間に応じて発生日で比較を行う
    '    If pstrTrgFrom.Length > 0 And pstrTrgTo.Length > 0 Then
    '        strSQL.Append(" AND DT.HATYMD BETWEEN :TRGDATE_FROM AND :TRGDATE_TO ")
    '    ElseIf pstrTrgFrom.Length > 0 And pstrTrgTo.Length = 0 Then
    '        strSQL.Append(" AND DT.HATYMD >= :TRGDATE_FROM ")
    '    ElseIf pstrTrgFrom.Length = 0 And pstrTrgTo.Length > 0 Then
    '        strSQL.Append(" AND DT.HATYMD <= :TRGDATE_TO ")
    '    End If

    '    If ind = 2 Then
    '        strSQL.Append(" AND ROWNUM <= " & pdecPageMax & " ")

    '        'ORDER BY
    '        strSQL.Append("	ORDER BY ")
    '        If pstrPgKbn = "1" Then
    '            strSQL.Append("DT.KURACD, ")
    '            strSQL.Append("DT.JACD, ")
    '            strSQL.Append("DT.HATYMD, ")
    '            strSQL.Append("DT.HATTIME, ")
    '            strSQL.Append("DT.ACBCD ")
    '        ElseIf pstrPgKbn = "2" Then
    '            strSQL.Append("DT.KURACD, ")
    '            strSQL.Append("HN.HAISO_CD, ")
    '            strSQL.Append("DT.HATYMD, ")
    '            strSQL.Append("DT.HATTIME, ")
    '            strSQL.Append("DT.ACBCD, ")
    '            strSQL.Append("DT.USER_CD ")
    '        Else
    '            strSQL.Append("DT.HATYMD, ")
    '            strSQL.Append("DT.HATTIME, ")
    '            strSQL.Append("DT.ACBCD, ")
    '            strSQL.Append("DT.USER_CD ")
    '        End If
    '    End If

    '    Return strSQL.ToString

    'End Function
    '*-----------------------------------------------------------*
    '2011.11.21 MOD H.Uema
    ' 引数追加(発生区分：3追加に伴う)
    '*-----------------------------------------------------------*
    'Public Function fncMakeSelect(ByVal ind As Integer, _
    '                              ByVal pstrKuraCd As String, _
    '                              ByVal pstrKyoCd As String, _
    '                              ByVal pstrJaCdFr As String, _
    '                              ByVal pstrJaCdTo As String, _
    '                              ByVal pstrJasCdFr As String, _
    '                              ByVal pstrJasCdTo As String, _
    '                              ByVal pstrTrgFrom As String, _
    '                              ByVal pstrTrgTo As String, _
    '                              ByVal pstrPgKbn As String, _
    '                              ByVal pdecPageMax As Decimal) As String
    '2015/11/04 w.ganeko 2015改善開発 №6 start
    'Public Function fncMakeSelect(ByVal ind As Integer, _
    '                                ByVal pstrKuraCd As String, _
    '                                ByVal pstrKyoCd As String, _
    '                                ByVal pstrJaCdFr As String, _
    '                                ByVal pstrJaCdTo As String, _
    '                                ByVal pstrJasCdFr As String, _
    '                                ByVal pstrJasCdTo As String, _
    '                                ByVal pstrTrgFrom As String, _
    '                                ByVal pstrTrgTo As String, _
    '                                ByVal pstrPgKbn As String, _
    '                                ByVal pdecPageMax As Decimal, _
    '                                ByVal pstrHatKbn As String) As String
    ''**********************************************************
    '' 2012/06/28 ADD W.GANEKO
    ''ログ吐き出し
    ''戻り値：書き込んだファイルへのフルパス
    ''**********************************************************
    'Public Sub mlog(ByVal pstrString As String)
    '    Dim strFilnm As String = "log" & System.DateTime.Today.ToString("yyyyMMdd")
    '    Dim strLogPath As String = ConfigurationSettings.AppSettings("LOG_OUT_PATH")
    '    Dim strPath As String = strLogPath & strFilnm & ".txt"
    '    Dim strLogFlg As String = ConfigurationSettings.AppSettings("LOG_OUT")
    '    If strLogFlg = "1" Then
    '        '書き込みファイルへのストリーム
    '        Dim outFile As New StreamWriter(strPath, True, System.Text.Encoding.Default)

    '        '引数の文字列をストリームに書き込み
    '        outFile.Write(System.DateTime.Now & pstrString + vbCrLf)

    '        'メモリフラッシュ（ファイル書き込み）
    '        outFile.Flush()

    '        'ファイルクローズ
    '        outFile.Close()
    '    End If
    'End Sub
    '2017/02/15 H.Mori mod 改善2016 No9-1 START
    'Public Function fncMakeSelect(ByVal ind As Integer, _
    '                                ByVal pstrKuraCd As String, _
    '                                ByVal pstrKyoCd As String, _
    '                                ByVal pstrJaCdFr As String, _
    '                                ByVal pstrJaCdTo As String, _
    '                                ByVal pstrJasCdFr As String, _
    '                                ByVal pstrJasCdTo As String, _
    '                                ByVal pstrTrgFrom As String, _
    '                                ByVal pstrTrgTo As String, _
    '                                ByVal pstrPgKbn As String, _
    '                                ByVal pdecPageMax As Decimal, _
    '                                ByVal pstrHatKbn As String, _
    '                                ByVal pstrHanbaiCdFr As String, _
    '                                ByVal pstrHanbaiCdTo As String, _
    '                                ByVal pstrTaikbn As String, _
    '                                ByVal pstrHkkbn As String
    '                                ) As String
    '2015/11/04 w.ganeko 2015改善開発 №6 end
    Public Function fncMakeSelect(ByVal ind As Integer, _
                                ByVal pstrKuraCd As String, _
                                ByVal pstrKyoCd As String, _
                                ByVal pstrJaCdFr As String, _
                                ByVal pstrJaCdTo As String, _
                                ByVal pstrJasCdFr As String, _
                                ByVal pstrJasCdTo As String, _
                                ByVal pstrTrgFrom As String, _
                                ByVal pstrTrgTo As String, _
                                ByVal pstrPgKbn As String, _
                                ByVal pdecPageMax As Decimal, _
                                ByVal pstrHatKbn As String, _
                                ByVal pstrHanbaiCdFr As String, _
                                ByVal pstrHanbaiCdTo As String, _
                                ByVal pstrTaikbn As String, _
                                ByVal pstrHkkbn As String, _
                                ByVal pstrKikankbn As String, _
                                ByVal pstrTrgTimeFrom As String, _
                                ByVal pstrTrgTimeTo As String _
                                ) As String
        '2017/02/15 H.Mori mod 改善2016 No9-1 END
        Dim strSQL As New StringBuilder("")
        '2015/11/04 w.ganeko 2015改善開発 №6 start
        Dim taiArry As String() = pstrTaikbn.Split(","c)
        Dim taiStr As String = ""
        For i As Integer = 0 To taiArry.Length - 1 Step 1
            If taiArry(i) <> "0" And taiArry(i) <> "" Then
                If taiStr <> "" Then
                    taiStr = taiStr & ","
                End If
                taiStr = taiStr & "'" & taiArry(i) & "'"
            End If
        Next
        '2015/11/04 w.ganeko 2015改善開発 №6 end
        strSQL.Append("SELECT ")
        If ind = 1 Then
            strSQL.Append("COUNT(*) ")
        Else
            strSQL.Append("DT.KENNM, ")
            strSQL.Append("DT.KURACD, ")
            strSQL.Append("DT.KANSCD, ")
            strSQL.Append("DT.SYONO, ")             '2016/11/30 T.Ono add 2016改善開発 №12
            '20050730 NEC UPDATE START
            'strSQL.Append("HN.HAISO_CD, ")          '--JA支所マスタ．供給センターコード
            strSQL.Append("HA.HAISO_CD, ")          '--配送センタマスタ．供給センターコード
            '20050730 NEC UPDATE END
            strSQL.Append("HA.NAME, ")              '--配送センタマスタ．供給センター名
            strSQL.Append("DT.JACD, ")
            strSQL.Append("DT.JANM, ")
            strSQL.Append("DT.ACBCD, ")
            strSQL.Append("DT.ACBNM, ")
            strSQL.Append("DT.ACBCD || DT.USER_CD AS JUYOKA, ")
            strSQL.Append("DT.JUSYONM, ")
            '2006/06/14 NEC UPDATE START
            'strSQL.Append("DT.JUTEL1 || DT.JUTEL2 AS JUTEL, ")
            strSQL.Append("DT.JUTEL1, ")
            strSQL.Append("DT.JUTEL2, ")
            '2006/06/14 NEC END
            strSQL.Append("DT.RENTEL, ")
            strSQL.Append("DT.ADDR, ")
            strSQL.Append("DT.HATKBN_NAI, ")
            strSQL.Append("DT.HATYMD, ")
            strSQL.Append("DT.HATTIME, ")
            strSQL.Append("DT.KEIHOSU, ")
            strSQL.Append("DT.RYURYO, ")
            '2020/11/01 T.Ono mod 2020監視改善 Start
            '' 2015/01/05 H.Hosoda mod 2014改善開発 No8,9 追加対応 START
            ''strSQL.Append("DT.KMNM1, ")
            ''strSQL.Append("DT.KMNM2, ")
            ''strSQL.Append("DT.KMNM3, ")
            ''strSQL.Append("DT.KMNM4, ")
            ''strSQL.Append("DT.KMNM5, ")
            ''strSQL.Append("DT.KMNM6, ")
            'strSQL.Append("DECODE(DT.KMCD1,NULL,'',DT.KMNM1) AS KMNM1,")
            'strSQL.Append("DECODE(DT.KMCD2,NULL,'',DT.KMNM2) AS KMNM2,")
            'strSQL.Append("DECODE(DT.KMCD3,NULL,'',DT.KMNM3) AS KMNM3,")
            'strSQL.Append("DECODE(DT.KMCD4,NULL,'',DT.KMNM4) AS KMNM4,")
            'strSQL.Append("DECODE(DT.KMCD5,NULL,'',DT.KMNM5) AS KMNM5,")
            'strSQL.Append("DECODE(DT.KMCD6,NULL,'',DT.KMNM6) AS KMNM6,")
            '' 2015/01/05 H.Hosoda mod 2014改善開発 No8,9 追加対応 END
            strSQL.Append("DT.KMNM1, ")
            strSQL.Append("DT.KMNM2, ")
            strSQL.Append("DT.KMNM3, ")
            strSQL.Append("DT.KMNM4, ")
            strSQL.Append("DT.KMNM5, ")
            strSQL.Append("DT.KMNM6, ")
            '2020/11/01 T.Ono mod 2020監視改善 StartEND
            strSQL.Append("DT.TMSKB_NAI, ")
            strSQL.Append("DT.SYOYMD, ")
            strSQL.Append("DT.SYOTIME, ")
            strSQL.Append("DT.TAITNM, ")
            strSQL.Append("DT.TAIOKBN_NAI, ")
            strSQL.Append("DT.TKTANCD_NM, ")
            strSQL.Append("DT.TFKINM, ")
            strSQL.Append("DT.TKIGNM, ")
            strSQL.Append("DT.TSADNM, ")
            '2006/06/14 NEC UPDATE START
            strSQL.Append("DT.SDNM, ")
            '2006/06/14 NEC UPDATE END
            strSQL.Append("DT.TFKICD, ")    '--- 2005/07/12 ADD Falcon
            '--- ↓2005/05/21 ADD Falcon↓ ---
            strSQL.Append("DT.FUK_MEMO, ")
            strSQL.Append("DT.AITNM, ")
            ' 2015/02/12 H.Hosoda mod 2014改善開発 No9 START
            'strSQL.Append("DT.TSTANNM, ")
            strSQL.Append("DT.SYUTDTNM, ")
            ' 2015/02/12 H.Hosoda mod 2014改善開発 No9 END
            strSQL.Append("DT.SADNM, ")
            strSQL.Append("DT.FKINM, ")
            'strSQL.Append("DT.ASENM, ") ' 2015/02/12 H.Hosoda del 2014改善開発 No9
            strSQL.Append("DT.KIGNM, ")
            'strSQL.Append("DT.STANM, ") ' 2015/02/12 H.Hosoda del 2014改善開発 No9
            strSQL.Append("DT.SDTBIK1, ")
            strSQL.Append("DT.SDTBIK2, ")
            '2006/06/14 NEC UPDATE START
            strSQL.Append("DT.SDTBIK3, ")
            strSQL.Append("DT.SIJI_BIKO1, ")
            '2006/06/14 NEC UPDATE END
            strSQL.Append("DT.SNTTOKKI, ")
            strSQL.Append("DT.STD_CD, ")
            '--- ↑2005/05/21 ADD Falcon↑ ---
            strSQL.Append("DT.TAIOKBN, ")       '--- 2005/05/26 ADD Falcon ---
            strSQL.Append("DT.TEL_MEMO1, ")
            strSQL.Append("DT.TEL_MEMO2, ")
            strSQL.Append("DT.TEL_MEMO4, ")         '2020/11/01 T.Ono add 2020監視改善
            strSQL.Append("DT.TEL_MEMO5, ")         '2020/11/01 T.Ono add 2020監視改善
            strSQL.Append("DT.TEL_MEMO6, ")         '2020/11/01 T.Ono add 2020監視改善
            ' 2015/02/12 H.Hosoda add 2014改善開発 No8,9 START
            strSQL.Append("DT.SIJIYMD, ")
            strSQL.Append("DT.SIJITIME, ")
            strSQL.Append("DT.SDYMD, ")
            strSQL.Append("DT.SDTIME, ")
            strSQL.Append("DT.TYAKYMD, ")
            strSQL.Append("DT.TYAKTIME, ")
            strSQL.Append("DT.SYOKANYMD, ")
            strSQL.Append("DT.SYOKANTIME, ")
            strSQL.Append("DT.HANJICD, ")                  '2015/11/04 w.ganeko 2015改善開発 №6
            strSQL.Append("DT.HANJINM, ")                  '2015/11/04 w.ganeko 2015改善開発 №6
            ' 2015/02/12 H.Hosoda add 2014改善開発 No8,9 END
            strSQL.Append("DT.KENSIN ") '2010/03/05 T.Watabe add
            strSQL.Append("FROM ")
            strSQL.Append("    D20_TAIOU DT, ")
            strSQL.Append("    HN2MAS HN, ")
            '20050730 NEC UPDATE START
            'strSQL.Append("HAIMAS HA ")
            strSQL.Append("    ( ")
            strSQL.Append("        SELECT J.CLI_CD,J.HAN_CD,H.HAISO_CD,H.NAME ")
            strSQL.Append("        FROM HN2MAS J,HAIMAS H ")
            strSQL.Append("        WHERE SUBSTR(J.CLI_CD,2,2)=H.KEN_CD AND J.HAISO_CD=H.HAISO_CD ")
            strSQL.Append("    ) HA ")
            '20050730 NEC UPDATE END
        End If
        'WHERE
        strSQL.Append("WHERE ")        '重複は含まない
        '2015/11/04 w.ganeko 2015改善開発 №6 start
        'strSQL.Append("      DT.TAIOKBN<'3' ")        '重複は含まない
        If taiStr.Length > 0 And taiStr <> "" Then
            strSQL.Append("      DT.TAIOKBN IN (" & taiStr & ")") '重複は含まない
        Else
            strSQL.Append("      DT.TAIOKBN<'3'") '重複は含まない
        End If
        '販売事業者
        If pstrHanbaiCdFr.Length <> 0 Or pstrHanbaiCdTo.Length <> 0 Then
            'strSQL.Append("      AND EXISTS( ")
            'strSQL.Append("        SELECT 'X' FROM ")
            'strSQL.Append("          M10_HANJIGYOSYA M10, ")
            'strSQL.Append("          M09_JAGROUP M09, ")
            'strSQL.Append("          CLIMAS CL ")
            'strSQL.Append("         WHERE 1=1 ")
            'strSQL.Append("         AND M09.KURACD = CL.CLI_CD ")
            'strSQL.Append("         AND M10.GROUPCD = M09.GROUPCD ")
            'strSQL.Append("         AND CL.CLI_CD = M09.KURACD ")
            'strSQL.Append("         AND CL.CLI_CD = DT.KURACD ")
            'strSQL.Append("         AND M09.ACBCD = DT.ACBCD ")
            'strSQL.Append("      ) ")
            If pstrHanbaiCdFr.Length <> 0 Then strSQL.Append("	  AND DT.HANJICD >= :GROUPCDFR ")
            If pstrHanbaiCdTo.Length <> 0 Then strSQL.Append("	  AND DT.HANJICD <= :GROUPCDTO ")
        End If
        If pstrHkkbn.Length <> 0 And pstrHkkbn <> "0" Then
            strSQL.Append("      AND DT.FAXRUISEKIKBN = '" & pstrHkkbn & "' ")
        End If
        '2015/11/04 w.ganeko 2015改善開発 №6 end
        strSQL.Append("  AND DT.KURACD=HN.CLI_CD(+) ")
        strSQL.Append("  AND DT.ACBCD=HN.HAN_CD(+) ")
        '20050730 NEC UPDATE START
        'strSQL.Append("  AND SUBSTR(HN.CLI_CD,2,2)=HA.KEN_CD(+) ")
        'strSQL.Append("  AND HN.HAISO_CD=HA.HAISO_CD(+) ")
        strSQL.Append("  AND DT.KURACD=HA.CLI_CD(+) ")
        strSQL.Append("  AND DT.ACBCD=HA.HAN_CD(+) ")
        '20050730 NEC UPDATE END
        ' 画面からの条件指定
        If pstrKuraCd.Length <> 0 Then
            strSQL.Append(" AND DT.KURACD = :KURACD ")
        End If
        If pstrKyoCd.Length <> 0 Then
            '20050730 NEC UPDATE START
            '供給センターが指定されたときは等価結合
            'strSQL.Append("  AND :KYOCD=HN.HAISO_CD(+) ")
            strSQL.Append("  AND DT.KURACD=HA.CLI_CD ")
            strSQL.Append("  AND DT.ACBCD=HA.HAN_CD ")
            '20050730 NEC UPDATE END
            strSQL.Append("  AND :KYOCD=HA.HAISO_CD ")
        End If
        If pstrJaCdFr.Length <> 0 Then strSQL.Append("	  AND DT.JACD >= :JACDFR ")
        If pstrJaCdTo.Length <> 0 Then strSQL.Append("	  AND DT.JACD <= :JACDTO ")
        If pstrJasCdFr.Length <> 0 Then strSQL.Append("	  AND DT.ACBCD >= :JASCDFR ")
        If pstrJasCdTo.Length <> 0 Then strSQL.Append("	  AND DT.ACBCD <= :JASCDTO ")
        '2011.11.21 MODIFY H.Uema *-----------------------------------------* start
        'strSQL.Append("	  AND DT.HATKBN = :HATKBN ")
        If String.Compare("3", pstrHatKbn, True) <> 0 Then
            strSQL.Append("	  AND DT.HATKBN = :HATKBN ")
        Else
            strSQL.Append("   AND DT.HATKBN < :HATKBN ")
        End If
        '2011.11.21 MODIFY H.Uema *-----------------------------------------* end

        ' 2015/02/12 H.Hosoda mod 2014改善開発 No8,9 追加対応 START
        ''指定されている対象期間に応じて発生日で比較を行う
        'If pstrTrgFrom.Length > 0 And pstrTrgTo.Length > 0 Then
        '    strSQL.Append(" AND DT.HATYMD BETWEEN :TRGDATE_FROM AND :TRGDATE_TO ")
        'ElseIf pstrTrgFrom.Length > 0 And pstrTrgTo.Length = 0 Then
        '    strSQL.Append(" AND DT.HATYMD >= :TRGDATE_FROM ")
        'ElseIf pstrTrgFrom.Length = 0 And pstrTrgTo.Length > 0 Then
        '    strSQL.Append(" AND DT.HATYMD <= :TRGDATE_TO ")
        'End If
        ''指定されている対象期間に応じて対応完了日で比較を行う
        '2017/02/15 H.Mori mod 改善2016 No9-1 START
        'If pstrTrgFrom.Length > 0 And pstrTrgTo.Length > 0 Then
        '    strSQL.Append(" AND DT.SYOYMD BETWEEN :TRGDATE_FROM AND :TRGDATE_TO ")
        'ElseIf pstrTrgFrom.Length > 0 And pstrTrgTo.Length = 0 Then
        '    strSQL.Append(" AND DT.SYOYMD >= :TRGDATE_FROM ")
        'ElseIf pstrTrgFrom.Length = 0 And pstrTrgTo.Length > 0 Then
        '    strSQL.Append(" AND DT.SYOYMD <= :TRGDATE_TO ")
        'End If
        ' 2015/02/12 H.Hosoda mod 2014改善開発 No8,9 追加対応 END
        If pstrKikankbn = "1" Then '対応完了日
            If pstrTrgTimeFrom.Length = 0 AndAlso pstrTrgTimeTo.Length = 0 Then
                strSQL.Append(" AND DT.SYOYMD BETWEEN :TRGDATE_FROM AND :TRGDATE_TO ")
            ElseIf pstrTrgTimeFrom.Length > 0 AndAlso pstrTrgTimeTo.Length > 0 Then
                strSQL.Append(" AND DT.SYOYMD || DT.SYOTIME BETWEEN :TRGDATE_FROM || :TRGTIME_FROM AND :TRGDATE_TO || :TRGTIME_TO ")
            End If
        Else                       '受信日
            If pstrTrgTimeFrom.Length = 0 AndAlso pstrTrgTimeTo.Length = 0 Then
                strSQL.Append(" AND DT.HATYMD BETWEEN :TRGDATE_FROM AND :TRGDATE_TO ")
            ElseIf pstrTrgTimeFrom.Length > 0 AndAlso pstrTrgTimeTo.Length > 0 Then
                strSQL.Append(" AND DT.HATYMD || DT.HATTIME BETWEEN :TRGDATE_FROM || :TRGTIME_FROM AND :TRGDATE_TO || :TRGTIME_TO ")
            End If
        End If
            '2017/02/15 H.Mori mod 改善2016 No9-1 END

            If ind = 2 Then
                'strSQL.Append(" AND ROWNUM <= " & pdecPageMax & " ") 2013/12/06 T.Ono del 監視改善2013

                'ORDER BY
                strSQL.Append("	ORDER BY ")
                If pstrPgKbn = "1" Then
                    strSQL.Append("DT.KURACD, ")
                    strSQL.Append("DT.JACD, ")
                    strSQL.Append("DT.HATYMD, ")
                    strSQL.Append("DT.HATTIME, ")
                    strSQL.Append("DT.ACBCD ")
                    '2015/11/04 w.ganeko 2015改善開発 №6 start
                    'ElseIf pstrPgKbn = "2" Then
                    '    strSQL.Append("DT.KURACD, ")
                    '    strSQL.Append("HN.HAISO_CD, ")
                    '    strSQL.Append("DT.HATYMD, ")
                    '    strSQL.Append("DT.HATTIME, ")
                    '    strSQL.Append("DT.ACBCD, ")
                    '    strSQL.Append("DT.USER_CD ")
                ElseIf pstrPgKbn = "2" Then
                    strSQL.Append("DT.KURACD, ")
                    strSQL.Append("DT.JACD, ")
                    strSQL.Append("DT.ACBCD, ")
                    strSQL.Append("DT.HATYMD, ")
                    strSQL.Append("DT.HATTIME, ")
                    strSQL.Append("DT.USER_CD ")
                ElseIf pstrPgKbn = "3" Then
                    strSQL.Append("DT.KURACD, ")
                    strSQL.Append("DT.HANJICD, ")
                    strSQL.Append("DT.HATYMD, ")
                    strSQL.Append("DT.HATTIME, ")
                    strSQL.Append("DT.ACBCD, ")
                    strSQL.Append("DT.USER_CD ")
                ElseIf pstrPgKbn = "4" Then
                    strSQL.Append("DT.KURACD, ")
                    strSQL.Append("HN.HAISO_CD, ")
                    strSQL.Append("DT.HATYMD, ")
                    strSQL.Append("DT.HATTIME, ")
                    strSQL.Append("DT.ACBCD, ")
                    strSQL.Append("DT.USER_CD ")
                    '2015/11/04 w.ganeko 2015改善開発 №6 end
                Else
                    strSQL.Append("DT.HATYMD, ")
                    strSQL.Append("DT.HATTIME, ")
                    strSQL.Append("DT.ACBCD, ")
                    strSQL.Append("DT.USER_CD ")
                End If
            End If
            'mlog(strSQL.ToString)

            Return strSQL.ToString

    End Function

    ''''******************************************************************************
    ''''*　概　要:ＳＥＬＥＣＴ文を作成
    ''''*　備　考:
    ''''******************************************************************************
    '''Public Function fncMakeSelect2(ByVal pstrKuracd As String, _
    '''                              ByVal pstrKyocd As String, _
    '''                              ByVal pstrJacd As String, _
    '''                              ByVal pstrJascd As String, _
    '''                              ByVal pstrTrgFrom As String, _
    '''                              ByVal pstrTrgTo As String) As String

    '''    Dim strSQL As New StringBuilder("")

    '''    'SELECT
    '''    strSQL.Append("SELECT ")
    '''    strSQL.Append(" TAI.KENNM AS KENNM, ")
    '''    strSQL.Append(" NOU.CENTNM AS CENTNM, ")
    '''    strSQL.Append(" NOU.ACBNM AS JANM, ")
    '''    strSQL.Append(" NOU.SISYONM AS SISYONM, ")
    '''    strSQL.Append(" NOU.ACBKETA AS ACBKETA, ")
    '''    strSQL.Append(" TAI.ACBCD AS ACBCD, ")
    '''    strSQL.Append(" TAI.HATKBN_NAI AS HATKBN_NAI, ")
    '''    strSQL.Append(" TAI.JUYOKA AS JUYOKA, ")
    '''    strSQL.Append(" TAI.JUSYONM AS JUSYONM, ")
    '''    strSQL.Append(" TAI.JUTEL AS JUTEL, ")
    '''    strSQL.Append(" TAI.RENTEL AS RENTEL, ")
    '''    strSQL.Append(" TAI.ADDR AS ADDR, ")
    '''    strSQL.Append(" TAI.HATYMD AS HATYMD, ")
    '''    strSQL.Append(" TAI.HATTIME AS HATTIME, ")
    '''    strSQL.Append(" TAI.KEIHOSU AS KEIHOSU, ")
    '''    strSQL.Append(" TAI.RYURYO AS RYURYO, ")
    '''    strSQL.Append(" TAI.KMNM1 AS KMNM1, ")
    '''    strSQL.Append(" TAI.KMNM2 AS KMNM2, ")
    '''    strSQL.Append(" TAI.KMNM3 AS KMNM3, ")
    '''    strSQL.Append(" TAI.KMNM4 AS KMNM4, ")
    '''    strSQL.Append(" TAI.KMNM5 AS KMNM5, ")
    '''    strSQL.Append(" TAI.KMNM6 AS KMNM6 , ")
    '''    strSQL.Append(" TAI.TMSKB AS TMSKB , ")
    '''    strSQL.Append(" TAI.TMSKB_NAI AS TMSKB_NAI, ")
    '''    strSQL.Append(" TAI.SYOYMD AS SYOYMD, ")
    '''    strSQL.Append(" TAI.SYOTIME AS SYOTIME, ")
    '''    strSQL.Append(" TAI.TAITNM AS TAITNM, ")
    '''    strSQL.Append(" TAI.TAIOKBN AS TAIOKBN, ")
    '''    strSQL.Append(" TAI.TAIOKBN_NAI AS TAIOKBN_NAI, ")
    '''    strSQL.Append(" TAI.TKTANCD_NM AS TKTANCD_NM, ")
    '''    strSQL.Append(" TAI.TFKINM AS TFKINM, ")
    '''    strSQL.Append(" TAI.TKIGNM AS TKIGNM, ")
    '''    strSQL.Append(" TAI.TSADNM AS TSADNM, ")
    '''    strSQL.Append(" TAI.TEL_MEMO1 AS TEL_MEMO1, ")
    '''    strSQL.Append(" TAI.TEL_MEMO2 AS TEL_MEMO2 ")

    '''    'FROM
    '''    strSQL.Append(" FROM ")
    '''    strSQL.Append(" (")
    '''    strSQL.Append(" SELECT NOU.KENCD,")
    '''    strSQL.Append("   NOU.ACBCD,")
    '''    strSQL.Append("   NOU.ACBNM,")
    '''    strSQL.Append("   NOU.SISYONM,")
    '''    strSQL.Append("   NOU.ACBKETA,")
    '''    strSQL.Append("   KYO.CENTNM ")
    '''    strSQL.Append("  FROM M03_NOKYO NOU,")
    '''    strSQL.Append("   M04_KYOKYU KYO ")
    '''    strSQL.Append("  WHERE NOU.KENCD=KYO.KENCD ")
    '''    strSQL.Append("    AND NOU.CENTCD=KYO.CENTCD ")
    '''    strSQL.Append(" ) NOU, ")
    '''    strSQL.Append(" D20_TAIOU TAI")

    '''    'WHERE
    '''    If pstrKuracd.Length <> 0 Then
    '''        strSQL.Append("	WHERE TAI.KENCD = :KENCD")
    '''    End If
    '''    If pstrKyocd.Length <> 0 Then
    '''        strSQL.Append("	  AND NOU.CENTCD LIKE :CENTCD || '%'")
    '''    End If
    '''    If pstrJacd.Length <> 0 Then
    '''        strSQL.Append("	  AND TAI.ACBCD LIKE :JACD || '%'")
    '''    End If
    '''    If pstrJascd.Length <> 0 Then
    '''        strSQL.Append("	  AND TAI.ACBCD = :JASCD")
    '''    End If
    '''    strSQL.Append("	  AND TAI.HATKBN = :HATKBN")
    '''    ''指定されている対象期間に応じて発生日で比較を行う
    '''    If pstrTrgFrom.Length > 0 And pstrTrgTo.Length > 0 Then
    '''        strSQL.Append(" AND TAI.HATYMD BETWEEN :TRGDATE_FROM AND :TRGDATE_TO")
    '''    ElseIf pstrTrgFrom.Length > 0 And pstrTrgTo.Length = 0 Then
    '''        strSQL.Append(" AND TAI.HATYMD >= :TRGDATE_FROM")
    '''    ElseIf pstrTrgFrom.Length = 0 And pstrTrgTo.Length > 0 Then
    '''        strSQL.Append(" AND TAI.HATYMD <= :TRGDATE_TO")
    '''    End If
    '''    strSQL.Append("	AND TAI.KENCD=NOU.KENCD(+)")
    '''    strSQL.Append("	AND TAI.ACBCD=NOU.ACBCD(+)")
    '''    '重複は含まない
    '''    strSQL.Append("	AND TAI.TAIOKBN<'3'")

    '''    'ORDER BY
    '''    strSQL.Append("	ORDER BY ")
    '''    '2004/11/24 NEC UPDATE START
    '''    '発生日順にソート
    '''    'strSQL.Append("	TAI.KENCD,")
    '''    'strSQL.Append("	TAI.ACBCD,")
    '''    'strSQL.Append("	TAI.JUYOKA")
    '''    strSQL.Append("	TAI.HATYMD,")
    '''    strSQL.Append("	TAI.HATTIME")
    '''    '2004/11/24 NEC UPDATE END

    '''    Return strSQL.ToString
    '''End Function
    '===========================================================
    ' ＪＡ名をＤＢから取得 2015/01/23 T.Ono add 
    '===========================================================
    Private Function getDB2JaNm(ByVal cdb As CDB, ByVal clientCd As String, ByVal jaCd As String) As String

        Dim res As String
        Dim ds As New DataSet
        Dim dr As DataRow
        Dim SQL As StringBuilder = New StringBuilder("")

        If clientCd.Length = 0 Then Return "" 'ｺｰﾄﾞが空はそのまま空で返す
        If jaCd.Length = 0 Then Return "" 'ｺｰﾄﾞが空はそのまま空で返す

        SQL.Append("SELECT JA_NAME FROM HN2MAS WHERE CLI_CD = '" & clientCd & "' AND  JA_CD = '" & jaCd & "'")
        Try
            cdb.pSQL = SQL.ToString
            cdb.mExecQuery()    'SQL実行
            ds = cdb.pResult    '結果をデータセットに格納

            'データが存在しない場合
            If ds.Tables(0).Rows.Count = 0 Then
                Return ""      'データが0件であることを示す文字列を返す
            End If
            dr = ds.Tables(0).Rows(0)           'データローにデータセットを格納
            res = Convert.ToString(dr.Item("JA_NAME"))

        Catch ex As Exception
        Finally
        End Try
        Return res
    End Function
    '===========================================================
    ' ＪＡ・ＪＡ支所名をＤＢから取得
    '===========================================================
    Private Function getDB2JasNm(ByVal cdb As CDB, ByVal clientCd As String, ByVal jasCd As String) As String

        Dim res As String
        Dim ds As New DataSet
        Dim dr As DataRow
        Dim SQL As StringBuilder = New StringBuilder("")

        If clientCd.Length = 0 Then Return "" 'ｺｰﾄﾞが空はそのまま空で返す
        If jasCd.Length = 0 Then Return "" 'ｺｰﾄﾞが空はそのまま空で返す

        SQL.Append("SELECT JAS_NAME FROM HN2MAS WHERE CLI_CD = '" & clientCd & "' AND  HAN_CD = '" & jasCd & "'")
        Try
            cdb.pSQL = SQL.ToString
            cdb.mExecQuery()    'SQL実行
            ds = cdb.pResult    '結果をデータセットに格納

            'データが存在しない場合
            If ds.Tables(0).Rows.Count = 0 Then
                Return ""      'データが0件であることを示す文字列を返す
            End If
            dr = ds.Tables(0).Rows(0)           'データローにデータセットを格納
            res = Convert.ToString(dr.Item("JAS_NAME"))

        Catch ex As Exception
        Finally
        End Try
        Return res
    End Function

    '===========================================================
    ' 県名をＤＢから取得
    '===========================================================
    Private Function getDB2KenNm(ByVal cdb As CDB, ByVal clientCd As String) As String

        Dim res As String
        Dim ds As New DataSet
        Dim dr As DataRow
        Dim SQL As StringBuilder = New StringBuilder("")

        If clientCd.Length = 0 Then Return "" 'ｺｰﾄﾞが空はそのまま空で返す

        SQL.Append("SELECT KEN_NAME FROM CLIMAS WHERE CLI_CD = '" & clientCd & "' ")
        Try
            cdb.pSQL = SQL.ToString
            cdb.mExecQuery()    'SQL実行
            ds = cdb.pResult    '結果をデータセットに格納

            'データが存在しない場合
            If ds.Tables(0).Rows.Count = 0 Then
                Return ""      'データが0件であることを示す文字列を返す
            End If
            dr = ds.Tables(0).Rows(0)           'データローにデータセットを格納
            res = Convert.ToString(dr.Item("KEN_NAME"))

        Catch ex As Exception
            Return ex.ToString
        Finally
        End Try
        Return res
    End Function

    ''===========================================================
    '' クライアント名をＤＢから取得
    ''===========================================================
    'Private Function getDB2ClientNm(ByVal cdb As CDB, ByVal clientCd As String) As String

    '    Dim res As String
    '    Dim ds As New DataSet
    '    Dim dr As DataRow
    '    Dim SQL As StringBuilder

    '    If clientCd.Length = 0 Then Return "" 'ｺｰﾄﾞが空はそのまま空で返す

    '    SQL.Append("SELECT CLI_NAME FROM CLIMAS WHERE CLI_CD = '" & clientCd & "' ")
    '    Try
    '        cdb.pSQL = SQL.ToString
    '        cdb.mExecQuery()    'SQL実行
    '        ds = cdb.pResult    '結果をデータセットに格納

    '        'データが存在しない場合
    '        If ds.Tables(0).Rows.Count = 0 Then
    '            Return ""      'データが0件であることを示す文字列を返す
    '        End If
    '        dr = ds.Tables(0).Rows(0)           'データローにデータセットを格納
    '        res = Convert.ToString(dr.Item("CLI_NAME"))

    '    Catch ex As Exception
    '    Finally
    '    End Try
    '    Return res
    'End Function

    '===========================================================
    ' 供給ｾﾝﾀｰ名をＤＢから取得
    '===========================================================
    Private Function getDB2CenterNm(ByVal cdb As CDB, ByVal kenCd As String, ByVal centerCd As String) As String

        Dim res As String
        Dim ds As New DataSet
        Dim dr As DataRow
        Dim SQL As StringBuilder = New StringBuilder("")

        If kenCd.Length = 0 Then Return "" 'ｺｰﾄﾞが空はそのまま空で返す
        If centerCd.Length = 0 Then Return "" 'ｺｰﾄﾞが空はそのまま空で返す

        SQL.Append("SELECT NAME FROM HAIMAS WHERE KEN_CD = '" & kenCd & "' AND HAISO_CD = '" & centerCd & "' ")
        Try
            cdb.pSQL = SQL.ToString
            cdb.mExecQuery()    'SQL実行
            ds = cdb.pResult    '結果をデータセットに格納

            'データが存在しない場合
            If ds.Tables(0).Rows.Count = 0 Then
                Return ""      'データが0件であることを示す文字列を返す
            End If
            dr = ds.Tables(0).Rows(0)           'データローにデータセットを格納
            res = Convert.ToString(dr.Item("NAME"))

        Catch ex As Exception
        Finally
        End Try
        Return res
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
    End Sub

    '******************************************************************************
    '*　概　要：S05_AUTOFAXLOGDB 累積情報自動FAXのログを記録する。
    '*　備　考：
    '*  作  成：2016/11/30 T.Ono
    '******************************************************************************
    Private Function mInsertS05AutofaxLog(ByVal cdb As CDB,
                                        ByVal pstrEXEC_YMD As String,
                                        ByVal pstrEXEC_TIME As String,
                                        ByVal pstrEXEC_KBN As String,
                                        ByVal pstrGUID As String,
                                        ByVal pintSEQNO As Integer,
                                        ByVal pstrINPUT_YMD As String,
                                        ByVal pstrLATEST_OF_DAY_FLG As String,
                                        ByVal pstrTAIOU_KANSCD As String,
                                        ByVal pstrTAIOU_SYONO As String,
                                        ByVal pstrTAIOU_KURACD As String,
                                        ByVal pstrTAIOU_JACD As String,
                                        ByVal pstrTAIOU_ACBCD As String,
                                        ByVal pstrTAIOU_USER_CD As String,
                                        ByVal pstrAUTO_KBN As String,
                                        ByVal pstrAUTO_FAXNO As String,
                                        ByVal pstrAUTO_MAIL As String,
                                        ByVal pstrAUTO_ZERO_FLG As String,
                                        ByVal pstrWHERE_TAIOU As String,
                                        ByVal pstrDEBUGFLG As String,
                                        ByVal pstrBIKO As String
                                        ) As String

        Dim sql As New StringBuilder("")

        Try
            '文字編集
            pstrWHERE_TAIOU = Replace(pstrWHERE_TAIOU, "'", "''") 'カンマを２重化
            pstrWHERE_TAIOU = Replace(pstrWHERE_TAIOU, vbCrLf, "") '改行をはずす
            pstrWHERE_TAIOU = Replace(pstrWHERE_TAIOU, "  ", " ") 'スペースを詰める

            '/* 自動FAX専用ログテーブルへ出力 */
            sql = New StringBuilder("")
            sql.Append("INSERT INTO S05_AUTOFAXLOGDB ")
            sql.Append("(")
            sql.Append("    EXEC_YMD     ,")
            sql.Append("    EXEC_TIME    ,")
            sql.Append("    EXEC_KBN    ,")
            sql.Append("    GUID         ,")
            sql.Append("    SEQNO        ,")
            sql.Append("    INPUT_YMD       ,")
            sql.Append("    LATEST_OF_DAY_FLG       ,")
            sql.Append("    TAIOU_KANSCD       ,")
            sql.Append("    TAIOU_SYONO        ,")
            sql.Append("    TAIOU_KURACD       ,")
            sql.Append("    TAIOU_JACD         ,")
            sql.Append("    TAIOU_ACBCD        ,")
            sql.Append("    TAIOU_USER_CD      ,")
            sql.Append("    AUTO_KBN     ,")
            sql.Append("    AUTO_FAXNO   ,")
            sql.Append("    AUTO_MAIL    ,")
            sql.Append("    AUTO_ZERO_FLG,")
            sql.Append("    SQLWHERE,")
            sql.Append("    DEBUGFLG,")
            sql.Append("    BIKO,")
            sql.Append("    ADD_DATE      ")
            sql.Append(")VALUES( ")
            sql.Append("    '" & pstrEXEC_YMD & "', ")
            sql.Append("    '" & pstrEXEC_TIME & "', ")
            sql.Append("    '" & pstrEXEC_KBN & "', ")
            sql.Append("    '" & pstrGUID & "', ")
            sql.Append("     " & pintSEQNO & ", ")
            sql.Append("    '" & pstrINPUT_YMD & "', ")
            sql.Append("    '" & pstrLATEST_OF_DAY_FLG & "', ")
            sql.Append("    '" & pstrTAIOU_KANSCD & "', ")
            sql.Append("    '" & pstrTAIOU_SYONO & "', ")
            sql.Append("    '" & pstrTAIOU_KURACD & "', ")
            sql.Append("    '" & pstrTAIOU_JACD & "', ")
            sql.Append("    '" & pstrTAIOU_ACBCD & "', ")
            sql.Append("    '" & pstrTAIOU_USER_CD & "', ")
            sql.Append("    '" & pstrAUTO_KBN & "', ")
            sql.Append("    '" & pstrAUTO_FAXNO & "', ")
            sql.Append("    '" & pstrAUTO_MAIL & "', ")
            sql.Append("    '" & pstrAUTO_ZERO_FLG & "', ")
            sql.Append("    '" & pstrWHERE_TAIOU & "', ")
            sql.Append("    '" & pstrDEBUGFLG & "', ")
            sql.Append("    '" & pstrBIKO & "', ")
            sql.Append("    SYSDATE ")
            sql.Append(") ")

            cdb.mBeginTrans() 'トランザクション開始
            cdb.pSQL = sql.ToString '//SQLセット
            cdb.mExecNonQuery() '//SQL実行
            cdb.mCommit() 'トランザクション終了(コミット)
        Catch ex As Exception
            cdb.mRollback() 'トランザクション終了(ロールバック)
            'エラーの内容とＳＱＬ文を返す
            Return "ERROR:" & ex.ToString & vbCrLf & vbCrLf & Environment.StackTrace & vbCrLf & " 直前のSQL[" & sql.ToString & "]"
        Finally
        End Try

        Return "OK"

    End Function
    '******************************************************************************
    '*　概　要：S05_AUTOFAXLOGDB ログの前回分をクリアする。
    '*　備　考：2016/11/30時点では未使用。デバッグ実行機能がないので、使用しない。
    '*        ：使うときは、このコメントも消してください。 
    '*  作  成：2016/11/30 T.Ono
    '******************************************************************************
    Private Function mUpdateFlgS05AutofaxLog(ByVal cdb As CDB,
                                        ByVal pstrEXEC_KBN As String,
                                        ByVal pstrINPUT_YMD As String,
                                        ByVal pstrAUTO_KBN As String,
                                        ByVal pstrAUTO_FAXNO As String,
                                        ByVal pstrAUTO_MAIL As String
                                        ) As String

        Dim sql As New StringBuilder("")

        Try
            '/* 自動FAX専用ログテーブルを更新 */
            sql = New StringBuilder("")
            sql.Append("UPDATE S05_AUTOFAXLOGDB ")
            sql.Append("SET LATEST_OF_DAY_FLG = '0' ") '　前回作成データを古いと判別できるようにフラグ変える
            sql.Append("WHERE 1=1 ")
            sql.Append("    AND EXEC_KBN  = '" & pstrEXEC_KBN & "' ")
            sql.Append("    AND INPUT_YMD = '" & pstrINPUT_YMD & "' ")
            sql.Append("    AND LATEST_OF_DAY_FLG = '1' ")
            If pstrAUTO_KBN = "1" Then
                sql.Append("    AND AUTO_FAXNO = '" & pstrAUTO_FAXNO & "' ")
            Else
                sql.Append("    AND AUTO_MAIL = '" & pstrAUTO_MAIL & "' ")
            End If

            cdb.mBeginTrans() 'トランザクション開始
            cdb.pSQL = sql.ToString '//SQLセット
            cdb.mExecNonQuery() '//SQL実行
            cdb.mCommit() 'トランザクション終了(コミット)
        Catch ex As Exception
            cdb.mRollback() 'トランザクション終了(ロールバック)
            'エラーの内容とＳＱＬ文を返す
            Return "ERROR:" & ex.ToString & vbCrLf & vbCrLf & Environment.StackTrace & vbCrLf & " 直前のSQL[" & sql.ToString & "]"
        Finally
        End Try

        Return "OK"

    End Function


End Class
