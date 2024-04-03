'***********************************************
'�v���_�E���ݒ�}�X�^�ꗗ  ���C�����
'***********************************************
Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common
Imports JPG.Common.log

Imports System.Text

Partial Class MSPUFJAG00
    Inherits System.Web.UI.Page

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

    '******************************************************************************
    ' Page_Load
    '******************************************************************************
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                                                                    Handles MyBase.Load
        '//------------------------------------------
        '//�@HTTP�w�b�_�𑗐M
        HttpHeaderC.mNoCache(Response)

        '//------------------------------------------
        '//�@�F�؃N���X�̃C���X�^���X����
        AuthC = New CAuthenticate(Request, Response)

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
             MyBase.MapPath("../../../MS/MSPUFJAG/MSPUFJAG00/") & "MSPUFJAG00.js"))
        '<�t�H�[�J�X�֘A�֐�>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncFo.js"))
        strScript.Append("</Script>")
        '//------------------------------------------
        '//�@Css�i�[
        strScript.Append("<Style>")
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "CssList.css"))
        strScript.Append("</Style>")
        '//------------------------------------------
        '//�@Script������
        lblScript.Text = strScript.ToString

        '//------------------------------------------
        If MyBase.IsPostBack = False Then
            '//--------------------------------------
            '//���߂ĊJ�������������s�����
        Else
            '//--------------------------------------
            '//�Q��ڈȍ~���s�����
            '//--------------------------------------
        End If

        '//-------------------------------------------------
        '<TODO>�����̉��ID��HIDDEN��hdnMyAspx�ɏ������ށi�V�X�e�����ʁj
        hdnMyAspx.Value = "MSPUFJAG00"
        '//-------------------------------------------------

        Dim strRec As String
        Try
            '********************************************
            '//------------------------------------------
            '// Select���̍쐬
            Dim SQLC As New MSPUFJAG00CCSQL.CSQL
            Dim SqlParamC As New CSQLParam
            Dim strSQL As New StringBuilder
            Dim ds As New DataSet
            Dim strHtml As New StringBuilder

            '// �f�[�^�̎擾
            strSQL = New StringBuilder("")
            Call fncMakeSQL(strSQL, SqlParamC)
            ds = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

            '//------------------------------------------
            '<TODO>�f�[�^�ҏW���s���ꍇ�ALOOP�ɂăf�[�^���ăZ�b�g����
            Dim intRow As Integer
            Dim strTemp As String
            Dim strKbn As String

            strHtml.Append("<table cellspacing=""0"" cellpadding=""1"" widht=""980px"">")
            strHtml.Append("	<tr>")
            strHtml.Append("		<td width=""50px"" height=""0px""></td>")
            strHtml.Append("		<td width=""190px""></td>")
            strHtml.Append("		<td width=""330px""></td>")
            strHtml.Append("		<td width=""330px""></td>")
            strHtml.Append("		<td width=""60px""></td>")
            strHtml.Append("		<td width=""50px""></td>")
            strHtml.Append("		<td width=""50px""></td>")
            strHtml.Append("	</tr>")

            If Convert.ToString(ds.Tables(0).Rows(0).Item(0)) = "XYZ" Then
                '//------------------------------------------
                '<TODO>�f�[�^�����݂��Ȃ��ꍇ�A��̖��׍s���o�͂���

                '�w�b�_�[�s���o��
                strHtml.Append("	<tr>")
                strHtml.Append("		<td>&nbsp;</td>")
                strHtml.Append("	</tr>")
                strHtml.Append("	<tr>")
                strHtml.Append("		<td colspan=""7"" class=""COMMT"">�敪�F</td>")
                strHtml.Append("	</tr>")
                strHtml.Append("	<tr>")
                strHtml.Append("		<td align=""center"" class=""TITL"">�R�[�h</td>")
                strHtml.Append("		<td align=""center"" class=""TITL"">����</td>")
                strHtml.Append("		<td align=""center"" class=""TITL"">���e�P</td>")
                strHtml.Append("		<td align=""center"" class=""TITL"">���e�Q</td>")
                strHtml.Append("		<td align=""center"" class=""TITL"">�\������</td>")
                strHtml.Append("		<td align=""center"" class=""TITL"">�o�^��</td>")
                strHtml.Append("		<td align=""center"" class=""TITR"">�X�V��</td>")
                strHtml.Append("	</tr>")

                '���׍s���o�́i��j
                strHtml.Append("	<tr>")
                strHtml.Append("		<td class=""OTHR""></td>")
                strHtml.Append("		<td class=""OTHR""></td>")
                strHtml.Append("		<td class=""OTHR""></td>")
                strHtml.Append("		<td class=""OTHR""></td>")
                strHtml.Append("		<td class=""OTHR""></td>")
                strHtml.Append("		<td class=""OTHR""></td>")
                strHtml.Append("		<td class=""OTHR""></td>")
                strHtml.Append("	</tr>")
            Else
                For intRow = 0 To ds.Tables(0).Rows.Count - 1

                    If strKbn <> Convert.ToString(ds.Tables(0).Rows(intRow).Item("KBN")) Then
                        '�w�b�_�[�s���o��
                        strHtml.Append("	<tr>")
                        '�ŏ��̃��[�v�ȊO
                        If intRow <> 0 Then
                            strHtml.Append("		<td class=""BREAK"">&nbsp;</td>")
                        Else
                            strHtml.Append("        <td>&nbsp;</td>")
                        End If
                        strHtml.Append("	</tr>")
                        strHtml.Append("	<tr>")
                        strHtml.Append("		<td colspan=""7"" class=""COMMT"">�敪�F�@�@" & _
                                            Convert.ToString(ds.Tables(0).Rows(intRow).Item("KBN")) & "�@" & _
                                            Convert.ToString(ds.Tables(0).Rows(intRow).Item("KBNNM")) & "</td>")
                        strHtml.Append("	</tr>")
                        strHtml.Append("	<tr>")
                        strHtml.Append("		<td align=""center"" class=""TITL"">�R�[�h</td>")
                        strHtml.Append("		<td align=""center"" class=""TITL"">����</td>")
                        strHtml.Append("		<td align=""center"" class=""TITL"">���e�P</td>")
                        strHtml.Append("		<td align=""center"" class=""TITL"">���e�Q</td>")
                        strHtml.Append("		<td align=""center"" class=""TITL"">�\������</td>")
                        strHtml.Append("		<td align=""center"" class=""TITL"">�o�^��</td>")
                        strHtml.Append("		<td align=""center"" class=""TITR"">�X�V��</td>")
                        strHtml.Append("	</tr>")
                    End If

                    strHtml.Append("	<tr>")
                    strHtml.Append("		<td class=""OTHR"" >" & _
                                Convert.ToString(ds.Tables(0).Rows(intRow).Item("CD")) & "</td>")
                    strHtml.Append("		<td class=""OTHR"">" & _
                                Convert.ToString(ds.Tables(0).Rows(intRow).Item("NAME")) & "</td>")
                    strHtml.Append("		<td class=""OTHR"">" & _
                                Convert.ToString(ds.Tables(0).Rows(intRow).Item("NAIYO1")) & "</td>")
                    strHtml.Append("		<td class=""OTHR"">" & _
                                Convert.ToString(ds.Tables(0).Rows(intRow).Item("NAIYO2")) & "</td>")
                    strHtml.Append("		<td class=""OTHR"">" & _
                                Convert.ToString(ds.Tables(0).Rows(intRow).Item("DISP_NO")) & "</td>")
                    '�쐬���ҏW
                    strHtml.Append("		<td class=""OTHR"" align=""center"">" & _
                                fncDateSet(Convert.ToString(ds.Tables(0).Rows(intRow).Item("ADD_DATE"))) & "</td>")
                    '�X�V���ҏW
                    strHtml.Append("		<td class=""OTHR"" align=""center"">" & _
                                fncDateSet(Convert.ToString(ds.Tables(0).Rows(intRow).Item("EDT_DATE"))) & "</td>")
                    strHtml.Append("	</tr>")

                    If ds.Tables(0).Rows.Count <> 1 Then
                        strHtml.Append("	<tr>")
                        strHtml.Append("	<td widht=""985px"" colspan=""7"">")
                        strHtml.Append("        <table style=""BORDER-BOTTOM: black 1px solid"" cellSpacing=""0"" cellPadding=""0"" width=""100%""><tr><td></td></tr></table>")
                        strHtml.Append("    </td>")
                        strHtml.Append("	</tr>")
                    End If

                    strKbn = Convert.ToString(ds.Tables(0).Rows(intRow).Item("KBN"))
                Next

                strHtml.Append("</table>")

            End If

            lblHtml.Text = strHtml.ToString

            '//------------------------------------------
            '********************************************
            strRec = "OK"
        Catch ex As Exception
            strRec = ex.ToString
            Dim ErrMsgC As New CErrMsg
            strMsg.Append("alert('�V�X�e���G���[�F" & ErrMsgC.mGetArtMsg(strRec) & "');")
        End Try

    End Sub

    '******************************************************************************
    ' SQL�쐬
    '******************************************************************************
    '//------------------------------------------
    '<TODO>SELECT���̍쐬��SQL�p�����[�^�̃o�C���h
    Private Sub fncMakeSQL(ByVal pstrSQL As StringBuilder, ByVal pSqlParamC As CSQLParam)
        pstrSQL.Append("SELECT ")
        pstrSQL.Append("PL.KBN,")
        pstrSQL.Append("PM.NAME AS KBNNM,")
        pstrSQL.Append("PL.CD,")
        pstrSQL.Append("PL.NAME,")
        pstrSQL.Append("PL.NAIYO1,")
        pstrSQL.Append("PL.NAIYO2,")
        pstrSQL.Append("PL.DISP_NO,")
        pstrSQL.Append("PL.ADD_DATE,")
        pstrSQL.Append("PL.EDT_DATE ")
        pstrSQL.Append("FROM M06_PULLDOWN PM,")
        pstrSQL.Append("M06_PULLDOWN PL ")
        pstrSQL.Append("WHERE PM.KBN = '00'")
        pstrSQL.Append(" AND PM.CD = PL.KBN ")
        pstrSQL.Append("ORDER BY KBN,CD")

    End Sub

    '******************************************************************************
    '*�@�T�@�v�F�p�����[�^�l�����tYYYY/MM/DD�l��Ԃ�
    '*�@���@�l�F
    '******************************************************************************
    Public Function fncDateSet(ByVal pstrDate As String) As String
        Dim DateFncC As New CDateFnc
        Dim strRec As String
        strRec = ""
        If IsNumeric(pstrDate) = True Then
            strRec = DateFncC.mGet(pstrDate)
        End If

        Return strRec
    End Function
End Class
