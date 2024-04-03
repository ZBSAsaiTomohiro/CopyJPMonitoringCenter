'***********************************************
' �i�`�S���ҘA����G�N�Z���o��  ���
'***********************************************
' �ύX����
' 2010/03/30 T.Watabe �V�K�쐬

Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common
Imports JPG.Common.log

Imports System.Text

Partial Class MSTAEJAG00
    Inherits System.Web.UI.Page
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
    ' ���t�N���X
    '******************************************************************************
    Protected DateFncC As New CDateFnc

    '******************************************************************************
    ' �N�b�L�[
    '******************************************************************************
    Protected ConstC As New CConst

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

        '2012/04/04 NEC ou Add Str
        '.NET�̎d�l�ύX�ɂ��AReadOnly������ASPX�ł���ƁA�T�[�o���Œl�̎Q�Ƃ��ł��Ȃ��Ȃ邽�߁AVB����Attribute�ł���
        If MyBase.IsPostBack = False Then
            txtKURACD.Attributes.Add("ReadOnly", "true")
            txtJACD.Attributes.Add("ReadOnly", "true")
        End If
        '2012/04/04 NEC ou Add End

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
        '[�Ή����ʈꗗ]�g�p�\����(�^:��/�c:��/��:��/�o:�~)
        AuthC.fncAuthCheck(Server, AuthC.pGROUP_UNKOU & "," & AuthC.pGROUP_KANSHI & "," & AuthC.pGROUP_EIGYOU)

        '//------------------------------------------
        '//�|�b�v�A�b�v�o��
        If hdnKensaku.Value = "COPOPUPG00" Then
            Server.Transfer("../../../Popup/COPOPUPG00.aspx")
        End If
        '//�J�����_�[�̏o��
        If hdnKensaku.Value = "COCALDRG00" Then
            Server.Transfer("../../../Popup/COCALDRG00.aspx")
        End If
        '//�����`�F�b�N�X�N���v�g
        If hdnKensaku.Value = "MSTAEJCG00" Then
            Server.Transfer("./MSTAEJCG00.aspx")
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
        '<�Ǝ��X�N���v�g>
        strScript.Append(cscript1.mWriteScript( _
             MyBase.MapPath("../../../MS/MSTAEJAG/MSTAEJAG00/") & "MSTAEJAG00.js"))
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
            '//�t�H�[�J�X���Z�b�g����
            strMsg.Append("Form1.btnKURACD.focus();")

        Else
            '//--------------------------------------
            '//�@�Q��ڈȍ~���s�����
            '//--------------------------------------------------------------------------
            '//����ʕ\������R���{�{�b�N�X�͊e�ŏI�C�x���g/���\�b�h��CALL���܂�
            '//--------------------------------------------------------------------------
        End If

        '//-------------------------------------------------
        '<TODO>�����̉��ID��HIDDEN��hdnMyAspx�ɏ������ށi�V�X�e�����ʁj
        hdnMyAspx.Value = "MSTAEJAG00"
        '//-------------------------------------------------

    End Sub

    '******************************************************************************
    ' Excel�o��(�`�F�b�N��)
    '******************************************************************************
    Private Sub btnSelect_ServerClick(ByVal sender As System.Object, _
                                    ByVal e As System.EventArgs) Handles btnSelect.ServerClick
        Dim strRec As String
        'Dim bytExcel() As Byte '2014/01/16 T.Ono del ���P�Ή�2013 Excel�𒼐ڏo�͂ɕύX
        Dim MSTAEJAG00C As New MSTAEJAG00MSTAEJAW00.MSTAEJAW00

        Dim strSTKBN As String
        Dim strPGKBN As String
        Dim strTAIOU_CHOFUKU As String '2010/03/09 T.Watabe add

        '//�@�F�؃N���X�̃C���X�^���X����
        AuthC = New CAuthenticate(Request, Response)

        Dim strRecMsg As String = ""
        'Dim intMaxDataCnt As Integer = ConstC.pPageMax '2008/12/18 T.Watabe edit
        Dim intMaxDataCnt As Integer = 65000

        '2012/04/04 NEC ou Upd Str
        'strRec = MSTAEJAG00C.mExcel( _
        '                         Request.Cookies.Get("ASP.NET_SessionId").Value, _
        '                         hdnKURACD.Value, _
        '                         hdnJACD.Value, _
        '                         strPGKBN, _
        '                         txtKURACD.Text, _
        '                         txtJACD.Text, _
        '                         intMaxDataCnt, _
        '                         AuthC.pCENTERCD _
        '                         )
        strRec = MSTAEJAG00C.mExcel( _
                         Me.Session.SessionID, _
                         hdnKURACD.Value.Trim, _
                         hdnJACD.Value.Trim, _
                         strPGKBN, _
                         txtKURACD.Text, _
                         txtJACD.Text, _
                         intMaxDataCnt, _
                         AuthC.pCENTERCD _
                         )
        '2012/04/04 NEC ou Upd End

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

        ElseIf strRec.Substring(0, 7) = "DATAMAX" Then
            '�f�[�^���ő�s���𒴂����̏ꍇ
            strRecMsg = "�f�[�^���ő�s���𒴂��܂����B[�ő�" & intMaxDataCnt & "�s]"
            strMsg.Append("alert('" & strRecMsg & "');")
            strMsg.Append("Form1.btnSelect.focus();")

        Else
            '�u�J���A�ۑ��v�̃_�C�����O���o��悤��HTTP�w�b�_�ɒǉ�
            '�t�@�C�����́AHttpUtility.UrlEncode���\�b�h���g�p����SJIS�ɃG���R�[�h����K�v������
            '.xls�`���ɕύX 2013/12/06 T.Ono mod �Ď����P2013
            'HttpHeaderC.mDownLoad(Response, "�i�`�S���ҘA����.exe")
            HttpHeaderC.mDownLoadXLS(Response, "�i�`�S���ҘA����.xls")

            '2014/01/16 T.Ono mod �Ď����P2013 excel�𒼐ڊJ�� Start
            ''Web�T�[�r�X�̖߂�l�iBASE64�̃e�L�X�g�j���o�C�g�f�[�^�ɕϊ�����
            'bytExcel = Convert.FromBase64String(strRec)
            ''�t�@�C�����M
            'Response.BinaryWrite(bytExcel)
            Response.WriteFile(strRec)
            '2014/01/16 T.Ono mod �Ď����P2013 excel�𒼐ڊJ�� End
            strRecMsg = "OK"
        End If

        strRec = strRecMsg
        '-------------------------------------------------
        '//�`�o���O��������
        Dim LogC As New CLog
        Dim strRecLog As String
        '2012/04/04 NEC ou Upd Str
        'strRecLog = LogC.mAPLog(Request.Cookies.Get("ASP.NET_SessionId").Value, AuthC.pUSERNAME, AuthC.pIPADDRESS, hdnMyAspx.Value, "4", strRec, Request.Form)
        strRecLog = LogC.mAPLog(Me.Session.SessionID, AuthC.pUSERNAME, AuthC.pIPADDRESS, hdnMyAspx.Value, "4", strRec, Request.Form)
        '2012/04/04 NEC ou Upd End
        If strRecLog <> "OK" Then
            Dim errmsgc As New CErrMsg
            strMsg.Append("alert('�V�X�e���G���[�F" & errmsgc.mGetArtMsg(strRecLog) & "');")
        End If
    End Sub

    '******************************************************************************
    '* �����`�F�b�N�p��ʂɓn���p�����[�^�ݒ�
    '******************************************************************************
    Public ReadOnly Property pKuracd() As String
        Get
            Return hdnKURACD.Value.Trim     '2012/04/04 NEC ou Add Upd
        End Get
    End Property
    Public ReadOnly Property pJacd() As String
        Get
            Return hdnJACD.Value.Trim       '2012/04/04 NEC ou Add Upd
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�i���ݏ�����n���v���p�e�B
    '*�@���@�l�F(���R�[�h)
    '******************************************************************************
    Public ReadOnly Property pCode1() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    ''�^�s�J�����̏ꍇ�͑S�Ă̊Ď��Z���^�[��I���\
                    ''�ȊO�̏ꍇ�͑�s���g�p�����Ɏ����̊Ď��Z���^�[�̂ݎg�p�\
                    strRec = AuthC.pAUTHCENTERCD

                Case "1"
                Case "2"
                    strRec = hdnKURACD.Value
                Case "3"
            End Select
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�i���ݏ�����n���v���p�e�B
    '*�@���@�l�F(�����Z���^�[�R�[�h/�i�`�R�[�h)
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
                    strRec = ""
                Case "3"
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
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = "�N���C�A���g�ꗗ"
                Case "1"
                Case "2"
                    strRec = "�i�`�ꗗ"
                Case "3"
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
                Case "2"
                    strRec = "JA"
                Case "3"
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
                    strRec = "hdnKURACD"
                Case "1"
                Case "2"
                    strRec = "hdnJACD"
                Case "3"
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
                    strRec = "txtKURACD"
                Case "1"
                Case "2"
                    strRec = "txtJACD"
                Case "3"
            End Select
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�t�H�[�J�X��Ԃ��I�u�W�F�N�g�̖��O�l��n���v���p�e�B
    '*�@�T�@�v�F�J�����_�[���t�Ńt�H�[�J�X�Z�b�g����鍀�ږ���Ԃ��I�u�W�F�N�g���w��
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pBackFocs() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value.Length > 0 Then
                Select Case hdnPopcrtl.Value
                    Case "0"
                        strRec = "btnKURACD"
                    Case "1"
                    Case "2"
                        strRec = "btnKen1"
                    Case "3"
                End Select
            End If
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�i�`���ύX���ꂽ���ɃN���A����I�u�W�F�N�g�̖��O�l��n���v���p�e�B�P
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pClearName() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = "txtJACD"
                Case "1"
                    strRec = ""
                Case "2"
                    strRec = ""
                Case "3"
                    strRec = ""
            End Select
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�i�`���ύX���ꂽ���ɃN���A����I�u�W�F�N�g�̖��O�l��n���v���p�e�B�P
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pClearCode() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = "hdnJACD"
                Case "1"
                    strRec = ""
                Case "2"
                    strRec = ""
                    'Case "3"
                    '    strRec = ""
            End Select
            Return strRec
        End Get
    End Property

End Class
