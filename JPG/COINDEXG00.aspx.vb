Option Explicit On
Option Strict On

Imports Common
Imports System.Text
Imports JPG.Common

Partial Class COINDEXG00
    Inherits System.Web.UI.Page
    '******************************************************************************
    ' HttpHeader
    '******************************************************************************
    Protected HttpHeaderC As New CHttpHeader

    '<TODO>宣言共通仕様
    '******************************************************************************
    ' 認証クラス     2013/07/09 T.Ono add
    '******************************************************************************
    Protected AuthC As CAuthenticate

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
        '//　認証クラスのインスタンス生成     2013/07/09 T.Ono add
        AuthC = New CAuthenticate(Request, Response)
        '//------------------------------------------
        '// Script書込み用変数宣言
        Dim strScript As New StringBuilder("")
        Dim CTI_NO_VALUE As String = ""

        If IsNothing(Request.QueryString("CTINO")) = True Then
            '//通常のメニューを出力する
            CTI_NO_VALUE = ""
        ElseIf Convert.ToString(Request.QueryString("CTINO")).Length > 0 Then
            CTI_NO_VALUE = "?CTINO=" & Request.QueryString("CTINO")
        Else
            '//通常のメニューを出力する
            CTI_NO_VALUE = ""
        End If

        strScript.Append("<script language=javascript>")
        '--- ↓2005/04/29 DEL Falcon↓ ---
        ''''strScript.Append("var obj;")
        ''''strScript.Append("obj=document.referrer;")
        ''''strScript.Append("if (obj!=''){")
        ''''strScript.Append("parent.location.href='COGBASEG00.aspx';")
        ''''strScript.Append("}")
        ''''strScript.Append("var uAgent = navigator.userAgent.toUpperCase();")
        ''''strScript.Append("if (uAgent.indexOf('WINDOWS CE') < 0){")
        ''''strScript.Append("if((opener==null)&&(obj=='')){")
        '--- ↑2005/04/29 DEL Falcon↑ ---
        ' 2013/07/09 T.Ono mod Start
        'strScript.Append("window.open('COGBASEG00.aspx" & CTI_NO_VALUE & "','','toolbar=no,location=no,directories=no,status=no,menubar=yes,scrollbars=yes,scrollbars=yes,resizable=yes,top=0,left=0,width=1024,height=768');")
        If InStr(AuthC.pGROUPNAME, "0監視業務単独") > 0 Then
            '            strScript.Append("window.open('COGBASEG00.aspx" & CTI_NO_VALUE & "','','toolbar=no,location=no,directories=no,status=no,menubar=yes,scrollbars=yes,scrollbars=yes,resizable=yes,top=0,left=0,width=1024,height=768');")
            strScript.Append("window.open('COGBASEG00.aspx" & CTI_NO_VALUE & "','','toolbar=no,location=no,directories=no,status=no,menubar=yes,scrollbars=yes,scrollbars=yes,resizable=yes,top=0,left=0,width=1400,height=800');")
        Else
            '            strScript.Append("window.open('COGBASEG00.aspx" & CTI_NO_VALUE & "','','toolbar=no,location=no,directories=no,status=no,menubar=yes,scrollbars=yes,scrollbars=yes,resizable=yes,top=0,left=0,width=1430,height=768');")
            strScript.Append("window.open('COGBASEG00.aspx" & CTI_NO_VALUE & "','','toolbar=no,location=no,directories=no,status=no,menubar=yes,scrollbars=yes,scrollbars=yes,resizable=yes,top=0,left=0,width=1500,height=800');")
        End If
        ' 2013/07/09 T.Ono mod End
        strScript.Append("window.opener=true;")
        strScript.Append("(window.open('','_self').opener=window).close();")        '2012/06/26 NEC ou Add
        'strScript.Append("window.close();")                                        '2012/06/26 NEC ou Del
        '--- ↓2005/04/29 DEL Falcon↓ ---
        ''''strScript.Append("}")
        ''''strScript.Append("}")
        '--- ↑2005/04/29 DEL Falcon↑ ---
        strScript.Append("</script>")


        lblScript.Text = strScript.ToString
    End Sub

End Class
