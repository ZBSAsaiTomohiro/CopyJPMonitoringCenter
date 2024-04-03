'***********************************************
'コピー補助ポップアップ
'***********************************************
Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common

Imports System.Text
Imports System.IO

Partial Class KETAIJVG00
    Inherits System.Web.UI.Page


    Private strExecFlg As String

    '<TODO>宣言共通仕様
    '******************************************************************************
    ' HttpHeader
    '******************************************************************************
    Protected HttpHeaderC As New CHttpHeader

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
             MyBase.MapPath("../../../KE/KETAIJAG/KETAIJAG00/") & "KETAIJVG00.js"))
        '<フォーカス関連関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncFo.js"))
        '<入力チェック関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncChk.js"))
        '<電話番号チェック関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncTel.js"))
        '<バイト数関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncGetByte.js"))
        strScript.Append("</Script>")
        '//------------------------------------------
        '//　Css格納
        strScript.Append("<Style>")
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "CssSmall.css"))
        strScript.Append("</Style>")
        '//------------------------------------------
        '//　Script書込み
        lblScript.Text = strScript.ToString


        '//------------------------------------------------------------------------------
        If MyBase.IsPostBack = False Then
            '//--------------------------------------
            '//初めて開いた時だけ実行される

            '//------------------------------------------
            'データの格納
            Dim KETAIJAG00C As KETAIJAG00
            KETAIJAG00C = CType(Context.Handler, KETAIJAG00)
            hdnKURACD.Value = KETAIJAG00C.gstrKURACD
            hdnACBCD.Value = KETAIJAG00C.gstrACBCD
            hdnUSER_CD.Value = KETAIJAG00C.gstrUSER_CD
            '--連絡先2--
            txtRENTEL2.Text = KETAIJAG00C.gstrRENTEL2.Replace("-", "")
            txtRENTEL2_BIKO.Text = KETAIJAG00C.gstrRENTEL2_BIKO
            Dim strUpdDate As String = KETAIJAG00C.gstrRENTEL2_UPD_DATE
            If strUpdDate <> "" Then
                txtRENTEL2_UPD_DATE.Text = strUpdDate.Substring(0, 4) & "/" & strUpdDate.Substring(4, 2) & "/" & strUpdDate.Substring(6, 2)
            Else
                txtRENTEL2_UPD_DATE.Text = strUpdDate
            End If
            txtRENTEL2_UPD_DATE.Attributes.Add("ReadOnly", "true")
            '--連絡先3--
            txtRENTEL3.Text = KETAIJAG00C.gstrRENTEL3.Replace("-", "")
            txtRENTEL3_BIKO.Text = KETAIJAG00C.gstrRENTEL3_BIKO
            strUpdDate = ""
            strUpdDate = KETAIJAG00C.gstrRENTEL3_UPD_DATE
            If strUpdDate <> "" Then
                txtRENTEL3_UPD_DATE.Text = strUpdDate.Substring(0, 4) & "/" & strUpdDate.Substring(4, 2) & "/" & strUpdDate.Substring(6, 2)
            Else
                txtRENTEL3_UPD_DATE.Text = strUpdDate
            End If
            txtRENTEL3_UPD_DATE.Attributes.Add("ReadOnly", "true")
            '--電話番号--       2016/12/13 H.Mori add 2016改善開発 No5-1 
            txtTELAB.Text = KETAIJAG00C.gstrTELAB
            txtTELAB.Attributes.Add("ReadOnly", "true")
            '--第3連動連絡先--  2016/12/13 H.Mori add 2016改善開発 No5-1
            txtDAI3RENDORENTEL.Text = KETAIJAG00C.gstrDAI3RENDORENTEL
            txtDAI3RENDORENTEL.Attributes.Add("ReadOnly", "true")
            Dim teljvg As String = KETAIJAG00C.gstrTelJVG
            If teljvg = "2" Then
                rdoTel1_2.Checked = True
            ElseIf teljvg = "3" Then
                rdoTel1_3.Checked = True
            ElseIf teljvg = "4" Then
                rdoTel_AB.Checked = True
            ElseIf teljvg = "5" Then
                rdoTel_DAI3.Checked = True
            Else
                rdoTel1_2.Checked = True
            End If
            Dim gstrKBNMODE As String = KETAIJAG00C.gstrKBNMODE
            If gstrKBNMODE = "2" Then
                btnTelEnt.Attributes.Add("Disabled", "true")
            End If
        End If
    End Sub
    '******************************************************************************
    '*　概　要：実行ボタン押下時の処理
    '*　備　考：
    '******************************************************************************
    Private Sub btnTelEnt_ServerClick(ByVal sender As System.Object, _
                                    ByVal e As System.EventArgs) Handles btnTelEnt.ServerClick
        Dim KETAIJAW00C As New KETAIJAG00KETAIJAW00.KETAIJAW00()
        Dim strRec As String
        Dim strRENTEL2_UPD_DATE As String
        Dim strRENTEL3_UPD_DATE As String
        Dim strUpdDate As String
        strRENTEL2_UPD_DATE = txtRENTEL2_UPD_DATE.Text
        strRENTEL3_UPD_DATE = txtRENTEL3_UPD_DATE.Text
        strRec = KETAIJAW00C.mUpd_SHAMAS(hdnKURACD.Value, _
                                         hdnACBCD.Value, _
                                         hdnUSER_CD.Value, _
                                         txtRENTEL2.Text, _
                                         txtRENTEL2_BIKO.Text, _
                                         txtRENTEL3.Text, _
                                         txtRENTEL3_BIKO.Text _
                                         )
        Select Case Left(strRec, 2)
            Case "OK"   '//正常終了
                strMsg.Append("parent.opener.frames('data').Form1.hdnRENTEL2.value = '" & txtRENTEL2.Text.Replace("-", "") & "';" & vbCrLf)
                strMsg.Append("parent.opener.frames('data').Form1.hdnRENTEL2_BIKO.value = '" & txtRENTEL2_BIKO.Text & "';" & vbCrLf)
                strMsg.Append("parent.opener.frames('data').Form1.hdnRENTEL3.value = '" & txtRENTEL3.Text.Replace("-", "") & "';" & vbCrLf)
                strMsg.Append("parent.opener.frames('data').Form1.hdnRENTEL3_BIKO.value = '" & txtRENTEL3_BIKO.Text & "';" & vbCrLf)
                strUpdDate = ""
                strUpdDate = strRec.Substring(2, 8)
                Dim strRentelUpd As String = strRec.Substring(10, 1)
                'strMsg.Append("alert('" & strRec & "_" & strUpdDate & "_" & strRentelUpd & "')" & vbCrLf)
                If strRentelUpd = "1" Or strRentelUpd = "2" Then
                    If strUpdDate <> "" Then
                        txtRENTEL2_UPD_DATE.Text = strUpdDate.Substring(0, 4) & "/" & strUpdDate.Substring(4, 2) & "/" & strUpdDate.Substring(6, 2)
                    Else
                        txtRENTEL2_UPD_DATE.Text = strUpdDate
                    End If
                    strMsg.Append("parent.opener.frames('data').Form1.hdnRENTEL2_UPD_DATE.value = '" & strUpdDate & "';" & vbCrLf)
                Else
                    strMsg.Append("parent.opener.frames('data').Form1.hdnRENTEL2_UPD_DATE.value = '" & txtRENTEL2_UPD_DATE.Text.Replace("/", "") & "';" & vbCrLf)
                End If
                If strRentelUpd = "1" Or strRentelUpd = "3" Then
                    If strUpdDate <> "" Then
                        txtRENTEL3_UPD_DATE.Text = strUpdDate.Substring(0, 4) & "/" & strUpdDate.Substring(4, 2) & "/" & strUpdDate.Substring(6, 2)
                    Else
                        txtRENTEL3_UPD_DATE.Text = strUpdDate
                    End If
                    strMsg.Append("parent.opener.frames('data').Form1.hdnRENTEL3_UPD_DATE.value = '" & strUpdDate & "';" & vbCrLf)
                Else
                    strMsg.Append("parent.opener.frames('data').Form1.hdnRENTEL3_UPD_DATE.value = '" & txtRENTEL3_UPD_DATE.Text.Replace("/", "") & "';" & vbCrLf)
                End If
                Dim teljvg As String = ""
                If rdoTel1_2.Checked = True Then
                    teljvg = "2"
                ElseIf rdoTel1_3.Checked = True Then
                    teljvg = "3"
                End If
                strMsg.Append("parent.opener.frames('data').Form1.hdnTelJVG.value = '" & teljvg & "';" & vbCrLf)
                strMsg.Append("alert('正常に終了しました。')" & vbCrLf)
                'strMsg.Append("parent.opener.frames('data').Form1.btnTelHas2.focus();" & vbCrLf)
                'strMsg.Append("window.close();" & vbCrLf)
            Case "N1"   '//データ無し
                strMsg.Append("alert('データが存在しません。')" & vbCrLf)
                strMsg.Append("document.getElementById('btnTelEnt').focus();" & vbCrLf)
            Case "N2"   '//変更無し
                strMsg.Append("alert('変更がありません。')" & vbCrLf)
                strMsg.Append("document.getElementById('btnTelEnt').focus();" & vbCrLf)
            Case Else
                Dim ErrMsgC As New CErrMsg
                strMsg.Append("alert('システムエラー：" & ErrMsgC.mGetArtMsg(strRec) & "');")
        End Select
        KETAIJAW00C = Nothing

    End Sub
    ''**********************************************************
    '' 2012/06/28 ADD W.GANEKO
    ''ログ吐き出し
    ''戻り値：書き込んだファイルへのフルパス
    ''**********************************************************
    'Public Sub mlog(ByVal pstrString As String)
    '    Dim strFilnm As String = "log" & System.DateTime.Today.ToString("yyyyMMdd")
    '    Dim strLogPath As String = ConfigurationSettings.AppSettings("LOG_OUT_PATH")
    '    Dim strPath As String = strLogPath & strFilnm & ".txt"
    '    Dim strLogFlg As String = ConfigurationSettings.AppSettings("LOG_OUT")
    '    If strLogFlg = "1" Then
    '        '書き込みファイルへのストリーム
    '        Dim outFile As New StreamWriter(strPath, True, System.Text.Encoding.Default)

    '        '引数の文字列をストリームに書き込み
    '        outFile.Write(System.DateTime.Now & "|" & pstrString + vbCrLf)

    '        'メモリフラッシュ（ファイル書き込み）
    '        outFile.Flush()

    '        'ファイルクローズ
    '        outFile.Close()
    '    End If
    'End Sub
End Class
