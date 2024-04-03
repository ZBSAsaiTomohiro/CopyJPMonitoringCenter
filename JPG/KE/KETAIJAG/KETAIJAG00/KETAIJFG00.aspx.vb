'***********************************************
'対応入力　ＦＡＸ送信データ作成
'***********************************************
Option Explicit On
Option Strict On


Imports Common
Imports JPG.Common
Imports JPG.Common.log

Imports System.Text

Partial Class KETAIJFG00
    Inherits System.Web.UI.Page

    '******************************************************************************
    ' HttpHeader
    '******************************************************************************
    Protected HttpHeaderC As New CHttpHeader

    '<TODO>宣言共通仕様
    '******************************************************************************
    ' 認証クラス
    '******************************************************************************
    Protected AuthC As CAuthenticate

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
    '*　概　要：ＦＡＸ送信ボタン押下時
    '*　備　考：
    '******************************************************************************
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '//------------------------------------------
        HttpHeaderC.mNoCache(Response)

        '//------------------------------------------
        '// 認証クラスのインスタンス生成
        AuthC = New CAuthenticate(Request, Response)

        '//------------------------------------------
        '//　認証処理
        '<TODO>：使用可能権限を指定する
        '使用可能権限(運:○/営:×/監:○/出:×)
        '2005/12/03 NEC UPDATE START
        '[対応入力]使用可能権限(運:○/営:○/監:○/出:×)
        'AuthC.fncAuthCheck(Server, AuthC.pGROUP_UNKOU & "," & AuthC.pGROUP_KANSHI)
        AuthC.fncAuthCheck(Server, AuthC.pGROUP_UNKOU & "," & AuthC.pGROUP_KANSHI & "," & AuthC.pGROUP_EIGYOU)
        '2005/12/03 NEC UPDATE START

        '//------------------------------------------
        '// ＷＥＢサービスのインスタンスを作成
        Dim strRec As String
        Dim KEFAXJAW00C As New KETAIJAG00KEFAXJAW00.KEFAXJAW00

        '//------------------------------------------
        '// 呼び出し元の画面クラスインスタンスを作成
        'Dim KETAIJTG00C As KETAIJTG00
        'KETAIJTG00C = CType(Context.Handler, KETAIJTG00)

        '//------------------------------------------
        '// ＷＥＢサービスの実行

        '2014/12/25 T.Ono add 2014改善開発 No4 START
        'メール/プレビューに表示する発信者をconfigファイルから取得
        '（FAXはKEFAXJAE00.exe.config[JIDOU_DOCUMENT_SENDERNAME]から取得している）
        Dim strSEND_NAME As String = ""
        If InStr(AuthC.pGROUPNAME, "0監視業務単独") > 0 Then
            '沖縄
            strSEND_NAME = ConfigurationSettings.AppSettings("JIDOU_DOCUMENT_SENDERNAME_OKINAWA")
        Else
            'その他（川口監視ｾﾝﾀｰ、運行、営業所）
            strSEND_NAME = ConfigurationSettings.AppSettings("JIDOU_DOCUMENT_SENDERNAME_KAWAGUCHI")
        End If

        'ﾌﾟﾚﾋﾞｭｰ作成
        If Request.Form("hdnBtnKBN") = "2" Then
            Dim strRes As String
            strRes = fncCreatePreview(strSEND_NAME)
            If strRes <> "OK" Then
                strMsg.Append("alert('システムエラー：" & strRes & "');")
            End If
            '↓ﾌﾟﾚﾋﾞｭｰ表示成功時には、適用されなかった。
            strMsg.Append("parent.Form1.btnTelHas.disabled=false;")
            strMsg.Append("parent.Form1.btnPreview.focus();")
            strMsg.Append("location.replace('about:blank');")   '受信フレーム内をブランクページに。
            Return
        End If
        '2014/12/25 T.Ono add 2014改善開発 No4 END

        Dim strSendFlg As String
        strSendFlg = Request.Form("hdnSendFlg")
        If strSendFlg = "2" Or strSendFlg = "3" Then
            '2020/11/01 T.Ono mod 2020監視改善　hdnTEL_MEMO4～6追加
            strRec = KEFAXJAW00C.fncDataOut(Request.Form("hdnSYONO"),
                                            Request.Form("hdnFAX_TITLE"),
                                            Request.Form("hdnACBCD"),
                                            Request.Form("hdnKURACD"),
                                            Request.Form("hdnKANSCD"),
                                            Request.Form("hdnJUSYONM"),
                                            Request.Form("hdnUSER_CD"),
                                            Request.Form("hdnJUTEL1"),
                                            Request.Form("hdnJUTEL2"),
                                            Request.Form("hdnRENTEL"),
                                            Request.Form("hdnADDR"),
                                            Request.Form("hdnHATYMD"),
                                            Request.Form("hdnHATTIME"),
                                            Request.Form("hdnKENSIN"),
                                            Request.Form("hdnRYURYO"),
                                            Request.Form("hdnMETASYU"),
                                            Request.Form("hdnKMNM1"),
                                            Request.Form("hdnKMNM2"),
                                            Request.Form("hdnKMNM3"),
                                            Request.Form("hdnKMNM4"),
                                            Request.Form("hdnKMNM5"),
                                            Request.Form("hdnKMNM6"),
                                            Request.Form("hdnTAIOKBN"),
                                            Request.Form("hdnTKTANCD"),
                                            Request.Form("hdnSYOYMD"),
                                            Request.Form("hdnSYOTIME"),
                                            Request.Form("hdnSIJIYMD"),
                                            Request.Form("hdnSIJITIME"),
                                            Request.Form("hdnTAITCD"),
                                            Request.Form("hdnTELRCD"),
                                            Request.Form("hdnFUK_MEMO"),
                                            Request.Form("hdnTEL_MEMO1"),
                                            Request.Form("hdnTEL_MEMO2"),
                                            Request.Form("hdnTEL_MEMO4"),
                                            Request.Form("hdnTEL_MEMO5"),
                                            Request.Form("hdnTEL_MEMO6"),
                                            Request.Form("hdnTKIGCD"),
                                            Request.Form("hdnTSADCD"),
                                            Request.Form("txtFAX_REN"),
                                            Request.Form("hdnMITOKBN")
                                           )
            Dim strRecMsg As String
            Dim strTextName As String

            Select Case Left(strRec, 2)
                Case "OK"   '//正常終了
                    strTextName = strRec
                    strTextName = strTextName.Substring(2, strTextName.Length - 2)
                    '2015/12/09 w.ganeko 2015改善開発 №2 start
                    'strMsg.Append("var strRec;")
                    'strMsg.Append("strRec = parent.Form1.Fax.SetExePath(parent.Form1.hdnFAXEXEPATH.value);")
                    'strMsg.Append("strRec = parent.Form1.Fax.SetExeName(parent.Form1.hdnFAXEXENAME.value);")
                    'strMsg.Append("strRec = parent.Form1.Fax.SetHdValue(parent.Form1.hdnFAXHEAD.value);")
                    'strMsg.Append("strRec = parent.Form1.Fax.SetFaxNumber(parent.Form1.hdnSNDFAXNO.value.split(' - ').join(''));")
                    'strMsg.Append("var strTemp;")
                    'strMsg.Append("strTemp = (parent.Form1.hdnFAXSESSION.value + ' ' + parent.Form1.hdnKURACD.value);")
                    'strMsg.Append("strTemp = (strTemp + (parent.Form1.hdnHATYMD.value.split('/').join('') + ' ' + parent.Form1.hdnSYONO.value + ' '));")
                    ''strMsg.Append("strTemp = (strTemp + ' ' + '" & strTextName & "');") '2014/02/04 T.Ono mod 監視改善2013 FAXサーバー選択追加
                    'strMsg.Append("strTemp = (strTemp + ' ' + '" & strTextName & "' + ' ' + parent.Form1.hdnFAXServerKBN.value);")
                    'strMsg.Append("strRec = parent.Form1.Fax.SetParam(strTemp);")
                    'strMsg.Append("strRec = parent.Form1.Fax.FncExecFax();")
                    'strMsg.Append("strRec = parent.Form1.Fax.GetStatus();")
                    Dim strToFaxStr As String
                    strToFaxStr = Request.Form("hdnSNDFAXNO")
                    strMsg.Append("var strFaxNo = '" & strToFaxStr & "';" & vbCrLf)
                    strMsg.Append("var strRec;" & vbCrLf)
                    strMsg.Append("strRec = parent.Form1.Fax.SetExePath(parent.Form1.hdnFAXEXEPATH.value);" & vbCrLf)
                    strMsg.Append("strRec = parent.Form1.Fax.SetExeName(parent.Form1.hdnFAXEXENAME.value);" & vbCrLf)
                    strMsg.Append("strRec = parent.Form1.Fax.SetHdValue(parent.Form1.hdnFAXHEAD.value);" & vbCrLf)
                    strMsg.Append("strRec = parent.Form1.Fax.SetFaxNumber(strFaxNo.split(' - ').join(''));" & vbCrLf)
                    strMsg.Append("var strTemp;" & vbCrLf)
                    strMsg.Append("strTemp = (parent.Form1.hdnFAXSESSION.value + ' ' + parent.Form1.hdnKURACD.value);" & vbCrLf)
                    strMsg.Append("strTemp = (strTemp + (parent.Form1.hdnHATYMD.value.split('/').join('') + ' ' + parent.Form1.hdnSYONO.value + ' '));" & vbCrLf)
                    strMsg.Append("strTemp = (strTemp + ' ' + '" & strTextName & "' + ' ' + parent.Form1.hdnFAXServerKBN.value);")
                    strMsg.Append("strRec = parent.Form1.Fax.SetParam(strTemp);" & vbCrLf)
                    strMsg.Append("strRec = parent.Form1.Fax.FncExecFax();" & vbCrLf)
                    strMsg.Append("strRec = parent.Form1.Fax.GetStatus();" & vbCrLf)
                    '2015/12/09 w.ganeko 2015改善開発 №2 end

                    '★★★2020/03/16 T.Ono FAX送信方法変更試作
                    'strMsg.Append("alert('Hello');" & vbCrLf)
                    'strMsg.Append("var sh;" & vbCrLf)
                    'strMsg.Append("sh = new ActiveXObject('WScript.Shell');" & vbCrLf)
                    'strMsg.Append("var res;" & vbCrLf)
                    'strMsg.Append("res = sh.run('D:/KANSI/DIAL/call.vbs, 0, true');" & vbCrLf)

                Case Else
                    Dim ErrMsgC As New CErrMsg
                    strMsg.Append("alert('システムエラー：" & ErrMsgC.mGetArtMsg(strRec) & "');")
            End Select

            strMsg.Append("parent.Form1.btnTelHas.disabled=false;")
            '2015/12/09 w.ganeko 2015改善開発 №2
            strMsg.Append("parent.Form1.btnSoExit.disabled=true;")
            strMsg.Append("parent.Form1.btnTelHas.focus();")
            strMsg.Append("location.replace('about:blank');")   '受信フレーム内をブランクページに。
        End If

        If strSendFlg = "3" Or strSendFlg = "4" Then
            Dim strMail As String
            Dim strMailPass As String
            strMail = Request.Form("hdnSNDMAIL")
            strMailPass = Request.Form("hdnSNDMAILPASS")
            '2015/01/19 T.Ono mod 2014改善開発 [発信者:strSEND_NAME]を追加
            '2020/11/01 T.Ono mod 2020監視改善 hdnTEL_MEMO4～6追加
            strRec = KEFAXJAW00C.fncExcelDataOut(Request.Form("hdnSYONO"),
                                Request.Form("hdnFAX_TITLE"),
                                Request.Form("hdnACBCD"),
                                Request.Form("hdnKURACD"),
                                Request.Form("hdnKANSCD"),
                                Request.Form("hdnJUSYONM"),
                                Request.Form("hdnUSER_CD"),
                                Request.Form("hdnJUTEL1"),
                                Request.Form("hdnJUTEL2"),
                                Request.Form("hdnRENTEL"),
                                Request.Form("hdnADDR"),
                                Request.Form("hdnHATYMD"),
                                Request.Form("hdnHATTIME"),
                                Request.Form("hdnKENSIN"),
                                Request.Form("hdnRYURYO"),
                                Request.Form("hdnMETASYU"),
                                Request.Form("hdnKMNM1"),
                                Request.Form("hdnKMNM2"),
                                Request.Form("hdnKMNM3"),
                                Request.Form("hdnKMNM4"),
                                Request.Form("hdnKMNM5"),
                                Request.Form("hdnKMNM6"),
                                Request.Form("hdnTAIOKBN"),
                                Request.Form("hdnTKTANCD"),
                                Request.Form("hdnSYOYMD"),
                                Request.Form("hdnSYOTIME"),
                                Request.Form("hdnSIJIYMD"),
                                Request.Form("hdnSIJITIME"),
                                Request.Form("hdnTAITCD"),
                                Request.Form("hdnTELRCD"),
                                Request.Form("hdnFUK_MEMO"),
                                Request.Form("hdnTEL_MEMO1"),
                                Request.Form("hdnTEL_MEMO2"),
                                Request.Form("hdnTEL_MEMO4"),
                                Request.Form("hdnTEL_MEMO5"),
                                Request.Form("hdnTEL_MEMO6"),
                                Request.Form("hdnTKIGCD"),
                                Request.Form("hdnTSADCD"),
                                Request.Form("txtFAX_REN"),
                                Request.Form("hdnMITOKBN"),
                                strSendFlg,
                                strMail,
                                strMailPass,
                                strSEND_NAME
                               )
            If Left(strRec, 2) = "OK" Then
                strMsg.Append("alert('メールを送信しました。');")
            Else
                strMsg.Append("alert('メール送信に失敗しました。');")
            End If
            strMsg.Append("parent.Form1.btnTelHas.disabled=false;")
            '2015/12/09 w.ganeko 2015改善開発 №2
            strMsg.Append("parent.Form1.btnSoExit.disabled=true;")
            strMsg.Append("parent.Form1.btnTelHas.focus();")
            strMsg.Append("location.replace('about:blank');")   '受信フレーム内をブランクページに。
        End If


    End Sub

    '******************************************************************************
    '*　概　要：プレビュー作成
    '*　備　考：2014/12/25 T.Ono add 2014改善開発 No4
    '******************************************************************************
    Private Function fncCreatePreview(ByVal pstrSEND_NAME As String) As String
        '//------------------------------------------
        '// ＷＥＢサービスのインスタンスを作成
        Dim strRec As String
        Dim KEFAXJAW00C As New KETAIJAG00KEFAXJAW00.KEFAXJAW00


        '//------------------------------------------
        '// ＷＥＢサービスの実行

        '1.FAX用データのテキストファイル作成
        '2.テキストファイルからエクセルファイル作成

        'FAX用データのテキストファイル作成
        Dim strSendFlg As String
        strSendFlg = Request.Form("hdnSendFlg")
        '2020/11/01 T.Ono mod 2020監視改善 hdnTEL_MEMO4～6追加
        strRec = KEFAXJAW00C.fncDataOut(Request.Form("hdnSYONO"),
                                        Request.Form("hdnFAX_TITLE"),
                                        Request.Form("hdnACBCD"),
                                        Request.Form("hdnKURACD"),
                                        Request.Form("hdnKANSCD"),
                                        Request.Form("hdnJUSYONM"),
                                        Request.Form("hdnUSER_CD"),
                                        Request.Form("hdnJUTEL1"),
                                        Request.Form("hdnJUTEL2"),
                                        Request.Form("hdnRENTEL"),
                                        Request.Form("hdnADDR"),
                                        Request.Form("hdnHATYMD"),
                                        Request.Form("hdnHATTIME"),
                                        Request.Form("hdnKENSIN"),
                                        Request.Form("hdnRYURYO"),
                                        Request.Form("hdnMETASYU"),
                                        Request.Form("hdnKMNM1"),
                                        Request.Form("hdnKMNM2"),
                                        Request.Form("hdnKMNM3"),
                                        Request.Form("hdnKMNM4"),
                                        Request.Form("hdnKMNM5"),
                                        Request.Form("hdnKMNM6"),
                                        Request.Form("hdnTAIOKBN"),
                                        Request.Form("hdnTKTANCD"),
                                        Request.Form("hdnSYOYMD"),
                                        Request.Form("hdnSYOTIME"),
                                        Request.Form("hdnSIJIYMD"),
                                        Request.Form("hdnSIJITIME"),
                                        Request.Form("hdnTAITCD"),
                                        Request.Form("hdnTELRCD"),
                                        Request.Form("hdnFUK_MEMO"),
                                        Request.Form("hdnTEL_MEMO1"),
                                        Request.Form("hdnTEL_MEMO2"),
                                        Request.Form("hdnTEL_MEMO4"),
                                        Request.Form("hdnTEL_MEMO5"),
                                        Request.Form("hdnTEL_MEMO6"),
                                        Request.Form("hdnTKIGCD"),
                                        Request.Form("hdnTSADCD"),
                                        Request.Form("txtFAX_REN"),
                                        Request.Form("hdnMITOKBN")
                                        )

        'テキストファイルの作成結果
        If Left(strRec, 2) <> "OK" Then
            'エラー
            Return strRec
        End If


        'エクセルファイル作成
        Dim strTextName As String
        strTextName = strRec
        strTextName = strTextName.Substring(2, strTextName.Length - 2)
        '2015/12/09 w.ganeko 2015改善開発 №2 start
        Dim strToFax As String()
        Dim strToFaxStr As String
        strToFaxStr = Request.Form("hdnSNDFAXNO")
        strToFax = strToFaxStr.Split(","c)

        'strRec = KEFAXJAW00C.mExcel(Request.Form("hdnFAXSESSION"), strTextName, _
        '                     pstrSEND_NAME, "", "", "", Request.Form("hdnSNDFAXNO"), "2")
        strRec = KEFAXJAW00C.mExcel(Request.Form("hdnFAXSESSION"), strTextName, _
                             pstrSEND_NAME, "", "", "", strToFax(0), "2")
        '2015/12/09 w.ganeko 2015改善開発 №2 end

        'strRec = "ERROR*ERROR*ERROR"
        'エクセルファイルの作成結果
        If strRec.Substring(0, 5) = "ERROR" Then
            'そのままのメッセージを出力
        Else
            HttpHeaderC.mDownLoadXLS(Response, "プレビュー.xls")
            Response.ContentType = "application/msexcel" '2017/05/11 T.Ono add 「ファイルを開く」際のエラー対策
            Response.WriteFile(strRec)
            strRec = "OK"
        End If

        Return strRec
    End Function

End Class
