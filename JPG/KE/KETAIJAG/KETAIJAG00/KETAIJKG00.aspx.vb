'***********************************************
'�Ή������ꗗ�@�f�[�^����
'***********************************************
Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common.log
Imports JPG.Common

Imports System.Text
Imports System.IO

Partial Class KETAIJKG00
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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '//------------------------------------------
        '//�@HTTP�w�b�_�𑗐M
        HttpHeaderC.mNoCache(Response)

        '//------------------------------------------
        '//�@�F�؃N���X�̃C���X�^���X����
        AuthC = New CAuthenticate(Request, Response)

        '//------------------------------------------
        '// �f�[�^�̏o��
        Select Case Request.Form("hdnKensaku")
            Case "KETAIJKG00_KEN"
                Call fncGetData_KEN()
            Case "KETAIJKG00_REN"
                Call fncGetData_REN()
            Case "KETAIJKG00_REN_AND_HANGRP" '2014/12/19 T.Ono add 2014���P�J�� No2
                Call fncGetData_REN()
                Call fncGetData_HANGRP()
            Case "KETAIJKG00_TKN"
                Call fncGetData_TIME("KETAIJKG00_TKN")
            Case "KETAIJKG00_SSJ"
                Call fncGetData_TIME("KETAIJKG00_SSJ")
            Case "SEARCHTEL"
                Call fncGetData_CUS()
            Case "KETAIJKG00_ROC_btnTelHas1" '2017/10/18 H.Mori add 2017���P�J�� No4-3
                Call fncGetRoc_USER("KETAIJKG00_ROC_btnTelHas1")
            Case "KETAIJKG00_ROC_btnTelHas2" '2017/10/18 H.Mori add 2017���P�J�� No4-3
                Call fncGetRoc_USER("KETAIJKG00_ROC_btnTelHas2")
            Case "KETAIJKG00_ROC_btnRenraku" '2017/10/18 H.Mori add 2017���P�J�� No4-3
                Call fncGetRoc_USER("KETAIJKG00_ROC_btnRenraku")
            Case "KETAIJKG00_ROC_btnTKTANCD" '2017/10/18 H.Mori add 2017���P�J�� No4-3
                Call fncGetRoc_USER("KETAIJKG00_ROC_btnTKTANCD")
        End Select

        '//------------------------------------------
        '// �t���[�����[�N����ɂ���
        strMsg.Append("location.replace('about:blank');")

    End Sub

    '******************************************************************************
    ' �@�N���C�A���g�R�[�h��茧�����擾����
    '******************************************************************************
    Private Function fncGetData_KEN() As String
        Dim SQLC As New KETAIJAG00CSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet

        Dim KETAIJAG00C As KETAIJAG00
        KETAIJAG00C = CType(Context.Handler, KETAIJAG00)

        Dim intRow As Integer
        Dim strRec As String

        strRec = "OK"
        Try
            '//�o����Џ��̎擾
            strSQL = New StringBuilder("")
            strSQL.Append("SELECT  ")
            strSQL.Append("CL.KANSI_CODE, ")
            strSQL.Append("CL.KEN_NAME ")
            strSQL.Append("FROM CLIMAS CL ")
            strSQL.Append("WHERE CL.CLI_CD = :CLSI_CD ")

            '�p�����[�^�̃Z�b�g
            SqlParamC.fncSetParam("CLSI_CD", True, KETAIJAG00C.pPRAM_CLI)

            '//SQL�̎��s
            dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

            If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
            Else
                '//�f�[�^���o�͂��܂�
                strMsg.Append("parent.Data.Form1.hdnKANSCD.value='" & Convert.ToString(dbData.Tables(0).Rows(0).Item("KANSI_CODE")) & "';")
                strMsg.Append("parent.Data.Form1.txtKENNM.value='" & Convert.ToString(dbData.Tables(0).Rows(0).Item("KEN_NAME")) & "';")
            End If

            '������ 2013/06/25 T.Ono add ���ӎ����i�N���C�A���g�j���擾 ������
            strSQL = New StringBuilder("")
            '2016/02/02 w.ganeko 2015�Ď����P ��2 start
            'strSQL.Append("SELECT  ")
            'strSQL.Append("  M05.GUIDELINE AS GUIDELINE_CL ")
            'strSQL.Append("FROM  M05_TANTO M05  ")
            'strSQL.Append("WHERE M05.KBN   = '3'  ")
            'strSQL.Append("  AND M05.TANCD = '01'  ")
            'strSQL.Append("  AND TRIM(M05.GUIDELINE) IS NOT NULL  ")
            'strSQL.Append("  AND M05.KURACD = :CLSI_CD  ")
            'strSQL.Append("  AND M05.CODE   = 'XXXX' ")
            strSQL.Append("SELECT  D.GUIDELINE AS GUIDELINE_CL ")
            strSQL.Append(",D.GUIDELINE2 AS GUIDELINE_CL2 ")   ' 2019/11/01 W.GANEKO add 2019�Ď����P
            strSQL.Append(",D.GUIDELINE3 AS GUIDELINE_CL3 ")   ' 2019/11/01 W.GANEKO add 2019�Ď����P
            strSQL.Append(",NVL(D.GUIDELINENM1, '�N���C�A���g1') AS GUIDELINENM_CL1 ")   ' 2020/10/15 T.Ono add 2020�Ď����P
            strSQL.Append(",NVL(D.GUIDELINENM2, '�N���C�A���g2') AS GUIDELINENM_CL2 ")   ' 2020/10/15 T.Ono add 2020�Ď����P
            strSQL.Append(",NVL(D.GUIDELINENM3, '�N���C�A���g3') AS GUIDELINENM_CL3 ")   ' 2020/10/15 T.Ono add 2020�Ď����P
            strSQL.Append("FROM M11_JAHOKOKU D ")
            strSQL.Append("WHERE  D.KBN = '1' ")
            strSQL.Append("AND    D.GROUPCD = :CLSI_CD ")
            strSQL.Append("AND    TRIM(D.GUIDELINE) IS NOT NULL  ")
            strSQL.Append("AND    LPAD(D.TANCD, 2, '0') = '01' ")
            '2016/02/02 w.ganeko 2015�Ď����P ��2 end

            '�p�����[�^�̃Z�b�g
            SqlParamC = New CSQLParam()
            SqlParamC.fncSetParam("CLSI_CD", True, KETAIJAG00C.pPRAM_CLI)

            '//SQL�̎��s
            dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

            If Convert.ToString(dbData.Tables(0).Rows(0).Item("GUIDELINE_CL")) <> "XYZ" Then
                '//�f�[�^���o�͂��܂�
                Dim guideline As String = Convert.ToString(dbData.Tables(0).Rows(0).Item("GUIDELINE_CL")).Replace(ControlChars.Lf, "").Replace("'", ControlChars.Quote)
                Dim guideline2 As String = Convert.ToString(dbData.Tables(0).Rows(0).Item("GUIDELINE_CL2")).Replace(ControlChars.Lf, "").Replace("'", ControlChars.Quote)  ' 2019/11/01 W.GANEKO add 2019�Ď����P start
                Dim guideline3 As String = Convert.ToString(dbData.Tables(0).Rows(0).Item("GUIDELINE_CL3")).Replace(ControlChars.Lf, "").Replace("'", ControlChars.Quote)  ' 2019/11/01 W.GANEKO add 2019�Ď����P start
                Dim guidelineNM1 As String = Convert.ToString(dbData.Tables(0).Rows(0).Item("GUIDELINENM_CL1")).Trim  ' 2020/10/15 T.Ono add 2020�Ď����P
                Dim guidelineNM2 As String = Convert.ToString(dbData.Tables(0).Rows(0).Item("GUIDELINENM_CL2")).Trim  ' 2020/10/15 T.Ono add 2020�Ď����P
                Dim guidelineNM3 As String = Convert.ToString(dbData.Tables(0).Rows(0).Item("GUIDELINENM_CL3")).Trim  ' 2020/10/15 T.Ono add 2020�Ď����P
                strMsg.Append("parent.Data.Form1.txtGuidelineCL.value = '" & guideline & "';")
                strMsg.Append("parent.Data.Form1.txtGuidelineCL2.value = '" & guideline2 & "';")  ' 2019/11/01 W.GANEKO add 2019�Ď����P start
                strMsg.Append("parent.Data.Form1.txtGuidelineCL3.value = '" & guideline3 & "';")  ' 2019/11/01 W.GANEKO add 2019�Ď����P start
                strMsg.Append("parent.Data.Form1.txtGuidelineNMCL1.value = '" & guidelineNM1 & "';")  ' 2020/10/15 T.Ono add 2020�Ď����P
                strMsg.Append("parent.Data.Form1.txtGuidelineNMCL2.value = '" & guidelineNM2 & "';")  ' 2020/10/15 T.Ono add 2020�Ď����P
                strMsg.Append("parent.Data.Form1.txtGuidelineNMCL3.value = '" & guidelineNM3 & "';")  ' 2020/10/15 T.Ono add 2020�Ď����P
            Else
                '//�f�[�^�����������܂�
                strMsg.Append("parent.Data.Form1.txtGuidelineCL.value = '';")
                strMsg.Append("parent.Data.Form1.txtGuidelineCL2.value = '';")               ' 2019/11/01 W.GANEKO add 2019�Ď����P start
                strMsg.Append("parent.Data.Form1.txtGuidelineCL3.value = '';")               ' 2019/11/01 W.GANEKO add 2019�Ď����P start
                strMsg.Append("parent.Data.Form1.txtGuidelineNMCL1.value = '�N���C�A���g1';")             ' 2020/10/15 T.Ono add 2020�Ď����P
                strMsg.Append("parent.Data.Form1.txtGuidelineNMCL2.value = '�N���C�A���g2';")             ' 2020/10/15 T.Ono add 2020�Ď����P
                strMsg.Append("parent.Data.Form1.txtGuidelineNMCL3.value = '�N���C�A���g3';")             ' 2020/10/15 T.Ono add 2020�Ď����P
            End If
            '//�N���C�A���g�I��������@JA���ӎ��������������܂�
            strMsg.Append("parent.Data.Form1.txtGuideline.value = '';")
            strMsg.Append("parent.Data.Form1.txtGuideline2.value = '';")                    ' 2019/11/01 W.GANEKO add 2019�Ď����P start
            strMsg.Append("parent.Data.Form1.txtGuideline3.value = '';")                    ' 2019/11/01 W.GANEKO add 2019�Ď����P start
            strMsg.Append("parent.Data.Form1.txtGuidelineNM1.value = 'JA���ӎ���1';")                  ' 2020/10/15 T.Ono add 2020�Ď����P
            strMsg.Append("parent.Data.Form1.txtGuidelineNM2.value = 'JA���ӎ���2';")                  ' 2020/10/15 T.Ono add 2020�Ď����P
            strMsg.Append("parent.Data.Form1.txtGuidelineNM3.value = 'JA���ӎ���3';")                  ' 2020/10/15 T.Ono add 2020�Ď����P
            strMsg.Append("parent.Data.Form1.txtGuideline.onchange();")
            strMsg.Append("parent.Data.Form1.txtGuidelineCL.onchange();")
            '������ 2013/06/25 T.Ono add ���ӎ����i�N���C�A���g�j���擾 ������


        Catch ex As Exception
            Dim ErrMsgC As New CErrMsg
            strMsg.Append("alert('�V�X�e���G���[�F" & ErrMsgC.mGetArtMsg(ex.ToString) & "');")
            strRec = "ERROR"

            '--- ��2005/04/24 MOD Falcon�� ---
        Finally
            If dbData Is Nothing Then
            Else
                dbData.Dispose()
            End If
            '--- ��2005/04/24 MOD Falcon�� ---
        End Try

        '--- ��2005/04/24 DEL Falcon�� ---
        'dbData.Dispose()
        '--- ��2005/04/24 DEL Falcon�� ---

        Return strRec
    End Function

    '******************************************************************************
    ' �@JA�x���R�[�h���o����Џ����擾�A���݂��Ȃ��ꍇ��
    ' �A�o����ЃR�[�h�����ݒ�̏ꍇ�́A����JA�x���R�[�h�ŒS���҂��S���擾����
    '******************************************************************************
    Private Function fncGetData_REN() As String
        Dim SQLC As New KETAIJAG00CSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet

        Dim KETAIJAG00C As KETAIJAG00
        KETAIJAG00C = CType(Context.Handler, KETAIJAG00)

        Dim intRow As Integer
        Dim intTan As Integer
        Dim strRec As String

        Dim strJACD As String ' 2007/09/18 T.Watabe add
        Dim existFlg As Boolean
        strJACD = ""
        existFlg = False

        Dim DBKBN As Integer = 0  ' 2013/05/31 T.Ono add 0:M05_TANTO  1:M05_TANTO2(���q�l�w��)  2:M05_TANTO2(���q�l�͈�)
        ' 2013/08/07 T.Ono add FAXKBN,FAXKURAKBN,GUIDELINE�擾
        Dim strFAXKBN As String
        Dim strFAXKURAKBN As String
        Dim strGUIDELINE As String
        Dim strGUIDELINECL As String '2015/02/19 T.Ono add 2014���P�J�� No15
        Dim strGUIDELINE2 As String   '2019/11/01 W.GANEKO 2019���P�J�� No8-12
        Dim strGUIDELINECL2 As String '2019/11/01 W.GANEKO 2019���P�J�� No8-12
        Dim strGUIDELINE3 As String   '2019/11/01 W.GANEKO 2019���P�J�� No8-12
        Dim strGUIDELINECL3 As String '2019/11/01 W.GANEKO 2019���P�J�� No8-12
        '2020/11/01 T.Ono 2020�Ď����P Strat
        Dim strGUIDELINENM1 As String
        Dim strGUIDELINENMCL1 As String
        Dim strGUIDELINENM2 As String
        Dim strGUIDELINENMCL2 As String
        Dim strGUIDELINENM3 As String
        Dim strGUIDELINENMCL3 As String
        '2020/11/01 T.Ono 2020�Ď����P End

        strRec = "OK"
        Try

            '//�I�����ꂽ�i�`�x���R�[�h���[JA�R�[�h][JA��][JA�x����]��
            '//Hidden�ɐݒ肷��
            strSQL = New StringBuilder("")
            strSQL.Append("SELECT  ")
            strSQL.Append("JA_CD, ")
            strSQL.Append("JA_NAME, ")
            strSQL.Append("JAS_NAME ")
            strSQL.Append("FROM HN2MAS ")
            strSQL.Append("WHERE CLI_CD = :CLSI_CD ")
            strSQL.Append("  AND HAN_CD = :HAN_CD ")
            '�p�����[�^�̃Z�b�g
            SqlParamC.fncSetParam("CLSI_CD", True, KETAIJAG00C.pPRAM_CLI)
            SqlParamC.fncSetParam("HAN_CD", True, KETAIJAG00C.pPRAM_JASS)
            '//SQL�̎��s
            dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)
            '//�f�[�^�̎擾
            If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
                strMsg.Append("parent.Data.Form1.hdnJACD.value='';")              '�i�`�R�[�h
                strMsg.Append("parent.Data.Form1.hdnJANAME.value='';")            '�i�`��
                strMsg.Append("parent.Data.Form1.hdnJASNAME.value='';")           '�i�`�x����
            Else
                strMsg.Append("parent.Data.Form1.hdnJACD.value='" & Convert.ToString(dbData.Tables(0).Rows(intRow).Item("JA_CD")) & "';")
                strMsg.Append("parent.Data.Form1.hdnJANAME.value='" & Convert.ToString(dbData.Tables(0).Rows(intRow).Item("JA_NAME")) & "';")
                strMsg.Append("parent.Data.Form1.hdnJASNAME.value='" & Convert.ToString(dbData.Tables(0).Rows(intRow).Item("JAS_NAME")) & "';")

                strJACD = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("JA_CD")) ' 2007/09/18 T.Watabe add JA�R�[�h��S���ґI��p�Ɏ擾
            End If


            '//�o����Џ��̎擾
            strSQL = New StringBuilder("")
            strSQL.Append("SELECT  ")
            strSQL.Append("    JA.SHUTU_CD, ")
            strSQL.Append("    JA.KYOTEN_CD, ")
            strSQL.Append("    KAISYA_NAME, ")
            strSQL.Append("    KYOTEN_NAME, ")
            '20050802 NEC UPDATE START
            'strSQL.Append("    KYOTEN_TEL ")
            strSQL.Append("    PATO_TEL ")
            '20050802 NEC UPDATE END
            strSQL.Append("FROM HN2MAS JA, ")
            strSQL.Append("     SHUTUDOMAS SD ")
            strSQL.Append("WHERE JA.CLI_CD = :CLSI_CD ")
            strSQL.Append("  AND JA.HAN_CD = :HAN_CD ")
            strSQL.Append("  AND JA.SHUTU_CD = SD.SHUTU_CD ")
            strSQL.Append("  AND JA.KYOTEN_CD = SD.KYOTEN_CD ")
            strSQL.Append("  AND '1' = SD.KUBUN ")      '//1:�o����Ё@2:�i�`
            '�p�����[�^�̃Z�b�g
            SqlParamC = New CSQLParam()                 '2012/05/28 NEC Add
            SqlParamC.fncSetParam("CLSI_CD", True, KETAIJAG00C.pPRAM_CLI)
            SqlParamC.fncSetParam("HAN_CD", True, KETAIJAG00C.pPRAM_JASS)
            '//SQL�̎��s
            dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

            '������������������������������������������������������������������������
            '--- ��2005/09/07 MOD Falcon�� ---
            '�o����Ђւ̓d�b���M�{�^���ƘA����I���{�^���̗������g�p�\�ɂ���

            '//----------------------------------------------------------------------
            If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
                '�o����Џ��͏���������
                strMsg.Append("parent.Data.Form1.hdnSTD_CD.value='';")              '�o����ЃR�[�h
                strMsg.Append("parent.Data.Form1.txtSTD.value='';")                 '�o����Ж�
                strMsg.Append("parent.Data.Form1.hdnSTD_KYOTEN_CD.value='';")       '���_�R�[�h
                strMsg.Append("parent.Data.Form1.txtSTD_KYOTEN.value='';")          '���_��
                strMsg.Append("parent.Data.Form1.txtSTD_TEL.value='';")             '�d�b�ԍ�
                strMsg.Append("parent.Data.Form1.btnTel.disabled = true;")  '�d�b���M�{�^���g�p�s��
            Else
                '//�f�[�^���o�͂��܂�
                '�o����Ж��E���_���E�d�b�ԍ��Ƀf�[�^���Z�b�g����
                strMsg.Append("parent.Data.Form1.hdnSTD_CD.value='" & Convert.ToString(dbData.Tables(0).Rows(intRow).Item("SHUTU_CD")) & "';")              '�o����ЃR�[�h
                strMsg.Append("parent.Data.Form1.txtSTD.value='" & Convert.ToString(dbData.Tables(0).Rows(intRow).Item("KAISYA_NAME")) & "';")              '�o����Ж�
                strMsg.Append("parent.Data.Form1.hdnSTD_KYOTEN_CD.value='" & Convert.ToString(dbData.Tables(0).Rows(intRow).Item("KYOTEN_CD")) & "';")      '���_�R�[�h
                strMsg.Append("parent.Data.Form1.txtSTD_KYOTEN.value='" & Convert.ToString(dbData.Tables(0).Rows(intRow).Item("KYOTEN_NAME")) & "';")       '���_��
                '20050802 NEC UPDATE START
                'strMsg.Append("parent.Data.Form1.txtSTD_TEL.value='" & Convert.ToString(dbData.Tables(0).Rows(intRow).Item("KYOTEN_TEL")) & "';")           '�d�b�ԍ�
                strMsg.Append("parent.Data.Form1.txtSTD_TEL.value='" & Convert.ToString(dbData.Tables(0).Rows(intRow).Item("PATO_TEL")) & "';")           '�d�b�ԍ�
                '20050802 NEC UPDATE END
                strMsg.Append("parent.Data.Form1.btnTel.disabled = false;") '�d�b���M�{�^���g�p��
            End If
            '//----------------------------------------------------------------------

            '������������������������������������������������������������������������

            '//�f�[�^�̎擾
            '������ 2013/05/24 T.Ono add �ڋq�P�ʓo�^�@�\�ǉ� ������
            '�܂�M05_TANTO2������

            If KETAIJAG00C.pPRAM_JUYOKA <> "" Then
                '���q�l�R�[�h�w��Ō��������q�l�R�[�h�͈͂Ō���
                For i As Integer = 0 To 1
                    strSQL = New StringBuilder("")
                    '2016/02/02 w.ganeko 2015���P�J�� ��2 start
                    'strSQL.Append("SELECT ")
                    'strSQL.Append("    JA.JA_NAME, ")
                    'strSQL.Append("    JA.JAS_NAME, ")
                    'strSQL.Append("    TN.TANCD, ")
                    'strSQL.Append("    TN.TANNM, ")
                    'strSQL.Append("    TN.RENTEL1, ")
                    'strSQL.Append("    TN.RENTEL2, ")
                    'strSQL.Append("    TN.RENTEL3, ")
                    'strSQL.Append("    TN.FAXNO, ")
                    'strSQL.Append("    TN.BIKO, ")
                    'strSQL.Append("    TN.EDT_DATE, ")
                    'strSQL.Append("    TN.TIME, ")
                    'strSQL.Append("    TN.SPOT_MAIL, ")
                    'strSQL.Append("    TN.MAIL_PASS, ")
                    'strSQL.Append("    TN.USER_CD_FROM ")
                    'strSQL.Append("FROM HN2MAS JA, ")
                    'strSQL.Append("     M05_TANTO2 TN ")
                    'strSQL.Append("WHERE ")
                    'strSQL.Append("      JA.CLI_CD = :CLSI_CD ")
                    'strSQL.Append("  AND JA.HAN_CD = :HAN_CD ")
                    'strSQL.Append("  AND JA.CLI_CD = TN.KURACD(+) ")
                    'strSQL.Append("  AND JA.HAN_CD = TN.CODE(+) ")
                    'If i = 0 Then
                    '    strSQL.Append("  AND TN.USER_CD_TO Is Null ")
                    '    strSQL.Append("  AND TN.USER_CD_FROM = :USER_CD")
                    'Else
                    '    strSQL.Append("  AND :USER_CD between TN.USER_CD_FROM and TN.USER_CD_TO")
                    'End If
                    'strSQL.Append("  AND 0 <> TO_NUMBER(TN.TANCD) ")
                    'strSQL.Append("  AND '3' = TN.KBN(+) ")
                    'strSQL.Append("ORDER BY TO_NUMBER(TN.TANCD) ")
                    strSQL.Append("SELECT ")
                    strSQL.Append("    JA.JA_NAME, ")
                    strSQL.Append("    JA.JAS_NAME, ")
                    strSQL.Append("    M11.GROUPCD, ")
                    strSQL.Append("    M11.GROUPNM, ")
                    strSQL.Append("    M11.TANCD, ")
                    strSQL.Append("    M11.TANNM, ")
                    strSQL.Append("    M11.RENTEL1, ")
                    strSQL.Append("    M11.RENTEL2, ")
                    strSQL.Append("    M11.RENTEL3, ")
                    strSQL.Append("    M11.FAXNO, ")
                    strSQL.Append("    M11.BIKO, ")
                    strSQL.Append("    TO_CHAR(M11.UPD_DATE,'YYYYMMDD') AS EDT_DATE, ")
                    strSQL.Append("    TO_CHAR(M11.UPD_DATE,'HH24MISS') AS TIME, ")
                    strSQL.Append("    M11.SPOT_MAIL, ")
                    strSQL.Append("    M11.MAIL_PASS, ")
                    strSQL.Append("    M09.USERCD_FROM AS USER_CD_FROM ")
                    strSQL.Append("FROM HN2MAS JA, ")
                    strSQL.Append("     M09_JAGROUP M09, ")
                    strSQL.Append("     M11_JAHOKOKU M11 ")
                    strSQL.Append("WHERE ")
                    strSQL.Append("      JA.CLI_CD = :CLSI_CD ")
                    strSQL.Append("  AND JA.HAN_CD = :HAN_CD ")
                    strSQL.Append("  AND M09.KBN(+) = '002' ")
                    strSQL.Append("  AND JA.CLI_CD = M09.KURACD(+) ")
                    strSQL.Append("  AND JA.HAN_CD = M09.ACBCD(+) ")
                    strSQL.Append("  AND M11.KBN(+) = '2' ")
                    strSQL.Append("  AND M09.GROUPCD = M11.GROUPCD(+) ")
                    If i = 0 Then
                        strSQL.Append("  AND M09.USERCD_TO(+) Is Null ")
                        strSQL.Append("  AND M09.USERCD_FROM(+) = :USER_CD")
                    Else
                        strSQL.Append("  AND :USER_CD between M09.USERCD_FROM(+) and M09.USERCD_TO(+)")
                    End If
                    strSQL.Append("  AND 0 <> TO_NUMBER(M11.TANCD) ")
                    strSQL.Append("ORDER BY TO_NUMBER(M11.TANCD) ")
                    '2016/02/02 w.ganeko 2015���P�J�� ��2 end
                    '�p�����[�^�̃Z�b�g
                    SqlParamC = New CSQLParam()
                    SqlParamC.fncSetParam("CLSI_CD", True, KETAIJAG00C.pPRAM_CLI)
                    SqlParamC.fncSetParam("HAN_CD", True, KETAIJAG00C.pPRAM_JASS)
                    SqlParamC.fncSetParam("USER_CD", True, KETAIJAG00C.pPRAM_JUYOKA)
                    'mlog(strSQL.ToString & " CLSI_CD=" & KETAIJAG00C.pPRAM_CLI & " HAN_CD=" & KETAIJAG00C.pPRAM_JASS & " USER_CD=" & KETAIJAG00C.pPRAM_JUYOKA)
                    '//SQL�̎��s
                    dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

                    If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) <> "XYZ" Then
                        If i = 0 Then
                            DBKBN = 1   '���q�l�R�[�h�w��
                        Else
                            DBKBN = 2   '���q�l�R�[�h�w��͈�
                        End If
                        strMsg.Append("parent.Data.Form1.hdnUSER_CD_FROM.value='" & Convert.ToString(dbData.Tables(0).Rows(0).Item("USER_CD_FROM")) & "';")
                        Exit For
                    End If
                Next
            End If

            If DBKBN = 0 Then
                '������ 2013/05/24 T.Ono add �ڋq�P�ʓo�^�@�\�ǉ� ������

                'If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then     '2005/09/07 DEL Falcon
                strSQL = New StringBuilder("")
                '2016/02/02 w.ganeko 2015���P�J�� ��2 start
                'strSQL.Append("SELECT ")
                'strSQL.Append("    JA.JA_NAME, ")
                'strSQL.Append("    JA.JAS_NAME, ")
                'strSQL.Append("    TN.TANCD, ")
                'strSQL.Append("    TN.TANNM, ")
                'strSQL.Append("    TN.RENTEL1, ")
                'strSQL.Append("    TN.RENTEL2, ")
                'strSQL.Append("    TN.RENTEL3, ") '2013/05/27 T.Ono add
                'strSQL.Append("    TN.FAXNO, ")
                'strSQL.Append("    TN.BIKO, ")
                'strSQL.Append("    TN.EDT_DATE, ")
                'strSQL.Append("    TN.TIME, ")
                'strSQL.Append("    TN.SPOT_MAIL, ") '2012/03/26 W.GANEKO
                'strSQL.Append("    TN.MAIL_PASS ") '2012/03/26 W.GANEKO
                'strSQL.Append("FROM HN2MAS JA, ")
                'strSQL.Append("     M05_TANTO TN ")
                'strSQL.Append("WHERE ")
                'strSQL.Append("      JA.CLI_CD = :CLSI_CD ")
                'strSQL.Append("  AND JA.HAN_CD = :HAN_CD ")
                'strSQL.Append("  AND JA.CLI_CD = TN.KURACD(+) ")
                'strSQL.Append("  AND JA.HAN_CD = TN.CODE(+) ")
                'strSQL.Append("  AND 0 <> TO_NUMBER(TN.TANCD) ")
                'strSQL.Append("  AND '3' = TN.KBN(+) ")
                'strSQL.Append("ORDER BY TO_NUMBER(TN.TANCD) ")
                strSQL.Append("SELECT ")
                strSQL.Append("    JA.JA_NAME, ")
                strSQL.Append("    JA.JAS_NAME, ")
                strSQL.Append("    M11.GROUPCD, ")
                strSQL.Append("    M11.GROUPNM, ")
                strSQL.Append("    M11.TANCD, ")
                strSQL.Append("    M11.TANNM, ")
                strSQL.Append("    M11.RENTEL1, ")
                strSQL.Append("    M11.RENTEL2, ")
                strSQL.Append("    M11.RENTEL3, ")
                strSQL.Append("    M11.FAXNO, ")
                strSQL.Append("    M11.BIKO, ")
                strSQL.Append("    TO_CHAR(M11.UPD_DATE,'YYYYMMDD') AS EDT_DATE, ")
                strSQL.Append("    TO_CHAR(M11.UPD_DATE,'HH24MISS') AS TIME, ")
                strSQL.Append("    M11.SPOT_MAIL, ")
                strSQL.Append("    M11.MAIL_PASS ")
                strSQL.Append("FROM HN2MAS JA, ")
                strSQL.Append("     M09_JAGROUP M09, ")
                strSQL.Append("     M11_JAHOKOKU M11 ")
                strSQL.Append("WHERE ")
                strSQL.Append("      JA.CLI_CD = :CLSI_CD ")
                strSQL.Append("  AND JA.HAN_CD = :HAN_CD ")
                strSQL.Append("  AND M09.KBN(+) = '002' ")
                strSQL.Append("  AND JA.CLI_CD = M09.KURACD(+) ")
                strSQL.Append("  AND JA.HAN_CD = M09.ACBCD(+) ")
                strSQL.Append("  AND M11.KBN(+) = '2' ")
                strSQL.Append("  AND M09.GROUPCD = M11.GROUPCD(+) ")
                strSQL.Append("  AND M09.USERCD_FROM(+) IS NULL ")
                strSQL.Append("  AND M09.USERCD_TO(+) IS NULL ")
                strSQL.Append("  AND 0 <> TO_NUMBER(M11.TANCD(+)) ")
                strSQL.Append("ORDER BY TO_NUMBER(M11.TANCD) ")
                '2016/02/02 w.ganeko 2015���P�J�� ��2 end
                'mlog(strSQL.ToString & "CLSI_CD=" & KETAIJAG00C.pPRAM_CLI & " HAN_CD=" & KETAIJAG00C.pPRAM_JASS)
                '�p�����[�^�̃Z�b�g
                SqlParamC = New CSQLParam()                 '2012/05/28 NEC Add
                SqlParamC.fncSetParam("CLSI_CD", True, KETAIJAG00C.pPRAM_CLI)
                SqlParamC.fncSetParam("HAN_CD", True, KETAIJAG00C.pPRAM_JASS)

                '//SQL�̎��s
                dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)
                '������ 2013/05/24 T.Ono add �ڋq�P�ʓo�^�@�\�ǉ� ������
            End If
            '������ 2013/05/24 T.Ono add �ڋq�P�ʓo�^�@�\�ǉ� ������

            '--- ��2005/09/07 DEL Falcon�� ---
            ''�o����Џ��͏���������
            'strMsg.Append("parent.Data.Form1.hdnSTD_CD.value='';")              '�o����ЃR�[�h
            'strMsg.Append("parent.Data.Form1.txtSTD.value='';")                 '�o����Ж�
            'strMsg.Append("parent.Data.Form1.hdnSTD_KYOTEN_CD.value='';")       '���_�R�[�h
            'strMsg.Append("parent.Data.Form1.txtSTD_KYOTEN.value='';")          '���_��
            'strMsg.Append("parent.Data.Form1.txtSTD_TEL.value='';")             '�d�b�ԍ�
            ''�{�^���͘A����I���ƂȂ�
            'strMsg.Append("parent.Data.Form1.btnRenraku.value='�A����I��';")   '�{�^��
            '--- ��2005/09/07 DEL Falcon�� ---

            If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) <> "XYZ" Then
                '�i�`�x�����f�[�^����I
                existFlg = True
                strMsg.Append("parent.Data.Form1.hdnM05_TANTO_HAN_CD.value='" & KETAIJAG00C.pPRAM_JASS & "';") ' 2010/05/12 T.Watabe add
                strMsg.Append("parent.Data.Form1.hdnGROUPCD.value='" & Convert.ToString(dbData.Tables(0).Rows(0).Item("GROUPCD")) & "';") ' 2016/02/02 W.GANEKO add
                strMsg.Append("parent.Data.Form1.hdnGROUPNM.value='" & Convert.ToString(dbData.Tables(0).Rows(0).Item("GROUPNM")) & "';") ' 2016/02/02 W.GANEKO add
            Else
                If strJACD <> "" Then

                    '�i�`�x���Ō�����Ȃ��̂ŁE�E�E
                    '�B�i�`��\�R�[�h����擾

                    '�p�����[�^�̃Z�b�g
                    SqlParamC = New CSQLParam()                 '2012/05/28 NEC Add
                    SqlParamC.fncSetParam("CLSI_CD", True, KETAIJAG00C.pPRAM_CLI)
                    SqlParamC.fncSetParam("HAN_CD", True, strJACD)
                    'mlog(strSQL.ToString & " CLSI_CD=" & KETAIJAG00C.pPRAM_CLI & " HAN_CD=" & strJACD & " USER_CD=" & KETAIJAG00C.pPRAM_JUYOKA)

                    '//SQL�̎��s
                    dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

                    If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) <> "XYZ" Then
                        '�i�`��\���f�[�^����I
                        existFlg = True
                        strMsg.Append("parent.Data.Form1.hdnM05_TANTO_HAN_CD.value='" & strJACD & "';") ' 2010/05/12 T.Watabe add
                        strMsg.Append("parent.Data.Form1.hdnGROUPCD.value='" & Convert.ToString(dbData.Tables(0).Rows(0).Item("GROUPCD")) & "';") ' 2016/02/02 W.GANEKO add
                        strMsg.Append("parent.Data.Form1.hdnGROUPNM.value='" & Convert.ToString(dbData.Tables(0).Rows(0).Item("GROUPNM")) & "';") ' 2016/02/02 W.GANEKO add
                    End If
                End If

            End If

            '�f�[�^�Ȃ��̏ꍇ������
            'If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
            If existFlg = False Then
                dbData.Tables(0).Rows(intRow).Item("JA_NAME") = ""
                dbData.Tables(0).Rows(intRow).Item("JAS_NAME") = ""
                dbData.Tables(0).Rows(intRow).Item("TANCD") = ""
                dbData.Tables(0).Rows(intRow).Item("TANNM") = ""
                dbData.Tables(0).Rows(intRow).Item("RENTEL1") = ""
                dbData.Tables(0).Rows(intRow).Item("RENTEL2") = ""
                dbData.Tables(0).Rows(intRow).Item("RENTEL3") = "" '2013/05/27 T.Ono add
                dbData.Tables(0).Rows(intRow).Item("FAXNO") = ""
                dbData.Tables(0).Rows(intRow).Item("BIKO") = ""
                dbData.Tables(0).Rows(intRow).Item("SPOT_MAIL") = ""  '2012/03/26 W.GANEKO
                dbData.Tables(0).Rows(intRow).Item("MAIL_PASS") = ""  '2012/03/26 W.GANEKO
                dbData.Tables(0).Rows(intRow).Item("GROUPCD") = ""  '2016/02/02 W.GANEKO
                dbData.Tables(0).Rows(intRow).Item("GROUPNM") = ""  '2016/02/02 W.GANEKO
            End If
            '�S���ҏ����Z�b�g����
            strMsg.Append("parent.Data.Form1.hdnREN_STD_JASCD.value='" & KETAIJAG00C.pPRAM_JASS & "';")
            strMsg.Append("parent.Data.Form1.hdnREN_STD_JANA.value='" & Convert.ToString(dbData.Tables(0).Rows(intRow).Item("JA_NAME")) & "';")
            strMsg.Append("parent.Data.Form1.hdnREN_STD_JASNA.value='" & Convert.ToString(dbData.Tables(0).Rows(intRow).Item("JAS_NAME")) & "';")

            'For intTan = 0 To 3 ' 2008/10/31 T.Watabe edit
            'For intTan = 0 To 9 ' 2010/05/10 T.Watabe edit
            For intTan = 0 To 29
                If Convert.ToString(dbData.Tables(0).Rows(intRow).Item("TANCD")) <> "" Then
                    If intTan + 1 = CInt(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("TANCD"))) Then
                        strMsg.Append("parent.Data.Form1.hdnREN_" & intTan & "_TANCD.value='" & Convert.ToString(dbData.Tables(0).Rows(intRow).Item("TANCD")) & "';")
                        strMsg.Append("parent.Data.Form1.hdnREN_" & intTan & "_NA.value='" & Convert.ToString(dbData.Tables(0).Rows(intRow).Item("TANNM")) & "';")
                        strMsg.Append("parent.Data.Form1.hdnREN_" & intTan & "_TEL1.value='" & Convert.ToString(dbData.Tables(0).Rows(intRow).Item("RENTEL1")) & "';")
                        strMsg.Append("parent.Data.Form1.hdnREN_" & intTan & "_TEL2.value='" & Convert.ToString(dbData.Tables(0).Rows(intRow).Item("RENTEL2")) & "';")
                        strMsg.Append("parent.Data.Form1.hdnREN_" & intTan & "_TEL3.value='" & Convert.ToString(dbData.Tables(0).Rows(intRow).Item("RENTEL3")) & "';") '2013/05/27 T.Ono add
                        strMsg.Append("parent.Data.Form1.hdnREN_" & intTan & "_BIKO.value='" & Convert.ToString(dbData.Tables(0).Rows(intRow).Item("BIKO")) & "';")
                        strMsg.Append("parent.Data.Form1.hdnREN_" & intTan & "_FAX.value='" & Convert.ToString(dbData.Tables(0).Rows(intRow).Item("FAXNO")) & "';")
                        strMsg.Append("parent.Data.Form1.hdnREN_" & intTan & "_EDT_DATE.value='" & Convert.ToString(dbData.Tables(0).Rows(intRow).Item("EDT_DATE")) & "';")
                        strMsg.Append("parent.Data.Form1.hdnREN_" & intTan & "_TIME.value='" & Convert.ToString(dbData.Tables(0).Rows(intRow).Item("TIME")) & "';")
                        strMsg.Append("parent.Data.Form1.hdnREN_" & intTan & "_MAIL.value='" & Convert.ToString(dbData.Tables(0).Rows(intRow).Item("SPOT_MAIL")) & "';")
                        strMsg.Append("parent.Data.Form1.hdnREN_" & intTan & "_MAILPASS.value='" & Convert.ToString(dbData.Tables(0).Rows(intRow).Item("MAIL_PASS")) & "';")

                        If intRow < dbData.Tables(0).Rows.Count - 1 Then
                            intRow += 1
                        End If
                    Else
                        '�A������͏����������
                        strMsg.Append("parent.Data.Form1.hdnREN_" & intTan & "_TANCD.value='" & intTan + 1 & "';")
                        strMsg.Append("parent.Data.Form1.hdnREN_" & intTan & "_NA.value='';")
                        strMsg.Append("parent.Data.Form1.hdnREN_" & intTan & "_TEL1.value='';")
                        strMsg.Append("parent.Data.Form1.hdnREN_" & intTan & "_TEL2.value='';")
                        strMsg.Append("parent.Data.Form1.hdnREN_" & intTan & "_TEL3.value='';") '2013/05/27 T.Ono add
                        strMsg.Append("parent.Data.Form1.hdnREN_" & intTan & "_BIKO.value='';")
                        strMsg.Append("parent.Data.Form1.hdnREN_" & intTan & "_FAX.value='';")
                        strMsg.Append("parent.Data.Form1.hdnREN_" & intTan & "_EDT_DATE.value='';")
                        strMsg.Append("parent.Data.Form1.hdnREN_" & intTan & "_TIME.value='';")
                        strMsg.Append("parent.Data.Form1.hdnREN_" & intTan & "_MAIL.value='';") '2012/03/26 W.GANEKO
                        strMsg.Append("parent.Data.Form1.hdnREN_" & intTan & "_MAILPASS.value='';") '2012/03/26 W.GANEKO
                    End If
                Else
                    '�A������͏����������
                    strMsg.Append("parent.Data.Form1.hdnREN_" & intTan & "_TANCD.value='" & intTan + 1 & "';")
                    strMsg.Append("parent.Data.Form1.hdnREN_" & intTan & "_NA.value='';")
                    strMsg.Append("parent.Data.Form1.hdnREN_" & intTan & "_TEL1.value='';")
                    strMsg.Append("parent.Data.Form1.hdnREN_" & intTan & "_TEL2.value='';")
                    strMsg.Append("parent.Data.Form1.hdnREN_" & intTan & "_TEL3.value='';") '2013/05/27 T.Ono add
                    strMsg.Append("parent.Data.Form1.hdnREN_" & intTan & "_FAX.value='';")
                    strMsg.Append("parent.Data.Form1.hdnREN_" & intTan & "_BIKO.value='';")
                    strMsg.Append("parent.Data.Form1.hdnREN_" & intTan & "_EDT_DATE.value='';")
                    strMsg.Append("parent.Data.Form1.hdnREN_" & intTan & "_TIME.value='';")
                    strMsg.Append("parent.Data.Form1.hdnREN_" & intTan & "_MAIL.value='';") '2012/03/26 W.GANEKO
                    strMsg.Append("parent.Data.Form1.hdnREN_" & intTan & "_MAILPASS.value='';") '2012/03/26 W.GANEKO
                End If
            Next

            'Else   '2005/09/07 DEL Falcon
            '--- ��2005/09/07 DEL Falcon�� ---  '�ړ�
            ''//�f�[�^���o�͂��܂�
            ''�o����Ж��E���_���E�d�b�ԍ��Ƀf�[�^���Z�b�g����
            'strMsg.Append("parent.Data.Form1.hdnSTD_CD.value='" & Convert.ToString(dbData.Tables(0).Rows(intRow).Item("SHUTU_CD")) & "';")              '�o����ЃR�[�h
            'strMsg.Append("parent.Data.Form1.txtSTD.value='" & Convert.ToString(dbData.Tables(0).Rows(intRow).Item("KAISYA_NAME")) & "';")              '�o����Ж�
            'strMsg.Append("parent.Data.Form1.hdnSTD_KYOTEN_CD.value='" & Convert.ToString(dbData.Tables(0).Rows(intRow).Item("KYOTEN_CD")) & "';")      '���_�R�[�h
            'strMsg.Append("parent.Data.Form1.txtSTD_KYOTEN.value='" & Convert.ToString(dbData.Tables(0).Rows(intRow).Item("KYOTEN_NAME")) & "';")       '���_��
            ''20050802 NEC UPDATE START
            ''strMsg.Append("parent.Data.Form1.txtSTD_TEL.value='" & Convert.ToString(dbData.Tables(0).Rows(intRow).Item("KYOTEN_TEL")) & "';")           '�d�b�ԍ�
            'strMsg.Append("parent.Data.Form1.txtSTD_TEL.value='" & Convert.ToString(dbData.Tables(0).Rows(intRow).Item("PATO_TEL")) & "';")           '�d�b�ԍ�
            ''20050802 NEC UPDATE END
            ''�{�^���͓d�b���M�ƂȂ�
            'strMsg.Append("parent.Data.Form1.btnRenraku.value='�d�b���M';") '�{�^��
            '--- ��2005/09/07 DEL Falcon�� ---  '�ړ�

            '--- ��2005/09/07 DEL Falcon�� ---
            ''�A������͏����������
            'strMsg.Append("parent.Data.Form1.hdnREN_STD_JASCD.value='';")
            'strMsg.Append("parent.Data.Form1.hdnREN_STD_JANA.value='';")
            'strMsg.Append("parent.Data.Form1.hdnREN_STD_JASNA.value='';")
            'For intRow = 0 To 3
            '    '�A������͏����������
            '    strMsg.Append("parent.Data.Form1.hdnREN_" & intRow & "_TANCD.value='';")
            '    strMsg.Append("parent.Data.Form1.hdnREN_" & intRow & "_NA.value='';")
            '    strMsg.Append("parent.Data.Form1.hdnREN_" & intRow & "_TEL1.value='';")
            '    strMsg.Append("parent.Data.Form1.hdnREN_" & intRow & "_TEL2.value='';")
            '    strMsg.Append("parent.Data.Form1.hdnREN_" & intRow & "_FAX.value='';")
            '    strMsg.Append("parent.Data.Form1.hdnREN_" & intRow & "_BIKO.value='';")
            '    strMsg.Append("parent.Data.Form1.hdnREN_" & intRow & "_EDT_DATE.value='';")
            '    strMsg.Append("parent.Data.Form1.hdnREN_" & intRow & "_TIME.value='';")
            'Next
            '--- ��2005/09/07 DEL Falcon�� ---

            'End If     '2005/09/07 DEL Falcon
            '--- ��2005/09/07 MOD Falcon�� ---


            '������ 2013/08/07 T.Ono mod �ڋq�P�ʓo�^�@�\�ǉ� ������
            ''������ 2011.11.10 ADD h.uema ���ӎ������擾 ********** ������
            ''//�S���}�X�^���璍�ӎ������擾����
            'strSQL = New StringBuilder("")
            'strSQL.Append("SELECT ")
            'strSQL.Append("  DECODE(M05.CODE, :HAN_CD, '0', '1') AS SORT ")
            'strSQL.Append("  ,M05.GUIDELINE ")
            'strSQL.Append("FROM M05_TANTO M05 ")
            'strSQL.Append("WHERE M05.KBN = '3' ")
            'strSQL.Append("  AND M05.TANCD = '01' ")
            'strSQL.Append("  AND TRIM(M05.GUIDELINE) IS NOT NULL ")
            'strSQL.Append("  AND M05.KURACD = :CLSI_CD ")
            'strSQL.Append("  AND M05.CODE IN (:HAN_CD, :JA_CD) ")
            'strSQL.Append("ORDER BY SORT ")

            ''�p�����[�^�̃Z�b�g
            'SqlParamC = New CSQLParam()                 '2012/05/28 NEC Add
            'SqlParamC.fncSetParam("CLSI_CD", True, KETAIJAG00C.pPRAM_CLI)
            'SqlParamC.fncSetParam("HAN_CD", True, KETAIJAG00C.pPRAM_JASS)
            'SqlParamC.fncSetParam("JA_CD", True, strJACD)

            ''//SQL�̎��s
            'dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

            'If Convert.ToString(dbData.Tables(0).Rows(0).Item("SORT")) <> "XYZ" Then
            '    '//�f�[�^���o�͂��܂�
            '    Dim guideline As String = Convert.ToString(dbData.Tables(0).Rows(0).Item("GUIDELINE")).Replace(ControlChars.Lf, "").Replace("'", ControlChars.Quote)
            '    strMsg.Append("parent.Data.Form1.txtGuideline.value = '" & guideline & "';")
            'Else
            '    '//�f�[�^�����������܂�
            '    strMsg.Append("parent.Data.Form1.txtGuideline.value = '';")
            'End If
            'strMsg.Append("parent.Data.Form1.txtGuideline.onchange();")
            ''������ 2011.11.10 ADD h.uema ���ӎ������擾 ********** ������
            ' FAXKBN�AFAXKURAKBN�AGUIDELINE�AGUDELINECL���擾
            strSQL = New StringBuilder("")
            '2016/02/02 w.ganeko 2015�J�����P ��2 start
            'strSQL.Append("WITH ")
            'strSQL.Append("/* ���q�l�� */ ")
            'strSQL.Append("A AS ( ")
            'strSQL.Append("SELECT T.KURACD, T.CODE, T.USER_CD_FROM, T.FAXKBN, T.FAXKURAKBN, T.GUIDELINE ")
            'strSQL.Append("FROM   M05_TANTO2 T ")
            'strSQL.Append("WHERE  T.KURACD = :CLSI_CD ")
            'strSQL.Append("AND    T.CODE = :HAN_CD ")
            'strSQL.Append("AND    T.USER_CD_FROM = :USER_CD ")
            'strSQL.Append("AND    T.KBN = '3' ")
            'strSQL.Append("AND    LPAD(T.TANCD, 2, '0') = '01' ")
            'strSQL.Append("AND    T.USER_CD_TO IS NULL ")
            'strSQL.Append("), ")
            'strSQL.Append("/* ���q�l�͈� */ ")
            'strSQL.Append("B AS ( ")
            'strSQL.Append("SELECT T.KURACD, T.CODE, T.USER_CD_FROM, T.FAXKBN, T.FAXKURAKBN, T.GUIDELINE ")
            'strSQL.Append("FROM   M05_TANTO2 T ")
            'strSQL.Append("WHERE  T.KURACD = :CLSI_CD ")
            'strSQL.Append("AND    T.CODE = :HAN_CD ")
            'strSQL.Append("AND    T.KBN = '3' ")
            'strSQL.Append("AND    LPAD(T.TANCD, 2, '0') = '01' ")
            'strSQL.Append("AND    T.USER_CD_TO IS NOT NULL ")
            'strSQL.Append("AND    :USER_CD BETWEEN T.USER_CD_FROM AND T.USER_CD_TO ")
            'strSQL.Append("), ")
            'strSQL.Append("/* JA�x�� */ ")
            'strSQL.Append("C AS ( ")
            'strSQL.Append("SELECT T.KURACD, T.CODE, T.FAXKBN, T.FAXKURAKBN, T.GUIDELINE ")
            'strSQL.Append("FROM   M05_TANTO T ")
            'strSQL.Append("WHERE  T.KURACD = :CLSI_CD ")
            'strSQL.Append("AND    T.CODE = :HAN_CD ")
            'strSQL.Append("AND    T.KBN = '3' ")
            'strSQL.Append("AND    LPAD(T.TANCD, 2, '0') = '01' ")
            'strSQL.Append("), ")
            'strSQL.Append("/* JA3�P�^ */ ")
            'strSQL.Append("D AS ( ")
            'strSQL.Append("SELECT T.KURACD, T.CODE, T.FAXKBN, T.FAXKURAKBN, T.GUIDELINE ")
            'strSQL.Append("FROM   M05_TANTO T ")
            'strSQL.Append("WHERE  T.KURACD = :CLSI_CD ")
            'strSQL.Append("AND    T.CODE = :JA_CD ")
            'strSQL.Append("AND    T.KBN = '3' ")
            'strSQL.Append("AND    LPAD(T.TANCD, 2, '0') = '01' ")
            'strSQL.Append("), ")
            '2015/02/19 T.Ono add 2014���P�J�� No15 START
            'strSQL.Append("/* �N���C�A���g */ ")
            'strSQL.Append("K AS ( ")
            'strSQL.Append("SELECT T.KURACD, T.CODE, T.FAXKBN, T.FAXKURAKBN, T.GUIDELINE AS GUIDELINECL ")
            'strSQL.Append("FROM   M05_TANTO T ")
            'strSQL.Append("WHERE  T.KURACD = :CLSI_CD ")
            'strSQL.Append("AND    T.CODE = 'XXXX' ")
            'strSQL.Append("AND    T.KBN = '3' ")
            'strSQL.Append("AND    LPAD(T.TANCD, 2, '0') = '01' ")
            'strSQL.Append("), ")
            strSQL.Append("WITH ")
            strSQL.Append("/* ���q�l�� */ ")
            strSQL.Append("A AS ( ")
            strSQL.Append("SELECT T.KURACD, T.ACBCD, T.USERCD_FROM, D.FAXKBN, D.FAXKURAKBN, D.GUIDELINE ")
            strSQL.Append(",D.GUIDELINE2 ")          '2019/11/01 W.GANEKO 2019�Ď����P No8-12
            strSQL.Append(",D.GUIDELINE3 ")          '2019/11/01 W.GANEKO 2019�Ď����P No8-12
            strSQL.Append(",D.GUIDELINENM1 ")          '2020/11/01 T.Ono 2020�Ď����P
            strSQL.Append(",D.GUIDELINENM2 ")          '2020/11/01 T.Ono 2020�Ď����P
            strSQL.Append(",D.GUIDELINENM3 ")          '2020/11/01 T.Ono 2020�Ď����P
            strSQL.Append("FROM   M09_JAGROUP T, ")
            strSQL.Append("       M11_JAHOKOKU D ")
            strSQL.Append("WHERE  T.KURACD = :CLSI_CD ")
            strSQL.Append("AND    T.ACBCD = :HAN_CD ")
            strSQL.Append("AND    T.KBN = '002' ")
            strSQL.Append("AND    T.USERCD_FROM = :USER_CD ")
            strSQL.Append("AND    T.USERCD_TO IS NULL ")
            strSQL.Append("AND    D.KBN = '2' ")
            strSQL.Append("AND    T.GROUPCD = D.GROUPCD ")
            strSQL.Append("AND    LPAD(D.TANCD, 2, '0') = '01' ")
            strSQL.Append("), ")
            strSQL.Append("/* ���q�l�͈� */ ")
            strSQL.Append("B AS ( ")
            strSQL.Append("SELECT T.KURACD, T.ACBCD, T.USERCD_FROM, D.FAXKBN, D.FAXKURAKBN, D.GUIDELINE ")
            strSQL.Append(",D.GUIDELINE2 ")          '2019/11/01 W.GANEKO 2019�Ď����P No8-12
            strSQL.Append(",D.GUIDELINE3 ")          '2019/11/01 W.GANEKO 2019�Ď����P No8-12
            strSQL.Append(",D.GUIDELINENM1 ")          '2020/11/01 T.Ono 2020�Ď����P
            strSQL.Append(",D.GUIDELINENM2 ")          '2020/11/01 T.Ono 2020�Ď����P
            strSQL.Append(",D.GUIDELINENM3 ")          '2020/11/01 T.Ono 2020�Ď����P
            strSQL.Append("FROM   M09_JAGROUP T, ")
            strSQL.Append("       M11_JAHOKOKU D ")
            strSQL.Append("WHERE  T.KURACD = :CLSI_CD ")
            strSQL.Append("AND    T.ACBCD = :HAN_CD ")
            strSQL.Append("AND    T.KBN = '002' ")
            strSQL.Append("AND    D.KBN = '2' ")
            strSQL.Append("AND    T.GROUPCD = D.GROUPCD ")
            strSQL.Append("AND    LPAD(D.TANCD, 2, '0') = '01' ")
            strSQL.Append("AND    T.USERCD_TO IS NOT NULL ")
            strSQL.Append("AND    :USER_CD BETWEEN T.USERCD_FROM AND T.USERCD_TO ")
            strSQL.Append("), ")
            strSQL.Append("/* JA�x�� */ ")
            strSQL.Append("C AS ( ")
            strSQL.Append("SELECT T.KURACD, T.ACBCD, D.FAXKBN, D.FAXKURAKBN, D.GUIDELINE ")
            strSQL.Append(",D.GUIDELINE2 ")          '2019/11/01 W.GANEKO 2019�Ď����P No8-12
            strSQL.Append(",D.GUIDELINE3 ")          '2019/11/01 W.GANEKO 2019�Ď����P No8-12
            strSQL.Append(",D.GUIDELINENM1 ")          '2020/11/01 T.Ono 2020�Ď����P
            strSQL.Append(",D.GUIDELINENM2 ")          '2020/11/01 T.Ono 2020�Ď����P
            strSQL.Append(",D.GUIDELINENM3 ")          '2020/11/01 T.Ono 2020�Ď����P
            strSQL.Append("FROM   M09_JAGROUP T, ")
            strSQL.Append("       M11_JAHOKOKU D ")
            strSQL.Append("WHERE  T.KURACD = :CLSI_CD ")
            strSQL.Append("AND    T.ACBCD = :HAN_CD ")
            strSQL.Append("AND    T.KBN = '002' ")
            strSQL.Append("AND    D.KBN = '2' ")
            strSQL.Append("AND    T.GROUPCD = D.GROUPCD ")
            strSQL.Append("AND    LPAD(D.TANCD, 2, '0') = '01' ")
            strSQL.Append("AND    T.USERCD_FROM IS NULL ")
            strSQL.Append("AND    T.USERCD_TO IS NULL ")
            strSQL.Append("), ")
            strSQL.Append("/* �N���C�A���g */ ")
            strSQL.Append("K AS ( ")
            strSQL.Append("SELECT D.GROUPCD AS KURACD, D.FAXKBN, D.FAXKURAKBN, D.GUIDELINE AS GUIDELINECL ")
            strSQL.Append(",D.GUIDELINE2 AS GUIDELINECL2 ")          '2019/11/01 W.GANEKO 2019�Ď����P No8-12
            strSQL.Append(",D.GUIDELINE3 AS GUIDELINECL3 ")          '2019/11/01 W.GANEKO 2019�Ď����P No8-12
            strSQL.Append(",D.GUIDELINENM1 AS GUIDELINENMCL1 ")          '2020/11/01 T.Ono 2020�Ď����P
            strSQL.Append(",D.GUIDELINENM2 AS GUIDELINENMCL2 ")          '2020/11/01 T.Ono 2020�Ď����P
            strSQL.Append(",D.GUIDELINENM3 AS GUIDELINENMCL3 ")          '2020/11/01 T.Ono 2020�Ď����P
            strSQL.Append("FROM M11_JAHOKOKU D ")
            strSQL.Append("WHERE  D.KBN = '1' ")
            strSQL.Append("AND    D.GROUPCD = :CLSI_CD ")
            strSQL.Append("AND    LPAD(D.TANCD, 2, '0') = '01' ")
            strSQL.Append("), ")
            '2016/02/02 w.ganeko 2015�J�����P ��2 END
            '2015/02/19 T.Ono add 2014���P�J�� No15 START
            strSQL.Append("/* DUMMY */ ")
            strSQL.Append("E AS( ")
            strSQL.Append("SELECT :CLSI_CD AS CLI_CD ")
            strSQL.Append("FROM   DUAL  ")
            strSQL.Append(") ")
            '2015/02/19 T.Ono add 2014���P�J�� No15 START
            'strSQL.Append("SELECT NVL(A.FAXKBN, NVL(B.FAXKBN, NVL(C.FAXKBN, NVL(D.FAXKBN, '0')))) AS FAXKBN , ")
            'strSQL.Append("       NVL(A.FAXKURAKBN, NVL(B.FAXKURAKBN, NVL(C.FAXKURAKBN, NVL(D.FAXKURAKBN, '0')))) AS FAXKURAKBN, ")
            'strSQL.Append("       NVL(A.GUIDELINE, NVL(B.GUIDELINE, NVL(C.GUIDELINE, NVL(D.GUIDELINE, '')))) AS GUIDELINE ")
            'strSQL.Append("FROM   A, B, C, D, E ")
            '2016/02/02 w.ganeko 2015�J�����P ��2 START
            'strSQL.Append("SELECT NVL(A.FAXKBN, NVL(B.FAXKBN, NVL(C.FAXKBN, NVL(D.FAXKBN, NVL(K.FAXKBN, '0'))))) AS FAXKBN , ")
            'strSQL.Append("       NVL(A.FAXKURAKBN, NVL(B.FAXKURAKBN, NVL(C.FAXKURAKBN, NVL(D.FAXKURAKBN, NVL(K.FAXKURAKBN, '0'))))) AS FAXKURAKBN, ")
            'strSQL.Append("       NVL(A.GUIDELINE, NVL(B.GUIDELINE, NVL(C.GUIDELINE, NVL(D.GUIDELINE, '')))) AS GUIDELINE, ")
            'strSQL.Append("       K.GUIDELINECL ")
            'strSQL.Append("FROM   A, B, C, D, K, E ")
            '2015/02/19 T.Ono add 2014���P�J�� No15 START
            strSQL.Append("SELECT NVL(A.FAXKBN, NVL(B.FAXKBN, NVL(C.FAXKBN, NVL(K.FAXKBN, '0')))) AS FAXKBN , ")
            strSQL.Append("       NVL(A.FAXKURAKBN, NVL(B.FAXKURAKBN, NVL(C.FAXKURAKBN, NVL(K.FAXKURAKBN, '0')))) AS FAXKURAKBN, ")
            strSQL.Append("       NVL(A.GUIDELINE, NVL(B.GUIDELINE, NVL(C.GUIDELINE, ''))) AS GUIDELINE, ")
            strSQL.Append("       NVL(A.GUIDELINE2, NVL(B.GUIDELINE2, NVL(C.GUIDELINE2, ''))) AS GUIDELINE2, ")  '2019/11/01 W.GANEKO 2019�Ď����P No8-12
            strSQL.Append("       NVL(A.GUIDELINE3, NVL(B.GUIDELINE3, NVL(C.GUIDELINE3, ''))) AS GUIDELINE3, ")  '2019/11/01 W.GANEKO 2019�Ď����P No8-12
            strSQL.Append("       K.GUIDELINECL ")
            strSQL.Append("       ,K.GUIDELINECL2 ")   '2019/11/01 W.GANEKO 2019�Ď����P No8-12
            strSQL.Append("       ,K.GUIDELINECL3 ")   '2019/11/01 W.GANEKO 2019�Ď����P No8-12
            strSQL.Append("       ,NVL(A.GUIDELINENM1, NVL(B.GUIDELINENM1, NVL(C.GUIDELINENM1, 'JA���ӎ���1'))) AS GUIDELINENM1 ") �@�@�@�@�@'2020/11/01 T.Ono 2020�Ď����P
            strSQL.Append("       ,NVL(A.GUIDELINENM2, NVL(B.GUIDELINENM2, NVL(C.GUIDELINENM2, 'JA���ӎ���2'))) AS GUIDELINENM2 ") �@�@�@�@�@'2020/11/01 T.Ono 2020�Ď����P
            strSQL.Append("       ,NVL(A.GUIDELINENM3, NVL(B.GUIDELINENM3, NVL(C.GUIDELINENM3, 'JA���ӎ���3'))) AS GUIDELINENM3 ") �@�@�@�@�@'2020/11/01 T.Ono 2020�Ď����P
            strSQL.Append("       ,NVL(K.GUIDELINENMCL1, '�N���C�A���g1') AS GUIDELINENMCL1 ") '2020/11/01 T.Ono 2020�Ď����P
            strSQL.Append("       ,NVL(K.GUIDELINENMCL2, '�N���C�A���g2') AS GUIDELINENMCL2 ") '2020/11/01 T.Ono 2020�Ď����P
            strSQL.Append("       ,NVL(K.GUIDELINENMCL3, '�N���C�A���g3') AS GUIDELINENMCL3 ") '2020/11/01 T.Ono 2020�Ď����P
            strSQL.Append("FROM   A, B, C, K, E ")
            '2016/02/02 w.ganeko 2015�J�����P ��2 END
            strSQL.Append("WHERE  E.CLI_CD = A.KURACD(+) ")
            strSQL.Append("AND    E.CLI_CD = B.KURACD(+) ")
            strSQL.Append("AND    E.CLI_CD = C.KURACD(+) ")
            'strSQL.Append("AND    E.CLI_CD = D.KURACD(+) ") 2016/02/02 w.ganeko 2015�J�����P ��2
            strSQL.Append("AND    E.CLI_CD = K.KURACD(+) ") '2015/02/19 T.Ono add 2014���P�J�� No15

            SqlParamC = New CSQLParam()
            SqlParamC.fncSetParam("CLSI_CD", True, KETAIJAG00C.pPRAM_CLI)
            SqlParamC.fncSetParam("HAN_CD", True, KETAIJAG00C.pPRAM_JASS)
            'SqlParamC.fncSetParam("JA_CD", True, strJACD) 2016/02/02 w.ganeko 2015�J�����P ��2
            SqlParamC.fncSetParam("USER_CD", True, KETAIJAG00C.pPRAM_JUYOKA)
            'mlog(strSQL.ToString & " CLSI_CD=" & KETAIJAG00C.pPRAM_CLI & " HAN_CD=" & KETAIJAG00C.pPRAM_JASS & " USER_CD=" & KETAIJAG00C.pPRAM_JUYOKA)
            '//SQL�̎��s
            dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

            If Convert.ToString(dbData.Tables(0).Rows(0).Item("FAXKBN")) <> "XYZ" Then
                '//�f�[�^���o�͂��܂�
                strFAXKBN = Convert.ToString(dbData.Tables(0).Rows(0).Item("FAXKBN"))
                strFAXKURAKBN = Convert.ToString(dbData.Tables(0).Rows(0).Item("FAXKURAKBN"))
                strGUIDELINE = Convert.ToString(dbData.Tables(0).Rows(0).Item("GUIDELINE")).Replace(ControlChars.Lf, "").Replace("'", ControlChars.Quote)
                strMsg.Append("parent.Data.Form1.txtGuideline.value = '" & strGUIDELINE & "';")
                '2015/02/19 T.Ono add 2014���P�J�� No15 START
                strGUIDELINECL = Convert.ToString(dbData.Tables(0).Rows(0).Item("GUIDELINECL")).Replace(ControlChars.Lf, "").Replace("'", ControlChars.Quote)
                strMsg.Append("parent.Data.Form1.txtGuidelineCL.value = '" & strGUIDELINECL & "';")
                '2015/02/19 T.Ono add 2014���P�J�� No15 END
                '2019/11/01 W.GANEKO 2019�Ď����P No8-12 START
                strGUIDELINE2 = Convert.ToString(dbData.Tables(0).Rows(0).Item("GUIDELINE2")).Replace(ControlChars.Lf, "").Replace("'", ControlChars.Quote)
                strGUIDELINE3 = Convert.ToString(dbData.Tables(0).Rows(0).Item("GUIDELINE3")).Replace(ControlChars.Lf, "").Replace("'", ControlChars.Quote)
                strGUIDELINECL2 = Convert.ToString(dbData.Tables(0).Rows(0).Item("GUIDELINECL2")).Replace(ControlChars.Lf, "").Replace("'", ControlChars.Quote)
                strGUIDELINECL3 = Convert.ToString(dbData.Tables(0).Rows(0).Item("GUIDELINECL3")).Replace(ControlChars.Lf, "").Replace("'", ControlChars.Quote)
                strMsg.Append("parent.Data.Form1.txtGuideline2.value = '" & strGUIDELINE2 & "';")
                strMsg.Append("parent.Data.Form1.txtGuideline3.value = '" & strGUIDELINE3 & "';")
                strMsg.Append("parent.Data.Form1.txtGuidelineCL2.value = '" & strGUIDELINECL2 & "';")
                strMsg.Append("parent.Data.Form1.txtGuidelineCL3.value = '" & strGUIDELINECL3 & "';")
                '2019/11/01 W.GANEKO 2019�Ď����P No8-12 END
                '2020/11/01 T.Ono 2020�Ď����P Strat
                strGUIDELINENM1 = Convert.ToString(dbData.Tables(0).Rows(0).Item("GUIDELINENM1")).Trim
                strGUIDELINENM2 = Convert.ToString(dbData.Tables(0).Rows(0).Item("GUIDELINENM2")).Trim
                strGUIDELINENM3 = Convert.ToString(dbData.Tables(0).Rows(0).Item("GUIDELINENM3")).Trim
                strGUIDELINENMCL1 = Convert.ToString(dbData.Tables(0).Rows(0).Item("GUIDELINENMCL1")).Trim
                strGUIDELINENMCL2 = Convert.ToString(dbData.Tables(0).Rows(0).Item("GUIDELINENMCL2")).Trim
                strGUIDELINENMCL3 = Convert.ToString(dbData.Tables(0).Rows(0).Item("GUIDELINENMCL3")).Trim
                strMsg.Append("parent.Data.Form1.txtGuidelineNM1.value = '" & strGUIDELINENM1 & "';")
                strMsg.Append("parent.Data.Form1.txtGuidelineNM2.value = '" & strGUIDELINENM2 & "';")
                strMsg.Append("parent.Data.Form1.txtGuidelineNM3.value = '" & strGUIDELINENM3 & "';")
                strMsg.Append("parent.Data.Form1.txtGuidelineNMCL1.value = '" & strGUIDELINENMCL1 & "';")
                strMsg.Append("parent.Data.Form1.txtGuidelineNMCL2.value = '" & strGUIDELINENMCL2 & "';")
                strMsg.Append("parent.Data.Form1.txtGuidelineNMCL3.value = '" & strGUIDELINENMCL3 & "';")
                '2020/11/01 T.Ono 2020�Ď����P End
            Else
                '//�f�[�^�����������܂�
                strFAXKBN = "0"
                strFAXKURAKBN = "0"
                strGUIDELINE = ""
                strGUIDELINECL = "" '2015/02/19 T.Ono add 2014���P�J�� No15
                strMsg.Append("parent.Data.Form1.txtGuideline.value = '';")
                strMsg.Append("parent.Data.Form1.txtGuidelineCL.value = '';") '2015/02/19 T.Ono add 2014���P�J�� No15
                strMsg.Append("parent.Data.Form1.txtGuideline2.value = '';")   '2019/11/01 W.GANEKO 2019�Ď����P No8-12
                strMsg.Append("parent.Data.Form1.txtGuidelineCL2.value = '';") '2019/11/01 W.GANEKO 2019�Ď����P No8-12
                strMsg.Append("parent.Data.Form1.txtGuideline3.value = '';")   '2019/11/01 W.GANEKO 2019�Ď����P No8-12
                strMsg.Append("parent.Data.Form1.txtGuidelineCL3.value = '';") '2019/11/01 W.GANEKO 2019�Ď����P No8-12
                '2020/11/01 T.Ono 2020�Ď����P Strat
                strMsg.Append("parent.Data.Form1.txtGuidelineNM1.value = 'JA���ӎ���1';")
                strMsg.Append("parent.Data.Form1.txtGuidelineNM2.value = 'JA���ӎ���2';")
                strMsg.Append("parent.Data.Form1.txtGuidelineNM3.value = 'JA���ӎ���3';")
                strMsg.Append("parent.Data.Form1.txtGuidelineNMCL1.value = '�N���C�A���g1';")
                strMsg.Append("parent.Data.Form1.txtGuidelineNMCL2.value = '�N���C�A���g2';")
                strMsg.Append("parent.Data.Form1.txtGuidelineNMCL3.value = '�N���C�A���g3';")
                '2020/11/01 T.Ono 2020�Ď����P End
            End If
            strMsg.Append("parent.Data.Form1.txtGuideline.onchange();")
            strMsg.Append("parent.Data.Form1.txtGuidelineCL.onchange();") '2015/02/19 T.Ono add 2014���P�J�� No15
            '������ 2013/08/07 T.Ono mod �ڋq�P�ʓo�^�@�\�ǉ� ������

            ''2015/02/19 T.Ono del 2014���P�J�� No15 ���FAXKBN���擾�����ɓ���
            ''������ 2013/06/25 T.Ono add ���ӎ����i�N���C�A���g�j���擾 ������
            'strSQL = New StringBuilder("")
            'strSQL.Append("SELECT  ")
            'strSQL.Append("  M05.GUIDELINE AS GUIDELINE_CL ")
            'strSQL.Append("FROM  M05_TANTO M05  ")
            'strSQL.Append("WHERE M05.KBN   = '3'  ")
            'strSQL.Append("  AND M05.TANCD = '01'  ")
            'strSQL.Append("  AND TRIM(M05.GUIDELINE) IS NOT NULL  ")
            'strSQL.Append("  AND M05.KURACD = :CLSI_CD  ")
            'strSQL.Append("  AND M05.CODE   = 'XXXX' ")

            ''�p�����[�^�̃Z�b�g
            'SqlParamC = New CSQLParam()
            'SqlParamC.fncSetParam("CLSI_CD", True, KETAIJAG00C.pPRAM_CLI)

            ''//SQL�̎��s
            'dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

            'If Convert.ToString(dbData.Tables(0).Rows(0).Item("GUIDELINE_CL")) <> "XYZ" Then
            '    '//�f�[�^���o�͂��܂�
            '    Dim guideline As String = Convert.ToString(dbData.Tables(0).Rows(0).Item("GUIDELINE_CL")).Replace(ControlChars.Lf, "").Replace("'", ControlChars.Quote)
            '    strMsg.Append("parent.Data.Form1.txtGuidelineCL.value = '" & guideline & "';")
            'Else
            '    '//�f�[�^�����������܂�
            '    strMsg.Append("parent.Data.Form1.txtGuidelineCL.value = '';")
            'End If
            'strMsg.Append("parent.Data.Form1.txtGuidelineCL.onchange();")
            ''������ 2013/06/25 T.Ono add ���ӎ����i�N���C�A���g�j���擾 ������


            Dim backurl As String = Request.Form("hdnBackUrl")
            If backurl <> "KEKEKJAG00" Then
                '������ 2013/08/07 T.Ono mod �ڋq�P�ʓo�^�@�\�ǉ� ������
                ''������ 2011.11.28 ADD h.uema FAX�s�v�t���O(�ײ���)���擾 ********** ������
                ''//�S���}�X�^����FAX�s�v�t���O(�ײ���)���擾����
                'strSQL = New StringBuilder("")
                'strSQL.Append("SELECT ")
                'strSQL.Append("  DECODE(M05.CODE, :HAN_CD, '0', '1') AS SORT ")
                'strSQL.Append("  ,M05.FAXKURAKBN ")
                'strSQL.Append("FROM M05_TANTO M05 ")
                'strSQL.Append("WHERE M05.KBN = '3' ")
                'strSQL.Append("  AND M05.TANCD = '01' ")
                'strSQL.Append("  AND TRIM(M05.FAXKURAKBN) IS NOT NULL ")
                'strSQL.Append("  AND M05.KURACD = :CLSI_CD ")
                'strSQL.Append("  AND M05.CODE IN (:HAN_CD, :JA_CD) ")
                'strSQL.Append("ORDER BY SORT ")

                ''�p�����[�^�̃Z�b�g
                'SqlParamC = New CSQLParam()                 '2012/05/28 NEC Add
                'SqlParamC.fncSetParam("CLSI_CD", True, KETAIJAG00C.pPRAM_CLI)
                'SqlParamC.fncSetParam("HAN_CD", True, KETAIJAG00C.pPRAM_JASS)
                'SqlParamC.fncSetParam("JA_CD", True, strJACD)

                ''//SQL�̎��s
                'dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)


                'If Convert.ToString(dbData.Tables(0).Rows(0).Item("FAXKURAKBN")) = "1" Then
                '    '//�f�[�^���o�͂��܂�
                '    strMsg.Append("parent.Data.Form1.chkFAXKURAKBN.checked = true;")
                'Else
                '    '//�f�[�^���o�͂��܂�
                '    strMsg.Append("parent.Data.Form1.chkFAXKURAKBN.checked = false;")
                'End If
                ''������ 2011.11.28 ADD h.uema FAX�s�v�t���O(�ײ���)���擾 ********** ������

                ''������ 2011.12.01 ADD h.uema FAX�s�v�t���O(JA)���擾 ********** ������
                ''//�S���}�X�^����FAX�s�v�t���O(JA)���擾����
                'strSQL = New StringBuilder("")
                'strSQL.Append("SELECT ")
                'strSQL.Append("  DECODE(M05.CODE, :HAN_CD, '0', '1') AS SORT ")
                'strSQL.Append("  ,M05.FAXKBN ")
                'strSQL.Append("FROM M05_TANTO M05 ")
                'strSQL.Append("WHERE M05.KBN = '3' ")
                'strSQL.Append("  AND M05.TANCD = '01' ")
                'strSQL.Append("  AND TRIM(M05.FAXKBN) IS NOT NULL ")
                'strSQL.Append("  AND M05.KURACD = :CLSI_CD ")
                'strSQL.Append("  AND M05.CODE IN (:HAN_CD, :JA_CD) ")
                'strSQL.Append("ORDER BY SORT ")

                ''�p�����[�^�̃Z�b�g
                'SqlParamC = New CSQLParam()                 '2012/05/28 NEC Add
                'SqlParamC.fncSetParam("CLSI_CD", True, KETAIJAG00C.pPRAM_CLI)
                'SqlParamC.fncSetParam("HAN_CD", True, KETAIJAG00C.pPRAM_JASS)
                'SqlParamC.fncSetParam("JA_CD", True, strJACD)

                ''//SQL�̎��s
                'dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

                'If Convert.ToString(dbData.Tables(0).Rows(0).Item("FAXKBN")) = "1" Then
                '    '//�f�[�^���o�͂��܂�
                '    strMsg.Append("parent.Data.Form1.chkFAXKBN.checked = true;")
                'Else
                '    '//�f�[�^���o�͂��܂�
                '    strMsg.Append("parent.Data.Form1.chkFAXKBN.checked = false;")
                'End If
                ''������ 2011.12.01 ADD h.uema FAX�s�v�t���O(JA)���擾 ********** ������
                '�S���}�X�^����FAX�s�v�t���O(JA)���擾����
                If strFAXKBN = "1" Then
                    '//�f�[�^���o�͂��܂�
                    strMsg.Append("parent.Data.Form1.chkFAXKBN.checked = true;")
                Else
                    '//�f�[�^���o�͂��܂�
                    strMsg.Append("parent.Data.Form1.chkFAXKBN.checked = false;")
                End If

                '�S���}�X�^����FAX�s�v�t���O(�ײ���)���擾����
                If strFAXKURAKBN = "1" Then
                    '//�f�[�^���o�͂��܂�
                    strMsg.Append("parent.Data.Form1.chkFAXKURAKBN.checked = true;")
                Else
                    '//�f�[�^���o�͂��܂�
                    strMsg.Append("parent.Data.Form1.chkFAXKURAKBN.checked = false;")
                End If
                '������ 2013/08/07 T.Ono mod �ڋq�P�ʓo�^�@�\�ǉ� ������

                '2014/02/10 T.Ono add �Ď����P2013
                '�d���\���Ώۂ̌x��̏ꍇ�́A�񍐕s�v�Ƀ`�F�b�N������
                If backurl = "KEJUKJAG00" AndAlso KETAIJAG00C.pPRAM_choufukuhyouji = "1" Then
                    strMsg.Append("parent.Data.Form1.chkFAXKBN.checked = true;")
                    strMsg.Append("parent.Data.Form1.chkFAXKURAKBN.checked = true;")
                    strMsg.Append("parent.Data.Form1.chkFAXRUISEKIKBN.checked = true;") '2015/12/21 H.Mori add �Ď����P2015
                End If
            End If


        Catch ex As Exception
            Dim ErrMsgC As New CErrMsg
            strMsg.Append("alert('�V�X�e���G���[�F" & ErrMsgC.mGetArtMsg(ex.ToString) & "');")
            strRec = "ERROR"
            '--- ��2005/04/24 MOD Falcon�� ---
        Finally
            If dbData Is Nothing Then
            Else
                dbData.Dispose()
            End If
            '--- ��2005/04/24 MOD Falcon�� ---
        End Try

        '���b�N�����A����{�^�����g�p�\�ɂ���
        strMsg.Append("parent.Data.Form1.btnRenraku.disabled = false;")
        '�o����Џ��E�i�`���̎擾���s���ׁA�o�^�{�^�������b�N����
        strMsg.Append("parent.Data.Form1.btnUpdate.disabled = false;")

        '--- ��2005/04/24 DEL Falcon�� ---
        'dbData.Dispose()
        '--- ��2005/04/24 DEL Falcon�� ---

        Return strRec
    End Function
    '**********************************************************
    ' 2012/06/28 ADD W.GANEKO
    '���O�f���o��
    '�߂�l�F�������񂾃t�@�C���ւ̃t���p�X
    '**********************************************************
    Public Sub mlog(ByVal pstrString As String)
        Dim strFilnm As String = "log" & System.DateTime.Today.ToString("yyyyMMdd")
        Dim strLogPath As String = ConfigurationSettings.AppSettings("LOG_OUT_PATH")
        Dim strPath As String = strLogPath & strFilnm & ".txt"
        Dim strLogFlg As String = ConfigurationSettings.AppSettings("LOG_OUT")
        Dim linestring As New StringBuilder("")
        Dim LogC As New CLog

        Dim strRecLog As String
        If strLogFlg = "1" Then
            '�������݃t�@�C���ւ̃X�g���[��
            'Dim sw As StreamWriter
            'Dim fs As New FileStream(strPath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite)
            'linestring = New StringBuilder("")
            'linestring.Append(System.DateTime.Now & "." & System.DateTime.Now.Millisecond & "[" & AuthC.pUSERNAME & "][" & AuthC.pIPADDRESS & "][" & Me.Session.SessionID & "]" & pstrString & Chr(13) & Chr(10))
            Dim tbllog As String = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff") & " " & pstrString
            strRecLog = LogC.mAPLog(Me.Session.SessionID, AuthC.pUSERNAME, AuthC.pIPADDRESS, Request.Form("hdnMyAspx"), "4", tbllog, Request.Form)
            'sw = New StreamWriter(fs, System.Text.Encoding.Default)

            ''�����̕�������X�g���[���ɏ�������
            'sw.Write(linestring.ToString)

            ''�������t���b�V���i�t�@�C���������݁j
            ''sw.Flush()

            ''�t�@�C���N���[�Y
            'sw.Close()
            'sw.Dispose()
            'fs.Close()
            'fs.Dispose()
        End If
    End Sub
    '******************************************************************************
    ' �̔����Ǝ҂��擾
    ' 2014/12/19 T.Ono add 2014���P�J�� No2
    '******************************************************************************
    Private Function fncGetData_HANGRP() As String
        Dim SQLC As New KETAIJAG00CSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet

        Dim KETAIJAG00C As KETAIJAG00
        KETAIJAG00C = CType(Context.Handler, KETAIJAG00)

        Dim strRec As String
        Dim intRow As Integer
        strRec = "OK"

        Try
            '//�I�����ꂽ�i�`�x���R�[�h���[�̔����Ǝ�CD][�̔����ƎҖ�]��
            '//Hidden�ɐݒ肷��
            strSQL = New StringBuilder("")
            strSQL.Append("SELECT ")
            strSQL.Append(" HN.JA_CD ")
            strSQL.Append(" ,HN.JA_NAME ")
            strSQL.Append(" ,HN.JAS_NAME ")
            strSQL.Append(" ,NVL(H3.GROUPCD, NVL(H2.GROUPCD, NVL(H1.GROUPCD, ''))) AS HANJICD ") '�̔����Ǝ҃R�[�h
            strSQL.Append(" ,NVL2(H3.GROUPCD, H3.HANJIGYOSYANM, NVL2(H2.GROUPCD, H2.HANJIGYOSYANM ,NVL2(H1.GROUPCD, H1.HANJIGYOSYANM,''))) AS HANJINM ") '�̔����ƎҖ�
            strSQL.Append("FROM HN2MAS HN ")
            strSQL.Append(" ,M09_JAGROUP G1 ")      'JA�x��
            strSQL.Append(" ,M10_HANJIGYOSYA H1 ")
            strSQL.Append(" ,M09_JAGROUP G2 ")      '���[�U�[�͈�
            strSQL.Append(" ,M10_HANJIGYOSYA H2 ")
            strSQL.Append(" ,M09_JAGROUP G3 ")      '���[�U�[��
            strSQL.Append(" ,M10_HANJIGYOSYA H3 ")
            strSQL.Append("WHERE HN.CLI_CD = :CLSI_CD ")
            strSQL.Append("AND HN.HAN_CD = :HAN_CD ")
            'JA�x��
            strSQL.Append("AND G1.KBN(+) = '001' ")
            strSQL.Append("AND G1.KURACD(+) = HN.CLI_CD ")
            strSQL.Append("AND G1.ACBCD(+) = HN.HAN_CD ")
            strSQL.Append("AND G1.USERCD_FROM(+) IS NULL ")
            strSQL.Append("AND G1.USERCD_TO(+) IS NULL ")
            strSQL.Append("AND G1.GROUPCD = H1.GROUPCD(+) ")
            '���[�U�[�͈�
            strSQL.Append("AND G2.KBN(+) = '001' ")
            strSQL.Append("AND G2.KURACD(+) = HN.CLI_CD ")
            strSQL.Append("AND G2.ACBCD(+) = HN.HAN_CD ")
            strSQL.Append("AND :USER_CD BETWEEN G2.USERCD_FROM(+) AND G2.USERCD_TO(+) ")
            strSQL.Append("AND G2.USERCD_TO(+) IS NOT NULL ")
            strSQL.Append("AND G2.GROUPCD = H2.GROUPCD(+) ")
            '���[�U�[��
            strSQL.Append("AND G3.KBN(+) = '001' ")
            strSQL.Append("AND G3.KURACD(+) = HN.CLI_CD ")
            strSQL.Append("AND G3.ACBCD(+) = HN.HAN_CD ")
            strSQL.Append("AND G3.USERCD_FROM(+) = :USER_CD ")
            strSQL.Append("AND G3.USERCD_TO(+) IS NULL ")
            strSQL.Append("AND G3.GROUPCD = H3.GROUPCD(+) ")

            '�p�����[�^�̃Z�b�g
            SqlParamC.fncSetParam("CLSI_CD", True, KETAIJAG00C.pPRAM_CLI)
            SqlParamC.fncSetParam("HAN_CD", True, KETAIJAG00C.pPRAM_JASS)
            SqlParamC.fncSetParam("USER_CD", True, KETAIJAG00C.pPRAM_JUYOKA)
            '//SQL�̎��s
            dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)
            '//�f�[�^�̎擾
            If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
                strMsg.Append("parent.Data.Form1.hdnHANJICD.value='';")           '�̔����Ǝ҃R�[�h
                strMsg.Append("parent.Data.Form1.hdnHANJINM.value='';")           '�̔����ƎҖ�
                strMsg.Append("parent.Data.Form1.txtHANGRP.value='';")            '�̔����Ǝ�(���)
            Else
                strMsg.Append("parent.Data.Form1.hdnHANJICD.value='" & Convert.ToString(dbData.Tables(0).Rows(intRow).Item("HANJICD")) & "';")
                strMsg.Append("parent.Data.Form1.hdnHANJINM.value='" & Convert.ToString(dbData.Tables(0).Rows(intRow).Item("HANJINM")) & "';")
                strMsg.Append("parent.Data.Form1.txtHANGRP.value='" & _
                              Convert.ToString(dbData.Tables(0).Rows(intRow).Item("HANJICD")) & " : " & Convert.ToString(dbData.Tables(0).Rows(intRow).Item("HANJINM")) & "';")

            End If


        Catch ex As Exception
            Dim ErrMsgC As New CErrMsg
            strMsg.Append("alert('�V�X�e���G���[�F" & ErrMsgC.mGetArtMsg(ex.ToString) & "');")
            strRec = "ERROR"
        Finally
            If dbData Is Nothing Then
            Else
                dbData.Dispose()
            End If
        End Try
        Return strRec
    End Function

    '******************************************************************************
    ' 
    '******************************************************************************
    Private Function fncGetData_TIME(ByVal strFLG As String) As String
        ''Dim DateFncC As New CDateFnc
        Dim TimeFncC As New CTimeFnc

        Select Case strFLG
            Case "KETAIJKG00_TKN"
                '//�Ή��������ɓ��t�Z�b�g
                strMsg.Append("with(parent.Data.Form1){")
                strMsg.Append("if(txtSYOYMD.value==''){")
                strMsg.Append("txtSYOYMD.value = '" & Now.ToString("yyyyMMdd") & "';")
                strMsg.Append("}")
                strMsg.Append("if(txtSYOTIME.value==''){")
                strMsg.Append("txtSYOTIME.value = '" & TimeFncC.mGet(Now.ToString("HHmmss"), 1) & "';")
                strMsg.Append("}")
                strMsg.Append("txtSYOYMD.focus();")
                strMsg.Append("}")

            Case "KETAIJKG00_SSJ"
                '//�o���w�����ɓ��t�Z�b�g
                strMsg.Append("with(parent.Data.Form1){")
                strMsg.Append("if(txtSIJIYMD.value==''){")
                strMsg.Append("txtSIJIYMD.value = '" & Now.ToString("yyyyMMdd") & "';")
                strMsg.Append("}")
                strMsg.Append("if(txtSIJITIME.value==''){")
                strMsg.Append("txtSIJITIME.value = '" & TimeFncC.mGet(Now.ToString("HHmmss"), 1) & "';")
                strMsg.Append("}")
                strMsg.Append("txtSIJIYMD.focus();")
                strMsg.Append("}")

        End Select

    End Function
    '******************************************************************************
    ' �B�d�b�ԍ����炨�q�l���Ȃǂ��擾����
    '******************************************************************************
    Private Function fncGetData_CUS() As String
        Dim SQLC As New KETAIJAG00CSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet

        Dim KETAIJAG00C As KETAIJAG00
        KETAIJAG00C = CType(Context.Handler, KETAIJAG00)

        Dim intRow As Integer
        Dim strRec As String

        strRec = "OK"
        Try
            '//�o����Џ��̎擾
            strSQL = New StringBuilder("")
            strSQL.Append("SELECT  ")
            strSQL.Append("CL.KANSI_CODE, ")
            strSQL.Append("CL.KEN_NAME ")
            strSQL.Append("FROM CLIMAS CL ")
            strSQL.Append("WHERE  ")
            strSQL.Append("    CL.TELA = :TEL1 ")
            strSQL.Append("AND CL.TELB = :TEL2 ")

            '�p�����[�^�̃Z�b�g
            SqlParamC.fncSetParam("TEL1", True, KETAIJAG00C.pPRAM_TEL1)
            SqlParamC.fncSetParam("TEL2", True, KETAIJAG00C.pPRAM_TEL2)

            '//SQL�̎��s
            dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

            If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
            Else
                '//�f�[�^���o�͂��܂�
                strMsg.Append("parent.Data.Form1.hdnKANSCD.value='" & Convert.ToString(dbData.Tables(0).Rows(0).Item("KANSI_CODE")) & "';")
                strMsg.Append("parent.Data.Form1.txtKENNM.value='" & Convert.ToString(dbData.Tables(0).Rows(0).Item("KEN_NAME")) & "';")
            End If

        Catch ex As Exception
            Dim ErrMsgC As New CErrMsg
            strMsg.Append("alert('�V�X�e���G���[�F" & ErrMsgC.mGetArtMsg(ex.ToString) & "');")
            strRec = "ERROR"

            '--- ��2005/04/24 MOD Falcon�� ---
        Finally
            If dbData Is Nothing Then
            Else
                dbData.Dispose()
            End If
            '--- ��2005/04/24 MOD Falcon�� ---
        End Try

        '--- ��2005/04/24 DEL Falcon�� ---
        'dbData.Dispose()
        '--- ��2005/04/24 DEL Falcon�� ---

        Return strRec
    End Function
    '******************************************************************************
    ' 2017/10/18 H.Mori add 2017���P�J�� No4-3
    ' ���b�N���[�U�[�m�F
    '******************************************************************************
    Private Function fncGetRoc_USER(ByVal strFLG As String) As String
        Dim SQLC As New KETAIJAG00CSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet
        Dim strRes As String

        Dim KETAIJAG00C As KETAIJAG00
        KETAIJAG00C = CType(Context.Handler, KETAIJAG00)

        Dim strRec As String

        strRec = "OK"
        Try
            strSQL.Append("SELECT ")
            strSQL.Append("KEI.ROC_USER ")
            strSQL.Append("FROM T10_KEIHO KEI ")
            strSQL.Append("WHERE  ")
            strSQL.Append("    KEI.SYORI_SERIAL = :SYORI_SERIAL ")

            '�p�����[�^�̃Z�b�g
            SqlParamC.fncSetParam("SYORI_SERIAL", True, KETAIJAG00C.pMoveSerial)

            '//SQL�̎��s
            dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)
            strRes = Convert.ToString(dbData.Tables(0).Rows(0).Item("ROC_USER"))

            If strRes <> AuthC.pUSERNAME Then
                strMsg.Append("alert('���x�񁡁��������������������������������������������������������������������������������������������������������������������@ \n\n\n\n\n\n\n\n\n\n\n\n\n\n\n �@���̃��[�U�[���Ή����ł��B�m�F���Ă��������B \n\n\n\n\n\n\n\n\n\n\n\n\n\n\n �����������������������������������������������������������������������������������������������������������������������������@');")
            End If

            Select Case strFLG
                Case "KETAIJKG00_ROC_btnTelHas1"
                    strMsg.Append("parent.Data.btnDial_onclick('1',parent.Data.Form1.txtRENTEL.value,parent.Data.Form1.txtJUSYONM.value);")
                Case "KETAIJKG00_ROC_btnTelHas2"
                    strMsg.Append("parent.Data.btnRenraku_onclick('3');")
                Case "KETAIJKG00_ROC_btnRenraku"
                    strMsg.Append("parent.Data.btnRenraku_onclick('2');")
                Case "KETAIJKG00_ROC_btnTKTANCD"
                    strMsg.Append("parent.Data.btnPopup_onclick('3');")
            End Select

        Catch ex As Exception
            Dim ErrMsgC As New CErrMsg
            strMsg.Append("alert('�V�X�e���G���[�F" & ErrMsgC.mGetArtMsg(ex.ToString) & "');")
            strRec = "ERROR"

        Finally
            If dbData Is Nothing Then
            Else
                dbData.Dispose()
            End If
        End Try

        Return strRec
    End Function
End Class
