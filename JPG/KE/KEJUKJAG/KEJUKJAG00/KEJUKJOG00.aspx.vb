'***********************************************
'��M�x��\���p�l��  �f�[�^�x��o��
'***********************************************
Option Explicit On
Option Strict On

Imports Common
Imports System.Text
Imports JPG.Common
Imports System.IO
Imports System.Diagnostics
Imports JPG.Common.log

Partial Class KEJUKJOG00
    Inherits System.Web.UI.Page

    '******************************************************************************
    ' HttpHeader
    '******************************************************************************
    Protected HttpHeaderC As New CHttpHeader

    '******************************************************************************
    ' ScriptMessage
    '******************************************************************************
    Private strMsg As New StringBuilder("")      '//<script>�͕K�v�Ȃ�
    Protected AuthC As CAuthenticate
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
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '//------------------------------------------
        '//�@HTTP�w�b�_�𑗐M
        HttpHeaderC.mNoCache(Response)
        AuthC = New CAuthenticate(Request, Response)
        Dim lineno As String = New StackFrame(True).GetFileLineNumber.ToString
        mlog("[KEJUKJOG00 " & lineno & "]- Page_Load start")

        'webConfig�t�@�C����艺�L�f�[�^���擾���܂�
        '��WAV�t�@�C��URL
        '��WAV�t�@�C��LOOP��
        '��x��o�͎���(�b)
        Dim strWAVURL As String = ConfigurationSettings.AppSettings("WAVURL")
        Dim strWAVCNT As String = CStr(CInt(ConfigurationSettings.AppSettings("WAVCNT")))
        Dim strWAVSEC As String = CStr(CInt(ConfigurationSettings.AppSettings("WAVSEC")) * 1000)

        '�x��̏����Z�b�g
        strMsg.Append("document.write('<BGSOUND SRC=""" & strWAVURL & """ LOOP=""" & strWAVCNT & """>');")
        strMsg.Append("myTimer = setInterval('fncWav_end()'," & strWAVSEC & ");")

        '�t�H�[�J�X���Z�b�g���܂�(�ŐV�\��)�B
        strMsg.Append("obj1=parent.opener.frames('Data').document.getElementById('btnRenew');")
        strMsg.Append("obj1.focus();")

        '��ʂ��I�����܂�
        strMsg.Append("function fncWav_end(){")
        strMsg.Append(" window.close();")
        strMsg.Append("}")
        lineno = New StackFrame(True).GetFileLineNumber.ToString
        mlog("[KEJUKJOG00 " & lineno & "]- Page_Load end")

    End Sub
    '**********************************************************
    ' 2012/06/28 ADD W.GANEKO
    '���O�f���o��
    '�߂�l�F�������񂾃t�@�C���ւ̃t���p�X
    '**********************************************************
    Public Sub mlog(ByVal pstrString As String)
        Dim strFilnm As String = "log" & System.DateTime.Today.ToString("yyyyMMdd")
        Dim strLogPath As String = ConfigurationSettings.AppSettings("LOG_OUT_PATH")
        Dim strPath As String = strLogPath & strFilnm & ".txt"
        Dim strLogFlg As String = ConfigurationSettings.AppSettings("LOG_OUT")
        Dim LogC As New CLog
        Dim strRecLog As String
        Dim linestring As New StringBuilder("")
        If strLogFlg = "1" Then
            '�������݃t�@�C���ւ̃X�g���[��
            'Dim sw As StreamWriter
            'Dim fs As New FileStream(strPath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite)
            'linestring = New StringBuilder("")
            'linestring.Append(System.DateTime.Now & "." & System.DateTime.Now.Millisecond & "[" & AuthC.pUSERNAME & "][" & AuthC.pIPADDRESS & "][" & Me.Session.SessionID & "]" & pstrString & Chr(13) & Chr(10))
            Dim tbllog As String = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff") & " " & pstrString
            strRecLog = LogC.mAPLog(Me.Session.SessionID, AuthC.pUSERNAME, AuthC.pIPADDRESS, Request.Form("hdnMyAspx"), "4", tbllog, Request.Form)
            'sw = New StreamWriter(fs, System.Text.Encoding.Default)

            ''�����̕�������X�g���[���ɏ�������
            'sw.Write(linestring.ToString)

            ''�������t���b�V���i�t�@�C���������݁j
            ''sw.Flush()

            ''�t�@�C���N���[�Y
            'sw.Close()
            'sw.Dispose()
            'fs.Close()
            'fs.Dispose()
        End If
    End Sub
End Class
