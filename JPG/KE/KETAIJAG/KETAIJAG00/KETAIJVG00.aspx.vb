'***********************************************
'�R�s�[�⏕�|�b�v�A�b�v
'***********************************************
Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common

Imports System.Text
Imports System.IO

Partial Class KETAIJVG00
    Inherits System.Web.UI.Page


    Private strExecFlg As String

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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '//------------------------------------------
        '//�@HTTP�w�b�_�𑗐M
        HttpHeaderC.mNoCache(Response)

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
             MyBase.MapPath("../../../KE/KETAIJAG/KETAIJAG00/") & "KETAIJVG00.js"))
        '<�t�H�[�J�X�֘A�֐�>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncFo.js"))
        '<���̓`�F�b�N�֐�>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncChk.js"))
        '<�d�b�ԍ��`�F�b�N�֐�>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncTel.js"))
        '<�o�C�g���֐�>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncGetByte.js"))
        strScript.Append("</Script>")
        '//------------------------------------------
        '//�@Css�i�[
        strScript.Append("<Style>")
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "CssSmall.css"))
        strScript.Append("</Style>")
        '//------------------------------------------
        '//�@Script������
        lblScript.Text = strScript.ToString


        '//------------------------------------------------------------------------------
        If MyBase.IsPostBack = False Then
            '//--------------------------------------
            '//���߂ĊJ�������������s�����

            '//------------------------------------------
            '�f�[�^�̊i�[
            Dim KETAIJAG00C As KETAIJAG00
            KETAIJAG00C = CType(Context.Handler, KETAIJAG00)
            hdnKURACD.Value = KETAIJAG00C.gstrKURACD
            hdnACBCD.Value = KETAIJAG00C.gstrACBCD
            hdnUSER_CD.Value = KETAIJAG00C.gstrUSER_CD
            '--�A����2--
            txtRENTEL2.Text = KETAIJAG00C.gstrRENTEL2.Replace("-", "")
            txtRENTEL2_BIKO.Text = KETAIJAG00C.gstrRENTEL2_BIKO
            Dim strUpdDate As String = KETAIJAG00C.gstrRENTEL2_UPD_DATE
            If strUpdDate <> "" Then
                txtRENTEL2_UPD_DATE.Text = strUpdDate.Substring(0, 4) & "/" & strUpdDate.Substring(4, 2) & "/" & strUpdDate.Substring(6, 2)
            Else
                txtRENTEL2_UPD_DATE.Text = strUpdDate
            End If
            txtRENTEL2_UPD_DATE.Attributes.Add("ReadOnly", "true")
            '--�A����3--
            txtRENTEL3.Text = KETAIJAG00C.gstrRENTEL3.Replace("-", "")
            txtRENTEL3_BIKO.Text = KETAIJAG00C.gstrRENTEL3_BIKO
            strUpdDate = ""
            strUpdDate = KETAIJAG00C.gstrRENTEL3_UPD_DATE
            If strUpdDate <> "" Then
                txtRENTEL3_UPD_DATE.Text = strUpdDate.Substring(0, 4) & "/" & strUpdDate.Substring(4, 2) & "/" & strUpdDate.Substring(6, 2)
            Else
                txtRENTEL3_UPD_DATE.Text = strUpdDate
            End If
            txtRENTEL3_UPD_DATE.Attributes.Add("ReadOnly", "true")
            '--�d�b�ԍ�--       2016/12/13 H.Mori add 2016���P�J�� No5-1 
            txtTELAB.Text = KETAIJAG00C.gstrTELAB
            txtTELAB.Attributes.Add("ReadOnly", "true")
            '--��3�A���A����--  2016/12/13 H.Mori add 2016���P�J�� No5-1
            txtDAI3RENDORENTEL.Text = KETAIJAG00C.gstrDAI3RENDORENTEL
            txtDAI3RENDORENTEL.Attributes.Add("ReadOnly", "true")
            Dim teljvg As String = KETAIJAG00C.gstrTelJVG
            If teljvg = "2" Then
                rdoTel1_2.Checked = True
            ElseIf teljvg = "3" Then
                rdoTel1_3.Checked = True
            ElseIf teljvg = "4" Then
                rdoTel_AB.Checked = True
            ElseIf teljvg = "5" Then
                rdoTel_DAI3.Checked = True
            Else
                rdoTel1_2.Checked = True
            End If
            Dim gstrKBNMODE As String = KETAIJAG00C.gstrKBNMODE
            If gstrKBNMODE = "2" Then
                btnTelEnt.Attributes.Add("Disabled", "true")
            End If
        End If
    End Sub
    '******************************************************************************
    '*�@�T�@�v�F���s�{�^���������̏���
    '*�@���@�l�F
    '******************************************************************************
    Private Sub btnTelEnt_ServerClick(ByVal sender As System.Object, _
                                    ByVal e As System.EventArgs) Handles btnTelEnt.ServerClick
        Dim KETAIJAW00C As New KETAIJAG00KETAIJAW00.KETAIJAW00()
        Dim strRec As String
        Dim strRENTEL2_UPD_DATE As String
        Dim strRENTEL3_UPD_DATE As String
        Dim strUpdDate As String
        strRENTEL2_UPD_DATE = txtRENTEL2_UPD_DATE.Text
        strRENTEL3_UPD_DATE = txtRENTEL3_UPD_DATE.Text
        strRec = KETAIJAW00C.mUpd_SHAMAS(hdnKURACD.Value, _
                                         hdnACBCD.Value, _
                                         hdnUSER_CD.Value, _
                                         txtRENTEL2.Text, _
                                         txtRENTEL2_BIKO.Text, _
                                         txtRENTEL3.Text, _
                                         txtRENTEL3_BIKO.Text _
                                         )
        Select Case Left(strRec, 2)
            Case "OK"   '//����I��
                strMsg.Append("parent.opener.frames('data').Form1.hdnRENTEL2.value = '" & txtRENTEL2.Text.Replace("-", "") & "';" & vbCrLf)
                strMsg.Append("parent.opener.frames('data').Form1.hdnRENTEL2_BIKO.value = '" & txtRENTEL2_BIKO.Text & "';" & vbCrLf)
                strMsg.Append("parent.opener.frames('data').Form1.hdnRENTEL3.value = '" & txtRENTEL3.Text.Replace("-", "") & "';" & vbCrLf)
                strMsg.Append("parent.opener.frames('data').Form1.hdnRENTEL3_BIKO.value = '" & txtRENTEL3_BIKO.Text & "';" & vbCrLf)
                strUpdDate = ""
                strUpdDate = strRec.Substring(2, 8)
                Dim strRentelUpd As String = strRec.Substring(10, 1)
                'strMsg.Append("alert('" & strRec & "_" & strUpdDate & "_" & strRentelUpd & "')" & vbCrLf)
                If strRentelUpd = "1" Or strRentelUpd = "2" Then
                    If strUpdDate <> "" Then
                        txtRENTEL2_UPD_DATE.Text = strUpdDate.Substring(0, 4) & "/" & strUpdDate.Substring(4, 2) & "/" & strUpdDate.Substring(6, 2)
                    Else
                        txtRENTEL2_UPD_DATE.Text = strUpdDate
                    End If
                    strMsg.Append("parent.opener.frames('data').Form1.hdnRENTEL2_UPD_DATE.value = '" & strUpdDate & "';" & vbCrLf)
                Else
                    strMsg.Append("parent.opener.frames('data').Form1.hdnRENTEL2_UPD_DATE.value = '" & txtRENTEL2_UPD_DATE.Text.Replace("/", "") & "';" & vbCrLf)
                End If
                If strRentelUpd = "1" Or strRentelUpd = "3" Then
                    If strUpdDate <> "" Then
                        txtRENTEL3_UPD_DATE.Text = strUpdDate.Substring(0, 4) & "/" & strUpdDate.Substring(4, 2) & "/" & strUpdDate.Substring(6, 2)
                    Else
                        txtRENTEL3_UPD_DATE.Text = strUpdDate
                    End If
                    strMsg.Append("parent.opener.frames('data').Form1.hdnRENTEL3_UPD_DATE.value = '" & strUpdDate & "';" & vbCrLf)
                Else
                    strMsg.Append("parent.opener.frames('data').Form1.hdnRENTEL3_UPD_DATE.value = '" & txtRENTEL3_UPD_DATE.Text.Replace("/", "") & "';" & vbCrLf)
                End If
                Dim teljvg As String = ""
                If rdoTel1_2.Checked = True Then
                    teljvg = "2"
                ElseIf rdoTel1_3.Checked = True Then
                    teljvg = "3"
                End If
                strMsg.Append("parent.opener.frames('data').Form1.hdnTelJVG.value = '" & teljvg & "';" & vbCrLf)
                strMsg.Append("alert('����ɏI�����܂����B')" & vbCrLf)
                'strMsg.Append("parent.opener.frames('data').Form1.btnTelHas2.focus();" & vbCrLf)
                'strMsg.Append("window.close();" & vbCrLf)
            Case "N1"   '//�f�[�^����
                strMsg.Append("alert('�f�[�^�����݂��܂���B')" & vbCrLf)
                strMsg.Append("document.getElementById('btnTelEnt').focus();" & vbCrLf)
            Case "N2"   '//�ύX����
                strMsg.Append("alert('�ύX������܂���B')" & vbCrLf)
                strMsg.Append("document.getElementById('btnTelEnt').focus();" & vbCrLf)
            Case Else
                Dim ErrMsgC As New CErrMsg
                strMsg.Append("alert('�V�X�e���G���[�F" & ErrMsgC.mGetArtMsg(strRec) & "');")
        End Select
        KETAIJAW00C = Nothing

    End Sub
    ''**********************************************************
    '' 2012/06/28 ADD W.GANEKO
    ''���O�f���o��
    ''�߂�l�F�������񂾃t�@�C���ւ̃t���p�X
    ''**********************************************************
    'Public Sub mlog(ByVal pstrString As String)
    '    Dim strFilnm As String = "log" & System.DateTime.Today.ToString("yyyyMMdd")
    '    Dim strLogPath As String = ConfigurationSettings.AppSettings("LOG_OUT_PATH")
    '    Dim strPath As String = strLogPath & strFilnm & ".txt"
    '    Dim strLogFlg As String = ConfigurationSettings.AppSettings("LOG_OUT")
    '    If strLogFlg = "1" Then
    '        '�������݃t�@�C���ւ̃X�g���[��
    '        Dim outFile As New StreamWriter(strPath, True, System.Text.Encoding.Default)

    '        '�����̕�������X�g���[���ɏ�������
    '        outFile.Write(System.DateTime.Now & "|" & pstrString + vbCrLf)

    '        '�������t���b�V���i�t�@�C���������݁j
    '        outFile.Flush()

    '        '�t�@�C���N���[�Y
    '        outFile.Close()
    '    End If
    'End Sub
End Class
