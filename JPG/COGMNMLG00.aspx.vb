Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common '2014/02/26 T.Ono add �Ď����P2013

Imports System.Text

Partial Class COGMNMLG00
    Inherits System.Web.UI.Page

    '******************************************************************************
    ' HttpHeader
    '******************************************************************************
    Protected HttpHeaderC As New CHttpHeader

    '<TODO>�錾���ʎd�l
    '******************************************************************************
    ' �F�؃N���X�@2014/02/26 T.Ono add �Ď����P2013
    '******************************************************************************
    Protected AuthC As CAuthenticate

    '<TODO>�錾���ʎd�l
    '******************************************************************************
    ' ScriptMessage�@2014/02/26 T.Ono add �Ď����P2013
    '******************************************************************************
    Private strMsg As New StringBuilder("")

    '<TODO>�錾���ʎd�l
    '******************************************************************************
    ' Render�@2014/02/26 T.Ono add �Ď����P2013
    '******************************************************************************
    Protected Overrides Sub Render(ByVal writer As HtmlTextWriter)
        MyBase.Render(writer)

        Dim strWrite As New StringBuilder("")

        strWrite.Append("<script language='JavaScript'>")
        strWrite.Append(strMsg.ToString())
        strWrite.Append("</script>")
        writer.Write(strWrite.ToString())
    End Sub

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

    '******************************************************************************
    ' �}�X�^�ꗗ���j���[
    '******************************************************************************
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '//------------------------------------------
        '//�@HTTP�w�b�_�𑗐M
        HttpHeaderC.mNoCache(Response)

        '2014/02/06 T.Ono add �Ď����P2013 ���[�U�[�����m�F ----------START
        '//------------------------------------------
        '//�@�F�؃N���X�̃C���X�^���X����
        AuthC = New CAuthenticate(Request, Response)

        Dim strGROUPNAME As String = AuthC.pGROUPNAME
        Dim arrGroupName() As String = strGROUPNAME.Split(Convert.ToChar(","))
        Dim bolKANSHI_FLG As Boolean = False
        Dim arrKanshiGroup() As String = AuthC.pGROUP_KANSHI.Split(Convert.ToChar(","))
        Dim i As Integer
        Dim bolUNKOU_FLG As Boolean = False
        Dim arrUnkouGroup() As String = AuthC.pGROUP_UNKOU.Split(Convert.ToChar(","))

        '>>�^�s�J���������`�F�b�N
        For i = 0 To arrUnkouGroup.Length - 1
            If Array.IndexOf(arrGroupName, arrUnkouGroup(i)) >= 0 Then
                bolUNKOU_FLG = True
                Exit For
            End If
        Next i

        '>>�Ď��Z���^�[�����`�F�b�N
        If bolUNKOU_FLG = False Then
            For i = 0 To arrKanshiGroup.Length - 1
                If Array.IndexOf(arrGroupName, arrKanshiGroup(i)) >= 0 Then
                    bolKANSHI_FLG = True
                    Exit For
                End If
            Next i
        End If
        '2014/02/26 T.Ono add �Ď����P2013 ���[�U�[�����m�F ----------END


        '//------------------------------------------
        '// Script�����ݗp�ϐ��錾
        Dim strScript As New StringBuilder("")
        Dim cscript1 As New CScript
        Dim strScriptPath As String
        strScriptPath = ConfigurationSettings.AppSettings("SCRIPTPATH")

        '//JavaScript----------------------------------
        strScript.Append(vbCrLf)
        strScript.Append("<Script language=javascript>" & vbCrLf)
        '<���j���[��ʋ��ʊ֐�>
        strScript.Append(cscript1.mWriteScript(MyBase.MapPath("./") & "COGBASEG00.js") & vbCrLf)
        strScript.Append("</Script>" & vbCrLf)

        '//Css-----------------------------------------
        strScript.Append("<Style>" & vbCrLf)
        '<���ʃN���X>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "CssData.css") & vbCrLf)
        '<���j���[��ʋ��ʃN���X>
        strScript.Append(cscript1.mWriteScript(MyBase.MapPath("./") & "COGBASEG00.css") & vbCrLf)
        strScript.Append("</Style>" & vbCrLf)

        lblScript.Text = strScript.ToString

        '2014/02/26 T.Ono add �Ď����P2013 ���O�C�����[�U�[�ɂ��A�{�^���̕\���E��\���𐧌� ----------START
        If bolUNKOU_FLG = True Then
            '�^�s�J����
        ElseIf bolKANSHI_FLG = True Then
            '�Ď��Z���^�[
            strMsg.Append("fncDispMNML(0);")
        End If
        '2014/02/26 T.Ono add �Ď����P2013 ���O�C�����[�U�[�ɂ��A�{�^���̕\���E��\���𐧌� ----------END

    End Sub

End Class
