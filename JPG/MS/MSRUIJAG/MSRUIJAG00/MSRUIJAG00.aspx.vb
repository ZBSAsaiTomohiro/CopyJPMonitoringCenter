'***********************************************
' �ݐϏ�񎩓�FAX&���[���}�X�^  ���C�����
'***********************************************
' �ύX����

Option Explicit On
Option Strict On

Imports Common
Imports Common.DB
Imports JPG.Common
Imports JPG.Common.log

Imports System.Text

Partial Class MSRUIJAG00
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

    '******************************************************************************
    ' Page_Load
    '******************************************************************************
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '2012/04/03 NEC ou Add
        '.NET�̎d�l�ύX�ɂ��AReadOnly������ASPX�ł���ƁA�T�[�o���Œl�̎Q�Ƃ��ł��Ȃ��Ȃ邽�߁AVB����Attribute�ł���
        If MyBase.IsPostBack = False Then
            txtKURACD.Attributes.Add("ReadOnly", "true")
            txtACBCD_F.Attributes.Add("ReadOnly", "true") '2014/03/10 T.Ono add �i���ݏ����ǉ�
            txtACBCD_T.Attributes.Add("ReadOnly", "true") '2014/03/10 T.Ono add �i���ݏ����ǉ�
            Dim objDefNO As System.Web.UI.WebControls.TextBox
            Dim objDefDEL As System.Web.UI.WebControls.CheckBox
            Dim objHASSEI As System.Web.UI.WebControls.DropDownList
            Dim objKAIPAGE As System.Web.UI.WebControls.DropDownList
            Dim objKIKAN As System.Web.UI.WebControls.DropDownList
            Dim objZEROSEND As System.Web.UI.WebControls.DropDownList    '2020/11/01 T.Ono add 2020�Ď����P
            Dim objSD_PRT As System.Web.UI.WebControls.DropDownList
            Dim objSENDSTOP As System.Web.UI.WebControls.DropDownList
            Dim objLSTSEND As System.Web.UI.WebControls.TextBox

            Dim i As Integer
            For i = 1 To 30
                objDefNO = CType(FindControl("txtNO_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                objDefDEL = CType(FindControl("chkDEL_" & CStr(i)), System.Web.UI.WebControls.CheckBox)
                objHASSEI = CType(FindControl("listHASSEI_" & CStr(i)), System.Web.UI.WebControls.DropDownList)
                objKAIPAGE = CType(FindControl("listKAIPAGE_" & CStr(i)), System.Web.UI.WebControls.DropDownList)
                objKIKAN = CType(FindControl("listKIKAN_" & CStr(i)), System.Web.UI.WebControls.DropDownList)
                objZEROSEND = CType(FindControl("listZEROSND_" & CStr(i)), System.Web.UI.WebControls.DropDownList)    '2020/11/01 T.Ono add 2020�Ď����P
                objSD_PRT = CType(FindControl("listSD_PRT_" & CStr(i)), System.Web.UI.WebControls.DropDownList)
                objSENDSTOP = CType(FindControl("listSNDSTOP_" & CStr(i)), System.Web.UI.WebControls.DropDownList)
                objLSTSEND = CType(FindControl("txtLSSEND_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                objDefNO.Attributes.Add("ReadOnly", "true")
                objLSTSEND.Attributes.Add("ReadOnly", "true")
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
             MyBase.MapPath("../../../MS/MSRUIJAG/MSRUIJAG00/") & "MSRUIJAG00.js"))
        '<�t�H�[�J�X�֘A�֐�>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncFo.js"))
        '<���̓`�F�b�N�֐�>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncChk.js"))
        '<���̓`�F�b�N�֐�>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncDate.js"))
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


        End If

        '<TODO>�����̉��ID��HIDDEN��hdnMyAspx�ɏ������ށi�V�X�e�����ʁj
        hdnMyAspx.Value = "MSRUIJAG00"
        '//-------------------------------------------------

    End Sub

    '******************************************************************************
    '* ���������������O�̉�ʏ�ԁiReadOnly��Disabled�j
    '********************************/*********************************************
    Private Sub fncIni_statebf()
        '//--------------------------------------------------------------------------
        '<TODO>�����O�̏�ԂɃR���g���[���̏�Ԃ�ݒ肷��

        btnKURACD.Disabled = False

    End Sub

    '******************************************************************************
    '* �������������ꂽ��̉�ʏ�ԁiReadOnly��Disabled�j
    '******************************************************************************
    Private Sub fncIni_stateaf()
        '//--------------------------------------------------------------------------
        '<TODO>������̏�ԂɃR���g���[���̏�Ԃ�ݒ肷��
        '

        txtKURACD.Attributes.Add("ReadOnly", "true")
        txtACBCD_F.Attributes.Add("ReadOnly", "true") '2014/03/10 T.Ono add �i���ݏ����ǉ�
        txtACBCD_T.Attributes.Add("ReadOnly", "true") '2014/03/10 T.Ono add �i���ݏ����ǉ�
        Dim objDefNO As System.Web.UI.WebControls.TextBox
        Dim objDefDEL As System.Web.UI.WebControls.CheckBox
        Dim objLSTSEND As System.Web.UI.WebControls.TextBox

        Dim i As Integer
        For i = 1 To 30
            objDefNO = CType(FindControl("txtNO_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objDefDEL = CType(FindControl("chkDEL_" & CStr(i)), System.Web.UI.WebControls.CheckBox)
            objLSTSEND = CType(FindControl("txtLSSEND_" & CStr(i)), System.Web.UI.WebControls.TextBox)

            objDefNO.Attributes.Add("ReadOnly", "true")
            objLSTSEND.Attributes.Add("ReadOnly", "true")
            objDefDEL.Checked = False

        Next
    End Sub

    '******************************************************************************
    '* �e�R���g���[���̐ݒ�l�̏�����
    '******************************************************************************
    Private Sub fncIni_format()
        '//--------------------------------------------------------------------------
        txtKURACD.Text = ""
        hdnKURACD.Value = ""
        txtACBCD_F.Text = ""   '2014/03/10 T.Ono mod �i���ݏ����ǉ�
        hdnACBCD_F.Value = ""  '2014/03/10 T.Ono mod �i���ݏ����ǉ�
        txtACBCD_T.Text = ""   '2014/03/10 T.Ono mod �i���ݏ����ǉ�
        hdnACBCD_T.Value = ""  '2014/03/10 T.Ono mod �i���ݏ����ǉ�


        '�L�[�ȊO�̒l������������
        Call fncIni_notkey()

    End Sub

    '******************************************************************************
    '* �L�[�ȊO�̒l������������
    '******************************************************************************
    Private Sub fncIni_notkey()
        Call fncIni_date()
        '//--------------------------------------------------------------------------
        '<TODO>�R���g���[���̒l������������

        hdnKURACD_MOTO.Value = ""

        Dim objID As System.Web.UI.HtmlControls.HtmlInputHidden
        Dim objDISP_NO As System.Web.UI.HtmlControls.HtmlInputHidden
        Dim objSEND As System.Web.UI.WebControls.TextBox
        Dim objKYOKYUCD As System.Web.UI.WebControls.TextBox
        Dim objACBCDFR As System.Web.UI.WebControls.TextBox
        Dim objACBCDTO As System.Web.UI.WebControls.TextBox
        Dim objFAX1 As System.Web.UI.WebControls.TextBox
        Dim objFAX2 As System.Web.UI.WebControls.TextBox
        Dim objMAIL1 As System.Web.UI.WebControls.TextBox
        Dim objMAIL2 As System.Web.UI.WebControls.TextBox
        Dim objNXSEND As System.Web.UI.WebControls.TextBox
        Dim objLSSEND As System.Web.UI.WebControls.TextBox
        Dim objSENDSTR As System.Web.UI.WebControls.TextBox
        Dim objSENDEND As System.Web.UI.WebControls.TextBox
        Dim objMAILPASS As System.Web.UI.WebControls.TextBox
        Dim objZIPFILE As System.Web.UI.WebControls.TextBox
        Dim objBIKOU As System.Web.UI.WebControls.TextBox

        Dim objEDT_DT As System.Web.UI.HtmlControls.HtmlInputHidden
        Dim objADD_DT As System.Web.UI.HtmlControls.HtmlInputHidden
        Dim objDEL As System.Web.UI.WebControls.CheckBox
        Dim i As Integer
        For i = 1 To 30
            objID = CType(FindControl("hdnID_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
            objDISP_NO = CType(FindControl("hdnDISP_NO_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKYOKYUCD = CType(FindControl("txtKYOKYU_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objEDT_DT = CType(FindControl("hdnEDT_DT_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
            objADD_DT = CType(FindControl("hdnADD_DT_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
            objSEND = CType(FindControl("txtSEND_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objACBCDFR = CType(FindControl("txtACBCDFR_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objACBCDTO = CType(FindControl("txtACBCDTO_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objFAX1 = CType(FindControl("txtFAX1_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objFAX2 = CType(FindControl("txtFAX2_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objMAIL1 = CType(FindControl("txtMAIL1_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objMAIL2 = CType(FindControl("txtMAIL2_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objNXSEND = CType(FindControl("txtNXSEND_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objLSSEND = CType(FindControl("txtLSSEND_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objSENDSTR = CType(FindControl("txtSENDSTR_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objSENDEND = CType(FindControl("txtSENDEND_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objMAILPASS = CType(FindControl("txtMAILPASS_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objZIPFILE = CType(FindControl("txtZIP_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objBIKOU = CType(FindControl("txtBIKOU_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objDEL = CType(FindControl("chkDEL_" & CStr(i)), System.Web.UI.WebControls.CheckBox)

            objID.Value = ""
            objDISP_NO.Value = CStr(i) '�@�B�I�ɔԍ���t����
            objKYOKYUCD.Text = ""
            objEDT_DT.Value = ""
            objADD_DT.Value = ""
            objKYOKYUCD.Text = ""
            objSEND.Text = ""
            objACBCDFR.Text = ""
            objACBCDTO.Text = ""
            objFAX1.Text = ""
            objFAX2.Text = ""
            objMAIL1.Text = ""
            objMAIL2.Text = ""
            objNXSEND.Text = ""
            objLSSEND.Text = ""
            objSENDSTR.Text = ""
            objSENDEND.Text = ""
            objMAILPASS.Text = ""
            objZIPFILE.Text = ""
            objBIKOU.Text = ""
            objDEL.Checked = False
        Next
        Call fncIni_List()
    End Sub
    '******************************************************************************
    '* ���t(�쐬���X�V��)������������
    '******************************************************************************
    Private Sub fncIni_List()
        Dim objlistHASSEI As System.Web.UI.WebControls.DropDownList
        Dim objlistKAIPAGE As System.Web.UI.WebControls.DropDownList
        Dim objlistKIKAN As System.Web.UI.WebControls.DropDownList
        Dim objlistZEROSND As System.Web.UI.WebControls.DropDownList
        Dim objlistSD_PRT As System.Web.UI.WebControls.DropDownList    '2020/11/01 T.Ono add 2020�Ď����P
        Dim objlistSNDSTOP As System.Web.UI.WebControls.DropDownList

        Dim i As Integer
        For i = 1 To 30
            objlistHASSEI = CType(FindControl("listHASSEI_" & CStr(i)), System.Web.UI.WebControls.DropDownList)
            objlistKAIPAGE = CType(FindControl("listKAIPAGE_" & CStr(i)), System.Web.UI.WebControls.DropDownList)
            objlistKIKAN = CType(FindControl("listKIKAN_" & CStr(i)), System.Web.UI.WebControls.DropDownList)
            objlistZEROSND = CType(FindControl("listZEROSND_" & CStr(i)), System.Web.UI.WebControls.DropDownList)
            objlistSD_PRT = CType(FindControl("listSD_PRT_" & CStr(i)), System.Web.UI.WebControls.DropDownList)    '2020/11/01 T.Ono add 2020�Ď����P
            objlistSNDSTOP = CType(FindControl("listSNDSTOP_" & CStr(i)), System.Web.UI.WebControls.DropDownList)
            objlistHASSEI.Items.Insert(0, New ListItem("1:�d�b", "1"))
            objlistHASSEI.Items.Insert(1, New ListItem("2:�x��", "2"))
            objlistHASSEI.Items.Insert(2, New ListItem("3:����", "3"))
            objlistHASSEI.DataBind()

            objlistKAIPAGE.Items.Insert(0, New ListItem("1:JA�P��", "1"))
            '2015/11/20 w.ganeko 2015���P�J�� ��8 start
            'objlistKAIPAGE.Items.Insert(1, New ListItem("2:��������", "2"))
            'objlistKAIPAGE.Items.Insert(2, New ListItem("3:���łȂ�", "3"))
            objlistKAIPAGE.Items.Insert(1, New ListItem("2:JA�x���P��", "2"))
            objlistKAIPAGE.Items.Insert(2, New ListItem("3:�̔����ƎҒP��", "3"))
            objlistKAIPAGE.Items.Insert(3, New ListItem("4:��������", "4"))
            objlistKAIPAGE.Items.Insert(4, New ListItem("5:���łȂ�", "5"))
            '2015/11/20 w.ganeko 2015���P�J�� ��8 end
            objlistKAIPAGE.DataBind()

            objlistKIKAN.Items.Insert(0, New ListItem("1:����", "1"))
            objlistKIKAN.Items.Insert(1, New ListItem("2:�T��", "2"))
            objlistKIKAN.Items.Insert(2, New ListItem("3:����", "3"))
            objlistKIKAN.DataBind()

            objlistZEROSND.Items.Insert(0, New ListItem("0:���Ȃ�", "0"))
            objlistZEROSND.Items.Insert(1, New ListItem("1:0�����M����", "1"))
            objlistZEROSND.DataBind()

            '2020/11/01 T.Ono add 2020�Ď����P
            objlistSD_PRT.Items.Insert(0, New ListItem("0:�\���Ȃ�", "0"))
            objlistSD_PRT.Items.Insert(1, New ListItem("1:�\������", "1"))
            objlistSD_PRT.DataBind()

            objlistSNDSTOP.Items.Insert(0, New ListItem("0:���M�\", "0"))
            objlistSNDSTOP.Items.Insert(1, New ListItem("1:�ꎞ��~", "1"))
            objlistSNDSTOP.DataBind()
        Next
    End Sub
    '******************************************************************************
    '* ���t(�쐬���X�V��)������������
    '******************************************************************************
    Private Sub fncIni_date()

        txtAYMD.Value = ""
        txtUYMD.Value = ""
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
            Dim col As Integer = 0
            col = Convert.ToInt32(hdnPopcrtl.Value)
            If hdnPopcrtl.Value = "0" Then
                If hdnBackUrl.Value = "EIGYOU" Then
                    '//�c�Ə��O���[�v�̏ꍇ�͊Ď��Z���^�[���R�t�����Ȃ��ׁA�S�N���C�A���g���o��
                    strRec = ""
                Else
                    '//
                    strRec = AuthC.pAUTHCENTERCD    '//�N���C�A���g�R�[�h�ꗗ �`�c�F�؂̎g�p�\�Ď��Z���^�[�R�[�h
                End If
            ElseIf col >= 1 And col <= 30 Then
                strRec = hdnKENCD.Value        '//���R�[�h�ꗗ
            ElseIf col >= 31 And col <= 90 Then
                strRec = hdnKURACD.Value        '//�N���C�A���g�R�[�h�ꗗ
            ElseIf hdnPopcrtl.Value = "101" Then '//JA�x���R�[�hFrom�@2014/03/10 T.Ono add �i���ݏ����ǉ�
                strRec = hdnKURACD.Value
            ElseIf hdnPopcrtl.Value = "102" Then '//JA�x���R�[�hTo�@2014/03/10 T.Ono add �i���ݏ����ǉ�
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
            Dim strRec As String = ""
            Dim col As Integer = 0
            col = Convert.ToInt32(hdnPopcrtl.Value)
            If hdnPopcrtl.Value = "0" Then          '//�N���C�A���g�R�[�h�ꗗ
                strRec = "�N���C�A���g�R�[�h�ꗗ"
            ElseIf col >= 1 And col <= 30 Then
                strRec = "�����Z���^�[�ꗗ"
            ElseIf col >= 31 And col <= 90 Then
                strRec = "JA�x���ꗗ"
            ElseIf hdnPopcrtl.Value = "101" Then     '2014/03/10 T.Ono add �i���ݏ����ǉ�
                strRec = "JA�x���ꗗ"
            ElseIf hdnPopcrtl.Value = "102" Then     '2014/03/10 T.Ono add �i���ݏ����ǉ�
                strRec = "JA�x���ꗗ"
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
            Dim strRec As String = ""
            Dim col As Integer = 0
            col = Convert.ToInt32(hdnPopcrtl.Value)
            If hdnPopcrtl.Value = "0" Then          '//�N���C�A���g�R�[�h�ꗗ
                strRec = "CLI"
            ElseIf col >= 1 And col <= 30 Then
                strRec = "KYO"
            ElseIf col >= 31 And col <= 90 Then
                strRec = "JAJASS"
            ElseIf hdnPopcrtl.Value = "101" Then     '2014/03/10 T.Ono add �i���ݏ����ǉ�
                strRec = "JASS"
            ElseIf hdnPopcrtl.Value = "102" Then     '2014/03/10 T.Ono add �i���ݏ����ǉ�
                strRec = "JASS"
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
            Dim strRec As String = ""
            Dim col As Integer = 0
            col = Convert.ToInt32(hdnPopcrtl.Value)
            If hdnPopcrtl.Value = "0" Then
                strRec = "hdnKURACD"
            ElseIf col >= 1 And col <= 30 Then
                strRec = "txtKYOKYU_" & Convert.ToString(col)
            ElseIf col >= 31 And col <= 60 Then
                col = col - 30
                strRec = "txtACBCDFR_" & Convert.ToString(col)
            ElseIf col >= 61 And col <= 90 Then
                col = col - 60
                strRec = "txtACBCDTO_" & Convert.ToString(col)
            ElseIf hdnPopcrtl.Value = "101" Then     '2014/03/10 T.Ono add �i���ݏ����ǉ�
                strRec = "hdnACBCD_F"
            ElseIf hdnPopcrtl.Value = "102" Then     '2014/03/10 T.Ono add �i���ݏ����ǉ�
                strRec = "hdnACBCD_T"
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
            Dim strRec As String = ""
            Dim col As Integer = 0                        '2014/03/10 T.Ono add
            col = Convert.ToInt32(hdnPopcrtl.Value)       '2014/03/10 T.Ono add
            If hdnPopcrtl.Value = "0" Then
                strRec = "txtKURACD"
                'ElseIf hdnPopcrtl.Value >= "1" And hdnPopcrtl.Value <= "90" Then   '2014/03/10 T.Ono mod
            ElseIf col >= 1 And col <= 90 Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "101" Then     '2014/03/10 T.Ono add �i���ݏ����ǉ�
                strRec = "txtACBCD_F"
            ElseIf hdnPopcrtl.Value = "102" Then     '2014/03/10 T.Ono add �i���ݏ����ǉ�
                strRec = "txtACBCD_T"
            End If
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�R�[�h��Ԃ��I�u�W�F�N�g�̖��O�l��n���v���p�e�B
    '*�@���@�l�F�f�[�^�I����A�R�[�h��Ԃ��I�u�W�F�N�g�����w�肷��
    '******************************************************************************
    Public ReadOnly Property pBackCode2() As String
        Get
            Dim strRec As String = ""
            If hdnPopcrtl.Value = "0" Then
                strRec = "hdnKENCD"
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
    Public ReadOnly Property pBackName2() As String
        Get
            Dim strRec As String = ""
            If hdnPopcrtl.Value = "0" Then
                strRec = ""
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
            Dim strRec As String = ""
            Dim col As Integer = 0
            col = Convert.ToInt32(hdnPopcrtl.Value)
            If hdnPopcrtl.Value = "0" Then
                strRec = "btnKURACD"
            ElseIf col >= 1 And col <= 30 Then
                strRec = "btnKYOKYU_" & Convert.ToString(col)
            ElseIf col >= 31 And col <= 60 Then
                col = col - 30
                strRec = "btnACBCDFR_" & Convert.ToString(col)
            ElseIf col >= 61 And col <= 90 Then
                col = col - 60
                strRec = "btnACBCDTO_" & Convert.ToString(col)
            ElseIf hdnPopcrtl.Value = "101" Then    '2014/03/10 T.Ono add �i���ݏ����ǉ�
                strRec = "btnACBCD_F"
            ElseIf hdnPopcrtl.Value = "102" Then    '2014/03/10 T.Ono add �i���ݏ����ǉ�
                strRec = "btnACBCD_T"
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
            Dim strRec As String
            If hdnPopcrtl.Value = "101" Then
                strRec = "fncSetTo"
            ElseIf hdnPopcrtl.Value = "102" Then
                strRec = "fncSetTo"
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
            If hdnPopcrtl.Value = "0" Then
                strRec = "txtACBCD_F"
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
                strRec = "hdnACBCD_F"
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
                strRec = "txtACBCD_T"
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
                strRec = "hdnACBCD_T"
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

            dbData = fncDataSelect(0)
            'If ds.Tables(0).Rows.Count = 0 Then
            If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
                '�f�[�^�����݂��Ȃ��ׁA�����̓G���[
                '���b�Z�[�W���o�͌�A�����O��Ԃɂ���B

                strMsg.Append("alert('�f�[�^�����݂��܂���');")
                strMsg.Append("Form1.btnSelect.focus();")

                Call fncIni_statebf()
                '//--------------------------------------------------------------------------
            Else
                '�f�[�^�����݂���ׁA�V�K�o�^�͕s��
                '�f�[�^���o�͌�A�������Ԃɂ���B

                '------------------------------------
                '<TODO>�f�[�^���o�͂���
                If dbData.Tables(0).Rows.Count > 30 Then
                    strMsg.Append("alert('�ő�o�͌����𒴂��܂����B�������w�肵�čēx�������Ă�������');")
                End If

                '���R�[�h
                hdnKURACD.Value = Convert.ToString(dbData.Tables(0).Rows(0).Item("KURACD"))
                hdnKURACD_MOTO.Value = Convert.ToString(dbData.Tables(0).Rows(0).Item("KURACD"))
                '����
                txtKURACD.Text = Convert.ToString(dbData.Tables(0).Rows(0).Item("KURACD")) & " : " & Convert.ToString(dbData.Tables(0).Rows(0).Item("CLI_NAME"))
                Dim sMinAddDate As String
                Dim sMaxEdtDate As String
                sMinAddDate = DateFncC.mGet(Convert.ToString(dbData.Tables(0).Rows(0).Item("INS_DATE")))
                sMaxEdtDate = DateFncC.mGet(Convert.ToString(dbData.Tables(0).Rows(0).Item("UPD_DATE")))

                Dim objID As System.Web.UI.HtmlControls.HtmlInputHidden
                Dim objDISP_NO As System.Web.UI.HtmlControls.HtmlInputHidden
                Dim objSEND As System.Web.UI.WebControls.TextBox
                Dim objKYOKYUCD As System.Web.UI.WebControls.TextBox
                Dim objACBCDFR As System.Web.UI.WebControls.TextBox
                Dim objACBCDTO As System.Web.UI.WebControls.TextBox
                Dim objFAX1 As System.Web.UI.WebControls.TextBox
                Dim objFAX2 As System.Web.UI.WebControls.TextBox
                Dim objMAIL1 As System.Web.UI.WebControls.TextBox
                Dim objMAIL2 As System.Web.UI.WebControls.TextBox
                Dim objNXSEND As System.Web.UI.WebControls.TextBox
                Dim objLSSEND As System.Web.UI.WebControls.TextBox
                Dim objSENDSTR As System.Web.UI.WebControls.TextBox
                Dim objSENDEND As System.Web.UI.WebControls.TextBox
                Dim objMAILPASS As System.Web.UI.WebControls.TextBox
                Dim objZIPFILE As System.Web.UI.WebControls.TextBox
                Dim objBIKOU As System.Web.UI.WebControls.TextBox
                Dim objlistHASSEI As System.Web.UI.WebControls.DropDownList
                Dim objlistKAIPAGE As System.Web.UI.WebControls.DropDownList
                Dim objlistKIKAN As System.Web.UI.WebControls.DropDownList
                Dim objlistZEROSND As System.Web.UI.WebControls.DropDownList
                Dim objlistSD_PRT As System.Web.UI.WebControls.DropDownList    '2020/11/01 T.Ono add 2020�Ď����P
                Dim objlistSNDSTOP As System.Web.UI.WebControls.DropDownList
                Dim objEDT_DT As System.Web.UI.HtmlControls.HtmlInputHidden
                Dim objADD_DT As System.Web.UI.HtmlControls.HtmlInputHidden

                Dim i As Integer
                Dim intRow As Integer
                Dim sDispNo As String

                For intRow = 0 To dbData.Tables(0).Rows.Count - 1

                    If intRow >= 30 Then Exit For '30���ȏ�͏�������

                    '----------------------------
                    ' �ŏ��̓o�^���A�Ō�̍X�V��������ʍ��ڂɃZ�b�g
                    '----------------------------
                    '�o�^�����󂩁A�ȑO�̏ꍇ�A�Z�b�g
                    If sMinAddDate = "" _
                        Or DateFncC.mGet(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("INS_DATE"))) < sMinAddDate Then
                        sMinAddDate = DateFncC.mGet(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("INS_DATE")))
                    End If
                    '�X�V�����󂩁A����Ɍ�̏ꍇ�A�Z�b�g
                    If DateFncC.mGet(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("UPD_DATE"))) <> "" _
                        And DateFncC.mGet(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("UPD_DATE"))) >= sMaxEdtDate Then
                        sMaxEdtDate = DateFncC.mGet(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("UPD_DATE")))

                        '�������󂩁A����Ɍ�̎��Ԃ̏ꍇ�A�Z�b�g
                        'If sMaxTime = "" _
                        '    Or Convert.ToString(dbData.Tables(0).Rows(intRow).Item("TIME")) >= sMaxTime Then
                        'sMaxTime = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("TIME"))
                        'End If
                    End If

                    '----------------------------
                    ' ���׏�����ʍ��ڂɃZ�b�g
                    '----------------------------
                    i = intRow + 1

                    objID = CType(FindControl("hdnID_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
                    objDISP_NO = CType(FindControl("hdnDISP_NO_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
                    objKYOKYUCD = CType(FindControl("txtKYOKYU_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                    objEDT_DT = CType(FindControl("hdnEDT_DT_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
                    objADD_DT = CType(FindControl("hdnADD_DT_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
                    objSEND = CType(FindControl("txtSEND_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                    objACBCDFR = CType(FindControl("txtACBCDFR_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                    objACBCDTO = CType(FindControl("txtACBCDTO_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                    objFAX1 = CType(FindControl("txtFAX1_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                    objFAX2 = CType(FindControl("txtFAX2_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                    objMAIL1 = CType(FindControl("txtMAIL1_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                    objMAIL2 = CType(FindControl("txtMAIL2_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                    objNXSEND = CType(FindControl("txtNXSEND_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                    objLSSEND = CType(FindControl("txtLSSEND_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                    objSENDSTR = CType(FindControl("txtSENDSTR_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                    objSENDEND = CType(FindControl("txtSENDEND_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                    objMAILPASS = CType(FindControl("txtMAILPASS_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                    objZIPFILE = CType(FindControl("txtZIP_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                    objBIKOU = CType(FindControl("txtBIKOU_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                    objlistHASSEI = CType(FindControl("listHASSEI_" & CStr(i)), System.Web.UI.WebControls.DropDownList)
                    objlistKAIPAGE = CType(FindControl("listKAIPAGE_" & CStr(i)), System.Web.UI.WebControls.DropDownList)
                    objlistKIKAN = CType(FindControl("listKIKAN_" & CStr(i)), System.Web.UI.WebControls.DropDownList)
                    objlistZEROSND = CType(FindControl("listZEROSND_" & CStr(i)), System.Web.UI.WebControls.DropDownList)
                    objlistSD_PRT = CType(FindControl("listSD_PRT_" & CStr(i)), System.Web.UI.WebControls.DropDownList)    '2020/11/01 T.Ono add 2020�Ď����P
                    objlistSNDSTOP = CType(FindControl("listSNDSTOP_" & CStr(i)), System.Web.UI.WebControls.DropDownList)
                    objID.Value = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("ID"))
                    objDISP_NO.Value = CStr(i)
                    objADD_DT.Value = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("INS_DATE"))
                    objEDT_DT.Value = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("UPD_DATE"))
                    objSEND.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("SEQ"))
                    objKYOKYUCD.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("HAISO_CD"))
                    objACBCDFR.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("ACBCD_FR"))
                    objACBCDTO.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("ACBCD_TO"))
                    objFAX1.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("FAX1"))
                    objFAX2.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("FAX2"))
                    objMAIL1.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("MAIL1"))
                    objMAIL2.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("MAIL2"))
                    objNXSEND.Text = fncDateSet(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("NEXTSENDDATE")))
                    objLSSEND.Text = fncDateSet(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("LASTSENDDATE")))
                    objSENDSTR.Text = fncDateSet(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("SENDSTDATE")))
                    objSENDEND.Text = fncDateSet(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("SENDEDDATE")))
                    objMAILPASS.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("MAIL_PASSWORD"))
                    objZIPFILE.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("ZIP_FILE_NAME"))
                    objBIKOU.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("BIKO"))
                    Dim list As New ListItem
                    'objlistHASSEI.SelectedValue = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("HATKBN"))
                    list = objlistHASSEI.Items.FindByValue(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("HATKBN")))
                    objlistHASSEI.SelectedIndex = objlistHASSEI.Items.IndexOf(list)

                    'objlistKAIPAGE.SelectedValue = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("PAGEKBN"))
                    list = objlistKAIPAGE.Items.FindByValue(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("PAGEKBN")))
                    objlistKAIPAGE.SelectedIndex = objlistKAIPAGE.Items.IndexOf(list)

                    'objlistKIKAN.SelectedValue = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("PERIODKBN"))
                    list = objlistKIKAN.Items.FindByValue(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("PERIODKBN")))
                    objlistKIKAN.SelectedIndex = objlistKIKAN.Items.IndexOf(list)

                    'objlistZEROSND.SelectedValue = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("ZEROSENDKBN"))
                    list = objlistZEROSND.Items.FindByValue(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("ZEROSENDKBN")))
                    objlistZEROSND.SelectedIndex = objlistZEROSND.Items.IndexOf(list)

                    '2020/11/01 T.Ono add 2020�Ď����P
                    list = objlistSD_PRT.Items.FindByValue(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("SD_PRT")))
                    objlistSD_PRT.SelectedIndex = objlistSD_PRT.Items.IndexOf(list)

                    'objlistSNDSTOP.SelectedValue = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("SENDSTOPKBN"))
                    list = objlistSNDSTOP.Items.FindByValue(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("SENDSTOPKBN")))
                    objlistSNDSTOP.SelectedIndex = objlistSNDSTOP.Items.IndexOf(list)
                Next ' intRow


                txtAYMD.Value = sMinAddDate
                txtUYMD.Value = sMaxEdtDate

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

        Dim strKBN As String
        strKBN = "3"        '//�i�`�x���S���҂Ƀ`�F�b�N

        Dim MSRUIJAW00C As New MSRUIJAG00MSRUIJAW00.MSRUIJAW00

        Dim strKURACD As String
        strKURACD = hdnKURACD.Value

        '�l��z��ɃZ�b�g
        Dim objID As System.Web.UI.HtmlControls.HtmlInputHidden
        Dim objDEL As System.Web.UI.WebControls.CheckBox
        Dim objDISP_NO As System.Web.UI.HtmlControls.HtmlInputHidden
        Dim objKYOKYUCD As System.Web.UI.WebControls.TextBox
        Dim objEDT_DT As System.Web.UI.HtmlControls.HtmlInputHidden
        Dim objADD_DT As System.Web.UI.HtmlControls.HtmlInputHidden
        Dim objSEND As System.Web.UI.WebControls.TextBox
        Dim objACBCDFR As System.Web.UI.WebControls.TextBox
        Dim objACBCDTO As System.Web.UI.WebControls.TextBox
        Dim objFAX1 As System.Web.UI.WebControls.TextBox
        Dim objFAX2 As System.Web.UI.WebControls.TextBox
        Dim objMAIL1 As System.Web.UI.WebControls.TextBox
        Dim objMAIL2 As System.Web.UI.WebControls.TextBox
        Dim objNXSEND As System.Web.UI.WebControls.TextBox
        Dim objLSSEND As System.Web.UI.WebControls.TextBox
        Dim objSENDSTR As System.Web.UI.WebControls.TextBox
        Dim objSENDEND As System.Web.UI.WebControls.TextBox
        Dim objMAILPASS As System.Web.UI.WebControls.TextBox
        Dim objZIPFILE As System.Web.UI.WebControls.TextBox
        Dim objBIKOU As System.Web.UI.WebControls.TextBox
        Dim objlistHASSEI As System.Web.UI.WebControls.DropDownList
        Dim objlistKAIPAGE As System.Web.UI.WebControls.DropDownList
        Dim objlistKIKAN As System.Web.UI.WebControls.DropDownList
        Dim objlistZEROSND As System.Web.UI.WebControls.DropDownList
        Dim objlistSD_PRT As System.Web.UI.WebControls.DropDownList    '2020/11/01 T.Ono add 2020�Ď����P
        Dim objlistSNDSTOP As System.Web.UI.WebControls.DropDownList
        Dim sID(30) As String
        Dim sDEL(30) As String
        Dim sDISP_NO(30) As String
        Dim sKYOKYUCD(30) As String
        Dim sEDT_DT(30) As String
        Dim sADD_DT(30) As String
        Dim sSEND(30) As String
        Dim sACBCDFR(30) As String
        Dim sACBCDTO(30) As String
        Dim sFAX1(30) As String
        Dim sFAX2(30) As String
        Dim sMAIL1(30) As String
        Dim sMAIL2(30) As String
        Dim sNXSEND(30) As String
        Dim sLSSEND(30) As String
        Dim sSENDSTR(30) As String
        Dim sSENDEND(30) As String
        Dim sMAILPASS(30) As String
        Dim sZIPFILE(30) As String
        Dim sBIKOU(30) As String
        Dim slistHASSEI(30) As String
        Dim slistKAIPAGE(30) As String
        Dim slistKIKAN(30) As String
        Dim slistZEROSND(30) As String
        Dim slistSD_PRT(30) As String    '2020/11/01 T.Ono add 2020�Ď����P
        Dim slistSNDSTOP(30) As String
        Dim i As Integer
        For i = 1 To 30
            objID = CType(FindControl("hdnID_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
            objDEL = CType(FindControl("chkDEL_" & CStr(i)), System.Web.UI.WebControls.CheckBox)
            objDISP_NO = CType(FindControl("hdnDISP_NO_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKYOKYUCD = CType(FindControl("txtKYOKYU_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objEDT_DT = CType(FindControl("hdnEDT_DT_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
            objADD_DT = CType(FindControl("hdnADD_DT_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
            objSEND = CType(FindControl("txtSEND_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objACBCDFR = CType(FindControl("txtACBCDFR_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objACBCDTO = CType(FindControl("txtACBCDTO_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objFAX1 = CType(FindControl("txtFAX1_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objFAX2 = CType(FindControl("txtFAX2_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objMAIL1 = CType(FindControl("txtMAIL1_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objMAIL2 = CType(FindControl("txtMAIL2_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objNXSEND = CType(FindControl("txtNXSEND_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objLSSEND = CType(FindControl("txtLSSEND_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objSENDSTR = CType(FindControl("txtSENDSTR_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objSENDEND = CType(FindControl("txtSENDEND_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objMAILPASS = CType(FindControl("txtMAILPASS_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objZIPFILE = CType(FindControl("txtZIP_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objBIKOU = CType(FindControl("txtBIKOU_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objlistHASSEI = CType(FindControl("listHASSEI_" & CStr(i)), System.Web.UI.WebControls.DropDownList)
            objlistKAIPAGE = CType(FindControl("listKAIPAGE_" & CStr(i)), System.Web.UI.WebControls.DropDownList)
            objlistKIKAN = CType(FindControl("listKIKAN_" & CStr(i)), System.Web.UI.WebControls.DropDownList)
            objlistZEROSND = CType(FindControl("listZEROSND_" & CStr(i)), System.Web.UI.WebControls.DropDownList)
            objlistSD_PRT = CType(FindControl("listSD_PRT_" & CStr(i)), System.Web.UI.WebControls.DropDownList)    '2020/11/01 T.Ono add 2020�Ď����P
            objlistSNDSTOP = CType(FindControl("listSNDSTOP_" & CStr(i)), System.Web.UI.WebControls.DropDownList)

            sID(i) = objID.Value
            If (objDEL.Checked) Then
                sDEL(i) = "true"
            Else
                sDEL(i) = "false"
            End If
            sDISP_NO(i) = objDISP_NO.Value
            sEDT_DT(i) = objEDT_DT.Value
            sADD_DT(i) = objADD_DT.Value
            sSEND(i) = objSEND.Text
            sKYOKYUCD(i) = objKYOKYUCD.Text
            sACBCDFR(i) = objACBCDFR.Text
            sACBCDTO(i) = objACBCDTO.Text
            sFAX1(i) = objFAX1.Text
            sFAX2(i) = objFAX2.Text
            sMAIL1(i) = objMAIL1.Text
            sMAIL2(i) = objMAIL2.Text
            sNXSEND(i) = fncDateGet(objNXSEND.Text)
            sLSSEND(i) = fncDateGet(objLSSEND.Text)
            sSENDSTR(i) = fncDateGet(objSENDSTR.Text)
            sSENDEND(i) = fncDateGet(objSENDEND.Text)
            sMAILPASS(i) = objMAILPASS.Text
            sZIPFILE(i) = objZIPFILE.Text
            sBIKOU(i) = objBIKOU.Text
            slistHASSEI(i) = Request.Form("listHASSEI_" & CStr(i))
            slistKAIPAGE(i) = Request.Form("listKAIPAGE_" & CStr(i))
            slistKIKAN(i) = Request.Form("listKIKAN_" & CStr(i))
            slistZEROSND(i) = Request.Form("listZEROSND_" & CStr(i))
            slistSD_PRT(i) = Request.Form("listSD_PRT_" & CStr(i))    '2020/11/01 T.Ono add  2020�Ď����P
            slistSNDSTOP(i) = Request.Form("listSNDSTOP_" & CStr(i))

        Next
        '2020/11/01 T.Ono mod 2020�Ď����P slistSD_PRT�ǉ�
        strRec = MSRUIJAW00C.mSetEx(
                    CInt(pstrKBN),
                      strKURACD,
                      sID,
                      sSEND,
                      sKYOKYUCD,
                      sACBCDFR,
                      sACBCDTO,
                      sFAX1,
                      sFAX2,
                      sMAIL1,
                      sMAIL2,
                      sNXSEND,
                      sLSSEND,
                      sSENDSTR,
                      sSENDEND,
                      sMAILPASS,
                      sZIPFILE,
                      sBIKOU,
                      slistHASSEI,
                      slistKAIPAGE,
                      slistKIKAN,
                      slistZEROSND,
                      slistSD_PRT,
                      slistSNDSTOP,
                      sDEL,
                      DateFncC.mHenkanGet(txtAYMD.Value),
                      DateFncC.mHenkanGet(txtUYMD.Value),
                      sADD_DT,
                      sEDT_DT)

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
                If pstrKBN = "1" Or pstrKBN = "2" Then
                    strRec = fncbtnKensaku_ClickEvent("2")
                Else
                    strRec = fncbtnKensaku_ClickEvent("2")
                End If
                strMsg.Append("alert('����ɏI�����܂���');")
                '//------------------------------
                strMsg.Append("Form1.btnSelect.focus();")

            Case "0"
                strRecMsg = "���̃��[�U�[�ɂ���ăf�[�^���X�V����Ă��܂��B�ēx�������Ă�������"
                strMsg.Append("alert('" & strRecMsg & "');")
                Call fncIni_List()

                '//------------------------------
                '<TODO>�t�H�[�J�X���Z�b�g����i�C�����ł̃G���[�B�����{�^���ɃZ�b�g�j
                strMsg.Append("Form1.btnSelect.focus();")
                strRec = strRecMsg
            Case "1"
                strRecMsg = "���Ƀf�[�^�����݂��܂�"
                strMsg.Append("alert('" & strRecMsg & "');")
                Call fncIni_List()

                '//------------------------------
                strRec = strRecMsg
            Case "2"
                strRecMsg = "�Ώۃf�[�^�����݂��܂���"
                strMsg.Append("alert('" & strRecMsg & "');")
                Call fncIni_List()

                '//------------------------------
                '<TODO>�t�H�[�J�X���Z�b�g����i�C�����ł̃G���[�B�����{�^���ɃZ�b�g�j
                strMsg.Append("Form1.btnSelect.focus();")
                strRec = strRecMsg
            Case "3"
                strRecMsg = "�r�����䏈���ŃG���[���������܂����B�ēx���s���Ă�������"
                strMsg.Append("alert('" & strRecMsg & "');")
                Call fncIni_List()

                '<TODO>�t�H�[�J�X���Z�b�g����i�o�^�E�C���E�폜���ł̃G���[�B�I���{�^���ɃZ�b�g�j
                strMsg.Append("Form1.btnExit.focus();")
                strRec = strRecMsg
            Case "4"
                strRecMsg = "���R�[�h�����݂��܂���"
                strMsg.Append("alert('" & strRecMsg & "');")
                Call fncIni_List()

                '<TODO>�t�H�[�J�X���Z�b�g����i�o�^�E�C�����ł̃G���[�B�N���C�A���g�R�[�h�����⏕�{�^���ɃZ�b�g�j
                strMsg.Append("Form1.btnSelect.focus();")

                strRec = strRecMsg
            Case "5"
                strRecMsg = "���M�������ɓo�^����Ă��܂��B"
                strMsg.Append("alert('" & strRecMsg & "');")
                Call fncIni_List()

                '<TODO>�t�H�[�J�X���Z�b�g����i�o�^�E�C�����ł̃G���[�B���M���ɃZ�b�g�j
                strMsg.Append("Form1.txtSEND_1.focus();")

                strRec = strRecMsg
            Case "8"        
                strRecMsg = "�����Z���^�[�R�[�h���d�����Ă��܂�"
                strMsg.Append("alert('" & strRecMsg & "');")
                Call fncIni_List()

                '<TODO>�t�H�[�J�X���Z�b�g����i�o�^�E�C�����ł̃G���[�B�R�[�h�����⏕�{�^���ɃZ�b�g�j
                strMsg.Append("Form1.txtKYOKYU_1.focus();")

                strRec = strRecMsg

            Case Else
                Dim ErrMsgC As New CErrMsg

                strMsg.Append("alert('�V�X�e���G���[�F" & ErrMsgC.mGetArtMsg(strRec) & "');")
                Call fncIni_List()

                If pstrKBN = "1" Then
                    '//----------------------------------
                    '<TODO>�t�H�[�J�X���Z�b�g����i�o�^�����F���O�o�͂̃G���[�̈׃L�[�ɃZ�b�g�j
                ElseIf pstrKBN = "2" Then
                    '//----------------------------------
                    '<TODO>�t�H�[�J�X���Z�b�g����i�C�������F���O�o�͂̃G���[�̈׃L�[�ȍ~�ɃZ�b�g�j
                    strMsg.Append("Form1.txtKYOKYU_1.focus();")
                Else
                    '//----------------------------------
                    '<TODO>�t�H�[�J�X���Z�b�g����i���̑��@�F���O�o�͂̃G���[�̈׃L�[�ȍ~�ɃZ�b�g�j
                    strMsg.Append("Form1.txtKYOKYU_1.focus();")
                End If
        End Select
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
    '* ���̓L�[�ɂ��f�[�^�̌������s���܂��B
    '* pintKbn�@0:�����{�^���������f�[�^�o��
    '*        �@1:�V�K�{�^���������f�[�^�J�E���g�o��
    '******************************************************************************
    Private Function fncDataSelect(ByVal pintkbn As Integer) As DataSet

        'intKbn     0:�����{�^������
        'intKbn     1:�V�K�{�^������

        '//------------------------------------------
        '//<TODO>Select���̍쐬
        Dim SQLC As New MSRUIJAG00CCSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet
        'Dim cdb As New CDB
        'Dim dbData As New DataSet
        'Dim strSQL As New StringBuilder("")
        'cdb.mOpen()

        strSQL.Append("SELECT ")
        If pintkbn = 0 Then
            '�����Ȃ̂őS�Ă̍��ڂ��擾���܂�
            strSQL.Append("A.KURACD, ")
            strSQL.Append("CL.CLI_NAME, ")
            strSQL.Append("A.ID, ")
            strSQL.Append("A.SEQ, ")
            strSQL.Append("A.HAISO_CD, ")
            strSQL.Append("A.ACBCD_FR, ")
            strSQL.Append("A.ACBCD_TO, ")
            strSQL.Append("A.HATKBN, ")
            strSQL.Append("A.PAGEKBN, ")
            strSQL.Append("A.PERIODKBN, ")
            strSQL.Append("A.FAX1, ")
            strSQL.Append("A.FAX2, ")
            strSQL.Append("A.MAIL1, ")
            strSQL.Append("A.MAIL2, ")
            strSQL.Append("A.ZEROSENDKBN, ")
            strSQL.Append("A.SD_PRT, ")             '2020/11/01 T.Ono add 2020�Ď����P
            strSQL.Append("A.JOTAI, ")
            strSQL.Append("A.LASTSENDDATE, ")
            strSQL.Append("A.NEXTSENDDATE, ")
            strSQL.Append("A.SENDSTOPKBN, ")
            strSQL.Append("A.SENDSTDATE, ")
            strSQL.Append("A.SENDEDDATE, ")
            strSQL.Append("A.BIKO, ")
            strSQL.Append("A.DEL_FLG, ")
            strSQL.Append("A.MAIL_PASSWORD, ")
            strSQL.Append("A.ZIP_FILE_NAME, ")
            strSQL.Append("A.INS_DATE, ")
            strSQL.Append("A.UPD_DATE ")
        Else
            '�V�K�Ȃ̂őΏۃf�[�^�̃J�E���g���擾���܂�
            strSQL.Append("COUNT(*) AS CNT ")
        End If
        strSQL.Append("FROM B10_BTRUIJAE  A, ")
        strSQL.Append("     CLIMAS CL ")
        strSQL.Append("WHERE A.KURACD   = :KURACD ")
        strSQL.Append("AND A.DEL_FLG  = '0' ")
        strSQL.Append("AND A.KURACD   = CL.CLI_CD(+) ")
        '2014/03/10 T.Ono add �i���ݏ����ǉ�
        If hdnACBCD_F.Value.Trim.Length > 0 AndAlso hdnACBCD_T.Value.Trim.Length > 0 Then
            'JA�x��From�`To�w��
            strSQL.Append("AND ((A.ACBCD_FR BETWEEN :ACBCD_F AND :ACBCD_T ")
            strSQL.Append("     OR A.ACBCD_TO BETWEEN :ACBCD_F AND :ACBCD_T) ")
            strSQL.Append("     OR (A.ACBCD_FR < :ACBCD_F AND A.ACBCD_TO > :ACBCD_T)) ")
        ElseIf hdnACBCD_F.Value.Trim.Length > 0 Then
            'JA�x��From�w��
            strSQL.Append("AND A.ACBCD_TO >= :ACBCD_F ")
        ElseIf hdnACBCD_T.Value.Trim.Length > 0 Then
            'JA�x��To�w��
            strSQL.Append("AND A.ACBCD_FR <= :ACBCD_T ")
        End If

        If pintkbn = 0 Then
            '2014/03/10 T.Ono mod 
            'strSQL.Append(" ORDER BY A.SEQ ")
            strSQL.Append(" ORDER BY A.HAISO_CD, A.ACBCD_FR, A.ACBCD_TO")
        End If
        If hdnKURACD.Value.Trim.Length > 0 Then
            SqlParamC.fncSetParam("KURACD", True, hdnKURACD.Value.Trim)
        End If
        '2014/03/10 T.Ono add �i���ݏ����ǉ�
        If hdnACBCD_F.Value.Trim.Length > 0 Then
            SqlParamC.fncSetParam("ACBCD_F", True, hdnACBCD_F.Value.Trim)
        End If
        If hdnACBCD_T.Value.Trim.Length > 0 Then
            SqlParamC.fncSetParam("ACBCD_T", True, hdnACBCD_T.Value.Trim)
        End If

        dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)
        'cdb.pSQL = strSQL.ToString
        'If hdnKURACD.Value.Trim.Length > 0 Then
        '    cdb.pSQLParamStr("KURACD") = hdnKURACD.Value.Trim
        'End If
        ''2014/03/10 T.Ono add �i���ݏ����ǉ�
        'If hdnACBCD_F.Value.Trim.Length > 0 Then
        '    cdb.pSQLParamStr("ACBCD_F") = hdnACBCD_F.Value.Trim
        'End If
        'If hdnACBCD_T.Value.Trim.Length > 0 Then
        '    cdb.pSQLParamStr("ACBCD_T") = hdnACBCD_T.Value.Trim
        'End If
        'cdb.mExecQuery()
        'dbData = cdb.pResult    '���ʂ��f�[�^�Z�b�g�Ɋi�[
        'cdb.mClose()
        'cdb = Nothing
        Return dbData
    End Function
    '******************************************************************************
    ' Excel�o��(�`�F�b�N��)
    '******************************************************************************
    Private Sub btnCSVout_ServerClick(ByVal sender As System.Object, _
                                    ByVal e As System.EventArgs) Handles btnCSVout.ServerClick
        Dim strRec As String
        Dim MSRUIJAG00C As New MSRUIJAG00MSRUIJAW00.MSRUIJAW00

        '//�@�F�؃N���X�̃C���X�^���X����
        AuthC = New CAuthenticate(Request, Response)

        Dim strRecMsg As String = ""

        strRec = MSRUIJAG00C.mCSV( _
                         Me.Session.SessionID, _
                         hdnKURACD.Value _
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
            HttpHeaderC.mDownLoadCSV(Response, "�ݐϏ�񎩓�FAX���[���}�X�^.csv")
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
