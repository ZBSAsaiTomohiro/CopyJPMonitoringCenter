'***********************************************
'工事受注システム　メイン画面
'***********************************************
'<TODO>宣言共通仕様
Option Explicit On
Option Strict On

'<TODO>宣言共通仕様
Imports Common
Imports JPG.Common
Imports JPG.Common.log

Imports System.Text     '：StringBuilderを使用するため
Imports System.Web.Security

Partial Class COLOGING00
    Inherits System.Web.UI.Page

    Protected ConstC As New CConst

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

    '******************************************************************************
    ' Page_Load
    '******************************************************************************
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '//------------------------------------------
        '//　HTTPヘッダを送信
        HttpHeaderC.mNoCache(Response)

        '//------------------------------------------
        '// Script書込み用変数宣言
        Dim strScript As New StringBuilder("")

        '//画面の出力プロパティを制御する-------
        strScript.Append("<script language=javascript>")
        '--- ↓2005/04/29 DEL Falcon↓ ---
        'strScript.Append("var obj;")
        'strScript.Append("obj=document.referrer;")
        'strScript.Append("if (obj!=''){")
        'strScript.Append("parent.location.href='COGBASEG00.aspx';")
        'strScript.Append("}")
        'strScript.Append("var uAgent = navigator.userAgent.toUpperCase();")
        'strScript.Append("if (uAgent.indexOf('WINDOWS CE') < 0){")
        'strScript.Append("if((opener==null)&&(obj=='')){")
        '--- ↑2005/04/29 DEL Falcon↑ ---
        strScript.Append("if(opener==null){")
        strScript.Append("window.open('COGBASEG00.aspx','','toolbar=no,location=no,directories=no,status=no,menubar=yes,scrollbars=yes,scrollbars=yes,resizable=yes,top=0,left=0,width=1024,height=768');")
        strScript.Append("window.opener=true;")
        strScript.Append("(window.open('','_self').opener=window).close();")        '2012/06/26 NEC ou Add
        'strScript.Append("window.close();")                                        '2012/06/26 NEC ou Del
        strScript.Append("}")
        '--- ↓2005/04/29 DEL Falcon↓ ---
        'strScript.Append("}")
        '--- ↑2005/04/29 DEL Falcon↑ 
        strScript.Append("</script>")
        '//-------------------------------------

        Dim cscript1 As New CScript
        Dim strScriptPath As String
        strScriptPath = ConfigurationSettings.AppSettings("SCRIPTPATH")

        '------------------------------------------------------------------------------
        '<TODO>HTML内に必要なJavaScript/CSSはここで[strScript]変数に格納後
        '      画面上[lblScript]に書き込みを行います(SPANタグとしてクライアントにスクリプトが
        '      出力されます。)
        '      [lblScript(Label)]を作成する事
        '//------------------------------------------
        '//　JavaScript格納
        strScript.Append("<Script language=javascript>")
        '<フォーカス関連関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncFo.js"))
        strScript.Append("</Script>")
        '//------------------------------------------
        '//　Css格納
        strScript.Append("<Style>")
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "CssData.css"))
        strScript.Append("</Style>")
        '//------------------------------------------
        '//　Script書込み
        lblScript.Text = strScript.ToString

        '//-------------------------------------------------
        '<TODO>自分の画面IDをHIDDENのhdnMyAspxに書き込む（システム共通）
        hdnMyAspx.Value = "COLOGING00"
        '//-------------------------------------------------

        '//-------------------------------------------------
        '//  出動確認からの戻り遷移がある為、この画面を出力する前に認証を削除する
        FormsAuthentication.SignOut()

        '//------------------------------------------------
        'フォーカスをセットする
        strMsg.Append("Form1.txtSHUTU_CD.focus();")

        '//------------------------------------------------
        '//監視センターからの遷移の場合、それを制御する為に画面ＩＤを分ける
        If MyBase.IsPostBack = False Then
            '//--------------------------------------
            '//初めて開いた時だけ実行される
            Dim strIPADDRESS As String = Request.ServerVariables("REMOTE_ADDR")     '//IPアドレス
            '//hdnLOGIN_FLG 0:通常出動会社　1:監視センター
            If Request.Form("hdnMyAspx") = "SDLOGJAG00" Or Request.Form("hdnLOGIN_FLG") = "1" Then
                '-------------------------------------------------
                '//ＡＰログ書き込み
                Dim LogC As New CLog
                Dim strRecLog As String
                '2012/04/06 NEC ou Upd Str
                'strRecLog = LogC.mAPLog(Request.Cookies.Get("ASP.NET_SessionId").Value, Request.Form("hdnUSERCD"), strIPADDRESS, hdnMyAspx.Value, "4", "監視センターログイン", Request.Form)
                strRecLog = LogC.mAPLog(Me.Session.SessionID, Request.Form("hdnUSERCD"), strIPADDRESS, hdnMyAspx.Value, "4", "監視センターログイン", Request.Form)
                '2012/04/06 NEC ou Upd End
                If strRecLog <> "OK" Then
                    Dim errmsgc As New CErrMsg
                    strMsg.Append("alert('システムエラー：" & errmsgc.mGetArtMsg(strRecLog) & "');")
                    Exit Sub
                End If

                'ログインを行なう
                '-------------------------------------------------
                '//一度サインアウトして
                FormsAuthentication.Initialize()
                '//認証済みにして
                FormsAuthentication.SetAuthCookie(Request.Form("hdnUSERCD"), False)
                '//クッキーにセット(キーにはユーザーコードを引き渡す)
                Call fncSetCookie(Convert.ToString(Request.Form("hdnUSERCD")), "1")

                '//ログイン画面の次ページは緊急出動一覧
                Response.Redirect("COGBASEG00.aspx")
            End If
        End If
    End Sub

    '******************************************************************************
    ' 
    '******************************************************************************
    Private Sub btnLogon_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogon.ServerClick
        Dim strRec As String

        Dim strShutu_cd As String = txtSHUTU_CD.Value                           '//出動会社コード
        Dim strKyoten_cd As String = txtKYOTEN_CD.Value                         '//拠点コード
        Dim strUserPass As String = txtUserPass.Value                           '//パスワード
        Dim strIPADDRESS As String = Request.ServerVariables("REMOTE_ADDR")     '//IPアドレス

        Dim LogC As New CLog
        Dim strRecLog As String

        Try
            If strShutu_cd.Length = 0 Or strKyoten_cd.Length = 0 Or strUserPass.Length = 0 Then
                strRec = "出動会社コード、拠点コードまたはパスワードが違います。"
                Exit Try
            End If

            '//検索処理を行う
            Dim SQLC As New JPSDCSQL.CSQL
            Dim SqlParamC As New CSQLParam
            Dim strSQL As New StringBuilder("")
            Dim ds As New DataSet

            '//SQL文の作成
            strSQL.Append("SELECT ")
            strSQL.Append("SHUTU_CD, ")
            strSQL.Append("KYOTEN_CD, ")
            strSQL.Append("PASSWD ")
            strSQL.Append("FROM  SHUTUDOMAS ")
            strSQL.Append("WHERE SHUTU_CD = :SHUTU_CD ")
            strSQL.Append("  AND KYOTEN_CD = :KYOTEN_CD ")
            strSQL.Append("  AND PASSWD = :PASSWD ")

            SqlParamC.fncSetParam("SHUTU_CD", True, strShutu_cd)
            SqlParamC.fncSetParam("KYOTEN_CD", True, strKyoten_cd)
            SqlParamC.fncSetParam("PASSWD", True, strUserPass)

            ds = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

            If ds.Tables(0).Rows.Count = 0 Then
                '//データが１件も無かったら画面上のメッセージフィールドにメッセージ表示
                strRec = "出動会社コード、拠点コードまたはパスワードが違います。"
                Exit Try
            Else
                '//データがあったら
                '//コードがXYZだったら
                If Convert.ToString(ds.Tables(0).Rows(0).Item(0)) = "XYZ" Then
                    strRec = "出動会社コード、拠点コードまたはパスワードが違います。"
                    Exit Try
                Else
                    If txtSHUTU_CD.Value = Convert.ToString(ds.Tables(0).Rows(0).Item("SHUTU_CD")) And _
                        txtKYOTEN_CD.Value = Convert.ToString(ds.Tables(0).Rows(0).Item("KYOTEN_CD")) And _
                        txtUserPass.Value = Convert.ToString(ds.Tables(0).Rows(0).Item("PASSWD")) Then
                        '-------------------------------------------------
                        strRec = "ログイン正常終了"

                        '-------------------------------------------------
                        '//ＡＰログ書き込み ★認証ＯＫ時のログ出力★
                        '2012/04/06 NEC ou Upd Str
                        'strRecLog = LogC.mAPLog(Request.Cookies.Get("ASP.NET_SessionId").Value, strShutu_cd & "-" & strKyoten_cd, strIPADDRESS, hdnMyAspx.Value, "4", strRec, Request.Form)
                        strRecLog = LogC.mAPLog(Me.Session.SessionID, strShutu_cd & "-" & strKyoten_cd, strIPADDRESS, hdnMyAspx.Value, "4", strRec, Request.Form)
                        '2012/04/06 NEC ou Upd End
                        If strRecLog <> "OK" Then
                            Dim errmsgc As New CErrMsg
                            strMsg.Append("alert('システムエラー：" & errmsgc.mGetArtMsg(strRecLog) & "');")
                            Exit Sub
                        End If

                        '-------------------------------------------------
                        txtUserPass.Value = Convert.ToString(ds.Tables(0).Rows(0).Item("PASSWD"))
                        '//一度サインアウトして
                        FormsAuthentication.Initialize()
                        '//認証済みにして
                        FormsAuthentication.SetAuthCookie(txtSHUTU_CD.Value, False)
                        '//クッキーにセット
                        Call fncSetCookie(Convert.ToString(ds.Tables(0).Rows(0).Item("SHUTU_CD")), "0")
                        '//ログイン画面の次ページは緊急出動一覧
                        Response.Redirect("COGBASEG00.aspx")

                        Exit Sub
                    Else
                        '//ユーザ名かパスワードが違っていたら
                        strRec = "ユーザーコードまたはパスワードが違います。"
                        Exit Try
                    End If
                End If
            End If

            '//クッキーにセット
            Call fncSetCookie(Convert.ToString(ds.Tables(0).Rows(0).Item("SHUTU_CD")), "0")

        Catch ex As Exception

        End Try

        '-------------------------------------------------
        '//メッセージの出力
        lblMsg.Text = strRec

        '-------------------------------------------------
        '//ＡＰログ書き込み ★認証エラー時のログ出力★
        '2012/04/06 NEC ou Upd Str
        'strRecLog = LogC.mAPLog(Request.Cookies.Get("ASP.NET_SessionId").Value, strShutu_cd & "-" & strKyoten_cd, strIPADDRESS, hdnMyAspx.Value, "4", strRec, Request.Form)
        strRecLog = LogC.mAPLog(Me.Session.SessionID, strShutu_cd & "-" & strKyoten_cd, strIPADDRESS, hdnMyAspx.Value, "4", strRec, Request.Form)
        '2012/04/06 NEC ou Upd End
        If strRecLog <> "OK" Then
            Dim errmsgc As New CErrMsg
            strMsg.Append("alert('システムエラー：" & errmsgc.mGetArtMsg(strRecLog) & "');")
        End If

    End Sub

    '******************************************************************************
    ' 
    '******************************************************************************
    Private Sub fncSetCookie(ByVal pstrHCY_CD As String, ByVal pstrFLG As String)
        'カウンタ
        Dim i As Integer
        Dim intFlg As Integer = 0
        Dim array() As String

        'クッキーコレクション
        Dim MyCookieColl As HttpCookieCollection
        '現在のクッキーコレクションを変数に格納
        MyCookieColl = Request.Cookies
        'クッキーコレクション内のすべてのキーを配列に格納
        array = MyCookieColl.AllKeys()

        '配列の最後までループ
        For i = 0 To array.GetUpperBound(0)
            '既にキーがセットしてあるかどうか、HCY_CDキーの有無で判断する
            If MyCookieColl(i).Name = ConstC.pCookie_SD_Logincd Then
                'キーがセットしてるかどうかの判断フラグ
                intFlg = 1
                Exit For
            End If
        Next
        Dim ckSHUTU_CD As HttpCookie        '出動会社コード
        Dim ckKYOTEN_CD As HttpCookie       '拠点コード
        Dim ckCENTCD As HttpCookie          '使用可能監視センターコード

        If intFlg = 0 Then
            'キーがセットされていなかったら
            '新しいキーを作る
            ckSHUTU_CD = New HttpCookie(ConstC.pCookie_SD_Logincd)
            ckKYOTEN_CD = New HttpCookie(ConstC.pCookie_SD_Kyotencd)
            '監視センターからのログインとして
            ckCENTCD = New HttpCookie(ConstC.pCookie_SD_ALLCenter)
        Else
            'キーがセットされていたら
            'そのキーを変数に格納
            ckSHUTU_CD = MyCookieColl(ConstC.pCookie_SD_Logincd)
            ckKYOTEN_CD = MyCookieColl(ConstC.pCookie_SD_Kyotencd)
            '監視センターからのログインとして
            ckCENTCD = MyCookieColl(ConstC.pCookie_SD_ALLCenter)
        End If

        ckSHUTU_CD.Value = pstrHCY_CD
        ckKYOTEN_CD.Value = Request.Form("txtKYOTEN_CD")
        '監視センターからのログインとして
        ckCENTCD.Value = Request.Form("hdnCENTERCD")

        'クッキーに戻す
        Response.Cookies.Add(ckSHUTU_CD)
        Response.Cookies.Add(ckKYOTEN_CD)
        Response.Cookies.Add(ckCENTCD)
    End Sub
End Class
