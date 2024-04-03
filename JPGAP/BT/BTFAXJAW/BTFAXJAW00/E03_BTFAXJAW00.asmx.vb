'***********************************************
'対応内容明細（ＦＡＸ）　帳票出力
'***********************************************
' 変更履歴
' 2008/10/14 T.Watabe 項目タイトル「対応日」を「完了日時」に変更
' 2008/10/14 T.Watabe 出動会社欄に受信日時(出動指示日＆時刻)、出動日時を追加
' 2008/10/21 T.Watabe 出動会社処理区分・内容を表示
' 2008/11/04 T.Watabe FAX1枚が１ページに収まらないので1行不要な行を出力しないように変更。
' 2010/05/24 T.Watabe FAX送信先、ﾒｰﾙ送信先、それぞれ複数設定を可能に改良。
' 2010/09/14 T.Watabe 旧PG(BTFAXJAE00)からも参照できるようにﾒｿｯﾄﾞを追加
'                           旧からはmExcel,新からはmExcel2を呼び出し
' 2010/09/15 T.Watabe DB SIDを戻すﾒｿｯﾄﾞを追加
' 2010/09/17 T.Watabe FAXが一枚に収まらないので、縮小拡大率を93から90へ変更。
' 2010/10/06 T.Watabe FAXが一枚に収まらない問題の対応(余白を削る。ﾃﾞｰﾀが無い行は詰める)
' 2010/12/21 T.Watabe ｸﾗｲｱﾝﾄ送信の際の条件不備を修正
' 2011/03/10 T.Watabe 圧縮ファイル名の先頭にｸﾗｲｱﾝﾄｺｰﾄﾞを付与
' 2011/03/10 T.Watabe 自動区分の3:FAX,ﾒｰﾙ送信両方に対応するように変更

Option Explicit On 
Option Strict On

Imports Common
Imports Common.DB

Imports System.Web.Services
Imports System.Configuration
Imports System.Text

'Imports java.util.zip 'vjslib.dllへの参照設定が必要です 

