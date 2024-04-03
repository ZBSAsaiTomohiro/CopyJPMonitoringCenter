'***********************************************
'プルダウン設定マスタ一覧  メイン画面
'***********************************************
Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common
Imports JPG.Common.log

Imports System.Text

Partial Class MSPUFJAG00
    Inherits System.Web.UI.Page

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

    '******************************************************************************
    ' Page_Load
    '******************************************************************************
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                                                                    Handles MyBase.Load
        '//------------------------------------------
        '//　HTTPヘッダを送信
        HttpHeaderC.mNoCache(Response)

        '//------------------------------------------
        '//　認証クラスのインスタンス生成
        AuthC = New CAuthenticate(Request, Response)

        '//------------------------------------------
        '// Script書込み用変数宣言
        Dim strScript As New StringBuilder("")
        Dim cscript1 As New CScript
        Dim strScriptPath As String
        strScriptPath = ConfigurationSettings.AppSettings("SCRIPTPATH")


        '------------------------------------------------------------------------------
        '<TODO>HTML内に必要なJavaScript/CSSはここで[strScript]変数に格納後
        '      画面上[lblScript]に書き込みを行います(SPANタグとしてクライアントにスクリプトが
        '      出力されます。)
        '//------------------------------------------
        '//　JavaScript格納
        strScript.Append("<Script language=javascript>")
        '<独自スクリプト>
        strScript.Append(cscript1.mWriteScript( _
             MyBase.MapPath("../../../MS/MSPUFJAG/MSPUFJAG00/") & "MSPUFJAG00.js"))
        '<フォーカス関連関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncFo.js"))
        strScript.Append("</Script>")
        '//------------------------------------------
        '//　Css格納
        strScript.Append("<Style>")
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "CssList.css"))
        strScript.Append("</Style>")
        '//------------------------------------------
        '//　Script書込み
        lblScript.Text = strScript.ToString

        '//------------------------------------------
        If MyBase.IsPostBack = False Then
            '//--------------------------------------
            '//初めて開いた時だけ実行される
        Else
            '//--------------------------------------
            '//２回目以降実行される
            '//--------------------------------------
        End If

        '//-------------------------------------------------
        '<TODO>自分の画面IDをHIDDENのhdnMyAspxに書き込む（システム共通）
        hdnMyAspx.Value = "MSPUFJAG00"
        '//-------------------------------------------------

        Dim strRec As String
        Try
            '********************************************
            '//------------------------------------------
            '// Select文の作成
            Dim SQLC As New MSPUFJAG00CCSQL.CSQL
            Dim SqlParamC As New CSQLParam
            Dim strSQL As New StringBuilder
            Dim ds As New DataSet
            Dim strHtml As New StringBuilder

            '// データの取得
            strSQL = New StringBuilder("")
            Call fncMakeSQL(strSQL, SqlParamC)
            ds = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

            '//------------------------------------------
            '<TODO>データ編集を行う場合、LOOPにてデータを再セットする
            Dim intRow As Integer
            Dim strTemp As String
            Dim strKbn As String

            strHtml.Append("<table cellspacing=""0"" cellpadding=""1"" widht=""980px"">")
            strHtml.Append("	<tr>")
            strHtml.Append("		<td width=""50px"" height=""0px""></td>")
            strHtml.Append("		<td width=""190px""></td>")
            strHtml.Append("		<td width=""330px""></td>")
            strHtml.Append("		<td width=""330px""></td>")
            strHtml.Append("		<td width=""60px""></td>")
            strHtml.Append("		<td width=""50px""></td>")
            strHtml.Append("		<td width=""50px""></td>")
            strHtml.Append("	</tr>")

            If Convert.ToString(ds.Tables(0).Rows(0).Item(0)) = "XYZ" Then
                '//------------------------------------------
                '<TODO>データが存在しない場合、空の明細行を出力する

                'ヘッダー行を出力
                strHtml.Append("	<tr>")
                strHtml.Append("		<td>&nbsp;</td>")
                strHtml.Append("	</tr>")
                strHtml.Append("	<tr>")
                strHtml.Append("		<td colspan=""7"" class=""COMMT"">区分：</td>")
                strHtml.Append("	</tr>")
                strHtml.Append("	<tr>")
                strHtml.Append("		<td align=""center"" class=""TITL"">コード</td>")
                strHtml.Append("		<td align=""center"" class=""TITL"">名称</td>")
                strHtml.Append("		<td align=""center"" class=""TITL"">内容１</td>")
                strHtml.Append("		<td align=""center"" class=""TITL"">内容２</td>")
                strHtml.Append("		<td align=""center"" class=""TITL"">表示順序</td>")
                strHtml.Append("		<td align=""center"" class=""TITL"">登録日</td>")
                strHtml.Append("		<td align=""center"" class=""TITR"">更新日</td>")
                strHtml.Append("	</tr>")

                '明細行を出力（空）
                strHtml.Append("	<tr>")
                strHtml.Append("		<td class=""OTHR""></td>")
                strHtml.Append("		<td class=""OTHR""></td>")
                strHtml.Append("		<td class=""OTHR""></td>")
                strHtml.Append("		<td class=""OTHR""></td>")
                strHtml.Append("		<td class=""OTHR""></td>")
                strHtml.Append("		<td class=""OTHR""></td>")
                strHtml.Append("		<td class=""OTHR""></td>")
                strHtml.Append("	</tr>")
            Else
                For intRow = 0 To ds.Tables(0).Rows.Count - 1

                    If strKbn <> Convert.ToString(ds.Tables(0).Rows(intRow).Item("KBN")) Then
                        'ヘッダー行を出力
                        strHtml.Append("	<tr>")
                        '最初のループ以外
                        If intRow <> 0 Then
                            strHtml.Append("		<td class=""BREAK"">&nbsp;</td>")
                        Else
                            strHtml.Append("        <td>&nbsp;</td>")
                        End If
                        strHtml.Append("	</tr>")
                        strHtml.Append("	<tr>")
                        strHtml.Append("		<td colspan=""7"" class=""COMMT"">区分：　　" & _
                                            Convert.ToString(ds.Tables(0).Rows(intRow).Item("KBN")) & "　" & _
                                            Convert.ToString(ds.Tables(0).Rows(intRow).Item("KBNNM")) & "</td>")
                        strHtml.Append("	</tr>")
                        strHtml.Append("	<tr>")
                        strHtml.Append("		<td align=""center"" class=""TITL"">コード</td>")
                        strHtml.Append("		<td align=""center"" class=""TITL"">名称</td>")
                        strHtml.Append("		<td align=""center"" class=""TITL"">内容１</td>")
                        strHtml.Append("		<td align=""center"" class=""TITL"">内容２</td>")
                        strHtml.Append("		<td align=""center"" class=""TITL"">表示順序</td>")
                        strHtml.Append("		<td align=""center"" class=""TITL"">登録日</td>")
                        strHtml.Append("		<td align=""center"" class=""TITR"">更新日</td>")
                        strHtml.Append("	</tr>")
                    End If

                    strHtml.Append("	<tr>")
                    strHtml.Append("		<td class=""OTHR"" >" & _
                                Convert.ToString(ds.Tables(0).Rows(intRow).Item("CD")) & "</td>")
                    strHtml.Append("		<td class=""OTHR"">" & _
                                Convert.ToString(ds.Tables(0).Rows(intRow).Item("NAME")) & "</td>")
                    strHtml.Append("		<td class=""OTHR"">" & _
                                Convert.ToString(ds.Tables(0).Rows(intRow).Item("NAIYO1")) & "</td>")
                    strHtml.Append("		<td class=""OTHR"">" & _
                                Convert.ToString(ds.Tables(0).Rows(intRow).Item("NAIYO2")) & "</td>")
                    strHtml.Append("		<td class=""OTHR"">" & _
                                Convert.ToString(ds.Tables(0).Rows(intRow).Item("DISP_NO")) & "</td>")
                    '作成日編集
                    strHtml.Append("		<td class=""OTHR"" align=""center"">" & _
                                fncDateSet(Convert.ToString(ds.Tables(0).Rows(intRow).Item("ADD_DATE"))) & "</td>")
                    '更新日編集
                    strHtml.Append("		<td class=""OTHR"" align=""center"">" & _
                                fncDateSet(Convert.ToString(ds.Tables(0).Rows(intRow).Item("EDT_DATE"))) & "</td>")
                    strHtml.Append("	</tr>")

                    If ds.Tables(0).Rows.Count <> 1 Then
                        strHtml.Append("	<tr>")
                        strHtml.Append("	<td widht=""985px"" colspan=""7"">")
                        strHtml.Append("        <table style=""BORDER-BOTTOM: black 1px solid"" cellSpacing=""0"" cellPadding=""0"" width=""100%""><tr><td></td></tr></table>")
                        strHtml.Append("    </td>")
                        strHtml.Append("	</tr>")
                    End If

                    strKbn = Convert.ToString(ds.Tables(0).Rows(intRow).Item("KBN"))
                Next

                strHtml.Append("</table>")

            End If

            lblHtml.Text = strHtml.ToString

            '//------------------------------------------
            '********************************************
            strRec = "OK"
        Catch ex As Exception
            strRec = ex.ToString
            Dim ErrMsgC As New CErrMsg
            strMsg.Append("alert('システムエラー：" & ErrMsgC.mGetArtMsg(strRec) & "');")
        End Try

    End Sub

    '******************************************************************************
    ' SQL作成
    '******************************************************************************
    '//------------------------------------------
    '<TODO>SELECT文の作成＆SQLパラメータのバインド
    Private Sub fncMakeSQL(ByVal pstrSQL As StringBuilder, ByVal pSqlParamC As CSQLParam)
        pstrSQL.Append("SELECT ")
        pstrSQL.Append("PL.KBN,")
        pstrSQL.Append("PM.NAME AS KBNNM,")
        pstrSQL.Append("PL.CD,")
        pstrSQL.Append("PL.NAME,")
        pstrSQL.Append("PL.NAIYO1,")
        pstrSQL.Append("PL.NAIYO2,")
        pstrSQL.Append("PL.DISP_NO,")
        pstrSQL.Append("PL.ADD_DATE,")
        pstrSQL.Append("PL.EDT_DATE ")
        pstrSQL.Append("FROM M06_PULLDOWN PM,")
        pstrSQL.Append("M06_PULLDOWN PL ")
        pstrSQL.Append("WHERE PM.KBN = '00'")
        pstrSQL.Append(" AND PM.CD = PL.KBN ")
        pstrSQL.Append("ORDER BY KBN,CD")

    End Sub

    '******************************************************************************
    '*　概　要：パラメータ値より日付YYYY/MM/DD値を返す
    '*　備　考：
    '******************************************************************************
    Public Function fncDateSet(ByVal pstrDate As String) As String
        Dim DateFncC As New CDateFnc
        Dim strRec As String
        strRec = ""
        If IsNumeric(pstrDate) = True Then
            strRec = DateFncC.mGet(pstrDate)
        End If

        Return strRec
    End Function
End Class
