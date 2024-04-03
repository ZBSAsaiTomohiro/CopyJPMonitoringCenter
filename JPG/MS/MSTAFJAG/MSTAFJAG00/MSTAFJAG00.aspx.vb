'***********************************************
'担当者マスタ一覧  メイン画面
'***********************************************
Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common
Imports JPG.Common.log

Imports System.Text

Partial Class MSTAFJAG00
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
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
             MyBase.MapPath("../../../MS/MSTAFJAG/MSTAFJAG00/") & "MSTAFJAG00.js"))
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

            '//-----------------------------------------------------
            '// 営業所グループのみに所属している場合、[営業所メニュー]より遷移してきている為
            '// 終了ボタン押下時は[営業所メニュー]に戻る
            '//-----------------------------------------------------
            hdnBackUrl.Value = ""
            Dim strGROUPNAME As String = AuthC.pGROUPNAME
            Dim arrGroupName() As String = strGROUPNAME.Split(Convert.ToChar(","))
            '--- ↓2005/04/19 MOD　Falcon↓ -----------------
            Dim arrKanshiGroup() As String = AuthC.pGROUP_KANSHI.Split(Convert.ToChar(","))
            Dim i As Integer
            Dim bolGroupFLG As Boolean = False

            '運行開発部・営業所の所属チェック
            If Array.IndexOf(arrGroupName, AuthC.pGROUP_UNKOU) >= 0 Or _
                Array.IndexOf(arrGroupName, AuthC.pGROUP_EIGYOU) >= 0 Then
                bolGroupFLG = True
            End If
            '--- ↑2005/04/19 MOD Falcon↑ ------------------
            '--- ↓2005/04/28 MOD　Falcon↓ -----------------
            '監視センター所属チェック
            If bolGroupFLG = False Then
                For i = 0 To arrKanshiGroup.Length - 1
                    If Array.IndexOf(arrGroupName, arrKanshiGroup(i)) >= 0 Then
                        bolGroupFLG = True
                        '//営業所グループ
                        hdnBackUrl.Value = "KANSHI"
                        Exit For
                    End If
                Next i
            End If
            '--- ↑2005/04/28 MOD Falcon↑ ------------------
            '--- ↓2005/04/19 MOD　Falcon↓ -----------------
            If bolGroupFLG = False Then
                Dim j As Integer
                Dim intEIGYOU_LEN As Integer
                Dim intGROUP_LEN As Integer
                intEIGYOU_LEN = AuthC.pGROUP_EIGYOU.Length
                For j = 0 To arrGroupName.Length - 1
                    intGROUP_LEN = arrGroupName(j).Length
                    If intGROUP_LEN > 0 Then
                        If Convert.ToString(arrGroupName(j)).Substring(intGROUP_LEN - intEIGYOU_LEN, intEIGYOU_LEN) = AuthC.pGROUP_EIGYOU Then
                            '//営業所グループ
                            hdnBackUrl.Value = "EIGYOU"
                        End If
                    End If
                Next
            End If
            '--- ↑2005/04/19 MOD Falcon↑ ------------------

            '--- ↓2005/04/19 DEL　Falcon↓ -----------------
            '''''If _
            '''''    Array.IndexOf(arrGroupName, AuthC.pGROUP_UNKOU) >= 0 Or _
            '''''    Array.IndexOf(arrGroupName, AuthC.pGROUP_TOUHOKU) >= 0 Or _
            '''''    Array.IndexOf(arrGroupName, AuthC.pGROUP_NAKANIHON) >= 0 Or _
            '''''    Array.IndexOf(arrGroupName, AuthC.pGROUP_NISHINIHON) >= 0 Or _
            '''''    Array.IndexOf(arrGroupName, AuthC.pGROUP_EIGYOU) >= 0 Then
            '''''    'いずれかのグループに所属している場合はそのメニューにて業務を行うため
            '''''    '通常[マスタメニュー]に戻る
            '''''Else
            '''''    Dim j As Integer
            '''''    Dim intEIGYOU_LEN As Integer
            '''''    Dim intGROUP_LEN As Integer
            '''''    intEIGYOU_LEN = AuthC.pGROUP_EIGYOU.Length
            '''''    For j = 0 To arrGroupName.Length - 1
            '''''        intGROUP_LEN = arrGroupName(j).Length
            '''''        If intGROUP_LEN > 0 Then
            '''''            If Convert.ToString(arrGroupName(j)).Substring(intGROUP_LEN - intEIGYOU_LEN, intEIGYOU_LEN) = AuthC.pGROUP_EIGYOU Then
            '''''                '//営業所グループ
            '''''                hdnBackUrl.Value = "EIGYOU"
            '''''            End If
            '''''        End If
            '''''    Next
            '''''End If
            '--- ↑2005/04/19 DEL Falcon↑ ------------------


            '--- ↓2008/07/31 ADD T.Watabe↓ -----------------
            ' 担当者一覧の選択画面からのパラメータ
            hdnKEY_KBN.Value = Request.Form("hdnKEY_KBN")       ' 1:JA支所/2:監視センター/3:出動会社
            hdnKEY_KURACD.Value = Request.Form("hdnKEY_KURACD") 'クライアントコード
            hdnKEY_CODE.Value = Request.Form("hdnKEY_CODE")     'コード
            hdnKEY_JACD.Value = Request.Form("hdnKEY_JACD")     'JAコード
            '2016/02/19 H.Mori add 2015改善開発 №9
            hdnKEY_GROUPCD.Value = Request.Form("hdnKEY_GROUPCD")     'グループコード
            '2015/11/02 w.ganeko 2015改善開発 №9
            hdnKEY_TANTOTEL.Value = Request.Form("hdnKEY_TANTOTEL")     'JA・担当者連絡先
            '--- ↑2005/07/31 DEL T.Watabe↑ ------------------


        Else
            '//--------------------------------------
            '//２回目以降実行される
            '//--------------------------------------
        End If

        '//-------------------------------------------------
        '<TODO>自分の画面IDをHIDDENのhdnMyAspxに書き込む（システム共通）
        hdnMyAspx.Value = "MSTAFJAG00"
        '//-------------------------------------------------

        Dim strRec As String

        Try
            '********************************************
            '//------------------------------------------
            '// Select文の作成
            Dim SQLC As New MSTAFJAG00CCSQL.CSQL
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
            Dim strKBN As String
            Dim strKBN_NM As String
            Dim intKBNSum As Integer
            Dim strKURACD As String
            Dim strCODE As String
            Dim strCODE_NM As String ' 2009/07/24 T.Watabe add
            Dim strCODE_HYOJI As String  ' 2013/07/02 T.Ono add  タイトル表示用
            '2016/02/25 H.Mori del 2015改善開発 №9 START
            'Dim strUSER_CD_FROM As String  ' 2013/07/02 T.Ono add
            'Dim strUSER_CD_TO As String    ' 2013/07/02 T.Ono add
            'Dim strUSER_CD As String = ""   ' 2013/07/02 T.Ono add　タイトル表示用
            '2016/02/25 H.Mori del 2015改善開発 №9 END
            Dim strCODE2 As String '2016/02/19 H.Mori add 2015改善開発 №9

            strHtml.Append("<table cellspacing=""0"" cellpadding=""1"" width=""970px"">")
            strHtml.Append("	<tr>")
            strHtml.Append("		<td width=""50px""></td>")                      'クライアントコード
            strHtml.Append("		<td width=""40px""></td>")                      'コード／担当者コード
            strHtml.Append("		<td width=""280px""></td>")                     'コード名称／担当者名
            strHtml.Append("		<td width=""100px""></td>")                     '連絡電話番号１／連絡電話番号２
            strHtml.Append("		<td width=""100px""></td>")                      'FAX番号
            strHtml.Append("		<td width=""40px""></td>")                      '表示順序
            strHtml.Append("		<td width=""260px""></td>")                     '記事
            strHtml.Append("		<td width=""40px""></td>")                      '登録日／更新日
            strHtml.Append("	</tr>" & vbCrLf)

            If Convert.ToString(ds.Tables(0).Rows(0).Item(0)) = "XYZ" Then
                '//------------------------------------------
                '<TODO>データが存在しない場合、空の明細行を出力する

                'ヘッダー行を出力
                strHtml.Append("	<tr>")
                strHtml.Append("		<td>&nbsp;</td>")
                strHtml.Append("	</tr>")
                strHtml.Append("	<tr>")
                strHtml.Append("		<td colspan=""9"">区分：</td>")
                strHtml.Append("	</tr>")
                ' ▼▼▼ 2013/07/02 T.Ono mod 顧客単位登録機能追加 ▼▼▼
                'strHtml.Append("	<tr>" & vbCrLf)
                'strHtml.Append("		<td rowspan=""2"" align=""center"" class=""TITL"" valign=""top"">ｸﾗｲｱﾝﾄ<BR>ｺｰﾄﾞ</td>" & vbCrLf)
                'strHtml.Append("		<td align=""center"" class=""TITTL"">担当者ｺｰﾄﾞ</td>" & vbCrLf)
                'strHtml.Append("		<td align=""center"" class=""TITTL"">担当者名</td>" & vbCrLf)
                'strHtml.Append("		<td align=""center"" class=""TITTL"">連絡電話番号１</td>" & vbCrLf)
                'strHtml.Append("		<td align=""center"" class=""TITTL"">FAX番号</td>" & vbCrLf)
                'strHtml.Append("		<td align=""center"" class=""TITBL"" rowspan=""2"" valign=""top"">表示<BR>順序</td>" & vbCrLf)
                'strHtml.Append("		<td align=""center"" class=""TITBL"" rowspan=""2"" valign=""top"">備考</td>" & vbCrLf)
                'strHtml.Append("		<td align=""center"" class=""TITR"">登録日</td>" & vbCrLf)
                'strHtml.Append("	</tr>")
                'strHtml.Append("	<tr>" & vbCrLf)
                'strHtml.Append("		<td align=""center"" class=""TITBL"">&nbsp;</td>" & vbCrLf)
                'strHtml.Append("		<td align=""center"" class=""TITBL"">&nbsp;</td>" & vbCrLf)
                'strHtml.Append("		<td align=""center"" class=""TITBL"">連絡電話番号２</td>" & vbCrLf)
                'strHtml.Append("		<td align=""center"" class=""TITBL"">&nbsp;</td>" & vbCrLf)
                'strHtml.Append("		<td align=""center"" class=""TITBR"">更新日</td>" & vbCrLf)
                'strHtml.Append("	</tr>" & vbCrLf)
                strHtml.Append("	<tr>" & vbCrLf)
                strHtml.Append("		<td rowspan=""3"" align=""center"" class=""TITL"" valign=""top"">ｸﾗｲｱﾝﾄ<BR>ｺｰﾄﾞ</td>" & vbCrLf)
                strHtml.Append("		<td rowspan=""3"" align=""center"" class=""TITL"" valign=""top"">担当者ｺｰﾄﾞ</td>" & vbCrLf)
                strHtml.Append("		<td rowspan=""3"" align=""center"" class=""TITL"" valign=""top"">担当者名</td>" & vbCrLf)
                strHtml.Append("		<td align=""center"" class=""TITTL"">連絡電話番号１</td>" & vbCrLf)
                ' 2014/01/07 T.Ono mod 改善対応2013 JA担当者は項目名変更
                'strHtml.Append("		<td align=""center"" class=""TITTL"">FAX番号</td>" & vbCrLf)
                If hdnKEY_KBN.Value = "1" Then
                    strHtml.Append("		<td align=""center"" class=""TITTL"">ｽﾎﾟｯﾄFAX番号</td>" & vbCrLf)
                Else
                    strHtml.Append("		<td align=""center"" class=""TITTL"">FAX番号</td>" & vbCrLf)
                End If
                strHtml.Append("		<td align=""center"" class=""TITBL"" rowspan=""3"" valign=""top"">表示<BR>順序</td>" & vbCrLf)
                ' 2013/11/29 T.Ono mod 改善対応2013 JA担当者は項目名変更
                'strHtml.Append("		<td align=""center"" class=""TITBL"" rowspan=""3"" valign=""top"">備考</td>" & vbCrLf)
                If hdnKEY_KBN.Value = "1" Then
                    strHtml.Append("		<td align=""center"" class=""TITBL"" rowspan=""3"" valign=""top"">記事</td>" & vbCrLf)
                Else
                    strHtml.Append("		<td align=""center"" class=""TITBL"" rowspan=""3"" valign=""top"">備考</td>" & vbCrLf)
                End If
                strHtml.Append("		<td align=""center"" class=""TITTR"">登録日</td>" & vbCrLf)
                strHtml.Append("	</tr>" & vbCrLf)
                strHtml.Append("	<tr>" & vbCrLf)
                strHtml.Append("		<td align=""center"" class=""TITTL"">連絡電話番号２</td>" & vbCrLf)
                strHtml.Append("		<td align=""center"" class=""TITL"" rowspan=""2"" valign=""top"">自動FAX番号</td>" & vbCrLf)
                strHtml.Append("		<td align=""center"" class=""TITR"" rowspan=""2"" valign=""top"">更新日</td>" & vbCrLf)
                strHtml.Append("	</tr>" & vbCrLf)
                strHtml.Append("	<tr>" & vbCrLf)
                strHtml.Append("		<td align=""center"" class=""TITBL"">連絡電話番号３</td>" & vbCrLf)
                strHtml.Append("	</tr>" & vbCrLf)
                ' ▲▲▲ 2013/07/02 T.Ono mod 顧客単位登録機能追加 ▲▲▲

                '明細行を出力（空）
                strHtml.Append("	<tr>" & vbCrLf)
                strHtml.Append("		<td class=""OTHR"" rowspan=""2""></td>" & vbCrLf)
                strHtml.Append("		<td class=""OTHR""></td>" & vbCrLf)
                strHtml.Append("		<td class=""OTHR""></td>" & vbCrLf)
                strHtml.Append("		<td class=""OTHR""></td>" & vbCrLf)
                strHtml.Append("		<td class=""OTHR""></td>" & vbCrLf)
                strHtml.Append("		<td class=""OTHR"" rowspan=""2""></td>" & vbCrLf)
                strHtml.Append("		<td class=""OTHR"" rowspan=""2""></td>" & vbCrLf)
                strHtml.Append("		<td class=""OTHR""></td>" & vbCrLf)
                strHtml.Append("	</tr>")
                strHtml.Append("    <tr>" & vbCrLf)
                strHtml.Append("		<td class=""OTHR""></td>" & vbCrLf)
                strHtml.Append("		<td class=""OTHR""></td>" & vbCrLf)
                strHtml.Append("		<td class=""OTHR""></td>" & vbCrLf)
                strHtml.Append("		<td class=""OTHR""></td>" & vbCrLf)
                strHtml.Append("		<td class=""OTHR""></td>" & vbCrLf)
                strHtml.Append("	</tr>" & vbCrLf)
            Else
                For intRow = 0 To ds.Tables(0).Rows.Count - 1
                    '2016/02/25 H.Mori del? 2015改善開発 №9 START
                    'If strKBN <> Convert.ToString(ds.Tables(0).Rows(intRow).Item("KBN")) And _
                    '    intRow <> 0 Then
                    '    '合計欄出力
                    '    strHtml.Append("	<tr>")
                    '    strHtml.Append("		<td height=""5px""></td>")
                    '    strHtml.Append("	</tr>")
                    '    strHtml.Append("	<tr>")
                    '    strHtml.Append("		<td class=""COMMT"" colspan=""9"">　　合計　　" & intKBNSum & "</td>")
                    '    strHtml.Append("	</tr>" & vbCrLf)

                    '    intKBNSum = 0

                    'End If
                    '2016/02/25 H.Mori del? 2015改善開発 №9 END

                    ' 2013/07/02 T.Ono mod
                    'If strKBN <> Convert.ToString(ds.Tables(0).Rows(intRow).Item("KBN")) Or _
                    '   strKURACD <> Convert.ToString(ds.Tables(0).Rows(intRow).Item("KURACD")) Or _
                    '   strCODE <> Convert.ToString(ds.Tables(0).Rows(intRow).Item("CODE")) Then
                    '2016/02/17 H.Mori mod 2015改善開発 №9 START
                    'If strKBN <> Convert.ToString(ds.Tables(0).Rows(intRow).Item("KBN")) Or _
                    '    strKURACD <> Convert.ToString(ds.Tables(0).Rows(intRow).Item("KURACD")) Or _
                    '    strCODE <> Convert.ToString(ds.Tables(0).Rows(intRow).Item("CODE")) Then
                    '    'strUSER_CD_FROM <> Convert.ToString(ds.Tables(0).Rows(intRow).Item("USER_CD_FROM")) Or _
                    '    'strUSER_CD_TO <> Convert.ToString(ds.Tables(0).Rows(intRow).Item("USER_CD_TO")) Then
                    If hdnKEY_KBN.Value = "1" Then
                        strCODE2 = Convert.ToString(ds.Tables(0).Rows(intRow).Item("GROUPCD"))
                    Else
                        strCODE2 = Convert.ToString(ds.Tables(0).Rows(intRow).Item("CODE"))
                    End If
                    If strKBN <> Convert.ToString(ds.Tables(0).Rows(intRow).Item("KBN")) Or _
                        strKURACD <> Convert.ToString(ds.Tables(0).Rows(intRow).Item("KURACD")) Or _
                        strCODE <> strCODE2 Then
                        '2016/02/17 H.Mori mod 2015改善開発 №9 END

                        strTemp = Convert.ToString(ds.Tables(0).Rows(intRow).Item("KBN"))
                        If strTemp = "1" Then
                            strKBN_NM = "監視センター担当者"
                            strCODE_NM = Convert.ToString(ds.Tables(0).Rows(intRow).Item("KANSI_NAME")) ' 2009/07/24 T.Watabe add
                        ElseIf strTemp = "2" Then
                            strKBN_NM = "出動会社担当者"
                            strCODE_NM = Convert.ToString(ds.Tables(0).Rows(intRow).Item("KAISYA_NAME")) ' 2009/07/24 T.Watabe add
                            '2016/02/17 H.Mori mod 2015改善開発 №9 START
                            'ElseIf strTemp = "3" Then
                        ElseIf strTemp = " " Then
                            strKBN_NM = "ＪＡ支所担当者"
                            'strCODE_NM = Convert.ToString(ds.Tables(0).Rows(intRow).Item("JAS_NAME")) ' 2009/07/24 T.Watabe add
                            strCODE_NM = Convert.ToString(ds.Tables(0).Rows(intRow).Item("GROUPNM"))
                            '2016/02/17 H.Mori mod 2015改善開発 №9 END
                        End If

                        'ヘッダー行を出力
                        strHtml.Append("	<tr>")
                        '最初のループ以外
                        If intRow <> 0 Then
                            strHtml.Append("		<td class=""BREAK"">&nbsp;</td>") '印刷時の改行コード挿入！
                        Else
                            strHtml.Append("        <td>&nbsp;</td>")
                        End If
                        strHtml.Append("	</tr>")
                        strHtml.Append("	<tr height=""30px"">")

                        ' ▼▼▼ 2013/07/02 T.Ono mod 顧客単位登録機能追加 ▼▼▼
                        'タイトル文字列を作る（CODE="XXXX"の場合はCODEを表示しない）
                        '2016/02/17 H.Mori mod 2015改善開発 №9 START
                        'If Convert.ToString(ds.Tables(0).Rows(intRow).Item("CODE")) = "XXXX" Then
                        '    strCODE_HYOJI = ""
                        'Else
                        '    strCODE_HYOJI = Convert.ToString(ds.Tables(0).Rows(intRow).Item("CODE"))
                        'End If
                        If hdnKEY_KBN.Value = "1" Then
                            strCODE_HYOJI = Convert.ToString(ds.Tables(0).Rows(intRow).Item("GROUPCD"))
                        Else
                            strCODE_HYOJI = Convert.ToString(ds.Tables(0).Rows(intRow).Item("CODE"))
                        End If
                        '2016/02/17 H.Mori mod 2015改善開発 №9 END
                        'タイトル文字列を作る(ユーザーコード)
                        '2016/02/17 H.Mori del 2015改善開発 №9 START
                        'If Convert.ToString(ds.Tables(0).Rows(intRow).Item("USER_CD_FROM")) <> "" Then
                        '    strUSER_CD = Convert.ToString(ds.Tables(0).Rows(intRow).Item("USER_CD_FROM"))
                        '    If Convert.ToString(ds.Tables(0).Rows(intRow).Item("USER_CD_TO")) <> "" Then
                        '        strUSER_CD += " ～ " & Convert.ToString(ds.Tables(0).Rows(intRow).Item("USER_CD_TO"))
                        '    End If
                        'Else
                        '    strUSER_CD = ""
                        'End If
                        '2016/02/17 H.Mori del 2015改善開発 №9 END
                        'タイトル表示を変更
                        'strHtml.Append("		<td colspan=""7"" class=""COMMT"">区分：　　" & _
                        '                    Convert.ToString(ds.Tables(0).Rows(intRow).Item("KBN")) & "　" & strKBN_NM & " " & Convert.ToString(ds.Tables(0).Rows(intRow).Item("CODE")) & " " & strCODE_NM & "</td>" & vbCrLf)
                        '2016/02/19 H.Mori mod 2015改善開発 №9 START
                        'strHtml.Append("		<td colspan=""7"" class=""COMMT"">区分：　　" & _
                        '                Convert.ToString(ds.Tables(0).Rows(intRow).Item("KBN")) & "　" & strKBN_NM & " " & _
                        '                strCODE_HYOJI & " " & strCODE_NM & " " & strUSER_CD & "</td>" & vbCrLf)
                        strHtml.Append("		<td colspan=""7"" class=""COMMT"">区分：　　" & _
                                        Convert.ToString(ds.Tables(0).Rows(intRow).Item("KBN")) & "　" & strKBN_NM & " " & _
                                        strCODE_HYOJI & " " & strCODE_NM & "</td>" & vbCrLf)
                        '2016/02/19 H.Mori mod 2015改善開発 №9 START
                        ' ▲▲▲ 2013/07/02 T.Ono mod 顧客単位登録機能追加 ▲▲▲

                        strHtml.Append("		<td colspan=""2"" class=""COMMT""><table style=""BORDER: black 0px solid; FONT-SIZE: 11px;"" cellSpacing=""0"" cellPadding=""0""><tr height=""30px""><td style=""BORDER: black 1px solid; FONT-SIZE: 12px; width:60px; text-align:center;"">確認印</td><td style=""BORDER: black 1px solid; FONT-SIZE: 12px; width:40px; text-align:center;"">&nbsp;</td></tr></table></td>")
                        strHtml.Append("	</tr>")
                        ' ▼▼▼ 2013/07/02 T.Ono mod 顧客単位登録機能追加 ▼▼▼ 電話番号３、自動FAX番号追加
                        'strHtml.Append("	<tr>")
                        'strHtml.Append("		<td align=""center"" class=""TITL"" valign=""top"" rowspan=""2"">ｸﾗｲｱﾝﾄ<BR>ｺｰﾄﾞ</td>" & vbCrLf)
                        'strHtml.Append("		<td align=""center"" class=""TITBL"" valign=""top"" rowspan=""2"">担当</td>" & vbCrLf)
                        'strHtml.Append("		<td align=""center"" class=""TITBL"" valign=""top"" rowspan=""2"">担当者名</td>" & vbCrLf)
                        'strHtml.Append("		<td align=""center"" class=""TITTL"">連絡電話番号１</td>" & vbCrLf)
                        'strHtml.Append("		<td align=""center"" class=""TITBL"" valign=""top"" rowspan=""2"">FAX番号</td>" & vbCrLf)
                        'strHtml.Append("		<td align=""center"" class=""TITBL"" valign=""top"" rowspan=""2"">表示<BR>順序</td>" & vbCrLf)
                        'strHtml.Append("		<td align=""center"" class=""TITBL"" valign=""top"" rowspan=""2"">備考</td>" & vbCrLf)
                        'strHtml.Append("		<td align=""center"" class=""TITTR"">登録日</td>" & vbCrLf)
                        'strHtml.Append("	</tr>")
                        'strHtml.Append("	<tr>")
                        'strHtml.Append("		<td align=""center"" class=""TITBL"">連絡電話番号２</td>")
                        'strHtml.Append("		<td align=""center"" class=""TITBR"">更新日</td>" & vbCrLf)
                        'strHtml.Append("	</tr>" & vbCrLf)
                        strHtml.Append("	<tr>")
                        strHtml.Append("		<td align=""center"" class=""TITL"" valign=""top"" rowspan=""3"">ｸﾗｲｱﾝﾄ<BR>ｺｰﾄﾞ</td>" & vbCrLf)
                        strHtml.Append("		<td align=""center"" class=""TITBL"" valign=""top"" rowspan=""3"">担当</td>" & vbCrLf)
                        strHtml.Append("		<td align=""center"" class=""TITBL"" valign=""top"" rowspan=""3"">担当者名</td>" & vbCrLf)
                        strHtml.Append("		<td align=""center"" class=""TITTL"">連絡電話番号１</td>" & vbCrLf)
                        ' 2014/01/07 T.Ono mod 改善対応2013 JA担当者は項目名変更
                        'strHtml.Append("		<td align=""center"" class=""TITTL"">FAX番号</td>" & vbCrLf)
                        If hdnKEY_KBN.Value = "1" Then
                            strHtml.Append("		<td align=""center"" class=""TITTL"">ｽﾎﾟｯﾄFAX番号</td>" & vbCrLf)
                        Else
                            strHtml.Append("		<td align=""center"" class=""TITTL"">FAX番号</td>" & vbCrLf)
                        End If
                        strHtml.Append("		<td align=""center"" class=""TITBL"" valign=""top"" rowspan=""3"">表示<BR>順序</td>" & vbCrLf)
                        ' 2013/11/29 T.Ono mod 改善対応2013 JA担当者は項目名変更
                        'strHtml.Append("		<td align=""center"" class=""TITBL"" valign=""top"" rowspan=""3"">備考</td>" & vbCrLf)
                        If hdnKEY_KBN.Value = "1" Then
                            strHtml.Append("		<td align=""center"" class=""TITBL"" valign=""top"" rowspan=""3"">記事</td>" & vbCrLf)
                        Else
                            strHtml.Append("		<td align=""center"" class=""TITBL"" valign=""top"" rowspan=""3"">備考</td>" & vbCrLf)
                        End If
                        strHtml.Append("		<td align=""center"" class=""TITTR"">登録日</td>" & vbCrLf)
                        strHtml.Append("	</tr>" & vbCrLf)
                        strHtml.Append("	<tr>" & vbCrLf)
                        strHtml.Append("		<td align=""center"" class=""TITTL"">連絡電話番号２</td>" & vbCrLf)
                        strHtml.Append("		<td align=""center"" class=""TITBL"" valign=""top"" rowspan=""2"">自動FAX番号</td>" & vbCrLf)
                        strHtml.Append("		<td align=""center"" class=""TITBR"" valign=""top"" rowspan=""2"">更新日</td>" & vbCrLf)
                        strHtml.Append("	</tr>" & vbCrLf)
                        strHtml.Append("	<tr>" & vbCrLf)
                        strHtml.Append("		<td align=""center"" class=""TITBL"">連絡電話番号３</td>" & vbCrLf)
                        strHtml.Append("	</tr>" & vbCrLf)
                        ' ▲▲▲ 2013/07/02 T.Ono mod 顧客単位登録機能追加 ▲▲▲
                    End If

                    '明細行を出力

                    strHtml.Append("	<tr>")
                    'クライアントコード
                    strTemp = Convert.ToString(ds.Tables(0).Rows(intRow).Item("KURACD"))

                    If strTemp = "ZZZZ" Then
                        ' 2013/07/02 T.Ono mod
                        'strHtml.Append("		<td class=""OTHR"" valign=""top"" rowspan=""2""></td>" & vbCrLf)
                        strHtml.Append("		<td class=""OTHR"" valign=""top"" rowspan=""3""></td>" & vbCrLf)
                    Else
                        ' 2013/07/02 T.Ono mod
                        'strHtml.Append("		<td class=""OTHR"" valign=""top"" rowspan=""2"">" & _
                        '            Convert.ToString(ds.Tables(0).Rows(intRow).Item("KURACD")) & "</td>" & vbCrLf)
                        strHtml.Append("		<td class=""OTHR"" valign=""top"" rowspan=""3"">" & _
                                    Convert.ToString(ds.Tables(0).Rows(intRow).Item("KURACD")) & "</td>" & vbCrLf)
                    End If
                    ''コード
                    'strHtml.Append("		<td class=""OTHR"">" & _
                    '            Convert.ToString(ds.Tables(0).Rows(intRow).Item("CODE")) & "</td>" & vbCrLf)
                    ''コード名称
                    'strTemp = Convert.ToString(ds.Tables(0).Rows(intRow).Item("KBN"))
                    'If strTemp = "1" Then           '監視センター担当者名
                    '    strHtml.Append("		<td class=""OTHR"">" & _
                    '                Convert.ToString(ds.Tables(0).Rows(intRow).Item("KANSI_NAME")) & "</td>" & vbCrLf)
                    'ElseIf strTemp = "2" Then       '出動会社担当者名
                    '    strHtml.Append("		<td class=""OTHR"">" & _
                    '                Convert.ToString(ds.Tables(0).Rows(intRow).Item("KAISYA_NAME")) & "</td>" & vbCrLf)
                    'ElseIf strTemp = "3" Then       'ＪＡ支所担当者名
                    '    strHtml.Append("		<td class=""OTHR"">" & _
                    '                Convert.ToString(ds.Tables(0).Rows(intRow).Item("JAS_NAME")) & "</td>" & vbCrLf)
                    'End If
                    '担当者コード
                    strHtml.Append("		<td class=""OTHR"">" & _
                        Convert.ToString(ds.Tables(0).Rows(intRow).Item("TANCD")) & "</td>" & vbCrLf)
                    '担当者名
                    strHtml.Append("		<td class=""OTHR"">" & _
                        Convert.ToString(ds.Tables(0).Rows(intRow).Item("TANNM")) & "</td>" & vbCrLf)
                    '連絡電話番号１
                    strHtml.Append("		<td class=""OTHR"">" & _
                        Convert.ToString(ds.Tables(0).Rows(intRow).Item("RENTEL1")) & "</td>" & vbCrLf)
                    'FAX番号
                    strHtml.Append("		<td class=""OTHR"">" & _
                        Convert.ToString(ds.Tables(0).Rows(intRow).Item("FAXNO")) & "</td>" & vbCrLf)
                    '表示順序
                    '2016/02/17 H.Mori mod 2015改善開発 №9 START
                    ' 2013/07/02 T.Ono mod
                    'strHtml.Append("		<td class=""OTHR"" valign=""top"" rowspan=""2"">" & _
                    '            Convert.ToString(ds.Tables(0).Rows(intRow).Item("DISP_NO")) & "</td>" & vbCrLf)
                    'strHtml.Append("		<td class=""OTHR"" valign=""top"" rowspan=""3"">" & _
                    '               Convert.ToString(ds.Tables(0).Rows(intRow).Item("DISP_NO")) & "</td>" & vbCrLf)
                    If hdnKEY_KBN.Value = "1" Then
                        strHtml.Append("		<td class=""OTHR"" valign=""top"" rowspan=""3"">" & "" & "</td>" & vbCrLf)
                    Else
                        strHtml.Append("		<td class=""OTHR"" valign=""top"" rowspan=""3"">" & _
                                       Convert.ToString(ds.Tables(0).Rows(intRow).Item("DISP_NO")) & "</td>" & vbCrLf)
                    End If
                    '2016/02/17 H.Mori mod 2015改善開発 №9 END
                    '備考／記事
                    ' 2013/07/02 T.Ono mod
                    'strHtml.Append("		<td class=""OTHR"" valign=""top"" rowspan=""2"">" & _
                    '            Convert.ToString(ds.Tables(0).Rows(intRow).Item("BIKO")) & "</td>" & vbCrLf)
                    strHtml.Append("		<td class=""OTHR"" valign=""top"" rowspan=""3"">" & _
                                Convert.ToString(ds.Tables(0).Rows(intRow).Item("BIKO")) & "</td>" & vbCrLf)
                    '作成日編集
                    strHtml.Append("		<td class=""OTHR"" align=""center"">" & _
                                fncDateSet(Convert.ToString(ds.Tables(0).Rows(intRow).Item("ADD_DATE"))) & "</td>" & vbCrLf)
                    strHtml.Append("	</tr>")
                    strHtml.Append("    <tr>")
                    ''担当者コード
                    'strHtml.Append("		<td class=""OTHR"">" & _
                    '            Convert.ToString(ds.Tables(0).Rows(intRow).Item("TANCD")) & "</td>" & vbCrLf)
                    ''担当者名
                    'strHtml.Append("		<td class=""OTHR"">" & _
                    '            Convert.ToString(ds.Tables(0).Rows(intRow).Item("TANNM")) & "</td>" & vbCrLf)
                    strHtml.Append("		<td class=""OTHR"">" & "" & "</td>" & vbCrLf)
                    strHtml.Append("		<td class=""OTHR"">" & "" & "</td>" & vbCrLf)
                    '連絡電話番号２
                    strHtml.Append("		<td class=""OTHR"">" & _
                                Convert.ToString(ds.Tables(0).Rows(intRow).Item("RENTEL2")) & "</td>" & vbCrLf)
                    ' 2013/07/02 T.Ono mod
                    '自動FAX番号
                    'strHtml.Append("		<td class=""OTHR""></td>" & vbCrLf)
                    strHtml.Append("		<td class=""OTHR"">" & _
                                Convert.ToString(ds.Tables(0).Rows(intRow).Item("AUTO_FAXNO")) & "</td>" & vbCrLf)
                    '更新日編集
                    ' 2013/07/02 T.Ono mod
                    'strHtml.Append("		<td class=""OTHR"" align=""center"">" & _
                    '            fncDateSet(Convert.ToString(ds.Tables(0).Rows(intRow).Item("EDT_DATE"))) & "&nbsp;</td>" & vbCrLf)
                    strHtml.Append("		<td class=""OTHR"" align=""center"" valign=""top"" rowspan=""2"">" & _
                                fncDateSet(Convert.ToString(ds.Tables(0).Rows(intRow).Item("EDT_DATE"))) & "&nbsp;</td>" & vbCrLf)
                    strHtml.Append("	</tr>" & vbCrLf)

                    ' ▼▼▼ 2013/07/02 T.Ono add 顧客単位登録機能追加 ▼▼▼
                    '3列目
                    strHtml.Append("    <tr>")
                    '担当者コード
                    strHtml.Append("		<td class=""OTHR"">" & "" & "</td>" & vbCrLf)
                    '担当者名
                    strHtml.Append("		<td class=""OTHR"">" & "" & "</td>" & vbCrLf)
                    '連絡電話番号３
                    strHtml.Append("		<td class=""OTHR"">" & _
                                Convert.ToString(ds.Tables(0).Rows(intRow).Item("RENTEL3")) & "</td>" & vbCrLf)
                    strHtml.Append("		<td class=""OTHR""></td>" & vbCrLf)
                    strHtml.Append("	</tr>" & vbCrLf)
                    ' ▲▲▲ 2013/07/02 T.Ono add 顧客単位登録機能追加 ▲▲▲

                    If ds.Tables(0).Rows.Count <> 1 Then
                        strHtml.Append("	<tr>")
                        strHtml.Append("	<td widht=""985px"" colspan=""9"">")
                        strHtml.Append("        <table style=""BORDER-BOTTOM: black 1px solid"" cellSpacing=""0"" cellPadding=""0"" width=""100%""><tr><td></td></tr></table>")
                        strHtml.Append("    </td>")
                        strHtml.Append("	</tr>" & vbCrLf)
                    End If

                    intKBNSum = intKBNSum + 1

                    strKBN = Convert.ToString(ds.Tables(0).Rows(intRow).Item("KBN"))
                    strKURACD = Convert.ToString(ds.Tables(0).Rows(intRow).Item("KURACD"))
                    '2016/02/17 H.Mori mod 2015改善開発 №9 START
                    'strCODE = Convert.ToString(ds.Tables(0).Rows(intRow).Item("CODE"))
                    'strUSER_CD_FROM = Convert.ToString(ds.Tables(0).Rows(intRow).Item("USER_CD_FROM"))  ' 2013/07/02 T.Ono add
                    'strUSER_CD_TO = Convert.ToString(ds.Tables(0).Rows(intRow).Item("USER_CD_TO"))      ' 2013/07/02 T.Ono add
                    If hdnKEY_KBN.Value = "1" Then
                        strCODE = Convert.ToString(ds.Tables(0).Rows(intRow).Item("GROUPCD"))                       
                    Else
                        strCODE = Convert.ToString(ds.Tables(0).Rows(intRow).Item("CODE"))
                    End If
                    '2016/02/17 H.Mori mod 2015改善開発 №9 END
                Next

                strHtml.Append("	<tr>")
                strHtml.Append("		<td height=""5px""></td>" & vbCrLf)
                strHtml.Append("	</tr>")
                strHtml.Append("	<tr>")
                strHtml.Append("		<td class=""COMMT"" colspan=""9"">　　合計　　" & intKBNSum & "</td>" & vbCrLf)
                strHtml.Append("	</tr>")
                strHtml.Append("</table>" & vbCrLf)

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
        Dim i As Integer
        Dim arrTemp() As String
        Dim strCenter As String = ""
        If hdnBackUrl.Value <> "EIGYOU" Then
            arrTemp = AuthC.pAUTHCENTERCD.Split(Convert.ToChar(","))
            For i = 0 To arrTemp.Length - 1
                If strCenter.Length > 0 Then
                    strCenter = strCenter & ","
                End If
                strCenter = strCenter & "'" & arrTemp(i) & "'"
            Next
        End If
        '2016/02/17 H.Mori add 2015改善開発 №9 
        If hdnKEY_KBN.Value = "2" Or hdnKEY_KBN.Value = "3" Then
            pstrSQL.Append("SELECT ")
            pstrSQL.Append("      TA.KBN, ")
            pstrSQL.Append("      TA.KURACD, ")
            pstrSQL.Append("      TA.CODE, ")
            '2016/02/17 H.Mori del 2015改善開発 №9
            'pstrSQL.Append("      JA.JAS_NAME, ")        
            pstrSQL.Append("      KA.KANSI_NAME, ")
            pstrSQL.Append("      SH.KAISYA_NAME, ")
            pstrSQL.Append("      TA.TANCD, ")
            pstrSQL.Append("      TA.TANNM, ")
            pstrSQL.Append("      TA.RENTEL1, ")
            pstrSQL.Append("      TA.RENTEL2, ")
            pstrSQL.Append("      FAXNO, ")
            pstrSQL.Append("      TA.DISP_NO, ")
            pstrSQL.Append("      TA.BIKO, ")
            pstrSQL.Append("      TA.ADD_DATE, ")
            pstrSQL.Append("      TA.EDT_DATE ")
            ' ▼▼▼ 2013/07/01 T.Ono add 顧客単位登録機能追加 ▼▼▼
            pstrSQL.Append("      , ")
            '2016/02/17 H.Mori del 2015改善開発 №9
            'pstrSQL.Append("      NULL AS USER_CD_FROM, ")
            '2016/02/17 H.Mori del 2015改善開発 №9
            'pstrSQL.Append("      NULL AS USER_CD_TO, ")
            pstrSQL.Append("      TA.AUTO_FAXNO, ")
            pstrSQL.Append("      TA.RENTEL3 ")
            '2016/02/17 H.Mori del 2015改善開発 №9
            'pstrSQL.Append("      '01' AS NO, ")   '顧客単位の登録と区別
            '2016/02/17 H.Mori del 2015改善開発 №9
            'pstrSQL.Append("      DECODE(TA.CODE,'XXXX','01','02') AS NO2 ")   'クライアントのみの登録を区別
            ' ▲▲▲ 2013/07/01 T.Ono add 顧客単位登録機能追加 ▲▲▲
            pstrSQL.Append("FROM  M05_TANTO TA, ")
            pstrSQL.Append("      HN2MAS JA, ")
            pstrSQL.Append("      KANSIMAS KA,")

            '--- ↓2005/04/29 ADD Falcon↓ ---
            pstrSQL.Append("      CLIMAS CL, ")
            '--- ↑2005/04/29 ADD Falcon↑ ---

            pstrSQL.Append("      SHUTUDOMAS SH ")
            pstrSQL.Append("WHERE TA.KURACD = JA.CLI_CD(+) ")

            '--- ↓2005/04/29 ADD Falcon↓ ---
            pstrSQL.Append("  AND TA.KURACD = CL.CLI_CD(+) ")
            '--- ↑2005/04/29 ADD Falcon↑ ---

            '2016/02/17 H.Mori del 2015改善開発 №9
            'pstrSQL.Append("  AND TA.CODE = JA.HAN_CD(+) ")
            pstrSQL.Append("  AND TA.CODE = KA.KANSI_CD(+) ")

            '--- ↓2005/07/13 MOD Falcon↓ ---  出動会社コード＋拠点コードで検索
            'pstrSQL.Append("  AND TA.CODE = SH.SHUTU_CD(+) ")
            pstrSQL.Append("  AND TA.CODE = SH.SHUTU_CD(+) || SH.KYOTEN_CD(+)")
            '--- ↑2005/07/13 MOD Falcon↑ ---

            'pstrSQL.Append("  AND '00' = SH.KYOTEN_CD(+) ")    '--- 2005/07/20 DEL Falcon

            '--- ↓2005/04/29 ADD Falcon↓ ---
            If hdnBackUrl.Value <> "EIGYOU" Then
                pstrSQL.Append("  AND ((TA.KBN='1' AND KA.KANSI_CD IN (" & strCenter & ")) ")
                pstrSQL.Append("      OR (TA.KBN='2'AND SH.KANSI_CD IN (" & strCenter & "))) ")
                '2016/02/17 H.Mori del 2015改善開発 №9
                'pstrSQL.Append("      OR (TA.KBN='3' AND CL.KANSI_CODE IN (" & strCenter & "))) ")
            End If
            '--- ↑2005/04/29 ADD Falcon↑ ---

            '--- ↓2007/07/31 ADD T.Watabe↓ ---

            '2016/02/17 H.Mori del 2015改善開発 №9 START
            'If hdnKEY_KBN.Value = "1" Or hdnKEY_KBN.Value = "2" Or hdnKEY_KBN.Value = "3" Then
            ' 1:JA支所/2:監視センター/3:出動会社

            'M05_TANTO KBN      【区分】                1:監視センター担当者　2:出動会社担当者 3:JA支所担当者
            'M05_TANTO KURACD   【クライアントコード】  JA支所の場合クライアントコード、その他の場合、ALL「Z」をセット
            'M05_TANTO CODE     【コード】              監視センターコードまたは出動会社コードまたはJA支所コード

            '2016/02/17 H.Mori del 2015改善開発 №9 START
            'If hdnKEY_KBN.Value = "1" Then '1:JA支所
            '    pstrSQL.Append("  AND TA.KBN='3' ")
            '2016/02/17 H.Mori del 2015改善開発 №9 END
            If hdnKEY_KBN.Value = "2" Then '2:監視センター
                pstrSQL.Append("  AND TA.KBN='1' ")
            ElseIf hdnKEY_KBN.Value = "3" Then '3:出動会社
                pstrSQL.Append("  AND TA.KBN='2' ")
            End If
            '2012/04/04 NEC ou Add Upd Str
            '2016/02/17 H.Mori del 2015改善開発 №9 START
            'If hdnKEY_KURACD.Value.Trim <> "" Then 'クライアントコード
            '    pstrSQL.Append("  AND TA.KURACD = '" & hdnKEY_KURACD.Value.Trim & "' ")
            'End If
            '2016/02/17 H.Mori del 2015改善開発 №9 END
            If hdnKEY_CODE.Value.Trim <> "" Then 'コード
                pstrSQL.Append("  AND TA.CODE = '" & hdnKEY_CODE.Value.Trim & "' ")
            End If
            '2012/04/04 NEC ou Add Upd End
            '2016/02/17 H.Mori del 2015改善開発 №9 START
            'If hdnKEY_JACD.Value <> "" Then 'JAコード(前方一致)
            '    pstrSQL.Append("  AND TA.CODE LIKE '" & hdnKEY_JACD.Value & "%' ")
            'End If
            '2016/02/17 H.Mori del 2015改善開発 №9 END
            '2016/02/17 H.Mori del 2015改善開発 №9 START
            '2016/02/08 H.Mori 2015改善開発 №9 START
            '2015/11/02 w.ganeko 2015改善開発 №9 start
            'If hdnKEY_TANTOTEL.Value <> "" Then
            '    pstrSQL.Append("  AND ( ")
            '    pstrSQL.Append("  TA.RENTEL1 = '" & hdnKEY_TANTOTEL.Value & "' ")
            '    pstrSQL.Append("  OR TA.RENTEL2 = '" & hdnKEY_TANTOTEL.Value & "' ")
            '    pstrSQL.Append("  OR TA.RENTEL3 = '" & hdnKEY_TANTOTEL.Value & "' ")
            '    pstrSQL.Append("  ) ")
            'End If
            '2015/11/02 w.ganeko 2015改善開発 №9 end
            'If hdnKEY_TANTOTEL.Value <> "" Then
            '    pstrSQL.Append("  AND ( ")
            '    pstrSQL.Append("  REPLACE(REPLACE(TA.RENTEL1,'-',''), ' ','') ")
            '    pstrSQL.Append("  LIKE REPLACE('" & hdnKEY_TANTOTEL.Value & "','-','') || '%' ")
            '    pstrSQL.Append("  OR REPLACE(REPLACE(TA.RENTEL2,'-',''), ' ','') ")
            '    pstrSQL.Append("  LIKE REPLACE('" & hdnKEY_TANTOTEL.Value & "','-','') || '%' ")
            '    pstrSQL.Append("  OR REPLACE(REPLACE(TA.RENTEL3,'-',''), ' ','') ")
            '    pstrSQL.Append("  LIKE REPLACE('" & hdnKEY_TANTOTEL.Value & "','-','') || '%' ")
            '    pstrSQL.Append("  ) ")
            'End If
            '2016/02/08 H.Mori 2015改善開発 №9 END
            'End If
            '2016/02/17 H.Mori del 2015改善開発 №9 END
            '--- ↑2007/07/31 ADD T.Watabe↑ ---

            '2016/02/17 H.Mori add 2015改善開発 №9 
            pstrSQL.Append("ORDER BY KURACD,CODE,TANCD")
        End If


        '2016/02/17 H.Mori del START M05_TANTO2 → M09JAGROUP 
        '' ▼▼▼ 2013/07/01 T.Ono add 顧客単位登録機能追加 ▼▼▼
        ''JA支所担当者の場合は、M05_TANTO2(顧客単位登録マスタ)からもデータを取得する
        'If hdnKEY_KBN.Value = "1" Then     'hdnKEY_KBN　1:JA支所/2:監視センター/3:出動会社
        '    pstrSQL.Append("UNION ALL ")
        '    pstrSQL.Append("SELECT ")
        '    pstrSQL.Append("      TA.KBN, ")
        '    pstrSQL.Append("      TA.KURACD, ")
        '    pstrSQL.Append("      TA.CODE, ")
        '    pstrSQL.Append("      JA.JAS_NAME, ")
        '    pstrSQL.Append("      NULL AS KANSI_NAME, ")
        '    pstrSQL.Append("      NULL AS KAISYA_NAME, ")
        '    pstrSQL.Append("      TA.TANCD, ")
        '    pstrSQL.Append("      TA.TANNM, ")
        '    pstrSQL.Append("      TA.RENTEL1, ")
        '    pstrSQL.Append("      TA.RENTEL2, ")
        '    pstrSQL.Append("      TA.FAXNO, ")
        '    pstrSQL.Append("      TA.DISP_NO, ")
        '    pstrSQL.Append("      TA.BIKO, ")
        '    pstrSQL.Append("      TA.ADD_DATE, ")
        '    pstrSQL.Append("      TA.EDT_DATE, ")
        '    pstrSQL.Append("      TA.USER_CD_FROM, ")
        '    pstrSQL.Append("      TA.USER_CD_TO, ")
        '    pstrSQL.Append("      TA.AUTO_FAXNO, ")
        '    pstrSQL.Append("      TA.RENTEL3, ")
        '    pstrSQL.Append("      '02' AS NO, ")   '顧客単位の登録と区別
        '    pstrSQL.Append("      '02' AS NO2 ")   'クライアントのみの登録と区別
        '    pstrSQL.Append("FROM  M05_TANTO2 TA, ")
        '    pstrSQL.Append("      HN2MAS JA, ")
        '    pstrSQL.Append("      CLIMAS CL ")
        '    pstrSQL.Append("WHERE TA.KURACD = JA.CLI_CD(+) ")
        '    pstrSQL.Append("  AND TA.KURACD = CL.CLI_CD(+) ")
        '    pstrSQL.Append("  AND TA.CODE = JA.HAN_CD(+) ")
        '    pstrSQL.Append("  AND TA.KBN='3' ")
        '    If hdnBackUrl.Value <> "EIGYOU" Then
        '        pstrSQL.Append("  AND CL.KANSI_CODE IN (" & strCenter & ") ")
        '    End If

        '    'M05_TANTO KBN      【区分】                1:監視センター担当者　2:出動会社担当者 3:JA支所担当者
        '    'M05_TANTO KURACD   【クライアントコード】  JA支所の場合クライアントコード、その他の場合、ALL「Z」をセット
        '    'M05_TANTO CODE     【コード】              監視センターコードまたは出動会社コードまたはJA支所コード

        '    If hdnKEY_KURACD.Value.Trim <> "" Then 'クライアントコード
        '        pstrSQL.Append("  AND TA.KURACD = '" & hdnKEY_KURACD.Value.Trim & "' ")
        '    End If
        '    If hdnKEY_CODE.Value.Trim <> "" Then 'コード
        '        pstrSQL.Append("  AND TA.CODE = '" & hdnKEY_CODE.Value.Trim & "' ")
        '    End If
        '    If hdnKEY_JACD.Value <> "" Then 'JAコード(前方一致)
        '        pstrSQL.Append("  AND TA.CODE LIKE '" & hdnKEY_JACD.Value & "%' ")
        '    End If
        '    '2015/11/02 w.ganeko 2015改善開発 №9 start
        '    If hdnKEY_TANTOTEL.Value <> "" Then
        '        pstrSQL.Append("  AND ( ")
        '        pstrSQL.Append("  TA.RENTEL1 = '" & hdnKEY_TANTOTEL.Value & "' ")
        '        pstrSQL.Append("  OR TA.RENTEL2 = '" & hdnKEY_TANTOTEL.Value & "' ")
        '        pstrSQL.Append("  OR TA.RENTEL3 = '" & hdnKEY_TANTOTEL.Value & "' ")
        '        pstrSQL.Append("  ) ")
        '    End If
        '    '2015/11/02 w.ganeko 2015改善開発 №9 end
        'End If
        '' ▲▲▲ 2013/07/01 T.Ono add 顧客単位登録機能追加 ▲▲▲
        '2016/02/17 H.Mori del START M05_TANTO2 → M09JAGROUP 

        '2016/02/17 H.Mori add 2015改善開発 №9 START
        If hdnKEY_KBN.Value = "1" Then     'hdnKEY_KBN　1:JA支所/2:監視センター/3:出動会社
            pstrSQL.Append("SELECT DISTINCT ")
            pstrSQL.Append("      ' ' AS KBN, ")
            pstrSQL.Append("      NVL(M09.KURACD,'ZZZZ') KURACD, ")
            pstrSQL.Append("      M11.GROUPCD, ")
            'pstrSQL.Append("      M11.GROUPNM, ")'2016/03/24 T.Ono mod 2015改善開発
            pstrSQL.Append("      NVL(M11.GROUPNM, M11B.GROUPNM) AS GROUPNM,  ")
            pstrSQL.Append("      M11.TANCD, ")
            pstrSQL.Append("      M11.TANNM, ")
            pstrSQL.Append("      M11.RENTEL1, ")
            pstrSQL.Append("      M11.RENTEL2, ")
            pstrSQL.Append("      M11.RENTEL3, ")
            pstrSQL.Append("      M11.FAXNO, ")
            pstrSQL.Append("      M11.BIKO, ")
            pstrSQL.Append("      TO_CHAR(M11.INS_DATE,'YYYYMMDD') AS ADD_DATE, ")
            pstrSQL.Append("      TO_CHAR(M11.UPD_DATE,'YYYYMMDD') AS EDT_DATE, ")
            pstrSQL.Append("      M11.AUTO_FAXNO ")
            pstrSQL.Append("FROM  M09_JAGROUP M09, ")
            pstrSQL.Append("      M11_JAHOKOKU M11, ")
            pstrSQL.Append("      M11_JAHOKOKU M11B, ")
            pstrSQL.Append("      HN2MAS JA, ")
            pstrSQL.Append("      CLIMAS CL ")
            pstrSQL.Append("WHERE M09.KURACD = JA.CLI_CD(+) ")
            pstrSQL.Append("  AND M09.ACBCD = JA.HAN_CD(+) ")
            pstrSQL.Append("  AND M09.KBN(+) = '002' ")
            pstrSQL.Append("  AND M11.KBN(+) = '2' ")
            pstrSQL.Append("  AND M09.GROUPCD(+) = M11.GROUPCD ")
            pstrSQL.Append("  AND M11.GROUPCD = M11B.GROUPCD ")      '2016/03/24 T.Ono add 2015改善開発
            pstrSQL.Append("  AND M11.KBN = M11B.KBN ")              '2016/03/24 T.Ono add 2015改善開発
            pstrSQL.Append("  AND LPAD(M11B.TANCD, 2, '0') = '01' ") '2016/03/24 T.Ono add 2015改善開発
            If hdnBackUrl.Value <> "EIGYOU" Then
                pstrSQL.Append("  AND CL.KANSI_CODE IN (" & strCenter & ") ")
            End If
            If hdnKEY_KURACD.Value.Trim <> "" Then 'クライアントコード
                pstrSQL.Append("  AND M09.KURACD = '" & hdnKEY_KURACD.Value.Trim & "' ")
            End If
            If hdnKEY_CODE.Value.Trim <> "" Then 'JA支所コード
                pstrSQL.Append("  AND M09.ACBCD = '" & hdnKEY_CODE.Value.Trim & "' ")
            End If
            If hdnKEY_GROUPCD.Value.Trim <> "" Then 'グループコード・名称
                pstrSQL.Append("  AND M11.GROUPCD = '" & hdnKEY_GROUPCD.Value.Trim & "' ")
            End If
            If hdnKEY_JACD.Value <> "" Then 'JAコード(前方一致)
                pstrSQL.Append("  AND M09.ACBCD LIKE '" & hdnKEY_JACD.Value & "%' ")
            End If
            If hdnKEY_TANTOTEL.Value <> "" Then 'ＪＡ・担当者連絡先(前方一致)
                pstrSQL.Append("  AND ( ")
                pstrSQL.Append("  REPLACE(REPLACE(M11.RENTEL1,'-',''), ' ','') ")
                pstrSQL.Append("  LIKE REPLACE('" & hdnKEY_TANTOTEL.Value & "','-','') || '%' ")
                pstrSQL.Append("  OR REPLACE(REPLACE(M11.RENTEL2,'-',''), ' ','') ")
                pstrSQL.Append("  LIKE REPLACE('" & hdnKEY_TANTOTEL.Value & "','-','') || '%' ")
                pstrSQL.Append("  OR REPLACE(REPLACE(M11.RENTEL3,'-',''), ' ','') ")
                '2016/03/24 T.Ono add 2015改善開発 監視廣田様からFAXも検索してほしいとの要望
                pstrSQL.Append("  LIKE REPLACE('" & hdnKEY_TANTOTEL.Value & "','-','') || '%' ")
                pstrSQL.Append("  OR REPLACE(REPLACE(M11.FAXNO,'-',''), ' ','')  ")
                pstrSQL.Append("  LIKE REPLACE('" & hdnKEY_TANTOTEL.Value & "','-','') || '%' ")
                pstrSQL.Append("  OR REPLACE(REPLACE(M11.AUTO_FAXNO,'-',''), ' ','')  ")
                pstrSQL.Append("  LIKE REPLACE('" & hdnKEY_TANTOTEL.Value & "','-','') || '%' ")
                pstrSQL.Append("  ) ")
            End If
            pstrSQL.Append("ORDER BY KURACD,GROUPCD,TANCD")
        End If
        '2016/02/17 H.Mori add 2015改善開発 №9 END

        ' 2013/07/01 T.Ono mod 
        ''--- ↓2005/07/19 MOD Falcon↓ ---
        ''pstrSQL.Append("ORDER BY KBN,CODE")
        'pstrSQL.Append("ORDER BY KBN,KURACD,CODE,TANCD")
        ''--- ↑2005/07/19 MOD Falcon↑ ---

        '2016/02/17 H.Mori del 2015改善開発 №9
        'pstrSQL.Append("ORDER BY KBN,NO2,KURACD,CODE,NO,USER_CD_TO,USER_CD_FROM,TANCD")

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
