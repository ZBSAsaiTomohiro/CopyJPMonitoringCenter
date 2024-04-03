'***********************************************
'�S���҃}�X�^�ꗗ  ���C�����
'***********************************************
Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common
Imports JPG.Common.log

Imports System.Text

Partial Class MSTAFJAG00
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
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
             MyBase.MapPath("../../../MS/MSTAFJAG/MSTAFJAG00/") & "MSTAFJAG00.js"))
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

            '//-----------------------------------------------------
            '// �c�Ə��O���[�v�݂̂ɏ������Ă���ꍇ�A[�c�Ə����j���[]���J�ڂ��Ă��Ă����
            '// �I���{�^����������[�c�Ə����j���[]�ɖ߂�
            '//-----------------------------------------------------
            hdnBackUrl.Value = ""
            Dim strGROUPNAME As String = AuthC.pGROUPNAME
            Dim arrGroupName() As String = strGROUPNAME.Split(Convert.ToChar(","))
            '--- ��2005/04/19 MOD�@Falcon�� -----------------
            Dim arrKanshiGroup() As String = AuthC.pGROUP_KANSHI.Split(Convert.ToChar(","))
            Dim i As Integer
            Dim bolGroupFLG As Boolean = False

            '�^�s�J�����E�c�Ə��̏����`�F�b�N
            If Array.IndexOf(arrGroupName, AuthC.pGROUP_UNKOU) >= 0 Or _
                Array.IndexOf(arrGroupName, AuthC.pGROUP_EIGYOU) >= 0 Then
                bolGroupFLG = True
            End If
            '--- ��2005/04/19 MOD Falcon�� ------------------
            '--- ��2005/04/28 MOD�@Falcon�� -----------------
            '�Ď��Z���^�[�����`�F�b�N
            If bolGroupFLG = False Then
                For i = 0 To arrKanshiGroup.Length - 1
                    If Array.IndexOf(arrGroupName, arrKanshiGroup(i)) >= 0 Then
                        bolGroupFLG = True
                        '//�c�Ə��O���[�v
                        hdnBackUrl.Value = "KANSHI"
                        Exit For
                    End If
                Next i
            End If
            '--- ��2005/04/28 MOD Falcon�� ------------------
            '--- ��2005/04/19 MOD�@Falcon�� -----------------
            If bolGroupFLG = False Then
                Dim j As Integer
                Dim intEIGYOU_LEN As Integer
                Dim intGROUP_LEN As Integer
                intEIGYOU_LEN = AuthC.pGROUP_EIGYOU.Length
                For j = 0 To arrGroupName.Length - 1
                    intGROUP_LEN = arrGroupName(j).Length
                    If intGROUP_LEN > 0 Then
                        If Convert.ToString(arrGroupName(j)).Substring(intGROUP_LEN - intEIGYOU_LEN, intEIGYOU_LEN) = AuthC.pGROUP_EIGYOU Then
                            '//�c�Ə��O���[�v
                            hdnBackUrl.Value = "EIGYOU"
                        End If
                    End If
                Next
            End If
            '--- ��2005/04/19 MOD Falcon�� ------------------

            '--- ��2005/04/19 DEL�@Falcon�� -----------------
            '''''If _
            '''''    Array.IndexOf(arrGroupName, AuthC.pGROUP_UNKOU) >= 0 Or _
            '''''    Array.IndexOf(arrGroupName, AuthC.pGROUP_TOUHOKU) >= 0 Or _
            '''''    Array.IndexOf(arrGroupName, AuthC.pGROUP_NAKANIHON) >= 0 Or _
            '''''    Array.IndexOf(arrGroupName, AuthC.pGROUP_NISHINIHON) >= 0 Or _
            '''''    Array.IndexOf(arrGroupName, AuthC.pGROUP_EIGYOU) >= 0 Then
            '''''    '�����ꂩ�̃O���[�v�ɏ������Ă���ꍇ�͂��̃��j���[�ɂċƖ����s������
            '''''    '�ʏ�[�}�X�^���j���[]�ɖ߂�
            '''''Else
            '''''    Dim j As Integer
            '''''    Dim intEIGYOU_LEN As Integer
            '''''    Dim intGROUP_LEN As Integer
            '''''    intEIGYOU_LEN = AuthC.pGROUP_EIGYOU.Length
            '''''    For j = 0 To arrGroupName.Length - 1
            '''''        intGROUP_LEN = arrGroupName(j).Length
            '''''        If intGROUP_LEN > 0 Then
            '''''            If Convert.ToString(arrGroupName(j)).Substring(intGROUP_LEN - intEIGYOU_LEN, intEIGYOU_LEN) = AuthC.pGROUP_EIGYOU Then
            '''''                '//�c�Ə��O���[�v
            '''''                hdnBackUrl.Value = "EIGYOU"
            '''''            End If
            '''''        End If
            '''''    Next
            '''''End If
            '--- ��2005/04/19 DEL Falcon�� ------------------


            '--- ��2008/07/31 ADD T.Watabe�� -----------------
            ' �S���҈ꗗ�̑I����ʂ���̃p�����[�^
            hdnKEY_KBN.Value = Request.Form("hdnKEY_KBN")       ' 1:JA�x��/2:�Ď��Z���^�[/3:�o�����
            hdnKEY_KURACD.Value = Request.Form("hdnKEY_KURACD") '�N���C�A���g�R�[�h
            hdnKEY_CODE.Value = Request.Form("hdnKEY_CODE")     '�R�[�h
            hdnKEY_JACD.Value = Request.Form("hdnKEY_JACD")     'JA�R�[�h
            '2016/02/19 H.Mori add 2015���P�J�� ��9
            hdnKEY_GROUPCD.Value = Request.Form("hdnKEY_GROUPCD")     '�O���[�v�R�[�h
            '2015/11/02 w.ganeko 2015���P�J�� ��9
            hdnKEY_TANTOTEL.Value = Request.Form("hdnKEY_TANTOTEL")     'JA�E�S���ҘA����
            '--- ��2005/07/31 DEL T.Watabe�� ------------------


        Else
            '//--------------------------------------
            '//�Q��ڈȍ~���s�����
            '//--------------------------------------
        End If

        '//-------------------------------------------------
        '<TODO>�����̉��ID��HIDDEN��hdnMyAspx�ɏ������ށi�V�X�e�����ʁj
        hdnMyAspx.Value = "MSTAFJAG00"
        '//-------------------------------------------------

        Dim strRec As String

        Try
            '********************************************
            '//------------------------------------------
            '// Select���̍쐬
            Dim SQLC As New MSTAFJAG00CCSQL.CSQL
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
            Dim strKBN As String
            Dim strKBN_NM As String
            Dim intKBNSum As Integer
            Dim strKURACD As String
            Dim strCODE As String
            Dim strCODE_NM As String ' 2009/07/24 T.Watabe add
            Dim strCODE_HYOJI As String  ' 2013/07/02 T.Ono add  �^�C�g���\���p
            '2016/02/25 H.Mori del 2015���P�J�� ��9 START
            'Dim strUSER_CD_FROM As String  ' 2013/07/02 T.Ono add
            'Dim strUSER_CD_TO As String    ' 2013/07/02 T.Ono add
            'Dim strUSER_CD As String = ""   ' 2013/07/02 T.Ono add�@�^�C�g���\���p
            '2016/02/25 H.Mori del 2015���P�J�� ��9 END
            Dim strCODE2 As String '2016/02/19 H.Mori add 2015���P�J�� ��9

            strHtml.Append("<table cellspacing=""0"" cellpadding=""1"" width=""970px"">")
            strHtml.Append("	<tr>")
            strHtml.Append("		<td width=""50px""></td>")                      '�N���C�A���g�R�[�h
            strHtml.Append("		<td width=""40px""></td>")                      '�R�[�h�^�S���҃R�[�h
            strHtml.Append("		<td width=""280px""></td>")                     '�R�[�h���́^�S���Җ�
            strHtml.Append("		<td width=""100px""></td>")                     '�A���d�b�ԍ��P�^�A���d�b�ԍ��Q
            strHtml.Append("		<td width=""100px""></td>")                      'FAX�ԍ�
            strHtml.Append("		<td width=""40px""></td>")                      '�\������
            strHtml.Append("		<td width=""260px""></td>")                     '�L��
            strHtml.Append("		<td width=""40px""></td>")                      '�o�^���^�X�V��
            strHtml.Append("	</tr>" & vbCrLf)

            If Convert.ToString(ds.Tables(0).Rows(0).Item(0)) = "XYZ" Then
                '//------------------------------------------
                '<TODO>�f�[�^�����݂��Ȃ��ꍇ�A��̖��׍s���o�͂���

                '�w�b�_�[�s���o��
                strHtml.Append("	<tr>")
                strHtml.Append("		<td>&nbsp;</td>")
                strHtml.Append("	</tr>")
                strHtml.Append("	<tr>")
                strHtml.Append("		<td colspan=""9"">�敪�F</td>")
                strHtml.Append("	</tr>")
                ' ������ 2013/07/02 T.Ono mod �ڋq�P�ʓo�^�@�\�ǉ� ������
                'strHtml.Append("	<tr>" & vbCrLf)
                'strHtml.Append("		<td rowspan=""2"" align=""center"" class=""TITL"" valign=""top"">�ײ���<BR>����</td>" & vbCrLf)
                'strHtml.Append("		<td align=""center"" class=""TITTL"">�S���Һ���</td>" & vbCrLf)
                'strHtml.Append("		<td align=""center"" class=""TITTL"">�S���Җ�</td>" & vbCrLf)
                'strHtml.Append("		<td align=""center"" class=""TITTL"">�A���d�b�ԍ��P</td>" & vbCrLf)
                'strHtml.Append("		<td align=""center"" class=""TITTL"">FAX�ԍ�</td>" & vbCrLf)
                'strHtml.Append("		<td align=""center"" class=""TITBL"" rowspan=""2"" valign=""top"">�\��<BR>����</td>" & vbCrLf)
                'strHtml.Append("		<td align=""center"" class=""TITBL"" rowspan=""2"" valign=""top"">���l</td>" & vbCrLf)
                'strHtml.Append("		<td align=""center"" class=""TITR"">�o�^��</td>" & vbCrLf)
                'strHtml.Append("	</tr>")
                'strHtml.Append("	<tr>" & vbCrLf)
                'strHtml.Append("		<td align=""center"" class=""TITBL"">&nbsp;</td>" & vbCrLf)
                'strHtml.Append("		<td align=""center"" class=""TITBL"">&nbsp;</td>" & vbCrLf)
                'strHtml.Append("		<td align=""center"" class=""TITBL"">�A���d�b�ԍ��Q</td>" & vbCrLf)
                'strHtml.Append("		<td align=""center"" class=""TITBL"">&nbsp;</td>" & vbCrLf)
                'strHtml.Append("		<td align=""center"" class=""TITBR"">�X�V��</td>" & vbCrLf)
                'strHtml.Append("	</tr>" & vbCrLf)
                strHtml.Append("	<tr>" & vbCrLf)
                strHtml.Append("		<td rowspan=""3"" align=""center"" class=""TITL"" valign=""top"">�ײ���<BR>����</td>" & vbCrLf)
                strHtml.Append("		<td rowspan=""3"" align=""center"" class=""TITL"" valign=""top"">�S���Һ���</td>" & vbCrLf)
                strHtml.Append("		<td rowspan=""3"" align=""center"" class=""TITL"" valign=""top"">�S���Җ�</td>" & vbCrLf)
                strHtml.Append("		<td align=""center"" class=""TITTL"">�A���d�b�ԍ��P</td>" & vbCrLf)
                ' 2014/01/07 T.Ono mod ���P�Ή�2013 JA�S���҂͍��ږ��ύX
                'strHtml.Append("		<td align=""center"" class=""TITTL"">FAX�ԍ�</td>" & vbCrLf)
                If hdnKEY_KBN.Value = "1" Then
                    strHtml.Append("		<td align=""center"" class=""TITTL"">��߯�FAX�ԍ�</td>" & vbCrLf)
                Else
                    strHtml.Append("		<td align=""center"" class=""TITTL"">FAX�ԍ�</td>" & vbCrLf)
                End If
                strHtml.Append("		<td align=""center"" class=""TITBL"" rowspan=""3"" valign=""top"">�\��<BR>����</td>" & vbCrLf)
                ' 2013/11/29 T.Ono mod ���P�Ή�2013 JA�S���҂͍��ږ��ύX
                'strHtml.Append("		<td align=""center"" class=""TITBL"" rowspan=""3"" valign=""top"">���l</td>" & vbCrLf)
                If hdnKEY_KBN.Value = "1" Then
                    strHtml.Append("		<td align=""center"" class=""TITBL"" rowspan=""3"" valign=""top"">�L��</td>" & vbCrLf)
                Else
                    strHtml.Append("		<td align=""center"" class=""TITBL"" rowspan=""3"" valign=""top"">���l</td>" & vbCrLf)
                End If
                strHtml.Append("		<td align=""center"" class=""TITTR"">�o�^��</td>" & vbCrLf)
                strHtml.Append("	</tr>" & vbCrLf)
                strHtml.Append("	<tr>" & vbCrLf)
                strHtml.Append("		<td align=""center"" class=""TITTL"">�A���d�b�ԍ��Q</td>" & vbCrLf)
                strHtml.Append("		<td align=""center"" class=""TITL"" rowspan=""2"" valign=""top"">����FAX�ԍ�</td>" & vbCrLf)
                strHtml.Append("		<td align=""center"" class=""TITR"" rowspan=""2"" valign=""top"">�X�V��</td>" & vbCrLf)
                strHtml.Append("	</tr>" & vbCrLf)
                strHtml.Append("	<tr>" & vbCrLf)
                strHtml.Append("		<td align=""center"" class=""TITBL"">�A���d�b�ԍ��R</td>" & vbCrLf)
                strHtml.Append("	</tr>" & vbCrLf)
                ' ������ 2013/07/02 T.Ono mod �ڋq�P�ʓo�^�@�\�ǉ� ������

                '���׍s���o�́i��j
                strHtml.Append("	<tr>" & vbCrLf)
                strHtml.Append("		<td class=""OTHR"" rowspan=""2""></td>" & vbCrLf)
                strHtml.Append("		<td class=""OTHR""></td>" & vbCrLf)
                strHtml.Append("		<td class=""OTHR""></td>" & vbCrLf)
                strHtml.Append("		<td class=""OTHR""></td>" & vbCrLf)
                strHtml.Append("		<td class=""OTHR""></td>" & vbCrLf)
                strHtml.Append("		<td class=""OTHR"" rowspan=""2""></td>" & vbCrLf)
                strHtml.Append("		<td class=""OTHR"" rowspan=""2""></td>" & vbCrLf)
                strHtml.Append("		<td class=""OTHR""></td>" & vbCrLf)
                strHtml.Append("	</tr>")
                strHtml.Append("    <tr>" & vbCrLf)
                strHtml.Append("		<td class=""OTHR""></td>" & vbCrLf)
                strHtml.Append("		<td class=""OTHR""></td>" & vbCrLf)
                strHtml.Append("		<td class=""OTHR""></td>" & vbCrLf)
                strHtml.Append("		<td class=""OTHR""></td>" & vbCrLf)
                strHtml.Append("		<td class=""OTHR""></td>" & vbCrLf)
                strHtml.Append("	</tr>" & vbCrLf)
            Else
                For intRow = 0 To ds.Tables(0).Rows.Count - 1
                    '2016/02/25 H.Mori del? 2015���P�J�� ��9 START
                    'If strKBN <> Convert.ToString(ds.Tables(0).Rows(intRow).Item("KBN")) And _
                    '    intRow <> 0 Then
                    '    '���v���o��
                    '    strHtml.Append("	<tr>")
                    '    strHtml.Append("		<td height=""5px""></td>")
                    '    strHtml.Append("	</tr>")
                    '    strHtml.Append("	<tr>")
                    '    strHtml.Append("		<td class=""COMMT"" colspan=""9"">�@�@���v�@�@" & intKBNSum & "</td>")
                    '    strHtml.Append("	</tr>" & vbCrLf)

                    '    intKBNSum = 0

                    'End If
                    '2016/02/25 H.Mori del? 2015���P�J�� ��9 END

                    ' 2013/07/02 T.Ono mod
                    'If strKBN <> Convert.ToString(ds.Tables(0).Rows(intRow).Item("KBN")) Or _
                    '   strKURACD <> Convert.ToString(ds.Tables(0).Rows(intRow).Item("KURACD")) Or _
                    '   strCODE <> Convert.ToString(ds.Tables(0).Rows(intRow).Item("CODE")) Then
                    '2016/02/17 H.Mori mod 2015���P�J�� ��9 START
                    'If strKBN <> Convert.ToString(ds.Tables(0).Rows(intRow).Item("KBN")) Or _
                    '    strKURACD <> Convert.ToString(ds.Tables(0).Rows(intRow).Item("KURACD")) Or _
                    '    strCODE <> Convert.ToString(ds.Tables(0).Rows(intRow).Item("CODE")) Then
                    '    'strUSER_CD_FROM <> Convert.ToString(ds.Tables(0).Rows(intRow).Item("USER_CD_FROM")) Or _
                    '    'strUSER_CD_TO <> Convert.ToString(ds.Tables(0).Rows(intRow).Item("USER_CD_TO")) Then
                    If hdnKEY_KBN.Value = "1" Then
                        strCODE2 = Convert.ToString(ds.Tables(0).Rows(intRow).Item("GROUPCD"))
                    Else
                        strCODE2 = Convert.ToString(ds.Tables(0).Rows(intRow).Item("CODE"))
                    End If
                    If strKBN <> Convert.ToString(ds.Tables(0).Rows(intRow).Item("KBN")) Or _
                        strKURACD <> Convert.ToString(ds.Tables(0).Rows(intRow).Item("KURACD")) Or _
                        strCODE <> strCODE2 Then
                        '2016/02/17 H.Mori mod 2015���P�J�� ��9 END

                        strTemp = Convert.ToString(ds.Tables(0).Rows(intRow).Item("KBN"))
                        If strTemp = "1" Then
                            strKBN_NM = "�Ď��Z���^�[�S����"
                            strCODE_NM = Convert.ToString(ds.Tables(0).Rows(intRow).Item("KANSI_NAME")) ' 2009/07/24 T.Watabe add
                        ElseIf strTemp = "2" Then
                            strKBN_NM = "�o����ВS����"
                            strCODE_NM = Convert.ToString(ds.Tables(0).Rows(intRow).Item("KAISYA_NAME")) ' 2009/07/24 T.Watabe add
                            '2016/02/17 H.Mori mod 2015���P�J�� ��9 START
                            'ElseIf strTemp = "3" Then
                        ElseIf strTemp = " " Then
                            strKBN_NM = "�i�`�x���S����"
                            'strCODE_NM = Convert.ToString(ds.Tables(0).Rows(intRow).Item("JAS_NAME")) ' 2009/07/24 T.Watabe add
                            strCODE_NM = Convert.ToString(ds.Tables(0).Rows(intRow).Item("GROUPNM"))
                            '2016/02/17 H.Mori mod 2015���P�J�� ��9 END
                        End If

                        '�w�b�_�[�s���o��
                        strHtml.Append("	<tr>")
                        '�ŏ��̃��[�v�ȊO
                        If intRow <> 0 Then
                            strHtml.Append("		<td class=""BREAK"">&nbsp;</td>") '������̉��s�R�[�h�}���I
                        Else
                            strHtml.Append("        <td>&nbsp;</td>")
                        End If
                        strHtml.Append("	</tr>")
                        strHtml.Append("	<tr height=""30px"">")

                        ' ������ 2013/07/02 T.Ono mod �ڋq�P�ʓo�^�@�\�ǉ� ������
                        '�^�C�g������������iCODE="XXXX"�̏ꍇ��CODE��\�����Ȃ��j
                        '2016/02/17 H.Mori mod 2015���P�J�� ��9 START
                        'If Convert.ToString(ds.Tables(0).Rows(intRow).Item("CODE")) = "XXXX" Then
                        '    strCODE_HYOJI = ""
                        'Else
                        '    strCODE_HYOJI = Convert.ToString(ds.Tables(0).Rows(intRow).Item("CODE"))
                        'End If
                        If hdnKEY_KBN.Value = "1" Then
                            strCODE_HYOJI = Convert.ToString(ds.Tables(0).Rows(intRow).Item("GROUPCD"))
                        Else
                            strCODE_HYOJI = Convert.ToString(ds.Tables(0).Rows(intRow).Item("CODE"))
                        End If
                        '2016/02/17 H.Mori mod 2015���P�J�� ��9 END
                        '�^�C�g������������(���[�U�[�R�[�h)
                        '2016/02/17 H.Mori del 2015���P�J�� ��9 START
                        'If Convert.ToString(ds.Tables(0).Rows(intRow).Item("USER_CD_FROM")) <> "" Then
                        '    strUSER_CD = Convert.ToString(ds.Tables(0).Rows(intRow).Item("USER_CD_FROM"))
                        '    If Convert.ToString(ds.Tables(0).Rows(intRow).Item("USER_CD_TO")) <> "" Then
                        '        strUSER_CD += " �` " & Convert.ToString(ds.Tables(0).Rows(intRow).Item("USER_CD_TO"))
                        '    End If
                        'Else
                        '    strUSER_CD = ""
                        'End If
                        '2016/02/17 H.Mori del 2015���P�J�� ��9 END
                        '�^�C�g���\����ύX
                        'strHtml.Append("		<td colspan=""7"" class=""COMMT"">�敪�F�@�@" & _
                        '                    Convert.ToString(ds.Tables(0).Rows(intRow).Item("KBN")) & "�@" & strKBN_NM & " " & Convert.ToString(ds.Tables(0).Rows(intRow).Item("CODE")) & " " & strCODE_NM & "</td>" & vbCrLf)
                        '2016/02/19 H.Mori mod 2015���P�J�� ��9 START
                        'strHtml.Append("		<td colspan=""7"" class=""COMMT"">�敪�F�@�@" & _
                        '                Convert.ToString(ds.Tables(0).Rows(intRow).Item("KBN")) & "�@" & strKBN_NM & " " & _
                        '                strCODE_HYOJI & " " & strCODE_NM & " " & strUSER_CD & "</td>" & vbCrLf)
                        strHtml.Append("		<td colspan=""7"" class=""COMMT"">�敪�F�@�@" & _
                                        Convert.ToString(ds.Tables(0).Rows(intRow).Item("KBN")) & "�@" & strKBN_NM & " " & _
                                        strCODE_HYOJI & " " & strCODE_NM & "</td>" & vbCrLf)
                        '2016/02/19 H.Mori mod 2015���P�J�� ��9 START
                        ' ������ 2013/07/02 T.Ono mod �ڋq�P�ʓo�^�@�\�ǉ� ������

                        strHtml.Append("		<td colspan=""2"" class=""COMMT""><table style=""BORDER: black 0px solid; FONT-SIZE: 11px;"" cellSpacing=""0"" cellPadding=""0""><tr height=""30px""><td style=""BORDER: black 1px solid; FONT-SIZE: 12px; width:60px; text-align:center;"">�m�F��</td><td style=""BORDER: black 1px solid; FONT-SIZE: 12px; width:40px; text-align:center;"">&nbsp;</td></tr></table></td>")
                        strHtml.Append("	</tr>")
                        ' ������ 2013/07/02 T.Ono mod �ڋq�P�ʓo�^�@�\�ǉ� ������ �d�b�ԍ��R�A����FAX�ԍ��ǉ�
                        'strHtml.Append("	<tr>")
                        'strHtml.Append("		<td align=""center"" class=""TITL"" valign=""top"" rowspan=""2"">�ײ���<BR>����</td>" & vbCrLf)
                        'strHtml.Append("		<td align=""center"" class=""TITBL"" valign=""top"" rowspan=""2"">�S��</td>" & vbCrLf)
                        'strHtml.Append("		<td align=""center"" class=""TITBL"" valign=""top"" rowspan=""2"">�S���Җ�</td>" & vbCrLf)
                        'strHtml.Append("		<td align=""center"" class=""TITTL"">�A���d�b�ԍ��P</td>" & vbCrLf)
                        'strHtml.Append("		<td align=""center"" class=""TITBL"" valign=""top"" rowspan=""2"">FAX�ԍ�</td>" & vbCrLf)
                        'strHtml.Append("		<td align=""center"" class=""TITBL"" valign=""top"" rowspan=""2"">�\��<BR>����</td>" & vbCrLf)
                        'strHtml.Append("		<td align=""center"" class=""TITBL"" valign=""top"" rowspan=""2"">���l</td>" & vbCrLf)
                        'strHtml.Append("		<td align=""center"" class=""TITTR"">�o�^��</td>" & vbCrLf)
                        'strHtml.Append("	</tr>")
                        'strHtml.Append("	<tr>")
                        'strHtml.Append("		<td align=""center"" class=""TITBL"">�A���d�b�ԍ��Q</td>")
                        'strHtml.Append("		<td align=""center"" class=""TITBR"">�X�V��</td>" & vbCrLf)
                        'strHtml.Append("	</tr>" & vbCrLf)
                        strHtml.Append("	<tr>")
                        strHtml.Append("		<td align=""center"" class=""TITL"" valign=""top"" rowspan=""3"">�ײ���<BR>����</td>" & vbCrLf)
                        strHtml.Append("		<td align=""center"" class=""TITBL"" valign=""top"" rowspan=""3"">�S��</td>" & vbCrLf)
                        strHtml.Append("		<td align=""center"" class=""TITBL"" valign=""top"" rowspan=""3"">�S���Җ�</td>" & vbCrLf)
                        strHtml.Append("		<td align=""center"" class=""TITTL"">�A���d�b�ԍ��P</td>" & vbCrLf)
                        ' 2014/01/07 T.Ono mod ���P�Ή�2013 JA�S���҂͍��ږ��ύX
                        'strHtml.Append("		<td align=""center"" class=""TITTL"">FAX�ԍ�</td>" & vbCrLf)
                        If hdnKEY_KBN.Value = "1" Then
                            strHtml.Append("		<td align=""center"" class=""TITTL"">��߯�FAX�ԍ�</td>" & vbCrLf)
                        Else
                            strHtml.Append("		<td align=""center"" class=""TITTL"">FAX�ԍ�</td>" & vbCrLf)
                        End If
                        strHtml.Append("		<td align=""center"" class=""TITBL"" valign=""top"" rowspan=""3"">�\��<BR>����</td>" & vbCrLf)
                        ' 2013/11/29 T.Ono mod ���P�Ή�2013 JA�S���҂͍��ږ��ύX
                        'strHtml.Append("		<td align=""center"" class=""TITBL"" valign=""top"" rowspan=""3"">���l</td>" & vbCrLf)
                        If hdnKEY_KBN.Value = "1" Then
                            strHtml.Append("		<td align=""center"" class=""TITBL"" valign=""top"" rowspan=""3"">�L��</td>" & vbCrLf)
                        Else
                            strHtml.Append("		<td align=""center"" class=""TITBL"" valign=""top"" rowspan=""3"">���l</td>" & vbCrLf)
                        End If
                        strHtml.Append("		<td align=""center"" class=""TITTR"">�o�^��</td>" & vbCrLf)
                        strHtml.Append("	</tr>" & vbCrLf)
                        strHtml.Append("	<tr>" & vbCrLf)
                        strHtml.Append("		<td align=""center"" class=""TITTL"">�A���d�b�ԍ��Q</td>" & vbCrLf)
                        strHtml.Append("		<td align=""center"" class=""TITBL"" valign=""top"" rowspan=""2"">����FAX�ԍ�</td>" & vbCrLf)
                        strHtml.Append("		<td align=""center"" class=""TITBR"" valign=""top"" rowspan=""2"">�X�V��</td>" & vbCrLf)
                        strHtml.Append("	</tr>" & vbCrLf)
                        strHtml.Append("	<tr>" & vbCrLf)
                        strHtml.Append("		<td align=""center"" class=""TITBL"">�A���d�b�ԍ��R</td>" & vbCrLf)
                        strHtml.Append("	</tr>" & vbCrLf)
                        ' ������ 2013/07/02 T.Ono mod �ڋq�P�ʓo�^�@�\�ǉ� ������
                    End If

                    '���׍s���o��

                    strHtml.Append("	<tr>")
                    '�N���C�A���g�R�[�h
                    strTemp = Convert.ToString(ds.Tables(0).Rows(intRow).Item("KURACD"))

                    If strTemp = "ZZZZ" Then
                        ' 2013/07/02 T.Ono mod
                        'strHtml.Append("		<td class=""OTHR"" valign=""top"" rowspan=""2""></td>" & vbCrLf)
                        strHtml.Append("		<td class=""OTHR"" valign=""top"" rowspan=""3""></td>" & vbCrLf)
                    Else
                        ' 2013/07/02 T.Ono mod
                        'strHtml.Append("		<td class=""OTHR"" valign=""top"" rowspan=""2"">" & _
                        '            Convert.ToString(ds.Tables(0).Rows(intRow).Item("KURACD")) & "</td>" & vbCrLf)
                        strHtml.Append("		<td class=""OTHR"" valign=""top"" rowspan=""3"">" & _
                                    Convert.ToString(ds.Tables(0).Rows(intRow).Item("KURACD")) & "</td>" & vbCrLf)
                    End If
                    ''�R�[�h
                    'strHtml.Append("		<td class=""OTHR"">" & _
                    '            Convert.ToString(ds.Tables(0).Rows(intRow).Item("CODE")) & "</td>" & vbCrLf)
                    ''�R�[�h����
                    'strTemp = Convert.ToString(ds.Tables(0).Rows(intRow).Item("KBN"))
                    'If strTemp = "1" Then           '�Ď��Z���^�[�S���Җ�
                    '    strHtml.Append("		<td class=""OTHR"">" & _
                    '                Convert.ToString(ds.Tables(0).Rows(intRow).Item("KANSI_NAME")) & "</td>" & vbCrLf)
                    'ElseIf strTemp = "2" Then       '�o����ВS���Җ�
                    '    strHtml.Append("		<td class=""OTHR"">" & _
                    '                Convert.ToString(ds.Tables(0).Rows(intRow).Item("KAISYA_NAME")) & "</td>" & vbCrLf)
                    'ElseIf strTemp = "3" Then       '�i�`�x���S���Җ�
                    '    strHtml.Append("		<td class=""OTHR"">" & _
                    '                Convert.ToString(ds.Tables(0).Rows(intRow).Item("JAS_NAME")) & "</td>" & vbCrLf)
                    'End If
                    '�S���҃R�[�h
                    strHtml.Append("		<td class=""OTHR"">" & _
                        Convert.ToString(ds.Tables(0).Rows(intRow).Item("TANCD")) & "</td>" & vbCrLf)
                    '�S���Җ�
                    strHtml.Append("		<td class=""OTHR"">" & _
                        Convert.ToString(ds.Tables(0).Rows(intRow).Item("TANNM")) & "</td>" & vbCrLf)
                    '�A���d�b�ԍ��P
                    strHtml.Append("		<td class=""OTHR"">" & _
                        Convert.ToString(ds.Tables(0).Rows(intRow).Item("RENTEL1")) & "</td>" & vbCrLf)
                    'FAX�ԍ�
                    strHtml.Append("		<td class=""OTHR"">" & _
                        Convert.ToString(ds.Tables(0).Rows(intRow).Item("FAXNO")) & "</td>" & vbCrLf)
                    '�\������
                    '2016/02/17 H.Mori mod 2015���P�J�� ��9 START
                    ' 2013/07/02 T.Ono mod
                    'strHtml.Append("		<td class=""OTHR"" valign=""top"" rowspan=""2"">" & _
                    '            Convert.ToString(ds.Tables(0).Rows(intRow).Item("DISP_NO")) & "</td>" & vbCrLf)
                    'strHtml.Append("		<td class=""OTHR"" valign=""top"" rowspan=""3"">" & _
                    '               Convert.ToString(ds.Tables(0).Rows(intRow).Item("DISP_NO")) & "</td>" & vbCrLf)
                    If hdnKEY_KBN.Value = "1" Then
                        strHtml.Append("		<td class=""OTHR"" valign=""top"" rowspan=""3"">" & "" & "</td>" & vbCrLf)
                    Else
                        strHtml.Append("		<td class=""OTHR"" valign=""top"" rowspan=""3"">" & _
                                       Convert.ToString(ds.Tables(0).Rows(intRow).Item("DISP_NO")) & "</td>" & vbCrLf)
                    End If
                    '2016/02/17 H.Mori mod 2015���P�J�� ��9 END
                    '���l�^�L��
                    ' 2013/07/02 T.Ono mod
                    'strHtml.Append("		<td class=""OTHR"" valign=""top"" rowspan=""2"">" & _
                    '            Convert.ToString(ds.Tables(0).Rows(intRow).Item("BIKO")) & "</td>" & vbCrLf)
                    strHtml.Append("		<td class=""OTHR"" valign=""top"" rowspan=""3"">" & _
                                Convert.ToString(ds.Tables(0).Rows(intRow).Item("BIKO")) & "</td>" & vbCrLf)
                    '�쐬���ҏW
                    strHtml.Append("		<td class=""OTHR"" align=""center"">" & _
                                fncDateSet(Convert.ToString(ds.Tables(0).Rows(intRow).Item("ADD_DATE"))) & "</td>" & vbCrLf)
                    strHtml.Append("	</tr>")
                    strHtml.Append("    <tr>")
                    ''�S���҃R�[�h
                    'strHtml.Append("		<td class=""OTHR"">" & _
                    '            Convert.ToString(ds.Tables(0).Rows(intRow).Item("TANCD")) & "</td>" & vbCrLf)
                    ''�S���Җ�
                    'strHtml.Append("		<td class=""OTHR"">" & _
                    '            Convert.ToString(ds.Tables(0).Rows(intRow).Item("TANNM")) & "</td>" & vbCrLf)
                    strHtml.Append("		<td class=""OTHR"">" & "" & "</td>" & vbCrLf)
                    strHtml.Append("		<td class=""OTHR"">" & "" & "</td>" & vbCrLf)
                    '�A���d�b�ԍ��Q
                    strHtml.Append("		<td class=""OTHR"">" & _
                                Convert.ToString(ds.Tables(0).Rows(intRow).Item("RENTEL2")) & "</td>" & vbCrLf)
                    ' 2013/07/02 T.Ono mod
                    '����FAX�ԍ�
                    'strHtml.Append("		<td class=""OTHR""></td>" & vbCrLf)
                    strHtml.Append("		<td class=""OTHR"">" & _
                                Convert.ToString(ds.Tables(0).Rows(intRow).Item("AUTO_FAXNO")) & "</td>" & vbCrLf)
                    '�X�V���ҏW
                    ' 2013/07/02 T.Ono mod
                    'strHtml.Append("		<td class=""OTHR"" align=""center"">" & _
                    '            fncDateSet(Convert.ToString(ds.Tables(0).Rows(intRow).Item("EDT_DATE"))) & "&nbsp;</td>" & vbCrLf)
                    strHtml.Append("		<td class=""OTHR"" align=""center"" valign=""top"" rowspan=""2"">" & _
                                fncDateSet(Convert.ToString(ds.Tables(0).Rows(intRow).Item("EDT_DATE"))) & "&nbsp;</td>" & vbCrLf)
                    strHtml.Append("	</tr>" & vbCrLf)

                    ' ������ 2013/07/02 T.Ono add �ڋq�P�ʓo�^�@�\�ǉ� ������
                    '3���
                    strHtml.Append("    <tr>")
                    '�S���҃R�[�h
                    strHtml.Append("		<td class=""OTHR"">" & "" & "</td>" & vbCrLf)
                    '�S���Җ�
                    strHtml.Append("		<td class=""OTHR"">" & "" & "</td>" & vbCrLf)
                    '�A���d�b�ԍ��R
                    strHtml.Append("		<td class=""OTHR"">" & _
                                Convert.ToString(ds.Tables(0).Rows(intRow).Item("RENTEL3")) & "</td>" & vbCrLf)
                    strHtml.Append("		<td class=""OTHR""></td>" & vbCrLf)
                    strHtml.Append("	</tr>" & vbCrLf)
                    ' ������ 2013/07/02 T.Ono add �ڋq�P�ʓo�^�@�\�ǉ� ������

                    If ds.Tables(0).Rows.Count <> 1 Then
                        strHtml.Append("	<tr>")
                        strHtml.Append("	<td widht=""985px"" colspan=""9"">")
                        strHtml.Append("        <table style=""BORDER-BOTTOM: black 1px solid"" cellSpacing=""0"" cellPadding=""0"" width=""100%""><tr><td></td></tr></table>")
                        strHtml.Append("    </td>")
                        strHtml.Append("	</tr>" & vbCrLf)
                    End If

                    intKBNSum = intKBNSum + 1

                    strKBN = Convert.ToString(ds.Tables(0).Rows(intRow).Item("KBN"))
                    strKURACD = Convert.ToString(ds.Tables(0).Rows(intRow).Item("KURACD"))
                    '2016/02/17 H.Mori mod 2015���P�J�� ��9 START
                    'strCODE = Convert.ToString(ds.Tables(0).Rows(intRow).Item("CODE"))
                    'strUSER_CD_FROM = Convert.ToString(ds.Tables(0).Rows(intRow).Item("USER_CD_FROM"))  ' 2013/07/02 T.Ono add
                    'strUSER_CD_TO = Convert.ToString(ds.Tables(0).Rows(intRow).Item("USER_CD_TO"))      ' 2013/07/02 T.Ono add
                    If hdnKEY_KBN.Value = "1" Then
                        strCODE = Convert.ToString(ds.Tables(0).Rows(intRow).Item("GROUPCD"))                       
                    Else
                        strCODE = Convert.ToString(ds.Tables(0).Rows(intRow).Item("CODE"))
                    End If
                    '2016/02/17 H.Mori mod 2015���P�J�� ��9 END
                Next

                strHtml.Append("	<tr>")
                strHtml.Append("		<td height=""5px""></td>" & vbCrLf)
                strHtml.Append("	</tr>")
                strHtml.Append("	<tr>")
                strHtml.Append("		<td class=""COMMT"" colspan=""9"">�@�@���v�@�@" & intKBNSum & "</td>" & vbCrLf)
                strHtml.Append("	</tr>")
                strHtml.Append("</table>" & vbCrLf)

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
        Dim i As Integer
        Dim arrTemp() As String
        Dim strCenter As String = ""
        If hdnBackUrl.Value <> "EIGYOU" Then
            arrTemp = AuthC.pAUTHCENTERCD.Split(Convert.ToChar(","))
            For i = 0 To arrTemp.Length - 1
                If strCenter.Length > 0 Then
                    strCenter = strCenter & ","
                End If
                strCenter = strCenter & "'" & arrTemp(i) & "'"
            Next
        End If
        '2016/02/17 H.Mori add 2015���P�J�� ��9 
        If hdnKEY_KBN.Value = "2" Or hdnKEY_KBN.Value = "3" Then
            pstrSQL.Append("SELECT ")
            pstrSQL.Append("      TA.KBN, ")
            pstrSQL.Append("      TA.KURACD, ")
            pstrSQL.Append("      TA.CODE, ")
            '2016/02/17 H.Mori del 2015���P�J�� ��9
            'pstrSQL.Append("      JA.JAS_NAME, ")        
            pstrSQL.Append("      KA.KANSI_NAME, ")
            pstrSQL.Append("      SH.KAISYA_NAME, ")
            pstrSQL.Append("      TA.TANCD, ")
            pstrSQL.Append("      TA.TANNM, ")
            pstrSQL.Append("      TA.RENTEL1, ")
            pstrSQL.Append("      TA.RENTEL2, ")
            pstrSQL.Append("      FAXNO, ")
            pstrSQL.Append("      TA.DISP_NO, ")
            pstrSQL.Append("      TA.BIKO, ")
            pstrSQL.Append("      TA.ADD_DATE, ")
            pstrSQL.Append("      TA.EDT_DATE ")
            ' ������ 2013/07/01 T.Ono add �ڋq�P�ʓo�^�@�\�ǉ� ������
            pstrSQL.Append("      , ")
            '2016/02/17 H.Mori del 2015���P�J�� ��9
            'pstrSQL.Append("      NULL AS USER_CD_FROM, ")
            '2016/02/17 H.Mori del 2015���P�J�� ��9
            'pstrSQL.Append("      NULL AS USER_CD_TO, ")
            pstrSQL.Append("      TA.AUTO_FAXNO, ")
            pstrSQL.Append("      TA.RENTEL3 ")
            '2016/02/17 H.Mori del 2015���P�J�� ��9
            'pstrSQL.Append("      '01' AS NO, ")   '�ڋq�P�ʂ̓o�^�Ƌ��
            '2016/02/17 H.Mori del 2015���P�J�� ��9
            'pstrSQL.Append("      DECODE(TA.CODE,'XXXX','01','02') AS NO2 ")   '�N���C�A���g�݂̂̓o�^�����
            ' ������ 2013/07/01 T.Ono add �ڋq�P�ʓo�^�@�\�ǉ� ������
            pstrSQL.Append("FROM  M05_TANTO TA, ")
            pstrSQL.Append("      HN2MAS JA, ")
            pstrSQL.Append("      KANSIMAS KA,")

            '--- ��2005/04/29 ADD Falcon�� ---
            pstrSQL.Append("      CLIMAS CL, ")
            '--- ��2005/04/29 ADD Falcon�� ---

            pstrSQL.Append("      SHUTUDOMAS SH ")
            pstrSQL.Append("WHERE TA.KURACD = JA.CLI_CD(+) ")

            '--- ��2005/04/29 ADD Falcon�� ---
            pstrSQL.Append("  AND TA.KURACD = CL.CLI_CD(+) ")
            '--- ��2005/04/29 ADD Falcon�� ---

            '2016/02/17 H.Mori del 2015���P�J�� ��9
            'pstrSQL.Append("  AND TA.CODE = JA.HAN_CD(+) ")
            pstrSQL.Append("  AND TA.CODE = KA.KANSI_CD(+) ")

            '--- ��2005/07/13 MOD Falcon�� ---  �o����ЃR�[�h�{���_�R�[�h�Ō���
            'pstrSQL.Append("  AND TA.CODE = SH.SHUTU_CD(+) ")
            pstrSQL.Append("  AND TA.CODE = SH.SHUTU_CD(+) || SH.KYOTEN_CD(+)")
            '--- ��2005/07/13 MOD Falcon�� ---

            'pstrSQL.Append("  AND '00' = SH.KYOTEN_CD(+) ")    '--- 2005/07/20 DEL Falcon

            '--- ��2005/04/29 ADD Falcon�� ---
            If hdnBackUrl.Value <> "EIGYOU" Then
                pstrSQL.Append("  AND ((TA.KBN='1' AND KA.KANSI_CD IN (" & strCenter & ")) ")
                pstrSQL.Append("      OR (TA.KBN='2'AND SH.KANSI_CD IN (" & strCenter & "))) ")
                '2016/02/17 H.Mori del 2015���P�J�� ��9
                'pstrSQL.Append("      OR (TA.KBN='3' AND CL.KANSI_CODE IN (" & strCenter & "))) ")
            End If
            '--- ��2005/04/29 ADD Falcon�� ---

            '--- ��2007/07/31 ADD T.Watabe�� ---

            '2016/02/17 H.Mori del 2015���P�J�� ��9 START
            'If hdnKEY_KBN.Value = "1" Or hdnKEY_KBN.Value = "2" Or hdnKEY_KBN.Value = "3" Then
            ' 1:JA�x��/2:�Ď��Z���^�[/3:�o�����

            'M05_TANTO KBN      �y�敪�z                1:�Ď��Z���^�[�S���ҁ@2:�o����ВS���� 3:JA�x���S����
            'M05_TANTO KURACD   �y�N���C�A���g�R�[�h�z  JA�x���̏ꍇ�N���C�A���g�R�[�h�A���̑��̏ꍇ�AALL�uZ�v���Z�b�g
            'M05_TANTO CODE     �y�R�[�h�z              �Ď��Z���^�[�R�[�h�܂��͏o����ЃR�[�h�܂���JA�x���R�[�h

            '2016/02/17 H.Mori del 2015���P�J�� ��9 START
            'If hdnKEY_KBN.Value = "1" Then '1:JA�x��
            '    pstrSQL.Append("  AND TA.KBN='3' ")
            '2016/02/17 H.Mori del 2015���P�J�� ��9 END
            If hdnKEY_KBN.Value = "2" Then '2:�Ď��Z���^�[
                pstrSQL.Append("  AND TA.KBN='1' ")
            ElseIf hdnKEY_KBN.Value = "3" Then '3:�o�����
                pstrSQL.Append("  AND TA.KBN='2' ")
            End If
            '2012/04/04 NEC ou Add Upd Str
            '2016/02/17 H.Mori del 2015���P�J�� ��9 START
            'If hdnKEY_KURACD.Value.Trim <> "" Then '�N���C�A���g�R�[�h
            '    pstrSQL.Append("  AND TA.KURACD = '" & hdnKEY_KURACD.Value.Trim & "' ")
            'End If
            '2016/02/17 H.Mori del 2015���P�J�� ��9 END
            If hdnKEY_CODE.Value.Trim <> "" Then '�R�[�h
                pstrSQL.Append("  AND TA.CODE = '" & hdnKEY_CODE.Value.Trim & "' ")
            End If
            '2012/04/04 NEC ou Add Upd End
            '2016/02/17 H.Mori del 2015���P�J�� ��9 START
            'If hdnKEY_JACD.Value <> "" Then 'JA�R�[�h(�O����v)
            '    pstrSQL.Append("  AND TA.CODE LIKE '" & hdnKEY_JACD.Value & "%' ")
            'End If
            '2016/02/17 H.Mori del 2015���P�J�� ��9 END
            '2016/02/17 H.Mori del 2015���P�J�� ��9 START
            '2016/02/08 H.Mori 2015���P�J�� ��9 START
            '2015/11/02 w.ganeko 2015���P�J�� ��9 start
            'If hdnKEY_TANTOTEL.Value <> "" Then
            '    pstrSQL.Append("  AND ( ")
            '    pstrSQL.Append("  TA.RENTEL1 = '" & hdnKEY_TANTOTEL.Value & "' ")
            '    pstrSQL.Append("  OR TA.RENTEL2 = '" & hdnKEY_TANTOTEL.Value & "' ")
            '    pstrSQL.Append("  OR TA.RENTEL3 = '" & hdnKEY_TANTOTEL.Value & "' ")
            '    pstrSQL.Append("  ) ")
            'End If
            '2015/11/02 w.ganeko 2015���P�J�� ��9 end
            'If hdnKEY_TANTOTEL.Value <> "" Then
            '    pstrSQL.Append("  AND ( ")
            '    pstrSQL.Append("  REPLACE(REPLACE(TA.RENTEL1,'-',''), ' ','') ")
            '    pstrSQL.Append("  LIKE REPLACE('" & hdnKEY_TANTOTEL.Value & "','-','') || '%' ")
            '    pstrSQL.Append("  OR REPLACE(REPLACE(TA.RENTEL2,'-',''), ' ','') ")
            '    pstrSQL.Append("  LIKE REPLACE('" & hdnKEY_TANTOTEL.Value & "','-','') || '%' ")
            '    pstrSQL.Append("  OR REPLACE(REPLACE(TA.RENTEL3,'-',''), ' ','') ")
            '    pstrSQL.Append("  LIKE REPLACE('" & hdnKEY_TANTOTEL.Value & "','-','') || '%' ")
            '    pstrSQL.Append("  ) ")
            'End If
            '2016/02/08 H.Mori 2015���P�J�� ��9 END
            'End If
            '2016/02/17 H.Mori del 2015���P�J�� ��9 END
            '--- ��2007/07/31 ADD T.Watabe�� ---

            '2016/02/17 H.Mori add 2015���P�J�� ��9 
            pstrSQL.Append("ORDER BY KURACD,CODE,TANCD")
        End If


        '2016/02/17 H.Mori del START M05_TANTO2 �� M09JAGROUP 
        '' ������ 2013/07/01 T.Ono add �ڋq�P�ʓo�^�@�\�ǉ� ������
        ''JA�x���S���҂̏ꍇ�́AM05_TANTO2(�ڋq�P�ʓo�^�}�X�^)������f�[�^���擾����
        'If hdnKEY_KBN.Value = "1" Then     'hdnKEY_KBN�@1:JA�x��/2:�Ď��Z���^�[/3:�o�����
        '    pstrSQL.Append("UNION ALL ")
        '    pstrSQL.Append("SELECT ")
        '    pstrSQL.Append("      TA.KBN, ")
        '    pstrSQL.Append("      TA.KURACD, ")
        '    pstrSQL.Append("      TA.CODE, ")
        '    pstrSQL.Append("      JA.JAS_NAME, ")
        '    pstrSQL.Append("      NULL AS KANSI_NAME, ")
        '    pstrSQL.Append("      NULL AS KAISYA_NAME, ")
        '    pstrSQL.Append("      TA.TANCD, ")
        '    pstrSQL.Append("      TA.TANNM, ")
        '    pstrSQL.Append("      TA.RENTEL1, ")
        '    pstrSQL.Append("      TA.RENTEL2, ")
        '    pstrSQL.Append("      TA.FAXNO, ")
        '    pstrSQL.Append("      TA.DISP_NO, ")
        '    pstrSQL.Append("      TA.BIKO, ")
        '    pstrSQL.Append("      TA.ADD_DATE, ")
        '    pstrSQL.Append("      TA.EDT_DATE, ")
        '    pstrSQL.Append("      TA.USER_CD_FROM, ")
        '    pstrSQL.Append("      TA.USER_CD_TO, ")
        '    pstrSQL.Append("      TA.AUTO_FAXNO, ")
        '    pstrSQL.Append("      TA.RENTEL3, ")
        '    pstrSQL.Append("      '02' AS NO, ")   '�ڋq�P�ʂ̓o�^�Ƌ��
        '    pstrSQL.Append("      '02' AS NO2 ")   '�N���C�A���g�݂̂̓o�^�Ƌ��
        '    pstrSQL.Append("FROM  M05_TANTO2 TA, ")
        '    pstrSQL.Append("      HN2MAS JA, ")
        '    pstrSQL.Append("      CLIMAS CL ")
        '    pstrSQL.Append("WHERE TA.KURACD = JA.CLI_CD(+) ")
        '    pstrSQL.Append("  AND TA.KURACD = CL.CLI_CD(+) ")
        '    pstrSQL.Append("  AND TA.CODE = JA.HAN_CD(+) ")
        '    pstrSQL.Append("  AND TA.KBN='3' ")
        '    If hdnBackUrl.Value <> "EIGYOU" Then
        '        pstrSQL.Append("  AND CL.KANSI_CODE IN (" & strCenter & ") ")
        '    End If

        '    'M05_TANTO KBN      �y�敪�z                1:�Ď��Z���^�[�S���ҁ@2:�o����ВS���� 3:JA�x���S����
        '    'M05_TANTO KURACD   �y�N���C�A���g�R�[�h�z  JA�x���̏ꍇ�N���C�A���g�R�[�h�A���̑��̏ꍇ�AALL�uZ�v���Z�b�g
        '    'M05_TANTO CODE     �y�R�[�h�z              �Ď��Z���^�[�R�[�h�܂��͏o����ЃR�[�h�܂���JA�x���R�[�h

        '    If hdnKEY_KURACD.Value.Trim <> "" Then '�N���C�A���g�R�[�h
        '        pstrSQL.Append("  AND TA.KURACD = '" & hdnKEY_KURACD.Value.Trim & "' ")
        '    End If
        '    If hdnKEY_CODE.Value.Trim <> "" Then '�R�[�h
        '        pstrSQL.Append("  AND TA.CODE = '" & hdnKEY_CODE.Value.Trim & "' ")
        '    End If
        '    If hdnKEY_JACD.Value <> "" Then 'JA�R�[�h(�O����v)
        '        pstrSQL.Append("  AND TA.CODE LIKE '" & hdnKEY_JACD.Value & "%' ")
        '    End If
        '    '2015/11/02 w.ganeko 2015���P�J�� ��9 start
        '    If hdnKEY_TANTOTEL.Value <> "" Then
        '        pstrSQL.Append("  AND ( ")
        '        pstrSQL.Append("  TA.RENTEL1 = '" & hdnKEY_TANTOTEL.Value & "' ")
        '        pstrSQL.Append("  OR TA.RENTEL2 = '" & hdnKEY_TANTOTEL.Value & "' ")
        '        pstrSQL.Append("  OR TA.RENTEL3 = '" & hdnKEY_TANTOTEL.Value & "' ")
        '        pstrSQL.Append("  ) ")
        '    End If
        '    '2015/11/02 w.ganeko 2015���P�J�� ��9 end
        'End If
        '' ������ 2013/07/01 T.Ono add �ڋq�P�ʓo�^�@�\�ǉ� ������
        '2016/02/17 H.Mori del START M05_TANTO2 �� M09JAGROUP 

        '2016/02/17 H.Mori add 2015���P�J�� ��9 START
        If hdnKEY_KBN.Value = "1" Then     'hdnKEY_KBN�@1:JA�x��/2:�Ď��Z���^�[/3:�o�����
            pstrSQL.Append("SELECT DISTINCT ")
            pstrSQL.Append("      ' ' AS KBN, ")
            pstrSQL.Append("      NVL(M09.KURACD,'ZZZZ') KURACD, ")
            pstrSQL.Append("      M11.GROUPCD, ")
            'pstrSQL.Append("      M11.GROUPNM, ")'2016/03/24 T.Ono mod 2015���P�J��
            pstrSQL.Append("      NVL(M11.GROUPNM, M11B.GROUPNM) AS GROUPNM,  ")
            pstrSQL.Append("      M11.TANCD, ")
            pstrSQL.Append("      M11.TANNM, ")
            pstrSQL.Append("      M11.RENTEL1, ")
            pstrSQL.Append("      M11.RENTEL2, ")
            pstrSQL.Append("      M11.RENTEL3, ")
            pstrSQL.Append("      M11.FAXNO, ")
            pstrSQL.Append("      M11.BIKO, ")
            pstrSQL.Append("      TO_CHAR(M11.INS_DATE,'YYYYMMDD') AS ADD_DATE, ")
            pstrSQL.Append("      TO_CHAR(M11.UPD_DATE,'YYYYMMDD') AS EDT_DATE, ")
            pstrSQL.Append("      M11.AUTO_FAXNO ")
            pstrSQL.Append("FROM  M09_JAGROUP M09, ")
            pstrSQL.Append("      M11_JAHOKOKU M11, ")
            pstrSQL.Append("      M11_JAHOKOKU M11B, ")
            pstrSQL.Append("      HN2MAS JA, ")
            pstrSQL.Append("      CLIMAS CL ")
            pstrSQL.Append("WHERE M09.KURACD = JA.CLI_CD(+) ")
            pstrSQL.Append("  AND M09.ACBCD = JA.HAN_CD(+) ")
            pstrSQL.Append("  AND M09.KBN(+) = '002' ")
            pstrSQL.Append("  AND M11.KBN(+) = '2' ")
            pstrSQL.Append("  AND M09.GROUPCD(+) = M11.GROUPCD ")
            pstrSQL.Append("  AND M11.GROUPCD = M11B.GROUPCD ")      '2016/03/24 T.Ono add 2015���P�J��
            pstrSQL.Append("  AND M11.KBN = M11B.KBN ")              '2016/03/24 T.Ono add 2015���P�J��
            pstrSQL.Append("  AND LPAD(M11B.TANCD, 2, '0') = '01' ") '2016/03/24 T.Ono add 2015���P�J��
            If hdnBackUrl.Value <> "EIGYOU" Then
                pstrSQL.Append("  AND CL.KANSI_CODE IN (" & strCenter & ") ")
            End If
            If hdnKEY_KURACD.Value.Trim <> "" Then '�N���C�A���g�R�[�h
                pstrSQL.Append("  AND M09.KURACD = '" & hdnKEY_KURACD.Value.Trim & "' ")
            End If
            If hdnKEY_CODE.Value.Trim <> "" Then 'JA�x���R�[�h
                pstrSQL.Append("  AND M09.ACBCD = '" & hdnKEY_CODE.Value.Trim & "' ")
            End If
            If hdnKEY_GROUPCD.Value.Trim <> "" Then '�O���[�v�R�[�h�E����
                pstrSQL.Append("  AND M11.GROUPCD = '" & hdnKEY_GROUPCD.Value.Trim & "' ")
            End If
            If hdnKEY_JACD.Value <> "" Then 'JA�R�[�h(�O����v)
                pstrSQL.Append("  AND M09.ACBCD LIKE '" & hdnKEY_JACD.Value & "%' ")
            End If
            If hdnKEY_TANTOTEL.Value <> "" Then '�i�`�E�S���ҘA����(�O����v)
                pstrSQL.Append("  AND ( ")
                pstrSQL.Append("  REPLACE(REPLACE(M11.RENTEL1,'-',''), ' ','') ")
                pstrSQL.Append("  LIKE REPLACE('" & hdnKEY_TANTOTEL.Value & "','-','') || '%' ")
                pstrSQL.Append("  OR REPLACE(REPLACE(M11.RENTEL2,'-',''), ' ','') ")
                pstrSQL.Append("  LIKE REPLACE('" & hdnKEY_TANTOTEL.Value & "','-','') || '%' ")
                pstrSQL.Append("  OR REPLACE(REPLACE(M11.RENTEL3,'-',''), ' ','') ")
                '2016/03/24 T.Ono add 2015���P�J�� �Ď��A�c�l����FAX���������Ăق����Ƃ̗v�]
                pstrSQL.Append("  LIKE REPLACE('" & hdnKEY_TANTOTEL.Value & "','-','') || '%' ")
                pstrSQL.Append("  OR REPLACE(REPLACE(M11.FAXNO,'-',''), ' ','')  ")
                pstrSQL.Append("  LIKE REPLACE('" & hdnKEY_TANTOTEL.Value & "','-','') || '%' ")
                pstrSQL.Append("  OR REPLACE(REPLACE(M11.AUTO_FAXNO,'-',''), ' ','')  ")
                pstrSQL.Append("  LIKE REPLACE('" & hdnKEY_TANTOTEL.Value & "','-','') || '%' ")
                pstrSQL.Append("  ) ")
            End If
            pstrSQL.Append("ORDER BY KURACD,GROUPCD,TANCD")
        End If
        '2016/02/17 H.Mori add 2015���P�J�� ��9 END

        ' 2013/07/01 T.Ono mod 
        ''--- ��2005/07/19 MOD Falcon�� ---
        ''pstrSQL.Append("ORDER BY KBN,CODE")
        'pstrSQL.Append("ORDER BY KBN,KURACD,CODE,TANCD")
        ''--- ��2005/07/19 MOD Falcon�� ---

        '2016/02/17 H.Mori del 2015���P�J�� ��9
        'pstrSQL.Append("ORDER BY KBN,NO2,KURACD,CODE,NO,USER_CD_TO,USER_CD_FROM,TANCD")

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
