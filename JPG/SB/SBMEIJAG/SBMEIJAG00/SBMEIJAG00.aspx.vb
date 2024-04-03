'***********************************************
' �������捞
'***********************************************
' �ύX����
' 2018/08/22 T.Ono
' 2019/11/01 T.Ono �Ď����P2019 CSV�捞�A�����V�[�g�捞
' 

Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common
Imports JPG.Common.log

Imports System.Text

Partial Class SBMEIJAG00
    Inherits System.Web.UI.Page

    '�{�^��

    '�e�L�X�g�{�b�N�X

    '�R���{�{�b�N�X

    '�`�F�b�N�{�b�N�X

    '��\���R���g���[��

    '******************************************************************************
    ' HttpHeader
    '******************************************************************************
    Protected HttpHeaderC As New CHttpHeader

    '<TODO>�錾���ʎd�l
    '******************************************************************************
    ' �F�؃N���X
    '******************************************************************************
    Protected AuthC As CAuthenticate

    '******************************************************************************
    ' �N�b�L�[
    '******************************************************************************
    Protected ConstC As New CConst

    '******************************************************************************
    ' ScriptMessage
    '******************************************************************************
    Private strMsg As New StringBuilder("")      '//<script>�͕K�v�Ȃ�

    Dim strFilepath As String '�I�������t�@�C���p�X

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
    Private Sub Page_Load(ByVal sender As System.Object, _
                                            ByVal e As System.EventArgs) Handles MyBase.Load

        '.NET�̎d�l�ύX�ɂ��AReadOnly������ASPX�ł���ƁA�T�[�o���Œl�̎Q�Ƃ��ł��Ȃ��Ȃ邽�߁AVB����Attribute�ł���
        If MyBase.IsPostBack = False Then
            '���͋֎~��txt������ΐݒ�

        End If

        '//------------------------------------------
        '//�@HTTP�w�b�_�𑗐M
        HttpHeaderC.mNoCache(Response)

        '//------------------------------------------
        '//�@�F�؃N���X�̃C���X�^���X����
        AuthC = New CAuthenticate(Request, Response)
        'AuthC.pCENTERCD()
        '//------------------------------------------
        '//�@�F�؏���
        '<TODO>�F�g�p�\�������w�肷��
        '[�x��o�͉��]�g�p�\����(�^:��/�c:��/��:��/�o:�~)
        AuthC.fncAuthCheck(Server, AuthC.pGROUP_UNKOU & "," & AuthC.pGROUP_KANSHI & "," & AuthC.pGROUP_EIGYOU)
        '//------------------------------------------
        '//�|�b�v�A�b�v�o��
        If hdnKensaku.Value = "COPOPUPG00" Then
            Server.Transfer("../../../Popup/COPOPUPG00.aspx")
        End If


        '//-----------------------------------------------
        '//���߂ĊJ�������������s�����
        If MyBase.IsPostBack = False Then
            'POST�f�[�^�̎擾�ϐ��̏�����
            Call fncGetPostIni()
        Else
            'POST�f�[�^�̎擾
            Call fncGetPost()
        End If
        '//-----------------------------------------------

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
        '//�@JavaScript�i�[
        strScript.Append("<Script language=javascript>")
        '<�Ǝ��X�N���v�g>
        strScript.Append(cscript1.mWriteScript(
             MyBase.MapPath("../../../SB/SBMEIJAG/SBMEIJAG00/") & "SBMEIJAG00.js"))
        '<�t�H�[�J�X�֘A�֐�>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncFo.js"))
        '<�����`�F�b�N�֐�>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncNumChk.js"))
        strScript.Append("</Script>")
        '//------------------------------------------
        '//�@Css�i�[
        strScript.Append("<Style>")
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "CssData.css"))
        strScript.Append("</Style>")
        '//------------------------------------------
        '//�@Script������
        lblScript.Text = strScript.ToString


        '//------------------------------------------------------------------------------
        If MyBase.IsPostBack = False Then
            '//--------------------------------------
            '//�@���߂ĊJ�������������s�����

            '//--------------------------------------------------------------------------
            '<TODO>�����\���Ƃ��ĕK�v�ȃR���g���[���̐ݒ���s���܂�
            '      ��)��ʏ����\�����́��������I������Ă��邱�Ɓc�c���̏���
            '//--------------------------------------------------------------------------
            '�@�������ʂɂ���ʂ̏�Ԃ̐ݒ�------------------------
            '�@��ʂ��y�����O��ԁz�ɂ���i���̓f�[�^�͂��̂܂ܑJ�ڂ�����j
            '//-------------------------------------------

            '�����\���Ƃ��ĕK�v�ȃR���g���[���̐ݒ���s���܂�
            '�N�x��\��
            txtNENDO.Text = DateTime.Now.AddMonths(-3).ToString("yyyy")

            '//�t�H�[�J�X���Z�b�g����
            strMsg.Append("Form1.rdoDATA1.focus();")
        Else
            '//--------------------------------------
            '//�@�Q��ڈȍ~���s�����
            '//--------------------------------------------------------------------------
            '//����ʕ\������R���{�{�b�N�X�͊e�ŏI�C�x���g/���\�b�h��CALL���܂�
            '//--------------------------------------------------------------------------
            '<TODO>�R���{�{�b�N�X�g�p���A�l�I����Function��Call����
            'Call fncSelectCombo()


        End If

        '//-------------------------------------------------
        '<TODO>�����̉��ID��HIDDEN��hdnMyAspx�ɏ������ށi�V�X�e�����ʁj
        hdnMyAspx.Value = "SBMEIJAG00"
        '//-------------------------------------------------

    End Sub

    '******************************************************************************
    '* POST�f�[�^�̎擾�ϐ��̏�����
    '******************************************************************************
    Private Sub fncGetPostIni()
        '//--------------------------------------------------------------------------
        ''<TODO>��ʃR���g���[�����e���i�[�����ϐ�������������
        ''//-----------------------------------------------

    End Sub

    '******************************************************************************
    '* HTTPPOST�f�[�^�擾
    '******************************************************************************
    Private Sub fncGetPost()
        '//--------------------------------------------------------------------------
        '<TODO>��ʃR���g���[���̓��e��ϐ��Ɋi�[����
        '//     �R���{�{�b�N�X��XYZ����t�̕ϊ����͂��̉ӏ��ōs��
    End Sub


    '******************************************************************************
    '* ���s�{�^������
    '******************************************************************************
    Private Sub btnSelect_ServerClick(ByVal sender As System.Object,
                                    ByVal e As System.EventArgs) Handles btnSelect.ServerClick

        Try
            Dim strRes As String
            Dim SBMEIJAG00C As New SBMEIJAG00SBMEIJAW00.SBMEIJAW00
            Dim strDataType As String = "0" '�o�̓t�@�C���@1=��b̧�ف@2=LTOS�t�@�C��
            Dim sfilepath As String = ""

            '�^�C���A�E�g�̎��Ԃ�ݒ�i60���j
            SBMEIJAG00C.Timeout = 6000000


            '�I�������t�@�C�����T�[�o�[�ɃA�b�v���[�h
            strRes = fncFileUpLoad()
            If strRes = "Error" Then
                strMsg.Append("alert('�t�@�C���̓ǂݍ��݂Ɏ��s���܂����B\n������x�������Ȃ����Ă��������B');")
                strMsg.Append("Form1.btnSelect.focus();")
                Return
            Else
                sfilepath = strRes
            End If

            '�捞�f�[�^�ŏ����𕪂���
            If rdoDATA1.Checked = True Then
                strDataType = "1"
            ElseIf rdoDATA2.Checked = True Then
                strDataType = "2"
            Else
                '�G���[ ���肦�Ȃ�'
            End If

            mlog(strDataType)

            If strDataType = "1" Then
                '�����b�t�@�C��
                '���̓t�@�C���@�K�{���ڂ̃`�F�b�N
                '2019/11/01 T.Ono mod �Ď����P2019
                'strRes = SBMEIJAG00C.mChkkisofile(strRes, "1")
                Select Case System.IO.Path.GetExtension(sfilepath).ToLower
                    Case ".xlsx", ".xls"
                        strRes = SBMEIJAG00C.mChkkisofile(strRes, "1")
                    Case ".csv"
                        strRes = SBMEIJAG00C.mChkkisofileCSV(strRes, "1")
                    Case Else
                        strRes = "�g���q��xlsx��xls��csv�Ƃ��Ă�������"
                End Select

                If strRes <> "OK" Then
                    strMsg.Append("alert('�K�{���ځ@���O�`�F�b�N\n\n" & strRes & "');")
                    strMsg.Append("Form1.btnSelect.focus();")
                    Return
                End If


                '�捞����
                '2019/11/13 T.Ono mod �Ď����P2019
                'strRes = SBMEIJAG00C.mReadkisofile(sfilepath, txtNENDO.Text, AuthC.pUSERNAME)
                Select Case System.IO.Path.GetExtension(sfilepath).ToLower
                    Case ".xlsx", ".xls"
                        strRes = SBMEIJAG00C.mReadkisofile(sfilepath, txtNENDO.Text, AuthC.pUSERNAME)
                    Case ".csv"
                        strRes = SBMEIJAG00C.mReadkisofileCSV(sfilepath, txtNENDO.Text, AuthC.pUSERNAME)
                    Case Else
                        strRes = "�g���q��xlsx��xls��csv�Ƃ��Ă�������"
                End Select

                If strRes = "OK" Then
                    strMsg.Append("alert('��ʏ���Җ�����X�V���܂���');")
                    strMsg.Append("Form1.btnSelect.focus();")
                Else
                    strMsg.Append("alert('�t�@�C���̓ǂݍ��݂Ɏ��s���܂����B\n " & strRes & "');")
                    'strMsg.Append("alert('�t�@�C���̓ǂݍ��݂Ɏ��s���܂���\n�Ǘ��҂ւ��A����������');")
                    strMsg.Append("Form1.btnSelect.focus();")
                End If

            Else
                mlog("LTOS" & sfilepath)
                'LTOS�t�@�C��
                '���̓t�@�C���@�K�{���ڂ̃`�F�b�N
                '2019/11/01 T.Ono mod �Ď����P2019
                'strRes = SBMEIJAG00C.mChkLTOSfile(strRes, "1")
                Select Case System.IO.Path.GetExtension(sfilepath).ToLower
                    Case ".xlsx", ".xls"
                        mlog(".xlsx")
                        strRes = SBMEIJAG00C.mChkLTOSfile(strRes, "1")
                    Case ".csv"
                        mlog(".csv")
                        strRes = SBMEIJAG00C.mChkLTOSfileCSV(strRes, "1")
                    Case Else
                        strRes = "�g���q��xlsx��xls��csv�Ƃ��Ă�������"
                End Select

                If strRes <> "OK" Then
                    strMsg.Append("alert('�K�{���ځ@���O�`�F�b�N\n\n" & strRes & "');")
                    strMsg.Append("Form1.btnSelect.focus();")
                    Return
                End If


                '�捞����
                '2019/11/01 T.Ono mod �Ď����P2019
                'strRes = SBMEIJAG00C.mReadLTOSfile(sfilepath, txtNENDO.Text, AuthC.pUSERNAME)
                Select Case System.IO.Path.GetExtension(sfilepath).ToLower
                    Case ".xlsx", ".xls"
                        strRes = SBMEIJAG00C.mReadLTOSfile(sfilepath, txtNENDO.Text, AuthC.pUSERNAME)
                    Case ".csv"
                        strRes = SBMEIJAG00C.mReadLTOSfileCSV(sfilepath, txtNENDO.Text, AuthC.pUSERNAME)
                    Case Else
                        strRes = "�g���q��xlsx��xls��csv�Ƃ��Ă�������"
                End Select

                mlog(strRes)

                If strRes.Substring(0, 2) = "OK" Then
                    Dim strResArray As String()
                    strResArray = Split(strRes, ":")

                    mlog(strResArray(0) & ":" & strResArray(1) & ":" & strResArray(2))

                    If strResArray(1) = "0" Then
                        strMsg.Append("alert('�X�V�Ώۂ͂���܂���ł���');")
                        strMsg.Append("Form1.btnSelect.focus();")
                    Else
                        strMsg.Append("alert('��ʏ���Җ�����X�V���܂���');")
                        strMsg.Append("Form1.btnSelect.focus();")
                    End If

                    'If strRes.Substring(0, 4) = "OK:0" Then
                    '    mlog("�X�V�Ȃ��F" & strRes)
                    '    strMsg.Append("alert('�X�V�Ώۂ͂���܂���ł���');")
                    '    strMsg.Append("Form1.btnSelect.focus();")
                    'Else
                    '    mlog("�X�V����F" & strRes)
                    '    strMsg.Append("alert('��ʏ���Җ�����X�V���܂���');")
                    '    strMsg.Append("Form1.btnSelect.focus();")
                    'End If
                Else
                    strMsg.Append("alert('�t�@�C���̓ǂݍ��݂Ɏ��s���܂����B\n " & strRes & "');")
                    strMsg.Append("Form1.btnSelect.focus();")
                End If
            End If

        Catch ex As Exception
            mlog("�V�X�e���G���[(btnFileUpload_Click)�F" & ex.ToString)
            strMsg.Append("alert('�t�@�C���̎捞�Ɏ��s���܂����B\n������x�������Ȃ����Ă��������B');")
            strMsg.Append("Form1.btnSelect.focus();")
        Finally
        End Try
    End Sub

    '**********************************************************
    '�t�@�C���A�b�v���[�h
    '�߂�l�F�������񂾃t�@�C���ւ̃t���p�X
    '**********************************************************
    Private Function fncFileUpLoad() As String

        Dim uploadFile As HttpPostedFile
        Dim sSaveFileName As String
        Dim sSaveFileNameR As String
        Dim sSaveFileNameR2 As String '�ꕔ�����ϊ���
        Dim sSaveFileExt As String
        Dim sSavePath As String
        Dim sSaveFileKey As String '�t�@�C���ۑ����ɓ��ɕt����L�[�i�����j
        Dim skipF As Boolean = False
        Dim fs As String()
        Dim strRes As String = "ERROR"

        Try
            uploadFile = Request.Files("FileUpload1")
            If (uploadFile.FileName <> "") Then

                '�t�@�C����������
                sSaveFileNameR = System.IO.Path.GetFileName(uploadFile.FileName)
                strFilepath = sSaveFileNameR '��ʍĕ\���p
                sSaveFileExt = System.IO.Path.GetExtension(uploadFile.FileName) '�g���q�擾���A�������֕ϊ�
                sSaveFileExt = sSaveFileExt.ToLower

                sSaveFileKey = DateTime.Now.ToString("yyyyMMddHHmmss")
                sSaveFileNameR2 = sSaveFileNameR
                sSaveFileNameR2 = sSaveFileNameR2.Replace(" ", "") '���p�X�y�[�X�͏���
                sSaveFileName = sSaveFileKey & "_" & sSaveFileNameR2
                'sSavePath = "C:\inetpub\wwwroot\JPGAP\TEMP\00\SBMEIJAW00\"�@�@'�捞�t�@�C���̒u���ꏊ
                sSavePath = ConfigurationSettings.AppSettings("SBMEIJAW_PATH")



                '�d���t�@�C���`�F�b�N
                fs = System.IO.Directory.GetFiles(sSavePath, sSaveFileName)   'folder�ɂ���t�@�C�����擾����
                If fs.Length >= 1 Then '���Ƀt�@�C�����o�^����Ă���H
                    strMsg.Append("alert('���Ƀt�@�C�����o�^����Ă��܂��B[" & sSaveFileNameR & "]' );")
                    strMsg.Append("Form1.btnSelect.focus();")
                    skipF = True
                End If


                If skipF = False Then
                    '�o�^
                    uploadFile.SaveAs(sSavePath + sSaveFileName) '�t�@�C���ۑ��I

                    strRes = sSavePath + sSaveFileName

                End If
            End If
        Catch ex As Exception
            strMsg.Append("alert('�t�@�C���̓ǂݍ��݂Ɏ��s���܂����B\n������x�������Ȃ����Ă��������B');")
            strMsg.Append("Form1.btnSelect.focus();")
            strRes = "ERROR"
        Finally
        End Try

        Return strRes
    End Function

    '**********************************************************
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
        Dim strRec As String

        Try
            If strLogFlg = "1" Then
                '�������݃t�@�C���ւ̃X�g���[��
                Dim outFile As New System.IO.StreamWriter(strPath, True, System.Text.Encoding.Default)

                '�����̕�������X�g���[���ɏ�������
                outFile.Write(System.DateTime.Now & "|" & AuthC.pUSERNAME & "|" & AuthC.pIPADDRESS & "|" & pstrString + vbCrLf)

                '�������t���b�V���i�t�@�C���������݁j
                outFile.Flush()

                '�t�@�C���N���[�Y
                outFile.Close()
            End If
        Catch ex As Exception
            strRec = "ERROR:" & ex.ToString
            strRecLog = LogC.mAPLog(Me.Session.SessionID, AuthC.pUSERNAME, AuthC.pIPADDRESS, Request.Form("hdnMyAspx"), "1", strRec, Request.Form)
        End Try
    End Sub
End Class
