'***********************************************
'�Ή����ʈꗗ  �ꗗ���
'***********************************************
' �ύX����
' 2011/11/02 H.Uema �\�����ڂ̕ύX�i�폜�F�����ԍ�, �ǉ��FJA�x����, �x��P�j
' 2011/11/02 H.Uema �\�������ύX(99->999)��Web.config�Ō������`���Ă���ӏ����C��
' 2011/11/28 H.Uema �\�����ڂ̕ύX�i�ǉ��FJA�x���R�[�h�j
Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common
Imports JPG.Common.log
Imports System.Text

Partial Class KEKEKJFG00
    Inherits System.Web.UI.Page

    Protected WithEvents dbData As System.Data.DataSet

    '2011.11.15 ADD H.Uema

    Protected KEKEKJAG00_C As KEKEKJAG00
    Protected ConstC As New CConst

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
    ' Page_Load
    '******************************************************************************
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '//------------------------------------------
        '// HTTP�w�b�_�𑗐M
        HttpHeaderC.mNoCache(Response)

        '//------------------------------------------
        '//�@�F�؃N���X�̃C���X�^���X����
        AuthC = New CAuthenticate(Request, Response)

        '//------------------------------------------
        '//�@�F�؏���
        '<TODO>�F�g�p�\�������w�肷��
        '2005/12/03 NEC UPDATE START
        '[�Ή����ʈꗗ]�g�p�\����(�^:��/�c:�~/��:��/�o:�~)
        '[�Ή����ʈꗗ]�g�p�\����(�^:��/�c:��/��:��/�o:�~)
        'AuthC.fncAuthCheck(Server, AuthC.pGROUP_UNKOU & "," & AuthC.pGROUP_KANSHI)
        AuthC.fncAuthCheck(Server, AuthC.pGROUP_UNKOU & "," & AuthC.pGROUP_KANSHI & "," & AuthC.pGROUP_EIGYOU)
        '2005/12/03 NEC UPDATE START

        '//------------------------------------------
        '// �Ή�����
        If hdnJUMP.Value = "KETAIJAG00" Then
            Server.Transfer("../../../KE/KETAIJAG/KETAIJAG00/KETAIJAG00.aspx")
        End If

        '//------------------------------------------
        '// Script�����ݗp�ϐ��錾
        Dim strScript As New StringBuilder("")
        Dim cscript1 As New CScript
        Dim strScriptPath As String
        strScriptPath = ConfigurationSettings.AppSettings("SCRIPTPATH")
        '//------------------------------------------
        '//�@JavaScript�i�[
        strScript.Append("<Script language=javascript>")
        '//�Ǝ��̃X�N���v�g
        strScript.Append(cscript1.mWriteScript( _
             MyBase.MapPath("../../../KE/KEKEKJAG/KEKEKJAG00/") & "KEKEKJFG00.js"))
        '//�ꗗ�X�N���v�g
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
        If Not IsPostBack Then
            KEKEKJAG00_C = CType(Context.Handler, KEKEKJAG00)
        End If
        '//------------------------------------------
        '********************************************

        '//-------------------------------------------------
        '<TODO>�����̉��ID��HIDDEN��hdnMyAspx�ɏ������ށi�V�X�e�����ʁj
        hdnMyAspx.Value = "KEKEKJAG00"
        '//-------------------------------------------------

        Dim strKEY_KANSCD As String
        Dim strKEY_SYONO As String

        strKEY_KANSCD = KEKEKJAG00_C.pKEY_KANSCD
        strKEY_SYONO = KEKEKJAG00_C.pKEY_SYONO

        hdnMOVE_TMSKB.Value = KEKEKJAG00_C.pTMSKB
        hdnMOVE_JUTEL.Value = KEKEKJAG00_C.pJUTEL
        'hdnMOVE_NCUTEL.Value = KEKEKJAG00_C.pNCUTEL            '2014/12/05 H.Hosoda add �Ď����P2014 No.7 '2016/11/25 H.Mori del �Ď����P2016 No3-2
        hdnMOVE_KANSCD.Value = KEKEKJAG00_C.pKANSCD
        hdnMOVE_HATKBN.Value = KEKEKJAG00_C.pHATKBN
        'hdnMOVE_TAIOKBN.Value = KEKEKJAG00_C.pTAIOKBN          '2014/12/04 H.Hosoda del �Ď����P2014 No.7
        hdnMOVE_TAIOKBN1.Value = KEKEKJAG00_C.pTAIOKBN1         '2014/12/04 H.Hosoda add �Ď����P2014 No.7
        hdnMOVE_TAIOKBN2.Value = KEKEKJAG00_C.pTAIOKBN2         '2014/12/04 H.Hosoda add �Ď����P2014 No.7
        hdnMOVE_TAIOKBN3.Value = KEKEKJAG00_C.pTAIOKBN3         '2014/12/04 H.Hosoda add �Ď����P2014 No.7
        hdnMOVE_TKTANCD.Value = KEKEKJAG00_C.pTKTANCD
        hdnMOVE_TKTANNM.Value = KEKEKJAG00_C.pTKTANNAME
        hdnMOVE_JUSYONM.Value = KEKEKJAG00_C.pJUSYONM
        'hdnMOVE_JUSYOKN.Value = KEKEKJAG00_C.pJUSYOKN          '2016/11/24 H.Mori del �Ď����P2016 No3-3
        hdnMOVE_KIKANKBN.Value = KEKEKJAG00_C.pKikankbn         '2017/10/25 H.Mori add 2017���P�J�� No3-1
        hdnMOVE_HATYMD_To.Value = KEKEKJAG00_C.pHATYMD_To
        hdnMOVE_HATTIME_To.Value = KEKEKJAG00_C.pHATTIME_To
        hdnMOVE_HATYMD_From.Value = KEKEKJAG00_C.pHATYMD_From
        hdnMOVE_HATTIME_From.Value = KEKEKJAG00_C.pHATTIME_From
        hdnMOVE_KURACD.Value = KEKEKJAG00_C.pKURACD
        hdnMOVE_KURACD_NAME.Value = KEKEKJAG00_C.pKURACD_NAME
        hdnMOVE_KURACD_TO.Value = KEKEKJAG00_C.pKURACD_TO            '2019/11/01 T.Ono add �Ď����P2019
        hdnMOVE_KURACD_TO_NAME.Value = KEKEKJAG00_C.pKURACD_TO_NAME  '2019/11/01 T.Ono add �Ď����P2019
        hdnMOVE_JACD.Value = KEKEKJAG00_C.pJACD                   '2013/12/09 T.Ono add �Ď����P2013
        hdnMOVE_JACD_NAME.Value = KEKEKJAG00_C.pJACD_NAME         '2013/12/09 T.Ono add �Ď����P2013        
        hdnMOVE_JACD_CLI.Value = KEKEKJAG00_C.pJACD_CLI            '2019/11/01 T.Ono add �Ď����P2019
        '2019/11/01 T.Ono del �Ď����P2019 START
        'hdnMOVE_HAN_GRP.Value = KEKEKJAG00_C.pHANGRP              '2014/12/08 H.Hosoda add �Ď����P2014 No.7
        'hdnMOVE_HAN_GRP_NAME.Value = KEKEKJAG00_C.pHANGRP_NAME    '2014/12/08 H.Hosoda add �Ď����P2014 No.7
        'hdnMOVE_KINREN_GRP.Value = KEKEKJAG00_C.pKINRENGRP              '2016/11/25 H.Mori add �Ď����P2016 No3-1
        'hdnMOVE_KINREN_GRP_NAME.Value = KEKEKJAG00_C.pKINRENGRP_NAME    '2016/11/25 H.Mori add �Ď����P2016 No3-1
        '2019/11/01 T.Ono del �Ď����P2019 END
        hdnMOVE_ACBCD.Value = KEKEKJAG00_C.pACBCD
        hdnMOVE_ACBCD_NAME.Value = KEKEKJAG00_C.pACBCD_NAME
        hdnMOVE_ACBCD_CLI.Value = KEKEKJAG00_C.pACBCD_CLI          '2019/11/01 T.Ono add �Ď����P2019
        hdnMOVE_ACBCD_TO.Value = KEKEKJAG00_C.pACBCD_TO            '2019/11/01 T.Ono add �Ď����P2019
        hdnMOVE_ACBCD_TO_NAME.Value = KEKEKJAG00_C.pACBCD_TO_NAME  '2019/11/01 T.Ono add �Ď����P2019
        hdnMOVE_ACBCD_TO_CLI.Value = KEKEKJAG00_C.pACBCD_TO_CLI    '2019/11/01 T.Ono add �Ď����P2019
        hdnMOVE_USER_CD.Value = KEKEKJAG00_C.pUSER_CD
        '2011.11.15 ADD H.Uema
        hdnMOVE_KMCD.Value = KEKEKJAG00_C.pKMCD
        hdnMOVE_KMNM.Value = KEKEKJAG00_C.pKMNM
        '�X�N���[���ʒu
        hdnScrollTop.Value = KEKEKJAG00_C.pScrollTop                '2013/12/10 T.Ono add �Ď����P2013

        '<TODO>��ʃI�u�W�F�N�g���g�p�\�ɂ���
        strMsg.Append("parent.Form1.btnSelect.disabled=false;")
        strMsg.Append("parent.Form1.btnExit.disabled=false;")
        strMsg.Append("parent.Form1.btnCalendar1.disabled=false;")
        strMsg.Append("parent.Form1.btnCalendar2.disabled=false;")
        strMsg.Append("parent.Form1.btnTKTANCD.disabled=false;")
        strMsg.Append("parent.Form1.btnKURACD.disabled=false;")
        strMsg.Append("parent.Form1.btnKURACD_TO.disabled=false;")  '2019/11/01 T.Ono add �Ď����P2019
        strMsg.Append("parent.Form1.btnJACD.disabled=false;")       '2013/12/09 T.Ono add �Ď����P2013
        'strMsg.Append("parent.Form1.btnHANGRP.disabled=false;")     '2014/12/08 H.Hosoda add �Ď����P2014 No.7
        'strMsg.Append("parent.Form1.btnKINRENGRP.disabled=false;")     '2016/11/25 H.Mori add �Ď����P2016 No3-1
        strMsg.Append("parent.Form1.btnACBCD.disabled=false;")
        strMsg.Append("parent.Form1.btnACBCD_TO.disabled=false;")   '2019/11/01 T.Ono add �Ď����P2019
        strMsg.Append("parent.Form1.btnKMCD.disabled=false;")       '2013/12/09 T.Ono add �Ď����P2013
        strMsg.Append("window.scroll( 0, " & hdnScrollTop.Value & ");") '�X�N���[���ʒu 2013/12/09 T.Ono add �Ď����P2013
        Dim strRec As String = ""

        Try
            '//------------------------------------------
            Dim SQLC As New KEKEKJAG00CCSQL.CSQL
            Dim SqlParamC As New CSQLParam
            Dim strSQL As New StringBuilder

            '//------------------------------------------
            '//MAX�����`�F�b�N
            Dim intCount As Integer

            If KEKEKJAG00_C.pSelectClick = "1" Then

                Dim dbCnt As DataSet
                strSQL = New StringBuilder("")
                '�����{�^����������Ă���ꍇ�̂݌����`�F�b�N���s��
                Call mMakeSQL(strSQL, SqlParamC, 1, 0)
                dbCnt = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)
                If Convert.ToInt32(dbCnt.Tables(0).Rows(0).Item("CNT")) > ConstC.pScrollMax Then
                    strMsg.Append("alert('�ő�o�͌����𒴂��܂����B�������w�肵�čēx�������Ă�������');")
                End If
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


            '�擾�f�[�^�̕ҏW���s��-----------------------------
            Dim intRow As Integer

            If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
                If KEKEKJAG00_C.pSelectClick = "1" Then
                    '//�����{�^�������ɂ��f�[�^�O��
                    strMsg.Append("alert('�Ώۃf�[�^�����݂��܂���');")
                    strRec = "�f�[�^�����݂��܂���"
                End If

                dbData.Tables(0).Rows(0).Item("JS_KANSCD") = ""     'JS�o�͗p
                dbData.Tables(0).Rows(0).Item("JS_SYONO") = ""
                dbData.Tables(0).Rows(0).Item("CH_KANSCD") = ""     '�J�ڃ`�F�b�N�p
                dbData.Tables(0).Rows(0).Item("CH_SYONO") = ""
                dbData.Tables(0).Rows(0).Item("ROWNO") = ""
                dbData.Tables(0).Rows(0).Item("COLOR") = ""     'SPAN�J���[
                dbData.Tables(0).Rows(0).Item("CLS") = ""       'SPAN�N���X
                dbData.Tables(0).Rows(0).Item("KANSCD") = ""
                dbData.Tables(0).Rows(0).Item("SYONO") = ""
                dbData.Tables(0).Rows(0).Item("SYOYMD") = ""
                dbData.Tables(0).Rows(0).Item("SYOTIME") = ""
                dbData.Tables(0).Rows(0).Item("HATYMD") = ""
                dbData.Tables(0).Rows(0).Item("HATTIME") = ""
                dbData.Tables(0).Rows(0).Item("HATKBN") = ""
                dbData.Tables(0).Rows(0).Item("TAIOKBN") = ""
                dbData.Tables(0).Rows(0).Item("TMSKB") = ""
                dbData.Tables(0).Rows(0).Item("JUSYONM") = ""

                '*** 2011.11.02 ADD h.uema �\�����ډ��C�ɔ����C�� ***** START
                dbData.Tables(0).Rows(0).Item("ACBCD") = ""
                dbData.Tables(0).Rows(0).Item("ACBNM") = ""
                dbData.Tables(0).Rows(0).Item("KMCD1") = ""
                dbData.Tables(0).Rows(0).Item("KMNM1") = ""
                '*** 2011.11.02 ADD h.uema �\�����ډ��C�ɔ����C�� ***** END

            Else
                Dim strJsCode As New StringBuilder("")
                Dim EscapeC As New CEscape

                Dim strTemp As String

                For intRow = 0 To dbData.Tables(0).Rows.Count - 1
                    'Html��Js�ɂĎg�p����
                    dbData.Tables(0).Rows(intRow).Item("ROWNO") =
                        EscapeC.mDb_Js(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("ROWNO")))
                    dbData.Tables(0).Rows(intRow).Item("JS_KANSCD") =
                        EscapeC.mDb_Js(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("JS_KANSCD")))
                    dbData.Tables(0).Rows(intRow).Item("JS_SYONO") =
                        EscapeC.mDb_Js(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("JS_SYONO")))
                    'Html�̒l�Ƃ��Ďg�p����
                    dbData.Tables(0).Rows(intRow).Item("KANSCD") =
                        EscapeC.mDb_Html(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("KANSCD")))
                    dbData.Tables(0).Rows(intRow).Item("SYONO") =
                        EscapeC.mDb_Html(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("SYONO")))
                    dbData.Tables(0).Rows(intRow).Item("SYOYMD") =
                        EscapeC.mDb_Html(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("SYOYMD")))
                    dbData.Tables(0).Rows(intRow).Item("SYOTIME") =
                        EscapeC.mDb_Html(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("SYOTIME")))
                    dbData.Tables(0).Rows(intRow).Item("HATYMD") =
                        EscapeC.mDb_Html(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("HATYMD")))
                    dbData.Tables(0).Rows(intRow).Item("HATTIME") =
                        EscapeC.mDb_Html(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("HATTIME")))
                    dbData.Tables(0).Rows(intRow).Item("HATKBN") =
                        EscapeC.mDb_Html(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("HATKBN")))
                    dbData.Tables(0).Rows(intRow).Item("TAIOKBN") =
                        EscapeC.mDb_Html(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("TAIOKBN")))
                    dbData.Tables(0).Rows(intRow).Item("TMSKB") =
                        EscapeC.mDb_Html(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("TMSKB")))
                    dbData.Tables(0).Rows(intRow).Item("JUSYONM") =
                        EscapeC.mDb_Html(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("JUSYONM")))

                    '*** 2011.11.02 ADD h.uema �\�����ډ��C�ɔ����C�� ***** START
                    dbData.Tables(0).Rows(intRow).Item("ACBCD") =
                        EscapeC.mDb_Html(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("ACBCD")))
                    dbData.Tables(0).Rows(intRow).Item("ACBNM") =
                        EscapeC.mDb_Html(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("ACBNM")))
                    dbData.Tables(0).Rows(intRow).Item("KMCD1") =
                        EscapeC.mDb_Html(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("KMCD1")))
                    dbData.Tables(0).Rows(intRow).Item("KMNM1") =
                        EscapeC.mDb_Html(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("KMNM1")))
                    '*** 2011.11.02 ADD h.uema �\�����ډ��C�ɔ����C�� ***** END

                    '//�o�^��ʂ��߂��Ă������̉�ʑJ�ڎ��ɁA�w�肵���f�[�^�̐F��ύX����
                    If (strKEY_KANSCD = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("CH_KANSCD")) And
                        strKEY_SYONO = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("CH_SYONO"))) Then
                        dbData.Tables(0).Rows(intRow).Item("COLOR") = "GreenYellow"
                        dbData.Tables(0).Rows(intRow).Item("CLS") = "CHK"
                    Else
                        dbData.Tables(0).Rows(intRow).Item("COLOR") = "skyblue"
                        dbData.Tables(0).Rows(intRow).Item("CLS") = ""
                    End If

                    '*** 2011.11.02 cmmentOut h.uema
                    '*** �����ԍ����ڂ���\���ƂȂ邽�߁A���L�����͕s�v
                    ''//��ʃ����N�������ԍ���
                    'If Convert.ToString(dbData.Tables(0).Rows(intRow).Item("SYONO")) <> "" Then

                    '    '//�����ԍ��Ƀ����N�����A�Ή����͂ɑJ�ڂ���
                    '    strJsCode = New StringBuilder("")
                    '    strJsCode.Append("<a href=""JavaScript:fncJump(")
                    '    strJsCode.Append("'" & Convert.ToString(dbData.Tables(0).Rows(intRow).Item("JS_KANSCD")) & "',")
                    '    strJsCode.Append("'" & Convert.ToString(dbData.Tables(0).Rows(intRow).Item("JS_SYONO")) & "'")
                    '    strJsCode.Append(")"">")
                    '    strJsCode.Append(Convert.ToString(dbData.Tables(0).Rows(intRow).Item("SYONO")))
                    '    strJsCode.Append("</a>")

                    '    dbData.Tables(0).Rows(intRow).Item("SYONO") = strJsCode.ToString
                    'End If
                    '//������
                    strTemp = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("HATYMD"))
                    If IsNumeric(strTemp) = True Then
                        dbData.Tables(0).Rows(intRow).Item("HATYMD") = KEKEKJAG00_C.fncDateSet(strTemp)
                    End If
                    '//��������
                    strTemp = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("HATTIME"))
                    If IsNumeric(strTemp) = True Then
                        dbData.Tables(0).Rows(intRow).Item("HATTIME") = KEKEKJAG00_C.fncTimeSet(strTemp, 0)
                    End If
                    '//�Ή�������
                    strTemp = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("SYOYMD"))
                    If IsNumeric(strTemp) = True Then
                        dbData.Tables(0).Rows(intRow).Item("SYOYMD") = KEKEKJAG00_C.fncDateSet(strTemp)
                    End If
                    '//�Ή���������
                    strTemp = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("SYOTIME"))
                    If IsNumeric(strTemp) = True Then
                        dbData.Tables(0).Rows(intRow).Item("SYOTIME") = KEKEKJAG00_C.fncTimeSet(strTemp, 1)
                    End If
                    '*** 2011.11.02 ADD h.uema �\�����ډ��C�ɔ����C�� ***** START
                    '// JA�x�X�x��
                    strTemp = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("ACBNM"))
                    If strTemp = "" Then
                        strTemp = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("ACBCD"))
                        If strTemp = "" Then
                            strTemp = "***"
                        End If
                    End If
                    '//�����N�����A�Ή����͂ɑJ�ڂ���
                    strJsCode = New StringBuilder("")
                    strJsCode.Append("<a href=""JavaScript:fncJump(")
                    strJsCode.Append("'" & Convert.ToString(dbData.Tables(0).Rows(intRow).Item("JS_KANSCD")) & "',")
                    strJsCode.Append("'" & Convert.ToString(dbData.Tables(0).Rows(intRow).Item("JS_SYONO")) & "'")
                    strJsCode.Append(")"">")
                    strJsCode.Append(strTemp)
                    strJsCode.Append("</a>")
                    dbData.Tables(0).Rows(intRow).Item("ACBNM") = strJsCode.ToString
                    '// �x��P
                    If Convert.ToString(dbData.Tables(0).Rows(intRow).Item("KMCD1")) = "" Then
                        strTemp = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("KMNM1"))
                    Else
                        strTemp = Convert.ToString(dbData.Tables(0).Rows(intRow).Item("KMCD1")) +
                                ":" + Convert.ToString(dbData.Tables(0).Rows(intRow).Item("KMNM1"))
                    End If
                    dbData.Tables(0).Rows(intRow).Item("KMNM1") = strTemp
                    '*** 2011.11.02 ADD h.uema �\�����ډ��C�ɔ����C�� ***** END
                Next

            End If


            '���s�[�^�Ƀo�C���h����-----------------------------
            rptData.DataBind()


            '********************************************
            If KEKEKJAG00_C.pSelectClick = "1" Then
                If strRec.Length = 0 Then       '[�f�[�^�����݂��܂���]�̃��b�Z�[�W���o��
                    strRec = "OK"
                End If
            End If
        Catch ex As Exception
            strRec = ex.ToString
            Dim ErrMsgC As New CErrMsg
            strMsg.Append("alert('�V�X�e���G���[�F" & ErrMsgC.mGetArtMsg(strRec) & "');")
        End Try

        If KEKEKJAG00_C.pSelectClick = "1" Then
            '//�����{�^�������ɂ���ʏo�͂̏ꍇ�͌����{�^���Ƀt�H�[�J�X�Z�b�g
            '//�����o�͎��͐e��ʂł̐���ɔC����
            '<TODO>������̃t�H�[�J�X���Z�b�g����
            strMsg.Append("parent.Form1.btnSelect.focus();")

            '-------------------------------------------------
            '//�`�o���O��������
            Dim LogC As New CLog
            Dim strRecLog As String
            '2012/04/04 NEC ou Upd
            'strRecLog = LogC.mAPLog(Request.Cookies.Get("ASP.NET_SessionId").Value, AuthC.pUSERNAME, AuthC.pIPADDRESS, hdnMyAspx.Value, "4", strRec, Request.Form)
            strRecLog = LogC.mAPLog(Me.Session.SessionID, AuthC.pUSERNAME, AuthC.pIPADDRESS, hdnMyAspx.Value, "4", strRec, Request.Form)
            '2012/04/04 NEC ou Upd
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

        '2013/12/10 T.Ono add �Ď����P2013
        If intkbn = 0 Then
            If intCount > 0 Then
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
                'strSQL.Append("LPAD(ROWNUM,3,0) AS ROWNO, ")   '2013/12/10 T.Ono mod �Ď����P2013
                strSQL.Append("LPAD(ROWNUM,4,0) AS ROWNO, ")
                strSQL.Append("	'' AS COLOR,")                                              'SPAN�J���[
                strSQL.Append("	'' AS CLS,")                                                'SPAN�N���X
                strSQL.Append("	TAI.KANSCD,")
                strSQL.Append("	TAI.SYONO,")
                strSQL.Append("	TAI.KANSCD AS JS_KANSCD,")
                strSQL.Append("	TAI.SYONO AS JS_SYONO,")
                strSQL.Append("	TAI.KANSCD AS CH_KANSCD,")
                strSQL.Append("	TAI.SYONO AS CH_SYONO,")
                strSQL.Append("	TAI.SYOYMD,")
                strSQL.Append("	TAI.SYOTIME,")
                strSQL.Append("	TAI.HATYMD,")
                strSQL.Append("	TAI.HATTIME,")
                strSQL.Append("	TAI.HATKBN AS HATKBNCD,")
                strSQL.Append("	P08.NAME AS HATKBN,")
                strSQL.Append("	TAI.TAIOKBN AS TAIOKBNCD,")
                strSQL.Append("	P09.NAME AS TAIOKBN,")
                '*** 2011.11.02 ADD h.uema �\�����ډ��C�ɔ����C�� ***** START
                strSQL.Append(" TAI.ACBCD,")
                strSQL.Append(" TAI.ACBNM,")
                strSQL.Append(" TAI.KMCD1,")
                strSQL.Append(" TAI.KMNM1,")
                '*** 2011.11.02 ADD h.uema �\�����ډ��C�ɔ����C�� ***** END
                strSQL.Append("	TAI.TMSKB AS TMSKBCD,")
                strSQL.Append("	P10.NAME AS TMSKB,")
                strSQL.Append("	TAI.JUSYONM,")
                strSQL.Append("	TAI.TAIO_ST_DATE,")
                strSQL.Append("	TAI.TAIO_ST_TIME ")
                strSQL.Append("FROM D20_TAIOU TAI, ")
                strSQL.Append("     M06_PULLDOWN P08, ")
                strSQL.Append("     M06_PULLDOWN P09, ")
                strSQL.Append("     M06_PULLDOWN P10 ")
            Else
                strSQL.Append("'XYZ' AS ROWNO, ")
                strSQL.Append("	'' AS COLOR,")
                strSQL.Append("	'' AS CLS,")
                strSQL.Append("	'' AS KANSCD,")
                strSQL.Append("	'' AS SYONO,")
                strSQL.Append("	'' AS JS_KANSCD,")
                strSQL.Append("	'' AS JS_SYONO,")
                strSQL.Append("	'' AS CH_KANSCD,")
                strSQL.Append("	'' AS CH_SYONO,")
                strSQL.Append("	'' AS SYOYMD,")
                strSQL.Append("	'' AS SYOTIME,")
                strSQL.Append("	'' AS HATYMD,")
                strSQL.Append("	'' AS HATTIME,")
                strSQL.Append("	'' AS HATKBNCD,")
                strSQL.Append("	'' AS HATKBN,")
                strSQL.Append("	'' AS TAIOKBNCD,")
                strSQL.Append("	'' AS TAIOKBN,")
                '*** 2011.11.02 ADD h.uema �\�����ډ��C�ɔ����C�� ***** START
                strSQL.Append(" '' AS ACBCD,")
                strSQL.Append(" '' AS ACBNM,")
                strSQL.Append(" '' AS KMCD1,")
                strSQL.Append(" '' AS KMNM1,")
                '*** 2011.11.02 ADD h.uema �\�����ډ��C�ɔ����C�� ***** END
                strSQL.Append("	'' AS TMSKBCD,")
                strSQL.Append("	'' AS TMSKB,")
                strSQL.Append("	'' AS JUSYONM,")
                strSQL.Append("	'' AS TAIO_ST_DATE,")
                strSQL.Append("	'' AS TAIO_ST_TIME ")
                strSQL.Append("FROM DUAL ")
                strSQL.Append(") A") '2013/12/10 add T.Ono �Ď����P2013

                Exit Sub
            End If
        Else
            '//�����J�E���g�p��SQL
            strSQL.Append("COUNT(*) AS CNT ")       '�J�E���g
            strSQL.Append("FROM D20_TAIOU TAI ")
        End If

        If intkbn = 0 Then
            strSQL.Append("  WHERE ROWNUM <= " & ConstC.pScrollMax)
        Else
            strSQL.Append("  WHERE ROWNUM <= " & ConstC.pScrollMax + 1)
        End If

        '�Ď��Z���^�[
        If KEKEKJAG00_C.pKANSCD.Length > 0 Then
            strSQL.Append(" AND TAI.KANSCD = :KANSCD ")
        End If

        ''��������
        'If KEKEKJAG00_C.pHATYMD_From.Length > 0 And KEKEKJAG00_C.pHATYMD_To.Length > 0 Then
        '    strSQL.Append(" AND TAI.HATYMD BETWEEN :HATYMD_FROM AND :HATYMD_TO ")
        'End If
        'If KEKEKJAG00_C.pHATYMD_From.Length > 0 And KEKEKJAG00_C.pHATYMD_To.Length = 0 Then
        '    strSQL.Append(" AND TAI.HATYMD >= :HATYMD_FROM ")
        'End If
        'If KEKEKJAG00_C.pHATYMD_From.Length = 0 And KEKEKJAG00_C.pHATYMD_To.Length > 0 Then
        '    strSQL.Append(" AND TAI.HATYMD <= :HATYMD_TO ")
        'End If
        ''��������
        'If KEKEKJAG00_C.pHATTIME_From.Length > 0 And KEKEKJAG00_C.pHATTIME_To.Length > 0 Then
        '    strSQL.Append(" AND TAI.HATTIME BETWEEN :HATTIME_FROM AND :HATTIME_TO ")
        'End If
        'If KEKEKJAG00_C.pHATTIME_From.Length > 0 And KEKEKJAG00_C.pHATTIME_To.Length = 0 Then
        '    strSQL.Append(" AND TAI.HATTIME >= :HATTIME_FROM ")
        'End If
        'If KEKEKJAG00_C.pHATTIME_From.Length = 0 And KEKEKJAG00_C.pHATTIME_To.Length > 0 Then
        '    strSQL.Append(" AND TAI.HATTIME <= :HATTIME_TO ")
        'End If

        '2017/10/25 H.Mori add 2017���P�J�� No3-1 �Ή��������E��M�� START
        If KEKEKJAG00_C.pKikankbn = "2" Then '��M��
            '�Ώۊ��ԥ�Ώێ���From
            If KEKEKJAG00_C.pHATYMD_From.Length > 0 AndAlso KEKEKJAG00_C.pHATTIME_From.Length > 0 Then
                strSQL.Append(" AND TAI.HATYMD || TAI.HATTIME >= :HATYMD_FROM || :HATTIME_FROM ")
            End If
            If KEKEKJAG00_C.pHATYMD_From.Length > 0 AndAlso KEKEKJAG00_C.pHATTIME_From.Length = 0 Then
                strSQL.Append(" AND TAI.HATYMD >= :HATYMD_FROM ")
            End If
            '�Ώۊ��ԥ�Ώێ���To
            If KEKEKJAG00_C.pHATYMD_To.Length > 0 AndAlso KEKEKJAG00_C.pHATTIME_To.Length > 0 Then
                strSQL.Append(" AND TAI.HATYMD || TAI.HATTIME <= :HATYMD_TO || :HATTIME_To ")
            End If
            If KEKEKJAG00_C.pHATYMD_To.Length > 0 AndAlso KEKEKJAG00_C.pHATTIME_To.Length = 0 Then
                strSQL.Append(" AND TAI.HATYMD <= :HATYMD_TO ")
            End If
        End If
        If KEKEKJAG00_C.pKikankbn = "1" Then '�Ή�������
            '�Ώۊ��ԥ�Ώێ���From
            If KEKEKJAG00_C.pHATYMD_From.Length > 0 AndAlso KEKEKJAG00_C.pHATTIME_From.Length > 0 Then
                strSQL.Append(" AND TAI.SYOYMD || TAI.SYOTIME >= :HATYMD_FROM || :HATTIME_FROM ")
            End If
            If KEKEKJAG00_C.pHATYMD_From.Length > 0 AndAlso KEKEKJAG00_C.pHATTIME_From.Length = 0 Then
                strSQL.Append(" AND TAI.SYOYMD >= :HATYMD_FROM ")
            End If
            '�Ώۊ��ԥ�Ώێ���To
            If KEKEKJAG00_C.pHATYMD_To.Length > 0 AndAlso KEKEKJAG00_C.pHATTIME_To.Length > 0 Then
                strSQL.Append(" AND TAI.SYOYMD || TAI.SYOTIME <= :HATYMD_TO || :HATTIME_To ")
            End If
            If KEKEKJAG00_C.pHATYMD_To.Length > 0 AndAlso KEKEKJAG00_C.pHATTIME_To.Length = 0 Then
                strSQL.Append(" AND TAI.SYOYMD <= :HATYMD_TO ")
            End If
        End If
        '2017/10/25 H.Mori add 2017���P�J�� No3-1 �Ή��������E��M�� END

        '�Ď��Z���^�[�S����
        If KEKEKJAG00_C.pTKTANCD.Length > 0 Then
            strSQL.Append(" AND TAI.TKTANCD = :TKTANCD ")
        End If
        '�����敪
        If KEKEKJAG00_C.pHATKBN.Length > 0 Then
            strSQL.Append(" AND TAI.HATKBN = :HATKBN ")
        End If

        '�Ή��敪
        '2014/12/05 H.Hosoda mod �Ď����P2014 No.7 START
        'If KEKEKJAG00_C.pTAIOKBN.Length > 0 Then
        '    strSQL.Append(" AND TAI.TAIOKBN = :TAIOKBN ")
        'End If
        strSQL.Append(" AND TAI.TAIOKBN IN (:TAIOKBN1,:TAIOKBN2,:TAIOKBN3)")
        '2014/12/05 H.Hosoda mod �Ď����P2014 No.7 END

        '�����敪
        If KEKEKJAG00_C.pTMSKB.Length > 0 Then
            strSQL.Append(" AND TAI.TMSKB = :TMSKB ")
        End If
        '���q�l�d�b�ԍ�
        If KEKEKJAG00_C.pJUTEL.Length > 0 Then
            '2014/12/05 H.Hosoda mod �Ď����P2014 No.7 START
            'strSQL.Append(" AND TAI.KTELNO LIKE :KTELNO || '%' ")
            'strSQL.Append(" AND REPLACE(TAI.KTELNO,'-','') ") 2015/01/23 T.Ono mod �Ď����P2014 No.7
            '�A����2,3�@2016/1/29 H.Mori mod �Ď����P2015 START
            'strSQL.Append(" AND REPLACE(REPLACE(TAI.KTELNO,'-',''),' ','') ")
            'strSQL.Append("  LIKE REPLACE(:KTELNO,'-','') || '%' ")
            '2016/11/25 H.Mori mod ���P2016 No3-2 START
            'strSQL.Append(" AND (REPLACE(REPLACE(TAI.KTELNO,'-',''), ' ','') ")
            'strSQL.Append("  LIKE REPLACE(:KTELNO,'-','') || '%' ")
            strSQL.Append(" AND (REPLACE(REPLACE(TAI.RENTEL,'-',''), ' ','') ")
            strSQL.Append("  LIKE REPLACE(:KTELNO,'-','') || '%' ")
            '2016/11/25 H.Mori mod ���P2016 No3-2 END
            strSQL.Append(" OR REPLACE(REPLACE(TAI.RENTEL2,'-',''), ' ','') ")
            strSQL.Append("  LIKE REPLACE(:KTELNO,'-','') || '%' ")
            strSQL.Append(" OR REPLACE(REPLACE(TAI.RENTEL3,'-',''), ' ','') ")
            strSQL.Append("  LIKE REPLACE(:KTELNO,'-','') || '%' ")
            '�A����2,3�@2016/1/29 H.Mori mod �Ď����P2015 END
            '2014/12/05 H.Hosoda mod �Ď����P2014 No.7 END
            '2016/11/25 H.Mori add ���P2016 No3-2 START
            strSQL.Append(" OR REPLACE(REPLACE(TAI.JUTEL1 || TAI.JUTEL2,'-',''),' ','') ")
            strSQL.Append("  LIKE REPLACE(:KTELNO,'-','') || '%' ")
            strSQL.Append(" OR REPLACE(REPLACE(TAI.TELAB,'-',''),' ','') ")
            strSQL.Append("  LIKE REPLACE(:KTELNO,'-','') || '%' ")
            strSQL.Append(" OR REPLACE(REPLACE(TAI.DAI3RENDORENTEL,'-',''),' ','') ")
            strSQL.Append("  LIKE REPLACE(:KTELNO,'-','') || '%') ")
            '2016/12/22 H.Mori add �Ď����P2016 No3-2 END
        End If
        '2016/11/25 H.Mori del �Ď����P2016 No3-2 START
        '�����ԍ�  '2014/12/05 H.Hosoda add �Ď����P2014 No.7
        'If KEKEKJAG00_C.pNCUTEL.Length > 0 Then
        '    'strSQL.Append(" AND REPLACE(TAI.JUTEL1 || TAI.JUTEL2,'-','') ") 2015/01/23 T.Ono mod �Ď����P2014 ��7
        '    strSQL.Append(" AND REPLACE(REPLACE(TAI.JUTEL1 || TAI.JUTEL2,'-',''),' ','') ")
        '    strSQL.Append("  LIKE REPLACE(:NCUTELNO,'-','') || '%' ")
        'End If
        '2016/11/25 H.Mori del �Ď����P2016 No3-2 END
        '���q�l��
        If KEKEKJAG00_C.pJUSYONM.Length > 0 Then
            '2014/12/05 H.Hosoda mod �Ď����P2014 No.7 START
            'strSQL.Append(" AND TAI.JUSYONM LIKE :JUSYONM || '%' ")
            strSQL.Append(" AND (REPLACE(UTL_I18N.TRANSLITERATE(TO_SINGLE_BYTE (TAI.JUSYONM), 'FWKATAKANA_HWKATAKANA'),' ','') ")
            strSQL.Append("  LIKE REPLACE(UTL_I18N.TRANSLITERATE(TO_SINGLE_BYTE (:JUSYONM), 'FWKATAKANA_HWKATAKANA'),' ','')  || '%' ")
            '2014/12/05 H.Hosoda mod �Ď����P2014 No.7 END
            '2016/11/24 H.Mori add �Ď����P2016 No3-3 START
            strSQL.Append(" OR  REPLACE(UTL_I18N.TRANSLITERATE(TO_SINGLE_BYTE (TAI.JUSYOKN), 'FWKATAKANA_HWKATAKANA'),' ','') ")
            strSQL.Append("  LIKE REPLACE(UTL_I18N.TRANSLITERATE(TO_SINGLE_BYTE (:JUSYONM), 'FWKATAKANA_HWKATAKANA'),' ','')  || '%') ")
            '2016/11/24 H.Mori add �Ď����P2016 No3-3 END
        End If
        '2016/11/24 H.Mori del �Ď����P2016 No3-3 START
        ''���q�l���J�i
        'If KEKEKJAG00_C.pJUSYOKN.Length > 0 Then
        '    '2014/12/05 H.Hosoda mod �Ď����P2014 No.7 START
        '    'strSQL.Append(" AND TAI.JUSYOKN LIKE :JUSYOKN || '%' ")
        '    strSQL.Append(" AND REPLACE(UTL_I18N.TRANSLITERATE(TO_SINGLE_BYTE (TAI.JUSYOKN), 'FWKATAKANA_HWKATAKANA'),' ','') ")
        '    strSQL.Append("  LIKE REPLACE(UTL_I18N.TRANSLITERATE(TO_SINGLE_BYTE (:JUSYOKN), 'FWKATAKANA_HWKATAKANA'),' ','')  || '%' ")
        '    '2014/12/05 H.Hosoda mod �Ď����P2014 No.7 END
        'End If
        '2016/11/24 H.Mori del �Ď����P2016 No3-3 END
        '�N���C�A���g�R�[�h
        If KEKEKJAG00_C.pKURACD.Length > 0 Then
            '2019/11/01 T.Ono mod �Ď����P2019
            'strSQL.Append(" AND TAI.KURACD = :KURACD ")
            strSQL.Append(" AND TAI.KURACD >= :KURACD ")
            strSQL.Append(" AND TAI.KURACD <= :KURACD_TO ")
        End If
        '�i�`�R�[�h 2013/12/10 T.Ono add �Ď����P2013
        If KEKEKJAG00_C.pJACD.Length > 0 Then
            strSQL.Append(" AND TAI.JACD = :JACD ")
        End If

        '2019/11/01 T.Ono del �Ď����P2019 START
        ''�̔����Ǝ҃O���[�v�R�[�h 2014/12/08 H.Hosoda add �Ď����P2014 No.7
        'If KEKEKJAG00_C.pHANGRP.Length > 0 Then
        '    strSQL.Append(" AND TAI.HANJICD = :HANGRP ")
        'End If
        ''�ً}�A����Gr 2016/11/25 H.Mori add �Ď����P2016 No3-1
        'If KEKEKJAG00_C.pKINRENGRP.Length > 0 Then
        '    strSQL.Append(" AND TAI.KINRENCD = :KINRENGRP ")
        'End If
        '2019/11/01 T.Ono del �Ď����P2019 END

        '�i�`�x���R�[�h
        If KEKEKJAG00_C.pACBCD.Length > 0 Then
            ' 2011/11/15 MOD H.Uema JA�x���R�[�h��Like����(�O����v)�֕ύX
            'strSQL.Append(" AND TAI.ACBCD = :ACBCD ") 'DEL
            'strSQL.Append(" AND TAI.ACBCD LIKE :ACBCD || '%' ") 'ADD '2013/12/10 T.Ono mod �Ď����P2013
            '2019/11/01 T.Ono mod �Ď����P2019
            'strSQL.Append(" AND TAI.ACBCD = :ACBCD ")
            strSQL.Append(" AND TAI.KURACD || TAI.ACBCD >= :KURACD || :ACBCD ")
            strSQL.Append(" AND TAI.KURACD || TAI.ACBCD <= :KURACD_TO || :ACBCD_TO ")
        End If
        '���q�l�R�[�h
        If KEKEKJAG00_C.pUSER_CD.Length > 0 Then
            strSQL.Append(" AND TAI.USER_CD LIKE :USER_CD || '%' ")
        End If
        '2011.11.15 ADD H.Uema
        '�x��R�[�h
        If KEKEKJAG00_C.pKMCD.Length > 0 Then
            strSQL.Append(" AND TAI.KMCD1 = :KMCD ")
        End If

        If intkbn = 0 Then
            strSQL.Append("  AND '08'   = P08.KBN(+) ")
            strSQL.Append("  AND TAI.HATKBN = P08.CD(+) ")
            strSQL.Append("  AND '09'   = P09.KBN(+) ")
            strSQL.Append("  AND TAI.TAIOKBN = P09.CD(+) ")
            strSQL.Append("  AND '10'   = P10.KBN(+) ")
            strSQL.Append("  AND TAI.TMSKB = P10.CD(+) ")
            '2020/11/01 T.Ono mod �Ď����P2020 START
            ''2014/12/05 H.Hosoda mod �Ď����P2014 No.7 START
            ''strSQL.Append("ORDER BY TAI.HATYMD DESC,TAI.HATTIME DESC ")
            'strSQL.Append("ORDER BY TAI.HATYMD DESC,TAI.HATTIME DESC,TAI.SYONO DESC ")
            ''2014/12/05 H.Hosoda mod �Ď����P2014 No.7 END
            If KEKEKJAG00_C.pKikankbn = "2" Then '��M��
                strSQL.Append("ORDER BY TAI.HATYMD DESC,TAI.HATTIME DESC,TAI.SYONO DESC ")
            ElseIf KEKEKJAG00_C.pKikankbn = "1" Then '�Ή�������
                strSQL.Append("ORDER BY TAI.SYOYMD DESC,TAI.SYOTIME DESC,TAI.SYONO DESC ")
            Else '��{�͎�M��
                strSQL.Append("ORDER BY TAI.HATYMD DESC,TAI.HATTIME DESC,TAI.SYONO DESC ")
            End If
            '2020/11/01 T.Ono mod �Ď����P2020 END
            strSQL.Append(") A") '2013/12/10 add T.Ono �Ď����P2013
        End If

        '�p�����[�^�̃Z�b�g
        If KEKEKJAG00_C.pKANSCD.Length > 0 Then
            SqlParamC.fncSetParam("KANSCD", True, KEKEKJAG00_C.pKANSCD)
        End If
        If KEKEKJAG00_C.pHATYMD_From.Length > 0 Then
            SqlParamC.fncSetParam("HATYMD_FROM", True, KEKEKJAG00_C.pHATYMD_From)
        End If
        If KEKEKJAG00_C.pHATYMD_To.Length > 0 Then
            SqlParamC.fncSetParam("HATYMD_TO", True, KEKEKJAG00_C.pHATYMD_To)
        End If
        If KEKEKJAG00_C.pHATTIME_From.Length > 0 Then
            SqlParamC.fncSetParam("HATTIME_FROM", True, KEKEKJAG00_C.pHATTIME_From)
            ''''''SqlParamC.fncSetParam("HATTIME_FROM", True, KEKEKJAG00_C.pHATTIME_From & "00")
        End If

        If KEKEKJAG00_C.pHATTIME_To.Length > 0 Then
            '2017/10/26 H.Mori add 2017���P�J�� No3-1 START
            SqlParamC.fncSetParam("HATTIME_TO", True, KEKEKJAG00_C.pHATTIME_To & "59")
            ''''''SqlParamC.fncSetParam("HATTIME_TO", True, KEKEKJAG00_C.pHATTIME_To)
            ''''''SqlParamC.fncSetParam("HATTIME_TO", True, KEKEKJAG00_C.pHATTIME_To & "99")
            '2017/10/26 H.Mori add 2017���P�J�� No3-1 END
        End If
        If KEKEKJAG00_C.pTKTANCD.Length > 0 Then
            SqlParamC.fncSetParam("TKTANCD", True, KEKEKJAG00_C.pTKTANCD)
        End If
        If KEKEKJAG00_C.pHATKBN.Length > 0 Then
            SqlParamC.fncSetParam("HATKBN", True, KEKEKJAG00_C.pHATKBN)
        End If

        '2014/12/05 H.Hosoda mod �Ď����P2014 No.7 START
        'If KEKEKJAG00_C.pTAIOKBN.Length > 0 Then
        '    SqlParamC.fncSetParam("TAIOKBN", True, KEKEKJAG00_C.pTAIOKBN)
        'End If
        '�`�F�b�N�{�b�N�X�@0�F�`�F�b�N�Ȃ��@1�F�`�F�b�N����
        '�Ή��敪�@1�F�d�b�@2�F�o���@3�F�d��
        If KEKEKJAG00_C.pTAIOKBN1 = "0" Then
            SqlParamC.fncSetParam("TAIOKBN1", True, "")
        Else
            SqlParamC.fncSetParam("TAIOKBN1", True, "1")
        End If

        If KEKEKJAG00_C.pTAIOKBN2 = "0" Then
            SqlParamC.fncSetParam("TAIOKBN2", True, "")
        Else
            SqlParamC.fncSetParam("TAIOKBN2", True, "2")
        End If

        If KEKEKJAG00_C.pTAIOKBN3 = "0" Then
            SqlParamC.fncSetParam("TAIOKBN3", True, "")
        Else
            SqlParamC.fncSetParam("TAIOKBN3", True, "3")
        End If
        '2014/12/05 H.Hosoda mod �Ď����P2014 No.7 END

        If KEKEKJAG00_C.pTMSKB.Length > 0 Then
            SqlParamC.fncSetParam("TMSKB", True, KEKEKJAG00_C.pTMSKB)
        End If
        If KEKEKJAG00_C.pJUTEL.Length > 0 Then
            SqlParamC.fncSetParam("KTELNO", True, KEKEKJAG00_C.pJUTEL)
        End If
        '2016/11/25 H.Mori del �Ď����P2016 No3-2 START
        '2014/12/05 H.Hosoda add �Ď����P2014 No.7 START
        'If KEKEKJAG00_C.pNCUTEL.Length > 0 Then
        '    SqlParamC.fncSetParam("NCUTELNO", True, KEKEKJAG00_C.pNCUTEL)
        'End If
        '2014/12/05 H.Hosoda add �Ď����P2014 No.7 END
        '2016/11/25 H.Mori del �Ď����P2016 No3-2 END
        If KEKEKJAG00_C.pJUSYONM.Length > 0 Then
            SqlParamC.fncSetParam("JUSYONM", True, KEKEKJAG00_C.pJUSYONM)
        End If
        '2016/11/24 H.Mori del �Ď����P2016 No3-3 START
        'If KEKEKJAG00_C.pJUSYOKN.Length > 0 Then
        '    SqlParamC.fncSetParam("JUSYOKN", True, KEKEKJAG00_C.pJUSYOKN)
        'End If
        '2016/11/24 H.Mori del �Ď����P2016 No3-3 END

        '2019/11/01 T.Ono mod �Ď����P2019 START
        'If KEKEKJAG00_C.pKURACD.Length > 0 Then
        '    SqlParamC.fncSetParam("KURACD", True, KEKEKJAG00_C.pKURACD)
        'End If
        ''2013/12/10 T.Ono add �Ď����P2013
        'If KEKEKJAG00_C.pJACD.Length > 0 Then
        '    SqlParamC.fncSetParam("JACD", True, KEKEKJAG00_C.pJACD)
        'End If
        'If KEKEKJAG00_C.pHANGRP.Length > 0 Then    '2014/12/08 H.Hosoda add �Ď����P2014 No.7 
        '    SqlParamC.fncSetParam("HANGRP", True, KEKEKJAG00_C.pHANGRP)
        'End If
        'If KEKEKJAG00_C.pKINRENGRP.Length > 0 Then    '2016/11/25 H.Mori add �Ď����P2016 No3-1 
        '    SqlParamC.fncSetParam("KINRENGRP", True, KEKEKJAG00_C.pKINRENGRP)
        'End If
        If KEKEKJAG00_C.pJACD.Length > 0 Then
            SqlParamC.fncSetParam("JACD", True, KEKEKJAG00_C.pJACD)
            SqlParamC.fncSetParam("KURACD", True, KEKEKJAG00_C.pJACD_CLI)
            SqlParamC.fncSetParam("KURACD_TO", True, KEKEKJAG00_C.pJACD_CLI)
        Else
            If KEKEKJAG00_C.pKURACD.Length > 0 Then
                SqlParamC.fncSetParam("KURACD", True, KEKEKJAG00_C.pKURACD)
            End If
            If KEKEKJAG00_C.pKURACD_TO.Length > 0 Then
                SqlParamC.fncSetParam("KURACD_TO", True, KEKEKJAG00_C.pKURACD_TO)
            End If
        End If
        '2019/11/01 T.Ono mod �Ď����P2019 END
        If KEKEKJAG00_C.pACBCD.Length > 0 Then
            SqlParamC.fncSetParam("ACBCD", True, KEKEKJAG00_C.pACBCD)
            '2019/11/01 T.Ono add �Ď����P2019
            SqlParamC.fncSetParam("ACBCD_TO", True, KEKEKJAG00_C.pACBCD_TO)
        End If
        If KEKEKJAG00_C.pUSER_CD.Length > 0 Then
            SqlParamC.fncSetParam("USER_CD", True, KEKEKJAG00_C.pUSER_CD)
        End If
        '2011.11.15 ADD H.Uema
        If KEKEKJAG00_C.pKMCD.Length > 0 Then
            SqlParamC.fncSetParam("KMCD", True, KEKEKJAG00_C.pKMCD)
        End If

    End Sub
End Class
