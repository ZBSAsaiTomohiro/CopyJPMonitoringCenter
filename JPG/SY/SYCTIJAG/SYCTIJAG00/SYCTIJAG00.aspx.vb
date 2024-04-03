'***********************************************
'ＣＴＩ画面遷移機能
'***********************************************
Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common
Imports JPG.Common.log

Imports System.Text

Partial Class SYCTIJAG00
    Inherits System.Web.UI.Page

    Public gstrCLI_CD As String
    Public gstrHAN_CD As String
    Public gstrUSER_CD As String
    Public gstrCTITELNO As String
    Public gstrKENFLG As String

    '<TODO>宣言共通仕様
    '******************************************************************************
    ' HttpHeader
    '******************************************************************************
    Protected HttpHeaderC As New CHttpHeader

    '<TODO>宣言共通仕様
    '******************************************************************************
    ' 認証クラス
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

        Dim strRec As String
        Dim strTRANSFER As String

        '//------------------------------------------
        If IsNothing(Request.QueryString("CTINO")) = True Then
            '顧客検索画面に検索条件なしで遷移する
            '検索前の状態で遷移
            gstrCTITELNO = ""
            gstrKENFLG = "0"            '//検索前状態で顧客検索画面を出力
            strTRANSFER = "MSKOSJAG00"

            strRec = "クエリーストリングが設定されていません"
        ElseIf Convert.ToString(Request.QueryString("CTINO")).Length > 0 Then
            'データが１件のみの場合は、そのキーを保持しつつ対応入力画面に遷移する
            'データが複数、もしくは存在しない場合は、取得した電話番号を条件にした検索後状態で
            '顧客検索画面に遷移する

            gstrCTITELNO = Convert.ToString(Request.QueryString("CTINO"))

            Dim intCnt As Integer
            'データを検索し、データを出力します
            intCnt = fncDataSelect()

            If intCnt = 1 Then
                gstrKENFLG = ""         '//対応入力画面を出力
                strTRANSFER = "KETAIJAG00"

                strRec = "一致した電話番号で対応入力画面を出力します"
            Else
                gstrKENFLG = "1"        '//検索後状態で顧客検索画面を出力
                strTRANSFER = "MSKOSJAG00"

                strRec = "複数件抽出したので、顧客検索画面を出力します"
            End If
        Else
            '顧客検索画面に検索条件なしで遷移する
            '検索前の状態で遷移
            gstrCTITELNO = ""
            gstrKENFLG = "0"            '//検索前状態で顧客検索画面を出力
            strTRANSFER = "MSKOSJAG00"

            strRec = "電話番号が設定されていません"
        End If

        '-------------------------------------------------
        '//ＡＰログ書き込み
        Dim LogC As New CLog
        Dim strRecLog As String
        '2012/04/04 NEC ou Upd
        'strRecLog = LogC.mAPLog(Request.Cookies.Get("ASP.NET_SessionId").Value, AuthC.pUSERNAME, AuthC.pIPADDRESS, "SYCTIJAG00", "4", strRec, Request.Form)
        strRecLog = LogC.mAPLog(Me.Session.SessionID, AuthC.pUSERNAME, AuthC.pIPADDRESS, "SYCTIJAG00", "4", strRec, Request.Form)
        '2012/04/04 NEC ou Upd
        If strRecLog <> "OK" Then
            Dim errmsgc As New CErrMsg
            strMsg.Append("alert('システムエラー：" & errmsgc.mGetArtMsg(strRecLog) & "');")
        End If


        '画面遷移を行う
        Server.Transfer("../../../" & strTRANSFER.Substring(0, 2) & "/" & strTRANSFER.Substring(0, 8) & "/" & strTRANSFER & "/" & strTRANSFER & ".aspx")

    End Sub

    '******************************************************************************
    '* CTIからの電話番号で検索し、件数を返す
    '******************************************************************************
    Private Function fncDataSelect() As Integer
        Dim intRec As Integer
        '//------------------------------------------
        Dim SQLC As New SYCTIJAG00CCSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet

        strSQL.Append("SELECT ")
        strSQL.Append("CLI_CD, ")
        strSQL.Append("HAN_CD, ")
        strSQL.Append("USER_CD ")
        strSQL.Append("FROM SHAMAS ")
        'strSQL.Append("WHERE KANKENSAKU_TEL = :KANKENSAKU_TEL ") '2016/2/2 H.Mori mod 監視改善2015
        strSQL.Append("WHERE REPLACE(REPLACE(KANKENSAKU_TEL,'-',''), ' ','') = :KANKENSAKU_TEL ") '2016/2/5 H.Mori add 監視改善2015
        strSQL.Append("OR    REPLACE(REPLACE(RENTEL2,'-',''), ' ','') = :KANKENSAKU_TEL ") '2016/2/5 H.Mori add 監視改善2015
        strSQL.Append("OR    REPLACE(REPLACE(RENTEL3,'-',''), ' ','') = :KANKENSAKU_TEL ") '2016/2/5 H.Mori add 監視改善2015 
        '2017/04/24 H.Mori add 維持管理 CTIの検索条件と参照項目を一致させる START
        strSQL.Append("OR    REPLACE(REPLACE(TELA || TELB,'-',''), ' ', '') = :KANKENSAKU_TEL ")
        strSQL.Append("OR    REPLACE(REPLACE(DAI3RENDORENTEL,'-',''), ' ', '') = :KANKENSAKU_TEL ")
        '2017/04/24 H.Mori add 維持管理 CTIの検索条件と参照項目を一致させる END

        SqlParamC.fncSetParam("KANKENSAKU_TEL", True, gstrCTITELNO)

        dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

        If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
            'データなしでリターン
            gstrCLI_CD = ""
            gstrHAN_CD = ""
            gstrUSER_CD = ""
            intRec = 0
        Else
            If dbData.Tables(0).Rows.Count = 1 Then
                'キー一致が複数あり
                gstrCLI_CD = Convert.ToString(dbData.Tables(0).Rows(0).Item("CLI_CD"))
                gstrHAN_CD = Convert.ToString(dbData.Tables(0).Rows(0).Item("HAN_CD"))
                gstrUSER_CD = Convert.ToString(dbData.Tables(0).Rows(0).Item("USER_CD"))
            Else
                'データが複数あり
                gstrCLI_CD = ""
                gstrHAN_CD = ""
                gstrUSER_CD = ""
            End If
            intRec = dbData.Tables(0).Rows.Count
        End If

        Return intRec
    End Function
End Class
