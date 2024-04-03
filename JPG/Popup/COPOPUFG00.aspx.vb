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

Partial Class COPOPUFG00
    Inherits System.Web.UI.Page
    Protected WithEvents dbSet As System.Data.DataSet

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
            Case "JASS2"                     '�i�`�x���ꗗ��\��(JA�����o�͂���)
                Call mMakeSQL_JASS2(strSQL, SqlParamC)
                dbSet = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)
            Case "JASS3"                     '�i�`�x���ꗗ��\��(JA�R�[�h�͈ꗗ�ɕ\�����Ȃ�)�@'2014/10/02 T.Ono mod 2014���P�J�� No19
                Call mMakeSQL_JASS3(strSQL, SqlParamC)
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
            Case "KENCD"                    '���R�[�h�ꗗ��\��
                Call mMakeSQL_KENCD(strSQL, SqlParamC)
                dbSet = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)
            Case "TKTANCDKN_ORDCD"          '�Ď��Z���^�[�S���҈ꗗ��\��(�Ď��Z���^�[�R�[�h���o��) �S���҃R�[�h���@2014/02/07 T.Ono add �Ď����P
                Call mMakeSQL_TKTANCDKN_ORDCD(strSQL, SqlParamC)
                dbSet = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)
            Case "HANG"                    '�̔����Ǝ҃O���[�v�ꗗ(���g�p�O���[�v�܂܂Ȃ��j�@'2014/12/04 H.Hosoda add 2014���P�J�� No6
                Call mMakeSQL_HANG(strSQL, SqlParamC)
                dbSet = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)
            Case "HANG2"                     '�̔����Ǝ҃O���[�v�ꗗ�@'2014/10/08 T.Ono add 2014���P�J�� No19
                Call mMakeSQL_HANG2(strSQL, SqlParamC)
                dbSet = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)
            Case "JATANMAS"                  'M05_TANTO/2�}�X�^�@�o�^�ς݈ꗗ�@'2015/02/18 T.Ono add 2014���P�J�� No15
                Call mMakeSQL_JATANMAS(strSQL, SqlParamC)
                dbSet = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)
            Case "JAHOKOKU"                  'M11_JAHOKOKU�}�X�^�@�O���[�v�R�[�h�ꗗ�@'2015/11/18 T.Ono add 2015���P�J�� No7
                Call mMakeSQL_JAHOKOKU(strSQL, SqlParamC)
                dbSet = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)
            Case "JAHOKOKU2"                 '�ً}�A����Gr�ꗗ(���g�p�O���[�v�܂܂Ȃ��j�@'2016/11/17 H.Mori add 2016���P�J�� No2-1
                Call mMakeSQL_JAHOKOKU2(strSQL, SqlParamC)
                dbSet = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)
            Case "AUTOGROUP"                  'M08_AUTOTAIOU�}�X�^�@�O���[�v�R�[�h�ꗗ�@'2017/02/09 W.Ganeko add 2016���P�J�� No10
                Call mMakeSQL_AUTOGROUP(strSQL, SqlParamC)
                dbSet = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)
            Case "HANBAITEN"                  'M12_HANBAITEN�}�X�^�@�O���[�v�R�[�h�ꗗ�@'2019/01/10 T.Ono add 2018���P�J��
                Call mMakeSQL_HANBAITEN(strSQL, SqlParamC)
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
        'strMsg.Append("function fncPutData(strcd,strnm){")
        strMsg.Append("function fncPutData(strcd,strnm,strcd2,strnm2){")
        If strDBFlg = "" Then
            '2015/11/02 w.ganeko 2015���P�J�� start
            strMsg.Append("var oener = null;" + vbCrLf)
            strMsg.Append("try{" + vbCrLf)
            strMsg.Append("  oener = parent.opener.frames(""data"");" + vbCrLf)
            strMsg.Append("} catch(e){" + vbCrLf)
            strMsg.Append("  oener = parent.opener;" + vbCrLf)
            strMsg.Append("}" + vbCrLf)
            '2015/11/02 w.ganeko 2015���P�J�� end
            strMsg.Append("if(strcd==' '){strcd=='';}" + vbCrLf)
            strMsg.Append("if(strnm==' '){strnm=='';}" + vbCrLf)
            '// �R�[�h�f�[�^�̃Z�b�g
            If COPOPUPG00_C.pBackCode <> "" Then
                'strMsg.Append("obj1=parent.opener.frames(""data"").document.getElementById(""" & COPOPUPG00_C.pBackCode & """);") 2015/11/02 w.ganeko ��9 mod
                strMsg.Append("obj1=oener.document.getElementById(""" & COPOPUPG00_C.pBackCode & """);" + vbCrLf)
                strMsg.Append("if(obj1!=null) {" + vbCrLf)
                strMsg.Append("if(obj1.value!=strcd) {" + vbCrLf)
                If COPOPUPG00_C.pClear1.Length > 0 Then
                    'strMsg.Append("obj4=parent.opener.frames(""data"").document.getElementById(""" & COPOPUPG00_C.pClear1 & """);") 2015/11/02 w.ganeko ��9 mod
                    strMsg.Append("obj4=oener.document.getElementById(""" & COPOPUPG00_C.pClear1 & """);" + vbCrLf)
                    strMsg.Append("obj4.value='';")
                End If
                If COPOPUPG00_C.pClear2.Length > 0 Then
                    'strMsg.Append("obj5=parent.opener.frames(""data"").document.getElementById(""" & COPOPUPG00_C.pClear2 & """);") 2015/11/02 w.ganeko ��9 mod
                    strMsg.Append("obj5=oener.document.getElementById(""" & COPOPUPG00_C.pClear2 & """);" + vbCrLf)
                    strMsg.Append("obj5.value='';")
                End If
                If COPOPUPG00_C.pClear3.Length > 0 Then
                    'strMsg.Append("obj6=parent.opener.frames(""data"").document.getElementById(""" & COPOPUPG00_C.pClear3 & """);") 2015/11/02 w.ganeko ��9 mod
                    strMsg.Append("obj6=oener.document.getElementById(""" & COPOPUPG00_C.pClear3 & """);" + vbCrLf)
                    strMsg.Append("obj6.value='';")
                End If
                If COPOPUPG00_C.pClear4.Length > 0 Then
                    'strMsg.Append("obj7=parent.opener.frames(""data"").document.getElementById(""" & COPOPUPG00_C.pClear4 & """);") 2015/11/02 w.ganeko ��9 mod
                    strMsg.Append("obj7=oener.document.getElementById(""" & COPOPUPG00_C.pClear4 & """);" + vbCrLf)
                    strMsg.Append("obj7.value='';")
                End If
                If COPOPUPG00_C.pClear5.Length > 0 Then
                    'strMsg.Append("obj8=parent.opener.frames(""data"").document.getElementById(""" & COPOPUPG00_C.pClear5 & """);") 2015/11/02 w.ganeko ��9 mod
                    strMsg.Append("obj8=oener.document.getElementById(""" & COPOPUPG00_C.pClear5 & """);" + vbCrLf)
                    strMsg.Append("obj8.value='';")
                End If
                If COPOPUPG00_C.pClear6.Length > 0 Then
                    'strMsg.Append("obj9=parent.opener.frames(""data"").document.getElementById(""" & COPOPUPG00_C.pClear6 & """);") 2015/11/02 w.ganeko ��9 mod
                    strMsg.Append("obj9=oener.document.getElementById(""" & COPOPUPG00_C.pClear6 & """);" + vbCrLf)
                    strMsg.Append("obj9.value='';")
                End If
                '2014/12/11 H.Hosoda add 2014���P�J�� No13 START
                If COPOPUPG00_C.pClear7.Length > 0 Then
                    'strMsg.Append("obj12=parent.opener.frames(""data"").document.getElementById(""" & COPOPUPG00_C.pClear7 & """);") 2015/11/02 w.ganeko ��9 mod
                    strMsg.Append("obj12=oener.document.getElementById(""" & COPOPUPG00_C.pClear7 & """);" + vbCrLf)
                    strMsg.Append("obj12.value='';")
                End If
                If COPOPUPG00_C.pClear8.Length > 0 Then
                    'strMsg.Append("obj13=parent.opener.frames(""data"").document.getElementById(""" & COPOPUPG00_C.pClear8 & """);")  2015/11/02 w.ganeko ��9 mod
                    strMsg.Append("obj13=oener.document.getElementById(""" & COPOPUPG00_C.pClear8 & """);" + vbCrLf)
                    strMsg.Append("obj13.value='';")
                End If
                '2015/11/04 w.ganeko 2015���P�J�� ��6 START
                If COPOPUPG00_C.pClear9.Length > 0 Then
                    strMsg.Append("obj14=oener.document.getElementById(""" & COPOPUPG00_C.pClear9 & """);" + vbCrLf)
                    strMsg.Append("obj14.value='';")
                End If
                If COPOPUPG00_C.pClear10.Length > 0 Then
                    strMsg.Append("obj15=oener.document.getElementById(""" & COPOPUPG00_C.pClear10 & """);" + vbCrLf)
                    strMsg.Append("obj15.value='';")
                End If
                If COPOPUPG00_C.pClear11.Length > 0 Then
                    strMsg.Append("obj16=oener.document.getElementById(""" & COPOPUPG00_C.pClear11 & """);" + vbCrLf)
                    strMsg.Append("obj16.value='';")
                End If
                If COPOPUPG00_C.pClear12.Length > 0 Then
                    strMsg.Append("obj17=oener.document.getElementById(""" & COPOPUPG00_C.pClear12 & """);" + vbCrLf)
                    strMsg.Append("obj17.value='';")
                End If
                If COPOPUPG00_C.pClear13.Length > 0 Then
                    strMsg.Append("obj18=oener.document.getElementById(""" & COPOPUPG00_C.pClear13 & """);" + vbCrLf)
                    strMsg.Append("obj18.value='';")
                End If
                If COPOPUPG00_C.pClear14.Length > 0 Then
                    strMsg.Append("obj19=oener.document.getElementById(""" & COPOPUPG00_C.pClear14 & """);" + vbCrLf)
                    strMsg.Append("obj19.value='';")
                End If
                '2015/11/04 w.ganeko 2015���P�J�� ��6 END
                '2014/12/11 H.Hosoda add 2014���P�J�� No13 END
                strMsg.Append("}" + vbCrLf)
                strMsg.Append("}" + vbCrLf)
                strMsg.Append("obj1.value=strcd;" + vbCrLf)
            End If
            If COPOPUPG00_C.pBackMode = "1" Then
                'strMsg.Append("strcd2=strcd;" + vbCrLf)
                'strMsg.Append("strnm2=strnm;" + vbCrLf)
                'strMsg.Append("obj20=oener.document.getElementById(""" & COPOPUPG00_C.pBackName & """);" + vbCrLf)
                'strMsg.Append("obj20.fireEvent(""onchange"");" + vbCrLf)
            End If

            '// ���O�f�[�^�̃Z�b�g
            If COPOPUPG00_C.pBackName <> "" Then
                'strMsg.Append("obj2=parent.opener.frames(""data"").document.getElementById(""" & COPOPUPG00_C.pBackName & """);")   2015/11/02 w.ganeko ��9 mod
                strMsg.Append("obj2=oener.document.getElementById(""" & COPOPUPG00_C.pBackName & """);" + vbCrLf)
                strMsg.Append("obj2.value=strnm;")
            End If
            '// ���O�f�[�^�̃Z�b�g
            If COPOPUPG00_C.pBackCode2 <> "" Then
                'strMsg.Append("obj10=parent.opener.frames(""data"").document.getElementById(""" & COPOPUPG00_C.pBackCode2 & """);")    2015/11/02 w.ganeko ��9 mod
                strMsg.Append("obj10=oener.document.getElementById(""" & COPOPUPG00_C.pBackCode2 & """);" + vbCrLf)
                strMsg.Append("obj10.value=strcd2;")
            End If
            If COPOPUPG00_C.pBackName2 <> "" Then
                'strMsg.Append("obj11=parent.opener.frames(""data"").document.getElementById(""" & COPOPUPG00_C.pBackName2 & """);")    2015/11/02 w.ganeko ��9 mod
                strMsg.Append("obj11=oener.document.getElementById(""" & COPOPUPG00_C.pBackName2 & """);" + vbCrLf)
                strMsg.Append("obj11.value=strnm2;")
            End If
            '// �t�H�[�J�X�̃Z�b�g
            If COPOPUPG00_C.pBackFocs <> "" Then
                'strMsg.Append("obj3=parent.opener.frames(""data"").document.getElementById(""" & COPOPUPG00_C.pBackFocs & """);")   2015/11/02 w.ganeko ��9 mod
                strMsg.Append("obj3=oener.document.getElementById(""" & COPOPUPG00_C.pBackFocs & """);")
                strMsg.Append("obj3.focus();")
            End If
            '// JavaScript�̎��s
            If COPOPUPG00_C.pBackScript <> "" Then
                'strMsg.Append("parent.opener.frames(""data"")." & COPOPUPG00_C.pBackScript & "();") 2015/11/02 w.ganeko ��9 mod
                strMsg.Append("oener." & COPOPUPG00_C.pBackScript & "();")
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
        strSQL.Append("' ' AS CDNM, ")
        strSQL.Append("' ' AS CODE2, ")
        strSQL.Append("' ' AS CDNM2 ")
        strSQL.Append("FROM ")
        strSQL.Append("DUAL ")
        strSQL.Append("UNION ALL ")
        strSQL.Append("SELECT ")
        strSQL.Append("CLI_CD AS CODE, ")
        strSQL.Append("CLI_NAME AS NAME, ")
        strSQL.Append("CLI_CD || ' : ' || CLI_NAME AS CDNM, ")
        strSQL.Append("KEN_CODE AS CODE2, ")
        strSQL.Append("KEN_CODE || ':' || KEN_NAME AS CDNM2 ")
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
        strSQL.Append("' ' AS CDNM, ")
        strSQL.Append("' ' AS CODE2, ")
        strSQL.Append("' ' AS CDNM2 ")
        strSQL.Append("FROM ")
        strSQL.Append("DUAL ")
        strSQL.Append("UNION ALL ")
        strSQL.Append("SELECT ")
        strSQL.Append("HAN_CD AS CODE, ")
        strSQL.Append("JAS_NAME AS NAME, ")
        strSQL.Append("HAN_CD || ' : ' || JA_NAME || '/' || JAS_NAME AS CDNM, ")
        strSQL.Append("' ' AS CODE2, ")
        strSQL.Append("' ' AS CDNM2 ")
        strSQL.Append("FROM HN2MAS ")
        strSQL.Append("WHERE CLI_CD = :CLI_CD ")
        strSQL.Append("AND NVL(DEL_FLG,'0') <> '1' ") ' 2008/10/29 T.Watabe add
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
        strSQL.Append("' ' AS CDNM, ")
        strSQL.Append("' ' AS CODE2, ")
        strSQL.Append("' ' AS CDNM2 ")
        strSQL.Append("FROM ")
        strSQL.Append("DUAL ")
        strSQL.Append("UNION ALL ")
        strSQL.Append("SELECT ")
        strSQL.Append("DISTINCT ")
        strSQL.Append("JA_CD AS CODE, ")
        strSQL.Append("JA_NAME AS NAME, ")
        strSQL.Append("JA_CD || ' : ' || JA_NAME  AS CDNM, ")
        '2019/11/01 T.Ono mod �Ď����P2019 No1
        'strSQL.Append("' ' AS CODE2, ")
        strSQL.Append("CLI_CD AS CODE2, ")
        strSQL.Append("' ' AS CDNM2 ")
        strSQL.Append("FROM HN2MAS ")
        '2019/11/01 T.Ono mod �Ď����P2019 No1
        'strSQL.Append("WHERE CLI_CD = :CLI_CD ")
        If COPOPUPG00_C.pCode3.Length > 0 Then
            strSQL.Append("WHERE CLI_CD >= :CLI_CD ")
            strSQL.Append("  AND CLI_CD <= :CLI_CD_TO ")
        Else
            strSQL.Append("WHERE CLI_CD = :CLI_CD ")
        End If
        strSQL.Append("AND NVL(DEL_FLG,'0') <> '1' ") ' 2008/10/29 T.Watabe add
        '--- ��2005/05/24 MOD Falcon�� ---
        If COPOPUPG00_C.pCode2.Length > 0 Then
            strSQL.Append("  AND HAISO_CD = :HAISO_CD ")
        End If
        '--- ��2005/05/24 MOD Falcon�� ---
        ''''DISTINCT�ɂĂi�`�̒��o�Ƃ���(�ȏ�̓}�X�^�������s��)
        ''''strSQL.Append("  AND LENGTH(HAN_CD) = TO_NUMBER(HAN_KETA) ")
        '2019/11/01 T.Ono mod �Ď����P2019 No1
        'strSQL.Append("ORDER BY CODE ")
        strSQL.Append("ORDER BY CODE2, CODE ")

        SqlParamC.fncSetParam("CLI_CD", True, COPOPUPG00_C.pCode1)
        '--- ��2005/05/24 MOD Falcon�� ---
        If COPOPUPG00_C.pCode2.Length > 0 Then
            SqlParamC.fncSetParam("HAISO_CD", True, COPOPUPG00_C.pCode2)
        End If
        '--- ��2005/05/24 MOD Falcon�� ---
        '2019/11/01 T.Ono add �Ď����P2019 No1
        If COPOPUPG00_C.pCode3.Length > 0 Then
            SqlParamC.fncSetParam("CLI_CD_TO", True, COPOPUPG00_C.pCode3)
        End If
    End Sub

    '******************************************************************************
    ' �i�`�x���ꗗ
    '******************************************************************************
    Private Sub mMakeSQL_JASS(ByVal strSQL As StringBuilder, ByVal SqlParamC As CSQLParam)

        '2020/02/21 T.Ono mod Oracle Alert�΍� UNION ALL�̑O�����ւ� START
        'strSQL.Append("SELECT ")
        'strSQL.Append("' ' AS CODE, ")
        'strSQL.Append("' ' AS NAME, ")
        'strSQL.Append("' ' AS CDNM, ")
        'strSQL.Append("' ' AS CODE2, ")
        'strSQL.Append("' ' AS CDNM2 ")
        'strSQL.Append("FROM ")
        'strSQL.Append("DUAL ")
        'strSQL.Append("UNION ALL ")
        'strSQL.Append("SELECT ")
        'strSQL.Append("HAN_CD AS CODE, ")
        'strSQL.Append("JAS_NAME AS NAME, ")
        'strSQL.Append("HAN_CD || ' : ' || JAS_NAME AS CDNM, ")
        ''2019/11/01 T.Ono mod �Ď����P2019 No1
        ''strSQL.Append("' ' AS CODE2, ")
        'strSQL.Append("CLI_CD AS CODE2, ")
        'strSQL.Append("' ' AS CDNM2 ")
        'strSQL.Append("FROM HN2MAS ")
        'strSQL.Append("WHERE CLI_CD = :CLI_CD ")
        'strSQL.Append("AND NVL(DEL_FLG,'0') <> '1' ") ' 2008/10/29 T.Watabe add
        'If COPOPUPG00_C.pCode2.Length > 0 Then
        '    strSQL.Append("  AND JA_CD = :JA_CD ")
        'End If
        ''2014/12/04 H.Hosoda add 2014���P�J�� No6 START
        'If COPOPUPG00_C.pCode3.Length > 0 Then
        '    strSQL.Append("  AND EXISTS (SELECT * FROM M09_JAGROUP JG WHERE GROUPCD = :HAN_GRP AND HN2MAS.HAN_CD = JG.ACBCD) ")
        'End If
        ''2014/12/04 H.Hosoda add 2014���P�J�� No6 END
        ''2016/11/21 H.Mori add 2016���P�J�� No2-1 START
        'If COPOPUPG00_C.pCode4.Length > 0 Then
        '    strSQL.Append("  AND EXISTS (SELECT * FROM M09_JAGROUP JG WHERE GROUPCD = :JAHOKOKU_GRP AND HN2MAS.HAN_CD = JG.ACBCD) ")
        'End If
        ''2016/11/21 H.Mori add 2016���P�J�� No2-1 END
        ''''''���}�X�^�ɂ͂i�`�x���f�[�^�������݂��Ȃ�
        '''''strSQL.Append("  AND LENGTH(HAN_CD) = TO_NUMBER(HAN_KETA) + TO_NUMBER(JA_KETA) ")
        ''2019/11/01 T.Ono mod �Ď����P2019 No1
        ''strSQL.Append("ORDER BY CODE ")
        'strSQL.Append("ORDER BY CODE2, CODE ")

        strSQL.Append("SELECT ")
        strSQL.Append("HAN_CD AS CODE, ")
        strSQL.Append("JAS_NAME AS NAME, ")
        strSQL.Append("HAN_CD || ' : ' || JAS_NAME AS CDNM, ")
        strSQL.Append("CLI_CD AS CODE2, ")
        strSQL.Append("' ' AS CDNM2 ")
        strSQL.Append("FROM HN2MAS ")
        strSQL.Append("WHERE CLI_CD = :CLI_CD ")
        strSQL.Append("AND NVL(DEL_FLG,'0') <> '1' ")
        If COPOPUPG00_C.pCode2.Length > 0 Then
            strSQL.Append("  AND JA_CD = :JA_CD ")
        End If
        If COPOPUPG00_C.pCode3.Length > 0 Then
            strSQL.Append("  AND EXISTS (SELECT * FROM M09_JAGROUP JG WHERE GROUPCD = :HAN_GRP AND HN2MAS.HAN_CD = JG.ACBCD) ")
        End If
        If COPOPUPG00_C.pCode4.Length > 0 Then
            strSQL.Append("  AND EXISTS (SELECT * FROM M09_JAGROUP JG WHERE GROUPCD = :JAHOKOKU_GRP AND HN2MAS.HAN_CD = JG.ACBCD) ")
        End If
        strSQL.Append("UNION ALL ")
        strSQL.Append("SELECT ")
        strSQL.Append("' ' AS CODE, ")
        strSQL.Append("' ' AS NAME, ")
        strSQL.Append("' ' AS CDNM, ")
        strSQL.Append("' ' AS CODE2, ")
        strSQL.Append("' ' AS CDNM2 ")
        strSQL.Append("FROM ")
        strSQL.Append("DUAL ")
        strSQL.Append("ORDER BY CODE2, CODE ")
        '2020/02/21 T.Ono mod Oracle Alert�΍� END


        SqlParamC.fncSetParam("CLI_CD", True, COPOPUPG00_C.pCode1)
        If COPOPUPG00_C.pCode2.Length > 0 Then
            SqlParamC.fncSetParam("JA_CD", True, COPOPUPG00_C.pCode2)
        End If

        '2014/12/04 H.Hosoda add 2014���P�J�� No6 START
        If COPOPUPG00_C.pCode3.Length > 0 Then
            SqlParamC.fncSetParam("HAN_GRP", True, COPOPUPG00_C.pCode3)
        End If
        '2014/12/04 H.Hosoda add 2014���P�J�� No6 END
        '2016/11/21 H.Mori add 2016���P�J�� No2-1 START
        If COPOPUPG00_C.pCode4.Length > 0 Then
            SqlParamC.fncSetParam("JAHOKOKU_GRP", True, COPOPUPG00_C.pCode4)
        End If
        '2016/11/21 H.Mori add 2016���P�J�� No2-1 END
        '2019/11/01 T.Ono add �Ď����P2019 No1
        If COPOPUPG00_C.pCode5.Length > 0 Then
            SqlParamC.fncSetParam("CLI_CD_TO", True, COPOPUPG00_C.pCode5)
        End If

    End Sub

    '******************************************************************************
    ' �i�`�x���ꗗ�i�i�`�����o�͂���j
    '******************************************************************************
    Private Sub mMakeSQL_JASS2(ByVal strSQL As StringBuilder, ByVal SqlParamC As CSQLParam)
        strSQL.Append("SELECT ")
        strSQL.Append("' ' AS CODE, ")
        strSQL.Append("' ' AS NAME, ")
        strSQL.Append("' ' AS CDNM, ")
        strSQL.Append("' ' AS CODE2, ")
        strSQL.Append("' ' AS CDNM2 ")
        strSQL.Append("FROM ")
        strSQL.Append("DUAL ")
        strSQL.Append("UNION ALL ")
        strSQL.Append("SELECT ")
        strSQL.Append("HAN_CD AS CODE, ")
        '--- ��2005/05/21 ADD Falcon�� ---
        strSQL.Append("JA_NAME || JAS_NAME AS NAME, ")
        strSQL.Append("HAN_CD || ' : ' || JA_NAME || JAS_NAME AS CDNM, ")
        strSQL.Append("' ' AS CODE2, ")
        strSQL.Append("' ' AS CDNM2 ")
        '--- ��2005/05/21 ADD Falcon�� ---
        strSQL.Append("FROM HN2MAS ")
        strSQL.Append("WHERE CLI_CD = :CLI_CD ")
        strSQL.Append("AND NVL(DEL_FLG,'0') <> '1' ") ' 2008/10/29 T.Watabe add
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
    ' �i�`�x���ꗗ�iJA�R�[�h�͈ꗗ�ɕ\�����Ȃ�)�j�@2014/10/02 T.Ono mod 2014���P�J�� No19
    '******************************************************************************
    Private Sub mMakeSQL_JASS3(ByVal strSQL As StringBuilder, ByVal SqlParamC As CSQLParam)
        strSQL.Append("SELECT ")
        strSQL.Append("' ' AS CODE, ")
        strSQL.Append("' ' AS NAME, ")
        strSQL.Append("' ' AS CDNM, ")
        strSQL.Append("' ' AS CODE2, ")
        strSQL.Append("' ' AS CDNM2 ")
        strSQL.Append("FROM ")
        strSQL.Append("DUAL ")
        strSQL.Append("UNION ALL ")
        strSQL.Append("SELECT ")
        strSQL.Append("A.HAN_CD AS CODE, ")
        strSQL.Append("A.JAS_NAME AS NAME, ")
        strSQL.Append("A.HAN_CD || ' : ' || A.JAS_NAME AS CDNM, ")
        strSQL.Append("' ' AS CODE2, ")
        strSQL.Append("' ' AS CDNM2 ")
        strSQL.Append("FROM ")
        strSQL.Append("HN2MAS A ")
        strSQL.Append("WHERE ")
        strSQL.Append("A.CLI_CD = :CLI_CD ")
        strSQL.Append("AND	NVL(A.DEL_FLG,'0') <> '1' ")
        If COPOPUPG00_C.pCode2.Length > 0 Then
            strSQL.Append("AND  A.JA_CD = :JA_CD ")
        End If
        strSQL.Append("AND	NOT EXISTS( ")
        strSQL.Append("	SELECT	'X' ")
        strSQL.Append("	FROM	HN2MAS B ")
        strSQL.Append("	WHERE	A.CLI_CD = B.CLI_CD ")
        strSQL.Append("	AND	A.HAN_CD = B.JA_CD ")
        strSQL.Append("	) ")
        strSQL.Append("ORDER BY CODE ")

        '�N���C�A���g�R�[�h
        SqlParamC.fncSetParam("CLI_CD", True, COPOPUPG00_C.pCode1)
        'JA�R�[�h
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
        strSQL.Append("' ' AS CDNM, ")
        strSQL.Append("' ' AS CODE2, ")
        strSQL.Append("' ' AS CDNM2 ")
        strSQL.Append("FROM ")
        strSQL.Append("DUAL ")
        strSQL.Append("UNION ALL ")
        strSQL.Append("SELECT ")
        strSQL.Append("HAISO_CD AS CODE, ")
        strSQL.Append("NAME AS NAME, ")
        strSQL.Append("HAISO_CD || ' : ' || NAME AS CDNM, ")
        strSQL.Append("' ' AS CODE2, ")
        strSQL.Append("' ' AS CDNM2 ")
        strSQL.Append("FROM HAIMAS ")
        strSQL.Append("WHERE KEN_CD = :KEN_CD ")

        strSQL.Append("ORDER BY CODE ")

        SqlParamC.fncSetParam("KEN_CD", True, COPOPUPG00_C.pCode1)
    End Sub

    '******************************************************************************
    ' �Ď��Z���^�[�ꗗ
    '******************************************************************************
    Private Sub mMakeSQL_KANSHI(ByVal strSQL As StringBuilder, ByVal SqlParamC As CSQLParam)
        '�֘A����Ď��Z���^�[�̃R�[�h�̂ݏo�͂��邱��
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
        strSQL.Append("' ' AS CDNM, ")
        strSQL.Append("' ' AS CODE2, ")
        strSQL.Append("' ' AS CDNM2 ")
        strSQL.Append("FROM ")
        strSQL.Append("DUAL ")
        strSQL.Append("UNION ALL ")
        strSQL.Append("SELECT ")
        strSQL.Append("KANSI_CD AS CODE, ")
        strSQL.Append("KANSI_NAME AS NAME, ")
        strSQL.Append("KANSI_CD || ' : ' || KANSI_NAME AS CDNM, ")
        strSQL.Append("' ' AS CODE2, ")
        strSQL.Append("' ' AS CDNM2 ")
        strSQL.Append("FROM KANSIMAS ")
        '--- ��2005/04/29 DEL Falcon�� ---
        'If arrTemp.Length = 0 Then
        '    strSQL.Append("WHERE KANSI_CD = '' ")
        'Else
        '    strSQL.Append("WHERE KANSI_CD IN (" & strCenter & ") ")
        'End If
        '--- ��2005/04/29 DEL Falcon�� ---
        '--- ��2005/04/29 MOD Falcon�� ---
        If COPOPUPG00_C.pCode1.Length > 0 Then
            strSQL.Append("  WHERE KANSI_CD IN (" & strCenter & ") ")
        End If
        '--- ��2005/04/29 MOD Falcon�� ---
        strSQL.Append("ORDER BY CODE ")

    End Sub

    '******************************************************************************
    ' �o����Јꗗ
    '******************************************************************************
    Private Sub mMakeSQL_SYUTUDOU(ByVal strSQL As StringBuilder, ByVal SqlParamC As CSQLParam)
        '--- ��2005/04/29 ADD Falcon�� ---
        '�֘A����Ď��Z���^�[�̏o����ЃR�[�h�̂ݏo�͂��邱��
        '�`�c�F�؂��ꂽ�u�g�p�\�Ď��Z���^�[�v�ɏ�������o����Ђ��o��
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
        '--- ��2005/04/29 ADD Falcon�� ---
        strSQL.Append("SELECT ")
        strSQL.Append("' ' AS CODE, ")
        strSQL.Append("' ' AS NAME, ")
        strSQL.Append("' ' AS CDNM, ")
        strSQL.Append("' ' AS CODE2, ")
        strSQL.Append("' ' AS CDNM2 ")
        strSQL.Append("FROM ")
        strSQL.Append("DUAL ")
        strSQL.Append("UNION ALL ")
        strSQL.Append("SELECT ")
        '--- ��2005/05/21 MOD Falcon�� ---
        '�o����Ё{���_�ɃR�[�h�Ɩ��̂��C��
        'strSQL.Append("SHUTU_CD AS CODE, ")
        'strSQL.Append("KAISYA_NAME AS NAME, ")
        'strSQL.Append("SHUTU_CD || ' : ' || KAISYA_NAME AS CDNM ")
        strSQL.Append("SHUTU_CD || KYOTEN_CD AS CODE, ")
        strSQL.Append("KAISYA_NAME || KYOTEN_NAME AS NAME, ")
        strSQL.Append("SHUTU_CD || KYOTEN_CD || ' : ' || KAISYA_NAME || KYOTEN_NAME AS CDNM, ")
        strSQL.Append("' ' AS CODE2, ")
        strSQL.Append("' ' AS CDNM2 ")
        '--- ��2005/05/21 MOD Falcon�� ---
        strSQL.Append("FROM SHUTUDOMAS ")
        strSQL.Append("WHERE KUBUN = :KUBUN ")
        '--- ��2005/04/29 ADD Falcon�� ---
        If COPOPUPG00_C.pCode1.Length > 0 Then
            strSQL.Append("  AND KANSI_CD IN (" & strCenter & ") ")
        End If
        '--- ��2005/04/29 ADD Falcon�� ---
        '--- ��2005/05/21 ADD Falcon�� ---
        strSQL.Append("ORDER BY CODE")
        '--- ��2005/05/21 ADD Falcon�� ---
        SqlParamC.fncSetParam("KUBUN", True, "1")
    End Sub

    '******************************************************************************
    ' �v���_�E���敪���ꗗ
    '******************************************************************************
    Private Sub mMakeSQL_PULLKBN(ByVal strSQL As StringBuilder, ByVal SqlParamC As CSQLParam)
        strSQL.Append("SELECT ")
        strSQL.Append("' ' AS CODE, ")
        strSQL.Append("' ' AS NAME, ")
        strSQL.Append("' ' AS CDNM, ")
        strSQL.Append("' ' AS CODE2, ")
        strSQL.Append("' ' AS CDNM2 ")
        strSQL.Append("FROM ")
        strSQL.Append("DUAL ")
        strSQL.Append("UNION ALL ")
        strSQL.Append("SELECT ")
        strSQL.Append("CD AS CODE, ")
        strSQL.Append("NAME AS NAME, ")
        strSQL.Append("NAME AS CDNM, ")          '�v���_�E���}�X�^�ɂĎg�p����B�R���{�n�ł͂Ȃ����͕⏕�|�b�v�n
        strSQL.Append("' ' AS CODE2, ")
        strSQL.Append("' ' AS CDNM2 ")
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
        '--- ��2005/04/23 MOD�@Falcon�� -----------------
        'strSQL.Append("' ' AS JUNJO ")
        strSQL.Append("0 AS JUNJO, ")
        strSQL.Append("' ' AS CODE2, ")
        strSQL.Append("' ' AS CDNM2 ")
        '--- ��2005/04/23 MOD�@Falcon�� -----------------
        strSQL.Append("FROM ")
        strSQL.Append("DUAL ")
        strSQL.Append("UNION ALL ")
        strSQL.Append("SELECT ")
        strSQL.Append("CD AS CODE, ")
        strSQL.Append("NAME AS NAME, ")
        strSQL.Append("NAME AS CDNM, ")          '�v���_�E���}�X�^�ɂĎg�p����B�R���{�n�ł͂Ȃ����͕⏕�|�b�v�n
        '--- ��2005/04/23 MOD�@Falcon�� -----------------
        'strSQL.Append("TO_CHAR(DISP_NO) AS JUNJO ")
        strSQL.Append("TO_NUMBER(NVL(DISP_NO,9999)) AS JUNJO, ")
        strSQL.Append("' ' AS CODE2, ")
        strSQL.Append("' ' AS CDNM2 ")
        '--- ��2005/04/23 MOD�@Falcon�� -----------------
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
        '--- ��2005/04/23 DEL�@Falcon�� -----------------
        'strSQL.Append("ORDER BY JUNJO ")
        '--- ��2005/04/23 DEL�@Falcon�� -----------------
        '--- ��2005/04/23 MOD�@Falcon�� -----------------
        strSQL.Append("ORDER BY JUNJO,CODE ")
        '--- ��2005/04/23 MOD�@Falcon�� -----------------

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
        '--- ��2005/04/23 ADD�@Falcon�� -----------------
        strSQL.Append("0 AS DISP_NO, ")
        '--- ��2005/04/23 ADD�@Falcon�� -----------------
        strSQL.Append("' ' AS CDNM, ")
        strSQL.Append("' ' AS CODE2, ")
        strSQL.Append("' ' AS CDNM2 ")
        strSQL.Append("FROM ")
        strSQL.Append("DUAL ")
        strSQL.Append("UNION ALL ")
        strSQL.Append("SELECT ")
        strSQL.Append("TN.TANCD AS CODE, ")
        strSQL.Append("TN.TANNM AS NAME, ")
        '--- ��2005/04/23 ADD�@Falcon�� -----------------
        strSQL.Append("TO_NUMBER(NVL(TN.DISP_NO,9999)) AS DISP_NO, ")
        '--- ��2005/04/23 ADD�@Falcon�� -----------------
        strSQL.Append("TN.TANCD || ' : ' || TN.TANNM  AS CDNM, ")
        strSQL.Append("' ' AS CODE2, ")
        strSQL.Append("' ' AS CDNM2 ")
        strSQL.Append("FROM CLIMAS CL, ")
        strSQL.Append("     M05_TANTO TN ")
        strSQL.Append("WHERE CL.CLI_CD = :CLI_CD ")
        strSQL.Append("  AND TN.KBN = '1' ")
        strSQL.Append("  AND TN.KURACD = 'ZZZZ' ")
        strSQL.Append("  AND TN.CODE = CL.KANSI_CODE ")
        '�Ď��Z���^�[�R�[�h�����w��̏ꍇ�͋�ƂȂ�
        '--- ��2005/04/23 DEL�@Falcon�� -----------------
        'strSQL.Append("ORDER BY CODE ")
        '--- ��2005/04/23 DEL�@Falcon�� -----------------
        '--- ��2005/04/23 MOD�@Falcon�� -----------------
        strSQL.Append("ORDER BY DISP_NO,CODE ")
        '--- ��2005/04/23 MOD�@Falcon�� -----------------

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
        '--- ��2005/04/23 ADD�@Falcon�� -----------------
        strSQL.Append("0 AS DISP_NO, ")
        '--- ��2005/04/23 ADD�@Falcon�� -----------------
        strSQL.Append("' ' AS CDNM, ")
        strSQL.Append("' ' AS CODE2, ")
        strSQL.Append("' ' AS CDNM2 ")
        strSQL.Append("FROM ")
        strSQL.Append("DUAL ")
        strSQL.Append("UNION ALL ")
        strSQL.Append("SELECT ")
        strSQL.Append("TN.TANCD AS CODE, ")
        strSQL.Append("TN.TANNM AS NAME, ")
        '--- ��2005/04/23 ADD�@Falcon�� -----------------
        strSQL.Append("TO_NUMBER(NVL(TN.DISP_NO,9999)) AS DISP_NO, ")
        '--- ��2005/04/23 ADD�@Falcon�� -----------------
        strSQL.Append("TN.TANCD || ' : ' || TN.TANNM  AS CDNM, ")
        strSQL.Append("' ' AS CODE2, ")
        strSQL.Append("' ' AS CDNM2 ")
        strSQL.Append("FROM M05_TANTO TN ")
        strSQL.Append("WHERE TN.KBN = '1' ")
        strSQL.Append("  AND TN.KURACD = 'ZZZZ' ")
        '�Ď��Z���^�[�R�[�h�����w��̏ꍇ�͋�ƂȂ�
        If strCenter.Length = 0 Then
            strSQL.Append("  AND TN.CODE = '' ")
        Else
            strSQL.Append("  AND TN.CODE IN (" & strCenter & ") ")
        End If
        '--- ��2005/04/23 DEL�@Falcon�� -----------------
        'strSQL.Append("ORDER BY CODE ")
        '--- ��2005/04/23 DEL�@Falcon�� -----------------
        '--- ��2005/04/23 MOD�@Falcon�� -----------------
        strSQL.Append("ORDER BY DISP_NO,CODE ")
        '--- ��2005/04/23 MOD�@Falcon�� -----------------
    End Sub

    '******************************************************************************
    ' �Ď��Z���^�[�S���҈ꗗ�i�Ď��Z���^�[�R�[�h���o�́j�S���҃R�[�h�� 2014/02/07 T.Ono add �Ď����P2013
    '******************************************************************************
    Private Sub mMakeSQL_TKTANCDKN_ORDCD(ByVal strSQL As StringBuilder, ByVal SqlParamC As CSQLParam)
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
        strSQL.Append("0 AS DISP_NO, ")
        strSQL.Append("' ' AS CDNM, ")
        strSQL.Append("' ' AS CODE2, ")
        strSQL.Append("' ' AS CDNM2, ")
        strSQL.Append("0 AS ORDCD ")
        strSQL.Append("FROM ")
        strSQL.Append("DUAL ")
        strSQL.Append("UNION ALL ")
        strSQL.Append("SELECT ")
        strSQL.Append("TN.TANCD AS CODE, ")
        strSQL.Append("TN.TANNM AS NAME, ")
        strSQL.Append("TO_NUMBER(NVL(TN.DISP_NO,9999)) AS DISP_NO, ")
        strSQL.Append("TN.TANCD || ' : ' || TN.TANNM  AS CDNM, ")
        strSQL.Append("' ' AS CODE2, ")
        strSQL.Append("' ' AS CDNM2, ")
        strSQL.Append("TO_NUMBER(TN.TANCD) AS ORDCD ")
        strSQL.Append("FROM M05_TANTO TN ")
        strSQL.Append("WHERE TN.KBN = '1' ")
        strSQL.Append("  AND TN.KURACD = 'ZZZZ' ")
        '�Ď��Z���^�[�R�[�h�����w��̏ꍇ�͋�ƂȂ�
        If strCenter.Length = 0 Then
            strSQL.Append("  AND TN.CODE = '' ")
        Else
            strSQL.Append("  AND TN.CODE IN (" & strCenter & ") ")
        End If

        strSQL.Append("ORDER BY ORDCD ")

    End Sub
    '******************************************************************************
    ' ���R�[�h�ꗗ
    '******************************************************************************
    Private Sub mMakeSQL_KENCD(ByVal strSQL As StringBuilder, ByVal SqlParamC As CSQLParam)
        strSQL.Append("SELECT ")
        strSQL.Append("' ' AS CODE, ")
        strSQL.Append("' ' AS NAME, ")
        strSQL.Append("' ' AS CDNM, ")
        strSQL.Append("' ' AS CODE2, ")
        strSQL.Append("' ' AS CDNM2 ")
        strSQL.Append("FROM ")
        strSQL.Append("DUAL ")
        strSQL.Append("UNION ALL ")
        strSQL.Append("SELECT DISTINCT ")
        strSQL.Append("KEN_CODE AS CODE, ")
        strSQL.Append("KEN_NAME AS NAME, ")
        strSQL.Append("KEN_CODE || ' : ' || KEN_NAME AS CDNM, ")
        strSQL.Append("' ' AS CODE2, ")
        strSQL.Append("' ' AS CDNM2 ")
        strSQL.Append("FROM CLIMAS ")
        strSQL.Append("WHERE KANSI_CODE IS NOT NULL ")
        strSQL.Append("ORDER BY CODE ")

    End Sub

    '******************************************************************************
    ' �̔����Ǝ҃O���[�v�R�[�h�ꗗ 2014/12/04 H.Hosoda add 2014���P�J�� No6
    '******************************************************************************
    Private Sub mMakeSQL_HANG(ByVal strSQL As StringBuilder, ByVal SqlParamC As CSQLParam)

        strSQL.Append("SELECT ")
        strSQL.Append("' ' AS CODE, ")
        strSQL.Append("' ' AS NAME, ")
        strSQL.Append("' ' AS CDNM, ")
        strSQL.Append("' ' AS CODE2, ")
        strSQL.Append("' ' AS CDNM2 ")
        strSQL.Append("FROM ")
        strSQL.Append("DUAL ")
        strSQL.Append("UNION ALL ")
        '�g�p�i�R�t�����ꂽ�j�O���[�v
        strSQL.Append("SELECT  ")
        strSQL.Append("A.GROUPCD AS CODE, ")
        strSQL.Append("A.GROUPNM AS NAME, ")
        strSQL.Append("A.GROUPCD || ' : ' || A.GROUPNM AS CDNM, ")
        strSQL.Append("A.GROUPCD AS CODE2, ")
        strSQL.Append("A.HANJIGYOSYANM  AS CDNM2 ")
        strSQL.Append("FROM  ")
        strSQL.Append("M10_HANJIGYOSYA A, ")
        strSQL.Append("M09_JAGROUP B, ")
        strSQL.Append("CLIMAS C ")
        strSQL.Append("WHERE 1=1 ")
        strSQL.Append("AND B.KBN = '001' ") '2016/02/25 T.Ono add ��̫��ݽ���P
        '2019/11/01 T.Ono mod �Ď����P2019 No1
        'strSQL.Append("AND B.KURACD = C.CLI_CD ")
        If COPOPUPG00_C.pCode2.Length > 0 Then
            strSQL.Append("AND B.KURACD >= :CLI_CD ")
            strSQL.Append("AND B.KURACD <= :CLI_CD_TO ")
            strSQL.Append("AND C.CLI_CD >= :CLI_CD ")
            strSQL.Append("AND C.CLI_CD <= :CLI_CD_TO ")
        Else
            strSQL.Append("AND B.KURACD = :CLI_CD ")
            strSQL.Append("AND C.CLI_CD = :CLI_CD ")
        End If
        strSQL.Append("AND A.GROUPCD = B.GROUPCD ")
        'strSQL.Append("AND C.CLI_CD = :CLI_CD ") '2019/11/01 T.Ono mod �Ď����P2019 No1
        strSQL.Append("GROUP BY A.GROUPCD, A.GROUPNM, A.HANJIGYOSYANM ")
        strSQL.Append("ORDER BY 1 ")

        '�N���C�A���g�R�[�h
        SqlParamC.fncSetParam("CLI_CD", True, COPOPUPG00_C.pCode1)

        '2019/11/01 T.Ono add �Ď����P2019 No1
        If COPOPUPG00_C.pCode2.Trim.Length > 0 Then
            SqlParamC.fncSetParam("CLI_CD_TO", True, COPOPUPG00_C.pCode2)
        End If

    End Sub

    '******************************************************************************
    ' �̔����Ǝ҃O���[�v�R�[�h�ꗗ(���g�p�O���[�v�܂�)�@2014/10/08 T.Ono add 2014���P�J�� No19
    '******************************************************************************
    Private Sub mMakeSQL_HANG2(ByVal strSQL As StringBuilder, ByVal SqlParamC As CSQLParam)
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
        strSQL.Append("' ' AS CDNM, ")
        strSQL.Append("' ' AS CODE2, ")
        strSQL.Append("' ' AS CDNM2 ")
        strSQL.Append("FROM ")
        strSQL.Append("DUAL ")
        strSQL.Append("UNION ALL ")
        '�g�p�i�R�t�����ꂽ�j�O���[�v
        strSQL.Append("SELECT  ")
        strSQL.Append("A.GROUPCD AS CODE, ")
        strSQL.Append("A.GROUPNM AS NAME, ")
        strSQL.Append("A.GROUPCD || ' : ' || A.GROUPNM AS CDNM, ")
        strSQL.Append("A.GROUPCD AS CODE2, ")
        strSQL.Append("A.HANJIGYOSYANM AS CDNM2 ")
        strSQL.Append("FROM  ")
        strSQL.Append("M10_HANJIGYOSYA A, ")
        strSQL.Append("M09_JAGROUP B, ")
        strSQL.Append("CLIMAS C ")
        strSQL.Append("WHERE 1=1 ")
        '�Ď��Z���^�[�R�[�h�B���w��̏ꍇ�͋�ƂȂ�
        If strCenter.Length = 0 Then
            strSQL.Append("AND C.KANSI_CODE = '' ")
        Else
            strSQL.Append("AND C.KANSI_CODE IN (" & strCenter & ") ")
        End If
        strSQL.Append("AND B.KBN = '001' ") '2016/02/25 T.Ono add ��̫��ݽ���P
        strSQL.Append("AND B.KURACD = C.CLI_CD ")
        strSQL.Append("AND A.GROUPCD = B.GROUPCD ")
        '�N���C�A���g�R�[�h�B
        If COPOPUPG00_C.pCode2.Length > 0 Then
            strSQL.Append("AND C.CLI_CD = :CLI_CD ")
        End If
        strSQL.Append("GROUP BY A.GROUPCD, A.GROUPNM, A.HANJIGYOSYANM ")
        strSQL.Append("UNION ALL ")
        '���g�p�i�R�t������Ă��Ȃ��j�O���[�v
        strSQL.Append("SELECT ")
        strSQL.Append("D.GROUPCD AS CODE, ")
        strSQL.Append("D.GROUPNM AS NAME, ")
        strSQL.Append("D.GROUPCD || ' : ' || D.GROUPNM AS CDNM, ")
        strSQL.Append("D.GROUPCD AS CODE2, ")
        strSQL.Append("D.HANJIGYOSYANM AS CDNM2 ")
        strSQL.Append("FROM ")
        strSQL.Append("M10_HANJIGYOSYA D ")
        strSQL.Append("WHERE NOT EXISTS( ")
        strSQL.Append("	SELECT 'X' ")
        strSQL.Append("	FROM M09_JAGROUP E ")
        strSQL.Append("	WHERE 1=1 ")
        strSQL.Append("	AND D.GROUPCD = E.GROUPCD ")
        strSQL.Append(" AND E.KBN = '001' ") '2016/02/25 T.Ono add ��̫��ݽ���P
        strSQL.Append("	) ")
        strSQL.Append("GROUP BY D.GROUPCD, D.GROUPNM, D.HANJIGYOSYANM ")
        strSQL.Append("ORDER BY 1 ")

        '�N���C�A���g�R�[�h
        If COPOPUPG00_C.pCode2.Length > 0 Then
            SqlParamC.fncSetParam("CLI_CD", True, COPOPUPG00_C.pCode2)
        End If
    End Sub

    '******************************************************************************
    ' 2015���P�J���@�g�p��~
    ' �o�^�ς݈ꗗ(JA�S���ҁE�񍐐�}�X�^)�@2015/02/18 T.Ono add 2014���P�J�� No15
    '******************************************************************************
    Private Sub mMakeSQL_JATANMAS(ByVal strSQL As StringBuilder, ByVal SqlParamC As CSQLParam)

        strSQL.Append("SELECT ")
        strSQL.Append("    ' ' AS CODE, ")
        strSQL.Append("    ' ' AS NAME, ")
        strSQL.Append("    '' AS CDNM, ")
        strSQL.Append("    ' ' AS CODE2, ")
        strSQL.Append("    '' AS CDNM2, ")
        strSQL.Append("    '0' AS DISP_NO, ")
        strSQL.Append("    ' ' AS JASCD ")
        strSQL.Append("FROM ")
        strSQL.Append("DUAL ")
        strSQL.Append("UNION ALL ")
        strSQL.Append("SELECT ")
        strSQL.Append("    T.CODE || ':' || DECODE(T.USER_CD_TO, NULL, T.USER_CD_FROM, T.USER_CD_FROM || '�`' || T.USER_CD_TO) AS CODE, ")
        strSQL.Append("    H.JAS_NAME AS NAME, ")
        strSQL.Append("    T.CODE || ' : ' || H.JAS_NAME AS CDNM, ")
        strSQL.Append("    T.CODE AS CODE2, ")
        strSQL.Append("    DECODE(T.USER_CD_TO, NULL, T.USER_CD_FROM, T.USER_CD_FROM || ',' || T.USER_CD_TO) AS CDNM2, ")
        strSQL.Append("    DECODE(T.USER_CD_TO, NULL, '3', '2') AS DISP_NO, ")
        strSQL.Append("    T.CODE AS JASCD ")
        strSQL.Append("FROM M05_TANTO2 T, ")
        strSQL.Append("     HN2MAS H ")
        strSQL.Append("WHERE 1=1 ")
        strSQL.Append("AND   T.KBN = '3' ")
        strSQL.Append("AND   T.KURACD = :KURACD ")
        If COPOPUPG00_C.pCode2.Length > 0 Then
            'strSQL.Append("AND   T.CODE = :CODE ") '2015/03/17 T.Ono mod JA3���Ŕz���̎x�����o��
            strSQL.Append("AND   T.CODE LIKE :CODE || '%' ")
        End If
        strSQL.Append("AND   T.KURACD = H.CLI_CD ")
        strSQL.Append("AND   T.CODE = H.HAN_CD ")
        strSQL.Append("GROUP BY T.CODE, T.USER_CD_FROM, T.USER_CD_TO, H.JAS_NAME ")
        strSQL.Append("UNION ALL ")
        strSQL.Append("SELECT ")
        strSQL.Append("    T.CODE AS CODE, ")
        strSQL.Append("    H.JAS_NAME AS NAME, ")
        strSQL.Append("    T.CODE || ' : ' || H.JAS_NAME AS CDNM, ")
        strSQL.Append("    T.CODE AS CODE2, ")
        strSQL.Append("    '' AS CDNM2, ")
        strSQL.Append("    '1' AS DISP_NO, ")
        strSQL.Append("    T.CODE AS JASCD ")
        strSQL.Append("FROM M05_TANTO T, ")
        strSQL.Append("     HN2MAS H ")
        strSQL.Append("WHERE 1=1 ")
        strSQL.Append("AND   T.KBN = '3' ")
        strSQL.Append("AND   T.KURACD = :KURACD ")
        If COPOPUPG00_C.pCode2.Length > 0 Then
            'strSQL.Append("AND   T.CODE = :CODE ") '2015/03/17 T.Ono mod JA3���Ŕz���̎x�����o��
            strSQL.Append("AND   T.CODE LIKE :CODE || '%'  ")
        End If
        strSQL.Append("AND   T.CODE <> 'XXXX' ")
        strSQL.Append("AND   T.KURACD = H.CLI_CD ")
        strSQL.Append("AND   T.CODE = H.HAN_CD ")
        strSQL.Append("GROUP BY T.CODE, H.JAS_NAME ")
        strSQL.Append("ORDER BY JASCD, DISP_NO, CDNM ")

        '�N���C�A���g�R�[�h�i�K�{�j
        If COPOPUPG00_C.pCode1.Length > 0 Then
            SqlParamC.fncSetParam("KURACD", True, COPOPUPG00_C.pCode1)
        End If
        'JA�x���R�[�h
        If COPOPUPG00_C.pCode2.Length > 0 Then
            SqlParamC.fncSetParam("CODE", True, COPOPUPG00_C.pCode2)
        End If
    End Sub
    '******************************************************************************
    ' �O���[�v�R�[�h�ꗗ(JA�S���ҁE�񍐐�E���ӎ����}�X�^)�i���g�p�܂ށj�@2015/11/18 T.Ono add 2015���P�J�� No7
    '******************************************************************************
    Private Sub mMakeSQL_JAHOKOKU(ByVal strSQL As StringBuilder, ByVal SqlParamC As CSQLParam)

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
        strSQL.Append("' ' AS CDNM, ")
        strSQL.Append("' ' AS CODE2, ")
        strSQL.Append("' ' AS CDNM2 ")
        strSQL.Append("FROM ")
        strSQL.Append("DUAL ")
        strSQL.Append("UNION ALL ")
        '�g�p�i�R�t�����ꂽ�j�O���[�v
        strSQL.Append("SELECT  ")
        strSQL.Append("A.GROUPCD AS CODE, ")
        strSQL.Append("A.GROUPNM AS NAME, ")
        strSQL.Append("A.GROUPCD || ' : ' || A.GROUPNM AS CDNM, ")
        'strSQL.Append("'' AS CODE2, ") '2019/11/01 T.Ono mod �Ď����P2019
        strSQL.Append("C.CLI_CD AS CODE2, ")
        strSQL.Append("'' AS CDNM2 ")
        strSQL.Append("FROM  ")
        strSQL.Append("M11_JAHOKOKU A, ")
        strSQL.Append("M09_JAGROUP B, ")
        strSQL.Append("CLIMAS C ")
        strSQL.Append("WHERE 1=1 ")
        '�Ď��Z���^�[�R�[�h�B���w��̏ꍇ�͋�ƂȂ�
        If strCenter.Length = 0 Then
            strSQL.Append("AND C.KANSI_CODE = '' ")
        Else
            strSQL.Append("AND C.KANSI_CODE IN (" & strCenter & ") ")
        End If
        strSQL.Append("AND B.KURACD = C.CLI_CD ")
        strSQL.Append("AND A.GROUPCD = B.GROUPCD ")
        strSQL.Append("AND A.KBN = '2' ")
        strSQL.Append("AND LPAD(A.TANCD, 2, '0') = '01' ")
        '�N���C�A���g�R�[�h�B
        '2019/11/01 T.Ono mod �Ď����P2019 START
        'If COPOPUPG00_C.pCode2.Length > 0 Then
        '    strSQL.Append("AND C.CLI_CD = :CLI_CD ")
        'End If
        If COPOPUPG00_C.pCode4.Length > 0 Then
            strSQL.Append("AND C.CLI_CD >= :CLI_CD ")
            strSQL.Append("AND C.CLI_CD <= :CLI_CD_TO ")
        ElseIf COPOPUPG00_C.pCode2.Length > 0 Then
            strSQL.Append("AND C.CLI_CD = :CLI_CD ")
        End If
        '2019/11/01 T.Ono mod �Ď����P2019 END
        'JA�x���R�[�h�B
        If COPOPUPG00_C.pCode3.Length > 0 Then
            strSQL.Append("AND B.ACBCD = :ACBCD ")
        End If
        'strSQL.Append("GROUP BY A.GROUPCD, A.GROUPNM ") '2019/11/01 T.Ono mod �Ď����P2019
        strSQL.Append("GROUP BY C.CLI_CD, A.GROUPCD, A.GROUPNM ")
        strSQL.Append("UNION ALL ")
        '���g�p�i�R�t������Ă��Ȃ��j�O���[�v
        strSQL.Append("SELECT ")
        strSQL.Append("D.GROUPCD AS CODE, ")
        strSQL.Append("D.GROUPNM AS NAME, ")
        strSQL.Append("D.GROUPCD || ' : ' || D.GROUPNM AS CDNM, ")
        strSQL.Append("'' AS CODE2, ")
        strSQL.Append("'' AS CDNM2 ")
        strSQL.Append("FROM ")
        strSQL.Append("M11_JAHOKOKU D ")
        strSQL.Append("WHERE NOT EXISTS( ")
        strSQL.Append("	SELECT 'X' ")
        strSQL.Append("	FROM M09_JAGROUP E ")
        strSQL.Append("	WHERE 1=1 ")
        strSQL.Append("	AND D.GROUPCD = E.GROUPCD ")
        strSQL.Append("	) ")
        strSQL.Append("AND D.KBN = '2' ")
        strSQL.Append("AND LPAD(D.TANCD, 2, '0') = '01' ")
        'strSQL.Append("GROUP BY GROUPCD, GROUPNM ")
        strSQL.Append("ORDER BY 1 ")

        '�N���C�A���g�R�[�h
        If COPOPUPG00_C.pCode2.Length > 0 Then
            SqlParamC.fncSetParam("CLI_CD", True, COPOPUPG00_C.pCode2)
        End If
        '�N���C�A���g�R�[�hTo
        If COPOPUPG00_C.pCode4.Length > 0 Then
            SqlParamC.fncSetParam("CLI_CD_TO", True, COPOPUPG00_C.pCode4)
        End If
        'JA�x���R�[�h
        If COPOPUPG00_C.pCode3.Length > 0 Then
            SqlParamC.fncSetParam("ACBCD", True, COPOPUPG00_C.pCode3)
        End If
    End Sub

    '******************************************************************************
    ' �O���[�v�R�[�h�ꗗ�i���g�p�O���[�v�܂܂Ȃ��j�@2016/11/17 H.Mori add �Ď����P2016 No2-1
    '******************************************************************************
    Private Sub mMakeSQL_JAHOKOKU2(ByVal strSQL As StringBuilder, ByVal SqlParamC As CSQLParam)

        strSQL.Append("SELECT ")
        strSQL.Append("' ' AS CODE, ")
        strSQL.Append("' ' AS NAME, ")
        strSQL.Append("' ' AS CDNM, ")
        strSQL.Append("' ' AS CODE2, ")
        strSQL.Append("' ' AS CDNM2 ")
        strSQL.Append("FROM ")
        strSQL.Append("DUAL ")
        strSQL.Append("UNION ALL ")
        '�g�p�i�R�t�����ꂽ�j�O���[�v
        strSQL.Append("SELECT  ")
        strSQL.Append("A.GROUPCD AS CODE, ")
        strSQL.Append("A.GROUPNM AS NAME, ")
        strSQL.Append("A.GROUPCD || ' : ' || A.GROUPNM AS CDNM, ")
        strSQL.Append("'' AS CODE2, ")
        strSQL.Append("'' AS CDNM2 ")
        strSQL.Append("FROM  ")
        strSQL.Append("M11_JAHOKOKU A, ")
        strSQL.Append("M09_JAGROUP B, ")
        strSQL.Append("CLIMAS C ")
        strSQL.Append("WHERE 1=1 ")
        strSQL.Append("AND B.KURACD = C.CLI_CD ")
        strSQL.Append("AND A.GROUPCD = B.GROUPCD ")
        strSQL.Append("AND A.KBN = '2' ")
        strSQL.Append("AND LPAD(A.TANCD, 2, '0') = '01' ")
        strSQL.Append("AND C.CLI_CD = :CLI_CD ")
        strSQL.Append("GROUP BY A.GROUPCD, A.GROUPNM ")
        strSQL.Append("ORDER BY 1 ")

        '�N���C�A���g�R�[�h
        SqlParamC.fncSetParam("CLI_CD", True, COPOPUPG00_C.pCode1)

    End Sub
    '******************************************************************************
    ' �O���[�v�R�[�h�ꗗ(�����Ή��O���[�v�}�X�^)�i���g�p�܂ށj�@2016/02/09 W.Ganeko add 2016���P�J�� No10
    '******************************************************************************
    Private Sub mMakeSQL_AUTOGROUP(ByVal strSQL As StringBuilder, ByVal SqlParamC As CSQLParam)

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
        strSQL.Append("' ' AS CDNM, ")
        strSQL.Append("' ' AS CODE2, ")
        strSQL.Append("' ' AS CDNM2 ")
        strSQL.Append("FROM ")
        strSQL.Append("DUAL ")
        strSQL.Append("UNION ALL ")
        '�g�p�i�R�t�����ꂽ�j�O���[�v
        strSQL.Append("SELECT  ")
        strSQL.Append("A.GROUPCD AS CODE, ")
        strSQL.Append("A.GROUPNM AS NAME, ")
        strSQL.Append("A.GROUPCD || ' : ' || A.GROUPNM AS CDNM, ")
        strSQL.Append("'' AS CODE2, ")
        strSQL.Append("'' AS CDNM2 ")
        strSQL.Append("FROM ")
        strSQL.Append("(SELECT ")
        strSQL.Append("A.GROUPCD, ")
        strSQL.Append("A.GROUPNM ")
        strSQL.Append("FROM  ")
        strSQL.Append("M08_AUTOTAIOU A, ")
        strSQL.Append("M09_JAGROUP B, ")
        strSQL.Append("CLIMAS C ")
        strSQL.Append("WHERE 1=1 ")
        '�Ď��Z���^�[�R�[�h�B���w��̏ꍇ�͋�ƂȂ�
        If strCenter.Length = 0 Then
            strSQL.Append("AND C.KANSI_CODE = '' ")
        Else
            strSQL.Append("AND C.KANSI_CODE IN (" & strCenter & ") ")
        End If
        strSQL.Append("AND B.KURACD = C.CLI_CD ")
        strSQL.Append("AND A.GROUPCD = B.GROUPCD ")
        '�N���C�A���g�R�[�h�B
        If COPOPUPG00_C.pCode2.Length > 0 Then
            strSQL.Append("AND C.CLI_CD = :CLI_CD ")
        End If
        'JA�x���R�[�h�B
        If COPOPUPG00_C.pCode3.Length > 0 Then
            strSQL.Append("AND B.ACBCD = :ACBCD ")
        End If
        strSQL.Append("GROUP BY A.GROUPCD, A.GROUPNM ")
        strSQL.Append("ORDER BY A.GROUPCD, A.GROUPNM ")
        strSQL.Append(") A ")
        strSQL.Append("UNION ALL ")
        '���g�p�i�R�t������Ă��Ȃ��j�O���[�v
        strSQL.Append("SELECT ")
        strSQL.Append("D.GROUPCD AS CODE, ")
        strSQL.Append("D.GROUPNM AS NAME, ")
        strSQL.Append("D.GROUPCD || ' : ' || D.GROUPNM AS CDNM, ")
        strSQL.Append("'' AS CODE2, ")
        strSQL.Append("'' AS CDNM2 ")
        strSQL.Append("FROM ")
        strSQL.Append("M08_AUTOTAIOU D ")
        strSQL.Append("WHERE NOT EXISTS( ")
        strSQL.Append("	SELECT 'X' ")
        strSQL.Append("	FROM M09_JAGROUP E ")
        strSQL.Append("	WHERE 1=1 ")
        strSQL.Append("	AND D.GROUPCD = E.GROUPCD ")
        strSQL.Append("	) ")
        strSQL.Append("GROUP BY GROUPCD, GROUPNM ")
        strSQL.Append("ORDER BY 1 ")

        '�N���C�A���g�R�[�h
        If COPOPUPG00_C.pCode2.Length > 0 Then
            SqlParamC.fncSetParam("CLI_CD", True, COPOPUPG00_C.pCode2)
        End If
        'JA�x���R�[�h
        If COPOPUPG00_C.pCode3.Length > 0 Then
            SqlParamC.fncSetParam("ACBCD", True, COPOPUPG00_C.pCode3)
        End If
    End Sub

    '******************************************************************************
    ' �̔��X�O���[�v�R�[�h�ꗗ(���g�p�O���[�v�܂�)�@2019/01/10 T.Ono add 2018���P�J��
    '******************************************************************************
    Private Sub mMakeSQL_HANBAITEN(ByVal strSQL As StringBuilder, ByVal SqlParamC As CSQLParam)
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
        strSQL.Append("' ' AS CDNM, ")
        strSQL.Append("' ' AS CODE2, ")
        strSQL.Append("' ' AS CDNM2 ")
        strSQL.Append("FROM ")
        strSQL.Append("DUAL ")
        strSQL.Append("UNION ALL ")
        '�g�p�i�R�t�����ꂽ�j�O���[�v
        strSQL.Append("SELECT  ")
        strSQL.Append("A.GROUPCD AS CODE, ")
        strSQL.Append("A.GROUPNM AS NAME, ")
        strSQL.Append("A.GROUPCD || ' : ' || A.GROUPNM AS CDNM, ")
        strSQL.Append("A.GROUPCD AS CODE2, ")
        strSQL.Append("A.HANBAITENNM AS CDNM2 ")
        strSQL.Append("FROM  ")
        strSQL.Append("M12_HANBAITEN A, ")
        strSQL.Append("M09_JAGROUP B, ")
        strSQL.Append("CLIMAS C ")
        strSQL.Append("WHERE 1=1 ")
        '�Ď��Z���^�[�R�[�h�B���w��̏ꍇ�͋�ƂȂ�
        If strCenter.Length = 0 Then
            strSQL.Append("AND C.KANSI_CODE = '' ")
        Else
            strSQL.Append("AND C.KANSI_CODE IN (" & strCenter & ") ")
        End If
        strSQL.Append("AND B.KBN = '004' ")
        strSQL.Append("AND B.KURACD = C.CLI_CD ")
        strSQL.Append("AND A.GROUPCD = B.GROUPCD ")
        '�N���C�A���g�R�[�h�B
        If COPOPUPG00_C.pCode2.Length > 0 Then
            strSQL.Append("AND C.CLI_CD = :CLI_CD ")
        End If
        strSQL.Append("GROUP BY A.GROUPCD, A.GROUPNM, A.HANBAITENNM ")
        strSQL.Append("UNION ALL ")
        '���g�p�i�R�t������Ă��Ȃ��j�O���[�v
        strSQL.Append("SELECT ")
        strSQL.Append("D.GROUPCD AS CODE, ")
        strSQL.Append("D.GROUPNM AS NAME, ")
        strSQL.Append("D.GROUPCD || ' : ' || D.GROUPNM AS CDNM, ")
        strSQL.Append("D.GROUPCD AS CODE2, ")
        strSQL.Append("D.HANBAITENNM AS CDNM2 ")
        strSQL.Append("FROM ")
        strSQL.Append("M12_HANBAITEN D ")
        strSQL.Append("WHERE NOT EXISTS( ")
        strSQL.Append("	SELECT 'X' ")
        strSQL.Append("	FROM M09_JAGROUP E ")
        strSQL.Append("	WHERE 1=1 ")
        strSQL.Append("	AND D.GROUPCD = E.GROUPCD ")
        strSQL.Append(" AND E.KBN = '004' ")
        strSQL.Append("	) ")
        strSQL.Append("GROUP BY D.GROUPCD, D.GROUPNM, D.HANBAITENNM ")
        strSQL.Append("ORDER BY 1 ")

        '�N���C�A���g�R�[�h
        If COPOPUPG00_C.pCode2.Length > 0 Then
            SqlParamC.fncSetParam("CLI_CD", True, COPOPUPG00_C.pCode2)
        End If
    End Sub

    '******************************************************************************
    ' ���̑�
    '******************************************************************************
    Private Sub mMakeSQL_ELSE(ByVal strSQL As StringBuilder, ByVal SqlParamC As CSQLParam)
        strSQL.Append("SELECT ")
        strSQL.Append("'' AS CODE,")
        strSQL.Append("'�\���f�[�^�w�����Ԉ���Ă��܂�' AS CDNM, ")
        strSQL.Append("'�\���f�[�^�w�����Ԉ���Ă��܂�' AS NAME ")
        strSQL.Append(",' ' AS CODE2 ") '2014/10/20 T.Ono add
        strSQL.Append(",' ' AS CDNM2 ") '2014/10/20 T.Ono add
        strSQL.Append("FROM ")
        strSQL.Append("DUAL ")
    End Sub
End Class
