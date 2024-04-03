'***********************************************
'�ݐϏ��ꗗ  �ꗗ���
'***********************************************
' �ύX����
' 2011/02/01 T.Watabe ���[�G�N�Z�������kexe�`���֕ύX���ē]��������@����߂�B���̂܂ܓ]���B

Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common
Imports JPG.Common.log

Imports System.Text

Partial Class KERUIJOG00
    Inherits System.Web.UI.Page
    Protected WithEvents dbData As System.Data.DataSet

    '******************************************************************************
    ' HttpHeader
    '******************************************************************************
    Protected HttpHeaderC As New CHttpHeader

    '<TODO>�錾���ʎd�l
    '******************************************************************************
    ' �F�؃N���X
    '******************************************************************************
    Protected AuthC As CAuthenticate

    '******************************************************************************
    ' ���t�N���X
    '******************************************************************************
    Protected DateFncC As New CDateFnc

    '******************************************************************************
    ' �����N���X                 2017/02/15 H.Mori add 2016���P�J�� No9-1
    '******************************************************************************
    Protected TimeFncC As New CTimeFnc

    '******************************************************************************
    ' �N�b�L�[
    '******************************************************************************
    Protected ConstC As New CConst
    Protected WithEvents btnSelectTest As System.Web.UI.HtmlControls.HtmlInputButton

    '******************************************************************************
    ' ScriptMessage
    '******************************************************************************
    Private strMsg As New StringBuilder("")      '//<script>�͕K�v�Ȃ�

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
    Private Sub Page_Load(ByVal sender As System.Object, _
                                            ByVal e As System.EventArgs) Handles MyBase.Load

        '2012/04/04 NEC ou Add Str
        '.NET�̎d�l�ύX�ɂ��AReadOnly������ASPX�ł���ƁA�T�[�o���Œl�̎Q�Ƃ��ł��Ȃ��Ȃ邽�߁AVB����Attribute�ł���
        If MyBase.IsPostBack = False Then
            txtKURACD.Attributes.Add("ReadOnly", "true")
            txtKYOCD.Attributes.Add("ReadOnly", "true")
            '2015/11/04 W.GANEKO 2015���P�J�� ��6 start
            'txtJACD.Attributes.Add("ReadOnly", "true")
            'txtJASCD.Attributes.Add("ReadOnly", "true")
            txtHANJICD_F.Attributes.Add("ReadOnly", "true")
            txtHANJICD_T.Attributes.Add("ReadOnly", "true")
            txtJACD_F.Attributes.Add("ReadOnly", "true")
            txtJACD_T.Attributes.Add("ReadOnly", "true")
            txtJASCD_F.Attributes.Add("ReadOnly", "true")
            txtJASCD_T.Attributes.Add("ReadOnly", "true")
            '2015/11/04 W.GANEKO 2015���P�J�� ��6 end
        End If
        '2012/04/04 NEC ou Add End

        '//------------------------------------------
        '//�@HTTP�w�b�_�𑗐M
        HttpHeaderC.mNoCache(Response)

        '//------------------------------------------
        '//�@�F�؃N���X�̃C���X�^���X����
        AuthC = New CAuthenticate(Request, Response)
        'AuthC.pCENTERCD()
        '//------------------------------------------
        '//�@�F�؏���
        '<TODO>�F�g�p�\�������w�肷��
        '[�Ή����ʈꗗ]�g�p�\����(�^:��/�c:�~/��:��/�o:�~)
        '20051201 NEC UPDATE START
        '[�Ή����ʈꗗ]�g�p�\����(�^:��/�c:��/��:��/�o:�~)
        'AuthC.fncAuthCheck(Server, AuthC.pGROUP_UNKOU & "," & AuthC.pGROUP_KANSHI)
        AuthC.fncAuthCheck(Server, AuthC.pGROUP_UNKOU & "," & AuthC.pGROUP_KANSHI & "," & AuthC.pGROUP_EIGYOU)
        '20051201 NEC UPDATE END

        '//------------------------------------------
        '//�|�b�v�A�b�v�o��
        If hdnKensaku.Value = "COPOPUPG00" Then
            Server.Transfer("../../../Popup/COPOPUPG00.aspx")
        End If
        '//�J�����_�[�̏o��
        If hdnKensaku.Value = "COCALDRG00" Then
            Server.Transfer("../../../Popup/COCALDRG00.aspx")
        End If
        '//�����`�F�b�N�X�N���v�g
        If hdnKensaku.Value = "KERUIJCG00" Then
            Server.Transfer("./KERUIJCG00.aspx")
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
             MyBase.MapPath("../../../KE/KERUIJOG/KERUIJOG00/") & "KERUIJOG00.js"))
        '<�t�H�[�J�X�֘A�֐�>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncFo.js"))
        '<���t�֘A�֐�>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncDate.js"))
        '<���Ԋ֘A�֐�> 
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncTime.js")) '2017/02/14 H.Mori add ���P2016 No9-1
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
            '//�@���߂ĊJ�������������s�����

            '//--------------------------------------------------------------------------
            '<TODO>�����\���Ƃ��ĕK�v�ȃR���g���[���̐ݒ���s���܂�
            '      ��)��ʏ����\�����́��������I������Ă��邱�Ɓc�c���̏���
            '//--------------------------------------------------------------------------
            '�@�������ʂɂ���ʂ̏�Ԃ̐ݒ�------------------------
            '�@��ʂ��y�����O��ԁz�ɂ���i���̓f�[�^�͂��̂܂ܑJ�ڂ�����j
            '//-------------------------------------------

            '�Ώۊ��Ԃɓ������t��\���@2013/12/05 T.Ono add �Ď����P2013
            txtTRGDATE_From.Text = DateTime.Today.ToString("yyyy/MM/dd")
            txtTRGDATE_To.Text = DateTime.Today.ToString("yyyy/MM/dd")

            '//�t�H�[�J�X���Z�b�g����
            strMsg.Append("Form1.btnKURACD.focus();")
        Else
            '//--------------------------------------
            '//�@�Q��ڈȍ~���s�����
            '//--------------------------------------------------------------------------
            '//����ʕ\������R���{�{�b�N�X�͊e�ŏI�C�x���g/���\�b�h��CALL���܂�
            '//--------------------------------------------------------------------------
        End If

        '//-------------------------------------------------
        '<TODO>�����̉��ID��HIDDEN��hdnMyAspx�ɏ������ށi�V�X�e�����ʁj
        hdnMyAspx.Value = "KERUIJOG00"
        '//-------------------------------------------------

    End Sub

    '******************************************************************************
    ' Excel�o��(�`�F�b�N��)
    '******************************************************************************
    Private Sub btnSelect_ServerClick(ByVal sender As System.Object, _
                                    ByVal e As System.EventArgs) Handles btnSelect.ServerClick
        Dim strRec As String
        'Dim bytExcel() As Byte '2014/01/16 T.Ono del ���P�Ή�2013 Excel�𒼐ڏo�͂ɕύX
        Dim KERUIJOG00C As New KERUIJOG00KERUIJOW00.KERUIJOW00

        Dim strSTKBN As String
        Dim strPGKBN As String
        Dim strKIKANKBN As String '2017/02/15 H.Mori add ���P2016 No9-1

        '//�@�F�؃N���X�̃C���X�^���X����
        AuthC = New CAuthenticate(Request, Response)

        '�����敪�擾
        If rdoSTKBN1.Checked = True Then
            strSTKBN = "1"      '�d�b
        ElseIf rdoSTKBN2.Checked = True Then
            strSTKBN = "2"      '�x��
        ElseIf rdoSTKBN3.Checked = True Then
            '2011.11.21 ADD H.Uema
            strSTKBN = "3"
        Else
            strSTKBN = ""
        End If
        '���y�[�W����
        If rdoPGKBN1.Checked = True Then
            strPGKBN = "1"      'JA�P��
            '2015/11/04 W.GANEKO 2015���P�J�� ��6 start
            'ElseIf rdoPGKBN2.Checked = True Then
            '    strPGKBN = "2"      '�����Z���^�[�P��
            'Else
            '    strPGKBN = "3"      '���y�[�W�Ȃ�
            'End If
        ElseIf rdoPGKBN2.Checked = True Then
            strPGKBN = "2"      'JA�x���P��
        ElseIf rdoPGKBN3.Checked = True Then
            strPGKBN = "3"      '�̔����ƎҒP��
        ElseIf rdoPGKBN4.Checked = True Then
            strPGKBN = "4"      '�����Z���^�[�P��
        Else
            strPGKBN = "5"      '���y�[�W�Ȃ�
        End If
        '2015/11/04 W.GANEKO 2015���P�J�� ��6 end
        '2015/11/04 w.ganeko 2015���P�J�� ��6 start
        Dim strHOKOKU As String = ""
        '�񍐗v�E�s�v
        If rdoHOKOKU1.Checked = True Then
            strHOKOKU = "2"      '�K�v�̂�
        ElseIf rdoHOKOKU2.Checked = True Then
            strHOKOKU = "0"      '�S��
        End If
        Dim strTAIO As New StringBuilder("")
        '�Ή��敪
        '�d�b
        If checkTEL.Checked = True Then
            strTAIO.Append("1")      '�d�b
        Else
            strTAIO.Append("0")      '�d�b
        End If
        '�o��
        strTAIO.Append(",")
        If checkSYTUDO.Checked = True Then
            strTAIO.Append("2")      '�o��
        Else
            strTAIO.Append("0")      '�o��
        End If
        '�d��
        strTAIO.Append(",")
        If checkTYOFUKU.Checked = True Then
            strTAIO.Append("3")
        Else
            strTAIO.Append("0")
        End If
        '2015/11/04 w.ganeko 2015���P�J�� ��6 end

        '�o���˗����e�E���l    2020/11/01 T.Ono add 2020�Ď����P
        Dim strSdPrtKBN As String '2020/11/01 T.Ono add 2020�Ď����P
        If checkSdPrt.Checked = True Then
            strSdPrtKBN = "1"     '�\������
        Else
            strSdPrtKBN = "0"     '�\���Ȃ�
        End If

        '2017/02/15 H.Mori add ���P2016 No9-1 START
        '�Ώۊ��ԋ敪�擾 2014/12/11 H.Hosoda add �Ď����P2014 ��13
        If rdoKIKAN1.Checked = True Then
            strKIKANKBN = "1"     '�Ή�������
        Else
            strKIKANKBN = "2"     '��M��
        End If
        '2017/02/15 H.Mori add ���P2016 No9-1 END

        Dim strRecMsg As String = ""

        '2012/04/04 NEC ou Upd
        'strRec = KERUIJOG00C.mExcel( _
        '                         Request.Cookies.Get("ASP.NET_SessionId").Value, _
        '                         hdnKURACD.Value, _
        '                         hdnKYOCD.Value, _
        '                         hdnJACD.Value, _
        '                         hdnJASCD.Value, _
        '                         strSTKBN, _
        '                         strPGKBN, _
        '                         DateFncC.mHenkanGet(txtTRGDATE_From.Text), _
        '                         DateFncC.mHenkanGet(txtTRGDATE_To.Text), _
        '                         txtKURACD.Text, _
        '                         txtKYOCD.Text, _
        '                         txtJACD.Text, _
        '                         txtJASCD.Text, _
        '                         ConstC.pPageMax, _
        '                         AuthC.pCENTERCD _
        '                         )
        '2015/11/04 W.GANEKO 2015���P�J�� ��6 start
        'strRec = KERUIJOG00C.mExcel( _
        '                         Me.Session.SessionID, _
        '                         hdnKURACD.Value.Trim, _
        '                         hdnKYOCD.Value.Trim, _
        '                         hdnJACD.Value.Trim, _
        '                         hdnJASCD.Value.Trim, _
        '                         strSTKBN, _
        '                         strPGKBN, _
        '                         DateFncC.mHenkanGet(txtTRGDATE_From.Text), _
        '                         DateFncC.mHenkanGet(txtTRGDATE_To.Text), _
        '                         txtKURACD.Text, _
        '                         txtKYOCD.Text, _
        '                         txtJACD.Text, _
        '                         txtJASCD.Text, _
        '                         ConstC.pPageMax, _
        '                         AuthC.pCENTERCD _
        '                         )
        '2017/02/15 H.Mori mod ���P2016 No9-1 START
        'strRec = KERUIJOG00C.mExcel( _
        '                         Me.Session.SessionID, _
        '                         hdnKURACD.Value.Trim, _
        '                         hdnKYOCD.Value.Trim, _
        '                         hdnJACD_F.Value.Trim, _
        '                         hdnJACD_T.Value.Trim, _
        '                         hdnJASCD_F.Value.Trim, _
        '                         hdnJASCD_T.Value.Trim, _
        '                         strSTKBN, _
        '                         strPGKBN, _
        '                         DateFncC.mHenkanGet(txtTRGDATE_From.Text), _
        '                         DateFncC.mHenkanGet(txtTRGDATE_To.Text), _
        '                         txtKURACD.Text, _
        '                         txtKYOCD.Text, _
        '                         txtJACD_F.Text, _
        '                         txtJACD_T.Text, _
        '                         txtJASCD_F.Text, _
        '                         txtJASCD_T.Text, _
        '                         ConstC.pPageMax, _
        '                         AuthC.pCENTERCD, _
        '                         hdnHANJICD_F.Value.Trim, _
        '                         hdnHANJICD_T.Value.Trim, _
        '                         strTAIO.ToString, _
        '                         strHOKOKU, _
        '                         txtHANJICD_F.Text, _
        '                         txtHANJICD_T.Text _
        '                         )
        'TODO
        '2015/11/04 W.GANEKO 2015���P�J�� ��6 end

        '2012/04/04 NEC ou Upd
        '2020/11/01 T.Ono mod 2020�Ď����P strSdPrtKBN �ǉ�
        strRec = KERUIJOG00C.mExcel(
                                 Me.Session.SessionID,
                                 hdnKURACD.Value.Trim,
                                 hdnKYOCD.Value.Trim,
                                 hdnJACD_F.Value.Trim,
                                 hdnJACD_T.Value.Trim,
                                 hdnJASCD_F.Value.Trim,
                                 hdnJASCD_T.Value.Trim,
                                 strSTKBN,
                                 strPGKBN,
                                 DateFncC.mHenkanGet(txtTRGDATE_From.Text),
                                 DateFncC.mHenkanGet(txtTRGDATE_To.Text),
                                 txtKURACD.Text,
                                 txtKYOCD.Text,
                                 txtJACD_F.Text,
                                 txtJACD_T.Text,
                                 txtJASCD_F.Text,
                                 txtJASCD_T.Text,
                                 ConstC.pPageMax,
                                 AuthC.pCENTERCD,
                                 hdnHANJICD_F.Value.Trim,
                                 hdnHANJICD_T.Value.Trim,
                                 strTAIO.ToString,
                                 strHOKOKU,
                                 txtHANJICD_F.Text,
                                 txtHANJICD_T.Text,
                                 strKIKANKBN,
                                 TimeFncC.mHenkanGet(txtTRGTIME_From.Text),
                                 TimeFncC.mHenkanGet(txtTRGTIME_To.Text),
                                 strSdPrtKBN
                                 )

        '2017/02/15 H.Mori mod ���P2016 No9-1 END

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
            '2011/02/10 T.Watabe ���̕����֖߂��B
            If True Then
                '�u�J���A�ۑ��v�̃_�C�����O���o��悤��HTTP�w�b�_�ɒǉ�
                '�t�@�C�����́AHttpUtility.UrlEncode���\�b�h���g�p����SJIS�ɃG���R�[�h����K�v������
                '.xls�`���ɕύX 2013/12/05 T.Ono mod �Ď����P2013
                'HttpHeaderC.mDownLoad(Response, "�ݐϏ��ꗗ.exe") ' 2011/02/01 T.Watabe edit
                HttpHeaderC.mDownLoadXLS(Response, "�ݐϏ��ꗗ.xls")
                '2014/01/16 T.Ono mod �Ď����P2013 excel�𒼐ڊJ�� Start
                'bytExcel = Convert.FromBase64String(strRec) 'Web�T�[�r�X�̖߂�l�iBASE64�̃e�L�X�g�j���o�C�g�f�[�^�ɕϊ�����
                'Response.BinaryWrite(bytExcel) '�t�@�C�����M
                Response.WriteFile(strRec)
                '2014/01/16 T.Ono mod �Ď����P2013 excel�𒼐ڊJ�� End
                Response.End()
            Else
                '2011/02/01 T.Watabe �G�N�Z���𒼐ڃ_�E�����[�h����悤�ɕύX
                Dim sFile As String
                Dim sPath As String
                Dim pos As Integer
                pos = strRec.LastIndexOf("\\")
                If pos <= 0 Then
                    strRecMsg = "�t�@�C���p�X�Ɂ��}�[�N���܂܂�Ă��܂���B[" & strRec & "]"
                    strMsg.Append("alert('" & strRecMsg & "');")
                    strMsg.Append("Form1.btnSelect.focus();")
                Else
                    'sFile = "20110204143856rbz1mou53ostff55k12fv02a-KERUIJOX00.xls"
                    sFile = strRec.Substring(pos + 1)
                    sFile = HttpUtility.UrlEncode(sFile)
                    'sPath = "/JPGAP/TEMP/00/KERUIJOX00/"
                    'sPath = Server.MapPath(sPath)
                    sPath = strRec.Substring(0, pos)
                    sPath = HttpUtility.UrlEncode(sPath)
                    Response.Redirect("/JPG/test2.aspx?file=" & sFile & "&path=" & sPath)
                    Response.End()
                End If
            End If

            strRecMsg = "OK"
        End If

        strRec = strRecMsg
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

    Private Sub btnSelectTest_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectTest.ServerClick

        Dim sFile As String
        Dim sPath As String
        sFile = "20110204143856rbz1mou53ostff55k12fv02a-KERUIJOX00.xls"
        sFile = HttpUtility.UrlEncode(sFile)
        sPath = "/JPGAP/TEMP/00/KERUIJOX00/"
        sPath = Server.MapPath(sPath)
        sPath = HttpUtility.UrlEncode(sPath)
        Response.Redirect("/JPG/test2.aspx?file=" & sFile & "&path=" & sPath)
        Response.End()
    End Sub
    '******************************************************************************
    '* �����`�F�b�N�p��ʂɓn���p�����[�^�ݒ�
    '******************************************************************************
    Public ReadOnly Property pKuracd() As String
        Get
            Return hdnKURACD.Value.Trim     '2012/04/04 NEC ou Add Upd
        End Get
    End Property
    Public ReadOnly Property pKyocd() As String
        Get
            Return hdnKYOCD.Value.Trim      '2012/04/04 NEC ou Add Upd
        End Get
    End Property
    '2015/11/04 w.ganeko 2015���P�J�� ��6 start
    'Public ReadOnly Property pJacd() As String
    '    Get
    '        Return hdnJACD.Value.Trim       '2012/04/04 NEC ou Add Upd
    '    End Get
    'End Property
    'Public ReadOnly Property pJascd() As String
    '    Get
    '        Return hdnJASCD.Value.Trim      '2012/04/04 NEC ou Add Upd
    '    End Get
    'End Property
    Public ReadOnly Property pJacdFr() As String
        Get
            Return hdnJACD_F.Value.Trim
        End Get
    End Property
    Public ReadOnly Property pJacdTo() As String
        Get
            Return hdnJACD_T.Value.Trim
        End Get
    End Property
    Public ReadOnly Property pJascdFr() As String
        Get
            Return hdnJASCD_F.Value.Trim
        End Get
    End Property
    Public ReadOnly Property pJascdTo() As String
        Get
            Return hdnJASCD_T.Value.Trim
        End Get
    End Property
    Public ReadOnly Property pHanbaiFr() As String
        Get
            Return hdnHANJICD_F.Value.Trim()
        End Get
    End Property
    Public ReadOnly Property pHanbaiTo() As String
        Get
            Return hdnHANJICD_T.Value.Trim
        End Get
    End Property
    Public ReadOnly Property pHkKbn() As String
        Get
            Dim strHOKOKU As String = ""
            '�񍐗v�E�s�v
            If rdoHOKOKU1.Checked = True Then
                strHOKOKU = "2"      '�K�v�̂�
            ElseIf rdoHOKOKU2.Checked = True Then
                strHOKOKU = "0"      '�S��
            End If
            Return strHOKOKU
        End Get
    End Property
    Public ReadOnly Property pTaiKbn() As String
        Get
            Dim strTAIO As New StringBuilder("")
            '�Ή��敪
            '�d�b
            If checkTEL.Checked = True Then
                strTAIO.Append("1")      '�d�b
            Else
                strTAIO.Append("0")      '�d�b
            End If
            '�o��
            strTAIO.Append(",")
            If checkSYTUDO.Checked = True Then
                strTAIO.Append("2")      '�o��
            Else
                strTAIO.Append("0")      '�o��
            End If
            '�d��
            strTAIO.Append(",")
            If checkTYOFUKU.Checked = True Then
                strTAIO.Append("3")
            Else
                strTAIO.Append("0")
            End If

            Return strTAIO.ToString
        End Get
    End Property
    '2015/11/04 w.ganeko 2015���P�J�� ��6 end
    Public ReadOnly Property pHatKbn() As String
        Get
            Dim strSTKBN As String
            If rdoSTKBN1.Checked = True Then
                strSTKBN = "1"      '�d�b
            ElseIf rdoSTKBN2.Checked = True Then
                strSTKBN = "2"      '�x��
            ElseIf rdoSTKBN3.Checked = True Then
                '2011.11.21 ADD H.Uema
                strSTKBN = "3"
            Else
                strSTKBN = ""
            End If

            Return strSTKBN
        End Get
    End Property
    Public ReadOnly Property pYmdFrom() As String
        Get
            Return DateFncC.mHenkanGet(txtTRGDATE_From.Text)
        End Get
    End Property
    Public ReadOnly Property pYmdTo() As String
        Get
            Return DateFncC.mHenkanGet(txtTRGDATE_To.Text)
        End Get
    End Property
    '2017/02/15 H.Mori add ���P2016 No9-1 START
    Public ReadOnly Property pKikankbn() As String
        Get
            Dim strKIKANKBN As String = ""
            '�Ώۊ��ԋ敪
            If rdoKIKAN1.Checked = True Then
                strKIKANKBN = "1"      '�Ή�������
            ElseIf rdoKIKAN2.Checked = True Then
                strKIKANKBN = "2"      '��M��
            End If
            Return strKIKANKBN
        End Get
    End Property
    Public ReadOnly Property pTimeFrom() As String
        Get
            Return TimeFncC.mHenkanGet(txtTRGTIME_From.Text)
        End Get
    End Property
    Public ReadOnly Property pTimeTo() As String
        Get
            Return TimeFncC.mHenkanGet(txtTRGTIME_To.Text)
        End Get
    End Property
    '2017/02/15 H.Mori add ���P2016 No9-1 END

    '******************************************************************************
    '*�@�T�@�v�F�i���ݏ�����n���v���p�e�B
    '*�@���@�l�F(���R�[�h)
    '******************************************************************************
    Public ReadOnly Property pCode1() As String
        Get
            Dim strRec As String
            '2015/11/04 W.GANEKO 2015���P�J�� ��6 START
            'Select Case hdnPopcrtl.Value
            '    Case "0"
            ' 2007/08/09 T.Watabe edit ��s���Ă���Ď��Z���^�[�̃N���C�A���g���\�������悤�ɕύX
            ''�^�s�J�����̏ꍇ�͑S�Ă̊Ď��Z���^�[��I���\
            ''�ȊO�̏ꍇ�͑�s���g�p�����Ɏ����̊Ď��Z���^�[�̂ݎg�p�\
            'Dim strGROUPNAME As String = AuthC.pGROUPNAME
            'Dim arrGroupName() As String = strGROUPNAME.Split(Convert.ToChar(","))
            'If Array.IndexOf(arrGroupName, AuthC.pGROUP_UNKOU) >= 0 Then
            'strRec = AuthC.pAUTHCENTERCD
            'Else
            '    strRec = AuthC.pCENTERCD
            'End If
            '    Case "1"
            'strRec = ""
            'If hdnKURACD.Value <> "" Then
            'strRec = hdnKURACD.Value.Substring(1, 2)        ''�N���C�A���g�R�[�h(4)��JA�x���R�[�h(1)�{���R�[�h(2)�{�C��1����(1)
            'End If
            '    Case "2"
            'strRec = hdnKURACD.Value       2014/01/21 T.Ono mod �Ď����P2013 Trim������
            'strRec = hdnKURACD.Value.Trim
            '    Case "3"
            'strRec = hdnKURACD.Value       2014/01/21 T.Ono mod �Ď����P2013 Trim������
            'strRec = hdnKURACD.Value.Trim
            'End Select
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = AuthC.pAUTHCENTERCD
                Case "1"
                    strRec = ""
                    If hdnKURACD.Value <> "" Then
                        strRec = hdnKURACD.Value.Substring(1, 2)        ''�N���C�A���g�R�[�h(4)��JA�x���R�[�h(1)�{���R�[�h(2)�{�C��1����(1)
                    End If
                Case "2", "3", "4", "5", "6", "7"
                    strRec = hdnKURACD.Value.Trim
            End Select
            '2015/11/04 W.GANEKO 2015���P�J�� ��6 END
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�i���ݏ�����n���v���p�e�B
    '*�@���@�l�F(�����Z���^�[�R�[�h/�i�`�R�[�h)
    '******************************************************************************
    Public ReadOnly Property pCode2() As String
        Get
            Dim strRec As String
            '2015/11/04 W.GANEKO 2015���P�J�� ��6 START
            'Select Case hdnPopcrtl.Value
            '    Case "0"
            'strRec = ""
            '    Case "1"
            'strRec = ""
            '    Case "2"
            ''strRec = hdnKYOCD.Value    '--- 2005/05/24 MOD Falcon ---
            'strRec = ""
            '    Case "3"
            ''strRec = hdnJACD.Value       2014/01/21 T.Ono mod �Ď����P2013 Trim������
            'strRec = hdnJACD.Value.Trim
            'End Select
            Select Case hdnPopcrtl.Value
                Case "0", "1", "2", "3", "6", "7"
                    strRec = ""

                '2019/11/01 T.Ono mod �Ď����P2019 START
                'Case "4", "5"
                '    strRec = hdnJACD_F.Value.Trim
                Case "4"
                    strRec = hdnJACD_F.Value.Trim
                Case "5"
                    strRec = hdnJACD_T.Value.Trim
                    '2019/11/01 T.Ono mod �Ď����P2019 END
            End Select
            '2015/11/04 W.GANEKO 2015���P�J�� ��6 END
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�o�͂���ꗗ�̖��O��n���v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pListName() As String
        Get
            Dim strRec As String
            '2015/11/04 W.GANEKO 2015���P�J�� ��6 START
            'Select Case hdnPopcrtl.Value
            '    Case "0"
            'strRec = "�N���C�A���g�ꗗ"
            '    Case "1"
            'strRec = "�����Z���^�[�ꗗ"
            '    Case "2"
            'strRec = "�i�`�ꗗ"
            '    Case "3"
            'strRec = "�i�`�x���ꗗ"
            'End Select
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = "�N���C�A���g�ꗗ"
                Case "1"
                    strRec = "�����Z���^�[�ꗗ"
                Case "2", "3"
                    strRec = "�i�`�ꗗ"
                Case "4", "5"
                    strRec = "�i�`�x���ꗗ"
                Case "6", "7"
                    strRec = "�̔����Ǝ҈ꗗ"
            End Select
            '2015/11/04 W.GANEKO 2015���P�J�� ��6 END
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�o�͂���ꗗ�𐧌䂷��l��n���v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pListCd() As String
        Get
            Dim strRec As String
            '2015/11/04 W.GANEKO 2015���P�J�� ��6 START
            'Select Case hdnPopcrtl.Value
            '    Case "0"
            'strRec = "CLI"
            '    Case "1"
            'strRec = "KYO"
            '    Case "2"
            'strRec = "JA"
            '    Case "3"
            'strRec = "JASS"
            'End Select
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = "CLI"
                Case "1"
                    strRec = "KYO"
                Case "2", "3"
                    strRec = "JA"
                Case "4", "5"
                    strRec = "JASS"
                Case "6", "7"
                    strRec = "HANG"
            End Select
            '2015/11/04 W.GANEKO 2015���P�J�� ��6 END
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�R�[�h��Ԃ��I�u�W�F�N�g�̖��O�l��n���v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pBackCode() As String
        Get
            Dim strRec As String
            '2015/11/04 W.GANEKO 2015���P�J�� ��6 START
            'Select Case hdnPopcrtl.Value
            '    Case "0"
            'strRec = "hdnKURACD"
            '    Case "1"
            'strRec = "hdnKYOCD"
            '    Case "2"
            'strRec = "hdnJACD"
            '    Case "3"
            'strRec = "hdnJASCD"
            'End Select
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = "hdnKURACD"
                Case "1"
                    strRec = "hdnKYOCD"
                Case "2"
                    strRec = "hdnJACD_F"
                Case "3"
                    strRec = "hdnJACD_T"
                Case "4"
                    strRec = "hdnJASCD_F"
                Case "5"
                    strRec = "hdnJASCD_T"
                Case "6"
                    strRec = "hdnHANJICD_F"
                Case "7"
                    strRec = "hdnHANJICD_T"
            End Select
            '2015/11/04 W.GANEKO 2015���P�J�� ��6 END
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F���̂�Ԃ��I�u�W�F�N�g�̖��O�l��n���v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pBackName() As String
        Get
            Dim strRec As String
            '2015/11/04 W.GANEKO 2015���P�J�� ��6 START
            'Select Case hdnPopcrtl.Value
            '    Case "0"
            'strRec = "txtKURACD"
            '    Case "1"
            'strRec = "txtKYOCD"
            '    Case "2"
            'strRec = "txtJACD"
            '    Case "3"
            'strRec = "txtJASCD"
            'End Select
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = "txtKURACD"
                Case "1"
                    strRec = "txtKYOCD"
                Case "2"
                    strRec = "txtJACD_F"
                Case "3"
                    strRec = "txtJACD_T"
                Case "4"
                    strRec = "txtJASCD_F"
                Case "5"
                    strRec = "txtJASCD_T"
                Case "6"
                    strRec = "txtHANJICD_F"
                Case "7"
                    strRec = "txtHANJICD_T"
            End Select
            '2015/11/04 W.GANEKO 2015���P�J�� ��6 END
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�t�H�[�J�X��Ԃ��I�u�W�F�N�g�̖��O�l��n���v���p�e�B
    '*�@�T�@�v�F�J�����_�[���t�Ńt�H�[�J�X�Z�b�g����鍀�ږ���Ԃ��I�u�W�F�N�g���w��
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pBackFocs() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value.Length > 0 Then
                '2015/11/04 W.GANEKO 2015���P�J�� ��6 START
                'Select Case hdnPopcrtl.Value
                '    Case "0"
                'strRec = "btnKURACD"
                '    Case "1"
                'strRec = "btnKYOCD"
                '    Case "2"
                'strRec = "btnKen1"
                '    Case "3"
                'strRec = "btnKen2"
                'End Select
                Select Case hdnPopcrtl.Value
                    Case "0"
                        strRec = "btnKURACD"
                    Case "1"
                        strRec = "btnKYOCD"
                    Case "2"
                        strRec = "btnKen1_F"
                    Case "3"
                        strRec = "btnKen1_T"
                    Case "4"
                        strRec = "btnKen2_F"
                    Case "5"
                        strRec = "btnKen2_T"
                    Case "6"
                        strRec = "btnHANJICD_F"
                    Case "7"
                        strRec = "btnHANJICD_T"
                End Select
                '2015/11/04 W.GANEKO 2015���P�J�� ��6 END
            ElseIf hdnCalendar.Value = "1" Then
                strRec = "txtTRGDATE_From"
            ElseIf hdnCalendar.Value = "2" Then
                strRec = "txtTRGDATE_To"
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
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = ""
                Case "1"
                    strRec = ""
                Case "2"
                    strRec = "fncSetTo"
                Case "3"
                    strRec = ""
                Case "4"
                    strRec = "fncSetTo"
                Case "5"
                    strRec = ""
                Case "6"
                    strRec = "fncSetTo"
                Case "7"
                    strRec = ""
                Case Else
                    strRec = ""
            End Select
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�i�`���ύX���ꂽ���ɃN���A����I�u�W�F�N�g�̖��O�l��n���v���p�e�B�P
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pClearName() As String
        Get
            Dim strRec As String
            '2015/11/04 W.GANEKO 2015���P�J�� ��6 START
            'Select Case hdnPopcrtl.Value
            '    Case "0"
            'strRec = "txtKYOCD,txtJACD,txtJASCD"
            '    Case "1"
            'strRec = "txtJACD,txtJASCD"
            '    Case "2"
            'strRec = "txtJASCD"
            '    Case "3"
            'strRec = ""
            'End Select
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = "txtKYOCD,txtHANJICD_F,txtHANJICD_T,txtJACD_F,txtJACD_T,txtJASCD_F,txtJASCD_T"
                Case "1"
                    strRec = "txtHANJICD_F,txtHANJICD_T,txtJACD_F,txtJACD_T,txtJASCD_F,txtJASCD_T"
                Case "2", "3"
                    strRec = "txtJASCD_F,txtJASCD_T"
                Case "4", "5"
                    strRec = ""
                Case "6", "7"
                    strRec = "txtJACD_F,txtJACD_T,txtJASCD_F,txtJASCD_T"
            End Select
            '2015/11/04 W.GANEKO 2015���P�J�� ��6 END
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�i�`���ύX���ꂽ���ɃN���A����I�u�W�F�N�g�̖��O�l��n���v���p�e�B�P
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pClearCode() As String
        Get
            Dim strRec As String
            '2015/11/04 W.GANEKO 2015���P�J�� ��6 START
            'Select Case hdnPopcrtl.Value
            '    Case "0"
            'strRec = "hdnKYOCD,hdnJACD,hdnJASCD"
            '    Case "1"
            'strRec = "hdnJACD,hdnJASCD"
            '    Case "2"
            'strRec = "hdnJASCD"
            '    Case "3"
            'strRec = ""
            'End Select
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = "hdnKYOCD,hdnHANJICD_F,hdnHANJICD_T,hdnJACD_F,hdnJACD_T,hdnJASCD_F,hdnJASCD_T"
                Case "1"
                    strRec = "hdnHANJICD_F,hdnHANJICD_T,hdnJACD_F,hdnJACD_T,hdnJASCD_F,hdnJASCD_T"
                Case "2", "3"
                    strRec = "hdnJASCD_F,hdnJASCD_T"
                Case "4", "5"
                    strRec = ""
                Case "6", "7"
                    strRec = "hdnJACD_F,hdnJACD_T,hdnJASCD_F,hdnJASCD_T"
            End Select
            '2015/11/04 W.GANEKO 2015���P�J�� ��6 END
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�J�����_�[���t��Ԃ��̒l��Ԃ��I�u�W�F�N�g���w��
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pBackDate() As String
        Get
            Dim strRec As String
            If hdnCalendar.Value = "1" Then
                strRec = "txtTRGDATE_From"
            ElseIf hdnCalendar.Value = "2" Then
                strRec = "txtTRGDATE_To"
            End If
            Return strRec
        End Get
    End Property

End Class
