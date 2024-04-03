'******************************************************************************
' �|�b�v�A�b�v (�Ăяo����)
'******************************************************************************
' �ύX����
' 2013/12/12 T.Ono add �Ď����P2013 �N���C�A���g�EJA�I���|�b�v�A�b�v�ǉ��̂���JPG����R�s�[

Option Explicit On
Option Strict On

Imports Common

Imports System.Text

'******************************************************************************
' �|�b�v�A�b�v (�Ăяo����)
'******************************************************************************

Partial Class COPOPUPG00
    Inherits System.Web.UI.Page
    '�V�X�e������
    Protected strListName As String

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
    Protected SDLSTJAG00_C As SDLSTJAG00.SDLSTJAG00         '�o���ꗗ
    ' 2014/10/23 H.Hosoda add 1Line 2014���P�J�� No11 START
    Protected SDSYUJAG00_C As SDSYUJAG00.SDSYUJAG00        '�ً}�o���Ή�����
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
        'Iframe�o��
        If hdnKensaku.Value = "COPOPUFG00" Then
            Server.Transfer("COPOPUFG00.aspx")
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
        '//------------------------------------------
        '//�@JavaScript�i�[
        strScript.Append("<Script language=javascript>")
        '<�|�b�v�A�b�v�p�֐�>
        '--- ��2012/02/16 UPD NEC��  ---
        'strScript.Append(cscript1.mWriteScript(MyBase.MapPath("../../../Popup/") & "COPOPUPG00.js"))
        strScript.Append(cscript1.mWriteScript(MyBase.MapPath("../../JPSD/Popup/") & "COPOPUPG00.js"))
        '--- ��2012/02/16 UPD NEC��  ---
        '<�t�H�[�J�X�֘A�֐�>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncFo.js"))
        '<���̓`�F�b�N�֐�>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncChk.js"))
        strScript.Append("</Script>")
        '//------------------------------------------
        '//�@Css�i�[
        strScript.Append("<Style>")
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "CssPopup.css"))
        strScript.Append("</Style>")
        '//------------------------------------------
        '//�@Script������
        lblScript.Text = strScript.ToString

        '------------------------------------------------------------------------------
        '<TODO>�@�\�ǉ����ɑΏۂ̃v���W�F�N�g��ǉ����Ă���

        ''�ً}�o���ꗗ
        If Request.Path.LastIndexOf("SDLSTJAG00") >= 0 Then
            SDLSTJAG00_C = CType(Context.Handler, SDLSTJAG00.SDLSTJAG00)
            strListName = SDLSTJAG00_C.pListName
            hdnListCd.Value = SDLSTJAG00_C.pListCd
            hdnCode1.Value = SDLSTJAG00_C.pCode1
            hdnCode2.Value = SDLSTJAG00_C.pCode2          '2013/12/09 T.Ono add �Ď����P2013
            hdnBackCode.Value = SDLSTJAG00_C.pBackCode
            hdnBackName.Value = SDLSTJAG00_C.pBackName
            hbdBackFocs.Value = SDLSTJAG00_C.pBackFocs
            hdnClear1.Value = SDLSTJAG00_C.pClearName
            hdnClear2.Value = SDLSTJAG00_C.pClearCode
        End If

        ' 2014/10/23 H.Hosoda add 2014���P�J�� No11 START
        '�o����ВS���҈ꗗ
        If Request.Path.LastIndexOf("SDSYUJAG00") >= 0 Then
            SDSYUJAG00_C = CType(Context.Handler, SDSYUJAG00.SDSYUJAG00)
            strListName = SDSYUJAG00_C.pListName
            hdnListCd.Value = SDSYUJAG00_C.pListCd
            hdnCode1.Value = SDSYUJAG00_C.pCode1
            hdnCode2.Value = SDSYUJAG00_C.pCode2          '2013/12/09 T.Ono add �Ď����P2013
            hdnBackCode.Value = SDSYUJAG00_C.pBackCode
            hdnBackName.Value = SDSYUJAG00_C.pBackName
            hdnBackNameOnly.Value = SDSYUJAG00_C.pBackNameOnly
            hbdBackFocs.Value = SDSYUJAG00_C.pBackFocs
            hdnClear1.Value = SDSYUJAG00_C.pClearName
            hdnClear2.Value = SDSYUJAG00_C.pClearCode
        End If
        ' 2014/10/23 H.Hosoda add 2014���P�J�� No11 END

        '------------------------------------------------------------------------------
        '�ꗗ�^�C�g���̕\��
        lblListName.Text = strListName
        '�E�B���h�E�̃^�C�g���̐ݒ�
        strMsg.Append("document.title='" & strListName & "'")
    End Sub
    '******************************************************************************
    '*�@�T�@�v�F���X�g�R�[�h(���)�̒l��n���v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pListCd() As String
        Get
            Return hdnListCd.Value
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�R�[�h��Ԃ��I�u�W�F�N�g�̖��O�l��n���v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pBackCode() As String
        Get
            Return hdnBackCode.Value
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F���̂�Ԃ��I�u�W�F�N�g�̖��O�l��n���v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pBackName() As String
        Get
            Return hdnBackName.Value
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F���݂̂̂�Ԃ��I�u�W�F�N�g�̖��O�l��n���v���p�e�B�@'2014/10/30 H.Hosoda add 2014���P�J�� No11
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pBackNameOnly() As String
        Get
            Return hdnBackNameOnly.Value
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�t�H�[�J�X��Ԃ��I�u�W�F�N�g�̖��O�l��n���v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pBackFocs() As String
        Get
            Return hbdBackFocs.Value
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F���s����i�r����n���v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pBackScript() As String
        Get
            Return hbdBackScript.Value
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pPopType() As String
        Get
            '[1]:�R�[�h�̕Ԃ�l�͕\���p�́u[CODE]�F[NAME]�v�ɂȂ�܂��F�f�t�H���g
            '[2]:�R�[�h�̕Ԃ�l�͓��͉\(�ڋq����)�p�́uCODE�v�ɂȂ�܂�
            Return hdnPopType.Value
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�R�[�h�̒l��n���v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pCode1() As String
        Get
            Return hdnCode1.Value
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�R�[�h�̒l��n���v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pCode2() As String
        Get
            Return hdnCode2.Value
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�����Z���^�[���ύX���ꂽ���ɃN���A����I�u�W�F�N�g�̖��O�l��n���v���p�e�B�P
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pClear1() As String
        Get
            Return hdnClear1.Value
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�����Z���^�[���ύX���ꂽ���ɃN���A����I�u�W�F�N�g�̖��O�l��n���v���p�e�B�Q
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pClear2() As String
        Get
            Return hdnClear2.Value
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�����Z���^�[���ύX���ꂽ���ɃN���A����I�u�W�F�N�g�̖��O�l��n���v���p�e�B�P
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pClear3() As String
        Get
            Return hdnClear3.Value
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�����Z���^�[���ύX���ꂽ���ɃN���A����I�u�W�F�N�g�̖��O�l��n���v���p�e�B�Q
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pClear4() As String
        Get
            Return hdnClear4.Value
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�����Z���^�[���ύX���ꂽ���ɃN���A����I�u�W�F�N�g�̖��O�l��n���v���p�e�B�P
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pClear5() As String
        Get
            Return hdnClear5.Value
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�����Z���^�[���ύX���ꂽ���ɃN���A����I�u�W�F�N�g�̖��O�l��n���v���p�e�B�Q
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pClear6() As String
        Get
            Return hdnClear6.Value
        End Get
    End Property
End Class
