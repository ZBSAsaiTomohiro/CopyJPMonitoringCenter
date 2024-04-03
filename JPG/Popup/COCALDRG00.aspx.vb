Option Explicit On
Option Strict On

Imports Common

Imports System.Text

'******************************************************************************
' �|�b�v�A�b�v (�J�����_�[)
'******************************************************************************
' 2008/11/20 T.Watabe �u�Ď��Ή����W�v�\�v�p�ɋL�q�ǉ�

Partial Class COCALDRG00
    Inherits System.Web.UI.Page

    '******************************************************************************
    ' HttpHeader
    '******************************************************************************
    Protected HttpHeaderC As New CHttpHeader

    '******************************************************************************
    ' ScriptMessage
    '******************************************************************************
    Private strMsg As New StringBuilder("")      '//<script>�͕K�v�Ȃ�

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
    '<TODO>�@�\�ǉ����ɑΏۂ̃v���W�F�N�g��ǉ����Ă���
    Protected KEKEKJAG00_C As KEKEKJAG00.KEKEKJAG00
    Protected KERUIJOG00_C As KERUIJOG00.KERUIJOG00
    '/* 2006/05/24 ADD_BEGIN */
    Protected KETAISYG00_C As KETAISYG00.KETAISYG00  '/* �x��o�͎w����� */
    '/* 2006/05/24 ADD_END */
    Protected KEKANSYG00_C As KEKANSYG00.KEKANSYG00  '/* �Ď��Ή����W�v�\ ' 2008/11/20 T.Watabe add */
    Protected KESAIJAG00_C As KESAIJAG00.KESAIJAG00  '/* �ЊQ�Ή����[�@   ' 2020/01/06 T.Ono add */
    '-----------------------------------------------------------------------

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
    ' Page_Load
    '******************************************************************************
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                                                                Handles MyBase.Load
        '//------------------------------------------
        '//�@HTTP�w�b�_�𑗐M
        HttpHeaderC.mNoCache(Response)

        '//------------------------------------------
        '// Script�����ݗp�ϐ��錾
        Dim strScript As New StringBuilder("")
        Dim cscript1 As New CScript
        Dim strScriptPath As String
        strScriptPath = ConfigurationSettings.AppSettings("SCRIPTPATH")

        '------------------------------------------------------------------------------
        '<TODO>HTML���ɕK�v��JavaScript/CSS�͂�����[strScript]�ϐ��Ɋi�[��
        '      ��ʏ�[lblScript]�ɏ������݂��s���܂�(SPAN�^�O�Ƃ��ăN���C�A���g�ɃX�N���v�g��
        '      �o�͂���܂��B)
        '//------------------------------------------
        '//�@Css�i�[
        strScript.Append("<Style>")
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "CssPopup.css"))
        strScript.Append("</Style>")
        '//------------------------------------------
        '//�@Script������
        lblScript.Text = strScript.ToString

        '//--------------------------------------------------------------------------------
        If MyBase.IsPostBack = False Then
            '//--------------------------------------
            '//�@���߂ĊJ�������������s�����
            '------------------------------------------------------------------------------
            '<TODO>�@�\�ǉ����ɑΏۂ̃v���W�F�N�g��ǉ����Ă���
            If Request.Path.LastIndexOf("KEKEKJAG00") >= 0 Then
                KEKEKJAG00_C = CType(Context.Handler, KEKEKJAG00.KEKEKJAG00)
                hdnBackDate.Value = KEKEKJAG00_C.pBackDate
                hbdBackFocs.Value = KEKEKJAG00_C.pBackFocs
            End If

            If Request.Path.LastIndexOf("KERUIJOG00") >= 0 Then
                KERUIJOG00_C = CType(context.Handler, KERUIJOG00.KERUIJOG00)
                hdnBackDate.Value = KERUIJOG00_C.pBackDate
                hbdBackFocs.Value = KERUIJOG00_C.pBackFocs
            End If
            '/* 2006/05/24 ADD_BEGIN */
            If Request.Path.LastIndexOf("KETAISYG00") >= 0 Then
                KETAISYG00_C = CType(context.Handler, KETAISYG00.KETAISYG00)
                hdnBackDate.Value = KETAISYG00_C.pBackDate
                hbdBackFocs.Value = KETAISYG00_C.pBackFocs
            End If
            '/* 2006/05/24 ADD_END   */
            ' 2008/11/20 T.Watabe add
            If Request.Path.LastIndexOf("KEKANSYG00") >= 0 Then
                KEKANSYG00_C = CType(context.Handler, KEKANSYG00.KEKANSYG00)
                hdnBackDate.Value = KEKANSYG00_C.pBackDate
                hbdBackFocs.Value = KEKANSYG00_C.pBackFocs
            End If
            '�ЊQ�Ή����[�@2020/01/06 T.Ono add
            If Request.Path.LastIndexOf("KESAIJAG00") >= 0 Then
                KESAIJAG00_C = CType(Context.Handler, KESAIJAG00.KESAIJAG00)
                hdnBackDate.Value = KESAIJAG00_C.pBackDate
                hbdBackFocs.Value = KESAIJAG00_C.pBackFocs
            End If

            '�{���̓��t��I����Ԃŏo�͂��܂�------------------
            calender.SelectedDate = DateTime.Now

            '--------------------------------------------------
        Else
            '------------------------------------------------------------------------------
            '//Null
        End If

    End Sub

    '******************************************************************************
    ' �J�����_�[�̃N���b�N
    '******************************************************************************
    Private Sub calender_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                                                                Handles calender.SelectionChanged
        Dim strDate As String = Format(calender.SelectedDate, "yyyy/MM/dd")
        '//���t�̃Z�b�g
        If hdnBackDate.Value <> "" Then
            strMsg.Append("obj1=parent.opener.frames(""data"").document.getElementById(""" & hdnBackDate.Value & """);")
            strMsg.Append("obj1.value='" & strDate & "';")
        End If
        '// �t�H�[�J�X�̃Z�b�g
        If hbdBackFocs.Value <> "" Then
            strMsg.Append("obj2=parent.opener.frames(""data"").document.getElementById(""" & hbdBackFocs.Value & """);")
            strMsg.Append("obj2.focus();")
        End If
        strMsg.Append("window.close();")
    End Sub
End Class
