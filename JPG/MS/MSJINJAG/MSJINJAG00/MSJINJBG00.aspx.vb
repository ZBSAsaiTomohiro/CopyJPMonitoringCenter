Option Explicit On
Option Strict On

Imports Common

Imports System.Text
Imports System.Text.RegularExpressions

'******************************************************************************
' �|�b�v�A�b�v (�ꗗ��)
'******************************************************************************
' �ύX����
' 2008/10/29 T.Watabe HN2MAS����ꗗ�쐬����SQL�́ADEL_FLG=1��ΏۊO�Ƃ���悤�ɕύX

Partial Class MSJINJBG00
    Inherits System.Web.UI.Page
    Protected WithEvents dbSet As System.Data.DataSet

    Protected MSJINJCG00_C As MSJINJCG00

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
        Me.dbSet = New System.Data.DataSet
        CType(Me.dbSet, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'dbSet
        '
        Me.dbSet.DataSetName = "NewDataSet"
        Me.dbSet.Locale = New System.Globalization.CultureInfo("ja-JP")
        CType(Me.dbSet, System.ComponentModel.ISupportInitialize).EndInit()

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
        '------------------------------------------------------------------------------
        '<TODO>HTML���ɕK�v��JavaScript/CSS�͂�����[strScript]�ϐ��Ɋi�[��
        '      ��ʏ�[lblScript]�ɏ������݂��s���܂�(SPAN�^�O�Ƃ��ăN���C�A���g�ɃX�N���v�g��
        '      �o�͂���܂��B)
        '//------------------------------------------
        '//�@JavaScript�i�[
        strScript.Append("<Script language=javascript>")
        '<�Ǝ��X�N���v�g>
        strScript.Append(cscript1.mWriteScript( _
             MyBase.MapPath("../../../MS/MSJINJAG/MSJINJAG00/") & "MSJINJCG00.js"))
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
        '// �Ăяo�����N���X�̃C���X�^���X�쐬
        MSJINJCG00_C = CType(Context.Handler, MSJINJCG00)
        '//------------------------------------------
        '********************************************

        '********************************************
        '//------------------------------------------
        '// Select���̍쐬
        Dim SQLC As New MSJINJAG00CCSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder
        Dim strDBFlg As String = ""

        '// �f�[�^�̎擾
        Call mMakeSQL_PULLCODE(strSQL)
        dbSet = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

        '// �擾�f�[�^�̕ҏW���s��--------------------
        Dim DateFncC As New CDateFnc
        If Convert.ToString(dbSet.Tables(0).Rows(0).Item(0)) = "XYZ" Then
            dbSet.Tables(0).Rows(0).Item("CODE") = ""
            dbSet.Tables(0).Rows(0).Item("NAME") = ""
            strDBFlg = "NODATA"
        End If
        '// ���s�[�^�Ƀo�C���h����--------------------
        rptIframe.DataBind()
        '//------------------------------------------
    End Sub

    '******************************************************************************
    ' �v���_�E���R�[�h�ꗗ
    '******************************************************************************
    Private Sub mMakeSQL_PULLCODE(ByVal strSQL As StringBuilder)
        strSQL.Append("SELECT ")
        strSQL.Append("' ' AS CODE, ")
        strSQL.Append("' ' AS NAME, ")
        strSQL.Append("' ' AS CDNM, ")
        strSQL.Append("0 AS JUNJO, ")
        strSQL.Append("' ' AS CODE2, ")
        strSQL.Append("' ' AS CDNM2 ")
        strSQL.Append("FROM ")
        strSQL.Append("DUAL ")
        strSQL.Append("UNION ALL ")
        strSQL.Append("SELECT ")
        strSQL.Append("CD AS CODE, ")
        strSQL.Append("NAME AS NAME, ")
        strSQL.Append("NAME AS CDNM, ")
        strSQL.Append("TO_NUMBER(NVL(DISP_NO,9999)) AS JUNJO, ")
        strSQL.Append("' ' AS CODE2, ")
        strSQL.Append("' ' AS CDNM2 ")
        strSQL.Append("FROM ")
        strSQL.Append("M06_PULLDOWN ")
        strSQL.Append("WHERE ")
        strSQL.Append(" KBN = '70' ")
        strSQL.Append("ORDER BY JUNJO,CODE ")

    End Sub

End Class
