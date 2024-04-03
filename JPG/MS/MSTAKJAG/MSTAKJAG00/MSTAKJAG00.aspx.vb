'***********************************************
'�Ď��Z���^�[�S���҃}�X�^
'***********************************************
' �ύX����

Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common
Imports JPG.Common.log

Imports System.Text

Partial Class MSTAKJAG00
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
            txtCODE.Attributes.Add("ReadOnly", "true")
            txtTANCD_F.Attributes.Add("ReadOnly", "true")
            txtTANCD_T.Attributes.Add("ReadOnly", "true")
            Dim objDefNO As System.Web.UI.WebControls.TextBox
            Dim objDefDEL As System.Web.UI.WebControls.CheckBox
            Dim i As Integer
            For i = 1 To 30
                objDefNO = CType(FindControl("txtNO_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                objDefDEL = CType(FindControl("chkDEL_" & CStr(i)), System.Web.UI.WebControls.CheckBox)

                objDefNO.Attributes.Add("ReadOnly", "true")
                objDefDEL.Checked = False
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
             MyBase.MapPath("../../../MS/MSTAKJAG/MSTAKJAG00/") & "MSTAKJAG00.js"))
        '<�t�H�[�J�X�֘A�֐�>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncFo.js"))
        '<���̓`�F�b�N�֐�>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncChk.js"))
        '<�d�b�ԍ��`�F�b�N�֐�>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncTel.js"))
        '<���l�֘A�֐�>
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

        Else
            '//--------------------------------------
            '//�@�Q��ڈȍ~���s�����
            '//--------------------------------------


        End If

        '<TODO>�����̉��ID��HIDDEN��hdnMyAspx�ɏ������ށi�V�X�e�����ʁj
        hdnMyAspx.Value = "MSTAKJAG00"
        '//-------------------------------------------------

    End Sub

    '******************************************************************************
    '* ���������������O�̉�ʏ�ԁiReadOnly��Disabled�j
    '********************************/*********************************************
    Private Sub fncIni_statebf()
        '//--------------------------------------------------------------------------
        '<TODO>�����O�̏�ԂɃR���g���[���̏�Ԃ�ݒ肷��

        btnCODE.Disabled = False
        btnTANCD_F.Disabled = False
        btnTANCD_T.Disabled = False

    End Sub

    '******************************************************************************
    '* �������������ꂽ��̉�ʏ�ԁiReadOnly��Disabled�j
    '******************************************************************************
    Private Sub fncIni_stateaf()
        '//--------------------------------------------------------------------------
        '<TODO>������̏�ԂɃR���g���[���̏�Ԃ�ݒ肷��
        '
        txtCODE.Attributes.Add("ReadOnly", "true")
        txtTANCD_F.Attributes.Add("ReadOnly", "true")
        txtTANCD_T.Attributes.Add("ReadOnly", "true")
        Dim objNO As System.Web.UI.WebControls.TextBox
        Dim objDEL As System.Web.UI.WebControls.CheckBox
        Dim i As Integer
        For i = 1 To 30
            objNO = CType(FindControl("txtNO_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objDEL = CType(FindControl("chkDEL_" & CStr(i)), System.Web.UI.WebControls.CheckBox)

            objNO.Attributes.Add("ReadOnly", "true")
            objDEL.Checked = False
        Next
    End Sub

    '******************************************************************************
    '* �e�R���g���[���̐ݒ�l�̏�����
    '******************************************************************************
    Private Sub fncIni_format()
        '//--------------------------------------------------------------------------
        txtCODE.Text = ""
        hdnCODE.Value = ""
        txtTANCD_F.Text = ""
        hdnTANCD_F.Value = ""
        txtTANCD_T.Text = ""
        hdnTANCD_T.Value = ""

        '�L�[�ȊO�̒l������������
        Call fncIni_notkey()

    End Sub

    '******************************************************************************
    '* �L�[�ȊO�̒l������������
    '******************************************************************************
    Private Sub fncIni_notkey()

        '//--------------------------------------------------------------------------
        '<TODO>�R���g���[���̒l������������

        hdnCODE_MOTO.Value = ""
        hdnTANCD_F_MOTO.Value = ""
        hdnTANCD_T_MOTO.Value = ""

        Dim objDEL As System.Web.UI.WebControls.CheckBox
        Dim objTANCD As System.Web.UI.WebControls.TextBox
        Dim objTANNM As System.Web.UI.WebControls.TextBox
        Dim objTANID As System.Web.UI.WebControls.TextBox    '2020/11/01 T.Ono add 2020 �Ď����P2020
        Dim objDISP_NO As System.Web.UI.WebControls.TextBox
        Dim objBIKO As System.Web.UI.WebControls.TextBox
        Dim objADD_DATE As System.Web.UI.HtmlControls.HtmlInputHidden
        Dim objEDT_DATE As System.Web.UI.HtmlControls.HtmlInputHidden
        Dim objTIME As System.Web.UI.HtmlControls.HtmlInputHidden

        Dim i As Integer

        For i = 1 To 30
            '�R���g���[������T���o���A�^�ϊ�
            objDEL = CType(FindControl("chkDEL_" & CStr(i)), System.Web.UI.WebControls.CheckBox)
            objTANCD = CType(FindControl("txtTANCD_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objTANNM = CType(FindControl("txtTANNM_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objTANID = CType(FindControl("txtTANID_" & CStr(i)), System.Web.UI.WebControls.TextBox)    '2020/11/01 T.Ono add 2020�Ď����P
            objDISP_NO = CType(FindControl("txtDISP_NO_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objBIKO = CType(FindControl("txtBIKO_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objADD_DATE = CType(FindControl("hdnADD_DATE_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
            objEDT_DATE = CType(FindControl("hdnEDT_DATE_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
            objTIME = CType(FindControl("hdnTIME_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)


            objDEL.Checked = False
            objTANCD.Text = ""
            objTANNM.Text = ""
            objTANID.Text = ""    '2020/11/01 T.Ono add 2020�Ď����P
            objDISP_NO.Text = ""
            objBIKO.Text = ""
            objADD_DATE.Value = ""
            objEDT_DATE.Value = ""
            objTIME.Value = ""
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
            If hdnPopcrtl.Value = "1" Then      '//�Ď��Z���^�[�R�[�h�ꗗ
                strRec = AuthC.pAUTHCENTERCD    '//�`�c�F�؂̎g�p�\�Ď��Z���^�[�R�[�h
            ElseIf hdnPopcrtl.Value = "2" Then  '//�S���҃R�[�h�iFrom�j�ꗗ
                strRec = hdnCODE.Value.Trim     '//�Ď��Z���^�[�R�[�h
            ElseIf hdnPopcrtl.Value = "3" Then  '//�S���҃R�[�h�iTo�j�ꗗ
                strRec = hdnCODE.Value.Trim     '//�Ď��Z���^�[�R�[�h
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
            If hdnPopcrtl.Value = "1" Then          '//�Ď��Z���^�[�R�[�h�ꗗ
                strRec = "�Ď��Z���^�[�R�[�h�ꗗ"
            ElseIf hdnPopcrtl.Value = "2" Then      '//�S���҃R�[�h�iFrom�j�ꗗ
                strRec = "�Ď��Z���^�[�S���҈ꗗ"
            ElseIf hdnPopcrtl.Value = "3" Then      '//�S���҃R�[�h�iTo�j�ꗗ
                strRec = "�Ď��Z���^�[�S���҈ꗗ"
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
                strRec = "KANSHI"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = "TKTANCDKN_ORDCD"
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = "TKTANCDKN_ORDCD"
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
                strRec = "hdnCODE"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = "hdnTANCD_F"
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = "hdnTANCD_T"
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
                strRec = "txtCODE"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = "txtTANCD_F"
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = "txtTANCD_T"
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
                strRec = "btnCODE"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = "btnTANCD_F"
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = "btnTANCD_T"
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
                strRec = "txtTANCD_F"
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
                strRec = "hdnTANCD_F"
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
                strRec = "txtTANCD_T"
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
                strRec = "hdnTANCD_T"
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
                strRec = ""
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
                '<TODO>30���ȏ�̏ꍇ�̓��b�Z�[�W
                If dbData.Tables(0).Rows.Count > 30 Then
                    strMsg.Append("alert('�ő�o�͌����𒴂��܂����B�������w�肵�čēx�������Ă�������');")
                End If

                '------------------------------------
                '<TODO>�f�[�^���o�͂���

                '�Ď��Z���^�[�R�[�h
                hdnCODE.Value = Convert.ToString(dbData.Tables(0).Rows(0).Item("CODE"))
                hdnCODE_MOTO.Value = Convert.ToString(dbData.Tables(0).Rows(0).Item("CODE"))
                '�Ď��Z���^�[��
                txtCODE.Text = Convert.ToString(dbData.Tables(0).Rows(0).Item("CODE")) & " : " & Convert.ToString(dbData.Tables(0).Rows(0).Item("KANSI_NAME"))

                Dim objTANCD As System.Web.UI.WebControls.TextBox
                Dim objTANNM As System.Web.UI.WebControls.TextBox
                Dim objTANID As System.Web.UI.WebControls.TextBox    '2020/11/01 T.Ono add 2020�Ď����P
                Dim objDISP_NO As System.Web.UI.WebControls.TextBox
                Dim objBIKO As System.Web.UI.WebControls.TextBox
                Dim objADD_DATE As System.Web.UI.HtmlControls.HtmlInputHidden
                Dim objEDT_DATE As System.Web.UI.HtmlControls.HtmlInputHidden
                Dim objTIME As System.Web.UI.HtmlControls.HtmlInputHidden

                Dim intRow As Integer

                For intRow = 0 To dbData.Tables(0).Rows.Count - 1

                    If intRow >= 30 Then Exit For '30���ȏ�͏�������

                    '----------------------------
                    ' ���׏�����ʍ��ڂɃZ�b�g
                    '----------------------------
                    '�R���g���[������T���o���A�^�ϊ�
                    objTANCD = CType(FindControl("txtTANCD_" & CStr(intRow + 1)), System.Web.UI.WebControls.TextBox)
                    objTANNM = CType(FindControl("txtTANNM_" & CStr(intRow + 1)), System.Web.UI.WebControls.TextBox)
                    objTANID = CType(FindControl("txtTANID_" & CStr(intRow + 1)), System.Web.UI.WebControls.TextBox)    '2020/11/01 T.Ono add 2020�Ď����P
                    objDISP_NO = CType(FindControl("txtDISP_NO_" & CStr(intRow + 1)), System.Web.UI.WebControls.TextBox)
                    objBIKO = CType(FindControl("txtBIKO_" & CStr(intRow + 1)), System.Web.UI.WebControls.TextBox)
                    objADD_DATE = CType(FindControl("hdnADD_DATE_" & CStr(intRow + 1)), System.Web.UI.HtmlControls.HtmlInputHidden)
                    objEDT_DATE = CType(FindControl("hdnEDT_DATE_" & CStr(intRow + 1)), System.Web.UI.HtmlControls.HtmlInputHidden)
                    objTIME = CType(FindControl("hdnTIME_" & CStr(intRow + 1)), System.Web.UI.HtmlControls.HtmlInputHidden)

                    '�L�[���ڂ͕ύX�s�ɂ���
                    objTANCD.ReadOnly = True
                    objTANCD.BackColor = Color.Gainsboro

                    objTANCD.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("TANCD"))
                    objTANNM.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("TANNM"))
                    objTANID.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("GUIDELINE"))    '2020/11/01 T.Ono add 2020�Ď����P
                    objDISP_NO.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("DISP_NO"))
                    objBIKO.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("BIKO"))
                    objADD_DATE.Value = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("ADD_DATE"))
                    objEDT_DATE.Value = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("EDT_DATE"))
                    objTIME.Value = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("TIME"))

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
        Dim MSTAKJAW00C As New MSTAKJAG00MSTAKJAW00.MSTAKJAW00

        '//-----------------------------------------------
        '<TODO>�Ď��Z���^�[�S���҂͋敪=1
        Dim strKBN As String
        strKBN = "1"

        '//-----------------------------------------------
        '<TODO>�N���C�A���g�R�[�h="ZZZZ"
        Dim strKURACD As String
        strKURACD = "ZZZZ"

        '//-----------------------------------------------
        '<TODO>�S���҃R�[�hFrom�ETo
        Dim strTANCD_F As String
        Dim strTANCD_T As String
        strTANCD_F = hdnTANCD_F.Value
        strTANCD_T = hdnTANCD_T.Value


        '�l��z��ɃZ�b�g
        Dim sTANCD(30) As String
        Dim sTANNM(30) As String
        Dim sTANID(30) As String    '2020/11/01 T.Ono add 2020�Ď����P
        Dim sDISP_NO(30) As String
        Dim sBIKO(30) As String
        Dim sDEL(30) As String
        Dim sADD_DATE(30) As String
        Dim sEDT_DATE(30) As String
        Dim sTIME(30) As String
        Dim objTANCD As System.Web.UI.WebControls.TextBox
        Dim objTANNM As System.Web.UI.WebControls.TextBox
        Dim objTANID As System.Web.UI.WebControls.TextBox    '2020/11/01 T.Ono add 2020�Ď����P
        Dim objDISP_NO As System.Web.UI.WebControls.TextBox
        Dim objBIKO As System.Web.UI.WebControls.TextBox
        Dim objDEL As System.Web.UI.WebControls.CheckBox
        Dim objADD_DATE As System.Web.UI.HtmlControls.HtmlInputHidden
        Dim objEDT_DATE As System.Web.UI.HtmlControls.HtmlInputHidden
        Dim objTIME As System.Web.UI.HtmlControls.HtmlInputHidden
        Dim i As Integer

        For i = 1 To 30
            '�R���g���[������T���o���A�^�ϊ�
            objTANCD = CType(FindControl("txtTANCD_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objTANNM = CType(FindControl("txtTANNM_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objTANID = CType(FindControl("txtTANID_" & CStr(i)), System.Web.UI.WebControls.TextBox)    '2020/11/01 T.Ono add 2020�Ď����P
            objDISP_NO = CType(FindControl("txtDISP_NO_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objBIKO = CType(FindControl("txtBIKO_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objDEL = CType(FindControl("chkDEL_" & CStr(i)), System.Web.UI.WebControls.CheckBox)
            objADD_DATE = CType(FindControl("hdnADD_DATE_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
            objEDT_DATE = CType(FindControl("hdnEDT_DATE_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
            objTIME = CType(FindControl("hdnTIME_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)


            sTANCD(i) = Trim(objTANCD.Text)
            sTANNM(i) = Trim(objTANNM.Text)
            sTANID(i) = Trim(objTANID.Text)
            sDISP_NO(i) = Trim(objDISP_NO.Text)
            sBIKO(i) = Trim(objBIKO.Text)
            If (objDEL.Checked) Then
                sDEL(i) = "true"
            Else
                sDEL(i) = "false"
            End If
            sADD_DATE(i) = objADD_DATE.Value
            sEDT_DATE(i) = objEDT_DATE.Value
            sTIME(i) = objTIME.Value
        Next

        '2020/11/01 T.Ono mod 2020�Ď����P sTANID�ǉ�
        strRec = MSTAKJAW00C.mSetEx(
                    CInt(pstrKBN),
                    strKBN,
                    strKURACD,
                    hdnCODE.Value,
                    strTANCD_F,
                    strTANCD_T,
                    sTANCD,
                    sTANNM,
                    sTANID,
                    sDISP_NO,
                    sBIKO,
                    sDEL,
                    sADD_DATE,
                    sEDT_DATE,
                    sTIME)

        '�y���ʁz
        '  OK : ����ɏI�����܂���
        '   0 : ���̃��[�U�[�ɂ���ăf�[�^���X�V����Ă��܂��B�ēx�������Ă�������
        '   1 : ���Ƀf�[�^�����݂��܂�
        '   2 : �Ώۃf�[�^�����݂��܂���
        '   3 : �r�����䏈���ŃG���[���������܂����B�ēx���s���Ă�������
        Dim strRecTemp As String = strRec
        Dim strRecMsg As String
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
                strRecMsg = "�Ď��Z���^�[�R�[�h�����݂��܂���"
                strMsg.Append("alert('" & strRecMsg & "');")

                '<TODO>�t�H�[�J�X���Z�b�g����i�o�^�E�C�����ł̃G���[�B�Ď��Z���^�[�R�[�h�����⏕�{�^���ɃZ�b�g�j
                strMsg.Append("Form1.btnCODE.focus();")

            Case Else
                Dim ErrMsgC As New CErrMsg

                strMsg.Append("alert('�V�X�e���G���[�F" & ErrMsgC.mGetArtMsg(strRec) & "');")

                If pstrKBN = "1" Then
                    '//----------------------------------
                    '<TODO>�t�H�[�J�X���Z�b�g����i�o�^�����F���O�o�͂̃G���[�̈׃L�[�ɃZ�b�g�j
                ElseIf pstrKBN = "2" Then
                    '//----------------------------------
                    '<TODO>�t�H�[�J�X���Z�b�g����i�C�������F���O�o�͂̃G���[�̈׃L�[�ȍ~�ɃZ�b�g�j
                    strMsg.Append("Form1.txtTANCD_1.focus();")
                Else
                    '//----------------------------------
                    '<TODO>�t�H�[�J�X���Z�b�g����i���̑��@�F���O�o�͂̃G���[�̈׃L�[�ȍ~�ɃZ�b�g�j
                    strMsg.Append("Form1.txtTANCD_1.focus();")
                End If
        End Select
        For i = 1 To 30
            objTANCD = CType(FindControl("txtTANCD_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            If objTANCD.Text <> "" Then
                objTANCD.ReadOnly = True
                objTANCD.BackColor = Color.Gainsboro
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
        Dim SQLC As New MSTAKJAG00CCSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet

        strSQL.Append(" SELECT ")
        strSQL.Append(" 	A.KBN ")
        strSQL.Append(" 	,A.KURACD ")
        strSQL.Append(" 	,A.CODE ")
        strSQL.Append(" 	,B.KANSI_NAME ")
        strSQL.Append(" 	,A.TANCD ")
        strSQL.Append(" 	,A.TANNM ")
        strSQL.Append(" 	,A.GUIDELINE ")    '�S����ID�@2020/11/01 T.Ono add 2020�Ď����P
        strSQL.Append(" 	,A.DISP_NO ")
        strSQL.Append(" 	,A.BIKO ")
        strSQL.Append(" 	,A.ADD_DATE ")
        strSQL.Append(" 	,A.EDT_DATE ")
        strSQL.Append(" 	,A.TIME ")
        strSQL.Append(" FROM  ")
        strSQL.Append(" 	M05_TANTO A ")
        strSQL.Append(" 	,KANSIMAS B ")
        strSQL.Append(" WHERE 1=1 ")
        strSQL.Append(" AND	A.KBN = '1' ")
        strSQL.Append(" AND	A.KURACD = 'ZZZZ' ")
        strSQL.Append(" AND	A.CODE = :CODE ")
        strSQL.Append(" AND A.CODE = B.KANSI_CD ")
        If hdnTANCD_F.Value.Trim.Length > 0 Then
            strSQL.Append(" AND	TO_NUMBER(A.TANCD) >= TO_NUMBER(:TANCD_F) ")
        End If
        If hdnTANCD_T.Value.Trim.Length > 0 Then
            strSQL.Append(" AND	TO_NUMBER(A.TANCD) <= TO_NUMBER(:TANCD_T) ")
        End If
        strSQL.Append(" ORDER BY TO_NUMBER(A.TANCD) ")


        '�Ď��Z���^�[�R�[�h
        If hdnCODE.Value.Trim.Length > 0 Then
            SqlParamC.fncSetParam("CODE", True, hdnCODE.Value.Trim)
        End If
        '�S���҃R�[�hFrom
        If hdnTANCD_F.Value.Trim.Length > 0 Then
            SqlParamC.fncSetParam("TANCD_F", True, hdnTANCD_F.Value.Trim)
        End If
        '�S���҃R�[�hTo
        If hdnTANCD_T.Value.Trim.Length > 0 Then
            SqlParamC.fncSetParam("TANCD_T", True, hdnTANCD_T.Value.Trim)
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
    Private Sub btnCSVout_ServerClick(ByVal sender As System.Object, _
                                    ByVal e As System.EventArgs) Handles btnCSVout.ServerClick
        Dim strRec As String
        Dim MSTAKJAG00C As New MSTAKJAG00MSTAKJAW00.MSTAKJAW00

        '//�@�F�؃N���X�̃C���X�^���X����
        AuthC = New CAuthenticate(Request, Response)

        Dim strRecMsg As String = "ERROR"

        strRec = MSTAKJAG00C.mCSV( _
                         Me.Session.SessionID, _
                         hdnCODE.Value, _
                         hdnTANCD_F.Value.Trim, _
                         hdnTANCD_T.Value.Trim _
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
            HttpHeaderC.mDownLoadCSV(Response, "�Ď��Z���^�[�S����.csv")
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
