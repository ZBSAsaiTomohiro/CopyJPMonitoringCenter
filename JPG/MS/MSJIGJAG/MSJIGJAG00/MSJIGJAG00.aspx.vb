'***********************************************
' �����Z���^�[�}�X�^  ���C�����
'***********************************************
' �ύX����

Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common
Imports JPG.Common.log

Imports System.Text

Partial Class MSJIGJAG00
    Inherits System.Web.UI.Page

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

    Private strCBO_GROUPCD(50) As String
    Private strCBO_USE_FLG(50) As String

    '******************************************************************************
    ' Page_Load
    '******************************************************************************
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '.NET�̎d�l�ύX�ɂ��AReadOnly������ASPX�ł���ƁA�T�[�o���Œl�̎Q�Ƃ��ł��Ȃ��Ȃ邽�߁AVB����Attribute�ł���
        If MyBase.IsPostBack = False Then
            txtKURACD.Attributes.Add("ReadOnly", "true")
            txtACBCD_F.Attributes.Add("ReadOnly", "true")
            txtACBCD_T.Attributes.Add("ReadOnly", "true")
            Dim objDefNO As System.Web.UI.WebControls.TextBox
            Dim objDefDEL As System.Web.UI.WebControls.CheckBox
            Dim i As Integer
            For i = 1 To 50
                objDefNO = CType(FindControl("txtNO_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                objDefDEL = CType(FindControl("chkDEL_" & CStr(i)), System.Web.UI.WebControls.CheckBox)

                objDefNO.Attributes.Add("ReadOnly", "true")
                objDefDEL.Checked = False
            Next
        End If
        '2012/04/03 NEC ou Add

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
             MyBase.MapPath("../../../MS/MSJIGJAG/MSJIGJAG00/") & "MSJIGJAG00.js"))
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

        Else
            '//--------------------------------------
            '//�@�Q��ڈȍ~���s�����
            '//--------------------------------------

            '�R���{�{�b�N�X�̍Đݒ�
            '�O���[�v�R�[�h(KEY)
            Dim list As ListItem
            fncCombo_Create_GROUPCD_KEY()
            list = cboGROUPCD.Items.FindByValue(Request.Form("cboGROUPCD"))
            cboGROUPCD.SelectedIndex = cboGROUPCD.Items.IndexOf(list)

            '�ꗗ�̃R���{�{�b�N�X�̍Đݒ�
            fncCombo_Create_GROUPCD() '�O���[�v�R�[�h�́A�֐����Ń��[�v���邽�ߊO�ŁB
            Dim i As Integer
            For i = 1 To 50
                fncCombo_Create_USE_FLG(i)
                fncComboGet(i)
                fncComboSet(i)
            Next


        End If

        '<TODO>�����̉��ID��HIDDEN��hdnMyAspx�ɏ������ށi�V�X�e�����ʁj
        hdnMyAspx.Value = "MSJIGJAG00"
        '//-------------------------------------------------

    End Sub

    '******************************************************************************
    '* ���������������O�̉�ʏ�ԁiReadOnly��Disabled�j
    '********************************/*********************************************
    Private Sub fncIni_statebf()
        '//--------------------------------------------------------------------------
        '<TODO>�����O�̏�ԂɃR���g���[���̏�Ԃ�ݒ肷��

        btnKURACD.Disabled = False
        btnACBCD_F.Disabled = False
        btnACBCD_T.Disabled = False

    End Sub

    '******************************************************************************
    '* �������������ꂽ��̉�ʏ�ԁiReadOnly��Disabled�j
    '******************************************************************************
    Private Sub fncIni_stateaf()
        '//--------------------------------------------------------------------------
        '<TODO>������̏�ԂɃR���g���[���̏�Ԃ�ݒ肷��
        '

        txtKURACD.Attributes.Add("ReadOnly", "true")
        txtACBCD_F.Attributes.Add("ReadOnly", "true")
        txtACBCD_T.Attributes.Add("ReadOnly", "true")
        Dim objNO As System.Web.UI.WebControls.TextBox
        Dim objDEL As System.Web.UI.WebControls.CheckBox
        Dim i As Integer
        For i = 1 To 50
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
        txtKURACD.Text = ""
        hdnKURACD.Value = ""
        txtACBCD_F.Text = ""
        hdnACBCD_F.Value = ""
        txtACBCD_T.Text = ""
        hdnACBCD_T.Value = ""
        fncCombo_Create_GROUPCD_KEY() '�O���[�v�R�[�h
        hdnGROUPCD.Value = ""

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
        hdnACBCD_F_MOTO.Value = ""
        hdnACBCD_T_MOTO.Value = ""
        hdnGROUPCD_MOTO.Value = ""

        Dim objDEL As System.Web.UI.WebControls.CheckBox
        Dim objKURACD As System.Web.UI.WebControls.TextBox
        Dim objACBCD As System.Web.UI.WebControls.TextBox
        Dim objBIKO As System.Web.UI.WebControls.TextBox
        Dim objINS_DATE As System.Web.UI.HtmlControls.HtmlInputHidden
        Dim objUPD_DATE As System.Web.UI.HtmlControls.HtmlInputHidden

        Dim i As Integer
        For i = 1 To 50
            objDEL = CType(FindControl("chkDEL_" & CStr(i)), System.Web.UI.WebControls.CheckBox)
            objKURACD = CType(FindControl("txtKURACD_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objACBCD = CType(FindControl("txtACBCD_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objBIKO = CType(FindControl("txtBIKO_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objINS_DATE = CType(FindControl("hdnINS_DATE_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
            objUPD_DATE = CType(FindControl("hdnUPD_DATE_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)


            objDEL.Checked = False
            objKURACD.Text = ""
            objACBCD.Text = ""
            objBIKO.Text = ""
            objINS_DATE.Value = ""
            objUPD_DATE.Value = ""

            fncCombo_Create_USE_FLG(i)

        Next

        '�O���[�v�R�[�h�̃Z�b�g�@�f�[�^�擾��1�x�ōς܂����߁A�����Ń��[�v������
        fncCombo_Create_GROUPCD()

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
    '* �ꊇ�o�^�{�^�����������ꂽ�Ƃ��̏���
    '******************************************************************************
    Private Sub btnIkkatu_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIkkatu.ServerClick
        Dim strRec As String
        strRec = fncbtnIkkatu_ClickEvent(hdnKBN.Value)

        Call fncIni_stateaf()
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
            ElseIf hdnPopcrtl.Value = "2" Then  '//JA�x���R�[�h�iFrom�j�ꗗ
                strRec = hdnKURACD.Value
            ElseIf hdnPopcrtl.Value = "3" Then  '//JA�x���R�[�h�iTo�j�ꗗ
                strRec = hdnKURACD.Value
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
                strRec = "�N���C�A���g�R�[�h�ꗗ"
            ElseIf hdnPopcrtl.Value = "2" Then      '//JA�x���R�[�h�iFrom�j�ꗗ
                strRec = "�i�`�x���R�[�h�ꗗ"
            ElseIf hdnPopcrtl.Value = "3" Then      '//JA�x���R�[�h�iTo�j�ꗗ
                strRec = "�i�`�x���R�[�h�ꗗ"
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
                strRec = "JASS"
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = "JASS"
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
                strRec = "hdnACBCD_F"
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = "hdnACBCD_T"
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
                strRec = "txtACBCD_F"
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = "txtACBCD_T"
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
                strRec = "btnACBCD_F"
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = "btnACBCD_T"
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
                strRec = "txtACBCD_F"
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
                strRec = "hdnACBCD_F"
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
                strRec = "txtACBCD_T"
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
                strRec = "hdnACBCD_T"
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
                '<TODO>�t�H�[�J�X���Z�b�g����i�����{�^���ɃZ�b�g�j
                strMsg.Append("Form1.btnSelect.focus();")

                '//--------------------------------------------------------------------------
            Else
                '�f�[�^�����݂���ׁA�f�[�^�o��

                '------------------------------------
                '<TODO>50���ȏ�̏ꍇ�̓��b�Z�[�W
                If dbData.Tables(0).Rows.Count > 50 Then
                    strMsg.Append("alert('�ő�o�͌����𒴂��܂����B�������w�肵�čēx�������Ă�������');")
                End If

                '------------------------------------
                '<TODO>�f�[�^���o�͂���

                ''�N���C�A���g�R�[�h
                'hdnKURACD.Value = Convert.ToString(dbData.Tables(0).Rows(0).Item("KURACD"))
                'hdnKURACD_MOTO.Value = Convert.ToString(dbData.Tables(0).Rows(0).Item("KURACD"))
                ''�N���C�A���g��
                'txtKURACD.Text = Convert.ToString(dbData.Tables(0).Rows(0).Item("KURACD")) & " : " & Convert.ToString(dbData.Tables(0).Rows(0).Item("CLI_NAME"))

                '�N���C�A���g�R�[�h
                If hdnKURACD.Value.Length <> 0 Then
                    hdnKURACD_MOTO.Value = hdnKURACD.Value.Trim
                Else
                    hdnKURACD_MOTO.Value = ""
                End If
                'JA�x���R�[�h
                If hdnACBCD_F.Value.Length <> 0 Then
                    hdnACBCD_F_MOTO.Value = hdnACBCD_F.Value.Trim
                Else
                    hdnACBCD_F_MOTO.Value = ""
                End If
                If hdnACBCD_T.Value.Length <> 0 Then
                    hdnACBCD_T_MOTO.Value = hdnACBCD_T.Value.Trim
                Else
                    hdnACBCD_T_MOTO.Value = ""
                End If
                '�O���[�v�R�[�h
                If cboGROUPCD.SelectedIndex <> 0 Then
                    hdnGROUPCD.Value = Convert.ToString(cboGROUPCD.Items.Item(CInt(Request.Form("cboGROUPCD"))))
                    hdnGROUPCD_MOTO.Value = hdnGROUPCD.Value.Trim
                Else
                    hdnGROUPCD.Value = ""
                    hdnGROUPCD_MOTO.Value = ""
                End If


                Dim objKURACD As System.Web.UI.WebControls.TextBox
                Dim objACBCD As System.Web.UI.WebControls.TextBox
                Dim objBIKO As System.Web.UI.WebControls.TextBox
                Dim objINS_DATE As System.Web.UI.HtmlControls.HtmlInputHidden
                Dim objUPD_DATE As System.Web.UI.HtmlControls.HtmlInputHidden

                Dim intRow As Integer

                For intRow = 0 To dbData.Tables(0).Rows.Count - 1

                    If intRow >= 50 Then Exit For '50���ȏ�͏�������

                    '----------------------------
                    ' ���׏�����ʍ��ڂɃZ�b�g
                    '----------------------------
                    '�R���g���[������T���o���A�^�ϊ�
                    objKURACD = CType(FindControl("txtKURACD_" & CStr(intRow + 1)), System.Web.UI.WebControls.TextBox)
                    objACBCD = CType(FindControl("txtACBCD_" & CStr(intRow + 1)), System.Web.UI.WebControls.TextBox)
                    objBIKO = CType(FindControl("txtBIKO_" & CStr(intRow + 1)), System.Web.UI.WebControls.TextBox)
                    objINS_DATE = CType(FindControl("hdnINS_DATE_" & CStr(intRow + 1)), System.Web.UI.HtmlControls.HtmlInputHidden)
                    objUPD_DATE = CType(FindControl("hdnUPD_DATE_" & CStr(intRow + 1)), System.Web.UI.HtmlControls.HtmlInputHidden)

                    '�L�[���ڂ͕ύX�s�ɂ���
                    objKURACD.ReadOnly = True
                    objKURACD.BackColor = Color.Gainsboro
                    objACBCD.ReadOnly = True
                    objACBCD.BackColor = Color.Gainsboro

                    objKURACD.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("KURACD"))
                    objACBCD.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("ACBCD"))
                    objBIKO.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("BIKO"))
                    objINS_DATE.Value = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("INS_DATE"))
                    objUPD_DATE.Value = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("UPD_DATE"))

                    strCBO_GROUPCD(intRow + 1) = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("GROUPCD"))
                    strCBO_USE_FLG(intRow + 1) = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("USE_FLG"))

                    fncComboSet(intRow + 1)
                Next ' intRow


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

        Dim MSJIGJAW00C As New MSJIGJAG00MSJIGJAW00.MSJIGJAW00


        '�l��z��ɃZ�b�g
        Dim objKURACD As System.Web.UI.WebControls.TextBox
        Dim objACBCD As System.Web.UI.WebControls.TextBox
        Dim objGROUPCD As JPG.Common.Controls.CTLCombo
        Dim objINS_DATE As System.Web.UI.HtmlControls.HtmlInputHidden
        Dim objUPD_DATE As System.Web.UI.HtmlControls.HtmlInputHidden
        Dim objBIKO As System.Web.UI.WebControls.TextBox
        Dim objDEL As System.Web.UI.WebControls.CheckBox
        Dim sKURACD(50) As String
        Dim sACBCD(50) As String
        Dim sGROUPCD(50) As String
        Dim sUSE_FLG(50) As String
        Dim sINS_DATE(50) As String
        Dim sUPD_DATE(50) As String
        Dim sBIKO(50) As String
        Dim sDEL(50) As String
        Dim i As Integer
        For i = 1 To 50
            objKURACD = CType(FindControl("txtKURACD_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objACBCD = CType(FindControl("txtACBCD_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objGROUPCD = CType(FindControl("cboGROUPCD_" & CStr(i)), JPG.Common.Controls.CTLCombo)
            objINS_DATE = CType(FindControl("hdnINS_DATE_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
            objUPD_DATE = CType(FindControl("hdnUPD_DATE_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
            objBIKO = CType(FindControl("txtBIKO_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objDEL = CType(FindControl("chkDEL_" & CStr(i)), System.Web.UI.WebControls.CheckBox)

            sKURACD(i) = objKURACD.Text.Trim
            sACBCD(i) = objACBCD.Text.Trim
            sUSE_FLG(i) = Request.Form("cboUSE_FLG_" & i)
            sINS_DATE(i) = objINS_DATE.Value.Trim
            sUPD_DATE(i) = objUPD_DATE.Value.Trim
            sBIKO(i) = objBIKO.Text.Trim

            If Request.Form("cboGROUPCD_" & i) <> "" Then
                sGROUPCD(i) = Convert.ToString(objGROUPCD.Items.Item(CInt(Request.Form("cboGROUPCD_" & i)))) '�C���f�b�N�X����Ȃ��āA�R�[�h���K�v
            Else
                sGROUPCD(i) = ""
            End If


            If (objDEL.Checked) Then
                sDEL(i) = "true"
            Else
                sDEL(i) = "false"
            End If

        Next
        strRec = MSJIGJAW00C.mSetEx( _
                    CInt(pstrKBN), _
                    sKURACD, _
                    sACBCD, _
                    sGROUPCD, _
                    sUSE_FLG, _
                    sINS_DATE, _
                    sUPD_DATE, _
                    sBIKO, _
                    sDEL)

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
            Case "1"
                strRecMsg = "���Ƀf�[�^�����݂��܂�"
                strMsg.Append("alert('" & strRecMsg & "');")

                '//------------------------------
                strRec = strRecMsg
            Case "2"
                strRecMsg = "�Ώۃf�[�^�����݂��܂���"
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
                strRecMsg = "�N���C�A���g�R�[�h�����݂��܂���"
                strMsg.Append("alert('" & strRecMsg & "');")

                '<TODO>�t�H�[�J�X���Z�b�g����i�o�^�E�C�����ł̃G���[�B�����{�^���ɃZ�b�g�j
                strMsg.Append("Form1.btnSelect.focus();")

                strRec = strRecMsg
            Case "5"
                strRecMsg = "JA�x���R�[�h�����݂��܂���"
                strMsg.Append("alert('" & strRecMsg & "');")

                '<TODO>�t�H�[�J�X���Z�b�g����i�o�^�E�C�����ł̃G���[�B�����{�^���ɃZ�b�g�j
                strMsg.Append("Form1.btnSelect.focus();")

                strRec = strRecMsg
            Case Else
                Dim ErrMsgC As New CErrMsg

                strMsg.Append("alert('�V�X�e���G���[�F" & ErrMsgC.mGetArtMsg(strRec) & "');")

                If pstrKBN = "1" Then
                    '//----------------------------------
                    '<TODO>�t�H�[�J�X���Z�b�g����i�o�^�����F���O�o�͂̃G���[�̈׃L�[�ɃZ�b�g�j
                ElseIf pstrKBN = "2" Then
                    '//----------------------------------
                    '<TODO>�t�H�[�J�X���Z�b�g����i�C�������F���O�o�͂̃G���[�̈׃L�[�ȍ~�ɃZ�b�g�j
                    strMsg.Append("Form1.txtKURACD_1.focus();")
                Else
                    '//----------------------------------
                    '<TODO>�t�H�[�J�X���Z�b�g����i���̑��@�F���O�o�͂̃G���[�̈׃L�[�ȍ~�ɃZ�b�g�j
                    strMsg.Append("Form1.txtKURACD_1.focus();")
                End If
        End Select

        For i = 1 To 50
            objKURACD = CType(FindControl("txtKURACD_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objACBCD = CType(FindControl("txtACBCD_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            If objKURACD.Text <> "" Then
                objKURACD.ReadOnly = True
                objKURACD.BackColor = Color.Gainsboro
                objACBCD.ReadOnly = True
                objACBCD.BackColor = Color.Gainsboro
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
    '* �ꊇ�o�^���������ꂽ�Ƃ��̏���
    '******************************************************************************
    Private Function fncbtnIkkatu_ClickEvent(ByVal pstrKBN As String) As String

        Dim strRec As String = ""
        Dim DateFncC As New CDateFnc

        Dim MSJIGJAW00C As New MSJIGJAG00MSJIGJAW00.MSJIGJAW00


        '�z��p��
        Dim sKURACD() As String = {""}
        Dim sACBCD() As String = {""}
        Dim sGROUPCD() As String = {""}
        Dim sUSE_FLG() As String = {""}
        Dim sINS_DATE() As String = {""}
        Dim sUPD_DATE() As String = {""}
        Dim sBIKO() As String = {""}
        Dim sDEL() As String = {""}
        '�d���m�F
        Dim bolchkCHOUFUKU As Boolean = False 'True�F�d���Ȃ��@False�F�d������NG
        '����
        Dim dbData As DataSet
        Dim bolDataSelect As Boolean = False 'True�F�Ώۃf�[�^����@False�F�Ώۃf�[�^�Ȃ�NG


        Try

            hdnGROUPCD.Value = Convert.ToString(cboGROUPCD.Items.Item(CInt(Request.Form("cboGROUPCD"))))

            '�d���m�F
            bolchkCHOUFUKU = fncchkCHOUFUKU()
            If bolchkCHOUFUKU = False Then
                strMsg.Append("alert('�o�^�ς݃f�[�^�����݂��܂��B�������ăf�[�^���m�F���Ă�������');")

                Call fncIni_statebf()

                '//------------------------------
                '<TODO>�t�H�[�J�X���Z�b�g����i�����{�^���ɃZ�b�g�j
                strMsg.Append("Form1.btnSelect.focus();")
                strRec = "�d���`�F�b�N"
                Return strRec
            End If

            '����
            dbData = fncDataSelect_Ikkatu()

            If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
                '�f�[�^�����݂��Ȃ��ׁA�����̓G���[
                '���b�Z�[�W���o�͌�A�����O��Ԃɂ���B
                strMsg.Append("alert('�f�[�^�����݂��܂���');")

                Call fncIni_statebf()

                '//------------------------------
                '<TODO>�t�H�[�J�X���Z�b�g����i�����{�^���ɃZ�b�g�j
                strMsg.Append("Form1.btnSelect.focus();")
                dbData.Dispose()
                strRec = "�Ώۃf�[�^�Ȃ�"
                Return strRec
            Else

                '�ϐ��ɓo�^�l���i�[
                Dim intRow As Integer

                For intRow = 0 To dbData.Tables(0).Rows.Count - 1

                    ReDim Preserve sKURACD(intRow + 1)
                    ReDim Preserve sACBCD(intRow + 1)
                    ReDim Preserve sGROUPCD(intRow + 1)
                    ReDim Preserve sUSE_FLG(intRow + 1)
                    ReDim Preserve sINS_DATE(intRow + 1)
                    ReDim Preserve sUPD_DATE(intRow + 1)
                    ReDim Preserve sBIKO(intRow + 1)
                    ReDim Preserve sDEL(intRow + 1)


                    sKURACD(intRow + 1) = hdnKURACD.Value.Trim
                    sACBCD(intRow + 1) = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("HAN_CD"))
                    sGROUPCD(intRow + 1) = hdnGROUPCD.Value.Trim
                    sUSE_FLG(intRow + 1) = "1"
                    sINS_DATE(intRow + 1) = ""
                    sUPD_DATE(intRow + 1) = ""
                    sBIKO(intRow + 1) = ""
                    sDEL(intRow + 1) = "false"

                Next

                strRec = MSJIGJAW00C.mSetEx( _
                                    CInt(pstrKBN), _
                                    sKURACD, _
                                    sACBCD, _
                                    sGROUPCD, _
                                    sUSE_FLG, _
                                    sINS_DATE, _
                                    sUPD_DATE, _
                                    sBIKO, _
                                    sDEL)



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
                    Case "1"
                        strRecMsg = "���Ƀf�[�^�����݂��܂�"
                        strMsg.Append("alert('" & strRecMsg & "');")

                        '//------------------------------
                        strRec = strRecMsg
                    Case "2"
                        strRecMsg = "�Ώۃf�[�^�����݂��܂���"
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
                        strRecMsg = "�N���C�A���g�R�[�h�����݂��܂���"
                        strMsg.Append("alert('" & strRecMsg & "');")

                        '<TODO>�t�H�[�J�X���Z�b�g����i�o�^�E�C�����ł̃G���[�B�����{�^���ɃZ�b�g�j
                        strMsg.Append("Form1.btnSelect.focus();")

                        strRec = strRecMsg
                    Case "5"
                        strRecMsg = "JA�x���R�[�h�����݂��܂���"
                        strMsg.Append("alert('" & strRecMsg & "');")

                        '<TODO>�t�H�[�J�X���Z�b�g����i�o�^�E�C�����ł̃G���[�B�����{�^���ɃZ�b�g�j
                        strMsg.Append("Form1.btnSelect.focus();")

                        strRec = strRecMsg
                    Case Else
                        Dim ErrMsgC As New CErrMsg

                        strMsg.Append("alert('�V�X�e���G���[�F" & ErrMsgC.mGetArtMsg(strRec) & "');")

                        If pstrKBN = "1" Then
                            '//----------------------------------
                            '<TODO>�t�H�[�J�X���Z�b�g����i�o�^�����F���O�o�͂̃G���[�̈׃L�[�ɃZ�b�g�j
                        ElseIf pstrKBN = "2" Then
                            '//----------------------------------
                            '<TODO>�t�H�[�J�X���Z�b�g����i�C�������F���O�o�͂̃G���[�̈׃L�[�ȍ~�ɃZ�b�g�j
                            strMsg.Append("Form1.txtKURACD_1.focus();")
                        Else
                            '//----------------------------------
                            '<TODO>�t�H�[�J�X���Z�b�g����i���̑��@�F���O�o�͂̃G���[�̈׃L�[�ȍ~�ɃZ�b�g�j
                            strMsg.Append("Form1.txtKURACD_1.focus();")
                        End If
                End Select
                dbData.Dispose()
            End If

        Catch ex As Exception
            strRec = ex.ToString
            Dim ErrMsgC As New CErrMsg
            strMsg.Append("alert('�V�X�e���G���[�F" & ErrMsgC.mGetArtMsg(ex.ToString) & "');")

        Finally
            '-------------------------------------------------
            '//�`�o���O��������
            Dim LogC As New CLog
            Dim strRecLog As String
            strRecLog = LogC.mAPLog(Me.Session.SessionID, AuthC.pUSERNAME, AuthC.pIPADDRESS, hdnMyAspx.Value, pstrKBN, strRec, Request.Form)

            If strRecLog <> "OK" Then
                Dim errmsgc As New CErrMsg
                strMsg.Append("alert('�V�X�e���G���[�F" & errmsgc.mGetArtMsg(strRecLog) & "');")
            End If

        End Try
        

        Return strRec
    End Function

    '******************************************************************************
    '* ���̓L�[�ɂ��f�[�^�̌������s���܂��B
    '******************************************************************************
    Private Function fncDataSelect() As DataSet

        '//------------------------------------------
        '//<TODO>Select���̍쐬
        Dim SQLC As New MSJIGJAG00CCSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet

        strSQL.Append("SELECT  ")
        strSQL.Append("	    A.KURACD ")
        'strSQL.Append("	    ,B.CLI_NAME ")
        strSQL.Append("	    ,A.ACBCD ")
        'strSQL.Append("	    ,C.JAS_NAME ")
        strSQL.Append("	    ,A.GROUPCD ")
        strSQL.Append("	    ,A.USE_FLG ")
        strSQL.Append("	    ,A.INS_DATE ")
        strSQL.Append("	    ,A.UPD_DATE ")
        strSQL.Append("     ,A.BIKO ")
        strSQL.Append("FROM ")
        strSQL.Append("	    M07_AUTOTAIOUGROUP A ")
        'strSQL.Append("	    ,CLIMAS B ")
        'strSQL.Append("	    ,HN2MAS C ")
        strSQL.Append("WHERE 1=1")
        'strSQL.Append("AND   A.KURACD = B.CLI_CD(+) ")
        'strSQL.Append("AND   A.KURACD = C.CLI_CD(+) ")
        'strSQL.Append("AND   A.ACBCD = C.HAN_CD(+) ")
        '�N���C�A���g�R�[�h
        If hdnKURACD.Value.Trim.Length > 0 Then
            strSQL.Append("AND   A.KURACD =:KURACD ")
        End If
        'JA�x���R�[�h
        If hdnACBCD_F.Value.Trim.Length > 0 Then
            strSQL.Append("AND   A.ACBCD >=:ACBCD_F ")
        End If
        If hdnACBCD_T.Value.Trim.Length > 0 Then
            strSQL.Append("AND   A.ACBCD <=:ACBCD_T ")
        End If
        '�O���[�v�R�[�h
        If hdnGROUPCD.Value.Trim.Length > 0 Then
            strSQL.Append("AND   A.GROUPCD =:GROUPCD ")
        End If
        strSQL.Append("ORDER BY A.KURACD, A.ACBCD")


        '�N���C�A���g�R�[�h
        If hdnKURACD.Value.Trim.Length > 0 Then
            SqlParamC.fncSetParam("KURACD", True, hdnKURACD.Value.Trim)
        End If
        'JA�x���R�[�h�iFrom�j
        If hdnACBCD_F.Value.Trim.Length > 0 Then
            SqlParamC.fncSetParam("ACBCD_F", True, hdnACBCD_F.Value.Trim)
        End If
        'JA�x���R�[�h�iTo�j
        If hdnACBCD_T.Value.Trim.Length > 0 Then
            SqlParamC.fncSetParam("ACBCD_T", True, hdnACBCD_T.Value.Trim)
        End If
        '�O���[�v�R�[�h
        If hdnGROUPCD.Value.Trim.Length > 0 Then
            SqlParamC.fncSetParam("GROUPCD", True, hdnGROUPCD.Value.Trim)
        End If

        dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

        Return dbData
    End Function
    '******************************************************************************
    ' Excel�o��(�`�F�b�N��)
    '******************************************************************************
    Private Sub btnCSVout_ServerClick(ByVal sender As System.Object, _
                                    ByVal e As System.EventArgs) Handles btnCSVout.ServerClick
        Dim strRec As String
        Dim MSJIGJAG00C As New MSJIGJAG00MSJIGJAW00.MSJIGJAW00

        '//�@�F�؃N���X�̃C���X�^���X����
        AuthC = New CAuthenticate(Request, Response)

        Dim strRecMsg As String = ""

        strRec = MSJIGJAG00C.mCSV( _
                         Me.Session.SessionID, _
                         hdnKURACD.Value, _
                         hdnACBCD_F.Value, _
                         hdnACBCD_T.Value, _
                         hdnGROUPCD.Value _
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
            HttpHeaderC.mDownLoadCSV(Response, "�����Ή��O���[�v�}�X�^.csv")
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


    '**************************************************
    '* �R���{�{�b�N�X�̑I��
    '**************************************************
    Private Sub fncCombo_Select(ByVal obj As JPG.Common.Controls.CTLCombo, ByVal str As String)
        Dim list As New ListItem
        If str <> "" Then
            list = obj.Items.FindByValue(str)
            obj.SelectedIndex = obj.Items.IndexOf(list)
        End If
    End Sub

    '**************************************************
    '* �ꗗ�̃R���{�{�b�N�X�̓��͒l�擾
    '**************************************************
    Private Sub fncComboGet(ByVal i As Integer)
        Dim obj As JPG.Common.Controls.CTLCombo

        '�O���[�v�R�[�h
        obj = CType(FindControl("cboGROUPCD_" & CStr(i)), JPG.Common.Controls.CTLCombo)
        strCBO_GROUPCD(i) = Request.Form(obj.ID)
        If Request.Form("cboGROUPCD_" & i) <> "" Then
            strCBO_GROUPCD(i) = Convert.ToString(obj.Items.Item(CInt(Request.Form("cboGROUPCD_" & CStr(i)))))
        Else
            strCBO_GROUPCD(i) = ""
        End If
        '�g�p�t���O
        obj = CType(FindControl("cboUSE_FLG_" & CStr(i)), JPG.Common.Controls.CTLCombo)
        strCBO_USE_FLG(i) = Request.Form(obj.ID)

    End Sub

    '******************************************************************************
    '*�@�T�@�v�F�R���{�{�b�N�X�̑I��
    '*�@���@�l�F
    '******************************************************************************
    Private Sub fncComboSet(ByVal i As Integer)
        Dim obj As JPG.Common.Controls.CTLCombo
        Dim list As New ListItem

        If strCBO_GROUPCD(i) <> "" Then
            obj = CType(FindControl("cboGROUPCD_" & CStr(i)), JPG.Common.Controls.CTLCombo)
            list = obj.Items.FindByText(strCBO_GROUPCD(i))
            obj.SelectedIndex = obj.Items.IndexOf(list)
        End If

        If strCBO_USE_FLG(i) <> "" Then
            obj = CType(FindControl("cboUSE_FLG_" & CStr(i)), JPG.Common.Controls.CTLCombo)
            list = obj.Items.FindByValue(strCBO_USE_FLG(i))
            obj.SelectedIndex = obj.Items.IndexOf(list)
        End If

    End Sub
    '�O���[�v�R�[�h(KEY)
    Private Sub fncCombo_Create_GROUPCD_KEY()

        cboGROUPCD.Items.Clear()

        Dim dbData As DataSet
        dbData = fncGET_GROUPCD()

        If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
            cboGROUPCD.Items.Add(New ListItem("", ""))
        Else
            Dim intRow As Integer
            cboGROUPCD.Items.Add(New ListItem("", ""))
            For intRow = 0 To dbData.Tables(0).Rows.Count - 1
                cboGROUPCD.Items.Add(New ListItem(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("GROUPCD")), CStr(intRow + 1)))
            Next
        End If
    End Sub
    '�O���[�v�R�[�h
    Private Sub fncCombo_Create_GROUPCD()

        Dim objGROUPCD As JPG.Common.Controls.CTLCombo
        Dim dbData As DataSet

        dbData = fncGET_GROUPCD()

        '�f�[�^�擾����x�ɂ��邽�߁A�����Ń��[�v
        Dim i As Integer
        For i = 1 To 50
            objGROUPCD = CType(FindControl("cboGROUPCD_" & CStr(i)), JPG.Common.Controls.CTLCombo)
            objGROUPCD.Items.Clear()

            If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
                cboGROUPCD.Items.Add(New ListItem("", ""))
            Else
                Dim intRow As Integer
                objGROUPCD.Items.Add(New ListItem("", ""))
                For intRow = 0 To dbData.Tables(0).Rows.Count - 1
                    objGROUPCD.Items.Add(New ListItem(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("GROUPCD")), CStr(intRow + 1)))
                Next
            End If
        Next

    End Sub
    '�g�p�t���O
    Private Sub fncCombo_Create_USE_FLG(ByVal i As Integer)
        Dim objUSE_FLG As JPG.Common.Controls.CTLCombo
        objUSE_FLG = CType(FindControl("cboUSE_FLG_" & CStr(i)), JPG.Common.Controls.CTLCombo)
        objUSE_FLG.Items.Clear()
        objUSE_FLG.Items.Add(New ListItem("0�F�g�p�s��", "0"))
        objUSE_FLG.Items.Add(New ListItem("1�F�g�p��", "1"))
        objUSE_FLG.SelectedIndex = 1
    End Sub

    '******************************************************************************
    '*�O���[�v�R�[�h�̈ꗗ�擾
    '******************************************************************************
    Private Function fncGET_GROUPCD() As DataSet

        '//------------------------------------------
        '//<TODO>Select���̍쐬
        Dim SQLC As New MSJIGJAG00CCSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet

        'strSQL.Append("SELECT ")
        'strSQL.Append("		A.GROUPCD ")
        'strSQL.Append("FROM ")
        'strSQL.Append("		M08_AUTOTAIOU A ")
        'strSQL.Append("GROUP BY A.GROUPCD ")
        'strSQL.Append("ORDER BY A.GROUPCD ")
        strSQL.Append("SELECT ")
        strSQL.Append("		A.GROUPCD  ")
        strSQL.Append("FROM  ")
        strSQL.Append("		M08_AUTOTAIOU A  ")
        strSQL.Append("GROUP BY A.GROUPCD  ")
        strSQL.Append("UNION ")
        strSQL.Append("SELECT ")
        strSQL.Append("		B.GROUPCD ")
        strSQL.Append("FROM ")
        strSQL.Append("		M07_AUTOTAIOUGROUP B ")
        strSQL.Append("GROUP BY B.GROUPCD ")
        strSQL.Append("ORDER BY GROUPCD ")

        dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

        Return dbData
    End Function

    '******************************************************************************
    '*�w��͈͂̏d���`�F�b�N�@True�F�d���Ȃ��@False�F�d������NG
    '******************************************************************************
    Private Function fncchkCHOUFUKU() As Boolean

        Dim res As Boolean = False

        '//------------------------------------------
        '//<TODO>Select���̍쐬
        Dim SQLC As New MSJIGJAG00CCSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet

        strSQL.Append("SELECT ")
        strSQL.Append("		'X' ")
        strSQL.Append("FROM ")
        strSQL.Append("		M07_AUTOTAIOUGROUP A ")
        strSQL.Append("WHERE ")
        strSQL.Append("		A.KURACD = :KURACD ")
        If hdnACBCD_F.Value.Trim.Length > 0 Then
            strSQL.Append("AND	A.ACBCD >= :ACBCD_F ")
        End If
        If hdnACBCD_T.Value.Trim.Length > 0 Then
            strSQL.Append("AND	A.ACBCD <= :ACBCD_T ")
        End If
        strSQL.Append("ORDER BY A.KURACD, A.ACBCD ")


        SqlParamC.fncSetParam("KURACD", True, hdnKURACD.Value.Trim)

        If hdnACBCD_F.Value.Trim.Length > 0 Then
            SqlParamC.fncSetParam("ACBCD_F", True, hdnACBCD_F.Value.Trim)
        End If
        If hdnACBCD_T.Value.Trim.Length > 0 Then
            SqlParamC.fncSetParam("ACBCD_T", True, hdnACBCD_T.Value.Trim)
        End If

        dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

        If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
            res = True
        Else
            res = False
        End If

        Return res
    End Function

    '******************************************************************************
    '*�ꊇ�o�^�p����
    '******************************************************************************
    Private Function fncDataSelect_Ikkatu() As DataSet

        '//------------------------------------------
        '//<TODO>Select���̍쐬
        Dim SQLC As New MSJIGJAG00CCSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet

        strSQL.Append("SELECT ")
        strSQL.Append("		A.CLI_CD ")
        strSQL.Append("		,A.HAN_CD ")
        strSQL.Append("FROM ")
        strSQL.Append("		HN2MAS A ")
        strSQL.Append("WHERE ")
        strSQL.Append("		A.CLI_CD = :KURACD ")
        strSQL.Append("AND	NVL(A.DEL_FLG,'0') <> '1' ")
        If hdnACBCD_F.Value.Trim.Length > 0 Then
            strSQL.Append("AND	A.HAN_CD >= :ACBCD_F ")
        End If
        If hdnACBCD_T.Value.Trim.Length > 0 Then
            strSQL.Append("AND	A.HAN_CD <= :ACBCD_T ")
        End If
        strSQL.Append("AND	NOT EXISTS( ")
        strSQL.Append("			SELECT	'X' ")
        strSQL.Append("			FROM	HN2MAS B ")
        strSQL.Append("			WHERE	A.CLI_CD = B.CLI_CD ")
        strSQL.Append("			AND		A.HAN_CD = B.JA_CD ")
        strSQL.Append("			) ")
        strSQL.Append("ORDER BY A.CLI_CD, A.HAN_CD ")

        '//------------------------------------------
        '//<TODO>�p�����[�^�̐ݒ�
        SqlParamC.fncSetParam("KURACD", True, hdnKURACD.Value.Trim)

        If hdnACBCD_F.Value.Trim.Length > 0 Then
            SqlParamC.fncSetParam("ACBCD_F", True, hdnACBCD_F.Value.Trim)
        End If

        If hdnACBCD_T.Value.Trim.Length > 0 Then
            SqlParamC.fncSetParam("ACBCD_T", True, hdnACBCD_T.Value.Trim)
        End If


        dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

        Return dbData
    End Function
End Class
