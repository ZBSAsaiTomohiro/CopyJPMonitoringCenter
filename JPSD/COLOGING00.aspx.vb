'***********************************************
'�H���󒍃V�X�e���@���C�����
'***********************************************
'<TODO>�錾���ʎd�l
Option Explicit On
Option Strict On

'<TODO>�錾���ʎd�l
Imports Common
Imports JPG.Common
Imports JPG.Common.log

Imports System.Text     '�FStringBuilder���g�p���邽��
Imports System.Web.Security

Partial Class COLOGING00
    Inherits System.Web.UI.Page

    Protected ConstC As New CConst

    '<TODO>�錾���ʎd�l
    '******************************************************************************
    ' HttpHeader
    '******************************************************************************
    Protected HttpHeaderC As New CHttpHeader

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
        '//------------------------------------------
        '//�@HTTP�w�b�_�𑗐M
        HttpHeaderC.mNoCache(Response)

        '//------------------------------------------
        '// Script�����ݗp�ϐ��錾
        Dim strScript As New StringBuilder("")

        '//��ʂ̏o�̓v���p�e�B�𐧌䂷��-------
        strScript.Append("<script language=javascript>")
        '--- ��2005/04/29 DEL Falcon�� ---
        'strScript.Append("var obj;")
        'strScript.Append("obj=document.referrer;")
        'strScript.Append("if (obj!=''){")
        'strScript.Append("parent.location.href='COGBASEG00.aspx';")
        'strScript.Append("}")
        'strScript.Append("var uAgent = navigator.userAgent.toUpperCase();")
        'strScript.Append("if (uAgent.indexOf('WINDOWS CE') < 0){")
        'strScript.Append("if((opener==null)&&(obj=='')){")
        '--- ��2005/04/29 DEL Falcon�� ---
        strScript.Append("if(opener==null){")
        strScript.Append("window.open('COGBASEG00.aspx','','toolbar=no,location=no,directories=no,status=no,menubar=yes,scrollbars=yes,scrollbars=yes,resizable=yes,top=0,left=0,width=1024,height=768');")
        strScript.Append("window.opener=true;")
        strScript.Append("(window.open('','_self').opener=window).close();")        '2012/06/26 NEC ou Add
        'strScript.Append("window.close();")                                        '2012/06/26 NEC ou Del
        strScript.Append("}")
        '--- ��2005/04/29 DEL Falcon�� ---
        'strScript.Append("}")
        '--- ��2005/04/29 DEL Falcon�� 
        strScript.Append("</script>")
        '//-------------------------------------

        Dim cscript1 As New CScript
        Dim strScriptPath As String
        strScriptPath = ConfigurationSettings.AppSettings("SCRIPTPATH")

        '------------------------------------------------------------------------------
        '<TODO>HTML���ɕK�v��JavaScript/CSS�͂�����[strScript]�ϐ��Ɋi�[��
        '      ��ʏ�[lblScript]�ɏ������݂��s���܂�(SPAN�^�O�Ƃ��ăN���C�A���g�ɃX�N���v�g��
        '      �o�͂���܂��B)
        '      [lblScript(Label)]���쐬���鎖
        '//------------------------------------------
        '//�@JavaScript�i�[
        strScript.Append("<Script language=javascript>")
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

        '//-------------------------------------------------
        '<TODO>�����̉��ID��HIDDEN��hdnMyAspx�ɏ������ށi�V�X�e�����ʁj
        hdnMyAspx.Value = "COLOGING00"
        '//-------------------------------------------------

        '//-------------------------------------------------
        '//  �o���m�F����̖߂�J�ڂ�����ׁA���̉�ʂ��o�͂���O�ɔF�؂��폜����
        FormsAuthentication.SignOut()

        '//------------------------------------------------
        '�t�H�[�J�X���Z�b�g����
        strMsg.Append("Form1.txtSHUTU_CD.focus();")

        '//------------------------------------------------
        '//�Ď��Z���^�[����̑J�ڂ̏ꍇ�A����𐧌䂷��ׂɉ�ʂh�c�𕪂���
        If MyBase.IsPostBack = False Then
            '//--------------------------------------
            '//���߂ĊJ�������������s�����
            Dim strIPADDRESS As String = Request.ServerVariables("REMOTE_ADDR")     '//IP�A�h���X
            '//hdnLOGIN_FLG 0:�ʏ�o����Ё@1:�Ď��Z���^�[
            If Request.Form("hdnMyAspx") = "SDLOGJAG00" Or Request.Form("hdnLOGIN_FLG") = "1" Then
                '-------------------------------------------------
                '//�`�o���O��������
                Dim LogC As New CLog
                Dim strRecLog As String
                '2012/04/06 NEC ou Upd Str
                'strRecLog = LogC.mAPLog(Request.Cookies.Get("ASP.NET_SessionId").Value, Request.Form("hdnUSERCD"), strIPADDRESS, hdnMyAspx.Value, "4", "�Ď��Z���^�[���O�C��", Request.Form)
                strRecLog = LogC.mAPLog(Me.Session.SessionID, Request.Form("hdnUSERCD"), strIPADDRESS, hdnMyAspx.Value, "4", "�Ď��Z���^�[���O�C��", Request.Form)
                '2012/04/06 NEC ou Upd End
                If strRecLog <> "OK" Then
                    Dim errmsgc As New CErrMsg
                    strMsg.Append("alert('�V�X�e���G���[�F" & errmsgc.mGetArtMsg(strRecLog) & "');")
                    Exit Sub
                End If

                '���O�C�����s�Ȃ�
                '-------------------------------------------------
                '//��x�T�C���A�E�g����
                FormsAuthentication.Initialize()
                '//�F�؍ς݂ɂ���
                FormsAuthentication.SetAuthCookie(Request.Form("hdnUSERCD"), False)
                '//�N�b�L�[�ɃZ�b�g(�L�[�ɂ̓��[�U�[�R�[�h�������n��)
                Call fncSetCookie(Convert.ToString(Request.Form("hdnUSERCD")), "1")

                '//���O�C����ʂ̎��y�[�W�ً͋}�o���ꗗ
                Response.Redirect("COGBASEG00.aspx")
            End If
        End If
    End Sub

    '******************************************************************************
    ' 
    '******************************************************************************
    Private Sub btnLogon_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogon.ServerClick
        Dim strRec As String

        Dim strShutu_cd As String = txtSHUTU_CD.Value                           '//�o����ЃR�[�h
        Dim strKyoten_cd As String = txtKYOTEN_CD.Value                         '//���_�R�[�h
        Dim strUserPass As String = txtUserPass.Value                           '//�p�X���[�h
        Dim strIPADDRESS As String = Request.ServerVariables("REMOTE_ADDR")     '//IP�A�h���X

        Dim LogC As New CLog
        Dim strRecLog As String

        Try
            If strShutu_cd.Length = 0 Or strKyoten_cd.Length = 0 Or strUserPass.Length = 0 Then
                strRec = "�o����ЃR�[�h�A���_�R�[�h�܂��̓p�X���[�h���Ⴂ�܂��B"
                Exit Try
            End If

            '//�����������s��
            Dim SQLC As New JPSDCSQL.CSQL
            Dim SqlParamC As New CSQLParam
            Dim strSQL As New StringBuilder("")
            Dim ds As New DataSet

            '//SQL���̍쐬
            strSQL.Append("SELECT ")
            strSQL.Append("SHUTU_CD, ")
            strSQL.Append("KYOTEN_CD, ")
            strSQL.Append("PASSWD ")
            strSQL.Append("FROM  SHUTUDOMAS ")
            strSQL.Append("WHERE SHUTU_CD = :SHUTU_CD ")
            strSQL.Append("  AND KYOTEN_CD = :KYOTEN_CD ")
            strSQL.Append("  AND PASSWD = :PASSWD ")

            SqlParamC.fncSetParam("SHUTU_CD", True, strShutu_cd)
            SqlParamC.fncSetParam("KYOTEN_CD", True, strKyoten_cd)
            SqlParamC.fncSetParam("PASSWD", True, strUserPass)

            ds = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

            If ds.Tables(0).Rows.Count = 0 Then
                '//�f�[�^���P���������������ʏ�̃��b�Z�[�W�t�B�[���h�Ƀ��b�Z�[�W�\��
                strRec = "�o����ЃR�[�h�A���_�R�[�h�܂��̓p�X���[�h���Ⴂ�܂��B"
                Exit Try
            Else
                '//�f�[�^����������
                '//�R�[�h��XYZ��������
                If Convert.ToString(ds.Tables(0).Rows(0).Item(0)) = "XYZ" Then
                    strRec = "�o����ЃR�[�h�A���_�R�[�h�܂��̓p�X���[�h���Ⴂ�܂��B"
                    Exit Try
                Else
                    If txtSHUTU_CD.Value = Convert.ToString(ds.Tables(0).Rows(0).Item("SHUTU_CD")) And _
                        txtKYOTEN_CD.Value = Convert.ToString(ds.Tables(0).Rows(0).Item("KYOTEN_CD")) And _
                        txtUserPass.Value = Convert.ToString(ds.Tables(0).Rows(0).Item("PASSWD")) Then
                        '-------------------------------------------------
                        strRec = "���O�C������I��"

                        '-------------------------------------------------
                        '//�`�o���O�������� ���F�؂n�j���̃��O�o�́�
                        '2012/04/06 NEC ou Upd Str
                        'strRecLog = LogC.mAPLog(Request.Cookies.Get("ASP.NET_SessionId").Value, strShutu_cd & "-" & strKyoten_cd, strIPADDRESS, hdnMyAspx.Value, "4", strRec, Request.Form)
                        strRecLog = LogC.mAPLog(Me.Session.SessionID, strShutu_cd & "-" & strKyoten_cd, strIPADDRESS, hdnMyAspx.Value, "4", strRec, Request.Form)
                        '2012/04/06 NEC ou Upd End
                        If strRecLog <> "OK" Then
                            Dim errmsgc As New CErrMsg
                            strMsg.Append("alert('�V�X�e���G���[�F" & errmsgc.mGetArtMsg(strRecLog) & "');")
                            Exit Sub
                        End If

                        '-------------------------------------------------
                        txtUserPass.Value = Convert.ToString(ds.Tables(0).Rows(0).Item("PASSWD"))
                        '//��x�T�C���A�E�g����
                        FormsAuthentication.Initialize()
                        '//�F�؍ς݂ɂ���
                        FormsAuthentication.SetAuthCookie(txtSHUTU_CD.Value, False)
                        '//�N�b�L�[�ɃZ�b�g
                        Call fncSetCookie(Convert.ToString(ds.Tables(0).Rows(0).Item("SHUTU_CD")), "0")
                        '//���O�C����ʂ̎��y�[�W�ً͋}�o���ꗗ
                        Response.Redirect("COGBASEG00.aspx")

                        Exit Sub
                    Else
                        '//���[�U�����p�X���[�h������Ă�����
                        strRec = "���[�U�[�R�[�h�܂��̓p�X���[�h���Ⴂ�܂��B"
                        Exit Try
                    End If
                End If
            End If

            '//�N�b�L�[�ɃZ�b�g
            Call fncSetCookie(Convert.ToString(ds.Tables(0).Rows(0).Item("SHUTU_CD")), "0")

        Catch ex As Exception

        End Try

        '-------------------------------------------------
        '//���b�Z�[�W�̏o��
        lblMsg.Text = strRec

        '-------------------------------------------------
        '//�`�o���O�������� ���F�؃G���[���̃��O�o�́�
        '2012/04/06 NEC ou Upd Str
        'strRecLog = LogC.mAPLog(Request.Cookies.Get("ASP.NET_SessionId").Value, strShutu_cd & "-" & strKyoten_cd, strIPADDRESS, hdnMyAspx.Value, "4", strRec, Request.Form)
        strRecLog = LogC.mAPLog(Me.Session.SessionID, strShutu_cd & "-" & strKyoten_cd, strIPADDRESS, hdnMyAspx.Value, "4", strRec, Request.Form)
        '2012/04/06 NEC ou Upd End
        If strRecLog <> "OK" Then
            Dim errmsgc As New CErrMsg
            strMsg.Append("alert('�V�X�e���G���[�F" & errmsgc.mGetArtMsg(strRecLog) & "');")
        End If

    End Sub

    '******************************************************************************
    ' 
    '******************************************************************************
    Private Sub fncSetCookie(ByVal pstrHCY_CD As String, ByVal pstrFLG As String)
        '�J�E���^
        Dim i As Integer
        Dim intFlg As Integer = 0
        Dim array() As String

        '�N�b�L�[�R���N�V����
        Dim MyCookieColl As HttpCookieCollection
        '���݂̃N�b�L�[�R���N�V������ϐ��Ɋi�[
        MyCookieColl = Request.Cookies
        '�N�b�L�[�R���N�V�������̂��ׂẴL�[��z��Ɋi�[
        array = MyCookieColl.AllKeys()

        '�z��̍Ō�܂Ń��[�v
        For i = 0 To array.GetUpperBound(0)
            '���ɃL�[���Z�b�g���Ă��邩�ǂ����AHCY_CD�L�[�̗L���Ŕ��f����
            If MyCookieColl(i).Name = ConstC.pCookie_SD_Logincd Then
                '�L�[���Z�b�g���Ă邩�ǂ����̔��f�t���O
                intFlg = 1
                Exit For
            End If
        Next
        Dim ckSHUTU_CD As HttpCookie        '�o����ЃR�[�h
        Dim ckKYOTEN_CD As HttpCookie       '���_�R�[�h
        Dim ckCENTCD As HttpCookie          '�g�p�\�Ď��Z���^�[�R�[�h

        If intFlg = 0 Then
            '�L�[���Z�b�g����Ă��Ȃ�������
            '�V�����L�[�����
            ckSHUTU_CD = New HttpCookie(ConstC.pCookie_SD_Logincd)
            ckKYOTEN_CD = New HttpCookie(ConstC.pCookie_SD_Kyotencd)
            '�Ď��Z���^�[����̃��O�C���Ƃ���
            ckCENTCD = New HttpCookie(ConstC.pCookie_SD_ALLCenter)
        Else
            '�L�[���Z�b�g����Ă�����
            '���̃L�[��ϐ��Ɋi�[
            ckSHUTU_CD = MyCookieColl(ConstC.pCookie_SD_Logincd)
            ckKYOTEN_CD = MyCookieColl(ConstC.pCookie_SD_Kyotencd)
            '�Ď��Z���^�[����̃��O�C���Ƃ���
            ckCENTCD = MyCookieColl(ConstC.pCookie_SD_ALLCenter)
        End If

        ckSHUTU_CD.Value = pstrHCY_CD
        ckKYOTEN_CD.Value = Request.Form("txtKYOTEN_CD")
        '�Ď��Z���^�[����̃��O�C���Ƃ���
        ckCENTCD.Value = Request.Form("hdnCENTERCD")

        '�N�b�L�[�ɖ߂�
        Response.Cookies.Add(ckSHUTU_CD)
        Response.Cookies.Add(ckKYOTEN_CD)
        Response.Cookies.Add(ckCENTCD)
    End Sub
End Class
