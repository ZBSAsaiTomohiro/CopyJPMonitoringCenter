'***********************************************
'�Ή�����  ���s����
'***********************************************
Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common.log

Imports System.Text

Partial Class SDSYUJJG00
    Inherits System.Web.UI.Page
    '******************************************************************************
    ' HttpHeader
    '******************************************************************************
    Protected HttpHeaderC As New CHttpHeader

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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' �y�[�W�����������郆�[�U�[ �R�[�h�������ɑ}�����܂��B
        '//------------------------------------------
        HttpHeaderC.mNoCache(Response)

        Dim strRec As String
        Dim SDSYUJAW00C As New SDSYUJAG00SDSYUJAW00.SDSYUJAW00

        Dim SDSYUJAG00C As SDSYUJAG00
        SDSYUJAG00C = CType(Context.Handler, SDSYUJAG00)
        'AP�̃T�[�r�X�����s-------------------------------
        '2006/06/15 NEC UPDATE START
        'strRec = SDSYUJAW00C.mSet(SDSYUJAG00C.gstrKANSCD, _
        '                            SDSYUJAG00C.gstrSYONO, _
        '                            SDSYUJAG00C.gstrKBN, _
        '                            SDSYUJAG00C.gstrTSTANCD, _
        '                            SDSYUJAG00C.gstrSTD_CD, _
        '                            SDSYUJAG00C.gstrSTD_KYOTEN_CD, _
        '                            SDSYUJAG00C.gstrSYUTDTNM, _
        '                            SDSYUJAG00C.gstrJUYMD, _
        '                            SDSYUJAG00C.gstrJUTIME, _
        '                            SDSYUJAG00C.gstrTYAKYMD, _
        '                            SDSYUJAG00C.gstrTYAKTIME, _
        '                            SDSYUJAG00C.gstrSYOKANYMD, _
        '                            SDSYUJAG00C.gstrSYOKANTIME, _
        '                            SDSYUJAG00C.gstrAITCD, _
        '                            SDSYUJAG00C.gstrMETHEIKAKU, _
        '                            SDSYUJAG00C.gstrRUSUHAIRI, _
        '                            SDSYUJAG00C.gstrKIGCD, _
        '                            SDSYUJAG00C.gstrSADCD, _
        '                            SDSYUJAG00C.gstrASECD, _
        '                            SDSYUJAG00C.gstrSTACD, _
        '                            SDSYUJAG00C.gstrFKICD, _
        '                            SDSYUJAG00C.gstrJAKENREN, _
        '                            SDSYUJAG00C.gstrRENTIME, _
        '                            SDSYUJAG00C.gstrKIGUTAIYO, _
        '                            SDSYUJAG00C.gstrGASMUMU, _
        '                            SDSYUJAG00C.gstrORGENIN, _
        '                            SDSYUJAG00C.gstrHAIKAN, _
        '                            SDSYUJAG00C.gstrGASUGUMU, _
        '                            SDSYUJAG00C.gstrHOSKOKAN, _
        '                            SDSYUJAG00C.gstrMETYOINA, _
        '                            SDSYUJAG00C.gstrTYOUYOINA, _
        '                            SDSYUJAG00C.gstrVALYOINA, _
        '                            SDSYUJAG00C.gstrKYUHAIUMU, _
        '                            SDSYUJAG00C.gstrCOYOINA, _
        '                            SDSYUJAG00C.gstrSDTBIK2, _
        '                            SDSYUJAG00C.gstrSNTTOKKI, _
        '                            SDSYUJAG00C.gstrMETFUKKI, _
        '                            SDSYUJAG00C.gstrHOAN, _
        '                            SDSYUJAG00C.gstrGASGIRE, _
        '                            SDSYUJAG00C.gstrKIGKOSYO, _
        '                            SDSYUJAG00C.gstrCSNTGEN, _
        '                            SDSYUJAG00C.gstrCSNTNGAS, _
        '                            SDSYUJAG00C.gstrSDTBIK1, _
        '                            SDSYUJAG00C.gstrADD_DATE, _
        '                            SDSYUJAG00C.gstrEDT_DATE, _
        '                            SDSYUJAG00C.gstrEDT_TIME)
        '2006/06/15 NEC UPDATE END
        '2008/10/14 T.Watabe edit
        'strRec = SDSYUJAW00C.mSet(SDSYUJAG00C.gstrKANSCD, _
        '                    SDSYUJAG00C.gstrSYONO, _
        '                    SDSYUJAG00C.gstrKBN, _
        '                    SDSYUJAG00C.gstrTSTANCD, _
        '                    SDSYUJAG00C.gstrSTD_CD, _
        '                    SDSYUJAG00C.gstrSTD_KYOTEN_CD, _
        '                    SDSYUJAG00C.gstrSYUTDTNM, _
        '                    SDSYUJAG00C.gstrJUYMD, _
        '                    SDSYUJAG00C.gstrJUTIME, _
        '                    SDSYUJAG00C.gstrTYAKYMD, _
        '                    SDSYUJAG00C.gstrTYAKTIME, _
        '                    SDSYUJAG00C.gstrSYOKANYMD, _
        '                    SDSYUJAG00C.gstrSYOKANTIME, _
        '                    SDSYUJAG00C.gstrAITCD, _
        '                    SDSYUJAG00C.gstrMETHEIKAKU, _
        '                    SDSYUJAG00C.gstrRUSUHAIRI, _
        '                    SDSYUJAG00C.gstrKIGCD, _
        '                    SDSYUJAG00C.gstrSADCD, _
        '                    SDSYUJAG00C.gstrASECD, _
        '                    SDSYUJAG00C.gstrSTACD, _
        '                    SDSYUJAG00C.gstrFKICD, _
        '                    SDSYUJAG00C.gstrJAKENREN, _
        '                    SDSYUJAG00C.gstrRENTIME, _
        '                    SDSYUJAG00C.gstrKIGUTAIYO, _
        '                    SDSYUJAG00C.gstrGASMUMU, _
        '                    SDSYUJAG00C.gstrORGENIN, _
        '                    SDSYUJAG00C.gstrHAIKAN, _
        '                    SDSYUJAG00C.gstrGASUGUMU, _
        '                    SDSYUJAG00C.gstrHOSKOKAN, _
        '                    SDSYUJAG00C.gstrMETYOINA, _
        '                    SDSYUJAG00C.gstrTYOUYOINA, _
        '                    SDSYUJAG00C.gstrVALYOINA, _
        '                    SDSYUJAG00C.gstrKYUHAIUMU, _
        '                    SDSYUJAG00C.gstrCOYOINA, _
        '                    SDSYUJAG00C.gstrSDTBIK2, _
        '                    SDSYUJAG00C.gstrSNTTOKKI, _
        '                    SDSYUJAG00C.gstrSDTBIK3, _
        '                    SDSYUJAG00C.gstrMETFUKKI, _
        '                    SDSYUJAG00C.gstrHOAN, _
        '                    SDSYUJAG00C.gstrGASGIRE, _
        '                    SDSYUJAG00C.gstrKIGKOSYO, _
        '                    SDSYUJAG00C.gstrCSNTGEN, _
        '                    SDSYUJAG00C.gstrCSNTNGAS, _
        '                    SDSYUJAG00C.gstrSDTBIK1, _
        '                    SDSYUJAG00C.gstrADD_DATE, _
        '                    SDSYUJAG00C.gstrEDT_DATE, _
        '                    SDSYUJAG00C.gstrEDT_TIME)
        ' 2014/10/30 H.Hosoda mod 2014���P�J�� No11
        'strRec = SDSYUJAW00C.mSet(SDSYUJAG00C.gstrKANSCD, _
        '                    SDSYUJAG00C.gstrSYONO, _
        '                    SDSYUJAG00C.gstrKBN, _
        '                    SDSYUJAG00C.gstrTSTANCD, _
        '                    SDSYUJAG00C.gstrSTD_CD, _
        '                    SDSYUJAG00C.gstrSTD_KYOTEN_CD, _
        '                    SDSYUJAG00C.gstrSYUTDTNM, _
        '                    SDSYUJAG00C.gstrJUYMD, _
        '                    SDSYUJAG00C.gstrJUTIME, _
        '                    SDSYUJAG00C.gstrSDYMD, _
        '                    SDSYUJAG00C.gstrSDTIME, _
        '                    SDSYUJAG00C.gstrTYAKYMD, _
        '                    SDSYUJAG00C.gstrTYAKTIME, _
        '                    SDSYUJAG00C.gstrSYOKANYMD, _
        '                    SDSYUJAG00C.gstrSYOKANTIME, _
        '                    SDSYUJAG00C.gstrAITCD, _
        '                    SDSYUJAG00C.gstrMETHEIKAKU, _
        '                    SDSYUJAG00C.gstrRUSUHAIRI, _
        '                    SDSYUJAG00C.gstrKIGCD, _
        '                    SDSYUJAG00C.gstrSADCD, _
        '                    SDSYUJAG00C.gstrASECD, _
        '                    SDSYUJAG00C.gstrSTACD, _
        '                    SDSYUJAG00C.gstrFKICD, _
        '                    SDSYUJAG00C.gstrJAKENREN, _
        '                    SDSYUJAG00C.gstrRENTIME, _
        '                    SDSYUJAG00C.gstrKIGUTAIYO, _
        '                    SDSYUJAG00C.gstrGASMUMU, _
        '                    SDSYUJAG00C.gstrORGENIN, _
        '                    SDSYUJAG00C.gstrHAIKAN, _
        '                    SDSYUJAG00C.gstrGASUGUMU, _
        '                    SDSYUJAG00C.gstrHOSKOKAN, _
        '                    SDSYUJAG00C.gstrMETYOINA, _
        '                    SDSYUJAG00C.gstrTYOUYOINA, _
        '                    SDSYUJAG00C.gstrVALYOINA, _
        '                    SDSYUJAG00C.gstrKYUHAIUMU, _
        '                    SDSYUJAG00C.gstrCOYOINA, _
        '                    SDSYUJAG00C.gstrSDTBIK2, _
        '                    SDSYUJAG00C.gstrSNTTOKKI, _
        '                    SDSYUJAG00C.gstrSDTBIK3, _
        '                    SDSYUJAG00C.gstrMETFUKKI, _
        '                    SDSYUJAG00C.gstrHOAN, _
        '                    SDSYUJAG00C.gstrGASGIRE, _
        '                    SDSYUJAG00C.gstrKIGKOSYO, _
        '                    SDSYUJAG00C.gstrCSNTGEN, _
        '                    SDSYUJAG00C.gstrCSNTNGAS, _
        '                    SDSYUJAG00C.gstrSDTBIK1, _
        '                    SDSYUJAG00C.gstrADD_DATE, _
        '                    SDSYUJAG00C.gstrEDT_DATE, _
        '                    SDSYUJAG00C.gstrEDT_TIME)
        strRec = SDSYUJAW00C.mSet(SDSYUJAG00C.gstrKANSCD, _
                    SDSYUJAG00C.gstrSYONO, _
                    SDSYUJAG00C.gstrKBN, _
                    SDSYUJAG00C.gstrTSTANCD, _
                    SDSYUJAG00C.gstrTSTANNM, _
                    SDSYUJAG00C.gstrSTD_CD, _
                    SDSYUJAG00C.gstrSTD_KYOTEN_CD, _
                    SDSYUJAG00C.gstrSYUTDTNM, _
                    SDSYUJAG00C.gstrJUYMD, _
                    SDSYUJAG00C.gstrJUTIME, _
                    SDSYUJAG00C.gstrSDYMD, _
                    SDSYUJAG00C.gstrSDTIME, _
                    SDSYUJAG00C.gstrTYAKYMD, _
                    SDSYUJAG00C.gstrTYAKTIME, _
                    SDSYUJAG00C.gstrSYOKANYMD, _
                    SDSYUJAG00C.gstrSYOKANTIME, _
                    SDSYUJAG00C.gstrAITCD, _
                    SDSYUJAG00C.gstrMETHEIKAKU, _
                    SDSYUJAG00C.gstrRUSUHAIRI, _
                    SDSYUJAG00C.gstrKIGCD, _
                    SDSYUJAG00C.gstrSADCD, _
                    SDSYUJAG00C.gstrASECD, _
                    SDSYUJAG00C.gstrSTACD, _
                    SDSYUJAG00C.gstrFKICD, _
                    SDSYUJAG00C.gstrJAKENREN, _
                    SDSYUJAG00C.gstrRENTIME, _
                    SDSYUJAG00C.gstrKIGUTAIYO, _
                    SDSYUJAG00C.gstrGASMUMU, _
                    SDSYUJAG00C.gstrORGENIN, _
                    SDSYUJAG00C.gstrHAIKAN, _
                    SDSYUJAG00C.gstrGASUGUMU, _
                    SDSYUJAG00C.gstrHOSKOKAN, _
                    SDSYUJAG00C.gstrMETYOINA, _
                    SDSYUJAG00C.gstrTYOUYOINA, _
                    SDSYUJAG00C.gstrVALYOINA, _
                    SDSYUJAG00C.gstrKYUHAIUMU, _
                    SDSYUJAG00C.gstrCOYOINA, _
                    SDSYUJAG00C.gstrSDTBIK2, _
                    SDSYUJAG00C.gstrSNTTOKKI, _
                    SDSYUJAG00C.gstrSDTBIK3, _
                    SDSYUJAG00C.gstrMETFUKKI, _
                    SDSYUJAG00C.gstrHOAN, _
                    SDSYUJAG00C.gstrGASGIRE, _
                    SDSYUJAG00C.gstrKIGKOSYO, _
                    SDSYUJAG00C.gstrCSNTGEN, _
                    SDSYUJAG00C.gstrCSNTNGAS, _
                    SDSYUJAG00C.gstrSDTBIK1, _
                    SDSYUJAG00C.gstrADD_DATE, _
                    SDSYUJAG00C.gstrEDT_DATE, _
                    SDSYUJAG00C.gstrEDT_TIME)
        Dim strRecMsg As String
        If strRec <> "OK" Then
            '//�G���[�̏ꍇ�͉�ʂ�ێ����邽�߁A���b�N�����{�^�����g�p�\�ɂ���
            strMsg.Append("parent.Data.Form1.btnExit.disabled=false;")
            strMsg.Append("parent.Data.Form1.btnUpd1.disabled=false;")
            strMsg.Append("parent.Data.Form1.btnUpd2.disabled=false;")
        End If
        Select Case strRec
            Case "OK"   '//����I��
                '���̑������̏ꍇ�͏I���{�^���C�x���g
                strMsg.Append("alert('����ɏI�����܂���');")
                strMsg.Append("parent.Data.doPostBack('btnExit','');")
            Case "2"        '2012/04/27 NEC ou Upd
                strRecMsg = "�Ώۃf�[�^�����݂��܂���"
                strMsg.Append("alert('" & strRecMsg & "');")
                strRec = strRecMsg
            Case "0"        '2012/04/27 NEC ou Upd
                strRecMsg = "���̃��[�U�[�ɂ���ăf�[�^���X�V����Ă��܂��B�ēx�������Ă�������"
                strMsg.Append("alert('" & strRecMsg & "');")
                strRec = strRecMsg
                If SDSYUJAG00C.gstrKBN = "2" Then       '2012/04/27 NEC ou Upd
                    strMsg.Append("parent.Data.Form1.btnUpd1.focus();")
                Else
                    strMsg.Append("parent.Data.Form1.btnUpd2.focus();")
                End If
            Case "3"
                strRecMsg = "���ɑΉ��ς݂ɂȂ��Ă��܂�"
                strMsg.Append("alert('" & strRecMsg & "');")
                strRec = strRecMsg
                If SDSYUJAG00C.gstrKBN = "2" Then       '2012/04/27 NEC ou Upd
                    strMsg.Append("parent.Data.Form1.btnUpd1.focus();")
                Else
                    strMsg.Append("parent.Data.Form1.btnUpd2.focus();")
                End If
            Case Else
                Dim ErrMsgC As New CErrMsg
                strMsg.Append("alert('�V�X�e���G���[�F" & ErrMsgC.mGetArtMsg(strRec) & "');")
                strMsg.Append("with(parent.Data.Form1){")
                If SDSYUJAG00C.gstrKBN = "2" Then       '2012/04/27 NEC ou Upd
                    strMsg.Append("btnUpd1.focus();")
                Else
                    strMsg.Append("btnUpd2.focus();")
                End If
                strMsg.Append("}")
        End Select

        '-------------------------------------------------
        '//�`�o���O��������
        Dim LogC As New CLog
        Dim strRecLog As String
        '2012/04/06 NEC ou Upd Str
        'strRecLog = LogC.mAPLog(Request.Cookies.Get("ASP.NET_SessionId").Value, SDSYUJAG00C.pLOGIN_USER, SDSYUJAG00C.pLOGIN_IPADDRESS, SDSYUJAG00C.pMY_ASPX, "2", strRec, Request.Form)
        strRecLog = LogC.mAPLog(Me.Session.SessionID, SDSYUJAG00C.pLOGIN_USER, SDSYUJAG00C.pLOGIN_IPADDRESS, SDSYUJAG00C.pMY_ASPX, "2", strRec, Request.Form)
        '2012/04/06 NEC ou Upd End
        If strRecLog <> "OK" Then
            Dim errmsgc As New CErrMsg
            strMsg.Append("alert('�V�X�e���G���[�F" & errmsgc.mgetartmsg(strRecLog) & "');")
        End If

        strMsg.Append("location.replace('about:blank');")   '��M�t���[�������u�����N�y�[�W�ɁB

    End Sub
End Class