<System.Web.Services.WebService(Namespace:="http://tempuri.org/BTFAXJAW00/BTFAXJAW00")> _
Public Class BTFAXJAW00
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

    'プログラムＩＤ
    Dim strPGID As String

    Const strFAXKBN As String = "1"  'FAX送信
    Const strMAILKBN As String = "2" 'ﾒｰﾙ送信
    Const strBoth As String = "3"    'FAX,ﾒｰﾙ両方

    '******************************************************************************
    '*　概　要：監視センターの存在チェック
    '*　備　考：
    '******************************************************************************
    <WebMethod()> Public Function mChkKans( _
                                        ByVal pstrKANSI_CD As String, _
                                        ByRef pstrKANSI_NAME As String, _
                                        ByRef pstrKANSI_KANA As String, _
                                        ByRef pstrTEL As String, _
                                        ByRef pstrKINKYU_TEL As String, _
                                        ByRef pstrPOST_NO As String, _
                                        ByRef pstrADDRESS1 As String, _
                                        ByRef pstrADDRESS2 As String, _
                                        ByRef pstrBIKOU As String) As String
        '--------------------------------------------------
        Dim cdb As New CDB
        Dim strSQL As New StringBuilder("")
        Dim ds As New DataSet
        Dim dr As DataRow
        Dim strRec As String

        strRec = "OK"

        '---------------------------------------------
        'プールの最小値設定
        '---------------------------------------------
        cdb.pConnectPoolSize = 1

        '--------------------------------------------------
        '接続OPEN
        Try
            cdb.mOpen()
        Catch ex As Exception
            Return ex.ToString
        Finally

        End Try

        '--------------------------------------------------
        Try
            'データのSELECT
            strSQL = New StringBuilder("")
            'SQL作成開始
            strSQL.Append("SELECT ")
            strSQL.Append("    KANSI_NAME, ")
            strSQL.Append("    KANSI_KANA, ")
            strSQL.Append("    TEL, ")
            strSQL.Append("    KINKYU_TEL, ")
            strSQL.Append("    POST_NO, ")
            strSQL.Append("    ADDRESS1, ")
            strSQL.Append("    ADDRESS2, ")
            strSQL.Append("    BIKOU ")
            strSQL.Append("FROM  KANSIMAS ")
            strSQL.Append("WHERE KANSI_CD = :KANSI_CD ")
            '//パラメータセット
            cdb.pSQLParamStr("KANSI_CD") = pstrKANSI_CD
            '//SQLセット
            cdb.pSQL = strSQL.ToString
            '//SQL実行
            cdb.mExecQuery()
            '//データセットに格納
            ds = cdb.pResult
            '//データが存在しない場合
            If ds.Tables(0).Rows.Count = 0 Then
                '//データが0件であることを示す文字列を返す
                Return "DATA0"
            End If
            '//データローにデータを格納
            dr = ds.Tables(0).Rows(0)
            '//データの取得
            pstrKANSI_NAME = Convert.ToString(dr.Item("KANSI_NAME"))
            pstrKANSI_KANA = Convert.ToString(dr.Item("KANSI_KANA"))
            pstrTEL = Convert.ToString(dr.Item("TEL"))
            pstrKINKYU_TEL = Convert.ToString(dr.Item("KINKYU_TEL"))
            pstrPOST_NO = Convert.ToString(dr.Item("POST_NO"))
            pstrADDRESS1 = Convert.ToString(dr.Item("ADDRESS1"))
            pstrADDRESS2 = Convert.ToString(dr.Item("ADDRESS2"))
            pstrBIKOU = Convert.ToString(dr.Item("BIKOU"))

        Catch ex As Exception
            strRec = "ERROR:" & ex.ToString
        Finally
            '接続クローズ
            cdb.mClose()
        End Try

        Return strRec
    End Function

    ' 2010/09/14 T.Watabe add 旧PG(BTFAXJAE00)からも参照できるようにﾒｿｯﾄﾞを追加
    '                           旧からはmExcel,新からはmExcel2を呼び出し
    '******************************************************************************
    '*　概　要：監視センター対応内容明細（ＦＡＸ）の出力
    '*　備　考：
    '******************************************************************************
    <WebMethod()> Public Function mExcel( _
                                        ByVal pstrKANSI_CODE As String, _
                                        ByVal pstrSESSION As String, _
                                        ByVal pstrTAISYOUBI As String, _
                                        ByVal pstrKURACD_F As String, _
                                        ByVal pstrKURACD_T As String, _
                                        ByVal pstrCreateFilePath As String, _
                                        ByVal pstrSEND_JALP_NAME As String, _
                                        ByVal pstrSEND_CENT_NAME As String _
                                       ) As String

        Return mExcel2(pstrKANSI_CODE, _
                        pstrSESSION, _
                        pstrTAISYOUBI, _
                        pstrKURACD_F, _
                        pstrKURACD_T, _
                        pstrCreateFilePath, _
                        pstrSEND_JALP_NAME, _
                        pstrSEND_CENT_NAME, _
                        "1") '未指定は1:販売所とする。
    End Function
    '******************************************************************************
    '*　概　要：監視センター対応内容明細（ＦＡＸ）の出力
    '*　備　考：
    '******************************************************************************
    '--- ↓2005/09/10 MOD Falcon↓ ---  '自動ＦＡＸ締め時刻削除
    '--- ↓2005/09/06 MOD Falcon↓ ---  '自動ＦＡＸ締め時刻追加
    ' 引数
    ' pstrSEND_KBN 送信区分 1:販売所(JA・支所)/2:ｸﾗｲｱﾝﾄ
    <WebMethod()> Public Function mExcel2( _
                                        ByVal pstrKANSI_CODE As String, _
                                        ByVal pstrSESSION As String, _
                                        ByVal pstrTAISYOUBI As String, _
                                        ByVal pstrKURACD_F As String, _
                                        ByVal pstrKURACD_T As String, _
                                        ByVal pstrCreateFilePath As String, _
                                        ByVal pstrSEND_JALP_NAME As String, _
                                        ByVal pstrSEND_CENT_NAME As String, _
                                        ByVal pstrSEND_KBN As String _
                                       ) As String
        '--- ↑2005/09/06 MOD Falcon↑ ---
        '--- ↑2005/09/10 MOD Falcon↑ ---

        '--------------------------------------------------
        '自動ＦＡＸ番号に入力された番号毎にＦＡＸ送信・ファイル作成を行う
        Dim cdb As New cdb
        Dim strSQL As New StringBuilder("")
        Dim ds As New DataSet
        Dim dr As DataRow
        Dim strRec As String

        '--------------------------------------------------
        'プログラムＩＤ(作成帳票に使用)
        strPGID = "BTFAXJAX00"

        '---------------------------------------------
        'プールの最小値設定
        '---------------------------------------------
        cdb.pConnectPoolSize = 1

        '--------------------------------------------------
        '接続OPEN
        Try
            cdb.mOpen()
        Catch ex As Exception
            Return ex.ToString
        Finally

        End Try

        '--------------------------------------------------
        '対象日の検索条件の設定
        '対応済みのデータで
        '対応完了日がシステム日付の前の日の締め日からシステム日付の締め日まで

        Dim strTaisyoStDT As String '開始日 2008/10/14 T.Watabe edit
        Dim strTaisyoEdDT As String '終了日 2008/10/14 T.Watabe edit
        strTaisyoStDT = fncAdd_Date(pstrTAISYOUBI, -1) & ConfigurationSettings.AppSettings("JIDOFAXSIME")
        strTaisyoEdDT = pstrTAISYOUBI & ConfigurationSettings.AppSettings("JIDOFAXSIME")

        Dim strWHERE_TAIOU As New StringBuilder("")
        Dim strWHERE_CLI As New StringBuilder("") '2010/12/21 T.Watabe add
        If pstrSEND_KBN = "1" Then '送信区分 1:販売所(JA・支所)/2:ｸﾗｲｱﾝﾄ
            strWHERE_TAIOU.Append("  AND TAI.FAXKBN = '2' ")            '//ＦＡＸ必要(JA)
        Else
            strWHERE_TAIOU.Append("  AND TAI.FAXKURAKBN = '2' ")        '//ＦＡＸ必要(ｸﾗｲｱﾝﾄ供給ｾﾝﾀ)
        End If
        strWHERE_TAIOU.Append("  AND TAI.TMSKB = '2' ")             '//処理済み
        '--- ↓2005/09/10 MOD Falcon↓ ---  
        '2005/09/06の修正を元に戻す
        strWHERE_TAIOU.Append("  AND ( ")
        strWHERE_TAIOU.Append("          (TAI.SYOYMD || TAI.SYOTIME > '" & strTaisyoStDT & "' ")
        strWHERE_TAIOU.Append("          AND TAI.SYOYMD || TAI.SYOTIME   <='" & strTaisyoEdDT & "') ")
        '--- ↓2005/09/06 MOD Falcon↓ ---
        '自動ＦＡＸ締め時刻を監視センター毎にexeCONFIGファイルに設定
        'strWHERE_TAIOU.Append("  AND ((TAI.SYOYMD || TAI.SYOTIME > '" & fncAdd_Date(pstrTAISYOUBI, -1) & pstrJIDOFAXSIME & "' ")
        'strWHERE_TAIOU.Append("  AND TAI.SYOYMD || TAI.SYOTIME   <='" & pstrTAISYOUBI & pstrJIDOFAXSIME & "') ")
        'strWHERE_TAIOU.Append("  AND ((TAI.SYOYMD || TAI.SYOTIME > '" & strTaisyoStDT & "' ")
        'strWHERE_TAIOU.Append("  AND TAI.SYOYMD || TAI.SYOTIME   <='" & strTaisyoEdDT & "') ")
        '--- ↑2005/09/06 MOD Falcon↑ ---
        '--- ↑2005/09/10 MOD Falcon↑ ---

        '--- ↓2005/09/10 MOD Falcon↓ --- 
        '2005/09/06の修正を元に戻す
        strWHERE_TAIOU.Append("      OR  ")
        strWHERE_TAIOU.Append("          (TAI.SYOKANYMD || TAI.SYOKANTIME > '" & strTaisyoStDT & "' ")
        strWHERE_TAIOU.Append("          AND TAI.SYOKANYMD || TAI.SYOKANTIME <='" & strTaisyoEdDT & "') ")
        strWHERE_TAIOU.Append("      ) ")
        '--- ↓2005/09/06 MOD Falcon↓ ---
        '自動ＦＡＸ締め時刻を監視センター毎にexeCONFIGファイルに設定
        'strWHERE_TAIOU.Append("  OR (TAI.SYOKANYMD || TAI.SYOKANTIME > '" & fncAdd_Date(pstrTAISYOUBI, -1) & pstrJIDOFAXSIME & "' ")
        'strWHERE_TAIOU.Append("  AND TAI.SYOKANYMD || TAI.SYOKANTIME <='" & pstrTAISYOUBI & pstrJIDOFAXSIME & "')) ")
        '--- ↓2005/05/23 MOD Falcon↓ ---
        'strWHERE_TAIOU.Append("  OR (TAI.SYOKANYMD || TAI.SYOKANTIME > '" & strTaisyoStDT & "' ")
        'strWHERE_TAIOU.Append("  AND TAI.SYOKANYMD || TAI.SYOKANTIME <='" & strTaisyoEdDT & "')) ")
        'strWHERE_TAIOU.Append("  OR (TAI.SYOKANYMD || TAI.SYOKANTIME <='" & strTaisyoEdDT & "' ")
        'strWHERE_TAIOU.Append("  AND TAI.SYOKANYMD || TAI.SYOKANTIME <='" & strTaisyoEdDT & "')) ")
        '--- ↓2005/05/19 MOD Falcon↓ ---
        '処理完了日、処理完了時間も条件に追加(OR)
        'strWHERE_TAIOU.Append("  AND TAI.SYOYMD || TAI.SYOTIME > '" & strTaisyoStDT & "' ")
        'strWHERE_TAIOU.Append("  AND TAI.SYOYMD || TAI.SYOTIME <='" & strTaisyoEdDT & "' ")
        '--- ↑2005/05/19 MOD Falcon↑ ---
        '--- ↑2005/05/23 MOD Falcon↑ ---
        '--- ↑2005/09/06 MOD Falcon↑ ---
        '--- ↑2005/09/10 MOD Falcon↑ ---

        '--- ↓2005/09/10 ADD Falcon↓ ---
        'クライアントコードの範囲指定を追加
        If pstrKURACD_F.Length > 0 Then
            strWHERE_TAIOU.Append("  AND TAI.KURACD >= '" & pstrKURACD_F & "' ")
            strWHERE_CLI.Append("  AND CLI.CLI_CD >= '" & pstrKURACD_F & "' ") '2010/12/21 T.Watabe add
        End If
        If pstrKURACD_T.Length > 0 Then
            strWHERE_TAIOU.Append("  AND TAI.KURACD <= '" & pstrKURACD_T & "' ")
            strWHERE_CLI.Append("  AND CLI.CLI_CD <= '" & pstrKURACD_T & "' ") '2010/12/21 T.Watabe add
        End If
        '--- ↑2005/09/10 ADD Falcon↑ ---

        '--------------------------------------------------
        Try
            'データのSELECT
            strSQL = New StringBuilder("")
            'SQL作成開始

            '--- 2005/05/19 MOD Falcon ---      AUTO⇒AUTO_KUBUN
            'strSQL.Append("SELECT ")
            'strSQL.Append("    AUTO_KUBUN, ")
            'strSQL.Append("    AUTO_FAX, ")
            'strSQL.Append("    AUTO_MAIL, ")
            'strSQL.Append("    MAX(HATYMD) AS HATYMD ") ' 2007/09/18 T.Watabe add ソートに発注日も追加
            'strSQL.Append("FROM ")
            'strSQL.Append("( ")
            'strSQL.Append("    SELECT ")
            'strSQL.Append("        JAS.AUTO_KUBUN, ")
            'strSQL.Append("        DECODE(JAS.AUTO_KUBUN,1,JAS.AUTO_FAX,'') AS AUTO_FAX, ")
            'strSQL.Append("        DECODE(JAS.AUTO_KUBUN,2,JAS.AUTO_MAIL,'') AS AUTO_MAIL, ")
            'strSQL.Append("        TAI.HATYMD || '-' || TAI.HATTIME AS HATYMD ") ' 2007/09/18 T.Watabe add
            'strSQL.Append("    FROM ")
            'strSQL.Append("        CLIMAS CLI,")
            'strSQL.Append("        HN2MAS JAS, ")
            'strSQL.Append("        D20_TAIOU TAI ")
            'strSQL.Append("    WHERE ")
            'strSQL.Append("            CLI.KANSI_CODE  = :KANSI_CODE")
            'strSQL.Append("        AND CLI.CLI_CD      = JAS.CLI_CD")
            'strSQL.Append("        AND (JAS.AUTO_KUBUN = '" & strFAXKBN & "' OR JAS.AUTO_KUBUN = '" & strMAILKBN & "') ")
            'strSQL.Append("        AND JAS.CLI_CD      = TAI.KURACD ")
            'strSQL.Append("        AND JAS.HAN_CD      = TAI.ACBCD ")
            'strSQL.Append(strWHERE_TAIOU.ToString)
            'strSQL.Append(") ")
            'strSQL.Append("GROUP BY AUTO_KUBUN, AUTO_FAX, AUTO_MAIL ")
            'strSQL.Append("ORDER BY AUTO_FAX, AUTO_MAIL, HATYMD ") ' 2007/09/18 T.Watabe add
            If pstrSEND_KBN = "1" Then '送信区分 1:販売所(JA・支所)/2:ｸﾗｲｱﾝﾄ
                '2011/03/27 T.Watabe ﾒｰﾙｱﾄﾞﾚｽ参照先を担当マスタに変更。代表JAにも対応(支所ごとの指定ではなく、代表のJAのみﾒｱﾄﾞを指定している場合)
                'strSQL.Append("SELECT  ")
                'strSQL.Append("    AUTO_KUBUN,  ")
                'strSQL.Append("    AUTO_FAX, ")
                'strSQL.Append("    AUTO_MAIL, ")
                'strSQL.Append("    SUM(TAIOU) AS CNT ") 'この件数が０は、０件送信を行う。
                'strSQL.Append("FROM ")
                'strSQL.Append("( ")
                'strSQL.Append("    SELECT  ") '対象① AUTO_FAX と AUTO_MAIL（既存）
                'strSQL.Append("        JAS.AUTO_KUBUN,  ")
                ''strSQL.Append("        DECODE(JAS.AUTO_KUBUN,1,JAS.AUTO_FAX,'') AS AUTO_FAX,  ") ' 2011/03/10 T.Watabe edit
                ''strSQL.Append("        DECODE(JAS.AUTO_KUBUN,2,JAS.AUTO_MAIL,'') AS AUTO_MAIL, ")
                'strSQL.Append("        JAS.AUTO_FAX AS AUTO_FAX,  ")
                'strSQL.Append("        JAS.AUTO_MAIL AS AUTO_MAIL, ")
                'strSQL.Append("        DECODE(T.ACBCD, NULL, 0, 1) AS TAIOU ")
                'strSQL.Append("    FROM  ")
                'strSQL.Append("        CLIMAS CLI, ")
                'strSQL.Append("        HN2MAS JAS, ")
                'strSQL.Append("        D20_TAIOU T ")
                'strSQL.Append("    WHERE  ")
                'strSQL.Append("            CLI.KANSI_CODE  = :KANSI_CODE")
                'strSQL.Append("        AND CLI.CLI_CD      = JAS.CLI_CD")
                ''strSQL.Append("        AND (JAS.AUTO_KUBUN = '" & strFAXKBN & "' OR JAS.AUTO_KUBUN = '" & strMAILKBN & "') ") ' 2011/03/10 T.Watabe edit
                'strSQL.Append("        AND JAS.AUTO_KUBUN IN ('" & strFAXKBN & "', '" & strMAILKBN & "', '" & strBoth & "') ")
                'strSQL.Append("        AND T.KURACD (+)= JAS.CLI_CD ")
                'strSQL.Append("        AND T.ACBCD  (+)= JAS.HAN_CD ")
                'strSQL.Append("        AND ( ")
                'strSQL.Append("                EXISTS ( ") ' 0件報告以外の場合、ここで存在データを対象とする
                'strSQL.Append("                    SELECT *  ")
                'strSQL.Append("                    FROM D20_TAIOU TAI ")
                'strSQL.Append("                    WHERE  ")
                'strSQL.Append("                            JAS.CLI_CD = TAI.KURACD  ")
                'strSQL.Append("                        AND JAS.HAN_CD = TAI.ACBCD  ")
                'strSQL.Append(strWHERE_TAIOU.ToString)
                'strSQL.Append("                ) ")
                'strSQL.Append("                OR  ")
                'strSQL.Append("                (JAS.YOBI3 = '1' AND T.ACBCD IS NULL) ") '予備３＝1(0件報告をする)＆対応データ＝なし(0件)
                'strSQL.Append("            ) ")
                'strSQL.Append("    UNION ALL ") ' 2010/05/24 T.Watabe add TELA_FAX1&TELB_FAX1用の抽出
                'strSQL.Append("    SELECT  ") '対象② TELA_FAX1&TELB_FAX1
                'strSQL.Append("        JAS.AUTO_KUBUN,  ")
                ''strSQL.Append("        DECODE(JAS.AUTO_KUBUN, 1, RTRIM(JAS.TELA_FAX1) || RTRIM(TELB_FAX1),'') AS AUTO_FAX,  ") ' 2011/03/10 T.Watabe edit ' 2010/05/24 T.Watabe add
                'strSQL.Append("        RTRIM(JAS.TELA_FAX1) || RTRIM(TELB_FAX1) AS AUTO_FAX,  ")
                'strSQL.Append("        NULL AS AUTO_MAIL, ")
                'strSQL.Append("        DECODE(T.ACBCD, NULL, 0, 1) AS TAIOU ")
                'strSQL.Append("    FROM  ")
                'strSQL.Append("        CLIMAS CLI, ")
                'strSQL.Append("        HN2MAS JAS, ")
                'strSQL.Append("        D20_TAIOU T ")
                'strSQL.Append("    WHERE  ")
                'strSQL.Append("            CLI.KANSI_CODE  = :KANSI_CODE")
                'strSQL.Append("        AND CLI.CLI_CD      = JAS.CLI_CD")
                ''strSQL.Append("        AND JAS.AUTO_KUBUN = '" & strFAXKBN & "' ")
                'strSQL.Append("        AND JAS.AUTO_KUBUN IN ('" & strFAXKBN & "', '" & strBoth & "') ")
                'strSQL.Append("        AND (JAS.TELA_FAX1 || TELB_FAX1) IS NOT NULL ")
                'strSQL.Append("        AND T.KURACD (+)= JAS.CLI_CD ")
                'strSQL.Append("        AND T.ACBCD  (+)= JAS.HAN_CD ")
                'strSQL.Append("        AND ( ")
                'strSQL.Append("                EXISTS ( ")
                'strSQL.Append("                    SELECT *  ")
                'strSQL.Append("                    FROM D20_TAIOU TAI ")
                'strSQL.Append("                    WHERE  ")
                'strSQL.Append("                            JAS.CLI_CD = TAI.KURACD  ")
                'strSQL.Append("                        AND JAS.HAN_CD = TAI.ACBCD  ")
                'strSQL.Append(strWHERE_TAIOU.ToString)
                'strSQL.Append("                ) ")
                'strSQL.Append("                OR  ")
                'strSQL.Append("                (JAS.YOBI3 = '1' AND T.ACBCD IS NULL) ") '予備３＝1(0件報告をする)＆対応データ＝なし(0件)
                'strSQL.Append("            ) ")
                'strSQL.Append(")  ")
                'strSQL.Append("GROUP BY AUTO_KUBUN, AUTO_FAX, AUTO_MAIL ")
                'strSQL.Append("ORDER BY AUTO_KUBUN, AUTO_FAX, AUTO_MAIL ")
                strSQL.Append("SELECT  ")
                strSQL.Append("    A.AUTO_KUBUN,  ")
                strSQL.Append("    A.AUTO_FAX, ")
                strSQL.Append("    DECODE(B.AUTO_MAIL, NULL, C.AUTO_MAIL, B.AUTO_MAIL) AS AUTO_MAIL, ")
                strSQL.Append("    SUM(A.TAIOU) AS CNT ") 'この件数が０は、０件送信を行う。
                strSQL.Append("FROM ")
                strSQL.Append("( ")
                strSQL.Append("    SELECT  ") '対象① AUTO_FAX と AUTO_MAIL（既存）
                strSQL.Append("        JAS.CLI_CD,  ")
                strSQL.Append("        JAS.HAN_CD,  ")
                strSQL.Append("        JAS.JA_CD ,  ")
                strSQL.Append("        JAS.AUTO_KUBUN,  ")
                'strSQL.Append("        DECODE(JAS.AUTO_KUBUN,1,JAS.AUTO_FAX,'') AS AUTO_FAX,  ") ' 2011/03/10 T.Watabe edit
                'strSQL.Append("        DECODE(JAS.AUTO_KUBUN,2,JAS.AUTO_MAIL,'') AS AUTO_MAIL, ")
                strSQL.Append("        JAS.AUTO_FAX AS AUTO_FAX,  ")
                strSQL.Append("        JAS.AUTO_MAIL AS AUTO_MAIL, /* このｱﾄﾞﾚｽは使わない。NULLでもかまわない */ ")
                strSQL.Append("        DECODE(T.ACBCD, NULL, 0, 1) AS TAIOU ")
                strSQL.Append("    FROM  ")
                strSQL.Append("        CLIMAS CLI, ")
                strSQL.Append("        HN2MAS JAS, ")
                strSQL.Append("        D20_TAIOU T ")
                strSQL.Append("    WHERE  ")
                strSQL.Append("            CLI.KANSI_CODE  = :KANSI_CODE")
                strSQL.Append("        AND CLI.CLI_CD      = JAS.CLI_CD")
                'strSQL.Append("        AND (JAS.AUTO_KUBUN = '" & strFAXKBN & "' OR JAS.AUTO_KUBUN = '" & strMAILKBN & "') ") ' 2011/03/10 T.Watabe edit
                strSQL.Append("        AND JAS.AUTO_KUBUN IN ('" & strFAXKBN & "', '" & strMAILKBN & "', '" & strBoth & "') ")
                strSQL.Append("        AND T.KURACD (+)= JAS.CLI_CD ")
                strSQL.Append("        AND T.ACBCD  (+)= JAS.HAN_CD ")
                strSQL.Append("        AND ( ")
                strSQL.Append("                EXISTS ( ") ' 0件報告以外の場合、ここで存在データを対象とする
                strSQL.Append("                    SELECT *  ")
                strSQL.Append("                    FROM D20_TAIOU TAI ")
                strSQL.Append("                    WHERE  ")
                strSQL.Append("                            JAS.CLI_CD = TAI.KURACD  ")
                strSQL.Append("                        AND JAS.HAN_CD = TAI.ACBCD  ")
                strSQL.Append(strWHERE_TAIOU.ToString)
                strSQL.Append("                ) ")
                strSQL.Append("                OR  ")
                strSQL.Append("                (JAS.YOBI3 = '1' AND T.ACBCD IS NULL) ") '予備３＝1(0件報告をする)＆対応データ＝なし(0件)
                strSQL.Append("            ) ")
                strSQL.Append("    UNION ALL ") ' 2010/05/24 T.Watabe add TELA_FAX1&TELB_FAX1用の抽出
                strSQL.Append("    SELECT  ") '対象② TELA_FAX1&TELB_FAX1
                strSQL.Append("        JAS.CLI_CD,  ")
                strSQL.Append("        JAS.HAN_CD,  ")
                strSQL.Append("        JAS.JA_CD ,  ")
                strSQL.Append("        JAS.AUTO_KUBUN,  ")
                'strSQL.Append("        DECODE(JAS.AUTO_KUBUN, 1, RTRIM(JAS.TELA_FAX1) || RTRIM(TELB_FAX1),'') AS AUTO_FAX,  ") ' 2011/03/10 T.Watabe edit ' 2010/05/24 T.Watabe add
                strSQL.Append("        RTRIM(JAS.TELA_FAX1) || RTRIM(TELB_FAX1) AS AUTO_FAX,  ")
                strSQL.Append("        NULL AS AUTO_MAIL, ")
                strSQL.Append("        DECODE(T.ACBCD, NULL, 0, 1) AS TAIOU ")
                strSQL.Append("    FROM  ")
                strSQL.Append("        CLIMAS CLI, ")
                strSQL.Append("        HN2MAS JAS, ")
                strSQL.Append("        D20_TAIOU T ")
                strSQL.Append("    WHERE  ")
                strSQL.Append("            CLI.KANSI_CODE  = :KANSI_CODE")
                strSQL.Append("        AND CLI.CLI_CD      = JAS.CLI_CD")
                'strSQL.Append("        AND JAS.AUTO_KUBUN = '" & strFAXKBN & "' ")
                strSQL.Append("        AND JAS.AUTO_KUBUN IN ('" & strFAXKBN & "', '" & strBoth & "') ")
                strSQL.Append("        AND (JAS.TELA_FAX1 || TELB_FAX1) IS NOT NULL ")
                strSQL.Append("        AND T.KURACD (+)= JAS.CLI_CD ")
                strSQL.Append("        AND T.ACBCD  (+)= JAS.HAN_CD ")
                strSQL.Append("        AND ( ")
                strSQL.Append("                EXISTS ( ")
                strSQL.Append("                    SELECT *  ")
                strSQL.Append("                    FROM D20_TAIOU TAI ")
                strSQL.Append("                    WHERE  ")
                strSQL.Append("                            JAS.CLI_CD = TAI.KURACD  ")
                strSQL.Append("                        AND JAS.HAN_CD = TAI.ACBCD  ")
                strSQL.Append(strWHERE_TAIOU.ToString)
                strSQL.Append("                ) ")
                strSQL.Append("                OR  ")
                strSQL.Append("                (JAS.YOBI3 = '1' AND T.ACBCD IS NULL) ") '予備３＝1(0件報告をする)＆対応データ＝なし(0件)
                strSQL.Append("            ) ")
                strSQL.Append("    ) A, ")
                strSQL.Append("    M05_TANTO B, ")
                strSQL.Append("    M05_TANTO C ")
                strSQL.Append("WHERE ")
                strSQL.Append("        B.KURACD (+)= RTRIM(A.CLI_CD) ")
                strSQL.Append("    AND B.CODE   (+)= RTRIM(A.HAN_CD) ")
                strSQL.Append("    AND B.KBN    (+)= '3' ")
                strSQL.Append("    AND B.AUTO_MAIL (+)IS NOT NULL ")
                strSQL.Append("    AND C.KURACD (+)= RTRIM(A.CLI_CD) ")
                strSQL.Append("    AND C.CODE   (+)= RTRIM(A.JA_CD) ")
                strSQL.Append("    AND C.KBN    (+)= '3' ")
                strSQL.Append("    AND C.AUTO_MAIL (+)IS NOT NULL ")
                strSQL.Append("GROUP BY  ")
                strSQL.Append("    A.AUTO_KUBUN,  ")
                strSQL.Append("    A.AUTO_FAX,  ")
                strSQL.Append("    DECODE(B.AUTO_MAIL, NULL, C.AUTO_MAIL, B.AUTO_MAIL) ")
                strSQL.Append("ORDER BY  ")
                strSQL.Append("    AUTO_KUBUN,  ")
                strSQL.Append("    AUTO_FAX,  ")
                strSQL.Append("    AUTO_MAIL  ")
            Else
                '2:ｸﾗｲｱﾝﾄ(供給ｾﾝﾀ)
                strSQL.Append("SELECT ")
                strSQL.Append("    AUTO_KUBUN, ")
                strSQL.Append("    AUTO_FAX, ")
                strSQL.Append("    AUTO_MAIL, ")
                strSQL.Append("    SUM(TAIOU) AS CNT ")
                strSQL.Append("FROM ")
                strSQL.Append("( ")
                strSQL.Append("        /* ①FAX通常 */ ")
                strSQL.Append("        SELECT ")
                strSQL.Append("            '1'    AS AUTO_KUBUN, ")
                strSQL.Append("            P.NAME AS AUTO_FAX, ")
                strSQL.Append("            NULL   AS AUTO_MAIL, ")
                strSQL.Append("            DECODE(TAI.ACBCD, NULL, 0, 1) AS TAIOU ")
                strSQL.Append("        FROM ")
                strSQL.Append("            CLIMAS CLI, ")
                strSQL.Append("            M06_PULLDOWN P, ")
                strSQL.Append("            D20_TAIOU TAI ")
                strSQL.Append("        WHERE ")
                strSQL.Append("                CLI.KANSI_CODE    = '" & pstrKANSI_CODE & "' ")
                strSQL.Append("            AND P.KBN = '76' ")
                strSQL.Append("            AND P.NAME IS NOT NULL ")
                strSQL.Append("            AND SUBSTR(P.CD, 1,4) = CLI.CLI_CD  ")
                strSQL.Append("            AND TAI.KURACD          = CLI.CLI_CD  ")
                strSQL.Append(strWHERE_TAIOU.ToString)
                strSQL.Append("    UNION ALL ")
                strSQL.Append("        /* ②FAX０件表示 */ ")
                strSQL.Append("        SELECT ")
                strSQL.Append("            '1'    AS AUTO_KUBUN, ")
                strSQL.Append("            P.NAME AS AUTO_FAX, ")
                strSQL.Append("            NULL   AS AUTO_MAIL, ")
                strSQL.Append("            0 AS TAIOU ")
                strSQL.Append("        FROM ")
                strSQL.Append("            CLIMAS CLI, ")
                strSQL.Append("            M06_PULLDOWN P ")
                strSQL.Append("        WHERE ")
                strSQL.Append("                CLI.KANSI_CODE    = '" & pstrKANSI_CODE & "' ")
                strSQL.Append("            AND P.KBN = '76' ")
                strSQL.Append("            AND P.NAME IS NOT NULL ")
                strSQL.Append("            AND SUBSTR(P.CD, 1, 4) = CLI.CLI_CD  ")
                strSQL.Append("            AND SUBSTR(P.NAIYO2, 1, 1) = '1' /* 0件表示 */ ")
                strSQL.Append(strWHERE_CLI.ToString)
                strSQL.Append("    UNION ALL ")
                strSQL.Append("        /* ③ﾒｰﾙ通常 */ ")
                strSQL.Append("        SELECT ")
                strSQL.Append("            '2'    AS AUTO_KUBUN, ")
                strSQL.Append("            NULL AS AUTO_FAX, ")
                strSQL.Append("            P.NAIYO1   AS AUTO_MAIL, ")
                strSQL.Append("            DECODE(TAI.ACBCD, NULL, 0, 1) AS TAIOU ")
                strSQL.Append("        FROM ")
                strSQL.Append("            CLIMAS CLI, ")
                strSQL.Append("            M06_PULLDOWN P, ")
                strSQL.Append("            D20_TAIOU TAI ")
                strSQL.Append("        WHERE ")
                strSQL.Append("                CLI.KANSI_CODE    = '" & pstrKANSI_CODE & "' ")
                strSQL.Append("            AND P.KBN = '76' ")
                strSQL.Append("            AND P.NAIYO1 IS NOT NULL ")
                strSQL.Append("            AND SUBSTR(P.CD, 1,4) = CLI.CLI_CD  ")
                strSQL.Append("            AND TAI.KURACD          = CLI.CLI_CD  ")
                strSQL.Append(strWHERE_TAIOU.ToString)
                strSQL.Append("    UNION ALL ")
                strSQL.Append("        /* ④ﾒｰﾙ０件表示 */ ")
                strSQL.Append("        SELECT ")
                strSQL.Append("            '2'    AS AUTO_KUBUN, ")
                strSQL.Append("            NULL AS AUTO_FAX, ")
                strSQL.Append("            P.NAIYO1   AS AUTO_MAIL, ")
                strSQL.Append("            0 AS TAIOU ")
                strSQL.Append("        FROM ")
                strSQL.Append("            CLIMAS CLI, ")
                strSQL.Append("            M06_PULLDOWN P ")
                strSQL.Append("        WHERE ")
                strSQL.Append("                CLI.KANSI_CODE    = '" & pstrKANSI_CODE & "'     ")
                strSQL.Append("            AND P.KBN = '76' ")
                strSQL.Append("            AND P.NAIYO1 IS NOT NULL ")
                strSQL.Append("            AND SUBSTR(P.CD, 1,4) = CLI.CLI_CD  ")
                strSQL.Append("            AND SUBSTR(P.NAIYO2, 1, 1) = '1' /* 0件表示 */ ")
                strSQL.Append(strWHERE_CLI.ToString)
                strSQL.Append(") ")
                strSQL.Append("GROUP BY      ")
                strSQL.Append("    AUTO_KUBUN, ")
                strSQL.Append("    AUTO_FAX, ")
                strSQL.Append("    AUTO_MAIL ")

            End If

            'Return "DEBUG[" & strSQL.ToString & "]"

            '//パラメータのセット
            cdb.pSQLParamStr("KANSI_CODE") = pstrKANSI_CODE

            cdb.pSQL = strSQL.ToString          '//SQLセット
            cdb.mExecQuery()                    '//SQL実行
            ds = cdb.pResult                    '//データセットに格納
            If ds.Tables(0).Rows.Count = 0 Then '//データが存在しない？
                Return "DATA0"                  '//データが0件であることを示す文字列を返す
            End If
            dr = ds.Tables(0).Rows(0)           '//データローにデータを格納

            '//データを出力
            Dim strFlg As String = ""
            Dim intLoop As Integer = 1
            Dim intDataRows As Integer = ds.Tables(0).Rows.Count
            Dim intData As Integer = 0
            Dim arrAUTO() As String
            Dim arrAUTO_FAX() As String
            Dim arrAUTO_MAIL() As String
            Dim arrAUTO_CNT() As Integer
            Dim autoKbn As String = ""
            For Each dr In ds.Tables(0).Rows
                '--- ↓2005/05/19 MOD Falcon↓ ---      AUTO⇒AUTO_KUBUN
                autoKbn = Convert.ToString(dr.Item("AUTO_KUBUN"))
                'If (Convert.ToString(dr.Item("AUTO_KUBUN")) = strFAXKBN And Convert.ToString(dr.Item("AUTO_FAX")).Length > 0) Or _
                '   (Convert.ToString(dr.Item("AUTO_KUBUN")) = strMAILKBN And Convert.ToString(dr.Item("AUTO_MAIL")).Length > 0) Then
                If ((autoKbn = strFAXKBN Or autoKbn = strBoth) And Convert.ToString(dr.Item("AUTO_FAX")).Length > 0) Or _
                   ((autoKbn = strMAILKBN Or autoKbn = strBoth) And Convert.ToString(dr.Item("AUTO_MAIL")).Length > 0) Then

                    ' 2011/03/10 T.Watabe edit FAXとﾒｰﾙを両方送信可能に変更
                    'ReDim Preserve arrAUTO(intData)
                    'ReDim Preserve arrAUTO_FAX(intData)
                    'ReDim Preserve arrAUTO_MAIL(intData)
                    'ReDim Preserve arrAUTO_CNT(intData)
                    'arrAUTO(intData) = Convert.ToString(dr.Item("AUTO_KUBUN"))
                    'arrAUTO_FAX(intData) = Convert.ToString(dr.Item("AUTO_FAX"))
                    'arrAUTO_MAIL(intData) = Convert.ToString(dr.Item("AUTO_MAIL"))
                    'arrAUTO_CNT(intData) = Convert.ToInt16(dr.Item("CNT"))
                    'intData += 1
                    If autoKbn = strFAXKBN Or autoKbn = strBoth Then '自動区分が1:FAX送信/3:FAX,ﾒｰﾙ両方
                        ReDim Preserve arrAUTO(intData)
                        ReDim Preserve arrAUTO_FAX(intData)
                        ReDim Preserve arrAUTO_MAIL(intData)
                        ReDim Preserve arrAUTO_CNT(intData)
                        arrAUTO(intData) = "1"      '1:FAX送信 固定
                        arrAUTO_FAX(intData) = Convert.ToString(dr.Item("AUTO_FAX"))
                        arrAUTO_MAIL(intData) = ""  'ﾒｰﾙ空欄
                        arrAUTO_CNT(intData) = Convert.ToInt16(dr.Item("CNT"))
                        intData += 1
                    End If
                    If autoKbn = strMAILKBN Or autoKbn = strBoth Then '自動区分が2:ﾒｰﾙ送信/3:FAX,ﾒｰﾙ両方
                        ReDim Preserve arrAUTO(intData)
                        ReDim Preserve arrAUTO_FAX(intData)
                        ReDim Preserve arrAUTO_MAIL(intData)
                        ReDim Preserve arrAUTO_CNT(intData)
                        arrAUTO(intData) = "2"      '2:ﾒｰﾙ送信 固定
                        arrAUTO_FAX(intData) = ""   'FAX空欄
                        arrAUTO_MAIL(intData) = Convert.ToString(dr.Item("AUTO_MAIL"))
                        arrAUTO_CNT(intData) = Convert.ToInt16(dr.Item("CNT"))
                        intData += 1
                    End If
                End If
                '--- ↑2005/05/19 MOD Falcon↑ ---    
            Next

            If intData = 0 Then
                '//データが0件であることを示す文字列を返す
                Return "DATA0"
            End If

            Dim i As Integer
            For i = 0 To intData - 1
                If intLoop = intData Then
                    strFlg = "1"
                Else
                    strFlg = "0"
                End If
                strRec = mExcelOut(cdb, _
                            pstrKANSI_CODE, _
                            pstrSESSION, _
                            pstrTAISYOUBI, _
                            strWHERE_TAIOU.ToString, _
                            arrAUTO(i), _
                            arrAUTO_FAX(i), _
                            arrAUTO_MAIL(i), _
                            arrAUTO_CNT(i), _
                            pstrCreateFilePath, _
                            strFlg, _
                            pstrSEND_JALP_NAME, _
                            pstrSEND_CENT_NAME, _
                            pstrSEND_KBN _
                            )
                '//ＥＸＣＥＬファイルは、[strCOMPRESS]にセットした名前の圧縮ファイルに追加する
                Select Case strRec.Substring(0, 5)
                    'Case "DATA0"
                    '    Exit Try
                Case "DEBUG"
                        Exit Try
                    Case "ERROR"
                        Exit Try
                End Select
                intLoop += 1
            Next

        Catch ex As Exception
            strRec = "ERROR:" & ex.ToString
        Finally
            '接続クローズ
            cdb.mClose()
        End Try

        Return strRec
    End Function

    '******************************************************************************
    '*　概　要：ナースセンター対応内容明細（ＦＡＸ）の出力
    '*　備　考：
    '******************************************************************************
    '　DATA0：対象データがありません
    Private Function mExcelOut( _
                                ByVal cdb As CDB, _
                                ByVal pstrKANSI_CODE As String, _
                                ByVal pstrSESSION As String, _
                                ByVal pstrTAISYOUBI As String, _
                                ByVal pstrWHERE_TAIOU As String, _
                                ByVal pstrAUTO As String, _
                                ByVal pstrFAXNO As String, _
                                ByVal pstrMAILAD As String, _
                                ByVal pintCNT As Integer, _
                                ByVal pstrCreateFilePath As String, _
                                ByVal pstrFlg As String, _
                                ByVal pstrSEND_JALP_NAME As String, _
                                ByVal pstrSEND_CENT_NAME As String, _
                                ByVal pstrSEND_KBN As String _
                                ) As String

        Dim strSQL As New StringBuilder("")
        Dim ds As New DataSet
        Dim dr As DataRow


        Dim ExcelC As New CExcel 'Excelクラス
        Dim compressC As New CCompress '圧縮クラス
        Dim intGYOSU As Integer = 56 '改行制御を行う
        Dim DateFncC As New CDateFnc '日付変換クラス
        Dim FileToStrC As New CFileStr 'ファイルをBase64にエンコードするクラス
        Dim sZipFilePass As String ' 2008/12/12 T.Watabe add
        Dim sendCD As String '2010/05/24 T.Watabe add

        Dim cliCd4FileHead As String = "" '2011/03/10 T.Watabe add

        If pstrSEND_KBN = "1" Then
            sendCD = "H" '販売所
        Else
            sendCD = "C" 'ｾﾝﾀｰ
        End If


        Dim sel As StringBuilder = New StringBuilder("")
        Dim fro As StringBuilder = New StringBuilder("")
        Dim whe As StringBuilder = New StringBuilder("")

        If pstrSEND_KBN = "1" Then '1:販売所？

            sel.Append("    ,JAS.YOBI5 ") ' パスワード

            fro.Append("    ,HN2MAS JAS ")

            whe.Append("AND CLI.CLI_CD     = JAS.CLI_CD ")
            'whe.Append("AND JAS.AUTO_KUBUN = :AUTO_KUBUN ")     '--- 2005/05/19 MOD Falcon ---  AUTO ⇒ AUTO_KUBUN
            If pstrAUTO = strFAXKBN Then 'ＦＡＸ送信？
                whe.Append("  AND JAS.AUTO_KUBUN IN ('" & strFAXKBN & "','" & strBoth & "') ")  ' 2011/03/10 T.Watabe edit
                whe.Append("  AND (JAS.AUTO_FAX = :AUTO_FAX OR RTRIM(JAS.TELA_FAX1) || RTRIM(TELB_FAX1) = :AUTO_FAX)")
            Else 'メール送信？
                whe.Append("  AND JAS.AUTO_KUBUN IN ('" & strMAILKBN & "','" & strBoth & "') ") ' 2011/03/10 T.Watabe edit
                'whe.Append("  AND JAS.AUTO_MAIL = :AUTO_MAIL ")' 2011/03/28 T.Watabe edit １つのメール送信用データ作成時の抽出用ＳＱＬ
                whe.Append("    AND (JAS.CLI_CD, JAS.HAN_CD, JAS.JA_CD) IN ( ") '/* JPGAP側 送信対象メアドから、対象となるＪＡ支所を抽出するSQL */
                whe.Append("        /* 1:ＪＡ支所レベルでメアド設定 */ ")
                whe.Append("            SELECT  ")
                whe.Append("                A.CLI_CD, A.HAN_CD, A.JA_CD ")
                whe.Append("            FROM  ")
                whe.Append("                HN2MAS A, ")
                whe.Append("                M05_TANTO C ")
                whe.Append("            WHERE ")
                whe.Append("                    C.KURACD = A.CLI_CD ")
                whe.Append("                AND C.CODE   = A.HAN_CD ")
                whe.Append("                AND C.KBN    = '3' ")
                whe.Append("                and C.AUTO_MAIL = :AUTO_MAIL ")
                whe.Append("                AND A.HAN_CD <> A.JA_CD /* JAは除外。JA支所のみ */ ")
                whe.Append("        UNION ")
                whe.Append("        /* 2:ＪＡレベルでメアド設定 */ ")
                whe.Append("            SELECT  ")
                whe.Append("               X.CLI_CD, X.HAN_CD, X.JA_CD ")
                whe.Append("            FROM  ")
                whe.Append("                ( ")
                whe.Append("                    SELECT  ")
                whe.Append("                        A.CLI_CD, A.HAN_CD, A.JA_CD ")
                whe.Append("                    FROM  ")
                whe.Append("                        HN2MAS A, ")
                whe.Append("                        M05_TANTO B ")
                whe.Append("                    WHERE ")
                whe.Append("                            B.KURACD (+)= A.CLI_CD ")
                whe.Append("                        AND B.CODE   (+)= A.HAN_CD ")
                whe.Append("                        AND B.KBN    (+)= '3' ")
                whe.Append("                        AND B.KURACD IS NULL ")
                whe.Append("                ) X, ")
                whe.Append("                M05_TANTO Y ")
                whe.Append("            WHERE ")
                whe.Append("                    Y.KURACD = X.CLI_CD ")
                whe.Append("                AND Y.CODE   = X.JA_CD ")
                whe.Append("                AND Y.KBN    = '3' ")
                whe.Append("                and Y.AUTO_MAIL = :AUTO_MAIL ")
                whe.Append("    ) ")
            End If
            whe.Append("  AND JAS.CLI_CD   = TAI.KURACD  ")
            whe.Append("  AND JAS.HAN_CD   = TAI.ACBCD  ")
            whe.Append("  AND SUBSTR(JAS.CLI_CD,2,2) = KYO.KEN_CD(+) ")
            whe.Append("  AND JAS.HAISO_CD = KYO.HAISO_CD(+) ")

        Else '2:ｸﾗｲｱﾝﾄ？

            'sel.Append("    ,CLI.CLI_CD AS YOBI5 ") ' パスワード 2008/12/12 T.Watabe add
            sel.Append("    ,DECODE(INSTR(P.NAIYO2, ','), 0, NULL, SUBSTR(P.NAIYO2, INSTR(P.NAIYO2, ',') + 1)) AS YOBI5 ") ' パスワード 2010/10/25 T.Watabe add

            fro.Append("    ,M06_PULLDOWN P ")
            fro.Append("    ,HN2MAS JAS ")

            whe.Append("  AND P.KBN              = '76' ")
            whe.Append("  AND SUBSTR(P.CD, 1, 4) = CLI.CLI_CD  ")
            'whe.Append("  AND :AUTO_KUBUN IS NOT NULL ") 'ﾀﾞﾐｰ
            If pstrAUTO = strFAXKBN Then 'ＦＡＸ送信？
                whe.Append("  AND P.NAME   = :AUTO_FAX ")
            Else 'メール送信？
                whe.Append("  AND P.NAIYO1 = :AUTO_MAIL ")
            End If
            whe.Append("  AND JAS.CLI_CD   = TAI.KURACD  ")
            whe.Append("  AND JAS.HAN_CD   = TAI.ACBCD  ")
            whe.Append("  AND SUBSTR(JAS.CLI_CD,2,2) = KYO.KEN_CD(+) ")
            whe.Append("  AND JAS.HAISO_CD = KYO.HAISO_CD(+) ")
        End If

        Try
            '//------------------------------------------------
            'データのSELECT
            '//------------------------------------------------
            strSQL = New StringBuilder("")
            'SQL作成開始
            strSQL.Append("SELECT ")
            strSQL.Append("    CLI.CLI_CD,  ") '2011/03/10 T.Watabe add
            '20051003 NEC ADD START
            strSQL.Append("    KOK.USER_CD SH_USER, ")
            '20051003 NEC ADD END
            strSQL.Append("    TAI.JANM, ")
            strSQL.Append("    TAI.ACBNM, ")
            strSQL.Append("    TAI.KENNM, ")
            strSQL.Append("    KYO.NAME, ")
            'strSQL.Append("    JAS.AUTO_FAX, ")
            'strSQL.Append("    JAS.AUTO_MAIL, ")
            strSQL.Append("    TAI.JUSYONM, ")
            strSQL.Append("    TAI.ACBCD, ")
            strSQL.Append("    TAI.USER_CD, ")
            strSQL.Append("    TAI.KTELNO, ")
            '2006/06/14 NEC UPDATE START
            strSQL.Append("    TAI.SDNM, ")
            strSQL.Append("    TAI.JUTEL1, ")
            strSQL.Append("    TAI.JUTEL2, ")
            strSQL.Append("    KOK.USER_FLG, ")
            '2006/06/14 NEC UPDATE END
            strSQL.Append("    TAI.RENTEL, ")
            strSQL.Append("    TAI.ADDR, ")
            strSQL.Append("    KOK.GAS_STOP AS GAS_START, ")
            strSQL.Append("    KOK.GAS_DELE, ")
            strSQL.Append("    TAI.TIZUNO, ")
            strSQL.Append("    KOK.SHUGOU, ")
            strSQL.Append("    TAI.NCU_SET, ")
            strSQL.Append("    TAI.HATYMD, ")
            strSQL.Append("    TAI.HATTIME, ")
            strSQL.Append("    TAI.KENSIN, ")
            strSQL.Append("    TAI.RYURYO, ")
            strSQL.Append("    TAI.METASYU, ")
            strSQL.Append("    TAI.KMNM1, ")
            strSQL.Append("    TAI.KMNM2, ")
            strSQL.Append("    TAI.KMNM3, ")
            strSQL.Append("    TAI.KMNM4, ")
            strSQL.Append("    TAI.KMNM5, ")
            strSQL.Append("    TAI.KMNM6, ")
            strSQL.Append("    TAI.MITOKBN, ")
            strSQL.Append("    TAI.TAIOKBN_NAI, ")
            strSQL.Append("    TAI.TMSKB_NAI, ")
            strSQL.Append("    TAI.SYONO, ")
            strSQL.Append("    TAI.TKTANCD_NM, ")
            strSQL.Append("    TAI.SYOYMD, ")
            strSQL.Append("    TAI.SYOTIME, ")
            strSQL.Append("    TAI.TAITNM, ")
            strSQL.Append("    TAI.TELRNM, ")
            strSQL.Append("    TAI.FUK_MEMO, ")
            strSQL.Append("    TAI.TEL_MEMO1, ")
            strSQL.Append("    TAI.TEL_MEMO2, ")
            strSQL.Append("    TAI.TKIGNM, ")
            strSQL.Append("    TAI.TSADNM, ")
            strSQL.Append("    TAI.SIJI_BIKO1, ")
            strSQL.Append("    TAI.SIJI_BIKO2, ")
            strSQL.Append("    TAI.SYUTDTNM, ")
            strSQL.Append("    TAI.STD_KYOTEN, ")
            strSQL.Append("    TAI.TSTANNM, ")
            strSQL.Append("    TAI.TYAKYMD, ")
            strSQL.Append("    TAI.TYAKTIME, ")
            strSQL.Append("    TAI.SYOKANYMD, ")
            strSQL.Append("    TAI.SYOKANTIME, ")
            strSQL.Append("    TAI.AITNM, ")
            strSQL.Append("    TAI.SDTBIK1, ")
            strSQL.Append("    TAI.FKINM, ")
            strSQL.Append("    TAI.KIGTAIYO, ")
            strSQL.Append("    TAI.JAKENREN, ")
            strSQL.Append("    TAI.RENTIME, ")
            strSQL.Append("    TAI.GASMUMU, ")
            strSQL.Append("    TAI.ORGENIN, ")
            strSQL.Append("    TAI.GASGUMU, ")
            strSQL.Append("    TAI.HOSKOKAN, ")
            strSQL.Append("    TAI.METYOINA, ")
            strSQL.Append("    TAI.TYOUYOINA, ")
            strSQL.Append("    TAI.VALYOINA, ")
            strSQL.Append("    TAI.KYUHAIUMU, ")
            strSQL.Append("    TAI.COYOINA, ")
            strSQL.Append("    TAI.SDTBIK2, ")
            '2006/06/14 NEC UPDATE START
            strSQL.Append("    TAI.SDTBIK3, ")
            '2006/06/14 NEC UPDATE END
            strSQL.Append("    TAI.SNTTOKKI, ")
            strSQL.Append("    TAI.METFUKKI, ")
            strSQL.Append("    TAI.HOAN, ")
            strSQL.Append("    TAI.GASGIRE, ")
            strSQL.Append("    TAI.KIGKOSYO, ")
            strSQL.Append("    TAI.CSNTGEN, ")
            strSQL.Append("    TAI.CSNTNGAS, ")
            strSQL.Append("    TAI.SDTBIK1, ")
            strSQL.Append("    TAI.STD_CD, ")               '--- 2005/05/23 ADD Falcon
            strSQL.Append("    TAI.STD, ")                  '--- 2005/05/23 ADD Falcon
            strSQL.Append("    TAI.TAIOKBN, ")              '--- 2005/05/25 ADD Falcon
            strSQL.Append("    TAI.TFKICD, ")               '--- 2005/07/13 ADD Falcon
            strSQL.Append("    PL3.NAME AS SHUGOUNM, ")
            strSQL.Append("    PL5.NAME AS RYURYONM ")
            strSQL.Append("    ,TAI.HATYMD || '-' || TAI.HATTIME AS HATYMDT ")    ' 2007/09/18 T.Watabe add
            strSQL.Append("    ,TAI.SIJIYMD ")  ' 出動指示日        2008/10/14 T.Watabe add
            strSQL.Append("    ,TAI.SIJITIME ") ' 出動指示時刻      2008/10/14 T.Watabe add
            strSQL.Append("    ,TAI.SDYMD ")    ' 出動日            2008/10/14 T.Watabe add
            strSQL.Append("    ,TAI.SDTIME ")   ' 出動時刻          2008/10/14 T.Watabe add
            strSQL.Append("    ,TAI.KIGNM ")    ' ガス器具          2008/10/14 T.Watabe add 
            strSQL.Append("    ,TAI.SADNM ")    ' メータ作動原因１  2008/10/14 T.Watabe add
            strSQL.Append("    ,TAI.SDSKBN_NAI ")  ' 出動会社処理区分・内容 ' 2008/10/21 T.Watabe add
            'strSQL.Append("    ,JAS.YOBI5 ") ' パスワード 2008/12/12 T.Watabe add
            strSQL.Append(sel) ' パスワード 2008/12/12 T.Watabe add
            strSQL.Append("FROM CLIMAS CLI, ")
            'strSQL.Append("     HN2MAS JAS, ")
            strSQL.Append("     D20_TAIOU TAI, ")
            strSQL.Append("     HAIMAS KYO, ")
            strSQL.Append("     SHAMAS KOK, ")
            strSQL.Append("     M06_PULLDOWN PL3, ")
            strSQL.Append("     M06_PULLDOWN PL5 ")
            strSQL.Append(fro)
            strSQL.Append("WHERE ")
            strSQL.Append("    CLI.KANSI_CODE = :KANSI_CODE ")
            'strSQL.Append("AND CLI.CLI_CD     = JAS.CLI_CD ")
            'strSQL.Append("AND JAS.AUTO_KUBUN = '" & pstrAUTO & "' ")     '--- 2005/05/19 MOD Falcon ---  AUTO ⇒ AUTO_KUBUN
            'If pstrAUTO = strFAXKBN Then
            '    'ＦＡＸ送信の場合
            '    'strSQL.Append("  AND JAS.AUTO_FAX = :AUTO_FAX ") ’2010/05/24 T.Watabe edit
            '    strSQL.Append("  AND (JAS.AUTO_FAX = :AUTO_FAX OR RTRIM(JAS.TELA_FAX1) || RTRIM(TELB_FAX1) = :AUTO_FAX)")
            'Else
            '    'メール送信の場合
            '    strSQL.Append("  AND JAS.AUTO_MAIL = :AUTO_MAIL ")
            'End If
            'strSQL.Append("  AND JAS.CLI_CD   = TAI.KURACD  ")
            'strSQL.Append("  AND JAS.HAN_CD   = TAI.ACBCD  ")
            'strSQL.Append("  AND SUBSTR(JAS.CLI_CD,2,2) = KYO.KEN_CD(+) ")
            'strSQL.Append("  AND JAS.HAISO_CD = KYO.HAISO_CD(+) ")
            strSQL.Append(whe)
            strSQL.Append(pstrWHERE_TAIOU.ToString)
            strSQL.Append("  AND TAI.KURACD   = KOK.CLI_CD(+) ")
            strSQL.Append("  AND TAI.ACBCD    = KOK.HAN_CD(+) ")
            strSQL.Append("  AND TAI.USER_CD  = KOK.USER_CD(+) ")
            strSQL.Append("  AND '03'         = PL3.KBN(+) ")
            strSQL.Append("  AND KOK.SHUGOU   = PL3.CD(+) ")
            strSQL.Append("  AND '05'         = PL5.KBN(+) ")
            strSQL.Append("  AND TAI.RYURYO   = PL5.CD(+) ")
            strSQL.Append("ORDER BY ")
            strSQL.Append("    HATYMDT ") ' 2007/09/18 T.Watabe add ソートがそもそも無かったので追加

            'Return "DEBUG[" & strSQL.ToString & "]"

            cdb.pSQL = strSQL.ToString '//SQLセット

            '//パラメータのセット
            cdb.pSQLParamStr("KANSI_CODE") = pstrKANSI_CODE
            'cdb.pSQLParamStr("AUTO_KUBUN") = strFAXKBN
            'If pstrAUTO = strFAXKBN Then
            If pstrAUTO = strFAXKBN Then
                cdb.pSQLParamStr("AUTO_FAX") = pstrFAXNO 'ＦＡＸ送信の場合
            Else
                cdb.pSQLParamStr("AUTO_MAIL") = pstrMAILAD 'メール送信の場合
            End If

            cdb.mExecQuery() '//SQL実行
            ds = cdb.pResult  '//データセットに格納


            '//------------------------------------------------
            '// ファイルの作成１（基本情報設定）
            '//------------------------------------------------
            If True Then
                ExcelC.pKencd = "00"            '県コードをセット
                ExcelC.pSessionID = pstrSESSION 'セッションID　※処理日付＆電話番号を設定する
                ExcelC.pRepoID = strPGID        '帳票ID
                ExcelC.pLandScape = False       '帳票縦
                ExcelC.mOpen()                  'ファイルオープン
                'タイトル
                If pstrAUTO = strFAXKBN Then
                    'ＦＡＸ送信の場合
                    ExcelC.pTitle = "監視センター対応内容明細（ＦＡＸ）"
                Else
                    'メール送信の場合
                    ExcelC.pTitle = "監視センター対応内容明細（メール）"
                End If
                ExcelC.pDate = DateFncC.mGet(Now.ToString("yyyyMMdd")) '作成日
                'ExcelC.pScale = 93               '縮小拡大率 2010/09/17 T.Watabe edit
                ExcelC.pScale = 95               '縮小拡大率
                If pstrSEND_KBN = "2" Then '2:クライアントの目印をフッタへ付ける
                    ExcelC.pFooter = "&R ."
                    'ExcelC.pFooter = "&R &P \/ " & pintCNT & "."
                Else
                    'ExcelC.pFooter = "&R &P \/ " & pintCNT & " "
                End If

                '余白
                '2005/10/03 NEC UPDATE
                '2005/12/22 NEC UPDATE
                '2006/06/21 NEC UPDATE 
                ExcelC.pMarginTop = 1.8D
                'ExcelC.pMarginBottom = 1D ' 2010/10/06 T.Watabe edit
                ExcelC.pMarginBottom = 0.5D
                ExcelC.pMarginLeft = 1.2D
                ExcelC.pMarginRight = 1.5D
                ExcelC.pMarginHeader = 1D
                'ExcelC.pMarginFooter = 1D ' 2010/10/06 T.Watabe edit
                ExcelC.pMarginFooter = 0.5D
            End If

            If ds.Tables(0).Rows.Count = 0 Then  '//データが存在しない？

                'Return "DATA0" '//データが0件であることを示す文字列を返す
                '-------------
                ' マスタ情報取得
                '-------------
                strSQL = New StringBuilder("")
                If pstrSEND_KBN = "1" Then '1:販売所？
                    strSQL.Append("SELECT DISTINCT ")
                    strSQL.Append("    CLI.CLI_CD,  ") '2011/03/10 T.Watabe add
                    strSQL.Append("    KYO.NAME AS CENTER_NAME, ")
                    strSQL.Append("    CLI.KEN_NAME, ")
                    strSQL.Append("    KAN.TEL ")
                    strSQL.Append("FROM  ")
                    strSQL.Append("    CLIMAS CLI, ")
                    strSQL.Append("    HN2MAS JAS, ")
                    strSQL.Append("    HAIMAS KYO, ")
                    strSQL.Append("    KANSIMAS KAN ")
                    strSQL.Append("WHERE ")
                    strSQL.Append("        CLI.KANSI_CODE  = '" & pstrKANSI_CODE & "' ")
                    strSQL.Append("    AND CLI.CLI_CD      = JAS.CLI_CD ")
                    If pstrAUTO = "1" Then '1:FAX送信
                        'strSQL.Append("    AND JAS.AUTO_KUBUN  = '1' AND JAS.AUTO_FAX    = '" & pstrFAXNO & "' ")
                        'strSQL.Append("    AND JAS.AUTO_KUBUN  = '1' ") ' 2011/03/10 T.Watabe edit
                        strSQL.Append("    AND JAS.AUTO_KUBUN IN ('" & strFAXKBN & "','" & strBoth & "') ")
                        strSQL.Append("    AND (JAS.AUTO_FAX = '" & pstrFAXNO & "' OR RTRIM(JAS.TELA_FAX1) || RTRIM(TELB_FAX1) = '" & pstrFAXNO & "')")
                    Else
                        'strSQL.Append("    AND JAS.AUTO_KUBUN  = '2' AND JAS.AUTO_MAIL    = '" & pstrMAILAD & "' ") ' 2011/03/10 T.Watabe edit
                        strSQL.Append("    AND JAS.AUTO_KUBUN IN ('" & strMAILKBN & "','" & strBoth & "') ")
                        strSQL.Append("    AND JAS.AUTO_MAIL    = '" & pstrMAILAD & "' ")
                    End If
                    strSQL.Append("    AND JAS.YOBI3       = '1' ")
                    strSQL.Append("    AND KYO.KEN_CD(+)   = SUBSTR(JAS.CLI_CD,2,2) ")
                    strSQL.Append("    AND KYO.HAISO_CD(+) = JAS.HAISO_CD ")
                    strSQL.Append("    AND KAN.KANSI_CD (+)= CLI.KANSI_CODE ")

                Else '2:ｸﾗｲｱﾝﾄ？
                    strSQL.Append("SELECT DISTINCT ")
                    strSQL.Append("    CLI.CLI_CD,  ") '2011/03/10 T.Watabe add
                    strSQL.Append("    CLI.CLI_NAME AS CENTER_NAME, ")
                    strSQL.Append("    CLI.KEN_NAME, ")
                    strSQL.Append("    KAN.TEL ")
                    strSQL.Append("FROM ")
                    strSQL.Append("    CLIMAS CLI, ")
                    strSQL.Append("    M06_PULLDOWN P, ")
                    strSQL.Append("    KANSIMAS KAN ")
                    strSQL.Append("WHERE ")
                    strSQL.Append("        CLI.KANSI_CODE  = '" & pstrKANSI_CODE & "' ")
                    strSQL.Append("    AND P.KBN = '76' ")
                    strSQL.Append("    AND SUBSTR(P.CD, 1, 4) = CLI.CLI_CD  ")
                    If pstrAUTO = "1" Then
                        strSQL.Append("    AND P.NAME   = '" & pstrFAXNO & "' ")
                    Else
                        strSQL.Append("    AND P.NAIYO1 = '" & pstrMAILAD & "' ")
                    End If
                    strSQL.Append("    AND KAN.KANSI_CD (+)= CLI.KANSI_CODE ")
                End If
                cdb.pSQL = strSQL.ToString   '//SQLセット
                cdb.mExecQuery() '//SQL実行

                Dim dsInfo As New DataSet
                Dim drInfo As DataRow
                dsInfo = cdb.pResult  '//データセットに格納

                Dim kenName As String = ""
                Dim centerName As String = ""
                Dim jalpTel As String = ""

                If dsInfo.Tables(0).Rows.Count > 0 Then  '//データが存在する？
                    drInfo = dsInfo.Tables(0).Rows(0)
                    kenName = Convert.ToString(drInfo.Item("KEN_NAME"))
                    centerName = Convert.ToString(drInfo.Item("CENTER_NAME"))
                    jalpTel = Convert.ToString(drInfo.Item("TEL"))
                    cliCd4FileHead = Convert.ToString(drInfo.Item("CLI_CD")) '2011/03/10 T.Watabe add
                End If

                Dim taisyoDate As String = fncAdd_Date(pstrTAISYOUBI, -1)
                taisyoDate = taisyoDate.Substring(0, 4) & "/" & taisyoDate.Substring(4, 2) & "/" & taisyoDate.Substring(6, 2)

                '//------------------------------------------------
                '// ファイルの作成２（データ設定）
                '//------------------------------------------------
                ExcelC.mHeader(intGYOSU, 30, 1)

                '各列の幅をピクセルでセット。枠線も消す。
                '1行目
                'ExcelC.pCellStyle(1) = "width:50px;border-style:none"
                'ExcelC.pCellStyle(2) = "width:104px;border-style:none"
                ExcelC.pCellStyle(1) = "width:32px;border-style:none"
                ExcelC.pCellStyle(2) = "width:122px;border-style:none"
                ExcelC.pCellStyle(3) = "width:72px;border-style:none"
                ExcelC.pCellStyle(4) = "width:72px;border-style:none"

                ExcelC.pCellStyle(5) = "width:90px;border-style:none"
                ExcelC.pCellStyle(6) = "width:115px;border-style:none"
                ExcelC.pCellStyle(7) = "width:72px;border-style:none"
                ExcelC.pCellStyle(8) = "width:52px;border-style:none"
                ExcelC.pCellStyle(9) = "width:80px;border-style:none"
                'ExcelC.pCellStyle(10) = "width:62px;border-style:none"
                ExcelC.pCellStyle(10) = "width:3px;border-style:none" ' 2010/09/17 T.Watabe edit
                ExcelC.pCellStyle(11) = "width:3px;border-style:none" ' 2010/09/17 T.Watabe add
                ExcelC.pCellStyle(12) = "width:3px;border-style:none" ' 2010/09/17 T.Watabe add
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
                ExcelC.pCellVal(11) = "" ' 2010/09/17 T.Watabe add
                ExcelC.pCellVal(12) = "" ' 2010/09/17 T.Watabe add
                ExcelC.mWriteLine("")   '行をファイルに書き込む

                '1行目
                ExcelC.pCellStyle(1) = "border-style:none"
                If pstrAUTO = "1" Then
                    ExcelC.pCellVal(1, "colspan=6") = "送信先FAX番号：" & pstrFAXNO
                Else
                    ExcelC.pCellVal(1, "colspan=6") = ""
                End If
                ExcelC.mWriteLine("")   '行をファイルに書き込む

                '2行目
                ExcelC.pCellStyle(1) = "border-style:none"
                ExcelC.pCellVal(1, "colspan=6") = ""
                ExcelC.mWriteLine("")   '行をファイルに書き込む

                '3行目
                ExcelC.pCellStyle(1) = "border-style:none"
                ExcelC.pCellStyle(2) = "border-style:none"
                ExcelC.pCellStyle(3) = "border-style:none"
                ExcelC.pCellVal(1, "colspan=2") = "県名：" & kenName
                If pstrSEND_KBN = "1" Then
                    ExcelC.pCellVal(2, "colspan=4") = "供給センター名：" & centerName
                Else
                    ExcelC.pCellVal(2, "colspan=4") = "クライアント名：" & centerName
                End If
                ExcelC.mWriteLine("")   '行をファイルに書き込む

                '4行目
                ExcelC.pCellStyle(1) = "border-style:none"
                ExcelC.pCellVal(1, "colspan=10 align=right") = "発行者TEL：" & jalpTel
                ExcelC.mWriteLine("")   '行をファイルに書き込む

                '5行目
                ExcelC.pCellStyle(1) = "border-style:none"
                ExcelC.pCellVal(1, "colspan=10 align=right") = "発行者：" & pstrSEND_JALP_NAME   '//㈱JA-LPｶﾞｽ情報ｾﾝﾀｰ
                ExcelC.mWriteLine("")   '行をファイルに書き込む

                '6行目
                ExcelC.pCellStyle(1) = "border-style:none"
                ExcelC.pCellVal(1, "colspan=10 align=right") = pstrSEND_CENT_NAME   '//ＬＰガス集中センター
                ExcelC.mWriteLine("")   '行をファイルに書き込む
                '7行目
                ExcelC.pCellStyle(1) = "border-style:none"
                ExcelC.pCellVal(1, "colspan=6") = ""
                ExcelC.mWriteLine("")   '行をファイルに書き込む

                '8行目
                ExcelC.pCellStyle(1) = "border-style:none"
                ExcelC.pCellVal(1, "colspan=6") = "[" & taisyoDate & "] 対応０件"
                ExcelC.mWriteLine("")   '行をファイルに書き込む

            Else
                '//データローにデータを格納
                dr = ds.Tables(0).Rows(0)

                '2006/06/15 NEC ADD START
                Dim drKansimas As DataRow
                If True Then
                    Dim dsKansimas As New DataSet
                    Dim strSQL_Kansimas As New StringBuilder("")

                    strSQL_Kansimas.Append("SELECT TEL ")        '電話番号
                    strSQL_Kansimas.Append("FROM KANSIMAS ")
                    strSQL_Kansimas.Append("WHERE KANSI_CD = :KANSI_CD ")

                    cdb.pSQL = strSQL_Kansimas.ToString '//SQLセット
                    cdb.pSQLParamStr("KANSI_CD") = pstrKANSI_CODE '//パラメータセット
                    cdb.mExecQuery()  '//SQL実行
                    dsKansimas = cdb.pResult  '//データセットに格納

                    If dsKansimas.Tables(0).Rows.Count = 0 Then '//データが存在しない？

                        strSQL_Kansimas.Remove(0, strSQL_Kansimas.Length)
                        strSQL_Kansimas.Append("SELECT '' AS TEL ")      '電話番号
                        strSQL_Kansimas.Append("FROM DUAL ")

                        cdb.pSQL = strSQL_Kansimas.ToString  '//SQLセット
                        cdb.mExecQuery()  '//SQL実行
                        dsKansimas = cdb.pResult  '//データセットに格納
                        drKansimas = dsKansimas.Tables(0).Rows(0) '//データを格納
                    Else
                        drKansimas = dsKansimas.Tables(0).Rows(0) '//データを格納
                    End If
                End If
                '2006/06/15 NEC ADD END

                '//------------------------------------------------
                '// ファイルの作成２（データ設定）
                '//------------------------------------------------

                'ヘッダ項目をセット。（1ページあたり行数、出力行数、先頭行から何行目までが行タイトルか）
                'ExcelC.mHeader(intGYOSU, intGYOSU, 1)
                ExcelC.mHeader(intGYOSU, ds.Tables(0).Rows.Count, 1)

                '各列の幅をピクセルでセット。枠線も消す。
                '1行目
                'ExcelC.pCellStyle(1) = "width:50px;border-style:none"
                'ExcelC.pCellStyle(2) = "width:104px;border-style:none"
                ExcelC.pCellStyle(1) = "width:32px;border-style:none"
                ExcelC.pCellStyle(2) = "width:122px;border-style:none"
                ExcelC.pCellStyle(3) = "width:72px;border-style:none"
                ExcelC.pCellStyle(4) = "width:72px;border-style:none"

                'ExcelC.pCellStyle(5) = "width:72px;border-style:none"  '20050803 NEC UPDATE
                ExcelC.pCellStyle(5) = "width:90px;border-style:none"
                'ExcelC.pCellStyle(6) = "width:115px;border-style:none" ' 2010/10/07
                'ExcelC.pCellStyle(7) = "width:72px;border-style:none" ' 2010/10/07
                ExcelC.pCellStyle(6) = "width:67px;border-style:none"
                ExcelC.pCellStyle(7) = "width:120px;border-style:none"
                ExcelC.pCellStyle(8) = "width:52px;border-style:none"
                ExcelC.pCellStyle(9) = "width:80px;border-style:none"
                'ExcelC.pCellStyle(10) = "width:80px;border-style:none"'20050803 NEC UPDATE
                'ExcelC.pCellStyle(10) = "width:62px;border-style:none" ' 2010/09/17 T.Watabe edit
                ExcelC.pCellStyle(10) = "width:3px;border-style:none"
                ExcelC.pCellStyle(11) = "width:3px;border-style:none" ' 2010/09/17 T.Watabe add
                ExcelC.pCellStyle(12) = "width:3px;border-style:none" ' 2010/09/17 T.Watabe add
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
                ExcelC.pCellVal(11) = "" ' 2010/09/17 T.Watabe add
                ExcelC.pCellVal(12) = "" ' 2010/09/17 T.Watabe add
                ExcelC.mWriteLine("")   '行をファイルに書き込む

                '--------------------------------------------------
                'データの出力
                '--------------------------------------------------
                Dim intRowCount As Integer
                Dim strSTD_CD As String
                Dim strTFKICD As String         '--- 2005/07/12 ADD Falcon ---

                'ループする
                For Each dr In ds.Tables(0).Rows

                    sZipFilePass = Convert.ToString(dr.Item("YOBI5")) ' 2008/12/12 T.Watabe add

                    If cliCd4FileHead.Length <= 0 Then '空？→最初？
                        cliCd4FileHead = Convert.ToString(dr.Item("CLI_CD")) '2011/03/10 T.Watabe add
                    End If

                    '2006/06/14 NEC UPDATE START
                    '1行目
                    ExcelC.pCellStyle(1) = "border-style:none"
                    If pstrAUTO = "1" Then
                        'ExcelC.pCellVal(1, "colspan=6") = "送信先FAX番号：" & Convert.ToString(dr.Item("AUTO_FAX")) ' 2010/05/24 T.Watabe edit
                        ExcelC.pCellVal(1, "colspan=6") = "送信先FAX番号：" & pstrFAXNO
                    Else
                        ExcelC.pCellVal(1, "colspan=6") = ""
                    End If
                    ExcelC.mWriteLine("")   '行をファイルに書き込む
                    '2006/06/14 NEC UPDATE END
                    '2行目
                    ExcelC.pCellStyle(1) = "border-style:none"
                    ExcelC.pCellStyle(2) = "border-style:none"

                    'JA名が長いとき改行される
                    'ExcelC.pCellVal(1, "colspan=3") = "ＪＡ名：" & Convert.ToString(dr.Item("JANM")) '2005/12/22 NEC UPDATE
                    'ExcelC.pCellVal(2, "colspan=7") = "支所名：" & Convert.ToString(dr.Item("ACBNM")) & "　御中" '2005/12/22 NEC UPDATE
                    'ExcelC.pCellVal(1, "colspan=4") = "ＪＡ名：" & Convert.ToString(dr.Item("JANM"))  '2006/06/14 NEC UPDATE 
                    'ExcelC.pCellVal(2, "colspan=6") = "支所名：" & Convert.ToString(dr.Item("ACBNM")) & "　御中"  '2006/06/14 NEC UPDATE 
                    ExcelC.pCellVal(1, "colspan=10") = "ＪＡ支所名　 ：" & Convert.ToString(dr.Item("ACBNM")) & "　御中"
                    ExcelC.mWriteLine("")   '行をファイルに書き込む

                    '3行目
                    ExcelC.pCellStyle(1) = "border-style:none"
                    'ExcelC.pCellStyle(2) = "border-style:none"
                    'ExcelC.pCellStyle(3) = "border-style:none"
                    ExcelC.pCellVal(1, "colspan=10") = "県　　　名　 ：" & Convert.ToString(dr.Item("KENNM"))
                    'ExcelC.pCellVal(2, "colspan=4") = "供給センター名：" & Convert.ToString(dr.Item("NAME"))
                    '2006/06/14 NEC UPDATE START
                    'If pstrAUTO = "1" Then
                    '    ExcelC.pCellVal(3, "colspan=4 align=right") = "FAX番号：" & Convert.ToString(dr.Item("AUTO_FAX"))
                    'Else
                    '    '''''ExcelC.pCellVal(3, "colspan=4 align=right") = "ﾒｰﾙｱﾄﾞﾚｽ：" & Convert.ToString(dr.Item("AUTO_MAIL"))
                    '    ExcelC.pCellVal(3, "colspan=4 align=right") = ""
                    'End If
                    '2006/06/14 NEC UPDATE END
                    ExcelC.mWriteLine("")   '行をファイルに書き込む

                    '4行目
                    '2006/06/14 NEC UPDATE START
                    ExcelC.pCellStyle(1) = "border-style:none"
                    ExcelC.pCellStyle(2) = "border-style:none"
                    ExcelC.pCellVal(1, "colspan=6") = "供給ｾﾝﾀｰ名　 ：" & Convert.ToString(dr.Item("NAME"))
                    ExcelC.pCellVal(2, "colspan=4 align=right") = "発行者TEL：" & Convert.ToString(drKansimas.Item("TEL"))
                    '2006/06/14 NEC UPDATE END
                    ExcelC.mWriteLine("")   '行をファイルに書き込む

                    '5行目
                    ExcelC.pCellStyle(1) = "border-style:none"
                    '2006/06/14 NEC UPDATE START
                    'ExcelC.pCellVal(1, "colspan=10 align=right") = pstrSEND_JALP_NAME   '//㈱JA-LPｶﾞｽ情報ｾﾝﾀｰ
                    ExcelC.pCellVal(1, "colspan=10 align=right") = "発行者：" & pstrSEND_JALP_NAME   '//㈱JA-LPｶﾞｽ情報ｾﾝﾀｰ
                    '2006/06/14 NEC UPDATE END
                    ExcelC.mWriteLine("")   '行をファイルに書き込む

                    '6行目
                    ExcelC.pCellStyle(1) = "border-style:none"
                    ExcelC.pCellVal(1, "colspan=10 align=right") = pstrSEND_CENT_NAME   '//ＬＰガス集中センター
                    ExcelC.mWriteLine("")   '行をファイルに書き込む

                    '7行目
                    ExcelC.pCellStyle(1) = "border-bottom-style:none;border-left-style:none;border-right-style:none"
                    ExcelC.pCellVal(1, "colspan=10") = ""
                    ExcelC.mWriteLine("")   '行をファイルに書き込む

                    '8行目
                    ExcelC.pCellStyle(1) = "border-style:none"
                    ExcelC.pCellVal(1, "colspan=10") = "<<受信情報>>"
                    ExcelC.mWriteLine("")   '行をファイルに書き込む

                    '9行目
                    'ExcelC.mWriteLine("")   '行をファイルに書き込む    '--- 2005/05/19 DEL Falcon ---

                    '10行目
                    ExcelC.pCellStyle(1) = "border-style:none;height:36px;vertical-align:top"
                    ExcelC.pCellStyle(2) = "border-style:none;height:36px;vertical-align:top"
                    ExcelC.pCellVal(1, "colspan=6") = "お客様氏名：" & Convert.ToString(dr.Item("JUSYONM"))
                    ExcelC.pCellVal(2, "colspan=4") = "お客様ｺｰﾄﾞ：" & Convert.ToString(dr.Item("ACBCD")) & Convert.ToString(dr.Item("USER_CD"))
                    ExcelC.mWriteLine("")   '行をファイルに書き込む

                    '11行目
                    'ExcelC.mWriteLine("")   '行をファイルに書き込む

                    '12行目
                    ExcelC.pCellStyle(1) = "border-style:none"
                    ExcelC.pCellStyle(2) = "border-style:none"
                    '2006/06/14 NEC UPDATE START
                    'ExcelC.pCellVal(1, "colspan=4") = "電話番号：" & Convert.ToString(dr.Item("KTELNO"))
                    If Convert.ToString(dr.Item("JUTEL1")) = "" Or Convert.ToString(dr.Item("JUTEL2")) = "" Then
                        ExcelC.pCellVal(1, "colspan=6") = "電話番号　：" & Convert.ToString(dr.Item("JUTEL1")) & Convert.ToString(dr.Item("JUTEL2"))
                    Else
                        ExcelC.pCellVal(1, "colspan=6") = "電話番号　：" & Convert.ToString(dr.Item("JUTEL1")) & "-" & Convert.ToString(dr.Item("JUTEL2"))
                    End If
                    '2006/06/14 NEC UPDATE END
                    ExcelC.pCellVal(2, "colspan=4") = "連絡電話番号：" & Convert.ToString(dr.Item("RENTEL"))
                    ExcelC.mWriteLine("")   '行をファイルに書き込む

                    '13行目
                    ExcelC.pCellStyle(1) = "border-style:none"
                    ExcelC.pCellVal(1, "colspan=10") = "住所　　　：" & Convert.ToString(dr.Item("ADDR"))
                    ExcelC.mWriteLine("")   '行をファイルに書き込む

                    '14行目
                    ExcelC.mWriteLine("")   '行をファイルに書き込む

                    '15行目
                    ExcelC.pCellStyle(1) = "border-style:none"
                    ExcelC.pCellStyle(2) = "border-style:none"
                    ExcelC.pCellStyle(3) = "border-style:none"
                    ExcelC.pCellVal(1, "colspan=3") = "取引中止日：" & fncDateSet(Convert.ToString(dr.Item("GAS_START")))
                    ExcelC.pCellVal(2, "colspan=3") = "取引廃止日　　：" & fncDateSet(Convert.ToString(dr.Item("GAS_DELE")))
                    ExcelC.pCellVal(3, "colspan=4") = "地図番号　：" & Convert.ToString(dr.Item("TIZUNO"))
                    ExcelC.mWriteLine("")   '行をファイルに書き込む

                    '16行目
                    ExcelC.pCellStyle(1) = "border-style:none"
                    ExcelC.pCellStyle(2) = "border-style:none"
                    ExcelC.pCellVal(1, "colspan=3") = "集合区分　：" & Convert.ToString(dr.Item("SHUGOUNM"))
                    '2006/06/14 NEC UPDATE START
                    'If Convert.ToString(dr.Item("NCU_SET")) = "3" Then      '3:未接続
                    '    ExcelC.pCellVal(2, "colspan=7") = "ＮＣＵ設置区分：" & "無"
                    'Else
                    '    ExcelC.pCellVal(2, "colspan=7") = "ＮＣＵ設置区分：" & "有"
                    'End If
                    If Convert.ToString(dr.Item("NCU_SET")) = "3" Then      '3:未接続
                        ExcelC.pCellVal(2, "colspan=3") = "ＮＣＵ設置区分：" & "無"
                    Else
                        ExcelC.pCellVal(2, "colspan=3") = "ＮＣＵ設置区分：" & "有"
                    End If
                    ExcelC.pCellStyle(3) = "border-style:none"
                    Select Case Convert.ToString(dr.Item("USER_FLG"))
                        Case "0"
                            '0:未開通
                            ExcelC.pCellVal(3, "colspan=4") = "お客様状態：" & "未開通"
                        Case "1"
                            '1:運用中
                            ExcelC.pCellVal(3, "colspan=4") = "お客様状態：" & "運用中"
                        Case "2"
                            '2:休止中
                            ExcelC.pCellVal(3, "colspan=4") = "お客様状態：" & "休止中"
                        Case Else
                            'その他
                            ExcelC.pCellVal(3, "colspan=4") = "お客様状態："
                    End Select
                    '2006/06/14 NEC UPDATE END
                    ExcelC.mWriteLine("")   '行をファイルに書き込む

                    '17行目
                    ExcelC.mWriteLine("")   '行をファイルに書き込む

                    '18行目
                    ExcelC.pCellStyle(1) = "border-style:none"
                    ExcelC.pCellVal(1, "colspan=10") = "【警報内容】"
                    ExcelC.mWriteLine("")   '行をファイルに書き込む

                    '19行目
                    ExcelC.pCellStyle(1) = "border-style:none"
                    ExcelC.pCellStyle(2) = "border-style:none"
                    ExcelC.pCellStyle(3) = "border-style:none"
                    'ExcelC.pCellStyle(4) = "border-style:none"
                    ExcelC.pCellVal(1, "colspan=3") = "発生日：" & fncDateSet(Convert.ToString(dr.Item("HATYMD"))) & " " & fncTimeSet(Convert.ToString(dr.Item("HATTIME")))
                    ExcelC.pCellVal(2, "colspan=2") = "メータ値：" & Convert.ToString(dr.Item("KENSIN"))
                    'ExcelC.pCellVal(3, "colspan=1") = "流量区分：" & Convert.ToString(dr.Item("RYURYO"))    '名称ではない
                    'ExcelC.pCellVal(4, "colspan=4") = "メータ種別：" & Convert.ToString(dr.Item("METASYU"))
                    ExcelC.pCellVal(3, "colspan=5") = "流量区分：" & Convert.ToString(dr.Item("RYURYO")) & "　メータ種別：" & Convert.ToString(dr.Item("METASYU"))
                    ExcelC.mWriteLine("")   '行をファイルに書き込む

                    '20行目
                    ExcelC.pCellStyle(1) = "border-style:none"
                    ExcelC.pCellStyle(2) = "border-style:none"
                    ExcelC.pCellVal(1, "colspan=5") = "1：" & Convert.ToString(dr.Item("KMNM1"))
                    '2006/06/14 NEC UPDATE START
                    'ExcelC.pCellVal(2, "colspan=5") = "2：" & Convert.ToString(dr.Item("KMNM2"))
                    ExcelC.pCellVal(2, "colspan=5") = "4：" & Convert.ToString(dr.Item("KMNM4"))
                    '2006/06/14 NEC UPDATE END
                    ExcelC.mWriteLine("")   '行をファイルに書き込む

                    '21行目
                    ExcelC.pCellStyle(1) = "border-style:none"
                    ExcelC.pCellStyle(2) = "border-style:none"
                    '2006/06/14 NEC UPDATE START
                    'ExcelC.pCellVal(1, "colspan=5") = "3：" & Convert.ToString(dr.Item("KMNM3"))
                    'ExcelC.pCellVal(2, "colspan=5") = "4：" & Convert.ToString(dr.Item("KMNM4"))
                    ExcelC.pCellVal(1, "colspan=5") = "2：" & Convert.ToString(dr.Item("KMNM2"))
                    ExcelC.pCellVal(2, "colspan=5") = "5：" & Convert.ToString(dr.Item("KMNM5"))
                    '2006/06/14 NEC UPDATE END
                    ExcelC.mWriteLine("")   '行をファイルに書き込む

                    '22行目
                    ExcelC.pCellStyle(1) = "border-style:none"
                    ExcelC.pCellStyle(2) = "border-style:none"
                    '2006/06/14 NEC UPDATE START
                    'ExcelC.pCellVal(1, "colspan=5") = "5：" & Convert.ToString(dr.Item("KMNM5"))
                    ExcelC.pCellVal(1, "colspan=5") = "3：" & Convert.ToString(dr.Item("KMNM3"))
                    '2006/06/14 NEC UPDATE END
                    ExcelC.pCellVal(2, "colspan=5") = "6：" & Convert.ToString(dr.Item("KMNM6"))
                    ExcelC.mWriteLine("")   '行をファイルに書き込む

                    '23行目
                    ExcelC.pCellStyle(1) = "border-style:none"
                    '2005/10/03 NEC UPDATE START
                    '共有マスタに顧客がいなかったら表示する
                    '                If Convert.ToString(dr.Item("MITOKBN")) = "1" Then
                    If Convert.ToString(dr.Item("SH_USER")) = "" Then
                        '2005/10/03 NEC UPDATE END
                        ExcelC.pCellVal(1, "colspan=10") = "お客様マスター　氏名、住所、電話番号をご確認の上、ご連絡ください。"
                    Else
                        ExcelC.pCellVal(1, "colspan=10") = ""
                    End If
                    ExcelC.mWriteLine("")   '行をファイルに書き込む

                    '24行目
                    ExcelC.pCellStyle(1) = "border-bottom-style:none;border-left-style:none;border-right-style:none"
                    ExcelC.pCellVal(1, "colspan=10") = ""
                    ExcelC.mWriteLine("")   '行をファイルに書き込む

                    '25行目
                    ExcelC.pCellStyle(1) = "border-style:none"
                    ExcelC.pCellVal(1, "colspan=10") = "<<監視センター対応内容>>"
                    ExcelC.mWriteLine("")   '行をファイルに書き込む

                    '26行目
                    ExcelC.pCellStyle(1) = "border-style:none"
                    ExcelC.pCellStyle(2) = "border-style:none"
                    ExcelC.pCellStyle(3) = "border-style:none"
                    ExcelC.pCellVal(1, "colspan=3") = "対応区分　　：" & Convert.ToString(dr.Item("TAIOKBN_NAI"))
                    ExcelC.pCellVal(2, "colspan=2") = "処理区分：" & Convert.ToString(dr.Item("TMSKB_NAI"))
                    ExcelC.pCellVal(3, "colspan=5") = "処理番号(照会用)：" & Convert.ToString(dr.Item("SYONO"))
                    ExcelC.mWriteLine("")   '行をファイルに書き込む

                    '27行目
                    ExcelC.pCellStyle(1) = "border-style:none"
                    ExcelC.pCellStyle(2) = "border-style:none"
                    ExcelC.pCellVal(1, "colspan=5") = "監視ｾﾝﾀｰ担当：" & Convert.ToString(dr.Item("TKTANCD_NM"))
                    'ExcelC.pCellVal(2, "colspan=5") = "対応日：" & fncDateSet(Convert.ToString(dr.Item("SYOYMD"))) & " " & fncTimeSet(Convert.ToString(dr.Item("SYOTIME"))) ' 2008/10/14 T.Watabe edit
                    ExcelC.pCellVal(2, "colspan=5") = "完了日時　　　　：" & fncDateSet(Convert.ToString(dr.Item("SYOYMD"))) & " " & fncTimeSet(Convert.ToString(dr.Item("SYOTIME")))
                    ExcelC.mWriteLine("")   '行をファイルに書き込む

                    '28行目
                    ExcelC.mWriteLine("")   '行をファイルに書き込む

                    '29行目
                    ExcelC.pCellStyle(1) = "border-style:none"
                    ExcelC.pCellVal(1, "colspan=10") = "連絡相手　　：" & Convert.ToString(dr.Item("TAITNM"))
                    ExcelC.mWriteLine("")   '行をファイルに書き込む

                    '30行目
                    ExcelC.pCellStyle(1) = "border-style:none"
                    ExcelC.pCellVal(1, "colspan=10") = "電話連絡内容：" & Convert.ToString(dr.Item("TELRNM"))
                    ExcelC.mWriteLine("")   '行をファイルに書き込む

                    '--- ↓2005/05/17 MOD Falcon↓ ---
                    '出力順を電話メモ１⇒電話メモ２⇒復帰操作メモに修正
                    ''31行目
                    ''ExcelC.pCellStyle(1) = "border-style:none"
                    'ExcelC.pCellStyle(1) = "border-style:none;height:36px"  '--- 2005/05/19 MOD Falcon ---
                    'ExcelC.pCellVal(1, "colspan=10") = Convert.ToString(dr.Item("TEL_MEMO1"))
                    'ExcelC.mWriteLine("")   '行をファイルに書き込む

                    ''32行目
                    'If Convert.ToString(dr.Item("TEL_MEMO2")).Trim.Length > 0 Then ' 2010/10/06 T.Watabe edit ﾃﾞｰﾀが無ければ詰める
                    '    'ExcelC.pCellStyle(1) = "border-style:none"
                    '    ExcelC.pCellStyle(1) = "border-style:none;height:36px"  '--- 2005/05/19 MOD Falcon ---
                    '    ExcelC.pCellVal(1, "colspan=10") = Convert.ToString(dr.Item("TEL_MEMO2"))
                    '    ExcelC.mWriteLine("")   '行をファイルに書き込む
                    'End If

                    ''33行目
                    'If Convert.ToString(dr.Item("FUK_MEMO")).Trim.Length > 0 Then ' 2010/10/06 T.Watabe edit ﾃﾞｰﾀが無ければ詰める
                    '    'ExcelC.pCellStyle(1) = "border-style:none"
                    '    ExcelC.pCellStyle(1) = "border-style:none;height:36px"  '--- 2005/05/19 MOD Falcon ---
                    '    ExcelC.pCellVal(1, "colspan=10") = Convert.ToString(dr.Item("FUK_MEMO"))
                    '    ExcelC.mWriteLine("")   '行をファイルに書き込む
                    'End If
                    '31行目
                    ExcelC.pCellStyle(1) = "border-style:none"
                    ExcelC.pCellStyle(2) = "border-style:none;height:64px;vertical-align:top"
                    ExcelC.pCellVal(1) = ""
                    ExcelC.pCellVal(2, "colspan=9") = Convert.ToString(dr.Item("TEL_MEMO1")) & Convert.ToString(dr.Item("TEL_MEMO2")) & Convert.ToString(dr.Item("FUK_MEMO"))
                    ExcelC.mWriteLine("")   '行をファイルに書き込む
                    '--- ↑2005/05/17 MOD Falcon↑ ---

                    '34行目
                    ExcelC.pCellStyle(1) = "border-style:none"
                    ExcelC.pCellVal(1, "colspan=10") = "原因器具名　：" & Convert.ToString(dr.Item("TKIGNM"))
                    ExcelC.mWriteLine("")   '行をファイルに書き込む

                    '35行目
                    ExcelC.pCellStyle(1) = "border-style:none"
                    ExcelC.pCellVal(1, "colspan=10") = "作動原因　　：" & Convert.ToString(dr.Item("TSADNM"))
                    ExcelC.mWriteLine("")   '行をファイルに書き込む

                    '36行目
                    '2006/06/14 NEC UPDATE START
                    ExcelC.pCellStyle(1) = "border-style:none"
                    ExcelC.pCellVal(1, "colspan=10") = "出動指示　　：" & Convert.ToString(dr.Item("SDNM"))
                    '2006/06/14 NEC UPDATE END
                    ExcelC.mWriteLine("")   '行をファイルに書き込む

                    '37行目
                    ExcelC.pCellStyle(1) = "border-style:none"
                    ExcelC.pCellVal(1, "colspan=10") = "出動指示備考：" & Convert.ToString(dr.Item("SIJI_BIKO1"))
                    ExcelC.mWriteLine("")   '行をファイルに書き込む

                    '38行目
                    ExcelC.pCellStyle(1) = "border-style:none"
                    ExcelC.pCellVal(1, "colspan=10") = "　　　　　　　" & Convert.ToString(dr.Item("siji_biko2"))
                    ExcelC.mWriteLine("")   '行をファイルに書き込む

                    '39行目
                    '2006/06/15 NEC UPDATE START
                    'ExcelC.mWriteLine("")   '行をファイルに書き込む
                    '2006/06/15 NEC UPDATE END

                    '40行目
                    ExcelC.pCellStyle(1) = "border-bottom-style:none;border-left-style:none;border-right-style:none"
                    ExcelC.pCellVal(1, "colspan=10") = ""
                    ExcelC.mWriteLine("")   '行をファイルに書き込む

                    '--- ↓2005/05/25 ADD Falcon↓ ---
                    '--- ↓2005/05/23 ADD Falcon↓ ---
                    strSTD_CD = Convert.ToString(dr.Item("STD_CD"))
                    '--- ↑2005/05/23 ADD Falcon↑ ---

                    '--- ↓2005/07/13 ADD Falcon↓ ---
                    strTFKICD = Convert.ToString(dr.Item("TFKICD"))         '復帰対応状況
                    '--- ↑2005/07/13 ADD Falcon↑ ---

                    '--- ↓2005/05/31 MOD Falcon↓ ---
                    'If strSTD_CD.Length <> 0 And Convert.ToString(dr.Item("TAIOKBN")) = "2" Then                       '--- 2005/07/13 DEL Falcon
                    If strSTD_CD.Length <> 0 And Convert.ToString(dr.Item("TAIOKBN")) = "2" And strTFKICD = "8" Then    '--- 2005/07/13 MOD Falcon
                        '---------- 出動指示の場合のみデータ出力する ---------------------------
                        '41行目
                        ExcelC.pCellStyle(1) = "border-style:none"
                        ExcelC.pCellStyle(2) = "border-style:none" ' 2008/10/21 T.Watabe add
                        'ExcelC.pCellVal(1, "colspan=10") = "<<出動会社対応内容>>"
                        ExcelC.pCellVal(1, "colspan=6") = "<<出動会社対応内容>>"
                        ExcelC.pCellVal(2, "colspan=4 align=right") = "処理区分：" & Convert.ToString(dr.Item("SDSKBN_NAI")) ' 2008/10/21 T.Watabe add
                        ExcelC.mWriteLine("")   '行をファイルに書き込む

                        '42行目
                        ExcelC.pCellStyle(1) = "border-style:none"
                        ExcelC.pCellVal(1, "colspan=10") = "出動委託先（指定保安機関）：" & Convert.ToString(dr.Item("STD"))
                        ExcelC.mWriteLine("")   '行をファイルに書き込む

                        '43行目
                        ExcelC.pCellStyle(1) = "border-style:none"
                        ExcelC.pCellVal(1, "colspan=10") = "支所･拠点名：" & Convert.ToString(dr.Item("STD_KYOTEN"))
                        ExcelC.mWriteLine("")   '行をファイルに書き込む

                        '44行目
                        ExcelC.pCellStyle(1) = "border-style:none"
                        ExcelC.pCellStyle(2) = "border-style:none"
                        ExcelC.pCellStyle(3) = "border-style:none"
                        ExcelC.pCellVal(1, "colspan=3") = "対応者　　 ：" & Convert.ToString(dr.Item("SYUTDTNM"))
                        'ExcelC.pCellVal(2, "colspan=3") = "到着時間：" & fncDateSet(Convert.ToString(dr.Item("TYAKYMD"))) & " " & fncTimeSet(Convert.ToString(dr.Item("TYAKTIME"))) ' 2008/10/14 T.Watabe edit
                        'ExcelC.pCellVal(3, "colspan=4") = "措置完了時間：" & fncDateSet(Convert.ToString(dr.Item("SYOKANYMD"))) & " " & fncTimeSet(Convert.ToString(dr.Item("SYOKANTIME"))) ' 2008/10/14 T.Watabe edit
                        ExcelC.pCellVal(2, "colspan=3") = "受信日時：" & fncDateSet(Convert.ToString(dr.Item("SIJIYMD"))) & " " & fncTimeSet(Convert.ToString(dr.Item("SIJITIME"))) '受信日時(出動指示日＆時刻)
                        ExcelC.pCellVal(3, "colspan=4") = "出動日時　　：" & fncDateSet(Convert.ToString(dr.Item("SDYMD"))) & " " & fncTimeSet(Convert.ToString(dr.Item("SDTIME")))
                        ExcelC.mWriteLine("")   '行をファイルに書き込む

                        '45行目
                        ExcelC.pCellStyle(1) = "border-style:none"
                        ExcelC.pCellStyle(2) = "border-style:none" ' 2008/10/14 T.Watabe add
                        ExcelC.pCellStyle(3) = "border-style:none" ' 2008/10/14 T.Watabe add
                        'ExcelC.pCellVal(1, "colspan=10") = "対応相手：" & Convert.ToString(dr.Item("AITNM")) ' 2008/10/14 T.Watabe edit
                        ExcelC.pCellVal(1, "colspan=3") = "対応相手　 ：" & Convert.ToString(dr.Item("AITNM"))
                        ExcelC.pCellVal(2, "colspan=3") = "到着日時：" & fncDateSet(Convert.ToString(dr.Item("TYAKYMD"))) & " " & fncTimeSet(Convert.ToString(dr.Item("TYAKTIME"))) ' 2008/10/14 T.Watabe add
                        ExcelC.pCellVal(3, "colspan=4") = "措置完了日時：" & fncDateSet(Convert.ToString(dr.Item("SYOKANYMD"))) & " " & fncTimeSet(Convert.ToString(dr.Item("SYOKANTIME"))) ' 2008/10/14 T.Watabe add
                        ExcelC.mWriteLine("")   '行をファイルに書き込む

                        ' 2008/11/04 T.Watabe del 
                        ''46行目
                        'ExcelC.mWriteLine("")   '行をファイルに書き込む

                        '47行目
                        ExcelC.pCellStyle(1) = "border-style:none"
                        '2006/06/14 NEC UPDATE START
                        'If Convert.ToString(dr.Item("CSNTNGAS")) = "1" Then
                        '    ExcelC.pCellVal(1, "colspan=10") = "【お客様のお話内容】 " & Convert.ToString(dr.Item("SDTBIK1"))
                        'Else
                        '    If Convert.ToString(dr.Item("METFUKKI")) = "1" Then
                        '        ExcelC.pCellVal(1, "colspan=10") = "【お客様のお話内容】 " & "メータ復帰"
                        '    ElseIf Convert.ToString(dr.Item("HOAN")) = "1" Then
                        '        ExcelC.pCellVal(1, "colspan=10") = "【お客様のお話内容】 " & "保安"
                        '    ElseIf Convert.ToString(dr.Item("GASGIRE")) = "1" Then
                        '        ExcelC.pCellVal(1, "colspan=10") = "【お客様のお話内容】 " & "ガス切れ"
                        '    ElseIf Convert.ToString(dr.Item("KIGKOSYO")) = "1" Then
                        '        ExcelC.pCellVal(1, "colspan=10") = "【お客様のお話内容】 " & "器具故障"
                        '    ElseIf Convert.ToString(dr.Item("CSNTGEN")) = "1" Then
                        '        ExcelC.pCellVal(1, "colspan=10") = "【お客様のお話内容】 " & "その他"
                        '    Else
                        '        ExcelC.pCellVal(1, "colspan=10") = "【お客様のお話内容】 " & ""
                        '    End If
                        'End If

                        ExcelC.pCellVal(1, "colspan=10") = "【お客様のお話内容】"
                        ExcelC.mWriteLine("")   '行をファイルに書き込む
                        '48行目
                        ExcelC.pCellStyle(1) = "border-style:none"
                        ExcelC.pCellStyle(2) = "border-style:none"
                        ExcelC.pCellStyle(3) = "border-style:none"
                        ExcelC.pCellVal(1) = ""
                        If Convert.ToString(dr.Item("METFUKKI")) = "1" Then
                            ExcelC.pCellVal(2, "colspan=3") = "ガス関連：" & "メータ復帰"
                        ElseIf Convert.ToString(dr.Item("HOAN")) = "1" Then
                            ExcelC.pCellVal(2, "colspan=3") = "ガス関連：" & "保安"
                        ElseIf Convert.ToString(dr.Item("GASGIRE")) = "1" Then
                            ExcelC.pCellVal(2, "colspan=3") = "ガス関連：" & "ガス切れ"
                        ElseIf Convert.ToString(dr.Item("KIGKOSYO")) = "1" Then
                            ExcelC.pCellVal(2, "colspan=3") = "ガス関連：" & "器具故障"
                        ElseIf Convert.ToString(dr.Item("CSNTGEN")) = "1" Then
                            ExcelC.pCellVal(2, "colspan=3") = "ガス関連：" & "その他"
                        Else
                            ExcelC.pCellVal(2, "colspan=3") = "ガス関連：" & ""
                        End If
                        ExcelC.mWriteLine("")   '行をファイルに書き込む

                        '49行目
                        ExcelC.pCellStyle(1) = "border-style:none"
                        ExcelC.pCellStyle(2) = "border-style:none"
                        ExcelC.pCellVal(1) = ""
                        ExcelC.pCellVal(2, "colspan=9") = "お話内容：" & Convert.ToString(dr.Item("SDTBIK1"))
                        ExcelC.mWriteLine("")   '行をファイルに書き込む
                        '2006/06/14 NEC UPDATE END

                        '50行目
                        ExcelC.pCellStyle(1) = "border-style:none"
                        ExcelC.pCellStyle(2) = "border-style:none"
                        ExcelC.pCellVal(1, "colspan=5") = "復帰対応：" & Convert.ToString(dr.Item("FKINM"))
                        'If Convert.ToString(dr.Item("KIGTAIYO")) = "1" Then  '1:有 ' 2008/10/21 T.Watabe edit
                        '    ExcelC.pCellVal(2, "colspan=5") = "簡易ガス器具の貸与：" & "有"
                        'Else
                        '    ExcelC.pCellVal(2, "colspan=5") = "簡易ガス器具の貸与：" & "無"
                        'End If
                        ExcelC.pCellVal(2, "colspan=5") = "メータ作動原因１　：" & Convert.ToString(dr.Item("SADNM")) '1:有 ' 2008/10/21 T.Watabe add
                        ExcelC.mWriteLine("")   '行をファイルに書き込む

                        ' ▼ 2008/10/14 T.Watabe add
                        '50行目+1
                        ExcelC.pCellStyle(1) = "border-style:none"
                        ExcelC.pCellStyle(2) = "border-style:none"
                        ExcelC.pCellVal(1, "colspan=5") = "ガス器具：" & Convert.ToString(dr.Item("KIGNM"))
                        If Convert.ToString(dr.Item("KIGTAIYO")) = "1" Then  '1:有
                            ExcelC.pCellVal(2, "colspan=5") = "簡易ガス器具の貸与：" & "有"
                        Else
                            ExcelC.pCellVal(2, "colspan=5") = "簡易ガス器具の貸与：" & "無"
                        End If
                        ExcelC.mWriteLine("")   '行をファイルに書き込む
                        ' ▲ 2008/10/14 T.Watabe add

                        '51行目
                        ExcelC.pCellStyle(1) = "border-style:none"
                        ExcelC.pCellStyle(2) = "border-style:none"
                        ExcelC.pCellVal(1, "colspan=5") = "連絡状況 連絡相手：" & Convert.ToString(dr.Item("JAKENREN")) & "　様"
                        ExcelC.pCellVal(2, "colspan=5") = "連絡時間　　　　　：" & fncTimeSet(Convert.ToString(dr.Item("RENTIME")))
                        ExcelC.mWriteLine("")   '行をファイルに書き込む

                        '52行目
                        ExcelC.pCellStyle(1) = "border-style:none"
                        ExcelC.pCellStyle(2) = "border-style:none"
                        If Convert.ToString(dr.Item("GASMUMU")) = "0" Then  ' 0：有　1：無
                            ExcelC.pCellVal(1, "colspan=2") = "ガス漏れ点検：" & "有"
                        Else
                            ExcelC.pCellVal(1, "colspan=2") = "ガス漏れ点検：" & "無"
                        End If
                        If Convert.ToString(dr.Item("ORGENIN")) = "1" Then  'ガス器具　1:有
                            ExcelC.pCellVal(2, "colspan=8") = "原因：" & "ガス器具"
                        Else
                            ExcelC.pCellVal(2, "colspan=8") = "原因：" & ""
                        End If
                        ExcelC.mWriteLine("")   '行をファイルに書き込む

                        '53行目
                        ExcelC.pCellStyle(1) = "border-style:none"
                        ExcelC.pCellStyle(2) = "border-style:none"
                        ExcelC.pCellStyle(3) = "border-style:none"
                        If Convert.ToString(dr.Item("GASGUMU")) = "0" Then      '0：有　1：無
                            ExcelC.pCellVal(1, "colspan=2") = "ガス切れ点検：" & "有"
                        Else
                            ExcelC.pCellVal(1, "colspan=2") = "ガス切れ点検：" & "無"
                        End If
                        If Convert.ToString(dr.Item("HOSKOKAN")) = "0" Then     '0：実施　1：未実施
                            ExcelC.pCellVal(2, "colspan=5") = "ｺﾞﾑﾎｰｽ交換：" & "実施"
                        Else
                            ExcelC.pCellVal(2, "colspan=5") = "ｺﾞﾑﾎｰｽ交換：" & "未実施"
                        End If
                        If Convert.ToString(dr.Item("COYOINA")) = "0" Then      '0：良　1：否
                            ExcelC.pCellVal(3, "colspan=3") = "ＣＯ濃度：" & "良"
                        Else
                            ExcelC.pCellVal(3, "colspan=3") = "ＣＯ濃度：" & "否"
                        End If
                        ExcelC.mWriteLine("")   '行をファイルに書き込む

                        '54行目
                        ExcelC.pCellStyle(1) = "border-style:none"
                        ExcelC.pCellStyle(2) = "border-style:none"
                        ExcelC.pCellStyle(3) = "border-style:none"
                        ExcelC.pCellStyle(4) = "border-style:none"
                        If Convert.ToString(dr.Item("METYOINA")) = "0" Then      '0：良　1：否
                            ExcelC.pCellVal(1, "colspan=2") = "メータ点検　：" & "良"
                        Else
                            ExcelC.pCellVal(1, "colspan=2") = "メータ点検　：" & "否"
                        End If
                        If Convert.ToString(dr.Item("TYOUYOINA")) = "0" Then      '0：良　1：否
                            ExcelC.pCellVal(2, "colspan=3") = "調整期点検：" & "良"
                        Else
                            ExcelC.pCellVal(2, "colspan=3") = "調整期点検：" & "否"
                        End If
                        If Convert.ToString(dr.Item("VALYOINA")) = "0" Then      '0：良　1：否
                            ExcelC.pCellVal(3, "colspan=2") = "容器･中間バルブ：" & "良"
                        Else
                            ExcelC.pCellVal(3, "colspan=2") = "容器･中間バルブ：" & "否"
                        End If
                        If Convert.ToString(dr.Item("KYUHAIUMU")) = "0" Then      '0：良　1：否
                            ExcelC.pCellVal(4, "colspan=3") = "吸排気口：" & "良"
                        Else
                            ExcelC.pCellVal(4, "colspan=3") = "吸排気口：" & "否"
                        End If
                        ExcelC.mWriteLine("")   '行をファイルに書き込む

                        '--- ↓2005/09/09 MOD Falcon↓ ---
                        '2006/06/14 NEC UPDATE START
                        ''55行目
                        'ExcelC.pCellStyle(1) = "border-style:none"
                        'ExcelC.pCellVal(1, "colspan=10") = "特記事項："
                        ''ExcelC.pCellVal(1, "colspan=10") = "特記事項：" & Convert.ToString(dr.Item("SDTBIK2"))
                        'ExcelC.mWriteLine("")   '行をファイルに書き込む

                        ''56行目
                        'ExcelC.pCellStyle(1) = "border-style:none;font-size:10pt;height:36px"
                        'ExcelC.pCellVal(1, "colspan=10") = Convert.ToString(dr.Item("SDTBIK2"))
                        'ExcelC.mWriteLine("")   '行をファイルに書き込む

                        ''57行目
                        'ExcelC.pCellStyle(1) = "border-style:none"
                        'ExcelC.pCellVal(1, "colspan=10") = "ＪＡ／県連様への依頼事項等："
                        'ExcelC.mWriteLine("")   '行をファイルに書き込む

                        ''58行目
                        'ExcelC.pCellStyle(1) = "border-style:none;font-size:10pt;height:36px"
                        ''ExcelC.pCellStyle(1) = "border-style:none"
                        'ExcelC.pCellVal(1, "colspan=10") = Convert.ToString(dr.Item("SNTTOKKI"))
                        'ExcelC.mWriteLine("")   '行をファイルに書き込む

                        '55行目
                        ExcelC.pCellStyle(1) = "border-style:none"
                        ExcelC.pCellVal(1, "colspan=10") = "出動結果内容/報告："
                        ExcelC.mWriteLine("")   '行をファイルに書き込む

                        ''56行目
                        'ExcelC.pCellStyle(1) = "border-style:none;height:36px"
                        'ExcelC.pCellVal(1, "colspan=10") = Convert.ToString(dr.Item("SDTBIK2"))
                        'ExcelC.mWriteLine("")   '行をファイルに書き込む

                        ''57行目
                        'If Convert.ToString(dr.Item("SNTTOKKI")).Trim.Length > 0 Then ' 2010/10/06 T.Watabe edit ﾃﾞｰﾀが無ければ詰める
                        '    ExcelC.pCellStyle(1) = "border-style:none;height:36px"
                        '    ExcelC.pCellVal(1, "colspan=10") = Convert.ToString(dr.Item("SNTTOKKI"))
                        '    ExcelC.mWriteLine("")   '行をファイルに書き込む
                        'End If

                        ''58行目
                        'If Convert.ToString(dr.Item("SDTBIK3")).Trim.Length > 0 Then ' 2010/10/06 T.Watabe edit ﾃﾞｰﾀが無ければ詰める
                        '    ExcelC.pCellStyle(1) = "border-style:none;height:36px"
                        '    ExcelC.pCellVal(1, "colspan=10") = Convert.ToString(dr.Item("SDTBIK3"))
                        '    ExcelC.mWriteLine("")   '行をファイルに書き込む
                        'End If
                        '56行目
                        ExcelC.pCellStyle(1) = "border-style:none"
                        ExcelC.pCellStyle(2) = "border-style:none;height:64px;vertical-align:top"
                        ExcelC.pCellVal(1) = ""
                        ExcelC.pCellVal(2, "colspan=9") = Convert.ToString(dr.Item("SDTBIK2")) & Convert.ToString(dr.Item("SNTTOKKI")) & Convert.ToString(dr.Item("SDTBIK3"))
                        ExcelC.mWriteLine("")   '行をファイルに書き込む
                        '2006/06/14 NEC UPDATE END
                        '--- ↑2005/09/09 MOD Falcon↑ ---

                    Else
                        '--- ↓2005/09/10 DEL Falcon↓ ---
                        '出動会社が出動した内容ではない場合、「出動情報」欄すべて表示しないようにする

                        ''---------- 出動指示ではない場合、データ出力は行わない ---------------------------
                        ''41行目
                        'ExcelC.pCellStyle(1) = "border-style:none"
                        'ExcelC.pCellVal(1, "colspan=10") = "<<出動会社対応内容>>"
                        'ExcelC.mWriteLine("")   '行をファイルに書き込む

                        ''42行目
                        'ExcelC.pCellStyle(1) = "border-style:none"
                        'ExcelC.pCellVal(1, "colspan=10") = "出動委託先（指定保安機関）："
                        'ExcelC.mWriteLine("")   '行をファイルに書き込む

                        ''43行目
                        'ExcelC.pCellStyle(1) = "border-style:none"
                        'ExcelC.pCellVal(1, "colspan=10") = "支所・拠点名："
                        'ExcelC.mWriteLine("")   '行をファイルに書き込む

                        ''44行目
                        'ExcelC.pCellStyle(1) = "border-style:none"
                        'ExcelC.pCellStyle(2) = "border-style:none"
                        'ExcelC.pCellStyle(3) = "border-style:none"
                        'ExcelC.pCellVal(1, "colspan=3") = "対応者："
                        'ExcelC.pCellVal(2, "colspan=3") = "到着時間："
                        'ExcelC.pCellVal(3, "colspan=4") = "措置完了時間："
                        'ExcelC.mWriteLine("")   '行をファイルに書き込む

                        ''45行目
                        'ExcelC.pCellStyle(1) = "border-style:none"
                        'ExcelC.pCellVal(1, "colspan=10") = "対応相手："
                        'ExcelC.mWriteLine("")   '行をファイルに書き込む

                        ''46行目
                        'ExcelC.mWriteLine("")   '行をファイルに書き込む

                        ''47行目
                        'ExcelC.pCellStyle(1) = "border-style:none"
                        'ExcelC.pCellVal(1, "colspan=10") = "【お客様のお話内容】 "
                        'ExcelC.mWriteLine("")   '行をファイルに書き込む

                        ''49行目
                        'ExcelC.mWriteLine("")   '行をファイルに書き込む

                        ''50行目
                        'ExcelC.pCellStyle(1) = "border-style:none"
                        'ExcelC.pCellStyle(2) = "border-style:none"
                        'ExcelC.pCellVal(1, "colspan=5") = "復帰対応："
                        'ExcelC.pCellVal(2, "colspan=5") = "簡易ガス器具の貸与："
                        'ExcelC.mWriteLine("")   '行をファイルに書き込む

                        ''51行目
                        'ExcelC.pCellStyle(1) = "border-style:none"
                        'ExcelC.pCellStyle(2) = "border-style:none"
                        'ExcelC.pCellVal(1, "colspan=5") = "連絡状況　連絡相手："
                        'ExcelC.pCellVal(2, "colspan=5") = "連絡時間："
                        'ExcelC.mWriteLine("")   '行をファイルに書き込む

                        ''52行目
                        'ExcelC.pCellStyle(1) = "border-style:none"
                        'ExcelC.pCellStyle(2) = "border-style:none"
                        'ExcelC.pCellVal(1, "colspan=2") = "ガス漏れ点検："
                        'ExcelC.pCellVal(2, "colspan=8") = "原因："
                        'ExcelC.mWriteLine("")   '行をファイルに書き込む

                        ''53行目
                        'ExcelC.pCellStyle(1) = "border-style:none"
                        'ExcelC.pCellStyle(2) = "border-style:none"
                        'ExcelC.pCellVal(1, "colspan=2") = "ガス切れ点検："
                        'ExcelC.pCellVal(2, "colspan=8") = "ゴムホース交換："
                        'ExcelC.mWriteLine("")   '行をファイルに書き込む

                        ''54行目
                        'ExcelC.pCellStyle(1) = "border-style:none"
                        'ExcelC.pCellStyle(2) = "border-style:none"
                        'ExcelC.pCellStyle(3) = "border-style:none"
                        'ExcelC.pCellStyle(4) = "border-style:none"
                        'ExcelC.pCellStyle(5) = "border-style:none"
                        'ExcelC.pCellVal(1, "colspan=2") = "メータ点検："
                        'ExcelC.pCellVal(2, "colspan=2") = "調整期点検："
                        'ExcelC.pCellVal(3, "colspan=2") = "容器・中間バルブ："
                        'ExcelC.pCellVal(4, "colspan=2") = "吸排気口："
                        'ExcelC.pCellVal(5, "colspan=2") = "ＣＯ濃度："
                        'ExcelC.mWriteLine("")   '行をファイルに書き込む

                        ''55行目
                        'ExcelC.pCellStyle(1) = "border-style:none"
                        'ExcelC.pCellVal(1, "colspan=10") = "特記事項："
                        'ExcelC.mWriteLine("")   '行をファイルに書き込む

                        ''56行目
                        'ExcelC.mWriteLine("")   '行をファイルに書き込む

                        ''57行目
                        'ExcelC.pCellStyle(1) = "border-style:none"
                        'ExcelC.pCellVal(1, "colspan=10") = "ＪＡ／県連様への依頼事項等："
                        'ExcelC.mWriteLine("")   '行をファイルに書き込む

                        ''58行目
                        'ExcelC.pCellStyle(1) = "border-style:none"
                        'ExcelC.pCellVal(1, "colspan=10") = ""
                        'ExcelC.mWriteLine("")   '行をファイルに書き込む
                        '--- ↑2005/09/10 DEL Falcon↑ ---

                    End If

                    '出動対応時のみ出動情報を出力するように修正
                    'If strSTD_CD.Length <> 0 And Convert.ToString(dr.Item("TAIOKBN")) = "2" Then
                    '    '41行目
                    '    ExcelC.pCellStyle(1) = "border-style:none"
                    '    ExcelC.pCellVal(1, "colspan=10") = "<<出動会社対応内容>>"
                    '    ExcelC.mWriteLine("")   '行をファイルに書き込む

                    '    '42行目
                    '    '--- ↓2005/05/23 MOD Falcon↓ ---
                    '    ExcelC.pCellStyle(1) = "border-style:none"
                    '    'ExcelC.pCellVal(1, "colspan=10") = "出動委託先（指定保安機関）：" & Convert.ToString(dr.Item("SYUTDTNM"))
                    '    'ExcelC.pCellVal(1, "colspan=10") = "出動委託先（指定保安機関）：" & Convert.ToString(dr.Item("TSTANNM"))
                    '    ExcelC.pCellVal(1, "colspan=10") = "出動委託先（指定保安機関）：" & Convert.ToString(dr.Item("STD"))
                    '    ExcelC.mWriteLine("")   '行をファイルに書き込む
                    '    '--- ↑2005/05/23 MOD Falcon↑ ---

                    '    '43行目
                    '    ExcelC.pCellStyle(1) = "border-style:none"
                    '    ExcelC.pCellVal(1, "colspan=10") = "支所・拠点名：" & Convert.ToString(dr.Item("STD_KYOTEN"))
                    '    ExcelC.mWriteLine("")   '行をファイルに書き込む

                    '    '44行目
                    '    ExcelC.pCellStyle(1) = "border-style:none"
                    '    ExcelC.pCellStyle(2) = "border-style:none"
                    '    ExcelC.pCellStyle(3) = "border-style:none"
                    '    '--- ↓2005/05/21 MOD Falcon↓ ---
                    '    'ExcelC.pCellVal(1, "colspan=3") = "対応者：" & Convert.ToString(dr.Item("TSTANNM"))
                    '    ExcelC.pCellVal(1, "colspan=3") = "対応者：" & Convert.ToString(dr.Item("SYUTDTNM"))
                    '    '--- ↑2005/05/21 MOD Falcon↑ ---
                    '    ExcelC.pCellVal(2, "colspan=3") = "到着時間：" & fncDateSet(Convert.ToString(dr.Item("TYAKYMD"))) & " " & fncTimeSet(Convert.ToString(dr.Item("TYAKTIME")))
                    '    ExcelC.pCellVal(3, "colspan=4") = "措置完了時間：" & fncDateSet(Convert.ToString(dr.Item("SYOKANYMD"))) & " " & fncTimeSet(Convert.ToString(dr.Item("SYOKANTIME")))
                    '    ExcelC.mWriteLine("")   '行をファイルに書き込む

                    '    '45行目
                    '    ExcelC.pCellStyle(1) = "border-style:none"
                    '    ExcelC.pCellVal(1, "colspan=10") = "対応相手：" & Convert.ToString(dr.Item("AITNM"))
                    '    ExcelC.mWriteLine("")   '行をファイルに書き込む

                    '    '46行目
                    '    ExcelC.mWriteLine("")   '行をファイルに書き込む
                    'End If

                    ''47行目
                    'ExcelC.pCellStyle(1) = "border-style:none"
                    ''''''ExcelC.pCellVal(1, "colspan=10") = "【お客様のお話内容】"
                    'If Convert.ToString(dr.Item("CSNTNGAS")) = "1" Then
                    '    ExcelC.pCellVal(1, "colspan=10") = "【お客様のお話内容】 " & Convert.ToString(dr.Item("SDTBIK1"))
                    'Else
                    '    If Convert.ToString(dr.Item("METFUKKI")) = "1" Then
                    '        ExcelC.pCellVal(1, "colspan=10") = "【お客様のお話内容】 " & "メータ復帰"
                    '    ElseIf Convert.ToString(dr.Item("HOAN")) = "1" Then
                    '        ExcelC.pCellVal(1, "colspan=10") = "【お客様のお話内容】 " & "保安"
                    '    ElseIf Convert.ToString(dr.Item("GASGIRE")) = "1" Then
                    '        ExcelC.pCellVal(1, "colspan=10") = "【お客様のお話内容】 " & "ガス切れ"
                    '    ElseIf Convert.ToString(dr.Item("KIGKOSYO")) = "1" Then
                    '        ExcelC.pCellVal(1, "colspan=10") = "【お客様のお話内容】 " & "器具故障"
                    '    ElseIf Convert.ToString(dr.Item("CSNTGEN")) = "1" Then
                    '        ExcelC.pCellVal(1, "colspan=10") = "【お客様のお話内容】 " & "その他"
                    '    Else
                    '        ExcelC.pCellVal(1, "colspan=10") = "【お客様のお話内容】 " & ""
                    '    End If
                    'End If
                    'ExcelC.mWriteLine("")   '行をファイルに書き込む

                    ''49行目
                    'ExcelC.mWriteLine("")   '行をファイルに書き込む

                    ''50行目
                    'ExcelC.pCellStyle(1) = "border-style:none"
                    'ExcelC.pCellStyle(2) = "border-style:none"
                    'ExcelC.pCellVal(1, "colspan=5") = "復帰対応：" & Convert.ToString(dr.Item("FKINM"))
                    ''--- ↓2005/05/23 MOD Falcon↓ ---
                    'If strSTD_CD.Length = 0 Then
                    '    ExcelC.pCellVal(2, "colspan=5") = "簡易ガス器具の貸与："
                    'Else
                    '    If Convert.ToString(dr.Item("KIGTAIYO")) = "1" Then  '1:有
                    '        ExcelC.pCellVal(2, "colspan=5") = "簡易ガス器具の貸与：" & "有"
                    '    Else
                    '        ExcelC.pCellVal(2, "colspan=5") = "簡易ガス器具の貸与：" & "無"
                    '    End If
                    'End If
                    ''--- ↑2005/05/23 MOD Falcon↑ ---
                    'ExcelC.mWriteLine("")   '行をファイルに書き込む

                    ''51行目
                    'ExcelC.pCellStyle(1) = "border-style:none"
                    'ExcelC.pCellStyle(2) = "border-style:none"
                    'ExcelC.pCellVal(1, "colspan=5") = "連絡状況　連絡相手：" & Convert.ToString(dr.Item("JAKENREN")) & "　様"
                    'ExcelC.pCellVal(2, "colspan=5") = "連絡時間：" & fncTimeSet(Convert.ToString(dr.Item("RENTIME")))
                    'ExcelC.mWriteLine("")   '行をファイルに書き込む

                    ''52行目
                    'ExcelC.pCellStyle(1) = "border-style:none"
                    'ExcelC.pCellStyle(2) = "border-style:none"
                    ''--- ↓2005/05/23 MOD Falcon↓ ---
                    'If strSTD_CD.Length = 0 Then
                    '    ExcelC.pCellVal(1, "colspan=2") = "ガス漏れ点検："
                    '    ExcelC.pCellVal(2, "colspan=8") = "原因："
                    'Else
                    '    If Convert.ToString(dr.Item("GASMUMU")) = "0" Then  ' 0：有　1：無
                    '        ExcelC.pCellVal(1, "colspan=2") = "ガス漏れ点検：" & "有"
                    '    Else
                    '        ExcelC.pCellVal(1, "colspan=2") = "ガス漏れ点検：" & "無"
                    '    End If
                    '    If Convert.ToString(dr.Item("ORGENIN")) = "1" Then  'ガス器具　1:有
                    '        ExcelC.pCellVal(2, "colspan=8") = "原因：" & "ガス器具"
                    '    Else
                    '        ExcelC.pCellVal(2, "colspan=8") = "原因：" & ""
                    '    End If
                    'End If
                    ''--- ↑2005/05/23 MOD Falcon↑ ---
                    'ExcelC.mWriteLine("")   '行をファイルに書き込む

                    ''53行目
                    'ExcelC.pCellStyle(1) = "border-style:none"
                    'ExcelC.pCellStyle(2) = "border-style:none"
                    ''--- ↓2005/05/23 MOD Falcon↓ ---
                    'If strSTD_CD.Length = 0 Then
                    '    ExcelC.pCellVal(1, "colspan=2") = "ガス切れ点検："
                    '    ExcelC.pCellVal(2, "colspan=8") = "ゴムホース交換："
                    'Else
                    '    If Convert.ToString(dr.Item("GASGUMU")) = "0" Then      '0：有　1：無
                    '        ExcelC.pCellVal(1, "colspan=2") = "ガス切れ点検：" & "有"
                    '    Else
                    '        ExcelC.pCellVal(1, "colspan=2") = "ガス切れ点検：" & "無"
                    '    End If
                    '    If Convert.ToString(dr.Item("HOSKOKAN")) = "0" Then     '0：実施　1：未実施
                    '        'ExcelC.pCellVal(2, "colspan=8") = "ゴムホース交換：" & "未実施"    '--- 2005/05/23 DEL Falcon ---
                    '        ExcelC.pCellVal(2, "colspan=8") = "ゴムホース交換：" & "実施"
                    '    Else
                    '        ExcelC.pCellVal(2, "colspan=8") = "ゴムホース交換：" & "未実施"
                    '    End If
                    'End If
                    ''--- ↑2005/05/23 MOD Falcon↑ ---
                    'ExcelC.mWriteLine("")   '行をファイルに書き込む

                    ''54行目
                    'ExcelC.pCellStyle(1) = "border-style:none"
                    'ExcelC.pCellStyle(2) = "border-style:none"
                    'ExcelC.pCellStyle(3) = "border-style:none"
                    'ExcelC.pCellStyle(4) = "border-style:none"
                    'ExcelC.pCellStyle(5) = "border-style:none"
                    ''--- ↓2005/05/23 MOD Falcon↓ ---
                    'If strSTD_CD.Length = 0 Then
                    '    ExcelC.pCellVal(1, "colspan=2") = "メータ点検："
                    '    ExcelC.pCellVal(2, "colspan=2") = "調整期点検："
                    '    ExcelC.pCellVal(3, "colspan=2") = "容器・中間バルブ："
                    '    ExcelC.pCellVal(4, "colspan=2") = "吸排気口："
                    '    ExcelC.pCellVal(5, "colspan=2") = "ＣＯ濃度："
                    'Else
                    '    If Convert.ToString(dr.Item("METYOINA")) = "0" Then      '0：良　1：否
                    '        ExcelC.pCellVal(1, "colspan=2") = "メータ点検：" & "良"
                    '    Else
                    '        ExcelC.pCellVal(1, "colspan=2") = "メータ点検：" & "否"
                    '    End If
                    '    If Convert.ToString(dr.Item("TYOUYOINA")) = "0" Then      '0：良　1：否
                    '        ExcelC.pCellVal(2, "colspan=2") = "調整期点検：" & "良"
                    '    Else
                    '        ExcelC.pCellVal(2, "colspan=2") = "調整期点検：" & "否"
                    '    End If
                    '    If Convert.ToString(dr.Item("VALYOINA")) = "0" Then      '0：良　1：否
                    '        ExcelC.pCellVal(3, "colspan=2") = "容器・中間バルブ：" & "良"
                    '    Else
                    '        ExcelC.pCellVal(3, "colspan=2") = "容器・中間バルブ：" & "否"
                    '    End If
                    '    If Convert.ToString(dr.Item("KYUHAIUMU")) = "0" Then      '0：良　1：否
                    '        ExcelC.pCellVal(4, "colspan=2") = "吸排気口：" & "良"
                    '    Else
                    '        ExcelC.pCellVal(4, "colspan=2") = "吸排気口：" & "否"
                    '    End If
                    '    If Convert.ToString(dr.Item("COYOINA")) = "0" Then      '0：良　1：否
                    '        ExcelC.pCellVal(5, "colspan=2") = "ＣＯ濃度：" & "良"
                    '    Else
                    '        ExcelC.pCellVal(5, "colspan=2") = "ＣＯ濃度：" & "否"
                    '    End If
                    'End If
                    ''--- ↑2005/05/23 MOD Falcon↑ ---
                    'ExcelC.mWriteLine("")   '行をファイルに書き込む

                    ''55行目
                    'ExcelC.pCellStyle(1) = "border-style:none"
                    'ExcelC.pCellVal(1, "colspan=10") = "特記事項：" & Convert.ToString(dr.Item("SDTBIK2"))
                    'ExcelC.mWriteLine("")   '行をファイルに書き込む

                    ''56行目
                    'ExcelC.mWriteLine("")   '行をファイルに書き込む

                    ''57行目
                    'ExcelC.pCellStyle(1) = "border-style:none"
                    'ExcelC.pCellVal(1, "colspan=10") = "ＪＡ／県連様への依頼事項等："
                    'ExcelC.mWriteLine("")   '行をファイルに書き込む

                    ''58行目
                    'ExcelC.pCellStyle(1) = "border-style:none"
                    'ExcelC.pCellVal(1, "colspan=10") = Convert.ToString(dr.Item("SNTTOKKI"))
                    'ExcelC.mWriteLine("")   '行をファイルに書き込む
                    '--- ↑2005/05/31 MOD Falcon↑ ---

                    intRowCount = intRowCount + 1

                    If intRowCount <> ds.Tables(0).Rows.Count Then
                        '改ページ
                        ExcelC.mWriteLine("", True)
                    End If

                Next
            End If

            'ファイルクローズ
            ExcelC.mClose()

            '圧縮先ファイルのあるフォルダ
            compressC.p_Dir = ExcelC.pDirName
            '日本語ファイル名の指定(パラメータ[セッション] + 電話番号)
            If pstrAUTO = "1" Then '1:fax
                'ＦＡＸファイル作成
                'compressC.p_NihongoFileName = pstrSESSION & pstrFAXNO & ".xls" '20050506 edit Falcon
                compressC.p_NihongoFileName = pstrSESSION & pstrAUTO & pstrFAXNO & ".xls"
                '圧縮元ファイル名      (上記作成したEXCELファイル)(LZHに追加する)
                compressC.p_FileName = ExcelC.pDirName & ExcelC.pFileName & ".xls"
            Else
                'メール送信ファイル作成

                ' 2008/12/12 T.Watabe add
                'ZIPに圧縮
                'fncZipTest(ExcelC.pDirName & ExcelC.pFileName & ".xls", ExcelC.pDirName & ExcelC.pFileName & ".zip")
                fncMakeZipWithPass(ExcelC.pDirName & ExcelC.pFileName & ".xls", ExcelC.pDirName & ExcelC.pFileName & ".zip", sZipFilePass)

                'compressC.p_NihongoFileName = pstrSESSION & pstrMAILAD & ".xls" '20050506 edit Falcon
                'compressC.p_NihongoFileName = pstrSESSION & pstrAUTO & pstrMAILAD & ".xls" '2008/12/12 T.Watabe edit
                'compressC.p_NihongoFileName = pstrSESSION & pstrAUTO & pstrMAILAD & ".xls.zip" '2011/03/10 T.Watabe edit
                compressC.p_NihongoFileName = pstrSESSION & pstrAUTO & "(" & cliCd4FileHead & ")" & pstrMAILAD & ".xls.zip"

                '圧縮元ファイル名      (上記作成したEXCELファイルをこの名前でLZHに追加する)
                compressC.p_FileName = ExcelC.pDirName & ExcelC.pFileName & ".zip"
            End If

            '圧縮先ファイル名      (パラメータ[セッション])※２回目以降の時は追加される
            compressC.p_madeFilename = ExcelC.pDirName & pstrSESSION & ".lzh"
            '解凍先のパスを指定
            If pstrFlg = "1" Then
                compressC.p_ToDir = pstrCreateFilePath & "\"
            End If
            '解凍後自動実行無し
            compressC.p_Exec = False
            '圧縮実行
            compressC.mCompress()

            fncFileKill(ExcelC.pDirName & ExcelC.pFileName & ".xls") 'エクセルファイル削除！
            fncFileKill(ExcelC.pDirName & ExcelC.pFileName & ".zip") 'zipファイル削除！

            '圧縮したファイルをBase64エンコードして戻す
            Return FileToStrC.mFileToStr(compressC.p_madeFilename.Replace(".lzh", ".exe"))
        Catch ex As Exception
            'エラーの内容とＳＱＬ文を返す
            Return "ERROR:" & ex.ToString

        Finally

        End Try
    End Function

    '****************************************************************
    'YYYYMMDD → YYYY年MM月DD日
    '****************************************************************
    Private Function fncEdit_Date(ByVal strDate As String) As String
        If strDate.Length = 8 Then
            Return strDate.Substring(0, 4) & "年" & strDate.Substring(4, 2) & "月" & strDate.Substring(6, 2) & "日"
        Else
            Return ""
        End If
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
    'HHMISS → HH時MI分
    '****************************************************************
    Private Function fncEdit_Time(ByVal strTime As String) As String
        If strTime.Length = 4 Then
            Return strTime.Substring(0, 2) & "時" & strTime.Substring(2, 2) & "分"
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

    '************************************************
    '指定された日数加算します
    '************************************************
    Private Function fncAdd_Date(ByVal pstrDate As String, ByVal pintDate As Integer) As String
        Dim strRec As String
        Try
            strRec = Format(DateSerial(CInt(pstrDate.Substring(0, 4)), CInt(pstrDate.Substring(4, 2)), CInt(pstrDate.Substring(6, 2)) + pintDate), "yyyyMMdd")
        Catch ex As Exception
            strRec = ""
        End Try
        Return strRec
    End Function

    '******************************************************************************
    '*　概　要：文字列バイト指定文字取得
    '*　備　考：
    '******************************************************************************
    Private Function MidB(ByVal pstrText As String, ByVal pintSt As Integer, ByVal pintLenb As Integer) As String
        Dim i As Integer
        Dim intCd As Integer
        Dim intBt As Integer
        Dim strTmp As String
        Dim strRec As String
        strRec = ""
        If pintSt < 1 Or pintLenb < 1 Then Return strRec
        For i = 1 To Len(pstrText)
            If intBt + 1 >= pintSt Then Exit For
            strTmp = Mid(pstrText, i, 1)
            intBt = intBt + LenB(strTmp)
        Next
        If i > Len(pstrText) Then Return strRec
        intBt = 0
        For i = i To Len(pstrText)
            strTmp = Mid(pstrText, i, 1)
            intBt = intBt + LenB(strTmp)
            If intBt > pintLenb Then Exit For
            strRec = strRec + strTmp
        Next
        Return strRec
    End Function

    '******************************************************************************
    '*　概　要：文字列バイト取得
    '*　備　考：
    '******************************************************************************
    Private Function LenB(ByVal pstrString As String) As Integer
        Return System.Text.Encoding.GetEncoding(932).GetByteCount(pstrString)

    End Function

    '******************************************************************************
    '*　概　要：ファイルの圧縮(zip) vjslib.dll使用(.Netフレームワーク J#)(要参照設定)
    '*　備　考：
    '******************************************************************************
    'Private Sub fncZipTest(ByVal sXlsFilePath As String, ByVal sZipFilePath As String)
    '    Dim outStream As New java.util.zip.ZipOutputStream(New java.io.FileOutputStream(sZipFilePath))
    '    putFileToZip(outStream, sXlsFilePath)
    '    outStream.close()
    'End Sub
    'Private Sub putFileToZip(ByVal outStream As java.util.zip.ZipOutputStream, ByVal Path As String)
    '    Dim size As Integer = CInt(FileLen(Path))
    '    Dim inStream As New java.io.BufferedInputStream(New java.io.FileInputStream(Path))
    '    Dim crc As New java.util.zip.CRC32
    '    Dim buf(size - 1) As SByte
    '    If inStream.read(buf, 0, size) <> -1 Then
    '        crc.update(buf, 0, size)
    '        outStream.write(buf, 0, size)
    '    End If
    '    Dim entry As New java.util.zip.ZipEntry(System.IO.Path.GetFileName(Path))
    '    entry.setMethod(java.util.zip.ZipEntry.DEFLATED)
    '    entry.setSize(size)
    '    entry.setCrc(crc.getValue())
    '    outStream.putNextEntry(entry)
    '    inStream.close()
    '    outStream.closeEntry()
    '    outStream.flush()
    'End Sub

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

    '2008/12/15 T.Watabe add
    Function fncFileKill(ByVal sFilePath As String) As Boolean
        Dim bErr As Boolean
        bErr = False
        Try
            Kill(sFilePath)
        Catch ex As Exception
            bErr = True
        End Try
        Return bErr
    End Function



    '*****************************************************************
    '*　概　要：バッチ実行ログを取得
    '*****************************************************************
    <WebMethod()> Public Function dispBatchLog(ByRef batchLog As String) As Boolean

        Dim ds As New DataSet
        Dim cdb As New cdb
        Dim dr As DataRow

        batchLog = ""

        'batchLog = "test"
        'Return True
        'Exit Function

        '---------------------------------------------
        '接続文字列の設定
        '---------------------------------------------
        'cdb.pJPUID = ConfigurationSettings.AppSettings("DB_USER_ID")
        'cdb.pJPPWD = ConfigurationSettings.AppSettings("DB_PASSWORD")
        'cdb.pJPDB = ConfigurationSettings.AppSettings("DB_SID")

        '---------------------------------------------
        'プールの最小値設定
        '---------------------------------------------
        cdb.pConnectPoolSize = 1

        '接続OPEN----------------------------------------
        Try
            cdb.mOpen()
        Catch ex As Exception
            Return False
        Finally

        End Try

        Try
            'トランザクション開始
            cdb.mBeginTrans()

            '対応ＤＢ　D20_TAIOU
            Dim sql As New StringBuilder
            sql.Append("SELECT ")
            sql.Append("    TO_CHAR(TO_DATE(ST_YMD || ST_TIME,'YYYYMMDDHH24MISS'), 'YYYY/MM/DD HH24:MI') AS ST, ")
            sql.Append("    LPAD(TRUNC(EXEC_SEC / 1000,0), 5, ' ') || '秒' AS MIN, ")
            sql.Append("    SUBSTRB(MSG, 1,80) AS MSG ")
            sql.Append("FROM S02_BACHDB  ")
            sql.Append("WHERE PROC_ID = 'BTFAXJAE00' ")
            sql.Append("ORDER BY ST_YMD || ST_TIME DESC ")
            cdb.pSQL = sql.ToString
            cdb.mExecQuery() 'SQL実行！

            '結果をデータセットに格納
            ds = cdb.pResult

            'データが存在しない場合
            If ds.Tables(0).Rows.Count = 0 Then

                batchLog = "0件"
            Else
                Dim i As Integer = 0
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    If i >= 50 Then Exit For '50件まで

                    dr = ds.Tables(0).Rows(i)
                    'arrBatchLog.Add(Convert.ToString(dr.Item("ST")) & Convert.ToString(dr.Item("MIN")) & " " & Convert.ToString(dr.Item("MSG")))
                    If batchLog.Length > 0 Then batchLog = batchLog & "$$" '$$は関数から取得した改行付き文字列の改行がうまくされない為。
                    batchLog = batchLog & Convert.ToString(dr.Item("ST")) & Convert.ToString(dr.Item("MIN")) & " " & Convert.ToString(dr.Item("MSG"))
                Next
            End If

        Catch ex As Exception
            batchLog = ex.ToString
            Return False
        Finally
            '接続クローズ
            cdb.mClose()
        End Try
        cdb = Nothing

        Return True

    End Function

    ' 2010/09/15 T.Watabe add
    '*****************************************************************
    '*　概　要：DB SIDを戻す
    '*****************************************************************
    <WebMethod()> Public Function getDBSID() As String
        Dim res As String = ""
        Try
            res = ConfigurationSettings.AppSettings("JPDB")
        Catch ex As Exception
            res = "JPDB 参照エラー:" & ex.ToString
        End Try
        Return res
    End Function

End Class
