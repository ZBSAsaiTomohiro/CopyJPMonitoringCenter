'***********************************************
' �i�`�S���ҘA����G�N�Z���o��  ���
'***********************************************
' �ύX����
' 2015/12/16 T.Ono �V�K�쐬
'�iMSTAEJAG00���R�s�[�@JA�S���ҁE�񍐐�E���ӎ����}�X�^���Q�Ƃ��邽�߂Ƀ��j���[�A���j

Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common
Imports JPG.Common.log

Imports System.Text
Imports System.IO

Partial Class MSTAHJAG00
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

        '.NET�̎d�l�ύX�ɂ��AReadOnly������ASPX�ł���ƁA�T�[�o���Œl�̎Q�Ƃ��ł��Ȃ��Ȃ邽�߁AVB����Attribute�ł���
        If MyBase.IsPostBack = False Then
            txtKURACD.Attributes.Add("ReadOnly", "true")
            txtJACD.Attributes.Add("ReadOnly", "true")
            txtGROUPCD.Attributes.Add("ReadOnly", "true")
        End If

        '//------------------------------------------
        '//�@HTTP�w�b�_�𑗐M
        HttpHeaderC.mNoCache(Response)

        '//------------------------------------------
        '//�@�F�؃N���X�̃C���X�^���X����
        AuthC = New CAuthenticate(Request, Response)

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
        '//�����`�F�b�N�X�N���v�g
        If hdnKensaku.Value = "MSTAHJCG00" Then
            Server.Transfer("./MSTAHJCG00.aspx")
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
             MyBase.MapPath("../../../MS/MSTAHJAG/MSTAHJAG00/") & "MSTAHJAG00.js"))
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

            '2017/07/20 H.Mori add START
            '//-----------------------------------------------------                
            '// �c�Ə��O���[�v�݂̂ɏ������Ă���ꍇ�A[�c�Ə����j���[]���J�ڂ��Ă��Ă����
            '// �I���{�^����������[�c�Ə����j���[]�ɖ߂�
            '//-----------------------------------------------------
            hdnBackUrl.Value = ""

            Dim strGROUPNAME As String = AuthC.pGROUPNAME
            Dim arrGroupName() As String = strGROUPNAME.Split(Convert.ToChar(","))
            Dim arrKanshiGroup() As String = AuthC.pGROUP_KANSHI.Split(Convert.ToChar(","))
            Dim i As Integer
            Dim bolGroupFLG As Boolean = False

            '�^�s�J�����E�c�Ə��̏����`�F�b�N
            If Array.IndexOf(arrGroupName, AuthC.pGROUP_UNKOU) >= 0 Or _
                Array.IndexOf(arrGroupName, AuthC.pGROUP_EIGYOU) >= 0 Then
                bolGroupFLG = True
            End If

            '�Ď��Z���^�[�����`�F�b�N
            If bolGroupFLG = False Then
                For i = 0 To arrKanshiGroup.Length - 1
                    If Array.IndexOf(arrGroupName, arrKanshiGroup(i)) >= 0 Then
                        bolGroupFLG = True
                        '//�c�Ə��O���[�v
                        hdnBackUrl.Value = "KANSHI"
                        Exit For
                    End If
                Next i
            End If

            If bolGroupFLG = False Then
                Dim j As Integer
                Dim intEIGYOU_LEN As Integer
                Dim intGROUP_LEN As Integer
                intEIGYOU_LEN = AuthC.pGROUP_EIGYOU.Length
                For j = 0 To arrGroupName.Length - 1
                    intGROUP_LEN = arrGroupName(j).Length
                    If intGROUP_LEN > 0 Then
                        If Convert.ToString(arrGroupName(j)).Substring(intGROUP_LEN - intEIGYOU_LEN, intEIGYOU_LEN) = AuthC.pGROUP_EIGYOU Then
                            '//�c�Ə��O���[�v
                            hdnBackUrl.Value = "EIGYOU"
                        End If
                    End If
                Next
            End If
            '2017/07/20 H.Mori add END

        Else
            '//--------------------------------------
            '//�@�Q��ڈȍ~���s�����
            '//--------------------------------------------------------------------------
            '//����ʕ\������R���{�{�b�N�X�͊e�ŏI�C�x���g/���\�b�h��CALL���܂�
            '//--------------------------------------------------------------------------
        End If

        '//-------------------------------------------------
        '<TODO>�����̉��ID��HIDDEN��hdnMyAspx�ɏ������ށi�V�X�e�����ʁj
        hdnMyAspx.Value = "MSTAHJAG00"
        '//-------------------------------------------------

    End Sub

    '******************************************************************************
    ' Excel�o��(�`�F�b�N��)
    '******************************************************************************
    Private Sub btnSelect_ServerClick(ByVal sender As System.Object, _
                                    ByVal e As System.EventArgs) Handles btnSelect.ServerClick
        Dim strRec As String
        Dim MSTAHJAG00C As New MSTAHJAG00MSTAHJAW00.MSTAHJAW00

        Dim strPGKBN As String

        '//�@�F�؃N���X�̃C���X�^���X����
        AuthC = New CAuthenticate(Request, Response)

        Dim strRecMsg As String = ""
        Dim intMaxDataCnt As Integer = 65000

        '2019/11/01 T.Ono mod �Ď����P2019 hdnKURACD_TO�AhdnJACD_CLI�ǉ�
        'strRec = MSTAHJAG00C.mExcel(
        '                 Me.Session.SessionID,
        '                 hdnKURACD.Value.Trim,
        '                 hdnJACD.Value.Trim,
        '                 hdnGROUPCD.Value.Trim,
        '                 strPGKBN,
        '                 txtKURACD.Text,
        '                 txtGROUPCD.Text,
        '                 intMaxDataCnt,
        '                  AuthC.pAUTHCENTERCD
        '                 )
        strRec = MSTAHJAG00C.mExcel(
                         Me.Session.SessionID,
                         hdnKURACD.Value.Trim,
                         hdnKURACD_TO.Value.Trim,
                         hdnJACD.Value.Trim,
                         hdnJACD_CLI.Value.Trim,
                         hdnGROUPCD.Value.Trim,
                         strPGKBN,
                         txtKURACD.Text,
                         txtGROUPCD.Text,
                         intMaxDataCnt,
                          AuthC.pAUTHCENTERCD
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

        ElseIf strRec.Substring(0, 7) = "DATAMAX" Then
            '�f�[�^���ő�s���𒴂����̏ꍇ
            strRecMsg = "�f�[�^���ő�s���𒴂��܂����B[�ő�" & intMaxDataCnt & "�s]"
            strMsg.Append("alert('" & strRecMsg & "');")
            strMsg.Append("Form1.btnSelect.focus();")

        Else
            '�u�J���A�ۑ��v�̃_�C�����O���o��悤��HTTP�w�b�_�ɒǉ�
            '�t�@�C�����́AHttpUtility.UrlEncode���\�b�h���g�p����SJIS�ɃG���R�[�h����K�v������
            '.xls�`��
            HttpHeaderC.mDownLoadXLS(Response, "�i�`�S���ҘA����.xls")

            ''�t�@�C�����M
            Response.WriteFile(strRec)
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

    '******************************************************************************
    '* �����`�F�b�N�p��ʂɓn���p�����[�^�ݒ�
    '******************************************************************************
    Public ReadOnly Property pKuracd() As String
        Get
            Return hdnKURACD.Value.Trim
        End Get
    End Property
    '2019/11/01 T.Ono add �Ď����P2019
    Public ReadOnly Property pKuracd_to() As String
        Get
            Return hdnKURACD_TO.Value.Trim
        End Get
    End Property
    Public ReadOnly Property pJAcd() As String
        Get
            Return hdnJACD.Value.Trim
        End Get

    End Property
    '�i�`�R�[�h�ɕR�Â��N���C�A���g�R�[�h�̒l��n���v���p�e�B�@'2013/12/09 T.ono add �Ď����P2013
    Public ReadOnly Property pJACD_CLI() As String
        Get
            Return hdnJACD_CLI.Value.Trim
        End Get
    End Property
    Public ReadOnly Property pGroupcd() As String
        Get
            Return hdnGROUPCD.Value.Trim
        End Get

    End Property
    Public ReadOnly Property pCentercd() As String
        Get
            Return AuthC.pAUTHCENTERCD()
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
                    strRec = hdnKURACD.Value
                Case "2"
                    strRec = AuthC.pAUTHCENTERCD
                Case "3"
                    '2019/11/01 T.Ono mod �Ď����P219
                    strRec = AuthC.pAUTHCENTERCD
                Case Else
                    strRec = ""
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
                    strRec = hdnKURACD.Value.Trim
                Case "3"
            End Select
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�i���ݏ�����n���v���p�e�B
    '*�@���@�l�F2019/11/01 T.Ono mod �Ď����P2019
    '******************************************************************************
    Public ReadOnly Property pCode3() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = ""
                Case "1"
                    strRec = hdnKURACD_TO.Value.Trim
                Case "2"
                    strRec = ""
                Case "3"
                    strRec = ""
                Case Else
                    strRec = ""
            End Select
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�i���ݏ�����n���v���p�e�B
    '*�@���@�l�F2019/11/01 T.Ono mod �Ď����P2019
    '******************************************************************************
    Public ReadOnly Property pCode4() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = ""
                Case "1"
                    strRec = ""
                Case "2"
                    strRec = hdnKURACD_TO.Value.Trim
                Case "3"
                    strRec = ""
                Case Else
                    strRec = ""
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
                    strRec = "�i�`�ꗗ"
                Case "2"
                    strRec = "�O���[�v�R�[�h�ꗗ"
                Case "3"
                    '2019/11/01 T.Ono add �Ď����P2019
                    strRec = "�N���C�A���g�ꗗ"
                Case Else
                    strRec = ""
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
                    strRec = "JA"
                Case "2"
                    strRec = "JAHOKOKU"
                Case "3"
                    '2019/11/01 T.Ono add �Ď����P2019
                    strRec = "CLI"
                Case Else
                    strRec = ""
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
                    strRec = "hdnJACD"
                Case "2"
                    strRec = "hdnGROUPCD"
                Case "3"
                    '2019/11/01 T.Ono add �Ď����P2019
                    strRec = "hdnKURACD_TO"
                Case Else
                    strRec = ""
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
                    strRec = "txtJACD"
                Case "2"
                    strRec = "txtGROUPCD"
                Case "3"
                    '2019/11/01 T.Ono add �Ď����P2019
                    strRec = "txtKURACD_TO"
                Case Else
                    strRec = ""
            End Select
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�R�[�h��Ԃ��I�u�W�F�N�g�̖��O�l��n���v���p�e�B 2019/11/01 T.Ono add �Ď����P2019
    '*�@���@�l�F�f�[�^�I����A�R�[�h��Ԃ��I�u�W�F�N�g�����w�肷��
    '******************************************************************************
    Public ReadOnly Property pBackCode2() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = ""
                Case "1"
                    strRec = "hdnJACD_CLI"
                Case "2"
                    strRec = ""
                Case "3"
                    strRec = ""
                Case Else
                    strRec = ""
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
                        strRec = "btnJACD"
                    Case "2"
                        strRec = "btnGROUPCD"
                    Case "3"
                        '2019/11/01 T.Ono add �Ď����P2019
                        strRec = "btnKURACD_TO"
                    Case Else
                        strRec = ""
                End Select
            End If
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F���^�[����Ɏ��s�����i�r�@2019/11/01 T.Ono add �Ď����P2019
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pBackScript() As String
        Get
            Dim strRec As String = ""
            If hdnPopcrtl.Value.Length > 0 Then
                Select Case hdnPopcrtl.Value
                    Case "0"
                        strRec = "fncSetTo"
                    Case "1"
                        strRec = ""
                    Case "2"
                        strRec = ""
                    Case "3"
                        strRec = ""
                    Case Else
                        strRec = ""
                End Select
            End If
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�N���C�A���g���ύX���ꂽ���ɃN���A����I�u�W�F�N�g�̖��O�l��n���v���p�e�B�P
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pClearCode1() As String
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
                    '2019/11/01 T.Ono add �Ď����P2019
                    'strRec = ""
                    strRec = "txtJACD"
                Case Else
                    strRec = ""
            End Select
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�N���C�A���g���ύX���ꂽ���ɃN���A����I�u�W�F�N�g�̖��O�l��n���v���p�e�B�Q
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pClearCode2() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = "hdnJACD"
                Case "1"
                    strRec = ""
                Case "2"
                    strRec = ""
                Case "3"
                    '2019/11/01 T.Ono add �Ď����P2019
                    strRec = "hdnJACD"
                Case Else
                    strRec = ""
            End Select
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�N���C�A���g���ύX���ꂽ���ɃN���A����I�u�W�F�N�g�̖��O�l��n���v���p�e�B�R
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pClearCode3() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = "txtGROUPCD"
                Case "1"
                    strRec = ""
                Case "2"
                    strRec = ""
                Case "3"
                    '2019/11/01 T.Ono add �Ď����P2019
                    'strRec = ""
                    strRec = "txtGROUPCD"
                Case Else
                    strRec = ""
            End Select
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�N���C�A���g���ύX���ꂽ���ɃN���A����I�u�W�F�N�g�̖��O�l��n���v���p�e�B�S
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pClearCode4() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = "hdnGROUPCD"
                Case "1"
                    strRec = ""
                Case "2"
                    strRec = ""
                Case "3"
                    '2019/11/01 T.Ono add �Ď����P2019
                    strRec = "hdnGROUPCD"
                Case Else
                    strRec = ""
            End Select
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�N���C�A���g���ύX���ꂽ���ɃN���A����I�u�W�F�N�g�̖��O�l��n���v���p�e�B�T
    '*�@���@�l�F2019/11/01 T.Ono add �Ď����P2019
    '******************************************************************************
    Public ReadOnly Property pClearCode5() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = "hdnJACD_CLI"
                Case "1"
                    strRec = ""
                Case "2"
                    strRec = ""
                Case "3"
                    strRec = "hdnJACD_CLI"
                Case Else
                    strRec = ""
            End Select
            Return strRec
        End Get
    End Property
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
        Dim strRec As String

        Try
            If strLogFlg = "1" Then
                '�������݃t�@�C���ւ̃X�g���[��
                Dim outFile As New StreamWriter(strPath, True, System.Text.Encoding.Default)

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
