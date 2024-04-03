'******************************************************************************
' ポップアップ (呼び出し部)
'******************************************************************************
' 変更履歴
' 2010/03/30 T.Watabe MSTAEJAG「ＪＡ担当者連絡先エクセル出力」用に設定を追加

Option Explicit On
Option Strict On

Imports Common

Imports System.Text

'******************************************************************************
' ポップアップ (呼び出し部)
'******************************************************************************

Partial Class COPOPUPG00
    Inherits System.Web.UI.Page
    'システム項目
    Protected strListName As String

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

    '------------------------------------------------------------------------------
    '<TODO>機能追加時に対象のプロジェクトを追加していく
    Protected MSTANJAG00_C As MSTANJAG00.MSTANJAG00         '担当者マスタ
    Protected MSPULJAG00_C As MSPULJAG00.MSPULJAG00         'プルダウンマスタ
    Protected KETAIJAG00_C As KETAIJAG00.KETAIJAG00         '対応入力
    Protected KERUIJOG00_C As KERUIJOG00.KERUIJOG00         '累積情報一覧
    Protected KEKEKJAG00_C As KEKEKJAG00.KEKEKJAG00         '対応結果一覧
    Protected MSKOSJAG00_C As MSKOSJAG00.MSKOSJAG00         '顧客検索
    '/* 2006/05/25 ADD_BEGIN */
    Protected KETAISYG00_C As KETAISYG00.KETAISYG00         '警報出力
    '/* 2006/05/25 ADD_END */
    Protected MSTASJAG00_C As MSTASJAG00.MSTASJAG00         '担当者一覧 '/* 2008/07/31 ADD_BEGIN */
    Protected MSTAJJAG00_C As MSTAJJAG00.MSTAJJAG00         'JA担当者マスタ ' 2008/11/07 T.Watabe add
    Protected KEKANSYG00_C As KEKANSYG00.KEKANSYG00         '監視対応数集計表 ' 2008/11/20 T.Watabe add
    Protected MSTAEJAG00_C As MSTAEJAG00.MSTAEJAG00         'JA担当者連絡先   '2012/05/11 NEC ou Add
    Protected MSKYOJAG00_C As MSKYOJAG00.MSKYOJAG00         '供給センターマスタ '2014/01/30 W.GANEKO Add
    Protected MSRUIJAG00_C As MSRUIJAG00.MSRUIJAG00         '累積情報自動FAXマスタ '2014/02/06 W.GANEKO Add
    Protected MSTAKJAG00_C As MSTAKJAG00.MSTAKJAG00         '監視センター担当者マスタ ' 2014/02/07 T.Ono add
    Protected MSTALJAG00_C As MSTALJAG00.MSTALJAG00         '出動会社担当者マスタ ' 2014/02/13 T.Ono add
    Protected MSJIGJAG00_C As MSJIGJAG00.MSJIGJAG00         '自動対応グループマスタ ' 2014/02/21 T.Ono add
    Protected MSJAGJAG00_C As MSJAGJAG00.MSJAGJAG00         'JAグループ作成マスタ ' 2014/10/03 T.Ono add 2014改善開発 No19
    Protected MSHAGJAG00_C As MSHAGJAG00.MSHAGJAG00         '販売事業者グループマスタ ' 2014/10/03 T.Ono add 2014改善開発 No19
    Protected MSTAGJAG00_C As MSTAGJAG00.MSTAGJAG00         'JA担当者・連絡先・注意事項マスタ ' 2015/11/04 T.Ono add 2015改善開発 №7
    Protected MSTAHJAG00_C As MSTAHJAG00.MSTAHJAG00         'JA担当者連絡先(JA報告先マスタ参照) '2015/12/15 T.Ono add 2015改善開発 №7
    Protected MSJINJAG00_C As MSJINJAG00.MSJINJAG00         '自動対応グループ作成マスタ ' 2017/02/09 W.Ganeko add 2016改善開発 No10
    Protected SBMEOJAG00_C As SBMEOJAG00.SBMEOJAG00         '一般消費者名簿出力　2019/01/10 T.Ono add 2018改善開発
    Protected MSHATJAG00_C As MSHATJAG00.MSHATJAG00         '販売店グループマスタ　2019/01/24 T.Ono add 2018改善開発
    Protected KESAIJAG00_C As KESAIJAG00.KESAIJAG00         '災害対応帳票　2019/11/01 T.Ono add 監視改善2019

    '-----------------------------------------------------------------------

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
        'Iframe出力
        If hdnKensaku.Value = "COPOPUFG00" Then
            Server.Transfer("COPOPUFG00.aspx")
        End If

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
        '<ポップアップ用関数>
        '--- ↓2012/02/16 UPD NEC↓  ---
        'strScript.Append(cscript1.mWriteScript(MyBase.MapPath("../../../Popup/") & "COPOPUPG00.js"))
        strScript.Append(cscript1.mWriteScript(MyBase.MapPath("../../JPG/Popup/") & "COPOPUPG00.js"))
        '--- ↓2012/02/16 UPD NEC↓  ---
        '<フォーカス関連関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncFo.js"))
        '<入力チェック関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncChk.js"))
        strScript.Append("</Script>")
        '//------------------------------------------
        '//　Css格納
        strScript.Append("<Style>")
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "CssPopup.css"))
        strScript.Append("</Style>")
        '//------------------------------------------
        '//　Script書込み
        lblScript.Text = strScript.ToString

        '------------------------------------------------------------------------------
        '<TODO>機能追加時に対象のプロジェクトを追加していく
        ''担当者マスタ
        If Request.Path.LastIndexOf("MSTANJAG00") >= 0 Then
            MSTANJAG00_C = CType(Context.Handler, MSTANJAG00.MSTANJAG00)
            strListName = MSTANJAG00_C.pListName
            hdnListCd.Value = MSTANJAG00_C.pListCd
            hdnCode1.Value = MSTANJAG00_C.pCode1
            hdnBackCode.Value = MSTANJAG00_C.pBackCode
            hdnBackName.Value = MSTANJAG00_C.pBackName
            hbdBackFocs.Value = MSTANJAG00_C.pBackFocs
            hdnClear1.Value = MSTANJAG00_C.pClear1
            hdnClear2.Value = MSTANJAG00_C.pClear2
        End If
        ''プルダウンマスタ
        If Request.Path.LastIndexOf("MSPULJAG00") >= 0 Then
            MSPULJAG00_C = CType(Context.Handler, MSPULJAG00.MSPULJAG00)
            strListName = MSPULJAG00_C.pListName
            hdnListCd.Value = MSPULJAG00_C.pListCd
            hdnCode1.Value = MSPULJAG00_C.pCode1
            hdnBackCode.Value = MSPULJAG00_C.pBackCode
            hdnBackName.Value = MSPULJAG00_C.pBackName
            hbdBackFocs.Value = MSPULJAG00_C.pBackFocs
            hdnClear1.Value = MSPULJAG00_C.pClear1
        End If
        '対応入力
        If Request.Path.LastIndexOf("KETAIJAG00") >= 0 Then
            KETAIJAG00_C = CType(Context.Handler, KETAIJAG00.KETAIJAG00)
            strListName = KETAIJAG00_C.pListName
            hdnListCd.Value = KETAIJAG00_C.pListCd
            hdnCode1.Value = KETAIJAG00_C.pCode1
            hdnBackCode.Value = KETAIJAG00_C.pBackCode
            hdnBackName.Value = KETAIJAG00_C.pBackName
            hbdBackFocs.Value = KETAIJAG00_C.pBackFocs
            hbdBackScript.Value = KETAIJAG00_C.pBackScript
            hdnClear1.Value = KETAIJAG00_C.pClear1
            hdnClear2.Value = KETAIJAG00_C.pClear2
            hdnClear3.Value = KETAIJAG00_C.pClear3
            hdnClear4.Value = KETAIJAG00_C.pClear4
        End If
        ''累積情報一覧
        If Request.Path.LastIndexOf("KERUIJOG00") >= 0 Then
            KERUIJOG00_C = CType(Context.Handler, KERUIJOG00.KERUIJOG00)
            strListName = KERUIJOG00_C.pListName
            hdnListCd.Value = KERUIJOG00_C.pListCd
            hdnCode1.Value = KERUIJOG00_C.pCode1
            hdnCode2.Value = KERUIJOG00_C.pCode2
            hdnBackCode.Value = KERUIJOG00_C.pBackCode
            hdnBackName.Value = KERUIJOG00_C.pBackName
            hbdBackFocs.Value = KERUIJOG00_C.pBackFocs
            hbdBackScript.Value = KERUIJOG00_C.pBackScript      '2019/11/01 T.Ono add 監視改善2019
            hdnClear1.Value = Convert.ToString(KERUIJOG00_C.pClearCode.Split(Convert.ToChar(",")).GetValue(0))
            hdnClear2.Value = Convert.ToString(KERUIJOG00_C.pClearName.Split(Convert.ToChar(",")).GetValue(0))
            If KERUIJOG00_C.pClearCode.Split(Convert.ToChar(",")).Length > 1 Then
                hdnClear3.Value = Convert.ToString(KERUIJOG00_C.pClearCode.Split(Convert.ToChar(",")).GetValue(1))
                hdnClear4.Value = Convert.ToString(KERUIJOG00_C.pClearName.Split(Convert.ToChar(",")).GetValue(1))
            End If
            If KERUIJOG00_C.pClearCode.Split(Convert.ToChar(",")).Length > 2 Then
                hdnClear5.Value = Convert.ToString(KERUIJOG00_C.pClearCode.Split(Convert.ToChar(",")).GetValue(2))
                hdnClear6.Value = Convert.ToString(KERUIJOG00_C.pClearName.Split(Convert.ToChar(",")).GetValue(2))
            End If
            '2015/11/04 w.ganeko 2015改善開発 №6 START
            If KERUIJOG00_C.pClearCode.Split(Convert.ToChar(",")).Length > 3 Then
                hdnClear7.Value = Convert.ToString(KERUIJOG00_C.pClearCode.Split(Convert.ToChar(",")).GetValue(3))
                hdnClear8.Value = Convert.ToString(KERUIJOG00_C.pClearName.Split(Convert.ToChar(",")).GetValue(3))
            End If
            If KERUIJOG00_C.pClearCode.Split(Convert.ToChar(",")).Length > 4 Then
                hdnClear9.Value = Convert.ToString(KERUIJOG00_C.pClearCode.Split(Convert.ToChar(",")).GetValue(4))
                hdnClear10.Value = Convert.ToString(KERUIJOG00_C.pClearName.Split(Convert.ToChar(",")).GetValue(4))
            End If
            If KERUIJOG00_C.pClearCode.Split(Convert.ToChar(",")).Length > 5 Then
                hdnClear11.Value = Convert.ToString(KERUIJOG00_C.pClearCode.Split(Convert.ToChar(",")).GetValue(5))
                hdnClear12.Value = Convert.ToString(KERUIJOG00_C.pClearName.Split(Convert.ToChar(",")).GetValue(5))
            End If
            If KERUIJOG00_C.pClearCode.Split(Convert.ToChar(",")).Length > 6 Then
                hdnClear13.Value = Convert.ToString(KERUIJOG00_C.pClearCode.Split(Convert.ToChar(",")).GetValue(6))
                hdnClear14.Value = Convert.ToString(KERUIJOG00_C.pClearName.Split(Convert.ToChar(",")).GetValue(6))
            End If
            '2015/11/04 w.ganeko 2015改善開発 №6 END
        End If
        ''対応変更一覧
        If Request.Path.LastIndexOf("KEKEKJAG00") >= 0 Then
            KEKEKJAG00_C = CType(Context.Handler, KEKEKJAG00.KEKEKJAG00)
            strListName = KEKEKJAG00_C.pListName
            hdnListCd.Value = KEKEKJAG00_C.pListCd
            hdnCode1.Value = KEKEKJAG00_C.pCode1
            hdnCode2.Value = KEKEKJAG00_C.pCode2            '2013/12/10 T.Ono add 監視改善2013
            hdnCode3.Value = KEKEKJAG00_C.pCode3            '2014/12/08 H.Hosoda add 監視改善2014 No.7
            hdnCode4.Value = KEKEKJAG00_C.pCode4            '2016/11/25 H.Mori add 監視改善2016 No3-1
            hdnBackCode.Value = KEKEKJAG00_C.pBackCode
            hdnBackName.Value = KEKEKJAG00_C.pBackName
            hdnBackCode2.Value = KEKEKJAG00_C.pBackCode2    '2019/11/01 T.Ono add 監視改善2019
            hbdBackFocs.Value = KEKEKJAG00_C.pBackFocs
            hbdBackScript.Value = KEKEKJAG00_C.pBackScript  '2013/12/10 T.Ono add 監視改善2013
            hdnClear1.Value = KEKEKJAG00_C.pClear1
            hdnClear2.Value = KEKEKJAG00_C.pClear2
            hdnClear3.Value = KEKEKJAG00_C.pClear3          '2013/12/10 T.Ono add 監視改善2013
            hdnClear4.Value = KEKEKJAG00_C.pClear4          '2013/12/10 T.Ono add 監視改善2013
            hdnClear5.Value = KEKEKJAG00_C.pClear5          '2014/12/08 H.Hosoda add 監視改善2014 No.7
            hdnClear6.Value = KEKEKJAG00_C.pClear6          '2014/12/08 H.Hosoda add 監視改善2014 No.7
            hdnClear7.Value = KEKEKJAG00_C.pClear7          '2016/11/25 H.Mori add 監視改善2016 No3-1
            hdnClear8.Value = KEKEKJAG00_C.pClear8          '2016/11/25 H.Mori add 監視改善2016 No3-1
            hdnClear9.Value = KEKEKJAG00_C.pClear9          '2019/11/01 T.Ono add 監視改善2019
        End If
        ''顧客検索
        If Request.Path.LastIndexOf("MSKOSJAG00") >= 0 Then
            MSKOSJAG00_C = CType(Context.Handler, MSKOSJAG00.MSKOSJAG00)
            strListName = MSKOSJAG00_C.pListName
            hdnListCd.Value = MSKOSJAG00_C.pListCd
            hdnCode1.Value = MSKOSJAG00_C.pCode1
            hdnCode2.Value = MSKOSJAG00_C.pCode2          '2013/12/09 T.Ono add 監視改善2013
            hdnCode3.Value = MSKOSJAG00_C.pCode3          '2014/12/04 H.Hosoda add 監視改善2014 No.6
            hdnCode4.Value = MSKOSJAG00_C.pCode4          '2016/11/21 H.Mori add 監視改善2016 No2-1
            hdnBackCode.Value = MSKOSJAG00_C.pBackCode
            hdnBackName.Value = MSKOSJAG00_C.pBackName
            hdnBackCode2.Value = MSKOSJAG00_C.pBackCode2  '2019/11/01 T.Ono add 監視改善2019
            hbdBackFocs.Value = MSKOSJAG00_C.pBackFocs
            hbdBackScript.Value = MSKOSJAG00_C.pBackScript '2019/11/01 T.Ono add 監視改善2019
            hdnClear1.Value = MSKOSJAG00_C.pClear1
            hdnClear2.Value = MSKOSJAG00_C.pClear2
            hdnClear3.Value = MSKOSJAG00_C.pClear3        '2013/12/09 T.Ono add 監視改善2013
            hdnClear4.Value = MSKOSJAG00_C.pClear4        '2013/12/09 T.Ono add 監視改善2013
            hdnClear5.Value = MSKOSJAG00_C.pClear5        '2014/12/04 H.Hosoda add 監視改善2014 No.6
            hdnClear6.Value = MSKOSJAG00_C.pClear6        '2014/12/04 H.Hosoda add 監視改善2014 No.6
            hdnClear7.Value = MSKOSJAG00_C.pClear7        '2016/11/17 H.Mori add 監視改善2016 No2-1
            hdnClear8.Value = MSKOSJAG00_C.pClear8        '2016/11/17 H.Mori add 監視改善2016 No2-1
            hdnClear9.Value = MSKOSJAG00_C.pClear9        '2016/11/24 H.Mori add 監視改善2016 No2-2
            hdnClear10.Value = MSKOSJAG00_C.pClear10        '2016/11/24 H.Mori add 監視改善2016 No2-2
            hdnClear11.Value = MSKOSJAG00_C.pClear11        '2019/11/01 T.Ono add 監視改善2019 No1
            hdnClear12.Value = MSKOSJAG00_C.pClear12        '2019/11/01 T.Ono add 監視改善2019 No1
            hdnClear13.Value = MSKOSJAG00_C.pClear13        '2019/11/01 T.Ono add 監視改善2019 No1
        End If
        '/* 2006/05/25 ADD_BEGIN */
        ''警報出力
        If Request.Path.LastIndexOf("KETAISYG00") >= 0 Then
            KETAISYG00_C = CType(Context.Handler, KETAISYG00.KETAISYG00)
            strListName = KETAISYG00_C.pListName
            hdnListCd.Value = KETAISYG00_C.pListCd
            hdnCode1.Value = KETAISYG00_C.pCode1
            '2019/11/01 T.Ono mod 監視改善2019 START
            hdnBackCode.Value = KETAISYG00_C.pBackCode
            hdnBackName.Value = KETAISYG00_C.pBackName
            hdnBackCode2.Value = KETAISYG00_C.pBackCode2        '2019/11/01 T.Ono mod 監視改善2019
            hbdBackFocs.Value = KETAISYG00_C.pBackFocs
            hbdBackScript.Value = KETAISYG00_C.pBackScript      '2019/11/01 T.Ono add 監視改善2019
            ' 2008/11/11 T.Watabe add
            hdnClear1.Value = Convert.ToString(KETAISYG00_C.pClearCode.Split(Convert.ToChar(",")).GetValue(0))
            hdnClear2.Value = Convert.ToString(KETAISYG00_C.pClearName.Split(Convert.ToChar(",")).GetValue(0))
            If KETAISYG00_C.pClearCode.Split(Convert.ToChar(",")).Length > 1 Then
                hdnClear3.Value = Convert.ToString(KETAISYG00_C.pClearCode.Split(Convert.ToChar(",")).GetValue(1))
                hdnClear4.Value = Convert.ToString(KETAISYG00_C.pClearName.Split(Convert.ToChar(",")).GetValue(1))
            End If
            If KETAISYG00_C.pClearCode.Split(Convert.ToChar(",")).Length > 2 Then
                hdnClear5.Value = Convert.ToString(KETAISYG00_C.pClearCode.Split(Convert.ToChar(",")).GetValue(2))
                hdnClear6.Value = Convert.ToString(KETAISYG00_C.pClearName.Split(Convert.ToChar(",")).GetValue(2))
            End If
            '2014/12/11 H.Hosoda add 監視改善2014 No.13 START
            If KETAISYG00_C.pClearCode.Split(Convert.ToChar(",")).Length > 3 Then
                hdnClear7.Value = Convert.ToString(KETAISYG00_C.pClearCode.Split(Convert.ToChar(",")).GetValue(3))
                hdnClear8.Value = Convert.ToString(KETAISYG00_C.pClearName.Split(Convert.ToChar(",")).GetValue(3))
            End If
            '2014/12/11 H.Hosoda add 監視改善2014 No.13 END
        End If
        '/* 2006/05/25 ADD_END */

        '/* 2008/07/31 ADD_BEGIN */
        ''担当者一覧
        If Request.Path.LastIndexOf("MSTASJAG00") >= 0 Then
            MSTASJAG00_C = CType(Context.Handler, MSTASJAG00.MSTASJAG00)
            strListName = MSTASJAG00_C.pListName
            hdnListCd.Value = MSTASJAG00_C.pListCd
            hdnCode1.Value = MSTASJAG00_C.pCode1
            hdnCode2.Value = MSTASJAG00_C.pCode2    '2016/02/15 H.Mori add 2015改善開発 №9
            hdnCode3.Value = MSTASJAG00_C.pCode3    '2016/02/15 H.Mori add 2015改善開発 №9
            hdnBackCode.Value = MSTASJAG00_C.pBackCode
            hdnBackName.Value = MSTASJAG00_C.pBackName
            hbdBackFocs.Value = MSTASJAG00_C.pBackFocs
            hdnClear1.Value = MSTASJAG00_C.pClear1
            hdnClear2.Value = MSTASJAG00_C.pClear2
            hdnClear3.Value = MSTASJAG00_C.pClear3  '2016/02/16 H.Mori add 2015改善開発 №9
            hdnClear4.Value = MSTASJAG00_C.pClear4  '2016/02/16 H.Mori add 2015改善開発 №9
        End If
        '/* 2008/07/31 ADD_END */

        'JA担当者マスタ 2008/11/07 T.Watabe add
        If Request.Path.LastIndexOf("MSTAJJAG00") >= 0 Then
            MSTAJJAG00_C = CType(Context.Handler, MSTAJJAG00.MSTAJJAG00)
            strListName = MSTAJJAG00_C.pListName
            hdnListCd.Value = MSTAJJAG00_C.pListCd
            hdnCode1.Value = MSTAJJAG00_C.pCode1
            hdnCode2.Value = MSTAJJAG00_C.pCode2           ' 2015/02/18 T.Ono add 2014改善開発 No15
            hdnBackCode.Value = MSTAJJAG00_C.pBackCode
            hdnBackName.Value = MSTAJJAG00_C.pBackName
            hdnBackCode2.Value = MSTAJJAG00_C.pBackCode2   ' 2015/02/18 T.Ono add 2014改善開発 No15
            hdnBackName2.Value = MSTAJJAG00_C.pBackName2   ' 2015/02/18 T.Ono add 2014改善開発 No15
            hbdBackFocs.Value = MSTAJJAG00_C.pBackFocs
            hbdBackScript.Value = MSTAJJAG00_C.pBackScript ' 2013/12/13 T.Ono add 監視改善2013
            hdnClear1.Value = MSTAJJAG00_C.pClear1
            hdnClear2.Value = MSTAJJAG00_C.pClear2
            hdnClear3.Value = MSTAJJAG00_C.pClear3  ' 2013/07/04 T.Ono add
            hdnClear4.Value = MSTAJJAG00_C.pClear4  ' 2013/07/04 T.Ono add
            hdnClear5.Value = MSTAJJAG00_C.pClear5  ' 2013/07/04 T.Ono add
        End If

        '監視対応数集計表 2008/11/20 T.Watabe add
        If Request.Path.LastIndexOf("KEKANSYG00") >= 0 Then
            KEKANSYG00_C = CType(Context.Handler, KEKANSYG00.KEKANSYG00)
            strListName = KEKANSYG00_C.pListName
            hdnListCd.Value = KEKANSYG00_C.pListCd
            hdnCode1.Value = KEKANSYG00_C.pCode1
            hdnCode2.Value = KEKANSYG00_C.pCode2
            hdnBackCode.Value = KEKANSYG00_C.pBackCode
            hdnBackName.Value = KEKANSYG00_C.pBackName
            hbdBackFocs.Value = KEKANSYG00_C.pBackFocs
            hbdBackScript.Value = KEKANSYG00_C.pBackScript  '2015/02/10 H.Hosoda add 監視改善2014 No.14
            hdnClear1.Value = Convert.ToString(KEKANSYG00_C.pClearCode.Split(Convert.ToChar(",")).GetValue(0))
            hdnClear2.Value = Convert.ToString(KEKANSYG00_C.pClearName.Split(Convert.ToChar(",")).GetValue(0))
            If KEKANSYG00_C.pClearCode.Split(Convert.ToChar(",")).Length > 1 Then
                hdnClear3.Value = Convert.ToString(KEKANSYG00_C.pClearCode.Split(Convert.ToChar(",")).GetValue(1))
                hdnClear4.Value = Convert.ToString(KEKANSYG00_C.pClearName.Split(Convert.ToChar(",")).GetValue(1))
            End If
            If KEKANSYG00_C.pClearCode.Split(Convert.ToChar(",")).Length > 2 Then
                hdnClear5.Value = Convert.ToString(KEKANSYG00_C.pClearCode.Split(Convert.ToChar(",")).GetValue(2))
                hdnClear6.Value = Convert.ToString(KEKANSYG00_C.pClearName.Split(Convert.ToChar(",")).GetValue(2))
            End If
            '2015/02/09 H.Hosoda add 監視改善2014 No.14 START
            If KEKANSYG00_C.pClearCode.Split(Convert.ToChar(",")).Length > 3 Then
                hdnClear7.Value = Convert.ToString(KEKANSYG00_C.pClearCode.Split(Convert.ToChar(",")).GetValue(3))
                hdnClear8.Value = Convert.ToString(KEKANSYG00_C.pClearName.Split(Convert.ToChar(",")).GetValue(3))
            End If
            '2015/02/09 H.Hosoda add 監視改善2014 No.14 END
        End If
        ' ＪＡ担当者連絡先エクセル出力 2010/03/30 T.Watabe add
        If Request.Path.LastIndexOf("KEKANSYG00") >= 0 Then
            KEKANSYG00_C = CType(Context.Handler, KEKANSYG00.KEKANSYG00)
            strListName = KEKANSYG00_C.pListName
            hdnListCd.Value = KEKANSYG00_C.pListCd
            hdnCode1.Value = KEKANSYG00_C.pCode1
            hdnCode2.Value = KEKANSYG00_C.pCode2
            hdnBackCode.Value = KEKANSYG00_C.pBackCode
            hdnBackName.Value = KEKANSYG00_C.pBackName
            hbdBackFocs.Value = KEKANSYG00_C.pBackFocs
            hdnClear1.Value = Convert.ToString(KEKANSYG00_C.pClearCode.Split(Convert.ToChar(",")).GetValue(0))
            hdnClear2.Value = Convert.ToString(KEKANSYG00_C.pClearName.Split(Convert.ToChar(",")).GetValue(0))
            If KEKANSYG00_C.pClearCode.Split(Convert.ToChar(",")).Length > 1 Then
                hdnClear3.Value = Convert.ToString(KEKANSYG00_C.pClearCode.Split(Convert.ToChar(",")).GetValue(1))
                hdnClear4.Value = Convert.ToString(KEKANSYG00_C.pClearName.Split(Convert.ToChar(",")).GetValue(1))
            End If
            If KEKANSYG00_C.pClearCode.Split(Convert.ToChar(",")).Length > 2 Then
                hdnClear5.Value = Convert.ToString(KEKANSYG00_C.pClearCode.Split(Convert.ToChar(",")).GetValue(2))
                hdnClear6.Value = Convert.ToString(KEKANSYG00_C.pClearName.Split(Convert.ToChar(",")).GetValue(2))
            End If
        End If
        '2012/05/11 NEC ou Add Str
        'ＪＡ担当者連絡先エクセル出力
        If Request.Path.LastIndexOf("MSTAEJAG00") >= 0 Then
            MSTAEJAG00_C = CType(Context.Handler, MSTAEJAG00.MSTAEJAG00)
            strListName = MSTAEJAG00_C.pListName
            hdnListCd.Value = MSTAEJAG00_C.pListCd
            hdnCode1.Value = MSTAEJAG00_C.pCode1
            hdnBackCode.Value = MSTAEJAG00_C.pBackCode
            hdnBackName.Value = MSTAEJAG00_C.pBackName
            hbdBackFocs.Value = MSTAEJAG00_C.pBackFocs
            hdnClear1.Value = MSTAEJAG00_C.pClearCode
            hdnClear2.Value = MSTAEJAG00_C.pClearName
        End If
        '2012/05/11 NEC ou Add End
        '供給センターマスタ 2014/01/30 W.GANEKO add
        If Request.Path.LastIndexOf("MSKYOJAG00") >= 0 Then
            MSKYOJAG00_C = CType(Context.Handler, MSKYOJAG00.MSKYOJAG00)
            strListName = MSKYOJAG00_C.pListName
            hdnListCd.Value = MSKYOJAG00_C.pListCd
            hdnCode1.Value = MSKYOJAG00_C.pCode1
            hdnBackCode.Value = MSKYOJAG00_C.pBackCode
            hdnBackName.Value = MSKYOJAG00_C.pBackName
            hbdBackFocs.Value = MSKYOJAG00_C.pBackFocs
        End If
        '累積情報自動FAXマスタ 2014/02/07 W.GANEKO add
        If Request.Path.LastIndexOf("MSRUIJAG00") >= 0 Then
            MSRUIJAG00_C = CType(Context.Handler, MSRUIJAG00.MSRUIJAG00)
            strListName = MSRUIJAG00_C.pListName
            hdnListCd.Value = MSRUIJAG00_C.pListCd
            hdnCode1.Value = MSRUIJAG00_C.pCode1
            hdnBackCode.Value = MSRUIJAG00_C.pBackCode
            hdnBackName.Value = MSRUIJAG00_C.pBackName
            hdnBackCode2.Value = MSRUIJAG00_C.pBackCode2
            hdnBackName2.Value = MSRUIJAG00_C.pBackName2
            hbdBackFocs.Value = MSRUIJAG00_C.pBackFocs
            hbdBackScript.Value = MSRUIJAG00_C.pBackScript      '2019/11/01 T.Ono add 監視改善2019
            hdnClear1.Value = MSRUIJAG00_C.pClear1       '20114/03/10 T.Ono add 絞込み条件追加
            hdnClear2.Value = MSRUIJAG00_C.pClear2       '20114/03/10 T.Ono add 絞込み条件追加
            hdnClear3.Value = MSRUIJAG00_C.pClear3       '20114/03/10 T.Ono add 絞込み条件追加
            hdnClear4.Value = MSRUIJAG00_C.pClear4       '20114/03/10 T.Ono add 絞込み条件追加
        End If
        '監視センター担当者マスタ 2014/02/07 T.Ono add
        If Request.Path.LastIndexOf("MSTAKJAG00") >= 0 Then
            MSTAKJAG00_C = CType(Context.Handler, MSTAKJAG00.MSTAKJAG00)
            strListName = MSTAKJAG00_C.pListName
            hdnListCd.Value = MSTAKJAG00_C.pListCd
            hdnCode1.Value = MSTAKJAG00_C.pCode1
            hdnBackCode.Value = MSTAKJAG00_C.pBackCode
            hdnBackName.Value = MSTAKJAG00_C.pBackName
            hbdBackFocs.Value = MSTAKJAG00_C.pBackFocs
            hbdBackScript.Value = MSTAKJAG00_C.pBackScript
            hdnClear1.Value = MSTAKJAG00_C.pClear1
            hdnClear2.Value = MSTAKJAG00_C.pClear2
            hdnClear3.Value = MSTAKJAG00_C.pClear3
            hdnClear4.Value = MSTAKJAG00_C.pClear4
            hdnClear5.Value = MSTAKJAG00_C.pClear5
        End If
        '出動会社担当者マスタ 2014/02/13 T.Ono add
        If Request.Path.LastIndexOf("MSTALJAG00") >= 0 Then
            MSTALJAG00_C = CType(Context.Handler, MSTALJAG00.MSTALJAG00)
            strListName = MSTALJAG00_C.pListName
            hdnListCd.Value = MSTALJAG00_C.pListCd
            hdnCode1.Value = MSTALJAG00_C.pCode1
            hdnBackCode.Value = MSTALJAG00_C.pBackCode
            hdnBackName.Value = MSTALJAG00_C.pBackName
            hbdBackFocs.Value = MSTALJAG00_C.pBackFocs
            hbdBackScript.Value = MSTALJAG00_C.pBackScript
            hdnClear1.Value = MSTALJAG00_C.pClear1
            hdnClear2.Value = MSTALJAG00_C.pClear2
        End If
        '自動対応グループマスタ 2014/02/21 T.Ono add
        If Request.Path.LastIndexOf("MSJIGJAG00") >= 0 Then
            MSJIGJAG00_C = CType(Context.Handler, MSJIGJAG00.MSJIGJAG00)
            strListName = MSJIGJAG00_C.pListName
            hdnListCd.Value = MSJIGJAG00_C.pListCd
            hdnCode1.Value = MSJIGJAG00_C.pCode1
            hdnBackCode.Value = MSJIGJAG00_C.pBackCode
            hdnBackName.Value = MSJIGJAG00_C.pBackName
            hbdBackFocs.Value = MSJIGJAG00_C.pBackFocs
            hbdBackScript.Value = MSJIGJAG00_C.pBackScript
            hdnClear1.Value = MSJIGJAG00_C.pClear1
            hdnClear2.Value = MSJIGJAG00_C.pClear2
            hdnClear3.Value = MSJIGJAG00_C.pClear3
            hdnClear4.Value = MSJIGJAG00_C.pClear4
        End If
        'JAグループ作成マスタ 2014/10/03 T.Ono add 2014改善開発 No19
        If Request.Path.LastIndexOf("MSJAGJAG00") >= 0 Then
            MSJAGJAG00_C = CType(Context.Handler, MSJAGJAG00.MSJAGJAG00)
            strListName = MSJAGJAG00_C.pListName
            hdnListCd.Value = MSJAGJAG00_C.pListCd
            hdnCode1.Value = MSJAGJAG00_C.pCode1
            hdnCode2.Value = MSJAGJAG00_C.pCode2
            hdnBackCode.Value = MSJAGJAG00_C.pBackCode
            hdnBackName.Value = MSJAGJAG00_C.pBackName
            hbdBackFocs.Value = MSJAGJAG00_C.pBackFocs
            hbdBackScript.Value = MSJAGJAG00_C.pBackScript
            hdnClear1.Value = MSJAGJAG00_C.pClear1
            hdnClear2.Value = MSJAGJAG00_C.pClear2
            hdnClear3.Value = MSJAGJAG00_C.pClear3
            hdnClear4.Value = MSJAGJAG00_C.pClear4
        End If
        '販売事業者グループマスタ 2014/10/03 T.Ono add 2014改善開発 No19
        If Request.Path.LastIndexOf("MSHAGJAG00") >= 0 Then
            MSHAGJAG00_C = CType(Context.Handler, MSHAGJAG00.MSHAGJAG00)
            strListName = MSHAGJAG00_C.pListName
            hdnListCd.Value = MSHAGJAG00_C.pListCd
            hdnCode1.Value = MSHAGJAG00_C.pCode1
            hdnCode2.Value = MSHAGJAG00_C.pCode2
            hdnBackCode.Value = MSHAGJAG00_C.pBackCode
            hdnBackName.Value = MSHAGJAG00_C.pBackName
            hbdBackFocs.Value = MSHAGJAG00_C.pBackFocs
            hbdBackScript.Value = MSHAGJAG00_C.pBackScript
            hdnClear1.Value = MSHAGJAG00_C.pClear1
            hdnClear2.Value = MSHAGJAG00_C.pClear2
            hdnClear3.Value = MSHAGJAG00_C.pClear3
            hdnClear4.Value = MSHAGJAG00_C.pClear4
            hdnClear5.Value = MSHAGJAG00_C.pClear5
        End If
        'JA担当者・連絡先・注意事項マスタ 2015/11/04 T.Ono add 2015改善開発 №7
        If Request.Path.LastIndexOf("MSTAGJAG00") >= 0 Then
            MSTAGJAG00_C = CType(Context.Handler, MSTAGJAG00.MSTAGJAG00)
            strListName = MSTAGJAG00_C.pListName
            hdnListCd.Value = MSTAGJAG00_C.pListCd
            hdnCode1.Value = MSTAGJAG00_C.pCode1
            hdnCode2.Value = MSTAGJAG00_C.pCode2
            hdnCode3.Value = MSTAGJAG00_C.pCode3
            hdnBackCode.Value = MSTAGJAG00_C.pBackCode
            hdnBackName.Value = MSTAGJAG00_C.pBackName
            hdnBackCode2.Value = MSTAGJAG00_C.pBackCode2
            hdnBackName2.Value = MSTAGJAG00_C.pBackName2
            hbdBackFocs.Value = MSTAGJAG00_C.pBackFocs
            hbdBackScript.Value = MSTAGJAG00_C.pBackScript
            hdnClear1.Value = MSTAGJAG00_C.pClear1
            hdnClear2.Value = MSTAGJAG00_C.pClear2
            hdnClear3.Value = MSTAGJAG00_C.pClear3
            hdnClear4.Value = MSTAGJAG00_C.pClear4
            hdnClear5.Value = MSTAGJAG00_C.pClear5
        End If
        'ＪＡ担当者連絡先エクセル出力（JA報告先マスタ参照）2015/12/15 T.Ono add 2015改善開発 №7
        If Request.Path.LastIndexOf("MSTAHJAG00") >= 0 Then
            MSTAHJAG00_C = CType(Context.Handler, MSTAHJAG00.MSTAHJAG00)
            strListName = MSTAHJAG00_C.pListName
            hdnListCd.Value = MSTAHJAG00_C.pListCd
            hdnCode1.Value = MSTAHJAG00_C.pCode1
            hdnCode2.Value = MSTAHJAG00_C.pCode2
            hdnCode3.Value = MSTAHJAG00_C.pCode3            '2019/11/01 T.Ono add 監視改善2019
            hdnCode4.Value = MSTAHJAG00_C.pCode4            '2019/11/01 T.Ono add 監視改善2019
            hdnBackCode.Value = MSTAHJAG00_C.pBackCode
            hdnBackName.Value = MSTAHJAG00_C.pBackName
            hdnBackCode2.Value = MSTAHJAG00_C.pBackCode2    '2019/11/01 T.Ono add 監視改善2019
            hbdBackFocs.Value = MSTAHJAG00_C.pBackFocs
            hbdBackScript.Value = MSTAHJAG00_C.pBackScript  '2019/11/01 T.Ono add 監視改善2019
            hdnClear1.Value = MSTAHJAG00_C.pClearCode1
            hdnClear2.Value = MSTAHJAG00_C.pClearCode2
            hdnClear3.Value = MSTAHJAG00_C.pClearCode3
            hdnClear4.Value = MSTAHJAG00_C.pClearCode4
            hdnClear5.Value = MSTAHJAG00_C.pClearCode5      '2019/11/01 T.Ono add 監視改善2019
        End If
        '自動対応グループ作成マスタ 2017/02/09 W.Ganeko add 2016改善開発 No10
        If Request.Path.LastIndexOf("MSJINJAG00") >= 0 Then
            MSJINJAG00_C = CType(Context.Handler, MSJINJAG00.MSJINJAG00)
            strListName = MSJINJAG00_C.pListName
            hdnListCd.Value = MSJINJAG00_C.pListCd
            hdnCode1.Value = MSJINJAG00_C.pCode1
            hdnCode2.Value = MSJINJAG00_C.pCode2
            hdnBackCode.Value = MSJINJAG00_C.pBackCode
            hdnBackName.Value = MSJINJAG00_C.pBackName
            hbdBackFocs.Value = MSJINJAG00_C.pBackFocs
            hbdBackScript.Value = MSJINJAG00_C.pBackScript
            hdnClear1.Value = MSJINJAG00_C.pClear1
            hdnClear2.Value = MSJINJAG00_C.pClear2
            hdnClear3.Value = MSJINJAG00_C.pClear3
            hdnClear4.Value = MSJINJAG00_C.pClear4
        End If
        '一般消費者名簿出力 2019/01/10 T.Ono add 2018改善開発
        If Request.Path.LastIndexOf("SBMEOJAG00") >= 0 Then
            SBMEOJAG00_C = CType(Context.Handler, SBMEOJAG00.SBMEOJAG00)
            strListName = SBMEOJAG00_C.pListName
            hdnListCd.Value = SBMEOJAG00_C.pListCd
            hdnCode1.Value = SBMEOJAG00_C.pCode1
            hdnCode2.Value = SBMEOJAG00_C.pCode2
            hdnBackCode.Value = SBMEOJAG00_C.pBackCode
            hdnBackName.Value = SBMEOJAG00_C.pBackName
            hbdBackFocs.Value = SBMEOJAG00_C.pBackFocs
            hbdBackScript.Value = SBMEOJAG00_C.pBackScript
            hdnClear1.Value = SBMEOJAG00_C.pClear1
            hdnClear2.Value = SBMEOJAG00_C.pClear2
            hdnClear3.Value = SBMEOJAG00_C.pClear3
            hdnClear4.Value = SBMEOJAG00_C.pClear4
        End If
        '販売店グループマスタ 2019/01/24 T.Ono add 2018改善開発
        If Request.Path.LastIndexOf("MSHATJAG00") >= 0 Then
            MSHATJAG00_C = CType(Context.Handler, MSHATJAG00.MSHATJAG00)
            strListName = MSHATJAG00_C.pListName
            hdnListCd.Value = MSHATJAG00_C.pListCd
            hdnCode1.Value = MSHATJAG00_C.pCode1
            hdnCode2.Value = MSHATJAG00_C.pCode2
            hdnBackCode.Value = MSHATJAG00_C.pBackCode
            hdnBackName.Value = MSHATJAG00_C.pBackName
            hbdBackFocs.Value = MSHATJAG00_C.pBackFocs
            hbdBackScript.Value = MSHATJAG00_C.pBackScript
            hdnClear1.Value = MSHATJAG00_C.pClear1
            hdnClear2.Value = MSHATJAG00_C.pClear2
            hdnClear3.Value = MSHATJAG00_C.pClear3
            hdnClear4.Value = MSHATJAG00_C.pClear4
            hdnClear5.Value = MSHATJAG00_C.pClear5
        End If
        '災害対応帳票　2019/11/01 T.Ono add 監視改善2019
        If Request.Path.LastIndexOf("KESAIJAG00") >= 0 Then
            KESAIJAG00_C = CType(Context.Handler, KESAIJAG00.KESAIJAG00)
            strListName = KESAIJAG00_C.pListName
            hdnListCd.Value = KESAIJAG00_C.pListCd
            hdnCode1.Value = KESAIJAG00_C.pCode1
            hdnBackCode.Value = KESAIJAG00_C.pBackCode
            hdnBackName.Value = KESAIJAG00_C.pBackName
            hdnBackCode2.Value = KESAIJAG00_C.pBackCode2
            hbdBackFocs.Value = KESAIJAG00_C.pBackFocs
            hbdBackScript.Value = KESAIJAG00_C.pBackScript
            If KESAIJAG00_C.pClear.Split(Convert.ToChar(",")).Length > 1 Then
                hdnClear1.Value = Convert.ToString(KESAIJAG00_C.pClear.Split(Convert.ToChar(",")).GetValue(0))
                hdnClear2.Value = Convert.ToString(KESAIJAG00_C.pClear.Split(Convert.ToChar(",")).GetValue(1))
                hdnClear3.Value = Convert.ToString(KESAIJAG00_C.pClear.Split(Convert.ToChar(",")).GetValue(2))
                hdnClear4.Value = Convert.ToString(KESAIJAG00_C.pClear.Split(Convert.ToChar(",")).GetValue(3))
                hdnClear5.Value = Convert.ToString(KESAIJAG00_C.pClear.Split(Convert.ToChar(",")).GetValue(4))
                hdnClear6.Value = Convert.ToString(KESAIJAG00_C.pClear.Split(Convert.ToChar(",")).GetValue(5))
            End If
        End If
        '------------------------------------------------------------------------------
        '一覧タイトルの表示
        lblListName.Text = strListName
        'ウィンドウのタイトルの設定
        strMsg.Append("document.title='" & strListName & "'")
    End Sub
    '******************************************************************************
    '*　概　要：リストコード(種別)の値を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pListCd() As String
        Get
            Return hdnListCd.Value
        End Get
    End Property
    '******************************************************************************
    '*　概　要：コードを返すオブジェクトの名前値を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pBackCode() As String
        Get
            Return hdnBackCode.Value
        End Get
    End Property
    '******************************************************************************
    '*　概　要：名称を返すオブジェクトの名前値を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pBackName() As String
        Get
            Return hdnBackName.Value
        End Get
    End Property
    '******************************************************************************
    '*　概　要：フォーカスを返すオブジェクトの名前値を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pBackFocs() As String
        Get
            Return hbdBackFocs.Value
        End Get
    End Property
    '******************************************************************************
    '*　概　要：実行するＪＳ名を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pBackScript() As String
        Get
            Return hbdBackScript.Value
        End Get
    End Property
    '******************************************************************************
    '*　概　要：
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pPopType() As String
        Get
            '[1]:コードの返り値は表示用の「[CODE]：[NAME]」になります：デフォルト
            '[2]:コードの返り値は入力可能(顧客検索)用の「CODE」になります
            Return hdnPopType.Value
        End Get
    End Property
    '******************************************************************************
    '*　概　要：コードの値を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pCode1() As String
        Get
            Return hdnCode1.Value
        End Get
    End Property
    '******************************************************************************
    '*　概　要：コードの値を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pCode2() As String
        Get
            Return hdnCode2.Value
        End Get
    End Property
    '******************************************************************************
    '*　概　要：コードの値を渡すプロパティ 2014/12/04 H.Hosoda add 監視改善2014 No.6
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pCode3() As String
        Get
            Return hdnCode3.Value
        End Get
    End Property
    '******************************************************************************
    '*　概　要：コードの値を渡すプロパティ 2016/11/21 H.Mori add 監視改善2016 No2-1
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pCode4() As String
        Get
            Return hdnCode4.Value
        End Get
    End Property
    '******************************************************************************
    '*　概　要：コードの値を渡すプロパティ 2019/11/01 T.Ono add 監視改善2019 No1
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pCode5() As String
        Get
            Return hdnCode5.Value
        End Get
    End Property
    '******************************************************************************
    '*　概　要：供給センターが変更された時にクリアするオブジェクトの名前値を渡すプロパティ１
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pClear1() As String
        Get
            Return hdnClear1.Value
        End Get
    End Property
    '******************************************************************************
    '*　概　要：供給センターが変更された時にクリアするオブジェクトの名前値を渡すプロパティ２
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pClear2() As String
        Get
            Return hdnClear2.Value
        End Get
    End Property
    '******************************************************************************
    '*　概　要：供給センターが変更された時にクリアするオブジェクトの名前値を渡すプロパティ１
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pClear3() As String
        Get
            Return hdnClear3.Value
        End Get
    End Property
    '******************************************************************************
    '*　概　要：供給センターが変更された時にクリアするオブジェクトの名前値を渡すプロパティ２
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pClear4() As String
        Get
            Return hdnClear4.Value
        End Get
    End Property
    '******************************************************************************
    '*　概　要：供給センターが変更された時にクリアするオブジェクトの名前値を渡すプロパティ１
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pClear5() As String
        Get
            Return hdnClear5.Value
        End Get
    End Property
    '******************************************************************************
    '*　概　要：供給センターが変更された時にクリアするオブジェクトの名前値を渡すプロパティ２
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pClear6() As String
        Get
            Return hdnClear6.Value
        End Get
    End Property
    
    '2014/12/11 H.Hosoda add 監視改善2014 No.13 START
    '******************************************************************************
    '*　概　要：供給センターが変更された時にクリアするオブジェクトの名前値を渡すプロパティ７
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pClear7() As String
        Get
            Return hdnClear7.Value
        End Get
    End Property
    '******************************************************************************
    '*　概　要：供給センターが変更された時にクリアするオブジェクトの名前値を渡すプロパティ８
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pClear8() As String
        Get
            Return hdnClear8.Value
        End Get
    End Property
    '2014/12/11 H.Hosoda add 監視改善2014 No.13 END
    '2015/11/04 w.ganeko 2015改善開発 №6 START
    '******************************************************************************
    '*　概　要：供給センターが変更された時にクリアするオブジェクトの名前値を渡すプロパティ８
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pClear9() As String
        Get
            Return hdnClear9.Value
        End Get
    End Property
    '******************************************************************************
    '*　概　要：供給センターが変更された時にクリアするオブジェクトの名前値を渡すプロパティ８
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pClear10() As String
        Get
            Return hdnClear10.Value
        End Get
    End Property
    '******************************************************************************
    '*　概　要：供給センターが変更された時にクリアするオブジェクトの名前値を渡すプロパティ８
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pClear11() As String
        Get
            Return hdnClear11.Value
        End Get
    End Property
    '******************************************************************************
    '*　概　要：供給センターが変更された時にクリアするオブジェクトの名前値を渡すプロパティ８
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pClear12() As String
        Get
            Return hdnClear12.Value
        End Get
    End Property
    '******************************************************************************
    '*　概　要：供給センターが変更された時にクリアするオブジェクトの名前値を渡すプロパティ８
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pClear13() As String
        Get
            Return hdnClear13.Value
        End Get
    End Property
    '******************************************************************************
    '*　概　要：供給センターが変更された時にクリアするオブジェクトの名前値を渡すプロパティ８
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pClear14() As String
        Get
            Return hdnClear14.Value
        End Get
    End Property
    '2015/11/04 w.ganeko 2015改善開発 №6 END
    '******************************************************************************
    '*　概　要：コードを返すオブジェクトの名前値を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pBackCode2() As String
        Get
            Return hdnBackCode2.Value
        End Get
    End Property
    '******************************************************************************
    '*　概　要：名称を返すオブジェクトの名前値を渡すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pBackName2() As String
        Get
            Return hdnBackName2.Value
        End Get
    End Property
    '******************************************************************************
    '*　概　要：pBackCode2、pBackName2に、pBackCode、pBackNameをセットする場合は1
    '*　備　考：2019/11/01 w.ganeko 2019監視改善 add　ToにFromと同値を入れる
    '******************************************************************************
    Public ReadOnly Property pBackMode() As String
        Get
            Return hdnBackMode.Value
        End Get
    End Property
End Class
