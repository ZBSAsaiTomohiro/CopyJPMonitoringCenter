Option Explicit On 
Option Strict On

Imports Common

Imports System.Text
Imports System.Text.RegularExpressions

'******************************************************************************
' �|�b�v�A�b�v (�ꗗ��)
'******************************************************************************
Public Class COPOPUFG00
    Inherits System.Web.UI.Page
    Protected WithEvents dbSet As System.Data.DataSet
    Protected WithEvents rptIframe As System.Web.UI.WebControls.Repeater
    Protected WithEvents lblScript As System.Web.UI.WebControls.Label

    Protected COPOPUPG00_C As COPOPUPG00

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
        COPOPUPG00_C = CType(Context.Handler, COPOPUPG00)
        '//------------------------------------------
        '********************************************

        '********************************************
        '//------------------------------------------
        '// Select���̍쐬
        Dim SQLC As New JPGCSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder
        Dim strDBFlg As String = ""

        '// �f�[�^�̎擾
        strSQL = New StringBuilder("")
        Select Case COPOPUPG00_C.pListCd
            Case "CLI"                      '�N���C�A���g�ꗗ��\��      ��DB�����N
                Call mMakeSQL_CLIMAS(strSQL, SqlParamC)
                dbSet = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)
            Case "JAJASS"                   '�i�`/�i�`�x���ꗗ��\��(�i�`/�i�`�x���`���ŏo��)
                Call mMakeSQL_JAJASS(strSQL, SqlParamC)
                dbSet = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)
            Case "JA"                       '�i�`�ꗗ��\��
                Call mMakeSQL_JA(strSQL, SqlParamC)
                dbSet = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)
            Case "JASS"                     '�i�`�x���ꗗ��\��
                Call mMakeSQL_JASS(strSQL, SqlParamC)
                dbSet = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)
            Case "KYO"                      '�����Z���^�[�ꗗ��\��
                Call mMakeSQL_KYO(strSQL, SqlParamC)
                dbSet = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)
            Case "KANSHI"                   '�Ď��Z���^�[�ꗗ��\��
                Call mMakeSQL_KANSHI(strSQL, SqlParamC)
                dbSet = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)
            Case "SYUTUDOU"                 '�o����Јꗗ��\��
                Call mMakeSQL_SYUTUDOU(strSQL, SqlParamC)
                dbSet = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)
            Case "PULLKBN"                  '�v���_�E���敪�ꗗ��\��
                Call mMakeSQL_PULLKBN(strSQL, SqlParamC)
                dbSet = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)
            Case "PULLCODE"                 '�v���_�E���R�[�h�ꗗ��\��
                Call mMakeSQL_PULLCODE(strSQL, SqlParamC)
                dbSet = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)
            Case "TKTANCD"                  '�Ď��Z���^�[�S���҈ꗗ��\��(�N���C�A���g�R�[�h���o��)
                Call mMakeSQL_TKTANCD(strSQL, SqlParamC)
                dbSet = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)
            Case "TKTANCDKN"                '�Ď��Z���^�[�S���҈ꗗ��\��(�Ď��Z���^�[�R�[�h���o��)
                Call mMakeSQL_TKTANCDKN(strSQL, SqlParamC)
                dbSet = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)
            Case Else                       ' �G���[�w��
                Call mMakeSQL_ELSE(strSQL, SqlParamC)
                dbSet = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)
                strDBFlg = "NODATA"
        End Select

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
        '********************************************

        '********************************************
        '//------------------------------------------
        '// �f�[�^�I����������JavaScript���s
        strMsg.Append("function fncPutData(strcd,strnm){")
        If strDBFlg = "" Then
            strMsg.Append("if(strcd==' '){strcd=='';}")
            strMsg.Append("if(strnm==' '){strnm=='';}")
            '// �R�[�h�f�[�^�̃Z�b�g
            If COPOPUPG00_C.pBackCode <> "" Then
                strMsg.Append("obj1=parent.opener.frames(""data"").document.getElementById(""" & COPOPUPG00_C.pBackCode & """);")
                strMsg.Append("if(obj1!=null) {")
                strMsg.Append("if(obj1.value!=strcd) {")
                If COPOPUPG00_C.pClear1.Length > 0 Then
                    strMsg.Append("obj4=parent.opener.frames(""data"").document.getElementById(""" & COPOPUPG00_C.pClear1 & """);")
                    strMsg.Append("obj4.value='';")
                End If
                If COPOPUPG00_C.pClear2.Length > 0 Then
                    strMsg.Append("obj5=parent.opener.frames(""data"").document.getElementById(""" & COPOPUPG00_C.pClear2 & """);")
                    strMsg.Append("obj5.value='';")
                End If
                If COPOPUPG00_C.pClear3.Length > 0 Then
                    strMsg.Append("obj6=parent.opener.frames(""data"").document.getElementById(""" & COPOPUPG00_C.pClear3 & """);")
                    strMsg.Append("obj6.value='';")
                End If
                If COPOPUPG00_C.pClear4.Length > 0 Then
                    strMsg.Append("obj7=parent.opener.frames(""data"").document.getElementById(""" & COPOPUPG00_C.pClear4 & """);")
                    strMsg.Append("obj7.value='';")
                End If
                strMsg.Append("}")
                strMsg.Append("}")
                strMsg.Append("obj1.value=strcd;")
            End If
            '// ���O�f�[�^�̃Z�b�g
            If COPOPUPG00_C.pBackName <> "" Then
                strMsg.Append("obj2=parent.opener.frames(""data"").document.getElementById(""" & COPOPUPG00_C.pBackName & """);")
                strMsg.Append("obj2.value=strnm;")
            End If
            '// �t�H�[�J�X�̃Z�b�g
            If COPOPUPG00_C.pBackFocs <> "" Then
                strMsg.Append("obj3=parent.opener.frames(""data"").document.getElementById(""" & COPOPUPG00_C.pBackFocs & """);")
                strMsg.Append("obj3.focus();")
            End If
            '// JavaScript�̎��s
            If COPOPUPG00_C.pBackScript <> "" Then
                strMsg.Append("parent.opener.frames(""data"")." & COPOPUPG00_C.pBackScript & "();")
            End If
            strMsg.Append("parent.window.close();")
        End If
        strMsg.Append("}")
        '//------------------------------------------
        '********************************************
    End Sub

    '******************************************************************************
    ' �N���C�A���g�ꗗ
    '******************************************************************************
    Private Sub mMakeSQL_CLIMAS(ByVal strSQL As StringBuilder, ByVal SqlParamC As CSQLParam)
        '�֘A����Ď��Z���^�[�̃N���C�A���g�R�[�h�̂ݏo�͂��邱��
        '�`�c�F�؂��ꂽ�u�g�p�\�Ď��Z���^�[�v�ɏ�������N���C�A���g���o��
        Dim i As Integer
        Dim arrTemp() As String
        Dim strCenter As String = ""
        arrTemp = COPOPUPG00_C.pCode1.Split(Convert.ToChar(","))
        For i = 0 To arrTemp.Length - 1
            If strCenter.Length > 0 Then
                strCenter = strCenter & ","
            End If
            strCenter = strCenter & "'" & arrTemp(i) & "'"
        Next
        strSQL.Append("SELECT ")
        strSQL.Append("' ' AS CODE, ")
        strSQL.Append("' ' AS NAME, ")
        strSQL.Append("' ' AS CDNM ")
        strSQL.Append("FROM ")
        strSQL.Append("DUAL ")
        strSQL.Append("UNION ALL ")
        strSQL.Append("SELECT ")
        strSQL.Append("CLI_CD AS CODE, ")
        strSQL.Append("CLI_NAME AS NAME, ")
        strSQL.Append("CLI_CD || ' : ' || CLI_NAME AS CDNM ")
        strSQL.Append("FROM CLIMAS ")
        If COPOPUPG00_C.pCode1.Length > 0 Then
            strSQL.Append("WHERE KANSI_CODE IN (" & strCenter & ") ")
        End If
        strSQL.Append("ORDER BY CODE ")
    End Sub

    '******************************************************************************
    ' �i�`/�i�`�x���ꗗ
    '******************************************************************************
    Private Sub mMakeSQL_JAJASS(ByVal strSQL As StringBuilder, ByVal SqlParamC As CSQLParam)
        strSQL.Append("SELECT ")
        strSQL.Append("' ' AS CODE, ")
        strSQL.Append("' ' AS NAME, ")
        strSQL.Append("' ' AS CDNM ")
        strSQL.Append("FROM ")
        strSQL.Append("DUAL ")
        strSQL.Append("UNION ALL ")
        strSQL.Append("SELECT ")
        strSQL.Append("HAN_CD AS CODE, ")
        strSQL.Append("JAS_NAME AS NAME, ")
        strSQL.Append("HAN_CD || ' : ' || JA_NAME || '/' || JAS_NAME AS CDNM ")
        strSQL.Append("FROM HN2MAS ")
        strSQL.Append("WHERE CLI_CD = :CLI_CD ")
        '''''���}�X�^�ɂ͂i�`�x���f�[�^�������݂��Ȃ�
        ''''strSQL.Append("  AND LENGTH(HAN_CD) = TO_NUMBER(HAN_KETA) + TO_NUMBER(JA_KETA) ")
        strSQL.Append("ORDER BY CODE ")

        SqlParamC.fncSetParam("CLI_CD", True, COPOPUPG00_C.pCode1)
    End Sub

    '******************************************************************************
    ' �i�`�ꗗ
    '******************************************************************************
    Private Sub mMakeSQL_JA(ByVal strSQL As StringBuilder, ByVal SqlParamC As CSQLParam)
        strSQL.Append("SELECT ")
        strSQL.Append("' ' AS CODE, ")
        strSQL.Append("' ' AS NAME, ")
        strSQL.Append("' ' AS CDNM ")
        strSQL.Append("FROM ")
        strSQL.Append("DUAL ")
        strSQL.Append("UNION ALL ")
        strSQL.Append("SELECT ")
        strSQL.Append("DISTINCT ")
        strSQL.Append("JA_CD AS CODE, ")
        strSQL.Append("JA_NAME AS NAME, ")
        strSQL.Append("JA_CD || ' : ' || JA_NAME  AS CDNM ")
        strSQL.Append("FROM HN2MAS ")
        strSQL.Append("WHERE CLI_CD = :CLI_CD ")
        strSQL.Append("  AND HAISO_CD = :HAISO_CD ")
        ''''DISTINCT�ɂĂi�`�̒��o�Ƃ���(�ȏ�̓}�X�^�������s��)
        ''''strSQL.Append("  AND LENGTH(HAN_CD) = TO_NUMBER(HAN_KETA) ")
        strSQL.Append("ORDER BY CODE ")

        SqlParamC.fncSetParam("CLI_CD", True, COPOPUPG00_C.pCode1)
        SqlParamC.fncSetParam("HAISO_CD", True, COPOPUPG00_C.pCode2)
    End Sub

    '******************************************************************************
    ' �i�`�x���ꗗ
    '******************************************************************************
    Private Sub mMakeSQL_JASS(ByVal strSQL As StringBuilder, ByVal SqlParamC As CSQLParam)
        strSQL.Append("SELECT ")
        strSQL.Append("' ' AS CODE, ")
        strSQL.Append("' ' AS NAME, ")
        strSQL.Append("' ' AS CDNM ")
        strSQL.Append("FROM ")
        strSQL.Append("DUAL ")
        strSQL.Append("UNION ALL ")
        strSQL.Append("SELECT ")
        strSQL.Append("HAN_CD AS CODE, ")
        strSQL.Append("JAS_NAME AS NAME, ")
        strSQL.Append("HAN_CD || ' : ' || JAS_NAME AS CDNM ")
        strSQL.Append("FROM HN2MAS ")
        strSQL.Append("WHERE CLI_CD = :CLI_CD ")
        If COPOPUPG00_C.pCode2.Length > 0 Then
            strSQL.Append("  AND JA_CD = :JA_CD ")
        End If
        '''''���}�X�^�ɂ͂i�`�x���f�[�^�������݂��Ȃ�
        ''''strSQL.Append("  AND LENGTH(HAN_CD) = TO_NUMBER(HAN_KETA) + TO_NUMBER(JA_KETA) ")
        strSQL.Append("ORDER BY CODE ")

        SqlParamC.fncSetParam("CLI_CD", True, COPOPUPG00_C.pCode1)
        If COPOPUPG00_C.pCode2.Length > 0 Then
            SqlParamC.fncSetParam("JA_CD", True, COPOPUPG00_C.pCode2)
        End If
    End Sub

    '******************************************************************************
    ' �����Z���^�[�ꗗ
    '******************************************************************************
    Private Sub mMakeSQL_KYO(ByVal strSQL As StringBuilder, ByVal SqlParamC As CSQLParam)
        strSQL.Append("SELECT ")
        strSQL.Append("' ' AS CODE, ")
        strSQL.Append("' ' AS NAME, ")
        strSQL.Append("' ' AS CDNM ")
        strSQL.Append("FROM ")
        strSQL.Append("DUAL ")
        strSQL.Append("UNION ALL ")
        strSQL.Append("SELECT ")
        strSQL.Append("HAISO_CD AS CODE, ")
        strSQL.Append("NAME AS NAME, ")
        strSQL.Append("HAISO_CD || ' : ' || NAME AS CDNM ")
        strSQL.Append("FROM HAIMAS ")
        strSQL.Append("WHERE KEN_CD = :KEN_CD ")
        strSQL.Append("ORDER BY CODE ")

        SqlParamC.fncSetParam("KEN_CD", True, COPOPUPG00_C.pCode1)
    End Sub

    '******************************************************************************
    ' �Ď��Z���^�[�ꗗ
    '******************************************************************************
    Private Sub mMakeSQL_KANSHI(ByVal strSQL As StringBuilder, ByVal SqlParamC As CSQLParam)
        '�֘A����Ď��Z���^�[�̃N���C�A���g�R�[�h�̂ݏo�͂��邱��
        '�`�c�F�؂��ꂽ�u�g�p�\�Ď��Z���^�[�v�̊Ď��Z���^�[���o��
        Dim i As Integer
        Dim arrTemp() As String
        Dim strCenter As String = ""
        arrTemp = COPOPUPG00_C.pCode1.Split(Convert.ToChar(","))
        For i = 0 To arrTemp.Length - 1
            If strCenter.Length > 0 Then
                strCenter = strCenter & ","
            End If
            strCenter = strCenter & "'" & arrTemp(i) & "'"
        Next

        strSQL.Append("SELECT ")
        strSQL.Append("' ' AS CODE, ")
        strSQL.Append("' ' AS NAME, ")
        strSQL.Append("' ' AS CDNM ")
        strSQL.Append("FROM ")
        strSQL.Append("DUAL ")
        strSQL.Append("UNION ALL ")
        strSQL.Append("SELECT ")
        strSQL.Append("KANSI_CD AS CODE, ")
        strSQL.Append("KANSI_NAME AS NAME, ")
        strSQL.Append("KANSI_CD || ' : ' || KANSI_NAME AS CDNM ")
        strSQL.Append("FROM KANSIMAS ")
        If arrTemp.Length = 0 Then
            strSQL.Append("WHERE KANSI_CD = '' ")
        Else
            strSQL.Append("WHERE KANSI_CD IN (" & strCenter & ") ")
        End If
        strSQL.Append("ORDER BY CODE ")

    End Sub

    '******************************************************************************
    ' �o����Јꗗ
    '******************************************************************************
    Private Sub mMakeSQL_SYUTUDOU(ByVal strSQL As StringBuilder, ByVal SqlParamC As CSQLParam)
        strSQL.Append("SELECT ")
        strSQL.Append("' ' AS CODE, ")
        strSQL.Append("' ' AS NAME, ")
        strSQL.Append("' ' AS CDNM ")
        strSQL.Append("FROM ")
        strSQL.Append("DUAL ")
        strSQL.Append("UNION ALL ")
        strSQL.Append("SELECT ")
        strSQL.Append("SHUTU_CD AS CODE, ")
        strSQL.Append("KAISYA_NAME AS NAME, ")
        strSQL.Append("SHUTU_CD || ' : ' || KAISYA_NAME AS CDNM ")
        strSQL.Append("FROM SHUTUDOMAS ")
        strSQL.Append("WHERE KUBUN = :KUBUN ")

        SqlParamC.fncSetParam("KUBUN", True, "1")
    End Sub

    '******************************************************************************
    ' �v���_�E���敪���ꗗ
    '******************************************************************************
    Private Sub mMakeSQL_PULLKBN(ByVal strSQL As StringBuilder, ByVal SqlParamC As CSQLParam)
        strSQL.Append("SELECT ")
        strSQL.Append("' ' AS CODE, ")
        strSQL.Append("' ' AS NAME, ")
        strSQL.Append("' ' AS CDNM ")
        strSQL.Append("FROM ")
        strSQL.Append("DUAL ")
        strSQL.Append("UNION ALL ")
        strSQL.Append("SELECT ")
        strSQL.Append("CD AS CODE, ")
        strSQL.Append("NAME AS NAME, ")
        strSQL.Append("NAME AS CDNM ")          '�v���_�E���}�X�^�ɂĎg�p����B�R���{�n�ł͂Ȃ����͕⏕�|�b�v�n
        strSQL.Append("FROM ")
        strSQL.Append("M06_PULLDOWN ")
        strSQL.Append("WHERE KBN = '00' ")
        If COPOPUPG00_C.pCode1.Length > 0 Then
            strSQL.Append("  AND CD LIKE :CD || '%' ")
        End If
        strSQL.Append("ORDER BY CODE ")

        If COPOPUPG00_C.pCode1.Length > 0 Then
            SqlParamC.fncSetParam("CD", True, COPOPUPG00_C.pCode1)
        End If
    End Sub

    '******************************************************************************
    ' �v���_�E���R�[�h�ꗗ
    '******************************************************************************
    Private Sub mMakeSQL_PULLCODE(ByVal strSQL As StringBuilder, ByVal SqlParamC As CSQLParam)
        strSQL.Append("SELECT ")
        strSQL.Append("' ' AS CODE, ")
        strSQL.Append("' ' AS NAME, ")
        strSQL.Append("' ' AS CDNM, ")
        strSQL.Append("' ' AS JUNJO ")
        strSQL.Append("FROM ")
        strSQL.Append("DUAL ")
        strSQL.Append("UNION ALL ")
        strSQL.Append("SELECT ")
        strSQL.Append("CD AS CODE, ")
        strSQL.Append("NAME AS NAME, ")
        strSQL.Append("NAME AS CDNM, ")          '�v���_�E���}�X�^�ɂĎg�p����B�R���{�n�ł͂Ȃ����͕⏕�|�b�v�n
        strSQL.Append("TO_CHAR(DISP_NO) AS JUNJO ")
        strSQL.Append("FROM ")
        strSQL.Append("M06_PULLDOWN ")

        If (COPOPUPG00_C.pCode1.Length > 0) Or (COPOPUPG00_C.pCode2.Length > 0) Then
            strSQL.Append("WHERE ")
        End If
        If COPOPUPG00_C.pCode1.Length > 0 Then
            strSQL.Append(" KBN = :KBN ")
            If COPOPUPG00_C.pCode2.Length > 0 Then
                strSQL.Append(" AND ")
            End If
        End If
        If COPOPUPG00_C.pCode2.Length > 0 Then
            strSQL.Append(" CD LIKE :CD || '%' ")
        End If

        strSQL.Append("ORDER BY JUNJO ")

        If COPOPUPG00_C.pCode1.Length > 0 Then
            SqlParamC.fncSetParam("KBN", True, COPOPUPG00_C.pCode1)
        End If
        If COPOPUPG00_C.pCode2.Length > 0 Then
            SqlParamC.fncSetParam("CD", True, COPOPUPG00_C.pCode2)
        End If
    End Sub

    '******************************************************************************
    ' �Ď��Z���^�[�S���҈ꗗ
    '******************************************************************************
    Private Sub mMakeSQL_TKTANCD(ByVal strSQL As StringBuilder, ByVal SqlParamC As CSQLParam)
        strSQL.Append("SELECT ")
        strSQL.Append("' ' AS CODE, ")
        strSQL.Append("' ' AS NAME, ")
        strSQL.Append("' ' AS CDNM ")
        strSQL.Append("FROM ")
        strSQL.Append("DUAL ")
        strSQL.Append("UNION ALL ")
        strSQL.Append("SELECT ")
        strSQL.Append("TN.TANCD AS CODE, ")
        strSQL.Append("TN.TANNM AS NAME, ")
        strSQL.Append("TN.TANCD || ' : ' || TN.TANNM  AS CDNM ")
        strSQL.Append("FROM CLIMAS CL, ")
        strSQL.Append("     M05_TANTO TN ")
        strSQL.Append("WHERE CL.CLI_CD = :CLI_CD ")
        strSQL.Append("  AND TN.KBN = '1' ")
        strSQL.Append("  AND TN.KURACD = 'ZZZZ' ")
        strSQL.Append("  AND TN.CODE = CL.KANSI_CODE ")
        '�Ď��Z���^�[�R�[�h�����w��̏ꍇ�͋�ƂȂ�
        strSQL.Append("ORDER BY CODE ")

        '�N���C�A���g�R�[�h�̐ݒ�
        SqlParamC.fncSetParam("CLI_CD", True, COPOPUPG00_C.pCode1)
    End Sub

    '******************************************************************************
    ' �Ď��Z���^�[�S���҈ꗗ�i�Ď��Z���^�[�R�[�h���o�́j
    '******************************************************************************
    Private Sub mMakeSQL_TKTANCDKN(ByVal strSQL As StringBuilder, ByVal SqlParamC As CSQLParam)
        '�֘A����Ď��Z���^�[�̃N���C�A���g�R�[�h�̂ݏo�͂��邱��
        '�`�c�F�؂��ꂽ�u�g�p�\�Ď��Z���^�[�v�̊Ď��Z���^�[���o��
        Dim i As Integer
        Dim arrTemp() As String
        Dim strCenter As String = ""
        arrTemp = COPOPUPG00_C.pCode1.Split(Convert.ToChar(","))
        For i = 0 To arrTemp.Length - 1
            If strCenter.Length > 0 Then
                strCenter = strCenter & ","
            End If
            strCenter = strCenter & "'" & arrTemp(i) & "'"
        Next

        strSQL.Append("SELECT ")
        strSQL.Append("' ' AS CODE, ")
        strSQL.Append("' ' AS NAME, ")
        strSQL.Append("' ' AS CDNM ")
        strSQL.Append("FROM ")
        strSQL.Append("DUAL ")
        strSQL.Append("UNION ALL ")
        strSQL.Append("SELECT ")
        strSQL.Append("TN.TANCD AS CODE, ")
        strSQL.Append("TN.TANNM AS NAME, ")
        strSQL.Append("TN.TANCD || ' : ' || TN.TANNM  AS CDNM ")
        strSQL.Append("FROM M05_TANTO TN ")
        strSQL.Append("WHERE TN.KBN = '1' ")
        strSQL.Append("  AND TN.KURACD = 'ZZZZ' ")
        '�Ď��Z���^�[�R�[�h�����w��̏ꍇ�͋�ƂȂ�
        If strCenter.Length = 0 Then
            strSQL.Append("  AND TN.CODE = '' ")
        Else
            strSQL.Append("  AND TN.CODE IN (" & strCenter & ") ")
        End If
        strSQL.Append("ORDER BY CODE ")
    End Sub


    '******************************************************************************
    ' ���̑�
    '******************************************************************************
    Private Sub mMakeSQL_ELSE(ByVal strSQL As StringBuilder, ByVal SqlParamC As CSQLParam)
        strSQL.Append("SELECT ")
        strSQL.Append("'' AS CODE,")
        strSQL.Append("'�\���f�[�^�w�����Ԉ���Ă��܂�' AS CDNM, ")
        strSQL.Append("'�\���f�[�^�w�����Ԉ���Ă��܂�' AS NAME ")
        strSQL.Append("FROM ")
        strSQL.Append("DUAL ")
    End Sub
End Class
