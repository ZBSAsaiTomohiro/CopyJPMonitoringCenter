'***********************************************
'�S���҃}�X�^  ���C�����
'***********************************************
Option Explicit On
Option Strict On

Imports Common
Imports Common.DB
Imports JPG.Common
Imports JPG.Common.log

Imports System.Text

Partial Class MSTASJAG00
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

        '2012/04/04 NEC ou Add Str
        '.NET�̎d�l�ύX�ɂ��AReadOnly������ASPX�ł���ƁA�T�[�o���Œl�̎Q�Ƃ��ł��Ȃ��Ȃ邽�߁AVB����Attribute�ł���
        If MyBase.IsPostBack = False Then
            txtKURACD.Attributes.Add("ReadOnly", "true")
            txtCODE.Attributes.Add("ReadOnly", "true")
            txtGROUPCD.Attributes.Add("ReadOnly", "true") '2016/02/12 H.Mori add 2015���P�J�� ��9
        End If
        '2012/04/04 NEC ou Add End

        '//------------------------------------------
        '//�@HTTP�w�b�_�𑗐M
        HttpHeaderC.mNoCache(Response)

        '//------------------------------------------
        '//�@�F�؃N���X�̃C���X�^���X����
        AuthC = New CAuthenticate(Request, Response)

        '//------------------------------------------
        '//�@�F�؏���
        '<TODO>�F�g�p�\�������w�肷��
        '--- ��2005/04/28 DEL�@Falcon�� -----------------
        '[�v���_�E���}�X�^]�g�p�\����(�^:��/�c:��/��:�~/�o:�~)
        'AuthC.fncAuthCheck(Server, AuthC.pGROUP_UNKOU & "," & AuthC.pGROUP_EIGYOU)

        '--- ��2005/04/28 DEL Falcon�� -----------------
        '--- ��2005/04/28 MOD�@Falcon�� -----------------
        '[�S���҃}�X�^]�g�p�\����(�^:��/�c:��/��:��/�o:�~)
        AuthC.fncAuthCheck(Server, AuthC.pGROUP_UNKOU & "," & AuthC.pGROUP_EIGYOU & "," & AuthC.pGROUP_KANSHI)

        '--- ��2005/04/28 MOD Falcon�� -----------------
        '//------------------------------------------
        '<TODO>�|�b�v�A�b�v/�o�^�n�t���[���̏o��
        '      [hdnKensaku(Hidden)]���쐬���鎖
        If hdnKensaku.Value = "COPOPUPG00" Then
            Server.Transfer("../../../Popup/COPOPUPG00.aspx")
        End If

        ' 2008/07/31 ADD T.Watabe
        '//------------------------------------------
        '// �S���҈ꗗ
        If hdnKensaku.Value = "MSTAFJAG00" Then
            Server.Transfer("../../../MS/MSTAFJAG/MSTAFJAG00/MSTAFJAG00.aspx")
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
             MyBase.MapPath("../../../MS/MSTASJAG/MSTASJAG00/") & "MSTASJAG00.js"))
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
            strMsg.Append("Form1.rdoKBN1.focus();")

            '//-----------------------------------------------------
            '// �c�Ə��O���[�v�݂̂ɏ������Ă���ꍇ�A[�c�Ə����j���[]���J�ڂ��Ă��Ă����
            '// �I���{�^����������[�c�Ə����j���[]�ɖ߂�
            '//-----------------------------------------------------

            hdnBackUrl.Value = ""

            Dim strGROUPNAME As String = AuthC.pGROUPNAME
            Dim arrGroupName() As String = strGROUPNAME.Split(Convert.ToChar(","))
            '--- ��2005/04/19 MOD�@Falcon�� -----------------
            Dim arrKanshiGroup() As String = AuthC.pGROUP_KANSHI.Split(Convert.ToChar(","))
            Dim i As Integer
            Dim bolGroupFLG As Boolean = False

            '�^�s�J�����E�c�Ə��̏����`�F�b�N
            If Array.IndexOf(arrGroupName, AuthC.pGROUP_UNKOU) >= 0 Or _
                Array.IndexOf(arrGroupName, AuthC.pGROUP_EIGYOU) >= 0 Then
                bolGroupFLG = True
            End If
            '--- ��2005/04/19 MOD Falcon�� ------------------
            '--- ��2005/04/28 MOD�@Falcon�� -----------------
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
            '--- ��2005/04/28 MOD Falcon�� ------------------
            '--- ��2005/04/19 MOD�@Falcon�� -----------------
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
            '--- ��2005/04/19 MOD Falcon�� ------------------

            '--- ��2005/04/19 DEL�@Falcon�� -----------------
            'If _
            '    Array.IndexOf(arrGroupName, AuthC.pGROUP_UNKOU) >= 0 Or _
            '    Array.IndexOf(arrGroupName, AuthC.pGROUP_TOUHOKU) >= 0 Or _
            '    Array.IndexOf(arrGroupName, AuthC.pGROUP_NAKANIHON) >= 0 Or _
            '    Array.IndexOf(arrGroupName, AuthC.pGROUP_NISHINIHON) >= 0 Or _
            '    Array.IndexOf(arrGroupName, AuthC.pGROUP_EIGYOU) >= 0 Then
            '    '�����ꂩ�̃O���[�v�ɏ������Ă���ꍇ�͂��̃��j���[�ɂċƖ����s������
            '    '�ʏ�[�}�X�^���j���[]�ɖ߂�
            'Else
            '    Dim j As Integer
            '    Dim intEIGYOU_LEN As Integer
            '    Dim intGROUP_LEN As Integer
            '    intEIGYOU_LEN = AuthC.pGROUP_EIGYOU.Length
            '    For j = 0 To arrGroupName.Length - 1
            '        intGROUP_LEN = arrGroupName(j).Length
            '        If intGROUP_LEN > 0 Then
            '            If Convert.ToString(arrGroupName(j)).Substring(intGROUP_LEN - intEIGYOU_LEN, intEIGYOU_LEN) = AuthC.pGROUP_EIGYOU Then
            '                '//�c�Ə��O���[�v
            '                hdnBackUrl.Value = "EIGYOU"
            '            End If
            '        End If
            '    Next
            'End If
            '--- ��2005/04/19 DEL Falcon�� ------------------
        Else
            '//--------------------------------------
            '//�@�Q��ڈȍ~���s�����
            '//--------------------------------------

            If hdnTANKBN.Value = "1" Then           '//�i�`�S���҂�I������
                rdoKBN1.Checked = True
                rdoKBN2.Checked = False
                rdoKBN3.Checked = False
            ElseIf hdnTANKBN.Value = "2" Then       '//�Ď��Z���^�[��I������
                rdoKBN1.Checked = False
                rdoKBN2.Checked = True
                rdoKBN3.Checked = False
                btnKURACD.Disabled = True
                txtCODE.ReadOnly = True
                txtCODE.CssClass = "c-RO"
                txtCODE.BackColor = System.Drawing.Color.Gainsboro
                txtCODE.TabIndex = -1
            ElseIf hdnTANKBN.Value = "3" Then       '//�o����Ђ�I������
                rdoKBN1.Checked = False
                rdoKBN2.Checked = False
                rdoKBN3.Checked = True
                btnKURACD.Disabled = True
                txtCODE.ReadOnly = True
                txtCODE.CssClass = "c-RO"
                txtCODE.BackColor = System.Drawing.Color.Gainsboro
                txtCODE.TabIndex = -1
            End If
        End If

        '//�S���敪�̃��W�I�{�^���Ő��䂷�邽��
        strMsg.Append("window_open();")

        '//-------------------------------------------------
        '<TODO>�����̉��ID��HIDDEN��hdnMyAspx�ɏ������ށi�V�X�e�����ʁj
        hdnMyAspx.Value = "MSTASJAG00"
        '//-------------------------------------------------
    End Sub

    '******************************************************************************
    '* ���������������O�̉�ʏ�ԁiReadOnly��Disabled�j
    '******************************************************************************
    Private Sub fncIni_statebf()
        '//--------------------------------------------------------------------------
        '<TODO>�����O�̏�ԂɃR���g���[���̏�Ԃ�ݒ肷��
        '
        rdoKBN1.Disabled = False
        rdoKBN2.Disabled = False

        If hdnTANKBN.Value = "1" Then           '//�i�`�S���҂�I������
            '--- ��2005/04/28 ADD Falcon�� ---
            btnKURACD.Disabled = False
            '--- ��2005/04/28 ADD Falcon�� ---
        ElseIf hdnTANKBN.Value = "2" Then       '//�Ď��Z���^�[��I������
            btnKURACD.Disabled = True
        ElseIf hdnTANKBN.Value = "3" Then       '//�o����Ђ�I������
            btnKURACD.Disabled = True
        End If

    End Sub

    '******************************************************************************
    '* �������������ꂽ��̉�ʏ�ԁiReadOnly��Disabled�j
    '******************************************************************************
    Private Sub fncIni_stateaf()
        '//--------------------------------------------------------------------------
        '<TODO>������̏�ԂɃR���g���[���̏�Ԃ�ݒ肷��
        '
        rdoKBN1.Disabled = True
        rdoKBN2.Disabled = True
        rdoKBN3.Disabled = True

        btnKURACD.Disabled = True
        btnCODECD.Disabled = True

    End Sub

    '******************************************************************************
    '* �e�R���g���[���̐ݒ�l�̏�����
    '******************************************************************************
    Private Sub fncIni_format()
        '//--------------------------------------------------------------------------
        '<TODO>�R���g���[���̒l������������
        '
        rdoKBN1.Checked = True
        rdoKBN2.Checked = False
        rdoKBN3.Checked = False

        txtKURACD.Text = ""
        txtCODE.Text = ""
        txtJACD.Text = ""
        txtTantoTel.Text = "" '2015/11/02 w.ganeko 2015���P�J�� ��9
        hdnTANKBN.Value = "1"
    End Sub

    '******************************************************************************
    '* �L�[�ȊO�̒l������������
    '******************************************************************************
    Private Sub fncIni_notkey()
        'Call fncIni_date()
        '//--------------------------------------------------------------------------
        '<TODO>�R���g���[���̒l������������
        '
    End Sub

    ''******************************************************************************
    ''* ���t(�쐬���X�V��)������������
    ''******************************************************************************
    'Private Sub fncIni_date()
    '    hdnTIME.Value = ""
    'End Sub

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
                If hdnTANKBN.Value = "1" Then
                    strRec = hdnKURACD.Value        '//�i�`�x���R�[�h�ꗗ
                ElseIf hdnTANKBN.Value = "2" Then
                    strRec = AuthC.pAUTHCENTERCD    '//�Ď��Z���^�[�R�[�h�ꗗ �`�c�F�؂̎g�p�\�Ď��Z���^�[�R�[�h
                ElseIf hdnTANKBN.Value = "3" Then
                    '--- ��2005/04/29 DEL Falcon�� ---
                    'strRec = ""                     '//�o����ЃR�[�h�ꗗ
                    '--- ��2005/04/29 DEL Falcon�� ---
                    '--- ��2005/04/29 ADD Falcon�� ---
                    If hdnBackUrl.Value = "EIGYOU" Then
                        '//�c�Ə��O���[�v�̏ꍇ�͊Ď��Z���^�[���R�t�����Ȃ��ׁA�S�N���C�A���g���o��
                        strRec = ""
                    Else
                        strRec = AuthC.pAUTHCENTERCD    '//�o����ЃR�[�h�ꗗ �`�c�F�؂̎g�p�\�Ď��Z���^�[�R�[�h
                    End If
                    '--- ��2005/04/29 ADD Falcon�� ---
                End If
            ElseIf hdnPopcrtl.Value = "3" Then      '//�O���[�v�R�[�h�ꗗ
                strRec = AuthC.pAUTHCENTERCD        '2016/02/15 H.Mori add 2015���P�J�� ��9
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�i���ݏ�����n���v���p�e�B
    '*�@���@�l�F���o�����Q�̒l��n��                   '2016/02/15 H.Mori add 2015���P�J�� ��9
    '******************************************************************************
    Public ReadOnly Property pCode2() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "2" Then      '//JA�x���R�[�h�ꗗ
                strRec = ""
            ElseIf hdnPopcrtl.Value = "3" Then      '//�O���[�v�R�[�h�ꗗ
                strRec = hdnKURACD.Value.Trim
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�i���ݏ�����n���v���p�e�B
    '*�@���@�l�F���o�����R�̒l��n��                   '2016/02/15 H.Mori add 2015���P�J�� ��9
    '******************************************************************************
    Public ReadOnly Property pCode3() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = ""
            ElseIf hdnPopcrtl.Value = "2" Then      '//JA�x���R�[�h�ꗗ
                strRec = ""
            ElseIf hdnPopcrtl.Value = "3" Then      '//�O���[�v�R�[�h�ꗗ
                strRec = hdnCODE.Value.Trim
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
                If hdnTANKBN.Value = "1" Then
                    strRec = "�i�`�x���R�[�h�ꗗ"
                ElseIf hdnTANKBN.Value = "2" Then
                    strRec = "�Ď��Z���^�[�R�[�h�ꗗ"
                ElseIf hdnTANKBN.Value = "3" Then
                    strRec = "�o����ЃR�[�h�ꗗ"
                End If
            ElseIf hdnPopcrtl.Value = "3" Then      '//�O���[�v�R�[�h�ꗗ
                strRec = "�O���[�v�R�[�h�ꗗ"       '2016/02/15 H.Mori add 2015���P�J�� ��9
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
                If hdnTANKBN.Value = "1" Then
                    'strRec = "JASS2"
                    strRec = "JASS"      '--- 2008/02/27 MOD T.Watabe ---
                ElseIf hdnTANKBN.Value = "2" Then
                    strRec = "KANSHI"
                ElseIf hdnTANKBN.Value = "3" Then
                    strRec = "SYUTUDOU"
                End If
            ElseIf hdnPopcrtl.Value = "3" Then      '//�O���[�v�R�[�h�ꗗ
                strRec = "JAHOKOKU"                 '2016/02/15 H.Mori add 2015���P�J�� ��9
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
            ElseIf hdnPopcrtl.Value = "3" Then      '2016/02/15 H.Mori add 2015���P�J�� ��9
                strRec = "hdnGROUPCD"
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
            ElseIf hdnPopcrtl.Value = "3" Then      '2016/02/15 H.Mori add 2015���P�J�� ��9
                strRec = "txtGROUPCD"
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
            ElseIf hdnPopcrtl.Value = "3" Then      '2016/02/15 H.Mori add 2015���P�J�� ��9
                strRec = "btnGROUPCD"
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
                'strRec = ""
                strRec = "hdnGROUPCD"               '2016/02/15 H.Mori add 2015���P�J�� ��9
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
                'strRec = ""
                strRec = "txtGROUPCD"               '2016/02/16 H.Mori add 2015���P�J�� ��9
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F '2016/02/15 H.Mori add 2015���P�J�� ��9
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pClear3() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "hdnGROUPCD"
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F '2016/02/15 H.Mori add 2015���P�J�� ��9
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pClear4() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "txtGROUPCD"
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
            'Dim dbData As DataSet
            'dbData = fncDataSelect(0)
            'If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
            '    '�f�[�^�����݂��Ȃ��ׁA�����̓G���[
            '    '���b�Z�[�W���o�͌�A�����O��Ԃɂ���B

            '    strMsg.Append("alert('�f�[�^�����݂��܂���');")

            '    Call fncIni_statebf()
            '    '//--------------------------------------------------------------------------
            '    '�t�H�[�J�X���Z�b�g����
            '    If hdnTANKBN.Value = "1" Then
            '        strMsg.Append("Form1.rdoKBN1.focus();")
            '    ElseIf hdnTANKBN.Value = "2" Then
            '        strMsg.Append("Form1.rdoKBN2.focus();")
            '    ElseIf hdnTANKBN.Value = "3" Then
            '        strMsg.Append("Form1.rdoKBN3.focus();")
            '    End If
            'Else
            '    '�f�[�^�����݂���ׁA�V�K�o�^�͕s��
            '    '�f�[�^���o�͌�A�������Ԃɂ���B

            '    '------------------------------------
            '    '<TODO>�f�[�^���o�͂���
            '    Dim strTemp As String

            '    strTemp = Convert.ToString(dbData.Tables(0).Rows(0).Item("KBN"))
            '    If strTemp = "3" Then
            '        rdoKBN1.Checked = True               '//�i�`�x���S���҂�I������
            '        rdoKBN2.Checked = False
            '        rdoKBN3.Checked = False
            '    ElseIf strTemp = "1" Then
            '        rdoKBN1.Checked = False              '//�Ď��Z���^�[�S���҂�I������
            '        rdoKBN2.Checked = True
            '        rdoKBN3.Checked = False
            '    ElseIf strTemp = "2" Then
            '        rdoKBN1.Checked = False              '//�o����ВS���҂�I������
            '        rdoKBN2.Checked = False
            '        rdoKBN3.Checked = True
            '    End If

            '    '�N���C�A���g�R�[�h
            '    hdnKURACD.Value = Convert.ToString(dbData.Tables(0).Rows(0).Item("KURACD"))
            '    '�N���C�A���g��
            '    If strTemp = "3" Then                   '//�i�`�x���S����
            '        txtKURACD.Text = Convert.ToString(dbData.Tables(0).Rows(0).Item("KURACD")) & " : " & Convert.ToString(dbData.Tables(0).Rows(0).Item("CLI_NAME"))
            '    Else
            '        txtKURACD.Text = ""
            '    End If
            '    '�R�[�h
            '    hdnCODE.Value = Convert.ToString(dbData.Tables(0).Rows(0).Item("CODE"))
            '    '�R�[�h����
            '    If strTemp = "3" Then                   '//�i�`�x���S����
            '        txtCODE.Text = Convert.ToString(dbData.Tables(0).Rows(0).Item("CODE")) & " : " & Convert.ToString(dbData.Tables(0).Rows(0).Item("JAS_NAME"))
            '    ElseIf strTemp = "1" Then               '//�Ď��Z���^�[�S����
            '        txtCODE.Text = Convert.ToString(dbData.Tables(0).Rows(0).Item("CODE")) & " : " & Convert.ToString(dbData.Tables(0).Rows(0).Item("KANSI_NAME"))
            '    ElseIf strTemp = "2" Then               '//�o����ВS����
            '        '--- ��2005/05/21 MOD Falcon�� ---
            '        'txtCODE.Text = Convert.ToString(dbData.Tables(0).Rows(0).Item("CODE")) & " : " & Convert.ToString(dbData.Tables(0).Rows(0).Item("KAISYA_NAME"))
            '        txtCODE.Text = Convert.ToString(dbData.Tables(0).Rows(0).Item("CODE")) & " : " & Convert.ToString(dbData.Tables(0).Rows(0).Item("KAISYA_NAME"))
            '        '--- ��2005/05/21 MOD Falcon�� ---
            '    End If

            '    hdnTIME.Value = Convert.ToString(dbData.Tables(0).Rows(0).Item("TIME"))

            '    If pstrKBN = "1" Then
            '        '�����{�^��������
            '        Call fncIni_stateaf()

            '        '//------------------------------
            '        '<TODO>�t�H�[�J�X���Z�b�g����i�f�[�^�����݂����̂ŃL�[�ȊO�ɃZ�b�g�j
            '        strMsg.Append("Form1.txtTANNM.focus();")
            '    End If
            'End If
            'dbData.Dispose()

        Catch ex As Exception
            strRec = ex.ToString
            Dim ErrMsgC As New CErrMsg
            strMsg.Append("alert('�V�X�e���G���[�F" & ErrMsgC.mGetArtMsg(ex.ToString) & "');")
        End Try

        Return strRec

    End Function

    ''******************************************************************************
    ''* ���̓L�[�ɂ��f�[�^�̌������s���܂��B
    ''* pintKbn�@0:�����{�^���������f�[�^�o��
    ''*        �@1:�V�K�{�^���������f�[�^�J�E���g�o��
    ''******************************************************************************
    'Private Function fncDataSelect(ByVal pintkbn As Integer) As DataSet

    '    'intKbn     0:�����{�^������
    '    'intKbn     1:�V�K�{�^������

    '    '//------------------------------------------
    '    '//<TODO>Select���̍쐬
    '    Dim SQLC As New MSTASJAG00CCSQL.CSQL
    '    Dim SqlParamC As New CSQLParam
    '    Dim strSQL As New StringBuilder("")
    '    Dim dbData As DataSet

    '    strSQL.Append("SELECT ")
    '    If pintkbn = 0 Then
    '        '�����Ȃ̂őS�Ă̍��ڂ��擾���܂�
    '        strSQL.Append("TA.KBN, ")
    '        strSQL.Append("TA.KURACD, ")
    '        strSQL.Append("CL.CLI_NAME, ")
    '        strSQL.Append("TA.CODE, ")
    '        '--- ��2005/05/21 ADD Falcon�� ---
    '        'strSQL.Append("JA.JAS_NAME, ")
    '        'strSQL.Append("SH.KAISYA_NAME, ")
    '        strSQL.Append("JA_NAME || JAS_NAME AS JAS_NAME, ")
    '        strSQL.Append("SH.KAISYA_NAME || KYOTEN_NAME AS KAISYA_NAME, ")
    '        '--- ��2005/05/21 ADD Falcon�� ---
    '        strSQL.Append("KA.KANSI_NAME, ")
    '        strSQL.Append("TA.TANCD, ")
    '        strSQL.Append("TA.TANNM, ")
    '        strSQL.Append("TA.RENTEL1, ")
    '        strSQL.Append("TA.RENTEL2, ")
    '        strSQL.Append("TA.FAXNO, ")
    '        strSQL.Append("TA.DISP_NO, ")
    '        strSQL.Append("TA.BIKO, ")
    '        strSQL.Append("TA.ADD_DATE, ")
    '        strSQL.Append("TA.EDT_DATE, ")
    '        strSQL.Append("TA.TIME ")
    '    Else
    '        '�V�K�Ȃ̂őΏۃf�[�^�̃J�E���g���擾���܂�
    '        strSQL.Append("COUNT(*) AS CNT ")
    '    End If
    '    strSQL.Append("FROM  M05_TANTO TA, ")
    '    strSQL.Append("      CLIMAS CL, ")
    '    strSQL.Append("      HN2MAS JA, ")
    '    strSQL.Append("      KANSIMAS KA,")
    '    strSQL.Append("      SHUTUDOMAS SH ")
    '    strSQL.Append("WHERE TA.KBN   = :KBN ")
    '    '--- ��2005/07/19 ADD Falcon�� ---
    '    strSQL.Append("  AND TA.KURACD  = :KURACD ")
    '    '--- ��2005/07/19 ADD Falcon�� ---
    '    strSQL.Append("  AND TA.CODE  = :CODE ")
    '    strSQL.Append("  AND TA.TANCD = :TANCD ")
    '    strSQL.Append("  AND TA.KURACD = CL.CLI_CD(+) ")
    '    strSQL.Append("  AND TA.KURACD = JA.CLI_CD(+) ")
    '    strSQL.Append("  AND TA.CODE = JA.HAN_CD(+) ")
    '    strSQL.Append("  AND TA.CODE = KA.KANSI_CD(+) ")
    '    'strSQL.Append("  AND TA.CODE = SH.SHUTU_CD(+) ")
    '    strSQL.Append("  AND TA.CODE = (SH.SHUTU_CD(+) || SH.KYOTEN_CD(+)) ")

    '    'strSQL.Append("  AND '00' = SH.KYOTEN_CD(+) ") '--- 2005/07/20 DEL Falcon

    '    'hdnTANKBN.Value 1:�i�`�S���ҁ@2:�Ď��Z���^�[�S���ҁ@3:�o����ВS����
    '    If hdnTANKBN.Value = "1" Then
    '        SqlParamC.fncSetParam("KBN", True, "3")
    '    ElseIf hdnTANKBN.Value = "2" Then
    '        SqlParamC.fncSetParam("KBN", True, "1")
    '    ElseIf hdnTANKBN.Value = "3" Then
    '        SqlParamC.fncSetParam("KBN", True, "2")
    '    End If

    '    If hdnCODE.Value.Length > 0 Then
    '        SqlParamC.fncSetParam("CODE", True, hdnCODE.Value)
    '    End If
    '    If txtTANCD.Text.Length > 0 Then
    '        SqlParamC.fncSetParam("TANCD", True, txtTANCD.Text)
    '    End If

    '    '--- ��2005/07/19 ADD Falcon�� ---
    '    If hdnTANKBN.Value = "1" Then
    '        If hdnKURACD.Value.Length > 0 Then
    '            SqlParamC.fncSetParam("KURACD", True, hdnKURACD.Value)
    '        End If
    '    Else
    '        SqlParamC.fncSetParam("KURACD", True, "ZZZZ")
    '    End If
    '    '--- ��2005/07/19 ADD Falcon�� ---

    '    dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)
    '    Return dbData
    'End Function

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
