'***********************************************
' �����Z���^�[�}�X�^  ���C�����
'***********************************************
' �ύX����

Option Explicit On
Option Strict On

Imports Common
Imports Common.DB
Imports JPG.Common
Imports JPG.Common.log

Imports System.Text

Partial Class MSKYOJAG00
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
            txtKENCD.Attributes.Add("ReadOnly", "true")
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
             MyBase.MapPath("../../../MS/MSKYOJAG/MSKYOJAG00/") & "MSKYOJAG00.js"))
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


        End If

        '<TODO>�����̉��ID��HIDDEN��hdnMyAspx�ɏ������ށi�V�X�e�����ʁj
        hdnMyAspx.Value = "MSKYOJAG00"
        '//-------------------------------------------------

    End Sub

    '******************************************************************************
    '* ���������������O�̉�ʏ�ԁiReadOnly��Disabled�j
    '********************************/*********************************************
    Private Sub fncIni_statebf()
        '//--------------------------------------------------------------------------
        '<TODO>�����O�̏�ԂɃR���g���[���̏�Ԃ�ݒ肷��

        btnKENCD.Disabled = False

    End Sub

    '******************************************************************************
    '* �������������ꂽ��̉�ʏ�ԁiReadOnly��Disabled�j
    '******************************************************************************
    Private Sub fncIni_stateaf()
        '//--------------------------------------------------------------------------
        '<TODO>������̏�ԂɃR���g���[���̏�Ԃ�ݒ肷��
        '

        txtKENCD.Attributes.Add("ReadOnly", "true")
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
        txtKENCD.Text = ""
        hdnKENCD.Value = ""


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

        hdnKENCD_MOTO.Value = ""

        Dim objEDT_DT As System.Web.UI.HtmlControls.HtmlInputHidden
        Dim objDISP_NO As System.Web.UI.HtmlControls.HtmlInputHidden
        Dim objKYOKYUCD As System.Web.UI.WebControls.TextBox
        Dim objKYOKYUNM As System.Web.UI.WebControls.TextBox
        Dim objDEL As System.Web.UI.WebControls.CheckBox
        Dim i As Integer
        For i = 1 To 30
            objEDT_DT = CType(FindControl("hdnEDT_DT_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden) '�R���g���[������T���o���A�^�ϊ�
            objDISP_NO = CType(FindControl("hdnDISP_NO_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKYOKYUCD = CType(FindControl("txtKYOKYU_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objKYOKYUNM = CType(FindControl("txtKYOKYUNM_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objDEL = CType(FindControl("chkDEL_" & CStr(i)), System.Web.UI.WebControls.CheckBox)

            objEDT_DT.Value = ""
            objDISP_NO.Value = CStr(i) '�@�B�I�ɔԍ���t����
            objKYOKYUCD.Text = ""
            objKYOKYUNM.Text = ""
            objDEL.Checked = False
        Next

    End Sub

    '******************************************************************************
    '* ���t(�쐬���X�V��)������������
    '******************************************************************************
    Private Sub fncIni_date()

        txtAYMD.Value = ""
        txtUYMD.Value = ""
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
            If hdnPopcrtl.Value = "1" Then
                If hdnBackUrl.Value = "EIGYOU" Then
                    '//�c�Ə��O���[�v�̏ꍇ�͊Ď��Z���^�[���R�t�����Ȃ��ׁA�S�N���C�A���g���o��
                    strRec = ""
                Else
                    '//
                    strRec = AuthC.pAUTHCENTERCD    '//�N���C�A���g�R�[�h�ꗗ �`�c�F�؂̎g�p�\�Ď��Z���^�[�R�[�h
                End If
            ElseIf hdnPopcrtl.Value = "2" Then      '//�R�[�h�ꗗ
                strRec = hdnKENCD.Value        '//�i�`�x���R�[�h�ꗗ
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
            If hdnPopcrtl.Value = "1" Then          '//���R�[�h�ꗗ
                strRec = "���R�[�h�ꗗ"
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
            If hdnPopcrtl.Value = "1" Then          '//���R�[�h�ꗗ
                strRec = "KENCD"
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
            If hdnPopcrtl.Value = "1" Then
                strRec = "hdnKENCD"
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
            If hdnPopcrtl.Value = "1" Then
                strRec = "txtKENCD"
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
            If hdnPopcrtl.Value = "1" Then
                strRec = "btnKENCD"
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
                hdnKENCD.Value = Convert.ToString(dbData.Tables(0).Rows(0).Item("KEN_CD"))
                hdnKENCD_MOTO.Value = Convert.ToString(dbData.Tables(0).Rows(0).Item("KEN_CD"))
                '����
                txtKENCD.Text = Convert.ToString(dbData.Tables(0).Rows(0).Item("KEN_CD")) & " : " & Convert.ToString(dbData.Tables(0).Rows(0).Item("KEN_NAME"))
                Dim sMinAddDate As String
                Dim sMaxEdtDate As String
                Dim sMaxTime As String
                sMinAddDate = DateFncC.mGet(Convert.ToString(dbData.Tables(0).Rows(0).Item("ADD_DATE")))
                sMaxEdtDate = DateFncC.mGet(Convert.ToString(dbData.Tables(0).Rows(0).Item("EDT_DATE")))
                sMaxTime = Convert.ToString(dbData.Tables(0).Rows(0).Item("TIME"))

                Dim objDISP_NO As System.Web.UI.HtmlControls.HtmlInputHidden
                Dim objKYOKYUCD As System.Web.UI.WebControls.TextBox
                Dim objKYOKYUNM As System.Web.UI.WebControls.TextBox
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
                    i = intRow + 1

                    objDISP_NO = CType(FindControl("hdnDISP_NO_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
                    objKYOKYUCD = CType(FindControl("txtKYOKYU_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                    objKYOKYUNM = CType(FindControl("txtKYOKYUNM_" & CStr(i)), System.Web.UI.WebControls.TextBox)
                    objEDT_DT = CType(FindControl("hdnEDT_DT_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
                    objADD_DT = CType(FindControl("hdnADD_DT_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
                    objKYOKYUCD.ReadOnly = True
                    objKYOKYUCD.BackColor = Color.Gainsboro

                    objDISP_NO.Value = CStr(i)
                    objADD_DT.Value = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("ADD_DATE"))
                    objEDT_DT.Value = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("EDT_DATE")) & Convert.ToString(dbData.Tables(0).Rows(intRow).Item("TIME"))
                    objKYOKYUCD.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("HAISO_CD"))
                    objKYOKYUNM.Text = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("NAME"))
                Next ' intRow


                txtAYMD.Value = sMinAddDate
                txtUYMD.Value = sMaxEdtDate
                hdnTIME.Value = sMaxTime

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

        Dim MSKYOJAW00C As New MSKYOJAG00MSKYOJAW00.MSKYOJAW00

        Dim strKENCD As String
        strKENCD = hdnKENCD.Value

        '�l��z��ɃZ�b�g
        Dim objADD_DT As System.Web.UI.HtmlControls.HtmlInputHidden
        Dim objEDT_DT As System.Web.UI.HtmlControls.HtmlInputHidden
        Dim objDISP_NO As System.Web.UI.HtmlControls.HtmlInputHidden
        Dim objKYOKYUCD As System.Web.UI.WebControls.TextBox
        Dim objKYOKYUNM As System.Web.UI.WebControls.TextBox
        Dim objDEL As System.Web.UI.WebControls.CheckBox
        Dim sADD_DT(30) As String
        Dim sEDT_DT(30) As String
        Dim sDISP_NO(30) As String
        Dim sKYOKYUCD(30) As String
        Dim sKYOKYUNM(30) As String
        Dim sDEL(30) As String
        Dim i As Integer
        For i = 1 To 30
            objADD_DT = CType(FindControl("hdnADD_DT_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden) '�R���g���[������T���o���A�^�ϊ�
            objEDT_DT = CType(FindControl("hdnEDT_DT_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden) '�R���g���[������T���o���A�^�ϊ�
            objDISP_NO = CType(FindControl("hdnDISP_NO_" & CStr(i)), System.Web.UI.HtmlControls.HtmlInputHidden)
            objKYOKYUCD = CType(FindControl("txtKYOKYU_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objKYOKYUNM = CType(FindControl("txtKYOKYUNM_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            objDEL = CType(FindControl("chkDEL_" & CStr(i)), System.Web.UI.WebControls.CheckBox)

            sADD_DT(i) = objADD_DT.Value
            sEDT_DT(i) = objEDT_DT.Value
            sDISP_NO(i) = objDISP_NO.Value
            sKYOKYUCD(i) = objKYOKYUCD.Text
            sKYOKYUNM(i) = Trim(objKYOKYUNM.Text)
            If (objDEL.Checked) Then
                sDEL(i) = "true"
            Else
                sDEL(i) = "false"
            End If

        Next
        strRec = MSKYOJAW00C.mSetEx( _
                    CInt(pstrKBN), _
                    strKENCD, _
                    sKYOKYUCD, _
                    sKYOKYUNM, _
                    sDEL, _
                    DateFncC.mHenkanGet(txtAYMD.Value), _
                    DateFncC.mHenkanGet(txtUYMD.Value), _
                    hdnTIME.Value, _
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
                strMsg.Append("Form1.btnSelect.focus();")
                strRec = strRecMsg
            Case "4"
                strRecMsg = "���R�[�h�����݂��܂���"
                strMsg.Append("alert('" & strRecMsg & "');")

                '<TODO>�t�H�[�J�X���Z�b�g����i�o�^�E�C�����ł̃G���[�B�N���C�A���g�R�[�h�����⏕�{�^���ɃZ�b�g�j
                strMsg.Append("Form1.btnSelect.focus();")

                strRec = strRecMsg

            Case "8"        
                strRecMsg = "�����Z���^�[�R�[�h���d�����Ă��܂�"
                strMsg.Append("alert('" & strRecMsg & "');")

                '<TODO>�t�H�[�J�X���Z�b�g����i�o�^�E�C�����ł̃G���[�B�R�[�h�����⏕�{�^���ɃZ�b�g�j
                strMsg.Append("Form1.txtKYOKYU_1.focus();")

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
                    strMsg.Append("Form1.txtKYOKYU_1.focus();")
                Else
                    '//----------------------------------
                    '<TODO>�t�H�[�J�X���Z�b�g����i���̑��@�F���O�o�͂̃G���[�̈׃L�[�ȍ~�ɃZ�b�g�j
                    strMsg.Append("Form1.txtKYOKYU_1.focus();")
                End If
        End Select
        For i = 1 To 30
            objKYOKYUCD = CType(FindControl("txtKYOKYU_" & CStr(i)), System.Web.UI.WebControls.TextBox)
            If objKYOKYUCD.Text <> "" Then
                objKYOKYUCD.ReadOnly = True
                objKYOKYUCD.BackColor = Color.Gainsboro
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
    '* pintKbn�@0:�����{�^���������f�[�^�o��
    '*        �@1:�V�K�{�^���������f�[�^�J�E���g�o��
    '******************************************************************************
    Private Function fncDataSelect(ByVal pintkbn As Integer) As DataSet

        'intKbn     0:�����{�^������
        'intKbn     1:�V�K�{�^������

        '//------------------------------------------
        '//<TODO>Select���̍쐬
        Dim SQLC As New MSKYOJAG00CCSQL.CSQL
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
            strSQL.Append("A.KEN_CD, ")
            strSQL.Append("B.KEN_NAME, ")
            strSQL.Append("A.HAISO_CD, ")
            strSQL.Append("A.NAME, ")
            strSQL.Append("A.ADD_DATE, ")
            strSQL.Append("A.EDT_DATE, ")
            strSQL.Append("A.TIME ")
        Else
            '�V�K�Ȃ̂őΏۃf�[�^�̃J�E���g���擾���܂�
            strSQL.Append("COUNT(*) AS CNT ")
        End If
        strSQL.Append("FROM  HAIMAS A, ")
        strSQL.Append("(SELECT DISTINCT ")
        strSQL.Append(" KEN_CODE, ")
        strSQL.Append(" KEN_NAME ")
        strSQL.Append("FROM CLIMAS ")
        strSQL.Append("WHERE KANSI_CODE IS NOT NULL ")
        strSQL.Append(") B ")
        strSQL.Append("WHERE A.KEN_CD   = :KEN_CD ")
        strSQL.Append("AND A.KEN_CD   = B.KEN_CODE(+) ")

        If pintkbn = 0 Then
            strSQL.Append(" ORDER BY TO_NUMBER(HAISO_CD) ")
        End If
        If hdnKENCD.Value.Length > 0 Then
            SqlParamC.fncSetParam("KEN_CD", True, hdnKENCD.Value)
        End If

        dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)
        'cdb.pSQL = strSQL.ToString
        'If hdnKENCD.Value.Length > 0 Then
        '    cdb.pSQLParamStr("KEN_CD") = hdnKENCD.Value
        'End If
        'cdb.mExecQuery()
        'dbData = cdb.pResult    '���ʂ��f�[�^�Z�b�g�Ɋi�[
        'cdb.mClose()
        'cdb = Nothing
        Return (dbData)
    End Function
    '******************************************************************************
    ' Excel�o��(�`�F�b�N��)
    '******************************************************************************
    Private Sub btnCSVout_ServerClick(ByVal sender As System.Object, _
                                    ByVal e As System.EventArgs) Handles btnCSVout.ServerClick
        Dim strRec As String
        Dim MSKYOJAG00C As New MSKYOJAG00MSKYOJAW00.MSKYOJAW00

        '//�@�F�؃N���X�̃C���X�^���X����
        AuthC = New CAuthenticate(Request, Response)

        Dim strRecMsg As String = ""

        strRec = MSKYOJAG00C.mCSV( _
                         Me.Session.SessionID, _
                         hdnKENCD.Value _
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
            HttpHeaderC.mDownLoadCSV(Response, "�����Z���^�[�}�X�^.csv")
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
