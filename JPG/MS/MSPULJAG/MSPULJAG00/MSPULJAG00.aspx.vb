'***********************************************
'�v���_�E���ݒ�}�X�^  ���C�����
'***********************************************
Option Explicit On
Option Strict On

Imports Common
Imports Common.DB
Imports JPG.Common
Imports JPG.Common.log

Imports System.Text

Partial Class MSPULJAG00
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
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                                                                Handles MyBase.Load
        '2012/04/04 NEC ou Add
        '.NET�̎d�l�ύX�ɂ��AReadOnly������ASPX�ł���ƁA�T�[�o���Œl�̎Q�Ƃ��ł��Ȃ��Ȃ邽�߁AVB����Attribute�ł���
        If MyBase.IsPostBack = False Then
            txtKBN_NAME.Attributes.Add("ReadOnly", "true")
            txtAYMD.Attributes.Add("ReadOnly", "true")
            txtUYMD.Attributes.Add("ReadOnly", "true")
        End If
        '2012/04/04 NEC ou Add

        '//------------------------------------------
        '//�@HTTP�w�b�_�𑗐M
        HttpHeaderC.mNoCache(Response)

        '//------------------------------------------
        '//�@�F�؃N���X�̃C���X�^���X����
        AuthC = New CAuthenticate(Request, Response)

        '//------------------------------------------
        '//�@�F�؏���
        '<TODO>�F�g�p�\�������w�肷��
        '[�v���_�E���}�X�^]�g�p�\����(�^:��/�c:�~/��:�~/�o:�~)
        AuthC.fncAuthCheck(Server, AuthC.pGROUP_UNKOU)

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
             MyBase.MapPath("../../../MS/MSPULJAG/MSPULJAG00/") & "MSPULJAG00.js"))
        '<�t�H�[�J�X�֘A�֐�>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncFo.js"))
        '<���l�֘A�֐�>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncNumChk.js"))
        '<���̓`�F�b�N�֐�>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncChk.js"))

        strScript.Append("</Script>")
        '//------------------------------------------
        '//�@Css�i�[
        strScript.Append("<Style>")
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "CssData.css"))
        strScript.Append("</Style>")
        '//------------------------------------------
        '//�@Script������
        lblScript.Text = strScript.ToString

        '//------------------------------------------
        If MyBase.IsPostBack = False Then
            '//--------------------------------------
            '//���߂ĊJ�������������s�����

            '//--------------------------------------
            '�����\���Ƃ��ĕK�v�ȃR���g���[���̐ݒ���s���܂�
            Call fncIni_format()    '//�l�̏�����

            '//--------------------------------------
            '������ʂ̏�Ԑݒ�(��ʂ��y�����O��ԁz�ɂ���i���̓f�[�^�͂��̂܂ܑJ�ڂ�����)
            Call fncIni_statebf()

            '//--------------------------------------
            '<TODO>�t�H�[�J�X���Z�b�g����i�����\���Ȃ̂ŃL�[�ɃZ�b�g����j
            strMsg.Append("Form1.txtKBN.focus();")
        Else
            '//--------------------------------------
            '//�Q��ڈȍ~���s�����
            '//--------------------------------------
        End If

        '//------------------------------------------
        '<TODO>�����̉��ID��HIDDEN��hdnMyAspx�ɏ������ށi�V�X�e�����ʁj
        hdnMyAspx.Value = "MSPULJAG00"
        '//------------------------------------------

    End Sub

    '******************************************************************************
    '* ���������������O�̉�ʏ�ԁiReadOnly��Disabled�j
    '******************************************************************************
    Private Sub fncIni_statebf()
        btnUpdate.Disabled = False      '�o�^�{�^���g�p�\
        btnDelete.Disabled = True       '�폜�{�^���g�p�s��

        '//------------------------------------------
        '<TODO>�����O�̏�ԂɃR���g���[���̏�Ԃ�ݒ肷��
        '      ���ׂĂ̍��ڂ��g�p�\(�폜�{�^���ȊO)
        '�敪
        txtKBN.ReadOnly = False
        txtKBN.CssClass = "c-k"
        txtKBN.BackColor = Nothing
        '�敪�����{�^��
        btnKenKBN.Disabled = False

        '�R�[�h
        txtCD.ReadOnly = False
        txtCD.CssClass = "c-k"
        txtCD.BackColor = Nothing
        '�R�[�h�����{�^��
        btnKenCD.Disabled = False
    End Sub

    '******************************************************************************
    '* �������������ꂽ��̉�ʏ�ԁiReadOnly��Disabled�j
    '******************************************************************************
    Private Sub fncIni_stateaf()
        btnUpdate.Disabled = False      '�o�^�{�^���g�p�\
        btnDelete.Disabled = False      '�폜�{�^���g�p�\

        '//------------------------------------------
        '<TODO>������̏�ԂɃR���g���[���̏�Ԃ�ݒ肷��
        '�敪
        txtKBN.ReadOnly = True
        txtKBN.CssClass = "c-RO"
        txtKBN.BackColor = System.Drawing.Color.Gainsboro
        '�敪�����{�^��
        btnKenKBN.Disabled = True

        '�R�[�h
        txtCD.ReadOnly = True
        txtCD.CssClass = "c-RO"
        txtCD.BackColor = System.Drawing.Color.Gainsboro
        '�R�[�h�����{�^��
        btnKenCD.Disabled = True

        '2012/05/25 NEC ou Add Str
        txtKBN_NAME.Attributes.Add("ReadOnly", "true")
        txtAYMD.Attributes.Add("ReadOnly", "true")
        txtUYMD.Attributes.Add("ReadOnly", "true")
        '2012/05/25 NEC ou Add End
    End Sub

    '******************************************************************************
    '* �e�R���g���[���̐ݒ�l�̏�����
    '******************************************************************************
    Private Sub fncIni_format()
        '//--------------------------------------------------------------------------
        '<TODO>�L�[�R���g���[���̒l������������
        txtKBN.Text = ""
        txtKBN_NAME.Text = ""
        txtCD.Text = ""

        '�L�[�ȊO�̒l������������
        Call fncIni_notkey()
    End Sub

    '******************************************************************************
    '* �L�[�ȊO�̒l������������
    '******************************************************************************
    Private Sub fncIni_notkey()
        Call fncIni_date()

        '//------------------------------------------
        '<TODO>�R���g���[���̒l������������
        txtNAME.Text = ""
        txtDISP_NO.Text = ""
        txtNAIYO1.Text = ""
        txtNAIYO2.Text = ""
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
    '* �V�K�{�^�����������ꂽ�Ƃ��̏���
    '******************************************************************************
    Private Sub btnInsert_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsert.ServerClick
        Try
            '//--------------------------------------
            '�V�K�o�^�`�F�b�N���s��
            Dim dbData As DataSet
            dbData = fncDataSelect(1)
            'If ds.Tables(0).Rows.Count = 0 Then
            If Convert.ToString(dbData.Tables(0).Rows(0).Item("CNT")) = "0" Then
                '�f�[�^�����݂��Ȃ��ׁA�V�K�o�^�͉\

                '�L�[���ڈȊO���폜���A�����O��Ԃɂ���B
                Call fncIni_notkey()
                Call fncIni_statebf()

                '//----------------------------------
                '<TODO>�t�H�[�J�X���Z�b�g����i�V�K�o�^�Ńf�[�^�����݂��Ȃ��̂ŃL�[�ȍ~�ɃZ�b�g�j
                strMsg.Append("Form1.txtNAME.focus();")

            Else
                '�f�[�^�����݂���ׁA�V�K�o�^�͕s��

                '���b�Z�[�W���o�͌�A�����O��Ԃɂ���B
                strMsg.Append("alert('���Ƀf�[�^�����݂��܂�');")
                Call fncIni_statebf()

                '//----------------------------------
                '<TODO>�t�H�[�J�X���Z�b�g����i�V�K�o�^�Ńf�[�^�����݂���̂ŃL�[�ɃZ�b�g�j
                strMsg.Append("Form1.txtKBN.focus();")
            End If
            dbData.Dispose()

        Catch ex As Exception
            Dim ErrMsgC As New CErrMsg
            strMsg.Append("alert('�V�X�e���G���[�F" & ErrMsgC.mGetArtMsg(ex.ToString) & "');")
        End Try
    End Sub

    '******************************************************************************
    '* �o�^�{�^�����������ꂽ�Ƃ��̏���
    '******************************************************************************
    Private Sub btnUpdate_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.ServerClick
        Dim strRec As String
        strRec = fncbtnJikkou_ClickEvent(hdnKBN.Value)

        If hdnKBN.Value = "1" Then
            Call fncIni_statebf()
        Else
            If strRec = "OK" Then
                Call fncIni_statebf()
            Else
                Call fncIni_stateaf()
            End If
        End If
    End Sub

    '******************************************************************************
    '* �폜�{�^�����������ꂽ�Ƃ��̏���
    '******************************************************************************
    Private Sub btnDelete_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.ServerClick
        Dim strRec As String
        strRec = fncbtnJikkou_ClickEvent("3")

        If strRec = "OK" Then
            Call fncIni_statebf()
        Else
            Call fncIni_stateaf()
        End If
    End Sub

    '******************************************************************************
    '* ����{�^�����������ꂽ�Ƃ��̏���
    '******************************************************************************
    Private Sub btnClear_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.ServerClick
        Call fncIni_format()    '//�l�̏�����
        Call fncIni_statebf()   '//��Ԃ̏�����

        '//------------------------------------------
        '<TODO>�t�H�[�J�X���Z�b�g����i������ʂɖ߂����̂�(PageLoad���l)�L�[�ɃZ�b�g�j
        strMsg.Append("Form1.txtKBN.focus();")
    End Sub

    '******************************************************************************
    '*�@�T�@�v�F�i���ݏ�����n���v���p�e�B
    '*�@���@�l�F���o�����P�̒l��n��
    '******************************************************************************
    Public ReadOnly Property pCode1() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then      '//�v���_�E���敪�ꗗ�F�敪�������ɓn��
                strRec = ""
            ElseIf hdnPopcrtl.Value = "2" Then  '//�v���_�E���R�[�h�ꗗ�F�敪�������ɓn��
                strRec = txtKBN.Text
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
            If hdnPopcrtl.Value = "1" Then
                strRec = "�v���_�E���敪�ꗗ"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = "�v���_�E���R�[�h�ꗗ"
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
                strRec = "PULLKBN"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = "PULLCODE"
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
            If hdnPopcrtl.Value = "1" Then      '//�敪�ɃR�[�h��Ԃ�
                strRec = "txtKBN"
            ElseIf hdnPopcrtl.Value = "2" Then  '//�R�[�h�ɃR�[�h��Ԃ�
                strRec = "txtCD"
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
            If hdnPopcrtl.Value = "1" Then      '//�敪���ɖ��̂�Ԃ�
                strRec = "txtKBN_NAME"
            ElseIf hdnPopcrtl.Value = "2" Then  '//
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
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then      '//�敪�Ƀt�H�[�J�X���Z�b�g
                strRec = "txtKBN"
            ElseIf hdnPopcrtl.Value = "2" Then  '//�R�[�h�Ƀt�H�[�J�X���Z�b�g
                strRec = "txtCD"
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�t�H�[�J�X��Ԃ�����Ɏ��s����JS����n���v���p�e�B
    '*�@���@�l�F2005.01.27 J.Katayama ����ύX�����ꍇJA�x���R�[�h���폜����
    '******************************************************************************
    Public ReadOnly Property pBackScript() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then      '//
                strRec = "fncPopfunction"
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
    '*�@�T�@�v�F
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pClear1() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "txtCD"
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

        Try
            '//--------------------------------------
            '�����������s��
            Dim DateFncC As New CDateFnc
            Dim dbData As DataSet
            dbData = fncDataSelect(0)
            If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
                '�f�[�^�����݂��Ȃ��ׁA�����̓G���[
                '���b�Z�[�W���o�͌�A�����O��Ԃɂ���B

                strMsg.Append("alert('�f�[�^�����݂��܂���');")

                Call fncIni_statebf()

                '//----------------------------------
                '<TODO>�t�H�[�J�X���Z�b�g����i�f�[�^�����݂��Ȃ��̂ŃL�[�ɃZ�b�g�j
                strMsg.Append("Form1.txtKBN.focus();")
            Else
                '�f�[�^�����݂���ׁA�V�K�o�^�͕s��
                '�f�[�^���o�͌�A�������Ԃɂ���B

                '------------------------------------
                '<TODO>�f�[�^���o�͂���
                txtKBN.Text = Convert.ToString(dbData.Tables(0).Rows(0).Item("KBN"))
                txtKBN_NAME.Text = Convert.ToString(dbData.Tables(0).Rows(0).Item("KBNNM"))
                txtCD.Text = Convert.ToString(dbData.Tables(0).Rows(0).Item("CD"))
                txtNAME.Text = Convert.ToString(dbData.Tables(0).Rows(0).Item("NAME"))
                txtNAIYO1.Text = Convert.ToString(dbData.Tables(0).Rows(0).Item("NAIYO1"))
                txtNAIYO2.Text = Convert.ToString(dbData.Tables(0).Rows(0).Item("NAIYO2"))
                txtDISP_NO.Text = Convert.ToString(dbData.Tables(0).Rows(0).Item("DISP_NO"))
                '�����L�R���ڂ͕K�{��
                txtAYMD.Text = DateFncC.mGet(Convert.ToString(dbData.Tables(0).Rows(0).Item("ADD_DATE")))
                txtUYMD.Text = DateFncC.mGet(Convert.ToString(dbData.Tables(0).Rows(0).Item("EDT_DATE")))
                hdnTIME.Value = Convert.ToString(dbData.Tables(0).Rows(0).Item("TIME"))

                If pstrKBN = "1" Then
                    '�����{�^��������
                    Call fncIni_stateaf()

                    '//------------------------------
                    '<TODO>�t�H�[�J�X���Z�b�g����i�f�[�^�����݂����̂ŃL�[�ȊO�ɃZ�b�g�j
                    strMsg.Append("Form1.txtNAME.focus();")
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
        Dim MSPULJAW00C As New MSPULJAG00MSPULJAW00.MSPULJAW00

        '--------------------------------------------
        '<TODO>WEB�T�[�r�X���Ăяo��
        strRec = MSPULJAW00C.mSet( _
                            CInt(pstrKBN), _
                            txtKBN.Text, _
                            txtCD.Text, _
                            txtNAME.Text, _
                            txtNAIYO1.Text, _
                            txtNAIYO2.Text, _
                            txtDISP_NO.Text, _
                            DateFncC.mHenkanGet(txtAYMD.Text), _
                            DateFncC.mHenkanGet(txtUYMD.Text), _
                            hdnTIME.Value)

        '--------------------------------------------
        '<TODO>�Ԃ�l�ɂ�鐧����s���B
        '�y���ʁz
        '  OK : ����ɏI�����܂���
        '   0 : ���̃��[�U�[�ɂ���ăf�[�^���X�V����Ă��܂��B�ēx�������Ă�������
        '   1 : ���Ƀf�[�^�����݂��܂�
        '   2 : �Ώۃf�[�^�����݂��܂���
        '   3 : �r�����䏈���ŃG���[���������܂����B�ēx���s���Ă�������

        Dim strRecMsg As String
        Select Case strRec
            Case "OK"
                If pstrKBN = "1" Or pstrKBN = "2" Then
                    Call fncbtnKensaku_ClickEvent("2")
                Else
                    Call fncIni_date()
                End If
                strMsg.Append("alert('����ɏI�����܂���');")

                '//------------------------------
                '<TODO>�t�H�[�J�X���Z�b�g����i����I����͏�����ԂɂȂ�̂ŃL�[�ɃZ�b�g�j
                strMsg.Append("Form1.txtKBN.focus();")
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
                '<TODO>�t�H�[�J�X���Z�b�g����i�o�^���ł̃G���[�B�L�[�ɃZ�b�g�j
                strMsg.Append("Form1.txtKBN.focus();")

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
                strRecMsg = "�敪�����݂��܂���"
                strMsg.Append("alert('" & strRecMsg & "');")

                '<TODO>�t�H�[�J�X���Z�b�g����i�o�^�E�C�����ł̃G���[�B�敪�ɃZ�b�g�j
                strMsg.Append("Form1.txtKBN.focus();")

                strRec = strRecMsg
            Case Else
                Dim ErrMsgC As New CErrMsg

                strMsg.Append("alert('�V�X�e���G���[�F" & ErrMsgC.mGetArtMsg(strRec) & "');")

                If pstrKBN = "1" Then
                    '//----------------------------------
                    '<TODO>�t�H�[�J�X���Z�b�g����i�o�^�����F���O�o�͂̃G���[�̈׃L�[�ɃZ�b�g�j
                    strMsg.Append("Form1.txtKBN.focus();")
                ElseIf pstrKBN = "2" Then
                    '//----------------------------------
                    '<TODO>�t�H�[�J�X���Z�b�g����i�C�������F���O�o�͂̃G���[�̈׃L�[�ȍ~�ɃZ�b�g�j
                    strMsg.Append("Form1.txtNAME.focus();")
                Else
                    '//----------------------------------
                    '<TODO>�t�H�[�J�X���Z�b�g����i���̑��@�F���O�o�͂̃G���[�̈׃L�[�ȍ~�ɃZ�b�g�j
                    strMsg.Append("Form1.txtNAME.focus();")
                End If
        End Select

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
            strMsg.Append("alert('�V�X�e���G���[�F" & errmsgc.mGetArtMsg(strRecLog) & "');")
        End If

        Return strRec
    End Function

    '******************************************************************************
    '* ���̓L�[�ɂ��f�[�^�̌������s���܂��B
    '* pintKbn�@0:�����{�^���������f�[�^�o��
    '*        �@1:�V�K�{�^���������f�[�^�J�E���g�o��
    '******************************************************************************
    Private Function fncDataSelect(ByVal pintKbn As Integer) As DataSet
        'intKbn     0:�����{�^������
        'intKbn     1:�V�K�{�^������

        '//------------------------------------------
        '//<TODO>Select���̍쐬
        Dim SQLC As New MSPULJAG00CCSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet
        'Dim cdb As New CDB
        'Dim dbData As New DataSet
        'Dim strSQL As New StringBuilder("")
        'cdb.mOpen()
        strSQL.Append("SELECT ")
        If pintKbn = 0 Then
            '�����Ȃ̂őS�Ă̍��ڂ��擾���܂�
            strSQL.Append("PL.KBN, ")
            strSQL.Append("PM.NAME AS KBNNM, ")
            strSQL.Append("PL.CD, ")
            strSQL.Append("PL.NAME, ")
            strSQL.Append("PL.NAIYO1, ")
            strSQL.Append("PL.NAIYO2, ")
            strSQL.Append("PL.DISP_NO, ")
            strSQL.Append("PL.ADD_DATE, ")
            strSQL.Append("PL.EDT_DATE, ")
            strSQL.Append("PL.TIME ")
        Else
            '�V�K�Ȃ̂őΏۃf�[�^�̃J�E���g���擾���܂�
            strSQL.Append("COUNT(*) AS CNT ")
        End If
        strSQL.Append("FROM  M06_PULLDOWN PL, ")
        strSQL.Append("      M06_PULLDOWN PM ")
        strSQL.Append("WHERE PL.KBN  = :KBN ")
        strSQL.Append("  AND PL.CD = :CD ")
        strSQL.Append("  AND PM.KBN = '00' ")
        strSQL.Append("  AND PM.CD = PL.KBN ")

        SqlParamC.fncSetParam("KBN", True, txtKBN.Text)
        SqlParamC.fncSetParam("CD", True, txtCD.Text)

        dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

        'cdb.pSQL = strSQL.ToString
        'cdb.pSQLParamStr("KBN") = txtKBN.Text
        'cdb.pSQLParamStr("CD") = txtCD.Text
        'cdb.mExecQuery()
        'dbData = cdb.pResult    '���ʂ��f�[�^�Z�b�g�Ɋi�[
        'cdb.mClose()
        'cdb = Nothing
        Return dbData
    End Function

End Class
