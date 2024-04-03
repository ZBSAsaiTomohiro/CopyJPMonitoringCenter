'***********************************************
'�A������
'***********************************************
Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common

Imports System.Text

Partial Class SDSYUJTG00
    Inherits System.Web.UI.Page
    'Protected WithEvents txtDENWABIKO As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnTelHas As System.Web.UI.HtmlControls.HtmlInputButton
    '--- ��2005/04/25 ADD Falcon�� ---

    '<TODO>�錾���ʎd�l
    '******************************************************************************
    ' HttpHeader
    '******************************************************************************
    Protected HttpHeaderC As New CHttpHeader

    '<TODO>�錾���ʎd�l
    '******************************************************************************
    ' �F�؃N���X
    '******************************************************************************
    'Protected AuthC As CAuthenticate

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

        strWrite.Append("<!-- Render -->")
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
        'AuthC = New CAuthenticate(Request, Response)

        '//------------------------------------------
        '//�@�F�؏���
        '<TODO>�F�g�p�\�������w�肷��
        '�g�p�\����(�^:��/�c:�~/��:��/�o:�~)
        '[�Ή�����]�g�p�\����(�^:��/�c:��/��:��/�o:�~)
        'AuthC.fncAuthCheck(Server, AuthC.pGROUP_UNKOU & "," & AuthC.pGROUP_KANSHI & "," & AuthC.pGROUP_EIGYOU)

        '�O��ʂ�������擾
        Dim SDSYUJAG00C As SDSYUJAG00
        SDSYUJAG00C = CType(Context.Handler, SDSYUJAG00)
        hdnKURACD.Value = SDSYUJAG00C.pPRAM_KURACD
        hdnACBCD.Value = SDSYUJAG00C.pPRAM_JASCD
        ' 2013/07/01 T.Ono add
        hdnKANSCD.Value = SDSYUJAG00C.pPRAM_KANSCD   '�Ď��Z���^�[�R�[�h
        hdnSYONO.Value = SDSYUJAG00C.pPRAM_SYONO     '�����ԍ�

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
             MyBase.MapPath("../../../SD/SDSYUJAG/SDSYUJAG00/") & "SDSYUJTG00.js"))
        '<�t�H�[�J�X�֘A�֐�>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncFo.js"))
        '<���̓`�F�b�N�֐�>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncChk.js"))
        '<�d�b�ԍ��`�F�b�N�֐�>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncTel.js"))
        '<�o�C�g���֐�>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncGetByte.js"))
        '<�S�p�`�F�b�N�֐�>
        strScript.Append(strScript.Append("</Script>"))
        '//------------------------------------------
        '//�@Css�i�[
        strScript.Append("<Style>")
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "CssSmall.css"))
        strScript.Append("</Style>")
        '//------------------------------------------
        '//�@Script������
        lblScript.Text = strScript.ToString


        '//------------------------------------
        Dim SQLC As New SDSYUJAG00CSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet
        Try
            'If MyBase.IsPostBack = False Then
            '//�Ή����͉�ʂ̏����󂯎�� ---
            Call GetSDSYUJAG00()
            '//--------------------------------
            strSQL = New StringBuilder("")
            strSQL.Append("SELECT  ")
            strSQL.Append("JA.JA_NAME, ")
            strSQL.Append("JA.JAS_NAME, ")
            strSQL.Append("JA.JA_KANA, ")
            strSQL.Append("JA.JAS_KANA ")
            strSQL.Append("FROM HN2MAS JA ")
            strSQL.Append("WHERE JA.CLI_CD = :CLSI_CD ")
            strSQL.Append("  AND JA.HAN_CD = :HAN_CD ")

            '�p�����[�^�̃Z�b�g
            SqlParamC.fncSetParam("CLSI_CD", True, hdnKURACD.Value)
            SqlParamC.fncSetParam("HAN_CD", True, hdnACBCD.Value)

            '//SQL�̎��s
            dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

            If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then

            Else
                '//���̏o��
                '����
                If Convert.ToString(dbData.Tables(0).Rows(0).Item("JA_NAME")).Length = 0 And Convert.ToString(dbData.Tables(0).Rows(0).Item("JAS_NAME")).Length = 0 Then
                    '�������݂��Ȃ�
                    txtACBNM.Text = ""
                ElseIf Convert.ToString(dbData.Tables(0).Rows(0).Item("JA_NAME")).Length > 0 And Convert.ToString(dbData.Tables(0).Rows(0).Item("JAS_NAME")).Length > 0 Then
                    '�������݂���
                    txtACBNM.Text = Convert.ToString(dbData.Tables(0).Rows(0).Item("JA_NAME")) & " / " & Convert.ToString(dbData.Tables(0).Rows(0).Item("JAS_NAME"))
                Else
                    '�ǂ��炩���݂���
                    txtACBNM.Text = Convert.ToString(dbData.Tables(0).Rows(0).Item("JA_NAME")) & Convert.ToString(dbData.Tables(0).Rows(0).Item("JAS_NAME"))
                End If
                '�J�i
                If Convert.ToString(dbData.Tables(0).Rows(0).Item("JA_KANA")).Length = 0 And Convert.ToString(dbData.Tables(0).Rows(0).Item("JAS_KANA")).Length = 0 Then
                    '�������݂��Ȃ�
                    txtACBKN.Text = ""
                ElseIf Convert.ToString(dbData.Tables(0).Rows(0).Item("JA_KANA")).Length > 0 And Convert.ToString(dbData.Tables(0).Rows(0).Item("JAS_KANA")).Length > 0 Then
                    '�������݂���
                    txtACBKN.Text = Convert.ToString(dbData.Tables(0).Rows(0).Item("JA_KANA")) & " / " & Convert.ToString(dbData.Tables(0).Rows(0).Item("JAS_KANA"))
                Else
                    '�ǂ��炩���݂���
                    txtACBKN.Text = Convert.ToString(dbData.Tables(0).Rows(0).Item("JA_KANA")) & Convert.ToString(dbData.Tables(0).Rows(0).Item("JAS_KANA"))
                End If

            End If
            'End If

            '�J�[�\���̃Z�b�g
            strMsg.Append("Form1.btnExit.focus();")

        Catch ex As Exception
            Dim ErrMsgC As New CErrMsg
            strMsg.Append("alert('�V�X�e���G���[�F" & ErrMsgC.mGetArtMsg(ex.ToString) & "');")

        Finally
            If dbData Is Nothing Then
            Else
                dbData.Dispose()
            End If
        End Try

    End Sub

    '--- ��2005/04/25 ADD Falcon�� ---
    '******************************************************************************
    '*�@�T�@�v�F
    '*�@���@�l�F
    '******************************************************************************
    Private Sub GetSDSYUJAG00()
        Dim UtilFucC As New CUtilFuc


        Dim intRow As Integer
        Dim intTan As Integer
        Dim strRec As String

        Dim strJACD As String ' 2007/09/18 T.Watabe add
        Dim existFlg As Boolean



        '//------------------------------------
        Dim SQLC As New SDSYUJAG00CSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim strSQL2 As New StringBuilder("") ' 2009/03/05 T.Watabe add
        Dim dbData As DataSet
        Dim TanMSKBN As String = "0"  ' 0:M05_TANTO2�o�^�Ȃ� 1:���q�lCD1�ł̓o�^ 2:���q�lCD�͈͂ł̓o�^

        Try
            TanMSKBN = fncCheckTANTO2() ' 2013/07/01 T.Ono add

            '//�f�[�^�̎擾
            '2016/02/10 H.Mori mod 2016���P�J�� START
            'strSQL = New StringBuilder("")
            'strSQL.Append("SELECT ")
            'strSQL.Append("    JA.JA_NAME, ")
            'strSQL.Append("    JA.JAS_NAME, ")
            'strSQL.Append("    TN.TANCD, ")
            'strSQL.Append("    TN.TANNM, ")
            'strSQL.Append("    TN.RENTEL1, ")
            'strSQL.Append("    TN.RENTEL2, ")
            'strSQL.Append("    TN.RENTEL3, ")                       '2013/06/28 T.Ono add �d�b�ԍ�3
            'strSQL.Append("    TN.FAXNO, ")
            'strSQL.Append("    TN.BIKO, ")
            'strSQL.Append("    TN.EDT_DATE, ")
            'strSQL.Append("    TN.TIME ")
            'strSQL.Append("FROM HN2MAS JA, ")
            '' ������ 2013/07/01 T.Ono mod �ڋq�P�ʓo�^�@�\�ǉ� ������
            ''strSQL.Append("     M05_TANTO TN ")
            'If TanMSKBN = "1" Or TanMSKBN = "2" Then
            '    strSQL.Append("     M05_TANTO2 TN, ")
            '    strSQL.Append("     D20_TAIOU TI ")
            'Else
            '    strSQL.Append("     M05_TANTO TN ")
            'End If
            '' ������ 2013/07/01 T.Ono mod �ڋq�P�ʓo�^�@�\�ǉ� ������
            'strSQL.Append("WHERE ")
            'strSQL.Append("      JA.CLI_CD = :CLSI_CD ")
            'strSQL.Append("  AND JA.HAN_CD = :HAN_CD ")
            'strSQL.Append("  AND JA.CLI_CD = TN.KURACD(+) ")
            'strSQL.Append("  AND JA.HAN_CD = TN.CODE(+) ")
            'strSQL.Append("  AND 0 <> TO_NUMBER(TN.TANCD) ")
            'strSQL.Append("  AND '3' = TN.KBN(+) ")
            '' ������ 2013/07/01 T.Ono mod �ڋq�P�ʓo�^�@�\�ǉ� ������
            'If TanMSKBN = "1" Then
            '    strSQL.Append("  AND TI.KANSCD = :KANSCD ")
            '    strSQL.Append("  AND TI.SYONO = :SYONO ")
            '    strSQL.Append("  AND TN.USER_CD_TO IS NULL ")
            '    strSQL.Append("  AND TI.USER_CD = TN.USER_CD_FROM ")
            'ElseIf TanMSKBN = "2" Then
            '    strSQL.Append("  AND TI.KANSCD = :KANSCD ")
            '    strSQL.Append("  AND TI.SYONO = :SYONO ")
            '    strSQL.Append("  AND TN.USER_CD_TO IS NOT NULL ")
            '    strSQL.Append("  AND TI.USER_CD BETWEEN TN.USER_CD_FROM AND TN.USER_CD_TO ")
            'End If
            '' ������ 2013/07/01 T.Ono mod �ڋq�P�ʓo�^�@�\�ǉ� ������
            'strSQL.Append("ORDER BY TO_NUMBER(TN.TANCD) ")
            strSQL = New StringBuilder("")
            strSQL.Append("SELECT ")
            strSQL.Append("    JA.JA_NAME, ")
            strSQL.Append("    JA.JAS_NAME, ")
            strSQL.Append("    M11.TANCD, ")
            strSQL.Append("    M11.TANNM, ")
            strSQL.Append("    M11.RENTEL1, ")
            strSQL.Append("    M11.RENTEL2, ")
            strSQL.Append("    M11.RENTEL3, ")
            strSQL.Append("    M11.FAXNO, ")
            strSQL.Append("    M11.SPOT_MAIL, ")                       '2019/08/02 W.GANEKO ADD
            strSQL.Append("    M11.BIKO, ")
            strSQL.Append("    TO_CHAR(M11.UPD_DATE,'YYYYMMDD') AS EDT_DATE, ")
            strSQL.Append("    TO_CHAR(M11.UPD_DATE,'HH24MISS') AS TIME ")
            strSQL.Append("FROM HN2MAS JA, ")
            If TanMSKBN = "1" Or TanMSKBN = "2" Then
                strSQL.Append("     M09_JAGROUP M09, ")
                strSQL.Append("     M11_JAHOKOKU M11, ")
                strSQL.Append("     D20_TAIOU TI ")
            Else
                strSQL.Append("     M09_JAGROUP M09, ")
                strSQL.Append("     M11_JAHOKOKU M11 ")
            End If
            strSQL.Append("WHERE ")
            strSQL.Append("      JA.CLI_CD = :CLSI_CD ")
            strSQL.Append("  AND JA.HAN_CD = :HAN_CD ")
            strSQL.Append("  AND M09.KBN(+) = '002' ")
            strSQL.Append("  AND JA.CLI_CD = M09.KURACD(+) ")
            strSQL.Append("  AND JA.HAN_CD = M09.ACBCD(+) ")
            strSQL.Append("  AND M11.KBN(+) = '2' ")
            strSQL.Append("  AND M09.GROUPCD = M11.GROUPCD(+) ")
            strSQL.Append("  AND 0 <> TO_NUMBER(M11.TANCD) ")

            If TanMSKBN = "1" Then
                strSQL.Append("  AND TI.KANSCD = :KANSCD ")
                strSQL.Append("  AND TI.SYONO = :SYONO ")
                strSQL.Append("  AND M09.USERCD_TO IS NULL ")
                strSQL.Append("  AND TI.USER_CD = M09.USERCD_FROM ")
            ElseIf TanMSKBN = "2" Then
                strSQL.Append("  AND TI.KANSCD = :KANSCD ")
                strSQL.Append("  AND TI.SYONO = :SYONO ")
                strSQL.Append("  AND M09.USERCD_TO IS NOT NULL ")
                strSQL.Append("  AND TI.USER_CD BETWEEN M09.USERCD_FROM AND M09.USERCD_TO ")
            Else
                strSQL.Append("  AND M09.USERCD_FROM IS NULL ")
                strSQL.Append("  AND M09.USERCD_TO IS NULL ")
            End If
            strSQL.Append("ORDER BY TO_NUMBER(M11.TANCD) ")
            '2016/02/10 H.Mori mod 2016���P�J�� END

            '�p�����[�^�̃Z�b�g
            SqlParamC.fncSetParam("CLSI_CD", True, hdnKURACD.Value)
            SqlParamC.fncSetParam("HAN_CD", True, hdnACBCD.Value)
            ' ������ 2013/07/01 T.Ono mod �ڋq�P�ʓo�^�@�\�ǉ� ������
            If TanMSKBN = "1" Or TanMSKBN = "2" Then
                SqlParamC.fncSetParam("KANSCD", True, hdnKANSCD.Value)
                SqlParamC.fncSetParam("SYONO", True, hdnSYONO.Value)
            End If
            ' ������ 2013/07/01 T.Ono mod �ڋq�P�ʓo�^�@�\�ǉ� ������

            '//SQL�̎��s
            dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)


            If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) <> "XYZ" Then
                '�i�`�x�����f�[�^����I
                existFlg = True
                '2016/02/10 H.Mori del 2016���P�J�� START
                'Else

                '    '2009/03/05 T.Watabe add
                '    '�i�`�x���R�[�h����i�`�R�[�h���Q��  
                '    strSQL2.Append("SELECT JA_CD FROM HN2MAS WHERE CLI_CD = :CLSI_CD  AND HAN_CD = :HAN_CD ")
                '    SqlParamC = New CSQLParam()                 '2012/07/17 NEC Add
                '    SqlParamC.fncSetParam("CLSI_CD", True, hdnKURACD.Value) '�p�����[�^�̃Z�b�g
                '    SqlParamC.fncSetParam("HAN_CD", True, hdnACBCD.Value)
                '    dbData = SQLC.mGetData(strSQL2.ToString, SqlParamC.pParamDataSet, True) '//SQL�̎��s
                '    strJACD = Convert.ToString(dbData.Tables(0).Rows(0).Item(0))

                '    If strJACD <> "" Then '�i�`�R�[�h����H

                '        '�i�`�x���Ō�����Ȃ��̂ŁE�E�E
                '        '�B�i�`��\�R�[�h����擾

                '        '�p�����[�^�̃Z�b�g
                '        SqlParamC = New CSQLParam()                 '2012/07/17 NEC Add
                '        SqlParamC.fncSetParam("CLSI_CD", True, hdnKURACD.Value)
                '        SqlParamC.fncSetParam("HAN_CD", True, strJACD)

                '        '//SQL�̎��s
                '        dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

                '        If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) <> "XYZ" Then
                '            '�i�`��\���f�[�^����I
                '            existFlg = True
                '        End If
                '    End If
                '2016/02/10 H.Mori del 2016���P�J�� END

            End If

            '�f�[�^�Ȃ��̏ꍇ������
            If existFlg = False Then
                dbData.Tables(0).Rows(intRow).Item("JA_NAME") = ""
                dbData.Tables(0).Rows(intRow).Item("JAS_NAME") = ""
                dbData.Tables(0).Rows(intRow).Item("TANCD") = ""
                dbData.Tables(0).Rows(intRow).Item("TANNM") = ""
                dbData.Tables(0).Rows(intRow).Item("RENTEL1") = ""
                dbData.Tables(0).Rows(intRow).Item("RENTEL2") = ""
                dbData.Tables(0).Rows(intRow).Item("RENTEL3") = ""      ' 2013/06/28 T.Ono add
                dbData.Tables(0).Rows(intRow).Item("FAXNO") = ""
                dbData.Tables(0).Rows(intRow).Item("SPOT_MAIL") = ""    '2019/08/02 W.GANEKO ADD
                dbData.Tables(0).Rows(intRow).Item("BIKO") = ""
            End If

            Dim bInit As Boolean
            For intTan = 0 To 9
                If Convert.ToString(dbData.Tables(0).Rows(intRow).Item("TANCD")) <> "" Then
                    If intTan + 1 = CInt(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("TANCD"))) Then
                        strMsg.Append("document.Form1.txtTANNM" & intTan + 1 & ".value='" & Convert.ToString(dbData.Tables(0).Rows(intRow).Item("TANNM")) & "';")
                        strMsg.Append("document.Form1.txtRENTEL1_" & intTan + 1 & ".value='" & Convert.ToString(dbData.Tables(0).Rows(intRow).Item("RENTEL1")) & "';")
                        strMsg.Append("document.Form1.txtRENTEL2_" & intTan + 1 & ".value='" & Convert.ToString(dbData.Tables(0).Rows(intRow).Item("RENTEL2")) & "';")
                        strMsg.Append("document.Form1.txtRENTEL3_" & intTan + 1 & ".value='" & Convert.ToString(dbData.Tables(0).Rows(intRow).Item("RENTEL3")) & "';")  ' 2013/06/28 T.Ono add
                        strMsg.Append("document.Form1.txtBIKO" & intTan + 1 & ".value='" & Convert.ToString(dbData.Tables(0).Rows(intRow).Item("BIKO")) & "';")
                        strMsg.Append("document.Form1.txtMail" & intTan + 1 & ".value='" & Convert.ToString(dbData.Tables(0).Rows(intRow).Item("SPOT_MAIL")) & "';")    '2019/08/02 W.GANEKO ADD
                        strMsg.Append("document.Form1.txtFAX" & intTan + 1 & ".value='" & Convert.ToString(dbData.Tables(0).Rows(intRow).Item("FAXNO")) & "';")

                        If intRow < dbData.Tables(0).Rows.Count - 1 Then
                            intRow += 1
                        End If

                        bInit = False
                    Else
                        bInit = True
                    End If
                End If
                If bInit = True Then
                    '�A������͏����������
                    strMsg.Append("document.Form1.txtTANNM" & intTan + 1 & ".value='';")
                    strMsg.Append("document.Form1.txtRENTEL1_" & intTan + 1 & ".value='';")
                    strMsg.Append("document.Form1.txtRENTEL2_" & intTan + 1 & ".value='';")
                    strMsg.Append("document.Form1.txtRENTEL3_" & intTan + 1 & ".value='';")     ' 2013/06/28 T.Ono add
                    strMsg.Append("document.Form1.txtBIKO" & intTan + 1 & ".value='';")
                    strMsg.Append("document.Form1.txtMail" & intTan + 1 & ".value='';")         '2019/08/02 W.GANEKO ADD
                    strMsg.Append("document.Form1.txtFAX" & intTan + 1 & ".value='';")
                End If
            Next

        Catch ex As Exception
            Dim ErrMsgC As New CErrMsg
            strMsg.Append("alert('�V�X�e���G���[�F" & ErrMsgC.mGetArtMsg(ex.ToString) & "');")

        Finally
            If dbData Is Nothing Then
            Else
                dbData.Dispose()
            End If
        End Try

    End Sub

    '**********************************************************
    ' 2013/07/01 T.Ono add
    'M05_TANTO2�ɓo�^�����邩�m�F
    '�߂�l�F 0�FTANTO2�o�^�Ȃ� 1:���q�l�R�[�h1�� 2:���q�l�R�[�h�͈�
    '**********************************************************
    Private Function fncCheckTANTO2() As String

        Dim SQLC As New SDSYUJAG00CSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet
        Dim strRes As String = "0"
        Dim i As Integer
        Try

            For i = 0 To 1
                '2016/02/10 H.Mori mod 2016���P�J�� START
                '1�T�ځF���q�lCD1�A2�T�ځF���q�lCD�͈�
                'strSQL = New StringBuilder("")
                'strSQL.Append("SELECT   B.KURACD ")
                'strSQL.Append("FROM     D20_TAIOU A, ")
                'strSQL.Append("         M05_TANTO2 B ")
                'strSQL.Append("WHERE    A.KANSCD = :KANSCD ")
                'strSQL.Append("AND      A.SYONO = :SYONO ")
                'strSQL.Append("AND      B.KURACD = A.KURACD ")
                'strSQL.Append("AND      B.CODE = A.ACBCD ")
                'If i = 0 Then
                '    strSQL.Append("AND	    B.USER_CD_TO IS NULL ")
                '    strSQL.Append("AND	    A.USER_CD =  B.USER_CD_FROM ")
                'Else
                '    strSQL.Append("AND      B.USER_CD_TO IS NOT NULL ")
                '    strSQL.Append("AND      A.USER_CD BETWEEN B.USER_CD_FROM AND B.USER_CD_TO ")
                'End If
                strSQL = New StringBuilder("")
                strSQL.Append("SELECT   M09.KURACD ")
                strSQL.Append("FROM     D20_TAIOU A, ")
                strSQL.Append("         M09_JAGROUP M09 ")
                strSQL.Append("WHERE    A.KANSCD = :KANSCD ")
                strSQL.Append("AND      A.SYONO = :SYONO ")
                strSQL.Append("AND      M09.KURACD = A.KURACD ")
                strSQL.Append("AND      M09.ACBCD = A.ACBCD ")
                strSQL.Append("AND      M09.KBN(+) = '002' ")
                If i = 0 Then
                    strSQL.Append("AND	    M09.USERCD_TO IS NULL ")
                    strSQL.Append("AND	    A.USER_CD =  M09.USERCD_FROM ")
                Else
                    strSQL.Append("AND      M09.USERCD_TO IS NOT NULL ")
                    strSQL.Append("AND      A.USER_CD BETWEEN M09.USERCD_FROM AND M09.USERCD_TO ")
                End If
                '2016/02/10 H.Mori mod 2016���P�J�� END

                '�p�����[�^�̃Z�b�g
                SqlParamC.fncSetParam("KANSCD", True, hdnKANSCD.Value)
                SqlParamC.fncSetParam("SYONO", True, hdnSYONO.Value)

                '//SQL�̎��s
                dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

                If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
                    '�f�[�^�Ȃ��̏ꍇ
                    strRes = "0"
                Else
                    '�f�[�^����̏ꍇ
                    strRes = CStr(i + 1)
                    Exit For
                End If
            Next

        Catch ex As Exception
            Dim ErrMsgC As New CErrMsg
            strMsg.Append("alert('�V�X�e���G���[�F" & ErrMsgC.mGetArtMsg(ex.ToString) & "');")

        Finally
            If dbData Is Nothing Then
            Else
                dbData.Dispose()
            End If
        End Try

        Return strRes
    End Function

End Class
