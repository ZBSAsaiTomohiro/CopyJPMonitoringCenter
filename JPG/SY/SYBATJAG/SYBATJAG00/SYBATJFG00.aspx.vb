'***********************************************
'�o�b�`���s�����ꗗ  �ꗗ���
'***********************************************
Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common
Imports JPG.Common.log
Imports System.Text

Partial Class SYBATJFG00
    Inherits System.Web.UI.Page
    Protected WithEvents dbData As System.Data.DataSet

    Protected SYBATJAG00_C As SYBATJAG00
    Protected ConstC As New CConst

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
        Me.dbData = New System.Data.DataSet
        CType(Me.dbData, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'dbData
        '
        Me.dbData.DataSetName = "NewDataSet"
        Me.dbData.Locale = New System.Globalization.CultureInfo("ja-JP")
        CType(Me.dbData, System.ComponentModel.ISupportInitialize).EndInit()

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
    '*�@�T�@�v�F
    '*�@���@�l�F
    '******************************************************************************
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '//------------------------------------------
        '//�@HTTP�w�b�_�𑗐M
        HttpHeaderC.mNoCache(Response)

        '//------------------------------------------
        '//�@�F�؃N���X�̃C���X�^���X����
        AuthC = New CAuthenticate(Request, Response)

        '//------------------------------------------
        '//�@�F�؏���
        '<TODO>�F�g�p�\�������w�肷��
        '[�o�b�`���s�����ꗗ]�g�p�\����(�^:��/�c:�~/��:��/�o:�~)
        AuthC.fncAuthCheck(Server, AuthC.pGROUP_UNKOU & "," & AuthC.pGROUP_KANSHI)

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
        SYBATJAG00_C = CType(Context.Handler, SYBATJAG00)
        '//------------------------------------------
        '********************************************

        '********************************************

        '//-------------------------------------------------
        '<TODO>�����̉��ID��HIDDEN��hdnMyAspx�ɏ������ށi�V�X�e�����ʁj
        hdnMyAspx.Value = "SYBATJAG00"
        '//-------------------------------------------------

        '<TODO>��ʃI�u�W�F�N�g���g�p�\�ɂ���
        strMsg.Append("parent.Form1.btnSelect.disabled=false;")
        strMsg.Append("parent.Form1.btnExit.disabled=false;")

        Dim strRec As String = ""

        Try
            '//------------------------------------------
            Dim SQLC As New SYBATJAG00CCSQL.CSQL
            Dim SqlParamC As New CSQLParam
            Dim strSQL As New StringBuilder

            '//------------------------------------------
            '//MAX�����`�F�b�N
            Dim intCount As Integer

            If SYBATJAG00_C.pSelectClick = "1" Then
                Dim dbCnt As DataSet
                strSQL = New StringBuilder("")
                '�����{�^����������Ă���ꍇ�̂݌����`�F�b�N���s��
                Call mMakeSQL(strSQL, SqlParamC, 1, 0)
                dbCnt = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)
                intCount = Convert.ToInt32(dbCnt.Tables(0).Rows(0).Item("CNT"))
                dbCnt.Dispose()
            Else
                '�����{�^����������Ă��Ȃ��ꍇ�͌����������s��Ȃ�[�ꗗ�\�����s��Ȃ�]
                intCount = 0
            End If

            '//------------------------------------------
            '// �f�[�^�̎擾
            strSQL = New StringBuilder("")
            Call mMakeSQL(strSQL, SqlParamC, 0, intCount)
            dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

            '//�擾�f�[�^�̕ҏW���s��-----------------------------
            Dim intRow As Integer

            If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
                If SYBATJAG00_C.pSelectClick = "1" Then
                    '//�����{�^�������ɂ��f�[�^�O��
                    strMsg.Append("alert('�Ώۃf�[�^�����݂��܂���');")
                    strRec = "�f�[�^�����݂��܂���"
                End If

                dbData.Tables(0).Rows(0).Item("ROWNO") = ""
                dbData.Tables(0).Rows(0).Item("PROC_ID") = ""           '�v���W�F�N�g�h�c
                dbData.Tables(0).Rows(0).Item("ST_YMD") = ""            '�J�n���t
                dbData.Tables(0).Rows(0).Item("ST_TIME") = ""           '�J�n����
                dbData.Tables(0).Rows(0).Item("ED_YMD") = ""            '�I�����t
                dbData.Tables(0).Rows(0).Item("ED_TIME") = ""           '�I������
                dbData.Tables(0).Rows(0).Item("PROJ_STATUS_CD") = ""       '
                dbData.Tables(0).Rows(0).Item("PROJ_STATUS") = ""       '�v���W�F�N�g���s����
                dbData.Tables(0).Rows(0).Item("EXEC_STATUS_CD") = ""
                dbData.Tables(0).Rows(0).Item("EXEC_STATUS") = ""       '������
                dbData.Tables(0).Rows(0).Item("MSG") = ""               '���b�Z�[�W

            Else

                Dim strTemp As String
                Dim EscapeC As New CEscape

                For intRow = 0 To dbData.Tables(0).Rows.Count - 1
                    dbData.Tables(0).Rows(intRow).Item("ROWNO") = _
                       EscapeC.mDb_Js(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("ROWNO")))
                    '//������
                    strTemp = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("PROC_ID"))
                    Select Case strTemp
                        Case "BTGETJAE00"
                            dbData.Tables(0).Rows(intRow).Item("PROC_ID") = "�����f�[�^����"
                            'Case "BTFAXJAE00"�@2013/12/06 T.Ono del �Ď����P2013
                            '    dbData.Tables(0).Rows(intRow).Item("PROC_ID") = "�����e�`�w"
                            'Case "SYHANJAE00"�@2013/12/06 T.Ono del �Ď����P2013
                            'dbData.Tables(0).Rows(intRow).Item("PROC_ID") = "�̔��A��������"
                        Case "BTLTSJAE00"
                            'dbData.Tables(0).Rows(intRow).Item("PROC_ID") = "�����k�s�n�r�A��"�@2013/12/06 T.Ono mod �Ď����P2013
                            dbData.Tables(0).Rows(intRow).Item("PROC_ID") = "�i�`�|�k�s�n�r�A��"
                        Case "BTFAXJCE00"
                            dbData.Tables(0).Rows(intRow).Item("PROC_ID") = "�����e�`�w2013"
                        Case "BTFAXJDE00"
                            dbData.Tables(0).Rows(intRow).Item("PROC_ID") = "�����e�`�w2014" '2015/03/10 T.Ono add 2014���P�J��
                    End Select

                    '//�J�n���t
                    strTemp = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("ST_YMD"))
                    If IsNumeric(strTemp) = True Then
                        dbData.Tables(0).Rows(intRow).Item("ST_YMD") = SYBATJAG00_C.fncDateSet(strTemp)
                    End If
                    '//�J�n����
                    strTemp = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("ST_TIME"))
                    If IsNumeric(strTemp) = True Then
                        dbData.Tables(0).Rows(intRow).Item("ST_TIME") = SYBATJAG00_C.fncTimeSet(strTemp, 1)
                    End If
                    dbData.Tables(0).Rows(intRow).Item("ST_YMD") = _
                                Convert.ToString(dbData.Tables(0).Rows(intRow).Item("ST_YMD")) & " " & _
                                Convert.ToString(dbData.Tables(0).Rows(intRow).Item("ST_TIME"))

                    '//�I�����t
                    strTemp = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("ED_YMD"))
                    If IsNumeric(strTemp) = True Then
                        dbData.Tables(0).Rows(intRow).Item("ED_YMD") = SYBATJAG00_C.fncDateSet(strTemp)
                    End If
                    '//�I������
                    strTemp = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("ED_TIME"))
                    If IsNumeric(strTemp) = True Then
                        dbData.Tables(0).Rows(intRow).Item("ED_TIME") = SYBATJAG00_C.fncTimeSet(strTemp, 1)
                    End If
                    dbData.Tables(0).Rows(intRow).Item("ED_YMD") = _
                                Convert.ToString(dbData.Tables(0).Rows(intRow).Item("ED_YMD")) & " " & _
                                Convert.ToString(dbData.Tables(0).Rows(intRow).Item("ED_TIME"))
                    '���s����
                    strTemp = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("PROJ_STATUS"))
                    If strTemp = "1" Then
                        dbData.Tables(0).Rows(intRow).Item("EXEC_STATUS") = ""
                    End If

                Next
            End If

            '���s�[�^�Ƀo�C���h����-----------------------------
            rptData.DataBind()
            '********************************************
            If SYBATJAG00_C.pSelectClick = "1" Then
                If strRec.Length = 0 Then       '[�f�[�^�����݂��܂���]�̃��b�Z�[�W���o��
                    strRec = "OK"
                End If
            End If
        Catch ex As Exception
            ''strRec = "�o�͏����ɂăG���[���������܂���"   '//ORACLE-MESSAGE���Ƒ傫������׃��b�Z�[�W�w��
            strRec = ex.ToString
            Dim ErrMsgC As New CErrMsg
            strMsg.Append("alert('�V�X�e���G���[�F" & errmsgc.mGetArtMsg(strRec) & "');")

        End Try

        If SYBATJAG00_C.pSelectClick = "1" Then
            '//�����{�^�������ɂ���ʏo�͂̏ꍇ�͌����{�^���Ƀt�H�[�J�X�Z�b�g
            '//�����o�͎��͐e��ʂł̐���ɔC����
            '<TODO>������̃t�H�[�J�X���Z�b�g����
            strMsg.Append("parent.Form1.btnSelect.focus();")

            '-------------------------------------------------
            '//�`�o���O��������
            Dim LogC As New CLog
            Dim strRecLog As String
            '2012/04/04 NEC ou Upd Str
            'strRecLog = LogC.mAPLog(Request.Cookies.Get("ASP.NET_SessionId").Value, AuthC.pUSERNAME, AuthC.pIPADDRESS, hdnMyAspx.Value, "4", strRec, Request.Form)
            strRecLog = LogC.mAPLog(Me.Session.SessionID, AuthC.pUSERNAME, AuthC.pIPADDRESS, hdnMyAspx.Value, "4", strRec, Request.Form)
            '2012/04/04 NEC ou Upd End
            If strRecLog <> "OK" Then
                Dim errmsgc As New CErrMsg
                strMsg.Append("alert('�V�X�e���G���[�F" & errmsgc.mGetArtMsg(strRecLog) & "');")
            End If
        End If

    End Sub

    '******************************************************************************
    '*�@�T�@�v�F
    '*�@���@�l�F
    '******************************************************************************
    Private Sub mMakeSQL(ByVal strSQL As StringBuilder, ByVal SqlParamC As CSQLParam, ByVal intkbn As Integer, ByVal intCount As Integer)

        '2013/12/09 T.Ono add �Ď����P2013
        If intkbn = 0 Then
            If intCount > 0 Then
                'strSQL.Append("SELECT LPAD(ROWNUM,4,0) AS NO, A.* ")
                strSQL.Append("SELECT ")
                strSQL.Append("A.* ")
                strSQL.Append(",ROWNUM AS NO ")
                strSQL.Append("FROM (")
            Else
                strSQL.Append("SELECT ")
                strSQL.Append("A.* ")
                strSQL.Append(",'' AS NO ")
                strSQL.Append("FROM (")
            End If
        End If


        strSQL.Append("SELECT ")
        If intkbn = 0 Then
            If intCount > 0 Then
                strSQL.Append("LPAD(ROWNUM,3,0) AS ROWNO, ")
                strSQL.Append("BA.PROC_ID, ")
                strSQL.Append("BA.ST_YMD, ")
                strSQL.Append("BA.ST_TIME, ")
                strSQL.Append("BA.ED_YMD, ")
                strSQL.Append("BA.ED_TIME, ")
                strSQL.Append("BA.PROJ_STATUS AS PROJ_STATUS_CD, ")
                strSQL.Append("P33.NAME AS PROJ_STATUS, ")
                strSQL.Append("BA.EXEC_STATUS AS EXEC_STATUS_CD, ")
                strSQL.Append("P34.NAME AS EXEC_STATUS, ")
                strSQL.Append("BA.MSG ")
                strSQL.Append("FROM S02_BACHDB BA,  ")
                strSQL.Append("     M06_PULLDOWN P33, ")
                strSQL.Append("     M06_PULLDOWN P34 ")
            Else
                strSQL.Append("'XYZ' AS ROWNO, ")
                strSQL.Append("'' AS PROC_ID, ")
                strSQL.Append("'' AS ST_YMD, ")
                strSQL.Append("'' AS ST_TIME, ")
                strSQL.Append("'' AS ED_YMD, ")
                strSQL.Append("'' AS ED_TIME, ")
                strSQL.Append("'' AS PROJ_STATUS_CD, ")
                strSQL.Append("'' AS PROJ_STATUS, ")
                strSQL.Append("'' AS EXEC_STATUS_CD, ")
                strSQL.Append("'' AS EXEC_STATUS, ")
                strSQL.Append("'' AS MSG ")
                strSQL.Append("FROM DUAL ")
                strSQL.Append(") A") '2013/12/09 add T.Ono �Ď����P2013
                Exit Sub
            End If
        Else
            '//�����J�E���g�p��SQL
            strSQL.Append("COUNT(*) AS CNT ")       '�J�E���g
            strSQL.Append("FROM S02_BACHDB BA ")
        End If

        If intkbn = 0 Then
            strSQL.Append("  WHERE ROWNUM <= " & ConstC.pScrollMax)
        Else
            strSQL.Append("  WHERE ROWNUM <= " & ConstC.pScrollMax + 1)
        End If

        '�Ώۓ��tFrom�`To
        strSQL.Append("  AND (BA.ADD_DATE BETWEEN :TRGDATE_F AND :TRGDATE_T) ")

        '�v���W�F�N�g�h�c
        If SYBATJAG00_C.pPROC_ID.Length > 0 Then
            strSQL.Append("  AND BA.PROC_ID = :PROC_ID ")
        End If

        '���
        If SYBATJAG00_C.pKbn = "2" Then         '����
            strSQL.Append("  AND (BA.PROJ_STATUS = '0' AND BA.EXEC_STATUS = '1') ")
        ElseIf SYBATJAG00_C.pKbn = "3" Then     '�ُ�
            strSQL.Append("  AND (BA.PROJ_STATUS = '1' AND BA.EXEC_STATUS = '0') ")
        Else                                    '�S��

        End If

        If intkbn = 0 Then
            strSQL.Append("  AND P33.KBN = '33' ")
            strSQL.Append("  AND P33.CD  = BA.PROJ_STATUS ")
            strSQL.Append("  AND P34.KBN = '34' ")
            strSQL.Append("  AND P34.CD  = BA.EXEC_STATUS ")
            strSQL.Append("ORDER BY ST_YMD DESC,ST_TIME DESC ")
            strSQL.Append(") A") '2013/12/09 add T.Ono �Ď����P2013
        End If

        '�p�����[�^�̃Z�b�g
        '�u�S�āv�ɑΉ� IF���ǉ��@2013/12/06 T.Ono mod �Ď����P2013
        If SYBATJAG00_C.pPROC_ID.Length > 0 Then
            SqlParamC.fncSetParam("PROC_ID", True, SYBATJAG00_C.pPROC_ID)
        End If
        SqlParamC.fncSetParam("TRGDATE_T", True, SYBATJAG00_C.pTRGDATE_T)
        SqlParamC.fncSetParam("TRGDATE_F", True, SYBATJAG00_C.pTRGDATE_F)

    End Sub
End Class