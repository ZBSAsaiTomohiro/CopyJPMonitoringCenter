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

    '<TODO>�錾���ʎd�l
    '******************************************************************************
    ' �F�؃N���X     2013/07/09 T.Ono add
    '******************************************************************************
    Protected AuthC As CAuthenticate

#Region " Web �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h "

    '���̌Ăяo���� Web �t�H�[�� �f�U�C�i�ŕK�v�ł��B
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    '���� : ���̃v���[�X�z���_�錾�� Web �t�H�[�� �f�U�C�i�ŕK�v�ł��B
    '�폜����шړ����Ȃ��ł��������B
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        ' CODEGEN: ���̃��\�b�h�Ăяo���� Web �t�H�[�� �f�U�C�i�ŕK�v�ł��B
        ' �R�[�h �G�f�B�^���g���ĕύX���Ȃ��ł��������B
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '//------------------------------------------
        '//�@HTTP�w�b�_�𑗐M
        HttpHeaderC.mNoCache(Response)

        '//------------------------------------------
        '//�@�F�؃N���X�̃C���X�^���X����     2013/07/09 T.Ono add
        AuthC = New CAuthenticate(Request, Response)
        '//------------------------------------------
        '// Script�����ݗp�ϐ��錾
        Dim strScript As New StringBuilder("")
        Dim CTI_NO_VALUE As String = ""

        If IsNothing(Request.QueryString("CTINO")) = True Then
            '//�ʏ�̃��j���[���o�͂���
            CTI_NO_VALUE = ""
        ElseIf Convert.ToString(Request.QueryString("CTINO")).Length > 0 Then
            CTI_NO_VALUE = "?CTINO=" & Request.QueryString("CTINO")
        Else
            '//�ʏ�̃��j���[���o�͂���
            CTI_NO_VALUE = ""
        End If

        strScript.Append("<script language=javascript>")
        '--- ��2005/04/29 DEL Falcon�� ---
        ''''strScript.Append("var obj;")
        ''''strScript.Append("obj=document.referrer;")
        ''''strScript.Append("if (obj!=''){")
        ''''strScript.Append("parent.location.href='COGBASEG00.aspx';")
        ''''strScript.Append("}")
        ''''strScript.Append("var uAgent = navigator.userAgent.toUpperCase();")
        ''''strScript.Append("if (uAgent.indexOf('WINDOWS CE') < 0){")
        ''''strScript.Append("if((opener==null)&&(obj=='')){")
        '--- ��2005/04/29 DEL Falcon�� ---
        ' 2013/07/09 T.Ono mod Start
        'strScript.Append("window.open('COGBASEG00.aspx" & CTI_NO_VALUE & "','','toolbar=no,location=no,directories=no,status=no,menubar=yes,scrollbars=yes,scrollbars=yes,resizable=yes,top=0,left=0,width=1024,height=768');")
        If InStr(AuthC.pGROUPNAME, "0�Ď��Ɩ��P��") > 0 Then
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
        '--- ��2005/04/29 DEL Falcon�� ---
        ''''strScript.Append("}")
        ''''strScript.Append("}")
        '--- ��2005/04/29 DEL Falcon�� ---
        strScript.Append("</script>")


        lblScript.Text = strScript.ToString
    End Sub

End Class
