'***********************************************
'連絡先画面
'***********************************************
Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common

Imports System.Text

Partial Class SDSYUJTG00
    Inherits System.Web.UI.Page
    'Protected WithEvents txtDENWABIKO As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnTelHas As System.Web.UI.HtmlControls.HtmlInputButton
    '--- ↓2005/04/25 ADD Falcon↓ ---

    '<TODO>宣言共通仕様
    '******************************************************************************
    ' HttpHeader
    '******************************************************************************
    Protected HttpHeaderC As New CHttpHeader

    '<TODO>宣言共通仕様
    '******************************************************************************
    ' 認証クラス
    '******************************************************************************
    'Protected AuthC As CAuthenticate

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

        strWrite.Append("<!-- Render -->")
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
        'AuthC = New CAuthenticate(Request, Response)

        '//------------------------------------------
        '//　認証処理
        '<TODO>：使用可能権限を指定する
        '使用可能権限(運:○/営:×/監:○/出:×)
        '[対応入力]使用可能権限(運:○/営:○/監:○/出:×)
        'AuthC.fncAuthCheck(Server, AuthC.pGROUP_UNKOU & "," & AuthC.pGROUP_KANSHI & "," & AuthC.pGROUP_EIGYOU)

        '前画面から情報を取得
        Dim SDSYUJAG00C As SDSYUJAG00
        SDSYUJAG00C = CType(Context.Handler, SDSYUJAG00)
        hdnKURACD.Value = SDSYUJAG00C.pPRAM_KURACD
        hdnACBCD.Value = SDSYUJAG00C.pPRAM_JASCD
        ' 2013/07/01 T.Ono add
        hdnKANSCD.Value = SDSYUJAG00C.pPRAM_KANSCD   '監視センターコード
        hdnSYONO.Value = SDSYUJAG00C.pPRAM_SYONO     '処理番号

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
             MyBase.MapPath("../../../SD/SDSYUJAG/SDSYUJAG00/") & "SDSYUJTG00.js"))
        '<フォーカス関連関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncFo.js"))
        '<入力チェック関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncChk.js"))
        '<電話番号チェック関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncTel.js"))
        '<バイト数関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncGetByte.js"))
        '<全角チェック関数>
        strScript.Append(strScript.Append("</Script>"))
        '//------------------------------------------
        '//　Css格納
        strScript.Append("<Style>")
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "CssSmall.css"))
        strScript.Append("</Style>")
        '//------------------------------------------
        '//　Script書込み
        lblScript.Text = strScript.ToString


        '//------------------------------------
        Dim SQLC As New SDSYUJAG00CSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet
        Try
            'If MyBase.IsPostBack = False Then
            '//対応入力画面の情報を受け取る ---
            Call GetSDSYUJAG00()
            '//--------------------------------
            strSQL = New StringBuilder("")
            strSQL.Append("SELECT  ")
            strSQL.Append("JA.JA_NAME, ")
            strSQL.Append("JA.JAS_NAME, ")
            strSQL.Append("JA.JA_KANA, ")
            strSQL.Append("JA.JAS_KANA ")
            strSQL.Append("FROM HN2MAS JA ")
            strSQL.Append("WHERE JA.CLI_CD = :CLSI_CD ")
            strSQL.Append("  AND JA.HAN_CD = :HAN_CD ")

            'パラメータのセット
            SqlParamC.fncSetParam("CLSI_CD", True, hdnKURACD.Value)
            SqlParamC.fncSetParam("HAN_CD", True, hdnACBCD.Value)

            '//SQLの実行
            dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

            If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then

            Else
                '//情報の出力
                '名称
                If Convert.ToString(dbData.Tables(0).Rows(0).Item("JA_NAME")).Length = 0 And Convert.ToString(dbData.Tables(0).Rows(0).Item("JAS_NAME")).Length = 0 Then
                    '両方存在しない
                    txtACBNM.Text = ""
                ElseIf Convert.ToString(dbData.Tables(0).Rows(0).Item("JA_NAME")).Length > 0 And Convert.ToString(dbData.Tables(0).Rows(0).Item("JAS_NAME")).Length > 0 Then
                    '両方存在する
                    txtACBNM.Text = Convert.ToString(dbData.Tables(0).Rows(0).Item("JA_NAME")) & " / " & Convert.ToString(dbData.Tables(0).Rows(0).Item("JAS_NAME"))
                Else
                    'どちらか存在する
                    txtACBNM.Text = Convert.ToString(dbData.Tables(0).Rows(0).Item("JA_NAME")) & Convert.ToString(dbData.Tables(0).Rows(0).Item("JAS_NAME"))
                End If
                'カナ
                If Convert.ToString(dbData.Tables(0).Rows(0).Item("JA_KANA")).Length = 0 And Convert.ToString(dbData.Tables(0).Rows(0).Item("JAS_KANA")).Length = 0 Then
                    '両方存在しない
                    txtACBKN.Text = ""
                ElseIf Convert.ToString(dbData.Tables(0).Rows(0).Item("JA_KANA")).Length > 0 And Convert.ToString(dbData.Tables(0).Rows(0).Item("JAS_KANA")).Length > 0 Then
                    '両方存在する
                    txtACBKN.Text = Convert.ToString(dbData.Tables(0).Rows(0).Item("JA_KANA")) & " / " & Convert.ToString(dbData.Tables(0).Rows(0).Item("JAS_KANA"))
                Else
                    'どちらか存在する
                    txtACBKN.Text = Convert.ToString(dbData.Tables(0).Rows(0).Item("JA_KANA")) & Convert.ToString(dbData.Tables(0).Rows(0).Item("JAS_KANA"))
                End If

            End If
            'End If

            'カーソルのセット
            strMsg.Append("Form1.btnExit.focus();")

        Catch ex As Exception
            Dim ErrMsgC As New CErrMsg
            strMsg.Append("alert('システムエラー：" & ErrMsgC.mGetArtMsg(ex.ToString) & "');")

        Finally
            If dbData Is Nothing Then
            Else
                dbData.Dispose()
            End If
        End Try

    End Sub

    '--- ↓2005/04/25 ADD Falcon↓ ---
    '******************************************************************************
    '*　概　要：
    '*　備　考：
    '******************************************************************************
    Private Sub GetSDSYUJAG00()
        Dim UtilFucC As New CUtilFuc


        Dim intRow As Integer
        Dim intTan As Integer
        Dim strRec As String

        Dim strJACD As String ' 2007/09/18 T.Watabe add
        Dim existFlg As Boolean



        '//------------------------------------
        Dim SQLC As New SDSYUJAG00CSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim strSQL2 As New StringBuilder("") ' 2009/03/05 T.Watabe add
        Dim dbData As DataSet
        Dim TanMSKBN As String = "0"  ' 0:M05_TANTO2登録なし 1:お客様CD1つでの登録 2:お客様CD範囲での登録

        Try
            TanMSKBN = fncCheckTANTO2() ' 2013/07/01 T.Ono add

            '//データの取得
            '2016/02/10 H.Mori mod 2016改善開発 START
            'strSQL = New StringBuilder("")
            'strSQL.Append("SELECT ")
            'strSQL.Append("    JA.JA_NAME, ")
            'strSQL.Append("    JA.JAS_NAME, ")
            'strSQL.Append("    TN.TANCD, ")
            'strSQL.Append("    TN.TANNM, ")
            'strSQL.Append("    TN.RENTEL1, ")
            'strSQL.Append("    TN.RENTEL2, ")
            'strSQL.Append("    TN.RENTEL3, ")                       '2013/06/28 T.Ono add 電話番号3
            'strSQL.Append("    TN.FAXNO, ")
            'strSQL.Append("    TN.BIKO, ")
            'strSQL.Append("    TN.EDT_DATE, ")
            'strSQL.Append("    TN.TIME ")
            'strSQL.Append("FROM HN2MAS JA, ")
            '' ▼▼▼ 2013/07/01 T.Ono mod 顧客単位登録機能追加 ▼▼▼
            ''strSQL.Append("     M05_TANTO TN ")
            'If TanMSKBN = "1" Or TanMSKBN = "2" Then
            '    strSQL.Append("     M05_TANTO2 TN, ")
            '    strSQL.Append("     D20_TAIOU TI ")
            'Else
            '    strSQL.Append("     M05_TANTO TN ")
            'End If
            '' ▲▲▲ 2013/07/01 T.Ono mod 顧客単位登録機能追加 ▲▲▲
            'strSQL.Append("WHERE ")
            'strSQL.Append("      JA.CLI_CD = :CLSI_CD ")
            'strSQL.Append("  AND JA.HAN_CD = :HAN_CD ")
            'strSQL.Append("  AND JA.CLI_CD = TN.KURACD(+) ")
            'strSQL.Append("  AND JA.HAN_CD = TN.CODE(+) ")
            'strSQL.Append("  AND 0 <> TO_NUMBER(TN.TANCD) ")
            'strSQL.Append("  AND '3' = TN.KBN(+) ")
            '' ▼▼▼ 2013/07/01 T.Ono mod 顧客単位登録機能追加 ▼▼▼
            'If TanMSKBN = "1" Then
            '    strSQL.Append("  AND TI.KANSCD = :KANSCD ")
            '    strSQL.Append("  AND TI.SYONO = :SYONO ")
            '    strSQL.Append("  AND TN.USER_CD_TO IS NULL ")
            '    strSQL.Append("  AND TI.USER_CD = TN.USER_CD_FROM ")
            'ElseIf TanMSKBN = "2" Then
            '    strSQL.Append("  AND TI.KANSCD = :KANSCD ")
            '    strSQL.Append("  AND TI.SYONO = :SYONO ")
            '    strSQL.Append("  AND TN.USER_CD_TO IS NOT NULL ")
            '    strSQL.Append("  AND TI.USER_CD BETWEEN TN.USER_CD_FROM AND TN.USER_CD_TO ")
            'End If
            '' ▲▲▲ 2013/07/01 T.Ono mod 顧客単位登録機能追加 ▲▲▲
            'strSQL.Append("ORDER BY TO_NUMBER(TN.TANCD) ")
            strSQL = New StringBuilder("")
            strSQL.Append("SELECT ")
            strSQL.Append("    JA.JA_NAME, ")
            strSQL.Append("    JA.JAS_NAME, ")
            strSQL.Append("    M11.TANCD, ")
            strSQL.Append("    M11.TANNM, ")
            strSQL.Append("    M11.RENTEL1, ")
            strSQL.Append("    M11.RENTEL2, ")
            strSQL.Append("    M11.RENTEL3, ")
            strSQL.Append("    M11.FAXNO, ")
            strSQL.Append("    M11.SPOT_MAIL, ")                       '2019/08/02 W.GANEKO ADD
            strSQL.Append("    M11.BIKO, ")
            strSQL.Append("    TO_CHAR(M11.UPD_DATE,'YYYYMMDD') AS EDT_DATE, ")
            strSQL.Append("    TO_CHAR(M11.UPD_DATE,'HH24MISS') AS TIME ")
            strSQL.Append("FROM HN2MAS JA, ")
            If TanMSKBN = "1" Or TanMSKBN = "2" Then
                strSQL.Append("     M09_JAGROUP M09, ")
                strSQL.Append("     M11_JAHOKOKU M11, ")
                strSQL.Append("     D20_TAIOU TI ")
            Else
                strSQL.Append("     M09_JAGROUP M09, ")
                strSQL.Append("     M11_JAHOKOKU M11 ")
            End If
            strSQL.Append("WHERE ")
            strSQL.Append("      JA.CLI_CD = :CLSI_CD ")
            strSQL.Append("  AND JA.HAN_CD = :HAN_CD ")
            strSQL.Append("  AND M09.KBN(+) = '002' ")
            strSQL.Append("  AND JA.CLI_CD = M09.KURACD(+) ")
            strSQL.Append("  AND JA.HAN_CD = M09.ACBCD(+) ")
            strSQL.Append("  AND M11.KBN(+) = '2' ")
            strSQL.Append("  AND M09.GROUPCD = M11.GROUPCD(+) ")
            strSQL.Append("  AND 0 <> TO_NUMBER(M11.TANCD) ")

            If TanMSKBN = "1" Then
                strSQL.Append("  AND TI.KANSCD = :KANSCD ")
                strSQL.Append("  AND TI.SYONO = :SYONO ")
                strSQL.Append("  AND M09.USERCD_TO IS NULL ")
                strSQL.Append("  AND TI.USER_CD = M09.USERCD_FROM ")
            ElseIf TanMSKBN = "2" Then
                strSQL.Append("  AND TI.KANSCD = :KANSCD ")
                strSQL.Append("  AND TI.SYONO = :SYONO ")
                strSQL.Append("  AND M09.USERCD_TO IS NOT NULL ")
                strSQL.Append("  AND TI.USER_CD BETWEEN M09.USERCD_FROM AND M09.USERCD_TO ")
            Else
                strSQL.Append("  AND M09.USERCD_FROM IS NULL ")
                strSQL.Append("  AND M09.USERCD_TO IS NULL ")
            End If
            strSQL.Append("ORDER BY TO_NUMBER(M11.TANCD) ")
            '2016/02/10 H.Mori mod 2016改善開発 END

            'パラメータのセット
            SqlParamC.fncSetParam("CLSI_CD", True, hdnKURACD.Value)
            SqlParamC.fncSetParam("HAN_CD", True, hdnACBCD.Value)
            ' ▼▼▼ 2013/07/01 T.Ono mod 顧客単位登録機能追加 ▼▼▼
            If TanMSKBN = "1" Or TanMSKBN = "2" Then
                SqlParamC.fncSetParam("KANSCD", True, hdnKANSCD.Value)
                SqlParamC.fncSetParam("SYONO", True, hdnSYONO.Value)
            End If
            ' ▲▲▲ 2013/07/01 T.Ono mod 顧客単位登録機能追加 ▲▲▲

            '//SQLの実行
            dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)


            If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) <> "XYZ" Then
                'ＪＡ支所→データあり！
                existFlg = True
                '2016/02/10 H.Mori del 2016改善開発 START
                'Else

                '    '2009/03/05 T.Watabe add
                '    'ＪＡ支所コードからＪＡコードを参照  
                '    strSQL2.Append("SELECT JA_CD FROM HN2MAS WHERE CLI_CD = :CLSI_CD  AND HAN_CD = :HAN_CD ")
                '    SqlParamC = New CSQLParam()                 '2012/07/17 NEC Add
                '    SqlParamC.fncSetParam("CLSI_CD", True, hdnKURACD.Value) 'パラメータのセット
                '    SqlParamC.fncSetParam("HAN_CD", True, hdnACBCD.Value)
                '    dbData = SQLC.mGetData(strSQL2.ToString, SqlParamC.pParamDataSet, True) '//SQLの実行
                '    strJACD = Convert.ToString(dbData.Tables(0).Rows(0).Item(0))

                '    If strJACD <> "" Then 'ＪＡコードあり？

                '        'ＪＡ支所で見つからないので・・・
                '        '③ＪＡ代表コードから取得

                '        'パラメータのセット
                '        SqlParamC = New CSQLParam()                 '2012/07/17 NEC Add
                '        SqlParamC.fncSetParam("CLSI_CD", True, hdnKURACD.Value)
                '        SqlParamC.fncSetParam("HAN_CD", True, strJACD)

                '        '//SQLの実行
                '        dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

                '        If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) <> "XYZ" Then
                '            'ＪＡ代表→データあり！
                '            existFlg = True
                '        End If
                '    End If
                '2016/02/10 H.Mori del 2016改善開発 END

            End If

            'データなしの場合初期化
            If existFlg = False Then
                dbData.Tables(0).Rows(intRow).Item("JA_NAME") = ""
                dbData.Tables(0).Rows(intRow).Item("JAS_NAME") = ""
                dbData.Tables(0).Rows(intRow).Item("TANCD") = ""
                dbData.Tables(0).Rows(intRow).Item("TANNM") = ""
                dbData.Tables(0).Rows(intRow).Item("RENTEL1") = ""
                dbData.Tables(0).Rows(intRow).Item("RENTEL2") = ""
                dbData.Tables(0).Rows(intRow).Item("RENTEL3") = ""      ' 2013/06/28 T.Ono add
                dbData.Tables(0).Rows(intRow).Item("FAXNO") = ""
                dbData.Tables(0).Rows(intRow).Item("SPOT_MAIL") = ""    '2019/08/02 W.GANEKO ADD
                dbData.Tables(0).Rows(intRow).Item("BIKO") = ""
            End If

            Dim bInit As Boolean
            For intTan = 0 To 9
                If Convert.ToString(dbData.Tables(0).Rows(intRow).Item("TANCD")) <> "" Then
                    If intTan + 1 = CInt(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("TANCD"))) Then
                        strMsg.Append("document.Form1.txtTANNM" & intTan + 1 & ".value='" & Convert.ToString(dbData.Tables(0).Rows(intRow).Item("TANNM")) & "';")
                        strMsg.Append("document.Form1.txtRENTEL1_" & intTan + 1 & ".value='" & Convert.ToString(dbData.Tables(0).Rows(intRow).Item("RENTEL1")) & "';")
                        strMsg.Append("document.Form1.txtRENTEL2_" & intTan + 1 & ".value='" & Convert.ToString(dbData.Tables(0).Rows(intRow).Item("RENTEL2")) & "';")
                        strMsg.Append("document.Form1.txtRENTEL3_" & intTan + 1 & ".value='" & Convert.ToString(dbData.Tables(0).Rows(intRow).Item("RENTEL3")) & "';")  ' 2013/06/28 T.Ono add
                        strMsg.Append("document.Form1.txtBIKO" & intTan + 1 & ".value='" & Convert.ToString(dbData.Tables(0).Rows(intRow).Item("BIKO")) & "';")
                        strMsg.Append("document.Form1.txtMail" & intTan + 1 & ".value='" & Convert.ToString(dbData.Tables(0).Rows(intRow).Item("SPOT_MAIL")) & "';")    '2019/08/02 W.GANEKO ADD
                        strMsg.Append("document.Form1.txtFAX" & intTan + 1 & ".value='" & Convert.ToString(dbData.Tables(0).Rows(intRow).Item("FAXNO")) & "';")

                        If intRow < dbData.Tables(0).Rows.Count - 1 Then
                            intRow += 1
                        End If

                        bInit = False
                    Else
                        bInit = True
                    End If
                End If
                If bInit = True Then
                    '連絡先情報は初期化される
                    strMsg.Append("document.Form1.txtTANNM" & intTan + 1 & ".value='';")
                    strMsg.Append("document.Form1.txtRENTEL1_" & intTan + 1 & ".value='';")
                    strMsg.Append("document.Form1.txtRENTEL2_" & intTan + 1 & ".value='';")
                    strMsg.Append("document.Form1.txtRENTEL3_" & intTan + 1 & ".value='';")     ' 2013/06/28 T.Ono add
                    strMsg.Append("document.Form1.txtBIKO" & intTan + 1 & ".value='';")
                    strMsg.Append("document.Form1.txtMail" & intTan + 1 & ".value='';")         '2019/08/02 W.GANEKO ADD
                    strMsg.Append("document.Form1.txtFAX" & intTan + 1 & ".value='';")
                End If
            Next

        Catch ex As Exception
            Dim ErrMsgC As New CErrMsg
            strMsg.Append("alert('システムエラー：" & ErrMsgC.mGetArtMsg(ex.ToString) & "');")

        Finally
            If dbData Is Nothing Then
            Else
                dbData.Dispose()
            End If
        End Try

    End Sub

    '**********************************************************
    ' 2013/07/01 T.Ono add
    'M05_TANTO2に登録があるか確認
    '戻り値： 0：TANTO2登録なし 1:お客様コード1つ 2:お客様コード範囲
    '**********************************************************
    Private Function fncCheckTANTO2() As String

        Dim SQLC As New SDSYUJAG00CSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet
        Dim strRes As String = "0"
        Dim i As Integer
        Try

            For i = 0 To 1
                '2016/02/10 H.Mori mod 2016改善開発 START
                '1週目：お客様CD1つ、2週目：お客様CD範囲
                'strSQL = New StringBuilder("")
                'strSQL.Append("SELECT   B.KURACD ")
                'strSQL.Append("FROM     D20_TAIOU A, ")
                'strSQL.Append("         M05_TANTO2 B ")
                'strSQL.Append("WHERE    A.KANSCD = :KANSCD ")
                'strSQL.Append("AND      A.SYONO = :SYONO ")
                'strSQL.Append("AND      B.KURACD = A.KURACD ")
                'strSQL.Append("AND      B.CODE = A.ACBCD ")
                'If i = 0 Then
                '    strSQL.Append("AND	    B.USER_CD_TO IS NULL ")
                '    strSQL.Append("AND	    A.USER_CD =  B.USER_CD_FROM ")
                'Else
                '    strSQL.Append("AND      B.USER_CD_TO IS NOT NULL ")
                '    strSQL.Append("AND      A.USER_CD BETWEEN B.USER_CD_FROM AND B.USER_CD_TO ")
                'End If
                strSQL = New StringBuilder("")
                strSQL.Append("SELECT   M09.KURACD ")
                strSQL.Append("FROM     D20_TAIOU A, ")
                strSQL.Append("         M09_JAGROUP M09 ")
                strSQL.Append("WHERE    A.KANSCD = :KANSCD ")
                strSQL.Append("AND      A.SYONO = :SYONO ")
                strSQL.Append("AND      M09.KURACD = A.KURACD ")
                strSQL.Append("AND      M09.ACBCD = A.ACBCD ")
                strSQL.Append("AND      M09.KBN(+) = '002' ")
                If i = 0 Then
                    strSQL.Append("AND	    M09.USERCD_TO IS NULL ")
                    strSQL.Append("AND	    A.USER_CD =  M09.USERCD_FROM ")
                Else
                    strSQL.Append("AND      M09.USERCD_TO IS NOT NULL ")
                    strSQL.Append("AND      A.USER_CD BETWEEN M09.USERCD_FROM AND M09.USERCD_TO ")
                End If
                '2016/02/10 H.Mori mod 2016改善開発 END

                'パラメータのセット
                SqlParamC.fncSetParam("KANSCD", True, hdnKANSCD.Value)
                SqlParamC.fncSetParam("SYONO", True, hdnSYONO.Value)

                '//SQLの実行
                dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

                If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
                    'データなしの場合
                    strRes = "0"
                Else
                    'データありの場合
                    strRes = CStr(i + 1)
                    Exit For
                End If
            Next

        Catch ex As Exception
            Dim ErrMsgC As New CErrMsg
            strMsg.Append("alert('システムエラー：" & ErrMsgC.mGetArtMsg(ex.ToString) & "');")

        Finally
            If dbData Is Nothing Then
            Else
                dbData.Dispose()
            End If
        End Try

        Return strRes
    End Function

End Class
