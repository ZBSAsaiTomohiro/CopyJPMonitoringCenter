'***********************************************
'累積情報一覧  件数確認
'***********************************************
Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common
Imports JPG.Common.log

Imports System.Text

Partial Class KEKANSCG00
    Inherits System.Web.UI.Page

    '******************************************************************************
    ' HttpHeader
    '******************************************************************************
    Protected HttpHeaderC As New CHttpHeader

    '******************************************************************************
    ' 親画面クラス
    '******************************************************************************
    Protected KEKANSYG00C As KEKANSYG00

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
        '//------------------------------------------
        '//　HTTPヘッダを送信
        HttpHeaderC.mNoCache(Response)

        '//<TODO>Transferしてきた親のハンドルを引き継ぐ
        KEKANSYG00C = CType(Context.Handler, KEKANSYG00)

        Dim strRec As String
        Dim strRecMsg As String
        Dim KEKANSCG00C As New KEKANSYG00KEKANSYW00.KEKANSYW00

        '2017/02/16 H.Mori mod 改善2016 No8-2 START
        '2015/02/09 H.Hosoda mod 監視改善2014 №14 Start
        'strRec = KEKANSCG00C.mCheck( _
        '                       KEKANSYG00C.pKuracd, _
        '                       KEKANSYG00C.pJacd, _
        '                       KEKANSYG00C.pYmdFrom, _
        '                       KEKANSYG00C.pYmdTo, _
        '                       ConstC.pPageMax _
        '                       )
        'strRec = KEKANSCG00C.mCheck( _
        '                       KEKANSYG00C.pKuracdFrom, _
        '                       KEKANSYG00C.pKuracdTo, _
        '                       KEKANSYG00C.pJacdFrom, _
        '                       KEKANSYG00C.pJacdTo, _
        '                       KEKANSYG00C.pHangrpFrom, _
        '                       KEKANSYG00C.pHangrpTo, _
        '                       KEKANSYG00C.pPgkbn, _
        '                       KEKANSYG00C.pHasseiTel, _
        '                       KEKANSYG00C.pHasseiKei, _
        '                       KEKANSYG00C.pTaiouTel, _
        '                       KEKANSYG00C.pTaiouShu, _
        '                       KEKANSYG00C.pTaiouJuf, _
        '                       KEKANSYG00C.pYmdFrom, _
        '                       KEKANSYG00C.pYmdTo, _
        '                       KEKANSYG00C.pTrgdatekbn, _
        '                       ConstC.pPageMax _
        '                       )
        '2015/02/09 H.Hosoda mod 監視改善2014 №14 End
        '2020/11/01 T.Ono mod 監視改善2020 Start
        'pTsadcd 追加
        strRec = KEKANSCG00C.mCheck(
                               KEKANSYG00C.pKuracdFrom,
                               KEKANSYG00C.pKuracdTo,
                               KEKANSYG00C.pJacdFrom,
                               KEKANSYG00C.pJacdTo,
                               KEKANSYG00C.pHangrpFrom,
                               KEKANSYG00C.pHangrpTo,
                               KEKANSYG00C.pPgkbn,
                               KEKANSYG00C.pHasseiTel,
                               KEKANSYG00C.pHasseiKei,
                               KEKANSYG00C.pTaiouTel,
                               KEKANSYG00C.pTaiouShu,
                               KEKANSYG00C.pTaiouJuf,
                               KEKANSYG00C.pYmdFrom,
                               KEKANSYG00C.pYmdTo,
                               KEKANSYG00C.pTrgdatekbn,
                               ConstC.pPageMax,
                               KEKANSYG00C.pTimeFrom,
                               KEKANSYG00C.pTimeTo,
                               KEKANSYG00C.pTsadcd
                               )
        '2017/02/16 H.Mori mod 改善2016 No8-2 END
        '2020/11/01 T.Ono mod 監視改善2020 End

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
            strMsg.Append("parent.Data.doPostBack('btnSelect','');" & vbCrLf)
        End If
    End Sub

End Class
