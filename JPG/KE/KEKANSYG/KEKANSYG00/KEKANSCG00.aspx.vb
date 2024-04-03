'***********************************************
'�ݐϏ��ꗗ  �����m�F
'***********************************************
Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common
Imports JPG.Common.log

Imports System.Text

Partial Class KEKANSCG00
    Inherits System.Web.UI.Page

    '******************************************************************************
    ' HttpHeader
    '******************************************************************************
    Protected HttpHeaderC As New CHttpHeader

    '******************************************************************************
    ' �e��ʃN���X
    '******************************************************************************
    Protected KEKANSYG00C As KEKANSYG00

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
        '//------------------------------------------
        '//�@HTTP�w�b�_�𑗐M
        HttpHeaderC.mNoCache(Response)

        '//<TODO>Transfer���Ă����e�̃n���h���������p��
        KEKANSYG00C = CType(Context.Handler, KEKANSYG00)

        Dim strRec As String
        Dim strRecMsg As String
        Dim KEKANSCG00C As New KEKANSYG00KEKANSYW00.KEKANSYW00

        '2017/02/16 H.Mori mod ���P2016 No8-2 START
        '2015/02/09 H.Hosoda mod �Ď����P2014 ��14 Start
        'strRec = KEKANSCG00C.mCheck( _
        '                       KEKANSYG00C.pKuracd, _
        '                       KEKANSYG00C.pJacd, _
        '                       KEKANSYG00C.pYmdFrom, _
        '                       KEKANSYG00C.pYmdTo, _
        '                       ConstC.pPageMax _
        '                       )
        'strRec = KEKANSCG00C.mCheck( _
        '                       KEKANSYG00C.pKuracdFrom, _
        '                       KEKANSYG00C.pKuracdTo, _
        '                       KEKANSYG00C.pJacdFrom, _
        '                       KEKANSYG00C.pJacdTo, _
        '                       KEKANSYG00C.pHangrpFrom, _
        '                       KEKANSYG00C.pHangrpTo, _
        '                       KEKANSYG00C.pPgkbn, _
        '                       KEKANSYG00C.pHasseiTel, _
        '                       KEKANSYG00C.pHasseiKei, _
        '                       KEKANSYG00C.pTaiouTel, _
        '                       KEKANSYG00C.pTaiouShu, _
        '                       KEKANSYG00C.pTaiouJuf, _
        '                       KEKANSYG00C.pYmdFrom, _
        '                       KEKANSYG00C.pYmdTo, _
        '                       KEKANSYG00C.pTrgdatekbn, _
        '                       ConstC.pPageMax _
        '                       )
        '2015/02/09 H.Hosoda mod �Ď����P2014 ��14 End
        '2020/11/01 T.Ono mod �Ď����P2020 Start
        'pTsadcd �ǉ�
        strRec = KEKANSCG00C.mCheck(
                               KEKANSYG00C.pKuracdFrom,
                               KEKANSYG00C.pKuracdTo,
                               KEKANSYG00C.pJacdFrom,
                               KEKANSYG00C.pJacdTo,
                               KEKANSYG00C.pHangrpFrom,
                               KEKANSYG00C.pHangrpTo,
                               KEKANSYG00C.pPgkbn,
                               KEKANSYG00C.pHasseiTel,
                               KEKANSYG00C.pHasseiKei,
                               KEKANSYG00C.pTaiouTel,
                               KEKANSYG00C.pTaiouShu,
                               KEKANSYG00C.pTaiouJuf,
                               KEKANSYG00C.pYmdFrom,
                               KEKANSYG00C.pYmdTo,
                               KEKANSYG00C.pTrgdatekbn,
                               ConstC.pPageMax,
                               KEKANSYG00C.pTimeFrom,
                               KEKANSYG00C.pTimeTo,
                               KEKANSYG00C.pTsadcd
                               )
        '2017/02/16 H.Mori mod ���P2016 No8-2 END
        '2020/11/01 T.Ono mod �Ď����P2020 End

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
            strMsg.Append("parent.Data.doPostBack('btnSelect','');" & vbCrLf)
        End If
    End Sub

End Class
