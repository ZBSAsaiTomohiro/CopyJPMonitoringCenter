'***********************************************
'��M�x��\���p�l��  ���C�����(�o�^�n�t���[�����[�N)
'***********************************************
Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common
Imports System.Text
Imports JPG.Common.log
Imports System.IO
Imports System.Diagnostics

Partial Class KEJUKJAG00
    Inherits System.Web.UI.Page

    Private strExecFlg As String            '�{�^���̃C�x���g�𐧌䂷��

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
        '2012/04/03 NEC ou Add Str
        '.NET�̎d�l�ύX�ɂ��AReadOnly������ASPX�ł���ƁA�T�[�o���Œl�̎Q�Ƃ��ł��Ȃ��Ȃ邽�߁AVB����Attribute�ł���
        If MyBase.IsPostBack = False Then

            txtCOUNT.Attributes.Add("ReadOnly", "true")
            txtTAICNT.Attributes.Add("ReadOnly", "true")
            txtTOTALCNT.Attributes.Add("ReadOnly", "true") '2016/11/16 H.Mori add 2016���P�J�� No1-2
            txt1KMYMD.Attributes.Add("ReadOnly", "true")
            txt1KMTIME.Attributes.Add("ReadOnly", "true")
            txt1KURACD.Attributes.Add("ReadOnly", "true")
            txt1KENNM.Attributes.Add("ReadOnly", "true")
            txt1KMCNT.Attributes.Add("ReadOnly", "true")
            txt1RYURYO.Attributes.Add("ReadOnly", "true")
            txt1ROC.Attributes.Add("ReadOnly", "true")
            txt1KMMESSAGE1.Attributes.Add("ReadOnly", "true")
            txt1KMMESSAGE2.Attributes.Add("ReadOnly", "true")
            txt1KMMESSAGE3.Attributes.Add("ReadOnly", "true")
            txt1JUYONM.Attributes.Add("ReadOnly", "true")
            txt1JANM.Attributes.Add("ReadOnly", "true")
            txt1JUTEL.Attributes.Add("ReadOnly", "true")
            txt1ADDR.Attributes.Add("ReadOnly", "true")
            txt1META.Attributes.Add("ReadOnly", "true")
            txt1ROCUSER.Attributes.Add("ReadOnly", "true") '2017/10/11 H.Mori add 2017���P�J�� No1

            txt2KMYMD.Attributes.Add("ReadOnly", "true")
            txt2KMTIME.Attributes.Add("ReadOnly", "true")
            txt2KURACD.Attributes.Add("ReadOnly", "true")
            txt2KENNM.Attributes.Add("ReadOnly", "true")
            txt2KMCNT.Attributes.Add("ReadOnly", "true")
            txt2RYURYO.Attributes.Add("ReadOnly", "true")
            txt2ROC.Attributes.Add("ReadOnly", "true")
            txt2KMMESSAGE1.Attributes.Add("ReadOnly", "true")
            txt2KMMESSAGE2.Attributes.Add("ReadOnly", "true")
            txt2KMMESSAGE3.Attributes.Add("ReadOnly", "true")
            txt2JUYONM.Attributes.Add("ReadOnly", "true")
            txt2JANM.Attributes.Add("ReadOnly", "true")
            txt2JUTEL.Attributes.Add("ReadOnly", "true")
            txt2ADDR.Attributes.Add("ReadOnly", "true")
            txt2META.Attributes.Add("ReadOnly", "true")
            txt2ROCUSER.Attributes.Add("ReadOnly", "true") '2017/10/11 H.Mori add 2017���P�J�� No1

            txt3KMYMD.Attributes.Add("ReadOnly", "true")
            txt3KMTIME.Attributes.Add("ReadOnly", "true")
            txt3KURACD.Attributes.Add("ReadOnly", "true")
            txt3KENNM.Attributes.Add("ReadOnly", "true")
            txt3KMCNT.Attributes.Add("ReadOnly", "true")
            txt3RYURYO.Attributes.Add("ReadOnly", "true")
            txt3ROC.Attributes.Add("ReadOnly", "true")
            txt3KMMESSAGE1.Attributes.Add("ReadOnly", "true")
            txt3KMMESSAGE2.Attributes.Add("ReadOnly", "true")
            txt3KMMESSAGE3.Attributes.Add("ReadOnly", "true")
            txt3JUYONM.Attributes.Add("ReadOnly", "true")
            txt3JANM.Attributes.Add("ReadOnly", "true")
            txt3JUTEL.Attributes.Add("ReadOnly", "true")
            txt3ADDR.Attributes.Add("ReadOnly", "true")
            txt3META.Attributes.Add("ReadOnly", "true")
            txt3ROCUSER.Attributes.Add("ReadOnly", "true") '2017/10/11 H.Mori add 2017���P�J�� No1
            '2019/11/01 W.GANEKO ADD 2019���P�J�� No3,4 start
            txt4KMYMD.Attributes.Add("ReadOnly", "true")
            txt4KMTIME.Attributes.Add("ReadOnly", "true")
            txt4KURACD.Attributes.Add("ReadOnly", "true")
            txt4KENNM.Attributes.Add("ReadOnly", "true")
            txt4KMCNT.Attributes.Add("ReadOnly", "true")
            txt4RYURYO.Attributes.Add("ReadOnly", "true")
            txt4ROC.Attributes.Add("ReadOnly", "true")
            txt4KMMESSAGE1.Attributes.Add("ReadOnly", "true")
            txt4KMMESSAGE2.Attributes.Add("ReadOnly", "true")
            txt4KMMESSAGE3.Attributes.Add("ReadOnly", "true")
            txt4JUYONM.Attributes.Add("ReadOnly", "true")
            txt4JANM.Attributes.Add("ReadOnly", "true")
            txt4JUTEL.Attributes.Add("ReadOnly", "true")
            txt4ADDR.Attributes.Add("ReadOnly", "true")
            txt4META.Attributes.Add("ReadOnly", "true")
            txt4ROCUSER.Attributes.Add("ReadOnly", "true")

            txt5KMYMD.Attributes.Add("ReadOnly", "true")
            txt5KMTIME.Attributes.Add("ReadOnly", "true")
            txt5KURACD.Attributes.Add("ReadOnly", "true")
            txt5KENNM.Attributes.Add("ReadOnly", "true")
            txt5KMCNT.Attributes.Add("ReadOnly", "true")
            txt5RYURYO.Attributes.Add("ReadOnly", "true")
            txt5ROC.Attributes.Add("ReadOnly", "true")
            txt5KMMESSAGE1.Attributes.Add("ReadOnly", "true")
            txt5KMMESSAGE2.Attributes.Add("ReadOnly", "true")
            txt5KMMESSAGE3.Attributes.Add("ReadOnly", "true")
            txt5JUYONM.Attributes.Add("ReadOnly", "true")
            txt5JANM.Attributes.Add("ReadOnly", "true")
            txt5JUTEL.Attributes.Add("ReadOnly", "true")
            txt5ADDR.Attributes.Add("ReadOnly", "true")
            txt5META.Attributes.Add("ReadOnly", "true")
            txt5ROCUSER.Attributes.Add("ReadOnly", "true")

            txt6KMYMD.Attributes.Add("ReadOnly", "true")
            txt6KMTIME.Attributes.Add("ReadOnly", "true")
            txt6KURACD.Attributes.Add("ReadOnly", "true")
            txt6KENNM.Attributes.Add("ReadOnly", "true")
            txt6KMCNT.Attributes.Add("ReadOnly", "true")
            txt6RYURYO.Attributes.Add("ReadOnly", "true")
            txt6ROC.Attributes.Add("ReadOnly", "true")
            txt6KMMESSAGE1.Attributes.Add("ReadOnly", "true")
            txt6KMMESSAGE2.Attributes.Add("ReadOnly", "true")
            txt6KMMESSAGE3.Attributes.Add("ReadOnly", "true")
            txt6JUYONM.Attributes.Add("ReadOnly", "true")
            txt6JANM.Attributes.Add("ReadOnly", "true")
            txt6JUTEL.Attributes.Add("ReadOnly", "true")
            txt6ADDR.Attributes.Add("ReadOnly", "true")
            txt6META.Attributes.Add("ReadOnly", "true")
            txt6ROCUSER.Attributes.Add("ReadOnly", "true")
            '2019/11/01 W.GANEKO ADD 2019���P�J�� No3,4 end
        End If
        '2012/04/03 NEC ou Add End

        '//------------------------------------------
        '//�@HTTP�w�b�_�𑗐M
        HttpHeaderC.mNoCache(Response)

        '//------------------------------------------
        '//�@�F�؃N���X�̃C���X�^���X����
        AuthC = New CAuthenticate(Request, Response)
        mlog("[KEJUKJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load start")

        '//------------------------------------------
        '//�@�F�؏���
        '<TODO>�F�g�p�\�������w�肷��
        '[��M�x��\���p�l��]�g�p�\����(�^:��/�c:�~/��:��/�o:�~)
        AuthC.fncAuthCheck(Server, AuthC.pGROUP_UNKOU & "," & AuthC.pGROUP_KANSHI)

        '//------------------------------------------
        '<TODO>�Ή����͉�ʂ֑J��
        '      [hdnKensaku(Hidden)]���쐬���鎖
        '//------------------------------------------
        '�����ꗗ�|�b�v�A�b�v�o��
        If hdnKensaku.Value = "KEKESJAG00" Then
            mlog("[KEJUKJAG00" & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load KEKESJAG00")

            Server.Transfer("../../KEKESJAG/KEKESJAG00/KEKESJAG00.aspx")
        End If
        '2015/11/02 w.ganeko 2015���P�J�� No9 start
        '�S���҈ꗗ�|�b�v�A�b�v�o��
        If hdnKensaku.Value = "MSTASJAG00" Then
            mlog("[KEJUKJAG00" & New StackFrame(True).GetFileLineNumber.ToString & "]-Page_Load MSTASJAG00")
            Server.Transfer("../../../MS/MSTASJAG/MSTASJAG00/MSTASJAG00.aspx")
        End If
        '2015/11/02 w.ganeko 2015���P�J�� No9 end
        '//------------------------------------------
        '�A���[�g�o��
        If hdnKensaku.Value = "KEJUKJOG00" Then
            mlog("[KEJUKJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load KEJUKJOG00")
            Server.Transfer("KEJUKJOG00.aspx")
        End If
        '//------------------------------------------
        '�f�[�^�`�F�b�N���s���A�V�����x�񂪔������ꂽ��o�͂���
        If hdnKensaku.Value = "KEJUKJKG00" Then
            mlog("[KEJUKJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load KEJUKJKG00")
            strExecFlg = "DATACHECK"
            Server.Transfer("KEJUKJKG00.aspx")
        End If
        '//------------------------------------------
        '���b�N�������������s
        If hdnKensaku.Value = "KEJUKJRG00" Then
            mlog("[KEJUKJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load KEJUKJRG00")
            strExecFlg = "DATANOROC"
            Server.Transfer("KEJUKJKG00.aspx")
        End If
        '//------------------------------------------
        '�Ή����͏��������s�i���b�N�����j
        If hdnKensaku.Value = "KEJUKJNG00" Then
            mlog("[KEJUKJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load KEJUKJNG00")
            strExecFlg = "DATAROC"
            Server.Transfer("KEJUKJKG00.aspx")
        End If
        '//------------------------------------------
        '�Ή����͉�ʂ֑J�ڂ��܂�
        If hdnKensaku.Value = "KETAIJAG00" Then
             mlog("[KEJUKJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load KETAIJAG00")
            Server.Transfer("../../KETAIJAG/KETAIJAG00/KETAIJAG00.aspx")
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
                MyBase.MapPath("../../../KE/KEJUKJAG/KEJUKJAG00/") & "KEJUKJAG00.js"))
        '<�t�H�[�J�X�֘A�֐�>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncFo.js"))
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

            '�����l�Ƃ��Čx��̏�Ԃ��Z�b�g����
            hdnRownum.Value = "1"
            hdnDataCount.Value = "0"
            hdnBtmOukaFlg.Value = "0"  '2014/01/20 T.Ono
            '��ʑJ�ڂɂ�鐧��
            Select Case Request.Form("hdnMyAspx")
                Case "KETAIJAG00"
                    '//------------------------------
                    '//�Ή����͉�ʂ���̑J��
                    hdnCtlFlg.Value = "KEJUTAI"
                Case Else
                    '//------------------------------
                    '//���s�p�^�[���ʐ���
                    If Request.QueryString("CLFLG") = "KANSHI" Then
                        hdnCtlFlg.Value = "KEJUKEI"
                    Else
                        hdnCtlFlg.Value = "KEJUTAI"
                    End If
            End Select

            '//--------------------------------------
            '�ŐV�\���{�^���C�x���g�����s����
            strMsg.Append("btnRenew_onclick();")

            '//--------------------------------------
            '<TODO>�����\���Ƃ��ĕK�v�ȃR���g���[���̐ݒ���s���܂�
            '�Ή����͉�ʂ���̑J�� 2013/12/13 T.Ono add �Ď����P2013
            If hdnCtlFlg.Value = "KEJUTAI" Then
                '������
                If Request.Form("hdnKEY_SERIAL") <> "" Then
                    hdnKEY_SERIAL.Value = Request.Form("hdnKEY_SERIAL")
                End If

                '�����X�V
                If Request.Form("hdnJido") = "1" Then
                    hdnJido.Value = "1"
                    chkJido.Checked = True
                Else
                    hdnJido.Value = "0"
                    chkJido.Checked = False
                End If
                '�������̂�
                If Request.Form("hdnMishori") = "1" Then
                    hdnMishori.Value = "1"
                    chkMishori.Checked = True
                Else
                    hdnMishori.Value = "0"
                    chkMishori.Checked = False
                End If
            End If
            '�Ď����̉�ʂ̐��䏈��
            If hdnCtlFlg.Value = "KEJUKEI" Then
                strMsg.Append("fncDispKansi();")
            End If

            '//--------------------------------------------------------------------------
            '�@�������ʂɂ���ʂ̏�Ԃ̐ݒ�------------------------
            '�@��ʂ��y�����O��ԁz�ɂ���i���̓f�[�^�͂��̂܂ܑJ�ڂ�����j
        Else
            '//--------------------------------------
            '//�@�Q��ڈȍ~���s�����
            '//--------------------------------------------------------------------------
            '//����ʕ\������R���{�{�b�N�X�͊e�ŏI�C�x���g/���\�b�h��CALL���܂�
            '//--------------------------------------------------------------------------
        End If

        '//-------------------------------------------------
        '<TODO>�����̉��ID��HIDDEN��hdnMyAspx�ɏ������ށi�V�X�e�����ʁj
        hdnMyAspx.Value = "KEJUKJAG00"
        '//-------------------------------------------------

        '//-------------------------------------------------
        '//�Ď��p�̏ꍇ�A�f�[�^��M�t���[���̈�莞�Ԃ̃`�F�b�N���Ď�����
        '//��莞�ԍX�V��ʂł�[hdnDummy]���o�͂��鎖
        If hdnCtlFlg.Value = "KEJUKEI" Then
            Dim strJUSINCHECK As String = CStr((CInt(ConfigurationSettings.AppSettings("JINTER")) * 1000) * 3)
            'Dim strJUSINCHECK As String = CStr((CInt(ConfigurationSettings.AppSettings("JINTER")) * 1000) * 10)�@'������ T.Ono�u* 1000) * 3)�v�����@�e�X�g�p�K���߂�
            '[�Ď�]N�s��ɍēx���sJS���o�͂���
            '//2012/10/10 W.GANEKO CHG
            strMsg.Append("myTimer = setInterval('fncCheck_retry()'," & strJUSINCHECK & ");")
            strMsg.Append("function fncCheck_retry(){")
            strMsg.Append("var s='try{ parent.Recv.document.location.href }catch(kl_err){ 0 }';")
            strMsg.Append("if(!eval(s)) {")
            '�@�@�@�l�b�g���[�N���̗��R�ɂ��t���[�����ɂg�s�l�k�W�J����Ȃ��������B
            '�@�@�@�ʏ�̕��@�Ń`�F�b�N���s���ƃZ�L�����e�B�̖���A�N�Z�X�����ۂ�����
            strMsg.Append("	 fncDataCheck();")
            strMsg.Append("	 fncMessage();")
            strMsg.Append("} else {")
            '      �y�[�W�͑��݂����̂Ń_�~�[��HIDDEN���ڂ̑��݃`�F�b�N���s��
            strMsg.Append("  obj=parent.Recv.document.getElementById('hdnDummy');")
            strMsg.Append("  if (obj == null){")
            strMsg.Append("	   fncDataCheck();")
            strMsg.Append("	   fncMessage();")
            strMsg.Append("  }")
            strMsg.Append("}")
            strMsg.Append("}")
            'strMsg.Append("var fncckrty = function() {")
            'strMsg.Append("var s='try{ parent.Recv.document.location.href }catch(kl_err){ 0 }';")
            'strMsg.Append("if(!eval(s)) {")
            '�@�@�@�l�b�g���[�N���̗��R�ɂ��t���[�����ɂg�s�l�k�W�J����Ȃ��������B
            '�@�@�@�ʏ�̕��@�Ń`�F�b�N���s���ƃZ�L�����e�B�̖���A�N�Z�X�����ۂ�����
            'strMsg.Append("	 fncDataCheck();")
            'strMsg.Append("	 fncMessage();")
            'strMsg.Append("} else {")
            '      �y�[�W�͑��݂����̂Ń_�~�[��HIDDEN���ڂ̑��݃`�F�b�N���s��
            'strMsg.Append("  obj=parent.Recv.document.getElementById('hdnDummy');")
            'strMsg.Append("  if (obj == null){")
            'strMsg.Append("	   fncDataCheck();")
            'strMsg.Append("	   fncMessage();")
            'strMsg.Append("  }")
            'strMsg.Append("}")
            'strMsg.Append("};")
            'strMsg.Append("myTimer = setInterval(fncckrty," & strJUSINCHECK & ");")
            '//2012/10/10 W.GANEKO CHG
        End If

        '2013/12/25 T.Ono add �Ď����P2013
        If hdnCtlFlg.Value = "KEJUTAI" Then
            Dim strJUSINCHECK As String = CStr((CInt(ConfigurationSettings.AppSettings("JINTER2")) * 1000) * 3)
            strMsg.Append("myTimer = setInterval('fncCheck_retry2()'," & strJUSINCHECK & ");")
        End If
        mlog("[KEJUKJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load end")

    End Sub

    '******************************************************************************
    '*�@�T�@�v�F�������s����l��n���v���p�e�B
    '*�@���@�l�F���������{�^���̎�ނ�Ԃ�
    '******************************************************************************
    Public ReadOnly Property pExecFlag() As String
        Get
            Return strExecFlg
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�x��E�Ή��敪��Ԃ��v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pCtlFlg() As String
        Get
            Return hdnCtlFlg.Value
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�O��f�[�^������Ԃ��v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pDataCount() As String
        Get
            Return hdnDataCount.Value
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�O��f�[�^�o�͂̃X�^�[�g�ʒu��Ԃ��v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pRownum() As String
        Get
            Return hdnRownum.Value
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�����Ώۂ̃{�^���C���f�b�N�X��Ԃ��v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pINDEX() As String
        Get
            Return hdnINDEX.Value
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�����Ώۂ̏����ԍ���Ԃ��v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pSERIAL() As String
        Get
            Return hdnKEY_SERIAL.Value
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F��ʂ̖�����������������Ԃ��v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pNoReactionCount() As Integer
        Get
            If Request.Form("hdnNoReactionCOUNT").Length > 0 Then
                Return CInt(Request.Form("hdnNoReactionCOUNT"))
            Else
                Return 0
            End If
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F��ʂ̖�����������Ԃ��v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pDoReactionCount() As Integer
        Get
            If Request.Form("hdnDoReactionCOUNT").Length > 0 Then
                Return CInt(Request.Form("hdnDoReactionCOUNT"))
            Else
                Return 0
            End If
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F��ʂ̖�����������Ԃ��v���p�e�B
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pTaiTmskbCount() As Integer
        Get
            If Request.Form("hdnTaiTmskbCOUNT").Length > 0 Then
                Return CInt(Request.Form("hdnTaiTmskbCOUNT"))
            Else
                Return 0
            End If
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�����X�V�`�F�b�N��Ԃ�Ԃ��v���p�e�B�@2013/12/13 T.Ono add �Ď����P2013
    '*�@���@�l�F0�F�`�F�b�N�Ȃ��@1�F�`�F�b�N����
    '******************************************************************************
    Public ReadOnly Property pChkJido() As String
        Get
            Return hdnJido.Value
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�������̂݃`�F�b�N��Ԃ�Ԃ��v���p�e�B�@2013/12/13 T.Ono add �Ď����P2013
    '*�@���@�l�F0�F�`�F�b�N�Ȃ��@1�F�`�F�b�N����
    '******************************************************************************
    Public ReadOnly Property pChkMishori() As String
        Get
            Return hdnMishori.Value
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�O��o�͂̏�������Ԃ��v���p�e�B�@2013/12/18 T.Ono add �Ď����P2013
    '*�@���@�l�F��ʏ�
    '******************************************************************************
    Public ReadOnly Property pSYORI_SERIAL1() As String
        Get
            Return hdnSYORI_SERIAL1.Value
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�O��o�͂̏�������Ԃ��v���p�e�B�@2013/12/18 T.Ono add �Ď����P2013
    '*�@���@�l�F��ʒ�
    '******************************************************************************
    Public ReadOnly Property pSYORI_SERIAL2() As String
        Get
            Return hdnSYORI_SERIAL2.Value
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�O��o�͂̏�������Ԃ��v���p�e�B�@2013/12/18 T.Ono add �Ď����P2013
    '*�@���@�l�F��ʉ�
    '******************************************************************************
    Public ReadOnly Property pSYORI_SERIAL3() As String
        Get
            Return hdnSYORI_SERIAL3.Value
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�O��o�͂̏�������Ԃ��v���p�e�B�@2019/11/01 w.ganeko add �Ď����P2019
    '*�@���@�l�F��ʉ�
    '******************************************************************************
    Public ReadOnly Property pSYORI_SERIAL4() As String
        Get
            Return hdnSYORI_SERIAL4.Value
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�O��o�͂̏�������Ԃ��v���p�e�B�@2019/11/01 w.ganeko add �Ď����P2019
    '*�@���@�l�F��ʉ�
    '******************************************************************************
    Public ReadOnly Property pSYORI_SERIAL5() As String
        Get
            Return hdnSYORI_SERIAL5.Value
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�O��o�͂̏�������Ԃ��v���p�e�B�@2019/11/01 w.ganeko add �Ď����P2019
    '*�@���@�l�F��ʉ�
    '******************************************************************************
    Public ReadOnly Property pSYORI_SERIAL6() As String
        Get
            Return hdnSYORI_SERIAL6.Value
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�ً}�Ή��{�^�������t���O��Ԃ��v���p�e�B�@2014/01/20 T.Ono add �Ď����P2013
    '*�@���@�l�F�P�F�����@0�F�������ĂȂ�
    '******************************************************************************
    Public ReadOnly Property pBtmOukaFlg() As String
        Get
            Return hdnBtmOukaFlg.Value
        End Get
    End Property

    Private Sub btnFirst_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFirst.ServerClick
        strExecFlg = "DATAFIRST"
        mlog("[KEJUKJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- btnFirst_ServerClick KEJUKJKG00.aspx server.Transfer DATAFIRST")
        Server.Transfer("KEJUKJKG00.aspx")
    End Sub

    Private Sub btnPre_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPre.ServerClick
        strExecFlg = "DATAPRE"
        mlog("[KEJUKJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- btnPre_ServerClick KEJUKJKG00.aspx server.Transfer DATAPRE")
        Server.Transfer("KEJUKJKG00.aspx")
    End Sub

    Private Sub btnNex_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNex.ServerClick
        strExecFlg = "DATANEX"
        mlog("[KEJUKJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- btnNex_ServerClick KEJUKJKG00.aspx server.Transfer DATANEX")
        Server.Transfer("KEJUKJKG00.aspx")
    End Sub

    Private Sub btnEnd_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnd.ServerClick
        strExecFlg = "DATAEND"
        Dim lineno As String = New StackFrame(True).GetFileLineNumber.ToString
        mlog("[KEJUKJAG00 " & lineno & "]- btnEnd_ServerClick KEJUKJKG00.aspx server.Transfer DATAEND")
        Server.Transfer("KEJUKJKG00.aspx")
    End Sub

    Private Sub btnRenew_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRenew.ServerClick
        strExecFlg = "DATARENEW"
        mlog("[KEJUKJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- btnRenew_ServerClick KEJUKJKG00.aspx server.Transfer DATARENEW")
        Server.Transfer("KEJUKJKG00.aspx")
    End Sub
    '**********************************************************
    ' 2012/06/28 ADD W.GANEKO
    '���O�f���o��
    '�߂�l�F�������񂾃t�@�C���ւ̃t���p�X
    '**********************************************************
    Public Sub mlog(ByVal pstrString As String)
        Dim strFilnm As String = "log" & System.DateTime.Today.ToString("yyyyMMdd")
        Dim strLogPath As String = ConfigurationSettings.AppSettings("LOG_OUT_PATH")
        Dim strPath As String = strLogPath & strFilnm & ".txt"
        Dim strLogFlg As String = ConfigurationSettings.AppSettings("LOG_OUT")
        Dim strRecLog As String
        Dim LogC As New CLog

        Dim linestring As New StringBuilder("")
        If strLogFlg = "1" Then
            '�������݃t�@�C���ւ̃X�g���[��
            'Dim sw As StreamWriter
            'Dim fs As New FileStream(strPath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite)
            'linestring = New StringBuilder("")
            'linestring.Append(System.DateTime.Now & "." & System.DateTime.Now.Millisecond & "[" & AuthC.pUSERNAME & "][" & AuthC.pIPADDRESS & "][" & Me.Session.SessionID & "]" & pstrString & Chr(13) & Chr(10))
            Dim tbllog As String = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff") & " " & pstrString
            strRecLog = LogC.mAPLog(Me.Session.SessionID, AuthC.pUSERNAME, AuthC.pIPADDRESS, Request.Form("hdnMyAspx"), "4", tbllog, Request.Form)

            'sw = New StreamWriter(fs, System.Text.Encoding.Default)

            ''�����̕�������X�g���[���ɏ�������
            'sw.Write(linestring.ToString)

            ''�������t���b�V���i�t�@�C���������݁j
            ''sw.Flush()

            ''�t�@�C���N���[�Y
            'sw.Close()
            'sw.Dispose()
            'fs.Close()
            'fs.Dispose()
        End If
    End Sub
End Class
