'***********************************************
' JA�S���ҁE�A����E���ӎ����}�X�^  �t�@�C���_�E�����[�h
'***********************************************
Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common
Imports JPG.Common.log

Imports System.Text

Partial Class MSTAGJFG00
    Inherits System.Web.UI.Page

    '<TODO>�錾���ʎd�l
    '******************************************************************************
    ' HttpHeader
    '******************************************************************************
    Protected HttpHeaderC As New CHttpHeader

    '<TODO>�錾���ʎd�l
    '******************************************************************************
    ' �F�؃N���X
    '******************************************************************************
    Protected AuthC As CAuthenticate

    '<TODO>�錾���ʎd�l
    '******************************************************************************
    ' ScriptMessage
    '******************************************************************************
    Private strMsg As New StringBuilder("")

    '<TODO>�錾���ʎd�l
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

        '//------------------------------------------------------------------------------
        If MyBase.IsPostBack = False Then
            '//--------------------------------------
            '//���߂ĊJ�������������s�����
            fncFileDownload()

        Else
            '//--------------------------------------
            '//�@�Q��ڈȍ~���s�����
            '//--------------------------------------

        End If


    End Sub

    ' 2010/04/15 T.Watabe add
    '******************************************************************************
    '* �t�@�C���_�E�����[�h����
    '******************************************************************************
    Private Sub fncFileDownload()

        Dim sw As System.IO.Stream = Nothing
        Dim bw As System.IO.BinaryWriter = Nothing
        Dim dt As Byte()
        Dim fpath As String
        Dim sSaveFileName As String

        Try
            'sSaveFileName = "test.txt"
            'sSaveFileName = "test.gif"
            sSaveFileName = "test.xls"

            fpath = ConfigurationSettings.AppSettings("JA_TAN_MST_PATH") & sSaveFileName

            'sw = System.IO.File.Open(fpath, System.IO.FileMode.Create, System.IO.FileAccess.Write) 'Stream�Ńt�@�C�����J��
            'bw = New System.IO.BinaryWriter(sw) 'Stream��BinaryWriter�N���X�ŊJ��
            'bw.Write(dt) 'BinaryWriter�N���X���o�C�g�z��֏����o��

            'HttpHeaderC.mDownLoad(Response, "test.txt")
            'Response.BinaryWrite(dt) '�o�C�g�z������X�|���X�֏o��
            'Response.Flush()


            'Dim fs As New System.IO.FileStream(fpath, System.IO.FileMode.Open, System.IO.FileAccess.Read)
            ''If fs.Length > 0 Then
            'Dim br As New System.IO.BinaryReader(fs)
            '' Read data from Test.data.
            'dt = br.ReadBytes(CInt(fs.Length) - 1)
            'HttpHeaderC.mDownLoad(Response, "test.txt")
            'Response.BinaryWrite(dt) '�o�C�g�z������X�|���X�֏o��
            'Response.Flush()
            'br.Close()
            ''End If
            'fs.Close()
            'Response.End()

            'Response.ContentType = "application/octet-stream-dummy"
            'Response.WriteFile(fpath)
            'Response.End()
            'Response.ContentType = "image/gif"


            If System.IO.File.Exists(fpath) Then
                Response.Clear()
                If False Then
                    HttpHeaderC.mDownLoad(Response, sSaveFileName)
                    'Response.AddHeader("Content-Disposition", "inline;filename=" & sSaveFileName)
                    Response.ContentType = "application/octet-stream-dummy"
                    Response.WriteFile(fpath)
                    Response.End()
                End If

                Dim FileToStrC As New CFileStr                  '�t�@�C����Base64�ɃG���R�[�h����N���X
                Dim compressC As New CCompress                  '���k�N���X
                '���k��t�@�C���̂���t�H���_
                compressC.p_Dir = ConfigurationSettings.AppSettings("JA_TAN_MST_PATH")
                '���{��t�@�C�����̎w��
                compressC.p_NihongoFileName = sSaveFileName
                '���k���t�@�C����
                compressC.p_FileName = ConfigurationSettings.AppSettings("JA_TAN_MST_PATH") & sSaveFileName
                '���k��t�@�C����
                compressC.p_madeFilename = ConfigurationSettings.AppSettings("JA_TAN_MST_PATH") & sSaveFileName & ".lzh"
                '���k���s
                compressC.mCompress()
                '���k�����t�@�C����Base64�G���R�[�h���Ė߂�
                Dim strRec As String = FileToStrC.mFileToStr(compressC.p_madeFilename.Replace(".lzh", ".exe"))
                '�t�@�C�����́AHttpUtility.UrlEncode���\�b�h���g�p����SJIS�ɃG���R�[�h����K�v������
                HttpHeaderC.mDownLoad(Response, "�Ď��Ή����W�v�\.exe")

                'Web�T�[�r�X�̖߂�l�iBASE64�̃e�L�X�g�j���o�C�g�f�[�^�ɕϊ�����
                dt = Convert.FromBase64String(strRec)
                '�t�@�C�����M
                Response.BinaryWrite(dt)



            Else
                strMsg.Append("alert('" & "�Ώۃf�[�^�����݂��܂���" & "');")
                strMsg.Append("Form1.btnSelect.focus();")
            End If

            'Catch ex As Exception
            '    Throw ex
        Finally
            If bw Is Nothing = False Then bw.Close()
            If sw Is Nothing = False Then sw.Close()
        End Try
    End Sub
End Class
