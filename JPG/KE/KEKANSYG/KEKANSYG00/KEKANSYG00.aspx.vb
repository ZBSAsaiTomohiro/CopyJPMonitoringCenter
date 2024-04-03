'***********************************************
' �Ď��Ή����W�v�\  ���
'***********************************************
' �ύX����
' 2008/11/21 T.Watabe �V�K�쐬
' 2010/03/09 T.Watabe �Ή��敪���d���𒠕[�Ɋ܂�or�܂܂Ȃ��̏�����ǉ�

Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common
Imports JPG.Common.log

Imports System.Text

Partial Class KEKANSYG00
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
    ' �����N���X                 2017/02/15 H.Mori add 2016���P�J�� No8-2
    '******************************************************************************
    Protected TimeFncC As New CTimeFnc

    '******************************************************************************
    ' �N�b�L�[
    '******************************************************************************
    Protected ConstC As New CConst

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
            '2015/02/09 H.Hosoda mod �Ď����P2014 ��14 Start
            'txtKURACD.Attributes.Add("ReadOnly", "true")
            'txtJACD.Attributes.Add("ReadOnly", "true")
            txtKURACD_From.Attributes.Add("ReadOnly", "true")
            txtKURACD_To.Attributes.Add("ReadOnly", "true")
            txtJACD_From.Attributes.Add("ReadOnly", "true")
            txtJACD_To.Attributes.Add("ReadOnly", "true")
            txtHANGRP_From.Attributes.Add("ReadOnly", "true")
            txtHANGRP_To.Attributes.Add("ReadOnly", "true")
            '2015/02/09 H.Hosoda mod �Ď����P2014 ��14 End
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
        '[�Ή����ʈꗗ]�g�p�\����(�^:��/�c:��/��:��/�o:�~)
        AuthC.fncAuthCheck(Server, AuthC.pGROUP_UNKOU & "," & AuthC.pGROUP_KANSHI & "," & AuthC.pGROUP_EIGYOU)

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
        If hdnKensaku.Value = "KEKANSCG00" Then
            Server.Transfer("./KEKANSCG00.aspx")
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
             MyBase.MapPath("../../../KE/KEKANSYG/KEKANSYG00/") & "KEKANSYG00.js"))
        '<�t�H�[�J�X�֘A�֐�>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncFo.js"))
        '<���t�֘A�֐�>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncDate.js"))
        '<���Ԋ֘A�֐�> 
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncTime.js")) '2017/02/15 H.Mori add ���P2016 No8-2
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
            '//�t�H�[�J�X���Z�b�g����
            '2015/02/09 H.Hosoda mod �Ď����P2014 ��14 Start
            'strMsg.Append("Form1.btnKURACD.focus();")
            strMsg.Append("Form1.btnKURACD_From.focus();")
            '2015/02/09 H.Hosoda mod �Ď����P2014 ��14 Start

            '�����l�ɑO�������ƑO���������Z�b�g
            Dim ndt As Date = Now
            strMsg.Append("Form1.txtTRGDATE_From.value='" & Left(DateSerial(ndt.Year, ndt.Month - 1, 1).ToString, 10) & "';")
            strMsg.Append("Form1.txtTRGDATE_To.value='" & Left(DateSerial(ndt.Year, ndt.Month, 1).AddDays(-1).ToString, 10) & "';")

        Else
            '//--------------------------------------
            '//�@�Q��ڈȍ~���s�����
            '//--------------------------------------------------------------------------
            '//����ʕ\������R���{�{�b�N�X�͊e�ŏI�C�x���g/���\�b�h��CALL���܂�
            '//--------------------------------------------------------------------------
        End If

        '//-------------------------------------------------
        '<TODO>�����̉��ID��HIDDEN��hdnMyAspx�ɏ������ށi�V�X�e�����ʁj
        hdnMyAspx.Value = "KEKANSYG00"
        '//-------------------------------------------------

    End Sub

    '******************************************************************************
    ' Excel�o��(�`�F�b�N��)
    '******************************************************************************
    Private Sub btnSelect_ServerClick(ByVal sender As System.Object, _
                                    ByVal e As System.EventArgs) Handles btnSelect.ServerClick
        Dim strRec As String
        'Dim bytExcel() As Byte '2014/01/16 T.Ono del ���P�Ή�2013 Excel�𒼐ڏo�͂ɕύX
        Dim KEKANSYG00C As New KEKANSYG00KEKANSYW00.KEKANSYW00

        Dim strSTKBN As String
        Dim strPGKBN As String
        '2015/02/04 H.Hosoda mod �Ď����P2014 ��14 Start
        'Dim strTAIOU_CHOFUKU As String '2010/03/09 T.Watabe add
        Dim strHASSEI_TEL As String
        Dim strHASSEI_KEI As String
        Dim strTAIOU_TEL As String
        Dim strTAIOU_SHU As String
        Dim strTAIOU_JUF As String
        Dim strTRGDATE_KBN As String
        '2015/02/04 H.Hosoda mod �Ď����P2014 ��14 End
        Dim strTSADCD As String    '2020/11/01 T.Ono add 2020�Ď����P

        '//�@�F�؃N���X�̃C���X�^���X����
        AuthC = New CAuthenticate(Request, Response)

        '�W�����
        If rdoPGKBN1.Checked = True Then
            strPGKBN = "1"      '�N���C�A���g�P��
        ElseIf rdoPGKBN2.Checked = True Then
            strPGKBN = "2"      'JA�P��
        '2015/02/04 H.Hosoda mod �Ď����P2014 ��14 Start
        'Else
        ElseIf rdoPGKBN3.Checked = True Then
            strPGKBN = "3"      'JA�x���P��
        ElseIf rdoPGKBN4.Checked = True Then
            strPGKBN = "4"      '�̔����ƎҒP��
            '2017/02/16 H.Mori add ���P2016 No8-1 START
            'Else
            '    strPGKBN = "5"      '�̔����ƎҎx���P��
            'End If
            '2015/02/04 H.Hosoda mod �Ď����P2014 ��14 End
        ElseIf rdoPGKBN6.Checked = True Then
            strPGKBN = "6"      '���P��
        Else
            strPGKBN = "7"      '�̔����P��
        End If
        '2017/02/16 H.Mori add ���P2016 No8-1 END

        '2015/02/04 H.Hosoda add �Ď����P2014 ��14 Start
        strHASSEI_TEL = ""
        strHASSEI_KEI = ""
        If chkHSI_TEL.Checked = True Then  '�����敪�F�d�b
            strHASSEI_TEL = "1"
        End If
        If chkHSI_KEI.Checked = True Then  '�����敪�F�x��
            strHASSEI_KEI = "2"
        End If
        '2015/02/04 H.Hosoda add �Ď����P2014 ��14 End

        '2015/02/04 H.Hosoda mod �Ď����P2014 ��14 Start
        '2010/03/09 T.Watabe add
        'If chkTAIOU_CHOFUKU.Checked = True Then
        '    strTAIOU_CHOFUKU = "1"      '1:�d������
        'Else
        '    strTAIOU_CHOFUKU = "0"      '0:�d���Ȃ�
        'End If
        strTAIOU_TEL = ""
        strTAIOU_SHU = ""
        strTAIOU_JUF = ""
        If chkTAI_TEL.Checked = True Then  '�Ή��敪�F�d�b
            strTAIOU_TEL = "1"
        End If
        If chkTAI_SHU.Checked = True Then  '�Ή��敪�F�o��
            strTAIOU_SHU = "2"
        End If
        If chkTAI_JUF.Checked = True Then  '�Ή��敪�F�d��
            strTAIOU_JUF = "3"
        End If
        '2015/02/04 H.Hosoda mod �Ď����P2014 ��14 End

        '2015/02/04 H.Hosoda add �Ď����P2014 ��14 Start
        If rdoKIKAN1.Checked = True Then
            strTRGDATE_KBN = "1"      '�Ή�������
        Else
            strTRGDATE_KBN = "2"      '��M��
        End If
        '2015/02/04 H.Hosoda add �Ď����P2014 ��14 End

        '2020/11/01 T.Ono add �Ď����P2020 Start
        '�쓮�����@1���H���E�����ȂǁF63 �܂�
        strTSADCD = ""
        If chkTSADCD.Checked = True Then
            strTSADCD = "1"
        Else
            strTSADCD = "0"
        End If
        '2020/11/01 T.Ono add �Ď����P2020 End

        Dim strRecMsg As String = ""
        'Dim intMaxDataCnt As Integer = ConstC.pPageMax '2008/12/18 T.Watabe edit
        Dim intMaxDataCnt As Integer = 10000

        '2012/04/04 NEC ou Upd Str
        'strRec = KEKANSYG00C.mExcel( _
        '                         Request.Cookies.Get("ASP.NET_SessionId").Value, _
        '                         hdnKURACD.Value, _
        '                         hdnJACD.Value, _
        '                         strPGKBN, _
        '                         strTAIOU_CHOFUKU, _
        '                         DateFncC.mHenkanGet(txtTRGDATE_From.Text), _
        '                         DateFncC.mHenkanGet(txtTRGDATE_To.Text), _
        '                         txtKURACD.Text, _
        '                         txtJACD.Text, _
        '                         intMaxDataCnt, _
        '                         AuthC.pCENTERCD _
        '                         )
        '2015/02/04 H.Hosoda mod �Ď����P2014 ��14 Start        
        'strRec = KEKANSYG00C.mExcel( _
        '                 Me.Session.SessionID, _
        '                 hdnKURACD.Value.Trim(), _
        '                 hdnJACD.Value.Trim(), _
        '                 strPGKBN, _
        '                 strTAIOU_CHOFUKU, _
        '                 DateFncC.mHenkanGet(txtTRGDATE_From.Text), _
        '                 DateFncC.mHenkanGet(txtTRGDATE_To.Text), _
        '                 txtKURACD.Text, _
        '                 txtJACD.Text, _
        '                 intMaxDataCnt, _
        '                 AuthC.pCENTERCD _
        '                 )
        '2012/04/04 NEC ou Upd End
        '2017/02/15 H.Mori mod ���P2016 No8-2 START
        'strRec = KEKANSYG00C.mExcel( _
        '                 Me.Session.SessionID, _
        '                 hdnKURACD_From.Value.Trim(), _
        '                 hdnKURACD_To.Value.Trim(), _
        '                 hdnJACD_From.Value.Trim(), _
        '                 hdnJACD_To.Value.Trim(), _
        '                 hdnHANGRP_From.Value.Trim(), _
        '                 hdnHANGRP_To.Value.Trim(), _
        '                 strPGKBN, _
        '                 strHASSEI_TEL, _
        '                 strHASSEI_KEI, _
        '                 strTAIOU_TEL, _
        '                 strTAIOU_SHU, _
        '                 strTAIOU_JUF, _
        '                 DateFncC.mHenkanGet(txtTRGDATE_From.Text), _
        '                 DateFncC.mHenkanGet(txtTRGDATE_To.Text), _
        '                 strTRGDATE_KBN, _
        '                 intMaxDataCnt, _
        '                 AuthC.pCENTERCD _
        '                 )
        '2015/02/04 H.Hosoda mod �Ď����P2014 ��14 End
        '2020/11/01 T.Ono mod �Ď����P2020 Start
        'strTSADCD_CHK�@�ǉ�
        strRec = KEKANSYG00C.mExcel(
                         Me.Session.SessionID,
                         hdnKURACD_From.Value.Trim(),
                         hdnKURACD_To.Value.Trim(),
                         hdnJACD_From.Value.Trim(),
                         hdnJACD_To.Value.Trim(),
                         hdnHANGRP_From.Value.Trim(),
                         hdnHANGRP_To.Value.Trim(),
                         strPGKBN,
                         strHASSEI_TEL,
                         strHASSEI_KEI,
                         strTAIOU_TEL,
                         strTAIOU_SHU,
                         strTAIOU_JUF,
                         DateFncC.mHenkanGet(txtTRGDATE_From.Text),
                         DateFncC.mHenkanGet(txtTRGDATE_To.Text),
                         strTRGDATE_KBN,
                         intMaxDataCnt,
                         AuthC.pCENTERCD,
                         TimeFncC.mHenkanGet(txtTRGTIME_From.Text),
                         TimeFncC.mHenkanGet(txtTRGTIME_To.Text),
                         strTSADCD
                         )
        '2017/02/15 H.Mori mod ���P2016 No8-2 END
        '2020/11/01 T.Ono mod �Ď����P2020 End

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

        ElseIf strRec.Substring(0, 7) = "DATAMAX" Then
            '�f�[�^���ő�s���𒴂����̏ꍇ
            strRecMsg = "�f�[�^���ő�s���𒴂��܂����B[�ő�" & intMaxDataCnt & "�s]"
            strMsg.Append("alert('" & strRecMsg & "');")
            strMsg.Append("Form1.btnSelect.focus();")

        Else
            '�u�J���A�ۑ��v�̃_�C�����O���o��悤��HTTP�w�b�_�ɒǉ�
            '�t�@�C�����́AHttpUtility.UrlEncode���\�b�h���g�p����SJIS�ɃG���R�[�h����K�v������
            '.xls�`���ɕύX 2013/12/06 T.Ono mod �Ď����P2013
            'HttpHeaderC.mDownLoad(Response, "�Ď��Ή����W�v�\.exe")
            HttpHeaderC.mDownLoadXLS(Response, "�Ď��Ή����W�v�\.xls")

            '2014/01/16 T.Ono mod �Ď����P2013 excel�𒼐ڊJ�� Start
            ''Web�T�[�r�X�̖߂�l�iBASE64�̃e�L�X�g�j���o�C�g�f�[�^�ɕϊ�����
            'bytExcel = Convert.FromBase64String(strRec)
            ''�t�@�C�����M
            'Response.BinaryWrite(bytExcel)
            Response.WriteFile(strRec)
            '2014/01/16 T.Ono mod �Ď����P2013 excel�𒼐ڊJ�� End
            strRecMsg = "OK"
        End If

        strRec = strRecMsg
        '-------------------------------------------------
        '//�`�o���O��������
        Dim LogC As New CLog
        Dim strRecLog As String
        '2012/04/04 NEC ou Upd Str
        'strRecLog = LogC.mAPLog(Request.Cookies.Get("ASP.NET_SessionId").Value, AuthC.pUSERNAME, AuthC.pIPADDRESS, hdnMyAspx.Value, "4", strRec, Request.Form)
        strRecLog = LogC.mAPLog(Me.Session.SessionID, AuthC.pUSERNAME, AuthC.pIPADDRESS, hdnMyAspx.Value, "4", strRec, Request.Form)
        '2012/04/04 NEC ou Upd End
        If strRecLog <> "OK" Then
            Dim errmsgc As New CErrMsg
            strMsg.Append("alert('�V�X�e���G���[�F" & errmsgc.mGetArtMsg(strRecLog) & "');")
        End If
    End Sub

    '******************************************************************************
    '* �����`�F�b�N�p��ʂɓn���p�����[�^�ݒ�
    '******************************************************************************
    '2015/02/09 H.Hosoda mod �Ď����P2014 ��14 Start
    'Public ReadOnly Property pKuracd() As String
    '    Get
    '        Return hdnKURACD.Value.Trim     '2012/04/04 NEC ou Add Upd
    '    End Get
    'End Property
    'Public ReadOnly Property pJacd() As String
    '    Get
    '        Return hdnJACD.Value.Trim       '2012/04/04 NEC ou Add Upd
    '    End Get
    'End Property
    Public ReadOnly Property pKuracdFrom() As String
        Get
            Return hdnKURACD_From.Value.Trim     '2012/04/04 NEC ou Add Upd
        End Get
    End Property
    Public ReadOnly Property pKuracdTo() As String
        Get
            Return hdnKURACD_To.Value.Trim       '2012/04/04 NEC ou Add Upd
        End Get
    End Property
    Public ReadOnly Property pJacdFrom() As String
        Get
            Return hdnJACD_From.Value.Trim     '2012/04/04 NEC ou Add Upd
        End Get
    End Property
    Public ReadOnly Property pJacdTo() As String
        Get
            Return hdnJACD_To.Value.Trim       '2012/04/04 NEC ou Add Upd
        End Get
    End Property
    Public ReadOnly Property pHangrpFrom() As String
        Get
            Return hdnHANGRP_From.Value.Trim     '2012/04/04 NEC ou Add Upd
        End Get
    End Property
    Public ReadOnly Property pHangrpTo() As String
        Get
            Return hdnHANGRP_To.Value.Trim       '2012/04/04 NEC ou Add Upd
        End Get
    End Property
    Public ReadOnly Property pPgkbn() As String
        Get
            '�W�����
            If rdoPGKBN1.Checked = True Then
                Return "1"      '�N���C�A���g�P��
            ElseIf rdoPGKBN2.Checked = True Then
                Return "2"      'JA�P��
            ElseIf rdoPGKBN3.Checked = True Then
                Return "3"      'JA�x���P��
            ElseIf rdoPGKBN4.Checked = True Then
                Return "4"      '�̔����ƎҒP��
                '2017/02/16 H.Mori mod ���P2016 No8-1 START
                'Else
                '    Return "5"      '�̔����ƎҎx���P��
                '2017/02/16 H.Mori mod ���P2016 No8-1 END
            ElseIf rdoPGKBN6.Checked = True Then
                Return "6"      '���P��
            Else
                Return "7"      '�̔����P��
            End If
        End Get
    End Property
    Public ReadOnly Property pHasseiTel() As String
        Get
            If chkHSI_TEL.Checked = True Then  '�����敪�F�d�b
                Return "1"
            Else
                Return ""
            End If
        End Get
    End Property
    Public ReadOnly Property pHasseiKei() As String
        Get
            If chkHSI_KEI.Checked = True Then  '�����敪�F�x��
                Return "2"
            Else
                Return ""
            End If
        End Get
    End Property
    Public ReadOnly Property pTaiouTel() As String
        Get
            If chkTAI_TEL.Checked = True Then  '�Ή��敪�F�d�b
                Return "1"
            Else
                Return ""
            End If
        End Get
    End Property
    Public ReadOnly Property pTaiouShu() As String
        Get
            If chkTAI_SHU.Checked = True Then  '�Ή��敪�F�o��
                Return "2"
            Else
                Return ""
            End If
        End Get
    End Property
    Public ReadOnly Property pTaiouJuf() As String
        Get
            If chkTAI_JUF.Checked = True Then  '�Ή��敪�F�d��
                Return "3"
            Else
                Return ""
            End If
        End Get
    End Property
    Public ReadOnly Property pTrgdatekbn() As String
        Get
            If rdoKIKAN1.Checked = True Then
                Return "1"      '�Ή�������
            Else
                Return "2"      '��M��
            End If
        End Get
    End Property
    '2015/02/09 H.Hosoda mod �Ď����P2014 ��14 End
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
    '2017/02/16 H.Mori add ���P2016 No8-2 START
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
    '2020/11/01 T.Ono add 2020�Ď����P
    '�쓮����
    Public ReadOnly Property pTsadcd() As String
        Get
            If chkTSADCD.Checked = True Then
                Return "1"
            Else
                Return ""
            End If
        End Get
    End Property
    '2017/02/16 H.Mori add ���P2016 No8-2 END
    '******************************************************************************
    '*�@�T�@�v�F�i���ݏ�����n���v���p�e�B
    '*�@���@�l�F(���R�[�h)
    '******************************************************************************
    Public ReadOnly Property pCode1() As String
        Get
            Dim strRec As String
            Select Case hdnPopcrtl.Value
                Case "0"
                    ''�^�s�J�����̏ꍇ�͑S�Ă̊Ď��Z���^�[��I���\
                    ''�ȊO�̏ꍇ�͑�s���g�p�����Ɏ����̊Ď��Z���^�[�̂ݎg�p�\
                    strRec = AuthC.pAUTHCENTERCD
                Case "1"
                    '2015/02/09 H.Hosoda add �Ď����P2014 ��14
                    ''�^�s�J�����̏ꍇ�͑S�Ă̊Ď��Z���^�[��I���\
                    ''�ȊO�̏ꍇ�͑�s���g�p�����Ɏ����̊Ď��Z���^�[�̂ݎg�p�\
                    strRec = AuthC.pAUTHCENTERCD
                Case "2"
                    '2015/02/09 H.Hosoda mod �Ď����P2014 ��14 Start
                    'strRec = hdnKURACD.Value
                    strRec = hdnKURACD_From.Value
                    '2015/02/09 H.Hosoda mod �Ď����P2014 ��14 End
                Case "3"
                    'strRec = hdnKURACD_From.Value '2015/02/09 H.Hosoda add �Ď����P2014 ��14
                    strRec = hdnKURACD_To.Value    '2019/11/01 w.ganeko 2019�Ď����P ��4
                Case "4" '2015/02/09 H.Hosoda add �Ď����P2014 ��14
                    strRec = hdnKURACD_From.Value
                Case "5" '2015/02/09 H.Hosoda add �Ď����P2014 ��14
                    'strRec = hdnKURACD_From.Value '2019/11/01 w.ganeko 2019�Ď����P ��4
                    strRec = hdnKURACD_To.Value    '2019/11/01 w.ganeko 2019�Ď����P ��4
            End Select
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
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = ""
                Case "1"
                    strRec = ""
                Case "2"
                    strRec = ""
                    '2015/02/09 H.Hosoda mod �Ď����P2014 ��14 Start
                    'Case "3"
                Case Else
                    strRec = ""
                    '2015/02/09 H.Hosoda mod �Ď����P2014 ��14 End
            End Select
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
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = "�N���C�A���g�ꗗ"
                Case "1"
                    strRec = "�N���C�A���g�ꗗ" '2015/02/09 H.Hosoda add �Ď����P2014 ��14
                Case "2"
                    strRec = "�i�`�ꗗ"
                Case "3"
                    strRec = "�i�`�ꗗ"  '2015/02/09 H.Hosoda add �Ď����P2014 ��14
                Case "4" '2015/02/09 H.Hosoda add �Ď����P2014 ��14
                    strRec = "�̔����Ǝ҃O���[�v�ꗗ"
                Case "5" '2015/02/09 H.Hosoda add �Ď����P2014 ��14
                    strRec = "�̔����Ǝ҃O���[�v�ꗗ"
                Case Else '2015/02/09 H.Hosoda add �Ď����P2014 ��14
                    strRec = ""
            End Select
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
            Select Case hdnPopcrtl.Value
                Case "0"
                    strRec = "CLI"
                Case "1"
                    strRec = "CLI"  '2015/02/09 H.Hosoda add �Ď����P2014 ��14
                Case "2"
                    strRec = "JA"
                Case "3"
                    strRec = "JA"   '2015/02/09 H.Hosoda add �Ď����P2014 ��14
                Case "4" '2015/02/09 H.Hosoda add �Ď����P2014 ��14
                    strRec = "HANG"
                Case "5" '2015/02/09 H.Hosoda add �Ď����P2014 ��14
                    strRec = "HANG"
                Case Else '2015/02/09 H.Hosoda add �Ď����P2014 ��14
                    strRec = ""
            End Select
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
            Select Case hdnPopcrtl.Value
                Case "0"
                    '2015/02/09 H.Hosoda mod �Ď����P2014 ��14 Start
                    'strRec = "hdnKURACD"
                    strRec = "hdnKURACD_From"
                    '2015/02/09 H.Hosoda mod �Ď����P2014 ��14 End
                Case "1"
                    strRec = "hdnKURACD_To"  '2015/02/09 H.Hosoda add �Ď����P2014 ��14
                Case "2"
                    '2015/02/09 H.Hosoda mod �Ď����P2014 ��14 Start
                    'strRec = "hdnJACD"
                    strRec = "hdnJACD_From"
                    '2015/02/09 H.Hosoda mod �Ď����P2014 ��14 End
                Case "3"
                    strRec = "hdnJACD_To"  '2015/02/09 H.Hosoda add �Ď����P2014 ��14
                Case "4"  '2015/02/09 H.Hosoda add �Ď����P2014 ��14
                    strRec = "hdnHANGRP_From"
                Case "5"  '2015/02/09 H.Hosoda add �Ď����P2014 ��14
                    strRec = "hdnHANGRP_To"
                Case Else  '2015/02/09 H.Hosoda add �Ď����P2014 ��14
                    strRec = ""
            End Select
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
            Select Case hdnPopcrtl.Value
                Case "0"
                    '2015/02/09 H.Hosoda mod �Ď����P2014 ��14 Start
                    'strRec = "txtKURACD"
                    strRec = "txtKURACD_From"
                    '2015/02/09 H.Hosoda mod �Ď����P2014 ��14 End
                Case "1"
                    strRec = "txtKURACD_To" '2015/02/09 H.Hosoda add �Ď����P2014 ��14
                Case "2"
                    '2015/02/09 H.Hosoda mod �Ď����P2014 ��14 Start
                    'strRec = "txtJACD"
                    strRec = "txtJACD_From"
                Case "3"
                    strRec = "txtJACD_To"  '2015/02/09 H.Hosoda add �Ď����P2014 ��14
                Case "4"  '2015/02/09 H.Hosoda add �Ď����P2014 ��14
                    strRec = "txtHANGRP_From"
                Case "5"  '2015/02/09 H.Hosoda add �Ď����P2014 ��14
                    strRec = "txtHANGRP_To"
                Case Else  '2015/02/09 H.Hosoda add �Ď����P2014 ��14
                    strRec = ""
            End Select
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
                Select Case hdnPopcrtl.Value
                    Case "0"
                        '2015/02/09 H.Hosoda mod �Ď����P2014 ��14 Start
                        'strRec = "btnKURACD"
                        strRec = "btnKURACD_From"
                        '2015/02/09 H.Hosoda mod �Ď����P2014 ��14 End
                    Case "1"
                        strRec = "btnKURACD_To"  '2015/02/09 H.Hosoda add �Ď����P2014 ��14
                    Case "2"
                        '2015/02/09 H.Hosoda mod �Ď����P2014 ��14 Start
                        'strRec = "btnKen1"
                        strRec = "btnJACD_From"
                        '2015/02/09 H.Hosoda mod �Ď����P2014 ��14 End
                    Case "3"
                        strRec = "btnJACD_To"  '2015/02/09 H.Hosoda add �Ď����P2014 ��14
                    Case "4"  '2015/02/09 H.Hosoda add �Ď����P2014 ��14
                        strRec = "btnHANGRP_From"
                    Case "5"  '2015/02/09 H.Hosoda add �Ď����P2014 ��14
                        strRec = "btnHANGRP_To"
                    Case Else  '2015/02/09 H.Hosoda add �Ď����P2014 ��14
                        strRec = ""
                End Select
            ElseIf hdnCalendar.Value = "1" Then
                strRec = "txtTRGDATE_From"
            ElseIf hdnCalendar.Value = "2" Then
                strRec = "txtTRGDATE_To"
            Else '2015/02/09 H.Hosoda add �Ď����P2014 ��14
                strRec = ""
            End If
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
            Select Case hdnPopcrtl.Value
                Case "0"
                    '2015/02/09 H.Hosoda mod �Ď����P2014 ��14 Start
                    'strRec = "txtJACD"
                    strRec = "txtJACD_From,txtJACD_To,txtHANGRP_From,txtHANGRP_To"
                    '2015/02/09 H.Hosoda mod �Ď����P2014 ��14 End
                Case "1"
                    strRec = ""
                Case "2"
                    strRec = ""
                Case "3"
                    strRec = ""
                Case Else  '2015/02/09 H.Hosoda add �Ď����P2014 ��14
                    strRec = ""
            End Select
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
            Select Case hdnPopcrtl.Value
                Case "0"
                    '2015/02/09 H.Hosoda mod �Ď����P2014 ��14 Start
                    'strRec = "hdnJACD"
                    strRec = "hdnJACD_From,hdnJACD_To,hdnHANGRP_From,hdnHANGRP_To"
                    '2015/02/09 H.Hosoda mod �Ď����P2014 ��14 End
                Case "1"
                    strRec = ""
                Case "2"
                    strRec = ""
                    'Case "3"
                    '    strRec = ""
                Case Else '2015/02/09 H.Hosoda add �Ď����P2014 ��14
                    strRec = ""
            End Select
            Return strRec
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F���^�[����Ɏ��s�����i�r '2015/02/10 H.Hosoda add �Ď����P2014 ��14
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pBackScript() As String
        Get
            Dim strRec As String
            strRec = "fncPGKBNDisp"
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
