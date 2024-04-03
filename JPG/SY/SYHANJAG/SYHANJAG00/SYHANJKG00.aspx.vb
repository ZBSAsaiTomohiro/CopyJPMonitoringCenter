'***********************************************
'
'***********************************************
'<TODO>�錾���ʎd�l
Option Explicit On
Option Strict On

'<TODO>�錾���ʎd�l
Imports Common
Imports JPG.Common
Imports JPG.Common.log

Imports System.Text

Partial Class SYHANJKG00
    Inherits System.Web.UI.Page

    '<TODO>�錾���ʎd�l
    '******************************************************************************
    ' HttpHeader
    '******************************************************************************
    Protected HttpHeaderC As New CHttpHeader

    '<TODO>�錾���ʎd�l
    '******************************************************************************
    '�F�؃N���X
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

        '//-----------------------------------------
        Dim SYHANJAG00C As SYHANJAG00
        SYHANJAG00C = CType(Context.Handler, SYHANJAG00)

        '//------------------------------------------LAST_DAY(
        '//�@�̔��Ǘ������擾����
        Dim SQLC As New SYHANJAG00CSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet

        strSQL.Append("SELECT ")
        strSQL.Append("NAME AS ZTRG, ")                                                     '�O��Ώ۔N��
        '--- ��2005/05/13 MOD Falcon�� ---
        strSQL.Append("TO_CHAR(ADD_MONTHS(TO_DATE(NAME||'01'),1),'YYYYMM') AS KTRG, ")      '����Ώ۔N��
        '--- ��2005/05/13 MOD Falcon�� ---
        '--- ��2005/05/13 DEL Falcon�� ---
        'strSQL.Append("TO_CHAR(TO_DATE(NAIYO2)+1,'YYYYMM') AS KTRG, ")                      '����Ώ۔N��
        '--- ��2005/05/13 DEL Falcon�� ---
        strSQL.Append("NAIYO1 AS ZSYF, ")                                                   '�O��W�v���ԊJ�n
        strSQL.Append("NAIYO2 AS ZSYT, ")                                                   '�O��W�v���ԏI��
        strSQL.Append("TO_CHAR(TO_DATE(NAIYO2)+1,'YYYYMMDD') AS KSYF ")                     '����W�v���ԊJ�n
        'strSQL.Append("TO_CHAR(TO_DATE(NAIYO2)+1,'YYYYMMDD') AS KSYF, ")                    '����W�v���ԊJ�n
        'strSQL.Append("TO_CHAR(LAST_DAY(TO_DATE(NAIYO2)+1),'YYYYMMDD') AS KSYT ")           '����W�v���ԏI��
        strSQL.Append("FROM M06_PULLDOWN ")
        strSQL.Append("WHERE KBN =:KBN ")
        strSQL.Append("  AND CD =:KENCD ")

        '�p�����[�^�̃Z�b�g
        SqlParamC.fncSetParam("KBN", True, "56")
        SqlParamC.fncSetParam("KENCD", True, SYHANJAG00C.pKENCD)

        dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

        If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
            '�O�񏈗��Ώ۔N��
            strMsg.Append("parent.Data.Form1.hdnTAISYO.value='" & "" & "';")
            '���񏈗��Ώ۔N��
            strMsg.Append("parent.Data.Form1.hdnTAISYOP1.value='" & fncZenMonth_Last(Now.ToString("yyyyMMdd")).Substring(0, 6) & "';")
            '�O��W�v���ԊJ�n
            strMsg.Append("parent.Data.Form1.hdnSYUKEIF.value='" & "" & "';")
            '�O��W�v���ԏI��
            strMsg.Append("parent.Data.Form1.hdnSYUKEIT.value='" & "" & "';")
            '����W�v���ԊJ�n
            strMsg.Append("parent.Data.Form1.hdnSYUKEIFP1.value='" & fncZenMonth_Last(Now.ToString("yyyyMMdd")).Substring(0, 6) & "01" & "';")
            '����W�v���ԏI��
            strMsg.Append("parent.Data.Form1.hdnSYUKEITP1.value='" & fncZenMonth_Last(Now.ToString("yyyyMMdd")) & "';")
        Else
            '�O�񏈗��Ώ۔N��
            strMsg.Append("parent.Data.Form1.hdnTAISYO.value='" & Convert.ToString(dbData.Tables(0).Rows(0).Item("ZTRG")) & "';")
            '���񏈗��Ώ۔N��
            strMsg.Append("parent.Data.Form1.hdnTAISYOP1.value='" & Convert.ToString(dbData.Tables(0).Rows(0).Item("KTRG")) & "';")
            '�O��W�v���ԊJ�n
            strMsg.Append("parent.Data.Form1.hdnSYUKEIF.value='" & Convert.ToString(dbData.Tables(0).Rows(0).Item("ZSYF")) & "';")
            '�O��W�v���ԏI��
            strMsg.Append("parent.Data.Form1.hdnSYUKEIT.value='" & Convert.ToString(dbData.Tables(0).Rows(0).Item("ZSYT")) & "';")
            '����W�v���ԊJ�n
            strMsg.Append("parent.Data.Form1.hdnSYUKEIFP1.value='" & Convert.ToString(dbData.Tables(0).Rows(0).Item("KSYF")) & "';")
            '����W�v���ԏI��
            'strMsg.Append("parent.Data.Form1.hdnSYUKEITP1.value='" & Convert.ToString(dbData.Tables(0).Rows(0).Item("KSYT")) & "';")
            strMsg.Append("parent.Data.Form1.hdnSYUKEITP1.value='';")
        End If
        '��ʐ���t�@���N�V�������s
        strMsg.Append("parent.Data.fncKbnChange();")

        '--- ��2005/05/16 ADD Falcon�� ---
        strMsg.Append("parent.Data.Form1.btnJikkou.disabled=false;")
        '--- ��2005/05/16 ADD Falcon�� ---

        '-------------------------------------------------
        '//
        strMsg.Append("location.replace('about:blank');")   '��M�t���[�������u�����N�y�[�W�ɁB

    End Sub

    '************************************************
    '�O��������Ԃ�
    '************************************************
    Private Function fncZenMonth_Last(ByVal pstrDate As String) As String
        Dim strRec As String
        Try
            strRec = Format(DateSerial(CInt(pstrDate.Substring(0, 4)), CInt(pstrDate.Substring(4, 2)), 1 - 1), "yyyyMMdd")
        Catch ex As Exception
            strRec = ""
        End Try
        Return strRec
    End Function

End Class
