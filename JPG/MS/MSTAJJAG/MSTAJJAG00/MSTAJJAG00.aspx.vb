'***********************************************
'�S���҃}�X�^  ���C�����
'***********************************************
' �ύX����
' 2010/04/28 T.Watabe �A������R�O�ɑ���
' 2010/04/28 T.Watabe �N���C�A���g�A�i�`���Ƀt�@�C�����Q�܂œY�t�ł���悤�ɕύX
' 2011/04/14 T.Watabe ����FAX�������[�����M�ɑΉ�����ׂɁAJA�A���S���Җ��Ƀ��[���A�h���X��ݒ�ł���悤�ɕύX
' 2011/11/08 H.Uema   JA���ӎ�����ݒ�ł���悤�ɉ��C
' 2011/11/29 H.Uema   FAX�s�v�敪(�ײ���)��ݒ�ł���悤�ɏC��
' 2013/05/23 T.Ono    �ڋq�P�ʓo�^�@�\�ǉ�
' 2015/11    T.ONO    MSTAGJAG�Ɉڍs�B���v���O�����͖��g�p

Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common
Imports JPG.Common.log

Imports System.Text

Partial Class MSTAJJAG00
    Inherits System.Web.UI.Page

    ' 2010/04/12 T.Watabe add


    ' �� 2010/04/12 T.Watabe add
    ' �� 2010/04/12 T.Watabe add



    'Protected WithEvents FileUpload1 As System.Web.UI.WebControls.fileupload
    'Protected WithEvents btnFileDownload As System.Web.UI.HtmlControls.HtmlInputButton ' 2010/04/15 T.Watabe add


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

        '2012/04/03 NEC ou Add
        '.NET�̎d�l�ύX�ɂ��AReadOnly������ASPX�ł���ƁA�T�[�o���Œl�̎Q�Ƃ��ł��Ȃ��Ȃ邽�߁AVB����Attribute�ł���
        If MyBase.IsPostBack = False Then
            txtKURACD.Attributes.Add("ReadOnly", "true")
            txtCODE.Attributes.Add("ReadOnly", "true")
            txtFileName1.Attributes.Add("ReadOnly", "true")
            txtFileName2.Attributes.Add("ReadOnly", "true")
            txtTANCD_1.Attributes.Add("ReadOnly", "true")
            txtTANCD_2.Attributes.Add("ReadOnly", "true")
            txtTANCD_3.Attributes.Add("ReadOnly", "true")
            txtTANCD_4.Attributes.Add("ReadOnly", "true")
            txtTANCD_5.Attributes.Add("ReadOnly", "true")
            txtTANCD_6.Attributes.Add("ReadOnly", "true")
            txtTANCD_7.Attributes.Add("ReadOnly", "true")
            txtTANCD_8.Attributes.Add("ReadOnly", "true")
            txtTANCD_9.Attributes.Add("ReadOnly", "true")
            txtTANCD_10.Attributes.Add("ReadOnly", "true")
            txtTANCD_11.Attributes.Add("ReadOnly", "true")
            txtTANCD_12.Attributes.Add("ReadOnly", "true")
            txtTANCD_13.Attributes.Add("ReadOnly", "true")
            txtTANCD_14.Attributes.Add("ReadOnly", "true")
            txtTANCD_15.Attributes.Add("ReadOnly", "true")
            txtTANCD_16.Attributes.Add("ReadOnly", "true")
            txtTANCD_17.Attributes.Add("ReadOnly", "true")
            txtTANCD_18.Attributes.Add("ReadOnly", "true")
            txtTANCD_19.Attributes.Add("ReadOnly", "true")
            txtTANCD_20.Attributes.Add("ReadOnly", "true")
            txtTANCD_21.Attributes.Add("ReadOnly", "true")
            txtTANCD_22.Attributes.Add("ReadOnly", "true")
            txtTANCD_23.Attributes.Add("ReadOnly", "true")
            txtTANCD_24.Attributes.Add("ReadOnly", "true")
            txtTANCD_25.Attributes.Add("ReadOnly", "true")
            txtTANCD_26.Attributes.Add("ReadOnly", "true")
            txtTANCD_27.Attributes.Add("ReadOnly", "true")
            txtTANCD_28.Attributes.Add("ReadOnly", "true")
            txtTANCD_29.Attributes.Add("ReadOnly", "true")
            txtTANCD_30.Attributes.Add("ReadOnly", "true")
            txtAYMD.Attributes.Add("ReadOnly", "true")
            txtUYMD.Attributes.Add("ReadOnly", "true")
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
        If hdnKensaku.Value = "MSTAJJFG00" Then
            Server.Transfer("MSTAJJFG00.aspx")
        End If
        '// 2011.12.07 add h.uema *--------------* start
        If hdnKensaku.Value = "MSTAJJPG00" Then
            Server.Transfer("MSTAJJPG00.aspx")
        End If
        '// 2011.12.07 add h.uema *--------------* end

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
             MyBase.MapPath("../../../MS/MSTAJJAG/MSTAJJAG00/") & "MSTAJJAG00.js"))
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

            ' 203/07/09 T.Ono add ����ł́Atab��\�����Ȃ��i���ӎ�����\�����Ȃ��j
            If InStr(AuthC.pGROUPNAME, "0�Ď��Ɩ��P��") > 0 Then
                hdntab.Value = "1"      '�\���Ȃ�
            Else
                hdntab.Value = "0"      '�\������
            End If

        Else
            '//--------------------------------------
            '//�@�Q��ڈȍ~���s�����
            '//--------------------------------------

            '2015/02/18 T.Ono del 2014���P�J�� No15
            '' 2013/07/31 T.Ono add ����ȊO�̃��[�h���ɁAJA�x�����ނ����I���Ȃ�\����ς���
            'If txtCODE.Text = "" OrElse txtCODE.Text = " " Then
            '    lblpre.Text = "�N���C�A���g���ӎ���"
            '    strMsg.Append("Form1.document.getElementById('tblFAX_Default').style.display = 'none';") '2013/12/13 T.Ono add �Ď����P2013
            'Else
            '    lblpre.Text = "JA���ӎ���"
            '    strMsg.Append("Form1.document.getElementById('tblFAX_Default').style.display = 'block';") '2013/12/13 T.Ono add �Ď����P2013
            'End If

        End If

        '//�S���敪�̃��W�I�{�^���Ő��䂷�邽��
        strMsg.Append("window_open();")

        '//-------------------------------------------------
        '<TODO>�����̉��ID��HIDDEN��hdnMyAspx�ɏ������ށi�V�X�e�����ʁj
        hdnMyAspx.Value = "MSTAJJAG00"
        '//-------------------------------------------------


        '//-------------------------------------------------
        fncSearchAndSetFileName12() ' �t�@�C�����������\��

        ' 2013/07/11 T.Ono add
        ' �R���{�{�b�N�X�̃Z�b�g���e���ALoad����Ɠx�ɃN���A�����̂ŁA����Z�b�g���Ȃ���
        Dim sAUTO_KBN(30) As String
        Dim sAUTO_ZERO_FLG(30) As String
        Dim objAUTO_KBN As JPG.Common.Controls.CTLCombo
        Dim objAUTO_ZERO_FLG As JPG.Common.Controls.CTLCombo
        fncCombo_Get(sAUTO_KBN, sAUTO_ZERO_FLG)
        fncCombo_Create_AUTOKBN()
        fncCombo_Create_AUTOZEROFLG()
        For i As Integer = 1 To 30
            objAUTO_KBN = CType(FindControl("cboAUTO_KBN_" & CStr(i)), JPG.Common.Controls.CTLCombo)
            objAUTO_ZERO_FLG = CType(FindControl("cboAUTO_ZERO_FLG_" & CStr(i)), JPG.Common.Controls.CTLCombo)
            fncCombo_Select(objAUTO_KBN, sAUTO_KBN(i))
            fncCombo_Select(objAUTO_ZERO_FLG, sAUTO_ZERO_FLG(i))
        Next

        '�t�@�C���֌W�{�^���ɃC�x���g��ǉ�
        btnFileDelete1.Attributes("OnClick") = "return confirm('�폜���Ă�낵���ł����H');"
        btnFileDelete2.Attributes("OnClick") = "return confirm('�폜���Ă�낵���ł����H');"
        btnFileUpload.Attributes("OnClick") = "return btnFileUpload_onclick();"
        '//-------------------------------------------------

    End Sub

    '******************************************************************************
    '* ���������������O�̉�ʏ�ԁiReadOnly��Disabled�j
    '********************************/*********************************************
    Private Sub fncIni_statebf()
        '//--------------------------------------------------------------------------
        '<TODO>�����O�̏�ԂɃR���g���[���̏�Ԃ�ݒ肷��

        btnKURACD.Disabled = False

        'Dim objTANCD As System.Web.UI.WebControls.TextBox
        'Dim i As Integer
        'For i = 1 To 10
        '    objTANCD = CType(FindControl("txtTANCD_" & CStr(i)), System.Web.UI.WebControls.TextBox) '�R���g���[������T���o���A�^�ϊ�
        '    objTANCD.ReadOnly = False
        '    objTANCD.CssClass = "c-k"
        '    objTANCD.BackColor = Nothing            '�u���E�U��Color���䂪�s����Ȉ�Color�ݒ���s��
        '    'objTANCD.TabIndex = 4
        'Next


    End Sub

    '******************************************************************************
    '* �������������ꂽ��̉�ʏ�ԁiReadOnly��Disabled�j
    '******************************************************************************
    Private Sub fncIni_stateaf()
        '//--------------------------------------------------------------------------
        '<TODO>������̏�ԂɃR���g���[���̏�Ԃ�ݒ肷��
        '

        'btnKURACD.Disabled = True
        'btnCODECD.Disabled = True

        'Dim objTANCD As System.Web.UI.WebControls.TextBox
        'Dim i As Integer
        'For i = 1 To 10
        '    objTANCD = CType(FindControl("txtTANCD_" & CStr(i)), System.Web.UI.WebControls.TextBox) '�R���g���[������T���o���A�^�ϊ�
        '    objTANCD.ReadOnly = True
        '    objTANCD.CssClass = "c-RO"
        '    objTANCD.BackColor = System.Drawing.Color.Gainsboro            '�u���E�U��Color���䂪�s����Ȉ�Color�ݒ���s��
        '    'objTANCD.TabIndex = -1
        'Next

        '2012/05/25 NEC ou Add Str
        txtKURACD.Attributes.Add("ReadOnly", "true")
        txtCODE.Attributes.Add("ReadOnly", "true")
        txtFileName1.Attributes.Add("ReadOnly", "true")
        txtFileName2.Attributes.Add("ReadOnly", "true")
        txtTANCD_1.Attributes.Add("ReadOnly", "true")
        txtTANCD_2.Attributes.Add("ReadOnly", "true")
        txtTANCD_3.Attributes.Add("ReadOnly", "true")
        txtTANCD_4.Attributes.Add("ReadOnly", "true")
        txtTANCD_5.Attributes.Add("ReadOnly", "true")
        txtTANCD_6.Attributes.Add("ReadOnly", "true")
        txtTANCD_7.Attributes.Add("ReadOnly", "true")
        txtTANCD_8.Attributes.Add("ReadOnly", "true")
        txtTANCD_9.Attributes.Add("ReadOnly", "true")
        txtTANCD_10.Attributes.Add("ReadOnly", "true")
        txtTANCD_11.Attributes.Add("ReadOnly", "true")
        txtTANCD_12.Attributes.Add("ReadOnly", "true")
        txtTANCD_13.Attributes.Add("ReadOnly", "true")
        txtTANCD_14.Attributes.Add("ReadOnly", "true")
        txtTANCD_15.Attributes.Add("ReadOnly", "true")
        txtTANCD_16.Attributes.Add("ReadOnly", "true")
        txtTANCD_17.Attributes.Add("ReadOnly", "true")
        txtTANCD_18.Attributes.Add("ReadOnly", "true")
        txtTANCD_19.Attributes.Add("ReadOnly", "true")
        txtTANCD_20.Attributes.Add("ReadOnly", "true")
        txtTANCD_21.Attributes.Add("ReadOnly", "true")
        txtTANCD_22.Attributes.Add("ReadOnly", "true")
        txtTANCD_23.Attributes.Add("ReadOnly", "true")
        txtTANCD_24.Attributes.Add("ReadOnly", "true")
        txtTANCD_25.Attributes.Add("ReadOnly", "true")
        txtTANCD_26.Attributes.Add("ReadOnly", "true")
        txtTANCD_27.Attributes.Add("ReadOnly", "true")
        txtTANCD_28.Attributes.Add("ReadOnly", "true")
        txtTANCD_29.Attributes.Add("ReadOnly", "true")
        txtTANCD_30.Attributes.Add("ReadOnly", "true")
        txtAYMD.Attributes.Add("ReadOnly", "true")
        txtUYMD.Attributes.Add("ReadOnly", "true")
        '2012/05/25 NEC ou Add End
    End Sub

    '******************************************************************************
    '* �e�R���g���[���̐ݒ�l�̏�����
    '******************************************************************************
    Private Sub fncIni_format()
        '//--------------------------------------------------------------------------
        '<TODO>�R���g���[���̒l������������

        txtKURACD.Text = ""
        hdnKURACD.Value = ""
        txtCODE.Text = ""
        hdnCODE.Value = ""
        '������ 2013/05/23 T.Ono add �ڋq�P�ʓo�^�@�\�ǉ� ������
        txtUSER_CD_FROM.Text = ""
        txtUSER_CD_TO.Text = ""
        txtUSER_NM.Text = ""
        '������ 2013/05/23 T.Ono add �ڋq�P�ʓo�^�@�\�ǉ� ������

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
        hdnCODE_MOTO.Value = ""
        hdnUSER_CD_FROM_MOTO.Value = ""     ' 2013/05/30 T.Ono add
        hdnUSER_CD_TO_MOTO.Value = ""       ' 2013/05/30 T.Ono add
        txtUSER_NM.Text = ""                ' 2013/05/27 T.Ono add

        Dim objCopy As System.Web.UI.WebControls.CheckBox '2015/02/24 T.Ono add 2014���P�J�� No15
        Dim objEDT_DT As System.Web.UI.HtmlControls.HtmlInputHidden
        Dim objDISP_NO As System.Web.UI.HtmlControls.HtmlInputHidden
        Dim objTANCD As System.Web.UI.WebControls.TextBox
        Dim objTANNM As System.Web.UI.WebControls.TextBox
        Dim objRENTEL1 As System.Web.UI.WebControls.TextBox
        Dim objRENTEL2 As System.Web.UI.WebControls.TextBox
        Dim objRENTEL3 As System.Web.UI.WebControls.TextBox ' 2013/05/23 T.Ono add
        Dim objFAXNO As System.Web.UI.WebControls.TextBox
        Dim objBIKO As System.Web.UI.WebControls.TextBox
        Dim objAUTO_MAIL As System.Web.UI.WebControls.TextBox ' 2011/04/14 T.Watabe add
        Dim objSPOT_MAIL As System.Web.UI.WebControls.TextBox ' 2012/03/23 W.GANEKO add
        Dim objMAIL_PASS As System.Web.UI.WebControls.TextBox ' 2012/03/23 W.GANEKO add
        Dim objAUTO_MAIL_PASS As System.Web.UI.WebControls.TextBox  ' 2013/05/23 T.Ono add
        Dim objAUTO_FAXNO As System.Web.UI.WebControls.TextBox      ' 2013/05/23 T.Ono add
        Dim objAUTO_FAXNM As System.Web.UI.WebControls.TextBox      ' 2013/07/18 T.Ono add
        Dim i As Integer
        'For i = 1 To 10 2010/04/12 T.Watabe edit
        For i = 1 To 30
            objCopy = CType(FindControl("chkCopy_" & CStr(i)), System.Web.UI.WebControls.CheckBox) '2015/02/24 T.Ono add 2014���P�J�� No15
            objEDT_DT = CType(FindControl("hdnEDT_DT_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden) '�R���g���[������T���o���A�^�ϊ�
            objDISP_NO = CType(FindControl("hdnDISP_NO_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
            objTANCD = CType(FindControl("txtTANCD_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objTANNM = CType(FindControl("txtTANNM_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objRENTEL1 = CType(FindControl("txtRENTEL1_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objRENTEL2 = CType(FindControl("txtRENTEL2_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objRENTEL3 = CType(FindControl("txtRENTEL3_" & CStr(i)), System.Web.UI.WebControls.TextBox) ' 2013/05/23 T.Ono add
            objFAXNO = CType(FindControl("txtFAXNO_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objBIKO = CType(FindControl("txtBIKO_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objAUTO_MAIL = CType(FindControl("txtAUTO_MAIL_" & CStr(i)), System.Web.UI.WebControls.TextBox) ' 2011/04/14 T.Watabe add
            objSPOT_MAIL = CType(FindControl("txtSPOT_MAIL_" & CStr(i)), System.Web.UI.WebControls.TextBox) ' 2012/03/23 W.GANEKO add
            objMAIL_PASS = CType(FindControl("txtMAIL_PASS_" & CStr(i)), System.Web.UI.WebControls.TextBox) ' 2012/03/23 W.GANEKO add
            objAUTO_MAIL_PASS = CType(FindControl("txtAUTO_MAIL_PASS_" & CStr(i)), System.Web.UI.WebControls.TextBox)   ' 2013/05/23 T.Ono add
            objAUTO_FAXNO = CType(FindControl("txtAUTO_FAXNO_" & CStr(i)), System.Web.UI.WebControls.TextBox)           ' 2013/05/23 T.Ono add
            objAUTO_FAXNM = CType(FindControl("txtAUTO_FAXNM_" & CStr(i)), System.Web.UI.WebControls.TextBox)           ' 2013/07/18 T.Ono add

            objCopy.Checked = False '2015/02/24 T.Ono add 2014���P�J�� No15
            objEDT_DT.Value = ""
            objDISP_NO.Value = CStr(i) '�@�B�I�ɔԍ���t����
            'objTANCD.Text = CStr(i)  '�@�B�I�ɔԍ���t���� ' 2010/04/14 T.Watabe edit
            objTANCD.Text = Right("00" & CStr(i), 2) '�@�B�I�ɔԍ���t����
            objTANNM.Text = ""
            objRENTEL1.Text = ""
            objRENTEL2.Text = ""
            objRENTEL3.Text = ""    ' 2013/05/23 T.Ono add
            objFAXNO.Text = ""
            objBIKO.Text = ""
            objAUTO_MAIL.Text = "" ' 2011/04/14 T.Watabe add
            objSPOT_MAIL.Text = "" ' 2012/03/23 W.GANEKO add
            objMAIL_PASS.Text = "" ' 2012/03/23 W.GANEKO add
            objAUTO_MAIL_PASS.Text = "" ' 2013/05/23 T.Ono add
            objAUTO_FAXNO.Text = ""     ' 2013/05/23 T.Ono add
            objAUTO_FAXNM.Text = ""     ' 2013/07/18 T.Ono add
        Next

        '2011/11/18 ADD H.Uema
        txtGUIDELINE.Text = ""

        '2011/12/01 ADD H.Uema
        checkedRadio(rdoFAXJA1)
        checkedRadio(rdoFAXKURA1)
        '2015/02/24 T.Ono add 2014���P�J�� No15
        hdnFAXJA_MOTO.Value = "9"
        hdnFAXKURA_MOTO.Value = "9"

        '�t�@�C���֘A�����N���A
        hdnFileKey.Text = ""
        txtFileName1.Text = ""
        txtFileName2.Text = ""

        ' 2013/07/10 T.Ono add
        ' �R���{�{�b�N�X�̃Z�b�g
        fncCombo_Create_AUTOKBN()
        fncCombo_Create_AUTOZEROFLG()

    End Sub

    '******************************************************************************
    '* ���t(�쐬���X�V��)������������
    '******************************************************************************
    Private Sub fncIni_date()
        txtAYMD.Text = ""
        txtUYMD.Text = ""
        hdnTIME.Value = ""
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
        '2012/04/04 NEC ou Upd
        'strRecLog = LogC.mAPLog(Request.Cookies.Get("ASP.NET_SessionId").Value, AuthC.pUSERNAME, AuthC.pIPADDRESS, hdnMyAspx.Value, "4", strRec, Request.Form)
        strRecLog = LogC.mAPLog(Me.Session.SessionID, AuthC.pUSERNAME, AuthC.pIPADDRESS, hdnMyAspx.Value, "4", strRec, Request.Form)
        '2012/04/04 NEC ou Upd
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
            If hdnPopcrtl.Value = "1" Then
                If hdnBackUrl.Value = "EIGYOU" Then
                    '//�c�Ə��O���[�v�̏ꍇ�͊Ď��Z���^�[���R�t�����Ȃ��ׁA�S�N���C�A���g���o��
                    strRec = ""
                Else
                    '//
                    strRec = AuthC.pAUTHCENTERCD    '//�N���C�A���g�R�[�h�ꗗ �`�c�F�؂̎g�p�\�Ď��Z���^�[�R�[�h
                End If
            ElseIf hdnPopcrtl.Value = "2" Then      '//�R�[�h�ꗗ
                strRec = hdnKURACD.Value        '//�i�`�x���R�[�h�ꗗ
            ElseIf hdnPopcrtl.Value = "3" Then      '//�o�^�ς݈ꗗ    2015/02/18 T.Ono add 2014���P�J�� No15
                strRec = hdnKURACD.Value
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�i���ݏ�����n���v���p�e�B
    '*�@���@�l�F���o�����Q�̒l��n���@2015/02/18 T.Ono add 2014���P�J�� No15
    '******************************************************************************
    Public ReadOnly Property pCode2() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "2" Then      '//�R�[�h�ꗗ
                strRec = ""
            ElseIf hdnPopcrtl.Value = "3" Then      '//�o�^�ς݈ꗗ
                If hdnCODE.Value = "XXXX" Then
                    strRec = ""
                Else
                    strRec = hdnCODE.Value.Trim
                End If
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
            ElseIf hdnPopcrtl.Value = "2" Then      '//�R�[�h�ꗗ
                strRec = "�i�`�x���R�[�h�ꗗ"
            ElseIf hdnPopcrtl.Value = "3" Then      '//�o�^�ς݈ꗗ    2015/02/18 T.Ono add 2014���P�J�� No15
                strRec = "�o�^�ς݈ꗗ"
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
            If hdnPopcrtl.Value = "1" Then          '//�N���C�A���g�R�[�h�ꗗ
                strRec = "CLI"
            ElseIf hdnPopcrtl.Value = "2" Then      '//�R�[�h�ꗗ
                strRec = "JASS"      '--- 2008/02/27 MOD T.Watabe ---
            ElseIf hdnPopcrtl.Value = "3" Then      '//�o�^�ς݈ꗗ    2015/02/18 T.Ono add 2014���P�J�� No15
                strRec = "JATANMAS"
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
                strRec = "hdnCODE"
            ElseIf hdnPopcrtl.Value = "3" Then      '//�o�^�ς݈ꗗ    2015/02/18 T.Ono add 2014���P�J�� No15
                '�u005003:51021180�`51021200�v�̌`���œ��邽�߁A�����̒l�͎g���Ȃ���
                '�w�肵�Ȃ��Ɠ����Ȃ��̂ŁA�Ƃ肠�����w��B���ۂ�pBackCode2�̒l���g�p����B
                strRec = "hdnCODE"
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
                strRec = "txtCODE"
            ElseIf hdnPopcrtl.Value = "3" Then      '//�o�^�ς݈ꗗ    2015/02/18 T.Ono add 2014���P�J�� No15
                strRec = "txtCODE"
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�R�[�h��Ԃ��I�u�W�F�N�g�̖��O�l��n���v���p�e�B
    '*�@���@�l�F�f�[�^�I����A�R�[�h��Ԃ��I�u�W�F�N�g�����w�肷��@2015/02/18 T.Ono add 2014���P�J�� No15
    '******************************************************************************
    Public ReadOnly Property pBackCode2() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "3" Then      '//�o�^�ς݈ꗗ    2015/02/18 T.Ono add 2014���P�J�� No15
                strRec = "hdnCODE"                  '//JA�x���R�[�h
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F���̂�Ԃ��I�u�W�F�N�g�̖��O�l��n���v���p�e�B
    '*�@���@�l�F�f�[�^�I����A���̂�Ԃ��I�u�W�F�N�g�����w�肷��@2015/02/18 T.Ono add 2014���P�J�� No15
    '******************************************************************************
    Public ReadOnly Property pBackName2() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "3" Then      '//�o�^�ς݈ꗗ    2015/02/18 T.Ono add 2014���P�J�� No15
                strRec = "hdnUSER_CD_TEMP"          '//���q�l�R�[�hFrom,���q�l�R�[�hTo
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
                strRec = "btnCODECD"
            ElseIf hdnPopcrtl.Value = "3" Then      '//�o�^�ς݈ꗗ    2015/02/18 T.Ono add 2014���P�J�� No15
                strRec = "btnTOUROKUZUMI"
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pClear1() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "hdnCODE"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "3" Then      '//�o�^�ς݈ꗗ    2015/02/18 T.Ono add 2014���P�J�� No15
                strRec = ""
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pClear2() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "txtCODE"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "3" Then      '//�o�^�ς݈ꗗ    2015/02/18 T.Ono add 2014���P�J�� No15
                strRec = ""
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�N���C�A���g�AJA�x���I�����͂��q�l�R�[�h(From)���N���A 2013/07/04 T.Ono add
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pClear3() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "txtUSER_CD_FROM"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = "txtUSER_CD_FROM"
            ElseIf hdnPopcrtl.Value = "3" Then      '//�o�^�ς݈ꗗ    2015/02/18 T.Ono add 2014���P�J�� No15
                strRec = "txtUSER_CD_FROM"
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�N���C�A���g�AJA�x���I�����͂��q�l�R�[�h(To)���N���A 2013/07/04 T.Ono add
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pClear4() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "txtUSER_CD_TO"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = "txtUSER_CD_TO"
            ElseIf hdnPopcrtl.Value = "3" Then      '//�o�^�ς݈ꗗ    2015/02/18 T.Ono add 2014���P�J�� No15
                strRec = "txtUSER_CD_TO"
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�N���C�A���g�AJA�x���I�����͂��q�l�����N���A 2013/07/04 T.Ono add
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pClear5() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "txtUSER_NM"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = "txtUSER_NM"
            ElseIf hdnPopcrtl.Value = "3" Then      '//�o�^�ς݈ꗗ    2015/02/18 T.Ono add 2014���P�J�� No15
                strRec = "txtUSER_NM"
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
            If hdnPopcrtl.Value = "1" Then      '�N���C�A���g�R�[�h
                'strRec = "fncFAXKBNDisp" '2015/02/18 T.Ono mod 2014���P�J�� No15
                strRec = ""
            ElseIf hdnPopcrtl.Value = "2" Then  '�i�`�x��
                'strRec = "fncFAXKBNDisp" '2015/02/18 T.Ono mod 2014���P�J�� No15
                strRec = ""
            ElseIf hdnPopcrtl.Value = "3" Then  '�o�^�ς݈ꗗ    2015/02/18 T.Ono add 2014���P�J�� No15
                strRec = "fncSetUserCD"
                'strRec = ""
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

            '������ 2013/05/23 T.Ono add �ڋq�P�ʓo�^�@�\�ǉ� ������
            '���q�l�R�[�h�̓��͗L����select�����s�����𕪂���
            'dbData = fncDataSelect(0)
            If (txtUSER_CD_FROM.Text <> "") Then
                '�Ƃ肠�������q�l�R�[�h���������A����Ε\��
                dbData = fncUSERCD_Check()
                If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
                    txtUSER_NM.Text = ""
                Else
                    txtUSER_NM.Text = Convert.ToString(dbData.Tables(0).Rows(0).Item("USER_NM"))
                End If

                dbData = fncDataSelect2(0)

            Else
                dbData = fncDataSelect(0)
            End If
            '������ 2013/05/23 T.Ono add �ڋq�P�ʓo�^�@�\�ǉ� ������


            If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
                '�f�[�^�����݂��Ȃ��ׁA�����̓G���[
                '���b�Z�[�W���o�͌�A�����O��Ԃɂ���B

                strMsg.Append("alert('�f�[�^�����݂��܂���');")

                Call fncIni_statebf()
                '//--------------------------------------------------------------------------
            Else
                '�f�[�^�����݂���ׁA�V�K�o�^�͕s��
                '�f�[�^���o�͌�A�������Ԃɂ���B

                '------------------------------------
                '<TODO>�f�[�^���o�͂���

                '�N���C�A���g�R�[�h
                hdnKURACD.Value = Convert.ToString(dbData.Tables(0).Rows(0).Item("KURACD"))
                hdnKURACD_MOTO.Value = Convert.ToString(dbData.Tables(0).Rows(0).Item("KURACD"))
                '�N���C�A���g��
                txtKURACD.Text = Convert.ToString(dbData.Tables(0).Rows(0).Item("KURACD")) & " : " & Convert.ToString(dbData.Tables(0).Rows(0).Item("CLI_NAME"))
                '�R�[�h
                hdnCODE.Value = Convert.ToString(dbData.Tables(0).Rows(0).Item("CODE"))
                hdnCODE_MOTO.Value = Convert.ToString(dbData.Tables(0).Rows(0).Item("CODE"))
                '�R�[�h����
                ' 2013/06/24 T.Ono mod
                'txtCODE.Text = Convert.ToString(dbData.Tables(0).Rows(0).Item("CODE")) & " : " & Convert.ToString(dbData.Tables(0).Rows(0).Item("JAS_NAME"))
                If Convert.ToString(dbData.Tables(0).Rows(0).Item("CODE")) = "XXXX" Then
                    txtCODE.Text = ""
                    lblpre.Text = "�N���C�A���g���ӎ���"
                Else
                    txtCODE.Text = Convert.ToString(dbData.Tables(0).Rows(0).Item("CODE")) & " : " & Convert.ToString(dbData.Tables(0).Rows(0).Item("JAS_NAME"))
                    lblpre.Text = "JA���ӎ���"
                End If

                '������ 2013/05/24 T.Ono add �ڋq�P�ʓo�^�@�\�ǉ� ������
                If (txtUSER_CD_FROM.Text <> "") Then
                    '���q�l�R�[�h
                    hdnUSER_CD_FROM_MOTO.Value = Convert.ToString(dbData.Tables(0).Rows(0).Item("USER_CD_FROM"))
                    hdnUSER_CD_TO_MOTO.Value = Convert.ToString(dbData.Tables(0).Rows(0).Item("USER_CD_TO"))
                    '���q�l����
                    txtUSER_NM.Text = Convert.ToString(dbData.Tables(0).Rows(0).Item("USER_NM"))
                Else
                    hdnUSER_CD_FROM_MOTO.Value = ""
                    hdnUSER_CD_TO_MOTO.Value = ""
                    txtUSER_NM.Text = ""
                End If
                '������ 2013/05/24 T.Ono add �ڋq�P�ʓo�^�@�\�ǉ� ������

                Dim sMinAddDate As String
                Dim sMaxEdtDate As String
                Dim sMaxTime As String
                sMinAddDate = DateFncC.mGet(Convert.ToString(dbData.Tables(0).Rows(0).Item("ADD_DATE")))
                sMaxEdtDate = DateFncC.mGet(Convert.ToString(dbData.Tables(0).Rows(0).Item("EDT_DATE")))
                sMaxTime = Convert.ToString(dbData.Tables(0).Rows(0).Item("TIME"))

                Dim objDISP_NO As System.Web.UI.HtmlControls.HtmlInputHidden
                Dim objTANCD As System.Web.UI.WebControls.TextBox
                Dim objTANNM As System.Web.UI.WebControls.TextBox
                Dim objRENTEL1 As System.Web.UI.WebControls.TextBox
                Dim objRENTEL2 As System.Web.UI.WebControls.TextBox
                Dim objRENTEL3 As System.Web.UI.WebControls.TextBox  '2013/05/23 T.Ono add
                Dim objFAXNO As System.Web.UI.WebControls.TextBox
                Dim objBIKO As System.Web.UI.WebControls.TextBox
                Dim objAUTO_MAIL As System.Web.UI.WebControls.TextBox '2011/04/14 T.Watabe add
                Dim objSPOT_MAIL As System.Web.UI.WebControls.TextBox '2012/03/23 W.GANEKO add
                Dim objMAIL_PASS As System.Web.UI.WebControls.TextBox '2012/03/23 W.GANEKO add
                Dim objEDT_DT As System.Web.UI.HtmlControls.HtmlInputHidden
                Dim objAUTO_MAIL_PASS As System.Web.UI.WebControls.TextBox  ' 2013/05/23 T.Ono add
                Dim objAUTO_FAXNO As System.Web.UI.WebControls.TextBox      ' 2013/05/23 T.Ono add
                Dim objAUTO_FAXNM As System.Web.UI.WebControls.TextBox      ' 2013/07/18 T.Ono add
                Dim objAUTO_KBN As JPG.Common.Controls.CTLCombo             ' 2013/07/04 T.Ono add
                Dim objAUTO_ZERO_FLG As JPG.Common.Controls.CTLCombo        ' 2013/07/04 T.Ono add
                Dim strCboIndex As String                                   ' 2013/07/04 T.Ono add �R���{�{�b�N�X�I���C���f�b�N�X

                Dim i As Integer
                Dim intRow As Integer
                Dim sDispNo As String

                For intRow = 0 To dbData.Tables(0).Rows.Count - 1

                    'If intRow >= 10 Then Exit For '10���ȏ�͏������� 2010/04/12 T.Watabe edit
                    If intRow >= 30 Then Exit For '30���ȏ�͏�������

                    '----------------------------
                    ' �ŏ��̓o�^���A�Ō�̍X�V��������ʍ��ڂɃZ�b�g
                    '----------------------------
                    '�o�^�����󂩁A�ȑO�̏ꍇ�A�Z�b�g
                    If sMinAddDate = "" _
                        Or DateFncC.mGet(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("ADD_DATE"))) < sMinAddDate Then
                        sMinAddDate = DateFncC.mGet(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("ADD_DATE")))
                    End If
                    '�X�V�����󂩁A����Ɍ�̏ꍇ�A�Z�b�g
                    If DateFncC.mGet(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("EDT_DATE"))) <> "" _
                        And DateFncC.mGet(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("EDT_DATE"))) >= sMaxEdtDate Then
                        sMaxEdtDate = DateFncC.mGet(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("EDT_DATE")))

                        '�������󂩁A����Ɍ�̎��Ԃ̏ꍇ�A�Z�b�g
                        If sMaxTime = "" _
                            Or Convert.ToString(dbData.Tables(0).Rows(intRow).Item("TIME")) >= sMaxTime Then
                            sMaxTime = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("TIME"))
                        End If
                    End If

                    '----------------------------
                    ' ���׏�����ʍ��ڂɃZ�b�g
                    '----------------------------
                    sDispNo = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("DISP_NO"))
                    'For i = intRow + 1 To 10 ' 2010/04/12 T.Watabe edit
                    For i = intRow + 1 To 30
                        If Trim(sDispNo) = "" Then
                            sDispNo = "0"
                        ElseIf IsNumeric(sDispNo) = False Then
                            sDispNo = "0"
                        End If
                        If CInt(sDispNo) <= i Then '�\���ԍ�����(�ݒ肳��Ă��Ȃ��ꍇ)�A���[�v���̉񐔂��Ⴂ�ꍇ(���Ԃœo�^����Ă���ꍇ�΍�)

                            objDISP_NO = CType(FindControl("hdnDISP_NO_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
                            objTANCD = CType(FindControl("txtTANCD_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                            objTANNM = CType(FindControl("txtTANNM_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                            objRENTEL1 = CType(FindControl("txtRENTEL1_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                            objRENTEL2 = CType(FindControl("txtRENTEL2_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                            objRENTEL3 = CType(FindControl("txtRENTEL3_" & CStr(i)), System.Web.UI.WebControls.TextBox)     '2013/05/23 T.Ono add
                            objFAXNO = CType(FindControl("txtFAXNO_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                            objBIKO = CType(FindControl("txtBIKO_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                            objAUTO_MAIL = CType(FindControl("txtAUTO_MAIL_" & CStr(i)), System.Web.UI.WebControls.TextBox) ' 2011/04/14 T.Watabe add
                            objSPOT_MAIL = CType(FindControl("txtSPOT_MAIL_" & CStr(i)), System.Web.UI.WebControls.TextBox) ' 2012/03/23 W.GANEKO add
                            objMAIL_PASS = CType(FindControl("txtMAIL_PASS_" & CStr(i)), System.Web.UI.WebControls.TextBox) ' 2012/03/23 W.GANEKO add
                            objEDT_DT = CType(FindControl("hdnEDT_DT_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
                            objAUTO_MAIL_PASS = CType(FindControl("txtAUTO_MAIL_PASS_" & CStr(i)), System.Web.UI.WebControls.TextBox)   ' 2013/05/23 T.Ono add
                            objAUTO_FAXNO = CType(FindControl("txtAUTO_FAXNO_" & CStr(i)), System.Web.UI.WebControls.TextBox)           ' 2013/05/23 T.Ono add
                            objAUTO_FAXNM = CType(FindControl("txtAUTO_FAXNM_" & CStr(i)), System.Web.UI.WebControls.TextBox)           ' 2013/07/18 T.Ono add
                            objAUTO_KBN = CType(FindControl("cboAUTO_KBN_" & CStr(i)), JPG.Common.Controls.CTLCombo)                    ' 2013/07/04 T.Ono add
                            objAUTO_ZERO_FLG = CType(FindControl("cboAUTO_ZERO_FLG_" & CStr(i)), JPG.Common.Controls.CTLCombo)          ' 2013/07/04 T.Ono add

                            objDISP_NO.Value = CStr(i)
                            objTANCD.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("TANCD"))
                            objTANNM.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("TANNM"))
                            objRENTEL1.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("RENTEL1"))
                            objRENTEL2.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("RENTEL2"))
                            objRENTEL3.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("RENTEL3"))       '2013/05/23 T.Ono add
                            objFAXNO.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("FAXNO"))
                            objBIKO.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("BIKO"))
                            objAUTO_MAIL.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("AUTO_MAIL")) ' 2011/04/14 T.Watabe add
                            objSPOT_MAIL.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("SPOT_MAIL")) ' 2012/03/23 W.GANEKO add
                            objMAIL_PASS.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("MAIL_PASS")) ' 2012/03/23 W.GANEKO add
                            objEDT_DT.Value = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("EDT_DATE")) & Convert.ToString(dbData.Tables(0).Rows(intRow).Item("TIME"))
                            objAUTO_MAIL_PASS.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("AUTO_MAIL_PASS")) ' 2013/05/23 T.Ono add
                            objAUTO_FAXNO.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("AUTO_FAXNO"))         ' 2013/05/23 T.Ono add
                            objAUTO_FAXNM.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("AUTO_FAXNM"))         ' 2013/07/18 T.Ono add

                            ' �������M�敪        ' 2013/07/04/ T.Ono add
                            strCboIndex = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("AUTO_KBN"))
                            fncCombo_Select(objAUTO_KBN, strCboIndex)

                            ' �[�������M�t���O    ' 2013/07/04/ T.Ono add
                            strcboindex = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("AUTO_ZERO_FLG"))
                            fncCombo_Select(objAUTO_ZERO_FLG, strCboIndex)


                            ' 2011/11/08 ADD H.Uema
                            If "01" = objTANCD.Text Then
                                'JA���ӎ����Z�b�g
                                txtGUIDELINE.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("GUIDELINE"))

                                'FAX�s�v�t���O(�ײ���)
                                hdnFAXKURA_MOTO.Value = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("FAXKURAKBN")) '2015/02/18 T.Ono add 2014���P�J�� ��15
                                If Convert.ToString(dbData.Tables(0).Rows(intRow).Item("FAXKURAKBN")) = "1" Then
                                    checkedRadio(rdoFAXKURA3)
                                ElseIf Convert.ToString(dbData.Tables(0).Rows(intRow).Item("FAXKURAKBN")) = "0" Then
                                    checkedRadio(rdoFAXKURA2)
                                Else
                                    checkedRadio(rdoFAXKURA1)
                                End If

                                'FAX�s�v�t���O(JA)
                                hdnFAXJA_MOTO.Value = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("FAXKBN")) '2015/02/18 T.Ono add 2014���P�J�� ��15
                                If Convert.ToString(dbData.Tables(0).Rows(intRow).Item("FAXKBN")) = "1" Then
                                    checkedRadio(rdoFAXJA3)
                                ElseIf Convert.ToString(dbData.Tables(0).Rows(intRow).Item("FAXKBN")) = "0" Then
                                    checkedRadio(rdoFAXJA2)
                                Else
                                    checkedRadio(rdoFAXJA1)
                                End If
                            End If

                            Exit For '�����Ēl�Z�b�g�����玟���R�[�h��
                        End If
                    Next ' i
                Next ' intRow

                txtAYMD.Text = sMinAddDate
                txtUYMD.Text = sMaxEdtDate
                hdnTIME.Value = sMaxTime

                '�f�[�^���Ȃ����ڂɒS���҃R�[�h�𖄂߂Ă���
                'For i = 1 To 10 ' 2010/04/12
                For i = 1 To 30
                    objTANCD = CType(FindControl("txtTANCD_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                    If objTANCD.Text = "" Then
                        objTANCD.Text = Right("00" & CStr(i), 2)
                    End If
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

            fncSearchAndSetFileName12() ' �t�@�C�����������\��

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
        Dim MSTAJJAW00C As New MSTAJJAG00MSTAJJAW00.MSTAJJAW00

        '//-----------------------------------------------
        '<TODO>���W�I�{�^���`�F�b�N
        Dim strKBN As String
        strKBN = "3"        '//�i�`�x���S���҂Ƀ`�F�b�N

        '//-----------------------------------------------
        '<TODO>�N���C�A���g�R�[�h
        Dim strKURACD As String
        strKURACD = hdnKURACD.Value

        '2013/05/23 T.Ono add �ڋq�P�ʓo�^�@�\�ǉ�
        '//-----------------------------------------------
        '<TODO>���q�l�R�[�h
        Dim strUSER_CD_FROM As String
        Dim strUSER_CD_TO As String
        strUSER_CD_FROM = txtUSER_CD_FROM.Text
        strUSER_CD_TO = txtUSER_CD_TO.Text


        '�l��z��ɃZ�b�g
        'Dim sEDT_DT(10) As String ' 2010/04/12
        'Dim sDISP_NO(10) As String
        'Dim sTANCD(10) As String
        'Dim sTANNM(10) As String
        'Dim sRENTEL1(10) As String
        'Dim sRENTEL2(10) As String
        'Dim sFAXNO(10) As String
        'Dim sBIKO(10) As String
        Dim sEDT_DT(30) As String
        Dim sDISP_NO(30) As String
        Dim sTANCD(30) As String
        Dim sTANNM(30) As String
        Dim sRENTEL1(30) As String
        Dim sRENTEL2(30) As String
        Dim sRENTEL3(30) As String      ' 2013/05/23 T.Ono add
        Dim sFAXNO(30) As String
        Dim sBIKO(30) As String
        Dim sAUTO_MAIL(50) As String ' 2011/04/14 T.Watabe add
        Dim sSPOT_MAIL(50) As String ' 2012/03/23 W.GANEKO add
        Dim sMAIL_PASS(50) As String ' 2012/03/23 W.GANEKO add
        Dim sGUIDELINE(30) As String ' 2011/11/08 H.Uema add
        Dim sFAXKURAKBN(30) As String ' 2011/11/29 H.Uema add
        Dim sFAXJAKBN(30) As String ' 2011/12/01 H.Uema add
        Dim sAUTO_MAIL_PASS(50) As String   ' 2013/05/23 T.Ono add
        Dim sAUTO_FAXNO(30) As String       ' 2013/05/23 T.Ono add
        Dim sAUTO_FAXNM(30) As String       ' 2013/07/18 T.Ono add
        Dim sAUTO_KBN(30) As String         ' 2013/05/23 T.Ono add
        Dim sAUTO_ZERO_FLG(30) As String    ' 2013/05/23 T.Ono add
        Dim objEDT_DT As System.Web.UI.HtmlControls.HtmlInputHidden
        Dim objDISP_NO As System.Web.UI.HtmlControls.HtmlInputHidden
        Dim objTANCD As System.Web.UI.WebControls.TextBox
        Dim objTANNM As System.Web.UI.WebControls.TextBox
        Dim objRENTEL1 As System.Web.UI.WebControls.TextBox
        Dim objRENTEL2 As System.Web.UI.WebControls.TextBox
        Dim objRENTEL3 As System.Web.UI.WebControls.TextBox         '2013/05/23 T.Ono add
        Dim objFAXNO As System.Web.UI.WebControls.TextBox
        Dim objBIKO As System.Web.UI.WebControls.TextBox
        Dim objAUTO_MAIL As System.Web.UI.WebControls.TextBox ' 2011/04/14 T.Watabe add
        Dim objSPOT_MAIL As System.Web.UI.WebControls.TextBox ' 2011/04/14 T.Watabe add
        Dim objMAIL_PASS As System.Web.UI.WebControls.TextBox ' 2011/04/14 T.Watabe add
        Dim objAUTO_MAIL_PASS As System.Web.UI.WebControls.TextBox  ' 2013/05/23 T.Ono add
        Dim objAUTO_FAXNO As System.Web.UI.WebControls.TextBox      ' 2013/05/23 T.Ono add
        Dim objAUTO_FAXNM As System.Web.UI.WebControls.TextBox      ' 2013/07/18 T.Ono add
        Dim objAUTO_KBN As JPG.Common.Controls.CTLCombo             ' 2013/07/04 T.Ono add
        Dim objAUTO_ZERO_FLG As JPG.Common.Controls.CTLCombo        ' 2013/07/04 T.Ono add
        Dim i As Integer
        'For i = 1 To 10 ' 2010/04/12
        For i = 1 To 30
            objEDT_DT = CType(FindControl("hdnEDT_DT_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden) '�R���g���[������T���o���A�^�ϊ�
            objDISP_NO = CType(FindControl("hdnDISP_NO_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
            objTANCD = CType(FindControl("txtTANCD_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objTANNM = CType(FindControl("txtTANNM_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objRENTEL1 = CType(FindControl("txtRENTEL1_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objRENTEL2 = CType(FindControl("txtRENTEL2_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objRENTEL3 = CType(FindControl("txtRENTEL3_" & CStr(i)), System.Web.UI.WebControls.TextBox)     ' 2013/05/23 T.Ono add
            objFAXNO = CType(FindControl("txtFAXNO_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objBIKO = CType(FindControl("txtBIKO_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objAUTO_MAIL = CType(FindControl("txtAUTO_MAIL_" & CStr(i)), System.Web.UI.WebControls.TextBox) ' 2011/04/14 T.Watabe add
            objSPOT_MAIL = CType(FindControl("txtSPOT_MAIL_" & CStr(i)), System.Web.UI.WebControls.TextBox) ' 2012/03/23 W.GANEKO add
            objMAIL_PASS = CType(FindControl("txtMAIL_PASS_" & CStr(i)), System.Web.UI.WebControls.TextBox) ' 2012/03/23 W.GANEKO add
            objAUTO_MAIL_PASS = CType(FindControl("txtAUTO_MAIL_PASS_" & CStr(i)), System.Web.UI.WebControls.TextBox)   ' 2013/05/23 T.Ono add
            objAUTO_FAXNO = CType(FindControl("txtAUTO_FAXNO_" & CStr(i)), System.Web.UI.WebControls.TextBox)           ' 2013/05/23 T.Ono add
            objAUTO_FAXNM = CType(FindControl("txtAUTO_FAXNM_" & CStr(i)), System.Web.UI.WebControls.TextBox)           ' 2013/07/18 T.Ono add
            objAUTO_KBN = CType(FindControl("cboAUTO_KBN_" & CStr(i)), JPG.Common.Controls.CTLCombo)                    ' 2013/07/04 T.Ono add
            objAUTO_ZERO_FLG = CType(FindControl("cboAUTO_ZERO_FLG_" & CStr(i)), JPG.Common.Controls.CTLCombo)          ' 2013/07/04 T.Ono add

            sEDT_DT(i) = objEDT_DT.Value
            sDISP_NO(i) = objDISP_NO.Value
            sTANCD(i) = objTANCD.Text
            sTANNM(i) = Trim(objTANNM.Text)
            sRENTEL1(i) = Trim(objRENTEL1.Text)
            sRENTEL2(i) = Trim(objRENTEL2.Text)
            sRENTEL3(i) = Trim(objRENTEL3.Text)                   ' 2013/05/23 T.Ono add
            sFAXNO(i) = Trim(objFAXNO.Text)
            sBIKO(i) = Trim(objBIKO.Text)
            sAUTO_MAIL(i) = Trim(objAUTO_MAIL.Text) ' 2011/04/14 T.Watabe add
            sSPOT_MAIL(i) = Trim(objSPOT_MAIL.Text) ' 2012/03/23 W.GANEKO add
            sMAIL_PASS(i) = Trim(objMAIL_PASS.Text) ' 2012/03/23 W.GANEKO add
            sAUTO_MAIL_PASS(i) = Trim(objAUTO_MAIL_PASS.Text)    ' 2013/05/23 T.Ono add
            sAUTO_FAXNO(i) = Trim(objAUTO_FAXNO.Text)            ' 2013/05/23 T.Ono add
            sAUTO_FAXNM(i) = Trim(objAUTO_FAXNM.Text)            ' 2013/07/18 T.Ono add
            sAUTO_KBN(i) = Request.Form(objAUTO_KBN.ID)             ' 2013/07/04 T.Ono add
            sAUTO_ZERO_FLG(i) = Request.Form(objAUTO_ZERO_FLG.ID)   ' 2013/07/04 T.Ono add

            '2011/11/08 H.Uema add
            If i = 1 Then
                '���ӎ���
                sGUIDELINE(i) = Trim(txtGUIDELINE.Text)
                'FAX�s�v�t���O
                'JA
                If rdoFAXJA1.Checked Then
                    sFAXJAKBN(i) = ""
                ElseIf rdoFAXJA2.Checked Then
                    sFAXJAKBN(i) = "0"
                Else
                    sFAXJAKBN(i) = "1"
                End If
                '�ײ���
                If rdoFAXKURA1.Checked Then
                    sFAXKURAKBN(i) = ""
                ElseIf rdoFAXKURA2.Checked Then
                    sFAXKURAKBN(i) = "0"
                Else
                    sFAXKURAKBN(i) = "1"
                End If
                'If chkFAXKURAKBN.Checked Then
                '    sFAXKURAKBN(i) = "1"
                'Else
                '    sFAXKURAKBN(i) = "0"
                'End If
            Else
                sGUIDELINE(i) = ""
                sFAXKURAKBN(i) = ""
                sFAXJAKBN(i) = ""
            End If

        Next

        '--------------------------------------------
        '<TODO>WEB�T�[�r�X���Ăяo��
        ' 2011/04/14 T.Watabe edit
        'strRec = MSTAJJAW00C.mSet( _
        '                    CInt(pstrKBN), _
        '                    strKBN, _
        '                    strKURACD, _
        '                    hdnCODE.Value, _
        '                    sTANCD, _
        '                    sTANNM, _
        '                    sRENTEL1, _
        '                    sRENTEL2, _
        '                    sFAXNO, _
        '                    sDISP_NO, _
        '                    sBIKO, _
        '                    DateFncC.mHenkanGet(txtAYMD.Text), _
        '                    DateFncC.mHenkanGet(txtUYMD.Text), _
        '                    hdnTIME.Value, _
        '                    sEDT_DT)
        ' 2011/11/08 H.Uema edit
        ' 2011/12/01 H.Uema edit
        'strRec = MSTAJJAW00C.mSetEx( _
        '                    CInt(pstrKBN), _
        '                    strKBN, _
        '                    strKURACD, _
        '                    hdnCODE.Value, _
        '                    sTANCD, _
        '                    sTANNM, _
        '                    sRENTEL1, _
        '                    sRENTEL2, _
        '                    sFAXNO, _
        '                    sDISP_NO, _
        '                    sBIKO, _
        '                    DateFncC.mHenkanGet(txtAYMD.Text), _
        '                    DateFncC.mHenkanGet(txtUYMD.Text), _
        '                    hdnTIME.Value, _
        '                    sEDT_DT, _
        '                    sAUTO_MAIL)
        ' 2013/05/23 T.Ono edit
        'strRec = MSTAJJAW00C.mSetEx( _
        '                    CInt(pstrKBN), _
        '                    strKBN, _
        '                    strKURACD, _
        '                    hdnCODE.Value, _
        '                    sTANCD, _
        '                    sTANNM, _
        '                    sRENTEL1, _
        '                    sRENTEL2, _
        '                    sFAXNO, _
        '                    sDISP_NO, _
        '                    sBIKO, _
        '                    DateFncC.mHenkanGet(txtAYMD.Text), _
        '                    DateFncC.mHenkanGet(txtUYMD.Text), _
        '                    hdnTIME.Value, _
        '                    sEDT_DT, _
        '                    sAUTO_MAIL, _
        '                    sGUIDELINE, _
        '                    sFAXKURAKBN, _
        '                    sFAXJAKBN, _
        '                    sSPOT_MAIL, _
        '                    sMAIL_PASS)
        strRec = MSTAJJAW00C.mSetEx( _
                    CInt(pstrKBN), _
                    strKBN, _
                    strKURACD, _
                    hdnCODE.Value, _
                    strUSER_CD_FROM, _
                    strUSER_CD_TO, _
                    sTANCD, _
                    sTANNM, _
                    sRENTEL1, _
                    sRENTEL2, _
                    sRENTEL3, _
                    sFAXNO, _
                    sDISP_NO, _
                    sBIKO, _
                    DateFncC.mHenkanGet(txtAYMD.Text), _
                    DateFncC.mHenkanGet(txtUYMD.Text), _
                    hdnTIME.Value, _
                    sEDT_DT, _
                    sAUTO_MAIL, _
                    sGUIDELINE, _
                    sFAXKURAKBN, _
                    sFAXJAKBN, _
                    sSPOT_MAIL, _
                    sMAIL_PASS, _
                    sAUTO_MAIL_PASS, _
                    sAUTO_FAXNO, _
                    sAUTO_FAXNM, _
                    sAUTO_KBN, _
                    sAUTO_ZERO_FLG)
        '--------------------------------------------
        '<TODO>�Ԃ�l�ɂ�鐧����s���B
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
                ElseIf pstrKBN = "4" Then '4:�폜
                    Call fncIni_date()
                    ' 2013/07/10 T.Ono add �R���{�{�b�N�X�̏�����
                    fncCombo_Create_AUTOKBN()
                    fncCombo_Create_AUTOZEROFLG()
                Else
                    Call fncIni_date()
                End If
                strMsg.Append("alert('����ɏI�����܂���');")

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

                '<TODO>�t�H�[�J�X���Z�b�g����i�o�^�E�C�����ł̃G���[�B�N���C�A���g�R�[�h�����⏕�{�^���ɃZ�b�g�j
                strMsg.Append("Form1.btnSelect.focus();")

                strRec = strRecMsg

            Case "5"
                strRecMsg = "�i�`�x�������݂��܂���"
                strMsg.Append("alert('" & strRecMsg & "');")

                '<TODO>�t�H�[�J�X���Z�b�g����i�o�^�E�C�����ł̃G���[�B�R�[�h�����⏕�{�^���ɃZ�b�g�j
                strMsg.Append("Form1.btnCODECD.focus();")

                strRec = strRecMsg
            Case "6"
                strRecMsg = "�Ď��Z���^�[�����݂��܂���"
                strMsg.Append("alert('" & strRecMsg & "');")

                '<TODO>�t�H�[�J�X���Z�b�g����i�o�^�E�C�����ł̃G���[�B�R�[�h�����⏕�{�^���ɃZ�b�g�j
                strMsg.Append("Form1.btnCODECD.focus();")

                strRec = strRecMsg
            Case "7"
                strRecMsg = "�o����Ђ����݂��܂���"
                strMsg.Append("alert('" & strRecMsg & "');")

                '<TODO>�t�H�[�J�X���Z�b�g����i�o�^�E�C�����ł̃G���[�B�R�[�h�����⏕�{�^���ɃZ�b�g�j
                strMsg.Append("Form1.btnCODECD.focus();")

                strRec = strRecMsg

            Case "8"        '2013/06/25 T.Ono add
                strRecMsg = "���q�l�R�[�h�͈͂��d�����Ă��܂�"
                strMsg.Append("alert('" & strRecMsg & "');")

                '<TODO>�t�H�[�J�X���Z�b�g����i�o�^�E�C�����ł̃G���[�B�R�[�h�����⏕�{�^���ɃZ�b�g�j
                strMsg.Append("Form1.txtUSER_CD_FROM.focus();")

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
                    strMsg.Append("Form1.txtTANNM_1.focus();")
                Else
                    '//----------------------------------
                    '<TODO>�t�H�[�J�X���Z�b�g����i���̑��@�F���O�o�͂̃G���[�̈׃L�[�ȍ~�ɃZ�b�g�j
                    strMsg.Append("Form1.txtTANNM_1.focus();")
                End If
        End Select

        ' 2013/07/11 T.Ono add �G���[�̏ꍇ�́A�R���{�{�b�N�X�̏������ƁA���͒l�̃Z�b�g���s��
        If strRecTemp <> "OK" Then
            ' �R���{�{�b�N�X�Z�b�g
            fncCombo_Create_AUTOKBN()
            fncCombo_Create_AUTOZEROFLG()

            ' ���͓��e�̃Z�b�g
            For j As Integer = 1 To 30
                objAUTO_KBN = CType(FindControl("cboAUTO_KBN_" & CStr(j)), JPG.Common.Controls.CTLCombo)
                objAUTO_ZERO_FLG = CType(FindControl("cboAUTO_ZERO_FLG_" & CStr(j)), JPG.Common.Controls.CTLCombo)
                fncCombo_Select(objAUTO_KBN, sAUTO_KBN(j))
                fncCombo_Select(objAUTO_ZERO_FLG, sAUTO_ZERO_FLG(j))
            Next
        End If

        '-------------------------------------------------
        '//�`�o���O��������
        Dim LogC As New CLog
        Dim strRecLog As String
        '2012/04/04 NEC ou Upd
        'strRecLog = LogC.mAPLog(Request.Cookies.Get("ASP.NET_SessionId").Value, AuthC.pUSERNAME, AuthC.pIPADDRESS, hdnMyAspx.Value, pstrKBN, strRec, Request.Form)
        strRecLog = LogC.mAPLog(Me.Session.SessionID, AuthC.pUSERNAME, AuthC.pIPADDRESS, hdnMyAspx.Value, pstrKBN, strRec, Request.Form)
        '2012/04/04 NEC ou Upd
        If strRecLog <> "OK" Then
            Dim errmsgc As New CErrMsg
            strMsg.Append("alert('�V�X�e���G���[�F" & errmsgc.mgetartmsg(strRecLog) & "');")
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
        Dim SQLC As New MSTAJJAG00CCSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet

        strSQL.Append("SELECT ")
        If pintkbn = 0 Then
            '�����Ȃ̂őS�Ă̍��ڂ��擾���܂�
            strSQL.Append("TA.KBN, ")
            strSQL.Append("TA.KURACD, ")
            strSQL.Append("CL.CLI_NAME, ")
            strSQL.Append("TA.CODE, ")
            strSQL.Append("JA_NAME || JAS_NAME AS JAS_NAME, ")
            strSQL.Append("SH.KAISYA_NAME || KYOTEN_NAME AS KAISYA_NAME, ")
            strSQL.Append("KA.KANSI_NAME, ")
            strSQL.Append("LPAD(TA.TANCD,2,'0') AS TANCD, ")
            strSQL.Append("TA.TANNM, ")
            strSQL.Append("TA.RENTEL1, ")
            strSQL.Append("TA.RENTEL2, ")
            strSQL.Append("TA.RENTEL3, ")   ' 2013/05/23 T.Ono add
            strSQL.Append("TA.FAXNO, ")
            strSQL.Append("TA.DISP_NO, ")
            strSQL.Append("TA.BIKO, ")
            strSQL.Append("TA.ADD_DATE, ")
            strSQL.Append("TA.EDT_DATE, ")
            strSQL.Append("TA.TIME, ")
            strSQL.Append("TA.AUTO_MAIL, ") ' 2011/04/14 T.Watabe add
            strSQL.Append("TA.GUIDELINE, ") ' 2011/11/08 H.Uema add
            strSQL.Append("TA.FAXKURAKBN, ") ' 2011/11/29 H.Uema add
            strSQL.Append("TA.FAXKBN, ") ' 2011/12/01 H.Uema add
            strSQL.Append("TA.SPOT_MAIL, ") ' 2012/03/23 W.GANEKO add
            strSQL.Append("TA.MAIL_PASS, ") ' 2012/03/23 W.GANEKO add
            strSQL.Append("TA.AUTO_MAIL_PASS, ")   '����FAX�Y�ţ���߽ܰ�� 2013/05/23 T.Ono add
            strSQL.Append("TA.AUTO_FAXNO, ")       '����FAX�ԍ� 2013/05/23 T.Ono add
            strSQL.Append("TA.AUTO_KBN, ")         '�������M�敪 2013/05/23 T.Ono add
            strSQL.Append("TA.AUTO_ZERO_FLG, ")    '�[�������M�t���O 2013/05/23 T.Ono add
            strSQL.Append("TA.AUTO_FAXNM ")        '����FAX���M�� 2013/07/22 T.Ono add
        Else
            '�V�K�Ȃ̂őΏۃf�[�^�̃J�E���g���擾���܂�
            strSQL.Append("COUNT(*) AS CNT ")
        End If
        strSQL.Append("FROM  M05_TANTO TA, ")
        strSQL.Append("      CLIMAS CL, ")
        strSQL.Append("      HN2MAS JA, ")
        strSQL.Append("      KANSIMAS KA,")
        strSQL.Append("      SHUTUDOMAS SH ")
        strSQL.Append("WHERE TA.KBN   = :KBN ")
        strSQL.Append("  AND TA.KURACD  = :KURACD ")
        strSQL.Append("  AND TA.CODE  = :CODE ")
        strSQL.Append("  AND TA.KURACD = CL.CLI_CD(+) ")
        strSQL.Append("  AND TA.KURACD = JA.CLI_CD(+) ")
        strSQL.Append("  AND TA.CODE = JA.HAN_CD(+) ")
        strSQL.Append("  AND TA.CODE = KA.KANSI_CD(+) ")
        strSQL.Append("  AND TA.CODE = (SH.SHUTU_CD(+) || SH.KYOTEN_CD(+)) ")

        If pintkbn = 0 Then ' 2008/11/06 T.Watabe 
            'strSQL.Append(" ORDER BY TO_NUMBER(DISP_NO) ")
            strSQL.Append(" ORDER BY TO_NUMBER(TANCD) ")
        End If
        SqlParamC.fncSetParam("KBN", True, "3") 'hdnTANKBN.Value 1:�i�`�S���ҁ@2:�Ď��Z���^�[�S���ҁ@3:�o����ВS����
        If hdnCODE.Value.Length > 0 Then
            SqlParamC.fncSetParam("CODE", True, hdnCODE.Value)
        End If
        If hdnKURACD.Value.Length > 0 Then
            SqlParamC.fncSetParam("KURACD", True, hdnKURACD.Value)
        End If

        dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

        Return dbData
    End Function

    '������ 2013/05/23 T.Ono add �ڋq�P�ʓo�^�@�\�ǉ� fncDataSelect�����ɍ쐬������
    '******************************************************************************
    '* ���̓L�[�ɂ��f�[�^�̌������s���܂��B
    '* pintKbn�@0:�����{�^���������f�[�^�o��
    '*        �@1:�V�K�{�^���������f�[�^�J�E���g�o��
    '******************************************************************************
    Private Function fncDataSelect2(ByVal pintkbn As Integer) As DataSet

        'intKbn     0:�����{�^������
        'intKbn     1:�V�K�{�^������

        '//------------------------------------------
        '//<TODO>Select���̍쐬
        Dim SQLC As New MSTAJJAG00CCSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet

        strSQL.Append("SELECT ")
        '�����Ȃ̂őS�Ă̍��ڂ��擾���܂�
        strSQL.Append("TA.KBN, ")
        strSQL.Append("TA.KURACD, ")
        strSQL.Append("CL.CLI_NAME, ")
        strSQL.Append("TA.CODE, ")
        strSQL.Append("JA_NAME || JAS_NAME AS JAS_NAME, ")
        strSQL.Append("SH.KAISYA_NAME || KYOTEN_NAME AS KAISYA_NAME, ")
        strSQL.Append("KA.KANSI_NAME, ")
        strSQL.Append("TA.USER_CD_FROM, ")
        strSQL.Append("TA.USER_CD_TO, ")
        strSQL.Append("SM.NAME AS USER_NM, ")
        strSQL.Append("LPAD(TA.TANCD,2,'0') AS TANCD, ")
        strSQL.Append("TA.TANNM, ")
        strSQL.Append("TA.RENTEL1, ")
        strSQL.Append("TA.RENTEL2, ")
        strSQL.Append("TA.RENTEL3, ")
        strSQL.Append("TA.FAXNO, ")
        strSQL.Append("TA.DISP_NO, ")
        strSQL.Append("TA.BIKO, ")
        strSQL.Append("TA.ADD_DATE, ")
        strSQL.Append("TA.EDT_DATE, ")
        strSQL.Append("TA.TIME, ")
        strSQL.Append("TA.AUTO_MAIL, ")
        strSQL.Append("TA.GUIDELINE, ")
        strSQL.Append("TA.FAXKURAKBN, ")
        strSQL.Append("TA.FAXKBN, ")
        strSQL.Append("TA.SPOT_MAIL, ")
        strSQL.Append("TA.MAIL_PASS, ")
        strSQL.Append("TA.AUTO_MAIL_PASS, ")   '����FAX�Y�ţ���߽ܰ��
        strSQL.Append("TA.AUTO_FAXNO, ")       '����FAX�ԍ�
        strSQL.Append("TA.AUTO_KBN, ")         '�������M�敪
        strSQL.Append("TA.AUTO_ZERO_FLG, ")    '�[�������M�t���O
        strSQL.Append("TA.AUTO_FAXNM ")        '����FAX���M��
        strSQL.Append("FROM  M05_TANTO2 TA, ")
        strSQL.Append("      CLIMAS CL, ")
        strSQL.Append("      HN2MAS JA, ")
        strSQL.Append("      KANSIMAS KA,")
        strSQL.Append("      SHUTUDOMAS SH, ")
        strSQL.Append("      SHAMAS SM ")
        strSQL.Append("WHERE TA.KBN   = :KBN ")
        strSQL.Append("  AND TA.KURACD  = :KURACD ")
        strSQL.Append("  AND TA.CODE  = :CODE ")
        strSQL.Append("  AND TA.USER_CD_FROM  = :USER_CD_FROM ")
        If txtUSER_CD_TO.Text.Length > 0 Then
            strSQL.Append("  AND TA.USER_CD_TO  = :USER_CD_TO ")
        Else
            strSQL.Append("  AND TA.USER_CD_TO  Is Null ")
        End If
        strSQL.Append("  AND TA.KURACD = CL.CLI_CD(+) ")
        strSQL.Append("  AND TA.KURACD = JA.CLI_CD(+) ")
        strSQL.Append("  AND TA.CODE = JA.HAN_CD(+) ")
        strSQL.Append("  AND TA.CODE = KA.KANSI_CD(+) ")
        strSQL.Append("  AND TA.CODE = (SH.SHUTU_CD(+) || SH.KYOTEN_CD(+)) ")
        strSQL.Append("  AND TA.USER_CD_FROM = SM.USER_CD(+) ")
        strSQL.Append("  AND TA.KURACD = SM.CLI_CD(+) ")
        strSQL.Append("  AND TA.CODE = SM.HAN_CD(+) ")

        If pintkbn = 0 Then 
            strSQL.Append(" ORDER BY TO_NUMBER(TANCD) ")
        End If
        SqlParamC.fncSetParam("KBN", True, "3") '1:�Ď��Z���^�[�S���ҁ@2:�o����ВS���� 3:JA�x���S����
        If hdnCODE.Value.Length > 0 Then
            SqlParamC.fncSetParam("CODE", True, hdnCODE.Value)
        End If
        If hdnKURACD.Value.Length > 0 Then
            SqlParamC.fncSetParam("KURACD", True, hdnKURACD.Value)
        End If
        If txtUSER_CD_FROM.Text.Length > 0 Then
            SqlParamC.fncSetParam("USER_CD_FROM", True, txtUSER_CD_FROM.Text)
        End If
        If txtUSER_CD_TO.Text.Length > 0 Then
            SqlParamC.fncSetParam("USER_CD_TO", True, txtUSER_CD_TO.Text)
        End If

        dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

        Return dbData
    End Function

    ' 2013/05/27 T.Ono add
    Private Function fncUSERCD_Check() As DataSet
        '//<TODO>Select���̍쐬
        Dim SQLC As New MSTAJJAG00CCSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet

        strSQL.Append("SELECT ")
        strSQL.Append("USER_CD, ")
        strSQL.Append("NAME AS USER_NM ")
        strSQL.Append("FROM	SHAMAS ")
        strSQL.Append("WHERE CLI_CD  = :KURACD ")
        strSQL.Append("AND HAN_CD  = :CODE ")
        strSQL.Append("AND USER_CD  = :USER_CD ")

        If hdnCODE.Value.Length > 0 Then
            SqlParamC.fncSetParam("CODE", True, hdnCODE.Value)
        End If
        If hdnKURACD.Value.Length > 0 Then
            SqlParamC.fncSetParam("KURACD", True, hdnKURACD.Value)
        End If
        If txtUSER_CD_FROM.Text.Length > 0 Then
            SqlParamC.fncSetParam("USER_CD", True, txtUSER_CD_FROM.Text)
        End If

        dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)


        Return dbData
    End Function



    ' 2010/04/15 T.Watabe add
    '******************************************************************************
    '* �t�@�C���A�b�v���[�h����
    '******************************************************************************
    Private Sub btnFileUpload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFileUpload.Click
        Dim uploadFile As HttpPostedFile
        Dim sSaveFileName As String
        Dim sSaveFileNameR As String
        Dim sSaveFileNameR2 As String '�ꕔ�����ϊ���
        Dim sSaveFileExt As String
        Dim sSavePath As String
        Dim sSaveFileKey As String '�t�@�C���ۑ����ɓ��ɕt����L�[�i�ײ��ĺ��ށ{JA���ށj
        Dim skipF As Boolean = False
        Dim fs As String()

        Try
            uploadFile = Request.Files("FileUpload1")
            If (uploadFile.FileName <> "") Then

                '�t�@�C����������
                sSaveFileNameR = System.IO.Path.GetFileName(uploadFile.FileName)
                sSaveFileExt = System.IO.Path.GetExtension(uploadFile.FileName) '�g���q�擾���A�������֕ϊ�
                sSaveFileExt = sSaveFileExt.ToLower
                ' 2013/07/11 T.Ono mod
                'sSaveFileKey = hdnKURACD.Value & "_" & hdnCODE.Value & "_" '�N���C�A���g�R�[�h + JA�R�[�h
                If Trim(txtUSER_CD_FROM.Text) <> "" Then
                    sSaveFileKey = hdnKURACD.Value & "_" & hdnCODE.Value & "_" & Trim(txtUSER_CD_FROM.Text) & "_" '�N���C�A���g�R�[�h + JA�R�[�h + ���q�l�R�[�h
                Else
                    sSaveFileKey = hdnKURACD.Value & "_" & hdnCODE.Value & "_" & "X" & "_" '�N���C�A���g�R�[�h + JA�R�[�h + X ���q�l�R�[�h����Ƌ�ʂ��邽��"X"������
                End If
                sSaveFileNameR2 = sSaveFileNameR
                sSaveFileNameR2 = sSaveFileNameR2.Replace("_", "�Q") '�A���_�[�o�[�͋�؂蕶���Ƃ��Ďg�p����̂Œu������
                sSaveFileNameR2 = sSaveFileNameR2.Replace(" ", "") '���p�X�y�[�X�͏���
                sSaveFileName = sSaveFileKey & sSaveFileNameR2
                sSavePath = ConfigurationSettings.AppSettings("JA_TAN_MST_PATH")

                '�g���q�`�F�b�N
                'If sSaveFileExt = "lzh" Then           '2012/04/20 NEC ou Del
                If sSaveFileExt = ".lzh" Then           '2012/04/20 NEC ou Add
                    strMsg.Append("alert('�g���q��lzh�͓o�^�ł��܂���');")
                    strMsg.Append("Form1.btnSelect.focus();")
                    skipF = True
                    'ElseIf sSaveFileExt = "exe" Then   '2012/04/20 NEC ou Del
                ElseIf sSaveFileExt = ".exe" Then       '2012/04/20 NEC ou Add
                    strMsg.Append("alert('�g���q��exe�͓o�^�ł��܂���');")
                    strMsg.Append("Form1.btnSelect.focus();")
                    skipF = True
                End If

                '�d���t�@�C���`�F�b�N
                fs = System.IO.Directory.GetFiles(sSavePath, sSaveFileName)   'folder�ɂ���t�@�C�����擾����
                If fs.Length >= 1 Then '���Ƀt�@�C�����o�^����Ă���H
                    strMsg.Append("alert('���Ƀt�@�C�����o�^����Ă��܂��B[" & sSaveFileNameR & "]' );")
                    strMsg.Append("Form1.btnSelect.focus();")
                    skipF = True
                End If

                '�t�@�C������MAX�`�F�b�N
                fs = System.IO.Directory.GetFiles(sSavePath, sSaveFileKey & "*")   'folder�ɂ���t�@�C�����擾����
                If fs.Length >= 2 Then '���ɂQ�ȏ�t�@�C�����o�^����Ă���H
                    strMsg.Append("alert('����ȏ�o�^�ł��܂���B');")
                    strMsg.Append("Form1.btnSelect.focus();")
                    skipF = True
                End If

                If skipF = False Then
                    '�o�^

                    uploadFile.SaveAs(sSavePath + sSaveFileName) '�t�@�C���ۑ��I

                    fncSearchAndSetFileName12() '�t�@�C���������ĕ\��
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
        End Try
    End Sub
    ' 2010/04/15 T.Watabe add
    '******************************************************************************
    '* �t�@�C���폜����
    '******************************************************************************
    Private Sub btnFileDelete1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFileDelete1.Click

        Dim sSaveFileName As String   '���ۂ̌��t�@�C�����i�g���q����j  001_999_�e�X�g�t�@�C��.xls
        Dim sSaveFileNameR As String  '�_�E�����[�h��̃t�@�C����        �e�X�g�t�@�C��.xls
        Dim sSavePath As String       '���t�@�C���ۑ��t�H���_            D:\TEMP\SAVE\

        sSavePath = ConfigurationSettings.AppSettings("JA_TAN_MST_PATH")
        sSaveFileNameR = txtFileName1.Text.Trim '���t�@�C������
        'sSaveFileName = hdnKURACD.Value.Trim & "_" & hdnCODE.Value.Trim & "_" & sSaveFileNameR '�t�@�C�������A�ײ��ĺ��ށ{���ށ{�t�@�C�����ɕϊ�
        sSaveFileName = hdnFileKey.Text & sSaveFileNameR '�t�@�C�������A�ײ��ĺ��ށ{���ށ{�t�@�C�����ɕϊ�

        If fncFileDelete(sSavePath, sSaveFileName, sSaveFileNameR) Then '�����H
            fncSearchAndSetFileName12() '�t�@�C���������ĕ\��
        End If
    End Sub
    Private Sub btnFileDelete2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFileDelete2.Click

        Dim sSaveFileName As String   '���ۂ̌��t�@�C�����i�g���q����j  001_999_�e�X�g�t�@�C��.xls
        Dim sSaveFileNameR As String  '�_�E�����[�h��̃t�@�C����        �e�X�g�t�@�C��.xls
        Dim sSavePath As String       '���t�@�C���ۑ��t�H���_            D:\TEMP\SAVE\

        sSavePath = ConfigurationSettings.AppSettings("JA_TAN_MST_PATH")
        sSaveFileNameR = txtFileName2.Text.Trim '���t�@�C������
        'sSaveFileName = hdnKURACD.Value.Trim & "_" & hdnCODE.Value.Trim & "_" & sSaveFileNameR '�t�@�C�������A�ײ��ĺ��ށ{���ށ{�t�@�C�����ɕϊ�
        sSaveFileName = hdnFileKey.Text & sSaveFileNameR '�t�@�C�������A�ײ��ĺ��ށ{���ށ{�t�@�C�����ɕϊ�

        If fncFileDelete(sSavePath, sSaveFileName, sSaveFileNameR) Then '�����H
            fncSearchAndSetFileName12() '�t�@�C���������ĕ\��
        End If
    End Sub
    Private Function fncFileDelete(ByVal sSavePath As String, ByVal sSaveFileName As String, ByVal sSaveFileNameR As String) As Boolean
        Dim skipF As Boolean = False
        Dim res As Boolean = False
        Try
            '�t�@�C�����݃`�F�b�N
            'If sSaveFileName.Length <= 0 Then '�t�@�C�����݂��Ȃ��H              '2012/04/20 NEC ou Del
            If sSaveFileNameR.Length <= 0 Then '�t�@�C�����݂��Ȃ��H              '2012/04/20 NEC ou Add
                strMsg.Append("alert('�t�@�C�����w�肵�ĉ������B');")
                strMsg.Append("Form1.btnSelect.focus();")
                skipF = True
            End If

            If skipF = False Then
                System.IO.File.Delete(sSavePath & sSaveFileName) '�폜���s�I
                res = True
            End If
        Catch ex As Exception
            Throw ex
        Finally
        End Try
        Return res
    End Function

    ' 2010/04/15 T.Watabe add
    '******************************************************************************
    '* �t�@�C���_�E�����[�h����
    '******************************************************************************
    'Private Sub btnFileDownload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFileDownload.ServerClick
    'Private Sub btnFileDownload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFileDownload.Click

    '    Dim sw As System.IO.Stream = Nothing
    '    Dim bw As System.IO.BinaryWriter = Nothing
    '    Dim dt As Byte()
    '    Dim fpath As String
    '    Dim sSaveFileName As String

    '    Try
    '        'sSaveFileName = "test.txt"
    '        'sSaveFileName = "test.gif"
    '        sSaveFileName = "test.xls"

    '        fpath = ConfigurationSettings.AppSettings("JA_TAN_MST_PATH") & sSaveFileName

    '        'sw = System.IO.File.Open(fpath, System.IO.FileMode.Create, System.IO.FileAccess.Write) 'Stream�Ńt�@�C�����J��
    '        'bw = New System.IO.BinaryWriter(sw) 'Stream��BinaryWriter�N���X�ŊJ��
    '        'bw.Write(dt) 'BinaryWriter�N���X���o�C�g�z��֏����o��

    '        'HttpHeaderC.mDownLoad(Response, "test.txt")
    '        'Response.BinaryWrite(dt) '�o�C�g�z������X�|���X�֏o��
    '        'Response.Flush()


    '        'Dim fs As New System.IO.FileStream(fpath, System.IO.FileMode.Open, System.IO.FileAccess.Read)
    '        ''If fs.Length > 0 Then
    '        'Dim br As New System.IO.BinaryReader(fs)
    '        '' Read data from Test.data.
    '        'dt = br.ReadBytes(CInt(fs.Length) - 1)
    '        'HttpHeaderC.mDownLoad(Response, "test.txt")
    '        'Response.BinaryWrite(dt) '�o�C�g�z������X�|���X�֏o��
    '        'Response.Flush()
    '        'br.Close()
    '        ''End If
    '        'fs.Close()
    '        'Response.End()

    '        'Response.ContentType = "application/octet-stream-dummy"
    '        'Response.WriteFile(fpath)
    '        'Response.End()
    '        'Response.ContentType = "image/gif"

    '        If System.IO.File.Exists(fpath) Then
    '            Response.Clear()
    '            HttpHeaderC.mDownLoad(Response, sSaveFileName)
    '            Response.AddHeader("Content-Disposition", "inline;filename=" & sSaveFileName)
    '            Response.ContentType = "application/octet-stream-dummy"
    '            Response.WriteFile(fpath)
    '            Response.End()
    '        Else
    '            strMsg.Append("alert('" & "�Ώۃf�[�^�����݂��܂���" & "');")
    '            strMsg.Append("Form1.btnSelect.focus();")
    '        End If

    '        'Catch ex As Exception
    '        '    Throw ex
    '    Finally
    '        If bw Is Nothing = False Then bw.Close()
    '        If sw Is Nothing = False Then sw.Close()
    '    End Try
    'End Sub

    ' 2010/04/15 T.Watabe add
    '******************************************************************************
    '* �t�@�C���_�E�����[�h����
    '******************************************************************************
    'Private Sub btnFileDownload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFileDownload.ServerClick
    Private Sub btnFileDownload1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFileDownload1.Click

        Dim sSaveFileName As String   '���ۂ̌��t�@�C�����i�g���q����j  001_999_�e�X�g�t�@�C��.xls
        Dim sSaveFileNameR As String  '�_�E�����[�h��̃t�@�C����        �e�X�g�t�@�C��.xls
        Dim sSavePath As String       '���t�@�C���ۑ��t�H���_            D:\TEMP\SAVE\
        Try
            sSavePath = ConfigurationSettings.AppSettings("JA_TAN_MST_PATH")
            sSaveFileNameR = txtFileName1.Text.Trim '���t�@�C������
            'sSaveFileName = hdnKURACD.Value.Trim & "_" & hdnCODE.Value.Trim & "_" & sSaveFileNameR '�t�@�C�������A�ײ��ĺ��ށ{���ށ{�t�@�C�����ɕϊ�
            sSaveFileName = hdnFileKey.Text & sSaveFileNameR '�t�@�C�������A�ײ��ĺ��ށ{���ށ{�t�@�C�����ɕϊ�

            fncFileDownload(sSavePath, sSaveFileName, sSaveFileNameR)
        Catch ex As Exception
            Throw ex
        Finally
        End Try
    End Sub
    Private Sub btnFileDownload2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFileDownload2.Click

        Dim sSaveFileName As String   '���ۂ̌��t�@�C�����i�g���q����j  001_999_�e�X�g�t�@�C��.xls
        Dim sSaveFileNameR As String  '�_�E�����[�h��̃t�@�C����        �e�X�g�t�@�C��.xls
        Dim sSavePath As String       '���t�@�C���ۑ��t�H���_            D:\TEMP\SAVE\
        Try
            sSavePath = ConfigurationSettings.AppSettings("JA_TAN_MST_PATH")
            sSaveFileNameR = txtFileName2.Text.Trim '���t�@�C������
            'sSaveFileName = hdnKURACD.Value.Trim & "_" & hdnCODE.Value.Trim & "_" & sSaveFileNameR '�t�@�C�������A�ײ��ĺ��ށ{���ށ{�t�@�C�����ɕϊ�
            sSaveFileName = hdnFileKey.Text & sSaveFileNameR '�t�@�C�������A�ײ��ĺ��ށ{���ށ{�t�@�C�����ɕϊ�

            fncFileDownload(sSavePath, sSaveFileName, sSaveFileNameR)
        Catch ex As Exception
            Throw ex
        Finally
        End Try
    End Sub

    Private Function fncFileDownload(ByVal sSavePath As String, ByVal sSaveFileName As String, ByVal sSaveFileNameR As String) As String

        'Dim sw As System.IO.Stream = Nothing
        'Dim bw As System.IO.BinaryWriter = Nothing
        Dim dt As Byte()
        Dim sSaveFileNameS As String  '���ۂ̌��t�@�C�����i�g���q�Ȃ��j  001_999_�e�X�g�t�@�C��
        Dim fpath As String           '���t�@�C���܂ł̃t���p�X          D:\TEMP\SAVE\001_999_�e�X�g�t�@�C��.xls
        'Dim sSavePath As String       '���t�@�C���ۑ��t�H���_            D:\TEMP\SAVE\
        'Dim sSaveFileName As String   '���ۂ̌��t�@�C�����i�g���q����j  001_999_�e�X�g�t�@�C��.xls
        'Dim sSaveFileNameR As String  '�_�E�����[�h��̃t�@�C����        �e�X�g�t�@�C��.xls

        Dim tmp As String

        Try
            'Dim buf As String
            ' Dim searchPattern As String

            'sSavePath = ConfigurationSettings.AppSettings("JA_TAN_MST_PATH")
            'sSaveFileNameR = txtFileName1.Text
            'sSaveFileName = hdnKURACD.Value.Trim & "_" & hdnCODE.Value.Trim & "_" & sSaveFileNameR
            If sSaveFileName.IndexOf(".") > 0 Then '�g���q����H
                sSaveFileNameS = sSaveFileName.Substring(0, sSaveFileName.LastIndexOf("."))
            Else
                sSaveFileNameS = sSaveFileName
            End If
            Dim fs As String() = System.IO.Directory.GetFiles(sSavePath, sSaveFileName)  'folder�ɂ���t�@�C�����擾����
            If fs.Length > 0 Then
                fpath = fs(0)
            End If


            If System.IO.File.Exists(fpath) Then
                Response.Clear()

                Dim FileToStrC As New CFileStr                  '�t�@�C����Base64�ɃG���R�[�h����N���X
                Dim compressC As New CCompress                  '���k�N���X
                '���k��t�@�C���̂���t�H���_
                compressC.p_Dir = sSavePath
                '���{��t�@�C�����̎w��
                compressC.p_NihongoFileName = sSaveFileNameR
                '���k���t�@�C����
                compressC.p_FileName = sSavePath & sSaveFileName
                '���k��t�@�C����
                compressC.p_madeFilename = sSavePath & sSaveFileNameS & ".lzh"
                '���k���s
                compressC.mCompress()
                putlog("MSTAJJAG00 - " & compressC.p_madeFilename)
                If System.IO.File.Exists(compressC.p_madeFilename) Then '���k�����t�@�C�������݂���H

                    '���k�����t�@�C����Base64�G���R�[�h���Ė߂�
                    Dim strRec As String = FileToStrC.mFileToStr(compressC.p_madeFilename.Replace(".lzh", ".exe"))

                    dt = Convert.FromBase64String(strRec) 'Web�T�[�r�X�̖߂�l�iBASE64�̃e�L�X�g�j���o�C�g�f�[�^�ɕϊ�����
                    HttpHeaderC.mDownLoad(Response, sSaveFileNameS & ".exe") '�t�@�C�����́AHttpUtility.UrlEncode���\�b�h���g�p����SJIS�ɃG���R�[�h����K�v������
                    Response.BinaryWrite(dt) '�t�@�C�����M
                    Response.Flush() '���X�|���X��S�ēf���o���I

                    '���k�t�@�C���͕s�v�Ȃ̂ō폜�I
                    System.IO.File.Delete(sSavePath & sSaveFileNameS & ".lzh")
                    System.IO.File.Delete(sSavePath & sSaveFileNameS & ".exe")

                Else
                    tmp = "alert('"
                    tmp += "�Ώۃf�[�^�����݂��܂���B\n\n"
                    tmp += "[" & compressC.p_Dir.Replace("\", "\\") & "]\n"
                    tmp += "[" & compressC.p_NihongoFileName.Replace("\", "\\") & "]\n"
                    tmp += "[" & compressC.p_FileName.Replace("\", "\\") & "]\n"
                    tmp += "[" & compressC.p_madeFilename.Replace("\", "\\") & "]"
                    tmp += "');"
                    strMsg.Append(tmp)
                    strMsg.Append("Form1.btnSelect.focus();")
                End If

                'Dim strRec As String = FileToStrC.mFileToStr(sSavePath & sSaveFileNameS & ".xls")
                'dt = Convert.FromBase64String(strRec) 'Web�T�[�r�X�̖߂�l�iBASE64�̃e�L�X�g�j���o�C�g�f�[�^�ɕϊ�����
                'HttpHeaderC.mDownLoad(Response, sSaveFileNameS & ".xls") '�t�@�C�����́AHttpUtility.UrlEncode���\�b�h���g�p����SJIS�ɃG���R�[�h����K�v������
                'Response.BinaryWrite(dt) '�t�@�C�����M
                'Response.End()

            Else
                strMsg.Append("alert('" & "�Ώۃf�[�^�����݂��܂���" & "');")
                strMsg.Append("Form1.btnSelect.focus();")
            End If

            'Catch ex As Exception
            '    Throw ex
        Finally
            'If bw Is Nothing = False Then bw.Close()
            'If sw Is Nothing = False Then sw.Close()
        End Try
    End Function
    '-------------------------------------------------
    ' �t�@�C�����ĕ\���i�t�@�C�������擾���ăZ�b�g�j
    '-------------------------------------------------
    Private Sub fncSearchAndSetFileName12()
        Dim folder As String
        Dim buf As String
        Dim searchPattern As String

        '������
        hdnFileKey.Text = ""
        txtFileName1.Text = ""
        txtFileName2.Text = ""

        folder = ConfigurationSettings.AppSettings("JA_TAN_MST_PATH")
        '2013/07/11 T.Ono add
        'searchPattern = hdnKURACD.Value.Trim & "_" & hdnCODE.Value.Trim & "_"
        If Trim(txtUSER_CD_FROM.Text) <> "" Then
            searchPattern = hdnKURACD.Value.Trim & "_" & hdnCODE.Value.Trim & "_" & Trim(txtUSER_CD_FROM.Text) & "_"
        Else
            searchPattern = hdnKURACD.Value.Trim & "_" & hdnCODE.Value.Trim & "_" & "X" & "_"
        End If
        Dim fs As String() = System.IO.Directory.GetFiles(folder, searchPattern & "*") 'folder�ɂ���t�@�C�����擾����
        If fs.Length > 0 Then
            buf = fs(0).Substring(fs(0).LastIndexOf("\") + 1)
            txtFileName1.Text = buf.Substring(searchPattern.Length)

            hdnFileKey.Text = searchPattern '�L�[��ێ�
        End If
        If fs.Length > 1 Then
            buf = fs(1).Substring(fs(1).LastIndexOf("\") + 1)
            txtFileName2.Text = buf.Substring(searchPattern.Length)
        End If

        '2012/05/25 NEC ou Add Str
        Call fncIni_stateaf()
        '2012/05/25 NEC ou Add End
    End Sub

    Public Sub putlog(ByVal strMsg As String)
        Dim textFile As System.IO.StreamWriter
        Dim folder As String = ConfigurationSettings.AppSettings("JA_TAN_MST_PATH")
        textFile = New System.IO.StreamWriter(folder & "COASYUKE00.log", True, System.Text.Encoding.Default)
        textFile.WriteLine(strMsg)
        textFile.Close()
    End Sub

    Private Sub checkedRadio(ByVal rdo As HtmlInputRadioButton)

        If rdo Is rdoFAXJA1 Then
            rdoFAXJA1.Checked = True
            rdoFAXJA2.Checked = False
            rdoFAXJA3.Checked = False
        ElseIf rdo Is rdoFAXJA2 Then
            rdoFAXJA1.Checked = False
            rdoFAXJA2.Checked = True
            rdoFAXJA3.Checked = False
        ElseIf rdo Is rdoFAXJA3 Then
            rdoFAXJA1.Checked = False
            rdoFAXJA2.Checked = False
            rdoFAXJA3.Checked = True
        End If

        If rdo Is rdoFAXKURA1 Then
            rdoFAXKURA1.Checked = True
            rdoFAXKURA2.Checked = False
            rdoFAXKURA3.Checked = False
        ElseIf rdo Is rdoFAXKURA2 Then
            rdoFAXKURA1.Checked = False
            rdoFAXKURA2.Checked = True
            rdoFAXKURA3.Checked = False
        ElseIf rdo Is rdoFAXKURA3 Then
            rdoFAXKURA1.Checked = False
            rdoFAXKURA2.Checked = False
            rdoFAXKURA3.Checked = True
        End If
    End Sub

    '**************************************************
    '* �������M�敪�R���{�{�b�N�X�Z�b�g
    '* 2013/07/04 T.Ono add
    '**************************************************
    Private Sub fncCombo_Create_AUTOKBN()
        For i As Integer = 1 To 30
            Dim objAUTO_KBN As JPG.Common.Controls.CTLCombo
            objAUTO_KBN = CType(FindControl("cboAUTO_KBN_" & CStr(i)), JPG.Common.Controls.CTLCombo)
            objAUTO_KBN.Items.Clear()
            objAUTO_KBN.Items.Add(New ListItem("", ""))
            objAUTO_KBN.Items.Add(New ListItem("0:���M�Ȃ�", "0"))
            objAUTO_KBN.Items.Add(New ListItem("1:FAX���M", "1"))
            objAUTO_KBN.Items.Add(New ListItem("2:���[�����M", "2"))
            objAUTO_KBN.Items.Add(New ListItem("3:FAX�����[�����M", "3"))
        Next
    End Sub

    '**************************************************
    '* �[�������M�t���O�R���{�{�b�N�X�Z�b�g
    '* 2013/07/04 T.Ono add
    '**************************************************
    Private Sub fncCombo_Create_AUTOZEROFLG()
        For i As Integer = 1 To 30
            Dim objAUTO_ZERO_FLG As JPG.Common.Controls.CTLCombo
            objAUTO_ZERO_FLG = CType(FindControl("cboAUTO_ZERO_FLG_" & CStr(i)), JPG.Common.Controls.CTLCombo)
            objAUTO_ZERO_FLG.Items.Clear()
            objAUTO_ZERO_FLG.Items.Add(New ListItem("", ""))
            objAUTO_ZERO_FLG.Items.Add(New ListItem("0:���M�Ȃ�", "0"))
            objAUTO_ZERO_FLG.Items.Add(New ListItem("1:���M����", "1"))
        Next
    End Sub

    '**************************************************
    '* �R���{�{�b�N�X�̑I��
    '* 2013/07/04 T.Ono add
    '**************************************************
    Private Sub fncCombo_Select(ByVal obj As JPG.Common.Controls.CTLCombo, ByVal str As String)
        Dim list As New ListItem
        If str <> "" Then
            list = obj.Items.FindByValue(str)
            obj.SelectedIndex = obj.Items.IndexOf(list)
        End If
    End Sub

    '**************************************************
    '* �R���{�{�b�N�X�̓��͒l�擾
    '* 2013/07/04 T.Ono add
    '**************************************************
    Private Sub fncCombo_Get(ByRef sAUTO_KBN() As String, ByRef sAUTO_ZERO_FLG() As String)
        Dim objAUTO_KBN As JPG.Common.Controls.CTLCombo
        Dim objAUTO_ZERO_FLG As JPG.Common.Controls.CTLCombo

        For i As Integer = 1 To 30
            objAUTO_KBN = CType(FindControl("cboAUTO_KBN_" & CStr(i)), JPG.Common.Controls.CTLCombo)
            objAUTO_ZERO_FLG = CType(FindControl("cboAUTO_ZERO_FLG_" & CStr(i)), JPG.Common.Controls.CTLCombo)
            sAUTO_KBN(i) = Request.Form(objAUTO_KBN.ID)
            sAUTO_ZERO_FLG(i) = Request.Form(objAUTO_ZERO_FLG.ID)
        Next
    End Sub
End Class
