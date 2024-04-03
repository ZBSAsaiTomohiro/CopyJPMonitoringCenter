'***********************************************
'欠損データ一覧  一覧画面
'***********************************************
Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common
Imports System.Text

Partial Class KEKEKJFG00
    Inherits System.Web.UI.Page
    Protected WithEvents dbKeson As System.Data.DataSet

    Protected KEKESJAG00_C As KEKESJAG00
    Protected ConstC As New CConst

    '******************************************************************************
    ' HttpHeader
    '******************************************************************************
    Protected HttpHeaderC As New CHttpHeader

    '******************************************************************************
    ' ScriptMessage
    '******************************************************************************
    Private strMsg As New StringBuilder("")      '//<script>は必要なし

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
        Me.dbKeson = New System.Data.DataSet
        CType(Me.dbKeson, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'dbKeson
        '
        Me.dbKeson.DataSetName = "NewDataSet"
        Me.dbKeson.Locale = New System.Globalization.CultureInfo("ja-JP")
        CType(Me.dbKeson, System.ComponentModel.ISupportInitialize).EndInit()

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

    '******************************************************************************
    '*　Page_Load
    '******************************************************************************
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                                                                    Handles MyBase.Load
        '//------------------------------------------
        '//　HTTPヘッダを送信
        HttpHeaderC.mNoCache(Response)

        '//------------------------------------------
        '// Script書込み用変数宣言
        Dim strScript As New StringBuilder("")
        Dim cscript1 As New CScript
        Dim strScriptPath As String
        strScriptPath = ConfigurationSettings.AppSettings("SCRIPTPATH")
        '//------------------------------------------
        '//　JavaScript格納
        strScript.Append("<Script language=javascript>")
        '＜一覧スクリプト＞
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncBG.js"))
        strScript.Append("</Script>")
        '//------------------------------------------
        '//　Css格納
        strScript.Append("<Style>")
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "CssIframe.css"))
        strScript.Append("</Style>")
        '//------------------------------------------
        '//　Script書込み
        lblScript.Text = strScript.ToString

        '********************************************
        '//------------------------------------------
        '<TODO>呼び出し元クラスのインスタンス作成
        KEKESJAG00_C = CType(Context.Handler, KEKESJAG00)
        '//------------------------------------------
        '********************************************

        '********************************************
        '//------------------------------------------
        Dim intRow As Integer
        '// Select文の作成
        Dim SQLC As New KEKESJAG00CCSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder

        'MAX99の制御--------------------------------------
        '検索条件は存在しないため、全て出力します。ロジックは残します
        '//------------------------------------------
        '//MAX件数チェック
        Dim dbData As DataSet
        strSQL = New StringBuilder("")
        Call mMakeSQL(strSQL, SqlParamC, 1)
        dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)
        If Convert.ToInt32(dbData.Tables(0).Rows(0).Item("CNT")) > ConstC.pScrollMax Then
            strMsg.Append("alert('最大出力件数を超えました。" & ConstC.pScrollMax & "件まで出力します');")
        End If
        'MAX99の制御--------------------------------------

        '編集TEMP用
        Dim intTemp As Integer
        Dim strTemp1 As String
        Dim strTemp2 As String
        '// データの取得
        strSQL = New StringBuilder("")
        Call mMakeSQL(strSQL, SqlParamC, 0)
        dbKeson = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

        '// 取得データの編集を行う--------------------
        Dim DateFncC As New CDateFnc
        Dim TimeFncC As New CTimeFnc

        'イベントボタンのロック処理
        strMsg.Append("parent.Form1.btnExit.disabled=false;")
        If Convert.ToString(dbKeson.Tables(0).Rows(0).Item(0)) = "XYZ" Then
            '//------------------------------------------
            '<TODO>データが存在しない場合に出力する値を各フィールドに設定する
            dbKeson.Tables(0).Rows(0).Item("ROWNO") = "0"       'SPANキー
            dbKeson.Tables(0).Rows(0).Item("KEY") = ""          'SPANキー
            dbKeson.Tables(0).Rows(0).Item("FTPFILE") = ""      'SPANカラー
            dbKeson.Tables(0).Rows(0).Item("STATE") = ""
            dbKeson.Tables(0).Rows(0).Item("JOUKYOU") = ""
            dbKeson.Tables(0).Rows(0).Item("UPDDATE") = ""
            dbKeson.Tables(0).Rows(0).Item("UPDTIME") = ""

            strMsg.Append("parent.Form1.btnExit.focus();")
            strMsg.Append("parent.fncFo(parent.Form1.btnDelete, 5);")
            strMsg.Append("parent.Form1.btnDelete.disabled = true;")
            strMsg.Append("Form1.chkDel0.disabled = true;")

            hdnDataCnt.Value = "0"
        Else
            intTemp = 0
            strMsg.Append("parent.Form1.btnDelete.disabled = false;")
            For intRow = 0 To dbKeson.Tables(0).Rows.Count - 1
                intTemp += 1
                '//---------------------------------------
                '//最終更新時刻の編集
                strTemp1 = Convert.ToString(dbKeson.Tables(0).Rows(intRow).Item("UPDDATE"))
                strTemp2 = strTemp1
                strTemp1 = strTemp1.Substring(0, 8)
                strTemp2 = strTemp2.Substring(8, 6)
                If IsNumeric(strTemp1) = True Then
                    strTemp1 = DateFncC.mGet(strTemp1)
                End If
                If IsNumeric(strTemp2) = True Then
                    strTemp2 = TimeFncC.mGet(strTemp2, 1)
                End If
                dbKeson.Tables(0).Rows(intRow).Item("UPDDATE") = strTemp1 & " " & strTemp2
                '//---------------------------------------
            Next
            hdnDataCnt.Value = CStr(intTemp)
        End If
        '// リピータにバインドする--------------------
        rptKesonData.DataBind()
        '//------------------------------------------
        '********************************************
    End Sub
    '******************************************************************************
    ' SQL作成
    '******************************************************************************
    '//------------------------------------------
    '<TODO>SELECT文の作成＆SQLパラメータのバインド
    Private Sub mMakeSQL(ByVal pstrSQL As StringBuilder, ByVal pSqlParamC As CSQLParam, ByVal pintkbn As Integer)

        pstrSQL.Append("SELECT ")
        If pintkbn = 0 Then
            '//一覧用の項目を取得します
            pstrSQL.Append("TO_CHAR(ROWNUM) AS ROWNO, ")
            pstrSQL.Append("FILE_NAME AS KEY, ")
            pstrSQL.Append("FILE_NAME AS FTPFILE, ")
            pstrSQL.Append("FILE_STATUS AS STATE, ")
            pstrSQL.Append("FILE_WAIT_MODE AS JOUKYOU, ")
            pstrSQL.Append("LAST_MODIFIED AS UPDDATE, ")
            pstrSQL.Append("'' AS UPDTIME ")
        Else
            '//件数カウント用のSQL
            pstrSQL.Append("COUNT(*) AS CNT ")       'カウント
        End If
        pstrSQL.Append("FROM ")
        pstrSQL.Append("T11_KEIHOFILE ")
        pstrSQL.Append("WHERE FILE_STATUS IN (1,2) ")

        'MAX99の制御--------------------------------------
        '検索条件は存在しないため、全て出力します。ロジックは残します
        If pintkbn = 0 Then
            pstrSQL.Append(" AND  ROWNUM <= " & ConstC.pScrollMax)
        End If
        'MAX99の制御--------------------------------------

        pstrSQL.Append("ORDER BY FILE_NAME ")


    End Sub


End Class
