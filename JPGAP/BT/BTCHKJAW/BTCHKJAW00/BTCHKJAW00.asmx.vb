'***********************************************
' ���M�ς�FAX�̃`�F�b�N�iFAXactivlog VS ����FAX�V�X�e��Log�j 2015/09/14 add
' ID:BTCHKJAW00
'***********************************************
' �ύX����


Option Explicit On
Option Strict On

Imports Common
Imports Common.DB

Imports System.Web.Services
Imports System.Configuration
Imports System.Text
Imports System.IO
Imports System.Diagnostics

'Imports java.util.zip 'vjslib.dll�ւ̎Q�Ɛݒ肪�K�v�ł� 
<System.Web.Services.WebService(Namespace:="http://tempuri.org/JPGAP.BTCHKJAW00/BTCHKJAW00")> _
Public Class BTCHKJAW00
    Inherits System.Web.Services.WebService

#Region " Web �T�[�r�X �f�U�C�i�Ő������ꂽ�R�[�h "

    Public Sub New()
        MyBase.New()

        '���̌Ăяo���� Web �T�[�r�X �f�U�C�i�ŕK�v�ł��B
        InitializeComponent()

        ' InitializeComponent() �Ăяo���̌�ɓƎ��̏������R�[�h��ǉ����Ă��������B

    End Sub

    'Web �T�[�r�X �f�U�C�i�ŕK�v�ł��B
    Private components As System.ComponentModel.IContainer

    '���� : �ȉ��̃v���V�[�W���́AWeb �T�[�r�X �f�U�C�i�ŕK�v�ł��B
    'Web �T�[�r�X �f�U�C�i���g���ĕύX���邱�Ƃ��ł��܂��B  
    '�R�[�h �G�f�B�^�ɂ��ύX�͍s��Ȃ��ł��������B
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        'CODEGEN: ���̃v���V�[�W���� Web �T�[�r�X �f�U�C�i�ŕK�v�ł��B
        '�R�[�h �G�f�B�^�ɂ��ύX�͍s��Ȃ��ł��������B
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

