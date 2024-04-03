'***********************************************
'�b�s�h��ʑJ�ڋ@�\
'***********************************************
Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common
Imports JPG.Common.log

Imports System.Text

Partial Class SYCTIJAG00
    Inherits System.Web.UI.Page

    Public gstrCLI_CD As String
    Public gstrHAN_CD As String
    Public gstrUSER_CD As String
    Public gstrCTITELNO As String
    Public gstrKENFLG As String

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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '//------------------------------------------
        '//�@HTTP�w�b�_�𑗐M
        HttpHeaderC.mNoCache(Response)

        '//------------------------------------------
        '//�@�F�؃N���X�̃C���X�^���X����
        AuthC = New CAuthenticate(Request, Response)

        Dim strRec As String
        Dim strTRANSFER As String

        '//------------------------------------------
        If IsNothing(Request.QueryString("CTINO")) = True Then
            '�ڋq������ʂɌ��������Ȃ��őJ�ڂ���
            '�����O�̏�ԂőJ��
            gstrCTITELNO = ""
            gstrKENFLG = "0"            '//�����O��ԂŌڋq������ʂ��o��
            strTRANSFER = "MSKOSJAG00"

            strRec = "�N�G���[�X�g�����O���ݒ肳��Ă��܂���"
        ElseIf Convert.ToString(Request.QueryString("CTINO")).Length > 0 Then
            '�f�[�^���P���݂̂̏ꍇ�́A���̃L�[��ێ����Ή����͉�ʂɑJ�ڂ���
            '�f�[�^�������A�������͑��݂��Ȃ��ꍇ�́A�擾�����d�b�ԍ��������ɂ����������Ԃ�
            '�ڋq������ʂɑJ�ڂ���

            gstrCTITELNO = Convert.ToString(Request.QueryString("CTINO"))

            Dim intCnt As Integer
            '�f�[�^���������A�f�[�^���o�͂��܂�
            intCnt = fncDataSelect()

            If intCnt = 1 Then
                gstrKENFLG = ""         '//�Ή����͉�ʂ��o��
                strTRANSFER = "KETAIJAG00"

                strRec = "��v�����d�b�ԍ��őΉ����͉�ʂ��o�͂��܂�"
            Else
                gstrKENFLG = "1"        '//�������ԂŌڋq������ʂ��o��
                strTRANSFER = "MSKOSJAG00"

                strRec = "���������o�����̂ŁA�ڋq������ʂ��o�͂��܂�"
            End If
        Else
            '�ڋq������ʂɌ��������Ȃ��őJ�ڂ���
            '�����O�̏�ԂőJ��
            gstrCTITELNO = ""
            gstrKENFLG = "0"            '//�����O��ԂŌڋq������ʂ��o��
            strTRANSFER = "MSKOSJAG00"

            strRec = "�d�b�ԍ����ݒ肳��Ă��܂���"
        End If

        '-------------------------------------------------
        '//�`�o���O��������
        Dim LogC As New CLog
        Dim strRecLog As String
        '2012/04/04 NEC ou Upd
        'strRecLog = LogC.mAPLog(Request.Cookies.Get("ASP.NET_SessionId").Value, AuthC.pUSERNAME, AuthC.pIPADDRESS, "SYCTIJAG00", "4", strRec, Request.Form)
        strRecLog = LogC.mAPLog(Me.Session.SessionID, AuthC.pUSERNAME, AuthC.pIPADDRESS, "SYCTIJAG00", "4", strRec, Request.Form)
        '2012/04/04 NEC ou Upd
        If strRecLog <> "OK" Then
            Dim errmsgc As New CErrMsg
            strMsg.Append("alert('�V�X�e���G���[�F" & errmsgc.mGetArtMsg(strRecLog) & "');")
        End If


        '��ʑJ�ڂ��s��
        Server.Transfer("../../../" & strTRANSFER.Substring(0, 2) & "/" & strTRANSFER.Substring(0, 8) & "/" & strTRANSFER & "/" & strTRANSFER & ".aspx")

    End Sub

    '******************************************************************************
    '* CTI����̓d�b�ԍ��Ō������A������Ԃ�
    '******************************************************************************
    Private Function fncDataSelect() As Integer
        Dim intRec As Integer
        '//------------------------------------------
        Dim SQLC As New SYCTIJAG00CCSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet

        strSQL.Append("SELECT ")
        strSQL.Append("CLI_CD, ")
        strSQL.Append("HAN_CD, ")
        strSQL.Append("USER_CD ")
        strSQL.Append("FROM SHAMAS ")
        'strSQL.Append("WHERE KANKENSAKU_TEL = :KANKENSAKU_TEL ") '2016/2/2 H.Mori mod �Ď����P2015
        strSQL.Append("WHERE REPLACE(REPLACE(KANKENSAKU_TEL,'-',''), ' ','') = :KANKENSAKU_TEL ") '2016/2/5 H.Mori add �Ď����P2015
        strSQL.Append("OR    REPLACE(REPLACE(RENTEL2,'-',''), ' ','') = :KANKENSAKU_TEL ") '2016/2/5 H.Mori add �Ď����P2015
        strSQL.Append("OR    REPLACE(REPLACE(RENTEL3,'-',''), ' ','') = :KANKENSAKU_TEL ") '2016/2/5 H.Mori add �Ď����P2015 
        '2017/04/24 H.Mori add �ێ��Ǘ� CTI�̌��������ƎQ�ƍ��ڂ���v������ START
        strSQL.Append("OR    REPLACE(REPLACE(TELA || TELB,'-',''), ' ', '') = :KANKENSAKU_TEL ")
        strSQL.Append("OR    REPLACE(REPLACE(DAI3RENDORENTEL,'-',''), ' ', '') = :KANKENSAKU_TEL ")
        '2017/04/24 H.Mori add �ێ��Ǘ� CTI�̌��������ƎQ�ƍ��ڂ���v������ END

        SqlParamC.fncSetParam("KANKENSAKU_TEL", True, gstrCTITELNO)

        dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

        If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
            '�f�[�^�Ȃ��Ń��^�[��
            gstrCLI_CD = ""
            gstrHAN_CD = ""
            gstrUSER_CD = ""
            intRec = 0
        Else
            If dbData.Tables(0).Rows.Count = 1 Then
                '�L�[��v����������
                gstrCLI_CD = Convert.ToString(dbData.Tables(0).Rows(0).Item("CLI_CD"))
                gstrHAN_CD = Convert.ToString(dbData.Tables(0).Rows(0).Item("HAN_CD"))
                gstrUSER_CD = Convert.ToString(dbData.Tables(0).Rows(0).Item("USER_CD"))
            Else
                '�f�[�^����������
                gstrCLI_CD = ""
                gstrHAN_CD = ""
                gstrUSER_CD = ""
            End If
            intRec = dbData.Tables(0).Rows.Count
        End If

        Return intRec
    End Function
End Class
