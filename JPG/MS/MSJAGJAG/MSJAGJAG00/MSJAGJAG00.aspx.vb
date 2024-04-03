'***********************************************
' JA�O���[�v�쐬�}�X�^  ���C�����
'***********************************************
' �ύX����

Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common
Imports JPG.Common.log

Imports System.Text

Partial Class MSJAGJAG00
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

        '.NET�̎d�l�ύX�ɂ��AReadOnly������ASPX�ł���ƁA�T�[�o���Œl�̎Q�Ƃ��ł��Ȃ��Ȃ邽�߁AVB����Attribute�ł���
        If MyBase.IsPostBack = False Then
            txtKURACD.Attributes.Add("ReadOnly", "true")
            txtACBCD_F.Attributes.Add("ReadOnly", "true")
            txtACBCD_T.Attributes.Add("ReadOnly", "true")
            txtGROUPCD.Attributes.Add("ReadOnly", "true")
            Dim objDefNO As System.Web.UI.WebControls.TextBox
            Dim objDefTARGET As System.Web.UI.WebControls.CheckBox
            Dim objDefACBCD As System.Web.UI.WebControls.TextBox
            Dim objDefGROUPCD As System.Web.UI.WebControls.TextBox
            Dim objDefINS_DATE As System.Web.UI.WebControls.TextBox
            Dim objDefINS_USER As System.Web.UI.WebControls.TextBox
            Dim objDefUPD_DATE As System.Web.UI.WebControls.TextBox
            Dim objDefUPD_USER As System.Web.UI.WebControls.TextBox
            Dim i As Integer
            For i = 1 To 100
                objDefNO = CType(FindControl("txtNO_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                objDefTARGET = CType(FindControl("chkTARGET_" & CStr(i)), System.Web.UI.WebControls.CheckBox)
                objDefACBCD = CType(FindControl("txtACBCD_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                objDefGROUPCD = CType(FindControl("txtGROUPCD_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                objDefINS_DATE = CType(FindControl("txtINS_DATE_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                objDefINS_USER = CType(FindControl("txtINS_USER_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                objDefUPD_DATE = CType(FindControl("txtUPD_DATE_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                objDefUPD_USER = CType(FindControl("txtUPD_USER_" & CStr(i)), System.Web.UI.WebControls.TextBox)

                objDefNO.Attributes.Add("ReadOnly", "true")
                objDefTARGET.Checked = True
                objDefACBCD.Attributes.Add("ReadOnly", "true")
                objDefGROUPCD.Attributes.Add("ReadOnly", "true")
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
        '[JA�O���[�v�쐬�}�X�^]�g�p�\����(�^:��/�c:��/��:��/�o:�~)
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
             MyBase.MapPath("../../../MS/MSJAGJAG/MSJAGJAG00/") & "MSJAGJAG00.js"))
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

            '//--------------------------------------
            '�O���[�v�R�[�h(�V�K�o�^�p)����͕s�ɂ��邽�߂̃t���O�@0:���͉@1:���͕s��
            hdnReadOnlyFlg.Value = "0"
        Else
            '//--------------------------------------
            '//�@�Q��ڈȍ~���s�����
            '//--------------------------------------

            '�敪�R���{�{�b�N�X�̍Đݒ�
            Call fncCombo_Create_JAGKBN()
            cboJAGKBN.SelectedValue = Request.Form("cboJAGKBN")
            hdnJAGKBN.Value = Request.Form("cboJAGKBN")

            ''2017/02/09 W.Ganeko 2016�Ď����P ��10 start
            If hdnJAGKBN.Value = "003" Then
                Dim objUSERCD_F As System.Web.UI.WebControls.TextBox
                Dim objUSERCD_T As System.Web.UI.WebControls.TextBox
                Dim i As Integer
                For i = 1 To 100
                    objUSERCD_F = CType(FindControl("txtUSERCD_F_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                    objUSERCD_T = CType(FindControl("txtUSERCD_T_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                    objUSERCD_F.Attributes.Add("ReadOnly", "true")
                    objUSERCD_T.Attributes.Add("ReadOnly", "true")
                    objUSERCD_F.BackColor = Color.Gainsboro
                    objUSERCD_T.BackColor = Color.Gainsboro
                Next
            End If
            ''2017/02/09 W.Ganeko 2016�Ď����P ��10 end

            If hdnReadOnlyFlg.Value = "1" Then
                '�O���[�v�R�[�h(�V�K�o�^�p)�͓��͕s�ɂ���
                txtGROUPCD_NEW.Attributes.Add("ReadOnly", "true")
                txtGROUPCD_NEW.BackColor = Color.Gainsboro
            End If
        End If


        '<TODO>�����̉��ID��HIDDEN��hdnMyAspx�ɏ������ށi�V�X�e�����ʁj
        hdnMyAspx.Value = "MSJAGJAG00"
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
        btnGROUPCD.Disabled = False

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
        txtGROUPCD.Attributes.Add("ReadOnly", "true")
        Dim objNO As System.Web.UI.WebControls.TextBox
        Dim objTARGET As System.Web.UI.WebControls.CheckBox
        Dim objACBCD As System.Web.UI.WebControls.TextBox
        Dim objGROUPCD As System.Web.UI.WebControls.TextBox
        Dim objINS_DATE As System.Web.UI.WebControls.TextBox
        Dim objINS_USER As System.Web.UI.WebControls.TextBox
        Dim objUPD_DATE As System.Web.UI.WebControls.TextBox
        Dim objUPD_USER As System.Web.UI.WebControls.TextBox
        Dim i As Integer
        For i = 1 To 100
            objNO = CType(FindControl("txtNO_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objTARGET = CType(FindControl("chkTARGET_" & CStr(i)), System.Web.UI.WebControls.CheckBox)
            objACBCD = CType(FindControl("txtACBCD_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objGROUPCD = CType(FindControl("txtGROUPCD_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objINS_DATE = CType(FindControl("txtINS_DATE_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objINS_USER = CType(FindControl("txtINS_USER_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objUPD_DATE = CType(FindControl("txtUPD_DATE_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objUPD_USER = CType(FindControl("txtUPD_USER_" & CStr(i)), System.Web.UI.WebControls.TextBox)

            objNO.Attributes.Add("ReadOnly", "true")
            objTARGET.Checked = True
            objACBCD.Attributes.Add("ReadOnly", "true")
            objGROUPCD.Attributes.Add("ReadOnly", "true")
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

        ''��������
        '�敪
        fncCombo_Create_JAGKBN()
        hdnJAGKBN.Value = ""
        '�N���C�A���g�R�[�h
        txtKURACD.Text = ""
        hdnKURACD.Value = ""
        'JA�x���R�[�h
        txtACBCD_F.Text = ""
        hdnACBCD_F.Value = ""
        txtACBCD_T.Text = ""
        hdnACBCD_T.Value = ""
        '�O���[�v�R�[�h
        txtGROUPCD.Text = ""
        hdnGROUPCD.Value = ""
        '�o��
        chkSYU_TOUROKU.Checked = True
        chkSYU_MITOUROKU.Checked = True

        ''�O���[�v�V�K�o�^
        txtGROUPCD_NEW.Text = ""
        txtGROUPNM_NEW.Text = ""
        hdnINS_DATE_NEW.Value = ""
        hdnINS_USER_NEW.Value = ""
        hdnUPD_DATE_NEW.Value = ""
        hdnUPD_USER_NEW.Value = ""


        '�L�[�ȊO�̒l������������
        Call fncIni_notkey()

    End Sub

    '******************************************************************************
    '* �L�[�ȊO�̒l������������
    '******************************************************************************
    Private Sub fncIni_notkey()
        '//--------------------------------------------------------------------------
        '<TODO>�R���g���[���̒l������������

        hdnJAGKBN_MOTO.Value = ""
        hdnKURACD_MOTO.Value = ""
        hdnACBCD_F_MOTO.Value = ""
        hdnACBCD_T_MOTO.Value = ""
        hdnGROUPCD_MOTO.Value = ""

        Dim objTARGET As System.Web.UI.WebControls.CheckBox
        Dim objKURACD As System.Web.UI.WebControls.TextBox
        Dim objACBCD As System.Web.UI.WebControls.TextBox
        Dim objhdnACBCD As System.Web.UI.HtmlControls.HtmlInputHidden
        Dim objGROUPCD As System.Web.UI.WebControls.TextBox
        Dim objhdnGROUPCD As System.Web.UI.HtmlControls.HtmlInputHidden
        Dim objUSERCD_F As System.Web.UI.WebControls.TextBox
        Dim objUSERCD_T As System.Web.UI.WebControls.TextBox
        Dim objBIKO As System.Web.UI.WebControls.TextBox
        Dim objINS_DATE As System.Web.UI.WebControls.TextBox
        Dim objINS_USER As System.Web.UI.WebControls.TextBox
        Dim objUPD_DATE As System.Web.UI.WebControls.TextBox
        Dim objUPD_USER As System.Web.UI.WebControls.TextBox

        Dim i As Integer
        For i = 1 To 100
            objTARGET = CType(FindControl("chkTARGET_" & CStr(i)), System.Web.UI.WebControls.CheckBox)
            objKURACD = CType(FindControl("txtKURACD_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objACBCD = CType(FindControl("txtACBCD_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objhdnACBCD = CType(FindControl("hdnACBCD_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
            objGROUPCD = CType(FindControl("txtGROUPCD_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objhdnGROUPCD = CType(FindControl("hdnGROUPCD_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
            objUSERCD_F = CType(FindControl("txtUSERCD_F_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objUSERCD_T = CType(FindControl("txtUSERCD_T_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objBIKO = CType(FindControl("txtBIKO_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objINS_DATE = CType(FindControl("txtINS_DATE_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objINS_USER = CType(FindControl("txtINS_USER_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objUPD_DATE = CType(FindControl("txtUPD_DATE_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objUPD_USER = CType(FindControl("txtUPD_USER_" & CStr(i)), System.Web.UI.WebControls.TextBox)


            objTARGET.Checked = True
            objKURACD.Text = ""
            objACBCD.Text = ""
            objhdnACBCD.Value = ""
            objGROUPCD.Text = ""
            objhdnGROUPCD.Value = ""
            objUSERCD_F.Text = ""
            objUSERCD_T.Text = ""
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

        hdnReadOnlyFlg.Value = "0" '//�O���[�v�R�[�h(�V�K�o�^�p)����͉ɂ���
        '//------------------------------------------
        '<TODO>�t�H�[�J�X���Z�b�g����i������ʂɖ߂����̂�(PageLoad���l)�L�[�ɃZ�b�g�j
        strMsg.Append("Form1.btnSelect.focus();")
        Call fncIni_stateaf()
    End Sub

    '******************************************************************************
    '* �ꊇ�o�^�{�^�����������ꂽ�Ƃ��̏���
    '******************************************************************************
    Private Sub btnIKKATU_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIKKATU.ServerClick
        Dim strRec As String
        strRec = fncbtnIKKATU_ClickEvent(hdnKBN.Value)

        Call fncIni_stateaf()
    End Sub

    '******************************************************************************
    ' �f�[�^�o�̓{�^�����������ꂽ�Ƃ��̏����@Excel�o��(�`�F�b�N��)
    '******************************************************************************
    Private Sub btnCSVOUT_ServerClick(ByVal sender As System.Object, _
                                    ByVal e As System.EventArgs) Handles btnCSVOUT.ServerClick
        Dim strRec As String
        Dim MSJAGJAG00C As New MSJAGJAG00MSJAGJAW00.MSJAGJAW00

        '//�@�F�؃N���X�̃C���X�^���X����
        'AuthC = New CAuthenticate(Request, Response)

        Dim strRecMsg As String = ""

        strRec = MSJAGJAG00C.mCSV( _
                        Me.Session.SessionID, _
                        AuthC.pAUTHCENTERCD, _
                        hdnJAGKBN.Value.Trim, _
                        hdnKURACD.Value.Trim, _
                        hdnACBCD_F.Value.Trim, _
                        hdnACBCD_T.Value.Trim, _
                        hdnGROUPCD.Value.Trim, _
                        chkSYU_TOUROKU.Checked, _
                        chkSYU_MITOUROKU.Checked _
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
            HttpHeaderC.mDownLoadCSV(Response, "JA�O���[�v�쐬�}�X�^.csv")
            Response.WriteFile(strRec)
            Response.End()

            strRecMsg = "OK"
        End If

        strRec = strRecMsg
        '-------------------------------------------------
        '//�`�o���O��������
        Dim LogC As New CLog
        Dim strRecLog As String
        strRecLog = LogC.mAPLog(Me.Session.SessionID, AuthC.pUSERNAME, AuthC.pIPADDRESS, hdnMyAspx.Value, "5", strRec, Request.Form)
        If strRecLog <> "OK" Then
            Dim errmsgc As New CErrMsg
            strMsg.Append("alert('�V�X�e���G���[�F" & errmsgc.mGetArtMsg(strRecLog) & "');")
        End If
    End Sub

    '******************************************************************************
    '* �O���[�v�ǉ��{�^�����������ꂽ�Ƃ��̏���
    '******************************************************************************
    Private Sub btnGROUP_ADD_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGROUP_ADD.ServerClick

        Dim strRec As String

        hdnINS_DATE_NEW.Value = ""
        hdnINS_USER_NEW.Value = ""
        hdnUPD_DATE_NEW.Value = ""
        hdnUPD_USER_NEW.Value = ""

        strRec = fncbtnGROUP_ADD_ClickEvent(hdnKBN.Value)

        Call fncIni_notkey()
        Call fncIni_stateaf()
    End Sub

    '******************************************************************************
    '* �O���[�v�R�[�h�������{�^�����������ꂽ�Ƃ��̏���
    '******************************************************************************
    Private Sub btnGROUP_SEARCH_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGROUP_SEARCH.ServerClick

        Dim strRecMsg As String = ""

        '//------------------------------------------
        '//<TODO>Select���̍쐬
        Dim SQLC As New MSJAGJAG00CCSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet

        If hdnJAGKBN.Value.Trim = "001" Then
            strSQL.Append("SELECT ")
            strSQL.Append("     GROUPCD ")
            strSQL.Append("     ,GROUPNM ")
            strSQL.Append("     ,TO_CHAR(INS_DATE, 'YYYY/MM/DD HH24:MI:SS') AS INS_DATE ")
            strSQL.Append("     ,INS_USER ")
            strSQL.Append("     ,TO_CHAR(UPD_DATE, 'YYYY/MM/DD HH24:MI:SS') AS UPD_DATE ")
            strSQL.Append("     ,UPD_USER ")
            strSQL.Append("FROM ")
            strSQL.Append("     M10_HANJIGYOSYA ")
            strSQL.Append("WHERE ")
            strSQL.Append("     GROUPCD = :GROUPCD ")
        ElseIf hdnJAGKBN.Value.Trim = "002" Then
            'JA�S���ҁE�񍐐�E���ӎ����}�X�^�@2015/12/10 T.Ono add 2015���P�J�� ��7
            strSQL.Append("SELECT  ")
            strSQL.Append("     GROUPCD  ")
            strSQL.Append("     ,GROUPNM  ")
            strSQL.Append("     ,TO_CHAR(INS_DATE, 'YYYY/MM/DD HH24:MI:SS') AS INS_DATE  ")
            strSQL.Append("     ,INS_USER  ")
            strSQL.Append("     ,TO_CHAR(UPD_DATE, 'YYYY/MM/DD HH24:MI:SS') AS UPD_DATE  ")
            strSQL.Append("     ,UPD_USER  ")
            strSQL.Append("FROM  ")
            strSQL.Append("     M11_JAHOKOKU  ")
            strSQL.Append("WHERE  ")
            strSQL.Append("     GROUPCD = :GROUPCD ")
            strSQL.Append("AND  LPAD(TANCD, 2, '0') = '01' ")
        ElseIf hdnJAGKBN.Value.Trim = "003" Then
            '�����Ή��}�X�^�@2017/02/09 W.GANEKO add 2016���P�J�� ��10
            strSQL.Append("SELECT  ")
            strSQL.Append("     GROUPCD  ")
            strSQL.Append("     ,GROUPNM  ")
            strSQL.Append("     ,TO_CHAR(INS_DATE, 'YYYY/MM/DD HH24:MI:SS') AS INS_DATE  ")
            strSQL.Append("     ,'' AS INS_USER  ")
            strSQL.Append("     ,TO_CHAR(UPD_DATE, 'YYYY/MM/DD HH24:MI:SS') AS UPD_DATE  ")
            strSQL.Append("     ,'' AS UPD_USER  ")
            strSQL.Append("FROM  ")
            strSQL.Append("     M08_AUTOTAIOU  ")
            strSQL.Append("WHERE  ")
            strSQL.Append("     GROUPCD = :GROUPCD ")
        ElseIf hdnJAGKBN.Value.Trim = "004" Then
            '�̔��X�O���[�v�}�X�^�@2019/01/24 T.Ono add 2018���P�J��
            strSQL.Append("SELECT ")
            strSQL.Append("     GROUPCD ")
            strSQL.Append("     ,GROUPNM ")
            strSQL.Append("     ,TO_CHAR(INS_DATE, 'YYYY/MM/DD HH24:MI:SS') AS INS_DATE ")
            strSQL.Append("     ,INS_USER ")
            strSQL.Append("     ,TO_CHAR(UPD_DATE, 'YYYY/MM/DD HH24:MI:SS') AS UPD_DATE ")
            strSQL.Append("     ,UPD_USER ")
            strSQL.Append("FROM ")
            strSQL.Append("     M12_HANBAITEN ")
            strSQL.Append("WHERE ")
            strSQL.Append("     GROUPCD = :GROUPCD ")
        Else
            strSQL.Append("SELECT ")
            strSQL.Append("     'X' ")
            strSQL.Append("FROM ")
            strSQL.Append("     DUAL ")
            strSQL.Append("WHERE ")
            strSQL.Append("     1 <> 1 ")
        End If


        '//------------------------------------------
        '//<TODO>�p�����[�^�̐ݒ�
        SqlParamC.fncSetParam("GROUPCD", True, hdnGROUPCD.Value.Trim)

        dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

        If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
            '�f�[�^�Ȃ��ꍇ
            strRecMsg = "�Ώۃf�[�^�����݂��܂���"
            strMsg.Append("alert('" & strRecMsg & "');")
            strMsg.Append("Form1.btnGROUP_SEARCH.focus();")
        Else
            txtGROUPCD_NEW.Text = Convert.ToString(dbData.Tables(0).Rows(0).Item("GROUPCD")).Trim
            txtGROUPNM_NEW.Text = Convert.ToString(dbData.Tables(0).Rows(0).Item("GROUPNM")).Trim
            hdnINS_DATE_NEW.Value = Convert.ToString(dbData.Tables(0).Rows(0).Item("INS_DATE")).Trim
            hdnINS_USER_NEW.Value = Convert.ToString(dbData.Tables(0).Rows(0).Item("INS_USER")).Trim
            hdnUPD_DATE_NEW.Value = Convert.ToString(dbData.Tables(0).Rows(0).Item("UPD_DATE")).Trim
            hdnUPD_USER_NEW.Value = Convert.ToString(dbData.Tables(0).Rows(0).Item("UPD_USER")).Trim
            '�O���[�v�R�[�h(�V�K�o�^�p)�͓��͕s�ɂ���
            txtGROUPCD_NEW.Attributes.Add("ReadOnly", "true")
            txtGROUPCD_NEW.BackColor = Color.Gainsboro
            hdnReadOnlyFlg.Value = "1"
            '�t�H�[�J�X���Z�b�g����i�O���[�v�R�[�h�������ɃZ�b�g�j
            strMsg.Append("Form1.btnGROUP_SEARCH.focus();")
        End If

        Call fncIni_notkey()
        Call fncIni_stateaf()
    End Sub

    '******************************************************************************
    '* �O���[�v�R�[�h���ύX�m��{�^�����������ꂽ�Ƃ��̏���
    '******************************************************************************
    Private Sub btnGROUP_MOD_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGROUP_MOD.ServerClick
        Dim strRec As String

        strRec = fncbtnGROUP_ADD_ClickEvent(hdnKBN.Value)

        Call fncIni_notkey()
        Call fncIni_stateaf()
    End Sub

    '******************************************************************************
    '*�@�T�@�v�F�i���ݏ�����n���v���p�e�B
    '*�@���@�l�F���o�����P�̒l��n��
    '******************************************************************************
    Public ReadOnly Property pCode1() As String
        Get
            Dim strRec As String = ""
            Dim col As Integer = 0
            Dim objKURACD As System.Web.UI.WebControls.TextBox
            col = Convert.ToInt32(hdnPopcrtl.Value)

            If hdnPopcrtl.Value = "1" Then      '//�N���C�A���g�R�[�h�ꗗ 
                strRec = AuthC.pAUTHCENTERCD    '//�`�c�F�؂̎g�p�\�Ď��Z���^�[�R�[�h
            ElseIf hdnPopcrtl.Value = "2" Then  '//JA�x���R�[�h�iFrom�j�ꗗ
                strRec = hdnKURACD.Value.Trim
            ElseIf hdnPopcrtl.Value = "3" Then  '//JA�x���R�[�h�iTo�j�ꗗ
                strRec = hdnKURACD.Value.Trim
            ElseIf hdnPopcrtl.Value = "4" Then  '//�O���[�v�R�[�h�ꗗ
                strRec = AuthC.pAUTHCENTERCD    '//�`�c�F�؂̎g�p�\�Ď��Z���^�[�R�[�h
            ElseIf col >= 101 And col <= 200 Then
                col = col - 100
                objKURACD = CType(FindControl("txtKURACD_" & CStr(col)), System.Web.UI.WebControls.TextBox)
                strRec = objKURACD.Text.Trim
            ElseIf col >= 201 And col <= 300 Then
                strRec = AuthC.pAUTHCENTERCD
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
            Dim strRec As String = ""
            Dim col As Integer = 0
            Dim objKURACD As System.Web.UI.WebControls.TextBox
            col = Convert.ToInt32(hdnPopcrtl.Value)

            If hdnPopcrtl.Value = "1" Then      '//�N���C�A���g�R�[�h�ꗗ 
                strRec = ""
            ElseIf hdnPopcrtl.Value = "2" Then  '//JA�x���R�[�h�iFrom�j�ꗗ
                strRec = ""
            ElseIf hdnPopcrtl.Value = "3" Then  '//JA�x���R�[�h�iTo�j�ꗗ
                strRec = ""
            ElseIf hdnPopcrtl.Value = "4" Then  '//�O���[�v�R�[�h�ꗗ
                strRec = hdnKURACD.Value.Trim
            ElseIf col >= 101 And col <= 200 Then
                strRec = ""
            ElseIf col >= 201 And col <= 300 Then
                col = col - 200
                objKURACD = CType(FindControl("txtKURACD_" & CStr(col)), System.Web.UI.WebControls.TextBox)
                strRec = objKURACD.Text.Trim
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

            If hdnPopcrtl.Value = "1" Then          '//�N���C�A���g�R�[�h�ꗗ
                strRec = "�N���C�A���g�R�[�h�ꗗ"
            ElseIf hdnPopcrtl.Value = "2" Then      '//JA�x���R�[�h�iFrom�j�ꗗ
                strRec = "�i�`�x���R�[�h�ꗗ"
            ElseIf hdnPopcrtl.Value = "3" Then      '//JA�x���R�[�h�iTo�j�ꗗ
                strRec = "�i�`�x���R�[�h�ꗗ"
            ElseIf hdnPopcrtl.Value = "4" Then      '//�O���[�v�R�[�h�ꗗ
                If Request.Form("cboJAGKBN") = "001" Then
                    strRec = "�̔����Ǝ҃O���[�v�ꗗ" '�̔����Ǝ҃O���[�v
                ElseIf Request.Form("cboJAGKBN") = "002" Then '2015/11/25 T.Ono add 2015���P�J�� ��7
                    strRec = "JA�S���ҁE�񍐐�E���ӎ����O���[�v�ꗗ" 'JA�S���ҁE�񍐐�E���ӎ����}�X�^
                ElseIf Request.Form("cboJAGKBN") = "003" Then '2017/02/09 W.Ganeko add 2016���P�J�� ��10
                    strRec = "�����Ή����e�O���[�v�ꗗ" '�����Ή��O���[�v�}�X�^
                ElseIf Request.Form("cboJAGKBN") = "004" Then '2019/01/24 T.Ono add 2018���P�J��
                    strRec = "�̔��X�O���[�v�ꗗ" '�̔��X�O���[�v�}�X�^
                Else
                    strRec = ""
                End If
            ElseIf col >= 101 And col <= 200 Then
                strRec = "�i�`�x���R�[�h�ꗗ"
            ElseIf col >= 201 And col <= 300 Then
                If Request.Form("cboJAGKBN") = "001" Then
                    strRec = "�̔����Ǝ҃O���[�v�ꗗ" '�̔����Ǝ҃O���[�v
                ElseIf Request.Form("cboJAGKBN") = "002" Then '2015/11/25 T.Ono add 2015���P�J�� ��7
                    strRec = "JA�S���ҁE�񍐐�E���ӎ����O���[�v�ꗗ" 'JA�S���ҁE�񍐐�E���ӎ����}�X�^
                ElseIf Request.Form("cboJAGKBN") = "003" Then '2017/02/09 W.Ganeko add 2016���P�J�� ��10
                    strRec = "�����Ή����e�O���[�v�ꗗ" '�����Ή��O���[�v�}�X�^
                ElseIf Request.Form("cboJAGKBN") = "004" Then '2019/01/24 T.Ono add 2018���P�J��
                    strRec = "�̔��X�O���[�v�ꗗ" '�̔��X�O���[�v�}�X�^
                Else
                    strRec = ""
                End If
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
            Dim strRec As String = ""
            Dim col As Integer = 0
            col = Convert.ToInt32(hdnPopcrtl.Value)

            If hdnPopcrtl.Value = "1" Then
                strRec = "CLI"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = "JASS3"
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = "JASS3"
            ElseIf hdnPopcrtl.Value = "4" Then
                If Request.Form("cboJAGKBN") = "001" Then
                    strRec = "HANG2" '�̔����Ǝ҃O���[�v
                ElseIf Request.Form("cboJAGKBN") = "002" Then '2015/11/25 T.Ono add 2015���P�J�� ��7
                    strRec = "JAHOKOKU" 'JA�S���ҁE�񍐐�E���ӎ����}�X�^
                ElseIf Request.Form("cboJAGKBN") = "003" Then '2017/02/09 W.Ganeko add 2016���P�J�� ��10
                    strRec = "AUTOGROUP" '�����Ή��O���[�v�}�X�^
                ElseIf Request.Form("cboJAGKBN") = "004" Then '2019/01/24 T.Ono add 2018���P�J��
                    strRec = "HANBAITEN" '�̔��X�O���[�v�}�X�^
                Else
                    strRec = ""
                End If
            ElseIf col >= 101 And col <= 200 Then
                strRec = "JASS3"
            ElseIf col >= 201 And col <= 300 Then
                If Request.Form("cboJAGKBN") = "001" Then
                    strRec = "HANG2" '�̔����Ǝ҃O���[�v
                ElseIf Request.Form("cboJAGKBN") = "002" Then '2015/11/25 T.Ono add 2015���P�J�� ��7
                    strRec = "JAHOKOKU" 'JA�S���ҁE�񍐐�E���ӎ����}�X�^
                ElseIf Request.Form("cboJAGKBN") = "003" Then '2017/02/09 W.Ganeko add 2016���P�J�� ��10
                    strRec = "AUTOGROUP" '�����Ή��O���[�v�}�X�^
                ElseIf Request.Form("cboJAGKBN") = "004" Then '2019/01/24 T.Ono add 2018���P�J��
                    strRec = "HANBAITEN" '�̔��X�O���[�v�}�X�^
                Else
                    strRec = ""
                End If
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
            Dim strRec As String = ""
            Dim col As Integer = 0
            col = Convert.ToInt32(hdnPopcrtl.Value)

            If hdnPopcrtl.Value = "1" Then
                strRec = "hdnKURACD"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = "hdnACBCD_F"
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = "hdnACBCD_T"
            ElseIf hdnPopcrtl.Value = "4" Then
                strRec = "hdnGROUPCD"
            ElseIf col >= 101 And col <= 200 Then
                col = col - 100
                strRec = "hdnACBCD_" & Convert.ToString(col)
            ElseIf col >= 201 And col <= 300 Then
                col = col - 200
                strRec = "hdnGROUPCD_" & Convert.ToString(col)
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
            Dim strRec As String = ""
            Dim col As Integer = 0
            col = Convert.ToInt32(hdnPopcrtl.Value)

            If hdnPopcrtl.Value = "1" Then
                strRec = "txtKURACD"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = "txtACBCD_F"
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = "txtACBCD_T"
            ElseIf hdnPopcrtl.Value = "4" Then
                strRec = "txtGROUPCD"
            ElseIf col >= 101 And col <= 200 Then
                col = col - 100
                strRec = "txtACBCD_" & Convert.ToString(col)
            ElseIf col >= 201 And col <= 300 Then
                col = col - 200
                strRec = "txtGROUPCD_" & Convert.ToString(col)
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

            If hdnPopcrtl.Value = "1" Then
                strRec = "btnKURACD"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = "btnACBCD_F"
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = "btnACBCD_T"
            ElseIf hdnPopcrtl.Value = "4" Then
                strRec = "btnGROUPCD"
            ElseIf col >= 101 And col <= 200 Then
                col = col - 100
                strRec = "btnACBCD_" & Convert.ToString(col)
            ElseIf col >= 201 And col <= 300 Then
                col = col - 200
                strRec = "btnGROUPCD_" & Convert.ToString(col)
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
            Dim strRec As String = ""
            Dim col As Integer = 0
            col = Convert.ToInt32(hdnPopcrtl.Value)

            If hdnPopcrtl.Value = "1" Then
                strRec = "txtACBCD_F"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "4" Then
                strRec = ""
            ElseIf col >= 101 And col <= 200 Then
                strRec = ""
            ElseIf col >= 201 And col <= 300 Then
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
            Dim strRec As String = ""
            Dim col As Integer = 0
            col = Convert.ToInt32(hdnPopcrtl.Value)

            If hdnPopcrtl.Value = "1" Then
                strRec = "hdnACBCD_F"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "4" Then
                strRec = ""
            ElseIf col >= 101 And col <= 200 Then
                strRec = ""
            ElseIf col >= 201 And col <= 300 Then
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
            Dim strRec As String = ""
            Dim col As Integer = 0
            col = Convert.ToInt32(hdnPopcrtl.Value)

            If hdnPopcrtl.Value = "1" Then
                strRec = "txtACBCD_T"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "4" Then
                strRec = ""
            ElseIf col >= 101 And col <= 200 Then
                strRec = ""
            ElseIf col >= 201 And col <= 300 Then
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
            Dim strRec As String = ""
            Dim col As Integer = 0
            col = Convert.ToInt32(hdnPopcrtl.Value)

            If hdnPopcrtl.Value = "1" Then
                strRec = "hdnACBCD_T"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "4" Then
                strRec = ""
            ElseIf col >= 101 And col <= 200 Then
                strRec = ""
            ElseIf col >= 201 And col <= 300 Then
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
            Dim strRec As String = ""
            Dim col As Integer = 0
            col = Convert.ToInt32(hdnPopcrtl.Value)

            If hdnPopcrtl.Value = "1" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "4" Then
                strRec = ""
            ElseIf col >= 101 And col <= 200 Then
                strRec = ""
            ElseIf col >= 201 And col <= 300 Then
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
            Dim strRec As String = ""
            Dim col As Integer = 0
            col = Convert.ToInt32(hdnPopcrtl.Value)

            If hdnPopcrtl.Value = "1" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "2" Then
                '2019/11/01 T.Ono mod �Ď����P2019
                'strRec = ""
                strRec = "fncSetTo"
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "4" Then
                strRec = ""
            ElseIf col >= 101 And col <= 200 Then
                strRec = ""
            ElseIf col >= 201 And col <= 300 Then
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
            '�o�^�E�폜�A�ꊇ�o�^���炫���ꍇ
            '�o�͂Ƀ`�F�b�N�������ꍇ�́ASQL�G���[�ƂȂ邽�ߎ����I�ɂ���
            If chkSYU_TOUROKU.Checked = False AndAlso chkSYU_MITOUROKU.Checked = False Then
                chkSYU_TOUROKU.Checked = True
                chkSYU_MITOUROKU.Checked = True
            End If

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
                '<TODO>100���ȏ�̏ꍇ�̓��b�Z�[�W
                If dbData.Tables(0).Rows.Count > 100 Then
                    strMsg.Append("alert('�ő�o�͌����𒴂��܂����B�������w�肵�čēx�������Ă�������');")
                End If

                '------------------------------------
                '<TODO>�f�[�^���o�͂���
                '�敪
                If hdnJAGKBN.Value.Length <> 0 Then
                    hdnJAGKBN_MOTO.Value = hdnJAGKBN.Value.Trim
                End If
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
                If hdnGROUPCD.Value.Length <> 0 Then
                    hdnGROUPCD_MOTO.Value = hdnGROUPCD.Value.Trim
                Else
                    hdnGROUPCD_MOTO.Value = ""
                End If


                Dim objKURACD As System.Web.UI.WebControls.TextBox
                Dim objACBCD As System.Web.UI.WebControls.TextBox
                Dim objhdnACBCD As System.Web.UI.HtmlControls.HtmlInputHidden
                Dim objGROUPCD As System.Web.UI.WebControls.TextBox
                Dim objhdnGROUPCD As System.Web.UI.HtmlControls.HtmlInputHidden
                Dim objUSERCD_F As System.Web.UI.WebControls.TextBox
                Dim objUSERCD_T As System.Web.UI.WebControls.TextBox
                Dim objBIKO As System.Web.UI.WebControls.TextBox
                Dim objINS_DATE As System.Web.UI.WebControls.TextBox
                Dim objINS_USER As System.Web.UI.WebControls.TextBox
                Dim objUPD_DATE As System.Web.UI.WebControls.TextBox
                Dim objUPD_USER As System.Web.UI.WebControls.TextBox
                Dim objbtnACBCD As System.Web.UI.HtmlControls.HtmlInputButton

                Dim intRow As Integer

                For intRow = 0 To dbData.Tables(0).Rows.Count - 1

                    If intRow >= 100 Then Exit For '100���ȏ�͏�������

                    '----------------------------
                    ' ���׏�����ʍ��ڂɃZ�b�g
                    '----------------------------
                    '�R���g���[������T���o���A�^�ϊ�
                    objKURACD = CType(FindControl("txtKURACD_" & CStr(intRow + 1)), System.Web.UI.WebControls.TextBox)
                    objACBCD = CType(FindControl("txtACBCD_" & CStr(intRow + 1)), System.Web.UI.WebControls.TextBox)
                    objhdnACBCD = CType(FindControl("hdnACBCD_" & CStr(intRow + 1)), System.Web.UI.HtmlControls.HtmlInputHidden)
                    objGROUPCD = CType(FindControl("txtGROUPCD_" & CStr(intRow + 1)), System.Web.UI.WebControls.TextBox)
                    objhdnGROUPCD = CType(FindControl("hdnGROUPCD_" & CStr(intRow + 1)), System.Web.UI.HtmlControls.HtmlInputHidden)
                    objUSERCD_F = CType(FindControl("txtUSERCD_F_" & CStr(intRow + 1)), System.Web.UI.WebControls.TextBox)
                    objUSERCD_T = CType(FindControl("txtUSERCD_T_" & CStr(intRow + 1)), System.Web.UI.WebControls.TextBox)
                    objBIKO = CType(FindControl("txtBIKO_" & CStr(intRow + 1)), System.Web.UI.WebControls.TextBox)
                    objINS_DATE = CType(FindControl("txtINS_DATE_" & CStr(intRow + 1)), System.Web.UI.WebControls.TextBox)
                    objINS_USER = CType(FindControl("txtINS_USER_" & CStr(intRow + 1)), System.Web.UI.WebControls.TextBox)
                    objUPD_DATE = CType(FindControl("txtUPD_DATE_" & CStr(intRow + 1)), System.Web.UI.WebControls.TextBox)
                    objUPD_USER = CType(FindControl("txtUPD_USER_" & CStr(intRow + 1)), System.Web.UI.WebControls.TextBox)
                    objbtnACBCD = CType(FindControl("btnACBCD_" & CStr(intRow + 1)), System.Web.UI.HtmlControls.HtmlInputButton)


                    '�L�[���ڂ͕ύX�s�ɂ���
                    objKURACD.ReadOnly = True
                    objKURACD.BackColor = Color.Gainsboro
                    objACBCD.ReadOnly = True
                    objACBCD.BackColor = Color.Gainsboro
                    objbtnACBCD.Disabled = True

                    objKURACD.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("KURACD"))
                    objACBCD.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("ACBNM"))
                    objhdnACBCD.Value = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("ACBCD"))
                    objGROUPCD.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("GROUPNM"))
                    objhdnGROUPCD.Value = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("GROUPCD"))
                    objUSERCD_F.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("USERCD_FROM"))
                    objUSERCD_T.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("USERCD_TO"))
                    objBIKO.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("BIKO"))
                    objINS_DATE.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("INS_DATE"))
                    objINS_USER.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("INS_USER"))
                    objUPD_DATE.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("UPD_DATE"))
                    objUPD_USER.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("UPD_USER"))

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

        Dim strRec As String = ""
        Dim DateFncC As New CDateFnc

        Dim MSJAGJAW00C As New MSJAGJAG00MSJAGJAW00.MSJAGJAW00


        '�l��z��ɃZ�b�g
        Dim objTARGET As System.Web.UI.WebControls.CheckBox
        Dim objKURACD As System.Web.UI.WebControls.TextBox
        Dim objhdnACBCD As System.Web.UI.HtmlControls.HtmlInputHidden
        Dim objhdnGROUPCD As System.Web.UI.HtmlControls.HtmlInputHidden
        Dim objUSERCD_F As System.Web.UI.WebControls.TextBox
        Dim objUSERCD_T As System.Web.UI.WebControls.TextBox
        Dim objBIKO As System.Web.UI.WebControls.TextBox
        Dim objINS_DATE As System.Web.UI.WebControls.TextBox
        Dim objINS_USER As System.Web.UI.WebControls.TextBox
        Dim objUPD_DATE As System.Web.UI.WebControls.TextBox
        Dim objUPD_USER As System.Web.UI.WebControls.TextBox

        Dim sTARGET(100) As String
        Dim sKURACD(100) As String
        Dim sACBCD(100) As String
        Dim sGROUPCD(100) As String
        Dim sUSERCD_F(100) As String
        Dim sUSERCD_T(100) As String
        Dim sBIKO(100) As String
        Dim sINS_DATE(100) As String
        Dim sINS_USER(100) As String
        Dim sUPD_DATE(100) As String
        Dim sUPD_USER(100) As String

        Dim i As Integer
        For i = 1 To 100
            '�R���g���[������T���o���A�^�ϊ�
            objTARGET = CType(FindControl("chkTARGET_" & CStr(i)), System.Web.UI.WebControls.CheckBox)
            objKURACD = CType(FindControl("txtKURACD_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objhdnACBCD = CType(FindControl("hdnACBCD_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
            objhdnGROUPCD = CType(FindControl("hdnGROUPCD_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
            objUSERCD_F = CType(FindControl("txtUSERCD_F_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objUSERCD_T = CType(FindControl("txtUSERCD_T_" & CStr(i)), System.Web.UI.WebControls.TextBox)
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
            sKURACD(i) = objKURACD.Text.Trim
            sACBCD(i) = objhdnACBCD.Value.Trim
            sGROUPCD(i) = objhdnGROUPCD.Value.Trim
            sUSERCD_F(i) = objUSERCD_F.Text.Trim
            sUSERCD_T(i) = objUSERCD_T.Text.Trim
            sBIKO(i) = objBIKO.Text.Trim
            sINS_DATE(i) = objINS_DATE.Text.Trim
            sINS_USER(i) = objINS_USER.Text.Trim
            sUPD_DATE(i) = objUPD_DATE.Text.Trim
            sUPD_USER(i) = objUPD_USER.Text.Trim

        Next

        strRec = MSJAGJAW00C.mSetEx( _
                    CInt(pstrKBN), _
                    hdnJAGKBN.Value, _
                    sTARGET, _
                    sKURACD, _
                    sACBCD, _
                    sGROUPCD, _
                    sUSERCD_F, _
                    sUSERCD_T, _
                    sBIKO, _
                    sINS_DATE, _
                    sINS_USER, _
                    sUPD_DATE, _
                    sUPD_USER, _
                    AuthC.pUSERNAME _
                    )

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
                '����
                strRec = fncbtnKensaku_ClickEvent("2")
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
            Case "6"
                strRecMsg = "�P��JA�x����100���ȏ�o�^���邱�Ƃ͂ł��܂���"
                strMsg.Append("alert('" & strRecMsg & "');")

                '<TODO>�t�H�[�J�X���Z�b�g����i�o�^�E�C�����ł̃G���[�B�����{�^���ɃZ�b�g�j
                strMsg.Append("Form1.btnSelect.focus();")

                strRec = strRecMsg

            Case "7"
                '2016/03/09 T.Ono add 2015���P�J��
                strRecMsg = "�O���[�v�R�[�h�����݂��܂���"
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

        For i = 1 To 100
            Dim objACBCD As System.Web.UI.WebControls.TextBox
            Dim objbtnACBCD As System.Web.UI.HtmlControls.HtmlInputButton
            objKURACD = CType(FindControl("txtKURACD_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objACBCD = CType(FindControl("txtACBCD_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objbtnACBCD = CType(FindControl("btnACBCD_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputButton)
            If objKURACD.Text <> "" Then
                objKURACD.ReadOnly = True
                objKURACD.BackColor = Color.Gainsboro
                objACBCD.ReadOnly = True
                objACBCD.BackColor = Color.Gainsboro
                objbtnACBCD.Disabled = True
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
    Private Function fncbtnIKKATU_ClickEvent(ByVal pstrKBN As String) As String

        Dim strRec As String = ""
        Dim DateFncC As New CDateFnc

        Dim MSJAGJAW00C As New MSJAGJAG00MSJAGJAW00.MSJAGJAW00


        '�z��p��
        Dim sTARGET() As String = {""}
        Dim sKURACD() As String = {""}
        Dim sACBCD() As String = {""}
        Dim sGROUPCD() As String = {""}
        Dim sUSERCD_F() As String = {""}
        Dim sUSERCD_T() As String = {""}
        Dim sBIKO() As String = {""}
        Dim sINS_DATE() As String = {""}
        Dim sINS_USER() As String = {""}
        Dim sUPD_DATE() As String = {""}
        Dim sUPD_USER() As String = {""}

        '�d���m�F
        Dim bolchkCHOUFUKU As Boolean = False 'True�F�d���Ȃ��@False�F�d������NG
        '����
        Dim dbData As DataSet
        Dim bolDataSelect As Boolean = False 'True�F�Ώۃf�[�^����@False�F�Ώۃf�[�^�Ȃ�NG


        Try

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

                    ReDim Preserve sTARGET(intRow + 1)
                    ReDim Preserve sKURACD(intRow + 1)
                    ReDim Preserve sACBCD(intRow + 1)
                    ReDim Preserve sGROUPCD(intRow + 1)
                    ReDim Preserve sUSERCD_F(intRow + 1)
                    ReDim Preserve sUSERCD_T(intRow + 1)
                    ReDim Preserve sBIKO(intRow + 1)
                    ReDim Preserve sINS_DATE(intRow + 1)
                    ReDim Preserve sINS_USER(intRow + 1)
                    ReDim Preserve sUPD_DATE(intRow + 1)
                    ReDim Preserve sUPD_USER(intRow + 1)

                    sTARGET(intRow + 1) = "true"
                    sKURACD(intRow + 1) = hdnKURACD.Value.Trim
                    sACBCD(intRow + 1) = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("HAN_CD"))
                    sGROUPCD(intRow + 1) = hdnGROUPCD.Value.Trim
                    sUSERCD_F(intRow + 1) = ""
                    sUSERCD_T(intRow + 1) = ""
                    sBIKO(intRow + 1) = ""
                    sINS_DATE(intRow + 1) = ""
                    sINS_USER(intRow + 1) = ""
                    sUPD_DATE(intRow + 1) = ""
                    sUPD_USER(intRow + 1) = ""

                Next

                strRec = MSJAGJAW00C.mSetEx( _
                                    CInt(pstrKBN), _
                                    hdnJAGKBN.Value, _
                                    sTARGET, _
                                    sKURACD, _
                                    sACBCD, _
                                    sGROUPCD, _
                                    sUSERCD_F, _
                                    sUSERCD_T, _
                                    sBIKO, _
                                    sINS_DATE, _
                                    sINS_USER, _
                                    sUPD_DATE, _
                                    sUPD_USER, _
                                    AuthC.pUSERNAME _
                                    )


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
                        '����
                        strRec = fncbtnKensaku_ClickEvent("2")
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
                    Case "6"
                        strRecMsg = "�P��JA�x����100���ȏ�o�^���邱�Ƃ͂ł��܂���"
                        strMsg.Append("alert('" & strRecMsg & "');")

                        '<TODO>�t�H�[�J�X���Z�b�g����i�o�^�E�C�����ł̃G���[�B�����{�^���ɃZ�b�g�j
                        strMsg.Append("Form1.btnSelect.focus();")

                        strRec = strRecMsg
                    Case "7"
                        '2016/03/09 T.Ono add 2015���P�J��
                        strRecMsg = "�O���[�v�R�[�h�����݂��܂���"
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
        Dim SQLC As New MSJAGJAG00CCSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet
        Dim strSELECT As New StringBuilder("") '�O���[�v���擾SELECT��
        Dim strFROM As New StringBuilder("") '�O���[�v���擾��}�X�^FROM��
        Dim strWHERE As New StringBuilder("") '�O���[�v���擾WHERE��

        '�敪�ɂ��A�O���[�v�R�[�h���̎擾�悪�ς��
        If hdnJAGKBN.Value.Trim = "001" Then
            'SELECT��
            strSELECT.Append("	,A.GROUPCD || ' : ' || B.GROUPNM AS GROUPNM ")
            'FROM��
            strFROM.Append("	,M10_HANJIGYOSYA B ")
            'WHERE��
            strWHERE.Append("AND A.GROUPCD = B.GROUPCD(+) ")
        ElseIf hdnJAGKBN.Value.Trim = "002" Then
            'JA�S���ҁE�񍐐�E���ӎ����}�X�^�@2015/12/10 T.Ono add 2015���P�J�� ��7
            'SELECT��
            strSELECT.Append("	,A.GROUPCD || ' : ' || B.GROUPNM AS GROUPNM ")
            'FROM��
            strFROM.Append("	,M11_JAHOKOKU B ")
            'WHERE��
            strWHERE.Append("AND A.GROUPCD = B.GROUPCD(+) ")
            strWHERE.Append("AND LPAD(B.TANCD(+), 2, '0') = '01' ")
        ElseIf hdnJAGKBN.Value.Trim = "003" Then
            '�����Ή��}�X�^�@2017/02/09 W.GANEKO add 2016���P�J�� ��10
            'SELECT��
            strSELECT.Append("	,A.GROUPCD || ' : ' || B.GROUPNM AS GROUPNM ")
            'FROM��
            strFROM.Append("	,(SELECT GROUPCD,GROUPNM FROM M08_AUTOTAIOU GROUP BY GROUPCD,GROUPNM) B ")
            'WHERE��
            strWHERE.Append("AND A.GROUPCD = B.GROUPCD(+) ")
        ElseIf hdnJAGKBN.Value.Trim = "004" Then
            'SELECT��
            strSELECT.Append("	,A.GROUPCD || ' : ' || B.GROUPNM AS GROUPNM ")
            'FROM��
            strFROM.Append("	,M12_HANBAITEN B ")
            'WHERE��
            strWHERE.Append("AND A.GROUPCD = B.GROUPCD(+) ")
        Else
            strSELECT.Append("	,A.GROUPCD AS GROUPNM ")
            strFROM.Append("")
            strWHERE.Append("")
        End If

        strSQL.Append("WITH Z AS( ")

        If chkSYU_TOUROKU.Checked = True Then
            '�o�^��
            strSQL.Append("SELECT CASE WHEN USERCD_FROM IS NULL THEN '1' ")
            strSQL.Append("	WHEN USERCD_FROM IS NOT NULL AND USERCD_TO IS NOT NULL THEN '2' ")
            strSQL.Append("	WHEN USERCD_FROM IS NOT NULL AND USERCD_TO IS NULL THEN '3' ")
            strSQL.Append("	ELSE '0' ")
            strSQL.Append("	END AS NO ")
            strSQL.Append("	,A.KBN ")
            strSQL.Append("	,A.KURACD ")
            strSQL.Append("	,A.ACBCD ")
            strSQL.Append("	,A.GROUPCD ")
            strSQL.Append(strSELECT.ToString)
            strSQL.Append("	,A.USERCD_FROM ")
            strSQL.Append("	,A.USERCD_TO ")
            strSQL.Append("	,A.BIKO ")
            strSQL.Append("	,TO_CHAR(A.INS_DATE, 'YYYY/MM/DD HH24:MI:SS') AS INS_DATE ")
            strSQL.Append("	,A.INS_USER ")
            strSQL.Append("	,TO_CHAR(A.UPD_DATE, 'YYYY/MM/DD HH24:MI:SS') AS UPD_DATE ")
            strSQL.Append("	,A.UPD_USER ")
            strSQL.Append("FROM M09_JAGROUP A ")
            strSQL.Append(strFROM.ToString)
            strSQL.Append("WHERE 1=1 ")
            strSQL.Append("AND A.KBN = :KBN ")
            strSQL.Append(strWHERE.ToString)
            '�N���C�A���g�R�[�h
            If hdnKURACD.Value.Trim.Length > 0 Then
                strSQL.Append("AND A.KURACD = :KURACD ")
            End If
            'JA�x���R�[�h
            If hdnACBCD_F.Value.Trim.Length > 0 Then
                strSQL.Append("AND A.ACBCD >= :ACBCD_F ")
            End If
            If hdnACBCD_T.Value.Trim.Length > 0 Then
                strSQL.Append("AND A.ACBCD <= :ACBCD_T ")
            End If
            '�O���[�v�R�[�h
            If hdnGROUPCD.Value.Trim.Length > 0 Then
                strSQL.Append("AND A.GROUPCD = :GROUPCD ")
            End If
        End If

        If chkSYU_TOUROKU.Checked = True AndAlso chkSYU_MITOUROKU.Checked = True Then
            '�����̂Ƃ��͂Ȃ�
            strSQL.Append("UNION ALL ")
        End If

        If chkSYU_MITOUROKU.Checked = True Then
            '���o�^��
            strSQL.Append("SELECT '1' AS NO ")
            strSQL.Append("	,:KBN AS KBN ")
            strSQL.Append("	,A.CLI_CD AS KURACD ")
            strSQL.Append("	,A.HAN_CD AS ACBCD ")
            strSQL.Append("	,'' AS GROUPCD ")
            strSQL.Append("	,'' AS GROUPNM ")
            strSQL.Append("	,'' AS USERCD_FROM ")
            strSQL.Append("	,'' AS USERCD_TO ")
            strSQL.Append("	,'' AS BIKO ")
            strSQL.Append("	,'' AS INS_DATE ")
            strSQL.Append("	,'' AS INS_USER ")
            strSQL.Append("	,'' AS UPD_DATE ")
            strSQL.Append("	,'' AS UPD_USER ")
            strSQL.Append("FROM HN2MAS A ")
            strSQL.Append("	,HN2MAS B ")
            strSQL.Append("WHERE NOT EXISTS (SELECT 'X' ")
            strSQL.Append("	FROM M09_JAGROUP C ")
            strSQL.Append("	WHERE 1=1 ")
            strSQL.Append("	AND C.KBN = :KBN ")
            strSQL.Append("	AND C.KURACD = A.CLI_CD ")
            strSQL.Append("	AND C.ACBCD = A.HAN_CD ")
            strSQL.Append("	AND C.USERCD_FROM IS NULL")
            strSQL.Append("	) ")
            strSQL.Append("AND A.CLI_CD = B.CLI_CD ")
            strSQL.Append("AND A.HAN_CD = B.HAN_CD ")
            strSQL.Append("AND A.HAN_CD <> B.JA_CD ")
            strSQL.Append("AND NVL(A.DEL_FLG,'0') <> '1' ")
            strSQL.Append("AND NVL(B.DEL_FLG,'0') <> '1' ")
            '�N���C�A���g�R�[�h
            If hdnKURACD.Value.Trim.Length > 0 Then
                strSQL.Append("AND A.CLI_CD = :KURACD ")
            End If
            'JA�x���R�[�h
            If hdnACBCD_F.Value.Trim.Length > 0 Then
                strSQL.Append("AND A.HAN_CD >= :ACBCD_F ")
            End If
            If hdnACBCD_T.Value.Trim.Length > 0 Then
                strSQL.Append("AND A.HAN_CD <= :ACBCD_T ")
            End If
        End If

        strSQL.Append(") ")
        strSQL.Append("SELECT Z.NO AS NO ")
        strSQL.Append("	,Z.KBN AS KBN ")
        strSQL.Append("	,Z.KURACD AS KURACD ")
        strSQL.Append("	,Z.ACBCD AS ACBCD ")
        strSQL.Append("	,Z.ACBCD || ' : ' || A.JAS_NAME AS ACBNM ")
        strSQL.Append("	,Z.GROUPCD AS GROUPCD ")
        strSQL.Append("	,Z.GROUPNM AS GROUPNM ")
        strSQL.Append("	,Z.USERCD_FROM AS USERCD_FROM ")
        strSQL.Append("	,Z.USERCD_TO AS USERCD_TO ")
        strSQL.Append("	,Z.BIKO AS BIKO ")
        strSQL.Append("	,Z.INS_DATE AS INS_DATE ")
        strSQL.Append("	,Z.INS_USER AS INS_USER ")
        strSQL.Append("	,Z.UPD_DATE AS UPD_DATE ")
        strSQL.Append("	,Z.UPD_USER AS UPD_USER ")
        strSQL.Append("FROM Z, HN2MAS A ")
        strSQL.Append("WHERE Z.KURACD = A.CLI_CD ")
        strSQL.Append("AND Z.ACBCD = A.HAN_CD ")
        strSQL.Append("ORDER BY KBN, KURACD, ACBCD, NO, USERCD_FROM ")


        '�敪
        If hdnJAGKBN.Value.Trim.Length > 0 Then
            SqlParamC.fncSetParam("KBN", True, hdnJAGKBN.Value.Trim)
        End If
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
        If hdnGROUPCD.Value.Trim.Length > 0 AndAlso chkSYU_TOUROKU.Checked = True Then
            SqlParamC.fncSetParam("GROUPCD", True, hdnGROUPCD.Value.Trim)
        End If

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
        Dim SQLC As New MSJAGJAG00CCSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet

        strSQL.Append("SELECT ")
        strSQL.Append("		'X' ")
        strSQL.Append("FROM ")
        strSQL.Append("		M09_JAGROUP A ")
        strSQL.Append("WHERE ")
        strSQL.Append("		A.KBN = :JAGKBN ")
        strSQL.Append("AND	A.KURACD = :KURACD ")
        If hdnACBCD_F.Value.Trim.Length > 0 Then
            strSQL.Append("AND	A.ACBCD >= :ACBCD_F ")
        End If
        If hdnACBCD_T.Value.Trim.Length > 0 Then
            strSQL.Append("AND	A.ACBCD <= :ACBCD_T ")
        End If
        strSQL.Append("ORDER BY A.KURACD, A.ACBCD ")

        '//------------------------------------------
        '//<TODO>�p�����[�^�̐ݒ�
        SqlParamC.fncSetParam("JAGKBN", True, hdnJAGKBN.Value.Trim)
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
        Dim SQLC As New MSJAGJAG00CCSQL.CSQL
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

    '******************************************************************************
    '* �O���[�v�ǉ��{�^���������̏���
    '******************************************************************************
    Private Function fncbtnGROUP_ADD_ClickEvent(ByVal pstrKBN As String) As String

        Dim strRec As String = ""
        Dim DateFncC As New CDateFnc

        Dim MSJAGJAW00C As New MSJAGJAG00MSJAGJAW00.MSJAGJAW00

        Dim bolGroupNMchk As Boolean = False 'True:OK�@False:NG�@�������AM06.PULLDOWN:KBN=78 NAIYO1�Ɛ擪�������r
        Dim bolChoufukuGroup As Boolean = False 'True:�o�^�Ȃ��@False:�o�^����NG


        Try
            '-------------------------------------------------
            '�O���[�v���m�F
            bolGroupNMchk = fncGroupNMchk()
            If bolGroupNMchk = False Then
                strMsg.Append("alert('�O���[�v�R�[�h���s���ł�\n�擪�ɋ敪�Ɠ����A���t�@�x�b�g2��������͂��Ă�������');")

                Call fncIni_statebf()

                '//------------------------------
                '<TODO>�t�H�[�J�X���Z�b�g����i�O���[�v�R�[�h(�V�K�o�^�p)�ɃZ�b�g�j
                strMsg.Append("Form1.txtGROUPCD_NEW.focus();")
                strRec = "�O���[�v���擪�����`�F�b�N"
                Return strRec

            End If


            '-------------------------------------------------
            '�o�^�@�敪�ɂ��A�o�^��ύX
            Select Case hdnJAGKBN.Value.Trim
                Case "001" '�̔����Ǝ҃O���[�v�}�X�^
                    strRec = MSJAGJAW00C.mSetHANJIGYOSYA(
                                            CInt(hdnKBN.Value.Trim), _
                                            txtGROUPCD_NEW.Text.Trim, _
                                            txtGROUPNM_NEW.Text.Trim, _
                                            hdnINS_DATE_NEW.Value.Trim, _
                                            hdnINS_USER_NEW.Value.Trim, _
                                            hdnUPD_DATE_NEW.Value.Trim, _
                                            hdnUPD_USER_NEW.Value.Trim, _
                                            AuthC.pUSERNAME.Trim _
                                            )

                Case "002" 'JA�S���ҁE�񍐐�E���ӎ����}�X�^ 2015/12/10 T.Ono add 2015���P�J�� ��7
                    strRec = MSJAGJAW00C.mSetJAHOKOKU(
                                            CInt(hdnKBN.Value.Trim), _
                                            txtGROUPCD_NEW.Text.Trim, _
                                            txtGROUPNM_NEW.Text.Trim, _
                                            hdnINS_DATE_NEW.Value.Trim, _
                                            hdnINS_USER_NEW.Value.Trim, _
                                            hdnUPD_DATE_NEW.Value.Trim, _
                                            hdnUPD_USER_NEW.Value.Trim, _
                                            AuthC.pUSERNAME.Trim _
                                            )
                Case "003" '�����Ή��O���[�v�}�X�^ 2017/02/09 W.GANEKO add 2016���P�J�� ��10
                    strRec = MSJAGJAW00C.mSetAUTOTAIOU(
                                            CInt(hdnKBN.Value.Trim),
                                            txtGROUPCD_NEW.Text.Trim,
                                            txtGROUPNM_NEW.Text.Trim,
                                            hdnINS_DATE_NEW.Value.Trim,
                                            hdnINS_USER_NEW.Value.Trim,
                                            hdnUPD_DATE_NEW.Value.Trim,
                                            hdnUPD_USER_NEW.Value.Trim,
                                            AuthC.pUSERNAME.Trim
                                            )
                Case "004" '�̔��X�O���[�v�}�X�^ 2019/01/24 T.Ono add 2018���P�J��
                    strRec = MSJAGJAW00C.mSetHANBAITEN(
                                            CInt(hdnKBN.Value.Trim),
                                            txtGROUPCD_NEW.Text.Trim,
                                            txtGROUPNM_NEW.Text.Trim,
                                            hdnINS_DATE_NEW.Value.Trim,
                                            hdnINS_USER_NEW.Value.Trim,
                                            hdnUPD_DATE_NEW.Value.Trim,
                                            hdnUPD_USER_NEW.Value.Trim,
                                            AuthC.pUSERNAME.Trim
                                            )
                Case Else
                    strRec = "NG"
            End Select

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

                    '<TODO>�t�H�[�J�X���Z�b�g����i�����{�^���ɃZ�b�g�j
                    strMsg.Append("Form1.btnSelect.focus();")
                    '//------------------------------

                Case "0"
                    strRecMsg = "���̃��[�U�[�ɂ���ăf�[�^���X�V����Ă��܂��B�ēx�������Ă�������"
                    strMsg.Append("alert('" & strRecMsg & "');")

                    '//------------------------------
                    '<TODO>�t�H�[�J�X���Z�b�g����i�O���[�v�R�[�h���ύX�m��{�^���ɃZ�b�g�j
                    strMsg.Append("Form1.btnGROUP_SEARCH.focus();")
                    strRec = strRecMsg

                Case "1"
                    strRecMsg = "�o�^�ς݃f�[�^�����݂��܂��B�m�F���Ă�������"
                    strMsg.Append("alert('" & strRecMsg & "');")

                    '//------------------------------
                    '<TODO>�t�H�[�J�X���Z�b�g����i�C�����ł̃G���[�B�O���[�v�R�[�h(�V�K�o�^�p)�ɃZ�b�g�j
                    strMsg.Append("Form1.txtGROUPCD_NEW.focus();")
                    strRec = strRecMsg

                Case "2"
                    strRecMsg = "�f�[�^�����݂��܂���B�m�F���Ă�������"
                    strMsg.Append("alert('" & strRecMsg & "');")

                    '//------------------------------
                    '<TODO>�t�H�[�J�X���Z�b�g����i�O���[�v�R�[�h���ύX�m��{�^���ɃZ�b�g�j
                    strMsg.Append("Form1.btnGROUP_MOD.focus();")
                    strRec = strRecMsg

                Case "3" '2016/01/12 T.Ono add 2015���P�J��
                    strRecMsg = "�O���[�v�R�[�h�����d�����Ă��܂�"
                    strMsg.Append("alert('" & strRecMsg & "');")

                    '//------------------------------
                    '<TODO>�t�H�[�J�X���Z�b�g����i�O���[�v�R�[�h���ύX�m��{�^���ɃZ�b�g�j
                    strMsg.Append("Form1.txtGROUPNM_NEW.focus();")
                    strRec = strRecMsg
                Case Else
                    Dim ErrMsgC As New CErrMsg

                    strMsg.Append("alert('�V�X�e���G���[�F" & ErrMsgC.mGetArtMsg(strRec) & "');")

                    If pstrKBN = "7" Then
                        '//------------------------------
                        '<TODO>�t�H�[�J�X���Z�b�g����i�C�����ł̃G���[�B�O���[�v�R�[�h(�V�K�o�^�p)�ɃZ�b�g�j
                        strMsg.Append("Form1.txtGROUPCD_NEW.focus();")
                    ElseIf pstrKBN = "9" Then
                        '//------------------------------
                        '<TODO>�t�H�[�J�X���Z�b�g����i�O���[�v�R�[�h���ύX�m��{�^���ɃZ�b�g�j
                        strMsg.Append("Form1.btnGROUP_MOD.focus();")
                    Else
                        '//------------------------------
                        '<TODO>�t�H�[�J�X���Z�b�g����i�C�����ł̃G���[�B�O���[�v�R�[�h(�V�K�o�^�p)�ɃZ�b�g�j
                        strMsg.Append("Form1.txtGROUPCD_NEW.focus();")
                    End If
            End Select


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
    '*�O���[�v�ǉ��@�����K���𖞂����Ă��邩�@True�F(OK)�@False�F(NG)
    '******************************************************************************
    Private Function fncGroupNMchk() As Boolean
        '�v���_�E���}�X�^KBN=78 NAIYO1�Ɛ擪�������r

        Dim res As Boolean = False

        '//------------------------------------------
        '//<TODO>Select���̍쐬
        Dim SQLC As New MSJAGJAG00CCSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet

        strSQL.Append("SELECT ")
        strSQL.Append("		NAIYO1 ")
        strSQL.Append("FROM ")
        strSQL.Append("		M06_PULLDOWN A ")
        strSQL.Append("WHERE ")
        strSQL.Append("		A.KBN = '78' ")
        strSQL.Append("AND  A.CD = :JAGKBN ")


        '//------------------------------------------
        '//<TODO>�p�����[�^�̐ݒ�
        SqlParamC.fncSetParam("JAGKBN", True, hdnJAGKBN.Value.Trim)

        dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)



        '//------------------------------------------
        '//<TODO>���͒l��DB�̒l���r
        Dim GroupNM_header As String
        '2015/03/19 T.Ono mod START
        '1�������ƃG���[�ɂȂ��Ă��܂����ߏC��
        'GroupNM_header = txtGROUPCD_NEW.Text.Trim.Substring(0, 2)
        If txtGROUPCD_NEW.Text.Trim.Length < 2 Then
            Return False '1�����Ȃ�false��Ԃ�
        Else
            GroupNM_header = txtGROUPCD_NEW.Text.Trim.Substring(0, 2)
        End If
        '2015/03/19 T.Ono mod END

        If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
            res = False
        Else
            If Convert.ToString(dbData.Tables(0).Rows(0).Item("NAIYO1")) = GroupNM_header Then
                res = True
            Else
                res = False
            End If
        End If

        Return res
    End Function
    '******************************************************************************
    '*�O���[�v�ǉ��@DB�ɃO���[�v�R�[�h���o�^����Ă��邩�`�F�b�N�@True�F�o�^�Ȃ�(OK)�@False�F�o�^����(NG)
    '******************************************************************************
    Private Function fncChoufukuGroup() As Boolean

        Dim res As Boolean = False

        '//------------------------------------------
        '//<TODO>Select���̍쐬
        Dim SQLC As New MSJAGJAG00CCSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet

        If hdnJAGKBN.Value = "001" Then
            '�̔����Ǝ҃O���[�v�}�X�^
            strSQL.Append("SELECT ")
            strSQL.Append("		'X' ")
            strSQL.Append("FROM ")
            strSQL.Append("		M10_HANJIGYOSYA A ")
            strSQL.Append("WHERE ")
            strSQL.Append("		A.GROUPCD = :GROUPCD ")
        Else
            strSQL.Append("SELECT ")
            strSQL.Append("		'X' ")
            strSQL.Append("FROM ")
            strSQL.Append("		dual ")
        End If


        '//------------------------------------------
        '//<TODO>�p�����[�^�̐ݒ�
        SqlParamC.fncSetParam("GROUPCD", True, txtGROUPCD_NEW.Text.Trim)

        dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

        If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
            res = True
        Else
            res = False
        End If

        Return res
    End Function

    '�敪�R���{�{�b�N�X�쐬
    Private Sub fncCombo_Create_JAGKBN()
        cboJAGKBN.pComboTitle = False
        cboJAGKBN.pNoData = False
        cboJAGKBN.pType = "JAGKBN"               '//�O���[�v�敪
        cboJAGKBN.mMakeCombo()
    End Sub


End Class
