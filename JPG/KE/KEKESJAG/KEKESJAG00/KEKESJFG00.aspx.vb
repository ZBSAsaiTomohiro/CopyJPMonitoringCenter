'***********************************************
'�����f�[�^�ꗗ  �ꗗ���
'***********************************************
Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common
Imports System.Text

Partial Class KEKEKJFG00
    Inherits System.Web.UI.Page
    Protected WithEvents dbKeson As System.Data.DataSet

    Protected KEKESJAG00_C As KEKESJAG00
    Protected ConstC As New CConst

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
        Me.dbKeson = New System.Data.DataSet
        CType(Me.dbKeson, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'dbKeson
        '
        Me.dbKeson.DataSetName = "NewDataSet"
        Me.dbKeson.Locale = New System.Globalization.CultureInfo("ja-JP")
        CType(Me.dbKeson, System.ComponentModel.ISupportInitialize).EndInit()

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
    '*�@Page_Load
    '******************************************************************************
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                                                                    Handles MyBase.Load
        '//------------------------------------------
        '//�@HTTP�w�b�_�𑗐M
        HttpHeaderC.mNoCache(Response)

        '//------------------------------------------
        '// Script�����ݗp�ϐ��錾
        Dim strScript As New StringBuilder("")
        Dim cscript1 As New CScript
        Dim strScriptPath As String
        strScriptPath = ConfigurationSettings.AppSettings("SCRIPTPATH")
        '//------------------------------------------
        '//�@JavaScript�i�[
        strScript.Append("<Script language=javascript>")
        '���ꗗ�X�N���v�g��
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncBG.js"))
        strScript.Append("</Script>")
        '//------------------------------------------
        '//�@Css�i�[
        strScript.Append("<Style>")
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "CssIframe.css"))
        strScript.Append("</Style>")
        '//------------------------------------------
        '//�@Script������
        lblScript.Text = strScript.ToString

        '********************************************
        '//------------------------------------------
        '<TODO>�Ăяo�����N���X�̃C���X�^���X�쐬
        KEKESJAG00_C = CType(Context.Handler, KEKESJAG00)
        '//------------------------------------------
        '********************************************

        '********************************************
        '//------------------------------------------
        Dim intRow As Integer
        '// Select���̍쐬
        Dim SQLC As New KEKESJAG00CCSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder

        'MAX99�̐���--------------------------------------
        '���������͑��݂��Ȃ����߁A�S�ďo�͂��܂��B���W�b�N�͎c���܂�
        '//------------------------------------------
        '//MAX�����`�F�b�N
        Dim dbData As DataSet
        strSQL = New StringBuilder("")
        Call mMakeSQL(strSQL, SqlParamC, 1)
        dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)
        If Convert.ToInt32(dbData.Tables(0).Rows(0).Item("CNT")) > ConstC.pScrollMax Then
            strMsg.Append("alert('�ő�o�͌����𒴂��܂����B" & ConstC.pScrollMax & "���܂ŏo�͂��܂�');")
        End If
        'MAX99�̐���--------------------------------------

        '�ҏWTEMP�p
        Dim intTemp As Integer
        Dim strTemp1 As String
        Dim strTemp2 As String
        '// �f�[�^�̎擾
        strSQL = New StringBuilder("")
        Call mMakeSQL(strSQL, SqlParamC, 0)
        dbKeson = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

        '// �擾�f�[�^�̕ҏW���s��--------------------
        Dim DateFncC As New CDateFnc
        Dim TimeFncC As New CTimeFnc

        '�C�x���g�{�^���̃��b�N����
        strMsg.Append("parent.Form1.btnExit.disabled=false;")
        If Convert.ToString(dbKeson.Tables(0).Rows(0).Item(0)) = "XYZ" Then
            '//------------------------------------------
            '<TODO>�f�[�^�����݂��Ȃ��ꍇ�ɏo�͂���l���e�t�B�[���h�ɐݒ肷��
            dbKeson.Tables(0).Rows(0).Item("ROWNO") = "0"       'SPAN�L�[
            dbKeson.Tables(0).Rows(0).Item("KEY") = ""          'SPAN�L�[
            dbKeson.Tables(0).Rows(0).Item("FTPFILE") = ""      'SPAN�J���[
            dbKeson.Tables(0).Rows(0).Item("STATE") = ""
            dbKeson.Tables(0).Rows(0).Item("JOUKYOU") = ""
            dbKeson.Tables(0).Rows(0).Item("UPDDATE") = ""
            dbKeson.Tables(0).Rows(0).Item("UPDTIME") = ""

            strMsg.Append("parent.Form1.btnExit.focus();")
            strMsg.Append("parent.fncFo(parent.Form1.btnDelete, 5);")
            strMsg.Append("parent.Form1.btnDelete.disabled = true;")
            strMsg.Append("Form1.chkDel0.disabled = true;")

            hdnDataCnt.Value = "0"
        Else
            intTemp = 0
            strMsg.Append("parent.Form1.btnDelete.disabled = false;")
            For intRow = 0 To dbKeson.Tables(0).Rows.Count - 1
                intTemp += 1
                '//---------------------------------------
                '//�ŏI�X�V�����̕ҏW
                strTemp1 = Convert.ToString(dbKeson.Tables(0).Rows(intRow).Item("UPDDATE"))
                strTemp2 = strTemp1
                strTemp1 = strTemp1.Substring(0, 8)
                strTemp2 = strTemp2.Substring(8, 6)
                If IsNumeric(strTemp1) = True Then
                    strTemp1 = DateFncC.mGet(strTemp1)
                End If
                If IsNumeric(strTemp2) = True Then
                    strTemp2 = TimeFncC.mGet(strTemp2, 1)
                End If
                dbKeson.Tables(0).Rows(intRow).Item("UPDDATE") = strTemp1 & " " & strTemp2
                '//---------------------------------------
            Next
            hdnDataCnt.Value = CStr(intTemp)
        End If
        '// ���s�[�^�Ƀo�C���h����--------------------
        rptKesonData.DataBind()
        '//------------------------------------------
        '********************************************
    End Sub
    '******************************************************************************
    ' SQL�쐬
    '******************************************************************************
    '//------------------------------------------
    '<TODO>SELECT���̍쐬��SQL�p�����[�^�̃o�C���h
    Private Sub mMakeSQL(ByVal pstrSQL As StringBuilder, ByVal pSqlParamC As CSQLParam, ByVal pintkbn As Integer)

        pstrSQL.Append("SELECT ")
        If pintkbn = 0 Then
            '//�ꗗ�p�̍��ڂ��擾���܂�
            pstrSQL.Append("TO_CHAR(ROWNUM) AS ROWNO, ")
            pstrSQL.Append("FILE_NAME AS KEY, ")
            pstrSQL.Append("FILE_NAME AS FTPFILE, ")
            pstrSQL.Append("FILE_STATUS AS STATE, ")
            pstrSQL.Append("FILE_WAIT_MODE AS JOUKYOU, ")
            pstrSQL.Append("LAST_MODIFIED AS UPDDATE, ")
            pstrSQL.Append("'' AS UPDTIME ")
        Else
            '//�����J�E���g�p��SQL
            pstrSQL.Append("COUNT(*) AS CNT ")       '�J�E���g
        End If
        pstrSQL.Append("FROM ")
        pstrSQL.Append("T11_KEIHOFILE ")
        pstrSQL.Append("WHERE FILE_STATUS IN (1,2) ")

        'MAX99�̐���--------------------------------------
        '���������͑��݂��Ȃ����߁A�S�ďo�͂��܂��B���W�b�N�͎c���܂�
        If pintkbn = 0 Then
            pstrSQL.Append(" AND  ROWNUM <= " & ConstC.pScrollMax)
        End If
        'MAX99�̐���--------------------------------------

        pstrSQL.Append("ORDER BY FILE_NAME ")


    End Sub


End Class
