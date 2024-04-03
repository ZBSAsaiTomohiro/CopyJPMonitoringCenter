'***********************************************
'監視対応数集計表  件数確認
'***********************************************
Option Explicit On
'Option Strict On

Imports Common
Imports JPG.Common
Imports JPG.Common.log

Imports System.Text

Partial Class KERUIJCG00
    Inherits System.Web.UI.Page

    '******************************************************************************
    ' HttpHeader
    '******************************************************************************
    Protected HttpHeaderC As New CHttpHeader

    '******************************************************************************
    ' 親画面クラス
    '******************************************************************************
    Protected KERUIJOG00C As KERUIJOG00

    '<TODO>宣言共通仕様
    '******************************************************************************
    ' 認証クラス
    '******************************************************************************
    Protected AuthC As CAuthenticate

    '******************************************************************************
    ' クッキー
    '******************************************************************************
    Protected ConstC As New CConst

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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If True Then
            '//------------------------------------------
            '//　HTTPヘッダを送信
            HttpHeaderC.mNoCache(Response)

            '//<TODO>Transferしてきた親のハンドルを引き継ぐ
            KERUIJOG00C = CType(Context.Handler, KERUIJOG00)

            Dim strRec As String
            Dim strRecMsg As String
            Dim KERUIJCG00C As New KERUIJOG00KERUIJOW00.KERUIJOW00
            '2015/11/04 w.ganeko 2015改善開発 №6 start
            'strRec = KERUIJCG00C.mCheck( _
            '                       KERUIJOG00C.pKuracd, _
            '                       KERUIJOG00C.pKyocd, _
            '                       KERUIJOG00C.pJacd, _
            '                       KERUIJOG00C.pJascd, _
            '                       KERUIJOG00C.pHatKbn, _
            '                       KERUIJOG00C.pYmdFrom, _
            '                       KERUIJOG00C.pYmdTo, _
            '                       ConstC.pPageMax _
            '                       )
            '2017/02/15 H.Mori mod 改善2016 No9-1 START
            'strRec = KERUIJCG00C.mCheck( _
            '                        KERUIJOG00C.pKuracd, _
            '                        KERUIJOG00C.pKyocd, _
            '                        KERUIJOG00C.pJacdFr, _
            '                        KERUIJOG00C.pJacdTo, _
            '                        KERUIJOG00C.pJascdFr, _
            '                        KERUIJOG00C.pJascdTo, _
            '                        KERUIJOG00C.pHatKbn, _
            '                        KERUIJOG00C.pYmdFrom, _
            '                        KERUIJOG00C.pYmdTo, _
            '                        ConstC.pPageMax, _
            '                        KERUIJOG00C.pHanbaiFr, _
            '                        KERUIJOG00C.pHanbaiTo, _
            '                        KERUIJOG00C.pTaiKbn, _
            '                        KERUIJOG00C.pHkKbn _
            '                        )
            '2015/11/04 w.ganeko 2015改善開発 №6 end
            strRec = KERUIJCG00C.mCheck( _
                                    KERUIJOG00C.pKuracd, _
                                    KERUIJOG00C.pKyocd, _
                                    KERUIJOG00C.pJacdFr, _
                                    KERUIJOG00C.pJacdTo, _
                                    KERUIJOG00C.pJascdFr, _
                                    KERUIJOG00C.pJascdTo, _
                                    KERUIJOG00C.pHatKbn, _
                                    KERUIJOG00C.pYmdFrom, _
                                    KERUIJOG00C.pYmdTo, _
                                    ConstC.pPageMax, _
                                    KERUIJOG00C.pHanbaiFr, _
                                    KERUIJOG00C.pHanbaiTo, _
                                    KERUIJOG00C.pTaiKbn, _
                                    KERUIJOG00C.pHkKbn, _
                                    KERUIJOG00C.pKikankbn, _
                                    KERUIJOG00C.pTimeFrom, _
                                    KERUIJOG00C.pTimeTo _
                                    )
            '2017/02/15 H.Mori mod 改善2016 No9-1 END
            If strRec = "DATA0" Then
                'データが0件の場合
                strRecMsg = "対象データが存在しません"
                strMsg.Append("alert('" & strRecMsg & "');" & vbCrLf)
                strMsg.Append("parent.Data.Form1.btnSelect.focus();" & vbCrLf)

            ElseIf strRec = "DATAMAX" Then
                strRec = "CHK"
                '存在する為、上書きの確認を行う
                strMsg.Append(vbCrLf)
                strMsg.Append("function fncChkMessage(){" & vbCrLf)
                strMsg.Append("var strRes;" & vbCrLf)
                strMsg.Append("strRes = confirm('最大出力件数を超えました。\n出力しますか？');" & vbCrLf)
                strMsg.Append("if (strRes==false){" & vbCrLf)
                strMsg.Append("  parent.Data.Form1.btnSelect.disabled = false;")     '//制御を戻す
                strMsg.Append("  return;" & vbCrLf)
                strMsg.Append("}" & vbCrLf)
                strMsg.Append("" & vbCrLf)
                strMsg.Append("parent.Data.doPostBack('btnSelect','');" & vbCrLf)
                strMsg.Append("}" & vbCrLf)
                strMsg.Append("window.onload = fncChkMessage;" & vbCrLf)
                strMsg.Append(vbCrLf)
            Else
                strMsg.Append("try{" & vbCrLf)
                'strMsg.Append("alert('KERUIJCG00 001');" & vbCrLf)
                strMsg.Append("parent.Data.doPostBack('btnSelect','');" & vbCrLf)
                'strMsg.Append("window.opener.parent.Data.doPostBack('btnSelect','');" & vbCrLf)
                'strMsg.Append("alert('KERUIJCG00 002');" & vbCrLf)
                strMsg.Append("}catch(e){alert('ERROR:' + e);}" & vbCrLf)
            End If
        Else
            Dim bytExcel() As Byte
            Dim objBasp As Object
            'KERUIJOG00TEST.xls
            HttpHeaderC.mDownLoadXLS(Response, "KERUIJOG00.xls")
            objBasp = Server.CreateObject("Basp21")
            'bytExcel = objBasp.BinaryRead(Server.MapPath("D:\TEMP\KERUIJOG00TEST.xls"))
            bytExcel = objBasp.BinaryRead("D:\TEMP\KERUIJOG00TEST.xls")
            objBasp = Nothing
            Response.AddHeader("Content-Length", CStr(UBound(bytExcel) + 1))
            Response.BinaryWrite(bytExcel)
        End If
    End Sub

End Class
