'***********************************************
'
'***********************************************
'<TODO>宣言共通仕様
Option Explicit On
Option Strict On

'<TODO>宣言共通仕様
Imports Common
Imports JPG.Common
Imports JPG.Common.log

Imports System.Text

Partial Class SYHANJKG00
    Inherits System.Web.UI.Page

    '<TODO>宣言共通仕様
    '******************************************************************************
    ' HttpHeader
    '******************************************************************************
    Protected HttpHeaderC As New CHttpHeader

    '<TODO>宣言共通仕様
    '******************************************************************************
    '認証クラス
    '******************************************************************************
    Protected AuthC As CAuthenticate

    '<TODO>宣言共通仕様
    '******************************************************************************
    ' ScriptMessage
    '******************************************************************************
    Private strMsg As New StringBuilder("")

    '<TODO>宣言共通仕様
    '******************************************************************************
    ' Render
    '******************************************************************************
    Protected Overrides Sub Render(ByVal writer As HtmlTextWriter)
        MyBase.Render(writer)

        Dim strWrite As New StringBuilder("")

        strWrite.Append("<script language='JavaScript'>")
        strWrite.Append(strMsg.ToString())
        strWrite.Append("</script>")
        writer.Write(strWrite.ToString())
    End Sub

#Region " Web フォーム デザイナで生成されたコード "

    'この呼び出しは Web フォーム デザイナで必要です。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    'メモ : 次のプレースホルダ宣言は Web フォーム デザイナで必要です。
    '削除および移動しないでください。
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        ' CODEGEN: このメソッド呼び出しは Web フォーム デザイナで必要です。
        ' コード エディタを使って変更しないでください。
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '//------------------------------------------
        '//　HTTPヘッダを送信
        HttpHeaderC.mNoCache(Response)

        '//------------------------------------------
        '//　認証クラスのインスタンス生成
        AuthC = New CAuthenticate(Request, Response)

        '//-----------------------------------------
        Dim SYHANJAG00C As SYHANJAG00
        SYHANJAG00C = CType(Context.Handler, SYHANJAG00)

        '//------------------------------------------LAST_DAY(
        '//　販売管理情報を取得する
        Dim SQLC As New SYHANJAG00CSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet

        strSQL.Append("SELECT ")
        strSQL.Append("NAME AS ZTRG, ")                                                     '前回対象年月
        '--- ↓2005/05/13 MOD Falcon↓ ---
        strSQL.Append("TO_CHAR(ADD_MONTHS(TO_DATE(NAME||'01'),1),'YYYYMM') AS KTRG, ")      '今回対象年月
        '--- ↑2005/05/13 MOD Falcon↑ ---
        '--- ↓2005/05/13 DEL Falcon↓ ---
        'strSQL.Append("TO_CHAR(TO_DATE(NAIYO2)+1,'YYYYMM') AS KTRG, ")                      '今回対象年月
        '--- ↑2005/05/13 DEL Falcon↑ ---
        strSQL.Append("NAIYO1 AS ZSYF, ")                                                   '前回集計期間開始
        strSQL.Append("NAIYO2 AS ZSYT, ")                                                   '前回集計期間終了
        strSQL.Append("TO_CHAR(TO_DATE(NAIYO2)+1,'YYYYMMDD') AS KSYF ")                     '今回集計期間開始
        'strSQL.Append("TO_CHAR(TO_DATE(NAIYO2)+1,'YYYYMMDD') AS KSYF, ")                    '今回集計期間開始
        'strSQL.Append("TO_CHAR(LAST_DAY(TO_DATE(NAIYO2)+1),'YYYYMMDD') AS KSYT ")           '今回集計期間終了
        strSQL.Append("FROM M06_PULLDOWN ")
        strSQL.Append("WHERE KBN =:KBN ")
        strSQL.Append("  AND CD =:KENCD ")

        'パラメータのセット
        SqlParamC.fncSetParam("KBN", True, "56")
        SqlParamC.fncSetParam("KENCD", True, SYHANJAG00C.pKENCD)

        dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

        If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
            '前回処理対象年月
            strMsg.Append("parent.Data.Form1.hdnTAISYO.value='" & "" & "';")
            '今回処理対象年月
            strMsg.Append("parent.Data.Form1.hdnTAISYOP1.value='" & fncZenMonth_Last(Now.ToString("yyyyMMdd")).Substring(0, 6) & "';")
            '前回集計期間開始
            strMsg.Append("parent.Data.Form1.hdnSYUKEIF.value='" & "" & "';")
            '前回集計期間終了
            strMsg.Append("parent.Data.Form1.hdnSYUKEIT.value='" & "" & "';")
            '今回集計期間開始
            strMsg.Append("parent.Data.Form1.hdnSYUKEIFP1.value='" & fncZenMonth_Last(Now.ToString("yyyyMMdd")).Substring(0, 6) & "01" & "';")
            '今回集計期間終了
            strMsg.Append("parent.Data.Form1.hdnSYUKEITP1.value='" & fncZenMonth_Last(Now.ToString("yyyyMMdd")) & "';")
        Else
            '前回処理対象年月
            strMsg.Append("parent.Data.Form1.hdnTAISYO.value='" & Convert.ToString(dbData.Tables(0).Rows(0).Item("ZTRG")) & "';")
            '今回処理対象年月
            strMsg.Append("parent.Data.Form1.hdnTAISYOP1.value='" & Convert.ToString(dbData.Tables(0).Rows(0).Item("KTRG")) & "';")
            '前回集計期間開始
            strMsg.Append("parent.Data.Form1.hdnSYUKEIF.value='" & Convert.ToString(dbData.Tables(0).Rows(0).Item("ZSYF")) & "';")
            '前回集計期間終了
            strMsg.Append("parent.Data.Form1.hdnSYUKEIT.value='" & Convert.ToString(dbData.Tables(0).Rows(0).Item("ZSYT")) & "';")
            '今回集計期間開始
            strMsg.Append("parent.Data.Form1.hdnSYUKEIFP1.value='" & Convert.ToString(dbData.Tables(0).Rows(0).Item("KSYF")) & "';")
            '今回集計期間終了
            'strMsg.Append("parent.Data.Form1.hdnSYUKEITP1.value='" & Convert.ToString(dbData.Tables(0).Rows(0).Item("KSYT")) & "';")
            strMsg.Append("parent.Data.Form1.hdnSYUKEITP1.value='';")
        End If
        '画面制御ファンクション実行
        strMsg.Append("parent.Data.fncKbnChange();")

        '--- ↓2005/05/16 ADD Falcon↓ ---
        strMsg.Append("parent.Data.Form1.btnJikkou.disabled=false;")
        '--- ↑2005/05/16 ADD Falcon↑ ---

        '-------------------------------------------------
        '//
        strMsg.Append("location.replace('about:blank');")   '受信フレーム内をブランクページに。

    End Sub

    '************************************************
    '前月月末を返す
    '************************************************
    Private Function fncZenMonth_Last(ByVal pstrDate As String) As String
        Dim strRec As String
        Try
            strRec = Format(DateSerial(CInt(pstrDate.Substring(0, 4)), CInt(pstrDate.Substring(4, 2)), 1 - 1), "yyyyMMdd")
        Catch ex As Exception
            strRec = ""
        End Try
        Return strRec
    End Function

End Class
