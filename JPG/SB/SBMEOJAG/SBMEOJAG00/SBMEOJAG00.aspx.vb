'***********************************************
' ��ʏ���Җ���o��
'***********************************************
' �ύX����
' 2018/08/22 T.Ono 
' 

Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common
Imports JPG.Common.log

Imports System.Text

Partial Class SBMEOJAG00
    Inherits System.Web.UI.Page

    '�{�^��

    '�e�L�X�g�{�b�N�X

    '�R���{�{�b�N�X

    '�`�F�b�N�{�b�N�X

    '��\���R���g���[��

    Protected WithEvents dbData As System.Data.DataSet

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
    ' ScriptMessage
    '******************************************************************************
    Private strMsg As New StringBuilder("")      '//<script>�͕K�v�Ȃ�
    Dim strFileType As String         '�o�̓��X�g 


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
            txtKURACD_From.Attributes.Add("ReadOnly", "true")
            txtKURACD_To.Attributes.Add("ReadOnly", "true")
            txtHANTENCD_From.Attributes.Add("ReadOnly", "true")
            txtHANTENCD_To.Attributes.Add("ReadOnly", "true")
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
             MyBase.MapPath("../../../SB/SBMEOJAG/SBMEOJAG00/") & "SBMEOJAG00.js"))
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

        '�R���{�{�b�N�X�̍쐬
        '<TODO>�R���{�{�b�N�X�̍쐬Function��Call����
        Call fncCreateCombo()

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
            '�R���{�{�b�N�X�̍쐬
            'Call fncIni_format()    '//�l�̏�����

            '�N�x��\��
            txtNENDO.Text = DateTime.Now.AddMonths(-3).ToString("yyyy")

            '//�t�H�[�J�X���Z�b�g����
            strMsg.Append("Form1.txtKENCD.focus();")
        Else
            '//--------------------------------------
            '//�@�Q��ڈȍ~���s�����
            '//--------------------------------------------------------------------------
            '//����ʕ\������R���{�{�b�N�X�͊e�ŏI�C�x���g/���\�b�h��CALL���܂�
            '//--------------------------------------------------------------------------
            '<TODO>�R���{�{�b�N�X�g�p���A�l�I����Function��Call����
            Call fncSelectCombo()

        End If


        '//-------------------------------------------------
        '<TODO>�����̉��ID��HIDDEN��hdnMyAspx�ɏ������ށi�V�X�e�����ʁj
        hdnMyAspx.Value = "SBMEOJAG00"
        '//-------------------------------------------------

    End Sub

    '******************************************************************************
    '*�@�T�@�v�F�R���{�{�b�N�X�̑I��
    '*�@���@�l�F
    '******************************************************************************
    Private Sub fncSelectCombo()
        Dim list As New ListItem
        '//<TODO>�R���{�{�b�N�X��I����Ԃɂ���

        '//�o�̓��X�g
        If strFileType <> "" Then
            list = listfiletype.Items.FindByValue(strFileType)
            listfiletype.SelectedIndex = listfiletype.Items.IndexOf(list)
        End If
    End Sub

    '******************************************************************************
    '* POST�f�[�^�̎擾�ϐ��̏�����
    '******************************************************************************
    Private Sub fncGetPostIni()
        '//--------------------------------------------------------------------------
        ''<TODO>��ʃR���g���[�����e���i�[�����ϐ�������������
        ''//-----------------------------------------------
        hdnKURACD_From.Value = ""
        hdnKURACD_To.Value = ""
        txtKURACD_From.Text = ""
        txtKURACD_To.Text = ""

        hdnHANTENCD_From.Value = ""
        hdnHANTENCD_To.Value = ""
        txtHANTENCD_From.Text = ""
        txtHANTENCD_To.Text = ""

        txtKENCD.Text = ""

    End Sub

    '******************************************************************************
    '* HTTPPOST�f�[�^�擾
    '******************************************************************************
    Private Sub fncGetPost()
        '//--------------------------------------------------------------------------
        '<TODO>��ʃR���g���[���̓��e��ϐ��Ɋi�[����
        '//     �R���{�{�b�N�X��XYZ����t�̕ϊ����͂��̉ӏ��ōs��
        strFileType = Request.Form("listfiletype")

    End Sub

    '******************************************************************************
    '* �e�R���g���[���̐ݒ�l�̏�����
    '******************************************************************************
    Private Sub fncIni_format()

        '�R���{�쐬
        Call fncCombo_Create_FileType()         '�o�̓��X�g�R���{

        listfiletype.SelectedIndex = 0

    End Sub

    '******************************************************************************
    '*�@�T�@�v�F�R���{�{�b�N�X�쐬
    '*�@���@�l�F
    '******************************************************************************
    Private Sub fncCreateCombo()
        '//--------------------------------------------------------------------------
        '<TODO>�R���{�{�b�N�X���쐬����t�@���N�V������Call����
        Call fncCombo_Create_FileType()         '�o�̓��X�g�R���{
    End Sub
    Private Sub fncCombo_Create_FileType()
        '//�o�̓��X�g
        Dim objlistKIKAN As System.Web.UI.WebControls.DropDownList
        objlistKIKAN = CType(FindControl("listfiletype"), System.Web.UI.WebControls.DropDownList)
        objlistKIKAN.Items.Insert(0, New ListItem("1:��ʏ���Җ���", "1"))
        objlistKIKAN.Items.Insert(1, New ListItem("2:�m�F�p���X�g", "2"))
        objlistKIKAN.Items.Insert(2, New ListItem("3:���ׂ�", "3"))
        objlistKIKAN.DataBind()

    End Sub

    '******************************************************************************
    ' Excel�o��(�`�F�b�N��)
    '******************************************************************************
    Private Sub btnSelect_ServerClick(ByVal sender As System.Object,
                                    ByVal e As System.EventArgs) Handles btnSelect.ServerClick
        Dim strRec As String
        Dim SBMEOJAG00C As New SBMEOJAG00SBMEOJAW00.SBMEOJAW00

        '//�@�F�؃N���X�̃C���X�^���X����
        AuthC = New CAuthenticate(Request, Response)


        Dim strRecMsg As String = ""
        Dim strNENDO As String
        Dim strKEN As String
        Dim strKURACDFrom As String
        Dim strKURACDTo As String
        Dim strHANTENCDFrom As String
        Dim strHANTENCDTo As String
        Dim strFileType As String

        strNENDO = txtNENDO.Text
        strKEN = txtKENCD.Text
        strKURACDFrom = hdnKURACD_From.Value
        strKURACDTo = hdnKURACD_To.Value
        strHANTENCDFrom = hdnHANTENCD_From.Value
        strHANTENCDTo = hdnHANTENCD_To.Value
        strFileType = Request.Form("listfiletype")


        strRec = SBMEOJAG00C.mExcel(
                         Me.Session.SessionID,
                         strNENDO,
                         strKEN,
                         strKURACDFrom,
                         strKURACDTo,
                         strHANTENCDFrom,
                         strHANTENCDTo,
                         strFileType
                         )


        If strRec.Substring(0, 5) = "ERROR" Then
            '�G���[�ł���΃u���E�U�Ƀ��b�Z�[�W�\��
            Dim ErrMsgC As New CErrMsg
            strRecMsg = "�V�X�e���G���[�F" & ErrMsgC.mGetArtMsg(strRec)
            strMsg.Append("alert('" & strRecMsg & "');")

        ElseIf strRec.Substring(0, 5) = "DATA0" Then
            '�f�[�^��0���̏ꍇ
            strRecMsg = "�Ώۃf�[�^�����݂��܂���"
            strMsg.Append("alert('" & strRecMsg & "');")
            strMsg.Append("Form1.btnSelect.focus();")

        ElseIf strRec.Substring(0, 9) = "NULLEXIST" Then
            '���ރR�[�hNULL�̃f�[�^����ꍇ
            strRecMsg = "���ރR�[�h�s���̃f�[�^�����݂��܂�"
            strMsg.Append("alert('" & strRecMsg & "');")
            strMsg.Append("Form1.btnSelect.focus();")

        Else

            '�u�J���A�ۑ��v�̃_�C�����O���o��悤��HTTP�w�b�_�ɒǉ�
            Select Case strFileType
                Case "1"
                    '��ʏ���Җ���
                    HttpHeaderC.mDownLoadXLS(Response, "��ʏ���Җ���.zip")

                Case "2"
                    '�m�F�p���X�g
                    HttpHeaderC.mDownLoadXLS(Response, "�����b�t�@�C��_�m�F�p���X�g.zip")

                Case "3"
                    '���ׂ�
                    HttpHeaderC.mDownLoadXLS(Response, "�����b�t�@�C��_���ׂ�.zip")

                Case Else
                    '����ȊO�Ȃ�A��ʏ���Җ���ɂ��Ă���
                    HttpHeaderC.mDownLoadXLS(Response, "��ʏ���Җ���.zip")

            End Select


            Response.WriteFile(strRec)
            Response.End()

            strRecMsg = "OK"
        End If

        strRec = strRecMsg


        '-------------------------------------------------
        '//�`�o���O��������
        Dim LogC As New CLog
        Dim strRecLog As String
        strRecLog = LogC.mAPLog(Me.Session.SessionID, AuthC.pUSERNAME, AuthC.pIPADDRESS, hdnMyAspx.Value, "4", strRec, Request.Form)
        If strRecLog <> "OK" Then
            Dim errmsgc As New CErrMsg
            strMsg.Append("alert('�V�X�e���G���[�F" & errmsgc.mGetArtMsg(strRecLog) & "');")
        End If
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
                sSaveFileExt = System.IO.Path.GetExtension(uploadFile.FileName) '�g���q�擾���A�������֕ϊ�
                sSaveFileExt = sSaveFileExt.ToLower

                sSaveFileKey = DateTime.Now.ToString("yyyyMMddHHmmss")
                sSaveFileNameR2 = sSaveFileNameR
                sSaveFileNameR2 = sSaveFileNameR2.Replace(" ", "") '���p�X�y�[�X�͏���
                sSaveFileName = sSaveFileKey & "_" & sSaveFileNameR2
                'sSavePath = "C:\inetpub\wwwroot\JPGAP\TEMP\00\SBMEOJAW00\"�@�@'�捞�t�@�C���̒u���ꏊ
                sSavePath = ConfigurationSettings.AppSettings("SBMEOJAW_PATH")

                mlog(sSavePath)

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
            strMsg.Append("alert('�t�@�C���̃A�b�v���[�h�Ɏ��s���܂����B\n������x�������Ȃ����Ă��������B');")
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

    '******************************************************************************
    '*�@�T�@�v�F�i���ݏ�����n���v���p�e�B
    '*�@���@�l�F(�N���C�A���g�R�[�h)
    '******************************************************************************
    Public ReadOnly Property pCode1() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = AuthC.pAUTHCENTERCD
                Case "1"
                    strRec = AuthC.pAUTHCENTERCD
                Case "2"
                    strRec = AuthC.pAUTHCENTERCD
                Case "3"
                    strRec = AuthC.pAUTHCENTERCD
            End Select
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�i���ݏ�����n���v���p�e�B
    '*�@���@�l�F(�N���C�A���g�R�[�h)
    '******************************************************************************
    Public ReadOnly Property pCode2() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = ""
                Case "1"
                    strRec = ""
                Case "2"
                    strRec = hdnKURACD_From.Value.Trim
                Case "3"
                    'strRec = hdnKURACD_From.Value.Trim    '2019/11/01 T.Ono mod �Ď����P2019
                    strRec = hdnKURACD_To.Value.Trim
            End Select
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�o�͂���ꗗ�̖��O��n���v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pListName() As String
        Get
            Dim strRec As String
            'strRec = "�N���C�A���g�ꗗ"
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = "�N���C�A���g�ꗗ"
                Case "1"
                    strRec = "�N���C�A���g�ꗗ"
                Case "2"
                    strRec = "�̔��X�O���[�v�ꗗ"
                Case "3"
                    strRec = "�̔��X�O���[�v�ꗗ"
            End Select
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�o�͂���ꗗ�𐧌䂷��l��n���v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pListCd() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = "CLI"
                Case "1"
                    strRec = "CLI"
                Case "2"
                    strRec = "HANBAITEN"
                Case "3"
                    strRec = "HANBAITEN"
            End Select
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�R�[�h��Ԃ��I�u�W�F�N�g�̖��O�l��n���v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pBackCode() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = "hdnKURACD_From"
                Case "1"
                    strRec = "hdnKURACD_To"
                Case "2"
                    strRec = "hdnHANTENCD_From"
                Case "3"
                    strRec = "hdnHANTENCD_To"
            End Select
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F���̂�Ԃ��I�u�W�F�N�g�̖��O�l��n���v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pBackName() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = "txtKURACD_From"
                Case "1"
                    strRec = "txtKURACD_To"
                Case "2"
                    strRec = "txtHANTENCD_From"
                Case "3"
                    strRec = "txtHANTENCD_To"
            End Select
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�t�H�[�J�X��Ԃ��I�u�W�F�N�g�̖��O�l��n���v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pBackFocs() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = "btnKURACD_From"
                Case "1"
                    strRec = "btnKURACD_To"
                Case "2"
                    strRec = "btnHANTENCD_From"
                Case "3"
                    strRec = "btnHANTENCD_To"
            End Select

            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F���^�[����Ɏ��s�����i�r�@2019/11/01 T.Ono add �Ď����P2019
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pBackScript() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = "fncSetTo"
                Case "1"
                    strRec = ""
                Case "2"
                    strRec = "fncSetTo"
                Case "3"
                    strRec = ""
            End Select

            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�\�����N���A����I�u�W�F�N�g�̖��O��n���v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pClear1() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "0" Then
                strRec = "txtHANTENCD_From"
            ElseIf hdnPopcrtl.Value = "1" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = ""
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�\�����N���A����I�u�W�F�N�g�̖��O��n���v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pClear2() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "0" Then
                strRec = "hdnHANTENCD_From"
            ElseIf hdnPopcrtl.Value = "1" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = ""
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�\�����N���A����I�u�W�F�N�g�̖��O��n���v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pClear3() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "0" Then
                strRec = "txtHANTENCD_To"
            ElseIf hdnPopcrtl.Value = "1" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = ""
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�\�����N���A����I�u�W�F�N�g�̖��O��n���v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pClear4() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "0" Then
                strRec = "hdnHANTENCD_To"
            ElseIf hdnPopcrtl.Value = "1" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = ""
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property


End Class
