'***************************************************************************
'  監視対応数集計表
'***************************************************************************
' 変更履歴
' 2008/11/21 T.Watabe 新規作成
' 2009/02/17 T.Watabe 出動件数は、復帰対応状況＝８：緊急出動（出動会社）を対象とするように変更
' 2010/03/09 T.Watabe 対応区分＝重複を帳票に含むor含まないの条件を追加
' 2010/03/10 T.Watabe 表示項目を追加
' 2019/11/01 W.GANEKO JA名称で削除フラグ≠1のデータのみ表示


Option Explicit On 
Option Strict On

Imports Common
Imports Common.DB

Imports System.Web.Services
Imports System.Text
Imports System.Text.RegularExpressions

<System.Web.Services.WebService(Namespace:="http://tempuri.org/KEKANSYW00/Service1")> _
Public Class KEKANSYW00
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
    '2017/02/16 H.Mori mod 改善2016 No8-2 引数変更
    '2015/02/04 H.Hosoda mod 監視改善2014 №14 引数変更
    '2020/11/01 T.Ono mod   監視改善2020　引数変更 pstrTSADCD 追加
    '<WebMethod()> Public Function mCheck( _
    '                                    ByVal pstrKuracd As String, _
    '                                    ByVal pstrJacd As String, _
    '                                    ByVal pstrTrgFrom As String, _
    '                                    ByVal pstrTrgTo As String, _
    '                                    ByVal pdecPageMax As Decimal _
    '                                    ) As String
    '<WebMethod()> Public Function mCheck( _
    '                                    ByVal pstrKuracdFrom As String, _
    '                                    ByVal pstrKuracdTo As String, _
    '                                    ByVal pstrJacdFrom As String, _
    '                                    ByVal pstrJacdTo As String, _
    '                                    ByVal pstrHangrpFrom As String, _
    '                                    ByVal pstrHangrpTo As String, _
    '                                    ByVal pstrPgkbn As String, _
    '                                    ByVal pstrHasseiTel As String, _
    '                                    ByVal pstrHasseiKei As String, _
    '                                    ByVal pstrTaiouTel As String, _
    '                                    ByVal pstrTaiouShu As String, _
    '                                    ByVal pstrTaiouJuf As String, _
    '                                    ByVal pstrTrgFrom As String, _
    '                                    ByVal pstrTrgTo As String, _
    '                                    ByVal pstrTrgdatekbn As String, _
    '                                    ByVal pdecPageMax As Decimal _
    '                                    ) As String
    <WebMethod()> Public Function mCheck(
                                        ByVal pstrKuracdFrom As String,
                                        ByVal pstrKuracdTo As String,
                                        ByVal pstrJacdFrom As String,
                                        ByVal pstrJacdTo As String,
                                        ByVal pstrHangrpFrom As String,
                                        ByVal pstrHangrpTo As String,
                                        ByVal pstrPgkbn As String,
                                        ByVal pstrHasseiTel As String,
                                        ByVal pstrHasseiKei As String,
                                        ByVal pstrTaiouTel As String,
                                        ByVal pstrTaiouShu As String,
                                        ByVal pstrTaiouJuf As String,
                                        ByVal pstrTrgFrom As String,
                                        ByVal pstrTrgTo As String,
                                        ByVal pstrTrgdatekbn As String,
                                        ByVal pdecPageMax As Decimal,
                                        ByVal pstrTrgTimeFrom As String,
                                        ByVal pstrTrgTimeTo As String,
                                        ByVal pstrTsadcd As String
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
            '2017/02/16 H.Mori mod 改善2016 No8-2 START
            '2015/02/04 H.Hosoda mod 監視改善2014 №14 Start
            '2020/11/01 T.Ono mod 監視改善2020 pstrTsadcd 追加
            'cdb.pSQL = fncMakeSelect(2, _
            '                         pstrKuracd, _
            '                         pstrJacd, _
            '                         pstrTrgFrom, _
            '                         pstrTrgTo, _
            '                         "", _
            '                         "", _
            '                         pdecPageMax)

            'cdb.pSQL = fncMakeSelect(2, _
            '                          pstrKuracdFrom, _
            '                          pstrKuracdTo, _
            '                          pstrJacdFrom, _
            '                          pstrJacdTo, _
            '                          pstrHangrpFrom, _
            '                          pstrHangrpTo, _
            '                          pstrTrgFrom, _
            '                          pstrTrgTo, _
            '                          pstrPgkbn, _
            '                          pstrHasseiTel, _
            '                          pstrHasseiKei, _
            '                          pstrTaiouTel, _
            '                          pstrTaiouShu, _
            '                          pstrTaiouJuf, _
            '                          pstrTrgdatekbn, _
            '                          pdecPageMax)
            '2015/02/04 H.Hosoda mod 監視改善2014 №14 End
            cdb.pSQL = fncMakeSelect(2,
                                      pstrKuracdFrom,
                                      pstrKuracdTo,
                                      pstrJacdFrom,
                                      pstrJacdTo,
                                      pstrHangrpFrom,
                                      pstrHangrpTo,
                                      pstrTrgFrom,
                                      pstrTrgTo,
                                      pstrPgkbn,
                                      pstrHasseiTel,
                                      pstrHasseiKei,
                                      pstrTaiouTel,
                                      pstrTaiouShu,
                                      pstrTaiouJuf,
                                      pstrTrgdatekbn,
                                      pdecPageMax,
                                      pstrTrgTimeFrom,
                                      pstrTrgTimeTo,
                                      pstrTsadcd)
            '2017/02/16 H.Mori mod 改善2016 No8-2 END

            'パラメータセット
            '2015/02/10 H.Hosoda mod 監視改善2014 №14 Start
            'If pstrKuracd.Length <> 0 Then
            '    cdb.pSQLParamStr("KURACD") = pstrKuracd
            'End If
            'If pstrJacd.Length > 0 Then cdb.pSQLParamStr("JACD") = pstrJacd
            'If pstrTrgFrom.Length > 0 Then cdb.pSQLParamStr("TRGDATE_FROM") = pstrTrgFrom
            'If pstrTrgTo.Length > 0 Then cdb.pSQLParamStr("TRGDATE_TO") = pstrTrgTo
            'クライアントコード
            If pstrKuracdFrom <> "" Then
                cdb.pSQLParamStr("KURACD_FROM") = pstrKuracdFrom
            End If
            If pstrKuracdTo <> "" Then
                cdb.pSQLParamStr("KURACD_TO") = pstrKuracdTo
            End If
            'ＪＡコード ' @
            If pstrJacdFrom <> "" Then
                cdb.pSQLParamStr("JACD_FROM") = pstrJacdFrom
            End If
            If pstrJacdTo <> "" Then
                cdb.pSQLParamStr("JACD_TO") = pstrJacdTo
            End If
            '販売事業者グループコード
            If pstrHangrpFrom <> "" Then
                cdb.pSQLParamStr("HANGRP_FROM") = pstrHangrpFrom
            End If
            If pstrHangrpTo <> "" Then
                cdb.pSQLParamStr("HANGRP_TO") = pstrHangrpTo
            End If
            '対応完了日または受信日
            If pstrTrgFrom <> "" Then
                cdb.pSQLParamStr("TRGDATE_FROM") = pstrTrgFrom
            End If
            If pstrTrgTo <> "" Then
                cdb.pSQLParamStr("TRGDATE_TO") = pstrTrgTo
            End If
            '対応完了時刻または受信時刻　2017/02/16 H.Mori add 改善2016 No8-2 
            If pstrTrgTimeFrom <> "" Then
                cdb.pSQLParamStr("TRGTIME_FROM") = pstrTrgTimeFrom
            End If
            If pstrTrgTimeTo <> "" Then
                cdb.pSQLParamStr("TRGTIME_TO") = pstrTrgTimeTo & "59"
            End If
            '発生区分
            If pstrHasseiTel.Length = 0 And pstrHasseiKei.Length = 0 Then
                '条件なし
            Else
                '条件あり
                If pstrHasseiTel.Length <> 0 And pstrHasseiKei.Length <> 0 Then
                    cdb.pSQLParamStr("HATKBN1") = pstrHasseiTel
                    cdb.pSQLParamStr("HATKBN2") = pstrHasseiKei
                ElseIf pstrHasseiTel.Length <> 0 And pstrHasseiKei.Length = 0 Then
                    cdb.pSQLParamStr("HATKBN1") = pstrHasseiTel
                ElseIf pstrHasseiTel.Length = 0 And pstrHasseiKei.Length <> 0 Then
                    cdb.pSQLParamStr("HATKBN2") = pstrHasseiKei
                Else
                End If
            End If

            '対応区分
            If pstrTaiouTel.Length = 0 And pstrTaiouShu.Length = 0 And pstrTaiouJuf.Length = 0 Then
                '条件なし
            Else
                '条件あり
                '全部入力
                If pstrTaiouTel.Length <> 0 And pstrTaiouShu.Length <> 0 And pstrTaiouJuf.Length <> 0 Then
                    cdb.pSQLParamStr("TAIOKBN1") = pstrTaiouTel
                    cdb.pSQLParamStr("TAIOKBN2") = pstrTaiouShu
                    cdb.pSQLParamStr("TAIOKBN3") = pstrTaiouJuf
                    '一つ入力
                ElseIf pstrTaiouTel.Length <> 0 And pstrTaiouShu.Length = 0 And pstrTaiouJuf.Length = 0 Then
                    cdb.pSQLParamStr("TAIOKBN1") = pstrTaiouTel
                ElseIf pstrTaiouTel.Length = 0 And pstrTaiouShu.Length <> 0 And pstrTaiouJuf.Length = 0 Then
                    cdb.pSQLParamStr("TAIOKBN2") = pstrTaiouShu
                ElseIf pstrTaiouTel.Length = 0 And pstrTaiouShu.Length = 0 And pstrTaiouJuf.Length <> 0 Then
                    cdb.pSQLParamStr("TAIOKBN3") = pstrTaiouJuf
                    '二つ入力
                ElseIf pstrTaiouTel.Length <> 0 And pstrTaiouShu.Length <> 0 And pstrTaiouJuf.Length = 0 Then
                    cdb.pSQLParamStr("TAIOKBN1") = pstrTaiouTel
                    cdb.pSQLParamStr("TAIOKBN2") = pstrTaiouShu
                ElseIf pstrTaiouTel.Length <> 0 And pstrTaiouShu.Length = 0 And pstrTaiouJuf.Length <> 0 Then
                    cdb.pSQLParamStr("TAIOKBN1") = pstrTaiouTel
                    cdb.pSQLParamStr("TAIOKBN3") = pstrTaiouJuf
                ElseIf pstrTaiouTel.Length = 0 And pstrTaiouShu.Length <> 0 And pstrTaiouJuf.Length <> 0 Then
                    cdb.pSQLParamStr("TAIOKBN2") = pstrTaiouShu
                    cdb.pSQLParamStr("TAIOKBN3") = pstrTaiouJuf
                Else
                End If
            End If
            '2015/02/10 H.Hosoda mod 監視改善2014 №14 End

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
    '2015/02/04 H.Hosoda mod 監視改善2014 №14 引数変更
    '<WebMethod()> Public Function mExcel( _
    '                                    ByVal pstrSessionID As String, _
    '                                    ByVal pstrKuracd As String, _
    '                                    ByVal pstrJacd As String, _
    '                                    ByVal pstrPgkbn As String, _
    '                                    ByVal pstrTaiouChofuku As String, _
    '                                    ByVal pstrTrgFrom As String, _
    '                                    ByVal pstrTrgTo As String, _
    '                                    ByVal pstrKuraNm As String, _
    '                                    ByVal pstrJaNm As String, _
    '                                    ByVal pdecPageMax As Decimal, _
    '                                    ByVal pstrCentcd As String _
    '                                    ) As String
    '2017/02/15 H.Mori mod 改善2016 No8-2 START
    '<WebMethod()> Public Function mExcel( _
    '                                    ByVal pstrSessionID As String, _
    '                                    ByVal pstrKuracdFrom As String, _
    '                                    ByVal pstrKuracdTo As String, _
    '                                    ByVal pstrJacdFrom As String, _
    '                                    ByVal pstrJacdTo As String, _
    '                                    ByVal pstrHangrpFrom As String, _
    '                                    ByVal pstrHangrpTo As String, _
    '                                    ByVal pstrPgkbn As String, _
    '                                    ByVal pstrHasseiTel As String, _
    '                                    ByVal pstrHasseiKei As String, _
    '                                    ByVal pstrTaiouTel As String, _
    '                                    ByVal pstrTaiouShu As String, _
    '                                    ByVal pstrTaiouJuf As String, _
    '                                    ByVal pstrTrgFrom As String, _
    '                                    ByVal pstrTrgTo As String, _
    '                                    ByVal pstrTrgdatekbn As String, _
    '                                    ByVal pdecPageMax As Decimal, _
    '                                    ByVal pstrCentcd As String _
    '                                    ) As String
    '2020/11/01 T.Ono mod 監視改善2020 
    'pstrTSADOCD 追加
    <WebMethod()> Public Function mExcel(
                                        ByVal pstrSessionID As String,
                                        ByVal pstrKuracdFrom As String,
                                        ByVal pstrKuracdTo As String,
                                        ByVal pstrJacdFrom As String,
                                        ByVal pstrJacdTo As String,
                                        ByVal pstrHangrpFrom As String,
                                        ByVal pstrHangrpTo As String,
                                        ByVal pstrPgkbn As String,
                                        ByVal pstrHasseiTel As String,
                                        ByVal pstrHasseiKei As String,
                                        ByVal pstrTaiouTel As String,
                                        ByVal pstrTaiouShu As String,
                                        ByVal pstrTaiouJuf As String,
                                        ByVal pstrTrgFrom As String,
                                        ByVal pstrTrgTo As String,
                                        ByVal pstrTrgdatekbn As String,
                                        ByVal pdecPageMax As Decimal,
                                        ByVal pstrCentcd As String,
                                        ByVal pstrTrgTimeFrom As String,
                                        ByVal pstrTrgTimeTo As String,
                                        ByVal pstrTsadcd As String
                                        ) As String
        '2017/02/16 H.Mori mod 改善2016 No8-2 END

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

        Dim strTmp() As String

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
            '2017/02/16 H.Mori mod 改善2016 No8-2 START
            '2015/02/04 H.Hosoda mod 監視改善2014 №14 Start
            'strSQL.Append(fncMakeSelect(2, _
            '                         pstrKuracd, _
            '                         pstrJacd, _
            '                         pstrTrgFrom, _
            '                         pstrTrgTo, _
            '                         pstrPgkbn, _
            '                         pstrTaiouChofuku, _
            '                         pdecPageMax))
            'strSQL.Append(fncMakeSelect(2, _
            '                          pstrKuracdFrom, _
            '                          pstrKuracdTo, _
            '                          pstrJacdFrom, _
            '                          pstrJacdTo, _
            '                          pstrHangrpFrom, _
            '                          pstrHangrpTo, _
            '                          pstrTrgFrom, _
            '                          pstrTrgTo, _
            '                          pstrPgkbn, _
            '                          pstrHasseiTel, _
            '                          pstrHasseiKei, _
            '                          pstrTaiouTel, _
            '                          pstrTaiouShu, _
            '                          pstrTaiouJuf, _
            '                          pstrTrgdatekbn, _
            '                          pdecPageMax))
            '2015/02/04 H.Hosoda mod 監視改善2014 №14 End
            '2020/11/01 T.Ono mod 監視改善2020
            'pstrTsadcd 追加
            strSQL.Append(fncMakeSelect(2,
                                      pstrKuracdFrom,
                                      pstrKuracdTo,
                                      pstrJacdFrom,
                                      pstrJacdTo,
                                      pstrHangrpFrom,
                                      pstrHangrpTo,
                                      pstrTrgFrom,
                                      pstrTrgTo,
                                      pstrPgkbn,
                                      pstrHasseiTel,
                                      pstrHasseiKei,
                                      pstrTaiouTel,
                                      pstrTaiouShu,
                                      pstrTaiouJuf,
                                      pstrTrgdatekbn,
                                      pdecPageMax,
                                      pstrTrgTimeFrom,
                                      pstrTrgTimeTo,
                                      pstrTsadcd))
            '2017/02/16 H.Mori mod 改善2016 No8-2 END

            cdb.pSQL = strSQL.ToString 'SQLをセット

            '2015/02/10 H.Hosoda add 監視改善2014 №14 Start
            'パラメータセット
            'クライアントコード
            If pstrKuracdFrom <> "" Then
                cdb.pSQLParamStr("KURACD_FROM") = pstrKuracdFrom
            End If
            If pstrKuracdTo <> "" Then
                cdb.pSQLParamStr("KURACD_TO") = pstrKuracdTo
            End If
            'ＪＡコード ' @
            If pstrJacdFrom <> "" Then
                cdb.pSQLParamStr("JACD_FROM") = pstrJacdFrom
            End If
            If pstrJacdTo <> "" Then
                cdb.pSQLParamStr("JACD_TO") = pstrJacdTo
            End If
            '販売事業者グループコード
            If pstrHangrpFrom <> "" Then
                cdb.pSQLParamStr("HANGRP_FROM") = pstrHangrpFrom
            End If
            If pstrHangrpTo <> "" Then
                cdb.pSQLParamStr("HANGRP_TO") = pstrHangrpTo
            End If
            '対応完了日または受信日
            If pstrTrgFrom <> "" Then
                cdb.pSQLParamStr("TRGDATE_FROM") = pstrTrgFrom
            End If
            If pstrTrgTo <> "" Then
                cdb.pSQLParamStr("TRGDATE_TO") = pstrTrgTo
            End If
            '対応完了時刻または受信時刻　2017/02/15 H.Mori add 改善2016 No8-2 
            If pstrTrgTimeFrom <> "" Then
                cdb.pSQLParamStr("TRGTIME_FROM") = pstrTrgTimeFrom
            End If
            If pstrTrgTimeTo <> "" Then
                cdb.pSQLParamStr("TRGTIME_TO") = pstrTrgTimeTo & "59"
            End If
            '発生区分
            If pstrHasseiTel.Length = 0 And pstrHasseiKei.Length = 0 Then
                '条件なし
            Else
                '条件あり
                If pstrHasseiTel.Length <> 0 And pstrHasseiKei.Length <> 0 Then
                    cdb.pSQLParamStr("HATKBN1") = pstrHasseiTel
                    cdb.pSQLParamStr("HATKBN2") = pstrHasseiKei
                ElseIf pstrHasseiTel.Length <> 0 And pstrHasseiKei.Length = 0 Then
                    cdb.pSQLParamStr("HATKBN1") = pstrHasseiTel
                ElseIf pstrHasseiTel.Length = 0 And pstrHasseiKei.Length <> 0 Then
                    cdb.pSQLParamStr("HATKBN2") = pstrHasseiKei
                Else
                End If
            End If

            '対応区分
            If pstrTaiouTel.Length = 0 And pstrTaiouShu.Length = 0 And pstrTaiouJuf.Length = 0 Then
                '条件なし
            Else
                '条件あり
                '全部入力
                If pstrTaiouTel.Length <> 0 And pstrTaiouShu.Length <> 0 And pstrTaiouJuf.Length <> 0 Then
                    cdb.pSQLParamStr("TAIOKBN1") = pstrTaiouTel
                    cdb.pSQLParamStr("TAIOKBN2") = pstrTaiouShu
                    cdb.pSQLParamStr("TAIOKBN3") = pstrTaiouJuf
                    '一つ入力
                ElseIf pstrTaiouTel.Length <> 0 And pstrTaiouShu.Length = 0 And pstrTaiouJuf.Length = 0 Then
                    cdb.pSQLParamStr("TAIOKBN1") = pstrTaiouTel
                ElseIf pstrTaiouTel.Length = 0 And pstrTaiouShu.Length <> 0 And pstrTaiouJuf.Length = 0 Then
                    cdb.pSQLParamStr("TAIOKBN2") = pstrTaiouShu
                ElseIf pstrTaiouTel.Length = 0 And pstrTaiouShu.Length = 0 And pstrTaiouJuf.Length <> 0 Then
                    cdb.pSQLParamStr("TAIOKBN3") = pstrTaiouJuf
                    '二つ入力
                ElseIf pstrTaiouTel.Length <> 0 And pstrTaiouShu.Length <> 0 And pstrTaiouJuf.Length = 0 Then
                    cdb.pSQLParamStr("TAIOKBN1") = pstrTaiouTel
                    cdb.pSQLParamStr("TAIOKBN2") = pstrTaiouShu
                ElseIf pstrTaiouTel.Length <> 0 And pstrTaiouShu.Length = 0 And pstrTaiouJuf.Length <> 0 Then
                    cdb.pSQLParamStr("TAIOKBN1") = pstrTaiouTel
                    cdb.pSQLParamStr("TAIOKBN3") = pstrTaiouJuf
                ElseIf pstrTaiouTel.Length = 0 And pstrTaiouShu.Length <> 0 And pstrTaiouJuf.Length <> 0 Then
                    cdb.pSQLParamStr("TAIOKBN2") = pstrTaiouShu
                    cdb.pSQLParamStr("TAIOKBN3") = pstrTaiouJuf
                Else
                End If
            End If
            '2015/02/10 H.Hosoda add 監視改善2014 №14 End

            cdb.mExecQuery()    'SQL実行
            ds = cdb.pResult    '結果をデータセットに格納

            'データが存在しない場合
            If ds.Tables(0).Rows.Count = 0 Then
                Return "DATA0"      'データが0件であることを示す文字列を返す
            ElseIf ds.Tables(0).Rows.Count > intGyoMax Then
                Return "DATAMAX"    'データが最大行数を超える事を示す文字列を返す
            End If

            dr = ds.Tables(0).Rows(0)           'データローにデータセットを格納
            ExcelC.pKencd = "00"                '県コードをセット
            ExcelC.pSessionID = pstrSessionID   'セッションID
            ExcelC.pRepoID = "KEKANSYW00"       '帳票ID
            ExcelC.mOpen()                      'ファイルオープン

            ExcelC.pTitle = "監視対応数集計表"                        'タイトル
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

            'ヘッダ項目をセット。（1ページあたり行数、出力行数、先頭行から何行目までが行タイトルか）
            ExcelC.mHeader(65000, ds.Tables(0).Rows.Count, 3)

            '-----------------------
            ' エクセル項目情報
            '-----------------------
            Dim arrColNM1(27) As String
            Dim arrColNM2(27) As String
            Dim arrColID(27) As String
            Dim arrWidth(27) As String '幅 項目1～28
            Dim arrHeadBGColor(27) As String
            Dim arrLetters() As String = {"0", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB"}
            Dim zoku As String
            Dim buf As String

            Dim i As Integer
            If True Then
                '2017/02/17 H.Mori add 改善2016 No8-1 START
                'arrColNM1(1) = "クライアント"
                If pstrPgkbn = "6" Then
                    arrColNM1(1) = "県"
                Else
                    arrColNM1(1) = "クライアント"
                End If
                '2017/02/17 H.Mori add 改善2016 No8-1 END
                arrColNM1(2) = ""

                If pstrPgkbn = "2" Then
                    arrColNM1(3) = "ＪＡ"
                    '2015/02/04 H.Hosoda mod 監視改善2014 №14 Start
                    'Else
                    '2017/02/23 H.Mori mod 改善2016 No8-1 販売事業者支所単位の削除
                    'ElseIf pstrPgkbn = "3" Or pstrPgkbn = "5" Then
                ElseIf pstrPgkbn = "3" Then
                    arrColNM1(3) = "ＪＡ支所"
                ElseIf pstrPgkbn = "4" Then
                    arrColNM1(3) = "販売事業者"
                    '2015/02/04 H.Hosoda mod 監視改善2014 №14 End
                    '2017/02/17 H.Mori add 改善2016 No8-1 START
                ElseIf pstrPgkbn = "7" Then
                    arrColNM1(3) = "販売所"
                    '2017/02/17 H.Mori add 改善2016 No8-1 END
                End If

                arrColNM2(4) = ""
                arrColNM1(5) = "セキュリティ"
                '2015/02/13 H.Hosoda mod 監視改善2014 №14 Start
                'arrColNM2(5) = "オーバー予告"
                'arrColNM2(6) = "使用オーバー"
                'arrColNM2(7) = "警報器遮断"
                'arrColNM2(8) = "圧力遮断"
                'arrColNM2(9) = "流量オーバー"
                arrColNM2(5) = "使用時間オーバ予告"
                arrColNM2(6) = "使用時間オーバ遮断"
                arrColNM2(7) = "ガス警報器遮断"
                arrColNM2(8) = "圧力センサ遮断"
                arrColNM2(9) = "最大流量オーバ遮断"
                '2015/02/13 H.Hosoda mod 監視改善2014 №14 End
                arrColNM2(10) = "遮断弁異常"
                '2017/11/01 H.Mori mod 2017改善開発 No8-1 START 
                ''2015/02/13 H.Hosoda mod 監視改善2014 №14 Start
                ''arrColNM2(11) = "警報器作動"
                ''arrColNM2(12) = "外部センサー"
                'arrColNM2(11) = "ガス警報器作動"
                'arrColNM2(12) = "外部１センサ遮断"
                ''2015/02/13 H.Hosoda mod 監視改善2014 №14 End
                'arrColNM2(13) = "感震器遮断"
                ''2015/02/13 H.Hosoda mod 監視改善2014 №14 Start
                ''arrColNM2(14) = "安全確認中"
                'arrColNM2(14) = "安全確認中遮断"
                ''2015/02/13 H.Hosoda mod 監視改善2014 №14 End
                'arrColNM2(15) = "微少漏洩(流)"
                'arrColNM2(16) = "微少漏洩(圧)"
                'arrColNM2(17) = "その他"
                'arrColNM2(18) = "管理情報１"
                'arrColNM2(19) = "管理情報２"
                arrColNM2(11) = "ガス警報器作動"
                arrColNM2(12) = "感震器遮断"
                arrColNM2(13) = "安全確認中遮断"
                arrColNM2(14) = "微少漏洩(流)"
                arrColNM2(15) = "微少漏洩(圧)"
                arrColNM2(16) = "その他１"
                arrColNM2(17) = "その他２"
                arrColNM2(18) = "管理情報１"
                arrColNM2(19) = "管理情報２"
                '2017/11/01 H.Mori mod 2017改善開発 No8-1 END 
                arrColNM2(20) = "合計 "
                arrColNM2(21) = "内出動"
                arrColNM2(22) = "合計"
                arrColNM2(23) = "内出動"
                arrColNM2(24) = "合計"
                arrColNM2(25) = "内出動"
                arrColNM2(26) = "県"
                If pstrPgkbn = "2" Then
                    arrColNM2(27) = "JA"
                    '2015/02/04 H.Hosoda mod 監視改善2014 №14 Start
                    'Else
                    '2017/02/23 H.Mori mod 改善2016 No8-1 販売事業者支所単位の削除
                    'ElseIf pstrPgkbn = "3" Or pstrPgkbn = "5" Then
                ElseIf pstrPgkbn = "3" Then
                    arrColNM2(27) = "JA支所"
                ElseIf pstrPgkbn = "4" Then
                    arrColNM2(27) = "販売事業者"
                    '2015/02/04 H.Hosoda mod 監視改善2014 №14 End
                    '2017/02/17 H.Mori add 改善2016 No8-1 START
                ElseIf pstrPgkbn = "7" Then
                    arrColNM2(27) = "販売所"
                    '2017/02/17 H.Mori add 改善2016 No8-1 END
                End If
            End If
            If True Then
                arrColID(1) = "KURACD"
                arrColID(2) = "KURANM"
                arrColID(3) = "JACD"
                arrColID(4) = "JANM"
                arrColID(5) = "C01"
                arrColID(6) = "C02"
                arrColID(7) = "C03"
                arrColID(8) = "C04"
                arrColID(9) = "C05"
                arrColID(10) = "C06"
                arrColID(11) = "C07"
                arrColID(12) = "C08"
                arrColID(13) = "C09"
                arrColID(14) = "C10"
                arrColID(15) = "C11"
                arrColID(16) = "C12"
                arrColID(17) = "C13"
                arrColID(18) = "C14"
                arrColID(19) = "C15"
                arrColID(20) = "C16"
                arrColID(21) = "C20"
                arrColID(22) = "C17"
                arrColID(23) = "C21"
                arrColID(24) = "C18"
                arrColID(25) = "C19"
                arrColID(26) = "KENNM"
                arrColID(27) = "JACD"
            End If
            If True Then '幅
                arrWidth(1) = "31"
                arrWidth(2) = "133"
                arrWidth(3) = "53"
                arrWidth(4) = "133"
                arrWidth(5) = "66"
                arrWidth(6) = "66"
                arrWidth(7) = "66"
                arrWidth(8) = "66"
                arrWidth(9) = "66"
                arrWidth(10) = "66"
                arrWidth(11) = "66"
                arrWidth(12) = "66"
                arrWidth(13) = "66"
                arrWidth(14) = "66"
                arrWidth(15) = "66"
                arrWidth(16) = "66"
                arrWidth(17) = "66"
                arrWidth(18) = "66"
                arrWidth(19) = "66"
                arrWidth(20) = "66"
                arrWidth(21) = "66"
                arrWidth(22) = "54"
                arrWidth(23) = "54"
                arrWidth(24) = "66"
                arrWidth(25) = "66"
                arrWidth(26) = "41"
                arrWidth(27) = "51"
            End If
            If True Then
                arrHeadBGColor(1) = "background:#99CCFF;" '青
                arrHeadBGColor(2) = "background:#99CCFF;" '青
                arrHeadBGColor(3) = "background:#99CCFF;" '青
                arrHeadBGColor(4) = "background:#99CCFF;" '青
                arrHeadBGColor(5) = "background:#CCFFCC;" '黄緑
                arrHeadBGColor(6) = "background:#CCFFCC;" '黄緑
                arrHeadBGColor(7) = "background:#CCFFCC;" '黄緑
                arrHeadBGColor(8) = "background:#CCFFCC;" '黄緑
                arrHeadBGColor(9) = "background:#CCFFCC;" '黄緑
                arrHeadBGColor(10) = "background:#CCFFCC;" '黄緑
                arrHeadBGColor(11) = "background:#CCFFCC;" '黄緑
                arrHeadBGColor(12) = "background:#CCFFCC;" '黄緑
                arrHeadBGColor(13) = "background:#CCFFCC;" '黄緑
                arrHeadBGColor(14) = "background:#CCFFCC;" '黄緑
                arrHeadBGColor(15) = "background:#CCFFCC;" '黄緑
                arrHeadBGColor(16) = "background:#CCFFCC;" '黄緑
                arrHeadBGColor(17) = "background:#CCFFCC;" '黄緑
                arrHeadBGColor(18) = "background:#CCFFCC;" '黄緑
                'arrHeadBGColor(19) = "background:#CCFFCC;" '黄緑
                arrHeadBGColor(19) = "background:#CCFFCC;color:#FF0000;" '黄緑 '2017/11/17 H.Mori mod 2017改善開発 No8-1
                arrHeadBGColor(20) = "background:#CCFFCC;" '黄緑
                arrHeadBGColor(21) = "background:#CCFFCC;" '黄緑
                arrHeadBGColor(22) = "background:#CCFFFF;" '水色
                arrHeadBGColor(23) = "background:#CCFFFF;" '水色
                arrHeadBGColor(24) = "background:#FFFF99;" '黄色
                'arrHeadBGColor(25) = "background:#FFCC99;" '橙
                arrHeadBGColor(25) = "background:#FFFF99;" '黄色
                arrHeadBGColor(26) = "background:#99CCFF;" '青
                arrHeadBGColor(27) = "background:#99CCFF;" '青
            End If


            '■ヘッダ行1
            If True Then
                '2015/03/16 T.Ono add 2014改善開発 追加要望 指定条件を出力 START
                'Dim sDateFT As String
                'If Len(pstrTrgFrom) > 0 Or Len(pstrTrgTo) > 0 Then
                '    sDateFT = DateFncC.mGet(pstrTrgFrom) & "～" & DateFncC.mGet(pstrTrgTo)
                'End If
                'For i = 1 To 27
                '    ExcelC.pCellStyle(i) = "height:26px;text-align:left;font-size:13px;border-style:none;"
                'Next
                'ExcelC.pCellVal(1) = ""
                'ExcelC.pCellVal(2) = ""
                'ExcelC.pCellVal(3, "colspan=9") = Convert.ToString("対象期間:" & sDateFT)
                'ExcelC.mWriteLine("")       '行をファイルに書き込む
                Dim sDateFT As String = ""
                Dim sKuraFT As String = ""
                Dim sJaFT As String = ""
                Dim sHangrpJI As String = ""
                Dim sPgkbn As String = ""
                Dim sHasseikbn As String = ""
                Dim sTaioukbn As String = ""
                Dim sTrgdatekbn As String = ""
                '2017/02/16 H.Mori add 改善2016 No8-2 時刻追加 START
                'If Len(pstrTrgFrom) > 0 OrElse Len(pstrTrgTo) > 0 Then
                '    sDateFT = "対象期間:" & DateFncC.mGet(pstrTrgFrom) & "～" & DateFncC.mGet(pstrTrgTo)
                'End If
                If Len(pstrTrgTimeFrom) = 0 OrElse Len(pstrTrgTimeFrom) = 0 Then
                    sDateFT = "対象期間:" & DateFncC.mGet(pstrTrgFrom) & "～" & DateFncC.mGet(pstrTrgTo)
                Else
                    sDateFT = "対象期間:" & DateFncC.mGet(pstrTrgFrom) & " " & CTimeFncC.mGet(pstrTrgTimeFrom, 0) & "～" & DateFncC.mGet(pstrTrgTo) & " " & CTimeFncC.mGet(pstrTrgTimeTo, 0)
                End If
                '2017/02/16 H.Mori add 改善2016 No8-2 時刻追加 START
                If pstrTrgdatekbn = "1" Then
                    sDateFT += "・対応完了日"
                Else
                    sDateFT += "・受信日"
                End If
                If Len(pstrKuracdFrom) > 0 OrElse Len(pstrKuracdTo) > 0 Then
                    sKuraFT = "、ｸﾗｲｱﾝﾄ：" & pstrKuracdFrom & "～" & pstrKuracdTo
                End If
                If Len(pstrJacdFrom) > 0 OrElse Len(pstrJacdTo) > 0 Then
                    sJaFT = "、JA:" & pstrJacdFrom & "～" & pstrJacdTo
                End If
                If Len(pstrHangrpFrom) > 0 OrElse Len(pstrHangrpTo) > 0 Then
                    sHangrpJI = "、販売事業者:" & pstrHangrpFrom & "～" & pstrHangrpTo
                End If
                If pstrPgkbn = "1" Then
                    sPgkbn = "、集計条件：ｸﾗｲｱﾝﾄ単位"
                ElseIf pstrPgkbn = "2" Then
                    sPgkbn = "、集計条件：JA単位"
                ElseIf pstrPgkbn = "3" Then
                    sPgkbn = "、集計条件：JA支所単位"
                ElseIf pstrPgkbn = "4" Then
                    sPgkbn = "、集計条件：販売事業者単位"
                    '2017/02/17 H.Mori mod 改善2016 No8-1 START
                    'ElseIf pstrPgkbn = "5" Then
                    '    sPgkbn = "、集計条件：販売事業者支所単位"
                    'End If
                ElseIf pstrPgkbn = "6" Then
                    sPgkbn = "、集計条件：県単位"
                ElseIf pstrPgkbn = "7" Then
                    sPgkbn = "、集計条件：販売所単位"
                End If
                '2017/02/17 H.Mori mod 改善2016 No8-1 END
                If Len(pstrHasseiTel) > 0 And Len(pstrHasseiKei) > 0 Then
                    sHasseikbn = "、発生区分：電話・警報"
                ElseIf Len(pstrHasseiTel) > 0 Then
                    sHasseikbn = "、発生区分：電話"
                ElseIf Len(pstrHasseiKei) > 0 Then
                    sHasseikbn = "、発生区分：警報"
                End If
                If Len(pstrTaiouTel) > 0 And Len(pstrTaiouShu) > 0 And Len(pstrTaiouJuf) > 0 Then
                    sTaioukbn = "、対応区分：電話・出動・重複"
                ElseIf Len(pstrTaiouTel) > 0 And Len(pstrTaiouShu) > 0 Then
                    sTaioukbn = "、対応区分：電話・出動"
                ElseIf Len(pstrTaiouTel) > 0 And Len(pstrTaiouJuf) > 0 Then
                    sTaioukbn = "、対応区分：電話・重複"
                ElseIf Len(pstrTaiouShu) > 0 And Len(pstrTaiouJuf) > 0 Then
                    sTaioukbn = "、対応区分：出動・重複"
                ElseIf Len(pstrTaiouTel) > 0 Then
                    sTaioukbn = "、対応区分：電話"
                ElseIf Len(pstrTaiouShu) > 0 Then
                    sTaioukbn = "、対応区分：出動"
                ElseIf Len(pstrTaiouJuf) > 0 Then
                    sTaioukbn = "、対応区分：重複"
                Else
                End If

                '2020/11/01 T.Ono add 2020監視改善
                If pstrTsadcd = "1" Then
                    sTaioukbn = "、作動原因：工事・交換など(63) 含む"
                Else
                    sTaioukbn = "、作動原因：工事・交換など(63) 含まない"
                End If

                For i = 1 To 27
                    ExcelC.pCellStyle(i) = "height:26px;text-align:left;font-size:13px;border-style:none;"
                Next
                ExcelC.pCellVal(1) = ""
                ExcelC.pCellVal(2) = ""
                ExcelC.pCellVal(3, "colspan=22") = Convert.ToString(sDateFT & sKuraFT & sJaFT & sHangrpJI & sPgkbn & sHasseikbn & sTaioukbn)
                ExcelC.mWriteLine("")       '行をファイルに書き込む
                '2015/03/16 T.Ono add 2014改善開発 追加要望 指定条件を出力 END
            End If

            '■ヘッダ行2
            If True Then
                For i = 1 To 27
                    '2017/02/17 H.Mori mod 改善2016 No8-1 START
                    'If pstrPgkbn = "1" And (i = 3 Or i = 4 Or i = 27) Then '1:クライアントは、ＪＡ項目をスキップ
                    If (pstrPgkbn = "1" Or pstrPgkbn = "6") And (i = 3 Or i = 4 Or i = 27) Then '1:クライアント、県名は、ＪＡ項目をスキップ
                        '2017/02/17 H.Mori mod 改善2016 No8-1 END
                        'スキップ
                    Else
                        'ExcelC.pCellStyle(i) = "height:26px;text-align:center;font-size:9px;border-style:solid;background-color:lightgrey;" & arrHeadBGColor(i)
                        ExcelC.pCellStyle(i) = "height:26px;text-align:center;font-size:9px;border-style:solid;" & arrHeadBGColor(i)
                    End If
                Next
                '2017/02/17 H.Mori mod 改善2016 No8-1 START　
                'ExcelC.pCellVal(1, "colspan=2 rowspan=2") = Convert.ToString("クライアント")
                'If pstrPgkbn = "1" Then
                'スキップ
                If pstrPgkbn = "6" Then
                    ExcelC.pCellVal(1, "colspan=2 rowspan=2") = Convert.ToString("県")
                Else
                    ExcelC.pCellVal(1, "colspan=2 rowspan=2") = Convert.ToString("クライアント")
                End If
                If pstrPgkbn = "1" Or pstrPgkbn = "6" Then
                    'スキップ
                    '2017/02/17 H.Mori mod 改善2016 No8-1 END
                ElseIf pstrPgkbn = "2" Then
                    ExcelC.pCellVal(3, "colspan=2 rowspan=2") = Convert.ToString("ＪＡ")
                    '2015/02/04 H.Hosoda mod 監視改善2014 №14 Start
                    'Else
                    '2017/02/23 H.Mori mod 改善2016 No8-1 販売事業者支所単位の削除
                    'ElseIf pstrPgkbn = "3" Or pstrPgkbn = "5" Then
                ElseIf pstrPgkbn = "3" Then
                    ExcelC.pCellVal(3, "colspan=2 rowspan=2") = Convert.ToString("ＪＡ支所")
                ElseIf pstrPgkbn = "4" Then
                    ExcelC.pCellVal(3, "colspan=2 rowspan=2") = Convert.ToString("販売事業者")
                    '2015/02/04 H.Hosoda mod 監視改善2014 №14 End
                    '2017/02/17 H.Mori mod 改善2016 No8-1 START
                ElseIf pstrPgkbn = "7" Then
                    ExcelC.pCellVal(3, "colspan=2 rowspan=2") = Convert.ToString("販売所")
                    '2017/02/17 H.Mori mod 改善2016 No8-1 END
                End If
                ExcelC.pCellVal(5, "colspan=17") = "警    報"
                ExcelC.pCellVal(22, "colspan=2") = "電話"
                'ExcelC.pCellStyle(22) = "height:26px;width:" & arrWidth(22) & "px;text-align:center;font-size:9px;border-style:solid;" & arrHeadBGColor(22)
                ExcelC.pCellStyle(22) = "height:26px;width:" & arrWidth(22) & "px;text-align:center;font-size:9px;border-style:solid;" & arrHeadBGColor(22)
                ExcelC.pCellVal(24, "colspan=2") = "対応件数総合計 "
                'ExcelC.pCellStyle(24) = "height:26px;width:" & arrWidth(24) & "px;text-align:center;font-size:9px;border-style:solid;" & arrHeadBGColor(24)
                ExcelC.pCellStyle(24) = "height:26px;width:" & arrWidth(24) & "px;text-align:center;font-size:9px;border-style:solid;" & arrHeadBGColor(24)
                ExcelC.pCellVal(26, "rowspan=2") = "県"
                '2017/02/17 H.Mori mod 改善2016 No8-1 START　
                'If pstrPgkbn = "1" Then
                If pstrPgkbn = "1" Or pstrPgkbn = "6" Then
                    '2017/02/17 H.Mori mod 改善2016 No8-1 END
                    '　
                ElseIf pstrPgkbn = "2" Then
                    ExcelC.pCellVal(27, "rowspan=2") = Convert.ToString("JA")
                    '2015/02/04 H.Hosoda mod 監視改善2014 №14 Start
                    'Else
                    '2017/02/23 H.Mori mod 改善2016 No8-1 販売事業者支所単位の削除
                    'ElseIf pstrPgkbn = "3" Or pstrPgkbn = "5" Then
                ElseIf pstrPgkbn = "3" Then
                    ExcelC.pCellVal(27, "rowspan=2") = Convert.ToString("JA支所")
                ElseIf pstrPgkbn = "4" Then
                    ExcelC.pCellVal(27, "rowspan=2") = Convert.ToString("販売事業者")
                    '2017/02/17 H.Mori mod 改善2016 No8-1 START
                ElseIf pstrPgkbn = "7" Then
                    ExcelC.pCellVal(27, "rowspan=2") = Convert.ToString("販売所")
                    '2017/02/17 H.Mori mod 改善2016 No8-1 END
                End If
                ExcelC.mWriteLine("")       '行をファイルに書き込む
            End If

            '■ヘッダ行3
            For i = 1 To 27
                '2017/02/17 H.Mori mod 改善2016 No8-1 START
                'If pstrPgkbn = "1" And (i = 3 Or i = 4 Or i = 27) Then '1:クライアントは、ＪＡ項目をスキップ
                If (pstrPgkbn = "1" Or pstrPgkbn = "6") And (i = 3 Or i = 4 Or i = 27) Then '1:クライアントは、ＪＡ項目をスキップ
                    '2017/02/17 H.Mori mod 改善2016 No8-1 END
                    'スキップ
                Else
                    'ExcelC.pCellStyle(i) = "height:26px;text-align:center;font-size:9px;border-style:solid;background-color:lightgrey;" & arrHeadBGColor(i)
                    ExcelC.pCellStyle(i) = "height:26px;text-align:center;font-size:9px;border-style:solid;" & arrHeadBGColor(i)
                End If
            Next

            '2015/02/13 H.Hosoda mod 監視改善2014 №14 Start
            'ExcelC.pCellVal(5) = Convert.ToString("オーバー予告")
            'ExcelC.pCellVal(6) = Convert.ToString("使用オーバー")
            'ExcelC.pCellVal(7) = Convert.ToString("警報器遮断")
            'ExcelC.pCellVal(8) = Convert.ToString("圧力遮断")
            'ExcelC.pCellVal(9) = Convert.ToString("流量オーバー")
            ExcelC.pCellVal(5) = Convert.ToString("使用時間オーバ予告")
            ExcelC.pCellVal(6) = Convert.ToString("使用時間オーバ遮断")
            ExcelC.pCellVal(7) = Convert.ToString("ガス警報器遮断")
            ExcelC.pCellVal(8) = Convert.ToString("圧力センサ遮断")
            ExcelC.pCellVal(9) = Convert.ToString("最大流量オーバ遮断")
            '2015/02/13 H.Hosoda mod 監視改善2014 №14 End
            ExcelC.pCellVal(10) = Convert.ToString("遮断弁異常")

            '2017/11/01 H.Mori mod 2017改善開発 No8-1 START 
            ''2015/02/13 H.Hosoda mod 監視改善2014 №14 Start
            ''ExcelC.pCellVal(11) = Convert.ToString("警報器作動")
            ''ExcelC.pCellVal(12) = Convert.ToString("外部センサー")
            'ExcelC.pCellVal(11) = Convert.ToString("ガス警報器作動")
            'ExcelC.pCellVal(12) = Convert.ToString("外部１センサ遮断")
            ''2015/02/13 H.Hosoda mod 監視改善2014 №14 End
            'ExcelC.pCellVal(13) = Convert.ToString("感震器遮断")
            ''2015/02/13 H.Hosoda mod 監視改善2014 №14 Start
            ''ExcelC.pCellVal(14) = Convert.ToString("安全確認中")
            'ExcelC.pCellVal(14) = Convert.ToString("安全確認中遮断")
            ''2015/02/13 H.Hosoda mod 監視改善2014 №14 End
            'ExcelC.pCellVal(15) = Convert.ToString("微少漏洩(流)")
            'ExcelC.pCellVal(16) = Convert.ToString("微少漏洩(圧)")
            'ExcelC.pCellVal(17) = Convert.ToString("その他")
            'ExcelC.pCellVal(18) = Convert.ToString("管理情報１")
            'ExcelC.pCellVal(19) = Convert.ToString("管理情報２")
            ExcelC.pCellVal(11) = Convert.ToString("ガス警報器作動")
            ExcelC.pCellVal(12) = Convert.ToString("感震器遮断")
            ExcelC.pCellVal(13) = Convert.ToString("安全確認中遮断")
            ExcelC.pCellVal(14) = Convert.ToString("微少漏洩(流)")
            ExcelC.pCellVal(15) = Convert.ToString("微少漏洩(圧)")
            ExcelC.pCellVal(16) = Convert.ToString("その他１")
            ExcelC.pCellVal(17) = Convert.ToString("その他２")
            ExcelC.pCellVal(18) = Convert.ToString("管理情報１")
            ExcelC.pCellVal(19) = Convert.ToString("管理情報２")
            '2017/11/01 H.Mori mod 2017改善開発 No8-1 END 
            ExcelC.pCellVal(20) = Convert.ToString("合計")
            ExcelC.pCellVal(21) = Convert.ToString("内出動")
            ExcelC.pCellVal(22) = Convert.ToString("合計")
            ExcelC.pCellVal(23) = Convert.ToString("内出動")
            ExcelC.pCellVal(24) = Convert.ToString("合計")
            ExcelC.pCellVal(25) = Convert.ToString("内出動")
            ExcelC.mWriteLine("")       '行をファイルに書き込む

            '■明細データ行
            Dim iCnt As Integer
            Dim tmp As String
            Dim col2 As Integer '2017/11/06 H.Mori add 2017改善開発 No8-1
            For iCnt = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(iCnt)
                '2017/11/06 H.Mori mod 2017改善開発 No8-1 START
                If pstrPgkbn = "1" Or pstrPgkbn = "6" Then
                    col2 = 3
                Else
                    col2 = 5
                End If
                '2017/11/06 H.Mori mod 2017改善開発 No8-1 END

                '明細項目
                For i = 1 To 27
                    buf = ""
                    tmp = ""
                    zoku = ""
                    '2017/02/17 H.Mori mod 改善2016 No8-1 START
                    'If pstrPgkbn = "1" And (i = 3 Or i = 4 Or i = 27) Then '1:クライアントは、ＪＡ項目をスキップ
                    If (pstrPgkbn = "1" Or pstrPgkbn = "6") And (i = 3 Or i = 4 Or i = 27) Then '1:クライアントは、ＪＡ項目をスキップ
                        '2017/02/17 H.Mori mod 改善2016 No8-1 END
                        'スキップ
                    Else
                        buf = Convert.ToString(dr.Item(arrColID(i)))
                        tmp = "width:" & arrWidth(i) & "px;"
                        If i >= 5 And i <= 25 Then   '数値項目
                            tmp = "mso-number-format:'\#\,\#\#0';text-align:right;"
                            '2017/11/06 H.Mori mod 2017改善開発 No8-1 START
                            'zoku = "x:num=" & buf
                            If i = 19 Then
                                zoku = "x:num=0 x:fmla='= " & arrLetters(col2 + 15) & iCnt + 4 & "-SUM(" & arrLetters(col2) & iCnt + 4 & ":" & arrLetters(col2 + 13) & iCnt + 4 & ")'" '例 =T4-SUM(E4:R4)"
                            Else
                                zoku = "x:num=" & buf
                            End If
                            '2017/11/06 H.Mori mod 2017改善開発 No8-1 END
                        Else                        '文字項目
                            tmp = "text-align:left;white-space:nowrap;"
                        End If

                        '2017/02/16 H.Mori mod 改善2016 No8-4 START ﾌｫﾝﾄｻｲｽﾞを8→10へ変更
                        'ExcelC.pCellStyle(i) = "height:16px;font-size:11px;border-style:solid;" & tmp
                        If i >= 5 And i <= 25 Then
                            ExcelC.pCellStyle(i) = "height:16px;font-size:13px;border-style:solid;" & tmp '数値項目
                        Else
                            ExcelC.pCellStyle(i) = "height:16px;font-size:11px;border-style:solid;" & tmp '文字項目
                        End If
                        '2017/02/16 H.Mori mod 改善2016 No8-4 END   ﾌｫﾝﾄｻｲｽﾞを8→10へ変更
                        ExcelC.pCellVal(i, zoku) = buf
                    End If
                Next
                ExcelC.mWriteLine("")           '行をファイルに書き込む
            Next


            '■フッタ行（合計）
            Dim col As Integer '出力エクセル上のカラム番号
            tmp = "background:#99CCFF;text-align:right;"
            tmp = tmp & "height:26px;font-size:11px;border-style:solid;" & tmp
            '2017/02/17 H.Mori mod 改善2016 No8-1 START
            'If pstrPgkbn = "1" Then
            If pstrPgkbn = "1" Or pstrPgkbn = "6" Then
                '2017/02/17 H.Mori mod 改善2016 No8-1 END
                buf = "合計"
                zoku = "colspan=2"
                col = 2
                i = 5
            Else
                buf = "合計"
                zoku = "colspan=4"
                col = 4
                i = 5
            End If
            ExcelC.pCellStyle(1) = tmp
            ExcelC.pCellVal(1, zoku) = buf
            ExcelC.pCellStyle(26) = tmp
            ExcelC.pCellVal(26) = ""
            '2017/02/17 H.Mori mod 改善2016 No8-1 START
            'If pstrPgkbn > "1" Then
            If pstrPgkbn <> "1" And pstrPgkbn <> "6" Then
                '2017/02/17 H.Mori mod 改善2016 No8-1 END
                ExcelC.pCellStyle(27) = tmp
                ExcelC.pCellVal(27) = ""
            End If

            If True Then
                For i = i To 27 - 2
                    col = col + 1
                    buf = ""
                    zoku = ""
                    tmp = ""

                    '数値項目
                    '2017/02/16 H.Mori mod 改善2016 No8-4 START ﾌｫﾝﾄｻｲｽﾞを8→10へ変更
                    'tmp = tmp & "height:16px;font-size:11px;border-style:solid;"
                    tmp = tmp & "height:16px;font-size:13px;border-style:solid;"
                    '2017/02/16 H.Mori mod 改善2016 No8-4 START ﾌｫﾝﾄｻｲｽﾞを8→10へ変更
                    tmp = tmp & "width:" & arrWidth(i) & "px;"
                    tmp = tmp & "text-align:right;mso-number-format:'\#\,\#\#0';"
                    zoku = "x:num=0 x:fmla='=SUM(" & arrLetters(col) & "4:" & arrLetters(col) & "" & iCnt + 3 & ")'" '例 =SUM(E4:E100)"
                    buf = ""

                    ExcelC.pCellStyle(i) = tmp
                    ExcelC.pCellVal(i, zoku) = buf
                Next
                ExcelC.mWriteLine("")       '行をファイルに書き込む
            End If

            '2015/02/13 H.Hosoda add 監視改善2014 №14 Start
            '■フッタ行（警報補足：その他、管理情報１、管理情報２）
            tmp = "height:16px;font-size:11px;text-align:left;border-style:none;"
            ExcelC.pCellStyle(1) = tmp
            ExcelC.pCellVal(1) = ""
            ExcelC.mWriteLine("")       '行をファイルに書き込む
            '2017/10/31 H.Mori add 2017改善開発 No8-1 START
            '' ガス警報器遮断
            ExcelC.pCellStyle(1) = tmp
            ExcelC.pCellStyle(2) = tmp
            ExcelC.pCellVal(1) = ""
            ExcelC.pCellVal(2, "colspan=22") = Convert.ToString("【ガス警報器遮断】04：ガス警報器遮断、05：ＣＯ警報器遮断、06：第２ガス警報器遮断")
            ExcelC.mWriteLine("")       '行をファイルに書き込む
            '2017/10/31 H.Mori add 2017改善開発 No8-1 END
            '2017/02/16 H.Mori mod 改善2016 No8-3 START
            '' ガス警報器作動
            ExcelC.pCellStyle(1) = tmp
            ExcelC.pCellStyle(2) = tmp
            ExcelC.pCellVal(1) = ""
            '2017/10/31 H.Mori mod 2017改善開発 No8-1 START
            'ExcelC.pCellVal(2, "colspan=22") = Convert.ToString("ガス警報器作動:ガス警報器作動、バルク警報器作動、ガス漏れ警報")
            ExcelC.pCellVal(2, "colspan=22") = Convert.ToString("【ガス警報器作動】10：ガス警報器作動、11：第２ガス警報器作動、14：ＣＯ警報器作動、50：バルク警報器作動、50：ガス漏れ警報")
            '2017/10/31 H.Mori mod 2017改善開発 No8-1 END
            ExcelC.mWriteLine("")       '行をファイルに書き込む
            '2017/02/16 H.Mori mod 改善2016 No8-3 END
            '2017/10/31 H.Mori mod 2017改善開発 No8-1 START その他、管理情報１、管理情報２　→　その他１、その他２、管理情報１、管理情報２へ変更
            '' その他
            'ExcelC.pCellStyle(1) = tmp
            'ExcelC.pCellStyle(2) = tmp
            'ExcelC.pCellVal(1) = ""
            'ExcelC.pCellVal(2, "colspan=22") = Convert.ToString("その他:第２ガス警報器作動、圧力センサ作動、感震器作動、メータ電池電圧低下、警報器未接続／信号線短絡、警報器電源プラグ抜け、圧力監視異常、センタ遮断、緊急遮断／宅内遮断")
            'ExcelC.mWriteLine("")       '行をファイルに書き込む
            ''2015/12/17 T.Ono add 維持管理 警報CD増加対応 START
            'ExcelC.pCellStyle(1) = tmp
            'ExcelC.pCellStyle(2) = tmp
            'ExcelC.pCellVal(1) = ""
            'ExcelC.pCellVal(2, "colspan=22") = Convert.ToString("　　　 ロードサーベイ、延長使用時間、ガス使用量増加、ガス使用量減少、大型燃焼器、ガス不使用警告、プリペイ残量警告、検定期間満了警告、計測エラー警告、逆流警告、閉塞圧異常警告、供給圧力上限異常、供給圧力下限異常")
            'ExcelC.mWriteLine("")       '行をファイルに書き込む
            'ExcelC.pCellStyle(1) = tmp
            'ExcelC.pCellStyle(2) = tmp
            'ExcelC.pCellVal(1) = ""
            'ExcelC.pCellVal(2, "colspan=22") = Convert.ToString("　　　 漏洩検査中、漏洩検査異常、漏洩検査不可、漏洩検査異常なし、プリペイ遮断、計測エラー遮断、逆流遮断")
            'ExcelC.mWriteLine("")       '行をファイルに書き込む
            ''2015/12/17 T.Ono add 維持管理 警報CD増加対応 END
            ' '' 管理情報１
            'ExcelC.pCellStyle(1) = tmp
            'ExcelC.pCellStyle(2) = tmp
            'ExcelC.pCellVal(1) = ""
            'ExcelC.pCellVal(2, "colspan=22") = Convert.ToString("管理情報１:テスト遮断、遮断弁復帰、セキュリティ正常復帰")
            'ExcelC.mWriteLine("")       '行をファイルに書き込む
            ' '' 管理情報２
            'ExcelC.pCellStyle(1) = tmp
            'ExcelC.pCellStyle(2) = tmp
            'ExcelC.pCellVal(1) = ""
            ''2017/02/23 H.Mori mod 改善2016 No8-3
            ''ExcelC.pCellVal(2, "colspan=22") = Convert.ToString("管理情報２:ボンベ交換、残量警報３、残量警報２、残量警報１、リセット要求、外部機器２作動、ＡＣＵ電池・電圧低下、センサメッセージ")
            'ExcelC.pCellVal(2, "colspan=22") = Convert.ToString("管理情報２:ボンベ交換、残量警報３、残量警報２、残量警報１、リセット要求、外部機器２作動、ＡＣＵ電池・電圧低下、センサメッセージ、ＹＮＣＵ親機コンセント抜け、バルク残量警告４０％作動、バルク残量警告２０％作動")
            'ExcelC.mWriteLine("")       '行をファイルに書き込む
            ''2015/02/13 H.Hosoda add 監視改善2014 №14 End
            ''2017/02/16 H.Mori mod 改善2016 No8-3 START
            'ExcelC.pCellStyle(1) = tmp
            'ExcelC.pCellStyle(2) = tmp
            'ExcelC.pCellVal(1) = ""
            'ExcelC.pCellVal(2, "colspan=22") = Convert.ToString("　　　 自動切替が切り替わりました、自動切替が復旧しました、逆流警告（バルク）、バルク警報器復旧、ベーパライザー異常、ベーパーライザー復旧、遮断弁が閉じました、熱源機異常、２次側圧力が低下しました、２次側圧力が正常になりました")
            'ExcelC.mWriteLine("")       '行をファイルに書き込む
            'ExcelC.pCellStyle(1) = tmp
            'ExcelC.pCellStyle(2) = tmp
            'ExcelC.pCellVal(1) = ""
            'ExcelC.pCellVal(2, "colspan=22") = Convert.ToString("　　　 中間圧力異常、エアー圧力異常、Ｍ１ポートが動作しました。、Ｍ１ポートが復旧しました。、ボンベ庫異常、サーモバルブ作動（ベーバ）、サーモバルブ復旧（ベーバ）、ＮＣＵテスト　正常発呼")
            'ExcelC.mWriteLine("")       '行をファイルに書き込む
            'ExcelC.pCellStyle(1) = tmp
            'ExcelC.pCellStyle(2) = tmp
            'ExcelC.pCellVal(1) = ""
            'ExcelC.pCellVal(2, "colspan=22") = Convert.ToString("　　　 緊急遮断弁／耐震遮断弁　回復、緊急遮断弁／耐震遮断弁　作動、気化器異常")
            'ExcelC.mWriteLine("")       '行をファイルに書き込む
            'ExcelC.pCellStyle(1) = tmp
            'ExcelC.pCellStyle(2) = tmp
            'ExcelC.pCellVal(1) = ""
            'ExcelC.pCellVal(2, "colspan=22") = Convert.ToString("　　　 ※センサメッセージについて　警報コード=50、警報メッセージ=バルク警報器作動、ガス漏れ警報の場合、ガス警報器作動へ集計する。")
            'ExcelC.mWriteLine("")       '行をファイルに書き込む
            '2017/02/16 H.Mori mod 改善2016 No8-3 END
            '【 その他１】
            ExcelC.pCellStyle(1) = tmp
            ExcelC.pCellStyle(2) = tmp
            ExcelC.pCellVal(1) = ""
            ExcelC.pCellVal(2, "colspan=22") = Convert.ToString("【 その他１】03：外部センサ遮断、32：センタ遮断、33：緊急遮断／宅内遮断、34：メータ電池電圧低下遮断、35：ロードサーベイ、3C：検定期間満了警告、3D：計測エラー警告、3E：逆流警告、3I：漏洩検査中、3J：漏洩検査異常、3K：漏洩検査不可、3L：漏洩検査異常なし、")
            ExcelC.mWriteLine("")       '行をファイルに書き込む
            ExcelC.pCellStyle(1) = tmp
            ExcelC.pCellStyle(2) = tmp
            ExcelC.pCellVal(1) = ""
            ExcelC.pCellVal(2, "colspan=22") = Convert.ToString("　　　　　　 3M：プリペイ遮断、3N：計測エラー遮断、3O：逆流遮断、40：Ｇ－ＡＤＰ電池低下、50：逆流警告、50：ベーパライザー異常、50：遮断弁が閉じました、50：熱源機異常、50：２次側圧力が低下しました、50：中間圧力異常、50：エアー圧力異常、")
            ExcelC.mWriteLine("")       '行をファイルに書き込む
            ExcelC.pCellStyle(1) = tmp
            ExcelC.pCellStyle(2) = tmp
            ExcelC.pCellVal(1) = ""
            ExcelC.pCellVal(2, "colspan=22") = Convert.ToString("　　　　　　 50：Ｍ１ポートが動作しました、50：ボンベ庫異常、50：サーモバルブ作動（ベーバ）、50：緊急遮断弁／耐震遮断弁　作動、50：気化器異常")
            ExcelC.mWriteLine("")       '行をファイルに書き込む
            '【 その他２】
            ExcelC.pCellStyle(1) = tmp
            ExcelC.pCellStyle(2) = tmp
            ExcelC.pCellVal(1) = ""
            ExcelC.pCellVal(2, "colspan=22") = Convert.ToString("【 その他２】12：圧力センサ作動、13：感震器作動、17：テスト遮断、18：遮断弁復帰、23：メータ電池電圧低下、24：警報器未接続／信号線短絡、25：警報器電源プラグ抜け、26：圧力監視異常、3F：閉塞圧異常警告、3G：供給圧力上限異常、3H：供給圧力下限異常、")
            ExcelC.mWriteLine("")       '行をファイルに書き込む
            ExcelC.pCellStyle(1) = tmp
            ExcelC.pCellStyle(2) = tmp
            ExcelC.pCellVal(1) = ""
            ExcelC.pCellVal(2, "colspan=22") = Convert.ToString("　　　　　　 50：ＹＮＣＵ親機コンセント抜け")
            ExcelC.mWriteLine("")       '行をファイルに書き込む
            '【管理情報１】
            ExcelC.pCellStyle(1) = tmp
            ExcelC.pCellStyle(2) = tmp
            ExcelC.pCellVal(1) = ""
            ExcelC.pCellVal(2, "colspan=22") = Convert.ToString("【管理情報１】19：ボンベ交換、20：セキュリティ正常復帰、27：残量警報３、28：残量警報２、29：残量警報１、30：リセット要求、31：外部機器２作動、36：延長使用時間、37：ガス使用量増加、38：ガス使用量減少、39：大型燃焼器、3A：ガス不使用警告、")
            ExcelC.mWriteLine("")       '行をファイルに書き込む
            ExcelC.pCellStyle(1) = tmp
            ExcelC.pCellStyle(2) = tmp
            ExcelC.pCellVal(1) = ""
            ExcelC.pCellVal(2, "colspan=22") = Convert.ToString("　　　　　　　3B：プリペイ残量警告、49：ＡＣＵ電池・電圧低下、50：バルク残量警告４０％作動、50：バルク残量警告２０％作動、50：自動切替が切り替わりました、50：自動切替が復旧しました、50：バルク警報器復旧、50：ベーパーライザー復旧、")
            ExcelC.mWriteLine("")       '行をファイルに書き込む
            ExcelC.pCellStyle(1) = tmp
            ExcelC.pCellStyle(2) = tmp
            ExcelC.pCellVal(1) = ""
            ExcelC.pCellVal(2, "colspan=22") = Convert.ToString("　　　　　　　50：２次側圧力が正常になりました、50：Ｍ１ポートが復旧しました。、50：サーモバルブ復旧（ベーバ）、50：ＮＣＵテスト　正常発呼、50：緊急遮断弁／耐震遮断弁　回復")
            ExcelC.mWriteLine("")       '行をファイルに書き込む
            '【管理情報２】
            ExcelC.pCellStyle(1) = tmp
            ExcelC.pCellStyle(2) = "height:16px;font-size:11px;text-align:left;border-style:none;color:#FF0000;" '2017/11/17 H.Mori mod 2017改善開発 No8-1
            ExcelC.pCellVal(1) = ""
            ExcelC.pCellVal(2, "colspan=22") = Convert.ToString("【管理情報２】上記以外の警報　※警報内容を確認し、内容に適した項目に集約してください。")
            ExcelC.mWriteLine("")       '行をファイルに書き込む
            '2017/10/31 H.Mori mod 2017改善開発 No8-1 END その他、管理情報１、管理情報２　→　その他１、その他２、管理情報１、管理情報２へ変更

            ExcelC.mClose()                                 'ファイルクローズ

            '圧縮先ファイルのあるフォルダ
            compressC.p_Dir = ExcelC.pDirName
            '日本語ファイル名の指定
            compressC.p_NihongoFileName = "監視対応数集計表.xls"
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
    '2015/02/04 H.Hosoda mod 監視改善2014 №14 引数変更
    'Public Function fncMakeSelect(ByVal ind As Integer, _
    '                              ByVal pstrKuracd As String, _
    '                              ByVal pstrJacd As String, _
    '                              ByVal pstrTrgFrom As String, _
    '                              ByVal pstrTrgTo As String, _
    '                              ByVal pstrPgKbn As String, _
    '                              ByVal pstrTaiouChofuku As String, _
    '                              ByVal pdecPageMax As Decimal) As String
    '2017/02/15 H.Mori mod 改善2016 No8-2 引数変更
    'Public Function fncMakeSelect(ByVal ind As Integer, _
    '                              ByVal pstrKuracdFrom As String, _
    '                              ByVal pstrKuracdTo As String, _
    '                              ByVal pstrJacdFrom As String, _
    '                              ByVal pstrJacdTo As String, _
    '                              ByVal pstrHangrpFrom As String, _
    '                              ByVal pstrHangrpTo As String, _
    '                              ByVal pstrTrgFrom As String, _
    '                              ByVal pstrTrgTo As String, _
    '                              ByVal pstrPgKbn As String, _
    '                              ByVal pstrHasseiTel As String, _
    '                              ByVal pstrHasseiKei As String, _
    '                              ByVal pstrTaiouTel As String, _
    '                              ByVal pstrTaiouShu As String, _
    '                              ByVal pstrTaiouJuf As String, _
    '                              ByVal pstrTrgdatekbn As String, _
    '                              ByVal pdecPageMax As Decimal) As String
    '2020/11/01 T.Ono mod 監視改善2020
    'pstrTsadco 追加
    Public Function fncMakeSelect(ByVal ind As Integer,
                              ByVal pstrKuracdFrom As String,
                              ByVal pstrKuracdTo As String,
                              ByVal pstrJacdFrom As String,
                              ByVal pstrJacdTo As String,
                              ByVal pstrHangrpFrom As String,
                              ByVal pstrHangrpTo As String,
                              ByVal pstrTrgFrom As String,
                              ByVal pstrTrgTo As String,
                              ByVal pstrPgKbn As String,
                              ByVal pstrHasseiTel As String,
                              ByVal pstrHasseiKei As String,
                              ByVal pstrTaiouTel As String,
                              ByVal pstrTaiouShu As String,
                              ByVal pstrTaiouJuf As String,
                              ByVal pstrTrgdatekbn As String,
                              ByVal pdecPageMax As Decimal,
                              ByVal pstrTrgTimeFrom As String,
                              ByVal pstrTrgTimeTo As String,
                              ByVal pstrTsadcd As String) As String

        Dim strSQL As New StringBuilder("")
        Dim strWHE As New StringBuilder("")

        '----------------
        ' SQL条件作成(共通)
        '----------------
        '2017/02/15 H.Mori mod 改善2016 No8-2 対象時間追加 START
        '2015/02/04 H.Hosoda mod 監視改善2014 №14 対象期間区分による分岐追加 Start
        'If Len(pstrTrgFrom) > 0 Then '発生日FROM
        '    strWHE.Append("    AND HATYMD >= '" & pstrTrgFrom & "' ")
        'End If
        'If Len(pstrTrgTo) > 0 Then '発生日TO
        '    strWHE.Append("    AND HATYMD <= '" & pstrTrgTo & "' ")
        'End If
        'If pstrTrgdatekbn = "1" Then
        '    If Len(pstrTrgFrom) > 0 Then '対応完了日FROM
        '        strWHE.Append("    AND SYOYMD >= :TRGDATE_FROM ")
        '    End If
        '    If Len(pstrTrgTo) > 0 Then '対応完了日TO
        '        strWHE.Append("    AND SYOYMD <= :TRGDATE_TO ")
        '    End If
        'Else
        '    If Len(pstrTrgFrom) > 0 Then '受信日FROM
        '        strWHE.Append("    AND HATYMD >= :TRGDATE_FROM ")
        '    End If
        '    If Len(pstrTrgTo) > 0 Then '受信日TO
        '        strWHE.Append("    AND HATYMD <= :TRGDATE_TO ")
        '    End If
        'End If
        If pstrTrgdatekbn = "1" Then '対応完了日
            If pstrTrgTimeFrom.Length = 0 AndAlso pstrTrgTimeTo.Length = 0 Then
                strWHE.Append(" AND SYOYMD BETWEEN :TRGDATE_FROM AND :TRGDATE_TO ")
            ElseIf pstrTrgTimeFrom.Length > 0 AndAlso pstrTrgTimeTo.Length > 0 Then
                strWHE.Append(" AND SYOYMD || SYOTIME BETWEEN :TRGDATE_FROM || :TRGTIME_FROM AND :TRGDATE_TO || :TRGTIME_TO ")
            End If
        Else                       '受信日
            If pstrTrgTimeFrom.Length = 0 AndAlso pstrTrgTimeTo.Length = 0 Then
                strWHE.Append(" AND HATYMD BETWEEN :TRGDATE_FROM AND :TRGDATE_TO ")
            ElseIf pstrTrgTimeFrom.Length > 0 AndAlso pstrTrgTimeTo.Length > 0 Then
                strWHE.Append(" AND HATYMD || HATTIME BETWEEN :TRGDATE_FROM || :TRGTIME_FROM AND :TRGDATE_TO || :TRGTIME_TO ")
            End If
        End If
        '2015/02/04 H.Hosoda mod 監視改善2014 №14 対象期間区分による分岐追加 End
        '2017/02/16 H.Mori mod 改善2016 No8-2 対象時間追加 END
        '2015/02/04 H.Hosoda mod 監視改善2014 №14 Start
        'If Len(pstrKuracd) > 0 Then 'クライアントコード
        '    strWHE.Append("    AND KURACD = '" & pstrKuracd & "' ")
        'End If
        'If Len(pstrJacd) > 0 Then 'ＪＡコード
        '    strWHE.Append("    AND JACD = '" & pstrJacd & "' ")
        'End If
        '2010/03/09 T.Watabe add
        'If pstrTaiouChofuku = "0" Then '0:重複を含まない？
        '    strWHE.Append("    AND TAIOKBN <> '3' ")
        'End If
        If Len(pstrKuracdFrom) > 0 Then 'クライアントFROM
            strWHE.Append("    AND KURACD >= :KURACD_FROM ")
        End If
        If Len(pstrKuracdTo) > 0 Then 'クライアントTO
            strWHE.Append("    AND KURACD <= :KURACD_TO ")
        End If
        If Len(pstrJacdFrom) > 0 Then 'ＪＡコードFROM
            strWHE.Append("    AND JACD >= :JACD_FROM ")
        End If
        If Len(pstrJacdTo) > 0 Then 'ＪＡコードTO
            strWHE.Append("    AND JACD <= :JACD_TO ")
        End If
        If Len(pstrHangrpFrom) > 0 Then '販売事業者FROM
            strWHE.Append("    AND HANJICD >= :HANGRP_FROM ")
        End If
        If Len(pstrHangrpTo) > 0 Then '販売事業者TO
            strWHE.Append("    AND HANJICD <= :HANGRP_TO ")
        End If
        If Len(pstrHasseiTel) > 0 And Len(pstrHasseiKei) > 0 Then '発生区分:全て選択
            strWHE.Append("    AND (HATKBN = :HATKBN1 OR HATKBN = :HATKBN2) ")
        ElseIf Len(pstrHasseiTel) > 0 And Len(pstrHasseiKei) = 0 Then '発生区分:電話のみ選択
            strWHE.Append("    AND HATKBN = :HATKBN1 ")
        ElseIf Len(pstrHasseiTel) = 0 And Len(pstrHasseiKei) > 0 Then '発生区分:警報のみ選択
            strWHE.Append("    AND HATKBN = :HATKBN2 ")
        Else
            '条件なし
        End If
        If Len(pstrTaiouTel) > 0 And Len(pstrTaiouShu) > 0 And Len(pstrTaiouJuf) > 0 Then '対応区分:全て選択
            strWHE.Append("    AND (TAIOKBN = :TAIOKBN1 OR TAIOKBN = :TAIOKBN2 OR TAIOKBN = :TAIOKBN3) ")
        ElseIf Len(pstrTaiouTel) > 0 And Len(pstrTaiouShu) > 0 And Len(pstrTaiouJuf) = 0 Then '対応区分:電話・出動を選択
            strWHE.Append("    AND (TAIOKBN = :TAIOKBN1 OR TAIOKBN = :TAIOKBN2) ")
        ElseIf Len(pstrTaiouTel) > 0 And Len(pstrTaiouShu) = 0 And Len(pstrTaiouJuf) > 0 Then '対応区分:電話・重複を選択
            strWHE.Append("    AND (TAIOKBN = :TAIOKBN1 OR TAIOKBN = :TAIOKBN3) ")
        ElseIf Len(pstrTaiouTel) = 0 And Len(pstrTaiouShu) > 0 And Len(pstrTaiouJuf) > 0 Then '対応区分:出動・重複を選択
            strWHE.Append("    AND (TAIOKBN = :TAIOKBN2 OR TAIOKBN = :TAIOKBN3) ")
        ElseIf Len(pstrTaiouTel) > 0 And Len(pstrTaiouShu) = 0 And Len(pstrTaiouJuf) = 0 Then '対応区分:電話のみ選択
            strWHE.Append("    AND TAIOKBN = :TAIOKBN1 ")
        ElseIf Len(pstrTaiouTel) = 0 And Len(pstrTaiouShu) > 0 And Len(pstrTaiouJuf) = 0 Then  '対応区分:出動のみ選択
            strWHE.Append("    AND TAIOKBN = :TAIOKBN2 ")
        ElseIf Len(pstrTaiouTel) = 0 And Len(pstrTaiouShu) = 0 And Len(pstrTaiouJuf) > 0 Then '対応区分:重複のみ選択
            strWHE.Append("    AND TAIOKBN = :TAIOKBN3 ")
        Else
            '条件なし
        End If
        '2015/02/04 H.Hosoda mod 監視改善2014 №14 End

        '2020/09/14 T.Ono add 監視改善2020 START
        '作動原因（工事交換含まない）
        If pstrTsadcd = "0" Then 'チェックなし
            strWHE.Append("    AND (TSADCD <> '63' OR TSADCD IS NULL) ")
        End If
        '2020/09/14 T.Ono add 監視改善2020 END

        If ind = 1 Then
            '----------------
            ' 1:件数取得
            '----------------
            strSQL.Append("SELECT COUNT(*) FROM D20_TAIOU ")
            strSQL.Append("    WHERE  ")
            strSQL.Append("        1=1 ")
            strSQL.Append(strWHE) '条件追加
            If False Then
            ElseIf pstrPgKbn = "1" Then 'クライアント集計
                strSQL.Append("    GROUP BY KURACD ")
            ElseIf pstrPgKbn = "2" Then 'ＪＡ集計
                strSQL.Append("    GROUP BY KURACD, JACD ")
            ElseIf pstrPgKbn = "3" Then 'ＪＡ支所集計
                strSQL.Append("    GROUP BY KURACD, ACBCD ")
                '2015/02/13 H.Hosoda add 監視改善2014 №14 START
            ElseIf pstrPgKbn = "4" Then  '販売事業者単位 
                strSQL.Append("    GROUP BY KURACD, HANJICD ")
                '2017/02/17 H.Mori mod 改善2016 No8-1 START
                'ElseIf pstrPgKbn = "5" Then  '販売事業者支所単位 
                '    strSQL.Append("    GROUP BY KURACD, ACBCD, HANJICD ")
                '2015/02/13 H.Hosoda add 監視改善2014 №14 END
            ElseIf pstrPgKbn = "6" Then  '県単位 
                strSQL.Append("    GROUP BY SUBSTR(KURACD,2,2) ")
            ElseIf pstrPgKbn = "7" Then  '販売所単位 
                strSQL.Append("    GROUP BY KURACD, HANBCD ")
                '2017/02/17 H.Mori mod 改善2016 No8-1 END
            End If
        Else
            '----------------
            ' 2:データ取得
            '----------------
            strSQL.Append("WITH S AS ( ") '①WITH句（集計３パターンの違いをここで表す。他を共通にするため。）
            If False Then
            ElseIf pstrPgKbn = "1" Then 'クライアント集計 （※KMCD1=24は、KMCD2=21,22の時に、それぞれKMCD1=21,22に変換する。2008/12/19 by監視センター鈴木氏）
                'strSQL.Append("    SELECT KURACD, NULL  AS JACD, DECODE(KMCD1,'24',DECODE(KMCD2,'21','21','22','22',KMCD1),KMCD1) AS KMCD1, HATKBN, COUNT(*) AS CNT, SUM(DECODE(SDSKBN,'2',1,0)) AS SDSCNT ") ' 2009/02/17 T.Watabe edit
                'strSQL.Append("    SELECT KURACD, NULL  AS JACD, DECODE(KMCD1,'24',DECODE(KMCD2,'21','21','22','22',KMCD1),KMCD1) AS KMCD1, HATKBN, COUNT(*) AS CNT, SUM(DECODE(TFKICD,'8',1,0)) AS SDSCNT ") ' 2009/08/11 T.Watabe edit
                'strSQL.Append("    SELECT KURACD, NULL  AS JACD, TAIOKBN, DECODE(KMCD1,'24',DECODE(KMCD2,'21','21','22','22',KMCD1),KMCD1) AS KMCD1, HATKBN, COUNT(*) AS CNT, SUM(DECODE(TAIOKBN,'2',1,0)) AS SDSCNT ") '2017/02/16 H.Mori mod 改善2016 No7-1
                strSQL.Append("    SELECT KURACD, NULL  AS JACD, TAIOKBN, DECODE(KMCD1,'24',DECODE(KMCD2,'21','21','22','22',KMCD1),KMCD1) AS KMCD1, HATKBN, COUNT(*) AS CNT, SUM(DECODE(TAIOKBN,'2',1,0)) AS SDSCNT, KMNM1 ")
            ElseIf pstrPgKbn = "2" Then 'ＪＡ集計
                'strSQL.Append("    SELECT KURACD,          JACD, DECODE(KMCD1,'24',DECODE(KMCD2,'21','21','22','22',KMCD1),KMCD1) AS KMCD1, HATKBN, COUNT(*) AS CNT, SUM(DECODE(SDSKBN,'2',1,0)) AS SDSCNT ") ' 2009/02/17 T.Watabe edit
                'strSQL.Append("    SELECT KURACD,          JACD, DECODE(KMCD1,'24',DECODE(KMCD2,'21','21','22','22',KMCD1),KMCD1) AS KMCD1, HATKBN, COUNT(*) AS CNT, SUM(DECODE(TFKICD,'8',1,0)) AS SDSCNT ") ' 2009/08/11 T.Watabe edit
                'strSQL.Append("    SELECT KURACD,          JACD, TAIOKBN, DECODE(KMCD1,'24',DECODE(KMCD2,'21','21','22','22',KMCD1),KMCD1) AS KMCD1, HATKBN, COUNT(*) AS CNT, SUM(DECODE(TAIOKBN,'2',1,0)) AS SDSCNT ") '2017/02/16 H.Mori mod 改善2016 No7-1
                strSQL.Append("    SELECT KURACD,          JACD, TAIOKBN, DECODE(KMCD1,'24',DECODE(KMCD2,'21','21','22','22',KMCD1),KMCD1) AS KMCD1, HATKBN, COUNT(*) AS CNT, SUM(DECODE(TAIOKBN,'2',1,0)) AS SDSCNT, KMNM1 ")
            ElseIf pstrPgKbn = "3" Then 'ＪＡ支所集計
                'strSQL.Append("    SELECT KURACD, ACBCD AS JACD, DECODE(KMCD1,'24',DECODE(KMCD2,'21','21','22','22',KMCD1),KMCD1) AS KMCD1, HATKBN, COUNT(*) AS CNT, SUM(DECODE(SDSKBN,'2',1,0)) AS SDSCNT ") ' 2009/02/17 T.Watabe edit
                'strSQL.Append("    SELECT KURACD, ACBCD AS JACD, DECODE(KMCD1,'24',DECODE(KMCD2,'21','21','22','22',KMCD1),KMCD1) AS KMCD1, HATKBN, COUNT(*) AS CNT, SUM(DECODE(TFKICD,'8',1,0)) AS SDSCNT ") ' 2009/08/11 T.Watabe edit
                'strSQL.Append("    SELECT KURACD, ACBCD AS JACD, DECODE(KMCD1,'24',DECODE(KMCD2,'21','21','22','22',KMCD1),KMCD1) AS KMCD1, HATKBN, COUNT(*) AS CNT, SUM(DECODE(TAIOKBN,'2',1,0)) AS SDSCNT ")
                'strSQL.Append("    SELECT KURACD, ACBCD AS JACD, TAIOKBN, DECODE(KMCD1,'24',DECODE(KMCD2,'21','21','22','22',KMCD1),KMCD1) AS KMCD1, HATKBN, COUNT(*) AS CNT, SUM(DECODE(TAIOKBN,'2',1,0)) AS SDSCNT ") '2017/02/16 H.Mori mod 改善2016 No7-1
                strSQL.Append("    SELECT KURACD, ACBCD AS JACD, TAIOKBN, DECODE(KMCD1,'24',DECODE(KMCD2,'21','21','22','22',KMCD1),KMCD1) AS KMCD1, HATKBN, COUNT(*) AS CNT, SUM(DECODE(TAIOKBN,'2',1,0)) AS SDSCNT, KMNM1 ")
                '2015/02/09 H.Hosoda add 監視改善2014 №14 START
            ElseIf pstrPgKbn = "4" Then '販売事業者単位
                'strSQL.Append("    SELECT KURACD, HANJICD AS JACD, TAIOKBN, DECODE(KMCD1,'24',DECODE(KMCD2,'21','21','22','22',KMCD1),KMCD1) AS KMCD1, HATKBN, COUNT(*) AS CNT, SUM(DECODE(TAIOKBN,'2',1,0)) AS SDSCNT ") '2017/02/16 H.Mori mod 改善2016 No7-1
                strSQL.Append("    SELECT KURACD, HANJICD AS JACD, TAIOKBN, DECODE(KMCD1,'24',DECODE(KMCD2,'21','21','22','22',KMCD1),KMCD1) AS KMCD1, HATKBN, COUNT(*) AS CNT, SUM(DECODE(TAIOKBN,'2',1,0)) AS SDSCNT, KMNM1 ")
                '2017/02/17 H.Mori mod 改善2016 No8-1 START
                'ElseIf pstrPgKbn = "5" Then '販売事業者支所単位
                '    strSQL.Append("    SELECT KURACD, ACBCD AS JACD,HANJICD, TAIOKBN, DECODE(KMCD1,'24',DECODE(KMCD2,'21','21','22','22',KMCD1),KMCD1) AS KMCD1, HATKBN, COUNT(*) AS CNT, SUM(DECODE(TAIOKBN,'2',1,0)) AS SDSCNT ")
                '2015/02/09 H.Hosoda add 監視改善2014 №14 START
            ElseIf pstrPgKbn = "6" Then '県単位
                strSQL.Append("    SELECT SUBSTR(KURACD,2,2) AS KURACD, NULL  AS JACD, TAIOKBN, DECODE(KMCD1,'24',DECODE(KMCD2,'21','21','22','22',KMCD1),KMCD1) AS KMCD1, HATKBN, COUNT(*) AS CNT, SUM(DECODE(TAIOKBN,'2',1,0)) AS SDSCNT, KMNM1 ")
            ElseIf pstrPgKbn = "7" Then '販売所単位
                strSQL.Append("    SELECT KURACD, HANBCD AS JACD, TAIOKBN, DECODE(KMCD1,'24',DECODE(KMCD2,'21','21','22','22',KMCD1),KMCD1) AS KMCD1, HATKBN, COUNT(*) AS CNT, SUM(DECODE(TAIOKBN,'2',1,0)) AS SDSCNT, KMNM1 ")
                '2017/02/17 H.Mori mod 改善2016 No8-1 END
            End If
            strSQL.Append("    FROM D20_TAIOU ")
            strSQL.Append("    WHERE  ")
            strSQL.Append("        1=1 ")
            strSQL.Append(strWHE) '条件追加
            strSQL.Append("    GROUP BY  ")
            strSQL.Append("        KURACD, ")
            strSQL.Append("        JACD, ")
            strSQL.Append("        ACBCD, ")
            strSQL.Append("        HANJICD, ") '2015/02/10 H.Hosoda add 監視改善2014 №14
            strSQL.Append("        HANBCD, ") '2017/02/17 H.Mori add 改善2016 No8-1
            strSQL.Append("        KMCD1, ")
            strSQL.Append("        KMCD2, ")
            strSQL.Append("        HATKBN, ")
            strSQL.Append("        TAIOKBN, ") '2010/03/10 T.Watabe add
            strSQL.Append("        KMNM1 ") '2017/02/16 H.Mori add 改善2016 No8-3
            strSQL.Append("    HAVING COUNT(*) <> 0 ")
            strSQL.Append(") ")

            strSQL.Append("SELECT  ") '②本文
            strSQL.Append("    A.KURACD, ")
            '2017/02/17 H.Mori mod 改善2016 No8-1 START
            If pstrPgKbn = "6" Then
                strSQL.Append("    B.KEN_NAME AS KURANM, ")
            Else
                strSQL.Append("    B.CLI_NAME AS KURANM, ")
            End If
            '2017/02/17 H.Mori mod 改善2016 No8-1 END
            strSQL.Append("    A.JACD, ")
            If False Then
                '2017/02/17 H.Mori mod 改善2016 No8-1 START
                'ElseIf pstrPgKbn = "1" Then 'クライアント集計
            ElseIf pstrPgKbn = "1" Or pstrPgKbn = "6" Or pstrPgKbn = "7" Then 'クライアント集計、県集計、販売所集計
                '2017/02/17 H.Mori mod 改善2016 No8-1 END
                strSQL.Append("    NULL AS JANM, ")
            ElseIf pstrPgKbn = "2" Then 'ＪＡ集計
                '2014/03/24 T.Ono mod JA名称はJA_CDで検索する
                'strSQL.Append("    (SELECT MAX(C.JA_NAME)  FROM HN2MAS C WHERE C.CLI_CD = A.KURACD AND C.HAN_CD = A.JACD) AS JANM, ")
                '2019/11/01 W.GANEKO mod 2019監視改善 JA名称はJA_CDで削除済みは表示しない
                'strSQL.Append("    (SELECT MAX(C.JA_NAME)  FROM HN2MAS C WHERE C.CLI_CD = A.KURACD AND C.JA_CD = A.JACD) AS JANM, ")
                strSQL.Append("    (SELECT MAX(C.JA_NAME)  FROM HN2MAS C WHERE C.CLI_CD = A.KURACD AND C.JA_CD = A.JACD AND C.DEL_FLG IS NULL) AS JANM, ")
                '2015/02/09 H.Hosoda mod 監視改善2014 №14
                'ElseIf pstrPgKbn = "3" Then 'ＪＡ支所集計 
                '2017/02/23 H.Mori mod 改善2016 No8-1 販売事業者支所単位の削除
                'ElseIf pstrPgKbn = "3" Or pstrPgKbn = "5" Then 'ＪＡ支所集計、販売事業者支所単位
            ElseIf pstrPgKbn = "3" Then 'ＪＡ支所集計
                '2019/11/01 W.GANEKO mod 2019監視改善  JA名称はJA_CDで削除済みは表示しない
                'strSQL.Append("    (SELECT MAX(C.JAS_NAME) FROM HN2MAS C WHERE C.CLI_CD = A.KURACD AND C.HAN_CD = A.JACD) AS JANM, ")
                strSQL.Append("    (SELECT MAX(C.JAS_NAME) FROM HN2MAS C WHERE C.CLI_CD = A.KURACD AND C.HAN_CD = A.JACD AND C.DEL_FLG IS NULL) AS JANM, ")
            ElseIf pstrPgKbn = "4" Then '販売事業者単位 '2015/02/09 H.Hosoda add 監視改善2014 №14
                strSQL.Append("    (SELECT C.HANJIGYOSYANM FROM M10_HANJIGYOSYA C WHERE C.GROUPCD = A.JACD) AS JANM, ")
            End If
            strSQL.Append("    A.C01,A.C02,A.C03,A.C04,A.C05,A.C06,A.C07,A.C08,A.C09,A.C10, ")
            strSQL.Append("    A.C11,A.C12,A.C13,A.C14,A.C15,A.C16,A.C17,A.C18,A.C19, ")
            strSQL.Append("    A.C20,A.C21, ") '2010/03/10 T.Watabe add
            strSQL.Append("    B.KEN_NAME AS KENNM ")
            strSQL.Append("FROM  ")
            strSQL.Append("    ( ")
            strSQL.Append("    SELECT  ")
            strSQL.Append("        KURACD, ")
            strSQL.Append("        JACD, ")
            '【使用時間オーバ予告】
            strSQL.Append("        SUM(DECODE(KMCD1,'09',CNT,0)) AS C01, ")
            '【使用時間オーバ遮断】
            strSQL.Append("        SUM(DECODE(KMCD1,'02',CNT,0)) AS C02, ")
            '【ガス警報器遮断】
            strSQL.Append("        SUM(DECODE(KMCD1,'04',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'05',CNT,0)) + ") '2017/11/01 H.Mori add 2017改善開発 No8-1
            strSQL.Append("        SUM(DECODE(KMCD1,'06',CNT,0)) AS C03, ")
            '【圧力センサ遮断】
            strSQL.Append("        SUM(DECODE(KMCD1,'07',CNT,0)) AS C04, ")
            '【最大流量オーバ遮断】
            strSQL.Append("        SUM(DECODE(KMCD1,'01',CNT,0)) AS C05, ")
            '【遮断弁異常】
            strSQL.Append("        SUM(DECODE(KMCD1,'16',CNT,0)) AS C06, ")
            '2017/02/16 H.Mori mod 改善2016 No8-3 START
            '【ガス警報器作動】
            'strSQL.Append("        SUM(DECODE(KMCD1,'10',CNT,0)) AS C07, ")
            strSQL.Append("        SUM(DECODE(KMCD1,'10',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'11',CNT,0)) + ") '2017/11/01 H.Mori mod 2017改善開発 No8-1
            strSQL.Append("        SUM(DECODE(KMCD1,'14',CNT,0)) + ") '2017/11/01 H.Mori add 2017改善開発 No8-1
            strSQL.Append("        SUM(DECODE(KMCD1,'5G',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'5I',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'50',DECODE(KMNM1,'バルク警報器作動',CNT,'ガス漏れ警報',CNT,0),0)) AS C07, ")
            '2017/02/16 H.Mori mod 改善2016 No8-3 END
            '2017/11/01 H.Mori mod 2017改善開発 No8-1 START 集計項目の見直し
            'strSQL.Append("        SUM(DECODE(KMCD1,'03',CNT,0)) AS C08, ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'08',CNT,0)) AS C09, ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'15',CNT,0)) AS C10, ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'21',CNT,0)) AS C11, ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'22',CNT,0)) AS C12, ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'23',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'24',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'25',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'26',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'11',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'12',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'13',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'32',CNT,0)) + ")
            ''2015/12/17 T.Ono add 維持管理 警報CD増加対応 START
            ''strSQL.Append("        SUM(DECODE(KMCD1,'33',CNT,0)) AS C13, ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'33',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'35',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'36',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'37',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'38',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'39',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'3A',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'3B',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'3C',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'3D',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'3E',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'3F',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'3G',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'3H',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'3I',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'3J',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'3K',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'3L',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'3M',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'3N',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'3O',CNT,0)) AS C13, ")
            ''2015/12/17 T.Ono add 維持管理 警報CD増加対応 END
            'strSQL.Append("        SUM(DECODE(KMCD1,'20',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'17',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'18',CNT,0)) AS C14, ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'19',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'27',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'28',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'29',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'30',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'31',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'40',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'49',CNT,0)) + ")
            ''2017/02/16 H.Mori mod 改善2016 No8-3 START
            ''strSQL.Append("        SUM(DECODE(KMCD1,'50',CNT,0)) AS C15, ")           
            'strSQL.Append("        SUM(DECODE(KMCD1,'50',DECODE(KMNM1,'バルク警報器作動',0,'ガス漏れ警報',0,CNT),0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'5A',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'5B',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'5C',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'5D',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'5E',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'5F',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'5H',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'5J',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'5K',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'5L',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'5M',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'5N',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'5O',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'5P',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'5Q',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'5R',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'5S',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'5T',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'5U',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'5V',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'5W',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'5X',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'5Y',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'5Z',CNT,0)) AS C15, ")
            ''2017/02/16 H.Mori mod 改善2016 No8-3 END
            '【感震器遮断】
            strSQL.Append("        SUM(DECODE(KMCD1,'08',CNT,0)) AS C08, ")
            '【安全確認中遮断】
            strSQL.Append("        SUM(DECODE(KMCD1,'15',CNT,0)) AS C09, ")
            '【微少漏洩(流)】
            strSQL.Append("        SUM(DECODE(KMCD1,'21',CNT,0)) AS C10, ")
            '【微少漏洩(圧)】
            strSQL.Append("        SUM(DECODE(KMCD1,'22',CNT,0)) AS C11, ")
            '【その他１】
            strSQL.Append("        SUM(DECODE(KMCD1,'03',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'32',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'33',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'34',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'35',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'3C',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'3D',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'3E',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'3I',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'3J',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'3K',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'3L',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'3M',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'3N',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'3O',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'40',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'50',DECODE(KMNM1,'逆流警告',CNT,'ベーパライザー異常',CNT,'遮断弁が閉じました',CNT,")
            strSQL.Append("        '熱源機異常',CNT,'２次側圧力が低下しました',CNT,'中間圧力異常',CNT,'エアー圧力異常',CNT,")
            strSQL.Append("        'Ｍ１ポートが動作しました。',CNT,'ボンベ庫異常',CNT,'サーモバルブ作動（ベーバ）',CNT,'緊急遮断弁／耐震遮断弁　作動',CNT,")
            strSQL.Append("        '気化器異常',CNT,0),0)) +")
            strSQL.Append("        SUM(DECODE(KMCD1,'5F',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'5J',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'5L',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'5M',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'5N',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'5P',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'5Q',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'5R',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'5T',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'5U',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'5Y',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'5Z',CNT,0)) AS C12, ")
            '【その他２】
            strSQL.Append("        SUM(DECODE(KMCD1,'12',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'13',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'17',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'18',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'23',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'24',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'25',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'26',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'3F',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'3G',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'3H',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'50',DECODE(KMNM1,'ＹＮＣＵ親機コンセント抜け',CNT,0),0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'5A',CNT,0)) AS C13, ")
            '【管理情報１】
            strSQL.Append("        SUM(DECODE(KMCD1,'19',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'20',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'27',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'28',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'29',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'30',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'31',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'36',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'37',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'38',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'39',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'3A',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'3B',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'49',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'50',DECODE(KMNM1,'バルク残量警告４０％作動',CNT,'バルク残量警告４０％',CNT,'バルク残量警告２０％作動',CNT,")
            strSQL.Append("        'バルク残量警告２０％',CNT,'自動切替が切り替わりました',CNT,'自動切替が復旧しました',CNT,'バルク警報器復旧',CNT,'ベーパーライザー復旧',CNT,")
            strSQL.Append("        '２次側圧力が正常になりました',CNT,'Ｍ１ポートが復旧しました。',CNT,'サーモバルブ復旧（ベーバ）',CNT,'ＮＣＵテスト　正常発呼',CNT,")
            strSQL.Append("        '緊急遮断弁／耐震遮断弁　回復',CNT,0),0)) +")
            strSQL.Append("        SUM(DECODE(KMCD1,'5B',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'5C',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'5D',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'5E',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'5H',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'5K',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'5O',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'5S',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'5V',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'5W',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'5X',CNT,0)) AS C14, ")
            '【管理情報２】
            strSQL.Append("        SUM(DECODE(KMCD1,'99',CNT,0)) AS C15, ")
            '2017/11/01 H.Mori mod 2017改善開発 No8-1 END 集計項目の見直し
            strSQL.Append("        SUM(DECODE(HATKBN,'2',CNT,0)) AS C16, ")
            strSQL.Append("        SUM(DECODE(HATKBN,'1',CNT,0)) AS C17, ")
            strSQL.Append("        SUM(CNT) AS C18, ")
            strSQL.Append("        SUM(SDSCNT) AS C19, ")
            strSQL.Append("        SUM(DECODE(HATKBN,'2', DECODE(TAIOKBN,'2',CNT,0),0)) AS C20, ") '2:警報＆2:出動 2010/03/10 T.Watabe add
            strSQL.Append("        SUM(DECODE(HATKBN,'1', DECODE(TAIOKBN,'2',CNT,0),0)) AS C21  ") '1:電話＆2:出動 2010/03/10 T.Watabe add
            strSQL.Append("    FROM S ")
            strSQL.Append("    GROUP BY  ")
            strSQL.Append("        KURACD, ")
            strSQL.Append("        JACD ")
            '2017/02/23 H.Mori del 改善2016 No8-1 販売事業者支所単位の削除 START
            '2015/02/13 H.Hosoda add 監視改善2014 №14 START
            'If pstrPgKbn = "5" Then '販売事業者支所単位
            '    strSQL.Append("        ,HANJICD ")
            'End If
            '2015/02/13 H.Hosoda add 監視改善2014 №14 END
            '2017/02/23 H.Mori del 改善2016 No8-1 販売事業者支所単位の削除 END
            strSQL.Append("    ) A, ")
            '2017/02/23 H.Mori mod 改善2016 No8-1 START
            If pstrPgKbn = "6" Then
                strSQL.Append("(SELECT KEN_CODE,KEN_NAME FROM CLIMAS GROUP BY KEN_CODE,KEN_NAME) B ")
            Else
                strSQL.Append("    CLIMAS B ")
            End If
            '2017/02/23 H.Mori mod 改善2016 No8-1 END
            strSQL.Append("WHERE  ")
            '2017/02/21 H.Mori mod 改善2016 No8-1 START
            If pstrPgKbn = "6" Then
                strSQL.Append("    B.KEN_CODE(+) = A.KURACD ")
            Else
                strSQL.Append("    B.CLI_CD(+) = A.KURACD ")
            End If
            '2017/02/21 H.Mori mod 改善2016 No8-1 END
            strSQL.Append("ORDER BY  ")
            strSQL.Append("    A.KURACD, ")
            strSQL.Append("    A.JACD ")
        End If

        Return strSQL.ToString

    End Function

End Class
