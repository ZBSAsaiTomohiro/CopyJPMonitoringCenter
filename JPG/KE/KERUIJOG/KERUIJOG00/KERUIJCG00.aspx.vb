'***********************************************
'�Ď��Ή����W�v�\  �����m�F
'***********************************************
Option Explicit On
'Option Strict On

Imports Common
Imports JPG.Common
Imports JPG.Common.log

Imports System.Text

Partial Class KERUIJCG00
    Inherits System.Web.UI.Page

    '******************************************************************************
    ' HttpHeader
    '******************************************************************************
    Protected HttpHeaderC As New CHttpHeader

    '******************************************************************************
    ' �e��ʃN���X
    '******************************************************************************
    Protected KERUIJOG00C As KERUIJOG00

    '<TODO>�錾���ʎd�l
    '******************************************************************************
    ' �F�؃N���X
    '******************************************************************************
    Protected AuthC As CAuthenticate

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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If True Then
            '//------------------------------------------
            '//�@HTTP�w�b�_�𑗐M
            HttpHeaderC.mNoCache(Response)

            '//<TODO>Transfer���Ă����e�̃n���h���������p��
            KERUIJOG00C = CType(Context.Handler, KERUIJOG00)

            Dim strRec As String
            Dim strRecMsg As String
            Dim KERUIJCG00C As New KERUIJOG00KERUIJOW00.KERUIJOW00
            '2015/11/04 w.ganeko 2015���P�J�� ��6 start
            'strRec = KERUIJCG00C.mCheck( _
            '                       KERUIJOG00C.pKuracd, _
            '                       KERUIJOG00C.pKyocd, _
            '                       KERUIJOG00C.pJacd, _
            '                       KERUIJOG00C.pJascd, _
            '                       KERUIJOG00C.pHatKbn, _
            '                       KERUIJOG00C.pYmdFrom, _
            '                       KERUIJOG00C.pYmdTo, _
            '                       ConstC.pPageMax _
            '                       )
            '2017/02/15 H.Mori mod ���P2016 No9-1 START
            'strRec = KERUIJCG00C.mCheck( _
            '                        KERUIJOG00C.pKuracd, _
            '                        KERUIJOG00C.pKyocd, _
            '                        KERUIJOG00C.pJacdFr, _
            '                        KERUIJOG00C.pJacdTo, _
            '                        KERUIJOG00C.pJascdFr, _
            '                        KERUIJOG00C.pJascdTo, _
            '                        KERUIJOG00C.pHatKbn, _
            '                        KERUIJOG00C.pYmdFrom, _
            '                        KERUIJOG00C.pYmdTo, _
            '                        ConstC.pPageMax, _
            '                        KERUIJOG00C.pHanbaiFr, _
            '                        KERUIJOG00C.pHanbaiTo, _
            '                        KERUIJOG00C.pTaiKbn, _
            '                        KERUIJOG00C.pHkKbn _
            '                        )
            '2015/11/04 w.ganeko 2015���P�J�� ��6 end
            strRec = KERUIJCG00C.mCheck( _
                                    KERUIJOG00C.pKuracd, _
                                    KERUIJOG00C.pKyocd, _
                                    KERUIJOG00C.pJacdFr, _
                                    KERUIJOG00C.pJacdTo, _
                                    KERUIJOG00C.pJascdFr, _
                                    KERUIJOG00C.pJascdTo, _
                                    KERUIJOG00C.pHatKbn, _
                                    KERUIJOG00C.pYmdFrom, _
                                    KERUIJOG00C.pYmdTo, _
                                    ConstC.pPageMax, _
                                    KERUIJOG00C.pHanbaiFr, _
                                    KERUIJOG00C.pHanbaiTo, _
                                    KERUIJOG00C.pTaiKbn, _
                                    KERUIJOG00C.pHkKbn, _
                                    KERUIJOG00C.pKikankbn, _
                                    KERUIJOG00C.pTimeFrom, _
                                    KERUIJOG00C.pTimeTo _
                                    )
            '2017/02/15 H.Mori mod ���P2016 No9-1 END
            If strRec = "DATA0" Then
                '�f�[�^��0���̏ꍇ
                strRecMsg = "�Ώۃf�[�^�����݂��܂���"
                strMsg.Append("alert('" & strRecMsg & "');" & vbCrLf)
                strMsg.Append("parent.Data.Form1.btnSelect.focus();" & vbCrLf)

            ElseIf strRec = "DATAMAX" Then
                strRec = "CHK"
                '���݂���ׁA�㏑���̊m�F���s��
                strMsg.Append(vbCrLf)
                strMsg.Append("function fncChkMessage(){" & vbCrLf)
                strMsg.Append("var strRes;" & vbCrLf)
                strMsg.Append("strRes = confirm('�ő�o�͌����𒴂��܂����B\n�o�͂��܂����H');" & vbCrLf)
                strMsg.Append("if (strRes==false){" & vbCrLf)
                strMsg.Append("  parent.Data.Form1.btnSelect.disabled = false;")     '//�����߂�
                strMsg.Append("  return;" & vbCrLf)
                strMsg.Append("}" & vbCrLf)
                strMsg.Append("" & vbCrLf)
                strMsg.Append("parent.Data.doPostBack('btnSelect','');" & vbCrLf)
                strMsg.Append("}" & vbCrLf)
                strMsg.Append("window.onload = fncChkMessage;" & vbCrLf)
                strMsg.Append(vbCrLf)
            Else
                strMsg.Append("try{" & vbCrLf)
                'strMsg.Append("alert('KERUIJCG00 001');" & vbCrLf)
                strMsg.Append("parent.Data.doPostBack('btnSelect','');" & vbCrLf)
                'strMsg.Append("window.opener.parent.Data.doPostBack('btnSelect','');" & vbCrLf)
                'strMsg.Append("alert('KERUIJCG00 002');" & vbCrLf)
                strMsg.Append("}catch(e){alert('ERROR:' + e);}" & vbCrLf)
            End If
        Else
            Dim bytExcel() As Byte
            Dim objBasp As Object
            'KERUIJOG00TEST.xls
            HttpHeaderC.mDownLoadXLS(Response, "KERUIJOG00.xls")
            objBasp = Server.CreateObject("Basp21")
            'bytExcel = objBasp.BinaryRead(Server.MapPath("D:\TEMP\KERUIJOG00TEST.xls"))
            bytExcel = objBasp.BinaryRead("D:\TEMP\KERUIJOG00TEST.xls")
            objBasp = Nothing
            Response.AddHeader("Content-Length", CStr(UBound(bytExcel) + 1))
            Response.BinaryWrite(bytExcel)
        End If
    End Sub

End Class
