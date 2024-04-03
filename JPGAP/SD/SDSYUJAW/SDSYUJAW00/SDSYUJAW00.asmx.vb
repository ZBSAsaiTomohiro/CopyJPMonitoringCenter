'***********************************************
' 出動会社システム 緊急対応情報入力
'***********************************************
' 変更履歴
' 2010/04/02 T.Watabe 出動会社受付者の名称が取れていなかった点を修正

Option Explicit On 
Option Strict On

Imports Common.DB

Imports System.Text
Imports System.Web.Services

<System.Web.Services.WebService(Namespace:="http://tempuri.org/SDSYUJAW00/Service1")> _
Public Class SDSYUJAW00
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

    ' WEB サービスの例
    ' HelloWorld() サンプル サービスは、Hello World という文字列を返します。
    ' ビルドするには、以下の行からコメントを外してプロジェクトを保存、ビルドしてください。
    ' この Web サービスをテストするには、.asmx ファイルがスタート ページに設定されていることを確認し、
    ' F5 キーを押してください。
    '
    '<WebMethod()> _
    'Public Function HelloWorld() As String
    '   Return "Hello World"
    'End Function
    'pintKBN
    '   1:新規登録
    '   2:修正登録
    '   3:削除
    '************************************************
    '担当者マスタリストデータ取得
    '************************************************
    '【共通】
    '  OK : 正常に終了しました
    '   0 : 他のユーザーによってデータが更新されています。再度検索してください
    '   1 : 既にデータが存在します
    '   2 : 対象データが存在しません
    '   3 : 排他制御処理でエラーが発生しました。再度実行してください

    '2006/06/14 NEC UPDATE START
    '<WebMethod()> Public Function mSet( _
    '                                ByVal pstrKANSCD As String, _
    '                                ByVal pstrSYONO As String, _
    '                                ByVal pstrKBN As String, _
    '                                ByVal pstrTSTANCD As String, _
    '                                ByVal pstrSTD_CD As String, _
    '                                ByVal pstrSTD_KYOTEN_CD As String, _
    '                                ByVal pstrSYUTDTNM As String, _
    '                                ByVal pstrSIJIYMD As String, _
    '                                ByVal pstrSIJITIME As String, _
    '                                ByVal pstrTYAKYMD As String, _
    '                                ByVal pstrTYAKTIME As String, _
    '                                ByVal pstrSYOKANYMD As String, _
    '                                ByVal pstrSYOKANTIME As String, _
    '                                ByVal pstrAITCD As String, _
    '                                ByVal pstrMETHEIKAKU As String, _
    '                                ByVal pstrRUSUHARI As String, _
    '                                ByVal pstrKIGCD As String, _
    '                                ByVal pstrSADCD As String, _
    '                                ByVal pstrASECD As String, _
    '                                ByVal pstrSTACD As String, _
    '                                ByVal pstrFKICD As String, _
    '                                ByVal pstrJAKENREN As String, _
    '                                ByVal pstrRENTIME As String, _
    '                                ByVal pstrKIGTAIYO As String, _
    '                                ByVal pstrGASMUMU As String, _
    '                                ByVal pstrORGENIN As String, _
    '                                ByVal pstrHAIKAN As String, _
    '                                ByVal pstrGASGUMU As String, _
    '                                ByVal pstrHOSKOKAN As String, _
    '                                ByVal pstrMETYOINA As String, _
    '                                ByVal pstrTYOUYOINA As String, _
    '                                ByVal pstrVALYOINA As String, _
    '                                ByVal pstrKYUHAIUMU As String, _
    '                                ByVal pstrCOYOINA As String, _
    '                                ByVal pstrSDTBIK2 As String, _
    '                                ByVal pstrSNTTOKKI As String, _
    '                                ByVal pstrMETFUKKI As String, _
    '                                ByVal pstrHOAN As String, _
    '                                ByVal pstrGASGIRE As String, _
    '                                ByVal pstrKIGKOSYO As String, _
    '                                ByVal pstrCSNTGEN As String, _
    '                                ByVal pstrCSNTNGAS As String, _
    '                                ByVal pstrSDTBIK1 As String, _
    '                                ByVal pstrADD_DATE As String, _
    '                                ByVal pstrEDT_DATE As String, _
    '                                ByVal pstrTIME As String) As String
    ' 2014/10/30 H.Hosoda mod 2014改善開発 No11 START
    '<WebMethod()> Public Function mSet( _
    '                        ByVal pstrKANSCD As String, _
    '                        ByVal pstrSYONO As String, _
    '                        ByVal pstrKBN As String, _
    '                        ByVal pstrTSTANCD As String, _
    '                        ByVal pstrSTD_CD As String, _
    '                        ByVal pstrSTD_KYOTEN_CD As String, _
    '                        ByVal pstrSYUTDTNM As String, _
    '                        ByVal pstrSIJIYMD As String, _
    '                        ByVal pstrSIJITIME As String, _
    '                        ByVal pstrSDYMD As String, _
    '                        ByVal pstrSDTIME As String, _
    '                        ByVal pstrTYAKYMD As String, _
    '                        ByVal pstrTYAKTIME As String, _
    '                        ByVal pstrSYOKANYMD As String, _
    '                        ByVal pstrSYOKANTIME As String, _
    '                        ByVal pstrAITCD As String, _
    '                        ByVal pstrMETHEIKAKU As String, _
    '                        ByVal pstrRUSUHARI As String, _
    '                        ByVal pstrKIGCD As String, _
    '                        ByVal pstrSADCD As String, _
    '                        ByVal pstrASECD As String, _
    '                        ByVal pstrSTACD As String, _
    '                        ByVal pstrFKICD As String, _
    '                        ByVal pstrJAKENREN As String, _
    '                        ByVal pstrRENTIME As String, _
    '                        ByVal pstrKIGTAIYO As String, _
    '                        ByVal pstrGASMUMU As String, _
    '                        ByVal pstrORGENIN As String, _
    '                        ByVal pstrHAIKAN As String, _
    '                        ByVal pstrGASGUMU As String, _
    '                        ByVal pstrHOSKOKAN As String, _
    '                        ByVal pstrMETYOINA As String, _
    '                        ByVal pstrTYOUYOINA As String, _
    '                        ByVal pstrVALYOINA As String, _
    '                        ByVal pstrKYUHAIUMU As String, _
    '                        ByVal pstrCOYOINA As String, _
    '                        ByVal pstrSDTBIK2 As String, _
    '                        ByVal pstrSNTTOKKI As String, _
    '                        ByVal pstrSDTBIK3 As String, _
    '                        ByVal pstrMETFUKKI As String, _
    '                        ByVal pstrHOAN As String, _
    '                        ByVal pstrGASGIRE As String, _
    '                        ByVal pstrKIGKOSYO As String, _
    '                        ByVal pstrCSNTGEN As String, _
    '                        ByVal pstrCSNTNGAS As String, _
    '                        ByVal pstrSDTBIK1 As String, _
    '                        ByVal pstrADD_DATE As String, _
    '                        ByVal pstrEDT_DATE As String, _
    '                        ByVal pstrTIME As String) As String
    '2006/06/14 NEC UPDATE END
    <WebMethod()> Public Function mSet( _
                            ByVal pstrKANSCD As String, _
                            ByVal pstrSYONO As String, _
                            ByVal pstrKBN As String, _
                            ByVal pstrTSTANCD As String, _
                            ByVal pstrTSTANNM As String, _
                            ByVal pstrSTD_CD As String, _
                            ByVal pstrSTD_KYOTEN_CD As String, _
                            ByVal pstrSYUTDTNM As String, _
                            ByVal pstrSIJIYMD As String, _
                            ByVal pstrSIJITIME As String, _
                            ByVal pstrSDYMD As String, _
                            ByVal pstrSDTIME As String, _
                            ByVal pstrTYAKYMD As String, _
                            ByVal pstrTYAKTIME As String, _
                            ByVal pstrSYOKANYMD As String, _
                            ByVal pstrSYOKANTIME As String, _
                            ByVal pstrAITCD As String, _
                            ByVal pstrMETHEIKAKU As String, _
                            ByVal pstrRUSUHARI As String, _
                            ByVal pstrKIGCD As String, _
                            ByVal pstrSADCD As String, _
                            ByVal pstrASECD As String, _
                            ByVal pstrSTACD As String, _
                            ByVal pstrFKICD As String, _
                            ByVal pstrJAKENREN As String, _
                            ByVal pstrRENTIME As String, _
                            ByVal pstrKIGTAIYO As String, _
                            ByVal pstrGASMUMU As String, _
                            ByVal pstrORGENIN As String, _
                            ByVal pstrHAIKAN As String, _
                            ByVal pstrGASGUMU As String, _
                            ByVal pstrHOSKOKAN As String, _
                            ByVal pstrMETYOINA As String, _
                            ByVal pstrTYOUYOINA As String, _
                            ByVal pstrVALYOINA As String, _
                            ByVal pstrKYUHAIUMU As String, _
                            ByVal pstrCOYOINA As String, _
                            ByVal pstrSDTBIK2 As String, _
                            ByVal pstrSNTTOKKI As String, _
                            ByVal pstrSDTBIK3 As String, _
                            ByVal pstrMETFUKKI As String, _
                            ByVal pstrHOAN As String, _
                            ByVal pstrGASGIRE As String, _
                            ByVal pstrKIGKOSYO As String, _
                            ByVal pstrCSNTGEN As String, _
                            ByVal pstrCSNTNGAS As String, _
                            ByVal pstrSDTBIK1 As String, _
                            ByVal pstrADD_DATE As String, _
                            ByVal pstrEDT_DATE As String, _
                            ByVal pstrTIME As String) As String
        ' 2014/10/30 H.Hosoda mod 2014改善開発 No11 END
        Dim ds As New DataSet
        Dim cdb As New CDB
        Dim strRes As String
        Dim strSQL As StringBuilder

        Dim strTAIO_ST_DATE As String
        Dim strTAIO_ST_TIME As String
        '2006/06/23 NEC ADD START
        Dim strTMSKB_NAI As String
        '2006/06/23 NEC ADD END

        strRes = "OK"

        '接続OPEN----------------------------------------
        Try
            cdb.mOpen()
        Catch ex As Exception
            strRes = ex.ToString
            Return strRes
        Finally
        End Try

        Try
            'トランザクション開始--------------------------
            cdb.mBeginTrans()

            '*********************************
            '処理ストーリー
            '・排他のチェックを行う。
            '・修正時にはデータは存在すること
            '*********************************

            'ＤＢチェック(基本)-----------------------------
            strSQL = New StringBuilder("")
            strSQL.Append("SELECT ")
            strSQL.Append(" EDT_DATE, ")             '更新日
            strSQL.Append(" EDT_TIME, ")              '更新時間
            strSQL.Append(" TAIO_ST_DATE ,")              '更新時間
            strSQL.Append(" TAIO_ST_TIME ")              '更新時間
            strSQL.Append("FROM ")
            strSQL.Append("D20_TAIOU ")              '対応ＤＢ
            strSQL.Append("WHERE KANSCD = :KANSCD ") '監査コード
            strSQL.Append("AND   SYONO  = :SYONO  ") '処理番号
            strSQL.Append("FOR UPDATE NOWAIT ")      '排他制御をかける

            'SQL文セット
            cdb.pSQL = strSQL.ToString

            'パラメータに値をセット
            cdb.pSQLParamStr("KANSCD") = pstrKANSCD   '区分
            cdb.pSQLParamStr("SYONO") = pstrSYONO     'コード
            'SQL実行
            cdb.mExecQuery()
            ds = cdb.pResult

            '*****************************************************
            '修正時同じキーのデータが存在しない場合はエラーとする
            '*****************************************************
            If (ds.Tables(0).Rows.Count = 0) Then
                strRes = "2"
                Exit Try
            End If
            '*****************************************************
            '修正時で受け渡された日付及び時間と更新対象データが異なる場合エラー
            '*****************************************************
            If ((Convert.ToString(ds.Tables(0).Rows(0).Item("EDT_DATE")) <> pstrEDT_DATE) Or _
                (Convert.ToString(ds.Tables(0).Rows(0).Item("EDT_TIME")) <> pstrTIME)) Then
                strRes = "0"
                Exit Try
            End If
            strTAIO_ST_DATE = Convert.ToString(ds.Tables(0).Rows(0).Item("TAIO_ST_DATE"))
            strTAIO_ST_TIME = Convert.ToString(ds.Tables(0).Rows(0).Item("TAIO_ST_TIME"))

            '名称の取得（画面からはコードのみの取得をしているもの)

            ' 2014/10/30 H.Hosoda del 2014改善開発 No11 START
            '//受信者名
            'Dim strTSTANNM As String = fncGET_TANNM(pstrSTD_CD, pstrTSTANCD) ' 2010/04/02 T.Watabe edit
            'Dim strTSTANNM As String = fncGET_TANNM(pstrSTD_CD + pstrSTD_KYOTEN_CD, pstrTSTANCD) '出動会社ｺｰﾄﾞ＋拠点ｺｰﾄﾞ、出動会社受付者で検索
            'If strTSTANNM = "" Then
            '    strTSTANNM = fncGET_TANNM(pstrSTD_CD, pstrTSTANCD) '出動会社ｺｰﾄﾞ、出動会社受付者で検索
            'End If
            ' 2014/10/30 H.Hosoda del 2014改善開発 No11 END

            '//所属
            'Dim strSTD As String = fncGET_KYOTEN(pstrSTD_CD) 2008/02/07 T.Watabe edit 所属が更新されないバグを修正
            'Dim strSTD As String = fncGET_KYOTEN(pstrSTD_KYOTEN_CD)
            'Dim strSTD_KYOTEN As String = fncGET_KYOTEN(pstrSTD_KYOTEN_CD) 2008/02/14 T.Watabe edit
            Dim strSTD_KYOTEN As String = fncGET_KYOTEN(pstrSTD_CD, pstrSTD_KYOTEN_CD)
            '//対応相手
            Dim strAITNM As String = fncGET_PULLNM("12", pstrAITCD)
            '//器具原因
            Dim strKIGNM As String = fncGET_PULLNM("51", pstrKIGCD)
            '//作動原因
            Dim strSADNM As String = fncGET_PULLNM("52", pstrSADCD)
            '//作動原因
            'Dim strASENM As String = fncGET_PULLNM("53", pstrASECD) ' 2008/10/16 T.Watabe edit
            Dim strASENM As String = ""
            '//その他原因
            'Dim strSTANM As String = fncGET_PULLNM("54", pstrSTACD) ' 2008/10/16 T.Watabe edit
            Dim strSTANM As String = ""
            '//復帰操作
            Dim strFKINM As String = fncGET_PULLNM("55", pstrFKICD)

            '2006/06/23 NEC ADD START
            '*****************************************************
            '処理区分名の取得
            '*****************************************************
            strSQL = New StringBuilder("")
            strSQL.Append("SELECT NAME FROM M06_PULLDOWN WHERE KBN='10' AND CD=:CD")
            'SQL文セット
            cdb.pSQL = strSQL.ToString

            'パラメータに値をセット
            cdb.pSQLParamStr("CD") = pstrKBN   'コード
            'SQL実行
            cdb.mExecQuery()
            ds = cdb.pResult
            strTMSKB_NAI = Convert.ToString(ds.Tables(0).Rows(0).Item("NAME"))

            '2006/06/23 NEC ADD END

            '*****************************************************
            '対応ＤＢの更新処理
            '*****************************************************
            strSQL = New StringBuilder("")
            strSQL.Append("UPDATE D20_TAIOU ")
            strSQL.Append("SET TSTANCD    = :TSTANCD ")                     '受信者コード
            strSQL.Append("   ,TSTANNM    = :TSTANNM ")                     '受信者氏名
            strSQL.Append("   ,STD_KYOTEN_CD = :STD_KYOTEN_CD ")            '出動会社拠点コード '2008/02/08 T.Watabe add
            strSQL.Append("   ,STD_KYOTEN    = :STD_KYOTEN ")               '出動会社拠点名     '2008/02/08 T.Watabe add

            '2008/10/15 T.Watabe del 出動会社の処理完了日のみを更新するように変更
            'If pstrKBN = "2" Then
            '    '//対応完了
            '    strSQL.Append("   ,SYOYMD     = REPLACE(:SYOKANYMD,'/')")   '処理完了日
            '    strSQL.Append("   ,SYOTIME    = REPLACE(:SYOKANTIME,':')")  '処理完了時間
            '    strSQL.Append("   ,TAIO_SYO_TIME    = :TAIO_SYO_TIME   ")   '所要時間
            'Else
            '    '//対応中　※対応完了日は削除する
            '    strSQL.Append("   ,SYOYMD  = '' ")                          '処理完了日
            '    strSQL.Append("   ,SYOTIME = '' ")                          '処理完了時間
            '    strSQL.Append("   ,TAIO_SYO_TIME = ''   ")                  '所要時間
            'End If

            strSQL.Append("   ,SYUTDTNM   = :SYUTDTNM  ")                   '出動対応者
            strSQL.Append("   ,SIJIYMD    = REPLACE(:SIJIYMD,'/')     ")    '出動指示日付
            strSQL.Append("   ,SIJITIME   = REPLACE(:SIJITIME,':')    ")    '出動指示時刻
            strSQL.Append("   ,SDYMD    = REPLACE(:SDYMD,'/')   ")          '出動日  ' 2008/10/14 T.Watabe add
            strSQL.Append("   ,SDTIME   = REPLACE(:SDTIME,':')  ")          '出動時間  ' 2008/10/14 T.Watabe add
            strSQL.Append("   ,TYAKYMD    = REPLACE(:TYAKYMD,'/')   ")      '到着日
            strSQL.Append("   ,TYAKTIME   = REPLACE(:TYAKTIME,':')  ")      '到着時間
            strSQL.Append("   ,SYOKANYMD  = REPLACE(:SYOKANYMD,'/') ")      '処理完了日
            strSQL.Append("   ,SYOKANTIME = REPLACE(:SYOKANTIME,':')")      '処理完了時間
            strSQL.Append("   ,AITCD      = :AITCD     ")                   '対応相手
            strSQL.Append("   ,AITNM      = :AITNM     ")                   '対応相手名
            strSQL.Append("   ,METHEIKAKU = :METHEIKAKU")                   '不在時の措置　メータ遮断弁閉止確認 1:有
            strSQL.Append("   ,RUSUHARI   = :RUSUHARI  ")                   '不在時の措置　留守宅表示の貼付　 1:有
            strSQL.Append("   ,KIGCD      = :KIGCD     ")                   '器具原因コード	
            strSQL.Append("   ,KIGNM      = :KIGNM     ")                   '器具原因名称	
            strSQL.Append("   ,SADCD      = :SADCD     ")                   '作動原因コード	
            strSQL.Append("   ,SADNM      = :SADNM     ")                   '作動原因名称	
            strSQL.Append("   ,ASECD      = :ASECD     ")                   '圧力センサー作動原因
            strSQL.Append("   ,ASENM      = :ASENM     ")                   '圧力センサー作動原因
            strSQL.Append("   ,STACD      = :STACD     ")                   'その他原因コード
            strSQL.Append("   ,STANM      = :STANM     ")                   'その他原因名称
            strSQL.Append("   ,FKICD      = :FKICD     ")                   '復帰操作コード
            strSQL.Append("   ,FKINM      = :FKINM     ")                   '復帰操作名称
            strSQL.Append("   ,JAKENREN   = :JAKENREN  ")                   'ＪＡ／県連への連絡相手
            strSQL.Append("   ,RENTIME    = REPLACE(:RENTIME,':')   ")      'ＪＡ／県連への連絡時間
            strSQL.Append("   ,KIGTAIYO   = :KIGTAIYO  ")                   '簡易ガス器具の貸与　1：有
            strSQL.Append("   ,GASMUMU    = :GASMUMU   ")                   'ガス漏れ点検　0：有　1：無
            strSQL.Append("   ,ORGENIN    = :ORGENIN   ")                   'ガス漏れ点検有　原因　ガス器具　1:有
            strSQL.Append("   ,HAIKAN     = :HAIKAN    ")                   'ガス漏れ点検有　原因　配管　1:有
            strSQL.Append("   ,GASGUMU    = :GASGUMU   ")                   'ガス切れ確認　0：有　1：無
            strSQL.Append("   ,HOSKOKAN   = :HOSKOKAN  ")                   'ゴムホース交換　0：実施　1：未実施
            strSQL.Append("   ,METYOINA   = :METYOINA  ")                   'その他点検　メータ　0：良　1：否
            strSQL.Append("   ,TYOUYOINA  = :TYOUYOINA ")                   'その他点検　調整器　0：良　1：否
            strSQL.Append("   ,VALYOINA   = :VALYOINA  ")                   'その他点検　容器・中間バルブ　0：良　1：否
            strSQL.Append("   ,KYUHAIUMU  = :KYUHAIUMU ")                   'その他点検　吸排気口　0：有　1：無
            strSQL.Append("   ,COYOINA    = :COYOINA   ")                   'その他点検　ＣＯ濃度　0：良　1：否
            strSQL.Append("   ,SDTBIK2    = :SDTBIK2   ")                   '特記事項
            strSQL.Append("   ,SNTTOKKI   = :SNTTOKKI  ")                   'その他特記事項
            strSQL.Append("   ,SDTBIK3    = :SDTBIK3   ")                   '出動結果内容/報告 '2006/06/15 NEC UPDATE
            'strSQL.Append("   ,TMSKB     = :TMSKB     ")                   '処理区分 ' 2008/10/15 T.Watabe edit
            strSQL.Append("   ,SDSKBN     = :SDSKBN     ")                  '出動会社処理区分
            'strSQL.Append("   ,TMSKB_NAI = :TMSKB_NAI ")                   '処理区分名 '2006/06/23 NEC ADD
            strSQL.Append("   ,SDSKBN_NAI = :SDSKBN_NAI ")                  '出動会社処理区分名  ' 2008/10/15 T.Watabe edit
            strSQL.Append("   ,METFUKKI   = :METFUKKI  ")                   'その他特記事項
            strSQL.Append("   ,HOAN       = :HOAN  ")                       'その他特記事項
            strSQL.Append("   ,GASGIRE    = :GASGIRE  ")                    'その他特記事項
            strSQL.Append("   ,KIGKOSYO   = :KIGKOSYO  ")                   'その他特記事項
            strSQL.Append("   ,CSNTGEN    = :CSNTGEN  ")                    'その他特記事項
            strSQL.Append("   ,CSNTNGAS   = :CSNTNGAS  ")                   'その他特記事項
            strSQL.Append("   ,SDTBIK1    = :SDTBIK1  ")                    'その他特記事項
            strSQL.Append("   ,EDT_DATE   = TO_CHAR(SYSDATE,'YYYYMMDD')  ") '更新日付
            strSQL.Append("   ,EDT_TIME   = TO_CHAR(SYSDATE,'HH24MISS')  ") '更新時間
            strSQL.Append("WHERE KANSCD   = :KANSCD ")                      '監査コード
            strSQL.Append("AND   SYONO    = :SYONO ")                       '処理番号

            'SQL文セット
            cdb.pSQL = strSQL.ToString

            cdb.pSQLParamStr("KANSCD") = pstrKANSCD   '区分
            cdb.pSQLParamStr("SYONO") = pstrSYONO     'コード

            cdb.pSQLParamStr("TSTANCD") = pstrTSTANCD               '受信者コード
            ' 2014/10/30 H.Hosoda mod 2014改善開発 No11 START
            'cdb.pSQLParamStr("TSTANNM") = strTSTANNM                '受信者氏名
            cdb.pSQLParamStr("TSTANNM") = pstrTSTANNM                '受信者氏名
            ' 2014/10/30 H.Hosoda mod 2014改善開発 No11 END
            'cdb.pSQLParamStr("STD_CD") = pstrSTD_CD                '出動会社コード
            'cdb.pSQLParamStr("STD") = strSTD                       '出動会社名
            cdb.pSQLParamStr("STD_KYOTEN_CD") = pstrSTD_KYOTEN_CD   '出動会社拠点コード '2008/02/08 T.Watabe add
            cdb.pSQLParamStr("STD_KYOTEN") = strSTD_KYOTEN          '出動会社拠点名     '2008/02/08 T.Watabe add
            cdb.pSQLParamStr("SYUTDTNM") = pstrSYUTDTNM             '出動対応者
            cdb.pSQLParamStr("SIJIYMD") = pstrSIJIYMD               '対応受信日（警報受信日）
            cdb.pSQLParamStr("SIJITIME") = pstrSIJITIME             '対応時刻（受信時刻）
            cdb.pSQLParamStr("SDYMD") = pstrSDYMD                   '出動日 ' 2008/10/14 T.Watabe add
            cdb.pSQLParamStr("SDTIME") = pstrSDTIME                 '出動時間 ' 2008/10/14 T.Watabe add
            cdb.pSQLParamStr("TYAKYMD") = pstrTYAKYMD               '到着日
            cdb.pSQLParamStr("TYAKTIME") = pstrTYAKTIME             '到着時間
            cdb.pSQLParamStr("SYOKANYMD") = pstrSYOKANYMD           '処理完了日
            cdb.pSQLParamStr("SYOKANTIME") = pstrSYOKANTIME         '処理完了時間
            cdb.pSQLParamStr("AITCD") = pstrAITCD                   '対応相手
            cdb.pSQLParamStr("AITNM") = strAITNM                    '対応相手名
            cdb.pSQLParamStr("METHEIKAKU") = pstrMETHEIKAKU         '不在時の措置　メータ遮断弁閉止確認 1:有
            cdb.pSQLParamStr("RUSUHARI") = pstrRUSUHARI             '不在時の措置　留守宅表示の貼付　 1:有
            cdb.pSQLParamStr("KIGCD") = pstrKIGCD                   '器具原因コード	
            cdb.pSQLParamStr("KIGNM") = strKIGNM                    '器具原因名称	
            cdb.pSQLParamStr("SADCD") = pstrSADCD                   '作動原因コード	
            cdb.pSQLParamStr("SADNM") = strSADNM                    '作動原因名称	
            cdb.pSQLParamStr("ASECD") = pstrASECD                   '圧力センサー作動原因
            cdb.pSQLParamStr("ASENM") = strASENM                    '圧力センサー作動原因
            cdb.pSQLParamStr("STACD") = pstrSTACD                   'その他原因コード
            cdb.pSQLParamStr("STANM") = strSTANM                    'その他原因名称
            cdb.pSQLParamStr("FKICD") = pstrFKICD                   '復帰操作コード
            cdb.pSQLParamStr("FKINM") = strFKINM                    '復帰操作名称
            cdb.pSQLParamStr("JAKENREN") = pstrJAKENREN             'ＪＡ／県連への連絡相手
            cdb.pSQLParamStr("RENTIME") = pstrRENTIME               'ＪＡ／県連への連絡時間
            cdb.pSQLParamStr("KIGTAIYO") = pstrKIGTAIYO             '簡易ガス器具の貸与　1：有
            cdb.pSQLParamStr("GASMUMU") = pstrGASMUMU               'ガス漏れ点検　0：有　1：無
            cdb.pSQLParamStr("ORGENIN") = pstrORGENIN               'ガス漏れ点検有　原因　ガス器具　1:有
            cdb.pSQLParamStr("HAIKAN") = pstrHAIKAN                 'ガス漏れ点検有　原因　配管　1:有
            cdb.pSQLParamStr("GASGUMU") = pstrGASGUMU               'ガス切れ確認　0：有　1：無
            cdb.pSQLParamStr("HOSKOKAN") = pstrHOSKOKAN             'ゴムホース交換　0：実施　1：未実施
            cdb.pSQLParamStr("METYOINA") = pstrMETYOINA             'その他点検　メータ　0：良　1：否
            cdb.pSQLParamStr("TYOUYOINA") = pstrTYOUYOINA           'その他点検　調整器　0：良　1：否
            cdb.pSQLParamStr("VALYOINA") = pstrVALYOINA             'その他点検　容器・中間バルブ　0：良　1：否
            cdb.pSQLParamStr("KYUHAIUMU") = pstrKYUHAIUMU           'その他点検　吸排気口　0：有　1：無
            cdb.pSQLParamStr("COYOINA") = pstrCOYOINA               'その他点検　ＣＯ濃度　0：良　1：否
            cdb.pSQLParamStr("SDTBIK2") = pstrSDTBIK2               '特記事項
            cdb.pSQLParamStr("SNTTOKKI") = pstrSNTTOKKI             'その他特記事項
            cdb.pSQLParamStr("SDTBIK3") = pstrSDTBIK3               '出動結果内容/報告 '2006/06/15 NEC UPDATE
            'cdb.pSQLParamStr("TMSKB") = pstrKBN                    '処理区分 ' 2008/10/15 T.Watabe edit
            cdb.pSQLParamStr("SDSKBN") = pstrKBN                    '出動会社処理区分
            'cdb.pSQLParamStr("TMSKB_NAI") = strTMSKB_NAI           '処理区分名 '2006/06/23 NEC ADD ' 2008/10/15 T.Watabe edit
            cdb.pSQLParamStr("SDSKBN_NAI") = strTMSKB_NAI           '出動会社処理区分名
            cdb.pSQLParamStr("METFUKKI") = pstrMETFUKKI             '
            cdb.pSQLParamStr("HOAN") = pstrHOAN                     '
            cdb.pSQLParamStr("GASGIRE") = pstrGASGIRE               '
            cdb.pSQLParamStr("KIGKOSYO") = pstrKIGKOSYO             '
            cdb.pSQLParamStr("CSNTGEN") = pstrCSNTGEN               '
            cdb.pSQLParamStr("CSNTNGAS") = pstrCSNTNGAS             '
            cdb.pSQLParamStr("SDTBIK1") = pstrSDTBIK1               '

            ' 2008/10/16 T.Watabe del
            'If pstrKBN = "2" Then
            '    If strTAIO_ST_DATE.Length > 0 And strTAIO_ST_TIME.Length > 0 Then
            '        '処理開始日が設定されているときのみ計算
            '        cdb.pSQLParamStr("TAIO_SYO_TIME") = CStr(fncDateDiff(strTAIO_ST_DATE, strTAIO_ST_TIME, pstrSYOKANYMD, pstrSYOKANTIME))
            '    Else
            '        cdb.pSQLParamStr("TAIO_SYO_TIME") = ""
            '    End If
            'End If

            'SQLを実行
            cdb.mExecNonQuery()
            'コミット
            cdb.mCommit()
        Catch ex As Exception
            'エラーが起きたら エラー内容を格納
            strRes = ex.ToString

            '排他制御処理エラー
            If ErrorToString.Substring(0, 9) = "ORA-00054" Then
                Return "3"
            End If

            'ロールバック
            cdb.mRollback()
            strRes = strRes & cdb.pErr
        Finally
            '接続クローズ
            cdb.mClose()
        End Try

        cdb = Nothing

        Return strRes

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
    '*　概　要：担当者マスタを検索し、コードから名称を取得する
    '******************************************************************************
    Private Function fncGET_TANNM(ByVal pstrCD As String, ByVal pstrTANCD As String) As String
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
        strSQL.Append("TANNM AS NAME ")
        strSQL.Append("FROM M05_TANTO ")
        strSQL.Append("WHERE KBN = '2' ")
        strSQL.Append("  AND KURACD = 'ZZZZ' ")
        'strSQL.Append("  AND CODE = :CODE  ") 2010/04/02 T.Watabe edit
        strSQL.Append("  AND CODE LIKE :CODE || '%'  ")
        strSQL.Append("  AND TANCD = :TANCD ")
        strSQL.Append("ORDER BY TANCD ")

        'SQL文セット
        cdb.pSQL = strSQL.ToString
        'パラメータセット
        cdb.pSQLParamStr("CODE") = pstrCD         '//コード
        cdb.pSQLParamStr("TANCD") = pstrTANCD         '//コード
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
    '*　概　要：担当者マスタを検索し、コードから名称を取得する
    '******************************************************************************
    Private Function fncGET_KYOTEN(ByVal pstrSHUTU_CD As String, ByVal pstrKYOTEN_CD As String) As String
        Dim ds As New DataSet
        Dim cdb As New CDB
        Dim strRes As String
        Dim strSQL As StringBuilder
        strRes = ""

        '値がない場合は空を返す
        If pstrSHUTU_CD.Length = 0 Then
            Return strRes
        End If
        If pstrKYOTEN_CD.Length = 0 Then
            Return strRes
        End If

        'ＤＢオープン
        cdb.mOpen()
        'SQL作成
        strSQL = New StringBuilder("")
        strSQL.Append("SELECT ")
        strSQL.Append("    KYOTEN_NAME AS NAME ")
        strSQL.Append("FROM ")
        strSQL.Append("    SHUTUDOMAS ")
        strSQL.Append("WHERE ")
        strSQL.Append("        SHUTU_CD  = :SHUTU_CD ")
        strSQL.Append("    AND KYOTEN_CD = :KYOTEN_CD ")
        strSQL.Append("    AND KUBUN = '1' ")

        'SQL文セット
        cdb.pSQL = strSQL.ToString
        'パラメータセット
        cdb.pSQLParamStr("SHUTU_CD") = pstrSHUTU_CD         '// 出動会社コード
        cdb.pSQLParamStr("KYOTEN_CD") = pstrKYOTEN_CD       '// 拠点コード
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
    '*　概　要：所要時間の作成
    '******************************************************************************
    Private Function fncDateDiff(ByVal strSTDate As String, ByVal strSTTime As String, _
                                ByVal strEDDate As String, ByVal strEDTime As String) As Long
        Dim DatTim1 As Date
        Dim DatTim2 As Date

        Dim lngRec As Long

        If strSTDate.Length = 0 Or strSTTime.Length = 0 Then
            lngRec = 0
        End If

        strSTDate = strSTDate.Substring(0, 4) & "/" & strSTDate.Substring(4, 2) & "/" & strSTDate.Substring(6, 2)
        strSTTime = strSTTime.Substring(0, 2) & ":" & strSTTime.Substring(2, 2) & ":" & strSTTime.Substring(4, 2)
        'strEDDate = strEDDate.Substring(0, 4) & "/" & strEDDate.Substring(4, 2) & "/" & strEDDate.Substring(6, 2)
        'strEDTime = strEDTime.Substring(0, 2) & ":" & strEDTime.Substring(2, 2) & ":" & strEDTime.Substring(4, 2)

        DatTim1 = CDate(strSTDate & " " & strSTTime)
        DatTim2 = CDate(strEDDate & " " & strEDTime)

        lngRec = DateDiff(DateInterval.Minute, DatTim1, DatTim2)

        If lngRec > 99999 Then
            lngRec = 99999
        ElseIf lngRec < -9999 Then
            lngRec = -9999
        End If

        Return lngRec
    End Function

End Class