#End Region

    '�v���O�����h�c
    Dim strPGID As String

    Const strFAXKBN As String = "1"  'FAX���M
    Const strMAILKBN As String = "2" 'Ұّ��M
    Const strBoth As String = "3"    'FAX,Ұٗ���

    '2013/09/25 T.Watabe add
    '���O�o�͂Ɏg�p
    Dim strEXEC_YMD As String
    Dim strEXEC_TIME As String
    Dim strGUID As String
    Dim intSEQNO As Integer


    '******************************************************************************
    '*�@�T�@�v�F�o�^
    '*�@���@�l�F
    '******************************************************************************
    <WebMethod()> Public Function mGetListData(ByVal plist As ArrayList) As String
        Dim cdb As New CDB
        Dim strRec As String = ""
        Dim strbuf As String()

        For Each strbuf In plist





        Next

        strRec = mInser()





        Return strRec
    End Function


    Private Function mInser() As String
        Dim strRec As String = ""




        Return strRec
    End Function

    '******************************************************************************
    '*�@�T�@�v�F�Ď��Z���^�[�̑��݃`�F�b�N
    '*�@���@�l�F
    '******************************************************************************
    <WebMethod()> Public Function mChkKans( _
                                        ByVal pstrKANSI_CD As String, _
                                        ByRef pstrKANSI_NAME As String, _
                                        ByRef pstrKANSI_KANA As String, _
                                        ByRef pstrTEL As String, _
                                        ByRef pstrKINKYU_TEL As String, _
                                        ByRef pstrPOST_NO As String, _
                                        ByRef pstrADDRESS1 As String, _
                                        ByRef pstrADDRESS2 As String, _
                                        ByRef pstrBIKOU As String) As String
        '--------------------------------------------------
        Dim cdb As New CDB
        Dim strSQL As New StringBuilder("")
        Dim ds As New DataSet
        Dim dr As DataRow
        Dim strRec As String

        strRec = "OK"

        '---------------------------------------------
        '�v�[���̍ŏ��l�ݒ�
        '---------------------------------------------
        cdb.pConnectPoolSize = 1

        '--------------------------------------------------
        '�ڑ�OPEN
        Try
            cdb.mOpen()
        Catch ex As Exception
            Return ex.ToString
        Finally

        End Try

        '--------------------------------------------------
        Try
            '�f�[�^��SELECT
            strSQL = New StringBuilder("")
            'SQL�쐬�J�n
            strSQL.Append("SELECT ")
            strSQL.Append("    KANSI_NAME, ")
            strSQL.Append("    KANSI_KANA, ")
            strSQL.Append("    TEL, ")
            strSQL.Append("    KINKYU_TEL, ")
            strSQL.Append("    POST_NO, ")
            strSQL.Append("    ADDRESS1, ")
            strSQL.Append("    ADDRESS2, ")
            strSQL.Append("    BIKOU ")
            strSQL.Append("FROM  KANSIMAS ")
            strSQL.Append("WHERE KANSI_CD = :KANSI_CD ")
            '//�p�����[�^�Z�b�g
            cdb.pSQLParamStr("KANSI_CD") = pstrKANSI_CD
            '//SQL�Z�b�g
            cdb.pSQL = strSQL.ToString
            '//SQL���s
            cdb.mExecQuery()
            '//�f�[�^�Z�b�g�Ɋi�[
            ds = cdb.pResult
            '//�f�[�^�����݂��Ȃ��ꍇ
            If ds.Tables(0).Rows.Count = 0 Then
                '//�f�[�^��0���ł��邱�Ƃ������������Ԃ�
                Return "DATA0"
            End If
            '//�f�[�^���[�Ƀf�[�^���i�[
            dr = ds.Tables(0).Rows(0)
            '//�f�[�^�̎擾
            pstrKANSI_NAME = Convert.ToString(dr.Item("KANSI_NAME"))
            pstrKANSI_KANA = Convert.ToString(dr.Item("KANSI_KANA"))
            pstrTEL = Convert.ToString(dr.Item("TEL"))
            pstrKINKYU_TEL = Convert.ToString(dr.Item("KINKYU_TEL"))
            pstrPOST_NO = Convert.ToString(dr.Item("POST_NO"))
            pstrADDRESS1 = Convert.ToString(dr.Item("ADDRESS1"))
            pstrADDRESS2 = Convert.ToString(dr.Item("ADDRESS2"))
            pstrBIKOU = Convert.ToString(dr.Item("BIKOU"))

        Catch ex As Exception
            strRec = "ERROR:" & ex.ToString
        Finally
            '�ڑ��N���[�Y
            cdb.mClose()
        End Try

        Return strRec
    End Function

    '******************************************************************************
    '*�@�T�@�v�F�N���C�A���g�}�X�^�̑��݃`�F�b�N
    '*�@���@�l�F
    '*  ��  ���F2015/02/09 T.Watabe add
    '******************************************************************************
    <WebMethod()> Public Function isExistsClientCode( _
                                        ByVal pstrKANSI_CD As String, _
                                        ByRef pstrCLI_CD As String) As String

        '--------------------------------------------------
        Dim cdb As New CDB
        Dim strSQL As New StringBuilder("")
        Dim ds As New DataSet
        Dim dr As DataRow
        Dim strRec As String

        strRec = "OK"

        '---------------------------------------------
        '�v�[���̍ŏ��l�ݒ�
        '---------------------------------------------
        cdb.pConnectPoolSize = 1

        '--------------------------------------------------
        '�ڑ�OPEN
        Try
            cdb.mOpen()
        Catch ex As Exception
            Return ex.ToString
        Finally

        End Try

        '--------------------------------------------------
        Try
            '�f�[�^��SELECT
            strSQL = New StringBuilder("")
            'SQL�쐬�J�n
            strSQL.Append("SELECT * ")
            strSQL.Append("FROM  CLIMAS ")
            strSQL.Append("WHERE KANSI_CODE = :KANSI_CODE ")
            strSQL.Append("AND CLI_CD = :CLI_CD ")
            '//�p�����[�^�Z�b�g
            cdb.pSQLParamStr("KANSI_CODE") = pstrKANSI_CD
            cdb.pSQLParamStr("CLI_CD") = pstrCLI_CD
            '//SQL�Z�b�g
            cdb.pSQL = strSQL.ToString
            '//SQL���s
            cdb.mExecQuery()
            '//�f�[�^�Z�b�g�Ɋi�[
            ds = cdb.pResult
            '//�f�[�^�����݂��Ȃ��ꍇ
            If ds.Tables(0).Rows.Count = 0 Then
                '//�f�[�^��0���ł��邱�Ƃ������������Ԃ�
                Return "DATA0"
            Else
                strRec = "OK"
            End If

        Catch ex As Exception
            strRec = "ERROR:" & ex.ToString
        Finally
            '�ڑ��N���[�Y
            cdb.mClose()
        End Try

        Return strRec
    End Function

    ' 2010/09/14 T.Watabe add ��PG(BTFAXJAE00)������Q�Ƃł���悤��ҿ��ނ�ǉ�
    '                           �������mExcel,�V�����mExcel2���Ăяo��
    '******************************************************************************
    '*�@�T�@�v�F�Ď��Z���^�[�Ή����e���ׁi�e�`�w�j�̏o��
    '*�@���@�l�F
    '******************************************************************************
    <WebMethod()> Public Function mExcel( _
                                        ByVal pstrKANSI_CODE As String, _
                                        ByVal pstrSESSION As String, _
                                        ByVal pstrTAISYOUBI As String, _
                                        ByVal pstrKURACD_F As String, _
                                        ByVal pstrKURACD_T As String, _
                                        ByVal pstrCreateFilePath As String, _
                                        ByVal pstrSEND_JALP_NAME As String, _
                                        ByVal pstrSEND_CENT_NAME As String _
                                       ) As String

        Return mExcel3(pstrKANSI_CODE, _
                        pstrSESSION, _
                        pstrTAISYOUBI, _
                        pstrKURACD_F, _
                        pstrKURACD_T, _
                        "",
                        "",
                        "",
                        pstrCreateFilePath, _
                        pstrSEND_JALP_NAME, _
                        pstrSEND_CENT_NAME, _
                        "1", _
                        0)
        'pstrSEND_KBN ���w���1:�̔����Ƃ���B
    End Function
    ' 2011/05/19 T.Watabe add 
    '******************************************************************************
    '*�@�T�@�v�F�Ď��Z���^�[�Ή����e���ׁi�e�`�w�j�̏o��
    '*�@���@�l�F
    '******************************************************************************
    ' 2015/01/22 T.Watabe edit
    '<WebMethod()> Public Function mExcel2( _
    '                                    ByVal pstrKANSI_CODE As String, _
    '                                    ByVal pstrSESSION As String, _
    '                                    ByVal pstrTAISYOUBI As String, _
    '                                    ByVal pstrKURACD_F As String, _
    '                                    ByVal pstrKURACD_T As String, _
    '                                    ByVal pstrCreateFilePath As String, _
    '                                    ByVal pstrSEND_JALP_NAME As String, _
    '                                    ByVal pstrSEND_CENT_NAME As String, _
    '                                    ByVal pstrSEND_KBN As String _
    '                                   ) As String
    <WebMethod()> Public Function mExcel2( _
                                        ByVal pstrKANSI_CODE As String, _
                                        ByVal pstrSESSION As String, _
                                        ByVal pstrTAISYOUBI As String, _
                                        ByVal pstrKURACD_F As String, _
                                        ByVal pstrKURACD_T As String, _
                                        ByVal pstrJASCD_F As String, _
                                        ByVal pstrJASCD_T As String, _
                                        ByVal pstrFAXMAIL As String, _
                                        ByVal pstrCreateFilePath As String, _
                                        ByVal pstrSEND_JALP_NAME As String, _
                                        ByVal pstrSEND_CENT_NAME As String, _
                                        ByVal pstrSEND_KBN As String _
                                       ) As String

        Return mExcel3(pstrKANSI_CODE, _
                        pstrSESSION, _
                        pstrTAISYOUBI, _
                        pstrKURACD_F, _
                        pstrKURACD_T, _
                        pstrJASCD_F, _
                        pstrJASCD_T, _
                        pstrFAXMAIL, _
                        pstrCreateFilePath, _
                        pstrSEND_JALP_NAME, _
                        pstrSEND_CENT_NAME, _
                        pstrSEND_KBN, _
                        0)
    End Function
    '******************************************************************************
    '*�@�T�@�v�F�Ď��Z���^�[�Ή����e���ׁi�e�`�w�j�̏o��
    '*�@���@�l�F
    '******************************************************************************
    ' ����
    ' pstrSEND_KBN ���M�敪 1:�̔���(JA�E�x��)/2:�ײ���
    ' pintDebugSQLNo SQL�f�o�b�O�p�� 0:�f�o�b�O�Ȃ�/1�`:�f�o�b�O����
    ' 2015/01/22 T.Watabe edit
    '<WebMethod()> Public Function mExcel3( _
    '                                    ByVal pstrKANSI_CODE As String, _
    '                                    ByVal pstrSESSION As String, _
    '                                    ByVal pstrTAISYOUBI As String, _
    '                                    ByVal pstrKURACD_F As String, _
    '                                    ByVal pstrKURACD_T As String, _
    '                                    ByVal pstrCreateFilePath As String, _
    '                                    ByVal pstrSEND_JALP_NAME As String, _
    '                                    ByVal pstrSEND_CENT_NAME As String, _
    '                                    ByVal pstrSEND_KBN As String, _
    '                                    ByVal pintDebugSQLNo As Integer _
    '                                   ) As String
    <WebMethod()> Public Function mExcel3( _
                                        ByVal pstrKANSI_CODE As String, _
                                        ByVal pstrSESSION As String, _
                                        ByVal pstrTAISYOUBI As String, _
                                        ByVal pstrKURACD_F As String, _
                                        ByVal pstrKURACD_T As String, _
                                        ByVal pstrJASCD_F As String, _
                                        ByVal pstrJASCD_T As String, _
                                        ByVal pstrFAXMAIL As String, _
                                        ByVal pstrCreateFilePath As String, _
                                        ByVal pstrSEND_JALP_NAME As String, _
                                        ByVal pstrSEND_CENT_NAME As String, _
                                        ByVal pstrSEND_KBN As String, _
                                        ByVal pintDebugSQLNo As Integer _
                                       ) As String

        '--------------------------------------------------
        '�����e�`�w�ԍ��ɓ��͂��ꂽ�ԍ����ɂe�`�w���M�E�t�@�C���쐬���s��
        Dim cdb As New CDB
        Dim strSQL As New StringBuilder("")
        Dim ds As New DataSet
        Dim dr As DataRow
        Dim strRec As String
        Dim GUID As String = System.Guid.NewGuid().ToString() ' 2011/06/14 T.Watabe add
        Dim strFAXNO As String = "" ' 2015/01/22 T.Watabe add
        Dim strMAIL As String = "" ' 2015/01/22 T.Watabe add

        strEXEC_YMD = Format(DateTime.Now, "yyyyMMdd")
        strEXEC_TIME = Format(DateTime.Now, "HHmmss")
        strGUID = GUID
        intSEQNO = 0

        ' 2015/01/22 T.Watabe add
        ' FAX�ԍ�orҰٱ��ڽ�̐؂蕪��
        If pstrFAXMAIL.Length <= 0 Then
            '�󕶎������ݒ�
        ElseIf pstrFAXMAIL.IndexOf("@") >= 0 Then
            'Ұٱ��ڽ
            strMAIL = pstrFAXMAIL
        Else
            'FAX�ԍ�
            strFAXNO = pstrFAXMAIL
        End If

        '--------------------------------------------------
        '�v���O�����h�c(�쐬���[�Ɏg�p)
        strPGID = "BTFAXJAX00"
        mlog(pstrSESSION & "\" & pstrKANSI_CODE & "\" & pstrKURACD_F & "\" & pstrKURACD_T, strPGID & ":mExcel3�F1") '2014/04/11 T.Ono add ���O����
        '---------------------------------------------
        '�v�[���̍ŏ��l�ݒ�
        '---------------------------------------------
        cdb.pConnectPoolSize = 1

        '--------------------------------------------------
        '�ڑ�OPEN
        Try
            cdb.mOpen()
        Catch ex As Exception
            Return ex.ToString
        Finally

        End Try

        '--------------------------------------------------
        '�Ώۓ��̌��������̐ݒ�
        '�Ή��ς݂̃f�[�^��
        '�Ή����������V�X�e�����t�̑O�̓��̒��ߓ�����V�X�e�����t�̒��ߓ��܂�

        Dim strTaisyoStDT As String '�J�n�� 2008/10/14 T.Watabe edit
        Dim strTaisyoEdDT As String '�I���� 2008/10/14 T.Watabe edit
        strTaisyoStDT = fncAdd_Date(pstrTAISYOUBI, -1) & ConfigurationSettings.AppSettings("JIDOFAXSIME")
        strTaisyoEdDT = pstrTAISYOUBI & ConfigurationSettings.AppSettings("JIDOFAXSIME")

        Dim strWHERE_TAIOU As New StringBuilder("")
        Dim strWHERE_CLI As New StringBuilder("") '2010/12/21 T.Watabe add
        Dim strWHERE_JAS1 As New StringBuilder("") '2015/01/22 T.Watabe add
        Dim strWHERE_JAS2 As New StringBuilder("") '2015/01/22 T.Watabe add
        Dim strWHERE_FAXMAIL As New StringBuilder("") '2015/01/22 T.Watabe add
        If pstrSEND_KBN = "1" Then '���M�敪 1:�̔���(JA�E�x��)/2:�ײ���
            strWHERE_TAIOU.Append("  AND TAI.FAXKBN = '2' " & vbCrLf)            '//�e�`�w�K�v(JA)
        Else
            strWHERE_TAIOU.Append("  AND TAI.FAXKURAKBN = '2' " & vbCrLf)        '//�e�`�w�K�v(�ײ��ċ������)
        End If
        strWHERE_TAIOU.Append("  AND TAI.TMSKB = '2' " & vbCrLf)             '//�����ς�
        strWHERE_TAIOU.Append("  AND ( " & vbCrLf)
        strWHERE_TAIOU.Append("          (TAI.SYOYMD || TAI.SYOTIME > '" & strTaisyoStDT & "' " & vbCrLf)
        strWHERE_TAIOU.Append("          AND TAI.SYOYMD || TAI.SYOTIME   <='" & strTaisyoEdDT & "') " & vbCrLf)
        strWHERE_TAIOU.Append("      OR  " & vbCrLf)
        strWHERE_TAIOU.Append("          (TAI.SYOKANYMD || TAI.SYOKANTIME > '" & strTaisyoStDT & "' " & vbCrLf)
        strWHERE_TAIOU.Append("          AND TAI.SYOKANYMD || TAI.SYOKANTIME <='" & strTaisyoEdDT & "') " & vbCrLf)
        strWHERE_TAIOU.Append("      ) " & vbCrLf)

        '--- ��2005/09/10 ADD Falcon�� ---
        '�N���C�A���g�R�[�h�͈͎̔w���ǉ�
        If pstrKURACD_F.Length > 0 Then
            strWHERE_TAIOU.Append("  AND TAI.KURACD >= '" & pstrKURACD_F & "' " & vbCrLf)
            strWHERE_CLI.Append("  AND CLI.CLI_CD >= '" & pstrKURACD_F & "' " & vbCrLf) '2010/12/21 T.Watabe add
            strWHERE_JAS1.Append("  AND KURACD >= '" & pstrKURACD_F & "' " & vbCrLf) '2015/02/05 T.Watabe add
            strWHERE_JAS2.Append("  AND H.CLI_CD >= '" & pstrKURACD_F & "' " & vbCrLf) '2015/02/05 T.Watabe add
        End If
        If pstrKURACD_T.Length > 0 Then
            strWHERE_TAIOU.Append("  AND TAI.KURACD <= '" & pstrKURACD_T & "' " & vbCrLf)
            strWHERE_CLI.Append("  AND CLI.CLI_CD <= '" & pstrKURACD_T & "' " & vbCrLf) '2010/12/21 T.Watabe add
            strWHERE_JAS1.Append("  AND KURACD <= '" & pstrKURACD_T & "' " & vbCrLf) '2015/02/05 T.Watabe add
            strWHERE_JAS2.Append("  AND H.CLI_CD <= '" & pstrKURACD_T & "' " & vbCrLf) '2015/02/05 T.Watabe add
        End If

        '2015/01/22 T.Watabe add
        'JA�x��FROM-TO�̏����ǉ�
        If pstrJASCD_F.Length > 0 Or pstrJASCD_T.Length > 0 Then
            strWHERE_TAIOU.Append("  AND TAI.ACBCD >= '" & pstrJASCD_F & "' " & vbCrLf)
            strWHERE_TAIOU.Append("  AND TAI.ACBCD <= '" & pstrJASCD_T & "' " & vbCrLf)
            strWHERE_JAS1.Append("  AND CODE >= '" & pstrJASCD_F & "' " & vbCrLf)
            strWHERE_JAS1.Append("  AND CODE <= '" & pstrJASCD_T & "' " & vbCrLf)
            strWHERE_JAS2.Append("  AND H.HAN_CD >= '" & pstrJASCD_F & "'  " & vbCrLf) '2015/02/05 T.Watabe add
            strWHERE_JAS2.Append("  AND H.HAN_CD <= '" & pstrJASCD_T & "' " & vbCrLf) '2015/02/05 T.Watabe add
        End If

        '�Ď��Z���^�[�R�[�h��ǉ��i��ʂŕK�{�H�Ȃ̂ł����Œǉ��j
        strWHERE_TAIOU.Append("         AND TAI.KANSCD  = '" & pstrKANSI_CODE & "' " & vbCrLf) '2011/05/20 T.Watabe add
        strWHERE_CLI.Append("         AND CLI.KANSI_CODE  = '" & pstrKANSI_CODE & "' " & vbCrLf) '2011/05/20 T.Watabe add

        Dim strWHERE_TAIOU_COPY As New StringBuilder("") '2011/06/14 T.Watabe add
        strWHERE_TAIOU_COPY.Append(strWHERE_TAIOU)
        strWHERE_TAIOU.Append("         AND TAI.GUID  = '" & GUID & "' " & vbCrLf) '2011/06/14 T.Watabe add

        '2015/01/22 T.Watabe add
        'FAX�ԍ�orҰٱ��ڽ�̏����ǉ�(SQL�̍Ō�Ńt�B���^�[���|����)
        If strMAIL.Length > 0 Then strWHERE_FAXMAIL.Append("  AND AUTO_MAIL = '" & strMAIL & "' " & vbCrLf)
        If strFAXNO.Length > 0 Then strWHERE_FAXMAIL.Append("  AND REPLACE(AUTO_FAX,'-','') = REPLACE('" & strFAXNO & "','-','') " & vbCrLf)

        Try
            mlog(pstrSESSION & "\" & pstrKANSI_CODE & "\" & pstrKURACD_F & "\" & pstrKURACD_T, strPGID & ":mExcel3�F2") '2014/04/11 T.Ono add ���O����
            '2011/06/14 T.Watabe add
            '--------------------------------
            ' D20�̎��O�R�s�[
            '--------------------------------
            strRec = mCopyD20Taiou(cdb, GUID, strWHERE_TAIOU_COPY.ToString)
            If strRec <> "OK" Then
                cdb.mClose() '�ڑ��N���[�Y
                Return strRec
            End If
        Catch ex As Exception
            mlog(pstrSESSION & "\" & pstrKANSI_CODE & "\" & pstrKURACD_F & "\" & pstrKURACD_T, _
     "[" & ex.ToString & "]" & Environment.StackTrace)

            strRec = "ERROR:" & ex.ToString
            cdb.mClose() '�ڑ��N���[�Y
            Return strRec
        Finally
        End Try

        '--------------------------------------------------
        Try
            mlog(pstrSESSION & "\" & pstrKANSI_CODE & "\" & pstrKURACD_F & "\" & pstrKURACD_T, strPGID & ":mExcel3�F3 ���M�敪�F" & pstrSEND_KBN) '2014/04/11 T.Ono add ���O����
            '�f�[�^��SELECT
            strSQL = New StringBuilder("")
            'SQL�쐬�J�n
            If True Then
                If pstrSEND_KBN = "1" Then '���M�敪 1:�̔���(JA�E�x��)/2:�ײ���

                    '1:�̔���(JA�E�x��)
                    strSQL.Append("WITH TANTO2 AS ( " & vbCrLf)
                    strSQL.Append("    SELECT  " & vbCrLf)
                    strSQL.Append("          A.KURACD," & vbCrLf)
                    strSQL.Append("          SUBSTR(A.KURACD,1,3) AS JA_CD," & vbCrLf)
                    strSQL.Append("          A.CODE," & vbCrLf)
                    strSQL.Append("          A.USER_CD_FROM," & vbCrLf)
                    strSQL.Append("          A.USER_CD_TO," & vbCrLf)
                    strSQL.Append("          A.AUTO_MAIL," & vbCrLf)
                    strSQL.Append("          A.AUTO_KBN," & vbCrLf)
                    strSQL.Append("          A.AUTO_FAXNO," & vbCrLf)
                    strSQL.Append("          A.AUTO_ZERO_FLG" & vbCrLf)
                    strSQL.Append("    FROM  " & vbCrLf)
                    strSQL.Append("          CLIMAS CLI, " & vbCrLf)
                    strSQL.Append("          M05_TANTO2 A " & vbCrLf)
                    strSQL.Append("    WHERE " & vbCrLf)
                    strSQL.Append("          A.KBN = '3' " & vbCrLf)
                    strSQL.Append("          AND A.AUTO_KBN IN ('" & strFAXKBN & "', '" & strMAILKBN & "', '" & strBoth & "') " & vbCrLf)
                    strSQL.Append("          AND CLI.CLI_CD      = A.KURACD " & vbCrLf)
                    strSQL.Append(strWHERE_CLI.ToString & vbCrLf)
                    'strSQL.Append(strWHERE_JAS.ToString & vbCrLf) '2015/01/22 T.Watabe add
                    strSQL.Append(")," & vbCrLf)
                    strSQL.Append("TANTO AS ( " & vbCrLf)
                    strSQL.Append("    SELECT  " & vbCrLf)
                    strSQL.Append("          A.KURACD," & vbCrLf)
                    strSQL.Append("          A.CODE," & vbCrLf)
                    strSQL.Append("          A.AUTO_MAIL," & vbCrLf)
                    strSQL.Append("          A.AUTO_KBN," & vbCrLf)
                    strSQL.Append("          A.AUTO_FAXNO," & vbCrLf)
                    strSQL.Append("          A.AUTO_ZERO_FLG" & vbCrLf)
                    strSQL.Append("    FROM  " & vbCrLf)
                    strSQL.Append("          CLIMAS CLI, " & vbCrLf)
                    strSQL.Append("          M05_TANTO A " & vbCrLf)
                    strSQL.Append("    WHERE " & vbCrLf)
                    strSQL.Append("          A.KBN = '3' " & vbCrLf)
                    strSQL.Append("          AND A.AUTO_KBN IN ('" & strFAXKBN & "', '" & strMAILKBN & "', '" & strBoth & "') " & vbCrLf)
                    strSQL.Append("          AND CLI.CLI_CD      = A.KURACD " & vbCrLf)
                    strSQL.Append("          AND A.CODE <> 'XXXX' " & vbCrLf)
                    strSQL.Append(strWHERE_CLI.ToString & vbCrLf)
                    'strSQL.Append(strWHERE_JAS.ToString & vbCrLf) '2015/01/22 T.Watabe add
                    strSQL.Append(")," & vbCrLf)
                    strSQL.Append("T AS (" & vbCrLf)
                    strSQL.Append("    SELECT" & vbCrLf)
                    strSQL.Append("        DISTINCT" & vbCrLf)
                    strSQL.Append("        TAI.KURACD," & vbCrLf)
                    strSQL.Append("        TAI.JACD," & vbCrLf) ' 2013/09/09 T.Watabe add
                    strSQL.Append("        TAI.ACBCD," & vbCrLf)
                    strSQL.Append("        TAI.USER_CD" & vbCrLf)
                    strSQL.Append("    FROM D20_TAIOU_COPY TAI " & vbCrLf)
                    strSQL.Append("    WHERE 1=1 " & vbCrLf)
                    strSQL.Append(strWHERE_TAIOU.ToString)
                    strSQL.Append(") " & vbCrLf)
                    strSQL.Append("/* ���C���� */ " & vbCrLf) ' 2015/01/22 T.Watabe add
                    strSQL.Append("SELECT  " & vbCrLf) ' 2015/01/22 T.Watabe add
                    strSQL.Append("    AUTO_KUBUN," & vbCrLf) ' 2015/01/22 T.Watabe add
                    strSQL.Append("    AUTO_FAX_SORT," & vbCrLf) ' 2015/01/22 T.Watabe add
                    strSQL.Append("    AUTO_FAX," & vbCrLf) ' 2015/01/22 T.Watabe add
                    strSQL.Append("    AUTO_MAIL," & vbCrLf) ' 2015/01/22 T.Watabe add
                    strSQL.Append("    CNT " & vbCrLf) ' 2015/01/22 T.Watabe add
                    strSQL.Append("FROM ( " & vbCrLf) ' 2015/01/22 T.Watabe add
                    strSQL.Append("/* fax�� */ " & vbCrLf)
                    '' 0���񍐂���f�[�^---------------------------
                    strSQL.Append("    SELECT  " & vbCrLf)
                    strSQL.Append("          '1' AS AUTO_KUBUN," & vbCrLf)
                    strSQL.Append("          DECODE(LENGTH(AUTO_FAXNO),1,2,1) AS AUTO_FAX_SORT," & vbCrLf)
                    strSQL.Append(ReplaceHyphen("AUTO_FAXNO") & " AS AUTO_FAX," & vbCrLf)
                    strSQL.Append("          NULL AS AUTO_MAIL," & vbCrLf)
                    strSQL.Append("          0 AS CNT " & vbCrLf)
                    strSQL.Append("    FROM  " & vbCrLf)
                    strSQL.Append("          TANTO2 " & vbCrLf)
                    strSQL.Append("    WHERE " & vbCrLf)
                    strSQL.Append("              AUTO_KBN IN ('" & strFAXKBN & "', '" & strBoth & "') " & vbCrLf)
                    strSQL.Append("          AND AUTO_FAXNO IS NOT NULL " & vbCrLf)
                    strSQL.Append("          AND AUTO_ZERO_FLG ='1' " & vbCrLf)
                    strSQL.Append(strWHERE_JAS1.ToString & vbCrLf) '2015/01/22 T.Watabe add
                    strSQL.Append("    UNION " & vbCrLf)
                    ' 2015/02/05 T.Watabe edit
                    'strSQL.Append("    SELECT  " & vbCrLf)
                    'strSQL.Append("          '1' AS AUTO_KUBUN," & vbCrLf)
                    'strSQL.Append("          DECODE(LENGTH(TANTO.AUTO_FAXNO),1,2,1) AS AUTO_FAX_SORT," & vbCrLf)
                    'strSQL.Append(ReplaceHyphen("TANTO.AUTO_FAXNO") & " AS AUTO_FAX," & vbCrLf)
                    'strSQL.Append("          NULL AS AUTO_MAIL," & vbCrLf)
                    'strSQL.Append("          0 AS CNT " & vbCrLf)
                    'strSQL.Append("    FROM  " & vbCrLf)
                    'strSQL.Append("          TANTO " & vbCrLf)
                    'strSQL.Append("    WHERE " & vbCrLf)
                    'strSQL.Append("              TANTO.AUTO_KBN IN ('" & strFAXKBN & "', '" & strBoth & "') " & vbCrLf)
                    'strSQL.Append("          AND TANTO.AUTO_FAXNO IS NOT NULL " & vbCrLf)
                    'strSQL.Append("          AND TANTO.AUTO_ZERO_FLG ='1' " & vbCrLf)
                    'strSQL.Append(strWHERE_JAS2.ToString & vbCrLf) '2015/01/22 T.Watabe add
                    strSQL.Append("    SELECT  " & vbCrLf)
                    strSQL.Append("          '1' AS AUTO_KUBUN," & vbCrLf)
                    strSQL.Append("        DECODE(LENGTH(AUTO_FAXNO),1,2,1) AS AUTO_FAX_SORT," & vbCrLf)
                    strSQL.Append(ReplaceHyphen("AUTO_FAXNO") & " AS AUTO_FAX," & vbCrLf)
                    strSQL.Append("        NULL AS AUTO_MAIL," & vbCrLf)
                    strSQL.Append("        0 AS CNT " & vbCrLf)
                    strSQL.Append("    FROM ( " & vbCrLf)
                    strSQL.Append("        SELECT DISTINCT" & vbCrLf)
                    strSQL.Append("            DECODE(S.AUTO_FAXNO, " & vbCrLf)
                    strSQL.Append("                NULL, " & vbCrLf)
                    strSQL.Append("                J.AUTO_FAXNO," & vbCrLf) '/* JA�x��FAX�Ȃ���JAFAX���聕�[�������聨���� */
                    strSQL.Append("                DECODE(S.AUTO_ZERO_FLG, '1', S.AUTO_FAXNO, NULL) " & vbCrLf) '/* JA�x��FAX���聕�[�������聨����^�Ȃ������炸 */
                    strSQL.Append("            ) AS AUTO_FAXNO " & vbCrLf)
                    strSQL.Append("        FROM HN2MAS H " & vbCrLf)
                    strSQL.Append("            LEFT JOIN TANTO S " & vbCrLf)
                    strSQL.Append("                ON H.CLI_CD = S.KURACD AND H.HAN_CD = S.CODE AND S.AUTO_KBN IN ('" & strFAXKBN & "', '" & strBoth & "') AND S.AUTO_FAXNO IS NOT NULL " & vbCrLf) '2015/02/27 T.Watabe edit
                    strSQL.Append("            LEFT JOIN TANTO J " & vbCrLf)
                    strSQL.Append("                ON H.CLI_CD = J.KURACD AND H.JA_CD  = J.CODE AND J.AUTO_KBN IN ('" & strFAXKBN & "', '" & strBoth & "') AND J.AUTO_FAXNO IS NOT NULL AND J.AUTO_ZERO_FLG = '1' " & vbCrLf) '2015/02/27 T.Watabe edit
                    strSQL.Append("        WHERE 1=1 " & vbCrLf)
                    strSQL.Append(strWHERE_JAS2.ToString & vbCrLf) '2015/01/22 T.Watabe add
                    strSQL.Append("    ) " & vbCrLf)
                    strSQL.Append("    WHERE " & vbCrLf)
                    strSQL.Append("        AUTO_FAXNO IS NOT NULL " & vbCrLf)
                    '' �Ή��f�[�^����---------------------------
                    strSQL.Append("    UNION " & vbCrLf)
                    strSQL.Append("    SELECT  " & vbCrLf)
                    strSQL.Append("          '1' AS AUTO_KUBUN," & vbCrLf)
                    strSQL.Append("          DECODE(LENGTH(TANTO2.AUTO_FAXNO),1,2,1) AS AUTO_FAX_SORT," & vbCrLf)
                    strSQL.Append(ReplaceHyphen("TANTO2.AUTO_FAXNO") & " AS AUTO_FAX," & vbCrLf)
                    strSQL.Append("          NULL AS AUTO_MAIL," & vbCrLf)
                    strSQL.Append("          0 AS CNT " & vbCrLf)
                    strSQL.Append("    FROM  " & vbCrLf)
                    strSQL.Append("          TANTO2, " & vbCrLf)
                    strSQL.Append("          T  " & vbCrLf)
                    strSQL.Append("    WHERE " & vbCrLf)
                    strSQL.Append("              TANTO2.KURACD = T.KURACD " & vbCrLf)
                    strSQL.Append("          AND TANTO2.CODE = T.ACBCD " & vbCrLf)
                    strSQL.Append("          AND TANTO2.AUTO_KBN IN ('" & strFAXKBN & "', '" & strBoth & "') " & vbCrLf)
                    strSQL.Append("          AND TANTO2.AUTO_FAXNO IS NOT NULL " & vbCrLf)
                    strSQL.Append("          AND TANTO2.USER_CD_FROM = T.USER_CD AND TANTO2.USER_CD_TO IS NULL " & vbCrLf)
                    strSQL.Append("    UNION " & vbCrLf)
                    strSQL.Append("    SELECT  " & vbCrLf)
                    strSQL.Append("          '1' AS AUTO_KUBUN," & vbCrLf)
                    strSQL.Append("          DECODE(LENGTH(TANTO2.AUTO_FAXNO),1,2,1) AS AUTO_FAX_SORT," & vbCrLf)
                    strSQL.Append(ReplaceHyphen("TANTO2.AUTO_FAXNO") & " AS AUTO_FAX," & vbCrLf)
                    strSQL.Append("          NULL AS AUTO_MAIL," & vbCrLf)
                    strSQL.Append("          0 AS CNT " & vbCrLf)
                    strSQL.Append("    FROM  " & vbCrLf)
                    strSQL.Append("          TANTO2 , " & vbCrLf)
                    strSQL.Append("          T  " & vbCrLf)
                    strSQL.Append("    WHERE " & vbCrLf)
                    strSQL.Append("              TANTO2.KURACD = T.KURACD " & vbCrLf)
                    strSQL.Append("          AND TANTO2.CODE = T.ACBCD " & vbCrLf)
                    strSQL.Append("          AND TANTO2.AUTO_KBN IN ('" & strFAXKBN & "', '" & strBoth & "') " & vbCrLf)
                    strSQL.Append("          AND TANTO2.AUTO_FAXNO IS NOT NULL " & vbCrLf)
                    strSQL.Append("          AND T.USER_CD BETWEEN TANTO2.USER_CD_FROM AND TANTO2.USER_CD_TO AND TANTO2.USER_CD_TO IS NOT NULL " & vbCrLf)
                    strSQL.Append("          AND NOT EXISTS(  " & vbCrLf)
                    strSQL.Append("             SELECT 'X' FROM TANTO2 C " & vbCrLf)
                    strSQL.Append("             WHERE " & vbCrLf)
                    strSQL.Append("                C.KURACD = T.KURACD AND " & vbCrLf)
                    strSQL.Append("                C.CODE = T.ACBCD AND  " & vbCrLf)
                    strSQL.Append("                C.AUTO_KBN IN ('" & strFAXKBN & "', '" & strBoth & "') AND " & vbCrLf)
                    strSQL.Append("                C.USER_CD_FROM = T.USER_CD AND C.USER_CD_TO IS NULL " & vbCrLf)
                    strSQL.Append("          )   " & vbCrLf)
                    strSQL.Append("    UNION " & vbCrLf)
                    strSQL.Append("    SELECT  " & vbCrLf)
                    strSQL.Append("          '1' AS AUTO_KUBUN," & vbCrLf)
                    strSQL.Append("          DECODE(LENGTH(TANTO.AUTO_FAXNO),1,2,1) AS AUTO_FAX_SORT," & vbCrLf)
                    strSQL.Append(ReplaceHyphen("TANTO.AUTO_FAXNO") & " AS AUTO_FAX," & vbCrLf)
                    strSQL.Append("          NULL AS AUTO_MAIL," & vbCrLf)
                    strSQL.Append("          0 AS CNT " & vbCrLf)
                    strSQL.Append("    FROM  " & vbCrLf)
                    strSQL.Append("          TANTO, " & vbCrLf)
                    strSQL.Append("          T  " & vbCrLf)
                    strSQL.Append("    WHERE " & vbCrLf)
                    strSQL.Append("              TANTO.KURACD = T.KURACD " & vbCrLf)
                    strSQL.Append("          AND TANTO.CODE = T.ACBCD " & vbCrLf)
                    strSQL.Append("          AND TANTO.AUTO_KBN IN ('" & strFAXKBN & "', '" & strBoth & "') " & vbCrLf)
                    strSQL.Append("          AND TANTO.AUTO_FAXNO IS NOT NULL " & vbCrLf)
                    strSQL.Append("          AND NOT EXISTS(  " & vbCrLf)
                    strSQL.Append("             SELECT 'X' FROM TANTO2 C " & vbCrLf)
                    strSQL.Append("             WHERE " & vbCrLf)
                    strSQL.Append("                C.KURACD = T.KURACD AND " & vbCrLf)
                    strSQL.Append("                C.CODE = T.ACBCD AND  " & vbCrLf)
                    strSQL.Append("                C.AUTO_KBN IN ('" & strFAXKBN & "', '" & strBoth & "') AND " & vbCrLf)
                    strSQL.Append("                C.AUTO_FAXNO IS NOT NULL AND " & vbCrLf)
                    strSQL.Append("                C.USER_CD_FROM = T.USER_CD AND C.USER_CD_TO IS NULL " & vbCrLf)
                    strSQL.Append("          )   " & vbCrLf)
                    strSQL.Append("          AND NOT EXISTS(  " & vbCrLf)
                    strSQL.Append("             SELECT 'X' FROM TANTO2 C " & vbCrLf)
                    strSQL.Append("             WHERE " & vbCrLf)
                    strSQL.Append("                C.KURACD = T.KURACD AND " & vbCrLf)
                    strSQL.Append("                C.CODE = T.ACBCD AND  " & vbCrLf)
                    strSQL.Append("                C.AUTO_KBN IN ('" & strFAXKBN & "', '" & strBoth & "') AND " & vbCrLf)
                    strSQL.Append("                C.AUTO_FAXNO IS NOT NULL AND " & vbCrLf)
                    strSQL.Append("                T.USER_CD BETWEEN C.USER_CD_FROM AND C.USER_CD_TO AND C.USER_CD_TO IS NOT NULL " & vbCrLf)
                    strSQL.Append("          )   " & vbCrLf)
                    strSQL.Append("    UNION " & vbCrLf)
                    strSQL.Append("    SELECT  " & vbCrLf)
                    strSQL.Append("          '1' AS AUTO_KUBUN," & vbCrLf)
                    strSQL.Append("          DECODE(LENGTH(TANTO.AUTO_FAXNO),1,2,1) AS AUTO_FAX_SORT," & vbCrLf)
                    strSQL.Append(ReplaceHyphen("TANTO.AUTO_FAXNO") & " AS AUTO_FAX," & vbCrLf)
                    strSQL.Append("          NULL AS AUTO_MAIL," & vbCrLf)
                    strSQL.Append("          0 AS CNT " & vbCrLf)
                    strSQL.Append("    FROM  " & vbCrLf)
                    strSQL.Append("          TANTO, " & vbCrLf)
                    strSQL.Append("          T  " & vbCrLf)
                    strSQL.Append("    WHERE " & vbCrLf)
                    strSQL.Append("              TANTO.KURACD = T.KURACD " & vbCrLf)
                    'strSQL.Append("          AND TANTO.CODE = substr(T.ACBCD,1,3) " & vbCrLf) 2013/09/09 T.Watabe edit
                    strSQL.Append("          AND TANTO.CODE = T.JACD " & vbCrLf)
                    strSQL.Append("          AND TANTO.AUTO_KBN IN ('" & strFAXKBN & "', '" & strBoth & "') " & vbCrLf)
                    strSQL.Append("          AND TANTO.AUTO_FAXNO IS NOT NULL " & vbCrLf)
                    strSQL.Append("          AND NOT EXISTS(  " & vbCrLf)
                    strSQL.Append("             SELECT 'X' FROM TANTO C " & vbCrLf)
                    strSQL.Append("             WHERE " & vbCrLf)
                    strSQL.Append("                C.KURACD = T.KURACD AND " & vbCrLf)
                    strSQL.Append("                C.CODE = T.ACBCD AND  " & vbCrLf)
                    strSQL.Append("                C.AUTO_KBN IN ('" & strFAXKBN & "', '" & strBoth & "') AND " & vbCrLf)
                    strSQL.Append("                C.AUTO_FAXNO IS NOT NULL " & vbCrLf)
                    strSQL.Append("          )   " & vbCrLf)
                    strSQL.Append("          AND NOT EXISTS(  " & vbCrLf)
                    strSQL.Append("             SELECT 'X' FROM TANTO2 C " & vbCrLf)
                    strSQL.Append("             WHERE " & vbCrLf)
                    strSQL.Append("                C.KURACD = T.KURACD AND " & vbCrLf)
                    strSQL.Append("                C.CODE = T.ACBCD AND  " & vbCrLf)
                    strSQL.Append("                C.AUTO_KBN IN ('" & strFAXKBN & "', '" & strBoth & "') AND " & vbCrLf)
                    strSQL.Append("                C.AUTO_FAXNO IS NOT NULL AND " & vbCrLf)
                    strSQL.Append("                C.USER_CD_FROM = T.USER_CD AND C.USER_CD_TO IS NULL " & vbCrLf)
                    strSQL.Append("          )   " & vbCrLf)
                    strSQL.Append("          AND NOT EXISTS(  " & vbCrLf)
                    strSQL.Append("             SELECT 'X' FROM TANTO2 C " & vbCrLf)
                    strSQL.Append("             WHERE " & vbCrLf)
                    strSQL.Append("                C.KURACD = T.KURACD AND " & vbCrLf)
                    strSQL.Append("                C.CODE = T.ACBCD AND  " & vbCrLf)
                    strSQL.Append("                C.AUTO_KBN IN ('" & strFAXKBN & "', '" & strBoth & "') AND " & vbCrLf)
                    strSQL.Append("                C.AUTO_FAXNO IS NOT NULL AND " & vbCrLf)
                    strSQL.Append("                T.USER_CD BETWEEN C.USER_CD_FROM AND C.USER_CD_TO AND C.USER_CD_TO IS NOT NULL " & vbCrLf)
                    strSQL.Append("          )   " & vbCrLf)
                    strSQL.Append(" UNION   " & vbCrLf)
                    strSQL.Append("/* MAIL�� */ " & vbCrLf)
                    '' 0���񍐂���f�[�^---------------------------
                    strSQL.Append("    SELECT  " & vbCrLf)
                    strSQL.Append("          '2' AS AUTO_KUBUN," & vbCrLf)
                    strSQL.Append("          NULL AS AUTO_FAX_SORT," & vbCrLf)
                    strSQL.Append("          NULL AS AUTO_FAX," & vbCrLf)
                    strSQL.Append("          AUTO_MAIL AS AUTO_MAIL," & vbCrLf)
                    strSQL.Append("          0 AS CNT " & vbCrLf)
                    strSQL.Append("    FROM  " & vbCrLf)
                    strSQL.Append("          TANTO2 " & vbCrLf)
                    strSQL.Append("    WHERE " & vbCrLf)
                    strSQL.Append("              AUTO_KBN IN ('" & strMAILKBN & "', '" & strBoth & "') " & vbCrLf)
                    strSQL.Append("          AND AUTO_MAIL IS NOT NULL " & vbCrLf)
                    strSQL.Append("          AND AUTO_ZERO_FLG ='1' " & vbCrLf)
                    strSQL.Append(strWHERE_JAS1.ToString & vbCrLf) '2015/01/22 T.Watabe add
                    strSQL.Append("    UNION " & vbCrLf)
                    ' 2015/02/05 T.Watabe edit
                    'strSQL.Append("    SELECT  " & vbCrLf)
                    'strSQL.Append("          '2' AS AUTO_KUBUN," & vbCrLf)
                    'strSQL.Append("          NULL AS AUTO_FAX_SORT," & vbCrLf)
                    'strSQL.Append("          NULL AS AUTO_FAX," & vbCrLf)
                    'strSQL.Append("          TANTO.AUTO_MAIL AS AUTO_MAIL," & vbCrLf)
                    'strSQL.Append("          0 AS CNT " & vbCrLf)
                    'strSQL.Append("    FROM  " & vbCrLf)
                    'strSQL.Append("          TANTO " & vbCrLf)
                    'strSQL.Append("    WHERE " & vbCrLf)
                    'strSQL.Append("              TANTO.AUTO_KBN IN ('" & strMAILKBN & "', '" & strBoth & "') " & vbCrLf)
                    'strSQL.Append("          AND TANTO.AUTO_MAIL IS NOT NULL " & vbCrLf)
                    'strSQL.Append("          AND TANTO.AUTO_ZERO_FLG ='1' " & vbCrLf)
                    'strSQL.Append(strWHERE_JAS2.ToString & vbCrLf) '2015/01/22 T.Watabe add
                    strSQL.Append("    SELECT " & vbCrLf)
                    strSQL.Append("        '2' AS AUTO_KUBUN," & vbCrLf)
                    strSQL.Append("        NULL AS AUTO_FAX_SORT," & vbCrLf)
                    strSQL.Append("        NULL AS AUTO_FAX," & vbCrLf)
                    strSQL.Append("        AUTO_MAIL," & vbCrLf)
                    strSQL.Append("        0 AS CNT " & vbCrLf)
                    strSQL.Append("    FROM ( " & vbCrLf)
                    strSQL.Append("        SELECT DISTINCT" & vbCrLf)
                    strSQL.Append("            DECODE(S.AUTO_MAIL, " & vbCrLf)
                    strSQL.Append("                NULL, " & vbCrLf)
                    strSQL.Append("                J.AUTO_MAIL," & vbCrLf) '/* JA�x��mail�Ȃ���JAmail���聕�[�������聨���� */
                    strSQL.Append("                DECODE(S.AUTO_ZERO_FLG, '1', S.AUTO_MAIL, NULL) " & vbCrLf) '/* JA�x��mail���聕�[�������聨����^�Ȃ������炸 */
                    strSQL.Append("            ) AS AUTO_MAIL " & vbCrLf)
                    strSQL.Append("        FROM HN2MAS H " & vbCrLf)
                    ' 2015/03/20 T.Ono mod 2014���P�J�� No16 START
                    'strSQL.Append("            LEFT JOIN M05_TANTO S " & vbCrLf)
                    'strSQL.Append("                ON H.CLI_CD = S.KURACD AND H.HAN_CD = S.CODE AND S.KBN = '3' AND S.AUTO_KBN IN ('" & strMAILKBN & "', '" & strBoth & "') AND S.AUTO_MAIL IS NOT NULL " & vbCrLf)
                    'strSQL.Append("            LEFT JOIN M05_TANTO J " & vbCrLf)
                    'strSQL.Append("                ON H.CLI_CD = J.KURACD AND H.JA_CD  = J.CODE AND J.KBN = '3' AND J.AUTO_KBN IN ('" & strMAILKBN & "', '" & strBoth & "') AND J.AUTO_MAIL IS NOT NULL AND J.AUTO_ZERO_FLG = '1' " & vbCrLf)
                    strSQL.Append("            LEFT JOIN TANTO S " & vbCrLf)
                    strSQL.Append("                ON H.CLI_CD = S.KURACD AND H.HAN_CD = S.CODE AND S.AUTO_KBN IN ('" & strMAILKBN & "', '" & strBoth & "') AND S.AUTO_MAIL IS NOT NULL " & vbCrLf)
                    strSQL.Append("            LEFT JOIN TANTO J " & vbCrLf)
                    strSQL.Append("                ON H.CLI_CD = J.KURACD AND H.JA_CD  = J.CODE AND J.AUTO_KBN IN ('" & strMAILKBN & "', '" & strBoth & "') AND J.AUTO_MAIL IS NOT NULL AND J.AUTO_ZERO_FLG = '1' " & vbCrLf)
                    ' 2015/03/20 T.Ono mod 2014���P�J�� No16 END
                    strSQL.Append("        WHERE 1=1 " & vbCrLf)
                    strSQL.Append(strWHERE_JAS2.ToString & vbCrLf) '2015/01/22 T.Watabe add
                    strSQL.Append("    ) " & vbCrLf)
                    strSQL.Append("    WHERE " & vbCrLf)
                    strSQL.Append("        AUTO_MAIL IS NOT NULL " & vbCrLf)
                    '' �Ή��f�[�^����---------------------------
                    strSQL.Append("    UNION " & vbCrLf)
                    strSQL.Append("    SELECT  " & vbCrLf)
                    strSQL.Append("          '2' AS AUTO_KUBUN," & vbCrLf)
                    strSQL.Append("          NULL AS AUTO_FAX_SORT," & vbCrLf)
                    strSQL.Append("          NULL AS AUTO_FAX," & vbCrLf)
                    strSQL.Append("          TANTO2.AUTO_MAIL AS AUTO_MAIL," & vbCrLf)
                    strSQL.Append("          0 AS CNT " & vbCrLf)
                    strSQL.Append("    FROM  " & vbCrLf)
                    strSQL.Append("          TANTO2, " & vbCrLf)
                    strSQL.Append("          T  " & vbCrLf)
                    strSQL.Append("    WHERE " & vbCrLf)
                    strSQL.Append("              TANTO2.KURACD = T.KURACD " & vbCrLf)
                    strSQL.Append("          AND TANTO2.CODE = T.ACBCD " & vbCrLf)
                    strSQL.Append("          AND TANTO2.AUTO_KBN IN ('" & strMAILKBN & "', '" & strBoth & "') " & vbCrLf)
                    strSQL.Append("          AND TANTO2.AUTO_MAIL IS NOT NULL " & vbCrLf)
                    strSQL.Append("          AND TANTO2.USER_CD_FROM = T.USER_CD AND TANTO2.USER_CD_TO IS NULL " & vbCrLf)
                    strSQL.Append("    UNION " & vbCrLf)
                    strSQL.Append("    SELECT  " & vbCrLf)
                    strSQL.Append("          '2' AS AUTO_KUBUN," & vbCrLf)
                    strSQL.Append("          NULL AS AUTO_FAX_SORT," & vbCrLf)
                    strSQL.Append("          NULL AS AUTO_FAX," & vbCrLf)
                    strSQL.Append("          TANTO2.AUTO_MAIL AS AUTO_MAIL," & vbCrLf)
                    strSQL.Append("          0 AS CNT " & vbCrLf)
                    strSQL.Append("    FROM  " & vbCrLf)
                    strSQL.Append("          TANTO2 , " & vbCrLf)
                    strSQL.Append("          T  " & vbCrLf)
                    strSQL.Append("    WHERE " & vbCrLf)
                    strSQL.Append("              TANTO2.KURACD = T.KURACD " & vbCrLf)
                    strSQL.Append("          AND TANTO2.CODE = T.ACBCD " & vbCrLf)
                    strSQL.Append("          AND TANTO2.AUTO_KBN IN ('" & strMAILKBN & "', '" & strBoth & "') " & vbCrLf)
                    strSQL.Append("          AND TANTO2.AUTO_MAIL IS NOT NULL " & vbCrLf)
                    strSQL.Append("          AND T.USER_CD BETWEEN TANTO2.USER_CD_FROM AND TANTO2.USER_CD_TO AND TANTO2.USER_CD_TO IS NOT NULL " & vbCrLf)
                    strSQL.Append("          AND NOT EXISTS(  " & vbCrLf)
                    strSQL.Append("             SELECT 'X' FROM TANTO2 C " & vbCrLf)
                    strSQL.Append("             WHERE " & vbCrLf)
                    strSQL.Append("                C.KURACD = T.KURACD AND " & vbCrLf)
                    strSQL.Append("                C.CODE = T.ACBCD AND  " & vbCrLf)
                    strSQL.Append("                C.AUTO_KBN IN ('" & strMAILKBN & "', '" & strBoth & "') AND " & vbCrLf)
                    strSQL.Append("                C.AUTO_MAIL IS NOT NULL AND " & vbCrLf)
                    strSQL.Append("                C.USER_CD_FROM = T.USER_CD AND C.USER_CD_TO IS NULL " & vbCrLf)
                    strSQL.Append("          )   " & vbCrLf)
                    strSQL.Append("    UNION " & vbCrLf)
                    strSQL.Append("    SELECT  " & vbCrLf)
                    strSQL.Append("          '2' AS AUTO_KUBUN," & vbCrLf)
                    strSQL.Append("          NULL AS AUTO_FAX_SORT," & vbCrLf)
                    strSQL.Append("          NULL AS AUTO_FAX," & vbCrLf)
                    strSQL.Append("          TANTO.AUTO_MAIL AS AUTO_MAIL," & vbCrLf)
                    strSQL.Append("          0 AS CNT " & vbCrLf)
                    strSQL.Append("    FROM  " & vbCrLf)
                    strSQL.Append("          TANTO, " & vbCrLf)
                    strSQL.Append("          T  " & vbCrLf)
                    strSQL.Append("    WHERE " & vbCrLf)
                    strSQL.Append("              TANTO.KURACD = T.KURACD " & vbCrLf)
                    strSQL.Append("          AND TANTO.CODE = T.ACBCD " & vbCrLf)
                    strSQL.Append("          AND TANTO.AUTO_KBN IN ('" & strMAILKBN & "', '" & strBoth & "') " & vbCrLf)
                    strSQL.Append("          AND TANTO.AUTO_MAIL IS NOT NULL " & vbCrLf)
                    strSQL.Append("          AND NOT EXISTS(  " & vbCrLf)
                    strSQL.Append("             SELECT 'X' FROM TANTO2 C " & vbCrLf)
                    strSQL.Append("             WHERE " & vbCrLf)
                    strSQL.Append("                C.KURACD = T.KURACD AND " & vbCrLf)
                    strSQL.Append("                C.CODE = T.ACBCD AND  " & vbCrLf)
                    strSQL.Append("                C.AUTO_KBN IN ('" & strMAILKBN & "', '" & strBoth & "') AND " & vbCrLf)
                    strSQL.Append("                C.AUTO_MAIL IS NOT NULL AND " & vbCrLf)
                    strSQL.Append("                C.USER_CD_FROM = T.USER_CD AND C.USER_CD_TO IS NULL " & vbCrLf)
                    strSQL.Append("          )   " & vbCrLf)
                    strSQL.Append("          AND NOT EXISTS(  " & vbCrLf)
                    strSQL.Append("             SELECT 'X' FROM TANTO2 C " & vbCrLf)
                    strSQL.Append("             WHERE " & vbCrLf)
                    strSQL.Append("                C.KURACD = T.KURACD AND " & vbCrLf)
                    strSQL.Append("                C.CODE = T.ACBCD AND  " & vbCrLf)
                    strSQL.Append("                C.AUTO_KBN IN ('" & strMAILKBN & "', '" & strBoth & "') AND " & vbCrLf)
                    strSQL.Append("                C.AUTO_MAIL IS NOT NULL AND " & vbCrLf)
                    strSQL.Append("                T.USER_CD BETWEEN C.USER_CD_FROM AND C.USER_CD_TO AND C.USER_CD_TO IS NOT NULL " & vbCrLf)
                    strSQL.Append("          )   " & vbCrLf)
                    strSQL.Append("    UNION " & vbCrLf)
                    strSQL.Append("    SELECT  " & vbCrLf)
                    strSQL.Append("          '2' AS AUTO_KUBUN," & vbCrLf)
                    strSQL.Append("          NULL AS AUTO_FAX_SORT," & vbCrLf)
                    strSQL.Append("          NULL AS AUTO_FAX," & vbCrLf)
                    strSQL.Append("          TANTO.AUTO_MAIL AS AUTO_MAIL," & vbCrLf)
                    strSQL.Append("          0 AS CNT " & vbCrLf)
                    strSQL.Append("    FROM  " & vbCrLf)
                    strSQL.Append("          TANTO, " & vbCrLf)
                    strSQL.Append("          T  " & vbCrLf)
                    strSQL.Append("    WHERE " & vbCrLf)
                    strSQL.Append("              TANTO.KURACD = T.KURACD " & vbCrLf)
                    'strSQL.Append("          AND TANTO.CODE = substr(T.ACBCD,1,3) " & vbCrLf) 2013/09/09 T.Watabe edit
                    strSQL.Append("          AND TANTO.CODE = T.JACD " & vbCrLf)
                    strSQL.Append("          AND TANTO.AUTO_KBN IN ('" & strMAILKBN & "', '" & strBoth & "') " & vbCrLf)
                    strSQL.Append("          AND TANTO.AUTO_MAIL IS NOT NULL " & vbCrLf)
                    strSQL.Append("          AND NOT EXISTS(  " & vbCrLf)
                    strSQL.Append("             SELECT 'X' FROM TANTO C " & vbCrLf)
                    strSQL.Append("             WHERE " & vbCrLf)
                    strSQL.Append("                C.KURACD = T.KURACD AND " & vbCrLf)
                    strSQL.Append("                C.CODE = T.ACBCD AND  " & vbCrLf)
                    strSQL.Append("                C.AUTO_KBN IN ('" & strMAILKBN & "', '" & strBoth & "') AND " & vbCrLf)
                    strSQL.Append("                C.AUTO_MAIL IS NOT NULL " & vbCrLf)
                    strSQL.Append("          )   " & vbCrLf)
                    strSQL.Append("          AND NOT EXISTS(  " & vbCrLf)
                    strSQL.Append("             SELECT 'X' FROM TANTO2 C " & vbCrLf)
                    strSQL.Append("             WHERE " & vbCrLf)
                    strSQL.Append("                C.KURACD = T.KURACD AND " & vbCrLf)
                    strSQL.Append("                C.CODE = T.ACBCD AND  " & vbCrLf)
                    strSQL.Append("                C.AUTO_KBN IN ('" & strMAILKBN & "', '" & strBoth & "') AND " & vbCrLf)
                    strSQL.Append("                C.AUTO_MAIL IS NOT NULL AND " & vbCrLf)
                    strSQL.Append("                C.USER_CD_FROM = T.USER_CD AND C.USER_CD_TO IS NULL " & vbCrLf)
                    strSQL.Append("          )   " & vbCrLf)
                    strSQL.Append("          AND NOT EXISTS(  " & vbCrLf)
                    strSQL.Append("             SELECT 'X' FROM TANTO2 C " & vbCrLf)
                    strSQL.Append("             WHERE " & vbCrLf)
                    strSQL.Append("                C.KURACD = T.KURACD AND " & vbCrLf)
                    strSQL.Append("                C.CODE = T.ACBCD AND  " & vbCrLf)
                    strSQL.Append("                C.AUTO_KBN IN ('" & strMAILKBN & "', '" & strBoth & "') AND " & vbCrLf)
                    strSQL.Append("                C.AUTO_MAIL IS NOT NULL AND " & vbCrLf)
                    strSQL.Append("                T.USER_CD BETWEEN C.USER_CD_FROM AND C.USER_CD_TO AND C.USER_CD_TO IS NOT NULL " & vbCrLf)
                    strSQL.Append("          )   " & vbCrLf)
                    strSQL.Append(") " & vbCrLf) ' 2015/01/22 T.Watabe add
                    strSQL.Append("WHERE 1=1 " & vbCrLf) ' 2015/01/22 T.Watabe add
                    strSQL.Append(strWHERE_FAXMAIL.ToString & vbCrLf) ' 2015/01/22 T.Watabe add
                Else
                
                    '2015/01/22 T.Watabe edit ð��ٕʖ�"P."��"A."�֒u������
                    '2:�ײ���(�������)
                    strSQL.Append("WITH T AS ( /* T:�Ή��f�[�^�e�[�u�����̏����ɍ��v����KURACD */ " & vbCrLf)
                    strSQL.Append("    SELECT " & vbCrLf)
                    strSQL.Append("        DISTINCT " & vbCrLf)
                    strSQL.Append("        TAI.KURACD " & vbCrLf)
                    strSQL.Append("    FROM D20_TAIOU_COPY TAI  " & vbCrLf)
                    strSQL.Append("    WHERE 1=1  " & vbCrLf)
                    strSQL.Append(strWHERE_TAIOU.ToString & vbCrLf)
                    strSQL.Append(") " & vbCrLf)
                    strSQL.Append("SELECT  " & vbCrLf)
                    strSQL.Append("    AUTO_KUBUN,  " & vbCrLf)
                    strSQL.Append("    AUTO_FAX,  " & vbCrLf)
                    strSQL.Append("    AUTO_MAIL,  " & vbCrLf)
                    strSQL.Append("    0 AS CNT  " & vbCrLf)
                    strSQL.Append("FROM  " & vbCrLf)
                    strSQL.Append("(  " & vbCrLf)
                    strSQL.Append("        /* �@FAX�ʏ� */  " & vbCrLf)
                    strSQL.Append("        SELECT  " & vbCrLf)
                    strSQL.Append("            '1'    AS AUTO_KUBUN,  " & vbCrLf)
                    '2011/11/14 MOD H.Uema -------------------------------------------------------------------- START
                    ' FAX�ԍ��̃n�C�t������菜���悤��SQL���C��("REPLACE(JA.NAME, '-')")
                    strSQL.Append(ReplaceHyphen("A.AUTO_FAXNO") & " AS AUTO_FAX, " & vbCrLf)   'ADD
                    '2011/11/14 MOD H.Uema -------------------------------------------------------------------- END
                    strSQL.Append("            NULL   AS AUTO_MAIL  " & vbCrLf)
                    strSQL.Append("        FROM  " & vbCrLf)
                    strSQL.Append("            CLIMAS CLI,  " & vbCrLf)
                    strSQL.Append("            M05_TANTO A,  " & vbCrLf)
                    strSQL.Append("            T  " & vbCrLf)
                    strSQL.Append("        WHERE 1=1  " & vbCrLf)
                    strSQL.Append("            AND A.KBN = '3'  " & vbCrLf)
                    strSQL.Append("            AND A.AUTO_KBN IN ('" & strFAXKBN & "','" & strBoth & "') " & vbCrLf)
                    strSQL.Append("            AND A.AUTO_FAXNO IS NOT NULL  " & vbCrLf)
                    strSQL.Append("            AND A.CODE = 'XXXX'  " & vbCrLf)
                    strSQL.Append("            AND A.KURACD = CLI.CLI_CD   " & vbCrLf)
                    strSQL.Append("            AND T.KURACD = CLI.CLI_CD   " & vbCrLf)
                    strSQL.Append(strWHERE_CLI.ToString & vbCrLf)
                    strSQL.Append("    UNION ALL " & vbCrLf)
                    strSQL.Append("        /* �AFAX�O���\�� */  " & vbCrLf)
                    strSQL.Append("        SELECT  " & vbCrLf)
                    strSQL.Append("            '1'    AS AUTO_KUBUN,  " & vbCrLf)
                    '2011/11/14 MOD H.Uema -------------------------------------------------------------------- START
                    strSQL.Append(ReplaceHyphen("A.AUTO_FAXNO") & " AS AUTO_FAX, " & vbCrLf)   'ADD
                    '2011/11/14 MOD H.Uema -------------------------------------------------------------------- END
                    strSQL.Append("            NULL   AS AUTO_MAIL  " & vbCrLf)
                    strSQL.Append("        FROM  " & vbCrLf)
                    strSQL.Append("            CLIMAS CLI,  " & vbCrLf)
                    strSQL.Append("            M05_TANTO A  " & vbCrLf)
                    strSQL.Append("        WHERE 1=1  " & vbCrLf)
                    strSQL.Append("            AND A.KBN = '3'  " & vbCrLf)
                    strSQL.Append("            AND A.AUTO_KBN IN ('" & strFAXKBN & "','" & strBoth & "') " & vbCrLf)
                    strSQL.Append("            AND A.AUTO_FAXNO IS NOT NULL  " & vbCrLf)
                    strSQL.Append("            AND A.AUTO_ZERO_FLG = '1'  " & vbCrLf)
                    strSQL.Append("            AND A.CODE = 'XXXX'  " & vbCrLf)
                    strSQL.Append("            AND A.KURACD = CLI.CLI_CD   " & vbCrLf)
                    strSQL.Append(strWHERE_CLI.ToString & vbCrLf)
                    strSQL.Append("    UNION ALL " & vbCrLf)
                    strSQL.Append("        /* �BҰْʏ� */  " & vbCrLf)
                    strSQL.Append("        SELECT  " & vbCrLf)
                    strSQL.Append("            '2'    AS AUTO_KUBUN,  " & vbCrLf)
                    strSQL.Append("            NULL AS AUTO_FAX,  " & vbCrLf)
                    strSQL.Append("            A.AUTO_MAIL   AS AUTO_MAIL  " & vbCrLf)
                    strSQL.Append("        FROM  " & vbCrLf)
                    strSQL.Append("            CLIMAS CLI,  " & vbCrLf)
                    strSQL.Append("            M05_TANTO A,  " & vbCrLf)
                    strSQL.Append("            T  " & vbCrLf)
                    strSQL.Append("        WHERE 1=1  " & vbCrLf)
                    strSQL.Append("            AND A.KBN = '3'  " & vbCrLf)
                    strSQL.Append("            AND A.AUTO_KBN IN ('" & strMAILKBN & "','" & strBoth & "') " & vbCrLf)
                    strSQL.Append("            AND A.AUTO_MAIL IS NOT NULL  " & vbCrLf)
                    strSQL.Append("            AND A.CODE = 'XXXX'  " & vbCrLf)
                    strSQL.Append("            AND A.KURACD = CLI.CLI_CD   " & vbCrLf)
                    strSQL.Append("            AND T.KURACD = CLI.CLI_CD   " & vbCrLf)
                    strSQL.Append(strWHERE_CLI.ToString & vbCrLf)
                    strSQL.Append("    UNION ALL " & vbCrLf)
                    strSQL.Append("        /* �CҰقO���\�� */  " & vbCrLf)
                    strSQL.Append("        SELECT  " & vbCrLf)
                    strSQL.Append("            '2'    AS AUTO_KUBUN,  " & vbCrLf)
                    strSQL.Append("            NULL AS AUTO_FAX,  " & vbCrLf)
                    strSQL.Append("            A.AUTO_MAIL   AS AUTO_MAIL  " & vbCrLf)
                    strSQL.Append("        FROM  " & vbCrLf)
                    strSQL.Append("            CLIMAS CLI,  " & vbCrLf)
                    strSQL.Append("            M05_TANTO A  " & vbCrLf)
                    strSQL.Append("        WHERE 1=1  " & vbCrLf)
                    strSQL.Append("            AND A.KBN = '3'  " & vbCrLf)
                    strSQL.Append("            AND A.AUTO_KBN IN ('" & strMAILKBN & "','" & strBoth & "') " & vbCrLf)
                    strSQL.Append("            AND A.AUTO_MAIL IS NOT NULL  " & vbCrLf)
                    strSQL.Append("            AND A.AUTO_ZERO_FLG = '1'  " & vbCrLf)
                    strSQL.Append("            AND A.CODE = 'XXXX'  " & vbCrLf)
                    strSQL.Append("            AND A.KURACD = CLI.CLI_CD   " & vbCrLf)
                    strSQL.Append(strWHERE_CLI.ToString & vbCrLf)
                    strSQL.Append(")  " & vbCrLf)
                    strSQL.Append("WHERE 1=1 " & vbCrLf) ' 2015/01/22 T.Watabe add
                    strSQL.Append(strWHERE_FAXMAIL.ToString & vbCrLf) ' 2015/01/22 T.Watabe add
                    strSQL.Append("GROUP BY  " & vbCrLf)
                    strSQL.Append("    AUTO_KUBUN,  " & vbCrLf)
                    strSQL.Append("    AUTO_FAX,  " & vbCrLf)
                    strSQL.Append("    AUTO_MAIL  " & vbCrLf)
                End If
            End If

            'DEBUG
            If pintDebugSQLNo = 2 Then '2:���M����WSQL
                Return "DEBUG[" & strSQL.ToString & "]"
            End If

            '//�p�����[�^�̃Z�b�g
            'cdb.pSQLParamStr("KANSI_CODE") = pstrKANSI_CODE

            cdb.pSQL = strSQL.ToString          '//SQL�Z�b�g
            cdb.mExecQuery()                    '//SQL���s
            ds = cdb.pResult                    '//�f�[�^�Z�b�g�Ɋi�[
            If ds.Tables(0).Rows.Count = 0 Then '//�f�[�^�����݂��Ȃ��H
                Return "DATA0"                  '//�f�[�^��0���ł��邱�Ƃ������������Ԃ�
            End If
            dr = ds.Tables(0).Rows(0)           '//�f�[�^���[�Ƀf�[�^���i�[

            'DEBUG
            If pintDebugSQLNo = 101 Then
                Return "DEBUG[" & strSQL.ToString & "]"
            End If
            If pintDebugSQLNo = 102 Then
                Dim buf As String = ""
                Dim j As Integer = 0
                For Each dr In ds.Tables(0).Rows
                    If j >= 100 Then
                        buf = buf & "...[100���ȏ�͏ȗ�]" & vbCrLf
                        Exit For
                    End If
                    If (Convert.ToString(dr.Item("AUTO_FAX")).Length > 0) Then
                        j = j + 1
                        buf = buf & j & ".FAX :" & Convert.ToString(dr.Item("AUTO_FAX")) & vbCrLf
                    End If
                    If Convert.ToString(dr.Item("AUTO_MAIL")).Length > 0 Then
                        j = j + 1
                        buf = buf & j & ".MAIL:" & Convert.ToString(dr.Item("AUTO_MAIL")) & vbCrLf
                    End If
                Next
                Return "DEBUG[" & buf & "]"
            End If

            mlog(pstrSESSION & "\" & pstrKANSI_CODE & "\" & pstrKURACD_F & "\" & pstrKURACD_T, strPGID & ":mExcel3�F4 Count�F" & ds.Tables(0).Rows.Count) '2014/04/11 T.Ono add ���O����
            '//�f�[�^���o��
            Dim strFlg As String = ""
            Dim intLoop As Integer = 1
            Dim intDataRows As Integer = ds.Tables(0).Rows.Count
            Dim intData As Integer = 0
            Dim arrAUTO() As String
            Dim arrAUTO_FAX() As String
            Dim arrAUTO_MAIL() As String
            Dim arrAUTO_CNT() As Integer
            Dim autoKbn As String = ""

            ReDim Preserve arrAUTO(0)
            ReDim Preserve arrAUTO_FAX(0)
            ReDim Preserve arrAUTO_MAIL(0)
            ReDim Preserve arrAUTO_CNT(0)

            For Each dr In ds.Tables(0).Rows
                '--- ��2005/05/19 MOD Falcon�� ---      AUTO��AUTO_KUBUN
                autoKbn = Convert.ToString(dr.Item("AUTO_KUBUN"))
                If ((autoKbn = strFAXKBN Or autoKbn = strBoth) And Convert.ToString(dr.Item("AUTO_FAX")).Length > 0) Or _
                   ((autoKbn = strMAILKBN Or autoKbn = strBoth) And Convert.ToString(dr.Item("AUTO_MAIL")).Length > 0) Then

                    ' 2011/03/10 T.Watabe edit FAX��Ұق𗼕����M�\�ɕύX
                    If autoKbn = strFAXKBN Or autoKbn = strBoth Then '�����敪��1:FAX���M/3:FAX,Ұٗ���
                        ReDim Preserve arrAUTO(intData)
                        ReDim Preserve arrAUTO_FAX(intData)
                        ReDim Preserve arrAUTO_MAIL(intData)
                        ReDim Preserve arrAUTO_CNT(intData)
                        arrAUTO(intData) = "1"      '1:FAX���M �Œ�
                        arrAUTO_FAX(intData) = Convert.ToString(dr.Item("AUTO_FAX"))
                        arrAUTO_MAIL(intData) = ""  'Ұً�
                        arrAUTO_CNT(intData) = Convert.ToInt16(dr.Item("CNT"))
                        intData += 1
                    End If
                    If autoKbn = strMAILKBN Or autoKbn = strBoth Then '�����敪��2:Ұّ��M/3:FAX,Ұٗ���
                        ReDim Preserve arrAUTO(intData)
                        ReDim Preserve arrAUTO_FAX(intData)
                        ReDim Preserve arrAUTO_MAIL(intData)
                        ReDim Preserve arrAUTO_CNT(intData)
                        arrAUTO(intData) = "2"      '2:Ұّ��M �Œ�
                        arrAUTO_FAX(intData) = ""   'FAX��
                        arrAUTO_MAIL(intData) = Convert.ToString(dr.Item("AUTO_MAIL"))
                        arrAUTO_CNT(intData) = Convert.ToInt16(dr.Item("CNT"))
                        intData += 1
                    End If
                End If
                '--- ��2005/05/19 MOD Falcon�� ---    
            Next
            mlog(pstrSESSION & "\" & pstrKANSI_CODE & "\" & pstrKURACD_F & "\" & pstrKURACD_T, strPGID & ":mExcel3�F5 �f�[�^�J�E���g�F" & intData) '2014/04/11 T.Ono add ���O����
            If intData = 0 Then
                '//�f�[�^��0���ł��邱�Ƃ������������Ԃ�
                Return "DATA0"
            End If

            'DEBUG
            If pintDebugSQLNo = 103 Then
                Return "DEBUG[" & strSQL.ToString & "]"
            End If

            Dim i As Integer
            For i = 0 To intData - 1
                If intLoop = intData Then
                    strFlg = "1"
                Else
                    strFlg = "0"
                End If
                mlog(pstrSESSION & "\" & pstrKANSI_CODE & "\" & pstrKURACD_F & "\" & pstrKURACD_T, strPGID & ":mExcel3�F6 " & _
                     "�������M�敪:" & arrAUTO(i) & " FAX:" & arrAUTO_FAX(i) & " ���[��:" & arrAUTO_MAIL(i) & " CNT:" & arrAUTO_CNT(i)) '2014/04/11 T.Ono add ���O����
                strRec = mExcelOut(cdb, _
                            pstrKANSI_CODE, _
                            pstrSESSION, _
                            pstrTAISYOUBI, _
                            pstrKURACD_F, _
                            pstrKURACD_T, _
                            strWHERE_TAIOU.ToString, _
                            arrAUTO(i), _
                            arrAUTO_FAX(i), _
                            arrAUTO_MAIL(i), _
                            arrAUTO_CNT(i), _
                            pstrCreateFilePath, _
                            strFlg, _
                            pstrSEND_JALP_NAME, _
                            pstrSEND_CENT_NAME, _
                            pstrSEND_KBN, _
                            i, _
                            pintDebugSQLNo _
                            )
                '//�d�w�b�d�k�t�@�C���́A[strCOMPRESS]�ɃZ�b�g�������O�̈��k�t�@�C���ɒǉ�����
                Select Case strRec.Substring(0, 5)
                    'Case "DATA0"
                    '    Exit Try
                    Case "DEBUG"
                        'Exit Try
                        Return strRec
                    Case "ERROR"
                        Exit Try
                End Select
                intLoop += 1
            Next

            mlog(pstrSESSION & "\" & pstrKANSI_CODE & "\" & pstrKURACD_F & "\" & pstrKURACD_T, strPGID & ":mExcel3�F7") '2014/04/11 T.Ono add ���O����
            '2011/06/14 T.Watabe add
            '--------------------------------
            ' D20�̏�����폜
            '--------------------------------
            mDeleteD20Taiou(cdb, GUID)

        Catch ex As Exception
            mlog(pstrSESSION & "\" & pstrKANSI_CODE & "\" & pstrKURACD_F & "\" & pstrKURACD_T, _
     "[" & ex.ToString & "]" & Environment.StackTrace)
            strRec = "ERROR:" & ex.ToString
        Finally
            '�ڑ��N���[�Y
            cdb.mClose()
        End Try

        If pintDebugSQLNo <> 0 Then '�f�o�b�O���[�h�H
            If strRec.Substring(0, 5) <> "DEBUG" And strRec.Substring(0, 5) <> "ERROR" Then
                strRec = "DEBUG:�f�o�b�O���[�h�ł����A�f�[�^������Ă��܂��܂����B"
            End If
        End If
        Return strRec
    End Function

    '******************************************************************************
    '*�@�T�@�v�FD20_TAIOU_COPY��p�ӁiD20_TAIOU����Y���̓��t�{�����̃f�[�^�̂݃R�s�[����j
    '*�@���@�l�F
    '*  ��  ���F2011/06/14 T.Watabe
    '******************************************************************************
    Private Function mCopyD20Taiou(ByVal cdb As CDB, ByVal GUID As String, ByVal pstrWHERE_TAIOU As String) As String

        Dim sql As New StringBuilder("")

        Try

            '/* �����ɍ��v����f�[�^���R�s�[���Ă��� */
            sql = New StringBuilder("")
            sql.Append("INSERT INTO D20_TAIOU_COPY ")
            ' �� 2013/09/09 T.Watabe add
            sql.Append("(")
            sql.Append("    KANSCD,")
            sql.Append("    SYONO,")
            sql.Append("    HATYMD,")
            sql.Append("    HATTIME,")
            sql.Append("    KENSIN,")
            sql.Append("    KEIHOSU,")
            sql.Append("    RYURYO,")
            sql.Append("    METASYU,")
            sql.Append("    UNYO,")
            sql.Append("    JUYMD,")
            sql.Append("    JUTIME,")
            sql.Append("    NUM_DIGIT,")
            sql.Append("    KMCD1,")
            sql.Append("    KMNM1,")
            sql.Append("    KMCD2,")
            sql.Append("    KMNM2,")
            sql.Append("    KMCD3,")
            sql.Append("    KMNM3,")
            sql.Append("    KMCD4,")
            sql.Append("    KMNM4,")
            sql.Append("    KMCD5,")
            sql.Append("    KMNM5,")
            sql.Append("    KMCD6,")
            sql.Append("    KMNM6,")
            sql.Append("    ZSISYO,")
            sql.Append("    KURACD,")
            sql.Append("    KENNM,")
            sql.Append("    JACD,")
            sql.Append("    JANM,")
            sql.Append("    ACBCD,")
            sql.Append("    ACBNM,")
            sql.Append("    USER_CD,")
            sql.Append("    JUSYONM,")
            sql.Append("    JUSYOKN,")
            sql.Append("    JUTEL1,")
            sql.Append("    JUTEL2,")
            sql.Append("    RENTEL,")
            sql.Append("    KTELNO,")
            sql.Append("    ADDR,")
            sql.Append("    USER_KIJI,")
            sql.Append("    NCU_SET,")
            sql.Append("    TIZUNO,")
            sql.Append("    GAS_STOP,")
            sql.Append("    GAS_DELE,")
            sql.Append("    GAS_RESTART,")
            sql.Append("    MET_KATA,")
            sql.Append("    MET_MAKER,")
            sql.Append("    BONB1_KKG,")
            sql.Append("    BONB1_HON,")
            sql.Append("    BONB1_YOBI,")
            sql.Append("    BONB2_KKG,")
            sql.Append("    BONB2_HON,")
            sql.Append("    BONB2_YOBI,")
            sql.Append("    BONB3_KKG,")
            sql.Append("    BONB3_HON,")
            sql.Append("    BONB3_YOBI,")
            sql.Append("    BONB4_KKG,")
            sql.Append("    BONB4_HON,")
            sql.Append("    BONB4_YOBI,")
            sql.Append("    BOMB_TYPE,")
            sql.Append("    ZENKAI_HAISO,")
            sql.Append("    ZENKAI_HAI_S,")
            sql.Append("    KONKAI_HAISO,")
            sql.Append("    KONKAI_HAI_S,")
            sql.Append("    JIKAI_HAISO,")
            sql.Append("    ZENKAI_KENSIN,")
            sql.Append("    ZENKAI_KEN_S,")
            sql.Append("    ZENKAI_KEN_SIYO,")
            sql.Append("    KONKAI_KENSIN,")
            sql.Append("    KONKAI_KEN_S,")
            sql.Append("    KONKAI_KEN_SIYO,")
            sql.Append("    ZENKAI_HASEI,")
            sql.Append("    ZENKAI_HAS_S,")
            sql.Append("    KONKAI_HASEI,")
            sql.Append("    KONKAI_HAS_S,")
            sql.Append("    G_ZAIKO,")
            sql.Append("    ICHI_SIYO,")
            sql.Append("    YOSOKU_ICHI_SIYO,")
            sql.Append("    GAS1_HINMEI,")
            sql.Append("    GAS1_DAISU,")
            sql.Append("    GAS1_SEIFL,")
            sql.Append("    GAS2_HINMEI,")
            sql.Append("    GAS2_DAISU,")
            sql.Append("    GAS2_SEIFL,")
            sql.Append("    GAS3_HINMEI,")
            sql.Append("    GAS3_DAISU,")
            sql.Append("    GAS3_SEIFL,")
            sql.Append("    GAS4_HINMEI,")
            sql.Append("    GAS4_DAISU,")
            sql.Append("    GAS4_SEIFL,")
            sql.Append("    GAS5_HINMEI,")
            sql.Append("    GAS5_DAISU,")
            sql.Append("    GAS5_SEIFL,")
            sql.Append("    HATKBN,")
            sql.Append("    HATKBN_NAI,")
            sql.Append("    TAIOKBN,")
            sql.Append("    TAIOKBN_NAI,")
            sql.Append("    TMSKB,")
            sql.Append("    TMSKB_NAI,")
            sql.Append("    TKTANCD,")
            sql.Append("    TKTANCD_NM,")
            sql.Append("    TAITCD,")
            sql.Append("    TAITNM,")
            sql.Append("    TAIO_ST_DATE,")
            sql.Append("    TAIO_ST_TIME,")
            sql.Append("    SYOYMD,")
            sql.Append("    SYOTIME,")
            sql.Append("    TAIO_SYO_TIME,")
            sql.Append("    FAXKBN,")
            sql.Append("    TELRCD,")
            sql.Append("    TELRNM,")
            sql.Append("    TFKICD,")
            sql.Append("    TFKINM,")
            sql.Append("    FUK_MEMO,")
            sql.Append("    TEL_MEMO1,")
            sql.Append("    TEL_MEMO2,")
            sql.Append("    MITOKBN,")
            sql.Append("    TKIGCD,")
            sql.Append("    TKIGNM,")
            sql.Append("    TSADCD,")
            sql.Append("    TSADNM,")
            sql.Append("    GENIN_KIJI,")
            sql.Append("    SDCD,")
            sql.Append("    SDNM,")
            sql.Append("    SIJIYMD,")
            sql.Append("    SIJITIME,")
            sql.Append("    SIJI_BIKO1,")
            sql.Append("    SIJI_BIKO2,")
            sql.Append("    STD_JASCD,")
            sql.Append("    STD_JANA,")
            sql.Append("    STD_JASNA,")
            sql.Append("    REN_NA,")
            sql.Append("    REN_TEL_1,")
            sql.Append("    REN_TEL_2,")
            sql.Append("    REN_FAX,")
            sql.Append("    REN_BIKO,")
            sql.Append("    REN_1_NA,")
            sql.Append("    REN_1_TEL1,")
            sql.Append("    REN_1_TEL2,")
            sql.Append("    REN_1_FAX,")
            sql.Append("    REN_1_BIKO,")
            sql.Append("    REN_2_NA,")
            sql.Append("    REN_2_TEL1,")
            sql.Append("    REN_2_TEL2,")
            sql.Append("    REN_2_FAX,")
            sql.Append("    REN_2_BIKO,")
            sql.Append("    REN_3_NA,")
            sql.Append("    REN_3_TEL1,")
            sql.Append("    REN_3_TEL2,")
            sql.Append("    REN_3_FAX,")
            sql.Append("    REN_3_BIKO,")
            sql.Append("    STD_CD,")
            sql.Append("    STD,")
            sql.Append("    STD_KYOTEN_CD,")
            sql.Append("    STD_KYOTEN,")
            sql.Append("    STD_TEL,")
            sql.Append("    TEL_BIKO,")
            sql.Append("    FAX_TITLE,")
            sql.Append("    FAX_REN,")
            sql.Append("    TSTANCD,")
            sql.Append("    TSTANNM,")
            sql.Append("    STD_KYOTEN_CD_I,")
            sql.Append("    STD_KYOTEN_I,")
            sql.Append("    SYUTDTNM,")
            sql.Append("    ORNCU,")
            sql.Append("    TYAKYMD,")
            sql.Append("    TYAKTIME,")
            sql.Append("    SYOKANYMD,")
            sql.Append("    SYOKANTIME,")
            sql.Append("    AITCD,")
            sql.Append("    AITNM,")
            sql.Append("    METHEIKAKU,")
            sql.Append("    RUSUHARI,")
            sql.Append("    METFUKKI,")
            sql.Append("    HOAN,")
            sql.Append("    GASGIRE,")
            sql.Append("    KIGKOSYO,")
            sql.Append("    CSNTGEN,")
            sql.Append("    CSNTNGAS,")
            sql.Append("    SDTBIK1,")
            sql.Append("    KIGCD,")
            sql.Append("    KIGNM,")
            sql.Append("    SADCD,")
            sql.Append("    SADNM,")
            sql.Append("    STACD,")
            sql.Append("    STANM,")
            sql.Append("    ASECD,")
            sql.Append("    ASENM,")
            sql.Append("    FKICD,")
            sql.Append("    FKINM,")
            sql.Append("    JAKENREN,")
            sql.Append("    RENTIME,")
            sql.Append("    KIGTAIYO,")
            sql.Append("    GASMUMU,")
            sql.Append("    ORGENIN,")
            sql.Append("    HAIKAN,")
            sql.Append("    GASGUMU,")
            sql.Append("    HOSKOKAN,")
            sql.Append("    METYOINA,")
            sql.Append("    TYOUYOINA,")
            sql.Append("    VALYOINA,")
            sql.Append("    KYUHAIUMU,")
            sql.Append("    COYOINA,")
            sql.Append("    SDTBIK2,")
            sql.Append("    SNTTOKKI,")
            sql.Append("    LTOS_DATE,")
            sql.Append("    ADD_DATE,")
            sql.Append("    EDT_DATE,")
            sql.Append("    EDT_TIME,")
            sql.Append("    BIKOU,")
            sql.Append("    FAX_TITLE_CD,")
            sql.Append("    SDTBIK3,")
            sql.Append("    SDYMD,")
            sql.Append("    SDTIME,")
            sql.Append("    SDSKBN,")
            sql.Append("    SDSKBN_NAI,")
            sql.Append("    NCUHATYMD,")
            sql.Append("    NCUHATTIME,")
            sql.Append("    FAXKURAKBN,")
            sql.Append("    SYORI_SERIAL, ")
            sql.Append("    KAITU_DAY, ") ' 2013/08/26 T.Ono add �Ď����P2013��1
            sql.Append("    COPY_DATE, ")
            sql.Append("    GUID ")
            sql.Append(") ")
            ' �� 2013/09/09 T.Watabe add
            sql.Append("SELECT ")
            sql.Append("    KANSCD,")
            sql.Append("    SYONO,")
            sql.Append("    HATYMD,")
            sql.Append("    HATTIME,")
            sql.Append("    KENSIN,")
            sql.Append("    KEIHOSU,")
            sql.Append("    RYURYO,")
            sql.Append("    METASYU,")
            sql.Append("    UNYO,")
            sql.Append("    JUYMD,")
            sql.Append("    JUTIME,")
            sql.Append("    NUM_DIGIT,")
            'sql.Append("    KMCD1,") ' 2015/01/22 T.Watabe edit
            'sql.Append("    KMNM1,") ' 2015/01/22 T.Watabe edit
            'sql.Append("    KMCD2,") ' 2015/01/22 T.Watabe edit
            'sql.Append("    KMNM2,") ' 2015/01/22 T.Watabe edit
            'sql.Append("    KMCD3,") ' 2015/01/22 T.Watabe edit
            'sql.Append("    KMNM3,") ' 2015/01/22 T.Watabe edit
            'sql.Append("    KMCD4,") ' 2015/01/22 T.Watabe edit
            'sql.Append("    KMNM4,") ' 2015/01/22 T.Watabe edit
            'sql.Append("    KMCD5,") ' 2015/01/22 T.Watabe edit
            'sql.Append("    KMNM5,") ' 2015/01/22 T.Watabe edit
            'sql.Append("    KMCD6,") ' 2015/01/22 T.Watabe edit
            'sql.Append("    KMNM6,") ' 2015/01/22 T.Watabe edit
            sql.Append("    KMCD1, DECODE(RTRIM(KMCD1), NULL, NULL, KMNM1) AS KMNM1,")
            sql.Append("    KMCD2, DECODE(RTRIM(KMCD2), NULL, NULL, KMNM2) AS KMNM2,")
            sql.Append("    KMCD3, DECODE(RTRIM(KMCD3), NULL, NULL, KMNM3) AS KMNM3,")
            sql.Append("    KMCD4, DECODE(RTRIM(KMCD4), NULL, NULL, KMNM4) AS KMNM4,")
            sql.Append("    KMCD5, DECODE(RTRIM(KMCD5), NULL, NULL, KMNM5) AS KMNM5,")
            sql.Append("    KMCD6, DECODE(RTRIM(KMCD6), NULL, NULL, KMNM6) AS KMNM6,")
            sql.Append("    ZSISYO,")
            sql.Append("    KURACD,")
            sql.Append("    KENNM,")
            sql.Append("    JACD,")
            sql.Append("    JANM,")
            sql.Append("    ACBCD,")
            sql.Append("    ACBNM,")
            sql.Append("    USER_CD,")
            sql.Append("    JUSYONM,")
            sql.Append("    JUSYOKN,")
            sql.Append("    JUTEL1,")
            sql.Append("    JUTEL2,")
            sql.Append("    RENTEL,")
            sql.Append("    KTELNO,")
            sql.Append("    ADDR,")
            sql.Append("    USER_KIJI,")
            sql.Append("    NCU_SET,")
            sql.Append("    TIZUNO,")
            sql.Append("    GAS_STOP,")
            sql.Append("    GAS_DELE,")
            sql.Append("    GAS_RESTART,")
            sql.Append("    MET_KATA,")
            sql.Append("    MET_MAKER,")
            sql.Append("    BONB1_KKG,")
            sql.Append("    BONB1_HON,")
            sql.Append("    BONB1_YOBI,")
            sql.Append("    BONB2_KKG,")
            sql.Append("    BONB2_HON,")
            sql.Append("    BONB2_YOBI,")
            sql.Append("    BONB3_KKG,")
            sql.Append("    BONB3_HON,")
            sql.Append("    BONB3_YOBI,")
            sql.Append("    BONB4_KKG,")
            sql.Append("    BONB4_HON,")
            sql.Append("    BONB4_YOBI,")
            sql.Append("    BOMB_TYPE,")
            sql.Append("    ZENKAI_HAISO,")
            sql.Append("    ZENKAI_HAI_S,")
            sql.Append("    KONKAI_HAISO,")
            sql.Append("    KONKAI_HAI_S,")
            sql.Append("    JIKAI_HAISO,")
            sql.Append("    ZENKAI_KENSIN,")
            sql.Append("    ZENKAI_KEN_S,")
            sql.Append("    ZENKAI_KEN_SIYO,")
            sql.Append("    KONKAI_KENSIN,")
            sql.Append("    KONKAI_KEN_S,")
            sql.Append("    KONKAI_KEN_SIYO,")
            sql.Append("    ZENKAI_HASEI,")
            sql.Append("    ZENKAI_HAS_S,")
            sql.Append("    KONKAI_HASEI,")
            sql.Append("    KONKAI_HAS_S,")
            sql.Append("    G_ZAIKO,")
            sql.Append("    ICHI_SIYO,")
            sql.Append("    YOSOKU_ICHI_SIYO,")
            sql.Append("    GAS1_HINMEI,")
            sql.Append("    GAS1_DAISU,")
            sql.Append("    GAS1_SEIFL,")
            sql.Append("    GAS2_HINMEI,")
            sql.Append("    GAS2_DAISU,")
            sql.Append("    GAS2_SEIFL,")
            sql.Append("    GAS3_HINMEI,")
            sql.Append("    GAS3_DAISU,")
            sql.Append("    GAS3_SEIFL,")
            sql.Append("    GAS4_HINMEI,")
            sql.Append("    GAS4_DAISU,")
            sql.Append("    GAS4_SEIFL,")
            sql.Append("    GAS5_HINMEI,")
            sql.Append("    GAS5_DAISU,")
            sql.Append("    GAS5_SEIFL,")
            sql.Append("    HATKBN,")
            sql.Append("    HATKBN_NAI,")
            sql.Append("    TAIOKBN,")
            sql.Append("    TAIOKBN_NAI,")
            sql.Append("    TMSKB,")
            sql.Append("    TMSKB_NAI,")
            sql.Append("    TKTANCD,")
            sql.Append("    TKTANCD_NM,")
            sql.Append("    TAITCD,")
            sql.Append("    TAITNM,")
            sql.Append("    TAIO_ST_DATE,")
            sql.Append("    TAIO_ST_TIME,")
            sql.Append("    SYOYMD,")
            sql.Append("    SYOTIME,")
            sql.Append("    TAIO_SYO_TIME,")
            sql.Append("    FAXKBN,")
            sql.Append("    TELRCD,")
            sql.Append("    TELRNM,")
            sql.Append("    TFKICD,")
            sql.Append("    TFKINM,")
            sql.Append("    FUK_MEMO,")
            sql.Append("    TEL_MEMO1,")
            sql.Append("    TEL_MEMO2,")
            sql.Append("    MITOKBN,")
            sql.Append("    TKIGCD,")
            sql.Append("    TKIGNM,")
            sql.Append("    TSADCD,")
            sql.Append("    TSADNM,")
            sql.Append("    GENIN_KIJI,")
            sql.Append("    SDCD,")
            sql.Append("    SDNM,")
            sql.Append("    SIJIYMD,")
            sql.Append("    SIJITIME,")
            sql.Append("    SIJI_BIKO1,")
            sql.Append("    SIJI_BIKO2,")
            sql.Append("    STD_JASCD,")
            sql.Append("    STD_JANA,")
            sql.Append("    STD_JASNA,")
            sql.Append("    REN_NA,")
            sql.Append("    REN_TEL_1,")
            sql.Append("    REN_TEL_2,")
            sql.Append("    REN_FAX,")
            sql.Append("    REN_BIKO,")
            sql.Append("    REN_1_NA,")
            sql.Append("    REN_1_TEL1,")
            sql.Append("    REN_1_TEL2,")
            sql.Append("    REN_1_FAX,")
            sql.Append("    REN_1_BIKO,")
            sql.Append("    REN_2_NA,")
            sql.Append("    REN_2_TEL1,")
            sql.Append("    REN_2_TEL2,")
            sql.Append("    REN_2_FAX,")
            sql.Append("    REN_2_BIKO,")
            sql.Append("    REN_3_NA,")
            sql.Append("    REN_3_TEL1,")
            sql.Append("    REN_3_TEL2,")
            sql.Append("    REN_3_FAX,")
            sql.Append("    REN_3_BIKO,")
            sql.Append("    STD_CD,")
            sql.Append("    STD,")
            sql.Append("    STD_KYOTEN_CD,")
            sql.Append("    STD_KYOTEN,")
            sql.Append("    STD_TEL,")
            sql.Append("    TEL_BIKO,")
            sql.Append("    FAX_TITLE,")
            sql.Append("    FAX_REN,")
            sql.Append("    TSTANCD,")
            sql.Append("    TSTANNM,")
            sql.Append("    STD_KYOTEN_CD_I,")
            sql.Append("    STD_KYOTEN_I,")
            sql.Append("    SYUTDTNM,")
            sql.Append("    ORNCU,")
            sql.Append("    TYAKYMD,")
            sql.Append("    TYAKTIME,")
            sql.Append("    SYOKANYMD,")
            sql.Append("    SYOKANTIME,")
            sql.Append("    AITCD,")
            sql.Append("    AITNM,")
            sql.Append("    METHEIKAKU,")
            sql.Append("    RUSUHARI,")
            sql.Append("    METFUKKI,")
            sql.Append("    HOAN,")
            sql.Append("    GASGIRE,")
            sql.Append("    KIGKOSYO,")
            sql.Append("    CSNTGEN,")
            sql.Append("    CSNTNGAS,")
            sql.Append("    SDTBIK1,")
            sql.Append("    KIGCD,")
            sql.Append("    KIGNM,")
            sql.Append("    SADCD,")
            sql.Append("    SADNM,")
            sql.Append("    STACD,")
            sql.Append("    STANM,")
            sql.Append("    ASECD,")
            sql.Append("    ASENM,")
            sql.Append("    FKICD,")
            sql.Append("    FKINM,")
            sql.Append("    JAKENREN,")
            sql.Append("    RENTIME,")
            sql.Append("    KIGTAIYO,")
            sql.Append("    GASMUMU,")
            sql.Append("    ORGENIN,")
            sql.Append("    HAIKAN,")
            sql.Append("    GASGUMU,")
            sql.Append("    HOSKOKAN,")
            sql.Append("    METYOINA,")
            sql.Append("    TYOUYOINA,")
            sql.Append("    VALYOINA,")
            sql.Append("    KYUHAIUMU,")
            sql.Append("    COYOINA,")
            sql.Append("    SDTBIK2,")
            sql.Append("    SNTTOKKI,")
            sql.Append("    LTOS_DATE,")
            sql.Append("    ADD_DATE,")
            sql.Append("    EDT_DATE,")
            sql.Append("    EDT_TIME,")
            sql.Append("    BIKOU,")
            sql.Append("    FAX_TITLE_CD,")
            sql.Append("    SDTBIK3,")
            sql.Append("    SDYMD,")
            sql.Append("    SDTIME,")
            sql.Append("    SDSKBN,")
            sql.Append("    SDSKBN_NAI,")
            sql.Append("    NCUHATYMD,")
            sql.Append("    NCUHATTIME,")
            sql.Append("    FAXKURAKBN,")
            ' 2013/08/13 T.Ono mod ----------Start
            'sql.Append("    SYSDATE, ")
            'sql.Append("    '" & GUID & "', ")
            'sql.Append("    SYORI_SERIAL ")
            sql.Append("    SYORI_SERIAL, ")
            sql.Append("    KAITU_DAY, ") ' 2013/08/26 T.Ono add �Ď����P2013��1
            sql.Append("    SYSDATE, ")
            sql.Append("    '" & GUID & "' ")
            ' 2013/08/13 T.Ono mod ----------End
            sql.Append("FROM D20_TAIOU TAI ")
            sql.Append("WHERE 1=1 ")
            sql.Append(pstrWHERE_TAIOU)

            cdb.mBeginTrans() '�g�����U�N�V�����J�n
            cdb.pSQL = sql.ToString '//SQL�Z�b�g
            cdb.mExecNonQuery() '//SQL���s
            cdb.mCommit() '�g�����U�N�V�����I��(�R�~�b�g)
        Catch ex As Exception
            cdb.mRollback() '�g�����U�N�V�����I��(���[���o�b�N)
            '�G���[�̓��e�Ƃr�p�k����Ԃ�
            Return "ERROR:" & ex.ToString & vbCrLf & vbCrLf & Environment.StackTrace & vbCrLf & " ���O��SQL[" & sql.ToString & "]"
        Finally
        End Try

        Return "OK"

    End Function

    '******************************************************************************
    '*�@�T�@�v�FD20_TAIOU_COPY���������GUID�ŃN���A����B����c�����f�[�^���P���o�߂ō폜�B
    '*�@���@�l�F
    '*  ��  ���F2011/06/14 T.Watabe
    '******************************************************************************
    Private Function mDeleteD20Taiou(ByVal cdb As CDB, ByVal GUID As String) As String

        Dim sql As New StringBuilder("")

        Try
            cdb.mBeginTrans() '�g�����U�N�V�����J�n

            '/* �@�쐬����12���Ԍo�߂����f�[�^�͍폜 */
            sql = New StringBuilder("")
            sql.Append("DELETE FROM D20_TAIOU_COPY WHERE COPY_DATE IS NULL OR COPY_DATE <= SYSDATE - 0.5 ")
            cdb.pSQL = sql.ToString '//SQL�Z�b�g
            cdb.mExecNonQuery() '//SQL���s

            '/* �AGUID�Ńf�[�^�폜 */
            sql = New StringBuilder("")
            sql.Append("DELETE FROM D20_TAIOU_COPY WHERE GUID = '" & GUID & "' ")
            cdb.pSQL = sql.ToString '//SQL�Z�b�g
            cdb.mExecNonQuery() '//SQL���s

            cdb.mCommit() '�g�����U�N�V�����I��(�R�~�b�g)

        Catch ex As Exception
            cdb.mRollback() '�g�����U�N�V�����I��(���[���o�b�N)
            '�G���[�̓��e�Ƃr�p�k����Ԃ�
            Return "ERROR:" & ex.ToString & vbCrLf & vbCrLf & Environment.StackTrace & vbCrLf & " ���O��SQL[" & sql.ToString & "]"
        Finally
        End Try

        Return "OK"

    End Function

    '******************************************************************************
    '*�@�T�@�v�F�i�[�X�Z���^�[�Ή����e���ׁi�e�`�w�j�̏o��
    '*�@���@�l�F
    '******************************************************************************
    '�@DATA0�F�Ώۃf�[�^������܂���
    Private Function mExcelOut( _
                                ByVal cdb As CDB, _
                                ByVal pstrKANSI_CODE As String, _
                                ByVal pstrSESSION As String, _
                                ByVal pstrTAISYOUBI As String, _
                                ByVal pstrKURACD_F As String, _
                                ByVal pstrKURACD_T As String, _
                                ByVal pstrWHERE_TAIOU As String, _
                                ByVal pstrAUTO As String, _
                                ByVal pstrFAXNO As String, _
                                ByVal pstrMAILAD As String, _
                                ByVal pintCNT As Integer, _
                                ByVal pstrCreateFilePath As String, _
                                ByVal pstrFlg As String, _
                                ByVal pstrSEND_JALP_NAME As String, _
                                ByVal pstrSEND_CENT_NAME As String, _
                                ByVal pstrSEND_KBN As String, _
                                ByVal pintLoopNo As Integer, _
                                ByVal pintDebugSQLNo As Integer _
                                ) As String

        Dim strSQL As New StringBuilder("")
        Dim ds As New DataSet
        Dim dr As DataRow


        Dim ExcelC As New CExcel 'Excel�N���X
        Dim compressC As New CCompress '���k�N���X
        Dim intGYOSU As Integer = 56 '���s������s��
        Dim DateFncC As New CDateFnc '���t�ϊ��N���X
        Dim FileToStrC As New CFileStr '�t�@�C����Base64�ɃG���R�[�h����N���X
        Dim sZipFilePass As String = "" ' 2008/12/12 T.Watabe add
        Dim sendCD As String '2010/05/24 T.Watabe add

        Dim cliCd4FileHead As String = "" '2011/03/10 T.Watabe add
        Dim jaName4FileHead As String = ""  ' 2011/05/19 T.Watabe add
        Dim centerName As String = ""

        Dim wkstrTAIOU_SYONO As String = ""
        Dim wkstrTAIOU_KURACD As String = ""
        Dim wkstrTAIOU_JACD As String = ""
        Dim wkstrTAIOU_ACBCD As String = ""
        Dim wkstrTAIOU_USER_CD As String = ""
        Dim wkstrAUTO_ZERO_FLG As String = "0" ' �y�[�������M�t���O�z 0:�f�[�^����/1:�[�����I(�f�[�^�Ȃ�)


        If pstrSEND_KBN = "1" Then
            sendCD = "H" '�̔���
        Else
            sendCD = "C" '����
        End If

        mlog(pstrSESSION & "\" & pstrKANSI_CODE & "\" & pstrKURACD_F & "\" & pstrKURACD_T, "BTFAXJAX00:mExcelOut�F1") '2014/04/11 T.Ono add ���O����

        '����FAX��p���O�X�V(�t���O�N���A)�@2013/09/25 T.Watabe add
        Call mUpdateFlgS05AutofaxLog(cdb,
                                pstrSEND_KBN,
                                pstrTAISYOUBI,
                                pstrAUTO,
                                pstrFAXNO,
                                pstrMAILAD
                                )

        Dim sel As StringBuilder = New StringBuilder("")
        Dim fro As StringBuilder = New StringBuilder("")
        Dim whe As StringBuilder = New StringBuilder("")
        Dim wheC As StringBuilder = New StringBuilder("")
        Dim wheJ As StringBuilder = New StringBuilder("")
        Dim ord As StringBuilder = New StringBuilder("")

        mlog(pstrSESSION & "\" & pstrKANSI_CODE & "\" & pstrKURACD_F & "\" & pstrKURACD_T, "BTFAXJAX00:mExcelOut�F2 ���M�敪" & pstrSEND_KBN) '2014/04/11 T.Ono add ���O����

        If pstrSEND_KBN = "1" Then '1:�̔����H

            sel.Append("    ,DECODE(JAS2.AUTO_MAIL_PASS,NULL,DECODE(JAS3.AUTO_MAIL_PASS,NULL,DECODE(JAS.AUTO_MAIL_PASS,NULL,JAS1.AUTO_MAIL_PASS,JAS.AUTO_MAIL_PASS),JAS3.AUTO_MAIL_PASS),JAS2.AUTO_MAIL_PASS) AS YOBI5 " & vbCrLf) ' �p�X���[�h

            fro.Append("    ,M05_TANTO JAS " & vbCrLf)
            fro.Append("    ,M05_TANTO JAS1 " & vbCrLf)
            fro.Append("    ,M05_TANTO2 JAS2 " & vbCrLf)
            fro.Append("    ,M05_TANTO2 JAS3 " & vbCrLf)
            fro.Append("    ,HN2MAS JAS4 " & vbCrLf)

            If pstrAUTO = strFAXKBN Then '�e�`�w���M�H
                whe.Append("  AND JAS.AUTO_KBN(+)  IN ('" & strFAXKBN & "','" & strBoth & "') " & vbCrLf)  ' 2011/03/10 T.Watabe edit
                whe.Append("  AND JAS1.AUTO_KBN(+) IN ('" & strFAXKBN & "','" & strBoth & "') " & vbCrLf)  ' 2011/03/10 T.Watabe edit
                whe.Append("  AND JAS2.AUTO_KBN(+) IN ('" & strFAXKBN & "','" & strBoth & "') " & vbCrLf)  ' 2011/03/10 T.Watabe edit
                whe.Append("  AND JAS3.AUTO_KBN(+) IN ('" & strFAXKBN & "','" & strBoth & "') " & vbCrLf)  ' 2011/03/10 T.Watabe edit
                whe.Append("  AND " & ReplaceHyphen("JAS.AUTO_FAXNO(+)") & " = :AUTO_FAX " & vbCrLf)
                whe.Append("  AND " & ReplaceHyphen("JAS1.AUTO_FAXNO(+)") & " = :AUTO_FAX " & vbCrLf)
                whe.Append("  AND " & ReplaceHyphen("JAS2.AUTO_FAXNO(+)") & " = :AUTO_FAX " & vbCrLf)
                whe.Append("  AND " & ReplaceHyphen("JAS3.AUTO_FAXNO(+)") & " = :AUTO_FAX " & vbCrLf)
                'whe.Append("  AND (JAS.KURACD IS NOT NULL OR JAS1.KURACD IS NOT NULL OR JAS2.KURACD IS NOT NULL OR JAS3.KURACD IS NOT NULL) " & vbCrLf)
                whe.Append("  AND (  " & vbCrLf)
                '��\JA���O����
                whe.Append("  (JAS1.AUTO_FAXNO IS NOT NULL  " & vbCrLf)
                whe.Append("    AND NOT EXISTS(  " & vbCrLf)
                whe.Append("             SELECT 'X' FROM M05_TANTO C " & vbCrLf)
                whe.Append("             WHERE " & vbCrLf)
                whe.Append("                C.KBN = '3' AND " & vbCrLf)
                whe.Append("                C.KURACD = JAS1.KURACD AND " & vbCrLf)
                whe.Append("                JAS1.CODE IS NOT NULL AND  " & vbCrLf)
                whe.Append("                C.CODE = TAI.ACBCD AND  " & vbCrLf)
                whe.Append("                C.AUTO_KBN IN ('" & strFAXKBN & "', '" & strBoth & "') AND " & vbCrLf)
                whe.Append("                C.AUTO_FAXNO IS NOT NULL AND " & vbCrLf)
                whe.Append("                REPLACE(C.AUTO_FAXNO,'-') <> REPLACE(JAS1.AUTO_FAXNO,'-') " & vbCrLf)
                whe.Append("    )   " & vbCrLf)
                whe.Append("    AND NOT EXISTS(  " & vbCrLf)
                whe.Append("             SELECT 'X' FROM M05_TANTO2 C " & vbCrLf)
                whe.Append("             WHERE " & vbCrLf)
                whe.Append("                C.KBN = '3' AND " & vbCrLf)
                whe.Append("                C.KURACD = JAS1.KURACD AND " & vbCrLf)
                whe.Append("                JAS1.CODE IS NOT NULL AND  " & vbCrLf)
                whe.Append("                C.CODE = TAI.ACBCD AND  " & vbCrLf)
                whe.Append("                C.AUTO_KBN IN ('" & strFAXKBN & "', '" & strBoth & "') AND " & vbCrLf)
                whe.Append("                C.AUTO_FAXNO IS NOT NULL AND " & vbCrLf)
                whe.Append("                REPLACE(C.AUTO_FAXNO,'-') <> REPLACE(JAS1.AUTO_FAXNO,'-') AND " & vbCrLf)
                whe.Append("                C.USER_CD_FROM = TAI.USER_CD AND C.USER_CD_TO IS NULL " & vbCrLf)
                whe.Append("    )   " & vbCrLf)
                whe.Append("    AND NOT EXISTS(  " & vbCrLf)
                whe.Append("             SELECT 'X' FROM M05_TANTO2 C " & vbCrLf)
                whe.Append("             WHERE " & vbCrLf)
                whe.Append("                C.KBN = '3' AND " & vbCrLf)
                whe.Append("                C.KURACD = JAS1.KURACD AND " & vbCrLf)
                whe.Append("                JAS1.CODE IS NOT NULL AND  " & vbCrLf)
                whe.Append("                C.CODE = TAI.ACBCD AND  " & vbCrLf)
                whe.Append("                C.AUTO_KBN IN ('" & strFAXKBN & "', '" & strBoth & "') AND " & vbCrLf)
                whe.Append("                C.AUTO_FAXNO IS NOT NULL AND " & vbCrLf)
                whe.Append("                REPLACE(C.AUTO_FAXNO,'-') <> REPLACE(JAS1.AUTO_FAXNO,'-') AND " & vbCrLf)
                whe.Append("                TAI.USER_CD BETWEEN C.USER_CD_FROM AND C.USER_CD_TO AND C.USER_CD_TO IS NOT NULL " & vbCrLf)
                whe.Append("    )   " & vbCrLf)
                whe.Append("  )   " & vbCrLf)
                '�ڋq�͈͎w�菜�O����
                whe.Append("  OR   " & vbCrLf)
                whe.Append("  (JAS3.AUTO_FAXNO IS NOT NULL  " & vbCrLf)
                whe.Append("   AND NOT EXISTS(  " & vbCrLf)
                whe.Append("             SELECT 'X' FROM M05_TANTO2 C " & vbCrLf)
                whe.Append("             WHERE " & vbCrLf)
                whe.Append("                C.KBN = '3' AND " & vbCrLf)
                whe.Append("                C.KURACD = JAS3.KURACD AND " & vbCrLf)
                whe.Append("                C.CODE = JAS3.CODE AND  " & vbCrLf)
                whe.Append("                C.AUTO_KBN IN ('" & strFAXKBN & "', '" & strBoth & "') AND " & vbCrLf)
                whe.Append("                C.AUTO_FAXNO IS NOT NULL AND " & vbCrLf)
                whe.Append("                REPLACE(C.AUTO_FAXNO,'-') <> REPLACE(JAS3.AUTO_FAXNO,'-') AND " & vbCrLf)
                whe.Append("                C.USER_CD_FROM = TAI.USER_CD AND C.USER_CD_TO IS NULL " & vbCrLf)
                whe.Append("   )   " & vbCrLf)
                whe.Append("  )   " & vbCrLf)
                'JA�x���w�菜�O����
                whe.Append("  OR   " & vbCrLf)
                whe.Append("  (JAS.AUTO_FAXNO IS NOT NULL  " & vbCrLf)
                whe.Append("   AND NOT EXISTS(  " & vbCrLf)
                whe.Append("             SELECT 'X' FROM M05_TANTO2 C " & vbCrLf)
                whe.Append("             WHERE " & vbCrLf)
                whe.Append("                C.KBN = '3' AND " & vbCrLf)
                whe.Append("                C.KURACD = JAS.KURACD AND " & vbCrLf)
                whe.Append("                C.CODE = JAS.CODE AND  " & vbCrLf)
                whe.Append("                C.AUTO_KBN IN ('" & strFAXKBN & "', '" & strBoth & "') AND " & vbCrLf)
                whe.Append("                C.AUTO_FAXNO IS NOT NULL AND " & vbCrLf)
                whe.Append("                REPLACE(C.AUTO_FAXNO,'-') <> REPLACE(JAS.AUTO_FAXNO,'-') AND " & vbCrLf)
                whe.Append("                C.USER_CD_FROM = TAI.USER_CD AND C.USER_CD_TO IS NULL " & vbCrLf)
                whe.Append("   )   " & vbCrLf)
                whe.Append("   AND NOT EXISTS(  " & vbCrLf)
                whe.Append("             SELECT 'X' FROM M05_TANTO2 C " & vbCrLf)
                whe.Append("             WHERE " & vbCrLf)
                whe.Append("                C.KBN = '3' AND " & vbCrLf)
                whe.Append("                C.KURACD = JAS.KURACD AND " & vbCrLf)
                whe.Append("                C.CODE = JAS.CODE AND  " & vbCrLf)
                whe.Append("                C.AUTO_KBN IN ('" & strFAXKBN & "', '" & strBoth & "') AND " & vbCrLf)
                whe.Append("                C.AUTO_FAXNO IS NOT NULL AND " & vbCrLf)
                whe.Append("                REPLACE(C.AUTO_FAXNO,'-') <> REPLACE(JAS.AUTO_FAXNO,'-') AND " & vbCrLf)
                whe.Append("                TAI.USER_CD BETWEEN C.USER_CD_FROM AND C.USER_CD_TO AND C.USER_CD_TO IS NOT NULL " & vbCrLf)
                whe.Append("   )  " & vbCrLf)
                whe.Append("  )   " & vbCrLf)
                '�ڋq���ڎw��
                whe.Append("  OR   " & vbCrLf)
                whe.Append("  JAS2.AUTO_FAXNO IS NOT NULL)  " & vbCrLf)
            Else '���[�����M�H
                whe.Append("  AND JAS.AUTO_KBN(+) IN ('" & strMAILKBN & "','" & strBoth & "') " & vbCrLf) ' 2011/03/10 T.Watabe edit
                whe.Append("  AND JAS1.AUTO_KBN(+) IN ('" & strMAILKBN & "','" & strBoth & "') " & vbCrLf) ' 2011/03/10 T.Watabe edit
                whe.Append("  AND JAS2.AUTO_KBN(+) IN ('" & strMAILKBN & "','" & strBoth & "') " & vbCrLf) ' 2011/03/10 T.Watabe edit
                whe.Append("  AND JAS3.AUTO_KBN(+) IN ('" & strMAILKBN & "','" & strBoth & "') " & vbCrLf) ' 2011/03/10 T.Watabe edit
                'whe.Append("  AND (JAS.KURACD IS NOT NULL OR JAS1.KURACD IS NOT NULL OR JAS2.KURACD IS NOT NULL OR JAS3.KURACD IS NOT NULL) " & vbCrLf)
                whe.Append("  AND JAS.AUTO_MAIL(+) = :AUTO_MAIL " & vbCrLf)
                whe.Append("  AND JAS1.AUTO_MAIL(+) = :AUTO_MAIL " & vbCrLf)
                whe.Append("  AND JAS2.AUTO_MAIL(+) = :AUTO_MAIL " & vbCrLf)
                whe.Append("  AND JAS3.AUTO_MAIL(+) = :AUTO_MAIL " & vbCrLf)
                whe.Append("  AND (  " & vbCrLf)
                '��\JA�w�菜�O����
                whe.Append("  (JAS1.AUTO_MAIL IS NOT NULL  " & vbCrLf)
                whe.Append("   AND NOT EXISTS(  " & vbCrLf)
                whe.Append("             SELECT 'X' FROM M05_TANTO C " & vbCrLf)
                whe.Append("             WHERE " & vbCrLf)
                whe.Append("                C.KBN = '3' AND " & vbCrLf)
                whe.Append("                C.KURACD = JAS1.KURACD AND " & vbCrLf)
                whe.Append("                JAS1.CODE IS NOT NULL AND  " & vbCrLf)
                whe.Append("                C.CODE = TAI.ACBCD AND  " & vbCrLf)
                whe.Append("                C.AUTO_KBN IN ('" & strMAILKBN & "', '" & strBoth & "') AND " & vbCrLf)
                whe.Append("                C.AUTO_MAIL <> JAS1.AUTO_MAIL AND " & vbCrLf)
                whe.Append("                C.AUTO_MAIL IS NOT NULL  " & vbCrLf)
                whe.Append("   )   " & vbCrLf)
                whe.Append("   AND NOT EXISTS(  " & vbCrLf)
                whe.Append("             SELECT 'X' FROM M05_TANTO2 C " & vbCrLf)
                whe.Append("             WHERE " & vbCrLf)
                whe.Append("                C.KBN = '3' AND " & vbCrLf)
                whe.Append("                C.KURACD = JAS1.KURACD AND " & vbCrLf)
                whe.Append("                JAS1.CODE IS NOT NULL AND  " & vbCrLf)
                whe.Append("                C.CODE = TAI.ACBCD AND  " & vbCrLf)
                whe.Append("                C.AUTO_KBN IN ('" & strMAILKBN & "', '" & strBoth & "') AND " & vbCrLf)
                whe.Append("                C.AUTO_MAIL IS NOT NULL AND " & vbCrLf)
                whe.Append("                C.AUTO_MAIL <> JAS1.AUTO_MAIL AND " & vbCrLf)
                whe.Append("                C.USER_CD_FROM = TAI.USER_CD AND C.USER_CD_TO IS NULL " & vbCrLf)
                whe.Append("   )   " & vbCrLf)
                whe.Append("   AND NOT EXISTS(  " & vbCrLf)
                whe.Append("             SELECT 'X' FROM M05_TANTO2 C " & vbCrLf)
                whe.Append("             WHERE " & vbCrLf)
                whe.Append("                C.KBN = '3' AND " & vbCrLf)
                whe.Append("                C.KURACD = JAS1.KURACD AND " & vbCrLf)
                whe.Append("                JAS1.CODE IS NOT NULL AND  " & vbCrLf)
                whe.Append("                C.CODE = TAI.ACBCD AND  " & vbCrLf)
                whe.Append("                C.AUTO_KBN IN ('" & strMAILKBN & "', '" & strBoth & "') AND " & vbCrLf)
                whe.Append("                C.AUTO_MAIL IS NOT NULL AND " & vbCrLf)
                whe.Append("                C.AUTO_MAIL <> JAS1.AUTO_MAIL AND " & vbCrLf)
                whe.Append("                TAI.USER_CD BETWEEN C.USER_CD_FROM AND C.USER_CD_TO AND C.USER_CD_TO IS NOT NULL " & vbCrLf)
                whe.Append("   )   " & vbCrLf)
                whe.Append("  )   " & vbCrLf)
                '�ڋq�͈͎w�菜�O����
                whe.Append("  OR   " & vbCrLf)
                whe.Append("  (JAS3.AUTO_MAIL IS NOT NULL  " & vbCrLf)
                whe.Append("   AND NOT EXISTS(  " & vbCrLf)
                whe.Append("             SELECT 'X' FROM M05_TANTO2 C " & vbCrLf)
                whe.Append("             WHERE " & vbCrLf)
                whe.Append("                C.KBN = '3' AND " & vbCrLf)
                whe.Append("                C.KURACD = JAS3.KURACD AND " & vbCrLf)
                whe.Append("                C.CODE = JAS3.CODE AND  " & vbCrLf)
                whe.Append("                C.AUTO_KBN IN ('" & strMAILKBN & "', '" & strBoth & "') AND " & vbCrLf)
                whe.Append("                C.AUTO_MAIL IS NOT NULL AND " & vbCrLf)
                whe.Append("                C.AUTO_MAIL <> JAS3.AUTO_MAIL AND " & vbCrLf)
                whe.Append("                C.USER_CD_FROM = TAI.USER_CD AND C.USER_CD_TO IS NULL " & vbCrLf)
                whe.Append("   )   " & vbCrLf)
                whe.Append("  )   " & vbCrLf)
                'JA�x���w�菜�O����
                whe.Append("  OR   " & vbCrLf)
                whe.Append("  (JAS.AUTO_MAIL IS NOT NULL  " & vbCrLf)
                whe.Append("   AND NOT EXISTS(  " & vbCrLf)
                whe.Append("             SELECT 'X' FROM M05_TANTO2 C " & vbCrLf)
                whe.Append("             WHERE " & vbCrLf)
                whe.Append("                C.KBN = '3' AND " & vbCrLf)
                whe.Append("                C.KURACD = JAS.KURACD AND " & vbCrLf)
                whe.Append("                C.CODE = JAS.CODE AND  " & vbCrLf)
                whe.Append("                C.AUTO_KBN IN ('" & strMAILKBN & "', '" & strBoth & "') AND " & vbCrLf)
                whe.Append("                C.AUTO_MAIL IS NOT NULL AND " & vbCrLf)
                whe.Append("                C.AUTO_MAIL <> JAS.AUTO_MAIL AND " & vbCrLf)
                whe.Append("                C.USER_CD_FROM = TAI.USER_CD AND C.USER_CD_TO IS NULL " & vbCrLf)
                whe.Append("   )   " & vbCrLf)
                whe.Append("   AND NOT EXISTS(  " & vbCrLf)
                whe.Append("             SELECT 'X' FROM M05_TANTO2 C " & vbCrLf)
                whe.Append("             WHERE " & vbCrLf)
                whe.Append("                C.KBN = '3' AND " & vbCrLf)
                whe.Append("                C.KURACD = JAS.KURACD AND " & vbCrLf)
                whe.Append("                C.CODE = JAS.CODE AND  " & vbCrLf)
                whe.Append("                C.AUTO_KBN IN ('" & strMAILKBN & "', '" & strBoth & "') AND " & vbCrLf)
                whe.Append("                C.AUTO_MAIL IS NOT NULL AND " & vbCrLf)
                whe.Append("                C.AUTO_MAIL <> JAS.AUTO_MAIL AND " & vbCrLf)
                whe.Append("                TAI.USER_CD BETWEEN C.USER_CD_FROM AND C.USER_CD_TO AND C.USER_CD_TO IS NOT NULL " & vbCrLf)
                whe.Append("   )   " & vbCrLf)
                whe.Append("  )   " & vbCrLf)
                '�ڋq���ڎw��
                whe.Append("  OR   " & vbCrLf)
                whe.Append("  JAS2.AUTO_MAIL IS NOT NULL)  " & vbCrLf)
            End If
            whe.Append("  AND JAS.CODE(+) <> 'XXXX' " & vbCrLf)
            whe.Append("  AND JAS1.CODE(+) <> 'XXXX' " & vbCrLf)
            whe.Append("  AND JAS.KBN(+) = '3' " & vbCrLf)
            whe.Append("  AND JAS1.KBN(+) = '3' " & vbCrLf)
            whe.Append("  AND JAS2.KBN(+) = '3' " & vbCrLf)
            whe.Append("  AND JAS3.KBN(+) = '3' " & vbCrLf)
            whe.Append("  AND TAI.KURACD = JAS.KURACD(+) " & vbCrLf)
            whe.Append("  AND TAI.ACBCD = JAS.CODE(+) " & vbCrLf)
            whe.Append("  AND TAI.KURACD = JAS1.KURACD(+) " & vbCrLf)
            'whe.Append("  AND SUBSTR(TAI.ACBCD,1,4) = JAS1.CODE(+) " & vbCrLf) ' 2013/09/09 T.Watabe edit
            'whe.Append("  AND LENGTHB(JAS1.CODE(+)) = 4 " & vbCrLf) ' 2013/09/09 T.Watabe edit
            whe.Append("  AND TAI.JACD = JAS1.CODE(+) " & vbCrLf)
            whe.Append("  AND TAI.KURACD = JAS2.KURACD(+) " & vbCrLf)
            whe.Append("  AND TAI.ACBCD = JAS2.CODE(+) " & vbCrLf)
            whe.Append("  AND TAI.USER_CD = JAS2.USER_CD_FROM(+) " & vbCrLf)
            whe.Append("  AND JAS2.USER_CD_TO(+) IS NULL " & vbCrLf)
            whe.Append("  AND TAI.KURACD = JAS3.KURACD(+) " & vbCrLf)
            whe.Append("  AND TAI.ACBCD = JAS3.CODE(+) " & vbCrLf)
            whe.Append("  AND TAI.USER_CD BETWEEN JAS3.USER_CD_FROM(+) AND JAS3.USER_CD_TO(+) " & vbCrLf)
            whe.Append("  AND JAS3.USER_CD_TO(+) IS NOT NULL " & vbCrLf)
            whe.Append("  AND TAI.KURACD = JAS4.CLI_CD(+) " & vbCrLf)
            whe.Append("  AND TAI.ACBCD = JAS4.HAN_CD(+) " & vbCrLf)
            whe.Append("  AND SUBSTR(JAS4.CLI_CD,2,2) = KYO.KEN_CD(+) " & vbCrLf)
            whe.Append("  AND JAS4.HAISO_CD = KYO.HAISO_CD(+) " & vbCrLf)

            ord.Append("    HATYMDT " & vbCrLf) ' 2011/05/27 T.Watabe add �\�[�g��̔��X�ƃN���C�A���g�ŕς���

        Else '2:�ײ��āH

            sel.Append("    ,P.AUTO_MAIL_PASS AS YOBI5 " & vbCrLf) ' �p�X���[�h 2010/10/25 T.Watabe add
            sel.Append("    ,TAI.JACD AS JA_CD " & vbCrLf) ' 2011/05/27 T.Watabe add 

            fro.Append("    ,M05_TANTO P " & vbCrLf)
            fro.Append("    ,HN2MAS JAS " & vbCrLf)

            whe.Append("  AND P.KBN              = '3' " & vbCrLf)
            whe.Append("  AND P.KURACD = TAI.KURACD  " & vbCrLf)
            whe.Append("  AND P.CODE = 'XXXX' " & vbCrLf)
            If pstrAUTO = strFAXKBN Then '�e�`�w���M�H
                whe.Append("  AND P.AUTO_KBN IN ('" & strFAXKBN & "','" & strBoth & "') " & vbCrLf)  ' 2011/03/10 T.Watabe edit
                whe.Append("  AND " & ReplaceHyphen("P.AUTO_FAXNO") & " = :AUTO_FAX " & vbCrLf)
            Else '���[�����M�H
                whe.Append("  AND P.AUTO_KBN IN ('" & strMAILKBN & "','" & strBoth & "') " & vbCrLf)  ' 2011/03/10 T.Watabe edit
                whe.Append("  AND P.AUTO_MAIL = :AUTO_MAIL " & vbCrLf)
            End If
            whe.Append("  AND TAI.KURACD = JAS.CLI_CD(+) " & vbCrLf)
            whe.Append("  AND TAI.ACBCD = JAS.HAN_CD(+) " & vbCrLf)
            whe.Append("  AND SUBSTR(JAS.CLI_CD,2,2) = KYO.KEN_CD(+) " & vbCrLf)
            whe.Append("  AND JAS.HAISO_CD = KYO.HAISO_CD(+) " & vbCrLf)

            ord.Append("    CLI_CD, JA_CD, HATYMDT " & vbCrLf) ' 2011/05/27 T.Watabe add �\�[�g��̔��X�ƃN���C�A���g�ŕς���

        End If
        Dim faxUser As String = ""
        Try
            mlog(pstrSESSION & "\" & pstrKANSI_CODE & "\" & pstrKURACD_F & "\" & pstrKURACD_T, "BTFAXJAX00:mExcelOut�F3") '2014/04/11 T.Ono add ���O����
            '//------------------------------------------------
            ' �f�[�^��SELECT
            '//------------------------------------------------
            strSQL = New StringBuilder("")
            'SQL�쐬�J�n
            strSQL.Append("SELECT " & vbCrLf)
            strSQL.Append("    CLI.CLI_CD,  " & vbCrLf) '2011/03/10 T.Watabe add
            strSQL.Append("    CLI.CLI_NAME,  " & vbCrLf) '2011/05/27 T.Watabe add
            strSQL.Append("    KOK.USER_CD SH_USER, " & vbCrLf)
            strSQL.Append("    TAI.JACD,  " & vbCrLf) '2013/09/25 T.Watabe add
            strSQL.Append("    TAI.JANM, " & vbCrLf)
            strSQL.Append("    TAI.ACBNM, " & vbCrLf)
            strSQL.Append("    TAI.KENNM, " & vbCrLf)
            strSQL.Append("    KYO.NAME, " & vbCrLf)
            strSQL.Append("    TAI.JUSYONM, " & vbCrLf)
            strSQL.Append("    TAI.ACBCD, " & vbCrLf)
            strSQL.Append("    TAI.USER_CD, " & vbCrLf)
            strSQL.Append("    TAI.KTELNO, " & vbCrLf)
            strSQL.Append("    TAI.SDNM, " & vbCrLf)
            strSQL.Append("    TAI.JUTEL1, " & vbCrLf)
            strSQL.Append("    TAI.JUTEL2, " & vbCrLf)
            strSQL.Append("    KOK.USER_FLG, " & vbCrLf)
            strSQL.Append("    TAI.RENTEL, " & vbCrLf)
            strSQL.Append("    TAI.ADDR, " & vbCrLf)
            strSQL.Append("    KOK.GAS_STOP AS GAS_START, " & vbCrLf)
            strSQL.Append("    KOK.GAS_DELE, " & vbCrLf)
            strSQL.Append("    TAI.TIZUNO, " & vbCrLf)
            strSQL.Append("    KOK.SHUGOU, " & vbCrLf)
            strSQL.Append("    TAI.NCU_SET, " & vbCrLf)
            strSQL.Append("    TAI.HATYMD, " & vbCrLf)
            strSQL.Append("    TAI.HATTIME, " & vbCrLf)
            strSQL.Append("    TAI.KENSIN, " & vbCrLf)
            strSQL.Append("    TAI.RYURYO, " & vbCrLf)
            strSQL.Append("    TAI.METASYU, " & vbCrLf)
            strSQL.Append("    TAI.KMNM1, " & vbCrLf)
            strSQL.Append("    TAI.KMNM2, " & vbCrLf)
            strSQL.Append("    TAI.KMNM3, " & vbCrLf)
            strSQL.Append("    TAI.KMNM4, " & vbCrLf)
            strSQL.Append("    TAI.KMNM5, " & vbCrLf)
            strSQL.Append("    TAI.KMNM6, " & vbCrLf)
            strSQL.Append("    TAI.MITOKBN, " & vbCrLf)
            strSQL.Append("    TAI.TAIOKBN_NAI, " & vbCrLf)
            strSQL.Append("    TAI.TMSKB_NAI, " & vbCrLf)
            strSQL.Append("    TAI.SYONO, " & vbCrLf)
            strSQL.Append("    TAI.TKTANCD_NM, " & vbCrLf)
            strSQL.Append("    TAI.SYOYMD, " & vbCrLf)
            strSQL.Append("    TAI.SYOTIME, " & vbCrLf)
            strSQL.Append("    TAI.TAITNM, " & vbCrLf)
            strSQL.Append("    TAI.TELRNM, " & vbCrLf)
            strSQL.Append("    TAI.FUK_MEMO, " & vbCrLf)
            strSQL.Append("    TAI.TEL_MEMO1, " & vbCrLf)
            strSQL.Append("    TAI.TEL_MEMO2, " & vbCrLf)
            strSQL.Append("    TAI.TKIGNM, " & vbCrLf)
            strSQL.Append("    TAI.TSADNM, " & vbCrLf)
            strSQL.Append("    TAI.SIJIYMD, " & vbCrLf) '2015/03/06 T.Ono add 2014���P�J�� No16
            strSQL.Append("    TAI.SIJITIME, " & vbCrLf) '2015/03/06 T.Ono add 2014���P�J�� No16
            strSQL.Append("    TAI.SIJI_BIKO1, " & vbCrLf)
            strSQL.Append("    TAI.SIJI_BIKO2, " & vbCrLf)
            strSQL.Append("    TAI.SYUTDTNM, " & vbCrLf)
            strSQL.Append("    TAI.STD_KYOTEN, " & vbCrLf)
            strSQL.Append("    TAI.TSTANNM, " & vbCrLf)
            strSQL.Append("    TAI.TYAKYMD, " & vbCrLf)
            strSQL.Append("    TAI.TYAKTIME, " & vbCrLf)
            strSQL.Append("    TAI.SYOKANYMD, " & vbCrLf)
            strSQL.Append("    TAI.SYOKANTIME, " & vbCrLf)
            strSQL.Append("    TAI.AITNM, " & vbCrLf)
            strSQL.Append("    TAI.SDTBIK1, " & vbCrLf)
            strSQL.Append("    TAI.FKINM, " & vbCrLf)
            strSQL.Append("    TAI.KIGTAIYO, " & vbCrLf)
            strSQL.Append("    TAI.JAKENREN, " & vbCrLf)
            strSQL.Append("    TAI.RENTIME, " & vbCrLf)
            strSQL.Append("    TAI.GASMUMU, " & vbCrLf)
            strSQL.Append("    TAI.ORGENIN, " & vbCrLf)
            strSQL.Append("    TAI.GASGUMU, " & vbCrLf)
            strSQL.Append("    TAI.HOSKOKAN, " & vbCrLf)
            strSQL.Append("    TAI.METYOINA, " & vbCrLf)
            strSQL.Append("    TAI.TYOUYOINA, " & vbCrLf)
            strSQL.Append("    TAI.VALYOINA, " & vbCrLf)
            strSQL.Append("    TAI.KYUHAIUMU, " & vbCrLf)
            strSQL.Append("    TAI.COYOINA, " & vbCrLf)
            strSQL.Append("    TAI.SDTBIK2, " & vbCrLf)
            strSQL.Append("    TAI.SDTBIK3, " & vbCrLf)
            strSQL.Append("    TAI.SNTTOKKI, " & vbCrLf)
            strSQL.Append("    TAI.METFUKKI, " & vbCrLf)
            strSQL.Append("    TAI.HOAN, " & vbCrLf)
            strSQL.Append("    TAI.GASGIRE, " & vbCrLf)
            strSQL.Append("    TAI.KIGKOSYO, " & vbCrLf)
            strSQL.Append("    TAI.CSNTGEN, " & vbCrLf)
            strSQL.Append("    TAI.CSNTNGAS, " & vbCrLf)
            strSQL.Append("    TAI.SDTBIK1, " & vbCrLf)
            strSQL.Append("    TAI.STD_CD, " & vbCrLf)               '--- 2005/05/23 ADD Falcon
            strSQL.Append("    TAI.STD, " & vbCrLf)                  '--- 2005/05/23 ADD Falcon
            strSQL.Append("    TAI.TAIOKBN, " & vbCrLf)              '--- 2005/05/25 ADD Falcon
            strSQL.Append("    TAI.TFKICD, " & vbCrLf)               '--- 2005/07/13 ADD Falcon
            strSQL.Append("    PL3.NAME AS SHUGOUNM, " & vbCrLf)
            strSQL.Append("    PL5.NAME AS RYURYONM " & vbCrLf)
            strSQL.Append("    ,TAI.HATYMD || '-' || TAI.HATTIME AS HATYMDT " & vbCrLf)    ' 2007/09/18 T.Watabe add
            strSQL.Append("    ,TAI.SIJIYMD " & vbCrLf)  ' �o���w����        2008/10/14 T.Watabe add
            strSQL.Append("    ,TAI.SIJITIME " & vbCrLf) ' �o���w������      2008/10/14 T.Watabe add
            strSQL.Append("    ,TAI.SDYMD " & vbCrLf)    ' �o����            2008/10/14 T.Watabe add
            strSQL.Append("    ,TAI.SDTIME " & vbCrLf)   ' �o������          2008/10/14 T.Watabe add
            strSQL.Append("    ,TAI.KIGNM " & vbCrLf)    ' �K�X���          2008/10/14 T.Watabe add 
            strSQL.Append("    ,TAI.SADNM " & vbCrLf)    ' ���[�^�쓮�����P  2008/10/14 T.Watabe add
            strSQL.Append("    ,TAI.SDSKBN_NAI " & vbCrLf)  ' �o����Џ����敪�E���e ' 2008/10/21 T.Watabe add
            strSQL.Append(sel) ' �p�X���[�h 2008/12/12 T.Watabe add
            strSQL.Append("FROM CLIMAS CLI, " & vbCrLf)
            strSQL.Append("     D20_TAIOU_COPY TAI, " & vbCrLf)
            strSQL.Append("     HAIMAS KYO, " & vbCrLf)
            strSQL.Append("     SHAMAS KOK, " & vbCrLf)
            strSQL.Append("     M06_PULLDOWN PL3, " & vbCrLf)
            strSQL.Append("     M06_PULLDOWN PL5 " & vbCrLf)
            strSQL.Append(fro)
            strSQL.Append("WHERE " & vbCrLf)
            strSQL.Append("    CLI.KANSI_CODE = '" & pstrKANSI_CODE & "'  " & vbCrLf)
            strSQL.Append("AND CLI.CLI_CD     = TAI.KURACD ")
            strSQL.Append(whe)
            strSQL.Append(pstrWHERE_TAIOU.ToString)
            strSQL.Append("  AND TAI.KURACD   = KOK.CLI_CD(+) " & vbCrLf)
            strSQL.Append("  AND TAI.ACBCD    = KOK.HAN_CD(+) " & vbCrLf)
            strSQL.Append("  AND TAI.USER_CD  = KOK.USER_CD(+) " & vbCrLf)
            strSQL.Append("  AND '03'         = PL3.KBN(+) " & vbCrLf)
            strSQL.Append("  AND KOK.SHUGOU   = PL3.CD(+) " & vbCrLf)
            strSQL.Append("  AND '05'         = PL5.KBN(+) " & vbCrLf)
            strSQL.Append("  AND TAI.RYURYO   = PL5.CD(+) " & vbCrLf)
            strSQL.Append("ORDER BY " & vbCrLf)
            strSQL.Append(ord) ' 2007/09/18 T.Watabe add �\�[�g�������������������̂Œǉ�

            If pintDebugSQLNo = 3 Or (pintDebugSQLNo >= 2000 And pintDebugSQLNo <= 2999) Then
                If pstrAUTO = strFAXKBN Then
                    Return "DEBUG[" & strSQL.ToString & "]"
                End If
            End If
            If pintDebugSQLNo = 4 Or (pintDebugSQLNo >= 3000 And pintDebugSQLNo <= 3999) Then
                If pstrAUTO <> strFAXKBN Then
                    Return "DEBUG[" & strSQL.ToString & "]"
                End If
            End If

            mlog(pstrSESSION & "\" & pstrKANSI_CODE & "\" & pstrKURACD_F & "\" & pstrKURACD_T, "BTFAXJAX00:mExcelOut�F4") '2014/04/11 T.Ono add ���O����
            cdb.pSQL = strSQL.ToString '//SQL�Z�b�g

            '//�p�����[�^�̃Z�b�g
            If pstrAUTO = strFAXKBN Then
                cdb.pSQLParamStr("AUTO_FAX") = pstrFAXNO '�e�`�w���M�̏ꍇ
            Else
                cdb.pSQLParamStr("AUTO_MAIL") = pstrMAILAD '���[�����M�̏ꍇ
            End If

            cdb.mExecQuery() '//SQL���s
            ds = cdb.pResult  '//�f�[�^�Z�b�g�Ɋi�[

            If pintDebugSQLNo = 104 Then ' DEBUG
                Return "DEBUG:(" & pintDebugSQLNo & ")[" & strSQL.ToString & "]" & pstrFAXNO & "|" & pstrMAILAD
            End If

            mlog(pstrSESSION & "\" & pstrKANSI_CODE & "\" & pstrKURACD_F & "\" & pstrKURACD_T, "BTFAXJAX00:mExcelOut�F5 count:" & ds.Tables(0).Rows.Count) '2014/04/11 T.Ono add ���O����
            '//------------------------------------------------
            '// �t�@�C���̍쐬�P�i��{���ݒ�j
            '//------------------------------------------------
            If True Then
                ExcelC.pKencd = "00"            '���R�[�h���Z�b�g
                ExcelC.pSessionID = pstrSESSION '�Z�b�V����ID�@���������t���d�b�ԍ���ݒ肷��
                ExcelC.pRepoID = strPGID        '���[ID
                ExcelC.pLandScape = False       '���[�c
                ExcelC.mOpen()                  '�t�@�C���I�[�v��
                '�^�C�g��
                '2014/03/20 T.Ono mod FAX�^�C�g���ύX�v�]�@FAX�E���[�����ʂ�
                'If pstrAUTO = strFAXKBN Then
                '    '�e�`�w���M�̏ꍇ
                '    ExcelC.pTitle = "�Ď��Z���^�[�Ή����e���ׁi�e�`�w�j"
                'Else
                '    '���[�����M�̏ꍇ
                '    ExcelC.pTitle = "�Ď��Z���^�[�Ή����e���ׁi���[���j"
                'End If
                ExcelC.pTitle = "�Ď��Z���^�[�Ή����ʖ��ׁi���񍐁j"
                'If pintDebugSQLNo = 0 Then '2013/10/01 T.Watabe edit �f�o�b�O���͒��[�̉E��쐬�����w�肵�����t�ɂ���B
                '    ExcelC.pDate = DateFncC.mGet(Now.ToString("yyyyMMdd")) '�쐬��
                'Else
                '    ExcelC.pDate = DateFncC.mGet(pstrTAISYOUBI) '�쐬��
                'End If
                ExcelC.pDate = DateFncC.mGet(pstrTAISYOUBI) '�쐬��
                'ExcelC.pScale = 95               '�k���g�嗦 2013/11/26 T.Ono del
                If pstrSEND_KBN = "2" Then '2:�N���C�A���g�̖ڈ���t�b�^�֕t����
                    ExcelC.pFooter = "&R ."
                Else
                    'ExcelC.pFooter = "&R &P \/ " & pintCNT & " "
                End If

                '�]��
                '2005/10/03 NEC UPDATE
                '2005/12/22 NEC UPDATE
                '2006/06/21 NEC UPDATE 
                ExcelC.pMarginTop = 1.8D
                ExcelC.pMarginBottom = 0.5D
                ExcelC.pMarginLeft = 1.2D
                ExcelC.pMarginRight = 1.5D
                ExcelC.pMarginHeader = 1D
                'ExcelC.pMarginFooter = 1D ' 2010/10/06 T.Watabe edit
                ExcelC.pMarginFooter = 0.5D
            End If

            If ds.Tables(0).Rows.Count = 0 Then  '//�f�[�^�����݂��Ȃ��H

                '�P �[�����ŁA�[�������M�̏ꍇ�B

                If pintDebugSQLNo = 105 Then ' DEBUG
                    Return "DEBUG:(" & pintDebugSQLNo & ")[" & strSQL.ToString & "]" & pstrFAXNO & "|" & pstrMAILAD
                End If

                wheC = New StringBuilder("")
                wheJ = New StringBuilder("")

                '�N���C�A���g�R�[�h�͈͎̔w���ǉ�
                If pstrKURACD_F.Length > 0 Then
                    wheC.Append("  AND CLI.CLI_CD >= '" & pstrKURACD_F & "' " & vbCrLf)
                    wheJ.Append("  AND TAN.KURACD >= '" & pstrKURACD_F & "' " & vbCrLf)
                End If
                If pstrKURACD_T.Length > 0 Then
                    wheC.Append("  AND CLI.CLI_CD <= '" & pstrKURACD_T & "' " & vbCrLf)
                    wheJ.Append("  AND TAN.KURACD <= '" & pstrKURACD_T & "' " & vbCrLf)
                End If


                'Return "DATA0" '//�f�[�^��0���ł��邱�Ƃ������������Ԃ�
                '-------------
                ' �}�X�^���擾
                '-------------
                strSQL = New StringBuilder("")
                If pstrSEND_KBN = "1" Then '1:�̔����H
                    strSQL.Append("SELECT DISTINCT " & vbCrLf)
                    strSQL.Append("    CLI.CLI_CD,  " & vbCrLf)
                    strSQL.Append("    JAS.JA_NAME AS JANM,  " & vbCrLf)
                    strSQL.Append("    KYO.NAME AS CENTER_NAME, " & vbCrLf)
                    strSQL.Append("    CLI.KEN_NAME, " & vbCrLf)
                    strSQL.Append("    KAN.TEL, " & vbCrLf)
                    strSQL.Append("    TAN.AUTO_MAIL_PASS AS YOBI5 " & vbCrLf)
                    strSQL.Append("FROM  " & vbCrLf)
                    strSQL.Append("    CLIMAS CLI, " & vbCrLf)
                    strSQL.Append("    ( " & vbCrLf)
                    strSQL.Append("      SELECT  " & vbCrLf)
                    strSQL.Append("        KURACD, " & vbCrLf)
                    strSQL.Append("        CODE AS HAN_CD, " & vbCrLf)
                    strSQL.Append("        AUTO_MAIL_PASS  " & vbCrLf)
                    strSQL.Append("      FROM " & vbCrLf)
                    strSQL.Append("        M05_TANTO2 TAN " & vbCrLf)
                    strSQL.Append("      WHERE KBN = '3' " & vbCrLf)
                    strSQL.Append(wheJ)
                    strSQL.Append("      AND TAN.AUTO_ZERO_FLG   = '1' " & vbCrLf)
                    If pstrAUTO = "1" Then '1:FAX���M
                        strSQL.Append("  AND TAN.AUTO_KBN IN ('" & strFAXKBN & "','" & strBoth & "') " & vbCrLf)
                        strSQL.Append("  AND " & ReplaceHyphen("TAN.AUTO_FAXNO(+)") & " = '" & pstrFAXNO & "' " & vbCrLf)
                    Else
                        strSQL.Append("  AND TAN.AUTO_KBN IN ('" & strMAILKBN & "','" & strBoth & "') " & vbCrLf)
                        strSQL.Append("  AND AUTO_MAIL = '" & pstrMAILAD & "' " & vbCrLf)
                    End If
                    strSQL.Append("      UNION  " & vbCrLf)
                    strSQL.Append("      SELECT  " & vbCrLf)
                    strSQL.Append("        KURACD, " & vbCrLf)
                    strSQL.Append("        CODE AS HAN_CD, " & vbCrLf)
                    strSQL.Append("        AUTO_MAIL_PASS  " & vbCrLf)
                    strSQL.Append("      FROM " & vbCrLf)
                    strSQL.Append("        M05_TANTO TAN " & vbCrLf)
                    strSQL.Append("      WHERE KBN = '3' " & vbCrLf)
                    strSQL.Append("      AND TAN.CODE <> 'XXXX' " & vbCrLf)
                    strSQL.Append(wheJ)
                    strSQL.Append("      AND TAN.AUTO_ZERO_FLG   = '1' " & vbCrLf)
                    If pstrAUTO = "1" Then '1:FAX���M
                        strSQL.Append("  AND TAN.AUTO_KBN IN ('" & strFAXKBN & "','" & strBoth & "') " & vbCrLf)
                        strSQL.Append("  AND " & ReplaceHyphen("TAN.AUTO_FAXNO(+)") & " = '" & pstrFAXNO & "' " & vbCrLf)
                    Else
                        strSQL.Append("  AND TAN.AUTO_KBN IN ('" & strMAILKBN & "','" & strBoth & "') " & vbCrLf)
                        strSQL.Append("  AND AUTO_MAIL = '" & pstrMAILAD & "' " & vbCrLf)
                    End If
                    strSQL.Append("    ) TAN, " & vbCrLf)
                    strSQL.Append("    HN2MAS JAS, " & vbCrLf)
                    strSQL.Append("    HAIMAS KYO, " & vbCrLf)
                    strSQL.Append("    KANSIMAS KAN " & vbCrLf)
                    strSQL.Append("WHERE " & vbCrLf)
                    strSQL.Append("        CLI.KANSI_CODE  = '" & pstrKANSI_CODE & "' " & vbCrLf)
                    strSQL.Append("    AND CLI.CLI_CD      = TAN.KURACD " & vbCrLf)
                    strSQL.Append("    AND TAN.KURACD      = JAS.CLI_CD(+) " & vbCrLf)
                    strSQL.Append("    AND TAN.HAN_CD      = JAS.HAN_CD(+) " & vbCrLf)
                    strSQL.Append("    AND SUBSTR(JAS.CLI_CD,2,2) = KYO.KEN_CD(+) " & vbCrLf)
                    strSQL.Append("    AND JAS.HAISO_CD    = KYO.HAISO_CD(+) " & vbCrLf)
                    strSQL.Append("    AND CLI.KANSI_CODE  = KAN.KANSI_CD (+)" & vbCrLf)
                    strSQL.Append(wheC) ' 2011/05/26 T.Watabe edit

                    'strSQL.Append("ORDER BY CLI_CD, JA_CD, HAN_CD ") ' 2011/05/26 T.Watabe edit

                Else '2:�ײ��āH
                    strSQL.Append("SELECT DISTINCT " & vbCrLf)
                    strSQL.Append("    CLI.CLI_CD,  " & vbCrLf) '2011/03/10 T.Watabe add
                    strSQL.Append("    '' AS JANM,  " & vbCrLf) '2011/05/19 T.Watabe add
                    strSQL.Append("    CLI.CLI_NAME AS CENTER_NAME, " & vbCrLf)
                    strSQL.Append("    CLI.KEN_NAME, " & vbCrLf)
                    strSQL.Append("    KAN.TEL, " & vbCrLf)
                    strSQL.Append("    P.AUTO_MAIL_PASS AS YOBI5 " & vbCrLf) ' �p�X���[�h '2011/05/26 T.Watabe add
                    strSQL.Append("FROM " & vbCrLf)
                    strSQL.Append("    CLIMAS CLI, " & vbCrLf)
                    strSQL.Append("    M05_TANTO P, " & vbCrLf)
                    strSQL.Append("    KANSIMAS KAN " & vbCrLf)
                    strSQL.Append("WHERE " & vbCrLf)
                    strSQL.Append("        CLI.KANSI_CODE  = '" & pstrKANSI_CODE & "' " & vbCrLf)
                    strSQL.Append("    AND P.KBN = '3' " & vbCrLf)
                    strSQL.Append("    AND P.KURACD = CLI.CLI_CD  " & vbCrLf)
                    strSQL.Append("    AND P.CODE = 'XXXX'  " & vbCrLf)
                    strSQL.Append("    AND P.AUTO_ZERO_FLG   = '1' " & vbCrLf)
                    If pstrAUTO = "1" Then
                        strSQL.Append("  AND P.AUTO_KBN IN ('" & strFAXKBN & "','" & strBoth & "') " & vbCrLf)
                        strSQL.Append("  AND " & ReplaceHyphen("P.AUTO_FAXNO") & " = '" & pstrFAXNO & "' " & vbCrLf)
                    Else
                        strSQL.Append("  AND P.AUTO_KBN IN ('" & strMAILKBN & "','" & strBoth & "') " & vbCrLf)
                        strSQL.Append("  AND P.AUTO_MAIL = '" & pstrMAILAD & "' " & vbCrLf)
                    End If
                    strSQL.Append("    AND KAN.KANSI_CD (+)= CLI.KANSI_CODE " & vbCrLf)
                    strSQL.Append(wheC) ' 2011/05/26 T.Watabe edit
                End If

                ' DEBUG
                If pintDebugSQLNo = 5 Or (pintDebugSQLNo >= 4000 And pintDebugSQLNo <= 4999) Then
                    If pstrAUTO = strFAXKBN Then
                        Return "DEBUG[" & strSQL.ToString & "]"
                    End If
                End If
                If pintDebugSQLNo = 6 Or (pintDebugSQLNo >= 5000 And pintDebugSQLNo <= 5999) Then
                    If pstrAUTO <> strFAXKBN Then
                        Return "DEBUG[" & strSQL.ToString & "]"
                    End If
                End If
                cdb.pSQL = strSQL.ToString   '//SQL�Z�b�g
                cdb.mExecQuery() '//SQL���s

                Dim dsInfo As New DataSet
                Dim drInfo As DataRow
                dsInfo = cdb.pResult  '//�f�[�^�Z�b�g�Ɋi�[

                Dim kenName As String = ""
                Dim jalpTel As String = ""

                If pintDebugSQLNo = 106 Then ' DEBUG
                    Return "DEBUG:(" & pintDebugSQLNo & ")[" & strSQL.ToString & "]"
                End If

                If dsInfo.Tables(0).Rows.Count > 0 Then  '//�f�[�^�����݂���H
                    drInfo = dsInfo.Tables(0).Rows(0)
                    kenName = Convert.ToString(drInfo.Item("KEN_NAME"))
                    centerName = Convert.ToString(drInfo.Item("CENTER_NAME"))
                    jalpTel = Convert.ToString(drInfo.Item("TEL"))
                    cliCd4FileHead = Convert.ToString(drInfo.Item("CLI_CD")) '2011/03/10 T.Watabe add
                    jaName4FileHead = Convert.ToString(drInfo.Item("JANM")).Replace(" ", "") '2011/05/19 T.Watabe add
                    sZipFilePass = Convert.ToString(drInfo.Item("YOBI5")) ' 2011/05/26 T.Watabe add
                End If

                Dim taisyoDate As String = fncAdd_Date(pstrTAISYOUBI, -1)
                taisyoDate = taisyoDate.Substring(0, 4) & "/" & taisyoDate.Substring(4, 2) & "/" & taisyoDate.Substring(6, 2)
                faxUser = pstrFAXNO & jaName4FileHead

                '//------------------------------------------------
                '// �t�@�C���̍쐬�Q�i�f�[�^�ݒ�j
                '//------------------------------------------------
                ExcelC.mHeader(intGYOSU, 30, 1)

                '�e��̕����s�N�Z���ŃZ�b�g�B�g���������B
                '1�s��
                ExcelC.pCellStyle(1) = "width:32px;border-style:none"
                ExcelC.pCellStyle(2) = "width:122px;border-style:none"
                ExcelC.pCellStyle(3) = "width:72px;border-style:none"
                ExcelC.pCellStyle(4) = "width:72px;border-style:none"

                ExcelC.pCellStyle(5) = "width:90px;border-style:none"
                ExcelC.pCellStyle(6) = "width:115px;border-style:none"
                ExcelC.pCellStyle(7) = "width:72px;border-style:none"
                ExcelC.pCellStyle(8) = "width:52px;border-style:none"
                ExcelC.pCellStyle(9) = "width:80px;border-style:none"
                ExcelC.pCellStyle(10) = "width:3px;border-style:none" ' 2010/09/17 T.Watabe edit
                ExcelC.pCellStyle(11) = "width:3px;border-style:none" ' 2010/09/17 T.Watabe add
                ExcelC.pCellStyle(12) = "width:3px;border-style:none" ' 2010/09/17 T.Watabe add
                ExcelC.pCellVal(1) = ""
                ExcelC.pCellVal(2) = ""
                ExcelC.pCellVal(3) = ""
                ExcelC.pCellVal(4) = ""
                ExcelC.pCellVal(5) = ""
                ExcelC.pCellVal(6) = ""
                ExcelC.pCellVal(7) = ""
                ExcelC.pCellVal(8) = ""
                ExcelC.pCellVal(9) = ""
                ExcelC.pCellVal(10) = ""
                ExcelC.pCellVal(11) = "" ' 2010/09/17 T.Watabe add
                ExcelC.pCellVal(12) = "" ' 2010/09/17 T.Watabe add
                ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                '1�s��
                ExcelC.pCellStyle(1) = "border-style:none"
                If pstrAUTO = "1" Then
                    ExcelC.pCellVal(1, "colspan=6") = "���M��FAX�ԍ��F" & pstrFAXNO
                Else
                    ExcelC.pCellVal(1, "colspan=6") = ""
                End If
                ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                '2�s��
                ExcelC.pCellStyle(1) = "border-style:none"
                ExcelC.pCellVal(1, "colspan=6") = ""
                ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                '3�s��
                ExcelC.pCellStyle(1) = "border-style:none"
                'ExcelC.pCellVal(1, "colspan=10") = "�i�`��       �F" & jaName4FileHead '2015/03/06 T.Ono mod 2014���P�J�� :�̈ʒu����
                ExcelC.pCellVal(1, "colspan=10") = "�i�`���@�@�@ �F" & jaName4FileHead
                ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                '4�s��
                ExcelC.pCellStyle(1) = "border-style:none"
                'ExcelC.pCellVal(1, "colspan=10") = "���@�@�@���@ �F" & kenName '2015/03/06 T.Ono mod 2014���P�J�� :�̈ʒu����
                ExcelC.pCellVal(1, "colspan=10") = "���@�@�@���@ �F" & kenName
                ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                '5�s��
                ExcelC.pCellStyle(1) = "border-style:none"
                If pstrSEND_KBN = "1" Then '1:�̔��X�^2:�N���C�A���g
                    'ExcelC.pCellVal(1, "colspan=10") = "����������   �F" & centerName '2015/03/06 T.Ono mod 2014���P�J�� :�̈ʒu����
                    ExcelC.pCellVal(1, "colspan=10") = "�����������@ �F" & centerName
                Else
                    'ExcelC.pCellVal(1, "colspan=10") = "�ײ��Ė�     �F" & centerName '2015/03/06 T.Ono mod 2014���P�J�� :�̈ʒu����
                    ExcelC.pCellVal(1, "colspan=10") = "�ײ��Ė��@�@ �F" & centerName
                End If
                ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                '6�s��
                ExcelC.pCellStyle(1) = "border-style:none"
                ExcelC.pCellVal(1, "colspan=10 align=right") = "���s��TEL�F" & jalpTel
                ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                '7�s��
                ExcelC.pCellStyle(1) = "border-style:none"
                ExcelC.pCellVal(1, "colspan=10 align=right") = "���s�ҁF" & pstrSEND_JALP_NAME   '//��JA-LP�޽������
                ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                '8�s��
                ExcelC.pCellStyle(1) = "border-style:none"
                ExcelC.pCellVal(1, "colspan=10 align=right") = pstrSEND_CENT_NAME   '//�k�o�K�X�W���Z���^�[
                ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������
                '9�s��
                ExcelC.pCellStyle(1) = "border-style:none"
                ExcelC.pCellVal(1, "colspan=6") = ""
                ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                '10�s��
                ExcelC.pCellStyle(1) = "border-style:none"
                ExcelC.pCellVal(1, "colspan=6") = "[" & taisyoDate & "] �Ή��O��"
                ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                '���O�o�͗p�Ƀf�[�^�Z�b�g�@2013/09/25 T.Watabe add
                wkstrTAIOU_SYONO = ""
                wkstrTAIOU_KURACD = ""
                wkstrTAIOU_JACD = ""
                wkstrTAIOU_ACBCD = ""
                wkstrTAIOU_USER_CD = ""
                wkstrAUTO_ZERO_FLG = "1" ' �y�[�������M�t���O�z 0:�f�[�^����/1:�[�����I(�f�[�^�Ȃ�)
                intSEQNO = intSEQNO + 1

                'Throw New Exception("test")
                mlog(pstrSESSION & "\" & pstrKANSI_CODE & "\" & pstrKURACD_F & "\" & pstrKURACD_T, "BTFAXJAX00:mExcelOut�F6�i�[�����j") '2014/04/11 T.Ono add ���O����
                '����FAX��p���O�o�́@2013/09/25 T.Watabe add
                Call mInsertS05AutofaxLog(cdb,
                                        strEXEC_YMD,
                                        strEXEC_TIME,
                                        pstrSEND_KBN,
                                        strGUID,
                                        intSEQNO,
                                        pstrTAISYOUBI,
                                        "1",
                                        pstrKANSI_CODE,
                                        wkstrTAIOU_SYONO,
                                        wkstrTAIOU_KURACD,
                                        wkstrTAIOU_JACD,
                                        wkstrTAIOU_ACBCD,
                                        wkstrTAIOU_USER_CD,
                                        pstrAUTO,
                                        pstrFAXNO,
                                        pstrMAILAD,
                                        wkstrAUTO_ZERO_FLG,
                                        pstrWHERE_TAIOU,
                                        "" & pintDebugSQLNo,
                                        ""
                                        )

                '���[�����̏ꍇ�A�I���
            Else
                '�Q�@�f�[�^����̏ꍇ

                If pintDebugSQLNo = 107 Then ' DEBUG
                    Return "DEBUG:(" & pintDebugSQLNo & ")[" & strSQL.ToString & "]"
                End If

                '//�f�[�^���[�Ƀf�[�^���i�[
                dr = ds.Tables(0).Rows(0)

                '2006/06/15 NEC ADD START
                Dim drKansimas As DataRow
                If True Then
                    Dim dsKansimas As New DataSet
                    Dim strSQL_Kansimas As New StringBuilder("")

                    strSQL_Kansimas.Append("SELECT TEL ")        '�d�b�ԍ�
                    strSQL_Kansimas.Append("FROM KANSIMAS ")
                    strSQL_Kansimas.Append("WHERE KANSI_CD = :KANSI_CD ")

                    cdb.pSQL = strSQL_Kansimas.ToString '//SQL�Z�b�g
                    cdb.pSQLParamStr("KANSI_CD") = pstrKANSI_CODE '//�p�����[�^�Z�b�g
                    cdb.mExecQuery()  '//SQL���s
                    dsKansimas = cdb.pResult  '//�f�[�^�Z�b�g�Ɋi�[

                    If dsKansimas.Tables(0).Rows.Count = 0 Then '//�f�[�^�����݂��Ȃ��H

                        strSQL_Kansimas.Remove(0, strSQL_Kansimas.Length)
                        strSQL_Kansimas.Append("SELECT '' AS TEL ")      '�d�b�ԍ�
                        strSQL_Kansimas.Append("FROM DUAL ")

                        cdb.pSQL = strSQL_Kansimas.ToString  '//SQL�Z�b�g
                        cdb.mExecQuery()  '//SQL���s
                        dsKansimas = cdb.pResult  '//�f�[�^�Z�b�g�Ɋi�[
                        drKansimas = dsKansimas.Tables(0).Rows(0) '//�f�[�^���i�[
                    Else
                        drKansimas = dsKansimas.Tables(0).Rows(0) '//�f�[�^���i�[
                    End If
                End If
                '2006/06/15 NEC ADD END

                If pintDebugSQLNo = 108 Then ' DEBUG
                    Return "DEBUG:(" & pintDebugSQLNo & ")[" & strSQL.ToString & "]"
                End If
                '//------------------------------------------------
                '// �t�@�C���̍쐬�Q�i�f�[�^�ݒ�j
                '//------------------------------------------------

                '�w�b�_���ڂ��Z�b�g�B�i1�y�[�W������s���A�o�͍s���A�擪�s���牽�s�ڂ܂ł��s�^�C�g�����j
                'ExcelC.mHeader(intGYOSU, intGYOSU, 1)
                ExcelC.mHeader(intGYOSU, ds.Tables(0).Rows.Count, 1)

                '�e��̕����s�N�Z���ŃZ�b�g�B�g���������B
                '1�s��
                ExcelC.pCellStyle(1) = "width:32px;border-style:none"
                ExcelC.pCellStyle(2) = "width:122px;border-style:none"
                ExcelC.pCellStyle(3) = "width:72px;border-style:none"
                ExcelC.pCellStyle(4) = "width:72px;border-style:none"

                'ExcelC.pCellStyle(5) = "width:72px;border-style:none"  '20050803 NEC UPDATE
                ExcelC.pCellStyle(5) = "width:90px;border-style:none"
                'ExcelC.pCellStyle(6) = "width:115px;border-style:none" ' 2010/10/07
                'ExcelC.pCellStyle(7) = "width:72px;border-style:none" ' 2010/10/07
                ExcelC.pCellStyle(6) = "width:67px;border-style:none"
                ExcelC.pCellStyle(7) = "width:120px;border-style:none"
                ExcelC.pCellStyle(8) = "width:52px;border-style:none"
                ExcelC.pCellStyle(9) = "width:80px;border-style:none"
                'ExcelC.pCellStyle(10) = "width:80px;border-style:none"'20050803 NEC UPDATE
                'ExcelC.pCellStyle(10) = "width:62px;border-style:none" ' 2010/09/17 T.Watabe edit
                ExcelC.pCellStyle(10) = "width:3px;border-style:none"
                ExcelC.pCellStyle(11) = "width:3px;border-style:none" ' 2010/09/17 T.Watabe add
                ExcelC.pCellStyle(12) = "width:3px;border-style:none" ' 2010/09/17 T.Watabe add
                ExcelC.pCellVal(1) = ""
                ExcelC.pCellVal(2) = ""
                ExcelC.pCellVal(3) = ""
                ExcelC.pCellVal(4) = ""
                ExcelC.pCellVal(5) = ""
                ExcelC.pCellVal(6) = ""
                ExcelC.pCellVal(7) = ""
                ExcelC.pCellVal(8) = ""
                ExcelC.pCellVal(9) = ""
                ExcelC.pCellVal(10) = ""
                ExcelC.pCellVal(11) = "" ' 2010/09/17 T.Watabe add
                ExcelC.pCellVal(12) = "" ' 2010/09/17 T.Watabe add
                ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                '--------------------------------------------------
                '�f�[�^�̏o��
                '--------------------------------------------------
                Dim intRowCount As Integer
                Dim strSTD_CD As String
                Dim strTFKICD As String         '--- 2005/07/12 ADD Falcon ---

                '���[�v����
                For Each dr In ds.Tables(0).Rows
                    faxUser = ""
                    faxUser = pstrFAXNO & "_" & Convert.ToString(dr.Item("ACBNM")) & "_" & Convert.ToString(dr.Item("KENNM")) & "_" & Convert.ToString(dr.Item("ACBCD")) & Convert.ToString(dr.Item("USER_CD"))


                    sZipFilePass = Convert.ToString(dr.Item("YOBI5")) ' 2008/12/12 T.Watabe add

                    If cliCd4FileHead.Length <= 0 Then '��H���ŏ��H
                        cliCd4FileHead = Convert.ToString(dr.Item("CLI_CD")) '2011/03/10 T.Watabe add
                    End If
                    If jaName4FileHead.Length <= 0 Then '��H���ŏ��H
                        jaName4FileHead = Convert.ToString(dr.Item("JANM")).Replace(" ", "") '�i�`�� 2011/05/19 T.Watabe add
                    End If
                    If centerName.Length <= 0 Then '��H���ŏ��H
                        centerName = Convert.ToString(dr.Item("CLI_NAME")).Replace(" ", "") '�N���C�A���g��'2011/05/27 T.Watabe add
                    End If


                    '2006/06/14 NEC UPDATE START
                    '1�s��
                    ExcelC.pCellStyle(1) = "border-style:none"
                    If pstrAUTO = "1" Then
                        'ExcelC.pCellVal(1, "colspan=6") = "���M��FAX�ԍ��F" & Convert.ToString(dr.Item("AUTO_FAX")) ' 2010/05/24 T.Watabe edit
                        ExcelC.pCellVal(1, "colspan=6") = "���M��FAX�ԍ��F" & pstrFAXNO
                    Else
                        ExcelC.pCellVal(1, "colspan=6") = ""
                    End If
                    ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������
                    '2006/06/14 NEC UPDATE END

                    '2�s��
                    ExcelC.pCellStyle(1) = "border-style:none"
                    'ExcelC.pCellStyle(2) = "border-style:none"
                    'JA���������Ƃ����s�����
                    'ExcelC.pCellVal(1, "colspan=3") = "�i�`���F" & Convert.ToString(dr.Item("JANM")) '2005/12/22 NEC UPDATE
                    'ExcelC.pCellVal(2, "colspan=7") = "�x�����F" & Convert.ToString(dr.Item("ACBNM")) & "�@�䒆" '2005/12/22 NEC UPDATE
                    'ExcelC.pCellVal(1, "colspan=4") = "�i�`���F" & Convert.ToString(dr.Item("JANM"))  '2006/06/14 NEC UPDATE 
                    'ExcelC.pCellVal(2, "colspan=6") = "�x�����F" & Convert.ToString(dr.Item("ACBNM")) & "�@�䒆"  '2006/06/14 NEC UPDATE 
                    ExcelC.pCellVal(1, "colspan=10") = "�i�`�x�����@ �F" & Convert.ToString(dr.Item("ACBNM")) & "�@�䒆"
                    ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                    '3�s��
                    ExcelC.pCellStyle(1) = "border-style:none"
                    'ExcelC.pCellStyle(2) = "border-style:none"
                    'ExcelC.pCellStyle(3) = "border-style:none"
                    ExcelC.pCellVal(1, "colspan=10") = "���@�@�@���@ �F" & Convert.ToString(dr.Item("KENNM"))
                    'ExcelC.pCellVal(2, "colspan=4") = "�����Z���^�[���F" & Convert.ToString(dr.Item("NAME"))
                    '2006/06/14 NEC UPDATE START
                    'If pstrAUTO = "1" Then
                    '    ExcelC.pCellVal(3, "colspan=4 align=right") = "FAX�ԍ��F" & Convert.ToString(dr.Item("AUTO_FAX"))
                    'Else
                    '    '''''ExcelC.pCellVal(3, "colspan=4 align=right") = "Ұٱ��ڽ�F" & Convert.ToString(dr.Item("AUTO_MAIL"))
                    '    ExcelC.pCellVal(3, "colspan=4 align=right") = ""
                    'End If
                    '2006/06/14 NEC UPDATE END
                    ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                    '4�s��
                    '2006/06/14 NEC UPDATE START
                    ExcelC.pCellStyle(1) = "border-style:none"
                    ExcelC.pCellStyle(2) = "border-style:none"
                    ExcelC.pCellVal(1, "colspan=6") = "�����������@ �F" & Convert.ToString(dr.Item("NAME"))
                    ExcelC.pCellVal(2, "colspan=4 align=right") = "���s��TEL�F" & Convert.ToString(drKansimas.Item("TEL"))
                    '2006/06/14 NEC UPDATE END
                    ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                    '5�s��
                    ExcelC.pCellStyle(1) = "border-style:none"
                    '2006/06/14 NEC UPDATE START
                    'ExcelC.pCellVal(1, "colspan=10 align=right") = pstrSEND_JALP_NAME   '//��JA-LP�޽������
                    ExcelC.pCellVal(1, "colspan=10 align=right") = "���s�ҁF" & pstrSEND_JALP_NAME   '//��JA-LP�޽������
                    '2006/06/14 NEC UPDATE END
                    ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                    '6�s��
                    ExcelC.pCellStyle(1) = "border-style:none"
                    ExcelC.pCellVal(1, "colspan=10 align=right") = pstrSEND_CENT_NAME   '//�k�o�K�X�W���Z���^�[
                    ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                    '7�s��
                    ExcelC.pCellStyle(1) = "border-bottom-style:none;border-left-style:none;border-right-style:none"
                    ExcelC.pCellVal(1, "colspan=10") = ""
                    ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                    '8�s��
                    ExcelC.pCellStyle(1) = "border-style:none"
                    ExcelC.pCellVal(1, "colspan=10") = "<<��M���>>"
                    ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                    '9�s��
                    'ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������    '--- 2005/05/19 DEL Falcon ---

                    '10�s��
                    ExcelC.pCellStyle(1) = "border-style:none;height:36px;vertical-align:top"
                    ExcelC.pCellStyle(2) = "border-style:none;height:36px;vertical-align:top"
                    'ExcelC.pCellVal(1, "colspan=6") = "���q�l�����F" & Convert.ToString(dr.Item("JUSYONM")) '2015/03/06 T.Ono mod 2014���P�J�� No16
                    ExcelC.pCellVal(1, "colspan=6") = "���q�l���@�F" & Convert.ToString(dr.Item("JUSYONM"))
                    ExcelC.pCellVal(2, "colspan=4") = "���q�l���ށF" & Convert.ToString(dr.Item("ACBCD")) & Convert.ToString(dr.Item("USER_CD"))
                    ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                    '11�s��
                    'ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                    '12�s��
                    ExcelC.pCellStyle(1) = "border-style:none"
                    ExcelC.pCellStyle(2) = "border-style:none"
                    '2006/06/14 NEC UPDATE START
                    'ExcelC.pCellVal(1, "colspan=4") = "�d�b�ԍ��F" & Convert.ToString(dr.Item("KTELNO"))
                    If Convert.ToString(dr.Item("JUTEL1")) = "" Or Convert.ToString(dr.Item("JUTEL2")) = "" Then
                        'ExcelC.pCellVal(1, "colspan=6") = "�d�b�ԍ��@�F" & Convert.ToString(dr.Item("JUTEL1")) & Convert.ToString(dr.Item("JUTEL2")) '2015/03/06 T.Ono mod 2014���P�J�� No16
                        ExcelC.pCellVal(1, "colspan=6") = "�����ԍ��@�F" & Convert.ToString(dr.Item("JUTEL1")) & Convert.ToString(dr.Item("JUTEL2"))
                    Else
                        'ExcelC.pCellVal(1, "colspan=6") = "�d�b�ԍ��@�F" & Convert.ToString(dr.Item("JUTEL1")) & "-" & Convert.ToString(dr.Item("JUTEL2"))
                        ExcelC.pCellVal(1, "colspan=6") = "�����ԍ��@�F" & Convert.ToString(dr.Item("JUTEL1")) & "-" & Convert.ToString(dr.Item("JUTEL2")) '2015/03/06 T.Ono mod 2014���P�J�� No16
                    End If
                    '2006/06/14 NEC UPDATE END
                    'ExcelC.pCellVal(2, "colspan=4") = "�A���d�b�ԍ��F" & Convert.ToString(dr.Item("RENTEL")) '2015/03/06 T.Ono mod 2014���P�J�� No16
                    ExcelC.pCellVal(2, "colspan=4") = "�A����@�@�F" & Convert.ToString(dr.Item("RENTEL"))
                    ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                    '13�s��
                    ExcelC.pCellStyle(1) = "border-style:none"
                    ExcelC.pCellVal(1, "colspan=10") = "�Z���@�@�@�F" & Convert.ToString(dr.Item("ADDR"))
                    ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                    '14�s��
                    ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                    '15�s��
                    ExcelC.pCellStyle(1) = "border-style:none"
                    ExcelC.pCellStyle(2) = "border-style:none"
                    ExcelC.pCellStyle(3) = "border-style:none"
                    ExcelC.pCellVal(1, "colspan=3") = "������~���F" & fncDateSet(Convert.ToString(dr.Item("GAS_START")))
                    ExcelC.pCellVal(2, "colspan=3") = "����p�~���@�@�F" & fncDateSet(Convert.ToString(dr.Item("GAS_DELE")))
                    ExcelC.pCellVal(3, "colspan=4") = "�n�}�ԍ��@�F" & Convert.ToString(dr.Item("TIZUNO"))
                    ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                    '16�s��
                    ExcelC.pCellStyle(1) = "border-style:none"
                    ExcelC.pCellStyle(2) = "border-style:none"
                    ExcelC.pCellVal(1, "colspan=3") = "�W���敪�@�F" & Convert.ToString(dr.Item("SHUGOUNM"))
                    '2006/06/14 NEC UPDATE START
                    'If Convert.ToString(dr.Item("NCU_SET")) = "3" Then      '3:���ڑ�
                    '    ExcelC.pCellVal(2, "colspan=7") = "�m�b�t�ݒu�敪�F" & "��"
                    'Else
                    '    ExcelC.pCellVal(2, "colspan=7") = "�m�b�t�ݒu�敪�F" & "�L"
                    'End If
                    If Convert.ToString(dr.Item("NCU_SET")) = "3" Then      '3:���ڑ�
                        ExcelC.pCellVal(2, "colspan=3") = "�m�b�t�ݒu�敪�F" & "��"
                    Else
                        ExcelC.pCellVal(2, "colspan=3") = "�m�b�t�ݒu�敪�F" & "�L"
                    End If
                    ExcelC.pCellStyle(3) = "border-style:none"
                    Select Case Convert.ToString(dr.Item("USER_FLG"))
                        Case "0"
                            '0:���J��
                            ExcelC.pCellVal(3, "colspan=4") = "���q�l��ԁF" & "���J��"
                        Case "1"
                            '1:�^�p��
                            ExcelC.pCellVal(3, "colspan=4") = "���q�l��ԁF" & "�^�p��"
                        Case "2"
                            '2:�x�~��
                            ExcelC.pCellVal(3, "colspan=4") = "���q�l��ԁF" & "�x�~��"
                        Case Else
                            '���̑�
                            ExcelC.pCellVal(3, "colspan=4") = "���q�l��ԁF"
                    End Select
                    '2006/06/14 NEC UPDATE END
                    ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                    '17�s��
                    ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                    '18�s��
                    ExcelC.pCellStyle(1) = "border-style:none"
                    ExcelC.pCellVal(1, "colspan=10") = "�y�x����e�z"
                    ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                    '19�s��
                    ExcelC.pCellStyle(1) = "border-style:none"
                    ExcelC.pCellStyle(2) = "border-style:none"
                    ExcelC.pCellStyle(3) = "border-style:none"
                    'ExcelC.pCellStyle(4) = "border-style:none"
                    'ExcelC.pCellVal(1, "colspan=3") = "�������F" & fncDateSet(Convert.ToString(dr.Item("HATYMD"))) & " " & fncTimeSet(Convert.ToString(dr.Item("HATTIME"))) '2015/03/06 T.Ono mod 2014���P�J�� No16
                    ExcelC.pCellVal(1, "colspan=3") = "��M�����F" & fncDateSet(Convert.ToString(dr.Item("HATYMD"))) & " " & fncTimeSet(Convert.ToString(dr.Item("HATTIME")))
                    ExcelC.pCellVal(2, "colspan=2") = "���[�^�l�F" & Convert.ToString(dr.Item("KENSIN"))
                    'ExcelC.pCellVal(3, "colspan=1") = "���ʋ敪�F" & Convert.ToString(dr.Item("RYURYO"))    '���̂ł͂Ȃ�
                    'ExcelC.pCellVal(4, "colspan=4") = "���[�^��ʁF" & Convert.ToString(dr.Item("METASYU"))
                    ExcelC.pCellVal(3, "colspan=5") = "���ʋ敪�F" & Convert.ToString(dr.Item("RYURYO")) & "�@���[�^��ʁF" & Convert.ToString(dr.Item("METASYU"))
                    ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                    '20�s��
                    ExcelC.pCellStyle(1) = "border-style:none"
                    ExcelC.pCellStyle(2) = "border-style:none"
                    ExcelC.pCellVal(1, "colspan=5") = "1�F" & Convert.ToString(dr.Item("KMNM1"))
                    '2006/06/14 NEC UPDATE START
                    'ExcelC.pCellVal(2, "colspan=5") = "2�F" & Convert.ToString(dr.Item("KMNM2"))
                    ExcelC.pCellVal(2, "colspan=5") = "4�F" & Convert.ToString(dr.Item("KMNM4"))
                    '2006/06/14 NEC UPDATE END
                    ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                    '21�s��
                    ExcelC.pCellStyle(1) = "border-style:none"
                    ExcelC.pCellStyle(2) = "border-style:none"
                    '2006/06/14 NEC UPDATE START
                    'ExcelC.pCellVal(1, "colspan=5") = "3�F" & Convert.ToString(dr.Item("KMNM3"))
                    'ExcelC.pCellVal(2, "colspan=5") = "4�F" & Convert.ToString(dr.Item("KMNM4"))
                    ExcelC.pCellVal(1, "colspan=5") = "2�F" & Convert.ToString(dr.Item("KMNM2"))
                    ExcelC.pCellVal(2, "colspan=5") = "5�F" & Convert.ToString(dr.Item("KMNM5"))
                    '2006/06/14 NEC UPDATE END
                    ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                    '22�s��
                    ExcelC.pCellStyle(1) = "border-style:none"
                    ExcelC.pCellStyle(2) = "border-style:none"
                    '2006/06/14 NEC UPDATE START
                    'ExcelC.pCellVal(1, "colspan=5") = "5�F" & Convert.ToString(dr.Item("KMNM5"))
                    ExcelC.pCellVal(1, "colspan=5") = "3�F" & Convert.ToString(dr.Item("KMNM3"))
                    '2006/06/14 NEC UPDATE END
                    ExcelC.pCellVal(2, "colspan=5") = "6�F" & Convert.ToString(dr.Item("KMNM6"))
                    ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                    '23�s��
                    ExcelC.pCellStyle(1) = "border-style:none"
                    '2005/10/03 NEC UPDATE START
                    '���L�}�X�^�Ɍڋq�����Ȃ�������\������
                    '                If Convert.ToString(dr.Item("MITOKBN")) = "1" Then
                    If Convert.ToString(dr.Item("SH_USER")) = "" Then
                        '2005/10/03 NEC UPDATE END
                        ExcelC.pCellVal(1, "colspan=10") = "���q�l�}�X�^�[�@�����A�Z���A�d�b�ԍ������m�F�̏�A���A�����������B"
                    Else
                        ExcelC.pCellVal(1, "colspan=10") = ""
                    End If
                    ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                    '2013/11/26 T.Ono dell
                    '24�s��
                    'ExcelC.pCellStyle(1) = "border-bottom-style:none;border-left-style:none;border-right-style:none"
                    ExcelC.pCellStyle(1) = "border-bottom-style:none;border-left-style:none;border-right-style:none;height:6px"
                    ExcelC.pCellVal(1, "colspan=10") = ""
                    ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                    '25�s��
                    ExcelC.pCellStyle(1) = "border-style:none"
                    'ExcelC.pCellStyle(1) = "border-bottom-style:none;border-left-style:none;border-right-style:none"
                    ExcelC.pCellVal(1, "colspan=10") = "<<�Ď��Z���^�[�Ή����e>>"
                    ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                    '26�s��
                    ExcelC.pCellStyle(1) = "border-style:none"
                    ExcelC.pCellStyle(2) = "border-style:none"
                    ExcelC.pCellStyle(3) = "border-style:none"
                    ExcelC.pCellVal(1, "colspan=3") = "�Ή��敪�@�@�F" & Convert.ToString(dr.Item("TAIOKBN_NAI"))
                    ExcelC.pCellVal(2, "colspan=2") = "�����敪�F" & Convert.ToString(dr.Item("TMSKB_NAI"))
                    ExcelC.pCellVal(3, "colspan=5") = "�����ԍ�(�Ɖ�p)�F" & Convert.ToString(dr.Item("SYONO"))
                    ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                    '27�s��
                    ExcelC.pCellStyle(1) = "border-style:none"
                    ExcelC.pCellStyle(2) = "border-style:none"
                    ExcelC.pCellVal(1, "colspan=5") = "�Ď������S���F" & Convert.ToString(dr.Item("TKTANCD_NM"))
                    'ExcelC.pCellVal(2, "colspan=5") = "�Ή����F" & fncDateSet(Convert.ToString(dr.Item("SYOYMD"))) & " " & fncTimeSet(Convert.ToString(dr.Item("SYOTIME"))) ' 2008/10/14 T.Watabe edit
                    'ExcelC.pCellVal(2, "colspan=5") = "���������@�@�@�@�F" & fncDateSet(Convert.ToString(dr.Item("SYOYMD"))) & " " & fncTimeSet(Convert.ToString(dr.Item("SYOTIME"))) '2015/03/06 T.Ono mod 2014���P�J�� No16
                    ExcelC.pCellVal(2, "colspan=5") = "�Ή����������@�@�F" & fncDateSet(Convert.ToString(dr.Item("SYOYMD"))) & " " & fncTimeSet(Convert.ToString(dr.Item("SYOTIME")))
                    ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                    '28�s��
                    '2015/03/06 T.Ono mod 2014���P�J�� No16 START
                    ExcelC.pCellStyle(1) = "border-style:none"
                    ExcelC.pCellVal(1, "colspan=5") = "�˗������@�@�F" & fncDateSet(Convert.ToString(dr.Item("SIJIYMD"))) & " " & fncTimeSet(Convert.ToString(dr.Item("SIJITIME")))
                    '2015/03/06 T.Ono mod 2014���P�J�� No16 END
                    ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                    '29�s��
                    ExcelC.pCellStyle(1) = "border-style:none"
                    ExcelC.pCellVal(1, "colspan=10") = "�A������@�@�F" & Convert.ToString(dr.Item("TAITNM"))
                    ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                    '30�s��
                    ExcelC.pCellStyle(1) = "border-style:none"
                    ExcelC.pCellVal(1, "colspan=10") = "�d�b�A�����e�F" & Convert.ToString(dr.Item("TELRNM"))
                    ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                    '--- ��2005/05/17 MOD Falcon�� ---
                    '�o�͏���d�b�����P�˓d�b�����Q�˕��A���상���ɏC��
                    ''31�s��
                    ''ExcelC.pCellStyle(1) = "border-style:none"
                    'ExcelC.pCellStyle(1) = "border-style:none;height:36px"  '--- 2005/05/19 MOD Falcon ---
                    'ExcelC.pCellVal(1, "colspan=10") = Convert.ToString(dr.Item("TEL_MEMO1"))
                    'ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                    ''32�s��
                    'If Convert.ToString(dr.Item("TEL_MEMO2")).Trim.Length > 0 Then ' 2010/10/06 T.Watabe edit �ް���������΋l�߂�
                    '    'ExcelC.pCellStyle(1) = "border-style:none"
                    '    ExcelC.pCellStyle(1) = "border-style:none;height:36px"  '--- 2005/05/19 MOD Falcon ---
                    '    ExcelC.pCellVal(1, "colspan=10") = Convert.ToString(dr.Item("TEL_MEMO2"))
                    '    ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������
                    'End If

                    ''33�s��
                    'If Convert.ToString(dr.Item("FUK_MEMO")).Trim.Length > 0 Then ' 2010/10/06 T.Watabe edit �ް���������΋l�߂�
                    '    'ExcelC.pCellStyle(1) = "border-style:none"
                    '    ExcelC.pCellStyle(1) = "border-style:none;height:36px"  '--- 2005/05/19 MOD Falcon ---
                    '    ExcelC.pCellVal(1, "colspan=10") = Convert.ToString(dr.Item("FUK_MEMO"))
                    '    ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������
                    'End If
                    '31�s��
                    ExcelC.pCellStyle(1) = "border-style:none"
                    'ExcelC.pCellStyle(2) = "border-style:none;height:64px;vertical-align:top" '2013/11/26 T.Ono mod
                    ExcelC.pCellStyle(2) = "border-style:none;height:74px;vertical-align:top"
                    ExcelC.pCellVal(1) = ""
                    ExcelC.pCellVal(2, "colspan=9") = Convert.ToString(dr.Item("TEL_MEMO1")) & Convert.ToString(dr.Item("TEL_MEMO2")) & Convert.ToString(dr.Item("FUK_MEMO"))
                    ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������
                    '--- ��2005/05/17 MOD Falcon�� ---

                    '34�s��
                    ExcelC.pCellStyle(1) = "border-style:none"
                    'ExcelC.pCellVal(1, "colspan=10") = "�������@�F" & Convert.ToString(dr.Item("TKIGNM")) '2015/03/06 T.Ono mod 2014���P�J�� No16
                    ExcelC.pCellVal(1, "colspan=10") = "�������@�@�F" & Convert.ToString(dr.Item("TKIGNM"))
                    ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                    '35�s��
                    ExcelC.pCellStyle(1) = "border-style:none"
                    ExcelC.pCellVal(1, "colspan=10") = "�쓮�����@�@�F" & Convert.ToString(dr.Item("TSADNM"))
                    ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                    '36�s��
                    '2006/06/14 NEC UPDATE START
                    ExcelC.pCellStyle(1) = "border-style:none"
                    'ExcelC.pCellVal(1, "colspan=10") = "�o���w���@�@�F" & Convert.ToString(dr.Item("SDNM")) '2015/03/06 T.Ono mod 2014���P�J�� No16
                    ExcelC.pCellVal(1, "colspan=10") = "�o���˗����e�F" & Convert.ToString(dr.Item("SDNM"))
                    '2006/06/14 NEC UPDATE END
                    ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                    '37�s��
                    ExcelC.pCellStyle(1) = "border-style:none"
                    'ExcelC.pCellVal(1, "colspan=10") = "�o���w�����l�F" & Convert.ToString(dr.Item("SIJI_BIKO1")) '2015/03/06 T.Ono mod 2014���P�J�� No16
                    ExcelC.pCellVal(1, "colspan=10") = "�o���˗����l�F" & Convert.ToString(dr.Item("SIJI_BIKO1"))
                    ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                    '38�s��
                    ExcelC.pCellStyle(1) = "border-style:none"
                    ExcelC.pCellVal(1, "colspan=10") = "�@�@�@�@�@�@�@" & Convert.ToString(dr.Item("siji_biko2"))
                    ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                    '39�s��
                    '2006/06/15 NEC UPDATE START
                    'ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������
                    '2006/06/15 NEC UPDATE END

                    '2013/11/26 T.Ono del
                    '40�s��
                    'ExcelC.pCellStyle(1) = "border-bottom-style:none;border-left-style:none;border-right-style:none"
                    ExcelC.pCellStyle(1) = "border-bottom-style:none;border-left-style:none;border-right-style:none;height:6px"
                    ExcelC.pCellVal(1, "colspan=10") = ""
                    ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                    '--- ��2005/05/25 ADD Falcon�� ---
                    '--- ��2005/05/23 ADD Falcon�� ---
                    strSTD_CD = Convert.ToString(dr.Item("STD_CD"))
                    '--- ��2005/05/23 ADD Falcon�� ---

                    '--- ��2005/07/13 ADD Falcon�� ---
                    strTFKICD = Convert.ToString(dr.Item("TFKICD"))         '���A�Ή���
                    '--- ��2005/07/13 ADD Falcon�� ---

                    '--- ��2005/05/31 MOD Falcon�� ---
                    'If strSTD_CD.Length <> 0 And Convert.ToString(dr.Item("TAIOKBN")) = "2" Then                       '--- 2005/07/13 DEL Falcon
                    If strSTD_CD.Length <> 0 And Convert.ToString(dr.Item("TAIOKBN")) = "2" And strTFKICD = "8" Then    '--- 2005/07/13 MOD Falcon
                        '---------- �o���w���̏ꍇ�̂݃f�[�^�o�͂��� ---------------------------
                        '41�s��
                        ExcelC.pCellStyle(1) = "border-style:none"
                        ExcelC.pCellStyle(2) = "border-style:none" ' 2008/10/21 T.Watabe add
                        'ExcelC.pCellVal(1, "colspan=10") = "<<�o����БΉ����e>>"
                        ExcelC.pCellVal(1, "colspan=6") = "<<�o����БΉ����e>>"
                        ExcelC.pCellVal(2, "colspan=4 align=right") = "�����敪�F" & Convert.ToString(dr.Item("SDSKBN_NAI")) ' 2008/10/21 T.Watabe add
                        ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                        '42�s��
                        ExcelC.pCellStyle(1) = "border-style:none"
                        ExcelC.pCellVal(1, "colspan=10") = "�o���ϑ���i�w��ۈ��@�ցj�F" & Convert.ToString(dr.Item("STD"))
                        ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                        '43�s��
                        ExcelC.pCellStyle(1) = "border-style:none"
                        ExcelC.pCellVal(1, "colspan=10") = "�x������_���F" & Convert.ToString(dr.Item("STD_KYOTEN"))
                        ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                        '44�s��
                        ExcelC.pCellStyle(1) = "border-style:none"
                        ExcelC.pCellStyle(2) = "border-style:none"
                        ExcelC.pCellStyle(3) = "border-style:none"
                        'ExcelC.pCellVal(1, "colspan=3") = "�Ή��ҁ@�@ �F" & Convert.ToString(dr.Item("SYUTDTNM")) '2015/03/06 T.Ono mod 2014���P�J�� No16
                        ExcelC.pCellVal(1, "colspan=3") = "�o���Ή��� �F" & Convert.ToString(dr.Item("SYUTDTNM"))
                        'ExcelC.pCellVal(2, "colspan=3") = "�������ԁF" & fncDateSet(Convert.ToString(dr.Item("TYAKYMD"))) & " " & fncTimeSet(Convert.ToString(dr.Item("TYAKTIME"))) ' 2008/10/14 T.Watabe edit
                        'ExcelC.pCellVal(3, "colspan=4") = "�[�u�������ԁF" & fncDateSet(Convert.ToString(dr.Item("SYOKANYMD"))) & " " & fncTimeSet(Convert.ToString(dr.Item("SYOKANTIME"))) ' 2008/10/14 T.Watabe edit
                        ExcelC.pCellVal(2, "colspan=3") = "��M�����F" & fncDateSet(Convert.ToString(dr.Item("SIJIYMD"))) & " " & fncTimeSet(Convert.ToString(dr.Item("SIJITIME"))) '��M����(�o���w����������)
                        ExcelC.pCellVal(3, "colspan=4") = "�o�������@�@�F" & fncDateSet(Convert.ToString(dr.Item("SDYMD"))) & " " & fncTimeSet(Convert.ToString(dr.Item("SDTIME")))
                        ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                        '45�s��
                        ExcelC.pCellStyle(1) = "border-style:none"
                        ExcelC.pCellStyle(2) = "border-style:none" ' 2008/10/14 T.Watabe add
                        ExcelC.pCellStyle(3) = "border-style:none" ' 2008/10/14 T.Watabe add
                        'ExcelC.pCellVal(1, "colspan=10") = "�Ή�����F" & Convert.ToString(dr.Item("AITNM")) ' 2008/10/14 T.Watabe edit
                        ExcelC.pCellVal(1, "colspan=3") = "�Ή�����@ �F" & Convert.ToString(dr.Item("AITNM"))
                        ExcelC.pCellVal(2, "colspan=3") = "���������F" & fncDateSet(Convert.ToString(dr.Item("TYAKYMD"))) & " " & fncTimeSet(Convert.ToString(dr.Item("TYAKTIME"))) ' 2008/10/14 T.Watabe add
                        'ExcelC.pCellVal(3, "colspan=4") = "�[�u���������F" & fncDateSet(Convert.ToString(dr.Item("SYOKANYMD"))) & " " & fncTimeSet(Convert.ToString(dr.Item("SYOKANTIME"))) ' 2008/10/14 T.Watabe add '2015/03/06 T.Ono mod 2014���P�J�� No16
                        ExcelC.pCellVal(3, "colspan=4") = "�������������F" & fncDateSet(Convert.ToString(dr.Item("SYOKANYMD"))) & " " & fncTimeSet(Convert.ToString(dr.Item("SYOKANTIME")))
                        ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                        ' 2008/11/04 T.Watabe del 
                        ''46�s��
                        'ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                        '47�s��
                        ExcelC.pCellStyle(1) = "border-style:none"
                        '2006/06/14 NEC UPDATE START
                        'If Convert.ToString(dr.Item("CSNTNGAS")) = "1" Then
                        '    ExcelC.pCellVal(1, "colspan=10") = "�y���q�l�̂��b���e�z " & Convert.ToString(dr.Item("SDTBIK1"))
                        'Else
                        '    If Convert.ToString(dr.Item("METFUKKI")) = "1" Then
                        '        ExcelC.pCellVal(1, "colspan=10") = "�y���q�l�̂��b���e�z " & "���[�^���A"
                        '    ElseIf Convert.ToString(dr.Item("HOAN")) = "1" Then
                        '        ExcelC.pCellVal(1, "colspan=10") = "�y���q�l�̂��b���e�z " & "�ۈ�"
                        '    ElseIf Convert.ToString(dr.Item("GASGIRE")) = "1" Then
                        '        ExcelC.pCellVal(1, "colspan=10") = "�y���q�l�̂��b���e�z " & "�K�X�؂�"
                        '    ElseIf Convert.ToString(dr.Item("KIGKOSYO")) = "1" Then
                        '        ExcelC.pCellVal(1, "colspan=10") = "�y���q�l�̂��b���e�z " & "���̏�"
                        '    ElseIf Convert.ToString(dr.Item("CSNTGEN")) = "1" Then
                        '        ExcelC.pCellVal(1, "colspan=10") = "�y���q�l�̂��b���e�z " & "���̑�"
                        '    Else
                        '        ExcelC.pCellVal(1, "colspan=10") = "�y���q�l�̂��b���e�z " & ""
                        '    End If
                        'End If

                        ExcelC.pCellVal(1, "colspan=10") = "�y���q�l�̂��b���e�z"
                        ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������
                        '48�s��
                        ExcelC.pCellStyle(1) = "border-style:none"
                        ExcelC.pCellStyle(2) = "border-style:none"
                        ExcelC.pCellStyle(3) = "border-style:none"
                        ExcelC.pCellVal(1) = ""
                        If Convert.ToString(dr.Item("METFUKKI")) = "1" Then
                            ExcelC.pCellVal(2, "colspan=3") = "�K�X�֘A�F" & "���[�^���A"
                        ElseIf Convert.ToString(dr.Item("HOAN")) = "1" Then
                            ExcelC.pCellVal(2, "colspan=3") = "�K�X�֘A�F" & "�ۈ�"
                        ElseIf Convert.ToString(dr.Item("GASGIRE")) = "1" Then
                            ExcelC.pCellVal(2, "colspan=3") = "�K�X�֘A�F" & "�K�X�؂�"
                        ElseIf Convert.ToString(dr.Item("KIGKOSYO")) = "1" Then
                            ExcelC.pCellVal(2, "colspan=3") = "�K�X�֘A�F" & "���̏�"
                        ElseIf Convert.ToString(dr.Item("CSNTGEN")) = "1" Then
                            ExcelC.pCellVal(2, "colspan=3") = "�K�X�֘A�F" & "���̑�"
                        Else
                            ExcelC.pCellVal(2, "colspan=3") = "�K�X�֘A�F" & ""
                        End If
                        ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                        '49�s��
                        ExcelC.pCellStyle(1) = "border-style:none"
                        ExcelC.pCellStyle(2) = "border-style:none"
                        ExcelC.pCellVal(1) = ""
                        ExcelC.pCellVal(2, "colspan=9") = "���b���e�F" & Convert.ToString(dr.Item("SDTBIK1"))
                        ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������
                        '2006/06/14 NEC UPDATE END

                        '50�s��
                        ExcelC.pCellStyle(1) = "border-style:none"
                        ExcelC.pCellStyle(2) = "border-style:none"
                        ExcelC.pCellVal(1, "colspan=5") = "���A�Ή��F" & Convert.ToString(dr.Item("FKINM"))
                        'If Convert.ToString(dr.Item("KIGTAIYO")) = "1" Then  '1:�L ' 2008/10/21 T.Watabe edit
                        '    ExcelC.pCellVal(2, "colspan=5") = "�ȈՃK�X���̑ݗ^�F" & "�L"
                        'Else
                        '    ExcelC.pCellVal(2, "colspan=5") = "�ȈՃK�X���̑ݗ^�F" & "��"
                        'End If
                        ExcelC.pCellVal(2, "colspan=5") = "���[�^�쓮�����P�@�F" & Convert.ToString(dr.Item("SADNM")) '1:�L ' 2008/10/21 T.Watabe add
                        ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                        ' �� 2008/10/14 T.Watabe add
                        '50�s��+1
                        ExcelC.pCellStyle(1) = "border-style:none"
                        ExcelC.pCellStyle(2) = "border-style:none"
                        'ExcelC.pCellVal(1, "colspan=5") = "�K�X���F" & Convert.ToString(dr.Item("KIGNM")) '2015/03/06 T.Ono mod 2014���P�J�� No16
                        ExcelC.pCellVal(1, "colspan=5") = "�������F" & Convert.ToString(dr.Item("KIGNM"))
                        If Convert.ToString(dr.Item("KIGTAIYO")) = "1" Then  '1:�L
                            ExcelC.pCellVal(2, "colspan=5") = "�ȈՃK�X���̑ݗ^�F" & "�L"
                        Else
                            ExcelC.pCellVal(2, "colspan=5") = "�ȈՃK�X���̑ݗ^�F" & "��"
                        End If
                        ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������
                        ' �� 2008/10/14 T.Watabe add

                        '51�s��
                        ExcelC.pCellStyle(1) = "border-style:none"
                        ExcelC.pCellStyle(2) = "border-style:none"
                        ExcelC.pCellVal(1, "colspan=5") = "�A���� �A������F" & Convert.ToString(dr.Item("JAKENREN")) & "�@�l"
                        ExcelC.pCellVal(2, "colspan=5") = "�A�����ԁ@�@�@�@�@�F" & fncTimeSet(Convert.ToString(dr.Item("RENTIME")))
                        ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                        '52�s��
                        ExcelC.pCellStyle(1) = "border-style:none"
                        ExcelC.pCellStyle(2) = "border-style:none"
                        If Convert.ToString(dr.Item("GASMUMU")) = "0" Then  ' 0�F�L�@1�F��
                            ExcelC.pCellVal(1, "colspan=2") = "�K�X�R��_���F" & "�L"
                        Else
                            ExcelC.pCellVal(1, "colspan=2") = "�K�X�R��_���F" & "��"
                        End If
                        If Convert.ToString(dr.Item("ORGENIN")) = "1" Then  '�K�X���@1:�L
                            ExcelC.pCellVal(2, "colspan=8") = "�����F" & "�K�X���"
                        Else
                            ExcelC.pCellVal(2, "colspan=8") = "�����F" & ""
                        End If
                        ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                        '53�s��
                        ExcelC.pCellStyle(1) = "border-style:none"
                        ExcelC.pCellStyle(2) = "border-style:none"
                        ExcelC.pCellStyle(3) = "border-style:none"
                        If Convert.ToString(dr.Item("GASGUMU")) = "0" Then      '0�F�L�@1�F��
                            ExcelC.pCellVal(1, "colspan=2") = "�K�X�؂�_���F" & "�L"
                        Else
                            ExcelC.pCellVal(1, "colspan=2") = "�K�X�؂�_���F" & "��"
                        End If
                        If Convert.ToString(dr.Item("HOSKOKAN")) = "0" Then     '0�F���{�@1�F�����{
                            ExcelC.pCellVal(2, "colspan=5") = "���ΰ������F" & "���{"
                        Else
                            ExcelC.pCellVal(2, "colspan=5") = "���ΰ������F" & "�����{"
                        End If
                        If Convert.ToString(dr.Item("COYOINA")) = "0" Then      '0�F�ǁ@1�F��
                            ExcelC.pCellVal(3, "colspan=3") = "�b�n�Z�x�F" & "��"
                        Else
                            ExcelC.pCellVal(3, "colspan=3") = "�b�n�Z�x�F" & "��"
                        End If
                        ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                        '54�s��
                        ExcelC.pCellStyle(1) = "border-style:none"
                        ExcelC.pCellStyle(2) = "border-style:none"
                        ExcelC.pCellStyle(3) = "border-style:none"
                        ExcelC.pCellStyle(4) = "border-style:none"
                        If Convert.ToString(dr.Item("METYOINA")) = "0" Then      '0�F�ǁ@1�F��
                            ExcelC.pCellVal(1, "colspan=2") = "���[�^�_���@�F" & "��"
                        Else
                            ExcelC.pCellVal(1, "colspan=2") = "���[�^�_���@�F" & "��"
                        End If
                        If Convert.ToString(dr.Item("TYOUYOINA")) = "0" Then      '0�F�ǁ@1�F��
                            ExcelC.pCellVal(2, "colspan=3") = "�������_���F" & "��"
                        Else
                            ExcelC.pCellVal(2, "colspan=3") = "�������_���F" & "��"
                        End If
                        If Convert.ToString(dr.Item("VALYOINA")) = "0" Then      '0�F�ǁ@1�F��
                            ExcelC.pCellVal(3, "colspan=2") = "�e����ԃo���u�F" & "��"
                        Else
                            ExcelC.pCellVal(3, "colspan=2") = "�e����ԃo���u�F" & "��"
                        End If
                        If Convert.ToString(dr.Item("KYUHAIUMU")) = "0" Then      '0�F�ǁ@1�F��
                            ExcelC.pCellVal(4, "colspan=3") = "�z�r�C���F" & "��"
                        Else
                            ExcelC.pCellVal(4, "colspan=3") = "�z�r�C���F" & "��"
                        End If
                        ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                        '--- ��2005/09/09 MOD Falcon�� ---
                        '2006/06/14 NEC UPDATE START
                        ''55�s��
                        'ExcelC.pCellStyle(1) = "border-style:none"
                        'ExcelC.pCellVal(1, "colspan=10") = "���L�����F"
                        ''ExcelC.pCellVal(1, "colspan=10") = "���L�����F" & Convert.ToString(dr.Item("SDTBIK2"))
                        'ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                        ''56�s��
                        'ExcelC.pCellStyle(1) = "border-style:none;font-size:10pt;height:36px"
                        'ExcelC.pCellVal(1, "colspan=10") = Convert.ToString(dr.Item("SDTBIK2"))
                        'ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                        ''57�s��
                        'ExcelC.pCellStyle(1) = "border-style:none"
                        'ExcelC.pCellVal(1, "colspan=10") = "�i�`�^���A�l�ւ̈˗��������F"
                        'ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                        ''58�s��
                        'ExcelC.pCellStyle(1) = "border-style:none;font-size:10pt;height:36px"
                        ''ExcelC.pCellStyle(1) = "border-style:none"
                        'ExcelC.pCellVal(1, "colspan=10") = Convert.ToString(dr.Item("SNTTOKKI"))
                        'ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                        '55�s��
                        ExcelC.pCellStyle(1) = "border-style:none"
                        ExcelC.pCellVal(1, "colspan=10") = "�o�����ʓ��e/�񍐁F"
                        ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                        ''56�s��
                        'ExcelC.pCellStyle(1) = "border-style:none;height:36px"
                        'ExcelC.pCellVal(1, "colspan=10") = Convert.ToString(dr.Item("SDTBIK2"))
                        'ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                        ''57�s��
                        'If Convert.ToString(dr.Item("SNTTOKKI")).Trim.Length > 0 Then ' 2010/10/06 T.Watabe edit �ް���������΋l�߂�
                        '    ExcelC.pCellStyle(1) = "border-style:none;height:36px"
                        '    ExcelC.pCellVal(1, "colspan=10") = Convert.ToString(dr.Item("SNTTOKKI"))
                        '    ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������
                        'End If

                        ''58�s��
                        'If Convert.ToString(dr.Item("SDTBIK3")).Trim.Length > 0 Then ' 2010/10/06 T.Watabe edit �ް���������΋l�߂�
                        '    ExcelC.pCellStyle(1) = "border-style:none;height:36px"
                        '    ExcelC.pCellVal(1, "colspan=10") = Convert.ToString(dr.Item("SDTBIK3"))
                        '    ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������
                        'End If
                        '56�s��
                        ExcelC.pCellStyle(1) = "border-style:none"
                        'ExcelC.pCellStyle(2) = "border-style:none;height:64px;vertical-align:top" 2013/11/26 T.Ono mod
                        ExcelC.pCellStyle(2) = "border-style:none;height:74px;vertical-align:top"
                        ExcelC.pCellVal(1) = ""
                        ExcelC.pCellVal(2, "colspan=9") = Convert.ToString(dr.Item("SDTBIK2")) & Convert.ToString(dr.Item("SNTTOKKI")) & Convert.ToString(dr.Item("SDTBIK3"))
                        ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������
                        '2006/06/14 NEC UPDATE END
                        '--- ��2005/09/09 MOD Falcon�� ---

                    Else
                        '--- ��2005/09/10 DEL Falcon�� ---
                        '�o����Ђ��o���������e�ł͂Ȃ��ꍇ�A�u�o�����v�����ׂĕ\�����Ȃ��悤�ɂ���

                        ''---------- �o���w���ł͂Ȃ��ꍇ�A�f�[�^�o�͍͂s��Ȃ� ---------------------------
                        ''41�s��
                        'ExcelC.pCellStyle(1) = "border-style:none"
                        'ExcelC.pCellVal(1, "colspan=10") = "<<�o����БΉ����e>>"
                        'ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                        ''42�s��
                        'ExcelC.pCellStyle(1) = "border-style:none"
                        'ExcelC.pCellVal(1, "colspan=10") = "�o���ϑ���i�w��ۈ��@�ցj�F"
                        'ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                        ''43�s��
                        'ExcelC.pCellStyle(1) = "border-style:none"
                        'ExcelC.pCellVal(1, "colspan=10") = "�x���E���_���F"
                        'ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                        ''44�s��
                        'ExcelC.pCellStyle(1) = "border-style:none"
                        'ExcelC.pCellStyle(2) = "border-style:none"
                        'ExcelC.pCellStyle(3) = "border-style:none"
                        'ExcelC.pCellVal(1, "colspan=3") = "�Ή��ҁF"
                        'ExcelC.pCellVal(2, "colspan=3") = "�������ԁF"
                        'ExcelC.pCellVal(3, "colspan=4") = "�[�u�������ԁF"
                        'ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                        ''45�s��
                        'ExcelC.pCellStyle(1) = "border-style:none"
                        'ExcelC.pCellVal(1, "colspan=10") = "�Ή�����F"
                        'ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                        ''46�s��
                        'ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                        ''47�s��
                        'ExcelC.pCellStyle(1) = "border-style:none"
                        'ExcelC.pCellVal(1, "colspan=10") = "�y���q�l�̂��b���e�z "
                        'ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                        ''49�s��
                        'ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                        ''50�s��
                        'ExcelC.pCellStyle(1) = "border-style:none"
                        'ExcelC.pCellStyle(2) = "border-style:none"
                        'ExcelC.pCellVal(1, "colspan=5") = "���A�Ή��F"
                        'ExcelC.pCellVal(2, "colspan=5") = "�ȈՃK�X���̑ݗ^�F"
                        'ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                        ''51�s��
                        'ExcelC.pCellStyle(1) = "border-style:none"
                        'ExcelC.pCellStyle(2) = "border-style:none"
                        'ExcelC.pCellVal(1, "colspan=5") = "�A���󋵁@�A������F"
                        'ExcelC.pCellVal(2, "colspan=5") = "�A�����ԁF"
                        'ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                        ''52�s��
                        'ExcelC.pCellStyle(1) = "border-style:none"
                        'ExcelC.pCellStyle(2) = "border-style:none"
                        'ExcelC.pCellVal(1, "colspan=2") = "�K�X�R��_���F"
                        'ExcelC.pCellVal(2, "colspan=8") = "�����F"
                        'ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                        ''53�s��
                        'ExcelC.pCellStyle(1) = "border-style:none"
                        'ExcelC.pCellStyle(2) = "border-style:none"
                        'ExcelC.pCellVal(1, "colspan=2") = "�K�X�؂�_���F"
                        'ExcelC.pCellVal(2, "colspan=8") = "�S���z�[�X�����F"
                        'ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                        ''54�s��
                        'ExcelC.pCellStyle(1) = "border-style:none"
                        'ExcelC.pCellStyle(2) = "border-style:none"
                        'ExcelC.pCellStyle(3) = "border-style:none"
                        'ExcelC.pCellStyle(4) = "border-style:none"
                        'ExcelC.pCellStyle(5) = "border-style:none"
                        'ExcelC.pCellVal(1, "colspan=2") = "���[�^�_���F"
                        'ExcelC.pCellVal(2, "colspan=2") = "�������_���F"
                        'ExcelC.pCellVal(3, "colspan=2") = "�e��E���ԃo���u�F"
                        'ExcelC.pCellVal(4, "colspan=2") = "�z�r�C���F"
                        'ExcelC.pCellVal(5, "colspan=2") = "�b�n�Z�x�F"
                        'ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                        ''55�s��
                        'ExcelC.pCellStyle(1) = "border-style:none"
                        'ExcelC.pCellVal(1, "colspan=10") = "���L�����F"
                        'ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                        ''56�s��
                        'ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                        ''57�s��
                        'ExcelC.pCellStyle(1) = "border-style:none"
                        'ExcelC.pCellVal(1, "colspan=10") = "�i�`�^���A�l�ւ̈˗��������F"
                        'ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                        ''58�s��
                        'ExcelC.pCellStyle(1) = "border-style:none"
                        'ExcelC.pCellVal(1, "colspan=10") = ""
                        'ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������
                        '--- ��2005/09/10 DEL Falcon�� ---

                    End If

                    '�o���Ή����̂ݏo�������o�͂���悤�ɏC��
                    'If strSTD_CD.Length <> 0 And Convert.ToString(dr.Item("TAIOKBN")) = "2" Then
                    '    '41�s��
                    '    ExcelC.pCellStyle(1) = "border-style:none"
                    '    ExcelC.pCellVal(1, "colspan=10") = "<<�o����БΉ����e>>"
                    '    ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                    '    '42�s��
                    '    '--- ��2005/05/23 MOD Falcon�� ---
                    '    ExcelC.pCellStyle(1) = "border-style:none"
                    '    'ExcelC.pCellVal(1, "colspan=10") = "�o���ϑ���i�w��ۈ��@�ցj�F" & Convert.ToString(dr.Item("SYUTDTNM"))
                    '    'ExcelC.pCellVal(1, "colspan=10") = "�o���ϑ���i�w��ۈ��@�ցj�F" & Convert.ToString(dr.Item("TSTANNM"))
                    '    ExcelC.pCellVal(1, "colspan=10") = "�o���ϑ���i�w��ۈ��@�ցj�F" & Convert.ToString(dr.Item("STD"))
                    '    ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������
                    '    '--- ��2005/05/23 MOD Falcon�� ---

                    '    '43�s��
                    '    ExcelC.pCellStyle(1) = "border-style:none"
                    '    ExcelC.pCellVal(1, "colspan=10") = "�x���E���_���F" & Convert.ToString(dr.Item("STD_KYOTEN"))
                    '    ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                    '    '44�s��
                    '    ExcelC.pCellStyle(1) = "border-style:none"
                    '    ExcelC.pCellStyle(2) = "border-style:none"
                    '    ExcelC.pCellStyle(3) = "border-style:none"
                    '    '--- ��2005/05/21 MOD Falcon�� ---
                    '    'ExcelC.pCellVal(1, "colspan=3") = "�Ή��ҁF" & Convert.ToString(dr.Item("TSTANNM"))
                    '    ExcelC.pCellVal(1, "colspan=3") = "�Ή��ҁF" & Convert.ToString(dr.Item("SYUTDTNM"))
                    '    '--- ��2005/05/21 MOD Falcon�� ---
                    '    ExcelC.pCellVal(2, "colspan=3") = "�������ԁF" & fncDateSet(Convert.ToString(dr.Item("TYAKYMD"))) & " " & fncTimeSet(Convert.ToString(dr.Item("TYAKTIME")))
                    '    ExcelC.pCellVal(3, "colspan=4") = "�[�u�������ԁF" & fncDateSet(Convert.ToString(dr.Item("SYOKANYMD"))) & " " & fncTimeSet(Convert.ToString(dr.Item("SYOKANTIME")))
                    '    ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                    '    '45�s��
                    '    ExcelC.pCellStyle(1) = "border-style:none"
                    '    ExcelC.pCellVal(1, "colspan=10") = "�Ή�����F" & Convert.ToString(dr.Item("AITNM"))
                    '    ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                    '    '46�s��
                    '    ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������
                    'End If

                    ''47�s��
                    'ExcelC.pCellStyle(1) = "border-style:none"
                    ''''''ExcelC.pCellVal(1, "colspan=10") = "�y���q�l�̂��b���e�z"
                    'If Convert.ToString(dr.Item("CSNTNGAS")) = "1" Then
                    '    ExcelC.pCellVal(1, "colspan=10") = "�y���q�l�̂��b���e�z " & Convert.ToString(dr.Item("SDTBIK1"))
                    'Else
                    '    If Convert.ToString(dr.Item("METFUKKI")) = "1" Then
                    '        ExcelC.pCellVal(1, "colspan=10") = "�y���q�l�̂��b���e�z " & "���[�^���A"
                    '    ElseIf Convert.ToString(dr.Item("HOAN")) = "1" Then
                    '        ExcelC.pCellVal(1, "colspan=10") = "�y���q�l�̂��b���e�z " & "�ۈ�"
                    '    ElseIf Convert.ToString(dr.Item("GASGIRE")) = "1" Then
                    '        ExcelC.pCellVal(1, "colspan=10") = "�y���q�l�̂��b���e�z " & "�K�X�؂�"
                    '    ElseIf Convert.ToString(dr.Item("KIGKOSYO")) = "1" Then
                    '        ExcelC.pCellVal(1, "colspan=10") = "�y���q�l�̂��b���e�z " & "���̏�"
                    '    ElseIf Convert.ToString(dr.Item("CSNTGEN")) = "1" Then
                    '        ExcelC.pCellVal(1, "colspan=10") = "�y���q�l�̂��b���e�z " & "���̑�"
                    '    Else
                    '        ExcelC.pCellVal(1, "colspan=10") = "�y���q�l�̂��b���e�z " & ""
                    '    End If
                    'End If
                    'ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                    ''49�s��
                    'ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                    ''50�s��
                    'ExcelC.pCellStyle(1) = "border-style:none"
                    'ExcelC.pCellStyle(2) = "border-style:none"
                    'ExcelC.pCellVal(1, "colspan=5") = "���A�Ή��F" & Convert.ToString(dr.Item("FKINM"))
                    ''--- ��2005/05/23 MOD Falcon�� ---
                    'If strSTD_CD.Length = 0 Then
                    '    ExcelC.pCellVal(2, "colspan=5") = "�ȈՃK�X���̑ݗ^�F"
                    'Else
                    '    If Convert.ToString(dr.Item("KIGTAIYO")) = "1" Then  '1:�L
                    '        ExcelC.pCellVal(2, "colspan=5") = "�ȈՃK�X���̑ݗ^�F" & "�L"
                    '    Else
                    '        ExcelC.pCellVal(2, "colspan=5") = "�ȈՃK�X���̑ݗ^�F" & "��"
                    '    End If
                    'End If
                    ''--- ��2005/05/23 MOD Falcon�� ---
                    'ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                    ''51�s��
                    'ExcelC.pCellStyle(1) = "border-style:none"
                    'ExcelC.pCellStyle(2) = "border-style:none"
                    'ExcelC.pCellVal(1, "colspan=5") = "�A���󋵁@�A������F" & Convert.ToString(dr.Item("JAKENREN")) & "�@�l"
                    'ExcelC.pCellVal(2, "colspan=5") = "�A�����ԁF" & fncTimeSet(Convert.ToString(dr.Item("RENTIME")))
                    'ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                    ''52�s��
                    'ExcelC.pCellStyle(1) = "border-style:none"
                    'ExcelC.pCellStyle(2) = "border-style:none"
                    ''--- ��2005/05/23 MOD Falcon�� ---
                    'If strSTD_CD.Length = 0 Then
                    '    ExcelC.pCellVal(1, "colspan=2") = "�K�X�R��_���F"
                    '    ExcelC.pCellVal(2, "colspan=8") = "�����F"
                    'Else
                    '    If Convert.ToString(dr.Item("GASMUMU")) = "0" Then  ' 0�F�L�@1�F��
                    '        ExcelC.pCellVal(1, "colspan=2") = "�K�X�R��_���F" & "�L"
                    '    Else
                    '        ExcelC.pCellVal(1, "colspan=2") = "�K�X�R��_���F" & "��"
                    '    End If
                    '    If Convert.ToString(dr.Item("ORGENIN")) = "1" Then  '�K�X���@1:�L
                    '        ExcelC.pCellVal(2, "colspan=8") = "�����F" & "�K�X���"
                    '    Else
                    '        ExcelC.pCellVal(2, "colspan=8") = "�����F" & ""
                    '    End If
                    'End If
                    ''--- ��2005/05/23 MOD Falcon�� ---
                    'ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                    ''53�s��
                    'ExcelC.pCellStyle(1) = "border-style:none"
                    'ExcelC.pCellStyle(2) = "border-style:none"
                    ''--- ��2005/05/23 MOD Falcon�� ---
                    'If strSTD_CD.Length = 0 Then
                    '    ExcelC.pCellVal(1, "colspan=2") = "�K�X�؂�_���F"
                    '    ExcelC.pCellVal(2, "colspan=8") = "�S���z�[�X�����F"
                    'Else
                    '    If Convert.ToString(dr.Item("GASGUMU")) = "0" Then      '0�F�L�@1�F��
                    '        ExcelC.pCellVal(1, "colspan=2") = "�K�X�؂�_���F" & "�L"
                    '    Else
                    '        ExcelC.pCellVal(1, "colspan=2") = "�K�X�؂�_���F" & "��"
                    '    End If
                    '    If Convert.ToString(dr.Item("HOSKOKAN")) = "0" Then     '0�F���{�@1�F�����{
                    '        'ExcelC.pCellVal(2, "colspan=8") = "�S���z�[�X�����F" & "�����{"    '--- 2005/05/23 DEL Falcon ---
                    '        ExcelC.pCellVal(2, "colspan=8") = "�S���z�[�X�����F" & "���{"
                    '    Else
                    '        ExcelC.pCellVal(2, "colspan=8") = "�S���z�[�X�����F" & "�����{"
                    '    End If
                    'End If
                    ''--- ��2005/05/23 MOD Falcon�� ---
                    'ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                    ''54�s��
                    'ExcelC.pCellStyle(1) = "border-style:none"
                    'ExcelC.pCellStyle(2) = "border-style:none"
                    'ExcelC.pCellStyle(3) = "border-style:none"
                    'ExcelC.pCellStyle(4) = "border-style:none"
                    'ExcelC.pCellStyle(5) = "border-style:none"
                    ''--- ��2005/05/23 MOD Falcon�� ---
                    'If strSTD_CD.Length = 0 Then
                    '    ExcelC.pCellVal(1, "colspan=2") = "���[�^�_���F"
                    '    ExcelC.pCellVal(2, "colspan=2") = "�������_���F"
                    '    ExcelC.pCellVal(3, "colspan=2") = "�e��E���ԃo���u�F"
                    '    ExcelC.pCellVal(4, "colspan=2") = "�z�r�C���F"
                    '    ExcelC.pCellVal(5, "colspan=2") = "�b�n�Z�x�F"
                    'Else
                    '    If Convert.ToString(dr.Item("METYOINA")) = "0" Then      '0�F�ǁ@1�F��
                    '        ExcelC.pCellVal(1, "colspan=2") = "���[�^�_���F" & "��"
                    '    Else
                    '        ExcelC.pCellVal(1, "colspan=2") = "���[�^�_���F" & "��"
                    '    End If
                    '    If Convert.ToString(dr.Item("TYOUYOINA")) = "0" Then      '0�F�ǁ@1�F��
                    '        ExcelC.pCellVal(2, "colspan=2") = "�������_���F" & "��"
                    '    Else
                    '        ExcelC.pCellVal(2, "colspan=2") = "�������_���F" & "��"
                    '    End If
                    '    If Convert.ToString(dr.Item("VALYOINA")) = "0" Then      '0�F�ǁ@1�F��
                    '        ExcelC.pCellVal(3, "colspan=2") = "�e��E���ԃo���u�F" & "��"
                    '    Else
                    '        ExcelC.pCellVal(3, "colspan=2") = "�e��E���ԃo���u�F" & "��"
                    '    End If
                    '    If Convert.ToString(dr.Item("KYUHAIUMU")) = "0" Then      '0�F�ǁ@1�F��
                    '        ExcelC.pCellVal(4, "colspan=2") = "�z�r�C���F" & "��"
                    '    Else
                    '        ExcelC.pCellVal(4, "colspan=2") = "�z�r�C���F" & "��"
                    '    End If
                    '    If Convert.ToString(dr.Item("COYOINA")) = "0" Then      '0�F�ǁ@1�F��
                    '        ExcelC.pCellVal(5, "colspan=2") = "�b�n�Z�x�F" & "��"
                    '    Else
                    '        ExcelC.pCellVal(5, "colspan=2") = "�b�n�Z�x�F" & "��"
                    '    End If
                    'End If
                    ''--- ��2005/05/23 MOD Falcon�� ---
                    'ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                    ''55�s��
                    'ExcelC.pCellStyle(1) = "border-style:none"
                    'ExcelC.pCellVal(1, "colspan=10") = "���L�����F" & Convert.ToString(dr.Item("SDTBIK2"))
                    'ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                    ''56�s��
                    'ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                    ''57�s��
                    'ExcelC.pCellStyle(1) = "border-style:none"
                    'ExcelC.pCellVal(1, "colspan=10") = "�i�`�^���A�l�ւ̈˗��������F"
                    'ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                    ''58�s��
                    'ExcelC.pCellStyle(1) = "border-style:none"
                    'ExcelC.pCellVal(1, "colspan=10") = Convert.ToString(dr.Item("SNTTOKKI"))
                    'ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������
                    '--- ��2005/05/31 MOD Falcon�� ---

                    intRowCount = intRowCount + 1

                    If intRowCount <> ds.Tables(0).Rows.Count Then
                        '���y�[�W
                        ExcelC.mWriteLine("", True)
                    End If

                    '����FAX��p���O�o�͗p�Ƀf�[�^�Z�b�g�@2013/09/25 T.Watabe add
                    wkstrTAIOU_SYONO = Convert.ToString(dr.Item("SYONO"))
                    wkstrTAIOU_KURACD = Convert.ToString(dr.Item("CLI_CD"))
                    wkstrTAIOU_JACD = Convert.ToString(dr.Item("JACD"))
                    wkstrTAIOU_ACBCD = Convert.ToString(dr.Item("ACBCD"))
                    wkstrTAIOU_USER_CD = Convert.ToString(dr.Item("ACBCD")) & Convert.ToString(dr.Item("USER_CD"))
                    wkstrAUTO_ZERO_FLG = "0" ' �y�[�������M�t���O�z 0:�f�[�^����/1:�[�����I(�f�[�^�Ȃ�)
                    intSEQNO = intSEQNO + 1

                    mlog(pstrSESSION & "\" & pstrKANSI_CODE & "\" & pstrKURACD_F & "\" & pstrKURACD_T, "BTFAXJAX00:mExcelOut�F6�i�񍐂���jSYONO�F" & wkstrTAIOU_SYONO) '2014/04/11 T.Ono add ���O����
                    '����FAX��p���O�o�́@2013/09/25 T.Watabe add
                    Call mInsertS05AutofaxLog(cdb,
                                            strEXEC_YMD,
                                            strEXEC_TIME,
                                            pstrSEND_KBN,
                                            strGUID,
                                            intSEQNO,
                                            pstrTAISYOUBI,
                                            "1",
                                            pstrKANSI_CODE,
                                            wkstrTAIOU_SYONO,
                                            wkstrTAIOU_KURACD,
                                            wkstrTAIOU_JACD,
                                            wkstrTAIOU_ACBCD,
                                            wkstrTAIOU_USER_CD,
                                            pstrAUTO,
                                            pstrFAXNO,
                                            pstrMAILAD,
                                            wkstrAUTO_ZERO_FLG,
                                            pstrWHERE_TAIOU,
                                            "" & pintDebugSQLNo,
                                            ""
                                            )
                Next
            End If

            '�t�@�C���N���[�Y
            ExcelC.mClose()
            If pintDebugSQLNo = 109 Then ' DEBUG
                Return "DEBUG:(" & pintDebugSQLNo & ")[ExcelC.pDirName=" & ExcelC.pDirName & "]"
            End If
            mlog(pstrSESSION & "\" & pstrKANSI_CODE & "\" & pstrKURACD_F & "\" & pstrKURACD_T, "BTFAXJAX00:mExcelOut�F7") '2014/04/11 T.Ono add ���O����
            If pintDebugSQLNo = 0 Then ' �ʏ�

                '���k��t�@�C���̂���t�H���_
                compressC.p_Dir = ExcelC.pDirName
                '���{��t�@�C�����̎w��(�p�����[�^[�Z�b�V����] + �d�b�ԍ�)
                If pstrAUTO = "1" Then '1:fax
                    '�e�`�w�t�@�C���쐬
                    'compressC.p_NihongoFileName = pstrSESSION & pstrFAXNO & ".xls" '20050506 edit Falcon
                    'compressC.p_NihongoFileName = pstrSESSION & pstrAUTO & pstrFAXNO & ".xls"
                    compressC.p_NihongoFileName = pstrSESSION & "[" & pstrAUTO & "][" & pstrFAXNO & "].xls"
                    '���k���t�@�C����      (��L�쐬����EXCEL�t�@�C��)(LZH�ɒǉ�����)
                    compressC.p_FileName = ExcelC.pDirName & ExcelC.pFileName & ".xls"
                Else
                    '���[�����M�t�@�C���쐬

                    ' 2008/12/12 T.Watabe add
                    'ZIP�Ɉ��k
                    'fncZipTest(ExcelC.pDirName & ExcelC.pFileName & ".xls", ExcelC.pDirName & ExcelC.pFileName & ".zip")
                    fncMakeZipWithPass(ExcelC.pDirName & ExcelC.pFileName & ".xls", ExcelC.pDirName & ExcelC.pFileName & ".zip", sZipFilePass) ' 2014/06/17 T.Watabe edit
                    'fncMakeZipWithPass2(ExcelC.pDirName & ExcelC.pFileName & ".xls", ExcelC.pDirName & ExcelC.pFileName & ".zip", sZipFilePass)

                    'compressC.p_NihongoFileName = pstrSESSION & pstrMAILAD & ".xls" '20050506 edit Falcon
                    'compressC.p_NihongoFileName = pstrSESSION & pstrAUTO & pstrMAILAD & ".xls" '2008/12/12 T.Watabe edit
                    'compressC.p_NihongoFileName = pstrSESSION & pstrAUTO & pstrMAILAD & ".xls.zip" '2011/03/10 T.Watabe edit
                    'compressC.p_NihongoFileName = pstrSESSION & pstrAUTO & "(" & cliCd4FileHead & ")" & pstrMAILAD & ".xls.zip"
                    'compressC.p_NihongoFileName = pstrSESSION & "[" & pstrAUTO & "][" & pstrMAILAD & "][" & cliCd4FileHead & "][" & jaName4FileHead & "].xls.zip"

                    If pstrSEND_KBN = "1" Then '1:�̔����H
                        compressC.p_NihongoFileName = pstrSESSION & "[" & pstrAUTO & "][" & pstrMAILAD & "][" & cliCd4FileHead & "][" & jaName4FileHead & "].xls.zip"
                    Else
                        compressC.p_NihongoFileName = pstrSESSION & "[" & pstrAUTO & "][" & pstrMAILAD & "][" & cliCd4FileHead & "][" & centerName & "].xls.zip"
                    End If


                    '���k���t�@�C����      (��L�쐬����EXCEL�t�@�C�������̖��O��LZH�ɒǉ�����)
                    compressC.p_FileName = ExcelC.pDirName & ExcelC.pFileName & ".zip"
                End If

                '���k��t�@�C����      (�p�����[�^[�Z�b�V����])���Q��ڈȍ~�̎��͒ǉ������
                compressC.p_madeFilename = ExcelC.pDirName & pstrSESSION & ".lzh"
                '�𓀐�̃p�X���w��
                If pstrFlg = "1" Then
                    compressC.p_ToDir = pstrCreateFilePath & "\"
                End If
                '�𓀌㎩�����s����
                compressC.p_Exec = False
                '���k���s
                compressC.mCompress()
                mlog(pstrSESSION & "\" & pstrKANSI_CODE & "\" & pstrKURACD_F & "\" & pstrKURACD_T, "BTFAXJAX00:mExcelOut�F8") '2014/04/11 T.Ono add ���O����

                Try
                    ' 2013/10/01 T.Watabe �t�@�C�������A�w����{�e�`�w�ԍ��Ƃ��ăR�s�[�쐬���郍�W�b�N�B�g���u���Ή����Ɏg�p�B
                    'Dim wk As String
                    'wk = pstrTAISYOUBI & "_" & pstrFAXNO & pstrMAILAD
                    'System.IO.File.Copy(ExcelC.pDirName & ExcelC.pFileName & ".xls", ExcelC.pDirName & wk & ".xls", True)
                Catch ex As Exception
                End Try


                fncFileKill(ExcelC.pDirName & ExcelC.pFileName & ".xls") '�G�N�Z���t�@�C���폜�I
                fncFileKill(ExcelC.pDirName & ExcelC.pFileName & ".zip") 'zip�t�@�C���폜�I

                '���k�����t�@�C����Base64�G���R�[�h���Ė߂�
                Return FileToStrC.mFileToStr(compressC.p_madeFilename.Replace(".lzh", ".exe"))
            End If
        Catch ex As Exception
            mlog(pstrSESSION & "\" & pstrKANSI_CODE & "\" & pstrKURACD_F & "\" & pstrKURACD_T, _
                 "[" & faxUser & "]" & "[" & ex.ToString & "][" & ex.Source & "][" & ex.Message & "]" & Environment.StackTrace)
            '�G���[�̓��e�Ƃr�p�k����Ԃ�
            Return "ERROR:" & ex.ToString & vbCrLf & vbCrLf & Environment.StackTrace & vbCrLf & " ���O��SQL[" & strSQL.ToString & "]"

        Finally

        End Try

        Return "THROW_DEBUG"
    End Function

    '****************************************************************
    'YYYYMMDD �� YYYY�NMM��DD��
    '****************************************************************
    Private Function fncEdit_Date(ByVal strDate As String) As String
        If strDate.Length = 8 Then
            Return strDate.Substring(0, 4) & "�N" & strDate.Substring(4, 2) & "��" & strDate.Substring(6, 2) & "��"
        Else
            Return ""
        End If
    End Function

    '****************************************************************
    'YYYYMMDD �� YYYY/MM/DD
    '****************************************************************
    Private Function fncDateSet(ByVal strDate As String) As String
        If strDate.Length = 8 Then
            Return strDate.Substring(0, 4) & "/" & strDate.Substring(4, 2) & "/" & strDate.Substring(6, 2)
        Else
            Return ""
        End If
    End Function

    '****************************************************************
    'HHMISS �� HH��MI��
    '****************************************************************
    Private Function fncEdit_Time(ByVal strTime As String) As String
        If strTime.Length = 4 Then
            Return strTime.Substring(0, 2) & "��" & strTime.Substring(2, 2) & "��"
        Else
            Return ""
        End If
    End Function

    '****************************************************************
    'HHMISS �� HH:MI
    '****************************************************************
    Private Function fncTimeSet(ByVal strTime As String) As String
        If strTime.Length = 4 Or strTime.Length = 6 Then
            Return strTime.Substring(0, 2) & ":" & strTime.Substring(2, 2)
        Else
            Return ""
        End If
    End Function

    '************************************************
    '�w�肳�ꂽ�������Z���܂�
    '************************************************
    Private Function fncAdd_Date(ByVal pstrDate As String, ByVal pintDate As Integer) As String
        Dim strRec As String
        Try
            strRec = Format(DateSerial(CInt(pstrDate.Substring(0, 4)), CInt(pstrDate.Substring(4, 2)), CInt(pstrDate.Substring(6, 2)) + pintDate), "yyyyMMdd")
        Catch ex As Exception
            strRec = ""
        End Try
        Return strRec
    End Function

    '******************************************************************************
    '*�@�T�@�v�F������o�C�g�w�蕶���擾
    '*�@���@�l�F
    '******************************************************************************
    Private Function MidB(ByVal pstrText As String, ByVal pintSt As Integer, ByVal pintLenb As Integer) As String
        Dim i As Integer
        Dim intCd As Integer
        Dim intBt As Integer
        Dim strTmp As String
        Dim strRec As String
        strRec = ""
        If pintSt < 1 Or pintLenb < 1 Then Return strRec
        For i = 1 To Len(pstrText)
            If intBt + 1 >= pintSt Then Exit For
            strTmp = Mid(pstrText, i, 1)
            intBt = intBt + LenB(strTmp)
        Next
        If i > Len(pstrText) Then Return strRec
        intBt = 0
        For i = i To Len(pstrText)
            strTmp = Mid(pstrText, i, 1)
            intBt = intBt + LenB(strTmp)
            If intBt > pintLenb Then Exit For
            strRec = strRec + strTmp
        Next
        Return strRec
    End Function

    '******************************************************************************
    '*�@�T�@�v�F������o�C�g�擾
    '*�@���@�l�F
    '******************************************************************************
    Private Function LenB(ByVal pstrString As String) As Integer
        Return System.Text.Encoding.GetEncoding(932).GetByteCount(pstrString)

    End Function

    '2011/11/14 ADD H.Uema
    '******************************************************************************
    '*�@�T�@�v�F�n�C�t����菜���֐���t�^����SQL���\�z
    '*�@���@�l�F�����̒�����0�̏ꍇ, "'X'"��ԋp����
    '******************************************************************************
    Private Function ReplaceHyphen(ByVal pstrString As String) As String
        If (pstrString.Length > 0) Then
            Return "REPLACE(" & pstrString & ", '-')"
        Else
            Return "'X'"
        End If
    End Function

    '******************************************************************************
    '*�@�T�@�v�F�t�@�C���̈��k(zip) vjslib.dll�g�p(.Net�t���[�����[�N J#)(�v�Q�Ɛݒ�)
    '*�@���@�l�F
    '******************************************************************************
    'Private Sub fncZipTest(ByVal sXlsFilePath As String, ByVal sZipFilePath As String)
    '    Dim outStream As New java.util.zip.ZipOutputStream(New java.io.FileOutputStream(sZipFilePath))
    '    putFileToZip(outStream, sXlsFilePath)
    '    outStream.close()
    'End Sub
    'Private Sub putFileToZip(ByVal outStream As java.util.zip.ZipOutputStream, ByVal Path As String)
    '    Dim size As Integer = CInt(FileLen(Path))
    '    Dim inStream As New java.io.BufferedInputStream(New java.io.FileInputStream(Path))
    '    Dim crc As New java.util.zip.CRC32
    '    Dim buf(size - 1) As SByte
    '    If inStream.read(buf, 0, size) <> -1 Then
    '        crc.update(buf, 0, size)
    '        outStream.write(buf, 0, size)
    '    End If
    '    Dim entry As New java.util.zip.ZipEntry(System.IO.Path.GetFileName(Path))
    '    entry.setMethod(java.util.zip.ZipEntry.DEFLATED)
    '    entry.setSize(size)
    '    entry.setCrc(crc.getValue())
    '    outStream.putNextEntry(entry)
    '    inStream.close()
    '    outStream.closeEntry()
    '    outStream.flush()
    'End Sub

    '******************************************************************************
    '*�@�T�@�v�F�t�@�C���̈��k(zip) ICSharpCode.SharpZipLib.dll�g�p(�v�Q�Ɛݒ�)
    '*�@���@�l�F
    '******************************************************************************
    Private Sub fncMakeZipWithPass(ByVal sXlsFilePath As String, ByVal sZipFilePath As String, ByVal sPass As String)

        '���k����t�@�C���̐ݒ� 
        'Dim filePaths(100) As String
        Dim crc As ICSharpCode.SharpZipLib.Checksums.Crc32

        Dim writer As System.IO.FileStream
        Dim zos As ICSharpCode.SharpZipLib.Zip.ZipOutputStream
        Dim f As String
        Dim fs As System.IO.FileStream
        Dim buffer() As Byte
        Dim ze As ICSharpCode.SharpZipLib.Zip.ZipEntry

        Dim file As String
        'filePaths(0) = sXlsFilePath

        If Len(sPass) <= 0 Then
            sPass = "jalp" '�p�X���[�h�̃f�t�H���g��jalp
        End If

        crc = New ICSharpCode.SharpZipLib.Checksums.Crc32
        writer = New System.IO.FileStream( _
                        sZipFilePath, System.IO.FileMode.Create, _
                        System.IO.FileAccess.Write, _
                        System.IO.FileShare.Write)
        zos = New ICSharpCode.SharpZipLib.Zip.ZipOutputStream(writer)

        ' ���k���x����ݒ肷�� 
        zos.SetLevel(6)
        ' �p�X���[�h��ݒ肷�� 
        zos.Password = sPass

        ' Zip�Ƀt�@�C����ǉ����� 
        If True Then
            'For Each file As String In filePaths '(�����t�@�C�����P��zip�Ɉ��k���邱�Ƃ��ł���B)
            file = sXlsFilePath

            ' ZIP�ɒǉ�����Ƃ��̃t�@�C���������肷�� 
            f = System.IO.Path.GetFileName(file)
            ze = New ICSharpCode.SharpZipLib.Zip.ZipEntry(f)
            ze.CompressionMethod = ICSharpCode.SharpZipLib.Zip.CompressionMethod.Stored '����1�s��Windows�W���ł�PASS�𓀖�肪�����I�H

            ' �w�b�_��ݒ肷�� 
            ' �t�@�C����ǂݍ��� 
            fs = New System.IO.FileStream( _
                        file, _
                        System.IO.FileMode.Open, _
                        System.IO.FileAccess.Read, _
                        System.IO.FileShare.Read)
            ReDim buffer(CInt(fs.Length))

            fs.Read(buffer, 0, buffer.Length)
            fs.Close()
            ' CRC��ݒ肷�� 
            crc.Reset()
            crc.Update(buffer)
            ze.Crc = crc.Value
            ' �T�C�Y��ݒ肷�� 
            ze.Size = buffer.Length

            ' ���Ԃ�ݒ肷�� 
            ze.DateTime = DateTime.Now

            ' �V�����G���g���̒ǉ����J�n 
            zos.PutNextEntry(ze)
            ' �������� 
            zos.Write(buffer, 0, buffer.Length)

            'Next
        End If

        zos.Close()
        writer.Close()
    End Sub

    ' 2015/01/22 T.Watabe del
    ''******************************************************************************
    ''*�@�T�@�v�F�t�@�C���̈��k(zip) Ionic.Zip.dll�g�p(�v�Q�Ɛݒ�) 2014/06/17 T.Watabe add
    ''*�@���@�l�F
    ''******************************************************************************
    'Private Sub fncMakeZipWithPass2(ByVal sXlsFilePath As String, ByVal sZipFilePath As String, ByVal sPass As String)

    '    Dim zip As Ionic.Zip.ZipFile
    '    zip = New Ionic.Zip.ZipFile()
    '    zip.CompressionLevel = Ionic.Zlib.CompressionLevel.BestCompression
    '    zip.AlternateEncoding = System.Text.Encoding.GetEncoding("shift_jis")
    '    zip.AlternateEncodingUsage = Ionic.Zip.ZipOption.Always

    '    If Len(sPass) <= 0 Then
    '        sPass = "jalp" '�p�X���[�h�̃f�t�H���g��jalp
    '    End If
    '    zip.Password = sPass
    '    '// zip.Encryption = Ionic.Zip.EncryptionAlgorithm.WinZipAes256 //AES 256�r�b�g�Í���

    '    If (Directory.Exists(sXlsFilePath)) Then
    '        '//�t�H���_
    '        zip.AddDirectory(sXlsFilePath, "") '(source,"dir")
    '    Else
    '        '//�t�@�C��
    '        zip.AddFile(sXlsFilePath, "") '//(source,"dir")
    '    End If
    '    zip.Save(sZipFilePath)
    'End Sub

    '2008/12/15 T.Watabe add
    Function fncFileKill(ByVal sFilePath As String) As Boolean
        Dim bErr As Boolean
        bErr = False
        Try
            Kill(sFilePath)
        Catch ex As Exception
            bErr = True
        End Try
        Return bErr
    End Function



    '*****************************************************************
    '*�@�T�@�v�F�o�b�`���s���O���擾
    '*****************************************************************
    <WebMethod()> Public Function dispBatchLog(ByRef batchLog As String) As Boolean

        Dim ds As New DataSet
        Dim cdb As New CDB
        Dim dr As DataRow

        batchLog = ""

        'batchLog = "test"
        'Return True
        'Exit Function

        '---------------------------------------------
        '�ڑ�������̐ݒ�
        '---------------------------------------------
        'cdb.pJPUID = ConfigurationSettings.AppSettings("DB_USER_ID")
        'cdb.pJPPWD = ConfigurationSettings.AppSettings("DB_PASSWORD")
        'cdb.pJPDB = ConfigurationSettings.AppSettings("DB_SID")

        '---------------------------------------------
        '�v�[���̍ŏ��l�ݒ�
        '---------------------------------------------
        cdb.pConnectPoolSize = 1

        '�ڑ�OPEN----------------------------------------
        Try
            cdb.mOpen()
        Catch ex As Exception
            Return False
        Finally

        End Try

        Try
            '�g�����U�N�V�����J�n
            cdb.mBeginTrans()

            '�Ή��c�a�@D20_TAIOU
            Dim sql As New StringBuilder
            sql.Append("SELECT ")
            sql.Append("    TO_CHAR(TO_DATE(ST_YMD || ST_TIME,'YYYYMMDDHH24MISS'), 'YYYY/MM/DD HH24:MI') AS ST, ")
            sql.Append("    LPAD(TRUNC(EXEC_SEC / 1000,0), 5, ' ') || '�b' AS MIN, ")
            sql.Append("    SUBSTRB(MSG, 1,80) AS MSG ")
            sql.Append("FROM S02_BACHDB  ")
            sql.Append("WHERE PROC_ID = 'BTCHKJAE00' ")
            sql.Append("ORDER BY ST_YMD || ST_TIME DESC ")
            cdb.pSQL = sql.ToString
            cdb.mExecQuery() 'SQL���s�I

            '���ʂ��f�[�^�Z�b�g�Ɋi�[
            ds = cdb.pResult

            '�f�[�^�����݂��Ȃ��ꍇ
            If ds.Tables(0).Rows.Count = 0 Then

                batchLog = "0��"
            Else
                Dim i As Integer = 0
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    If i >= 50 Then Exit For '50���܂�

                    dr = ds.Tables(0).Rows(i)
                    'arrBatchLog.Add(Convert.ToString(dr.Item("ST")) & Convert.ToString(dr.Item("MIN")) & " " & Convert.ToString(dr.Item("MSG")))
                    If batchLog.Length > 0 Then batchLog = batchLog & "$$" '$$�͊֐�����擾�������s�t��������̉��s�����܂�����Ȃ��ׁB
                    batchLog = batchLog & Convert.ToString(dr.Item("ST")) & Convert.ToString(dr.Item("MIN")) & " " & Convert.ToString(dr.Item("MSG"))
                Next
            End If

        Catch ex As Exception
            batchLog = ex.ToString
            Return False
        Finally
            '�ڑ��N���[�Y
            cdb.mClose()
        End Try
        cdb = Nothing

        Return True

    End Function

    ' 2010/09/15 T.Watabe add
    '*****************************************************************
    '*�@�T�@�v�FDB SID��߂�
    '*****************************************************************
    <WebMethod()> Public Function getDBSID() As String
        Dim res As String = ""
        Try
            res = ConfigurationSettings.AppSettings("JPDB")
        Catch ex As Exception
            res = "JPDB �Q�ƃG���[:" & ex.ToString
        End Try
        Return res
    End Function

    '******************************************************************************
    '*�@�T�@�v�FS05_AUTOFAXLOGDB ����FAX�̃��O���L�^����B
    '*�@���@�l�F
    '*  ��  ���F2013/09/25 T.Watabe
    '******************************************************************************
    Private Function mInsertS05AutofaxLog(ByVal cdb As CDB,
                                        ByVal pstrEXEC_YMD As String,
                                        ByVal pstrEXEC_TIME As String,
                                        ByVal pstrEXEC_KBN As String,
                                        ByVal pstrGUID As String,
                                        ByVal pintSEQNO As Integer,
                                        ByVal pstrINPUT_YMD As String,
                                        ByVal pstrLATEST_OF_DAY_FLG As String,
                                        ByVal pstrTAIOU_KANSCD As String,
                                        ByVal pstrTAIOU_SYONO As String,
                                        ByVal pstrTAIOU_KURACD As String,
                                        ByVal pstrTAIOU_JACD As String,
                                        ByVal pstrTAIOU_ACBCD As String,
                                        ByVal pstrTAIOU_USER_CD As String,
                                        ByVal pstrAUTO_KBN As String,
                                        ByVal pstrAUTO_FAXNO As String,
                                        ByVal pstrAUTO_MAIL As String,
                                        ByVal pstrAUTO_ZERO_FLG As String,
                                        ByVal pstrWHERE_TAIOU As String,
                                        ByVal pstrDEBUGFLG As String,
                                        ByVal pstrBIKO As String
                                        ) As String

        Dim sql As New StringBuilder("")

        Try
            '�����ҏW
            pstrWHERE_TAIOU = Replace(pstrWHERE_TAIOU, "'", "''") '�J���}���Q�d��
            pstrWHERE_TAIOU = Replace(pstrWHERE_TAIOU, vbCrLf, "") '���s���͂���
            pstrWHERE_TAIOU = Replace(pstrWHERE_TAIOU, "  ", " ") '�X�y�[�X���l�߂�

            '/* ����FAX��p���O�e�[�u���֏o�� */
            sql = New StringBuilder("")
            sql.Append("INSERT INTO S05_AUTOFAXLOGDB ")
            sql.Append("(")
            sql.Append("    EXEC_YMD     ,")
            sql.Append("    EXEC_TIME    ,")
            sql.Append("    EXEC_KBN    ,")
            sql.Append("    GUID         ,")
            sql.Append("    SEQNO        ,")
            sql.Append("    INPUT_YMD       ,")
            sql.Append("    LATEST_OF_DAY_FLG       ,")
            sql.Append("    TAIOU_KANSCD       ,")
            sql.Append("    TAIOU_SYONO        ,")
            sql.Append("    TAIOU_KURACD       ,")
            sql.Append("    TAIOU_JACD         ,")
            sql.Append("    TAIOU_ACBCD        ,")
            sql.Append("    TAIOU_USER_CD      ,")
            sql.Append("    AUTO_KBN     ,")
            sql.Append("    AUTO_FAXNO   ,")
            sql.Append("    AUTO_MAIL    ,")
            sql.Append("    AUTO_ZERO_FLG,")
            sql.Append("    SQLWHERE,")
            sql.Append("    DEBUGFLG,")
            sql.Append("    BIKO,")
            sql.Append("    ADD_DATE      ")
            sql.Append(")VALUES( ")
            sql.Append("    '" & pstrEXEC_YMD & "', ")
            sql.Append("    '" & pstrEXEC_TIME & "', ")
            sql.Append("    '" & pstrEXEC_KBN & "', ")
            sql.Append("    '" & pstrGUID & "', ")
            sql.Append("     " & pintSEQNO & ", ")
            sql.Append("    '" & pstrINPUT_YMD & "', ")
            sql.Append("    '" & pstrLATEST_OF_DAY_FLG & "', ")
            sql.Append("    '" & pstrTAIOU_KANSCD & "', ")
            sql.Append("    '" & pstrTAIOU_SYONO & "', ")
            sql.Append("    '" & pstrTAIOU_KURACD & "', ")
            sql.Append("    '" & pstrTAIOU_JACD & "', ")
            sql.Append("    '" & pstrTAIOU_ACBCD & "', ")
            sql.Append("    '" & pstrTAIOU_USER_CD & "', ")
            sql.Append("    '" & pstrAUTO_KBN & "', ")
            sql.Append("    '" & pstrAUTO_FAXNO & "', ")
            sql.Append("    '" & pstrAUTO_MAIL & "', ")
            sql.Append("    '" & pstrAUTO_ZERO_FLG & "', ")
            sql.Append("    '" & pstrWHERE_TAIOU & "', ")
            sql.Append("    '" & pstrDEBUGFLG & "', ")
            sql.Append("    '" & pstrBIKO & "', ")
            sql.Append("    SYSDATE ")
            sql.Append(") ")

            cdb.mBeginTrans() '�g�����U�N�V�����J�n
            cdb.pSQL = sql.ToString '//SQL�Z�b�g
            cdb.mExecNonQuery() '//SQL���s
            cdb.mCommit() '�g�����U�N�V�����I��(�R�~�b�g)
        Catch ex As Exception
            cdb.mRollback() '�g�����U�N�V�����I��(���[���o�b�N)
            '�G���[�̓��e�Ƃr�p�k����Ԃ�
            Return "ERROR:" & ex.ToString & vbCrLf & vbCrLf & Environment.StackTrace & vbCrLf & " ���O��SQL[" & sql.ToString & "]"
        Finally
        End Try

        Return "OK"

    End Function
    '******************************************************************************
    '*�@�T�@�v�FS05_AUTOFAXLOGDB ����FAX�̃��O�̑O�񕪂��N���A����B
    '*�@���@�l�F
    '*  ��  ���F2013/09/25 T.Watabe
    '******************************************************************************
    Private Function mUpdateFlgS05AutofaxLog(ByVal cdb As CDB,
                                        ByVal pstrEXEC_KBN As String,
                                        ByVal pstrINPUT_YMD As String,
                                        ByVal pstrAUTO_KBN As String,
                                        ByVal pstrAUTO_FAXNO As String,
                                        ByVal pstrAUTO_MAIL As String
                                        ) As String

        Dim sql As New StringBuilder("")

        Try
            '/* ����FAX��p���O�e�[�u�����X�V */
            sql = New StringBuilder("")
            sql.Append("UPDATE S05_AUTOFAXLOGDB ")
            sql.Append("SET LATEST_OF_DAY_FLG = '0' ") '�@�O��쐬�f�[�^���Â��Ɣ��ʂł���悤�Ƀt���O�ς���
            sql.Append("WHERE 1=1 ")
            sql.Append("    AND EXEC_KBN  = '" & pstrEXEC_KBN & "' ")
            sql.Append("    AND INPUT_YMD = '" & pstrINPUT_YMD & "' ")
            sql.Append("    AND LATEST_OF_DAY_FLG = '1' ")
            If pstrAUTO_KBN = "1" Then
                sql.Append("    AND AUTO_FAXNO = '" & pstrAUTO_FAXNO & "' ")
            Else
                sql.Append("    AND AUTO_MAIL = '" & pstrAUTO_MAIL & "' ")
            End If

            cdb.mBeginTrans() '�g�����U�N�V�����J�n
            cdb.pSQL = sql.ToString '//SQL�Z�b�g
            cdb.mExecNonQuery() '//SQL���s
            cdb.mCommit() '�g�����U�N�V�����I��(�R�~�b�g)
        Catch ex As Exception
            cdb.mRollback() '�g�����U�N�V�����I��(���[���o�b�N)
            '�G���[�̓��e�Ƃr�p�k����Ԃ�
            Return "ERROR:" & ex.ToString & vbCrLf & vbCrLf & Environment.StackTrace & vbCrLf & " ���O��SQL[" & sql.ToString & "]"
        Finally
        End Try

        Return "OK"

    End Function
    '**********************************************************
    ' 2012/06/28 ADD W.GANEKO
    '���O�f���o��
    '�߂�l�F�������񂾃t�@�C���ւ̃t���p�X
    '**********************************************************
    Public Sub mlog(ByVal pstrSESSION As String, ByVal pstrString As String)
        'Dim strFilnm As String = "log" & System.DateTime.Today.ToString("yyyyMMdd") '20140417 T.Ono mod
        Dim strKanscd() As String = Split(pstrSESSION, "\")
        Dim strFilnm As String = "log" & strKanscd(1) & "_" & System.DateTime.Today.ToString("yyyyMMdd")
        Dim strLogPath As String = ConfigurationSettings.AppSettings("LOG_OUT_PATH")
        Dim strPath As String = strLogPath & strFilnm & ".txt"
        Dim strLogFlg As String = ConfigurationSettings.AppSettings("LOG_OUT")
        If strLogFlg = "1" Then
            '�������݃t�@�C���ւ̃X�g���[��
            Dim outFile As New StreamWriter(strPath, True, System.Text.Encoding.Default)

            '�����̕�������X�g���[���ɏ�������
            outFile.Write(System.DateTime.Now & ":" & pstrSESSION & ":[" & pstrString + "]" & vbCrLf)

            '�������t���b�V���i�t�@�C���������݁j
            outFile.Flush()

            '�t�@�C���N���[�Y
            outFile.Close()
        End If
    End Sub

End Class
