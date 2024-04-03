'***********************************************
'�Ή����́@�e�`�w���M�f�[�^�쐬
'***********************************************
Option Explicit On
Option Strict On


Imports Common
Imports JPG.Common
Imports JPG.Common.log

Imports System.Text

Partial Class KETAIJFG00
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
    '*�@�T�@�v�F�e�`�w���M�{�^��������
    '*�@���@�l�F
    '******************************************************************************
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '//------------------------------------------
        HttpHeaderC.mNoCache(Response)

        '//------------------------------------------
        '// �F�؃N���X�̃C���X�^���X����
        AuthC = New CAuthenticate(Request, Response)

        '//------------------------------------------
        '//�@�F�؏���
        '<TODO>�F�g�p�\�������w�肷��
        '�g�p�\����(�^:��/�c:�~/��:��/�o:�~)
        '2005/12/03 NEC UPDATE START
        '[�Ή�����]�g�p�\����(�^:��/�c:��/��:��/�o:�~)
        'AuthC.fncAuthCheck(Server, AuthC.pGROUP_UNKOU & "," & AuthC.pGROUP_KANSHI)
        AuthC.fncAuthCheck(Server, AuthC.pGROUP_UNKOU & "," & AuthC.pGROUP_KANSHI & "," & AuthC.pGROUP_EIGYOU)
        '2005/12/03 NEC UPDATE START

        '//------------------------------------------
        '// �v�d�a�T�[�r�X�̃C���X�^���X���쐬
        Dim strRec As String
        Dim KEFAXJAW00C As New KETAIJAG00KEFAXJAW00.KEFAXJAW00

        '//------------------------------------------
        '// �Ăяo�����̉�ʃN���X�C���X�^���X���쐬
        'Dim KETAIJTG00C As KETAIJTG00
        'KETAIJTG00C = CType(Context.Handler, KETAIJTG00)

        '//------------------------------------------
        '// �v�d�a�T�[�r�X�̎��s

        '2014/12/25 T.Ono add 2014���P�J�� No4 START
        '���[��/�v���r���[�ɕ\�����锭�M�҂�config�t�@�C������擾
        '�iFAX��KEFAXJAE00.exe.config[JIDOU_DOCUMENT_SENDERNAME]����擾���Ă���j
        Dim strSEND_NAME As String = ""
        If InStr(AuthC.pGROUPNAME, "0�Ď��Ɩ��P��") > 0 Then
            '����
            strSEND_NAME = ConfigurationSettings.AppSettings("JIDOU_DOCUMENT_SENDERNAME_OKINAWA")
        Else
            '���̑��i����Ď������A�^�s�A�c�Ə��j
            strSEND_NAME = ConfigurationSettings.AppSettings("JIDOU_DOCUMENT_SENDERNAME_KAWAGUCHI")
        End If

        '����ޭ��쐬
        If Request.Form("hdnBtnKBN") = "2" Then
            Dim strRes As String
            strRes = fncCreatePreview(strSEND_NAME)
            If strRes <> "OK" Then
                strMsg.Append("alert('�V�X�e���G���[�F" & strRes & "');")
            End If
            '������ޭ��\���������ɂ́A�K�p����Ȃ������B
            strMsg.Append("parent.Form1.btnTelHas.disabled=false;")
            strMsg.Append("parent.Form1.btnPreview.focus();")
            strMsg.Append("location.replace('about:blank');")   '��M�t���[�������u�����N�y�[�W�ɁB
            Return
        End If
        '2014/12/25 T.Ono add 2014���P�J�� No4 END

        Dim strSendFlg As String
        strSendFlg = Request.Form("hdnSendFlg")
        If strSendFlg = "2" Or strSendFlg = "3" Then
            '2020/11/01 T.Ono mod 2020�Ď����P�@hdnTEL_MEMO4�`6�ǉ�
            strRec = KEFAXJAW00C.fncDataOut(Request.Form("hdnSYONO"),
                                            Request.Form("hdnFAX_TITLE"),
                                            Request.Form("hdnACBCD"),
                                            Request.Form("hdnKURACD"),
                                            Request.Form("hdnKANSCD"),
                                            Request.Form("hdnJUSYONM"),
                                            Request.Form("hdnUSER_CD"),
                                            Request.Form("hdnJUTEL1"),
                                            Request.Form("hdnJUTEL2"),
                                            Request.Form("hdnRENTEL"),
                                            Request.Form("hdnADDR"),
                                            Request.Form("hdnHATYMD"),
                                            Request.Form("hdnHATTIME"),
                                            Request.Form("hdnKENSIN"),
                                            Request.Form("hdnRYURYO"),
                                            Request.Form("hdnMETASYU"),
                                            Request.Form("hdnKMNM1"),
                                            Request.Form("hdnKMNM2"),
                                            Request.Form("hdnKMNM3"),
                                            Request.Form("hdnKMNM4"),
                                            Request.Form("hdnKMNM5"),
                                            Request.Form("hdnKMNM6"),
                                            Request.Form("hdnTAIOKBN"),
                                            Request.Form("hdnTKTANCD"),
                                            Request.Form("hdnSYOYMD"),
                                            Request.Form("hdnSYOTIME"),
                                            Request.Form("hdnSIJIYMD"),
                                            Request.Form("hdnSIJITIME"),
                                            Request.Form("hdnTAITCD"),
                                            Request.Form("hdnTELRCD"),
                                            Request.Form("hdnFUK_MEMO"),
                                            Request.Form("hdnTEL_MEMO1"),
                                            Request.Form("hdnTEL_MEMO2"),
                                            Request.Form("hdnTEL_MEMO4"),
                                            Request.Form("hdnTEL_MEMO5"),
                                            Request.Form("hdnTEL_MEMO6"),
                                            Request.Form("hdnTKIGCD"),
                                            Request.Form("hdnTSADCD"),
                                            Request.Form("txtFAX_REN"),
                                            Request.Form("hdnMITOKBN")
                                           )
            Dim strRecMsg As String
            Dim strTextName As String

            Select Case Left(strRec, 2)
                Case "OK"   '//����I��
                    strTextName = strRec
                    strTextName = strTextName.Substring(2, strTextName.Length - 2)
                    '2015/12/09 w.ganeko 2015���P�J�� ��2 start
                    'strMsg.Append("var strRec;")
                    'strMsg.Append("strRec = parent.Form1.Fax.SetExePath(parent.Form1.hdnFAXEXEPATH.value);")
                    'strMsg.Append("strRec = parent.Form1.Fax.SetExeName(parent.Form1.hdnFAXEXENAME.value);")
                    'strMsg.Append("strRec = parent.Form1.Fax.SetHdValue(parent.Form1.hdnFAXHEAD.value);")
                    'strMsg.Append("strRec = parent.Form1.Fax.SetFaxNumber(parent.Form1.hdnSNDFAXNO.value.split(' - ').join(''));")
                    'strMsg.Append("var strTemp;")
                    'strMsg.Append("strTemp = (parent.Form1.hdnFAXSESSION.value + ' ' + parent.Form1.hdnKURACD.value);")
                    'strMsg.Append("strTemp = (strTemp + (parent.Form1.hdnHATYMD.value.split('/').join('') + ' ' + parent.Form1.hdnSYONO.value + ' '));")
                    ''strMsg.Append("strTemp = (strTemp + ' ' + '" & strTextName & "');") '2014/02/04 T.Ono mod �Ď����P2013 FAX�T�[�o�[�I��ǉ�
                    'strMsg.Append("strTemp = (strTemp + ' ' + '" & strTextName & "' + ' ' + parent.Form1.hdnFAXServerKBN.value);")
                    'strMsg.Append("strRec = parent.Form1.Fax.SetParam(strTemp);")
                    'strMsg.Append("strRec = parent.Form1.Fax.FncExecFax();")
                    'strMsg.Append("strRec = parent.Form1.Fax.GetStatus();")
                    Dim strToFaxStr As String
                    strToFaxStr = Request.Form("hdnSNDFAXNO")
                    strMsg.Append("var strFaxNo = '" & strToFaxStr & "';" & vbCrLf)
                    strMsg.Append("var strRec;" & vbCrLf)
                    strMsg.Append("strRec = parent.Form1.Fax.SetExePath(parent.Form1.hdnFAXEXEPATH.value);" & vbCrLf)
                    strMsg.Append("strRec = parent.Form1.Fax.SetExeName(parent.Form1.hdnFAXEXENAME.value);" & vbCrLf)
                    strMsg.Append("strRec = parent.Form1.Fax.SetHdValue(parent.Form1.hdnFAXHEAD.value);" & vbCrLf)
                    strMsg.Append("strRec = parent.Form1.Fax.SetFaxNumber(strFaxNo.split(' - ').join(''));" & vbCrLf)
                    strMsg.Append("var strTemp;" & vbCrLf)
                    strMsg.Append("strTemp = (parent.Form1.hdnFAXSESSION.value + ' ' + parent.Form1.hdnKURACD.value);" & vbCrLf)
                    strMsg.Append("strTemp = (strTemp + (parent.Form1.hdnHATYMD.value.split('/').join('') + ' ' + parent.Form1.hdnSYONO.value + ' '));" & vbCrLf)
                    strMsg.Append("strTemp = (strTemp + ' ' + '" & strTextName & "' + ' ' + parent.Form1.hdnFAXServerKBN.value);")
                    strMsg.Append("strRec = parent.Form1.Fax.SetParam(strTemp);" & vbCrLf)
                    strMsg.Append("strRec = parent.Form1.Fax.FncExecFax();" & vbCrLf)
                    strMsg.Append("strRec = parent.Form1.Fax.GetStatus();" & vbCrLf)
                    '2015/12/09 w.ganeko 2015���P�J�� ��2 end

                    '������2020/03/16 T.Ono FAX���M���@�ύX����
                    'strMsg.Append("alert('Hello');" & vbCrLf)
                    'strMsg.Append("var sh;" & vbCrLf)
                    'strMsg.Append("sh = new ActiveXObject('WScript.Shell');" & vbCrLf)
                    'strMsg.Append("var res;" & vbCrLf)
                    'strMsg.Append("res = sh.run('D:/KANSI/DIAL/call.vbs, 0, true');" & vbCrLf)

                Case Else
                    Dim ErrMsgC As New CErrMsg
                    strMsg.Append("alert('�V�X�e���G���[�F" & ErrMsgC.mGetArtMsg(strRec) & "');")
            End Select

            strMsg.Append("parent.Form1.btnTelHas.disabled=false;")
            '2015/12/09 w.ganeko 2015���P�J�� ��2
            strMsg.Append("parent.Form1.btnSoExit.disabled=true;")
            strMsg.Append("parent.Form1.btnTelHas.focus();")
            strMsg.Append("location.replace('about:blank');")   '��M�t���[�������u�����N�y�[�W�ɁB
        End If

        If strSendFlg = "3" Or strSendFlg = "4" Then
            Dim strMail As String
            Dim strMailPass As String
            strMail = Request.Form("hdnSNDMAIL")
            strMailPass = Request.Form("hdnSNDMAILPASS")
            '2015/01/19 T.Ono mod 2014���P�J�� [���M��:strSEND_NAME]��ǉ�
            '2020/11/01 T.Ono mod 2020�Ď����P hdnTEL_MEMO4�`6�ǉ�
            strRec = KEFAXJAW00C.fncExcelDataOut(Request.Form("hdnSYONO"),
                                Request.Form("hdnFAX_TITLE"),
                                Request.Form("hdnACBCD"),
                                Request.Form("hdnKURACD"),
                                Request.Form("hdnKANSCD"),
                                Request.Form("hdnJUSYONM"),
                                Request.Form("hdnUSER_CD"),
                                Request.Form("hdnJUTEL1"),
                                Request.Form("hdnJUTEL2"),
                                Request.Form("hdnRENTEL"),
                                Request.Form("hdnADDR"),
                                Request.Form("hdnHATYMD"),
                                Request.Form("hdnHATTIME"),
                                Request.Form("hdnKENSIN"),
                                Request.Form("hdnRYURYO"),
                                Request.Form("hdnMETASYU"),
                                Request.Form("hdnKMNM1"),
                                Request.Form("hdnKMNM2"),
                                Request.Form("hdnKMNM3"),
                                Request.Form("hdnKMNM4"),
                                Request.Form("hdnKMNM5"),
                                Request.Form("hdnKMNM6"),
                                Request.Form("hdnTAIOKBN"),
                                Request.Form("hdnTKTANCD"),
                                Request.Form("hdnSYOYMD"),
                                Request.Form("hdnSYOTIME"),
                                Request.Form("hdnSIJIYMD"),
                                Request.Form("hdnSIJITIME"),
                                Request.Form("hdnTAITCD"),
                                Request.Form("hdnTELRCD"),
                                Request.Form("hdnFUK_MEMO"),
                                Request.Form("hdnTEL_MEMO1"),
                                Request.Form("hdnTEL_MEMO2"),
                                Request.Form("hdnTEL_MEMO4"),
                                Request.Form("hdnTEL_MEMO5"),
                                Request.Form("hdnTEL_MEMO6"),
                                Request.Form("hdnTKIGCD"),
                                Request.Form("hdnTSADCD"),
                                Request.Form("txtFAX_REN"),
                                Request.Form("hdnMITOKBN"),
                                strSendFlg,
                                strMail,
                                strMailPass,
                                strSEND_NAME
                               )
            If Left(strRec, 2) = "OK" Then
                strMsg.Append("alert('���[���𑗐M���܂����B');")
            Else
                strMsg.Append("alert('���[�����M�Ɏ��s���܂����B');")
            End If
            strMsg.Append("parent.Form1.btnTelHas.disabled=false;")
            '2015/12/09 w.ganeko 2015���P�J�� ��2
            strMsg.Append("parent.Form1.btnSoExit.disabled=true;")
            strMsg.Append("parent.Form1.btnTelHas.focus();")
            strMsg.Append("location.replace('about:blank');")   '��M�t���[�������u�����N�y�[�W�ɁB
        End If


    End Sub

    '******************************************************************************
    '*�@�T�@�v�F�v���r���[�쐬
    '*�@���@�l�F2014/12/25 T.Ono add 2014���P�J�� No4
    '******************************************************************************
    Private Function fncCreatePreview(ByVal pstrSEND_NAME As String) As String
        '//------------------------------------------
        '// �v�d�a�T�[�r�X�̃C���X�^���X���쐬
        Dim strRec As String
        Dim KEFAXJAW00C As New KETAIJAG00KEFAXJAW00.KEFAXJAW00


        '//------------------------------------------
        '// �v�d�a�T�[�r�X�̎��s

        '1.FAX�p�f�[�^�̃e�L�X�g�t�@�C���쐬
        '2.�e�L�X�g�t�@�C������G�N�Z���t�@�C���쐬

        'FAX�p�f�[�^�̃e�L�X�g�t�@�C���쐬
        Dim strSendFlg As String
        strSendFlg = Request.Form("hdnSendFlg")
        '2020/11/01 T.Ono mod 2020�Ď����P hdnTEL_MEMO4�`6�ǉ�
        strRec = KEFAXJAW00C.fncDataOut(Request.Form("hdnSYONO"),
                                        Request.Form("hdnFAX_TITLE"),
                                        Request.Form("hdnACBCD"),
                                        Request.Form("hdnKURACD"),
                                        Request.Form("hdnKANSCD"),
                                        Request.Form("hdnJUSYONM"),
                                        Request.Form("hdnUSER_CD"),
                                        Request.Form("hdnJUTEL1"),
                                        Request.Form("hdnJUTEL2"),
                                        Request.Form("hdnRENTEL"),
                                        Request.Form("hdnADDR"),
                                        Request.Form("hdnHATYMD"),
                                        Request.Form("hdnHATTIME"),
                                        Request.Form("hdnKENSIN"),
                                        Request.Form("hdnRYURYO"),
                                        Request.Form("hdnMETASYU"),
                                        Request.Form("hdnKMNM1"),
                                        Request.Form("hdnKMNM2"),
                                        Request.Form("hdnKMNM3"),
                                        Request.Form("hdnKMNM4"),
                                        Request.Form("hdnKMNM5"),
                                        Request.Form("hdnKMNM6"),
                                        Request.Form("hdnTAIOKBN"),
                                        Request.Form("hdnTKTANCD"),
                                        Request.Form("hdnSYOYMD"),
                                        Request.Form("hdnSYOTIME"),
                                        Request.Form("hdnSIJIYMD"),
                                        Request.Form("hdnSIJITIME"),
                                        Request.Form("hdnTAITCD"),
                                        Request.Form("hdnTELRCD"),
                                        Request.Form("hdnFUK_MEMO"),
                                        Request.Form("hdnTEL_MEMO1"),
                                        Request.Form("hdnTEL_MEMO2"),
                                        Request.Form("hdnTEL_MEMO4"),
                                        Request.Form("hdnTEL_MEMO5"),
                                        Request.Form("hdnTEL_MEMO6"),
                                        Request.Form("hdnTKIGCD"),
                                        Request.Form("hdnTSADCD"),
                                        Request.Form("txtFAX_REN"),
                                        Request.Form("hdnMITOKBN")
                                        )

        '�e�L�X�g�t�@�C���̍쐬����
        If Left(strRec, 2) <> "OK" Then
            '�G���[
            Return strRec
        End If


        '�G�N�Z���t�@�C���쐬
        Dim strTextName As String
        strTextName = strRec
        strTextName = strTextName.Substring(2, strTextName.Length - 2)
        '2015/12/09 w.ganeko 2015���P�J�� ��2 start
        Dim strToFax As String()
        Dim strToFaxStr As String
        strToFaxStr = Request.Form("hdnSNDFAXNO")
        strToFax = strToFaxStr.Split(","c)

        'strRec = KEFAXJAW00C.mExcel(Request.Form("hdnFAXSESSION"), strTextName, _
        '                     pstrSEND_NAME, "", "", "", Request.Form("hdnSNDFAXNO"), "2")
        strRec = KEFAXJAW00C.mExcel(Request.Form("hdnFAXSESSION"), strTextName, _
                             pstrSEND_NAME, "", "", "", strToFax(0), "2")
        '2015/12/09 w.ganeko 2015���P�J�� ��2 end

        'strRec = "ERROR*ERROR*ERROR"
        '�G�N�Z���t�@�C���̍쐬����
        If strRec.Substring(0, 5) = "ERROR" Then
            '���̂܂܂̃��b�Z�[�W���o��
        Else
            HttpHeaderC.mDownLoadXLS(Response, "�v���r���[.xls")
            Response.ContentType = "application/msexcel" '2017/05/11 T.Ono add �u�t�@�C�����J���v�ۂ̃G���[�΍�
            Response.WriteFile(strRec)
            strRec = "OK"
        End If

        Return strRec
    End Function

End Class
