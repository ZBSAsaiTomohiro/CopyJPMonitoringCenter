'***********************************************
'�ً}�o���ꗗ�@���C�����
'***********************************************
'<TODO>�錾���ʎd�l
Option Explicit On
Option Strict On

'<TODO>�錾���ʎd�l
Imports Common          '�F�Q�Ɛݒ��COCOMONC00��ݒ肷��
Imports JPG.Common
Imports System.Text     '�FStringBuilder���g�p���邽��

Partial Class SDLSTJAG00
    Inherits System.Web.UI.Page
    '--- ��2005/05/13 ADD Falcon�� ---
    '--- ��2005/05/13 ADD Falcon�� ---

    Protected ConstC As New CConst
    Private strSYU_CD As String = ""    '�o����ЃR�[�h(�N�b�L�[���擾�����l���i�[����

    '<TODO>�錾���ʎd�l
    '******************************************************************************
    ' HttpHeader
    '******************************************************************************
    Protected HttpHeaderC As New CHttpHeader

    '<TODO>�錾���ʎd�l
    '******************************************************************************
    ' ScriptMessage
    '******************************************************************************
    Private strMsg As New StringBuilder("")

    '******************************************************************************
    ' �F�؃N���X
    '******************************************************************************
    Protected AuthC As CAuthenticate


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

        '2012/04/05 NEC ou Add Str
        '.NET�̎d�l�ύX�ɂ��AReadOnly������ASPX�ł���ƁA�T�[�o���Œl�̎Q�Ƃ��ł��Ȃ��Ȃ邽�߁AVB����Attribute�ł���
        If MyBase.IsPostBack = False Then
            txtKEKKA_KENSU.Attributes.Add("ReadOnly", "true")
            txtCLI_CD.Attributes.Add("ReadOnly", "true") '2013/12/12 T.Ono add �Ď����P2013
            txtJA_CD.Attributes.Add("ReadOnly", "true")  '2013/12/12 T.Ono add �Ď����P2013
            txtGROUP_CD.Attributes.Add("ReadOnly", "true")  '2014/10/21 H.Hosoda add �Ď����P2014 No10
        End If
        '2012/04/05 NEC ou Add End

        '//------------------------------------------
        '//�@HTTP�w�b�_�𑗐M
        HttpHeaderC.mNoCache(Response)
        '//�@�F�؃N���X�̃C���X�^���X�����@2013/12/20 T.Ono add �Ď����P2013
        AuthC = New CAuthenticate(Request, Response)
        '//------------------------------------------------
        '�c�a�F�؎�(���O�C����ʃ��O�I����)�ɃZ�b�g�����o����ЃR�[�h���i�[����
        strSYU_CD = Convert.ToString(Request.Cookies(ConstC.pCookie_SD_Logincd).Value)

        '//------------------------------------------
        '<TODO>�|�b�v�A�b�v/�o�^�n�t���[���̏o��
        '      [hdnKensaku(Hidden)]���쐬���鎖
        '//�ً}�o�����ʈꗗ
        If hdnKensaku.Value = "SDLSTKFG00" Then
            Server.Transfer("SDLSTKFG00.aspx")
        End If
        '//�ً}�o���ꗗ
        If hdnKensaku.Value = "SDLSTSFG00" Then
            Server.Transfer("SDLSTSFG00.aspx")
        End If
        '//�|�b�v�A�b�v�o�́@2013/12/12 T.Ono add �Ď����P
        If hdnKensaku.Value = "COPOPUPG00" Then
            Server.Transfer("../../../Popup/COPOPUPG00.aspx")
        End If
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
        '      [lblScript(Label)]���쐬���鎖
        '//------------------------------------------
        '//�@JavaScript�i�[
        strScript.Append("<Script language=javascript>")
        '<�Ǝ��X�N���v�g>
        strScript.Append(cscript1.mWriteScript( _
             MyBase.MapPath("../../../SD/SDLSTJAG/SDLSTJAG00/") & "SDLSTJAG00.js"))
        '<�t�H�[�J�X�֘A�֐�>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncFo.js"))
        '<���t�֘A�֐�>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncDate.js"))
        strScript.Append("</Script>")
        '//------------------------------------------
        '//�@Css�i�[
        strScript.Append("<Style>")
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "CssData.css"))
        strScript.Append("</Style>")
        '//------------------------------------------

        '2013/12/20 T.Ono add �Ď����P2013
        Dim strDivFaxKbnDisp As String = "[" & AuthC.pGROUPNAME & "][" & InStr(AuthC.pGROUPNAME, "0�Ď��Ɩ��P��") & "]"
        '�c�Ə��̎擾
        Dim strEIGYOGROUP As String = ConfigurationSettings.AppSettings("GROUP_EIGYOU")        '�c�Ə����擾(Web.config) 2014/11/14 T.Ono add
        strScript.Append("<!-- AD�̊Ď�������� " & strDivFaxKbnDisp & " -->" & vbCrLf)
        If InStr(AuthC.pGROUPNAME, "0�Ď��Ɩ��P��") > 0 Then ' �����򕌂̉�ʂɂ͕\�������Ȃ�
            hdnOTHER_KANSI_CENTER.Value = "1"
        ElseIf InStr(AuthC.pGROUPNAME, strEIGYOGROUP) > 0 Then '�c�Ə��̉�ʂɂ͕\�������Ȃ� 2014/11/14 T.Ono add
            hdnOTHER_KANSI_CENTER.Value = "1"
        Else
            hdnOTHER_KANSI_CENTER.Value = "0"
        End If

        '�^�s�J�����̎擾 2014/11/14 T.Ono add
        '�^�s�ɂ�"�c�Ə�"���܂܂�邽�߁A�^�s���ǂ������Ō�Ƀ`�F�b�N
        Dim strUNKOUGROUP As String
        Dim arrUnkouGroup() As String
        Dim i As Integer
        strUNKOUGROUP = ConfigurationSettings.AppSettings("GROUP_UNKOU")        '�^�s�J�������擾(Web.config)
        arrUnkouGroup = strUNKOUGROUP.Split(Convert.ToChar(","))                '�^�s�J�������擾(�J���}��؂�)

        '>>�^�s�J�����`�F�b�N
        For i = 0 To arrUnkouGroup.Length - 1
            If InStr(AuthC.pGROUPNAME, arrUnkouGroup(i)) > 0 Then
                hdnOTHER_KANSI_CENTER.Value = "0"
            End If
        Next i


        '//�@Script������
        lblScript.Text = strScript.ToString

        Dim strMyAspx As String
        Dim strKBN As String

        strMyAspx = Request.Form("hdnMyAspx")

        '//------------------------------------------
        If MyBase.IsPostBack = False Then
            '//--------------------------------------
            '//���߂ĊJ�������������s�����

            '//--------------------------------------
            '�����\���Ƃ��ĕK�v�ȃR���g���[���̐ݒ���s���܂�
            Call fncIni_format()    '//�l�̏�����

            If strMyAspx = "SDSYUJAG00" Then
                '//�ً}�o���m�F�E���͂���̑J�ڎ�

                '�����Ώۊ��ԁiFrom�j
                txtSIJIYMD_From.Text = fncDateSet(Request.Form("hdnMOVE_SIJIYMD_F"))
                '�������iTo�j
                txtSIJIYMD_To.Text = fncDateSet(Request.Form("hdnMOVE_SIJIYMD_T"))
                '2013/12/12 T.Ono add �Ď����P2013 START
                '�N���C�A���g�R�[�h
                hdnCLI_CD.Value = Request.Form("hdnMOVE_CLI_CD")
                '�N���C�A���g��
                txtCLI_CD.Text = Request.Form("hdnMOVE_CLI_CD_NAME")
                '�i�`�R�[�h
                hdnJA_CD.Value = Request.Form("hdnMOVE_JA_CD")
                '�i�`��
                txtJA_CD.Text = Request.Form("hdnMOVE_JA_CD_NAME")
                ' 2013/12/12 T.Ono add �Ď����P2013 START
                ' 2014/10/21 H.Hosoda add 2014���P�J�� No10 START
                '�̔����Ǝ҃O���[�v�R�[�h
                hdnGROUP_CD.Value = Request.Form("hdnMOVE_GROUP_CD")
                '�̔����Ǝ҃O���[�v��
                txtGROUP_CD.Text = Request.Form("hdnMOVE_GROUP_CD_NAME")
                ' 2014/10/21 H.Hosoda add 2014���P�J�� No10 END

                '�敪
                strKBN = Request.Form("hdnMOVE_KBN")
                If strKBN = "1" Then
                    rdoKBN1.Checked = True
                    rdoKBN2.Checked = False
                Else
                    rdoKBN1.Checked = False
                    rdoKBN2.Checked = True
                End If

                '�I���L�[��ێ�����
                hdnKEY_KANSCD.Value = Request.Form("hdnKEY_KANSCD")
                hdnKEY_SYONO.Value = Request.Form("hdnKEY_SYONO")
                '�X�N���[���o�[
                hdnScrollTop.Value = Request.Form("hdnScrollTop")            '2013/12/11 T.Ono add �Ď����P2013

                '--- ��2005/05/13 ADD Falcon�� ---
                '�u�f�[�^�Ȃ��v���b�Z�[�W���o�͂��Ȃ�
                hdnMsgMode.Value = "MSG0"
                '--- ��2005/05/13 ADD Falcon�� ---

                '�敪�ɍ�������ʏ�ԂŌ���
                strMsg.Append("fncChangeMode(" & strKBN & ",'1');")

                '//------------------------------------------------
                '<TODO>�t�H�[�J�X���Z�b�g����
                If strKBN = "1" Then
                    strMsg.Append("Form1.rdoKBN1.focus();")
                Else
                    strMsg.Append("Form1.rdoKBN2.focus();")
                End If

            Else
                '//�o����Ѓ��O�C����ʂ���̑J�ڎ�

                '//�ꗗ�敪�i�o���ꗗ���f�t�H���g�\���j
                rdoKBN1.Checked = True
                rdoKBN2.Checked = False

                '--- ��2005/05/13 ADD Falcon�� ---
                '�u�f�[�^�Ȃ��v���b�Z�[�W���o��
                hdnMsgMode.Value = ""
                '--- ��2005/05/13 ADD Falcon�� ---

                '�o���ꗗ�Ƃ��Č���
                strMsg.Append("fncChangeMode(1,'0');")

                strMsg.Append("Form1.rdoKBN1.focus();")
            End If

            '//--------------------------------------
            '//0:�ʏ�o����Ё@1:�Ď��Z���^�[
            hdnLOGIN_FLG.Value = pLOGIN_FLG
        Else
            '//--------------------------------------
            '//�Q��ڈȍ~���s�����
            '//--------------------------------------
        End If

        '//-------------------------------------------------
        '<TODO>�����̉��ID��HIDDEN��hdnMyAspx�ɏ������ށi�V�X�e�����ʁj
        hdnMyAspx.Value = "SDLSTJAG00"
        '//-------------------------------------------------

    End Sub

    '******************************************************************************
    '* �e�R���g���[���̐ݒ�l�̏�����
    '******************************************************************************
    Private Sub fncIni_format()

        rdoKBN1.Checked = True
        rdoKBN2.Checked = False
        txtSIJIYMD_From.Text = ""
        txtSIJIYMD_To.Text = ""
        hdnKEY_KANSCD.Value = ""
        hdnKEY_SYONO.Value = ""
        '2013/12/12 T.Ono add �Ď����P2013 START
        txtCLI_CD.Text = ""
        txtJA_CD.Text = ""
        hdnCLI_CD.Value = ""
        hdnJA_CD.Value = ""
        hdnScrollTop.Value = "0"
        '2013/12/12 T.Ono add �Ď����P2013 END
        '2014/10/21 H.Hosoda add 2014���P�J�� No10 START
        txtGROUP_CD.Text = ""
        hdnGROUP_CD.Value = ""
        '2014/10/21 H.Hosoda add 2014���P�J�� No10 END

    End Sub

    '******************************************************************************
    '*�@�T�@�v�F�p�����[�^�l�����tYYYYMMDD�l��Ԃ�
    '*�@���@�l�F
    '******************************************************************************
    Public Function fncDateGet(ByVal pstrDate As String) As String
        Dim DateFncC As New CDateFnc
        Dim strRec As String
        strRec = ""
        If pstrDate.Length <> 0 Then
            strRec = DateFncC.mHenkanGet(pstrDate)
        End If

        Return strRec
    End Function

    '******************************************************************************
    '*�@�T�@�v�F�p�����[�^�l�����tYYYY/MM/DD�l��Ԃ�
    '*�@���@�l�F
    '******************************************************************************
    Public Function fncDateSet(ByVal pstrDate As String) As String
        Dim DateFncC As New CDateFnc
        Dim strRec As String
        strRec = ""
        If IsNumeric(pstrDate) = True Then
            strRec = DateFncC.mGet(pstrDate)
        End If

        Return strRec
    End Function

    '******************************************************************************
    '*�@�T�@�v�F�p�����[�^�l��莞��HH:mm:ss�l��Ԃ�
    '*�@���@�l�F
    '******************************************************************************
    Public Function fncTimeSet(ByVal pstrTime As String) As String
        Dim TimeFncC As New CTimeFnc
        Dim strRec As String
        strRec = ""
        If IsNumeric(pstrTime) = True Then
            strRec = TimeFncC.mGet(pstrTime, 0)
        End If

        Return strRec
    End Function

    '******************************************************************************
    '*�@�T�@�v�FhdnSelectClick�̒l��n���v���p�e�B
    '*�@���@�l�F�����{�^���������̂�"1"������BIFRAME���ɂđJ�ړI�o�͂Ȃ̂������o�͂Ȃ̂��𔻒�(MESSAGE)
    '******************************************************************************
    Public ReadOnly Property pSelectClick() As String
        Get
            Return hdnSelectClick.Value
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�o����ЃR�[�h�̒l��n���v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pSYU_CD() As String
        Get
            Return strSYU_CD
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�����Ώۊ��ԁi�e�������j�̒l��n���v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pSIJIYMD_F() As String
        Get
            Return fncDateGet(txtSIJIYMD_From.Text)
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�����Ώۊ��ԁi�s���j�̒l��n���v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pSIJIYMD_T() As String
        Get
            Return fncDateGet(txtSIJIYMD_To.Text)
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�ꗗ�őI�������Ď��Z���^�[�R�[�h�̒l��n���v���p�e�B
    '*�@���@�l�F�ً}�o���m�F�E���͉�ʂ��߂��Ă������Ɏg�p
    '******************************************************************************
    Public ReadOnly Property pKEY_KANSCD() As String
        Get
            Return hdnKEY_KANSCD.Value
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�ꗗ�őI�����������ԍ��̒l��n���v���p�e�B
    '*�@���@�l�F�ً}�o���m�F�E���͉�ʂ��߂��Ă������Ɏg�p
    '******************************************************************************
    Public ReadOnly Property pKEY_SYONO() As String
        Get
            Return hdnKEY_SYONO.Value
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F���O�C�����[�U�[����Ԃ��v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pLOGIN_USER() As String
        Get
            Return Convert.ToString(Request.Cookies(ConstC.pCookie_SD_Logincd).Value)
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F���O�C�����[�U�[��IPADDRESS��Ԃ��v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pLOGIN_IPADDRESS() As String
        Get
            Return Request.ServerVariables("REMOTE_ADDR")
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F���O�C�����[�U�[�̗��p�\�Ď��Z���^�[��Ԃ��v���p�e�B
    '*�@���@�l�F���Ď��Z���^�[���J�ڎ��̂�
    '******************************************************************************
    Public ReadOnly Property pLOGIN_ALLCENTERCD() As String
        Get
            Return Convert.ToString(Request.Cookies(ConstC.pCookie_SD_ALLCenter).Value)
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F���O�C�������J�ڃt���O
    '*�@���@�l�F0:�ʏ�o����Ё@1:�Ď��Z���^�[
    '******************************************************************************
    Public ReadOnly Property pLOGIN_FLG() As String
        Get
            If Convert.ToString(Request.Cookies(ConstC.pCookie_SD_ALLCenter).Value).Length = 0 Then
                Return "0"
            Else
                Return "1"
            End If
        End Get
    End Property

    '<TODO>���������Ƃ���IFRAME��ʂɈ����n�������lReadOnly�v���p�e�B�Őݒ肷��
    '******************************************************************************
    '*�@�T�@�v�F�N���C�A���g�R�[�h�̒l��n���v���p�e�B�@'2013/12/12 T.ono add �Ď����P2013
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pCLI_CD() As String
        Get
            Return hdnCLI_CD.Value.Trim
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�N���C�A���g���̒l��n���v���p�e�B�@'2013/12/12 T.ono add �Ď����P2013
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pCLI_CD_NAME() As String
        Get
            Return txtCLI_CD.Text
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�i�`�R�[�h�̒l��n���v���p�e�B�@'2013/12/12 T.ono add �Ď����P2013
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pJA_CD() As String
        Get
            Return hdnJA_CD.Value.Trim
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�i�`�R�[�h�̒l��n���v���p�e�B�@'2013/12/12 T.ono add �Ď����P2013
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pJA_CD_NAME() As String
        Get
            Return txtJA_CD.Text
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�O���[�v�R�[�h�̒l��n���v���p�e�B�@'2014/10/21 H.hosoda add �Ď����P2014
    '*�@���@�l�F�̔����Ǝ҃O���[�v�R�[�h��n��
    '******************************************************************************
    Public ReadOnly Property pGROUP_CD() As String
        Get
            Return hdnGROUP_CD.Value.Trim
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�O���[�v���̒l��n���v���p�e�B�@'2014/10/21 H.hosoda add �Ď����P2014
    '*�@���@�l�F�̔����Ǝ҃O���[�v����n��
    '******************************************************************************
    Public ReadOnly Property pGROUP_CD_NAME() As String
        Get
            Return txtGROUP_CD.Text
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�X�N���[���o�[�̈ʒu��n���v���p�e�B�@2013/12/11 T.Ono add �Ď����P2013
    '*�@���@�l�F�Ή����͉�ʂ��߂��Ă������Ɏg�p
    '******************************************************************************
    Public ReadOnly Property pScrollTop() As String
        Get
            Return hdnScrollTop.Value
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�i���ݏ�����n���v���p�e�B1�@2013/12/12 T.Ono add �Ď����P2013
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pCode1() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = pLOGIN_ALLCENTERCD
                Case "1"
                    strRec = hdnCLI_CD.Value                 '//�i�`�R�[�h�ꗗ
                Case "2"                                     ' 2014/10/21 H.Hosoda add 2014���P�J�� No10
                    strRec = hdnCLI_CD.Value                 '//�̔����Ǝ҈ꗗ
                Case Else
                    strRec = ""
            End Select
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�i���ݏ�����n���v���p�e�B2�@2013/12/12 T.Ono add �Ď����P2013
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pCode2() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = ""
                Case "1"
                    strRec = ""
                Case "2"            ' 2014/10/21 H.Hosoda add 2014���P�J�� No10
                    strRec = ""
                Case Else
                    strRec = ""
            End Select
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�o�͂���ꗗ�̖��O��n���v���p�e�B�@2013/12/12 T.Ono add �Ď����P2013
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pListName() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = "�N���C�A���g�ꗗ"
                Case "1"
                    strRec = "�i�`�ꗗ"
                Case "2"                ' 2014/10/21 H.Hosoda add 2014���P�J�� No10
                    strRec = "�̔����Ǝ҃O���[�v�ꗗ"
                Case Else
                    strRec = ""
            End Select
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�o�͂���ꗗ�𐧌䂷��l��n���v���p�e�B�@2013/12/12 T.Ono add �Ď����P2013
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pListCd() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = "CLI"
                Case "1"
                    strRec = "JA"
                Case "2"                ' 2014/10/21 H.Hosoda add 2014���P�J�� No10
                    strRec = "HANG"
                Case Else
                    strRec = ""
            End Select
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�R�[�h��Ԃ��I�u�W�F�N�g�̖��O�l��n���v���p�e�B�@2013/12/12 T.Ono add �Ď����P2013
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pBackCode() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = "hdnCLI_CD"
                Case "1"
                    strRec = "hdnJA_CD"
                Case "2"                ' 2014/10/21 H.Hosoda add 2014���P�J�� No10
                    strRec = "hdnGROUP_CD"
                Case Else
                    strRec = ""
            End Select
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F���̂�Ԃ��I�u�W�F�N�g�̖��O�l��n���v���p�e�B�@2013/12/12 T.Ono add �Ď����P2013
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pBackName() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = "txtCLI_CD"
                Case "1"
                    strRec = "txtJA_CD"
                Case "2"                ' 2014/10/21 H.Hosoda add 2014���P�J�� No10
                    strRec = "txtGROUP_CD"
                Case Else
                    strRec = ""
            End Select
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�t�H�[�J�X��Ԃ��I�u�W�F�N�g�̖��O�l��n���v���p�e�B�@2013/12/12 T.Ono add �Ď����P2013
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pBackFocs() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = "btnCLI_CD"
                Case "1"
                    strRec = "btnJA_CD"
                Case "2"                ' 2014/10/21 H.Hosoda add 2014���P�J�� No10
                    strRec = "btnGROUP_CD"
                Case Else
                    strRec = ""
            End Select
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�i�`���ύX���ꂽ���ɃN���A����I�u�W�F�N�g�̖��O�l��n���v���p�e�B�P�@2013/12/12 T.Ono add �Ď����P2013
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pClearName() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    '2014/10/21 H.Hosoda mod 2014���P�J�� No10 START
                    'strRec = "txtJA_CD"
                    txtJA_CD.Text = txtJA_CD.Text.Trim()
                    txtGROUP_CD.Text = txtGROUP_CD.Text.Trim()
                    If txtJA_CD.Text <> String.Empty Then
                        strRec = "txtJA_CD"
                    Else
                        strRec = "txtGROUP_CD"
                    End If
                    '2014/10/21 H.Hosoda mod 2014���P�J�� No10 END
                Case "1"
                    strRec = ""
                Case "2"                ' 2014/10/21 H.Hosoda add 2014���P�J�� No10
                    strRec = ""
                Case Else
                    strRec = ""
            End Select
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�i�`���ύX���ꂽ���ɃN���A����I�u�W�F�N�g�̖��O�l��n���v���p�e�B�P�@2013/12/12 T.Ono add �Ď����P2013
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pClearCode() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    '2014/10/21 H.Hosoda mod 2014���P�J�� No10 START
                    'strRec = "hdnJA_CD"
                    hdnJA_CD.Value = hdnJA_CD.Value.Trim()
                    hdnGROUP_CD.Value = hdnGROUP_CD.Value.Trim()
                    If hdnJA_CD.Value <> String.Empty Then
                        strRec = "hdnJA_CD"
                    Else
                        strRec = "hdnGROUP_CD"
                    End If
                    '2014/10/21 H.Hosoda mod 2014���P�J�� No10 END
                Case "1"
                    strRec = ""
                Case "2"                ' 2014/10/21 H.Hosoda add 2014���P�J�� No10
                    strRec = ""
                Case Else
                    strRec = ""
            End Select
            Return strRec
        End Get
    End Property

End Class
