'***********************************************
' �����Z���^�[�}�X�^  ���C�����
'***********************************************
' �ύX����

Option Explicit On
Option Strict On

Imports Common
Imports Common.DB   ' 2023/01/26 ADD Y.ARAKAKI 2022�X��No�D _�����Ή����e�}�X�^_����x��No�̎g�p�t���O�ꊇ�ݒ�ǉ��Ή�
Imports JPG.Common
Imports JPG.Common.log

Imports System.Text


Partial Class MSJINJAG00
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

    '�R���{�{�b�N�X�̒l�i�[
    Private strCBO_PROCKBN(30) As String
    Private strCBO_TAIOKBN(30) As String
    Private strCBO_TMSKB(30) As String
    Private strCBO_TAITCD(30) As String
    Private strCBO_TFKICD(30) As String
    Private strCBO_TKIGCD(30) As String
    Private strCBO_TSADCD(30) As String
    Private strCBO_TELRCD(30) As String
    Private strCBO_USE_FLG(30) As String
    ' 2023/01/26 ADD START Y.ARAKAKI 2022�X��No�D _�����Ή����e�}�X�^_����x��No�̎g�p�t���O�ꊇ�ݒ�ǉ��Ή�
    Private strCBO_JTLISTFROM As String
    Private strCBO_JTLISTTO As String
    ' 2023/01/26 ADD END   Y.ARAKAKI 2022�X��No�D _�����Ή����e�}�X�^_����x��No�̎g�p�t���O�ꊇ�ݒ�ǉ��Ή�

    '******************************************************************************
    ' Page_Load
    '******************************************************************************
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '2012/04/03 NEC ou Add
        '.NET�̎d�l�ύX�ɂ��AReadOnly������ASPX�ł���ƁA�T�[�o���Œl�̎Q�Ƃ��ł��Ȃ��Ȃ邽�߁AVB����Attribute�ł���
        If MyBase.IsPostBack = False Then
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
        '2012/04/03 NEC ou Add
        txtGROUPCD.Attributes.Add("ReadOnly", "true")

        '//------------------------------------------
        '//�@HTTP�w�b�_�𑗐M
        HttpHeaderC.mNoCache(Response)

        '//------------------------------------------
        '//�@�F�؃N���X�̃C���X�^���X����
        AuthC = New CAuthenticate(Request, Response)

        '//------------------------------------------
        '//�@�F�؏���
        '<TODO>�F�g�p�\�������w�肷��
        '[�����Ή����e�}�X�^]�g�p�\����(�^:��/�c:�~/��:��/�o:�~)
        AuthC.fncAuthCheck(Server, AuthC.pGROUP_UNKOU & "," & AuthC.pGROUP_KANSHI)

        '//------------------------------------------
        '<TODO>�|�b�v�A�b�v/�o�^�n�t���[���̏o��
        '      [hdnKensaku(Hidden)]���쐬���鎖
        'If hdnKensaku.Value = "COPOPUPG00" Then
        '    Server.Transfer("../../../Popup/COPOPUPG00.aspx")
        'End If
        '�x��ꗗ��\������i�|�b�v�A�b�v�j
        If hdnKensaku.Value = "MSJINJCG00" Then
            Server.Transfer("MSJINJCG00.aspx")
        End If
        '2017/02/09 W.GANEKO ADD 2016�Ď����P
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
             MyBase.MapPath("../../../MS/MSJINJAG/MSJINJAG00/") & "MSJINJAG00.js"))
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


        Else
            '//--------------------------------------
            '//�@�Q��ڈȍ~���s�����
            '//--------------------------------------

            '2017/02/09 W.GANEKO DEL START 
            '�O���[�v�R�[�h�R���{�{�b�N�X�̍Đݒ�
            'Dim list As ListItem
            'fncCombo_Create_GROUPCD()
            'list = cboGROUPCD.Items.FindByValue(Request.Form("cboGROUPCD"))
            ''list = cboGROUPCD.Items.FindByText(hdnGROUPCD.Value.Trim)
            'cboGROUPCD.SelectedIndex = cboGROUPCD.Items.IndexOf(list)

            '�ꗗ�̃R���{�{�b�N�X�̍Đݒ�
            Dim i As Integer
            For i = 1 To 30
                fncCombo_Create_PROCKBN(i)
                fncCombo_Create_TAIOKBN(i)
                fncCombo_Create_TMSKB(i)
                fncCombo_Create_TAITCD(i)
                fncCombo_Create_TFKICD(i)
                fncCombo_Create_TKIGCD(i)
                fncCombo_Create_TSADCD(i)
                fncCombo_Create_TELRCD(i)
                fncCombo_Create_USE_FLG(i)

                fncComboGet(i) '�R���{�{�b�N�X�̎擾
                fncComboSet(i) '�R���{�{�b�N�X�̐ݒ�
            Next

            fncCombo_Create_JidouTaiouGroupList()  ' 2023/01/26 ADD Y.ARAKAKI 2022�X��No�D _�����Ή����e�}�X�^_����x��No�̎g�p�t���O�ꊇ�ݒ�ǉ��Ή�
            fncComboGetAndSet_FromTo() '��ʂɒl�ݒ肠��΁A����
        End If



        '<TODO>�����̉��ID��HIDDEN��hdnMyAspx�ɏ������ށi�V�X�e�����ʁj
        hdnMyAspx.Value = "MSJINJAG00"
        '//-------------------------------------------------

    End Sub

    '******************************************************************************
    '* ���������������O�̉�ʏ�ԁiReadOnly��Disabled�j
    '********************************/*********************************************
    Private Sub fncIni_statebf()
        '//--------------------------------------------------------------------------
        '<TODO>�����O�̏�ԂɃR���g���[���̏�Ԃ�ݒ肷��

        'btnGROUPCD.Disabled = False

    End Sub

    '******************************************************************************
    '* �������������ꂽ��̉�ʏ�ԁiReadOnly��Disabled�j
    '******************************************************************************
    Private Sub fncIni_stateaf()
        '//--------------------------------------------------------------------------
        '<TODO>������̏�ԂɃR���g���[���̏�Ԃ�ݒ肷��
        '
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
        txtGROUPCD.Text = ""       '2017/02/09 W.GANEKO ADD 2016�Ď����P ��10
        hdnGROUPCD.Value = ""
        txtGROUPCD_NEW.Text = ""
        'fncCombo_Create_GROUPCD() '�O���[�v�R�[�h

        '�L�[�ȊO�̒l������������
        Call fncIni_notkey()

    End Sub

    '******************************************************************************
    '* �L�[�ȊO�̒l������������
    '******************************************************************************
    Private Sub fncIni_notkey()
        '//--------------------------------------------------------------------------
        '<TODO>�R���g���[���̒l������������

        hdnGROUPCD_MOTO.Value = ""

        Dim objDEL As System.Web.UI.WebControls.CheckBox
        Dim objKMCD As System.Web.UI.WebControls.TextBox
        Dim objKMNM As System.Web.UI.WebControls.TextBox
        Dim objTKTANCD As System.Web.UI.WebControls.TextBox
        Dim objTEL_MEMO1 As System.Web.UI.WebControls.TextBox
        Dim objBIKO As System.Web.UI.WebControls.TextBox
        Dim objINS_DATE As System.Web.UI.HtmlControls.HtmlInputHidden
        Dim objUPD_DATE As System.Web.UI.HtmlControls.HtmlInputHidden

        txtGROUPNM.Text = "" '��ٰ�ߺ��ޖ�

        Dim i As Integer

        For i = 1 To 30
            '�R���g���[������T���o���A�^�ϊ�
            objDEL = CType(FindControl("chkDEL_" & CStr(i)), System.Web.UI.WebControls.CheckBox)
            objKMCD = CType(FindControl("txtKMCD_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objKMNM = CType(FindControl("txtKMNM_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objTKTANCD = CType(FindControl("txtTKTANCD_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objTEL_MEMO1 = CType(FindControl("txtTEL_MEMO1_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objBIKO = CType(FindControl("txtBIKO_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objINS_DATE = CType(FindControl("hdnINS_DATE_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
            objUPD_DATE = CType(FindControl("hdnUPD_DATE_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)

            objDEL.Checked = False
            objKMCD.Text = ""
            objKMNM.Text = ""
            objTKTANCD.Text = ""
            objTEL_MEMO1.Text = ""
            objBIKO.Text = ""
            objINS_DATE.Value = ""
            objUPD_DATE.Value = ""


            '�R���{�{�b�N�X�̏�����
            fncCombo_Create_PROCKBN(i)
            fncCombo_Create_TAIOKBN(i)
            fncCombo_Create_TMSKB(i)
            fncCombo_Create_TAITCD(i)
            fncCombo_Create_TFKICD(i)
            fncCombo_Create_TKIGCD(i)
            fncCombo_Create_TSADCD(i)
            fncCombo_Create_TELRCD(i)
            fncCombo_Create_USE_FLG(i)

        Next

        fncCombo_Create_JidouTaiouGroupList()  ' 2023/01/26 ADD Y.ARAKAKI 2022�X��No�D _�����Ή����e�}�X�^_����x��No�̎g�p�t���O�ꊇ�ݒ�ǉ��Ή�

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
        cboJTLISTFROM.Items.Clear() '//�������F�O���[�v�R�[�hListFrom
        cboJTLISTTO.Items.Clear() '//�������F�O���[�v�R�[�hListTo

        Call fncIni_format()    '//�l�̏�����
        Call fncIni_statebf()   '//��Ԃ̏�����

        '//------------------------------------------
        '<TODO>�t�H�[�J�X���Z�b�g����i������ʂɖ߂����̂�(PageLoad���l)�L�[�ɃZ�b�g�j
        strMsg.Append("Form1.btnSelect.focus();")
    End Sub

    ' 2023/02/07 ADD START Y.ARAKAKI 2022�X��No�D _�����Ή����e�}�X�^_����x��No�̎g�p�t���O�ꊇ�ݒ�ǉ��Ή�
    '******************************************************************************
    '* �X�V�F�g�p�� �{�^�����������ꂽ�Ƃ��̏��� 
    '******************************************************************************
    Private Sub btnUpdateJtFlgAllOn_ServerClick(ByVal sender As System.Object,
                                                ByVal e As System.EventArgs) Handles btnUpdateJtFlgAllOn.ServerClick
        Dim strRec As String
        strRec = fncbtnUpdFromTo_ClickEvent("1") '�X�V�����ďo�i1:�g�p�j

        Call fncIni_stateaf()
    End Sub
    '******************************************************************************
    '* �X�V�F�g�p�s�� �{�^�����������ꂽ�Ƃ��̏��� 
    '******************************************************************************
    Private Sub btnUpdateJtFlgAllOff_ServerClick(ByVal sender As System.Object,
                                                 ByVal e As System.EventArgs) Handles btnUpdateJtFlgAllOff.ServerClick
        Dim strRec As String
        strRec = fncbtnUpdFromTo_ClickEvent("2") '�X�V�����ďo�i2:�g�p�s�j

        Call fncIni_stateaf()
    End Sub
    ' 2023/02/07 ADD END   Y.ARAKAKI 2022�X��No�D _�����Ή����e�}�X�^_����x��No�̎g�p�t���O�ꊇ�ݒ�ǉ��Ή�

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


            '�L�[���i�[
            If pstrKBN = "2" Then
                '2017/02/09 W.GANEKO UPD START 2016�Ď����P
                '�o�^������B�O���[�v�R�[�h�̍폜�A�V�K�o�^�ɑΉ����邽�߁A�R���{�{�b�N�X���ăZ�b�g
                'Dim list As New ListItem
                ''�R���{�{�b�N�X���ăZ�b�g
                'fncCombo_Create_GROUPCD()
                ''�O���[�v�R�[�h��\��
                'list = cboGROUPCD.Items.FindByText(hdnGROUPCD.Value)
                'cboGROUPCD.SelectedIndex = cboGROUPCD.Items.IndexOf(list)
                '�폜�ɂ��O���[�v�R�[�h�����݂��Ȃ��Ȃ���
                'If cboGROUPCD.SelectedIndex.ToString = "0" Then
                '    hdnGROUPCD.Value = ""
                '    '//------------------------------
                '    '<TODO>�t�H�[�J�X���Z�b�g����i�f�[�^�����݂����̂ŃL�[�ȊO�ɃZ�b�g�j
                '    strMsg.Append("Form1.btnSelect.focus();")
                '    Return strRec
                'End If
            Else
                'hdnGROUPCD.Value = Convert.ToString(cboGROUPCD.Items.Item(CInt(Request.Form("cboGROUPCD"))))
            End If


            dbData = fncDataSelect()

            If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
                '�f�[�^�����݂��Ȃ��ׁA�����̓G���[
                '���b�Z�[�W���o�͌�A�����O��Ԃɂ���B

                strMsg.Append("alert('�f�[�^�����݂��܂���');")

                Call fncIni_statebf()

                '//------------------------------
                '<TODO>�t�H�[�J�X���Z�b�g����i�����{�^���փZ�b�g�j
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

                '�O���[�v�R�[�h
                hdnGROUPCD.Value = Convert.ToString(dbData.Tables(0).Rows(0).Item("GROUPCD"))
                hdnGROUPCD_MOTO.Value = Convert.ToString(dbData.Tables(0).Rows(0).Item("GROUPCD"))
                txtGROUPNM.Text = Convert.ToString(dbData.Tables(0).Rows(0).Item("GROUPNM"))          '2017/02/09 W.GANEKO ADD 2016�Ď����P

                ''�Ď��Z���^�[��
                'txtCODE.Text = Convert.ToString(dbData.Tables(0).Rows(0).Item("CODE")) & " : " & Convert.ToString(dbData.Tables(0).Rows(0).Item("KANSI_NAME"))


                Dim objKMCD As System.Web.UI.WebControls.TextBox
                Dim objKMNM As System.Web.UI.WebControls.TextBox
                Dim objTKTANCD As System.Web.UI.WebControls.TextBox
                Dim objTEL_MEMO1 As System.Web.UI.WebControls.TextBox
                Dim objBIKO As System.Web.UI.WebControls.TextBox
                Dim objINS_DATE As System.Web.UI.HtmlControls.HtmlInputHidden
                Dim objUPD_DATE As System.Web.UI.HtmlControls.HtmlInputHidden

                'Dim objPROCKBN As JPG.Common.Controls.CTLCombo
                'Dim objTAIOKBN As JPG.Common.Controls.CTLCombo
                'Dim objTMSKB As JPG.Common.Controls.CTLCombo
                'Dim objTAITCD As JPG.Common.Controls.CTLCombo
                'Dim objTFKICD As JPG.Common.Controls.CTLCombo
                'Dim objTKIGCD As JPG.Common.Controls.CTLCombo
                'Dim objTSADCD As JPG.Common.Controls.CTLCombo
                'Dim objTELRCD As JPG.Common.Controls.CTLCombo
                'Dim objUSE_FLG As JPG.Common.Controls.CTLCombo


                Dim intRow As Integer

                For intRow = 0 To dbData.Tables(0).Rows.Count - 1

                    If intRow >= 30 Then Exit For '30���ȏ�͏�������

                    '----------------------------
                    ' ���׏�����ʍ��ڂɃZ�b�g
                    '----------------------------
                    '�R���g���[������T���o���A�^�ϊ�
                    objKMCD = CType(FindControl("txtKMCD_" & CStr(intRow + 1)), System.Web.UI.WebControls.TextBox)
                    objKMNM = CType(FindControl("txtKMNM_" & CStr(intRow + 1)), System.Web.UI.WebControls.TextBox)
                    objTKTANCD = CType(FindControl("txtTKTANCD_" & CStr(intRow + 1)), System.Web.UI.WebControls.TextBox)
                    objTEL_MEMO1 = CType(FindControl("txtTEL_MEMO1_" & CStr(intRow + 1)), System.Web.UI.WebControls.TextBox)
                    objBIKO = CType(FindControl("txtBIKO_" & CStr(intRow + 1)), System.Web.UI.WebControls.TextBox)
                    objINS_DATE = CType(FindControl("hdnINS_DATE_" & CStr(intRow + 1)), System.Web.UI.HtmlControls.HtmlInputHidden)
                    objUPD_DATE = CType(FindControl("hdnUPD_DATE_" & CStr(intRow + 1)), System.Web.UI.HtmlControls.HtmlInputHidden)

                    '�L�[���ڂ͕ύX�s�ɂ���
                    objKMCD.ReadOnly = True
                    objKMCD.BackColor = Color.Gainsboro
                    objKMNM.ReadOnly = True
                    objKMNM.BackColor = Color.Gainsboro

                    'objPROCKBN = CType(FindControl("cboPROCKBN_" & CStr(intRow + 1)), JPG.Common.Controls.CTLCombo)
                    'objTAIOKBN = CType(FindControl("cboTAIOKBN_" & CStr(intRow + 1)), JPG.Common.Controls.CTLCombo)
                    'objTMSKB = CType(FindControl("cboTMSKB_" & CStr(intRow + 1)), JPG.Common.Controls.CTLCombo)
                    'objTAITCD = CType(FindControl("cboTAITCD_" & CStr(intRow + 1)), JPG.Common.Controls.CTLCombo)
                    'objTFKICD = CType(FindControl("cboTFKICD_" & CStr(intRow + 1)), JPG.Common.Controls.CTLCombo)
                    'objTKIGCD = CType(FindControl("cboTKIGCD_" & CStr(intRow + 1)), JPG.Common.Controls.CTLCombo)
                    'objTSADCD = CType(FindControl("cboTSADCD_" & CStr(intRow + 1)), JPG.Common.Controls.CTLCombo)
                    'objTELRCD = CType(FindControl("cboTELRCD_" & CStr(intRow + 1)), JPG.Common.Controls.CTLCombo)
                    'objUSE_FLG = CType(FindControl("cboUSE_FLG_" & CStr(intRow + 1)), JPG.Common.Controls.CTLCombo)

                    objKMCD.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("KMCD"))
                    objKMNM.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("KMNM"))
                    objTKTANCD.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("TKTANCD"))
                    objTEL_MEMO1.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("TEL_MEMO1"))
                    objBIKO.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("BIKO"))
                    objINS_DATE.Value = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("INS_DATE"))
                    objUPD_DATE.Value = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("UPD_DATE"))

                    'objPROCKBN.SelectedIndex = Convert.ToInt32(dbData.Tables(0).Rows(intRow).Item("PROCKBN"))
                    'objTAIOKBN.SelectedIndex = Convert.ToInt32(dbData.Tables(0).Rows(intRow).Item("TAIOKBN"))
                    'objTMSKB.SelectedIndex = Convert.ToInt32(dbData.Tables(0).Rows(intRow).Item("TMSKB"))
                    'objTAITCD.SelectedIndex = Convert.ToInt32(dbData.Tables(0).Rows(intRow).Item("TAITCD"))
                    'objTFKICD.SelectedIndex = Convert.ToInt32(dbData.Tables(0).Rows(intRow).Item("TFKICD"))
                    'objTKIGCD.SelectedIndex = Convert.ToInt32(dbData.Tables(0).Rows(intRow).Item("TKIGCD"))
                    'objTSADCD.SelectedIndex = Convert.ToInt32(dbData.Tables(0).Rows(intRow).Item("TSADCD"))
                    'objTELRCD.SelectedIndex = Convert.ToInt32(dbData.Tables(0).Rows(intRow).Item("TELRCD"))
                    'objUSE_FLG.SelectedIndex = Convert.ToInt32(dbData.Tables(0).Rows(intRow).Item("USE_FLG"))


                    strCBO_PROCKBN(intRow + 1) = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("PROCKBN"))
                    strCBO_TAIOKBN(intRow + 1) = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("TAIOKBN"))
                    strCBO_TMSKB(intRow + 1) = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("TMSKB"))
                    strCBO_TAITCD(intRow + 1) = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("TAITCD"))
                    strCBO_TFKICD(intRow + 1) = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("TFKICD"))
                    strCBO_TKIGCD(intRow + 1) = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("TKIGCD"))
                    strCBO_TSADCD(intRow + 1) = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("TSADCD"))
                    strCBO_TELRCD(intRow + 1) = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("TELRCD"))
                    strCBO_USE_FLG(intRow + 1) = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("USE_FLG"))

                    fncComboSet(intRow + 1)
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
        '�l��z��ɃZ�b�g
        Dim objKMCD As System.Web.UI.WebControls.TextBox
        Dim objKMNM As System.Web.UI.WebControls.TextBox
        Dim objTKTANCD As System.Web.UI.WebControls.TextBox
        Dim objTEL_MEMO1 As System.Web.UI.WebControls.TextBox
        Dim objBIKO As System.Web.UI.WebControls.TextBox
        Dim objINS_DATE As System.Web.UI.HtmlControls.HtmlInputHidden
        Dim objUPD_DATE As System.Web.UI.HtmlControls.HtmlInputHidden
        Dim objDEL As System.Web.UI.WebControls.CheckBox

        Dim sKMCD(30) As String
        Dim sKMNM(30) As String
        Dim sPROCKBN(30) As String
        Dim sTAIOKBN(30) As String
        Dim sTMSKB(30) As String
        Dim sTKTANCD(30) As String
        Dim sTAITCD(30) As String
        Dim sTFKICD(30) As String
        Dim sTKIGCD(30) As String
        Dim sTSADCD(30) As String
        Dim sTELRCD(30) As String
        Dim sTEL_MEMO1(30) As String
        Dim sUSE_FLG(30) As String
        Dim sINS_DATE(30) As String
        Dim sUPD_DATE(30) As String
        Dim sBIKO(30) As String
        Dim sDEL(30) As String

        Dim i As Integer
        '//------------------------------------------
        '<TODO>�Ǝ���WEB�T�[�r����錾����
        Dim MSJINJAW00C As New MSJINJAG00MSJINJAW00.MSJINJAW00

        '//-----------------------------------------------
        '<TODO>�O���[�v�R�[�h
        Dim strGROUPCD As String
        Dim bolCHKGROUPCD As Boolean = True 'True:OK False:NG
        Dim bolCHKJAGROUPCD As Boolean = True 'True:OK False:NG   '2017/02/09 W.GANEKO ADD 2016�Ď����P
        Dim bolCHKSTRGROUPCD As Boolean = True 'True:OK False:NG   '2017/02/09 W.GANEKO ADD 2016�Ď����P
        Dim strGROUPCDNM As String
        If pstrKBN = "1" AndAlso txtGROUPCD_NEW.Text.Trim <> "" Then
            '�O���[�v�R�[�h�̐V�K�o�^
            bolCHKGROUPCD = fncchkGROUPCD(txtGROUPCD_NEW.Text.Trim) '���͂����O���[�v�R�[�h�����ɂ���ꍇ��NG
            bolCHKSTRGROUPCD = fncCHKSTRGROUPCD(txtGROUPCD_NEW.Text.Trim) '2017/02/09 W.GANEKO ADD 2016�Ď����P
            strGROUPCD = txtGROUPCD_NEW.Text.Trim
            hdnGROUPCD.Value = txtGROUPCD_NEW.Text.Trim
            strGROUPCDNM = txtGROUPNM.Text.Trim     '2017/02/09 W.GANEKO ADD 2016�Ď����P
        Else
            '�O���[�v�o�^�I��
            'hdnGROUPCD.Value = Convert.ToString(cboGROUPCD.Items.Item(CInt(Request.Form("cboGROUPCD"))))
            '2017/02/09 W.GANEKO ADD 2016�Ď����P
            If pstrKBN = "4" Then
                bolCHKJAGROUPCD = fncchkJAGROUPCD(hdnGROUPCD.Value.Trim) '���͂���JA�O���[�v�R�[�h�����ɂ���ꍇ��NG
            End If
            strGROUPCD = hdnGROUPCD.Value
            strGROUPCDNM = txtGROUPNM.Text.Trim  '2017/02/09 W.GANEKO ADD 2016�Ď����P
        End If

        If bolCHKGROUPCD = False Then
            '�V�K�̏ꍇ�B�O���[�v�R�[�h�����ɑ��݂���
            strRec = "4"
        ElseIf bolCHKSTRGROUPCD = False Then '2017/02/09 W.GANEKO ADD 2016�Ď����P
            '�V�K�̏ꍇ�B�O���[�v�R�[�h�̓�2�������Ⴄ
            strRec = "6"
        ElseIf pstrKBN = "4" AndAlso bolCHKJAGROUPCD = False AndAlso fncchkJAGROUPDEL(hdnGROUPCD.Value.Trim) = False Then '2017/03/09 T.Ono mod 2016�Ď����P
            'ElseIf pstrKBN = "4" AndAlso bolCHKJAGROUPCD = False Then '2017/02/09 W.GANEKO ADD 2016�Ď����P
            '�폜�̏ꍇ�BJA�O���[�v�R�[�h�����ɑ��݂���
            strRec = "5"
        Else


            For i = 1 To 30
                '�R���g���[������T���o���A�^�ϊ�
                objKMCD = CType(FindControl("txtKMCD_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                objKMNM = CType(FindControl("txtKMNM_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                objTKTANCD = CType(FindControl("txtTKTANCD_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                objTEL_MEMO1 = CType(FindControl("txtTEL_MEMO1_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                objBIKO = CType(FindControl("txtBIKO_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                objINS_DATE = CType(FindControl("hdnINS_DATE_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
                objUPD_DATE = CType(FindControl("hdnUPD_DATE_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
                objDEL = CType(FindControl("chkDEL_" & CStr(i)), System.Web.UI.WebControls.CheckBox)

                sKMCD(i) = objKMCD.Text.Trim
                sKMNM(i) = objKMNM.Text.Trim
                sPROCKBN(i) = Request.Form("cboPROCKBN_" & i)
                sTAIOKBN(i) = Request.Form("cboTAIOKBN_" & i)
                sTMSKB(i) = Request.Form("cboTMSKB_" & i)
                sTAITCD(i) = Request.Form("cboTAITCD_" & i)
                sTFKICD(i) = Request.Form("cboTFKICD_" & i)
                sTKIGCD(i) = Request.Form("cboTKIGCD_" & i)
                sTSADCD(i) = Request.Form("cboTSADCD_" & i)
                sTELRCD(i) = Request.Form("cboTELRCD_" & i)
                sTEL_MEMO1(i) = objTEL_MEMO1.Text.Trim
                sUSE_FLG(i) = Request.Form("cboUSE_FLG_" & i)
                sINS_DATE(i) = objINS_DATE.Value.Trim
                sUPD_DATE(i) = objUPD_DATE.Value.Trim
                sBIKO(i) = objBIKO.Text.Trim

                '�S���҃R�[�h�@�����Ή��ŒS���҃R�[�h�󔒂̏ꍇ��"999"���Z�b�g
                If sPROCKBN(i) = "1" AndAlso objTKTANCD.Text.Trim = "" Then
                    sTKTANCD(i) = "999"
                Else
                    sTKTANCD(i) = objTKTANCD.Text.Trim
                End If

                If (objDEL.Checked) Then
                    sDEL(i) = "true"
                Else
                    sDEL(i) = "false"
                End If

            Next
            '2017/02/09 W.GANEKO UPD 2016�Ď����P
            'strRec = MSJINJAW00C.mSetEx( _
            '            CInt(pstrKBN), _
            '            strGROUPCD, _
            '            sKMCD, _
            '            sKMNM, _
            '            sPROCKBN, _
            '            sTAIOKBN, _
            '            sTMSKB, _
            '            sTKTANCD, _
            '            sTAITCD, _
            '            sTFKICD, _
            '            sTKIGCD, _
            '            sTSADCD, _
            '            sTELRCD, _
            '            sTEL_MEMO1, _
            '            sUSE_FLG, _
            '            sINS_DATE, _
            '            sUPD_DATE, _
            '            sBIKO, _
            '            sDEL)
            strRec = MSJINJAW00C.mSetEx( _
                         CInt(pstrKBN), _
                         strGROUPCD, _
                         sKMCD, _
                         sKMNM, _
                         sPROCKBN, _
                         sTAIOKBN, _
                         sTMSKB, _
                         sTKTANCD, _
                         sTAITCD, _
                         sTFKICD, _
                         sTKIGCD, _
                         sTSADCD, _
                         sTELRCD, _
                         sTEL_MEMO1, _
                         sUSE_FLG, _
                         sINS_DATE, _
                         sUPD_DATE, _
                         sBIKO, _
                         sDEL, _
                         strGROUPCDNM _
                         )
        End If


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
                'strRecMsg = "���Ƀf�[�^�����݂��܂�"
                strRecMsg = "���ɃO���[�v�R�[�h�����݂��܂�"
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
                strRecMsg = "���ɃO���[�v�R�[�h�����݂��܂�"
                strMsg.Append("alert('" & strRecMsg & "');")

                '<TODO>�t�H�[�J�X���Z�b�g����i�o�^�E�C�����ł̃G���[�B�V�K�o�^�p���͗��ɃZ�b�g�j
                strMsg.Append("Form1.txtGROUPCD_NEW.focus();")

                strRec = strRecMsg
            Case "5"
                '2017/02/09 W.GANEKO ADD 2016�Ď����P
                strRecMsg = "JA�O���[�v�쐬�}�X�^�Ŏg�p����Ă���f�[�^������܂��B\n�f�[�^���m�F���ĉ������B"
                strMsg.Append("alert('" & strRecMsg & "');")

                '<TODO>�t�H�[�J�X���Z�b�g����i�o�^�E�C�����ł̃G���[�B�V�K�o�^�p���͗��ɃZ�b�g�j
                strMsg.Append("Form1.btnSelect.focus();")

                strRec = strRecMsg
            Case "6"
                '2017/02/09 W.GANEKO ADD 2016�Ď����P
                strRecMsg = "�O���[�v�R�[�h���s���ł��B\n�擪�ɏ���̃A���t�@�x�b�g2��������͂��Ă��������B"
                strMsg.Append("alert('" & strRecMsg & "');")

                '<TODO>�t�H�[�J�X���Z�b�g����i�o�^�E�C�����ł̃G���[�B�V�K�o�^�p���͗��ɃZ�b�g�j
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
                    strMsg.Append("Form1.txtKMCD_1.focus();")
                Else
                    '//----------------------------------
                    '<TODO>�t�H�[�J�X���Z�b�g����i���̑��@�F���O�o�͂̃G���[�̈׃L�[�ȍ~�ɃZ�b�g�j
                    strMsg.Append("Form1.txtKMCD_1.focus();")
                End If
        End Select
        If pstrKBN <> "1" Then
            For i = 1 To 30
                objKMCD = CType(FindControl("txtKMCD_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                objKMNM = CType(FindControl("txtKMNM_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                If objKMCD.Text <> "" Then
                    objKMCD.ReadOnly = True
                    objKMCD.BackColor = Color.Gainsboro
                    objKMNM.ReadOnly = True
                    objKMNM.BackColor = Color.Gainsboro
                End If
            Next
        End If
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

    ' 2023/02/07 ADD START Y.ARAKAKI 2022�X��No�D _�����Ή����e�}�X�^_����x��No�̎g�p�t���O�ꊇ�ݒ�ǉ��Ή�
    '******************************************************************************
    '* �o�^�E�폜���������ꂽ�Ƃ��̏���
    '******************************************************************************
    Private Function fncbtnUpdFromTo_ClickEvent(ByVal updKbn As String) As String
        Dim strRec As String
        strRec = "OK" '�����l�F�X�VOK�@�㑱�ŃG���[������Ώ㏑�������B

        '//�`�o���O�������� (S03_APLOGDB�ɁA������s���ʂ̃��O���������ށB���s�敪�͂Q�F�C���ň������Ƃɂ���B)
        Dim LogC As New CLog
        Dim strRecLog As String
        Dim pstrKBN As String
        pstrKBN = "2" ' ����̐��́����s�敪�B S03_APLOGDB.EXEC_STATUS �� �y���s�敪�z�P�F�o�^�@�Q�F�C���@�R�F�폜�@�S�F�Ɖ�i�ꗗ�o�́j

        Dim groupCdFromValue As String  '��ʁF�O���[�v�R�[�h�iFROM)
        Dim groupCdToValue As String    '��ʁF�O���[�v�R�[�h�iTO)
        '��ʂ��l���擾(JS�`�F�b�N���Ă�̂ŁA�K���l����A�Ȃ�����FROM-TO�Ԃ̎w��͈͂͐������O��B)
        groupCdFromValue = Request.Form("cboJTLISTFROM")
        groupCdToValue = Request.Form("cboJTLISTTO")

        Dim ds As New DataSet
        Dim cdb As New CDB
        Dim strSQL As StringBuilder

        Try
            '�ڑ�OPEN----------------------------------------
            cdb.mOpen()
            '�g�����U�N�V�����J�n--------------------------
            cdb.mBeginTrans()

            '1.�X�V�O�����i�r�����b�N�j
            strSQL = New StringBuilder("")
            strSQL.Append("SELECT ")
            strSQL.Append(" 	    A.USE_FLG ")
            strSQL.Append(" 	    ,A.UPD_DATE ")
            strSQL.Append("FROM ")
            strSQL.Append("		M08_AUTOTAIOU A ")
            strSQL.Append("WHERE ")
            strSQL.Append("		A.GROUPCD BETWEEN :GRPCDFROM AND :GRPCDTO ")
            strSQL.Append("AND		A.KMCD IN  ('08','15') ")
            strSQL.Append("ORDER BY A.GROUPCD, A.KMCD ")
            strSQL.Append("FOR UPDATE NOWAIT ")             '�r�������������

            'SQL���Z�b�g
            cdb.pSQL = strSQL.ToString
            '�p�����[�^�ɒl���Z�b�g
            cdb.pSQLParamStr("GRPCDFROM") = groupCdFromValue  '�O���[�v�R�[�h(FROM)
            cdb.pSQLParamStr("GRPCDTO") = groupCdToValue      '�O���[�v�R�[�h(TO)

            'SQL���s
            cdb.mExecQuery()
            ds = cdb.pResult

            If (ds.Tables(0).Rows.Count <> 0) Then '�c�a�Ƀf�[�^�����݂���H
                '2.�X�V�����A���{�B
                strSQL = New StringBuilder("")
                strSQL.Append("UPDATE ")
                strSQL.Append("         M08_AUTOTAIOU ")
                strSQL.Append("SET ")
                strSQL.Append("     	USE_FLG = :USE_FLG, ")
                strSQL.Append("     	UPD_DATE = TO_DATE(:UPD_DATE, 'YYYY/MM/DD HH24:MI:SS') ")
                strSQL.Append("WHERE   ")
                strSQL.Append("		GROUPCD BETWEEN :GRPCDFROM AND :GRPCDTO ")
                strSQL.Append("     AND KMCD IN  ('08','15') ") '�x�񃁃b�Z�[�WNo�c�Œ�l 08�F���k��Ւf�A15�F���S�m�F���Ւf

                'SQL���Z�b�g
                cdb.pSQL = strSQL.ToString

                '�p�����[�^�ɒl���Z�b�g
                '��ʂ̃{�^�������ɂ���āA�g�p�t���O�̒l��ύX����B
                If updKbn = "1" Then '�g�p�{�^�����������g�p�t���O�� 1:�g�p�\ �Ƃ���B
                    cdb.pSQLParamStr("USE_FLG") = "1"  '�g�p�t���O    1:�g�p�\  0:�g�p�s��
                ElseIf updKbn = "2" Then '�g�p�s�{�^�����������g�p�t���O�� 0:�g�p�s�� �Ƃ���B
                    cdb.pSQLParamStr("USE_FLG") = "0"  '�g�p�t���O    1:�g�p�\  0:�g�p�s��
                End If
                cdb.pSQLParamStr("UPD_DATE") = Now.ToString()  '�V�X�e�����t
                cdb.pSQLParamStr("GRPCDFROM") = groupCdFromValue  '�O���[�v�R�[�h(FROM)
                cdb.pSQLParamStr("GRPCDTO") = groupCdToValue      '�O���[�v�R�[�h(TO)

                'SQL�����s(�X�V)
                cdb.mExecNonQuery()

            End If

            '�R�~�b�g
            cdb.mCommit()

            strMsg.Append("alert('����ɏI�����܂���');")
            strMsg.Append("Form1.btnSelect.focus();") '<TODO>�t�H�[�J�X���Z�b�g����i�����{�^���ɃZ�b�g�j

        Catch ex As Exception

            '�r�����䏈���G���[
            If ErrorToString.Substring(0, 9) = "ORA-00054" Then
                strRec = "�r�����䏈���ŃG���[���������܂����B�ēx���s���Ă�������"
                strMsg.Append("alert('" & strRec & "');")

                '�G���[���O�����ODB�ɓo�^
                strRecLog = LogC.mAPLog(Me.Session.SessionID, AuthC.pUSERNAME, AuthC.pIPADDRESS, hdnMyAspx.Value, pstrKBN, strRec, Request.Form)

                If strRecLog <> "OK" Then
                    Dim errmsgc As New CErrMsg
                    strMsg.Append("alert('�V�X�e���G���[�F" & errmsgc.mGetArtMsg(strRecLog) & "');")
                End If

                Return "3"
            End If
            '�G���[���N������ �G���[���e���i�[
            strRec = "�V�X�e���G���[�F" & ex.ToString

            strMsg.Append("alert('" & strRec & "');")
            '<TODO>�t�H�[�J�X���Z�b�g����i�o�^�E�C���E�폜���ł̃G���[�B�I���{�^���ɃZ�b�g�j
            strMsg.Append("Form1.btnExit.focus();")

            '���[���o�b�N
            cdb.mRollback()
            strRec = strRec & cdb.pErr
        Finally
            '�ڑ��N���[�Y
            cdb.mClose()
        End Try

        cdb = Nothing

        '���O����
        strRecLog = LogC.mAPLog(Me.Session.SessionID, AuthC.pUSERNAME, AuthC.pIPADDRESS, hdnMyAspx.Value, pstrKBN, strRec, Request.Form)

        If strRecLog <> "OK" Then
            Dim errmsgc As New CErrMsg
            strMsg.Append("alert('�V�X�e���G���[�F" & errmsgc.mGetArtMsg(strRecLog) & "');")
        End If

        '(�O���[�vCD���I������Ă���ꍇ�̂�)�����������{�B�Q�F�o�^or�X�V������̌��� 
        If hdnGROUPCD.Value.Trim.Length > 0 Then
            fncbtnKensaku_ClickEvent("2")
        End If

        Return strRec
    End Function
    ' 2023/02/07 ADD END   Y.ARAKAKI 2022�X��No�D _�����Ή����e�}�X�^_����x��No�̎g�p�t���O�ꊇ�ݒ�ǉ��Ή�

    '******************************************************************************
    '* ���̓L�[�ɂ��f�[�^�̌������s���܂��B
    '******************************************************************************
    Private Function fncDataSelect() As DataSet

        '//------------------------------------------
        '//<TODO>Select���̍쐬
        Dim SQLC As New MSJINJAG00CCSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet

        strSQL.Append("SELECT  ")
        strSQL.Append("	    A.GROUPCD ")
        strSQL.Append("	    ,A.KMCD ")
        strSQL.Append("	    ,A.KMNM ")
        strSQL.Append("	    ,A.PROCKBN ")
        strSQL.Append("	    ,A.TAIOKBN ")
        strSQL.Append("	    ,A.TMSKB ")
        strSQL.Append("	    ,A.TKTANCD ")
        strSQL.Append("	    ,A.TAITCD ")
        strSQL.Append("	    ,A.TFKICD ")
        strSQL.Append("	    ,A.TKIGCD ")
        strSQL.Append("	    ,A.TSADCD ")
        strSQL.Append("	    ,A.TELRCD ")
        strSQL.Append("	    ,A.TEL_MEMO1 ")
        strSQL.Append("	    ,A.USE_FLG ")
        strSQL.Append("	    ,A.INS_DATE ")
        strSQL.Append("	    ,A.UPD_DATE ")
        strSQL.Append("	,   A.BIKO ")
        strSQL.Append("	,   A.GROUPNM ")     '2017/02/09 W.GANEKO ADD 2016�Ď����P ��10
        strSQL.Append("FROM ")
        strSQL.Append("	    M08_AUTOTAIOU A ")
        strSQL.Append("WHERE ")
        strSQL.Append("     GROUPCD = :GROUPCD ")
        strSQL.Append("ORDER BY KMCD ")


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
        Dim MSJINJAW00C As New MSJINJAG00MSJINJAW00.MSJINJAW00

        '//�@�F�؃N���X�̃C���X�^���X����
        AuthC = New CAuthenticate(Request, Response)

        Dim strRecMsg As String = ""

        '�L�[���i�[
        'hdnGROUPCD.Value = Convert.ToString(cboGROUPCD.Items.Item(CInt(Request.Form("cboGROUPCD"))))

        strRec = MSJINJAW00C.mCSV( _
                         Me.Session.SessionID, _
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
            HttpHeaderC.mDownLoadCSV(Response, "�����Ή����e�}�X�^.csv")
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
    '* �R���{�{�b�N�X�̓��͒l�擾
    '**************************************************
    Private Sub fncComboGet(ByVal i As Integer)
        Dim obj As JPG.Common.Controls.CTLCombo

        obj = CType(FindControl("cboPROCKBN_" & CStr(i)), JPG.Common.Controls.CTLCombo)
        strCBO_PROCKBN(i) = Request.Form(obj.ID)

        obj = CType(FindControl("cboTAIOKBN_" & CStr(i)), JPG.Common.Controls.CTLCombo)
        strCBO_TAIOKBN(i) = Request.Form(obj.ID)

        obj = CType(FindControl("cboTMSKB_" & CStr(i)), JPG.Common.Controls.CTLCombo)
        strCBO_TMSKB(i) = Request.Form(obj.ID)

        obj = CType(FindControl("cboTAITCD_" & CStr(i)), JPG.Common.Controls.CTLCombo)
        strCBO_TAITCD(i) = Request.Form(obj.ID)

        obj = CType(FindControl("cboTFKICD_" & CStr(i)), JPG.Common.Controls.CTLCombo)
        strCBO_TFKICD(i) = Request.Form(obj.ID)

        obj = CType(FindControl("cboTKIGCD_" & CStr(i)), JPG.Common.Controls.CTLCombo)
        strCBO_TKIGCD(i) = Request.Form(obj.ID)

        obj = CType(FindControl("cboTSADCD_" & CStr(i)), JPG.Common.Controls.CTLCombo)
        strCBO_TSADCD(i) = Request.Form(obj.ID)

        obj = CType(FindControl("cboTELRCD_" & CStr(i)), JPG.Common.Controls.CTLCombo)
        strCBO_TELRCD(i) = Request.Form(obj.ID)

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

        If strCBO_PROCKBN(i) <> "" Then
            obj = CType(FindControl("cboPROCKBN_" & CStr(i)), JPG.Common.Controls.CTLCombo)
            list = obj.Items.FindByValue(strCBO_PROCKBN(i))
            obj.SelectedIndex = obj.Items.IndexOf(list)
        End If

        If strCBO_TAIOKBN(i) <> "" Then
            obj = CType(FindControl("cboTAIOKBN_" & CStr(i)), JPG.Common.Controls.CTLCombo)
            list = obj.Items.FindByValue(strCBO_TAIOKBN(i))
            obj.SelectedIndex = obj.Items.IndexOf(list)
        End If

        If strCBO_TMSKB(i) <> "" Then
            obj = CType(FindControl("cboTMSKB_" & CStr(i)), JPG.Common.Controls.CTLCombo)
            list = obj.Items.FindByValue(strCBO_TMSKB(i))
            obj.SelectedIndex = obj.Items.IndexOf(list)
        End If

        If strCBO_TAITCD(i) <> "" Then
            obj = CType(FindControl("cboTAITCD_" & CStr(i)), JPG.Common.Controls.CTLCombo)
            list = obj.Items.FindByValue(strCBO_TAITCD(i))
            obj.SelectedIndex = obj.Items.IndexOf(list)
        End If

        If strCBO_TFKICD(i) <> "" Then
            obj = CType(FindControl("cboTFKICD_" & CStr(i)), JPG.Common.Controls.CTLCombo)
            list = obj.Items.FindByValue(strCBO_TFKICD(i))
            obj.SelectedIndex = obj.Items.IndexOf(list)
        End If

        If strCBO_TKIGCD(i) <> "" Then
            obj = CType(FindControl("cboTKIGCD_" & CStr(i)), JPG.Common.Controls.CTLCombo)
            list = obj.Items.FindByValue(strCBO_TKIGCD(i))
            obj.SelectedIndex = obj.Items.IndexOf(list)
        End If

        If strCBO_TSADCD(i) <> "" Then
            obj = CType(FindControl("cboTSADCD_" & CStr(i)), JPG.Common.Controls.CTLCombo)
            list = obj.Items.FindByValue(strCBO_TSADCD(i))
            obj.SelectedIndex = obj.Items.IndexOf(list)
        End If

        If strCBO_TELRCD(i) <> "" Then
            obj = CType(FindControl("cboTELRCD_" & CStr(i)), JPG.Common.Controls.CTLCombo)
            list = obj.Items.FindByValue(strCBO_TELRCD(i))
            obj.SelectedIndex = obj.Items.IndexOf(list)
        End If

        If strCBO_USE_FLG(i) <> "" Then
            obj = CType(FindControl("cboUSE_FLG_" & CStr(i)), JPG.Common.Controls.CTLCombo)
            list = obj.Items.FindByValue(strCBO_USE_FLG(i))
            obj.SelectedIndex = obj.Items.IndexOf(list)
        End If

    End Sub

    ' 2023/02/07 ADD START Y.ARAKAKI 2022�X��No�D _�����Ή����e�}�X�^_����x��No�̎g�p�t���O�ꊇ�ݒ�ǉ��Ή�
    '**************************************************
    '* �R���{�{�b�N�X�̓��͒l�擾�{�ݒ�(�O���[�v�R�[�hFromTo) '��ʂ̒l�ێ��p�Ɏg�p�B
    '**************************************************
    Private Sub fncComboGetAndSet_FromTo()
        Dim objFrom As JPG.Common.Controls.CTLCombo
        Dim objTo As JPG.Common.Controls.CTLCombo

        '��ʂ̒l�ێ�
        objFrom = CType(FindControl("cboJTLISTFROM"), JPG.Common.Controls.CTLCombo)
        objTo = CType(FindControl("cboJTLISTTO"), JPG.Common.Controls.CTLCombo)
        strCBO_JTLISTFROM = Request.Form(objFrom.ID)
        strCBO_JTLISTTO = Request.Form(objTo.ID)

        '������ʂ̒l�ێ�������΁A��������B
        Dim listFrom As New ListItem
        Dim listTo As New ListItem
        If strCBO_JTLISTFROM <> "" Then
            listFrom = objFrom.Items.FindByValue(strCBO_JTLISTFROM)
            objFrom.SelectedIndex = objFrom.Items.IndexOf(listFrom)
        End If
        If strCBO_JTLISTTO <> "" Then
            listTo = objTo.Items.FindByValue(strCBO_JTLISTTO)
            objTo.SelectedIndex = objTo.Items.IndexOf(listTo)
        End If
    End Sub
    ' 2023/02/07 ADD END   Y.ARAKAKI 2022�X��No�D _�����Ή����e�}�X�^_����x��No�̎g�p�t���O�ꊇ�ݒ�ǉ��Ή�

    '2017/02/09 W.GANEKO DEL 2016�Ď����P ��10
    '�O���[�v�R�[�h�iKEY�j
    'Private Sub fncCombo_Create_GROUPCD()

    '    cboGROUPCD.Items.Clear()

    '    Dim dbData As DataSet
    '    dbData = fncGET_GROUPCD()

    '    If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
    '        cboGROUPCD.Items.Add(New ListItem("", ""))
    '    Else
    '        Dim intRow As Integer
    '        cboGROUPCD.Items.Add(New ListItem("", ""))
    '        For intRow = 0 To dbData.Tables(0).Rows.Count - 1
    '            cboGROUPCD.Items.Add(New ListItem(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("GROUPCD")), CStr(intRow + 1)))
    '        Next
    '    End If

    'End Sub
    '�Ή��^�Ή������敪
    Private Sub fncCombo_Create_PROCKBN(ByVal i As Integer)
        Dim objPROCKBN As JPG.Common.Controls.CTLCombo
        objPROCKBN = CType(FindControl("cboPROCKBN_" & CStr(i)), JPG.Common.Controls.CTLCombo)
        objPROCKBN.Items.Clear()
        objPROCKBN.Items.Add(New ListItem("", ""))
        objPROCKBN.Items.Add(New ListItem("1�F�����Ή�", "1"))
        objPROCKBN.Items.Add(New ListItem("2�F����", "2"))
        objPROCKBN.Items.Add(New ListItem("3�F�����i�Z�L�����e�B���Q�Ɓj", "3"))
        objPROCKBN.Items.Add(New ListItem("4�F�d���\��", "4"))
    End Sub
    '�Ή��敪
    Private Sub fncCombo_Create_TAIOKBN(ByVal i As Integer)
        Dim objTAIOKBN As JPG.Common.Controls.CTLCombo
        objTAIOKBN = CType(FindControl("cboTAIOKBN_" & CStr(i)), JPG.Common.Controls.CTLCombo)
        objTAIOKBN.pComboTitle = True
        objTAIOKBN.pNoData = False
        objTAIOKBN.pType = "TAIOUKBN"               '//�Ή��敪
        objTAIOKBN.mMakeCombo()
    End Sub
    '�����敪
    Private Sub fncCombo_Create_TMSKB(ByVal i As Integer)
        Dim objTMSKB As JPG.Common.Controls.CTLCombo
        objTMSKB = CType(FindControl("cboTMSKB_" & CStr(i)), JPG.Common.Controls.CTLCombo)
        objTMSKB.pComboTitle = True
        objTMSKB.pNoData = False
        objTMSKB.pType = "SYORIKBN"               '//�����敪
        objTMSKB.mMakeCombo()
    End Sub
    '�A������
    Private Sub fncCombo_Create_TAITCD(ByVal i As Integer)
        Dim objTAITCD As JPG.Common.Controls.CTLCombo
        objTAITCD = CType(FindControl("cboTAITCD_" & CStr(i)), JPG.Common.Controls.CTLCombo)
        objTAITCD.pComboTitle = True
        objTAITCD.pNoData = False
        objTAITCD.pType = "RENRAKUA"               '//�A������
        objTAITCD.mMakeCombo()
    End Sub
    '���A�Ή���
    Private Sub fncCombo_Create_TFKICD(ByVal i As Integer)
        Dim objTFKICD As JPG.Common.Controls.CTLCombo
        objTFKICD = CType(FindControl("cboTFKICD_" & CStr(i)), JPG.Common.Controls.CTLCombo)
        objTFKICD.pComboTitle = True
        objTFKICD.pNoData = False
        objTFKICD.pType = "HUKKITAI"               '//���A�Ή���
        objTFKICD.mMakeCombo()
    End Sub
    '�K�X���
    Private Sub fncCombo_Create_TKIGCD(ByVal i As Integer)
        Dim objTKIGCD As JPG.Common.Controls.CTLCombo
        objTKIGCD = CType(FindControl("cboTKIGCD_" & CStr(i)), JPG.Common.Controls.CTLCombo)
        objTKIGCD.pComboTitle = True
        objTKIGCD.pNoData = False
        objTKIGCD.pType = "GAKUKIGU"               '//�K�X���
        objTKIGCD.mMakeCombo()
    End Sub
    '�쓮����
    Private Sub fncCombo_Create_TSADCD(ByVal i As Integer)
        Dim objTSADCD As JPG.Common.Controls.CTLCombo
        objTSADCD = CType(FindControl("cboTSADCD_" & CStr(i)), JPG.Common.Controls.CTLCombo)
        objTSADCD.pComboTitle = True
        objTSADCD.pNoData = False
        objTSADCD.pType = "SADOUGEN"               '//�쓮����
        objTSADCD.mMakeCombo()
    End Sub
    '�d�b�A�����e
    Private Sub fncCombo_Create_TELRCD(ByVal i As Integer)
        Dim objTELRCD As JPG.Common.Controls.CTLCombo
        objTELRCD = CType(FindControl("cboTELRCD_" & CStr(i)), JPG.Common.Controls.CTLCombo)
        objTELRCD.pComboTitle = True
        objTELRCD.pNoData = False
        objTELRCD.pType = "DENWAREN"               '//�d�b�A�����e
        objTELRCD.mMakeCombo()
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

    ' 2023/01/26 ADD START Y.ARAKAKI 2022�X��No�D _�����Ή����e�}�X�^_����x��No�̎g�p�t���O�ꊇ�ݒ�ǉ��Ή�
    '******************************************************************************
    '*�O���[�v�R�[�h�i�����Ή�From-To�j_��ʃ��X�g�{�b�N�X�p_�ꗗ�擾
    '*  ��From-To�A�܂Ƃ߂ĂQ���X�g���̃��R�[�h���擾�A�ݒ肷��B
    '******************************************************************************
    Private Sub fncCombo_Create_JidouTaiouGroupList()
        '�S���ڌ����p
        Dim strSQL1 As New StringBuilder("")
        Dim dbData1 As DataSet
        Dim cdb As New CDB
        'DB��������
        Dim i As Integer

        '���������J�n
        cdb.mOpen()
        strSQL1.Append("SELECT ")
        strSQL1.Append(" M8.GROUPCD AS CD ")
        strSQL1.Append(" ,M8.GROUPCD || '�F' || M8.GROUPNM AS NAME ")
        strSQL1.Append("FROM ")
        strSQL1.Append(" M08_AUTOTAIOU M8 ")
        strSQL1.Append("WHERE ")
        strSQL1.Append(" M8.KMCD IN ('08','15') ")
        strSQL1.Append("GROUP BY M8.GROUPCD,M8.GROUPNM ")
        strSQL1.Append("ORDER BY M8.GROUPCD,M8.GROUPNM ")

        cdb.pSQL = strSQL1.ToString
        'cdb.pSQLParamStr(":������ �̏������̂ݎw��") = "�������e"  '������͏����w��Ȃ��ׁ̈A�����͕s�v�ŃR�����g�A�E�g�B
        cdb.mExecQuery()
        dbData1 = cdb.pResult     '���ʂ��f�[�^�Z�b�g�i�[
        cdb.mClose()
        cdb = Nothing



        '���������ʏ����ƈႤ��肽�����ƁB�F���X�g���e��ݒ肵�A�S����(�ҏW�p�o�b�N�A�b�v)�����js���X�g�ɐݒ�B
        cboJTLISTFROM.Items.Add(New ListItem("", "")) '���X�g�ҏW1�s�ڂ͋�s��ݒ�B
        cboJTLISTTO.Items.Add(New ListItem("", "")) '���X�g�ҏW1�s�ڂ͋�s��ݒ�B
        If dbData1.Tables(0).Rows.Count > 0 Then
            For i = 0 To dbData1.Tables(0).Rows.Count - 1

                '����m�F���Ė��Ȃ���΂��̕s�v�s�폜��
                'strMsg.Append("var item = {val:'" + Convert.ToString(dbData1.Tables(0).Rows(i).Item(0)) + "',txt:'" + Convert.ToString(dbData1.Tables(0).Rows(i).Item(1)) + "'};")
                'strMsg.Append("listcboTKIGCD.push(item);")

                '�R���{�ɒǉ�
                cboJTLISTFROM.Items.Add(New ListItem(Convert.ToString(dbData1.Tables(0).Rows(i).Item(1)),
                  Convert.ToString(dbData1.Tables(0).Rows(i).Item(0))))
                cboJTLISTTO.Items.Add(New ListItem(Convert.ToString(dbData1.Tables(0).Rows(i).Item(1)),
                  Convert.ToString(dbData1.Tables(0).Rows(i).Item(0))))
            Next
        End If

    End Sub
    ' 2023/01/26 ADD END   Y.ARAKAKI 2022�X��No�D _�����Ή����e�}�X�^_����x��No�̎g�p�t���O�ꊇ�ݒ�ǉ��Ή�

    '******************************************************************************
    '*�O���[�v�R�[�h�̈ꗗ�擾
    '******************************************************************************
    Private Function fncGET_GROUPCD() As DataSet

        '//------------------------------------------
        '//<TODO>Select���̍쐬
        Dim SQLC As New MSJINJAG00CCSQL.CSQL
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
        strSQL.Append("		A.GROUPCD ")
        strSQL.Append("FROM ")
        strSQL.Append("		M08_AUTOTAIOU A ")
        strSQL.Append("GROUP BY A.GROUPCD ")
        'strSQL.Append("UNION ")
        'strSQL.Append("SELECT ")
        'strSQL.Append("		B.GROUPCD ")
        'strSQL.Append("FROM ")
        'strSQL.Append("		M07_AUTOTAIOUGROUP B ")
        'strSQL.Append("GROUP BY B.GROUPCD ")
        'strSQL.Append("ORDER BY GROUPCD ")

        dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

        Return dbData
    End Function

    '******************************************************************************
    '*�O���[�v�R�[�h�̏d���`�F�b�N�@True�F�d���Ȃ��@False�F�d������NG
    '******************************************************************************
    Private Function fncchkGROUPCD(ByVal groupcd As String) As Boolean

        Dim res As Boolean = False

        '//------------------------------------------
        '//<TODO>Select���̍쐬
        Dim SQLC As New MSJINJAG00CCSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet

        strSQL.Append("SELECT ")
        strSQL.Append("		A.GROUPCD ")
        strSQL.Append("FROM ")
        strSQL.Append("		M08_AUTOTAIOU A ")
        strSQL.Append("WHERE ")
        strSQL.Append("		A.GROUPCD = :GROUPCD ")
        strSQL.Append("GROUP BY A.GROUPCD ")
        '2017/02/09 W.GANEKO DEL START 2016�Ď����P ��10
        'strSQL.Append("UNION ")
        'strSQL.Append("SELECT ")
        'strSQL.Append("		B.GROUPCD ")
        'strSQL.Append("FROM ")
        'strSQL.Append("		M07_AUTOTAIOUGROUP B ")
        'strSQL.Append("WHERE ")
        'strSQL.Append("		B.GROUPCD = :GROUPCD ")
        'strSQL.Append("GROUP BY B.GROUPCD ")
        'strSQL.Append("ORDER BY GROUPCD ")
        '2017/02/09 W.GANEKO DEL END 2016�Ď����P ��10

        SqlParamC.fncSetParam("GROUPCD", True, groupcd.Trim)

        dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)


        If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
            res = True
        Else
            res = False
        End If

        Return res
    End Function
    '2017/02/09 W.GANEKO ADD START 2016�Ď����P ��10
    '******************************************************************************
    '*�O���[�v�R�[�h�̐擪�����`�F�b�N�@True�F�d���Ȃ��@False�F�d������NG
    '******************************************************************************
    Private Function fncCHKSTRGROUPCD(ByVal groupcd As String) As Boolean

        Dim res As Boolean = False

        '//------------------------------------------
        '//<TODO>Select���̍쐬
        Dim SQLC As New MSJINJAG00CCSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet
        Dim KEY As String = ""
        strSQL.Append("SELECT ")
        strSQL.Append("		A.NAIYO1 ")
        strSQL.Append("FROM ")
        strSQL.Append("		M06_PULLDOWN A ")
        strSQL.Append("WHERE ")
        strSQL.Append("		A.KBN = '78' ")
        strSQL.Append("AND  A.CD = '003'  ")

        dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)


        If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
            res = False
        Else
            KEY = Convert.ToString(dbData.Tables(0).Rows(0).Item(0)).Trim
            If groupcd.Substring(0, 2) = KEY.Substring(0, 2) Then
                res = True
            Else
                res = False
            End If
        End If

        Return res
    End Function
    '******************************************************************************
    '*JA�O���[�v�R�[�h�̏d���`�F�b�N�@True�F�d���Ȃ��@False�F�d������NG
    '******************************************************************************
    Private Function fncchkJAGROUPCD(ByVal groupcd As String) As Boolean

        Dim res As Boolean = False

        '//------------------------------------------
        '//<TODO>Select���̍쐬
        Dim SQLC As New MSJINJAG00CCSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet

        strSQL.Append("SELECT ")
        strSQL.Append("		A.GROUPCD ")
        strSQL.Append("FROM ")
        strSQL.Append("		M09_JAGROUP A ")
        strSQL.Append("WHERE ")
        strSQL.Append("		A.KBN = '003' ")
        strSQL.Append("AND  A.GROUPCD = :GROUPCD ")
        strSQL.Append("ORDER BY GROUPCD ")

        SqlParamC.fncSetParam("GROUPCD", True, groupcd.Trim)

        dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)


        If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
            res = True
        Else
            res = False
        End If

        Return res
    End Function
    '******************************************************************************
    '*�@�T�@�v�F�S���폜���̃`�F�b�N�@True�F�폜�@False�F�폜�s��
    '*�@���@�l�FJA�O���[�v�쐬�}�X�^�ɕR�t������ꍇ�A��s���Ƃ̍폜�͉\�Ƃ��邪
    '*�@�@�@�@�@�O���[�v�S�����폜���邱�Ƃ͂ł��Ȃ�
    '******************************************************************************
    Private Function fncchkJAGROUPDEL(ByVal groupcd As String) As Boolean

        Dim res As Boolean = False
        Dim objKMCD As System.Web.UI.WebControls.TextBox
        Dim objDEL As System.Web.UI.WebControls.CheckBox
        Dim DELCOUNT As Integer = 0
        Dim i As Integer

        '�폜�Ώۍs���J�E���g
        For i = 1 To 30
            '�R���g���[������T���o���A�^�ϊ�
            objKMCD = CType(FindControl("txtKMCD_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objDEL = CType(FindControl("chkDEL_" & CStr(i)), System.Web.UI.WebControls.CheckBox)

            If objKMCD.Text.Trim.Length <> 0 AndAlso (objDEL.Checked) Then
                DELCOUNT += 1
            End If
        Next

        '�ΏۃO���[�v�̓o�^���R�[�h��
        '//------------------------------------------
        '//<TODO>Select���̍쐬
        Dim SQLC As New MSJINJAG00CCSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet

        strSQL.Append("SELECT ")
        strSQL.Append("		COUNT(A.GROUPCD) ")
        strSQL.Append("FROM ")
        strSQL.Append("		M08_AUTOTAIOU A ")
        strSQL.Append("WHERE ")
        strSQL.Append("		A.GROUPCD = :GROUPCD ")
        strSQL.Append("ORDER BY GROUPCD ")

        SqlParamC.fncSetParam("GROUPCD", True, groupcd.Trim)

        dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)


        If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
            res = True
        Else
            If CStr(DELCOUNT) = Convert.ToString(dbData.Tables(0).Rows(0).Item(0)).Trim Then
                res = False
            Else
                res = True
            End If
        End If

        'strMsg.Append("alert('" & Convert.ToString(dbData.Tables(0).Rows(0).Item(0)).Trim & "');")
        Return res
    End Function

    Private Sub MSJINJAG00_AbortTransaction(sender As Object, e As EventArgs) Handles Me.AbortTransaction

    End Sub
    '******************************************************************************
    '*�@�T�@�v�F�i���ݏ�����n���v���p�e�B
    '*�@���@�l�F���o�����P�̒l��n��
    '******************************************************************************
    Public ReadOnly Property pCode1() As String
        Get
            Dim strRec As String = ""
            strRec = AuthC.pAUTHCENTERCD    '//�`�c�F�؂̎g�p�\�Ď��Z���^�[�R�[�h
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
 
            strRec = ""
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

            strRec = "�����Ή����e�O���[�v�ꗗ" '�����Ή��O���[�v�}�X�^
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
            strRec = "AUTOGROUP" '�����Ή��O���[�v�}�X�^
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
            strRec = "hdnGROUPCD"
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
            strRec = "txtGROUPCD"
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
            strRec = "btnGROUPCD"
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
            strRec = ""
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
            strRec = ""
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
            strRec = ""
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
            strRec = ""
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
            strRec = ""
            Return strRec
        End Get
    End Property
End Class
