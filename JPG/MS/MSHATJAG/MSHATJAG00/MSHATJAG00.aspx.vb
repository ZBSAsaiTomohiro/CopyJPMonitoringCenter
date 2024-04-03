'***********************************************
'�̔��X�O���[�v�}�X�^
'***********************************************
' �ύX����

Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common
Imports JPG.Common.log

Imports System.Text

Partial Class MSHATJAG00
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

        '.NET�̎d�l�ύX�ɂ��AReadOnly������ASPX�ł���ƁA�T�[�o���Œl�̎Q�Ƃ��ł��Ȃ��Ȃ邽�߁AVB����Attribute�ł���
        If MyBase.IsPostBack = False Then
            txtKURACD.Attributes.Add("ReadOnly", "true")
            txtGROUPCD_F.Attributes.Add("ReadOnly", "true")
            txtGROUPCD_T.Attributes.Add("ReadOnly", "true")
            Dim objDefNO As System.Web.UI.WebControls.TextBox
            Dim objDefTARGET As System.Web.UI.WebControls.CheckBox
            Dim objDefINS_DATE As System.Web.UI.WebControls.TextBox
            Dim objDefINS_USER As System.Web.UI.WebControls.TextBox
            Dim objDefUPD_DATE As System.Web.UI.WebControls.TextBox
            Dim objDefUPD_USER As System.Web.UI.WebControls.TextBox
            Dim i As Integer
            For i = 1 To 100
                objDefNO = CType(FindControl("txtNO_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                objDefTARGET = CType(FindControl("chkTARGET_" & CStr(i)), System.Web.UI.WebControls.CheckBox)
                objDefINS_DATE = CType(FindControl("txtINS_DATE_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                objDefINS_USER = CType(FindControl("txtINS_USER_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                objDefUPD_DATE = CType(FindControl("txtUPD_DATE_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                objDefUPD_USER = CType(FindControl("txtUPD_USER_" & CStr(i)), System.Web.UI.WebControls.TextBox)

                objDefNO.Attributes.Add("ReadOnly", "true")
                objDefTARGET.Checked = True
                objDefINS_DATE.Attributes.Add("ReadOnly", "true")
                objDefINS_USER.Attributes.Add("ReadOnly", "true")
                objDefUPD_DATE.Attributes.Add("ReadOnly", "true")
                objDefUPD_USER.Attributes.Add("ReadOnly", "true")
            Next
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
        '[�S���҃}�X�^]�g�p�\����(�^:��/�c:��/��:��/�o:�~)
        AuthC.fncAuthCheck(Server, AuthC.pGROUP_UNKOU & "," & AuthC.pGROUP_EIGYOU & "," & AuthC.pGROUP_KANSHI)

        '//------------------------------------------
        '<TODO>�|�b�v�A�b�v/�o�^�n�t���[���̏o��
        '      [hdnKensaku(Hidden)]���쐬���鎖
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
        '//------------------------------------------
        '//�@JavaScript�i�[
        strScript.Append("<Script language=javascript>")
        '<�Ǝ��X�N���v�g>
        strScript.Append(cscript1.mWriteScript( _
             MyBase.MapPath("../../../MS/MSHATJAG/MSHATJAG00/") & "MSHATJAG00.js"))
        '<�t�H�[�J�X�֘A�֐�>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncFo.js"))
        '<���̓`�F�b�N�֐�>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncChk.js"))
        '<���l�֘A�֐�>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncNumChk.js"))
        '<�o�C�g���J�E���g�֐�>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncGetByte.js"))
        '<�S�p�`�F�b�N�֐�>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncZenkakuChk.js"))
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
            '//���߂ĊJ�������������s�����

            '//--------------------------------------
            '�����\���Ƃ��ĕK�v�ȃR���g���[���̐ݒ���s���܂�
            Call fncIni_format()    '//�l�̏�����

            '//--------------------------------------
            '������ʂ̏�Ԑݒ�(��ʂ��y�����O��ԁz�ɂ���i���̓f�[�^�͂��̂܂ܑJ�ڂ�����)
            Call fncIni_statebf()

            '//--------------------------------------------------------------------------
            '�t�H�[�J�X���Z�b�g����
            strMsg.Append("Form1.btnSelect.focus();")

            '//-----------------------------------------------------
            '// �c�Ə��O���[�v�͓���ʂ��g��Ȃ����߁AhdnBackUrl���g�p���Ȃ�
            '//-----------------------------------------------------
            hdnBackUrl.Value = ""

        Else
            '//--------------------------------------
            '//�@�Q��ڈȍ~���s�����
            '//--------------------------------------


        End If

        '<TODO>�����̉��ID��HIDDEN��hdnMyAspx�ɏ������ށi�V�X�e�����ʁj
        hdnMyAspx.Value = "MSHATJAG00"
        '//-------------------------------------------------

    End Sub

    '******************************************************************************
    '* ���������������O�̉�ʏ�ԁiReadOnly��Disabled�j
    '********************************/*********************************************
    Private Sub fncIni_statebf()
        '//--------------------------------------------------------------------------
        '<TODO>�����O�̏�ԂɃR���g���[���̏�Ԃ�ݒ肷��

        btnKURACD.Disabled = False
        btnGROUPCD_F.Disabled = False
        btnGROUPCD_T.Disabled = False

    End Sub

    '******************************************************************************
    '* �������������ꂽ��̉�ʏ�ԁiReadOnly��Disabled�j
    '******************************************************************************
    Private Sub fncIni_stateaf()
        '//--------------------------------------------------------------------------
        '<TODO>������̏�ԂɃR���g���[���̏�Ԃ�ݒ肷��
        '
        txtKURACD.Attributes.Add("ReadOnly", "true")
        txtGROUPCD_F.Attributes.Add("ReadOnly", "true")
        txtGROUPCD_T.Attributes.Add("ReadOnly", "true")
        Dim objNO As System.Web.UI.WebControls.TextBox
        Dim objTARGET As System.Web.UI.WebControls.CheckBox
        Dim objINS_DATE As System.Web.UI.WebControls.TextBox
        Dim objINS_USER As System.Web.UI.WebControls.TextBox
        Dim objUPD_DATE As System.Web.UI.WebControls.TextBox
        Dim objUPD_USER As System.Web.UI.WebControls.TextBox
        Dim i As Integer
        For i = 1 To 100
            objNO = CType(FindControl("txtNO_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objTARGET = CType(FindControl("chkTARGET_" & CStr(i)), System.Web.UI.WebControls.CheckBox)
            objINS_DATE = CType(FindControl("txtINS_DATE_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objINS_USER = CType(FindControl("txtINS_USER_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objUPD_DATE = CType(FindControl("txtUPD_DATE_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objUPD_USER = CType(FindControl("txtUPD_USER_" & CStr(i)), System.Web.UI.WebControls.TextBox)

            objNO.Attributes.Add("ReadOnly", "true")
            objTARGET.Checked = True
            objINS_DATE.Attributes.Add("ReadOnly", "true")
            objINS_USER.Attributes.Add("ReadOnly", "true")
            objUPD_DATE.Attributes.Add("ReadOnly", "true")
            objUPD_USER.Attributes.Add("ReadOnly", "true")
        Next
    End Sub

    '******************************************************************************
    '* �e�R���g���[���̐ݒ�l�̏�����
    '******************************************************************************
    Private Sub fncIni_format()
        '//--------------------------------------------------------------------------
        txtKURACD.Text = ""
        hdnKURACD.Value = ""
        txtGROUPCD_F.Text = ""
        hdnGROUPCD_F.Value = ""
        txtGROUPCD_T.Text = ""
        hdnGROUPCD_T.Value = ""

        '�L�[�ȊO�̒l������������
        Call fncIni_notkey()

    End Sub

    '******************************************************************************
    '* �L�[�ȊO�̒l������������
    '******************************************************************************
    Private Sub fncIni_notkey()

        '//--------------------------------------------------------------------------
        '<TODO>�R���g���[���̒l������������

        hdnKURACD_MOTO.Value = ""
        hdnGROUPCD_F_MOTO.Value = ""
        hdnGROUPCD_T_MOTO.Value = ""

        Dim objTARGET As System.Web.UI.WebControls.CheckBox
        Dim objGROUPCD As System.Web.UI.WebControls.TextBox
        Dim objGROUPNM As System.Web.UI.WebControls.TextBox
        Dim objHANBAITENNM As System.Web.UI.WebControls.TextBox
        Dim objBIKO As System.Web.UI.WebControls.TextBox
        Dim objINS_DATE As System.Web.UI.WebControls.TextBox
        Dim objINS_USER As System.Web.UI.WebControls.TextBox
        Dim objUPD_DATE As System.Web.UI.WebControls.TextBox
        Dim objUPD_USER As System.Web.UI.WebControls.TextBox

        Dim i As Integer

        For i = 1 To 100
            '�R���g���[������T���o���A�^�ϊ�
            objTARGET = CType(FindControl("chkTARGET_" & CStr(i)), System.Web.UI.WebControls.CheckBox)
            objGROUPCD = CType(FindControl("txtGROUPCD_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objGROUPNM = CType(FindControl("txtGROUPNM_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objHANBAITENNM = CType(FindControl("txtHANBAITENNM_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objBIKO = CType(FindControl("txtBIKO_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objINS_DATE = CType(FindControl("txtINS_DATE_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objINS_USER = CType(FindControl("txtINS_USER_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objUPD_DATE = CType(FindControl("txtUPD_DATE_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objUPD_USER = CType(FindControl("txtUPD_USER_" & CStr(i)), System.Web.UI.WebControls.TextBox)


            objTARGET.Checked = True
            objGROUPCD.Text = ""
            objGROUPNM.Text = ""
            objHANBAITENNM.Text = ""
            objBIKO.Text = ""
            objINS_DATE.Text = ""
            objINS_USER.Text = ""
            objUPD_DATE.Text = ""
            objUPD_USER.Text = ""
        Next

    End Sub

    '******************************************************************************
    '* �����{�^�����������ꂽ�Ƃ��̏���
    '******************************************************************************
    Private Sub btnSelect_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.ServerClick
        Dim strRec As String

        '�f�[�^���������A�f�[�^���o�͂��܂�
        strRec = fncbtnKensaku_ClickEvent("1")

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
    '* �o�^�{�^�����������ꂽ�Ƃ��̏���
    '******************************************************************************
    Private Sub btnUpdate_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.ServerClick
        Dim strRec As String
        strRec = fncbtnJikkou_ClickEvent(hdnKBN.Value)

        Call fncIni_stateaf()
    End Sub


    '******************************************************************************
    '* ����{�^�����������ꂽ�Ƃ��̏���
    '******************************************************************************
    Private Sub btnClear_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.ServerClick
        Call fncIni_format()    '//�l�̏�����
        Call fncIni_statebf()   '//��Ԃ̏�����

        '//------------------------------------------
        '<TODO>�t�H�[�J�X���Z�b�g����i������ʂɖ߂����̂�(PageLoad���l)�L�[�ɃZ�b�g�j
        strMsg.Append("Form1.btnSelect.focus();")
    End Sub

    '******************************************************************************
    '*�@�T�@�v�F�i���ݏ�����n���v���p�e�B
    '*�@���@�l�F���o�����P�̒l��n��
    '******************************************************************************
    Public ReadOnly Property pCode1() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then      '//�N���C�A���g�R�[�h�ꗗ
                strRec = AuthC.pAUTHCENTERCD    '//�`�c�F�؂̎g�p�\�Ď��Z���^�[�R�[�h
            ElseIf hdnPopcrtl.Value = "2" Then  '//�O���[�v�R�[�h�iFrom�j�ꗗ
                strRec = AuthC.pAUTHCENTERCD    '//�`�c�F�؂̎g�p�\�Ď��Z���^�[�R�[�h
            ElseIf hdnPopcrtl.Value = "3" Then  '//�O���[�v�R�[�h�iTo�j�ꗗ
                strRec = AuthC.pAUTHCENTERCD    '//�`�c�F�؂̎g�p�\�Ď��Z���^�[�R�[�h
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�i���ݏ�����n���v���p�e�B
    '*�@���@�l�F���o�����Q�̒l��n��
    '******************************************************************************
    Public ReadOnly Property pCode2() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then      '//�N���C�A���g�R�[�h�ꗗ
                strRec = ""
            ElseIf hdnPopcrtl.Value = "2" Then  '//�O���[�v�R�[�h�iFrom�j�ꗗ
                strRec = hdnKURACD.Value.Trim   '//�N���C�A���g�R�[�h
            ElseIf hdnPopcrtl.Value = "3" Then  '//�O���[�v�R�[�h�iTo�j�ꗗ
                strRec = hdnKURACD.Value.Trim   '//�N���C�A���g�R�[�h
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�o�͂���ꗗ�̖��O��n���v���p�e�B
    '*�@���@�l�F�|�b�v�A�b�v�̃^�C�g������n��
    '******************************************************************************
    Public ReadOnly Property pListName() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then          '//�N���C�A���g�R�[�h�ꗗ
                strRec = "�N���C�A���g�R�[�h�R�[�h�ꗗ"
            ElseIf hdnPopcrtl.Value = "2" Then      '//���[�v�R�[�h�iFrom�j�ꗗ
                strRec = "�O���[�v�R�[�h�ꗗ"
            ElseIf hdnPopcrtl.Value = "3" Then      '//�O���[�v�R�[�h�iTo�j�ꗗ
                strRec = "�O���[�v�R�[�h�ꗗ"
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�o�͂���ꗗ�𐧌䂷��l��n���v���p�e�B
    '*�@���@�l�F�|�b�v�A�b�v�̎�ނ�I������
    '******************************************************************************
    Public ReadOnly Property pListCd() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "CLI"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = "HANBAITEN"
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = "HANBAITEN"
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�R�[�h��Ԃ��I�u�W�F�N�g�̖��O�l��n���v���p�e�B
    '*�@���@�l�F�f�[�^�I����A�R�[�h��Ԃ��I�u�W�F�N�g�����w�肷��
    '******************************************************************************
    Public ReadOnly Property pBackCode() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "hdnKURACD"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = "hdnGROUPCD_F"
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = "hdnGROUPCD_T"
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F���̂�Ԃ��I�u�W�F�N�g�̖��O�l��n���v���p�e�B
    '*�@���@�l�F�f�[�^�I����A���̂�Ԃ��I�u�W�F�N�g�����w�肷��
    '******************************************************************************
    Public ReadOnly Property pBackName() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "txtKURACD"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = "txtGROUPCD_F"
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = "txtGROUPCD_T"
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�t�H�[�J�X��Ԃ��I�u�W�F�N�g�̖��O�l��n���v���p�e�B
    '*�@���@�l�F�f�[�^�I����A�l��Ԃ�����ɁA�J�[�\�����Z�b�g����ꏊ�̎w��
    '******************************************************************************
    Public ReadOnly Property pBackFocs() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "btnKURACD"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = "btnGROUPCD_F"
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = "btnGROUPCD_T"
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
    Public ReadOnly Property pClear1() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
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
            If hdnPopcrtl.Value = "1" Then
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
            If hdnPopcrtl.Value = "1" Then
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
            If hdnPopcrtl.Value = "1" Then
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
    Public ReadOnly Property pClear5() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
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
    '*�@�T�@�v�F���^�[����Ɏ��s�����i�r
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pBackScript() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "2" Then
                '2019/11/01 T.Ono mod �Ď����P2019
                'strRec = ""
                strRec = "fncSetTo"
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '* �f�[�^�̏o�͏���
    '******************************************************************************
    Private Function fncbtnKensaku_ClickEvent(ByVal pstrKBN As String) As String
        '1:�����{�^��
        '2:���s��o�́@(�t�H�[�J�X�̃Z�b�g���ς��܂�)
        Dim strRec As String

        strRec = "OK"

        fncIni_notkey() '�L�[�ȊO�̍��ڏ�����

        Try
            '//--------------------------------------
            '�����������s��
            Dim DateFncC As New CDateFnc
            Dim dbData As DataSet
            Dim UserCheckFLG As Boolean = True

            dbData = fncDataSelect()

            If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
                '�f�[�^�����݂��Ȃ��ׁA�����̓G���[
                '���b�Z�[�W���o�͌�A�����O��Ԃɂ���B

                strMsg.Append("alert('�f�[�^�����݂��܂���');")

                Call fncIni_statebf()

                '//------------------------------
                '<TODO>�t�H�[�J�X���Z�b�g����
                strMsg.Append("Form1.btnSelect.focus();")

                '//--------------------------------------------------------------------------
            Else
                '�f�[�^�����݂���ׁA�f�[�^�o��

                '------------------------------------
                '<TODO>100���ȏ�̏ꍇ�̓��b�Z�[�W
                If dbData.Tables(0).Rows.Count > 100 Then
                    strMsg.Append("alert('�ő�o�͌����𒴂��܂����B�������w�肵�čēx�������Ă�������');")
                End If

                '------------------------------------
                '<TODO>�f�[�^���o�͂���
                '�N���C�A���g�R�[�h
                If hdnKURACD.Value.Length <> 0 Then
                    hdnKURACD_MOTO.Value = hdnKURACD.Value.Trim
                Else
                    hdnKURACD_MOTO.Value = ""
                End If
                'JA�x���R�[�h
                If hdnGROUPCD_F.Value.Length <> 0 Then
                    hdnGROUPCD_F_MOTO.Value = hdnGROUPCD_F.Value.Trim
                Else
                    hdnGROUPCD_F_MOTO.Value = ""
                End If
                If hdnGROUPCD_T.Value.Length <> 0 Then
                    hdnGROUPCD_T_MOTO.Value = hdnGROUPCD_T.Value.Trim
                Else
                    hdnGROUPCD_T_MOTO.Value = ""
                End If


                Dim objGROUPCD As System.Web.UI.WebControls.TextBox
                Dim objGROUPNM As System.Web.UI.WebControls.TextBox
                Dim objHANBAITENNM As System.Web.UI.WebControls.TextBox
                Dim objBIKO As System.Web.UI.WebControls.TextBox
                Dim objINS_DATE As System.Web.UI.WebControls.TextBox
                Dim objINS_USER As System.Web.UI.WebControls.TextBox
                Dim objUPD_DATE As System.Web.UI.WebControls.TextBox
                Dim objUPD_USER As System.Web.UI.WebControls.TextBox

                Dim intRow As Integer

                For intRow = 0 To dbData.Tables(0).Rows.Count - 1

                    If intRow >= 100 Then Exit For '100���ȏ�͏�������

                    '----------------------------
                    ' ���׏�����ʍ��ڂɃZ�b�g
                    '----------------------------
                    '�R���g���[������T���o���A�^�ϊ�
                    objGROUPCD = CType(FindControl("txtGROUPCD_" & CStr(intRow + 1)), System.Web.UI.WebControls.TextBox)
                    objGROUPNM = CType(FindControl("txtGROUPNM_" & CStr(intRow + 1)), System.Web.UI.WebControls.TextBox)
                    objHANBAITENNM = CType(FindControl("txtHANBAITENNM_" & CStr(intRow + 1)), System.Web.UI.WebControls.TextBox)
                    objBIKO = CType(FindControl("txtBIKO_" & CStr(intRow + 1)), System.Web.UI.WebControls.TextBox)
                    objINS_DATE = CType(FindControl("txtINS_DATE_" & CStr(intRow + 1)), System.Web.UI.WebControls.TextBox)
                    objINS_USER = CType(FindControl("txtINS_USER_" & CStr(intRow + 1)), System.Web.UI.WebControls.TextBox)
                    objUPD_DATE = CType(FindControl("txtUPD_DATE_" & CStr(intRow + 1)), System.Web.UI.WebControls.TextBox)
                    objUPD_USER = CType(FindControl("txtUPD_USER_" & CStr(intRow + 1)), System.Web.UI.WebControls.TextBox)

                    '�L�[���ڂ͕ύX�s�ɂ���
                    objGROUPCD.ReadOnly = True
                    objGROUPCD.BackColor = Color.Gainsboro

                    objGROUPCD.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("GROUPCD"))
                    objGROUPNM.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("GROUPNM"))
                    objHANBAITENNM.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("HANBAITENNM"))
                    objBIKO.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("BIKO"))
                    objINS_DATE.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("INS_DATE"))
                    objINS_USER.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("INS_USER"))
                    objUPD_DATE.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("UPD_DATE"))
                    objUPD_USER.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("UPD_USER"))

                Next

                If pstrKBN = "1" Then
                    '�����{�^��������
                    Call fncIni_stateaf()

                    '//------------------------------
                    '<TODO>�t�H�[�J�X���Z�b�g����i�f�[�^�����݂����̂ŃL�[�ȊO�ɃZ�b�g�j
                    strMsg.Append("Form1.btnSelect.focus();")
                End If


            End If
            dbData.Dispose()

        Catch ex As Exception
            strRec = ex.ToString
            Dim ErrMsgC As New CErrMsg
            strMsg.Append("alert('�V�X�e���G���[�F" & ErrMsgC.mGetArtMsg(ex.ToString) & "');")
        End Try

        Return strRec

    End Function

    '******************************************************************************
    '* �o�^�E�폜���������ꂽ�Ƃ��̏���
    '******************************************************************************
    Private Function fncbtnJikkou_ClickEvent(ByVal pstrKBN As String) As String

        Dim strRec As String
        Dim DateFncC As New CDateFnc

        '//------------------------------------------
        '<TODO>�Ǝ���WEB�T�[�r����錾����
        Dim MSHATJAW00C As New MSHATJAG00MSHATJAW00.MSHATJAW00

        '�l��z��ɃZ�b�g
        Dim objTARGET As System.Web.UI.WebControls.CheckBox
        Dim objGROUPCD As System.Web.UI.WebControls.TextBox
        Dim objGROUPNM As System.Web.UI.WebControls.TextBox
        Dim objHANBAITENNM As System.Web.UI.WebControls.TextBox
        Dim objBIKO As System.Web.UI.WebControls.TextBox
        Dim objINS_DATE As System.Web.UI.WebControls.TextBox
        Dim objINS_USER As System.Web.UI.WebControls.TextBox
        Dim objUPD_DATE As System.Web.UI.WebControls.TextBox
        Dim objUPD_USER As System.Web.UI.WebControls.TextBox


        Dim sTARGET(100) As String
        Dim sGROUPCD(100) As String
        Dim sGROUPNM(100) As String
        Dim sHANBAITENNM(100) As String
        Dim sBIKO(100) As String
        Dim sINS_DATE(100) As String
        Dim sINS_USER(100) As String
        Dim sUPD_DATE(100) As String
        Dim sUPD_USER(100) As String

        Dim i As Integer

        For i = 1 To 100
            '�R���g���[������T���o���A�^�ϊ�
            objTARGET = CType(FindControl("chkTARGET_" & CStr(i)), System.Web.UI.WebControls.CheckBox)
            objGROUPCD = CType(FindControl("txtGROUPCD_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objGROUPNM = CType(FindControl("txtGROUPNM_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objHANBAITENNM = CType(FindControl("txtHANBAITENNM_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objBIKO = CType(FindControl("txtBIKO_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objINS_DATE = CType(FindControl("txtINS_DATE_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objINS_USER = CType(FindControl("txtINS_USER_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objUPD_DATE = CType(FindControl("txtUPD_DATE_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objUPD_USER = CType(FindControl("txtUPD_USER_" & CStr(i)), System.Web.UI.WebControls.TextBox)

            If (objTARGET.Checked) Then
                sTARGET(i) = "true"
            Else
                sTARGET(i) = "false"
            End If
            sGROUPCD(i) = objGROUPCD.Text.Trim
            sGROUPNM(i) = objGROUPNM.Text.Trim
            sHANBAITENNM(i) = objHANBAITENNM.Text.Trim
            sBIKO(i) = objBIKO.Text.Trim
            sINS_DATE(i) = objINS_DATE.Text.Trim
            sINS_USER(i) = objINS_USER.Text.Trim
            sUPD_DATE(i) = objUPD_DATE.Text.Trim
            sUPD_USER(i) = objUPD_USER.Text.Trim
        Next

        strRec = MSHATJAW00C.mSetEx(
                    CInt(pstrKBN),
                    sTARGET,
                    sGROUPCD,
                    sGROUPNM,
                    sHANBAITENNM,
                    sBIKO,
                    sINS_DATE,
                    sINS_USER,
                    sUPD_DATE,
                    sUPD_USER,
                    AuthC.pUSERNAME
                    )

        '�y���ʁz
        '  OK : ����ɏI�����܂���
        '   0 : ���̃��[�U�[�ɂ���ăf�[�^���X�V����Ă��܂��B�ēx�������Ă�������
        '   1 : ���Ƀf�[�^�����݂��܂�
        '   2 : �Ώۃf�[�^�����݂��܂���
        '   3 : �r�����䏈���ŃG���[���������܂����B�ēx���s���Ă�������
        Dim strRecTemp As String = strRec
        Dim strRecMsg As String
        Dim intRowNo As Integer = 0
        Select Case strRec
            Case "OK"
                strMsg.Append("alert('����ɏI�����܂���');")

                If pstrKBN = "1" Or pstrKBN = "2" Then
                    strRec = fncbtnKensaku_ClickEvent("2")
                Else
                    strRec = fncbtnKensaku_ClickEvent("2")
                End If
                '<TODO>�t�H�[�J�X���Z�b�g����i�����{�^���ɃZ�b�g�j
                strMsg.Append("Form1.btnSelect.focus();")
                '//------------------------------

            Case "0"
                strRecMsg = "���̃��[�U�[�ɂ���ăf�[�^���X�V����Ă��܂��B�ēx�������Ă�������"
                strMsg.Append("alert('" & strRecMsg & "');")

                '//------------------------------
                '<TODO>�t�H�[�J�X���Z�b�g����i�C�����ł̃G���[�B�����{�^���ɃZ�b�g�j
                strMsg.Append("Form1.btnSelect.focus();")
                strRec = strRecMsg
            Case "3"
                strRecMsg = "�r�����䏈���ŃG���[���������܂����B�ēx���s���Ă�������"
                strMsg.Append("alert('" & strRecMsg & "');")

                '<TODO>�t�H�[�J�X���Z�b�g����i�o�^�E�C���E�폜���ł̃G���[�B�I���{�^���ɃZ�b�g�j
                strMsg.Append("Form1.btnExit.focus();")
                strRec = strRecMsg
            Case "4"
                strRecMsg = "JA�O���[�v�쐬�}�X�^�Ŏg�p����Ă���f�[�^������܂��B\n�f�[�^���m�F���Ă�������"
                strMsg.Append("alert('" & strRecMsg & "');")

                '<TODO>�t�H�[�J�X���Z�b�g����i�o�^�E�C���E�폜���ł̃G���[�B�����{�^���ɃZ�b�g�j
                strMsg.Append("Form1.btnSelect.focus();")
                strRec = strRecMsg
            Case "5"
                strRecMsg = "�v���_�E���}�X�^�ɓo�^������܂���"
                strMsg.Append("alert('" & strRecMsg & "');")

                '<TODO>�t�H�[�J�X���Z�b�g����i�o�^�E�C�����ł̃G���[�B�I���{�^���ɃZ�b�g�j
                strMsg.Append("Form1.btnExit.focus();")
            Case "6001" To "6100"
                '�G���[�s��Ԃ��B�Ώۍs�͓��͕s�Ƃ��Ȃ��K�v�����邽�߁B
                intRowNo = CInt(strRec.Substring(1))
                strRecMsg = "�O���[�v�R�[�h���s���ł��B\n�擪�ɏ���̃A���t�@�x�b�g2��������͂��Ă�������"
                strMsg.Append("alert('" & strRecMsg & "');")
                '<TODO>�t�H�[�J�X���Z�b�g����i�o�^�E�C�����ł̃G���[�B�Ď��Z���^�[�R�[�h�����⏕�{�^���ɃZ�b�g�j
                strMsg.Append("Form1.btnSelect.focus();")
                ''<TODO>�t�H�[�J�X���Z�b�g����i�o�^�E�C�����ł̃G���[�B�Ď��Z���^�[�R�[�h�����⏕�{�^���ɃZ�b�g�j
                'strMsg.Append("Form1.txtGROUPCD_" & intRowNo & ".focus();")
            Case Else
                Dim ErrMsgC As New CErrMsg

                strMsg.Append("alert('�V�X�e���G���[�F" & ErrMsgC.mGetArtMsg(strRec) & "');")

                If pstrKBN = "1" Then
                    '//----------------------------------
                    '<TODO>�t�H�[�J�X���Z�b�g����i�o�^�����F�����ɃZ�b�g�j
                    strMsg.Append("Form1.btnSelect.focus();")
                ElseIf pstrKBN = "2" Then
                    '//----------------------------------
                    '<TODO>�t�H�[�J�X���Z�b�g����i�C�������F�����ɃZ�b�g�j
                    strMsg.Append("Form1.btnSelect.focus();")
                Else
                    '//----------------------------------
                    '<TODO>�t�H�[�J�X���Z�b�g����i���̑��@�F�����ɃZ�b�g�j
                    strMsg.Append("Form1.btnSelect.focus();")
                End If
        End Select
        For i = 1 To 100
            objGROUPCD = CType(FindControl("txtGROUPCD_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            If objGROUPCD.Text <> "" AndAlso i <> intRowNo Then
                objGROUPCD.ReadOnly = True
                objGROUPCD.BackColor = Color.Gainsboro
            End If
        Next

        '-------------------------------------------------
        '//�`�o���O��������
        Dim LogC As New CLog
        Dim strRecLog As String
        strRecLog = LogC.mAPLog(Me.Session.SessionID, AuthC.pUSERNAME, AuthC.pIPADDRESS, hdnMyAspx.Value, pstrKBN, strRec, Request.Form)

        If strRecLog <> "OK" Then
            Dim errmsgc As New CErrMsg
            strMsg.Append("alert('�V�X�e���G���[�F" & errmsgc.mGetArtMsg(strRecLog) & "');")
        End If

        Return strRec
    End Function

    '******************************************************************************
    '* ���̓L�[�ɂ��f�[�^�̌������s���܂��B
    '******************************************************************************
    Private Function fncDataSelect() As DataSet

        '//------------------------------------------
        '//<TODO>Select���̍쐬
        Dim SQLC As New MSHATJAG00CCSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet

        strSQL.Append("SELECT DISTINCT ")
        strSQL.Append("	A.GROUPCD ")
        strSQL.Append("	,A.GROUPNM ")
        strSQL.Append("	,A.HANBAITENNM ")
        strSQL.Append("	,A.BIKO ")
        strSQL.Append("	,TO_CHAR(A.INS_DATE, 'YYYY/MM/DD HH24:MI:SS') AS INS_DATE ")
        strSQL.Append("	,A.INS_USER ")
        strSQL.Append("	,TO_CHAR(A.UPD_DATE, 'YYYY/MM/DD HH24:MI:SS') AS UPD_DATE ")
        strSQL.Append("	,A.UPD_USER ")
        strSQL.Append("FROM M12_HANBAITEN A ")
        If hdnKURACD.Value.Trim.Length > 0 Then
            strSQL.Append("	,M09_JAGROUP B ")
        End If
        strSQL.Append("WHERE 1=1 ")
        If hdnKURACD.Value.Trim.Length > 0 Then
            strSQL.Append("AND B.KURACD = :KURACD ")
            strSQL.Append("AND A.GROUPCD = B.GROUPCD ")
            strSQL.Append("AND B.KBN = '004' ")
        End If
        If hdnGROUPCD_F.Value.Trim.Length > 0 Then
            strSQL.Append("AND A.GROUPCD >= :GROUPCD_F ")
        End If
        If hdnGROUPCD_T.Value.Trim.Length > 0 Then
            strSQL.Append("AND A.GROUPCD <= :GROUPCD_T ")
        End If
        strSQL.Append("ORDER BY A.GROUPCD ")


        '�N���C�A���g�R�[�h
        If hdnKURACD.Value.Trim.Length > 0 Then
            SqlParamC.fncSetParam("KURACD", True, hdnKURACD.Value.Trim)
        End If
        '�O���[�v�R�[�hFrom
        If hdnGROUPCD_F.Value.Trim.Length > 0 Then
            SqlParamC.fncSetParam("GROUPCD_F", True, hdnGROUPCD_F.Value.Trim)
        End If
        '�O���[�v�R�[�hTo
        If hdnGROUPCD_T.Value.Trim.Length > 0 Then
            SqlParamC.fncSetParam("GROUPCD_T", True, hdnGROUPCD_T.Value.Trim)
        End If

        dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

        Return dbData
    End Function


    Public Sub putlog(ByVal strMsg As String)
        Dim textFile As System.IO.StreamWriter
        Dim folder As String = ConfigurationSettings.AppSettings("JA_TAN_MST_PATH")
        textFile = New System.IO.StreamWriter(folder & "COASYUKE00.log", True, System.Text.Encoding.Default)
        textFile.WriteLine(strMsg)
        textFile.Close()
    End Sub
    '******************************************************************************
    ' Excel�o��(�`�F�b�N��)
    '******************************************************************************
    Private Sub btnCSVOUT_ServerClick(ByVal sender As System.Object, _
                                    ByVal e As System.EventArgs) Handles btnCSVOUT.ServerClick
        Dim strRec As String
        Dim MSHATJAG00C As New MSHATJAG00MSHATJAW00.MSHATJAW00

        '//�@�F�؃N���X�̃C���X�^���X����
        AuthC = New CAuthenticate(Request, Response)

        Dim strRecMsg As String = "ERROR"

        strRec = MSHATJAG00C.mCSV( _
                         Me.Session.SessionID, _
                         hdnKURACD.Value.Trim, _
                         hdnGROUPCD_F.Value.Trim, _
                         hdnGROUPCD_T.Value.Trim _
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

        Else
            '�u�J���A�ۑ��v�̃_�C�����O���o��悤��HTTP�w�b�_�ɒǉ�
            '�t�@�C�����́AHttpUtility.UrlEncode���\�b�h���g�p����SJIS�ɃG���R�[�h����K�v������
            HttpHeaderC.mDownLoadCSV(Response, "�̔��X�O���[�v�}�X�^.csv")
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
End Class
